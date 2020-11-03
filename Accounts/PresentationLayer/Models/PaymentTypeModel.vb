Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PaymentTypeModel

        Public Property AccountIdNo As Int16
        Public Property BankChargesAccountIdNo As Int16
        Public Property BankChargesVatAccountIdNo As Int16
        Public Property PaymentTypeCode As String
        Public Property PaymentTypeName As String
        Public Property PaymentTypeNameAra As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property Rate As Decimal

    End Class

End Namespace