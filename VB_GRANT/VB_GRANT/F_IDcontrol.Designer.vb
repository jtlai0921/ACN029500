<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_IDcontrol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_IDcontrol))
        Me.B_Edit = New System.Windows.Forms.Button()
        Me.B_New = New System.Windows.Forms.Button()
        Me.B_Quit = New System.Windows.Forms.Button()
        Me.B_Delet = New System.Windows.Forms.Button()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C_ID = New System.Windows.Forms.ComboBox()
        Me.T_Ename = New System.Windows.Forms.TextBox()
        Me.T_Dept = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_PassW = New System.Windows.Forms.TextBox()
        Me.B_CusPass = New System.Windows.Forms.Button()
        Me.B_DefaultPass = New System.Windows.Forms.Button()
        Me.T_FirstYes = New System.Windows.Forms.RadioButton()
        Me.T_FirstNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_FirstLogon = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_Administrator = New System.Windows.Forms.TextBox()
        Me.B_ChangeAdmin = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_IDenable = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.T_EnableYes = New System.Windows.Forms.RadioButton()
        Me.T_EnableNo = New System.Windows.Forms.RadioButton()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.B_TOP = New System.Windows.Forms.PictureBox()
        Me.B_PREV = New System.Windows.Forms.PictureBox()
        Me.B_NEXT = New System.Windows.Forms.PictureBox()
        Me.B_BOT = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_Authority = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_TOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_PREV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_NEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B_BOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_Edit
        '
        Me.B_Edit.BackColor = System.Drawing.Color.MidnightBlue
        Me.B_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Edit.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Edit.ForeColor = System.Drawing.Color.White
        Me.B_Edit.Location = New System.Drawing.Point(551, 601)
        Me.B_Edit.Name = "B_Edit"
        Me.B_Edit.Size = New System.Drawing.Size(102, 38)
        Me.B_Edit.TabIndex = 3
        Me.B_Edit.Text = "修 改"
        Me.B_Edit.UseVisualStyleBackColor = False
        '
        'B_New
        '
        Me.B_New.BackColor = System.Drawing.Color.MidnightBlue
        Me.B_New.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_New.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_New.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_New.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_New.ForeColor = System.Drawing.Color.White
        Me.B_New.Location = New System.Drawing.Point(658, 601)
        Me.B_New.Name = "B_New"
        Me.B_New.Size = New System.Drawing.Size(102, 38)
        Me.B_New.TabIndex = 2
        Me.B_New.Text = "新 增"
        Me.B_New.UseVisualStyleBackColor = False
        '
        'B_Quit
        '
        Me.B_Quit.BackColor = System.Drawing.Color.MidnightBlue
        Me.B_Quit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Quit.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Quit.ForeColor = System.Drawing.Color.White
        Me.B_Quit.Location = New System.Drawing.Point(230, 601)
        Me.B_Quit.Name = "B_Quit"
        Me.B_Quit.Size = New System.Drawing.Size(102, 38)
        Me.B_Quit.TabIndex = 6
        Me.B_Quit.Text = "結 束"
        Me.B_Quit.UseVisualStyleBackColor = False
        '
        'B_Delet
        '
        Me.B_Delet.BackColor = System.Drawing.Color.MidnightBlue
        Me.B_Delet.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Delet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_Delet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_Delet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Delet.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Delet.ForeColor = System.Drawing.Color.White
        Me.B_Delet.Location = New System.Drawing.Point(444, 601)
        Me.B_Delet.Name = "B_Delet"
        Me.B_Delet.Size = New System.Drawing.Size(102, 38)
        Me.B_Delet.TabIndex = 4
        Me.B_Delet.Text = "刪 除"
        Me.B_Delet.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.MidnightBlue
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(337, 601)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 38)
        Me.B_Reset.TabIndex = 5
        Me.B_Reset.Text = "重 設"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(346, 309)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "帳號"
        '
        'C_ID
        '
        Me.C_ID.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C_ID.ForeColor = System.Drawing.Color.Navy
        Me.C_ID.FormattingEnabled = True
        Me.C_ID.Location = New System.Drawing.Point(390, 306)
        Me.C_ID.Name = "C_ID"
        Me.C_ID.Size = New System.Drawing.Size(210, 28)
        Me.C_ID.TabIndex = 1
        '
        'T_Ename
        '
        Me.T_Ename.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_Ename.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Ename.ForeColor = System.Drawing.Color.White
        Me.T_Ename.Location = New System.Drawing.Point(390, 341)
        Me.T_Ename.Name = "T_Ename"
        Me.T_Ename.ReadOnly = True
        Me.T_Ename.Size = New System.Drawing.Size(102, 29)
        Me.T_Ename.TabIndex = 14
        '
        'T_Dept
        '
        Me.T_Dept.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_Dept.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Dept.ForeColor = System.Drawing.Color.White
        Me.T_Dept.Location = New System.Drawing.Point(494, 341)
        Me.T_Dept.Name = "T_Dept"
        Me.T_Dept.ReadOnly = True
        Me.T_Dept.Size = New System.Drawing.Size(78, 29)
        Me.T_Dept.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(298, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "姓名及部門"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(346, 380)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "密碼"
        '
        'T_PassW
        '
        Me.T_PassW.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_PassW.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_PassW.ForeColor = System.Drawing.Color.White
        Me.T_PassW.Location = New System.Drawing.Point(390, 376)
        Me.T_PassW.Name = "T_PassW"
        Me.T_PassW.ReadOnly = True
        Me.T_PassW.Size = New System.Drawing.Size(160, 29)
        Me.T_PassW.TabIndex = 17
        '
        'B_CusPass
        '
        Me.B_CusPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_CusPass.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_CusPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_CusPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_CusPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_CusPass.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_CusPass.ForeColor = System.Drawing.Color.White
        Me.B_CusPass.Location = New System.Drawing.Point(554, 376)
        Me.B_CusPass.Name = "B_CusPass"
        Me.B_CusPass.Size = New System.Drawing.Size(72, 29)
        Me.B_CusPass.TabIndex = 7
        Me.B_CusPass.Text = "自 訂"
        Me.B_CusPass.UseVisualStyleBackColor = False
        '
        'B_DefaultPass
        '
        Me.B_DefaultPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_DefaultPass.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_DefaultPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_DefaultPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_DefaultPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_DefaultPass.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_DefaultPass.ForeColor = System.Drawing.Color.White
        Me.B_DefaultPass.Location = New System.Drawing.Point(627, 376)
        Me.B_DefaultPass.Name = "B_DefaultPass"
        Me.B_DefaultPass.Size = New System.Drawing.Size(72, 29)
        Me.B_DefaultPass.TabIndex = 8
        Me.B_DefaultPass.Text = "預 設"
        Me.B_DefaultPass.UseVisualStyleBackColor = False
        '
        'T_FirstYes
        '
        Me.T_FirstYes.AutoSize = True
        Me.T_FirstYes.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_FirstYes.ForeColor = System.Drawing.Color.Navy
        Me.T_FirstYes.Location = New System.Drawing.Point(9, 11)
        Me.T_FirstYes.Name = "T_FirstYes"
        Me.T_FirstYes.Size = New System.Drawing.Size(55, 22)
        Me.T_FirstYes.TabIndex = 21
        Me.T_FirstYes.TabStop = True
        Me.T_FirstYes.Text = "Yes"
        Me.T_FirstYes.UseVisualStyleBackColor = True
        '
        'T_FirstNo
        '
        Me.T_FirstNo.AutoSize = True
        Me.T_FirstNo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_FirstNo.ForeColor = System.Drawing.Color.Navy
        Me.T_FirstNo.Location = New System.Drawing.Point(86, 11)
        Me.T_FirstNo.Name = "T_FirstNo"
        Me.T_FirstNo.Size = New System.Drawing.Size(48, 22)
        Me.T_FirstNo.TabIndex = 22
        Me.T_FirstNo.TabStop = True
        Me.T_FirstNo.Text = "No"
        Me.T_FirstNo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.Controls.Add(Me.T_FirstYes)
        Me.GroupBox1.Controls.Add(Me.T_FirstNo)
        Me.GroupBox1.Location = New System.Drawing.Point(440, 483)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 36)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(314, 494)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "初次登入"
        '
        'T_FirstLogon
        '
        Me.T_FirstLogon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_FirstLogon.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_FirstLogon.ForeColor = System.Drawing.Color.White
        Me.T_FirstLogon.Location = New System.Drawing.Point(390, 490)
        Me.T_FirstLogon.Name = "T_FirstLogon"
        Me.T_FirstLogon.ReadOnly = True
        Me.T_FirstLogon.Size = New System.Drawing.Size(46, 29)
        Me.T_FirstLogon.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(298, 456)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "系統管理員"
        '
        'T_Administrator
        '
        Me.T_Administrator.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_Administrator.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Administrator.ForeColor = System.Drawing.Color.White
        Me.T_Administrator.Location = New System.Drawing.Point(390, 451)
        Me.T_Administrator.Name = "T_Administrator"
        Me.T_Administrator.ReadOnly = True
        Me.T_Administrator.Size = New System.Drawing.Size(46, 29)
        Me.T_Administrator.TabIndex = 26
        '
        'B_ChangeAdmin
        '
        Me.B_ChangeAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.B_ChangeAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ChangeAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple
        Me.B_ChangeAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple
        Me.B_ChangeAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ChangeAdmin.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_ChangeAdmin.ForeColor = System.Drawing.Color.White
        Me.B_ChangeAdmin.Location = New System.Drawing.Point(440, 451)
        Me.B_ChangeAdmin.Name = "B_ChangeAdmin"
        Me.B_ChangeAdmin.Size = New System.Drawing.Size(132, 29)
        Me.B_ChangeAdmin.TabIndex = 9
        Me.B_ChangeAdmin.Text = "更換系統管理員"
        Me.B_ChangeAdmin.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(314, 420)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "啟用帳號"
        '
        'T_IDenable
        '
        Me.T_IDenable.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_IDenable.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_IDenable.ForeColor = System.Drawing.Color.White
        Me.T_IDenable.Location = New System.Drawing.Point(390, 415)
        Me.T_IDenable.Name = "T_IDenable"
        Me.T_IDenable.ReadOnly = True
        Me.T_IDenable.Size = New System.Drawing.Size(46, 29)
        Me.T_IDenable.TabIndex = 30
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox2.Controls.Add(Me.T_EnableYes)
        Me.GroupBox2.Controls.Add(Me.T_EnableNo)
        Me.GroupBox2.Location = New System.Drawing.Point(440, 408)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 36)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        '
        'T_EnableYes
        '
        Me.T_EnableYes.AutoSize = True
        Me.T_EnableYes.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_EnableYes.ForeColor = System.Drawing.Color.Navy
        Me.T_EnableYes.Location = New System.Drawing.Point(9, 11)
        Me.T_EnableYes.Name = "T_EnableYes"
        Me.T_EnableYes.Size = New System.Drawing.Size(55, 22)
        Me.T_EnableYes.TabIndex = 21
        Me.T_EnableYes.TabStop = True
        Me.T_EnableYes.Text = "Yes"
        Me.T_EnableYes.UseVisualStyleBackColor = True
        '
        'T_EnableNo
        '
        Me.T_EnableNo.AutoSize = True
        Me.T_EnableNo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_EnableNo.ForeColor = System.Drawing.Color.Navy
        Me.T_EnableNo.Location = New System.Drawing.Point(86, 11)
        Me.T_EnableNo.Name = "T_EnableNo"
        Me.T_EnableNo.Size = New System.Drawing.Size(48, 22)
        Me.T_EnableNo.TabIndex = 22
        Me.T_EnableNo.TabStop = True
        Me.T_EnableNo.Text = "No"
        Me.T_EnableNo.UseVisualStyleBackColor = True
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.Navy
        Me.T_RecordNo.Location = New System.Drawing.Point(10, 256)
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.Size = New System.Drawing.Size(100, 22)
        Me.T_RecordNo.TabIndex = 34
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
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(10, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(970, 234)
        Me.DataGridView1.TabIndex = 0
        '
        'B_TOP
        '
        Me.B_TOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.B_TOP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.B_TOP.Image = CType(resources.GetObject("B_TOP.Image"), System.Drawing.Image)
        Me.B_TOP.InitialImage = Nothing
        Me.B_TOP.Location = New System.Drawing.Point(820, 256)
        Me.B_TOP.Name = "B_TOP"
        Me.B_TOP.Size = New System.Drawing.Size(33, 32)
        Me.B_TOP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.B_TOP.TabIndex = 35
        Me.B_TOP.TabStop = False
        '
        'B_PREV
        '
        Me.B_PREV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.B_PREV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.B_PREV.Image = CType(resources.GetObject("B_PREV.Image"), System.Drawing.Image)
        Me.B_PREV.InitialImage = Nothing
        Me.B_PREV.Location = New System.Drawing.Point(860, 256)
        Me.B_PREV.Name = "B_PREV"
        Me.B_PREV.Size = New System.Drawing.Size(33, 32)
        Me.B_PREV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.B_PREV.TabIndex = 36
        Me.B_PREV.TabStop = False
        '
        'B_NEXT
        '
        Me.B_NEXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.B_NEXT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.B_NEXT.Image = CType(resources.GetObject("B_NEXT.Image"), System.Drawing.Image)
        Me.B_NEXT.InitialImage = Nothing
        Me.B_NEXT.Location = New System.Drawing.Point(900, 256)
        Me.B_NEXT.Name = "B_NEXT"
        Me.B_NEXT.Size = New System.Drawing.Size(33, 32)
        Me.B_NEXT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.B_NEXT.TabIndex = 37
        Me.B_NEXT.TabStop = False
        '
        'B_BOT
        '
        Me.B_BOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.B_BOT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.B_BOT.Image = CType(resources.GetObject("B_BOT.Image"), System.Drawing.Image)
        Me.B_BOT.InitialImage = Nothing
        Me.B_BOT.Location = New System.Drawing.Point(940, 256)
        Me.B_BOT.Name = "B_BOT"
        Me.B_BOT.Size = New System.Drawing.Size(33, 32)
        Me.B_BOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.B_BOT.TabIndex = 38
        Me.B_BOT.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(330, 532)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "已授權"
        '
        'T_Authority
        '
        Me.T_Authority.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_Authority.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Authority.ForeColor = System.Drawing.Color.White
        Me.T_Authority.Location = New System.Drawing.Point(390, 527)
        Me.T_Authority.Name = "T_Authority"
        Me.T_Authority.ReadOnly = True
        Me.T_Authority.Size = New System.Drawing.Size(46, 29)
        Me.T_Authority.TabIndex = 39
        '
        'F_IDcontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_Authority)
        Me.Controls.Add(Me.B_BOT)
        Me.Controls.Add(Me.B_NEXT)
        Me.Controls.Add(Me.B_PREV)
        Me.Controls.Add(Me.B_TOP)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_IDenable)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.B_ChangeAdmin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_Administrator)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_FirstLogon)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_DefaultPass)
        Me.Controls.Add(Me.B_CusPass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_PassW)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_Dept)
        Me.Controls.Add(Me.T_Ename)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_ID)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_Delet)
        Me.Controls.Add(Me.B_Edit)
        Me.Controls.Add(Me.B_New)
        Me.Controls.Add(Me.B_Quit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_IDcontrol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_TOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_PREV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_NEXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B_BOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Edit As System.Windows.Forms.Button
    Friend WithEvents B_New As System.Windows.Forms.Button
    Friend WithEvents B_Quit As System.Windows.Forms.Button
    Friend WithEvents B_Delet As System.Windows.Forms.Button
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C_ID As System.Windows.Forms.ComboBox
    Friend WithEvents T_Ename As System.Windows.Forms.TextBox
    Friend WithEvents T_Dept As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_PassW As System.Windows.Forms.TextBox
    Friend WithEvents B_CusPass As System.Windows.Forms.Button
    Friend WithEvents B_DefaultPass As System.Windows.Forms.Button
    Friend WithEvents T_FirstYes As System.Windows.Forms.RadioButton
    Friend WithEvents T_FirstNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_FirstLogon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_Administrator As System.Windows.Forms.TextBox
    Friend WithEvents B_ChangeAdmin As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_IDenable As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents T_EnableYes As System.Windows.Forms.RadioButton
    Friend WithEvents T_EnableNo As System.Windows.Forms.RadioButton
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents B_TOP As System.Windows.Forms.PictureBox
    Friend WithEvents B_PREV As System.Windows.Forms.PictureBox
    Friend WithEvents B_NEXT As System.Windows.Forms.PictureBox
    Friend WithEvents B_BOT As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_Authority As System.Windows.Forms.TextBox
End Class
