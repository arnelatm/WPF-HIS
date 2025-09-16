using System.Diagnostics;

namespace AATM.Core.UI.Logging
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FrmLogViewer : System.Windows.Forms.Form
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
            txtLogs = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // txtLogs
            // 
            txtLogs.Location = new System.Drawing.Point(12, 12);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.Size = new System.Drawing.Size(594, 426);
            txtLogs.TabIndex = 0;
            // 
            // FrmLogViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(txtLogs);
            Name = "FrmLogViewer";
            Text = "FrmLogViewer";
            ResumeLayout(false);
            PerformLayout();

        }

        internal System.Windows.Forms.TextBox txtLogs;
    }
}