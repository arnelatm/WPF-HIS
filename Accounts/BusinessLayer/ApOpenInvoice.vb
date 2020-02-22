' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer

Namespace BusinessLayer

    Public Class ApOpenInvoice
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property IdNo As Integer

        Public Property DiscountTaken As Decimal
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property PaidAmount As Decimal

    End Class
End NameSpace