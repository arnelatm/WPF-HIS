Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IOtWorkHourView
        Inherits IView

        Property IdNo As Int32
        Property EmployeeIdNo As Int32
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property OvertimeRegular As Decimal
        Property OvertimeHoliday As Decimal
        Property OvertimeSpecial As Decimal
        Property PayrollIdNo As Int16
        Property Sequence As Int16
    End Interface

End Namespace