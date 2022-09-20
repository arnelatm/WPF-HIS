Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IItemDetailsView
        Inherits IView

        Property BranchID As String
        Property DosageForm As String
        Property GenericName As String
        Property GTIN As String
        Property IdNo As Int32
        Property ItemDetailsCode As String
        Property ItemDetailsName As String
        Property ItemGroup As String
        Property Pack1 As Int16
        Property Pack2 As Int16
        Property Pack3 As Int16
        Property PackageSize As Double?
        Property PackageType As String
        Property Price_Cash As Decimal?
        Property QtyOnHand As Decimal?
        Property RegistrationNo As String
        Property StrengthValue As String
        Property UnitOfStrength As String
        Property UnitOfVolume As String
        Property Volume As Double?
        Property PrescriptionDrug As Boolean
        Property RouteOfAdministration As String

        Event FinderValueChanged(itemIdNo As Int16)

        Event GTinValueChanged(sender As DataGridView, gTinValue As String)

    End Interface

End Namespace