<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_TableMaintMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TableMaintMenu))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_FileKind = New System.Windows.Forms.GroupBox()
        Me.T_Table03 = New System.Windows.Forms.RadioButton()
        Me.T_Table02 = New System.Windows.Forms.RadioButton()
        Me.T_Table01 = New System.Windows.Forms.RadioButton()
        Me.B_GO = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.B_GiveUp = New VB_SAMPLE.MyClass_ButtonGeneral()
        Me.T_FileKind.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(267, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(287, 19)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "請點選欲維護的對照表，再敲『GO』鈕。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(180, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "對照表名稱"
        '
        'T_FileKind
        '
        Me.T_FileKind.BackgroundImage = CType(resources.GetObject("T_FileKind.BackgroundImage"), System.Drawing.Image)
        Me.T_FileKind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.T_FileKind.Controls.Add(Me.T_Table03)
        Me.T_FileKind.Controls.Add(Me.T_Table02)
        Me.T_FileKind.Controls.Add(Me.T_Table01)
        Me.T_FileKind.Location = New System.Drawing.Point(271, 59)
        Me.T_FileKind.Name = "T_FileKind"
        Me.T_FileKind.Size = New System.Drawing.Size(150, 159)
        Me.T_FileKind.TabIndex = 64
        Me.T_FileKind.TabStop = False
        '
        'T_Table03
        '
        Me.T_Table03.AutoSize = True
        Me.T_Table03.BackColor = System.Drawing.Color.Transparent
        Me.T_Table03.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Table03.ForeColor = System.Drawing.Color.Navy
        Me.T_Table03.Location = New System.Drawing.Point(7, 108)
        Me.T_Table03.Name = "T_Table03"
        Me.T_Table03.Size = New System.Drawing.Size(72, 31)
        Me.T_Table03.TabIndex = 3
        Me.T_Table03.Text = "等級"
        Me.T_Table03.UseVisualStyleBackColor = False
        '
        'T_Table02
        '
        Me.T_Table02.AutoSize = True
        Me.T_Table02.BackColor = System.Drawing.Color.Transparent
        Me.T_Table02.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Table02.ForeColor = System.Drawing.Color.Navy
        Me.T_Table02.Location = New System.Drawing.Point(7, 61)
        Me.T_Table02.Name = "T_Table02"
        Me.T_Table02.Size = New System.Drawing.Size(72, 31)
        Me.T_Table02.TabIndex = 2
        Me.T_Table02.Text = "職稱"
        Me.T_Table02.UseVisualStyleBackColor = False
        '
        'T_Table01
        '
        Me.T_Table01.AutoSize = True
        Me.T_Table01.BackColor = System.Drawing.Color.Transparent
        Me.T_Table01.Checked = True
        Me.T_Table01.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Table01.ForeColor = System.Drawing.Color.Navy
        Me.T_Table01.Location = New System.Drawing.Point(7, 14)
        Me.T_Table01.Name = "T_Table01"
        Me.T_Table01.Size = New System.Drawing.Size(114, 31)
        Me.T_Table01.TabIndex = 1
        Me.T_Table01.TabStop = True
        Me.T_Table01.Text = "部門代號"
        Me.T_Table01.UseVisualStyleBackColor = False
        '
        'B_GO
        '
        Me.B_GO.BackColor = System.Drawing.Color.Black
        Me.B_GO.BackgroundImage = CType(resources.GetObject("B_GO.BackgroundImage"), System.Drawing.Image)
        Me.B_GO.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GO.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_GO.ForeColor = System.Drawing.Color.White
        Me.B_GO.Location = New System.Drawing.Point(350, 324)
        Me.B_GO.Name = "B_GO"
        Me.B_GO.Size = New System.Drawing.Size(102, 36)
        Me.B_GO.TabIndex = 61
        Me.B_GO.Text = "GO"
        Me.B_GO.UseVisualStyleBackColor = False
        '
        'B_GiveUp
        '
        Me.B_GiveUp.BackColor = System.Drawing.Color.Black
        Me.B_GiveUp.BackgroundImage = CType(resources.GetObject("B_GiveUp.BackgroundImage"), System.Drawing.Image)
        Me.B_GiveUp.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_GiveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_GiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_GiveUp.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_GiveUp.ForeColor = System.Drawing.Color.White
        Me.B_GiveUp.Location = New System.Drawing.Point(240, 324)
        Me.B_GiveUp.Name = "B_GiveUp"
        Me.B_GiveUp.Size = New System.Drawing.Size(102, 36)
        Me.B_GiveUp.TabIndex = 62
        Me.B_GiveUp.Text = "放 棄"
        Me.B_GiveUp.UseVisualStyleBackColor = False
        '
        'F_TableMaintMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(693, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_FileKind)
        Me.Controls.Add(Me.B_GO)
        Me.Controls.Add(Me.B_GiveUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_TableMaintMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.T_FileKind.ResumeLayout(False)
        Me.T_FileKind.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_FileKind As System.Windows.Forms.GroupBox
    Friend WithEvents T_Table02 As System.Windows.Forms.RadioButton
    Friend WithEvents T_Table01 As System.Windows.Forms.RadioButton
    Friend WithEvents B_GO As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents B_GiveUp As VB_SAMPLE.MyClass_ButtonGeneral
    Friend WithEvents T_Table03 As System.Windows.Forms.RadioButton
End Class
