Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DurationListModel
        Inherits DurationModel

        Public Property DurationListModel As List(Of DurationModel)

    End Class

    Public Class DurationModel

        Public Property DurationCode As String
        Public Property DurationName As String
        Public Property DurationNameARa As String
        Public Property IdNo As Int32
    End Class

End Namespace