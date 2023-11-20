Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveEarnedPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveEarnedView, TM)

        Private ReadOnly _employeeLeaveEarnedService = New AccountsService("EmployeeLeaveEarned")

        Public Sub New(itemView As IEmployeeLeaveEarnedView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableName = "EmployeeLeaveEarned"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"User", "EnteredBy", "IdNo,UserName", Nothing},
                             New String() {"Employee", "EmployeeIdNo", Nothing, Nothing},
                             New String() {"Leave", "LeaveIdNo", Nothing, "Earnable = 1"}
                             })
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub


        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                retValue = IsLeaveValid()
            End If
            Return retValue
        End Function

        Private Function IsLeaveValid() As Boolean
            Dim retValue As Boolean = False
            If NoOverlappingDates() Then
                retValue = True
            End If
            Return retValue
        End Function


        Private Function NoOverlappingDates() As Boolean
            Dim noOverlap As Boolean = True
            Dim overlappingLeave As EmployeeLeaveEarnedModel = _employeeLeaveEarnedService.GetOverlappingEarnedLeave(View.EmployeeIdNo, View.StartDate, View.EndDate, View.LeaveIdNo)
            If overlappingLeave.IdNo > 0 Then
                MessageBox.Show("The applied date for this leave overlaps with an existing leave earned leave application. See Earned Leave Application Number #" & overlappingLeave.IdNo.ToString("N0"))
                noOverlap = False
            End If
            Return noOverlap
        End Function


    End Class

End Namespace