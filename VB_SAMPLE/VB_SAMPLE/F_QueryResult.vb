Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic

Public Class F_QueryResult
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0

    ' 宣告公用變數以便儲存 SQL 指令
    Public Msqlstr_1 As String = ""

    ' 宣告公用變數以便儲存彙總方式之代號（1 明細、2 部門小計、3 部門＋等級 小計、4 部門＋職稱＋性別 小計）
    Public MSubTotalKind As Integer = 1

    ' 宣告公用變數以便儲存比對方式之代號（0 不比對、1 比對員工號、2 比對部門代號、3 比對職稱）
    Public MMatchKind As Integer = 0

    ' 宣告公用變數以便儲存比對檔之檔名及路徑
    Public MSourceFile As String = ""

    ' 宣告變數，以便儲存 User 所指定比對檔的副檔名之長度
    Public MLenExt As Integer

    ' ************************************************************************************************************************************************



    ' 繼續指定查詢條件
    Private Sub B_Continue_Click(sender As Object, e As EventArgs) Handles B_Continue.Click
        'Me.Hide()
        Me.Dispose()
        F_Query.Show()

    End Sub

    ' 抓出合於條件的資料，並顯示於 DataGridView
    ' 相關程式若寫於本表單 Load 載入時，則無法重複執行，因為以 Show 呼叫本表單，只有第一次會 Load
    ' 相關程式若寫於本表單 VisibleChanged 可見事件變動時，則可重複執行，但 Show 及 Hide 都會執行一次相同程式，浪費時間
    ' 相關程式若寫於本表單 Shown 顯示時，則無法重複執行，且螢幕會顯示表單未完整載入的畫面，造成 User 疑慮
    ' 改進辦法 → 相關程式寫於本表單 Load 載入時，但繼續指定查詢條件時，需使用 Dispose 釋放本表單，以便再次以 Show 呼叫本表單時，仍會 Load 本表單而再度執行本程式
    'Private Sub F_QueryResult_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    'Private Sub F_QueryResult_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
    Private Sub F_QueryResult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 接收 F_Query.vb 傳遞過來的 SQL 指令、彙總方式之代號、比對種類之代號、比對檔之檔名及路徑
        'Msqlstr_1 = F_Query.Tag

        Msqlstr_1 = F_Query.ASendList(0)
        MSubTotalKind = F_Query.ASendList(1)
        MMatchKind = F_Query.ASendList(2)
        MSourceFile = F_Query.ASendList(3)
        MLenExt = F_Query.ASendList(4)

        ' 顯示等待訊息 ***********************************************************************************
        F_wait.Show()

        ' 開始計時
        Dim MTempTime As Date = DateTime.Now

        ' 清空資料格控制項
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = "記錄數： 0"

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet

        ' 因第二次呼叫本表單之前已釋放本表單資源，故下段程式已無需要
        ' 第二次以上查詢時，先清除 Table01
        'Dim O_RemoveTable As DataTable = ODataSet_1.Tables("Table01")
        'If ODataSet_1.Tables.CanRemove(O_RemoveTable) Then
        'ODataSet_1.Tables.Remove(O_RemoveTable)
        ''ODataSet_1.Tables("Table01").Rows.Clear()
        ''ODataSet_1.Tables("Table01").Columns.Clear()
        'End If

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 若比對種類 MMatchKind <> 0 ，則需進行比對 *******************************************************************************************
        Select Case MMatchKind
            Case 1
                ' 將 User 指定的『員工號』比對檔的資料 存入 DataTable，然後使用 DataView 的 RowFilter 屬性與薪津資料比對
                ' 先使用 ADO 讀取比對檔（Excel 檔）
                ' 設定連接字串，供 OleDbConnection 物件使用
                ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
                ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
                ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
                Dim MFN_1 As String = (MSourceFile)
                Dim Mstrconn_1 As String = ""
                If MLenExt >= 5 Then
                    Mstrconn_1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
                Else
                    Mstrconn_1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"
                End If

                ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
                Dim Ocn_2 As New OleDbConnection(Mstrconn_1)
                Ocn_2.Open()

                ' 讀取第一張工作表的名稱，並存入變數 MSheet1Name
                ' OleDbConnection 的 GetSchema 方法 可讀出檔案結構描述資訊，它是一個資訊集合，可存入資料表
                ' 括號內為結構描述的名稱，例如 Tables、Columns、Indexes等，若不指定，則傳回一般摘要資訊，
                ' 若結構描述名稱為 Tables 時，其中第 3 欄為工作表名稱，第 8 欄為檔案產生日期
                ' 如此，User 無論將工作表名稱改為何種名稱都可抓出，也可克服新舊版 Excel 工作表名稱不同的困擾
                ' GetSchema 所讀出的資料表名稱是排序過的，故若要固定讀取第一張工作表，則須要求 User 將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表
                Dim MSheet1Name As String = ""
                Dim O_Information As DataTable
                O_Information = Ocn_2.GetSchema("Tables")
                MSheet1Name = O_Information.Rows(0)(2)

                ' 設定 SQL 字串，供資料轉接器使用
                Dim Msqlstr_1 As String = "Select * From [" + MSheet1Name + "]"

                ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
                Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_1, Ocn_2)

                ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
                ' ODataSet_1 資料集含有兩個資料表，Table01 儲存薪津資料（取自 SQL Server），TabMatch 儲存比對資料（取自 Excel 檔）
                ODataAdapter_2.Fill(ODataSet_1, "TabMatch")

                ' 使用 DefaultView 屬性建立預設的資料檢視表（此 DataView 資料檢視表物件可儲存從 DataTable 篩選或排序後的資料）
                Dim O_DataView As DataView
                O_DataView = ODataSet_1.Tables("TabMatch").DefaultView

                ' 開始比對 DataTable，非 DataView 之值，則刪除之
                ' 需反向刪除，否則執行過半後，可能因 Mcou 大於實際存在之列號而發生錯誤
                ' 使用資料檢視表的 RowFilter 屬性來過濾資料，若 DataTable 第一欄（即員工號）的資料不存在於 DataView 之中，則 Count 傳回 0，
                ' 此時應使用 Detele 方法刪除 DataTable 之中的該筆資料
                ' 因為比對資料（取自 Excel 檔）沒有欄名，故 DataView 資料檢視表的內定欄名為 F1（若有第二欄，則為 F2，餘類推），
                ' 比較值（本例為 Mcheck）的前後要加單引號
                Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
                Dim Mcheck As String = ""
                For Mcou = Mstop To 0 Step -1
                    Mcheck = ODataSet_1.Tables("Table01").Rows(Mcou)(0)
                    O_DataView.RowFilter = "F1='" + Mcheck + "'"
                    If O_DataView.Count = 0 Then
                        ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
                    End If
                Next

            Case 2
                ' 將 User 指定的『部門代號』比對檔的資料 存入清單集合類別 List01，再與薪津資料比對
                ' 先使用 ADO 讀取比對檔（Excel 檔）
                ' 設定連接字串，供 OleDbConnection 物件使用
                ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
                ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
                ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
                Dim MFN_1 As String = (MSourceFile)
                Dim Mstrconn_1 As String = ""
                If MLenExt >= 5 Then
                    Mstrconn_1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
                Else
                    Mstrconn_1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"
                End If

                ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
                Dim Ocn_2 As New OleDbConnection(Mstrconn_1)
                Ocn_2.Open()

                ' 讀取第一張工作表的名稱，並存入變數 MSheet1Name
                ' OleDbConnection 的 GetSchema 方法 可讀出檔案結構描述資訊，它是一個資訊集合，可存入資料表
                ' 括號內為結構描述的名稱，例如 Tables、Columns、Indexes等，若不指定，則傳回一般摘要資訊，
                ' 若結構描述名稱為 Tables 時，其中第 3 欄為工作表名稱，第 8 欄為檔案產生日期
                ' 如此，User 無論將工作表名稱改為何種名稱都可抓出，也可克服新舊版 Excel 工作表名稱不同的困擾
                ' GetSchema 所讀出的資料表名稱是排序過的，故若要固定讀取第一張工作表，則須要求 User 將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表
                Dim MSheet1Name As String = ""
                Dim O_Information As DataTable
                O_Information = Ocn_2.GetSchema("Tables")
                MSheet1Name = O_Information.Rows(0)(2)

                ' 設定 SQL 字串，供資料轉接器使用
                Dim Msqlstr_1 As String = "Select * From [" + MSheet1Name + "]"

                ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_2），括號內有兩個參數，分別為  SQL 指令 與 連結物件
                Dim Ocmd_2 As New OleDbCommand(Msqlstr_1, Ocn_2)

                ' 使用 OleDbCommand 的 ExecuteReader 方法將讀出的資料存入 OleDbDataReader 資料讀取物件
                ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
                Dim Odataread_0 As OleDbDataReader
                Odataread_0 = Ocmd_2.ExecuteReader()

                ' 將比對資料從 OleDbDataReader 存入清單集合類別 List01，再與薪津資料比對
                ' 使用清單集合類別需引用 System.Collections.Generic 泛型集合命名空間，
                ' 首先使用 List 建構函式建立新的清單集合物件 List01，括號內以 Of 關鍵字指出其型別
                ' 然後使用 Add 方法，將比對資料逐一插入清單集合物件，其優點是無需宣告元素大小，也無需調整集合之大小，程式較簡潔，效能亦較優
                Dim List01 As New List(Of String)
                Do While Odataread_0.Read() = True
                    If IsDBNull(Odataread_0.Item(0)) = False Then
                        List01.Add(Odataread_0.Item(0))
                    End If
                Loop

                ' 關閉 存取資料庫的相關物件
                Ocmd_2.Dispose()
                Ocn_2.Close()
                Ocn_2.Dispose()
                Odataread_0.Close()

                ' 開始比對 DataTable，非清單集合之值，則刪除之
                ' 需反向刪除，否則執行過半後，可能因 Mcou 大於實際存在之列號而發生錯誤
                ' 使用清單的 IndexOf 方法 來比對資料，若 DataTable 第 4 欄（即部門代號）的資料不存在於清單集合之中，則傳回 -1，
                ' 此時應使用 Detele 方法刪除 DataTable 之中的該筆資料
                Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
                Dim Mcheck As String = ""
                For Mcou = Mstop To 0 Step -1
                    Mcheck = ODataSet_1.Tables("Table01").Rows(Mcou)(3)
                    If List01.IndexOf(Mcheck) = -1 Then
                        ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
                    End If
                Next

            Case 3
                ' 將 User 指定的『職稱』比對檔的資料 存入清單集合類別 List01 或 陣列 ATabTitle，再與薪津資料比對
                ' 先使用 ADO 讀取比對檔（Excel 檔）
                ' 設定連接字串，供 OleDbConnection 物件使用
                ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
                ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
                ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
                Dim MFN_1 As String = (MSourceFile)
                Dim Mstrconn_1 As String = ""
                If MLenExt >= 5 Then
                    Mstrconn_1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
                Else
                    Mstrconn_1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"
                End If

                ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
                Dim Ocn_2 As New OleDbConnection(Mstrconn_1)
                Ocn_2.Open()

                ' 讀取第一張工作表的名稱，並存入變數 MSheet1Name
                ' OleDbConnection 的 GetSchema 方法 可讀出檔案結構描述資訊，它是一個資訊集合，可存入資料表
                ' 括號內為結構描述的名稱，例如 Tables、Columns、Indexes等，若不指定，則傳回一般摘要資訊，
                ' 若結構描述名稱為 Tables 時，其中第 3 欄為工作表名稱，第 8 欄為檔案產生日期
                ' 如此，User 無論將工作表名稱改為何種名稱都可抓出，也可克服新舊版 Excel 工作表名稱不同的困擾
                ' GetSchema 所讀出的資料表名稱是排序過的，故若要固定讀取第一張工作表，則須要求 User 將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表
                Dim MSheet1Name As String = ""
                Dim O_Information As DataTable
                O_Information = Ocn_2.GetSchema("Tables")
                MSheet1Name = O_Information.Rows(0)(2)

                ' 設定 SQL 字串，供資料轉接器使用
                Dim Msqlstr_1 As String = "Select * From [" + MSheet1Name + "]"

                ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
                ' 無需使用 OleDbCommand 物件
                Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_1, Ocn_2)

                ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
                ' ODataSet_1 資料集含有兩個資料表，Table01 儲存薪津資料（取自 SQL Server），TabMatch 儲存比對資料（取自 Excel 檔）
                ODataAdapter_2.Fill(ODataSet_1, "TabMatch")

                ' 方法一，將比對資料存入陣列 ATabTitle，再與薪津資料比對
                'Dim ATabTitle(0) As String
                'Dim Mstop As Int32 = ODataSet_1.Tables("TabMatch").Rows.Count - 1
                'For Mcou = 0 To Mstop Step 1
                'ATabTitle(Mcou) = Trim(ODataSet_1.Tables("TabMatch").Rows(Mcou)(0))
                'ReDim Preserve ATabTitle(Mcou + 1)
                'Next
                ' 使用 Resize 方法重新調整陣列大小，以便刪除無資料的元素，括號內第一個參數為陣列名稱，第二個參數為 調整後的大小（陣列元素）
                'Array.Resize(ATabTitle, Mstop + 1)

                ' 方法二，將比對資料存入清單集合類別 List01，再與薪津資料比對
                ' 使用清單集合類別需引用 System.Collections.Generic 泛型集合命名空間，
                ' 首先使用 List 建構函式建立新的清單集合物件 List01，括號內以 Of 關鍵字指出其型別
                ' 然後使用 Add 方法，將比對資料逐一插入清單集合物件，其優點是無需宣告元素大小，也無需調整集合之大小，程式較簡潔，效能亦較優
                Dim List01 As New List(Of String)
                Dim Mstop As Int32 = ODataSet_1.Tables("TabMatch").Rows.Count - 1
                For Mcou = 0 To Mstop Step 1
                    List01.Add(Trim(ODataSet_1.Tables("TabMatch").Rows(Mcou)(0)))
                Next

                ' 關閉 存取資料庫的相關物件
                Ocn_2.Close()
                Ocn_2.Dispose()
                ODataAdapter_1.Dispose()
                ODataAdapter_2.Dispose()

                ' 開始比對 DataTable，非陣列之值，則刪除之
                ' 需反向刪除，否則執行過半後，可能因 Mcou 大於實際存在之列號而發生錯誤
                ' 使用陣列或清單集合的 IndexOf 方法 來比對資料，若 DataTable 第 7 欄（即職稱）的資料不存在於陣列或清單集合之中，則傳回 -1，
                ' 此時應使用 Detele 方法刪除 DataTable 之中的該筆資料
                Dim Mstop1 As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
                Dim Mcheck As String = ""
                For Mcou = Mstop1 To 0 Step -1
                    Mcheck = ODataSet_1.Tables("Table01").Rows(Mcou)(6)
                    'If Array.IndexOf(ATabTitle, Mcheck) = -1 Then
                    If List01.IndexOf(Mcheck) = -1 Then
                        ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
                    End If
                Next
        End Select
        ' 使用資料集的AcceptChanges 方法 認可前述之變更
        ODataSet_1.Tables("Table01").AcceptChanges()

        ' 指定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If MTotalRecordNo = 0 Then
            T_RecordNo.Text = "記錄數： 0 / " + MTotalRecordNo.ToString
        Else
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
        End If

        ' 加入中文欄名，欄名因匯總方式而不同
        Select Case MSubTotalKind
            Case 1
                With DataGridView1
                    .Columns(0).HeaderText = "員工號"
                    .Columns(1).HeaderText = "員工姓名"
                    .Columns(2).HeaderText = "性別"
                    .Columns(3).HeaderText = "部門代號"
                    .Columns(4).HeaderText = "部門名稱"
                    .Columns(5).HeaderText = "職稱代號"
                    .Columns(6).HeaderText = "職稱"
                    .Columns(7).HeaderText = "等級"
                    .Columns(8).HeaderText = "數量"
                    .Columns(9).HeaderText = "年資"
                    .Columns(10).HeaderText = "年齡"
                    .Columns(11).HeaderText = "薪津"
                    .Columns(12).HeaderText = "津貼"
                    .Columns(13).HeaderText = "伙食費"
                    .Columns(14).HeaderText = "日期"
                End With
            Case 2
                With DataGridView1
                    .Columns(0).HeaderText = "部門代號"
                    .Columns(1).HeaderText = "數量"
                    .Columns(2).HeaderText = "薪津"
                    .Columns(3).HeaderText = "津貼"
                    .Columns(4).HeaderText = "伙食費"
                End With
            Case 3
                With DataGridView1
                    .Columns(0).HeaderText = "部門代號"
                    .Columns(1).HeaderText = "等級"
                    .Columns(2).HeaderText = "數量"
                    .Columns(3).HeaderText = "薪津"
                    .Columns(4).HeaderText = "津貼"
                    .Columns(5).HeaderText = "伙食費"
                End With
            Case 4
                With DataGridView1
                    .Columns(0).HeaderText = "部門代號"
                    .Columns(1).HeaderText = "職稱"
                    .Columns(2).HeaderText = "性別"
                    .Columns(3).HeaderText = "數量"
                    .Columns(4).HeaderText = "薪津"
                    .Columns(5).HeaderText = "津貼"
                    .Columns(6).HeaderText = "伙食費"
                End With
        End Select

        ' 格式化及列高調整非常耗時，若為明細資料，則不使用，其他彙總方式才使用
        ' 金額等欄位格式化
        'With DataGridView1
        '.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '.Columns(8).DefaultCellStyle.Format = "#,0"
        '.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(9).DefaultCellStyle.Format = "#,0.0"
        '.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(10).DefaultCellStyle.Format = "#,0.0"
        '.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(11).DefaultCellStyle.Format = "#,0"
        '.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(12).DefaultCellStyle.Format = "#,0"
        '.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(13).DefaultCellStyle.Format = "#,0"
        '.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With
        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        'DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        'Dim mtprow As Object
        'For Each mtprow In DataGridView1.Rows
        'mtprow.Height = 24
        'Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        'DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        'DataGridView1.ColumnHeadersHeight = 28

        Select Case MSubTotalKind
            Case 2
                With DataGridView1
                    .Columns(2).DefaultCellStyle.Format = "#,0"
                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(3).DefaultCellStyle.Format = "#,0"
                    .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(4).DefaultCellStyle.Format = "#,0"
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
            Case 3
                With DataGridView1
                    .Columns(3).DefaultCellStyle.Format = "#,0"
                    .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(4).DefaultCellStyle.Format = "#,0"
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(5).DefaultCellStyle.Format = "#,0"
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
            Case 4
                With DataGridView1
                    .Columns(4).DefaultCellStyle.Format = "#,0"
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(5).DefaultCellStyle.Format = "#,0"
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(6).DefaultCellStyle.Format = "#,0"
                    .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
        End Select

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 結束等待訊息 ***********************************************************************************
        F_wait.Hide()

        ' 使用 DataTable 的 Compute 方法計算小計，並顯示於螢幕右方中央
        ' Compute 方法的括號內有兩個參數，第一個為運算式，第二個為篩選條件
        ' 若 DataTable 之中無資料，則傳回值會是 DBNull.Value，
        ' 故接收計算結果的變數之型別（例如 Mtotal_2）宜用 Object，或使用下列判斷方式
        If MTotalRecordNo > 0 Then
            Dim O_DataTable As DataTable = ODataSet_1.Tables("Table01")
            Dim Mtotal_1 As Int32
            Mtotal_1 = O_DataTable.Compute("count(dept_code)", "dept_code like '%'")
            Dim Mtotal_2 As Object
            Mtotal_2 = O_DataTable.Compute("Sum(wages)", "dept_code like '%'")
            Dim Mtotal_3 As Object
            Mtotal_3 = O_DataTable.Compute("Sum(allowance)", "dept_code like '%'")
            Dim Mtotal_4 As Object
            Mtotal_4 = O_DataTable.Compute("Sum(meal)", "dept_code like '%'")

            T_TOTREC.Text = Format(Mtotal_1, "#,0")
            T_TOTWAGES.Text = Format(Mtotal_2, "#,0")
            T_TOTALLOWANCE.Text = Format(Mtotal_3, "#,0")
            T_TOTMEAL.Text = Format(Mtotal_4, "#,0")
            '        Else
            '            T_TOTREC.Text = 0
            '            T_TOTWAGES.Text = 0
            '            T_TOTALLOWANCE.Text = 0
            '            T_TOTMEAL.Text = 0
        End If

        ' 結束計時並顯示耗用時間，全部 28337 筆 耗時約 5 分 37 秒
        Dim MTempSec As Integer = DateDiff("s", MTempTime, DateTime.Now)
        Dim MResSec As Integer = MTempSec Mod 60
        Dim MResMin As Integer = Int(MTempSec / 60)
        L_ElapsedTime.Text = "耗用時間： " + MResMin.ToString + " 分 " + MResSec.ToString + " 秒"

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 屬性，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If
    End Sub

    ' DataGridView 選取變動事件中傳回游標所在列的資料
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As SqlInt32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

        ' 將游標所在列的資料顯示於各個文字盒，隨彙總方式之不同而調整
        Select Case MSubTotalKind
            Case 1
                T_ENO.Text = DataGridView1.CurrentRow.Cells(0).Value
                T_NAME.Text = DataGridView1.CurrentRow.Cells(1).Value
                T_SEX.Text = DataGridView1.CurrentRow.Cells(2).Value
                T_DEPTCODE.Text = DataGridView1.CurrentRow.Cells(3).Value
                T_DEPTNAME.Text = DataGridView1.CurrentRow.Cells(4).Value
                T_TITLECODE.Text = DataGridView1.CurrentRow.Cells(5).Value
                T_TITLE.Text = DataGridView1.CurrentRow.Cells(6).Value
                T_GRADE.Text = DataGridView1.CurrentRow.Cells(7).Value
                T_WAGES.Text = Format(DataGridView1.CurrentRow.Cells(11).Value, "#,0")
                T_ALLOWANCE.Text = Format(DataGridView1.CurrentRow.Cells(12).Value, "#,0")
                T_MEAL.Text = Format(DataGridView1.CurrentRow.Cells(13).Value, "#,0")
            Case 2
                T_ENO.Text = ""
                T_NAME.Text = ""
                T_SEX.Text = ""
                T_DEPTCODE.Text = DataGridView1.CurrentRow.Cells(0).Value
                T_DEPTNAME.Text = ""
                T_TITLECODE.Text = ""
                T_TITLE.Text = ""
                T_GRADE.Text = ""
                T_WAGES.Text = Format(DataGridView1.CurrentRow.Cells(2).Value, "#,0")
                T_ALLOWANCE.Text = Format(DataGridView1.CurrentRow.Cells(3).Value, "#,0")
                T_MEAL.Text = Format(DataGridView1.CurrentRow.Cells(4).Value, "#,0")
            Case 3
                T_ENO.Text = ""
                T_NAME.Text = ""
                T_SEX.Text = ""
                T_DEPTCODE.Text = DataGridView1.CurrentRow.Cells(0).Value
                T_DEPTNAME.Text = ""
                T_GRADE.Text = DataGridView1.CurrentRow.Cells(1).Value
                T_TITLECODE.Text = ""
                T_TITLE.Text = ""
                T_WAGES.Text = Format(DataGridView1.CurrentRow.Cells(3).Value, "#,0")
                T_ALLOWANCE.Text = Format(DataGridView1.CurrentRow.Cells(4).Value, "#,0")
                T_MEAL.Text = Format(DataGridView1.CurrentRow.Cells(5).Value, "#,0")
            Case 4
                T_ENO.Text = ""
                T_NAME.Text = ""
                T_SEX.Text = DataGridView1.CurrentRow.Cells(2).Value
                T_DEPTCODE.Text = DataGridView1.CurrentRow.Cells(0).Value
                T_DEPTNAME.Text = ""
                T_TITLECODE.Text = ""
                T_TITLE.Text = DataGridView1.CurrentRow.Cells(1).Value
                T_GRADE.Text = ""
                T_WAGES.Text = Format(DataGridView1.CurrentRow.Cells(4).Value, "#,0")
                T_ALLOWANCE.Text = Format(DataGridView1.CurrentRow.Cells(5).Value, "#,0")
                T_MEAL.Text = Format(DataGridView1.CurrentRow.Cells(6).Value, "#,0")
        End Select

    End Sub

    ' 移動游標至第一筆
    ' 只使用 Select 方法來選定目標儲存格，例如 DataGridView1(0, 0).Selected = True，是無法達到預期效果的，
    ' 第一，若目標儲存格（例如最後一筆）不在顯示範圍內，則不會自動捲動到顯示範圍內，
    ' 第二，不會引發 DataGridView 的 SelectionChanged 選取變動事件，故無法傳回游標所在列的資料。
    ' 改進辦法，使用 DataGridViewRow 資料網格檢視列物件
    ' 將目標儲存格（例如最後一筆）宣告為 DataGridViewRow 資料網格檢視列物件
    ' 然後使用 DataGridView 資料網格檢視物件的 CurrentCell 屬性，指定  DataGridViewRow 資料網格檢視列物件的第一格位為作用格位，
    ' 最後再使用 DataGridViewRow 資料網格檢視列物件的 Selected 屬性取選目標列即可
    ' 使用 CurrentCell 屬性可解決前述問題，如果目前儲存格不在顯示範圍內，則會自動捲動到顯示範圍內，且會引發 CurrentCellChanged 事件
    ' DataGridView 的 ClearSelection 方法可清除目前已選取的格位
    Private Sub B_TOP_Click(sender As Object, e As EventArgs) Handles B_TOP.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            'Dim O_DataRow As DataGridViewRow
            'O_DataRow = DataGridView1.Rows(0)
            Dim O_DataRow As DataGridViewRow = DataGridView1.Rows(0)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至最後一筆
    Private Sub B_BOT_Click(sender As Object, e As EventArgs) Handles B_BOT.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MTotalRecordNo - 1)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至前一筆
    Private Sub B_PREV_Click(sender As Object, e As EventArgs) Handles B_PREV.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()

            ' 計算前一筆的列號，並存入變數 MRowNo（目前游標所在之列號減 1），但不能小於 0
            Dim MRowNo As Int32 = DataGridView1.CurrentRow.Index - 1
            If MRowNo < 0 Then
                MRowNo = 0
            End If

            ' 宣告下一列為 DataGridViewRow 物件，並將其第一格位設為作用儲存格
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MRowNo)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至下一筆
    Private Sub B_NEXT_Click(sender As Object, e As EventArgs) Handles B_NEXT.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()

            ' 計算下一筆的列號，並存入變數 MRowNo（目前游標所在之列號加 1），但不能超過總筆數減 1
            Dim MRowNo As Int32 = DataGridView1.CurrentRow.Index + 1
            If MRowNo > MTotalRecordNo - 1 Then
                MRowNo = MTotalRecordNo - 1
            End If

            ' 宣告下一列為 DataGridViewRow 物件，並將其第一格位設為作用儲存格
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MRowNo)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 將查詢結果匯出為 Excel 檔
    Private Sub B_Export_Click(sender As Object, e As EventArgs) Handles B_Export.Click
          Select MSubTotalKind
            Case 1
                ' 匯出明細表（使用 ADO 將 DataGridView 的資料匯出為 Excel 檔）
                ' 先使用 CreateDirectory 方法建立資料夾 D:\TestQuery，以便儲存匯出的 Excel 檔
                ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
                If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
                    My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
                End If

                ' 若檔案 D:\TestQuery\TestSalary_01.xls 已存在，則刪除之，以便本程序可重複使用
                If System.IO.File.Exists("D:\TestQuery\TestSalary_01.xls") = True Then
                    My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestSalary_01.xls")
                End If

                ' 設定連接管道
                Dim MFN_0 As String = "D:\TestQuery\TestSalary_01.xls"
                Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
                Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
                Oconn_0.Open()

                ' 插入欄名
                Dim Msqlstr_0 As String = "Create Table Sheet1 ([員工號] Text(5), [員工姓名] Text(10), [性別] Text(1), [部門代號] Text(4), [部門名稱] Text(10), [職稱代號] Text(3), [職稱] Text(14), [等級] Text(3), [數量] Integer, [年資] double, [年齡] double, [薪津] double, [津貼] double, [伙食費] double, [日期] Text(6))"
                Dim Ocmd_0 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_0)
                Ocmd_0.ExecuteNonQuery()

                ' 插入資料
                Dim MRowNo As Int32 = DataGridView1.Rows.Count - 1
                Dim Msqlstr_1 As String = ""
                Dim MSheetName As String = "Sheet1"
                Dim Ocmd_1 As New System.Data.OleDb.OleDbCommand
                Ocmd_1.Connection = Oconn_0

                ' 使用 For 迴圈逐列將 DataGridView 的資料匯出至 Excel 檔
                ' Insert 指令中無需指定欄名，Values 之後接 @具名參數，以降低 SQL 指令的複雜度
                On Error Resume Next
                For Mcou = 0 To MRowNo Step 1
                    Msqlstr_1 = "Insert Into [" + MSheetName + "] Values(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15)"
                    Ocmd_1.Parameters.Clear()
                    Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(0).Value
                    Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(1).Value
                    Ocmd_1.Parameters.AddWithValue("@t3", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(2).Value
                    Ocmd_1.Parameters.AddWithValue("@t4", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(3).Value
                    Ocmd_1.Parameters.AddWithValue("@t5", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(4).Value
                    Ocmd_1.Parameters.AddWithValue("@t6", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(5).Value
                    Ocmd_1.Parameters.AddWithValue("@t7", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(6).Value
                    Ocmd_1.Parameters.AddWithValue("@t8", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(7).Value
                    Ocmd_1.Parameters.AddWithValue("@t9", DbType.Int32).Value = DataGridView1.Rows(Mcou).Cells(8).Value
                    Ocmd_1.Parameters.AddWithValue("@t10", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(9).Value
                    Ocmd_1.Parameters.AddWithValue("@t11", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(10).Value
                    Ocmd_1.Parameters.AddWithValue("@t12", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(11).Value
                    Ocmd_1.Parameters.AddWithValue("@t13", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(12).Value
                    Ocmd_1.Parameters.AddWithValue("@t14", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(13).Value
                    Ocmd_1.Parameters.AddWithValue("@t15", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(14).Value
                    Ocmd_1.CommandText = Msqlstr_1
                    Ocmd_1.ExecuteNonQuery()
                Next

                ' 關閉相關物件及釋放資源
                Ocmd_0.Dispose()
                Ocmd_1.Dispose()
                Oconn_0.Close()
                MsgBox("資料已匯出至 D:\TestQuery\TestSalary_01.xls！", 0 + 64, "OK")

            Case 2
                ' 匯出部門小計表（使用 COM 將 DataGridView 的資料匯出為 Excel 檔）
                ' 先使用 CreateDirectory 方法建立資料夾 D:\TestQuery，以便儲存匯出的 Excel 檔
                ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
                If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
                    My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
                End If

                ' 若檔案 D:\TestQuery\TestSalary_02.xls 已存在，則刪除之，以便本程序可重複使用
                If System.IO.File.Exists("D:\TestQuery\TestSalary_02.xls") = True Then
                    My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestSalary_02.xls")
                End If

                ' 宣告應用程式物件  OLEAPP，啟動 Excel 應用程式
                Dim OLEAPP As Object = CreateObject("Excel.Application")
                ' 關閉可見
                OLEAPP.Visible = False
                ' 關閉警告視窗
                OLEAPP.DisplayAlerts = False

                ' 宣告活頁簿物件 Mybook，由 Excel 應用程式新增一個活頁簿
                Dim MyBook = OLEAPP.Workbooks.Add()
                ' 宣告工作表物件 MySheet，並以表第一張工作表為作用工作表，Worksheets 括號內可為工作表名稱（須加雙引號）或工作表索引順序
                ' 作用工作表為程式處理之對象
                Dim MySheet As Object = MyBook.Worksheets(1)
                MySheet.Activate()

                ' 使用 For 迴圈逐列將 DataGridView 的資料匯出至 Excel 檔（本例從第５列開始）
                ' 在儲存格置入資料需使用 Value 屬性指定並標示其儲存格位置，
                ' 位置標示有兩種方法:
                ' 使用 Cells 屬性指定位置，括號內為列號及行號，均由 1 起算
                ' 使用 Range 屬性指定位置，括號內為儲存格標示，須加雙引號
                ' 日期欄的格式設為文字，匯入 Excel 之後再格式化，若設為日期時間格式，則當該欄無資料時匯入 Excel 仍會殘留多餘的時間
                ' 先判斷 DataGridView 的資料是否為 Null，再以適當值匯出至 Excel
                Dim MStop As Int32 = DataGridView1.Rows.Count - 1
                Dim Mdeptcode As String = ""
                Dim Mqty As Int32 = 0
                Dim Mwages As Double = 0
                Dim Mallowance As Double = 0
                Dim Mmeal As Double = 0

                For Mrow = 0 To MStop Step 1
                    If IsDBNull(DataGridView1.Rows(Mrow).Cells(0).Value) = True Then
                        Mdeptcode = ""
                    Else
                        Mdeptcode = DataGridView1.Rows(Mrow).Cells(0).Value
                    End If
                    If IsDBNull(DataGridView1.Rows(Mrow).Cells(1).Value) = True Then
                        Mqty = Nothing
                    Else
                        Mqty = DataGridView1.Rows(Mrow).Cells(1).Value
                    End If
                    If IsDBNull(DataGridView1.Rows(Mrow).Cells(2).Value) = True Then
                        Mwages = Nothing
                    Else
                        Mwages = DataGridView1.Rows(Mrow).Cells(2).Value
                    End If
                    If IsDBNull(DataGridView1.Rows(Mrow).Cells(3).Value) = True Then
                        Mallowance = ""
                    Else
                        Mallowance = DataGridView1.Rows(Mrow).Cells(3).Value
                    End If
                    If IsDBNull(DataGridView1.Rows(Mrow).Cells(4).Value) = True Then
                        Mmeal = ""
                    Else
                        Mmeal = DataGridView1.Rows(Mrow).Cells(4).Value
                    End If

                    MySheet.Cells(Mrow + 5, 1).Value = Mdeptcode
                    MySheet.Cells(Mrow + 5, 2).Value = Mqty
                    MySheet.Cells(Mrow + 5, 3).Value = Mwages
                    MySheet.Cells(Mrow + 5, 4).Value = Mallowance
                    MySheet.Cells(Mrow + 5, 5).Value = Mmeal
                Next

                ' 置入標題於 A1 儲存格
                MySheet.Range("A1").Value = "薪津統計表_部門小計"
                ' 置入欄位名稱於第４列
                MySheet.Range("A4").Value = "部門代號"
                MySheet.Range("B4").Value = "數量"
                MySheet.Range("C4").Value = "薪津"
                MySheet.Range("D4").Value = "津貼"
                MySheet.Range("E4").Value = "伙食費"
                ' 置入計算公式於 A3 儲存格，以便計算總筆數（使用 Value 指定，不能使用 Formula）
                MySheet.Range("A3").Value = "=Counta(A5:A65536)"

                ' 標題格式化
                OLEAPP.Range("A1").Select()
                OLEAPP.Selection.RowHeight = 30
                OLEAPP.Selection.Font.Name = "新細明體"
                OLEAPP.Selection.Font.FontStyle = "粗體"
                OLEAPP.Selection.Font.ColorIndex = 5
                OLEAPP.Selection.Font.Size = 16

                '『欄名』格式化
                OLEAPP.Range("A4:E4").Select()
                ' 設定底色為淺黃色
                OLEAPP.Selection.Interior.ColorIndex = 19
                ' 畫線（使用藍色實線）
                OLEAPP.Selection.Borders(1).LineStyle = 1
                OLEAPP.Selection.Borders(2).LineStyle = 1
                OLEAPP.Selection.Borders(3).LineStyle = 1
                OLEAPP.Selection.Borders(4).LineStyle = 1
                OLEAPP.Selection.Borders(1).ColorIndex = 11
                OLEAPP.Selection.Borders(2).ColorIndex = 11
                OLEAPP.Selection.Borders(3).ColorIndex = 11
                OLEAPP.Selection.Borders(4).ColorIndex = 11
                ' 置中（不能使用 xlCenter，需使用阿拉伯數字，3 置中、4 靠右）
                ' OLEAPP.Selection.HorizontalAlignment = xlCenter
                OLEAPP.Selection.HorizontalAlignment = 3
                ' 改字體（大小12、顏色紫色）
                OLEAPP.Selection.Font.Name = "新細明體"
                OLEAPP.Selection.Font.FontStyle = "標準"
                OLEAPP.Selection.Font.Size = 12
                OLEAPP.Selection.Font.ColorIndex = 13
                OLEAPP.Selection.RowHeight = 24

                ' 計算公式格式化
                ' 顏色可用 Color 屬性或 ColorIndex 屬性指定，前者以 RGB 數碼指定，例如紅色為 RGB(255, 0, 0)，
                ' 後者以索引值指定，例如紅色為 3，基本顏色的筍引值請見第9章表4之『16種基本顏色名稱對照表』
                OLEAPP.Range("A3").Select()
                OLEAPP.Selection.RowHeight = 18
                OLEAPP.Selection.Font.Name = "Arial"
                OLEAPP.Selection.Font.FontStyle = "標準"
                'OLEAPP.Selection.Font.ColorIndex = 3
                OLEAPP.Selection.Font.Color = RGB(255, 0, 0)
                OLEAPP.Selection.Font.Size = 11
                OLEAPP.Selection.HorizontalAlignment = 3
                ' 第二列格式化
                OLEAPP.Range("A2").Select()
                OLEAPP.Selection.RowHeight = 18

                ' 調整欄寬
                OLEAPP.Columns("A:A").Select()
                OLEAPP.Selection.ColumnWidth = 10
                OLEAPP.Columns("B:B").Select()
                OLEAPP.Selection.ColumnWidth = 12
                OLEAPP.Columns("C:C").Select()
                OLEAPP.Selection.ColumnWidth = 16
                OLEAPP.Columns("D:D").Select()
                OLEAPP.Selection.ColumnWidth = 16
                OLEAPP.Columns("E:E").Select()
                OLEAPP.Selection.ColumnWidth = 16

                ' 表頭區儲存格底色
                OLEAPP.Range("A1:E3").Select()
                OLEAPP.Selection.Interior.ColorIndex = 2

                ' 資料區進行格式化（調整字型大小、字體顏色、儲存格底色及列高等，從第5列開始）
                ' 先偵測及選定範圍，左上角為 A5，根據 A3 公式算出的筆數來判斷右小角的位置，然後使用 Select 方法選定該格位選定，再以 Address 屬性傳回其位址
                Dim MRecordNo As Int32 = MySheet.Range("A3").Value
                OLEAPP.Cells(MRecordNo + 4, 5).Select()
                Dim MAddress As String = OLEAPP.Selection.Address
                Dim MRange As String = "A5:" + MAddress

                OLEAPP.Range(MRange).Select()
                OLEAPP.Selection.RowHeight = 18
                OLEAPP.Selection.Font.Name = "Arial"
                OLEAPP.Selection.Font.FontStyle = "標準"
                OLEAPP.Selection.Font.Size = 11
                OLEAPP.Selection.Interior.ColorIndex = 2

                ' 數字欄格式化，本例為第 2 欄數量（無小數）、第 3至5 欄金額（小數兩位）
                ' 先偵測及選定範圍
                OLEAPP.Cells(MRecordNo + 4, 2).Select()
                MAddress = OLEAPP.Selection.Address
                MRange = "B5:" + MAddress
                OLEAPP.Range(MRange).Select()
                OLEAPP.Selection.NumberFormatLocal = "#,##0"

                OLEAPP.Cells(MRecordNo + 4, 5).Select()
                MAddress = OLEAPP.Selection.Address
                MRange = "C5:" + MAddress
                OLEAPP.Range(MRange).Select()
                OLEAPP.Selection.NumberFormatLocal = "#,##0.00_ "

                ' 部門欄置中
                OLEAPP.Cells(MRecordNo + 4, 1).Select()
                MAddress = OLEAPP.Selection.Address
                MRange = "A5:" + MAddress
                OLEAPP.Range(MRange).Select()
                OLEAPP.Selection.HorizontalAlignment = 3

                ' 隱藏格線
                OLEAPP.ActiveWindow.DisplayGridlines = False

                ' 設定版面，上、下邊界各為 1 cm，Orientation=2 為橫印、1 為直印，
                ' PaperSize=1 為 Letter 、8 為 A3、9 為 A4
                OLEAPP.ActiveSheet.PageSetup.TopMargin = 27.78
                OLEAPP.ActiveSheet.PageSetup.BottomMargin = 0
                OLEAPP.ActiveSheet.PageSetup.LeftMargin = 27.78
                OLEAPP.ActiveSheet.PageSetup.RightMargin = 0
                OLEAPP.ActiveSheet.PageSetup.HeaderMargin = 0
                OLEAPP.ActiveSheet.PageSetup.FooterMargin = 0
                OLEAPP.ActiveSheet.PageSetup.Orientation = 1
                OLEAPP.ActiveSheet.PageSetup.PaperSize = 9

                ' 游標歸位
                OLEAPP.Range("A1").Select()
                OLEAPP.Range("A2").Select()

                ' 使用 SaveAs 方法將活頁簿物件 Mybook 存入檔案，括號內為檔名及路徑
                MyBook.SaveAs("D:\TestQuery\TestSalary_02.xls")

                ' 關閉相關物件並釋放資源
                MyBook.Close()
                MyBook = Nothing
                MySheet = Nothing
                OLEAPP.Quit()
                MsgBox("資料已匯出至 D:\TestQuery\TestSalary_02.xls！", 0 + 64, "OK")

            Case 3
                ' 匯出部門＋等級小計表（使用 ADO 將 DataGridView 的資料匯出為 Excel 檔）
                ' 先使用 CreateDirectory 方法建立資料夾 D:\TestQuery，以便儲存匯出的 Excel 檔
                ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
                If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
                    My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
                End If

                ' 若檔案 D:\TestQuery\TestSalary_03.xls 已存在，則刪除之，以便本程序可重複使用
                If System.IO.File.Exists("D:\TestQuery\TestSalary_03.xls") = True Then
                    My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestSalary_03.xls")
                End If

                ' 設定連接管道
                Dim MFN_0 As String = "D:\TestQuery\TestSalary_03.xls"
                Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
                Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
                Oconn_0.Open()

                ' 插入欄名
                Dim Msqlstr_0 As String = "Create Table Sheet1 ([部門代號] Text(4), [等級] Text(3), [數量] Integer, [薪津] double, [津貼] double, [伙食費] double)"
                Dim Ocmd_0 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_0)
                Ocmd_0.ExecuteNonQuery()

                ' 插入資料
                Dim MRowNo As Int32 = DataGridView1.Rows.Count - 1
                Dim Msqlstr_1 As String = ""
                Dim MSheetName As String = "Sheet1"
                Dim Ocmd_1 As New System.Data.OleDb.OleDbCommand
                Ocmd_1.Connection = Oconn_0

                ' 使用 For 迴圈逐列將 DataGridView 的資料匯出至 Excel 檔
                ' Insert 指令中無需指定欄名，Values 之後接 @具名參數，以降低 SQL 指令的複雜度
                On Error Resume Next
                For Mcou = 0 To MRowNo Step 1
                    Msqlstr_1 = "Insert Into [" + MSheetName + "] Values(@t1,@t2,@t3,@t4,@t5,@t6)"
                    Ocmd_1.Parameters.Clear()
                    Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(0).Value
                    Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(1).Value
                    Ocmd_1.Parameters.AddWithValue("@t3", DbType.Int32).Value = DataGridView1.Rows(Mcou).Cells(2).Value
                    Ocmd_1.Parameters.AddWithValue("@t4", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(3).Value
                    Ocmd_1.Parameters.AddWithValue("@t5", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(4).Value
                    Ocmd_1.Parameters.AddWithValue("@t6", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(5).Value
                    Ocmd_1.CommandText = Msqlstr_1
                    Ocmd_1.ExecuteNonQuery()
                Next

                ' 關閉相關物件及釋放資源
                Ocmd_0.Dispose()
                Ocmd_1.Dispose()
                Oconn_0.Close()
                MsgBox("資料已匯出至 D:\TestQuery\TestSalary_03.xls！", 0 + 64, "OK")

            Case 4
                ' 匯出部門＋職稱＋性別小計表（使用 ADO 將 DataGridView 的資料匯出為 Excel 檔）
                ' 先使用 CreateDirectory 方法建立資料夾 D:\TestQuery，以便儲存匯出的 Excel 檔
                ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
                If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
                    My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
                End If

                ' 若檔案 D:\TestQuery\TestSalary_04.xls 已存在，則刪除之，以便本程序可重複使用
                If System.IO.File.Exists("D:\TestQuery\TestSalary_04.xls") = True Then
                    My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestSalary_04.xls")
                End If

                ' 設定連接管道
                Dim MFN_0 As String = "D:\TestQuery\TestSalary_04.xls"
                Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
                Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
                Oconn_0.Open()

                ' 插入欄名
                Dim Msqlstr_0 As String = "Create Table Sheet1 ([部門代號] Text(4), [職稱] Text(14), [性別] Text(1), [數量] Integer, [薪津] double, [津貼] double, [伙食費] double)"
                Dim Ocmd_0 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_0)
                Ocmd_0.ExecuteNonQuery()

                ' 插入資料
                Dim MRowNo As Int32 = DataGridView1.Rows.Count - 1
                Dim Msqlstr_1 As String = ""
                Dim MSheetName As String = "Sheet1"
                Dim Ocmd_1 As New System.Data.OleDb.OleDbCommand
                Ocmd_1.Connection = Oconn_0

                ' 使用 For 迴圈逐列將 DataGridView 的資料匯出至 Excel 檔
                ' Insert 指令中無需指定欄名，Values 之後接 @具名參數，以降低 SQL 指令的複雜度
                On Error Resume Next
                For Mcou = 0 To MRowNo Step 1
                    Msqlstr_1 = "Insert Into [" + MSheetName + "] Values(@t1,@t2,@t3,@t4,@t5,@t6,@t7)"
                    Ocmd_1.Parameters.Clear()
                    Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(0).Value
                    Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(1).Value
                    Ocmd_1.Parameters.AddWithValue("@t3", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(2).Value
                    Ocmd_1.Parameters.AddWithValue("@t4", DbType.Int32).Value = DataGridView1.Rows(Mcou).Cells(3).Value
                    Ocmd_1.Parameters.AddWithValue("@t5", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(4).Value
                    Ocmd_1.Parameters.AddWithValue("@t6", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(5).Value
                    Ocmd_1.Parameters.AddWithValue("@t7", DbType.Double).Value = DataGridView1.Rows(Mcou).Cells(6).Value
                    Ocmd_1.CommandText = Msqlstr_1
                    Ocmd_1.ExecuteNonQuery()
                Next

                ' 關閉相關物件及釋放資源
                Ocmd_0.Dispose()
                Ocmd_1.Dispose()
                Oconn_0.Close()
                MsgBox("資料已匯出至 D:\TestQuery\TestSalary_04.xls！", 0 + 64, "OK")
        End Select
    End Sub

End Class