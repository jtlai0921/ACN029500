Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class MyClass_SqlServerRead
    ' 使用 Implements 陳述式引入 IDisposable 介面（亦即所謂的實作），以便本類別的執行個體（據以宣告的物件）支援 Dispose 方法
    ' 本敘述必須在宣告欄位、屬性、方法之前使用
    ' 另見 #Region 段落之程式（由 VB 自動產生，輸入 Implements IDisposable 之後即自動產生）
    Implements IDisposable

    ' 宣告欄位（公用變數）供外部程式讀取
    Public O_SqlTable_0 As DataTable

    Private MServerName As String = ""
    Private MDataBase As String = ""
    Private MUserName As String = ""
    Private MPassword As String = ""
    Private MSQLCommand As String = ""

    ' 宣告屬性程序之一
    ' 本屬性值需由 User 指定 SQL Server 執行個體名稱，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputServerName（即 User 指定的  SQL Server 執行個體名稱）指定給變數 MServerName，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property ServerName As String
        'Get
        '    Return MServerName
        'End Get
        Set(ByVal InputServerName As String)
            MServerName = InputServerName
        End Set
    End Property

    ' 宣告屬性程序之二
    ' 本屬性值需由 User 指定資料庫名稱，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputDBName（即 User 指定的資料庫名稱）指定給變數 MDataBase ，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property DBName As String
        Set(ByVal InputDBName As String)
            MDataBase = InputDBName
        End Set
    End Property

    ' 宣告屬性程序之三
    ' 本屬性值需由 User 指定使用者名稱，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputUserName（即 User 指定的使用者名稱）指定給變數 MUserName ，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property UserName As String
        Set(ByVal InputUserName As String)
            MUserName = InputUserName
        End Set
    End Property

    ' 宣告屬性程序之四
    ' 本屬性值需由 User 指定使用者密碼，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數  InputPassword（即 User 指定的使用者密碼）指定給變數 MPassword ，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property Password As String
        Set(ByVal InputPassword As String)
            MPassword = InputPassword
        End Set
    End Property

    ' 宣告屬性程序之五
    ' 本屬性值需由 User 指定 SQL 指令，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputSQLCommand（即 User 指定的 SQL 指令）指定給變數 MSQLCommand ，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property SQLCommand As String
        Set(ByVal InputSQLCommand As String)
            MSQLCommand = InputSQLCommand
        End Set
    End Property

    ' 宣告方法
    ' 使用 Try 捕捉錯誤 ，以防 User 輸錯指令
    Public Sub GetData()
        ' 宣告連接字串，以供後續 SqlConnection 連接物件使用
        Dim Mcnstr_0 As String = "Data Source=" + MServerName + ";Initial Catalog=" + MDataBase + ";User ID=" + MUserName + ";Password=" + MPassword + ";Trusted_Connection=False"
        ' 依據 SqlConnection 類別建立新的連接物件，括號內為連接字串
        Dim Ocn_0 As New SqlConnection(Mcnstr_0)
        Try
            ' 使用 SqlConnection  的 Open 方法 開啟資料庫連線
            Ocn_0.Open()
            ' 宣告 SQL 命令變數，以供後續 SqlDataAdapter 轉接器物件使用
            Dim Msqlstr_0 As String = MSQLCommand
            ' 依據 SqlDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
            Dim ODataAdapter_0 As New SqlDataAdapter(Msqlstr_0, Ocn_0)
            ' 建立資料表物件，以便存放讀出的資料
            O_SqlTable_0 = New DataTable
            ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
            ODataAdapter_0.Fill(O_SqlTable_0)
            ' 關閉 存取資料庫的相關物件
            Ocn_0.Close()
            Ocn_0.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString, 0 + 16, "Error")
            Exit Sub
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO:  處置 Managed 狀態 (Managed 物件)。
            End If

            ' TODO:  釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下面的 Finalize()。
            ' TODO:  將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

    ' TODO:  只有當上面的 Dispose(ByVal disposing As Boolean) 有可釋放 Unmanaged 資源的程式碼時，才覆寫 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 請勿變更此程式碼。在上面的 Dispose(ByVal disposing As Boolean) 中輸入清除程式碼。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
