Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeIdListView
        Implements IEmployeeIdListView

        Public Sub New()
        End Sub

        Public Property IdNo As Int32 Implements IEmployeeIdListView.IdNo

        Public Property EmployeeName As String Implements IEmployeeIdListView.EmployeeName

        Public Property NationalIdNo As String Implements IEmployeeIdListView.NationalIdNo

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property Picture As Image Implements IEmployeeIdListView.Picture
            
    End Class

End Namespace