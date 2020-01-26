<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Class01
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.B_Import01 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_AccessDB = New System.Windows.Forms.ComboBox()
        Me.L_AccessSQL = New System.Windows.Forms.ComboBox()
        Me.T_AccessDB = New System.Windows.Forms.TextBox()
        Me.T_AccessSQL = New System.Windows.Forms.TextBox()
        Me.B_Import02 = New System.Windows.Forms.Button()
        Me.T_SQLServerName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_SQLDBName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_UserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_Password = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_SqlSelect = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.L_SQLSelect = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_Import01
        '
        Me.B_Import01.BackColor = System.Drawing.Color.OrangeRed
        Me.B_Import01.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Import01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Import01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Import01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Import01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Import01.ForeColor = System.Drawing.Color.White
        Me.B_Import01.Location = New System.Drawing.Point(454, 607)
        Me.B_Import01.Name = "B_Import01"
        Me.B_Import01.Size = New System.Drawing.Size(130, 36)
        Me.B_Import01.TabIndex = 5
        Me.B_Import01.Text = "匯入 Access"
        Me.B_Import01.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(9, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(972, 264)
        Me.DataGridView1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Access 資料庫名稱及其路徑"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 19)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "讀取 Access 資料的指令"
        '
        'L_AccessDB
        '
        Me.L_AccessDB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.L_AccessDB.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_AccessDB.ForeColor = System.Drawing.Color.Navy
        Me.L_AccessDB.FormattingEnabled = True
        Me.L_AccessDB.IntegralHeight = False
        Me.L_AccessDB.Items.AddRange(New Object() {"APPDATA\TAB_ZIPCODE.mdb", "APPDATA\VBACCESSDB.accdb", "APPDATA\StampCollection.mdb"})
        Me.L_AccessDB.Location = New System.Drawing.Point(469, 299)
        Me.L_AccessDB.MaxDropDownItems = 7
        Me.L_AccessDB.MaxLength = 4
        Me.L_AccessDB.Name = "L_AccessDB"
        Me.L_AccessDB.Size = New System.Drawing.Size(35, 28)
        Me.L_AccessDB.TabIndex = 89
        '
        'L_AccessSQL
        '
        Me.L_AccessSQL.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.L_AccessSQL.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_AccessSQL.ForeColor = System.Drawing.Color.Navy
        Me.L_AccessSQL.FormattingEnabled = True
        Me.L_AccessSQL.IntegralHeight = False
        Me.L_AccessSQL.Items.AddRange(New Object() {"Select * From ZIPLIST", "Select datano,description,qty,price,amt,datatime From TEST01", "Select * from STAMP"})
        Me.L_AccessSQL.Location = New System.Drawing.Point(709, 333)
        Me.L_AccessSQL.MaxDropDownItems = 7
        Me.L_AccessSQL.MaxLength = 4
        Me.L_AccessSQL.Name = "L_AccessSQL"
        Me.L_AccessSQL.Size = New System.Drawing.Size(35, 27)
        Me.L_AccessSQL.TabIndex = 90
        '
        'T_AccessDB
        '
        Me.T_AccessDB.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AccessDB.ForeColor = System.Drawing.Color.Navy
        Me.T_AccessDB.Location = New System.Drawing.Point(207, 299)
        Me.T_AccessDB.Name = "T_AccessDB"
        Me.T_AccessDB.Size = New System.Drawing.Size(260, 29)
        Me.T_AccessDB.TabIndex = 91
        '
        'T_AccessSQL
        '
        Me.T_AccessSQL.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_AccessSQL.ForeColor = System.Drawing.Color.Navy
        Me.T_AccessSQL.Location = New System.Drawing.Point(207, 333)
        Me.T_AccessSQL.Name = "T_AccessSQL"
        Me.T_AccessSQL.Size = New System.Drawing.Size(500, 27)
        Me.T_AccessSQL.TabIndex = 92
        '
        'B_Import02
        '
        Me.B_Import02.BackColor = System.Drawing.Color.Teal
        Me.B_Import02.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Import02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Import02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Import02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Import02.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Import02.ForeColor = System.Drawing.Color.White
        Me.B_Import02.Location = New System.Drawing.Point(590, 607)
        Me.B_Import02.Name = "B_Import02"
        Me.B_Import02.Size = New System.Drawing.Size(162, 36)
        Me.B_Import02.TabIndex = 93
        Me.B_Import02.Text = "匯入 SQL Server"
        Me.B_Import02.UseVisualStyleBackColor = False
        '
        'T_SQLServerName
        '
        Me.T_SQLServerName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SQLServerName.ForeColor = System.Drawing.Color.Navy
        Me.T_SQLServerName.Location = New System.Drawing.Point(207, 395)
        Me.T_SQLServerName.Name = "T_SQLServerName"
        Me.T_SQLServerName.Size = New System.Drawing.Size(260, 29)
        Me.T_SQLServerName.TabIndex = 95
        Me.T_SQLServerName.Text = "Localhost\SqlExpress"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(53, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 19)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "SQL Server 執行個體"
        '
        'T_SQLDBName
        '
        Me.T_SQLDBName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SQLDBName.ForeColor = System.Drawing.Color.Navy
        Me.T_SQLDBName.Location = New System.Drawing.Point(207, 430)
        Me.T_SQLDBName.Name = "T_SQLDBName"
        Me.T_SQLDBName.Size = New System.Drawing.Size(178, 29)
        Me.T_SQLDBName.TabIndex = 97
        Me.T_SQLDBName.Text = "VBSQLDB"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(120, 435)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 19)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "資料庫名稱"
        '
        'T_UserName
        '
        Me.T_UserName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_UserName.ForeColor = System.Drawing.Color.Navy
        Me.T_UserName.Location = New System.Drawing.Point(207, 465)
        Me.T_UserName.Name = "T_UserName"
        Me.T_UserName.Size = New System.Drawing.Size(178, 29)
        Me.T_UserName.TabIndex = 99
        Me.T_UserName.Text = "VBUSER01"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(120, 469)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 19)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "使用者名稱"
        '
        'T_Password
        '
        Me.T_Password.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Password.ForeColor = System.Drawing.Color.Navy
        Me.T_Password.Location = New System.Drawing.Point(207, 500)
        Me.T_Password.Name = "T_Password"
        Me.T_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.T_Password.Size = New System.Drawing.Size(178, 29)
        Me.T_Password.TabIndex = 101
        Me.T_Password.Text = "abc-12345"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(120, 505)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 19)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "使用者密碼"
        '
        'T_SqlSelect
        '
        Me.T_SqlSelect.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_SqlSelect.ForeColor = System.Drawing.Color.Navy
        Me.T_SqlSelect.Location = New System.Drawing.Point(207, 535)
        Me.T_SqlSelect.Name = "T_SqlSelect"
        Me.T_SqlSelect.Size = New System.Drawing.Size(650, 27)
        Me.T_SqlSelect.TabIndex = 103
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(135, 540)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "讀取指令"
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.Navy
        Me.T_RecordNo.Location = New System.Drawing.Point(816, 282)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(165, 20)
        Me.T_RecordNo.TabIndex = 104
        Me.T_RecordNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Purple
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(238, 607)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 4
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Olive
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(346, 607)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 105
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'L_SQLSelect
        '
        Me.L_SQLSelect.BackColor = System.Drawing.Color.YellowGreen
        Me.L_SQLSelect.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L_SQLSelect.ForeColor = System.Drawing.Color.Navy
        Me.L_SQLSelect.FormattingEnabled = True
        Me.L_SQLSelect.IntegralHeight = False
        Me.L_SQLSelect.Items.AddRange(New Object() {"Select datano,description,qty,price,amt,datatime From TEST01", "Select STAFF_NO,STAFF_NAME,STAFF_SEX,DEPT_CODE,DEPT_NAME,TITLECODE,TITLE,GRADE,WA" & _
                "GES,FILEDATE From SALARY Where FILEDATE='201412'", "Select * From TAB_DEPT"})
        Me.L_SQLSelect.Location = New System.Drawing.Point(859, 535)
        Me.L_SQLSelect.MaxDropDownItems = 7
        Me.L_SQLSelect.MaxLength = 4
        Me.L_SQLSelect.Name = "L_SQLSelect"
        Me.L_SQLSelect.Size = New System.Drawing.Size(35, 25)
        Me.L_SQLSelect.TabIndex = 106
        '
        'F_Class01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.L_SQLSelect)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.T_SqlSelect)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.T_Password)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.T_UserName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_SQLDBName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_SQLServerName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.B_Import02)
        Me.Controls.Add(Me.T_AccessSQL)
        Me.Controls.Add(Me.T_AccessDB)
        Me.Controls.Add(Me.L_AccessSQL)
        Me.Controls.Add(Me.L_AccessDB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Import01)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Class01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Import01 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_AccessDB As System.Windows.Forms.ComboBox
    Friend WithEvents L_AccessSQL As System.Windows.Forms.ComboBox
    Friend WithEvents T_AccessDB As System.Windows.Forms.TextBox
    Friend WithEvents T_AccessSQL As System.Windows.Forms.TextBox
    Friend WithEvents B_Import02 As System.Windows.Forms.Button
    Friend WithEvents T_SQLServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_SQLDBName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_UserName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_SqlSelect As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents L_SQLSelect As System.Windows.Forms.ComboBox
End Class
