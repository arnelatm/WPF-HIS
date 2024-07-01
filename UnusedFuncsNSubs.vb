    Protected Function TextBoxNumParser(Of T As Structure)(ByRef control As CTextBox) As T
        Dim retValue As T
        Try
            retValue = Parser(Of T).Parser(control.Text)
            Text = retValue.ToString()
        Catch ex As Exception
            If Not IgnoreTextBoxNumParserMessage Then
                Dim description As String
                If TypeOf control Is ILinkedLabel Then
                    description = DirectCast(control, ILinkedLabel).GetControlDescription()
                Else
                    description = control.Name
                End If
            End If
            retValue = Parser(Of T).Parser("0")
        End Try
        Return retValue
    End Function