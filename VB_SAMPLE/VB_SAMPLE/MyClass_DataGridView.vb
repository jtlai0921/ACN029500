Public Class MyClass_DataGridView
    Inherits DataGridView

    Public Sub New()
        ' 欄位名稱字體、顏色、置中
        Me.EnableHeadersVisualStyles = False
        With ColumnHeadersDefaultCellStyle
            .Font = New Font("微軟正黑體", 10)
            .ForeColor = Color.White
            .BackColor = Color.DarkBlue
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' 各個格位之格式化
        With DefaultCellStyle
            .Font = New Font("微軟正黑體", 10)
            .ForeColor = Color.FromArgb(255, 0, 0, 128)
            .BackColor = Color.White
            .SelectionForeColor = Color.White
            .SelectionBackColor = Color.FromArgb(255, 180, 0, 90)
        End With

        ' 自動調整列高及欄寬（欄名除外或全部格位），設定各欄的名稱
        ' FullRowSelect 選取整列、CellSelect 一次只能選取一個格位、RowHeaderSelect 一次只能選取一個格位或一整列
        ' 背景色、邊框樣式、長寬、唯讀、Null 顯示值
        ' Color.Transparent 無效，故此處不設定背景色，由 User 以手動方式調成表單顏色，以消除多餘的 DataGridView 底框
        ' BorderStyle.None 不設邊框
        'Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Me.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        Me.BorderStyle = BorderStyle.None
        Me.Width = 972
        Me.Height = 264
        Me.ReadOnly = True
        Me.DefaultCellStyle.NullValue = ""

        ' 間格列的顏色
        Me.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 225, 243, 245)
        Me.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(255, 0, 0, 128)
        Me.ScrollBars = Windows.Forms.ScrollBars.Both

        ' 不允許資料網格檢視控制項增列最後一筆
        Me.AllowUserToAddRows = False
    End Sub

End Class
