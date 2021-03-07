Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenter(Of T As IView, TM As New)
        Inherits CommonPresenter(Of T, TM)

        'Protected Shared Property ModelApOpenInvoice As
        'IModelOpenInvoice
        'Private Property ModelArOpenInvoice ' As IModelOpenInvoice
        'Private Property ModelCashCode ' As IModelCashCode

        Public Sub New(itemView As T)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub Initializer(objectName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
            TableName = objectName
            SortOrderKey = objectName + "Name"
            'If objectName Is Nothing Then
            '    ModelPresenter = New ModelAccounts(objectName)
            'Else
            ModelPresenter = New ModelAccounts(objectName, bizParams, daoParams)
            'Dim t As Type = Type.GetType(presenterModelName)
            'If tableOrViewName Is Nothing Then
            '    ModelPresenter = Activator.CreateInstance(t)
            'Else
            '    'Dim args As Object() = {baseClassName}
            '    'Dim t As Type = Type.GetType(presenterModelName)
            '    ModelPresenter = Activator.CreateInstance(t, tableOrViewName)
            'End If
            OriginalModel = New TM
            DataModel = New TM
            'End If
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Model." + baseClassName + "Model"
            'OriginalModel = Activator.CreateInstance(Type.GetType(presenterModelName))
            'DataModel = Activator.CreateInstance(Type.GetType(presenterModelName))
        End Sub

        Public Overrides Sub InitializerWithTv(baseClassName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, bizParams, daoParams)
            If TreeViewParentIdField IsNot Nothing Then
                SortOrderKey = "SortKey"
            End If
        End Sub

        'Public Sub CheckIfEditable() Handles MyBase.BeforeEdit
        '    Dim type As Type = View.GetType
        '    If type.GetProperty("Posted") IsNot Nothing Then
        '        Dim cPosted = CallByName(View, "Posted", CallType.Get)
        '        If cPosted Then
        '            Messaging.Show(True, "MsgEditingOfPostedRecordNotAllowed", $"This record has already been posted. Edits not allowed!", "Posted Entry")
        '            CancelEdit = True
        '        End If
        '    End If
        'End Sub

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

        Public Function GetSupplierPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        End Function

        Public Function GetSupplierSettlementDiscount(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDiscount")
        End Function

        Public Function GetSupplierSettlementDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDueDays")
        End Function

        Public Function GetCustomerPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "PaymentDueDays")
        End Function

        Public Function GetCustomerSettlementDiscount(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDiscount")
        End Function

        Public Function GetCustomerSettlementDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDueDays")
        End Function

        Public Function IsAccountsPayableAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "AP"
        End Function

        Public Function IsAccountsReceivableAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "AR"
        End Function

        Public Function IsInputVatAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "VI"
        End Function

        Public Function GetAdvancesToSupplierAccountIdNo()
            Return GetRecordFieldWithKey("AS", "Account", "SpecialAccount", "IdNo")
        End Function

        Public Function GetCustomerAdvancesAccountIdNo()
            Return GetRecordFieldWithKey("CA", "Account", "SpecialAccount", "IdNo")
        End Function

        'Public Function GetRegularEarningsByCode()
        '    Return GetRecordFieldWithKey("CA", "Account", "SpecialAccount", "IdNo")
        'End Function

        'Public Function GetRegularDeductionsByCode()
        '    Return GetRecordFieldWithKey("CA", "Account", "SpecialAccount", "IdNo")
        'End Function

        Public Function GetAccount(idNo As String)
            Dim accountModel As New ModelAccounts("Account")
            Return accountModel.GetRecordById(Of AccountModel)(idNo)
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
            Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
            Dim apOpenInvoiceModel As New ApOpenInvoiceModel With {
                    .JournalCode = journalCode,
                    .JournalIdNo = journalItem.JournalIdNo,
                    .JournalItemIdNo = journalItem.IdNo
                    }
            Return modelApOpenInvoice.AddRecord(Of ApOpenInvoiceModel)(apOpenInvoiceModel)
        End Function

        Public Function DeleteApOpenInvoice(ByRef idNo As Int32)
            Dim retVal As Integer = 0
            If idNo <> 0 Then
                Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
                retVal = modelApOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
            End If
            Return retVal
        End Function

        Public Function ArOpenInvoiceExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
            Return Model.CountRecordWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode", "JournalItemIdNo")
        End Function

        Public Function ArCollectionExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
            Dim arOpenInvoiceIdNo As Integer
            arOpenInvoiceIdNo = Model.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
                                                             "JournalItemIdNo", "IdNo")
            Return Model.CountRecordWithKey(arOpenInvoiceIdNo, "CsrOiItem", "ArOpenInvoiceIdNo") > 0
        End Function

        Public Function ApPaymentExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
            Dim apOpenInvoiceIdNo As Integer
            apOpenInvoiceIdNo = Model.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
                                                             "JournalItemIdNo", "IdNo")
            If Model.CountRecordWithKey(apOpenInvoiceIdNo, "CdOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "CkOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "PcOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function DeleteArOpenInvoice(ByRef idNo As Int32) As String
            Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
            If Model.CountRecordWithKey(idNo, "CsrOiItem", "ArOpenInvoiceIdNo") = 0 Then
                Return modelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
            End If
            Return 0
        End Function

        Public Function GetDepositTypeModel() As List(Of DepositTypeModel)
            Dim modelDepositType As New ModelAccounts("DepositType")
            Return modelDepositType.GetAll(Of DepositTypeModel)("DepositTypeName")
        End Function

        Public Function GetIntPhoneCodes(Optional ByVal sortKey As String = "CountryName")
            Return GetLookupData("CountryName", "CountryNameAra", "CountryTelCode", "Country", sortKey, "")
        End Function

        Public Function GetEndingGlBalance(ByVal accountIdNo As Int16, ByVal reconciliationDate As Date) As Decimal
            Return DataModel.GetEndingGlBalance(accountIdNo, reconciliationDate)
        End Function

        Public Function GetAdvancePaymentOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
            Return _
                Model.GetRecordFieldWith2Key(idNo, journalCode, "ApOpenInvoice", "JournalItemIdNo", "JournalCode",
                                             "IdNo")
        End Function

        Public Function GetAdvanceCollectionOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
            Return _
                Model.GetRecordFieldWith2Key(idNo, journalCode, "ArOpenInvoice", "JournalItemIdNo", "JournalCode",
                                             "IdNo")
        End Function

        Public Function UpdateInputVatAmount(journalItems As List(Of IJournalItemView))
            Dim tiVatAmount As Decimal = 0
            Dim inputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatInput)
            For Each item In journalItems
                If item.SpecialAccount = inputVatAccount Then
                    tiVatAmount = tiVatAmount + item.Debit - item.Credit
                End If
            Next
            Return tiVatAmount
        End Function

        Public Function UpdateOutputVatAmount(journalItems As List(Of IJournalItemView))
            Dim toVatAmount As Decimal = 0
            Dim outputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatOutput)
            For Each item In journalItems
                If item.SpecialAccount = outputVatAccount Then
                    toVatAmount = toVatAmount + item.Credit - item.Debit
                End If
            Next
            Return toVatAmount
        End Function

        'Public Sub MakeSpAcctNPayType(journalItems As List(Of IJournalItemView), accountIdNo As Int16, nIndex As Int16)
        '    Dim account As AccountModel
        '    journalItems(nIndex).AccountIdNo = accountIdNo
        '    account = GetAccount(accountIdNo)
        '    journalItems(nIndex).SpecialAccount = account.SpecialAccount
        '    journalItems(nIndex).PayeeType = account.PayeeType
        'End Sub

        Public Sub MakeDebitAmount(journalItem As IJournalItemView, amount As Decimal?)
            If amount Is Nothing OrElse amount >= 0 Then
                journalItem.Credit = 0
            ElseIf amount < 0 Then
                journalItem.Credit = amount * -1
                journalItem.Debit = 0
            End If
        End Sub

        Public Sub MakeCreditAmount(journalItem As IJournalItemView, amount As Decimal?)
            If amount Is Nothing OrElse amount >= 0 Then
                journalItem.Debit = 0
            ElseIf amount < 0 Then
                journalItem.Debit = amount * -1
                journalItem.Credit = 0
            End If
        End Sub

        Public Sub MakePayTypeAndSpecialAccount(journalItem As IJournalItemView, accountIdNo As Int16?)
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

        Public Sub AddNewItemOnBindingSource(Of TS As New)(ByVal e As System.ComponentModel.AddingNewEventArgs, bindingSource As BindingSource, dataGridView As DataGridView)
            e.NewObject = New TS
            ' work around for error on datagrid entry on lastrow please do not remove.
            ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
            ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
            ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
            If dataGridView.Rows.Count = bindingSource.Count Then
                bindingSource.RemoveAt(bindingSource.Count - 1)
            End If
        End Sub

        Protected Function IsChildValid(Of Tcm)(childProperty) As Boolean
            Dim retValue As Boolean = True
            Dim bizObjectList As New List(Of Tcm)
            Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
            Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
            ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
            Dim model As New ModelAccounts(bizName)
            Dim dModel = GlobalVariables.Mapper.Map(childProperty, bizObjectList)
            For Each item In bizObjectList
                If Not model.IsValid(item) Then
                    retValue = False
                    AddToParentError(model.GetBizObjectErrors)
                    Exit For
                End If
            Next
            Return retValue
        End Function

        Public Function GetBizRules(childProperty)
            Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
            Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
            ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
            Dim bModel As New ModelAccounts(bizName)
            Return bModel.GetBizObjectRules()
        End Function

        Public Function GetBizObject(childProperty)
            Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
            Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
            ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
            Dim bModel As New ModelAccounts(bizName)
            Return bModel.DataService.DataBo
        End Function

        Protected Function IsChildValid2(Of Tcm)(bizName, childProperty) As Boolean
            Dim retValue As Boolean = True
            Dim sModel As New List(Of Tcm)
            Dim esModel As New ModelAccounts(bizName)
            Dim dModel = GlobalVariables.Mapper.Map(childProperty, sModel)
            For Each item In sModel
                If Not esModel.IsValid(item) Then
                    retValue = False
                End If
            Next
            If Not retValue Then
                AddToParentError(esModel.GetBizObjectErrors)
            End If
            Return retValue
        End Function

    End Class

End Namespace