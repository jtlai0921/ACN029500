Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System
Imports System.Web.UI

Public Class F_QueryAdvanceResult
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0
    ' 宣告公用變數以便儲存 SQL 指令
    Public Msqlstr_1 As String = ""
    ' 宣告資料表 O_TableTotal，以便儲存個年資層的資料（載入及匯出程序中都會使用，故以 Public 宣告）
    Public O_TableTotal As New DataTable



    ' 抓出合於條件的資料，並顯示於 DataGridView
    '相關程式寫於本表單 Load 載入時，但繼續指定查詢條件時，需使用 Dispose 釋放本表單，以便再次以 Show 呼叫本表單時，仍會 Load 本表單而再度執行本程式
    Private Sub F_QueryAdvanceResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 接收 F_QueryAdvance.vb 傳遞過來的 SQL 指令
        Msqlstr_1 = F_QueryAdvanced.Tag

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

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 增加兩欄（LevelCode 年資層代碼、LevelDescription 年資層說明）
        Dim O_col01 As New DataColumn
        O_col01.DataType = System.Type.GetType("System.String")
        With O_col01
            .Caption = "LevelCode"
            .ColumnName = "LevelCode"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        ODataSet_1.Tables("Table01").Columns.Add(O_col01)

        Dim O_col02 As New DataColumn
        O_col02.DataType = System.Type.GetType("System.String")
        With O_col02
            .Caption = "LevelDescription"
            .ColumnName = "LevelDescription"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        ODataSet_1.Tables("Table01").Columns.Add(O_col02)

        ' 使用雙迴圈逐筆判斷 Table01 每一員工的年資層，
        ' 外迴圈逐一取出每一員工的年資（變數 Mseniority），
        ' 內迴圈將前述的年資逐一比對 F_QueryAdvance.vb 傳遞過來的年資層，
        ' 陣列有 18 列 4 行，每一行之值存入下列變數，
        ' MlevA 起始年資、MlevB 終止年資、MlevNo 年資層代碼、Mlev 年資層說明，
        ' 若某一員工的年資大於某一層的『起始年資』且小於等於該層的『終止年資』，
        ' 則取出該層的『年資層代碼』及『年資層說明』，然後存入 Table01 資料表的新增欄位（LevelCode 年資層代碼、LevelDescription 年資層說明）
        ' 若年資不屬於陣列中任一年資層，則『年資層代碼』設為 Z、『年資層說明』設為『未分類』
        Dim MlevA As Integer = 0
        Dim MlevB As Integer = 0
        Dim MlevNo As String = "Z"
        Dim Mlev As String = "未分類"
        Dim Mstop = ODataSet_1.Tables("Table01").Rows.Count - 1
        Dim Mseniority As Double = 0
        For mrow = 0 To Mstop Step 1
            Mseniority = ODataSet_1.Tables("Table01").Rows(mrow)(9)
            MlevA = 0
            MlevB = 0
            MlevNo = "Z"
            Mlev = "未分類"
            For mcou = 0 To 17 Step 1
                If F_QueryAdvanced.Alevel(mcou, 2) = "" Then
                    Exit For
                End If
                MlevA = Convert.ToInt16(F_QueryAdvanced.Alevel(mcou, 2))
                MlevB = Convert.ToInt16(F_QueryAdvanced.Alevel(mcou, 3))
                If Mseniority > MlevA And Mseniority <= MlevB Then
                    MlevNo = F_QueryAdvanced.Alevel(mcou, 0)
                    Mlev = F_QueryAdvanced.Alevel(mcou, 1)
                    Exit For
                End If
            Next
            ODataSet_1.Tables("Table01").Rows(mrow)(15) = MlevNo
            ODataSet_1.Tables("Table01").Rows(mrow)(16) = Mlev
        Next
        ' 指定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 建立新的資料表，以便儲存各個年資層的合計資料
        ' 使用資料表的 Columns.Add 方法新增欄位，括號內新欄位
        Dim O_colA As New DataColumn
        O_colA.DataType = System.Type.GetType("System.String")
        With O_colA
            .Caption = "年資層代碼"
            .ColumnName = "LevelNo"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = True
        End With
        O_TableTotal.Columns.Add(O_colA)

        Dim O_colB As New DataColumn
        O_colB.DataType = System.Type.GetType("System.String")
        With O_colB
            .Caption = "年資層說明"
            .ColumnName = "LevelDescription"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TableTotal.Columns.Add(O_colB)

        Dim O_colC As New DataColumn
        O_colC.DataType = System.Type.GetType("System.Int32")
        With O_colC
            .Caption = "合計筆數"
            .ColumnName = "Qty"
            .AllowDBNull = True
            .ReadOnly = False
        End With
        O_TableTotal.Columns.Add(O_colC)

        Dim O_colD As New DataColumn
        O_colD.DataType = System.Type.GetType("System.Double")
        With O_colD
            .Caption = "合計薪津"
            .ColumnName = "Wages"
            .AllowDBNull = True
            .ReadOnly = False
        End With
        O_TableTotal.Columns.Add(O_colD)

        Dim O_colE As New DataColumn
        O_colE.DataType = System.Type.GetType("System.Double")
        With O_colE
            .Caption = "合計津貼"
            .ColumnName = "Allowance"
            .AllowDBNull = True
            .ReadOnly = False
        End With
        O_TableTotal.Columns.Add(O_colE)

        Dim O_colF As New DataColumn
        O_colF.DataType = System.Type.GetType("System.Double")
        With O_colF
            .Caption = "合計伙食費"
            .ColumnName = "Meal"
            .AllowDBNull = True
            .ReadOnly = False
        End With
        O_TableTotal.Columns.Add(O_colF)

        ' 求各年資層的小計
        ' 使用 DataTable 的 Compute 方法計算同一年資層的合計筆數、合計薪津、合計津貼、合計伙食費，
        ' 分別存入變數 Mtotqty、Mtotwages、Mtotallowance、Mtotmeal
        Dim O_TempTable As DataTable = ODataSet_1.Tables("Table01")
        Dim Mtotqty As Int32
        Dim Mtotwages As Double
        Dim Mtotallowance As Double
        Dim Mtotmeal As Double

        ' 產生 Compute 方法括號內所需的兩個參數，第一個參數為運算式，第二個參數為條件式，
        ' 若沒有相符合的條件，則計算結果會傳回 Null，故先將計算結果存入物件變數 MTempTotal，然後再判斷其結果是否為 Null，
        ' 最後才存入 Mtotqty、Mtotwages、Mtotallowance、Mtotmeal 等變數中
        Dim Mcode As String = ""
        Dim Mdescription As String = ""
        Dim MstrA1 As String = "count(Staff_no)"
        Dim MstrA2 As String = ""
        Dim MstrB1 As String = "Sum(wages)"
        Dim MstrC1 As String = "Sum(allowance)"
        Dim MstrD1 As String = "Sum(meal)"
        Dim MTempTotal As Object

        ' 逐一取出陣列 F_QueryAdvanced.Alevel 之年資層代碼，作為 Compute 方法的條件式參數
        ' 迴圈內每一圈都需根據年資層代碼重新產生第二個參數
        Dim Mstop_2 As Integer = F_QueryAdvanced.Acount(0) - 1
        For mcoub = 0 To Mstop_2 Step 1
            Mcode = F_QueryAdvanced.Alevel(mcoub, 0)
            Mdescription = F_QueryAdvanced.Alevel(mcoub, 1)
            MstrA2 = "LevelCode='" + Mcode + "'"
            Mtotqty = O_TempTable.Compute(MstrA1, MstrA2)
            MTempTotal = O_TempTable.Compute(MstrB1, MstrA2)
            If IsDBNull(MTempTotal) Then
                Mtotwages = 0
            Else
                Mtotwages = MTempTotal
            End If
            MTempTotal = O_TempTable.Compute(MstrC1, MstrA2)
            If IsDBNull(MTempTotal) Then
                Mtotallowance = 0
            Else
                Mtotallowance = MTempTotal
            End If
            MTempTotal = O_TempTable.Compute(MstrD1, MstrA2)
            If IsDBNull(MTempTotal) Then
                Mtotmeal = 0
            Else
                Mtotmeal = MTempTotal
            End If

            ' 新增資料列，以便將前述求算出來的年資層合計數存入資料表  O_TableTotal
            '' 使用資料表的 Rows.Add 方法新增資料列，括號內新資料列的名稱，
            ' 將前述求算出來的合計數存入資料列的某一欄，資料列的 Item 屬性可設定資料列中某一行的資料，
            ' 隨後使用資料表的 AcceptChanges 方法認可此項變動
            Dim O_NewRow As DataRow
            O_NewRow = O_TableTotal.NewRow()
            O_NewRow.Item(0) = Mcode
            O_NewRow.Item(1) = Mdescription
            O_NewRow.Item(2) = Mtotqty
            O_NewRow.Item(3) = Mtotwages
            O_NewRow.Item(4) = Mtotallowance
            O_NewRow.Item(5) = Mtotmeal
            O_TableTotal.Rows.Add(O_NewRow)
            O_TableTotal.AcceptChanges()
        Next

        ' 計算未分類年資層，代碼為 Z
        MstrA2 = "LevelCode='Z'"
        Mtotqty = O_TempTable.Compute(MstrA1, MstrA2)
        MTempTotal = O_TempTable.Compute(MstrB1, MstrA2)
        If IsDBNull(MTempTotal) Then
            Mtotwages = 0
        Else
            Mtotwages = MTempTotal
        End If
        MTempTotal = O_TempTable.Compute(MstrC1, MstrA2)
        If IsDBNull(MTempTotal) Then
            Mtotallowance = 0
        Else
            Mtotallowance = MTempTotal
        End If
        MTempTotal = O_TempTable.Compute(MstrD1, MstrA2)
        If IsDBNull(MTempTotal) Then
            Mtotmeal = 0
        Else
            Mtotmeal = MTempTotal
        End If

        ' 若有未分類的年資層，則新增資料列，以便將前述求算出來的 Z 類合計數存入資料表  O_TableTotal
        If Mtotqty > 0 Then
            Dim O_NewRow As DataRow
            O_NewRow = O_TableTotal.NewRow()
            O_NewRow.Item(0) = "Z"
            O_NewRow.Item(1) = "未分類"
            O_NewRow.Item(2) = Mtotqty
            O_NewRow.Item(3) = Mtotwages
            O_NewRow.Item(4) = Mtotallowance
            O_NewRow.Item(5) = Mtotmeal
            O_TableTotal.Rows.Add(O_NewRow)
            O_TableTotal.AcceptChanges()
        End If

        ' 計算個年資層的平均數 
        ' 先新增三個欄位，以便儲存平均數
        Dim O_colG As New DataColumn
        O_colG.DataType = System.Type.GetType("System.Double")
        With O_colG
            .Caption = "平均薪津"
            .ColumnName = "AvgWages"
            .AllowDBNull = True
            .ReadOnly = False
            '.Expression = "Wages/Qty"
        End With
        O_TableTotal.Columns.Add(O_colG)

        Dim O_colH As New DataColumn
        O_colH.DataType = System.Type.GetType("System.Double")
        With O_colH
            .Caption = "平均津貼"
            .ColumnName = "AvgAllowance"
            .AllowDBNull = True
            .ReadOnly = False
            '.Expression = "Allowance/Qty"
        End With
        O_TableTotal.Columns.Add(O_colH)

        Dim O_colI As New DataColumn
        O_colH.DataType = System.Type.GetType("System.Double")
        With O_colI
            .Caption = "平均伙食費"
            .ColumnName = "AvgMeal"
            .AllowDBNull = True
            .ReadOnly = False
            '.Expression = "Meal/Qty"
        End With
        O_TableTotal.Columns.Add(O_colI)

        ' 前述使用 Expression 屬性來設定運算式較無彈性，例如當分母為零時，會出現『 不是一個數字』的訊息，
        ' 故改用下列程式來計算平均數
        Dim Mstop_3 As Integer = O_TableTotal.Rows.Count - 1
        For Mcouc = 0 To Mstop_3 Step 1
            If O_TableTotal.Rows(Mcouc)(2) > 0 Then
                O_TableTotal.Rows(Mcouc)(6) = Math.Round(O_TableTotal.Rows(Mcouc)(3) / O_TableTotal.Rows(Mcouc)(2), 0)
                O_TableTotal.Rows(Mcouc)(7) = Math.Round(O_TableTotal.Rows(Mcouc)(4) / O_TableTotal.Rows(Mcouc)(2), 0)
                O_TableTotal.Rows(Mcouc)(8) = Math.Round(O_TableTotal.Rows(Mcouc)(5) / O_TableTotal.Rows(Mcouc)(2), 0)
            Else
                O_TableTotal.Rows(Mcouc)(6) = 0
                O_TableTotal.Rows(Mcouc)(7) = 0
                O_TableTotal.Rows(Mcouc)(8) = 0
            End If
        Next
        ' 指定 DataGridView2 的資料來源
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = O_TableTotal

        ' 關閉 存取資料庫的相關物件
        O_TempTable.Dispose()
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

        ' 為 DataGridView1 加入中文欄名，欄名因匯總方式而不同
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
            .Columns(15).HeaderText = "年資層代號"
            .Columns(16).HeaderText = "年資層"
        End With

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

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

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

        ' 為 DataGridView2 加入中文欄名，欄名因匯總方式而不同
        With DataGridView2
            .Columns(0).HeaderText = "年資層代號"
            .Columns(1).HeaderText = "年資層"
            .Columns(2).HeaderText = "人數"
            .Columns(3).HeaderText = "合計薪津"
            .Columns(4).HeaderText = "合計津貼"
            .Columns(5).HeaderText = "合計伙食費"
            .Columns(6).HeaderText = "平均薪津"
            .Columns(7).HeaderText = "平均津貼"
            .Columns(8).HeaderText = "平均伙食費"
        End With

        ' 金額等欄位格式化
        With DataGridView2
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Format = "#,0"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "#,0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "#,0"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.Format = "#,0"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).DefaultCellStyle.Format = "#,0"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).DefaultCellStyle.Format = "#,0"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        ' 結束等待訊息 ***********************************************************************************
        F_wait.Hide()

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

    ' 繼續指定查詢條件
    Private Sub B_Continue_Click(sender As Object, e As EventArgs) Handles B_Continue.Click
        'Me.Hide()
        Me.Dispose()
        F_QueryAdvanced.Show()
    End Sub

    ' 匯出資料
    Private Sub B_Export_Click(sender As Object, e As EventArgs) Handles B_Export.Click
        Me.Enabled = False
        F_Save01.Show()
    End Sub

    ' 致能變動事件
    ' 當 User 在表單 F_Save01 完成存檔類型及存檔名稱之設定後，系統會將本表單之 Enable 屬性設為 True，
    ' 故應在本表單的 EnabledChanged 致能變動事件中撰寫 接收存檔類型及存檔名稱 及 匯出檔案之程式
    Private Sub F_QueryAdvanceResult_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        ' 呼叫 F_Save01.vb 表單，讓 User 設定匯出檔之檔名及型別時，本表單之 Enable 屬性設為 False，
        ' 當 User 設定匯出檔之檔名及型別之後，本表單之 Enable 屬性設為 True，無論 設為 False 或 True 都會引發 EnabledChanged 事件，
        ' 故本程序需先檢查本表單之 Enable 狀況，若為 False，則立即離開本程序，
        ' 以免 EnabledChanged 事件之相關程式又再執行一次（每敲一次『匯出』鈕都會執行匯出程式、浪費時間並疑惑 User）
        If Me.Enabled = False Then
            Exit Sub
        End If

        ' 若 User 在 F_Save01.vb 表單中敲了『放棄』鈕，亦須即離開本程序（本表單之 Enable 屬性為 True）
        ' 變數 MFileKind 儲存 User 所設定之檔案型別
        Dim MFileKind As String = F_Save01.Asavefile(0)
        If MFileKind = "GiveUp" Then
            Exit Sub
        End If

        ' 變數 MSaveFileName 儲存 User 所設定匯出檔之檔名及路徑
        Dim MSaveFileName As String = F_Save01.Asavefile(1)

        ' 根據  User 所設定之檔案型別，執行不同的匯出程式
        Select Case MFileKind
            Case "xls"
                ' 本段匯出為 Excel檔
                ' 若相同資料夾內有相同檔案，則刪除之，以便本程序可重複使用
                If System.IO.File.Exists(MSaveFileName) = True Then
                    My.Computer.FileSystem.DeleteFile(MSaveFileName)
                End If

                ' 使用 OleDb 建立 Excel 檔
                Dim Mstrconn_2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MSaveFileName + ";Extended Properties='Excel 8.0;HDR=Yes';"
                Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
                Oconn_2.Open()

                Dim Msqlstr_0 As String = "Create Table Sheet1 ([年資層代碼] Text(1),[年資層說明] Text(6),[人數] Integer,[合計薪津] Double,[合計津貼] Double,[合計伙食費] Double,[平均薪津] Double,[平均津貼] Double,[平均伙食費] Double)"
                Dim Ocmd_2 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_2)
                Ocmd_2.ExecuteNonQuery()

                ' 使用 For 迴圈逐列將 O_TempTable 資料表的資料匯出至 Excel 檔
                ' Insert 指令中無需指定欄名，Values 之後接 @具名參數，以降低 SQL 指令的複雜度
                On Error Resume Next
                Dim Mstop As Integer = O_TableTotal.Rows.Count - 1
                Dim MLevelNo As String = ""
                Dim MLevelDescription As String = ""
                Dim Mqty As Int32 = 0
                Dim MWages As Double
                Dim MAllowance As Double
                Dim MMeal As Double
                Dim MAvgWages As Double
                Dim MAvgAllowance As Double
                Dim MAvgMeal As Double
                For Mcou = 0 To Mstop Step 1
                    MLevelNo = O_TableTotal.Rows(Mcou)(0)
                    MLevelDescription = O_TableTotal.Rows(Mcou)(1)
                    Mqty = O_TableTotal.Rows(Mcou)(2)
                    MWages = O_TableTotal.Rows(Mcou)(3)
                    MAllowance = O_TableTotal.Rows(Mcou)(4)
                    MMeal = O_TableTotal.Rows(Mcou)(5)
                    MAvgWages = O_TableTotal.Rows(Mcou)(6)
                    MAvgAllowance = O_TableTotal.Rows(Mcou)(7)
                    MAvgMeal = O_TableTotal.Rows(Mcou)(8)

                    Msqlstr_0 = "Insert Into Sheet1 Values(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9)"
                    Ocmd_2.Parameters.Clear()
                    Ocmd_2.Parameters.AddWithValue("@t1", DbType.String).Value = MLevelNo
                    Ocmd_2.Parameters.AddWithValue("@t2", DbType.String).Value = MLevelDescription
                    Ocmd_2.Parameters.AddWithValue("@t3", DbType.Int32).Value = Mqty
                    Ocmd_2.Parameters.AddWithValue("@t4", DbType.Double).Value = MWages
                    Ocmd_2.Parameters.AddWithValue("@t5", DbType.Double).Value = MAllowance
                    Ocmd_2.Parameters.AddWithValue("@t6", DbType.Double).Value = MMeal
                    Ocmd_2.Parameters.AddWithValue("@t7", DbType.Double).Value = MAvgWages
                    Ocmd_2.Parameters.AddWithValue("@t8", DbType.Double).Value = MAvgAllowance
                    Ocmd_2.Parameters.AddWithValue("@t9", DbType.Double).Value = MAvgMeal
                    Ocmd_2.CommandText = Msqlstr_0
                    Ocmd_2.ExecuteNonQuery()
                Next

                ' 關閉相關物件及釋放資源
                Ocmd_2.Dispose()
                Ocmd_2.Dispose()
                Oconn_2.Close()
                Oconn_2.Dispose()

                Me.TopMost = False
                MsgBox("資料已存入 " + MSaveFileName, 0 + 64, "OK")
                Me.TopMost = True

            Case "htm"
                ' 本段匯出為網頁檔
                ' 使用 My.Computer.FileSystem 的 OpenTextFileWriter 方法可開啟 StreamWriter 物件，以便將資料寫入檔案，
                ' 需引用命名空間 Microsoft.VisualBasic.FileIO 及 System.Text
                ' 括號內第一個參數為檔案名稱及其路徑，第二個參數為附加與否，True 表示要附加，False 表示要覆蓋，第三個參數為編碼，編碼方式有 ASCII、UTF-8 等
                ' StreamWriter 資料流寫入類別的 WriteLine 方法可將資料寫入檔案，其後加上行結束字元，但 Write 則不加
                Dim O_file = My.Computer.FileSystem.OpenTextFileWriter(MSaveFileName, False, Encoding.UTF8)

                ' 文檔類型宣告
                ' 讓瀏覽器根據所宣告的文檔類型來解譯 HTML 標籤
                'O_fileWriteLine("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>")
                'O_file.WriteLine("<html xmlns='http://www.w3.org/1999/xhtml'>")
                O_file.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01 Transitional//EN'>")

                ' 定義網頁表頭（置於<head> ... </head>之間）
                ' title 元素可指定文件標題，charset 屬性可定義文件的字元編碼
                O_file.WriteLine("<html>")
                O_file.WriteLine("<head>")
                'O_SW.WriteLine("<meta http-equiv='Content-Language' content='zh-cn'>")
                O_file.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>")
                O_file.WriteLine("<title>年資層薪津統計表</title>")
                O_file.WriteLine("</head>")

                ' 定義網頁內容（置於<body> ... </body>之間）
                ' 定義網頁背景色、字型，
                ' 輸出文件名稱
                O_file.WriteLine("<body bgcolor='#006600' text='#FFFFFF' style='font-family: Arial; font-size: 16pt' link='#FFFFFF' vlink='#FFFFFF' alink='#FFFFFF'>")
                O_file.WriteLine("<p align='center'><font face='sans-serif' size='6' color='#FFFF00'>年資層薪津統計表<br>")
                O_file.WriteLine("<p style='font-family: Arial; font-size: 14pt; line-height: 42px; letter-spacing: 1px; text-align: left; vertical-align: medium'><font color='#FFFF00' size='4'><span style='font-family: Arial; font-size: 14pt; line-height: 42px; letter-spacing: 1px; text-align: left; vertical-align: medium'>")

                ' 輸出表格（置於<table> ... </table>之間）
                ' 表格元素： bgcolor 背景色、width寬度（可指定像數或百分比），
                ' 表格列（置於<TR> ... </TR>之間），
                ' 表格之儲存格（置於<TD> ... </TD>之間），表格儲存格元素：align 對齊方式、width寬度（可指定像數或百分比）、height 高度（可指定像數或百分比）、 bgcolor 背景色
                ' 置入欄位名稱
                O_file.WriteLine("<center><table border=1 cellpadding=0 cellspacing=0 width=900 height=36 bgcolor=FFFFFF bordercolor=#808080 bordercolorlight=#808080 bordercolordark=#808080>")
                O_file.WriteLine("<TR>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "年資層代號" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "年資層說明" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "人數" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "合計薪津" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "合計津貼" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "合計伙食費" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "平均薪津" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "平均津貼" + "</TD>")
                O_file.WriteLine("<TD style=font-size:12pt;color:#003300 width=100 height=36 bgcolor=rgb(204,255,204) align=center>" + "平均伙食費" + "</TD>")
                O_file.WriteLine("</TR>")

                ' 置入資料
                On Error Resume Next
                Dim Mstop As Integer = O_TableTotal.Rows.Count - 1
                Dim MLevelNo As String = ""
                Dim MLevelDescription As String = ""
                Dim Mqty As Int32 = 0
                Dim MWages As Double
                Dim MAllowance As Double
                Dim MMeal As Double
                Dim MAvgWages As Double
                Dim MAvgAllowance As Double
                Dim MAvgMeal As Double
                For Mcou = 0 To Mstop Step 1
                    MLevelNo = O_TableTotal.Rows(Mcou)(0)
                    MLevelDescription = O_TableTotal.Rows(Mcou)(1)
                    Mqty = O_TableTotal.Rows(Mcou)(2)
                    MWages = O_TableTotal.Rows(Mcou)(3)
                    MAllowance = O_TableTotal.Rows(Mcou)(4)
                    MMeal = O_TableTotal.Rows(Mcou)(5)
                    MAvgWages = O_TableTotal.Rows(Mcou)(6)
                    MAvgAllowance = O_TableTotal.Rows(Mcou)(7)
                    MAvgMeal = O_TableTotal.Rows(Mcou)(8)

                    O_file.WriteLine("<TR>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=center>" + MLevelNo + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=center>" + MLevelDescription + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + Mqty.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MWages.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MAllowance.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MMeal.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MAvgWages.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MAvgAllowance.ToString("#,0") + "</TD>")
                    O_file.WriteLine("<TD style=font-size:12pt;color:#000000 width=100 height=36 bgcolor=rgb(255,255,255) align=right>" + MAvgMeal.ToString("#,0") + "</TD>")
                    O_file.WriteLine("</TR>")
                Next

                ' 表格結尾符號
                O_file.WriteLine("</table></center>")

                ' 定義網頁結尾
                O_file.WriteLine("</body>")
                O_file.WriteLine("</html>")

                ' 關閉資料流物件
                O_file.Flush()
                O_file.Close()
                O_file.Dispose()

                Me.TopMost = False
                MsgBox("資料已存入 " + MSaveFileName, 0 + 64, "OK")
                Me.TopMost = True
        End Select
    End Sub

End Class