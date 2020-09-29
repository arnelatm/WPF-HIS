Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollEarnAccountsView
        Inherits IView

        Property PayrollEarnAccounts As IList(Of PayrollEarnAccountModel)

    End Interface

End Namespace