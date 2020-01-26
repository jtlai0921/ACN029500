Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Collections.Generic

Public Class F_Query_3

    ' 宣告清單集合，以便儲存節點文字
    Public List01 As New List(Of String)
    ' 宣告變數，以便儲存被選取節點之數量 
    Public MselectNo As Integer = 0
    ' 宣告變數，以便儲存相同節點之數量 
    Public MsameitemNo As Integer = 0
    ' 宣告變數，以便儲存被勾選節點之數量 
    Public McheckNo As Integer = 0

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' *****************************************************************************************************************
    ' 選取之後的事件，將被敲選節點的名稱及文字顯示於文字盒
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TextBox1.Text = TreeView1.SelectedNode.Name
        TextBox2.Text = TreeView1.SelectedNode.Text
        ' 變更前景色及背景色
        ' TreeView1.SelectedNode.BackColor = Color.DarkRed
        ' TreeView1.SelectedNode.ForeColor = Color.White
    End Sub

    ' 展開 TreeView，並使用 GetNodeCount 方法傳回節點數量
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        TreeView1.ExpandAll()
        On Error Resume Next
        TextBox3.Text = TreeView1.GetNodeCount(True)
        TextBox4.Text = TreeView1.Nodes(0).Nodes(1).GetNodeCount(True)
    End Sub

    ' 收縮 TreeView
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        TreeView1.CollapseAll()
    End Sub

    ' 載入本表單時，設定 TreeView 的縮排點數及項目高度
    Private Sub F_Query_3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.Indent = 20
        TreeView1.ItemHeight = 30

        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()
    End Sub

    ' 增加節點
    Private Sub B_03_Click(sender As Object, e As EventArgs) Handles B_03.Click
        If TreeView1.Nodes.Count = 0 Then
            MsgBox("Sorry, 全部節點已移除, 無法新增！", 0 + 16, "Error")
            Exit Sub
        End If
        On Error Resume Next

        ' 第一段， 在次節點增加『處級』單位 ************************************************************
        ' 先判斷欲增加之節點是否已存在
        Dim Mitem01 As String = "營業處"

        ' 先判斷根節點文字與新增文字是否相同
        MsameitemNo = 0
        If TreeView1.Nodes(0).Text = Mitem01 Then
            MsameitemNo = 1
        End If

        ' 使用遞迴呼叫程序，判斷每一層級的節點文字是否與新增文字相同，括號內有兩個參數，前者為根節點，後者為欲新增之節點文字
        'CheckNode(TreeView1.TopNode, Mitem01)
        CheckNode(TreeView1.Nodes(0), Mitem01)
        If MsameitemNo > 0 Then
            MsgBox("相同的節點文字已存在，" + Chr(13) + Chr(13) + "不能新增！", 0 + 16, "Error")
            Exit Sub
        End If
        TreeView1.Nodes(0).Nodes.Add(New TreeNode(Mitem01))
        TreeView1.Refresh()

        ' 第二段， 次次節點第二項增加『部級』單位  ************************************************************
        ' 先判斷欲增加之節點是否已存在
        Mitem01 = "企劃部"

        ' 先判斷根節點文字與新增文字是否相同
        MsameitemNo = 0
        If TreeView1.Nodes(0).Text = Mitem01 Then
            MsameitemNo = 1
        End If

        ' 使用遞迴呼叫程序，判斷每一層級的節點文字是否與新增文字相同，括號內有兩個參數，前者為根節點，後者為欲新增之節點文字
        'CheckNode(TreeView1.TopNode, Mitem01)
        CheckNode(TreeView1.Nodes(0), Mitem01)
        If MsameitemNo > 0 Then
            MsgBox("相同的節點文字已存在，" + Chr(13) + Chr(13) + "不能新增！", 0 + 16, "Error")
            Exit Sub
        End If
        TreeView1.Nodes(0).Nodes(1).Nodes.Add(New TreeNode(Mitem01))
        TreeView1.Refresh()

        ' 重算節點數
        TextBox3.Text = TreeView1.GetNodeCount(True)
        TextBox4.Text = TreeView1.Nodes(0).Nodes(1).GetNodeCount(True)
    End Sub

    ' 判斷每一層級的節點之文字是否與新增之值相同，若相同，則增加 MselectNo 變數之值
    ' 本程序為遞迴呼叫程序，所謂遞迴 Recursion 就是一個 Procedure 或 Function 循環呼叫自己本身
    ' 使用 For Each 迴圈判斷同一層節點的每一項目文字是否與新增文字相同
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub CheckNode(TempNode As TreeNode, ByVal Mcheck As String)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Text = Mcheck Then
                MsameitemNo = MsameitemNo + 1
            End If
            If TempNode.Nodes.Count > 0 Then CheckNode(O_node, Mcheck)
        Next
    End Sub

    ' 移除最後被敲選的節點，移除前先警告
    Private Sub B_04_Click(sender As Object, e As EventArgs) Handles B_04.Click

        ' 全部節點已移除
        If TreeView1.Nodes.Count = 0 Then
            MsgBox("Sorry, 已無節點可移除", 0 + 16, "Error")
            Exit Sub
        End If

        ' 先判斷是否已選定某一節點
        MselectNo = 0
        If TreeView1.Nodes(0).IsSelected = True Then
            MselectNo = 1
        End If
        ' 使用遞迴呼叫程序（括號內傳遞根節點，以便判斷選定狀態）
        DeleteNode(TreeView1.Nodes(0))
        If MselectNo = 0 Then
            MsgBox("請先選定欲移除的節點", 0 + 16, "Error")
            Exit Sub
        End If

        Dim MdeleteItem As String = TreeView1.SelectedNode.Text
        Dim Mcheck1 = MsgBox("您確定要移除節點『" + MdeleteItem + "』嗎？", 4 + 32 + 256, "Confirm")
        If Mcheck1 = 6 Then
            TreeView1.SelectedNode.Remove()
            TextBox3.Text = ""
            TextBox4.Text = ""
            TreeView1.Refresh()
        End If

    End Sub

    ' 判斷每一層級的節點之選取狀態，若已被敲選，則增加 MselectNo 變數之值
    ' 本程序為遞迴呼叫程序，所謂遞迴 Recursion 就是一個 Procedure 或 Function 呼叫自己本身
    ' 使用 For Each 迴圈判斷同一層節點的每一項目是否被選取
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub DeleteNode(TempNode As TreeNode)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.IsSelected = True Then
                MselectNo = MselectNo + 1
            End If
            If TempNode.Nodes.Count > 0 Then DeleteNode(O_node)
        Next
    End Sub

    ' 列出節點文字，先將節點文字存入清單集合 List01，再顯示於 RichTextBox1 豐富文字盒
    Private Sub B_05_Click(sender As Object, e As EventArgs) Handles B_05.Click
        ' 先清除清單集合 List01，以便重複使用
        List01.Clear()

        ' 先將根節點文字存入清單集合 List01
        List01.Add(TreeView1.Nodes(0).Text)

        ' 使用遞迴呼叫程序（括號內參數傳遞根節點）
        'GetAllChildNodes(TreeView1.TopNode)
        GetAllChildNodes(TreeView1.Nodes(0))

        ' 使用遞迴呼叫程序（括號內傳遞次節點第二項，可列出該節點第二項的全部項目之文字）
        'GetAllChildNodes(TreeView1.Nodes(0).Nodes(1))

        ' 將清單集合 List01 的內容顯示於豐富文字盒
        RichTextBox1.Clear()
        Dim Mstop As Integer = List01.Count - 1
        For Mcou = 0 To Mstop Step 1
            RichTextBox1.AppendText(List01(Mcou) + Chr(13))
        Next
    End Sub

    ' 將節點文字存入清單集合 List01
    ' 本程序為遞迴呼叫程序，所謂遞迴 Recursion 就是一個 Procedure 或 Function 呼叫自己本身
    ' 使用 For Each 迴圈逐一將同一層節點的每一項目文字存入清單集合 List01
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub GetAllChildNodes(TempNode As TreeNode)
        For Each O_node As TreeNode In TempNode.Nodes
            List01.Add(O_node.Text)
            If TempNode.Nodes.Count > 0 Then GetAllChildNodes(O_node)
        Next
    End Sub

    ' 尋找特定節點文字，先將節點文字存入清單集合 List01，再使用 Contains 方法找出特定字串是否存在於 List01 之中
    Private Sub B_06_Click(sender As Object, e As EventArgs) Handles B_06.Click
        List01.Clear()
        List01.Add(TreeView1.Nodes(0).Text)
        ' 遞迴呼叫程序（括號內傳遞根節點，可列出全部節點文字）
        GetAllChildNodes(TreeView1.TopNode)

        Dim Msearch As String = "會計部"
        If List01.Contains(Msearch) = True Then
            MsgBox(Msearch + " 找到了", 0 + 64, "尋找結果")
        Else
            MsgBox(Msearch + " 沒找到", 0 + 16, "尋找結果")
        End If
    End Sub

    ' 離開
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

    ' 重設
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        L_dept.Text = ""
        RichTextBox1.Clear()
        ' 取消選取狀態
        TreeView1.SelectedNode = Nothing
    End Sub

    ' 檢查已被勾選之節點數
    Private Sub B_07_Click(sender As Object, e As EventArgs) Handles B_07.Click
        TreeView1.SelectedNode = Nothing
        ' 先判斷根節點之勾選狀態
        McheckNo = 0
        If TreeView1.Nodes(0).Checked = True Then
            McheckNo = 1
        End If

        ' 使用遞迴呼叫程序，判斷每一層節點之各項目的勾選狀態，括號內參數為為根節點
        GetCheckNodes(TreeView1.Nodes(0))
        MsgBox("已勾選項數： " + McheckNo.ToString, 0 + 64, "檢查結果")

    End Sub

    ' 將被勾選節點之數量存入變數 McheckNo
    ' 本程序為遞迴呼叫程序，所謂遞迴 Recursion 就是一個 Procedure 或 Function 呼叫自己本身
    ' 使用 For Each 迴圈逐一判斷同一層節點的每一項目的勾選狀態
    ' TempNode.Nodes.Count > 0 表示下一層節點的項數大於零（亦即還有下一層節點），故繼續呼叫本程序
    Private Sub GetCheckNodes(TempNode As TreeNode)
        For Each O_node As TreeNode In TempNode.Nodes
            If O_node.Checked = True Then
                McheckNo = McheckNo + 1
            End If
            If TempNode.Nodes.Count > 0 Then GetCheckNodes(O_node)
        Next
    End Sub

    ' 修改被選節點的文字
    Private Sub B_Modify_Click(sender As Object, e As EventArgs) Handles B_Modify.Click
        Me.TopMost = False
        Dim MnewString As String = Interaction.InputBox("請輸入新的名稱，" + Chr(13) + Chr(13) + "以便取代作用節點之文字", "Input")
        If MnewString = Nothing Then
            Exit Sub
        End If
        Try
            TreeView1.SelectedNode.Text = MnewString
        Catch ex As Exception
            MsgBox("請先敲選欲修改的節點！", 0 + 16, "Error")
            Exit Sub
        End Try
    End Sub

    ' 查出敲選節點之部門人數及其平均薪津
    Private Sub B_Query_Click(sender As Object, e As EventArgs) Handles B_Query.Click
        TextBox5.Text = ""
        TextBox6.Text = ""
        L_dept.Text = ""

        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"
        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)
        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()
        Dim Mdept As String = ""
        Try
            Mdept = TreeView1.SelectedNode.Text
        Catch ex As Exception
            MsgBox("請先敲選欲查詢的節點！", 0 + 16, "Error")
            Exit Sub
        End Try
        Dim Msqlstr_1 As String = "Select Sum(qty) as qty,Sum(wages) as wages From SALARY Where filedate='201412' and dept_name='" + Mdept + "'"

        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_1），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_1 As New SqlCommand(Msqlstr_1, Ocn_1)

        ' 使用 SqlCommand 的 ExecuteReader 方法將讀出的資料存入 SqlDataReader 資料讀取物件
        ' ExecuteReader 方法適用於不涉資料增刪修的單純讀取工作
        Dim Odataread_1 As SqlDataReader
        Odataread_1 = Ocmd_1.ExecuteReader()

        ' 讀出資料並存入變數
        Dim MtotalQty As Integer = 0
        Dim MtotalWages As Double = 0
        Do While Odataread_1.Read() = True
            If IsDBNull(Odataread_1.Item(0)) = True Then
                'MtotalQty = 0
                'MtotalWages = 0
                TextBox5.Text = 0
                TextBox6.Text = 0
                L_dept.Text = "請敲選部門（非處級單位）"
            Else
                MtotalQty = Odataread_1.Item(0)
                MtotalWages = Odataread_1.Item(1)
                TextBox5.Text = Format(MtotalQty, "#,0")
                TextBox6.Text = Format(Math.Round(MtotalWages / MtotalQty, 0), "#,0")
                L_dept.Text = Mdept
            End If
        Loop

        ' 關閉資料處理相關物件
        Odataread_1.Close()
        Ocmd_1.Cancel()
        Ocn_1.Close()
        Ocn_1.Dispose()
        MsgBox("資料已查出！" + Chr(13) + Chr(10) + "請見右上角文字盒。", 0 + 64, "OK")

    End Sub

End Class