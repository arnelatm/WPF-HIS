Imports System.Windows.Forms


Public Module Valid
    Function IsInteger(ByRef EntryControl As Control, ByVal Optional MessageUser As Boolean = True) As Integer
        Dim ConvertedValue As Integer
        Try
            ConvertedValue = CInt(EntryControl.Text)
        Catch ex As Exception
            If MessageUser Then
                MessageBox.Show("Invalid entry, only numbers allowed for this field, enter 0 to exit!")
            End If
            EntryControl.Focus()
        End Try
        'Loop
        Return ConvertedValue
    End Function
End Module

