Imports System.IO
Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem

Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel

Imports OfficeOpenXml
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Chart
Imports OfficeOpenXml.Style

Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports GemBox.Spreadsheet
Imports GemBox.Spreadsheet.WinFormsUtilities
Imports GemBox.Spreadsheet.Charts

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Deployment.Application
Imports System
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Printing
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.Reporting.WinForms

Public Class F_Convert

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告公用變數以便儲存查詢結果的總筆數
    Public MTotalRecordNo As SqlInt32 = 0

    ' 宣告 O_PrintDocument 為 輸出到印表機的物件，必須使用 WithEvents 宣告該物件變數
    ' 若使用下列方式宣告將會發生錯誤：
    ' Public O_PrintDocument As Printing.PrintDocument
    ' 使用 WithEvents 宣告該物件變數，後續程式才可使用 Handles 關鍵字處理該物件變數的事件，亦即才能處理如下之 PrintPage 列印頁事件
    ' Private Sub O_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles O_PrintDocument.PrintPage
    Public WithEvents O_PrintDocument As Printing.PrintDocument

    ' 宣告 O_PrintPreview 為 預覽對話方塊物件
    Public O_PrintPreview As New PrintPreviewDialog

    Public WithEvents O_PrintDocument2 As Printing.PrintDocument
    Public O_PrintPreview2 As New PrintPreviewDialog
    Public MPrintNO As Integer = 0
    Public MStartNo As Integer = 0
    Public MStopNo As Integer = 0

    Public WithEvents O_PrintDocument3 As Printing.PrintDocument
    Public O_PrintPreview3 As New PrintPreviewDialog

    Public WithEvents O_PrintDocument5 As Printing.PrintDocument
    Public O_PrintPreview5 As New PrintPreviewDialog

    ' 正式版需在 SetLicense 括號內輸入序號
    Public Sub New()
        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
        InitializeComponent()

    End Sub

    ' 載入本表單
    Private Sub F_Convert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ReportViewer1.Visible = False
        B_NPOI_READ.Focus()
    End Sub

    ' 使用 GemBox 讀取 Excel、ODS、CSV、HTML 檔，並顯示於 DataGridView
    ' 必須引用 GemBox.Spreadsheet.WinFormsUtilities
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click

        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing

        ' 開啟檔案對話方塊
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm"
        OpenFileDialog1.FilterIndex = 2
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim O_ExcelFile = ExcelFile.Load(OpenFileDialog1.FileName)
            DataGridViewConverter.ExportToDataGridView(O_ExcelFile.Worksheets.ActiveWorksheet, Me.DataGridView1, New ExportToDataGridViewOptions() With {.ColumnHeaders = False})
        End If

    End Sub

    ' 使用 GemBox 將 DataGridView 的資料存檔，
    ' 存檔種類有 Excel、ODS、CSV、HTML、PDF 及 圖檔 
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click

        ' 先檢查 DataGridView 是否有資料可匯出
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可匯出！" + Chr(13) + Chr(13) + "請先敲『GemBox 讀取』", 0 + 16, "Error")
            Exit Sub
        End If

        ' 開啟存檔對話方塊
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm|XLTX (*.xltx)|*.xltx|XLTM (*.xltm)|*.xltm|ODS (*.ods)|*.ods|OTS (*.ots)|*.ots|CSV (*.csv)|*.csv|TSV (*.tsv)|*.tsv|HTML (*.html)|*.html|MHTML (.mhtml)|*.mhtml|PDF (*.pdf)|*.pdf|XPS (*.xps)|*.xps|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif|WMP (*.wdp)|*.wdp"
        SaveFileDialog1.FilterIndex = 3
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim O_ExcelFile = New ExcelFile
            Dim O_WS = O_ExcelFile.Worksheets.Add("Sheet1")
            DataGridViewConverter.ImportFromDataGridView(O_WS, Me.DataGridView1, New ImportFromDataGridViewOptions() With {.ColumnHeaders = False})
            O_ExcelFile.Save(SaveFileDialog1.FileName)
        End If

    End Sub

    '  使用 GemBox 產生統計圖
    '  需引用 GemBox.Spreadsheet.Charts
    ' ExcelWorksheet 與 EPPlus 物件衝突，故須註明命名空間 GemBox.Spreadsheet
    Private Sub B_B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click

        ' 若資料夾 D:\TestQuery 不存在，則建立之，以便儲存檔案
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 宣告 ExcelFile 物件
        Dim O_ExcelFile As ExcelFile = New ExcelFile
        ' 宣告工作表物件 O_WS，並使用 Add 方法新增工作表，括號內為工作表之名稱
        Dim O_WS As GemBox.Spreadsheet.ExcelWorksheet = O_ExcelFile.Worksheets.Add("統計圖")

        ' 使用工作表物件的 Charts.Add 新增圖表，括號內有 3 參數，第一個為圖表種類，Column 直條圖、Bar 橫條圖、Pie 圓餅圖、Line 折線圖，
        ' 第二個為圖表左上角位置，第三個為圖表右下角位置，後兩個參數可決定圖表的大小
        Dim O_chart = O_WS.Charts.Add(ChartType.Column, "B7", "I24")
        ' 使用 SelectData 方法指定圖表資料區，
        ' Cells.GetSubrangeAbsolute 方法可指定儲存格範圍，括號內有 4 參數，
        ' 第一個為起始列，第二個為起始行，第三個為終止列，第四個為終止行，亦即範圍左上角格位之行列代號及右下角格位的行列代號，行列代號均由 0 起算
        O_chart.SelectData(O_WS.Cells.GetSubrangeAbsolute(0, 0, 4, 1), True)

        ' 置入欄名，Cells 括號內為行列代號，前者為列，後者為行，均由 0 起算
        O_WS.Cells(0, 0).Value = "品名"
        O_WS.Cells(0, 1).Value = "數量"

        ' 置入資料
        O_WS.Cells(1, 0).Value = "香蕉"
        O_WS.Cells(2, 0).Value = "鳳梨"
        O_WS.Cells(3, 0).Value = "芒果"
        O_WS.Cells(4, 0).Value = "水蜜桃"
        O_WS.Cells(1, 1).Value = 2000
        O_WS.Cells(2, 1).Value = 1000
        O_WS.Cells(3, 1).Value = 2500
        O_WS.Cells(4, 1).Value = 3000

        ' 設定字型名稱
        O_WS.Cells.GetSubrangeAbsolute(0, 0, 0, 1).Style.Font.Name = "微軟正黑體"
        O_WS.Cells.GetSubrangeAbsolute(1, 0, 4, 0).Style.Font.Name = "新細明體"
        O_WS.Cells.GetSubrangeAbsolute(1, 1, 4, 1).Style.Font.Name = "Arila"
        ' 欄名字體加粗
        O_WS.Cells(0, 0).Style.Font.Weight = GemBox.Spreadsheet.ExcelFont.BoldWeight
        O_WS.Cells(0, 1).Style.Font.Weight = GemBox.Spreadsheet.ExcelFont.BoldWeight
        ' 設定字型大小（單位為 20分之1點）
        O_WS.Cells.GetSubrangeAbsolute(0, 0, 0, 1).Style.Font.Size = 16 * 20
        O_WS.Cells.GetSubrangeAbsolute(1, 0, 4, 1).Style.Font.Size = 12 * 20

        ' 數字加千分號
        O_WS.Cells.GetSubrangeAbsolute(1, 1, 4, 1).Style.NumberFormat = "#,##0"

        ' 使用 SetWidth 方法調整欄寬，括號內有兩個參數，第一個為大小，第二個為單位， Centimeter 公分、Millimeter 公厘、Pixel 像素、Point 點、1 Twip= 20分之1點、1 英吋=72點
        O_WS.Columns(0).SetWidth(72 * 0.9, LengthUnit.Point)
        O_WS.Columns(1).SetWidth(72 * 1.1, LengthUnit.Point)

        ' 使用 SetHeight 方法調整列高，括號內有兩個參數，第一個為大小，第二個為單位， Centimeter 公分、Millimeter 公厘、Pixel 像素、Point 點、1 Twip= 20分之1點、1 英吋=72點
        O_WS.Rows(0).SetHeight(24 * 20, LengthUnit.Twip)
        O_WS.Rows(1).SetHeight(18 * 20, LengthUnit.Twip)
        O_WS.Rows(2).SetHeight(18 * 20, LengthUnit.Twip)
        O_WS.Rows(3).SetHeight(18 * 20, LengthUnit.Twip)
        O_WS.Rows(4).SetHeight(18 * 20, LengthUnit.Twip)

        ' 調整列印大小為一張
        O_WS.PrintOptions.FitWorksheetWidthToPages = 1
        O_WS.PrintOptions.FitWorksheetHeightToPages = 1

        ' 存檔
        O_ExcelFile.Save("D:\TestQuery\Chart_01.xlsx")
        MsgBox("檔案 D:\TestQuery\Chart_01.xlsx 已產生！", 0 + 64, "OK")

    End Sub

    ' 使用 GemBox 將資料表匯出為 Excel 檔
    Private Sub B_05_Click(sender As Object, e As EventArgs) Handles B_05.Click

        ' 若資料夾 D:\TestQuery 不存在，則建立之，以便儲存檔案
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 宣告 ExcelFile 物件
        Dim O_ExcelFile As ExcelFile = New ExcelFile
        ' 宣告工作表物件 O_WS，並使用 Add 方法新增工作表，括號內為工作表之名稱
        Dim O_WS As GemBox.Spreadsheet.ExcelWorksheet = O_ExcelFile.Worksheets.Add("工作表1")

        ' 新增資料表 O_TempTable
        Dim O_TempTable As DataTable = New DataTable
        ' 加入欄位
        O_TempTable.Columns.Add("品名", Type.GetType("System.String"))
        O_TempTable.Columns.Add("數量", Type.GetType("System.Int32"))
        O_TempTable.Columns.Add("日期", Type.GetType("System.DateTime"))
        ' 將物件陣列的資料置入資料表
        O_TempTable.Rows.Add(New Object() {"香蕉", 100, "2015/06/01"})
        O_TempTable.Rows.Add(New Object() {"蓮霧", 200, "2015/06/02"})
        O_TempTable.Rows.Add(New Object() {"水蜜桃", 300, "2015/06/03"})
        O_TempTable.Rows.Add(New Object() {"西瓜", 400, "2015/06/04"})
        O_TempTable.Rows.Add(New Object() {"鳳梨", 500, "2015/06/05"})

        ' 將資料表資料顯示於 DataGridView
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 將表頭置入工作表A1格位
        O_WS.Cells(0, 0).Value = "水果銷售統計表"
        ' 使用 InsertDataTable 方法將資料表的資料置入工作表，由第三列開始（只需一列程式碼即可）
        O_WS.InsertDataTable(O_TempTable, New InsertDataTableOptions() With {.ColumnHeaders = True, .StartRow = 2})

        ' 存檔
        O_ExcelFile.Save("D:\TestQuery\GemBox_01.xlsx")
        MsgBox("檔案 D:\TestQuery\GemBox_01.xlsx 已產生！", 0 + 64, "OK")

    End Sub

    ' 使用 NPOI 建立新的活頁簿（ xls 檔）
    ' 使用  XSSFWorkbook 可順利建立 xlsx 檔，但可能無法讀取，
    ' 故欲建立 xlsx 檔，建議使用 EPPlus
    Private Sub B_NPOI_WRITE_Click(sender As Object, e As EventArgs) Handles B_NPOI_WRITE.Click

        ' 若資料夾 D:\TestQuery 不存在，則建立之，以便儲存匯出檔
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 宣告活頁簿 O_WorkBook
        Dim O_WorkBook As HSSFWorkbook = New HSSFWorkbook
        'Dim O_WorkBook As XSSFWorkbook = New XSSFWorkbook

        ' 新增工作表 O_Sheet
        Dim O_Sheet As HSSFSheet = O_WorkBook.CreateSheet("Sheet1")
        'Dim O_Sheet As XSSFSheet = O_WorkBook.CreateSheet("工作表1")

        ' 插入資料值 或 計算公式
        O_Sheet.CreateRow(0).CreateCell(0).SetCellValue("測試資料")
        O_Sheet.CreateRow(1).CreateCell(0).SetCellValue(100)
        O_Sheet.CreateRow(2).CreateCell(0).SetCellValue(200)
        O_Sheet.CreateRow(3).CreateCell(0).SetCellValue(300)
        O_Sheet.CreateRow(4).CreateCell(0).SetCellFormula("Sum(A2:A4)")

        Dim O_File As FileStream = New FileStream("D:\TestQuery\NPOI_01.xls", FileMode.Create, FileAccess.Write)
        'Dim O_File As FileStream = New FileStream("D:\TestQuery\NPOI_02.xlsx", FileMode.Create, FileAccess.Write)
        O_WorkBook.Write(O_File)

        ' 釋放資源 
        O_WorkBook = Nothing
        MsgBox("檔案 D:\TestQuery\NPOI_01.xls 已產生！", 0 + 64, "OK")
        'MsgBox("檔案 D:\TestQuery\NPOI_02.xlsx 已產生！", 0 + 64, "OK")

    End Sub

    ' 使用 NPOI 讀取 xls 檔，然後顯示於 DataGridView
    Private Sub B_NPOI_READ_Click(sender As Object, e As EventArgs) Handles B_NPOI_READ.Click

        ' 建立資料表（包含４欄），以便儲存讀取的資料
        Dim O_TempTable As New DataTable
        Dim O_col01 As New DataColumn
        O_col01.DataType = System.Type.GetType("System.String")
        With O_col01
            .Caption = "代號"
            .ColumnName = "ItemCode"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col01)
        Dim O_col02 As New DataColumn
        O_col02.DataType = System.Type.GetType("System.String")
        With O_col02
            .Caption = "品名"
            .ColumnName = "ItemName"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col02)
        Dim O_col03 As New DataColumn
        O_col03.DataType = System.Type.GetType("System.Int32")
        With O_col03
            .Caption = "數量"
            .ColumnName = "Qty"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col03)

        ' 讀取 Excel 檔
        ' 首先使用 NPOI 的 XSSFWorkbook 建構函式建立新的活頁簿物件，括號內使用 FileStream 建構函式建立新的檔案流物件，其括號內有三個參數，
        ' 第一個參數為欲讀取之檔案名稱及其路徑，第二個參數為檔案啟動模式（FileMode.Open 開啟、FileMode.Create 建立、FileMode.Append 附加資料至檔尾），
        ' 第三個參數為存取模式（FileAccess.Read讀取、FileAccess.Write寫入、FileAccess.ReadWrite 讀取及寫入）。
        Dim MFN_0 As String = "APPDATA\範例A_銷售基本檔.xls"

        ' 使用 NPOI 的 XSSFWorkbook 建構函式建立新的活頁簿物件，括號內為檔案流物件
        Dim O_WorkBook = New HSSFWorkbook(New FileStream(MFN_0, FileMode.Open, FileAccess.Read))

        ' 使用活頁簿物件的 GetSheetName 屬性取回工作表名稱，括號內為工作表索引順序（由 0 起算）
        Dim MSheetName As String = O_WorkBook.GetSheetName(0)

        ' 使用 NPOI 的 XSSFSheet 建構函式建立新的工作表物件，括號內為工作表名稱
        Dim O_Sheet As HSSFSheet = O_WorkBook.GetSheet(MSheetName)

        ' 使用 For 迴圈讀取儲存格的資料
        Dim MItemCode As String = ""
        Dim MItemName As String = ""
        Dim MQty As Int32 = 0

        Dim MTotalRecordNo As Int32 = 0
        Dim mtprow As Object

        ' PhysicalNumberOfRows 屬性可傳回列數，以便作為迴圈的終止值
        ' PhysicalNumberOfCells 屬性可傳回行數
        Dim Mstop As Int32 = Convert.ToInt32(O_Sheet.PhysicalNumberOfRows)

        ' NPOI 取得某儲存格資料是使用工作表物件的 GetRow 屬性及 GetCell 屬性，GetRow 括號內為列號（由0起算），GetCell 括號內為行號（由0起算），
        ' GetRow 屬性及 GetCell 屬性 之後接資料型別（StringCellValue 字串、NumericCellValue 數字、DateCellValue 日期時間）
        ' 先將 Excel 工作表儲存格的資料存入 DataRow，再將該  DataRow 併入資料表 O_TempTable（使用 Datatable 的 Rows.Add 方法）
        For Mrow = 1 To Mstop Step 1
            On Error GoTo Err01
            MItemCode = O_Sheet.GetRow(Mrow).GetCell(0).StringCellValue
            MItemName = O_Sheet.GetRow(Mrow).GetCell(1).StringCellValue
            MQty = O_Sheet.GetRow(Mrow).GetCell(2).NumericCellValue

            Dim O_NewRow As DataRow
            O_NewRow = O_TempTable.NewRow()
            O_NewRow.Item(0) = MItemCode
            O_NewRow.Item(1) = MItemName
            O_NewRow.Item(2) = MQty
            O_TempTable.Rows.Add(O_NewRow)
            O_TempTable.AcceptChanges()
        Next

        ' 將資料表的資料顯示於 DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = O_TempTable.Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 為 DataGridView1 加入中文欄名，欄名因匯總方式而不同
        With DataGridView1
            .Columns(0).HeaderText = "代號"
            .Columns(1).HeaderText = "品名"
            .Columns(2).HeaderText = "數量"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False
        Exit Sub

