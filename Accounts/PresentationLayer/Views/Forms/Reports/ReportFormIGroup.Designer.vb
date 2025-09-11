Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms.Reports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportFormIGroup
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
            Me.btnOk.DesignerSelected = False
            Me.btnOk.Location = New System.Drawing.Point(0, 415)
            Me.btnOk.Visible = False
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = True
            Me.btnCancel.Location = New System.Drawing.Point(362, 415)
            Me.btnCancel.Text = "Close"
            '
            'btnQuit
            '
            Me.btnQuit.Location = New System.Drawing.Point(766, 12)
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(760, 409)
            '
            'ReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Name = "ReportForm"
            Me.Text = "Report Form"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace