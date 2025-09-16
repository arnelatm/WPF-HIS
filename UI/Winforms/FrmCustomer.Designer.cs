using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Winforms
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FrmCustomer : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            btnSave = new Button();
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel = new Button();
            txtCustomerID = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            _StatusStrip = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            lblCustomerID = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            dgvCustomers = new DataGridView();
            dgvCustomers.CellClick += new DataGridViewCellEventHandler(dgvCustomers_CellClick);
            btnDelete = new Button();
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnClear = new Button();
            btnClear.Click += new EventHandler(btnClear_Click);
            cmbLanguage = new ComboBox();
            cmbLanguage.SelectedIndexChanged += new EventHandler(cmbLanguage_SelectedIndexChanged);
            lblLanguage = new Label();
            _StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(270, 332);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(68, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(379, 332);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(68, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Location = new Point(316, 205);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(82, 20);
            txtCustomerID.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(316, 231);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(179, 20);
            txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(316, 257);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(179, 20);
            txtLastName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(316, 283);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(179, 20);
            txtEmail.TabIndex = 5;
            // 
            // StatusStrip
            // 
            _StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1 });
            _StatusStrip.Location = new Point(0, 380);
            _StatusStrip.Name = "_StatusStrip";
            _StatusStrip.Size = new Size(788, 22);
            _StatusStrip.TabIndex = 6;
            _StatusStrip.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(119, 17);
            ToolStripStatusLabel1.Text = "ToolStripStatusLabel1";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(217, 206);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(65, 13);
            lblCustomerID.TabIndex = 7;
            lblCustomerID.Text = "Customer ID";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(217, 234);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(57, 13);
            lblFirstName.TabIndex = 8;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(217, 260);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(58, 13);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "Last Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(217, 286);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(73, 13);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email Address";
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(34, 24);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(716, 150);
            dgvCustomers.TabIndex = 11;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(483, 332);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(68, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(583, 332);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(68, 23);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(126, 334);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 21);
            cmbLanguage.TabIndex = 14;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(31, 332);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(55, 13);
            lblLanguage.TabIndex = 15;
            lblLanguage.Text = "Language";
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 402);
            Controls.Add(lblLanguage);
            Controls.Add(cmbLanguage);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(dgvCustomers);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblCustomerID);
            Controls.Add(_StatusStrip);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtCustomerID);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "FormCustomer";
            Text = "FormCustomer";
            _StatusStrip.ResumeLayout(false);
            _StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            Load += new EventHandler(FrmView_Load);
            Load += new EventHandler(FrmCustomer_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Button btnSave;
        internal Button btnCancel;
        internal TextBox txtCustomerID;
        internal TextBox txtFirstName;
        internal TextBox txtLastName;
        internal TextBox txtEmail;
        internal Label lblCustomerID;
        internal Label lblFirstName;
        internal Label lblLastName;
        internal Label lblEmail;
        internal DataGridView dgvCustomers;
        private StatusStrip _StatusStrip;

        public virtual StatusStrip StatusStrip
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StatusStrip;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StatusStrip = value;
            }
        }
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal Button btnDelete;
        internal Button btnClear;
        internal ComboBox cmbLanguage;
        internal Label lblLanguage;
    }
}