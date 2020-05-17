Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms.Reports
    Public Class StatementOfAccountsPayable

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Supplier"
            SortOrderKey = "IdNo"
            PresenterObj = New SupplierPresenter(Me)
            cboSupplierCode.DataSource = PresenterObj.GetSupplierListByCode()
            Dim today As Date = Now()
            dtpBeginningDate.Value = GlobalFunctions.GbDateSerial(Year(today), 1, 1)
            dtpEndingDate.Value = Now()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

    End Class
End Namespace