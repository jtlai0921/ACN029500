<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Input_1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Input_1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_Name = New System.Windows.Forms.TextBox()
        Me.T_SEX = New System.Windows.Forms.GroupBox()
        Me.T_Woman = New System.Windows.Forms.RadioButton()
        Me.T_Man = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_EDATE = New System.Windows.Forms.TextBox()
        Me.T_BDATE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_SCHOOLING = New System.Windows.Forms.ComboBox()
        Me.T_ADDRESS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_CITY = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_TOWN = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.T_ZIPCODE = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.T_INTEREST = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.L_date1 = New System.Windows.Forms.Label()
        Me.L_date2 = New System.Windows.Forms.Label()
        Me.T_DEPTCODE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.L_DEPTNAME = New System.Windows.Forms.Label()
        Me.T_TITLE = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.T_Color = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.L_Designer = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_LIST01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_OK = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_SEX.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(169, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "姓名"
        '
        'T_Name
        '
        Me.T_Name.BackColor = System.Drawing.Color.White
        Me.T_Name.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Name.ForeColor = System.Drawing.Color.Navy
        Me.T_Name.Location = New System.Drawing.Point(220, 39)
        Me.T_Name.Name = "T_Name"
        Me.T_Name.Size = New System.Drawing.Size(143, 33)
        Me.T_Name.TabIndex = 0
        '
        'T_SEX
        '
        Me.T_SEX.Controls.Add(Me.T_Woman)
        Me.T_SEX.Controls.Add(Me.T_Man)
        Me.T_SEX.Location = New System.Drawing.Point(617, 27)
        Me.T_SEX.Name = "T_SEX"
        Me.T_SEX.Size = New System.Drawing.Size(130, 46)
        Me.T_SEX.TabIndex = 1
        Me.T_SEX.TabStop = False
        '
        'T_Woman
        '
        Me.T_Woman.AutoSize = True
        Me.T_Woman.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Woman.ForeColor = System.Drawing.Color.Navy
        Me.T_Woman.Location = New System.Drawing.Point(77, 14)
        Me.T_Woman.Name = "T_Woman"
        Me.T_Woman.Size = New System.Drawing.Size(47, 28)
        Me.T_Woman.TabIndex = 1
        Me.T_Woman.Text = "女"
        Me.T_Woman.UseVisualStyleBackColor = True
        '
        'T_Man
        '
        Me.T_Man.AutoSize = True
        Me.T_Man.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Man.ForeColor = System.Drawing.Color.Navy
        Me.T_Man.Location = New System.Drawing.Point(7, 14)
        Me.T_Man.Name = "T_Man"
        Me.T_Man.Size = New System.Drawing.Size(47, 28)
        Me.T_Man.TabIndex = 0
        Me.T_Man.Text = "男"
        Me.T_Man.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(567, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "性別"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(131, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 24)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "入公司日"
        '
        'T_EDATE
        '
        Me.T_EDATE.BackColor = System.Drawing.Color.White
        Me.T_EDATE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_EDATE.ForeColor = System.Drawing.Color.Navy
        Me.T_EDATE.Location = New System.Drawing.Point(220, 154)
        Me.T_EDATE.MaxLength = 8
        Me.T_EDATE.Name = "T_EDATE"
        Me.T_EDATE.Size = New System.Drawing.Size(129, 33)
        Me.T_EDATE.TabIndex = 4
        '
        'T_BDATE
        '
        Me.T_BDATE.BackColor = System.Drawing.Color.White
        Me.T_BDATE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_BDATE.ForeColor = System.Drawing.Color.Navy
        Me.T_BDATE.Location = New System.Drawing.Point(220, 212)
        Me.T_BDATE.MaxLength = 8
        Me.T_BDATE.Name = "T_BDATE"
        Me.T_BDATE.Size = New System.Drawing.Size(129, 33)
        Me.T_BDATE.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(150, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 24)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "出生日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(352, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "（yyyymmdd）"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(352, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 17)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "（yyyymmdd）"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(169, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 24)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "學歷"
        '
        'T_SCHOOLING
        '
        Me.T_SCHOOLING.BackColor = System.Drawing.Color.White
        Me.T_SCHOOLING.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SCHOOLING.ForeColor = System.Drawing.Color.Navy
        Me.T_SCHOOLING.FormattingEnabled = True
        Me.T_SCHOOLING.ItemHeight = 24
        Me.T_SCHOOLING.Items.AddRange(New Object() {"博士", "碩士", "大學", "專科", "高中", "高職", "國中", "小學"})
        Me.T_SCHOOLING.Location = New System.Drawing.Point(220, 270)
        Me.T_SCHOOLING.Name = "T_SCHOOLING"
        Me.T_SCHOOLING.Size = New System.Drawing.Size(120, 32)
        Me.T_SCHOOLING.TabIndex = 6
        '
        'T_ADDRESS
        '
        Me.T_ADDRESS.BackColor = System.Drawing.Color.White
        Me.T_ADDRESS.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ADDRESS.ForeColor = System.Drawing.Color.Navy
        Me.T_ADDRESS.Location = New System.Drawing.Point(220, 384)
        Me.T_ADDRESS.Name = "T_ADDRESS"
        Me.T_ADDRESS.Size = New System.Drawing.Size(527, 33)
        Me.T_ADDRESS.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(169, 388)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 24)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "戶籍"
        '
        'T_CITY
        '
        Me.T_CITY.BackColor = System.Drawing.Color.White
        Me.T_CITY.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_CITY.ForeColor = System.Drawing.Color.Navy
        Me.T_CITY.FormattingEnabled = True
        Me.T_CITY.IntegralHeight = False
        Me.T_CITY.ItemHeight = 24
        Me.T_CITY.Items.AddRange(New Object() {"臺北市", "基隆市", "新北市", "宜蘭縣", "新竹市", "新竹縣", "桃園市", "苗栗縣", "臺中市", "彰化縣", "南投縣", "嘉義市", "嘉義縣", "雲林縣", "臺南市", "高雄市", "南海諸島", "澎湖縣", "屏東縣", "臺東縣", "花蓮縣", "金門縣", "連江縣"})
        Me.T_CITY.Location = New System.Drawing.Point(220, 327)
        Me.T_CITY.MaxDropDownItems = 7
        Me.T_CITY.Name = "T_CITY"
        Me.T_CITY.Size = New System.Drawing.Size(120, 32)
        Me.T_CITY.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(169, 331)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 24)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "縣市"
        '
        'T_TOWN
        '
        Me.T_TOWN.BackColor = System.Drawing.Color.White
        Me.T_TOWN.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TOWN.ForeColor = System.Drawing.Color.Navy
        Me.T_TOWN.FormattingEnabled = True
        Me.T_TOWN.IntegralHeight = False
        Me.T_TOWN.ItemHeight = 24
        Me.T_TOWN.Location = New System.Drawing.Point(434, 327)
        Me.T_TOWN.MaxDropDownItems = 7
        Me.T_TOWN.Name = "T_TOWN"
        Me.T_TOWN.Size = New System.Drawing.Size(126, 32)
        Me.T_TOWN.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(365, 331)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 24)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "鄉鎮區"
        '
        'T_ZIPCODE
        '
        Me.T_ZIPCODE.BackColor = System.Drawing.Color.White
        Me.T_ZIPCODE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ZIPCODE.ForeColor = System.Drawing.Color.Navy
        Me.T_ZIPCODE.Location = New System.Drawing.Point(690, 327)
        Me.T_ZIPCODE.MaxLength = 3
        Me.T_ZIPCODE.Name = "T_ZIPCODE"
        Me.T_ZIPCODE.Size = New System.Drawing.Size(57, 33)
        Me.T_ZIPCODE.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(602, 331)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 24)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "郵遞區號"
        '
        'T_INTEREST
        '
        Me.T_INTEREST.BackColor = System.Drawing.Color.White
        Me.T_INTEREST.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_INTEREST.ForeColor = System.Drawing.Color.Navy
        Me.T_INTEREST.Location = New System.Drawing.Point(220, 442)
        Me.T_INTEREST.Name = "T_INTEREST"
        Me.T_INTEREST.Size = New System.Drawing.Size(485, 33)
        Me.T_INTEREST.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(169, 446)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 24)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "興趣"
        '
        'L_date1
        '
        Me.L_date1.AutoSize = True
        Me.L_date1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_date1.ForeColor = System.Drawing.Color.Black
        Me.L_date1.Location = New System.Drawing.Point(465, 187)
        Me.L_date1.Name = "L_date1"
        Me.L_date1.Size = New System.Drawing.Size(0, 20)
        Me.L_date1.TabIndex = 24
        Me.L_date1.Visible = False
        '
        'L_date2
        '
        Me.L_date2.AutoSize = True
        Me.L_date2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_date2.ForeColor = System.Drawing.Color.Black
        Me.L_date2.Location = New System.Drawing.Point(465, 243)
        Me.L_date2.Name = "L_date2"
        Me.L_date2.Size = New System.Drawing.Size(0, 20)
        Me.L_date2.TabIndex = 27
        Me.L_date2.Visible = False
        '
        'T_DEPTCODE
        '
        Me.T_DEPTCODE.BackColor = System.Drawing.Color.White
        Me.T_DEPTCODE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPTCODE.ForeColor = System.Drawing.Color.Navy
        Me.T_DEPTCODE.FormattingEnabled = True
        Me.T_DEPTCODE.IntegralHeight = False
        Me.T_DEPTCODE.Location = New System.Drawing.Point(220, 97)
        Me.T_DEPTCODE.MaxDropDownItems = 7
        Me.T_DEPTCODE.MaxLength = 4
        Me.T_DEPTCODE.Name = "T_DEPTCODE"
        Me.T_DEPTCODE.Size = New System.Drawing.Size(143, 32)
        Me.T_DEPTCODE.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(169, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 24)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "部門"
        '
        'L_DEPTNAME
        '
        Me.L_DEPTNAME.AutoSize = True
        Me.L_DEPTNAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_DEPTNAME.ForeColor = System.Drawing.Color.Black
        Me.L_DEPTNAME.Location = New System.Drawing.Point(373, 121)
        Me.L_DEPTNAME.Name = "L_DEPTNAME"
        Me.L_DEPTNAME.Size = New System.Drawing.Size(0, 20)
        Me.L_DEPTNAME.TabIndex = 20
        '
        'T_TITLE
        '
        Me.T_TITLE.BackColor = System.Drawing.Color.White
        Me.T_TITLE.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLE.ForeColor = System.Drawing.Color.Navy
        Me.T_TITLE.FormattingEnabled = True
        Me.T_TITLE.IntegralHeight = False
        Me.T_TITLE.ItemHeight = 24
        Me.T_TITLE.Items.AddRange(New Object() {"總經理", "處長", "廠長", "組長", "特助", "秘書", "會計員", "研究員", "品管員", "文書員", "佐理員", "工程師", "技術員", "採購員", "倉管員"})
        Me.T_TITLE.Location = New System.Drawing.Point(617, 97)
        Me.T_TITLE.MaxDropDownItems = 7
        Me.T_TITLE.Name = "T_TITLE"
        Me.T_TITLE.Size = New System.Drawing.Size(130, 32)
        Me.T_TITLE.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(567, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 24)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "職稱"
        '
        'T_Color
        '
        Me.T_Color.BackColor = System.Drawing.Color.White
        Me.T_Color.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Color.ForeColor = System.Drawing.Color.Navy
        Me.T_Color.FormattingEnabled = True
        Me.T_Color.ItemHeight = 20
        Me.T_Color.Items.AddRange(New Object() {"底色 A _ 197, 197, 197", "底色 B _ 185, 211, 200", "底色 C _ 205, 205, 193", "底色 D _ 176, 196, 210", "底色 E _ 180, 205, 205"})
        Me.T_Color.Location = New System.Drawing.Point(220, 500)
        Me.T_Color.Name = "T_Color"
        Me.T_Color.Size = New System.Drawing.Size(188, 28)
        Me.T_Color.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(64, 504)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(153, 20)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "變更表單及按鈕底色"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.L_Designer)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(784, 488)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 166)
        Me.Panel1.TabIndex = 35
        '
        'L_Designer
        '
        Me.L_Designer.AutoSize = True
        Me.L_Designer.BackColor = System.Drawing.Color.Transparent
        Me.L_Designer.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_Designer.ForeColor = System.Drawing.Color.Navy
        Me.L_Designer.Location = New System.Drawing.Point(36, 130)
        Me.L_Designer.Name = "L_Designer"
        Me.L_Designer.Size = New System.Drawing.Size(130, 19)
        Me.L_Designer.TabIndex = 0
        Me.L_Designer.Text = "設計者：美欣 566"
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(13, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 147)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Purple
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(347, 606)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(90, 34)
        Me.B_Close.TabIndex = 16
        Me.B_Close.Text = "放 棄"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'B_LIST01
        '
        Me.B_LIST01.BackColor = System.Drawing.Color.Navy
        Me.B_LIST01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_LIST01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_LIST01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_LIST01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_LIST01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_LIST01.ForeColor = System.Drawing.Color.White
        Me.B_LIST01.Location = New System.Drawing.Point(711, 442)
        Me.B_LIST01.Name = "B_LIST01"
        Me.B_LIST01.Size = New System.Drawing.Size(36, 33)
        Me.B_LIST01.TabIndex = 12
        Me.B_LIST01.Text = "....."
        Me.B_LIST01.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(450, 606)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(90, 34)
        Me.B_Reset.TabIndex = 15
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.B_OK.ForeColor = System.Drawing.Color.White
        Me.B_OK.Location = New System.Drawing.Point(553, 606)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(90, 34)
        Me.B_OK.TabIndex = 14
        Me.B_OK.Text = "確 定"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'F_Input_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.T_Color)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.T_TITLE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.L_DEPTNAME)
        Me.Controls.Add(Me.T_DEPTCODE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.L_date2)
        Me.Controls.Add(Me.L_date1)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_LIST01)
        Me.Controls.Add(Me.T_INTEREST)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.T_ZIPCODE)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_TOWN)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.T_CITY)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.T_ADDRESS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.T_SCHOOLING)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_BDATE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_EDATE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_SEX)
        Me.Controls.Add(Me.T_Name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Input_1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.TopMost = True
        Me.T_SEX.ResumeLayout(False)
        Me.T_SEX.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_OK As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_Name As System.Windows.Forms.TextBox
    Friend WithEvents T_SEX As System.Windows.Forms.GroupBox
    Friend WithEvents T_Woman As System.Windows.Forms.RadioButton
    Friend WithEvents T_Man As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_EDATE As System.Windows.Forms.TextBox
    Friend WithEvents T_BDATE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_SCHOOLING As System.Windows.Forms.ComboBox
    Friend WithEvents T_ADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents T_CITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents T_TOWN As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_ZIPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents T_INTEREST As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents B_LIST01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents L_date1 As System.Windows.Forms.Label
    Friend WithEvents L_date2 As System.Windows.Forms.Label
    Friend WithEvents T_DEPTCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents L_DEPTNAME As System.Windows.Forms.Label
    Friend WithEvents T_TITLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents T_Color As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents L_Designer As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
