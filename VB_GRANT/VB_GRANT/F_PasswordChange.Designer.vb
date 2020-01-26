<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_PasswordChange
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
        Me.T_PASSA = New System.Windows.Forms.TextBox()
        Me.B_OK = New System.Windows.Forms.Button()
        Me.B_Quit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_PASSB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'T_PASSA
        '
        Me.T_PASSA.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_PASSA.ForeColor = System.Drawing.Color.Navy
        Me.T_PASSA.Location = New System.Drawing.Point(173, 109)
        Me.T_PASSA.MaxLength = 10
        Me.T_PASSA.Name = "T_PASSA"
        Me.T_PASSA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.T_PASSA.Size = New System.Drawing.Size(208, 33)
        Me.T_PASSA.TabIndex = 0
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.LightSteelBlue
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_OK.ForeColor = System.Drawing.Color.Navy
        Me.B_OK.Location = New System.Drawing.Point(280, 235)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(102, 38)
        Me.B_OK.TabIndex = 2
        Me.B_OK.Text = "確 定"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'B_Quit
        '
        Me.B_Quit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.B_Quit.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Quit.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Quit.ForeColor = System.Drawing.Color.Navy
        Me.B_Quit.Location = New System.Drawing.Point(172, 235)
        Me.B_Quit.Name = "B_Quit"
        Me.B_Quit.Size = New System.Drawing.Size(102, 38)
        Me.B_Quit.TabIndex = 3
        Me.B_Quit.Text = "放 棄"
        Me.B_Quit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(110, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "請輸入相同密碼兩次"
        '
        'T_PASSB
        '
        Me.T_PASSB.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_PASSB.ForeColor = System.Drawing.Color.Navy
        Me.T_PASSB.Location = New System.Drawing.Point(173, 152)
        Me.T_PASSB.MaxLength = 10
        Me.T_PASSB.Name = "T_PASSB"
        Me.T_PASSB.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.T_PASSB.Size = New System.Drawing.Size(208, 33)
        Me.T_PASSB.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(110, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(335, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "長度 6～10 位，限 英文、阿拉伯數字 及  橫線（- dash）"
        '
        'F_PasswordChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(554, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_PASSB)
        Me.Controls.Add(Me.T_PASSA)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.B_Quit)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_PasswordChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_PASSA As System.Windows.Forms.TextBox
    Friend WithEvents B_OK As System.Windows.Forms.Button
    Friend WithEvents B_Quit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_PASSB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
