<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddressTxt = New System.Windows.Forms.TextBox()
        Me.LikesBtn = New System.Windows.Forms.Button()
        Me.ListTxt = New System.Windows.Forms.TextBox()
        Me.ConsoleLbl = New System.Windows.Forms.Label()
        Me.ListGetter = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.RollerChange = New System.Windows.Forms.Timer(Me.components)
        Me.DrawBtn = New System.Windows.Forms.Button()
        Me.ShowScreenBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimeTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SpeedTxt = New System.Windows.Forms.TextBox()
        Me.TrustLbl = New System.Windows.Forms.Label()
        Me.AboutBtn = New System.Windows.Forms.Button()
        Me.SaveListBtn = New System.Windows.Forms.Button()
        Me.CommentsBtn = New System.Windows.Forms.Button()
        Me.CommentsGetter = New System.ComponentModel.BackgroundWorker()
        Me.VkStatusLbl = New System.Windows.Forms.Label()
        Me.VKLoginBtn = New System.Windows.Forms.Button()
        Me.MembershipChk = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Address:"
        '
        'AddressTxt
        '
        Me.AddressTxt.Location = New System.Drawing.Point(67, 10)
        Me.AddressTxt.Name = "AddressTxt"
        Me.AddressTxt.Size = New System.Drawing.Size(242, 20)
        Me.AddressTxt.TabIndex = 1
        '
        'LikesBtn
        '
        Me.LikesBtn.Location = New System.Drawing.Point(16, 36)
        Me.LikesBtn.Name = "LikesBtn"
        Me.LikesBtn.Size = New System.Drawing.Size(80, 23)
        Me.LikesBtn.TabIndex = 2
        Me.LikesBtn.Text = "Get Reposts"
        Me.LikesBtn.UseVisualStyleBackColor = True
        '
        'ListTxt
        '
        Me.ListTxt.Location = New System.Drawing.Point(16, 78)
        Me.ListTxt.Multiline = True
        Me.ListTxt.Name = "ListTxt"
        Me.ListTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ListTxt.Size = New System.Drawing.Size(293, 279)
        Me.ListTxt.TabIndex = 3
        '
        'ConsoleLbl
        '
        Me.ConsoleLbl.AutoSize = True
        Me.ConsoleLbl.Location = New System.Drawing.Point(15, 62)
        Me.ConsoleLbl.Name = "ConsoleLbl"
        Me.ConsoleLbl.Size = New System.Drawing.Size(41, 13)
        Me.ConsoleLbl.TabIndex = 4
        Me.ConsoleLbl.Text = "Ready."
        '
        'ListGetter
        '
        Me.ListGetter.WorkerReportsProgress = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Red
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 363)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(293, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'DrawBtn
        '
        Me.DrawBtn.Enabled = False
        Me.DrawBtn.Location = New System.Drawing.Point(16, 392)
        Me.DrawBtn.Name = "DrawBtn"
        Me.DrawBtn.Size = New System.Drawing.Size(122, 23)
        Me.DrawBtn.TabIndex = 6
        Me.DrawBtn.Text = "D R A W"
        Me.DrawBtn.UseVisualStyleBackColor = True
        '
        'ShowScreenBtn
        '
        Me.ShowScreenBtn.Location = New System.Drawing.Point(225, 392)
        Me.ShowScreenBtn.Name = "ShowScreenBtn"
        Me.ShowScreenBtn.Size = New System.Drawing.Size(83, 23)
        Me.ShowScreenBtn.TabIndex = 7
        Me.ShowScreenBtn.Text = "Show Screen"
        Me.ShowScreenBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Time:"
        '
        'TimeTxt
        '
        Me.TimeTxt.Location = New System.Drawing.Point(218, 421)
        Me.TimeTxt.Name = "TimeTxt"
        Me.TimeTxt.Size = New System.Drawing.Size(91, 20)
        Me.TimeTxt.TabIndex = 9
        Me.TimeTxt.Text = "5,8"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 450)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Speed:"
        '
        'SpeedTxt
        '
        Me.SpeedTxt.Location = New System.Drawing.Point(218, 447)
        Me.SpeedTxt.Name = "SpeedTxt"
        Me.SpeedTxt.Size = New System.Drawing.Size(91, 20)
        Me.SpeedTxt.TabIndex = 9
        Me.SpeedTxt.Text = "75"
        '
        'TrustLbl
        '
        Me.TrustLbl.AutoSize = True
        Me.TrustLbl.Location = New System.Drawing.Point(15, 482)
        Me.TrustLbl.Name = "TrustLbl"
        Me.TrustLbl.Size = New System.Drawing.Size(39, 13)
        Me.TrustLbl.TabIndex = 10
        Me.TrustLbl.Text = "Label4"
        '
        'AboutBtn
        '
        Me.AboutBtn.Location = New System.Drawing.Point(234, 474)
        Me.AboutBtn.Name = "AboutBtn"
        Me.AboutBtn.Size = New System.Drawing.Size(75, 23)
        Me.AboutBtn.TabIndex = 11
        Me.AboutBtn.Text = "About..."
        Me.AboutBtn.UseVisualStyleBackColor = True
        '
        'SaveListBtn
        '
        Me.SaveListBtn.Location = New System.Drawing.Point(144, 392)
        Me.SaveListBtn.Name = "SaveListBtn"
        Me.SaveListBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveListBtn.TabIndex = 12
        Me.SaveListBtn.Text = "Save list..."
        Me.SaveListBtn.UseVisualStyleBackColor = True
        '
        'CommentsBtn
        '
        Me.CommentsBtn.Location = New System.Drawing.Point(102, 36)
        Me.CommentsBtn.Name = "CommentsBtn"
        Me.CommentsBtn.Size = New System.Drawing.Size(89, 23)
        Me.CommentsBtn.TabIndex = 2
        Me.CommentsBtn.Text = "Get Comments"
        Me.CommentsBtn.UseVisualStyleBackColor = True
        '
        'CommentsGetter
        '
        '
        'VkStatusLbl
        '
        Me.VkStatusLbl.AutoSize = True
        Me.VkStatusLbl.Location = New System.Drawing.Point(15, 543)
        Me.VkStatusLbl.Name = "VkStatusLbl"
        Me.VkStatusLbl.Size = New System.Drawing.Size(51, 13)
        Me.VkStatusLbl.TabIndex = 13
        Me.VkStatusLbl.Text = "VKStatus"
        '
        'VKLoginBtn
        '
        Me.VKLoginBtn.Location = New System.Drawing.Point(234, 538)
        Me.VKLoginBtn.Name = "VKLoginBtn"
        Me.VKLoginBtn.Size = New System.Drawing.Size(75, 23)
        Me.VKLoginBtn.TabIndex = 14
        Me.VKLoginBtn.Text = "Log in..."
        Me.VKLoginBtn.UseVisualStyleBackColor = True
        '
        'MembershipChk
        '
        Me.MembershipChk.AutoSize = True
        Me.MembershipChk.Location = New System.Drawing.Point(197, 40)
        Me.MembershipChk.Name = "MembershipChk"
        Me.MembershipChk.Size = New System.Drawing.Size(116, 17)
        Me.MembershipChk.TabIndex = 15
        Me.MembershipChk.Text = "Check membership"
        Me.MembershipChk.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 573)
        Me.Controls.Add(Me.MembershipChk)
        Me.Controls.Add(Me.VKLoginBtn)
        Me.Controls.Add(Me.VkStatusLbl)
        Me.Controls.Add(Me.SaveListBtn)
        Me.Controls.Add(Me.AboutBtn)
        Me.Controls.Add(Me.TrustLbl)
        Me.Controls.Add(Me.SpeedTxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TimeTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ShowScreenBtn)
        Me.Controls.Add(Me.DrawBtn)
        Me.Controls.Add(Me.ConsoleLbl)
        Me.Controls.Add(Me.ListTxt)
        Me.Controls.Add(Me.CommentsBtn)
        Me.Controls.Add(Me.LikesBtn)
        Me.Controls.Add(Me.AddressTxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents AddressTxt As TextBox
    Friend WithEvents LikesBtn As Button
    Friend WithEvents ListTxt As TextBox
    Friend WithEvents ConsoleLbl As Label
    Friend WithEvents ListGetter As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents RollerChange As Timer
    Friend WithEvents DrawBtn As Button
    Friend WithEvents ShowScreenBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TimeTxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SpeedTxt As TextBox
    Friend WithEvents TrustLbl As Label
    Friend WithEvents AboutBtn As Button
    Friend WithEvents SaveListBtn As Button
    Friend WithEvents CommentsBtn As Button
    Friend WithEvents CommentsGetter As System.ComponentModel.BackgroundWorker
    Friend WithEvents VkStatusLbl As Label
    Friend WithEvents VKLoginBtn As Button
    Friend WithEvents MembershipChk As CheckBox
End Class
