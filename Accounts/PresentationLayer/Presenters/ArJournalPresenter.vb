Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ArJournalPresenter
        Inherits AccountsPresenter(Of IArJournalView, ArJournalModel)

        Private ReadOnly _arOpenInvoiceModel As ModelArOpenInvoice

        Public Sub New(view As IArJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelArJournal()
            TableName = "ArJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ArJournalModel()
            DataBizObject = New ArJournal
            DataModel = New ArJournalModel
            _arOpenInvoiceModel = New ModelArOpenInvoice
            ModelArOpenInvoice = New ModelArOpenInvoice
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
            'GlobalVariables.Mapper.Map(DataModel, DataBizObject)
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