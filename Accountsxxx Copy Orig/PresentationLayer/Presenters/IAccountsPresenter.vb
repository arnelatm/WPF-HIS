Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Interface IAccountsPresenter
        Inherits IPresenter

        'Function AddApOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
        'Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
        'Function ApPaymentExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        'Function ArCollectionExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        'Function ArOpenInvoiceExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        Function ComputePayAmount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
        'Function DeleteApOpenInvoice(ByRef idNo As Int32)
        'Function DeleteArOpenInvoice(ByRef idNo As Int32) As String
        'Function GetAccount(idNo As String)
        'Function GetAdvanceCollectionOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
        'Function GetAdvancePaymentOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
        'Function GetAdvancesToSupplierAccountIdNo()
        'Function GetBizObject(childProperty)
        'Function GetBizRules(childProperty)
        'Function GetCustomerAdvancesAccountIdNo()
        'Function GetCustomerPaymentDueDays(idNo As String)
        'Function GetCustomerSettlementDiscount(idNo As String)
        'Function GetCustomerSettlementDueDays(idNo As String)
        'Function GetDepositTypeModel() As List(Of DepositTypeModel)
        'Function GetEndingGlBalance(ByVal accountIdNo As Int16, ByVal reconciliationDate As Date) As Decimal
        Function GetIntPhoneCodes(Optional ByVal sortKey As String = "CountryName")
        'Function GetSupplierPaymentDueDays(idNo As String)
        'Function GetSupplierSettlementDiscount(idNo As String)
        'Function GetSupplierSettlementDueDays(idNo As String)
        'Function IsAccountsPayableAccount(ByVal accountIdNo As Int16)
        'Function IsAccountsReceivableAccount(ByVal accountIdNo As Int16)
        'Function IsChildValid(Of Tcm)(childProperty) As Boolean
        'Function IsChildValid2(Of Tcm)(bizName, childProperty) As Boolean
        'Function IsInputVatAccount(ByVal accountIdNo As Int16)
        'Function UpdateInputVatAmount(journalItems As List(Of IJournalItemView))
        'Function UpdateOutputVatAmount(journalItems As List(Of IJournalItemView))
        'Function ValidateDataBoundGrid(Of TMG As New)(viewProperty As Object, dataGridView As DataGridView, dictionary As Dictionary(Of String, Object), Optional tabPage As TabPage = Nothing)
        'Sub AddNewItemOnBindingSource(Of TS As New)(ByVal e As System.ComponentModel.AddingNewEventArgs, bindingSource As BindingSource, dataGridView As DataGridView)
        'Sub Initializer(objectName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
        'Sub InitializerWithTv(baseClassName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
        'Sub MakeCreditAmount(journalItem As IJournalItemView, amount As Decimal?)
        'Sub MakeDebitAmount(journalItem As IJournalItemView, amount As Decimal?)
        'Sub MakePayTypeAndSpecialAccount(journalItem As IJournalItemView, accountIdNo As Int16?)
        'Sub SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean)
    End Interface

End Namespace