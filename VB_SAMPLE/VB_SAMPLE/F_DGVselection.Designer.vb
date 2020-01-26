<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DGVselection
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_RGB_1 = New System.Windows.Forms.TextBox()
        Me.B_01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.T_RGB_2 = New System.Windows.Forms.TextBox()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.B_02 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_04 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_RGB_4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_RGB_3 = New System.Windows.Forms.TextBox()
        Me.B_03 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_06 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_RGB_6 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_RGB_5 = New System.Windows.Forms.TextBox()
        Me.B_05 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(168, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "字體顏色"
        '
        'T_RGB_1
        '
        Me.T_RGB_1.BackColor = System.Drawing.Color.White
        Me.T_RGB_1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_1.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_1.Location = New System.Drawing.Point(245, 29)
        Me.T_RGB_1.MaxLength = 11
        Me.T_RGB_1.Name = "T_RGB_1"
        Me.T_RGB_1.ReadOnly = True
        Me.T_RGB_1.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_1.TabIndex = 37
        Me.T_RGB_1.Text = "0,0,128"
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.Navy
        Me.B_01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.White
        Me.B_01.Location = New System.Drawing.Point(392, 30)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(96, 36)
        Me.B_01.TabIndex = 36
        Me.B_01.Text = "調色盤 1"
        Me.B_01.UseVisualStyleBackColor = False
        '
        'ColorDialog1
        '
        Me.ColorDialog1.FullOpen = True
        '
        'T_RGB_2
        '
        Me.T_RGB_2.BackColor = System.Drawing.Color.White
        Me.T_RGB_2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_2.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_2.Location = New System.Drawing.Point(245, 74)
        Me.T_RGB_2.MaxLength = 11
        Me.T_RGB_2.Name = "T_RGB_2"
        Me.T_RGB_2.ReadOnly = True
        Me.T_RGB_2.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_2.TabIndex = 39
        Me.T_RGB_2.Text = "255,255,255"
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.SteelBlue
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(291, 390)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 40
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(152, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "字體背景色"
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.Navy
        Me.B_02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.White
        Me.B_02.Location = New System.Drawing.Point(392, 74)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(96, 36)
        Me.B_02.TabIndex = 42
        Me.B_02.Text = "調色盤 2"
        Me.B_02.UseVisualStyleBackColor = False
        '
        'B_04
        '
        Me.B_04.BackColor = System.Drawing.Color.Navy
        Me.B_04.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_04.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_04.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_04.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_04.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_04.ForeColor = System.Drawing.Color.White
        Me.B_04.Location = New System.Drawing.Point(392, 193)
        Me.B_04.Name = "B_04"
        Me.B_04.Size = New System.Drawing.Size(96, 36)
        Me.B_04.TabIndex = 48
        Me.B_04.Text = "調色盤 4"
        Me.B_04.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(152, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "選區背景色"
        '
        'T_RGB_4
        '
        Me.T_RGB_4.BackColor = System.Drawing.Color.White
        Me.T_RGB_4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_4.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_4.Location = New System.Drawing.Point(245, 193)
        Me.T_RGB_4.MaxLength = 11
        Me.T_RGB_4.Name = "T_RGB_4"
        Me.T_RGB_4.ReadOnly = True
        Me.T_RGB_4.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_4.TabIndex = 46
        Me.T_RGB_4.Text = "180,0,90"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(136, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "選區字體顏色"
        '
        'T_RGB_3
        '
        Me.T_RGB_3.BackColor = System.Drawing.Color.White
        Me.T_RGB_3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_3.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_3.Location = New System.Drawing.Point(245, 148)
        Me.T_RGB_3.MaxLength = 11
        Me.T_RGB_3.Name = "T_RGB_3"
        Me.T_RGB_3.ReadOnly = True
        Me.T_RGB_3.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_3.TabIndex = 44
        Me.T_RGB_3.Text = "255,255,255"
        '
        'B_03
        '
        Me.B_03.BackColor = System.Drawing.Color.Navy
        Me.B_03.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_03.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_03.ForeColor = System.Drawing.Color.White
        Me.B_03.Location = New System.Drawing.Point(392, 149)
        Me.B_03.Name = "B_03"
        Me.B_03.Size = New System.Drawing.Size(96, 36)
        Me.B_03.TabIndex = 43
        Me.B_03.Text = "調色盤 3"
        Me.B_03.UseVisualStyleBackColor = False
        '
        'B_06
        '
        Me.B_06.BackColor = System.Drawing.Color.Navy
        Me.B_06.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_06.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_06.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_06.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_06.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_06.ForeColor = System.Drawing.Color.White
        Me.B_06.Location = New System.Drawing.Point(392, 314)
        Me.B_06.Name = "B_06"
        Me.B_06.Size = New System.Drawing.Size(96, 36)
        Me.B_06.TabIndex = 54
        Me.B_06.Text = "調色盤 6"
        Me.B_06.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(136, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "間格列背景色"
        '
        'T_RGB_6
        '
        Me.T_RGB_6.BackColor = System.Drawing.Color.White
        Me.T_RGB_6.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_6.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_6.Location = New System.Drawing.Point(245, 314)
        Me.T_RGB_6.MaxLength = 11
        Me.T_RGB_6.Name = "T_RGB_6"
        Me.T_RGB_6.ReadOnly = True
        Me.T_RGB_6.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_6.TabIndex = 52
        Me.T_RGB_6.Text = "225,243,245"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(120, 274)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 20)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "間格列字體顏色"
        '
        'T_RGB_5
        '
        Me.T_RGB_5.BackColor = System.Drawing.Color.White
        Me.T_RGB_5.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RGB_5.ForeColor = System.Drawing.Color.Navy
        Me.T_RGB_5.Location = New System.Drawing.Point(245, 269)
        Me.T_RGB_5.MaxLength = 11
        Me.T_RGB_5.Name = "T_RGB_5"
        Me.T_RGB_5.ReadOnly = True
        Me.T_RGB_5.Size = New System.Drawing.Size(130, 33)
        Me.T_RGB_5.TabIndex = 50
        Me.T_RGB_5.Text = "0,0,128"
        '
        'B_05
        '
        Me.B_05.BackColor = System.Drawing.Color.Navy
        Me.B_05.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_05.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_05.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_05.ForeColor = System.Drawing.Color.White
        Me.B_05.Location = New System.Drawing.Point(392, 270)
        Me.B_05.Name = "B_05"
        Me.B_05.Size = New System.Drawing.Size(96, 36)
        Me.B_05.TabIndex = 49
        Me.B_05.Text = "調色盤 5"
        Me.B_05.UseVisualStyleBackColor = False
        '
        'F_DGVselection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(684, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_06)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_RGB_6)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_RGB_5)
        Me.Controls.Add(Me.B_05)
        Me.Controls.Add(Me.B_04)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_RGB_4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_RGB_3)
        Me.Controls.Add(Me.B_03)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.T_RGB_2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_RGB_1)
        Me.Controls.Add(Me.B_01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_DGVselection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_RGB_1 As System.Windows.Forms.TextBox
    Friend WithEvents B_01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents T_RGB_2 As System.Windows.Forms.TextBox
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_02 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_04 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_RGB_4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_RGB_3 As System.Windows.Forms.TextBox
    Friend WithEvents B_03 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_06 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_RGB_6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_RGB_5 As System.Windows.Forms.TextBox
    Friend WithEvents B_05 As VB_SAMPLE.MyClass_ButtonGeneral
End Class
