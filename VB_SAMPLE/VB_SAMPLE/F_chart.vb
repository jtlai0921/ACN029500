Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Printing

Public Class F_chart
    ' 宣告  ODataSet_0 資料集，供不同程序使用
    Public ODataSet_0 As DataSet = New DataSet



    ' ***************************************************************************************************
    ' 載入本表單時，讀取 魚類銷售統計.xlsx
    Private Sub F_chart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 設定連接字串，供 OleDbConnection 物件使用
        ' Extended Properties=之後的參數要用單引號括起來，否則會出现“找不到可安装的 ISAM”的訊息
        ' HDR=Yes　表示 Excel 表的第一列為欄名，No 则表示第一列不是欄名
        ' IMEX=1; 將文數字混雜的欄位資料視為文字來處理，例如 QTY 欄名為文字 而 HDR=NO，IMEX=1，則該欄之數字會被視為文字來處理，
        ' 若 HDR=Yes，IMEX=1，則該欄之數字會被視為數字來處理，例如 12,345 變成 12345
        ' OLEDB.12 可連結新版及舊版的 Excel，但需安裝 Office 2007（含）以上，OLEDB.4 只能連結舊版的 Excel
        ' Office 版本編號： 2003 → 11 、 2007 → 12 、 2010 → 14 、 2013 → 15
        Dim MFN_0 As String = "APPDATA\魚類銷售統計.xlsx"
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
        'Dim ODataSet_0 As DataSet = New DataSet
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
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_0.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Oconn_0.Close()
        Oconn_0.Dispose()
        ODataAdapter_0.Dispose()

        ' 計算總筆數，另在 SelectionChanged 事件中顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        Dim MTotalRecordNo As Int32
        MTotalRecordNo = ODataSet_0.Tables("Table01").Rows.Count
        DataGridView1(0, 0).Selected = True
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        '資料網格控制項格式化
        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "今年數量"
            .Columns(2).HeaderText = "去年數量"
        End With
        ' 欄位格式化，
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 方法，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，後者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If
        DataGridView1.Refresh()
    End Sub

    ' 繪圖 1，有一個數列
    Private Sub B_Chart1_Click(sender As Object, e As EventArgs) Handles B_Chart1.Click

        ' 將 User 所敲選的圖形名稱存入變數
        Dim Mtype As String = ""
        If RB_1.Checked = True Then
            Mtype = RB_1.Text
        End If
        If RB_2.Checked = True Then
            Mtype = RB_2.Text
        End If
        If RB_3.Checked = True Then
            Mtype = RB_3.Text
        End If
        If RB_4.Checked = True Then
            Mtype = RB_4.Text
        End If
        If RB_5.Checked = True Then
            Mtype = RB_5.Text
        End If
        If RB_6.Checked = True Then
            Mtype = RB_6.Text
        End If
        If Mtype = "" Then
            MsgBox("Sorry, 請先在表單右上角敲選圖形！" + Chr(13) + Chr(13) + "再敲『繪圖 1』鈕。", 0 + 16, "Error")
            Exit Sub
        End If

        ' 清除圖表資料來源
        Chart1.DataSource = Nothing
        ' 清除數列、標題文字（表頭）、圖例
        Chart1.Series.Clear()
        Chart1.Titles.Clear()
        Chart1.Legends.Clear()

        ' 設定圖表的背景色及框線
        Chart1.BackColor = Color.OldLace
        Chart1.BorderlineDashStyle = ChartDashStyle.Solid
        Chart1.BorderlineWidth = 1
        Chart1.BorderlineColor = Color.Black

        ' 宣告數列並將其加入圖表1
        Dim Series1 As Series = New Series()
        Chart1.Series.Add(Series1)

        ' 設定圖表的資料來源
        ' 數列1各個資料點的標記取自 Table01 資料表的第一欄
        ' 數列1各個資料點的數據取自 Table01 資料表的第二欄
        Chart1.DataSource = ODataSet_0.Tables("Table01")
        Chart1.Series("Series1").XValueMember = "F1"
        Chart1.Series("Series1").YValueMembers = "F2"

        ' 各個資料點不設框線
        Chart1.Series("Series1").BorderDashStyle = ChartDashStyle.NotSet

        ' 依據 User 之敲選設定圖型種類
        Select Case Mtype
            Case "長條圖"
                Series1.ChartType = SeriesChartType.Column
            Case "折線圖"
                Series1.ChartType = SeriesChartType.FastLine
                ' 折線圖設框線，可使線條較厚實，視覺上較清楚
                Chart1.Series("Series1").BorderDashStyle = ChartDashStyle.Solid
                Chart1.Series("Series1").BorderColor = Color.Black
                Chart1.Series("Series1").BorderWidth = 3
            Case "橫條圖"
                Series1.ChartType = SeriesChartType.Bar
            Case "圓餅圖"
                'Series1.ChartType = 18
                Series1.ChartType = SeriesChartType.Pie
                ' 加入圖例（限圓餅圖，其他圖形無需）
                Dim Legend1 As Legend = New Legend
                Chart1.Legends.Add(Legend1)
            Case "區域圖"
                Series1.ChartType = SeriesChartType.Area
            Case "雷達圖"
                Series1.ChartType = SeriesChartType.Radar
        End Select

        ' 設定圖型的色盤
        Chart1.Palette = ChartColorPalette.BrightPastel

        ' 設定Y軸數據之型態
        Chart1.Series("Series1").YValueType = ChartValueType.Int32

        ' 顯示各個資料點的標記
        ' 設定各個資料點標記的字型屬性
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").LabelForeColor = Color.Black
        Chart1.Series("Series1").Font = New Font("Arial", 12)

        ' 取消格線
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False

        ' 增加另一個Y軸
        Chart1.ChartAreas(0).AxisY2.Enabled = AxisEnabled.True

        ' 設定圖表區的背景色
        Chart1.ChartAreas(0).BorderColor = Color.White
        ' 設定圖表區的框線
        Chart1.ChartAreas(0).BorderDashStyle = ChartDashStyle.Solid
        Chart1.ChartAreas(0).BorderColor = Color.Navy
        Chart1.ChartAreas(0).BorderWidth = 1

        ' 宣告兩個標題並將其加入圖表1
        ' 設定標題文字及其字型之屬性
        Dim Title1 As Title = New Title
        Chart1.Titles.Add(Title1)
        Chart1.Titles(0).Text = "魚類銷售統計"
        Chart1.Titles(0).Font = New Font("微軟正黑體", 14)
        Chart1.Titles(0).ForeColor = Color.Navy

        ' 設定X軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisX.Title = "品名"
        Chart1.ChartAreas(0).AxisX.TitleFont = New Font("微軟正黑體", 12)
        Chart1.ChartAreas(0).AxisX.TitleForeColor = Color.DarkRed

        ' 設定Y軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisY.Title = "數量"
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("微軟正黑體", 12)
        Chart1.ChartAreas(0).AxisY.TitleForeColor = Color.DarkRed

        ' 設定X軸標記的顯示方式
        Chart1.ChartAreas(0).AxisX.Interval = AutoSize
        Chart1.ChartAreas(0).AxisX.IntervalOffset = 1

        ' 設定Y軸標記的顯示方式
        Chart1.ChartAreas(0).AxisY.Interval = AutoSize

    End Sub

    ' 繪圖 2，有兩個數列
    Private Sub B_Chart2_Click(sender As Object, e As EventArgs) Handles B_Chart2.Click

        ' 清除圖表資料來源
        Chart1.DataSource = Nothing
        ' 清除數列、標題文字（表頭）、圖例
        Chart1.Series.Clear()
        Chart1.Titles.Clear()
        Chart1.Legends.Clear()

        ' 設定圖表的背景色及框線
        'Chart1.BackColor = Color.OldLace
        Chart1.BackColor = Color.White
        Chart1.BorderlineDashStyle = ChartDashStyle.Solid
        Chart1.BorderlineWidth = 1
        Chart1.BorderlineColor = Color.Black

        ' 宣告數列兩個並將其加入圖表1
        Dim Series1 As Series = New Series()
        Chart1.Series.Add(Series1)
        Dim Series2 As Series = New Series()
        Chart1.Series.Add(Series2)

        ' 設定圖表的資料來源
        ' 數列1各個資料點的標記取自 Table01 資料表的第一欄
        ' 數列1各個資料點的數據取自 Table01 資料表的第二欄
        ' 數列2各個資料點的數據取自 Table01 資料表的第三欄
        Chart1.DataSource = ODataSet_0.Tables("Table01")
        Chart1.Series("Series1").XValueMember = "F1"
        Chart1.Series("Series1").YValueMembers = "F2"
        Chart1.Series("Series2").XValueMember = "F1"
        Chart1.Series("Series2").YValueMembers = "F3"

        ' 加入圖例（兩個），分別說明數列1及數列2
        Dim Legend1 As Legend = New Legend
        Chart1.Legends.Add(Legend1)
        Series1.LegendText = "今年數量"
        Dim Legend2 As Legend = New Legend
        Chart1.Legends.Add(Legend2)
        Series2.LegendText = "去年數量"

        '設定圖型種類（直條圖）
        Series1.ChartType = SeriesChartType.RangeColumn
        Series2.ChartType = SeriesChartType.RangeColumn

        ' 設定圖型顏色（使用色盤）
        Chart1.Palette = ChartColorPalette.SeaGreen
        ' 設定圖型顏色（自訂）
        'Chart1.Series("Series1").Color = Color.DarkBlue
        'Chart1.Series("Series2").Color = Color.LightSeaGreen

        ' 各個資料點不設框線
        Chart1.Series("Series1").BorderDashStyle = ChartDashStyle.NotSet
        Chart1.Series("Series2").BorderDashStyle = ChartDashStyle.NotSet

        ' 設定Y軸數據之型態
        Chart1.Series("Series1").YValueType = ChartValueType.Int32
        Chart1.Series("Series2").YValueType = ChartValueType.Int32

        ' 不顯示各個資料點的標記
        Chart1.Series("Series1").IsValueShownAsLabel = False

        ' 顯示格線
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = True
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = True

        ' 不增加另一個Y軸
        Chart1.ChartAreas(0).AxisY2.Enabled = AxisEnabled.False

        ' 設定圖表區的背景色
        Chart1.ChartAreas(0).BackColor = Color.White
        ' 設定圖表區的框線
        Chart1.ChartAreas(0).BorderDashStyle = ChartDashStyle.Solid
        Chart1.ChartAreas(0).BorderColor = Color.Navy
        Chart1.ChartAreas(0).BorderWidth = 1

        ' 宣告兩個標題並將其加入圖表1
        ' 設定標題文字及其字型之屬性
        Dim Title1 As Title = New Title
        Chart1.Titles.Add(Title1)
        Chart1.Titles(0).Text = "魚類銷售統計"
        Chart1.Titles(0).Font = New Font("微軟正黑體", 16)
        Chart1.Titles(0).ForeColor = Color.Navy

        ' 設定X軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisX.Title = "品名"
        Chart1.ChartAreas(0).AxisX.TitleFont = New Font("微軟正黑體", 14)
        Chart1.ChartAreas(0).AxisX.TitleForeColor = Color.DarkGreen

        ' 設定Y軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisY.Title = "數量"
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("微軟正黑體", 14)
        Chart1.ChartAreas(0).AxisY.TitleForeColor = Color.DarkGreen

        ' 設定X軸標記的顯示方式
        Chart1.ChartAreas(0).AxisX.Interval = AutoSize
        Chart1.ChartAreas(0).AxisX.IntervalOffset = 1

        ' 設定Y軸標記的顯示方式（每50個單位顯示一個刻度）
        Chart1.ChartAreas(0).AxisY.Interval = 50

    End Sub

    ' 存成圖檔，使用 Chart 類別的 SaveImage 方法可將圖表存成 Gif、Bmp、Jpeg、Png、Wmf 等類型的圖檔
    ' SaveImage 方法有兩個參數，前者為圖檔之檔名及其路徑，後者為圖檔類型
    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        ' 使用 FileSystem 類別的 MkDir 方法建立新資料夾，
        ' 先使用 Directory 類別的 Exists 方法 檢查資料夾是否已存在
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        Dim MfileName As String = "D:\TestQuery\TestChart01.jpg"
        Chart1.SaveImage(MfileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        MsgBox("圖表已存入 D:\TestQuery 資料夾！", 0 + 64, "OK")

    End Sub

    ' 使用 Chart 控制項的 Printing 屬性圖表列印
    ' 使用  Chart1.Printing.Print(True) 或 Chart1.Printing.PrintPreview() 可從印表機印出圖表或先預覽再列印，但缺少圖表大小及位置之設定（印在紙張的中間）
    ' 有關列印之詳細說明請參閱第七章
    ' 需引用命名空間 System.Drawing.Printing
    Private Sub B_Print_Click(sender As Object, e As EventArgs) Handles B_Print.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要列印圖表嗎？" + Chr(13) + Chr(13) + "1. 請先打開印表機電源。" + Chr(13) + "2. 螢幕會顯示預覽列印視窗，敲印表機圖示可印出圖表。", 4 + 32 + 256, "Confirm")
        If MANS <> 6 Then
            Exit Sub
        End If

        ' 宣告 O_PD1  為 輸出到印表機的物件
        Dim O_PD1 As New Printing.PrintDocument
        ' 宣告 O_PPV1 為 預覽對話方塊物件
        Dim O_PPV1 As New PrintPreviewDialog

        ' 使用 PrintDocument 的 DefaultPageSettings.Margins 屬性設定上、下、左、右邊界的大小
        O_PD1.DefaultPageSettings.Margins.Top = 50
        O_PD1.DefaultPageSettings.Margins.Bottom = 50
        O_PD1.DefaultPageSettings.Margins.Left = 50
        O_PD1.DefaultPageSettings.Margins.Right = 50

        ' 使用 PrintDocument 的 DefaultPageSettings.Landscape 屬性設定直印或橫印，Landscape = False 為直印
        O_PD1.DefaultPageSettings.Landscape = False

        ' 使用 PrintDocument 的 DefaultPageSettings.PaperSizes 屬性設定紙張大小
        Dim O_PageSize As System.Drawing.Printing.PaperSize
        For Each O_PageSize In O_PD1.PrinterSettings.PaperSizes
            If O_PageSize.PaperName = "A4" Then
                O_PD1.DefaultPageSettings.PaperSize = O_PageSize
                Exit For
            End If
        Next

        ' 觸發 PrintPage 事件程序，該事件中設定了圖表列印位置及其大小
        ' 需傳遞相關列印參數，故列印程式不能寫於一般副程序，而須寫於 PrintPage 列印頁事件程序，
        ' 該事件程序需使用 AddHandler 陳述式呼叫，可在執行階段使事件與事件處理常式產生關聯，
        ' AddHandler 後接所要繫結的事件（本例為 O_PD1  的 PrintPage 事件，亦即列印文件的列印事件），
        ' AddressOf 後接欲處理的程序名稱（本例為 O_PD1 _PrintPage）
        AddHandler O_PD1.PrintPage, AddressOf O_PD1_PrintPage

        ' 下列指令可將圖表直接從印表機印出
        ' O_PD1 .Print()

        ' 先預覽再列印（在預覽視窗中敲印表機圖示可印出圖表）
        Me.TopMost = False
        O_PPV1.Document = O_PD1
        O_PPV1.ShowDialog()
        Me.TopMost = True

        ' 釋放資源
        O_PD1.Dispose()
    End Sub

    ' 列印頁事件程序
    Private Sub O_PD1_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        ' Rectangle 結構所儲存的整數表示矩形的位置和大小，
        ' 第一個參數為長方形左上角的 X 座標（數值越大離紙張左邊越遠），第二個參數為長方形左上角的 Y 座標（數值越大離紙張上邊越遠），
        ' 第三個參數為長方形的寬度，第四個參數為長方形的高度
        Dim O_Rectangle As New System.Drawing.Rectangle(10, 30, 600, 500)
        ' 使用 Chart.Printing 屬性的 PrintPaint 方法印出圖表，括號內兩個參數，第一個為列印頁事件參數，第二個為圖表在紙張上的區域（位置及大小）
        Chart1.Printing.PrintPaint(ev.Graphics, O_Rectangle)
    End Sub

    ' 以程式產生圖型（載入本表單之預設長條圖）
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click

        ' 清除圖表資料來源
        Chart1.DataSource = Nothing
        ' 清除數列、標題文字（表頭）、圖例
        Chart1.Series.Clear()
        Chart1.Titles.Clear()
        Chart1.Legends.Clear()

        ' 設定圖表的背景色及框線
        Chart1.BackColor = Color.OldLace
        Chart1.BorderlineDashStyle = ChartDashStyle.Solid
        Chart1.BorderlineWidth = 1
        Chart1.BorderlineColor = Color.Black

        ' 宣告數列並將其加入圖表1
        Dim Series1 As Series = New Series()
        Chart1.Series.Add(Series1)
        ' 加入資料點
        Chart1.Series("Series1").Points.AddXY("香蕉", 10)
        Chart1.Series("Series1").Points.AddXY("蘋果", 30)
        Chart1.Series("Series1").Points.AddXY("鳳梨", 20)

        '設定圖型種類（直條圖）
        'Series1.ChartType = SeriesChartType.RangeColumn
        Series1.ChartType = SeriesChartType.Column

        ' 自訂各個資料點的顏色
        Chart1.Series("Series1").Points(0).Color = Color.FromArgb(128, 0, 128)
        'Chart1.Series("Series1").Points(0).Color = Color.Purple
        Chart1.Series("Series1").Points(1).Color = Color.OrangeRed
        Chart1.Series("Series1").Points(2).Color = Color.Teal
        ' 自訂各個資料點的框線（不設框線）
        Chart1.Series("Series1").Points(0).BorderDashStyle = ChartDashStyle.NotSet
        Chart1.Series("Series1").Points(1).BorderDashStyle = ChartDashStyle.NotSet
        Chart1.Series("Series1").Points(2).BorderDashStyle = ChartDashStyle.NotSet
        ' 設定Y軸數據之型態
        Chart1.Series("Series1").YValueType = ChartValueType.Int32

        ' 顯示各個資料點的標記
        ' 設定各個資料點標記的字型屬性
        Chart1.Series("Series1").Points(0).IsValueShownAsLabel = True
        Chart1.Series("Series1").Points(1).IsValueShownAsLabel = True
        Chart1.Series("Series1").Points(2).IsValueShownAsLabel = True
        Chart1.Series("Series1").Points(0).LabelForeColor = Color.Black
        Chart1.Series("Series1").Points(0).Font = New Font("Arial", 11)
        Chart1.Series("Series1").Points(1).LabelForeColor = Color.Black
        Chart1.Series("Series1").Points(1).Font = New Font("Arial", 11)
        Chart1.Series("Series1").Points(2).LabelForeColor = Color.Black
        Chart1.Series("Series1").Points(2).Font = New Font("Arial", 11)

        ' 取消格線
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False

        ' 增加另一個Y軸
        Chart1.ChartAreas(0).AxisY2.Enabled = AxisEnabled.True

        ' 設定圖表區的背景色
        Chart1.ChartAreas(0).BorderColor = Color.White
        ' 設定圖表區的框線
        Chart1.ChartAreas(0).BorderDashStyle = ChartDashStyle.Solid
        Chart1.ChartAreas(0).BorderColor = Color.Navy
        Chart1.ChartAreas(0).BorderWidth = 1

        ' 宣告兩個標題並將其加入圖表1
        ' 設定標題文字及其字型之屬性
        Dim Title1 As Title = New Title
        Chart1.Titles.Add(Title1)
        Dim Title2 As Title = New Title
        Chart1.Titles.Add(Title2)
        Chart1.Titles(0).Text = "銷售統計圖"
        Chart1.Titles(1).Text = "2015年"
        Chart1.Titles(0).Font = New Font("微軟正黑體", 14)
        Chart1.Titles(0).ForeColor = Color.Navy
        Chart1.Titles(1).Font = New Font("微軟正黑體", 10)
        Chart1.Titles(1).ForeColor = Color.DarkGreen

        ' 設定X軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisX.Title = "品名"
        Chart1.ChartAreas(0).AxisX.TitleFont = New Font("微軟正黑體", 12)
        Chart1.ChartAreas(0).AxisX.TitleForeColor = Color.Navy

        ' 設定Y軸標題及其字型之屬性
        Chart1.ChartAreas(0).AxisY.Title = "公噸"
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("微軟正黑體", 12)
        Chart1.ChartAreas(0).AxisY.TitleForeColor = Color.Navy

        ' 設定X軸標記的顯示方式
        Chart1.ChartAreas(0).AxisX.Interval = AutoSize
        Chart1.ChartAreas(0).AxisX.IntervalOffset = 1

        ' 設定Y軸標記的顯示方式
        Chart1.ChartAreas(0).AxisY.Interval = AutoSize

    End Sub

    ' 離開本表單
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