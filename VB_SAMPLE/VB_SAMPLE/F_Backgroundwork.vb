Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Class F_Backgroundwork

    ' 宣告公用資料處理物件及公用變數，以便在不同程序中使用
    Public O_conn_01 As OleDbConnection
    Public O_cmd_01 As OleDbCommand
    Public O_adp_01 As OleDbDataAdapter
    Public O_dset_01 As DataSet
    'Public O_dtable_01 As DataTable
    Public O_dv_01 As DataView
    Public MQ_branch As String = ""
    Public MQ_dogtypes As String = ""
    Public MQ_saledatea As String = ""
    Public MQ_saledateb As String = ""
    Public MMM As String = ""
    Public M_recno As Integer = 0
    Public M_TotalQty As Integer = 0
    Public MTempTime As Date

    ' 更改進度條顏色之方法
    ' 1. 敲『專案』、『.....屬性』，進入發行精靈， 敲左方的『應用程式』，然後取消『啟用XP視覺化樣式』前方的勾號，
    '     ProgressBar1.ForeColor 之設定即可生效，例如 ProgressBar1.ForeColor=Color.SkyBlue
    ' 2. 使用 API 函數
    'Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    ' 先於預設建構函式 New() ，作 BackgroundWorker 背景執行個體、ProgressBar 進度條
    ' 設定 BackgroundWorker 背景執行個體的 WorkerReportsProgress，該屬性設為 True ，可引發 ProgressChanged 事件，
    ' 設定 BackgroundWorker 背景執行個體的 WorkerSupportsCancellation ，該屬性設為 True ，才能支援取消作業的動作（亦即使該類別可呼叫 CancelAsync方法）
    ' 進度條最小值、進度條最大值、進度條目前進度值、進度條前進單位
    ' 設定 Timer1 計時器之觸發時間及反致能
    '  InitializeComponent() 是 .NET平台自動執行的，主要的工作是做一些初始化的工作
    Public Sub New()
        InitializeComponent()
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True

        Label1.Visible = False
        ProgressBar1.Visible = False
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0
        ProgressBar1.Step = 10
        ' 設定進度條顏色 1 綠色、2 紅色、3 黃色
        'SendMessage(ProgressBar1.Handle, 1040, 2, 0)

        Timer1.Interval = 1000
        Timer1.Enabled = False
    End Sub

    ' 按下『開始』鈕，啟動背景工作
    Private Sub B_GO_Click(sender As System.Object, e As System.EventArgs) Handles B_GO.Click

        ' 開始計時
        MTempTime = DateTime.Now

        ' 清除前次的查詢結果，將進度條目前進度值歸零，合計筆數歸零，合計數量歸零
        DataGridView1.DataSource = Nothing
        ProgressBar1.Value = 0
        M_recno = 0
        M_TotalQty = 0

        ' 加入虛擬欄位
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("a", "分店")
            DataGridView1.Columns.Add("b", "銷售日")
            DataGridView1.Columns.Add("c", "品種")
            DataGridView1.Columns.Add("d", "單價")
            DataGridView1.Columns.Add("e", "數量")
        End If

        L_RECNO.Text = "筆數： 0"
        L_TOTALQTY.Text = "合計數量： 0"
        L_ElapsedTime.Text = "耗用時間： 0 秒"
        MQ_branch = Trim(T_BRANCH.Text)
        MQ_dogtypes = Trim(T_DOGTYPES.Text)
        MQ_saledatea = Trim(T_SALEDATEA.Text)
        MQ_saledateb = Trim(T_SALEDATEB.Text)

        ' 檢查銷售日是否正確，起訖日都需指定或都不指定
        If Len(MQ_saledatea) <> 0 Then
            If Len(MQ_saledatea) <> 10 Then
                MsgBox("起始銷售日不正確！", 0 + 16, "Error")
                T_SALEDATEA.Focus()
                Exit Sub
            End If
            If IsDate(MQ_saledatea) = False Then
                MsgBox("起始銷售日不正確！", 0 + 16, "Error")
                T_SALEDATEA.Focus()
                Exit Sub
            End If
        End If

        If Len(MQ_saledateb) <> 0 Then
            If Len(MQ_saledateb) <> 10 Then
                MsgBox("終止銷售日不正確！", 0 + 16, "Error")
                T_SALEDATEB.Focus()
                Exit Sub
            End If
            If IsDate(MQ_saledateb) = False Then
                MsgBox("終止銷售日不正確！", 0 + 16, "Error")
                T_SALEDATEB.Focus()
                Exit Sub
            End If
        End If

        If Len(MQ_saledatea) = 0 And Len(MQ_saledateb) <> 0 Then
            MsgBox("起始銷售日未指定！" + Chr(13) + Chr(10) + "起迄日需同時指定或都不指定", 0 + 16, "Error")
            T_SALEDATEA.Focus()
            Exit Sub
        End If
        If Len(MQ_saledatea) <> 0 And Len(MQ_saledateb) = 0 Then
            MsgBox("終止銷售日未指定！" + Chr(13) + Chr(10) + "起迄日需同時指定或都不指定", 0 + 16, "Error")
            T_SALEDATEB.Focus()
            Exit Sub
        End If

        If Len(MQ_saledatea) <> 0 And Len(MQ_saledateb) <> 0 Then
            If MQ_saledatea > MQ_saledateb Then
                MsgBox("起始日不能大於終止日！", 0 + 16, "Error")
                T_SALEDATEA.Focus()
                Exit Sub
            End If
        End If

        ' IsBusy 屬性<> True，表示 BackgroundWorker 執行個體尚未執行
        ' RunWorkerAsync 方法 可觸發 DoWork 事件開始執行背景工作，需要在背景中執行的程序可撰寫於DoWork事件程序中
        If BackgroundWorker1.IsBusy <> True Then
            Label1.Visible = True
            ProgressBar1.Visible = True
            CheckedListBox1.Visible = True
            ' 使各個按鈕反致能
            B_GO.Enabled = False
            B_RESET.Enabled = False
            B_OneThread.Enabled = False
            MyClass_ButtonClose1.Enabled = False

            ' 啟動計時器以便顯示進度條
            Timer1.Enabled = True
            ' 啟動背景工作
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    ' 背景工作之 DoWork 工作執行事件（主要處理工作寫於此段）
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ' 報告進度 1（正在讀取資料）**********************************************************************
        BackgroundWorker1.ReportProgress(1)

        ' 使用 OleDb 讀取 DogSale.csv 狗仔銷售紀錄檔的資料
        ' FMT=Delimited(,) 表示文字檔各欄的分隔符號為 為逗號
        Dim MFN_01 As String = "APPDATA\DogSale.csv"
        Dim Mstr_conn_01 As String = ""
        Mstr_conn_01 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\;Extended Properties='Text;HDR=Yes;IMEX=1;FMT=Delimited(,);'"

        ' 建立連結
        O_conn_01 = New OleDbConnection(Mstr_conn_01)
        O_conn_01.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_01 As String
        Mstr_com_01 = "SELECT * FROM " + MFN_01

        ' 建立命令物件 O_cmd_01
        O_cmd_01 = New OleDbCommand(Mstr_com_01, O_conn_01)

        ' 建立轉接器物件 O_adp_01
        O_adp_01 = New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_01.SelectCommand = O_cmd_01

        ' 建立資料集物件 O_dset_01
        O_dset_01 = New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料集
        ' Fill 方法 之括號內有兩個參數，前者為資料集的名稱，後者為資料表的名稱
        O_adp_01.Fill(O_dset_01, "DATA01")

        ' 將資料集中的第一個資料表存入 datatable（此處無需要）
        'O_dtable_01 = O_dset_01.Tables("DATA01")

        ' 建立資料檢視物件 O_dv_01
        O_dv_01 = O_dset_01.Tables("DATA01").DefaultView

        ' 報告進度 2（正在篩選資料） **********************************************************************
        BackgroundWorker1.ReportProgress(2)

        ' 過濾資料檢視物件的資料
        ' 重設 MMM 為空字串，否則會殘留前一次的查詢條件
        MMM = ""
        If Len(MQ_branch) <> 0 Then
            MMM = "branch=" + "'" + MQ_branch + "'"
        End If

        If Len(MMM) = 0 Then
            If Len(MQ_dogtypes) <> 0 Then
                MMM = "dogtypes=" + "'" + MQ_dogtypes + "'"
            End If
        Else
            If Len(MQ_dogtypes) <> 0 Then
                MMM = MMM + " and " + "dogtypes=" + "'" + MQ_dogtypes + "'"
            End If
        End If

        If Len(MMM) = 0 Then
            If Len(MQ_saledatea) <> 0 Then
                MMM = "sdate>=" + "#" + MQ_saledatea + "#" + " and " + "sdate<=" + "#" + MQ_saledateb + "#"
            End If
        Else
            If Len(MQ_saledatea) <> 0 Then
                MMM = MMM + " and " + "sdate>=" + "#" + MQ_saledatea + "#" + " and " + "sdate<=" + "#" + MQ_saledateb + "#"
            End If
        End If

        If Len(MMM) = 0 Then
            O_dv_01.RowFilter = "branch like '%'"
        Else
            O_dv_01.RowFilter = MMM
        End If
        M_recno = O_dv_01.Count

        ' 報告進度 3（正在匯出檔案） **********************************************************************
        BackgroundWorker1.ReportProgress(3)

        ' 建立目標資料夾
        Dim MDESDIR As New DirectoryInfo("C:\DATA_VBSAMPLE")
        If MDESDIR.Exists = False Then
            MDESDIR.Create()
        End If

        ' 使用 COM 物件 存取 Excel
        ' CreateObject 可建立一個已登錄於系統登錄檔的 ActiveX 物件
        ' 例如 Dim OLEAPP As Object = CreateObject("Word.Application") 

        Dim OLEAPP As Object = CreateObject("Excel.Application")
        OLEAPP.Visible = False
        '關閉警告視窗
        OLEAPP.DisplayAlerts = False

        ' 建立新的 Excel 活頁簿
        Dim MyNewWorkbook = OLEAPP.Workbooks.Add
        'Dim MyNewWorksheet = MyNewWorkbook.Worksheets.Add
        MyNewWorkbook.SaveAs("C:\DATA_VBSAMPLE\C01_BackGroundWork.xls")
        'MyNewWorksheet = Nothing
        MyNewWorkbook = Nothing

        ' 開啟目標活頁簿
        Dim MDESFN As String = "C:\DATA_VBSAMPLE\C01_BackGroundWork.xls"
        Dim Mybook As Object = OLEAPP.workbooks.open(MDESFN)

        ' 固定使用第一張工作表
        Dim MySheet As Object = Mybook.sheets(1)

        ' 將欄位名稱置入第一張工作表第一列
        MySheet.Cells(1, 1).Value = "分店"
        MySheet.Cells(1, 2).Value = "銷售日"
        MySheet.Cells(1, 3).Value = "品種"
        MySheet.Cells(1, 4).Value = "單價"
        MySheet.Cells(1, 5).Value = "數量"
        MySheet.Cells(1, 6).Value = "金額"

        ' 將 DataView 資料寫入 Excel 工作表，新增金額欄
        ' 加總數量並存入變數 M_TotalQty
        For Mcou = 1 To M_recno Step 1
            MySheet.Cells(Mcou + 1, 1).Value = O_dv_01(Mcou - 1)(0)
            MySheet.Cells(Mcou + 1, 2).Value = O_dv_01(Mcou - 1)(1)
            MySheet.Cells(Mcou + 1, 3).Value = O_dv_01(Mcou - 1)(2)
            MySheet.Cells(Mcou + 1, 4).Value = O_dv_01(Mcou - 1)(3)
            MySheet.Cells(Mcou + 1, 5).Value = O_dv_01(Mcou - 1)(4)
            MySheet.Cells(Mcou + 1, 6).Value = O_dv_01(Mcou - 1)(3) * O_dv_01(Mcou - 1)(4)
            M_TotalQty = M_TotalQty + O_dv_01(Mcou - 1)(4)
        Next

        ' 報告進度 4（正在格式化） **********************************************************************
        BackgroundWorker1.ReportProgress(4)
        ' 偵測資料區的範圍
        OLEAPP.Cells(M_recno + 1, 6).Select()
        Dim VADDRESS_E As String = OLEAPP.Selection.Address
        Dim VRANGE As String = "A2:" + VADDRESS_E

        ' 資料區格式化（調整字型大小、顏色及列高，第一列 24，其他有效列 18，欄寬 12，字形 Arial，大小 11）
        OLEAPP.Range(VRANGE).Select()
        OLEAPP.Selection.ColumnWidth = 12
        OLEAPP.Selection.RowHeight = 18
        OLEAPP.Selection.Font.Name = "微軟正黑體"
        OLEAPP.Selection.Font.FontStyle = "標準"
        OLEAPP.Selection.Font.Size = 11

        ' 資料區格式化格式化（白底，隱藏格線）
        OLEAPP.Selection.Interior.ColorIndex = 2
        OLEAPP.ActiveWindow.DisplayGridlines = False

        ' 銷售日置中並給予日期格式（yyyy/mm/dd），欄寬調為 14
        OLEAPP.Cells(M_recno + 1, 2).Select()
        Dim VADDRESS_E2 As String = OLEAPP.Selection.Address
        Dim VRANGE2 As String = "B2:" + VADDRESS_E2
        OLEAPP.Range(VRANGE2).Select()
        OLEAPP.Selection.ColumnWidth = 14
        OLEAPP.Selection.HorizontalAlignment = 3
        OLEAPP.Selection.NumberFormatLocal = "yyyy/mm/dd"

        ' 單價、數量及金額格式化（千位逗號、小數0位）
        OLEAPP.Cells(M_recno + 1, 6).Select()
        Dim VADDRESS_E3 As String = OLEAPP.Selection.Address
        Dim VRANGE3 As String = "D2:" + VADDRESS_E3
        OLEAPP.Range(VRANGE3).Select()
        OLEAPP.Selection.NumberFormatLocal = "#,##0_ "

        '『欄名』格式化
        OLEAPP.Cells(1, 6).Select()
        VADDRESS_E = OLEAPP.Selection.Address
        VRANGE = "A1:" + VADDRESS_E
        OLEAPP.Range(VRANGE).Select()
        ' 設定列高 24
        OLEAPP.Selection.RowHeight = 24
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
        'OLEAPP.Selection.HorizontalAlignment = xlCenter
        OLEAPP.Selection.HorizontalAlignment = 3
        ' 改字體（大小12、顏色紫色）
        OLEAPP.Selection.Font.Name = "微軟正黑體"
        OLEAPP.Selection.Font.FontStyle = "標準"
        OLEAPP.Selection.Font.Size = 12
        OLEAPP.Selection.Font.ColorIndex = 13

        ' 游標歸位
        OLEAPP.Range("A1").Select()
        OLEAPP.Range("A3").Select()

        ' 報告進度 5（正在更新 DataGridView） **********************************************************************
        BackgroundWorker1.ReportProgress(5)

        ' 關閉相關存取物件
        Mybook.Save()
        MySheet = Nothing
        Mybook = Nothing
        OLEAPP.Quit()

        ' 若於此處指定 DataGridView1 資料網格檢視的資料來源，則會出現下列錯誤訊息：
        ' 跨執行緒作業無效: 存取控制項 DataGridView1' 時所使用的執行緒與建立控制項的執行緒不同。
        ' 因為表單元件都在主執行緒執行，所以會出現跨執行緒的錯誤，
        ' 改進方法之一是將有關表單控制項的程式撰寫於 RunWorkerCompleted 背景工作完成事件中
        ' DataGridView1.DataSource =  O_dv_01
        'O_conn_01.Close()

        ' 呼叫 CancelAsync 方法，停止執行背景工作，該方法會自動將 CancellationPending 屬性設為 true
        BackgroundWorker1.CancelAsync()

    End Sub

    ' 背景工作之 ProgressChanged 進度變更事件
    ' 反映背景工作進度狀態
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                CheckedListBox1.SetItemChecked(0, True)
            Case 2
                CheckedListBox1.SetItemChecked(1, True)
            Case 3
                CheckedListBox1.SetItemChecked(2, True)
            Case 4
                CheckedListBox1.SetItemChecked(3, True)
            Case 5
                CheckedListBox1.SetItemChecked(4, True)
        End Select
    End Sub

    ' 背景工作之 RunWorkerCompleted 工作完成事件
    ' 進度條之進度值歸零
    ' 指定 DataGridView1 資料網格檢視的資料來源，以便將讀取的資料顯示於表單上
    ' 關閉資料處理物件
    ' 使各個按鈕致能
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ' 刪除虛擬欄位
        If DataGridView1.Columns.Count <> 0 Then
            DataGridView1.Columns.RemoveAt(4)
            DataGridView1.Columns.RemoveAt(3)
            DataGridView1.Columns.RemoveAt(2)
            DataGridView1.Columns.RemoveAt(1)
            DataGridView1.Columns.RemoveAt(0)
        End If
        DataGridView1.DataSource = O_dv_01

        L_RECNO.Text = "筆數： " + M_recno.ToString
        L_TOTALQTY.Text = "合計數量： " + M_TotalQty.ToString
        ' 本段ˋ調整每一筆資料的列高，不能寫於本表單之載入事件，因尚未指定資料來源，無法得知有哪些資料列
        ' AutoSizeRowsMode 須設為 None，但耗時甚久
        'Dim mtprow As Object
        'For Each mtprow In DataGridView1.Rows
        'mtprow.Height = 30
        'Next mtprow

        ' 不能寫於本表單之載入事件，因尚未指定資料來源，無法得知有哪些欄位
        ' 變更各欄位的名稱，日期欄格式化，數值欄加千位逗號
        With DataGridView1
            .Columns(0).HeaderText = "分店"
            .Columns(1).HeaderText = "銷售日"
            .Columns(1).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(2).HeaderText = "品種"
            .Columns(3).HeaderText = "單價"
            .Columns(3).DefaultCellStyle.Format = "#,0"
            .Columns(4).HeaderText = "數量"
        End With

        ' 變更各欄位名稱的字體
        ' 必須將 EnableHeadersVisualStyles 設為 False，否則無法變更欄名的前景色及背景色
        DataGridView1.EnableHeadersVisualStyles = False
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Font = New Font("微軟正黑體", 14, FontStyle.Regular)
            .BackColor = Color.Teal
            .ForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 關閉資料處理物件
        O_cmd_01.Dispose()
        O_adp_01.Dispose()
        O_conn_01.Close()
        O_conn_01.Dispose()

        ' 停止計時器，進度表取消勾選狀態，隱藏進度條及進度表，
        Timer1.Enabled = False
        Label1.Visible = False
        ProgressBar1.Visible = False
        CheckedListBox1.SetItemChecked(0, False)
        CheckedListBox1.SetItemChecked(1, False)
        CheckedListBox1.SetItemChecked(2, False)
        CheckedListBox1.SetItemChecked(3, False)
        CheckedListBox1.SetItemChecked(4, False)
        CheckedListBox1.Visible = False

        ' 結束計時並顯示耗用時間
        Dim MTempSec As Integer = DateDiff("s", MTempTime, DateTime.Now)
        Dim MResSec As Integer = MTempSec Mod 60
        Dim MResMin As Integer = Int(MTempSec / 60)
        L_ElapsedTime.Text = "耗用時間： " + MResMin.ToString + " 分 " + MResSec.ToString + " 秒"
        MsgBox("已處理完畢！" + Chr(13) + Chr(10) + "檔案已存入 C:\ DATA_VBSAMPLE \ C01_BackGroundWork.xls", 0 + 64, "OK")
        B_GO.Enabled = True
        B_RESET.Enabled = True
        B_OneThread.Enabled = True
        MyClass_ButtonClose1.Enabled = True

    End Sub

    ' 清除查詢條件
    Private Sub B_RESET_Click(sender As Object, e As EventArgs) Handles B_RESET.Click
        T_BRANCH.Text = ""
        T_DOGTYPES.Text = ""
        T_SALEDATEA.Text = ""
        T_SALEDATEB.Text = ""
        DataGridView1.DataSource = Nothing
        L_RECNO.Text = "筆數： 0"
        L_TOTALQTY.Text = "合計數量： 0"
        L_ElapsedTime.Text = "耗用時間：0 秒"

        ' 加入虛擬欄位
        ' 虛擬欄位之背景色需在 DataGridViewCellStyle 屬性中設定
        ' 刪除虛擬欄位，需先判斷是否已有欄位，否則每敲一次 Reset 鈕就會增加一組欄位
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("a", "分店")
            DataGridView1.Columns.Add("b", "銷售日")
            DataGridView1.Columns.Add("c", "品種")
            DataGridView1.Columns.Add("d", "單價")
            DataGridView1.Columns.Add("e", "數量")
        End If

    End Sub

    ' 載入本表單時，將 EnableHeadersVisualStyles 設為 False，以便自訂的欄名顏色可生效
    Private Sub F_Backgroundwork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.EnableHeadersVisualStyles = False
        T_BRANCH.Focus()
    End Sub

    ' 計時器之 Tick 事件，每1千豪秒執行下列程序一次
    ' 若進度條之進度值已達頂點，則歸零，以便反覆顯示前進之狀態
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Step
        Else
            ProgressBar1.Value = 0
        End If
    End Sub

    ' 單一執行緒
    Private Sub B_OneThread_Click(sender As Object, e As EventArgs) Handles B_OneThread.Click

        Label1.Visible = True
        MsgBox("本程式執行數字加總並顯示進度狀況，但兩項工作都在主執行緒處理，" + Chr(13) + Chr(10) + "故敲『確定』鈕之後，不會顯示進度條的狀況，" _
               + Chr(13) + Chr(10) + "只有當計算工作結束後，才會顯示進度條的狀況。", 0 + 64, "Information")

        ProgressBar1.Visible = True
        ' 啟動計時器，觸發 Tick 事件，以便使進度條每一秒前進 10 個單位
        ' 計時器雖已啟動，但需等一秒之後才觸發 Tick 事件，故未觸發前會先執行加總工作
        Timer1.Enabled = True
        Dim MResult As Double = 0
        ' 累加 15 億次
        For Mcou = 1 To 1500000000 Step 1
            MResult = MResult + 1
        Next

        MsgBox("計算結果： " + Format(MResult, "#,###").ToString + Chr(13) + Chr(10) + "拖曳本視窗標題列以移動視窗，可看見進度條仍在前進，" _
               + Chr(13) + Chr(10) + "敲『確定』鈕之後，結束本程式。", 0 + 64, "OK")

        Label1.Visible = False
        Timer1.Enabled = False
        ProgressBar1.Visible = False
    End Sub

End Class