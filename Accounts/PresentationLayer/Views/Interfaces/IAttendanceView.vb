Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IAttendanceView
        Inherits IView

        Property IdNo As Int32
        Property EmployeeIdNo As Int32
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property DaysPresent As Decimal
        Property DaysAbsentWithPay As Decimal
        Property DaysAbsentWithoutPay As Decimal
        Property DaysOff As Decimal


    End Interface

End Namespace