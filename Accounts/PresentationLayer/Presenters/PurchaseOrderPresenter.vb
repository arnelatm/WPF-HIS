
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PurchaseOrderPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IPurchaseOrderView, TM)
        Implements ISubscriber(Of DgvItemsChanged), ICrPrintableReportView

        Public Event PrintReport As ICrPrintableReportView.PrintReportEventHandler Implements ICrPrintableReportView.PrintReport
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _productService As New AccountsService("Product")
        Private ReadOnly _inventoryService As New AccountsService("Inventory")

        Public Sub New(view As IPurchaseOrderView)
            MyBase.New(view)
            DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()
            TableName = "PurchaseOrder"
            WithTreeView = False
            Service = New AccountsService("PurchaseOrder")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("PurchaseOrderIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Quantity", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("UnitCost", GetType(Decimal))
            DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("PurchaseOrderIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Quantity", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitCost", GetType(Decimal))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            AddHandler view.ProductCodeValidating, AddressOf OnProductCodeValidating
            AddHandler view.ProductNameValidating, AddressOf OnProductNameValidating

        End Sub



        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            data.Add({"Supplier", "SupplierIdNo", Nothing, Nothing, "SupplierName"})
            data.Add({"User", "UserIdNo", "IdNo,UserName", Nothing})
            CreateDataSourceThread(data)

            data.Clear()
            data.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            data.Add({"Product", "ProductsByCode", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "ProductName"})
            CreateLookupDataThread(data)
            data.Clear()

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.PurchaseOrderDetails, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PurchaseOrderDetailFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("PurchaseOrderIdNo") = View.IdNo
            workRow("NetAmount") = itemDataView.NetAmount
            workRow("ProductIdNo") = itemDataView.ProductIdNo
            workRow("Quantity") = itemDataView.Quantity
            workRow("UnitCost") = itemDataView.UnitCost
            workRow("UnitIdNo") = itemDataView.UnitIdNo
        End Sub

        Public Function PurchaseOrderDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private ReadOnly _PurchaseOrderItemService As New AccountsService("PurchaseOrderDetail")

        Public Property Errors As List(Of String) Implements IView.Errors

        Private Property IView_DataFilter As String Implements IView.DataFilter

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_PurchaseOrderItemService, DtUpdateTable, DtInsertTable, passedValue, "PurchaseOrderIdNo")
        End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue As Boolean = True
        '    'If MyBase.IsBizDataValid Then
        '    '    ' 
        '    'Else
        '    '    retValue = False
        '    'End If
        '    Return retValue
        'End Function

        Public Overrides Sub GoPrintRecord()
            Dim cr As New CrPrintableArgs
            Dim pr As New PrintReportPresenter(Of PurchaseOrderModel)
            Dim title As String = Messaging.TranslateCaption("Purchase Order")
            cr.ReportFileName = "Purchase Order.Rpt"
            cr.Language = CultureInfo.CurrentCulture.Name
            cr.ReportParameters = {cr.Language, "Language", title, "ReportTitle", View.IdNo, "PurchaseOrderIdNo"}
            pr.PrintReport(cr.ReportFileName, cr, False)
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.PurchaseOrderDetails IsNot Nothing And View.PurchaseOrderDetails.Count() > 0 Then
                DtUpdateTable.Clear()
                '_PurchaseOrderItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub OnPurchaseOrderdgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            Dim PurchaseOrderDetail As PurchaseOrderDetailView = eventType.BindingSource.Current
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        'Case $"ProductCode"
                        '    InitializePurchaseOrderDetailValues(eventType.BindingSource, PurchaseOrderDetail.ProductCode)
                        Case $"Quantity"
                            'SetAmounts(PurchaseOrderDetail)
                            eventType.BindingSource.ResetCurrentItem()
                        Case "NetAmount"
                            '.Price = IIf(.Quantity = 0, 0, .GrossAmount / .Quantity)
                        Case "UnitIdNo"
                            RecomputeNewCost(PurchaseOrderDetail)
                    End Select
                    .NetAmount = GetNetAmount(PurchaseOrderDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub


        Private Sub RecomputeNewCost(PurchaseOrderDetail As PurchaseOrderDetailView)
            If PurchaseOrderDetail.UnitCost <> 0 Then
                Dim product As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(PurchaseOrderDetail.ProductIdNo)
                Dim lastCost As Decimal = Service.GetLastPurchaseCost(PurchaseOrderDetail.ProductIdNo)
                If PurchaseOrderDetail.UnitIdNo = product.BaseUnitIdNo Then
                    PurchaseOrderDetail.UnitCost = lastCost
                Else
                    Dim pUnitInfo As Object = New ExpandoObject
                    Dim pUnitIdNo As Int32 = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, PurchaseOrderDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
                    pUnitInfo = Service.GetFieldsWithIdNo(pUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                    If pUnitInfo Is Nothing Then
                        PurchaseOrderDetail.UnitCost = 0
                    Else
                        PurchaseOrderDetail.UnitCost = IIf(pUnitInfo.UnitQty = 0, 0, lastCost * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
                    End If
                End If
            End If
        End Sub

        'Private Sub RecomputePrice(oldUnit As Int16, newUnit As Int16, bs As BindingSource)
        '    If oldUnit <> newUnit Then
        '        Dim inventory As IInventoryView
        '        Dim newPrice As Decimal
        '        Dim productIdNo As Int32 = bs.Current.ProductIdNo
        '        Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        '        Dim baseUnitIdNo As Int16
        '        inventory = _inventoryService.GetRecordByIdNo(Of InventoryModel)(bs.Current.InventoryIdNo)
        '        Dim invUnitCost As Decimal
        '        invUnitCost = inventory.UnitCost
        '        baseUnitIdNo = productModel.BaseUnitIdNo
        '        Dim inventoryIdNo As Int32 = bs.Current.InventoryIdNo
        '        Dim unitQty, baseQty As Int16
        '        Dim baseUnitCost As Decimal
        '        If newUnit = baseUnitIdNo Then
        '            baseUnitCost = inventory.UnitCost
        '        Else
        '            unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
        '            baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
        '            baseUnitCost = IIf(baseQty = 0, 0, unitQty / baseQty * inventory.UnitCost)
        '        End If
        '        bs.Current.UnitCost = newPrice
        '        SetAmounts(bs.Current)
        '    End If
        'End Sub

        Private Function ConvertToBaseUnitPrice(product As ProductModel, PurchaseOrderDetail As PurchaseOrderDetailView)
            Dim baseUnitPrice As Decimal
            If PurchaseOrderDetail.UnitIdNo = product.BaseUnitIdNo Then
                baseUnitPrice = PurchaseOrderDetail.UnitCost
            Else
                Dim productUnitIdNo As Int32 = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, PurchaseOrderDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
                Dim pUnitInfo = Service.GetFieldsWithIdNo(productUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                baseUnitPrice = IIf(pUnitInfo.BaseQty = 0, 0, PurchaseOrderDetail.UnitCost * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
            End If
            Return baseUnitPrice
        End Function

        Private Sub OnProductCodeValidating(productCode As String, control As Control)
            Dim entryIsValid As Boolean = False
            Dim selectionCancelled As Boolean = False
            Dim itemCodeOkButNonInInventory As Boolean = False
            If productCode Is Nothing OrElse productCode = "" Then
                entryIsValid = True
            Else
                Dim product As New ProductModel
                product = GetProductModel(productCode)
                If product.ProductName Is Nothing Then
                    entryIsValid = False
                Else
                    With View.PurchaseOrderDetailsBs.Current
                        .ProductIdNo = product.IdNo
                        .ProductName = product.ProductName
                        .UnitIdNo = product.BaseUnitIdNo
                        .Quantity = 1
                        .UnitCost = Service.GetLastPurchaseCost(product.IdNo)
                        .NetAmount = .UnitCost * .Quantity
                    End With
                    entryIsValid = True
                End If
            End If
            If Not entryIsValid Then
                If Not (selectionCancelled Or itemCodeOkButNonInInventory) Then
                    Dim errorText = Messaging.GetParametrizedMessage(True, "MsgInvalidValue", {"fieldValue", productCode, "fieldDescription", "Product Code"})
                    View.ValidationErrorText = errorText
                    entryIsValid = False
                    Messaging.Show(errorText)
                End If
            End If
            View.ProductCodeIsValid = entryIsValid
        End Sub

        Private Sub UpdateIdNameUnit(product As ProductModel)
            View.PurchaseOrderDetailsBs.Current.ProductIdNo = product.IdNo
            View.PurchaseOrderDetailsBs.Current.ProductName = product.ProductName
            View.PurchaseOrderDetailsBs.Current.UnitIdNo = product.BaseUnitIdNo
        End Sub

        Private Sub UpdateCodeNameUnit(product As ProductModel)
            View.PurchaseOrderDetailsBs.Current.ProductIdNo = product.IdNo
            View.PurchaseOrderDetailsBs.Current.ProductCode = product.ProductCode
            View.PurchaseOrderDetailsBs.Current.ProductName = product.ProductName
            View.PurchaseOrderDetailsBs.Current.UnitIdNo = product.BaseUnitIdNo
        End Sub

        Private Sub OnProductNameValidating(textToSearch As String, control As Control)
            View.ProductNameIsValid = True
            If textToSearch.Contains("<GS>") Then
                Dim qrCodeData As Object = New ExpandoObject
                Dim qrCodeText As String = textToSearch
                qrCodeData = Accounts.AccountHelpers.GetQrCodeInfo(textToSearch)
                View.PurchaseOrderDetailsBs.Current.ProductCode = GetProductCodeFromGTin(qrCodeData.GTin)
            Else
                If ProductNameIsValid(textToSearch, control) Then
                    ' View.ProductNameIsValid = True (default is already true)
                Else
                    View.ProductNameIsValid = False
                End If
            End If
        End Sub

        Private Function ProductNameIsValid(textToSearch As String, control As Control) As Boolean
            Dim retVal As Boolean = True
            Dim formToRun As New ProductFinder(textToSearch, control)
            formToRun.Presenter = New ProductFinderPresenter(Of ProductModel)(formToRun)
            If formToRun.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim product As ProductModel = formToRun.Product
                If product Is Nothing Then
                    View.ProductNameIsValid = False
                Else
                    product = SetProductInitialValues(product)
                    View.PurchaseOrderDetailsBs.Current.InventoryIdNo = 0
                End If
            Else
                retVal = False
            End If
            Return retVal
        End Function

        Private Function SetProductInitialValues(product As ProductModel) As ProductModel
            With View.PurchaseOrderDetailsBs.Current
                .ProductIdNo = product.IdNo
                .ProductName = product.ProductName
                .ProductCode = product.ProductCode
                .UnitIdNo = product.BaseUnitIdNo
                .Quantity = 1
                .UnitCost = Service.GetLastPurchaseCost(product.IdNo)
                .NetAmount = .UnitCost * .Quantity
            End With
            View.PurchaseOrderDetailsBs.ResetBindings(False)
            Return product
        End Function

        'Private Sub CheckStock(product As ProductModel)
        '    CountInventory(product.IdNo)
        'End Sub

        'Private Function CountInventory(productIdNo As Int32)
        '    Dim nCount As Int16 = 0
        '    nCount = Service.GetRecord
        'End Function

        Private Sub SetPurchaseOrderDetailValues(pModel As ProductModel, PurchaseOrderDetail As PurchaseOrderDetailView)
            Dim LastPurchaseInfo As Object = New ExpandoObject
            LastPurchaseInfo = GetLastPurchaseInfo(pModel)
            With PurchaseOrderDetail
                If LastPurchaseInfo Is Nothing Then
                    SetDefaultUnit(pModel, PurchaseOrderDetail)
                Else
                    .UnitIdNo = LastPurchaseInfo.UnitIdNo
                    .UnitCount = GetUnitCount(pModel, PurchaseOrderDetail)
                End If
                SetAmounts(PurchaseOrderDetail)
                .ProductIdNo = pModel.IdNo
            End With
        End Sub

        Private Sub SetAmounts(PurchaseOrderDetail As PurchaseOrderDetailView)
            With PurchaseOrderDetail
                .NetAmount = GetNetAmount(PurchaseOrderDetail)
                '.UnitCost = GetUnitCost(PurchaseOrderDetail)
            End With
        End Sub

        Private Function GetNetAmount(PurchaseOrderDetail As PurchaseOrderDetailView) As Decimal
            Return Math.Round(PurchaseOrderDetail.UnitCost * PurchaseOrderDetail.Quantity, 2)
        End Function

        Public Function GetProductModel(productCode As String) As ProductModel
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
            Return result
        End Function

        'Public Overrides Function IsOkToDeleteRecord() As Boolean
        '    Dim retValue As Boolean = True
        '    If MyBase.IsOkToDeleteRecord Then
        '        'If ReconciledEntriesExist(View.PurchaseOrderDetails, "AP") Then
        '        '    retValue = False
        '        'End If
        '    Else
        '        retValue = False
        '    End If
        '    Return retValue
        'End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'For Each item In View.PurchaseOrderDetails
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
            'InitializePurchaseOrderDetailValues(bs, productCode)
            'bs.EndEdit()
            ''bs.ResetCurrentItem()
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Function GetProductCodeFromGTin(gTin As String) As String
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
            Return productModel.ProductCode
        End Function

        Private Sub OnProductUnitSelection(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        'Private Sub OnUnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String)
        '    If newUnit = 0 Then
        '        Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", formattedValue, "fieldDescription", "Unit"})
        '    Else
        '        RecomputePrice(oldUnit, newUnit, bs)
        '    End If
        'End Sub

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

        Private Sub SetDefaultUnit(item As ProductModel, PurchaseOrderDetail As PurchaseOrderDetailView)
            Dim noOfUnits = GetUnitCount(item, PurchaseOrderDetail)
            PurchaseOrderDetail.UnitCount = noOfUnits
            If noOfUnits = 1 OrElse PurchaseOrderDetail.UnitIdNo = 0 Then
                PurchaseOrderDetail.UnitIdNo = item.BaseUnitIdNo
            Else
                Dim nCount As Int16 = Service.CountRecordWith2Key(Of Int32, Int16)("ProductUnit", "ProductIdNo", "UnitIdNo", item.IdNo, PurchaseOrderDetail.UnitIdNo)
                If nCount = 0 Then
                    PurchaseOrderDetail.UnitIdNo = item.BaseUnitIdNo
                Else
                    PurchaseOrderDetail.UnitIdNo = 0
                End If
            End If
        End Sub

        Private Function GetUnitCount(item As ProductModel, PurchaseOrderDetail As PurchaseOrderDetailView) As Int32
            Return Service.CountRecordWithKey(Of Int32)("ProductUnit", "ProductIdNo", item.IdNo) + 1
        End Function

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.TransactionDate = Date.Now()
            View.UserIdNo = GlobalVariables.UserIdNo
            Dim wareHouse = Service.GetTopOneFields("Warehouse", "IdNo", "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString(), "IdNo", True)
            View.WarehouseIdNo = wareHouse.IdNo
        End Sub

        'Private Function OnPostData(idNo As Int32) As Boolean
        '    Dim retVal As Boolean = Service.PostData(idNo)
        '    If retVal Then
        '        View.Posted = True
        '    End If
        '    Return retVal
        'End Function

    End Class

End Namespace