<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Query
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.T_TITLE = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.L_DEPTNAME = New System.Windows.Forms.Label()
        Me.T_DEPTCODE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_SEX = New System.Windows.Forms.GroupBox()
        Me.T_Woman = New System.Windows.Forms.RadioButton()
        Me.T_Man = New System.Windows.Forms.RadioButton()
        Me.T_ENO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_GRADE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_SUBTOTAL = New System.Windows.Forms.GroupBox()
        Me.T_S4 = New System.Windows.Forms.RadioButton()
        Me.T_S3 = New System.Windows.Forms.RadioButton()
        Me.T_S2 = New System.Windows.Forms.RadioButton()
        Me.T_S1 = New System.Windows.Forms.RadioButton()
        Me.T_Path = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.T_MATCH3 = New System.Windows.Forms.RadioButton()
        Me.T_MATCH2 = New System.Windows.Forms.RadioButton()
        Me.T_MATCH = New System.Windows.Forms.GroupBox()
        Me.T_MATCH1 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.B_PickUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_Query = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_GiveUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Remove = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Select = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_SEX.SuspendLayout()
        Me.T_SUBTOTAL.SuspendLayout()
        Me.T_MATCH.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(353, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "已選日期"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(37, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "可選日期"
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.White
        Me.ListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.Navy
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.IntegralHeight = False
        Me.ListBox2.ItemHeight = 24
        Me.ListBox2.Location = New System.Drawing.Point(356, 43)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox2.Size = New System.Drawing.Size(120, 172)
        Me.ListBox2.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Navy
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Items.AddRange(New Object() {"201412", "201411", "201410", "201409", "201408", "201407", "201406", "201405", "201404", "201403", "201402", "201401"})
        Me.ListBox1.Location = New System.Drawing.Point(40, 43)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(120, 172)
        Me.ListBox1.TabIndex = 1
        '
        'T_TITLE
        '
        Me.T_TITLE.BackColor = System.Drawing.Color.White
        Me.T_TITLE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLE.ForeColor = System.Drawing.Color.Navy
        Me.T_TITLE.FormattingEnabled = True
        Me.T_TITLE.IntegralHeight = False
        Me.T_TITLE.ItemHeight = 24
        Me.T_TITLE.Items.AddRange(New Object() {"一等資材員", "一等管制員", "二等資材員", "二等機械員", "化驗員", "佐理員", "助理技術員", "助理採購員", "巡護員", "技工", "技術員", "秘書", "專案助理", "採購員", "勞工安衛管理員", "會計員", "業務代表", "業務員", "資材管制員", "資料處理員", "資料管理分析員", "資料管理員", "資深業務代表", "管制員", "操作助理", "操作員", "辦事員", "檢驗員", "營運規劃員", "醫務管理員", "關務員", "警衛", "護理員", "品保稽核", "副工程師", "專員", "勞工安衛管理師", "結構工程師", "結構助理工程師", "結構副工程師", "督導員", "資訊助理工程師", "資訊副工程師", "審核員", "工務長", "代工務長", "代值勤組長", "代組長", "代管制長", "值勤組長", "副組長", "組長", "管制長", "領工", "領班", "檢驗領班", "警衛組長", "警衛領班", "工程師", "化驗師", "資訊工程師", "維護工程師", "助理工程師", "資深資訊工程師", "研究員", "工務經理", "代值勤經理", "代副理", "代經理", "值勤經理", "副理", "經理", "主任", "代主任", "品管主任", "品管副主任", "副主任", "代協理", "協理", "處長", "廠長"})
        Me.T_TITLE.Location = New System.Drawing.Point(713, 176)
        Me.T_TITLE.MaxDropDownItems = 7
        Me.T_TITLE.MaxLength = 14
        Me.T_TITLE.Name = "T_TITLE"
        Me.T_TITLE.Size = New System.Drawing.Size(168, 32)
        Me.T_TITLE.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(662, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 24)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "職稱"
        '
        'L_DEPTNAME
        '
        Me.L_DEPTNAME.AutoSize = True
        Me.L_DEPTNAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_DEPTNAME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.L_DEPTNAME.Location = New System.Drawing.Point(904, 92)
        Me.L_DEPTNAME.Name = "L_DEPTNAME"
        Me.L_DEPTNAME.Size = New System.Drawing.Size(0, 20)
        Me.L_DEPTNAME.TabIndex = 41
        '
        'T_DEPTCODE
        '
        Me.T_DEPTCODE.BackColor = System.Drawing.Color.White
        Me.T_DEPTCODE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPTCODE.ForeColor = System.Drawing.Color.Navy
        Me.T_DEPTCODE.FormattingEnabled = True
        Me.T_DEPTCODE.IntegralHeight = False
        Me.T_DEPTCODE.Items.AddRange(New Object() {"1100生產一部", "1200生產二部", "1300生產三部", "1400生產四部", "1500維護部", "1600資材部", "1700工程部", "1800職安部", "1900廠長室", "2100人事行政部", "2200會計部", "2300業務部", "2400資訊部", "2500研發部", "2600企劃部", "2900管理處長室", "3100品保部", "3200訓練部", "3300品檢部", "3900品管處長室"})
        Me.T_DEPTCODE.Location = New System.Drawing.Point(713, 84)
        Me.T_DEPTCODE.MaxDropDownItems = 7
        Me.T_DEPTCODE.MaxLength = 4
        Me.T_DEPTCODE.Name = "T_DEPTCODE"
        Me.T_DEPTCODE.Size = New System.Drawing.Size(180, 32)
        Me.T_DEPTCODE.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(662, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 24)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "部門"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(662, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 24)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "性別"
        '
        'T_SEX
        '
        Me.T_SEX.BackColor = System.Drawing.Color.SeaGreen
        Me.T_SEX.Controls.Add(Me.T_Woman)
        Me.T_SEX.Controls.Add(Me.T_Man)
        Me.T_SEX.Location = New System.Drawing.Point(713, 121)
        Me.T_SEX.Name = "T_SEX"
        Me.T_SEX.Size = New System.Drawing.Size(130, 46)
        Me.T_SEX.TabIndex = 35
        Me.T_SEX.TabStop = False
        '
        'T_Woman
        '
        Me.T_Woman.AutoSize = True
        Me.T_Woman.BackColor = System.Drawing.Color.SeaGreen
        Me.T_Woman.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Woman.ForeColor = System.Drawing.Color.White
        Me.T_Woman.Location = New System.Drawing.Point(77, 13)
        Me.T_Woman.Name = "T_Woman"
        Me.T_Woman.Size = New System.Drawing.Size(47, 28)
        Me.T_Woman.TabIndex = 8
        Me.T_Woman.Text = "女"
        Me.T_Woman.UseVisualStyleBackColor = False
        '
        'T_Man
        '
        Me.T_Man.AutoSize = True
        Me.T_Man.BackColor = System.Drawing.Color.SeaGreen
        Me.T_Man.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Man.ForeColor = System.Drawing.Color.White
        Me.T_Man.Location = New System.Drawing.Point(7, 13)
        Me.T_Man.Name = "T_Man"
        Me.T_Man.Size = New System.Drawing.Size(47, 28)
        Me.T_Man.TabIndex = 7
        Me.T_Man.Text = "男"
        Me.T_Man.UseVisualStyleBackColor = False
        '
        'T_ENO
        '
        Me.T_ENO.BackColor = System.Drawing.Color.White
        Me.T_ENO.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ENO.ForeColor = System.Drawing.Color.Navy
        Me.T_ENO.Location = New System.Drawing.Point(713, 43)
        Me.T_ENO.MaxLength = 5
        Me.T_ENO.Name = "T_ENO"
        Me.T_ENO.Size = New System.Drawing.Size(96, 33)
        Me.T_ENO.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(643, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 24)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "員工號"
        '
        'T_GRADE
        '
        Me.T_GRADE.BackColor = System.Drawing.Color.White
        Me.T_GRADE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_GRADE.ForeColor = System.Drawing.Color.Navy
        Me.T_GRADE.FormattingEnabled = True
        Me.T_GRADE.IntegralHeight = False
        Me.T_GRADE.ItemHeight = 24
        Me.T_GRADE.Items.AddRange(New Object() {"02", "03", "04", "05", "05A", "06", "07", "07A", "07B", "07C", "07D", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.T_GRADE.Location = New System.Drawing.Point(713, 217)
        Me.T_GRADE.MaxDropDownItems = 7
        Me.T_GRADE.MaxLength = 3
        Me.T_GRADE.Name = "T_GRADE"
        Me.T_GRADE.Size = New System.Drawing.Size(96, 32)
        Me.T_GRADE.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(662, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "等級"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(624, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 24)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "彙總方式"
        '
        'T_SUBTOTAL
        '
        Me.T_SUBTOTAL.BackColor = System.Drawing.Color.SeaGreen
        Me.T_SUBTOTAL.Controls.Add(Me.T_S4)
        Me.T_SUBTOTAL.Controls.Add(Me.T_S3)
        Me.T_SUBTOTAL.Controls.Add(Me.T_S2)
        Me.T_SUBTOTAL.Controls.Add(Me.T_S1)
        Me.T_SUBTOTAL.Location = New System.Drawing.Point(713, 290)
        Me.T_SUBTOTAL.Name = "T_SUBTOTAL"
        Me.T_SUBTOTAL.Size = New System.Drawing.Size(236, 183)
        Me.T_SUBTOTAL.TabIndex = 45
        Me.T_SUBTOTAL.TabStop = False
        '
        'T_S4
        '
        Me.T_S4.AutoSize = True
        Me.T_S4.BackColor = System.Drawing.Color.SeaGreen
        Me.T_S4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_S4.ForeColor = System.Drawing.Color.White
        Me.T_S4.Location = New System.Drawing.Point(7, 134)
        Me.T_S4.Name = "T_S4"
        Me.T_S4.Size = New System.Drawing.Size(223, 28)
        Me.T_S4.TabIndex = 14
        Me.T_S4.Text = "部門＋職稱＋性別 小計"
        Me.T_S4.UseVisualStyleBackColor = False
        '
        'T_S3
        '
        Me.T_S3.AutoSize = True
        Me.T_S3.BackColor = System.Drawing.Color.SeaGreen
        Me.T_S3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_S3.ForeColor = System.Drawing.Color.White
        Me.T_S3.Location = New System.Drawing.Point(7, 94)
        Me.T_S3.Name = "T_S3"
        Me.T_S3.Size = New System.Drawing.Size(166, 28)
        Me.T_S3.TabIndex = 13
        Me.T_S3.Text = "部門＋等級 小計"
        Me.T_S3.UseVisualStyleBackColor = False
        '
        'T_S2
        '
        Me.T_S2.AutoSize = True
        Me.T_S2.BackColor = System.Drawing.Color.SeaGreen
        Me.T_S2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_S2.ForeColor = System.Drawing.Color.White
        Me.T_S2.Location = New System.Drawing.Point(7, 54)
        Me.T_S2.Name = "T_S2"
        Me.T_S2.Size = New System.Drawing.Size(104, 28)
        Me.T_S2.TabIndex = 12
        Me.T_S2.Text = "部門小計"
        Me.T_S2.UseVisualStyleBackColor = False
        '
        'T_S1
        '
        Me.T_S1.AutoSize = True
        Me.T_S1.BackColor = System.Drawing.Color.SeaGreen
        Me.T_S1.Checked = True
        Me.T_S1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_S1.ForeColor = System.Drawing.Color.White
        Me.T_S1.Location = New System.Drawing.Point(7, 14)
        Me.T_S1.Name = "T_S1"
        Me.T_S1.Size = New System.Drawing.Size(66, 28)
        Me.T_S1.TabIndex = 11
        Me.T_S1.TabStop = True
        Me.T_S1.Text = "明細"
        Me.T_S1.UseVisualStyleBackColor = False
        '
        'T_Path
        '
        Me.T_Path.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Path.ForeColor = System.Drawing.Color.Navy
        Me.T_Path.Location = New System.Drawing.Point(40, 290)
        Me.T_Path.MaxLength = 180
        Me.T_Path.Name = "T_Path"
        Me.T_Path.ReadOnly = True
        Me.T_Path.Size = New System.Drawing.Size(436, 27)
        Me.T_Path.TabIndex = 67
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.White
        Me.T_RecordNo.Location = New System.Drawing.Point(41, 493)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(160, 20)
        Me.T_RecordNo.TabIndex = 69
        '
        'T_MATCH3
        '
        Me.T_MATCH3.AutoSize = True
        Me.T_MATCH3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.T_MATCH3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH3.ForeColor = System.Drawing.Color.White
        Me.T_MATCH3.Location = New System.Drawing.Point(7, 82)
        Me.T_MATCH3.Name = "T_MATCH3"
        Me.T_MATCH3.Size = New System.Drawing.Size(59, 24)
        Me.T_MATCH3.TabIndex = 13
        Me.T_MATCH3.Text = "職稱"
        Me.T_MATCH3.UseVisualStyleBackColor = False
        '
        'T_MATCH2
        '
        Me.T_MATCH2.AutoSize = True
        Me.T_MATCH2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.T_MATCH2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH2.ForeColor = System.Drawing.Color.White
        Me.T_MATCH2.Location = New System.Drawing.Point(7, 48)
        Me.T_MATCH2.Name = "T_MATCH2"
        Me.T_MATCH2.Size = New System.Drawing.Size(91, 24)
        Me.T_MATCH2.TabIndex = 12
        Me.T_MATCH2.Text = "部門代號"
        Me.T_MATCH2.UseVisualStyleBackColor = False
        '
        'T_MATCH
        '
        Me.T_MATCH.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.T_MATCH.Controls.Add(Me.T_MATCH3)
        Me.T_MATCH.Controls.Add(Me.T_MATCH2)
        Me.T_MATCH.Controls.Add(Me.T_MATCH1)
        Me.T_MATCH.Location = New System.Drawing.Point(374, 322)
        Me.T_MATCH.Name = "T_MATCH"
        Me.T_MATCH.Size = New System.Drawing.Size(102, 118)
        Me.T_MATCH.TabIndex = 70
        Me.T_MATCH.TabStop = False
        '
        'T_MATCH1
        '
        Me.T_MATCH1.AutoSize = True
        Me.T_MATCH1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.T_MATCH1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH1.ForeColor = System.Drawing.Color.White
        Me.T_MATCH1.Location = New System.Drawing.Point(7, 14)
        Me.T_MATCH1.Name = "T_MATCH1"
        Me.T_MATCH1.Size = New System.Drawing.Size(75, 24)
        Me.T_MATCH1.TabIndex = 11
        Me.T_MATCH1.Text = "員工號"
        Me.T_MATCH1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(298, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "比對種類"
        '
        'B_PickUp
        '
        Me.B_PickUp.BackColor = System.Drawing.Color.SeaGreen
        Me.B_PickUp.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PickUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_PickUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_PickUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PickUp.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PickUp.ForeColor = System.Drawing.Color.White
        Me.B_PickUp.Location = New System.Drawing.Point(374, 450)
        Me.B_PickUp.Name = "B_PickUp"
        Me.B_PickUp.Size = New System.Drawing.Size(102, 36)
        Me.B_PickUp.TabIndex = 68
        Me.B_PickUp.Text = "選取檔案"
        Me.B_PickUp.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.SeaGreen
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal
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
        Me.DataGridView1.Location = New System.Drawing.Point(41, 324)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(160, 162)
        Me.DataGridView1.TabIndex = 47
        '
        'B_Query
        '
        Me.B_Query.BackColor = System.Drawing.Color.YellowGreen
        Me.B_Query.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Query.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Query.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Query.Location = New System.Drawing.Point(552, 601)
        Me.B_Query.Name = "B_Query"
        Me.B_Query.Size = New System.Drawing.Size(102, 36)
        Me.B_Query.TabIndex = 14
        Me.B_Query.Text = "查 詢"
        Me.B_Query.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.YellowGreen
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Reset.Location = New System.Drawing.Point(444, 601)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 15
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_GiveUp
        '
        Me.B_GiveUp.BackColor = System.Drawing.Color.YellowGreen
        Me.B_GiveUp.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GiveUp.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_GiveUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_GiveUp.Location = New System.Drawing.Point(336, 601)
        Me.B_GiveUp.Name = "B_GiveUp"
        Me.B_GiveUp.Size = New System.Drawing.Size(102, 36)
        Me.B_GiveUp.TabIndex = 16
        Me.B_GiveUp.Text = "放 棄"
        Me.B_GiveUp.UseVisualStyleBackColor = False
        '
        'B_Remove
        '
        Me.B_Remove.BackColor = System.Drawing.Color.SeaGreen
        Me.B_Remove.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Remove.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Remove.ForeColor = System.Drawing.Color.White
        Me.B_Remove.Location = New System.Drawing.Point(207, 133)
        Me.B_Remove.Name = "B_Remove"
        Me.B_Remove.Size = New System.Drawing.Size(102, 36)
        Me.B_Remove.TabIndex = 4
        Me.B_Remove.Text = "← 移 除"
        Me.B_Remove.UseVisualStyleBackColor = False
        '
        'B_Select
        '
        Me.B_Select.BackColor = System.Drawing.Color.SeaGreen
        Me.B_Select.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Select.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Select.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Select.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Select.ForeColor = System.Drawing.Color.White
        Me.B_Select.Location = New System.Drawing.Point(207, 91)
        Me.B_Select.Name = "B_Select"
        Me.B_Select.Size = New System.Drawing.Size(102, 36)
        Me.B_Select.TabIndex = 2
        Me.B_Select.Text = "選 定 →"
        Me.B_Select.UseVisualStyleBackColor = False
        '
        'F_Query
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_MATCH)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.T_Path)
        Me.Controls.Add(Me.B_PickUp)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_SUBTOTAL)
        Me.Controls.Add(Me.T_GRADE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_TITLE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.L_DEPTNAME)
        Me.Controls.Add(Me.T_DEPTCODE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_SEX)
        Me.Controls.Add(Me.T_ENO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.B_Query)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_GiveUp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.B_Remove)
        Me.Controls.Add(Me.B_Select)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Query"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.T_SEX.ResumeLayout(False)
        Me.T_SEX.PerformLayout()
        Me.T_SUBTOTAL.ResumeLayout(False)
        Me.T_SUBTOTAL.PerformLayout()
        Me.T_MATCH.ResumeLayout(False)
        Me.T_MATCH.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents B_Remove As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Select As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_GiveUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Query As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_TITLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents L_DEPTNAME As System.Windows.Forms.Label
    Friend WithEvents T_DEPTCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_SEX As System.Windows.Forms.GroupBox
    Friend WithEvents T_Woman As System.Windows.Forms.RadioButton
    Friend WithEvents T_Man As System.Windows.Forms.RadioButton
    Friend WithEvents T_ENO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_GRADE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_SUBTOTAL As System.Windows.Forms.GroupBox
    Friend WithEvents T_S3 As System.Windows.Forms.RadioButton
    Friend WithEvents T_S2 As System.Windows.Forms.RadioButton
    Friend WithEvents T_S1 As System.Windows.Forms.RadioButton
    Friend WithEvents T_S4 As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents T_Path As System.Windows.Forms.TextBox
    Friend WithEvents B_PickUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents T_MATCH3 As System.Windows.Forms.RadioButton
    Friend WithEvents T_MATCH2 As System.Windows.Forms.RadioButton
    Friend WithEvents T_MATCH As System.Windows.Forms.GroupBox
    Friend WithEvents T_MATCH1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
