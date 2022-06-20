Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IHolidayView
        Inherits IView

        Property DateCreated As DateTime?
        Property DateEnd As Date
        Property DateStart As Date
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        'Property PayrollCode As String
        'Property PayrollEndDate As Date
        'Property PayrollIdNo As Int32
        'Property PayrollName As String
        'Property PayrollStartDate As Date

    End Interface

End Namespace