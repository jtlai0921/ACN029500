<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Query_3
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("生產一部")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("生產二部")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("生產三部")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("生產四部")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("工廠", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("人事行政部")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("會計部")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("業務部")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("資訊部")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("管理處", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("品保部")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("品檢部")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("品管處", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VB電子公司", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode10, TreeNode13})
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.B_01 = New System.Windows.Forms.Button()
        Me.B_02 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.B_03 = New System.Windows.Forms.Button()
        Me.B_04 = New System.Windows.Forms.Button()
        Me.B_05 = New System.Windows.Forms.Button()
        Me.B_06 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.B_07 = New System.Windows.Forms.Button()
        Me.B_Modify = New System.Windows.Forms.Button()
        Me.B_Query = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.L_dept = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node1_1"
        TreeNode1.Text = "生產一部"
        TreeNode2.Name = "Node1_2"
        TreeNode2.Text = "生產二部"
        TreeNode3.Name = "Node1_3"
        TreeNode3.Text = "生產三部"
        TreeNode4.Name = "Node1_4"
        TreeNode4.Text = "生產四部"
        TreeNode5.BackColor = System.Drawing.Color.White
        TreeNode5.ForeColor = System.Drawing.Color.Black
        TreeNode5.Name = "Node1"
        TreeNode5.Text = "工廠"
        TreeNode6.Name = "Node2_1"
        TreeNode6.Text = "人事行政部"
        TreeNode7.Name = "Node2_2"
        TreeNode7.Text = "會計部"
        TreeNode8.Name = "Node2_3"
        TreeNode8.Text = "業務部"
        TreeNode9.Name = "Node2_4"
        TreeNode9.Text = "資訊部"
        TreeNode10.Name = "Node2"
        TreeNode10.Text = "管理處"
        TreeNode11.Name = "Node3_1"
        TreeNode11.Text = "品保部"
        TreeNode12.Name = "Node3_2"
        TreeNode12.Text = "品檢部"
        TreeNode13.Name = "Node3"
        TreeNode13.Text = "品管處"
        TreeNode14.BackColor = System.Drawing.Color.White
        TreeNode14.ForeColor = System.Drawing.Color.Black
        TreeNode14.Name = "Node0"
        TreeNode14.Text = "VB電子公司"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode14})
        Me.TreeView1.Size = New System.Drawing.Size(355, 459)
        Me.TreeView1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(725, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 29)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(725, 47)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(136, 29)
        Me.TextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(617, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "目前節點代號"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(617, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "目前節點名稱"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(725, 82)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(136, 29)
        Me.TextBox3.TabIndex = 5
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(725, 117)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(136, 29)
        Me.TextBox4.TabIndex = 6
        '
        'B_01
        '
        Me.B_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_01.ForeColor = System.Drawing.Color.Black
        Me.B_01.Location = New System.Drawing.Point(228, 521)
        Me.B_01.Name = "B_01"
        Me.B_01.Size = New System.Drawing.Size(102, 36)
        Me.B_01.TabIndex = 8
        Me.B_01.Text = "展 開"
        Me.B_01.UseVisualStyleBackColor = False
        '
        'B_02
        '
        Me.B_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_02.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_02.ForeColor = System.Drawing.Color.Black
        Me.B_02.Location = New System.Drawing.Point(336, 521)
        Me.B_02.Name = "B_02"
        Me.B_02.Size = New System.Drawing.Size(102, 36)
        Me.B_02.TabIndex = 9
        Me.B_02.Text = "收 合"
        Me.B_02.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(649, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "總節點數"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(553, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "次節點第二項之節點數"
        '
        'B_03
        '
        Me.B_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_03.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_03.ForeColor = System.Drawing.Color.Black
        Me.B_03.Location = New System.Drawing.Point(444, 521)
        Me.B_03.Name = "B_03"
        Me.B_03.Size = New System.Drawing.Size(102, 36)
        Me.B_03.TabIndex = 12
        Me.B_03.Text = "增加節點"
        Me.B_03.UseVisualStyleBackColor = False
        '
        'B_04
        '
        Me.B_04.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_04.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_04.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_04.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_04.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_04.ForeColor = System.Drawing.Color.Black
        Me.B_04.Location = New System.Drawing.Point(552, 521)
        Me.B_04.Name = "B_04"
        Me.B_04.Size = New System.Drawing.Size(102, 36)
        Me.B_04.TabIndex = 13
        Me.B_04.Text = "移除節點"
        Me.B_04.UseVisualStyleBackColor = False
        '
        'B_05
        '
        Me.B_05.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_05.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_05.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_05.ForeColor = System.Drawing.Color.Black
        Me.B_05.Location = New System.Drawing.Point(660, 521)
        Me.B_05.Name = "B_05"
        Me.B_05.Size = New System.Drawing.Size(102, 36)
        Me.B_05.TabIndex = 14
        Me.B_05.Text = "列出節點"
        Me.B_05.UseVisualStyleBackColor = False
        '
        'B_06
        '
        Me.B_06.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_06.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_06.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_06.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_06.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_06.ForeColor = System.Drawing.Color.Black
        Me.B_06.Location = New System.Drawing.Point(228, 563)
        Me.B_06.Name = "B_06"
        Me.B_06.Size = New System.Drawing.Size(102, 36)
        Me.B_06.TabIndex = 15
        Me.B_06.Text = "尋找節點 2"
        Me.B_06.UseVisualStyleBackColor = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Navy
        Me.RichTextBox1.Location = New System.Drawing.Point(400, 40)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(138, 431)
        Me.RichTextBox1.TabIndex = 16
        Me.RichTextBox1.Text = ""
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.Black
        Me.B_Reset.Location = New System.Drawing.Point(660, 563)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 105
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Close.ForeColor = System.Drawing.Color.Black
        Me.B_Close.Location = New System.Drawing.Point(660, 606)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 106
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(395, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "節點清單"
        '
        'B_07
        '
        Me.B_07.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_07.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_07.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_07.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_07.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_07.ForeColor = System.Drawing.Color.Black
        Me.B_07.Location = New System.Drawing.Point(336, 563)
        Me.B_07.Name = "B_07"
        Me.B_07.Size = New System.Drawing.Size(102, 36)
        Me.B_07.TabIndex = 108
        Me.B_07.Text = "勾選數量"
        Me.B_07.UseVisualStyleBackColor = False
        '
        'B_Modify
        '
        Me.B_Modify.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_Modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Modify.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Modify.ForeColor = System.Drawing.Color.Black
        Me.B_Modify.Location = New System.Drawing.Point(444, 563)
        Me.B_Modify.Name = "B_Modify"
        Me.B_Modify.Size = New System.Drawing.Size(102, 36)
        Me.B_Modify.TabIndex = 109
        Me.B_Modify.Text = "修改節點文字"
        Me.B_Modify.UseVisualStyleBackColor = False
        '
        'B_Query
        '
        Me.B_Query.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.B_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Query.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Query.ForeColor = System.Drawing.Color.Black
        Me.B_Query.Location = New System.Drawing.Point(552, 563)
        Me.B_Query.Name = "B_Query"
        Me.B_Query.Size = New System.Drawing.Size(102, 36)
        Me.B_Query.TabIndex = 110
        Me.B_Query.Text = "查 詢"
        Me.B_Query.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(725, 206)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(136, 29)
        Me.TextBox5.TabIndex = 111
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(725, 241)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(136, 29)
        Me.TextBox6.TabIndex = 112
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(649, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "合計人數"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(649, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "平均薪津"
        '
        'L_dept
        '
        Me.L_dept.AutoSize = True
        Me.L_dept.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_dept.Location = New System.Drawing.Point(730, 176)
        Me.L_dept.Name = "L_dept"
        Me.L_dept.Size = New System.Drawing.Size(0, 20)
        Me.L_dept.TabIndex = 115
        '
        'F_Query_3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.L_dept)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.B_Query)
        Me.Controls.Add(Me.B_Modify)
        Me.Controls.Add(Me.B_07)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.B_06)
        Me.Controls.Add(Me.B_05)
        Me.Controls.Add(Me.B_04)
        Me.Controls.Add(Me.B_03)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.B_02)
        Me.Controls.Add(Me.B_01)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Query_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents B_01 As System.Windows.Forms.Button
    Friend WithEvents B_02 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_03 As System.Windows.Forms.Button
    Friend WithEvents B_04 As System.Windows.Forms.Button
    Friend WithEvents B_05 As System.Windows.Forms.Button
    Friend WithEvents B_06 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents B_07 As System.Windows.Forms.Button
    Friend WithEvents B_Modify As System.Windows.Forms.Button
    Friend WithEvents B_Query As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents L_dept As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
