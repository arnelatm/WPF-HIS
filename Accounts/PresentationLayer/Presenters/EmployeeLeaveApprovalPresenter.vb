Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

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
            'AddHandler view.EmployeeIdCheckedEvent, AddressOf OnEmployeeIdCheckedEvent

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
                Dim transactionNumber As Int32
                transactionNumber = Service.GetNextSeries("IdPrintingSeries")
                Dim dtEmployeeLeaveStatus As New DataTable
                CreateDataTable(dtEmployeeLeaveStatus, {{"EmployeeLeaveIdNo", GetType(Int32)},
                                                         {"EnteredBy", GetType(Int32)},
                                                         {"Status", GetType(Int32)},
                                                         {"EnteredBy", GetType(Int32)}
                                                        })
                'For Each leave As EmployeeLeaveStatus In View.EmployeeLeaveList
                '    If EmployeeLeaveStatus.Print Then
                '        Dim workRow As DataRow
                '        workRow = dtIdPrinting.NewRow()
                '        workRow("EmployeeIdNo") = EmployeeId.IdNo
                '        workRow("TransactionNumber") = transactionNumber
                '        dtIdPrinting.Rows.Add(workRow)
                '    End If
                'Next
                'Dim retVal = Service.ExecuteTvpSp("InsertEmployeeIdPrintingTvp", dtIdPrinting)
                'Dim cForm
                'cForm = New ReportForm("HR Id Printing.Rpt", transactionNumber, "TransactionNumber")
                'cForm.Show()
            End If
        End Sub

        'Private Sub OnEmployeeIdCheckedEvent(sender As Object)
        '    sender.Print = Not sender.Print
        'End Sub

        'Private Sub OnClearAllEmployeeId(ByVal bsData As BindingSource, clear As Boolean)
        '    For Each item In bsData
        '        item.Print = clear
        '    Next item
        'End Sub

    End Class

End Namespace