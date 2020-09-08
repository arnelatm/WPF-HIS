Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class FringeBenefitModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property FringeBenefitCode As String
        Public Property FringeBenefitName As String
        Public Property FringeBenefitNameAra As String
        Public Property AccountIdNo As Int32
        Public Property DefaultFrequency As Char
        Public Property FringeBenefitType As Char
        Public Property Notes As String
    End Class

End Namespace