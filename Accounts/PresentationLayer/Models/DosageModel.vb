Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DosageModel
        Public Property IdNo As Int32
        Public Property DosageCode As String
        Public Property DosageName As String
        Public Property DosageNameAra As String
        Public Property Route As Int32
        Public Property Direction As Int32
        Public Property Frequency As Int32
        Public Property FrequencyTiming As Int32
    End Class

    Public Class DosagePrintingModel
        Inherits DosageModel

        Public Property Age As Int16
        Public Property AgeDMY As String
        Public Property Dose As Decimal
        Public Property DoseUnit As Int16
        Public Property Duration As Decimal
        Public Property DurationUnit As Int16
        Public Property FileNo As Int32
        Public Property Gender As String
        Public Property PatientName As String


    End Class

End Namespace