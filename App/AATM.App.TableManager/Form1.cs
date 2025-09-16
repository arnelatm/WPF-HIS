using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AATM.Services;
using AATM.Contracts.Dtos;

// --- 3. Main Windows Form ---
// This class defines the UI and handles all user interactions.
public class TranslationForm : Form
{
    // UI controls
    private DataGridView _dataGridView;
    private TextBox _txtModuleName;
    private TextBox _txtUIIdentifier;
    private TextBox _txtOriginalString;
    private TextBox _txtLanguageCode;
    private TextBox _txtLocalizedString;
    private Button _btnSave;
    private Button _btnNew;
    private Button _btnDelete;
    private Label _statusLabel;

    private readonly TranslationDbService _dbService;

    public TranslationForm()
    {
        _dbService = new TranslationDbService();
        InitializeComponent();
        LoadTranslationsAsync();
    }

    private void InitializeComponent()
    {
        // Form properties
        Text = "Translation Management Dashboard";
        Size = new Size(1000, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9);

        // Layout setup
        TableLayoutPanel mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
            ColumnCount = 2,
            RowCount = 2,
        };
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // Data grid column
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // Input panel column
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        Controls.Add(mainLayout);

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
        _dataGridView.DoubleClick += (sender, e) => {
            if (_dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = _dataGridView.SelectedRows[0];
                int id = (int)selectedRow.Cells["ID"].Value;
                var selectedTranslation = _dbService.GetAllTranslationsAsync().Result.FirstOrDefault(t => t.ID == id);
                if (selectedTranslation != null)
                {
                    PopulateFormFields(selectedTranslation);
                }
            }
        };
        mainLayout.Controls.Add(_dataGridView, 0, 0);

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
        mainLayout.Controls.Add(inputPanel, 1, 0);

        // Add labels and text boxes
        AddLabeledTextBox(inputPanel, "Module Name", ref _txtModuleName);
        AddLabeledTextBox(inputPanel, "UI Identifier", ref _txtUIIdentifier);
        AddLabeledTextBox(inputPanel, "Original String", ref _txtOriginalString, true);
        AddLabeledTextBox(inputPanel, "Language Code", ref _txtLanguageCode);
        AddLabeledTextBox(inputPanel, "Localized String", ref _txtLocalizedString, true);

        // Add buttons
        FlowLayoutPanel buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
        };
        _btnNew = new Button { Text = "New", Width = 80, Height = 30 };
        _btnNew.Click += (sender, e) => ClearFormFields();
        _btnSave = new Button { Text = "Save", Width = 80, Height = 30 };
        _btnSave.Click += (sender, e) => SaveOrUpdateTranslationAsync();
        _btnDelete = new Button { Text = "Delete", Width = 80, Height = 30 };
        _btnDelete.Click += (sender, e) => DeleteTranslationAsync();

        buttonPanel.Controls.Add(_btnSave);
        buttonPanel.Controls.Add(_btnDelete);
        buttonPanel.Controls.Add(_btnNew);
        inputPanel.Controls.Add(buttonPanel);

        // --- Status Label (bottom) ---
        _statusLabel = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "Ready",
            ForeColor = Color.DarkSlateGray
        };
        mainLayout.Controls.Add(_statusLabel, 0, 1);
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
            var translations = await _dbService.GetAllTranslationsAsync();
            _dataGridView.DataSource = translations;
            _statusLabel.Text = $"Loaded {translations.Count} translations.";
        }
        catch (Exception ex)
        {
            _statusLabel.Text = $"Error loading data: {ex.Message}";
        }
    }


    // This method has been updated to use the new UpsertTranslationAsync method.
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
            // If a row is selected, this is an update operation.
            int id = (int)_dataGridView.SelectedRows[0].Cells["ID"].Value;
            dto.ID = id;
        }

        try
        {
            // Now, we just call a single method, regardless of whether it's an insert or update.
            var result = await _dbService.UpsertTranslationAsync(dto);
            _statusLabel.Text = $"Translation with ID {result} saved successfully.";
            LoadTranslationsAsync();
            ClearFormFields();
        }
        catch (Exception ex)
        {
            _statusLabel.Text = $"Error saving translation: {ex.Message}";
        }
    }

    //private async void SaveOrUpdateTranslationAsync()
    //{
    //    var dto = new TranslationDto
    //    {
    //        ModuleName = _txtModuleName.Text,
    //        UIIdentifier = _txtUIIdentifier.Text,
    //        OriginalString = _txtOriginalString.Text,
    //        LanguageCode = _txtLanguageCode.Text,
    //        LocalizedString = _txtLocalizedString.Text
    //    };

    //    try
    //    {
    //        if (_dataGridView.SelectedRows.Count > 0)
    //        {
    //            // This is an update operation
    //            int id = (int)_dataGridView.SelectedRows[0].Cells["ID"].Value;
    //            dto.ID = id;
    //            await _dbService.UpdateTranslationAsync(dto);
    //            _statusLabel.Text = $"Translation with ID {id} updated successfully.";
    //        }
    //        else
    //        {
    //            // This is an add operation
    //            await _dbService.AddTranslationAsync(dto);
    //            _statusLabel.Text = "New translation added successfully.";
    //        }
    //        LoadTranslationsAsync();
    //        ClearFormFields();
    //    }
    //    catch (Exception ex)
    //    {
    //        _statusLabel.Text = $"Error saving translation: {ex.Message}";
    //    }
    //}

    private async void DeleteTranslationAsync()
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

    private void PopulateFormFields(TranslationDto dto)
    {
        _txtModuleName.Text = dto.ModuleName;
        _txtUIIdentifier.Text = dto.UIIdentifier;
        _txtOriginalString.Text = dto.OriginalString;
        _txtLanguageCode.Text = dto.LanguageCode;
        _txtLocalizedString.Text = dto.LocalizedString;
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
}