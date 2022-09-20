Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DrugAcceptModel
        Public Property BatchNo As String
        Public Property Expiry As Date?
        Public Property GTin As String
        Public Property IdNo As Int32
        Public Property Item_Code As String
        Public Property ItemNameEnglish As String
        Public Property AcceptDate As Date?
        Public Property SerializationNo As String
    End Class

End Namespace