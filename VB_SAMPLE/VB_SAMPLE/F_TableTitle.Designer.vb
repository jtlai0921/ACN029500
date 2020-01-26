<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_TableTitle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TableTitle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.B_UpdateSQL = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_CLEAR = New System.Windows.Forms.Button()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.B_BOT = New System.Windows.Forms.Button()
        Me.B_NEXT = New System.Windows.Forms.Button()
        Me.B_PREV = New System.Windows.Forms.Button()
        Me.B_TOP = New System.Windows.Forms.Button()
        Me.T_Title = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.B_Export = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Import = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_Delete = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Modify = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_ADD = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_TitleCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_UpdateSQL
        '
        Me.B_UpdateSQL.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_UpdateSQL.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_UpdateSQL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_UpdateSQL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_UpdateSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_UpdateSQL.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_UpdateSQL.ForeColor = System.Drawing.Color.Navy
        Me.B_UpdateSQL.Location = New System.Drawing.Point(546, 435)
        Me.B_UpdateSQL.Name = "B_UpdateSQL"
        Me.B_UpdateSQL.Size = New System.Drawing.Size(102, 36)
        Me.B_UpdateSQL.TabIndex = 81
        Me.B_UpdateSQL.Text = "更 新"
        Me.B_UpdateSQL.UseVisualStyleBackColor = False
        Me.B_UpdateSQL.Visible = False
        '
        'B_CLEAR
        '
        Me.B_CLEAR.BackgroundImage = CType(resources.GetObject("B_CLEAR.BackgroundImage"), System.Drawing.Image)
        Me.B_CLEAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.B_CLEAR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_CLEAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_CLEAR.Location = New System.Drawing.Point(591, 212)
        Me.B_CLEAR.Name = "B_CLEAR"
        Me.B_CLEAR.Size = New System.Drawing.Size(34, 34)
        Me.B_CLEAR.TabIndex = 80
        Me.B_CLEAR.UseVisualStyleBackColor = True
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.Navy
        Me.B_Close.Location = New System.Drawing.Point(654, 519)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 79
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.Navy
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_RecordNo.Location = New System.Drawing.Point(59, 21)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(201, 20)
        Me.T_RecordNo.TabIndex = 76
        '
        'B_BOT
        '
        Me.B_BOT.BackgroundImage = CType(resources.GetObject("B_BOT.BackgroundImage"), System.Drawing.Image)
        Me.B_BOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.B_BOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_BOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_BOT.Location = New System.Drawing.Point(554, 212)
        Me.B_BOT.Name = "B_BOT"
        Me.B_BOT.Size = New System.Drawing.Size(34, 34)
        Me.B_BOT.TabIndex = 68
        Me.B_BOT.UseVisualStyleBackColor = True
        '
        'B_NEXT
        '
        Me.B_NEXT.BackgroundImage = CType(resources.GetObject("B_NEXT.BackgroundImage"), System.Drawing.Image)
        Me.B_NEXT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.B_NEXT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_NEXT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_NEXT.Location = New System.Drawing.Point(517, 212)
        Me.B_NEXT.Name = "B_NEXT"
        Me.B_NEXT.Size = New System.Drawing.Size(34, 34)
        Me.B_NEXT.TabIndex = 67
        Me.B_NEXT.UseVisualStyleBackColor = True
        '
        'B_PREV
        '
        Me.B_PREV.BackgroundImage = CType(resources.GetObject("B_PREV.BackgroundImage"), System.Drawing.Image)
        Me.B_PREV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.B_PREV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_PREV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_PREV.Location = New System.Drawing.Point(480, 212)
        Me.B_PREV.Name = "B_PREV"
        Me.B_PREV.Size = New System.Drawing.Size(34, 34)
        Me.B_PREV.TabIndex = 66
        Me.B_PREV.UseVisualStyleBackColor = True
        '
        'B_TOP
        '
        Me.B_TOP.BackgroundImage = CType(resources.GetObject("B_TOP.BackgroundImage"), System.Drawing.Image)
        Me.B_TOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.B_TOP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_TOP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_TOP.Location = New System.Drawing.Point(443, 212)
        Me.B_TOP.Name = "B_TOP"
        Me.B_TOP.Size = New System.Drawing.Size(34, 34)
        Me.B_TOP.TabIndex = 65
        Me.B_TOP.UseVisualStyleBackColor = True
        '
        'T_Title
        '
        Me.T_Title.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Title.ForeColor = System.Drawing.Color.Black
        Me.T_Title.Location = New System.Drawing.Point(443, 305)
        Me.T_Title.MaxLength = 14
        Me.T_Title.Name = "T_Title"
        Me.T_Title.Size = New System.Drawing.Size(154, 33)
        Me.T_Title.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(392, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 24)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "職稱"
        '
        'B_Export
        '
        Me.B_Export.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_Export.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Export.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Export.ForeColor = System.Drawing.Color.Navy
        Me.B_Export.Location = New System.Drawing.Point(654, 477)
        Me.B_Export.Name = "B_Export"
        Me.B_Export.Size = New System.Drawing.Size(102, 36)
        Me.B_Export.TabIndex = 75
        Me.B_Export.Text = "匯 出"
        Me.B_Export.UseVisualStyleBackColor = False
        '
        'B_Import
        '
        Me.B_Import.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_Import.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Import.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Import.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Import.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Import.ForeColor = System.Drawing.Color.Navy
        Me.B_Import.Location = New System.Drawing.Point(654, 435)
        Me.B_Import.Name = "B_Import"
        Me.B_Import.Size = New System.Drawing.Size(102, 36)
        Me.B_Import.TabIndex = 74
        Me.B_Import.Text = "匯 入"
        Me.B_Import.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(57, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(282, 500)
        Me.DataGridView1.TabIndex = 64
        '
        'B_Delete
        '
        Me.B_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_Delete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Delete.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Delete.ForeColor = System.Drawing.Color.Navy
        Me.B_Delete.Location = New System.Drawing.Point(654, 393)
        Me.B_Delete.Name = "B_Delete"
        Me.B_Delete.Size = New System.Drawing.Size(102, 36)
        Me.B_Delete.TabIndex = 73
        Me.B_Delete.Text = "刪 除"
        Me.B_Delete.UseVisualStyleBackColor = False
        '
        'B_Modify
        '
        Me.B_Modify.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_Modify.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Modify.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Modify.ForeColor = System.Drawing.Color.Navy
        Me.B_Modify.Location = New System.Drawing.Point(654, 351)
        Me.B_Modify.Name = "B_Modify"
        Me.B_Modify.Size = New System.Drawing.Size(102, 36)
        Me.B_Modify.TabIndex = 72
        Me.B_Modify.Text = "修 改"
        Me.B_Modify.UseVisualStyleBackColor = False
        '
        'B_ADD
        '
        Me.B_ADD.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.B_ADD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ADD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_ADD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ADD.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_ADD.ForeColor = System.Drawing.Color.Navy
        Me.B_ADD.Location = New System.Drawing.Point(654, 309)
        Me.B_ADD.Name = "B_ADD"
        Me.B_ADD.Size = New System.Drawing.Size(102, 36)
        Me.B_ADD.TabIndex = 71
        Me.B_ADD.Text = "新 增"
        Me.B_ADD.UseVisualStyleBackColor = False
        '
        'T_TitleCode
        '
        Me.T_TitleCode.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TitleCode.ForeColor = System.Drawing.Color.Black
        Me.T_TitleCode.Location = New System.Drawing.Point(443, 266)
        Me.T_TitleCode.MaxLength = 3
        Me.T_TitleCode.Name = "T_TitleCode"
        Me.T_TitleCode.Size = New System.Drawing.Size(95, 33)
        Me.T_TitleCode.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(354, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "職稱代號"
        '
        'F_TableTitle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(814, 574)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_UpdateSQL)
        Me.Controls.Add(Me.B_CLEAR)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.B_BOT)
        Me.Controls.Add(Me.B_NEXT)
        Me.Controls.Add(Me.B_PREV)
        Me.Controls.Add(Me.B_TOP)
        Me.Controls.Add(Me.T_Title)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.B_Export)
        Me.Controls.Add(Me.B_Import)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Delete)
        Me.Controls.Add(Me.B_Modify)
        Me.Controls.Add(Me.B_ADD)
        Me.Controls.Add(Me.T_TitleCode)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_TableTitle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_UpdateSQL As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_CLEAR As System.Windows.Forms.Button
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents B_BOT As System.Windows.Forms.Button
    Friend WithEvents B_NEXT As System.Windows.Forms.Button
    Friend WithEvents B_PREV As System.Windows.Forms.Button
    Friend WithEvents B_TOP As System.Windows.Forms.Button
    Friend WithEvents T_Title As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_Export As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Import As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents B_Delete As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Modify As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_ADD As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_TitleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
