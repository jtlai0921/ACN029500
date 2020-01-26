Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic
Imports TaipeiVB

Public Class F_DLL
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0
    ' 宣告資料表以便作為 DataGridView1 的資料來源
    Public O_Table01 As DataTable
    ' 宣告資料表以便作為 DataGridView2 的資料來源
    Public O_Table02 As DataTable
    ' 宣告資料集物件
    Public ODataSet_1 As DataSet

    ' 載入本表單時讀取薪津資料至DataGridView
    Private Sub F_DLL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 顯示等待訊息
        F_wait.Show()
        DataGridView1.DataSource = Nothing

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_1 As String = "Select STAFF_NO,STAFF_NAME,STAFF_SEX,DEPT_CODE,DEPT_NAME,TITLECODE,TITLE,GRADE,WAGES,FILEDATE From SALARY Where FILEDATE='201412' And DEPT_CODE In ('2100','2200','2500','2600')"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 建立資料集，以便存放讀出的資料
        'ODataSet_1 = New DataSet
        ' 建立資料表
        O_Table01 = New DataTable
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資表
        ODataAdapter_1.Fill(O_Table01)

        ' 指定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_Table01

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料表的總筆數
        MTotalRecordNo = O_Table01.Rows.Count
        T_RecordNo.Text = MTotalRecordNo.ToString

        ' 加入中文欄名，欄名因匯總方式而不同
        With DataGridView1
            .Columns(0).HeaderText = "員工號"
            .Columns(1).HeaderText = "員工姓名"
            .Columns(2).HeaderText = "性別"
            .Columns(3).HeaderText = "部門代號"
            .Columns(4).HeaderText = "部門名稱"
            .Columns(5).HeaderText = "職稱代號"
            .Columns(6).HeaderText = "職稱"
            .Columns(7).HeaderText = "等級"
            .Columns(8).HeaderText = "薪津"
            .Columns(9).HeaderText = "日期"
        End With
        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 格式化
        With DataGridView1
            .Columns(8).DefaultCellStyle.Format = "#,0"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

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
            .Name = "Delete_chk"
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

        ' 產生 Table02 資料表（結構及資料與 Table01 相同，隨後清空，以便儲存 DataGridView 移出的資料）
        O_Table02 = O_Table01.Copy()
        DataGridView2.DataSource = O_Table02

        ' 加入中文欄名，欄名因匯總方式而不同
        With DataGridView2
            .Columns(0).HeaderText = "員工號"
            .Columns(1).HeaderText = "員工姓名"
            .Columns(2).HeaderText = "性別"
            .Columns(3).HeaderText = "部門代號"
            .Columns(4).HeaderText = "部門名稱"
            .Columns(5).HeaderText = "職稱代號"
            .Columns(6).HeaderText = "職稱"
            .Columns(7).HeaderText = "等級"
            .Columns(8).HeaderText = "薪津"
            .Columns(9).HeaderText = "日期"
        End With
        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView2.ColumnHeadersHeight = 28

        ' 格式化
        With DataGridView2
            .Columns(8).DefaultCellStyle.Format = "#,0"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView2.AllowUserToAddRows = False

        ' 在資料網格控制項中增加核取清單方塊欄 ，供 User 敲選
        Dim O_ChkBox2 As New DataGridViewCheckBoxColumn
        With O_ChkBox2
            .FlatStyle = FlatStyle.Standard
            .HeaderText = "請敲選"
            .Name = "Delete_chk"
            .ThreeState = False
            '.ValueType = GetType(Boolean)
            '.FalseValue = False
            '.TrueValue = True
            .ValueType = GetType(String)
            .FalseValue = "No"
            .TrueValue = "Yes"
        End With
        DataGridView2.Columns.Insert(0, O_ChkBox2)

        Dim MStop2 As Int32 = DataGridView2.Columns.Count - 1
        DataGridView2.ReadOnly = False
        For Mcou = 1 To MStop2 Step 1
            DataGridView2.Columns(Mcou).ReadOnly = True
        Next

        ' 清空資料網格控制項 2，先清除其來源資料表，
        ' 若使用下列 Clear 方法，則連欄位名稱都會被清除，故不使用
        'DataGridView2.DataSource = Nothing
        'DataGridView2.Rows.Clear()
        'DataGridView2.Columns.Clear()

        Dim MStop3 As Int32 = O_Table02.Rows.Count - 1
        For Mcou = 0 To MStop3 Step 1
            O_Table02.Rows(Mcou).Delete()
        Next
        DataGridView2.DataSource = O_Table02
        DataGridView2.Refresh()
        ' 顯示記錄數
        T_RecordNo2.Text = DataGridView2.Rows.Count.ToString

        ' 結束等待訊息
        F_wait.Hide()

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 屬性，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView2.RowCount > 0 Then
            'DataGridView2.Rows(0).Cells(0).Selected = True
            DataGridView2(0, 0).Selected = True
        End If
    End Sub

    Private Sub B_Close_Click(sender As Object, e As EventArgs) Handles B_Close.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            F_menu.Show()
        Else
            Return
        End If
    End Sub

    ' 移出 DataGridView1 中的勾選的項目（轉入 DataGridView2）
    Private Sub B_Remove_Click(sender As Object, e As EventArgs) Handles B_Remove.Click
        ' 先檢查 DataGridView 是否有資料可移除
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可移除！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 顯示等待訊息
        F_wait.Show()

        ' 逐列判斷 DataGridView 第一行的資料是否為  Yes 或 True（核取清單方塊之狀態），若是則移除之
        ' 必須反向判斷（由最後一筆逐漸往前判斷），否則執行過半時，會因列號大於 DataGridView 的總筆數而發生錯誤（DataGridView 的總筆數會因 RemoveAt 而逐漸減少）
        ' 資料網格控制項的格位可由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 亦可於 DataGridView 之後以括號指定行數及列數（括號內兩個引數，前者為行，後者為列，切莫顛倒），
        ' RemoveAt 方法可移除資料網格控制項的資料列，括號內為資料列索引
        ' 移除之前，先將該列資料存入 DataRow 資料列，然後併入 O_Table02 資料表，該資料表為 DataGridView2 的 資料來源
        ' 請注意 DataGridView1 括號內的行號（第一個參數），由 1 開始取出 10 欄的資料轉入 O_NewRow 資料列，因為第一個欄位（行號 0）為核取清單方塊欄，無需轉出
        Dim MTotalRecords As Int32 = DataGridView1.Rows.Count
        For Mcou = MTotalRecords - 1 To 0 Step -1
            'If DataGridView1(0, Mcou).Value = True Then
            If DataGridView1(0, Mcou).Value = "Yes" Then
                Dim O_NewRow As DataRow
                O_NewRow = O_Table02.NewRow()
                O_NewRow.Item(0) = DataGridView1(1, Mcou).Value
                O_NewRow.Item(1) = DataGridView1(2, Mcou).Value
                O_NewRow.Item(2) = DataGridView1(3, Mcou).Value
                O_NewRow.Item(3) = DataGridView1(4, Mcou).Value
                O_NewRow.Item(4) = DataGridView1(5, Mcou).Value
                O_NewRow.Item(5) = DataGridView1(6, Mcou).Value
                O_NewRow.Item(6) = DataGridView1(7, Mcou).Value
                O_NewRow.Item(7) = DataGridView1(8, Mcou).Value
                O_NewRow.Item(8) = DataGridView1(9, Mcou).Value
                O_NewRow.Item(9) = DataGridView1(10, Mcou).Value
                O_Table02.Rows.Add(O_NewRow)
                O_Table02.AcceptChanges()

                DataGridView1.Rows.RemoveAt(Mcou)
            End If
        Next
        DataGridView1.Refresh()
        DataGridView2.DataSource = O_Table02
        DataGridView2.Refresh()

        ' 結束等待訊息
        F_wait.Hide()

        ' 顯示記錄數
        MTotalRecordNo = DataGridView2.Rows.Count
        T_RecordNo2.Text = MTotalRecordNo.ToString
        MTotalRecordNo = DataGridView1.Rows.Count
        T_RecordNo.Text = MTotalRecordNo.ToString

    End Sub

    ' 移出 DataGridView2 中的勾選的項目（轉回 DataGridView1）
    Private Sub B_ReCall_Click(sender As Object, e As EventArgs) Handles B_ReCall.Click
        ' 先檢查 DataGridView 是否有資料可轉回
        If DataGridView2.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可轉回！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 顯示等待訊息
        F_wait.Show()

        ' 逐列判斷 DataGridView 第一行的資料是否為  Yes 或 True（核取清單方塊之狀態），若是則移除之
        ' 必須反向判斷（由最後一筆逐漸往前判斷），否則執行過半時，會因列號大於 DataGridView 的總筆數而發生錯誤（DataGridView 的總筆數會因 Delete 而逐漸減少）
        ' 資料網格控制項的格位可由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 亦可於 DataGridView 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列，切莫顛倒），
        ' RemoveAt 方法可移除資料網格控制項的資料列，括號內為資料列索引
        ' 移除之前，先將該列資料存入 DataRow 資料列，然後併入 O_Table01 資料表，該資料表為 DataGridView1 的 資料來源
        ' 請注意 DataGridView2 括號內的行號（第一個參數），由 1 開始取出 10 欄的資料轉入 O_NewRow 資料列，因為第一個欄位（行號 0）為核取清單方塊欄，無需轉出
        Dim MTotalRecords As Int32 = DataGridView2.Rows.Count
        For Mcou = MTotalRecords - 1 To 0 Step -1
            'If DataGridView2(0, Mcou).Value = True Then
            If DataGridView2(0, Mcou).Value = "Yes" Then
                Dim O_NewRow As DataRow
                O_NewRow = O_Table01.NewRow()
                O_NewRow.Item(0) = DataGridView2(1, Mcou).Value
                O_NewRow.Item(1) = DataGridView2(2, Mcou).Value
                O_NewRow.Item(2) = DataGridView2(3, Mcou).Value
                O_NewRow.Item(3) = DataGridView2(4, Mcou).Value
                O_NewRow.Item(4) = DataGridView2(5, Mcou).Value
                O_NewRow.Item(5) = DataGridView2(6, Mcou).Value
                O_NewRow.Item(6) = DataGridView2(7, Mcou).Value
                O_NewRow.Item(7) = DataGridView2(8, Mcou).Value
                O_NewRow.Item(8) = DataGridView2(9, Mcou).Value
                O_NewRow.Item(9) = DataGridView2(10, Mcou).Value
                O_Table01.Rows.Add(O_NewRow)
                O_Table01.AcceptChanges()

                DataGridView2.Rows.RemoveAt(Mcou)
            End If
        Next
        DataGridView2.Refresh()
        DataGridView1.DataSource = O_Table01
        DataGridView1.Refresh()

        ' 結束等待訊息
        F_wait.Hide()

        ' 顯示記錄數
        MTotalRecordNo = DataGridView1.Rows.Count
        T_RecordNo.Text = MTotalRecordNo.ToString
        MTotalRecordNo = DataGridView2.Rows.Count
        T_RecordNo2.Text = MTotalRecordNo.ToString

    End Sub

    ' 在比對清單中敲了『等級』，顯示『等級』下拉式選單及其輸入文字盒，其他下拉式選單及輸入文字盒不顯示
    Private Sub T_MATCH1_CheckedChanged(sender As Object, e As EventArgs) Handles T_MATCH1.CheckedChanged
        If T_MATCH1.Checked = True Then
            L_GRADE.Visible = True
            T_GRADE.Visible = True
            T_GradeList.Visible = True
            L_DEPT.Visible = False
            T_DEPT.Visible = False
            T_DeptList.Visible = False
            L_TITLE.Visible = False
            T_TITLE.Visible = False
            T_TitleList.Visible = False
        End If
    End Sub

    ' 在比對清單中敲了『部門』，顯示『部門』下拉式選單及其輸入文字盒，其他下拉式選單及輸入文字盒不顯示
    Private Sub T_MATCH2_CheckedChanged(sender As Object, e As EventArgs) Handles T_MATCH2.CheckedChanged
        If T_MATCH2.Checked = True Then
            L_GRADE.Visible = False
            T_GRADE.Visible = False
            T_GradeList.Visible = False
            L_DEPT.Visible = True
            T_DEPT.Visible = True
            T_DeptList.Visible = True
            L_TITLE.Visible = False
            T_TITLE.Visible = False
            T_TitleList.Visible = False
        End If
    End Sub

    ' 在比對清單中敲了『職稱』，顯示『職稱』下拉式選單及其輸入文字盒，其他下拉式選單及輸入文字盒不顯示
    Private Sub T_MATCH3_CheckedChanged(sender As Object, e As EventArgs) Handles T_MATCH3.CheckedChanged
        If T_MATCH3.Checked = True Then
            L_GRADE.Visible = False
            T_GRADE.Visible = False
            T_GradeList.Visible = False
            L_DEPT.Visible = False
            T_DEPT.Visible = False
            T_DeptList.Visible = False
            L_TITLE.Visible = True
            T_TITLE.Visible = True
            T_TitleList.Visible = True
        End If
    End Sub

    '  T_GRADE 等級下拉式選單敲選變動事件，將選單之值併入 T_GradeList 文字盒，可多選但不能重複，各值之間以逗號分隔
    Private Sub T_GRADE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_GRADE.SelectedIndexChanged
        Dim Mtemp As String = Strings.Trim(T_GradeList.Text)
        If Mtemp = "" Then
            T_GradeList.Text = T_GRADE.Text
        Else
            Dim O_01 As New TaipeiVB.MyClass01
            Dim Mresult As String
            ' 將 T_GradeList 文字盒的已輸入字串按逗號分隔，並存入陣列 Awords，作為自訂函式 InList 的第二參數
            Dim Awords As String() = Strings.Split(Mtemp, ",")
            ' 使用自訂函式 InList 檢查下拉式選單之值是否已敲選過，未敲選過才列入  T_GradeList 文字盒，以免重複
            Mresult = O_01.InList(T_GRADE.Text, Awords)
            If Mresult = "N" Then
                T_GradeList.Text = Mtemp + "," + T_GRADE.Text
            End If
        End If
    End Sub

    '  T_DEPT 部門下拉式選單敲選變動事件，將選單之值併入 T_DeptList 文字盒，可多選但不能重複，各值之間以逗號分隔
    Private Sub T_DEPT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_DEPT.SelectedIndexChanged
        Dim Mtemp As String = Strings.Trim(T_DeptList.Text)
        If Mtemp = "" Then
            T_DeptList.Text = Strings.Left(T_DEPT.Text, 4)
        Else
            Dim O_01 As New TaipeiVB.MyClass01
            Dim Mresult As String
            ' 將 T_DeptList 文字盒的已輸入字串按逗號分隔，並存入陣列 Awords，作為自訂函式 InList 的第二參數
            Dim Awords As String() = Strings.Split(Mtemp, ",")
            ' 使用自訂函式 InList 檢查下拉式選單之值是否已敲選過，未敲選過才列入  T_DeptList 文字盒，以免重複
            Mresult = O_01.InList(Strings.Left(T_DEPT.Text, 4), Awords)
            If Mresult = "N" Then
                T_DeptList.Text = Mtemp + "," + Strings.Left(T_DEPT.Text, 4)
            End If
        End If
    End Sub

    '  T_TITLE 職稱下拉式選單敲選變動事件，將選單之值併入 T_TitleList 文字盒，可多選但不能重複，各值之間以逗號分隔
    Private Sub T_TITLE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_TITLE.SelectedIndexChanged
        Dim Mtemp As String = Strings.Trim(T_TitleList.Text)
        If Mtemp = "" Then
            T_TitleList.Text = T_TITLE.Text
        Else
            Dim O_01 As New TaipeiVB.MyClass01
            Dim Mresult As String
            ' 將 T_TitleList 文字盒的已輸入字串按逗號分隔，並存入陣列 Awords，作為自訂函式 InList 的第二參數
            Dim Awords As String() = Strings.Split(Mtemp, ",")
            ' 使用自訂函式 InList 檢查下拉式選單之值是否已敲選過，未敲選過才列入  T_TitleList 文字盒，以免重複
            Mresult = O_01.InList(T_TITLE.Text, Awords)
            If Mresult = "N" Then
                T_TitleList.Text = Mtemp + "," + T_TITLE.Text
            End If
        End If
    End Sub

    ' 清空輸入文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        T_GradeList.Text = ""
        T_DeptList.Text = ""
        T_TitleList.Text = ""
        T_GRADE.Text = ""
        T_DEPT.Text = ""
        T_TITLE.Text = ""
    End Sub

    ' 比對資料
    Private Sub B_Match_Click(sender As Object, e As EventArgs) Handles B_Match.Click

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可比對！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 根據 User 所敲選的比對種類找出欄位索引，例如『等級』為第9欄（索引順序為 8），並存入變數 MkeyColumn
        ' 比對值（User輸入或敲選之值）則存入變數 Mtemp
        Dim MkeyColumn As Integer = 8
        Dim Mtemp As String = ""
        If T_MATCH1.Checked = True Then
            MkeyColumn = 8
            Mtemp = Strings.Trim(T_GradeList.Text)
        End If
        If T_MATCH2.Checked = True Then
            MkeyColumn = 4
            Mtemp = Strings.Trim(T_DeptList.Text)
        End If
        If T_MATCH3.Checked = True Then
            MkeyColumn = 7
            Mtemp = Strings.Trim(T_TitleList.Text)
        End If
        If Mtemp = "" Then
            MsgBox("Sorry, 您尚未輸入比對值！" + Chr(13) + Chr(13) + "您必須在『等級』、『部門』、『職稱』等欄擇一輸入。", 0 + 16, "Error")
            Exit Sub
        End If
        ' 顯示等待訊息
        F_wait.Show()

        ' 依據 TaipeiVB.MyClass01 建立新的物件 O_01
        Dim O_01 As New TaipeiVB.MyClass01
        ' 關鍵欄之值，例如『等級』存入變數 MchkValue
        Dim MchkValue As String = ""
        ' 比對結果存入 Mresult
        Dim Mresult As String = ""
        ' 符合的筆數存入 Mchkqty
        Dim Mchkqty As Int32 = 0
        Dim Mstop As Int32 = DataGridView1.Rows.Count - 1

        ' 以 For 迴圈逐筆比對，先清空第一欄的核取狀態
        For Mrow = 0 To Mstop Step 1
            DataGridView1(0, Mrow).Value = "No"
        Next
        For Mrow = 0 To Mstop Step 1
            ' 將關鍵欄之值，例如『等級』存入變數MchkValue，作為自訂函式函式 InList 的第一個參數
            MchkValue = DataGridView1(MkeyColumn, Mrow).Value
            ' 將 Mtemp 比對值按逗號分隔，並存入陣列 Awords，作為自訂函式 InList 的第二參數
            Dim Awords As String() = Strings.Split(Mtemp, ",")
            ' 利用自訂函式 InList 比對，比對結果存入 Mresult
            Mresult = O_01.InList(MchkValue, Awords)
            If Mresult = "Y" Then
                DataGridView1(0, Mrow).Value = "Yes"
                Mchkqty = Mchkqty + 1
            End If
        Next
        ' 結束等待訊息
        F_wait.Hide()
        MsgBox("比對完成！" + Chr(13) + Chr(13) + "符合筆數： " + Mchkqty.ToString, 0 + 64, "OK")

    End Sub

    ' 將 DataGridView2 的全部資料轉回 DataGridView1
    Private Sub B_ReCallAll_Click(sender As Object, e As EventArgs) Handles B_ReCallAll.Click
        ' 先檢查 DataGridView 是否有資料可轉回
        If DataGridView2.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可轉回！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 顯示等待訊息
        F_wait.Show()

        ' 移除之前，先將 DataGridView2 的資料存入 DataRow 資料列，然後併入 O_Table01 資料表，該資料表為 DataGridView1 的 資料來源
        Dim MTotalRecords As Int32 = DataGridView2.Rows.Count
        For Mcou = MTotalRecords - 1 To 0 Step -1
            Dim O_NewRow As DataRow
            O_NewRow = O_Table01.NewRow()
            O_NewRow.Item(0) = DataGridView2(1, Mcou).Value
            O_NewRow.Item(1) = DataGridView2(2, Mcou).Value
            O_NewRow.Item(2) = DataGridView2(3, Mcou).Value
            O_NewRow.Item(3) = DataGridView2(4, Mcou).Value
            O_NewRow.Item(4) = DataGridView2(5, Mcou).Value
            O_NewRow.Item(5) = DataGridView2(6, Mcou).Value
            O_NewRow.Item(6) = DataGridView2(7, Mcou).Value
            O_NewRow.Item(7) = DataGridView2(8, Mcou).Value
            O_NewRow.Item(8) = DataGridView2(9, Mcou).Value
            O_NewRow.Item(9) = DataGridView2(10, Mcou).Value
            O_Table01.Rows.Add(O_NewRow)
            O_Table01.AcceptChanges()

            DataGridView2.Rows.RemoveAt(Mcou)
        Next
        DataGridView2.Refresh()
        DataGridView1.DataSource = O_Table01
        DataGridView1.Refresh()

        ' 結束等待訊息
        F_wait.Hide()

        ' 顯示記錄數
        MTotalRecordNo = DataGridView1.Rows.Count
        T_RecordNo.Text = MTotalRecordNo.ToString
        MTotalRecordNo = DataGridView2.Rows.Count
        T_RecordNo2.Text = MTotalRecordNo.ToString
    End Sub

End Class