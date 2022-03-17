Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IItemDetailsView
        Inherits IView

        Property BranchID As String
        Property Category As String
        Property Created_By_Branch As String
        Property DosageForm As String
        Property GenericName As String
        Property IdNo As Int32
        Property Item_Status As String
        Property ItemDetailsCode As String
        Property ItemDetailsName As String
        Property ItemGroup As String
        Property Pack1 As Int16
        Property Pack2 As Int16
        Property Pack3 As Int16
        Property PackageSize As Decimal?
        Property PackageType As String
        Property SaleStrip As String
        Property StrengthValue As String
        Property UnitOfStrength As String
        Property UnitOfVolume As String
        Property UserId As String
        Property Volume As Decimal?
    End Interface

End Namespace