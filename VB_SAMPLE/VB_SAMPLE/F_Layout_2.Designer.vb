<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Layout_2
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MyClass_DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.L_RecordNo = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Query = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.T_DGV_Height = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.B_ADJ = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_GridDefault = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Selection = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Font = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.T_Form_Width = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_Form_Height = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.B_FormSize = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_FormSizeO = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.B_Close = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.MyClass_DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.T_DGV_Height, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MyClass_DataGridView1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.L_RecordNo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBox1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(900, 573)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'MyClass_DataGridView1
        '
        Me.MyClass_DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        Me.MyClass_DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MyClass_DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyClass_DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MyClass_DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.MyClass_DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MyClass_DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MyClass_DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MyClass_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.MyClass_DataGridView1, 4)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MyClass_DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.MyClass_DataGridView1.EnableHeadersVisualStyles = False
        Me.MyClass_DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.MyClass_DataGridView1.Name = "MyClass_DataGridView1"
        Me.MyClass_DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MyClass_DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.MyClass_DataGridView1.RowHeadersWidth = 60
        Me.MyClass_DataGridView1.RowTemplate.Height = 24
        Me.MyClass_DataGridView1.Size = New System.Drawing.Size(888, 194)
        Me.MyClass_DataGridView1.TabIndex = 0
        '
        'L_RecordNo
        '
        Me.L_RecordNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.L_RecordNo.Dock = System.Windows.Forms.DockStyle.Top
        Me.L_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_RecordNo.ForeColor = System.Drawing.Color.Navy
        Me.L_RecordNo.Location = New System.Drawing.Point(766, 206)
        Me.L_RecordNo.Name = "L_RecordNo"
        Me.L_RecordNo.Size = New System.Drawing.Size(128, 20)
        Me.L_RecordNo.TabIndex = 4
        Me.L_RecordNo.Text = "合計筆數： 0"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Navy
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Items.AddRange(New Object() {"水果", "昆蟲", "風景", "動物", "鳥類", "民俗", "花卉", "飛機", "人物", "名畫", "名著", "傳說", "遺產", "戲劇"})
        Me.ListBox1.Location = New System.Drawing.Point(643, 237)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(114, 104)
        Me.ListBox1.TabIndex = 5
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.B_Reset, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.B_Query, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(766, 237)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(105, 93)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(3, 49)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(90, 36)
        Me.B_Reset.TabIndex = 7
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_Query
        '
        Me.B_Query.BackColor = System.Drawing.Color.Teal
        Me.B_Query.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Query.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Query.ForeColor = System.Drawing.Color.White
        Me.B_Query.Location = New System.Drawing.Point(3, 3)
        Me.B_Query.Name = "B_Query"
        Me.B_Query.Size = New System.Drawing.Size(90, 36)
        Me.B_Query.TabIndex = 6
        Me.B_Query.Text = "查 詢"
        Me.B_Query.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureBox1, 2)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 209)
        Me.PictureBox1.Name = "PictureBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.PictureBox1, 3)
        Me.PictureBox1.Size = New System.Drawing.Size(376, 190)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.T_DGV_Height, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(65, 431)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(200, 76)
        Me.TableLayoutPanel6.TabIndex = 11
        '
        'T_DGV_Height
        '
        Me.T_DGV_Height.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T_DGV_Height.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_DGV_Height.ForeColor = System.Drawing.Color.Navy
        Me.T_DGV_Height.Location = New System.Drawing.Point(137, 3)
        Me.T_DGV_Height.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.T_DGV_Height.Minimum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.T_DGV_Height.Name = "T_DGV_Height"
        Me.T_DGV_Height.Size = New System.Drawing.Size(60, 29)
        Me.T_DGV_Height.TabIndex = 8
        Me.T_DGV_Height.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(84, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "DataGridView"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.B_ADJ, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.B_GridDefault, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.B_Selection, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.B_Font, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(274, 431)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(193, 76)
        Me.TableLayoutPanel3.TabIndex = 8
        '
        'B_ADJ
        '
        Me.B_ADJ.BackColor = System.Drawing.Color.Purple
        Me.B_ADJ.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ADJ.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_ADJ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ADJ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ADJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ADJ.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_ADJ.ForeColor = System.Drawing.Color.White
        Me.B_ADJ.Location = New System.Drawing.Point(3, 3)
        Me.B_ADJ.Name = "B_ADJ"
        Me.B_ADJ.Size = New System.Drawing.Size(90, 32)
        Me.B_ADJ.TabIndex = 53
        Me.B_ADJ.Text = "調整列高"
        Me.B_ADJ.UseVisualStyleBackColor = False
        '
        'B_GridDefault
        '
        Me.B_GridDefault.BackColor = System.Drawing.Color.Purple
        Me.B_GridDefault.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GridDefault.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_GridDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GridDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GridDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GridDefault.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_GridDefault.ForeColor = System.Drawing.Color.White
        Me.B_GridDefault.Location = New System.Drawing.Point(99, 41)
        Me.B_GridDefault.Name = "B_GridDefault"
        Me.B_GridDefault.Size = New System.Drawing.Size(90, 32)
        Me.B_GridDefault.TabIndex = 65
        Me.B_GridDefault.Text = "還 原"
        Me.B_GridDefault.UseVisualStyleBackColor = False
        '
        'B_Selection
        '
        Me.B_Selection.BackColor = System.Drawing.Color.Purple
        Me.B_Selection.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Selection.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_Selection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Selection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Selection.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Selection.ForeColor = System.Drawing.Color.White
        Me.B_Selection.Location = New System.Drawing.Point(3, 41)
        Me.B_Selection.Name = "B_Selection"
        Me.B_Selection.Size = New System.Drawing.Size(90, 32)
        Me.B_Selection.TabIndex = 66
        Me.B_Selection.Text = "調整選區"
        Me.B_Selection.UseVisualStyleBackColor = False
        '
        'B_Font
        '
        Me.B_Font.BackColor = System.Drawing.Color.Purple
        Me.B_Font.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Font.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_Font.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Font.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Font.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Font.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Font.ForeColor = System.Drawing.Color.White
        Me.B_Font.Location = New System.Drawing.Point(99, 3)
        Me.B_Font.Name = "B_Font"
        Me.B_Font.Size = New System.Drawing.Size(90, 32)
        Me.B_Font.TabIndex = 60
        Me.B_Font.Text = "調整字型"
        Me.B_Font.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.T_Form_Width, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.T_Form_Height, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(586, 431)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(171, 76)
        Me.TableLayoutPanel5.TabIndex = 10
        '
        'T_Form_Width
        '
        Me.T_Form_Width.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Form_Width.ForeColor = System.Drawing.Color.Navy
        Me.T_Form_Width.Location = New System.Drawing.Point(88, 3)
        Me.T_Form_Width.MaxLength = 4
        Me.T_Form_Width.Name = "T_Form_Width"
        Me.T_Form_Width.Size = New System.Drawing.Size(70, 29)
        Me.T_Form_Width.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(9, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "表單高度"
        '
        'T_Form_Height
        '
        Me.T_Form_Height.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Form_Height.ForeColor = System.Drawing.Color.Navy
        Me.T_Form_Height.Location = New System.Drawing.Point(88, 41)
        Me.T_Form_Height.MaxLength = 4
        Me.T_Form_Height.Name = "T_Form_Height"
        Me.T_Form_Height.Size = New System.Drawing.Size(70, 29)
        Me.T_Form_Height.TabIndex = 52
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(9, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "表單寬度"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.B_FormSize, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.B_FormSizeO, 0, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(766, 431)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(105, 75)
        Me.TableLayoutPanel4.TabIndex = 9
        '
        'B_FormSize
        '
        Me.B_FormSize.BackColor = System.Drawing.Color.SlateBlue
        Me.B_FormSize.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_FormSize.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_FormSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_FormSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_FormSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_FormSize.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_FormSize.ForeColor = System.Drawing.Color.White
        Me.B_FormSize.Location = New System.Drawing.Point(3, 3)
        Me.B_FormSize.Name = "B_FormSize"
        Me.B_FormSize.Size = New System.Drawing.Size(90, 31)
        Me.B_FormSize.TabIndex = 61
        Me.B_FormSize.Text = "設定大小"
        Me.B_FormSize.UseVisualStyleBackColor = False
        '
        'B_FormSizeO
        '
        Me.B_FormSizeO.BackColor = System.Drawing.Color.SlateBlue
        Me.B_FormSizeO.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_FormSizeO.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.B_FormSizeO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_FormSizeO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_FormSizeO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_FormSizeO.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_FormSizeO.ForeColor = System.Drawing.Color.White
        Me.B_FormSizeO.Location = New System.Drawing.Point(3, 40)
        Me.B_FormSizeO.Name = "B_FormSizeO"
        Me.B_FormSizeO.Size = New System.Drawing.Size(90, 32)
        Me.B_FormSizeO.TabIndex = 62
        Me.B_FormSizeO.Text = "還原大小"
        Me.B_FormSizeO.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.B_Close, 1, 0)
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(274, 524)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(296, 43)
        Me.TableLayoutPanel7.TabIndex = 12
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Tomato
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(121, 3)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(96, 37)
        Me.B_Close.TabIndex = 7
        Me.B_Close.Text = "離 開"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.Color.Navy
        Me.FontDialog1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        '
        'F_Layout_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(914, 581)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "F_Layout_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "表格式面板配置控制項的應用"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.MyClass_DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.T_DGV_Height, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MyClass_DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents L_RecordNo As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents B_Query As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Close As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_DGV_Height As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_Form_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents T_Form_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents B_ADJ As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents B_Font As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_FormSize As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_FormSizeO As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_GridDefault As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Selection As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
End Class
