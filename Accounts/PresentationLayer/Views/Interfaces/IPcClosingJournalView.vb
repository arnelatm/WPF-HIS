Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPcClosingJournalView
        Inherits IView

        Property Amount As Decimal
        Property CdJournalIdNo As Int32
        Property IdNo As Int32
        Property Notes As String
        Property PayeeName As String
        Property PayeeNameAra As String
        Property PaymentType As String
        Property PayType As String
        Property PcClosed As Boolean
        Property ReferenceNo As String
        Property TransactionDate As Date?

    End Interface

End Namespace