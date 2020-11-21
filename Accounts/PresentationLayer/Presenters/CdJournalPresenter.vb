Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Public Class CdJournalPresenter
    Inherits DisbursementJournalPresenter(Of IDisbursementJournalView, DisbursementJournalModel)

    Public Sub New(View As IDisbursementJournalView)
        MyBase.New(View)
        ModelPresenter = New ModelAccounts("CdJournal")
        TableName = "CashDisbursementJournal"
        SortOrderKey = "IdNo"
        JournalCode = "CD"
        ReportName = "Cash Disbursement Journal.Rpt"
        OriginalModel = New CashDisbursementJournalModel()
        DataModel = New CashDisbursementJournalModel

    End Sub

End Class