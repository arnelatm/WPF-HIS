Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters


    Public Class ApJournalPresenter
        Inherits AccountsPresenter(Of IApJournalView, ApJournal, ApJournalModel)

        Public ParentViewList As List(Of ApJournalModel)
        Private ReadOnly _apOpenInvoiceModel As ModelApOpenInvoice

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            CurrentModel = New ModelApJournal()
            TableName = "ApJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ApJournalModel()
            BizObject = New ApJournal
            DataModel = New ApJournalModel
            _apOpenInvoiceModel = New ModelApOpenInvoice
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
            retValue = Model.UpdateGlReferenceNumber(BizObject)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim apOpenInvoiceBo As New ApOpenInvoice
            apOpenInvoiceBo.DiscountTaken = journalItem.DiscountTaken
            apOpenInvoiceBo.PaidAmount = journalItem.PaidAmount
            apOpenInvoiceBo.IdNo = journalItem.IdNo
            apOpenInvoiceBo.JournalItemIdNo = journalItem.IdNo
            retValue = _apOpenInvoiceModel.UpdateRecord(Of ApOpenInvoice)(apOpenInvoiceBo)
            Return retValue
        End Function

    End Class
End NameSpace