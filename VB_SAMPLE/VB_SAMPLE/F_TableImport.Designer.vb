<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_TableImport
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
        Me.B_GiveUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_OK = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_SheetName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_Path = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.B_PickUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'B_GiveUp
        '
        Me.B_GiveUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.B_GiveUp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GiveUp.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_GiveUp.ForeColor = System.Drawing.Color.Black
        Me.B_GiveUp.Location = New System.Drawing.Point(239, 336)
        Me.B_GiveUp.Name = "B_GiveUp"
        Me.B_GiveUp.Size = New System.Drawing.Size(102, 36)
        Me.B_GiveUp.TabIndex = 95
        Me.B_GiveUp.Text = "放 棄"
        Me.B_GiveUp.UseVisualStyleBackColor = False
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_OK.ForeColor = System.Drawing.Color.Black
        Me.B_OK.Location = New System.Drawing.Point(348, 336)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(102, 36)
        Me.B_OK.TabIndex = 94
        Me.B_OK.Text = "確 定"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'T_SheetName
        '
        Me.T_SheetName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SheetName.ForeColor = System.Drawing.Color.Navy
        Me.T_SheetName.Location = New System.Drawing.Point(181, 130)
        Me.T_SheetName.MaxLength = 20
        Me.T_SheetName.Name = "T_SheetName"
        Me.T_SheetName.ReadOnly = True
        Me.T_SheetName.Size = New System.Drawing.Size(120, 29)
        Me.T_SheetName.TabIndex = 89
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(25, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 20)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "第一張工作表的名稱"
        '
        'T_Path
        '
        Me.T_Path.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Path.ForeColor = System.Drawing.Color.Navy
        Me.T_Path.Location = New System.Drawing.Point(181, 92)
        Me.T_Path.MaxLength = 180
        Me.T_Path.Name = "T_Path"
        Me.T_Path.ReadOnly = True
        Me.T_Path.Size = New System.Drawing.Size(470, 33)
        Me.T_Path.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(89, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "檔名及路徑"
        '
        'B_PickUp
        '
        Me.B_PickUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.B_PickUp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_PickUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_PickUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_PickUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PickUp.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PickUp.ForeColor = System.Drawing.Color.Black
        Me.B_PickUp.Location = New System.Drawing.Point(549, 130)
        Me.B_PickUp.Name = "B_PickUp"
        Me.B_PickUp.Size = New System.Drawing.Size(102, 36)
        Me.B_PickUp.TabIndex = 92
        Me.B_PickUp.Text = "選取檔案"
        Me.B_PickUp.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(178, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(414, 19)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "請敲『選取檔案』鈕，選取欲匯入的檔案，再敲『確定』鈕。"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(178, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(381, 19)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "匯入檔必須為 Excel 檔，且資料須儲存於第一張工作表，"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(178, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(306, 19)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "資料由格位 A2 起往下輸入，第一列為欄名。"
        '
        'F_TableImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(689, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_GiveUp)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.T_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_Path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.B_PickUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_TableImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_GiveUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_OK As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_SheetName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_PickUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
