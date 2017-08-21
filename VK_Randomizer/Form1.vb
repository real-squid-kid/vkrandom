Imports System.ComponentModel

Public Class Form1
    Dim result As New List(Of String)
    Dim count As Integer = 0
    Dim offset As Integer = 0
    Dim likes As Integer = 0
    Dim ticker As Integer = 0
    Dim current(1) As String
    Private Sub LikesBtn_Click(sender As Object, e As EventArgs) Handles LikesBtn.Click
        Dim worker As New VkWorker
        DrawBtn.Enabled = False
        ProgressBar1.Value = 100
        ProgressBar1.Style = ProgressBarStyle.Marquee
        result.Add("Empty")
        result.Clear()
        count = 0
        offset = 0
        ListTxt.Text = ""
        ConsoleLbl.Text = "Getting likes and reposts count..."
        likes = worker.GetLikes(AddressTxt.Text, "copies")
        ConsoleLbl.Text = worker.GetLikes(AddressTxt.Text, "copies") & " reposts, getting list of reposted..."
        ListGetter.RunWorkerAsync()
    End Sub

    Private Sub ListGetter_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ListGetter.DoWork
        Dim worker As New VkWorker
        Dim list() As Integer
        Do While likes - offset >= 0
            list = worker.GetUsersLiked(AddressTxt.Text, "copies", offset)
            For Each uid In list
                Dim part As String = uid & "," & worker.GetName(uid)
                result.Add(part)
                count += 1
            Next
            ListGetter.ReportProgress((Math.Truncate(count / likes)) * 100)
            offset += 100
        Loop
    End Sub

    Private Sub ListGetter_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ListGetter.ProgressChanged
        ConsoleLbl.Text = count & " / " & likes
    End Sub

    Private Sub ListGetter_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles ListGetter.RunWorkerCompleted
        ListTxt.Text = ""
        For Each id In result
            ListTxt.AppendText(id & vbCrLf)
        Next
        ProgressBar1.Value = 0
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ConsoleLbl.Text = "OK," & count & " entires of " & likes & "reposts."
        DrawBtn.Enabled = True
    End Sub

    Private Sub ShowScreenBtn_Click(sender As Object, e As EventArgs) Handles ShowScreenBtn.Click
        Screen.Show()
    End Sub

    Private Sub DrawBtn_Click(sender As Object, e As EventArgs) Handles DrawBtn.Click
        ConsoleLbl.Text = "Fetching random number..."
        Dim webClient As New System.Net.WebClient
        Dim random As Double
        random = webClient.DownloadString("https://www.random.org/integers/?num=1&min=1&max=1000000000&col=1&base=10&format=plain&rnd=new")
        Randomize(random)
        ConsoleLbl.Text = "Drawing..."
        ticker = 0
        With Screen
            .Label1.ForeColor = Color.Gray
            .Label2.ForeColor = Color.Gray
            .LowTime = False
            .InitialSpeed = SpeedTxt.Text
            .TimeLeft = TimeTxt.Text
            .Scroller.Enabled = True
        End With
        My.Computer.Audio.Play(My.Resources.m10_cursor, AudioPlayMode.Background)
    End Sub

    Function Request()
        Dim temp As String = result(Int(Rnd() * result.Count))
        Dim chosen() As String = Strings.Split(temp, ",")
        ' ConsoleLbl.Text = chosen(1)
        ' Screen.Label1.Text = chosen(1)
        ' ticker += 1
        ' If ticker = 64 Then
        ' AddressTxt.Text = "https://vk.com/id" & chosen(0)
        ' RollerChange.Enabled = False
        ' Screen.Label1.ForeColor = Color.LightGreen
        '  End If
        Return chosen
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As Boolean
        Dim worker As New VkWorker
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("http://continue.su/vkrandom.chksum")
        a = worker.ChecksumCheck(Application.ExecutablePath, result)
        If a Then
            TrustLbl.ForeColor = Color.Green
            TrustLbl.Text = "Trusted version"
        Else
            TrustLbl.ForeColor = Color.Red
            TrustLbl.Text = "Untrusted version, may be forged"
        End If
    End Sub

    Private Sub AboutBtn_Click(sender As Object, e As EventArgs) Handles AboutBtn.Click
        AboutMe.Show()
    End Sub
End Class
