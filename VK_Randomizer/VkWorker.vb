Public Class VkWorker
    Public Function GetLikes(e As String)
        Dim temp As String
        Dim parts(1) As String
        ' Gets a string like https://vk.com/wall-29534144_6837921
        ' Uses like this: https://api.vk.com/method/likes.getList?type=post&owner_id=-51016572&item_id=839965&filter=likes&offset=1
        temp = Mid(e, 18)
        parts = Split(temp, "_")
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("https://api.vk.com/method/likes.getList?type=post&owner_id=" & parts(0) & "&item_id=" & parts(1) & "&filter=likes&offset=1")

    End Function
End Class
