Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollEarnAccountView
        Implements IPayrollEarnAccountView

        Public Property AccountIdNo As Int16 Implements IPayrollEarnAccountView.AccountIdNo
        Public Property AccountName As String Implements IPayrollEarnAccountView.AccountName
        Public Property EarningIdNo As Int16 Implements IPayrollEarnAccountView.EarningIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPayrollEarnAccountView.IdNo
        Public Property PayGroupIdNo As Int16 Implements IPayrollEarnAccountView.PayGroupIdNo
        Public Property PayGroupName As String Implements IPayrollEarnAccountView.PayGroupName
        Public Property Sequence As Int16 Implements IPayrollEarnAccountView.Sequence

    End Class

    'Public Class GeneralPayrollEarnAccountView
    '    Inherits PayrollEarnAccountView

    '    Public Sub New()
    '        Ea = New EventAggregator()
    '    End Sub

    'End Class

    'Public Class DebitChanged

    '    Public Sub New(ByVal debit As Decimal)
    '        Me.Debit = debit
    '    End Sub

    '    Public Property Debit As Decimal

    'End Class

    'Public Class CreditChanged

    '    Public Sub New(ByVal credit As Decimal)
    '        Me.Credit = credit
    '    End Sub

    '    Public Property Credit As Decimal

    'End Class

End Namespace