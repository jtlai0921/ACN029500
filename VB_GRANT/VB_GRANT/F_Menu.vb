Public Class F_Menu

    ' 載入本表單時，判斷 F_SQL_Login 登入表單所產生的清單集合之內容，
    ' List_ID 清單儲存了 某帳號的資料（帳號、姓名及系統管理員），
    ' List_GRANT 清單儲存了 某帳號的授權項目，
    ' 以便決定主目錄上哪些項目可被使用（Visible=True）
    ' 表單之間傳遞參數的方法請參考本書第 3 章第 3 節的說明
    Private Sub F_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If F_SQL_Login.List_ID(2) = "Y" Then
            Me.Z02.Visible = True
            Me.Z03.Visible = True
            Me.Z2.Enabled = True
            Me.Z3.Enabled = True
        Else
            Me.Z02.Visible = False
            Me.Z03.Visible = False
            Me.Z2.Enabled = False
            Me.Z3.Enabled = False
        End If

        If F_SQL_Login.List_GRANT.Contains("A01") = True Then
            Me.A01.Visible = True
            Me.A1.Enabled = True
        Else
            Me.A01.Visible = False
            Me.A1.Enabled = False
        End If
        If F_SQL_Login.List_GRANT.Contains("A02") = True Then
            Me.A02.Visible = True
            Me.A2.Enabled = True
        Else
            Me.A02.Visible = False
            Me.A2.Enabled = False
        End If
        If F_SQL_Login.List_GRANT.Contains("A03") = True Then
            Me.A03.Visible = True
            Me.A3.Enabled = True
        Else
            Me.A03.Visible = False
            Me.A3.Enabled = False
        End If
        If F_SQL_Login.List_GRANT.Contains("B01") = True Then
            Me.B01.Visible = True
            Me.B1.Enabled = True
        Else
            Me.B01.Visible = False
            Me.B1.Enabled = False
        End If
        If F_SQL_Login.List_GRANT.Contains("B02") = True Then
            Me.B02.Visible = True
            Me.B2.Enabled = True
        Else
            Me.B02.Visible = False
            Me.B2.Enabled = False
        End If
        If F_SQL_Login.List_GRANT.Contains("B03") = True Then
            Me.B03.Visible = True
            Me.B3.Enabled = True
        Else
            Me.B03.Visible = False
            Me.B3.Enabled = False
        End If

    End Sub

    Private Sub A01_Click(sender As Object, e As EventArgs) Handles A01.Click
        MsgBox("A1 資料維護一！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub A02_Click(sender As Object, e As EventArgs) Handles A02.Click
        MsgBox("A2 資料維護二！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub A03_Click(sender As Object, e As EventArgs) Handles A03.Click
        MsgBox("A3 資料維護三！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B01_Click(sender As Object, e As EventArgs) Handles B01.Click
        MsgBox("B1 資料查詢一！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B02_Click(sender As Object, e As EventArgs) Handles B02.Click
        MsgBox("B2 資料查詢二！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B03_Click(sender As Object, e As EventArgs) Handles B03.Click
        MsgBox("B3 資料查詢三！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B_Close_Click(sender As Object, e As EventArgs) Handles B_Close.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            Application.Exit()
        Else
            Return
        End If
    End Sub

    Private Sub A1_Click(sender As Object, e As EventArgs) Handles A1.Click
        MsgBox("A1 資料維護一！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub A2_Click(sender As Object, e As EventArgs) Handles A2.Click
        MsgBox("A2 資料維護二！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub A3_Click(sender As Object, e As EventArgs) Handles A3.Click
        MsgBox("A3 資料維護三！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        MsgBox("B1 資料查詢一！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        MsgBox("B2 資料查詢二！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub B3_Click(sender As Object, e As EventArgs) Handles B3.Click
        MsgBox("B3 資料查詢三！" + Chr(13) + Chr(13) + "敲『確定』鈕之後，返回主目錄。", 0 + 64, "OK")
    End Sub

    Private Sub Z_EXIT_Click(sender As Object, e As EventArgs) Handles Z_EXIT.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            Application.Exit()
        Else
            Return
        End If
    End Sub

    ' 顯示密碼更換表單
    Private Sub Z01_Click(sender As Object, e As EventArgs) Handles Z01.Click
        Me.Hide()
        F_PasswordChange.Show()
    End Sub

    ' 顯示密碼更換表單
    Private Sub Z1_Click(sender As Object, e As EventArgs) Handles Z1.Click
        Me.Hide()
        F_PasswordChange.Show()
    End Sub

    ' 顯示授權管理表單
    Private Sub Z03_Click(sender As Object, e As EventArgs) Handles Z03.Click
        Me.Hide()
        F_GrantFunction.Show()
    End Sub

    ' 顯示授權管理表單
    Private Sub Z3_Click(sender As Object, e As EventArgs) Handles Z3.Click
        Me.Hide()
        F_GrantFunction.Show()
    End Sub

    ' 顯示帳號管理表單
    Private Sub Z02_Click(sender As Object, e As EventArgs) Handles Z02.Click
        Me.Hide()
        F_IDcontrol.Show()
    End Sub

    ' 顯示帳號管理表單
    Private Sub Z2_Click(sender As Object, e As EventArgs) Handles Z2.Click
        Me.Hide()
        F_IDcontrol.Show()
    End Sub
End Class