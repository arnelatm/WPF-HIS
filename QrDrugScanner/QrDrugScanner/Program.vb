Imports System
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Program

    Sub Main(args As String())
        Dim value As String = Nothing
        Dim strFile As String = "C:\temp\DrugQrCode.txt"
        Dim fileExists As Boolean = File.Exists(strFile)
        If fileExists Then
            File.Delete(strFile)
        End If
        While True
            Console.Write("Please Scan Drug's QRCode : ")
            value = Console.ReadLine()
            Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
                sw.WriteLine(value)
            End Using
            Exit While
        End While
    End Sub

End Module