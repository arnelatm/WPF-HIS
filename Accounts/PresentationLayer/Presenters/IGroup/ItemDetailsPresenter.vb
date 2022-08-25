Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Presenters

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
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("DrugDosageForm_View", "DosageForm",{"DosageForm"},"DosageForm")
            CreateDataSource("DrugUnitOfVolume_View", "UnitOfVolume",{"UnitOfVolume"},"UnitOfVolume")
            CreateDataSource("DrugUnitOfStrength_View", "UnitOfStrength",{"UnitOfStrength"},"UnitOfStrength")
            CreateDataSource("DrugPackageType_View", "PackageType",{"PackageType"},"PackageType")
            CreateDataSource("DrugRouteOfAdministration_View", "RouteOfAdministration",{"RouteOfAdministration"},"RouteOfAdministration")
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