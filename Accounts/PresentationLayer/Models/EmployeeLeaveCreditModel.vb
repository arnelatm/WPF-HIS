Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveCreditModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property EmployeeIdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveAllowed As Int16
        Public Property PaidPercent As Decimal
        Public Property Cumulative As Boolean
        Public Property MaxCarryOver As Int16
        Public Property MaxLimit As Int16
        Public Property NoMaxLimit As Boolean
        Public Property AccumulatedLeaves As Int16

    End Class

End Namespace