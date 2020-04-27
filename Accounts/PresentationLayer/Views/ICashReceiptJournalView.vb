Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICashReceiptJournalView
        Inherits IView
        Property AccountIdNo As Int32
        Property Amount As Decimal
        Property Applied As Decimal
        Property Cancelled As Boolean
        Property CheckDate As Date?
        Property CheckNumber As String
        ReadOnly Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int32?
        Property DiscountTaken As Decimal
        Property IdNo As Integer
        Property Notes As String
        Property OrNumber As String
        Property PayorIdNo As Int32
        Property PayorName As String
        Property PayorType As String
        ReadOnly Property Posted As Boolean
        Property ReferenceNo As String
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
    End Interface

End Namespace