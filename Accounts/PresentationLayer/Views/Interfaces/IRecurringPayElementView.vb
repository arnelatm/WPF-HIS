Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IRecurringPayElementView
        Inherits IView

        Property Active As Boolean
        Property Amount As Decimal
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property PayElementIdNo As Int16
        Property PeriodicPayment As Decimal
        Property RecurrType As String
        Property StartDate As Date?
        Property TotalAmount As Decimal

    End Interface

End Namespace