Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeEarningView
        Implements IEmployeeEarningView, ISelfDuplicating

        Public Property Amount As Decimal Implements IEmployeeEarningView.Amount
        Public Property EarningCode As String Implements IEmployeeEarningView.EarningCode
        Public Property EarningIdNo As Int16 Implements IEmployeeEarningView.EarningIdNo
        Public Property EarningName As String Implements IEmployeeEarningView.EarningName
        Public Property EarningNameAra As String Implements IEmployeeEarningView.EarningNameAra
        Public Property EarningType As Char Implements IEmployeeEarningView.EarningType
        Public Property EmployeeIdNo As Int32 Implements IEmployeeEarningView.EmployeeIdNo
        Public Property IdNo As Int32 Implements IEmployeeEarningView.IdNo
        Public Property Sequence As Int16 Implements IEmployeeEarningView.Sequence
        Public Property Errors As List(Of String) Implements IView.Errors

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New EmployeeEarningView
        End Function

    End Class


End Namespace