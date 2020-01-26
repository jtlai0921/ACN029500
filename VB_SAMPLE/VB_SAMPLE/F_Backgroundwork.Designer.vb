<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Backgroundwork
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_BRANCH = New System.Windows.Forms.ComboBox()
        Me.T_DOGTYPES = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.T_SALEDATEA = New System.Windows.Forms.TextBox()
        Me.T_SALEDATEB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.L_criterion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.L_RECNO = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.L_ElapsedTime = New System.Windows.Forms.Label()
        Me.L_TOTALQTY = New System.Windows.Forms.Label()
        Me.B_OneThread = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.MyClass_ButtonClose1 = New VB_SAMPLE.MyClass_ButtonClose()
        Me.B_RESET = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_GO = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Red
        Me.ProgressBar1.Location = New System.Drawing.Point(315, 385)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(360, 28)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(13, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 297)
        Me.Panel1.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(473, 284)
        Me.DataGridView1.TabIndex = 6
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "分店"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 73
        '
        'Column2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column2.HeaderText = "銷售日"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 92
        '
        'Column3
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column3.HeaderText = "品種"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 73
        '
        'Column4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column4.HeaderText = "單價"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column5
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle6.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column5.HeaderText = "數量"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 73
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(315, 355)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "正在處理中，請稍待！"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(634, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "分店"
        '
        'T_BRANCH
        '
        Me.T_BRANCH.BackColor = System.Drawing.Color.White
        Me.T_BRANCH.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_BRANCH.ForeColor = System.Drawing.Color.Navy
        Me.T_BRANCH.FormattingEnabled = True
        Me.T_BRANCH.Items.AddRange(New Object() {"基隆", "台北", "新北", "桃園", "新竹", "台中", "台南", "高雄", "屏東", "花蓮"})
        Me.T_BRANCH.Location = New System.Drawing.Point(678, 77)
        Me.T_BRANCH.Name = "T_BRANCH"
        Me.T_BRANCH.Size = New System.Drawing.Size(96, 28)
        Me.T_BRANCH.TabIndex = 1
        '
        'T_DOGTYPES
        '
        Me.T_DOGTYPES.BackColor = System.Drawing.Color.White
        Me.T_DOGTYPES.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DOGTYPES.ForeColor = System.Drawing.Color.Navy
        Me.T_DOGTYPES.FormattingEnabled = True
        Me.T_DOGTYPES.IntegralHeight = False
        Me.T_DOGTYPES.Items.AddRange(New Object() {"八哥 ", "大丹狗", "大麥丁", "巴吉度", "日本秋田犬", "比熊犬", "北京狗 ", "可卡", "巨型貴賓", "白色狐狸狗 ", "米格魯 ", "西施 ", "西高地白梗 ", "西藏獒犬", "杜賓狗 ", "沙皮狗", "法國鬥牛犬", "玩具貴賓 ", "長毛吉娃娃 ", "阿富汗犬", "哈士奇 ", "約克夏 ", "拳師狗", "柴犬 ", "雪納瑞 ", "博美 ", "喜樂蒂 ", "短毛吉娃娃 ", "黃金獵犬", "聖伯納", "瑪爾濟斯 ", "德國狼狗 ", "蝴蝶犬 ", "鬆獅犬", "邊境牧羊犬"})
        Me.T_DOGTYPES.Location = New System.Drawing.Point(678, 117)
        Me.T_DOGTYPES.MaxDropDownItems = 10
        Me.T_DOGTYPES.Name = "T_DOGTYPES"
        Me.T_DOGTYPES.Size = New System.Drawing.Size(130, 28)
        Me.T_DOGTYPES.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(634, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "品種"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BackColor = System.Drawing.Color.White
        Me.CheckedListBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckedListBox1.ForeColor = System.Drawing.Color.Maroon
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.IntegralHeight = False
        Me.CheckedListBox1.Items.AddRange(New Object() {"1. 正在讀取資料", "2. 正在篩選資料", "3. 正在匯出檔案", "4. 正在格式化", "5. 正在更新 DataGridView"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(315, 419)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(222, 129)
        Me.CheckedListBox1.TabIndex = 12
        Me.CheckedListBox1.Visible = False
        '
        'T_SALEDATEA
        '
        Me.T_SALEDATEA.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SALEDATEA.ForeColor = System.Drawing.Color.Navy
        Me.T_SALEDATEA.Location = New System.Drawing.Point(678, 157)
        Me.T_SALEDATEA.MaxLength = 10
        Me.T_SALEDATEA.Name = "T_SALEDATEA"
        Me.T_SALEDATEA.Size = New System.Drawing.Size(108, 29)
        Me.T_SALEDATEA.TabIndex = 3
        '
        'T_SALEDATEB
        '
        Me.T_SALEDATEB.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SALEDATEB.ForeColor = System.Drawing.Color.Navy
        Me.T_SALEDATEB.Location = New System.Drawing.Point(827, 157)
        Me.T_SALEDATEB.MaxLength = 10
        Me.T_SALEDATEB.Name = "T_SALEDATEB"
        Me.T_SALEDATEB.Size = New System.Drawing.Size(108, 29)
        Me.T_SALEDATEB.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(790, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 27)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "～"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(618, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "銷售日"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Teal
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.L_criterion)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.B_RESET)
        Me.Panel2.Controls.Add(Me.B_GO)
        Me.Panel2.Location = New System.Drawing.Point(589, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(383, 285)
        Me.Panel2.TabIndex = 18
        '
        'L_criterion
        '
        Me.L_criterion.AutoSize = True
        Me.L_criterion.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_criterion.ForeColor = System.Drawing.Color.Yellow
        Me.L_criterion.Location = New System.Drawing.Point(124, 10)
        Me.L_criterion.Name = "L_criterion"
        Me.L_criterion.Size = New System.Drawing.Size(143, 24)
        Me.L_criterion.TabIndex = 20
        Me.L_criterion.Text = "請指定查詢條件"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(90, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "yyyy/mm/dd"
        '
        'L_RECNO
        '
        Me.L_RECNO.AutoSize = True
        Me.L_RECNO.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_RECNO.ForeColor = System.Drawing.Color.White
        Me.L_RECNO.Location = New System.Drawing.Point(17, 318)
        Me.L_RECNO.Name = "L_RECNO"
        Me.L_RECNO.Size = New System.Drawing.Size(70, 20)
        Me.L_RECNO.TabIndex = 19
        Me.L_RECNO.Text = "筆數： 0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'L_ElapsedTime
        '
        Me.L_ElapsedTime.AutoSize = True
        Me.L_ElapsedTime.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_ElapsedTime.ForeColor = System.Drawing.Color.White
        Me.L_ElapsedTime.Location = New System.Drawing.Point(17, 380)
        Me.L_ElapsedTime.Name = "L_ElapsedTime"
        Me.L_ElapsedTime.Size = New System.Drawing.Size(122, 20)
        Me.L_ElapsedTime.TabIndex = 21
        Me.L_ElapsedTime.Text = "耗用時間： 0 秒"
        '
        'L_TOTALQTY
        '
        Me.L_TOTALQTY.AutoSize = True
        Me.L_TOTALQTY.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_TOTALQTY.ForeColor = System.Drawing.Color.White
        Me.L_TOTALQTY.Location = New System.Drawing.Point(17, 349)
        Me.L_TOTALQTY.Name = "L_TOTALQTY"
        Me.L_TOTALQTY.Size = New System.Drawing.Size(102, 20)
        Me.L_TOTALQTY.TabIndex = 23
        Me.L_TOTALQTY.Text = "合計數量： 0"
        '
        'B_OneThread
        '
        Me.B_OneThread.BackColor = System.Drawing.Color.PowderBlue
        Me.B_OneThread.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_OneThread.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_OneThread.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite
        Me.B_OneThread.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OneThread.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_OneThread.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_OneThread.Location = New System.Drawing.Point(509, 596)
        Me.B_OneThread.Name = "B_OneThread"
        Me.B_OneThread.Size = New System.Drawing.Size(102, 36)
        Me.B_OneThread.TabIndex = 22
        Me.B_OneThread.Text = "單一執行緒"
        Me.B_OneThread.UseVisualStyleBackColor = False
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
        Me.MyClass_ButtonClose1.Location = New System.Drawing.Point(380, 596)
        Me.MyClass_ButtonClose1.Name = "MyClass_ButtonClose1"
        Me.MyClass_ButtonClose1.Size = New System.Drawing.Size(102, 36)
        Me.MyClass_ButtonClose1.TabIndex = 8
        Me.MyClass_ButtonClose1.Text = "Close"
        Me.MyClass_ButtonClose1.UseVisualStyleBackColor = False
        '
        'B_RESET
        '
        Me.B_RESET.BackColor = System.Drawing.Color.Purple
        Me.B_RESET.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_RESET.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_RESET.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_RESET.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_RESET.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_RESET.ForeColor = System.Drawing.Color.White
        Me.B_RESET.Location = New System.Drawing.Point(87, 228)
        Me.B_RESET.Name = "B_RESET"
        Me.B_RESET.Size = New System.Drawing.Size(102, 36)
        Me.B_RESET.TabIndex = 7
        Me.B_RESET.Text = "Reset"
        Me.B_RESET.UseVisualStyleBackColor = False
        '
        'B_GO
        '
        Me.B_GO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_GO.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GO.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_GO.ForeColor = System.Drawing.Color.White
        Me.B_GO.Location = New System.Drawing.Point(207, 228)
        Me.B_GO.Name = "B_GO"
        Me.B_GO.Size = New System.Drawing.Size(102, 36)
        Me.B_GO.TabIndex = 5
        Me.B_GO.Text = "查 詢"
        Me.B_GO.UseVisualStyleBackColor = False
        '
        'F_Backgroundwork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.L_TOTALQTY)
        Me.Controls.Add(Me.B_OneThread)
        Me.Controls.Add(Me.L_ElapsedTime)
        Me.Controls.Add(Me.L_RECNO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_SALEDATEB)
        Me.Controls.Add(Me.T_SALEDATEA)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.T_DOGTYPES)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_BRANCH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MyClass_ButtonClose1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Backgroundwork"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyClass_ButtonClose1 As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents B_GO As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_BRANCH As System.Windows.Forms.ComboBox
    Friend WithEvents T_DOGTYPES As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents T_SALEDATEA As System.Windows.Forms.TextBox
    Friend WithEvents T_SALEDATEB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents B_RESET As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents L_RECNO As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents L_ElapsedTime As System.Windows.Forms.Label
    Friend WithEvents B_OneThread As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents L_TOTALQTY As System.Windows.Forms.Label
    Friend WithEvents L_criterion As System.Windows.Forms.Label
End Class
