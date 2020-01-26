<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Query_1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Query_1))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_Color = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.B_Close1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Output1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Reset1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Query1 = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Remove = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_Select = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Navy
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Items.AddRange(New Object() {"201412", "201411", "201410", "201409", "201408", "201407", "201406", "201405", "201404", "201403", "201402", "201401"})
        Me.ListBox1.Location = New System.Drawing.Point(257, 60)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(120, 172)
        Me.ListBox1.TabIndex = 20
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.White
        Me.ListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox2.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.Navy
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.IntegralHeight = False
        Me.ListBox2.ItemHeight = 24
        Me.ListBox2.Location = New System.Drawing.Point(613, 60)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox2.Size = New System.Drawing.Size(120, 172)
        Me.ListBox2.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(253, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "可選日期"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(609, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "已選日期"
        '
        'T_Color
        '
        Me.T_Color.BackColor = System.Drawing.Color.White
        Me.T_Color.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Color.ForeColor = System.Drawing.Color.Navy
        Me.T_Color.FormattingEnabled = True
        Me.T_Color.ItemHeight = 20
        Me.T_Color.Items.AddRange(New Object() {"顏色 A", "顏色 B", "顏色 C", "顏色 D", "顏色 E"})
        Me.T_Color.Location = New System.Drawing.Point(525, 512)
        Me.T_Color.Name = "T_Color"
        Me.T_Color.Size = New System.Drawing.Size(96, 28)
        Me.T_Color.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(369, 515)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 20)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "變更表單及按鈕顏色"
        '
        'B_Close1
        '
        Me.B_Close1.BackColor = System.Drawing.Color.Black
        Me.B_Close1.BackgroundImage = CType(resources.GetObject("B_Close1.BackgroundImage"), System.Drawing.Image)
        Me.B_Close1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close1.ForeColor = System.Drawing.Color.White
        Me.B_Close1.Location = New System.Drawing.Point(288, 608)
        Me.B_Close1.Name = "B_Close1"
        Me.B_Close1.Size = New System.Drawing.Size(102, 36)
        Me.B_Close1.TabIndex = 41
        Me.B_Close1.Text = "關 閉"
        Me.B_Close1.UseVisualStyleBackColor = False
        '
        'B_Output1
        '
        Me.B_Output1.BackColor = System.Drawing.Color.Black
        Me.B_Output1.BackgroundImage = CType(resources.GetObject("B_Output1.BackgroundImage"), System.Drawing.Image)
        Me.B_Output1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Output1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Output1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Output1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Output1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Output1.ForeColor = System.Drawing.Color.White
        Me.B_Output1.Location = New System.Drawing.Point(600, 608)
        Me.B_Output1.Name = "B_Output1"
        Me.B_Output1.Size = New System.Drawing.Size(102, 36)
        Me.B_Output1.TabIndex = 22
        Me.B_Output1.Text = "匯 出"
        Me.B_Output1.UseVisualStyleBackColor = False
        '
        'B_Reset1
        '
        Me.B_Reset1.BackColor = System.Drawing.Color.Black
        Me.B_Reset1.BackgroundImage = CType(resources.GetObject("B_Reset1.BackgroundImage"), System.Drawing.Image)
        Me.B_Reset1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset1.ForeColor = System.Drawing.Color.White
        Me.B_Reset1.Location = New System.Drawing.Point(392, 608)
        Me.B_Reset1.Name = "B_Reset1"
        Me.B_Reset1.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset1.TabIndex = 19
        Me.B_Reset1.Text = "重 設"
        Me.B_Reset1.UseVisualStyleBackColor = False
        '
        'B_Query1
        '
        Me.B_Query1.BackColor = System.Drawing.Color.Black
        Me.B_Query1.BackgroundImage = CType(resources.GetObject("B_Query1.BackgroundImage"), System.Drawing.Image)
        Me.B_Query1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Query1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Query1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Query1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Query1.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Query1.ForeColor = System.Drawing.Color.White
        Me.B_Query1.Location = New System.Drawing.Point(496, 608)
        Me.B_Query1.Name = "B_Query1"
        Me.B_Query1.Size = New System.Drawing.Size(102, 36)
        Me.B_Query1.TabIndex = 18
        Me.B_Query1.Text = "查 詢"
        Me.B_Query1.UseVisualStyleBackColor = False
        '
        'B_Remove
        '
        Me.B_Remove.BackColor = System.Drawing.Color.Black
        Me.B_Remove.BackgroundImage = CType(resources.GetObject("B_Remove.BackgroundImage"), System.Drawing.Image)
        Me.B_Remove.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Remove.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Remove.ForeColor = System.Drawing.Color.White
        Me.B_Remove.Location = New System.Drawing.Point(444, 158)
        Me.B_Remove.Name = "B_Remove"
        Me.B_Remove.Size = New System.Drawing.Size(102, 36)
        Me.B_Remove.TabIndex = 2
        Me.B_Remove.Text = "← 移 除"
        Me.B_Remove.UseVisualStyleBackColor = False
        '
        'B_Select
        '
        Me.B_Select.BackColor = System.Drawing.Color.Black
        Me.B_Select.BackgroundImage = CType(resources.GetObject("B_Select.BackgroundImage"), System.Drawing.Image)
        Me.B_Select.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Select.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Select.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Select.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Select.ForeColor = System.Drawing.Color.White
        Me.B_Select.Location = New System.Drawing.Point(444, 116)
        Me.B_Select.Name = "B_Select"
        Me.B_Select.Size = New System.Drawing.Size(102, 36)
        Me.B_Select.TabIndex = 0
        Me.B_Select.Text = "選 定 →"
        Me.B_Select.UseVisualStyleBackColor = False
        '
        'F_Query_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_Close1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_Color)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Output1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.B_Reset1)
        Me.Controls.Add(Me.B_Query1)
        Me.Controls.Add(Me.B_Remove)
        Me.Controls.Add(Me.B_Select)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Query_1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Select As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Remove As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Reset1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_Query1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents B_Output1 As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_Color As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents B_Close1 As VB_SAMPLE.MyClass_ButtonGeneral
End Class
