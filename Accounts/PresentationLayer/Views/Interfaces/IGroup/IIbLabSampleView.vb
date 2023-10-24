Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IIbLabSampleView
        Property TransactionDate As Date?
        Property IbLabSampleDetails As List(Of IbLabSampleDetailView)
    End Interface



    Public Interface IIbLabSampleDetailView
        Property IdNo As Int32
        Property TransKey As Int32
        Property TakenDate As Date
        Property TakenTime As DateTime
        Property TakenBy As String
        Property Urine As Boolean
        Property Stool As Boolean
        Property Rbs As Decimal
    End Interface

End Namespace