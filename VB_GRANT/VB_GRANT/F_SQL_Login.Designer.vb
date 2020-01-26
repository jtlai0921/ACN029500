<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_SQL_Login
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.B_Login = New System.Windows.Forms.Button()
        Me.B_Exit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.T_PASSW = New System.Windows.Forms.TextBox()
        Me.T_ID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.B_Save = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_Password = New System.Windows.Forms.TextBox()
        Me.T_User = New System.Windows.Forms.TextBox()
        Me.T_DataBase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_ServerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'B_Login
        '
        Me.B_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_Login.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Login.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Login.ForeColor = System.Drawing.Color.White
        Me.B_Login.Location = New System.Drawing.Point(261, 183)
        Me.B_Login.Name = "B_Login"
        Me.B_Login.Size = New System.Drawing.Size(102, 38)
        Me.B_Login.TabIndex = 2
        Me.B_Login.Text = "Login"
        Me.B_Login.UseVisualStyleBackColor = False
        '
        'B_Exit
        '
        Me.B_Exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_Exit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Exit.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Exit.ForeColor = System.Drawing.Color.White
        Me.B_Exit.Location = New System.Drawing.Point(158, 183)
        Me.B_Exit.Name = "B_Exit"
        Me.B_Exit.Size = New System.Drawing.Size(102, 38)
        Me.B_Exit.TabIndex = 3
        Me.B_Exit.Text = "Exit"
        Me.B_Exit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(160, 36)
        Me.TabControl1.Location = New System.Drawing.Point(10, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(530, 300)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.T_PASSW)
        Me.TabPage1.Controls.Add(Me.B_Login)
        Me.TabPage1.Controls.Add(Me.T_ID)
        Me.TabPage1.Controls.Add(Me.B_Exit)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(522, 256)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "登入VB 應用系統"
        Me.ToolTip1.SetToolTip(Me.TabPage1, "帳號 A0001 的預設密碼為 a-12345，其他帳號的預設密碼為 abc123")
        '
        'T_PASSW
        '
        Me.T_PASSW.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_PASSW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.T_PASSW.Location = New System.Drawing.Point(156, 107)
        Me.T_PASSW.MaxLength = 10
        Me.T_PASSW.Name = "T_PASSW"
        Me.T_PASSW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.T_PASSW.Size = New System.Drawing.Size(208, 33)
        Me.T_PASSW.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.T_PASSW, "帳號 A0001 的預設密碼為 a-12345")
        '
        'T_ID
        '
        Me.T_ID.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.T_ID.Location = New System.Drawing.Point(156, 66)
        Me.T_ID.MaxLength = 14
        Me.T_ID.Name = "T_ID"
        Me.T_ID.Size = New System.Drawing.Size(160, 33)
        Me.T_ID.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.T_ID, "系統管理員之範例帳號 A0001")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(112, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "密碼"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(112, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "帳號"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.B_Save)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.T_Password)
        Me.TabPage2.Controls.Add(Me.T_User)
        Me.TabPage2.Controls.Add(Me.T_DataBase)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.T_ServerName)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(522, 256)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SQL Server 登入資訊"
        '
        'B_Save
        '
        Me.B_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.B_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Save.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Save.ForeColor = System.Drawing.Color.White
        Me.B_Save.Location = New System.Drawing.Point(208, 205)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(102, 38)
        Me.B_Save.TabIndex = 4
        Me.B_Save.Text = "Save"
        Me.B_Save.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Teal
        Me.Label5.Location = New System.Drawing.Point(113, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(254, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "SQL Server 登入資訊修改後，請敲 Save 鈕"
        '
        'T_Password
        '
        Me.T_Password.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Password.Location = New System.Drawing.Point(116, 160)
        Me.T_Password.MaxLength = 60
        Me.T_Password.Name = "T_Password"
        Me.T_Password.Size = New System.Drawing.Size(201, 29)
        Me.T_Password.TabIndex = 3
        '
        'T_User
        '
        Me.T_User.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_User.Location = New System.Drawing.Point(116, 126)
        Me.T_User.MaxLength = 60
        Me.T_User.Name = "T_User"
        Me.T_User.Size = New System.Drawing.Size(154, 29)
        Me.T_User.TabIndex = 2
        '
        'T_DataBase
        '
        Me.T_DataBase.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DataBase.Location = New System.Drawing.Point(116, 92)
        Me.T_DataBase.MaxLength = 60
        Me.T_DataBase.Name = "T_DataBase"
        Me.T_DataBase.Size = New System.Drawing.Size(241, 29)
        Me.T_DataBase.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(73, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "密碼"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(57, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "使用者"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(25, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "資料庫名稱"
        '
        'T_ServerName
        '
        Me.T_ServerName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ServerName.Location = New System.Drawing.Point(116, 58)
        Me.T_ServerName.MaxLength = 60
        Me.T_ServerName.Name = "T_ServerName"
        Me.T_ServerName.Size = New System.Drawing.Size(287, 29)
        Me.T_ServerName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(25, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "伺服器名稱"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.ForeColor = System.Drawing.Color.Red
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 20
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(322, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "A0001"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(370, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 18)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "a-12345"
        '
        'F_SQL_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(550, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_SQL_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents B_Login As System.Windows.Forms.Button
    Friend WithEvents B_Exit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents T_PASSW As System.Windows.Forms.TextBox
    Friend WithEvents T_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_Password As System.Windows.Forms.TextBox
    Friend WithEvents T_User As System.Windows.Forms.TextBox
    Friend WithEvents T_DataBase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
