Imports System.Data
Imports System.IO
Imports TaipeiVB

Public Class F_DLL01

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

    ' 清空文字盒
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        T_USD.Text = ""
        T_AMT01.Text = ""
        T_QTY.Text = ""
        T_StartCode.Text = ""
        T_YES.Checked = False
        T_NO.Checked = False
        L_Parameter.Text = ""
    End Sub

    ' 阿拉伯數字轉成英文金額
    Private Sub B_USD_Click(sender As Object, e As EventArgs) Handles B_USD.Click
        If Strings.Trim(T_AMT01.Text) = "" Then
            MsgBox("請輸入阿拉數字", 0 + 16, "Error")
            T_AMT01.Focus()
            Exit Sub
        End If
        Dim Monly As Object = ""
        If T_YES.Checked = True Then
            Monly = "1"
        End If
        If T_NO.Checked = True Then
            Monly = "0"
        End If
        Dim O_01 As New TaipeiVB.MyClass01
        Dim Mresult As String
        Mresult = O_01.USD(T_AMT01.Text, Monly)
        T_USD.Text = Mresult
    End Sub

    ' 判斷奇偶數
    Private Sub B_ODD_Click(sender As Object, e As EventArgs) Handles B_ODD.Click
        If Strings.Trim(T_AMT01.Text) = "" Then
            MsgBox("請輸入阿拉伯數字", 0 + 16, "Error")
            T_AMT01.Focus()
            Exit Sub
        End If
        Dim O_01 As New TaipeiVB.MyClass01
        Dim Mchk As String = O_01.IsOddNo(T_AMT01.Text)
        Dim Mans As String = ""
        Me.TopMost = False
        Select Case Mchk
            Case "Y"
                Mans = T_AMT01.Text + " 為 奇數"
            Case "N"
                Mans = T_AMT01.Text + " 為 偶數"
            Case Else
                Mans = Mchk
        End Select
        MsgBox(Mans, 0 + 64, "OK")
        Me.TopMost = True
    End Sub

    ' 匯出中文字元
    ' 參數1 → 字數、 參數2 → 起始碼（可省略）
    Private Sub B_ChineseCHR_Click(sender As Object, e As EventArgs) Handles B_ChineseCHR.Click
        If Strings.Trim(T_QTY.Text) = "" Then
            MsgBox("請輸入字數", 0 + 16, "Error")
            T_QTY.Focus()
            Exit Sub
        End If
        Dim O_01 As New TaipeiVB.MyClass01
        Dim Mresult As String = ""
        If T_StartCode.Text = "" Then
            Mresult = O_01.ChineseCHR(T_QTY.Text)
        Else
            Mresult = O_01.ChineseCHR(T_QTY.Text, T_StartCode.Text)
        End If
        L_Parameter.Text = Mresult
    End Sub

    ' 轉成國幣金額
    Private Sub B_NTD_Click(sender As Object, e As EventArgs) Handles B_NTD.Click
        If Strings.Trim(T_AMT01.Text) = "" Then
            MsgBox("請輸入阿拉數字", 0 + 16, "Error")
            T_AMT01.Focus()
            Exit Sub
        End If
        Dim O_01 As New TaipeiVB.MyClass01
        Dim Mresult As String
        Mresult = O_01.NTD(T_AMT01.Text)
        T_USD.Text = Mresult
    End Sub
End Class