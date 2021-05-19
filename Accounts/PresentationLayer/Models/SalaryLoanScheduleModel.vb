Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SalaryLoanScheduleModel

        Public Property Amount As Decimal
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property PeriodicPayment As Decimal
        Public Property StartDate As Date?

    End Class

End Namespace