Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IEmployeeDeductionView
        Inherits IView

        Property Amount As Decimal
        Property DeductionCode As String
        Property DeductionIdNo As Int16
        Property DeductionName As String
        Property DeductionNameAra As String
        Property DeductionType As Char
        Property IdNo As Int32

    End Interface

End Namespace