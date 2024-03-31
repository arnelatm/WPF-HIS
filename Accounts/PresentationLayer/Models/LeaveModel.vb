Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class LeaveModel

        Public Property Earnable As Boolean
        Public Property PaidPercent As Decimal
        Public Property Notes As String
        Public Property NoMaxLimit As Boolean
        Public Property MaxLimit As Decimal
        Public Property MaxCarryOver As Decimal
        Public Property LeaveNameAra As String
        Public Property LeaveName As String
        Public Property LeaveType As String
        Public Property LeaveCode As String
        Public Property LeaveAllowed As Decimal
        Public Property IdNo As Int16
        Public Property Holiday As Boolean
        Public Property Errors As List(Of String)
        Public Property Cumulative As Boolean

    End Class

End Namespace