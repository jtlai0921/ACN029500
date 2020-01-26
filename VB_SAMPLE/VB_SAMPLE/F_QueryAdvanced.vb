Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Public Class F_QueryAdvanced
    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""
    ' 宣告二維陣列 Alevel（18 列 4 行），以便儲存 User 所設定的年資層
    Public Alevel(17, 3) As String
    ' 宣告陣列 Acount，以便儲存年資層的數量
    Public Acount(0) As Integer



    ' ********************************************************************************************************************************
    ' 將清單1的選取項目加入清單2
    Private Sub B_Select_Click(sender As Object, e As EventArgs) Handles B_Select.Click

        ' 本功能只允許 User 選取單一的日期，故 ListBox1 的 SelectionMode 以設為 one
        ' ListBox 的 SelectedItem 可傳回單一的被選取項目之名稱，SelectedItems 則可傳被選取項目的集合，該集合內包含清單上所有被選取項目之名稱
        ListBox2.Items.Clear()
        ListBox2.Items.Add(ListBox1.SelectedItem)
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
            'Me.Hide()
            Me.Dispose()
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
        T_DEPTCODE.Text = ""
        L_DEPTNAME.Text = ""
        T_TITLE.Text = ""
        T_GRADE.Text = ""

        ' 清空年資層
        T_Y1B.Text = ""
        T_Y2A.Text = ""
        T_Y2B.Text = ""
        T_Y3A.Text = ""
        T_Y3B.Text = ""
        T_Y4A.Text = ""
        T_Y4B.Text = ""
        T_Y5A.Text = ""
        T_Y5B.Text = ""
        T_Y6A.Text = ""
        T_Y6B.Text = ""
        T_Y7A.Text = ""
        T_Y7B.Text = ""
        T_Y8A.Text = ""
        T_Y8B.Text = ""
        T_Y9A.Text = ""
        T_Y9B.Text = ""
        T_Y10A.Text = ""
        T_Y10B.Text = ""
        T_Y11A.Text = ""
        T_Y11B.Text = ""
        T_Y12A.Text = ""
        T_Y12B.Text = ""
        T_Y13A.Text = ""
        T_Y13B.Text = ""
        T_Y14A.Text = ""
        T_Y14B.Text = ""
        T_Y15A.Text = ""
        T_Y15B.Text = ""
        T_Y16A.Text = ""
        T_Y16B.Text = ""
        T_Y17A.Text = ""
        T_Y17B.Text = ""
        T_Y18A.Text = ""
        T_Y18B.Text = ""

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

    ' 設定 A 類年資層
    Private Sub B_KindA_Click(sender As Object, e As EventArgs) Handles B_KindA.Click
        T_Y1B.Text = "1"
        T_Y2A.Text = "1"
        T_Y2B.Text = "3"
        T_Y3A.Text = "3"
        T_Y3B.Text = "5"
        T_Y4A.Text = "5"
        T_Y4B.Text = "7"
        T_Y5A.Text = "7"
        T_Y5B.Text = "10"
        T_Y6A.Text = "10"
        T_Y6B.Text = "15"
        T_Y7A.Text = "15"
        T_Y7B.Text = "20"
        T_Y8A.Text = "20"
        T_Y8B.Text = "25"
        T_Y9A.Text = "25"
        T_Y9B.Text = "60"
        T_Y10A.Text = ""
        T_Y10B.Text = ""
        T_Y11A.Text = ""
        T_Y11B.Text = ""
        T_Y12A.Text = ""
        T_Y12B.Text = ""
        T_Y13A.Text = ""
        T_Y13B.Text = ""
        T_Y14A.Text = ""
        T_Y14B.Text = ""
        T_Y15A.Text = ""
        T_Y15B.Text = ""
        T_Y16A.Text = ""
        T_Y16B.Text = ""
        T_Y17A.Text = ""
        T_Y17B.Text = ""
        T_Y18A.Text = ""
        T_Y18B.Text = ""
    End Sub

    ' 設定 B 類年資層
    Private Sub B_KindB_Click(sender As Object, e As EventArgs) Handles B_KindB.Click
        T_Y1B.Text = "3"
        T_Y2A.Text = "3"
        T_Y2B.Text = "5"
        T_Y3A.Text = "5"
        T_Y3B.Text = "10"
        T_Y4A.Text = "10"
        T_Y4B.Text = "15"
        T_Y5A.Text = "15"
        T_Y5B.Text = "20"
        T_Y6A.Text = "20"
        T_Y6B.Text = "25"
        T_Y7A.Text = "25"
        T_Y7B.Text = "60"
        T_Y8A.Text = ""
        T_Y8B.Text = ""
        T_Y9A.Text = ""
        T_Y9B.Text = ""
        T_Y10A.Text = ""
        T_Y10B.Text = ""
        T_Y11A.Text = ""
        T_Y11B.Text = ""
        T_Y12A.Text = ""
        T_Y12B.Text = ""
        T_Y13A.Text = ""
        T_Y13B.Text = ""
        T_Y14A.Text = ""
        T_Y14B.Text = ""
        T_Y15A.Text = ""
        T_Y15B.Text = ""
        T_Y16A.Text = ""
        T_Y16B.Text = ""
        T_Y17A.Text = ""
        T_Y17B.Text = ""
        T_Y18A.Text = ""
        T_Y18B.Text = ""
    End Sub

    ' 設定 C 類年資層
    Private Sub B_KindC_Click(sender As Object, e As EventArgs) Handles B_KindC.Click
        T_Y1B.Text = "5"
        T_Y2A.Text = "5"
        T_Y2B.Text = "10"
        T_Y3A.Text = "10"
        T_Y3B.Text = "20"
        T_Y4A.Text = "20"
        T_Y4B.Text = "30"
        T_Y5A.Text = "30"
        T_Y5B.Text = "60"
        T_Y6A.Text = ""
        T_Y6B.Text = ""
        T_Y7A.Text = ""
        T_Y7B.Text = ""
        T_Y8A.Text = ""
        T_Y8B.Text = ""
        T_Y9A.Text = ""
        T_Y9B.Text = ""
        T_Y10A.Text = ""
        T_Y10B.Text = ""
        T_Y11A.Text = ""
        T_Y11B.Text = ""
        T_Y12A.Text = ""
        T_Y12B.Text = ""
        T_Y13A.Text = ""
        T_Y13B.Text = ""
        T_Y14A.Text = ""
        T_Y14B.Text = ""
        T_Y15A.Text = ""
        T_Y15B.Text = ""
        T_Y16A.Text = ""
        T_Y16B.Text = ""
        T_Y17A.Text = ""
        T_Y17B.Text = ""
        T_Y18A.Text = ""
        T_Y18B.Text = ""
    End Sub

    ' 設定 D 類年資層
    Private Sub B_KindD_Click(sender As Object, e As EventArgs) Handles B_KindD.Click
        T_Y1B.Text = "1"
        T_Y2A.Text = "1"
        T_Y2B.Text = "2"
        T_Y3A.Text = "2"
        T_Y3B.Text = "3"
        T_Y4A.Text = "3"
        T_Y4B.Text = "4"
        T_Y5A.Text = "4"
        T_Y5B.Text = "5"
        T_Y6A.Text = "5"
        T_Y6B.Text = "6"
        T_Y7A.Text = "6"
        T_Y7B.Text = "7"
        T_Y8A.Text = "7"
        T_Y8B.Text = "8"
        T_Y9A.Text = "8"
        T_Y9B.Text = "9"
        T_Y10A.Text = "9"
        T_Y10B.Text = "10"
        T_Y11A.Text = "10"
        T_Y11B.Text = "11"
        T_Y12A.Text = "11"
        T_Y12B.Text = "12"
        T_Y13A.Text = "12"
        T_Y13B.Text = "13"
        T_Y14A.Text = "13"
        T_Y14B.Text = "14"
        T_Y15A.Text = "14"
        T_Y15B.Text = "15"
        T_Y16A.Text = "15"
        T_Y16B.Text = "60"
        T_Y17A.Text = ""
        T_Y17B.Text = ""
        T_Y18A.Text = ""
        T_Y18B.Text = ""
    End Sub

    ' 載入本表單
    Private Sub F_QueryAdvanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 讀取 SQL Server 登入資訊
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 第一段，讀出唯一日期，作為 ListBox1 清單控制項的項目 *********************************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Msqlstr_1 As String = "Select distinct filedate From SALARY"
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入 SqlDataReader 資料讀取器
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_1 As SqlDataReader
        Odataread_1 = Ocmd_1.ExecuteReader()

        ' 將讀取器的資料存入 List 清單集合
        ' 以清單集合取代陣列，效能較佳，程式較簡潔（無需宣告大小）
        ' DataReader 的 Item 屬性可傳回讀取器中某一行的資料，括號內可為欄位順序（由0起算）或欄名
        Dim List01 As New List(Of String)
        Do While Odataread_1.Read() = True
            List01.Add(Odataread_1.Item(0))
        Loop

        ' 清單集合遞增排序再予反轉，以便遞減排序日期資料
        List01.Sort()
        List01.Reverse()

        ' 將清單集合的資料併入 ListBox 清單控制項
        ListBox1.Items.Clear()
        Dim MTotalItems As Integer = List01.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            ListBox1.Items.Add(List01.Item(Mcou))
        Next

        ' 關閉 存取資料庫的相關物件 
        Ocmd_1.Dispose()
        Odataread_1.Close()
        Odataread_1.Dispose()

        ' 第二段，讀出部門代號，作為下拉式選單的選項 *********************************************************
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_2），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Msqlstr_2 As String = "Select * From TAB_DEPT"
        Dim Ocmd_2 As New SqlCommand(Msqlstr_2, Ocn_1)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入 SqlDataReader 資料讀取器
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_2 As SqlDataReader
        Odataread_2 = Ocmd_2.ExecuteReader()

        ' 將讀取器的資料存入 List 清單集合，先使用 Clear 方法清除清單所有元素，以便重複使用
        ' 以清單集合取代陣列，效能較佳，程式較簡潔（無需宣告大小）
        ' DataReader 的 Item 屬性可傳回讀取器中某一行的資料，括號內可為欄位順序（由0起算）或欄名
        ' 務必使用 Trim 方法 去除多餘的空白
        List01.Clear()
        Do While Odataread_2.Read() = True
            List01.Add(Strings.Trim(Odataread_2.Item(0)) + Strings.Trim(Odataread_2.Item(1)))
        Loop

        ' 清單集合遞增排
        List01.Sort()

        ' 將清單集合的資料併入 文字盒
        T_DEPTCODE.Items.Clear()
        MTotalItems = List01.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            T_DEPTCODE.Items.Add(List01.Item(Mcou))
        Next

        ' 關閉 存取資料庫的相關物件
        Ocmd_2.Dispose()
        Odataread_2.Close()
        Odataread_2.Dispose()

        ' 第三段，讀出職稱，作為下拉式選單的選項 *********************************************************
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_3），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Msqlstr_3 As String = "Select title From TAB_TITLE"
        Dim Ocmd_3 As New SqlCommand(Msqlstr_3, Ocn_1)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入 SqlDataReader 資料讀取器
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_3 As SqlDataReader
        Odataread_3 = Ocmd_3.ExecuteReader()

        ' 將讀取器的資料存入 List 清單集合，先使用 Clear 方法清除清單所有元素，以便重複使用
        ' 以清單集合取代陣列，效能較佳，程式較簡潔（無需宣告大小）
        ' DataReader 的 Item 屬性可傳回讀取器中某一行的資料，括號內可為欄位順序（由0起算）或欄名
        ' 務必使用 Trim 方法 去除多餘的空白
        List01.Clear()
        Do While Odataread_3.Read() = True
            List01.Add(Strings.Trim(Odataread_3.Item(0)))
        Loop

        ' 清單集合遞增排
        List01.Sort()

        ' 將清單集合的資料併入 文字盒
        T_TITLE.Items.Clear()
        MTotalItems = List01.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            T_TITLE.Items.Add(List01.Item(Mcou))
        Next

        ' 關閉 存取資料庫的相關物件
        Ocmd_3.Dispose()
        Odataread_3.Close()
        Odataread_3.Dispose()

        ' 第四段，讀出等級，作為下拉式選單的選項 *********************************************************
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_4），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Msqlstr_4 As String = "Select * From TAB_GRADE"
        Dim Ocmd_4 As New SqlCommand(Msqlstr_4, Ocn_1)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入 SqlDataReader 資料讀取器
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_4 As SqlDataReader
        Odataread_4 = Ocmd_4.ExecuteReader()

        ' 將讀取器的資料存入 List 清單集合，先使用 Clear 方法清除清單所有元素，以便重複使用
        ' 以清單集合取代陣列，效能較佳，程式較簡潔（無需宣告大小）
        ' DataReader 的 Item 屬性可傳回讀取器中某一行的資料，括號內可為欄位順序（由0起算）或欄名
        ' 務必使用 Trim 方法 去除多餘的空白
        List01.Clear()
        Do While Odataread_4.Read() = True
            List01.Add(Strings.Trim(Odataread_4.Item(0)))
        Loop

        ' 清單集合遞增排
        List01.Sort()

        ' 將清單集合的資料併入 文字盒
        T_GRADE.Items.Clear()
        MTotalItems = List01.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            T_GRADE.Items.Add(List01.Item(Mcou))
        Next

        ' 關閉 存取資料庫的相關物件
        Ocmd_4.Dispose()
        Odataread_4.Close()
        Odataread_4.Dispose()
        Ocn_1.Close()
        Ocn_1.Dispose()
    End Sub

    ' 查詢
    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click

        ' 檢查年資層的設定是否合理（起始年資不能大於終止年資）  程式待增 ****************************************************************

        ' 先使用 Items.Count 屬性檢查是否有日期（至少需要一個）
        If ListBox2.Items.Count = 0 Then
            MsgBox("Sorry, 尚未選取日期！" + Chr(13) + Chr(10) + "請先敲選日期一個", 0 + 16, "Error")
            Exit Sub
        End If

        ' 將 User 所指定的查詢條件存入變數 MMM，以便組合 SQL 指令
        Dim MMM As String = ""
        If T_DEPTCODE.Text <> "" Then
            MMM = "dept_code='" + T_DEPTCODE.Text + "'"
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
            MTempDate = "'" + Itemname + "'"
        Next
        If MMM = "" Then
            MMM = "filedate=" + MTempDate
        Else
            MMM = MMM + " and filedate=" + MTempDate
        End If

        ' 組合 SQL 指令
        ' 再將 SQL 指令存入 Tag，供 F_QueryAdvanceResult.vb 之程式使用，以便據以抓出相關資料
        Dim MTempString As String = ""
        MTempString = "Select staff_no,staff_name,staff_sex,dept_code,dept_name,titlecode,title,grade,qty,seniority,years,wages,allowance,meal,filedate From SALARY Where " + MMM
        Me.Tag = MTempString

        ' 將年資層存入陣列
        ' 變數 Mcount 儲存年資層的數量
        ' 將判斷式列於無限迴圈 Do Loop 之中，只要某一年資層未的設定就離開迴圈，以便強迫 User 必須連續輸入，中間不得空白
        ' 先使用巢狀迴圈設定每一元素之值
        For Mrow = 0 To 17 Step 1
            For Mcol = 0 To 3 Step 1
                Alevel(Mrow, Mcol) = ""
            Next
        Next

        Dim Mcount As Integer = 0
        Do

            If Strings.Trim(T_Y1B.Text) = "" Then
                Exit Do
            Else
                Alevel(0, 0) = "A"
                Alevel(0, 1) = "0～" + Strings.Trim(T_Y1B.Text)
                Alevel(0, 2) = "0"
                Alevel(0, 3) = Strings.Trim(T_Y1B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y2A.Text) = "" Then
                Exit Do
            Else
                Alevel(1, 0) = "B"
                Alevel(1, 1) = Strings.Trim(T_Y2A.Text) + "～" + Strings.Trim(T_Y2B.Text)
                Alevel(1, 2) = Strings.Trim(T_Y2A.Text)
                Alevel(1, 3) = Strings.Trim(T_Y2B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y3A.Text) = "" Then
                Exit Do
            Else
                Alevel(2, 0) = "C"
                Alevel(2, 1) = Strings.Trim(T_Y3A.Text) + "～" + Strings.Trim(T_Y3B.Text)
                Alevel(2, 2) = Strings.Trim(T_Y3A.Text)
                Alevel(2, 3) = Strings.Trim(T_Y3B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y4A.Text) = "" Then
                Exit Do
            Else
                Alevel(3, 0) = "D"
                Alevel(3, 1) = Strings.Trim(T_Y4A.Text) + "～" + Strings.Trim(T_Y4B.Text)
                Alevel(3, 2) = Strings.Trim(T_Y4A.Text)
                Alevel(3, 3) = Strings.Trim(T_Y4B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y5A.Text) = "" Then
                Exit Do
            Else
                Alevel(4, 0) = "E"
                Alevel(4, 1) = Strings.Trim(T_Y5A.Text) + "～" + Strings.Trim(T_Y5B.Text)
                Alevel(4, 2) = Strings.Trim(T_Y5A.Text)
                Alevel(4, 3) = Strings.Trim(T_Y5B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y6A.Text) = "" Then
                Exit Do
            Else
                Alevel(5, 0) = "F"
                Alevel(5, 1) = Strings.Trim(T_Y6A.Text) + "～" + Strings.Trim(T_Y6B.Text)
                Alevel(5, 2) = Strings.Trim(T_Y6A.Text)
                Alevel(5, 3) = Strings.Trim(T_Y6B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y7A.Text) = "" Then
                Exit Do
            Else
                Alevel(6, 0) = "G"
                Alevel(6, 1) = Strings.Trim(T_Y7A.Text) + "～" + Strings.Trim(T_Y7B.Text)
                Alevel(6, 2) = Strings.Trim(T_Y7A.Text)
                Alevel(6, 3) = Strings.Trim(T_Y7B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y8A.Text) = "" Then
                Exit Do
            Else
                Alevel(7, 0) = "H"
                Alevel(7, 1) = Strings.Trim(T_Y8A.Text) + "～" + Strings.Trim(T_Y8B.Text)
                Alevel(7, 2) = Strings.Trim(T_Y8A.Text)
                Alevel(7, 3) = Strings.Trim(T_Y8B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y9A.Text) = "" Then
                Exit Do
            Else
                Alevel(8, 0) = "I"
                Alevel(8, 1) = Strings.Trim(T_Y9A.Text) + "～" + Strings.Trim(T_Y9B.Text)
                Alevel(8, 2) = Strings.Trim(T_Y9A.Text)
                Alevel(8, 3) = Strings.Trim(T_Y9B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y10A.Text) = "" Then
                Exit Do
            Else
                Alevel(9, 0) = "J"
                Alevel(9, 1) = Strings.Trim(T_Y10A.Text) + "～" + Strings.Trim(T_Y10B.Text)
                Alevel(9, 2) = Strings.Trim(T_Y10A.Text)
                Alevel(9, 3) = Strings.Trim(T_Y10B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y11A.Text) = "" Then
                Exit Do
            Else
                Alevel(10, 0) = "K"
                Alevel(10, 1) = Strings.Trim(T_Y11A.Text) + "～" + Strings.Trim(T_Y11B.Text)
                Alevel(10, 2) = Strings.Trim(T_Y11A.Text)
                Alevel(10, 3) = Strings.Trim(T_Y11B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y12A.Text) = "" Then
                Exit Do
            Else
                Alevel(11, 0) = "L"
                Alevel(11, 1) = Strings.Trim(T_Y12A.Text) + "～" + Strings.Trim(T_Y12B.Text)
                Alevel(11, 2) = Strings.Trim(T_Y12A.Text)
                Alevel(11, 3) = Strings.Trim(T_Y12B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y13A.Text) = "" Then
                Exit Do
            Else
                Alevel(12, 0) = "M"
                Alevel(12, 1) = Strings.Trim(T_Y13A.Text) + "～" + Strings.Trim(T_Y13B.Text)
                Alevel(12, 2) = Strings.Trim(T_Y13A.Text)
                Alevel(12, 3) = Strings.Trim(T_Y13B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y14A.Text) = "" Then
                Exit Do
            Else
                Alevel(13, 0) = "N"
                Alevel(13, 1) = Strings.Trim(T_Y14A.Text) + "～" + Strings.Trim(T_Y14B.Text)
                Alevel(13, 2) = Strings.Trim(T_Y14A.Text)
                Alevel(13, 3) = Strings.Trim(T_Y14B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y15A.Text) = "" Then
                Exit Do
            Else
                Alevel(14, 0) = "O"
                Alevel(14, 1) = Strings.Trim(T_Y15A.Text) + "～" + Strings.Trim(T_Y15B.Text)
                Alevel(14, 2) = Strings.Trim(T_Y15A.Text)
                Alevel(14, 3) = Strings.Trim(T_Y15B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y16A.Text) = "" Then
                Exit Do
            Else
                Alevel(15, 0) = "P"
                Alevel(15, 1) = Strings.Trim(T_Y16A.Text) + "～" + Strings.Trim(T_Y16B.Text)
                Alevel(15, 2) = Strings.Trim(T_Y16A.Text)
                Alevel(15, 3) = Strings.Trim(T_Y16B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y17A.Text) = "" Then
                Exit Do
            Else
                Alevel(16, 0) = "Q"
                Alevel(16, 1) = Strings.Trim(T_Y17A.Text) + "～" + Strings.Trim(T_Y17B.Text)
                Alevel(16, 2) = Strings.Trim(T_Y17A.Text)
                Alevel(16, 3) = Strings.Trim(T_Y17B.Text)
                Mcount += 1
            End If

            If Strings.Trim(T_Y18A.Text) = "" Then
                Exit Do
            Else
                Alevel(17, 0) = "R"
                Alevel(17, 1) = Strings.Trim(T_Y18A.Text) + "～" + Strings.Trim(T_Y18B.Text)
                Alevel(17, 2) = Strings.Trim(T_Y18A.Text)
                Alevel(17, 3) = Strings.Trim(T_Y18B.Text)
                Mcount += 1
            End If

            Exit Do
        Loop
        Acount(0) = Mcount
        Me.Hide()
        F_QueryAdvanceResult.Show()

    End Sub

End Class