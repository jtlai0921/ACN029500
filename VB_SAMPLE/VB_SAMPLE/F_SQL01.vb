Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class F_SQL01
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

        ' 第二段 ************************************************************************************
        ' 自 SQL Server 抓出最大編號，以便編制新資料的編號，編號為 Int 型態，由 1～2,147,483,647
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
        ' SqlDataReader 的 Item 屬性可取回某一行的資料，括號內可為欄位順序（由 0 起算）或欄名
        ' 從 SqlDataReader 讀出的資料需轉換型別才能運算，轉換資料型別的方式如下例，使用 Val函數 或 GetSqlInt32 方法，
        ' 該方法可取得資料並作型別轉換，速度較快，
        ' GetSqlInt32 是 SQL Server 專用方法，如果 DataReader 的資料來自 Access 或 Excel，則需使用 GetInt32、GetString 等方法
        ' 取出 SqlDataReader 物件的資料必須使用 Read 方法循序讀取，開始取出 SqlDataReader 的資料時，記錄指標位於檔頭，
        ' 故即使 SqlDataReader 只有一筆資料也無法直接使用 DataRead.Item(0) 取回資料，而必須置於迴圈中以 Read 方法讀取，否則讀不到任何資料
        ' SqlDataReader 的 Read 方法傳回 False 表示已至檔尾
        ' SqlDataReader 的 HasRows 屬性可判斷 DataRead 物件中是否有資料，但不適用於本案例，因為 Select MAX() 指令一定會抓出資料，至少會是 Null
        Dim Mdatano As SqlInt32 = 0

        'If Odataread_0.HasRows = True Then
        'Do While Odataread_0.Read() = True
        'Mdatano = Val(Odataread_0.Item(0)) + 1
        'Mdatano = Odataread_0.GetSqlInt32(0) + 1
        'Loop
        'Else
        'Mdatano = 1
        'End If

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
        Ocmd_0.Cancel()
        Ocn_0.Close()
        Ocn_0.Dispose()

        ' 第三段 ************************************************************************************
        ' 將 User 輸入值存入變數
        ' 型態 SqlInt32 表示 32 位元整數，最大值為  2,147,483,647
        ' Int16.MaxValue 欄位 表示 Int16 的最大可能值。  這個欄位是常數。這個常數的值為  32,767
        ' Int32.MaxValue 欄位 表示 Int32 的最大可能值。  這個欄位是常數。這個常數的值為 2,147,483,647
        ' Int64.MaxValue 欄位 表示 Int64 的最大可能值。  這個欄位是常數。這個常數的值為  9,223,372,036,854,775,807
        ' Single.MaxValue 欄位 表示 Single 的最大可能值。  這個欄位是常數。這個常數的值為   3.402823e38
        ' Double.MaxValue 欄位 表示 Double 的最大可能值。  這個欄位是常數。這個常數的值為  1.7976931348623157E+308
        Dim Mdescription As String = Trim(T_description.Text)
        'Dim Mqty As SqlInt32 = Val(T_qty.Text)
        Dim Mqty As Double = Val(T_qty.Text)
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

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Insert into TEST01(datano,description,qty,price,amt,datatime,pic01) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7)"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 用 SQLCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
        ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
        ' Clear 方法可清除 Parameters
        Ocmd_1.Parameters.Clear()
        Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.Int).Value = Mdatano
        Ocmd_1.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = Mdescription
        Ocmd_1.Parameters.AddWithValue("@t3", SqlDbType.Int).Value = Mqty
        Ocmd_1.Parameters.AddWithValue("@t4", SqlDbType.Decimal).Value = Mprice
        Ocmd_1.Parameters.AddWithValue("@t5", SqlDbType.Float).Value = Mamt
        Ocmd_1.Parameters.AddWithValue("@t6", SqlDbType.DateTime).Value = DateTime.Now

        'Ocmd_1.Parameters.AddWithValue("@t1", Mdatano)
        'Ocmd_1.Parameters.AddWithValue("@t2", Mdescription)
        'Ocmd_1.Parameters.AddWithValue("@t3", Mqty)
        'Ocmd_1.Parameters.AddWithValue("@t4", Mprice)
        'Ocmd_1.Parameters.AddWithValue("@t5", Mamt)
        'Ocmd_1.Parameters.AddWithValue("@t6", DateTime.Now)

        ' 先偵測 User 是否指定圖片，若無，則給予 Null（ 詳　B_NULL_Click 事件內的說明）
        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t7", SqlDbType.VarBinary).Value = SqlBinary.Null
            'Ocmd_1.Parameters.AddWithValue("@t7", SqlBinary.Null)
        Else
            ' 宣告位元組陣列，以便儲存二進位資料
            Dim Apicturedata() As Byte = Nothing
            ' 根據 FileStream 類別建立相關物件，以便處理二進位資料
            ' 使用 FileStream 類別需引用命名空間 System.IO
            ' 以 New 關鍵字作 O_FileStream 新物件的初始化（建構函式），括號內3個參數依序為來源檔之路徑、建立模式 （有 Append、Create、Open等）、處理模式（有 Read、ReadWrite、Write三種）
            Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.Read)
            ' 使用 Length 屬性檢查檔案的大小（本例限 5 MB）
            Dim Mlength As Double = O_FileStream.Length
            If Mlength > 5242880 Then
                MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                Exit Sub
            End If

            Dim O_BinaryReader As New BinaryReader(O_FileStream)
            ' 使用 ReadBytes 方法讀取二進位資料，並存入位元組陣列，括號內為欲讀取的位元組數，不能超過 2 GB，最大值為 2,147,483,647
            Apicturedata = O_BinaryReader.ReadBytes(5242880)

            Ocmd_1.Parameters.AddWithValue("@t7", SqlDbType.VarBinary).Value = Apicturedata
            'Ocmd_1.Parameters.AddWithValue("@t7", Apicturedata)

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，將資料存入 SQL Server
        Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
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

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Update TEST01 Set description=@t1,qty=@t2,price=@t3,amt=@t4,datatime=@t5,pic01=@t6 Where datano=" + "'" + Trim(T_datano.Text) + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        Ocmd_1.Parameters.Clear()
        If Len(Trim(T_description.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.NChar).Value = SqlChars.Null
            'Ocmd_1.Parameters.AddWithValue("@t1", SqlChars.Null)
        Else
            Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.NChar).Value = T_description.Text
            'Ocmd_1.Parameters.AddWithValue("@t1", T_description.Text)
        End If
        Ocmd_1.Parameters.AddWithValue("@t2", SqlDbType.Int).Value = Val(T_qty.Text)
        Ocmd_1.Parameters.AddWithValue("@t3", SqlDbType.NVarChar).Value = Val(T_price.Text)
        Ocmd_1.Parameters.AddWithValue("@t4", SqlDbType.Float).Value = Math.Round(Val(T_price.Text) * Val(T_qty.Text), 2)
        Ocmd_1.Parameters.AddWithValue("@t5", SqlDbType.DateTime).Value = DateTime.Now

        ' 若未選圖片，則給予 Null
        ' 要在 VarBinary 或 Image 欄置入 Null，需使用 SqlBinary.Null，不能使用 DBNull.Value，但須引用 System.Data.SqlTypes 命名空間，
        ' 使用這個命名空間內的類別，有助於防止因精確度喪失所造成的型別轉換錯誤，微軟將 SqlBinary、SqlChars等稱之為結構，是 .Net Framework 的 SqlType（SQL Server 資料類型）
        ' SqlBinary 對應的欄位型別 binary、image、timestamp、varbinary
        ' SqlChars 對應的欄位型別 char、nchar、text、ntext、nvarchar、varchar
        ' SqlDecimal 對應的欄位型別 numeric、decimal 
        ' SqlDouble 對應的欄位型別 float
        ' SqlInt32 對應的欄位型別 Int
        ' SqlDateTime 對應的欄位型別 datetime、smalldatetime

        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t6", SqlDbType.VarBinary).Value = SqlBinary.Null
        Else
            ' 宣告位元組陣列，以便儲存二進位資料
            Dim Apicturedata() As Byte = Nothing
            ' 根據 FileStream 類別建立相關物件，以便處理二進位資料
            ' 以 New 關鍵字作 O_FileStream 新物件的初始化，括號內3個參數依序為來源檔之路徑、建立模式 （有 Append、Create、Open等）、處理模式（有 Read、ReadWrite、Write三種）
            Dim O_FileStream As New FileStream(T_Path.Text, FileMode.Open, FileAccess.ReadWrite)
            ' 使用 Length 屬性檢查檔案的大小（本例限 5 MB）
            Dim Mlength As Double = O_FileStream.Length
            If Mlength > 5242880 Then
                MsgBox("檔案太大！" + Chr(13) + Chr(13) + "請重新選檔（限 5 MB）", 0 + 16, "Error")
                Exit Sub
            End If

            Dim O_BinaryReader As New BinaryReader(O_FileStream)
            ' 使用 ReadBytes 方法讀取二進位資料，並存入位元組陣列
            Apicturedata = O_BinaryReader.ReadBytes(5242880)

            Ocmd_1.Parameters.AddWithValue("@t6", SqlDbType.VarBinary).Value = Apicturedata

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult As Integer = Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
        Ocn_1.Close()
        Ocn_1.Dispose()
        If MupdateResult = 1 Then
            MsgBox("資料已修改！" + Chr(13) + Chr(10) + "敲『查詢』鈕，可查看修改的結果。", 0 + 64, "OK")
            ' 清空文字盒，以方便下一筆資料的輸入
            T_datano.Text = ""
            T_description.Text = ""
            T_qty.Text = ""
            T_price.Text = ""
            T_Path.Text = ""
            T_FileName.Text = ""
            T_FileSize.Text = ""
        Else
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲修改資料的編號。", 0 + 16, "Error")
        End If

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

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Delete From TEST01 Where datano=" + "'" + Trim(T_datano.Text) + "'"
        ' 以 SslCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 執行非查詢指令，將資料存入 SQL Server
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未刪除任何資料
        Dim MdeleteResult As Integer = Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
        Ocn_1.Close()
        Ocn_1.Dispose()
        If MdeleteResult = 1 Then
            ' 重抓資料並更新 dataGridView
            Dim Mcnstr_2 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"
            Dim Ocn_2 As New SqlConnection(Mcnstr_2)
            Ocn_2.Open()
            Dim Msqlstr_2 As String = "Select datano,description,qty,price,amt,datatime From TEST01"
            Dim ODataAdapter_2 As New SqlDataAdapter(Msqlstr_2, Ocn_2)
            Dim ODataSet_2 As DataSet = New DataSet
            ODataAdapter_2.Fill(ODataSet_2, "Table01")
            If DataGridView1.Columns.Count <> 0 Then
                DataGridView1.Columns.RemoveAt(5)
                DataGridView1.Columns.RemoveAt(4)
                DataGridView1.Columns.RemoveAt(3)
                DataGridView1.Columns.RemoveAt(2)
                DataGridView1.Columns.RemoveAt(1)
                DataGridView1.Columns.RemoveAt(0)
            End If
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = ODataSet_2.Tables("Table01")
            Ocn_2.Close()
            Ocn_2.Dispose()
            MTotalRecordNo = ODataSet_2.Tables("Table01").Rows.Count
            T_RecordNo.Text = "記錄數： 1 / " + MTotalRecordNo.ToString
            With DataGridView1
                .Columns(0).HeaderText = "資料編號"
                .Columns(1).HeaderText = "說明"
                .Columns(2).HeaderText = "數量"
                .Columns(3).HeaderText = "單價"
                .Columns(4).HeaderText = "金額"
                .Columns(5).HeaderText = "資料建立時間"
            End With
            With DataGridView1
                .Columns(2).DefaultCellStyle.Format = "#,0"
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = "#,0.00"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).DefaultCellStyle.Format = "#,0.00"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Dim mtprow As Object
            For Each mtprow In DataGridView1.Rows
                mtprow.Height = 24
            Next mtprow
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            DataGridView1.ColumnHeadersHeight = 28
            DataGridView1.AllowUserToAddRows = False

            ' 清空文字盒，以方便下一筆資料的輸入
            T_datano.Text = ""
            T_description.Text = ""
            T_qty.Text = ""
            T_price.Text = ""
            T_Path.Text = ""
            T_FileName.Text = ""
            T_FileSize.Text = ""
            MsgBox("資料已刪除！", 0 + 64, "OK")
        Else
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲刪除資料的編號。", 0 + 16, "Error")
        End If

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
        Dim Mdatano As SqlInt32 = 0
        Do While Odataread_0.Read() = True
            If IsDBNull(Odataread_0.Item(0)) = True Then
                Mdatano = 1
            Else
                Mdatano = Odataread_0.GetSqlInt32(0) + 1
            End If
        Loop

        ' 關閉資料處理相關物件
        Odataread_0.Close()
        Ocmd_0.Cancel()
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

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Insert into TEST01(datano,description,qty,price,amt,datatime,pic01) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7)"
        ' 以 SslCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 用 SQLCommand 物件 的 Parameters 屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 欲賦予 SQL Server 資料表 Null 值須使用其資料型別的 Null 屬性，例如文字欄需以 SqlChars.Null 指定、整數欄需以 SqlInt32.Null 指定、日期時間欄需以 SqlDateTime.Null 指定、
        ' 二進位欄需以 SqlBinary.Null 指定、固定位數數值欄需以  SqlDecimal.Null 指定
        Ocmd_1.Parameters.AddWithValue("@t1", SqlDbType.Int).Value = Mdatano
        Ocmd_1.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = SqlChars.Null
        Ocmd_1.Parameters.AddWithValue("@t3", SqlDbType.Int).Value = SqlInt32.Null
        Ocmd_1.Parameters.AddWithValue("@t4", SqlDbType.Decimal).Value = SqlDecimal.Null
        Ocmd_1.Parameters.AddWithValue("@t5", SqlDbType.Float).Value = SqlDouble.Null
        Ocmd_1.Parameters.AddWithValue("@t6", SqlDbType.DateTime).Value = SqlDateTime.Null
        Ocmd_1.Parameters.AddWithValue("@t7", SqlDbType.VarBinary).Value = SqlBinary.Null

        ' 執行非查詢指令，將資料存入 SQL Server
        Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Cancel()
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