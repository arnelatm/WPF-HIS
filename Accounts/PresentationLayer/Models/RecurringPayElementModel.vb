Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class RecurringPayElementModel

        Public Property Amount As Decimal
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property PayElementIdNo As Int16
        Public Property PeriodicPayment As Decimal
        Public Property StartDate As Date?
        Public Property TotalAmount As Decimal

    End Class

End Namespace