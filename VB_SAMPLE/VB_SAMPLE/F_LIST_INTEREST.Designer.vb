<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_LIST_INTEREST
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
        Me.B_OK = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'B_OK
        '
        Me.B_OK.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.B_OK.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_OK.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_OK.ForeColor = System.Drawing.Color.White
        Me.B_OK.Location = New System.Drawing.Point(342, 283)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(102, 36)
        Me.B_OK.TabIndex = 0
        Me.B_OK.Text = "確 定"
        Me.B_OK.UseVisualStyleBackColor = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BackColor = System.Drawing.Color.White
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.ColumnWidth = 150
        Me.CheckedListBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckedListBox1.ForeColor = System.Drawing.Color.Navy
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"籃球", "足球", "棒球", "壘球", "羽球", "網球", "高爾夫球", "排球", "撞球", "其他球類", "慢跑", "快走", "騎車", "游泳", "爬山", "潛水", "溜冰", "健身", "國術", "其他運動", "民族舞", "土風舞", "街舞", "芭蕾", "踢躂舞", "爵士舞", "拉丁舞", "摩登舞", "國標舞 ", "其他舞蹈", "電影欣賞", "藝文欣賞", "聽音樂", "繪畫", "寫作", "編曲", "書法", "歌唱", "樂器演奏", "逛街購物", "泡茶", "釣魚", "養寵物", "閱讀", "攝影", "烹飪", "園藝", "收藏", "旅遊", "其他嗜好"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(758, 244)
        Me.CheckedListBox1.TabIndex = 1
        '
        'F_LIST_INTEREST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(786, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.B_OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_LIST_INTEREST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents B_OK As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
End Class
