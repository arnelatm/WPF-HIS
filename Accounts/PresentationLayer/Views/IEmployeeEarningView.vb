Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IEmployeeEarningView
        Inherits IView
        Property Amount As Decimal
        Property EarningCode As String
        Property EarningIdNo As String
        Property EarningName As String
        Property EarningNameAra As String
        Property EarningType As Char
        Property EmployeeIdNo As String
        Property IdNo As Int32
        Property Sequence As Int16
    End Interface

End Namespace