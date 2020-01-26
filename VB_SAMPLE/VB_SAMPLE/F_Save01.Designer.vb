<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Save01
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_FileKind = New System.Windows.Forms.GroupBox()
        Me.T_File02 = New System.Windows.Forms.RadioButton()
        Me.T_File01 = New System.Windows.Forms.RadioButton()
        Me.T_Path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.B_Save = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_OK = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_GiveUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_FileKind.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(73, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "檔案類型"
        '
        'T_FileKind
        '
        Me.T_FileKind.Controls.Add(Me.T_File02)
        Me.T_FileKind.Controls.Add(Me.T_File01)
        Me.T_FileKind.Location = New System.Drawing.Point(149, 81)
        Me.T_FileKind.Name = "T_FileKind"
        Me.T_FileKind.Size = New System.Drawing.Size(193, 46)
        Me.T_FileKind.TabIndex = 55
        Me.T_FileKind.TabStop = False
        '
        'T_File02
        '
        Me.T_File02.AutoSize = True
        Me.T_File02.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_File02.ForeColor = System.Drawing.Color.Navy
        Me.T_File02.Location = New System.Drawing.Point(99, 14)
        Me.T_File02.Name = "T_File02"
        Me.T_File02.Size = New System.Drawing.Size(72, 28)
        Me.T_File02.TabIndex = 2
        Me.T_File02.Text = "Html"
        Me.T_File02.UseVisualStyleBackColor = True
        '
        'T_File01
        '
        Me.T_File01.AutoSize = True
        Me.T_File01.Checked = True
        Me.T_File01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_File01.ForeColor = System.Drawing.Color.Navy
        Me.T_File01.Location = New System.Drawing.Point(7, 14)
        Me.T_File01.Name = "T_File01"
        Me.T_File01.Size = New System.Drawing.Size(72, 28)
        Me.T_File01.TabIndex = 1
        Me.T_File01.TabStop = True
        Me.T_File01.Text = "Excel"
        Me.T_File01.UseVisualStyleBackColor = True
        '
        'T_Path
        '
        Me.T_Path.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Path.Location = New System.Drawing.Point(149, 133)
        Me.T_Path.MaxLength = 180
        Me.T_Path.Name = "T_Path"
        Me.T_Path.ReadOnly = True
        Me.T_Path.Size = New System.Drawing.Size(470, 29)
        Me.T_Path.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "檔名及路徑"
        '
        'B_Save
        '
        Me.B_Save.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.B_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Save.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Save.ForeColor = System.Drawing.Color.White
        Me.B_Save.Location = New System.Drawing.Point(551, 168)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(68, 36)
        Me.B_Save.TabIndex = 3
        Me.B_Save.Text = "重 設"
        Me.B_Save.UseVisualStyleBackColor = False
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.Teal
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_OK.ForeColor = System.Drawing.Color.White
        Me.B_OK.Location = New System.Drawing.Point(342, 289)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(102, 36)
        Me.B_OK.TabIndex = 4
        Me.B_OK.Text = "OK"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'B_GiveUp
        '
        Me.B_GiveUp.BackColor = System.Drawing.Color.Teal
        Me.B_GiveUp.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GiveUp.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_GiveUp.ForeColor = System.Drawing.Color.White
        Me.B_GiveUp.Location = New System.Drawing.Point(232, 289)
        Me.B_GiveUp.Name = "B_GiveUp"
        Me.B_GiveUp.Size = New System.Drawing.Size(102, 36)
        Me.B_GiveUp.TabIndex = 5
        Me.B_GiveUp.Text = "放 棄"
        Me.B_GiveUp.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(148, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(343, 19)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "若要變更內定的檔名或資料夾，請敲『重 設』鈕。"
        '
        'F_Save01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(677, 350)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_Path)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Save)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_FileKind)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.B_GiveUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Save01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.T_FileKind.ResumeLayout(False)
        Me.T_FileKind.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_OK As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_GiveUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_FileKind As System.Windows.Forms.GroupBox
    Friend WithEvents T_File02 As System.Windows.Forms.RadioButton
    Friend WithEvents T_File01 As System.Windows.Forms.RadioButton
    Friend WithEvents T_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_Save As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
