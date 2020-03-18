Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CashReceiptJournalPresenter
        Inherits AccountsPresenter(Of ICashReceiptJournalView, CashReceiptJournalModel)

        Public ParentViewList As List(Of CashReceiptJournalModel)
        Private _arOpenInvoiceBo As New ArOpenInvoice
        Private ReadOnly _arOpenInvoiceModel As New ModelAccounts("ArOpenInvoice")

        Public Sub New(view As ICashReceiptJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CashReceiptJournal")
            TableName = "CashReceiptJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CashReceiptJournalModel()
            DataModel = New CashReceiptJournalModel
            '_arOpenInvoiceModel = New ModelArOpenInvoice
        End Sub

        Public Property JournalItemsPresenter As CashReceiptJournalItemsPresenter
        Public Property CsrOiItemsPresenter As CsrOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim cashReceiptJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    cashReceiptJournalChangesMade = True
                ElseIf CsrOiItemsPresenter.ChangesMadeInCsrOiItem Then
                    cashReceiptJournalChangesMade = True
                Else
                    cashReceiptJournalChangesMade = False
                End If
            Else
                cashReceiptJournalChangesMade = True
            End If
            Return cashReceiptJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _arOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _arOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function GetReceiptType(ByRef idNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CashReceiptJournal", "IdNo", "PayorType")
            Return retVal
        End Function

        Public Function GetCustomerAdvancesOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CR", "ArOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetCustomerOpenInvoices(ByRef customerIdNo As Integer) As String
            Dim retVal As String
            retVal = ModelPresenter.GetCustomerOpenInvoices(customerIdNo)
            Return retVal
        End Function

        'Public Function AddOpenInvoice(ByVal journalItem As JournalItemModel) As Integer
        '    Dim retVal As Integer
        '    Dim arOpenInvoiceBo As New ArOpenInvoice
        '    arOpenInvoiceBo.PaidAmount = 0
        '    arOpenInvoiceBo.DiscountTaken = 0
        '    arOpenInvoiceBo.JournalCode = "CR"
        '    arOpenInvoiceBo.JournalIdNo = journalItem.JournalIdNo
        '    arOpenInvoiceBo.JournalItemIdNo = journalItem.IdNo
        '    retVal = _arOpenInvoiceModel.AddRecord(Of ArOpenInvoice)(arOpenInvoiceBo)
        '    Return retVal
        'End Function

    End Class

End Namespace