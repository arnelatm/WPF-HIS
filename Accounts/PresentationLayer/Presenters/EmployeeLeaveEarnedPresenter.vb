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
        Private _hiredDate As Date?
        Private _releasedDate As Date?
        Private _yearsOfService As Int16
        Private _daysAllowedPerYear As Int16

        Public Sub New(itemView As IEmployeeLeaveEarnedView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableName = "EmployeeLeaveEarned"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.DateValuesChanged, AddressOf OnDateValuesChanged
            AddHandler View.LeaveIdNoChanged, AddressOf OnLeaveIdNoChanged
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"User", "EnteredBy", "IdNo,UserName", Nothing},
                             New String() {"Employee", "EmployeeIdNo", Nothing, Nothing},
                             New String() {"Leave", "LeaveIdNo", Nothing, "Earnable = 1"}
                             })
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub


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
            Dim daysAllowedPerYearFromStartDate = GetLeaveDaysAllowedPerYear(yearsOfServiceFromStartDate)
            Dim daysAllowedPerYearFromEndDate = GetLeaveDaysAllowedPerYear(yearsOfServiceFromEndDate)
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
                    leavesAllowedPerYear = GetLeaveDaysAllowedPerYear(i)
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

        Private Function GetMinimumDays()
            Return Service.GetFieldValue(Of Int16)("MinimumDays", "EarnableLeave", _yearsOfService.ToString() + " >= YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function

        Private Function GetMinimumDaysForLeave()
            Return Service.GetFieldValue(Of Int16)("MinimumDaysForLeave", "EarnableLEave", _yearsOfService.ToString() + " >= YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function


        Private Function GetLeaveDaysAllowedPerYear(yearsOfService As Int16)
            Return Service.GetFieldValue(Of Int16)("LeaveDaysAllowedPerYear", "EarnableLEave", yearsOfService.ToString() + " >= YearsOfServiceStart and " + yearsOfService.ToString() + " < YearsOfServiceEnd ")
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

        Public Sub OnDateValuesChanged(idNo As Int16)
            If idNo <> 0 Then
                View.DaysEarned = GetDaysEarned()
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
            If Not IsUserASupervisor() Then
                DataFilter += IIf(DataFilter Is Nothing Or DataFilter = "", "", " and ") + " EmployeeIdNo = " & employeeIdNo.ToString()
            Else
                DataFilter += IIf(DataFilter Is Nothing Or DataFilter = "", "", " and ") + IIf(DataFilter Is Nothing Or DataFilter = "", "", " and ") + " and (SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString() & ")"
            End If
        End Sub


    End Class

End Namespace