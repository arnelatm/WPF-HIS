Imports System.Windows.Navigation
Imports System.Data
Imports System.Collections.Generic
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenter(Of TV As AATM.PresentationLayer.Views.IView, TM As New)
        Inherits CommonPresenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As AATM.PresentationLayer.Views.IView)
            MyBase.New(itemView)
        End Sub

        Public Sub CreateSpecialAccountDataSourceT(fieldName As String, specialAccountArray As String())
            Dim filter As String
            filter = Accounts.AccountHelpers.CreateSpecialAccountFilterKey(specialAccountArray)
            MakeControlDataSources({New Object() {"Account", fieldName, Nothing, filter}})
        End Sub

        Public Sub CreateSpecialAccountDataSource(fieldName As String, specialAccountArray As String())
            Dim filter As String
            filter = Accounts.AccountHelpers.CreateSpecialAccountFilterKey(specialAccountArray)
            MakeControlDataSources({New Object() {"Account", fieldName, Nothing, filter}})
        End Sub

        Public Function GetDepositTypeModel() As List(Of DepositTypeModel)
            Dim cModel As New DepositTypeModel
            Dim cModelList As New List(Of DepositTypeModel)
            Dim depositTypeService As New AccountsService("DepositType")
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DepositTypeModel)("DepositTypeName", cModel)
            Dim depositType As List(Of DepositType)
            depositType = depositTypeService.GetList(Of DepositType)(newSortOrderKey)
            GlobalVariables.Mapper.Map(depositType, cModelList)
            Return cModelList
        End Function

        Public Function GetAccount(idNo As String)
            Dim accountService As New AccountsService("Account")
            Return accountService.GetRecordByIdNo(Of AccountModel)(idNo)
        End Function

        Public Function JournalItemPayeesAreValid(journalItems As IEnumerable(Of AATM.Accounts.PresentationLayer.Views.Interfaces.IJournalItemView), payeeDataSource As Object) As Boolean
            If journalItems Is Nothing Then Return True

            Dim payeeRows As DataTable = TryCast(payeeDataSource, DataTable)
            If payeeRows Is Nothing Then
                Dim payeeView As DataView = TryCast(payeeDataSource, DataView)
                If payeeView IsNot Nothing Then payeeRows = payeeView.Table
            End If
            If payeeRows Is Nothing Then
                payeeRows = TryCast(Service.GetDtRecords("Contact_View", "IdNo,CSECode"), DataTable)
            End If

            Dim contactTypes As New Dictionary(Of Int32, String)
            If payeeRows IsNot Nothing AndAlso payeeRows.Columns.Contains("IdNo") AndAlso payeeRows.Columns.Contains("CSECode") Then
                For Each contactRow As DataRow In payeeRows.Rows
                    If Not contactRow.IsNull("IdNo") Then
                        contactTypes(Convert.ToInt32(contactRow("IdNo"))) = Convert.ToString(contactRow("CSECode"))
                    End If
                Next
            End If

            Dim rowNumber As Integer = 0
            For Each item In journalItems
                rowNumber += 1
                If item Is Nothing Then Continue For
                If item.Debit = 0D AndAlso item.Credit = 0D Then Continue For

                Dim lineNumber As Integer = If(item.Sequence > 0, CInt(item.Sequence), rowNumber)
                Dim requiredType As String = GetJournalItemPayeeType(item)

                If Not String.Equals(requiredType, "C", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not String.Equals(requiredType, "S", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not String.Equals(requiredType, "E", StringComparison.OrdinalIgnoreCase) Then Continue For

                If item.PayIdNo <= 0 Then
                    ShowJournalItemPayeeError(item, lineNumber,
                                              "MsgPayeeRequiredForAccount",
                                              "A customer, supplier, or employee must be selected for this account.",
                                              "Payee Required")
                    Return False
                End If

                Dim contactType As String = Nothing
                If Not contactTypes.TryGetValue(item.PayIdNo, contactType) OrElse
                   Not String.Equals(contactType, requiredType, StringComparison.OrdinalIgnoreCase) Then
                    ShowJournalItemPayeeError(item, lineNumber,
                                              "MsgGeneralJournalPayeeMustMatchAccountType",
                                              "The selected contact must match the account payee type.",
                                              "Invalid Payee")
                    Return False
                End If
            Next

            Return True
        End Function

        Private Sub ShowJournalItemPayeeError(item As AATM.Accounts.PresentationLayer.Views.Interfaces.IJournalItemView,
                                              lineNumber As Integer,
                                              messageKey As String,
                                              defaultMessage As String,
                                              defaultCaption As String)
            Dim accountName As String = If(item.AccountName, String.Empty).Trim()
            If accountName = String.Empty Then
                accountName = "Account " & If(item.AccountIdNo.HasValue, item.AccountIdNo.Value.ToString(), String.Empty)
            End If

            Dim lineCaption As String = Messaging.TranslateCaption("Line")
            If String.IsNullOrWhiteSpace(lineCaption) Then lineCaption = "Line"

            Dim message As String = Messaging.GetMessage(True, messageKey)
            If String.IsNullOrWhiteSpace(message) Then message = defaultMessage
            message = String.Format("{0} {1} ({2}): {3}", lineCaption, lineNumber, accountName, message)

            Dim caption As String = Messaging.GetMessageCaption(messageKey)
            If String.IsNullOrWhiteSpace(caption) Then caption = defaultCaption
            Messaging.Show(message, caption)
        End Sub

        Public Function GetJournalItemPayeeType(journalItem As AATM.Accounts.PresentationLayer.Views.Interfaces.IJournalItemView) As String
            If journalItem Is Nothing Then Return Nothing

            'The ledger classification is authoritative for the AP, AR, and
            'employee-loan control accounts, even if an account's PayeeType is
            'configured inconsistently.
            Select Case If(journalItem.SpecialAccount, String.Empty).Trim().ToUpperInvariant()
                Case "AP", "AS", "PD"
                    Return "S"
                Case "AR", "CA", "RD", "SD"
                    Return "C"
                Case "EL"
                    Return "E"
            End Select

            If String.Equals(journalItem.PayeeType, "C", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(journalItem.PayeeType, "S", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(journalItem.PayeeType, "E", StringComparison.OrdinalIgnoreCase) Then
                Return journalItem.PayeeType
            End If

            Return Nothing
        End Function

        Public Sub SetJournalItemPayeesForType(journalItems As IEnumerable(Of AATM.Accounts.PresentationLayer.Views.Interfaces.IJournalItemView),
                                               cseCode As String,
                                               cseIdNo As Integer?,
                                               payeeDataSource As Object)
            If journalItems Is Nothing Then Return

            For Each item In journalItems
                If item Is Nothing OrElse (item.Debit = 0D AndAlso item.Credit = 0D) Then Continue For
                If String.Equals(GetJournalItemPayeeType(item), cseCode, StringComparison.OrdinalIgnoreCase) Then
                    SetJournalItemPayeeIfMissing(item, cseCode, cseIdNo, payeeDataSource)
                End If
            Next
        End Sub

        Public Function GetContactIdNo(cseCode As String, cseIdNo As Integer?, payeeDataSource As Object) As Integer
            If String.IsNullOrWhiteSpace(cseCode) OrElse Not cseIdNo.HasValue OrElse cseIdNo.Value <= 0 Then Return 0

            Dim payeeRows As DataTable = TryCast(payeeDataSource, DataTable)
            If payeeRows Is Nothing Then
                Dim payeeView As DataView = TryCast(payeeDataSource, DataView)
                If payeeView IsNot Nothing Then payeeRows = payeeView.Table
            End If
            If payeeRows Is Nothing OrElse Not payeeRows.Columns.Contains("IdNo") OrElse
               Not payeeRows.Columns.Contains("CSECode") OrElse Not payeeRows.Columns.Contains("CSEIdNo") Then Return 0

            For Each contactRow As DataRow In payeeRows.Rows
                If contactRow.IsNull("IdNo") OrElse contactRow.IsNull("CSEIdNo") OrElse contactRow.IsNull("CSECode") Then Continue For
                If Convert.ToInt32(contactRow("CSEIdNo")) = cseIdNo.Value AndAlso
                   String.Equals(Convert.ToString(contactRow("CSECode")), cseCode, StringComparison.OrdinalIgnoreCase) Then
                    Return Convert.ToInt32(contactRow("IdNo"))
                End If
            Next

            Return 0
        End Function

        Public Sub SetJournalItemPayeeIfMissing(journalItem As AATM.Accounts.PresentationLayer.Views.Interfaces.IJournalItemView,
                                                cseCode As String,
                                                cseIdNo As Integer?,
                                                payeeDataSource As Object)
            If journalItem Is Nothing OrElse journalItem.PayIdNo > 0 Then Return
            journalItem.PayeeType = cseCode
            journalItem.PayIdNo = GetContactIdNo(cseCode, cseIdNo, payeeDataSource)
        End Sub

        Public Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
            Dim arOpenInvoiceService As New AccountsService("ArOpenInvoice")
            Dim arOpenInvoiceModel As New ArOpenInvoiceModel With {
                    .JournalCode = journalCode,
                    .JournalIdNo = journalItem.JournalIdNo,
                    .JournalItemIdNo = journalItem.IdNo
                    }
            Return arOpenInvoiceService.AddRecord(arOpenInvoiceModel)
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
                If journalItem.Credit <> 0 Then
                    journalItem.Credit = 0
                End If
            ElseIf amount < 0 Then
                journalItem.Credit = amount * -1
                If journalItem.Debit <> 0 Then
                    journalItem.Debit = 0
                End If
            End If
        End Sub

        Public Sub MakeCreditAmount(journalItem As JournalItemView, amount As Decimal?)
            If amount Is Nothing OrElse amount > 0 Then
                If journalItem.Debit <> 0 Then
                    journalItem.Debit = 0
                End If
            ElseIf amount < 0 Then
                journalItem.Debit = amount * -1
                If journalItem.Credit <> 0 Then
                    journalItem.Credit = 0
                End If
            End If
        End Sub

        Public Sub MakePayTypeAndSpecialAccount(journalItem As JournalItemView, accountIdNo As Int16?)
            Dim account As AccountModel
            If accountIdNo Is Nothing Or accountIdNo <= 0 Then
                journalItem.JournalIdNo = 0
                journalItem.SpecialAccount = Nothing
                journalItem.PayeeType = Nothing
                journalItem.AccountName = ""
            Else
                account = GetAccount(accountIdNo)
                journalItem.AccountIdNo = accountIdNo
                journalItem.SpecialAccount = account.SpecialAccount
                journalItem.PayeeType = account.PayeeType
                journalItem.AccountName = account.AccountName
            End If
        End Sub

        Public Function UserIsASupervisor()
            Dim employeeIdNo As Int32 = GetUserEmployeeIdNo()
            If employeeIdNo > 0 Then
                Return Service.GetField(Of Boolean, Int32)(employeeIdNo, "Employee", "IdNo", "Supervisor")
            End If
            Return False
        End Function


        Public Function UserIsASuperAdministrator()
            Return GlobalFunctions.UserIsASuperAdmin
        End Function

        Public Function UserHasHrManagerAccess()
            If UserHasAccess("HumanResourcesManager") Then
                Return True
            End If
            Return False
        End Function

        Public Function UserHasHrAccess()
            If UserHasAccess("HumanResources") Then
                Return True
            End If
            Return False
        End Function


        Public Function GetUserEmployeeIdNo() As Int32
            Return Service.GetUserEmployeeIdNo()
        End Function

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

        'Protected Sub New()
        '    MyBase.New()
        'End Sub

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

        Public Function ConvertSpecialAccountsToFilter(accountType As String)
            Dim values = accountType.Split(",")
            Dim lookupFilter = ""
            For Each account In values
                If lookupFilter <> "" Then
                    lookupFilter = lookupFilter + " Or "
                End If
                lookupFilter = lookupFilter + "SpecialAccount = '" & account & "'"
            Next
            Return lookupFilter
        End Function

        Public Function GetApOpenInvoiceNumber(journalItemIdNo As Int32) As Int32
            Dim idNo As Int32
            idNo = Service.GetRecordFieldWith2KeyG(Of String, Int32, Int32)("AP", journalItemIdNo, "ApOpenInvoice", "JournalCode", "JournalItemIdNo", "IdNo")
            Return idNo
        End Function

        Public Function GetArOpenInvoiceNumber(journalItemIdNo As Int32) As Int32
            Dim idNo As Int32
            idNo = Service.GetRecordFieldWith2KeyG(Of String, Int32, Int32)("AR", journalItemIdNo, "ArOpenInvoice", "JournalCode", "JournalItemIdNo", "IdNo")
            Return idNo
        End Function

        Public Function IsAccountsPayableAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = EnumToCode(SpecialAccountSelection.AccountsPayable)
        End Function

        Public Function IsAccountsReceivableAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = EnumToCode(SpecialAccountSelection.AccountsReceivable)
        End Function

        Public Function ReconciledEntriesExist(journalItems As List(Of JournalItemView), journalCode As String) As Boolean
            Dim result As Boolean = False
            Dim reconciledDao = New ReconciledDao
            For Each item In journalItems
                'Dim reconciledData As Reconciled = reconciledDao.GetReconciledItem(JournalCode, item.IdNo)
                If reconciledDao.IsItemReconciled(journalCode, item.IdNo) Then
                    Messaging.Show(True, "MsgEditingOfReconciledNotAllowed")
                    result = True
                    Exit For
                ElseIf reconciledDao.IsItemInLockedReconciliation(journalCode, item.IdNo) Then
                    Messaging.Show(True, "MsgEditingOfReconciliationReviewNotAllowed")
                    result = True
                    Exit For
                End If
            Next
            Return result
        End Function

    End Class

End Namespace
