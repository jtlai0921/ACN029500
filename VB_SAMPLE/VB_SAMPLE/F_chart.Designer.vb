<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_chart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 10.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 30.0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 20.0R)
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.B_Chart1 = New System.Windows.Forms.Button()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.T_RecordNo = New System.Windows.Forms.TextBox()
        Me.B_Save = New System.Windows.Forms.Button()
        Me.B_Chart2 = New System.Windows.Forms.Button()
        Me.B_Print = New System.Windows.Forms.Button()
        Me.RB_1 = New System.Windows.Forms.RadioButton()
        Me.RB_2 = New System.Windows.Forms.RadioButton()
        Me.RB_3 = New System.Windows.Forms.RadioButton()
        Me.RB_4 = New System.Windows.Forms.RadioButton()
        Me.RB_5 = New System.Windows.Forms.RadioButton()
        Me.RB_6 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New VB_SAMPLE.MyClass_DataGridView()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Reset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Reset.Location = New System.Drawing.Point(498, 607)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 105
        Me.B_Reset.Text = "預設圖型"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_Chart1
        '
        Me.B_Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Chart1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Chart1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Chart1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Chart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Chart1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Chart1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Chart1.Location = New System.Drawing.Point(282, 607)
        Me.B_Chart1.Name = "B_Chart1"
        Me.B_Chart1.Size = New System.Drawing.Size(102, 36)
        Me.B_Chart1.TabIndex = 104
        Me.B_Chart1.Text = "繪 圖 1"
        Me.B_Chart1.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Close.Location = New System.Drawing.Point(174, 607)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 103
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.OldLace
        Me.Chart1.BorderlineColor = System.Drawing.Color.Black
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.Title = "品名"
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.Navy
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        ChartArea1.AxisY.Title = "公噸"
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.Navy
        ChartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisY2.MajorGrid.Enabled = False
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.Navy
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(197, 194)
        Me.Chart1.Name = "Chart1"
        Series1.BorderColor = System.Drawing.Color.Black
        Series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Series1.ChartArea = "ChartArea1"
        Series1.IsVisibleInLegend = False
        Series1.Name = "Series1"
        Series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel
        DataPoint1.AxisLabel = "香蕉"
        DataPoint1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        DataPoint1.Color = System.Drawing.Color.Purple
        DataPoint1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataPoint1.IsValueShownAsLabel = True
        DataPoint1.Label = ""
        DataPoint2.AxisLabel = "蘋果"
        DataPoint2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        DataPoint2.Color = System.Drawing.Color.OrangeRed
        DataPoint2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataPoint2.IsValueShownAsLabel = True
        DataPoint3.AxisLabel = "鳳梨"
        DataPoint3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        DataPoint3.Color = System.Drawing.Color.Teal
        DataPoint3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataPoint3.IsValueShownAsLabel = True
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(596, 388)
        Me.Chart1.TabIndex = 110
        Me.Chart1.Text = "Chart1"
        Title1.Alignment = System.Drawing.ContentAlignment.TopCenter
        Title1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.Navy
        Title1.Name = "Title1"
        Title1.Text = "銷售統計圖"
        Title2.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Title2.ForeColor = System.Drawing.Color.DarkGreen
        Title2.Name = "Title2"
        Title2.Text = "2015年"
        Me.Chart1.Titles.Add(Title1)
        Me.Chart1.Titles.Add(Title2)
        '
        'T_RecordNo
        '
        Me.T_RecordNo.BackColor = System.Drawing.Color.Teal
        Me.T_RecordNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RecordNo.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_RecordNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.T_RecordNo.Location = New System.Drawing.Point(327, 12)
        Me.T_RecordNo.MaxLength = 180
        Me.T_RecordNo.Name = "T_RecordNo"
        Me.T_RecordNo.ReadOnly = True
        Me.T_RecordNo.Size = New System.Drawing.Size(120, 22)
        Me.T_RecordNo.TabIndex = 107
        '
        'B_Save
        '
        Me.B_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Save.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Save.Location = New System.Drawing.Point(606, 607)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(102, 36)
        Me.B_Save.TabIndex = 111
        Me.B_Save.Text = "儲 存"
        Me.B_Save.UseVisualStyleBackColor = False
        '
        'B_Chart2
        '
        Me.B_Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Chart2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Chart2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Chart2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Chart2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Chart2.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Chart2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Chart2.Location = New System.Drawing.Point(390, 607)
        Me.B_Chart2.Name = "B_Chart2"
        Me.B_Chart2.Size = New System.Drawing.Size(102, 36)
        Me.B_Chart2.TabIndex = 112
        Me.B_Chart2.Text = "繪 圖 2"
        Me.B_Chart2.UseVisualStyleBackColor = False
        '
        'B_Print
        '
        Me.B_Print.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.B_Print.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.B_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.B_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Print.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Print.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Print.Location = New System.Drawing.Point(714, 607)
        Me.B_Print.Name = "B_Print"
        Me.B_Print.Size = New System.Drawing.Size(102, 36)
        Me.B_Print.TabIndex = 114
        Me.B_Print.Text = "列 印"
        Me.B_Print.UseVisualStyleBackColor = False
        '
        'RB_1
        '
        Me.RB_1.AutoSize = True
        Me.RB_1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_1.ForeColor = System.Drawing.Color.White
        Me.RB_1.Location = New System.Drawing.Point(33, 35)
        Me.RB_1.Name = "RB_1"
        Me.RB_1.Size = New System.Drawing.Size(85, 28)
        Me.RB_1.TabIndex = 116
        Me.RB_1.TabStop = True
        Me.RB_1.Text = "長條圖"
        Me.RB_1.UseVisualStyleBackColor = True
        '
        'RB_2
        '
        Me.RB_2.AutoSize = True
        Me.RB_2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_2.ForeColor = System.Drawing.Color.White
        Me.RB_2.Location = New System.Drawing.Point(33, 72)
        Me.RB_2.Name = "RB_2"
        Me.RB_2.Size = New System.Drawing.Size(85, 28)
        Me.RB_2.TabIndex = 117
        Me.RB_2.TabStop = True
        Me.RB_2.Text = "折線圖"
        Me.RB_2.UseVisualStyleBackColor = True
        '
        'RB_3
        '
        Me.RB_3.AutoSize = True
        Me.RB_3.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_3.ForeColor = System.Drawing.Color.White
        Me.RB_3.Location = New System.Drawing.Point(33, 109)
        Me.RB_3.Name = "RB_3"
        Me.RB_3.Size = New System.Drawing.Size(85, 28)
        Me.RB_3.TabIndex = 118
        Me.RB_3.TabStop = True
        Me.RB_3.Text = "橫條圖"
        Me.RB_3.UseVisualStyleBackColor = True
        '
        'RB_4
        '
        Me.RB_4.AutoSize = True
        Me.RB_4.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_4.ForeColor = System.Drawing.Color.White
        Me.RB_4.Location = New System.Drawing.Point(153, 35)
        Me.RB_4.Name = "RB_4"
        Me.RB_4.Size = New System.Drawing.Size(85, 28)
        Me.RB_4.TabIndex = 119
        Me.RB_4.TabStop = True
        Me.RB_4.Text = "圓餅圖"
        Me.RB_4.UseVisualStyleBackColor = True
        '
        'RB_5
        '
        Me.RB_5.AutoSize = True
        Me.RB_5.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_5.ForeColor = System.Drawing.Color.White
        Me.RB_5.Location = New System.Drawing.Point(153, 72)
        Me.RB_5.Name = "RB_5"
        Me.RB_5.Size = New System.Drawing.Size(85, 28)
        Me.RB_5.TabIndex = 120
        Me.RB_5.TabStop = True
        Me.RB_5.Text = "區域圖"
        Me.RB_5.UseVisualStyleBackColor = True
        '
        'RB_6
        '
        Me.RB_6.AutoSize = True
        Me.RB_6.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_6.ForeColor = System.Drawing.Color.White
        Me.RB_6.Location = New System.Drawing.Point(153, 109)
        Me.RB_6.Name = "RB_6"
        Me.RB_6.Size = New System.Drawing.Size(85, 28)
        Me.RB_6.TabIndex = 121
        Me.RB_6.TabStop = True
        Me.RB_6.Text = "雷達圖"
        Me.RB_6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_1)
        Me.GroupBox1.Controls.Add(Me.RB_6)
        Me.GroupBox1.Controls.Add(Me.RB_2)
        Me.GroupBox1.Controls.Add(Me.RB_5)
        Me.GroupBox1.Controls.Add(Me.RB_3)
        Me.GroupBox1.Controls.Add(Me.RB_4)
        Me.GroupBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox1.Location = New System.Drawing.Point(681, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 150)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "請敲選一項圖形，再敲『繪圖  1』鈕"
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
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(308, 168)
        Me.DataGridView1.TabIndex = 106
        '
        'F_chart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_Print)
        Me.Controls.Add(Me.B_Chart2)
        Me.Controls.Add(Me.B_Save)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.T_RecordNo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_Chart1)
        Me.Controls.Add(Me.B_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_chart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents B_Chart1 As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents T_RecordNo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As VB_SAMPLE.MyClass_DataGridView
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents B_Chart2 As System.Windows.Forms.Button
    Friend WithEvents B_Print As System.Windows.Forms.Button
    Friend WithEvents RB_1 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_3 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_4 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_5 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_6 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
