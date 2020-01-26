<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_TempFile
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.B_02 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_03 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.MyClass_ButtonClose1 = New VB_SAMPLE.MyClass_ButtonClose()
        Me.B_01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(289, 247)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(412, 150)
        Me.TextBox1.TabIndex = 0
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.Purple
        Me.B_02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.White
        Me.B_02.Location = New System.Drawing.Point(498, 463)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(102, 36)
        Me.B_02.TabIndex = 2
        Me.B_02.Text = "寫入資料"
        Me.B_02.UseVisualStyleBackColor = False
        '
        'B_03
        '
        Me.B_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_03.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_03.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_03.ForeColor = System.Drawing.Color.White
        Me.B_03.Location = New System.Drawing.Point(390, 505)
        Me.B_03.Name = "B_03"
        Me.B_03.Size = New System.Drawing.Size(102, 36)
        Me.B_03.TabIndex = 3
        Me.B_03.Text = "讀出資料"
        Me.B_03.UseVisualStyleBackColor = False
        '
        'MyClass_ButtonClose1
        '
        Me.MyClass_ButtonClose1.BackColor = System.Drawing.Color.MediumVioletRed
        Me.MyClass_ButtonClose1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MyClass_ButtonClose1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.MyClass_ButtonClose1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.MyClass_ButtonClose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MyClass_ButtonClose1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.MyClass_ButtonClose1.ForeColor = System.Drawing.Color.White
        Me.MyClass_ButtonClose1.Location = New System.Drawing.Point(498, 547)
        Me.MyClass_ButtonClose1.Name = "MyClass_ButtonClose1"
        Me.MyClass_ButtonClose1.Size = New System.Drawing.Size(102, 36)
        Me.MyClass_ButtonClose1.TabIndex = 5
        Me.MyClass_ButtonClose1.Text = "關 閉"
        Me.MyClass_ButtonClose1.UseVisualStyleBackColor = False
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.White
        Me.B_01.Location = New System.Drawing.Point(390, 463)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(102, 36)
        Me.B_01.TabIndex = 1
        Me.B_01.Text = "建立資料夾"
        Me.B_01.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.SeaGreen
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(498, 505)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 4
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'F_TempFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.B_03)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MyClass_ButtonClose1)
        Me.Controls.Add(Me.B_01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_TempFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MyClass_ButtonClose1 As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents B_01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_03 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_02 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
End Class
