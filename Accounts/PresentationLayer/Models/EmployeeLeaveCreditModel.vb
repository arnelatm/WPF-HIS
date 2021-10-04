Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveCreditModel

        Public Property AccumulatedLeaves As Decimal
        Public Property Cumulative As Boolean
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property LeaveAllowed As Decimal
        Public Property LeaveIdNo As Int16
        Public Property MaxCarryOver As Decimal
        Public Property MaxLimit As Decimal
        Public Property PaidPercent As Decimal
        Public Property Sequence As Int16

    End Class

End Namespace