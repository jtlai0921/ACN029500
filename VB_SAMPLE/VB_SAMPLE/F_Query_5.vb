Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class F_Query_5

    ' 宣告 MTotalRecordNo 變數，用以儲存 DataGridView 的記錄數
    Public MTotalRecordNo As Int32
    ' 宣告 O_DV 資料檢視表，供不同程序使用
    Public O_DV As DataView
    ' 宣告檢查變數
    Public Mfind As String
    ' 宣告資料表，供不同程序使用
    Public O_dtable_1 As DataTable



    ' --------------------------------------------------------------------------------------------------------------------------------

    ' 載入本表單時，設定 TreeView 的縮排點數及項目高度，並展開樹狀檢視控制項
    Private Sub F_Query_5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.Indent = 20
        TreeView1.ItemHeight = 30
        TreeView1.ExpandAll()
    End Sub

    ' 建立樹狀檢視範例 1
    ' 本法依照原始資料的順序建立樹狀檢視項目
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        ' 清空文字盒及資料網格控制項
        DataGridView1.DataSource = Nothing

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' Extended Properties=之後的參數要用單引號括起來，否則會出现“找不到可安装的 ISAM”的訊息
        ' HDR=Yes　表示 Excel 表的第一列為欄名，No 则表示第一列不是欄名
        ' IMEX=1; 將文數字混雜的欄位資料視為文字來處理，例如 QTY 欄名為文字 而 HDR=NO，IMEX=1，則該欄之數字會被視為文字來處理，
        ' 若 HDR=Yes，IMEX=1，則該欄之數字會被視為數字來處理，例如 12,345 變成 12345
        ' OLEDB.12 可連結新版及舊版的 Excel，但需安裝 Office 2007（含）以上，OLEDB.4 只能連結舊版的 Excel
        ' Office 版本編號： 2003 → 11 、 2007 → 12 、 2010 → 14 、 2013 → 15
        Dim MFN_0 As String = "APPDATA\圖書庫存統計.xlsx"
        Dim Mstrconn_0 As String = ""
        Mstrconn_0 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
        'Mstrconn_0 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"

        ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
        Dim Oconn_0 As New OleDbConnection(Mstrconn_0)
        Oconn_0.Open()

        ' 設定 SQL 字串，供資料轉接器使用
        Dim Msqlstr_0 As String = "Select * From [工作表1$]"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
        ' 無需使用 OleDbCommand 物件
        Dim ODataAdapter_0 As New OleDbDataAdapter(Msqlstr_0, Oconn_0)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_0 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_0.Fill(ODataSet_0, "Table01")

        ' 使用 Delete 方法刪除無需的部分（第 1～4 列），刪除後需使用 AcceptChanges 方法，以便認可對這個資料表所做的變更，
        ' 若不使用 AcceptChanges 方法，則 Rows.Count 屬性仍傳回刪除前的筆數，
        ' 若不使用 AcceptChanges 方法 ，DataGridView1 雖不會顯示已 Delete 的部分，但未實際移除，故 Rows.Count 屬性仍傳回刪除前的筆數
        ODataSet_0.Tables("Table01").Rows(0).Delete()
        ODataSet_0.Tables("Table01").Rows(1).Delete()
        ODataSet_0.Tables("Table01").Rows(2).Delete()
        ODataSet_0.Tables("Table01").Rows(3).Delete()
        ODataSet_0.Tables("Table01").AcceptChanges()

        ' 將來源資料存入 O_DV 資料檢視表 ，供TreeView1_AfterSelect 事件程序使用
        O_DV = ODataSet_0.Tables("Table01").DefaultView
        O_DV.Sort = "F1 ASC,F3 ASC"

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        ' 指派 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_0.Tables("Table01")
        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "分公司"
            .Columns(1).HeaderText = "分類"
            .Columns(2).HeaderText = "書名"
            .Columns(3).HeaderText = "數量"
        End With
        ' 格式化
        With DataGridView1
            .Columns(3).DefaultCellStyle.Format = "#,0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        ' 計算總筆數
        MTotalRecordNo = ODataSet_0.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數：  " + MTotalRecordNo.ToString

        ' 關閉 存取資料庫的相關物件
        Oconn_0.Close()
        Oconn_0.Dispose()
        ODataAdapter_0.Dispose()

        ' 清除原有樹狀檢視控制項的內容
        TreeView1.Nodes.Clear()

        ' 宣告根節點之文字
        Dim Mroot As String = "圖書庫存統計"
        ' 加入根節點
        TreeView1.Nodes.Add(Mroot)

        ' 使用 For 迴圈建立（第一層節點）分公司節點
        TreeView1.SelectedNode = Nothing
        Dim Mstop As Integer = ODataSet_0.Tables("Table01").Rows.Count - 1
        Dim Mbranch As String = ""
        Dim Mkind As String = ""
        Dim Mitemname As String = ""
        For Mcou = 0 To Mstop Step 1
            Mbranch = ODataSet_0.Tables("Table01").Rows(Mcou)(0)
            ' 呼叫副程序，建立分公司節點（傳遞分公司參數）
            SubLevel_1(TreeView1.Nodes(0), Mbranch)
        Next

        ' 使用 For 迴圈建立（第二層節點）分類節點
        TreeView1.SelectedNode = Nothing
        Mstop = ODataSet_0.Tables("Table01").Rows.Count - 1
        Mbranch = ""
        Mkind = ""
        Mitemname = ""
        For Mcou = 0 To Mstop Step 1
            Mbranch = ODataSet_0.Tables("Table01").Rows(Mcou)(0)
            Mkind = ODataSet_0.Tables("Table01").Rows(Mcou)(1)
            ' 呼叫副程序，建立分類節點（傳遞分公司參數及分類參數）
            SubLevel_2(TreeView1.Nodes(0), Mbranch, Mkind)
        Next

        ' 使用 For 迴圈建立（第三層節點）書名節點
        TreeView1.SelectedNode = Nothing
        Mstop = ODataSet_0.Tables("Table01").Rows.Count - 1
        Mbranch = ""
        Mkind = ""
        Mitemname = ""
        For Mcou = 0 To Mstop Step 1
            Mbranch = ODataSet_0.Tables("Table01").Rows(Mcou)(0)
            Mkind = ODataSet_0.Tables("Table01").Rows(Mcou)(1)
            Mitemname = ODataSet_0.Tables("Table01").Rows(Mcou)(2)
            ' 呼叫副程序，找出分公司及分類所在的節點（傳遞分公司及分類兩個參數）
            SubLevel_3(TreeView1.Nodes(0), Mbranch, Mkind)
            ' 在選定項目的同一層節點加入新項目（書名）
            TreeView1.SelectedNode.Nodes.Add(New TreeNode(Mitemname))
        Next

        ' 展開樹狀檢視控制項
        TreeView1.Indent = 20
        TreeView1.ItemHeight = 30
        TreeView1.ExpandAll()
        TreeView1.SelectedNode = TreeView1.Nodes(0)
    End Sub

    ' 副程序_建立『分公司』節點
    ' 檢查第一層每一節點，若節點名稱與分公司相同，則離開副程序，若無相同節點名稱，則新增之
    Private Sub SubLevel_1(TempNode As TreeNode, ByVal Temp_Branch As String)
        Dim MFind As String = "N"
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Temp_Branch Then
                Exit Sub
            End If
        Next
        If MFind = "N" Then
            TreeView1.SelectedNode = TreeView1.Nodes(0)
            TreeView1.SelectedNode.Nodes.Add(New TreeNode(Temp_Branch))
        End If
    End Sub

    ' 副程序_建立『分類』節點之一
    ' 檢查第一層每一節點，若節點名稱與分公司相同，則呼叫副程序 SubLevel_2B，並傳遞兩個參數， 前者為某一樹狀節點（包括其所有下層節點），後者為分類，
    ' 檢查第一層某一節點時（例如台北分公司），應使用SelectedNode 屬性選定該節點，以利後續程式新增該節點之項目（亦即其下一層之節點，本例為分類節點）
    Private Sub SubLevel_2(TempNode As TreeNode, ByVal Temp_Branch As String, ByVal Temp_Kind As String)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Temp_Branch Then
                TreeView1.SelectedNode = O_node
                SubLevel_2B(O_node, Temp_Kind)
            End If
        Next
    End Sub

    ' 副程序_建立『分類』節點之二
    ' 檢查第二層某一節點之所有項目，若項目名稱與分類相同，則離開副程序，若該節點無相同項目，則新增之，
    Private Sub SubLevel_2B(TempNode As TreeNode, M_Kind As String)
        Dim MFind As String = "N"
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = M_Kind Then
                Exit Sub
            End If
        Next
        If MFind = "N" Then
            TreeView1.SelectedNode.Nodes.Add(New TreeNode(M_Kind))
        End If
    End Sub

    ' 副程序_找出『分公司』
    ' 若節點名稱與分公司相同，則呼叫分類副程序，並傳遞該節點（包括其下層節點）作為副程序之參數
    Private Sub SubLevel_3(TempNode As TreeNode, ByVal Temp_Branch As String, ByVal Temp_kind As String)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Temp_Branch Then
                SubLevel_3B(O_node, Temp_kind)
            End If
        Next
    End Sub

    ' 副程序_找出『分類』
    ' 若節點名稱與分類相同，則選定該節點
    Private Sub SubLevel_3B(TempNode2 As TreeNode, ByVal M_kind As String)
        For Each O_node As TreeNode In TempNode2.Nodes
            If O_node.Text = M_kind Then
                TreeView1.SelectedNode = O_node
                Exit Sub
            End If
        Next
    End Sub

    ' 建立樹狀檢視範例 2
    ' 本法依照排序後的順序建立樹狀檢視項目，每一分公司都會有相同數量的下一層節點（分類數相同），即使沒有書名，也會建立分類節點，
    ' 例如高雄分公司沒有『語言』的書 ，也會建立『語言』節點
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        ' 清空文字盒及資料網格控制項
        DataGridView1.DataSource = Nothing

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' Extended Properties=之後的參數要用單引號括起來，否則會出现“找不到可安装的 ISAM”的訊息
        ' HDR=Yes　表示 Excel 表的第一列為欄名，No 则表示第一列不是欄名
        ' IMEX=1; 將文數字混雜的欄位資料視為文字來處理，例如 QTY 欄名為文字 而 HDR=NO，IMEX=1，則該欄之數字會被視為文字來處理，
        ' 若 HDR=Yes，IMEX=1，則該欄之數字會被視為數字來處理，例如 12,345 變成 12345
        ' OLEDB.12 可連結新版及舊版的 Excel，但需安裝 Office 2007（含）以上，OLEDB.4 只能連結舊版的 Excel
        ' Office 版本編號： 2003 → 11 、 2007 → 12 、 2010 → 14 、 2013 → 15
        Dim MFN_0 As String = "APPDATA\圖書庫存統計.xlsx"
        Dim Mstrconn_0 As String = ""
        Mstrconn_0 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
        'Mstrconn_0 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"

        ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
        Dim Oconn_0 As New OleDbConnection(Mstrconn_0)
        Oconn_0.Open()

        ' 設定 SQL 字串，供資料轉接器使用
        Dim Msqlstr_0 As String = "Select * From [工作表1$]"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
        ' 無需使用 OleDbCommand 物件
        Dim ODataAdapter_0 As New OleDbDataAdapter(Msqlstr_0, Oconn_0)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_0 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_0.Fill(ODataSet_0, "Table01")

        ' 使用 Delete 方法刪除無需的部分（第 1～4 列），刪除後需使用 AcceptChanges 方法，以便認可對這個資料表所做的變更，
        ' 若不使用 AcceptChanges 方法，則 Rows.Count 屬性仍傳回刪除前的筆數，
        ' 若不使用 AcceptChanges 方法 ，DataGridView1 雖不會顯示已 Delete 的部分，但未實際移除，故 Rows.Count 屬性仍傳回刪除前的筆數
        ODataSet_0.Tables("Table01").Rows(0).Delete()
        ODataSet_0.Tables("Table01").Rows(1).Delete()
        ODataSet_0.Tables("Table01").Rows(2).Delete()
        ODataSet_0.Tables("Table01").Rows(3).Delete()
        ODataSet_0.Tables("Table01").AcceptChanges()

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        ' 指派 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_0.Tables("Table01")
        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "分公司"
            .Columns(1).HeaderText = "分類"
            .Columns(2).HeaderText = "書名"
            .Columns(3).HeaderText = "數量"
        End With
        ' 格式化
        With DataGridView1
            .Columns(3).DefaultCellStyle.Format = "#,0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        ' 計算總筆數
        MTotalRecordNo = ODataSet_0.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數：  " + MTotalRecordNo.ToString

        ' 關閉 存取資料庫的相關物件
        Oconn_0.Close()
        Oconn_0.Dispose()
        ODataAdapter_0.Dispose()

        ' 篩選分公司作為第一層的節點
        ' 先按 F1 欄（分公司）排序
        Dim O_DataView As DataView
        O_DataView = ODataSet_0.Tables("Table01").DefaultView
        O_DataView.Sort = "F1 ASC"

        ' 逐筆比對 O_DataView 資料檢視物件的 F1 欄（分公司），以便篩選出唯一的分公司，並存入 List01 清單集合
        ' 先將 O_DataView 第一筆存入 List01，並存入 Mcheck 變數 ，以便作為比較的準繩，
        ' 然後使用 For 迴圈， 逐筆比對 O_DataView 資料檢視物件的 F1 欄（從第二筆開始），
        ' 若不同於 Mcheck，則併入 List01，並變更 Mcheck 變數之值 ，以便作為比較的新準繩
        Dim List01 As New List(Of String)
        Dim Mstop As Integer = O_DataView.Count - 1
        List01.Add(O_DataView.Item(0)(0))
        Dim Mcheck As String = O_DataView.Item(0)(0)
        For Mcou = 1 To Mstop Step 1
            If Mcheck <> O_DataView.Item(Mcou)(0) Then
                List01.Add(O_DataView.Item(Mcou)(0))
                Mcheck = O_DataView.Item(Mcou)(0)
            End If
        Next

        ' 清除原有樹狀檢視控制項的內容
        TreeView1.Nodes.Clear()

        ' 宣告根節點之文字
        Dim Mroot As String = "圖書庫存統計"
        ' 加入根節點
        TreeView1.Nodes.Add(Mroot)

        ' 使用 For 迴圈加入第一層的節點（分公司）
        Mstop = List01.Count - 1
        For Mcou = 0 To Mstop Step 1
            TreeView1.Nodes(0).Nodes.Add(New TreeNode(List01.Item(Mcou)))
        Next

        ' 篩選分類作為第二層的節點
        Dim List02 As New List(Of String)
        ' 先按 F2 欄（分類）排序
        O_DataView.Sort = "F2 ASC"

        ' 逐筆比對 O_DataView 資料檢視物件的 F2 欄（分類），以便篩選出唯一的『分類』，並存入 List02 清單集合
        ' 先將 O_DataView 第一筆存入 List02，並存入 Mcheck 變數 ，以便作為比較的準繩，
        ' 然後使用 For 迴圈， 逐筆比對 O_DataView 資料檢視物件的 F2 欄（從第二筆開始），
        ' 若不同於 Mcheck，則併入 List02，並變更 Mcheck 變數之值 ，以便作為比較的新準繩
        Mstop = O_DataView.Count - 1
        List02.Add(O_DataView.Item(0)(1))
        Mcheck = O_DataView.Item(0)(1)
        For Mcou = 1 To Mstop Step 1
            If Mcheck <> O_DataView.Item(Mcou)(1) Then
                List02.Add(O_DataView.Item(Mcou)(1))
                Mcheck = O_DataView.Item(Mcou)(1)
            End If
        Next

        TreeView1.SelectedNode = Nothing
        Dim MsearchNode As String = ""
        Mstop = List01.Count - 1
        Dim Mstop2 As Integer = List02.Count - 1
        ' 使用遞迴呼叫程序，判斷每一層級的節點文字是否與新增項目之類別相同，括號內有兩個參數，前者為根節點，前者為欲新增項目之所屬類別
        For mcou = 0 To Mstop Step 1
            MsearchNode = List01(mcou)
            CheckNode(TreeView1.Nodes(0), MsearchNode)
            For Mcou2 = 0 To Mstop2 Step 1
                TreeView1.SelectedNode.Nodes.Add(New TreeNode(List02(Mcou2)))
            Next
        Next

        ' 逐一加入項目名稱（書名）
        ' 使用 For 迴圈逐筆取出分公司及分類，以便作為副程序之參數
        TreeView1.SelectedNode = Nothing
        Mstop = ODataSet_0.Tables("Table01").Rows.Count - 1
        Dim Mbranch As String = ""
        Dim Mkind As String = ""
        Dim Mitemname As String = ""
        For Mcou = 0 To Mstop Step 1
            Mbranch = ODataSet_0.Tables("Table01").Rows(Mcou)(0)
            Mkind = ODataSet_0.Tables("Table01").Rows(Mcou)(1)
            Mitemname = ODataSet_0.Tables("Table01").Rows(Mcou)(2)
            ' 呼叫副程序，找出分公司及分類所在的節點（傳遞分公司及分類兩個參數）
            FindLevel_1(TreeView1.Nodes(0), Mbranch, Mkind)
            ' 在選定項目的同一層節點加入新項目（書名）
            TreeView1.SelectedNode.Nodes.Add(New TreeNode(Mitemname))
        Next
        ' 重新排序來源資料
        O_DataView.Sort = "F1 ASC,F2 ASC"
        DataGridView1.Refresh()
        ' 展開樹狀檢視控制項
        TreeView1.Indent = 20
        TreeView1.ItemHeight = 30
        TreeView1.ExpandAll()
        TreeView1.SelectedNode = TreeView1.Nodes(0)

        ' 本程序使用多個資料檢視表 ，故須將本資料檢視表放在最後一個處理，否則會受影響
        ' 將來源資料存入 O_DV 資料檢視表 ，供TreeView1_AfterSelect 事件程序使用
        O_DV = ODataSet_0.Tables("Table01").DefaultView
        O_DV.Sort = "F1 ASC,F3 ASC"

    End Sub

    ' 判斷每一層級的節點之文字是否與新增項目之類別相同，若相同，則選定該項目，以便後續程式在選定的節點加入新項目
    ' 使用 For Each 迴圈判斷同一層節點的每一項目文字是否與項目之類別相同
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub CheckNode(TempNode As TreeNode, ByVal Mcheck As String)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Mcheck Then
                TreeView1.SelectedNode = O_node
                Exit Sub
            End If
            If TempNode.Nodes.Count > 0 Then CheckNode(O_node, Mcheck)
        Next
    End Sub

    ' 副程序_找出『分公司』
    ' 若節點名稱與分公司相同，則呼叫分類副程序，並傳遞該節點（包括其下層節點）作為副程序之參數
    Private Sub FindLevel_1(TempNode As TreeNode, ByVal Temp_Branch As String, ByVal Temp_kind As String)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Temp_Branch Then
                FindLevel_2(O_node, Temp_kind)
            End If
        Next
    End Sub

    ' 副程序_找出『分類』
    ' 若節點名稱與分類相同，則選定該節點
    Private Sub FindLevel_2(TempNode2 As TreeNode, ByVal M_kind As String)
        For Each O_node As TreeNode In TempNode2.Nodes
            If O_node.Text = M_kind Then
                TreeView1.SelectedNode = O_node
                Exit Sub
            End If
        Next
    End Sub

    ' 離開
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

    ' 關閉樹狀檢視控制項
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TreeView1.CollapseAll()
    End Sub

    ' 展開樹狀檢視控制項
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TreeView1.ExpandAll()
    End Sub

    ' TreeView 選取之後的事件程序
    ' 將 User 所敲選項目的相關欄位資料顯示於文字盒
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If DataGridView1.Columns.Count = 0 Then
            Exit Sub
        End If
        If TreeView1.Nodes(0).Text = "圖書庫存統計" Then
            ' 顯示圖書庫存資料
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            ' 將 User 所敲選節點的層級存入變數 McurrentLevel
            Dim McurrentLevel As Integer = TreeView1.SelectedNode.Level
            Dim Mitemname As String = ""
            Dim Mbranch As String = ""
            ' 若 User 所敲選節點的層級為 3（敲選書名），則將其父父節點之文字（分公司）存入變數 Mbranch，將 User 所敲選節點的文字存入變數 Mitemname ，以便作為 資料檢視表的 FindRows 方法之參數
            ' 因為每一筆資料的分公司及書名是唯一的，故下列程序以分公司及書名決定  User 所敲選的資料是哪一筆，
            ' 若 User 所敲選節點的層級不是 3，則不予判斷
            If McurrentLevel = 3 Then
                Mbranch = TreeView1.SelectedNode.Parent.Parent.Text
                Mitemname = TreeView1.SelectedNode.Text
                Dim A_Match() As DataRowView = O_DV.FindRows({Mbranch, Mitemname})
                ' 使用 For each 逐筆處理資料列檢視，並將各欄資料顯示於文字盒
                Dim O_Row As DataRowView
                For Each O_Row In A_Match
                    TextBox1.Text = O_Row.Item(0)
                    TextBox2.Text = O_Row.Item(1)
                    TextBox3.Text = O_Row.Item(2)
                    TextBox4.Text = O_Row.Item(3)
                Next
            Else
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
            End If
        Else
            ' 顯示工單資料
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ' 使用資料表的 Select 方法找出合於條件的資料
            Dim Mwkno As String = TreeView1.SelectedNode.Text
            Dim Mexpression As String = "OrderNo='" + Mwkno + "'"
            Dim A_match() As DataRow
            A_match = O_dtable_1.Select(Mexpression)
            For Each O_Row In A_match
                TextBox5.Text = O_Row(0)
                If IsDBNull(O_Row(1)) = False Then
                    TextBox6.Text = O_Row(1)
                Else
                    TextBox6.Text = ""
                End If
                TextBox7.Text = O_Row(2)
                If IsDBNull(O_Row(3)) = False Then
                    TextBox8.Text = O_Row(3)
                Else
                    TextBox8.Text = ""
                End If
                TextBox9.Text = O_Row(5)
                TextBox10.Text = O_Row(6)
            Next
        End If
    End Sub

    ' 建立樹狀檢視範例 3
    Private Sub B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click
        Dim MpackageNo As String = T_PackageNo.Text
        If MpackageNo = "" Then
            MsgBox("請先敲選工作包編號！", 0 + 16, "Error")
            T_PackageNo.Focus()
            Exit Sub
        End If

        ' 第一段，將 User 指定條件的資料讀出 **************************************************************************************
        ' 連結資料庫
        Dim MDATANAME As String = "APPDATA\WorkOrder.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
        Dim O_conn_1 As New OleDbConnection(MSTRconn_1)
        O_conn_1.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_1 As String = "Select * From WkList where packageno='" + MpackageNo + "'"

        ' 建立命令物件 O_cmd_01
        Dim O_cmd_1 As New OleDbCommand(Mstr_com_1, O_conn_1)

        ' 建立轉接器物件 O_adp_01
        Dim O_adp_1 As New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_1.SelectCommand = O_cmd_1

        ' 建立資料集物件 O_dset_01
        Dim O_dset_1 = New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料集
        ' Fill 方法 之括號內有兩個參數，前者為資料集的名稱，後者為資料表的名稱
        O_adp_1.Fill(O_dset_1, "DATA01")

        ' 將資料集中的第一個資料表存入 datatable
        O_dtable_1 = New DataTable
        O_dtable_1 = O_dset_1.Tables("DATA01")

        '  先清除前次的查詢結果，再設定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = O_dset_1.Tables("DATA01")

        ' 計算總筆數
        MTotalRecordNo = O_dset_1.Tables("DATA01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數：  " + MTotalRecordNo.ToString

        ' 關閉資料處理物件
        O_cmd_1.Dispose()
        O_adp_1.Dispose()
        O_conn_1.Close()
        O_conn_1.Dispose()

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "工單編號"
            .Columns(1).HeaderText = "上層工單"
            .Columns(2).HeaderText = "工包編號"
            .Columns(3).HeaderText = "主工單"
            .Columns(4).HeaderText = "發工日期"
            .Columns(5).HeaderText = "器材編號"
            .Columns(6).HeaderText = "器材名稱"
            .Columns(7).HeaderText = "工作類別"
        End With
        ' 欄位格式化
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 第二段，建立根節點及第一層節點 **************************************************************************************

        ' 為暫用資料表 O_dtable_1 新增檢查欄 chk，並給予預設值 N，以省去檢查 Null 的麻煩
        Dim O_col As New DataColumn
        O_col.DataType = System.Type.GetType("System.String")
        With O_col
            .Caption = "chk"
            .ColumnName = "chk"
            .AllowDBNull = False
            .ReadOnly = False
            .Unique = False
            .DefaultValue = "N"
        End With
        O_dtable_1.Columns.Add(O_col)

        ' 清除原有樹狀檢視控制項的內容
        TreeView1.Nodes.Clear()

        ' 加入根節點
        TreeView1.Nodes.Add(MpackageNo)

        ' 檢查第4欄 MasterNo，若為 Y，則為主工單（已列入根節點），需在 chk 欄註記，已註記者，無須加入新節點
        Dim Mstop As Integer = O_dtable_1.Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            If IsDBNull(O_dtable_1.Rows(Mcou)(3)) = True Then
                Continue For
            Else
                If O_dtable_1.Rows(Mcou)(3) = "Y" Then
                    O_dtable_1.Rows(Mcou)(8) = "Y"
                End If
            End If
        Next

        ' 使用 For 迴圈建立第一層節點
        Mstop = O_dtable_1.Rows.Count - 1
        Dim Mnewnode As String = ""
        TreeView1.SelectedNode = TreeView1.Nodes(0)
        For Mcou = 0 To Mstop Step 1
            Mnewnode = O_dtable_1.Rows(Mcou)(0)
            ' 已註記者，不再處理
            If O_dtable_1.Rows(Mcou)(8) = "Y" = True Then
                Continue For
            Else
                ' 若第二欄（TopNo 上層工號）與 MpackageNo 工包號相同，則列入第一層節點，並在 chk 欄註記，
                If O_dtable_1.Rows(Mcou)(1) = MpackageNo Then
                    TreeView1.SelectedNode.Nodes.Add(New TreeNode(Mnewnode))
                    O_dtable_1.Rows(Mcou)(8) = "Y"
                End If
            End If
        Next

        ' 第三段，呼叫副程序，建立下層節點 **************************************************************************************
        SubNewNode()
        TreeView1.Indent = 20
        TreeView1.ItemHeight = 28
        TreeView1.ExpandAll()
        TreeView1.SelectedNode = TreeView1.Nodes(0)
        MsgBox("建構完成！", 0 + 64, "OK")
    End Sub

    ' 建立下層節點
    Private Sub SubNewNode()
        ' 使用資料表的 Compute 方法計算 chk 欄為 N 者（尚未加入節點者），若 N 為 0，則結束本程序，否則遞迴呼叫
        Dim MtotalN As Integer = O_dtable_1.Compute("Count(chk)", "chk='N'")
        If MtotalN = 0 Then
            Exit Sub
        End If
        TreeView1.SelectedNode = Nothing
        Dim Mstop As Integer = O_dtable_1.Rows.Count - 1
        Dim Mtopno As String = ""
        Dim Mnewnode As String = ""
        For Mcou = 0 To Mstop Step 1
            ' 已註記者，不再處理
            If O_dtable_1.Rows(Mcou)(8) = "Y" = True Then
                Continue For
            Else
                ' 取出第一欄資料（工單編號）存入變數 Mnewnode，以便後續程式加入新節點， 取出第二欄資料（上層工單）存入變數 Mtopno，以供後續程式判斷
                Mnewnode = O_dtable_1.Rows(Mcou)(0)
                Mtopno = O_dtable_1.Rows(Mcou)(1)
                ' 使用遞迴呼叫程序，判斷每一層級的節點文字是否與 TopNo 上層工號相同，
                ' 括號內有 4 個參數, 第1個為根節點, 第2個為上層工單之編號, 第3個為工單編號, 第4個為記錄數
                FindNode(TreeView1.Nodes(0), Mtopno, Mnewnode, Mcou)
            End If
        Next
        ' 重複執行本程序直到每一筆資料都處理完畢（chk 欄為Y）
        SubNewNode()
    End Sub

    ' 判斷每一層級的節點之文字是否與 TopNo 上層工號相同，若相同，則加入新節點，資料表  O_dtable_1 中的該筆資料的 chk 欄註記為 Y
    ' 本程序為遞迴呼叫程序，所謂遞迴 Recursion 就是一個 Procedure 或 Function 呼叫自己本身
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub FindNode(TempNode As TreeNode, ByVal Temp_TopNo As String, ByVal Temp_NewNode As String, ByVal Temp_RecordNo As Integer)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Temp_TopNo Then
                O_node.Nodes.Add(New TreeNode(Temp_NewNode))
                O_dtable_1.Rows(Temp_RecordNo)(8) = "Y"
                Exit Sub
            End If
            FindNode(O_node, Temp_TopNo, Temp_NewNode, Temp_RecordNo)
        Next
    End Sub

End Class