Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveApprovalPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IEmployeeLeaveApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService
        Private _holiday As Boolean
        Private _dtEmployeeLeaveApproval As New DataTable

        Public Sub New(view As IEmployeeLeaveApprovalView, holiday As Boolean)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeaveApproval")
            TableName = "EmployeeLeaveApproval"
            SortOrderKey = "IdNo"
            AskBeforeSave = True
            DisableSaveMemento = True
            _holiday = holiday
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.ApprovalCheckedEvent, AddressOf OnApprovalCheckedEvent

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim filter As String = "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If IsUserASupervisor() Then
                Dim employeeIdNo As Int32
                employeeIdNo = Service.GetUserEmployeeIdNo()
                filter += " and LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            Dim employeeLeaveList As List(Of EmployeeLeave) = Service.GetDaoRecords(filter)
            Dim employeeLeaveListModel As New List(Of EmployeeLeaveModel)
            GlobalVariables.Mapper.Map(employeeLeaveList, employeeLeaveListModel)
            GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveList)
            CreateLookupData("Employee", "EmployeeList")
            CreateDataSource("User", "EnteredBy", {"IdNo", "UserName"})
            CreateLookupData("Leave", "LeaveList")
            CreateEnumData(Of LeaveStatusSelection)(View.LeaveStatusList)
            If IsUserASupervisor() Then
                CreateEnumData(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumData(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Sub CreateApprovalData()
            If Not CancelSave Then
                _dtEmployeeLeaveApproval.Clear()
                CreateDataTable(_dtEmployeeLeaveApproval, {{"EmployeeLeaveApprovalIdNo", GetType(Int32)},
                                                          {"EmployeeLeaveIdNo", GetType(Int16)},
                                                          {"Note", GetType(String)},
                                                          {"Status", GetType(Int32)}
                                                          })
                For Each leave As IEmployeeLeaveView In View.EmployeeLeaveList
                    If leave.Approve Or leave.Disapprove Then
                        Dim workRow As DataRow
                        workRow = _dtEmployeeLeaveApproval.NewRow()
                        workRow("EmployeeLeaveIdNo") = leave.IdNo
                        workRow("Note") = leave.ApprovalNote
                        If leave.Approve Then
                            If IsUserASupervisor() Then
                                workRow("Status") = EnumToCode(LeaveStatusSelection.SupervisorApproved)
                            Else
                                workRow("Status") = EnumToCode(LeaveStatusSelection.Approved)
                            End If
                        Else
                            workRow("Status") = EnumToCode(LeaveStatusSelection.Disapproved)
                        End If
                        _dtEmployeeLeaveApproval.Rows.Add(workRow)
                    End If
                Next
            End If
        End Sub

        Public Overrides Function Save(ByRef viewControl As Control)
            Dim retVal As Integer
            Dim record As New EmployeeLeaveApprovalModel
            GlobalVariables.Mapper.Map(Of IEmployeeLeaveApprovalView, EmployeeLeaveApprovalModel)(View, record)
            NewlyAddedRecordIdNo = Service.AddRecord(record)
            If NewlyAddedRecordIdNo > 0 Then
                CreateApprovalData()
                For Each row As DataRow In _dtEmployeeLeaveApproval.Rows
                    row.Item("EmployeeLeaveApprovalIdNo") = NewlyAddedRecordIdNo
                Next row
                retVal = Service.ExecuteTvpSp("InsertEmployeeLeaveApprovalItemTvp", _dtEmployeeLeaveApproval)
            End If
            Return retVal
        End Function

        Public Overrides Function ChangesMade() As Boolean
            Dim retVal As Boolean = False
            For Each item In View.EmployeeLeaveList
                If item.Approve Or item.Disapprove Then
                    retVal = True
                    Exit For
                End If
            Next
            Return retVal
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim valid As Boolean = True
            For Each leave As IEmployeeLeaveView In View.EmployeeLeaveList
                If leave.Disapprove Then
                    If leave.ApprovalNote Is Nothing OrElse leave.ApprovalNote.Trim() = "" Then
                        Messaging.Show(True, "MsgEmptyApprovalNote", {"leaveNumber", leave.IdNo.ToString()})
                        valid = False
                    End If
                End If
            Next
            Return valid
        End Function

    End Class

End Namespace