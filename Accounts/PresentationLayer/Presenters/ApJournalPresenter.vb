Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class ApJournalPresenter
        Inherits AccountsPresenter(Of IApJournalView, ApJournalModel)

        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ApJournal")
            TableName = "ApJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ApJournalModel()
            DataModel = New ApJournalModel
        End Sub

        Public Property JournalItemsPresenter As ApJournalItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim apJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    apJournalChangesMade = True
                Else
                    apJournalChangesMade = False
                End If
            Else
                apJournalChangesMade = True
            End If
            Return apJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim openInvoiceModel As New ApOpenInvoiceModel
            openInvoiceModel.DiscountTaken = journalItem.DiscountTaken
            openInvoiceModel.PaidAmount = journalItem.PaidAmount
            openInvoiceModel.IdNo = journalItem.IdNo
            openInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retValue = _apOpenInvoiceModel.UpdateRecord(Of ApOpenInvoiceModel)(openInvoiceModel)
            Return retValue
        End Function

    End Class

End Namespace