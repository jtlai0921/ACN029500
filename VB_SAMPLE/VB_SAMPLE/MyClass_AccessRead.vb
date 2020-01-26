Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.VisualBasic

Public Class MyClass_AccessRead
    ' 使用 Implements 陳述式引入 IDisposable 介面（亦即所謂的實作），以便本類別的執行個體（據以宣告的物件）支援 Dispose 方法
    ' 本敘述必須在宣告欄位、屬性、方法之前使用
    ' 另見 #Region 段落之程式（由 VB 自動產生，輸入 Implements IDisposable 之後即自動產生）
    Implements IDisposable

    ' 宣告欄位（公用變數）供外部程式讀取
    Public O_AccessTable_0 As DataTable

    Private MDBName As String = ""
    Private MSQLCommand As String = ""

    ' 宣告屬性程序之一
    ' 本屬性值需由 User 指定資料庫名稱及其路徑，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputDBName（即 User 指定的資料庫名稱及其路徑）指定給變數 MDBName，該變數將於本類別的 GetData 方法中使用
    Public WriteOnly Property DBName As String
        'Get
        '    Return MDBName
        'End Get
        Set(ByVal InputDBName As String)
            MDBName = InputDBName
        End Set
    End Property

    ' 宣告屬性程序之二
    ' 本屬性值需由 User 指定 SQL 指令，故無需 Get 程序，只需 Set 程序，並使用 WriteOnly 關鍵字，
    ' Set 程序中將 參數 InputSQLCommand（即 User 指定的 SQL 指令）指定給變數 MSQLCommand ，該變數將於本類別的 GetData 方法中使用
    Public Property SQLCommand As String
        Get
            Return MSQLCommand
        End Get
        Set(ByVal InputSQLCommand As String)
            MSQLCommand = InputSQLCommand
        End Set
    End Property

    ' 宣告方法
    ' 使用 Try 捕捉錯誤 ，以防 User 輸錯指令
    Public Sub GetData()
        Dim MSTRconn_0 As String = "provider=Microsoft.ACE.Oledb.12.0;data source=" + MDBName
        ' 連結資料庫
        Dim Oconn_0 As New OleDbConnection(MSTRconn_0)
        Try
            Oconn_0.Open()
            ' 宣告 SQL 命令變數，以供後續 OleDbDataAdapter 轉接器物件使用
            Dim Msqlstr_0 As String = MSQLCommand
            ' 依據 OleDbDataAdapter 類別建立新的物件（資料轉接器），括號內為 SQL 命令及連接物件
            Dim ODataAdapter_0 As New OleDbDataAdapter(Msqlstr_0, Oconn_0)

            ' 建立資料表物件，以便存放讀出的資料
            O_AccessTable_0 = New DataTable
            ' 使用轉接器的 Fill 方法，將讀出的資料存入資料表
            ODataAdapter_0.Fill(O_AccessTable_0)

            ' 關閉 存取資料庫的相關物件
            Oconn_0.Close()
            Oconn_0.Dispose()
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

