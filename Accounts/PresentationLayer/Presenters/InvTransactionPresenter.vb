Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class InvTransactionPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IInvTransactionView, TM)
        Implements ISubscriber(Of DgvItemsChanged), ISubscriber(Of DgvItemsValidating)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _inventoryService As New AccountsService("Inventory")
        Private ReadOnly _productService As New AccountsService("Product")

        Public Sub New(view As IInvTransactionView)
            MyBase.New(view)
            DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()
            TableName = "InvTransaction"
            WithTreeView = False
            Service = New AccountsService("InvTransaction")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("BatchNo", GetType(String))
            DtInsertTable.Columns.Add("ExpiryDate", GetType(Date))
            DtInsertTable.Columns.Add("InventoryIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("InvTransactionIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Quantity", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("UnitCost", GetType(Decimal))
            DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))

            DtUpdateTable.Columns.Add("BatchNo", GetType(String))
            DtUpdateTable.Columns.Add("ExpiryDate", GetType(Date))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("InventoryIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("InvTransactionIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Quantity", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitCost", GetType(Decimal))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            'AddHandler view.GTinScanned, AddressOf OnGTinScanned
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            'AddHandler view.UnitChanged, AddressOf OnUnitChanged
            AddHandler view.InvTransactionTypeChanged, AddressOf OnInvTransactionTypeChanged
            AddHandler view.PostData, AddressOf OnPostData
            AddHandler view.ProductCodeValidating, AddressOf OnProductCodeValidating
            AddHandler view.ProductNameValidating, AddressOf OnProductNameValidating

        End Sub



        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            data.Add({"Warehouse", "WarehouseToIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            data.Add({"InvTransType", "InvTransTypeIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "InvTransTypeCode"})
            data.Add({"User", "UserIdNo", "IdNo,UserName", Nothing})
            CreateDataSourceThread(data)

            data.Clear()
            data.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            data.Add({"Product", "ProductsByCode", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "ProductName"})
            'data.Add({"InvTransactionDetail", "InvTransactionHistory", Nothing, Nothing})
            CreateLookupDataThread(data)
            data.Clear()

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.InvTransactionDetails, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf InvTransactionDetailFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("BatchNo") = itemDataView.BatchNo
            workRow("ExpiryDate") = IIf(itemDataView.ExpiryDate Is Nothing, DBNull.Value, itemDataView.ExpiryDate)
            workRow("InventoryIdNo") = itemDataView.InventoryIdNo
            workRow("InvTransactionIdNo") = View.IdNo
            workRow("NetAmount") = itemDataView.NetAmount
            workRow("ProductIdNo") = itemDataView.ProductIdNo
            workRow("Quantity") = itemDataView.Quantity
            workRow("UnitCost") = itemDataView.UnitCost
            workRow("UnitIdNo") = itemDataView.UnitIdNo
        End Sub

        Public Function InvTransactionDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private ReadOnly _InvTransactionItemService As New AccountsService("InvTransactionDetail")

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_InvTransactionItemService, DtUpdateTable, DtInsertTable, passedValue, "InvTransactionIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsBizDataValid Then
                For Each item In View.InvTransactionDetails
                    If item.NeedsExpiryDate AndAlso (item.ExpiryDate Is Nothing OrElse item.ExpiryDate.Value = Date.MinValue) Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Messaging.ShowPmMessage(True, "MsgExpDateNeeded", {"lineNumber", lineNumber})
                        retValue = False
                        Exit For
                    End If
                Next
                If retValue Then
                    If View.InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                        If View.WarehouseToIdNo Is Nothing OrElse View.WarehouseToIdNo = 0 Then
                            retValue = False
                            Messaging.Show(True, "MsgWareHouseToBlank")
                        End If
                    End If
                End If
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
            'Dim cForm As New ReportForm("Accounts Payable Journal.Rpt", View.IdNo, "InvTransactionIdNo", transactionAmount, "ApAmountInWords", totalApAmount, "TotalLineAmountInWords", language, "Language")
            'cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.InvTransactionDetails IsNot Nothing And View.InvTransactionDetails.Count() > 0 Then
                DtUpdateTable.Clear()
                '_InvTransactionItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Private Function GetSupplierPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        End Function

        Public Sub OnInvTransactiondgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            Dim InvTransactionDetail As InvTransactionDetailView = eventType.BindingSource.Current
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        Case $"ProductCode"
                            InitializeInvTransactionDetailValues(eventType.BindingSource, InvTransactionDetail.ProductCode)
                        Case $"Quantity"
                            'SetAmounts(InvTransactionDetail)
                            eventType.BindingSource.ResetCurrentItem()
                        Case "NetAmount"
                            '.Price = IIf(.Quantity = 0, 0, .GrossAmount / .Quantity)
                        Case "UnitIdNo"
                            RecomputeNewCost(InvTransactionDetail)
                    End Select
                    .NetAmount = GetNetAmount(InvTransactionDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub


        Private Sub RecomputeNewCost(invTransactionDetail As InvTransactionDetailView)
            If invTransactionDetail.UnitCost <> 0 Then
                Dim product As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(invTransactionDetail.ProductIdNo)
                Dim inventory As InventoryModel
                If invTransactionDetail.InventoryIdNo <> 0 Then
                    inventory = _inventoryService.GetRecordByIdNo(Of InventoryModel)(invTransactionDetail.InventoryIdNo)
                    Dim baseUnitCost As Decimal = IIf(inventory.QtyOnHand = 0, 0, inventory.TotalCost / inventory.QtyOnHand)
                    If invTransactionDetail.UnitIdNo = product.BaseUnitIdNo Then
                        invTransactionDetail.UnitCost = baseUnitCost
                    Else
                        Dim pUnitInfo As Object = New ExpandoObject
                        Dim pUnitIdNo As Int32 = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, invTransactionDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
                        pUnitInfo = Service.GetFieldsWithIdNo(pUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                        invTransactionDetail.UnitCost = IIf(pUnitInfo.UnitQty = 0, 0, baseUnitCost * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
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

        Private Function ConvertToBaseUnitPrice(product As ProductModel, invTransactionDetail As InvTransactionDetailView)
            Dim baseUnitPrice As Decimal
            If invTransactionDetail.UnitIdNo = product.BaseUnitIdNo Then
                baseUnitPrice = invTransactionDetail.UnitCost
            Else
                Dim productUnitIdNo As Int32 = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, invTransactionDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
                Dim pUnitInfo = Service.GetFieldsWithIdNo(productUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
                baseUnitPrice = IIf(pUnitInfo.BaseQty = 0, 0, invTransactionDetail.UnitCost * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
            End If
            Return baseUnitPrice
        End Function

        Private Sub InitializeInvTransactionDetailValues(ByRef bs As BindingSource, productCode As String)
            Dim retVal As Boolean = False
            Dim product As ProductModel = GetProductModel(productCode)
            If product IsNot Nothing Then
                If productCode <> bs.Current.ProductCode Then
                    Dim inventory As New List(Of InventoryModel)
                    inventory = Service.GetRecordsWithGroupIdNo(Of InventoryModel)(product.IdNo, "ExpiryDate")
                    bs.Current.ProductIdNo = product.IdNo
                    bs.Current.ProductName = product.ProductName
                    bs.Current.UnitIdNo = product.BaseUnitIdNo
                    If inventory.Count() = 1 Then
                        With bs.Current
                            If .Quantity = 0 Then
                                .Quantity = inventory(0).QtyOnHand
                            End If
                            .ProductCode = product.ProductCode
                            .BatchNo = inventory(0).BatchNo
                            .ExpiryDate = inventory(0).ExpiryDate
                            .UnitCost = inventory(0).UnitCost
                            .NetAmount = inventory(0).UnitCost * inventory(0).QtyOnHand
                            .InventoryIdNo = inventory(0).IdNo
                        End With
                        retVal = True
                    Else
                        If View.InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Then
                            Messaging.Show(True, "MsgNoSuchInventory", "Error")
                        End If
                        If View.InvTransTypeIdNo Then
                        End If
                        View.ProductInventory = inventory
                    End If
                End If
            Else
                bs.Current.ProductIdNo = ""
                bs.Current.ProductName = ""
                Messaging.Show(True, "Invalid Product Code!")
            End If
        End Sub


        Private Sub OnProductCodeValidating(productCode As String, control As Control)
            Dim retVal As Boolean = False
            Dim product As New ProductModel
            product = GetProductModel(productCode)
            If product.ProductName Is Nothing Then
                View.ProductCodeIsValid = True
                'allow null Product Code, since user can enter Product Name instead of Product Code.
            Else
                'If productCode <> View.InvTransactionDetailsBs.Current.ProductCode Then
                ' always check even if the same code as before, stock values may have changed
                ' since the last editing
                Dim inventory As New List(Of InventoryModel)
                inventory = Service.GetRecordsWithGroupIdNo(Of InventoryModel)(product.IdNo, "ExpiryDate")
                View.InvTransactionDetailsBs.Current.ProductIdNo = product.IdNo
                View.InvTransactionDetailsBs.Current.ProductName = product.ProductName
                View.InvTransactionDetailsBs.Current.UnitIdNo = product.BaseUnitIdNo
                If inventory.Count() = 1 Then
                    UpdateInvTransactionDetail(inventory, 0)
                    'View.InvTransactionDetailsBs.Current.ProductCode = product.ProductCode
                ElseIf inventory.Count() > 1 Then
                    SelectInventory(inventory, control)
                Else
                    If View.InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Then
                        Messaging.Show(True, "MsgNoSuchInventory", "Error")
                        View.ProductCodeIsValid = False
                    Else
                        View.ProductCodeIsValid = True
                    End If
                    View.ProductInventory = inventory
                    View.ProductCodeIsValid = True
                End If
                'Else
                ' same no need to change
                'View.ProductCodeIsValid = True
                'Messaging.Show(True, "Invalid Product Code!")
                'End If
            End If
        End Sub

        Private Sub OnProductNameValidating(textToSearch As String, control As Control)
            If textToSearch.Contains("<GS>") Then
                Dim qrCodeData As Object = New ExpandoObject
                Dim qrCodeText As String = textToSearch
                qrCodeData = Accounts.AccountHelpers.GetQrCodeInfo(textToSearch)
                View.InvTransactionDetailsBs.Current.ProductCode = GetProductCodeFromGTin(qrCodeData.GTin)
            Else
                Dim formToRun As New ProductFinder(textToSearch, control)
                formToRun.Presenter = New ProductFinderPresenter(Of ProductModel)(formToRun)
                If formToRun.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim product As ProductModel = formToRun.Product
                    View.InvTransactionDetailsBs.Current.ProductName = product.ProductName

                    View.NumberOfUnits = formToRun.NoOfUnits
                    If product Is Nothing Then
                        View.ProductNameIsValid = False
                    Else
                        View.ProductNameIsValid = True
                        View.InvTransactionDetailsBs.Current.ProductCode = product.ProductCode
                        Dim inventory As New List(Of InventoryModel)
                        inventory = Service.GetRecordsWithGroupIdNo(Of InventoryModel)(product.IdNo, "ExpiryDate")
                        View.InvTransactionDetailsBs.Current.ProductIdNo = product.IdNo
                        View.InvTransactionDetailsBs.Current.ProductName = product.ProductName
                        View.InvTransactionDetailsBs.Current.UnitIdNo = product.BaseUnitIdNo
                        If inventory.Count() = 1 Then
                            UpdateInvTransactionDetail(inventory, 0)
                        ElseIf inventory.Count() > 1 Then
                            SelectInventory(inventory, control)
                        Else
                            If View.InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Then
                                Messaging.Show(True, "MsgNoSuchInventory", "Error")
                                View.ProductCodeIsValid = False
                            Else
                                View.ProductCodeIsValid = True
                            End If
                            View.ProductInventory = inventory
                            View.ProductCodeIsValid = True
                        End If
                        View.InvTransactionDetailsBs.ResetBindings(False)
                    End If
                Else
                    View.ProductNameIsValid = False
                End If
            End If
        End Sub

        Private Sub UpdateInvTransactionDetail(inventory As List(Of InventoryModel), selectedIndex As Int16)
            With View.InvTransactionDetailsBs.Current
                .Quantity = SetInitialQuantity(inventory(selectedIndex))
                .BatchNo = inventory(selectedIndex).BatchNo
                .ExpiryDate = inventory(selectedIndex).ExpiryDate
                .InventoryIdNo = inventory(selectedIndex).IdNo
                .UnitCost = inventory(selectedIndex).UnitCost
                .NetAmount = inventory(selectedIndex).UnitCost * inventory(selectedIndex).QtyOnHand
                .OriginalUnitCost = inventory(selectedIndex).UnitCost
            End With
            View.ProductInventory = inventory
            View.ProductCodeIsValid = True
        End Sub

        Private Sub SelectInventory(inventory As List(Of InventoryModel), control As Control)
            Dim formToRun As New InventorySelector(inventory, control)
            formToRun.Presenter = New InventorySelectorPresenter(Of InventoryModel)(formToRun)
            If formToRun.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim selectedInvIndex As Int32 = formToRun.SelectedInvIndex
                UpdateInvTransactionDetail(inventory, selectedInvIndex)
            Else
                View.ProductCodeIsValid = False
            End If
        End Sub


        Private Function SetInitialQuantity(inventory As InventoryModel) As Int16
            Dim qty As Int16
            Dim InventoryAction As String
            InventoryAction = Service.GetField(Of String, Int16)(View.InvTransTypeIdNo, "InvTransType", "IdNo", "InventoryAction")
            If InventoryAction Is Nothing Then
                qty = 0
            ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                qty = inventory.QtyOnHand
            Else
                qty = 1
            End If
            Return qty
        End Function
        Private Sub CheckStock(product As ProductModel)
            CountInventory(product.IdNo)
        End Sub

        Private Function CountInventory(productIdNo As Int32)
            Dim nCount As Int16 = 0
            nCount = Service.GetRecord
        End Function

        Private Sub SetInvTransactionDetailValues(pModel As ProductModel, InvTransactionDetail As InvTransactionDetailView)
            Dim lastInvTransactionInfo As Object = New ExpandoObject
            lastInvTransactionInfo = GetLastInvTransactionInfo(pModel)
            With InvTransactionDetail
                If lastInvTransactionInfo Is Nothing Then
                    SetDefaultUnit(pModel, InvTransactionDetail)
                Else
                    .UnitIdNo = lastInvTransactionInfo.UnitIdNo
                    .UnitCount = GetUnitCount(pModel, InvTransactionDetail)
                End If
                SetAmounts(InvTransactionDetail)
                .ProductIdNo = pModel.IdNo
                .NeedsExpiryDate = GetNeedsExpiryDate(pModel.CategoryIdNo)
            End With
        End Sub

        Private Sub SetAmounts(InvTransactionDetail As InvTransactionDetailView)
            With InvTransactionDetail
                .NetAmount = GetNetAmount(InvTransactionDetail)
                '.UnitCost = GetUnitCost(InvTransactionDetail)
            End With
        End Sub

        Private Function GetNetAmount(InvTransactionDetail As InvTransactionDetailView) As Decimal
            Return Math.Round(InvTransactionDetail.UnitCost * InvTransactionDetail.Quantity, 2)
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
            'If ReconciledEntriesExist(View.InvTransactionDetails, "AP") Then
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
                'If ReconciledEntriesExist(View.InvTransactionDetails, "AP") Then
                '    retValue = False
                'End If
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'For Each item In View.InvTransactionDetails
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
            'InitializeInvTransactionDetailValues(bs, productCode)
            'bs.EndEdit()
            ''bs.ResetCurrentItem()
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Function GetProductCodeFromGTin(gTin As String) As String
            Dim bs = View.InvTransactionDetailsBs
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim InvTransactionDetail As InvTransactionDetailView = bs.Current
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

        Private Function GetLastInvTransactionInfo(pModel As ProductModel) As ExpandoObject
            Return Service.GetTopOneFields("InvTransactionDetail", "Price,UnitSalesPrice,UnitIdNo", "ProductIdNo = " & pModel.IdNo.ToString(), "IdNo", False)
        End Function

        Private Function GetSalesPrice(item As ProductModel) As Decimal
            Dim price As Decimal

            price = Service.GetField(Of Decimal, Int32)(item.IdNo, "Product", "IdNo", "Price_Cash")
            Return price
        End Function

        Private Sub SetDefaultUnit(item As ProductModel, InvTransactionDetail As InvTransactionDetailView)
            Dim noOfUnits = GetUnitCount(item, InvTransactionDetail)
            InvTransactionDetail.UnitCount = noOfUnits
            If noOfUnits = 1 OrElse InvTransactionDetail.UnitIdNo = 0 Then
                InvTransactionDetail.UnitIdNo = item.BaseUnitIdNo
            Else
                Dim nCount As Int16 = Service.CountRecordWith2Key(Of Int32, Int16)("ProductUnit", "ProductIdNo", "UnitIdNo", item.IdNo, InvTransactionDetail.UnitIdNo)
                If nCount = 0 Then
                    InvTransactionDetail.UnitIdNo = item.BaseUnitIdNo
                Else
                    InvTransactionDetail.UnitIdNo = 0
                End If
            End If
        End Sub

        Private Function GetUnitCount(item As ProductModel, InvTransactionDetail As InvTransactionDetailView) As Int32
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

        Private Sub OnInvTransactionTypeChanged(invTransType As Int16)
            View.InventoryAction = Service.GetField(View.InvTransTypeIdNo, "InvTransType", "IdNo", "InventoryAction")
            If View.InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                View.WarehouseToIdNoEnabled = True
            Else
                View.WarehouseToIdNoEnabled = False
            End If
        End Sub

        Private Function OnPostData(idNo As Int32) As Boolean
            Dim retVal As Boolean = Service.PostData(idNo)
            If retVal Then
                View.Posted = True
            End If
            Return retVal
        End Function

        Public Sub OnInvTransactionDgvItemsValidatingEventHandler(ByRef eventType As DgvItemsValidating) Implements ISubscriber(Of DgvItemsValidating).OnEventHandler
            Dim InvTransactionDetail As InvTransactionDetailView = eventType.BindingSource.Current
            Dim bs As BindingSource = eventType.BindingSource
            With bs.Current
                Select Case eventType.PropertyName
                    Case $"ProductCode"
                        Dim retVal As Boolean = False
                        Dim productCode As String = eventType.EnteredValue
                        Dim product As ProductModel = GetProductModel(eventType.EnteredValue)
                        If product IsNot Nothing Then
                            If productCode <> bs.Current.ProductCode Then
                                Dim inventory As New List(Of InventoryModel)
                                inventory = Service.GetRecordsWithGroupIdNo(Of InventoryModel)(product.IdNo, "ExpiryDate")
                                bs.Current.ProductIdNo = product.IdNo
                                bs.Current.ProductName = product.ProductName
                                bs.Current.UnitIdNo = product.BaseUnitIdNo
                                If inventory.Count() = 1 Then
                                    With bs.Current
                                        If .Quantity = 0 Then
                                            .Quantity = inventory(0).QtyOnHand
                                        End If
                                        .ProductCode = product.ProductCode
                                        .BatchNo = inventory(0).BatchNo
                                        .ExpiryDate = inventory(0).ExpiryDate
                                        .InventoryIdNo = inventory(0).IdNo
                                        .UnitCost = inventory(0).UnitCost
                                        .NetAmount = inventory(0).UnitCost * inventory(0).QtyOnHand
                                    End With
                                    retVal = True
                                Else
                                    If View.InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Then
                                        Messaging.Show(True, "MsgNoSuchInventory", "Error")
                                    End If
                                    If View.InvTransTypeIdNo Then
                                    End If
                                    View.ProductInventory = inventory
                                End If
                            End If
                        Else
                            bs.Current.ProductIdNo = ""
                            bs.Current.ProductName = ""
                            Messaging.Show(True, "Invalid Product Code!")
                        End If
                    Case Else
                        ' nothing to do
                End Select
            End With
        End Sub

    End Class

End Namespace