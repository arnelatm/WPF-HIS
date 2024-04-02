Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveApprovalPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService
        Private ReadOnly _userHasHrManagerAccess As Boolean
        Private ReadOnly _userHasHrAccess As Boolean
        Private ReadOnly _userIsASupervisor As Boolean
        Private ReadOnly _userIsASuperAdministrator As Boolean

        'Private _holiday As Boolean
        Private _dtEmployeeLeaveApprovalItem As New DataTable

        Public Sub New(view As IEmployeeLeaveApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeaveApproval")
            TableName = "EmployeeLeaveApproval"
            SortOrderKey = "IdNo"
            _userHasHrManagerAccess = UserHasHrManagerAccess()
            _userHasHrAccess = UserHasHrAccess()
            _userIsASupervisor = UserIsASupervisor()
            _userIsASuperAdministrator = UserIsASuperAdministrator()

            view.UserHasHrManagerAccess = _userHasHrManagerAccess
            view.UserHasHrAccess = _userHasHrAccess
            view.UserIsASupervisor = _userIsASupervisor
            view.UserIsASuperAdministrator = _userIsASuperAdministrator
            'AskBeforeSave = True
            'DisableSaveMemento = True
            '_holiday = holiday
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.ApprovalCheckedEvent, AddressOf OnApprovalCheckedEvent
            CreateDataTable(_dtEmployeeLeaveApprovalItem, {{"ApprovalNote", GetType(String)},
                                          {"EmployeeLeaveApprovalIdNo", GetType(Int32)},
                                          {"EmployeeLeaveIdNo", GetType(Int32)},
                                          {"Status", GetType(Int32)}
                                          })
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeVarDataSources({New Object() {"Employee", "EmployeeList", Nothing, Nothing},
                                New Object() {"Leave", "LeaveList", Nothing, Nothing}
                               })

            MakeControlDataSources({New Object() {"User", "ApprovedBy", "IdNo,UserName", Nothing, Nothing}})

            CreateEnumData(Of LeaveStatusSelection)(View.StatusList)
            If _userIsASupervisor Then
                CreateEnumData(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumData(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Overrides Sub EntryFormLoaded()
            Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
            If _userHasHrAccess OrElse _userHasHrManagerAccess OrElse _userIsASuperAdministrator Then
                ' include all records
            ElseIf Not _userIsASupervisor Then
                DataFilter += " ApprovedBy = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString()
            Else
                ' meaning show only the employee's own data
                DataFilter += " and EmployeeIdNo = " & employeeIdNo.ToString()
            End If
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim employeeIdNo As Int32
            View.ApprovedBy = GlobalVariables.UserIdNo
            View.DateCreated = Now()
            employeeIdNo = Service.GetUserEmployeeIdNo()
            Dim filter As String = "Status <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Used) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If _userHasHrAccess OrElse _userHasHrManagerAccess OrElse _userIsASuperAdministrator Then
                'can see all data
            ElseIf _userIsASupervisor Then
                filter += " And Status <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            Dim employeeLeaveApprovalItemsModel As List(Of EmployeeLeaveApprovalItemModel)
            employeeLeaveApprovalItemsModel = Service.GetDaoRecords(Of EmployeeLeaveApprovalItemModel)(filter)
            GlobalVariables.Mapper.Map(employeeLeaveApprovalItemsModel, View.EmployeeLeaveApprovalItems)
            CallByName(View, "BindEmployeeLeaveList", CallType.Method)
        End Sub

        Public Sub CreateApprovalData()
            If Not CancelSave Then
                _dtEmployeeLeaveApprovalItem.Clear()
                For Each leave As IEmployeeLeaveApprovalItemView In View.EmployeeLeaveApprovalItems
                    If leave.Approve Or leave.Disapprove Then
                        Dim workRow As DataRow
                        workRow = _dtEmployeeLeaveApprovalItem.NewRow()
                        workRow("ApprovalNote") = leave.ApprovalNote
                        workRow("EmployeeLeaveIdNo") = leave.IdNo
                        If leave.Approve Then
                            If _userHasHrAccess OrElse _userHasHrManagerAccess OrElse _userIsASuperAdministrator Then
                                workRow("Status") = EnumToCode(LeaveStatusSelection.Approved)
                            Else
                                workRow("Status") = EnumToCode(LeaveStatusSelection.SupervisorApproved)
                            End If
                        Else
                            workRow("Status") = EnumToCode(LeaveStatusSelection.Disapproved)
                        End If
                        _dtEmployeeLeaveApprovalItem.Rows.Add(workRow)
                    End If
                Next
            End If
        End Sub

        Public Overrides Function Save(ByRef viewControl As Control) As Boolean
            Dim retVal As Integer
            Dim record As New EmployeeLeaveApprovalModel
            GlobalVariables.Mapper.Map(Of IEmployeeLeaveApprovalView, EmployeeLeaveApprovalModel)(View, record)
            NewlyAddedRecordIdNo = Service.AddRecord(record)
            If NewlyAddedRecordIdNo > 0 Then
                CreateApprovalData()
                For Each row As DataRow In _dtEmployeeLeaveApprovalItem.Rows
                    row.Item("EmployeeLeaveApprovalIdNo") = NewlyAddedRecordIdNo
                Next row
                retVal = Service.ExecuteTvpSp("InsertEmployeeLeaveApprovalItemTvp", _dtEmployeeLeaveApprovalItem)
            End If
            If retVal < 0 Then
                Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ApplyEarnedLeaves()
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


        Private Sub ApplyEarnedLeaves()
            For Each row As DataRow In _dtEmployeeLeaveApprovalItem.Rows
                Dim employeeLeaveIdNo As Int32 = row.Item("EmployeeLeaveIdNo")
                Dim elm As Object = Service.GetFieldsWithIdNo(employeeLeaveIdNo, "EmployeeLeave", "EmployeeIdNo,LeaveIdNo,NoOfDays")
                Dim elcIdNo As Int32 = Service.GetField(Of Int32, Int32, Int32)(elm.EmployeeIdNo, elm.LeaveIdNo, "EmployeeLeaveCredit", "EmployeeIdNo", "LeaveIdNo", "IdNo")
                Dim accumulatedLeave As Int32 = DirectCast(Service.GetFieldWithIdNo(elcIdNo, "EmployeeLeaveCredit", "AccumulatedLeave"), Decimal)
                Service.GenericUpdateRecordWithIdNo(Of Decimal)(elcIdNo, "EmployeeLeaveCredit", "AccumulatedLeave", accumulatedLeave - elm.NoOfDays)
            Next row
        End Sub

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