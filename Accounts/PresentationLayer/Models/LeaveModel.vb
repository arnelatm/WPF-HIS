Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class LeaveModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property LeaveCode As String
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property LeaveAllowed As Int16
        Public Property PaidPercent As Decimal
        Public Property Cumulative As Boolean
        Public Property MaxCarryOver As Int16
        Public Property MaxLimit As Int16
        Public Property NoMaxLimit As Boolean
        Public Property Notes As String
    End Class

End Namespace