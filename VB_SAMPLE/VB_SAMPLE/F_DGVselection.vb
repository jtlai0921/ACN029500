Imports System
Imports System.IO

Public Class F_DGVselection
    Public MColor1R As Integer = 0
    Public MColor1G As Integer = 0
    Public MColor1B As Integer = 128
    Public MColor2R As Integer = 255
    Public MColor2G As Integer = 255
    Public MColor2B As Integer = 255
    Public MColor3R As Integer = 255
    Public MColor3G As Integer = 255
    Public MColor3B As Integer = 255
    Public MColor4R As Integer = 180
    Public MColor4G As Integer = 0
    Public MColor4B As Integer = 90
    Public MColor5R As Integer = 0
    Public MColor5G As Integer = 0
    Public MColor5B As Integer = 128
    Public MColor6R As Integer = 225
    Public MColor6G As Integer = 243
    Public MColor6B As Integer = 245

    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        ColorDialog1.Color = Color.FromArgb(0, 0, 128)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_1.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor1R = ColorDialog1.Color.R.ToString
            MColor1G = ColorDialog1.Color.G.ToString
            MColor1B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        ColorDialog1.Color = Color.FromArgb(255, 255, 255)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_2.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor2R = ColorDialog1.Color.R.ToString
            MColor2G = ColorDialog1.Color.G.ToString
            MColor2B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    Private Sub B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click
        ColorDialog1.Color = Color.FromArgb(255, 255, 255)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_3.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor3R = ColorDialog1.Color.R.ToString
            MColor3G = ColorDialog1.Color.G.ToString
            MColor3B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    Private Sub B_04_Click(sender As Object, e As EventArgs) Handles B_04.Click
        ColorDialog1.Color = Color.FromArgb(180, 0, 90)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_4.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor4R = ColorDialog1.Color.R.ToString
            MColor4G = ColorDialog1.Color.G.ToString
            MColor4B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    Private Sub B_05_Click(sender As Object, e As EventArgs) Handles B_05.Click
        ColorDialog1.Color = Color.FromArgb(0, 0, 128)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_5.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor5R = ColorDialog1.Color.R.ToString
            MColor5G = ColorDialog1.Color.G.ToString
            MColor5B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    Private Sub B_06_Click(sender As Object, e As EventArgs) Handles B_06.Click
        ColorDialog1.Color = Color.FromArgb(225, 243, 245)
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_RGB_6.Text = ColorDialog1.Color.R.ToString + "," + ColorDialog1.Color.G.ToString + "," + ColorDialog1.Color.B.ToString
            F_Layout_2.MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
            MColor6R = ColorDialog1.Color.R.ToString
            MColor6G = ColorDialog1.Color.G.ToString
            MColor6B = ColorDialog1.Color.B.ToString
        End If
    End Sub

    ' 關閉本表單
    Private Sub B_Close_Click(sender As Object, e As EventArgs) Handles B_Close.Click
        Me.Hide()
        F_Layout_2.Enabled = True
        F_Layout_2.TopMost = True

        ' 將前述參數存入檔案，以便下次載入 F_Layout_2 時設定其 DataGridView 之顏色
        Dim MFileName3 = "APPDATA\MyDataGridViewSelection.txt"
        Dim MStreamWrite3 As StreamWriter = New StreamWriter(MFileName3, False)
        MStreamWrite3.WriteLine(MColor1R)
        MStreamWrite3.WriteLine(MColor1G)
        MStreamWrite3.WriteLine(MColor1B)
        MStreamWrite3.WriteLine(MColor2R)
        MStreamWrite3.WriteLine(MColor2G)
        MStreamWrite3.WriteLine(MColor2B)
        MStreamWrite3.WriteLine(MColor3R)
        MStreamWrite3.WriteLine(MColor3G)
        MStreamWrite3.WriteLine(MColor3B)
        MStreamWrite3.WriteLine(MColor4R)
        MStreamWrite3.WriteLine(MColor4G)
        MStreamWrite3.WriteLine(MColor4B)
        MStreamWrite3.WriteLine(MColor5R)
        MStreamWrite3.WriteLine(MColor5G)
        MStreamWrite3.WriteLine(MColor5B)
        MStreamWrite3.WriteLine(MColor6R)
        MStreamWrite3.WriteLine(MColor6G)
        MStreamWrite3.WriteLine(MColor6B)
        MStreamWrite3.Flush()
        MStreamWrite3.Close()
        MsgBox("顏色已調整並已存入檔案！", 0 + 64 + 128, "OK")
    End Sub

End Class