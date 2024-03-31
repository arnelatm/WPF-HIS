Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.BusinessLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports CrystalDecisions.ReportAppServer.DataDefModel

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeavePresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveView, TM)
        'Implements ISubscriber(Of EntryFormLoaded)

        Private _userHasAccess As Boolean = False
        Private _holidayModel As New HolidayModel
        Private _hiredDate As Date?
        Private _releasedDate As Date?
        Private ReadOnly _holidayLeave As Boolean
        Private ReadOnly _holidayService As New AccountsService("Holiday")
        Private ReadOnly _leaveService As New AccountsService("Leave")
        Private ReadOnly _employeeLeaveCreditService = New AccountsService("EmployeeLeaveCredit")
        Private ReadOnly _employeeLeaveService = New AccountsService("EmployeeLeave")


        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As IEmployeeLeaveView, holidayLeave As Boolean)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeave")
            TableBaseName = "EmployeeLeave"
            TableName = "EmployeeLeave_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _holidayLeave = holidayLeave
            View.UserHasHrManagerAccess = UserHasHrManagerAccess()
            View.UserHasHrAccess = UserHasHrAccess()
            View.UserIsASupervisor = UserIsASupervisor()
            AddHandler View.DateValuesChanged, AddressOf OnDateValuesChanged
            AddHandler View.EmployeeIdChanged, AddressOf OnEmployeeIdChanged
            AddHandler View.ComputeNumberOfDays, AddressOf OnComputeNumberOfDays
        End Sub

        Private Sub OnComputeNumberOfDays()
            ComputeEmployeeServiceDetails()
            RecomputeLeaveDays()
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.FullDay = True
            View.EmployeeIdNo = GetUserEmployeeIdNo()
            View.EnteredBy = GlobalVariables.UserIdNo
            View.StartDate = Today()
            View.EndDate = Today()
            View.NoOfDays = 1
        End Sub

        Public Overrides Sub EntryFormLoaded()
            If _holidayLeave Then
                DataFilter = "Holiday = 1"
            Else
                DataFilter = "Holiday = 0"
            End If
            Dim employeeIdNo As Int32 = GetUserEmployeeIdNo()
            If UserHasHrAccess() OrElse UserHasHrManagerAccess() OrElse UserIsASuperAdministrator() Then
                ' no filter
            ElseIf UserIsASupervisor() Then
                View.UserIsASupervisor = True
                DataFilter += " and (SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString() & ")"
            Else
                View.UserIsASupervisor = False
                Dim control As Control = Nothing
                Dim x = MainFieldsDictionary
                If MainFieldsDictionary.TryGetValue("EmployeeIdNo", control) Then
                    CallByName(control, "DisplayOnly", CallType.Set, True)
                End If
                DataFilter += " and EmployeeIdNo = " & employeeIdNo.ToString()
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()

            If UserHasAccess("HumanResources") Then
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
            ElseIf UserIsASupervisor() Then
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                Dim filter As String = "IdNo = " + employeeIdNo.ToString() + " or SupervisorIdNo = " + employeeIdNo.ToString()
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, filter}})
            Else
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, "IdNo = " + employeeIdNo.ToString(), "IdNo"}})
            End If
            MakeControlDataSources({New Object() {"User", "EnteredBy", "IdNo,UserName", Nothing}})
            If _holidayLeave Then
                MakeControlDataSources({New Object() {"Leave", "LeaveIdNo", Nothing, " Holiday = 1"},
                                        New Object() {"Holiday_View", "HolidayIdNo", "IdNo,HolidayName,DateStart", Nothing}})
            Else
                MakeControlDataSources({New Object() {"Leave", "LeaveIdNo", Nothing, " Holiday = 0"}})
            End If
            CreateEnumDataSource(Of LeaveStatusSelection)("Status")
            CreateEnumData(Of LeaveStatusSelection)(View.StatusList)
            MakeVarDataSources({New Object() {"User", "Users", "IdNo,UserName", Nothing, Nothing}})
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If View.Status <> EnumToCode(LeaveStatusSelection.Submitted) Then
                Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", CodeToEnum(Of LeaveStatusSelection)(View.Status).ToString()})
                CancelEdit = True
            ElseIf View.EnteredBy <> GlobalVariables.UserIdNo Then
                If Not UserHasAccess("HumanResources") Then

                    Dim securityKeyMessage = Messaging.TranslateCaption("HumanResources")
                    Dim message = Messaging.GetParametrizedMessage(True, "MsgNoAccessToSecurity", {"securityKey", securityKeyMessage})
                    Messaging.Show(message)
                    CancelEdit = True
                End If
            End If
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            If _holidayLeave Then
                _holidayModel = _holidayService.GetRecordByIdNo(Of HolidayModel)(View.HolidayIdNo)
                View.LeaveIdNo = _holidayModel.LeaveIdNo
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                If Not _holidayLeave Then
                    retValue = IsLeaveValid()
                Else
                    retValue = IsHolidayLeaveValid()
                End If
            End If
            Return retValue
        End Function

        Private Function IsHolidayLeaveValid() As Boolean
            Dim retValue As Boolean = True
            ' check for overlapping dates
            If NoOverlappingDates() Then
                If Not (_holidayModel.DateStart >= View.StartDate AndAlso _holidayModel.DateEnd <= View.EndDate) Then
                    'Look for holidayTransfers
                    Dim noOfDaysInHoliday As Long = DateAndTime.DateDiff(DateInterval.Day, _holidayModel.DateStart, _holidayModel.DateEnd) + 1
                    Dim htService = New AccountsService("HolidayTransferItem")
                    Dim nDays As Long = 0
                    Dim holidayTransfers = htService.GetHolidayTransferItems(View.EmployeeIdNo, View.HolidayIdNo)
                    If holidayTransfers Is Nothing OrElse holidayTransfers.Count() = 0 Then
                        MessageBox.Show($"Sorry you don't have a holiday transfer request for this holiday.")
                        retValue = False
                    Else
                        Dim employeeLeaveModelList = New List(Of EmployeeLeaveModel)
                        Dim employeeLeaveService = New AccountsService("EmployeeLeave")
                        Dim noOfRequestedDays As Short
                        noOfRequestedDays = DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate)) + 1
                        Dim records = employeeLeaveService.GetEmployeeHolidayLeaves(View.EmployeeIdNo, View.HolidayIdNo)
                        If records Is Nothing OrElse records.Count = 0 Then
                            If noOfRequestedDays <= noOfDaysInHoliday Then
                                retValue = True
                            Else
                                MessageBox.Show("Sorry, the number of days applied exceeds the number of days of the holiday.")
                                retValue = False
                            End If
                        Else
                            ' check if no. of days for leave is not yet exceeded
                            Dim noOfAppliedDays As Int32 = 0
                            For Each item In records
                                noOfAppliedDays += DateDiff(DateInterval.Day, CDate(item.StartDate), CDate(item.EndDate)) + 1
                            Next
                            If (noOfAppliedDays + noOfRequestedDays) <= noOfDaysInHoliday Then
                                ' check for overlapping dates
                                retValue = NoOverlappingDates()
                            Else
                                If noOfDaysInHoliday = 1 Then
                                    MessageBox.Show("Sorry there is already an open holiday leave request for this employee and holiday.")
                                Else
                                    MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this holiday or the applied days leave plus the existing leaves will exceed the allotted days for this holiday.")
                                End If
                                retValue = False
                            End If
                        End If
                    End If
                End If
            Else
                retValue = False
            End If
            Return retValue
        End Function

        Private Function IsLeaveValid() As Boolean
            Dim retValue As Boolean = False
            If NoOverlappingDates() Then
                If RequestedLeaveDaysOk() Then
                    retValue = True
                End If
            End If
            Return retValue
            'Dim leaveModel As LeaveModel = _leaveService.GetRecordByIdNo(Of LeaveModel)(View.LeaveIdNo)
            '    If leaveModel.PaidPercent = 0 Then
            '        ' unpaid leaves are always allowed if approved by supervisor subject to maximum allowed leave for this specific leave
            '        If leaveModel.NoMaxLimit Then
            '            'allowed
            '        ElseIf noOfDaysApplied > leaveModel.LeaveAllowed Then
            '            retValue = False
            '            Dim leaveName As String = If(Messaging.IsArabic, leaveModel.LeaveNameAra, leaveModel.LeaveName)
            '            Messaging.ShowPmMessage(True, "MsgApplLvExceedAllowLv", {"leaveName", leaveName,
            '                                                                     "noOfDaysApplied", Format(noOfDaysApplied, "0"),
            '                                                                     "noOfDaysAllowed", Format(leaveModel.LeaveAllowed, "0")})
            '        ElseIf leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
            '            Dim leaveName As String = If(Messaging.IsArabic, leaveModel.LeaveNameAra, leaveModel.LeaveName)
            '            If Not OnceOnlyLeaveOk(leaveModel) Then
            '                retValue = False
            '            End If
            '            'ok 
            '        End If
            '    Else
            '        '    Dim employeeLeaveCreditModel As EmployeeLeaveCreditModel
            '        '    employeeLeaveCreditModel = _employeeLeaveCreditService.GetLeaveCredit(View.EmployeeIdNo, View.LeaveIdNo)
            '        '    Dim noOfRequestedDays As Long = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            '        '    Dim records As New List(Of EmployeeLeaveModel)
            '        '    Dim noOfAppliedDays As Int16 = 0
            '        '    If employeeLeaveCreditModel Is Nothing Then
            '        '        ' use default values
            '        '        Dim noOfDaysAllowed As Long = leaveModel.LeaveAllowed
            '        '        If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
            '        '            If leaveModel.LeaveType = LeaveTypeSelection.ResetsYearly Then
            '        '                ' check if no. of days for leave is not yet exceeded
            '        '                Dim leaveYear As Int16 = Year(View.StartDate)
            '        '                records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear", Year(View.EndDate))
            '        '                For Each item As EmployeeLeaveModel In records
            '        '                    noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '        '                Next
            '        '                If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
            '        '                    retValue = False
            '        '                    MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the existing leaves will exceed the allotted days for this leave.")
            '        '                End If
            '        '            ElseIf leaveModel.LeaveType = LeaveTypeSelection.AsNeeded Then
            '        '                ' always allow as long as leave days doesn't exceed Allowed Days
            '        '                ' unless there are other mitigating circumstances that should be programmed.
            '        '            ElseIf leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
            '        '                If Not OnceOnlyLeaveOk(leaveModel) Then
            '        '                    retValue = False
            '        '                End If
            '        '            End If
            '        '        End If
            '        '    Else
            '        '        If leaveModel.PaidPercent = 0 Then
            '        '            ' unpaid leaves are always allowed if approved by supervisor
            '        '        Else
            '        '            Dim noOfDaysAllowed As Long = employeeLeaveCreditModel.LeaveAllowed
            '        '            If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
            '        '                If leaveModel.LeaveType = LeaveTypeSelection.ResetsYearly Then
            '        '                    ' check if no. of days for leave is not yet exceeded
            '        '                    Dim leaveYear As Int16 = Year(View.StartDate)
            '        '                    If employeeLeaveCreditModel.Cumulative Then
            '        '                        records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "All")
            '        '                        For Each item As EmployeeLeaveModel In records
            '        '                            If item.Status <> EnumToCode(LeaveStatusSelection.Used) Then
            '        '                                noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '        '                            End If
            '        '                        Next
            '        '                    Else
            '        '                        records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear")
            '        '                        For Each item As EmployeeLeaveModel In records
            '        '                            If Year(View.StartDate) = leaveYear Then
            '        '                                noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '        '                            End If
            '        '                        Next
            '        '                    End If
            '        '                    If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
            '        '                        retValue = False
            '        '                        MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the existing leaves will exceed the allotted days for this leave.")
            '        '                    End If
            '        '                ElseIf leaveModel.LeaveType = LeaveTypeSelection.AsNeeded Then
            '        '                    ' always allow as long as leave days doesn't exceed Allowed Days
            '        '                    ' unless there are other mitigating circumstances that should be programmed.
            '        '                ElseIf leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
            '        '                    If Not OnceOnlyLeaveOk(leaveModel) Then
            '        '                        retValue = False
            '        '                    End If
            '        '                End If
            '        '            Else
            '        '                retValue = False
            '        '            End If
            '        '        End If
            '        '    End If
            '        '    retValue = False
            '        'End If
            '        Else
            '    retValue = False
            'End If
            'Return retValue
        End Function

        Private Function OneTimeLeaveOk(leaveModel As LeaveModel)
            Dim records As New List(Of EmployeeLeaveModel)
            Dim retValue As Boolean = True
            records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "All")
            If records.Count <> 0 And records(0).IdNo <> View.IdNo Then
                Dim leaveName As String = If(Messaging.IsArabic, leaveModel.LeaveNameAra, leaveModel.LeaveName)
                Dim leaveIdNo As Int16 = Format(records(0).IdNo, "0")
                If Not (records Is Nothing OrElse records.Count = 0) Then
                    retValue = False
                    Messaging.ShowPmMessage(True, "MsgOneTimeLeaveOnly", {"leaveName", leaveName, "leaveNumber", Format(records(0).IdNo, "0")})
                End If
            End If
            Return retValue
        End Function

        Private Function RequestedLeaveDaysOk() As Boolean
            Dim retVal As Boolean = True
            Dim leaveModel As LeaveModel = _leaveService.GetRecordByIdNo(Of LeaveModel)(View.LeaveIdNo)
            Dim leaveName As String = GetLeaveName(leaveModel)
            Dim noOfDaysApplied As Long = DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate)) + 1
            If noOfDaysApplied > leaveModel.LeaveAllowed Then
                retVal = False
                Messaging.ShowPmMessage(True, "MsgApplLvExceedAllowLv", {"leaveName", leaveName,
                                                                     "noOfDaysApplied", Format(noOfDaysApplied, "0"),
                                                                     "noOfDaysAllowed", Format(leaveModel.LeaveAllowed, "0")})
            End If
            If retVal Then
                If OneTimeLeave(leaveModel) Then
                    If Not OneTimeLeaveOk(leaveModel) Then
                        retVal = False
                    End If
                End If
            End If
            If retVal Then
                If UnPaidLeave(leaveModel) Then
                    ' unpaid leaves are always allowed if approved by supervisor subject to maximum allowed leave for this specific leave
                    Return True
                End If
            End If
            If retVal Then
                If leaveModel.Earnable Then
                    If Not EarnableLeaveOk(leaveModel) Then
                        retVal = False
                    End If
                End If
            End If
            Return retVal


            'Dim employeeLeaveCreditModel As EmployeeLeaveCreditModel
            'employeeLeaveCreditModel = _employeeLeaveCreditService.GetLeaveCredit(View.EmployeeIdNo, View.LeaveIdNo)
            'Dim noOfRequestedDays As Long = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            'Dim records As New List(Of EmployeeLeaveModel)
            'Dim noOfAppliedDays As Int16 = 0
            'If employeeLeaveCreditModel Is Nothing Then
            '    ' use default values
            '    Dim noOfDaysAllowed As Long = leaveModel.LeaveAllowed
            '    If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
            '        If leaveModel.LeaveType = LeaveTypeSelection.ResetsYearly Then
            '            ' check if no. of days for leave is not yet exceeded
            '            Dim leaveYear As Int16 = Year(View.StartDate)
            '            records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear", Year(View.EndDate))
            '            For Each item As EmployeeLeaveModel In records
            '                noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '            Next
            '            If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
            '                retValue = False
            '                MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the existing leaves will exceed the allotted days for this leave.")
            '            End If
            '        ElseIf leaveModel.LeaveType = LeaveTypeSelection.AsNeeded Then
            '            ' always allow as long as leave days doesn't exceed Allowed Days
            '            ' unless there are other mitigating circumstances that should be programmed.
            '        ElseIf leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
            '            If Not OnceOnlyLeaveOk(leaveModel) Then
            '                retValue = False
            '            End If
            '        End If
            '    End If
            'Else
            '    If leaveModel.PaidPercent = 0 Then
            '        ' unpaid leaves are always allowed if approved by supervisor
            '    Else
            '        Dim noOfDaysAllowed As Long = employeeLeaveCreditModel.LeaveAllowed
            '        If RequestedLeaveDaysOk(noOfDaysAllowed, noOfRequestedDays) Then
            '            If leaveModel.LeaveType = LeaveTypeSelection.ResetsYearly Then
            '                ' check if no. of days for leave is not yet exceeded
            '                Dim leaveYear As Int16 = Year(View.StartDate)
            '                If employeeLeaveCreditModel.Cumulative Then
            '                    records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "All")
            '                    For Each item As EmployeeLeaveModel In records
            '                        If item.Status <> EnumToCode(LeaveStatusSelection.Used) Then
            '                            noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '                        End If
            '                    Next
            '                Else
            '                    records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "ActiveYear")
            '                    For Each item As EmployeeLeaveModel In records
            '                        If Year(View.StartDate) = leaveYear Then
            '                            noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
            '                        End If
            '                    Next
            '                End If
            '                If (noOfAppliedDays + noOfRequestedDays) > noOfDaysAllowed Then
            '                    retValue = False
            '                    MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this Leave or the applied days leave plus the existing leaves will exceed the allotted days for this leave.")
            '                End If
            '            ElseIf leaveModel.LeaveType = LeaveTypeSelection.AsNeeded Then
            '                ' always allow as long as leave days doesn't exceed Allowed Days
            '                ' unless there are other mitigating circumstances that should be programmed.
            '            ElseIf leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
            '                If Not OnceOnlyLeaveOk(leaveModel) Then
            '                    retValue = False
            '                End If
            '            End If
            '        Else
            '            retValue = False
            '        End If
            '    End If
            'End If

            'Dim leaveDaysOk As Boolean = True
            'If noOfDaysApplied > noOfDaysAllowed Then
            '    Dim allowedDays As String
            '    Dim leaveName As String
            '    allowedDays = noOfDaysAllowed.ToString("N0")
            '    leaveName = Service.GetFieldWithIdNo(View.LeaveIdNo, "Leave", TranslateFieldName("LeaveName", "Leave"))
            '    Messaging.ShowPmMessage(True, "MsgNotEnoughLeave", {"noOfDaysApplied", noOfDaysApplied, "allowedDays", allowedDays, "leaveName", leaveName})
            '    MessageBox.Show($"Sorry, either you have no more leave credits for this type of leave or the number of days applied exceeds the number of allowed leave days of " & noOfDaysAllowed.ToString("N0") + " day(s)")
            '    leaveDaysOk = False
            'End If
            'Return leaveDaysOk
        End Function

        Private Function GetLeaveName(leaveModel As LeaveModel) As String
            If Messaging.IsArabic Then
                Return leaveModel.LeaveNameAra
            End If
            Return leaveModel.LeaveName
        End Function

        Private Function UnPaidLeave(leaveModel As LeaveModel) As Boolean
            If leaveModel.PaidPercent = 0 Then
                ' unpaid leaves are always allowed if approved by supervisor subject to maximum allowed leave for this specific leave
                'If leaveModel.NoMaxLimit Then
                '    'allowed
                'End If
                Return True
            End If
            Return False
        End Function

        Private Function OneTimeLeave(leaveModel As LeaveModel) As Boolean
            If leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
                Return True
            End If
            Return False
        End Function

        Private Function EarnableLeave(leaveModel As LeaveModel) As Boolean
            Return Service.GetFieldWithIdNo(leaveModel.IdNo, "Leave", "Earnable")
        End Function

        Private Function OneTimeLeaveAllowed(leaveModel As LeaveModel) As Boolean
            If leaveModel.LeaveType = LeaveTypeSelection.OnceOnly Then
                Return True
            End If
            Return False
        End Function

        Private Function EarnableLeaveOk(leaveModel As LeaveModel) As Boolean
            Dim retVal As Boolean = True
            Dim employeeLeaveCreditModel As EmployeeLeaveCreditModel
            employeeLeaveCreditModel = _employeeLeaveCreditService.GetLeaveCredit(View.EmployeeIdNo, View.LeaveIdNo)
            Dim earnedLeaveDays As Long = employeeLeaveCreditModel.AccumulatedLeave
            Dim noOfDaysRequested = DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate)) + 1
            If employeeLeaveCreditModel.IdNo <> 0 Then
                If noOfDaysRequested > earnedLeaveDays Then
                    retVal = False
                    Dim leaveName As String = GetLeaveName(leaveModel)
                    Messaging.ShowPmMessage(True, "MsgNotEnoughEarnedLeave", {"leaveName", leaveName, "noOfDaysRequested", noOfDaysRequested.ToString("0"), "earnedLeaveDays", earnedLeaveDays.ToString("0")}, "", "Error")
                End If
            Else
                retVal = False
                Messaging.Show(True, "MsgNoEarnedLeaves", {"leaveName", GetLeaveName(leaveModel)})
            End If
            If retVal Then
                Dim pendingLeaves As Int32 = GetTotalPendingLeaves(leaveModel, earnedLeaveDays)
                If pendingLeaves > 0 Then
                    If pendingLeaves + noOfDaysRequested > earnedLeaveDays Then
                        retVal = False
                        Messaging.ShowPmMessage(True, "MsgLeavePlusPendingExcess", {"noOfDaysRequested", noOfDaysRequested.ToString("0"), "pendingLeaves", pendingLeaves.ToString("0"), "leaveName", GetLeaveName(leaveModel), "earnedLeaveDays", earnedLeaveDays.ToString("0")})
                    End If
                End If
            End If
            Return retVal
        End Function

        Private Function NoOverlappingDates() As Boolean
            Dim noOverlap As Boolean = True
            Dim overlappingLeave As EmployeeLeaveModel = _employeeLeaveService.GetOverlappingLeave(View.EmployeeIdNo, View.StartDate, View.EndDate)
            If View.IdNo <> overlappingLeave.IdNo And overlappingLeave.IdNo > 0 Then
                MessageBox.Show("The applied date for this leave overlaps with an existing leave application. See Leave Application Number #" & overlappingLeave.IdNo.ToString("N0"))
                noOverlap = False
            End If
            Return noOverlap
        End Function

        Private Function LeaveOverlaps(records As List(Of EmployeeLeaveModel))
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
            If CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeLeaveApprovalItem", "EmployeeLeaveApprovalIdNo") Then
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

        Protected Sub OnAfterChangedRecord() Handles MyBase.AfterChangeRecord
            ComputeEmployeeServiceDetails()
            RecomputeLeaveDays()
        End Sub

        Protected Function ComputeEmployeeServiceDetails()
            If View.EmployeeIdNo > 0 Then
                Dim obj As Object = Service.GetFieldsWithIdNo(View.EmployeeIdNo, "Employee", "HiredDate,ReleasedDate")
                If obj IsNot Nothing Then
                    _hiredDate = obj.HiredDate
                    _releasedDate = obj.ReleasedDate
                End If
            End If
        End Function

        Private Sub OnDateValuesChanged()
            If View.EmployeeIdNo = 0 Then
                If View.StartDate = Date.MinValue Then
                    View.StartDate = Today()
                End If
                If View.EndDate = Date.MinValue Then
                    View.EndDate = Today()
                End If
            Else
                If View.StartDate < _hiredDate Then
                    Messaging.Show(True, "MsgValueMustBeGreaterThanOrEqual", {"fieldName1", "Start Date", "fieldValue1", View.StartDate.ToShortDateString, "fieldName2", "Hire Date", "fieldValue2", CDate(_hiredDate).ToShortDateString()})
                    View.StartDate = _hiredDate
                End If
                If _releasedDate IsNot Nothing Then
                    If View.EndDate > _releasedDate Then
                        Messaging.Show(True, "MsgValueMustBeLessThanOrEqual", {"fieldName1", "End Date", "fieldValue1", View.EndDate.ToShortDateString(), "fieldName2", "Released Date", "fieldValue2", CDate(_releasedDate).ToShortDateString()})
                        View.EndDate = _releasedDate
                    Else
                        If View.EndDate < _hiredDate Then
                            View.EndDate = _releasedDate
                        End If
                    End If
                Else
                    If View.EndDate < _hiredDate Or View.EndDate < View.StartDate Then
                        View.EndDate = Today()
                    End If
                End If
                If View.EndDate < View.StartDate Then
                    View.EndDate = View.StartDate
                End If
            End If
            RecomputeLeaveDays()
        End Sub

        Private Sub RecomputeLeaveDays()
            Try
                View.NoOfDays = DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate)) + 1
            Catch ex As Exception
                MessageBox.Show("Numeric overflow, maximum number of days is only " + Int16.MaxValue.ToString())
                View.NoOfDays = Int16.MaxValue
            End Try
        End Sub

        Private Sub OnEmployeeIdChanged()
            If View.EmployeeIdNo <> 0 Then
                ComputeEmployeeServiceDetails()
                If View.StartDate = Date.MinValue OrElse View.StartDate < _hiredDate Then
                    View.StartDate = _hiredDate
                End If
                If View.EndDate = Date.MinValue OrElse View.EndDate > _releasedDate Then
                    View.EndDate = _releasedDate
                    MessageBox.Show("End Date can't be more than the employee release date!")
                    Beep()
                End If
            End If
        End Sub

        Private Function GetTotalPendingLeaves(leaveModel As LeaveModel, noOfDaysApplied As Int32) As Int32
            ' check all applied leaves not only the currently shown leave, possibly multiple leaves applied for earnable leaves.
            Dim retVal As Boolean = True
            Dim records As New List(Of EmployeeLeaveModel)
            Dim retValue As Boolean = True
            records = _employeeLeaveService.GetEmployeeLeaves(View.EmployeeIdNo, View.LeaveIdNo, "Pending")
            Dim noOfDays As Int32 = 0
            For Each record As EmployeeLeaveModel In records
                If record.IdNo = View.IdNo Then
                    ' do not include the currently shown record
                Else
                    noOfDays += DateDiff(DateInterval.Day, CDate(record.StartDate), CDate(record.EndDate)) + 1
                End If
            Next
            Return noOfDays

        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retVal As Boolean = True
            Dim leaveStatus As LeaveStatusSelection = CodeToEnum(Of LeaveStatusSelection)(View.Status)
            If MyBase.IsOkToDeleteRecord() Then
                If leaveStatus = LeaveStatusSelection.Used OrElse leaveStatus = LeaveStatusSelection.Approved OrElse leaveStatus = LeaveStatusSelection.SupervisorApproved Then
                    Messaging.Show(True, "MsgApprovedOrUsedLeave")
                    retVal = False
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace