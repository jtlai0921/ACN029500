<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Query_2
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.B_Reset = New System.Windows.Forms.Button()
        Me.B_Close = New System.Windows.Forms.Button()
        Me.T_WEB = New System.Windows.Forms.ComboBox()
        Me.Label01 = New System.Windows.Forms.Label()
        Me.B_LoadFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(8, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(975, 461)
        Me.WebBrowser1.TabIndex = 22
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Cornsilk
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 470)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(578, 172)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = ""
        '
        'B_Reset
        '
        Me.B_Reset.BackColor = System.Drawing.Color.Teal
        Me.B_Reset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reset.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Reset.ForeColor = System.Drawing.Color.White
        Me.B_Reset.Location = New System.Drawing.Point(765, 606)
        Me.B_Reset.Name = "B_Reset"
        Me.B_Reset.Size = New System.Drawing.Size(102, 36)
        Me.B_Reset.TabIndex = 107
        Me.B_Reset.Text = "Reset"
        Me.B_Reset.UseVisualStyleBackColor = False
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.OrangeRed
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(657, 606)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 106
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'T_WEB
        '
        Me.T_WEB.BackColor = System.Drawing.Color.White
        Me.T_WEB.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_WEB.ForeColor = System.Drawing.Color.Navy
        Me.T_WEB.FormattingEnabled = True
        Me.T_WEB.IntegralHeight = False
        Me.T_WEB.ItemHeight = 20
        Me.T_WEB.Items.AddRange(New Object() {"Google", "奇摩", "石門水庫水情資訊", "中華郵政", "微軟"})
        Me.T_WEB.Location = New System.Drawing.Point(657, 485)
        Me.T_WEB.MaxDropDownItems = 7
        Me.T_WEB.Name = "T_WEB"
        Me.T_WEB.Size = New System.Drawing.Size(207, 28)
        Me.T_WEB.TabIndex = 108
        '
        'Label01
        '
        Me.Label01.AutoSize = True
        Me.Label01.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label01.ForeColor = System.Drawing.Color.White
        Me.Label01.Location = New System.Drawing.Point(605, 487)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(48, 24)
        Me.Label01.TabIndex = 109
        Me.Label01.Text = "網站"
        '
        'B_LoadFile
        '
        Me.B_LoadFile.BackColor = System.Drawing.Color.Purple
        Me.B_LoadFile.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_LoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_LoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_LoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_LoadFile.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_LoadFile.ForeColor = System.Drawing.Color.White
        Me.B_LoadFile.Location = New System.Drawing.Point(873, 606)
        Me.B_LoadFile.Name = "B_LoadFile"
        Me.B_LoadFile.Size = New System.Drawing.Size(102, 36)
        Me.B_LoadFile.TabIndex = 110
        Me.B_LoadFile.Text = "Load File"
        Me.B_LoadFile.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'F_Query_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_LoadFile)
        Me.Controls.Add(Me.T_WEB)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.B_Reset)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_Query_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents B_Reset As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents T_WEB As System.Windows.Forms.ComboBox
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents B_LoadFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
