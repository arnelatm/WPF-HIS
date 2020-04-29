Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CheckDisbursementJournalPresenter
        Inherits AccountsPresenter(Of ICheckDisbursementJournalView, CheckDisbursementJournalModel)

        Public ParentViewList As List(Of CheckDisbursementJournalModel)
        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Public Sub New(view As ICheckDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CheckDisbursementJournal")
            TableName = "CheckDisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CheckDisbursementJournalModel()
            DataModel = New CheckDisbursementJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property JournalItemsPresenter As CheckDisbursementJournalItemsPresenter
        Public Property CkdOiItemsPresenter As CkdOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim checkDisbursementJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    checkDisbursementJournalChangesMade = True
                ElseIf CkdOiItemsPresenter.ChangesMadeInCkdOiItem Then
                    checkDisbursementJournalChangesMade = True
                Else
                    checkDisbursementJournalChangesMade = False
                End If
            Else
                checkDisbursementJournalChangesMade = True
            End If
            Return checkDisbursementJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            GlobalVariables.Mapper.Map(View, DataModel)
            Return ModelPresenter.UpdateGlReferenceNumber(DataModel)
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function GetPaymentType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CheckDisbursementJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Int32) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CK", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32) As List(Of CkdOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of CkdOiItemModel)(supplierIdNo)
        End Function

    End Class

End Namespace