Public Class F_Query_1
    Public MTempColor As String = ""

    ' 將清單1的選取項目加入清單2
    Private Sub B_Select_Click(sender As Object, e As EventArgs) Handles B_Select.Click

        ' 將清單1的選取項目加入清單2，項目不得重複
        For Each Itemname As String In ListBox1.SelectedItems
            If ListBox2.FindString(Itemname) = -1 Then
                ListBox2.Items.Add(Itemname)
            End If
        Next

        ' 將清單2的項目存入陣列，以便重新排序
        ' ListBox1.Items.Item(2) 傳回第3個項目之名稱
        Dim MTotalItems As Integer = ListBox2.Items.Count
        Dim ArrayItems(MTotalItems) As String
        For Mcou = 0 To MTotalItems - 1 Step 1
            ArrayItems(Mcou) = ListBox2.Items.Item(Mcou)
        Next

        ' 遞增排序再反轉陣列，以便遞減排序陣列
        Array.Sort(ArrayItems)
        Array.Reverse(ArrayItems)

        ' 清除清單2的全部項目，再加入陣列之值
        ListBox2.Items.Clear()
        For Mcou = 0 To MTotalItems - 1 Step 1
            ListBox2.Items.Add(ArrayItems(Mcou))
        Next

    End Sub

    ' 移除清單2的選取項目
    ' RemoveAt 需指定移除選取項目的索引編號，Remove 需指定移除選取項目的名稱 
    Private Sub B_Remove_Click(sender As Object, e As EventArgs) Handles B_Remove.Click

        ' 方法一：使用 RemoveAt 
        Do While ListBox2.SelectedIndex <> -1
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        Loop

        ' 方法二：使用 Remove
        'Dim MTotalItems As Integer = ListBox2.SelectedItems.Count
        'For Mcou = 0 To MTotalItems - 1 Step 1
        'Dim MTempItem As String = ListBox2.SelectedItem
        'ListBox2.Items.Remove(MTempItem)
        'Next

    End Sub

    ' 取消清單1的選取狀態，移除清單2的全部項目
    Private Sub B_Reset1_Click(sender As Object, e As EventArgs) Handles B_Reset1.Click
        Dim MTotalItems As Integer = ListBox1.Items.Count
        For Mcou = 0 To MTotalItems - 1 Step 1
            ListBox1.SetSelected(Mcou, False)
        Next
        ListBox2.Items.Clear()

        ' 重設表單及控制項顏色
        Me.BackgroundImage = Nothing

        Me.BackColor = Color.FromArgb(255, 217, 217, 217)
        B_Close1.BackgroundImage = Nothing
        B_Reset1.BackgroundImage = Nothing
        B_Query1.BackgroundImage = Nothing
        B_Output1.BackgroundImage = Nothing
        B_Close1.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")
        B_Reset1.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")
        B_Query1.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")
        B_Output1.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")

        B_Close1.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Reset1.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Query1.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Output1.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
        B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
        B_Query1.ForeColor = Color.FromArgb(255, 255, 255, 255)
        B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)

        B_Select.BackgroundImage = Nothing
        B_Remove.BackgroundImage = Nothing
        B_Select.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")
        B_Remove.BackgroundImage = System.Drawing.Image.FromFile("APPDATA\bgg22.jpg")
        B_Select.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Remove.BackColor = Color.FromArgb(255, 0, 0, 0)
        B_Select.ForeColor = Color.FromArgb(255, 255, 255, 255)
        B_Remove.ForeColor = Color.FromArgb(255, 255, 255, 255)
        Label1.ForeColor = Color.FromArgb(255, 0, 0, 0)
        Label2.ForeColor = Color.FromArgb(255, 0, 0, 0)
        Label3.ForeColor = Color.FromArgb(255, 0, 0, 0)
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Color.Transparent

        T_Color.Text = ""
    End Sub

    ' 變更 ListBox 選取項目的背景色
    ' 先將 DrawMode 屬性須變更為 OwnerDrawFixed 或 OwnerDrawVariable，內定為 Normal，再於 DrawItem 視覺外觀變更事件中撰寫下列程式
    ' Brushes之後接您希望的顏色，本例為 DeepPink 深粉紅
    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.DeepPink, e.Bounds)
        End If

        Using newitem As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, newitem, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub

    ' 變更選取項目的背景色及前景色 且 變更未選項目的背景色及前景色
    Private Sub ListBox2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox2.DrawItem
        If ListBox2.Items.Count = 0 Then
            Exit Sub
        End If
        Using newitem As New SolidBrush(ListBox2.ForeColor)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(Brushes.DeepPink, e.Bounds)
                newitem.Color = Color.White
            Else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds)
                newitem.Color = Color.Navy
            End If
            ' 劃出框線
            'e.Graphics.DrawRectangle(Pens.DarkBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1)
            Using sf As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap, .Trimming = StringTrimming.Character}
                e.Graphics.DrawString(ListBox2.Items(e.Index).ToString, e.Font, newitem, e.Bounds, sf)
            End Using
        End Using
    End Sub

    ' 滑鼠經過按鈕時變更前景色
    Private Sub B_Close1_MouseHover(sender As Object, e As EventArgs) Handles B_Close1.MouseHover
        B_Close1.ForeColor = Color.White
    End Sub
    Private Sub B_Reset1_MouseHover(sender As Object, e As EventArgs) Handles B_Reset1.MouseHover
        B_Reset1.ForeColor = Color.White
    End Sub
    Private Sub B_Query1_MouseHover(sender As Object, e As EventArgs) Handles B_Query1.MouseHover
        B_Query1.ForeColor = Color.White
    End Sub
    Private Sub B_Output1_MouseHover(sender As Object, e As EventArgs) Handles B_Output1.MouseHover
        B_Output1.ForeColor = Color.White
    End Sub
    Private Sub B_Select_MouseHover(sender As Object, e As EventArgs) Handles B_Select.MouseHover
        B_Select.ForeColor = Color.White
    End Sub
    Private Sub B_Remove_MouseHover(sender As Object, e As EventArgs) Handles B_Remove.MouseHover
        B_Remove.ForeColor = Color.White
    End Sub

    ' 滑鼠離開按鈕時變更前景色
    Private Sub B_Select_MouseLeave(sender As Object, e As EventArgs) Handles B_Select.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 B"
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 C"
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 D"
                B_Select.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Select.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub
    Private Sub B_Remove_MouseLeave(sender As Object, e As EventArgs) Handles B_Remove.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 B"
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 C"
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
            Case "顏色 D"
                B_Remove.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Remove.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub
    Private Sub B_Close1_MouseLeave(sender As Object, e As EventArgs) Handles B_Close1.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Close1.ForeColor = Color.FromArgb(255, 0, 0, 128)
            Case "顏色 B"
                B_Close1.ForeColor = Color.FromArgb(255, 81, 81, 0)
            Case "顏色 C"
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 D"
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub
    Private Sub B_Reset1_MouseLeave(sender As Object, e As EventArgs) Handles B_Reset1.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Reset1.ForeColor = Color.FromArgb(255, 0, 0, 128)
            Case "顏色 B"
                B_Reset1.ForeColor = Color.FromArgb(255, 81, 81, 0)
            Case "顏色 C"
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 D"
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub
    Private Sub B_Query1_MouseLeave(sender As Object, e As EventArgs) Handles B_Query1.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Query1.ForeColor = Color.FromArgb(255, 0, 0, 128)
            Case "顏色 B"
                B_Query1.ForeColor = Color.FromArgb(255, 81, 81, 0)
            Case "顏色 C"
                B_Query1.ForeColor = Color.FromArgb(255, 92, 90, 0)
            Case "顏色 D"
                B_Query1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Query1.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub
    Private Sub B_Output1_MouseLeave(sender As Object, e As EventArgs) Handles B_Output1.MouseLeave
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                B_Output1.ForeColor = Color.FromArgb(255, 0, 0, 128)
            Case "顏色 B"
                B_Output1.ForeColor = Color.FromArgb(255, 81, 81, 0)
            Case "顏色 C"
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 D"
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 E"
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)

        End Select
    End Sub

    ' 變更表單及按鈕顏色
    Private Sub T_Color_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_Color.SelectedIndexChanged
        MTempColor = T_Color.Text
        Select Case MTempColor
            Case "顏色 A"
                Me.BackgroundImage = Nothing
                Me.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Close1.BackgroundImage = Nothing
                B_Reset1.BackgroundImage = Nothing
                B_Query1.BackgroundImage = Nothing
                B_Output1.BackgroundImage = Nothing
                B_Select.BackgroundImage = Nothing
                B_Remove.BackgroundImage = Nothing

                B_Close1.BackColor = Color.FromArgb(255, 193, 235, 255)
                B_Reset1.BackColor = Color.FromArgb(255, 125, 213, 255)
                B_Query1.BackColor = Color.FromArgb(255, 193, 235, 255)
                B_Output1.BackColor = Color.FromArgb(255, 125, 213, 255)
                B_Close1.ForeColor = Color.FromArgb(255, 0, 0, 128)
                B_Reset1.ForeColor = Color.FromArgb(255, 0, 0, 128)
                B_Query1.ForeColor = Color.FromArgb(255, 0, 0, 128)
                B_Output1.ForeColor = Color.FromArgb(255, 0, 0, 128)

                B_Select.BackColor = Color.FromArgb(255, 255, 219, 202)
                B_Remove.BackColor = Color.FromArgb(255, 255, 219, 202)
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
                Label1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label2.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label3.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 B"
                Me.BackgroundImage = Nothing
                Me.BackColor = Color.FromArgb(255, 0, 128, 64)
                B_Close1.BackgroundImage = Nothing
                B_Reset1.BackgroundImage = Nothing
                B_Query1.BackgroundImage = Nothing
                B_Output1.BackgroundImage = Nothing
                B_Select.BackgroundImage = Nothing
                B_Remove.BackgroundImage = Nothing

                B_Close1.BackColor = Color.FromArgb(255, 216, 216, 177)
                B_Reset1.BackColor = Color.FromArgb(255, 216, 216, 177)
                B_Query1.BackColor = Color.FromArgb(255, 216, 216, 177)
                B_Output1.BackColor = Color.FromArgb(255, 216, 216, 177)
                B_Close1.ForeColor = Color.FromArgb(255, 81, 81, 0)
                B_Reset1.ForeColor = Color.FromArgb(255, 81, 81, 0)
                B_Query1.ForeColor = Color.FromArgb(255, 81, 81, 0)
                B_Output1.ForeColor = Color.FromArgb(255, 81, 81, 0)
                B_Select.BackColor = Color.FromArgb(255, 255, 219, 202)

                B_Remove.BackColor = Color.FromArgb(255, 255, 219, 202)
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
                Label1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label2.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label3.ForeColor = Color.FromArgb(255, 255, 255, 255)
            Case "顏色 C"
                Me.BackgroundImage = Nothing
                Me.BackColor = Color.FromArgb(255, 0, 0, 0)
                B_Close1.BackgroundImage = Nothing
                B_Reset1.BackgroundImage = Nothing
                B_Query1.BackgroundImage = Nothing
                B_Output1.BackgroundImage = Nothing
                B_Select.BackgroundImage = Nothing
                B_Remove.BackgroundImage = Nothing

                B_Close1.BackColor = Color.FromArgb(255, 255, 0, 128)
                B_Reset1.BackColor = Color.FromArgb(255, 255, 128, 0)
                B_Query1.BackColor = Color.FromArgb(255, 192, 192, 0)
                B_Output1.BackColor = Color.FromArgb(255, 51, 153, 102)
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Query1.ForeColor = Color.FromArgb(255, 92, 90, 0)
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)

                B_Select.BackColor = Color.FromArgb(255, 255, 219, 202)
                B_Remove.BackColor = Color.FromArgb(255, 255, 219, 202)
                B_Select.ForeColor = Color.FromArgb(255, 128, 64, 64)
                B_Remove.ForeColor = Color.FromArgb(255, 128, 64, 64)
                Label1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label2.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label3.ForeColor = Color.FromArgb(255, 255, 255, 255)

            Case "顏色 D"
                Me.BackgroundImage = Nothing
                Me.BackColor = Color.FromArgb(255, 191, 205, 219)
                B_Close1.BackgroundImage = Nothing
                B_Reset1.BackgroundImage = Nothing
                B_Query1.BackgroundImage = Nothing
                B_Output1.BackgroundImage = Nothing
                B_Select.BackgroundImage = Nothing
                B_Remove.BackgroundImage = Nothing

                B_Close1.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Reset1.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Query1.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Output1.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Query1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)

                B_Select.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Remove.BackColor = Color.FromArgb(255, 0, 0, 128)
                B_Select.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Remove.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label1.ForeColor = Color.FromArgb(255, 0, 0, 128)
                Label2.ForeColor = Color.FromArgb(255, 0, 0, 128)
                Label3.ForeColor = Color.FromArgb(255, 0, 0, 128)

            Case "顏色 E"
                Me.BackgroundImage = Nothing
                Me.BackColor = Color.FromArgb(255, 185, 211, 200)
                B_Close1.BackgroundImage = Nothing
                B_Reset1.BackgroundImage = Nothing
                B_Query1.BackgroundImage = Nothing
                B_Output1.BackgroundImage = Nothing
                B_Select.BackgroundImage = Nothing
                B_Remove.BackgroundImage = Nothing

                B_Close1.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Reset1.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Query1.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Output1.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Close1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Reset1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Query1.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Output1.ForeColor = Color.FromArgb(255, 255, 255, 255)

                B_Select.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Remove.BackColor = Color.FromArgb(255, 55, 87, 73)
                B_Select.ForeColor = Color.FromArgb(255, 255, 255, 255)
                B_Remove.ForeColor = Color.FromArgb(255, 255, 255, 255)
                Label1.ForeColor = Color.FromArgb(255, 55, 87, 73)
                Label2.ForeColor = Color.FromArgb(255, 55, 87, 73)
                Label3.ForeColor = Color.FromArgb(255, 55, 87, 73)

        End Select
    End Sub

    Private Sub B_Close1_Click(sender As Object, e As EventArgs) Handles B_Close1.Click
        Dim MANS As Integer
        MANS = MsgBox("您確定要離開本頁嗎？", 4 + 32 + 256, "Confirm")
        If MANS = 6 Then
            Me.Dispose()
            F_menu.Show()
        Else
            Return
        End If
    End Sub

End Class