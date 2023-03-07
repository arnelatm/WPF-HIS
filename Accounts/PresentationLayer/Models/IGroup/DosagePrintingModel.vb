Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DosagePrintingModel
        Public Property Dosage As String
        Public Property DosageUnit As String
        Public Property Route As String
        Public Property Direction As String
        Public Property Frequency As String
        Public Property FrequencyTiming As String
        Public Property Duration As String
        Public Property DurationUnit As String
    End Class

End Namespace