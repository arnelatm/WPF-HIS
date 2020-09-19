Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EarningModel

        Public Property AccountIdNo As Int16
        Public Property DefaultFrequency As Char
        Public Property EarningCode As String
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As Char
        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property Notes As String

    End Class

End Namespace
