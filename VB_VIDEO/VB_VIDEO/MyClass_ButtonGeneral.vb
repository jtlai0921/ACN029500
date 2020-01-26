Public Class MyClass_ButtonGeneral
    Inherits Button

    ' 使用 New 關鍵字來建構函式，在函式內可設定屬性的初始值
    ' 此等初始值可被 User 修改，但部分屬性無效，例如 Text = "Exit"，若不修改，則會呈現  MyClass_Exit1 等
    '  若 AutoSize 設為 False，則按鈕大小不會隨文字度度調整，除非以手動調整
    Public Sub New()
        Font = New Font("微軟正黑體", 16)
        Text = "按鈕"
        ForeColor = Color.White
        BackColor = Color.FromArgb(0, 128, 0)
        Me.Width = 102
        Me.Height = 36
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderColor = Color.White
        FlatAppearance.BorderSize = 1
        FlatAppearance.MouseDownBackColor = Color.Black
        FlatAppearance.MouseOverBackColor = Color.Black
        TextAlign = ContentAlignment.MiddleCenter
        AutoSize = False
    End Sub

End Class
