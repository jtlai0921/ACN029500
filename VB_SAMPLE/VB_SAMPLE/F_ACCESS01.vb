Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_ACCESS01
    ' 宣告公用變數以便儲存來源檔及OleDB資料提供者
    Public MDATANAME As String = "APPDATA\VBACCESSDB.accdb"
    Public MSTRconn_0 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
    'Public MSTRconn_0 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=APPDATA\VBACCESSDB.accdb"
    'Public MSTRconn_0 As String = "provider=Microsoft.Jet.OLEDB.4.0;data source=" + MDATANAME

    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As Int32 = 0
    ' --------------------------------------------------------------------------------------------------------------------------------------------

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

        ' 第二段 ************************************************************************************
        ' 自 Access 資料庫抓出最大編號，以便編制新資料的編號
        ' 連結資料庫
        Dim Oconn_0 As New OleDbConnection(MSTRconn_0)
        Oconn_0.Open()

        ' 宣告 SQL 命令變數，以供後續下  OleDbCommand 物件使用
        Dim Msqlstr_0 As String = "Select MAX(datano) From TEST01"

        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_0 As New OleDbCommand(Msqlstr_0, Oconn_0)

        ' 使用 OleDbCommand 的 ExecuteReader 方法將讀出的資料存入 OleDbDataReader 資料讀取物件
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_0 As OleDbDataReader
        Odataread_0 = Ocmd_0.ExecuteReader()

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 資料編號固定為 6 碼，由 A00001～Z99999，最多可產生 259 萬 9974 個編號
        ' OleDbDataReader 的 Item 屬性可取回某一行的資料，括號內可為欄位順序（由 0 起算）或欄名
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

        Do While Odataread_0.Read() = True
            If IsDBNull(Odataread_0.Item(0)) = True Then
                Mdatano = "A00001"
            Else
                If Odataread_0.Item(0) = "Z99999" Then
                    MsgBox("資料編號已到頂，無法新增！" + Chr(13) + Chr(10) + "請先清空資料表，再新增資料。", 0 + 64, "Attention")
                    Exit Sub
                End If
                MSerialNo = Conversion.Val(Strings.Right(Odataread_0.Item(0), 5)) + 1
                If MSerialNo <= 99999 Then
                    MPreCode = Strings.Left(Odataread_0.Item(0), 1)
                    MLen = Strings.Len(MSerialNo.ToString)
                    Mdatano = MPreCode + Strings.StrDup(5 - MLen, "0") + MSerialNo.ToString
                Else
                    MPreCode = Strings.Left(Odataread_0.Item(0), 1)
                    MPreCode = Strings.Chr(Strings.Asc(MPreCode) + 1)
                    Mdatano = MPreCode + "00001"
                End If
            End If
        Loop

        ' 關閉資料處理相關物件
        Odataread_0.Close()
        Ocmd_0.Cancel()
        Oconn_0.Close()
        Oconn_0.Dispose()

        ' 第三段 ************************************************************************************
        ' 將 User 輸入值存入變數
        Dim Mdescription As String = Trim(T_description.Text)
        Dim Mqty As Int32 = Val(T_qty.Text)
        Dim Mprice As Double = Val(T_price.Text)
        Dim Mamt As Double = Math.Round(Mprice * Mqty, 2)

        ' 第四段 ************************************************************************************
        ' 將新資料存入 Access
        ' 連結資料庫()
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Insert into TEST01(datano,description,qty,price,amt,datatime,pic01) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7)"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New OleDbCommand(Msqlstr_1, Oconn_1)

        ' 用 OleDbCommand 物件 的 Parameters 參數屬性 的 AddWithValue 方法來匯整欲新增的欄位資料
        ' 下列兩種方式均可，第一種方式在 AddWithValue 括號內指定具名參數及資料型別，再以 Value 屬性指定來源資料，
        ' 第二種方式在 AddWithValue 括號內指定具名參數及料來源
        ' 日期時間型態需轉為文字，才能插入 Access
        ' Clear 方法可清除 Parameters
        Ocmd_1.Parameters.Clear()
        Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = Mdatano
        Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = Mdescription
        Ocmd_1.Parameters.AddWithValue("@t3", DbType.Int32).Value = Mqty
        Ocmd_1.Parameters.AddWithValue("@t4", DbType.Double).Value = Mprice
        Ocmd_1.Parameters.AddWithValue("@t5", DbType.Double).Value = Mamt
        Ocmd_1.Parameters.AddWithValue("@t6", DbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        'Ocmd_1.Parameters.AddWithValue("@t1", Mdatano)
        'Ocmd_1.Parameters.AddWithValue("@t2", Mdescription)
        'Ocmd_1.Parameters.AddWithValue("@t3", Mqty)
        'Ocmd_1.Parameters.AddWithValue("@t4", Mprice)
        'Ocmd_1.Parameters.AddWithValue("@t5", Mamt)
        'Ocmd_1.Parameters.AddWithValue("@t6", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))

        ' 先偵測 User 是否指定圖片，若無，則給予 Null（ 詳　B_NULL_Click 事件內的說明）
        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t7", DbType.Object).Value = DBNull.Value
            'Ocmd_1.Parameters.AddWithValue("@t7", DBNull.Value)
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
            ' 使用 ReadBytes 方法讀取二進位資料，並存入位元組陣列，括號內為欲讀取的位元組數
            Apicturedata = O_BinaryReader.ReadBytes(5242880)

            Ocmd_1.Parameters.AddWithValue("@t7", DbType.Binary).Value = Apicturedata
            'Ocmd_1.Parameters.AddWithValue("@t7", Apicturedata)

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，將資料存入 Access
        Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()
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
        Dim MTempNo As String = ""
        If Strings.Len(T_datano.Text) <> 6 Then
            MTempNo = ""
        Else
            MTempNo = Strings.UCase(Strings.Trim(T_datano.Text))
        End If

        ' 連結資料庫
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
        ' SQL 指令視 User 是否輸入資料編號而分為兩種
        Dim Msqlstr_1 As String = ""
        If MTempNo = "" Then
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01"
        Else
            Msqlstr_1 = "Select datano,description,qty,price,amt,datatime From TEST01 Where datano=" + "'" + MTempNo + "'"
        End If

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)

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
        Oconn_1.Close()
        Oconn_1.Dispose()
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

    ' DataGridView 選取變動事件中傳回游標所在列資料的圖片
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        ' 取回游標所在列的資料編號，以便作為後續 SQL指令之查詢條件
        Dim MTempNO As String = ""
        MTempNO = DataGridView1.CurrentRow.Cells(0).Value

        ' 連結資料庫
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select pic01 From TEST01 Where datano='" + MTempNO + "'"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料表
        'Dim O_dtable_1 As New DataTable
        'ODataAdapter_1.Fill(O_dtable_1)

        ' 需先判斷 User 所指定的編號是否存在
        'If O_dtable_1.Rows.Count = 0 Then
        'Exit Sub
        'End If

        If ODataSet_1.Tables("Table01").Rows.Count = 0 Then
            Exit Sub
        End If

        '  FileStream 檔案串流（或稱為資料流）是 .Net Framework 所提供的物件，用以存取檔案（包括文字檔及二進位檔）
        ' 宣告位元組陣列，並將資料表第1列第1行的資料（即前述已讀出的圖片）存入其中
        ' 判斷讀出的資料是否為 NULL 值 可使用  IsDBNull 函式 或 DBNull.Value.Equals 方法 或 Convert.IsDBNull 方法，範例如下
        If IsDBNull(ODataSet_1.Tables("Table01").Rows(0)(0)) = True Then
            'If IsDBNull(O_dtable_1.Rows(0)(0)) = True Then
            'If DBNull.Value.Equals(O_dtable_1.Rows(0)(0)) Then
            'If Convert.IsDBNull(O_dtable_1.Rows(0)(0)) = True Then
            PictureBox1.Image = Nothing
        Else
            Dim MTempBinary As Byte() = ODataSet_1.Tables("Table01").Rows(0)(0)
            'Dim MTempBinary As Byte() = O_dtable_1.Rows(0)(0)
            ' 依據 MemoryStream 記憶體串流建立新的物件，以便將資料直接存到實體檔，括號內為元組陣列
            Dim MTempStream As MemoryStream = New MemoryStream(MTempBinary)
            ' 使用 Image.FromStream 方法將記憶體串流物件指定給圖片盒，不能直接將位元組陣列指定給圖片盒，例如  PictureBox1.Image = MTempBinary 是不合法的
            PictureBox1.Image = Image.FromStream(MTempStream)
        End If

        ' 關閉 存取資料庫的相關物件
        Oconn_1.Close()
        Oconn_1.Dispose()
        ' 此處不關閉記憶體串流物件，以免出現『在 GDI+ 中發生泛型錯誤』的訊息
        'MTempStream.Close()

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

    ' 修改
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click

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

        ' 連結資料庫()
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 使用 Strings 類別的 UCase 方法將資料編號轉成大寫
        Dim MCheckNo As String = Strings.UCase(Strings.Trim(T_datano.Text))
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Update TEST01 Set description=@t1,qty=@t2,price=@t3,amt=@t4,datatime=@t5,pic01=@t6 Where datano=" + "'" + MCheckNo + "'"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New OleDbCommand(Msqlstr_1, Oconn_1)

        Ocmd_1.Parameters.Clear()
        If Len(Trim(T_description.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = DBNull.Value
            'Ocmd_1.Parameters.AddWithValue("@t1", DBNull.Value)
        Else
            Ocmd_1.Parameters.AddWithValue("@t1", DbType.String).Value = T_description.Text
            'Ocmd_1.Parameters.AddWithValue("@t1", T_description.Text)
        End If
        Ocmd_1.Parameters.AddWithValue("@t2", DbType.Int32).Value = Val(T_qty.Text)
        Ocmd_1.Parameters.AddWithValue("@t3", DbType.Double).Value = Val(T_price.Text)
        Ocmd_1.Parameters.AddWithValue("@t4", DbType.Double).Value = Math.Round(Val(T_price.Text) * Val(T_qty.Text), 2)
        Ocmd_1.Parameters.AddWithValue("@t5", DbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        ' 若未選圖片，則給予 Null
        If Len(Trim(T_Path.Text)) = 0 Then
            Ocmd_1.Parameters.AddWithValue("@t6", DbType.Object).Value = DBNull.Value
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

            Ocmd_1.Parameters.AddWithValue("@t6", DbType.Object).Value = Apicturedata

            ' 關閉資料流物件
            O_BinaryReader.Close()
            O_FileStream.Close()
        End If

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult As Integer = Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()
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
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲修改資料的編號（例如 A00005）。", 0 + 16, "Error")
        End If

    End Sub

    ' 刪除
    Private Sub B_Delete_Click(sender As Object, e As EventArgs) Handles B_Delete.Click

        If Len(Trim(T_datano.Text)) <> 6 Then
            MsgBox("『資料編號』未輸入或不正確！" + Chr(13) + Chr(10) + "請輸入欲刪除資料的編號（例如 A00005）。", 0 + 16, "Error")
            Exit Sub
        End If

        ' 連結資料庫()
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 使用 Strings 類別的 UCase 方法將資料編號轉成大寫
        Dim MCheckNo As String = Strings.UCase(Strings.Trim(T_datano.Text))
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Delete From TEST01 Where datano=" + "'" + MCheckNo + "'"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New OleDbCommand(Msqlstr_1, Oconn_1)

        ' 執行非查詢指令，將資料存入 SQL Server
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未刪除任何資料
        Dim MdeleteResult As Integer = Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Dispose()
        Oconn_1.Close()
        Oconn_1.Dispose()

        If MdeleteResult = 1 Then
            ' 重抓資料並更新 dataGridView
            Dim Oconn_2 As New OleDbConnection(MSTRconn_0)
            Oconn_2.Open()

            Dim Msqlstr_2 As String = "Select datano,description,qty,price,amt,datatime From TEST01"
            Dim ODataAdapter_2 As New OleDbDataAdapter(Msqlstr_2, Oconn_2)
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
            Oconn_2.Close()
            Oconn_2.Dispose()

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
            MsgBox("資料編號不存在！" + Chr(13) + Chr(10) + "請重新輸入欲刪除資料的編號（例如 A00005）。", 0 + 16, "Error")
        End If
    End Sub

    ' 將 NULL 值插入 Access
    ' 判斷讀出的資料是否為 NULL 值 可使用  IsDBNull 函式 或 DBNull.Value.Equals 方法 或 Convert.IsDBNull 方法
    Private Sub B_NULL_Click(sender As Object, e As EventArgs) Handles B_NULL.Click

        ' 第一段 ************************************************************************************
        ' 自 Access 抓出最大編號，以便編制新資料的編號
        ' 連結資料庫
        Dim Oconn_0 As New OleDbConnection(MSTRconn_0)
        Oconn_0.Open()

        ' 宣告 SQL 命令變數，以供後續下  OleDbCommand 物件使用
        Dim Msqlstr_0 As String = "Select MAX(datano) From TEST01"

        ' 以 OleDbCommand 建構函式始化新的執行個體（新物件名為 Ocmd_0），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_0 As New OleDbCommand(Msqlstr_0, Oconn_0)

        ' 使用 OleDbDataReader 的 ExecuteReader 方法將讀出的資料存入 OleDbDataReader 資料讀取物件
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_0 As OleDbDataReader
        Odataread_0 = Ocmd_0.ExecuteReader()

        ' 將前述讀出資料（即最大資料編號）存入變數 Mdatano
        ' 資料編號固定為 6 碼，由 A00001～Z99999，最多可產生 259 萬 9974 個編號
        ' OleDbDataReader 的 Item 屬性可取回某一行的資料，括號內可為欄位順序（由 0 起算）或欄名
        Dim MPreCode As String = ""
        Dim MSerialNo As String = ""
        Dim MLen As Integer = 0
        Dim Mdatano As String = ""

        Do While Odataread_0.Read() = True
            If IsDBNull(Odataread_0.Item(0)) = True Then
                Mdatano = "A00001"
            Else
                If Odataread_0.Item(0) = "Z99999" Then
                    MsgBox("資料編號已到頂，無法新增！" + Chr(13) + Chr(10) + "請先清空資料表，再新增資料。", 0 + 64, "Attention")
                    Exit Sub
                End If
                MSerialNo = Conversion.Val(Strings.Right(Odataread_0.Item(0), 5)) + 1
                If MSerialNo <= 99999 Then
                    MPreCode = Strings.Left(Odataread_0.Item(0), 1)
                    MLen = Strings.Len(MSerialNo.ToString)
                    Mdatano = MPreCode + Strings.StrDup(5 - MLen, "0") + MSerialNo.ToString
                Else
                    MPreCode = Strings.Left(Odataread_0.Item(0), 1)
                    MPreCode = Strings.Chr(Strings.Asc(MPreCode) + 1)
                    Mdatano = MPreCode + "00001"
                End If
            End If
        Loop

        ' 關閉資料處理相關物件
        Odataread_0.Close()
        Ocmd_0.Cancel()
        Oconn_0.Close()
        Oconn_0.Dispose()

        ' 第二段 ************************************************************************************
        '將 NULL 值插入 Access
        ' 連結資料庫()
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_1 As String = "Insert into TEST01(datano,description,qty,price,amt,datatime,pic01) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7)"
        ' 以 OleDbCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New OleDbCommand(Msqlstr_1, Oconn_1)

        Ocmd_1.Parameters.Clear()
        Ocmd_1.Parameters.AddWithValue("@t1", DbType.Int32).Value = Mdatano
        Ocmd_1.Parameters.AddWithValue("@t2", DbType.String).Value = DBNull.Value
        Ocmd_1.Parameters.AddWithValue("@t3", DbType.Int32).Value = DBNull.Value
        Ocmd_1.Parameters.AddWithValue("@t4", DbType.Double).Value = DBNull.Value
        Ocmd_1.Parameters.AddWithValue("@t5", DbType.Double).Value = DBNull.Value
        Ocmd_1.Parameters.AddWithValue("@t6", DbType.DateTime).Value = DBNull.Value
        Ocmd_1.Parameters.AddWithValue("@t7", DbType.Object).Value = DBNull.Value

        ' 執行非查詢指令，將資料存入 Access
        Ocmd_1.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocmd_1.Cancel()
        Oconn_1.Close()
        Oconn_1.Dispose()
        MsgBox("Null 資料已新增！" + Chr(13) + Chr(10) + "敲『查詢』鈕，可查看新增的結果。", 0 + 64, "OK")

    End Sub

    ' 載入本表單時，讀出 SQL Server 的登入資訊，並存入公用變數，以利後續各個程序使用
    Private Sub F_ACCESS1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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