Imports System.Threading

Public Class F_menu

    ' 1. 按鈕的程式 ******************************************************************************************************************************

    Private Sub B_05_Click(sender As Object, e As EventArgs)
        Me.Hide()
        F_TempFile.Show()
    End Sub

    Private Sub B_Layout1_Click(sender As Object, e As EventArgs) Handles B_Layout1.Click
        Me.Hide()
        F_Layout.Show()
    End Sub

    Private Sub B_Color_Click(sender As Object, e As EventArgs) Handles B_Color.Click
        Me.Hide()
        F_Color.Show()
    End Sub

    Private Sub B_08_Click(sender As Object, e As EventArgs) Handles B_08.Click
        Me.Hide()
        F_Input_1.Show()
    End Sub

    Private Sub B_09_Click(sender As Object, e As EventArgs) Handles B_09.Click
        Me.Hide()
        F_Query_1.Show()
    End Sub

    Private Sub B_10_Click(sender As Object, e As EventArgs) Handles B_10.Click
        Me.Hide()
        F_Backgroundwork.Show()
    End Sub

    Private Sub B_Layout2_Click(sender As Object, e As EventArgs) Handles B_Layout2.Click
        Me.Hide()
        F_Layout_2.Show()
    End Sub

    Private Sub B_SQL01_Click(sender As Object, e As EventArgs) Handles B_SQL01.Click
        Me.Hide()
        F_SQL01.Show()
    End Sub

    Private Sub B_SQLLogin_Click(sender As Object, e As EventArgs) Handles B_SQLLogin.Click
        Me.Hide()
        F_SQL_Login.Show()
    End Sub

    Private Sub B_ACCESS01_Click(sender As Object, e As EventArgs) Handles B_ACCESS01.Click
        Me.Hide()
        F_ACCESS01.Show()
    End Sub

    Private Sub B_ACCESS02_Click(sender As Object, e As EventArgs) Handles B_ACCESS02.Click
        Me.Hide()
        F_ACCESS02.Show()
    End Sub

    Private Sub B_FileSystem_Click(sender As Object, e As EventArgs) Handles B_FileSystem.Click
        Me.Hide()
        F_FileSystem.Show()
    End Sub

    Private Sub B_SQL02_Click(sender As Object, e As EventArgs) Handles B_SQL02.Click
        Me.Hide()
        F_SQL02.Show()
    End Sub

    Private Sub B_EXCEL01_Click(sender As Object, e As EventArgs) Handles B_EXCEL01.Click
        Me.Hide()
        F_EXCEL01.Show()
    End Sub

    Private Sub MyClass_ButtonGeneral2_Click(sender As Object, e As EventArgs) Handles B_Query.Click
        Me.Hide()
        F_Query.Show()
    End Sub

    Private Sub B_QueryAdvanced_Click(sender As Object, e As EventArgs) Handles B_QueryAdvanced.Click
        Me.Hide()
        F_QueryAdvanced.Show()
    End Sub

    Private Sub B_TableMaint_Click(sender As Object, e As EventArgs) Handles B_TableMaint.Click
        Me.Hide()
        F_TableMaintMenu.Show()
    End Sub

    Private Sub B_Chart_Click(sender As Object, e As EventArgs) Handles B_Chart.Click
        Me.Hide()
        F_chart.Show()
    End Sub

    Private Sub B_DLL01_Click(sender As Object, e As EventArgs) Handles B_DLL01.Click
        Me.Hide()
        F_DLL01.Show()
    End Sub

    Private Sub B_DLL02_Click_1(sender As Object, e As EventArgs) Handles B_DLL02.Click
        Me.Hide()
        F_DLL.Show()
    End Sub

    Private Sub B_Class01_Click(sender As Object, e As EventArgs) Handles B_Class01.Click
        Me.Hide()
        F_Class01.Show()
    End Sub

    Private Sub B_11_Click(sender As Object, e As EventArgs) Handles B_11.Click
        Me.Hide()
        F_Query_2.Show()
    End Sub

    Private Sub B_12_Click(sender As Object, e As EventArgs) Handles B_12.Click
        Me.Hide()
        F_Query_3.Show()
    End Sub

    Private Sub B_13_Click(sender As Object, e As EventArgs) Handles B_13.Click
        Me.Hide()
        F_Query_5.Show()
    End Sub

    Private Sub B_TempFile_Click(sender As Object, e As EventArgs) Handles B_TempFile.Click
        Me.Hide()
        F_TempFile.Show()
    End Sub

    ' 2. 功能表的程式 ******************************************************************************************************************************

    Private Sub Z_Exit_Click(sender As Object, e As EventArgs) Handles Z_Exit.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            Application.Exit()
        Else
            Return
        End If
    End Sub

    Private Sub C1_Click(sender As Object, e As EventArgs) Handles C1.Click
        Me.Hide()
        F_Input_1.Show()
    End Sub

    Private Sub C2_Click(sender As Object, e As EventArgs) Handles C2.Click
        Me.Hide()
        F_Query_1.Show()
    End Sub

    Private Sub C3_Click(sender As Object, e As EventArgs) Handles C3.Click
        Me.Hide()
        F_Query_2.Show()
    End Sub

    Private Sub C4_Click(sender As Object, e As EventArgs) Handles C4.Click
        Me.Hide()
        F_Query_3.Show()
    End Sub

    Private Sub C5_Click(sender As Object, e As EventArgs) Handles C5.Click
        Me.Hide()
        F_Query_5.Show()
    End Sub

    Private Sub D0_Click(sender As Object, e As EventArgs) Handles D0.Click
        Me.Hide()
        F_SQL_Login.Show()
    End Sub

    Private Sub D1_Click(sender As Object, e As EventArgs) Handles D1.Click
        Me.Hide()
        F_SQL01.Show()
    End Sub

    Private Sub D2_Click(sender As Object, e As EventArgs) Handles D2.Click
        Me.Hide()
        F_ACCESS01.Show()
    End Sub

    Private Sub D3_Click(sender As Object, e As EventArgs) Handles D3.Click
        Me.Hide()
        F_ACCESS02.Show()
    End Sub

    Private Sub D4_Click(sender As Object, e As EventArgs) Handles D4.Click
        Me.Hide()
        F_SQL02.Show()
    End Sub

    Private Sub D5_Click(sender As Object, e As EventArgs) Handles D5.Click
        Me.Hide()
        F_FileSystem.Show()
    End Sub

    Private Sub D6_Click(sender As Object, e As EventArgs) Handles D6.Click
        Me.Hide()
        F_EXCEL01.Show()
    End Sub

    Private Sub E1_Click(sender As Object, e As EventArgs) Handles E1.Click
        Me.Hide()
        F_Query.Show()
    End Sub

    Private Sub E2_Click(sender As Object, e As EventArgs) Handles E2.Click
        Me.Hide()
        F_Backgroundwork.Show()
    End Sub

    Private Sub E3_Click(sender As Object, e As EventArgs) Handles E3.Click
        Me.Hide()
        F_QueryAdvanced.Show()
    End Sub

    Private Sub E4_Click(sender As Object, e As EventArgs) Handles E4.Click
        Me.Hide()
        F_TableMaintMenu.Show()
    End Sub

    Private Sub E5_Click(sender As Object, e As EventArgs) Handles E5.Click
        Me.Hide()
        F_chart.Show()
    End Sub

    Private Sub F1_Click(sender As Object, e As EventArgs) Handles F1.Click
        Me.Hide()
        F_Class01.Show()
    End Sub

    Private Sub F2_Click(sender As Object, e As EventArgs) Handles F2.Click
        Me.Hide()
        F_DLL01.Show()
    End Sub

    Private Sub F3_Click(sender As Object, e As EventArgs) Handles F3.Click
        Me.Hide()
        F_DLL.Show()
    End Sub

    Private Sub G1_Click(sender As Object, e As EventArgs) Handles G1.Click
        Me.Hide()
        F_Color.Show()
    End Sub

    Private Sub G2_Click(sender As Object, e As EventArgs) Handles G2.Click
        Me.Hide()
        F_Layout.Show()
    End Sub

    Private Sub G3_Click(sender As Object, e As EventArgs) Handles G3.Click
        Me.Hide()
        F_Layout_2.Show()
    End Sub

    Private Sub G4_Click(sender As Object, e As EventArgs) Handles G4.Click
        Me.Hide()
        F_TempFile.Show()
    End Sub

    ' 3. 表單快顯功能表的程式 *********************************************************************************************************
    ' 隱藏功能表、顯示表頭、表頭上移
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        MenuStrip1.Visible = False
        PictureBox1.Visible = True
        PictureBox1.Location = New Point(255, 10)
    End Sub

    ' 顯示功能表、隱藏表頭、表頭歸位
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        MenuStrip1.Visible = True
        PictureBox1.Visible = False
        PictureBox1.Location = New Point(255, 50)
    End Sub

    ' 載入本表單時，顯示功能表、隱藏表頭
    Private Sub F_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Visible = True
        PictureBox1.Visible = False
    End Sub

    ' 結束
    Private Sub B_Exit_Click(sender As Object, e As EventArgs) Handles B_Exit.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本系統嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Application.Exit()
        Else
            Return
        End If
    End Sub
End Class