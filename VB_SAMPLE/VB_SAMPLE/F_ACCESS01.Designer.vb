﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ACCESS01
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
        Me.T_price = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_qty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_FileName = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.T_description = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_Path = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_datano = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        Me.B_Reset = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_NULL = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Delete = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Modify = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_ADD = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Query = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_PickUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_FileSize = New System.Windows.Forms.TextBox()
        Me.B_Close = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.Navy
        Me.T_RecordNo.Location = New System.Drawing.Point(10, 238)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(201, 22)
        Me.T_RecordNo.TabIndex = 71
        '
        'T_price
        '
        Me.T_price.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_price.Location = New System.Drawing.Point(694, 337)
        Me.T_price.MaxLength = 18
        Me.T_price.Name = "T_price"
        Me.T_price.Size = New System.Drawing.Size(145, 29)
        Me.T_price.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(650, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "單價"
        '
        'T_qty
        '
        Me.T_qty.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_qty.Location = New System.Drawing.Point(511, 337)
        Me.T_qty.MaxLength = 12
        Me.T_qty.Name = "T_qty"
        Me.T_qty.Size = New System.Drawing.Size(120, 29)
        Me.T_qty.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(468, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "數量"
        '
        'T_FileName
        '
        Me.T_FileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.T_FileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_FileName.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_FileName.ForeColor = System.Drawing.Color.Navy
        Me.T_FileName.Location = New System.Drawing.Point(511, 423)
        Me.T_FileName.MaxLength = 180
        Me.T_FileName.Name = "T_FileName"
        Me.T_FileName.ReadOnly = True
        Me.T_FileName.Size = New System.Drawing.Size(201, 22)
        Me.T_FileName.TabIndex = 64
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(10, 341)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(278, 305)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        '
        'T_description
        '
        Me.T_description.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_description.Location = New System.Drawing.Point(694, 290)
        Me.T_description.MaxLength = 36
        Me.T_description.Name = "T_description"
        Me.T_description.Size = New System.Drawing.Size(265, 29)
        Me.T_description.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(650, 294)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "說明"
        '
        'T_Path
        '
        Me.T_Path.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Path.Location = New System.Drawing.Point(511, 384)
        Me.T_Path.MaxLength = 180
        Me.T_Path.Name = "T_Path"
        Me.T_Path.Size = New System.Drawing.Size(470, 29)
        Me.T_Path.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(356, 388)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "圖片檔之檔名及路徑"
        '
        'T_datano
        '
        Me.T_datano.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_datano.Location = New System.Drawing.Point(511, 290)
        Me.T_datano.MaxLength = 6
        Me.T_datano.Name = "T_datano"
        Me.T_datano.Size = New System.Drawing.Size(95, 29)
        Me.T_datano.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(435, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "資料編號"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGreen
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
        Me.DataGridView1.Location = New System.Drawing.Point(10, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(972, 221)
        Me.DataGridView1.TabIndex = 73
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.SeaGreen
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(879, 461)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 72
        Me.B_Reset.Text = "清空文字盒"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_NULL
        '
        Me.B_NULL.BackColor = System.Drawing.Color.Teal
        Me.B_NULL.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_NULL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_NULL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_NULL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_NULL.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_NULL.ForeColor = System.Drawing.Color.White
        Me.B_NULL.Location = New System.Drawing.Point(879, 599)
        Me.B_NULL.Name = "B_NULL"
        Me.B_NULL.Size = New System.Drawing.Size(102, 36)
        Me.B_NULL.TabIndex = 65
        Me.B_NULL.Text = "Null"
        Me.B_NULL.UseVisualStyleBackColor = False
        '
        'B_Delete
        '
        Me.B_Delete.BackColor = System.Drawing.Color.Teal
        Me.B_Delete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Delete.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Delete.ForeColor = System.Drawing.Color.White
        Me.B_Delete.Location = New System.Drawing.Point(771, 599)
        Me.B_Delete.Name = "B_Delete"
        Me.B_Delete.Size = New System.Drawing.Size(102, 36)
        Me.B_Delete.TabIndex = 62
        Me.B_Delete.Text = "刪 除"
        Me.B_Delete.UseVisualStyleBackColor = False
        '
        'B_Modify
        '
        Me.B_Modify.BackColor = System.Drawing.Color.Teal
        Me.B_Modify.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Modify.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Modify.ForeColor = System.Drawing.Color.White
        Me.B_Modify.Location = New System.Drawing.Point(663, 599)
        Me.B_Modify.Name = "B_Modify"
        Me.B_Modify.Size = New System.Drawing.Size(102, 36)
        Me.B_Modify.TabIndex = 61
        Me.B_Modify.Text = "修 改"
        Me.B_Modify.UseVisualStyleBackColor = False
        '
        'B_ADD
        '
        Me.B_ADD.BackColor = System.Drawing.Color.Teal
        Me.B_ADD.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ADD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ADD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ADD.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_ADD.ForeColor = System.Drawing.Color.White
        Me.B_ADD.Location = New System.Drawing.Point(555, 599)
        Me.B_ADD.Name = "B_ADD"
        Me.B_ADD.Size = New System.Drawing.Size(102, 36)
        Me.B_ADD.TabIndex = 60
        Me.B_ADD.Text = "新 增"
        Me.B_ADD.UseVisualStyleBackColor = False
        '
        'B_Query
        '
        Me.B_Query.BackColor = System.Drawing.Color.Teal
        Me.B_Query.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Query.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Query.ForeColor = System.Drawing.Color.White
        Me.B_Query.Location = New System.Drawing.Point(447, 599)
        Me.B_Query.Name = "B_Query"
        Me.B_Query.Size = New System.Drawing.Size(102, 36)
        Me.B_Query.TabIndex = 59
        Me.B_Query.Text = "查 詢"
        Me.B_Query.UseVisualStyleBackColor = False
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
        Me.B_PickUp.Location = New System.Drawing.Point(879, 419)
        Me.B_PickUp.Name = "B_PickUp"
        Me.B_PickUp.Size = New System.Drawing.Size(102, 36)
        Me.B_PickUp.TabIndex = 52
        Me.B_PickUp.Text = "選取圖片"
        Me.B_PickUp.UseVisualStyleBackColor = False
        '
        'T_FileSize
        '
        Me.T_FileSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.T_FileSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_FileSize.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_FileSize.ForeColor = System.Drawing.Color.Navy
        Me.T_FileSize.Location = New System.Drawing.Point(511, 455)
        Me.T_FileSize.MaxLength = 180
        Me.T_FileSize.Name = "T_FileSize"
        Me.T_FileSize.ReadOnly = True
        Me.T_FileSize.Size = New System.Drawing.Size(201, 22)
        Me.T_FileSize.TabIndex = 70
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.Teal
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(339, 599)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 74
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'F_ACCESS01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.T_FileSize)
        Me.Controls.Add(Me.T_price)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T_qty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.B_NULL)
        Me.Controls.Add(Me.T_FileName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.B_Delete)
        Me.Controls.Add(Me.B_Modify)
        Me.Controls.Add(Me.B_ADD)
        Me.Controls.Add(Me.B_Query)
        Me.Controls.Add(Me.T_description)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_Path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_datano)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_PickUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_ACCESS01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Reset As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents T_price As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T_qty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_NULL As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_FileName As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents B_Delete As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Modify As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_ADD As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Query As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_description As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_datano As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_PickUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents T_FileSize As System.Windows.Forms.TextBox
    Friend WithEvents B_Close As System.Windows.Forms.Button
End Class
