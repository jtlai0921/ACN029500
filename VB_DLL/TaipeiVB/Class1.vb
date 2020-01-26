Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports System.Text

Public Class MyClass01
    Public VSDT10RES As String
    Public VSDT100RES As String
    Public VSDTDECRES As String
    Public VLASTAND As String
    Public VTEMP As String
    Public VTEMPA As String
    Public VCHKAND As String
    Public VTEMPDEC As String
    Public VGROUP As Integer
    Public VLEN As Integer
    Public VTEMP100 As String
    Public VTEMP10 As String
    Public VRES As String

    ' 判斷奇偶數
    Public Function IsOddNo(ByVal MtempNO As Object)
        If Information.IsNumeric(MtempNO) = False Then
            'IsOddNo = "Sorry, 非數字，無法判斷！"
            Return "Sorry, 非數字，無法判斷！"
            Exit Function
        End If
        If Math.Ceiling(Convert.ToDouble(MtempNO)) <> Convert.ToDouble(MtempNO) Then
            'IsOddNo = "Sorry, 非整數，無法判斷！"
            Return "Sorry, 非整數，無法判斷！"
            Exit Function
        End If
        Dim Mresult As Double = Convert.ToDouble(MtempNO) Mod 2
        If Mresult = 0 Then
            'IsOddNo = "N"
            Return "N"
        Else
            'IsOddNo = "Y"
            Return "Y"
        End If
    End Function

    ' 傳回 Unicode 中文字碼指標對照表，多載之一，一個參數（字元數量）
    Public Overloads Function ChineseCHR(ByVal MQTY As Object)
        If Information.IsNumeric(MQTY) = False Then
            MsgBox("Sorry, 非數字，無法處理！", 0 + 16, "Error")
            ChineseCHR = ""
            Exit Function
        End If
        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If
        If System.IO.File.Exists("D:\TestQuery\TestCHR.csv") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestCHR.csv")
        End If
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("D:\TestQuery\TestCHR.csv", False, Encoding.UTF8)

        ' Unicode 中文字碼指標的範圍 19968～40907，共計 20940 字（內含8個保留指標）
        ' 若 User 指定的字元數小於 1，則迴圈終值設為1（只產生 1 個字元），
        ' 若 User 指定的字元數大於 20940，則迴圈終值設為20939（產生 20940 個字元），
        ' 若 User 指定的字元數大於等於 1 且 小於等於 20940，則迴圈終值設以 User 指定為準（產生 User 指定數量的字元），
        ' 字碼指標自 19968 開始
        Dim Mstop As Integer
        Dim MStartNo As Integer = 19968
        Select Case Convert.ToInt64(MQTY)
            Case Is < 1
                Mstop = 1
            Case Is > 20940
                Mstop = 20940 - 1
            Case 1 To 20940
                Mstop = Convert.ToInt64(MQTY) - 1
        End Select
        Dim Mcolstr As String = ""
        For Mrow = 0 To Mstop Step 1
            Mcolstr = ""
            For Mcol = 0 To 1 Step 1
                If Mcol = 1 Then
                    Mcolstr = Strings.ChrW(MStartNo + Mrow) + Chr(13) + Chr(10)
                Else
                    Mcolstr = (MStartNo + Mrow).ToString + ","
                End If
                O_file.Write(Mcolstr)
            Next
        Next
        O_file.Close()
        MsgBox("資料已寫入 D:\TestQuery\TestCHR.csv ！", 0 + 64, "OK")
        ChineseCHR = "1 個參數"

    End Function

    ' 傳回 Unicode 字碼指標對照表，多載之二，兩個參數（字元數量及起始字碼）
    Public Overloads Function ChineseCHR(ByVal MQTY As Object, ByVal MSTARTCODE As Object)
        If Information.IsNumeric(MQTY) = False Then
            MsgBox("Sorry, 非數字，無法處理！", 0 + 16, "Error")
            ChineseCHR = ""
            Exit Function
        End If
        If Information.IsNumeric(MSTARTCODE) = False Then
            MsgBox("Sorry, 第二參數非數字，無法處理！", 0 + 16, "Error")
            ChineseCHR = ""
            Exit Function
        End If

        If My.Computer.FileSystem.DirectoryExists("D:\TestQuery") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TestQuery")
        End If
        If System.IO.File.Exists("D:\TestQuery\TestCHR.csv") = True Then
            My.Computer.FileSystem.DeleteFile("D:\TestQuery\TestCHR.csv")
        End If
        Dim O_file = My.Computer.FileSystem.OpenTextFileWriter("D:\TestQuery\TestCHR.csv", False, Encoding.UTF8)

        ' Unicode 中文字碼指標的範圍 19968～40907，共計 20940 字（內含8個保留指標）
        ' 若 User 指定的字元數小於 1，則迴圈終值設為1（只產生 1 個字元），
        ' 若 User 指定的字元數大於 20940，則迴圈終值設為20939（產生 20940 個字元），
        ' 若 User 指定的字元數大於等於 1 且 小於等於 20940，則迴圈終值設以 User 指定為準（產生 User 指定數量的字元），
        ' 若 User 指定的字碼指標小於 19968， 則字碼指標自 19968 開始，
        ' 若 User 指定的字碼指標大於 40907， 則字碼指標自 40907 開始，
        ' 若 User 指定的字碼指標大於等於 19968 且 小於等於 40907， 則起始字碼指標以 User 指定的為準
        ' 當字碼指標＋迴圈遞增值大於 40907，則須離開迴圈，以免產生非中文字元
        Dim Mstop As Integer
        Dim MStartNo As Integer
        Select Case Convert.ToInt64(MQTY)
            Case Is < 1
                Mstop = 1
            Case Is > 20940
                Mstop = 20940 - 1
            Case 1 To 20940
                Mstop = Convert.ToInt64(MQTY) - 1
        End Select
        Select Case Convert.ToInt64(MSTARTCODE)
            Case Is < 19968
                MStartNo = 19968
            Case Is > 40907
                MStartNo = 40907
            Case 19968 To 40907
                MStartNo = Convert.ToInt64(MSTARTCODE)
        End Select
        Dim Mcolstr As String = ""
        For Mrow = 0 To Mstop Step 1
            If MStartNo + Mrow > 40907 Then
                Exit For
            End If
            Mcolstr = ""
            For Mcol = 0 To 1 Step 1
                If Mcol = 1 Then
                    Mcolstr = Strings.ChrW(MStartNo + Mrow) + Chr(13) + Chr(10)
                Else
                    Mcolstr = (MStartNo + Mrow).ToString + ","
                End If
                O_file.Write(Mcolstr)
            Next
        Next
        O_file.Close()
        MsgBox("資料已寫入 D:\TestQuery\TestCHR.csv ！", 0 + 64, "OK")
        ChineseCHR = "2 個參數"
    End Function

    ' 阿拉伯數字轉成英文金額
    ' 本程序以合約或支票上上的書寫為準，故全部大寫
    ' 第二個參數為選擇性，若省略，則設為1（末尾加 ONLY），若輸入非數字，則設為1（末尾加 ONLY），
    ' 若輸入數字，但不是 0，則設為1（末尾加 ONLY），若輸入 0，則末尾不加 ONLY
    Public Function USD(ByVal AAA As Object, Optional ByVal BBB As Object = 1)
        If Information.IsNumeric(AAA) = False Then
            USD = "必須輸入阿拉數字"
            Exit Function
        End If
        If AAA <= 0 Or AAA > 999999999999.99 Then
            USD = "數值超過範圍"
            Exit Function
        End If
        Dim MchkBBB As Integer
        If BBB = Nothing Then
            MchkBBB = 1
        Else
            If Information.IsNumeric(BBB) = False Then
                MchkBBB = 1
            Else
                If BBB <> 0 Then
                    MchkBBB = 1
                Else
                    MchkBBB = 0
                End If
            End If
        End If

        VTEMP = Strings.Trim(AAA).ToString
        Dim MTempString As String = Format(Convert.ToDouble(AAA), "0.00")
        Dim Mlen As Integer = Strings.Len(MTempString)
        VTEMPA = StrDup(15 - Mlen, "0") + MTempString
        VTEMP = Strings.Left(VTEMPA, 12)
        VTEMPDEC = Strings.Right(VTEMPA, 2)
        VRES = ""
        VLEN = Len(VTEMP)

        VLASTAND = "N"
        For COU = 1 To 10 Step 3
            VGROUP = Convert.ToInt64(Strings.Mid(VTEMP, COU, 3))
            If COU = 1 Then
                VLASTAND = "N"
            Else
                If Convert.ToInt64(Strings.Left(VTEMP, COU - 1)) > 0 Then
                    VLASTAND = "Y"
                End If
            End If
            VCHKAND = "N"
            VTEMP100 = Strings.Mid(VTEMP, COU, 1)
            VTEMP10 = Strings.Mid(VTEMP, COU + 1, 2)
            Call SDT100(Convert.ToInt64(VTEMP100))
            Call SDT10(Convert.ToInt64(VTEMP10))
            If VGROUP <> 0 Then
                Select Case COU
                    Case 1
                        VRES = VRES + " BILLION"
                    Case 4
                        VRES = VRES + " MILLION"
                    Case 7
                        VRES = VRES + " THOUSAND"
                End Select
            End If
        Next
        If Convert.ToInt64(VTEMP) <> 0 Then
            If Convert.ToInt64(VTEMP) = 1 Then
                VRES = VRES + " DOLLAR"
            Else
                VRES = VRES + " DOLLARS"
            End If
        End If
        If Convert.ToInt64(VTEMPDEC) > 0 Then
            Call SDTDEC(Convert.ToInt64(VTEMPDEC))
        End If
        If MchkBBB = 0 Then
            USD = Strings.LTrim(VRES)
        Else
            USD = Strings.LTrim(VRES) + " ONLY."
        End If
    End Function

    Sub SDT100(VSDT100STR As Integer)
        Select Case VSDT100STR
            Case 0
                Exit Sub
            Case 1
                VSDT100RES = " ONE"
            Case 2
                VSDT100RES = " TWO"
            Case 3
                VSDT100RES = " THREE"
            Case 4
                VSDT100RES = " FOUR"
            Case 5
                VSDT100RES = " FIVE"
            Case 6
                VSDT100RES = " SIX"
            Case 7
                VSDT100RES = " SEVEN"
            Case 8
                VSDT100RES = " EIGHT"
            Case 9
                VSDT100RES = " NINE"
        End Select
        VCHKAND = "Y"
        VRES = VRES + VSDT100RES + " HUNDRED"
    End Sub

    Sub SDT10(VSDT10STR As Integer)
        If VSDT10STR < 20 Then
            Select Case VSDT10STR
                Case 0
                    Exit Sub
                Case 1
                    VSDT10RES = " ONE"
                Case 2
                    VSDT10RES = " TWO"
                Case 3
                    VSDT10RES = " THREE"
                Case 4
                    VSDT10RES = " FOUR"
                Case 5
                    VSDT10RES = " FIVE"
                Case 6
                    VSDT10RES = " SIX"
                Case 7
                    VSDT10RES = " SEVEN"
                Case 8
                    VSDT10RES = " EIGHT"
                Case 9
                    VSDT10RES = " NINE"
                Case 10
                    VSDT10RES = " TEN"
                Case 11
                    VSDT10RES = " ELEVEN"
                Case 12
                    VSDT10RES = " TWELVE"
                Case 13
                    VSDT10RES = " THIRTEEN"
                Case 14
                    VSDT10RES = " FOURTEEN"
                Case 15
                    VSDT10RES = " FIFTEEN"
                Case 16
                    VSDT10RES = " SIXTEEN"
                Case 17
                    VSDT10RES = " SEVENTEEN"
                Case 18
                    VSDT10RES = " EIGHTEEN"
                Case 19
                    VSDT10RES = " NINETEEN"
            End Select
            If VCHKAND = "Y" Then
                VRES = VRES + " AND" + VSDT10RES
            Else
                If VLASTAND = "Y" Then
                    VRES = VRES + " AND" + VSDT10RES
                    VLASTAND = "N"
                Else
                    VRES = VRES + VSDT10RES
                End If
            End If
        Else
            Select Case Convert.ToInt64(Strings.Left(VSDT10STR, 1))
                Case 2
                    VSDT10RES = " TWENTY"
                Case 3
                    VSDT10RES = " THIRTY"
                Case 4
                    VSDT10RES = " FORTY"
                Case 5
                    VSDT10RES = " FIFTY"
                Case 6
                    VSDT10RES = " SIXTY"
                Case 7
                    VSDT10RES = " SEVENTY"
                Case 8
                    VSDT10RES = " EIGHTY"
                Case 9
                    VSDT10RES = " NINETY"
            End Select
            Select Case Convert.ToInt64(Strings.Right(VSDT10STR, 1))
                Case 0
                    VSDT10RES = VSDT10RES
                Case 1
                    VSDT10RES = VSDT10RES + " ONE"
                Case 2
                    VSDT10RES = VSDT10RES + " TWO"
                Case 3
                    VSDT10RES = VSDT10RES + " THREE"
                Case 4
                    VSDT10RES = VSDT10RES + " FOUR"
                Case 5
                    VSDT10RES = VSDT10RES + " FIVE"
                Case 6
                    VSDT10RES = VSDT10RES + " SIX"
                Case 7
                    VSDT10RES = VSDT10RES + " SEVEN"
                Case 8
                    VSDT10RES = VSDT10RES + " EIGHT"
                Case 9
                    VSDT10RES = VSDT10RES + " NINE"
            End Select
            If VCHKAND = "Y" Then
                VRES = VRES + " AND" + VSDT10RES
            Else
                If VLASTAND = "Y" Then
                    VRES = VRES + " AND" + VSDT10RES
                    VLASTAND = "N"
                Else
                    VRES = VRES + VSDT10RES
                End If
            End If
        End If
    End Sub

    Sub SDTDEC(VSDTDECSTR As Integer)
        If VSDTDECSTR < 20 Then
            Select Case VSDTDECSTR
                Case 0
                    Exit Sub
                Case 1
                    VSDTDECRES = " ONE"
                Case 2
                    VSDTDECRES = " TWO"
                Case 3
                    VSDTDECRES = " THREE"
                Case 4
                    VSDTDECRES = " FOUR"
                Case 5
                    VSDTDECRES = " FIVE"
                Case 6
                    VSDTDECRES = " SIX"
                Case 7
                    VSDTDECRES = " SEVEN"
                Case 8
                    VSDTDECRES = " EIGHT"
                Case 9
                    VSDTDECRES = " NINE"
                Case 10
                    VSDTDECRES = " TEN"
                Case 11
                    VSDTDECRES = " ELEVEN"
                Case 12
                    VSDTDECRES = " TWELVE"
                Case 13
                    VSDTDECRES = " THIRTEEN"
                Case 14
                    VSDTDECRES = " FOURTEEN"
                Case 15
                    VSDTDECRES = " FIFTEEN"
                Case 16
                    VSDTDECRES = " SIXTEEN"
                Case 17
                    VSDTDECRES = " SEVENTEEN"
                Case 18
                    VSDTDECRES = " EIGHTEEN"
                Case 19
                    VSDTDECRES = " NINETEEN"
            End Select
            If Convert.ToInt64(VTEMP) = 0 Then
                If VSDTDECSTR = 1 Then
                    VRES = VSDTDECRES + " CENT"
                Else
                    VRES = VSDTDECRES + " CENTS"
                End If
            Else
                If VSDTDECSTR = 1 Then
                    VRES = VRES + " AND CENT" + VSDTDECRES
                Else
                    VRES = VRES + " AND CENTS" + VSDTDECRES
                End If
            End If
        Else
            Select Case Convert.ToInt64(Strings.Left(VSDTDECSTR, 1))
                Case 2
                    VSDTDECRES = " TWENTY"
                Case 3
                    VSDTDECRES = " THIRTY"
                Case 4
                    VSDTDECRES = " FORTY"
                Case 5
                    VSDTDECRES = " FIFTY"
                Case 6
                    VSDTDECRES = " SIXTY"
                Case 7
                    VSDTDECRES = " SEVENTY"
                Case 8
                    VSDTDECRES = " EIGHTY"
                Case 9
                    VSDTDECRES = " NINETY"
            End Select
            Select Case Convert.ToInt64(Strings.Right(VSDTDECSTR, 1))
                Case 0
                    VSDTDECRES = VSDTDECRES
                Case 1
                    VSDTDECRES = VSDTDECRES + " ONE"
                Case 2
                    VSDTDECRES = VSDTDECRES + " TWO"
                Case 3
                    VSDTDECRES = VSDTDECRES + " THREE"
                Case 4
                    VSDTDECRES = VSDTDECRES + " FOUR"
                Case 5
                    VSDTDECRES = VSDTDECRES + " FIVE"
                Case 6
                    VSDTDECRES = VSDTDECRES + " SIX"
                Case 7
                    VSDTDECRES = VSDTDECRES + " SEVEN"
                Case 8
                    VSDTDECRES = VSDTDECRES + " EIGHT"
                Case 9
                    VSDTDECRES = VSDTDECRES + " NINE"
            End Select
            If Convert.ToInt64(VTEMP) = 0 Then
                VRES = VSDTDECRES + " CENTS"
            Else
                VRES = VRES + " AND CENTS" + VSDTDECRES
            End If
        End If
    End Sub

    '  字串比對
    Public Function InList(ByVal MchkString As String, ByVal ParamArray Astrings() As String)
        InList = "N"
        For Each MMM As Object In Astrings
            If MMM = MchkString Then
                InList = "Y"
                Exit For
            End If
        Next
    End Function

    ' 國幣轉換
    Public Function NTD(ByVal UserDollar As Object)
        If IsNumeric(UserDollar) = False Then
            Return "必須為數字"
            Exit Function
        End If

        Dim MUserDollar As Double
        Dim MTempDollar As Double
        MUserDollar = CDbl(UserDollar)
        MTempDollar = Math.Abs(MUserDollar)
        MTempDollar = Math.Round(MTempDollar, 2)

        Dim VSTR As String = ""
        VSTR = Strings.Format(MTempDollar, "#.00")
        If Len(VSTR) > 15 Then
            Return "數字最多 12 位（千億），小數最多 2 位"
            Exit Function
        End If

        Dim ACHA(9) As String
        ACHA(1) = "壹"
        ACHA(2) = "貳"
        ACHA(3) = "參"
        ACHA(4) = "肆"
        ACHA(5) = "伍"
        ACHA(6) = "陸"
        ACHA(7) = "柒"
        ACHA(8) = "捌"
        ACHA(9) = "玖"

        Dim APOS(11) As String
        APOS(1) = "拾"
        APOS(2) = "佰"
        APOS(3) = "仟"
        APOS(4) = "萬"
        APOS(5) = "拾"
        APOS(6) = "佰"
        APOS(7) = "仟"
        APOS(8) = "億"
        APOS(9) = "拾"
        APOS(10) = "佰"
        APOS(11) = "仟"

        Dim VRES As String = ""
        Dim VZERO As String = "B"
        Dim VZEROA As Integer = 0
        Dim VLEN As Integer = Strings.Len(VSTR) - 3
        Dim VSTOP As Integer = VLEN

        For COU = 1 To VSTOP
            If VLEN - COU + 1 < 9 And VLEN - COU + 1 > 4 And Convert.ToInt64(Strings.Mid(VSTR, COU, 1)) = 0 Then
                VZEROA = VZEROA + 1
            End If

            If Convert.ToInt64(Strings.Mid(VSTR, COU, 1)) = 0 And VLEN - COU + 1 = 9 Then
                VRES = VRES + "億"
            End If

            If Convert.ToInt64(Strings.Mid(VSTR, COU, 1)) = 0 And VLEN - COU + 1 = 5 Then
                If VLEN < 9 Then
                    VRES = VRES + "萬"
                Else
                    If VZEROA = 4 Then
                        VRES = VRES
                    Else
                        VRES = VRES + "萬"
                    End If
                End If
            End If

            If Convert.ToInt64(Strings.Mid(VSTR, COU, 1)) <> 0 Then
                If VZERO = "A" Then
                    VRES = VRES + "零"
                    VZERO = "B"
                End If
                VRES = VRES + ACHA(Convert.ToInt64(Strings.Mid(VSTR, COU, 1)))

                If VLEN - COU + 1 = 1 Then
                    Exit For
                End If
                VRES = VRES + APOS(VLEN - COU)
            Else
                VZERO = "A"
            End If
        Next

        If Math.Abs(MUserDollar) < 1 Then
            VRES = VRES
        Else
            VRES = VRES + "元"
        End If

        If Convert.ToInt64(Strings.Right(VSTR, 2)) <> 0 Then
            If Convert.ToInt64(Strings.Mid(VSTR, VLEN + 2, 1)) <> 0 Then
                If Math.Abs(MTempDollar) > 1 Then
                    VRES = VRES + "零"
                End If
                VRES = VRES + ACHA(Convert.ToInt64(Strings.Mid(VSTR, VLEN + 2, 1))) + "角"
                If Convert.ToInt64(Strings.Mid(VSTR, VLEN + 3, 1)) <> 0 Then
                    VRES = VRES + ACHA(Convert.ToInt64(Strings.Mid(VSTR, VLEN + 3, 1))) + "分"
                End If
            End If
            If Convert.ToInt64(Strings.Mid(VSTR, VLEN + 2, 1)) = 0 Then
                If Math.Abs(MTempDollar) > 1 Then
                    VRES = VRES + "零"
                End If
                If Convert.ToInt64(Strings.Mid(VSTR, VLEN + 3, 1)) <> 0 Then
                    VRES = VRES + ACHA(Convert.ToInt64(Strings.Mid(VSTR, VLEN + 3, 1))) + "分"
                End If
            End If
        End If
        If UserDollar < 0 Then
            VRES = "負" + VRES
        End If
        If UserDollar = 0 Then
            VRES = "零元"
        End If
        VRES = "新台幣" + VRES + "正"
        NTD = VRES
    End Function

End Class