Imports System
Imports System.IO

Module Program

    Sub Main(args As String())
        Dim value As String
        Console.Write("Enter String: ")
        value = Console.ReadLine()
        Dim strFile As String = "C:\temp\DrugQrCode.txt"
        Dim fileExists As Boolean = File.Exists(strFile)
        Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
            sw.WriteLine(value)
        End Using
    End Sub

End Module