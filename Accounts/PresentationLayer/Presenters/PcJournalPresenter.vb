Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class PcJournalPresenter
        Inherits DisbursementJournalPresenter(Of IDisbursementJournalView, DisbursementJournalModel)

        Public Sub New(view As IDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PcJournal")
            DjItemModel = New ModelAccounts("PcDisbursementJournalItem")
            OiItemModel = New ModelAccounts("PcOiItem")
            TableName = "PcJournal"
            SortOrderKey = "IdNo"
            JournalCode = "PC"
            ReportName = "Petty Cash Disbursement Journal.Rpt"
        End Sub

    End Class

End Namespace