Public Class MyClass_ButtonClose
    Inherits Button

    ' 設定 Click 方法所要執行的動作
    ' 必須使用 Parent 關鍵字，以便隱藏本按鈕的父物件（某一 From），而非本按鈕
    Private Sub Me_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Parent.Hide()
            Application.Exit()
        Else
            Return
        End If
    End Sub
    ' 使用 Overrides 關鍵字，則 User 無法修改屬性
    'Protected Overrides Sub InitLayout()
    ' 
    '    MyBase.InitLayout()
    'End Sub

    ' 使用 New 關鍵字來建構函式，在函式內可設定屬性的初始值
    ' 此等初始值可被 User 修改，但部分屬性無效，例如 Text = "Exit"，若不修改，則會呈現  MyClass_Exit1 等
    Public Sub New()
        Me.Font = New Font("微軟正黑體", 16)
        Me.Text = "Exit"
        Me.ForeColor = Color.White
        Me.BackColor = Color.MediumVioletRed
        Me.Width = 102
        Me.Height = 36
        Me.FlatStyle = Windows.Forms.FlatStyle.Flat
        Me.FlatAppearance.BorderColor = Color.White
        Me.FlatAppearance.BorderSize = 1
        FlatAppearance.MouseDownBackColor = Color.Black
        FlatAppearance.MouseOverBackColor = Color.Black
        Me.TextAlign = ContentAlignment.MiddleCenter
    End Sub

End Class
