<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_QueryResult
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_ENO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_NAME = New System.Windows.Forms.TextBox()
        Me.T_DEPTNAME = New System.Windows.Forms.TextBox()
        Me.T_DEPTCODE = New System.Windows.Forms.TextBox()
        Me.T_SEX = New System.Windows.Forms.TextBox()
        Me.T_TITLECODE = New System.Windows.Forms.TextBox()
        Me.T_TITLE = New System.Windows.Forms.TextBox()
        Me.T_GRADE = New System.Windows.Forms.TextBox()
        Me.T_TOTREC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_TOTWAGES = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_TOTALLOWANCE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_TOTMEAL = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_WAGES = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_ALLOWANCE = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_MEAL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.L_ElapsedTime = New System.Windows.Forms.Label()
        Me.B_NEXT = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_PREV = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_BOT = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_TOP = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Export = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_Continue = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonClose()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_RecordNo.Location = New System.Drawing.Point(9, 284)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(201, 20)
        Me.T_RecordNo.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(92, 497)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "等級"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(92, 457)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 20)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "職稱"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(12, 379)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 20)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "部門代號及名稱"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(92, 418)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "性別"
        '
        'T_ENO
        '
        Me.T_ENO.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_ENO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_ENO.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ENO.ForeColor = System.Drawing.Color.White
        Me.T_ENO.Location = New System.Drawing.Point(135, 340)
        Me.T_ENO.MaxLength = 5
        Me.T_ENO.Name = "T_ENO"
        Me.T_ENO.ReadOnly = True
        Me.T_ENO.Size = New System.Drawing.Size(66, 22)
        Me.T_ENO.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(28, 340)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "員工號及姓名"
        '
        'T_NAME
        '
        Me.T_NAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_NAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_NAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_NAME.ForeColor = System.Drawing.Color.White
        Me.T_NAME.Location = New System.Drawing.Point(206, 340)
        Me.T_NAME.MaxLength = 5
        Me.T_NAME.Name = "T_NAME"
        Me.T_NAME.ReadOnly = True
        Me.T_NAME.Size = New System.Drawing.Size(120, 22)
        Me.T_NAME.TabIndex = 56
        '
        'T_DEPTNAME
        '
        Me.T_DEPTNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_DEPTNAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_DEPTNAME.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPTNAME.ForeColor = System.Drawing.Color.White
        Me.T_DEPTNAME.Location = New System.Drawing.Point(206, 379)
        Me.T_DEPTNAME.MaxLength = 5
        Me.T_DEPTNAME.Name = "T_DEPTNAME"
        Me.T_DEPTNAME.ReadOnly = True
        Me.T_DEPTNAME.Size = New System.Drawing.Size(120, 22)
        Me.T_DEPTNAME.TabIndex = 58
        '
        'T_DEPTCODE
        '
        Me.T_DEPTCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_DEPTCODE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_DEPTCODE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DEPTCODE.ForeColor = System.Drawing.Color.White
        Me.T_DEPTCODE.Location = New System.Drawing.Point(135, 379)
        Me.T_DEPTCODE.MaxLength = 5
        Me.T_DEPTCODE.Name = "T_DEPTCODE"
        Me.T_DEPTCODE.ReadOnly = True
        Me.T_DEPTCODE.Size = New System.Drawing.Size(66, 22)
        Me.T_DEPTCODE.TabIndex = 57
        '
        'T_SEX
        '
        Me.T_SEX.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_SEX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_SEX.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SEX.ForeColor = System.Drawing.Color.White
        Me.T_SEX.Location = New System.Drawing.Point(135, 418)
        Me.T_SEX.MaxLength = 5
        Me.T_SEX.Name = "T_SEX"
        Me.T_SEX.ReadOnly = True
        Me.T_SEX.Size = New System.Drawing.Size(64, 22)
        Me.T_SEX.TabIndex = 59
        '
        'T_TITLECODE
        '
        Me.T_TITLECODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_TITLECODE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_TITLECODE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLECODE.ForeColor = System.Drawing.Color.White
        Me.T_TITLECODE.Location = New System.Drawing.Point(135, 457)
        Me.T_TITLECODE.MaxLength = 5
        Me.T_TITLECODE.Name = "T_TITLECODE"
        Me.T_TITLECODE.ReadOnly = True
        Me.T_TITLECODE.Size = New System.Drawing.Size(54, 22)
        Me.T_TITLECODE.TabIndex = 60
        '
        'T_TITLE
        '
        Me.T_TITLE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_TITLE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_TITLE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TITLE.ForeColor = System.Drawing.Color.White
        Me.T_TITLE.Location = New System.Drawing.Point(194, 457)
        Me.T_TITLE.MaxLength = 5
        Me.T_TITLE.Name = "T_TITLE"
        Me.T_TITLE.ReadOnly = True
        Me.T_TITLE.Size = New System.Drawing.Size(146, 22)
        Me.T_TITLE.TabIndex = 61
        '
        'T_GRADE
        '
        Me.T_GRADE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_GRADE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_GRADE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_GRADE.ForeColor = System.Drawing.Color.White
        Me.T_GRADE.Location = New System.Drawing.Point(135, 496)
        Me.T_GRADE.MaxLength = 5
        Me.T_GRADE.Name = "T_GRADE"
        Me.T_GRADE.ReadOnly = True
        Me.T_GRADE.Size = New System.Drawing.Size(72, 22)
        Me.T_GRADE.TabIndex = 62
        '
        'T_TOTREC
        '
        Me.T_TOTREC.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_TOTREC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_TOTREC.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TOTREC.ForeColor = System.Drawing.Color.Navy
        Me.T_TOTREC.Location = New System.Drawing.Point(861, 315)
        Me.T_TOTREC.MaxLength = 5
        Me.T_TOTREC.Name = "T_TOTREC"
        Me.T_TOTREC.ReadOnly = True
        Me.T_TOTREC.Size = New System.Drawing.Size(120, 27)
        Me.T_TOTREC.TabIndex = 65
        Me.T_TOTREC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(788, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "合計筆數"
        '
        'T_TOTWAGES
        '
        Me.T_TOTWAGES.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_TOTWAGES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_TOTWAGES.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TOTWAGES.ForeColor = System.Drawing.Color.Navy
        Me.T_TOTWAGES.Location = New System.Drawing.Point(861, 342)
        Me.T_TOTWAGES.MaxLength = 5
        Me.T_TOTWAGES.Name = "T_TOTWAGES"
        Me.T_TOTWAGES.ReadOnly = True
        Me.T_TOTWAGES.Size = New System.Drawing.Size(120, 27)
        Me.T_TOTWAGES.TabIndex = 67
        Me.T_TOTWAGES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(788, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "合計薪津"
        '
        'T_TOTALLOWANCE
        '
        Me.T_TOTALLOWANCE.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_TOTALLOWANCE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_TOTALLOWANCE.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TOTALLOWANCE.ForeColor = System.Drawing.Color.Navy
        Me.T_TOTALLOWANCE.Location = New System.Drawing.Point(861, 369)
        Me.T_TOTALLOWANCE.MaxLength = 5
        Me.T_TOTALLOWANCE.Name = "T_TOTALLOWANCE"
        Me.T_TOTALLOWANCE.ReadOnly = True
        Me.T_TOTALLOWANCE.Size = New System.Drawing.Size(120, 27)
        Me.T_TOTALLOWANCE.TabIndex = 69
        Me.T_TOTALLOWANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(788, 372)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "合計津貼"
        '
        'T_TOTMEAL
        '
        Me.T_TOTMEAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_TOTMEAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_TOTMEAL.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_TOTMEAL.ForeColor = System.Drawing.Color.Navy
        Me.T_TOTMEAL.Location = New System.Drawing.Point(861, 396)
        Me.T_TOTMEAL.MaxLength = 5
        Me.T_TOTMEAL.Name = "T_TOTMEAL"
        Me.T_TOTMEAL.ReadOnly = True
        Me.T_TOTMEAL.Size = New System.Drawing.Size(120, 27)
        Me.T_TOTMEAL.TabIndex = 71
        Me.T_TOTMEAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(773, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "合計伙食費"
        '
        'T_WAGES
        '
        Me.T_WAGES.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_WAGES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_WAGES.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_WAGES.ForeColor = System.Drawing.Color.White
        Me.T_WAGES.Location = New System.Drawing.Point(416, 340)
        Me.T_WAGES.MaxLength = 5
        Me.T_WAGES.Name = "T_WAGES"
        Me.T_WAGES.ReadOnly = True
        Me.T_WAGES.Size = New System.Drawing.Size(156, 22)
        Me.T_WAGES.TabIndex = 73
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(373, 340)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 20)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "薪津"
        '
        'T_ALLOWANCE
        '
        Me.T_ALLOWANCE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_ALLOWANCE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_ALLOWANCE.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ALLOWANCE.ForeColor = System.Drawing.Color.White
        Me.T_ALLOWANCE.Location = New System.Drawing.Point(416, 379)
        Me.T_ALLOWANCE.MaxLength = 5
        Me.T_ALLOWANCE.Name = "T_ALLOWANCE"
        Me.T_ALLOWANCE.ReadOnly = True
        Me.T_ALLOWANCE.Size = New System.Drawing.Size(156, 22)
        Me.T_ALLOWANCE.TabIndex = 75
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(373, 379)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 20)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "津貼"
        '
        'T_MEAL
        '
        Me.T_MEAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.T_MEAL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_MEAL.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_MEAL.ForeColor = System.Drawing.Color.White
        Me.T_MEAL.Location = New System.Drawing.Point(416, 418)
        Me.T_MEAL.MaxLength = 5
        Me.T_MEAL.Name = "T_MEAL"
        Me.T_MEAL.ReadOnly = True
        Me.T_MEAL.Size = New System.Drawing.Size(156, 22)
        Me.T_MEAL.TabIndex = 77
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(357, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 20)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "伙食費"
        '
        'L_ElapsedTime
        '
        Me.L_ElapsedTime.AutoSize = True
        Me.L_ElapsedTime.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_ElapsedTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.L_ElapsedTime.Location = New System.Drawing.Point(788, 284)
        Me.L_ElapsedTime.Name = "L_ElapsedTime"
        Me.L_ElapsedTime.Size = New System.Drawing.Size(116, 19)
        Me.L_ElapsedTime.TabIndex = 78
        Me.L_ElapsedTime.Text = "耗用時間： 0 秒"
        '
        'B_NEXT
        '
        Me.B_NEXT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.B_NEXT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_NEXT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_NEXT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_NEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NEXT.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_NEXT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.B_NEXT.Location = New System.Drawing.Point(361, 608)
        Me.B_NEXT.Name = "B_NEXT"
        Me.B_NEXT.Size = New System.Drawing.Size(60, 32)
        Me.B_NEXT.TabIndex = 4
        Me.B_NEXT.Text = "下筆"
        Me.B_NEXT.UseVisualStyleBackColor = False
        '
        'B_PREV
        '
        Me.B_PREV.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.B_PREV.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PREV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_PREV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_PREV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PREV.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PREV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.B_PREV.Location = New System.Drawing.Point(298, 608)
        Me.B_PREV.Name = "B_PREV"
        Me.B_PREV.Size = New System.Drawing.Size(60, 32)
        Me.B_PREV.TabIndex = 3
        Me.B_PREV.Text = "前筆"
        Me.B_PREV.UseVisualStyleBackColor = False
        '
        'B_BOT
        '
        Me.B_BOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.B_BOT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_BOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_BOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_BOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_BOT.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_BOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.B_BOT.Location = New System.Drawing.Point(235, 608)
        Me.B_BOT.Name = "B_BOT"
        Me.B_BOT.Size = New System.Drawing.Size(60, 32)
        Me.B_BOT.TabIndex = 2
        Me.B_BOT.Text = "末筆"
        Me.B_BOT.UseVisualStyleBackColor = False
        '
        'B_TOP
        '
        Me.B_TOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.B_TOP.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_TOP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_TOP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_TOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_TOP.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_TOP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.B_TOP.Location = New System.Drawing.Point(172, 608)
        Me.B_TOP.Name = "B_TOP"
        Me.B_TOP.Size = New System.Drawing.Size(60, 32)
        Me.B_TOP.TabIndex = 1
        Me.B_TOP.Text = "首筆"
        Me.B_TOP.UseVisualStyleBackColor = False
        '
        'B_Export
        '
        Me.B_Export.BackColor = System.Drawing.Color.Teal
        Me.B_Export.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Export.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Export.ForeColor = System.Drawing.Color.White
        Me.B_Export.Location = New System.Drawing.Point(717, 604)
        Me.B_Export.Name = "B_Export"
        Me.B_Export.Size = New System.Drawing.Size(102, 36)
        Me.B_Export.TabIndex = 7
        Me.B_Export.Text = "匯 出"
        Me.B_Export.UseVisualStyleBackColor = False
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
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.DataGridView1.Location = New System.Drawing.Point(9, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(972, 264)
        Me.DataGridView1.TabIndex = 2
        '
        'B_Continue
        '
        Me.B_Continue.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_Continue.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Continue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Continue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Continue.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Continue.ForeColor = System.Drawing.Color.White
        Me.B_Continue.Location = New System.Drawing.Point(609, 604)
        Me.B_Continue.Name = "B_Continue"
        Me.B_Continue.Size = New System.Drawing.Size(102, 36)
        Me.B_Continue.TabIndex = 6
        Me.B_Continue.Text = "繼 續"
        Me.B_Continue.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.MediumVioletRed
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(501, 604)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 5
        Me.B_Close.Text = "結 束"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'F_QueryResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.L_ElapsedTime)
        Me.Controls.Add(Me.B_NEXT)
        Me.Controls.Add(Me.B_PREV)
        Me.Controls.Add(Me.B_BOT)
        Me.Controls.Add(Me.B_TOP)
        Me.Controls.Add(Me.T_MEAL)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.T_ALLOWANCE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.T_WAGES)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.T_TOTMEAL)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_TOTALLOWANCE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_TOTWAGES)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_TOTREC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Export)
        Me.Controls.Add(Me.T_GRADE)
        Me.Controls.Add(Me.T_TITLE)
        Me.Controls.Add(Me.T_TITLECODE)
        Me.Controls.Add(Me.T_SEX)
        Me.Controls.Add(Me.T_DEPTNAME)
        Me.Controls.Add(Me.T_DEPTCODE)
        Me.Controls.Add(Me.T_NAME)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_ENO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Continue)
        Me.Controls.Add(Me.B_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_QueryResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents B_Continue As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_ENO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_NAME As System.Windows.Forms.TextBox
    Friend WithEvents T_DEPTNAME As System.Windows.Forms.TextBox
    Friend WithEvents T_DEPTCODE As System.Windows.Forms.TextBox
    Friend WithEvents T_SEX As System.Windows.Forms.TextBox
    Friend WithEvents T_TITLECODE As System.Windows.Forms.TextBox
    Friend WithEvents T_TITLE As System.Windows.Forms.TextBox
    Friend WithEvents T_GRADE As System.Windows.Forms.TextBox
    Friend WithEvents B_Export As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_TOTREC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_TOTWAGES As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_TOTALLOWANCE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_TOTMEAL As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_WAGES As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents T_ALLOWANCE As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents T_MEAL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents B_TOP As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_BOT As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_PREV As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_NEXT As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents L_ElapsedTime As System.Windows.Forms.Label
End Class
