Imports System.Data.SqlTypes
Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports Microsoft.Office.Interop.Excel

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveEarnedPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IEmployeeLeaveEarnedView, TM)

        Private ReadOnly _employeeLeaveEarnedService = New AccountsService("EmployeeLeaveEarned")
        Private ReadOnly _userHasHrManagerAccess As Boolean
        Private ReadOnly _userHasHrAccess As Boolean
        Private ReadOnly _userIsASupervisor As Boolean
        Private ReadOnly _userIsASuperAdministrator As Boolean

        Private _hiredDate As Date?
        Private _releasedDate As Date?
        Private _yearsOfService As Int16
        Private _daysAllowedPerYear As Int16
        Private _earliestEarnedLeaveDate As Date


        Public Sub New(view As IEmployeeLeaveEarnedView)
            MyBase.New(view)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableName = "EmployeeLeaveEarned"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _userHasHrManagerAccess = UserHasHrManagerAccess()
            _userHasHrAccess = UserHasHrAccess()
            _userIsASupervisor = UserIsASupervisor()
            _userIsASuperAdministrator = UserIsASuperAdministrator()
            view.UserHasHrManagerAccess = _userHasHrManagerAccess
            view.UserHasHrAccess = _userHasHrAccess
            view.UserIsASupervisor = _userIsASupervisor
            view.UserIsASuperAdministrator = _userIsASuperAdministrator
            AddHandler view.DateValuesChanged, AddressOf OnDateValuesChanged
            AddHandler view.LeaveIdNoChanged, AddressOf OnLeaveIdNoChanged
        End Sub


        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"User", "EnteredBy", "IdNo,UserName", Nothing},
                             New Object() {"User", "ApprovedBy", "IdNo,UserName", Nothing},
                             New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing},
                             New Object() {"Leave", "LeaveIdNo", Nothing, "Earnable = 1"}
                             })
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EmployeeIdNo = GetUserEmployeeIdNo()
            View.EnteredBy = GlobalVariables.UserIdNo
            View.StartDate = GetEarliestLeaveDate()
        End Sub

        Private Function GetEarliestLeaveDate() As Date
            Dim earliestLeaveDate As String = Service.GetRecordFieldWithKey("ERLD", "Setting", "SettingCode", "Value")
            Return CType(earliestLeaveDate, Date)
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                retValue = IsLeaveValid()
            End If
            Return retValue
        End Function

        Private Function IsLeaveValid() As Boolean
            ComputeEmployeeServiceDetails()
            Dim retValue As Boolean
            If Not NoOverlappingDates() Then
                retValue = False
            ElseIf Not StartAndEndDateIsValid() Then
                retValue = False
            ElseIf Not LeaveAllowed() Then
                retValue = False
            Else
                retValue = True
            End If
            Return retValue
        End Function

        Private Function StartAndEndDateIsValid() As Boolean
            If View.StartDate > View.EndDate Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                Return False
            End If
            If _hiredDate Is Nothing Then
                MessageBox.Show("Hired Date for this employee is not entered, please update this employee information before proceeding with this transaction.")
                Return False
            ElseIf View.StartDate < _earliestEarnedLeaveDate Then
                Dim ed As String = Format(_earliestEarnedLeaveDate, "dd/MM/yyyy")
                Dim sd As String = Format(View.StartDate, "dd/MM/yyyy")
                Messaging.ShowPmMessage(True, "MsgValueMustBeGreaterThanOrEqual", {"fieldName1", "Start Date", "fieldValue1", sd, "fieldName2", "'Earliest Earned Leave Date'", "fieldValue2", ed})
                Return False

            ElseIf View.StartDate < _hiredDate Then
                Dim hd As String = Format(CType(_hiredDate, Date), "dd/MM/yyyy")
                Dim sd As String = Format(View.StartDate, "dd/MM/yyyy")
                Messaging.ShowPmMessage(True, "MsgValueMustBeGreaterThanOrEqual", {"fieldName1", "Start Date", "fieldValue1", sd, "fieldName2", "employee hired date", "fieldValue2", hd})
                Return False
            End If
            If _releasedDate IsNot Nothing AndAlso View.EndDate > _releasedDate Then
                Dim rd As String = Format(CType(_releasedDate, Date), "dd/MM/yyyy")
                Dim ed As String = Format(View.EndDate, "dd/MM/yyyy")
                Messaging.ShowPmMessage(True, "MsgValueMustBeLessThan", {"fieldName1", "End Date", "fieldValue1", ed, "fieldName2", "employee released date or today's date", "fieldValue2", rd})
                Return False
            End If
            Return True
        End Function


        Private Function ComputeEmployeeServiceDetails()
            Dim obj As Object = Service.GetFieldsWithIdNo(View.EmployeeIdNo, "Employee", "HiredDate,ReleasedDate")
            _hiredDate = obj.HiredDate
            _releasedDate = obj.ReleasedDate
        End Function

        Private Function GetDaysEarned()
            ComputeEmployeeServiceDetails()
            If View.StartDate Is Nothing Or View.EndDate Is Nothing Then
                Return 0
            End If
            Dim yearsOfServiceFromStartDate As Int16 = GetFloorIntYearDifference(CDate(_hiredDate), CDate(View.StartDate))
            Dim yearsOfServiceFromEndDate As Int16 = GetFloorIntYearDifference(CDate(_hiredDate), CDate(View.EndDate))
            Dim daysAllowedPerYearFromStartDate As Int16 = GetLeaveDaysAllowedPerYear(View.LeaveIdNo, yearsOfServiceFromStartDate)
            Dim daysAllowedPerYearFromEndDate = GetLeaveDaysAllowedPerYear(View.LeaveIdNo, yearsOfServiceFromEndDate)
            Dim totalDaysEarned As Int16 = 0
            Dim noOfYearsInDecimal As Decimal = 0D
            If daysAllowedPerYearFromStartDate = daysAllowedPerYearFromEndDate Then
                noOfYearsInDecimal = GetDecimalYearDifference(View.StartDate, View.EndDate)
                totalDaysEarned = Math.Floor(noOfYearsInDecimal * daysAllowedPerYearFromStartDate)
            Else
                Dim anniversaryHireDate As Date
                Dim leavesAllowedPerYear As Int16 = 0
                Dim begDate As Date = View.StartDate
                Dim daysAllowed As Int16 = 0
                ' compute days earned for each year 
                For i = yearsOfServiceFromStartDate To yearsOfServiceFromEndDate
                    anniversaryHireDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, begDate))
                    If anniversaryHireDate < View.EndDate Then
                        noOfYearsInDecimal = GetDecimalYearDifference(begDate, anniversaryHireDate)
                    Else
                        noOfYearsInDecimal = GetDecimalYearDifference(begDate, View.EndDate)
                    End If
                    leavesAllowedPerYear = GetLeaveDaysAllowedPerYear(View.LeaveIdNo, i)
                    totalDaysEarned += Math.Floor(noOfYearsInDecimal * leavesAllowedPerYear)
                    begDate = DateAdd(DateInterval.Day, 1, anniversaryHireDate)
                Next
            End If
            Return totalDaysEarned
        End Function

        Private Function LeaveAllowed()
            ComputeEmployeeServiceDetails()
            If View.StartDate Is Nothing Or View.EndDate Is Nothing Then
                Return 0
            End If
            Dim noOfDays As Int16 = DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate))
            Dim retVal As Boolean = True
            Dim minimumDays As Int16 = GetMinimumDays()
            Dim minDaysForLeaves As Int16 = GetMinimumDaysForLeave()

            If noOfDays < minimumDays Then
                MessageBox.Show("Sorry, days between the 'Start Date' and 'End Date' is not enough to avail for earned leaves. There are only " + noOfDays.ToString() + " day(s) between the start and end date. The minimum days in the selected date range should be at least " + minimumDays.ToString("0") + " day(s).")
                retVal = False
            ElseIf View.DaysEarned < minDaysForLeaves Then
                MessageBox.Show("Sorry, 'Leave Days Earned' of " + View.DaysEarned.ToString() + " day(s) is not enough to avail of earned leaves. The minimum days for earned leaves should be at least " + minDaysForLeaves.ToString("0"))
                retVal = False
            End If
            Return retVal
        End Function

        Private Function GetYearsOfService() As Int16
            Return GetFloorIntYearDifference(_hiredDate, View.EndDate)
        End Function

        Private Function GetMinimumDays() As Int16
            Return Service.GetFieldValue(Of Int16)("MinimumDays", "EarnableLeave", _yearsOfService.ToString() + " >= YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function

        Private Function GetMinimumDaysForLeave() As Int16
            Return Service.GetFieldValue(Of Int16)("MinimumDaysForLeave", "EarnableLEave", _yearsOfService.ToString() + " >= YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function


        Private Function GetLeaveDaysAllowedPerYear(leaveIdNo As Int16, yearsOfService As Int16) As Int16
            Dim condition As String = yearsOfService.ToString() + " >= YearsOfServiceStart and " + yearsOfService.ToString() + " < YearsOfServiceEnd " + " and leaveIdNo = " & leaveIdNo.ToString()
            Return Service.GetFieldValue(Of Int16)("LeaveDaysAllowedPerYear", "EarnableLEave", condition)
        End Function


        Private Function NoOverlappingDates() As Boolean
            Dim noOverlap As Boolean = True
            Dim x As DateTime = SqlDateTime.MinValue.Value
            Dim startDate As Date = IIf(View.StartDate < x, x, View.StartDate)
            Dim endDate As Date = IIf(View.EndDate < x, x, View.EndDate)
            Dim overlappingLeave As EmployeeLeaveEarnedModel = _employeeLeaveEarnedService.GetOverlappingEarnedLeave(View.EmployeeIdNo, startDate, endDate, View.LeaveIdNo)
            If overlappingLeave.IdNo > 0 And View.IdNo <> overlappingLeave.IdNo Then
                MessageBox.Show("The applied date for this leave overlaps with an existing leave earned leave application. See Earned Leave Application Number #" & overlappingLeave.IdNo.ToString("N0"))
                noOverlap = False
            End If
            Return noOverlap
        End Function

        Public Sub OnDateValuesChanged()
            ComputeEmployeeServiceDetails()
            If StartAndEndDateIsValid() Then
                If View.EmployeeIdNo <> 0 Then
                    View.DaysEarned = GetDaysEarned()
                End If
            End If
        End Sub

        Public Sub OnLeaveIdNoChanged(leaveIdNo As Int16)
            Dim lastEarnedDate As Date?
            If leaveIdNo <> 0 Then
                If View.StartDate Is Nothing Then
                    lastEarnedDate = Service.GetFieldOnMaxField("EndDate", "EmployeeLeaveEarned", "EndDate", "LeaveIdNo = " & leaveIdNo.ToString() + " and EmployeeIdNo = " + View.EmployeeIdNo.ToString())
                    If lastEarnedDate Is Nothing Then
                        View.StartDate = _hiredDate
                    Else
                        View.StartDate = lastEarnedDate
                    End If
                End If
                If View.EndDate Is Nothing Then
                    View.EndDate = IIf(_releasedDate Is Nothing, Today(), _releasedDate)
                End If
                View.DaysEarned = GetDaysEarned()
            End If
        End Sub

        Public Overrides Sub EntryFormLoaded()
            Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
            If _userHasHrAccess OrElse _userHasHrManagerAccess OrElse _userIsASuperAdministrator Then
                ' no filter these users has no restrictions for viewing all leaves
            ElseIf _userIsASupervisor Then
                ' only supervised employees can be shown
                DataFilter += IIf(DataFilter Is Nothing Or DataFilter = "", "", " and ") + " (SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString() & ")"
            Else
                ' only employee own leaves can be shown
                DataFilter += IIf(DataFilter Is Nothing Or DataFilter = "", "", " and ") + " EmployeeIdNo = " & employeeIdNo.ToString()
            End If
            _earliestEarnedLeaveDate = GetEarliestLeaveDate()
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            If View.ApprovedBy <> 0 Then
                If View.Approved Then
                    Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", Messaging.TranslateCaption(LeaveStatusSelection.Approved.ToString())})
                    CancelEdit = True
                ElseIf View.Disapproved Then
                    Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", Messaging.TranslateCaption(LeaveStatusSelection.Disapproved.ToString())})
                    CancelEdit = True
                End If
            End If
        End Sub

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retVal As Boolean = True
            If MyBase.IsOkToDeleteRecord() Then
                If View.ApprovedBy <> 0 Then
                    If View.Approved Then
                        Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", Messaging.TranslateCaption(LeaveStatusSelection.Approved.ToString())})
                        retVal = False
                    ElseIf View.Disapproved Then
                        Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", Messaging.TranslateCaption(LeaveStatusSelection.Disapproved.ToString())})
                        retVal = False
                    End If
                End If
            Else
                retVal = False
            End If
            Return retVal
        End Function

    End Class

End Namespace