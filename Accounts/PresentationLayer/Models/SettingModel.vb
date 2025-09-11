Imports AATM.Presentation.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SettingModel
        'Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property SettingCode As String
        Public Property SettingName As String
        Public Property SettingNameAra As String
        Public Property CodeGroupIdNo As Int16
        Public Property Note As String
    End Class

End Namespace