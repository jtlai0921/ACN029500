Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class F_EXCEL01

    ' 宣告 ODataSet_1 資料集，供不同程序使用
    Public ODataSet_1 As DataSet = New DataSet
    ' 宣告 MTotalRecordNo 變數，用以儲存 DataGridView 的記錄數
    Public MTotalRecordNo As Int32
    ' 宣告 MExcel_Ver 變數，用以儲存 Excel 的版本編號
    Public MExcel_Ver As Integer

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' ***************************************************************************************************************************************************
    ' 使用 ADO 匯入 Excel 檔的工作表（ 方法一），匯入已知檔案的某一張工作表
    ' 先將工作表的全部都匯入，然後由系統刪除不需要的部分
    Private Sub B_IMPORT01_Click(sender As Object, e As EventArgs) Handles B_IMPORT01.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' Extended Properties=之後的參數要用單引號括起來，否則會出现“找不到可安装的 ISAM”的訊息
        ' HDR=Yes　表示 Excel 表的第一列為欄名，No 则表示第一列不是欄名
        ' IMEX=1; 將文數字混雜的欄位資料視為文字來處理，例如 QTY 欄名為文字 而 HDR=NO，IMEX=1，則該欄之數字會被視為文字來處理，
        ' 若 HDR=Yes，IMEX=1，則該欄之數字會被視為數字來處理，例如 12,345 變成 12345
        ' OLEDB.12 可連結新版及舊版的 Excel，但需安裝 Office 2007（含）以上，OLEDB.4 只能連結舊版的 Excel
        ' Office 版本編號： 2003 → 11 、 2007 → 12 、 2010 → 14 、 2013 → 15
        Dim MFN_0 As String = "APPDATA\水果銷售統計.xlsx"
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

        ' 將筆數顯示於 T_Count 文字盒
        ' Excel 工作表1的 A3 格位有筆數計算公式，故使用 DataTable 的 Rows屬性之列行索引 可讀出該資料
        T_Count.Text = ODataSet_0.Tables("Table01").Rows(2)(0)

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
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_0.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Oconn_0.Close()
        Oconn_0.Dispose()
        ODataAdapter_0.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_0.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        '資料網格控制項格式化
        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "日期"
        End With
        ' 金額欄及日期欄格式化，
        ' 日期時間格式須注意大小寫  "yyyy/MM/dd HH:mm:ss" 為24小時制， "yyyy/MM/dd hh:mm:ss tt" 為12小時制並顯示上下午
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "#,0.00"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            .Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd hh:mm:ss tt"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 方法，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，後者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If
        DataGridView1.Refresh()

        MsgBox("資料已匯入！", 0 + 64, "OK")

    End Sub

    ' 使用 ADO 匯入 Excel 檔的工作表（ 方法二），匯入任一檔案的任一張工作表（由 User 指定，可能為 xls 或 xlsx）
    ' 由 User 選取檔案，程式將其內的全部工作表名稱顯示於下拉式選單，由 User 指定後，再匯入本系統，
    ' 工作表的全部都匯入
    Private Sub B_IMPORT02_Click(sender As Object, e As EventArgs) Handles B_IMPORT02.Click

        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()
        T_RecordNo.Text = ""

        ' 顯示 F_SheetChoice 表單，讓 User 選取檔案及工作表，
        ' 此處需使用 ShowDialog 將 F_SheetChoice 表單設為強制回應對話方塊，以便不執行其後的程式碼，直到對話方塊關閉
        ' 先隱藏本表單，以防 User 誤敲
        Me.Visible = False
        F_SheetChoice.ShowDialog()

        '此處取用表單的 Tag 無效（慢半拍），必須在表單的 VisibleChanged 事件中取用
        'T_SheetName.Text = F_SheetChoice.Tag

        ' 計算副檔名的長度，並存入變數 MLenExt
        ' 以長度來區分 Excel 種類，以便決定適當的 Provider
        ' 若 User 在 F_SheetChoice 表單敲放棄，則離開本程序
        Dim MCheckString As String = Strings.Trim(T_FileName.Text)
        If MCheckString = "" Then
            Me.Visible = True
            Me.TopMost = True
            Exit Sub
        End If
        Dim MTotallen As Integer = Strings.Len(MCheckString)
        Dim MLenExt As Integer = MTotallen - Strings.InStrRev(MCheckString, ".") + 1

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
        ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
        ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
        Dim MFN_1 As String = T_FileName.Text
        Dim Mstrconn_1 As String = ""
        If MLenExt >= 5 Then
            Mstrconn_1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
        Else
            Mstrconn_1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"
        End If

        ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
        Dim Oconn_1 As New OleDbConnection(Mstrconn_1)
        Oconn_1.Open()

        ' 顯示等待訊息 ***********************************************************************************
        F_wait.Show()

        ' 設定 SQL 字串，供資料轉接器使用
        Dim Msqlstr_1 As String = "Select * From [" + T_SheetName.Text + "]"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
        ' 無需使用 OleDbCommand 物件
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ' 因為 ODataSet_1 資料集使用 Public 宣告（不同程序會使用，故不能使用 Dim 宣告），故本程序結束後仍存在，
        ' 當第二次使用本程序時，Fill 方法會將讀出的資料附加於原資料的末尾（前次資料仍存在），故 Fill 之前必須先移除該資料表，
        ' 移除該資料表的方法有兩種，使用 Tables.Clear 方法將資料集內所有的資料表都清除，例如 ODataSet_1.Tables.Clear() ，
        ' 第二種方法是使用 Remove 方法移除特定資料表，但移除前必須先使用 CanRemove 方法偵測該料表是否可移除，否則在資料表產生之前使用 Remove 會發生錯誤（第一次使用 Fill 方法才會產生資料表），
        ' 亦可使用 Clear 方法清除資料表的內容，但行列都須清除，範例如下
        ' ODataSet_1.Tables.Clear()
        Dim O_RemoveTable As DataTable = ODataSet_1.Tables("Table01")
        If ODataSet_1.Tables.CanRemove(O_RemoveTable) Then
            ODataSet_1.Tables.Remove(O_RemoveTable)
            'ODataSet_1.Tables("Table01").Rows.Clear()
            'ODataSet_1.Tables("Table01").Columns.Clear()
        End If
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Oconn_1.Close()
        Oconn_1.Dispose()
        ODataAdapter_1.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        F_wait.Hide()

        ' 在資料網格控制項中增加核取清單方塊欄 ，供 User 敲選不需要的資料列，程式再據以刪除，
        ' 其方法是先根據  DataGridViewCheckBoxColumn 類別建立新物件（核取清單方塊欄），本例取名 O_ChkBox，
        ' 然後再使用 DataGridView 的 Columns.Insert 方法將新增欄位加入資料網格控制項，括號內兩個參數，前者為行號，後者為新增的欄位物件，
        ' 新增欄位的特徵可用下列屬性設定：
        ' FlatStyle 核取方塊儲存格的平面樣式外觀
        ' HeaderText 欄位標題
        ' Name 欄位名稱
        '.ValueType 資料型別
        '.FalseValue 未核取之值
        '.TrueValue 已核取之值
        ' IndeterminateValue 不確定之值
        ' ThreeState 是否允許三種狀態
        ' 後續判斷核取清單方塊欄是否已核取的程式必須與此處的設定一致，若此處設為布林值，則後續 Value 亦需為布林值，請參考 B_Remove_Click 事件程序
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

        Dim MStop As Integer = DataGridView1.Columns.Count - 1
        DataGridView1.ReadOnly = False
        For Mcou = 1 To MStop Step 1
            DataGridView1.Columns(Mcou).ReadOnly = True
        Next

        Me.Visible = True
        Me.TopMost = False
        MsgBox("資料已匯入！", 0 + 64, "OK")
        Me.TopMost = True

    End Sub

    ' 本表單的可見變動事件，將 User 所敲選的項目 置入 T_FileName 及 T_SheetName 文字盒
    Private Sub F_Input_1_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        ' T_SheetName.Text = F_SheetChoice.Tag
        T_FileName.Text = F_SheetChoice.ASendList(0)
        T_SheetName.Text = F_SheetChoice.ASendList(1)
    End Sub

    ' 移除 DataGridView 中被 User 勾選的項目
    Private Sub B_Remove_Click(sender As Object, e As EventArgs) Handles B_Remove.Click
        ' 先檢查 DataGridView 是否有資料可移除 ，若非由『匯入 2』產生的資料也不能使用本程序
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可移除！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If
        ' 使用 Information 類別的 TypeName 方法可判斷 DataGridView 第一欄是否為核取清單方塊欄
        ' 若型別非 DataGridViewCheckBoxCell ，則不是由『匯入 2』產生的資料
        If Information.TypeName(DataGridView1.Rows(0).Cells(0)) <> "DataGridViewCheckBoxCell" Then
            MsgBox("Sorry, 第一欄非檢查盒！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If

        ' 第一種方法 **************************************************************************************************************************
        ' 使用 For Each 迴圈逐筆判斷核取清單方塊欄之狀態，若為 Yes 或 True，則刪除資料表中對應的資料列
        ' 根據 DataGridViewRow 類別建立資料列物件，取名 O_row，代表資料網格控制項的某一資料列
        '  根據 DataGridViewCheckBoxCell 類別建立核取清單方塊物件，取名 O_check，
        ' 並於迴圈中將  O_row.Cells("Delete_chk") 指定給 O_check，代表資料網格控制項的某一資料列的核取清單方塊格位，
        ' 判斷核取清單方塊格位的狀態需使用 Value 屬性，不能使用 If O_check.TrueValue = True Then，因為 TrueValue 屬性是核取時系統給予之值，而非 User 核取與否
        ' 陣列 Adelete 儲存需要刪除（已核取）資料列的索引（列號），以供後續程式據以刪除資料表中相同列號的資料，
        ' 陣列大小由 DataGridView 的資料數決定，後續再使用陣列的 Resize 方法調整大小（刪除無資料的元素），以便加快刪除速度
        ' 不能使用 Array.Clear 方法，Clear 只清除陣列值，未移除陣列元素
        ' 陣列已宣告但無元素，可用 Nothing 判斷
        Dim O_row As DataGridViewRow
        Dim O_check As DataGridViewCheckBoxCell
        Dim Adelete(MTotalRecordNo) As Integer
        Dim MDeleteNo As Integer = 0
        For Each O_row In DataGridView1.Rows
            O_check = O_row.Cells("Delete_chk")
            'If O_check.Value = True Then
            If O_check.Value = "Yes" Then
                Adelete(MDeleteNo) = O_row.Index
                MDeleteNo = MDeleteNo + 1
            End If
        Next
        Array.Resize(Adelete, MDeleteNo)

        If Adelete Is Nothing Then
            MsgBox("Sorry, 無資料可移除！" + Chr(13) + Chr(13) + "請先勾選。", 0 + 16, "Error")
            Exit Sub
        Else
            'Dim Mstop As Integer = Adelete.Count - 1
            Dim Mstop As Integer = Adelete.Length - 1
            For Mcou = 0 To Mstop Step 1
                ODataSet_1.Tables("Table01").Rows(Adelete(Mcou)).Delete()
            Next
        End If
        ODataSet_1.Tables("Table01").AcceptChanges()
        DataGridView1.Refresh()

        ' 第二種方法 **************************************************************************************************************************
        ' 逐列判斷 DataGridView 第一行的資料是否為 True，若是，則刪除資料表中對應的資料，
        ' 必須反向判斷（由最後一筆逐漸往前判斷），否則執行過半時，會因列號大於 DataGridView 的總筆數而發生錯誤（DataGridView 的總筆數會因 Delete 而逐漸減少）
        ' 資料網格控制項的格位可由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，後者為列，切莫顛倒），
        ' 使用 AcceptChanges 方法 ，才能實際移除資料表中的資料
        'Dim MTotalRecords As Int32 = DataGridView1.Rows.Count
        'For Mcou = MTotalRecords - 1 To 0 Step -1
        '   If DataGridView1.Rows(Mcou).Cells(0).Value = True Then
        'If DataGridView1(0, Mcou).Value = True Then
        'ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
        'End If
        'Next
        'ODataSet_1.Tables("Table01").AcceptChanges()
        'DataGridView1.Refresh()

        ' 計算總筆數，顯示記錄數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        Dim Mrowno As Int32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

    End Sub

    ' DataGridView 選取變動事件
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As Int32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString
    End Sub

    ' 核取清單方塊欄全部勾選
    Private Sub B_SelectALL_Click(sender As Object, e As EventArgs) Handles B_SelectALL.Click
        ' 先檢查 DataGridView 是否有資料可勾選 ，若非由『匯入 2』產生的資料也不能使用本程序
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可勾選！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If
        ' 使用 Information 類別的 TypeName 方法可判斷 DataGridView 第一欄是否為核取清單方塊欄
        ' 若型別非 DataGridViewCheckBoxCell ，則不是由『匯入 2』產生的資料
        If Information.TypeName(DataGridView1.Rows(0).Cells(0)) <> "DataGridViewCheckBoxCell" Then
            MsgBox("Sorry, 第一欄非檢查盒！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If

        Dim O_row As DataGridViewRow
        Dim O_check As DataGridViewCheckBoxCell
        Dim Adelete(MTotalRecordNo) As Integer
        Dim MDeleteNo As Integer = 0
        For Each O_row In DataGridView1.Rows
            O_check = O_row.Cells("Delete_chk")
            'O_check.Value = True
            O_check.Value = "Yes"
        Next
    End Sub

    ' 核取清單方塊欄全部取消勾選
    Private Sub B_SelectNone_Click(sender As Object, e As EventArgs) Handles B_SelectNone.Click
        ' 先檢查 DataGridView 是否有資料可勾選 ，若非由『匯入 2』產生的資料也不能使用本程序
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可勾選！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If
        ' 使用 Information 類別的 TypeName 方法可判斷 DataGridView 第一欄是否為核取清單方塊欄
        ' 若型別非 DataGridViewCheckBoxCell ，則不是由『匯入 2』產生的資料
        If Information.TypeName(DataGridView1.Rows(0).Cells(0)) <> "DataGridViewCheckBoxCell" Then
            MsgBox("Sorry, 第一欄非檢查盒！" + Chr(13) + Chr(13) + "請先敲『匯入 2』", 0 + 16, "Error")
            Exit Sub
        End If

        Dim O_row As DataGridViewRow
        Dim O_check As DataGridViewCheckBoxCell
        Dim Adelete(MTotalRecordNo) As Integer
        Dim MDeleteNo As Integer = 0
        For Each O_row In DataGridView1.Rows
            O_check = O_row.Cells("Delete_chk")
            'O_check.Value = False
            O_check.Value = "No"
        Next
    End Sub

    ' 使用 COM 物件匯入 Excel 工作表（來源檔不能開啟）
    Private Sub B_IMPORT03_Click(sender As Object, e As EventArgs) Handles B_IMPORT03.Click

        ' 第一段 ********************************************************************************************************
        ' 建立資料表，以便儲存從 Excel 檔讀取的資料
        ' 依據 DataTable 類別建立資料表物件，括號內為資料表的名稱，
        ' CaseSensitive 設定字串比較是否區分大小寫、MinimumCapacity 設定初始的資料列數目
        Dim O_TempTable As DataTable = New DataTable("TempTable01")
        O_TempTable.CaseSensitive = False
        O_TempTable.MinimumCapacity = 1

        ' 使用 Add 方法加入欄位，括號內為欄位名稱及資料型態
        ' 使用 Type 類別的 GetType 方法可設定資料型別 System.Byte[]
        ' .NET Framework 基本資料型別: Boolean、Byte、Char、DateTime、Decimal、Double、Guid、Int16、Int32、Int64、SByte、Single、String、TimeSpan、UInt16、UInt32、UInt64 
        ' 沒有 System.Binary 這個型別，二進位圖片資料須使用 System.Byte[]，中括號不能省略
        O_TempTable.Columns.Add("itemcode", System.Type.GetType("System.String"))
        O_TempTable.Columns.Add("itemname", System.Type.GetType("System.String"))
        O_TempTable.Columns.Add("price", System.Type.GetType("System.Int32"))

        ' 設定欄位屬性
        O_TempTable.Columns("itemcode").AllowDBNull = False

        ' 第二段 ********************************************************************************************************
        ' 啟動 Excel 應用程式，並宣告其物件名稱為 OLEAPP
        Dim OLEAPP As Object = CreateObject("Excel.Application")
        ' 關閉可見
        OLEAPP.Visible = False
        ' 關閉警告視窗
        OLEAPP.DisplayAlerts = False

        ' 使用 Workbooks.Open 方法開啟活頁簿物件（取名 Mybook），括號內為欲開啟的檔案及其路徑
        ' 先偵測來源檔之檔名及路徑，並存入變數 MSourceFile
        Dim MSourceDir As String = ""
        MSourceDir = Directory.GetCurrentDirectory() + "\APPDATA\"
        Dim MSourceFile As String = MSourceDir + "範例A_銷售基本檔.xls"
        Dim Mybook As Object = OLEAPP.Workbooks.Open(MSourceFile)

        ' 因為活頁簿內有多張工作表，所以我們需使用 Activate 方法指定某一張工作表為作用中工作表（註：作用中工作表為程式處理的對象），
        ' 並將其命名為 MySheet，以利後續之處理。
        ' 開啟第一張工作表(括號內可指定工作表索引或工作表名稱)
        ' Activate 方法可指定作用工作表
        'Dim MySheet As Object = Mybook.sheets(1)
        Dim MySheet As Object = Mybook.Worksheets("Sheet1")
        MySheet.Activate()

        ' 讀取第一張工作表的全部資料（從 A2 起），並存入資料表
        ' 使用 Do Loop 無限迴圈逐列讀出 Excel 工作表的資料，直到關鍵欄（本例為第一欄產品編號）無資料為止（使用 Nothing 判斷）
        ' MySheet.Cells( , ).Value 屬性可讀或設定取 Excel 工作表某一格位的資料
        ' 變數 MRowNo 控制列號，Excel 工作表的欄列編號均由 1 起算
        ' O_NewRow 為資料暫存的列物件，該物件使用 DataTable 的 NewRow 方法產生
        ' Excel 工作表的某一列資料置入 O_NewRow 暫存列物件之後，必須使用 DataTable 的 Rows.Add 方法將其併入 O_TempTable 資料表
        ' 最後使用 AcceptChanges 方法 認可資料列所作之變更
        Dim O_NewRow As DataRow
        Dim MRowNo As Int32 = 2
        Do
            If MySheet.Cells(MRowNo, 1).Value = Nothing Then
                Exit Do
            Else
                O_NewRow = O_TempTable.NewRow()
                O_NewRow("itemcode") = MySheet.Cells(MRowNo, 1).Value
                O_NewRow("itemname") = MySheet.Cells(MRowNo, 2).Value
                O_NewRow("price") = MySheet.Cells(MRowNo, 3).Value
                O_TempTable.Rows.Add(O_NewRow)
                MRowNo = MRowNo + 1
            End If
        Loop
        O_TempTable.AcceptChanges()

        ' 將 O_TempTable 資料表指定給資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 關閉試算表及 OLE 物件
        MySheet = Nothing
        Mybook = Nothing
        OLEAPP.ActiveWorkbook.Close()
        OLEAPP.Workbooks.Close()
        OLEAPP.Quit()

        ' 資料網格控制項格式化
        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "品名"
            .Columns(2).HeaderText = "單價"
        End With
        ' 數字欄格式化，
        With DataGridView1
            .Columns(2).DefaultCellStyle.Format = "#,0"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = O_TempTable.Rows.Count
        If MTotalRecordNo > 0 Then
            DataGridView1(0, 0).Selected = True
        End If
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        MsgBox("資料已匯入！", 0 + 64, "OK")

    End Sub

    Private Sub F_EXCEL01_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 載入本表單時，讀出 SQL Server 的登入資訊，並存入公用變數，以利後續各個程序使用
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 設定購入日期的日曆控制項之預設值為當天
        T_purdate.Value = DateTime.Now.Date

        ' 載入本表單時，偵測 Excel 版本編號，再存入公用變數，供後續程式使用，以便決定使用哪一種版本的 OLEDB 提供者
        ' Office 版本編號： 2003 → 11 、 2007 → 12 、 2010 → 14 、 2013 → 15
        ' 偵測是否已安裝 Excel，若未安裝則會發生錯誤，程式改執行 ErrorHandler_01 段
        ' 偵測 Excel 版本編號以便決定使用哪一種版本的 OLEDB的方式有缺點，因為如果同時安裝新舊版，則前述指令會傳回舊版編號，後續程式會使用 OLEDB.4.0，故無法讀取新版 XLSX 檔
        ' 故改用 User 所選檔案的副檔名來判斷，變數 MExcel_Ver 後續程式無需再使用
        On Error GoTo ErrorHandler_01
        Dim OLEAPP As Object = CreateObject("Excel.Application")
        MExcel_Ver = Val(OLEAPP.Version)
        OLEAPP.Quit()
        Exit Sub

ErrorHandler_01:
        MsgBox("Sorry, 您未安裝 Excel！" + (Chr(13) & Chr(10)) + "請先安裝，再使用本系統", 0 + 16, "Error")
        Environment.Exit(0)
    End Sub

    ' 使用 ADO 將資料網格控制項的資料匯出為 Excel 檔
    Private Sub B_EXPORT1_Click(sender As Object, e As EventArgs) Handles B_EXPORT1.Click
        ' 先使用 CreateDirectory 方法建立資料夾 D:\TEST02，以便儲存匯出的 Excel 檔
        ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在
        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If

        ' 先以 OleDbConnection 物件打通連接管道，然後以 OleDbCommand 物件下達 SQL 指令，括號之參數內為SQL 指令及連接物件，
        ' 最後執行 ExecuteNonQuery 方法即可建立 Excel 檔
        ' 本例建立活頁簿 Book_1.xls，若已存在，可插入不同名稱的工作表，但不能 Create 相同名稱的工作表，
        ' 連接字串中不能使用 IMEX=1，讀取已存在的檔案才能使用
        ' Create Table 之後接工作表名稱，例如 Sheet1，工作表名稱之後必須有資料，不能空白，欄名以中括號括住，其後為資料型別，欄名之間以逗號分隔
        ' Create Table Sheet1 ([測試資料表] Text(6)) 或 Create Table 工作表1 ([測試資料表] Text(6)) 都被允許
        ' Insert Into 指令可插入資料，其後接工作表名稱，再以 Values 指定插入之值，插入值與欄位必須對應
        ' 範例中插入欄名使用 OleDbCommand 建構函式，建立新的命令物件 Ocmd_0 的同時，進行初始化（下達 SQL 指令並打通連接管道），一個陳述式就搞定，簡化程式碼，
        ' 插入資料則使用了不同方式（不用建構函式，而用相關屬性），範例中使用 OleDbCommand 物件的 Connection 屬性及 CommandText 屬性，分別設定連接管道及下達 SQL 指令，
        ' 這種方式可讓命令物件 Ocmd_0 重複使用，以便執行不同的 SQL 指令
        ' 若檔案 D:\TEST02\Book_01.xls 已存在，則刪除之，以便本程序可重複使用
        If System.IO.File.Exists("D:\TEST02\Book_01.xls") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TEST02\Book_01.xls")
        End If

        ' 設定連接管道
        Dim MFN_0 As String = "D:\TEST02\Book_01.xls"
        Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
        Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
        Oconn_0.Open()

        ' 插入欄名
        Dim Msqlstr_0 As String = "Create Table Sheet1 ([ItemCode] Text(6), [ItemName] Text(10), [Qty] Integer, [Price] double, [DataTime] datetime)"
        Dim Ocmd_0 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_0)
        Ocmd_0.ExecuteNonQuery()

        ' 插入第一筆資料
        Dim MSheetName As String = "Sheet1"
        Dim Msqlstr_1 As String
        Msqlstr_1 = "Insert Into [" + MSheetName + "] Values('A00001','西瓜',1,100.5,'2015/03/27')"
        Dim Ocmd_1 As New System.Data.OleDb.OleDbCommand
        Ocmd_1.Connection = Oconn_0
        Ocmd_1.CommandText = Msqlstr_1
        Ocmd_1.ExecuteNonQuery()

        ' 插入第二筆資料
        Msqlstr_1 = "Insert Into [" + MSheetName + "] Values('A00002','鳳梨',2,80.05,'2015/03/28')"
        Ocmd_1.CommandText = Msqlstr_1
        Ocmd_1.ExecuteNonQuery()

        ' 插入第三筆資料
        Dim MItemCode As String = "A00003"
        Dim MItemName As String = "火龍果"
        Dim MQty As Int32 = 3
        Dim MPrice As Double = 36
        Dim MDataTime As DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Msqlstr_1 = "Insert Into [" + MSheetName + "] Values('" + MItemCode + " ','" + MItemName + "'," + MQty.ToString + "," + MPrice.ToString + ",'" + MDataTime + " ')"
        Ocmd_1.CommandText = Msqlstr_1
        Ocmd_1.ExecuteNonQuery()

        ' 關閉相關物件及釋放資源
        Ocmd_0.Dispose()
        Ocmd_1.Dispose()
        Oconn_0.Close()

        MsgBox("資料已匯出至 D:\TEST02\Book_01.xls！", 0 + 64, "OK")

    End Sub

    ' 將 DataGridView 資料網格控制項的資料匯出為 Excel 檔
    Private Sub B_EXPORT2_Click(sender As Object, e As EventArgs) Handles B_EXPORT2.Click
        ' 先檢查 DataGridView 是否有資料可匯出
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可匯出！" + Chr(13) + Chr(13) + "請先敲『匯入 1』", 0 + 16, "Error")
            Exit Sub
        End If
        ' 先檢查 DataGridView 是否為『匯入 1』產生的資料
        If DataGridView1.Columns.Count <> 4 Then
            MsgBox("Sorry, 資料不正確！" + Chr(13) + Chr(13) + "請先敲『匯入 1』", 0 + 16, "Error")
            Exit Sub
        End If

        ' 若資料 D:\TEST02 夾不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If
        ' 若檔案 D:\TEST02\Test_01.xls 已存在，則刪除之，以便本程序可重複使用
        If System.IO.File.Exists("D:\TEST02\Test_01.xls") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TEST02\Test_01.xls")
        End If

        ' 先建立 D:\TEST02\Test_01.xls（只有欄名無資料，欄名與後續的資料必須對應）
        Dim MFN_0 As String = "D:\TEST02\Test_01.xls"
        Dim Mstrconn_0 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_0 + ";Extended Properties='Excel 8.0;HDR=No';"
        Dim Oconn_0 As New System.Data.OleDb.OleDbConnection(Mstrconn_0)
        Oconn_0.Open()

        Dim Msqlstr_0 As String = "Create Table Sheet1 ([品名] Text(6),[數量] Integer,[金額] Double,[日期] Datetime)"
        Dim Ocmd_0 As New System.Data.OleDb.OleDbCommand(Msqlstr_0, Oconn_0)
        Ocmd_0.ExecuteNonQuery()

        Dim MRowNo As Int32 = DataGridView1.Rows.Count - 1
        Dim MItemName As String = ""
        Dim MQty As Int32 = 0
        Dim MAmt As Double = 0
        Dim MDataTime As DateTime
        Dim Msqlstr_1 As String = ""
        Dim MSheetName As String = "Sheet1"
        Dim Ocmd_1 As New System.Data.OleDb.OleDbCommand
        Ocmd_1.Connection = Oconn_0

        ' 使用 For 迴圈逐列將 DataGridView 的資料匯出至 Excel 檔
        ' Insert 指令中無需指定欄名，Values 之後接 @具名參數，以降低 SQL 指令的複雜度
        On Error Resume Next
        For Mcou = 0 To MRowNo Step 1
            MItemName = DataGridView1.Rows(Mcou).Cells(0).Value
            MQty = DataGridView1.Rows(Mcou).Cells(1).Value
            MAmt = DataGridView1.Rows(Mcou).Cells(2).Value
            MDataTime = DataGridView1.Rows(Mcou).Cells(3).Value

            Msqlstr_1 = "Insert Into [" + MSheetName + "] Values(@t1,@t2,@t3,@t4)"
            Ocmd_1.Parameters.Clear()
            Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = MItemName
            Ocmd_1.Parameters.AddWithValue("@t2", DbType.Int32).Value = MQty
            Ocmd_1.Parameters.AddWithValue("@t3", DbType.Double).Value = MAmt
            Ocmd_1.Parameters.AddWithValue("@t4", DbType.DateTime).Value = MDataTime

            Ocmd_1.CommandText = Msqlstr_1
            Ocmd_1.ExecuteNonQuery()
        Next

        ' 關閉相關物件及釋放資源
        Ocmd_0.Dispose()
        Ocmd_1.Dispose()
        Oconn_0.Close()
        MsgBox("資料已匯出至 D:\TEST02\Test_01.xls！", 0 + 64, "OK")

    End Sub

    ' 使用 COM，將 DataGridView 資料網格控制項的資料匯出為 Excel 檔
    ' 從無到有，建立全新的 Excel 檔
    Private Sub B_EXPORT3_Click(sender As Object, e As EventArgs) Handles B_EXPORT3.Click
        ' 先檢查 DataGridView 是否有資料可匯出
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可匯出！" + Chr(13) + Chr(13) + "請先敲『匯入 1』", 0 + 16, "Error")
            Exit Sub
        End If
        ' 先檢查 DataGridView 是否為『匯入 1』產生的資料
        If DataGridView1.Columns.Count <> 4 Then
            MsgBox("Sorry, 資料不正確！" + Chr(13) + Chr(13) + "請先敲『匯入 1』", 0 + 16, "Error")
            Exit Sub
        End If

        ' 若資料夾 D:\TEST02 不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
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
        Dim MItemName As String = ""
        Dim MQty As Int32 = 0
        Dim MAmt As Double = 0
        'Dim MDataTime As DateTime = Nothing
        Dim MDataTime As String = ""

        For Mrow = 0 To MStop Step 1
            If IsDBNull(DataGridView1.Rows(Mrow).Cells(0).Value) = True Then
                MItemName = ""
            Else
                MItemName = DataGridView1.Rows(Mrow).Cells(0).Value
            End If
            If IsDBNull(DataGridView1.Rows(Mrow).Cells(1).Value) = True Then
                MQty = Nothing
            Else
                MQty = DataGridView1.Rows(Mrow).Cells(1).Value
            End If
            If IsDBNull(DataGridView1.Rows(Mrow).Cells(2).Value) = True Then
                MAmt = Nothing
            Else
                MAmt = DataGridView1.Rows(Mrow).Cells(2).Value
            End If
            If IsDBNull(DataGridView1.Rows(Mrow).Cells(3).Value) = True Then
                MDataTime = ""
            Else
                MDataTime = DataGridView1.Rows(Mrow).Cells(3).Value
            End If

            MySheet.Cells(Mrow + 5, 1).Value = MItemName
            MySheet.Cells(Mrow + 5, 2).Value = MQty
            MySheet.Cells(Mrow + 5, 3).Value = MAmt
            MySheet.Cells(Mrow + 5, 4).Value = MDataTime
        Next

        ' 置入標題於 A1 儲存格
        MySheet.Range("A1").Value = "水果銷售統計表"
        ' 置入欄位名稱於第４列
        MySheet.Range("A4").Value = "品名"
        MySheet.Range("B4").Value = "數量"
        MySheet.Range("C4").Value = "金額"
        MySheet.Range("D4").Value = "日期"
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
        OLEAPP.Range("A4:D4").Select()
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
        OLEAPP.Selection.ColumnWidth = 22

        ' 表頭區儲存格底色
        OLEAPP.Range("A1:D3").Select()
        OLEAPP.Selection.Interior.ColorIndex = 2
        
        ' 資料區進行格式化（調整字型大小、字體顏色、儲存格底色及列高等，從第5列開始）
        ' 先偵測及選定範圍，左上角為 A5，根據 A3 公式算出的筆數來判斷右小角的位置，然後使用 Select 方法選定該格位選定，再以 Address 屬性傳回其位址
        Dim MRecordNo As Int32 = MySheet.Range("A3").Value
        OLEAPP.Cells(MRecordNo + 4, 4).Select()
        Dim MAddress As String = OLEAPP.Selection.Address
        Dim MRange As String = "A5:" + MAddress

        OLEAPP.Range(MRange).Select()
        OLEAPP.Selection.RowHeight = 18
        OLEAPP.Selection.Font.Name = "Arial"
        OLEAPP.Selection.Font.FontStyle = "標準"
        OLEAPP.Selection.Font.Size = 11
        OLEAPP.Selection.Interior.ColorIndex = 2

        ' 數字欄格式化，本例為第 2 欄數量（無小數）、第 3 欄金額（小數兩位）
        ' 先偵測及選定範圍
        OLEAPP.Cells(MRecordNo + 4, 2).Select()
        MAddress = OLEAPP.Selection.Address
        MRange = "B5:" + MAddress
        OLEAPP.Range(MRange).Select()
        OLEAPP.Selection.NumberFormatLocal = "#,##0"

        OLEAPP.Cells(MRecordNo + 4, 3).Select()
        MAddress = OLEAPP.Selection.Address
        MRange = "C5:" + MAddress
        OLEAPP.Range(MRange).Select()
        OLEAPP.Selection.NumberFormatLocal = "#,##0.00_ "

        ' 日期格式化、置中，本例為第 4 欄
        OLEAPP.Cells(MRecordNo + 4, 4).Select()
        MAddress = OLEAPP.Selection.Address
        MRange = "D5:" + MAddress
        OLEAPP.Range(MRange).Select()
        OLEAPP.Selection.NumberFormatLocal = "yyyy/mm/dd hh:mm:ss"
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
        MyBook.SaveAs("D:\TEST02\Test_Excel.xls")

        ' 從印表機印出
        Dim Mans As Integer = MsgBox("請確認是否從印表機印出？" + Chr(13) + Chr(13) + "若要列印，請打開印表機電源。", 4 + 32, "請確認")
        If Mans = 6 Then
            OLEAPP.ActiveSheet.PrintOut()
        End If

        ' 關閉相關物件並釋放資源
        MyBook.Close()
        MyBook = Nothing
        MySheet = Nothing
        OLEAPP.Quit()
        MsgBox("資料已匯出 D:\TEST02\Test_Excel.xls！", 0 + 64, "OK")

    End Sub

    ' 自 Access 資料庫 StampCollection.mdb 抓出資料至 DataTable，再匯出為 Excel 檔
    ' 不從 DataGridView 匯出，而從 DataTable 匯出，因前者為文字格式，置入 Excel 以後轉換非常麻煩，
    ' 本範例之方法可自動格式化匯出資料，xls 非常理想，但 xlsx 效果稍差
    Private Sub B_EXPORT4_Click(sender As Object, e As EventArgs) Handles B_EXPORT4.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 若資料 D:\TEST02 夾不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If

        ' 若檔案 D:\TEST02\Test_Stamp.xls 已存在，則刪除之，以便本程序可重複使用
        If System.IO.File.Exists("D:\TEST02\Test_Stamp.xls") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TEST02\Test_Stamp.xls")
        End If

        ' 複製 Excel 檔，以便儲存匯出的資料
        Dim MSourceDir As String = Directory.GetCurrentDirectory() + "\APPDATA\"
        ' 設定來源檔
        Dim MSOUFN As String = MSourceDir + "Test_Stamp_BK.xls"
        ' 設定目的檔
        Dim MDESFN As String = "D:\TEST02\Test_Stamp.xls"
        ' 複製
        My.Computer.FileSystem.CopyFile(MSOUFN, MDESFN)

        ' 第一段，先讀取 Access 檔案至資料表，並顯示於 DataGridView **********************************************************************************
        ' 連結資料庫
        Dim MDATANAME As String = "APPDATA\StampCollection.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
        Dim O_conn_1 As New OleDbConnection(MSTRconn_1)
        O_conn_1.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_1 As String = "Select SNO,COUNTRY,ITEMNAME,TOPICS,QTY,COST,PURDATE from STAMP"

        ' 建立命令物件 O_cmd_01
        Dim O_cmd_1 As New OleDbCommand(Mstr_com_1, O_conn_1)

        ' 建立轉接器物件
        Dim ODataAdapter_1 As New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        ODataAdapter_1.SelectCommand = O_cmd_1

        ' 建立資料集物件
        Dim ODataSet_1 = New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料集
        ' Fill 方法 之括號內有兩個參數，前者為資料集的名稱，後者為資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        '  先清除前次的查詢結果，再設定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing

        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        ' 關閉資料處理物件並釋放資源
        O_cmd_1.Dispose()
        ODataAdapter_1.Dispose()
        O_conn_1.Close()
        O_conn_1.Dispose()

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "購入價格"
            .Columns(6).HeaderText = "購入時間"
        End With
        ' 金額欄及日期欄格式化
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "#,0.00"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 第二段，將 DataTable 的資料匯出為 Excel 檔 **********************************************************************************

        ' 本程序使用兩個資料轉接器，ODataAdapter_1 控制 Access 檔，ODataAdapter_2 控制 Excel 檔，
        ' 但只使用一個資料集 ODataSet_1，資料集內有兩個資料表，Table01 取自 Access 檔，Table02 結構取自 Excel，但資料則取自 Table01，
        ' 資料轉接器的 Update 方法可調節資料集（記憶體）與資料庫（硬碟）之間的異動，而本例的資料轉接器 ODataAdapter_2 就是負責 Table02 與 Excel 檔（取名 Test_Stamp.xls）之間的異動，
        ' 本程序要將資料表中的資料存入 Excel 檔，故使用 Insert 指令，插入值使用具名參數搭配資料轉接器的 InsertCommand.Parameters.Add 方法來指定，
        ' 舉例來說，ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4).SourceColumn = "編號"，是指出參數值的來源為『編號』欄（註：以本例而言就是 Table02 的『編號』欄），
        ' SourceColumn 屬性可指定參數值的來源欄，Add 括號內有兩個或三個參數，分別為具名參數，資料型別，資料型別的附加指定（例如文字長度），
        ' 亦可省略 SourceColumn 屬性，而將來源欄置入 Add 括號內，例如 ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4, "編號")

        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table02") 資料表的結構
        Dim MFN_2 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_2 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 建立無資料的資料轉接器與資料集
        Dim Msqlstr_2 As String = "Select * From [Sheet1$] Where 編號='Z'"
        Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
        ODataAdapter_2.Fill(ODataSet_1, "Table02")

        ' 使用 For 迴圈逐筆將 Table01 的資料存入 Table02，這兩個資料表的結構略有不同，Table01 為英文欄名，Table02 為中文欄名
        ' 迴圈內先使用 NewRow 方法根據 Table02 建立一個資料列物件 O_NewRow，以便暫存 Table01 的某列資料，
        ' 隨後再使用 Rows.Add 方法將資料列物件 O_NewRow 併入 Table02，
        ' 請注意  NewRow 及 Rows.Add 兩列指令都需置於回圈內，否則會發生錯誤
        Dim O_NewRow As DataRow
        Dim Mstop As Integer = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            O_NewRow = ODataSet_1.Tables("Table02").NewRow()
            O_NewRow("編號") = ODataSet_1.Tables("Table01").Rows(Mcou)(0)
            O_NewRow("國家") = ODataSet_1.Tables("Table01").Rows(Mcou)(1)
            O_NewRow("郵票名稱") = ODataSet_1.Tables("Table01").Rows(Mcou)(2)
            O_NewRow("專題類別") = ODataSet_1.Tables("Table01").Rows(Mcou)(3)
            O_NewRow("數量") = ODataSet_1.Tables("Table01").Rows(Mcou)(4)
            O_NewRow("購入價格") = ODataSet_1.Tables("Table01").Rows(Mcou)(5)
            O_NewRow("購入時間") = ODataSet_1.Tables("Table01").Rows(Mcou)(6)
            ODataSet_1.Tables("Table02").Rows.Add(O_NewRow)
        Next

        ' 建立插入指令，並指出插入值之來源為 Table02 的哪一欄（註：Table02 是資料轉接器 ODataAdapter_2 所指名欲調節的資料表，請注意欄名需一致）
        ODataAdapter_2.InsertCommand = New OleDbCommand("Insert Into [Sheet1$] (編號,國家,郵票名稱,專題類別,數量,購入價格,購入時間) Values (@t1,@t2,@t3,@t4,@t5,@6,@t7)", Oconn_2)
        ' ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4, "編號")
        ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4).SourceColumn = "編號"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t2", OleDbType.Char, 10).SourceColumn = "國家"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t3", OleDbType.Char, 30).SourceColumn = "郵票名稱"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t4", OleDbType.Char, 4).SourceColumn = "專題類別"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t5", OleDbType.Integer).SourceColumn = "數量"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t6", OleDbType.Double).SourceColumn = "購入價格"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t7", OleDbType.Date).SourceColumn = "購入時間"

        ' 使用資料轉接器的 Update 方法進行更新
        Dim MAffectedNO As Integer = ODataAdapter_2.Update(ODataSet_1, "Table02")

        ' 關閉資料處理物件並釋放資源
        ODataAdapter_2.Dispose()
        Oconn_2.Close()
        Oconn_2.Dispose()
        MsgBox("資料已存入 D:\TEST02\Test_Stamp.xls！", 0 + 64, "OK")

    End Sub

    ' 自 SQL Server 資料庫 VBSQLDB 的 TEST01 資料表 抓出資料至 DataTable，再匯出為 Excel 檔
    Private Sub B_EXPORT5_Click(sender As Object, e As EventArgs) Handles B_EXPORT5.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 若資料 D:\TEST02 夾不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If

        ' 若檔案 D:\TEST02\Test_03.xlsx 已存在，則刪除之，以便本程序可重複使用
        If System.IO.File.Exists("D:\TEST02\Test_03.xlsx") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TEST02\Test_03.xlsx")
        End If

        ' 複製 Excel 檔，以便儲存匯出的資料
        Dim MSourceDir As String = Directory.GetCurrentDirectory() + "\APPDATA\"
        ' 設定來源檔
        Dim MSOUFN As String = MSourceDir + "Test_03_BK.xlsx"
        ' 設定目的檔
        Dim MDESFN As String = "D:\TEST02\Test_03.xlsx"
        ' 複製
        My.Computer.FileSystem.CopyFile(MSOUFN, MDESFN)

        ' 第一段，先讀取 SQL Server 檔至資料表，並顯示於 DataGridView **********************************************************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select datano,description,qty,price,amt,datatime From TEST01"

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        ODataAdapter_1.Dispose()
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

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "資料編號"
            .Columns(1).HeaderText = "說明"
            .Columns(2).HeaderText = "數量"
            .Columns(3).HeaderText = "單價"
            .Columns(4).HeaderText = "金額"
            .Columns(5).HeaderText = "資料建立時間"
        End With
        ' 金額欄及日期欄格式化，
        ' 日期時間格式須注意大小寫  "yyyy/MM/dd HH:mm:ss" 為24小時制， "yyyy/MM/dd hh:mm:ss tt" 為12小時制並顯示上下午
        With DataGridView1
            .Columns(2).DefaultCellStyle.Format = "#,0"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "#,0.00"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Format = "#,0.00"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            '.Columns(5).DefaultCellStyle.Format = "yyyy/MM/dd hh:mm:ss tt"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 方法，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，後者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If

        ' 第二段，將 DataTable 的資料匯出為 Excel 檔 **********************************************************************************

        ' 本程序使用兩個資料轉接器，ODataAdapter_1 控制 SQL Server 檔，ODataAdapter_2 控制 Excel 檔，
        ' 但只使用一個資料集 ODataSet_1，資料集內有兩個資料表，Table01 取自 SQL Server 檔，Table02 結構取自 Excel，但資料則取自 Table01，
        ' 資料轉接器的 Update 方法可調節資料集（記憶體）與資料庫（硬碟）之間的異動，而本例的資料轉接器 ODataAdapter_2 就是負責 Table02 與 Excel 檔（取名 Test_03.xlsx）之間的異動，
        ' 本程序要將資料表中的資料存入 Excel 檔，故使用 Insert 指令，插入值使用具名參數搭配資料轉接器的 InsertCommand.Parameters.Add 方法來指定，
        ' 舉例來說，ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4).SourceColumn = "編號"，是指出參數值的來源為『編號』欄（註：以本例而言就是 Table02 的『資料編號』欄），
        ' SourceColumn 屬性可指定參數值的來源欄，Add 括號內有兩個或三個參數，分別為具名參數，資料型別，資料型別的附加指定（例如文字長度），
        ' 亦可省略 SourceColumn 屬性，而將來源欄置入 Add 括號內，例如 ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4, "資料編號")

        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table02") 資料表的結構
        Dim MFN_2 As String = "D:\TEST02\Test_03.xlsx"
        Dim Mstrconn_2 As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_2 + ";Extended Properties='Excel 12.0;HDR=Yes';"
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 建立無資料的資料轉接器與資料集
        Dim Msqlstr_2 As String = "Select * From [工作表1$] Where 資料編號='0'"
        Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
        ODataAdapter_2.Fill(ODataSet_1, "Table02")

        ' 使用 For 迴圈逐筆將 Table01 的資料存入 Table02，這兩個資料表的結構略有不同，Table01 為英文欄名，Table02 為中文欄名
        ' 迴圈內先使用 NewRow 方法根據 Table02 建立一個資料列物件 O_NewRow，以便暫存 Table01 的某列資料，
        ' 隨後再使用 Rows.Add 方法將資料列物件 O_NewRow 併入 Table02，
        ' 請注意  NewRow 及 Rows.Add 兩列指令都需置於回圈內，否則會發生錯誤
        Dim O_NewRow As DataRow
        Dim Mstop As Integer = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            O_NewRow = ODataSet_1.Tables("Table02").NewRow()
            O_NewRow("資料編號") = ODataSet_1.Tables("Table01").Rows(Mcou)(0)
            O_NewRow("說明") = ODataSet_1.Tables("Table01").Rows(Mcou)(1)
            O_NewRow("數量") = ODataSet_1.Tables("Table01").Rows(Mcou)(2)
            O_NewRow("單價") = ODataSet_1.Tables("Table01").Rows(Mcou)(3)
            O_NewRow("金額") = ODataSet_1.Tables("Table01").Rows(Mcou)(4)
            O_NewRow("資料建立時間") = ODataSet_1.Tables("Table01").Rows(Mcou)(5)
            ODataSet_1.Tables("Table02").Rows.Add(O_NewRow)
        Next

        ' 建立插入指令，並指出插入值之來源為 Table02 的哪一欄（註：Table02 是資料轉接器 ODataAdapter_2 所指名欲調節的資料表，請注意欄名需一致）
        ODataAdapter_2.InsertCommand = New OleDbCommand("Insert Into [工作表1$] (資料編號,說明,數量,單價,金額,資料建立時間) Values (@t1,@t2,@t3,@t4,@t5,@6)", Oconn_2)
        ' ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4, "編號")
        ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Integer).SourceColumn = "資料編號"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t2", OleDbType.Char, 36).SourceColumn = "說明"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t3", OleDbType.Integer).SourceColumn = "數量"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t4", OleDbType.Double).SourceColumn = "單價"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t5", OleDbType.Double).SourceColumn = "金額"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t6", OleDbType.Date).SourceColumn = "資料建立時間"

        ' 使用資料轉接器的 Update 方法進行更新
        Dim MAffectedNO As Integer = ODataAdapter_2.Update(ODataSet_1, "Table02")

        ' 關閉資料處理物件並釋放資源
        ODataAdapter_2.Dispose()
        Oconn_2.Close()
        Oconn_2.Dispose()
        MsgBox("資料已存入 D:\TEST02\Test_03.xlsx！", 0 + 64, "OK")

    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要清除文字盒的資料嗎？", 4 + 32 + 256, "Confirm")
        If MANS <> 6 Then
            Exit Sub
        End If

        T_sno.Text = ""
        T_country.Text = ""
        T_itemname.Text = ""
        T_topics.Text = ""
        T_qty.Text = ""
        T_cost.Text = ""
        T_purdate.Value = DateTime.Now.Date
    End Sub

    ' 新增資料於 D:\TEST02\Test_Stamp.xls
    Private Sub B_ADD_Click(sender As Object, e As EventArgs) Handles B_ADD.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 檢查檔案 D:\TEST02\Test_Stamp.xls 是否已存在
        If System.IO.File.Exists("D:\TEST02\Test_Stamp.xls") = False Then
            MsgBox("Sorry, 請先執行『轉檔 1』，再執行本程序", 0 + 16, "Error")
            Exit Sub
        End If

        ' 檢查『編號』、『郵票名稱』等必要資料是否已輸入及是否合理
        If Len(Trim(T_sno.Text)) <> 4 Then
            MsgBox("Sorry, 『編號』未輸入或不正確！" + Chr(13) + Chr(13) + "請輸入編號（例如 A099）", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_itemname.Text)) = 0 Then
            MsgBox("Sorry, 『郵票名稱』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_qty.Text)) = 0 Then
            MsgBox("Sorry, 『數量』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_cost.Text)) = 0 Then
            MsgBox("Sorry, 『購入價格』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If IsNumeric(T_qty.Text) = False Then
            MsgBox("Sorry, 『數量』欄必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If
        If IsNumeric(T_cost.Text) = False Then
            MsgBox("Sorry, 『購入價格』欄必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table02") 資料表的結構
        Dim MFN_2 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_2 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 建立資料轉接器與資料集
        Dim ODataSet_1 As DataSet = New DataSet
        Dim Msqlstr_2 As String = "Select * From [Sheet1$]"
        Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
        ODataAdapter_2.Fill(ODataSet_1, "Table02")
        DataGridView1.DataSource = ODataSet_1.Tables("Table02")

        ' 檢查編號是否重複 ****************************************************************************
        ' 使用 DefaultView 屬性建立預設的資料檢視表（此 DataView 資料檢視表物件可儲存從 DataTable 篩選或排序後的資料）
        ' 若使用如下的建構函式，會將 Table02 資料表的全部資料都複製於檢視表
        ' Dim O_DataView As DataView = New DataView(ODataSet_1.Tables("Table02"))
        Dim O_DataView As DataView
        O_DataView = ODataSet_1.Tables("Table02").DefaultView

        ' DataView 檢視表的 RowFilter 屬性篩選出 User 所輸入的編號，若有，則表示編號重複了
        ' 比較值 T_sno.Text 的前後要加單引號
        O_DataView.RowFilter = "編號='" + T_sno.Text + "'"
        If O_DataView.Count >= 1 Then
            MsgBox("Sorry, 『編號』重複了！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            ODataAdapter_2.Dispose()
            Oconn_2.Close()
            Oconn_2.Dispose()
            Exit Sub
        End If

        ' 將 User 輸入資料存入資料列物件 O_NewRow
        ' 若無日期資料，應給予 Null，例如 O_NewRow("購入時間") = DBNull.Value，若使用日曆控制項則無需（必有日期）
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table02").NewRow()
        O_NewRow("編號") = T_sno.Text
        O_NewRow("國家") = T_country.Text
        O_NewRow("郵票名稱") = T_itemname.Text
        O_NewRow("專題類別") = T_topics.Text
        O_NewRow("數量") = Convert.ToInt32(T_qty.Text)
        O_NewRow("購入價格") = Convert.ToDouble(T_cost.Text)
        O_NewRow("購入時間") = T_purdate.Value
        ODataSet_1.Tables("Table02").Rows.Add(O_NewRow)

        ' 建立插入指令，並指出插入值之來源為 Table02 的哪一欄（註：Table02 是資料轉接器 ODataAdapter_2 所指名欲調節的資料表，請注意欄名需一致）
        ODataAdapter_2.InsertCommand = New OleDbCommand("Insert Into [Sheet1$] (編號,國家,郵票名稱,專題類別,數量,購入價格,購入時間) Values (@t1,@t2,@t3,@t4,@t5,@6,@t7)", Oconn_2)
        ' ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4, "編號")
        ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 4).SourceColumn = "編號"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t2", OleDbType.Char, 10).SourceColumn = "國家"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t3", OleDbType.Char, 30).SourceColumn = "郵票名稱"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t4", OleDbType.Char, 4).SourceColumn = "專題類別"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t5", OleDbType.Integer).SourceColumn = "數量"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t6", OleDbType.Double).SourceColumn = "購入價格"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t7", OleDbType.Date).SourceColumn = "購入時間"

        ' 使用資料轉接器的 Update 方法進行更新
        Dim MAffectedNO As Integer = ODataAdapter_2.Update(ODataSet_1, "Table02")

        ' 關閉資料處理物件並釋放資源
        ODataAdapter_2.Dispose()
        Oconn_2.Close()
        Oconn_2.Dispose()

        ' 重新讀取更新後的資料 *************************************************
        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table01") 資料表的結構
        Dim MFN_1 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_1 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_1 As New OleDbConnection(Mstrconn_1)
        Oconn_1.Open()

        ' 在資料集 ODataSet_1 中建立另一資料表，第二列為空白，故不抓取（使用 Null 判斷）
        Dim Msqlstr_1 As String = "Select * From [Sheet1$] Where 編號<>Null"
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "購入價格"
            .Columns(6).HeaderText = "購入時間"
        End With
        ' 金額欄及日期欄格式化
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "#,0.00"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 關閉資料處理物件並釋放資源()
        ODataAdapter_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        MsgBox("D:\TEST02\Test_Stamp.xls 的資料已新增！", 0 + 64, "OK")

    End Sub

    ' 修改 D:\TEST02\Test_Stamp.xls 的資料
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 檢查檔案 D:\TEST02\Test_Stamp.xls 是否已存在
        If System.IO.File.Exists("D:\TEST02\Test_Stamp.xls") = False Then
            MsgBox("Sorry, 請先執行『轉檔 1』，再執行本程序", 0 + 16, "Error")
            Exit Sub
        End If

        ' 檢查『編號』、『郵票名稱』等必要資料是否已輸入及是否合理
        If Len(Trim(T_sno.Text)) <> 4 Then
            MsgBox("Sorry, 『編號』未輸入或不正確！" + Chr(13) + Chr(13) + "請輸入編號（例如 A099）", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_itemname.Text)) = 0 Then
            MsgBox("Sorry, 『郵票名稱』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_qty.Text)) = 0 Then
            MsgBox("Sorry, 『數量』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_cost.Text)) = 0 Then
            MsgBox("Sorry, 『購入價格』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If IsNumeric(T_qty.Text) = False Then
            MsgBox("Sorry, 『數量』欄必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If
        If IsNumeric(T_cost.Text) = False Then
            MsgBox("Sorry, 『購入價格』欄必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table02") 資料表的結構
        Dim MFN_2 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_2 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 建立資料轉接器與資料集
        Dim ODataSet_1 As DataSet = New DataSet
        Dim Msqlstr_2 As String = "Select * From [Sheet1$]"
        Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
        ODataAdapter_2.Fill(ODataSet_1, "Table02")
        DataGridView1.DataSource = ODataSet_1.Tables("Table02")

        ' 檢查編號是否存在 ****************************************************************************
        ' 使用 DefaultView 屬性建立預設的資料檢視表（此 DataView 資料檢視表物件可儲存從 DataTable 篩選或排序後的資料）
        Dim O_DataView As DataView
        O_DataView = ODataSet_1.Tables("Table02").DefaultView

        ' DataView 檢視表的 RowFilter 方法篩選出 User 所輸入的編號，若有，則表示編號存在
        ' 比較值 T_sno.Text 的前後要加單引號
        O_DataView.RowFilter = "編號='" + T_sno.Text + "'"
        If O_DataView.Count = 0 Then
            MsgBox("Sorry, 『編號』不存在！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            ODataAdapter_2.Dispose()
            Oconn_2.Close()
            Oconn_2.Dispose()
            Exit Sub
        End If

        ' 將 User 輸入資料存入資料列物件 O_NewRow
        ' 若無日期資料，應給予 Null，例如 O_NewRow("購入時間") = DBNull.Value，若使用日曆控制項則無需（必有日期）
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table02").NewRow()
        O_NewRow("編號") = T_sno.Text
        O_NewRow("國家") = T_country.Text
        O_NewRow("郵票名稱") = T_itemname.Text
        O_NewRow("專題類別") = T_topics.Text
        O_NewRow("數量") = Convert.ToInt32(T_qty.Text)
        O_NewRow("購入價格") = Convert.ToDouble(T_cost.Text)
        O_NewRow("購入時間") = T_purdate.Value
        ODataSet_1.Tables("Table02").Rows.Add(O_NewRow)

        ' 建立更新指令，並指出更新值之來源為 Table02 的哪一欄（註：Table02 是資料轉接器 ODataAdapter_2 所指名欲調節的資料表，請注意欄名需一致）
        ' 不使用 轉接器 ODataAdapter_2 的 UpdateCommand 屬性
        ODataAdapter_2.InsertCommand = New OleDbCommand("Update [Sheet1$] Set 國家=@t1,郵票名稱=@t2,專題類別=@t3,數量=@t4,購入價格=@t5,購入時間=@t6 Where 編號='" + T_sno.Text + "'", Oconn_2)
        ODataAdapter_2.InsertCommand.Parameters.Add("@t1", OleDbType.Char, 10).SourceColumn = "國家"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t2", OleDbType.Char, 30).SourceColumn = "郵票名稱"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t3", OleDbType.Char, 4).SourceColumn = "專題類別"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t4", OleDbType.Integer).SourceColumn = "數量"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t5", OleDbType.Double).SourceColumn = "購入價格"
        ODataAdapter_2.InsertCommand.Parameters.Add("@t6", OleDbType.Date).SourceColumn = "購入時間"

        ' 使用資料轉接器的 Update 方法進行更新
        Dim MAffectedNO As Integer = ODataAdapter_2.Update(ODataSet_1, "Table02")

        ' 關閉資料處理物件並釋放資源
        ODataAdapter_2.Dispose()
        Oconn_2.Close()
        Oconn_2.Dispose()

        ' 重新讀取更新後的資料 *************************************************
        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table01") 資料表的結構
        Dim MFN_1 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_1 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_1 As New OleDbConnection(Mstrconn_1)
        Oconn_1.Open()

        ' 在資料集 ODataSet_1 中建立另一資料表，第二列為空白，故不抓取（使用 Null 判斷）
        Dim Msqlstr_1 As String = "Select * From [Sheet1$] Where 編號<>Null"
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "購入價格"
            .Columns(6).HeaderText = "購入時間"
        End With
        ' 金額欄及日期欄格式化
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "#,0.00"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 關閉資料處理物件並釋放資源()
        ODataAdapter_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        MsgBox("D:\TEST02\Test_Stamp.xls 的資料已更新！", 0 + 64, "OK")
    End Sub

    ' 刪除 D:\TEST02\Test_Stamp.xls 的資料
    ' 無法 使用 OleDbCommand 刪除 Excel 檔中的資料，The Jet OLE DB provider does not allow DELETE operations.
    ' 即使建立主索引鍵亦無用，故使用 COM 物件執行刪除
    ' 微軟網站的說明：
    ' Although the Jet OLE DB Provider allows you to insert and update records in an Excel workbook, it does not allow DELETE operations. 
    ' If you try to perform a DELETE operation on one or more records, you receive the following error message: 
    ' Deleting data in a linked table is not supported by this ISAM. 
    Private Sub B_Delete_Click(sender As Object, e As EventArgs) Handles B_Delete.Click
        ' 清空文字盒及資料網格控制項
        T_FileName.Text = ""
        T_SheetName.Text = ""
        T_CreateDate.Text = ""
        T_Count.Text = ""
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = ""

        ' 檢查檔案 D:\TEST02\Test_Stamp.xls 是否已存在
        If System.IO.File.Exists("D:\TEST02\Test_Stamp.xls") = False Then
            MsgBox("Sorry, 請先執行『轉檔 1』，再執行本程序", 0 + 16, "Error")
            Exit Sub
        End If

        ' 檢查『編號』是否已輸入及是否合理
        If Len(Trim(T_sno.Text)) <> 4 Then
            MsgBox("Sorry, 『編號』未輸入或不正確！" + Chr(13) + Chr(13) + "請輸入編號（例如 A099）", 0 + 16, "Error")
            Exit Sub
        End If

        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table02") 資料表的結構
        Dim MFN_2 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_2 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_2 As New OleDbConnection(Mstrconn_2)
        Oconn_2.Open()

        ' 建立資料轉接器與資料集
        Dim ODataSet_1 As DataSet = New DataSet
        Dim Msqlstr_2 As String = "Select * From [Sheet1$]"
        Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
        ODataAdapter_2.Fill(ODataSet_1, "Table02")
        DataGridView1.DataSource = ODataSet_1.Tables("Table02")

        ' 檢查編號是否存在
        ' 使用 DefaultView 屬性建立預設的資料檢視表（此 DataView 資料檢視表物件可儲存從 DataTable 篩選或排序後的資料）
        Dim O_DataView As DataView
        O_DataView = ODataSet_1.Tables("Table02").DefaultView

        ' DataView 檢視表的 RowFilter 方法篩選出 User 所輸入的編號，若有，則表示編號存在
        ' 比較值 T_sno.Text 的前後要加單引號
        O_DataView.RowFilter = "編號='" + T_sno.Text + "'"
        If O_DataView.Count = 0 Then
            MsgBox("Sorry, 『編號』不存在！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            ODataAdapter_2.Dispose()
            Oconn_2.Close()
            Oconn_2.Dispose()
            Exit Sub
        End If

        ' 使用下列方法無法刪除，故改用 COM 物件
        'ODataAdapter_2.DeleteCommand = New OleDbCommand("Delete From [Sheet1$] Where 編號='" + T_sno.Text + "'", Oconn_2)
        'Dim MAffectedNO As Integer = ODataAdapter_2.Update(ODataSet_1, "Table02")

        ' 使用 For 迴圈逐筆判斷其編號是否與 User 所指定的相同，若是，則以迴圈計數+2 為所需刪除的列號，並存入變數 MDeleteRowNo ，供後續刪除指令使用，
        ' 註：資料從第三列開始，故目標列數需加 2
        ' DataTable 的 Rows屬性後加列號及行號可取出資料表中某格位之值
        Dim MDeleteRowNo As Int32 = 0
        Dim Mstop As Int32 = ODataSet_1.Tables("Table02").Rows.Count
        For Mrow = 1 To Mstop - 1 Step 1
            If ODataSet_1.Tables("Table02").Rows(Mrow)(0) = T_sno.Text Then
                MDeleteRowNo = Mrow + 2
                Exit For
            End If
        Next

        ' 關閉資料處理物件並釋放資源()
        ODataAdapter_2.Dispose()
        Oconn_2.Close()
        Oconn_2.Dispose()

        ' ***********************************************************************************************************
        ' 啟動  OLE Application（Excel 應用程式）
        Dim OLEAPP As Object = CreateObject("Excel.Application")
        ' 關閉可見
        OLEAPP.Visible = False
        ' 關閉警告視窗
        OLEAPP.DisplayAlerts = False

        ' 使用 Workbooks.Open 方法建立活頁簿物件（取名 Mybook），並開啟來源檔
        Dim Mybook As Object = OLEAPP.Workbooks.Open("D:\TEST02\Test_Stamp.xls")

        ' 建立工作表物件（取名 MySheet）， 開啟第一張工作表（括號內可指定工作表索引或工作表名稱）
        ' Activate 方法可指定作用工作表
        'Dim MySheet As Object = Mybook.sheets(1)
        Dim MySheet As Object = Mybook.Worksheets("Sheet1")
        MySheet.Activate()

        ' 選取目標列，再以 Delete 方法刪除整列
        OLEAPP.Rows(MDeleteRowNo).Select()
        OLEAPP.Selection.Delete()

        ' 游標歸位
        OLEAPP.Range("A1").Select()
        OLEAPP.Range("A2").Select()

        ' 使用 SaveAs 方法將活頁簿物件 Mybook 存入檔案，括號內為檔名及路徑
        Mybook.Save()

        ' 關閉相關物件並釋放資源
        Mybook.Close()
        Mybook = Nothing
        MySheet = Nothing
        OLEAPP.Quit()
        ' ************************************************************************************************

        ' 重新讀取更新後的資料
        ' 使用資料轉接器建立與 Excel 檔之管道，並據以建立  ODataSet_1.Tables("Table01") 資料表的結構
        Dim MFN_1 As String = "D:\TEST02\Test_Stamp.xls"
        Dim Mstrconn_1 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=Yes';"
        Dim Oconn_1 As New OleDbConnection(Mstrconn_1)
        Oconn_1.Open()

        ' 在資料集 ODataSet_1 中建立另一資料表，第二列為空白，故不抓取（使用 Null 判斷）
        Dim Msqlstr_1 As String = "Select * From [Sheet1$] Where 編號<>Null"
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "購入價格"
            .Columns(6).HeaderText = "購入時間"
        End With
        ' 金額欄及日期欄格式化
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "#,0.00"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 關閉資料處理物件並釋放資源()
        ODataAdapter_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString

        MsgBox("D:\TEST02\Test_Stamp.xls 中編號 " + T_sno.Text + " 的資料已刪除！", 0 + 64, "OK")
    End Sub

End Class