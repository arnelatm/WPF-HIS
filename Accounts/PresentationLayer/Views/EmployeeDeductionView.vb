Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeDeductionView
        Implements IEmployeeDeductionView, ISelfDuplicating

        Public Property Amount As Decimal Implements IEmployeeDeductionView.Amount
        Public Property DeductionCode As String Implements IEmployeeDeductionView.DeductionCode
        Public Property DeductionIdNo As Int16 Implements IEmployeeDeductionView.DeductionIdNo
        Public Property DeductionName As String Implements IEmployeeDeductionView.DeductionName
        Public Property DeductionNameAra As String Implements IEmployeeDeductionView.DeductionNameAra
        Public Property DeductionType As Char Implements IEmployeeDeductionView.DeductionType
        Public Property EmployeeIdNo As Int32 Implements IEmployeeDeductionView.EmployeeIdNo
        Public Property IdNo As Int32 Implements IEmployeeDeductionView.IdNo
        Public Property Sequence As Int16 Implements IEmployeeDeductionView.Sequence
        Public Property Errors As List(Of String) Implements IView.Errors

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New EmployeeDeductionView
        End Function
    End Class
End Namespace