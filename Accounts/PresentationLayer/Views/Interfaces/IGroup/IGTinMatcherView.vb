Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IGTinMatcherView
        Inherits IItemDetailsView

        Property DrugGTin As String
        Property DrugGenericName As String
        Property DrugDosageForm As String
        Property DrugTradeName As String
        Property DrugPackageSize As Double?
        Property DrugPackageType As String
        Property DrugRegistrationNo As String
        Property DrugStrengthValue As String
        Property DrugUnitOfStrength As String
        Property DrugUnitOfVolume As String
        Property DrugVolume As Double?
        Property DrugRouteOfAdministration As String
        Property DrugIdNo As Integer
        Property DrugList As Object
        Property DrugPublicPrice As Decimal
        'Property QtyOnHand As Decimal?
        'Event GetDrugDataTable(ByRef drugListDataTable As DataTable)
        'Event GetItemDataTable(ByRef itemListDataTable As DataTable)

        Event UpdateDrugDisplay(itemIdNo As Int32)
        Event UpdateItemDisplay(gTinIdNo As Integer)

        Event UpdateItemDisplay(gTinIdNo As Integer)

        Event MatchGTinRequested(gTinNumber As String, itemDetailIdNo As Integer)

        'Event GTinMatcherValueChanged(sender As Object, gTinIdNo As Int32)

    End Interface

End Namespace