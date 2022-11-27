Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class HolidayTransferItemView
        Implements IHolidayTransferItemView

        Public Sub New()
        End Sub

        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property EmployeeIdNo As Integer Implements IHolidayTransferItemView.EmployeeIdNo
        Public Property HolidayTransferIdNo As Integer Implements IHolidayTransferItemView.HolidayTransferIdNo
        Public Property IdNo As Integer Implements IHolidayTransferItemView.IdNo
        Public Property Transfer As Boolean Implements IHolidayTransferItemView.Transfer
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace