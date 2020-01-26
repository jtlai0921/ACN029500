Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_Input_1

    ' 使用建構函式，為按鈕設定初始化工作，將 Reset 按鈕的背景色設為完全透明
    'Public Sub New()

    ' 此為設計工具所需的呼叫。
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    'InitializeComponent()

    'B_Close.BackColor = Color.FromArgb(255, 128, 0, 128)
    'B_Reset.BackColor = Color.FromArgb(0, 0, 128, 164)
    'B_OK.BackColor = Color.FromArgb(255, 255, 128, 64)

    'End Sub

    ' 載入本表單時，設定 T_deptcpde 部門下拉式選單的資料來源
    Private Sub F_Input_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 若下拉式選單 T_TOWN 的資料來源檔為多欄，則需指定 ValueMember，以便讓程式知道要取出哪一欄之值，
        ' 但有一個缺點，就是 DisplayMember 設為無（不顯示欄名），則會自動在 T_TOWN 欄顯示第一個資料，故以下列指令消除
        'T_TOWN.Text = ""

        ' 第一段
        ' 連結 Excel 檔，以便以『對照表_部門代號及名稱.xls』作為 T_deptcpde 部門下拉式選單的資料來源
        ' 連結字串中 Extended Properties=之後的參數要用單引號括起來，否則會出现『找不到可安装的 ISAM』的訊息，
        ' HDR=Yes 表示 Excel 表的第一列為欄名，No 则表示第一列不是欄名，
        ' IMEX=1; 將文數字混雜的欄位資料視為文字來處理，例如 QTY 欄名為文字 而 HDR=NO，IMEX=1，則該欄之數字會被視為文字來處理，
        ' 若 HDR=Yes，IMEX=1，則該欄之數字會被視為數字來處理，例如 12,345 變成 12345
        ' OLEDB.12 可連結新版及舊版的 Excel，但需安裝 Office 2007（含）以上，OLEDB.4 只能連結舊版的 Excel
        Dim MFN_01 As String = "APPDATA\對照表_部門代號及名稱.xls"
        Dim Mstr_conn_01 As String = ""
        Mstr_conn_01 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_01 + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';"
        'Mstr_conn_01 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_01 + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';"

        ' 建立連結
        Dim O_conn_01 As New OleDbConnection(Mstr_conn_01)
        O_conn_01.Open()

        ' 第二段
        ' 使用 Command 物件 執行 SQL 指令，以便將 Excel 檔中某一工作表的資料存入 DataSet 物件，
        ' DataSet 為記憶體中的資料庫，可包含多個資料表，但在存入 DataSet 物件之前，需透過 DataAdapter 物件作為轉接器（亦即來源檔與DataSet之間的橋樑）。
        ' 因為一個 Excel 檔可能含有多張工作表，故在 SELECT * FROM 指令之後需接工作表名稱，但使用固定的工作表名稱會有不少缺點，故下述範例使用一種彈性的方法。
        ' 我們使用 Connection 物件的 GetSchema 方法取得檔案結構描述之相關資訊（包括檔名），以便正確讀出所需工作表的資料，
        ' GetSchema 方法所取得之檔案結構描述之第 3 欄為工作表名稱，範例中的 O_datatable_01.Rows(0)(2) 是指向 第 3 欄之第 1 列，故可傳回第一張工作表的名稱，
        ' O_datatable_01.Rows(1)(2) 可傳回第二張工作表的名稱，餘類推，
        ' SELECT * FROM 指令中不使用固定的工作表名稱，可避開新版 Excel 與 舊版 Excel 內定工作表名稱不一樣的困擾，前者為『工作表1』等、後者為『Sheet1』 等，
        ' 而且當 User 更改工作表名稱之後亦無需修改程式。但須注意，GetSchema 所讀出的工作表名稱是排序過的，
        ' 故若 User 要修改工作表名稱，需將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表。
        Dim O_datatable_01 As DataTable
        O_datatable_01 = O_conn_01.GetSchema("Tables")

        Dim Mstr_com_01 As String
        Mstr_com_01 = "SELECT * FROM [" + O_datatable_01.Rows(0)(2) + "]"

        Dim O_cmd_01 As New OleDbCommand(Mstr_com_01, O_conn_01)

        ' 以  OleDbDataAdapter 類別宣告轉接器物件 O_adp_01
        ' 若連結對象為 SQL Server 則須使用 SqlDataAdapter 類別
        Dim O_adp_01 As New OleDbDataAdapter()
        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_01.SelectCommand = O_cmd_01

        ' 第三段
        ' 以 DataSet 類別宣告資料集物件O_dset_01
        Dim O_dset_01 As New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入 資料集
        ' Fill 方法 之括號內有兩個引數，前者為資料集的名稱，後者為資料表的名稱
        O_adp_01.Fill(O_dset_01, "DATA01")

        ' 宣告資料表物件
        Dim O_dtable_01 As New DataTable
        ' 將資料集中的第一個資料表存入 datatable
        O_dtable_01 = O_dset_01.Tables("DATA01")

        ' 建立多欄式的下拉式選單
        ' 逐一取出 O_dset_01 資料集中的第一個資料表 DATA01 的每一筆資料作為下拉式選單的資料來源，
        ' 每一 row 為一個資料列物件（本例取名 O_row），掃描對象可為資料集中，亦可為資料表，因為 O_dtable_01 = O_dset_01.Tables("DATA01")，
        ' 建立資料表物件 O_dtable_01，可利用其屬性計算資料表的列數及行數，例如 MROWNO_01 = O_dtable_01.Rows.Count、MCOLNO_01 = O_dtable_01.Columns.Count
        ' 下列程式逐一掃瞄 DATA01 資料表的每一列，並將其 deptcode 欄 及 deptname 欄 的資料合併，然後再以 ComoBox 控制項的 Add 方法加入下拉式選單作為選單之項目
        For Each O_row In O_dset_01.Tables("DATA01").Rows
            If Information.IsDBNull(O_row("deptcode")) = False And Information.IsDBNull(O_row("deptname")) = False Then
                T_DEPTCODE.Items.Add(O_row("deptcode") + O_row("deptname"))
            End If
        Next

        ' 關閉相關物件
        O_cmd_01.Dispose()
        O_adp_01.Dispose()
        O_conn_01.Close()
        O_conn_01.Dispose()
        ' 將 T_DEPTCODE 文字盒的 Text 設為空字串，否則會出現下拉式選單的第一項
        T_DEPTCODE.Text = ""

        ' 指定 L_Designer 標籤的父物件為 PictureBox1，以便設定透明色
        L_Designer.Parent = PictureBox1
        L_Designer.BackColor = Color.Transparent
        PictureBox1.SendToBack()
        L_Designer.BringToFront()

    End Sub

    ' 當 User 敲選部門之後就啟動 Tab 鍵，將游標移至下一欄，
    ' 此動作會引發 T_DEPTCODE 的 Validated 事件，而該事件之程序可拆分 User 所選的部門代號及部門名稱，
    ' 若將 Validated 事件之程序併入本程序無法達到相同的效果
    Private Sub T_DEPTCODE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_DEPTCODE.SelectedIndexChanged
        SendKeys.Send("{Tab}")
    End Sub

    ' 當游標離開 T_DEPTCODE 部門文字盒時，拆分 User 所選的部門代號及部門名稱，以利後續程式可將其存入資料庫中不同的欄位
    Private Sub T_DEPTCODE_Validated(sender As Object, e As EventArgs) Handles T_DEPTCODE.Validated
        Dim MTempDept As String = RTrim(T_DEPTCODE.Text)
        Dim MLen As Integer = Len(MTempDept)
        If MLen = 0 Then
            Exit Sub
        Else
            T_DEPTCODE.Text = Strings.Left(MTempDept, 4)
            If MLen >= 4 Then
                L_DEPTNAME.Text = Strings.Right(MTempDept, MLen - 4)
            End If
        End If

        ' 本欄允許 User 直接輸入部門代號，但須檢查 User 所輸入的值是否為下拉式選單的選項之一
        '  L_DEPTNAME 部門名稱亦需重新抓取
        ' T_DEPTCODE.Items(Mcou) 可傳回選單某一選項之內容
        Dim MTotalItems As Integer = T_DEPTCODE.Items.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            If LTrim(RTrim(T_DEPTCODE.Text)) = Strings.Left(T_DEPTCODE.Items(Mcou), 4) Then
                Dim MLenItem As Integer = Len(T_DEPTCODE.Items(Mcou))
                L_DEPTNAME.Text = Strings.Mid(T_DEPTCODE.Items(Mcou), 5, MLenItem - 4)
                Exit Sub
            End If
        Next
        MsgBox("所輸入的代號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
        T_DEPTCODE.Focus()

    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要清除本頁資料嗎？", 4 + 32 + 256, "Confirm")
        If MANS <> 6 Then
            Exit Sub
        End If

        T_Name.Text = ""
        T_Man.Checked = False
        T_Woman.Checked = False
        T_DEPTCODE.Text = ""
        L_DEPTNAME.Text = ""
        T_TITLE.Text = ""
        T_EDATE.Text = ""
        T_BDATE.Text = ""
        T_SCHOOLING.Text = ""
        T_CITY.Text = ""
        T_TOWN.Text = ""
        T_ZIPCODE.Text = ""
        T_ADDRESS.Text = ""
        T_INTEREST.Text = ""
        T_Color.Text = ""

        ' 清除鄉鎮區下拉式選單之全部內容（選項）
        T_TOWN.Items.Clear()

        ' 恢復表單底色、恢復按鈕底色、恢復按鈕前景色、恢復按鈕邊框顏色
        Me.BackColor = Color.FromArgb(255, 191, 205, 219)

        B_Close.BackColor = Color.FromArgb(255, 128, 0, 128)
        B_Reset.BackColor = Color.FromArgb(255, 0, 128, 64)
        B_OK.BackColor = Color.FromArgb(255, 255, 128, 64)
        B_Close.ForeColor = Color.White
        B_Reset.ForeColor = Color.White
        B_OK.ForeColor = Color.White
        B_Close.FlatAppearance.BorderColor = Color.White
        B_Reset.FlatAppearance.BorderColor = Color.White
        B_OK.FlatAppearance.BorderColor = Color.White

        T_Name.Focus()

    End Sub

    ' 縣市欄下拉式選單之選取項目變更時，執行下列程式，
    ' 將 User 所指定縣市的鄉鎮區抓出來，作為鄉鎮區下拉式選單之內容，供 User 挑選
    Private Sub T_CITY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_CITY.SelectedIndexChanged

        ' 清除鄉鎮、郵區遞區號及戶籍 文字盒
        T_TOWN.Text = ""
        T_ZIPCODE.Text = ""
        T_ADDRESS.Text = ""
        ' 清除鄉鎮區下拉式選單之全部內容（選項）
        T_TOWN.Items.Clear()

        Dim MTempCity As String = T_CITY.Text

        ' 連結資料庫 1
        Dim MDATANAME_1 As String = "APPDATA\TAB_ZIPCODE.mdb"
        'Dim MDATANAME_1 As String = "TAB_ZIPCODE.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME_1
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()

        Dim MSTRsql_1 As String = "Select * from ZIPLIST where city='" + MTempCity + "'"
        Dim Ocmd_1 As New OleDbCommand(MSTRsql_1, Oconn_1)
        Dim Ored_1 As OleDbDataReader = Ocmd_1.ExecuteReader()

        ' 逐一讀出資料庫 1 中合於條件的資料，鄉鎮區欄可能為空值，故須使用 IsDBNull 偵測
        Do While Ored_1.Read()

            ' 使用 Add 方法將讀出資料加入下拉式選單
            ' 若無鄉鎮區（例如嘉義市、新竹市等），則須將郵遞區號置入 T_ZIPCODE 文字盒，
            ' 並將縣市、鄉鎮區及郵遞區號資料存入戶籍欄
            ' ★★★ 若下拉式選單要顯示多欄， 可在來源欄之間加入分隔符號 + " - " +
            If IsDBNull(Ored_1.Item(1)) = False Then
                T_TOWN.Items.Add(Ored_1.Item(1))
                'T_TOWN.Items.Add(Ored_1.Item(1) + " - " + Ored_1.Item(2))
                T_TOWN.Focus()
            Else
                T_ZIPCODE.Text = Ored_1.Item(2)
                T_ADDRESS.Text = RTrim(T_ZIPCODE.Text) + " " + RTrim(T_CITY.Text) + RTrim(T_TOWN.Text)
                T_ADDRESS.Focus()
                SendKeys.Send("{End}")
            End If

        Loop

        ' 關閉連結
        Ocmd_1.Cancel()
        Ored_1.Close()
        Oconn_1.Close()
        Oconn_1.Dispose()

    End Sub

    ' 鄉鎮區欄下拉式選單之選取項目變更時，執行下列程式，
    ' 根據 User 所指定的縣市及鄉鎮區，自資料庫抓出對應的郵遞區號，並存入 T_TWON 文字盒
    Private Sub T_TOWN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_TOWN.SelectedIndexChanged

        Dim MTempCity As String = T_CITY.Text
        'Dim MPOS As Integer = InStr(1, T_TOWN.Text, "-", 1)
        'Dim MTempTown As String = Strings.Left(T_TOWN.Text, MPOS - 1)
        Dim MTempTown As String = T_TOWN.Text

        ' 連結資料庫 1
        Dim MDATANAME_1 As String = "APPDATA\TAB_ZIPCODE.mdb"
        'Dim MDATANAME_1 As String = "TAB_ZIPCODE.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME_1
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()

        Dim MSTRsql_1 As String = "Select zipcode from ZIPLIST where city='" + MTempCity + "'" + " and town='" + MTempTown + "'"
        Dim Ocmd_1 As New OleDbCommand(MSTRsql_1, Oconn_1)
        Dim Ored_1 As OleDbDataReader = Ocmd_1.ExecuteReader()

        ' 逐一讀出資料庫 1 中合於條件的資料
        Do While Ored_1.Read()
            T_ZIPCODE.Text = Ored_1.Item(0)
        Loop

        ' 關閉連結
        Ocmd_1.Cancel()
        Ored_1.Close()
        Oconn_1.Close()
        Oconn_1.Dispose()

        ' 將縣市、鄉鎮區及郵遞區號資料存入戶籍欄
        T_ADDRESS.Text = RTrim(T_ZIPCODE.Text) + " " + RTrim(T_CITY.Text) + RTrim(T_TOWN.Text)
        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 接續輸入街道巷弄等地址
        T_ADDRESS.Focus()
        SendKeys.Send("{End}")

    End Sub

    ' 顯示興趣挑選清單
    Private Sub B_LIST01_Click(sender As Object, e As EventArgs) Handles B_LIST01.Click

        ' ★★★ 呼叫表單 F_LIST_INTEREST，並將本表單 F_Input_1 傳過去 給  F_LIST_INTEREST 的自訂函數 CtrlObj 使用，以便從  F_LIST_INTEREST 控制本表單的控制項，
        ' 亦即 從被呼叫的表單來控制呼叫的表單
        Dim CallForm01 As F_LIST_INTEREST = New F_LIST_INTEREST
        CallForm01.CtrlObj(Me)

        ' F_LIST_INTEREST.ShowDialog() 無法使用，故為避免 User 誤觸  F_LIST_INTEREST 以外的範圍而遮蓋了 F_LIST_INTEREST，
        ' 有兩種解決方案，隱藏本表單 F_Input_1 或 使本表單上的控制項皆反制能 （Enabled = False），
        ' 但表單上反制能 Me.Enabled = False，會影響自訂函數中的 Focus 等功能，故不使用
        Me.Visible = False
        F_LIST_INTEREST.Show()

    End Sub

    ' 關閉
    ' 必須使用  Dispose 釋放本表單，而不能使用 Hide 隱藏本表單，
    ' 否則再次 Show 本表單時，會殘留前次的輸入資料
    ' F_LIST_INTEREST 興趣清單也一併釋放
    Private Sub B_Close_Click(sender As Object, e As EventArgs) Handles B_Close.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            F_LIST_INTEREST.Dispose()
            'Me.Hide()
            Me.Dispose()
            F_menu.Show()
        Else
            Return
        End If

    End Sub

    ' 當本表單的可見事件變動時，將 User 所敲選的興趣項目 置入 T_INTEREST 文字盒
    Private Sub F_Input_1_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        'T_INTEREST.Text = F_LIST_INTEREST.Tag
        T_INTEREST.Text = F_LIST_INTEREST.MString

        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 查看，否則整個字串呈現選取狀態
        T_INTEREST.Focus()
        SendKeys.Send("{End}")
    End Sub

    ' 當游標離開 T_EDATE （進公司日）文字盒時，檢查日期格式是否正確
    ' 為方便 User 快速輸入，不要求輸入 / 分隔符號，也不使用日曆控制項
    Private Sub T_EDATE_Validated(sender As Object, e As EventArgs) Handles T_EDATE.Validated
        Dim MTempDate As String = T_EDATE.Text
        Dim Mchkdate As String = Strings.Left(MTempDate, 4) + "/" + Strings.Mid(MTempDate, 5, 2) + "/" + Strings.Right(MTempDate, 2)

        ' 長度必須為 8 byte， 不輸入任何資料時可離開本文字盒
        If Len(MTempDate) <> 0 And Len(MTempDate) <> 8 Then
            MsgBox("日期不正確！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
            T_EDATE.Focus()
            L_date1.Text = ""
            Exit Sub
        End If

        '  使用 IsDate 函數檢查日期格式
        If Len(MTempDate) <> 0 And IsDate(Mchkdate) = False Then
            MsgBox("日期不正確！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
            L_date1.Text = ""
            T_EDATE.Focus()
            Exit Sub
        Else
            L_date1.Text = Mchkdate
        End If
    End Sub

    ' 當游標離開 T_BDATE （出生日）文字盒時，檢查日期格式是否正確
    ' 為方便 User 快速輸入，不要求輸入 / 分隔符號，也不使用日曆控制項
    Private Sub T_BDATE_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles T_BDATE.Validating
        Dim MTempDate As String = T_BDATE.Text
        Dim Mchkdate As String = Strings.Left(MTempDate, 4) + "/" + Strings.Mid(MTempDate, 5, 2) + "/" + Strings.Right(MTempDate, 2)

        ' 不輸入任何資料時可離開本文字盒
        If Len(MTempDate) = 0 Then
            L_date2.Text = ""
            Return
        End If

        ' 長度必須為 8 byte
        If Len(MTempDate) <> 8 Then
            MsgBox("日期不正確！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
            L_date2.Text = ""
            T_BDATE.Focus()
            Exit Sub
        End If

        '  使用 IsDate 函數檢查日期格式
        If Len(MTempDate) <> 0 And IsDate(Mchkdate) = False Then
            MsgBox("日期不正確！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
            L_date2.Text = ""
            T_BDATE.Focus()
            Exit Sub
        Else
            L_date2.Text = Mchkdate
        End If
    End Sub

    ' 當游標離開 T_TITLE 職稱字盒時，檢查 User 所輸入的值是否為下拉式選單的選項之一
    Private Sub T_TITLE_Validated(sender As Object, e As EventArgs) Handles T_TITLE.Validated

        Dim MTotalItems As Integer = T_TITLE.Items.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            If LTrim(RTrim(T_TITLE.Text)) = T_TITLE.Items(Mcou) Then
                Exit Sub
            End If
        Next
        MsgBox("所輸入的職稱並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正", 0 + 16, "Error")
        T_TITLE.Focus()

    End Sub

    ' T_TITLE 職稱選取變動事件  
    Private Sub T_TITLE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_TITLE.SelectedIndexChanged
        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 查看，否則整個字串呈現選取狀態
        T_TITLE.Focus()
        SendKeys.Send("{End}")
    End Sub

    ' T_SCHOOLING 學歷選取變動事件  
    Private Sub T_SCHOOLING_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_SCHOOLING.SelectedIndexChanged
        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 查看，否則整個字串呈現選取狀態
        T_SCHOOLING.Focus()
        SendKeys.Send("{End}")
    End Sub

    ' 將 User 所輸入的資料存入資料庫
    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        ' 程式待寫 ...................................................
    End Sub

    ' 變更表單底色、變更按鈕底色、變更按鈕前景色、變更按鈕邊框顏色
    Private Sub T_Color_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_Color.SelectedIndexChanged
        Dim MTempColor As String = T_Color.Text
        Select Case MTempColor
            Case "底色 A _ 197, 197, 197"
                Me.BackColor = Color.FromArgb(197, 197, 197)
            Case "底色 B _ 185, 211, 200"
                Me.BackColor = Color.FromArgb(185, 211, 200)
            Case "底色 C _ 205, 205, 193"
                Me.BackColor = Color.FromArgb(205, 205, 193)
            Case "底色 D _ 176, 196, 210"
                Me.BackColor = Color.FromArgb(176, 196, 210)
            Case "底色 E _ 180, 205, 205"
                Me.BackColor = Color.FromArgb(180, 205, 205)
        End Select
        B_Close.BackColor = Color.FromArgb(0, 128, 0, 128)
        B_Reset.BackColor = Color.FromArgb(0, 0, 128, 164)
        B_OK.BackColor = Color.FromArgb(0, 255, 128, 64)
        B_Close.ForeColor = Color.Navy
        B_Reset.ForeColor = Color.Navy
        B_OK.ForeColor = Color.Navy
        B_Close.FlatAppearance.BorderColor = Color.Navy
        B_Reset.FlatAppearance.BorderColor = Color.Navy
        B_OK.FlatAppearance.BorderColor = Color.Navy

    End Sub

    ' 在滑鼠移過按鈕事件中，撰寫變更按鈕前景色的程式，以免因按鈕背景色變為透明之後，其上的文字不醒目
    Private Sub B_Close_MouseHover(sender As Object, e As EventArgs) Handles B_Close.MouseHover
        B_Close.ForeColor = Color.White
    End Sub
    Private Sub B_Reset_MouseHover(sender As Object, e As EventArgs) Handles B_Reset.MouseHover
        B_Reset.ForeColor = Color.White
    End Sub
    Private Sub B_OK_MouseHover(sender As Object, e As EventArgs) Handles B_OK.MouseHover
        B_OK.ForeColor = Color.White
    End Sub

    ' 在滑鼠離開按鈕事件中，撰寫變更按鈕前景色的程式
    Private Sub B_Close_MouseLeave(sender As Object, e As EventArgs) Handles B_Close.MouseLeave
        B_Close.ForeColor = Color.White
    End Sub
    Private Sub B_Reset_MouseLeave(sender As Object, e As EventArgs) Handles B_Reset.MouseLeave
        B_Reset.ForeColor = Color.White
    End Sub
    Private Sub B_OK_MouseLeave(sender As Object, e As EventArgs) Handles B_OK.MouseLeave
        B_OK.ForeColor = Color.White
    End Sub

End Class