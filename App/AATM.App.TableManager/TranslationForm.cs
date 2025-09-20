// TranslationForm.cs
using AATM.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.App.TableManager 
{
    public partial class TranslationForm : Form
    {
        private readonly TranslationDbService _dbService;
        private List<TranslationDto> _allTranslations;


        public TranslationForm()
        {
            _dbService = new TranslationDbService();
            InitializeComponent();
            // --- Status Label (bottom) ---

            _statusLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Ready",
                ForeColor = Color.DarkSlateGray
            };
            LoadTranslationsAsync();
        }

        // Plan (pseudocode):
        // - Fix CS0201 caused by a bare method group `SaveOrUpdateTranslationAsync;` used as a statement.
        // - Convert the event handler to async void and properly await the async method.
        // - Keep method signature compatible with WinForms event handlers.

        // Replacement for the BtnSave_Click event handler
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            await SaveOrUpdateTranslationAsync();
        }

        // Replacement for the BtnDelete_Click event handler
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            await DeleteTranslationAsync();
        }

        // Replacement for the BtnDelete_Click event handler
        private async void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            // await DeleteTranslationAsync();
        }

        private async void LoadTranslationsAsync()
        {
            
            _statusLabel.Text = "Loading translations...";
            try
            {
                _allTranslations = await _dbService.GetAllTranslationsAsync();
                _dataGridView.DataSource = _allTranslations;
                _statusLabel.Text = $"Loaded {_allTranslations.Count} translations.";
                if (_allTranslations.Count > 0)
                {
                    NavigateToRow(0);
                }
            }
            catch (Exception ex)
            {
                _statusLabel.Text = $"Error loading data: {ex.Message}";
            }
        }

        private void NavigateToRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < _dataGridView.Rows.Count)
            {
                _dataGridView.ClearSelection();
                _dataGridView.Rows[rowIndex].Selected = true;
                _dataGridView.FirstDisplayedScrollingRowIndex = rowIndex;
                PopulateFormFieldsFromGrid(rowIndex);
            }
        }

        private void FindTranslation(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var match = _allTranslations.FirstOrDefault(t =>
                (!string.IsNullOrEmpty(t.OriginalString) && t.OriginalString.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(t.UIIdentifier) && t.UIIdentifier.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0));

            if (match != null)
            {
                int rowIndex = _allTranslations.IndexOf(match);
                NavigateToRow(rowIndex);
            }
            else
            {
                MessageBox.Show("No matching translation found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];
            _txtModuleName.Text = row.Cells["ModuleName"].Value?.ToString() ?? string.Empty;
            _txtUIIdentifier.Text = row.Cells["UIIdentifier"].Value?.ToString() ?? string.Empty;
            _txtOriginalString.Text = row.Cells["OriginalString"].Value?.ToString() ?? string.Empty;
            _txtLanguageCode.Text = row.Cells["LanguageCode"].Value?.ToString() ?? string.Empty;
            _txtLocalizedString.Text = row.Cells["LocalizedString"].Value?.ToString() ?? string.Empty;
        }

        private async Task SaveOrUpdateTranslationAsync()
        {
            var dto = new TranslationDto
            {
                ModuleName = _txtModuleName.Text,
                UIIdentifier = _txtUIIdentifier.Text,
                OriginalString = _txtOriginalString.Text,
                LanguageCode = _txtLanguageCode.Text,
                LocalizedString = _txtLocalizedString.Text
            };

            if (_dataGridView.SelectedRows.Count > 0)
            {
                int id = (int)_dataGridView.SelectedRows[0].Cells["ID"].Value;
                dto.ID = id;
            }

            try
            {
                var result = await _dbService.UpsertTranslationAsync(dto);
                _statusLabel.Text = $"Translation with ID {result.ID} saved successfully.";
                LoadTranslationsAsync();
                ClearFormFields();
            }
            catch (Exception ex)
            {
                _statusLabel.Text = $"Error saving translation: {ex.Message}";
            }
        }

        private async Task DeleteTranslationAsync()
        {
            if (_dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a translation to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogResult = MessageBox.Show("Are you sure you want to delete this translation?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int id = (int)_dataGridView.SelectedRows[0].Cells["ID"].Value;
                    bool success = await _dbService.DeleteTranslationAsync(id);
                    if (success)
                    {
                        _statusLabel.Text = $"Translation with ID {id} deleted successfully.";
                        LoadTranslationsAsync();
                    }
                    else
                    {
                        _statusLabel.Text = $"Failed to delete translation with ID {id}.";
                    }
                }
                catch (Exception ex)
                {
                    _statusLabel.Text = $"Error deleting translation: {ex.Message}";
                }
            }
        }

        private void ClearFormFields()
        {
            _txtModuleName.Text = string.Empty;
            _txtUIIdentifier.Text = string.Empty;
            _txtOriginalString.Text = string.Empty;
            _txtLanguageCode.Text = string.Empty;
            _txtLocalizedString.Text = string.Empty;
            _dataGridView.ClearSelection();
        }

        private async Task ImportTranslationsAsync()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.Title = "Import Translations from CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var translationsToImport = new List<TranslationDto>();
                        using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                        {
                            // Skip header row
                            string headerLine = await reader.ReadLineAsync();
                            string line;
                            while ((line = await reader.ReadLineAsync()) != null)
                            {
                                string[] values = line.Split(',');
                                if (values.Length >= 5)
                                {
                                    translationsToImport.Add(new TranslationDto
                                    {
                                        ModuleName = values[0],
                                        UIIdentifier = values[1],
                                        OriginalString = values[2],
                                        LanguageCode = values[3],
                                        LocalizedString = values[4]
                                    });
                                }
                            }
                        }

                        int count = 0;
                        foreach (var dto in translationsToImport)
                        {
                            await _dbService.UpsertTranslationAsync(dto);
                            count++;
                            _statusLabel.Text = $"Importing... {count} of {translationsToImport.Count} records.";
                        }

                        LoadTranslationsAsync();
                        _statusLabel.Text = $"Imported {count} translations successfully.";
                    }
                    catch (Exception ex)
                    {
                        _statusLabel.Text = $"Error importing file: {ex.Message}";
                    }
                }
            }
        }

        private async Task ExportTranslationsAsync()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveFileDialog.Title = "Export Translations to CSV";
                saveFileDialog.FileName = "Translations.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var allTranslations = await _dbService.GetAllTranslationsAsync();
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Write header
                            await writer.WriteLineAsync("ModuleName,UIIdentifier,OriginalString,LanguageCode,LocalizedString");

                            // Write data
                            foreach (var t in allTranslations)
                            {
                                await writer.WriteLineAsync($"{t.ModuleName},{t.UIIdentifier},{t.OriginalString},{t.LanguageCode},{t.LocalizedString}");
                            }
                        }
                        _statusLabel.Text = $"Exported {allTranslations.Count} translations successfully.";
                    }
                    catch (Exception ex)
                    {
                        _statusLabel.Text = $"Error exporting file: {ex.Message}";
                    }
                }
            }
        }

        private void _btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void _tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
