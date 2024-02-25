Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class HolidayPresenter(Of TM As New)
        Inherits CommonPresenter(Of IHolidayView, TM)

        Public Sub New(itemView As IHolidayView)
            MyBase.New(itemView)
            Service = New AccountsService("Holiday")
            TableName = "Holiday"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"User", "EnteredBy", "IdNo,UserName", Nothing},
                                    New String() {"Leave", "LeaveIdNo", Nothing, "Holiday = 1"}})
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeLeave", "HolidayIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "HolidayTransfer", "HolidayIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace