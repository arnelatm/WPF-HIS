Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollDeductAccountsView
        Inherits IView

        Property PayrollDeductAccounts As IList(Of PayrollDeductAccountModel)

    End Interface

End Namespace