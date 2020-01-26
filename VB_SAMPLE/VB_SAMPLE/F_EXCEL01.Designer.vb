<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_EXCEL01
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.T_cost = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_qty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_itemname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_sno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_CreateDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_SheetName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_Count = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_FileName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_country = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.T_topics = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.T_purdate = New VB_SAMPLE.MyClass_Calendar()
        Me.B_EXPORT5 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_EXPORT4 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_EXPORT3 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_EXPORT2 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_IMPORT03 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_SelectNone = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_SelectALL = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Remove = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_IMPORT02 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_EXPORT1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Delete = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Modify = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_ADD = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_IMPORT01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonClose()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.Navy
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_RecordNo.Location = New System.Drawing.Point(9, 241)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(201, 22)
        Me.T_RecordNo.TabIndex = 71
        '
        'T_cost
        '
        Me.T_cost.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_cost.ForeColor = System.Drawing.Color.Black
        Me.T_cost.Location = New System.Drawing.Point(626, 413)
        Me.T_cost.MaxLength = 0
        Me.T_cost.Name = "T_cost"
        Me.T_cost.Size = New System.Drawing.Size(119, 29)
        Me.T_cost.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(550, 418)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "購入價格"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_qty
        '
        Me.T_qty.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_qty.ForeColor = System.Drawing.Color.Black
        Me.T_qty.Location = New System.Drawing.Point(445, 413)
        Me.T_qty.MaxLength = 0
        Me.T_qty.Name = "T_qty"
        Me.T_qty.Size = New System.Drawing.Size(71, 29)
        Me.T_qty.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(401, 418)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "數量"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_itemname
        '
        Me.T_itemname.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_itemname.ForeColor = System.Drawing.Color.Black
        Me.T_itemname.Location = New System.Drawing.Point(445, 368)
        Me.T_itemname.MaxLength = 30
        Me.T_itemname.Name = "T_itemname"
        Me.T_itemname.Size = New System.Drawing.Size(300, 29)
        Me.T_itemname.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(370, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "郵票名稱"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_sno
        '
        Me.T_sno.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_sno.ForeColor = System.Drawing.Color.Black
        Me.T_sno.Location = New System.Drawing.Point(445, 323)
        Me.T_sno.MaxLength = 4
        Me.T_sno.Name = "T_sno"
        Me.T_sno.Size = New System.Drawing.Size(71, 29)
        Me.T_sno.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(402, 327)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "編號"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_CreateDate
        '
        Me.T_CreateDate.BackColor = System.Drawing.Color.Navy
        Me.T_CreateDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_CreateDate.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_CreateDate.ForeColor = System.Drawing.Color.White
        Me.T_CreateDate.Location = New System.Drawing.Point(99, 341)
        Me.T_CreateDate.MaxLength = 12
        Me.T_CreateDate.Name = "T_CreateDate"
        Me.T_CreateDate.ReadOnly = True
        Me.T_CreateDate.Size = New System.Drawing.Size(200, 20)
        Me.T_CreateDate.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(7, 343)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "檔案產生日"
        '
        'T_SheetName
        '
        Me.T_SheetName.BackColor = System.Drawing.Color.Navy
        Me.T_SheetName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_SheetName.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SheetName.ForeColor = System.Drawing.Color.White
        Me.T_SheetName.Location = New System.Drawing.Point(99, 311)
        Me.T_SheetName.MaxLength = 20
        Me.T_SheetName.Name = "T_SheetName"
        Me.T_SheetName.ReadOnly = True
        Me.T_SheetName.Size = New System.Drawing.Size(120, 20)
        Me.T_SheetName.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(7, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 20)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "工作表名稱"
        '
        'T_Count
        '
        Me.T_Count.BackColor = System.Drawing.Color.Navy
        Me.T_Count.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_Count.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Count.ForeColor = System.Drawing.Color.White
        Me.T_Count.Location = New System.Drawing.Point(99, 371)
        Me.T_Count.MaxLength = 12
        Me.T_Count.Name = "T_Count"
        Me.T_Count.ReadOnly = True
        Me.T_Count.Size = New System.Drawing.Size(96, 20)
        Me.T_Count.TabIndex = 79
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(39, 372)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "資料量"
        '
        'T_FileName
        '
        Me.T_FileName.BackColor = System.Drawing.Color.Navy
        Me.T_FileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_FileName.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_FileName.ForeColor = System.Drawing.Color.White
        Me.T_FileName.Location = New System.Drawing.Point(99, 283)
        Me.T_FileName.MaxLength = 20
        Me.T_FileName.Name = "T_FileName"
        Me.T_FileName.ReadOnly = True
        Me.T_FileName.Size = New System.Drawing.Size(500, 20)
        Me.T_FileName.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(23, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "檔案名稱"
        '
        'T_country
        '
        Me.T_country.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_country.ForeColor = System.Drawing.Color.Black
        Me.T_country.Location = New System.Drawing.Point(650, 323)
        Me.T_country.MaxLength = 10
        Me.T_country.Name = "T_country"
        Me.T_country.Size = New System.Drawing.Size(95, 29)
        Me.T_country.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(606, 327)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 20)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "國家"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(763, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "專題類別"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(763, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 96
        Me.Label11.Text = "購入時間"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_topics
        '
        Me.T_topics.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_topics.ForeColor = System.Drawing.Color.Black
        Me.T_topics.FormattingEnabled = True
        Me.T_topics.Items.AddRange(New Object() {"水果", "昆蟲", "風景", "動物", "鳥類", "民俗", "花卉", "飛機", "人物", "名畫", "名著", "傳說", "遺產", "戲劇"})
        Me.T_topics.Location = New System.Drawing.Point(838, 323)
        Me.T_topics.Name = "T_topics"
        Me.T_topics.Size = New System.Drawing.Size(102, 28)
        Me.T_topics.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(518, 330)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "例如 A099"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'T_purdate
        '
        Me.T_purdate.BackColor = System.Drawing.Color.White
        Me.T_purdate.CalendarFont = New System.Drawing.Font("微軟正黑體", 11.0!)
        Me.T_purdate.CalendarForeColor = System.Drawing.Color.Navy
        Me.T_purdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.T_purdate.CalendarTitleBackColor = System.Drawing.Color.DarkBlue
        Me.T_purdate.CalendarTitleForeColor = System.Drawing.Color.White
        Me.T_purdate.CalendarTrailingForeColor = System.Drawing.Color.Brown
        Me.T_purdate.Font = New System.Drawing.Font("微軟正黑體", 11.0!)
        Me.T_purdate.ForeColor = System.Drawing.Color.Navy
        Me.T_purdate.Location = New System.Drawing.Point(838, 368)
        Me.T_purdate.Name = "T_purdate"
        Me.T_purdate.Size = New System.Drawing.Size(140, 27)
        Me.T_purdate.TabIndex = 97
        Me.T_purdate.Value = New Date(2015, 5, 1, 0, 0, 0, 0)
        '
        'B_EXPORT5
        '
        Me.B_EXPORT5.BackColor = System.Drawing.Color.DarkKhaki
        Me.B_EXPORT5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_EXPORT5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EXPORT5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EXPORT5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EXPORT5.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_EXPORT5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_EXPORT5.Location = New System.Drawing.Point(242, 561)
        Me.B_EXPORT5.Name = "B_EXPORT5"
        Me.B_EXPORT5.Size = New System.Drawing.Size(102, 36)
        Me.B_EXPORT5.TabIndex = 91
        Me.B_EXPORT5.Text = "轉 檔 2"
        Me.B_EXPORT5.UseVisualStyleBackColor = False
        '
        'B_EXPORT4
        '
        Me.B_EXPORT4.BackColor = System.Drawing.Color.DarkKhaki
        Me.B_EXPORT4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_EXPORT4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EXPORT4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EXPORT4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EXPORT4.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_EXPORT4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_EXPORT4.Location = New System.Drawing.Point(242, 518)
        Me.B_EXPORT4.Name = "B_EXPORT4"
        Me.B_EXPORT4.Size = New System.Drawing.Size(102, 36)
        Me.B_EXPORT4.TabIndex = 90
        Me.B_EXPORT4.Text = "轉 檔 1"
        Me.B_EXPORT4.UseVisualStyleBackColor = False
        '
        'B_EXPORT3
        '
        Me.B_EXPORT3.BackColor = System.Drawing.Color.MediumAquamarine
        Me.B_EXPORT3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_EXPORT3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EXPORT3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EXPORT3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EXPORT3.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_EXPORT3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EXPORT3.Location = New System.Drawing.Point(131, 604)
        Me.B_EXPORT3.Name = "B_EXPORT3"
        Me.B_EXPORT3.Size = New System.Drawing.Size(102, 36)
        Me.B_EXPORT3.TabIndex = 88
        Me.B_EXPORT3.Text = "匯 出 3"
        Me.B_EXPORT3.UseVisualStyleBackColor = False
        '
        'B_EXPORT2
        '
        Me.B_EXPORT2.BackColor = System.Drawing.Color.MediumAquamarine
        Me.B_EXPORT2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_EXPORT2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EXPORT2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EXPORT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EXPORT2.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_EXPORT2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EXPORT2.Location = New System.Drawing.Point(131, 561)
        Me.B_EXPORT2.Name = "B_EXPORT2"
        Me.B_EXPORT2.Size = New System.Drawing.Size(102, 36)
        Me.B_EXPORT2.TabIndex = 87
        Me.B_EXPORT2.Text = "匯 出 2"
        Me.B_EXPORT2.UseVisualStyleBackColor = False
        '
        'B_IMPORT03
        '
        Me.B_IMPORT03.BackColor = System.Drawing.Color.SkyBlue
        Me.B_IMPORT03.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_IMPORT03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_IMPORT03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_IMPORT03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_IMPORT03.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_IMPORT03.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_IMPORT03.Location = New System.Drawing.Point(20, 604)
        Me.B_IMPORT03.Name = "B_IMPORT03"
        Me.B_IMPORT03.Size = New System.Drawing.Size(102, 36)
        Me.B_IMPORT03.TabIndex = 86
        Me.B_IMPORT03.Text = "匯入 3"
        Me.B_IMPORT03.UseVisualStyleBackColor = False
        '
        'B_SelectNone
        '
        Me.B_SelectNone.BackColor = System.Drawing.Color.Teal
        Me.B_SelectNone.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_SelectNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_SelectNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_SelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_SelectNone.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_SelectNone.ForeColor = System.Drawing.Color.White
        Me.B_SelectNone.Location = New System.Drawing.Point(866, 197)
        Me.B_SelectNone.Name = "B_SelectNone"
        Me.B_SelectNone.Size = New System.Drawing.Size(96, 36)
        Me.B_SelectNone.TabIndex = 85
        Me.B_SelectNone.Text = "全不選"
        Me.B_SelectNone.UseVisualStyleBackColor = False
        '
        'B_SelectALL
        '
        Me.B_SelectALL.BackColor = System.Drawing.Color.Teal
        Me.B_SelectALL.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_SelectALL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_SelectALL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_SelectALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_SelectALL.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_SelectALL.ForeColor = System.Drawing.Color.White
        Me.B_SelectALL.Location = New System.Drawing.Point(866, 146)
        Me.B_SelectALL.Name = "B_SelectALL"
        Me.B_SelectALL.Size = New System.Drawing.Size(96, 36)
        Me.B_SelectALL.TabIndex = 84
        Me.B_SelectALL.Text = "全 選"
        Me.B_SelectALL.UseVisualStyleBackColor = False
        '
        'B_Remove
        '
        Me.B_Remove.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Remove.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Remove.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Remove.ForeColor = System.Drawing.Color.White
        Me.B_Remove.Location = New System.Drawing.Point(866, 12)
        Me.B_Remove.Name = "B_Remove"
        Me.B_Remove.Size = New System.Drawing.Size(96, 36)
        Me.B_Remove.TabIndex = 83
        Me.B_Remove.Text = "移 除"
        Me.B_Remove.UseVisualStyleBackColor = False
        '
        'B_IMPORT02
        '
        Me.B_IMPORT02.BackColor = System.Drawing.Color.SkyBlue
        Me.B_IMPORT02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_IMPORT02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_IMPORT02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_IMPORT02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_IMPORT02.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_IMPORT02.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_IMPORT02.Location = New System.Drawing.Point(20, 561)
        Me.B_IMPORT02.Name = "B_IMPORT02"
        Me.B_IMPORT02.Size = New System.Drawing.Size(102, 36)
        Me.B_IMPORT02.TabIndex = 80
        Me.B_IMPORT02.Text = "匯入 2"
        Me.B_IMPORT02.UseVisualStyleBackColor = False
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
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
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
        Me.DataGridView1.Location = New System.Drawing.Point(8, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(852, 221)
        Me.DataGridView1.TabIndex = 73
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.SteelBlue
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(838, 413)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(96, 30)
        Me.B_Reset.TabIndex = 72
        Me.B_Reset.Text = "清空文字盒"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_EXPORT1
        '
        Me.B_EXPORT1.BackColor = System.Drawing.Color.MediumAquamarine
        Me.B_EXPORT1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_EXPORT1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EXPORT1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EXPORT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EXPORT1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_EXPORT1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EXPORT1.Location = New System.Drawing.Point(131, 518)
        Me.B_EXPORT1.Name = "B_EXPORT1"
        Me.B_EXPORT1.Size = New System.Drawing.Size(102, 36)
        Me.B_EXPORT1.TabIndex = 65
        Me.B_EXPORT1.Text = "匯 出 1"
        Me.B_EXPORT1.UseVisualStyleBackColor = False
        '
        'B_Delete
        '
        Me.B_Delete.BackColor = System.Drawing.Color.Tan
        Me.B_Delete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Delete.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Delete.Location = New System.Drawing.Point(353, 604)
        Me.B_Delete.Name = "B_Delete"
        Me.B_Delete.Size = New System.Drawing.Size(102, 36)
        Me.B_Delete.TabIndex = 62
        Me.B_Delete.Text = "刪 除"
        Me.B_Delete.UseVisualStyleBackColor = False
        '
        'B_Modify
        '
        Me.B_Modify.BackColor = System.Drawing.Color.Tan
        Me.B_Modify.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Modify.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Modify.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Modify.Location = New System.Drawing.Point(353, 561)
        Me.B_Modify.Name = "B_Modify"
        Me.B_Modify.Size = New System.Drawing.Size(102, 36)
        Me.B_Modify.TabIndex = 61
        Me.B_Modify.Text = "修 改"
        Me.B_Modify.UseVisualStyleBackColor = False
        '
        'B_ADD
        '
        Me.B_ADD.BackColor = System.Drawing.Color.Tan
        Me.B_ADD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ADD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_ADD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ADD.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_ADD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_ADD.Location = New System.Drawing.Point(353, 518)
        Me.B_ADD.Name = "B_ADD"
        Me.B_ADD.Size = New System.Drawing.Size(102, 36)
        Me.B_ADD.TabIndex = 60
        Me.B_ADD.Text = "新 增"
        Me.B_ADD.UseVisualStyleBackColor = False
        '
        'B_IMPORT01
        '
        Me.B_IMPORT01.BackColor = System.Drawing.Color.SkyBlue
        Me.B_IMPORT01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_IMPORT01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_IMPORT01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_IMPORT01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_IMPORT01.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_IMPORT01.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_IMPORT01.Location = New System.Drawing.Point(20, 518)
        Me.B_IMPORT01.Name = "B_IMPORT01"
        Me.B_IMPORT01.Size = New System.Drawing.Size(102, 36)
        Me.B_IMPORT01.TabIndex = 59
        Me.B_IMPORT01.Text = "匯入 1"
        Me.B_IMPORT01.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.LightPink
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Close.Location = New System.Drawing.Point(242, 604)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 51
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'F_EXCEL01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.T_purdate)
        Me.Controls.Add(Me.T_topics)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.T_country)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.B_EXPORT5)
        Me.Controls.Add(Me.B_EXPORT4)
        Me.Controls.Add(Me.B_EXPORT3)
        Me.Controls.Add(Me.B_EXPORT2)
        Me.Controls.Add(Me.B_IMPORT03)
        Me.Controls.Add(Me.B_SelectNone)
        Me.Controls.Add(Me.B_SelectALL)
        Me.Controls.Add(Me.B_Remove)
        Me.Controls.Add(Me.T_FileName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.B_IMPORT02)
        Me.Controls.Add(Me.T_Count)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_CreateDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.T_cost)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_qty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.B_EXPORT1)
        Me.Controls.Add(Me.B_Delete)
        Me.Controls.Add(Me.B_Modify)
        Me.Controls.Add(Me.B_ADD)
        Me.Controls.Add(Me.B_IMPORT01)
        Me.Controls.Add(Me.T_itemname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_sno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_EXCEL01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents T_cost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_qty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_EXPORT1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Delete As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Modify As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_ADD As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_IMPORT01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_itemname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_sno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents T_CreateDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_SheetName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_Count As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents B_IMPORT02 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_FileName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents B_Remove As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_SelectALL As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_SelectNone As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_IMPORT03 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_EXPORT2 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_EXPORT3 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_EXPORT4 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_EXPORT5 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_country As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents T_topics As System.Windows.Forms.ComboBox
    Friend WithEvents T_purdate As VB_SAMPLE.MyClass_Calendar
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
