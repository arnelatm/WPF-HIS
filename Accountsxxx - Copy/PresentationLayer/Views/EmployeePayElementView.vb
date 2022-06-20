Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeePayElementView
        Implements IEmployeePayElementView

        Public Property Amount As Decimal Implements IEmployeePayElementView.Amount
        Public Property PayElementCode As String Implements IEmployeePayElementView.PayElementCode
        Public Property PayElementIdNo As Int16 Implements IEmployeePayElementView.PayElementIdNo
        Public Property PayElementName As String Implements IEmployeePayElementView.PayElementName
        Public Property PayElementNameAra As String Implements IEmployeePayElementView.PayElementNameAra
        Public Property PayElementType As Char Implements IEmployeePayElementView.PayElementType
        Public Property EmployeeIdNo As Int32 Implements IEmployeePayElementView.EmployeeIdNo
        Public Property IdNo As Int32 Implements IEmployeePayElementView.IdNo
        Public Property Sequence As Int16 Implements IEmployeePayElementView.Sequence
        Public Property Rate As Decimal Implements IEmployeePayElementView.Rate
        Public Property Unit As String Implements IEmployeePayElementView.Unit
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace