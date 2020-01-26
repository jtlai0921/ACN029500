Public Class F_Class01

    ' 離開本表單
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

    ' 使用 MyClass_AccessRead 類別匯入 Access 資料，並顯示於 DataGridView
    Private Sub B_Import01_Click(sender As Object, e As EventArgs) Handles B_Import01.Click
        If T_AccessDB.Text = "" Then
            MsgBox("Sorry, 請指定或敲選資料庫名稱及其路徑！", 0 + 16, "Error")
            T_AccessDB.Focus()
            Exit Sub
        End If
        If T_AccessSQL.Text = "" Then
            MsgBox("Sorry, 請輸入或敲選 SQL 指令！", 0 + 16, "Error")
            T_AccessSQL.Focus()
            Exit Sub
        End If

        ' 依據 MyClass_AccessRead 類別建立新的物件 O_01
        ' 使用 O_01物件的 DBName 屬性指定資料庫名稱及其路徑
        ' 使用 O_01物件的 SQLCommand 屬性指定 SQL 指令
        ' 使用 O_01物件的 GetData 方法取回已儲存在 O_AccessTable_0 資料表中的資料
        Dim O_01 As New MyClass_AccessRead
        O_01.DBName = T_AccessDB.Text
        O_01.SQLCommand = T_AccessSQL.Text
        O_01.GetData()

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_01.O_AccessTable_0
        O_01.Dispose()

        Dim MTotalRecordNo As Int32 = O_01.O_AccessTable_0.Rows.Count
        T_RecordNo.Text = "筆數： " + MTotalRecordNo.ToString
    End Sub

    ' 當 User 敲 Access 資料庫選單之向下鍵時，選單長度加大，以便顯示完整的選單內容
    Private Sub L_AccessDB_DropDown(sender As Object, e As EventArgs) Handles L_AccessDB.DropDown
        L_AccessDB.Size = New System.Drawing.Size(315, 28)
    End Sub

    ' 當 User 離開（關閉） Access 資料庫選單時，選單長度恢復原大小，以免佔用版面，增加 User 困擾
    Private Sub L_AccessDB_DropDownClosed(sender As Object, e As EventArgs) Handles L_AccessDB.DropDownClosed
        L_AccessDB.Size = New System.Drawing.Size(35, 28)
    End Sub

    ' Access 資料庫下拉式選單的選變動事件，將 User 所敲選的項目置入文字盒
    Private Sub L_AccessDB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L_AccessDB.SelectedIndexChanged
        T_AccessDB.Text = L_AccessDB.Text
    End Sub

    ' 當 User 敲 Access 讀取指令選單之向下鍵時，選單長度加大，以便顯示完整的選單內容
    Private Sub L_AccessSQL_DropDown(sender As Object, e As EventArgs) Handles L_AccessSQL.DropDown
        L_AccessSQL.Size = New System.Drawing.Size(500, 28)
    End Sub

    ' 當 User 離開（關閉）Access 讀取指令選單時，選單長度恢復原大小，以免佔用版面，增加 User 困擾
    Private Sub L_AccessSQL_DropDownClosed(sender As Object, e As EventArgs) Handles L_AccessSQL.DropDownClosed
        L_AccessSQL.Size = New System.Drawing.Size(35, 27)
    End Sub

    ' 將 User 所敲選的 Access 讀取指令 置入文字盒
    Private Sub L_AccessSQL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L_AccessSQL.SelectedIndexChanged
        T_AccessSQL.Text = L_AccessSQL.Text
    End Sub

    ' 使用 MyClass_SqlServerRead 類別匯入 SQL Server 的資料，並顯示於 DataGridView
    Private Sub B_Import02_Click(sender As Object, e As EventArgs) Handles B_Import02.Click
        If T_SqlSelect.Text = "" Then
            MsgBox("Sorry, 請在『 讀取指令』欄輸入或敲選 SQL 指令！", 0 + 16, "Error")
            T_SqlSelect.Focus()
            Exit Sub
        End If

        Dim O_02 As New MyClass_SqlServerRead
        O_02.ServerName = T_SQLServerName.Text
        O_02.DBName = T_SQLDBName.Text
        O_02.UserName = T_UserName.Text
        O_02.Password = T_Password.Text
        O_02.SQLCommand = T_SqlSelect.Text
        O_02.GetData()

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = O_02.O_SqlTable_0
        O_02.Dispose()

        Dim MTotalRecordNo As Int32 = O_02.O_SqlTable_0.Rows.Count
        T_RecordNo.Text = "筆數： " + MTotalRecordNo.ToString
    End Sub

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        T_AccessDB.Text = ""
        T_AccessSQL.Text = ""
        T_SqlSelect.Text = ""
        L_AccessDB.Text = ""
        L_AccessSQL.Text = ""
        L_SQLSelect.Text = ""
        T_RecordNo.Text = ""
        DataGridView1.DataSource = Nothing
    End Sub

    ' SQL server 讀取指令下拉式選單的選變動事件，將 User 所敲選的項目置入文字盒
    Private Sub L_SQLSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L_SQLSelect.SelectedIndexChanged
        T_SqlSelect.Text = L_SQLSelect.Text
    End Sub

    ' 當 User 敲 SQL Server 讀取指令選單之向下鍵時，選單長度加大並更換 Location，以便顯示完整的選單內容，
    Private Sub L_SQLSelect_DropDown(sender As Object, e As EventArgs) Handles L_SQLSelect.DropDown
        L_SQLSelect.Size = New System.Drawing.Size(970, 27)
        L_SQLSelect.Location = New System.Drawing.Point(10, 500)
    End Sub

    ' 當 User 離開（關閉）SQL Server 讀取指令選單時，選單長度恢復原大小，Location 亦歸原位，以免佔用版面，增加 User 困擾
    Private Sub L_SQLSelect_DropDownClosed(sender As Object, e As EventArgs) Handles L_SQLSelect.DropDownClosed
        L_SQLSelect.Size = New Size(35, 27)
        L_SQLSelect.Location = New System.Drawing.Point(859, 535)
    End Sub

End Class