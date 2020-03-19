Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ArJournalPresenter
        Inherits AccountsPresenter(Of IArJournalView, ArJournalModel)

        Private ReadOnly _arOpenInvoiceModel As New ModelAccounts("ArOpenInvoice")

        Public Sub New(view As IArJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ArJournal")
            TableName = "ArJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ArJournalModel()
            DataModel = New ArJournalModel
        End Sub

        Public Property JournalItemsPresenter As ArJournalItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim arJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    arJournalChangesMade = True
                Else
                    arJournalChangesMade = False
                End If
            Else
                arJournalChangesMade = True
            End If
            Return arJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim openInvoiceModel As New ArOpenInvoiceModel
            openInvoiceModel.DiscountTaken = journalItem.DiscountTaken
            openInvoiceModel.PaidAmount = journalItem.PaidAmount
            openInvoiceModel.IdNo = journalItem.IdNo
            openInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retValue = _arOpenInvoiceModel.UpdateRecord(Of ArOpenInvoiceModel)(openInvoiceModel)
            Return retValue
        End Function

    End Class

End Namespace