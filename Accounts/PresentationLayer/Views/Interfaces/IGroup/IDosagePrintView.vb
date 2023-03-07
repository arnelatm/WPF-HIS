Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDosagePrintView
        Inherits IView

        Property Dosage As String
        Property DosageUnit As String
        Property Route As String
        Property Direction As String
        Property Frequency As String
        Property FrequencyTiming As String
        Property Duration As String
        Property DurationUnit As String

    End Interface

End Namespace