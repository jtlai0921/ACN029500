<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Convert
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.L_DEPTNAME = New System.Windows.Forms.Label()
        Me.T_GRADE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_TITLE = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.T_DEPTCODE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_SEX = New System.Windows.Forms.GroupBox()
        Me.T_Woman = New System.Windows.Forms.RadioButton()
        Me.T_Man = New System.Windows.Forms.RadioButton()
        Me.T_FILEDATE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.B_Create = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.B_PrintBarCode = New System.Windows.Forms.Button()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.B_NPOI_READ = New System.Windows.Forms.Button()
        Me.B_NPOI_READ2 = New System.Windows.Forms.Button()
        Me.B_NPOI_WRITE = New System.Windows.Forms.Button()
        Me.B_EPPlus_Write = New System.Windows.Forms.Button()
        Me.B_EPPlus_Write2 = New System.Windows.Forms.Button()
        Me.B_EPPlus_Read = New System.Windows.Forms.Button()
        Me.B_01 = New System.Windows.Forms.Button()
        Me.B_02 = New System.Windows.Forms.Button()
        Me.B_03 = New System.Windows.Forms.Button()
        Me.B_05 = New System.Windows.Forms.Button()
        Me.B_Print1 = New System.Windows.Forms.Button()
        Me.B_Print2 = New System.Windows.Forms.Button()
        Me.B_Print3 = New System.Windows.Forms.Button()
        Me.B_RV = New System.Windows.Forms.Button()
        Me.B_RV_Hide = New System.Windows.Forms.Button()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_SEX.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.Navy
        Me.T_RecordNo.Location = New System.Drawing.Point(12, 338)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(189, 20)
        Me.T_RecordNo.TabIndex = 93
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'L_DEPTNAME
        '
        Me.L_DEPTNAME.AutoSize = True
        Me.L_DEPTNAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_DEPTNAME.ForeColor = System.Drawing.Color.Black
        Me.L_DEPTNAME.Location = New System.Drawing.Point(705, 594)
        Me.L_DEPTNAME.Name = "L_DEPTNAME"
        Me.L_DEPTNAME.Size = New System.Drawing.Size(0, 20)
        Me.L_DEPTNAME.TabIndex = 120
        '
        'T_GRADE
        '
        Me.T_GRADE.BackColor = System.Drawing.Color.White
        Me.T_GRADE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_GRADE.ForeColor = System.Drawing.Color.Navy
        Me.T_GRADE.FormattingEnabled = True
        Me.T_GRADE.IntegralHeight = False
        Me.T_GRADE.ItemHeight = 20
        Me.T_GRADE.Items.AddRange(New Object() {"02", "03", "04", "05", "05A", "06", "07", "07A", "07B", "07C", "07D", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.T_GRADE.Location = New System.Drawing.Point(826, 560)
        Me.T_GRADE.MaxDropDownItems = 7
        Me.T_GRADE.MaxLength = 3
        Me.T_GRADE.Name = "T_GRADE"
        Me.T_GRADE.Size = New System.Drawing.Size(80, 28)
        Me.T_GRADE.TabIndex = 124
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(783, 565)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "等級"
        '
        'T_TITLE
        '
        Me.T_TITLE.BackColor = System.Drawing.Color.White
        Me.T_TITLE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLE.ForeColor = System.Drawing.Color.Navy
        Me.T_TITLE.FormattingEnabled = True
        Me.T_TITLE.IntegralHeight = False
        Me.T_TITLE.ItemHeight = 20
        Me.T_TITLE.Items.AddRange(New Object() {"一等資材員", "一等管制員", "二等資材員", "二等機械員", "化驗員", "佐理員", "助理技術員", "助理採購員", "巡護員", "技工", "技術員", "秘書", "專案助理", "採購員", "勞工安衛管理員", "會計員", "業務代表", "業務員", "資材管制員", "資料處理員", "資料管理分析員", "資料管理員", "資深業務代表", "管制員", "操作助理", "操作員", "辦事員", "檢驗員", "營運規劃員", "醫務管理員", "關務員", "警衛", "護理員", "品保稽核", "副工程師", "專員", "勞工安衛管理師", "結構工程師", "結構助理工程師", "結構副工程師", "督導員", "資訊助理工程師", "資訊副工程師", "審核員", "工務長", "代工務長", "代值勤組長", "代組長", "代管制長", "值勤組長", "副組長", "組長", "管制長", "領工", "領班", "檢驗領班", "警衛組長", "警衛領班", "工程師", "化驗師", "資訊工程師", "維護工程師", "助理工程師", "資深資訊工程師", "研究員", "工務經理", "代值勤經理", "代副理", "代經理", "值勤經理", "副理", "經理", "主任", "代主任", "品管主任", "品管副主任", "副主任", "代協理", "協理", "處長", "廠長"})
        Me.T_TITLE.Location = New System.Drawing.Point(826, 528)
        Me.T_TITLE.MaxDropDownItems = 7
        Me.T_TITLE.MaxLength = 14
        Me.T_TITLE.Name = "T_TITLE"
        Me.T_TITLE.Size = New System.Drawing.Size(142, 28)
        Me.T_TITLE.TabIndex = 123
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(783, 534)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 20)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "職稱"
        '
        'T_DEPTCODE
        '
        Me.T_DEPTCODE.BackColor = System.Drawing.Color.White
        Me.T_DEPTCODE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPTCODE.ForeColor = System.Drawing.Color.Navy
        Me.T_DEPTCODE.FormattingEnabled = True
        Me.T_DEPTCODE.IntegralHeight = False
        Me.T_DEPTCODE.Items.AddRange(New Object() {"1100生產一部", "1200生產二部", "1300生產三部", "1400生產四部", "1500維護部", "1600資材部", "1700工程部", "1800職安部", "1900廠長室", "2100人事行政部", "2200會計部", "2300業務部", "2400資訊部", "2500研發部", "2600企劃部", "2900管理處長室", "3100品保部", "3200訓練部", "3300品檢部", "3900品管處長室"})
        Me.T_DEPTCODE.Location = New System.Drawing.Point(575, 560)
        Me.T_DEPTCODE.MaxDropDownItems = 7
        Me.T_DEPTCODE.MaxLength = 4
        Me.T_DEPTCODE.Name = "T_DEPTCODE"
        Me.T_DEPTCODE.Size = New System.Drawing.Size(150, 28)
        Me.T_DEPTCODE.TabIndex = 122
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(532, 565)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "部門"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(532, 612)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "性別"
        '
        'T_SEX
        '
        Me.T_SEX.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.T_SEX.Controls.Add(Me.T_Woman)
        Me.T_SEX.Controls.Add(Me.T_Man)
        Me.T_SEX.Location = New System.Drawing.Point(575, 593)
        Me.T_SEX.Name = "T_SEX"
        Me.T_SEX.Size = New System.Drawing.Size(105, 46)
        Me.T_SEX.TabIndex = 125
        Me.T_SEX.TabStop = False
        '
        'T_Woman
        '
        Me.T_Woman.AutoSize = True
        Me.T_Woman.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.T_Woman.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Woman.ForeColor = System.Drawing.Color.Black
        Me.T_Woman.Location = New System.Drawing.Point(59, 17)
        Me.T_Woman.Name = "T_Woman"
        Me.T_Woman.Size = New System.Drawing.Size(43, 24)
        Me.T_Woman.TabIndex = 8
        Me.T_Woman.Text = "女"
        Me.T_Woman.UseVisualStyleBackColor = False
        '
        'T_Man
        '
        Me.T_Man.AutoSize = True
        Me.T_Man.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.T_Man.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Man.ForeColor = System.Drawing.Color.Black
        Me.T_Man.Location = New System.Drawing.Point(7, 17)
        Me.T_Man.Name = "T_Man"
        Me.T_Man.Size = New System.Drawing.Size(43, 24)
        Me.T_Man.TabIndex = 7
        Me.T_Man.Text = "男"
        Me.T_Man.UseVisualStyleBackColor = False
        '
        'T_FILEDATE
        '
        Me.T_FILEDATE.BackColor = System.Drawing.Color.White
        Me.T_FILEDATE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_FILEDATE.ForeColor = System.Drawing.Color.Navy
        Me.T_FILEDATE.FormattingEnabled = True
        Me.T_FILEDATE.IntegralHeight = False
        Me.T_FILEDATE.Items.AddRange(New Object() {"201412", "201411", "201410", "201409", "201408", "201407", "201406", "201405", "201404", "201403", "201402", "201401"})
        Me.T_FILEDATE.Location = New System.Drawing.Point(575, 528)
        Me.T_FILEDATE.MaxDropDownItems = 7
        Me.T_FILEDATE.MaxLength = 4
        Me.T_FILEDATE.Name = "T_FILEDATE"
        Me.T_FILEDATE.Size = New System.Drawing.Size(102, 28)
        Me.T_FILEDATE.TabIndex = 131
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(532, 534)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "日期"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(520, 7)
        Me.ReportViewer1.Name = "ReportViewer"
        Me.ReportViewer1.ShowPrintButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(460, 480)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.ZoomPercent = 70
        '
        'B_Create
        '
        Me.B_Create.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.B_Create.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Create.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Create.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Create.Location = New System.Drawing.Point(264, 577)
        Me.B_Create.Name = "B_Create"
        Me.B_Create.Size = New System.Drawing.Size(90, 32)
        Me.B_Create.TabIndex = 138
        Me.B_Create.Text = "產生條碼 "
        Me.B_Create.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 620)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "條碼"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Black
        Me.TextBox2.Location = New System.Drawing.Point(48, 613)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(210, 33)
        Me.TextBox2.TabIndex = 135
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 583)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "代號"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(48, 576)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(210, 33)
        Me.TextBox1.TabIndex = 134
        '
        'B_PrintBarCode
        '
        Me.B_PrintBarCode.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.B_PrintBarCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_PrintBarCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_PrintBarCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_PrintBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PrintBarCode.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PrintBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_PrintBarCode.Location = New System.Drawing.Point(264, 614)
        Me.B_PrintBarCode.Name = "B_PrintBarCode"
        Me.B_PrintBarCode.Size = New System.Drawing.Size(90, 32)
        Me.B_PrintBarCode.TabIndex = 139
        Me.B_PrintBarCode.Text = "列印條碼 "
        Me.B_PrintBarCode.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.MediumVioletRed
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(884, 610)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(84, 36)
        Me.B_Close.TabIndex = 140
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(794, 610)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(84, 36)
        Me.B_Reset.TabIndex = 141
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
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
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(8, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(500, 320)
        Me.DataGridView1.TabIndex = 142
        '
        'B_NPOI_READ
        '
        Me.B_NPOI_READ.BackColor = System.Drawing.Color.LightCyan
        Me.B_NPOI_READ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_NPOI_READ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_NPOI_READ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_NPOI_READ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NPOI_READ.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_NPOI_READ.ForeColor = System.Drawing.Color.Black
        Me.B_NPOI_READ.Location = New System.Drawing.Point(8, 385)
        Me.B_NPOI_READ.Name = "B_NPOI_READ"
        Me.B_NPOI_READ.Size = New System.Drawing.Size(118, 36)
        Me.B_NPOI_READ.TabIndex = 143
        Me.B_NPOI_READ.Text = "NPOI 讀取 1"
        Me.B_NPOI_READ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_NPOI_READ.UseVisualStyleBackColor = False
        '
        'B_NPOI_READ2
        '
        Me.B_NPOI_READ2.BackColor = System.Drawing.Color.LightCyan
        Me.B_NPOI_READ2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_NPOI_READ2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_NPOI_READ2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_NPOI_READ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NPOI_READ2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_NPOI_READ2.ForeColor = System.Drawing.Color.Black
        Me.B_NPOI_READ2.Location = New System.Drawing.Point(8, 428)
        Me.B_NPOI_READ2.Name = "B_NPOI_READ2"
        Me.B_NPOI_READ2.Size = New System.Drawing.Size(118, 36)
        Me.B_NPOI_READ2.TabIndex = 144
        Me.B_NPOI_READ2.Text = "NPOI 讀取 1"
        Me.B_NPOI_READ2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_NPOI_READ2.UseVisualStyleBackColor = False
        '
        'B_NPOI_WRITE
        '
        Me.B_NPOI_WRITE.BackColor = System.Drawing.Color.LightCyan
        Me.B_NPOI_WRITE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_NPOI_WRITE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_NPOI_WRITE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_NPOI_WRITE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NPOI_WRITE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_NPOI_WRITE.ForeColor = System.Drawing.Color.Black
        Me.B_NPOI_WRITE.Location = New System.Drawing.Point(8, 471)
        Me.B_NPOI_WRITE.Name = "B_NPOI_WRITE"
        Me.B_NPOI_WRITE.Size = New System.Drawing.Size(118, 36)
        Me.B_NPOI_WRITE.TabIndex = 145
        Me.B_NPOI_WRITE.Text = "NPOI 寫入"
        Me.B_NPOI_WRITE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_NPOI_WRITE.UseVisualStyleBackColor = False
        '
        'B_EPPlus_Write
        '
        Me.B_EPPlus_Write.BackColor = System.Drawing.Color.Linen
        Me.B_EPPlus_Write.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Write.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Write.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EPPlus_Write.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_EPPlus_Write.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Write.Location = New System.Drawing.Point(136, 385)
        Me.B_EPPlus_Write.Name = "B_EPPlus_Write"
        Me.B_EPPlus_Write.Size = New System.Drawing.Size(118, 36)
        Me.B_EPPlus_Write.TabIndex = 146
        Me.B_EPPlus_Write.Text = "EPPlus 寫入 1"
        Me.B_EPPlus_Write.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_EPPlus_Write.UseVisualStyleBackColor = False
        '
        'B_EPPlus_Write2
        '
        Me.B_EPPlus_Write2.BackColor = System.Drawing.Color.Linen
        Me.B_EPPlus_Write2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Write2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Write2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Write2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EPPlus_Write2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_EPPlus_Write2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Write2.Location = New System.Drawing.Point(136, 428)
        Me.B_EPPlus_Write2.Name = "B_EPPlus_Write2"
        Me.B_EPPlus_Write2.Size = New System.Drawing.Size(118, 36)
        Me.B_EPPlus_Write2.TabIndex = 147
        Me.B_EPPlus_Write2.Text = "EPPlus 寫入 2"
        Me.B_EPPlus_Write2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_EPPlus_Write2.UseVisualStyleBackColor = False
        '
        'B_EPPlus_Read
        '
        Me.B_EPPlus_Read.BackColor = System.Drawing.Color.Linen
        Me.B_EPPlus_Read.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Read.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Read.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_EPPlus_Read.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_EPPlus_Read.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_EPPlus_Read.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_EPPlus_Read.Location = New System.Drawing.Point(136, 472)
        Me.B_EPPlus_Read.Name = "B_EPPlus_Read"
        Me.B_EPPlus_Read.Size = New System.Drawing.Size(118, 36)
        Me.B_EPPlus_Read.TabIndex = 148
        Me.B_EPPlus_Read.Text = "EPPlus 讀取"
        Me.B_EPPlus_Read.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_EPPlus_Read.UseVisualStyleBackColor = False
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.B_01.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_01.Location = New System.Drawing.Point(264, 385)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(126, 36)
        Me.B_01.TabIndex = 149
        Me.B_01.Text = "GemBox 讀取"
        Me.B_01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_01.UseVisualStyleBackColor = False
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.B_02.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_02.Location = New System.Drawing.Point(264, 428)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(126, 36)
        Me.B_02.TabIndex = 150
        Me.B_02.Text = "GemBox 寫入"
        Me.B_02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_02.UseVisualStyleBackColor = False
        '
        'B_03
        '
        Me.B_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.B_03.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_03.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_03.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_03.Location = New System.Drawing.Point(264, 472)
        Me.B_03.Name = "B_03"
        Me.B_03.Size = New System.Drawing.Size(126, 36)
        Me.B_03.TabIndex = 151
        Me.B_03.Text = "GemBox 繪圖"
        Me.B_03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_03.UseVisualStyleBackColor = False
        '
        'B_05
        '
        Me.B_05.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.B_05.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_05.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_05.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_05.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_05.Location = New System.Drawing.Point(264, 514)
        Me.B_05.Name = "B_05"
        Me.B_05.Size = New System.Drawing.Size(126, 36)
        Me.B_05.TabIndex = 152
        Me.B_05.Text = "GemBox 匯出"
        Me.B_05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_05.UseVisualStyleBackColor = False
        '
        'B_Print1
        '
        Me.B_Print1.BackColor = System.Drawing.Color.Khaki
        Me.B_Print1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_Print1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Print1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Print1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Print1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Print1.ForeColor = System.Drawing.Color.Black
        Me.B_Print1.Location = New System.Drawing.Point(400, 385)
        Me.B_Print1.Name = "B_Print1"
        Me.B_Print1.Size = New System.Drawing.Size(102, 36)
        Me.B_Print1.TabIndex = 153
        Me.B_Print1.Text = "列印 1"
        Me.B_Print1.UseVisualStyleBackColor = False
        '
        'B_Print2
        '
        Me.B_Print2.BackColor = System.Drawing.Color.Khaki
        Me.B_Print2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_Print2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Print2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Print2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Print2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Print2.ForeColor = System.Drawing.Color.Black
        Me.B_Print2.Location = New System.Drawing.Point(400, 428)
        Me.B_Print2.Name = "B_Print2"
        Me.B_Print2.Size = New System.Drawing.Size(102, 36)
        Me.B_Print2.TabIndex = 154
        Me.B_Print2.Text = "列印 2"
        Me.B_Print2.UseVisualStyleBackColor = False
        '
        'B_Print3
        '
        Me.B_Print3.BackColor = System.Drawing.Color.Khaki
        Me.B_Print3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.B_Print3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Print3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Print3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Print3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Print3.ForeColor = System.Drawing.Color.Black
        Me.B_Print3.Location = New System.Drawing.Point(400, 472)
        Me.B_Print3.Name = "B_Print3"
        Me.B_Print3.Size = New System.Drawing.Size(102, 36)
        Me.B_Print3.TabIndex = 155
        Me.B_Print3.Text = "列印 3"
        Me.B_Print3.UseVisualStyleBackColor = False
        '
        'B_RV
        '
        Me.B_RV.BackColor = System.Drawing.Color.PeachPuff
        Me.B_RV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_RV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_RV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_RV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_RV.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_RV.ForeColor = System.Drawing.Color.Red
        Me.B_RV.Location = New System.Drawing.Point(400, 514)
        Me.B_RV.Name = "B_RV"
        Me.B_RV.Size = New System.Drawing.Size(102, 36)
        Me.B_RV.TabIndex = 156
        Me.B_RV.Text = "報表檢視器"
        Me.B_RV.UseVisualStyleBackColor = False
        '
        'B_RV_Hide
        '
        Me.B_RV_Hide.BackColor = System.Drawing.Color.PeachPuff
        Me.B_RV_Hide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_RV_Hide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_RV_Hide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_RV_Hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_RV_Hide.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_RV_Hide.ForeColor = System.Drawing.Color.Red
        Me.B_RV_Hide.Location = New System.Drawing.Point(400, 556)
        Me.B_RV_Hide.Name = "B_RV_Hide"
        Me.B_RV_Hide.Size = New System.Drawing.Size(102, 36)
        Me.B_RV_Hide.TabIndex = 157
        Me.B_RV_Hide.Text = "隱藏檢視器"
        Me.B_RV_Hide.UseVisualStyleBackColor = False
        '
        'F_Convert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_RV_Hide)
        Me.Controls.Add(Me.B_RV)
        Me.Controls.Add(Me.B_Print3)
        Me.Controls.Add(Me.B_Print2)
        Me.Controls.Add(Me.B_Print1)
        Me.Controls.Add(Me.B_05)
        Me.Controls.Add(Me.B_03)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.B_01)
        Me.Controls.Add(Me.B_EPPlus_Read)
        Me.Controls.Add(Me.B_EPPlus_Write2)
        Me.Controls.Add(Me.B_EPPlus_Write)
        Me.Controls.Add(Me.B_NPOI_WRITE)
        Me.Controls.Add(Me.B_NPOI_READ2)
        Me.Controls.Add(Me.B_NPOI_READ)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_PrintBarCode)
        Me.Controls.Add(Me.B_Create)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.T_FILEDATE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_GRADE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_TITLE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.T_DEPTCODE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_SEX)
        Me.Controls.Add(Me.L_DEPTNAME)
        Me.Controls.Add(Me.T_RecordNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Convert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_SEX.ResumeLayout(False)
        Me.T_SEX.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents L_DEPTNAME As System.Windows.Forms.Label
    Friend WithEvents T_GRADE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_TITLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents T_DEPTCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_SEX As System.Windows.Forms.GroupBox
    Friend WithEvents T_Woman As System.Windows.Forms.RadioButton
    Friend WithEvents T_Man As System.Windows.Forms.RadioButton
    Friend WithEvents T_FILEDATE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents B_Create As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents B_PrintBarCode As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents B_NPOI_READ As System.Windows.Forms.Button
    Friend WithEvents B_NPOI_READ2 As System.Windows.Forms.Button
    Friend WithEvents B_NPOI_WRITE As System.Windows.Forms.Button
    Friend WithEvents B_EPPlus_Write As System.Windows.Forms.Button
    Friend WithEvents B_EPPlus_Write2 As System.Windows.Forms.Button
    Friend WithEvents B_EPPlus_Read As System.Windows.Forms.Button
    Friend WithEvents B_01 As System.Windows.Forms.Button
    Friend WithEvents B_02 As System.Windows.Forms.Button
    Friend WithEvents B_03 As System.Windows.Forms.Button
    Friend WithEvents B_05 As System.Windows.Forms.Button
    Friend WithEvents B_Print1 As System.Windows.Forms.Button
    Friend WithEvents B_Print2 As System.Windows.Forms.Button
    Friend WithEvents B_Print3 As System.Windows.Forms.Button
    Friend WithEvents B_RV As System.Windows.Forms.Button
    Friend WithEvents B_RV_Hide As System.Windows.Forms.Button
End Class
