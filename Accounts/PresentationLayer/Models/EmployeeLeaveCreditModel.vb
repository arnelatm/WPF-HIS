Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveCreditModel

        Public Property AccumulatedLeaves As Int16
        Public Property Cumulative As Boolean
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property LeaveAllowed As Int16
        Public Property LeaveIdNo As Int16
        Public Property MaxCarryOver As Int16
        Public Property MaxLimit As Int16
        Public Property NoMaxLimit As Boolean
        Public Property PaidPercent As Decimal
        Public Property Sequence As Int16

    End Class

End Namespace