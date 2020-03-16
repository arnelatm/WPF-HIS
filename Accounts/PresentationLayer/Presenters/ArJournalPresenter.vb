Imports AATM.Accounts.BusinessLayer
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
            '_arOpenInvoiceModel = New ModelAccounts("ArOpenInvoice")
            ModelArOpenInvoice = New ModelAccounts("ArOpenInvoice")
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
            Dim arOpenInvoiceBo As New ArOpenInvoice
            arOpenInvoiceBo.DiscountTaken = journalItem.DiscountTaken
            arOpenInvoiceBo.PaidAmount = journalItem.PaidAmount
            arOpenInvoiceBo.IdNo = journalItem.IdNo
            arOpenInvoiceBo.JournalItemIdNo = journalItem.IdNo
            retValue = ModelArOpenInvoice.UpdateRecord(Of ArOpenInvoice)(arOpenInvoiceBo)
            Return retValue
        End Function

    End Class

End Namespace