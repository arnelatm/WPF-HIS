using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AATM.Modules.Localization
{

    public partial class FrmTranslationManager : ITranslationManagerView
    {

        // UI Controls
        private ComboBox cmbLanguage;
        private DataGridView dgvTranslations;
        private Button btnSave;


        // Interface Events
        public event EventHandler LoadView;
        public event SaveTranslationEventHandler SaveTranslation;

        public delegate void SaveTranslationEventHandler(string originalString, string localizedString);
        public event LanguageChangedEventHandler LanguageChanged;

        public delegate void LanguageChangedEventHandler(string languageCode);

        public FrmTranslationManager()
        {
            cmbLanguage = new ComboBox();
            dgvTranslations = new DataGridView();
            btnSave = new Button();
            InitializeComponent();
        }

        // Interface Methods
        public void DisplayStrings(List<(string original, string localized)> translations)
        {
            dgvTranslations.Rows.Clear();
            foreach (var translation in translations)
                dgvTranslations.Rows.Add(translation.original, translation.localized);
        }

        public void DisplayLanguages(List<(string display, string code)> languages)
        {
            cmbLanguage.Items.Clear();
            foreach (var lang in languages)
                cmbLanguage.Items.Add(new { Text = lang.display, Value = lang.code });
            cmbLanguage.DisplayMember = "Text";
            cmbLanguage.ValueMember = "Value";
        }

        public void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Event Handlers
        private void FrmTranslationManager_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem is not null)
            {
                string languageCode = Conversions.ToString(cmbLanguage.SelectedItem.Value);
                LanguageChanged?.Invoke(languageCode);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Iterate through the DataGridView and raise the save event for each row that has been modified.
            foreach (DataGridViewRow row in dgvTranslations.Rows)
            {
                if (!row.IsNewRow && row.Cells["LocalizedString"].Value is not null)
                {
                    string originalString = row.Cells["OriginalString"].Value.ToString();
                    string localizedString = row.Cells["LocalizedString"].Value.ToString();
                    SaveTranslation?.Invoke(originalString, localizedString);
                }
            }
            ShowSuccessMessage("Translations saved successfully!");
        }

    }
}