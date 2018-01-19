Public Class VKLoginForm
    Private Sub VKLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=6336667&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.52")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim symb() As Char = {"=", "&"}
        Dim url() As String = WebBrowser1.Url.ToString.Split(symb)
        If url(0) = "https://oauth.vk.com/blank.html#access_token" Then
            My.Settings.VKToken = url(1)
            My.Settings.MyID = url(5)
            Threading.Thread.Sleep(500)
            Me.Close()
        End If
    End Sub

    Private Sub VKLoginForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.LoginChecker()
    End Sub
End Class