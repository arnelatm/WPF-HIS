Imports System.Windows.Forms
Imports AATM.Core.Messaging
Imports AATM.Core.Logging
Imports Winforms.AATM.Modules.Customers

Public Interface ICustomerView
    ' Define the contract for the view. The presenter will only know about this interface.
    Event LoadCustomers As EventHandler
    Event SaveCustomer(ByVal customer As CustomerDTO)

    Sub DisplayCustomers(ByVal customers As List(Of CustomerDTO))
    Sub EnableView(ByVal isEnabled As Boolean)
End Interface

Public Class FrmMain
    Implements ICustomerView

    ' These fields will be injected by our composition root.
    Private ReadOnly _presenter As CustomerPresenter

    ' The UI components for our view. You'll need to add these in the designer.
    Public WithEvents btnSaveCustomer As New Button()
    Public WithEvents dgvCustomers As New DataGridView()
    Public WithEvents tsMain As New ToolStrip()
    Public WithEvents tsStatus As New StatusStrip()
    Public WithEvents tsLblStatus As New ToolStripStatusLabel()
    Public WithEvents tsbtnViewLog As New ToolStripMenuItem("View Log")

    ' The presenter will be injected.
    Public Sub New(ByVal presenter As CustomerPresenter)
        ' This call is required by the designer.
        InitializeComponent()
        Me._presenter = presenter

        ' Designer code would go here
        Me.Text = "AATM Enterprise Application"
        Me.Width = 800
        Me.Height = 600

        ' Add a menu strip
        Dim menu As New MenuStrip()
        Dim fileMenu As New ToolStripMenuItem("File")
        Dim exitItem As New ToolStripMenuItem("Exit")
        AddHandler exitItem.Click, Sub() Application.Exit()
        fileMenu.DropDownItems.Add(exitItem)
        menu.Items.Add(fileMenu)
        Me.Controls.Add(menu)

        ' Add the "View Log" menu item
        Dim toolsMenu As New ToolStripMenuItem("Tools")
        toolsMenu.DropDownItems.Add(tsbtnViewLog)
        menu.Items.Add(toolsMenu)

        ' Add a status strip
        Me.Controls.Add(tsStatus)
        tsStatus.Items.Add(tsLblStatus)

        ' Add a DataGridView for customers
        dgvCustomers.Dock = DockStyle.Fill
        Me.Controls.Add(dgvCustomers)

        ' Add a save button
        btnSaveCustomer.Text = "Save Customer"
        Me.Controls.Add(btnSaveCustomer)
        btnSaveCustomer.Dock = DockStyle.Bottom

        ' Add the handler for the "View Log" menu item
        AddHandler tsbtnViewLog.Click, AddressOf ViewLogToolStripMenuItem_Click
    End Sub

    Public Sub DisplayCustomers(ByVal customers As List(Of CustomerDTO)) Implements ICustomerView.DisplayCustomers
        Me.dgvCustomers.DataSource = customers
    End Sub

    Public Sub EnableView(ByVal isEnabled As Boolean) Implements ICustomerView.EnableView
        ' Logic to enable/disable controls
        Me.Enabled = isEnabled
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadCustomers(Me, EventArgs.Empty)
    End Sub

    Private Sub btnSaveCustomer_Click(sender As Object, e As EventArgs) Handles btnSaveCustomer.Click
        ' For demonstration, we'll create a mock customer.
        Dim mockCustomer As New CustomerDTO() With {
            .FirstName = "John",
            .LastName = "Doe",
            .Email = "john.doe@example.com"
        }
        RaiseEvent SaveCustomer(mockCustomer)
    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim logViewer As New FrmLogViewer()
        logViewer.Show()
    End Sub

End Class

Public Class CustomerDTO
    Public Property CustomerID As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
End Class
