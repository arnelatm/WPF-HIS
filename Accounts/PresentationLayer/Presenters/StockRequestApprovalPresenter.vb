Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

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
            Service = New AccountsService("InvTransaction")
            TableName = "InvTransaction"
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
        End Sub


        'Public Overrides Function Save(ByRef viewControl As Control) As Boolean
        '    'Dim retVal As Integer
        '    'Dim record As New InvTransactionModel
        '    'GlobalVariables.Mapper.Map(Of IStockRequestApprovalView, InvTransactionModel)(View, record)
        '    'NewlyAddedRecordIdNo = Service.AddRecord(record)
        '    'If NewlyAddedRecordIdNo > 0 Then
        '    '    CreateApprovalData()
        '    '    For Each row As DataRow In _dtStockRequestApproval.Rows
        '    '        row.Item("StockRequestApprovalIdNo") = NewlyAddedRecordIdNo
        '    '    Next row
        '    '    retVal = Service.ExecuteTvpSp("InsertStockRequestApprovalItemTvp", _dtStockRequestApproval)
        '    'End If
        '    'If retVal < 0 Then
        '    '    MessagingService.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    'Else
        '    '    MessagingService.Show(True, "MsgRecordSuccessfullySaved")
        '    '    If AddMode Then
        '    '        RecordPositionNumber = GetSortedRecordPosition(NewlyAddedRecordIdNo)
        '    '    Else
        '    '        RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
        '    '    End If
        '    '    AddMode = False
        '    '    EditMode = False
        '    '    UpdateViewData(TargetIdNo)
        '    '    ClearAllErrorMessages()
        '    'End If
        '    'Return retVal < 0
        'End Function

        'Public Overrides Function ChangesMade() As Boolean
        '    Dim retVal As Boolean = False
        '    For Each item In View.StockRequestApprovalItems
        '        If item.Approve Or item.Disapprove Then
        '            retVal = True
        '            Exit For
        '        End If
        '    Next
        '    Return retVal
        'End Function

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim valid As Boolean = True
        '    For Each leave As StockRequestApprovalItemView In View.StockRequestApprovalItems
        '        If leave.Disapprove Then
        '            If leave.ApprovalNote Is Nothing OrElse leave.ApprovalNote.Trim() = "" Then
        '                MessagingService.Show(True, "MsgEmptyApprovalNote", {"leaveNumber", leave.IdNo.ToString()})
        '                valid = False
        '            End If
        '        End If
        '    Next
        '    Return valid
        'End Function

    End Class

End Namespace