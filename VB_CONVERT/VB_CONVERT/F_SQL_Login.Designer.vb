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
        Me.T_Password = New System.Windows.Forms.TextBox()
        Me.T_User = New System.Windows.Forms.TextBox()
        Me.T_DataBase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_ServerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.B_Save = New System.Windows.Forms.Button()
        Me.B_GO = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'T_Password
        '
        Me.T_Password.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Password.Location = New System.Drawing.Point(200, 175)
        Me.T_Password.MaxLength = 60
        Me.T_Password.Name = "T_Password"
        Me.T_Password.Size = New System.Drawing.Size(201, 29)
        Me.T_Password.TabIndex = 43
        '
        'T_User
        '
        Me.T_User.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_User.Location = New System.Drawing.Point(200, 141)
        Me.T_User.MaxLength = 60
        Me.T_User.Name = "T_User"
        Me.T_User.Size = New System.Drawing.Size(154, 29)
        Me.T_User.TabIndex = 42
        '
        'T_DataBase
        '
        Me.T_DataBase.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DataBase.Location = New System.Drawing.Point(200, 107)
        Me.T_DataBase.MaxLength = 60
        Me.T_DataBase.Name = "T_DataBase"
        Me.T_DataBase.Size = New System.Drawing.Size(241, 29)
        Me.T_DataBase.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(156, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "密碼"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(140, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "使用者"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(108, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "資料庫名稱"
        '
        'T_ServerName
        '
        Me.T_ServerName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ServerName.Location = New System.Drawing.Point(200, 73)
        Me.T_ServerName.MaxLength = 60
        Me.T_ServerName.Name = "T_ServerName"
        Me.T_ServerName.Size = New System.Drawing.Size(287, 29)
        Me.T_ServerName.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(108, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "伺服器名稱"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Teal
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(274, 20)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "請確認或修改 SQL Server 的登入資訊"
        '
        'B_Save
        '
        Me.B_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.B_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Save.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Save.ForeColor = System.Drawing.Color.White
        Me.B_Save.Location = New System.Drawing.Point(302, 267)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(102, 36)
        Me.B_Save.TabIndex = 141
        Me.B_Save.Text = "儲 存"
        Me.B_Save.UseVisualStyleBackColor = False
        '
        'B_GO
        '
        Me.B_GO.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.B_GO.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GO.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_GO.ForeColor = System.Drawing.Color.White
        Me.B_GO.Location = New System.Drawing.Point(191, 267)
        Me.B_GO.Name = "B_GO"
        Me.B_GO.Size = New System.Drawing.Size(102, 36)
        Me.B_GO.TabIndex = 142
        Me.B_GO.Text = "繼 續"
        Me.B_GO.UseVisualStyleBackColor = False
        '
        'F_SQL_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_GO)
        Me.Controls.Add(Me.B_Save)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_Password)
        Me.Controls.Add(Me.T_User)
        Me.Controls.Add(Me.T_DataBase)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_ServerName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_SQL_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_Password As System.Windows.Forms.TextBox
    Friend WithEvents T_User As System.Windows.Forms.TextBox
    Friend WithEvents T_DataBase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents B_GO As System.Windows.Forms.Button
End Class
