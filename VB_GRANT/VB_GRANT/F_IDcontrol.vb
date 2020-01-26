Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class F_IDcontrol

    ' 宣告公用變數以便儲存 SQL Server 的登入資訊（包括SQL伺服器名稱、資料庫名稱、使用者帳號、密碼）
    Public MServerName As String = ""
    Public MDataBase As String = ""
    Public MUser As String = ""
    Public MPassword As String = ""

    ' 宣告公用變數以便儲存匯入檔的資料比數
    Public MTotalRecordNo As Int32

    ' 宣告資料表 O_Table00 儲存員工基本資料（已授權者及未授權者），供不同程序使用
    Public O_Table00 As DataTable
    ' 宣告資料表 O_Table01 儲存帳號資料（已授權者），供不同程序使用
    Public O_Table01 As DataTable

    ' 宣告公用變數以便儲存某 User 的原密碼
    Public Vpass As Int64 = 0
    '----------------------------------------------------------------------------------------------------------------------------------------------------

    ' 載入本表單時，
    ' 1. 將 VBSQLDB.TABEMPLOYEE 員工基本資料自 SQL Server 讀出，並作為 C_ID 帳號下拉式選單的選項
    ' 2 將 VBSQLDB.TABPASSW 帳號資料自 SQL Server 讀出，然後合併未授權者的資料，再顯示於 DataGridView
    ' DataGridView 前面顯示已授權者的資料，DataGridView 後面顯示未授權者的資料，C_ID 帳號下拉式選單的選項包含全部員工資料（包括已授權及尚未授權者）
    Private Sub F_IDcontrol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        MServerName = MStreamRead.ReadLine()
        MDataBase = MStreamRead.ReadLine()
        MUser = MStreamRead.ReadLine()
        MPassword = MStreamRead.ReadLine()
        MStreamRead.Close()

        ' 第一段，並將 VBSQLDB.TABEMPLOYEE 員工基本資料自 SQL Server 讀出，並作為 C_ID 帳號下拉式選單的選項 ***************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_0 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_0 As New SqlConnection(Mcnstr_0)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_0.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_0 As String = "Select eno,ename,deptcode From TABEMPLOYEE"
        Dim ODataAdapter_0 As New SqlDataAdapter(Msqlstr_0, Ocn_0)

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
        O_Table00 = New DataTable
        ODataAdapter_0.Fill(O_Table00)

        ' 關閉 存取資料庫的相關物件
        Ocn_0.Close()
        Ocn_0.Dispose()

        ' 將 DataTable 的資料併入下拉式選單（C_ID 帳號）
        C_ID.Items.Clear()
        Dim MTotalItems As Integer = O_Table00.Rows.Count - 1
        For Mcou = 0 To MTotalItems Step 1
            C_ID.Items.Add(O_Table00.Rows(Mcou)(0) + " " + O_Table00.Rows(Mcou)(1) + " " + O_Table00.Rows(Mcou)(2))
        Next

        ' 第二段，呼叫副程序，以便讀取帳號資料（已授權者），然後合併未授權者的資料，再顯示於 DataGridView *********************************
        Call SubDataLoad()
    End Sub

    ' 讀取 VBSQLDB.TABPASSW 全部帳號資料的副程序
    ' 因不同程序會使用本段程式，故寫為副程序
    Private Sub SubDataLoad()
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_1 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_1 As New SqlConnection(Mcnstr_1)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_1.Open()

        ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
        Dim Msqlstr_1 As String = "Select * From TABPASSW"
        Dim ODataAdapter_1 As New SqlDataAdapter(Msqlstr_1, Ocn_1)

        ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
        ' 重設 O_Table01 為 New DataTable，否則重複呼叫本程序時，O_Table01 的資料會累積
        O_Table01 = New DataTable
        ODataAdapter_1.Fill(O_Table01)

        ' 增加一欄，以便區分未授權員工（VBSQLDB.TABPASSW 中尚無授權資料者）
        Dim O_col01 As New DataColumn
        O_col01.DataType = System.Type.GetType("System.String")
        With O_col01
            .Caption = "已授權"
            .ColumnName = "Authority"
            .AllowDBNull = True
            .ReadOnly = False
            .Unique = False
            .DefaultValue = "Y"
        End With
        O_Table01.Columns.Add(O_col01)

        ' 比對  O_Table00 員工基本資料表，以便將未授權員工併入 O_Table01 資料表，再顯示於 DataGridView ****************************************************
        ' 先建立資料檢視表，以利後續程式比對
        Dim O_DV1 As DataView = New DataView(O_Table01)
        O_DV1.Sort = "eno ASC"

        Dim Meno As String = ""
        Dim Mename As String = ""
        Dim Mdept As String = ""
        Dim Mstop As Int32 = O_Table00.Rows.Count - 1
        For Mcou = 0 To Mstop Step 1
            Meno = O_Table00.Rows(Mcou)(0)
            Mename = O_Table00.Rows(Mcou)(1)
            Mdept = O_Table00.Rows(Mcou)(2)
            Dim Mcheck As Integer = O_DV1.Find(Meno)
            If Mcheck = -1 Then
                Dim O_NewRow As DataRow
                O_NewRow = O_Table01.NewRow()
                O_NewRow.Item(0) = Meno
                O_NewRow.Item(1) = Mename
                O_NewRow.Item(2) = "N"
                O_NewRow.Item(3) = 0
                O_NewRow.Item(4) = 1143045268
                O_NewRow.Item(5) = "Y"
                O_NewRow.Item(6) = 0
                O_NewRow.Item(7) = "N"
                O_NewRow.Item(8) = Mdept
                O_NewRow.Item(9) = "N"
                O_Table01.Rows.Add(O_NewRow)
                O_Table01.AcceptChanges()
            End If
        Next

        ' 指定 DataGridView 的資料來源
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_Table01
        ' 將資料筆數存入變數 MTotalRecordNo，供後續程序使用
        MTotalRecordNo = O_Table01.Rows.Count
        ' 顯示記錄數
        T_RecordNo.Text = "記錄數： " + MTotalRecordNo.ToString

        ' 關閉 存取資料庫的相關物件
        Ocn_1.Close()
        Ocn_1.Dispose()

        ' 加入中文欄名
        With DataGridView1
            .Columns(0).HeaderText = "帳號"
            .Columns(1).HeaderText = "姓名"
            .Columns(2).HeaderText = "已啟用"
            .Columns(3).HeaderText = "總使用次數"
            .Columns(4).HeaderText = "密碼"
            .Columns(5).HeaderText = "初次登入"
            .Columns(6).HeaderText = "登入次數"
            .Columns(7).HeaderText = "系統管理員"
            .Columns(8).HeaderText = "部門代號"
            .Columns(9).HeaderText = "已授權"
        End With
        ' 調整欄位名稱的列高，ColumnHeadersHeightSizeMode 不能設為 AutoSize（預設值）
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 32

        ' 格式化
        With DataGridView1
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Format = "#,0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 不允許資料網格檢視控制項增列最後一筆
        DataGridView1.AllowUserToAddRows = False

        ' 逐一調整列高，AutoSizeRowsMode 需設為 None
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Dim mtprow As Object
        For Each mtprow In DataGridView1.Rows
            mtprow.Height = 32
        Next mtprow

        ' 移動游標至第一筆的第一個格位
        ' 移動游標使用 Selected 方法，
        ' 格位由 Rows 列集合（括號內為列數）之 Cells 屬性決定（括號內為行數），
        ' 格位位址亦可於 DataGridView1 之後以括號指定行數及列數（括號內兩個引數，前者為行，前者為列）
        If DataGridView1.RowCount > 0 Then
            'DataGridView1.Rows(0).Cells(0).Selected = True
            DataGridView1(0, 0).Selected = True
        End If
    End Sub

    ' 移動游標至第一筆
    ' 只使用 Select 方法來選定目標儲存格，例如 DataGridView1(0, 0).Selected = True，是無法達到預期效果的，
    ' 第一，若目標儲存格（例如最後一筆）不在顯示範圍內，則不會自動捲動到顯示範圍內，
    ' 第二，不會引發 DataGridView 的 SelectionChanged 選取變動事件，故無法傳回游標所在列的資料。
    ' 改進辦法，使用 DataGridViewRow 資料網格檢視列物件
    ' 將目標儲存格（例如最後一筆）宣告為 DataGridViewRow 資料網格檢視列物件
    ' 然後使用 DataGridView 資料網格檢視物件的 CurrentCell 屬性，指定  DataGridViewRow 資料網格檢視列物件的第一格位為作用格位，
    ' 最後再使用 DataGridViewRow 資料網格檢視列物件的 Selected 屬性取選目標列即可
    ' 使用 CurrentCell 屬性可解決前述問題，如果目前儲存格不在顯示範圍內，則會自動捲動到顯示範圍內，且會引發 CurrentCellChanged 事件
    ' DataGridView 的 ClearSelection 方法可清除目前已選取的格位
    Private Sub B_TOP_Click(sender As Object, e As EventArgs) Handles B_TOP.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            'Dim O_DataRow As DataGridViewRow
            'O_DataRow = DataGridView1.Rows(0)
            Dim O_DataRow As DataGridViewRow = DataGridView1.Rows(0)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至最後一筆
    Private Sub B_BOT_Click(sender As Object, e As EventArgs) Handles B_BOT.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MTotalRecordNo - 1)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至前一筆
    Private Sub B_PREV_Click(sender As Object, e As EventArgs) Handles B_PREV.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()

            ' 計算前一筆的列號，並存入變數 MRowNo（目前游標所在之列號減 1），但不能小於 0
            Dim MRowNo As Int32 = DataGridView1.CurrentRow.Index - 1
            If MRowNo < 0 Then
                MRowNo = 0
            End If

            ' 宣告下一列為 DataGridViewRow 物件，並將其第一格位設為作用儲存格
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MRowNo)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' 移動游標至下一筆
    Private Sub B_NEXT_Click(sender As Object, e As EventArgs) Handles B_NEXT.Click
        If DataGridView1.RowCount > 0 Then
            DataGridView1.ClearSelection()

            ' 計算下一筆的列號，並存入變數 MRowNo（目前游標所在之列號加 1），但不能超過總筆數減 1
            Dim MRowNo As Int32 = DataGridView1.CurrentRow.Index + 1
            If MRowNo > MTotalRecordNo - 1 Then
                MRowNo = MTotalRecordNo - 1
            End If

            ' 宣告下一列為 DataGridViewRow 物件，並將其第一格位設為作用儲存格
            Dim O_DataRow As DataGridViewRow
            O_DataRow = DataGridView1.Rows(MRowNo)
            DataGridView1.CurrentCell = O_DataRow.Cells(0)
            O_DataRow.Selected = True
        End If
    End Sub

    ' DataGridView 選取變動事件
    ' 將游標所在資料顯示於各個文字盒，供 User 修改
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        ' 儲存某 User 的原密碼，供還原之用
        Vpass = DataGridView1.CurrentRow.Cells(4).Value

        ' 顯示記錄數
        ' CurrentCellAddress 的 Y 屬性可傳回游標所在的列數， X 屬性則可傳回游標所在的行數，均由 0 起算
        Dim Mrowno As SqlInt32 = DataGridView1.CurrentCellAddress.Y + 1
        T_RecordNo.Text = "記錄數： " + Mrowno.ToString + " / " + MTotalRecordNo.ToString

        ' 將游標所在資料顯示餘各個文字盒
        C_ID.Text = DataGridView1.CurrentRow.Cells(0).Value
        T_Ename.Text = DataGridView1.CurrentRow.Cells(1).Value
        T_Dept.Text = DataGridView1.CurrentRow.Cells(8).Value
        T_PassW.Text = DataGridView1.CurrentRow.Cells(4).Value
        T_FirstLogon.Text = DataGridView1.CurrentRow.Cells(5).Value
        T_Administrator.Text = DataGridView1.CurrentRow.Cells(7).Value
        T_IDenable.Text = DataGridView1.CurrentRow.Cells(2).Value
        T_Authority.Text = (DataGridView1.CurrentRow.Cells(9).Value)

        ' 根據前述文字盒的資料變更『初次登入』選項按鈕的狀態
        If T_FirstLogon.Text = "Y" Then
            T_FirstYes.Checked = True
            T_FirstNo.Checked = False
        Else
            T_FirstYes.Checked = False
            T_FirstNo.Checked = True
        End If
        ' 根據前述文字盒的資料變更『已啟用』選項按鈕的狀態
        If T_IDenable.Text = "Y" Then
            T_EnableYes.Checked = True
            T_EnableNo.Checked = False
        Else
            T_EnableYes.Checked = False
            T_EnableNo.Checked = True
        End If
    End Sub

    ' 離開帳號選取欄時，檢查 User 輸入值是否為下拉式選單的內容
    ' 當 User 自行輸入帳號，而非使用下拉式選單敲選帳號時，使用本程序來檢查 User 所輸入之值是否為下拉式選單的內容
    ' 若不是下拉式選單的內容，應顯示警告訊息，
    ' 若為下拉式選單的內容之一，則呼叫副程序，以便將 User 所輸帳號的相關資料顯示於各個文字盒
    Private Sub C_ID_Validated(sender As Object, e As EventArgs) Handles C_ID.Validated

        ' 將帳號資料存入變數（5 byte）
        Dim MchkID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))

        ' 使用 ComboBox 的 FindString 方法檢查 User 輸入值是否為下拉式選單的內容之一，
        ' 若找到會傳回索引編號（由0起算，若找不到，則傳回 -1
        If C_ID.FindString(MchkID) = -1 Then
            MsgBox("所輸入的帳號並非下拉式選單的選項之一！" + Chr(13) + Chr(10) + "請修正。", 0 + 16, "Error")
            C_ID.Focus()
        End If
        C_ID.Text = MchkID
        ' 呼叫副程序，以便顯示某帳號的相關資料
        Call SubChange(MchkID)

    End Sub

    ' 帳號選取變動事件，
    ' 將 User 所選帳號的相關資料顯示於各個文字盒，供 User 修改
    Private Sub C_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles C_ID.SelectedIndexChanged

        ' 送出 End 按鍵，讓游標置於字串尾端，以利 User 查看，否則整個字串呈現選取狀態
        ' 本段程式在此處不能使用
        ' C_ID.Focus()
        'SendKeys.Send("{End}")

        ' 呼叫副程序，以便顯示某帳號的相關資料
        ' 先將帳號資料存入變數（5 byte）
        Dim MchkID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        Call SubChange(MchkID)

    End Sub

    ' 在文字盒顯示某帳號相關資料的副程序
    ' 因不同程序會使用本段程式，故寫為副程序
    Private Sub SubChange(ByVal EID As String)
        If EID = "" Then
            Exit Sub
        End If
        ' 先建立資料檢視表，然後使用其 RowFilter 屬性過濾出某帳號的資料
        Dim O_DV As DataView = New DataView(O_Table01)
        O_DV.RowFilter = "eno='" + EID + "'"

        ' 使用資料檢視表的 Item 屬性可取得其某一項的資料，Item 之後為列索引及行索引
        T_Ename.Text = O_DV.Item(0)(1)
        T_Dept.Text = O_DV.Item(0)(8)
        T_PassW.Text = O_DV.Item(0)(4)
        T_FirstLogon.Text = O_DV.Item(0)(5)
        T_Administrator.Text = O_DV.Item(0)(7)
        T_IDenable.Text = O_DV.Item(0)(2)

        ' 根據前述文字盒的資料變更『初次登入』選項按鈕的狀態
        If T_FirstLogon.Text = "Y" Then
            T_FirstYes.Checked = True
            T_FirstNo.Checked = False
        Else
            T_FirstYes.Checked = False
            T_FirstNo.Checked = True
        End If
        ' 根據前述文字盒的資料變更『已啟用』選項按鈕的狀態
        If T_IDenable.Text = "Y" Then
            T_EnableYes.Checked = True
            T_EnableNo.Checked = False
        Else
            T_EnableYes.Checked = False
            T_EnableNo.Checked = True
        End If

    End Sub

    ' 結束
    Private Sub B_Quit_Click(sender As Object, e As EventArgs) Handles B_Quit.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Hide()
            F_Menu.Show()
        Else
            Return
        End If
    End Sub

    ' 將密碼還原為自定密碼，同時將初次登入狀態設為 NO，但限於敲『修改』鈕之前有效
    Private Sub B_CusPass_Click(sender As Object, e As EventArgs) Handles B_CusPass.Click
        T_PassW.Text = Vpass
        T_FirstLogon.Text = "N"
        T_FirstNo.Checked = True
        T_FirstYes.Checked = False
        MsgBox("密碼已還原為自定密碼！" + Chr(13) + Chr(13) + "敲『修改』鈕之後，才會更新伺服器資料。", 0 + 64, "OK")
    End Sub

    ' 將密碼設為內定值，同時將初次登入狀態設為 YES
    Private Sub B_DefaultPass_Click(sender As Object, e As EventArgs) Handles B_DefaultPass.Click
        T_PassW.Text = 1143045268
        T_FirstLogon.Text = "Y"
        T_FirstNo.Checked = False
        T_FirstYes.Checked = True
        MsgBox("密碼已設為內定值 abc123！" + Chr(13) + Chr(13) + "敲『修改』鈕之後，才會更新伺服器資料。", 0 + 64, "OK")
    End Sub

    ' 要更換系統管理員，必須在此按鈕內執行，其餘『新增』、『修改』、『刪除』等按鈕不作管理員的更換
    ' 系統管理員只能有一人
    Private Sub B_ChangeAdmin_Click(sender As Object, e As EventArgs) Handles B_ChangeAdmin.Click
        Dim M_NewManager As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        If Strings.Len(M_NewManager) = 0 Then
            MsgBox("『帳號』未指定，無法更換！" + Chr(13) + Chr(10) + "請輸入或敲選。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If

        ' 找出目前系統管理員的帳號，並存入變數 M_CurrentManager
        ' 先建立資料檢視表，然後使用其 RowFilter 屬性過濾出某帳號的資料
        Dim O_DV As DataView = New DataView(O_Table01)
        O_DV.RowFilter = "sysmanager='Y'"

        ' 使用資料檢視表的 Item 屬性可取得其某一項的資料，Item 之後為列索引及行索引
        Dim M_CurrentManager = O_DV.Item(0)(0)

        If M_NewManager = M_CurrentManager Then
            MsgBox(M_NewManager + " 是目前的系統管理員，無需更換！", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        Else
            Dim MANS As Integer
            MANS = MsgBox("目前系統管理員為︰" + M_CurrentManager + "，您確定要更換為 " + M_NewManager + " 嗎？", 4 + 32 + 256, "Please Confirm")
            If MANS <> 6 Then
                C_ID.Focus()
                Exit Sub
            End If

            ' 更新 SQL Server 中的相關資料 ****************************************************
            ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
            Dim Mcnstr_2 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

            ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
            Dim Ocn_2 As New SqlConnection(Mcnstr_2)

            ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
            Ocn_2.Open()

            ' 將 VBSQLDB.TABPASSW 中 目前系統管理員的 sysmanager 欄改為 N
            Dim Msqlstr_2 As String = "Update TABPASSW Set sysmanager='N' Where eno='" + M_CurrentManager + "'"
            ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_2），括號內有兩個參數，分別為  SQL 指令 與 連結物件
            Dim Ocmd_2 As New SqlCommand(Msqlstr_2, Ocn_2)

            ' 執行非查詢指令，更新 SQL Server 的資料
            ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
            Dim MupdateResult2 As Integer = Ocmd_2.ExecuteNonQuery()

            ' 將 VBSQLDB.TABPASSW 中 新系統管理員的 sysmanager 欄改為 Y
            Dim Msqlstr_3 As String = "Update TABPASSW Set sysmanager='Y' Where eno='" + M_NewManager + "'"
            ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_3），括號內有兩個參數，分別為  SQL 指令 與 連結物件
            Dim Ocmd_3 As New SqlCommand(Msqlstr_3, Ocn_2)

            ' 執行非查詢指令，更新 SQL Server 的資料
            ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
            Dim MupdateResult3 As Integer = Ocmd_3.ExecuteNonQuery()

            ' 關閉 存取資料庫的相關物件
            Ocn_2.Close()
            Ocn_2.Dispose()

            ' 更換 SQL Server 中的功能授權，強制將 Z2 及 Z3 功能轉給新的系統管理員，其他功能以人功調整 *********************************************************

            ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
            Dim Mcnstr_5 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

            ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
            Dim Ocn_5 As New SqlConnection(Mcnstr_5)

            ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
            Ocn_5.Open()

            ' 宣告 SQL 指令
            Dim Msqlstr_5 As String = "Delete From TABGRANT Where fcode In ('Z02','Z03')"
            ' 以 SqlCommand 建構函式初始化新的執行個體，括號內為  SQL 指令 與 連結物件
            Dim Ocmd_5 As New SqlCommand(Msqlstr_5, Ocn_5)

            ' 執行非查詢指令，更新 SQL Server 資料
            ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，若為 0 ，則表示未刪除任何資料
            Dim MdeleteResult5 As Integer = Ocmd_5.ExecuteNonQuery()

            ' 關閉 存取資料庫的相關物件
            Ocn_5.Close()
            Ocn_5.Dispose()

            ' 第二段之二，將已勾選資料插入 SQL Server 中的 TABGRANT 資料表 ******************************
            ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
            Dim Mcnstr_6 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

            ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
            Dim Ocn_6 As New SqlConnection(Mcnstr_6)

            ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
            Ocn_6.Open()

            ' 宣告變數儲存 SQL 指令
            Dim Msqlstr_6 As String = "Insert into TABGRANT(eno,fcode,fname) values(@t1,@t2,@t3)"
            ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_6），括號內有兩個參數，分別為  SQL 指令 與 連結物件
            Dim Ocmd_6 As New SqlCommand(Msqlstr_6, Ocn_6)

            Ocmd_6.Parameters.Clear()
            Ocmd_6.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = M_NewManager
            Ocmd_6.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = "Z02"
            Ocmd_6.Parameters.AddWithValue("@t3", SqlDbType.NVarChar).Value = "帳號管理"
            'Ocmd_6.Parameters.AddWithValue("@t1",M_NewManager)
            'Ocmd_6.Parameters.AddWithValue("@t2", "Z02")
            'Ocmd_6.Parameters.AddWithValue("@t3", "帳號管理")
            ' 執行非查詢指令，將資料存入 SQL Server
            Ocmd_6.ExecuteNonQuery()

            ' 宣告變數儲存 SQL 指令
            Dim Msqlstr_7 As String = "Insert into TABGRANT(eno,fcode,fname) values(@t1,@t2,@t3)"
            ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_6），括號內有兩個參數，分別為  SQL 指令 與 連結物件
            Dim Ocmd_7 As New SqlCommand(Msqlstr_7, Ocn_6)

            Ocmd_7.Parameters.Clear()
            Ocmd_7.Parameters.AddWithValue("@t1", SqlDbType.NVarChar).Value = M_NewManager
            Ocmd_7.Parameters.AddWithValue("@t2", SqlDbType.NVarChar).Value = "Z03"
            Ocmd_7.Parameters.AddWithValue("@t3", SqlDbType.NVarChar).Value = "授權管理"
            'Ocmd_7.Parameters.AddWithValue("@t1",M_NewManager)
            'Ocmd_7.Parameters.AddWithValue("@t2", "Z03")
            'Ocmd_7.Parameters.AddWithValue("@t3", "授權管理")
            ' 執行非查詢指令，將資料存入 SQL Server
            Ocmd_7.ExecuteNonQuery()

            ' 關閉 存取資料庫的相關物件
            Ocn_6.Close()
            Ocn_6.Dispose()

            ' 重新載入 VBSQLDB.TABPASSW 帳號資料
            Call SubDataLoad()

            MsgBox("系統管理員及部份授權功能已更換！", 0 + 64, "OK")

        End If
    End Sub

    ' 敲啟用帳號選項按鈕 YES
    Private Sub T_EnableYes_Click(sender As Object, e As EventArgs) Handles T_EnableYes.Click
        T_EnableNo.Checked = False
        T_IDenable.Text = "Y"
    End Sub

    ' 敲啟用帳號選項按鈕 NO
    Private Sub T_EnableNo_Click(sender As Object, e As EventArgs) Handles T_EnableNo.Click
        T_EnableYes.Checked = False
        T_IDenable.Text = "N"
    End Sub

    ' 敲初次登入選項按鈕 YES
    Private Sub T_FirstYes_Click(sender As Object, e As EventArgs) Handles T_FirstYes.Click
        T_FirstNo.Checked = False
        T_FirstLogon.Text = "Y"
    End Sub

    ' 敲初次登入選項按鈕 NO
    Private Sub T_FirstNo_Click(sender As Object, e As EventArgs) Handles T_FirstNo.Click
        T_FirstYes.Checked = False
        T_FirstLogon.Text = "N"
    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        C_ID.Text = ""
        T_Ename.Text = ""
        T_Dept.Text = ""
        T_PassW.Text = ""
        T_FirstLogon.Text = ""
        T_Administrator.Text = ""
        T_IDenable.Text = ""
        T_FirstYes.Checked = False
        T_FirstNo.Checked = False
        T_EnableYes.Checked = False
        T_EnableNo.Checked = False
        T_Authority.Text = ""
    End Sub

    ' 新增帳號
    Private Sub B_New_Click(sender As Object, e As EventArgs) Handles B_New.Click
        ' 新增帳號之密碼等資料一律使用內定值
        ' 檢查各欄資料是否都已輸入
        If T_Authority.Text = "Y" Then
            MsgBox("本帳號已授權，無法新增！" + Chr(13) + Chr(10) + "請重選帳號，或使用『修改』鈕來變更該帳號的資料。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        If Strings.Len(C_ID.Text) <> 5 Then
            MsgBox("『帳號』未指定，無法新增！" + Chr(13) + Chr(10) + "請輸入或敲選。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        If T_PassW.Text = "" Then
            MsgBox("密碼未指定，無法新增！" + Chr(13) + Chr(10) + "請重選帳號，或敲『預設』鈕來產生密碼。", 0 + 16, "Error")
            Exit Sub
        End If
        If T_FirstLogon.Text = "" Then
            MsgBox("初次登入未設定，無法新增！" + Chr(13) + Chr(10) + "請敲選。", 0 + 16, "Error")
            Exit Sub
        End If
        If T_IDenable.Text = "" Then
            MsgBox("啟用帳號未設定，無法新增！" + Chr(13) + Chr(10) + "請敲選。", 0 + 16, "Error")
            Exit Sub
        End If
        ' 將帳號資料存入變數（5 byte）
        Dim MtempID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        Dim MtempENAME As String = T_Ename.Text
        Dim MtempDEPT As String = T_Dept.Text
        Dim MANS As Integer
        MANS = MsgBox("您確定要新增 " + MtempID + " 之授權嗎？", 4 + 32 + 256, "Please Confirm")
        If MANS <> 6 Then
            C_ID.Focus()
            Exit Sub
        End If

        ' 將新增使用者的資訊存入變數，
        ' 帳號可由 User 自選，其他資料一律使用內定值，
        ' 使用狀態為 0 、總使用次數為 0 、密碼為 1143045268（不理會 User 是否敲了『自訂』鈕）、
        ' 第一次登入為 Y 、第一次登入後累積次數為 0 、系統管理員為 N
        ' 此處系統管理員一律設為 N，若要更改系統管理員，應敲『更換系統管理員』鈕
        ' 帳號一律設為啟用狀態，若要停用，應使用修改功能

        ' 連結 SQL Server，先刪除 Server 中同一帳號的資料，再上傳新增使用者的基本資料及內定密碼 *************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_8 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_8 As New SqlConnection(Mcnstr_8)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_8.Open()

        ' 宣告 SQL 指令
        Dim Msqlstr_8 As String = "Delete From TABPASSW Where eno='" + MtempID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內為  SQL 指令 與 連結物件
        Dim Ocmd_8 As New SqlCommand(Msqlstr_8, Ocn_8)

        ' 執行非查詢指令，更新 SQL Server 資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，若為 0 ，則表示未刪除任何資料
        Dim MdeleteResult8 As Integer = Ocmd_8.ExecuteNonQuery()

        ' 將新帳號資料插入 SQL Server 中的 TABPASSW 資料表 ******************************
        ' 宣告變數儲存 SQL 指令
        Dim Msqlstr_9 As String = "Insert into TABPASSW(eno,ename,idenable,totno,passww,firstlogon,logonno,sysmanager,deptcode) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9)"
        ' 以 SqlCommand 建構函式初始化新的執行個體（新物件名為 Ocmd_6），括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_9 As New SqlCommand(Msqlstr_9, Ocn_8)

        Ocmd_9.Parameters.Clear()
        Ocmd_9.Parameters.AddWithValue("@t1", MtempID)
        Ocmd_9.Parameters.AddWithValue("@t2", MtempENAME)
        Ocmd_9.Parameters.AddWithValue("@t3", "Y")
        Ocmd_9.Parameters.AddWithValue("@t4", 0)
        Ocmd_9.Parameters.AddWithValue("@t5", 1143045268)
        Ocmd_9.Parameters.AddWithValue("@t6", "Y")
        Ocmd_9.Parameters.AddWithValue("@t7", 0)
        Ocmd_9.Parameters.AddWithValue("@t8", "N")
        Ocmd_9.Parameters.AddWithValue("@t9", MtempDEPT)

        ' 執行非查詢指令，將資料存入 SQL Server
        Ocmd_9.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocn_8.Close()
        Ocn_8.Dispose()

        ' 重新載入 VBSQLDB.TABPASSW 帳號資料
        Call SubDataLoad()
        MsgBox("帳號已新增！" + Chr(13) + Chr(13) + "另請使用主目錄的 Z3 ，授權該帳號可使用的功能。", 0 + 64, "OK")
    End Sub

    ' 修改帳號資料
    Private Sub B_Edit_Click(sender As Object, e As EventArgs) Handles B_Edit.Click
        ' 此處可更改『姓名』、『密碼』、『初次登入狀態』、『帳號啟用』，
        ' 『總使用次數』及『系統管理員』兩欄不能些改，若『初次登入』為 Y，則將『初次登入次數』歸零
        ' 修改對象以文字盒內所輸入的帳號為準，而非以游標所在為準
        ' 『帳號』不能修改，若帳號有錯，應刪除再新增
        ' 檢查各欄資料是否都已輸入
        Dim MID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        If Strings.Len(MID) = 0 Then
            MsgBox("『帳號』未指定，無法修改！" + Chr(13) + Chr(10) + "請輸入或敲選。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        If T_Authority.Text = "N" Then
            MsgBox("本帳號尚未授權，無法修改！" + Chr(13) + Chr(10) + "請重選帳號，或使用『新增』鈕來增加該帳號之授權。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
       
        ' 將帳號資料存入變數（5 byte）
        Dim MENAME As String = T_Ename.Text
        Dim MDEPT As String = T_Dept.Text
        Dim MENABLE As String = T_IDenable.Text
        Dim MPASSW As String = T_PassW.Text
        Dim MFIRST As String = T_FirstLogon.Text
        Dim MANS As Integer
        MANS = MsgBox("您確定要修改 " + MID + " 的資料嗎？", 4 + 32 + 256, "Please Confirm")
        If MANS <> 6 Then
            C_ID.Focus()
            Exit Sub
        End If

        ' 更新 SQL Server 中的相關資料 ****************************************************
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_10 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_10 As New SqlConnection(Mcnstr_10)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_10.Open()

        ' 更新 VBSQLDB.TABPASSW 中的姓名欄
        Dim Msqlstr_10 As String = "Update TABPASSW Set ename='" + MENAME + "' Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_10 As New SqlCommand(Msqlstr_10, Ocn_10)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult10 As Integer = Ocmd_10.ExecuteNonQuery()

        ' 更新 VBSQLDB.TABPASSW 中的啟用帳號欄
        Dim Msqlstr_10_1 As String = "Update TABPASSW Set idenable='" + MENABLE + "' Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_10_1 As New SqlCommand(Msqlstr_10_1, Ocn_10)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult10_1 As Integer = Ocmd_10_1.ExecuteNonQuery()

        ' 更新 VBSQLDB.TABPASSW 中的密碼欄
        Dim Msqlstr_10_2 As String = "Update TABPASSW Set passww='" + MPASSW + "' Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_10_2 As New SqlCommand(Msqlstr_10_2, Ocn_10)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult10_2 As Integer = Ocmd_10_2.ExecuteNonQuery()

        ' 更新 VBSQLDB.TABPASSW 中的初次登入欄
        Dim Msqlstr_10_3 As String = "Update TABPASSW Set firstlogon='" + MFIRST + "' Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_10_3 As New SqlCommand(Msqlstr_10_3, Ocn_10)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult10_3 As Integer = Ocmd_10_3.ExecuteNonQuery()

        ' 若為初次登入，則需更新 VBSQLDB.TABPASSW 中的初次登入次數欄（歸零）
        If MFIRST = "Y" Then
            Dim Msqlstr_10_4 As String = "Update TABPASSW Set logonno='0' Where eno='" + MID + "'"
            ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
            Dim Ocmd_10_4 As New SqlCommand(Msqlstr_10_4, Ocn_10)

            ' 執行非查詢指令，更新 SQL Server 的資料
            ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
            Dim MupdateResult10_4 As Integer = Ocmd_10_4.ExecuteNonQuery()
        End If

        ' 更新 VBSQLDB.TABPASSW 中的部門欄
        Dim Msqlstr_10_5 As String = "Update TABPASSW Set deptcode='" + MDEPT + "' Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內有兩個參數，分別為  SQL 指令 與 連結物件
        Dim Ocmd_10_5 As New SqlCommand(Msqlstr_10_5, Ocn_10)

        ' 執行非查詢指令，更新 SQL Server 的資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，以本例而言，若為 0 ，表示未修改任何資料
        Dim MupdateResult10_5 As Integer = Ocmd_10_5.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocn_10.Close()
        Ocn_10.Dispose()

        ' 重新載入 VBSQLDB.TABPASSW 帳號資料
        Call SubDataLoad()
        MsgBox("帳號已修改！", 0 + 64, "OK")
    End Sub

    ' 刪除帳號資料
    Private Sub B_Delet_Click(sender As Object, e As EventArgs) Handles B_Delet.Click
        ' 本功能可永久刪除使用者授權資料，包括 VBSQLDB.TABGRANT 授權檔資料
        ' 若因留停等原因而暫時不用，則應『停用』該帳號而非刪除（啟用帳號欄改為 N），以節省重建資料的時間

        ' 檢查各欄資料是否都已輸入
        Dim MID As String = Strings.UCase(Strings.Left(C_ID.Text, 5))
        If Strings.Len(MID) = 0 Then
            MsgBox("『帳號』未指定，無法刪除！" + Chr(13) + Chr(10) + "請輸入或敲選。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        If T_Authority.Text = "N" Then
            MsgBox("本帳號尚未授權，無法刪除！" + Chr(13) + Chr(10) + "請重選帳號。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        If T_Administrator.Text = "Y" Then
            MsgBox("本帳號為系統管理員，無法刪除！" + Chr(13) + Chr(10) + "請重選帳號。", 0 + 16, "Error")
            C_ID.Focus()
            Exit Sub
        End If
        Dim MANS As Integer
        MANS = MsgBox("您確定要刪除 " + MID + " 的授權資料嗎？" + Chr(13) + Chr(13) + "若因留停等原因而暫時不用，應『停用』該帳號而非刪除。" + Chr(13) + "（啟用帳號欄改為 N）", 4 + 32 + 256, "Please Confirm")
        If MANS <> 6 Then
            C_ID.Focus()
            Exit Sub
        End If

        ' 連結 SQL Server
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_11 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUser + ";Password=" + MPassword + ";Trusted_Connection=False"

        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_11 As New SqlConnection(Mcnstr_11)

        ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
        Ocn_11.Open()

        ' 宣告 SQL 指令，刪除 TABPASSW 密碼檔中的該使用者的資料
        Dim Msqlstr_11 As String = "Delete From TABPASSW Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內為  SQL 指令 與 連結物件
        Dim Ocmd_11 As New SqlCommand(Msqlstr_11, Ocn_11)

        ' 執行非查詢指令，更新 SQL Server 資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，若為 0 ，則表示未刪除任何資料
        Dim MdeleteResult11 As Integer = Ocmd_11.ExecuteNonQuery()

        ' 宣告 SQL 指令，刪除 TABGRANT 授權檔中的相關資料
        Dim Msqlstr_12 As String = "Delete From TABGRANT Where eno='" + MID + "'"
        ' 以 SqlCommand 建構函式初始化新的執行個體，括號內為  SQL 指令 與 連結物件
        Dim Ocmd_12 As New SqlCommand(Msqlstr_12, Ocn_11)

        ' 執行非查詢指令，更新 SQL Server 資料
        ' ExecuteNonQuery 方法執行後會傳回受影響的資料數，若為 0 ，則表示未刪除任何資料
        Dim MdeleteResult12 As Integer = Ocmd_12.ExecuteNonQuery()

        ' 關閉 存取資料庫的相關物件
        Ocn_11.Close()
        Ocn_11.Dispose()

        ' 重新載入 VBSQLDB.TABPASSW 帳號資料
        Call SubDataLoad()
        MsgBox("帳號 " + MID + " 的授權資料已刪除！", 0 + 64, "OK")
    End Sub

End Class