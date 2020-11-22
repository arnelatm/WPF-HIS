Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class CdJournalPresenter
        Inherits DisbursementJournalPresenter(Of IDisbursementJournalView, DisbursementJournalModel)

        Public Sub New(view As IDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CdJournal")
            DjItemModel = New ModelAccounts("CdJournalItem")
            OiItemModel = New ModelAccounts("CdOiItem")
            TableName = "CdJournal"
            SortOrderKey = "IdNo"
            JournalCode = "CD"
            ReportName = "Cash Disbursement Journal.Rpt"
        End Sub

    End Class

End Namespace