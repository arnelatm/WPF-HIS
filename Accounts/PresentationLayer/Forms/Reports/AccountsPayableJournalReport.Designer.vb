Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms.Reports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountsPayableJournalReport
        Inherits CrReportViewer

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = True
            Me.btnOk.Location = New System.Drawing.Point(341, 187)
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(422, 187)
            Me.btnCancel.Visible = False
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(759, 181)
            '
            'AccountsPayableJournalReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(759, 228)
            Me.Name = "AccountsPayableJournalReport"
            Me.Text = "AccountsPayableJournalReport"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End NameSpace