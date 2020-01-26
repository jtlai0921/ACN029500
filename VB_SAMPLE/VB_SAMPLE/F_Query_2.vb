Public Class F_Query_2

    ' 敲選豐富文字盒中的超連結事件
    ' 將 e.LinkText 指定給瀏覽器控制項的 Navigate方法，以便顯示連結之網頁
    ' e.LinkText 參數為超連結之位址
    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        WebBrowser1.Navigate(e.LinkText)
    End Sub

    ' 離開表單
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

    ' 載入本表單時，匯入 RTF 檔
    Private Sub F_Query_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Clear()
        RichTextBox1.LoadFile("APPDATA\RichTextBoxLink.rtf")
    End Sub

    ' 下拉式選單選取變動事件
    Private Sub T_WEB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_WEB.SelectedIndexChanged
        Dim Mweb As String = T_WEB.Text
        Select Case Mweb
            Case "Google"
                WebBrowser1.Navigate("http://www.google.com/")
            Case "奇摩"
                WebBrowser1.Navigate("https://tw.yahoo.com/")
            Case "石門水庫水情資訊"
                WebBrowser1.Navigate("http://www.wranb.gov.tw/np.asp?ctNode=458&mp=4")
            Case "中華郵政"
                WebBrowser1.Navigate("http://www.post.gov.tw/post/internet/index.jsp")
            Case "微軟"
                WebBrowser1.Navigate("http://www.microsoft.com/zh-tw/")
        End Select
        
    End Sub

    ' 重設
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        WebBrowser1.Navigate("about:blank")
        RichTextBox1.Clear()
        T_WEB.Text = ""
    End Sub

    ' 匯入 RTF 檔
    Private Sub B_LoadFile_Click(sender As Object, e As EventArgs) Handles B_LoadFile.Click
        Dim MFN As String = ""
        OpenFileDialog1.Filter = "(RTF 檔)|*.rtf"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "請選取一個 RTF 檔"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MFN = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If
        RichTextBox1.Clear()
        RichTextBox1.LoadFile(MFN)
        MsgBox("檔案已匯入！", 0 + 64, "OK")
    End Sub

End Class