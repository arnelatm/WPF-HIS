Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class SalePresenter(Of TM As New)
        Inherits TransactionsPresenter(Of ISaleView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _igService As Object
        Private ReadOnly _productService As New AccountsService("Product")

        Public Sub New(view As ISaleView)
            MyBase.New(view)
            DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()
            TableName = "Sale"
            WithTreeView = False
            Service = New AccountsService("Sale")
            _igService = New AccountsService("DrugSale")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("BatchNo", GetType(String))
            DtInsertTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("ExpiryDate", GetType(Date))
            DtInsertTable.Columns.Add("NetAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("Price", GetType(Decimal))
            DtInsertTable.Columns.Add("ProductIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("SaleIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Quantity", GetType(Decimal))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("UnitIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("VatAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("VatPercent", GetType(Decimal))

            DtUpdateTable.Columns.Add("BatchNo", GetType(String))
            DtUpdateTable.Columns.Add("DiscountAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("ExpiryDate", GetType(Date))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("NetAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("Price", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProductIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("SaleIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Quantity", GetType(Decimal))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("UnitIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("VatAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("VatPercent", GetType(Decimal))
            AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
            AddHandler view.GTinScanned, AddressOf OnGTinScanned
            AddHandler view.ProductUnitSelection, AddressOf OnProductUnitSelection
            AddHandler view.UnitChanged, AddressOf OnUnitChanged

        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Customer", "CustomerIdNo", Nothing, Nothing},
                                    New Object() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"},
                                    New Object() {"User", "UserIdNo", "IdNo,UserName", Nothing},
                                    New Object() {"Country", "NationalityCode", "IdNo,CountryName,CountryCode", Nothing}})
            MakeVarDataSources({New Object() {"Unit", "UnitsByCode", Nothing, Nothing},
                                New Object() {"Product", "ProductsByCode", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "ProductName"}})
            CreateEnumDataSource(Of MaleFemaleSelection)("Gender")
            CreateEnumDataSource(Of YearMonthDaySelection)("AgeYmd")
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.SaleDetails, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf SaleDetailFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("BatchNo") = itemDataView.BatchNo
            workRow("DiscountAmount") = itemDataView.DiscountAmount
            workRow("ExpiryDate") = IIf(itemDataView.ExpiryDate Is Nothing, DBNull.Value, itemDataView.ExpiryDate)
            workRow("NetAmount") = itemDataView.NetAmount
            workRow("Price") = itemDataView.Price
            workRow("ProductIdNo") = itemDataView.ProductIdNo
            workRow("SaleIdNo") = View.IdNo
            workRow("Quantity") = itemDataView.Quantity
            workRow("UnitIdNo") = itemDataView.UnitIdNo
            workRow("VatAmount") = itemDataView.VatAmount
            workRow("VatPercent") = itemDataView.VatPercent
        End Sub

        Public Function SaleDetailFilter(ByVal obj As Object) As Boolean
            If (obj.ProductIdNo Is Nothing Or obj.ProductIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private ReadOnly _SaleItemService As New AccountsService("SaleDetail")

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_SaleItemService, DtUpdateTable, DtInsertTable, passedValue, "SaleIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsBizDataValid Then
                For Each item In View.SaleDetails
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
            'Dim cForm As New ReportForm("Accounts Payable Journal.Rpt", View.IdNo, "SaleIdNo", transactionAmount, "ApAmountInWords", totalApAmount, "TotalLineAmountInWords", language, "Language")
            'cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.SaleDetails IsNot Nothing And View.SaleDetails.Count() > 0 Then
                DtUpdateTable.Clear()
                '_SaleItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub UpdateDueDate()
            If View.CustomerIdNo IsNot Nothing Then
                Dim customerPaymentDueDays = GetCustomerPaymentDueDays(View.CustomerIdNo)
                View.DueDate = DateAdd("d", customerPaymentDueDays, View.TransactionDate)
            Else
                View.DueDate = Nothing
            End If
        End Sub
        Public Function GetCustomerPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "PaymentDueDays")
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
        '                                                       "SaleDetailIdNo", "IdNo")
        '    If Service.CountRecordWithKey(Of Integer)("CdOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("CkOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    ElseIf Service.CountRecordWithKey(Of Integer)("PcOiItem", "ApOpenInvoiceIdNo", apOpenInvoiceIdNo) > 0 Then
        '        Return True
        '    End If
        '    Return False
        'End Function

        Public Sub OnSaledgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            Dim SaleDetail As SaleDetailView = eventType.BindingSource.Current
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
                        Case $"Quantity", $"Price", $"VatPercent", $"DiscountPercent"
                            SetAmounts(SaleDetail)
                            eventType.BindingSource.ResetCurrentItem()
                        Case "GrossAmount"
                            gAmt = .GrossAmount
                            With SaleDetail
                                .Price = RecomputePrice(SaleDetail)
                                .DiscountAmount = GetDiscountAmount(SaleDetail)
                                .AmtBefVat = GetAmountBeforeVat(SaleDetail)
                                .VatAmount = GetVatAmount(SaleDetail)
                                .NetAmount = GetNetAmount(SaleDetail)
                            End With
                        Case "DiscountAmount"
                            dPerc = RecomputeDiscountPercentage(SaleDetail)
                            With SaleDetail
                                .DiscountPercent = dPerc
                                .AmtBefVat = GetAmountBeforeVat(SaleDetail)
                                .VatAmount = GetVatAmount(SaleDetail)
                                .NetAmount = GetNetAmount(SaleDetail)
                            End With
                        Case "VatAmount"
                            vPerc = RecomputeVatPercentage(SaleDetail)
                            With SaleDetail
                                .VatPercent = vPerc
                                .NetAmount = GetNetAmount(SaleDetail)
                            End With
                        Case "AmtBefVat"
                            gAmt = .GrossAmount
                            If .AmtBefVat <= .GrossAmount Then
                                .DiscountAmount = .GrossAmount - .AmtBefVat
                                .DiscountPercent = If(.GrossAmount = 0, 0D, .DiscountAmount / .GrossAmount * 100D)
                                .VatAmount = .AmtBefVat * .VatPercent / 100
                                .NetAmount = GetNetAmount(SaleDetail)
                            Else
                                .GrossAmount = .AmtBefVat - .DiscountAmount
                                .Price = If(.Quantity = 0, 0D, .GrossAmount / .Quantity)
                                .DiscountPercent = If(.GrossAmount = 0, 0D, .DiscountAmount / .GrossAmount * 100D)
                                .VatAmount = GetVatAmount(SaleDetail)
                                .NetAmount = GetNetAmount(SaleDetail)
                            End If
                        Case "NetAmount"
                            .AmtBefVat = .NetAmount / (1 + .VatPercent / 100)
                            .VatAmount = .NetAmount - .AmtBefVat
                            .GrossAmount = .AmtBefVat / (1 - .DiscountPercent / 100)
                            .DiscountAmount = .GrossAmount - .AmtBefVat
                            .Price = If(.Quantity = 0, 0D, .GrossAmount / .Quantity)
                    End Select
                    .UnitCost = GetUnitCost(SaleDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

        Private Sub InitializeSaleDetailValues(ByRef SaleDetail As SaleDetailView, productCode As String)
            Dim product As ProductModel = GetProductModel(productCode)
            If product IsNot Nothing Then
                If productCode <> SaleDetail.ProductCode Then
                    With SaleDetail
                        SaleDetail.ProductIdNo = product.IdNo
                        SaleDetail.ProductName = product.ProductName
                        If SaleDetail.Quantity = 0 Then
                            SaleDetail.Quantity = 1
                        End If
                        SetSaleDetailValues(product, SaleDetail)
                        SaleDetail.ProductCode = product.ProductCode
                    End With
                End If
            Else
                SaleDetail.ProductIdNo = ""
                SaleDetail.ProductName = ""
                Messaging.Show(True, "Invalid Product Code!")
            End If
        End Sub

        Private Sub SetSaleDetailValues(pModel As ProductModel, SaleDetail As SaleDetailView)
            Dim lastSaleInfo As Object = New ExpandoObject
            lastSaleInfo = GetLastSaleInfo(pModel)
            With SaleDetail
                If lastSaleInfo Is Nothing Then
                    SetDefaultUnit(pModel, SaleDetail)
                Else
                    .Price = lastSaleInfo.Price
                    .UnitIdNo = lastSaleInfo.UnitIdNo
                    .UnitCount = GetUnitCount(pModel, SaleDetail)
                End If
                .VatPercent = GetVatPercentage(pModel.CategoryIdNo)
                SetAmounts(SaleDetail)
                .ProductIdNo = pModel.IdNo
                .NeedsExpiryDate = GetNeedsExpiryDate(pModel.CategoryIdNo)
            End With
        End Sub

        Private Sub SetAmounts(SaleDetail As SaleDetailView)
            With SaleDetail
                .GrossAmount = GetGrossAmount(SaleDetail)
                .DiscountAmount = GetDiscountAmount(SaleDetail)
                .AmtBefVat = GetAmountBeforeVat(SaleDetail)
                .VatAmount = GetVatAmount(SaleDetail)
                .NetAmount = GetNetAmount(SaleDetail)
                .UnitCost = GetUnitCost(SaleDetail)
            End With
        End Sub
        Private Function GetGrossAmount(SaleDetail As SaleDetailView) As Decimal
            Return SaleDetail.Price * SaleDetail.Quantity
        End Function

        Private Function GetDiscountAmount(SaleDetail As SaleDetailView) As Decimal
            Return SaleDetail.GrossAmount * SaleDetail.DiscountPercent / 100
        End Function

        Private Function GetAmountBeforeVat(SaleDetail As SaleDetailView) As Decimal
            Return SaleDetail.GrossAmount - SaleDetail.DiscountAmount
        End Function

        Private Function GetVatAmount(SaleDetail As SaleDetailView) As Decimal
            Return (SaleDetail.GrossAmount - SaleDetail.DiscountAmount) * SaleDetail.VatPercent / 100
        End Function

        Private Function GetNetAmount(SaleDetail As SaleDetailView) As Decimal
            Return SaleDetail.GrossAmount - SaleDetail.DiscountAmount + SaleDetail.VatAmount
        End Function

        Private Function GetUnitCost(SaleDetail As SaleDetailView) As Decimal
            Return If(SaleDetail.Quantity = 0, 0D, SaleDetail.NetAmount / SaleDetail.Quantity)
        End Function

        Private Function RecomputeDiscountPercentage(SaleDetail As SaleDetailView) As Decimal
            Return Math.Round(If(SaleDetail.GrossAmount = 0, 0D, SaleDetail.DiscountAmount / SaleDetail.GrossAmount * 100D), 2)
        End Function

        Private Function RecomputePrice(SaleDetail As SaleDetailView) As Decimal
            Return Math.Round(If(SaleDetail.Quantity = 0, 0D, SaleDetail.GrossAmount / SaleDetail.Quantity), 2)
        End Function

        Private Function RecomputeVatPercentage(SaleDetail As SaleDetailView) As Decimal
            Return If(SaleDetail.GrossAmount - SaleDetail.DiscountAmount = 0, 0D, SaleDetail.VatAmount / (SaleDetail.GrossAmount - SaleDetail.DiscountAmount) * 100D)
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
            'If ReconciledEntriesExist(View.SaleDetails, "AP") Then
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
                'If ReconciledEntriesExist(View.SaleDetails, "AP") Then
                '    retValue = False
                'End If
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'For Each item In View.SaleDetails
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
            Dim SaleDetail As SaleDetailView = bs.Current
            InitializeSaleDetailValues(SaleDetail, productCode)
            bs.EndEdit()
        End Sub

        Private Function GetProductModel(productCode As Int32) As ProductModel
            Dim productIdNo As Int32 = GetProductIdNo(productCode)
            Return _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
        End Function

        Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "Product", "GTin", "IdNo")
            Dim SaleDetail As SaleDetailView = bs.Current
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(idNo)
            productCode = productModel.ProductCode
            OnProductCodeChanged(productCode, bs)
        End Sub

        Private Sub OnProductUnitSelection(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub OnUnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String)
            RecomputePrice(oldUnit, newUnit, bs)
        End Sub

        Private Sub RecomputePrice(oldUnit As Int16, newUnit As Int16, bs As BindingSource)
            Dim SaleDetail As SaleDetailView = bs.Current
            Dim newPrice As Decimal
            Dim productIdNo As Int32 = bs.Current.ProductIdNo
            Dim productModel As ProductModel = _productService.GetRecordByIdNo(Of ProductModel)(productIdNo)
            If oldUnit <> newUnit Then
                Dim unitQty, baseQty As Int16
                Dim basePrice As Decimal
                If productModel.BaseUnitIdNo = oldUnit Then
                    basePrice = SaleDetail.Price
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, oldUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    basePrice = Math.Ceiling(If(baseQty = 0, 0D, unitQty / baseQty) * SaleDetail.Price * 100D) / 100D
                End If
                If newUnit = productModel.BaseUnitIdNo Then
                    newPrice = basePrice
                Else
                    unitQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "UnitQty")
                    baseQty = Service.GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(productIdNo, newUnit, "ProductUnit", "ProductIdNo", "UnitIdNo", "BaseQty")
                    newPrice = Math.Ceiling(If(unitQty = 0, 0D, basePrice * baseQty / unitQty) * 100D) / 100D
                End If
                SaleDetail.Price = newPrice
                SetAmounts(SaleDetail)
            End If
        End Sub

        Private Sub OnProductUnitEditing(productIdNo As Int32, bs As BindingSource)
            SetProductUnits(productIdNo)
        End Sub

        Private Sub SetProductUnits(productIdNo As Int16)
            Dim data As New ArrayList
            data.Add({"ProductUnit_View", "UnitsByProduct", "IdNo,UnitName,UnitCode", "ProductIdNo = " + productIdNo.ToString()})
            CreateVarDataSources(data)
        End Sub

        Private Function GetLastSaleInfo(pModel As ProductModel) As ExpandoObject
            Return Service.GetTopOneFields("SaleDetail", "Price,UnitIdNo", "ProductIdNo = " & pModel.IdNo.ToString(), "IdNo", False)
        End Function

        Private Function GetSalesPrice(item As ProductModel) As Decimal
            Dim price As Decimal

            price = Service.GetField(Of Decimal, Int32)(item.IdNo, "Product", "IdNo", "Price_Cash")
            Return price
        End Function

        Private Sub SetDefaultUnit(item As ProductModel, SaleDetail As SaleDetailView)
            Dim noOfUnits = GetUnitCount(item, SaleDetail)
            SaleDetail.UnitCount = noOfUnits
            If noOfUnits = 1 OrElse SaleDetail.UnitIdNo = 0 Then
                SaleDetail.UnitIdNo = item.BaseUnitIdNo
            Else
                Dim nCount As Int16 = Service.CountRecordWith2Key(Of Int32, Int16)("ProductUnit", "ProductIdNo", "UnitIdNo", item.IdNo, SaleDetail.UnitIdNo)
                If nCount = 0 Then
                    SaleDetail.UnitIdNo = item.BaseUnitIdNo
                Else
                    SaleDetail.UnitIdNo = 0
                End If
            End If
        End Sub

        Private Function GetUnitCount(item As ProductModel, SaleDetail As SaleDetailView) As Int32
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
            If View.SaleDetails IsNot Nothing Then
                View.SaleDetails.Clear()
            Else
                View.SaleDetails = New List(Of SaleDetailView)
            End If
            View.UserIdNo = GlobalVariables.UserIdNo
            Dim wareHouse = Service.GetTopOneFields("Warehouse", "IdNo", "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString(), "IdNo", True)
            View.WarehouseIdNo = wareHouse.IdNo
        End Sub

        Private Sub OnFindPatient()
            Dim patientType As String = Service.GetRecordFieldWithKeyG(Of String, Int32)(View.PatientType, "ItemCode", "IdNo", "ItemCodeName")
            Dim filter As String = "RegistrationNo = " + View.FileNo.ToString() + " and PatientType = '" & patientType & "'"
            Dim patient As Object = New ExpandoObject
            patient = _igService.GetRecordFieldsFiltered("PatientDetails", "PatientNameEnglish,Age,AgeYMD,Sex", filter)
            If patient Is Nothing Then
                MessageBox.Show("No Such Patient with that File number and type found on file.")
            Else
                View.PatientName = patient.PatientNameEnglish
                View.Age = patient.Age
                View.AgeDmy = patient.AgeYmd
                View.Gender = patient.Sex
            End If
        End Sub

    End Class

End Namespace
