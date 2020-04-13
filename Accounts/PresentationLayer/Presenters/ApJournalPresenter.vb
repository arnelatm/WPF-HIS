Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AutoMapper

Namespace PresentationLayer.Presenters

    Public Class ApJournalPresenter
        Inherits AccountsPresenter(Of IApJournalView, ApJournalModel)

        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")
        Private ReadOnly _apJournalItemModel As New ModelAccounts("ApJournalItem")
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ApJournal")
            TableName = "ApJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ApJournalModel()
            DataModel = New ApJournalModel
            GlobalVariables.EventAggregator.SubscribeEvent(Me)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim openInvoiceModel As New ApOpenInvoiceModel
            openInvoiceModel.DiscountTaken = journalItem.DiscountTaken
            openInvoiceModel.PaidAmount = journalItem.PaidAmount
            openInvoiceModel.IdNo = journalItem.IdNo
            openInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retValue = _apOpenInvoiceModel.UpdateRecord(Of ApOpenInvoiceModel)(openInvoiceModel)
            Return retValue
        End Function

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(DataModel.ReferenceNo) Then
                UpdateGlReferenceNumber()
            End If
            If AddMode Then
                GoLastRecord()
            End If
        End Sub

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue = False
            If MyBase.DataIsValid() Then
                Dim cPayeeType As String
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.Bank) + "|" + EnumToSpecialAccount(SpecialAccountSelection.Cash) + "|" + EnumToSpecialAccount(SpecialAccountSelection.PettyCashAccount)
                Dim specialAccount As String
                Dim chart As ChartModel
                retValue = True
                For Each item In DataModel.JournalItems
                    chart = GetChart(item.AccountIdNo)
                    specialAccount = chart.SpecialAccount
                    If item.AccountIdNo = 0 Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                        Dim lineNumber As String = item.Sequence.ToString()
                        Dim caption = "Invalid Entry!"
                        Dim message = Messaging.GetMessage(True, "MsgCashAccountsNotAllowed", "Error on line <{lineNumber}>. Cash accounts not allowed for AP Journal Entry.", "Invalid Entry")
                        message = message.Interpolate(Function(x) lineNumber)
                        Messaging.Show(message, caption)
                        retValue = False
                    Else
                        cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                        If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Supplier Then
                            MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Supplier/Vendor accounts allowed for this entry!", item.Sequence))
                            retValue = False
                        End If
                    End If
                Next
            End If
            Return retValue
        End Function

        Public Function SaveChildren(ByVal retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            If AddMode Then
                DataModel.JournalIdNo = retVal
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, DataModel.IdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                insertReturnValue = Model.InsertTvp(DtInsertTable)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Dim newJournalItem As List(Of JournalItemModel)
            If AddMode Then
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(DataModel.IdNo, "Sequence")
                For Each item In newJournalItem
                    If IsAccountsPayableAccount(item.AccountIdNo) Then
                        AddApOpenInvoice(item, "AP")
                    End If
                Next
            Else
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(DataModel.IdNo, "Sequence")
                Dim newItem
                Dim oldItem
                Dim newIsAp
                Dim oldIsAp
                Dim oldJournalItem As List(Of JournalItemModel)
                If Not AddMode Then
                    oldJournalItem = OriginalModel.Journalitems
                Else
                    oldJournalItem = Nothing
                End If
                For Each oldItem In oldJournalItem
                    ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                    ' so no problem on deletion
                    oldIsAp = IsAccountsPayableAccount(oldItem.AccountIdNo)
                    If oldIsAp Then
                        ' this item is AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item was deleted
                            DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                        Else
                            ' item is found
                            newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                ' nothing to do
                            Else
                                ' new is changed from AP to non-AP
                                DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                            End If
                        End If
                    Else
                        ' this item is Non-AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item is deleted just ignore Non-AP
                        Else
                            ' old item still in new
                            newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                AddApOpenInvoice(newItem, "AP")
                            Else
                                ' new is also Non-AP
                                ' nothing to do
                            End If
                        End If
                    End If
                Next
                For Each newItem In newJournalItem
                    newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                    Dim x = newItem.IdNo
                    oldItem = Nothing
                    For Each item In OriginalModel.JournalItems
                        If newItem.IdNo = item.IdNo Then
                            oldItem = item
                            Exit For
                        End If
                    Next
                    'oldItem = OriginalModel.JournalItems.Find(Function(c) c.IdNo = x)
                    If oldItem Is Nothing Then
                        ' this item is new
                        If newIsAp Then
                            ' this new item is an AP
                            AddApOpenInvoice(newItem, "AP")
                        Else
                            ' non - AP nothing to do
                        End If
                    Else
                        ' old item, already taken off in first (oldItem) for-loop
                    End If
                Next
            End If
            Return retVal
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In DataModel.JournalItems
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("JournalIdNo") = DataModel.IdNo
                workRow("Sequence") = nRowCount
                workRow("AccountIdNo") = ji.AccountIdNo
                workRow("Debit") = ji.Debit
                workRow("Credit") = ji.Credit
                workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
                workRow("Notes") = If(ji.Notes, "")
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount = nRowCount + 1
            Next
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            'View.JournalCode = AccountStrings.ApJournalPrefix
            DataModel.TransactionDate = Date.Now()
            DataModel.DueDate = Date.Now()
            DataModel.InvoiceDate = Date.Now()
            DataModel.JournalItems = New List(Of JournalItemModel)
            Dim item As New JournalItemModel With {
                    .JournalIdNo = DataModel.IdNo,
                    .Sequence = 1,
                    .AccountIdNo = Nothing,
                    .Credit = DataModel.Amount,
                    .Debit = 0,
                    .ProfitCenterIdNo = 0,
                    .Notes = ""
                    }
            DataModel.JournalItems.Add(item)
            GlobalVariables.Mapper.Map(DataModel, View)
            View.JournalItems = DataModel.JournalItems
        End Sub

        'Public Sub OnBeforeSave() Handles NewUserRequested
        '    If PresenterObj.AddMode Then
        '        IdNo = passedValue
        '    End If
        '    If DtInsertTable IsNot Nothing Then
        '        DtInsertTable.Clear()
        '    End If
        '    If DtUpdateTable IsNot Nothing Then
        '        DtUpdateTable.Clear()
        '    End If
        '    Dim oldJournalItem As List(Of JournalItemModel)
        '    If Not PresenterObj.AddMode Then
        '        oldJournalItem = PresenterObj.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '    Else
        '        oldJournalItem = Nothing
        '    End If
        '    Dim nRowCount = 1
        '    For Each ji In bsJournalItems
        '        Dim workRow As DataRow
        '        If ji.IdNo <= 0 Then
        '            workRow = DtInsertTable.NewRow()
        '        Else
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("IdNo") = ji.IdNo
        '        End If
        '        workRow("JournalIdNo") = IdNo
        '        workRow("Sequence") = nRowCount
        '        workRow("AccountIdNo") = ji.AccountIdNo
        '        workRow("Debit") = ji.Debit
        '        workRow("Credit") = ji.Credit
        '        workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
        '        workRow("Notes") = If(ji.Notes, "")
        '        If ji.IdNo <= 0 Then
        '            DtInsertTable.Rows.Add(workRow)
        '        Else
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '        nRowCount = nRowCount + 1
        '    Next
        '    PresenterObj.JournalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        '    Dim newJournalItem As List(Of JournalItemModel)
        '    If PresenterObj.AddMode Then
        '        newJournalItem = PresenterObj.JournalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        For Each item In newJournalItem
        '            If PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(item.AccountIdNo) Then
        '                PresenterObj.AddApOpenInvoice(item, "AP")
        '            End If
        '        Next
        '    Else
        '        newJournalItem = PresenterObj.JournalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        Dim newItem
        '        Dim oldItem
        '        Dim newIsAp
        '        Dim oldIsAp
        '        For Each oldItem In oldJournalItem
        '            ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
        '            ' so no problem on deletion
        '            oldIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(oldItem.AccountIdNo)
        '            If oldIsAp Then
        '                ' this item is AP
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item was deleted
        '                    PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                Else
        '                    ' item is found
        '                    newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '                    If newIsAp Then
        '                        ' nothing to do
        '                    Else
        '                        ' new is changed from AP to non-AP
        '                        PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                    End If
        '                End If
        '            Else
        '                ' this item is Non-AP
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item is deleted just ignore Non-AP
        '                Else
        '                    ' old item still in new
        '                    newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '                    If newIsAp Then
        '                        PresenterObj.AddApOpenInvoice(newItem, "AP")
        '                    Else
        '                        ' new is also Non-AP
        '                        ' nothing to do
        '                    End If
        '                End If
        '            End If
        '        Next
        '        For Each newItem In newJournalItem
        '            newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '            oldItem = oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo)
        '            If oldItem Is Nothing Then
        '                ' this item is new
        '                If newIsAp Then
        '                    ' this new item is an AP
        '                    PresenterObj.AddApOpenInvoice(newItem, "AP")
        '                Else
        '                    ' non - AP nothing to do
        '                End If
        '            Else
        '                ' old item, already taken off in first (oldItem) for-loop
        '            End If
        '        Next
        '    End If

        'End Sub

    End Class

End Namespace