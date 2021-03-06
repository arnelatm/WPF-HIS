Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer
Public Class CustomerEntryBound

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'MainTableName = "Customer"
        'TvMainFieldName = "CustomerName"
        'TvSecondaryFieldName = "CustomerCode"
        'SortOrderKey = "CustomerName"
        'FirstControl = txtCustomerName
        ' Add any initialization after the InitializeComponent() call.
        'PresenterObj = New CustomerPresenter(Me)
        'PresenterObj = New CustomerPresenter
        'Ea = PresenterObj.Ea
        'Ea.SubscribeEvent(Me)


    End Sub

    Private Sub CustomerEntryBound_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cust = New List(Of AATM.Accounts.BusinessLayer.Customer)
        Dim dao = New CustomerDao()
        cust = dao.GetAll()
        Me.CustomerBindingSource.DataSource = cust
    End Sub



End Class