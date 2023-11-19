Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveEarnedModel

        Public Property DateCreated As DateTime?
        Public Property DaysEarned As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As DateTime
        Public Property EnteredBy As Int32
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property Reason As String
        Public Property StartDate As Date
        Public Property Posted As Boolean


    End Class

End Namespace