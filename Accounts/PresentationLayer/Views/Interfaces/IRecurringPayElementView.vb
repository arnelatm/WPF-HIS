Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IRecurringPayElementView
        Inherits IView

        Property Active As Boolean
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EndDate As Date?
        Property IdNo As Int32
        Property LimitAmount As Decimal
        Property PayElementIdNo As Int16
        Property PeriodicAmount As Decimal
        Property RecurType As String
        Property StartDate As Date?
        Property TotalAmount As Decimal

    End Interface

End Namespace