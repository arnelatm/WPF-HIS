Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.ReportAppServer.DataDefModel
Imports Microsoft.Office.Interop.Excel
Imports System.Dynamic
Imports System.Globalization
Imports System.Runtime.InteropServices.ComTypes

Namespace Accounts

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

        Public Function GetQrCodeInfo(qrCodeText As String) As ExpandoObject
            Dim product As Object
            product = New ExpandoObject
            Dim dataLength = Len(qrCodeText)
            Dim i As Int16 = 0
            Dim ai As String = Mid(qrCodeText, 1, 2)
            Dim lastPosition As Int16 = 2
            Dim expiryDate As Date = Nothing
            Dim batchNo As String = Nothing
            Dim serializationNo As String = Nothing
            While lastPosition < dataLength
                Select Case ai
                    Case "01" 'GTIN
                        CType(product, IDictionary(Of String, Object))("GTin") = Mid(qrCodeText, lastPosition + 1, 14)
                        lastPosition += 14
                    Case "17" 'Expiry Date
                        Dim cExpDate As String = ""
                        cExpDate = Mid(qrCodeText, lastPosition + 1, 6)
                        If Right(cExpDate, 2) = "00" Then
                            cExpDate = Mid(cExpDate, 1, 4) + "01"
                        End If
                        Dim dExpDate As Date
                        Date.TryParseExact(CStr(cExpDate), {"yyyyMM", "yyyy/MM", "yyyy-MM", "yyMMdd"}, Nothing, DateTimeStyles.None, dExpDate)
                        CType(product, IDictionary(Of String, Object))("ExpiryDate") = dExpDate
                        lastPosition += 6
                    Case "11" 'manufacture date
                        CType(product, IDictionary(Of String, Object))("ManufactureDate") = Mid(qrCodeText, lastPosition + 1, 6)
                        lastPosition += 6
                    Case "10" ' Batch Number
                        For i = lastPosition + 1 To dataLength
                            If Mid(qrCodeText, i, 4) = "<GS>" Or Mid(qrCodeText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                                If i >= dataLength Then
                                    batchNo = Mid(qrCodeText, lastPosition + 1)
                                Else
                                    batchNo = Mid(qrCodeText, lastPosition + 1, i - lastPosition - 1)
                                End If
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next

                        'For i = lastPosition + 1 To dataLength
                        '    If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                        '        lastPosition = i + 3
                        '        Exit For
                        '    End If
                        'Next
                        CType(product, IDictionary(Of String, Object))("BatchNo") = CType(batchNo, String)
                    Case "21" ' Serialization No.
                        Dim serialNo As String = Nothing
                        For i = lastPosition + 1 To dataLength
                            If Mid(qrCodeText, i, 4) = "<GS>" Or Mid(qrCodeText, i, 1) = ChrW(13) Or i >= dataLength Then
                                If i >= dataLength Then
                                    serialNo = Mid(qrCodeText, lastPosition + 1)
                                Else
                                    serialNo = Mid(qrCodeText, lastPosition + 1, i - lastPosition - 1)
                                End If
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                        CType(product, IDictionary(Of String, Object))("SerializationNo") = serialNo
                        'For i = lastPosition + 1 To dataLength
                        '    If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then
                        '        lastPosition = i + 3
                        '        Exit For
                        '    End If
                        'Next
                End Select
                If lastPosition >= dataLength Then
                    Exit While
                Else
                    ai = Mid(qrCodeText, lastPosition + 1, 2)
                    If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                        Exit While
                    End If
                    lastPosition += 2
                End If
            End While
            Return product

        End Function

        Public Function BasicWithNotes(tableName As String) As Boolean
            Select Case tableName
                Case "PhoneType"
                    Return True
                Case "Bank"
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        Public Function LimitToBranch(tableName As String) As Boolean
            Select Case tableName
                Case "Warehouse"
                    Return True
                Case Else
                    Return False
            End Select
        End Function

    End Module
End Namespace
