Imports System.IO

Public Class F_TempFile

    ' 建立暫用資料夾並存入檔案
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click

        ' 若檔案夾 C:\DATA_VBSAMPLE 不存在，則建立之
        ' 使用 DirectoryInfo 類別，需引用命名空間System.IO
        Dim MDESDIR As New DirectoryInfo("C:\DATA_VBSAMPLE")
        If MDESDIR.Exists = False Then
            MDESDIR.Create()
        End If
        Dim MSOUDIR As String = ""

        ' 來源檔之檔名及路徑存入 MSOURCEFN
        Dim MSOURCEFN01 As String = "APPDATA\範例A_銷售基本檔.xls"
        Dim MSOURCEFN02 As String = "APPDATA\範例B_銷售紀錄檔.xls"
        Dim MSOURCEFN03 As String = "APPDATA\MyTestFile01.txt"

        ' 設定目的檔之變數，目的檔之檔名及路徑存入 MDESFN
        Dim MDESFN01 As String = "C:\DATA_VBSAMPLE\範例A_銷售基本檔.xls"
        Dim MDESFN02 As String = "C:\DATA_VBSAMPLE\範例B_銷售紀錄檔.xls"
        Dim MDESFN03 As String = "C:\DATA_VBSAMPLE\MyTestFile01.txt"

        ' 將來源檔複製於目的檔案夾
        FileCopy(MSOURCEFN01, MDESFN01)
        FileCopy(MSOURCEFN02, MDESFN02)
        FileCopy(MSOURCEFN03, MDESFN03)
        MsgBox("已處理完畢！", 0 + 64 + 128, "OK")
    End Sub

    ' 將文字盒 TextBox1 的資料寫入暫用資料夾 C:\DATA_VBSAMPLE 之內的文字檔 MyTestFile01.txt
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        ' 使一般 User 具有寫入 DATA_VBSAMPLE 資料夾的權限，內定一般 User 只有讀取權
        Shell("C:\Windows\System32\cacls C:\DATA_VBSAMPLE /T /E /G Users:C")

        Dim MFileName = "C:\DATA_VBSAMPLE\MyTestFile01.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        ' 若未輸入資料，則發出警告
        If TextBox1.Text = "" Then
            MsgBox("Sorry，資料尚未輸入！" + Chr(13) + Chr(10) + "請輸入資料，再敲本按鈕", 0 + 16 + 128, "Error")
            MStreamWrite.Close()
            TextBox1.Focus()
            Exit Sub
        Else
            MStreamWrite.WriteLine(TextBox1.Text)
        End If
        MStreamWrite.Flush()
        MStreamWrite.Close()
        MsgBox("資料已寫入！", 0 + 64 + 128, "OK")
    End Sub

    ' 讀出暫用資料夾 C:\DATA_VBSAMPLE 之內的文字檔 MyTestFile01.txt ，並置入文字盒 TextBox1
    ' 每一列資料要換列顯示
    Private Sub B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click
        TextBox1.Text = ""
        Dim MFileName = "C:\DATA_VBSAMPLE\MyTestFile01.txt"
        ' 先使用 File 類別的 Exists 方法檢查檔案是否存在
        If File.Exists(MFileName) = False Then
            MsgBox("Sorry，檔案不存在！" + Chr(13) + Chr(10) + "請先敲『建立資料夾』或『寫入資料』，再敲本按鈕", 0 + 16 + 128, "Error")
            Exit Sub
        End If
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        Dim MTempString As String
        Do
            MTempString = MStreamRead.ReadLine()
            If TextBox1.Text = "" Then
                TextBox1.Text = MTempString
            Else
                TextBox1.Text = TextBox1.Text + Chr(13) + Chr(10) + MTempString
            End If
        Loop Until MStreamRead.Peek() = -1
        MStreamRead.Close()
        MsgBox("已讀取完畢！", 0 + 64 + 128, "OK")
    End Sub

    ' 清空文字盒資料
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        TextBox1.Text = ""
    End Sub
End Class