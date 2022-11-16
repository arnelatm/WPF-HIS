Imports System.Dynamic
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
            TableName = "ItemDetails"
            SortOrderKey = "ItemNameEnglish"
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged
            AddHandler View.GTinValueChanged, AddressOf OnGTinValueChanged
        End Sub

        Protected Overrides Sub CreateDataSources()
            View.DrugList = Service.GetRecords("DrugList", "[Trade Name]")
            CreateDataSource("DrugDosageForm_View", "DosageForm", {"DosageForm"}, "DosageForm")
            CreateDataSource("DrugUnitOfVolume_View", "UnitOfVolume", {"UnitOfVolume"}, "UnitOfVolume")
            CreateDataSource("DrugUnitOfStrength_View", "UnitOfStrength", {"UnitOfStrength"}, "UnitOfStrength")
            CreateDataSource("DrugPackageType_View", "PackageType", {"PackageType"}, "PackageType")
            CreateDataSource("DrugRouteOfAdministration_View", "RouteOfAdministration", {"RouteOfAdministration"}, "RouteOfAdministration")
            CreateLookupData("ItemDetails", "ItemDetailsByName", {"Primary_Key", "ItemNameEnglish", "Item_Code"}, "BranchId='01'")
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "Active = 1 and ItemGroup = 'MD'"
            Else
                DataFilter = ""
            End If
            DisplayTree()
            GoFirstRecord()
        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

        Public Sub OnGTinValueChanged(idNo As Int16)
            If idNo <> 0 Then
                If View.GTIN IsNot Nothing Then
                    Dim gTinIdNo As Integer = Service.GetField("GTin", "DrugList")
                    Dim obj As Object = Service.GetFieldsWithIdNo(idNo, {"DosageForm", "GenericName", "PackageSize", "PackageType", "RegistrationNo", "RouteOfAdministration", "StrengthValue", "UnitOfStrength", "UnitOfVolume", "Volume"})
                    View.DosageForm = obj.DosageForm
                    View.GenericName = obj.GenericName
                    View.PackageSize = obj.PackageSize
                    View.PackageType = obj.PackageType
                    View.RegistrationNo = obj.RegistrationNo
                    View.RouteOfAdministration = obj.RouteOfAdministration
                    View.StrengthValue = obj.StrengthValue
                    View.UnitOfStrength = obj.UnitOfStrength
                    View.UnitOfVolume = obj.UnitOfVolume
                    View.Volume = obj.Volume
                End If
            End If
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
                View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
            End If
        End Sub

        Public Sub OnAfterSaveItemDetails() Handles Me.AfterSave
            Service.InsertRecord("StockPositionCurrent", {"BranchID", "Item_Code", "Batch", "Expiry", "WarehouseID", "PCSQty", "CashPrice", "CreditPrice", "CostPrice", "PurchaseNo", "TmpStock"},
                                                        {"String", "String", "String", "DateTime", "String", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal"},
                                                        {"01", View.ItemDetailsCode, "000", Now(), "01", 0, 0, 0, 0, 0, 0})
        End Sub

        Public Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            If View.GTIN IsNot Nothing Or View.GTIN <> "" Then
                Dim idNo As Int32 = Service.GetIdNoWithName(Of Int32)("DrugList", View.GTIN, "GTin")
                Dim drug As Object = Service.GetFieldsWithIdNo(idNo, "DrugList", "[IdNo],[Trade Name],[Generic Name],[GTIN],[Dosage Form],[Package Size],[Package Type],RegistrationNo,[Route Of Administration],[Strength Value],[Unit Of Strength],[Volume],[Unit Of Volume]", "IdNo")
                If drug IsNot Nothing Then
                    View.DrugIdNo = NoDbNull(drug.IdNo)
                    View.DrugTradeName = NoDbNull(drug.TradeName)
                    View.DrugGenericName = NoDbNull(drug.GenericName)
                    View.DrugDosageForm = NoDbNull(drug.DosageForm)
                    View.DrugRegistrationNo = NoDbNull(drug.RegistrationNo)
                    View.DrugPackageType = NoDbNull(drug.PackageType)
                    View.DrugPackageSize = NoDbNull(drug.PackageSize)
                    View.DrugRouteOfAdministration = NoDbNull(drug.RouteOfAdministration)
                    View.DrugStrengthValue = NoDbNull(drug.StrengthValue)
                    View.DrugUnitOfStrength = NoDbNull(drug.UnitOfStrength)
                    View.DrugUnitOfVolume = NoDbNull(drug.UnitOfVolume)
                    View.DrugVolume = NoDbNull(drug.Volume)
                    View.DrugGTin = NoDbNull(drug.GTin)
                Else
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
                End If
            End If
        End Sub

    End Class

End Namespace