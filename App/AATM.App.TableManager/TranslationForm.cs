using AATM.Contracts.Dtos;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace AATM.App.TableManager
{
    public partial class TranslationForm 
    {
        // UI controls
        private DataGridView _dataGridView;
        private TextBox _txtModuleName;
        private TextBox _txtUIIdentifier;
        private TextBox _txtOriginalString;
        private TextBox _txtLanguageCode;
        private TextBox _txtLocalizedString;
        private Button _btnSave;
        private Label _statusLabel;

        // Toolbar controls
        private ToolStrip _toolStrip;
        private ToolStripButton _btnFirst;
        private ToolStripButton _btnPrevious;
        private ToolStripButton _btnNext;
        private ToolStripButton _btnLast;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripButton _btnAdd;
        private ToolStripButton _btnDelete;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripLabel _lblFind;
        private ToolStripTextBox _txtFind;
        private ToolStripButton _btnFind;
        private ToolStripSeparator _toolStripSeparator3;
        private ToolStripButton _btnImport;
        private ToolStripButton _btnExport;

        private readonly TranslationDbService _dbService;
        private List<TranslationDto> _allTranslations;

        public TranslationForm()
        {
            _dbService = new TranslationDbService();
            InitializeComponent();
            ThisInitializeComponent();
            LoadTranslationsAsync();
        }

        private void ThisInitializeComponent()
        {
            this.Text = "Translation Management Dashboard";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9);

            // Main Layout Panel
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                ColumnCount = 2,
                RowCount = 3,
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Toolbar row
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Content row
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Status bar row
            Controls.Add(mainLayout);

            // --- Toolbar ---
            _toolStrip = new ToolStrip();
            _btnFirst = new ToolStripButton("|<") { Text = "First" };
            _btnPrevious = new ToolStripButton("<") { Text = "Previous" };
            _btnNext = new ToolStripButton(">") { Text = "Next" };
            _btnLast = new ToolStripButton(">|") { Text = "Last" };
            _btnAdd = new ToolStripButton("Add") { Text = "Add" };
            _btnDelete = new ToolStripButton("Delete") { Text = "Delete" };
            _lblFind = new ToolStripLabel("Find:");
            _txtFind = new ToolStripTextBox();
            _btnFind = new ToolStripButton("Find");
            _btnImport = new ToolStripButton("Import");
            _btnExport = new ToolStripButton("Export");
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripSeparator2 = new ToolStripSeparator();
            _toolStripSeparator3 = new ToolStripSeparator();

            _toolStrip.Items.AddRange(new ToolStripItem[] {
            _btnFirst, _btnPrevious, _btnNext, _btnLast, _toolStripSeparator1,
            _btnAdd, _btnDelete, _toolStripSeparator2, _lblFind, _txtFind, _btnFind,
            _toolStripSeparator3, _btnImport, _btnExport
        });

            _btnFirst.Click += (s, e) => NavigateToRow(0);
            _btnPrevious.Click += (s, e) => NavigateToRow(_dataGridView.SelectedRows.Count > 0 ? _dataGridView.SelectedRows[0].Index - 1 : 0);
            _btnNext.Click += (s, e) => NavigateToRow(_dataGridView.SelectedRows.Count > 0 ? _dataGridView.SelectedRows[0].Index + 1 : 0);
            _btnLast.Click += (s, e) => NavigateToRow(_dataGridView.Rows.Count - 1);
            _btnAdd.Click += (s, e) => ClearFormFields();
            _btnDelete.Click += async (s, e) => await DeleteTranslationAsync();
            _btnFind.Click += (s, e) => FindTranslation(_txtFind.Text);
            _btnImport.Click += async (s, e) => await ImportTranslationsAsync();
            _btnExport.Click += async (s, e) => await ExportTranslationsAsync();

            mainLayout.Controls.Add(_toolStrip, 0, 0);
            mainLayout.SetColumnSpan(_toolStrip, 2);

            // --- Data Grid View (left panel) ---
            _dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundColor = Color.White,
            };
            _dataGridView.DoubleClick += (sender, e) =>
            {
                if (_dataGridView.SelectedRows.Count > 0)
                {
                    PopulateFormFieldsFromGrid(_dataGridView.SelectedRows[0].Index);
                }
            };
            mainLayout.Controls.Add(_dataGridView, 0, 1);

            // --- Input Panel (right panel) ---
            TableLayoutPanel inputPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 10,
                Padding = new Padding(10),
            };
            inputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.Controls.Add(inputPanel, 1, 1);

            // Add labels and text boxes
            AddLabeledTextBox(inputPanel, "Module Name", ref _txtModuleName);
            AddLabeledTextBox(inputPanel, "UI Identifier", ref _txtUIIdentifier);
            AddLabeledTextBox(inputPanel, "Original String", ref _txtOriginalString, true);
            AddLabeledTextBox(inputPanel, "Language Code", ref _txtLanguageCode);
            AddLabeledTextBox(inputPanel, "Localized String", ref _txtLocalizedString, true);

            // Add Save button
            _btnSave = new Button { Text = "Save", Width = 80, Height = 30, Dock = DockStyle.Right };
            _btnSave.Click += async (sender, e) => await SaveOrUpdateTranslationAsync();
            inputPanel.Controls.Add(_btnSave);

            // --- Status Label (bottom) ---
            _statusLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Ready",
                ForeColor = Color.DarkSlateGray
            };
            mainLayout.Controls.Add(_statusLabel, 0, 2);
            mainLayout.SetColumnSpan(_statusLabel, 2);
        }

        private void AddLabeledTextBox(TableLayoutPanel panel, string labelText, ref TextBox textBox, bool multiline = false)
        {
            Label label = new Label { Text = labelText, Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomLeft };
            textBox = new TextBox { Dock = DockStyle.Fill };
            if (multiline)
            {
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Height = 80;
            }
            panel.Controls.Add(label);
            panel.Controls.Add(textBox);
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
    }
}
