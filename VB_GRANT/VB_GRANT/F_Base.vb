Public Class F_Base

    ' 使表單右上角的關閉鈕無效，方法一，使用關閉鈕事件
    Private Sub F_Base_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    ' 使表單右上角的關閉鈕無效，方法二，使用 Windows API 函數
    ' VB.NET 表單右上角的縮小及放大鈕可用其屬性來控制，但關閉鈕不能單獨控制，故只能求助於 API 函數
    ' 實務上需允許 User 縮小表單於螢幕下方的工作列，但不能讓 User 關閉表單（程式執行中），VB.NET 只能隱藏表單右上角的 ControlBox，
    ' 而無法單獨使關閉鈕不作用或隱藏
    'Private Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As Integer, ByVal bRevert As Integer) As Integer
    'Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
    'Private Const M_Disable As Integer = &H1000
    'Private Const MBox_Close As Integer = &HF060
    '★★★Private Const MBox_MAX As Integer = &HF030
    '★★★Private Const MBox_MIN As Integer = &HF020

    ' 載入本表單時，設定子表單並指定其顯示或隱藏
    Private Sub F_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 使表單右上角的關閉鈕無法作用（使用 API）
        ' RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_Close, M_Disable)
        '★★★RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_MAX, M_Disable)
        '★★★RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_MIN, M_Disable)

        ' 目錄表單（顯示）
        Dim f00 As New F_Menu
        f00.MdiParent = Me
        f00.Show()

        ' 密碼更換表單（隱藏）
        Dim f01 As New F_PasswordChange
        f01.MdiParent = Me
        f01.Hide()

        ' 帳號管理表單（隱藏）
        Dim f02 As New F_IDcontrol
        f02.MdiParent = Me
        f02.Hide()

        ' 授權管理表單（隱藏）
        Dim f03 As New F_GrantFunction
        f03.MdiParent = Me
        f03.Hide()

    End Sub

End Class