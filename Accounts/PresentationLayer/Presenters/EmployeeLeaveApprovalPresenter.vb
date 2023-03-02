Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveApprovalPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        'Private _holiday As Boolean
        Private _dtEmployeeLeaveApproval As New DataTable

        Public Sub New(view As IEmployeeLeaveApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeaveApproval")
            TableName = "EmployeeLeaveApproval"
            SortOrderKey = "IdNo"
            'AskBeforeSave = True
            'DisableSaveMemento = True
            '_holiday = holiday
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.ApprovalCheckedEvent, AddressOf OnApprovalCheckedEvent
            CreateDataTable(_dtEmployeeLeaveApproval, {{"ApprovalNote", GetType(String)},
                                          {"EmployeeLeaveApprovalIdNo", GetType(Int32)},
                                          {"EmployeeLeaveIdNo", GetType(Int32)},
                                          {"Status", GetType(Int32)}
                                          })
        End Sub

        Protected Overrides Sub CreateDataSources()

            'Dim employeeLeaveList As List(Of EmployeeLeave) = Service.GetDaoRecords(filter)
            'Dim employeeLeaveListModel As New List(Of EmployeeLeaveModel)
            'GlobalVariables.Mapper.Map(employeeLeaveList, employeeLeaveListModel)
            'GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveApprovalItems)
            CreateLookupData("Employee", "EmployeeList")
            CreateDataSource("User", "ApprovedBy", {"IdNo", "UserName"})
            CreateLookupData("Leave", "LeaveList")
            CreateEnumData(Of LeaveStatusSelection)(View.LeaveStatusList)
            If IsUserASupervisor() Then
                CreateEnumData(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumData(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.ApprovedBy = GlobalVariables.UserIdNo
            View.DateCreated = Now()
            Dim filter As String = "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Used) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If IsUserASupervisor() Then
                Dim employeeIdNo As Int32
                employeeIdNo = Service.GetUserEmployeeIdNo()
                filter += " and LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            'Dim data As List(Of EmployeeLeaveApprovalItem) = Service.GetDaoRecords(filter)
            Dim employeeLeaveApprovalItemsModel As List(Of EmployeeLeaveApprovalItemModel) 
            employeeLeaveApprovalItemsModel = Service.GetDaoRecords(Of EmployeeLeaveApprovalItemModel)(filter)
            'GlobalVariables.Mapper.Map(data, employeeLeaveApprovalItemsModel)
            GlobalVariables.Mapper.Map(employeeLeaveApprovalItemsModel, View.EmployeeLeaveApprovalItems)
            CallByName(View, "BindEmployeeLeaveList", CallType.Method)

            'View.EmployeeLeaveApprovalItems = Service.GetDaoRecords(filter)

            'GlobalVariables.Mapper.Map(employeeLeaveList, employeeLeaveListModel)
            'GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveApprovalItems)
            'View.EmployeeLeaveApprovalItems = Service.GetDaoRecords(filter)
        End Sub

        Public Sub CreateApprovalData()
            If Not CancelSave Then
                _dtEmployeeLeaveApproval.Clear()
                For Each leave As IEmployeeLeaveApprovalItemView In View.EmployeeLeaveApprovalItems
                    If leave.Approve Or leave.Disapprove Then
                        Dim workRow As DataRow
                        workRow = _dtEmployeeLeaveApproval.NewRow()
                        workRow("ApprovalNote") = leave.ApprovalNote
                        workRow("EmployeeLeaveIdNo") = leave.IdNo
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

        'Public Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    Dim record As New EmployeeLeaveApprovalModel
        '    GlobalVariables.Mapper.Map(Of IEmployeeLeaveApprovalView, EmployeeLeaveApprovalModel)(View, record)
        '    NewlyAddedRecordIdNo = Service.AddRecord(record)
        '    If NewlyAddedRecordIdNo > 0 Then
        '        CreateApprovalData()
        '        For Each row As DataRow In _dtEmployeeLeaveApproval.Rows
        '            row.Item("EmployeeLeaveApprovalIdNo") = NewlyAddedRecordIdNo
        '        Next row
        '        retVal = Service.ExecuteTvpSp("InsertEmployeeLeaveApprovalItemTvp", _dtEmployeeLeaveApproval)
        '    End If

        'End Sub

        Public Overrides Function Save(ByRef viewControl As Control) As Boolean
            'RaiseEvent BeforeSave()
            'Dim record As New TM
            'GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
            'Dim retVal As Integer = InitiateSave()
            'If retVal < 0 Then
            '    Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Else
            '    RaiseEvent AfterSave()
            'End If
            'If retVal < 0 Then
            'Else
            '    Messaging.Show(True, "MsgRecordSuccessfullySaved")
            '    If AddMode Then
            '        RecordPositionNumber = GetSortedRecordPosition(retVal)
            '    Else
            '        RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
            '    End If
            '    AddMode = False
            '    EditMode = False
            '    UpdateViewData(TargetIdNo)
            '    ClearAllErrorMessages()
            'End If
            'Return retVal

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
            If retVal < 0 Then
                Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Messaging.Show(True, "MsgRecordSuccessfullySaved")
                If AddMode Then
                    RecordPositionNumber = GetSortedRecordPosition(NewlyAddedRecordIdNo)
                Else
                    RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
                End If
                AddMode = False
                EditMode = False
                UpdateViewData(TargetIdNo)
                ClearAllErrorMessages()
            End If
            Return retVal < 0
        End Function

        Public Overrides Function ChangesMade() As Boolean
            Dim retVal As Boolean = False
            For Each item In View.EmployeeLeaveApprovalItems
                If item.Approve Or item.Disapprove Then
                    retVal = True
                    Exit For
                End If
            Next
            Return retVal
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim valid As Boolean = True
            For Each leave As EmployeeLeaveApprovalItemView In View.EmployeeLeaveApprovalItems
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