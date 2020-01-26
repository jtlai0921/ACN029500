Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class F_PasswordChange
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' ---------------------------------------------------------------------------------------------------------------------------------------------------------------

    ' 本表單載入時
    ' 自檔案讀出前次儲存的登入資訊，並置入文字盒
    ' 使用 StreamReader 資料流讀取器建構函式 建立新的物件（執行個體），以便讀取文字檔，括號內為檔名及其路徑
    ' 使用 ReadLine 方法自目前資料流讀取一行字元，並將資料以字串傳回
    ' 使用 Close 方法關閉 StreamReader 物件和基礎資料流
    Private Sub F_PasswordChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()
        T_PASSA.Focus()
    End Sub

    ' 再度顯示本表時，清空文字盒
    Private Sub F_PasswordChange_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        T_PASSA.Text = ""
        T_PASSB.Text = ""
        T_PASSA.Focus()
    End Sub

    ' 當游標離開第一個密碼文字方塊時，檢查輸入值是否符合規範
    Private Sub T_PASSA_Validated(sender As Object, e As EventArgs) Handles T_PASSA.Validated
        Dim MTPass As String = Strings.Trim(T_PASSA.Text)
        Dim Mstop As Integer = Strings.Len(MTPass)

        ' 若文字盒內無資料，允許跳離，以方便 User 敲『放 棄』鈕，但在『確 定』鈕內另作處理
        If Mstop = 0 Then
            Exit Sub
        End If
        If Mstop < 6 Then
            MsgBox("Sorry, 密碼長度不得小於 6 位！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If

        ' 檢查輸入值
        ' 密碼只能使用 大寫英文（ASC 為 65～90）、小寫英文（ASC 為 97～122）、阿拉伯數字（ASC 為 48～57） 及 - dash（ASC 為 45）等 63 種符號，
        ' 且不得為純英文或純阿拉伯數字，必須夾雜英文字母、阿拉伯數字或橫線
        Dim MAlphabet As Integer = 0
        Dim MNumber As Integer = 0
        Dim Mdash As Integer = 0
        Dim MOther As Integer = 0
        Dim Mchka As Integer

        For MCou = 1 To Mstop Step 1
            Mchka = Strings.Asc(Mid(MTPass, MCou, 1))
            Select Case Mchka
                Case 48 To 57
                    MNumber = MNumber + 1
                Case 65 To 90
                    MAlphabet = MAlphabet + 1
                Case 97 To 122
                    MAlphabet = MAlphabet + 1
                Case 45
                    Mdash = Mdash + 1
                Case Else
                    MOther = MOther + 1
            End Select
        Next

        If MOther > 0 Then
            MsgBox("Sorry, 密碼限英文字母、阿拉伯數字及橫線，不得使用其他符號！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If
        If MAlphabet = 0 And Mdash = 0 Then
            MsgBox("Sorry, 密碼內必須含有英文字母、阿拉伯數字或橫線！" + Chr(13) + Chr(13) + "（不得全部為數字）" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If
        If MNumber = 0 And Mdash = 0 Then
            MsgBox("Sorry, 密碼內必須含有英文字母、阿拉伯數字或橫線！" + Chr(13) + Chr(13) + "（不得全部為英文）" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If
    End Sub

    ' 當游標離開第二個密碼文字方塊時，檢查輸入值是否符合規範
    Private Sub T_PASSB_Validated(sender As Object, e As EventArgs) Handles T_PASSB.Validated
        Dim MTPass As String = Strings.Trim(T_PASSB.Text)
        Dim Mstop As Integer = Strings.Len(MTPass)

        ' 若文字盒內無資料，允許跳離，以方便 User 敲『放 棄』鈕，但在『確 定』鈕內另作處理
        If Mstop = 0 Then
            Exit Sub
        End If
        If Mstop < 6 Then
            MsgBox("Sorry, 密碼長度不得小於 6 位！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSB.Focus()
            Exit Sub
        End If

        ' 檢查輸入值
        ' 密碼只能使用 大寫英文（ASC 為 65～90）、小寫英文（ASC 為 97～122）、阿拉伯數字（ASC 為 48～57） 及 - dash（ASC 為 45）等 63 種符號，
        ' 且不得為純英文或純阿拉伯數字，必須夾雜英文字母、阿拉伯數字或橫線
        Dim MAlphabet As Integer = 0
        Dim MNumber As Integer = 0
        Dim Mdash As Integer = 0
        Dim MOther As Integer = 0
        Dim Mchka As Integer

        For MCou = 1 To Mstop Step 1
            Mchka = Strings.Asc(Mid(MTPass, MCou, 1))
            Select Case Mchka
                Case 48 To 57
                    MNumber = MNumber + 1
                Case 65 To 90
                    MAlphabet = MAlphabet + 1
                Case 97 To 122
                    MAlphabet = MAlphabet + 1
                Case 45
                    Mdash = Mdash + 1
                Case Else
                    MOther = MOther + 1
            End Select
        Next

        If MOther > 0 Then
            MsgBox("Sorry, 密碼限英文字母、阿拉伯數字及橫線，不得使用其他符號！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSB.Focus()
            Exit Sub
        End If
        If MAlphabet = 0 And Mdash = 0 Then
            MsgBox("Sorry, 密碼內必須含有英文字母、阿拉伯數字或橫線！" + Chr(13) + Chr(13) + "（不得全部為數字）" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSB.Focus()
            Exit Sub
        End If
        If MNumber = 0 And Mdash = 0 Then
            MsgBox("Sorry, 密碼內必須含有英文字母、阿拉伯數字或橫線！" + Chr(13) + Chr(13) + "（不得全部為英文）" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSB.Focus()
            Exit Sub
        End If
    End Sub

    ' 放棄
    Private Sub B_Quit_Click(sender As Object, e As EventArgs) Handles B_Quit.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Hide()
            F_Menu.Show()
        Else
            Return
        End If
    End Sub

    ' 確定
    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        Dim MPASSA As String = Strings.Trim(T_PASSA.Text)
        Dim MPASSB As String = Strings.Trim(T_PASSB.Text)

        If MPASSA <> MPASSB Then
            MsgBox("Sorry, 密碼不相同！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If
        If Strings.Len(MPASSA) = 0 Or Strings.Len(MPASSB) = 0 Then
            MsgBox("Sorry, 密碼尚未輸入！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If

        ' 轉換密碼值，然後存入 SQL Server
        ' 密碼換算為虛擬密碼並放入 MTempPass
        ' 先將各字元轉換為 ASCII Code，再累加
        Dim MTempPass As Int64 = 0
        Dim Mstop As Integer = Strings.Len(MPASSA)
        For Mcou = 1 To Mstop Step 1
            MTempPass = MTempPass + Strings.Asc(Strings.Mid(MPASSA, Mcou, 1))
        Next
        ' 將前述累加之值 以 SYD 方法處理，再放大若干倍
        ' SYD 年數合計法折舊之某期折舊金額，括號內4個參數，分別為成本、殘值、折舊期數、計算期數，下式傳回第2期的折舊金額
        MTempPass = Math.Round(Financial.SYD(MTempPass, 10, 5, 2) * 9876543.21, 0)

        ' 不得使用內定密碼 ABC123 或 abc123
        If MTempPass = 1143045268 Then
            MsgBox("Sorry, 不得使用內定密碼 abc123！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If
        If MTempPass = 890205761 Then
            MsgBox("Sorry, 不得使用內定密碼 ABC123！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSA.Focus()
            Exit Sub
        End If

        ' 更新 SQL Server 中登入者之密碼、取消初次登入狀態，並將初次登入累積數設為 0

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        '將登入者帳號存入變數 VENOA
        Dim VENOA As String = F_SQL_Login.List_ID(0)

        ' 更新 SQL Server 中的 logonno 初次登入累積數 ************************************************************************************
        Dim Msqlstr_1 As String = "Update TABPASSW Set logonno='0' Where eno='" + VENOA + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult1 As Integer = Ocmd_1.ExecuteNonQuery()

        ' 更新 SQL Server 中的 firstlogon 初次登入狀態 ************************************************************************************
        Dim Msqlstr_2 As String = "Update TABPASSW Set firstlogon='N' Where eno='" + VENOA + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_2 As New SqlCommand(Msqlstr_2, Ocn_1)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult2 As Integer = Ocmd_2.ExecuteNonQuery()

        ' 更新 SQL Server 中的 passww 密碼 ************************************************************************************
        Dim Msqlstr_3 As String = "Update TABPASSW Set passww=@t1 Where eno='" + VENOA + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_3 As New SqlCommand(Msqlstr_3, Ocn_1)

        Ocmd_3.Parameters.Clear()
        Ocmd_3.Parameters.AddWithValue("@t1", SqlDbType.Int).Value = MTempPass

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult3 As Integer = Ocmd_3.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()
        MsgBox("密碼已更換！", 0 + 64, "OK")
        Me.Hide()
        F_Menu.Show()
    End Sub
End Class