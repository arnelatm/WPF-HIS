Public Class PcJournal
    Inherits AATM.BusinessLayer.BusinessObject

    ' ** Enterprise Design Pattern: Identity field pattern
    Public Sub New()
        ' establish business rules
    End Sub

    Public Property AccountIdNo As Int16?
    Public Property Amount As Decimal
    Public Property Applied As Decimal
    Public Property Cancelled As Boolean
    Public Property DateCreated As DateTime?
    Public Property PayType As String
    Public Property DiscountAccountIdNo As Int16?
    Public Property DiscountTaken As Decimal
    Public Property IdNo As Int32
    Public Property Notes As String
    Public Property OrNumber As String
    Public Property PayeeIdNo As Int32?
    Public Property PayeeName As String
    Public Property PaymentType As String
    Public Property PcClosed As Boolean
    Public Property Posted As Boolean
    Public Property ReferenceNo As String
    Public Property TotalCredits As Decimal
    Public Property TotalDebits As Decimal
    Public Property TransactionDate As Date?
    Public Property UnApplied As Decimal
    Public Property VatAmount As Decimal
    Public Property VatNumber As String
End Class
