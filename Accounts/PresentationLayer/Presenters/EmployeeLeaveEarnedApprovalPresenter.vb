Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveEarnedApprovalPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveEarnedApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        'Private _holiday As Boolean
        Private _dtEmployeeLeaveEarnedApproval As New DataTable

        Public Sub New(view As IEmployeeLeaveEarnedApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeaveEarnedApproval")
            TableName = "EmployeeLeaveEarnedApproval"
            SortOrderKey = "IdNo"
            CreateDataTable(_dtEmployeeLeaveEarnedApproval, {{"ApprovalNote", GetType(String)},
                                          {"EmployeeLeaveEarnedApprovalIdNo", GetType(Int32)},
                                          {"EmployeeLeaveIdNo", GetType(Int32)},
                                          {"Status", GetType(Int32)}
                                          })
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeVarDataSources({New String() {"Employee", "EmployeeList", Nothing, Nothing},
                                New String() {"Leave", "LeaveList", Nothing, Nothing}
                               })

            MakeControlDataSources({New String() {"User", "ApprovedBy", "IdNo,UserName", Nothing, Nothing}})

            CreateEnumDataT(Of LeaveStatusSelection)(View.StatusList)
            If IsUserASupervisor() Then
                CreateEnumDataT(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumDataT(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.ApprovedBy = GlobalVariables.UserIdNo
            View.DateCreated = Now()
            Dim filter As String = "Status <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Used) + "' and " &
                         "Status <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If IsUserASupervisor() Then
                Dim employeeIdNo As Int32
                employeeIdNo = Service.GetUserEmployeeIdNo()
                filter += " and Status <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            Dim EmployeeLeaveEarnedApprovalItemsModel As List(Of EmployeeLeaveEarnedApprovalItemModel)
            EmployeeLeaveEarnedApprovalItemsModel = Service.GetDaoRecords(Of EmployeeLeaveEarnedApprovalItemModel)(filter)
            GlobalVariables.Mapper.Map(EmployeeLeaveEarnedApprovalItemsModel, View.EmployeeLeaveEarnedApprovalItems)
            CallByName(View, "BindEmployeeLeaveList", CallType.Method)
        End Sub

        Public Sub CreateApprovalData()
            If Not CancelSave Then
                _dtEmployeeLeaveEarnedApproval.Clear()
                For Each leave As IEmployeeLeaveEarnedApprovalItemView In View.EmployeeLeaveEarnedApprovalItems
                    If leave.Approve Or leave.Disapprove Then
                        Dim workRow As DataRow
                        workRow = _dtEmployeeLeaveEarnedApproval.NewRow()
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
                        _dtEmployeeLeaveEarnedApproval.Rows.Add(workRow)
                    End If
                Next
            End If
        End Sub

        Public Overrides Function Save(ByRef viewControl As Control) As Boolean
            Dim retVal As Integer
            Dim record As New EmployeeLeaveEarnedApprovalModel
            GlobalVariables.Mapper.Map(Of IEmployeeLeaveEarnedApprovalView, EmployeeLeaveEarnedApprovalModel)(View, record)
            Dim _userHasHrManagerAccess As Boolean = False
            If UserHasAccess("HumanResourcesManager") Then
                _userHasHrManagerAccess = True
            End If
            NewlyAddedRecordIdNo = Service.AddRecord(record)
            If NewlyAddedRecordIdNo > 0 Then
                CreateApprovalData()
                For Each row As DataRow In _dtEmployeeLeaveEarnedApproval.Rows
                    row.Item("EmployeeLeaveEarnedApprovalIdNo") = NewlyAddedRecordIdNo
                Next row
                retVal = Service.ExecuteTvpSp("InsertEmployeeLeaveEarnedApprovalItemTvp", _dtEmployeeLeaveEarnedApproval)
                If retVal >= 0 And _userHasHrManagerAccess Then
                    Dim leaveCreditDao As New EmployeeLeaveCreditDao
                    Dim leaveDao As New LeaveDao
                    Dim leaveCredit As New EmployeeLeaveCredit
                    For Each employeeLeave As IEmployeeLeaveEarnedApprovalItemView In View.EmployeeLeaveEarnedApprovalItems
                        If employeeLeave.Approve Then
                            Dim idNo As Int32 = Service.GetField(Of Int32, Int32, Int32)(employeeLeave.EmployeeIdNo, employeeLeave.LeaveIdNo, "EmployeeLeaveCredit", "EmployeeIdNo", "LeaveIdNo", "IdNo")
                            If idNo > 0 Then
                                leaveCredit = leaveCreditDao.GetRecordByIdNo(idNo)
                                Dim accumulatedLeave As Decimal = leaveCredit.AccumulatedLeave
                                If leaveCredit.Cumulative Then
                                    Dim earnableDays As Decimal = IIf(employeeLeave.DaysEarned > leaveCredit.MaxCarryOver, leaveCredit.MaxCarryOver, employeeLeave.DaysEarned)
                                    earnableDays = IIf(leaveCredit.NoMaxLimit, earnableDays, IIf(earnableDays + accumulatedLeave > leaveCredit.MaxLimit, leaveCredit.MaxLimit - accumulatedLeave, earnableDays))
                                    Service.UpdateRecordWithIdNo(Of Decimal)(idNo, "EmployeeLeaveCredit", "AccumulatedLeave", accumulatedLeave + earnableDays)
                                Else
                                    Service.UpdateRecordWithIdNo(Of Decimal)(idNo, "EmployeeLeaveCredit", "AccumulatedLeave", employeeLeave.DaysEarned)
                                End If
                            Else
                                Dim seq As Int16 = GetFieldOnMaxField("Sequence", "EmployeeLeaveCredit", "Sequence", "EmployeeIdNo = " & employeeLeave.IdNo.ToString() & " and LeaveidNo = " & employeeLeave.LeaveIdNo.ToString())
                                Dim leave As Leave = leaveDao.GetRecordByIdNo(employeeLeave.LeaveIdNo)
                                leaveCredit.Cumulative = leave.Cumulative
                                leaveCredit.LeaveIdNo = employeeLeave.LeaveIdNo
                                leaveCredit.EmployeeIdNo = employeeLeave.EmployeeIdNo
                                leaveCredit.LeaveAllowed = leave.LeaveAllowed
                                leaveCredit.PaidPercent = leave.PaidPercent
                                leaveCredit.MaxCarryOver = leave.MaxCarryOver
                                leaveCredit.Cumulative = leave.Cumulative
                                leaveCredit.MaxLimit = leave.MaxLimit
                                leaveCredit.NoMaxLimit = leave.NoMaxLimit
                                leaveCredit.Sequence = seq + 1
                                leaveCredit.AccumulatedLeave = employeeLeave.DaysEarned
                                leaveCreditDao.AddRecord(leaveCredit)
                            End If
                        End If
                    Next
                End If
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
            For Each item In View.EmployeeLeaveEarnedApprovalItems
                If item.Approve Or item.Disapprove Then
                    retVal = True
                    Exit For
                End If
            Next
            Return retVal
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim valid As Boolean = True
            For Each leave As EmployeeLeaveEarnedApprovalItemView In View.EmployeeLeaveEarnedApprovalItems
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