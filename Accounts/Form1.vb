Imports AATM.Libraries.GlobalFuncNSub

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
        Dim fileReader As String = txtBarcode.Text
        Dim dataLength = Len(fileReader)
        'Dim data As Byte()
        'data = convertQPToByteArray(fileReader)
        Dim message As String = "Text Length = " + Len(fileReader).ToString() + vbLf
        'Dim myByte() As Byte = data
        Dim i As Int16 = 0
        Dim cGTIN = Mid(fileReader, 3, 14)
        Dim ai As String = Mid(fileReader, 17, 2)
        Dim lastPosition As Int16 = 16
        Dim cSerializationNo = ""
        Dim cBatchNo = ""
        Dim yy As String = ""
        Dim mm As String = ""
        Dim dd As String = ""
        Dim separatorFound As Boolean = False
        For i = 1 To dataLength
            If Mid(fileReader, i, 1) = ChrW(29) Then
                separatorFound = True
                Exit For
            End If
        Next

        While lastPosition < dataLength
            Select Case ai
                Case "17"
                    lastPosition += 2
                    yy = Mid(fileReader, lastPosition + 1, 2)
                    mm = Mid(fileReader, lastPosition + 3, 2)
                    dd = Mid(fileReader, lastPosition + 5, 2)
                    'cExpiry = dd + "/" + mm + "/" + "20" + yy
                    'MessageBox.Show("Expiry = " + expiry)
                    lastPosition += 6
                Case "10"
                    lastPosition += 2
                    For i = lastPosition + 1 To dataLength
                        If Mid(fileReader, i, 1) = ChrW(29) Then
                            cBatchNo = Mid(fileReader, lastPosition + 1, i - lastPosition - 1)
                            lastPosition = i
                            Exit For
                        End If
                    Next
                    'MessageBox.Show("Batch No = " + batchNo)
                Case "21"
                    lastPosition += 2
                    For i = lastPosition + 1 To dataLength
                        If Mid(fileReader, i, 1) = ChrW(29) Or Mid(fileReader, i, 1) = ChrW(13) Or i >= dataLength Then
                            cSerializationNo = Mid(fileReader, lastPosition + 1, i - lastPosition - 1)
                            lastPosition = i
                            Exit For
                        End If
                    Next
                    'MessageBox.Show("Serialization No = " + serializationNo)
            End Select
            If lastPosition >= dataLength Then
                Exit While
            Else
                ai = Mid(fileReader, lastPosition + 1, 2)
                If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                    Exit While
                End If
            End If
        End While
        MessageBox.Show("GTIN = " + cGTIN + vbLf + "Expiry = " + GlobalFunctions.GbDateSerial(2000 + Val(yy), Val(mm), Val(dd)).ToString() + vbLf + "BatchNo = " + cBatchNo + vbLf + "Serialization No = " + cSerializationNo)
        MessageBox.Show(message)
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress

        Dim i As Integer = Me.txtBarcode.SelectionStart 'save for later use

        Select Case Asc(e.KeyChar)

            Case 4 'EOT

                Me.txtBarcode.Text = Me.txtBarcode.Text.Insert(Me.txtBarcode.SelectionStart, "<EOT>")

                Me.txtBarcode.SelectionStart = i + 5

                e.Handled = True

            Case 29 'GS

                Me.txtBarcode.Text = Me.txtBarcode.Text.Insert(Me.txtBarcode.SelectionStart, "<GS>")

                Me.txtBarcode.SelectionStart = i + 5

                e.Handled = True

            Case 30 'RS

                Me.txtBarcode.Text = Me.txtBarcode.Text.Insert(Me.txtBarcode.SelectionStart, "<RS>")

                Me.txtBarcode.SelectionStart = i + 5

                e.Handled = True

        End Select

    End Sub

End Class