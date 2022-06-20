Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeIdView
        Implements IEmployeeIdView

        Public Sub New()
        End Sub

        Public Property IdNo As Int32 Implements IEmployeeIdView.IdNo

        Public Property EmployeeName As String Implements IEmployeeIdView.EmployeeName

        Public Property NationalIdNo As String Implements IEmployeeIdView.NationalIdNo

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property Picture As Image Implements IEmployeeIdView.Picture
        Public Property Print As Boolean Implements IEmployeeIdView.Print

    End Class

End Namespace