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
Imports Telerik.Licensing

Namespace PresentationLayer.Presenters

    Public Class InvTransactionPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IInvTransactionView, TM)
        Implements ISubscriber(Of DgvItemsChanged), ISubscriber(Of DgvItemsValidating)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
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
            DtUpdateTable.Columns.Add("InvTransactionIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Quantity", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitCost", GetType(Decimal))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            AddHandler view.GTinScanned, AddressOf OnGTinScanned
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            AddHandler view.UnitChanged, AddressOf OnUnitChanged
            AddHandler view.InvTransactionTypeChanged, AddressOf OnInvTransactionTypeChanged
            AddHandler view.PostData, AddressOf OnPostData
            AddHandler view.ProductCodeValidating, AddressOf OnProductCodeValidating

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

        'Public Function ApPaymentExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Dim apOpenInvoiceIdNo As Integer
        '    apOpenInvoiceIdNo = Service.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
        '                                                       "InvTransactionDetailIdNo", "IdNo")
        '    If Service.CountRecordWithKey(Of Integer)("CdOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("CkOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("PcOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    End If
        '    Return False
        'End Function

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
                    End Select
                    .NetAmount = GetNetAmount(InvTransactionDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

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
                If productCode <> View.InvTransactionDetailsBs.Current.ProductCode Then
                    Dim inventory As New List(Of InventoryModel)
                    inventory = Service.GetRecordsWithGroupIdNo(Of InventoryModel)(product.IdNo, "ExpiryDate")
                    View.InvTransactionDetailsBs.Current.ProductIdNo = product.IdNo
                    View.InvTransactionDetailsBs.Current.ProductName = product.ProductName
                    View.InvTransactionDetailsBs.Current.UnitIdNo = product.BaseUnitIdNo
                    If inventory.Count() = 1 Then
                        With View.InvTransactionDetailsBs.Current
                            .Quantity = SetInitialQuantity(inventory(0))
                            .ProductCode = product.ProductCode
                            .BatchNo = inventory(0).BatchNo
                            .ExpiryDate = inventory(0).ExpiryDate
                            .UnitCost = inventory(0).UnitCost
                            .NetAmount = inventory(0).UnitCost * inventory(0).QtyOnHand
                        End With
                        View.ProductInventory = inventory
                        View.ProductCodeIsValid = True
                    ElseIf inventory.Count() > 1 Then
                        Dim form As New InventorySelector(inventory, control)
                        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            Dim selectedInvIndex As Int32 = form.SelectedInvIndex
                            With View.InvTransactionDetailsBs.Current
                                .BatchNo = inventory(selectedInvIndex).BatchNo
                                .Quantity = SetInitialQuantity(inventory(0))
                                .ExpiryDate = inventory(selectedInvIndex).ExpiryDate
                                .UnitCost = inventory(selectedInvIndex).UnitCost
                                .NetAmount = Math.Round(.UnitCost * .Quantity, 2)
                            End With
                            View.ProductInventory = inventory
                            View.ProductCodeIsValid = True
                        Else
                            View.ProductCodeIsValid = False
                        End If
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
                Else
                    View.ProductCodeIsValid = False
                    Messaging.Show(True, "Invalid Product Code!")
                End If
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

        Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim InvTransactionDetail As InvTransactionDetailView = bs.Current
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

        Private Sub RecomputePrice(oldUnit As Int16, newUnit As Int16, bs As BindingSource)
            Dim InvTransactionDetail As InvTransactionDetailView = bs.Current
            Dim newPrice As Decimal
            Dim productIdNo As Int32 = bs.Current.ProductIdNo
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            If oldUnit <> newUnit Then
                Dim unitQty, baseQty As Int16
                Dim basePrice As Decimal
                If productModel.BaseUnitIdNo = oldUnit Then
                    'basePrice = InvTransactionDetail.Price
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    'basePrice = Math.Ceiling(IIf(baseQty = 0, 0, unitQty / baseQty) * InvTransactionDetail.Price * 100D) / 100D
                End If
                If newUnit = productModel.BaseUnitIdNo Then
                    newPrice = basePrice
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    newPrice = Math.Ceiling(IIf(baseQty = 0, 0, basePrice * baseQty / unitQty) * 100D) / 100D
                End If
                'InvTransactionDetail.Price = newPrice
                SetAmounts(InvTransactionDetail)
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