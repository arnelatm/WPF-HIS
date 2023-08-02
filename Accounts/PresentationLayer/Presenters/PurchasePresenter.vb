Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

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
            DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()
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
            AddHandler view.PostData, AddressOf OnPostData

        End Sub


        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Supplier", "SupplierIdNo", Nothing, Nothing})
            data.Add({"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            data.Add({"User", "UserIdNo", "IdNo,UserName", Nothing})
            CreateDataSourceThread(data)

            data.Clear()
            data.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            data.Add({"Product", "ProductsByCode", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "ProductName"})
            'data.Add({"PurchaseDetail", "PurchaseHistory", Nothing, Nothing})
            CreateLookupDataThread(data)
            'data.Clear()

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
            Dim retValue As Boolean = True
            If MyBase.IsBizDataValid Then
                For Each item In View.PurchaseDetails
                    If item.NeedsExpiryDate AndAlso (item.ExpiryDate Is Nothing OrElse item.ExpiryDate.Value = Date.MinValue) Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Messaging.ShowPmMessage(True, "MsgExpDateNeeded", {"lineNumber", lineNumber})
                        retValue = False
                        Exit For
                    End If
                Next
            Else
                retValue = False
            End If
            Return retValue
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
            Dim purchaseDetail As PurchaseDetailView = eventType.BindingSource.Current
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim price As Decimal = 0
                    Dim vAmt As Decimal = 0
                    Dim amtBefVat As Decimal = 0
                    Dim dPerc As Decimal = 0
                    Dim vPerc As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        Case $"Quantity", $"Price", $"BonusQuantity", $"VatPercent", $"DiscountPercent"
                            SetAmounts(purchaseDetail)
                            eventType.BindingSource.ResetCurrentItem()
                        Case "GrossAmount"
                            gAmt = .GrossAmount
                            With purchaseDetail
                                .Price = RecomputePrice(purchaseDetail)
                                .DiscountAmount = GetDiscountAmount(purchaseDetail)
                                .AmtBefVat = GetAmountBeforeVat(purchaseDetail)
                                .VatAmount = GetVatAmount(purchaseDetail)
                                .NetAmount = GetNetAmount(purchaseDetail)
                            End With
                        Case "DiscountAmount"
                            dPerc = RecomputeDiscountPercentage(purchaseDetail)
                            With purchaseDetail
                                .DiscountPercent = dPerc
                                .AmtBefVat = GetAmountBeforeVat(purchaseDetail)
                                .VatAmount = GetVatAmount(purchaseDetail)
                                .NetAmount = GetNetAmount(purchaseDetail)
                            End With
                        Case "VatAmount"
                            vPerc = RecomputeVatPercentage(purchaseDetail)
                            With purchaseDetail
                                .VatPercent = vPerc
                                .NetAmount = GetNetAmount(purchaseDetail)
                            End With
                        Case "AmtBefVat"
                            gAmt = .GrossAmount
                            If .AmtBefVat <= .GrossAmount Then
                                .DiscountAmount = .GrossAmount - .AmtBefVat
                                .DiscountPercent = IIf(.GrossAmount = 0, 0, .DiscountAmount / .GrossAmount * 100)
                                .VatAmount = .AmtBefVat * .VatPercent / 100
                                .NetAmount = GetNetAmount(purchaseDetail)
                            Else
                                .GrossAmount = .AmtBefVat - .DiscountAmount
                                .Price = IIf(.Quantity = 0, 0, .GrossAmount / .Quantity)
                                .DiscountPercent = IIf(.GrossAmount = 0, 0, .DiscountAmount / .GrossAmount * 100)
                                .VatAmount = GetVatAmount(purchaseDetail)
                                .NetAmount = GetNetAmount(purchaseDetail)
                            End If
                        Case "NetAmount"
                            .AmtBefVat = .NetAmount / (1 + .VatPercent / 100)
                            .VatAmount = .NetAmount - .AmtBefVat
                            .GrossAmount = .AmtBefVat / (1 - .DiscountPercent / 100)
                            .DiscountAmount = .GrossAmount - .AmtBefVat
                            .Price = IIf(.Quantity = 0, 0, .GrossAmount / .Quantity)
                    End Select
                    .UnitCost = GetUnitCost(purchaseDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

        Private Sub InitializePurchaseDetailValues(ByRef purchaseDetail As PurchaseDetailView, productCode As String)
            Dim product As ProductModel = GetProductModel(productCode)
            If product IsNot Nothing Then
                If productCode <> purchaseDetail.ProductCode Then
                    With purchaseDetail
                        purchaseDetail.ProductIdNo = product.IdNo
                        purchaseDetail.ProductName = product.ProductName
                        If purchaseDetail.Quantity = 0 Then
                            purchaseDetail.Quantity = 1
                        End If
                        SetPurchaseDetailValues(product, purchaseDetail)
                        purchaseDetail.ProductCode = product.ProductCode
                    End With
                End If
            Else
                purchaseDetail.ProductIdNo = ""
                purchaseDetail.ProductName = ""
                Messaging.Show(True, "Invalid Product Code!")
            End If
        End Sub

        Private Sub SetPurchaseDetailValues(pModel As ProductModel, purchaseDetail As PurchaseDetailView)
            Dim lastPurchaseInfo As Object = New ExpandoObject
            lastPurchaseInfo = GetLastPurchaseInfo(pModel)
            With purchaseDetail
                If lastPurchaseInfo Is Nothing Then
                    SetDefaultUnit(pModel, purchaseDetail)
                Else
                    .Price = lastPurchaseInfo.Price
                    .UnitSalesPrice = lastPurchaseInfo.UnitSalesPrice
                    .UnitIdNo = lastPurchaseInfo.UnitIdNo
                    .UnitCount = GetUnitCount(pModel, purchaseDetail)
                End If
                .VatPercent = GetVatPercentage(pModel.CategoryIdNo)
                SetAmounts(purchaseDetail)
                .ProductIdNo = pModel.IdNo
                .NeedsExpiryDate = GetNeedsExpiryDate(pModel.CategoryIdNo)
            End With
        End Sub

        Private Sub SetAmounts(purchaseDetail As PurchaseDetailView)
            With purchaseDetail
                .GrossAmount = GetGrossAmount(purchaseDetail)
                .DiscountAmount = GetDiscountAmount(purchaseDetail)
                .AmtBefVat = GetAmountBeforeVat(purchaseDetail)
                .VatAmount = GetVatAmount(purchaseDetail)
                .NetAmount = GetNetAmount(purchaseDetail)
                .UnitCost = GetUnitCost(purchaseDetail)
            End With
        End Sub
        Private Function GetGrossAmount(purchaseDetail As PurchaseDetailView) As Decimal
            Return purchaseDetail.Price * purchaseDetail.Quantity
        End Function

        Private Function GetDiscountAmount(purchaseDetail As PurchaseDetailView) As Decimal
            Return purchaseDetail.GrossAmount * purchaseDetail.DiscountPercent / 100
        End Function

        Private Function GetAmountBeforeVat(purchaseDetail As PurchaseDetailView) As Decimal
            Return purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount
        End Function

        Private Function GetVatAmount(purchaseDetail As PurchaseDetailView) As Decimal
            Return (purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount) * purchaseDetail.VatPercent / 100
        End Function

        Private Function GetNetAmount(purchaseDetail As PurchaseDetailView) As Decimal
            Return purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount + purchaseDetail.VatAmount
        End Function

        Private Function GetUnitCost(purchaseDetail As PurchaseDetailView) As Decimal
            Return IIf(purchaseDetail.Quantity + purchaseDetail.BonusQuantity = 0, 0, purchaseDetail.NetAmount / (purchaseDetail.Quantity + purchaseDetail.BonusQuantity))
        End Function

        Private Function RecomputeDiscountPercentage(purchaseDetail As PurchaseDetailView) As Decimal
            Return Math.Round(IIf(purchaseDetail.GrossAmount = 0, 0, purchaseDetail.DiscountAmount / purchaseDetail.GrossAmount * 100), 2)
        End Function

        Private Function RecomputePrice(purchaseDetail As PurchaseDetailView) As Decimal
            Return Math.Round(IIf(purchaseDetail.Quantity = 0, 0, purchaseDetail.GrossAmount / purchaseDetail.Quantity), 2)
        End Function

        Private Function RecomputeVatPercentage(purchaseDetail As PurchaseDetailView) As Decimal
            Return IIf(purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount = 0, 0, purchaseDetail.VatAmount / (purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount) * 100)
        End Function

        Private Function GetProductModel(productCode As String) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Dim product As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            Return product
        End Function

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
            Dim purchaseDetail As PurchaseDetailView = bs.Current
            InitializePurchaseDetailValues(purchaseDetail, productCode)
            If purchaseDetail.ProductIdNo > 0 Then
                UpdatePurchaseHistory(purchaseDetail.ProductIdNo)
            End If
            bs.EndEdit()
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim purchaseDetail As PurchaseDetailView = bs.Current
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
            productCode = productModel.ProductCode
            OnProductCodeChanged(productCode, bs)
        End Sub

        Private Sub OnProductUnitSelection(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub OnUnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String)
            If newUnit = 0 Then
                Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", formattedValue, "fieldDescription", "Unit"})
            Else
                RecomputePrice(oldUnit, newUnit, bs)
            End If
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
            Dim purchaseDetail As PurchaseDetailView = bs.Current
            Dim newPrice As Decimal
            Dim productIdNo As Int32 = bs.Current.ProductIdNo
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            If oldUnit <> newUnit Then
                Dim unitQty, baseQty As Int16
                Dim basePrice As Decimal
                If productModel.BaseUnitIdNo = oldUnit Then
                    basePrice = purchaseDetail.Price
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    basePrice = Math.Ceiling(IIf(baseQty = 0, 0, unitQty / baseQty) * purchaseDetail.Price * 100D) / 100D
                End If
                If newUnit = productModel.BaseUnitIdNo Then
                    newPrice = basePrice
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    newPrice = Math.Ceiling(IIf(baseQty = 0, 0, basePrice * baseQty / unitQty) * 100D) / 100D
                End If
                purchaseDetail.Price = newPrice
                SetAmounts(purchaseDetail)
            End If
        End Sub

        Private Sub OnProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub SetProductUnits(productIdNo As Int16)
            Dim data As New ArrayList
            data.Add({"ProductUnit_View", "UnitsByProduct", "UnitIdNo,UnitName,UnitCode", "ProductIdNo = " + productIdNo.ToString()})
            CreateLookupDataThread(data)
        End Sub

        Private Function GetLastPurchaseInfo(pModel As ProductModel) As ExpandoObject
            Return Service.GetTopOneFields("PurchaseDetail", "Price,UnitSalesPrice,UnitIdNo", "ProductIdNo = " & pModel.IdNo.ToString(), "IdNo", False)
        End Function

        Private Function GetSalesPrice(item As ProductModel) As Decimal
            Dim price As Decimal

            price = Service.GetField(Of Decimal, Int32)(item.IdNo, "Product", "IdNo", "Price_Cash")
            Return price
        End Function

        Private Sub SetDefaultUnit(item As ProductModel, purchaseDetail As PurchaseDetailView)
            Dim noOfUnits = GetUnitCount(item, purchaseDetail)
            purchaseDetail.UnitCount = noOfUnits
            If noOfUnits = 1 OrElse purchaseDetail.UnitIdNo = 0 Then
                purchaseDetail.UnitIdNo = item.BaseUnitIdNo
            Else
                Dim nCount As Int16 = Service.CountRecordWith2Key(Of Int32, Int16)("ProductUnit", "ProductIdNo", "UnitIdNo", item.IdNo, purchaseDetail.UnitIdNo)
                If nCount = 0 Then
                    purchaseDetail.UnitIdNo = item.BaseUnitIdNo
                Else
                    purchaseDetail.UnitIdNo = 0
                End If
            End If
        End Sub

        Private Function GetUnitCount(item As ProductModel, purchaseDetail As PurchaseDetailView) As Int32
            Return Service.CountRecordWithKey(Of Int32)("ProductUnit", "ProductIdNo", item.IdNo) + 1
        End Function

        Private Function GetVatPercentage(categoryIdNo As Int16) As Decimal
            Return Service.GetField(Of Decimal, Int16)(categoryIdNo, "Category", "IdNo", "VatPercentage")
        End Function

        Private Function GetNeedsExpiryDate(categoryIdNo As Int16) As Decimal
            Return Service.GetField(Of Boolean, Int16)(categoryIdNo, "Category", "IdNo", "NeedsExpiryDate")
        End Function

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.TransactionDate = Date.Now()
            View.UserIdNo = GlobalVariables.UserIdNo
            Dim wareHouse = Service.GetTopOneFields("Warehouse", "IdNo", "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString(), "IdNo", True)
            View.WarehouseIdNo = wareHouse.IdNo
        End Sub

        Private Function OnPostData(idNo As Int32) As Boolean
            Dim retVal As Boolean = Service.PostData(idNo)
            If retVal Then
                View.Posted = True
            End If
            Return retVal
        End Function


    End Class

End Namespace