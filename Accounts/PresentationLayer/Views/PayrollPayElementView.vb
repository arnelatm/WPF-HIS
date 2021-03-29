Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Views

    Public Class PayrollPayElementView
        Public Property Amount As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayElementIdNo As Int16
        Public Property PayrollDetailIdNo As Int32
        Public Property PayrollIdNo As Int16
    End Class

End Namespace