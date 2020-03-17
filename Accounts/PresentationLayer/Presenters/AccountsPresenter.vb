Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenter(Of T As IView, TM As New)
        Inherits CommonPresenter(Of T, TM)

        'Protected Shared Property ModelApOpenInvoice As IModelOpenInvoice
        Protected Shared Property ModelArOpenInvoice As IModelOpenInvoice
        Protected Shared Property ModelCashCode As IModelCashCode

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

        Public Sub Initializer(baseClassName As String)
            Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts" 
            TableName = baseClassName
            SortOrderKey = baseClassName + "Name"
            Dim args As Object() = { baseClassName }
            Dim t As Type = Type.GetType(presenterModelName)
            ModelPresenter = Activator.CreateInstance( t, args ) 
            OriginalModel = New TM
            DataModel = New TM
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Model." + baseClassName + "Model"
            'OriginalModel = Activator.CreateInstance(Type.GetType(presenterModelName))
            'DataModel = Activator.CreateInstance(Type.GetType(presenterModelName))
        End Sub

        Public Sub InitializerWithTv(baseClassName As String)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName)
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

        Public Function AddApOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
            Dim retVal As Integer
            Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
            Dim apOpenInvoiceModel As New ApOpenInvoiceModel
            apOpenInvoiceModel.PaidAmount = 0
            apOpenInvoiceModel.DiscountTaken = 0
            apOpenInvoiceModel.JournalCode = journalCode
            apOpenInvoiceModel.JournalIdNo = journalItem.JournalIdNo
            apOpenInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retVal = ModelApOpenInvoice.AddRecord(Of ApOpenInvoiceModel)(apOpenInvoiceModel)
            Return retVal
        End Function

        Public Function DeleteApOpenInvoice(ByRef idNo As Integer) As String
            Dim retValue As String
            Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
            retValue = ModelApOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
            Return retValue
        End Function

        Public Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer
            Dim retVal As Integer
            Dim arOpenInvoiceModel As New ArOpenInvoiceModel

            arOpenInvoiceModel.PaidAmount = 0
            arOpenInvoiceModel.DiscountTaken = 0
            arOpenInvoiceModel.JournalCode = journalCode
            arOpenInvoiceModel.JournalIdNo = journalItem.JournalIdNo
            arOpenInvoiceModel.JournalItemIdNo = journalItem.IdNo
            'ModelArOpenInvoice = New ModelArOpenInvoice()
            retVal = ModelArOpenInvoice.AddRecord(Of ArOpenInvoiceModel)(arOpenInvoiceModel)
            Return retVal
        End Function

        Public Function DeleteArOpenInvoice(ByRef idNo As Integer) As String
            Dim retValue As String
            retValue = ModelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
            Return retValue
        End Function

        Public Function GetCashCodesModel() As List(Of CashCodeModel)
            Dim cashCodes As New List(Of CashCodeModel)
            Return ModelCashCode.GetAll(Of CashCodeModel)("CashName")
        End Function

        Public Function GetCashCodes(Optional ByVal sortKey As String = "CashName")
            Return GetLookupData("CashName", "CashNameAra", "CashCode",
                                 "CashCode", sortKey, "")
        End Function

        Public Function GetEndingGlBalance(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date) As Decimal
            Return DataModel.GetEndingGlBalance(accountIdNo, reconciliationDate)
        End Function

    End Class

End Namespace