Err01:
        ' 將資料表的資料顯示於 DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = O_TempTable.Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 為 DataGridView1 加入中文欄名，欄名因匯總方式而不同
        With DataGridView1
            .Columns(0).HeaderText = "代號"
            .Columns(1).HeaderText = "品名"
            .Columns(2).HeaderText = "數量"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

    End Sub

    ' 使用 NPOI 讀取 xlsx 檔，然後顯示於 DataGridView
    Private Sub B_NPOI_READ2_Click(sender As Object, e As EventArgs) Handles B_NPOI_READ2.Click
        ' 建立資料表（包含４欄），以便儲存讀取的資料
        Dim O_TempTable As New DataTable
        Dim O_col01 As New DataColumn
        O_col01.DataType = System.Type.GetType("System.String")
        With O_col01
            .Caption = "品名"
            .ColumnName = "ItemName"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col01)
        Dim O_col02 As New DataColumn
        O_col02.DataType = System.Type.GetType("System.Int32")
        With O_col02
            .Caption = "數量"
            .ColumnName = "Qty"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col02)
        Dim O_col03 As New DataColumn
        O_col03.DataType = System.Type.GetType("System.Double")
        With O_col03
            .Caption = "金額"
            .ColumnName = "Amt"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col03)
        Dim O_col04 As New DataColumn
        O_col04.DataType = System.Type.GetType("System.DateTime")
        With O_col04
            .Caption = "銷售日"
            .ColumnName = "SaleDate"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
        End With
        O_TempTable.Columns.Add(O_col04)

        ' 讀取 Excel 檔第一張工作表 A5～D9 的資料
        ' 使用 FileStream 的建構函式 建立新的檔案流物件 O_File，並予初始化，括號內有三個參數，
        ' 第一個參數為檔案名稱及其路徑，第二個參數為檔案啟動模式（FileMode.Open 開啟、FileMode.Create 建立、FileMode.Append 附加資料至檔尾），
        ' 第三個參數為存取模式（FileAccess.Read 讀取、FileAccess.Write 寫入、FileAccess.ReadWrite 讀取及寫入）
        Dim MFN_0 As String = "APPDATA\水果銷售統計.xlsx"
        Dim O_Filel As New FileStream(MFN_0, FileMode.Open, FileAccess.Read)

        ' 使用 NPOI 的 XSSFWorkbook 建構函式建立新的活頁簿物件，括號內為檔案流物件
        Dim O_WorkBook As XSSFWorkbook = New XSSFWorkbook(O_Filel)

        ' 使用活頁簿物件的 GetSheetName 屬性取回工作表名稱，括號內為工作表索引順序（由 0 起算）
        Dim MSheetName As String = O_WorkBook.GetSheetName(0)

        ' 使用 NPOI 的 XSSFSheet 建構函式建立新的工作表物件，括號內為工作表名稱
        Dim O_Sheet As XSSFSheet = O_WorkBook.GetSheet(MSheetName)

        ' 使用 For 迴圈讀取儲存格 A5～D9 的資料
        ' 先將 Excel 工作表某一列前4個儲存格的資料存入 DataRow，再將該  DataRow 併入資料表 O_TempTable（使用 Datatable 的 Rows.Add 方法）
        ' NPOI 取得某儲存格資料是使用工作表物件的 GetRow 屬性及 GetCell 屬性，GetRow 括號內為列號（由0起算），GetCell 括號內為行號（由0起算），
        ' GetRow 屬性及 GetCell 屬性 之後接資料型別（StringCellValue 字串、NumericCellValue 數字、DateCellValue 日期時間）
        Dim MItemName As String = ""
        Dim MQty As Int32 = 0
        Dim MAmt As Double
        Dim MsaleDate As DateTime

        Dim MTotalRecordNo As Int32 = 0
        Dim mtprow As Object

        For Mrow = 4 To 8 Step 1
            On Error GoTo Err01
            MItemName = O_Sheet.GetRow(Mrow).GetCell(0).StringCellValue
            MQty = O_Sheet.GetRow(Mrow).GetCell(1).NumericCellValue
            MAmt = O_Sheet.GetRow(Mrow).GetCell(2).NumericCellValue
            MsaleDate = O_Sheet.GetRow(Mrow).GetCell(3).DateCellValue

            Dim O_NewRow As DataRow
            O_NewRow = O_TempTable.NewRow()
            O_NewRow.Item(0) = MItemName
            O_NewRow.Item(1) = MQty
            O_NewRow.Item(2) = MAmt
            O_NewRow.Item(3) = MsaleDate
            O_TempTable.Rows.Add(O_NewRow)
            O_TempTable.AcceptChanges()
        Next

        ' 將資料表的資料顯示於 DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = O_TempTable.Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 為 DataGridView1 加入中文欄名，欄名因匯總方式而不同
        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "銷售日"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        Exit Sub

