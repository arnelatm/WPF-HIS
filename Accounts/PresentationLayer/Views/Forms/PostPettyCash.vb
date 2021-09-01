Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters

Namespace PresentationLayer.Views.Forms

    Public Class PostPettyCash

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PcJournal"
            SortOrderKey = "IdNo"
            Presenter = New PettyCashClosingPresenter(Of PettyCashClosingModel)(Me)
            cboAccountIdNo.DataSource = Presenter.GetAccountTypesList("BA,CS,CK")
            cboStartIdNo.DataSource = Presenter.GetLookup("PcJournal", "Reference", {"IdNo", "ReferenceNo", "TransactionDate"}, "Posted=0")
        End Sub

    End Class

End Namespace