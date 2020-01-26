Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_TableImport
    ' 宣告陣列，以便儲存 User 所敲選的檔案名稱及工作表名稱
    Public ASendList(1) As String
    '    Public MReturnFrom As String = ""



    ' **************************************************************************************************
    ' 使用 OpenFileDialog 檔案對話方塊控制項讓 User 選取欲匯入的 Excel 檔
    ' OpenFileDialog  類別的 FileName 屬性可傳回檔名（含路徑） ，存入 T_Path 文字盒
    ' OpenFileDialog  類別的 Filter 屬性可限定選檔類型
    ' OpenFileDialog  類別的 FilterIndex 屬性可設定預設選檔之索引順序
    ' OpenFileDialog  類別的 Title 屬性可設定對話方塊標題
    Private Sub B_PickUp_Click(sender As Object, e As EventArgs) Handles B_PickUp.Click
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
        Dim MLenExt As Integer = Len(Path.GetExtension(OpenFileDialog1.FileName))

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

        ' 顯示全部工作表名稱於 RadioButton，供 User 敲選
        ' OleDbConnection 的 GetSchema 方法 可讀出檔案結構描述資訊，它是一個資訊集合，可存入資料表
        ' 括號內為結構描述的名稱，例如 Tables、Columns、Indexes等，若不指定，則傳回一般摘要資訊，
        ' 若結構描述名稱為 Tables 時，其中第 3 欄為工作表名稱，第 8 欄為檔案產生日期
        ' 如此，User 無論將工作表名稱改為何種名稱都可抓出，也可克服新舊版 Excel 工作表名稱不同的困擾
        ' GetSchema 所讀出的資料表名稱是排序過的，故若要固定讀取第一張工作表，則須要求 User 將欲處理的工作表名稱命名為筆劃最少的，或刪除其他無關的工作表
        ' DataTable 的 Rows.Count 屬性可傳回資料表的筆數，以本例而言就是工作表張數
        Dim O_Information As DataTable
        O_Information = Oconn_1.GetSchema("Tables")
        T_SheetName.Text = O_Information.Rows(0)(2)
        Oconn_1.Close()
        Oconn_1.Dispose()

    End Sub

    ' 儲存 User 所敲選的檔案名稱及工作表名稱
    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        If T_Path.Text = "" Then
            MsgBox("請先選取所需的檔案，再敲『確 定』鈕。", 0 + 16, "Error")
            Exit Sub
        End If
        ASendList(0) = Strings.Trim(T_Path.Text)
        ASendList(1) = Strings.Trim(T_SheetName.Text)
        Me.Hide()
        'F_TableDept.Visible = True
    End Sub

    ' 放棄
    Private Sub B_GiveUp_Click(sender As Object, e As EventArgs) Handles B_GiveUp.Click
        ASendList(0) = ""
        ASendList(1) = ""
        Me.Hide()
        'F_TableDept.Visible = True
        ' Select Case MReturnFrom
        '     Case "F_TableDept"
        ' F_TableDept.Enabled = True
        '     Case "F_TableTitle"
        ' F_TableTitle.Enabled = True
        '     Case "F_TableGrade"
        ' F_TableGrade.Enabled = True
        ' End Select

    End Sub

    ' 載入本表單時，將游標移往 T_Path 文字盒
    Private Sub F_SheetChoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        T_Path.Text = ""
        T_SheetName.Text = ""
        T_Path.Focus()
    End Sub

End Class