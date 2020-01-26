<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_VIDEO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_VIDEO))
        Me.T_Description = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.B_Close = New VB_VIDEO.MyClass_ButtonExit()
        Me.B_ListRead = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_Remove = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_ListSave = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_PickFile = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_Desc = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_PlayOne = New VB_VIDEO.MyClass_ButtonGeneral()
        Me.B_PlayAll = New VB_VIDEO.MyClass_ButtonGeneral()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_Description
        '
        Me.T_Description.AllowDrop = True
        Me.T_Description.BackColor = System.Drawing.Color.White
        Me.T_Description.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T_Description.ForeColor = System.Drawing.Color.Navy
        Me.T_Description.Location = New System.Drawing.Point(22, 15)
        Me.T_Description.Multiline = True
        Me.T_Description.Name = "T_Description"
        Me.T_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.T_Description.Size = New System.Drawing.Size(600, 170)
        Me.T_Description.TabIndex = 17
        Me.T_Description.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(22, 191)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(600, 400)
        Me.AxWindowsMediaPlayer1.TabIndex = 15
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 11.0!)
        Me.ListBox1.ForeColor = System.Drawing.Color.Navy
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(642, 191)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(330, 270)
        Me.ListBox1.TabIndex = 1
        '
        'B_Close
        '
        Me.B_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.B_Close.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Close.Font = New System.Drawing.Font("微軟正黑體", 16.0!)
        Me.B_Close.ForeColor = System.Drawing.Color.White
        Me.B_Close.Location = New System.Drawing.Point(418, 607)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 36)
        Me.B_Close.TabIndex = 26
        Me.B_Close.Text = "Exit"
        Me.B_Close.UseVisualStyleBackColor = False
        '
        'B_ListRead
        '
        Me.B_ListRead.BackColor = System.Drawing.Color.Blue
        Me.B_ListRead.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ListRead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ListRead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ListRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ListRead.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_ListRead.ForeColor = System.Drawing.Color.White
        Me.B_ListRead.Location = New System.Drawing.Point(810, 536)
        Me.B_ListRead.Name = "B_ListRead"
        Me.B_ListRead.Size = New System.Drawing.Size(102, 36)
        Me.B_ListRead.TabIndex = 25
        Me.B_ListRead.Text = "讀取清單"
        Me.B_ListRead.UseVisualStyleBackColor = False
        '
        'B_Remove
        '
        Me.B_Remove.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.B_Remove.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Remove.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Remove.ForeColor = System.Drawing.Color.White
        Me.B_Remove.Location = New System.Drawing.Point(810, 494)
        Me.B_Remove.Name = "B_Remove"
        Me.B_Remove.Size = New System.Drawing.Size(102, 36)
        Me.B_Remove.TabIndex = 24
        Me.B_Remove.Text = "移 除"
        Me.B_Remove.UseVisualStyleBackColor = False
        '
        'B_ListSave
        '
        Me.B_ListSave.BackColor = System.Drawing.Color.Purple
        Me.B_ListSave.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_ListSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_ListSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_ListSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_ListSave.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_ListSave.ForeColor = System.Drawing.Color.White
        Me.B_ListSave.Location = New System.Drawing.Point(702, 536)
        Me.B_ListSave.Name = "B_ListSave"
        Me.B_ListSave.Size = New System.Drawing.Size(102, 36)
        Me.B_ListSave.TabIndex = 23
        Me.B_ListSave.Text = "儲存清單"
        Me.B_ListSave.UseVisualStyleBackColor = False
        '
        'B_PickFile
        '
        Me.B_PickFile.BackColor = System.Drawing.Color.Green
        Me.B_PickFile.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PickFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_PickFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_PickFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PickFile.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PickFile.ForeColor = System.Drawing.Color.White
        Me.B_PickFile.Location = New System.Drawing.Point(702, 494)
        Me.B_PickFile.Name = "B_PickFile"
        Me.B_PickFile.Size = New System.Drawing.Size(102, 36)
        Me.B_PickFile.TabIndex = 22
        Me.B_PickFile.Text = "增 加"
        Me.B_PickFile.UseVisualStyleBackColor = False
        '
        'B_Desc
        '
        Me.B_Desc.BackColor = System.Drawing.Color.Olive
        Me.B_Desc.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_Desc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_Desc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_Desc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Desc.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_Desc.ForeColor = System.Drawing.Color.White
        Me.B_Desc.Location = New System.Drawing.Point(310, 607)
        Me.B_Desc.Name = "B_Desc"
        Me.B_Desc.Size = New System.Drawing.Size(102, 36)
        Me.B_Desc.TabIndex = 20
        Me.B_Desc.Text = "顯示說明"
        Me.B_Desc.UseVisualStyleBackColor = False
        '
        'B_PlayOne
        '
        Me.B_PlayOne.BackColor = System.Drawing.Color.Teal
        Me.B_PlayOne.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PlayOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_PlayOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_PlayOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PlayOne.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PlayOne.ForeColor = System.Drawing.Color.White
        Me.B_PlayOne.Location = New System.Drawing.Point(202, 607)
        Me.B_PlayOne.Name = "B_PlayOne"
        Me.B_PlayOne.Size = New System.Drawing.Size(102, 36)
        Me.B_PlayOne.TabIndex = 19
        Me.B_PlayOne.Text = "單點播放"
        Me.B_PlayOne.UseVisualStyleBackColor = False
        '
        'B_PlayAll
        '
        Me.B_PlayAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.B_PlayAll.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PlayAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.B_PlayAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.B_PlayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PlayAll.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.B_PlayAll.ForeColor = System.Drawing.Color.Red
        Me.B_PlayAll.Location = New System.Drawing.Point(94, 607)
        Me.B_PlayAll.Name = "B_PlayAll"
        Me.B_PlayAll.Size = New System.Drawing.Size(102, 36)
        Me.B_PlayAll.TabIndex = 18
        Me.B_PlayAll.Text = "連續播放"
        Me.B_PlayAll.UseVisualStyleBackColor = False
        '
        'F_VIDEO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_ListRead)
        Me.Controls.Add(Me.B_Remove)
        Me.Controls.Add(Me.B_ListSave)
        Me.Controls.Add(Me.B_PickFile)
        Me.Controls.Add(Me.B_Desc)
        Me.Controls.Add(Me.B_PlayOne)
        Me.Controls.Add(Me.B_PlayAll)
        Me.Controls.Add(Me.T_Description)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "F_VIDEO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_Description As System.Windows.Forms.TextBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents B_PlayAll As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_PlayOne As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_Desc As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_PickFile As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_ListSave As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_Remove As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_ListRead As VB_VIDEO.MyClass_ButtonGeneral
    Friend WithEvents B_Close As VB_VIDEO.MyClass_ButtonExit
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
