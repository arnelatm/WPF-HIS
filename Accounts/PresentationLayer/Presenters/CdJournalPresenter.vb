Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class CdJournalPresenter
        Inherits DisbursementJournalPresenter(Of IDisbursementJournalView, DisbursementJournalModel)

        Public Sub New(view As IDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CashDisbursementJournal")
            CjItemModel = New ModelAccounts("CashDisbursementJournalItem")
            OiItemModel = New ModelAccounts("CdOiItem")
            TableName = "CashDisbursementJournal"
            SortOrderKey = "IdNo"
            JournalCode = "CD"
            ReportName = "Cash Disbursement Journal.Rpt"
            OriginalModel = New DisbursementJournalModel()
            DataModel = New DisbursementJournalModel

        End Sub

    End Class

End Namespace