<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_SheetChoice
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.T_Path = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_SheetName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_CreateDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_Count = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.B_GiveUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_OK = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_PickUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'T_Path
        '
        Me.T_Path.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Path.ForeColor = System.Drawing.Color.Navy
        Me.T_Path.Location = New System.Drawing.Point(177, 33)
        Me.T_Path.MaxLength = 180
        Me.T_Path.Name = "T_Path"
        Me.T_Path.Size = New System.Drawing.Size(470, 29)
        Me.T_Path.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "檔名及路徑"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Navy
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(177, 205)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(207, 164)
        Me.ListBox1.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 20)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "第一張工作表的名稱"
        '
        'T_SheetName
        '
        Me.T_SheetName.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SheetName.ForeColor = System.Drawing.Color.Navy
        Me.T_SheetName.Location = New System.Drawing.Point(177, 66)
        Me.T_SheetName.MaxLength = 20
        Me.T_SheetName.Name = "T_SheetName"
        Me.T_SheetName.Size = New System.Drawing.Size(120, 27)
        Me.T_SheetName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(69, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "檔案產生日期"
        '
        'T_CreateDate
        '
        Me.T_CreateDate.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_CreateDate.ForeColor = System.Drawing.Color.Navy
        Me.T_CreateDate.Location = New System.Drawing.Point(177, 97)
        Me.T_CreateDate.MaxLength = 12
        Me.T_CreateDate.Name = "T_CreateDate"
        Me.T_CreateDate.Size = New System.Drawing.Size(200, 27)
        Me.T_CreateDate.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(85, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 20)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "工作表數量"
        '
        'T_Count
        '
        Me.T_Count.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Count.ForeColor = System.Drawing.Color.Navy
        Me.T_Count.Location = New System.Drawing.Point(177, 128)
        Me.T_Count.MaxLength = 12
        Me.T_Count.Name = "T_Count"
        Me.T_Count.Size = New System.Drawing.Size(96, 27)
        Me.T_Count.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(85, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "工作表清單"
        '
        'B_GiveUp
        '
        Me.B_GiveUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_GiveUp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GiveUp.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_GiveUp.ForeColor = System.Drawing.Color.Black
        Me.B_GiveUp.Location = New System.Drawing.Point(436, 333)
        Me.B_GiveUp.Name = "B_GiveUp"
        Me.B_GiveUp.Size = New System.Drawing.Size(102, 36)
        Me.B_GiveUp.TabIndex = 8
        Me.B_GiveUp.Text = "放 棄"
        Me.B_GiveUp.UseVisualStyleBackColor = False
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_OK.ForeColor = System.Drawing.Color.Black
        Me.B_OK.Location = New System.Drawing.Point(545, 333)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(102, 36)
        Me.B_OK.TabIndex = 7
        Me.B_OK.Text = "確 定"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'B_PickUp
        '
        Me.B_PickUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_PickUp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_PickUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_PickUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_PickUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PickUp.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PickUp.ForeColor = System.Drawing.Color.Black
        Me.B_PickUp.Location = New System.Drawing.Point(545, 68)
        Me.B_PickUp.Name = "B_PickUp"
        Me.B_PickUp.Size = New System.Drawing.Size(102, 36)
        Me.B_PickUp.TabIndex = 5
        Me.B_PickUp.Text = "選取檔案"
        Me.B_PickUp.UseVisualStyleBackColor = False
        '
        'F_SheetChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(733, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_GiveUp)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.T_Count)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_CreateDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_Path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.B_PickUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_SheetChoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents T_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_PickUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_SheetName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_CreateDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_Count As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents B_OK As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_GiveUp As VB_SAMPLE.MyClass_ButtonGeneral

End Class
