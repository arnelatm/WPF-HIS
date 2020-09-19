Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DeductionModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property DeductionCode As String
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property AccountIdNo As Int16
        Public Property DefaultFrequency As Char
        Public Property DeductionType As Char
        Public Property Notes As String
    End Class

End Namespace