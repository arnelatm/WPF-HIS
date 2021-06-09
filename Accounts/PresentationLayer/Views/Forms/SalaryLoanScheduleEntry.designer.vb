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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CTreeView1 = New AATM.Libraries.CBaseControlsLibrary.CTreeView()
        Me.SalaryLoanScheduleView = New AATM.Accounts.PresentationLayer.Views.SalaryLoanScheduleView()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
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
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CTreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.SalaryLoanScheduleView)
        '
        'CTreeView1
        '
        resources.ApplyResources(Me.CTreeView1, "CTreeView1")
        Me.CTreeView1.Name = "CTreeView1"
            '
            'SalaryLoanScheduleView
            '
            resources.ApplyResources(Me.SalaryLoanScheduleView, "SalaryLoanScheduleView")
            Me.SalaryLoanScheduleView.Name = "SalaryLoanScheduleView"
            '
            'SalaryLoanScheduleEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.SplitContainer1)
            Me.Name = "SalaryLoanScheduleEntry"
            Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents SalaryLoanScheduleView As SalaryLoanScheduleView
        Friend WithEvents CTreeView1 As CTreeView
    End Class
End Namespace