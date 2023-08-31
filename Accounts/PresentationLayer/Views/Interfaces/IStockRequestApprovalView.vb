Imports AATM.Accounts.BusinessLayer
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IStockRequestApprovalView
        Inherits IView
        Property StockRequests As List(Of InvTransaction)

    End Interface

End Namespace