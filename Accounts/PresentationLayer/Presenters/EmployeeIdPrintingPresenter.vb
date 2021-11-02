Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeIdPrintingPresenter(Of TM As New)
        Inherits TransactionsPresenterNew(Of IEmployeeView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        Public Sub New(view As IEmployeeIdPrintingView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("Employee")
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            'Dim djArgs = {"CdJournalItem_View", "", "InsertCdJournalItemTVP"}
            '_journalItemService = New AccountsService("JournalItem", Nothing, djArgs)
            'djArgs = {"CdJournalItem_View", "UpdateEmployeeIdsTVP", ""}
            '_EmployeeIdsService = New AccountsService("PcClosingJournal", Nothing, djArgs)

            AskBeforeSave = True

            'AddHandler view.EmployeeIdCheckedEvent, AddressOf OnEmployeeIdCheckedEvent
            'AddHandler view.ClearAllEmployeeId, AddressOf OnClearAllEmployeeId

        End Sub

        'Private Sub OnEmployeeIdCheckedEvent(sender As Object)
        '    If EditMode Or AddMode Then
        '        If sender.PcClosed Then
        '            View.Amount -= sender.Amount
        '        Else
        '            View.Amount += sender.Amount
        '        End If
        '        sender.PcClosed = Not sender.PcClosed
        '    End If
        'End Sub

        'Public Sub GetOpenPettyCash()
        '    Dim modelData As List(Of PcClosingJournalModel)
        '    modelData = Service.GetOpenPettyCash()
        '    View.PcClosingJournals = New List(Of PcClosingJournalView)
        '    GlobalVariables.Mapper.Map(modelData, View.PcClosingJournals)
        'End Sub

        'Private Sub OnClearAllEmployeeId(ByVal bsPcClosingJournal As BindingSource, clear As Boolean)
        '    Dim total As Decimal = 0
        '    For Each item In bsPcClosingJournal
        '        item.PcClosed = clear
        '        If clear Then
        '            total += item.Amount
        '        End If
        '    Next item
        '    View.Amount = total
        '    View.Applied = total
        'End Sub

        'Public Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    AddMode = True
        '    If DtInsertTable IsNot Nothing Then
        '        DtInsertTable.Clear()
        '    End If
        '    Dim nRowCount As Int16 = 1
        '    CreateJournalItems()
        '    Dim workRow As DataRow
        '    For Each dataView In View.JournalItems
        '        Dim idNo As Integer = dataView.IdNo
        '        workRow = DtInsertTable.NewRow()
        '        workRow("Sequence") = nRowCount
        '        workRow("AccountIdNo") = dataView.AccountIdNo
        '        workRow("Credit") = dataView.Credit
        '        workRow("Debit") = dataView.Debit
        '        workRow("JournalIdNo") = View.IdNo
        '        workRow("Notes") = dataView.Notes
        '        workRow("RevCostCenteridNo") = dataView.RevCostCenterIdNo
        '        DtInsertTable.Rows.Add(workRow)
        '        nRowCount += 1
        '    Next
        '    workRow = Nothing
        '    For Each dataView In View.PcClosingJournals
        '        If dataView.PcClosed Then
        '            Dim idNo As Integer = dataView.IdNo
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("CdJournalIdNo") = View.IdNo
        '            workRow("IdNo") = dataView.IdNo
        '            workRow("PcClosed") = True
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '    Next
        '    View.PcClosed = True
        'End Sub

        'Public Sub CreateJournalItems()
        '    View.JournalItems = New List(Of JournalItemView)
        '    Dim x = New JournalItemView
        '    x.AccountIdNo = View.AccountIdNo
        '    x.Credit = View.Amount
        '    x.Debit = 0
        '    x.Notes = ""
        '    x.Sequence = 1
        '    x.JournalIdNo = 0
        '    View.JournalItems.Add(x)
        '    x = New JournalItemView
        '    x.AccountIdNo = View.PcAccountIdNo
        '    x.Credit = 0
        '    x.Debit = View.Amount
        '    x.Notes = ""
        '    x.Sequence = 2
        '    x.JournalIdNo = 0
        '    View.JournalItems.Add(x)
        'End Sub

        'Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        '    Dim passedValue As Integer
        '    passedValue = retVal
        '    For Each row As DataRow In DtInsertTable.Rows
        '        row.Item("JournalIdNo") = passedValue
        '    Next
        '    retVal = _journalItemService.InsertTvp(DtInsertTable)
        '    If retVal >= 0 Then
        '        retVal = _EmployeeIdsService.DelUpdateTvp(DtUpdateTable, passedValue)
        '    End If
        '    If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
        '        View.IdNo = passedValue
        '        retVal = UpdateGlReferenceNumber()
        '    End If
        'End Sub

        'Public Function UpdateGlReferenceNumber() As String
        '    Dim retValue As String
        '    Dim dataModel As New TM
        '    GlobalVariables.Mapper.Map(View, dataModel)
        '    retValue = Service.UpdateGlReferenceNumber(dataModel)
        '    Return retValue
        'End Function

        'Public ReadOnly Property PcAccountCount As Int16
        '    Get
        '        Dim specialAccount As String
        '        specialAccount = EnumToCode(SpecialAccountSelection.PettyCashAccount)
        '        Return Service.CountRecordWithKey(specialAccount, "Account", "SpecialAccount")
        '    End Get
        'End Property

        'Public ReadOnly Property DefaultPcAccount As Int16
        '    Get
        '        Dim retVal As String = Nothing
        '        If View.PcAccountIdNo Is Nothing Or View.PcAccountIdNo <= 0 Then
        '            If PcAccountCount >= 1 Then
        '                retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.PettyCashAccount), "Account", "SpecialAccount", "IdNo")
        '            Else
        '                Return 0
        '            End If
        '        End If
        '        If retVal Is Nothing Then
        '            Return 0
        '        End If
        '        Return CInt(retVal)
        '    End Get
        'End Property

    End Class

End Namespace