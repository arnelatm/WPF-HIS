// File: MyApp.UI/ TranslationForm.cs
//
// This Is the Presentation Layer. It Is responsible for the user interface
// And communicates with the Business Layer. It has no direct knowledge of
// the database Or the external translation API.

Using System;
Using System.Drawing;
Using System.Windows.Forms;
Using MyApp.Business;
Using AATM.Contracts;

Namespace MyApp.UI
{
    Partial Public Class TranslationForm :  Form
    {
        Private ReadOnly TranslationService _translationService;

        Public TranslationForm(TranslationService translationService)
        {
            InitializeComponent();
            _translationService = translationService;
            this.Load += New EventHandler(TranslationForm_Load);
        }

        Private void InitializeComponent()
        {
            // Set up the form layout And controls here.
            this.Text = "AATM Translation Tool";
            this.Size = New Size(800, 600);
            this.SuspendLayout();

            var panel = New FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = New Padding(10),
                AutoScroll = true
            };

            var originalStringLabel = New Label { Text = "Original String:", AutoSize = True, Font = New Font("Arial", 12) };
            var originalStringTextBox = New TextBox { Name = "OriginalStringTextBox", Multiline = True, Size = New Size(700, 80), Font = New Font("Arial", 12) };
            var languageCodeLabel = New Label { Text = "Language Code:", AutoSize = True, Font = New Font("Arial", 12) };
            var languageCodeTextBox = New TextBox { Name = "LanguageCodeTextBox", Size = New Size(200, 25), Font = New Font("Arial", 12) };
            var moduleNameLabel = New Label { Text = "Module Name:", AutoSize = True, Font = New Font("Arial", 12) };
            var moduleNameTextBox = New TextBox { Name = "ModuleNameTextBox", Size = New Size(200, 25), Font = New Font("Arial", 12) };
            var uiIdentifierLabel = New Label { Text = "UI Identifier:", AutoSize = True, Font = New Font("Arial", 12) };
            var uiIdentifierTextBox = New TextBox { Name = "UIIdentifierTextBox", Size = New Size(200, 25), Font = New Font("Arial", 12) };
            var translateButton = New Button { Text = "Translate", Size = New Size(150, 40), Font = New Font("Arial", 12) };
            
            var resultPanel = New TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = New Padding(10),
                ColumnCount = 2,
                RowCount = 3,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                AutoScroll = true
            };
            resultPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F));
            resultPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F));
            
            var localizedLabel = New Label { Text = "Localized String:", AutoSize = True, Font = New Font("Arial", 12, FontStyle.Bold) };
            var localizedValue = New TextBox { Name = "LocalizedValue", Multiline = True, ReadOnly = True, Dock = DockStyle.Fill, Font = New Font("Arial", 12) };
            var creationDateLabel = New Label { Text = "Creation Date:", AutoSize = True, Font = New Font("Arial", 12, FontStyle.Bold) };
            var creationDateValue = New Label { Name = "CreationDateValue", AutoSize = True, Font = New Font("Arial", 12) };

            resultPanel.Controls.Add(localizedLabel, 0, 0);
            resultPanel.Controls.Add(localizedValue, 1, 0);
            resultPanel.Controls.Add(creationDateLabel, 0, 1);
            resultPanel.Controls.Add(creationDateValue, 1, 1);

            translateButton.Click += (sender, e) =>
            {
                var originalText = originalStringTextBox.Text;
                var langCode = languageCodeTextBox.Text;
                var moduleName = moduleNameTextBox.Text;
                var uiIdentifier = uiIdentifierTextBox.Text;
                
                var translation = _translationService.Translate(originalText, langCode, moduleName, uiIdentifier);
                
                localizedValue.Text = translation.LocalizedString;
                creationDateValue.Text = translation.CreationDate.ToString();
            };

            panel.Controls.Add(originalStringLabel);
            panel.Controls.Add(originalStringTextBox);
            panel.Controls.Add(languageCodeLabel);
            panel.Controls.Add(languageCodeTextBox);
            panel.Controls.Add(moduleNameLabel);
            panel.Controls.Add(moduleNameTextBox);
            panel.Controls.Add(uiIdentifierLabel);
            panel.Controls.Add(uiIdentifierTextBox);
            panel.Controls.Add(translateButton);
            panel.Controls.Add(resultPanel);

            this.Controls.Add(panel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        Private void TranslationForm_Load(Object sender, EventArgs e)
        {
            // Placeholder for any form load logic.
        }
    }
}
