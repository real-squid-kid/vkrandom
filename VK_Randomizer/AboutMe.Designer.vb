<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutMe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OwnChkSum = New System.Windows.Forms.TextBox()
        Me.ServerChkSum = New System.Windows.Forms.TextBox()
        Me.StatementLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(357, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VK Contest tools version 0.2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(254, 52)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Developed by @real_squid_kid" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distributed under GNU GPL 3 license." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Checksum sour" &
    "ce at continue.su/vkrandom.chksum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fork me at GitHub!"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "This copy's checksum:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Original checksum:"
        '
        'OwnChkSum
        '
        Me.OwnChkSum.Location = New System.Drawing.Point(136, 110)
        Me.OwnChkSum.Name = "OwnChkSum"
        Me.OwnChkSum.ReadOnly = True
        Me.OwnChkSum.Size = New System.Drawing.Size(262, 20)
        Me.OwnChkSum.TabIndex = 3
        '
        'ServerChkSum
        '
        Me.ServerChkSum.Location = New System.Drawing.Point(136, 136)
        Me.ServerChkSum.Name = "ServerChkSum"
        Me.ServerChkSum.ReadOnly = True
        Me.ServerChkSum.Size = New System.Drawing.Size(262, 20)
        Me.ServerChkSum.TabIndex = 3
        '
        'StatementLbl
        '
        Me.StatementLbl.Location = New System.Drawing.Point(15, 170)
        Me.StatementLbl.Name = "StatementLbl"
        Me.StatementLbl.Size = New System.Drawing.Size(383, 44)
        Me.StatementLbl.TabIndex = 4
        Me.StatementLbl.Text = "Label5"
        '
        'AboutMe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 228)
        Me.Controls.Add(Me.StatementLbl)
        Me.Controls.Add(Me.ServerChkSum)
        Me.Controls.Add(Me.OwnChkSum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AboutMe"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "About Me"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents OwnChkSum As TextBox
    Friend WithEvents ServerChkSum As TextBox
    Friend WithEvents StatementLbl As Label
End Class
