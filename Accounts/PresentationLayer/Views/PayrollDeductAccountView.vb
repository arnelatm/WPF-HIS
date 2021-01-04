Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollDeductAccountView
        Implements IPayrollDeductAccountView

        Public Property AccountIdNo As Int16 Implements IPayrollDeductAccountView.AccountIdNo
        Public Property AccountName As String Implements IPayrollDeductAccountView.AccountName
        Public Property DeductionIdNo As Int16 Implements IPayrollDeductAccountView.DeductionIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPayrollDeductAccountView.IdNo
        Public Property PayGroupIdNo As Int16 Implements IPayrollDeductAccountView.PayGroupIdNo
        Public Property PayGroupName As String Implements IPayrollDeductAccountView.PayGroupName
        Public Property Sequence As Int16 Implements IPayrollDeductAccountView.Sequence

    End Class

    'Public Class GeneralPayrollDeductAccountView
    '    Inherits PayrollDeductAccountView

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