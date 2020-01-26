<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DLL01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_DLL01))
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.B_USD = New System.Windows.Forms.Button()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.T_AMT01 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_StartCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_QTY = New System.Windows.Forms.TextBox()
        Me.T_USD = New System.Windows.Forms.TextBox()
        Me.B_ChineseCHR = New System.Windows.Forms.Button()
        Me.B_ODD = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_MATCH = New System.Windows.Forms.GroupBox()
        Me.T_NO = New System.Windows.Forms.RadioButton()
        Me.T_YES = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_Parameter = New System.Windows.Forms.Label()
        Me.B_NTD = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.T_MATCH.SuspendLayout()
        Me.SuspendLayout()
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Transparent
        Me.B_Reset.BackgroundImage = CType(resources.GetObject("B_Reset.BackgroundImage"), System.Drawing.Image)
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_Reset.Location = New System.Drawing.Point(383, 486)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 105
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_USD
        '
        Me.B_USD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_USD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_USD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_USD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_USD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_USD.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_USD.ForeColor = System.Drawing.Color.White
        Me.B_USD.Location = New System.Drawing.Point(128, 158)
        Me.B_USD.Name = "B_USD"
        Me.B_USD.Size = New System.Drawing.Size(136, 38)
        Me.B_USD.TabIndex = 104
        Me.B_USD.Text = "轉成英文金額"
        Me.B_USD.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Transparent
        Me.B_Close.BackgroundImage = CType(resources.GetObject("B_Close.BackgroundImage"), System.Drawing.Image)
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.Purple
        Me.B_Close.Location = New System.Drawing.Point(269, 486)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 103
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(37, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 20)
        Me.Label10.TabIndex = 114
        Me.Label10.Text = "阿拉伯數字"
        '
        'T_AMT01
        '
        Me.T_AMT01.BackColor = System.Drawing.Color.White
        Me.T_AMT01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AMT01.ForeColor = System.Drawing.Color.Navy
        Me.T_AMT01.Location = New System.Drawing.Point(128, 118)
        Me.T_AMT01.Margin = New System.Windows.Forms.Padding(1)
        Me.T_AMT01.Name = "T_AMT01"
        Me.T_AMT01.Size = New System.Drawing.Size(182, 33)
        Me.T_AMT01.TabIndex = 113
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(537, 315)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 19)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "19968～40907"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(374, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 20)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "起始碼"
        '
        'T_StartCode
        '
        Me.T_StartCode.BackColor = System.Drawing.Color.White
        Me.T_StartCode.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_StartCode.ForeColor = System.Drawing.Color.Navy
        Me.T_StartCode.Location = New System.Drawing.Point(433, 308)
        Me.T_StartCode.Margin = New System.Windows.Forms.Padding(1)
        Me.T_StartCode.Name = "T_StartCode"
        Me.T_StartCode.Size = New System.Drawing.Size(102, 33)
        Me.T_StartCode.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(537, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 19)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "1～20940"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(390, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "字數"
        '
        'T_QTY
        '
        Me.T_QTY.BackColor = System.Drawing.Color.White
        Me.T_QTY.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_QTY.ForeColor = System.Drawing.Color.Navy
        Me.T_QTY.Location = New System.Drawing.Point(433, 273)
        Me.T_QTY.Margin = New System.Windows.Forms.Padding(1)
        Me.T_QTY.Name = "T_QTY"
        Me.T_QTY.Size = New System.Drawing.Size(102, 33)
        Me.T_QTY.TabIndex = 107
        '
        'T_USD
        '
        Me.T_USD.BackColor = System.Drawing.Color.White
        Me.T_USD.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_USD.ForeColor = System.Drawing.Color.Navy
        Me.T_USD.Location = New System.Drawing.Point(38, 16)
        Me.T_USD.Margin = New System.Windows.Forms.Padding(1)
        Me.T_USD.Multiline = True
        Me.T_USD.Name = "T_USD"
        Me.T_USD.Size = New System.Drawing.Size(678, 90)
        Me.T_USD.TabIndex = 106
        '
        'B_ChineseCHR
        '
        Me.B_ChineseCHR.BackColor = System.Drawing.Color.DarkBlue
        Me.B_ChineseCHR.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ChineseCHR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ChineseCHR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ChineseCHR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ChineseCHR.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_ChineseCHR.ForeColor = System.Drawing.Color.White
        Me.B_ChineseCHR.Location = New System.Drawing.Point(433, 347)
        Me.B_ChineseCHR.Name = "B_ChineseCHR"
        Me.B_ChineseCHR.Size = New System.Drawing.Size(136, 38)
        Me.B_ChineseCHR.TabIndex = 115
        Me.B_ChineseCHR.Text = "產生中文字元"
        Me.B_ChineseCHR.UseVisualStyleBackColor = False
        '
        'B_ODD
        '
        Me.B_ODD.BackColor = System.Drawing.Color.Purple
        Me.B_ODD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ODD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ODD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ODD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ODD.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_ODD.ForeColor = System.Drawing.Color.White
        Me.B_ODD.Location = New System.Drawing.Point(128, 242)
        Me.B_ODD.Name = "B_ODD"
        Me.B_ODD.Size = New System.Drawing.Size(136, 38)
        Me.B_ODD.TabIndex = 116
        Me.B_ODD.Text = "判斷奇偶數"
        Me.B_ODD.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(332, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "加 Only"
        '
        'T_MATCH
        '
        Me.T_MATCH.BackColor = System.Drawing.Color.Transparent
        Me.T_MATCH.Controls.Add(Me.T_NO)
        Me.T_MATCH.Controls.Add(Me.T_YES)
        Me.T_MATCH.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH.Location = New System.Drawing.Point(399, 109)
        Me.T_MATCH.Name = "T_MATCH"
        Me.T_MATCH.Size = New System.Drawing.Size(136, 42)
        Me.T_MATCH.TabIndex = 117
        Me.T_MATCH.TabStop = False
        '
        'T_NO
        '
        Me.T_NO.AutoSize = True
        Me.T_NO.BackColor = System.Drawing.Color.Transparent
        Me.T_NO.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_NO.ForeColor = System.Drawing.Color.Black
        Me.T_NO.Location = New System.Drawing.Point(75, 15)
        Me.T_NO.Name = "T_NO"
        Me.T_NO.Size = New System.Drawing.Size(43, 24)
        Me.T_NO.TabIndex = 12
        Me.T_NO.Text = "否"
        Me.T_NO.UseVisualStyleBackColor = False
        '
        'T_YES
        '
        Me.T_YES.AutoSize = True
        Me.T_YES.BackColor = System.Drawing.Color.Transparent
        Me.T_YES.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_YES.ForeColor = System.Drawing.Color.Black
        Me.T_YES.Location = New System.Drawing.Point(6, 15)
        Me.T_YES.Name = "T_YES"
        Me.T_YES.Size = New System.Drawing.Size(43, 24)
        Me.T_YES.TabIndex = 11
        Me.T_YES.Text = "是"
        Me.T_YES.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(657, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "（可省略）"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_Parameter
        '
        Me.L_Parameter.AutoSize = True
        Me.L_Parameter.BackColor = System.Drawing.Color.SteelBlue
        Me.L_Parameter.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_Parameter.ForeColor = System.Drawing.Color.Navy
        Me.L_Parameter.Location = New System.Drawing.Point(582, 358)
        Me.L_Parameter.Name = "L_Parameter"
        Me.L_Parameter.Size = New System.Drawing.Size(0, 20)
        Me.L_Parameter.TabIndex = 120
        '
        'B_NTD
        '
        Me.B_NTD.BackColor = System.Drawing.Color.Teal
        Me.B_NTD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_NTD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_NTD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_NTD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NTD.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_NTD.ForeColor = System.Drawing.Color.White
        Me.B_NTD.Location = New System.Drawing.Point(128, 200)
        Me.B_NTD.Name = "B_NTD"
        Me.B_NTD.Size = New System.Drawing.Size(136, 38)
        Me.B_NTD.TabIndex = 121
        Me.B_NTD.Text = "轉成中文金額"
        Me.B_NTD.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(367, 257)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 148)
        Me.Panel1.TabIndex = 122
        '
        'F_DLL01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(754, 534)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_NTD)
        Me.Controls.Add(Me.L_Parameter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_MATCH)
        Me.Controls.Add(Me.B_ODD)
        Me.Controls.Add(Me.B_ChineseCHR)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.T_AMT01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.T_StartCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_QTY)
        Me.Controls.Add(Me.T_USD)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_USD)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_DLL01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.T_MATCH.ResumeLayout(False)
        Me.T_MATCH.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents B_USD As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents T_AMT01 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents T_StartCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_QTY As System.Windows.Forms.TextBox
    Friend WithEvents T_USD As System.Windows.Forms.TextBox
    Friend WithEvents B_ChineseCHR As System.Windows.Forms.Button
    Friend WithEvents B_ODD As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_MATCH As System.Windows.Forms.GroupBox
    Friend WithEvents T_NO As System.Windows.Forms.RadioButton
    Friend WithEvents T_YES As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_Parameter As System.Windows.Forms.Label
    Friend WithEvents B_NTD As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
