Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveApprovalPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IEmployeeLeaveApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        Public Sub New(view As IEmployeeLeaveApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeave")
            TableName = "EmployeeLeave"
            SortOrderKey = "EmployeeName"
            AskBeforeSave = True
            DisableSaveMemento = True
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.ApprovalCheckedEvent, AddressOf OnApprovalCheckedEvent

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim filter As String = "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            Dim employeeLeaveList As List(Of EmployeeLeave) = Service.GetDaoRecords(filter)
            Dim employeeLeaveListModel As New List(Of EmployeeLeaveModel)
            GlobalVariables.Mapper.Map(employeeLeaveList, employeeLeaveListModel)
            GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveList)
            CreateLookupData("Employee", "EmployeeList")
            CreateLookupData("Leave", "LeaveList")
            CreateEnumData(Of LeaveStatusSelection)(View.LeaveStatusList)
            If IsUserASupervisor() Then
                CreateEnumData(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumData(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                'Dim transactionNumber As Int32
                'Dim now As DateTime = Today()
                'transactionNumber = Service.GetNextSeries("EmployeeApprovalSeries")
                'Dim payrollDetail As New PayrollDetail
                'GlobalVariables.Mapper.Map(PayrollDetailModel, payrollDetail)
                'If payrollDetail.IdNo = 0 Then
                '    payrollDetailIdNo = _payrollDetailsService.AddRecord(payrollDetail)
                'End If
                'Dim dtEmployeeLeaveStatus As New DataTable
                'CreateDataTable(dtEmployeeLeaveStatus, {{"EmployeeLeaveIdNo", GetType(Int32)},
                '                                         {"EnteredBy", GetType(Int32)},
                '                                         {"Status", GetType(Int32)},
                '                                         {"EnteredBy", GetType(Int32)}
                '                                        })
                'For Each leave As IEmployeeLeaveView In View.EmployeeLeaveList
                '    If leave.Approve Or leave.Disapprove Then
                '        Dim workRow As DataRow
                '        workRow = dtEmployeeLeaveStatus.NewRow()
                '        workRow("EmployeeLeaveIdNo") = leave.IdNo
                '        workRow("EnteredBy") = GlobalVariables.UserIdNo
                '        If leave.Approve Then
                '            If IsUserASupervisor() Then
                '                workRow("Status") = LeaveStatusSelection.SupervisorApproved
                '            Else
                '                workRow("Status") = LeaveStatusSelection.Approved
                '            End If
                '        Else
                '            workRow("Status") = LeaveStatusSelection.Disapproved
                '        End If

                '        'dt dtIdPrinting.Rows.Add(workRow)
                '    End If
                'Next
                'Dim retVal = Service.ExecuteTvpSp("InsertEmployeeIdPrintingTvp", dtIdPrinting)
                'Dim cForm
                'cForm = New ReportForm("HR Id Printing.Rpt", transactionNumber, "TransactionNumber")
                'cForm.Show()
            End If
        End Sub

    End Class

End Namespace