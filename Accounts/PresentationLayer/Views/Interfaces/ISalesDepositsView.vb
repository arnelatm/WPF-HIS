Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalesDepositsView
        Inherits IView

        Property SalesDeposits As IList(Of SalesDepositModel)

    End Interface

End Namespace