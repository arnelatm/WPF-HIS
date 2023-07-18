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

        Property Age As Int16
        Property AgeDMY As String
        Property Dose As Decimal
        Property DoseUnit As Int32
        Property Duration As Decimal
        Property DurationUnit As Int16
        Property FileNo As Int32
        Property ItemCode As String
        Property ItemName As String
        Property GTin As String
        Property Gender As String
        Property PatientName As String
        Property PatientType As Int16
        Property DefaultDoseUnit As Int16
        Property DefaultDurationUnit As Int16
        Property GenericName As String
        Property BarCode As String
        Property ItemIdNo As Integer
        Event AddNewDosage()
        Event UpdateTree()
        Event UpdatePatient()
        Event FindPatient()
        Event ItemCodeChanged()
        Event ItemNameChanged(idNo As Int32)
        Event GTinChanged(cGTin As String)
        Event BarCodeChanged(cBarCode As String)
    End Interface

End Namespace
