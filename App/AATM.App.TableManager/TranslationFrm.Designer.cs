namespace AATM.App.TableManager
{
    partial class TranslationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslationFrm));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnFirst = new System.Windows.Forms.ToolStripButton();
            this._btnPrevious = new System.Windows.Forms.ToolStripButton();
            this._btnNext = new System.Windows.Forms.ToolStripButton();
            this._btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._lblOriginal = new System.Windows.Forms.Label();
            this._txtOriginal = new System.Windows.Forms.TextBox();
            this._lblLocalized = new System.Windows.Forms.Label();
            this._txtLocalized = new System.Windows.Forms.TextBox();
            this._lblLanguage = new System.Windows.Forms.Label();
            this._txtLanguage = new System.Windows.Forms.TextBox();
            this._lblUIIdentifier = new System.Windows.Forms.Label();
            this._txtUIIdentifier = new System.Windows.Forms.TextBox();
            this._lblModule = new System.Windows.Forms.Label();
            this._txtModule = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._statusLabel = new System.Windows.Forms.Label();
            this._toolStrip.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnFirst,
            this._btnPrevious,
            this._btnNext,
            this._btnLast,
            this.toolStripButton1,
            this.tsbDelete});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(800, 25);
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "tsbSave";
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "toolStripButton2";
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 650F));
            this._tableLayoutPanel.Controls.Add(this._lblOriginal, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._txtOriginal, 1, 0);
            this._tableLayoutPanel.Controls.Add(this._lblLocalized, 0, 1);
            this._tableLayoutPanel.Controls.Add(this._txtLocalized, 1, 1);
            this._tableLayoutPanel.Controls.Add(this._lblLanguage, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._txtLanguage, 1, 2);
            this._tableLayoutPanel.Controls.Add(this._lblUIIdentifier, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._txtUIIdentifier, 1, 3);
            this._tableLayoutPanel.Controls.Add(this._lblModule, 0, 4);
            this._tableLayoutPanel.Controls.Add(this._txtModule, 1, 4);
            this._tableLayoutPanel.Controls.Add(this._btnSave, 0, 5);
            this._tableLayoutPanel.Controls.Add(this._btnDelete, 1, 5);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 6;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(800, 171);
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
            // _txtOriginal
            // 
            this._txtOriginal.Location = new System.Drawing.Point(153, 3);
            this._txtOriginal.Name = "_txtOriginal";
            this._txtOriginal.Size = new System.Drawing.Size(644, 20);
            this._txtOriginal.TabIndex = 1;
            // 
            // _lblLocalized
            // 
            this._lblLocalized.Location = new System.Drawing.Point(3, 20);
            this._lblLocalized.Name = "_lblLocalized";
            this._lblLocalized.Size = new System.Drawing.Size(144, 20);
            this._lblLocalized.TabIndex = 2;
            this._lblLocalized.Text = "Localized";
            // 
            // _txtLocalized
            // 
            this._txtLocalized.Location = new System.Drawing.Point(153, 23);
            this._txtLocalized.Name = "_txtLocalized";
            this._txtLocalized.Size = new System.Drawing.Size(644, 20);
            this._txtLocalized.TabIndex = 3;
            // 
            // _lblLanguage
            // 
            this._lblLanguage.Location = new System.Drawing.Point(3, 40);
            this._lblLanguage.Name = "_lblLanguage";
            this._lblLanguage.Size = new System.Drawing.Size(144, 20);
            this._lblLanguage.TabIndex = 4;
            this._lblLanguage.Text = "Language";
            // 
            // _txtLanguage
            // 
            this._txtLanguage.Location = new System.Drawing.Point(153, 43);
            this._txtLanguage.Name = "_txtLanguage";
            this._txtLanguage.Size = new System.Drawing.Size(100, 20);
            this._txtLanguage.TabIndex = 5;
            // 
            // _lblUIIdentifier
            // 
            this._lblUIIdentifier.Location = new System.Drawing.Point(3, 60);
            this._lblUIIdentifier.Name = "_lblUIIdentifier";
            this._lblUIIdentifier.Size = new System.Drawing.Size(144, 20);
            this._lblUIIdentifier.TabIndex = 6;
            this._lblUIIdentifier.Text = "UI Identifier";
            // 
            // _txtUIIdentifier
            // 
            this._txtUIIdentifier.Location = new System.Drawing.Point(153, 63);
            this._txtUIIdentifier.Name = "_txtUIIdentifier";
            this._txtUIIdentifier.Size = new System.Drawing.Size(322, 20);
            this._txtUIIdentifier.TabIndex = 7;
            // 
            // _lblModule
            // 
            this._lblModule.Location = new System.Drawing.Point(3, 80);
            this._lblModule.Name = "_lblModule";
            this._lblModule.Size = new System.Drawing.Size(144, 20);
            this._lblModule.TabIndex = 8;
            this._lblModule.Text = "Module";
            // 
            // _txtModule
            // 
            this._txtModule.Location = new System.Drawing.Point(153, 83);
            this._txtModule.Name = "_txtModule";
            this._txtModule.Size = new System.Drawing.Size(322, 20);
            this._txtModule.TabIndex = 9;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(3, 103);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 10;
            this._btnSave.Text = "Save";
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(153, 103);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(100, 32);
            this._btnDelete.TabIndex = 11;
            this._btnDelete.Text = "Delete";
            // 
            // _dataGridView
            // 
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._dataGridView.Location = new System.Drawing.Point(0, 223);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(800, 227);
            this._dataGridView.TabIndex = 4;
            // 
            // _statusLabel
            // 
            this._statusLabel.AutoSize = true;
            this._statusLabel.Location = new System.Drawing.Point(12, 199);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(35, 13);
            this._statusLabel.TabIndex = 5;
            this._statusLabel.Text = "label1";
            // 
            // TranslationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._toolStrip);
            this.Name = "TranslationFrm";
            this.Text = "TranslationFrm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _btnFirst;
        private System.Windows.Forms.ToolStripButton _btnPrevious;
        private System.Windows.Forms.ToolStripButton _btnNext;
        private System.Windows.Forms.ToolStripButton _btnLast;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _lblOriginal;
        private System.Windows.Forms.TextBox _txtOriginal;
        private System.Windows.Forms.Label _lblLocalized;
        private System.Windows.Forms.TextBox _txtLocalized;
        private System.Windows.Forms.Label _lblLanguage;
        private System.Windows.Forms.TextBox _txtLanguage;
        private System.Windows.Forms.Label _lblUIIdentifier;
        private System.Windows.Forms.TextBox _txtUIIdentifier;
        private System.Windows.Forms.Label _lblModule;
        private System.Windows.Forms.TextBox _txtModule;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label _statusLabel;
    }
}