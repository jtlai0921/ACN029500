Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic

Public Class F_TableTitle

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0

    ' 以 Public 宣告資料庫處理物件，以便在不同程序中共同使用
    Public Ocn_1 As SqlConnection
    Public ODataSet_1 As DataSet



    ' ***********************************************************************************************************************************
    ' 載入本表單時抓出對照表的資料，並顯示於 DataGridView
    Private Sub F_TableDeptt_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' 顯示等待訊息 ***********************************************************************************
        F_wait.Show()

        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Ocn_1 = New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select * From TAB_TITLE"

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataSet_1 = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 讀出資料顯示於資料網格控制項
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If MTotalRecordNo = 0 Then
            T_RecordNo.Text = "記錄數： 0 / " + MTotalRecordNo.ToString
        Else
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
        End If

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "職稱代號"
            .Columns(1).HeaderText = "職稱"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 結束等待訊息 ***********************************************************************************
        F_wait.Hide()

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
        ' 去除空白，以方便 User 據以修改使用
        ' 因為 User 可能匯錯資料，故使用 On Error Resume Next 陳述式，以防止程式中斷
        On Error Resume Next
        T_TitleCode.Text = Strings.Trim(DataGridView1.CurrentRow.Cells(0).Value)
        T_Title.Text = Strings.Trim(DataGridView1.CurrentRow.Cells(1).Value)
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
            MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
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
            MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count

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

    ' 清空文字盒
    Private Sub B_CLEAR_Click(sender As Object, e As EventArgs) Handles B_CLEAR.Click
        T_TitleCode.Text = ""
        T_Title.Text = ""
    End Sub

    ' 新增（將資料插入 SQL Server 資料表）
    Private Sub B_ADD_Click(sender As Object, e As EventArgs) Handles B_ADD.Click

        Dim Mtitlecode As String = Strings.Trim(T_TitleCode.Text)
        Dim Mtitle As String = Strings.Trim(T_Title.Text)

        ' 第一段 ************************************************************************************
        ' 檢查『職稱代號』、『職稱』是否已輸入，此  2 項不得空白
        If Strings.Len(Mtitlecode) <> 3 Then
            MsgBox("『職稱代號』未輸入或不正確！" + Chr(13) + Chr(13) + "固定長度 4 Byte", 0 + 16, "Error")
            Exit Sub
        End If
        If Strings.Len(Mtitle) = 0 Then
            MsgBox("『職稱』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第二段 ************************************************************************************
        ' 檢查『職稱代號』是否已存在，可使用 Find 方法 或 RowFilter 屬性（如下）
        ' 檢查 DataTable 即可（載入本表單時，已將全部資料存入 Table01）

        ' 使用 Find 方法，尋找欄須經排序
        'Dim O_DV As DataView = New DataView(ODataSet_1.Tables("Table01"))
        'O_DV.Sort = "titlecode ASC"
        'Dim Mcheck As Int32 = O_DV.Find(Mtitlecode)
        'If Mcheck <> -1 Then
        'MsgBox("Sorry, 『職稱代號』已存在，不能新增相同的代號！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
        'Exit Sub
        'End If

        ' DataView 檢視表的 RowFilter 屬性篩選出 User 所輸入的部門代號，若有，則表示重複了
        ' 比較值 T_TitleCode.Text 的前後要加單引號
        Dim O_DV As DataView = New DataView(ODataSet_1.Tables("Table01"))
        O_DV.RowFilter = "titlecode='" + Mtitlecode + "'"
        If O_DV.Count >= 1 Then
            MsgBox("Sorry, 『職稱代號』已存在，不能新增相同的代號！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第三段 ************************************************************************************
        ' 新資料存入 SQL Server
        ' 使用 SqlCommand 更新 SQL Server 資料庫
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Insert into TAB_TITLE(titlecode,title) values(@t1,@t2)"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 用 SQLCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
        ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
        ' Clear 方法可清除 Parameters
        Ocmd_1.Parameters.Clear()
        Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = Mtitlecode
        Ocmd_1.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = Mtitle
        'Ocmd_1.Parameters.AddWithValue("@t1", Mtitlecode)
        'Ocmd_1.Parameters.AddWithValue("@t2", Mtitle)

        ' 執行非查詢指令，將資料存入 SQL Server
        Dim MAffectedNO As Integer = Ocmd_1.ExecuteNonQuery()
        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()

        ' 第四段 ************************************************************************************
        ' 將新增資料插入資料表 Table01，以便新增下一筆資料時可作為檢查之用（不重新自 SQL Server 抓資料，以節省時間），
        ' DataGridView 亦可呈現最新狀況
        ' 使用資料表的 Rows.Add 方法新增資料列，括號內新資料列的名稱，
        ' 資料列的 Item 屬性可設定資料列中某一行的資料，
        ' 隨後使用資料表的 AcceptChanges 方法認可此項變動
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table01").NewRow()
        O_NewRow.Item(0) = Mtitlecode
        O_NewRow.Item(1) = Mtitle
        ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
        ODataSet_1.Tables("Table01").AcceptChanges()

        ' 更新資料網格
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 移動游標至最後一筆
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MTotalRecordNo - 1)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As SqlInt32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

        MsgBox("資料已新增！", 0 + 64, "OK")

    End Sub

    ' 離開本表單
    ' 釋放資源，以便重新呼叫本表單時，重新執行 Load 事件中的程序
    Private Sub B_Close_Click_1(sender As Object, e As EventArgs) Handles B_Close.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Ocn_1.Close()
            Ocn_1.Dispose()
            Me.Dispose()
            F_menu.Show()
        Else
            Return
        End If
    End Sub

    ' 修改資料
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click

        Dim Mtitlecode As String = Strings.Trim(T_TitleCode.Text)
        Dim Mtitle As String = Strings.Trim(T_Title.Text)

        ' 第一段 ************************************************************************************
        ' 檢查『職稱代號』、『職稱』是否已輸入，此  2 項不得空白
        If Strings.Len(Mtitlecode) <> 3 Then
            MsgBox("『職稱代號』未輸入或不正確！" + Chr(13) + Chr(13) + "固定長度 4 Byte", 0 + 16, "Error")
            Exit Sub
        End If
        If Strings.Len(Mtitle) = 0 Then
            MsgBox("『職稱名稱』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第二段 ************************************************************************************
        ' 檢查『部門代號』是否存在，此處應使用 Find 方法，
        ' 因為找到時可傳回其資料列的索引（亦即列號，由0起算），供後續程式使用
        ' 使用 Find 方法，尋找欄須經排序
        Dim O_DV As DataView = New DataView(ODataSet_1.Tables("Table01"))
        O_DV.Sort = "titlecode ASC"
        Dim Mcheck As Int32 = O_DV.Find(Mtitlecode)
        If Mcheck = -1 Then
            MsgBox("Sorry, 『職稱代號』』不存在，不能修改！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第三段 ************************************************************************************
        ' 使用 SqlCommand 更新 SQL Server 資料庫
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Update TAB_TITLE Set title=@t1 Where titlecode='" + Mtitlecode + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 用 SQLCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
        ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
        ' Clear 方法可清除 Parameters
        Ocmd_1.Parameters.Clear()
        Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = Mtitle
        'Ocmd_1.Parameters.AddWithValue("@t1", Mtitle)

        ' 執行非查詢指令，將資料存入 SQL Server
        Dim MAffectedNO As Integer = Ocmd_1.ExecuteNonQuery()
        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()

        ' 第四段 ************************************************************************************
        ' 更新資料表 Table01 及 DataGridView
        ' 資料表的 Rows屬性後接行列索引（前者為列，前者為行，需用括號括住，均由0起算），可傳回或設定特定格位的資料
        ODataSet_1.Tables("Table01").Rows(Mcheck)(1) = Mtitle
        ODataSet_1.Tables("Table01").AcceptChanges()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        MsgBox("資料已修改！", 0 + 64, "OK")
    End Sub

    ' 刪除
    Private Sub B_Delete_Click(sender As Object, e As EventArgs) Handles B_Delete.Click

        Dim Mtitlecode As String = Strings.Trim(T_TitleCode.Text)

        ' 第一段 ************************************************************************************
        ' 檢查『職稱代號』是否已輸入，此 項不得空白
        If Strings.Len(Mtitlecode) <> 3 Then
            MsgBox("『職稱代號』未輸入或不正確！" + Chr(13) + Chr(13) + "固定長度 3 Byte", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第二段 ************************************************************************************
        ' 檢查『職稱代號』是否存在，此處應使用 Find 方法，
        ' 因為找到時可傳回其資料列的索引（亦即列號，由0起算），供後續程式使用
        ' 使用 Find 方法，尋找欄須經排序
        Dim O_DV As DataView = New DataView(ODataSet_1.Tables("Table01"))
        O_DV.Sort = "titlecode ASC"
        Dim Mcheck As Int32 = O_DV.Find(Mtitlecode)
        If Mcheck = -1 Then
            MsgBox("Sorry, 『職稱代號』』不存在，不能刪除！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第三段 ************************************************************************************
        ' 使用 SqlCommand 更新 SQL Server 資料庫
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Delete From TAB_TITLE Where titlecode='" + Mtitlecode + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 執行非查詢指令，將資料存入 SQL Server
        Dim MAffectedNO As Integer = Ocmd_1.ExecuteNonQuery()
        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()

        ' 第四段 ************************************************************************************
        ' 刪除資料表 Table01 及 更新 DataGridView
        ' 資料表的 Rows屬性後接行列索引（前者為列，前者為行，需用括號括住，均由0起算），可傳回或設定特定格位的資料
        ' 使用 Delete 方法刪除資料表中的資料
        ' 務必使用 AcceptChanges 方法，認可對資料表所做的變更，否則後續計算資料總筆數時會發生錯誤
        ODataSet_1.Tables("Table01").Rows(Mcheck).Delete()
        ODataSet_1.Tables("Table01").AcceptChanges()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 移動游標至第一筆
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            Dim O_DataRow As DataGridViewRow = DataGridView1.Rows(0)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        Dim Mrowno As SqlInt32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

        MsgBox("資料已刪除！", 0 + 64, "OK")

    End Sub

    ' 匯出為 Excel 檔
    Private Sub B_Export_Click(sender As Object, e As EventArgs) Handles B_Export.Click
        ' 匯出對照表（使用 ADO 將 DataGridView 的資料匯出為 Excel 檔）
        ' 先使用 CreateDirectory 方法建立資料夾 D:\TestQuery，以便儲存匯出的 Excel 檔
        ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 若檔案 D:\TestQuery\Table_Dept.xls 已存在，則刪除之，以便本程序可重複使用
        If System.IO.File.Exists("D:\TestQuery\Table_Title.xls") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TestQuery\Table_Title.xls")
        End If

        ' 設定連接管道
        Dim MFN_0 As String = "D:\TestQuery\Table_Title.xls"
        Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
        Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
        Oconn_0.Open()

        ' 插入欄名
        Dim Msqlstr_0 As String = "Create Table Sheet1 ([職稱代號] Text(3), [職稱] Text(14))"
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
            Msqlstr_1 = "Insert Into [" + MSheetName + "] Values(@t1,@t2)"
            Ocmd_1.Parameters.Clear()
            Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(0).Value
            Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = DataGridView1.Rows(Mcou).Cells(1).Value
            Ocmd_1.CommandText = Msqlstr_1
            Ocmd_1.ExecuteNonQuery()
        Next

        ' 關閉相關物件及釋放資源
        Ocmd_0.Dispose()
        Ocmd_1.Dispose()
        Oconn_0.Close()
        MsgBox("資料已匯出至 D:\TestQuery\Table_Title.xls！", 0 + 64, "OK")
    End Sub

    ' 從 Excel 檔匯入
    Private Sub B_Import_Click(sender As Object, e As EventArgs) Handles B_Import.Click
        ' 顯示 F_TableImport 表單，讓 User 選取檔案及工作表，
        ' 此處需使用 ShowDialog 將 F_TableImport 表單設為強制回應對話方塊，以便不執行其後的程式碼，直到對話方塊關閉
        ' 先將本表單反致能，以防 User 誤敲
        ' 本系統共有三張表單呼叫 檔案選取表單  F_TableImport，但因使用 ShowDialog 呼叫，
        ' 故當 User 結束 對話方塊時，會回到原呼叫表單的呼叫處，繼續下一行的指令，不會搞錯，故無需傳遞參數來識別
        'Me.Visible = False
        Me.Enabled = False
        F_TableImport.ShowDialog()

        ' 計算副檔名的長度，並存入變數 MLenExt
        ' 以長度來區分 Excel 種類，以便決定適當的 Provider
        ' 若 User 在 F_TableImport 表單敲放棄，則離開本程序
        Dim MCheckString As String = F_TableImport.ASendList(0)
        If MCheckString = "" Then
            'Me.Visible = True
            Me.Enabled = True
            Me.TopMost = True
            Exit Sub
        End If
        Dim MTotallen As Integer = Strings.Len(MCheckString)
        Dim MLenExt As Integer = MTotallen - Strings.InStrRev(MCheckString, ".") + 1

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
        ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
        ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
        Dim MFN_1 As String = F_TableImport.ASendList(0)
        Dim Mstrconn_2 As String = ""
        If MLenExt >= 5 Then
            Mstrconn_2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';"
        Else
            Mstrconn_2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';"
        End If

        ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 顯示等待訊息 ***********************************************************************************
        F_wait.Show()

        ' 設定 SQL 字串，供資料轉接器使用
        Dim Msqlstr_2 As String = "Select * From [" + F_TableImport.ASendList(1) + "]"

        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_2），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_2 As New OleDbCommand(Msqlstr_2, Oconn_2)

        ' 使用 OleDbCommand 的 ExecuteReader 方法將讀出的資料存入 OleDbDataReader 資料讀取器
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_2 As OleDbDataReader
        Odataread_2 = Ocmd_2.ExecuteReader()

        '  將資料讀取器的資料存入 Table01並顯示於 DataGridView
        ' 不要使用 DataAdapter 的 Fill方法將匯入的資料填入 ODataSet_1.Table01，會使檔案結構不同
        ' 清除資料表 ODataSet_1.Tables("Table01") 的資料
        Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
        Next
        ODataSet_1.Tables("Table01").AcceptChanges()

        ' 將資料讀取器的資料存入 Table01
        ' 因為 User 可能匯錯資料，故使用 On Error Resume Next 陳述式，以防止程式中斷
        On Error Resume Next
        Dim MRowNo As Int32 = 0
        Do While Odataread_2.Read() = True
            Dim O_NewRow As DataRow
            O_NewRow = ODataSet_1.Tables("Table01").NewRow()
            O_NewRow.Item(0) = Odataread_2.Item(0)
            O_NewRow.Item(1) = Odataread_2.Item(1)
            ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
            ODataSet_1.Tables("Table01").AcceptChanges()
            MRowNo += 1
        Loop

        ' 將資料集之資料表的資料顯示於 DataGridView 資料網格控制項
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Oconn_2.Close()
        Oconn_2.Dispose()
        Odataread_2.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "職稱代號"
            .Columns(1).HeaderText = "職稱"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        F_wait.Hide()
        'Me.Visible = True
        Me.Enabled = True
        Me.TopMost = False
        ' 匯入資料後尚待 User 確認，此時並未更新 SQL Server 中的資料，若 User 執行增刪修，會發生錯誤，
        ' 例如新增資料在 DataGridView 中部存在，但在 SQL Server 中已存在，就會發生錯誤，故此時應隱藏增刪修按鈕，直到 User 按下『更新』鈕為止
        B_ADD.Visible = False
        B_Modify.Visible = False
        B_Delete.Visible = False
        MsgBox("資料已匯入，確認無誤後，請敲『更新』鈕。" + Chr(13) + Chr(13) + "若有錯誤，請重新匯入，或離開本頁，", 0 + 64, "OK")
        B_UpdateSQL.Visible = True
        Me.TopMost = True

    End Sub

    ' 更新 SQL Server（先刪除全部資料，再插入）
    Private Sub B_UpdateSQL_Click(sender As Object, e As EventArgs) Handles B_UpdateSQL.Click

        ' 先使用 SqlCommand 刪除 SQL Server 資料庫
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Delete From TAB_TITLE"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 執行非查詢指令，將資料存入 SQL Server
        Dim MAffectedNO As Integer = Ocmd_1.ExecuteNonQuery()
        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()

        ' 將資料表全部資料插入 SQL Server 資料庫
        ' 宣告變數儲存 SQL 指令
        Msqlstr_1 = "Insert into TAB_TITLE(titlecode,title) values(@t1,@t2)"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Ocmd_1 = New SqlCommand(Msqlstr_1, Ocn_1)

        ' 用 SQLCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
        ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
        ' Clear 方法可清除 Parameters
        ' 若 User 匯錯資料時，仍按下『更新』鈕，可能會發生錯誤（例如部門代號重複了），故加入 Try 陳述式，以處理例外狀況
        Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mrow = 0 To Mstop Step 1
            Ocmd_1.Parameters.Clear()
            Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = ODataSet_1.Tables("Table01").Rows(Mrow)(0)
            Ocmd_1.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = ODataSet_1.Tables("Table01").Rows(Mrow)(1)
            Try
                Ocmd_1.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString, 0 + 16, "Error")
                Exit Sub
            End Try
        Next
        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()

        B_UpdateSQL.Visible = False
        B_ADD.Visible = True
        B_Modify.Visible = True
        B_Delete.Visible = True
        MsgBox("資料已更新！", 0 + 64, "OK")

    End Sub

End Class