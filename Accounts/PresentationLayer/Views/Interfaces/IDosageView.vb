Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDosageView
        Inherits IView

        Property IdNo As Int32
        Property DosageCode As String
        Property DosageName As String
        Property DosageNameAra As String
        Property Route As Int32
        Property Direction As Int32
        Property Frequency As Int32
        Property FrequencyTiming As Int32

    End Interface

    Public Interface IDosagePrintingView
        Inherits IDosageView

        Property Dose As Decimal
        Property DosageUnit As Int32
        Property Duration As Decimal
        Property DurationTiming As Decimal
        Property FileNo As Int32
        Property PatientName As String
        Property Age As Int16
        Property AgeDMY As String
        Property Gender As String
        Event AddNewDosage()
        Event UpdateTree()
        Event UpdatePatient()

    End Interface

End Namespace
