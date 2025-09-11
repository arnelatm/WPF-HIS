Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Events

Namespace PresentationLayer.Presenters

    Public Class PurchasePresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IPurchaseView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private _productService
        Private _purchaseHistoryService
        Private _purchaseItemService
        Private _defaultUserWarehouseIdNo
        Protected PurchaseOrder As Boolean
        Protected PurchaseReturn As Boolean

        'Private ReadOnly _productService As New AccountsService("Product")
        'Private ReadOnly _purchaseHistoryService As New AccountsService("PurchaseHistory")
        'Protected PurchaseOrder As Boolean

        Public Sub New(view As IPurchaseView, ByVal param As Object())
            MyBase.New(view)
            PurchaseOrder = param(0)
            PurchaseReturn = param(1)

            If PurchaseOrder Then
                TableName = "PurchaseOrder"
                DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()
            Else
                DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString() & " and PurchaseReturn = " & IIf(PurchaseReturn, "1", "0")
                TableName = "Purchase"
            End If
            _productService = New AccountsService("Product")
            _purchaseHistoryService = New AccountsService("PurchaseHistory")
            _purchaseItemService = New AccountsService("PurchaseDetail", Nothing, {PurchaseOrder, PurchaseReturn})
            WithTreeView = False
            SortOrderKey = "IdNo"
            Service = New AccountsService("Purchase", {PurchaseOrder, PurchaseReturn}, {PurchaseOrder, PurchaseReturn})

            If PurchaseOrder Then
                DtInsertTable.Columns.Add("BonusQuantity", GetType(Decimal))
                DtInsertTable.Columns.Add("DiscountAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("Price", GetType(Decimal))
                DtInsertTable.Columns.Add("ProductIdNo", GetType(Int32))
                DtInsertTable.Columns.Add("PurchaseOrderIdNo", GetType(Int32))
                DtInsertTable.Columns.Add("Quantity", GetType(Decimal))
                DtInsertTable.Columns.Add("Sequence", GetType(Int16))
                DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))
                DtInsertTable.Columns.Add("VatAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("VatPercent", GetType(Decimal))

                DtUpdateTable.Columns.Add("BonusQuantity", GetType(Decimal))
                DtUpdateTable.Columns.Add("DiscountAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("Price", GetType(Decimal))
                DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("PurchaseOrderIdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("Quantity", GetType(Decimal))
                DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
                DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
                DtUpdateTable.Columns.Add("VatAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("VatPercent", GetType(Decimal))
            Else
                DtInsertTable.Columns.Add("BatchNo", GetType(String))
                DtInsertTable.Columns.Add("BonusQuantity", GetType(Decimal))
                DtInsertTable.Columns.Add("DiscountAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("ExpiryDate", GetType(Date))
                DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("Price", GetType(Decimal))
                DtInsertTable.Columns.Add("ProductIdNo", GetType(Int32))
                DtInsertTable.Columns.Add("PurchaseIdNo", GetType(Int32))
                DtInsertTable.Columns.Add("Quantity", GetType(Decimal))
                DtInsertTable.Columns.Add("Sequence", GetType(Int16))
                DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))
                DtInsertTable.Columns.Add("UnitSalesPrice", GetType(Decimal))
                DtInsertTable.Columns.Add("VatAmount", GetType(Decimal))
                DtInsertTable.Columns.Add("VatPercent", GetType(Decimal))

                DtUpdateTable.Columns.Add("BatchNo", GetType(String))
                DtUpdateTable.Columns.Add("BonusQuantity", GetType(Decimal))
                DtUpdateTable.Columns.Add("DiscountAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("ExpiryDate", GetType(Date))
                DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("Price", GetType(Decimal))
                DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("PurchaseIdNo", GetType(Int32))
                DtUpdateTable.Columns.Add("Quantity", GetType(Decimal))
                DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
                DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
                DtUpdateTable.Columns.Add("UnitSalesPrice", GetType(Decimal))
                DtUpdateTable.Columns.Add("VatAmount", GetType(Decimal))
                DtUpdateTable.Columns.Add("VatPercent", GetType(Decimal))
            End If

            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            AddHandler view.ProductCodeValidating, AddressOf OnProductCodeValidating
            AddHandler view.ProductNameValidating, AddressOf OnProductNameValidating
            AddHandler view.PostData, AddressOf OnPostData
            AddHandler view.RowChanged, AddressOf OnRowChanged
            _defaultUserWarehouseIdNo = Service.GetField(Of Int16, Int16, Int16)(AppSettingGroupSelector.UserDefaultWarehouse, GlobalVariables.UserIdNo, "AppSetting", "AppSettingGroupIdNo", "Selector1IdNo", "selector2IdNo")
        End Sub


        Public Sub FilterRecords()
            ' force move to last record to force the retrieval of filtered records
            GoLastRecord()
        End Sub


        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Supplier", "SupplierIdNo", Nothing, Nothing},
                                    New Object() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"},
                                    New Object() {"User", "UserIdNo", "IdNo,UserName", Nothing}})
            MakeVarDataSources({New Object() {"Unit", "UnitsByCode", Nothing, Nothing},
                                New Object() {"Product", "ProductsByCode", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "ProductName"}})
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.PurchaseDetails, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PurchaseDetailFilter)
                UpdateSupplierDate()
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            If PurchaseOrder Then
                workRow("BonusQuantity") = itemDataView.BonusQuantity
                workRow("DiscountAmount") = itemDataView.DiscountAmount
                workRow("NetAmount") = itemDataView.NetAmount
                workRow("Price") = itemDataView.Price
                workRow("ProductIdNo") = itemDataView.ProductIdNo
                workRow("PurchaseOrderIdNo") = View.IdNo
                workRow("Quantity") = itemDataView.Quantity
                workRow("UnitIdNo") = itemDataView.UnitIdNo
                workRow("VatAmount") = itemDataView.VatAmount
                workRow("VatPercent") = itemDataView.VatPercent
            Else
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
            End If

        End Sub

        Public Function PurchaseDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_purchaseItemService, DtUpdateTable, DtInsertTable, passedValue, IIf(PurchaseOrder, "PurchaseOrderIdNo", "PurchaseIdNo"))
            If retVal >= 0 AndAlso Not IsEmpty(View.VatNumber) Then
                Service.UpdateVatNumber(View.VatNumber, View.SupplierIdNo)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsBizDataValid Then
                If Not PurchaseOrder Then
                    For Each item In View.PurchaseDetails
                        If item.NeedsExpiryDate AndAlso (item.ExpiryDate Is Nothing OrElse item.ExpiryDate.Value = Date.MinValue) Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            MessagingService.ShowPmMessage(True, "MsgExpDateNeeded", {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        End If
                    Next
                End If
            Else
                retValue = False
            End If
            Return retValue
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim cr As New CrPrintableArgs
            Dim pr As New PrintReportPresenter(Of InvTransactionModel)
            Dim title As String
            If PurchaseOrder Then
                title = MessagingService.TranslateCaption("Purchase Order Report")
                cr.ReportFileName = "Purchase Order Report.Rpt"
                cr.Language = CultureInfo.CurrentCulture.Name
                cr.ReportParameters = {cr.Language, "Language", title, "ReportTitle", View.IdNo, "PurchaseOrderIdNo"}
            Else
                title = MessagingService.TranslateCaption("Purchase Report")
                cr.ReportFileName = "Purchase Report.Rpt"
                cr.Language = CultureInfo.CurrentCulture.Name
                cr.ReportParameters = {cr.Language, "Language", title, "ReportTitle", View.IdNo, "PurchaseIdNo"}
            End If

            pr.PrintReport(cr.ReportFileName, cr, False)
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.PurchaseDetails IsNot Nothing And View.PurchaseDetails.Count() > 0 Then
                DtUpdateTable.Clear()
                '_PurchaseItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

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
                        Case $"ProductCode"
                            InitializePurchaseDetailValues(eventType.BindingSource, purchaseDetail.ProductCode)

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
                        Case "UnitIdNo"
                            If .Price <> 0 Then
                                .Price = RecomputeNewPrice(eventType.BindingSource.Current)
                                SetAmounts(purchaseDetail)
                            End If
                    End Select
                    .UnitCost = GetUnitCost(purchaseDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

        Private Sub InitializePurchaseDetailValues(ByRef bs As BindingSource, productCode As String)
            Dim product As ProductModel = GetProductModel(productCode)
            If product IsNot Nothing Then
                If productCode <> bs.Current.ProductCode Then
                    With bs.Current
                        .ProductIdNo = product.IdNo
                        .ProductName = product.ProductName
                        .UnitIdNo = product.BaseUnitIdNo
                        If .Quantity = 0 Then
                            .Quantity = 1
                        End If
                        SetPurchaseDetailValues(product, bs.Current)
                        .ProductCode = product.ProductCode
                    End With
                End If
            Else
                bs.Current.ProductIdNo = ""
                bs.Current.ProductName = ""
                MessagingService.Show(True, "Invalid Product Code!")
            End If
        End Sub


        Private Sub OnProductCodeValidating(productCode As String, control As Control)
            Dim product As New ProductModel
            product = GetProductModel(productCode)
            If product.ProductName Is Nothing Then
                View.ProductCodeIsValid = False
                'allow null Product Code, since user can enter Product Name instead of Product Code.
            Else
                View.ProductCodeIsValid = True
                With View.PurchaseDetailsBs.Current
                    .ProductIdNo = product.IdNo
                    .ProductName = product.ProductName
                    .UnitIdNo = product.BaseUnitIdNo
                    .Quantity = 1
                    .UnitCost = Service.GetLastPurchaseCostBaseUnit(product.IdNo)
                    .NetAmount = .Price * .Quantity
                    .NeedsExpiryDate = Service.GetField(Of Boolean, Integer)(product.IdNo, "Product_View", "IdNo", "NeedsExpiryDate")
                End With
            End If
        End Sub

        Private Sub OnProductNameValidating(textToSearch As String, control As Control)
            If textToSearch.Contains("<GS>") Then
                Dim qrCodeData As Object = New ExpandoObject
                Dim qrCodeText As String = textToSearch
                qrCodeData = Accounts.AccountHelpers.GetQrCodeInfo(textToSearch)
                View.PurchaseDetailsBs.Current.ProductCode = GetProductCodeFromGTin(qrCodeData.GTin)
            Else
                Dim formToRun As New ProductFinder(textToSearch, control)
                formToRun.Presenter = New ProductFinderPresenter(Of ProductModel)(formToRun)
                If formToRun.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim product As ProductModel = formToRun.Product
                    If product IsNot Nothing Then
                        View.PurchaseDetailsBs.Current.ProductName = product.ProductName
                        View.NumberOfUnits = formToRun.NoOfUnits
                        If product Is Nothing Then
                            View.ProductNameIsValid = False
                        Else
                            View.ProductNameIsValid = True
                            View.PurchaseDetailsBs.Current.ProductCode = product.ProductCode
                            With View.PurchaseDetailsBs.Current
                                .ProductIdNo = product.IdNo
                                .ProductName = product.ProductName
                                .ProductCode = product.ProductCode
                                .UnitIdNo = product.BaseUnitIdNo
                                .Quantity = 1
                                .UnitCost = Service.GetLastPurchaseCostBaseUnit(product.IdNo)
                                .NetAmount = .Price * .Quantity
                                .NeedsExpiryDate = Service.GetField(Of Boolean, Integer)(product.IdNo, "Product_View", "IdNo", "NeedsExpiryDate")
                            End With
                            View.PurchaseDetailsBs.ResetBindings(False)
                        End If
                    Else
                        View.ProductNameIsValid = False
                    End If
                Else
                    View.ProductNameIsValid = False
                End If
            End If
        End Sub


        Private Sub SetPurchaseDetailValues(pModel As ProductModel, purchaseDetail As PurchaseDetailView)
            Dim lastPurchaseInfo As Object = New ExpandoObject
            lastPurchaseInfo = GetLastPurchaseInfo(pModel)
            With purchaseDetail
                If lastPurchaseInfo Is Nothing Then
                    SetDefaultUnit(pModel, purchaseDetail)
                Else
                    .UnitIdNo = lastPurchaseInfo.UnitIdNo
                    .UnitSalesPrice = lastPurchaseInfo.UnitSalesPrice
                    .UnitCount = GetUnitCount(pModel, purchaseDetail)
                    .Price = lastPurchaseInfo.Price
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
            If Math.Round(purchaseDetail.Quantity + purchaseDetail.BonusQuantity, 4) = 0 Then
                Return 0
            End If
            Return Math.Round(purchaseDetail.NetAmount / (purchaseDetail.Quantity + purchaseDetail.BonusQuantity), 4)
        End Function

        Private Function RecomputeDiscountPercentage(purchaseDetail As PurchaseDetailView) As Decimal
            Return Math.Round(IIf(purchaseDetail.GrossAmount = 0, 0, purchaseDetail.DiscountAmount / purchaseDetail.GrossAmount * 100), 2)
        End Function

        Private Function RecomputePrice(purchaseDetail As PurchaseDetailView) As Decimal
            Return Math.Round(IIf(purchaseDetail.Quantity = 0, 0, purchaseDetail.GrossAmount / purchaseDetail.Quantity), 2)
        End Function

        Private Function RecomputeNewPrice(purchaseDetail As PurchaseDetailView) As Decimal
            Dim newPrice As Decimal
            Dim product As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(purchaseDetail.ProductIdNo)
            Dim lastPurchaseInfo As Object = New ExpandoObject
            lastPurchaseInfo = GetLastPurchaseInfo(product)
            Dim baseUnitPrice As Decimal = ConvertToBaseUnitPrice(product, lastPurchaseInfo)
            Dim productUnitIdNo = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(purchaseDetail.ProductIdNo, purchaseDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
            If purchaseDetail.UnitIdNo = product.BaseUnitIdNo Then
                newPrice = baseUnitPrice
            Else
                Dim pUnitInfo As Object = New ExpandoObject
                pUnitInfo = Service.GetFieldsWithIdNo(productUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                If pUnitInfo Is Nothing Then
                    newPrice = 0
                Else
                    newPrice = IIf(pUnitInfo.UnitQty = 0, 0, baseUnitPrice * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
                End If
            End If
            Return newPrice
        End Function

        Private Function ConvertToBaseUnitPrice(product As ProductModel, lastPurchaseInfo As Object)
            Dim baseUnitPrice As Decimal
            If lastPurchaseInfo.UnitIdNo = product.BaseUnitIdNo Then
                baseUnitPrice = lastPurchaseInfo.Price
            Else
                Dim productUnitIdNo As Int32 = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, lastPurchaseInfo.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
                Dim pUnitInfo = Service.GetFieldsWithIdNo(productUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                baseUnitPrice = IIf(pUnitInfo.BaseQty = 0, 0, lastPurchaseInfo.Price * pUnitInfo.Unitqty / pUnitInfo.BaseQty)
            End If
            Return baseUnitPrice
        End Function

        Private Function RecomputeVatPercentage(purchaseDetail As PurchaseDetailView) As Decimal
            Return IIf(purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount = 0, 0, purchaseDetail.VatAmount / (purchaseDetail.GrossAmount - purchaseDetail.DiscountAmount) * 100)
        End Function

        Private Function GetProductCodeFromGTin(gTin As String) As String
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
            Return productModel.ProductCode
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
            Return True
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
            InitializePurchaseDetailValues(bs.Current, productCode)
            If purchaseDetail.ProductIdNo > 0 Then
                UpdatePurchaseHistory(purchaseDetail.ProductIdNo)
            End If
            bs.EndEdit()
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Sub OnProductUnitSelection(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub OnUnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String)
            If newUnit = 0 Then
                MessagingService.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", formattedValue, "fieldDescription", "Unit"})
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
            CreateVarDataSources(data)
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
            If _defaultUserWarehouseIdNo Is Nothing OrElse _defaultUserWarehouseIdNo = 0 Then
                Dim wareHouse = Service.GetTopOneFields("Warehouse", "IdNo", "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString(), "IdNo", True)
                View.WarehouseIdNo = wareHouse.IdNo
            Else
                View.WarehouseIdNo = _defaultUserWarehouseIdNo
            End If
        End Sub

        Private Function OnPostData(idNo As Int32) As Boolean
            Dim okToPost As Boolean = False
            Dim retVal As Boolean = False
            If UserIsASuperAdministrator() Then
                okToPost = True
            ElseIf EditMode Or AddMode Then
                MessagingService.Show(True, "MsgCannotPostUnsaved")
            ElseIf View.WarehouseIdNo = _defaultUserWarehouseIdNo Then
                ' you can post if your default warehouseid is the same as the current warehouseidno
                okToPost = True
            End If
            If okToPost Then
                retVal = Service.PostData(idNo)
                If retVal Then
                    View.Posted = True
                Else
                    MessageBox.Show("Posting Error")
                    Debugger.Break()
                End If
            End If
            Return retVal

        End Function


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

        Public Sub UpdateSupplierDate()
            If View.TransactionDate IsNot Nothing Then
                If View.InvoiceDate Is Nothing Then
                    View.InvoiceDate = View.TransactionDate
                End If
            Else
                View.InvoiceDate = Nothing
            End If
        End Sub

        'Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
        '    Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
        '    Dim purchaseDetail As PurchaseDetailView = bs.Current
        '    Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
        '    productCode = productModel.ProductCode
        '    OnProductCodeChanged(productCode, bs)
        'End Sub

    End Class

End Namespace