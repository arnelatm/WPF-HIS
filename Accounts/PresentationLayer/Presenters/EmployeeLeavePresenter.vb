Imports System.Windows.Forms.VisualStyles
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeavePresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IEmployeeLeaveView, TM)
        'Implements ISubscriber(Of EntryFormLoaded)

        Private _userHasAccess As Boolean = False
        Private _userIsASupervisor As Boolean = False
        Private ReadOnly _holiday As Boolean
        Private ReadOnly _holidayService As New AccountsService("Holiday")
        Private _leaveService As New AccountsService("Leave")
        Private _holidayModel As New HolidayModel

        Public Sub New(itemView As IEmployeeLeaveView, holiday As Boolean)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeave")
            TableName = "EmployeeLeave_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _holiday = holiday
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.FullDay = True
            View.EmployeeIdNo = Service.GetField(Of Int32, Int32)(GlobalVariables.UserIdNo, "User", "IdNo", "EmployeeIdNo")
            View.EnteredBy = GlobalVariables.UserIdNo
            View.StartDate = Today()
            View.EndDate = Today()
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
                    DataFilter = "EmployeeIdNo = " & employeeIdNo.ToString()
                Else
                    DataFilter = "SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString()
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
            If _holiday Then
                CreateDataSource("Leave", "LeaveIdNo", "Holiday = 1")
                CreateDataSource("Holiday_View", "HolidayIdNo", {"IdNo", "HolidayName", "DateStart"})
            Else
                CreateDataSource("Leave", "LeaveIdNo", "Holiday = 0")
            End If
            CreateEnumDataSource(Of LeaveStatusSelection)("LeaveStatus")
            CreateEnumData(Of LeaveStatusSelection)(View.LeaveStatusList)
            CreateLookupData("User", "Users", {"IdNo", "UserName"})
            'CreateEnumDataSource(Of LeaveApprovalSelection)("Approval")
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If View.LeaveStatus <> EnumToCode(LeaveStatusSelection.Submitted) Then
                Messaging.Show(True, "MsgLeaveAlreadyActed", {"approvalAction", CodeToEnum(Of LeaveStatusSelection)(View.LeaveStatus).ToString()})
                CancelEdit = True
            End If
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            If _holiday Then
                _holidayModel = _holidayService.GetRecordByIdNo(Of HolidayModel)(View.HolidayIdNo)
                View.LeaveIdNo = _holidayModel.LeaveIdNo
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                If Not _holiday Then
                    retValue = IsHolidayLeaveValid()
                Else
                    retValue = IsLeaveValid()
                End If
            End If
            Return retValue
        End Function

        Private Function IsHolidayLeaveValid() As Boolean
            Dim retValue As Boolean = False
            If _holidayModel.DateStart >= View.StartDate AndAlso _holidayModel.DateEnd <= View.EndDate Then
                retValue = True
            Else
                'Look for holidayTransfers
                Dim noOfDaysInHoliday As Long = DateAndTime.DateDiff(DateInterval.Day, _holidayModel.DateStart, _holidayModel.DateEnd) + 1
                Dim htService = New AccountsService("HolidayTransferItem")
                Dim nDays As Long = 0
                Dim holidayTransfers = htService.GetHolidayTransferItems(View.EmployeeIdNo, View.HolidayIdNo)
                If holidayTransfers Is Nothing OrElse holidayTransfers.Count() = 0 Then
                    MessageBox.Show($"Sorry you don't have a holiday transfer request for this holiday.")
                Else
                    Dim employeeLeaveModelList = New List(Of EmployeeLeaveModel)
                    Dim employeeLeaveService = New AccountsService("EmployeeLeave")
                    Dim noOfRequestedDays As Short
                    noOfRequestedDays = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
                    Dim records = employeeLeaveService.GetEmployeeHolidayLeaves(View.EmployeeIdNo, View.HolidayIdNo)
                    If records Is Nothing OrElse records.Count = 0 Then
                        retValue = True
                    Else
                        ' check if no. of days for leave is not yet exceeded
                        Dim noOfAppliedDays As Int16 = 0
                        For Each item In records
                            noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
                        Next
                        If (noOfAppliedDays + noOfRequestedDays) <= noOfDaysInHoliday Then
                            ' check for overlapping dates
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
                                MessageBox.Show("The applied date for this holiday leave overlaps with an existing leave application. See Leave Application Number #" & overlapIdNo.ToString("N0"))
                            Else
                                retValue = True
                            End If
                        Else
                            If noOfDaysInHoliday = 1 Then
                                MessageBox.Show("Sorry there is already an open holiday leave request for this employee and holiday.")
                            Else
                                MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this holiday or the applied days leave plus the existing leaves will exceed the allotted days for this holiday.")
                            End If
                        End If
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function IsLeaveValid() As Boolean
            Dim retValue As Boolean = False
            Dim employeeLeaveModelList = New List(Of EmployeeLeaveModel)
            Dim employeeLeaveService = New AccountsService("EmployeeLeave")
            Dim employeeLeaveCreditService = New AccountsService("EmployeeLeaveCredit")
            Dim noOfRequestedDays As Short
            Dim noOfDaysAllowed As Long = DateAndTime.DateDiff(DateInterval.Day, _holidayModel.DateStart, _holidayModel.DateEnd) + 1
            noOfRequestedDays = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            Dim records = employeeLeaveService.GetEmployeeHolidayLeaves(View.EmployeeIdNo, View.HolidayIdNo)
            If records Is Nothing OrElse records.Count = 0 Then
                retValue = True
            Else
                ' check if no. of days for leave is not yet exceeded
                Dim noOfAppliedDays As Int16 = 0
                For Each item In records
                    noOfAppliedDays += DateDiff(DateInterval.Day, item.StartDate, item.EndDate) + 1
                Next
                If (noOfAppliedDays + noOfRequestedDays) <= noOfDaysAllowed Then
                    ' check for overlapping dates
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
                        MessageBox.Show("The applied date for this holiday leave overlaps with an existing leave application. See Leave Application Number #" & overlapIdNo.ToString("N0"))
                    Else
                        retValue = True
                    End If
                Else
                    If noOfDaysAllowed = 1 Then
                        MessageBox.Show("Sorry there is already an open holiday leave request for this employee and holiday.")
                    Else
                        MessageBox.Show("Sorry either this employee has already consumed the allotted leave days for this holiday or the applied days leave plus the existing leaves will exceed the allotted days for this holiday.")
                    End If
                End If
            End If
            Return retValue
        End Function

    End Class

End Namespace