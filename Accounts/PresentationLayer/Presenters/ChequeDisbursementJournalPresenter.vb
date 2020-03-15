Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ChequeDisbursementJournalPresenter
        Inherits AccountsPresenter(Of IChequeDisbursementJournalView, ChequeDisbursementJournalModel)

        Public ParentViewList As List(Of ChequeDisbursementJournalModel)
        Private _apOpenInvoiceBo As New ApOpenInvoice
        Private ReadOnly _apOpenInvoiceModel As New ModelApOpenInvoice

        Public Sub New(view As IChequeDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelChequeDisbursementJournal()
            TableName = "ChequeDisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ChequeDisbursementJournalModel()
            DataModel = New ChequeDisbursementJournalModel
            _apOpenInvoiceModel = New ModelApOpenInvoice
        End Sub

        Public Property JournalItemsPresenter As ChequeDisbursementJournalItemsPresenter
        Public Property CkdOiItemsPresenter As CkdOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim chequeDisbursementJournalChangesMade As Boolean
            If GlobalFunctions.ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    chequeDisbursementJournalChangesMade = True
                ElseIf CkdOiItemsPresenter.ChangesMadeInCkdOiItem Then
                    chequeDisbursementJournalChangesMade = True
                Else
                    chequeDisbursementJournalChangesMade = False
                End If
            Else
                chequeDisbursementJournalChangesMade = True
            End If
            Return chequeDisbursementJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            DataModel = GlobalVariables.Mapper.Map(Of ChequeDisbursementJournalModel)(BizObject)
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
            retVal = Model.GetRecordFieldWithKey(idNo, "ChequeDisbursementJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CK", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetSupplierOpenInvoices(supplierIdNo)
            Return retVal
        End Function

    End Class

End Namespace