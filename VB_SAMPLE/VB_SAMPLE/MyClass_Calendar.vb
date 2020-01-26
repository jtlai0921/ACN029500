Public Class MyClass_Calendar
    Inherits DateTimePicker

    ' 使用 New 關鍵字來建構函式，在函式內可設定屬性的初始值
    Public Sub New()
        Me.Font = New Font("微軟正黑體", 11)
        MaxDate = "9998/12/31"
        MinDate = "1753/01/01"
        CalendarTitleBackColor = Color.DarkBlue
        CalendarTitleForeColor = Color.White
        CalendarFont = New Font("微軟正黑體", 11)
        CalendarForeColor = Color.Navy
        CalendarMonthBackground = Color.White
        CalendarTrailingForeColor = Color.Brown
        Format = DateTimePickerFormat.Long
        Me.Width = 156
        Value = Now
        Me.ForeColor = Color.Navy
        Me.BackColor = Color.White
    End Sub

End Class
