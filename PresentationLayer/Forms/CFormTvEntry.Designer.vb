Imports System.Windows.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CFormTvEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'CFormTvEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(867, 581)
        Me.Name = "CFormTvEntry"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    End Class
End Namespace