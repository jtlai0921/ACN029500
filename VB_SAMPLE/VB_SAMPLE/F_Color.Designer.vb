<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Color
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Color))
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.T_R = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_G = New System.Windows.Forms.TextBox()
        Me.HScrollBar2 = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_B = New System.Windows.Forms.TextBox()
        Me.HScrollBar3 = New System.Windows.Forms.HScrollBar()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.T_RGB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_hue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_sat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_bri = New System.Windows.Forms.TextBox()
        Me.HScrollBar4 = New System.Windows.Forms.HScrollBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.B_02 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.MyClass_ButtonClose1 = New VB_SAMPLE.MyClass_ButtonClose()
        Me.B_01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.SuspendLayout()
        '
        'HScrollBar1
        '
        Me.HScrollBar1.LargeChange = 1
        Me.HScrollBar1.Location = New System.Drawing.Point(255, 216)
        Me.HScrollBar1.Maximum = 255
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(471, 34)
        Me.HScrollBar1.TabIndex = 23
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(255, 44)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(234, 151)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = ""
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'T_R
        '
        Me.T_R.BackColor = System.Drawing.Color.White
        Me.T_R.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_R.ForeColor = System.Drawing.Color.Navy
        Me.T_R.Location = New System.Drawing.Point(180, 217)
        Me.T_R.MaxLength = 3
        Me.T_R.Name = "T_R"
        Me.T_R.ReadOnly = True
        Me.T_R.Size = New System.Drawing.Size(50, 33)
        Me.T_R.TabIndex = 24
        Me.T_R.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(136, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 27)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "紅"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(136, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 27)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "綠"
        '
        'T_G
        '
        Me.T_G.BackColor = System.Drawing.Color.White
        Me.T_G.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_G.ForeColor = System.Drawing.Color.Navy
        Me.T_G.Location = New System.Drawing.Point(180, 264)
        Me.T_G.MaxLength = 3
        Me.T_G.Name = "T_G"
        Me.T_G.ReadOnly = True
        Me.T_G.Size = New System.Drawing.Size(50, 33)
        Me.T_G.TabIndex = 28
        Me.T_G.Text = "0"
        '
        'HScrollBar2
        '
        Me.HScrollBar2.Location = New System.Drawing.Point(255, 263)
        Me.HScrollBar2.Maximum = 264
        Me.HScrollBar2.Name = "HScrollBar2"
        Me.HScrollBar2.Size = New System.Drawing.Size(471, 34)
        Me.HScrollBar2.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(136, 314)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 27)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "藍"
        '
        'T_B
        '
        Me.T_B.BackColor = System.Drawing.Color.White
        Me.T_B.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_B.ForeColor = System.Drawing.Color.Navy
        Me.T_B.Location = New System.Drawing.Point(180, 311)
        Me.T_B.MaxLength = 3
        Me.T_B.Name = "T_B"
        Me.T_B.ReadOnly = True
        Me.T_B.Size = New System.Drawing.Size(50, 33)
        Me.T_B.TabIndex = 31
        Me.T_B.Text = "0"
        '
        'HScrollBar3
        '
        Me.HScrollBar3.Location = New System.Drawing.Point(255, 310)
        Me.HScrollBar3.Maximum = 264
        Me.HScrollBar3.Name = "HScrollBar3"
        Me.HScrollBar3.Size = New System.Drawing.Size(471, 34)
        Me.HScrollBar3.TabIndex = 30
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.Black
        Me.RichTextBox2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox2.ForeColor = System.Drawing.Color.White
        Me.RichTextBox2.Location = New System.Drawing.Point(492, 44)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(234, 151)
        Me.RichTextBox2.TabIndex = 33
        Me.RichTextBox2.Text = ""
        '
        'T_RGB
        '
        Me.T_RGB.BackColor = System.Drawing.Color.White
        Me.T_RGB.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB.Location = New System.Drawing.Point(180, 367)
        Me.T_RGB.MaxLength = 11
        Me.T_RGB.Name = "T_RGB"
        Me.T_RGB.ReadOnly = True
        Me.T_RGB.Size = New System.Drawing.Size(141, 33)
        Me.T_RGB.TabIndex = 34
        Me.T_RGB.Text = "0, 0, 0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(123, 370)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 27)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "RGB"
        '
        'T_hue
        '
        Me.T_hue.BackColor = System.Drawing.Color.White
        Me.T_hue.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_hue.ForeColor = System.Drawing.Color.Navy
        Me.T_hue.Location = New System.Drawing.Point(425, 367)
        Me.T_hue.MaxLength = 11
        Me.T_hue.Name = "T_hue"
        Me.T_hue.Size = New System.Drawing.Size(53, 29)
        Me.T_hue.TabIndex = 37
        Me.T_hue.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(381, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "色相"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(479, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 27)
        Me.Label6.TabIndex = 47
        '
        'T_sat
        '
        Me.T_sat.BackColor = System.Drawing.Color.White
        Me.T_sat.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_sat.ForeColor = System.Drawing.Color.Navy
        Me.T_sat.Location = New System.Drawing.Point(557, 367)
        Me.T_sat.MaxLength = 11
        Me.T_sat.Name = "T_sat"
        Me.T_sat.Size = New System.Drawing.Size(53, 29)
        Me.T_sat.TabIndex = 46
        Me.T_sat.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(497, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "飽和度"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(629, 374)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 20)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "亮度"
        '
        'T_bri
        '
        Me.T_bri.BackColor = System.Drawing.Color.White
        Me.T_bri.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_bri.ForeColor = System.Drawing.Color.Navy
        Me.T_bri.Location = New System.Drawing.Point(673, 367)
        Me.T_bri.MaxLength = 11
        Me.T_bri.Name = "T_bri"
        Me.T_bri.Size = New System.Drawing.Size(53, 29)
        Me.T_bri.TabIndex = 49
        Me.T_bri.Text = "0"
        '
        'HScrollBar4
        '
        Me.HScrollBar4.LargeChange = 1
        Me.HScrollBar4.Location = New System.Drawing.Point(255, 438)
        Me.HScrollBar4.Maximum = 1000
        Me.HScrollBar4.Name = "HScrollBar4"
        Me.HScrollBar4.Size = New System.Drawing.Size(471, 34)
        Me.HScrollBar4.TabIndex = 54
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(179, 445)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "亮度調整"
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.Black
        Me.B_02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.White
        Me.B_02.Location = New System.Drawing.Point(756, 159)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(102, 36)
        Me.B_02.TabIndex = 36
        Me.B_02.Text = "調色盤 2"
        Me.B_02.UseVisualStyleBackColor = False
        '
        'MyClass_ButtonClose1
        '
        Me.MyClass_ButtonClose1.BackColor = System.Drawing.Color.MediumVioletRed
        Me.MyClass_ButtonClose1.BackgroundImage = CType(resources.GetObject("MyClass_ButtonClose1.BackgroundImage"), System.Drawing.Image)
        Me.MyClass_ButtonClose1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MyClass_ButtonClose1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.MyClass_ButtonClose1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.MyClass_ButtonClose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MyClass_ButtonClose1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.MyClass_ButtonClose1.ForeColor = System.Drawing.Color.Navy
        Me.MyClass_ButtonClose1.Location = New System.Drawing.Point(366, 564)
        Me.MyClass_ButtonClose1.Name = "MyClass_ButtonClose1"
        Me.MyClass_ButtonClose1.Size = New System.Drawing.Size(120, 42)
        Me.MyClass_ButtonClose1.TabIndex = 25
        Me.MyClass_ButtonClose1.Text = "Close"
        Me.MyClass_ButtonClose1.UseVisualStyleBackColor = False
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.Black
        Me.B_01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.White
        Me.B_01.Location = New System.Drawing.Point(756, 105)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(102, 36)
        Me.B_01.TabIndex = 20
        Me.B_01.Text = "調色盤 1"
        Me.B_01.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_Reset.BackgroundImage = CType(resources.GetObject("B_Reset.BackgroundImage"), System.Drawing.Image)
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.Navy
        Me.B_Reset.Location = New System.Drawing.Point(495, 564)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(120, 42)
        Me.B_Reset.TabIndex = 56
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'F_Color
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(980, 621)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.HScrollBar4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.T_bri)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_sat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_hue)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_RGB)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_B)
        Me.Controls.Add(Me.HScrollBar3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_G)
        Me.Controls.Add(Me.HScrollBar2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MyClass_ButtonClose1)
        Me.Controls.Add(Me.T_R)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.B_01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Color"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "色彩管理"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents B_01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents T_R As System.Windows.Forms.TextBox
    Friend WithEvents MyClass_ButtonClose1 As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_G As System.Windows.Forms.TextBox
    Friend WithEvents HScrollBar2 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_B As System.Windows.Forms.TextBox
    Friend WithEvents HScrollBar3 As System.Windows.Forms.HScrollBar
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents T_RGB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_02 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_hue As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_sat As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents T_bri As System.Windows.Forms.TextBox
    Friend WithEvents HScrollBar4 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
End Class
