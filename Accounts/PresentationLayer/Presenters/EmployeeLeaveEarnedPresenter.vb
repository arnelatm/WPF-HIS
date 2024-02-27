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
            hiredDate = Service.GetFieldWithIdNo(View.EmployeeIdNo, "Employee", "HiredDate")
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
            View.DaysEarned = ComputeDaysEarned(View.StartDate, View.EndDate)
            Return True
        End Function

        Private Function ComputeDaysEarned(startDate, EndDate)
            Dim daysEarned As Int16
            Dim yearsOfService As Int16
            Dim hiredDate As Date = Service.GetFieldWithIdNo(View.IdNo, "HiredDate")
            Dim daysOfService As Decimal = CType(DateAndTime.DateDiff(DateInterval.Day, hiredDate, CDate(View.EndDate)), Decimal)
            yearsOfService = Math.Floor(daysOfService / 365.25 + 1 / 365.25)
            Dim daysAllowedPerYear As Decimal = Service.GetFieldValue("DaysAllowedPerYear", "EarnableLEave", yearsOfService.ToString() + " > YearsOfServiceStart and " + yearsOfService.ToString() + " < YearsOfServiceEnd ")
            daysEarned = Math.Floor(daysOfService / 365.25 * daysAllowedPerYear)
            Return daysEarned
        End Function

        Private Function LeaveAllowed()
            Dim retVal As Boolean
            Dim yearsOfService As Int16
            Dim hiredDate As Date = Service.GetFieldWithIdNo(View.IdNo, "HiredDate")
            Dim daysOfService As Decimal = CType(DateAndTime.DateDiff(DateInterval.Day, hiredDate, CDate(View.EndDate)), Decimal)
            yearsOfService = Math.Floor(daysOfService / 365.25 + 1 / 365.25)
            Dim minimumDaysWorked As Int16 = Service.GetFieldValue("MinimumDaysWorked", "EarnableLEave", yearsOfService.ToString() + " > YearsOfServiceStart and " + yearsOfService.ToString() + " < YearsOfServiceEnd ")
            Dim minimumDaysLeave As Int16 = Service.GetFieldValue("MinimumDaysLeave", "EarnableLEave", yearsOfService.ToString() + " > YearsOfServiceStart and " + yearsOfService.ToString() + " < YearsOfServiceEnd ")
            Dim daysEarned = DateAndTime.DateDiff(DateInterval.Day, CDate(View.StartDate), CDate(View.EndDate))
            If daysEarned < minimumDaysWorked Then
                MessageBox.Show("Sorry, days worked is not enough for to avail of the leave. The minimum days worked should be at least " + minimumDaysWorked.ToString("0"))
                retVal = False
            Else
                retVal = True
            End If
            Return retVal
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


    End Class

End Namespace