Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class StockRequestApprovalPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IStockRequestApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        'Private _holiday As Boolean
        Private _dtStockRequestApproval As New DataTable

        Public Sub New(view As IStockRequestApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("StockRequestApproval")
            TableName = "StockRequestApproval"
            SortOrderKey = "IdNo"
            'AskBeforeSave = True
            'DisableSaveMemento = True
            '_holiday = holiday
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.ApprovalCheckedEvent, AddressOf OnApprovalCheckedEvent
            CreateDataTable(_dtStockRequestApproval, {{"ApprovalNote", GetType(String)},
                                          {"StockRequestApprovalIdNo", GetType(Int32)},
                                          {"StockRequestIdNo", GetType(Int32)},
                                          {"Status", GetType(Int32)}
                                          })
        End Sub

        Protected Overrides Sub CreateDataSources()

            'Dim StockRequestList As List(Of StockRequest) = Service.GetDaoRecords(filter)
            'Dim StockRequestListModel As New List(Of StockRequestModel)
            'GlobalVariables.Mapper.Map(StockRequestList, StockRequestListModel)
            'GlobalVariables.Mapper.Map(StockRequestListModel, View.StockRequestApprovalItems)
            CreateLookupData("Employee", "EmployeeList")
            CreateDataSource("User", "ApprovedBy", {"IdNo", "UserName"})
            CreateLookupData("Leave", "LeaveList")
            CreateEnumData(Of LeaveStatusSelection)(View.LeaveStatusList)
            If IsUserASupervisor() Then
                CreateEnumData(Of SupervisorApprovalSelection)(View.ApprovalStatusList)
            Else
                CreateEnumData(Of LeaveApprovalSelection)(View.ApprovalStatusList)
            End If
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.ApprovedBy = GlobalVariables.UserIdNo
            View.DateCreated = Now()
            Dim filter As String = "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Approved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Disapproved) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Used) + "' and " &
                         "LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.Cancelled) + "'"
            If IsUserASupervisor() Then
                Dim employeeIdNo As Int32
                employeeIdNo = Service.GetUserEmployeeIdNo()
                filter += " and LeaveStatus <> '" + EnumToCode(LeaveStatusSelection.SupervisorApproved) + "' and EmployeeIdNo <> " & employeeIdNo.ToString()
                filter += " and SuperVisorIdNo = " + employeeIdNo.ToString()
            End If
            'Dim data As List(Of StockRequestApprovalItem) = Service.GetDaoRecords(filter)
            Dim StockRequestApprovalItemsModel As List(Of InvTransactionDetail)
            StockRequestApprovalItemsModel = Service.GetDaoRecords(Of InvTransactionDetail)(filter)
            'GlobalVariables.Mapper.Map(data, StockRequestApprovalItemsModel)
            GlobalVariables.Mapper.Map(StockRequestApprovalItemsModel, View.StockRequestApprovalItems)
            CallByName(View, "BindStockRequestList", CallType.Method)

            'View.StockRequestApprovalItems = Service.GetDaoRecords(filter)

            'GlobalVariables.Mapper.Map(StockRequestList, StockRequestListModel)
            'GlobalVariables.Mapper.Map(StockRequestListModel, View.StockRequestApprovalItems)
            'View.StockRequestApprovalItems = Service.GetDaoRecords(filter)
        End Sub

        Public Sub CreateApprovalData()
            If Not CancelSave Then
                _dtStockRequestApproval.Clear()
                For Each leave As IStockRequestApprovalItemView In View.StockRequestApprovalItems
                    If leave.Approve Or leave.Disapprove Then
                        Dim workRow As DataRow
                        workRow = _dtStockRequestApproval.NewRow()
                        workRow("ApprovalNote") = leave.ApprovalNote
                        workRow("StockRequestIdNo") = leave.IdNo
                        If leave.Approve Then
                            If IsUserASupervisor() Then
                                workRow("Status") = EnumToCode(LeaveStatusSelection.SupervisorApproved)
                            Else
                                workRow("Status") = EnumToCode(LeaveStatusSelection.Approved)
                            End If
                        Else
                            workRow("Status") = EnumToCode(LeaveStatusSelection.Disapproved)
                        End If
                        _dtStockRequestApproval.Rows.Add(workRow)
                    End If
                Next
            End If
        End Sub

        'Public Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    Dim record As New InvTransactionModel
        '    GlobalVariables.Mapper.Map(Of IStockRequestApprovalView, InvTransactionModel)(View, record)
        '    NewlyAddedRecordIdNo = Service.AddRecord(record)
        '    If NewlyAddedRecordIdNo > 0 Then
        '        CreateApprovalData()
        '        For Each row As DataRow In _dtStockRequestApproval.Rows
        '            row.Item("StockRequestApprovalIdNo") = NewlyAddedRecordIdNo
        '        Next row
        '        retVal = Service.ExecuteTvpSp("InsertStockRequestApprovalItemTvp", _dtStockRequestApproval)
        '    End If

        'End Sub

        Public Overrides Function Save(ByRef viewControl As Control) As Boolean
            'RaiseEvent BeforeSave()
            'Dim record As New TM
            'GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
            'Dim retVal As Integer = InitiateSave()
            'If retVal < 0 Then
            '    Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Else
            '    RaiseEvent AfterSave()
            'End If
            'If retVal < 0 Then
            'Else
            '    Messaging.Show(True, "MsgRecordSuccessfullySaved")
            '    If AddMode Then
            '        RecordPositionNumber = GetSortedRecordPosition(retVal)
            '    Else
            '        RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
            '    End If
            '    AddMode = False
            '    EditMode = False
            '    UpdateViewData(TargetIdNo)
            '    ClearAllErrorMessages()
            'End If
            'Return retVal

            Dim retVal As Integer
            Dim record As New InvTransactionModel
            GlobalVariables.Mapper.Map(Of IStockRequestApprovalView, InvTransactionModel)(View, record)
            NewlyAddedRecordIdNo = Service.AddRecord(record)
            If NewlyAddedRecordIdNo > 0 Then
                CreateApprovalData()
                For Each row As DataRow In _dtStockRequestApproval.Rows
                    row.Item("StockRequestApprovalIdNo") = NewlyAddedRecordIdNo
                Next row
                retVal = Service.ExecuteTvpSp("InsertStockRequestApprovalItemTvp", _dtStockRequestApproval)
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
            For Each item In View.StockRequestApprovalItems
                If item.Approve Or item.Disapprove Then
                    retVal = True
                    Exit For
                End If
            Next
            Return retVal
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim valid As Boolean = True
            For Each leave As StockRequestApprovalItemView In View.StockRequestApprovalItems
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