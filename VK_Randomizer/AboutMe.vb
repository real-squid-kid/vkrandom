Public Class AboutMe
    Private Sub AboutMe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim webClient As New System.Net.WebClient
            ServerChkSum.Text = webClient.DownloadString("http://continue.su/vkrandom.chksum")
            Dim worker As New VkWorker
            OwnChkSum.Text = worker.ChecksumReturn(Application.ExecutablePath)
            If OwnChkSum.Text = ServerChkSum.Text Then
                StatementLbl.Text = "This is a trusted version from GitHub or other source. RNG is unforged and using RANDOM.ORG seed"
            Else
                StatementLbl.Text = "Checksums mismatch. RNG could be forged."
            End If
        Catch ex As Exception
            StatementLbl.Text = "Error while getting checksum. " & ex.Message & " RNG could be forged."
        End Try

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim webAddress As String = "https://github.com/real-squid-kid/vkrandom"
        Process.Start(webAddress)
    End Sub
End Class