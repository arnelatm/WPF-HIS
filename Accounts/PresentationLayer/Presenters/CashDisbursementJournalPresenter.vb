Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class CashDisbursementJournalPresenter
        Inherits AccountsPresenter(Of ICashDisbursementJournalView, CashDisbursementJournal, CashDisbursementJournalModel)

        Public ParentViewList As List(Of CashDisbursementJournalModel)
        Private _apOpenInvoiceBo As New ApOpenInvoice
        Private ReadOnly _apOpenInvoiceModel As New ModelApOpenInvoice

        Public Sub New(view As ICashDisbursementJournalView)
            MyBase.New(view)
            CurrentModel = New ModelCashDisbursementJournal()
            TableName = "CashDisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CashDisbursementJournalModel()
            BizObject = New CashDisbursementJournal
            DataModel = New CashDisbursementJournalModel
            _apOpenInvoiceModel = New ModelApOpenInvoice
        End Sub

        Public Property JournalItemsPresenter As CashDisbursementJournalItemsPresenter
        Public Property CadOiItemsPresenter As CadOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim cashDisbursementJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    cashDisbursementJournalChangesMade = True
                ElseIf CadOiItemsPresenter.ChangesMadeInCadOiItem Then
                    cashDisbursementJournalChangesMade = True
                Else
                    cashDisbursementJournalChangesMade = False
                End If
            Else
                cashDisbursementJournalChangesMade = True
            End If
            Return cashDisbursementJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            DataModel = GlobalVariables.Mapper.Map(Of CashDisbursementJournalModel)(BizObject)
            retValue = Model.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function GetPaymentType(ByRef idNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CashDisbursementJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CD", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetSupplierOpenInvoices(supplierIdNo)
            Return retVal
        End Function

    End Class
End NameSpace