Public Class F_TableMaintMenu

    ' 放棄
    Private Sub B_GiveUp_Click(sender As Object, e As EventArgs) Handles B_GiveUp.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Hide()
            F_menu.Show()
        Else
            Return
        End If
    End Sub

    ' GO，依據敲選結果顯示相關的對照表維護表單 
    Private Sub B_GO_Click(sender As Object, e As EventArgs) Handles B_GO.Click
        If T_Table01.Checked = True Then
            Me.Hide()
            F_TableDept.Show()
        End If
        If T_Table02.Checked = True Then
            Me.Hide()
            F_TableTitle.Show()
        End If
        If T_Table03.Checked = True Then
            Me.Hide()
            F_TableGrade.Show()
        End If
    End Sub

End Class