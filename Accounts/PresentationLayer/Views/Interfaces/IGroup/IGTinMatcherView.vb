Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IGTinMatcherView
        Inherits IItemDetailsView

        Property DrugTradeName As String
        Property DrugPackageSize As Double?
        Property DrugPackageType As String
        Property DrugRegistrationNo As String
        Property DrugStrengthValue As String
        Property DrugUnitOfStrength As String
        Property DrugUnitOfVolume As String
        Property DrugUserId As String
        Property DrugVolume As Double?
        Property DrugPrescriptionDrug As Boolean
        Property DrugRouteOfAdministration As String

    End Interface

End Namespace