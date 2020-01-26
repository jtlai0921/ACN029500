Public Class F_Save01
    ' 宣告陣列 Asavefile，以便儲存存檔型別及存檔名稱（含路徑）
    Public Asavefile(1) As String



    ' 載入本表單時建立資料夾及內定檔名
    Private Sub F_Save01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 若 D:\TestQuery 資料夾不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If
        T_Path.Text = "D:\TestQuery\Q_SalarySubtotal01.xls"
    End Sub

    ' 使用 SaveFileDialog 檔案對話方塊控制項讓 User 設定匯出檔的檔名及路徑
    ' InitialDirectory 屬性可設定預設目錄， 例如 D:\TestQuery
    ' Filter 屬性可設定檔案對話方塊中篩選器的預設副檔名 ， 例如 "Excel files|*.xls|HTML files|*.htm|ALL files|*.*" ，有三種副檔名可選擇
    ' FilterIndex 屬性可設定檔案對話方塊中篩選器的預設索引
    ' CheckPathExists 若指定了不存在的路徑，是否要顯示警告訊息
    ' FileName 屬性可設定或傳回檔案對話方塊中之檔名及路徑
    ' AddExtension 屬性若設為 True，則可自動加上內定的副檔名，若設為 False，則 DefaultExt 無效
    ' DefaultExt 屬性可設定內定的副檔名
    ' Title 屬性可設定檔案對話方塊之標題
    ' ShowHelp 屬性可設定檔案對話方塊是否要顯示『說明』鈕
    ' RestoreDirectory 屬性可設定檔案對話方塊是否要使用預設目錄，若要以前次所開啟的資料夾為預設目錄，應將本屬性設為 False，
    ' 但需同時取消 InitialDirectory屬性之使用
    ' 本範例之內定目錄及檔名為 D:\TestQuery\Q_SalarySubtotal01，副檔名則會依據 User 所敲選的檔案類型自動給予，
    ' 檔案對話方塊控制項的詳細使用方法請參考附錄 SaveFileDialog 的說明
    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        SaveFileDialog1.Title = "請敲選或輸入檔名及路徑"
        SaveFileDialog1.InitialDirectory = "D:\TestQuery"
        SaveFileDialog1.RestoreDirectory = False
        SaveFileDialog1.ShowHelp = False

        SaveFileDialog1.FileName = "Q_SalarySubtotal01"
        If T_File01.Checked = True Then
            SaveFileDialog1.DefaultExt = "xls"
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.Filter = "Excel files|*.xls"
        End If
        If T_File02.Checked = True Then
            SaveFileDialog1.DefaultExt = "htm"
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.Filter = "HTML files|*.htm"
        End If

        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.CheckPathExists = True
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            T_Path.Text = SaveFileDialog1.FileName
        Else
            T_Path.Text = ""
        End If
    End Sub

    ' OK，將 User 所設定的存檔型別及存檔名稱（含路徑）儲存於陣列，以供  F_QueryAdvanceResult 表單使用
    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        If Strings.Trim(T_Path.Text) = "" Then
            MsgBox("Sorry, 檔名尚未設定！" + Chr(13) + Chr(10) + "請先設定", 0 + 16, "Error")
            Exit Sub
        End If
        If T_File01.Checked = True Then
            Asavefile(0) = "xls"
        End If
        If T_File02.Checked = True Then
            Asavefile(0) = "htm"
        End If
        Asavefile(1) = T_Path.Text
        Me.Hide()
        F_QueryAdvanceResult.Enabled = True
        F_QueryAdvanceResult.Show()
    End Sub

    ' 放棄，陣列 Asavefile 之值設為 GiveUp，以供  F_QueryAdvanceResult 表單使用
    Private Sub B_GiveUp_Click(sender As Object, e As EventArgs) Handles B_GiveUp.Click
        Asavefile(0) = "GiveUp"
        Asavefile(1) = "GiveUp"
        Me.Hide()
        F_QueryAdvanceResult.Enabled = True
        F_QueryAdvanceResult.Show()
    End Sub

    ' 當 User 重敲檔案類型時，需更換內定檔名
    Private Sub T_File01_CheckedChanged(sender As Object, e As EventArgs) Handles T_File01.CheckedChanged
        If T_File01.Checked = True Then
            T_Path.Text = "D:\TestQuery\Q_SalarySubtotal01.xls"
        End If
    End Sub

    ' 當 User 重敲檔案類型時，需更換內定檔名
    Private Sub T_File02_CheckedChanged(sender As Object, e As EventArgs) Handles T_File02.CheckedChanged
        If T_File02.Checked = True Then
            T_Path.Text = "D:\TestQuery\Q_SalarySubtotal01.htm"
        End If
    End Sub

End Class