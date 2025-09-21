namespace AATM.App.TableManager
{
    public partial class TranslationFrm
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
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnFirst = new System.Windows.Forms.ToolStripButton();
            this._btnPrevious = new System.Windows.Forms.ToolStripButton();
            this._btnNext = new System.Windows.Forms.ToolStripButton();
            this._btnLast = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this._toolStrip.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnFirst,
            this._btnPrevious,
            this._btnNext,
            this._btnLast,
            this.tsbSave,
            this.tsbDelete});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(800, 27);
            this._toolStrip.TabIndex = 2;
            // 
            // _btnFirst
            // 
            this._btnFirst.Name = "_btnFirst";
            this._btnFirst.Size = new System.Drawing.Size(23, 22);
            this._btnFirst.Text = "|<";
            // 
            // _btnPrevious
            // 
            this._btnPrevious.Name = "_btnPrevious";
            this._btnPrevious.Size = new System.Drawing.Size(23, 22);
            this._btnPrevious.Text = "<";
            // 
            // _btnNext
            // 
            this._btnNext.Name = "_btnNext";
            this._btnNext.Size = new System.Drawing.Size(23, 22);
            this._btnNext.Text = ">";
            // 
            // _btnLast
            // 
            this._btnLast.Name = "_btnLast";
            this._btnLast.Size = new System.Drawing.Size(23, 22);
            this._btnLast.Text = ">|";
            // 
            // tsbSave
            // 
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(35, 22);
            this.tsbSave.Text = "Save";
            // 
            // tsbDelete
            // 
            this.tsbDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.tsbDelete.BackColor = System.Drawing.Color.Transparent;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(44, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 650F));
            this._tableLayoutPanel.Controls.Add(this._lblOriginal, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._dataGridView, 0, 6);
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
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 7;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.Size = new System.Drawing.Size(800, 355);
            this._tableLayoutPanel.TabIndex = 3;
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
            this._dataGridView.Location = new System.Drawing.Point(3, 133);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(794, 227);
            this._dataGridView.TabIndex = 4;
            // 
            // _txtOriginalString
            // 
            this._txtOriginalString.Location = new System.Drawing.Point(153, 3);
            this._txtOriginalString.Name = "_txtOriginalString";
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
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(70, 17);
            this.statusLabel.Text = "Status Label";
            // 
            // TranslationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._toolStrip);
            this.Name = "TranslationFrm";
            this.Text = "TranslationFrm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _btnFirst;
        private System.Windows.Forms.ToolStripButton _btnPrevious;
        private System.Windows.Forms.ToolStripButton _btnNext;
        private System.Windows.Forms.ToolStripButton _btnLast;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDelete;
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
    }
}