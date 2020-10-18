Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayPeriodModel

        Public Property EndDate As Date
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayCycleIdNo As Int16
        Public Property PayPeriodCode As String
        Public Property PayPeriodName As String
        Public Property PayPeriodNameAra As String
        Public Property StartDate As Date
    End Class

End Namespace