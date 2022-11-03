Public Class Form1

    Private Function convertQPToByteArray(ByVal qpString As String) As Byte()
        Dim c As Integer = 0
        Dim i As Integer = 0

        While i < qpString.Length
            If qpString(i) = "="c Then i += 2
            i += 1
            c += 1
        End While

        Dim binaryData As Byte() = New Byte(c - 1) {}
        Dim zero As Integer = Convert.ToInt16("0"c)
        c = 0
        i = 0

        While i < qpString.Length

            If qpString(i) = "="c Then
                binaryData(c) = CByte(Integer.Parse(qpString.Substring(i + 1, 2), System.Globalization.NumberStyles.HexNumber))
                i += 2
            Else
                binaryData(c) = Convert.ToByte(qpString(i))
            End If

            i += 1
            c += 1
        End While

        Return binaryData

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\temp\DrugQrCode.txt")
        Dim data As Byte()
        data = convertQPToByteArray(fileReader)
        Dim message As String = "Text Length = " + data.Count().ToString() + vbLf
        Dim myByte() As Byte = data
        Dim i As Int16 = 0
        For Each x In myByte
            i += 1
            If i = 33 Then
                Dim separator = Mid(fileReader, i, 1)
            End If
            message += i.ToString("####") + " - " + Mid(fileReader, i, 1) + vbLf
        Next
        MessageBox.Show(message)
    End Sub

End Class