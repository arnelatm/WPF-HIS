Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class LeaveModel

        Public Property Cumulative As Boolean
        Public Property Errors As List(Of String)
        Public Property Holiday As Boolean
        Public Property IdNo As Int16
        Public Property LeaveAllowed As Decimal
        Public Property LeaveCode As String
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property MaxCarryOver As Decimal
        Public Property MaxLimit As Decimal
        Public Property Notes As String
        Public Property PaidPercent As Decimal

    End Class

End Namespace