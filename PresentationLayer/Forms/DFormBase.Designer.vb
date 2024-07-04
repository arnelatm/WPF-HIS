<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DFormBase
    Inherits AATM.Libraries.CBaseControlsLibrary.DForm

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
        Me.TranslatorDac = New AATM.Libraries.MessagingLibrary.Dac()
        Me.StoreCaptions1 = New AATM.Libraries.MessagingLibrary.StoreCaptions()
        Me.AppDataDac = New AATM.Libraries.MessagingLibrary.Dac()
        Me.SuspendLayout()
        '
        'TranslatorDac
        '
        Me.TranslatorDac.Cs = ""
        '
        'AppDataDac
        '
        Me.AppDataDac.Cs = ""
        '
        'DFormBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Name = "DFormBase"
        Me.Text = "DFormBase"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TranslatorDac As Libraries.MessagingLibrary.Dac
    Friend WithEvents StoreCaptions1 As Libraries.MessagingLibrary.StoreCaptions
    Friend WithEvents AppDataDac As Libraries.MessagingLibrary.Dac
End Class
