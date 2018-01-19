Imports System.ComponentModel

Public Class Form1
    Dim result As New List(Of String)
    Dim count As Integer = 0
    Dim offset As Integer = 0
    Dim likes As Integer = 0
    Dim ticker As Integer = 0
    Dim current(1) As String
    Dim logged_in As Boolean
    Private Sub LikesBtn_Click(sender As Object, e As EventArgs) Handles LikesBtn.Click
        Dim worker As New VkWorker
        DrawBtn.Enabled = False
        LikesBtn.Enabled = False
        CommentsBtn.Enabled = False
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
        Dim list As List(Of VK_Randomizer.Name_Result)
        list = worker.GetRepostsSmart(AddressTxt.Text, "copies", offset) 'TEST TEST TEST DO NOT LEAVE HERE
        Do While likes - offset >= 0
            'list = worker.GetUsersLiked(AddressTxt.Text, "copies", offset)
            list = worker.GetRepostsSmart(AddressTxt.Text, "copies", offset)
            For Each f As Name_Result In list
                Dim part As String = f.uid & ", " & f.first_name & " " & f.last_name
                result.Add(part)
                count += 1
            Next
            ListGetter.ReportProgress((Math.Truncate(count / likes)) * 100)
            offset += 100
        Loop
    End Sub

    Private Sub ListGetter_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ListGetter.ProgressChanged
        '  ConsoleLbl.Text = count & " / " & likes
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
        LikesBtn.Enabled = True
        CommentsBtn.Enabled = True
    End Sub

    Private Sub ShowScreenBtn_Click(sender As Object, e As EventArgs) Handles ShowScreenBtn.Click
        Screen.Show()
    End Sub

    Private Sub DrawBtn_Click(sender As Object, e As EventArgs) Handles DrawBtn.Click
        ConsoleLbl.Text = "Fetching random number..."
        Try
            Dim webClient As New System.Net.WebClient
            Dim random As Double
            random = webClient.DownloadString("https://www.random.org/integers/?num=1&min=1&max=1000000000&col=1&base=10&format=plain&rnd=new")
            Randomize(random)
            ConsoleLbl.Text = "Drawing..."
        Catch ex As Exception
            ConsoleLbl.Text = "Cannot fetch seed: " & ex.Message & " Using pseudo-RNG..."
            Randomize()
        End Try
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
        LoginChecker()
        ' IntegrityCheck()
    End Sub

    Private Sub AboutBtn_Click(sender As Object, e As EventArgs) Handles AboutBtn.Click
        AboutMe.Show()
    End Sub

    Private Sub IntegrityCheck()
        Dim a As Boolean
        Dim worker As New VkWorker
        Dim webClient As New System.Net.WebClient
        Try
            Dim result As String = webClient.DownloadString("http://continue.su/vkrandom.chksum")
            a = worker.ChecksumCheck(Application.ExecutablePath, result)
            If a Then
                TrustLbl.ForeColor = Color.Green
                TrustLbl.Text = "Trusted version"
            Else
                TrustLbl.ForeColor = Color.Red
                TrustLbl.Text = "Untrusted version, may be forged"
            End If
        Catch ex As Exception
            TrustLbl.Text = "Cannot check the integrity of software: " & ex.Message
        End Try
    End Sub

    Public Sub LoginChecker()
        Dim worker As New VkWorker
        Dim CheckLogin As Profile_Items = worker.CheckLogin()
        Try
            VkStatusLbl.Text = "Logged in as " & CheckLogin.first_name & " " & CheckLogin.last_name
            VKLoginBtn.Text = "Log out"
            logged_in = True
        Catch ex As Exception
            VkStatusLbl.Text = "Log in to use this app"
            logged_in = False
            VKLoginBtn.Text = "Log in..."
        End Try
    End Sub

    Private Sub SaveListBtn_Click(sender As Object, e As EventArgs) Handles SaveListBtn.Click
        Dim file As New SaveFileDialog With {
            .Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }

        If file.ShowDialog() = DialogResult.OK Then
            Dim writer As System.IO.StreamWriter
            writer = My.Computer.FileSystem.OpenTextFileWriter(file.FileName, True)
            '           writer.WriteLine("id, Name")
            For Each f As String In ListTxt.Lines()
                writer.WriteLine(f)

            Next
            writer.Close()
        End If
    End Sub

    Private Sub CommentsBtn_Click(sender As Object, e As EventArgs) Handles CommentsBtn.Click
        Dim worker As New VkWorker
        DrawBtn.Enabled = False
        LikesBtn.Enabled = False
        CommentsBtn.Enabled = False
        ProgressBar1.Value = 100
        ProgressBar1.Style = ProgressBarStyle.Marquee
        result.Add("Empty")
        result.Clear()
        count = 0
        offset = 0
        ListTxt.Text = ""
        likes = worker.GetCommentsCount(AddressTxt.Text, offset)
        ConsoleLbl.Text = "Getting " & likes & " comments..."
        CommentsGetter.RunWorkerAsync()
    End Sub

    Private Sub CommentsGetter_DoWork(sender As Object, e As DoWorkEventArgs) Handles CommentsGetter.DoWork
        Dim worker As New VkWorker
        Dim list As List(Of Comments_Items)

        Do While likes - offset >= 0

            list = worker.GetComments(AddressTxt.Text, offset)
            'list = worker.GetUsersLiked(AddressTxt.Text, "copies", offset)
            For Each f As Comments_Items In list
                If MembershipChk.Checked = True Then
                    Dim isMember As String = worker.CheckMembership(f.from_id, "msi_russia") ' DONT FORGET TO REPLACE
                    Dim part As String = f.cid & vbTab & f.from_id & vbTab & f.text & vbTab & isMember
                    result.Add(part)
                    count += 1
                    UpdateTextBox(count & " / " & likes)
                    Threading.Thread.Sleep(400)
                Else
                    Dim part As String = f.cid & vbTab & f.from_id & vbTab & f.text & vbTab
                    result.Add(part)
                    count += 1
                End If
            Next
            ListGetter.ReportProgress((Math.Truncate(count / likes)) * 100)
            offset += 100
            list.Clear()
        Loop
    End Sub

    Private Sub UpdateTextBox(ByVal e As String)
        If Me.InvokeRequired Then
            Dim args() As String = {e}
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), args)
            Return
        End If
        ConsoleLbl.Text = e
    End Sub

    Private Sub CommentsGetter_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CommentsGetter.ProgressChanged
        ConsoleLbl.Text = count & " / " & likes
    End Sub

    Private Sub CommentsGetter_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CommentsGetter.RunWorkerCompleted
        ListTxt.Text = ""
        For Each id In result
            ListTxt.AppendText(id & vbCrLf)
        Next
        ProgressBar1.Value = 0
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ConsoleLbl.Text = "OK," & count & " entires of " & likes & "comments."
        DrawBtn.Enabled = True
        LikesBtn.Enabled = True
        CommentsBtn.Enabled = True
    End Sub

    Private Sub VKLoginBtn_Click(sender As Object, e As EventArgs) Handles VKLoginBtn.Click
        If logged_in = True Then
            My.Settings.VKToken = 0
            My.Settings.MyID = 0
            VkStatusLbl.Text = "Log in to use this app"
            logged_in = False
            VKLoginBtn.Text = "Log in..."
        Else
            VKLoginForm.Show()
        End If
    End Sub
End Class
