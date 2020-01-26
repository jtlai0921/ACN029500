Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class F_SQL_Login

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' 宣告公用變數以便儲存登入次數（超過 3 次強迫離開）
    Public Mloginno As Integer = 0

    ' 宣告清單集合，以便儲存某帳號相關資料，供後續主目錄表單使用
    Public List_ID As New List(Of String)
    ' 宣告清單集合，以便儲存某帳號的授權資料，供後續主目錄表單使用
    Public List_GRANT As New List(Of String)

    '-------------------------------------------------------------------------------------------------------------------------------------

    ' 儲存 SQL Server 登入資訊
    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        Dim MServerName As String = ""
        Dim MDataBase As String = ""
        Dim MUser As String = ""
        Dim MPassword As String = ""

        MServerName = Trim(T_ServerName.Text)
        MDataBase = Trim(T_DataBase.Text)
        MUser = Trim(T_User.Text)
        MPassword = Trim(T_Password.Text)

        ' 使用 StreamWriter 資料流寫入器建構函式 建立新的物件（執行個體），以便寫入文字檔，
        ' 括號內有兩個參數，前者為檔名及其路徑，後者為布林值，true  表示要附加資料至檔案，false 表示要覆寫檔案。 如果指定的檔案不存在，則這個參數沒有任何作用，而且建構函式會建立新的檔案
        ' 使用 WriteLine 方法將字串 (其後加上行結束字元) 寫入到文字字串或資料流
        ' 使用 Flush 方法清除目前寫入器 的所有緩衝區，並且將緩衝資料都寫入基礎資料流
        ' 使用 Close 方法 關閉目前的 StreamWriter 物件和基礎資料流
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine(MServerName)
        MStreamWrite.WriteLine(MDataBase)
        MStreamWrite.WriteLine(MUser)
        MStreamWrite.WriteLine(MPassword)
        MStreamWrite.Flush()
        MStreamWrite.Close()

        MsgBox("SQL Server 登入資訊已存入檔案！", 0 + 64 + 128, "OK")

    End Sub

    ' 本表單載入時
    ' 自檔案讀出前次儲存的登入資訊，並置入文字盒
    ' 使用 StreamReader 資料流讀取器建構函式 建立新的物件（執行個體），以便讀取文字檔，括號內為檔名及其路徑
    ' 使用 ReadLine 方法自目前資料流讀取一行字元，並將資料以字串傳回
    ' 使用 Close 方法關閉 StreamReader 物件和基礎資料流
    Private Sub F_SQL_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        T_ServerName.Text = MStreamRead.ReadLine()
        T_DataBase.Text = MStreamRead.ReadLine()
        T_User.Text = MStreamRead.ReadLine()
        T_Password.Text = MStreamRead.ReadLine()
        MStreamRead.Close()

        MServerName = Trim(T_ServerName.Text)
        MDataBase = Trim(T_DataBase.Text)
        MUser = Trim(T_User.Text)
        MPassword = Trim(T_Password.Text)

        TabControl1.SelectTab(0)
        T_ID.Select()
        T_ID.Focus()
    End Sub

    ' 切換標籤頁時變更表單的背景色，以便能與 TabConorol 的頁面顏色協調
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim MTabIndex As Integer = TabControl1.SelectedIndex
        If MTabIndex = 0 Then
            Me.BackColor = Color.FromArgb(64, 0, 0)
            T_ID.Focus()
        Else
            Me.BackColor = Color.SeaGreen
            T_ServerName.Focus()
        End If
    End Sub

    ' 離開
    Private Sub B_Exit_Click(sender As Object, e As EventArgs) Handles B_Exit.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            Application.Exit()
        Else
            Return
        End If
    End Sub

    ' 登入
    Private Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click

        Mloginno = Mloginno + 1
        If Mloginno > 3 Then
            MsgBox("Sorry, 登入失敗已達三次！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，本畫面將關閉。", 0 + 16, "Error")
            Application.Exit()
        End If

        Dim VENOA As String = Strings.Trim(T_ID.Text)
        Dim VPASSA As String = Strings.Trim(T_PASSW.Text)
        If Strings.Len(VENOA) = 0 Then
            MsgBox("Sorry, 『帳 號』尚未輸入！" + Chr(13) + Chr(13) + "請輸入。", 0 + 16, "Error")
            T_ID.Focus()
            Exit Sub
        End If
        If Strings.Len(VPASSA) < 6 Or Strings.Len(VPASSA) > 10 Then
            MsgBox("Sorry, 『密 碼』必須為 6～10 byte！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSW.Focus()
            Exit Sub
        End If

        ' 第 1 段，處理 User 輸入的帳號及密碼 ************************************************************************************
        ' 帳號通常不分大小寫，以免造成 User 的困擾，故以程式自動轉為大寫或小寫
        VENOA = Strings.UCase(VENOA)
        T_ID.Text = VENOA

        ' 密碼換算為虛擬密碼並放入 VPASSC
        ' 先將各字元轉換為 ASCII Code，再累加
        Dim VPASSC As Int64 = 0
        Dim Mstop As Integer = Strings.Len(VPASSA)
        For Mcou = 1 To Mstop Step 1
            VPASSC = VPASSC + Strings.Asc(Strings.Mid(VPASSA, Mcou, 1))
        Next
        ' 將前述累加之值 以 SYD 方法處理，再放大若干倍
        ' SYD 年數合計法折舊之某期折舊金額，括號內4個參數，分別為成本、殘值、折舊期數、計算期數，下式傳回第2期的折舊金額
        VPASSC = Math.Round(Financial.SYD(VPASSC, 10, 5, 2) * 9876543.21, 0)

        ' 第 2 段，從 SQL Server 讀取該帳號的資料 ************************************************************************************
        ' 若帳號不存於 SQL Server 之 VBSQLDB.dbo.TABPASSW 中，應請  User 重輸，若錯誤三次以上，則離開系統
        ' 若帳號正確，則取回 姓名，並放入VENAME，取回 授權狀況，並放入 VSYSEXP 等變數
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select * From TABPASSW Where eno='" + VENOA + "'"

        ' 以 SqlCommand 建構函式始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 使用 ExecuteReader 方法讀取資料
        Dim Odataread_1 As SqlDataReader
        Odataread_1 = Ocmd_1.ExecuteReader()

        ' 將前述讀出資料存入變數
        Dim VCHKENO As String = ""
        Dim VENAME As String = ""
        Dim VIDENABLE As String = ""
        Dim VTOTNO As Integer
        Dim VPASSB As Int64
        Dim VFIRSTLOGON As String = ""
        Dim VLOGONNO As Integer
        Dim VSYSMANAGER As String = ""
        Dim VDEPTCODE As String = ""

        ' 先檢查 User 所輸入的帳號是否存在
        If Odataread_1.HasRows = False Then
            MsgBox("Sorry, 帳號不存在！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_ID.Focus()
            Exit Sub
        End If

        Do While Odataread_1.Read() = True
            If IsDBNull(Odataread_1.Item(1)) = True Then
                VENAME = "無"
            Else
                VENAME = Odataread_1.Item(1)
            End If
            VIDENABLE = Odataread_1.Item(2)
            VTOTNO = Odataread_1.Item(3)
            If IsDBNull(Odataread_1.Item(4)) = True Then
                VPASSB = 0
            Else
                VPASSB = Odataread_1.Item(4)
            End If
            VFIRSTLOGON = Odataread_1.Item(5)
            VLOGONNO = Odataread_1.Item(6)
            VSYSMANAGER = Odataread_1.Item(7)
            VDEPTCODE = Odataread_1.Item(8)
        Loop
        Odataread_1.Close()

        ' 第 3 段，檢查帳號是否已停用 ************************************************************************************
        ' 留職停薪者可暫停其帳號而無須刪除，以免復職後又要重新建立，亦可保留帳號以免被新人佔用
        If VIDENABLE = "N" Then
            MsgBox("Sorry, 此帳號已停用！" + Chr(13) + Chr(13) + "請洽系統管理員或輸入其他帳號。", 0 + 16, "Error")
            T_ID.Focus()
            Exit Sub
        End If

        ' 第 4 段，判斷該帳號是否為初次使用者 ************************************************************************************
        ' 若為初次使用者而且其 LOGONNO 累積使用次數已達 3 次，則不准其登入，須由系統管理員再改為初次登入者
        ' 初次使用者之內定密碼為 abc123，為強迫其更換密碼，故限定內定密碼最多只能使用三次，以免被盜用而損及資料安全，
        ' 系統管理員將某一使用者改為初次登入者時，需同時將 LOGONNO 累積使用次數設為 0，
        ' 使用者修改密碼時，需同時將 FIRSTLOGON 初次登入狀態改為 N，初次登入累積數設為 0，
        ' 若初次登入者的 LOGONNO 累積次數已超過 3 次，則強迫離開，若未超過3 次，則累加 1 次
        If VFIRSTLOGON = "Y" Then
            If VLOGONNO = 3 Then
                MsgBox("Sorry, 內定密碼已使用 3 次，不能再使用！" + Chr(13) + Chr(13) + "請洽系統管理員。", 0 + 16, "Error")
                T_ID.Focus()
                Exit Sub
            Else
                ' 內定密碼使用 未達 3 次，可續用，但須累加 logonno 登入次數
                ' 宣告變數儲存 SQL 指令
                Dim Msqlstr_2 As String = "Update TABPASSW Set logonno=@t1 Where eno='" + VENOA + "'"
                ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
                Dim Ocmd_2 As New SqlCommand(Msqlstr_2, Ocn_1)

                Ocmd_2.Parameters.Clear()
                Ocmd_2.Parameters.AddWithValue("@t1", SqlDbType.Int).Value = VLOGONNO + 1
                ' 執行非查詢指令，更新 SQL Server 的資料
                ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
                Dim MupdateResult2 As Integer = Ocmd_2.ExecuteNonQuery()
            End If
        End If

        ' 第 5 段，檢查密碼是否正確  ************************************************************************************
        ' VPASSC 儲存 User 輸入的密碼（轉換後）、VPASSB 儲存 SQL Server 中的密碼（轉換後）
        If VPASSC <> VPASSB Then
            MsgBox("Sorry, 密碼錯誤！" + Chr(13) + Chr(13) + "請重新輸入。", 0 + 16, "Error")
            T_PASSW.Focus()
            Exit Sub
        End If

        ' 第 6 段，更新 SQL Server 中的 totno 總使用次數 ************************************************************************************
        Dim Msqlstr_3 As String = "Update TABPASSW Set totno=@t1 Where eno='" + VENOA + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_3 As New SqlCommand(Msqlstr_3, Ocn_1)

        Ocmd_3.Parameters.Clear()
        Ocmd_3.Parameters.AddWithValue("@t1", SqlDbType.Int).Value = VTOTNO + 1
        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult3 As Integer = Ocmd_3.ExecuteNonQuery()

        ' 第 7 段，將登入帳號的相關資料存入 List_ID 清單，供後續主目錄表單使用 ************************************************************************************
        List_ID.Add(VENOA)
        List_ID.Add(VENAME)
        List_ID.Add(VSYSMANAGER)

        ' 第 8 段，從 SQL Server 讀取該帳號的授權項目，並存入 List_GRANT 清單，供後續主目錄表單使用************************************************************************************
        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_5 As String = "Select * From TABGRANT Where eno='" + VENOA + "'"

        ' 以 SqlCommand 建構函式始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_5 As New SqlCommand(Msqlstr_5, Ocn_1)

        ' 使用 ExecuteReader 方法讀取資料
        Dim Odataread_5 As SqlDataReader
        Odataread_5 = Ocmd_5.ExecuteReader()

        Do While Odataread_5.Read() = True
            List_GRANT.Add(Odataread_5.Item(1))
        Loop
        Odataread_5.Close()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 顯示主目錄的父表單
        Me.Hide()
        F_Base.Show()

    End Sub

End Class