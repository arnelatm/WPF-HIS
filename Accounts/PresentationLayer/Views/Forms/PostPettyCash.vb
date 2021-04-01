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
            PresenterObj = New PettyCashClosingPresenter(Me)
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("BA,CS,CK")
            'cboStartIdNo.DataSource = PresenterObj.GetLookupData("ReferenceNo", "ReferenceNo", "TransactionDate", "PcJournal", "ReferenceNo", "Posted=0")
            cboStartIdNo.DataSource = PresenterObj.GetLookup("PcJournal", "Reference", {"IdNo", "ReferenceNo", "TransactionDate"}, "Posted=0")
            'GetLookupData(pDisplayName, pDisplayNameArabic, pDisplayCode, pLookUpTableToGet, pLookUpSortExpression, pFilterKey)
        End Sub

    End Class

End Namespace