Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.DataLayer
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports Telerik.Licensing

Namespace PresentationLayer.Presenters

    Public Class PurchasePresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IPurchaseView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _productService As New AccountsService("Product")
        Private ReadOnly _purchaseHistoryService As New AccountsService("PurchaseHistory")

        Public Sub New(view As IPurchaseView)
            MyBase.New(view)
            TableName = "Purchase"
            WithTreeView = False
            Service = New AccountsService("Purchase")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("BatchNo", GetType(String))
            DtInsertTable.Columns.Add("BonusQuantity", GetType(Int16))
            DtInsertTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("ExpiryDate", GetType(Date))
            DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("Price", GetType(Decimal))
            DtInsertTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PurchaseIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Quantity", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("UnitSalesPrice", GetType(Decimal))
            DtInsertTable.Columns.Add("VatAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("VatPercent", GetType(Decimal))

            DtUpdateTable.Columns.Add("BatchNo", GetType(String))
            DtUpdateTable.Columns.Add("BonusQuantity", GetType(Int16))
            DtUpdateTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("ExpiryDate", GetType(Date))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("Price", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("PurchaseIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Quantity", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitSalesPrice", GetType(Decimal))
            DtUpdateTable.Columns.Add("VatAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("VatPercent", GetType(Decimal))
            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            AddHandler view.GTinScanned, AddressOf OnGTinScanned
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            AddHandler view.UnitChanged, AddressOf OnUnitChanged
            AddHandler view.RowChanged, AddressOf OnRowChanged

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Supplier", "SupplierIdNo", Nothing, Nothing})
            data.Add({"Warehouse", "WarehouseIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)

            data.Clear()
            data.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            data.Add({"Product", "ProductsByCode", Nothing, Nothing})
            'data.Add({"PurchaseDetail", "PurchaseHistory", Nothing, Nothing})
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
            workRow("BatchNo") = itemDataView.BatchNo
            workRow("BonusQuantity") = itemDataView.BonusQuantity
            workRow("DiscountAmount") = itemDataView.DiscountAmount
            workRow("ExpiryDate") = IIf(itemDataView.ExpiryDate Is Nothing, DBNull.Value, itemDataView.ExpiryDate)
            workRow("NetAmount") = itemDataView.NetAmount
            workRow("Price") = itemDataView.Price
            workRow("ProductIdNo") = itemDataView.ProductIdNo
            workRow("PurchaseIdNo") = View.IdNo
            workRow("Quantity") = itemDataView.Quantity
            workRow("UnitIdNo") = itemDataView.UnitIdNo
            workRow("UnitSalesPrice") = itemDataView.UnitSalesPrice
            workRow("VatAmount") = itemDataView.VatAmount
            workRow("VatPercent") = itemDataView.VatPercent
        End Sub

        Public Function PurchaseDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private ReadOnly _purchaseItemService As New AccountsService("PurchaseDetail")

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_purchaseItemService, DtUpdateTable, DtInsertTable, passedValue, "PurchaseIdNo")
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
                Dim supplierPaymentDueDays = GetSupplierPaymentDueDays(View.SupplierIdNo)
                View.DueDate = DateAdd("d", supplierPaymentDueDays, View.TransactionDate)
            Else
                View.DueDate = Nothing
            End If
        End Sub

        Private Function GetSupplierPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        End Function

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

        Public Sub OnPurchasedgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    'Dim productCode = eventType.BindingSource.Current.ProductCode
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim price As Decimal = 0
                    Dim vAmt As Decimal = 0
                    Dim amtBefVat As Decimal = 0
                    Dim dPerc As Decimal = 0
                    Dim vPerc As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        Case $"ProductCode"
                            UpdatePurchaseItem(eventType.BindingSource.Current, eventType.EnteredValue)
                            OnProductCodeChanged(.ProductCode, eventType.BindingSource)
                            gAmt = .Price * .Quantity
                            .GrossAmount = gAmt
                            dAmt = gAmt * .DiscountPercent / 100
                            .DiscountAmount = dAmt
                            .AmtBefVat = gAmt - dAmt
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case $"Quantity"
                            gAmt = .Price * .Quantity
                            .GrossAmount = gAmt
                            dAmt = gAmt * .DiscountPercent / 100
                            .DiscountAmount = dAmt
                            .AmtBefVat = gAmt - dAmt
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "Price"
                            gAmt = .Price * .Quantity
                            .GrossAmount = gAmt
                            dAmt = gAmt * .DiscountPercent / 100
                            .DiscountAmount = dAmt
                            .AmtBefVat = gAmt - dAmt
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "GrossAmount"
                            gAmt = .GrossAmount
                            price = IIf(.Quantity = 0, 0, gAmt / .Quantity)
                            .Price = price
                            dAmt = gAmt * .DiscountPercent / 100
                            .DiscountAmount = dAmt
                            .DiscountPercent = dAmt / gAmt * 100
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .AmtBefVat = gAmt - dAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "VatAmount"
                            gAmt = .GrossAmount
                            dAmt = .DiscountAmount
                            vAmt = .VatAmount
                            vPerc = IIf(gAmt - dAmt = 0, 0, vAmt / (gAmt - dAmt) * 100)
                            .VatPercent = vPerc
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "VatPercent"
                            vPerc = .VatPercent
                            gAmt = .GrossAmount
                            dAmt = .DiscountAmount
                            vAmt = (gAmt - dAmt) * vPerc / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "DiscountPercent"
                            gAmt = .GrossAmount
                            dAmt = gAmt * .DiscountPercent / 100
                            .DiscountAmount = dAmt
                            .AmtBefVat = gAmt - dAmt
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "DiscountAmount"
                            gAmt = .GrossAmount
                            dAmt = .DiscountAmount
                            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
                            .DiscountPercent = dPerc
                            .AmtBefVat = gAmt - dAmt
                            vAmt = (gAmt - dAmt) * .VatPercent / 100
                            .VatAmount = vAmt
                            .NetAmount = gAmt - dAmt + vAmt
                        Case "AmtBefVat"
                            amtBefVat = .AmtBefVat
                            gAmt = .GrossAmount
                            If amtBefVat <= gAmt Then
                                dAmt = gAmt - amtBefVat
                                .DiscountAmount = dAmt
                                dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
                                .DiscountPercent = dPerc
                                vAmt = amtBefVat * .VatPercent / 100
                                .VatAmount = vAmt
                                .NetAmount = gAmt - dAmt + vAmt
                            Else
                                dAmt = .DiscountAmount
                                gAmt = amtBefVat - dAmt
                                .GrossAmount = gAmt
                                price = IIf(.Quantity = 0, 0, gAmt / .Quantity)
                                .Price = price
                                dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
                                .DiscountPercent = dPerc
                                vAmt = amtBefVat * .VatPercent / 100
                                .VatAmount = vAmt
                                .NetAmount = gAmt - dAmt + vAmt
                            End If
                        Case "NetAmount"
                            nAmt = .NetAmount
                            vPerc = .VatPercent
                            dPerc = .DiscountPercent
                            amtBefVat = nAmt / (1 + vPerc / 100)
                            .AmtBefVat = amtBefVat
                            .VatAmount = nAmt - amtBefVat
                            gAmt = amtBefVat / (1 - dPerc / 100)
                            .GrossAmount = gAmt
                            .DiscountAmount = gAmt - amtBefVat
                            .Price = IIf(.Quantity = 0, 0, gAmt / .Quantity)
                    End Select
                    Dim totQty As Int32 = .Quantity + .BonusQuantity
                    .UnitCost = IIf(totQty = 0, 0, .NetAmount / totQty)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

        Private Sub UpdatePurchaseItem(ByRef current As PurchaseDetailView, productCode As String)
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Dim item As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            If item IsNot Nothing Then
                current.ProductIdNo = item.IdNo
                current.ProductName = item.ProductName
                'SetProductUnits(item.IdNo)
            Else
                current.ProductIdNo = ""
                current.ProductName = ""
                Messaging.Show(True, "Invalid Product Code!")
            End If
        End Sub

        Private Function GetProductIdNo(productCode As String) As Int32
            Return GetRecordFieldWithKeyG(Of Int32)(productCode, "Product", "ProductCode", "IdNo")
        End Function

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
            '        End IfOnProductNameChanged
            '    End If
            'Next
            Return False
        End Function

        Private Sub OnProductCodeChanged(productCode As String, bs As BindingSource)
            Dim pModel As ProductModel = GetProductModel(productCode)
            UpdatePurchaseItem(pModel, bs)
            If pModel.IdNo > 0 Then
                UpdatePurchaseHistory(pModel.IdNo)
            End If
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
            productCode = productModel.ProductCode
            UpdatePurchaseItem(productModel, bs)
        End Sub

        Private Sub OnProductUnitSelection(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub OnUnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource)
            RecomputePrice(oldUnit, newUnit, bs)
        End Sub

        Private Sub OnRowChanged(productIdNo As Int32)
            UpdatePurchaseHistory(productIdNo)
        End Sub

        Private Sub UpdatePurchaseHistory(productIdNo As Int32)
            Dim purHistory As List(Of PurchaseHistoryModel)
            purHistory = _purchaseHistoryService.GetRecordsWithGroupIdNo(Of PurchaseHistoryModel)(productIdNo)
            GlobalVariables.Mapper.Map(purHistory, View.PurchaseHistory)
        End Sub

        Private Sub RecomputePrice(oldUnit As Int16, newUnit As Int16, bs As BindingSource)
            Dim newPrice As Decimal
            Dim productIdNo As Int32 = bs.Current.ProductIdNo
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            If oldUnit <> newUnit Then
                Dim unitQty, baseQty As Int16
                Dim basePrice As Decimal
                If productModel.BaseUnitIdNo = oldUnit Then
                    basePrice = bs.Current.Price
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    basePrice = IIf(baseQty = 0, 0, unitQty / baseQty) * bs.Current.Price
                End If
                If newUnit = productModel.BaseUnitIdNo Then
                    newPrice = basePrice
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    newPrice = IIf(baseQty = 0, 0, basePrice * baseQty / unitQty)
                End If
                Dim gAmt As Decimal = 0
                gAmt = newPrice * bs.Current.Quantity
                bs.Current.Price = newPrice
                bs.Current.GrossAmount = gAmt
                Dim dAmt As Decimal = gAmt * bs.Current.DiscountPercent / 100
                bs.Current.DiscountAmount = dAmt
                bs.Current.AmtBefVat = gAmt - dAmt
                Dim vAmt As Decimal = (gAmt - dAmt) * bs.Current.VatPercent / 100
                bs.Current.VatAmount = vAmt
                bs.Current.NetAmount = gAmt - dAmt + vAmt
                bs.Current.UnitCost = IIf(bs.Current.Quantity + bs.Current.BonusQuantity = 0, 0, bs.Current.NetAmount / (bs.Current.Quantity + bs.Current.BonusQuantity))
            End If
        End Sub

        Private Sub OnProductUnitEditing(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub SetProductUnits(productIdNo As Int16)
            Dim data As New ArrayList
            data.Add({"ProductUnit_View", "UnitsByProduct", "UnitName,IdNo,UnitCode", "ProductIdNo = " + productIdNo.ToString()})
            CreateLookupDataThread(data)
        End Sub

        Private Sub UpdatePurchaseItem(pModel As ProductModel, bs As BindingSource)
            With bs.Current
                If pModel.IdNo > 0 Then
                    If .ProductIdNo <> pModel.IdNo Then
                        .ProductCode = pModel.ProductCode
                        .ProductName = pModel.ProductName
                        If .Quantity = 0 Then
                            .Quantity = 1
                        End If
                        SetPurchaseValues(pModel, bs)
                    End If
                Else
                    bs.Current.ProductIdNo = Nothing
                    bs.Current.ProductName = Nothing
                    bs.Current.UnitIdNo = Nothing
                    bs.Current.Price = Nothing
                End If
            End With
        End Sub

        Private Sub SetPurchaseValues(pModel As ProductModel, bs As BindingSource)
            Dim lastPurchaseInfo As Object = New ExpandoObject
            lastPurchaseInfo = GetLastPurchaseInfo(pModel)
            With bs.Current
                If lastPurchaseInfo Is Nothing Then
                    SetDefaultUnit(pModel, bs)
                Else
                    .Price = lastPurchaseInfo.Price
                    .UnitSalesPrice = lastPurchaseInfo.UnitSalesPrice
                    .UnitIdNo = lastPurchaseInfo.UnitIdNo
                End If
                .VatPercent = GetVatPercentage(pModel.CategoryIdNo)
                .GrossAmount = .Price * .Quantity
                .DiscountAmount = .GrossAmount * .DiscountPercent / 100
                .AmtBefVat = .GrossAmount - .DiscountAmount
                .VatAmount = (.GrossAmount - .DiscountAmount) * .VatPercent / 100
                .NetAmount = .GrossAmount - .DiscountAmount + .VatAmount
                .ProductIdNo = pModel.IdNo
                .UnitCost = IIf(.Quantity + .BonusQuantity = 0, 0, .NetAmount / (.Quantity + .BonusQuantity))
            End With
        End Sub

        Private Function GetLastPurchaseInfo(pModel As ProductModel) As ExpandoObject
            Return Service.GetTopOneFields("PurchaseDetail", "Price,UnitSalesPrice,UnitIdNo", "ProductIdNo = " & pModel.IdNo.ToString(), "IdNo", False)
        End Function

        Private Function GetSalesPrice(item As ProductModel) As Decimal
            Dim price As Decimal

            price = Service.GetField(Of Decimal, Int32)(item.IdNo, "Product", "IdNo", "Price_Cash")
            Return price
        End Function

        Private Sub SetDefaultUnit(item As ProductModel, bs As BindingSource)
            Dim noOfUnits = Service.CountRecordWithKey(Of Int32)("ProductUnit", "ProductIdNo", item.IdNo) + 1
            bs.Current.UnitCount = noOfUnits
            If noOfUnits = 1 Or (bs.Current.UnitIdNo Is Nothing Or bs.Current.UnitIdNo = 0) Then
                bs.Current.UnitIdNo = item.BaseUnitIdNo
            Else
                Dim nCount As Int16 = Service.CountRecordWith2Key(Of Int32, Int16)("ProductUnit", "ProductIdNo", "UnitIdNo", item.IdNo, bs.Current.UnitIdNo)
                If nCount = 0 Then
                    bs.Current.UnitIdNo = item.BaseUnitIdNo
                Else
                    ' no change, retain current value
                End If
            End If
        End Sub

        Private Function GetVatPercentage(categoryIdNo As Int16) As Decimal
            Return Service.GetField(Of Int32, Int16)(categoryIdNo, "Category", "IdNo", "VatPercentage")
        End Function

    End Class

End Namespace