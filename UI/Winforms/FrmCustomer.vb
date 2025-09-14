Imports AATM.Core.Localization
Imports AATM.Modules.Customers

Public Class FrmCustomer
    Implements ICustomerView

    'Private _components As System.ComponentModel.IContainer

    Public Sub New()
        InitializeComponent()
        ' Populate the language dropdown
        cmbLanguage.Items.Add(New With {.Text = "English", .Value = "en-US"})
        cmbLanguage.Items.Add(New With {.Text = "العربية", .Value = "ar-SA"})
        cmbLanguage.DisplayMember = "Text"
        cmbLanguage.ValueMember = "Value"
        cmbLanguage.SelectedIndex = 0
        StoreOriginalTags(Me.Controls)
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
    ' Events that the presenter subscribes to.
    Public Event LoadView As EventHandler Implements ICustomerView.LoadView
    Public Event SaveCustomer(customer As CustomerDTO) Implements ICustomerView.SaveCustomer
    Public Event EditCustomer(customer As CustomerDTO) Implements ICustomerView.EditCustomer
    Public Event DeleteCustomer(customerID As Integer) Implements ICustomerView.DeleteCustomer
    Public Event ClearView As EventHandler Implements ICustomerView.ClearView
    Public Event LanguageChanged As ICustomerView.LanguageChangedEventHandler Implements ICustomerView.LanguageChanged

    Private Sub FrmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadView(Me, EventArgs.Empty)
    End Sub

    Public Sub DisplayCustomers(customers As List(Of CustomerDTO)) Implements ICustomerView.DisplayCustomers
        Me.dgvCustomers.DataSource = customers
    End Sub

    Public Sub ClearCustomerDetails() Implements ICustomerView.ClearCustomerDetails
        txtCustomerID.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
    End Sub

    Public Sub SetEditMode(isEditing As Boolean) Implements ICustomerView.SetEditMode
        btnDelete.Enabled = isEditing
    End Sub

    Public Sub SetRightToLeft(isRtl As Boolean) Implements ICustomerView.SetRightToLeft
        Me.RightToLeftLayout = isRtl
        Me.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
    End Sub

    Public Sub DisplayCustomerDetails(customer As CustomerDTO) Implements ICustomerView.DisplayCustomerDetails
        txtCustomerID.Text = customer.CustomerID.ToString()
        txtFirstName.Text = customer.FirstName
        txtLastName.Text = customer.LastName
        txtEmail.Text = customer.Email
    End Sub

    ' Event Handlers
    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadView(Me, EventArgs.Empty)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim customer As New CustomerDTO()
        If Not String.IsNullOrWhiteSpace(txtCustomerID.Text) Then
            customer.CustomerID = Integer.Parse(txtCustomerID.Text)
        End If
        customer.FirstName = txtFirstName.Text
        customer.LastName = txtLastName.Text
        customer.Email = txtEmail.Text
        RaiseEvent SaveCustomer(customer)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrWhiteSpace(txtCustomerID.Text) Then
            Dim customerID As Integer = Integer.Parse(txtCustomerID.Text)
            RaiseEvent DeleteCustomer(customerID)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        RaiseEvent ClearView(Me, EventArgs.Empty)
    End Sub

    Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        If e.RowIndex >= 0 Then
            Dim customer As CustomerDTO = CType(dgvCustomers.Rows(e.RowIndex).DataBoundItem, CustomerDTO)
            RaiseEvent EditCustomer(customer)
        End If
    End Sub

    '' Dispose method to clean up components
    'Protected Overrides Sub Dispose(disposing As Boolean)
    '    If disposing AndAlso (_components IsNot Nothing) Then
    '        _components.Dispose()
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    Public Function GetSelectedCustomerID() As Integer Implements ICustomerView.GetSelectedCustomerID
        Throw New NotImplementedException()
    End Function

    Private Sub cmbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
        If cmbLanguage.SelectedItem IsNot Nothing Then
            Dim languageCode As String = CType(cmbLanguage.SelectedItem, Object).Value
            RaiseEvent LanguageChanged(languageCode)
        End If
    End Sub

    ''' <summary>
    ''' Now simply calls the UI manager to translate the form.
    ''' </summary>
    Public Sub SetLocalizedText(uiLocalizationManager As IUiLocalizationManager, localizedStrings As Dictionary(Of String, String)) Implements ICustomerView.SetLocalizedText
        uiLocalizationManager.SetLocalizedText(Me, localizedStrings)
    End Sub


    '''' <summary>
    '''' Sets the UI text on the controls using the provided localized strings.
    '''' </summary>
    'Public Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String)) Implements ICustomerView.SetLocalizedText
    '    Me.Text = localizedStrings("CustomerFormTitle")

    '    For Each control As Control In Me.Controls
    '        If control.Tag IsNot Nothing AndAlso localizedStrings.ContainsKey(CStr(control.Tag)) Then
    '            control.Text = localizedStrings(CStr(control.Tag))
    '        End If
    '    Next
    'End Sub


    'Public Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String)) Implements ICustomerView.SetLocalizedText
    '    Me.Text = localizedStrings("CustomerFormTitle")
    '    Me.Controls("lblFirstName").Text = localizedStrings("FirstNameLabel")
    '    Me.Controls("lblLastName").Text = localizedStrings("LastNameLabel")
    '    Me.Controls("lblEmail").Text = localizedStrings("EmailLabel")
    '    Me.Controls("lblLanguage").Text = localizedStrings("LanguageLabel")
    '    Me.Controls("btnSave").Text = localizedStrings("SaveButtonText")
    '    Me.Controls("btnDelete").Text = localizedStrings("DeleteButtonText")
    '    Me.Controls("btnClear").Text = localizedStrings("ClearButtonText")
    'End Sub

    Public Sub DisplayLanguages(languages As List(Of (display As String, code As String))) Implements ICustomerView.DisplayLanguages
        cmbLanguage.Items.Clear()
        For Each lang In languages
            cmbLanguage.Items.Add(New With {.Text = lang.display, .Value = lang.code})
        Next
        cmbLanguage.DisplayMember = "Text"
        cmbLanguage.ValueMember = "Value"
    End Sub

    ''' <summary>
    ''' Recursively stores the original text of each control in its Tag property.
    ''' </summary>
    Private Sub StoreOriginalTags(controls As Control.ControlCollection)
        For Each control As Control In controls
            If Not String.IsNullOrWhiteSpace(control.Text) Then
                ' For our simple text-based localization, we'll use the original text as the key.
                control.Tag = control.Text
            End If

            If control.HasChildren Then
                StoreOriginalTags(control.Controls)
            End If
        Next
        ' The form's title is not in the Controls collection, so we set it manually.
        Me.Tag = "Customer Management"
    End Sub




    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    Dim customerToSave As New CustomerDTO()
    '    customerToSave.FirstName = Me.txtFirstName.Text
    '    customerToSave.LastName = Me.txtLastName.Text
    '    customerToSave.Email = Me.txtEmail.Text

    '    RaiseEvent SaveCustomer(customerToSave)
    'End Sub

    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    Me.Close()
    'End Sub

    'Public Sub EnableView(isEnabled As Boolean) Implements ICustomerView.EnableView
    '    Me.Enabled = isEnabled
    'End Sub


End Class