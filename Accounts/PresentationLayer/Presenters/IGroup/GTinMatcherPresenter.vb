Imports System.Dynamic
Imports System.Net.Http.Headers
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class GTinMatcherPresenter(Of TM As New)
        Inherits CommonPresenter(Of IGTinMatcherView, TM)

        Private _drugList As Object

        Public Sub New(itemView As IGTinMatcherView)
            MyBase.New(itemView)
            Service = New AccountsService("ItemDetails")
            TableName = "ItemDetailsQty_View"
            SortOrderKey = "ItemNameEnglish"
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged
            'AddHandler View.GetDrugDataTable, AddressOf OnGetDrugDataTable
            'AddHandler View.GetItemDataTable, AddressOf OnGetItemDataTable
            AddHandler View.UpdateDrugDisplay, AddressOf OnUpdateDrugDisplay
            AddHandler View.UpdateItemDisplay, AddressOf OnUpdateItemDisplay
            AddHandler View.GTinValueChanged, AddressOf OnGTinValueChanged
            AddHandler View.MatchGTinRequested, AddressOf OnMatchGTinRequested
        End Sub

        Private Sub OnMatchGTinRequested(gTinNumber As String, itemDetailIdNo As Integer)
            Service.UpdateRecordWithIdNo(Of String)(View.IdNo, "ItemDetails", "GTIN", View.DrugGTin)
            UpdateViewDisplay()
        End Sub

        Private Sub OnGTinValueChanged(sender As DataGridView, gTinValue As String)
            If gTinValue Is DBNull.Value Or gTinValue Is Nothing Or gTinValue = "" Then
                ClearDrugDisplay()
                ClearItemDrugDisplay()
            Else
                Dim drugIdNo As Integer = GetDrugIdNo(gTinValue)
                Dim drug As Object = MakeDrug(drugIdNo)
                DisplayDrug(drug)
            End If
        End Sub

        Private Function GetDrugIdNo(ByRef gTinValue As String) As Int32
            Return Service.GetField(Of Int32, String)(gTinValue, "DrugList", "GTin", "IdNo")
        End Function

        Private Sub OnUpdateDrugDisplay(itemDetailIdNo As Integer)
            Dim drug As Object = MakeDrug(itemDetailIdNo)
            DisplayDrug(drug)
            'Dim itemDao = New ItemDetailsDao()
            'View.QtyOnHand = itemDao.GetQtyOnHandBox(View.ItemDetailsCode)
        End Sub

        Private Sub OnUpdateItemDisplay(idNo As Integer)
            RecordPositionNumber = GetSortedRecordPosition(idNo)
            'Dim itemDao = New ItemDetailsDao()
            'View.QtyOnHand = itemDao.GetQtyOnHandBox(View.ItemDetailsCode)
        End Sub

        Private Function MakeDrug(drugIdNo As Integer) As Object
            Return Service.GetFieldsWithIdNo(drugIdNo, "DrugList", "IdNo,GTin,[Trade Name],[Dosage Form],[Generic Name],[Package Size],[Package Type],[Public Price],[RegistrationNo],[Route Of Administration],[Strength Value],[Unit Of Strength],[Unit Of Volume],Volume", "IdNo")
        End Function

        Protected Overrides Sub CreateDataSources()
            'View.DrugList = Service.GetRecords("DrugList", "[Trade Name]")
            CreateDataSource("DrugDosageForm_View", "DosageForm", {"DosageForm"}, "DosageForm")
            CreateDataSource("DrugUnitOfVolume_View", "UnitOfVolume", {"UnitOfVolume"}, "UnitOfVolume")
            CreateDataSource("DrugUnitOfStrength_View", "UnitOfStrength", {"UnitOfStrength"}, "UnitOfStrength")
            CreateDataSource("DrugPackageType_View", "PackageType", {"PackageType"}, "PackageType")
            CreateDataSource("DrugRouteOfAdministration_View", "RouteOfAdministration", {"RouteOfAdministration"}, "RouteOfAdministration")
            'CreateLookupDataTable("ItemDetails", "ItemDetailsByName", {"ItemNameEnglish", "Primary_Key"}, "BranchId='01' and ItemGroup='MD'")
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "ItemGroup = 'MD' and QtyOnHand <> 0 and BranchId = '01'"
            Else
                DataFilter = ""
            End If
            'DisplayTree()
            GoFirstRecord()
        End Sub

        Private Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

        'Private Sub OnGTinMatcherValueChanged(sender As DataGridView, gTin As String)
        '    If gTin IsNot Nothing Or gTin <> "" Then
        '        Dim gTinIdNo As Integer = GetGTinIdNo(gTin)
        '        Dim drug As Object = MakeDrug(gTinIdNo)
        '        If drug Is Nothing Then
        '            ClearItemDrugDisplay()
        '            ClearDrugDisplay()
        '        Else
        '            DisplayDrug(drug)
        '            View.DosageForm = NoDbNull(drug.DosageForm)
        '            View.GenericName = NoDbNull(drug.GenericName)
        '            View.PackageSize = NoDbNull(drug.PackageSize)
        '            View.PackageType = NoDbNull(drug.PackageType)
        '            View.RegistrationNo = NoDbNull(drug.RegistrationNo)
        '            View.RouteOfAdministration = NoDbNull(drug.RouteOfAdministration)
        '            View.StrengthValue = NoDbNull(drug.StrengthValue)
        '            View.UnitOfStrength = NoDbNull(drug.UnitOfStrength)
        '            View.UnitOfVolume = NoDbNull(drug.UnitOfVolume)
        '            View.Volume = NoDbNull(drug.Volume)
        '            Dim searchValue = View.GTIN
        '            Dim row = Enumerable.Where(Of DataGridViewRow)(sender.Rows.Cast(Of DataGridViewRow)(), Function(x) Not x.IsNewRow).FirstOrDefault(Function(x) CType(x.DataBoundItem, DataRowView)("GTin").ToString().Equals(searchValue))
        '            sender.CurrentCell = row.Cells(0)
        '        End If
        '    Else
        '        ClearItemDrugDisplay()
        '        ClearDrugDisplay()
        '    End If
        'End Sub

        Private Sub ClearItemDrugDisplay()
            View.DosageForm = Nothing
            View.GenericName = Nothing
            View.PackageSize = Nothing
            View.PackageType = Nothing
            View.RegistrationNo = Nothing
            View.RouteOfAdministration = Nothing
            View.StrengthValue = Nothing
            View.UnitOfStrength = Nothing
            View.UnitOfVolume = Nothing
            View.Volume = Nothing
        End Sub

        Private Sub DisplayDrug(drug As Object)
            If drug Is Nothing Then
                ClearDrugDisplay()
            Else
                View.DrugIdNo = NoDbNull(drug.IdNo)
                View.DrugGTin = NoDbNull(drug.GTin)
                View.DrugTradeName = NoDbNull(drug.TradeName)
                View.DrugGenericName = NoDbNull(drug.GenericName)
                View.DrugDosageForm = NoDbNull(drug.DosageForm)
                View.DrugGenericName = NoDbNull(drug.GenericName)
                View.DrugPackageSize = NoDbNull(drug.PackageSize)
                View.DrugPackageType = NoDbNull(drug.PackageType)
                View.DrugRegistrationNo = NoDbNull(drug.RegistrationNo)
                View.DrugRouteOfAdministration = NoDbNull(drug.RouteOfAdministration)
                View.DrugStrengthValue = NoDbNull(drug.StrengthValue)
                View.DrugUnitOfStrength = NoDbNull(drug.UnitOfStrength)
                View.DrugUnitOfVolume = NoDbNull(drug.UnitOfVolume)
                View.DrugVolume = NoDbNull(drug.Volume)
                View.DrugPublicPrice = NoDbNull(drug.PublicPrice)
            End If
        End Sub

        Private Sub ClearDrugDisplay()
            View.DrugIdNo = Nothing
            View.DrugTradeName = Nothing
            View.DrugGenericName = Nothing
            View.DrugDosageForm = Nothing
            View.DrugRegistrationNo = Nothing
            View.DrugPackageType = Nothing
            View.DrugPackageSize = Nothing
            View.DrugRouteOfAdministration = Nothing
            View.DrugStrengthValue = Nothing
            View.DrugUnitOfStrength = Nothing
            View.DrugUnitOfVolume = Nothing
            View.DrugVolume = Nothing
            View.DrugGTin = Nothing
            View.DrugPublicPrice = Nothing
        End Sub

        'Private Sub OnGetDrugDataTable(ByRef drugListDataTable As DataTable)
        '    drugListDataTable = Service.GetDataTable("DrugList", "[Trade Name]", "IdNo,GTin,[Trade Name],[Public Price],[Strength Value],[Unit of Strength],[Dosage Form],[Volume],[Unit of Volume],[Package Type],[Package Size]")
        'End Sub

        'Private Sub OnGetItemDataTable(ByRef itemDetailsDataTable As DataTable)
        '    itemDetailsDataTable = Service.GetDataTable("ItemDetailsQty_View", "ItemNameEnglish", "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3,QtyOnHand", "BranchId='01' and ItemGroup='MD'")
        'End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
                View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
            End If
        End Sub

        Public Sub OnAfterSaveItemDetails() Handles Me.AfterSave
            If Service.RecordCount("StockPositionCurrent", "Item_Code", View.ItemDetailsCode, "BranchId = '02'") = 0 Then
                Service.InsertRecord("StockPositionCurrent", {"BranchID", "Item_Code", "Batch", "Expiry", "WarehouseID", "PCSQty", "CashPrice", "CreditPrice", "CostPrice", "PurchaseNo", "TmpStock"},
                                                        {"String", "String", "String", "DateTime", "String", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal"},
                                                        {"01", View.ItemDetailsCode, "000", Now(), "01", 0, 0, 0, 0, 0, 0})
            End If
        End Sub

        Public Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            If View.GTIN IsNot Nothing Or View.GTIN <> "" Then
                Dim drugIdNo As Int32 = Service.GetField(Of Int32, String)(View.GTIN, "DrugList", "GTin", "IdNo")
                Dim drug As Object = MakeDrug(drugIdNo)
                DisplayDrug(drug)
            End If
        End Sub

    End Class

End Namespace