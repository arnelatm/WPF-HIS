Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeEarningView
        Implements IEmployeeEarningView

        Public Property Amount As Decimal Implements IEmployeeEarningView.Amount

        Public Property EarningCode As String Implements IEmployeeEarningView.EarningCode

        Public Property EarningIdNo As String Implements IEmployeeEarningView.EarningIdNo

        Public Property EarningName As String Implements IEmployeeEarningView.EarningName

        Public Property EarningNameAra As String Implements IEmployeeEarningView.EarningNameAra

        Public Property EarningType As Char Implements IEmployeeEarningView.EarningType

        Public Property EmployeeIdNo As String Implements IEmployeeEarningView.EmployeeIdNo

        Public Property IdNo As Integer Implements IEmployeeEarningView.IdNo

        Public Property Sequence As Short Implements IEmployeeEarningView.Sequence

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace