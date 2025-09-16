// File: MyApp.UI/TranslationForm.cs
//
// This is the Presentation Layer. It is responsible for the user interface
// and communicates with the Business Layer. It has no direct knowledge of
// the database or the external translation API.

using System;
using System.Drawing;
using System.Windows.Forms;
using AATM.Business.Logic;

namespace AATM.UI
{
    public partial class TranslationForm : Form
    {
        private readonly TranslationService _translationService;

        public TranslationForm(TranslationService translationService)
        {
            InitializeComponent();
            _translationService = translationService;
            this.Load += new EventHandler(TranslationForm_Load);
        }

        private void InitializeComponent()
        {
            // Set up the form layout and controls here.
            this.Text = "AATM Translation Tool";
            this.Size = new Size(800, 600);
            this.SuspendLayout();

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoScroll = true
            };

            var originalStringLabel = new Label { Text = "Original String:", AutoSize = true, Font = new Font("Arial", 12) };
            var originalStringTextBox = new TextBox { Name = "OriginalStringTextBox", Multiline = true, Size = new Size(700, 80), Font = new Font("Arial", 12) };
            var languageCodeLabel = new Label { Text = "Language Code:", AutoSize = true, Font = new Font("Arial", 12) };
            var languageCodeTextBox = new TextBox { Name = "LanguageCodeTextBox", Size = new Size(200, 25), Font = new Font("Arial", 12) };
            var moduleNameLabel = new Label { Text = "Module Name:", AutoSize = true, Font = new Font("Arial", 12) };
            var moduleNameTextBox = new TextBox { Name = "ModuleNameTextBox", Size = new Size(200, 25), Font = new Font("Arial", 12) };
            var uiIdentifierLabel = new Label { Text = "UI Identifier:", AutoSize = true, Font = new Font("Arial", 12) };
            var uiIdentifierTextBox = new TextBox { Name = "UIIdentifierTextBox", Size = new Size(200, 25), Font = new Font("Arial", 12) };
            var translateButton = new Button { Text = "Translate", Size = new Size(150, 40), Font = new Font("Arial", 12) };

            var resultPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                ColumnCount = 2,
                RowCount = 3,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                AutoScroll = true
            };
            resultPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            resultPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            var localizedLabel = new Label { Text = "Localized String:", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            var localizedValue = new TextBox { Name = "LocalizedValue", Multiline = true, ReadOnly = true, Dock = DockStyle.Fill, Font = new Font("Arial", 12) };
            var creationDateLabel = new Label { Text = "Creation Date:", AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            var creationDateValue = new Label { Name = "CreationDateValue", AutoSize = true, Font = new Font("Arial", 12) };

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

        private void TranslationForm_Load(object sender, EventArgs e)
        {
            // Placeholder for any form load logic.
        }
    }
}
