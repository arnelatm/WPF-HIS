Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeDeductionView
        Implements IEmployeeDeductionView

        Public Property Amount As Decimal Implements IEmployeeDeductionView.Amount
        Public Property DeductionCode As String Implements IEmployeeDeductionView.DeductionCode
        Public Property DeductionIdNo As Short Implements IEmployeeDeductionView.DeductionIdNo
        Public Property DeductionName As String Implements IEmployeeDeductionView.DeductionName
        Public Property DeductionNameAra As String Implements IEmployeeDeductionView.DeductionNameAra
        Public Property DeductionType As Char Implements IEmployeeDeductionView.DeductionType
        Public Property IdNo As Integer Implements IEmployeeDeductionView.IdNo
        Public Property Sequence As Short Implements IEmployeeDeductionView.Sequence
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class
End Namespace