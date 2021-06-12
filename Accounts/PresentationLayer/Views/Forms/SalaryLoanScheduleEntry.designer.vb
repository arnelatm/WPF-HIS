Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SalaryLoanScheduleEntry
        Inherits CFormEntryNew

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalaryLoanScheduleEntry))
            Me.SalaryLoanScheduleView = New AATM.Accounts.PresentationLayer.Views.SalaryLoanScheduleView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'SalaryLoanScheduleView
            '
            Me.SalaryLoanScheduleView.BackColor = System.Drawing.Color.Transparent
            resources.ApplyResources(Me.SalaryLoanScheduleView, "SalaryLoanScheduleView")
            Me.SalaryLoanScheduleView.Name = "SalaryLoanScheduleView"
            '
            'SalaryLoanScheduleEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.SalaryLoanScheduleView)
            Me.Name = "SalaryLoanScheduleEntry"
            Me.Controls.SetChildIndex(Me.SalaryLoanScheduleView, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout

End Sub

        Friend WithEvents SalaryLoanScheduleView As SalaryLoanScheduleView
    End Class
End Namespace