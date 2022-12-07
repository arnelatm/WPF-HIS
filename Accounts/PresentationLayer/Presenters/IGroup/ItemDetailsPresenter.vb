Imports System.Dynamic
Imports System.Threading
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ItemDetailsPresenter(Of TM As New)
        Inherits CommonPresenter(Of IItemDetailsView, TM)
        'Implements IDaoAutoCode2

        Public Sub New(itemView As IItemDetailsView)
            MyBase.New(itemView)
            Service = New AccountsService("ItemDetails") ', Nothing ,Nothing, "IGROUPCLINIC")
            'Service.SaveConnectionString()
            'Service.SetConnectionString("IGROUPCLINIC")
            TableName = "ItemDetails"
            SortOrderKey = "ItemNameEnglish"
            'Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.FinderValueChanged, AddressOf OnFinderValueChanged
            AddHandler View.GTinValueChanged, AddressOf OnGTinValueChanged
        End Sub

        Protected Overrides Sub CreateDataSources()

            CreateDataSource("DrugDosageForm_View", "DosageForm", {"DosageForm"}, "DosageForm")
            CreateDataSource("DrugUnitOfVolume_View", "UnitOfVolume", {"UnitOfVolume"}, "UnitOfVolume")
            CreateDataSource("DrugUnitOfStrength_View", "UnitOfStrength", {"UnitOfStrength"}, "UnitOfStrength")
            CreateDataSource("DrugPackageType_View", "PackageType", {"PackageType"}, "PackageType")
            CreateDataSource("DrugRouteOfAdministration_View", "RouteOfAdministration", {"RouteOfAdministration"}, "RouteOfAdministration")
            CreateLookupData("ItemDetails", "ItemDetailsByName", {"Primary_Key", "ItemNameEnglish", "Item_Code"}, "BranchId='01'")
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "Active = 1"
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

        Public Sub OnGTinValueChanged(sender As Object, gTinValue As String)
            If gTinValue IsNot Nothing Or gTinValue <> "" Then
                Dim gTinIdNo As Integer = Service.GetField("GTin", "DrugList")
                Dim obj As Object = Service.GetFieldsWithIdNo(gTinIdNo, "DrugList", "[Dosage Form],[Generic Name],[Package Size],[Package Type],[RegistrationNo],[Route Of Administration],[Strength Value],[Unit Of Strength],[Unit Of Volume],Volume")
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
            Else

            End If
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
                View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
            End If
        End Sub

        'Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode2.GenerateCode
        '    Return Service.UpdateCode("ItemDetails", idNo)
        'End Function

        Public Sub OnAfterSaveItemDetails() Handles Me.AfterSave
            Service.InsertRecord("StockPOsitionCurrent", {"BranchID", "Item_Code", "Batch", "Expiry", "WarehouseID", "PCSQty", "CashPrice", "CreditPrice", "CostPrice", "PurchaseNo", "TmpStock"},
                                                        {"String", "String", "String", "DateTime", "String", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal"},
                                                        {"01", View.ItemDetailsCode, "000", Now(), "01", 0, 0, 0, 0, 0, 0})
        End Sub

    End Class

End Namespace