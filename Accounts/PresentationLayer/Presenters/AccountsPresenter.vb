Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenter(Of T As IView, TM As New)
        Inherits CommonPresenter(Of T, TM)

        'Protected Shared Property ModelApOpenInvoice As
        'IModelOpenInvoice
        'Private Property ModelArOpenInvoice ' As IModelOpenInvoice
        'Private Property ModelCashCode ' As IModelCashCode

        Public Sub New(view As T)
            MyBase.New(view)
        End Sub

        Public Overrides Sub Initializer(baseClassName As String, Optional tableOrViewName As String = Nothing)
            Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts"
            TableName = IIf(tableOrViewName Is Nothing, baseClassName, tableOrViewName)
            SortOrderKey = baseClassName + "Name"
            Dim args As Object() = {baseClassName}
            Dim t As Type = Type.GetType(presenterModelName)
            ModelPresenter = Activator.CreateInstance(t, args)
            OriginalModel = New TM
            DataModel = New TM
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Model." + baseClassName + "Model"
            'OriginalModel = Activator.CreateInstance(Type.GetType(presenterModelName))
            'DataModel = Activator.CreateInstance(Type.GetType(presenterModelName))
        End Sub

        Public Overrides Sub InitializerWithTv(baseClassName As String, Optional tableOrViewName As String = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, tableOrViewName)
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

        Public Function GetSupplierVatNumber(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "VatNumber")
        End Function

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

        Public Function IsAccountsPayableAccount(ByVal AccountIdNo As Int16)
            Return GetRecordFieldWithKey(AccountIdNo, "Account", "IdNo", "SpecialAccount") = "AP"
        End Function

        Public Function IsAccountsReceivableAccount(ByVal AccountIdNo As Int16)
            Return GetRecordFieldWithKey(AccountIdNo, "Account", "IdNo", "SpecialAccount") = "AR"
        End Function

        Public Function IsInputVatAccount(ByVal AccountIdNo As Int16)
            Return GetRecordFieldWithKey(AccountIdNo, "Account", "IdNo", "SpecialAccount") = "VI"
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
            If Model.CountRecordWithKey(apOpenInvoiceIdNo, "CadOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "CkdOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "PcsOiItem", "ApOpenInvoiceIdNo") > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function DeleteArOpenInvoice(ByRef idNo As Int32) As String
            Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
            If Model.CountRecordWithKey(idNo, "CsrOiItem", "ArOpenInvoiceIdNo") = 0 Then
                Return modelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
            End If
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

    End Class

End Namespace