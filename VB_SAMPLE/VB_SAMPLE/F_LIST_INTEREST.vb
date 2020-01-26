Public Class F_LIST_INTEREST

    ' 宣告變數，儲存 User 所敲選的興趣
    Public MString As String = ""

    ' 判斷 User 所敲選的項目
    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click

        ' 宣告變數，儲存 User 所敲選的興趣
        'Dim MString As String = ""
        ' 清除前次所選項目
        MString = ""

        ' CheckedListBox 核取清單方塊之項目由 0 起算，Count 屬性可傳回核取清單方塊之項目總數，
        ' GetItemChecked() 方法可檢查某一項目是否已被敲選，GetItemText(mcou) 傳回項目代號，Items(mcou) 傳回項目名稱
        For mcou = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(mcou) = True Then
                If MString = "" Then
                    ' F_Input_1.MString = CheckedListBox1.GetItemText(mcou)
                    MString = CheckedListBox1.Items(mcou)
                Else
                    MString = MString + "、" + CheckedListBox1.Items(mcou)
                End If
            End If
        Next
        'Me.Tag = MString
        Me.Hide()
        F_Input_1.Visible = True
    End Sub

    ' 自訂函數，控制呼叫表單（本例為 F_Input_1）上的控制項
    ' 在本函數中將 User 所挑選的項目傳回  F_Input_1  表單會慢半拍，故不使用
    Public Function CtrlObj(ByRef MTempForm As System.Windows.Forms.Form)
        F_Input_1.T_INTEREST.Text = ""
        F_Input_1.T_INTEREST.Focus()
        Return ""
    End Function

End Class