Err01:
        ' 將資料表的資料顯示於 DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = O_TempTable.Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 為 DataGridView1 加入中文欄名，欄名因匯總方式而不同
        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "銷售日"
        End With

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False
    End Sub

    ' 使用 EPPlus 將 DataGridView 的資料寫入 xlsx 檔
    ' 本程式可自動偵測 DataGridView 的大小，無論其變化為何，都可匯出為 新版的 Excel 檔
    ' 加入參考 EPPlus.dll
    ' 引用命名空間 OfficeOpenXml
    Private Sub B_EPPlus_Write_Click(sender As Object, e As EventArgs) Handles B_EPPlus_Write.Click

        ' 先檢查 DataGridView 是否有資料可匯出
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Sorry, 無資料可匯出！" + Chr(13) + Chr(13) + "請先敲『NPOI 讀取 1』 或 『NPOI 讀取 2』", 0 + 16, "Error")
            Exit Sub
        End If

        ' 若資料夾 D:\TestQuery 不存在，則建立之，以便儲存匯出檔
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 若檔案已存在，則刪除之 ，ExcelPackage 無法新增相同名稱的工作表， 同一活頁簿可加入不同名稱的工作表
        If System.IO.File.Exists("D:\TestQuery\EPPlus01.xlsx") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TestQuery\EPPlus01.xlsx")
        End If

        ' 使用 My.Computer.FileSystem 的 GetFileInfo 方法 以便取回匯出檔之檔名及路徑，作為  ExcelPackage 的參數
        ' 使用 EPPlus 的 ExcelPackage 建構函式建立新的 ExcelPackage 物件，括號內為目標檔之檔名及路徑
        Dim O_information = My.Computer.FileSystem.GetFileInfo("D:\TestQuery\EPPlus01.xlsx")
        Dim O_EP As ExcelPackage = New ExcelPackage(O_information)

        ' 使用 Workbook.Worksheets.Add 方法立新的工作表，括號內為工作表名稱（可自訂）
        ' ExcelWorksheet 與 GemBox.Spreadsheet 衝突，故需標明命名空間
        Dim O_WS As OfficeOpenXml.ExcelWorksheet = O_EP.Workbook.Worksheets.Add("工作表1")

        ' 計算  DataGridView1 的列數及行數，以便作為迴圈終值之基礎
        Dim MRowsNo As Int32 = DataGridView1.Rows.Count
        Dim MColumnsNo As Integer = DataGridView1.ColumnCount

        ' 將 DataGridView 的 HeaderText 欄位名稱寫入工作表的第一列
        For Mcount = 0 To MColumnsNo - 1 Step 1
            O_WS.Cells(1, Mcount + 1).Value = DataGridView1.Columns(Mcount).HeaderText
        Next

        ' 使用雙迴圈將 DataGridView 各格位值寫入工作表，由第二列開始往下寫入，
        ' 外迴圈控制列數，內迴圈控制行數
        ' 請注意行號及列號之寫法，EPPlus 的 Cells 先列後行（由1起算）、DataGridView 先行後列（由0起算）
        For Mrow = 1 To MRowsNo Step 1
            For Mcol = 1 To MColumnsNo Step 1
                On Error Resume Next
                O_WS.Cells(Mrow + 1, Mcol).Value = DataGridView1(Mcol - 1, Mrow - 1).Value
            Next
        Next

        ' 使用 Save 方法存檔
        O_EP.Save()

        ' 釋放資源
        O_WS.Dispose()
        O_EP.Dispose()
        MsgBox("檔案 D:\TestQuery\EPPlus01.xlsx 已產生！", 0 + 64, "OK")

    End Sub

    ' 使用 EPPlus 將資料寫入 xlsx 檔，並予格式化，再繪出統計圖
    ' 引用命名空間 OfficeOpenXml、OfficeOpenXml.Drawing、OfficeOpenXml.Drawing.Chart、OfficeOpenXml.Style
    Private Sub B_EPPlus_Write2_Click(sender As Object, e As EventArgs) Handles B_EPPlus_Write2.Click

        ' 若資料夾 D:\TestQuery 不存在，則建立之，以便儲存匯出檔
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        ' 若檔案已存在，則刪除之 ，ExcelPackage 無法新增相同名稱的工作表， 同一活頁簿可加入不同名稱的工作表
        If System.IO.File.Exists("D:\TestQuery\EPPlus02.xlsx") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TestQuery\EPPlus02.xlsx")
        End If

        ' 使用 My.Computer.FileSystem 的 GetFileInfo 方法 以便取回匯出檔之檔名及路徑，作為  ExcelPackage 的參數
        ' 使用 EPPlus 的 ExcelPackage 建構函式建立新的 ExcelPackage 物件，括號內為目標檔之檔名及路徑
        Dim O_information = My.Computer.FileSystem.GetFileInfo("D:\TestQuery\EPPlus02.xlsx")
        Dim O_EP As ExcelPackage = New ExcelPackage(O_information)

        ' 使用 Workbook.Worksheets.Add 方法立新的工作表，括號內為工作表名稱（可自訂）
        ' ExcelWorksheet 與 GemBox.Spreadsheet 衝突，故需標明命名空間
        Dim O_WS As OfficeOpenXml.ExcelWorksheet = O_EP.Workbook.Worksheets.Add("工作表1")

        ' 使用 Cells.Value 屬性在工作表之特定格位置入文數字或公式
        ' Cell 括號內為行列索引，前者為列，後者為行，均由1起算
        O_WS.Cells(1, 1).Value = "EPPlus 所建立的 Excel 檔"

        O_WS.Cells(3, 1).Value = "品名"
        O_WS.Cells(3, 2).Value = "單價"
        O_WS.Cells(3, 3).Value = "數量"
        O_WS.Cells(3, 4).Value = "金額"
        O_WS.Cells(3, 5).Value = "日期"

        O_WS.Cells(4, 1).Value = "香蕉"
        O_WS.Cells(4, 2).Value = 10
        O_WS.Cells(4, 3).Value = 500
        O_WS.Cells(4, 4).Formula = "B4*C4"
        O_WS.Cells(4, 5).Value = Convert.ToDateTime("2015/06/01")

        O_WS.Cells(5, 1).Value = "蘋果"
        O_WS.Cells(5, 2).Value = 70
        O_WS.Cells(5, 3).Value = 30
        O_WS.Cells(5, 4).Formula = "B5*C5"
        O_WS.Cells(5, 5).Value = Convert.ToDateTime("2015/06/02")

        O_WS.Cells(6, 1).Value = "蓮霧"
        O_WS.Cells(6, 2).Value = 20
        O_WS.Cells(6, 3).Value = 350
        O_WS.Cells(6, 4).Formula = "B6*C6"
        O_WS.Cells(6, 5).Value = Date.Now

        O_WS.Cells(7, 1).Value = "合計"
        O_WS.Cells(7, 4).Formula = "Sum(D4:D6)"

        ' 開始格式化
        ' 定義範圍1
        ' Cells 括號內有4個引數，由左至右分別為 起始列、起始行、終止列、終止列，亦即範圍左上角格位的列數及行數、範圍右下角格位的列數及行數
        Dim O_Range1 As OfficeOpenXml.ExcelRange = O_WS.Cells(3, 1, 7, 5)
        'Dim O_Range1 As OfficeOpenXml.ExcelRange = O_WS.Cells("A3:E7")

        ' 在指定範圍畫框線
        O_Range1.Style.Border.Left.Style = ExcelBorderStyle.Thin
        O_Range1.Style.Border.Right.Style = ExcelBorderStyle.Thin
        O_Range1.Style.Border.Top.Style = ExcelBorderStyle.Thin
        O_Range1.Style.Border.Bottom.Style = ExcelBorderStyle.Thin

        ' 設定指定範圍的字體顏色、名稱及大小
        O_Range1.Style.Font.Name = "Arial"
        O_Range1.Style.Font.Color.SetColor(Color.Navy)
        O_Range1.Style.Font.Size = 12

        ' 數字格式化（千分號）
        ' 定義範圍2
        ' Cells 括號內有4個引數，由左至右分別為 起始列、起始行、終止列、終止列，亦即範圍左上角格位的列數及行數、範圍右上角格位的列數及行數
        Dim O_Range2 As OfficeOpenXml.ExcelRange = O_WS.Cells(4, 2, 7, 4)
        O_Range2.Style.Numberformat.Format = "#,##0"

        ' 水平置中對齊（欄名）
        ' 定義範圍3
        ' Cells 括號內有4個引數，由左至右分別為 起始列、起始行、終止列、終止列，亦即範圍左上角格位的列數及行數、範圍右上角格位的列數及行數
        Dim O_Range3 As OfficeOpenXml.ExcelRange = O_WS.Cells(3, 1, 3, 5)
        O_Range3.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

        ' 水平置中對齊（日期欄）
        ' 不先定義範圍
        O_WS.Cells(4, 5, 6, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

        ' 垂直置中對齊（全部範圍）
        Dim O_Range4 As OfficeOpenXml.ExcelRange = O_WS.Cells(1, 1, 7, 5)
        O_Range4.Style.VerticalAlignment = ExcelVerticalAlignment.Center

        ' 日期格式化
        O_WS.Cells("E4:E6").Style.Numberformat.Format = "yyyy/mm/dd"

        ' 設定背景色為白色（全部範圍）
        O_Range4.Style.Fill.PatternType = ExcelFillStyle.Solid
        O_Range4.Style.Fill.BackgroundColor.SetColor(Color.White)

        ' 設定背景色及前景色（欄名）
        O_Range3.Style.Fill.BackgroundColor.SetColor(Color.LightYellow)
        O_Range3.Style.Font.Color.SetColor(Color.Purple)

        ' 設定表頭的字體顏色、名稱及大小
        O_WS.Cells(1, 1).Style.Font.Name = "Arial"
        O_WS.Cells(1, 1).Style.Font.Color.SetColor(Color.SeaGreen)
        O_WS.Cells(1, 1).Style.Font.Size = 16

        ' 自動調整欄寬（字體會變小）
        'O_WS.Cells.Style.ShrinkToFit = True
        ' 調整欄寬
        O_WS.Column(1).Width = 12
        O_WS.Column(2).Width = 12
        O_WS.Column(3).Width = 12
        O_WS.Column(4).Width = 14
        O_WS.Column(5).Width = 16

        ' 調整列高
        O_WS.Row(1).Height = 24
        O_WS.Row(2).Height = 18
        O_WS.Row(3).Height = 24
        O_WS.Row(4).Height = 24
        O_WS.Row(5).Height = 24
        O_WS.Row(6).Height = 24
        O_WS.Row(7).Height = 24

        ' 格位合併
        O_WS.Cells("B7:C7").Merge = True

        ' 隱藏格線
        O_WS.View.ShowGridLines = False

        ' 版面設定
        ' Landscape 橫印、Portrait 直印
        ' OverThenDown 循列列印（先橫後直）、DownThenOver 循欄列印（先直後橫）
        O_WS.PrinterSettings.TopMargin = 1 / 2.5
        O_WS.PrinterSettings.LeftMargin = 1 / 2.5
        O_WS.PrinterSettings.RightMargin = 0
        O_WS.PrinterSettings.BottomMargin = 0
        O_WS.PrinterSettings.HeaderMargin = 0
        O_WS.PrinterSettings.FooterMargin = 0
        O_WS.PrinterSettings.PageOrder = ePageOrder.OverThenDown
        O_WS.PrinterSettings.PaperSize = ePaperSize.A4
        'O_WS.PrinterSettings.Orientation = eOrientation.Landscape
        O_WS.PrinterSettings.Orientation = eOrientation.Portrait

        ' 畫統計圖 1（立體圓餅圖），不另增工作表
        ' 使用 ExcelWorksheet 工作表類別的 Drawings.AddChart 建構函式建立新的圓餅圖物件 O_chart1，並予初始化，
        ' 括號內有兩個參數，第一個為圖表名稱，第二個為圖形種類，主要種類如下：
        ' Pie 圓餅圖、PieExploded 破裂圓餅圖、PieExploded3D 立體破裂圓餅圖、Line 折線圖、ColumnClustered 直條圖、ColumnClustered3D 立體直條圖、BarClustered3D 立體橫條圖
        ' 相關屬性之用法如下：
        ' SetPosition 可指定圖片位置，括號內第一個參數為圖型左上角距離工作表上邊的距離（像素），第二個參數為圖型左上角距離工作表左邊的距離（像素）
        ' Legend.Position 圖例的位置，Top、Bottom、Right、Left、TopRight
        ' SetSize 可指定圖片大小，括號內第一個參數為寬度（像素），第二個參數為高度（像素）
        ' DataLabel.ShowValue 是否指定資料標籤（各個圖型上是否加上數值）
        ' Series.Add 指定資料範圍，括號內第一個參數為資料數值的範圍，第二個參數為資料標籤的範圍
        ' Style 樣式有 48 種可指定，Style1～ Style48
        ' Title.Text 圖片的標題
        ' XAxis.Title.Text 橫軸（X 軸）標題（圓餅圖無）
        ' YAxis.Title.Text 縱軸（Y 軸）標題（圓餅圖無）
        Dim O_chart1 As OfficeOpenXml.Drawing.Chart.ExcelPieChart = O_WS.Drawings.AddChart("銷售統計圖之一", OfficeOpenXml.Drawing.Chart.eChartType.PieExploded3D)
        O_chart1.Legend.Position = OfficeOpenXml.Drawing.Chart.eLegendPosition.Right
        O_chart1.Legend.Add()
        O_chart1.SetPosition(250, 5)
        O_chart1.SetSize(500, 300)
        O_chart1.DataLabel.ShowValue = True
        Dim O_ChartRange1A As OfficeOpenXml.ExcelRange = O_WS.Cells("D4:D6")
        Dim O_ChartRange1B As OfficeOpenXml.ExcelRange = O_WS.Cells("A4:A6")
        O_chart1.Series.Add(O_ChartRange1A, O_ChartRange1B)
        O_chart1.Style = OfficeOpenXml.Drawing.Chart.eChartStyle.Style18
        O_chart1.Title.Text = "銷售統計圖"

        ' 畫統計圖 2（折線圖）
        ' 另增工作表  O_WS2
        Dim O_WS2 As OfficeOpenXml.ExcelWorksheet = O_EP.Workbook.Worksheets.Add("統計圖 1")
        Dim O_chart2 As OfficeOpenXml.Drawing.Chart.ExcelLineChart = O_WS2.Drawings.AddChart("銷售統計圖之二", OfficeOpenXml.Drawing.Chart.eChartType.Line)
        O_chart2.Legend.Position = OfficeOpenXml.Drawing.Chart.eLegendPosition.Right
        O_chart2.Legend.Add()
        O_chart2.SetPosition(10, 5)
        O_chart2.SetSize(600, 400)
        O_chart2.DataLabel.ShowValue = True
        Dim O_ChartRange2A As OfficeOpenXml.ExcelRange = O_WS.Cells("D4:D6")
        Dim O_ChartRange2B As OfficeOpenXml.ExcelRange = O_WS.Cells("A4:A6")
        O_chart2.Series.Add(O_ChartRange2A, O_ChartRange2B)
        O_chart2.Style = OfficeOpenXml.Drawing.Chart.eChartStyle.Style1
        O_chart2.Title.Text = "銷售統計圖"
        O_chart2.XAxis.Title.Text = "品名"
        O_chart2.YAxis.Title.Text = "金額"
        ' 隱藏格線
        O_WS2.View.ShowGridLines = False

        ' 畫統計圖 3（立體直條圖）
        ' 另增工作表  O_WS3
        Dim O_WS3 As OfficeOpenXml.ExcelWorksheet = O_EP.Workbook.Worksheets.Add("統計圖 2")
        Dim O_chart3 As OfficeOpenXml.Drawing.Chart.ExcelBarChart = O_WS3.Drawings.AddChart("銷售統計圖之三", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered3D)
        O_chart3.Legend.Position = OfficeOpenXml.Drawing.Chart.eLegendPosition.Right
        O_chart3.Legend.Add()
        O_chart3.SetPosition(10, 5)
        O_chart3.SetSize(600, 400)
        O_chart3.DataLabel.ShowValue = True
        Dim O_ChartRange3A As OfficeOpenXml.ExcelRange = O_WS.Cells("D4:D6")
        Dim O_ChartRange3B As OfficeOpenXml.ExcelRange = O_WS.Cells("A4:A6")
        O_chart3.Series.Add(O_ChartRange3A, O_ChartRange3B)
        O_chart3.Style = OfficeOpenXml.Drawing.Chart.eChartStyle.Style7
        O_chart3.Title.Text = "銷售統計圖"
        O_chart3.XAxis.Title.Text = "品名"
        O_chart3.YAxis.Title.Text = "金額"
        ' 隱藏格線
        O_WS3.View.ShowGridLines = False

        ' 使用 Save 方法存檔
        O_EP.Save()

        ' 釋放資源
        O_WS.Dispose()
        O_EP.Dispose()
        MsgBox("檔案 D:\TestQuery\EPPlus02.xlsx 已產生！", 0 + 64, "OK")
    End Sub

    ' 使用 EPPlus 將  xlsx 檔 的資料寫入 DataGridView
    Private Sub B_EPPlus_Read_Click(sender As Object, e As EventArgs) Handles B_EPPlus_Read.Click

        ' 開啟檔案對話方塊，讓 User 指定與匯入的 xlsx 檔
        Dim MFileName As String = ""
        OpenFileDialog1.Filter = "新版 Excel 檔|*.xlsx"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "請選取一個 xlsx 檔"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MFileName = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        ' 使用 My.Computer.FileSystem 的 GetFileInfo 方法 以便取回匯出檔之檔名及路徑，作為  ExcelPackage 的參數
        ' 使用 EPPlus 的 ExcelPackage 建構函式建立新的 ExcelPackage 物件，括號內為目標檔之檔名及路徑
        Dim O_information = My.Computer.FileSystem.GetFileInfo(MFileName)
        Dim O_EP As ExcelPackage = New ExcelPackage(O_information)

        ' 宣告第一張工作表為新的工作表O_WS 物件，括號內為工作表順序索引（由1起算）
        ' ExcelWorksheet 與 GemBox.Spreadsheet 衝突，故需標明命名空間
        Dim O_WS As OfficeOpenXml.ExcelWorksheet = O_EP.Workbook.Worksheets(1)

        ' 找出工作表中資料的起始行列及終止行列，以便作為迴圈計數之基礎
        Dim MStartRow As Int32 = O_WS.Dimension.Start.Row
        Dim MEndRow As Integer = O_WS.Dimension.End.Row
        Dim MStartColumn As Int32 = O_WS.Dimension.Start.Column
        Dim MEndColumn As Int32 = O_WS.Dimension.End.Column

        ' 建立新的資料表，以便儲存讀取的資料，資料表欄位數量由前述的 MEndColumn 終止行決定
        Dim O_TempTable As New DataTable
        For Mcount1 = 1 To MEndColumn Step 1
            Dim MTempColumnName As String = "F_" + Mcount1.ToString
            Dim MTempColumn As New DataColumn
            MTempColumn.DataType = System.Type.GetType("System.String")
            With MTempColumn
                .Caption = MTempColumnName
                .ColumnName = MTempColumnName
                .AllowDBNull = True
                .ReadOnly = False
                .Unique = False
            End With
            O_TempTable.Columns.Add(MTempColumn)
        Next

        ' 使用雙迴圈將工作表的資料寫入資料列，再併入 O_TempTable 資料表
        ' 外迴圈控制列數，內迴圈控制行數
        ' 請注意行號及列號之寫法，EPPlus 的 Cells 先列後行（由1起算）、資料列的 Item 屬性值由 0 起算
        For Mrow = MStartRow To MEndRow Step 1
            Dim O_NewRow As DataRow
            O_NewRow = O_TempTable.NewRow()
            For Mcol = MStartColumn To MEndColumn Step 1
                O_NewRow.Item(Mcol - 1) = O_WS.Cells(Mrow, Mcol).Value
            Next
            O_TempTable.Rows.Add(O_NewRow)
            O_TempTable.AcceptChanges()
        Next

        ' 將資料表的資料顯示於 DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_TempTable

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        Dim MTotalRecordNo = O_TempTable.Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 釋放資源
        O_WS.Dispose()
        O_EP.Dispose()
        MsgBox("檔案資料已匯入！", 0 + 64, "OK")

    End Sub

    ' 基本列印（文字、直線、長方形框線、實心圓 等）
    ' 需將 PrintDialog 列印對話方塊控制項從工具箱拖入表單
    ' 需引用命名空間 System.Drawing.Printing
    Private Sub B_Print1_Click(sender As Object, e As EventArgs) Handles B_Print1.Click

        ' 已使用 Public 宣告 O_PrintDocument 為 輸出到印表機的物件
        ' 已使用 Public 宣告 O_PrintPreview 為 預覽對話方塊物件
        ' 資料欲由印表機印出，需先將文字或圖形輸出到 PrintDocument 列印文件控制項（本例取名為 O_PrintDocument ）
        O_PrintDocument = New Printing.PrintDocument

        ' 使用 PrintDocument 的 DefaultPageSettings.Margins 屬性設定上、下、左、右邊界的大小
        O_PrintDocument.DefaultPageSettings.Margins.Top = 50
        O_PrintDocument.DefaultPageSettings.Margins.Bottom = 50
        O_PrintDocument.DefaultPageSettings.Margins.Left = 50
        O_PrintDocument.DefaultPageSettings.Margins.Right = 50

        ' 使用 PrintDocument 的 DefaultPageSettings.Landscape 屬性設定直印或橫印，Landscape = False 為直印
        O_PrintDocument.DefaultPageSettings.Landscape = True

        ' 使用 PrintDocument 的 DefaultPageSettings.PaperSizes 屬性設定紙張大小
        Dim O_PageSize As System.Drawing.Printing.PaperSize
        For Each O_PageSize In O_PrintDocument.PrinterSettings.PaperSizes
            If O_PageSize.PaperName = "A4" Then
                O_PrintDocument.DefaultPageSettings.PaperSize = O_PageSize
                Exit For
            End If
        Next

        ' 使用 PrintDocument 的 Print 方法啟動文件的列印處理序（可觸發 PrintDocument 的 PrintPage 事件程序）
        ' 下列程式可直接印出，無對話方塊
        'O_PrintDocument.Print()

        ' 顯示列印對話方塊
        ' 若 User 敲了『取消』鈕，則離開本程序，
        ' 若 User 敲了『列印』鈕，則顯示預覽列印對話方塊
        Me.TopMost = False
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            O_PrintDocument.Dispose()
            Exit Sub
        End If

        ' 顯示預覽對話方塊
        ' 先使用 PrintPreviewDialog 預覽對話方塊的 Document 屬性設定預覽的文件
        ' 再使用 PrintPreviewDialog 預覽對話方塊的 ShowDialog 方法顯示預覽對話方塊
        O_PrintPreview.Document = O_PrintDocument
        O_PrintPreview.ShowDialog()

        ' 釋放資源
        O_PrintDocument.Dispose()
        Me.TopMost = True

    End Sub

    ' 本段為 PrintDocument 的 PrintPage 列印頁事件程序
    ' 使用  PrintDocument 的 Print 方法就會觸動本事件
    ' 欲列印的資料及圖形需寫在本事件中，亦即在本程序中宣告繪圖物件，再傳給 PrintDocument 控制項
    Private Sub O_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles O_PrintDocument.PrintPage

        ' 使用 Font 建構函式宣告繪出字型
        Dim O_Font As Font = New Font("Arial", 12, FontStyle.Regular)

        ' 使用 Pen 建構函式宣告畫筆物件，括號內有兩個參數，第一個為顏色，第二個為寬度
        Dim O_Pen As Pen = New Pen(Color.Black, 0.1)

        ' 使用 Graphics 繪圖物件的 PageScale 屬性 取得或設定在這個 Graphics 的自然單位和畫面單位之間的縮放值
        e.Graphics.PageScale = PaperKind.A4

        ' 使用 Graphics 繪圖物件的 PageUnit 屬性 設定在畫面座標所使用的測量單位
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' 使用 Graphics 繪圖物件的 DrawString 方法 繪製字串
        ' 使用指定的 Brush 和 Font 物件，將指定的文字字串繪製於指定的位置。 
        ' 括號內有 4 個參數，第一個為要繪製的字串，第二個為字串格式，由 O_Font 物件定義，
        ' 第三個為字串的樣式及顏色格式，由 O_Brash 物件定義，本例定義為黑色實心筆刷，
        ' 第四個為繪製字串的左上角座標
        ' 使用 Point 結構定義 X 軸（橫軸）座標及 Y 軸（縱軸）座標，括號內有兩個參數，前者為 X 軸座標，後者為 Y 軸座標，
        ' 紙張左上角為原點(0,0)， X 軸之值越大離左邊界越遠，Y 軸之值越大離上邊界越遠
        ' Font 物件的 Height 屬性可傳回字型的高度
        Dim O_Brash As SolidBrush = New SolidBrush(Color.Black)
        Dim O_Point1 As Point = New Point(1, 2)
        e.Graphics.DrawString("繪圖測試 ABC 1234567", O_Font, O_Brash, O_Point1)
        Dim O_Point2 As Point = New Point(1, 4)
        e.Graphics.DrawString("字型的高度： " + O_Font.Height.ToString, O_Font, O_Brash, O_Point2)

        ' 宣告點物件，供後續 DrawLine 畫線方法定義座標，括號內有 2 個參數，第一個為 X 軸（橫軸）座標，第二個為 Y 軸（縱軸）座標
        Dim O_Point3 As Point = New Point(1, 6)
        Dim O_Point4 As Point = New Point(16, 6)
        ' 使用 Graphics 繪圖物件的 DrawLine 方法 繪製直線，
        ' 括號內有 3 個參數，第一個為直線的色彩及寬度，由 Pen 物件定義，
        ' 第二個為直線起點之座標，第三個為直線終點之座標
        e.Graphics.DrawLine(O_Pen, O_Point3, O_Point4)

        ' 使用 DrawRectangle 方法繪出長方形
        ' 括號內有 5 個參數，第一個為線條的色彩及寬度，由 Pen 物件定義，
        ' 第二個為長方形左上角之 X 座標，第三個為長方形左上角之 Y 座標，
        ' 第四個為長方形之寬度，第五個為長方形之高度
        e.Graphics.DrawRectangle(O_Pen, 5, 10, 30, 20)

        ' 使用 DrawEllipse 方法繪出橢圓形
        ' 橢圓形之大小由其周圍的長方形邊框所決定，請見繪出圖的虛線框，此方法的第4及第5個參數即為邊框的寬度及高度
        ' 括號內有 5 個參數，第一個為線條的色彩及寬度，由 O_Pen 物件定義，
        ' 第二個為橢圓形所構築之長方形左上角的 X 座標，第三個為橢圓形所構築之長方形左上角的 Y 座標，
        ' 第四個為橢圓形所構築之長方形的寬度，第五個為橢圓形所構築之長方形的高度
        e.Graphics.DrawEllipse(O_Pen, 5, 35, 30, 20)

        ' 使用 FillRectangle 方法繪出實心的長方形
        ' 括號內有 5 個參數，第一個為線條的色彩及寬度，由 SolidBrush 物件定義，
        ' 第二個為長方形之 X 座標，第三個為長方形之 Y 座標，
        ' 第四個為長方形之寬度，第五個為長方形之高度
        ' 先使用 SolidBrush 實心筆刷物件定義筆刷的顏色
        Dim O_Brash2 As SolidBrush = New SolidBrush(Color.DarkGreen)
        e.Graphics.FillRectangle(O_Brash2, 45, 10, 30, 20)

        ' 使用 FillEllipse 方法繪出實心的橢圓形
        ' 括號內有 5 個參數，第一個為線條的色彩及寬度，由 SolidBrush 物件定義，
        ' 第二個為橢圓形所構築之長方形左上角的 X 座標，第三個為橢圓形所構築之長方形左上角的 Y 座標，
        ' 第四個為橢圓形所構築之長方形的寬度，第五個為橢圓形所構築之長方形的高度
        Dim O_Brash3 As SolidBrush = New SolidBrush(Color.OrangeRed)
        e.Graphics.FillEllipse(O_Brash3, 45, 35, 30, 20)

        ' 以虛線繪出橢圓形的邊框，此邊框的大小決定了橢圓形的大小
        ' Pen 物件的 DashStyle 屬性可定義畫筆的樣式，Solid 實線、Dash 虛線、DashDot 虛點線、DashDotDot 虛兩點線
        Dim O_Pen1 As Pen = New Pen(Color.Black, 0.1)
        O_Pen1.DashStyle = Drawing2D.DashStyle.Dash
        e.Graphics.DrawRectangle(O_Pen1, 45, 35, 30, 20)

    End Sub

    ' 使用繪圖方式列印統計表
    Private Sub B_Print2_Click(sender As Object, e As EventArgs) Handles B_Print2.Click

        ' 第一段，先匯入資料檔並顯示於 DataGridView *************************************************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_2 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_2 As New SqlConnection(Mcnstr_2)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_2.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_2 As String = "Select STAFF_NO,STAFF_NAME,STAFF_SEX,DEPT_NAME,WAGES From SALARY Where FILEDATE='201412' And DEPT_CODE='1300'"

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_2 As New SqlDataAdapter(Msqlstr_2, Ocn_2)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_2 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_2.Fill(ODataSet_2, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_2.Tables("Table01")

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_2.Tables("Table01").Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "員工號"
            .Columns(1).HeaderText = "員工姓名"
            .Columns(2).HeaderText = "性別"
            .Columns(3).HeaderText = "部門名稱"
            .Columns(4).HeaderText = "薪津"
        End With
        ' 欄位資料格式化，
        With DataGridView1
            .Columns(4).DefaultCellStyle.Format = "#,0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 關閉 存取資料庫的相關物件
        ODataAdapter_2.Dispose()
        Ocn_2.Close()
        Ocn_2.Dispose()

        ' 第二段，設定列印文件控制項 *************************************************************************
        '  PageSetupDialog 元件是預先設定的對話方塊，此方塊用來在 Windows 架構應用程式中設定列印的頁面詳細資料，
        '  在您的 Windows 架構應用程式中，使用此控制項做為使用者設定頁面喜好設定的簡單方案，就不用設定自己的對話方塊，
        '  您可以讓使用者設定框線和邊界調整、頁首和頁尾及直印或橫印
        ' O_PrintDocument 輸出到印表機的物件 Printing.PrintDocument
        ' O_PrintPreview 預覽對話方塊物件 PrintPreviewDialog
        ' PrintDocument 列印文件控制項，資料欲由印表機印出，需先將文字或圖形輸出到 PrintDocument 列印文件控制項
        O_PrintDocument2 = New Printing.PrintDocument

        ' 使用 DefaultPageSettings 屬性設定上下邊界
        ' 使用 PrintDocument 的 .DefaultPageSettings.Margins 屬性設定上、下、左、右邊界的寬度
        O_PrintDocument2.DefaultPageSettings.Margins.Top = 30
        O_PrintDocument2.DefaultPageSettings.Margins.Bottom = 10
        O_PrintDocument2.DefaultPageSettings.Margins.Left = 30
        O_PrintDocument2.DefaultPageSettings.Margins.Right = 10

        ' 使用 DefaultPageSettings 屬性設定橫印，False 為直印，True 為橫印
        O_PrintDocument2.DefaultPageSettings.Landscape = False

        ' 使用 DefaultPageSettings 屬性設定紙張大小
        Dim O_PageSize2 As System.Drawing.Printing.PaperSize
        For Each O_PageSize2 In O_PrintDocument2.PrinterSettings.PaperSizes
            If O_PageSize2.PaperName = "A4" Then
                O_PrintDocument2.DefaultPageSettings.PaperSize = O_PageSize2
                Exit For
            End If
        Next

        Me.TopMost = False
        ' 頁次計算變數歸零，以便本程序重複使用時可正確計算頁次
        MPrintNO = 0

        ' 使用 PrintDocument 的 Print 方法啟動文件的列印處理序（可觸發 PrintDocument 的 PrintPage 事件程序）
        ' 下列程式可直接印出，無對話方塊，若有多頁，可連續印出，若使用 預覽對話方塊中的列印圖示，則每按一次只能印出一頁
        ' 從印表機印出
        ' Dim Mans As Integer = MsgBox("請確認是否從印表機印出？" + Chr(13) + Chr(13) + "若要列印，請打開印表機電源。", 4 + 32, "請確認")
        'If Mans = 6 Then
        'O_PrintDocument2.Print()
        'End If

        ' 顯示列印對話方塊
        ' 若 User 敲了『取消』鈕，則離開本程序，
        ' 若 User 敲了『列印』鈕，則顯示預覽列印對話方塊
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            O_PrintDocument2.Dispose()
            Exit Sub
        End If

        ' 顯示預覽對話方塊
        ' 先使用 PrintPreviewDialog 預覽對話方塊的 Document 屬性設定預覽的文件
        ' PrintPreviewDialog 預覽對話方塊的屬性可設定其大小、位置、字型等
        ' 使用 PrintPreviewDialog 預覽對話方塊的 ShowDialog 方法顯示預覽對話方塊
        O_PrintPreview2.Document = O_PrintDocument2
        O_PrintPreview2.Height = 520
        O_PrintPreview2.Width = 430
        Dim O_Point0 As Point = New Point(3, 1)
        O_PrintPreview2.Location = O_Point0
        Dim O_Font0 As Font = New Font("Arial", 11, FontStyle.Regular)
        O_PrintPreview2.Font = O_Font0
        O_PrintPreview2.TopMost = True
        O_PrintPreview2.ShowDialog()

        ' 釋放資源
        O_PrintDocument2.Dispose()
        Me.TopMost = True

    End Sub

    ' 轉成圖型，以便印出
    ' 本段為 PrintDocument 的 PrintPage 列印頁事件程序
    ' Printing.PrintDocument 為輸出到印表機的物件
    ' 使用 Print 方法就會觸動本事件
    ' 欲列印的資料及圖形需寫在本事件中，亦即在本程序中宣告繪圖物件，再傳給 PrintDocument 控制項
    Private Sub O_PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles O_PrintDocument2.PrintPage

        ' 使用 Graphics 繪圖物件的 PageUnit 屬性 設定在畫面座標所使用的測量單位
        ' 測量單位有 Point、Pixel、Millimeter、Inch、World、Document、Display
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' 使用  New 關鍵字宣告繪製的字型，表頭、欄名、欄位資料 可分別使用不同字型
        Dim O_FontTitle01 As Font = New Font("新細明體", 16, FontStyle.Bold)
        Dim O_FontTitle02 As Font = New Font("Arial", 10, FontStyle.Regular)
        Dim O_Font00 As Font = New Font("新細明體", 12, FontStyle.Regular)
        Dim O_Font As Font = New Font("Arial", 11, FontStyle.Regular)

        ' 使用 Pen 建構函式宣告畫筆物件，括號內有兩個參數，第一個為顏色，第二個為寬度，
        ' 使用 SolidBrush 建構函式宣告筆刷物件，以供後續 Graphics 繪圖物件使用
        Dim O_Pen As Pen = New Pen(Color.Black, 0.3)
        Dim O_Brash As SolidBrush = New SolidBrush(Color.Black)

        ' 取回上邊界及左邊界之值，以作為後續資料列印位置的基準
        Dim MleftMargin As Integer = O_PrintDocument2.DefaultPageSettings.Margins.Left
        Dim MTopMargin As Integer = O_PrintDocument2.DefaultPageSettings.Margins.Top

        If DataGridView1.ColumnCount > 0 Then
            ' 使用 DrawString 方法繪出表頭
            e.Graphics.DrawString("薪津資料統計表", O_FontTitle01, O_Brash, MleftMargin + 193, MTopMargin)

            '  使用 DrawLine 方法畫出直線
            ' 宣告點物件，供後續 DrawLine 畫線方法定義座標，' 括號內有 2 個參數，第一個為 X 軸（橫軸）座標，，第一個為 Y 軸（縱軸）座標
            Dim O_Point1 As Point = New Point(MleftMargin + 180, MTopMargin + 18)
            Dim O_Point2 As Point = New Point(MleftMargin + 180 + 146, MTopMargin + 18)

            ' 使用 Graphics 繪圖物件的 DrawLine 方法 繪製直線，
            ' 括號內有 3 個參數，第一個為直線的色彩及寬度，由 PEN 物件設定，
            ' 第二個為直線起點之座標，第三個為直線終點之座標
            e.Graphics.DrawLine(O_Pen, O_Point1, O_Point2)

            ' 畫第二條線
            Dim O_Point3 As Point = New Point(MleftMargin + 180, MTopMargin + 20)
            Dim O_Point4 As Point = New Point(MleftMargin + 180 + 146, MTopMargin + 20)
            e.Graphics.DrawLine(O_Pen, O_Point3, O_Point4)

            ' 使用 DrawString 方法繪出列印時間
            Dim MPrintTime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            e.Graphics.DrawString("列印時間： " + MPrintTime, O_FontTitle02, O_Brash, MleftMargin, MTopMargin + 25)

            ' 使用 DrawString 方法繪出頁次
            Dim MPageNo As String = (MPrintNO + 1).ToString
            e.Graphics.DrawString("頁次： " + MPageNo, O_FontTitle02, O_Brash, MleftMargin + 475, MTopMargin + 25)

            ' 繪製欄名
            ' 使用 Graphics 繪圖物件的 DrawString 方法 繪製字串
            ' 使用指定的 Brush 和 Font 物件，將指定的文字字串繪製於指定的位置。 
            ' 括號內有 5 個參數，第一個為要繪製的字串，第二個為字串格式，由 O_Font 物件定義，
            ' 第三個為字串的樣式及顏色格式，由 O_Brash 物件定義，本例定義為黑色實心筆刷，
            ' 第四個為繪製字串的左上角X座標，第五個為繪製字串的左上角Y座標
            Dim Mx01 As Integer = MleftMargin
            Dim My01 As Integer = MTopMargin + 60
            For Mcou = 0 To 4 Step 1
                e.Graphics.DrawString(DataGridView1.Columns(Mcou).HeaderText, O_Font00, O_Brash, Mx01, My01)
                ' 每一欄相距 90 點
                Mx01 = Mx01 + 90
            Next
        End If

        ' 繪製資料
        Dim Mx02 As Integer = MleftMargin
        Dim My02 As Integer = MTopMargin + 60 + 16
        Dim MTempString As String = ""
        Dim MTotalRecords As Int32 = DataGridView1.Rows.Count - 1

        ' 每一頁列印 43 筆資料
        ' 當資料量大的時候，需要分頁列印，每一頁的起始筆數及終止筆數都不相同，
        ' MStartNo 每一頁的起始筆數＝43 X MPrintNO 已列印頁次（由 0 起算），第一頁起始筆數為 0，第二頁起始筆數為 43，餘類推，
        ' MStopNo 每一頁的終止筆數＝MStartNo 起始筆數＋42，第一頁終止筆數為 42，第二頁終止筆數為 85，餘類推
        ' 使用雙迴圈控制欄位資料的列印，外迴圈控制每一頁的列數（每一列資料），內迴圈控制每一頁的行數（每一欄資料），
        ' 當內迴圈的控制變數 Mcol 為 4 時，資料須加千分號，每一欄相距 90 點，
        ' 當每一內迴圈結束後，X 軸位置歸原位，不能在遞增，下一筆資料才能從紙張左邊起印，Y 軸位座標遞增 16 點，以便下一筆資料能與上一筆資料保持適當距離
        MStartNo = 43 * MPrintNO
        MStopNo = MStartNo + 42
        For Mrow = MStartNo To MStopNo Step 1
            If Mrow > MTotalRecords Then
                Exit For
            End If
            For Mcol = 0 To 4 Step 1
                MTempString = DataGridView1.Rows(Mrow).Cells(Mcol).Value
                If Mcol = 4 Then
                    MTempString = Strings.Format(Convert.ToInt32(MTempString), "#,0")
                End If
                e.Graphics.DrawString(MTempString, O_Font, O_Brash, Mx02, My02)
                Mx02 = Mx02 + 90
            Next
            ' 每一列資料起始 X 軸位置歸原位
            Mx02 = MTopMargin
            ' 每一列資料上下相距 16 點
            My02 = My02 + 16
        Next

        ' 使用 Ceiling 方法計算列印所需的總頁數（每一頁列印 43筆）
        Dim MPrintTotalNo As Integer = Math.Ceiling(DataGridView1.Rows.Count / 43)

        ' 使用 PrintPageEventArgs 類別的 HasMorePages 屬性 來換頁列印
        ' 當 MPrintNO 已列印頁次小於 MPrintTotalNo - 1 列印總頁數減 1 時，將 HasMorePages = true，以便告訴 PrintDocument 物件還要再次呼叫 PrintPage 事件，
        ' 亦即再執行本程序一次，以便列印後續資料
        If MPrintNO < MPrintTotalNo - 1 Then
            MPrintNO = MPrintNO + 1
            e.HasMorePages = True
        End If

    End Sub

    ' 請款單列印（可控制細部設計）
    Private Sub B_Print3_Click(sender As Object, e As EventArgs) Handles B_Print3.Click

        ' 已使用 Public 宣告 O_PrintDocument3 為 輸出到印表機的物件
        ' 已使用 Public 宣告 O_PrintPreview3 為 預覽對話方塊物件
        ' 資料欲由印表機印出，需先將文字或圖形輸出到 PrintDocument 列印文件控制項（本例取名為 O_PrintDocument3 ）
        O_PrintDocument3 = New Printing.PrintDocument

        ' 使用 DefaultPageSettings 屬性設定上下邊界
        ' 使用 PrintDocument 的 .DefaultPageSettings.Margins 屬性設定上、下、左、右邊界的寬度
        O_PrintDocument3.DefaultPageSettings.Margins.Top = 20
        O_PrintDocument3.DefaultPageSettings.Margins.Bottom = 10
        O_PrintDocument3.DefaultPageSettings.Margins.Left = 20
        O_PrintDocument3.DefaultPageSettings.Margins.Right = 10

        ' 使用 DefaultPageSettings 屬性設定橫印，False 為直印，True 為橫印
        O_PrintDocument3.DefaultPageSettings.Landscape = False

        ' 使用 DefaultPageSettings 屬性設定紙張大小
        Dim O_PageSize3 As System.Drawing.Printing.PaperSize
        For Each O_PageSize3 In O_PrintDocument3.PrinterSettings.PaperSizes
            If O_PageSize3.PaperName = "A4" Then
                O_PrintDocument3.DefaultPageSettings.PaperSize = O_PageSize3
                Exit For
            End If
        Next

        Me.TopMost = False
        ' 頁次計算變數歸零，以便本程序重複使用時可正確計算頁次
        MPrintNO = 0

        ' 使用 PrintDocument 的 Print 方法啟動文件的列印處理序（可觸發 PrintDocument 的 PrintPage 事件程序）
        ' 下列程式可直接印出，無對話方塊，若有多頁，可連續印出，若使用 預覽對話方塊中的列印圖示，則每按一次只能印出一頁
        ' 從印表機印出
        ' Dim Mans As Integer = MsgBox("請確認是否從印表機印出？" + Chr(13) + Chr(13) + "若要列印，請打開印表機電源。", 4 + 32, "請確認")
        'If Mans = 6 Then
        'O_PrintDocument3.Print()
        'End If

        ' 顯示列印對話方塊
        ' 若 User 敲了『取消』鈕，則離開本程序，
        ' 若 User 敲了『列印』鈕，則顯示預覽列印對話方塊
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            O_PrintDocument3.Dispose()
            Exit Sub
        End If

        ' 顯示預覽對話方塊
        ' 先使用 PrintPreviewDialog 預覽對話方塊的 Document 屬性設定預覽的文件
        ' PrintPreviewDialog 預覽對話方塊的屬性可設定其大小、位置、字型等
        ' 使用 PrintPreviewDialog 預覽對話方塊的 ShowDialog 方法顯示預覽對話方塊
        O_PrintPreview3.Document = O_PrintDocument3
        O_PrintPreview3.Height = 520
        O_PrintPreview3.Width = 430
        Dim O_Point0 As Point = New Point(3, 1)
        O_PrintPreview3.Location = O_Point0
        Dim O_Font0 As Font = New Font("Arial", 11, FontStyle.Regular)
        O_PrintPreview3.Font = O_Font0
        O_PrintPreview3.TopMost = True
        O_PrintPreview3.ShowDialog()

        ' 釋放資源
        O_PrintDocument3.Dispose()
        Me.TopMost = True
    End Sub

    ' 本段為 PrintDocument 的 PrintPage 列印頁事件程序
    ' 使用  PrintDocument 的 Print 方法就會觸動本事件
    ' 欲列印的資料及圖形需寫在本事件中，亦即在本程序中宣告繪圖物件，再傳給 PrintDocument 控制項
    Private Sub O_PrintDocument3_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles O_PrintDocument3.PrintPage

        ' 使用  New 關鍵字宣告繪出字型
        Dim O_FontTitle As Font = New Font("微軟正黑體", 24, FontStyle.Regular)
        Dim O_Font As Font = New Font("Arial", 11, FontStyle.Regular)

        ' 使用 Pen 建構函式宣告畫筆物件，括號內有兩個參數，第一個為顏色，第二個為寬度
        Dim O_Pen As Pen = New Pen(Color.Black, 0.1)

        ' 使用 Graphics 繪圖物件的 PageScale 屬性 取得或設定在這個 Graphics 的自然單位和畫面單位之間的縮放值
        e.Graphics.PageScale = PaperKind.A4

        ' 使用 Graphics 繪圖物件的 PageUnit 屬性 設定在畫面座標所使用的測量單位
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' 使用 Graphics 繪圖物件的 DrawString 方法 繪製字串
        ' 使用指定的 Brush 和 Font 物件，將指定的文字字串繪製於指定的位置。 
        ' 括號內有 4 個參數，第一個為要繪製的字串，第二個為字串格式，由 O_Font 物件定義，
        ' 第三個為字串的樣式及顏色格式，由 O_Brash 物件定義，本例定義為黑色實心筆刷，
        ' 第四個為繪製字串的左上角座標
        ' 使用 Point 結構定義 X 軸（橫軸）座標及 Y 軸（縱軸）座標，括號內有兩個參數，前者為 X 軸座標，後者為 Y 軸座標，
        ' 紙張左上角為原點(0,0)， X 軸之值越大離左邊界越遠，Y 軸之值越大離上邊界越遠
        ' Font 物件的 Height 屬性可傳回字型的高度
        Dim O_Brash As SolidBrush = New SolidBrush(Color.Black)
        Dim O_Point1 As Point = New Point(3, 8)
        e.Graphics.DrawString("編號：", O_Font, O_Brash, O_Point1)
        Dim O_Point2 As Point = New Point(27, 6)
        e.Graphics.DrawString("請  款  單", O_FontTitle, O_Brash, O_Point2)
        Dim O_Point3 As Point = New Point(50, 8)
        e.Graphics.DrawString("日期：", O_Font, O_Brash, O_Point3)

        ' 使用 DrawRectangle 方法繪出長方形外框
        ' 括號內有 5 個參數，第一個為線條的色彩及寬度，由 Pen 物件定義，
        ' 第二個為長方形左上角之 X 座標，第三個為長方形左上角之 Y 座標，
        ' 第四個為長方形之寬度，第五個為長方形之高度
        e.Graphics.DrawRectangle(O_Pen, 3, 10, 57, 24)

        ' 畫三條橫線
        ' 宣告點物件，供後續 DrawLine 畫線方法定義座標，括號內有 2 個參數，第一個為 X 軸（橫軸）座標，第二個為 Y 軸（縱軸）座標
        ' 使用 Graphics 繪圖物件的 DrawLine 方法 繪製直線，
        ' 括號內有 3 個參數，第一個為直線的色彩及寬度，由 Pen 物件定義，
        ' 第二個為直線起點之座標，第三個為直線終點之座標
        ' 橫 1
        Dim O_Point4 As Point = New Point(3, 17)
        Dim O_Point5 As Point = New Point(60, 17)
        e.Graphics.DrawLine(O_Pen, O_Point4, O_Point5)

        ' 橫 2
        Dim O_Point6 As Point = New Point(3, 23)
        Dim O_Point7 As Point = New Point(60, 23)
        e.Graphics.DrawLine(O_Pen, O_Point6, O_Point7)

        ' 橫 3
        Dim O_Point8 As Point = New Point(3, 29)
        Dim O_Point9 As Point = New Point(60, 29)
        e.Graphics.DrawLine(O_Pen, O_Point8, O_Point9)

        ' 畫直線（左 2）
        Dim O_Point10 As Point = New Point(11, 10)
        Dim O_Point11 As Point = New Point(11, 34)
        e.Graphics.DrawLine(O_Pen, O_Point10, O_Point11)

        ' 畫直線（左 3 上）
        Dim O_Point12 As Point = New Point(40, 10)
        Dim O_Point13 As Point = New Point(40, 17)
        e.Graphics.DrawLine(O_Pen, O_Point12, O_Point13)

        ' 畫直線（左 4 上）
        Dim O_Point14 As Point = New Point(46, 10)
        Dim O_Point15 As Point = New Point(46, 17)
        e.Graphics.DrawLine(O_Pen, O_Point14, O_Point15)

        ' 畫直線（左 3 下）
        Dim O_Point16 As Point = New Point(40, 23)
        Dim O_Point17 As Point = New Point(40, 34)
        e.Graphics.DrawLine(O_Pen, O_Point16, O_Point17)

        ' 畫直線（左 4 下）
        Dim O_Point18 As Point = New Point(46, 29)
        Dim O_Point19 As Point = New Point(46, 34)
        e.Graphics.DrawLine(O_Pen, O_Point18, O_Point19)

        ' 繪製欄名
        Dim O_Point20 As Point = New Point(4, 13)
        e.Graphics.DrawString("請款事由", O_Font, O_Brash, O_Point20)
        Dim O_Point21 As Point = New Point(4, 20)
        e.Graphics.DrawString("請款金額", O_Font, O_Brash, O_Point21)
        Dim O_Point22 As Point = New Point(4, 25.5)
        e.Graphics.DrawString("支付方式", O_Font, O_Brash, O_Point22)
        Dim O_Point23 As Point = New Point(4, 31)
        e.Graphics.DrawString("其 他", O_Font, O_Brash, O_Point23)

        Dim O_Point24 As Point = New Point(41, 13)
        e.Graphics.DrawString("科 目", O_Font, O_Brash, O_Point24)
        Dim O_Point25 As Point = New Point(41, 31)
        e.Graphics.DrawString("領款人", O_Font, O_Brash, O_Point25)

        Dim O_Point26 As Point = New Point(3, 35)
        e.Graphics.DrawString("總經理                    經理                    覆核                    會計                    出納                    製單", O_Font, O_Brash, O_Point26)
        Dim O_Point27 As Point = New Point(60.5, 12)
        e.Graphics.DrawString("附", O_Font, O_Brash, O_Point27)
        Dim O_Point28 As Point = New Point(60.5, 14)
        e.Graphics.DrawString("單", O_Font, O_Brash, O_Point28)
        Dim O_Point29 As Point = New Point(60.5, 16)
        e.Graphics.DrawString("據", O_Font, O_Brash, O_Point29)
        Dim O_Point30 As Point = New Point(60.5, 20)
        e.Graphics.DrawString("張", O_Font, O_Brash, O_Point30)

        ' 繪製資料
        Dim Msno As String = "20150036"
        Dim Mreason1 As String = "歸墊方曉琳代付噪音罰單，"
        Dim Mreason2 As String = "告發單號：聲字第2015-103271號"
        Dim Mreason3 As String = ""
        Dim Mcode As String = "367 營運違規罰款"
        Dim Mamt As String = "$ 3,000       台幣三千元正"
        Dim Mpaykind As String = "支票       抬頭：方曉琳 即期票"
        Dim Mpaybank As String = "台灣銀行 中壢分行"
        Dim Mother As String = ""
        Dim Mreceiver As String = "方曉琳"

        Dim O_Point50 As Point = New Point(7, 8)
        e.Graphics.DrawString(Msno, O_Font, O_Brash, O_Point50)
        Dim O_Point51 As Point = New Point(54, 8)
        e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MM/dd"), O_Font, O_Brash, O_Point51)

        Dim O_Point52A As Point = New Point(12, 11)
        e.Graphics.DrawString(Mreason1, O_Font, O_Brash, O_Point52A)
        Dim O_Point52B As Point = New Point(12, 13)
        e.Graphics.DrawString(Mreason2, O_Font, O_Brash, O_Point52B)
        Dim O_Point52C As Point = New Point(12, 15)
        e.Graphics.DrawString(Mreason3, O_Font, O_Brash, O_Point52C)

        Dim O_Point54 As Point = New Point(12, 20)
        e.Graphics.DrawString(Mamt, O_Font, O_Brash, O_Point54)
        Dim O_Point55 As Point = New Point(12, 25.5)
        e.Graphics.DrawString(Mpaykind, O_Font, O_Brash, O_Point55)

        Dim O_Point56 As Point = New Point(47, 13)
        e.Graphics.DrawString(Mcode, O_Font, O_Brash, O_Point56)
        Dim O_Point57 As Point = New Point(41, 25.5)
        e.Graphics.DrawString(Mpaybank, O_Font, O_Brash, O_Point57)
        Dim O_Point58 As Point = New Point(12, 31)
        e.Graphics.DrawString(Mother, O_Font, O_Brash, O_Point58)
        Dim O_Point59 As Point = New Point(47, 31)
        e.Graphics.DrawString(Mreceiver, O_Font, O_Brash, O_Point59)

    End Sub

    ' 使用 ReportViewer 匯出及列印報表
    ' 需引用命名空間 Microsoft.Reporting.WinForms
    Private Sub B_RV_Click(sender As Object, e As EventArgs) Handles B_RV.Click

        ' 先檢查是否已指定日期（日期條件必須指定）
        If T_FILEDATE.Text = "" Then
            MsgBox("Sorry, 尚未指定日期！", 0 + 16, "Error")
            Exit Sub
        End If

        ReportViewer1.Visible = False

        ' 將 User 所指定的查詢條件存入變數 MMM，以便組合 SQL 指令
        Dim MMM As String = ""
        If T_DEPTCODE.Text <> "" Then
            MMM = "dept_code='" + T_DEPTCODE.Text + "'"
        End If
        If T_Man.Checked = True Then
            If MMM = "" Then
                MMM = "staff_sex='M'"
            Else
                MMM = MMM + " and staff_sex='M'"
            End If
        End If
        If T_Woman.Checked = True Then
            If MMM = "" Then
                MMM = "staff_sex='F'"
            Else
                MMM = MMM + " and staff_sex='F'"
            End If
        End If
        If T_TITLE.Text <> "" Then
            If MMM = "" Then
                MMM = "title='" + T_TITLE.Text + "'"
            Else
                MMM = MMM + " and title='" + T_TITLE.Text + "'"
            End If
        End If
        If T_GRADE.Text <> "" Then
            If MMM = "" Then
                MMM = "grade='" + T_GRADE.Text + "'"
            Else
                MMM = MMM + " and grade='" + T_GRADE.Text + "'"
            End If
        End If

        ' 合併 User 所指定的日期，並存入變數 MTempDate，以便作為 SQL 指令的一部分
        Dim MTempDate As String = Strings.Trim(T_FILEDATE.Text)
        If MMM = "" Then
            MMM = "filedate IN(" + MTempDate + ")"
        Else
            MMM = MMM + " and filedate IN(" + MTempDate + ")"
        End If

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
        Dim Msqlstr_1 As String = "Select STAFF_NO,STAFF_NAME,STAFF_SEX,DEPT_CODE,DEPT_NAME,WAGES,FILEDATE From SALARY Where " + MMM

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除欄位（必須反向刪除）
        Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        For Mcount = MTotalColumns To 0 Step -1
            DataGridView1.Columns.RemoveAt(Mcount)
        Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        MTotalRecordNo = ODataSet_1.Tables("Table01").Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "員工號"
            .Columns(1).HeaderText = "員工姓名"
            .Columns(2).HeaderText = "性別"
            .Columns(3).HeaderText = "部門代號"
            .Columns(4).HeaderText = "部門名稱"
            .Columns(5).HeaderText = "薪津"
            .Columns(6).HeaderText = "日期"
        End With

        ' 金額等欄位格式化
        With DataGridView1
            .Columns(5).DefaultCellStyle.Format = "#,0"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        'DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        'Dim mtprow As Object
        'For Each mtprow In DataGridView1.Rows
        'mtprow.Height = 24
        'Next mtprow

        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 28

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 設定報表檢視器背景色、邊框樣式、字型種類、字型大小、字型顏色、高度、寬度
        ReportViewer1.Reset()
        ReportViewer1.BackColor = Color.White
        ReportViewer1.Font = New Font("Arila", 11)
        ReportViewer1.ForeColor = Color.Black
        ReportViewer1.ShowPrintButton = True
        ReportViewer1.ShowZoomControl = True
        ReportViewer1.ShowFindControls = False
        ReportViewer1.ShowDocumentMapButton = False
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 90

        ' 設定報表檢視器之列印方向、紙張大小及邊界（省去 User 在 ReportViewer 中調整的麻煩）
        ' orientation 列印方向分為 landscape 橫印（風景畫） 及 portrait 直印（肖像畫）
        ' Landscape = False 直印、Landscape = True 橫印
        ' 依據 PageSettings 類別宣告新的頁面設定物件 O_pg
        Dim O_pg = New System.Drawing.Printing.PageSettings
        ' 使用 PageSettings 的 Margins 屬性設定上、下、左、右邊的邊界
        O_pg.Margins.Top = 39.5
        O_pg.Margins.Bottom = 0
        O_pg.Margins.Left = 39.5
        O_pg.Margins.Right = 0
        ' 使用 PageSettings 的 Landscape 屬性設定直印或橫印
        O_pg.Landscape = False
        ' 依據 PaperSize 類別宣告新的紙張大小物件 O_size
        Dim O_size As New System.Drawing.Printing.PaperSize
        ' 使用 PaperSize 的 RawKind 屬性 設定紙張大小，紙張大小有 Letter、A4、B4 等
        O_size.RawKind = PaperKind.A4
        ' 將紙張大小物件 O_size 指定給 PageSettings 物件的 PaperSize 屬性
        O_pg.PaperSize = O_size
        ' 使用 ReportViewer 的 SetPageSettings 方法設定報表檢視器之列印方向、紙張大小及邊界
        ReportViewer1.SetPageSettings(O_pg)

        ' 設定報表資料來源（方法一）
        ' 清除資料來源
        ReportViewer1.LocalReport.DataSources.Clear()
        ' 宣告資料來源物件 O_rds
        Dim O_rds As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        ' 使用資料來源物件的 Name 屬性指定資料來源名稱，此名稱須為資料集名稱，該資料集已設定連結管道（SQL 命令無需抓出資料）
        O_rds.Name = "DataSet1"
        ' 使用資料來源物件的 Value 屬性指定實際要在 ReportViewer 報表檢視器中顯示的資料（前述使用程式抓出和於條件的資料）
        O_rds.Value = ODataSet_1.Tables("Table01")
        ' 使用報表檢視器的 DataSources.Add 方法 將資料來源物件加入 ReportViewer
        ReportViewer1.LocalReport.DataSources.Add(O_rds)

        ' 設定報表資料來源（方法二），須將 BindingSource 資料來源繫結控制項從工具箱中拖曳至表單
        ' 清除資料來源
        'ReportViewer1.LocalReport.DataSources.Clear()
        ' 繫結資料來源，實際要在 ReportViewer 報表檢視器中顯示的資料（前述使用程式抓出和於條件的資料）
        'BindingSource1.DataSource = ODataSet_1.Tables("Table01")
        ' 使用 ReportDataSource 建構函式 建立新的報表資料來源物件，括號內第一個參數為資料集名稱，第二個參數為繫結資料來源（DataTable）
        'Dim O_rds As New ReportDataSource("DataSet1", Me.BindingSource1)
        'ReportViewer1.LocalReport.DataSources.Add(O_rds)

        ' 設定報表格式檔（報表定義檔,）之來源
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        'ReportViewer1.LocalReport.ReportPath = "APPDATA\Report1.rdl"
        'ReportViewer1.LocalReport.ReportPath = "APPDATA\Report2.rdl"
        ReportViewer1.LocalReport.ReportPath = "APPDATA\Salary_01.rdl"

        ' 更新報表檢視器
        Me.ReportViewer1.RefreshReport()
        ReportViewer1.Visible = True

        ' 關閉 存取資料庫的相關物件
        ODataAdapter_1.Dispose()
        Ocn_1.Close()
        Ocn_1.Dispose()
    End Sub

    ' 隱藏報表檢視器
    Private Sub B_RV_Hide_Click(sender As Object, e As EventArgs) Handles B_RV_Hide.Click
        ReportViewer1.Visible = False
    End Sub

    ' 重設查詢條件
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        T_FILEDATE.Text = ""
        T_DEPTCODE.Text = ""
        T_Man.Checked = False
        T_Woman.Checked = False
        T_TITLE.Text = ""
        T_GRADE.Text = ""
        L_DEPTNAME.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    ' 當 User 敲選部門之後就啟動 Tab 鍵，將游標移至下一欄，
    ' 此動作會引發 T_DEPTCODE 的 Validated 事件，而該事件之程序可拆分 User 所選的部門代號及部門名稱，
    ' 若將 Validated 事件之程序併入本程序無法達到相同的效果
    Private Sub T_DEPTCODE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_DEPTCODE.SelectedIndexChanged
        SendKeys.Send("{Tab}")
    End Sub

    ' 當游標離開 T_DEPTCODE 部門文字盒時，拆分 User 所選的部門代號及部門名稱，以利後續程式可將其存入資料庫中不同的欄位
    Private Sub T_DEPTCODE_Validated(sender As Object, e As EventArgs) Handles T_DEPTCODE.Validated
        Dim MTempDept As String = RTrim(T_DEPTCODE.Text)
        Dim MLen As Integer = Len(MTempDept)
        If MLen = 0 Then
            L_DEPTNAME.Text = ""
            Exit Sub
        Else
            T_DEPTCODE.Text = Strings.Left(MTempDept, 4)
            If MLen >= 4 Then
                L_DEPTNAME.Text = Strings.Right(MTempDept, MLen - 4)
            End If
        End If

        ' 本欄允許 User 直接輸入部門代號，但須檢查 User 所輸入的值是否為下拉式選單的選項之一
        '  L_DEPTNAME 部門名稱亦需重新抓取
        ' T_DEPTCODE.Items(Mcou) 可傳回選單某一選項之內容
        Dim MTotalItems As Integer = T_DEPTCODE.Items.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            If LTrim(RTrim(T_DEPTCODE.Text)) = Strings.Left(T_DEPTCODE.Items(Mcou), 4) Then
                Dim MLenItem As Integer = Len(T_DEPTCODE.Items(Mcou))
                L_DEPTNAME.Text = Strings.Mid(T_DEPTCODE.Items(Mcou), 5, MLenItem - 4)
                Exit Sub
            End If
        Next
        MsgBox("所輸入的代號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正或清除", 0 + 16, "Error")
        T_DEPTCODE.Focus()

    End Sub

    ' 當 User 敲選職稱之後就啟動 Tab 鍵，將游標移至下一欄，
    ' 此動作會引發 T_TITLE 的 Validated 事件
    Private Sub T_TITLE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_TITLE.SelectedIndexChanged
        SendKeys.Send("{Tab}")
    End Sub

    ' 當游標離開 T_TITLE 職稱文字盒時，檢查 User 所輸入的值
    ' 因本欄允許 User 直接輸入職稱，故需檢查 User 所輸入的值是否為下拉式選單的選項之一
    Private Sub T_TITLE_Validated(sender As Object, e As EventArgs) Handles T_TITLE.Validated
        If T_TITLE.Text = "" Then
            Exit Sub
        Else
            Dim MTotalItems As Integer = T_TITLE.Items.Count
            For Mcou = 0 To MTotalItems - 1 Step 1
                If T_TITLE.Text = T_TITLE.Items(Mcou) Then
                    Exit Sub
                End If
            Next
            MsgBox("所輸入的代號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正或清除", 0 + 16, "Error")
            T_TITLE.Focus()
        End If
    End Sub

    ' 當 User 敲選等級之後就啟動 Tab 鍵，將游標移至下一欄，
    ' 此動作會引發 T_GRADE 的 Validated 事件
    Private Sub T_GRADE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_GRADE.SelectedIndexChanged
        SendKeys.Send("{Tab}")
    End Sub

    ' 當游標離開 T_GRADE 等級文字盒時，檢查 User 所輸入的值
    ' 因本欄允許 User 直接輸入等級，故需檢查 User 所輸入的值是否為下拉式選單的選項之一
    Private Sub T_GRADE_Validated(sender As Object, e As EventArgs) Handles T_GRADE.Validated
        If T_GRADE.Text = "" Then
            Exit Sub
        Else
            Dim MTotalItems As Integer = T_GRADE.Items.Count
            For Mcou = 0 To MTotalItems - 1 Step 1
                If T_GRADE.Text = T_GRADE.Items(Mcou) Then
                    Exit Sub
                End If
            Next
            MsgBox("所輸入的代號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正或清除", 0 + 16, "Error")
            T_GRADE.Focus()
        End If
    End Sub

    ' 產生條碼
    Private Sub B_Create_Click(sender As Object, e As EventArgs) Handles B_Create.Click
        If Strings.Trim(TextBox1.Text) = "" Then
            MsgBox("Sorry, 請先在『代號』欄輸入英文、阿拉伯數字或 $ % + - . / 等符號！", 0 + 16, "Error")
            TextBox1.Focus()
            Exit Sub
        End If
        Dim Mtemp As String = "*" + Strings.UCase(TextBox1.Text) + "*"
        TextBox2.Font = New Font("Free 3 of 9", 24)
        TextBox2.Text = Mtemp
    End Sub

    ' 列印條碼
    Private Sub B_PrintBarCode_Click(sender As Object, e As EventArgs) Handles B_PrintBarCode.Click
        If Strings.Trim(TextBox2.Text) = "" Then
            MsgBox("Sorry, 條碼尚未產生，請先敲『產生條碼』鈕！", 0 + 16, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        ' 資料欲由印表機印出，需先將文字或圖形輸出到 PrintDocument 列印文件控制項（本例取名為 O_PrintDocument5 ）
        O_PrintDocument5 = New Printing.PrintDocument

        ' 使用 PrintDocument 的 DefaultPageSettings.Margins 屬性設定上、下、左、右邊界的大小
        O_PrintDocument5.DefaultPageSettings.Margins.Top = 20
        O_PrintDocument5.DefaultPageSettings.Margins.Bottom = 10
        O_PrintDocument5.DefaultPageSettings.Margins.Left = 20
        O_PrintDocument5.DefaultPageSettings.Margins.Right = 10

        ' 使用 PrintDocument 的 DefaultPageSettings.Landscape 屬性設定直印或橫印，Landscape = False 為直印
        O_PrintDocument5.DefaultPageSettings.Landscape = False

        ' 使用 PrintDocument 的 DefaultPageSettings.PaperSizes 屬性設定紙張大小
        Dim O_PageSize5 As System.Drawing.Printing.PaperSize
        For Each O_PageSize5 In O_PrintDocument5.PrinterSettings.PaperSizes
            If O_PageSize5.PaperName = "A4" Then
                O_PrintDocument5.DefaultPageSettings.PaperSize = O_PageSize5
                Exit For
            End If
        Next

        ' 使用 PrintDocument 的 Print 方法啟動文件的列印處理序（可觸發 PrintDocument 的 PrintPage 事件程序）
        ' 下列程式可直接印出，無對話方塊
        'O_PrintDocument5.Print()

        ' 顯示列印對話方塊
        ' 若 User 敲了『取消』鈕，則離開本程序，
        ' 若 User 敲了『列印』鈕，則顯示預覽列印對話方塊
        Me.TopMost = False
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            O_PrintDocument5.Dispose()
            Exit Sub
        End If

        ' 顯示預覽對話方塊
        ' 先使用 PrintPreviewDialog 預覽對話方塊的 Document 屬性設定預覽的文件
        ' 再使用 PrintPreviewDialog 預覽對話方塊的 ShowDialog 方法顯示預覽對話方塊
        O_PrintPreview5.Document = O_PrintDocument5
        O_PrintPreview5.ShowDialog()

        ' 釋放資源
        O_PrintDocument5.Dispose()
        Me.TopMost = True
    End Sub

    ' 本段為 PrintDocument 的 PrintPage 列印頁事件程序
    ' 使用  PrintDocument 的 Print 方法就會觸動本事件
    ' 欲列印的資料及圖形需寫在本事件中，亦即在本程序中宣告繪圖物件，再傳給 PrintDocument 控制項
    Private Sub O_PrintDocument5_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles O_PrintDocument5.PrintPage

        ' 使用  New 關鍵字宣告繪出字型
        Dim O_Font01 As Font = New Font("Free 3 of 9", 24, FontStyle.Regular)
        Dim O_Font02 As Font = New Font("Arial", 10, FontStyle.Regular)

        ' 使用 Pen 建構函式宣告畫筆物件，括號內有兩個參數，第一個為顏色，第二個為寬度
        Dim O_Pen As Pen = New Pen(Color.Black, 0.1)

        ' 使用 Graphics 繪圖物件的 PageScale 屬性 取得或設定在這個 Graphics 的自然單位和畫面單位之間的縮放值
        e.Graphics.PageScale = PaperKind.A4

        ' 使用 Graphics 繪圖物件的 PageUnit 屬性 設定在畫面座標所使用的測量單位
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' 使用 Graphics 繪圖物件的 DrawString 方法 繪製字串
        ' 使用指定的 Brush 和 Font 物件，將指定的文字字串繪製於指定的位置。 
        ' 括號內有 3 個參數，第一個為要繪製的字串，第二個為字串格式，由 O_Font 物件定義，
        ' 第三個為字串的樣式及顏色格式，由 O_Brash 物件定義，本例定義為黑色實心筆刷，
        ' 第三個為繪製字串的左上角座標
        ' 使用 Point 結構定義 X 軸（橫軸）座標及 Y 軸（縱軸）座標，括號內有兩個參數，前者為 X 軸座標，後者為 Y 軸座標，
        ' 紙張左上角為原點(0,0)， X 軸之值越大離左邊界越遠，Y 軸之值越大離上邊界越遠
        ' Font 物件的 Height 屬性可傳回字型的高度
        Dim O_Brash As SolidBrush = New SolidBrush(Color.Black)
        Dim O_Point1 As Point = New Point(1, 2)
        e.Graphics.DrawString(TextBox2.Text, O_Font01, O_Brash, O_Point1)
        Dim O_Point2 As Point = New Point(1, 5)
        e.Graphics.DrawString(TextBox1.Text, O_Font02, O_Brash, O_Point2)

    End Sub

    ' 結束
    Private Sub B_Close_Click(sender As Object, e As EventArgs) Handles B_Close.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            Application.Exit()
        Else
            Return
        End If
    End Sub

End Class