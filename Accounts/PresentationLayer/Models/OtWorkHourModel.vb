Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class OtWorkHourModel

        Public Property IdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property OvertimeRegular As Decimal
        Public Property OvertimeHoliday As Decimal
        Public Property OvertimeSpecial As Decimal
        Public Property PayrollIdNo As Int16
        Public Property Sequence As Int16
        Property Errors As List(Of String)

    End Class

End Namespace