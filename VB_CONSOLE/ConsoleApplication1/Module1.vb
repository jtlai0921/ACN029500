' 引用所需的命名空間
Imports System.IO
Imports Microsoft.VisualBasic

Module Module1
    Sub Main()
        Dim Mrate As Double
        Dim Myear As Integer
        Dim Mamt As Integer
        Dim Mpay As Integer

        ' Try陳述式，以便處理意外狀況（例如 User 輸入了文字或無效的引數，例如年數為 0）
        Try
            ' 請 User 輸入三個參數
            Console.WriteLine("請輸入貸款金額（例如 5000000）：")
            Mamt = Integer.Parse(Console.ReadLine())
            Console.WriteLine("請輸入貸款年數（例如 30）：")
            Myear = Integer.Parse(Console.ReadLine())
            Console.WriteLine("請輸入年利率（例如 0.03）：")
            Mrate = Double.Parse(Console.ReadLine())
            ' 使用 Financial 類別的 Pmt 方法計算每月應償還之金額
            Mpay = Financial.Pmt(Mrate / 12, Myear * 12, Mamt) * -1
        Catch ex As Exception
            ' 顯示錯誤訊息
            Console.WriteLine(ex.Message)
            Console.Read()
            Exit Sub
        End Try

        ' 若資料夾 D\:TEST02 不存在，則建立之
        If My.Computer.FileSystem.DirectoryExists("D\TEST02") = False Then
            My.Computer.FileSystem.CreateDirectory("D:\TEST02")
        End If
        ' 使用 StreamWriter 類別將前述資料存入檔案 Load_1.txt
        Dim MFileName = "D:\TEST02\Load_1.txt"
        Dim MSW As StreamWriter = New StreamWriter(MFileName, False)
        MSW.WriteLine("貸款金額： " + Mamt.ToString("#,0"))
        MSW.WriteLine("年利率： " + Mrate.ToString("0.000"))
        MSW.WriteLine("貸款年數： " + Myear.ToString)
        MSW.WriteLine("每月應償還金額： " + Mpay.ToString("#,0"))
        MSW.Flush()
        MSW.Close()

        ' 顯示計算結果
        Console.WriteLine("每月應償還金額： " + Mpay.ToString("#,0"))
        Console.WriteLine("計算資料已存入 D:\TEST02\Load_1.txt")
        Console.Read()
    End Sub
End Module
