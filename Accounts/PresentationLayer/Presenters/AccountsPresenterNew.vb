Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AutoMapper
Imports Telerik.WinControls.UI

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenterNew(Of TV As AATM.PresentationLayer.Views.IView, TM As New)
        Inherits CommonPresenterNew(Of TV, TM)

        Public Sub New(itemView As AATM.PresentationLayer.Views.IView)
            MyBase.New(itemView)
        End Sub

        Public Function GetDepositTypeModel() As List(Of DepositTypeModel)
            Dim cModel As New DepositTypeModel
            Dim cModelList As New List(Of DepositTypeModel)
            Dim depositTypeService As New AccountsService("DepositType")
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DepositTypeModel)("DepositTypeName", cModel)
            Dim depositType As List(Of DepositType)
            depositType = depositTypeService.GetAll(newSortOrderKey)
            GlobalVariables.Mapper.Map(depositType, cModelList)
            Return cModelList
        End Function

        Public Function GetAccount(idNo As String)
            Dim accountService As New AccountsService("Account")
            Return accountService.GetRecordByIdNo(Of AccountModel)(idNo)
        End Function

        Public Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
            Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
            Dim arOpenInvoiceModel As New ArOpenInvoiceModel With {
                    .JournalCode = journalCode,
                    .JournalIdNo = journalItem.JournalIdNo,
                    .JournalItemIdNo = journalItem.IdNo
                    }
            Return modelArOpenInvoice.AddRecord(Of ArOpenInvoiceModel)(arOpenInvoiceModel)
        End Function

        Public Function AddApOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
            Dim apOpenInvoiceService As New AccountsService("ApOpenInvoice")
            Dim apOpenInvoiceModel As New ApOpenInvoiceModel With {
                    .JournalCode = journalCode,
                    .JournalIdNo = journalItem.JournalIdNo,
                    .JournalItemIdNo = journalItem.IdNo
                    }
            Return apOpenInvoiceService.AddRecord(apOpenInvoiceModel)
        End Function

        Public Function UpdateInputVatAmount(journalItems As List(Of JournalItemView)) As Decimal
            Dim tiVatAmount As Decimal = 0
            Dim inputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatInput)
            For Each item In journalItems
                If item.SpecialAccount = inputVatAccount Then
                    tiVatAmount = tiVatAmount + item.Debit - item.Credit
                End If
            Next
            Return tiVatAmount
        End Function

        Public Function UpdateOutputVatAmount(journalItems As List(Of JournalItemView))
            Dim toVatAmount As Decimal = 0
            Dim outputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatOutput)
            For Each item In journalItems
                If item.SpecialAccount = outputVatAccount Then
                    toVatAmount = toVatAmount + item.Credit - item.Debit
                End If
            Next
            Return toVatAmount
        End Function

        Public Sub MakeDebitAmount(journalItem As JournalItemView, amount As Decimal?)
            If amount Is Nothing OrElse amount >= 0 Then
                journalItem.Credit = 0
            ElseIf amount < 0 Then
                journalItem.Credit = amount * -1
                journalItem.Debit = 0
            End If
        End Sub

        Public Sub MakeCreditAmount(journalItem As JournalItemView, amount As Decimal?)
            If amount Is Nothing OrElse amount >= 0 Then
                journalItem.Debit = 0
            ElseIf amount < 0 Then
                journalItem.Debit = amount * -1
                journalItem.Credit = 0
            End If
        End Sub

        Public Sub MakePayTypeAndSpecialAccount(journalItem As JournalItemView, accountIdNo As Int16?)
            Dim account As AccountModel
            If accountIdNo Is Nothing Or accountIdNo <= 0 Then
                journalItem.JournalIdNo = 0
                journalItem.SpecialAccount = Nothing
                journalItem.PayeeType = Nothing
            Else
                account = GetAccount(accountIdNo)
                journalItem.AccountIdNo = accountIdNo
                journalItem.SpecialAccount = account.SpecialAccount
                journalItem.PayeeType = account.PayeeType
            End If
        End Sub

        'Public Sub AddNewItemOnBindingSource(Of TS As New)(ByVal e As System.ComponentModel.AddingNewEventArgs, bindingSource As BindingSource, dataGridView As DataGridView) Implements IAccountsPresenter.AddNewItemOnBindingSource
        '    e.NewObject = New TS
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If dataGridView.Rows.Count = bindingSource.Count Then
        '        bindingSource.RemoveAt(bindingSource.Count - 1)
        '    End If
        'End Sub

        'Public Function GetBizRules(childProperty) Implements IAccountsPresenter.GetBizRules
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim bModel As New ModelAccounts(bizName)
        '    Return bModel.GetBizObjectRules()
        'End Function

        'Public Function GetBizObject(childProperty) Implements IAccountsPresenter.GetBizObject
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim bModel As New ModelAccounts(bizName)
        '    Return bModel.DataService.DataBo
        'End Function

        'Public Function ValidateDataBoundGrid(Of TMG As New)(viewProperty As Object, dataGridView As DataGridView, dictionary As Dictionary(Of String, Object), Optional tabPage As TabPage = Nothing) Implements IAccountsPresenter.ValidateDataBoundGrid
        '    Dim errorFound As Boolean = False
        '    Dim rules = GetBizRules(viewProperty)
        '    Dim bo = GetBizObject(viewProperty)
        '    For Each rule In rules
        '        For Each col In dataGridView.Columns()
        '            Dim colName = col.DataPropertyName
        '            If rule.Property = colName Then
        '                For Each row As DataGridViewRow In dataGridView.Rows
        '                    Dim model As New TMG
        '                    If row.Index() >= 0 AndAlso row.Index() < dataGridView.RowCount() - 1 Then
        '                        GlobalVariables.Mapper.Map(viewProperty(row.Index()), model)
        '                        GlobalVariables.Mapper.Map(model, bo)
        '                        If Not bo.IsRuleValid(rule) Then
        '                            Dim obj As New Object
        '                            dictionary.TryGetValue(rule.Property, obj)
        '                            row.Cells(obj.Name).ErrorText = rule.Error
        '                            errorFound = True
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        Next
        '    Next
        '    If errorFound Then
        '        If tabPage IsNot Nothing Then
        '            tabPage.ImageIndex = 0
        '        Else
        '            tabPage.ImageIndex = -1
        '        End If
        '    Else
        '        If tabPage IsNot Nothing Then
        '            tabPage.ImageIndex = -1
        '        End If
        '    End If
        '    Return Not errorFound
        'End Function

        Protected Sub New()
            MyBase.New()
        End Sub

        'Protected Function IsChildValid2(Of Tcm)(bizName, childProperty) As Boolean
        '    Dim retValue As Boolean = True
        '    Dim sModel As New List(Of Tcm)
        '    Dim esModel As New ModelAccounts(bizName)
        '    Dim dModel = GlobalVariables.Mapper.Map(childProperty, sModel)
        '    For Each item In sModel
        '        If Not esModel.IsValid(item) Then
        '            retValue = False
        '        End If
        '    Next
        '    If Not retValue Then
        '        AddToParentError(esModel.GetBizObjectErrors)
        '    End If
        '    Return retValue
        'End Function

        Public Sub SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean)
            If IsEmpty(currentVatNumber) Or override Then
                If idNo IsNot Nothing Then
                    Dim supplierVatNumber = GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "VatNumber")
                    currentVatNumber = supplierVatNumber
                Else
                    currentVatNumber = Nothing
                End If
            End If
        End Sub

        'Public Function IsAccountsReceivableAccount(ByVal accountIdNo As Int16)
        '    Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "AR"
        'End Function

        'Public Function IsInputVatAccount(ByVal accountIdNo As Int16)
        '    Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "VI"
        'End Function

        Public Function GetAdvancesToSupplierAccountIdNo()
            Return GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.AdvancesToSupplier), "Account", "SpecialAccount", "IdNo")
        End Function

        Public Function GetAccountTypesList(accountType As String, Optional ByVal sortKey As String = "AccountName")
            Dim values = accountType.Split(",")
            Dim lookupFilterKey = ""
            For Each account In values
                If lookupFilterKey <> "" Then
                    lookupFilterKey = lookupFilterKey + " Or "
                End If
                lookupFilterKey = lookupFilterKey + "SpecialAccount = '" & account & "'"
            Next
            Return GetLookup("Account", sortKey, lookupFilterKey)
        End Function

        'Public Function GetCustomerAdvancesAccountIdNo()
        '    Return GetRecordFieldWithKey("CA", "Account", "SpecialAccount", "IdNo")
        'End Function

        'Public Function ArOpenInvoiceExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Return Model.CountRecordWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode", "JournalItemIdNo")
        'End Function

        'Public Function ArCollectionExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Dim arOpenInvoiceIdNo As Integer
        '    arOpenInvoiceIdNo = Model.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
        '                                                     "JournalItemIdNo", "IdNo")
        '    Return Model.CountRecordWithKey(arOpenInvoiceIdNo, "CsrOiItem", "ArOpenInvoiceIdNo") > 0
        'End Function

        'Public Function GetEndingGlBalance(ByVal accountIdNo As Int16, ByVal reconciliationDate As Date) As Decimal
        '    Return DataModel.GetEndingGlBalance(accountIdNo, reconciliationDate)
        'End Function

        'Public Function GetAdvanceCollectionOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
        '    Return _
        '        Model.GetRecordFieldWith2Key(idNo, journalCode, "ArOpenInvoice", "JournalItemIdNo", "JournalCode",
        '                                     "IdNo")
        'End Function

        'Protected Function IsChildValid(Of Tcm)(childProperty) As Boolean
        '    Dim retValue As Boolean = True
        '    Dim bizObjectList As New List(Of Tcm)
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim model As New ModelAccounts(bizName)
        '    Dim dModel = GlobalVariables.Mapper.Map(childProperty, bizObjectList)
        '    For Each item In bizObjectList
        '        If Not model.IsValid(item) Then
        '            retValue = False
        '            AddToParentError(model.GetBizObjectErrors)
        '            Exit For
        '        End If
        '    Next
        '    Return retValue
        'End Function

    End Class

End Namespace