<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_FileSystem
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_ITEMNAME1 = New System.Windows.Forms.TextBox()
        Me.T_Qty1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_AMT1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_SDATE1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_SDATE2 = New System.Windows.Forms.TextBox()
        Me.T_AMT2 = New System.Windows.Forms.TextBox()
        Me.T_Qty2 = New System.Windows.Forms.TextBox()
        Me.T_ITEMNAME2 = New System.Windows.Forms.TextBox()
        Me.T_SDATE3 = New System.Windows.Forms.TextBox()
        Me.T_AMT3 = New System.Windows.Forms.TextBox()
        Me.T_Qty3 = New System.Windows.Forms.TextBox()
        Me.T_ITEMNAME3 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_B8 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_C5 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_C3 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_C2 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_C4 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B5 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_C1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B7 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B6 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B4 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B3 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B2 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_B1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_04 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_03 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_05 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_02 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_01 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonClose()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(564, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "檔案資訊或資料"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Navy
        Me.RichTextBox1.Location = New System.Drawing.Point(569, 62)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(342, 217)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(565, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "品名"
        '
        'T_ITEMNAME1
        '
        Me.T_ITEMNAME1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ITEMNAME1.ForeColor = System.Drawing.Color.Navy
        Me.T_ITEMNAME1.Location = New System.Drawing.Point(568, 320)
        Me.T_ITEMNAME1.Name = "T_ITEMNAME1"
        Me.T_ITEMNAME1.Size = New System.Drawing.Size(86, 29)
        Me.T_ITEMNAME1.TabIndex = 25
        '
        'T_Qty1
        '
        Me.T_Qty1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Qty1.ForeColor = System.Drawing.Color.Navy
        Me.T_Qty1.Location = New System.Drawing.Point(666, 320)
        Me.T_Qty1.Name = "T_Qty1"
        Me.T_Qty1.Size = New System.Drawing.Size(61, 29)
        Me.T_Qty1.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(662, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "數量"
        '
        'T_AMT1
        '
        Me.T_AMT1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AMT1.ForeColor = System.Drawing.Color.Navy
        Me.T_AMT1.Location = New System.Drawing.Point(739, 320)
        Me.T_AMT1.Name = "T_AMT1"
        Me.T_AMT1.Size = New System.Drawing.Size(100, 29)
        Me.T_AMT1.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(735, 297)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "金額"
        '
        'T_SDATE1
        '
        Me.T_SDATE1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SDATE1.ForeColor = System.Drawing.Color.Navy
        Me.T_SDATE1.Location = New System.Drawing.Point(851, 320)
        Me.T_SDATE1.Name = "T_SDATE1"
        Me.T_SDATE1.Size = New System.Drawing.Size(117, 29)
        Me.T_SDATE1.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(847, 297)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "日期"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(23, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 20)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "請依序由 A1 執行至 C5"
        '
        'T_SDATE2
        '
        Me.T_SDATE2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SDATE2.ForeColor = System.Drawing.Color.Navy
        Me.T_SDATE2.Location = New System.Drawing.Point(851, 355)
        Me.T_SDATE2.Name = "T_SDATE2"
        Me.T_SDATE2.Size = New System.Drawing.Size(117, 29)
        Me.T_SDATE2.TabIndex = 40
        '
        'T_AMT2
        '
        Me.T_AMT2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AMT2.ForeColor = System.Drawing.Color.Navy
        Me.T_AMT2.Location = New System.Drawing.Point(739, 355)
        Me.T_AMT2.Name = "T_AMT2"
        Me.T_AMT2.Size = New System.Drawing.Size(100, 29)
        Me.T_AMT2.TabIndex = 39
        '
        'T_Qty2
        '
        Me.T_Qty2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Qty2.ForeColor = System.Drawing.Color.Navy
        Me.T_Qty2.Location = New System.Drawing.Point(666, 355)
        Me.T_Qty2.Name = "T_Qty2"
        Me.T_Qty2.Size = New System.Drawing.Size(61, 29)
        Me.T_Qty2.TabIndex = 38
        '
        'T_ITEMNAME2
        '
        Me.T_ITEMNAME2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ITEMNAME2.ForeColor = System.Drawing.Color.Navy
        Me.T_ITEMNAME2.Location = New System.Drawing.Point(568, 355)
        Me.T_ITEMNAME2.Name = "T_ITEMNAME2"
        Me.T_ITEMNAME2.Size = New System.Drawing.Size(86, 29)
        Me.T_ITEMNAME2.TabIndex = 37
        '
        'T_SDATE3
        '
        Me.T_SDATE3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SDATE3.ForeColor = System.Drawing.Color.Navy
        Me.T_SDATE3.Location = New System.Drawing.Point(851, 390)
        Me.T_SDATE3.Name = "T_SDATE3"
        Me.T_SDATE3.Size = New System.Drawing.Size(117, 29)
        Me.T_SDATE3.TabIndex = 44
        '
        'T_AMT3
        '
        Me.T_AMT3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AMT3.ForeColor = System.Drawing.Color.Navy
        Me.T_AMT3.Location = New System.Drawing.Point(739, 390)
        Me.T_AMT3.Name = "T_AMT3"
        Me.T_AMT3.Size = New System.Drawing.Size(100, 29)
        Me.T_AMT3.TabIndex = 43
        '
        'T_Qty3
        '
        Me.T_Qty3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Qty3.ForeColor = System.Drawing.Color.Navy
        Me.T_Qty3.Location = New System.Drawing.Point(666, 390)
        Me.T_Qty3.Name = "T_Qty3"
        Me.T_Qty3.Size = New System.Drawing.Size(61, 29)
        Me.T_Qty3.TabIndex = 42
        '
        'T_ITEMNAME3
        '
        Me.T_ITEMNAME3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_ITEMNAME3.ForeColor = System.Drawing.Color.Navy
        Me.T_ITEMNAME3.Location = New System.Drawing.Point(568, 390)
        Me.T_ITEMNAME3.Name = "T_ITEMNAME3"
        Me.T_ITEMNAME3.Size = New System.Drawing.Size(86, 29)
        Me.T_ITEMNAME3.TabIndex = 41
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
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
        Me.DataGridView1.Location = New System.Drawing.Point(569, 438)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(342, 115)
        Me.DataGridView1.TabIndex = 47
        '
        'B_B8
        '
        Me.B_B8.BackColor = System.Drawing.Color.Silver
        Me.B_B8.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B8.ForeColor = System.Drawing.Color.Black
        Me.B_B8.Location = New System.Drawing.Point(192, 456)
        Me.B_B8.Name = "B_B8"
        Me.B_B8.Size = New System.Drawing.Size(136, 36)
        Me.B_B8.TabIndex = 46
        Me.B_B8.Text = "B8 複製資料夾"
        Me.B_B8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B8.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(502, 599)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 45
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_C5
        '
        Me.B_C5.BackColor = System.Drawing.Color.Silver
        Me.B_C5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_C5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_C5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_C5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_C5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_C5.ForeColor = System.Drawing.Color.Black
        Me.B_C5.Location = New System.Drawing.Point(356, 309)
        Me.B_C5.Name = "B_C5"
        Me.B_C5.Size = New System.Drawing.Size(136, 36)
        Me.B_C5.TabIndex = 35
        Me.B_C5.Text = "C5 檔案搜尋"
        Me.B_C5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_C5.UseVisualStyleBackColor = False
        '
        'B_C3
        '
        Me.B_C3.BackColor = System.Drawing.Color.Silver
        Me.B_C3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_C3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_C3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_C3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_C3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_C3.ForeColor = System.Drawing.Color.Black
        Me.B_C3.Location = New System.Drawing.Point(356, 211)
        Me.B_C3.Name = "B_C3"
        Me.B_C3.Size = New System.Drawing.Size(136, 36)
        Me.B_C3.TabIndex = 34
        Me.B_C3.Text = "C3讀取PRN檔"
        Me.B_C3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_C3.UseVisualStyleBackColor = False
        '
        'B_C2
        '
        Me.B_C2.BackColor = System.Drawing.Color.Silver
        Me.B_C2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_C2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_C2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_C2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_C2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_C2.ForeColor = System.Drawing.Color.Black
        Me.B_C2.Location = New System.Drawing.Point(356, 162)
        Me.B_C2.Name = "B_C2"
        Me.B_C2.Size = New System.Drawing.Size(136, 36)
        Me.B_C2.TabIndex = 33
        Me.B_C2.Text = "C2 讀取TSV檔"
        Me.B_C2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_C2.UseVisualStyleBackColor = False
        '
        'B_C4
        '
        Me.B_C4.BackColor = System.Drawing.Color.Silver
        Me.B_C4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_C4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_C4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_C4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_C4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_C4.ForeColor = System.Drawing.Color.Black
        Me.B_C4.Location = New System.Drawing.Point(356, 260)
        Me.B_C4.Name = "B_C4"
        Me.B_C4.Size = New System.Drawing.Size(136, 36)
        Me.B_C4.TabIndex = 32
        Me.B_C4.Text = "C4 讀取隨機檔"
        Me.B_C4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_C4.UseVisualStyleBackColor = False
        '
        'B_B5
        '
        Me.B_B5.BackColor = System.Drawing.Color.Silver
        Me.B_B5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B5.ForeColor = System.Drawing.Color.Black
        Me.B_B5.Location = New System.Drawing.Point(192, 309)
        Me.B_B5.Name = "B_B5"
        Me.B_B5.Size = New System.Drawing.Size(136, 36)
        Me.B_B5.TabIndex = 23
        Me.B_B5.Text = "B5 更換檔名"
        Me.B_B5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B5.UseVisualStyleBackColor = False
        '
        'B_C1
        '
        Me.B_C1.BackColor = System.Drawing.Color.Silver
        Me.B_C1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_C1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_C1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_C1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_C1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_C1.ForeColor = System.Drawing.Color.Black
        Me.B_C1.Location = New System.Drawing.Point(356, 113)
        Me.B_C1.Name = "B_C1"
        Me.B_C1.Size = New System.Drawing.Size(136, 36)
        Me.B_C1.TabIndex = 22
        Me.B_C1.Text = "C1 讀取CSV檔"
        Me.B_C1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_C1.UseVisualStyleBackColor = False
        '
        'B_B7
        '
        Me.B_B7.BackColor = System.Drawing.Color.Silver
        Me.B_B7.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B7.ForeColor = System.Drawing.Color.Black
        Me.B_B7.Location = New System.Drawing.Point(192, 407)
        Me.B_B7.Name = "B_B7"
        Me.B_B7.Size = New System.Drawing.Size(136, 36)
        Me.B_B7.TabIndex = 20
        Me.B_B7.Text = "B7 刪除資料夾"
        Me.B_B7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B7.UseVisualStyleBackColor = False
        '
        'B_B6
        '
        Me.B_B6.BackColor = System.Drawing.Color.Silver
        Me.B_B6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B6.ForeColor = System.Drawing.Color.Black
        Me.B_B6.Location = New System.Drawing.Point(192, 358)
        Me.B_B6.Name = "B_B6"
        Me.B_B6.Size = New System.Drawing.Size(136, 36)
        Me.B_B6.TabIndex = 19
        Me.B_B6.Text = "B6 刪除檔案"
        Me.B_B6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B6.UseVisualStyleBackColor = False
        '
        'B_B4
        '
        Me.B_B4.BackColor = System.Drawing.Color.Silver
        Me.B_B4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B4.ForeColor = System.Drawing.Color.Black
        Me.B_B4.Location = New System.Drawing.Point(192, 260)
        Me.B_B4.Name = "B_B4"
        Me.B_B4.Size = New System.Drawing.Size(136, 36)
        Me.B_B4.TabIndex = 18
        Me.B_B4.Text = "B4 複製檔案"
        Me.B_B4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B4.UseVisualStyleBackColor = False
        '
        'B_B3
        '
        Me.B_B3.BackColor = System.Drawing.Color.Silver
        Me.B_B3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B3.ForeColor = System.Drawing.Color.Black
        Me.B_B3.Location = New System.Drawing.Point(192, 211)
        Me.B_B3.Name = "B_B3"
        Me.B_B3.Size = New System.Drawing.Size(136, 36)
        Me.B_B3.TabIndex = 17
        Me.B_B3.Text = "B3 顯示檔案"
        Me.B_B3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B3.UseVisualStyleBackColor = False
        '
        'B_B2
        '
        Me.B_B2.BackColor = System.Drawing.Color.Silver
        Me.B_B2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B2.ForeColor = System.Drawing.Color.Black
        Me.B_B2.Location = New System.Drawing.Point(192, 162)
        Me.B_B2.Name = "B_B2"
        Me.B_B2.Size = New System.Drawing.Size(136, 36)
        Me.B_B2.TabIndex = 16
        Me.B_B2.Text = "B2 目前路徑"
        Me.B_B2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B2.UseVisualStyleBackColor = False
        '
        'B_B1
        '
        Me.B_B1.BackColor = System.Drawing.Color.Silver
        Me.B_B1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_B1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_B1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_B1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_B1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_B1.ForeColor = System.Drawing.Color.Black
        Me.B_B1.Location = New System.Drawing.Point(192, 113)
        Me.B_B1.Name = "B_B1"
        Me.B_B1.Size = New System.Drawing.Size(136, 36)
        Me.B_B1.TabIndex = 15
        Me.B_B1.Text = "B1 檔案資訊"
        Me.B_B1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_B1.UseVisualStyleBackColor = False
        '
        'B_04
        '
        Me.B_04.BackColor = System.Drawing.Color.Silver
        Me.B_04.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_04.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_04.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_04.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_04.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_04.ForeColor = System.Drawing.Color.Black
        Me.B_04.Location = New System.Drawing.Point(27, 260)
        Me.B_04.Name = "B_04"
        Me.B_04.Size = New System.Drawing.Size(136, 36)
        Me.B_04.TabIndex = 14
        Me.B_04.Text = "A4 寫入PRN檔"
        Me.B_04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_04.UseVisualStyleBackColor = False
        '
        'B_03
        '
        Me.B_03.BackColor = System.Drawing.Color.Silver
        Me.B_03.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_03.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_03.ForeColor = System.Drawing.Color.Black
        Me.B_03.Location = New System.Drawing.Point(27, 211)
        Me.B_03.Name = "B_03"
        Me.B_03.Size = New System.Drawing.Size(136, 36)
        Me.B_03.TabIndex = 13
        Me.B_03.Text = "A3 寫入TSV檔"
        Me.B_03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_03.UseVisualStyleBackColor = False
        '
        'B_05
        '
        Me.B_05.BackColor = System.Drawing.Color.Silver
        Me.B_05.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_05.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_05.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_05.ForeColor = System.Drawing.Color.Black
        Me.B_05.Location = New System.Drawing.Point(27, 309)
        Me.B_05.Name = "B_05"
        Me.B_05.Size = New System.Drawing.Size(136, 36)
        Me.B_05.TabIndex = 12
        Me.B_05.Text = "A5 寫入隨機檔"
        Me.B_05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_05.UseVisualStyleBackColor = False
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.Silver
        Me.B_02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.Black
        Me.B_02.Location = New System.Drawing.Point(27, 162)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(136, 36)
        Me.B_02.TabIndex = 11
        Me.B_02.Text = "A2 寫入CSV檔"
        Me.B_02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_02.UseVisualStyleBackColor = False
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.Silver
        Me.B_01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.Black
        Me.B_01.Location = New System.Drawing.Point(27, 113)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(136, 36)
        Me.B_01.TabIndex = 10
        Me.B_01.Text = "A1 新增資料夾"
        Me.B_01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B_01.UseVisualStyleBackColor = False
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
        Me.B_Close.Location = New System.Drawing.Point(387, 599)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 1
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'F_FileSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_B8)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_SDATE3)
        Me.Controls.Add(Me.T_AMT3)
        Me.Controls.Add(Me.T_Qty3)
        Me.Controls.Add(Me.T_ITEMNAME3)
        Me.Controls.Add(Me.T_SDATE2)
        Me.Controls.Add(Me.T_AMT2)
        Me.Controls.Add(Me.T_Qty2)
        Me.Controls.Add(Me.T_ITEMNAME2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.B_C5)
        Me.Controls.Add(Me.B_C3)
        Me.Controls.Add(Me.B_C2)
        Me.Controls.Add(Me.B_C4)
        Me.Controls.Add(Me.T_SDATE1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_AMT1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_Qty1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_ITEMNAME1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_B5)
        Me.Controls.Add(Me.B_C1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.B_B7)
        Me.Controls.Add(Me.B_B6)
        Me.Controls.Add(Me.B_B4)
        Me.Controls.Add(Me.B_B3)
        Me.Controls.Add(Me.B_B2)
        Me.Controls.Add(Me.B_B1)
        Me.Controls.Add(Me.B_04)
        Me.Controls.Add(Me.B_03)
        Me.Controls.Add(Me.B_05)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.B_01)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.B_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_FileSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonClose
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_01 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_02 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_05 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_03 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_04 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B2 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B3 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B4 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B6 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B7 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents B_C1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B5 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_ITEMNAME1 As System.Windows.Forms.TextBox
    Friend WithEvents T_Qty1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_AMT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_SDATE1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents B_C3 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_C2 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_C4 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_C5 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_SDATE2 As System.Windows.Forms.TextBox
    Friend WithEvents T_AMT2 As System.Windows.Forms.TextBox
    Friend WithEvents T_Qty2 As System.Windows.Forms.TextBox
    Friend WithEvents T_ITEMNAME2 As System.Windows.Forms.TextBox
    Friend WithEvents T_SDATE3 As System.Windows.Forms.TextBox
    Friend WithEvents T_AMT3 As System.Windows.Forms.TextBox
    Friend WithEvents T_Qty3 As System.Windows.Forms.TextBox
    Friend WithEvents T_ITEMNAME3 As System.Windows.Forms.TextBox
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_B8 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
End Class
