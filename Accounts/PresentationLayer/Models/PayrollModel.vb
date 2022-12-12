Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollModel

        Public Property EndDate As Date
        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property PayCycleIdNo As Byte
        Public Property PayrollCode As String
        Public Property PayrollName As String
        Public Property PayrollNameAra As String
        Public Property StartDate As Date
        Public Property PayrollAttendance As List(Of AttendanceItemModel)
        Public Property PayrollOvertime As List(Of OtWorkHourModel)
    End Class

End Namespace