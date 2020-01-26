Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_Query
    ' 宣告陣列，以便儲存 User 所指定的查詢條件
    ' 包括 SQL 指令、彙總方式之代號、比對種類之代號、比對檔之檔名及路徑
    Public ASendList(4) As String
    ' 宣告變數，以便儲存 User 所指定的比對種類
    Public Mmatchkind As Integer = 0
    ' 宣告變數，以便儲存 User 所指定比對檔的副檔名之長度
    Public MLenExt As Integer


    ' ********************************************************************************************************************************
    ' 將清單1的選取項目加入清單2
    Private Sub B_Select_Click(sender As Object, e As EventArgs) Handles B_Select.Click

        ' 將清單1的選取項目加入清單2，項目不得重複
        For Each Itemname As String In ListBox1.SelectedItems
            If ListBox2.FindString(Itemname) = -1 Then
                ListBox2.Items.Add(Itemname)
            End If
        Next

        ' 將清單2的項目存入陣列，以便重新排序
        ' ListBox1.Items.Item(2) 傳回第3個項目之名稱
        Dim MTotalItems As Integer = ListBox2.Items.Count
        Dim ArrayItems(MTotalItems) As String
        For Mcou = 0 To MTotalItems - 1 Step 1
            ArrayItems(Mcou) = ListBox2.Items.Item(Mcou)
        Next

        ' 遞增排序再反轉陣列，以便遞減排序陣列
        Array.Sort(ArrayItems)
        Array.Reverse(ArrayItems)

        ' 清除清單2的全部項目，再加入陣列之值
        ListBox2.Items.Clear()
        For Mcou = 0 To MTotalItems - 1 Step 1
            ListBox2.Items.Add(ArrayItems(Mcou))
        Next

    End Sub

    ' 移除清單2的選取項目
    ' RemoveAt 需指定移除選取項目的索引編號，Remove 需指定移除選取項目的名稱 
    Private Sub B_Remove_Click(sender As Object, e As EventArgs) Handles B_Remove.Click

        ' 方法一：使用 RemoveAt 
        Do While ListBox2.SelectedIndex <> -1
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        Loop

        ' 方法二：使用 Remove
        'Dim MTotalItems As Integer = ListBox2.SelectedItems.Count
        'For Mcou = 0 To MTotalItems - 1 Step 1
        'Dim MTempItem As String = ListBox2.SelectedItem
        'ListBox2.Items.Remove(MTempItem)
        'Next

    End Sub

    ' 放棄
    Private Sub B_GiveUp_Click(sender As Object, e As EventArgs) Handles B_GiveUp.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Hide()
            F_menu.Show()
        Else
            Return
        End If
    End Sub

    ' 變更 ListBox 選取項目的背景色
    ' 先將 DrawMode 屬性須變更為 OwnerDrawFixed 或 OwnerDrawVariable，內定為 Normal，再於 DrawItem 視覺外觀變更事件中撰寫下列程式
    ' Brushes之後接您希望的顏色，本例為 DeepPink 深粉紅
    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.DeepPink, e.Bounds)
        End If

        Using newitem As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, newitem, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub

    ' 變更選取項目的背景色及前景色 且 變更未選項目的背景色及前景色
    Private Sub ListBox2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox2.DrawItem
        If ListBox2.Items.Count = 0 Then
            Exit Sub
        End If
        Using newitem As New SolidBrush(ListBox2.ForeColor)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(Brushes.DeepPink, e.Bounds)
                newitem.Color = Color.White
            Else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds)
                newitem.Color = Color.Navy
            End If
            ' 劃出框線
            'e.Graphics.DrawRectangle(Pens.DarkBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1)
            Using sf As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap, .Trimming = StringTrimming.Character}
                e.Graphics.DrawString(ListBox2.Items(e.Index).ToString, e.Font, newitem, e.Bounds, sf)
            End Using
        End Using
    End Sub

    ' 重設
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        ' 取消清單1的選取狀態，移除清單2的全部項目
        Dim MTotalItems As Integer = ListBox1.Items.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            ListBox1.SetSelected(Mcou, False)
        Next
        ListBox2.Items.Clear()

        ' 清空文字盒
        T_ENO.Text = ""
        T_DEPTCODE.Text = ""
        T_Man.Checked = False
        T_Woman.Checked = False
        L_DEPTNAME.Text = ""
        T_TITLE.Text = ""
        T_GRADE.Text = ""
        T_S1.Checked = True
        T_S2.Checked = False
        T_S3.Checked = False

        ' 清空比對及資料網格控制項
        DataGridView1.DataSource = Nothing
        T_MATCH1.Checked = False
        T_MATCH2.Checked = False
        T_MATCH3.Checked = False
        T_Path.Text = ""
        Mmatchkind = 0
        T_RecordNo.Text = "記錄數： 0"

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

    ' 查詢
    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click

        ' 先使用 Items.Count 屬性檢查是否有日期（至少需要一個）
        If ListBox2.Items.Count = 0 Then
            MsgBox("Sorry, 尚未選取日期！" + Chr(13) + Chr(10) + "請先敲選日期一個或多個", 0 + 16, "Error")
            Exit Sub
        End If

        ' 檢查比對種類是否已指定
        Mmatchkind = 0
        If T_MATCH1.Checked = True Then
            Mmatchkind = 1
        End If
        If T_MATCH2.Checked = True Then
            Mmatchkind = 2
        End If
        If T_MATCH3.Checked = True Then
            Mmatchkind = 3
        End If
        If Len(Trim(T_Path.Text)) > 0 And Mmatchkind = 0 Then
            MsgBox("Sorry, 比對種類尚未敲選取！" + Chr(13) + Chr(10) + "請敲比對種類或清除比對檔（Reset）", 0 + 16, "Error")
            Exit Sub
        End If
        If Len(Trim(T_Path.Text)) = 0 And Mmatchkind <> 0 Then
            MsgBox("Sorry, 比對檔案尚未選取！" + Chr(13) + Chr(10) + "請選取比對檔或清除比對種類（Reset）", 0 + 16, "Error")
            Exit Sub
        End If

        ' 將 User 所指定的查詢條件存入變數 MMM，以便組合 SQL 指令
        Dim MMM As String = ""
        If T_ENO.Text <> "" Then
            MMM = "staff_no='" + T_ENO.Text + "'"
        End If
        If T_DEPTCODE.Text <> "" Then
            If MMM = "" Then
                MMM = "dept_code='" + T_DEPTCODE.Text + "'"
            Else
                MMM = MMM + " and dept_code='" + T_DEPTCODE.Text + "'"
            End If
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
        Dim MTempDate As String = ""
        For Each Itemname As String In ListBox2.Items
            If MTempDate = "" Then
                MTempDate = "'" + Itemname + "'"
            Else
                MTempDate = MTempDate + "," + "'" + Itemname + "'"
            End If
        Next
        If MMM = "" Then
            MMM = "filedate IN(" + MTempDate + ")"
        Else
            MMM = MMM + " and filedate IN(" + MTempDate + ")"
        End If

        ' 將 SQL 指令 及 彙總方式之代號 存入陣列，再 傳遞給 F_QueryResult.vb，以便其程式據以抓出相關資料
        ' 缺點 → 無法納入 dept_name 部門名稱欄，因該欄非 Group by 之項目
        Dim MGroupKind As Integer = 1
        If T_S1.Checked = True Then
            MGroupKind = 1
        End If
        If T_S2.Checked = True Then
            MGroupKind = 2
        End If
        If T_S3.Checked = True Then
            MGroupKind = 3
        End If
        If T_S4.Checked = True Then
            MGroupKind = 4
        End If

        ' 使用比對查詢時，不能進行彙總，故此處強制將 MGroupKind 彙總類別之代號改為 1，以防 User 誤敲
        If Mmatchkind <> 0 Then
            MGroupKind = 1
            T_S1.Checked = True
        End If

        ' 組合後 SQL 指令
        ' 若要進行比對查詢（Mmatchkind <> 0），則忽略彙總方式，即使 User 指定了小計方式，SQL 指令也不要納入 Group by
        Dim MTempString As String = ""
        If Mmatchkind = 0 Then
            Select Case MGroupKind
                Case 1
                    MTempString = "Select staff_no,staff_name,staff_sex,dept_code,dept_name,titlecode,title,grade,qty,seniority,years,wages,allowance,meal,filedate From SALARY Where " + MMM
                Case 2
                    MTempString = "Select dept_code,Sum(qty) as qty,Sum(wages) as wages,Sum(allowance) as allowance,Sum(meal) as meal From SALARY Where " + MMM + " Group by dept_code Order by dept_code"
                Case 3
                    MTempString = "Select dept_code,grade,Sum(qty) as qty,Sum(wages) as wages,Sum(allowance) as allowance,Sum(meal) as meal From SALARY Where " + MMM + " Group by dept_code,grade Order by dept_code,grade"
                Case 4
                    MTempString = "Select dept_code,title,staff_sex,Sum(qty) as qty,Sum(wages) as wages,Sum(allowance) as allowance,Sum(meal) as meal From SALARY Where " + MMM + " Group by dept_code,title,staff_sex Order by dept_code,title,staff_sex"
            End Select
        Else
            MTempString = "Select staff_no,staff_name,staff_sex,dept_code,dept_name,titlecode,title,grade,qty,seniority,years,wages,allowance,meal,filedate From SALARY Where " + MMM
        End If
        'Me.Tag = MTempString

        ' 將 SQL 指令、彙總方式之代號、比對種類之代號、比對檔之檔名及路徑 存入陣列、比對檔之副檔名的長度，供 F_QueryResult.vb 之程式使用
        ASendList(0) = MTempString
        ASendList(1) = MGroupKind
        ASendList(2) = Mmatchkind
        ASendList(3) = T_Path.Text
        ASendList(4) = MLenExt
        Me.Hide()
        F_QueryResult.Show()

    End Sub

    ' 載入本表單時，將比對檔複製於D:\TestQuery，供測試之用
    Private Sub F_Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 先使用 DirectoryExists 方法 檢查資料夾是否已存在，若不存在，則新增之
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If

        '  設定來源檔之檔名及路徑
        Dim MSOURCEFN01 As String = "APPDATA\比對_員工號.xls"
        Dim MSOURCEFN02 As String = "APPDATA\比對_部門代號.xls"
        Dim MSOURCEFN03 As String = "APPDATA\比對_職稱.xls"
        
        ' 設定目的檔之檔名及路徑
        Dim MDESFN01 As String = "D:\TestQuery\比對_員工號.xls"
        Dim MDESFN02 As String = "D:\TestQuery\比對_部門代號.xls"
        Dim MDESFN03 As String = "D:\TestQuery\比對_職稱.xls"

        ' 將來源檔複製於目的檔案夾
        FileCopy(MSOURCEFN01, MDESFN01)
        FileCopy(MSOURCEFN02, MDESFN02)
        FileCopy(MSOURCEFN03, MDESFN03)
    End Sub


    ' 使用 OpenFileDialog 檔案對話方塊控制項讓 User 選取欲匯入的 Excel 檔
    ' OpenFileDialog  類別的 FileName 屬性可傳回檔名（含路徑） ，存入 T_Path 文字盒
    ' OpenFileDialog  類別的 Filter 屬性可限定選檔類型
    ' OpenFileDialog  類別的 FilterIndex 屬性可設定預設選檔之索引順序
    ' OpenFileDialog  類別的 Title 屬性可設定對話方塊標題
    Private Sub B_PickUp_Click(sender As Object, e As EventArgs) Handles B_PickUp.Click
        ' 檢查比對種類是否已指定
        Mmatchkind = 0
        If T_MATCH1.Checked = True Then
            Mmatchkind = 1
        End If
        If T_MATCH2.Checked = True Then
            Mmatchkind = 2
        End If
        If T_MATCH3.Checked = True Then
            Mmatchkind = 3
        End If
        If Mmatchkind = 0 Then
            MsgBox("比對種類尚未敲選！" + Chr(13) + Chr(10) + "請先敲選。", 0 + 16, "Error")
            Exit Sub
        End If

        ' 選取比對檔案
        OpenFileDialog1.Filter = "(新版 Excel 檔;舊版 Excel 檔)|*.xlsx;*.xls"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "請選取一個圖檔"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_Path.Text = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        ' 使用 Path 類別的 GetExtension 方法取回副檔名，包含『.』 ，例如『.xls』、『.xlsx』
        ' 以長度來區分副檔名的種類
        MLenExt = Len(Path.GetExtension(OpenFileDialog1.FileName))

        ' 設定連接字串，供 OleDbConnection 物件使用
        ' 若 User 的電腦同時安裝新版及舊本的 Excel，則以版本編號來判斷可能會誤判，
        ' 誤以為只有舊版驅動程式，故以 OLEDB.4.0 來讀取 Excel 檔，若 User 選取 xlsx 檔就會發生檔案格式不符的狀況，
        ' 故下段程式改以 User 所選檔案的副檔名來判斷，以便正確使用 OLEDB 之版本
        Dim MFN_1 As String = T_Path.Text
        Dim Mstrconn_1 As String = ""
        If MLenExt >= 5 Then
            Mstrconn_1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1';"
        Else
            Mstrconn_1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MFN_1 + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1';"
        End If

        ' 使用 OleDbConnection 的建構函式建立新的連接物件，括號內為連接字串，再使用 Open 方法打通連接管道
        Dim Oconn_1 As New OleDbConnection(Mstrconn_1)
        Oconn_1.Open()

        ' 讀取第一張工作表的名稱，並存入變數 MSheet1Name
        ' OleDbConnection 的 GetSchema 方法 可讀出檔案結構描述資訊，它是一個資訊集合，可存入資料表
        ' 括號內為結構描述的名稱，例如 Tables、Columns、Indexes等，若不指定，則傳回一般摘要資訊，
        ' 若結構描述名稱為 Tables 時，其中第 3 欄為工作表名稱，第 8 欄為檔案產生日期
        ' 如此，User 無論將工作表名稱改為何種名稱都可抓出，也可克服新舊版 Excel 工作表名稱不同的困擾
        ' GetSchema 所讀出的資料表名稱是排序過的，故若要固定讀取第一張工作表，則須要求 User 將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表
        Dim MSheet1Name As String = ""
        Dim O_Information As DataTable
        O_Information = Oconn_1.GetSchema("Tables")
        MSheet1Name = O_Information.Rows(0)(2)

        ' 設定 SQL 字串，供資料轉接器使用
        Dim Msqlstr_1 As String = "Select * From [" + MSheet1Name + "]"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），以便將讀取的資料存入資料集，括號內為 SQL 命令及連接物件，
        ' 無需使用 OleDbCommand 物件
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        ' 將資料集之中某一資料表的資料顯示於 DataGridView 資料網格控制項
        ' 先刪除虛擬欄位（必須反向刪除）
        'Dim MTotalColumns As Integer = DataGridView1.Columns.Count - 1
        'For Mcount = MTotalColumns To 0 Step -1
        'DataGridView1.Columns.RemoveAt(Mcount)
        'Next
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 關閉 存取資料庫的相關物件
        Oconn_1.Close()
        Oconn_1.Dispose()
        ODataAdapter_1.Dispose()

        ' 顯示記錄數
        ' Rows.Count 屬性可傳回資料集之中某一資料表的總筆數
        Dim MTotalRecordNo As Int32 = ODataSet_1.Tables("Table01").Rows.Count
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 加入中文欄名，欄名因匯總方式而不同
         Select Mmatchkind
            Case 1
                DataGridView1.Columns(0).HeaderText = "員工號"
            Case 2
                DataGridView1.Columns(0).HeaderText = "部門代號"
            Case 3
                DataGridView1.Columns(0).HeaderText = "職稱"
        End Select

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
        MsgBox("比對資料已匯入！" + Chr(13) + Chr(13) + "請確認是否正確，再敲『查 詢』鈕。", 0 + 64, "OK")

    End Sub

End Class