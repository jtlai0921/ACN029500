Imports System.IO
Imports System.Security.Permissions

Public Class F_VIDEO

    ' 建立播放清單
    Private Sub B_PickFile_Click(sender As Object, e As EventArgs) Handles B_PickFile.Click
        ' 使用 Reset 方法清除前一次的選取結果，否則第二次選檔時，檔名欄會以前一次所選檔案為預設值，
        ' 此時 User若敲『取消』鈕，系統會將前一次所選檔案帶入 ListBox，而導致資料重複，即使增加如下的判斷程式亦無效，
        '  Reset 須在 Filter 之前執行，否則過濾功能會喪失
        ' 若只想傳回 User 所選檔名（不含路徑），則須使用 Path.GetFileName 方法，例如 TextBox1.Text = Path.GetFileName(OpenFileDialog1.FileName)，
        ' 使用 Path.GetFileName 須使用命名空間 Imports System.IO
        ' 使用 Filter 限制選檔的類別
        OpenFileDialog1.Reset()
        OpenFileDialog1.Filter = "Video & Music Files (mp4,avi,wmv,mov,swf,mp3,midi)|*.mp4;*.avi;*.wmv;*.mov;*.swf;*.mp3;*.mid|All Files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        Dim MFileName As String = OpenFileDialog1.FileName
        If MFileName <> "" Then
            ' 先判斷所選檔案是否已選過，以免重複
            If ListBox1.FindString(MFileName) = -1 Then
                ListBox1.Items.Add(OpenFileDialog1.FileName)
            End If
        End If
    End Sub

    ' 移除播放清單中的項目
    Private Sub B_Remove_Click(sender As Object, e As EventArgs) Handles B_Remove.Click
        Dim MSelectItem As String = ListBox1.SelectedItem
        ListBox1.Items.Remove(MSelectItem)
        ListBox1.Focus()
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    ' 自動接續播放清單上的所有影片或音樂
    Private Sub B_PlayAll_Click(sender As Object, e As EventArgs) Handles B_PlayAll.Click
        Dim MTotalItemsNo As Integer = ListBox1.Items.Count
        Dim MVideoName As String
        ' 逐一將 ListBox 的項目加入播放清單
        For Mcou As Integer = 0 To MTotalItemsNo - 1 Step 1
            MVideoName = ListBox1.Items(Mcou)
            Dim MTempMVideoName = AxWindowsMediaPlayer1.newMedia(MVideoName)
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(MTempMVideoName)
        Next
        ' 設定連續播放
        AxWindowsMediaPlayer1.settings.setMode("Loop", True)
        ' 開始播放
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    ' 只播放 User 在清單上所點選的項目
    Private Sub B_PlayOne_Click(sender As Object, e As EventArgs) Handles B_PlayOne.Click
        ' 取回 User 所選項目
        Dim MVideoName As String
        MVideoName = ListBox1.SelectedItem
        AxWindowsMediaPlayer1.URL = MVideoName
        ' 不連續播放
        AxWindowsMediaPlayer1.settings.setMode("Loop", False)
        ' 開始播放
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    ' 將清單存入文字檔
    Private Sub B_ListSave_Click(sender As Object, e As EventArgs) Handles B_ListSave.Click
        Dim MFileName = "APPDATA\MyVideoList.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)

        Dim MTotalItemsNo As Integer = ListBox1.Items.Count
        Dim MVideoName As String
        ' 逐一將 ListBox 的項目逐一存入檔案
        For Mcou As Integer = 0 To MTotalItemsNo - 1 Step 1
            MVideoName = ListBox1.Items(Mcou)
            MStreamWrite.WriteLine(MVideoName)
        Next
        MStreamWrite.Flush()
        MStreamWrite.Close()
        MsgBox("已存入檔案！", 0 + 64 + 128, "OK")
        ListBox1.Focus()
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If
        ListBox1.Focus()
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    ' 讀取文字檔內容，再存入清單
    Private Sub B_ListRead_Click(sender As Object, e As EventArgs) Handles B_ListRead.Click
        ' 先清空 ListBox
        ListBox1.Items.Clear()
        Dim MVideoName As String
        Dim MFileName = "APPDATA\MyVideoList.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        Do
            MVideoName = MStreamRead.ReadLine()
            ListBox1.Items.Add(MVideoName)
        Loop Until MStreamRead.Peek() = -1
        MStreamRead.Close()
        MsgBox("已讀取完畢！", 0 + 64 + 128, "OK")
        ListBox1.Focus()
        ListBox1.SelectedIndex = 0
    End Sub

    ' 載入本表單時，置入說明文字
    ' & vbCrLF & 可換行顯示，使用 Chr(13) & Chr(10)  亦可
    Private Sub F_VIDEO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MDESC01 As String = "請先敲『增加』鈕，以便選取欲播放的影音檔，然後再敲『連續播放』或『單點播放』，前者可連續播放清單上的影音檔，後者只播放清單上被選取的檔案。"
        Dim MDESC02 As String = "敲『移除』鈕，可移除清單上被選取的檔案。"
        Dim MDESC03 As String = "敲『儲存清單』鈕，可將清單內容存檔，已備下次使用。"
        Dim MDESC04 As String = "敲『讀取清單』鈕，可讀取前次存檔的資料並列示於清單上，供 User 選用。"

        ' T_Description.Text = "請先敲『增加』鈕，以便選取欲播放的影音檔，然後再敲『連續播放』或『單點播放』，前者可連續播放清單上的影音檔，後者只播放清單上被選取的檔案。"
        ' 敲『移除』鈕，可移除清單上被選取的檔案。敲『儲存清單』鈕，可將清單內容存檔，已備下次使用。
        ' 敲『讀取清單』鈕，可讀取前次存檔的資料並列示於清單上，供 User 選用。
        ' T_Description.Text = MDESC01 & vbCrLf & MDESC02 & vbCrLf & MDESC03 & vbCrLf & MDESC04
        T_Description.Text = MDESC01 & Chr(13) & Chr(10) & MDESC02 & Chr(13) & Chr(10) & MDESC03 & Chr(13) & Chr(10) & MDESC04

        ' 安裝於網路磁碟機才需使用下列程式碼
        ' 將播放清單及影音檔考入暫存資料夾
        ' 若檔案夾 C:\DATA_VBSAMPLE 不存在，則建立之
        'Dim MDESDIR As New DirectoryInfo("C:\DATA_VBSAMPLE")
        'If MDESDIR.Exists = False Then
        'MDESDIR.Create()
        'End If
        'Dim MSOUDIR As String = ""
        'MSOUDIR = Directory.GetCurrentDirectory() + "\APPDATA\"

        ' 來源檔之檔名及路徑存入 MSOURCEFN
        'Dim MSOURCEFN01 As String = MSOUDIR + "MyVideoList.txt"
        'Dim MSOURCEFN02 As String = MSOUDIR + "上海夜景.mp4"
        'Dim MSOURCEFN03 As String = MSOUDIR + "可愛的狗狗.mp4"
        'Dim MSOURCEFN04 As String = MSOUDIR + "安娜之歌.mid"
        'Dim MSOURCEFN05 As String = MSOUDIR + "愛的羅曼史.mid"
        'Dim MSOURCEFN06 As String = MSOUDIR + "嘉禾舞曲.MID"

        ' 若要發行於網路磁碟機，則不要使用 GetCurrentDirectory() 偵測檔案之所在，而應使用固定位置
        'Dim MSOURCEFN01 As String = "W:\VBSAMPLE\APPDATA\MyVideoList.txt"
        'Dim MSOURCEFN02 As String = "W:\VBSAMPLE\APPDATA\上海夜景.mp4"
        'Dim MSOURCEFN03 As String = "W:\VBSAMPLE\APPDATA\可愛的狗狗.mp4"
        'Dim MSOURCEFN04 As String = "W:\VBSAMPLE\APPDATA\安娜之歌.mid"
        'Dim MSOURCEFN05 As String = "W:\VBSAMPLE\APPDATA\愛的羅曼史.mid"
        'Dim MSOURCEFN06 As String = "W:\VBSAMPLE\APPDATA\嘉禾舞曲.MID"

        ' 設定目的檔之變數，目的檔之檔名及路徑存入 MDESFN
        'Dim MDESFN01 As String = "C:\DATA_VBSAMPLE\MyVideoList.txt"
        'Dim MDESFN02 As String = "C:\DATA_VBSAMPLE\上海夜景.mp4"
        'Dim MDESFN03 As String = "C:\DATA_VBSAMPLE\可愛的狗狗.mp4"
        'Dim MDESFN04 As String = "C:\DATA_VBSAMPLE\安娜之歌.mid"
        'Dim MDESFN05 As String = "C:\DATA_VBSAMPLE\愛的羅曼史.mid"
        'Dim MDESFN06 As String = "C:\DATA_VBSAMPLE\嘉禾舞曲.MID"

        ' 將來源檔複製於目的檔案夾
        'FileCopy(MSOURCEFN01, MDESFN01)
        'FileCopy(MSOURCEFN02, MDESFN02)
        'FileCopy(MSOURCEFN03, MDESFN03)
        'FileCopy(MSOURCEFN04, MDESFN04)
        'FileCopy(MSOURCEFN05, MDESFN05)
        'FileCopy(MSOURCEFN06, MDESFN06)

        'Dim MChangeFile As String = Directory.GetCurrentDirectory() + "\APPDATA\MyVideoList.txt"
        'Dim MChangeFileAtt As New FileIOPermission(FileIOPermissionAccess.Read, MChangeFile)
        'MChangeFileAtt.AddPathList(FileIOPermissionAccess.Write Or FileIOPermissionAccess.Read, MChangeFile)

        ' 載入清單項目
        ListBox1.Items.Clear()
        Dim MVideoName As String
        Dim MFileName = "APPDATA\MyVideoList.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        Do
            MVideoName = MStreamRead.ReadLine()
            ListBox1.Items.Add(MVideoName)
        Loop Until MStreamRead.Peek() = -1
        MStreamRead.Close()
        ListBox1.Focus()
        ListBox1.SelectedIndex = 0

    End Sub

    ' 顯示說明時，其他按鈕反制能（播放器隱藏），隱藏說明時，其他按鈕才可作用（播放器顯示）
    Private Sub B_Desc_Click(sender As Object, e As EventArgs) Handles B_Desc.Click

        If T_Description.Visible = True Then
            T_Description.Visible = False
            'Me.Text = "顯示說明"
            B_Desc.Text = "顯示說明"
            B_PlayAll.Enabled = True
            B_PlayOne.Enabled = True
            B_Close.Enabled = True
            B_PickFile.Enabled = True
            B_Remove.Enabled = True
            B_ListSave.Enabled = True
            B_ListRead.Enabled = True
            AxWindowsMediaPlayer1.Visible = True
        Else
            T_Description.Visible = True
            'Me.Text = "隱藏說明"
            B_Desc.Text = "隱藏說明"
            B_PlayAll.Enabled = False
            B_PlayOne.Enabled = False
            B_Close.Enabled = False
            B_PickFile.Enabled = False
            B_Remove.Enabled = False
            B_ListSave.Enabled = False
            B_ListRead.Enabled = False
            AxWindowsMediaPlayer1.Visible = False
        End If
    End Sub

End Class