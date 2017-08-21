Public Class Screen
    Property InitialSpeed As Integer
    Property TimeLeft As Single
    Dim Lbl1Loc, Lbl2Loc, Speed As Integer
    Dim InitialTime As Single
    Dim valCurrent, valNext As String
    Dim Requested(1) As String
    Property LowTime As Boolean
    Private Sub Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbl1Loc = 0
        Lbl2Loc = -200
        valCurrent = "VK Randomizer"
        Try
            Requested = Form1.Request()
            valNext = Requested(1)
        Catch ex As Exception
            valNext = "VK Randomizer"
        End Try

    End Sub

    Private Sub Scroller_Tick(sender As Object, e As EventArgs) Handles Scroller.Tick
        If InitialTime = 0 Then
            InitialTime = TimeLeft
            Speed = InitialSpeed
        End If
        TimeLeft -= 0.02
        If LowTime = False Then
            If (TimeLeft / InitialTime) < 0.5 Then Speed = Math.Truncate(InitialSpeed / 2)
            If (TimeLeft / InitialTime) < 0.25 Then Speed = Math.Truncate(InitialSpeed / 4)
            If (TimeLeft / InitialTime) < 0.125 Then Speed = Math.Truncate(InitialSpeed / 8)
            If TimeLeft < 0.5 Then
                Speed = 8
                'valCurrent = valNext
                ' Requested = Form1.Request()
                '  valNext = Requested(1)
                Lbl1Loc = 0
                Lbl2Loc = -200
                Label2.Text = Label1.Text
                LowTime = True
            End If
        Else
        End If
        Form1.Label2.Text = TimeLeft
        Lbl1Loc += Speed
        Lbl2Loc += Speed
        If Lbl1Loc >= 200 Then
            If TimeLeft > 0.5 Then
                Change()
            End If
        End If
        If LowTime = False Then
            Label1.Text = valCurrent
            Label2.Text = valNext
        End If
        If TimeLeft <= 0 Then
            Form1.AddressTxt.Text = "https://vk.com/id" & Requested(0)
            Scroller.Enabled = False
            Label1.ForeColor = Color.LightGreen
            Lbl1Loc = 0
            Form1.Label2.Text = "Time:"
            Form1.ConsoleLbl.Text = "Ready"
            Lbl2Loc = -200
            InitialTime = 0
        End If
        Dim a As New Point(Label1.Location.X, Lbl1Loc)
        Label1.Location = a
        Dim b As New Point(Label2.Location.X, Lbl2Loc)
        Label2.Location = b
    End Sub

    Private Sub Change()
        valCurrent = valNext
        Requested = Form1.Request()
        valNext = Requested(1)
        Lbl1Loc = 0
        Lbl2Loc = -200
    End Sub
End Class