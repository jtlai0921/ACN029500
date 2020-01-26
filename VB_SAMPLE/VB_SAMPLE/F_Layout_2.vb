Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class F_Layout_2

    ' 載入本表單時，顯示郵票蒐藏的全部資料
    Private Sub F_Layout_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 連結資料庫
        Dim MDATANAME As String = "APPDATA\StampCollection.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
        Dim O_conn_1 As New OleDbConnection(MSTRconn_1)
        O_conn_1.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_1 As String
        Mstr_com_1 = "Select SNO,COUNTRY,ITEMNAME,	TOPICS	,QTY,MINT,CONDITION,COST,PURDATE,SUPPLIER from STAMP"

        ' 建立命令物件 O_cmd_01
        Dim O_cmd_1 As New OleDbCommand(Mstr_com_1, O_conn_1)

        ' 建立轉接器物件 O_adp_01
        Dim O_adp_1 As New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_1.SelectCommand = O_cmd_1

        ' 建立資料集物件 O_dset_01
        Dim O_dset_1 = New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料集
        ' Fill 方法 之括號內有兩個參數，前者為資料集的名稱，後者為資料表的名稱
        O_adp_1.Fill(O_dset_1, "DATA01")

        '  先清除前次的查詢結果，再設定 DataGridView 的資料來源
        MyClass_DataGridView1.DataSource = Nothing
        MyClass_DataGridView1.DataSource = O_dset_1.Tables("DATA01")

        ' 關閉資料處理物件
        O_cmd_1.Dispose()
        O_adp_1.Dispose()
        O_conn_1.Close()
        O_conn_1.Dispose()

        ' 清除清單控制項的選取，顯示合計筆數
        Dim MTotalItemsNo As Integer = ListBox1.Items.Count
        For Mcou = 0 To MTotalItemsNo - 1
            ListBox1.SetSelected(Mcou, False)
        Next
        L_RecordNo.Text = "合計筆數： " + O_dset_1.Tables("DATA01").Rows.Count.ToString

        ' 加入中文欄名
        With MyClass_DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "新舊"
            .Columns(6).HeaderText = "品相"
            .Columns(7).HeaderText = "購入價格"
            .Columns(8).HeaderText = "購入時間"
            .Columns(9).HeaderText = "購入地點"
        End With
        ' 金額欄及日期欄格式化
        With MyClass_DataGridView1
            .Columns(7).DefaultCellStyle.Format = "#,0.00"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 自檔案讀出前次表單尺寸調整的資料，並據以調整表單大小
        ' 自檔案讀出前次圖片盒尺寸調整的資料，並據以調整圖片盒大小
        Dim MFormWidth As Integer
        Dim MFormHeight As Integer
        Dim MPictureBoxWidth As Integer
        Dim MPictureBoxHeight As Integer
        Dim MFileName = "APPDATA\MyFormSize.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MFormWidth = Val(MStreamRead.ReadLine())
        MFormHeight = Val(MStreamRead.ReadLine())
        MPictureBoxWidth = Val(MStreamRead.ReadLine())
        MPictureBoxHeight = Val(MStreamRead.ReadLine())
        MStreamRead.Close()
        Me.Size = New System.Drawing.Size(MFormWidth, MFormHeight)
        Me.PictureBox1.Size = (New System.Drawing.Size(MPictureBoxWidth, MPictureBoxHeight))
        T_Form_Width.Text = MFormWidth
        T_Form_Height.Text = MFormHeight

        ' 自檔案讀出前次 DataGridView 字型資料，並據以調整 DataGridView 的字型
        ' New Font 字型建構函示不支援粗斜字體，亦不支援刪除線與底線同時並存
        Dim MGridFontName As String
        Dim MGridFontStyle As Integer
        Dim MGridFontSize As Integer
        Dim MGridFontColor As String
        Dim MGridFontStrikeout As Boolean
        Dim MGridFontUnderline As Boolean
        Dim MFileName2 = "APPDATA\MyDataGridViewStyle.txt"
        Dim MStreamRead2 As StreamReader = New StreamReader(MFileName2)
        MGridFontName = MStreamRead2.ReadLine()
        MGridFontStyle = Val(MStreamRead2.ReadLine())
        MGridFontSize = Val(MStreamRead2.ReadLine())
        MGridFontColor = MStreamRead2.ReadLine()
        MGridFontStrikeout = MStreamRead2.ReadLine()
        MGridFontUnderline = MStreamRead2.ReadLine()
        MStreamRead2.Close()

        Dim MTempFomtStyle As Integer
        If MGridFontUnderline = True Then
            MTempFomtStyle = FontStyle.Underline
        End If
        If MGridFontStrikeout = True Then
            MTempFomtStyle = FontStyle.Strikeout
        End If
        Select Case MGridFontStyle
            Case 0
                MTempFomtStyle = FontStyle.Regular
            Case 1
                MTempFomtStyle = FontStyle.Bold
            Case 2
                MTempFomtStyle = FontStyle.Italic
            Case 3
                'MTempFomtStyle = FontStyle.Bold and FontStyle.Italic
                MTempFomtStyle = FontStyle.Italic
        End Select
        MyClass_DataGridView1.DefaultCellStyle.Font = New Font(MGridFontName, MGridFontSize, MTempFomtStyle, GraphicsUnit.Point)

        ' 選取區參數自檔案讀出
        Dim MColor1R As Integer
        Dim MColor1G As Integer
        Dim MColor1B As Integer
        Dim MColor2R As Integer
        Dim MColor2G As Integer
        Dim MColor2B As Integer
        Dim MColor3R As Integer
        Dim MColor3G As Integer
        Dim MColor3B As Integer
        Dim MColor4R As Integer
        Dim MColor4G As Integer
        Dim MColor4B As Integer
        Dim MColor5R As Integer
        Dim MColor5G As Integer
        Dim MColor5B As Integer
        Dim MColor6R As Integer
        Dim MColor6G As Integer
        Dim MColor6B As Integer

        Dim MFileName3 = "APPDATA\MyDataGridViewSelection.txt"
        Dim MStreamRead3 As StreamReader = New StreamReader(MFileName3)
        MColor1R = MStreamRead3.ReadLine()
        MColor1G = MStreamRead3.ReadLine()
        MColor1B = MStreamRead3.ReadLine()
        MColor2R = MStreamRead3.ReadLine()
        MColor2G = MStreamRead3.ReadLine()
        MColor2B = MStreamRead3.ReadLine()
        MColor3R = MStreamRead3.ReadLine()
        MColor3G = MStreamRead3.ReadLine()
        MColor3B = MStreamRead3.ReadLine()
        MColor4R = MStreamRead3.ReadLine()
        MColor4G = MStreamRead3.ReadLine()
        MColor4B = MStreamRead3.ReadLine()
        MColor5R = MStreamRead3.ReadLine()
        MColor5G = MStreamRead3.ReadLine()
        MColor5B = MStreamRead3.ReadLine()
        MColor6R = MStreamRead3.ReadLine()
        MColor6G = MStreamRead3.ReadLine()
        MColor6B = MStreamRead3.ReadLine()
        MStreamRead3.Close()

        MyClass_DataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(MColor1R, MColor1G, MColor1B)
        MyClass_DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(MColor2R, MColor2G, MColor2B)
        MyClass_DataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(MColor3R, MColor3G, MColor3B)
        MyClass_DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(MColor4R, MColor4G, MColor4B)
        MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(MColor5R, MColor5G, MColor5B)
        MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(MColor6R, MColor6G, MColor6B)

        ' 自檔案讀出前次 DataGridView 的列高資料，並據以調整 DataGridView 的列高
        Dim MTempRowHieight As Integer
        Dim MFileName1 = "APPDATA\MyDataGridViewRowHeight.txt"
        Dim MStreamRead1 As StreamReader = New StreamReader(MFileName1)
        MTempRowHieight = Val(MStreamRead1.ReadLine())
        MStreamRead1.Close()
        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        MyClass_DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In MyClass_DataGridView1.Rows
            mtprow.Height = MTempRowHieight
        Next mtprow
        T_DGV_Height.Value = MTempRowHieight
        Me.Refresh()

        ' 凍結前兩欄，以便游標右移時仍可見其編號
        MyClass_DataGridView1.Columns(1).Frozen = True
        ' 增加資料列編號
        Dim MRowNO As Integer = 0
        MRowNO = MyClass_DataGridView1.RowCount
        For Mcou = 0 To MRowNO - 1
            MyClass_DataGridView1.Rows(Mcou).HeaderCell.Value = (Mcou + 1).ToString
        Next

    End Sub

    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click

        ' 取回 User 的敲選項目
        Dim MTempKind As String = ""
        MTempKind = ListBox1.SelectedItem

        ' 連結資料庫
        Dim MDATANAME As String = "APPDATA\StampCollection.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDATANAME
        Dim O_conn_1 As New OleDbConnection(MSTRconn_1)
        O_conn_1.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_1 As String
        If MTempKind = "" Then
            Mstr_com_1 = "Select SNO,COUNTRY,ITEMNAME,	TOPICS	,QTY,MINT,CONDITION,COST,PURDATE,SUPPLIER from STAMP"
        Else
            Mstr_com_1 = "Select SNO,COUNTRY,ITEMNAME,	TOPICS	,QTY,MINT,CONDITION,COST,PURDATE,SUPPLIER from STAMP where TOPICS='" + MTempKind + "'"
        End If

        ' 建立命令物件 O_cmd_01
        Dim O_cmd_1 As New OleDbCommand(Mstr_com_1, O_conn_1)

        ' 建立轉接器物件 O_adp_01
        Dim O_adp_1 As New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_1.SelectCommand = O_cmd_1

        ' 建立資料集物件 O_dset_01
        Dim O_dset_1 = New DataSet
        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料集
        ' Fill 方法 之括號內有兩個參數，前者為資料集的名稱，後者為資料表的名稱
        O_adp_1.Fill(O_dset_1, "DATA01")

        ' 將資料集中的第一個資料表存入 datatable
        Dim O_dtable_1 As New DataTable
        O_dtable_1 = O_dset_1.Tables("DATA01")

        ' 建立資料檢視物件 O_dv_01
        Dim O_dv_1 As New DataView
        O_dv_1 = O_dset_1.Tables("DATA01").DefaultView

        '  先清除前次的查詢結果，再設定 DataGridView 的資料來源
        MyClass_DataGridView1.DataSource = Nothing
        ' 刪除虛擬欄位
        If MyClass_DataGridView1.Columns.Count <> 0 Then
            MyClass_DataGridView1.Columns.RemoveAt(9)
            MyClass_DataGridView1.Columns.RemoveAt(8)
            MyClass_DataGridView1.Columns.RemoveAt(7)
            MyClass_DataGridView1.Columns.RemoveAt(6)
            MyClass_DataGridView1.Columns.RemoveAt(5)
            MyClass_DataGridView1.Columns.RemoveAt(4)
            MyClass_DataGridView1.Columns.RemoveAt(3)
            MyClass_DataGridView1.Columns.RemoveAt(2)
            MyClass_DataGridView1.Columns.RemoveAt(1)
            MyClass_DataGridView1.Columns.RemoveAt(0)
        End If
        MyClass_DataGridView1.DataSource = O_dset_1.Tables("DATA01")
        'MyClass_DataGridView1.DataSource = O_dtable_1
        'MyClass_DataGridView1.DataSource = O_dv_1
        L_RecordNo.Text = "合計筆數： " + O_dset_1.Tables("DATA01").Rows.Count.ToString

        ' 關閉資料處理物件
        O_cmd_1.Dispose()
        O_adp_1.Dispose()
        O_conn_1.Close()
        O_conn_1.Dispose()

        ' 加入中文欄名
        With MyClass_DataGridView1
            .Columns(0).HeaderText = "編號"
            .Columns(1).HeaderText = "國家"
            .Columns(2).HeaderText = "郵票名稱"
            .Columns(3).HeaderText = "專題類別"
            .Columns(4).HeaderText = "數量"
            .Columns(5).HeaderText = "新舊"
            .Columns(6).HeaderText = "品相"
            .Columns(7).HeaderText = "購入價格"
            .Columns(8).HeaderText = "購入時間"
            .Columns(9).HeaderText = "購入地點"
        End With
        ' 金額欄及日期欄格式化
        With MyClass_DataGridView1
            .Columns(7).DefaultCellStyle.Format = "#,0.00"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        ' 增加資料列編號
        Dim MRowNO As Integer = 0
        MRowNO = MyClass_DataGridView1.RowCount
        For Mcou = 0 To MRowNO - 1
            MyClass_DataGridView1.Rows(Mcou).HeaderCell.Value = (Mcou + 1).ToString
        Next
        ' 凍結前兩欄，以便游標右移時仍可見其編號
        MyClass_DataGridView1.Columns(1).Frozen = True
    End Sub

    ' 清空 DataGridView 及 ListBox 之選取
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        MyClass_DataGridView1.DataSource = Nothing
        Dim MTotalItemsNo As Integer = ListBox1.Items.Count
        For Mcou = 0 To MTotalItemsNo - 1
            ListBox1.SetSelected(Mcou, False)
        Next
        L_RecordNo.Text = "合計筆數： 0"

        ' 加入虛擬欄位
        If MyClass_DataGridView1.Columns.Count = 0 Then
            MyClass_DataGridView1.Columns.Add("a", "編號")
            MyClass_DataGridView1.Columns.Add("b", "國家")
            MyClass_DataGridView1.Columns.Add("c", "郵票名稱")
            MyClass_DataGridView1.Columns.Add("d", "專題類別")
            MyClass_DataGridView1.Columns.Add("e", "數量")
            MyClass_DataGridView1.Columns.Add("f", "新舊")
            MyClass_DataGridView1.Columns.Add("g", "品相")
            MyClass_DataGridView1.Columns.Add("h", "購入價格")
            MyClass_DataGridView1.Columns.Add("i", "購入時間")
            MyClass_DataGridView1.Columns.Add("j", "購入地點")
        End If
        PictureBox1.Image = Nothing
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
    Private Sub F_Base_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    ' 調整 DataGridView 列高，並將 User 所選之值存入檔案，作為下次載入表單時的預設值
    Private Sub B_ADJ_Click(sender As Object, e As EventArgs) Handles B_ADJ.Click

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        MyClass_DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim MTempRowHeight As Integer = T_DGV_Height.Value
        Dim mtprow As Object
        For Each mtprow In MyClass_DataGridView1.Rows
            mtprow.Height = MTempRowHeight
        Next mtprow

        Dim MFileName = "APPDATA\MyDataGridViewRowHeight.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine(MTempRowHeight.ToString)
        MStreamWrite.Flush()
        MStreamWrite.Close()
        MsgBox("DataGridView 的列高已調整並已存入檔案！", 0 + 64 + 128, "OK")
    End Sub

    ' User 調整表單大小時，將其尺寸顯示於文字盒
    Private Sub F_Layout_2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        T_Form_Width.Text = Me.Size.Width
        T_Form_Height.Text = Me.Size.Height
    End Sub

    ' DataGridView 選取變動事件中傳回游標所在列資料的圖片
    Private Sub MyClass_DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles MyClass_DataGridView1.SelectionChanged
        ' MyClass_DataGridView1.CurrentRow.Cells(0).Value 可傳回游標所在列的 資料編號，後續程式再據以抓出其圖片，
        ' 但是當 User 敲選 DataGridView 最後一列（無資料）或敲選欄位名稱時會發生錯誤，故需加入適當程式碼，以處理意外狀況，
        ' 方法一，使用 On Error 陳述式， 方法二，使用 Try 陳述式

        ' 方法一
        'On Error Resume Next

        'Dim MTempSNO As String = ""
        'If IsDBNull(MyClass_DataGridView1.CurrentRow.Cells(0).Value) = True Then
        'PictureBox1.Image = Nothing
        'Exit Sub
        'Else
        'MTempSNO = MyClass_DataGridView1.CurrentRow.Cells(0).Value
        'End If

        ' 方法二
        Dim MTempSNO As String = ""
        Try
            MTempSNO = MyClass_DataGridView1.CurrentRow.Cells(0).Value
        Catch ex As Exception
            PictureBox1.Image = Nothing
            Exit Sub
        End Try

        ' 連結資料庫，以便讀出資料表的圖片欄資料
        Dim MDATANAME As String = "APPDATA\StampCollection.mdb"
        Dim MSTRconn_1 As String = "provider=Microsoft.ACE.Oledb.12.0;Data source=" + MDATANAME

        Dim O_conn_1 As New OleDbConnection(MSTRconn_1)
        O_conn_1.Open()

        ' 指定 SQL 指令
        Dim Mstr_com_1 As String
        Mstr_com_1 = "Select PIC from STAMP where SNO='" + MTempSNO + "'"

        ' 建立命令物件 O_cmd_01
        Dim O_cmd_1 As New OleDbCommand(Mstr_com_1, O_conn_1)

        '建立轉接器物件 O_adp_01
        Dim O_adp_1 As New OleDbDataAdapter()

        ' 使用 OleDbDataAdapter 的 SelectCommand 屬性指定 SQL 指令
        O_adp_1.SelectCommand = O_cmd_1

        ' 使用 OleDbDataAdapter 的 Fill 方法 將前述轉接器中的資料填入資料表
        Dim O_dtable_1 As New DataTable
        O_adp_1.Fill(O_dtable_1)

        ' 需先判斷 User 所指定的編號是否存在
        If O_dtable_1.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim MTempBinary As Byte() = O_dtable_1.Rows(0)(0)
        Dim MTempStream As MemoryStream = New MemoryStream(MTempBinary)
        PictureBox1.Image = Image.FromStream(MTempStream)

        ' 關閉資料處理物件
        O_cmd_1.Cancel()
        O_cmd_1.Dispose()
        O_adp_1.Dispose()
        O_conn_1.Close()
        O_conn_1.Dispose()

    End Sub

    ' 設定 DataGridView 的字型，包括字型、樣式、大小、顏色
    ' 並將 User 所選之值存入檔案，作為下次載入表單時的預設值
    Private Sub B_Font_Click(sender As Object, e As EventArgs) Handles B_Font.Click
        FontDialog1.ShowColor = True
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MyClass_DataGridView1.DefaultCellStyle.Font = FontDialog1.Font
            MyClass_DataGridView1.DefaultCellStyle.ForeColor = FontDialog1.Color

            Dim MGridFontName As String = FontDialog1.Font.Name
            Dim MGridFontStyle As Integer = FontDialog1.Font.Style
            Dim MGridFontSize As Integer = FontDialog1.Font.Size
            Dim MGridFontColor As String = FontDialog1.Color.ToKnownColor
            'Dim MGridFontColor As String = FontDialog1.Color.R.ToString + "," + FontDialog1.Color.G.ToString + "," + FontDialog1.Color.B.ToString
            Dim MGridFontStrikeout As Boolean = FontDialog1.Font.Strikeout
            Dim MGridFontUnderline As Boolean = FontDialog1.Font.Underline
            Dim MFileName = "APPDATA\MyDataGridViewStyle.txt"
            Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
            MStreamWrite.WriteLine(MGridFontName)
            MStreamWrite.WriteLine(MGridFontStyle.ToString)
            MStreamWrite.WriteLine(MGridFontSize.ToString)
            MStreamWrite.WriteLine(MGridFontColor)
            MStreamWrite.WriteLine(MGridFontStrikeout)
            MStreamWrite.WriteLine(MGridFontUnderline)
            MStreamWrite.Flush()
            MStreamWrite.Close()
            MsgBox("DataGridView 的字型已調整並已存入檔案！", 0 + 64 + 128, "OK")
        End If
    End Sub

    ' 重設表單大小，圖片盒等比例縮放，並將表單及圖片盒的尺寸存入檔案，作為下次載入表單時的預設值
    Private Sub B_FormSize_Click(sender As Object, e As EventArgs) Handles B_FormSize.Click
        Dim MFormWidth As Integer = T_Form_Width.Text
        Dim MFormHeight As Integer = T_Form_Height.Text
        Me.Size = New System.Drawing.Size(MFormWidth, MFormHeight)

        Dim MPictureBoxWidth As Integer = Math.Round(376 * Val(T_Form_Width.Text) / 930, 0)
        Dim MPictureBoxHeight As Integer = Math.Round(190 * Val(T_Form_Height.Text) / 620, 0)
        Me.PictureBox1.Size = (New System.Drawing.Size(MPictureBoxWidth, MPictureBoxHeight))
        Me.Refresh()

        Dim MFileName = "APPDATA\MyFormSize.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine(MFormWidth.ToString)
        MStreamWrite.WriteLine(MFormHeight.ToString)
        MStreamWrite.WriteLine(MPictureBoxWidth.ToString)
        MStreamWrite.WriteLine(MPictureBoxHeight.ToString)
        MStreamWrite.Flush()
        MStreamWrite.Close()
        MsgBox("表單大小已調整並已存入檔案！", 0 + 64 + 128, "OK")

    End Sub

    ' 還原表單大小，圖片盒大小改回預設值，並存檔
    Private Sub B_FormSizeO_Click(sender As Object, e As EventArgs) Handles B_FormSizeO.Click
        Me.Size = New System.Drawing.Size(930, 620)
        T_Form_Width.Text = 930
        T_Form_Height.Text = 620
        PictureBox1.Size = New System.Drawing.Size(376, 190)
        Me.Refresh()

        Dim MFileName = "APPDATA\MyFormSize.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine("930")
        MStreamWrite.WriteLine("620")
        MStreamWrite.WriteLine("376")
        MStreamWrite.WriteLine("190")
        MStreamWrite.Flush()
        MStreamWrite.Close()

        MsgBox("表單大小已還原並已存入檔案！", 0 + 64 + 128, "OK")
    End Sub

    ' 還原DataGridView的字型，並存檔
    ' 使用 New Font 字型建構函式來設定 DataGridView 的字型，括號內依序為 字型名稱、大小、樣式、單位、字元集
    ' 樣式代碼 → FontStyle.Regular 標準、FontStyle.Bold 粗體、FontStyle.Italic 斜體、FontStyle.Strikeout 刪除線、FontStyle.Underline 底線
    ' 單位代碼 → GraphicsUnit.Point 點、GraphicsUnit.Pixel 像素、GraphicsUnit.World 全局座標系統單位
    ' 字元集代碼 → 136 中文 Big5、0 西歐字母
    ' 還原DataGridView的列高，並存檔
    Private Sub B_GridDefault_Click(sender As Object, e As EventArgs) Handles B_GridDefault.Click
        MyClass_DataGridView1.DefaultCellStyle.Font = New Font("微軟正黑體", 9.75, FontStyle.Regular, GraphicsUnit.Point, 136)
        MyClass_DataGridView1.DefaultCellStyle.ForeColor = Color.Navy
        MyClass_DataGridView1.DefaultCellStyle.BackColor = Color.White
        MyClass_DataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255)
        MyClass_DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 0, 90)
        MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 128)
        MyClass_DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 243, 245)

        Dim MFileName = "APPDATA\MyDataGridViewStyle.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine("微軟正黑體")
        MStreamWrite.WriteLine("0")
        MStreamWrite.WriteLine("10")
        MStreamWrite.WriteLine("Navy")
        MStreamWrite.WriteLine("False")
        MStreamWrite.WriteLine("False")
        MStreamWrite.Flush()
        MStreamWrite.Close()

        ' 逐一還原列高為預設值，AutoSizeRowsMode 需設為 None
        MyClass_DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In MyClass_DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        Dim MFileName1 = "APPDATA\MyDataGridViewRowHeight.txt"
        Dim MStreamWrite1 As StreamWriter = New StreamWriter(MFileName1, False)
        MStreamWrite1.WriteLine("24")
        MStreamWrite1.Flush()
        MStreamWrite1.Close()
        T_DGV_Height.Value = 24

        ' 將顏色參數存入檔案，以便下次載入本表單時設定其 DataGridView 之顏色
        Dim MFileName3 = "APPDATA\MyDataGridViewSelection.txt"
        Dim MStreamWrite3 As StreamWriter = New StreamWriter(MFileName3, False)
        MStreamWrite3.WriteLine("0")
        MStreamWrite3.WriteLine("0")
        MStreamWrite3.WriteLine("128")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("255")
        MStreamWrite3.WriteLine("180")
        MStreamWrite3.WriteLine("0")
        MStreamWrite3.WriteLine("90")
        MStreamWrite3.WriteLine("0")
        MStreamWrite3.WriteLine("0")
        MStreamWrite3.WriteLine("128")
        MStreamWrite3.WriteLine("225")
        MStreamWrite3.WriteLine("243")
        MStreamWrite3.WriteLine("245")
        MStreamWrite3.Flush()
        MStreamWrite3.Close()

        MsgBox("DataGridView 的字型、列高及顏色已調整並已存入檔案！", 0 + 64 + 128, "OK")
    End Sub

    ' 調整選取區的顏色
    Private Sub B_Selection_Click(sender As Object, e As EventArgs) Handles B_Selection.Click
        Me.TopMost = False
        Me.Enabled = False
        F_DGVselection.Show()
    End Sub

End Class