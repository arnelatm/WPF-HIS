Imports AATM.Presentation.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ItemCodeModel
        'Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property ItemCodeCode As String
        Public Property ItemCodeName As String
        Public Property ItemCodeNameAra As String
        Public Property CodeGroupIdNo As Int16
        Public Property Note As String
    End Class

End Namespace