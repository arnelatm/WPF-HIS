Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class PurchasePresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IPurchaseView, TM)
        'Implements ISubscriber(Of DataChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        'Private ReadOnly _PurchaseItemService As New AccountsService("PurchaseDetail", Nothing, {"PurchaseItem_View", "UpdatePurchaseItemTVP", "InsertPurchaseItemTVP"})

        Public Sub New(view As IPurchaseView)
            MyBase.New(view)
            TableName = "Purchase"
            WithTreeView = False
            Service = New AccountsService("Purchase")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("BonusQuantity", GetType(Int16))
            DtInsertTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("Price", GetType(Decimal))
            DtInsertTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PurchaseIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Quantity", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("UnitIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("VatAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("VatPercent", GetType(Decimal))

            DtUpdateTable.Columns.Add("BonusQuantity", GetType(Int16))
            DtUpdateTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("Price", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("PurchaseIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Quantity", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("VatAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("VatPercent", GetType(Decimal))

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Supplier", "SupplierIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)

            data.Clear()
            data.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            data.Add({"Product", "ProductsByCode", Nothing, Nothing})
            CreateLookupDataThread(data)
            data.Clear()

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PurchaseDetails, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PurchaseDetailFilter)
                UpdateSupplierDate()
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("BonusQuantity") = itemDataView.BonusQuantity
            workRow("DiscountAmount") = itemDataView.DiscountAmount
            workRow("NetAmount") = itemDataView.NetAmount
            workRow("Price") = itemDataView.Price
            workRow("ProductIdNo") = itemDataView.ProductIdNo
            workRow("PurchaseIdNo") = View.IdNo
            workRow("Quantity") = itemDataView.Quantity
            workRow("UnitIdNo") = itemDataView.UnitIdNo
            workRow("VatAmount") = If(itemDataView.Amount, "")
            workRow("VatPercent") = itemDataView.VatPercent
        End Sub

        Public Function PurchaseDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            'retVal = UpdateChildData(_PurchaseItemService, DtUpdateTable, DtInsertTable, passedValue, "PurchaseIdNo")
            'If retVal >= 0 Then
            '    Dim newPurchaseDetail As List(Of PurchaseDetailModel)
            '    newPurchaseDetail = _PurchaseItemService.GetRecordsWithGroupIdNo(Of PurchaseDetailModel)(View.IdNo, "Sequence")
            '    'If AddMode Then
            '    '    For Each item In newPurchaseDetail
            '    '        If IsAccountsPayableAccount(item.ProductIdNo) Then
            '    '            retVal = AddApOpenInvoice(item, "AP")
            '    '            If retVal < 0 Then
            '    '                Exit For
            '    '            End If
            '    '        End If
            '    '    Next
            '    'Else
            '    '    'retVal = RemoveDeletedApOpenInvoices(retVal, newPurchaseDetail)
            '    '    'If retVal >= 0 Then
            '    '    '    retVal = AddNewApOpenInvoices(retVal, newPurchaseDetail)
            '    '    'End If
            '    'End If
            'End If
            'If retVal >= 0 Then
            '    If IsEmpty(View.ReferenceNo) Then
            '        retVal = UpdateGlReferenceNumber()
            '    End If
            'End If
            If retVal >= 0 AndAlso Not IsEmpty(View.VatNumber) Then
                Service.UpdateVatNumber(View.VatNumber, View.SupplierIdNo)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean

            Return True
        End Function

        Public Overrides Sub GoPrintRecord()
            'Dim transactionAmount As String
            'Dim totalApAmount As String
            'Dim currencies As New List(Of CurrencyInfo)()
            'Dim curCulture = CultureInfo.CurrentCulture
            'CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            'Dim language As String
            'language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            'currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            'If language = "ar" Then
            '    transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            'Else
            '    transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            'End If
            'If language = "ar" Then
            '    totalApAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            'Else
            '    totalApAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            'End If
            'Dim cForm As New ReportForm("Accounts Payable Journal.Rpt", View.IdNo, "PurchaseIdNo", transactionAmount, "ApAmountInWords", totalApAmount, "TotalLineAmountInWords", language, "Language")
            'cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.PurchaseDetails IsNot Nothing And View.PurchaseDetails.Count() > 0 Then
                DtUpdateTable.Clear()
                '_PurchaseItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub UpdateDueDate()
            If View.SupplierIdNo IsNot Nothing Then
                'Dim supplierPaymentDueDays = GetSupplierPaymentDueDays(View.SupplierIdNo)
                'View.DueDate = DateAdd("d", supplierPaymentDueDays, View.TransactionDate)
            Else
                View.DueDate = Nothing
            End If
        End Sub

        'Public Function GetSupplierPaymentDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        'End Function

        'Public Sub UpdateEarlySettlementValues()
        '    If View.SupplierIdNo IsNot Nothing Then
        '        Dim supplierSettlementDueDays As Integer
        '        Dim supplierSettlementDiscount As Decimal
        '        supplierSettlementDueDays = GetSupplierSettlementDueDays(View.SupplierIdNo)
        '        supplierSettlementDiscount = GetSupplierSettlementDiscount(View.SupplierIdNo)
        '        View.SettlementDueDate = DateAdd("d", supplierSettlementDueDays, View.TransactionDate)
        '        View.SettlementDiscount = supplierSettlementDiscount
        '    Else
        '        View.SettlementDueDate = Nothing
        '        View.SettlementDiscount = 0
        '    End If
        'End Sub

        'Public Function GetSupplierSettlementDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDueDays")
        'End Function

        'Public Function GetSupplierSettlementDiscount(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDiscount")
        'End Function

        Public Sub UpdateSupplierDate()
            If View.TransactionDate IsNot Nothing Then
                If View.InvoiceDate Is Nothing Then
                    View.InvoiceDate = View.TransactionDate
                End If
            Else
                View.InvoiceDate = Nothing
            End If
        End Sub

        'Public Function ApPaymentExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Dim apOpenInvoiceIdNo As Integer
        '    apOpenInvoiceIdNo = Service.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
        '                                                       "PurchaseDetailIdNo", "IdNo")
        '    If Service.CountRecordWithKey(Of Integer)("CdOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("CkOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("PcOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    End If
        '    Return False
        'End Function

        'Public Sub OnPurchaseDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
        '    With eventType.BindingSource
        '        If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
        '            Dim accountId = eventType.BindingSource.Current.ProductIdNo
        '            Select Case eventType.PropertyName
        '                Case $"ProductIdNo"
        '                    MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
        '                    View.VatAmount = UpdateInputVatAmount(View.PurchaseDetails)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                Case $"Debit"
        '                    MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                    View.VatAmount = UpdateInputVatAmount(View.PurchaseDetails)
        '                Case $"Credit"
        '                    MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                    View.VatAmount = UpdateInputVatAmount(View.PurchaseDetails)
        '            End Select
        '        End If
        '    End With
        'End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            If Not MyBase.IsOkToEditRecord() Then
                Return False
            End If
            Dim result As Boolean = True
            'If ReconciledEntriesExist(View.PurchaseDetails, "AP") Then
            '    result = False
            'Else
            '    If DependentRecordExist() Then
            '        result = False
            '    End If
            'End If
            Return result
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsOkToDeleteRecord Then
                'If ReconciledEntriesExist(View.PurchaseDetails, "AP") Then
                '    retValue = False
                'End If
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'For Each item In View.PurchaseDetails
            '    If IsAccountsPayableAccount(item.ProductIdNo) Then
            '        Dim apOpenInvoiceNumber As Int32 = GetApOpenInvoiceNumber(item.IdNo)
            '        If CheckDependentRecords(Of Int32)(apOpenInvoiceNumber, "CdOiItem", "ApOpenInvoiceIdNo") Then
            '            Return True
            '        End If
            '    End If
            'Next
            Return False
        End Function



    End Class

End Namespace