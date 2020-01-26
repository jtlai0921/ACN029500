Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_ACCESS02
    ' 宣告公用變數以便儲存來源檔及OleDB資料提供者
    Public MSTRconn_0 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=APPDATA\VBACCESSDB.accdb"

    ' 宣告資料庫連結物件
    Public Oconn_1 As OleDbConnection

    ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
    Public Msqlstr_1 As String = "Select datano,description,qty,price,amt,datatime From TEST01"

    ' 宣告資料轉接器（處理非圖片資料）
    Public ODataAdapter_1 As OleDbDataAdapter

    ' 宣告資料集物件（處理非圖片資料）
    Public ODataSet_1 As DataSet

    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As Int32 = 0

    ' 宣告資料轉接器（處理圖片資料）
    Public ODataAdapter_2 As OleDbDataAdapter

    ' 宣告資料集物件（處理圖片資料）
    Public ODataSet_2 As DataSet

    ' 宣告位元陣列以便儲存讀出的圖片
    Public MTempBinary As Byte()

    ' 宣告記憶體串流物件，以便將資料直接存到實體檔
    Public MTempStream As MemoryStream

    ' --------------------------------------------------------------------------------------------------------------------------------------------

    ' 本表單載入時，將資料存入資料集並顯示於 DataGridView，
    ' 但不載入圖片資料，圖片資料仍在 DataGridView 選取變動事件中讀取
    Private Sub F_ACCESS02_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 連結及開啟資料庫
        Oconn_1 = New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 建立資料轉接器
        ODataAdapter_1 = New OleDbDataAdapter(Msqlstr_1, Oconn_1)

        ' 建立資料集
        ODataSet_1 = New DataSet

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
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
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If

    End Sub

    ' DataGridView 選取變動事件中傳回游標所在列資料的圖片
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        ' 取回游標所在列的資料編號，以便作為後續 SQL指令之查詢條件
        Dim MTempNO As String = ""
        MTempNO = DataGridView1.CurrentRow.Cells(0).Value

        ' 使用相同的資料庫連結物件（已宣告為 Public），故此處無需再建立

        ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
        Dim Msqlstr_2 As String = "Select pic01 From TEST01 Where datano='" + MTempNO + "'"

        ' 建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        ODataAdapter_2 = New OleDbDataAdapter(Msqlstr_2, Oconn_1)

        ' 建立新資料集，以便存放讀出的圖片資料
        ODataSet_2 = New DataSet

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_2.Fill(ODataSet_2, "Table01")

        If ODataSet_2.Tables("Table01").Rows.Count = 0 Then
            Exit Sub
        End If

        ' 若無圖片資料，則清空圖片盒，若有，則顯示之
        If IsDBNull(ODataSet_2.Tables("Table01").Rows(0)(0)) = True Then
            PictureBox1.Image = Nothing
        Else
            MTempBinary = ODataSet_2.Tables("Table01").Rows(0)(0)
            MTempStream = New MemoryStream(MTempBinary)
            PictureBox1.Image = Image.FromStream(MTempStream)
        End If

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As Int32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

        ' 將游標所在列的資料顯示於各個文字盒
        On Error Resume Next
        T_datano.Text = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(DataGridView1.CurrentRow.Cells(1).Value) = True Then
            T_description.Text = ""
        Else
            T_description.Text = DataGridView1.CurrentRow.Cells(1).Value
        End If
        If IsDBNull(DataGridView1.CurrentRow.Cells(2).Value) = True Then
            T_qty.Text = ""
        Else
            T_qty.Text = DataGridView1.CurrentRow.Cells(2).Value
        End If
        If IsDBNull(DataGridView1.CurrentRow.Cells(3).Value) = True Then
            T_price.Text = ""
        Else
            T_price.Text = DataGridView1.CurrentRow.Cells(3).Value
        End If

    End Sub

    ' 使用 OpenFileDialog 檔案對話方塊控制項讓 User 選取圖片檔
    ' 選取圖片，SafeFileName 屬性可傳回檔名（不含路徑）， FileSystem 的 FileLen 方法可傳回檔案的大小， 括號內為檔名及其路徑
    ' 檔案對話方塊控制項的詳細使用方法請參考附錄 OpenFileDialog 的說明
    Private Sub B_PickUp_Click(sender As Object, e As EventArgs) Handles B_PickUp.Click
        OpenFileDialog1.Filter = "(JPG檔;GIF檔;BMP檔;WMF檔;PNG檔;ICO檔)|*.jpg;*.gif;*.bmp;*.wmf;*.png;*.ico"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "請選取一個圖檔"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_Path.Text = OpenFileDialog1.FileName
            T_FileName.Text = OpenFileDialog1.SafeFileName
            T_FileSize.Text = FileSystem.FileLen(T_Path.Text).ToString + " byte"
        End If
    End Sub

    ' 新增（將資料插入 Access 資料表）
    Private Sub B_ADD_Click(sender As Object, e As EventArgs) Handles B_ADD.Click

        ' 第一段 ************************************************************************************
        ' 檢查『數量』、『單價』是否已輸入，此  2 項不得空白
        If Len(Trim(T_qty.Text)) = 0 Then
            MsgBox("『數量』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_price.Text)) = 0 Then
            MsgBox("『單價』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        ' 使用 Information 類別的 IsNumeric 方法 檢查『數量』、『單價』是否為數字
        If Information.IsNumeric(T_qty.Text) = False Then
            MsgBox("『數量』欄的資料必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If
        If Information.IsNumeric(T_price.Text) = False Then
            MsgBox("『單價』欄的資料必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If

        ' 必須先於此處取回 User 輸入值
        Dim MTempDescription As String = Trim(T_description.Text)
        Dim MTempQty As Int32 = Val(T_qty.Text)
        Dim MTempPrice As Double = Val(T_price.Text)

        ' 第二段 ************************************************************************************
        ' 自 Dataset 抓出最大編號，以便編制新資料的編號
        ' 變數 MTempDataNo 儲存目前最大編號
        Dim MTempDataNo As Object = DBNull.Value

        ' 使用資料表的 Select 方法篩出目前最大編號，Select 括號內為運算式變數，請注意其寫法，不能只寫 MAX(datano)，
        ' 篩選出來的資料需存入資料列陣列（本例取名為 A_match），隨後使用 For Each 迴圈將篩選出來的資料列的第一欄之值存入變數 MTempDataNo
        ' 因為要從 Table01 來查出目前最大編號，故該資料表必須含有全部資料（註：經過查詢後，Table01 可能只含部分資料 ），
        ' 故先清空資料集的資料，重建資料轉接器，再使用轉接器的 Fill 方法，將全部資料重新填入資料集
        Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01"
        ODataSet_1.Clear()
        ODataAdapter_1 = New OleDbDataAdapter(Msqlstr_1, Oconn_1)
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        Dim O_TempTable As DataTable = ODataSet_1.Tables("Table01")
        ' Dim O_TempTable As DataTable = ODataSet_1.Tables("Table01").Copy()

        Dim Mexpression As String = "datano=MAX(datano)"
        Dim MsortOrder As String = "datano ASC"

        Dim A_match() As DataRow
        A_match = O_TempTable.Select(Mexpression, MsortOrder)
        If A_match.Length > 0 Then
            MTempDataNo = A_match(0)
            Dim O_Row As DataRow
            For Each O_Row In A_match
                MTempDataNo = O_Row(0)
            Next
        End If

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 資料編號固定為 6 碼，由 A00001～Z99999，最多可產生 259 萬 9974 個編號
        Dim MPreCode As String = ""
        Dim MSerialNo As String = ""
        Dim MLen As Integer = 0
        Dim Mdatano As String = ""

        ' 以 Strings 類別的方法取代字串函數來處理字串，需引用命名空間 Microsoft.VisualBasic
        ' 使用 Strings.Right 方法 抓出從右邊算起的部分字串，
        ' 在 Windows Form 中使用 Strings 類別的 Right 方法，則必須為 Microsoft.VisualBasic.Strings.Right 完整限定函式
        ' Strings.Left 方法 抓出從左邊算起的部分字串，Strings.StrDup 可重複指定的字元 ，
        ' Strings.Len 可傳回字串的字元數，例如 Strings.Len("ABC") 傳回 3，Strings.Len("程式設計") 傳回 4
        ' Strings.Asc 可傳會字元所對應的 ASCII Code，Strings.Chr 可傳回 ASCII Code 所對應的字元
        ' 使用 Conversion.Val 方法將文字轉成數字

        If IsDBNull(MTempDataNo) = True Then
            Mdatano = "A00001"
        Else
            If MTempDataNo = "Z99999" Then
                MsgBox("資料編號已到頂，無法新增！" + Chr(13) + Chr(10) + "請先清空資料表，再新增資料。", 0 + 64, "Attention")
                Exit Sub
            End If
            MSerialNo = Conversion.Val(Strings.Right(MTempDataNo, 5)) + 1
            If MSerialNo <= 99999 Then
                MPreCode = Strings.Left(MTempDataNo, 1)
                MLen = Strings.Len(MSerialNo.ToString)
                Mdatano = MPreCode + Strings.StrDup(5 - MLen, "0") + MSerialNo.ToString
            Else
                MPreCode = Strings.Left(MTempDataNo, 1)
                MPreCode = Strings.Chr(Strings.Asc(MPreCode) + 1)
                Mdatano = MPreCode + "00001"
            End If
        End If

        ' 第三段 ************************************************************************************
        ' 將 User 輸入值存入資料列
        ' 建立 DataRow 物件，以便暫存新增的資料
        ' 使用 DataTable 資料表的 NewRow 方法初始化 新建的 DataRow 物件（使新物件的欄位結構與來源資料表相同）
        ' 指定  DataRow 物件的各欄資料後，使用資料表的 Rows.Add 方法，將 DataRow 物件資料加入資料集之中的資料表
        ' 使用 DataRow 的 AcceptChanges 方法認可資料列所作之變更
        ' 使用 DataRow 的 SetAdded 方法 將 DataRow 物件的 Rowstate 變更為 Added
        ' Rowstate  之狀態：
        ' Added 資料列已經加入至 DataRowCollection，並且尚未呼叫 AcceptChanges。 
        ' Deleted 使用 DataRow 的 Delete 方法來刪除資料列。 
        ' Detached 資料列已建立，但它不屬於任何 DataRowCollection。 DataRow  在已經建立後、加入至集合前，或如果已經從集合移除後，會立即處在這個狀態中。  
        ' Modified 已經修改資料列，並且尚未呼叫 AcceptChanges。 
        ' Unchanged 資料列從上次呼叫 AcceptChanges 之後就未變更。 
        ' 設定 DataRow 之值可用欄名或欄位順序（如下）
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table01").NewRow()

        'O_NewRow("datano") = Mdatano
        'O_NewRow("description") = MTempDescription
        'O_NewRow("qty") = MTempQty
        'O_NewRow("price") = MTempPrice
        'O_NewRow("amt") = Math.Round(MTempPrice * MTempQty, 2)
        'O_NewRow("datatime") = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        O_NewRow(0) = Mdatano
        O_NewRow(1) = MTempDescription
        O_NewRow(2) = MTempQty
        O_NewRow(3) = MTempPrice
        O_NewRow(4) = Math.Round(MTempPrice * MTempQty, 2)
        O_NewRow(5) = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
        O_NewRow.AcceptChanges()
        O_NewRow.SetAdded()

        ' 使用 OleDbCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 OleDbCommandBuilder 令建構物件的 GetInsertCommand 方法，以便產生插入資料所需的 OleDbCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New OleDbCommandBuilder(ODataAdapter_1)
        O_CB1.GetInsertCommand(True)
        ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 圖片處理
        Dim Msqlstr_7 As String = "Update TEST01 Set pic01=@t7 Where datano=" + "'" + Mdatano + "'"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_7），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_7 As New OleDbCommand(Msqlstr_7, Oconn_1)

        ' 先偵測 User 是否指定圖片，若無，則給予 Null
        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_7.Parameters.AddWithValue("@t7", DbType.Object).Value = DBNull.Value
        Else
            Dim Apicturedata() As Byte = Nothing
            Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.Read)
            Dim Mlength As Double = O_FileStream.Length
            If Mlength > 5242880 Then
                MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                Exit Sub
            End If

            Dim O_BinaryReader As New BinaryReader(O_FileStream)
            Apicturedata = O_BinaryReader.ReadBytes(5242880)

            Ocmd_7.Parameters.AddWithValue("@t7", DbType.Binary).Value = Apicturedata

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，以便存入資料
        Ocmd_7.ExecuteNonQuery()
        Ocmd_7.Dispose()

        ' 清空文字盒，以方便下一筆資料的輸入
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""
        ' 重新顯示記錄數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If MTotalRecordNo = 0 Then
            T_RecordNo.Text = "記錄數： 0 / " + MTotalRecordNo.ToString
        Else
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
        End If
        MsgBox("資料已新增！" + Chr(13) + Chr(10) + "請見 DataGridView。", 0 + 64, "OK")
    End Sub

    ' 查詢
    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click

        ' 若 User 指定了資料編號，則查出該編號的資料，若未指定資料編號否，則查出全部資料
        Dim MTempNo As String = ""
        If Strings.Len(T_datano.Text) <> 6 Then
            MTempNo = ""
        Else
            MTempNo = Strings.UCase(Strings.Trim(T_datano.Text))
        End If

        ' SQL 指令視 User 是否輸入資料編號而分為兩種
        If MTempNo = "" Then
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01"
        Else
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01 Where datano=" + "'" + MTempNo + "'"
        End If

        ' 清空資料集的資料，重建資料轉接器，再使用轉接器的 Fill 方法，將新資料重新填入資料集
        ODataSet_1.Clear()
        ODataAdapter_1 = New OleDbDataAdapter(Msqlstr_1, Oconn_1)
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
            'DataGridView1.Columns.RemoveAt(0)
        Next
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
            '.Columns(5).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            .Columns(5).DefaultCellStyle.Format = "yyyy/MM/dd hh:mm:ss tt"
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
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If

    End Sub

    ' 修改
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click

        Dim Mdatano As String = ""

        ' 檢查『資料編號』、『數量』、『單價』是否已輸入，此  3 項不得空白
        If Len(Trim(T_datano.Text)) <> 6 Then
            MsgBox("Sorry, 『資料編號』未輸入或不正確！" + Chr(13) + Chr(13) + "請指定欲修改資料的編號（例如 A00005）", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_qty.Text)) = 0 Then
            MsgBox("『數量』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_price.Text)) = 0 Then
            MsgBox("『單價』未輸入！", 0 + 16, "Error")
            Exit Sub
        End If
        ' 使用 Information 類別的 IsNumeric 方法 檢查『數量』、『單價』是否為數字
        If Information.IsNumeric(T_qty.Text) = False Then
            MsgBox("『數量』欄的資料必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If
        If Information.IsNumeric(T_price.Text) = False Then
            MsgBox("『單價』欄的資料必須為數字！", 0 + 16, "Error")
            Exit Sub
        End If
        Mdatano = T_datano.Text

        ' 資料庫物件及資料集已宣告為 Public，故此處無需重新連接或開啟
        ' 使用 For 迴圈逐一掃瞄資料集，若其資料編號與 User 所指定者相同，則使用 Delete 方法刪除之
        ' Rows.Count  屬性可傳回資料表的筆數，Rows 屬性後接列號及行號（均由 0 起算且須以括號括住）可傳回其格位之值
        Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            If ODataSet_1.Tables("Table01").Rows(Mcou)(0) = Mdatano Then
                ODataSet_1.Tables("Table01").Rows(Mcou)(1) = T_description.Text
                ODataSet_1.Tables("Table01").Rows(Mcou)(2) = Val(T_qty.Text)
                ODataSet_1.Tables("Table01").Rows(Mcou)(3) = Val(T_price.Text)
                ODataSet_1.Tables("Table01").Rows(Mcou)(4) = Math.Round(Val(T_qty.Text) * Val(T_price.Text), 2)
                ODataSet_1.Tables("Table01").Rows(Mcou)(5) = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                Exit For
            End If
        Next

        ' 使用 OleDbCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 OleDbCommandBuilder 令建構物件的 GetUpdateCommand 方法，以便產生更新資料所需的 OleDbCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New OleDbCommandBuilder(ODataAdapter_1)
        O_CB1.GetUpdateCommand()
        Dim MAffectedNO As Integer = ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 圖片處理
        Dim Msqlstr_7 As String = "Update TEST01 Set pic01=@t7 Where datano=" + "'" + Mdatano + "'"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_7），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_7 As New OleDbCommand(Msqlstr_7, Oconn_1)

        ' 先偵測 User 是否指定圖片，若無，則給予 Null
        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_7.Parameters.AddWithValue("@t7", DbType.Object).Value = DBNull.Value
        Else
            Dim Apicturedata() As Byte = Nothing
            Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.Read)
            Dim Mlength As Double = O_FileStream.Length
            If Mlength > 5242880 Then
                MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                Exit Sub
            End If

            Dim O_BinaryReader As New BinaryReader(O_FileStream)
            Apicturedata = O_BinaryReader.ReadBytes(5242880)

            Ocmd_7.Parameters.AddWithValue("@t7", DbType.Binary).Value = Apicturedata

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，以便存入資料
        Ocmd_7.ExecuteNonQuery()
        Ocmd_7.Dispose()

        If MAffectedNO = 1 Then
            ' 清空文字盒，以方便下一筆資料的輸入
            T_datano.Text = ""
            T_description.Text = ""
            T_qty.Text = ""
            T_price.Text = ""
            T_Path.Text = ""
            T_FileName.Text = ""
            T_FileSize.Text = ""
            MsgBox("資料已修改！", 0 + 64, "OK")
        Else
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲修改資料的編號（例如 A00005）。", 0 + 16, "Error")
        End If

    End Sub

    ' 刪除
    Private Sub B_Delete_Click(sender As Object, e As EventArgs) Handles B_Delete.Click

        If Len(Trim(T_datano.Text)) <> 6 Then
            MsgBox("『資料編號』未輸入或不正確！" + Chr(13) + Chr(10) + "請輸入欲刪除資料的編號（例如 A00005）。", 0 + 16, "Error")
            Exit Sub
        End If

        ' 資料庫物件及資料集已宣告為 Public，故此處無需重新連接或開啟
        ' 使用 For 迴圈逐一掃瞄資料集，若其資料編號與 User 所指定者相同，則使用 Delete 方法刪除之
        ' Rows.Count  屬性可傳回資料表的筆數，Rows 屬性後接列號及行號（均由 0 起算且須以括號括住）可傳回其格位之值
        Dim Mstop As Int32 = ODataSet_1.Tables("Table01").Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            If ODataSet_1.Tables("Table01").Rows(Mcou)(0) = T_datano.Text Then
                ODataSet_1.Tables("Table01").Rows(Mcou).Delete()
                Exit For
            End If
        Next

        ' 使用 OleDbCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 OleDbCommandBuilder 令建構物件的 GetDeleteCommand 方法，以便產生刪除資料所需的 OleDbCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New OleDbCommandBuilder(ODataAdapter_1)
        O_CB1.GetDeleteCommand()
        Dim MAffectedNO As Integer = ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 清空文字盒，以方便下一筆資料的輸入
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""
        ' 重新顯示記錄數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If MTotalRecordNo = 0 Then
            T_RecordNo.Text = "記錄數： 0 / " + MTotalRecordNo.ToString
        Else
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
        End If

        If MAffectedNO = 0 Then
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲刪除資料的編號（例如 A00005）。", 0 + 16, "Error")
        Else
            MsgBox("資料已刪除！", 0 + 64, "OK")
        End If

    End Sub

    ' 將 NULL 值插入 Access
    ' 判斷讀出的資料是否為 NULL 值 可使用  IsDBNull 函式 或 DBNull.Value.Equals 方法 或 Convert.IsDBNull 方法
    Private Sub B_NULL_Click(sender As Object, e As EventArgs) Handles B_NULL.Click

        ' 第二段 ************************************************************************************
        ' 自 Dataset 抓出最大編號，以便編制新資料的編號
        Dim MTempDataNoB As Object = DBNull.Value

        ' 使用 DefaultView 屬性建立預設的資料檢視表（此 DataView 資料檢視表物件可儲存從 DataTable 篩選或排序後的資料）
        Dim O_DataView As DataView
        O_DataView = ODataSet_1.Tables("Table01").DefaultView

        ' 宣告資料列檢視物件（儲存 DataView 檢視表的每一列資料）
        Dim O_Row As DataRowView

        ' DataView 檢視表的 FindRows 方法找出最大的資料編號，
        ' 本例要從 datano 欄找出最大編號，該欄必須先使用 DataView 檢視表的 Sort 方法排序過，
        ' 合於條件的資料會存入物件陣列（本例為 O_Row），但該物件只會有一欄資料（本例為 datano），不會有其他欄的資料，
        ' DataView 檢視表的 RowFilter 方法所篩選出來的資料才會是整筆資料（有其他欄），例如 O_DataView.RowFilter = "qty>700"
        O_DataView.Sort = "datano ASC"
        O_DataView.FindRows("MAX(datano)")

        ' 使用  For 迴圈逐一將資料檢視表物件之資料列的資料取出，
        ' 取出 DataRowView 資料列檢視物件某欄的資料可用 Item 屬性（括號內為欄位順序，由 0 起算），
        ' 或在 DataRowView 資料列檢視物件後接括號，括號內以雙引號括住所需的欄位名稱，範例如下
        For Each O_Row In O_DataView
            'MTempDataNoB = O_Row("datano")
            MTempDataNoB = O_Row.Item(0)
        Next

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 資料編號固定為 6 碼，由 A00001～Z99999，最多可產生 259 萬 9974 個編號
        Dim MPreCode As String = ""
        Dim MSerialNo As String = ""
        Dim MLen As Integer = 0
        Dim Mdatano As String = ""

        ' 以 Strings 類別的方法取代字串函數來處理字串，需引用命名空間 Microsoft.VisualBasic
        ' 使用 Strings.Right 方法 抓出從右邊算起的部分字串，
        ' 在 Windows Form 中使用 Strings 類別的 Right 方法，則必須為 Microsoft.VisualBasic.Strings.Right 完整限定函式
        ' Strings.Left 方法 抓出從左邊算起的部分字串，Strings.StrDup 可重複指定的字元 ，
        ' Strings.Len 可傳回字串的字元數，例如 Strings.Len("ABC") 傳回 3，Strings.Len("程式設計") 傳回 4
        ' Strings.Asc 可傳會字元所對應的 ASCII Code，Strings.Chr 可傳回 ASCII Code 所對應的字元
        ' 使用 Conversion.Val 方法將文字轉成數字

        If IsDBNull(MTempDataNoB) = True Then
            Mdatano = "A00001"
        Else
            If MTempDataNoB = "Z99999" Then
                MsgBox("資料編號已到頂，無法新增！" + Chr(13) + Chr(10) + "請先清空資料表，再新增資料。", 0 + 64, "Attention")
                Exit Sub
            End If
            MSerialNo = Conversion.Val(Strings.Right(MTempDataNoB, 5)) + 1
            If MSerialNo <= 99999 Then
                MPreCode = Strings.Left(MTempDataNoB, 1)
                MLen = Strings.Len(MSerialNo.ToString)
                Mdatano = MPreCode + Strings.StrDup(5 - MLen, "0") + MSerialNo.ToString
            Else
                MPreCode = Strings.Left(MTempDataNoB, 1)
                MPreCode = Strings.Chr(Strings.Asc(MPreCode) + 1)
                Mdatano = MPreCode + "00001"
            End If
        End If

        ' 第三段 ************************************************************************************
        ' 將 Null 存入資料列
        ' 建立 DataRow 物件，以便暫存新增的資料
        ' 使用 DataTable 資料表的 NewRow 方法初始化 新建的DataRow 物件（使新物件的欄位結構與來源資料表相同）
        ' 指定  DataRow 物件的各欄資料後，使用資料表的 Rows.Add 方法，將物件資料加入資料集之中的資料表
        ' 使用 DataRow 的 AcceptChanges 方法認可資料列所作之變更
        ' 使用 DataRow 的 SetAdded 方法 將 DataRow 物件的 Rowstate 變更為 Added
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table01").NewRow()
        O_NewRow("datano") = Mdatano
        O_NewRow("description") = DBNull.Value
        O_NewRow("qty") = DBNull.Value
        O_NewRow("price") = DBNull.Value
        O_NewRow("amt") = DBNull.Value
        O_NewRow("datatime") = DBNull.Value
        ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
        O_NewRow.AcceptChanges()
        O_NewRow.SetAdded()

        ' 使用 OleDbCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 OleDbCommandBuilder 令建構物件的 GetInsertCommand 方法，已產生插入資料所需的 OleDbCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New OleDbCommandBuilder(ODataAdapter_1)
        O_CB1.GetInsertCommand()
        ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 圖片處理
        Dim Msqlstr_7 As String = "Update TEST01 Set pic01=@t7 Where datano=" + "'" + Mdatano + "'"
        Dim Ocmd_7 As New OleDbCommand(Msqlstr_7, Oconn_1)
        Ocmd_7.Parameters.AddWithValue("@t7", DbType.Object).Value = DBNull.Value
        Ocmd_7.ExecuteNonQuery()
        Ocmd_7.Dispose()

        ' 重新顯示記錄數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        If MTotalRecordNo = 0 Then
            T_RecordNo.Text = "記錄數： 0 / " + MTotalRecordNo.ToString
        Else
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
        End If

        MsgBox("Null 資料已新增！", 0 + 64, "OK")

    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""
    End Sub

    Private Sub MyClass_ButtonClose1_Click(sender As Object, e As EventArgs)
        ' 關閉 存取資料庫的相關物件並釋放資源
        Oconn_1.Close()
        Oconn_1.Dispose()
        ODataAdapter_1.Dispose()
        ODataAdapter_2.Dispose()
        ODataSet_1.Dispose()
        ODataSet_2.Dispose()
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
End Class
