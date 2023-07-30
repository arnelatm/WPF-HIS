Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransactionView
        Inherits IView

        Property Amount As Decimal
        Property BranchIdNo As Int16
        Property Cancelled As Boolean
        Property DateCreated As Date
        Property IdNo As Int32
        Property InvTransTypeIdNo As Int16
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TransactionDate As Date
        Property UserIdNo As Int16
        Property WarehouseIdNo As Int16
        Property WarehouseToIdNo As Int16?

    End Interface

End Namespace