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

        Event GetDataTable(ByRef drugListDataTable As DataTable)

        Event UpdateDrugDisplay(itemIdNo As Int32)

        'Event GTinMatcherValueChanged(sender As Object, gTinIdNo As Int32)

    End Interface

End Namespace