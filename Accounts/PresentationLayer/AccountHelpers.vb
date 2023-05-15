Namespace PresentationLayer

    Module AccountHelpers

        'Public Sub CreateSpecialAccountDataSource(ea As EventAggregator, specialAccountArray As String(), control As Control)
        '    If ea IsNot Nothing Then
        '        Dim filter As String = CreateSpecialAccountFilterKey(specialAccountArray)
        '        ea.PublishEvent(New GetDataSource("Account", control, filter))
        '    End If
        'End Sub

        Public Function CreateSpecialAccountFilterKey(specialAccountArray As String()) As String
            Dim lookUpFilterKey = ""
            For Each specialAccountCode In specialAccountArray
                If lookUpFilterKey <> "" Then
                    lookUpFilterKey = lookUpFilterKey + " Or "
                End If
                lookUpFilterKey = lookUpFilterKey + "SpecialAccount = '" & specialAccountCode & "'"
            Next
            Return "DetailAccount=1 and (" + lookUpFilterKey + ")"
        End Function


        Public Function ExtractGTin(cText As String) As String
            Dim dataLength = Len(cText)
            Dim i As Int16 = 0
            Dim ai As String = Mid(cText, 1, 2)
            Dim lastPosition As Int16 = 2
            Dim GTin As String = Nothing
            While lastPosition < dataLength
                Select Case ai
                    Case "01" 'GTIN
                        GTin = Mid(cText, lastPosition + 1, 14)
                        lastPosition += 14
                    Case "17" 'Expiry Date
                        lastPosition += 6
                    Case "11" 'manufacture date
                        lastPosition += 6
                    Case "10" ' Batch Number
                        For i = lastPosition + 1 To dataLength
                            If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                    Case "21" ' Serialization No.
                        For i = lastPosition + 1 To dataLength
                            If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                End Select
                If GTin IsNot Nothing OrElse lastPosition >= dataLength Then
                    Exit While
                Else
                    ai = Mid(cText, lastPosition + 1, 2)
                    If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                        Exit While
                    End If
                    lastPosition += 2
                End If
            End While
            Return GTin

        End Function
    End Module
End Namespace