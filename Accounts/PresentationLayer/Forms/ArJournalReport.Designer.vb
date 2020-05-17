Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ArJournalReport
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
            Me.btnOk.Location = New System.Drawing.Point(338, 187)
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(419, 187)
            Me.btnCancel.Visible = False
            '
            'btnQuit
            '
            Me.btnQuit.Location = New System.Drawing.Point(776, 0)
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(774, 181)
            '
            'ArJournalReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Name = "ArJournalReport"
            Me.Text = "ArJournalReport"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End NameSpace