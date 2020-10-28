Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PensionSchemeModel

        Public Property Errors As List(Of String)
        Public Property AccountIdNo As Int16?
        Public Property IdNo As Int16
        Public Property Notes As String
        Public Property PensionProviderIdNo As Int16?
        Public Property PensionSchemeCode As String
        Public Property PensionSchemeName As String
        Public Property PensionSchemeNameAra As String
    End Class

End Namespace