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
        'Implements ISubscriber(Of DataChanged)

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
                Dim transactionNumber As Int32
                transactionNumber = Service.GetNextSeries("IdPrintingSeries")
                Dim dtEmployeeLeaveStatus As New DataTable
                CreateDataTable(dtEmployeeLeaveStatus, {{"EmployeeLeaveIdNo", GetType(Int32)},
                                                         {"EnteredBy", GetType(Int32)},
                                                         {"Status", GetType(Int32)},
                                                         {"EnteredBy", GetType(Int32)}
                                                        })
                For Each leave As IEmployeeLeaveView In View.EmployeeLeaveList
                    If leave.Approve Then
                        Dim workRow As DataRow
                        workRow = dtEmployeeLeaveStatus.NewRow()
                        workRow("EmployeeLeaveIdNo") = leave.IdNo
                        workRow("EnteredBy") = GlobalVariables.UserIdNo
                        'workRow("Status") =
                        'dtIdPrinting.Rows.Add(workRow)
                    End If
                Next
                'Dim retVal = Service.ExecuteTvpSp("InsertEmployeeIdPrintingTvp", dtIdPrinting)
                'Dim cForm
                'cForm = New ReportForm("HR Id Printing.Rpt", transactionNumber, "TransactionNumber")
                'cForm.Show()
            End If
        End Sub

        'Public Sub OnEmpLeaveDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
        '    With eventType.BindingSource
        '        If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
        '            Select Case eventType.PropertyName
        '                Case $"Approve"
        '                    Dim employeeLeave As IEmployeeLeaveView = eventType.BindingSource.Current
        '                    If employeeLeave.Approve Then
        '                        employeeLeave.Disapprove = False
        '                    End If
        '                Case $"Disapprove"
        '                    Dim employeeLeave As IEmployeeLeaveView = eventType.BindingSource.Current
        '                    If employeeLeave.Disapprove Then
        '                        employeeLeave.Approve = False
        '                    End If
        '            End Select
        '        End If
        '    End With
        'End Sub

        'Private Sub OnApprovalCheckedEvent(sender As Object)
        '    sender.Approve = Not sender.Approve
        '    sender.bsEmployeeLeave.ResetBindings(False)
        'End Sub

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