Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IItemDetailsView
        Inherits IView

        Property BranchID As String
        Property Created_By_Branch As String
        Property IdNo As Int32
        Property ItemDetailsCode As String
        Property ItemDetailsName As String
        Property ItemGroup As String
        Property Pack1 As Int16
        Property Pack2 As Int16
        Property Pack3 As Int16
        Property Category As String
        Property SaleStrip As String
        Property Item_Status As String
        Property UserId As String
    End Interface

End Namespace