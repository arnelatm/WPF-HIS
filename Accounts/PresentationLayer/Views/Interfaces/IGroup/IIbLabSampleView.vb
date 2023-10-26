Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IIbLabSampleView
        Inherits IView

        Property TransactionDate As Date?
        Property IbLabSampleDetails As List(Of IbLabSampleDetailView)
        Event IbLabSamplesRequested(transactionDate As Date?)
    End Interface



    Public Interface IIbLabSampleDetailView
        Inherits IView

        Property Age As Decimal
        Property IdNo As Int32
        Property IqamaNo As String
        Property LabNo As String
        Property Nationality As String
        Property PatientName As String
        Property Rbs As Decimal
        Property Sequence As Int32
        Property Stool As Boolean
        Property TakenBy As String
        Property TakenDate As Date
        Property TakenTime As String
        Property Urine As Boolean
    End Interface

End Namespace