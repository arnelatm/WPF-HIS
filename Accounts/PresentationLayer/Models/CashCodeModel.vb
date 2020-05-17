Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CashCodeModel

        Public Property AccountIdNo As Int32?
        Public Property BankChargesAccountIdNo As Int32?
        Public Property BankChargesVatAccountIdNo As Int32?
        Public Property CashCode As String
        Public Property CashName As String
        Public Property CashNameAra As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Rate As Decimal

    End Class

End Namespace