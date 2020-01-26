Public Class F_Color

    ' 顯示調色盤對話方塊，供 User 挑選顏色，User 所選的顏色會作為豐富文字盒的前景色，
    ' 取回 RGB 色碼，並顯示於 T_RGB 文字盒
    Private Sub B_01_Click(sender As Object, e As EventArgs) Handles B_01.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            RichTextBox2.ForeColor = ColorDialog1.Color
            RichTextBox1.ForeColor = ColorDialog1.Color
            T_RGB.Text = ColorDialog1.Color.R.ToString + ", " + ColorDialog1.Color.G.ToString + ", " + ColorDialog1.Color.B.ToString
            Call RGB2HSB(123)
        End If
    End Sub

    ' 顯示調色盤對話方塊，供 User 挑選顏色，User 所選的顏色會作為豐富文字盒的背景色，
    ' 取回 RGB 色碼，並顯示於 T_RGB 文字盒
    Private Sub B_02_Click(sender As Object, e As EventArgs) Handles B_02.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            RichTextBox2.BackColor = ColorDialog1.Color
            T_RGB.Text = ColorDialog1.Color.R.ToString + ", " + ColorDialog1.Color.G.ToString + ", " + ColorDialog1.Color.B.ToString
            Call RGB2HSB(123)
        End If
    End Sub

    ' 水平捲軸1 拖曳時，將其位置值存入文字盒 T_R
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        T_R.Text = HScrollBar1.Value
        RichTextBox1.BackColor = Color.FromArgb(Val(T_R.Text), Val(T_G.Text), Val(T_B.Text))
        T_RGB.Text = T_R.Text.ToString + ", " + T_G.Text.ToString + ", " + T_B.Text.ToString
        Call RGB2HSB(123)
    End Sub

    ' 水平捲軸2 拖曳時，將其位置值存入文字盒 T_G
    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        T_G.Text = HScrollBar2.Value
        RichTextBox1.BackColor = Color.FromArgb(Val(T_R.Text), Val(T_G.Text), Val(T_B.Text))
        T_RGB.Text = T_R.Text.ToString + ", " + T_G.Text.ToString + ", " + T_B.Text.ToString
        Call RGB2HSB(123)
    End Sub

    ' 水平捲軸3 拖曳時，將其位置值存入文字盒 T_B
    Private Sub HScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        T_B.Text = HScrollBar3.Value
        RichTextBox1.BackColor = Color.FromArgb(Val(T_R.Text), Val(T_G.Text), Val(T_B.Text))
        T_RGB.Text = T_R.Text.ToString + ", " + T_G.Text.ToString + ", " + T_B.Text.ToString
        Call RGB2HSB(123)
    End Sub

    ' 載入本表單時將說明文字置入文字盒
    Private Sub F_Color_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = "拖曳捲軸可改變本文字框的底色"
        RichTextBox2.Text = "敲『調色盤 1』，可選取兩文字框的文字顏色。" + Chr(13) + Chr(10) + "敲『調色盤 2』，可選取本文字框的底色。"
    End Sub

    ' 使表單右上角的關閉鈕無效
    Private Sub F_Color_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    ' 自訂函式
    ' 將 T_RGB 文字盒內的 RGB 轉換成 HSB，並置入 色相、飽和度及亮度三個文字盒之內
    ' GetHue ， 色相在 HSB 色彩空間中是以度為單位來測量，範圍從 0.0 到 360.0
    ' GetSaturation ，  飽和度（彩度）範圍從 0.0 到 1.0，0.0 表示灰階，而 1.0 表示最飽和的彩度
    ' GetBrightness ， 亮度的範圍從 0.0 到 1.0，0.0 表示黑色，而 1.0 表示白色。
    Public Function RGB2HSB(Optional AAA As Integer = 123)
        Dim Mcomma01 As Integer = T_RGB.Text.IndexOf(",")
        Dim Mcomma02 As Integer = T_RGB.Text.LastIndexOf(",")
        Dim Mlen As Integer = Len(T_RGB.Text)

        Dim MTempR As Integer = Val(T_RGB.Text.Substring(0, Mcomma01))
        Dim MTempG As Integer = Val(T_RGB.Text.Substring(Mcomma01 + 1, Mcomma02 - Mcomma01))
        Dim MTempB As Integer = Val(T_RGB.Text.Substring(Mcomma02 + 1, Mlen - (Mcomma02 + 1)))
        Dim Mrgb As Color = Color.FromArgb(255, MTempR, MTempG, MTempB)

        Dim MHue As Double = Mrgb.GetHue()
        Dim MSaturation As Double = Mrgb.GetSaturation
        Dim MBrightness As Double = Mrgb.GetBrightness()
        T_hue.Text = MHue
        T_sat.Text = MSaturation
        T_bri.Text = MBrightness

        ' 重設第 4 捲動軸的位置
        HScrollBar4.Value = Math.Round(MBrightness * 1000, 0)
        Return AAA
    End Function

    ' 移動第 4 捲動軸的捲動鈕位置時（亦即調整亮度，色相及飽和度不變），將 HSB 轉成 RGB，並據以變更表單之底色
    Private Sub HScrollBar4_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar4.Scroll
        T_bri.Text = HScrollBar4.Value / 1000

        Dim MHue As Double = T_hue.Text
        Dim MSaturation As Double = T_sat.Text
        Dim MBrightness As Double = T_bri.Text
        MHue = MHue / 360
        Dim MR As Double = 0
        Dim MG As Double = 0
        Dim MB As Double = 0
        Dim Mtemp1, Mtemp2 As Double
        If MBrightness = 0 Then
            MR = 0
            MG = 0
            MB = 0
        Else
            If MSaturation = 0 Then
                MR = MBrightness
                MG = MBrightness
                MB = MBrightness
            Else
                If MBrightness <= 0.5 Then
                    Mtemp2 = MBrightness * (1 + MSaturation)
                Else
                    Mtemp2 = MBrightness + MSaturation - MBrightness * MSaturation
                End If
                Mtemp1 = 2 * MBrightness - Mtemp2
                Dim AtpHUE() As Double = {MHue + 1 / 3, MHue, MHue - 1 / 3}
                Dim AtpRGB() As Double = {0, 0, 0}
                Dim mcou As Integer
                For mcou = 0 To 2
                    If AtpHUE(mcou) < 0 Then
                        AtpHUE(mcou) = AtpHUE(mcou) + 1
                    End If
                    If AtpHUE(mcou) > 1 Then
                        AtpHUE(mcou) = AtpHUE(mcou) - 1
                    End If
                    If 6 * AtpHUE(mcou) < 1 Then
                        AtpRGB(mcou) = Mtemp1 + (Mtemp2 - Mtemp1) * AtpHUE(mcou) * 6
                    ElseIf 2 * AtpHUE(mcou) < 1 Then
                        AtpRGB(mcou) = Mtemp2
                    ElseIf 3 * AtpHUE(mcou) < 2 Then
                        AtpRGB(mcou) = Mtemp1 + (Mtemp2 - Mtemp1) * (2 / 3 - AtpHUE(mcou)) * 6
                    Else
                        AtpRGB(mcou) = Mtemp1
                    End If
                Next
                MR = AtpRGB(0)
                MG = AtpRGB(1)
                MB = AtpRGB(2)
            End If
        End If
        Me.BackColor = Color.FromArgb(CInt(255 * MR), CInt(255 * MG), CInt(255 * MB))
        T_RGB.Text = CInt(255 * MR).ToString + ", " + CInt(255 * MG).ToString + ", " + CInt(255 * MB).ToString
    End Sub

    ' 重設本表單及控制項的顏色，還原文字盒之值
    Private Sub B_Reset_Click(sender As Object, e As EventArgs) Handles B_Reset.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要清除本頁資料嗎？", 4 + 32 + 256, "Confirm")
        If MANS <> 6 Then
            Exit Sub
        End If

        Me.BackColor = Color.FromArgb(255, 0, 0, 0)
        RichTextBox1.BackColor = Color.FromArgb(255, 0, 0, 0)
        RichTextBox2.BackColor = Color.FromArgb(255, 0, 0, 0)
        RichTextBox1.ForeColor = Color.FromArgb(255, 255, 255, 255)
        RichTextBox2.ForeColor = Color.FromArgb(255, 255, 255, 255)
        HScrollBar1.Value = 0
        HScrollBar2.Value = 0
        HScrollBar3.Value = 0
        HScrollBar4.Value = 0
        T_RGB.Text = "0, 0, 0"
        T_hue.Text = 0
        T_sat.Text = 0
        T_bri.Text = 0
        T_R.Text = 0
        T_G.Text = 0
        T_B.Text = 0
    End Sub

End Class
