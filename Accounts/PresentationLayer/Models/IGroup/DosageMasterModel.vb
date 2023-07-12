Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DosageMasterModel

        Public Property DosageMasterListModel As List(Of DosageMasterDetailModel)

    End Class

    Public Class DosageMasterDetailModel

        Public Property DosageMasterCode As String
        Public Property DosageMasterName As String
        Public Property DosageMasterNameARa As String
        Public Property IdNo As Int32
    End Class

End Namespace