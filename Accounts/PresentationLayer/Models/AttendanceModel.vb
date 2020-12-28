Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class AttendanceModel

        Public Property IdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property DaysPresent As Decimal
        Public Property DaysAbsentWithPay As Decimal
        Public Property DaysAbsentWithoutPay As Decimal
        Public Property DaysOff As Decimal
        Property Errors As List(Of String)

    End Class

End Namespace