Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of ILeaveView, LeaveModel)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            Service = New AccountsService("Leave")
            TableName = "Leave"
            TreeViewMainField = "LeaveName"
            TreeViewSecondaryField = "LeaveCode"
            SortOrderKey = "LeaveName"
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "EmployeeLeave", "LeaveIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "EmployeeLeaveCredit", "LeaveIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "Holiday", "LeaveIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace