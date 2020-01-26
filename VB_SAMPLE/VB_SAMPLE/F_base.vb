Public Class F_Base

    ' 使表單右上角的關閉鈕無效，方法一，使用關閉鈕事件
    'Private Sub F_Base_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    If (e.CloseReason = CloseReason.UserClosing) Then
    '        e.Cancel = True
    '    End If
    'End Sub

    ' 使表單右上角的關閉鈕無效，方法二，使用 Windows API 函數
    ' VB.NET 表單右上角的縮小及放大鈕可用其屬性來控制，但關閉鈕不能單獨控制，故只能求助於 API 函數
    ' 實務上需允許 User 縮小表單於螢幕下方的工作列，但不能讓 User 關閉表單（程式執行中），VB.NET 只能隱藏表單右上角的 ControlBox，
    ' 而無法單獨使關閉鈕不作用或隱藏
    Private Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As Integer, ByVal bRevert As Integer) As Integer
    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
    Private Const M_Disable As Integer = &H1000
    Private Const MBox_Close As Integer = &HF060
    '★★★Private Const MBox_MAX As Integer = &HF030
    '★★★Private Const MBox_MIN As Integer = &HF020

    ' 載入本表單時，設定子表單並指定其顯示或隱藏
    Private Sub F_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 使表單右上角的關閉鈕無法作用（使用 API）
        RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_Close, M_Disable)
        '★★★RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_MAX, M_Disable)
        '★★★RemoveMenu(GetSystemMenu(Me.Handle.ToInt32, 0), MBox_MIN, M_Disable)

        ' 目錄表單（顯示）
        Dim f00 As New F_menu
        f00.MdiParent = Me
        f00.Show()

        ' 臨時資料夾表單（隱藏）
        Dim f03 As New F_TempFile
        f03.MdiParent = Me
        f03.Hide()

        ' 表單設計之一（隱藏）
        Dim FN_Layout As New F_Layout
        FN_Layout.MdiParent = Me
        FN_Layout.Hide()

        ' 表單設計之二 （隱藏）
        Dim FN_Layout_2 As New F_Layout_2
        FN_Layout_2.MdiParent = Me
        FN_Layout_2.Hide()

        ' 顏色表單（隱藏）
        Dim f06 As New F_Color
        f06.MdiParent = Me
        f06.Hide()

        ' 輸入表單 (隱藏)
        Dim f07 As New F_Input_1
        f07.MdiParent = Me
        f07.Hide()

        ' 查詢 1 表單 (隱藏)
        Dim FN_Query_1 As New F_Query_1
        FN_Query_1.MdiParent = Me
        FN_Query_1.Hide()

        '  背景處理 表單 (隱藏)
        Dim FN_Backgroundwork As New F_Backgroundwork
        FN_Backgroundwork.MdiParent = Me
        FN_Backgroundwork.Hide()

        ' 資料維護S 表單 (隱藏)
        Dim FN_SQL01 As New F_SQL01
        FN_SQL01.MdiParent = Me
        FN_SQL01.Hide()

        ' SQL 登入資訊表單 (隱藏)
        Dim FN_SQL_Login As New F_SQL_Login
        FN_SQL_Login.MdiParent = Me
        FN_SQL_Login.Hide()

        ' 資料維護A 表單 (隱藏)
        Dim FN_ACCESS01 As New F_ACCESS01
        FN_ACCESS01.MdiParent = Me
        FN_ACCESS01.Hide()

        ' 資料維護A2 表單 (隱藏)
        Dim FN_ACCESS02 As New F_ACCESS02
        FN_ACCESS02.MdiParent = Me
        FN_ACCESS02.Hide()

        ' 資料維護S2 表單 (隱藏)
        Dim FN_SQL02 As New F_SQL02
        FN_SQL02.MdiParent = Me
        FN_SQL02.Hide()

        ' 檔案處理 (隱藏)
        Dim FN_FileSystem As New F_FileSystem
        FN_FileSystem.MdiParent = Me
        FN_FileSystem.Hide()

        ' Excel 檔處理 (隱藏)
        Dim FN_EXCEL01 As New F_EXCEL01
        FN_EXCEL01.MdiParent = Me
        FN_EXCEL01.Hide()

        ' 查詢及處理
        Dim FN_Query As New F_Query
        FN_Query.MdiParent = Me
        FN_Query.Hide()

        ' 查詢及處理 2
        Dim FN_QueryAdvanced As New F_QueryAdvanced
        FN_QueryAdvanced.MdiParent = Me
        FN_QueryAdvanced.Hide()

        ' 對照表維護
        Dim FN_TableMaintMenu As New F_TableMaintMenu
        FN_TableMaintMenu.MdiParent = Me
        FN_TableMaintMenu.Hide()

        ' 統計圖
        Dim FN_chart As New F_chart
        FN_chart.MdiParent = Me
        FN_chart.Hide()

        ' 自訂類別應用
        Dim FN_Class01 As New F_Class01
        FN_Class01.MdiParent = Me
        FN_Class01.Hide()

        ' 函式庫應用之一
        Dim FN_DLL01 As New F_DLL01
        FN_DLL01.MdiParent = Me
        FN_DLL01.Hide()

        ' 函式庫應用之二
        Dim FN_DLL As New F_DLL
        FN_DLL.MdiParent = Me
        FN_DLL.Hide()

        ' 介面設計 3
        Dim FN_Query_2 As New F_Query_2
        FN_Query_2.MdiParent = Me
        FN_Query_2.Hide()

        ' 介面設計 4
        Dim FN_Query_3 As New F_Query_3
        FN_Query_3.MdiParent = Me
        FN_Query_3.Hide()

        ' 介面設計 5
        Dim FN_Query_5 As New F_Query_5
        FN_Query_5.MdiParent = Me
        FN_Query_5.Hide()

        ' 暫存檔處理 （隱藏）
        Dim FN_TempFile As New F_TempFile
        FN_TempFile.MdiParent = Me
        FN_TempFile.Hide()

        ' 請等待（隱藏）
        Dim f99 As New F_wait
        f99.MdiParent = Me
        f99.Hide()
    End Sub
End Class