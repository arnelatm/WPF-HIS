Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CashDisbursementJournalReport
        Inherits CrReportViewer

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnOk
            '
            Me.btnOk.Location = New System.Drawing.Point(280, 182)
            Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(379, 182)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(731, 181)
            '
            'btnQuit
            '
            Me.btnQuit.Location = New System.Drawing.Point(737, 0)
            '
            'AccountReconciliationReport
            '
            Me.ClientSize = New System.Drawing.Size(759, 228)
            Me.Margin = New System.Windows.Forms.Padding(2)
            Me.Name = "AccountReconciliationReport"
            Me.Text = "Account Reconciliation Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace