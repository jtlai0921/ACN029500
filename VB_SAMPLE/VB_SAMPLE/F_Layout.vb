Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_Layout

    ' 還原本表單大小
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        Me.Size = New System.Drawing.Size(960, 630)
    End Sub

    ' 本表單載入事件
    Private Sub F_Layout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 宣告變數以便儲存來源檔及OleDB資料提供者
        Dim MDATANAME As String = "APPDATA\MaterialUsed.mdb"
        'Dim MSTRconn_0 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
        Dim MSTRconn_0 As String = "provider=Microsoft.Jet.OLEDB.4.0;data source=" + MDATANAME

        ' 連結資料庫
        Dim Oconn_1 As New OleDbConnection(MSTRconn_0)
        Oconn_1.Open()

        ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
        ' SQL 指令視 User 是否輸入資料編號而分為兩種
        Dim Msqlstr_1 As String = "Select * From MATERIAL Where PRICE>5000"

        ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim ODataAdapter_1 As New OleDbDataAdapter(Msqlstr_1, Oconn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")

        MyClass_DataGridView1.DataSource = Nothing
        MyClass_DataGridView1.DataSource = ODataSet_1.Tables("Table01")

        ' 加入中文欄名
        With MyClass_DataGridView1
            .Columns(0).HeaderText = "工單編號"
            .Columns(1).HeaderText = "工作代號"
            .Columns(2).HeaderText = "領料單編號"
            .Columns(3).HeaderText = "分類編號"
            .Columns(4).HeaderText = "料號"
            .Columns(5).HeaderText = "器材名稱"
            .Columns(6).HeaderText = "單位"
            .Columns(7).HeaderText = "數量"
            .Columns(8).HeaderText = "單價"
            .Columns(9).HeaderText = "金額"
            .Columns(10).HeaderText = "部門代號"
            .Columns(11).HeaderText = "員工號"
            .Columns(12).HeaderText = "員工姓名"
            .Columns(13).HeaderText = "日期"
        End With

        ' 關閉 存取資料庫的相關物件
        Oconn_1.Close()
        Oconn_1.Dispose()

        ' 將資料編號填入列首
        Dim MRowNO As Integer = 0
        MRowNO = MyClass_DataGridView1.RowCount
        For Mcou = 0 To MRowNO - 1
            MyClass_DataGridView1.Rows(Mcou).HeaderCell.Value = (Mcou + 1).ToString
        Next
        ' 凍結前兩欄，以便游標右移時仍可見其編號
        MyClass_DataGridView1.Columns(1).Frozen = True
    End Sub

    ' 關閉本表單
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

    ' 使表單右上角的關閉鈕無效
    Private Sub F_Layout_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    ' 本表單尺寸改變時，重新顯示表單及其控制項的資訊
    Private Sub F_Layout_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TextBox1.Text = MyClass_DataGridView1.Size.Width.ToString + "、" + MyClass_DataGridView1.Size.Height.ToString
        TextBox2.Text = MyClass_DataGridView1.Location.X.ToString + "、" + MyClass_DataGridView1.Location.Y.ToString

        TextBox3.Text = Me.Width.ToString + "、" + Me.Size.Height.ToString()
        TextBox4.Text = Me.Location.X.ToString + "、" + Me.Location.Y.ToString
        TextBox5.Text = Me.AutoScaleMode

        TextBox6.Text = B_01.Size.Width.ToString + "、" + B_01.Size.Height.ToString
        TextBox7.Text = B_01.Location.X.ToString + "、" + B_01.Location.Y.ToString
        TextBox8.Text = B_01.Font.Name + "、" + B_01.Font.Size.ToString
    End Sub
End Class