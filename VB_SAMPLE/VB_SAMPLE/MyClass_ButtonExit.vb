Public Class MyClass_ButtonExit
    Inherits Button

    ' 設定 Click 方法所要執行的動作
    Private Sub Me_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Application.Exit()
        Else
            Return
        End If
    End Sub

    ' 使用 Overrides 關鍵字，則 User 無法修改屬性
    ' 雖然可在屬性視窗內重新指定此控制項的屬性（例如背景色），但其效用僅限於設計階段
    ' 一旦執行時，仍以自訂類別中所設定的屬性
    Protected Overrides Sub InitLayout()
        Font = New Font("微軟正黑體", 16)
        Text = "Exit"
        ForeColor = Color.White
        BackColor = Color.FromArgb(255, 0, 128)
        Me.Width = 102
        Me.Height = 36
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderColor = Color.White
        FlatAppearance.BorderSize = 1
        FlatAppearance.MouseDownBackColor = Color.Black
        FlatAppearance.MouseOverBackColor = Color.Black
        TextAlign = ContentAlignment.MiddleCenter
        MyBase.InitLayout()
    End Sub

    ' 使用 New 關鍵字來建構函式，在函式內可設定屬性的初始值
    ' 此等初始值可被 User 修改，但部分屬性無效，例如 Text = "Exit"，若不修改，則會呈現  MyClass_Exit1 等
    'Public Sub New()

    'End Sub

End Class

