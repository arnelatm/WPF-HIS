Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollModel

        Public Property EndDate As Date
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayCycleIdNo As Int16
        Public Property PayrollCode As String
        Public Property PayrollName As String
        Public Property PayrollNameAra As String
        Public Property StartDate As Date
        Public Property PayrollAttendance As List(Of AttendanceItemModel)
        Public Property PayrollOvertime As List(Of OvertimeItemModel)
    End Class

End Namespace