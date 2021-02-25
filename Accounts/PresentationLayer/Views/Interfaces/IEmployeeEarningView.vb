Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeEarningView
        Inherits IView
        Property Amount As Decimal
        Property EarningCode As String
        Property EarningIdNo As Int16
        Property EarningName As String
        Property EarningNameAra As String
        Property EarningType As Char
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property Rate As Decimal
        Property Sequence As Int16
        Property Unit As String
    End Interface

End Namespace