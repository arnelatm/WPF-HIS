Imports System.Windows.Forms.VisualStyles
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveEarnedPresenterX(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveEarnedView, TM)
        'Implements ISubscriber(Of EntryFormLoaded)

        Private _userHasAccess As Boolean = False
        Private _userIsASupervisor As Boolean = False
        Private ReadOnly _leaveService As New AccountsService("Leave")
        Private ReadOnly _EmployeeLeaveEarnedCreditService = New AccountsService("EmployeeLeaveEarnedCredit")
        Private ReadOnly _EmployeeLeaveEarnedService = New AccountsService("EmployeeLeaveEarned")


        Public Sub New(itemView As IEmployeeLeaveEarnedView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableBaseName = "EmployeeLeaveEarned"
            TableName = "EmployeeLeaveEarned_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EmployeeIdNo = Service.GetField(Of Int32, Int32)(GlobalVariables.UserIdNo, "User", "IdNo", "EmployeeIdNo")
            View.EnteredBy = GlobalVariables.UserIdNo
            View.StartDate = Today()
            View.EndDate = Today()
            View.DaysEarned = 1
        End Sub

        Public Overrides Sub EntryFormLoaded()
            If UserHasAccess("HumanResources") Then
                _userHasAccess = True
            Else
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                If Not IsUserASupervisor() Then
                    _userIsASupervisor = False
                    Dim control As Control = Nothing
                    Dim x = MainFieldsDictionary
                    If MainFieldsDictionary.TryGetValue("EmployeeIdNo", control) Then
                        CallByName(control, "DisplayOnly", CallType.Set, True)
                    End If
                    DataFilter += " and EmployeeIdNo = " & employeeIdNo.ToString()
                Else
                    DataFilter += " and (SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString() & ")"
                End If
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            If UserHasAccess("HumanResources") Then
                CreateDataSource("Employee", "EmployeeIdNo")
            ElseIf IsUserASupervisor() Then
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                Dim filter As String = "IdNo = " + employeeIdNo.ToString() + " or SupervisorIdNo = " + employeeIdNo.ToString()
                CreateDataSource("Employee", "EmployeeIdNo", filter)
            Else
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                CreateDataSource("Employee", "EmployeeIdNo", "IdNo = " + employeeIdNo.ToString())
            End If
            CreateDataSource("User", "EnteredBy", {"IdNo", "UserName"})
            CreateLookupData("User", "Users", {"IdNo", "UserName"})
            'CreateEnumDataSource(Of LeaveApprovalSelection)("Approval")
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If View.EnteredBy <> GlobalVariables.UserIdNo Then
                If Not UserHasAccess("HumanResources") Then

                    Dim securityKeyMessage = Messaging.TranslateCaption("HumanResources")
                    Dim message = Messaging.GetParametrizedMessage(True, "MsgNoAccessToSecurity", {"securityKey", securityKeyMessage})
                    Messaging.Show(message)
                    CancelEdit = True
                End If
            End If
        End Sub

        Private Function IsHolidayLeaveValid() As Boolean
            Dim retValue As Boolean = True
            '' check for overlapping dates
            'If NoOverlappingDates() Then
            '    If Not (_holidayModel.DateStart >= View.StartDate AndAlso _holidayModel.DateEnd <= View.EndDate) Then
            '        'Look for holidayTransfers
            '        Dim noOfDaysInHoliday As Long = DateAndTime.DateDiff(DateInterval.Day, _holidayModel.DateStart, _holidayModel.DateEnd) + 1
            '        Dim htService = New AccountsService("HolidayTransferItem")
            '        Dim nDays As Long = 0
            '        Dim holidayTransfers = htService.GetHolidayTransferItems(View.EmployeeIdNo, View.HolidayIdNo)
            '        If holidayTransfers Is Nothing OrElse holidayTransfers.Count() = 0 Then
            '            MessageBox.Show($"Sorry you don't have a holiday transfer request for this holiday.")
            '            retValue = False
            '        Else
            '            Dim EmployeeLeaveEarnedModelList = New List(Of EmployeeLeaveEarnedModel)
            '            Dim EmployeeLeaveEarnedService = New AccountsService("EmployeeLeaveEarned")
            '            Dim noOfRequestedDays As Short
            '            noOfRequestedDays = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            '            Dim records = EmployeeLeaveEarnedService.GetEmployeeHolidayLeaves(View.EmployeeIdNo, View.HolidayIdNo)
            '            If records Is Nothing OrElse records.Count = 0 Then
            '                If noOfRequestedDays <= noOfDaysInHoliday Then
            '                    retValue = True
            '                Else
            '                    MessageBox.Show("Sorry, the number of days applied exceeds the number of days of the holiday.")
            '                    retValue = False
            '                End If
            '            Else
            '                ' check if no. of days for leave is not yet exceeded
            '                Dim noOfAppliedDays As Int16 = 0
            '                For Each item In records
            '                    noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '                Next
            '                If (noOfAppliedDays + noOfRequestedDays) <= noOfDaysInHoliday Then
            '                    ' check for overlapping dates
            '                    retValue = NoOverlappingDates()
            '                Else
            '                    If noOfDaysInHoliday = 1 Then
            '                        MessageBox.Show("Sorry there is already an open holiday leave request for this employee and holiday.")
            '                    Else
            '                        MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this holiday or the applied days leave plus the existing leaves will exceed the allotted days for this holiday.")
            '                    End If
            '                    retValue = False
            '                End If
            '            End If
            '        End If
            '    End If
            'Else
            '    retValue = False
            'End If
            Return retValue
        End Function

        'Private Function IsLeaveValid() As Boolean
        '    Dim retValue As Boolean = True
        '    If NoOverlappingDates() Then
        '        Dim leaveModel As LeaveModel = _leaveService.GetRecordByIdNo(Of LeaveModel)(View.LeaveIdNo)
        '        Dim EmployeeLeaveEarnedModel As EmployeeLeaveEarnedModel
        '        'EmployeeLeaveEarnedModel = GetLeaveCreditModel(View.EmployeeIdNo, View.LeaveIdNo, leaveModel)
        '        EmployeeLeaveEarnedModel = _EmployeeLeaveEarnedCreditService.GetLeaveCredit(View.EmployeeIdNo, View.LeaveIdNo)
        '        Dim noOfRequestedDays As Long = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
        '        Dim records As New List(Of EmployeeLeaveEarnedModel)
        '        Dim noOfAppliedDays As Int16 = 0
        '        If EmployeeLeaveEarnedModel Is Nothing Then
        '            ' use default values
        '            Dim noOfDaysAllowed As Long = leaveModel.LeaveAllowed
        '            If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
        '                If leaveModel.LeaveCycle = LeaveCycleSelection.ResetsYearly Then
        '                    ' check if no. of days for leave is not yet exceeded
        '                    Dim leaveYear As Int16 = Year(View.StartDate)
        '                    'If EmployeeLeaveEarnedModel.Cumulative Then
        '                    'no record of accumulated leave treat as non-cumulative
        '                    'End if
        '                    records = _EmployeeLeaveEarnedService.GetEmployeeLeaveEarneds(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear", Year(View.EndDate))
        '                    For Each item As EmployeeLeaveEarnedModel In records
        '                        noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
        '                    Next
        '                    If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
        '                        retValue = False
        '                        MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the existing leaves will exceed the allotted days for this leave.")
        '                    End If
        '                ElseIf leaveModel.LeaveCycle = LeaveCycleSelection.AsNeeded Then
        '                    ' always allow as long as leave days doesn't exceed Allowed Days
        '                    ' unless there are other mitigating circumstances that should be programmed.
        '                ElseIf leaveModel.LeaveCycle = LeaveCycleSelection.OnceOnly Then
        '                    records = _EmployeeLeaveEarnedService.GetEmployeeLeaveEarneds(View.EmployeeIdNo, View.LeaveIdNo, "All")
        '                    If Not OnceOnlyLeaveOk(records) Then
        '                        retValue = False
        '                    End If
        '                End If
        '            End If
        '        Else
        '            Dim noOfDaysAllowed As Long = EmployeeLeaveEarnedModel.AccumulatedLeave
        '            If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
        '                If leaveModel.LeaveCycle = LeaveCycleSelection.ResetsYearly Then
        '                    ' check if no. of days for leave is not yet exceeded
        '                    Dim leaveYear As Int16 = Year(View.StartDate)
        '                    If EmployeeLeaveEarnedModel.Cumulative Then
        '                        records = _EmployeeLeaveEarnedService.GetEmployeeLeaveEarneds(View.EmployeeIdNo, View.LeaveIdNo, "All")
        '                        For Each item As EmployeeLeaveEarnedModel In records
        '                            If item.LeaveStatus = EnumToCode(LeaveStatusSelection.Used) Then
        '                                noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
        '                            End If
        '                        Next
        '                    Else
        '                        records = _EmployeeLeaveEarnedService.GetEmployeeLeaveEarneds(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear")
        '                        For Each item As EmployeeLeaveEarnedModel In records
        '                            If Year(View.StartDate) = leaveYear Then
        '                                noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
        '                            End If
        '                        Next
        '                    End If
        '                    If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
        '                        retValue = False
        '                        MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the used leaves will exceed the allotted days for this leave.")
        '                    End If
        '                ElseIf leaveModel.LeaveCycle = LeaveCycleSelection.AsNeeded Then
        '                    ' always allow as long as leave days doesn't exceed Allowed Days
        '                    ' unless there are other mitigating circumstances that should be programmed.
        '                ElseIf leaveModel.LeaveCycle = LeaveCycleSelection.OnceOnly Then
        '                    records = _EmployeeLeaveEarnedService.GetEmployeeLeaveEarneds(View.EmployeeIdNo, View.LeaveIdNo, "All")
        '                    If Not OnceOnlyLeaveOk(records) Then
        '                        retValue = False
        '                    End If
        '                End If
        '            Else
        '                retValue = False
        '            End If
        '        End If
        '    Else
        '        retValue = False
        '    End If
        '    Return retValue
        'End Function

        Private Function OnceOnlyLeaveOk(records As List(Of EmployeeLeaveEarnedModel))
            Dim retValue As Boolean = True
            If Not (records Is Nothing OrElse records.Count = 0) Then
                ' check if no. of days for leave is not yet exceeded
                retValue = False
                MessageBox.Show("Sorry, you have alredy used this leave.  You can only use this leave once!")
            End If
            Return retValue
        End Function

        'Private Function GetLeaveCreditModel(employeeIdNo As Int32, leaveIdNo As Int16, leaveModel As LeaveModel) As EmployeeLeaveEarnedModel
        '    Dim EmployeeLeaveEarnedModel As EmployeeLeaveEarnedModel
        '    EmployeeLeaveEarnedModel = _EmployeeLeaveEarnedCreditService.GetLeaveCredit(employeeIdNo, leaveIdNo)
        '    If EmployeeLeaveEarnedModel Is Nothing Then
        '        EmployeeLeaveEarnedModel = New EmployeeLeaveEarnedModel
        '        ' get the default values if no leavecredit is avaiable for this employee
        '        EmployeeLeaveEarnedModel.Cumulative = leaveModel.Cumulative
        '        EmployeeLeaveEarnedModel.LeaveAllowed = leaveModel.LeaveAllowed
        '        EmployeeLeaveEarnedModel.LeaveIdNo = leaveModel.IdNo
        '        EmployeeLeaveEarnedModel.MaxCarryOver = leaveModel.MaxCarryOver
        '        EmployeeLeaveEarnedModel.MaxLimit = leaveModel.MaxLimit
        '        EmployeeLeaveEarnedModel.NoMaxLimit = leaveModel.NoMaxLimit
        '        EmployeeLeaveEarnedModel.PaidPercent = leaveModel.PaidPercent
        '        EmployeeLeaveEarnedModel.AccumulatedLeave = leaveModel.LeaveAllowed
        '    End If
        '    Return EmployeeLeaveEarnedModel
        'End Function

        Private Function RequestedLeaveDaysOk(noOfDaysAllowed As Long, noOfRequestedDays As Long) As Boolean
            Dim leaveDaysOk As Boolean = True
            If noOfRequestedDays > noOfDaysAllowed Then
                Messaging.ShowPmMessage(True, "MsgApplLvExceedAllowLv", {"noOfDaysAllowed", noOfDaysAllowed.ToString("N0")})
                leaveDaysOk = False
            End If
            Return leaveDaysOk
        End Function

        'Private Function GetNoOfDaysAllowed(EmployeeLeaveEarnedModel As EmployeeLeaveEarnedModel) As Long
        '    Dim noOfDaysAllowed As Long
        '    If EmployeeLeaveEarnedModel IsNot Nothing Then
        '        If EmployeeLeaveEarnedModel.Cumulative Then
        '            noOfDaysAllowed = EmployeeLeaveEarnedModel.AccumulatedLeave
        '        Else
        '            noOfDaysAllowed = EmployeeLeaveEarnedModel.LeaveAllowed
        '        End If
        '    End If
        '    Return noOfDaysAllowed
        'End Function

        Private Function NoOverlappingDates() As Boolean
            Dim noOverlap As Boolean = True
            Dim overlappingLeave As EmployeeLeaveEarnedModel = _EmployeeLeaveEarnedService.GetOverlappingLeave(View.EmployeeIdNo, View.StartDate, View.EndDate)
            If overlappingLeave.IdNo <> View.IdNo And overlappingLeave.IdNo > 0 Then
                MessageBox.Show("The applied date for this leave overlaps with an existing leave application. See Leave Application Number #" & overlappingLeave.IdNo.ToString("N0"))
                noOverlap = False
            End If
            Return noOverlap
        End Function

        Private Function LeaveOverlaps(records As List(Of EmployeeLeaveEarnedModel))
            Dim retValue As Boolean
            Dim overlappingDates As Boolean = False
            Dim overlapIdNo As Int32 = 0
            For Each item In records
                If View.StartDate >= item.StartDate And View.StartDate <= item.EndDate Then
                    overlappingDates = True
                    overlapIdNo = item.IdNo
                    Exit For
                ElseIf View.EndDate >= item.StartDate And View.EndDate <= item.EndDate Then
                    overlappingDates = True
                    overlapIdNo = item.IdNo
                    Exit For
                End If
            Next
            If overlappingDates Then
                MessageBox.Show("The applied date for this leave overlaps with an existing leave application. See Leave Application Number #" & overlapIdNo.ToString("N0"))
            Else
                retValue = True
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeLeaveEarnedApprovalItem", "EmployeeLeaveEarnedApprovalIdNo") Then
                Return True
                'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PayElementAccount", "PayElementIdNo") Then
                '    Return True
                'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PayElementItem", "PayElementIdNo") Then
                '    Return True
                'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "RecurringPayElement", "PayElementIdNo") Then
                '    Return True
            End If
            Return False
        End Function

    End Class

End Namespace