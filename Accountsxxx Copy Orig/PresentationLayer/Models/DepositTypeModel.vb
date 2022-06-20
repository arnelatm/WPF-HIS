Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DepositTypeModel

        Public Property AccountIdNo As Int16
        Public Property BankChargesAccountIdNo As Int16?
        Public Property BankChargesVatAccountIdNo As Int16?
        Public Property DepositTypeCode As String
        Public Property DepositTypeName As String
        Public Property DepositTypeNameAra As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property WithBankCharges As Boolean

    End Class

End Namespace