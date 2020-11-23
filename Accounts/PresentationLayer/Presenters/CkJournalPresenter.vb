Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class CkJournalPresenter
        Inherits DisbursementJournalPresenter(Of IDisbursementJournalView, DisbursementJournalModel)

        Public Sub New(view As IDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CkJournal")
            DjItemModel = New ModelAccounts("CkJournalItem")
            OiItemModel = New ModelAccounts("CkOiItem")
            TableName = "CkJournal"
            SortOrderKey = "IdNo"
            JournalCode = "CD"
            ReportName = "Check Disbursement Journal.Rpt"
        End Sub

    End Class

End Namespace