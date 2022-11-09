Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DrugSalePresenter(Of TM As New)
        Inherits AccountsPresenter(Of IDrugSaleView, TM)

        Public Sub New(itemView As IDrugSaleView)
            MyBase.New(itemView)
            Service = New AccountsService("DrugSale")
            TableName = "DrugSale_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged
            AddHandler View.ClearEntry, AddressOf OnClearEntry
            AddHandler View.ValidateEntries, AddressOf OnValidateEntries
            AddHandler View.ValidateQrCode, AddressOf OnValidateQrCode
        End Sub

        Private Sub OnValidateEntries()
            If Not ValidEntries() Then
                MessageBox.Show("Please correct this record.")
            Else
                MessageBox.Show("Values are valid.")
            End If
        End Sub

        Private Sub OnClearEntry()
            ClearEntry()
        End Sub

        Private Sub ClearEntry()
            View.GTin = ""
            View.BatchNo = ""
            View.SerializationNo = ""
            View.Expiry = Nothing
            View.Manufacture = Nothing
            View.ItemNameEnglish = ""
        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

        Private Function GetDrugName() As String
            Return Service.GetField(View.GTin, "DrugList", "GTIN", "[Trade Name]")
        End Function

        Private Function GetDrugCode() As String
            Return Service.GetField(View.GTin, "ItemDetails", "GTIN", "[Item_Code]")
        End Function

        Public Function DrugAlreadySold(ByRef IdNo As Int32) As Boolean
            IdNo = Service.GetRecordFieldWith3KeyG(Of String, String, String, Int32)("DrugSale", View.GTin, View.BatchNo, View.SerializationNo, "GTin", "BatchNo", "SerializationNo", "IdNo")
            If IdNo > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.SaleDate = Today()
            View.QrCode = ""
        End Sub

        Private cGTin As String = Nothing
        Private cSerializationNo As String = Nothing
        Private cBatchNo As String = Nothing
        Private cExpiry As String
        Private cManufacture As String

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim saveData As Boolean = False
                If Not (View.QrCode Is Nothing Or View.QrCode = "") Then
                    If View.QrCode.Contains("<GS>") Then
                        ProcessQrCode()
                        If ValidValues() Then
                            AssignQrCodeValues()
                            ' don't allow duplicate values, item can only be sold once
                            saveData = Not IsDrugAlreadySold()
                        End If
                    End If
                End If
                If saveData Then
                    Dim control As Control = Nothing
                    If Not MainFieldsDictionary.TryGetValue("QrCode", control) Then
                        MyErrorProvider.SetError(control, "Drug already sold, cannot re-sale a drug.")
                    Else
                        Save(View)
                    End If
                End If
            End If
            Return retValue
        End Function

        Public Sub OnValidateQrCode(ByRef valid As Boolean)
            valid = False
            If Not (View.QrCode Is Nothing Or View.QrCode = "") Then
                If View.QrCode.Contains("<GS>") Then
                    ProcessQrCode()
                    If ValidValues() Then
                        AssignQrCodeValues()
                        ' don't allow duplicate values, item can only be sold once
                        valid = Not IsDrugAlreadySold()
                    End If
                End If
            Else
                valid = True
            End If
        End Sub

        Private Sub ProcessQrCode()
            Dim dataLength = Len(View.QrCode)
            Dim i As Int16 = 0
            cGTin = Mid(View.QrCode, 3, 14)
            Dim ai As String = Mid(View.QrCode, 17, 2)
            Dim lastPosition As Int16 = 18
            While lastPosition < dataLength
                Select Case ai
                    Case "17"
                        cExpiry = Mid(View.QrCode, lastPosition + 1, 6)
                        If Right(cExpiry, 2) = "00" Then
                            cExpiry = Mid(View.QrCode, 1, 4) + "01"
                        End If
                        lastPosition += 6
                    Case "11" 'manufacture date
                        cManufacture = Mid(View.QrCode, lastPosition + 1, 6)
                        lastPosition += 6
                    Case "10"
                        For i = lastPosition + 1 To dataLength
                            If Mid(View.QrCode, i, 4) = "<GS>" Then ' separator
                                cBatchNo = Mid(View.QrCode, lastPosition + 1, i - lastPosition - 1)
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                    'MessageBox.Show("Batch No = " + batchNo)
                    Case "21"
                        For i = lastPosition + 1 To dataLength
                            If Mid(View.QrCode, i, 4) = "<GS>" Or Mid(View.QrCode, i, 1) = ChrW(13) Or i >= dataLength Then
                                cSerializationNo = Mid(View.QrCode, lastPosition + 1, i - lastPosition - 1)
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                        'MessageBox.Show("Serialization No = " + serializationNo)
                End Select
                If lastPosition >= dataLength Then
                    Exit While
                Else
                    ai = Mid(View.QrCode, lastPosition + 1, 2)
                    If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                        Exit While
                    End If
                    lastPosition += 2
                End If
            End While
        End Sub

        Private Function ValidValues()
            Dim formats() As String = {"dd/MM/yyyy"}
            Dim yy As String, mm As String, dd As String
            yy = Mid(cExpiry, 1, 2)
            mm = Mid(cExpiry, 3, 2)
            dd = Mid(cExpiry, 5, 2)
            Dim textDate As String = dd + "/" + mm + "/" + (2000 + Val(yy)).ToString()
            Dim dDate As Date
            If Not DateTime.TryParseExact(textDate, formats, Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, dDate) Then
                MessageBox.Show("Invalid date value or format! <" + textDate + ">")
                Return False
            End If
            If dDate <= Today() Then
                MessageBox.Show("Item is Expired. Can't sell or accept an expired drug.")
                Return False
            End If
            If Len(cGTin) = 14 AndAlso Not IsNumeric(cGTin) Then
                MessageBox.Show("Invalid GTIN <" + cGTin + ">")
                Return False
            End If
            If Len(cBatchNo) < 1 Then
                MessageBox.Show("Batch Number cannot be empty!")
                Return False
            End If
            If Len(cSerializationNo) < 1 Then
                MessageBox.Show("Serialization Number cannot be empty!")
                Return False
            End If
            Return True
        End Function

        Private Function ValidEntries()
            Dim formats() As String = {"dd/MM/yyyy"}
            If View.Expiry Is Nothing Then
                MessageBox.Show("Expiry Date can't be empty!")
                Return False
            End If
            If View.Expiry <= Today() Then
                MessageBox.Show("Item is Expired. Can't sell or accept an expired drug.")
                Return False
            End If
            If Len(View.GTin) = 14 AndAlso Not IsNumeric(View.GTin) Then
                MessageBox.Show("Invalid GTIN <" + View.GTin + ">")
                Return False
            End If
            If Len(View.BatchNo) < 1 Then
                MessageBox.Show("Batch Number cannot be empty!")
                Return False
            End If
            If Len(View.SerializationNo) < 1 Then
                MessageBox.Show("Serialization Number cannot be empty!")
                Return False
            End If
            Return True
        End Function

        Private Function IsDrugAlreadySold() As Boolean
            Dim idNo As Int32 = 0
            If DrugAlreadySold(idNo) Then
                MessageBox.Show("Duplicate sale not allowed. This record has already been sold previously! See Record number <" + idNo.ToString("N0") + ">.")
                Return True
            End If
            Return False
        End Function

        Private Sub AssignQrCodeValues()
            View.GTin = cGTin
            View.BatchNo = cBatchNo
            View.SerializationNo = cSerializationNo
            View.Manufacture = MakeDate(cManufacture)
            View.Expiry = MakeDate(cExpiry)
            View.ItemNameEnglish = GetDrugName()
            View.Item_Code = GetDrugCode()
        End Sub

        Private Function MakeDate(stringDate As String) As Date
            Return GlobalFunctions.GbDateSerial(2000 + Val(Mid(stringDate, 1, 2)), Val(Mid(stringDate, 3, 2)), Val(Mid(stringDate, 5, 2)))
        End Function

    End Class

End Namespace