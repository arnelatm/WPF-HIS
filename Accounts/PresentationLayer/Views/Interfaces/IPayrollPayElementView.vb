Namespace PresentationLayer.Views.Interfaces

    Friend Interface IPayrollPayElementView
        Property Amount As Decimal
        Property EmployeeIdNo As Int32
        Property Errors As List(Of String)
        Property IdNo As Int32
        Property PayElementIdNo As Int16
        Property PayrollDetailIdNo As Int32
        Property PayrollIdNo As Int16
        Property RecurringPayElementIdNo As Int32

    End Interface

End Namespace