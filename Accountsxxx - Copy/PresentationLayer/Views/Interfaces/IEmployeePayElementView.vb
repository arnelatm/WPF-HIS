Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeePayElementView
        Inherits IView
        Property Amount As Decimal
        Property PayElementCode As String
        Property PayElementIdNo As Int16
        Property PayElementName As String
        Property PayElementNameAra As String
        Property PayElementType As Char
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property Rate As Decimal
        Property Sequence As Int16
        Property Unit As String
    End Interface

End Namespace