Imports System
Imports System.Data
Imports System.IO

Public Class F_SQL_Login

    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        Dim MServerName As String = ""
        Dim MDataBase As String = ""
        Dim MUser As String = ""
        Dim MPassword As String = ""

        MServerName = Trim(T_ServerName.Text)
        MDataBase = Trim(T_DataBase.Text)
        MUser = Trim(T_User.Text)
        MPassword = Trim(T_Password.Text)

        ' 使用 StreamWriter 資料流寫入器建構函式 建立新的物件（執行個體），以便寫入文字檔，
        ' 括號內有兩個參數，前者為檔名及其路徑，後者為布林值，true  表示要附加資料至檔案，false 表示要覆寫檔案。 如果指定的檔案不存在，則這個參數沒有任何作用，而且建構函式會建立新的檔案
        ' 使用 WriteLine 方法將字串 (其後加上行結束字元) 寫入到文字字串或資料流
        ' 使用 Flush 方法清除目前寫入器 的所有緩衝區，並且將緩衝資料都寫入基礎資料流
        ' 使用 Close 方法 關閉目前的 StreamWriter 物件和基礎資料流
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamWrite As StreamWriter = New StreamWriter(MFileName, False)
        MStreamWrite.WriteLine(MServerName)
        MStreamWrite.WriteLine(MDataBase)
        MStreamWrite.WriteLine(MUser)
        MStreamWrite.WriteLine(MPassword)
        MStreamWrite.Flush()
        MStreamWrite.Close()

        MsgBox("SQL Server 登入資訊已存入檔案！", 0 + 64 + 128, "OK")

    End Sub

    ' 自檔案讀出前次儲存的登入資訊，並置入文字盒
    ' 使用 StreamReader 資料流讀取器建構函式 建立新的物件（執行個體），以便讀取文字檔，括號內為檔名及其路徑
    ' 使用 ReadLine 方法自目前資料流讀取一行字元，並將資料以字串傳回
    ' 使用 Close 方法關閉 StreamReader 物件和基礎資料流
    Private Sub F_SQL_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MFileName = "APPDATA\MySQLLogin.txt"
        Dim MStreamRead As StreamReader = New StreamReader(MFileName)
        T_ServerName.Text = MStreamRead.ReadLine()
        T_DataBase.Text = MStreamRead.ReadLine()
        T_User.Text = MStreamRead.ReadLine()
        T_Password.Text = MStreamRead.ReadLine()
        MStreamRead.Close()
        T_DataBase.Focus()
    End Sub
End Class