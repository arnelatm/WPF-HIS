Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class HolidayTransferPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IHolidayTransferView, HolidayTransferModel)

        Public Sub New(view As IHolidayTransferView)
            MyBase.New(view)
            Service = New AccountsService("HolidayTransfer")
            TableName = "HolidayTransfer"
            SortOrderKey = "Sequence"
            WithTreeView = False
        End Sub

        Public Property ChangesMadeInHolidayTransferm As Boolean = False

        Protected Overrides Sub CreateDataSources()
            Dim filter As String = "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                                   "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                                   "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If IsUserASupervisor() Then
                Dim employeeIdNo As Int32
                employeeIdNo = Service.GetUserEmployeeIdNo()
                filter += " and LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            Dim currentHolidayTransferItems As List(Of HolidayTransferItem) = Service.GetDaoRecords(filter)
            Dim holidayTransferItems As New List(Of HolidayTransferItem)
            Dim holidayTransferItemsModel As New List(Of HolidayTransferItemModel)
            Dim activeEmployeeListModel As New List(Of HolidayTransferItem)
            Dim activeEmployees = Service.GetRecords("Employee", "EmployeeName", "IdNo", "Active=1")
            For Each employee In activeEmployees
                Dim ht = currentHolidayTransferItems.Find(Function(cc As HolidayTransferItem) cc.EmployeeIdNo = employee.IdNo)
                If Not IsNothing(ht) Then
                    holidayTransferItems.Add(ht)
                Else
                    Dim cHt = New HolidayTransferItem
                    cHt.EmployeeIdNo = employee.IdNo
                    holidayTransferItems.Add(cHt)
                End If
            Next
            GlobalVariables.Mapper.Map(holidayTransferItems, holidayTransferItemsModel)
            GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveList)
            CreateLookupData("Holiday", "HolidayList")
            CreateDataSource("User", "EnteredBy", {"IdNo", "UserName"})
        End Sub

        ''' <summary>
        '''     Displays list of  Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIdNo id to display.</param>
        Public Overloads Sub Display(journalIdNo As Int32)
            View.HolidayTransferItems = Service.GetRecordsWithGroupIdNo(Of HolidayTransferItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       journalIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Service.DelUpdateTvp(dtUpdate, journalIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Service.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

    End Class

End Namespace