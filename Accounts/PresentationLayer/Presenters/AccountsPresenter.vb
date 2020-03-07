Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenter(Of T As IView, TM As New)
        Inherits CommonPresenter(Of T, TM)

        'Protected Shared Property ModelApOpenInvoice As IModelApOpenInvoice
        'Protected Shared Property ModelArOpenInvoice As IModelArOpenInvoice
        'Protected Shared Property ModelCashCode As IModelCashCode

        Public Sub New(view As T)
            MyBase.New(view)

        End Sub

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
            'ModelApOpenInvoice = New ModelApOpenInvoice
            'ModelArOpenInvoice = New ModelArOpenInvoice
            'ModelCashCode = New ModelCashCode
        End Sub

        Public Function GetSupplierVatNumber(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "VatNumber")
        End Function

        Public Function GetSupplierPaymentDueDays(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        End Function

        Public Function GetSupplierSettlementDiscount(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDiscount")
        End Function

        Public Function GetSupplierSettlementDueDays(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDueDays")
        End Function

        Public Function GetCustomerPaymentDueDays(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Customer", "IdNo", "PaymentDueDays")
        End Function

        Public Function GetCustomerSettlementDiscount(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDiscount")
        End Function

        Public Function GetCustomerSettlementDueDays(idNo As String)
            Return Model.GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDueDays")
        End Function

        Public Function IsAccountsPayableAccount(ByVal accountIdNo As Integer)
            Return Model.GetRecordFieldWithKey(accountIdNo, "Chart", "IdNo", "SpecialAccount") = "AP"
        End Function

        Public Function IsAccountsReceivableAccount(ByVal accountIdNo As Integer)
            Return Model.GetRecordFieldWithKey(accountIdNo, "Chart", "IdNo", "SpecialAccount") = "AR"
        End Function

        Public Function IsInputVatAccount(ByVal accountIdNo As Integer)
            Return Model.GetRecordFieldWithKey(accountIdNo, "Chart", "IdNo", "SpecialAccount") = "VI"
        End Function

        Public Function GetAdvancesToSupplierAccountIdNo()
            Return Model.GetRecordFieldWithKey("AS", "Chart", "SpecialAccount", "IdNo")
        End Function

        Public Function GetCustomerAdvancesAccountIdNo()
            Return Model.GetRecordFieldWithKey("AC", "Chart", "SpecialAccount", "IdNo")
        End Function

        'Public Function GetChart(idNo As String)
        '    Dim lModel As New ModelChart
        '    Return lModel.GetRecordById(Of ChartModel)(idNo)
        'End Function

        'Public Function AddApOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
        '    Dim retVal As Integer
        '    Dim apOpenInvoiceBo As New ApOpenInvoice

        '    apOpenInvoiceBo.PaidAmount = 0
        '    apOpenInvoiceBo.DiscountTaken = 0
        '    apOpenInvoiceBo.JournalCode = journalCode
        '    apOpenInvoiceBo.JournalIdNo = journalItem.JournalIdNo
        '    apOpenInvoiceBo.JournalItemIdNo = journalItem.IdNo
        '    retVal = ModelApOpenInvoice.AddRecord(Of ApOpenInvoice)(apOpenInvoiceBo)
        '    Return retVal
        'End Function

        'Public Function DeleteApOpenInvoice(ByRef idNo As Integer) As String
        '    Dim retValue As String
        '    retValue = ModelApOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
        '    Return retValue
        'End Function

        'Public Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
        '    Dim retVal As Integer
        '    Dim arOpenInvoiceBo As New ArOpenInvoice

        '    arOpenInvoiceBo.PaidAmount = 0
        '    arOpenInvoiceBo.DiscountTaken = 0
        '    arOpenInvoiceBo.JournalCode = journalCode
        '    arOpenInvoiceBo.JournalIdNo = journalItem.JournalIdNo
        '    arOpenInvoiceBo.JournalItemIdNo = journalItem.IdNo
        '    retVal = ModelArOpenInvoice.AddRecord(Of ArOpenInvoice)(arOpenInvoiceBo)
        '    Return retVal
        'End Function

        'Public Function DeleteArOpenInvoice(ByRef idNo As Integer) As String
        '    Dim retValue As String
        '    retValue = ModelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
        '    Return retValue
        'End Function

        'Public Function GetCashCodesModel() As List(Of CashCodeModel)
        '    Dim cashCodes As New List(Of CashCodeModel)
        '    Return ModelCashCode.GetAll(Of CashCodeModel)("CashName")
        'End Function

        'Public Function GetCashCodes(Optional ByVal sortKey As String = "CashName")
        '    Return GetLookupData("CashName", "CashNameAra", "CashCode",
        '                         "CashCode", sortKey, "")
        'End Function

        'Public Function GetEndingGlBalance(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date) As Decimal
        '    Return CommonModel.GetEndingGlBalance(accountIdNo, reconciliationDate)
        'End Function

    End Class
End NameSpace