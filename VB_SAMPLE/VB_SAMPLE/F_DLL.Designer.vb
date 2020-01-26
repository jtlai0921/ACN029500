<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DLL
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.B_Match = New System.Windows.Forms.Button()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.T_RecordNo2 = New System.Windows.Forms.TextBox()
        Me.T_GRADE = New System.Windows.Forms.ComboBox()
        Me.L_GRADE = New System.Windows.Forms.Label()
        Me.T_TITLE = New System.Windows.Forms.ComboBox()
        Me.L_TITLE = New System.Windows.Forms.Label()
        Me.T_DEPT = New System.Windows.Forms.ComboBox()
        Me.L_DEPT = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_MATCH = New System.Windows.Forms.GroupBox()
        Me.T_MATCH3 = New System.Windows.Forms.RadioButton()
        Me.T_MATCH2 = New System.Windows.Forms.RadioButton()
        Me.T_MATCH1 = New System.Windows.Forms.RadioButton()
        Me.T_GradeList = New System.Windows.Forms.TextBox()
        Me.T_DeptList = New System.Windows.Forms.TextBox()
        Me.T_TitleList = New System.Windows.Forms.TextBox()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.B_ReCallAll = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_ReCall = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Remove = New VB_SAMPLE.MyClass_ButtonGeneral()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_MATCH.SuspendLayout()
        Me.SuspendLayout()
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
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
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
        Me.DataGridView1.Location = New System.Drawing.Point(8, 200)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(875, 221)
        Me.DataGridView1.TabIndex = 0
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(330, 608)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 1
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'B_Match
        '
        Me.B_Match.BackColor = System.Drawing.Color.Black
        Me.B_Match.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Match.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal
        Me.B_Match.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal
        Me.B_Match.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Match.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Match.ForeColor = System.Drawing.Color.White
        Me.B_Match.Location = New System.Drawing.Point(558, 608)
        Me.B_Match.Name = "B_Match"
        Me.B_Match.Size = New System.Drawing.Size(102, 36)
        Me.B_Match.TabIndex = 2
        Me.B_Match.Text = "比 對"
        Me.B_Match.UseVisualStyleBackColor = False
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.Black
        Me.T_RecordNo.Location = New System.Drawing.Point(889, 401)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(96, 22)
        Me.T_RecordNo.TabIndex = 50
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.Location = New System.Drawing.Point(8, 12)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(875, 164)
        Me.DataGridView2.TabIndex = 85
        '
        'T_RecordNo2
        '
        Me.T_RecordNo2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.T_RecordNo2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo2.ForeColor = System.Drawing.Color.Black
        Me.T_RecordNo2.Location = New System.Drawing.Point(889, 12)
        Me.T_RecordNo2.MaxLength = 180
        Me.T_RecordNo2.Name = "T_RecordNo2"
        Me.T_RecordNo2.ReadOnly = True
        Me.T_RecordNo2.Size = New System.Drawing.Size(96, 22)
        Me.T_RecordNo2.TabIndex = 86
        '
        'T_GRADE
        '
        Me.T_GRADE.BackColor = System.Drawing.Color.White
        Me.T_GRADE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_GRADE.ForeColor = System.Drawing.Color.Navy
        Me.T_GRADE.FormattingEnabled = True
        Me.T_GRADE.IntegralHeight = False
        Me.T_GRADE.ItemHeight = 20
        Me.T_GRADE.Items.AddRange(New Object() {"02", "03", "04", "05", "06", "07", "07A", "07C", "09", "10", "11", "12", "13", "15"})
        Me.T_GRADE.Location = New System.Drawing.Point(512, 457)
        Me.T_GRADE.MaxDropDownItems = 7
        Me.T_GRADE.MaxLength = 3
        Me.T_GRADE.Name = "T_GRADE"
        Me.T_GRADE.Size = New System.Drawing.Size(96, 28)
        Me.T_GRADE.TabIndex = 90
        '
        'L_GRADE
        '
        Me.L_GRADE.AutoSize = True
        Me.L_GRADE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_GRADE.ForeColor = System.Drawing.Color.Black
        Me.L_GRADE.Location = New System.Drawing.Point(468, 461)
        Me.L_GRADE.Name = "L_GRADE"
        Me.L_GRADE.Size = New System.Drawing.Size(41, 20)
        Me.L_GRADE.TabIndex = 96
        Me.L_GRADE.Text = "等級"
        '
        'T_TITLE
        '
        Me.T_TITLE.BackColor = System.Drawing.Color.White
        Me.T_TITLE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLE.ForeColor = System.Drawing.Color.Navy
        Me.T_TITLE.FormattingEnabled = True
        Me.T_TITLE.IntegralHeight = False
        Me.T_TITLE.ItemHeight = 20
        Me.T_TITLE.Items.AddRange(New Object() {"工程師", "代組長", "佐理員", "助理工程師", "技術員", "研究員", "副工程師", "專員", "組長", "會計員", "業務員", "督導員", "經理", "資料管理員", "資訊工程師", "審核員", "辦事員", "警衛", "警衛領班"})
        Me.T_TITLE.Location = New System.Drawing.Point(512, 529)
        Me.T_TITLE.MaxDropDownItems = 7
        Me.T_TITLE.MaxLength = 14
        Me.T_TITLE.Name = "T_TITLE"
        Me.T_TITLE.Size = New System.Drawing.Size(168, 28)
        Me.T_TITLE.TabIndex = 89
        Me.T_TITLE.Visible = False
        '
        'L_TITLE
        '
        Me.L_TITLE.AutoSize = True
        Me.L_TITLE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_TITLE.ForeColor = System.Drawing.Color.Black
        Me.L_TITLE.Location = New System.Drawing.Point(468, 533)
        Me.L_TITLE.Name = "L_TITLE"
        Me.L_TITLE.Size = New System.Drawing.Size(41, 20)
        Me.L_TITLE.TabIndex = 95
        Me.L_TITLE.Text = "職稱"
        Me.L_TITLE.Visible = False
        '
        'T_DEPT
        '
        Me.T_DEPT.BackColor = System.Drawing.Color.White
        Me.T_DEPT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPT.ForeColor = System.Drawing.Color.Navy
        Me.T_DEPT.FormattingEnabled = True
        Me.T_DEPT.IntegralHeight = False
        Me.T_DEPT.Items.AddRange(New Object() {"2100人事行政部", "2200會計部", "2500研發部", "2600企劃部"})
        Me.T_DEPT.Location = New System.Drawing.Point(512, 493)
        Me.T_DEPT.MaxDropDownItems = 7
        Me.T_DEPT.MaxLength = 4
        Me.T_DEPT.Name = "T_DEPT"
        Me.T_DEPT.Size = New System.Drawing.Size(180, 28)
        Me.T_DEPT.TabIndex = 88
        Me.T_DEPT.Visible = False
        '
        'L_DEPT
        '
        Me.L_DEPT.AutoSize = True
        Me.L_DEPT.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_DEPT.ForeColor = System.Drawing.Color.Black
        Me.L_DEPT.Location = New System.Drawing.Point(468, 497)
        Me.L_DEPT.Name = "L_DEPT"
        Me.L_DEPT.Size = New System.Drawing.Size(41, 20)
        Me.L_DEPT.TabIndex = 93
        Me.L_DEPT.Text = "部門"
        Me.L_DEPT.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(269, 463)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "比對種類"
        '
        'T_MATCH
        '
        Me.T_MATCH.BackColor = System.Drawing.Color.SeaGreen
        Me.T_MATCH.Controls.Add(Me.T_MATCH3)
        Me.T_MATCH.Controls.Add(Me.T_MATCH2)
        Me.T_MATCH.Controls.Add(Me.T_MATCH1)
        Me.T_MATCH.Location = New System.Drawing.Point(345, 457)
        Me.T_MATCH.Name = "T_MATCH"
        Me.T_MATCH.Size = New System.Drawing.Size(102, 118)
        Me.T_MATCH.TabIndex = 97
        Me.T_MATCH.TabStop = False
        '
        'T_MATCH3
        '
        Me.T_MATCH3.AutoSize = True
        Me.T_MATCH3.BackColor = System.Drawing.Color.SeaGreen
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
        Me.T_MATCH2.BackColor = System.Drawing.Color.SeaGreen
        Me.T_MATCH2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH2.ForeColor = System.Drawing.Color.White
        Me.T_MATCH2.Location = New System.Drawing.Point(7, 48)
        Me.T_MATCH2.Name = "T_MATCH2"
        Me.T_MATCH2.Size = New System.Drawing.Size(91, 24)
        Me.T_MATCH2.TabIndex = 12
        Me.T_MATCH2.Text = "部門代號"
        Me.T_MATCH2.UseVisualStyleBackColor = False
        '
        'T_MATCH1
        '
        Me.T_MATCH1.AutoSize = True
        Me.T_MATCH1.BackColor = System.Drawing.Color.SeaGreen
        Me.T_MATCH1.Checked = True
        Me.T_MATCH1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MATCH1.ForeColor = System.Drawing.Color.White
        Me.T_MATCH1.Location = New System.Drawing.Point(7, 14)
        Me.T_MATCH1.Name = "T_MATCH1"
        Me.T_MATCH1.Size = New System.Drawing.Size(59, 24)
        Me.T_MATCH1.TabIndex = 11
        Me.T_MATCH1.TabStop = True
        Me.T_MATCH1.Text = "等級"
        Me.T_MATCH1.UseVisualStyleBackColor = False
        '
        'T_GradeList
        '
        Me.T_GradeList.BackColor = System.Drawing.Color.White
        Me.T_GradeList.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_GradeList.ForeColor = System.Drawing.Color.Navy
        Me.T_GradeList.Location = New System.Drawing.Point(700, 457)
        Me.T_GradeList.Name = "T_GradeList"
        Me.T_GradeList.Size = New System.Drawing.Size(280, 29)
        Me.T_GradeList.TabIndex = 99
        '
        'T_DeptList
        '
        Me.T_DeptList.BackColor = System.Drawing.Color.White
        Me.T_DeptList.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DeptList.ForeColor = System.Drawing.Color.Navy
        Me.T_DeptList.Location = New System.Drawing.Point(700, 493)
        Me.T_DeptList.Name = "T_DeptList"
        Me.T_DeptList.Size = New System.Drawing.Size(280, 29)
        Me.T_DeptList.TabIndex = 100
        Me.T_DeptList.Visible = False
        '
        'T_TitleList
        '
        Me.T_TitleList.BackColor = System.Drawing.Color.White
        Me.T_TitleList.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TitleList.ForeColor = System.Drawing.Color.Navy
        Me.T_TitleList.Location = New System.Drawing.Point(700, 529)
        Me.T_TitleList.Name = "T_TitleList"
        Me.T_TitleList.Size = New System.Drawing.Size(280, 29)
        Me.T_TitleList.TabIndex = 101
        Me.T_TitleList.Visible = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(444, 608)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 102
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_ReCallAll
        '
        Me.B_ReCallAll.BackColor = System.Drawing.Color.Teal
        Me.B_ReCallAll.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ReCallAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ReCallAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ReCallAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ReCallAll.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_ReCallAll.ForeColor = System.Drawing.Color.White
        Me.B_ReCallAll.Location = New System.Drawing.Point(889, 98)
        Me.B_ReCallAll.Name = "B_ReCallAll"
        Me.B_ReCallAll.Size = New System.Drawing.Size(96, 36)
        Me.B_ReCallAll.TabIndex = 103
        Me.B_ReCallAll.Text = "全部轉回"
        Me.B_ReCallAll.UseVisualStyleBackColor = False
        '
        'B_ReCall
        '
        Me.B_ReCall.BackColor = System.Drawing.Color.Teal
        Me.B_ReCall.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ReCall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ReCall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ReCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ReCall.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_ReCall.ForeColor = System.Drawing.Color.White
        Me.B_ReCall.Location = New System.Drawing.Point(889, 140)
        Me.B_ReCall.Name = "B_ReCall"
        Me.B_ReCall.Size = New System.Drawing.Size(96, 36)
        Me.B_ReCall.TabIndex = 87
        Me.B_ReCall.Text = "轉回 ↓"
        Me.B_ReCall.UseVisualStyleBackColor = False
        '
        'B_Remove
        '
        Me.B_Remove.BackColor = System.Drawing.Color.Teal
        Me.B_Remove.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Remove.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Remove.ForeColor = System.Drawing.Color.White
        Me.B_Remove.Location = New System.Drawing.Point(889, 200)
        Me.B_Remove.Name = "B_Remove"
        Me.B_Remove.Size = New System.Drawing.Size(96, 36)
        Me.B_Remove.TabIndex = 84
        Me.B_Remove.Text = "移出 ↑"
        Me.B_Remove.UseVisualStyleBackColor = False
        '
        'F_DLL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_ReCallAll)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_TitleList)
        Me.Controls.Add(Me.T_DeptList)
        Me.Controls.Add(Me.T_GradeList)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_MATCH)
        Me.Controls.Add(Me.T_GRADE)
        Me.Controls.Add(Me.L_GRADE)
        Me.Controls.Add(Me.T_TITLE)
        Me.Controls.Add(Me.L_TITLE)
        Me.Controls.Add(Me.T_DEPT)
        Me.Controls.Add(Me.L_DEPT)
        Me.Controls.Add(Me.B_ReCall)
        Me.Controls.Add(Me.T_RecordNo2)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.B_Remove)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.B_Match)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_DLL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_MATCH.ResumeLayout(False)
        Me.T_MATCH.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents B_Match As System.Windows.Forms.Button
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents B_Remove As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents T_RecordNo2 As System.Windows.Forms.TextBox
    Friend WithEvents B_ReCall As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_GRADE As System.Windows.Forms.ComboBox
    Friend WithEvents L_GRADE As System.Windows.Forms.Label
    Friend WithEvents T_TITLE As System.Windows.Forms.ComboBox
    Friend WithEvents L_TITLE As System.Windows.Forms.Label
    Friend WithEvents T_DEPT As System.Windows.Forms.ComboBox
    Friend WithEvents L_DEPT As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_MATCH As System.Windows.Forms.GroupBox
    Friend WithEvents T_MATCH3 As System.Windows.Forms.RadioButton
    Friend WithEvents T_MATCH2 As System.Windows.Forms.RadioButton
    Friend WithEvents T_MATCH1 As System.Windows.Forms.RadioButton
    Friend WithEvents T_GradeList As System.Windows.Forms.TextBox
    Friend WithEvents T_DeptList As System.Windows.Forms.TextBox
    Friend WithEvents T_TitleList As System.Windows.Forms.TextBox
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents B_ReCallAll As VB_SAMPLE.MyClass_ButtonGeneral
End Class
