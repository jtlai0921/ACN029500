Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class F_SQL02
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0

    ' 使用 OpenFileDialog 檔案對話方塊控制項讓 User 選取圖片檔
    ' 選取圖片，SafeFileName 屬性可傳回檔名（不含路徑）， FileLen 函式可傳回檔案的大小， 括號內為檔名及其路徑
    ' 檔案對話方塊控制項的詳細使用方法請參考附錄 OpenFileDialog 的說明
    Private Sub B_PickUp_Click(sender As Object, e As EventArgs) Handles B_PickUp.Click
        OpenFileDialog1.Filter = "(JPG檔;GIF檔;BMP檔;WMF檔;PNG檔;ICO檔)|*.jpg;*.gif;*.bmp;*.wmf;*.png;*.ico"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "請選取一個圖檔"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_Path.Text = OpenFileDialog1.FileName
            T_FileName.Text = OpenFileDialog1.SafeFileName
            T_FileSize.Text = FileLen(T_Path.Text).ToString + " byte"
        End If
    End Sub

    ' 新增（將資料插入 SQL Server 資料表）
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
        ' 取回 User 輸入值
        Dim MTempDescription As String = Trim(T_description.Text)
        Dim MTempQty As Int32 = Val(T_qty.Text)
        Dim MTempPrice As Double = Val(T_price.Text)

        ' 第二段 ************************************************************************************
        ' 自 SQL Server 抓出最大編號，以便編制新資料的編號（此段仍使用 SqlCommand 物件處理）
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        ' 若 Trusted_Connection 設為True，則表示直接透過信任連線連接，故不需要指定帳號密碼資料
        ' Integrated Security=SSPI 的意義與 Trusted_Connection=True 相同
        ' 關鍵字之間以 ; 分隔
        Dim Mcnstr_0 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_0 As New SqlConnection(Mcnstr_0)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_0.Open()

        ' 宣告 SQL 命令變數，以供後續  SqlCommand 物件使用
        Dim Msqlstr_0 As String = "Select MAX(datano) From TEST01"

        ' 以 SqlCommand 建構函式始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_0 As New SqlCommand(Msqlstr_0, Ocn_0)

        ' 讀取目前最大編號有下列兩種方法：
        ' 方法 A → 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入  SqlDataReader 資料讀取物件
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_0 As SqlDataReader
        Odataread_0 = Ocmd_0.ExecuteReader()

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 配合後續 DataTable 的資料型別（無 SqlInt32），改用 Int32 ************
        'Dim Mdatano As SqlInt32 = 0
        Dim Mdatano As Int32 = 0
        Do While Odataread_0.Read() = True
            If IsDBNull(Odataread_0.Item(0)) = True Then
                Mdatano = 1
            Else
                Mdatano = Odataread_0.GetSqlInt32(0) + 1
            End If
        Loop
        Odataread_0.Close()

        ' 方法 B → 使用 SqlCommand 的 ExecuteScalar 方法（本法較簡單）
        'Dim Mdatano As Int32 = 0
        'Dim MTempNo As Int32 = Ocmd_0.ExecuteScalar()
        'If IsDBNull(MTempNo) = True Then
        'Mdatano = 1
        'Else
        'Mdatano = Convert.ToInt32(MTempNo) + 1
        'End If

        ' 關閉資料處理相關物件
        Ocmd_0.Dispose()
        Ocn_0.Close()
        Ocn_0.Dispose()

        ' 第三段 ************************************************************************************
        ' 將 User 輸入值存入變數
        Dim Mdescription As String = Trim(T_description.Text)
        'Dim Mqty As SqlInt32 = Val(T_qty.Text)
        Dim Mqty As Int32 = Val(T_qty.Text)
        Dim Mprice As Double = Val(T_price.Text)
        Dim Mamt As Double = Math.Round(Mprice * Mqty, 2)

        ' 第四段 ************************************************************************************
        ' 將新資料存入 SQL Server
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 使用 資料轉接器 更新 SQL Server 資料庫，不使用 SqlCommand 物件 ◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆
        ' 建立無資料的資料轉接器與資料集，使用下 4 列註記的程式碼較簡單，但本範另一種方式來建立無資料的資料轉接器與資料集，
        ' 雖較麻煩，但較有彈性，可適用於不同狀況
        'Dim Msqlstr_1 As String = "Select * From TEST01 Where datano<1"
        'Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)
        'Dim ODataSet_1 As DataSet = New DataSet
        'ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 使用 SqlDataAdapter 建構函式初始化資料轉接器，需指定 SQL 指令及連接物件，
        ' 以便後續使用資料轉接器的方法將資料集的資料更新至 SQL Server 資料庫時，能夠正確地對應資料表及其欄位，
        ' 只要資料表名稱及其欄位名稱正確即可，使用 Select 或 Insert 等陳述式都可
        Dim Msqlstr_1 As String = "Select * From TEST01 Where datano<1"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 建立資料集 ODataSet_1
        Dim ODataSet_1 As DataSet = New DataSet

        ' 依據 DataTable 類別建立資料表物件，括號內為資料表的名稱，後續使用資料集中的資料表時需指定此名稱
        ' CaseSensitive 設定字串比較是否區分大小寫、MinimumCapacity 設定初始的資料列數目
        Dim O_TempDataTable As DataTable = New DataTable("Table01")
        O_TempDataTable.CaseSensitive = False
        O_TempDataTable.MinimumCapacity = 1

        ' 使用 Add 方法加入欄位，括號內為欄位名稱及資料型態
        ' 使用 Type 類別的 GetType 方法可設定資料型別 System.Byte[]
        ' .NET Framework 基本資料型別: Boolean、Byte、Char、DateTime、Decimal、Double、Guid、Int16、Int32、Int64、SByte、Single、String、TimeSpan、UInt16、UInt32、UInt64 
        ' 沒有 System.Binary 這個型別，二進為圖片資料須使用 System.Byte[]，中括號不能省略
        O_TempDataTable.Columns.Add("datano", System.Type.GetType("System.Int32"))
        O_TempDataTable.Columns.Add("description", System.Type.GetType("System.String"))
        O_TempDataTable.Columns.Add("qty", System.Type.GetType("System.Int32"))
        O_TempDataTable.Columns.Add("price", System.Type.GetType("System.Decimal"))
        O_TempDataTable.Columns.Add("amt", System.Type.GetType("System.Double"))
        O_TempDataTable.Columns.Add("datatime", System.Type.GetType("System.DateTime"))
        O_TempDataTable.Columns.Add("pic01", Type.GetType("System.Byte[]"))

        ' 設定欄位屬性
        O_TempDataTable.Columns("datano").AllowDBNull = False
        O_TempDataTable.Columns("datano").Unique = True
        O_TempDataTable.Columns("description").MaxLength = 36
        O_TempDataTable.Columns("qty").DefaultValue = 0
        O_TempDataTable.Columns("price").ReadOnly = False
        'O_TempDataTable.Columns("amt").DataType = System.Type.GetType("System.Double")

        ' 設定 datano 欄為主索引鍵
        ' 先宣告陣列 Akeys（型別為資料欄物件，然後將資料表的欄位指定給它
        ' 最後再使用 PrimaryKey 屬性指定主索引鍵，
        ' 下述兩列指令可合寫為一行
        Dim Akeys(1) As DataColumn
        Akeys(0) = O_TempDataTable.Columns("datano")
        'Dim Akeys() As DataColumn = {O_TempDataTable.Columns("datano")}
        O_TempDataTable.PrimaryKey = Akeys

        ' 使用 Tables.Add 方法將資料表加入資料集
        ODataSet_1.Tables.Add(O_TempDataTable)

        ' 將 User 輸入值存入資料列
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table01").NewRow()

        O_NewRow("datano") = Mdatano
        O_NewRow("description") = MTempDescription
        O_NewRow("qty") = MTempQty
        O_NewRow("price") = MTempPrice
        O_NewRow("amt") = Math.Round(MTempPrice * MTempQty, 2)
        O_NewRow("datatime") = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        ' 圖片處理亦透過資料轉接器而不使用 SqlCommand 物件
        ' 先偵測 User 是否指定圖片，若無，則給予 Null
        If Len(Trim(T_Path.Text)) = 0 Then
            O_NewRow("pic01") = DBNull.Value
        Else
            Dim Apicturedata() As Byte = Nothing
            Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.Read)
            Dim Mlength As Double = O_FileStream.Length
            If Mlength > 5242880 Then
                MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                Ocn_1.Close()
                Ocn_1.Dispose()
                Exit Sub
            End If

            Dim O_BinaryReader As New BinaryReader(O_FileStream)
            Apicturedata = O_BinaryReader.ReadBytes(5242880)
            O_NewRow("pic01") = Apicturedata

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 將資料列併入資料集
        ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
        O_NewRow.AcceptChanges()
        O_NewRow.SetAdded()

        ' 更新 SQL Server 資料庫
        ' 使用 SqlCommandBuilder 命令建構物件的 GetInsertCommand 方法，以便產生插入資料所需的 SqlCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New SqlCommandBuilder(ODataAdapter_1)
        O_CB1.GetInsertCommand(True)
        ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()
        ' 清空文字盒，以方便下一筆資料的輸入
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""
        MsgBox("資料已新增！" + Chr(13) + Chr(10) + "敲『查詢』鈕，可查看新增的資料。", 0 + 64, "OK")

    End Sub

    ' 查詢
    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click

        ' 若 User 指定了資料編號，則查出該編號的資料，若未指定資料編號否，則查出全部資料
        ' IsNumeric 函式可檢查 User 所輸入值是否為數字，若未輸入亦會傳回 False（即視為非數字）
        ' 若輸入文字，亦查出全部資料
        Dim MTempNo As SqlInt32 = 0
        If IsNumeric(T_datano.Text) = False Then
            MTempNo = 0
        Else
            MTempNo = Val(Trim(T_datano.Text))
        End If

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        ' SQL 指令視 User 是否輸入資料編號而分為兩種
        Dim Msqlstr_1 As String = ""
        If MTempNo = 0 Then
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01"
        Else
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01 Where datano=" + "'" + MTempNo.ToString + "'"
        End If

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
            'DataGridView1.Columns.RemoveAt(0)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        'ODataAdapter_1.Dispose()
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

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續下 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select pic01 From TEST01 Where datano='" + MTempNO + "'"

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 讀出的資料可存入 DataSet 或 DataTable
        ' 方法一，存入 DataSet
        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        'Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        'ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 方法二，存入 DataTable
        ' 使用 SqlDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料表
        Dim O_dtable_1 As New DataTable
        ODataAdapter_1.Fill(O_dtable_1)
        If O_dtable_1.Rows.Count = 0 Then
            Exit Sub
        End If

        '  FileStream 檔案串流（或稱為資料流）是 .Net Framework 所提供的物件，用以存取檔案（包括文字檔及二進位檔）
        ' 宣告位元組陣列，並將資料表第1列第1行的資料（即前述已讀出的圖片）存入其中
        ' 判斷讀出的資料是否為 NULL 值 可使用  IsDBNull 函式 或 DBNull.Value.Equals 方法 或 Convert.IsDBNull 方法，範例如下
        'If IsDBNull(ODataSet_1.Tables("Table01").Rows(0)(0)) = True Then
        If IsDBNull(O_dtable_1.Rows(0)(0)) = True Then
            'If DBNull.Value.Equals(O_dtable_1.Rows(0)(0)) Then
            'If Convert.IsDBNull(O_dtable_1.Rows(0)(0)) = True Then
            PictureBox1.Image = Nothing
        Else
            'Dim MTempBinary As Byte() = ODataSet_1.Tables("Table01").Rows(0)(0)
            Dim MTempBinary As Byte() = O_dtable_1.Rows(0)(0)
            ' 依據 MemoryStream 記憶體串流建立新的物件，以便將資料直接存到實體檔，括號內為元組陣列
            Dim MTempStream As MemoryStream = New MemoryStream(MTempBinary)
            ' 使用 Image.FromStream 方法將記憶體串流物件指定給圖片盒，不能直接將位元組陣列指定給圖片盒，例如  PictureBox1.Image = MTempBinary 是不合法的
            PictureBox1.Image = Image.FromStream(MTempStream)
        End If

        ' 關閉 存取資料庫的相關物件
        'ODataAdapter_1.Dispose()
        Ocn_1.Close()
        Ocn_1.Dispose()
        ' 此處不關閉記憶體串流物件，以免出現『在 GDI+ 中發生泛型錯誤』的訊息
        'MTempStream.Close()

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As SqlInt32 = DataGridView1.CurrentCellAddress.Y + 1
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

    ' 修改
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click

        ' 檢查『資料編號』、『數量』、『單價』是否已輸入，此  3 項不得空白
        If Len(Trim(T_datano.Text)) = 0 Then
            MsgBox("Sorry, 『資料編號』未輸入！" + Chr(13) + Chr(13) + "請指定欲修改資料的編號", 0 + 16, "Error")
            Exit Sub
        End If
        ' 檢查『資料編號』是否為數字
        If IsNumeric(T_datano.Text) = False Then
            MsgBox("Sorry, 『資料編號』須為數字！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
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

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        Dim Mdatano As String = T_datano.Text
        ' 使用 資料轉接器 更新 SQL Server 資料庫，不使用 SqlCommand 物件 ◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆
        ' 建立無資料的資料轉接器與資料集
        Dim Msqlstr_1 As String = "Select * From TEST01 Where datano='" + Mdatano + "'"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)
        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' Rows.Count  屬性可傳回資料表的筆數
        If ODataSet_1.Tables("Table01").Rows.Count = 1 Then
            ODataSet_1.Tables("Table01").Rows(0)(0) = Mdatano
            ODataSet_1.Tables("Table01").Rows(0)(1) = T_description.Text
            ODataSet_1.Tables("Table01").Rows(0)(2) = Val(T_qty.Text)
            ODataSet_1.Tables("Table01").Rows(0)(3) = Val(T_price.Text)
            ODataSet_1.Tables("Table01").Rows(0)(4) = Math.Round(Val(T_qty.Text) * Val(T_price.Text), 2)
            ODataSet_1.Tables("Table01").Rows(0)(5) = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

            ' 圖片處理亦透過資料轉接器而不使用 SqlCommand 物件
            ' 先偵測 User 是否指定圖片，若無，則給予 Null
            If Len(Trim(T_Path.Text)) = 0 Then
                ODataSet_1.Tables("Table01").Rows(0)(6) = DBNull.Value
            Else
                Dim Apicturedata() As Byte = Nothing
                Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.Read)
                Dim Mlength As Double = O_FileStream.Length
                If Mlength > 5242880 Then
                    MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                    Ocn_1.Close()
                    Ocn_1.Dispose()
                    Exit Sub
                End If

                Dim O_BinaryReader As New BinaryReader(O_FileStream)
                Apicturedata = O_BinaryReader.ReadBytes(5242880)
                ODataSet_1.Tables("Table01").Rows(0)(6) = Apicturedata

                ' 關閉資料流物件
                O_BinaryReader.Close()
                O_FileStream.Close()
            End If
        Else
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲修改資料的編號。", 0 + 16, "Error")
            Ocn_1.Close()
            Ocn_1.Dispose()
            Exit Sub
        End If

        ' 使用 SqlCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 SqlCommandBuilder 令建構物件的 GetUpdateCommand 方法，以便產生更新資料所需的 SqlCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New SqlCommandBuilder(ODataAdapter_1)
        O_CB1.GetUpdateCommand()
        Dim MAffectedNO As Integer = ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()
        MsgBox("資料已修改！" + Chr(13) + Chr(10) + "敲『查詢』鈕，可查看修改的結果。", 0 + 64, "OK")
        ' 清空文字盒，以方便下一筆資料的輸入
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""

    End Sub

    ' 刪除
    Private Sub B_Delete_Click(sender As Object, e As EventArgs) Handles B_Delete.Click

        If Len(Trim(T_datano.Text)) = 0 Then
            MsgBox("『資料編號』未輸入！" + Chr(13) + Chr(10) + "請輸入欲刪除資料的編號。", 0 + 16, "Error")
            Exit Sub
        End If
        ' 檢查『資料編號』是否為數字
        If IsNumeric(T_datano.Text) = False Then
            MsgBox("Sorry, 『資料編號』須為數字！" + Chr(13) + Chr(13) + "請重新輸入", 0 + 16, "Error")
            Exit Sub
        End If

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        Dim Mdatano As String = T_datano.Text
        ' 使用 資料轉接器 更新 SQL Server 資料庫，不使用 SqlCommand 物件 ◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆
        ' 建立無資料的資料轉接器與資料集
        Dim Msqlstr_1 As String = "Select * From TEST01 Where datano='" + Mdatano + "'"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)
        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' Rows.Count  屬性可傳回資料表的筆數
        If ODataSet_1.Tables("Table01").Rows.Count = 1 Then
            ODataSet_1.Tables("Table01").Rows(0).Delete()
        Else
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲刪除資料的編號。", 0 + 16, "Error")
            Ocn_1.Close()
            Ocn_1.Dispose()
            Exit Sub
        End If

        ' 使用 SqlCommandBuilder 建構函式產生新的命令建構物件，以便調解 DataSet 的變更和相關的資料庫，括號內為含有欲變動資料之轉接器
        ' 使用 SqlCommandBuilder 令建構物件的 GetDeleteCommand 方法，以便產生刪除資料所需的 SqlCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New SqlCommandBuilder(ODataAdapter_1)
        O_CB1.GetDeleteCommand()
        Dim MAffectedNO As Integer = ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 清空文字盒，以方便下一筆資料的輸入
        T_datano.Text = ""
        T_description.Text = ""
        T_qty.Text = ""
        T_price.Text = ""
        T_Path.Text = ""
        T_FileName.Text = ""
        T_FileSize.Text = ""
        MsgBox("資料已刪除！", 0 + 64, "OK")

    End Sub

    ' 將 NULL 值插入 SQL Server 需使用 System.Data.SqlTypes 命名空間的相關類別
    ' 判斷讀出的資料是否為 NULL 值 可使用  IsDBNull 函式 或 DBNull.Value.Equals 方法 或 Convert.IsDBNull 方法
    Private Sub B_NULL_Click(sender As Object, e As EventArgs) Handles B_NULL.Click

        ' 第一段 ************************************************************************************
        ' 自 SQL Server 抓出最大編號，以便編制新資料的編號，編號為 Int 型態，由 1～2,147,483,647
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_0 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_0 As New SqlConnection(Mcnstr_0)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_0.Open()

        ' 宣告 SQL 命令變數，以供後續  SqlCommand 物件使用
        Dim Msqlstr_0 As String = "Select MAX(datano) From TEST01"

        ' 以 SqlCommand 建構函式始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_0 As New SqlCommand(Msqlstr_0, Ocn_0)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入  SqlDataReader 資料讀取物件
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_0 As SqlDataReader
        Odataread_0 = Ocmd_0.ExecuteReader()

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 配合後續 DataTable 的資料型別（無 SqlInt32），改用 Int32 ***********************************
        'Dim Mdatano As SqlInt32 = 0
        Dim Mdatano As Int32 = 0
        Do While Odataread_0.Read() = True
            If IsDBNull(Odataread_0.Item(0)) = True Then
                Mdatano = 1
            Else
                Mdatano = Odataread_0.GetSqlInt32(0) + 1
            End If
        Loop

        ' 關閉資料處理相關物件
        Odataread_0.Close()
        Ocmd_0.Dispose()
        Ocn_0.Close()
        Ocn_0.Dispose()

        ' 第二段 ************************************************************************************
        '將 NULL 值插入 SQL Server 
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 使用 資料轉接器 更新 SQL Server 資料庫，不使用 SqlCommand 物件 ◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆
        ' 建立無資料的資料轉接器與資料集
        Dim Msqlstr_1 As String = "Select * From TEST01 Where datano<1"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)
        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將 User 輸入值存入資料列
        Dim O_NewRow As DataRow
        O_NewRow = ODataSet_1.Tables("Table01").NewRow()

        O_NewRow("datano") = Mdatano
        O_NewRow("description") = DBNull.Value
        O_NewRow("qty") = DBNull.Value
        O_NewRow("price") = DBNull.Value
        O_NewRow("amt") = DBNull.Value
        O_NewRow("datatime") = DBNull.Value
        O_NewRow("pic01") = DBNull.Value

        ' 將資料列併入資料集
        ODataSet_1.Tables("Table01").Rows.Add(O_NewRow)
        O_NewRow.AcceptChanges()
        O_NewRow.SetAdded()

        ' 更新 SQL Server 資料庫
        ' 使用 SqlCommandBuilder 令建構物件的 GetInsertCommand 方法，以便產生插入資料所需的 SqlCommand 命令物件
        ' 使用 DataAdapter 資料轉接器的 Update 方法來呼叫 INSERT、UPDATE 或 DELETE 陳述式
        Dim O_CB1 As New SqlCommandBuilder(ODataAdapter_1)
        O_CB1.GetInsertCommand(True)
        ODataAdapter_1.Update(ODataSet_1, "Table01")
        O_CB1.Dispose()

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()
        MsgBox("Null 資料已新增！" + Chr(13) + Chr(10) + "敲『查詢』鈕，可查看新增的結果。", 0 + 64, "OK")

    End Sub

    ' 載入本表單時，讀出 SQL Server 的登入資訊，並存入公用變數，以利後續各個程序使用
    Private Sub F_SQL01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 清空資料格控制項
        DataGridView1.DataSource = Nothing
        T_RecordNo.Text = "記錄數： 0"

        ' 加入虛擬欄位
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("a", "資料編號")
            DataGridView1.Columns.Add("b", "說明")
            DataGridView1.Columns.Add("c", "數量")
            DataGridView1.Columns.Add("d", "單價")
            DataGridView1.Columns.Add("e", "金額")
            DataGridView1.Columns.Add("e", "資料建立時間")
        End If

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 清除圖片盒()
        PictureBox1.Image = Nothing
        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

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