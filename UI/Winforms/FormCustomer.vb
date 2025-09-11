Imports AATM.Modules.Customers
Imports Winforms.AATM.Modules.Customers

Public Class FormCustomer
    Implements ICustomerView

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(presenter As CustomerPresenter)
        Me.New()
        _presenter = presenter
        ' Note: In a real app, these controls would be created in the designer.
        'Me.MainStatusStrip = New StatusStrip()
        'Me.Controls.Add(Me.MainStatusStrip)
    End Sub

    ' This is the Presenter that the View will communicate with.
    Private ReadOnly _presenter As CustomerPresenter
    Public Event LoadCustomers As EventHandler Implements ICustomerView.LoadCustomers
    Public Event SaveCustomer(customer As CustomerDTO) Implements ICustomerView.SaveCustomer

    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadCustomers(Me, EventArgs.Empty)
    End Sub

    Public Sub DisplayCustomers(customers As List(Of CustomerDTO)) Implements ICustomerView.DisplayCustomers
        Me.dgvCustomers.DataSource = customers
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim customerToSave As New CustomerDTO()
        customerToSave.FirstName = Me.txtFirstName.Text
        customerToSave.LastName = Me.txtLastName.Text
        customerToSave.Email = Me.txtEmail.Text

        RaiseEvent SaveCustomer(customerToSave)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub EnableView(isEnabled As Boolean) Implements ICustomerView.EnableView
        Me.Enabled = isEnabled
    End Sub


End Class