Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class RecurringPayElementModel

        Public Property Active As Boolean
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As Date?
        Public Property IdNo As Int32
        Public Property LimitAmount As Decimal
        Public Property PayElementIdNo As Int16
        Public Property PeriodicAmount As Decimal
        Public Property RecurType As String
        Public Property StartDate As Date?
        Public Property TotalAmount As Decimal

    End Class

End Namespace