
Namespace PresentationLayer.Models
    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ApOpenInvoiceModel

        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property PaidAmount As Decimal

    End Class
End NameSpace