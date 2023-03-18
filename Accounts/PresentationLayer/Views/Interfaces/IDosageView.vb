Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDosageView
        Inherits IView

        Property IdNo As Int32
        Property DosageCode As String
        Property DosageName As String
        Property DosageNameAra As String
        Property Dose As Decimal
        Property DosageUnit As Int32
        Property Route As Int32
        Property Direction As Int32
        Property Frequency As Int32
        Property FrequencyTiming As Int32
        Property Duration As Int32
        Property DurationTiming As Int32

    End Interface

End Namespace
