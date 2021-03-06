﻿Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class VkWorker
    Public Function GetLikes(e As String, f As String)
        Dim temp As String
        Dim parts(1) As String
        ' Gets a string like https://vk.com/wall-29534144_6837921
        ' Uses like this: https://api.vk.com/method/likes.getList?type=post&owner_id=-51016572&item_id=839965&filter=likes&offset=1
        temp = Mid(e, 20)
        parts = Split(temp, "_")
        Dim webClient As New System.Net.WebClient
        Try
            Dim result As String = webClient.DownloadString("https://api.vk.com/method/likes.getList?type=post&owner_id=" & parts(0) & "&item_id=" & parts(1) & "&filter=" & f & "&offset=0")
            Dim parsed_result As Likes_Container
            parsed_result = JsonConvert.DeserializeObject(Of Likes_Container)(result)
            Return parsed_result.response.count
        Catch ex As Exception
            MessageBox.Show("Strange behaviour of VK Server while getting reposts: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function GetUsersLiked(e As String, f As String, g As Integer)
        Dim temp As String
        Dim parts(1) As String
        ' Gets a string like https://vk.com/wall-29534144_6837921
        ' Uses like this: https://api.vk.com/method/likes.getList?type=post&owner_id=-51016572&item_id=839965&filter=likes&offset=1
        temp = Mid(e, 20)
        parts = Split(temp, "_")
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Try
            Dim result As String = webClient.DownloadString("https://api.vk.com/method/likes.getList?type=post&owner_id=" & parts(0) & "&item_id=" & parts(1) & "&filter=" & f & "&offset=" & g)
            Dim parsed_result As Likes_Container
            parsed_result = JsonConvert.DeserializeObject(Of Likes_Container)(result)
            Return parsed_result.response.users
        Catch ex As Exception
            MessageBox.Show("Strange behaviour of VK Server while getting user IDs: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function GetComments(url As String, offset As Integer)
        ' Usage: https://api.vk.com/method/wall.getComments?owner_id=-11664745&post_id=163355&sort=asc&count=100&version=5.33&offset=0
        Dim temp As String
        Dim parts(1) As String
        temp = Mid(url, 20)
        parts = Split(temp, "_")
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Dim gather As String = webClient.DownloadString("https://api.vk.com/method/wall.getComments?owner_id=" & parts(0) & "&post_id=" & parts(1) & "&sort=asc&count=100&version=5.33&offset=" & offset)
        Dim rawinfo As List(Of String) = gather.Split(",").ToList
        rawinfo.RemoveAt(0)
        Dim nom As String = "[" & String.Join(",", rawinfo.ToArray)
        nom = nom.Substring(0, nom.Length - 1)
        Dim reposts = JsonConvert.DeserializeObject(Of List(Of Comments_Items))(nom)
        Debug.WriteLine(gather)
        Return reposts
    End Function

    Public Function GetCommentsCount(url As String, offset As Integer)
        ' Usage: https://api.vk.com/method/wall.getComments?owner_id=-11664745&post_id=163355&sort=asc&count=100&version=5.33&offset=0
        Dim temp As String
        Dim parts(1) As String
        temp = Mid(url, 20)
        parts = Split(temp, "_")
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Dim gather As String = webClient.DownloadString("https://api.vk.com/method/wall.getComments?owner_id=" & parts(0) & "&post_id=" & parts(1) & "&sort=asc&count=100&version=5.33&offset=" & offset)
        Dim rawinfo As List(Of String) = gather.Split(",").ToList
        Dim number() As String = rawinfo(0).Split("[")
        Dim done As Integer
        done = Int(number(1))
        Return done
    End Function

    Public Function GetRepostsSmart(url As String, filter As String, offset As String)
        ' https://api.vk.com/method/likes.getList?type=post&owner_id=-51016572&item_id=839965&filter=likes&offset=1&extended=true
        Dim temp As String
        Dim parts(1) As String
        temp = Mid(url, 20)
        parts = Split(temp, "_")
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Dim gather As String = webClient.DownloadString("https://api.vk.com/method/likes.getList?type=post&owner_id=" & parts(0) & "&item_id=" & parts(1) & "&filter=" & filter & "&offset=" & offset & "&extended=true")
        Dim reposts = JsonConvert.DeserializeObject(Of Reposts_Container)(gather)
        Return reposts.response.items
    End Function

    Public Function GetName(e As String)
        'Gets an uid, like 209526225
        'Uses like this: https://api.vk.com/method/users.get?user_ids=209526225,1500515&name_case=Nom
        If e < 1 Then
            Return "Community"
            Exit Function
        End If
        Dim ret As String
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Try
            Dim result As String = webClient.DownloadString("https://api.vk.com/method/users.get?user_ids=" & e & "&name_case=Nom")
            Dim parsed_result As Name_Container
            parsed_result = JsonConvert.DeserializeObject(Of Name_Container)(result)
            ret = parsed_result.response(0).first_name & " " & parsed_result.response(0).last_name
            Return ret
        Catch ex As Exception
            MessageBox.Show("Strange behaviour of VK Server while getting names: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CheckMembership(uid As Integer, group As String)
        'https://api.vk.com/method/groups.isMember?group_id=msi_russia&user_id=209526225&access_token=00000000000
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Dim gather As String = webClient.DownloadString("https://api.vk.com/method/groups.isMember?group_id=" & group & "&user_id=" & uid & "&access_token=" & My.Settings.VKToken)
        ' Dim parsed As Membership_Container = JsonConvert.DeserializeObject(Of Membership_Container)(gather)
        '  Return parsed.response
        Return gather
    End Function

    Public Function CheckLogin()
        'https://api.vk.com/method/account.getProfileInfo?access_token=00000000000
        Dim webClient As New Net.WebClient With {
            .Encoding = Text.Encoding.GetEncoding("UTF-8")
        }
        Dim gather As String = webClient.DownloadString("https://api.vk.com/method/account.getProfileInfo?access_token=" & My.Settings.VKToken)
        Try
            Dim parsed As Profile_Container = JsonConvert.DeserializeObject(Of Profile_Container)(gather)
            Dim result = parsed.response
            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ChecksumCheck(e As String, sum As String)

        Dim md5code As String

        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim f As FileStream = New FileStream(e, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        ' f = New FileStream((Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        md5.ComputeHash(f)
        ' Dim ObjFSO As Object = CreateObject("Scripting.FileSystemObject")
        '  Dim objFile = ObjFSO.GetFile(OpenFileDialog1.FileName)

        Dim hash As Byte() = md5.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte
        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        md5code = buff.ToString()

        If md5code = sum Then
            'if true
            Return True
        Else
            Return False
        End If
    End Function
    Function ChecksumReturn(e As String)

        Dim md5code As String

        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim f As FileStream = New FileStream(e, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        ' f = New FileStream((Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        md5.ComputeHash(f)
        ' Dim ObjFSO As Object = CreateObject("Scripting.FileSystemObject")
        '  Dim objFile = ObjFSO.GetFile(OpenFileDialog1.FileName)

        Dim hash As Byte() = md5.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte
        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        md5code = buff.ToString()

        Return md5code
    End Function
End Class

Public Class Likes_Result
    ' Public response As String
    Public count As Integer
    Public users() As Integer
End Class

Public Class Likes_Container
    Public response As Likes_Result
End Class

Public Class Name_Container
    Public response() As Name_Result
End Class

Public Class Reposts_Container
    Public response As Reposts_Items
End Class

Public Class Comments_Container
    Public stuff As Comments_Items
End Class

Public Class Profile_Container
    Public response As Profile_Items
End Class

Public Class Profile_Items
    Public Property first_name() As String
    Public Property last_name() As String
End Class

Public Class Comments_Items
    Public Property cid() As String
    Public Property from_id() As String
    Public Property text() As String
End Class

Public Class Reposts_Items
    Public Property count As Integer
    Public Property items() As List(Of Name_Result)
End Class

Public Class Membership_Container
    Public response As String
End Class


Public Class Name_Result
    Public uid As Integer
    Public first_name As String
    Public last_name As String
End Class