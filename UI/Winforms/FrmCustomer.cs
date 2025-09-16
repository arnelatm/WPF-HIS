using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AATM.Core.Localization;
using AATM.Modules.Customers;
using Microsoft.VisualBasic.CompilerServices;

namespace Winforms
{

    public partial class FrmCustomer : ICustomerView
    {

        // Private _components As System.ComponentModel.IContainer

        public FrmCustomer()
        {
            InitializeComponent();
            // Populate the language dropdown
            cmbLanguage.Items.Add(new { Text = "English", Value = "en-US" });
            cmbLanguage.Items.Add(new { Text = "العربية", Value = "ar-SA" });
            cmbLanguage.DisplayMember = "Text";
            cmbLanguage.ValueMember = "Value";
            cmbLanguage.SelectedIndex = 0;
            StoreOriginalTags(Controls);
            StatusStrip = _StatusStrip;
            _StatusStrip.Name = "StatusStrip";
        }

        public FrmCustomer(CustomerPresenter presenter) : this()
        {
            _presenter = presenter;
            // Note: In a real app, these controls would be created in the designer.
            // Me.MainStatusStrip = New StatusStrip()
            // Me.Controls.Add(Me.MainStatusStrip)
        }

        // This is the Presenter that the View will communicate with.
        private readonly CustomerPresenter _presenter;
        // Events that the presenter subscribes to.
        public event EventHandler LoadView;
        public event ICustomerView.SaveCustomerEventHandler SaveCustomer;
        public event ICustomerView.EditCustomerEventHandler EditCustomer;
        public event ICustomerView.DeleteCustomerEventHandler DeleteCustomer;
        public event EventHandler ClearView;
        public event ICustomerView.LanguageChangedEventHandler LanguageChanged;

        private void FrmView_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayCustomers(List<CustomerDTO> customers)
        {
            dgvCustomers.DataSource = customers;
        }

        public void ClearCustomerDetails()
        {
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
        }

        public void SetEditMode(bool isEditing)
        {
            btnDelete.Enabled = isEditing;
        }

        public void SetRightToLeft(bool isRtl)
        {
            RightToLeftLayout = isRtl;
            RightToLeft = isRtl ? RightToLeft.Yes : RightToLeft.No;
        }

        public void DisplayCustomerDetails(CustomerDTO customer)
        {
            txtCustomerID.Text = customer.CustomerID.ToString();
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtEmail.Text = customer.Email;
        }

        // Event Handlers
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var customer = new CustomerDTO();
            if (!string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                customer.CustomerID = int.Parse(txtCustomerID.Text);
            }
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Email = txtEmail.Text;
            SaveCustomer?.Invoke(customer);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                int customerID = int.Parse(txtCustomerID.Text);
                DeleteCustomer?.Invoke(customerID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearView?.Invoke(this, EventArgs.Empty);
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CustomerDTO customer = (CustomerDTO)dgvCustomers.Rows[e.RowIndex].DataBoundItem;
                EditCustomer?.Invoke(customer);
            }
        }

        // ' Dispose method to clean up components
        // Protected Overrides Sub Dispose(disposing As Boolean)
        // If disposing AndAlso (_components IsNot Nothing) Then
        // _components.Dispose()
        // End If
        // MyBase.Dispose(disposing)
        // End Sub

        public int GetSelectedCustomerID()
        {
            throw new NotImplementedException();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem is not null)
            {
                string languageCode = Conversions.ToString(cmbLanguage.SelectedItem.Value);
                LanguageChanged?.Invoke(languageCode);
            }
        }

        /// <summary>
    /// Now simply calls the UI manager to translate the form.
    /// </summary>
        public void SetLocalizedText(IUiLocalizationManager uiLocalizationManager, Dictionary<string, string> localizedStrings)
        {
            uiLocalizationManager.SetLocalizedText(this, localizedStrings);
        }


        // ''' <summary>
        // ''' Sets the UI text on the controls using the provided localized strings.
        // ''' </summary>
        // Public Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String)) Implements ICustomerView.SetLocalizedText
        // Me.Text = localizedStrings("CustomerFormTitle")

        // For Each control As Control In Me.Controls
        // If control.Tag IsNot Nothing AndAlso localizedStrings.ContainsKey(CStr(control.Tag)) Then
        // control.Text = localizedStrings(CStr(control.Tag))
        // End If
        // Next
        // End Sub


        // Public Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String)) Implements ICustomerView.SetLocalizedText
        // Me.Text = localizedStrings("CustomerFormTitle")
        // Me.Controls("lblFirstName").Text = localizedStrings("FirstNameLabel")
        // Me.Controls("lblLastName").Text = localizedStrings("LastNameLabel")
        // Me.Controls("lblEmail").Text = localizedStrings("EmailLabel")
        // Me.Controls("lblLanguage").Text = localizedStrings("LanguageLabel")
        // Me.Controls("btnSave").Text = localizedStrings("SaveButtonText")
        // Me.Controls("btnDelete").Text = localizedStrings("DeleteButtonText")
        // Me.Controls("btnClear").Text = localizedStrings("ClearButtonText")
        // End Sub

        public void DisplayLanguages(List<(string display, string code)> languages)
        {
            cmbLanguage.Items.Clear();
            foreach (var lang in languages)
                cmbLanguage.Items.Add(new { Text = lang.display, Value = lang.code });
            cmbLanguage.DisplayMember = "Text";
            cmbLanguage.ValueMember = "Value";
        }

        /// <summary>
    /// Recursively stores the original text of each control in its Tag property.
    /// </summary>
        private void StoreOriginalTags(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (!string.IsNullOrWhiteSpace(control.Text))
                {
                    // For our simple text-based localization, we'll use the original text as the key.
                    control.Tag = control.Text;
                }

                if (control.HasChildren)
                {
                    StoreOriginalTags(control.Controls);
                }
            }
            // The form's title is not in the Controls collection, so we set it manually.
            Tag = "Customer Management";
        }




        // Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        // Dim customerToSave As New CustomerDTO()
        // customerToSave.FirstName = Me.txtFirstName.Text
        // customerToSave.LastName = Me.txtLastName.Text
        // customerToSave.Email = Me.txtEmail.Text

        // RaiseEvent SaveCustomer(customerToSave)
        // End Sub

        // Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        // Me.Close()
        // End Sub

        // Public Sub EnableView(isEnabled As Boolean) Implements ICustomerView.EnableView
        // Me.Enabled = isEnabled
        // End Sub


    }
}