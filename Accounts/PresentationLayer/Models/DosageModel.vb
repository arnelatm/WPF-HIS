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

End Namespace