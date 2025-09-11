Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayElementAccountsView
        Inherits IView

        Property PayElementAccounts As IList(Of PayElementAccountModel)

    End Interface

End Namespace