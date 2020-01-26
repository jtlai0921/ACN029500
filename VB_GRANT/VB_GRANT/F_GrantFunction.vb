Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class F_GrantFunction
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' 宣告公用變數以便儲存匯入檔的資料比數
    Public MTotalRecordNo As Int32

    '----------------------------------------------------------------------------------------------------------------------------------------------------

    ' 載入本表單時，
    ' 1. 將帳號資料從 SQL Server 讀出，作為下拉式選單的選項 
    ' 2. 將授權清單自 SQL Server 讀出，並顯示於 DataGridView，供系統管理員挑選
    Private Sub F_GrantFunction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 第一段，將帳號資料從 SQL Server 讀出，作為下拉式選單的選項 -------------------------------------------------------------------------
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_0 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_0 As New SqlConnection(Mcnstr_0)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_0.Open()

        '  ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_0 As String = "Select eno,ename,deptcode From TABPASSW Order by deptcode ASC,eno ASC"
        Dim ODataAdapter_0 As New SqlDataAdapter(Msqlstr_0, Ocn_0)

        ' 建立資料表
        Dim O_Table00 As New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
        ODataAdapter_0.Fill(O_Table00)

        ' 將 DataTable 的資料併入下拉式選單（C_ID 帳號 及 C_Refer 比照對象 兩個選單）
        C_ID.Items.Clear()
        C_Refer.Items.Clear()
        Dim MTotalItems As Integer = O_Table00.Rows.Count - 1
        For Mcou = 0 To MTotalItems Step 1
            C_ID.Items.Add(O_Table00.Rows(Mcou)(0) + " " + O_Table00.Rows(Mcou)(1) + " " + O_Table00.Rows(Mcou)(2))
            C_Refer.Items.Add(O_Table00.Rows(Mcou)(0) + " " + O_Table00.Rows(Mcou)(1) + " " + O_Table00.Rows(Mcou)(2))
        Next

        ' 關閉 存取資料庫的相關物件
        Ocn_0.Close()
        Ocn_0.Dispose()

        '  第二段，將授權清單自 SQL Server 讀出，並顯示於 DataGridView，供系統管理員挑選 -------------------------------------------------------------------------
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_1 As String = "Select * From TABFLIST"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 建立資料表
        Dim O_Table01 As New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
        ODataAdapter_1.Fill(O_Table01)

        ' 指定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_Table01
        ' 將資料筆數存入變數 MTotalRecordNo，供後續程序使用
        MTotalRecordNo = O_Table01.Rows.Count

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "功能代碼"
            .Columns(1).HeaderText = "功能名稱"
            .Columns(2).HeaderText = "可授權數"
        End With
        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 36

        ' 格式化
        With DataGridView1
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Format = "#,0"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 36
        Next mtprow

        ' 在資料網格控制項中增加核取清單方塊欄 ，供 User 敲選
        ' 其方法是先根據  DataGridViewCheckBoxColumn 類別建立新物件（核取清單方塊欄），本例取名 O_ChkBox，
        ' 然後再使用 DataGridView 的 Columns.Insert 方法將新增欄位加入資料網格控制項，括號內兩個參數，前者為行號，後者為新增的欄位物件，
        ' 新增欄位的特徵可用下列屬性設定：
        ' FlatStyle 核取方塊儲存格的平面樣式外觀
        ' HeaderText 欄位標題
        ' Name 欄位名稱
        '.ValueType 資料型別
        '.FalseValue 未核取之值
        '.TrueValue 已核取之值
        ' 後續判斷核取清單方塊欄是否已核取的程式必須與此處的設定一致，若ValueType 設為布林值，則後續 Value 亦需為布林值
        ' 欄位唯讀與否之設定，需將 DataGridView 設為非唯讀，再將需要唯讀的欄位之 ReadOnly 屬性設為 True，
        ' 不能將 DataGridView 設為唯讀，再將需要非唯讀的欄位之 ReadOnly 屬性設為 False，
        ' 下例先將 DataGridView 設為非唯讀，再使用 For 迴圈將第一欄之外的欄位都設為唯讀，
        ' 此動作只作用於 資料網格控制項 而非其資料來源（與其 DataSource 屬性所指定的資料表無關）
        Dim O_ChkBox As New DataGridViewCheckBoxColumn
        With O_ChkBox
            .FlatStyle = FlatStyle.Standard
            .HeaderText = "請敲選"
            .Name = "Grant_chk"
            .ThreeState = False
            '.ValueType = GetType(Boolean)
            '.FalseValue = False
            '.TrueValue = True
            .ValueType = GetType(String)
            .FalseValue = "No"
            .TrueValue = "Yes"
        End With
        DataGridView1.Columns.Insert(0, O_ChkBox)

        Dim MStop As Int32 = DataGridView1.Columns.Count - 1
        DataGridView1.ReadOnly = False
        For Mcou = 1 To MStop Step 1
            DataGridView1.Columns(Mcou).ReadOnly = True
        Next

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 方法，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If

    End Sub

    ' 核取清單方塊欄全部勾選
    Private Sub B_SelectALL_Click(sender As Object, e As EventArgs) Handles B_SelectAll.Click
        Dim O_row As DataGridViewRow
        Dim O_check As DataGridViewCheckBoxCell
        Dim Adelete(MTotalRecordNo) As Integer
        For Each O_row In DataGridView1.Rows
            O_check = O_row.Cells("Grant_chk")
            'O_check.Value = True
            O_check.Value = "Yes"
        Next
        T_GrantNo.Text = MTotalRecordNo
    End Sub

    ' 核取清單方塊欄全部取消勾選
    Private Sub B_SelectNone_Click(sender As Object, e As EventArgs) Handles B_SelectNone.Click
        Dim O_row As DataGridViewRow
        Dim O_check As DataGridViewCheckBoxCell
        Dim Adelete(MTotalRecordNo) As Integer
        Dim MDeleteNo As Integer = 0
        For Each O_row In DataGridView1.Rows
            O_check = O_row.Cells("Grant_chk")
            'O_check.Value = False
            O_check.Value = "No"
        Next
        T_GrantNo.Text = 0
    End Sub

    ' 離開帳號選取欄時，檢查 User 輸入值是否為下拉式選單的內容
    ' 當 User 自行輸入帳號，而非使用下拉式選單敲選帳號時，使用本程序來檢查 User 所輸入之值是否為下拉式選單的內容
    ' 若不是下拉式選單的內容，應顯示警告訊息，
    ' 若為下拉式選單的內容之一，則呼叫副程序，以便更新 DataGridView 之勾選狀態
    Private Sub C_ID_Validated(sender As Object, e As EventArgs) Handles C_ID.Validated

        ' 將帳號資料存入變數（5 byte）
        Dim MchkID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))

        ' 使用 ComboBox 的 FindString 方法檢查 User 輸入值是否為下拉式選單的內容之一，
        ' 若找到會傳回索引編號（由0起算，若找不到，則傳回 -1
        If C_ID.FindString(MchkID) = -1 Then
            MsgBox("所輸入的帳號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正。", 0 + 16, "Error")
            C_ID.Focus()
        End If
        ' 呼叫副程序，以便更新 DataGridView 之勾選狀態，括號內傳遞之參數為 User 所輸入的帳號
        Call SubGrantList(MchkID)

    End Sub

    ' 帳號選取變動事件
    ' 選取不同帳號時，根據該帳號的授權資料更新 DaraGridView 之勾選狀態
    Private Sub C_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles C_ID.SelectedIndexChanged

        ' 隱藏右上角的錯誤清單（授權數超過標準者顯示右上角的資料網格控制項）
        DataGridView2.Visible = False
        L_ErrList.Visible = False

        ' 帳號為選單內容的左邊 5 位（一律轉為大寫）
        Dim MchkID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 查看，否則整個字串呈現選取狀態
        SendKeys.Send("{End}")

        ' 呼叫副程序，以便更新 DataGridView 之勾選狀態，括號內傳遞之參數為 User 所敲選的帳號
        Call SubGrantList(MchkID)

    End Sub

    ' 某帳號之授權狀態副程序
    Private Sub SubGrantList(ByVal EID As String)
        Dim MTPENO As String = EID

        ' 抓出某帳號之授權資料 *************************************************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_2 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_2 As New SqlConnection(Mcnstr_2)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_2.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_2 As String = "Select * From TABGRANT Where eno='" + MTPENO + "'"
        Dim ODataAdapter_2 As New SqlDataAdapter(Msqlstr_2, Ocn_2)

        ' 建立資料表
        Dim O_Table02 As New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資表
        ODataAdapter_2.Fill(O_Table02)

        ' 關閉 存取資料庫的相關物件
        Ocn_2.Close()
        Ocn_2.Dispose()

        ' 根據前述抓出資料（某帳號的授權資料）更新 DataGridView 之勾選狀態  *************************************************************************
        ' 將前述抓出資料（O_Table02）轉為資料檢視表，以利後續程式查找比對，查找比對欄 fcode 需經過排序
        Dim O_DV As DataView = New DataView(O_Table02)
        O_DV.Sort = "fcode ASC"
        ' 使用 For 迴圈逐一將第二欄的資料取出，然後以資料檢視表的 Find 方法查找，
        ' 若傳回 -1，表示未找到授權資料，故應取消DataGridView 之勾選狀態，反之，則應勾選
        Dim MGrantQty As Int32 = 0
        Dim Mfcode As String = ""
        For Mcou = 0 To MTotalRecordNo - 1 Step 1
            Mfcode = DataGridView1.Rows(Mcou).Cells(1).Value
            If O_DV.Find(Mfcode) = -1 Then
                DataGridView1.Rows(Mcou).Cells(0).Value = "No"
            Else
                DataGridView1.Rows(Mcou).Cells(0).Value = "Yes"
                MGrantQty += 1
            End If
        Next
        ' 顯示某帳號的授權數量
        T_GrantNo.Text = MGrantQty
    End Sub

    ' 根據勾選結果更新 SQL Server 的 TABGRANT 授權資料表
    Private Sub B_Update_Click(sender As Object, e As EventArgs) Handles B_Update.Click

        ' 帳號為選單內容的左邊 5 位（一律轉為大寫）
        Dim MTPENO As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        If Len(MTPENO) = 0 Then
            MsgBox("帳號尚未指定！" + Chr(13) + Chr(10) + "請指定", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        Dim MANS As Integer
        MANS = MsgBox("您確定要更新 " + MTPENO + " 的授權資料嗎？", 4 + 32 + 256, "Confirm")
        If MANS <> 6 Then
            Exit Sub
        End If

        ' 隱藏右上角的錯誤清單（授權數超過標準者顯示右上角的資料網格控制項）
        DataGridView2.Visible = False
        L_ErrList.Visible = False

        ' 第一段， 檢查授權數是否超限 ***************************************************************************

        ' 先抓出目前全部授權資料（User 指定的帳號要排除）
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_3 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_3 As New SqlConnection(Mcnstr_3)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_3.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_3 As String = "Select * From TABGRANT Where eno<>'" + MTPENO + "'"
        Dim ODataAdapter_3 As New SqlDataAdapter(Msqlstr_3, Ocn_3)

        ' 建立資料表
        Dim O_Table03 As New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資表
        ODataAdapter_3.Fill(O_Table03)

        ' 關閉 存取資料庫的相關物件
        Ocn_3.Close()
        Ocn_3.Dispose()

        ' 建立資料表 O_TableERR，以便儲存授權數超過標準的資料
        ' fcode 功能代號、fname功能名稱、grantqty 標準授權數
        Dim O_TableERR As New DataTable

        ' 使用資料表的 Columns.Add 方法新增欄位，括號內新欄位
        Dim O_colA As New DataColumn
        O_colA.DataType = System.Type.GetType("System.String")
        With O_colA
            .Caption = "功能代碼"
            .ColumnName = "Fcode"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = True
        End With
        O_TableERR.Columns.Add(O_colA)

        Dim O_colB As New DataColumn
        O_colB.DataType = System.Type.GetType("System.String")
        With O_colB
            .Caption = "功能名稱"
            .ColumnName = "Fname"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TableERR.Columns.Add(O_colB)

        Dim O_colC As New DataColumn
        O_colC.DataType = System.Type.GetType("System.Int32")
        With O_colC
            .Caption = "可授權數量"
            .ColumnName = "GrantQty"
            .AllowDBNull = True
            .ReadOnly = False
        End With
        O_TableERR.Columns.Add(O_colC)

        ' 使用 For 迴圈逐一計算已勾選項目的總授權數（本身除外）
        Dim Mfcode As String = ""
        Dim Mfname As String = ""
        Dim Mqty As Integer = 0
        Dim MStandQty As Integer = 0
        For Mcou = 0 To MTotalRecordNo - 1 Step 1
            If DataGridView1.Rows(Mcou).Cells(0).Value = "Yes" Then
                Mfcode = DataGridView1.Rows(Mcou).Cells(1).Value
                Mfname = DataGridView1.Rows(Mcou).Cells(2).Value
                MStandQty = DataGridView1.Rows(Mcou).Cells(3).Value

                ' 若可授權數為 0 ，表示該功能可無限授權（授權數量沒有限制），故無需判斷是否超限，可直接執行下一迴圈
                If MStandQty = 0 Then Continue For

                ' DataTable 的 Compute 方法可算出某一項目的筆數
                ' Compute 括號內有兩個參數，第一個為運算式，第二個為篩選條件，不能省略，參數之間以逗號分隔，且前後要加雙引號。
                Mqty = O_Table03.Compute("count(fcode)", "fcode='" + Mfcode + "'")

                ' 若授權數超過標準，則將相關資料存入資料表  O_TableERR，
                ' 先替  O_TableERR 新增資料列，
                ' 資料列的 Item 屬性可設定資料列中某一行的資料，
                ' 先使用資料表的 Rows.Add 方法新增資料列，括號內新資料列的名稱，
                ' 隨後使用資料表的 AcceptChanges 方法認可此項變動
                If Mqty + 1 > MStandQty Then
                    Dim O_NewRow As DataRow
                    O_NewRow = O_TableERR.NewRow()
                    O_NewRow.Item(0) = Mfcode
                    O_NewRow.Item(1) = Mfname
                    O_NewRow.Item(2) = MStandQty
                    O_TableERR.Rows.Add(O_NewRow)
                    O_TableERR.AcceptChanges()
                End If
            End If
        Next

        ' 將授權數超過標準的項目顯示於第二個 DataGridView
        If O_TableERR.Rows.Count > 0 Then
            ' 將 O_TableERR 資料表指定給 DataGridView2 的資料來源屬性
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = O_TableERR

            ' 加入中文欄名
            With DataGridView2
                .Columns(0).HeaderText = "功能代碼"
                .Columns(1).HeaderText = "功能名稱"
                .Columns(2).HeaderText = "可授權數"
            End With
            ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
            DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            DataGridView2.ColumnHeadersHeight = 36
            ' 格式化
            With DataGridView2
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).DefaultCellStyle.Format = "#,0"
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            ' 不允許資料網格檢視控制項增列最後一筆
            DataGridView2.AllowUserToAddRows = False

            ' 將 DataGridView2 改為可見
            DataGridView2.Visible = True
            L_ErrList.Visible = True

            ' 逐一調整列高，AutoSizeRowsMode 需設為 None
            DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Dim mtprow2 As Object
            For Each mtprow2 In DataGridView2.Rows
                mtprow2.Height = 30
            Next mtprow2

            MsgBox("授權數量超過標準了（請見右上角）！" + Chr(13) + Chr(10) + "請重新勾選，再敲『更 新』鈕。", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第二段， 更新 SQL Server 中的授權資料 ***************************************************************************
        ' 第二段之一，先刪除 Server 中同一帳號的資料 ******************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_5 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_5 As New SqlConnection(Mcnstr_5)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_5.Open()

        ' 宣告 SQL 指令
        Dim Msqlstr_5 As String = "Delete From TABGRANT Where eno=" + "'" + MTPENO + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內為  SQL 指令 與 連結物件
        Dim Ocmd_5 As New SqlCommand(Msqlstr_5, Ocn_5)

        ' 執行非查詢指令，將資料存入 SQL Server
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，若為 0 ，則表示未刪除任何資料
        Dim MdeleteResult5 As Integer = Ocmd_5.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocn_5.Close()
        Ocn_5.Dispose()

        ' 第二段之二，將已勾選資料插入 SQL Server 中的 TABGRANT 資料表 ******************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_6 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_6 As New SqlConnection(Mcnstr_6)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_6.Open()

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_6 As String = "Insert into TABGRANT(eno,fcode,fname) values(@t1,@t2,@t3)"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_6），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_6 As New SqlCommand(Msqlstr_6, Ocn_6)

        ' 使用 For 迴圈逐一處理 DataGridView1 之中的已勾選資料
        Dim Mstop As Int32 = DataGridView1.Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            If DataGridView1.Rows(Mcou).Cells(0).Value = "Yes" Then
                Mfcode = DataGridView1.Rows(Mcou).Cells(1).Value
                Mfname = DataGridView1.Rows(Mcou).Cells(2).Value
                ' 用 SQLCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
                ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
                ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
                ' Clear 方法可清除 Parameters
                Ocmd_6.Parameters.Clear()
                Ocmd_6.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = MTPENO
                Ocmd_6.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = Mfcode
                Ocmd_6.Parameters.AddWithValue("@t3", SqlDbType.NVarChar).Value = Mfname
                'Ocmd_6.Parameters.AddWithValue("@t1", MTPENO)
                'Ocmd_6.Parameters.AddWithValue("@t2", Mfcode)
                'Ocmd_6.Parameters.AddWithValue("@t3", Mfname)
                ' 執行非查詢指令，將資料存入 SQL Server
                Ocmd_6.ExecuteNonQuery()
            End If
        Next

        ' 關閉 存取資料庫的相關物件
        Ocn_6.Close()
        Ocn_6.Dispose()
        MsgBox(MTPENO + " 的授權資料已更新！", 0 + 64, "OK")

    End Sub

    ' 顯示比照選單及按鈕
    Private Sub B_Follow_Click(sender As Object, e As EventArgs) Handles B_Follow.Click
        Dim MTPENO As String = Strings.UCase(C_ID.Text)
        If Len(MTPENO) = 0 Then
            MsgBox("帳號尚未指定！" + Chr(13) + Chr(10) + "請指定", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If

        ' 隱藏右上角的錯誤清單（授權數超過標準者顯示右上角的資料網格控制項）
        DataGridView2.Visible = False
        L_ErrList.Visible = False

        ' 其他控制項反致能（不能使用）
        DataGridView1.Enabled = False
        C_ID.Enabled = False
        B_Follow.Enabled = False
        B_Update.Enabled = False
        B_SelectAll.Enabled = False
        B_SelectNone.Enabled = False

        MsgBox("請在螢幕右方選取『比照對象』，再敲『確定』鈕！", 0 + 64, "Attention")
        L_Refer.Visible = True
        C_Refer.Visible = True
        B_Refer.Visible = True
        B_GiveUp.Visible = True
        Panel1.Visible = True
    End Sub

    ' 處理比照者的資料，據以更新 DataGridView 之勾選狀態
    Private Sub B_Refer_Click(sender As Object, e As EventArgs) Handles B_Refer.Click
        Dim MRefer As String = Strings.UCase(Strings.Left(C_Refer.Text, 5))

        ' 抓出該比照者的現有授權功能
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_7 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_7 As New SqlConnection(Mcnstr_7)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_7.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_7 As String = "Select * From TABGRANT Where eno='" + MRefer + "'"
        Dim ODataAdapter_7 As New SqlDataAdapter(Msqlstr_7, Ocn_7)

        ' 建立資料表
        Dim O_Table07 As New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資表
        ODataAdapter_7.Fill(O_Table07)

        ' 關閉 存取資料庫的相關物件
        Ocn_7.Close()
        Ocn_7.Dispose()

        ' 先檢查 User 所輸入的帳號是否存在
        If O_Table07.Rows.Count = 0 Then
            MsgBox("Sorry, 帳號不存在或該帳號沒有授權資料！" + Chr(13) + Chr(13) + "請重新輸入或挑選。", 0 + 16, "Error")
            C_Refer.Focus()
            Exit Sub
        End If

        ' 根據前述抓出資料（比照者的授權資料）更新 DataGridView 之勾選狀態 
        ' 將前述抓出資料（O_Table07）轉為資料檢視表，以利後續程式查找比對，查找比對欄 fcode 需經過排序
        Dim O_DV As DataView = New DataView(O_Table07)
        O_DV.Sort = "fcode ASC"
        ' 使用 For 迴圈逐一將第二欄的資料取出，然後以資料檢視表的 Find 方法查找，
        ' 若傳回 -1，表示未找到授權資料，故應取消DataGridView 之勾選狀態，反之，則應勾選
        Dim MGrantQty As Int32 = 0
        Dim Mfcode As String = ""
        For Mcou = 0 To MTotalRecordNo - 1 Step 1
            Mfcode = DataGridView1.Rows(Mcou).Cells(1).Value
            If O_DV.Find(Mfcode) = -1 Then
                DataGridView1.Rows(Mcou).Cells(0).Value = "No"
            Else
                DataGridView1.Rows(Mcou).Cells(0).Value = "Yes"
                MGrantQty += 1
            End If
        Next
        ' 顯示比照者的授權數量
        T_GrantNo.Text = MGrantQty

        ' 其他控制項制能（恢復可用）
        DataGridView1.Enabled = True
        C_ID.Enabled = True
        B_Follow.Enabled = True
        B_Update.Enabled = True
        B_SelectAll.Enabled = True
        B_SelectNone.Enabled = True

        ' 隱藏比照選單等物件
        L_Refer.Visible = False
        C_Refer.Visible = False
        B_Refer.Visible = False
        Panel1.Visible = False
        MsgBox("比照對象的授權資料已顯示於左上角的資料網格控制項！" + Chr(13) + Chr(13) + "確認後，請敲『更 新』鈕。", 0 + 64, "OK")

    End Sub

    ' 結束
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

    ' 放棄比照
    Private Sub B_GiveUp_Click(sender As Object, e As EventArgs) Handles B_GiveUp.Click
        ' 其他控制項致能（恢復可用）
        DataGridView1.Enabled = True
        C_ID.Enabled = True
        B_Follow.Enabled = True
        B_Update.Enabled = True
        B_SelectAll.Enabled = True
        B_SelectNone.Enabled = True

        ' 隱藏比照選單等物件
        L_Refer.Visible = False
        C_Refer.Visible = False
        B_Refer.Visible = False
        B_GiveUp.Visible = False
        Panel1.Visible = False
    End Sub
End Class