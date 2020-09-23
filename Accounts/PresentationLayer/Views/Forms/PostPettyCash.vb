Imports AATM.Accounts.PresentationLayer.Presenters

Namespace PresentationLayer.Views.Forms
    Public Class PostPettyCash

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New PostPettyCashPresenter(Me)
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("BA,CS,CK")
            cboStartIdNo.DataSource = PresenterObj.GetRecords("PettyCashJournal", "ReferenceNo", "TransactionDate")
            cboEndIdNo.DataSource = PresenterObj.GetRecords("PettyCashJournal", "ReferenceNo", "TransactionDate")
            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub cboStartIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStartIdNo.SelectedIndexChanged

        End Sub
    End Class
End Namespace