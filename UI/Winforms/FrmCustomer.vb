Imports AATM.Core.UI.Logging
Imports Winforms.AATM.Modules.Customers

Public Class FrmCustomer
    Implements ICustomerView

    ' This is the Presenter that the View will communicate with.
    Private ReadOnly _presenter As CustomerPresenter

    ' WinForms UI Controls (simulated)
    Public ReadOnly Property dgvCustomers As DataGridView
    Public ReadOnly Property txtCustomerID As TextBox
    Public ReadOnly Property txtFirstName As TextBox
    Public ReadOnly Property txtLastName As TextBox
    Public ReadOnly Property txtEmail As TextBox
    Public ReadOnly Property btnSave As Button
    Public ReadOnly Property btnCancel As Button
    Public ReadOnly Property MainStatusStrip As StatusStrip

    ' MenuStrip for the Log Viewer
    Private ReadOnly MainMenu As MenuStrip

    Public Sub New(presenter As CustomerPresenter)
        _presenter = presenter
        ' Note: In a real app, these controls would be created in the designer.
        Me.MainStatusStrip = New StatusStrip()
        Me.Controls.Add(Me.MainStatusStrip)

        ' Create the MenuStrip for the Log Viewer
        Me.MainMenu = New MenuStrip()
        Me.Controls.Add(Me.MainMenu)

        Dim fileMenu As New ToolStripMenuItem("File")
        Me.MainMenu.Items.Add(fileMenu)

        Dim viewLogMenuItem As New ToolStripMenuItem("View Log")
        fileMenu.DropDownItems.Add(viewLogMenuItem)
        AddHandler viewLogMenuItem.Click, AddressOf Me.ViewLogMenuItem_Click
    End Sub

    Public Event LoadCustomers As EventHandler Implements ICustomerView.LoadCustomers
    Public Event SaveCustomer(ByVal customer As CustomerDTO) Implements ICustomerView.SaveCustomer

    Public Sub DisplayCustomers(ByVal customers As List(Of CustomerDTO)) Implements ICustomerView.DisplayCustomers
        Me.dgvCustomers.DataSource = customers
    End Sub

    Public Sub EnableView(ByVal isEnabled As Boolean) Implements ICustomerView.EnableView
        Me.Enabled = isEnabled
    End Sub

    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadCustomers(Me, EventArgs.Empty)
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

    Private Sub ViewLogMenuItem_Click(sender As Object, e As EventArgs)
        Dim logViewerForm As New FrmLogViewer()
        logViewerForm.Show()
    End Sub
End Class
