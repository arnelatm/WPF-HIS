namespace AATM.App.TableManager
{
    public partial class TranslationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this._lblOriginal = new System.Windows.Forms.Label();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._txtOriginalString = new System.Windows.Forms.TextBox();
            this._lblLocalized = new System.Windows.Forms.Label();
            this._txtLocalizedString = new System.Windows.Forms.TextBox();
            this._lblLanguage = new System.Windows.Forms.Label();
            this._txtLanguageCode = new System.Windows.Forms.TextBox();
            this._lblUIIdentifier = new System.Windows.Forms.Label();
            this._txtUIIdentifier = new System.Windows.Forms.TextBox();
            this._lblModule = new System.Windows.Forms.Label();
            this._txtModuleName = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 666F));
            this._tableLayoutPanel.Controls.Add(this.txtErrors, 0, 5);
            this._tableLayoutPanel.Controls.Add(this._lblOriginal, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._dataGridView, 0, 7);
            this._tableLayoutPanel.Controls.Add(this._txtOriginalString, 1, 0);
            this._tableLayoutPanel.Controls.Add(this._lblLocalized, 0, 1);
            this._tableLayoutPanel.Controls.Add(this._txtLocalizedString, 1, 1);
            this._tableLayoutPanel.Controls.Add(this._lblLanguage, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._txtLanguageCode, 1, 2);
            this._tableLayoutPanel.Controls.Add(this._lblUIIdentifier, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._txtUIIdentifier, 1, 3);
            this._tableLayoutPanel.Controls.Add(this._lblModule, 0, 4);
            this._tableLayoutPanel.Controls.Add(this._txtModuleName, 1, 4);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 8;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.Size = new System.Drawing.Size(816, 355);
            this._tableLayoutPanel.TabIndex = 3;
            // 
            // txtErrors
            // 
            this.txtErrors.BackColor = System.Drawing.Color.MistyRose;
            this.txtErrors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tableLayoutPanel.SetColumnSpan(this.txtErrors, 2);
            this.txtErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.ForeColor = System.Drawing.Color.DarkRed;
            this.txtErrors.Location = new System.Drawing.Point(3, 133);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrors.Size = new System.Drawing.Size(794, 44);
            this.txtErrors.TabIndex = 999;
            // 
            // _lblOriginal
            // 
            this._lblOriginal.Location = new System.Drawing.Point(3, 0);
            this._lblOriginal.Name = "_lblOriginal";
            this._lblOriginal.Size = new System.Drawing.Size(144, 20);
            this._lblOriginal.TabIndex = 0;
            this._lblOriginal.Text = "Original";
            // 
            // _dataGridView
            // 
            this._tableLayoutPanel.SetColumnSpan(this._dataGridView, 2);
            this._dataGridView.Location = new System.Drawing.Point(3, 183);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(794, 227);
            this._dataGridView.TabIndex = 4;
            // 
            // _txtOriginalString
            // 
            this._txtOriginalString.Location = new System.Drawing.Point(153, 3);
            this._txtOriginalString.Name = "_txtOriginalString";
            this._txtOriginalString.ReadOnly = true;
            this._txtOriginalString.Size = new System.Drawing.Size(644, 20);
            this._txtOriginalString.TabIndex = 1;
            // 
            // _lblLocalized
            // 
            this._lblLocalized.Location = new System.Drawing.Point(3, 26);
            this._lblLocalized.Name = "_lblLocalized";
            this._lblLocalized.Size = new System.Drawing.Size(144, 20);
            this._lblLocalized.TabIndex = 2;
            this._lblLocalized.Text = "Localized";
            // 
            // _txtLocalizedString
            // 
            this._txtLocalizedString.Location = new System.Drawing.Point(153, 29);
            this._txtLocalizedString.Name = "_txtLocalizedString";
            this._txtLocalizedString.Size = new System.Drawing.Size(644, 20);
            this._txtLocalizedString.TabIndex = 3;
            // 
            // _lblLanguage
            // 
            this._lblLanguage.Location = new System.Drawing.Point(3, 52);
            this._lblLanguage.Name = "_lblLanguage";
            this._lblLanguage.Size = new System.Drawing.Size(144, 20);
            this._lblLanguage.TabIndex = 4;
            this._lblLanguage.Text = "Language";
            // 
            // _txtLanguageCode
            // 
            this._txtLanguageCode.Location = new System.Drawing.Point(153, 55);
            this._txtLanguageCode.Name = "_txtLanguageCode";
            this._txtLanguageCode.ReadOnly = true;
            this._txtLanguageCode.Size = new System.Drawing.Size(100, 20);
            this._txtLanguageCode.TabIndex = 5;
            // 
            // _lblUIIdentifier
            // 
            this._lblUIIdentifier.Location = new System.Drawing.Point(3, 78);
            this._lblUIIdentifier.Name = "_lblUIIdentifier";
            this._lblUIIdentifier.Size = new System.Drawing.Size(144, 20);
            this._lblUIIdentifier.TabIndex = 6;
            this._lblUIIdentifier.Text = "UI Identifier";
            // 
            // _txtUIIdentifier
            // 
            this._txtUIIdentifier.Location = new System.Drawing.Point(153, 81);
            this._txtUIIdentifier.Name = "_txtUIIdentifier";
            this._txtUIIdentifier.Size = new System.Drawing.Size(322, 20);
            this._txtUIIdentifier.TabIndex = 7;
            // 
            // _lblModule
            // 
            this._lblModule.Location = new System.Drawing.Point(3, 104);
            this._lblModule.Name = "_lblModule";
            this._lblModule.Size = new System.Drawing.Size(144, 20);
            this._lblModule.TabIndex = 8;
            this._lblModule.Text = "Module";
            // 
            // _txtModuleName
            // 
            this._txtModuleName.Location = new System.Drawing.Point(153, 107);
            this._txtModuleName.Name = "_txtModuleName";
            this._txtModuleName.Size = new System.Drawing.Size(322, 20);
            this._txtModuleName.TabIndex = 9;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 380);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(816, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(70, 17);
            this.statusLabel.Text = "Status Label";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OriginalString";
            this.dataGridViewTextBoxColumn2.HeaderText = "OriginalString";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ModuleName";
            this.dataGridViewTextBoxColumn3.HeaderText = "ModuleName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UIIdentifier";
            this.dataGridViewTextBoxColumn4.HeaderText = "UIIdentifier";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LanguageCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "LanguageCode";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LocalizedString";
            this.dataGridViewTextBoxColumn6.HeaderText = "LocalizedString";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CreationDate";
            this.dataGridViewTextBoxColumn7.HeaderText = "CreationDate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // TranslationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 402);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "TranslationForm";
            this.Text = "TranslationFrm";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _lblOriginal;
        private System.Windows.Forms.TextBox _txtOriginalString;
        private System.Windows.Forms.Label _lblLocalized;
        private System.Windows.Forms.TextBox _txtLocalizedString;
        private System.Windows.Forms.Label _lblLanguage;
        private System.Windows.Forms.TextBox _txtLanguageCode;
        private System.Windows.Forms.Label _lblUIIdentifier;
        private System.Windows.Forms.TextBox _txtUIIdentifier;
        private System.Windows.Forms.Label _lblModule;
        private System.Windows.Forms.TextBox _txtModuleName;
        private System.Windows.Forms.DataGridView _dataGridView;
        public System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox txtErrors;
    }
}