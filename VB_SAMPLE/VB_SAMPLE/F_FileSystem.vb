Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.Data
Imports System.Data.OleDb

Public Class F_FileSystem
    ' 宣告二維陣列 ATemp01 儲存欲寫入檔案的資料（三列四欄）
    ' 若在宣告陣列的同時給予陣列值，則不能設定陣列的大小，但若為二維陣列，則括號中的逗號不能省略
    Public ATemp01(,) As String = {{"香蕉", 1, 10.5, "2015/04/09"}, {"水蜜桃", 20, 1000, "2015/04/10"}, {"蓮霧", 3, 600.05, "2015/04/12"}}



    ' 新增資料夾
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        ' 使用 FileSystem 類別的 MkDir 方法建立新資料夾，
        ' 先使用 Directory 類別的 Exists 方法 檢查資料夾是否已存在
        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = True Then
            MsgBox("C:\TEST01 資料夾已存在！", 0 + 64, "OK")
        Else
            My.Computer.FileSystem.CreateDirectory("C:\TEST01")
            MsgBox("C:\TEST01 資料夾已新增！", 0 + 64, "OK")
        End If
    End Sub

    ' 寫入以逗號分隔的順序檔 Sequential Access File
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = False Then
            MsgBox("請先敲 A1 鈕，以便建立資料夾 C:\TEST01", 0 + 16, "Error")
            Exit Sub
        End If

        ' OpenTextFileWriter 方法可開啟 StreamWriter 物件，以便將資料寫入檔案，
        ' 括號內第一個引數為檔案名稱及其路徑，第二個引數為附加與否，True 表示要附加，False 表示要覆蓋，第三個引數為編碼，編碼方式有 ASCII、UTF-8 等，此處使用系統預設值
        ' StreamWriter 資料流寫入類別的 WriteLine 方法可將資料寫入檔案，其後加上行結束字元，但 Write 則不加
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\TestA.csv", False, Encoding.Default)

        ' 使用雙迴圈將陣列中的資料寫入檔案，
        ' 內迴圈逐欄寫入，若非最後一欄，則補上逗號，若為最後一欄，則補上歸位及換行字元 Chr(13) 及 Chr(10)
        '  Write 方法可將資料寫入順序檔案，但不加入歸位及換行字元， WriteLine 則包含歸位及換行字元
        ' 宣告變數 Mcolstr 儲存每一陣列元素的資料
        Dim Mcolstr As String = ""
        For Mrow = 0 To 2 Step 1
            Mcolstr = ""
            For Mcol = 0 To 3 Step 1
                If Mcol = 3 Then
                    'Mcolstr = ATemp01(Mrow, Mcol) + vbCrLf
                    Mcolstr = ATemp01(Mrow, Mcol) + Chr(13) + Chr(10)
                Else
                    Mcolstr = ATemp01(Mrow, Mcol) + ","
                End If
                O_file.Write(Mcolstr)
            Next
        Next

        ' StreamWriter 資料流寫入類別的 Close 方法可關閉檔案
        O_file.Close()
        MsgBox("資料已寫入 C:\TEST01\TestA.csv！", 0 + 64, "OK")

        '***********************************************************************************************************************************
        ' 取回可用的檔案代碼
        'Dim MFileNo As Integer = FileSystem.FreeFile

        ' 開啟檔案，括號內第一個引數為檔案代碼，第二個引數為檔名及其路徑，第三個引數為 OpenMode 開啟模式，第四個引數為 AccessMode 處理模式，
        ' 開啟模式有 Append 開啟檔案附加到其中、Binary 開啟檔案進行二進位存取、Input 開啟檔案進行讀取、Output 開啟檔案進行寫入、Random 開啟檔案進行隨機存取。 
        ' 處理模式有 Default 允許讀取和寫入的權限（預設值）、 Read 允許讀取權限、ReadWrite 允許讀取和寫入的權限、Write 允許寫入權限。 
        ' 使用 Write 或 WriteLine 函式寫入檔案，需要 FileIOPermissionAccess 列舉型別的 Append 存取權限
        'FileSystem.FileOpen(MFileNo, "C:\TEST01\TestA.csv", OpenMode.Output, OpenAccess.Write)

        ' 宣告變數 Mcolstr 儲存每一陣列元素的資料
        'Dim Mcolstr As String = ""

        ' 內迴圈逐欄寫入，若非最後一欄，則補上逗號，若為最後一欄，則補上歸位及換行字元 Chr(13) 及 Chr(10)
        ' Print 方法可將資料寫入順序檔案，但不加入歸位及換行字元，PrintLine 則包含歸位及換行字元
        'For Mrow = 0 To 2 Step 1
        'Mcolstr = ""
        'For Mcol = 0 To 3 Step 1
        'If Mcol = 3 Then
        'Mcolstr = ATemp01(Mrow, Mcol) + Chr(13) + Chr(10)
        'Else
        'Mcolstr = ATemp01(Mrow, Mcol) + ","
        'End If
        'FileSystem.Print(MFileNo, Mcolstr)
        'Next
        'Next

        ' FileClose 方法 可關閉檔案
        'FileSystem.FileClose(MFileNo)

        'MsgBox("資料已寫入 C:\TEST01\TestA.csv！", 0 + 64, "OK")

    End Sub

    ' 寫入以 TAB 分隔的順序檔 Sequential Access File
    Private Sub B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click

        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = False Then
            MsgBox("請先敲 A1 鈕，以便建立資料夾 C:\TEST01", 0 + 16, "Error")
            Exit Sub
        End If

        ' OpenTextFileWriter 方法可開啟 StreamWriter 物件，以便將資料寫入檔案，
        ' 括號內第一個引數為檔案名稱及其路徑，第二個引數為附加與否，True 表示要附加，False 表示要覆蓋，第三個引數為編碼，編碼方式有 ASCII、UTF-8 等，此處使用系統預設值
        ' StreamWriter 資料流寫入類別的 WriteLine 方法可將資料寫入檔案，其後加上行結束字元，但 Write 則不加
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\TestB.txt", False, Encoding.Default)

        ' 使用雙迴圈將陣列中的資料寫入檔案，
        ' 內迴圈逐欄寫入，若非最後一欄，則補上逗號，若為最後一欄，則補上歸位及換行字元 Chr(13) 及 Chr(10)
        '  Write 方法可將資料寫入順序檔案，但不加入歸位及換行字元， WriteLine 則包含歸位及換行字元
        ' 宣告變數 Mcolstr 儲存每一陣列元素的資料
        Dim Mcolstr As String = ""
        For Mrow = 0 To 2 Step 1
            Mcolstr = ""
            For Mcol = 0 To 3 Step 1
                If Mcol = 3 Then
                    Mcolstr = ATemp01(Mrow, Mcol) + Chr(13) + Chr(10)
                Else
                    Mcolstr = ATemp01(Mrow, Mcol) + vbTab
                End If
                O_file.Write(Mcolstr)
            Next
        Next

        ' StreamWriter 資料流寫入類別的 Close 方法可關閉檔案
        O_file.Close()
        MsgBox("資料已寫入 C:\TEST01\TestB.txt！", 0 + 64, "OK")

    End Sub

    ' 寫入以 空白 分隔的順序檔 Sequential Access File
    Private Sub B_04_Click(sender As Object, e As EventArgs) Handles B_04.Click

        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = False Then
            MsgBox("請先敲 A1 鈕，以便建立資料夾 C:\TEST01", 0 + 16, "Error")
            Exit Sub
        End If

        ' OpenTextFileWriter 方法可開啟 StreamWriter 物件，以便將資料寫入檔案，
        ' 括號內第一個引數為檔案名稱及其路徑，第二個引數為附加與否，True 表示要附加，False 表示要覆蓋，第三個引數為編碼，編碼方式有 ASCII、UTF-8 等，此處使用系統預設值
        ' StreamWriter 資料流寫入類別的 WriteLine 方法可將資料寫入檔案，其後加上行結束字元，但 Write 則不加
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\TestC.txt", False, Encoding.UTF8)

        ' 使用雙迴圈將陣列中的資料寫入檔案，
        ' 內迴圈逐欄寫入，若非最後一欄，則補上逗號，若為最後一欄，則補上歸位及換行字元 Chr(13) 及 Chr(10)
        '  Write 方法可將資料寫入順序檔案，但不加入歸位及換行字元， WriteLine 則包含歸位及換行字元
        ' 宣告變數 Mcolstr 儲存每一陣列元素的資料
        Dim Mcolstr As String = ""
        For Mrow = 0 To 2 Step 1
            Mcolstr = ""
            For Mcol = 0 To 3 Step 1
                If Mcol = 3 Then
                    Mcolstr = ATemp01(Mrow, Mcol) + Chr(13) + Chr(10)
                Else
                    Mcolstr = ATemp01(Mrow, Mcol) + Strings.Space(1)
                End If
                O_file.Write(Mcolstr)
            Next
        Next

        ' StreamWriter 資料流寫入類別的 Close 方法可關閉檔案
        O_file.Close()
        MsgBox("資料已寫入 C:\TEST01\TestC.txt！", 0 + 64, "OK")

    End Sub

    ' 寫入隨機檔 Random Access File （每一欄長度固定）
    Private Sub B_05_Click(sender As Object, e As EventArgs) Handles B_05.Click

        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = False Then
            MsgBox("請先敲 A1 鈕，以便建立資料夾 C:\TEST01", 0 + 16, "Error")
            Exit Sub
        End If

        ' OpenTextFileWriter 方法可開啟 StreamWriter 物件，以便將資料寫入檔案，
        ' 括號內第一個引數為檔案名稱及其路徑，第二個引數為附加與否，True 表示要附加，False 表示要覆蓋，第三個引數為編碼，編碼方式有 ASCII、UTF-8 等，此處使用系統預設值
        ' StreamWriter 資料流寫入類別的 WriteLine 方法可將資料寫入檔案，其後加上行結束字元，但 Write 則不加
        'Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\TestD.txt", False, Encoding.Default)
        ' 編碼方式為 UTF8
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\TestD.txt", False, Encoding.UTF8)

        ' 宣告變數 MString 儲存各欄合併後的資料、Mcolstr 儲存每一陣列元素的資料、Mspaceqty 儲存每一資料應補上的空白數
        ' 變數 Mcol0～Mcol3 指定各欄的固定長度
        Dim MString As String = ""
        Dim Mcolstr As String = ""
        Dim Mspaceqty As Integer = 0
        Dim Mcol0 As Integer = 10
        Dim Mcol1 As Integer = 5
        Dim Mcol2 As Integer = 12
        Dim Mcol3 As Integer = 10

        ' 處理陣列中的資料並寫入檔案
        ' 內迴圈逐欄處理，每一欄補上應有的空白數，再合併各欄並存入變數 MString ，Mcolstr  儲存某一格位之值
        ' 外迴圈逐列處理，使用StreamWriter 資料流寫入類別的 WriteLine 方法 方法將合併後資料（整列資料）寫入檔案（包含歸位及換行字元）
        For Mrow = 0 To 2 Step 1
            MString = ""
            Mcolstr = ""
            Mspaceqty = 0
            For Mcol = 0 To 3 Step 1
                Mcolstr = ATemp01(Mrow, Mcol)
                Select Case Mcol
                    Case 0
                        'Mspaceqty = Mcol0 - Strings.Len(Mcolstr)
                        Mspaceqty = Mcol0 - (Strings.Len(Mcolstr)) * 2
                    Case 1
                        Mspaceqty = Mcol1 - Strings.Len(Mcolstr)
                    Case 2
                        Mspaceqty = Mcol2 - Strings.Len(Mcolstr)
                    Case 3
                        Mspaceqty = Mcol3 - Strings.Len(Mcolstr)
                End Select
                MString = MString & Mcolstr & Strings.Space(Mspaceqty)
            Next
            O_file.WriteLine(MString)
        Next

        ' StreamWriter 資料流寫入類別的 Close 方法可關閉檔案
        O_file.Close()
        MsgBox("資料已寫入 C:\TEST01\TestD.txt！", 0 + 64, "OK")

    End Sub

    ' 傳回特定檔案的資訊
    ' 比 FileSystem 類別的 FileLen 等方法可提供更多的訊息
    Private Sub B_B1_Click(sender As Object, e As EventArgs) Handles B_B1.Click
        If My.Computer.FileSystem.FileExists("C:\TEST01\TestA.csv") = False Then
            MsgBox("TestA.csv 檔不存在，請先敲 A2 鈕，以便產生該檔", 0 + 16, "Error")
            Exit Sub
        End If

        ' 使用 GetFileInfo 方法取回檔案資訊（包括檔案名稱、檔案大小、資料夾名稱、副檔名、上次處理時間及檔案屬性等）
        Dim O_information = My.Computer.FileSystem.GetFileInfo("C:\TEST01\TestA.csv")

        ' 使用 RichTextBox1 的 AppendText 方法 將檔案資訊顯示於豐富文字盒
        ' 檔案屬性→ Archive 可讀寫、ReadOnly 唯讀、 Hidden 隱藏、System 系統
        RichTextBox1.Text = ""
        RichTextBox1.AppendText("檔案全名： " + O_information.FullName + Chr(13) + Chr(10))
        RichTextBox1.AppendText("檔名： " + O_information.Name + Chr(13) + Chr(10))
        RichTextBox1.AppendText("檔案之副檔名： " + O_information.Extension + Chr(13) + Chr(10))
        RichTextBox1.AppendText("資料夾名稱： " + O_information.DirectoryName + Chr(13) + Chr(10))
        RichTextBox1.AppendText("檔案大小： " + O_information.Length.ToString + " byte" + Chr(13) + Chr(10))
        RichTextBox1.AppendText("上次處理時間： " + O_information.LastAccessTime.ToString + Chr(13) + Chr(10))
        RichTextBox1.AppendText("檔案屬性： " + O_information.Attributes.ToString)
        MsgBox("檔案資訊顯示於右方的文字盒", 0 + 64, "OK")

    End Sub

    ' 使用 FileSystem 類別的 CurDir 方法傳回目前的檔案路徑
    Private Sub B_B2_Click(sender As Object, e As EventArgs) Handles B_B2.Click
        Dim MPath As String = Microsoft.VisualBasic.FileSystem.CurDir
        MsgBox("目前的檔案路徑為 " + MPath, 0 + 64, "OK")
    End Sub

    ' 顯示檔名
    ' 使用 My.Computer.FileSystem 的 GetFiles 方法 可傳回指定資料夾內的檔案名稱並存入字串集合
    ' 第一個引數為資料夾名稱、第二個引數為是否要搜尋子資料夾，FileIO.SearchOption.SearchTopLevelOnly 不搜尋子資料夾（內定），FileIO.SearchOption.SearchAllSubDirectories 要搜尋子資料夾、
    ' 第三個引數為檔案類型（可搭配萬用字元）
    ' 使用 Directory 類別的 GetFiles 方法亦可傳回特定資料夾內的檔名，第一個引數為資料夾名稱、第二個引數為檔案類型、第三個引數為為是否要搜尋子資料夾，
    ' IO.SearchOption.AllDirectories 要搜尋子資料夾 ，IO.SearchOption.TopDirectoryOnly 不含子資料夾
    Private Sub B_B3_Click(sender As Object, e As EventArgs) Handles B_B3.Click
        Dim MQty As Integer = 0
        RichTextBox1.Text = ""
        'For Each MFileName As String In System.IO.Directory.GetFiles("C:\TEST01", "*.txt", IO.SearchOption.TopDirectoryOnly)
        'For Each MFileName As String In My.Computer.FileSystem.GetFiles("C:\TEST01", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
        For Each MFileName As String In My.Computer.FileSystem.GetFiles("C:\TEST01")
            RichTextBox1.AppendText(MFileName + Chr(13) + Chr(10))
            MQty = MQty + 1
        Next

        MsgBox("檔案共計 " + MQty.ToString + " 個" + Chr(13) + Chr(13) + "請見右方的文字盒", 0 + 64, "OK")

        ' 使用 FileSystem 類別的 Dir 方法亦可傳回指定類型的檔名，但比較麻煩，範例如下
        ' 下列程式可將 C:\TEST01 資料夾內的所有 Excel 檔的檔名存入陣列 AFileName，
        ' 括號內可指定資料夾及檔案類型，並可搭配萬用字元
        ' 第一次使用 Dir 時，必須提供路徑，若檔案有多個時，使用不含引數的 Dir()方法可讀出後續的項目
        ' 使用 ReDim Preserve 關鍵字來調整陣列的大小，以便容納不等數量的檔名
        ' ChDir 可切換資料夾
        'Dim AFileName(0) As String
        'Dim MTempFN As String = ""
        'Dim MQty As Integer = 0
        '    FileSystem.ChDir("C:\TEST01")
        '    MTempFN = FileSystem.Dir("*.*")
        '    AFileName(0) = MTempFN
        '    Do While MTempFN <> ""
        '        MTempFN = FileSystem.Dir()
        '        If MTempFN <> "" Then
        '            MQty = MQty + 1
        '            ReDim Preserve AFileName(MQty)
        '            AFileName(MQty) = MTempFN
        '        End If
        '    Loop
        ' 將最後一個檔名存入文字盒 TextBox1，陣列的 Count 屬性可傳回陣列元素的數量
        'TextBox1.Text = AFileName(AFileName.Count - 1)

        ' 將全部檔名顯示於豐富文字盒，陣列的 Count 屬性可傳回陣列元素的數量
        'Dim MItemNo As Integer = AFileName.Count - 1
        '    RichTextBox1.Text = ""
        '    For Mcou = 0 To MItemNo Step 1
        '        RichTextBox1.Text = RichTextBox1.Text + AFileName(Mcou) + Chr(13) + Chr(10)
        '    Next
        '    MsgBox("檔名共計 " + (MItemNo + 1).ToString + " 個" + Chr(13) + Chr(13) + "請見右方的文字盒", 0 + 64, "OK")

    End Sub

    ' 複製檔案，將 C:\TEST01 資料夾的檔案拷貝至 D:\TEST02 資料夾
    ' 先新增資料夾 D:\TEST02
    ' 使用 My.Computer.FileSystem.CopyFile 方法來拷貝檔案
    ' 括號內第一個引數為來源檔，第二個引數為目的檔（可更換檔名，但不能省略也不能使用萬用字元），第三個引數是否覆蓋已存在的檔案（Trur 或  False）
    ' 若使用 4 個引數，則第三個引數不能使用 True 或  False， 而必須使用 以視覺方式追蹤作業進度 FileIO.UIOption.AllDialogs 顯示對話方塊（讓 User 決定是否取代目的檔），FileIO.UIOption.OnlyErrorDialogs 錯誤時顯示對話方塊
    ' 第四個引數為按下對話方塊中的 [取消] 時應該執行的動作，FileIO.UICancelOption.DoNothing 不做任何動作， UICancelOption.ThrowException 取消作業（會中斷程式）
    Private Sub B_B4_Click(sender As Object, e As EventArgs) Handles B_B4.Click

        If My.Computer.FileSystem.DirectoryExists("D:\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If

        ' 拷貝單一檔案並顯示對話方塊，以便當目的檔存在時可由 User 決定如何處理
        'Me.SendToBack()
        'Try
        ''My.Computer.FileSystem.CopyFile("C:\TEST01\TestB.txt", "D:\TEST02\TestBBB.txt", True)
        'My.Computer.FileSystem.CopyFile("C:\TEST01\TestB.txt", "D:\TEST02\TestBBB.txt", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
        'Catch ex As Exception
        'MsgBox(ex.ToString, 0 + 16, "Error")
        'Exit Sub
        'End Try
        'Me.TopMost = True

        ' 拷貝資料夾內的全部檔案
        ' 先使用 My.Computer.FileSystem.GetFiles 方法逐一取出來源檔之檔名（含路徑），
        ' 再使用 My.Computer.FileSystem.GetFileInfo 的 Name 屬性取出檔名（不含路徑），以便作為目的檔之檔名
        For Each MSourceFile As String In My.Computer.FileSystem.GetFiles("C:\TEST01")
            Dim MFileName As String = My.Computer.FileSystem.GetFileInfo(MSourceFile).Name
            Dim Mdestination As String = "D:\TEST02\" + MFileName
            My.Computer.FileSystem.CopyFile(MSourceFile, Mdestination, True)
        Next
        MsgBox("C:\TEST01 資料夾的檔案已複製於 D:\TEST02 資料夾", 0 + 64 + 128, "OK")


        ' 以下使用 FileSystem 類別的 FileCopy 方法來拷貝檔案
        ' 欲複製的檔案不能開啟，且使用 FileCopy  需要完全信任
        ' FileCopy  括號內第一個引數為來源檔，第二個引數為目的檔（可更換檔名，但不能省略也不能使用萬用字元）
        ' FileCopy 一次只能複製一個檔案，若要拷貝多個檔案，則需要搭配 Directory 類別及 Path 類別
        ' Directory 類別的 GetFiles 方法可傳回特定檔案夾內所有檔案的檔名（包括完整路徑），括號內為磁碟機代號及資料夾名稱，需以雙引號括住
        ' Path 類別的 GetFileName 方法可傳回指定路徑之檔名（不含磁碟機代號及資料夾名稱）
        '    If Directory.Exists("D:\TEST02") = False Then
        '        FileSystem.MkDir("D:\TEST02")
        '    End If
        '    Try
        ' 拷貝一個檔案
        'FileSystem.FileCopy("C:\TEST01\TestB.txt", "D:\TEST02\TestBB.txt")

        ' 拷貝多個檔案
        '        For Each MSourceFile As String In Directory.GetFiles("C:\TEST01")
        '            FileSystem.FileCopy(MSourceFile, "D:\TEST02\" + Path.GetFileName(MSourceFile))
        '        Next

        ' 將來源區的全部檔名（包括完整路徑）顯示於文字盒
        'Dim AFileCollection() As String = Directory.GetFiles("C:\TEST01")
        'Dim MItemNo As Integer = AFileCollection.Length
        'For Mcou = 0 To MItemNo Step 1
        'RichTextBox1.Text = RichTextBox1.Text + AFileCollection(Mcou) + Chr(13) + Chr(10)
        'Next

        '        MsgBox("C:\TEST01 資料夾的檔案已複製於 D:\TEST02 資料夾", 0 + 64 + 128, "OK")
        '    Catch ex As Exception
        '        MsgBox(ex.ToString, 0 + 16, "Error")
        '    End Try
    End Sub

    ' 更換檔名
    '  My.Computer.FileSystem 無相關方法可用 Microsoft.VisualBasic.FileSystem 類別的 Rename 方法
    Private Sub B_B5_Click(sender As Object, e As EventArgs) Handles B_B5.Click
        Dim Mans As Integer = MsgBox("您確定要將 D:\TEST02\TestA.csv 的檔名更換為 TestBBB.csv 嗎？", 4 + 32, "Confirm")
        If Mans = 7 Then
            Exit Sub
        Else
            Try
                Microsoft.VisualBasic.FileSystem.Rename("D:\TEST02\TestA.csv ", "D:\TEST02\TestBBB.csv ")
            Catch ex As Exception
                MsgBox(ex.ToString, 0 + 16, "Error")
                Exit Sub
            End Try
            MsgBox("檔名已更換！", 0 + 64 + 128, "OK")
        End If
    End Sub

    ' 刪除檔案
    ' My.Computer.FileSystem.DeleteFile 不能使用萬用字元，Microsoft.VisualBasic.FileSystem.Kill 可使用萬用字元
    ' My.Computer.FileSystem.DeleteFile 括號內4個引數，第一個引數為欲刪除的檔案，第二個引數為顯示對話方塊，請 User 確認是否要刪除（OnlyErrorDialogs 錯誤時顯示或 AllDialogs 永遠顯示），
    ' 但若第三個引數設為 RecycleOption.SendToRecycleBin（丟入垃圾桶），則不會顯示對話方塊，
    ' 第三個引數為是否要將刪除的檔案丟入垃圾桶（SendToRecycleBin 丟入垃圾桶 或 DeletePermanently 永久性刪除），
    ' 第四個引數為按下對話方塊中的 [取消] 時應該執行的動作，FileIO.UICancelOption.DoNothing 不做任何動作， UICancelOption.ThrowException 取消作業（會中斷程式）
    Private Sub B_B6_Click(sender As Object, e As EventArgs) Handles B_B6.Click
        Dim Mans As Integer = MsgBox("您確定要刪除 D:\TEST02 資料夾中的 TestB.txt 檔嗎？", 4 + 32, "Confirm")
        If Mans = 7 Then
            Exit Sub
        Else
            Try
                Me.SendToBack()
                'Microsoft.VisualBasic.FileSystem.Kill("D:\TEST02\*.txt")
                'My.Computer.FileSystem.DeleteFile("D:\TEST02\TestB.txt")
                My.Computer.FileSystem.DeleteFile("D:\TEST02\TestB.txt", UIOption.AllDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                Me.TopMost = True
                'MsgBox("檔案已刪除！", 0 + 64 + 128, "OK")
            Catch ex As Exception
                MsgBox(ex.ToString, 0 + 16, "Error")
                Exit Sub
            End Try
        End If
    End Sub

    ' 刪除資料夾
    ' My.Computer.FileSystem 的 DeleteDirectory 方法可刪除資料夾
    ' 此方法為多載，括號內引數可為2或3或4 個，
    ' 括號內 2 個引數，第一個引數為欲刪除的資料夾，第二個引數為資料夾內有檔案時的處理方式（DeleteAllContents 刪除所有檔案 或 ThrowIfDirectoryNonEmpty 資料夾內無檔案時才會刪除）
    ' 括號內 3 個引數，第一個引數為欲刪除的資料夾，第二個引數為顯示對話方塊，請 User 確認是否要刪除（OnlyErrorDialogs 錯誤時顯示 或 AllDialogs 永遠顯示），
    ' 但若第三個引數設為 RecycleOption.SendToRecycleBin（丟入垃圾桶），則不會顯示對話方塊，
    ' 第三個引數為是否將刪除的檔案丟入垃圾桶（RecycleOption.SendToRecycleBin 丟入垃圾桶 或 RecycleOption.DeletePermanently 永遠刪除）
    ' 括號內 4 個引數，第一個引數為欲刪除的資料夾，第二個引數為顯示對話方塊，請 User 確認是否要刪除（OnlyErrorDialogs 錯誤時顯示或 AllDialogs 永遠顯示），
    ' 第三個引數為是否將刪除的檔案丟入垃圾桶（RecycleOption.SendToRecycleBin 丟入垃圾桶 或 RecycleOption.DeletePermanently 永遠刪除）
    ' 第四個引數為按下對話方塊中的 [取消] 時應該執行的動作，FileIO.UICancelOption.DoNothing 不做任何動作， UICancelOption.ThrowException 取消作業（會中斷程式）
    '使用 Microsoft.VisualBasic.FileSystem.RmDir 刪除資料夾時，若資料夾內有檔案，則會執行例外狀況之處理
    Private Sub B_B7_Click(sender As Object, e As EventArgs) Handles B_B7.Click
        Dim Mans As Integer = MsgBox("您確定要刪除 D:\TEST02 資料夾嗎？", 4 + 32, "Confirm")
        If Mans = 7 Then
            Exit Sub
        Else
            Try
                Me.SendToBack()
                'Microsoft.VisualBasic.FileSystem.RmDir("D:\TEST02")
                'My.Computer.FileSystem.DeleteDirectory("D:\TEST02", DeleteDirectoryOption.DeleteAllContents)
                'My.Computer.FileSystem.DeleteDirectory("D:\TEST02", UIOption.AllDialogs,RecycleOption.DeletePermanently)
                My.Computer.FileSystem.DeleteDirectory("D:\TEST02", UIOption.AllDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                Me.TopMost = True
            Catch ex As Exception
                MsgBox(ex.ToString, 0 + 16, "Error")
                Exit Sub
            End Try
            'MsgBox("資料夾已刪除！", 0 + 64 + 128, "OK")
        End If
    End Sub

    ' 複製資料夾 C:\TEST01 複製為 D:\TEST03
    ' 此方法為多載，
    ' 若括號內 2 個引數，則第一個引數為來源資料夾，第二個引數為資料夾目的資料夾
    ' 若括號內 3 個引數，則第一個引數為來源資料夾，第二個引數為資料夾目的資料夾，第三個引數為是否覆蓋（True 或 False）
    ' 若括號內 4 個引數，則第一個引數為來源資料夾，第二個引數為資料夾目的資料夾，第三個引數為顯示對話方塊，請 User 確認是否要覆蓋（OnlyErrorDialogs 錯誤時顯示或 AllDialogs 永遠顯示），
    ' 第四個引數為按下對話方塊中的 [取消] 時應該執行的動作，FileIO.UICancelOption.DoNothing 不做任何動作， UICancelOption.ThrowException 取消作業（會中斷程式）
    Private Sub B_B8_Click(sender As Object, e As EventArgs) Handles B_B8.Click

        'My.Computer.FileSystem.CopyDirectory("C:\TEST01", "D:\TEST03", True)
        'MsgBox("C:\TEST0 資料夾已複製於 D:\TEST03", 0 + 64 + 128, "OK")

        Me.SendToBack()
        My.Computer.FileSystem.CopyDirectory("C:\TEST01", "D:\TEST03", UIOption.AllDialogs, UICancelOption.DoNothing)
        Me.TopMost = True

    End Sub

    ' 讀出以逗號分隔的順序檔
    Private Sub B_C1_Click(sender As Object, e As EventArgs) Handles B_C1.Click

        ' OpenTextFileReader 方法可開啟 StreamReader 物件，以便從檔案讀取資料
        ' 括號內第一個引數為檔案名稱及其路徑，第二個引數為編碼，編碼方式有 ASCII、UTF-8 等，若指定不正確，會顯示亂碼，此處使用系統預設值
        ' StreamReader 資料流讀取類別的 Read 方法可讀取指定數量的字元，ReadLine 可讀取一整筆的資料（已歸位及換行字元為準）
        ' Peek 方法可傳回下一個可供讀取的字元，如果沒有要讀取的字元，則為 -1，判斷 Peek 方法傳回的字元可偵測檔案指標是否已至檔尾（至檔尾就無需再 ReadLine）
        ' 使用 Strings 類別的 Split 方法可分隔字串並存入陣列
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestA.csv", Encoding.Default)
        RichTextBox1.Text = ""
        T_ITEMNAME1.Text = ""
        T_Qty1.Text = ""
        T_AMT1.Text = ""
        T_SDATE1.Text = ""
        Do While O_file.Peek() >= 0
            RichTextBox1.AppendText(O_file.ReadLine + vbCrLf)
        Loop
        O_file.Close()

        Dim O_file_2 = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestA.csv", Encoding.Default)
        Dim ATempString As String = O_file_2.ReadLine
        Dim Adata() As String = Strings.Split(ATempString, Delimiter:=",")
        T_ITEMNAME1.Text = Adata(0)
        T_Qty1.Text = Adata(1)
        T_AMT1.Text = Adata(2)
        T_SDATE1.Text = Adata(3)
        O_file_2.Close()

        ' 使用 OleDb 讀取文字檔
        Dim MSTRconn_1 As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\TEST01\;Extended Properties='text;HDR=NO;FMT=CSVDelimited'"
        Dim Mstrsql_1 = "Select * from TestA.csv"
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()
        Dim ODataAdapter_1 As New OleDbDataAdapter(Mstrsql_1, Oconn_1)

        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")
        Oconn_1.Close()
        ODataAdapter_1.Dispose()

        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "日期"
        End With
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "#,0.00"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        MsgBox("TestA.csv 的資料已顯示於右方的文字盒 及 DataGridView，" + Chr(13) + Chr(13) + "第一筆資料顯示於右下角的 4 個文字盒內。", 0 + 64, "OK")

    End Sub

    ' 讀出以 TAB 分隔的順序檔
    Private Sub B_C2_Click(sender As Object, e As EventArgs) Handles B_C2.Click
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestB.txt", Encoding.Default)
        RichTextBox1.Text = ""
        T_ITEMNAME1.Text = ""
        T_Qty1.Text = ""
        T_AMT1.Text = ""
        T_SDATE1.Text = ""
        Do While O_file.Peek() >= 0
            RichTextBox1.AppendText(O_file.ReadLine + vbCrLf)
        Loop
        O_file.Close()

        Dim O_file_2 = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestB.txt", Encoding.Default)
        Dim ATempString As String = O_file_2.ReadLine
        Dim Adata() As String = Strings.Split(ATempString, Delimiter:=vbTab)
        T_ITEMNAME1.Text = Adata(0)
        T_Qty1.Text = Adata(1)
        T_AMT1.Text = Adata(2)
        T_SDATE1.Text = Adata(3)
        O_file_2.Close()

        ' 使用 OleDb 讀取文字檔
        ' 在連結字串中指定分割方式無效，必須在 Schema.ini File (Text File Driver) 文字檔驅動組態檔中指定
        Dim MSTRconn_1 As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\TEST01\;Extended Properties='Text;HDR=NO;FMT=TabDelimiter'"
        Dim Mstrsql_1 = "Select * from TestB.txt"
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()
        Dim ODataAdapter_1 As New OleDbDataAdapter(Mstrsql_1, Oconn_1)

        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")
        Oconn_1.Close()
        ODataAdapter_1.Dispose()

        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "日期"
        End With
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "#,0.00"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        MsgBox("TestB.txt 的資料已顯示於右方的文字盒 及 DataGridView，" + Chr(13) + Chr(13) + "第一筆資料顯示於右下角的 4 個文字盒內。", 0 + 64, "OK")
    End Sub

    ' 讀出以 空白 分隔的順序檔
    Private Sub B_C3_Click(sender As Object, e As EventArgs) Handles B_C3.Click
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestC.txt", Encoding.Default)
        RichTextBox1.Text = ""
        T_ITEMNAME1.Text = ""
        T_Qty1.Text = ""
        T_AMT1.Text = ""
        T_SDATE1.Text = ""
        Do While O_file.Peek() >= 0
            RichTextBox1.AppendText(O_file.ReadLine + vbCrLf)
        Loop
        O_file.Close()

        ' 以 Strings.Split 方法分割資料
        'Dim O_file_2 = My.Computer.FileSystem.OpenTextFileReader("C:\TEST01\TestC.txt", Encoding.Default)
        'Dim ATempString As String = O_file_2.ReadLine
        'Dim Adata() As String = Strings.Split(ATempString, Delimiter:=Strings.Space(1))
        'T_ITEMNAME1.Text = Adata(0)
        'T_Qty1.Text = Adata(1)
        'T_AMT1.Text = Adata(2)
        'T_SDATE1.Text = Adata(3)
        'O_file_2.Close()

        ' 以 TextFieldParser 文字欄剖析器分割資料，詳細說明請見 B_C4_Click 程序
        Dim O_file_2 As TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser("C:\TEST01\TestC.txt")
        O_file_2.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        O_file_2.Delimiters = {" "}
        Dim ATempRow() As String
        ATempRow = O_file_2.ReadFields()
        T_ITEMNAME1.Text = ATempRow(0)
        T_Qty1.Text = ATempRow(1)
        T_AMT1.Text = ATempRow(2)
        T_SDATE1.Text = ATempRow(3)
        O_file_2.Close()
        O_file_2.Dispose()

        ' 使用 OleDb 讀取文字檔
        ' 在連結字串中指定分割方式無效，必須在 Schema.ini File (Text File Driver) 文字檔驅動組態檔中指定
        ' 副檔名必須為 txt，若為其他副檔名，例如 prn，則本程式無法讀取，使用 OpenTextFileReader 則可讀取
        Dim MSTRconn_1 As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\TEST01\;Extended Properties='Text;HDR=NO;FMT=Delimited( );CharacterSet=65001'"
        Dim Mstrsql_1 = "Select * from TestC.txt"
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()
        Dim ODataAdapter_1 As New OleDbDataAdapter(Mstrsql_1, Oconn_1)

        Dim ODataSet_1 As DataSet = New DataSet
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")
        Oconn_1.Close()
        ODataAdapter_1.Dispose()

        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "日期"
        End With
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "#,0.00"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        MsgBox("TestC.txt 的資料已顯示於右方的文字盒及 DataGridView，" + Chr(13) + Chr(13) + "第一筆資料顯示於右下角的 4 個文字盒內。", 0 + 64, "OK")
    End Sub

    ' 讀取隨機檔 Random Access File （每一欄長度固定）
    Private Sub B_C4_Click(sender As Object, e As EventArgs) Handles B_C4.Click

        ' 建立文字欄剖析器，以便將每一筆資料的品名及其行號併入豐富文字盒
        Dim O_file As TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser("C:\TEST01\TestD.txt")
        Dim MItemName As String = ""
        RichTextBox1.Text = ""

        ' PeekChars 方法可傳回指定數目的字元，但不移動檔案指標
        ' LineNumber 屬性可傳回目前的行號，如果資料流中已沒有可用的字元，則會傳回 -1
        ' EndOfData 屬性可偵測檔案指標是否已至檔尾
        MItemName = O_file.PeekChars(7)
        RichTextBox1.AppendText(O_file.LineNumber.ToString + Strings.Space(2) + Strings.Trim(MItemName) + vbCrLf)
        While O_file.EndOfData = False
            O_file.ReadLine()
            MItemName = O_file.PeekChars(7)
            If O_file.LineNumber <> -1 Then
                RichTextBox1.AppendText(O_file.LineNumber.ToString + Strings.Space(2) + MItemName + vbCrLf)
            End If
        End While

        ' 關閉文字欄剖析物件並釋放其所使用的資源
        O_file.Close()
        O_file.Dispose()

        ' 清空文字盒
        T_ITEMNAME1.Text = ""
        T_Qty1.Text = ""
        T_AMT1.Text = ""
        T_SDATE1.Text = ""
        T_ITEMNAME2.Text = ""
        T_Qty2.Text = ""
        T_AMT2.Text = ""
        T_SDATE2.Text = ""
        T_ITEMNAME3.Text = ""
        T_Qty3.Text = ""
        T_AMT3.Text = ""
        T_SDATE3.Text = ""

        ' 使用 FileSystem 類別的 OpenTextFieldParser 方法建立 TextFieldParser 物牛，這個物件可剖析結構化文字檔，包括分隔符號分隔的順序檔或固定寬度的隨機檔都可剖析，
        Dim O_file_2 As TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser("C:\TEST01\TestD.txt")
        ' 使用 TextFieldParser 物牛的 TextFieldType 屬性指定欄位分隔型態，FieldType.FixedWidth 固定寬度，FieldType.Delimited 以符號分隔
        O_file_2.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth

        ' 使用 TextFieldParser 物牛的 SetFieldWidths 屬性指定各欄的寬度
        ' TextFieldParser 物牛的 ReadFields 方法可讀取一整筆的資料 並存入陣列
        ' 使用 While 迴圈 逐筆處理，使用 ReadFields 方法分割每一筆資料的各欄，並存入陣列中
        'O_file_2.SetFieldWidths(10, 5, 12, 10)
        O_file_2.SetFieldWidths(7, 5, 12, 10)
        Dim ATempRow() As String
        Dim MRowNo As Integer = 1
        While O_file_2.EndOfData = False
            Try
                ATempRow = O_file_2.ReadFields()
                Select Case MRowNo
                    Case 1
                        T_ITEMNAME1.Text = ATempRow(0)
                        T_Qty1.Text = ATempRow(1)
                        T_AMT1.Text = ATempRow(2)
                        T_SDATE1.Text = ATempRow(3)
                    Case 2
                        T_ITEMNAME2.Text = ATempRow(0)
                        T_Qty2.Text = ATempRow(1)
                        T_AMT2.Text = ATempRow(2)
                        T_SDATE2.Text = ATempRow(3)
                    Case 3
                        T_ITEMNAME3.Text = ATempRow(0)
                        T_Qty3.Text = ATempRow(1)
                        T_AMT3.Text = ATempRow(2)
                        T_SDATE3.Text = ATempRow(3)
                End Select
                MRowNo = MRowNo + 1
            Catch ex As Exception
                MsgBox(ex.ToString, 0 + 16, "Error")
                Exit Sub
            End Try
        End While
        ' 關閉文字欄剖析物件並釋放其所使用的資源
        O_file_2.Close()
        O_file_2.Dispose()

        ' 使用 OleDb 讀取文字檔
        ' Schema.ini File (Text File Driver)  文字檔驅動組態檔，必須以 ANSI 碼 或 ASCII 碼存檔
        ' Microsoft Jet data types資料型態的種類：
        ' Bit、Byte、Short、Long、Currency、Single、Double、DateTime、Text、Memo
        ' FMT 種類 TabDelimited、CSVDelimited、客製化 → Delimited("," )、FixedLength
        ' Code page identifiers 65001 為 UTF-8 編碼、950 為 Big5 編碼、936 為 簡體中文 GB2312 編碼
        Dim MSTRconn_1 As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\TEST01\;Extended Properties='text;HDR=NO;FMT=FixedLength;CharacterSet=65001'"
        Dim Mstrsql_1 = "Select * from TestD.txt"
        Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
        Oconn_1.Open()
        Dim ODataAdapter_1 As New OleDbDataAdapter(Mstrsql_1, Oconn_1)

        ' 依據 DataSet 類別建立新的物件（資料集），以便存放讀出的資料
        Dim ODataSet_1 As DataSet = New DataSet
        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料集，括號內為 資料集 及 資料表的名稱
        ODataAdapter_1.Fill(ODataSet_1, "Table01")
        DataGridView1.DataSource = ODataSet_1.Tables("Table01")
        Oconn_1.Close()
        ODataAdapter_1.Dispose()

        With DataGridView1
            .Columns(0).HeaderText = "品名"
            .Columns(1).HeaderText = "數量"
            .Columns(2).HeaderText = "金額"
            .Columns(3).HeaderText = "日期"
        End With
        With DataGridView1
            .Columns(1).DefaultCellStyle.Format = "#,0"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "#,0.00"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "yyyy/MM/dd"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 24
        Next mtprow

        MsgBox("TestD.txt 每一筆資料的品名及其行號已顯示於右方豐富文字盒，" + Chr(13) + Chr(13) + "全部資料顯示於右下角的各個文字盒及 dataGridView。", 0 + 64, "OK")
    End Sub

    ' 使用 FindInFiles 方法來搜尋檔案
    ' 括號內有4個引數，第一個引數為資料夾名稱、第二個引數為欲搜尋的字料夾、第三個引數為是否區分大小寫、
    ' 第四個引數為是否搜尋子資料夾，FileIO.SearchOption.SearchTopLevelOnly 不搜尋子資料夾（內定），FileIO.SearchOption.SearchAllSubDirectories 要搜尋子資料夾。
    Private Sub B_C5_Click(sender As Object, e As EventArgs) Handles B_C5.Click
        RichTextBox1.Text = ""
        Dim CTemp01 As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        CTemp01 = My.Computer.FileSystem.FindInFiles("C:\TEST01", "香蕉", True, FileIO.SearchOption.SearchTopLevelOnly)
        For Each MFileName In CTemp01
            RichTextBox1.AppendText(MFileName + vbCrLf)
        Next
        MsgBox("C:\TEST01 資料夾內含有『香蕉』二字的檔案已顯示於右方文字盒。", 0 + 64 + 128, "OK")
    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        RichTextBox1.Text = ""

        T_ITEMNAME1.Text = ""
        T_Qty1.Text = ""
        T_AMT1.Text = ""
        T_SDATE1.Text = ""
        T_ITEMNAME2.Text = ""
        T_Qty2.Text = ""
        T_AMT2.Text = ""
        T_SDATE2.Text = ""
        T_ITEMNAME3.Text = ""
        T_Qty3.Text = ""
        T_AMT3.Text = ""
        T_SDATE3.Text = ""

        DataGridView1.DataSource = Nothing
    End Sub

    ' 載入本表單時，寫入Schema.ini File (Text File Driver) 文字檔驅動組態檔， 以利後續 OleDb 程式讀取文字檔
    ' Schema.ini 必須以 ANSI 碼存檔，而且須存入與欲處理的文字檔同一資料夾
    ' 注意 Width，中文一個字為 2 byte 與 OpenTextFieldParser 的算法不同，非常麻煩
    Private Sub F_FileSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists("C:\TEST01") = False Then
            My.Computer.FileSystem.CreateDirectory("C:\TEST01")
        End If
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEST01\Schema.ini", False, Encoding.ASCII)
        O_file.WriteLine("[TestD.txt]")
        O_file.WriteLine("Format = FixedLength")
        O_file.WriteLine("ColNameHeader = False")
        O_file.WriteLine("MaxScanRows = 0")
        O_file.WriteLine("DateTimeFormat = yyyy/mm/dd")
        O_file.WriteLine("Col1=F1 Text Width 10")
        O_file.WriteLine("Col2=F2 Integer Width 5")
        O_file.WriteLine("Col3=F3 Double Width 12")
        O_file.WriteLine("Col4=F4 Text Width 13")
        O_file.WriteLine("")
        O_file.WriteLine("[TestB.txt]")
        O_file.WriteLine("Format = TabDelimited")
        O_file.WriteLine("ColNameHeader = False")
        O_file.WriteLine("")
        O_file.WriteLine("[TestC.txt]")
        O_file.WriteLine("Format = Delimited( )")
        O_file.WriteLine("ColNameHeader = False")
        O_file.Close()
    End Sub
End Class