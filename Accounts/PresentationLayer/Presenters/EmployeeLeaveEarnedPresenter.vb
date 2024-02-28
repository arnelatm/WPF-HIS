Imports System.Data.SqlTypes
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

        Public Sub New(itemView As IEmployeeLeaveEarnedView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableName = "EmployeeLeaveEarned"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.DateValuesChanged, AddressOf onDateValuesChanged
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
            Dim hiredDate As Object
            Dim releasedDate As Object
            Dim dateHired As Date?
            Dim dateReleased As Date?
            hiredDate = GetHiredDate()
            releasedDate = Service.GetFieldWithIdNo(View.EmployeeIdNo, "Employee", "ReleasedDate")
            If hiredDate Is DBNull.Value Or hiredDate Is Nothing Then
                dateHired = Nothing
            Else
                dateHired = hiredDate
            End If
            If releasedDate Is DBNull.Value Or releasedDate Is Nothing Then
                dateReleased = Nothing
            Else
                dateReleased = releasedDate
            End If
            If View.StartDate > View.EndDate Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                Return False
            End If
            If dateHired Is Nothing Then
                MessageBox.Show("Hired Date for this employee is not entered. Cannot save and continue.")
                Return False
            ElseIf View.StartDate < dateHired Then
                Dim hd As String = Format(CType(dateHired, Date), "dd/MM/yyyy")
                Dim sd As String = Format(View.StartDate, "dd/MM/yyyy")
                Messaging.ShowPmMessage(True, "MsgValueMustBeGreaterThan", {"fieldName1", "Start Date", "fieldValue1", sd, "fieldName2", "employee hired date", "fieldValue2", hd})
                Return False
            End If
            If dateReleased IsNot Nothing AndAlso View.EndDate > dateReleased Then
                Dim rd As String = Format(CType(dateReleased, Date), "dd/MM/yyyy")
                Dim ed As String = Format(View.EndDate, "dd/MM/yyyy")
                Messaging.ShowPmMessage(True, "MsgValueMustBeLessThan", {"fieldName1", "End Date", "fieldValue1", ed, "fieldName2", "employee released date or today's date", "fieldValue2", rd})
                Return False
            End If
            Return True
        End Function


        Private _hiredDate As Date
        Private _yearsOfService As Int16
        Private _daysAllowedPerYear As Int16

        Private Function ComputeEmployeeServiceDetails()
            Dim daysOfService As Int16
            _hiredDate = GetHiredDate()
            daysOfService = GetDaysOfService()
            _yearsOfService = ConvertDaysToYearsService(daysOfService)
            _daysAllowedPerYear = GetLeaveDaysAllowedPerYear()
        End Function

        Private Function ComputeDaysEarned(startDate, EndDate)
            ComputeEmployeeServiceDetails()
            Dim daysWorked As Int16
            daysWorked = GetNoOfDays()
            Return GetDaysEarned(daysWorked)
        End Function

        Private Function GetDaysEarned(noOfDays As Int16)
            Return CType(Math.Floor(noOfDays / 365.25 * _daysAllowedPerYear), Int16)
        End Function

        Private Function LeaveAllowed()
            ComputeEmployeeServiceDetails()
            Dim noOfDays As Int16 = GetNoOfDays()
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

        Private Shared Function ConvertDaysToYearsService(daysOfService As Decimal) As Double
            Return Math.Floor(daysOfService / 365.25 + 1 / 365.25)
        End Function

        Private Function GetDaysOfService() As Int16
            If _hiredDate = Date.MinValue Then
                Return 0
            End If
            Return CType(DateAndTime.DateDiff(DateInterval.Day, _hiredDate, CDate(View.EndDate)), Int16)
        End Function

        Private Function GetNoOfDays() As Int16
            Return CType(DateAndTime.DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate)), Decimal)
        End Function

        Private Function GetHiredDate()
            Return CDate(Service.GetFieldWithIdNo(View.EmployeeIdNo, "Employee", "HiredDate"))
        End Function

        Private Function GetMinimumDays()
            Return Service.GetFieldValue(Of Int16)("MinimumDays", "EarnableLeave", _yearsOfService.ToString() + " > YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function

        Private Function GetMinimumDaysForLeave()
            Return Service.GetFieldValue(Of Int16)("MinimumDaysForLeave", "EarnableLEave", _yearsOfService.ToString() + " > YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
        End Function


        Private Function GetLeaveDaysAllowedPerYear()
            Return Service.GetFieldValue(Of Int16)("LeaveDaysAllowedPerYear", "EarnableLEave", _yearsOfService.ToString() + " > YearsOfServiceStart and " + _yearsOfService.ToString() + " < YearsOfServiceEnd ")
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
                View.DaysEarned = ComputeDaysEarned(View.StartDate, View.EndDate)
            End If
        End Sub

    End Class

End Namespace