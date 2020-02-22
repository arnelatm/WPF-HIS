Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TrialBalanceYearlyReport
        Inherits CrReportViewer

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtReportYear = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(120, 192)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(216, 192)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(1, 2)
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(404, 185)
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(458, 0)
        '
        'txtReportYear
        '
        Me.txtReportYear.AcceptsReturn = false
        Me.txtReportYear.AcceptsTab = false
        Me.txtReportYear.BackColor = System.Drawing.Color.White
        Me.txtReportYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReportYear.ComputedValue = false
        Me.txtReportYear.DataBoundControl = true
        Me.txtReportYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReportYear.ForeColor = System.Drawing.Color.Black
        Me.txtReportYear.LinkedLabel = Nothing
        Me.txtReportYear.Location = New System.Drawing.Point(168, 76)
        Me.txtReportYear.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReportYear.Name = "txtReportYear"
        Me.txtReportYear.EditingMode = false
        Me.txtReportYear.Size = New System.Drawing.Size(66, 23)
        Me.txtReportYear.TabIndex = 13
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(69, 40)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(281, 17)
        Me.CLabel1.TabIndex = 14
        Me.CLabel1.Text = "Enter Desired Year for Yearly Trial Balance"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrialBalanceYearlyReport
        '
        Me.ClientSize = New System.Drawing.Size(445, 238)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.txtReportYear)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "TrialBalanceYearlyReport"
        Me.Text = "Trial Balance Monthly Report"
        Me.Controls.SetChildIndex(Me.CrystalReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnQuit, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.txtReportYear, 0)
        Me.Controls.SetChildIndex(Me.CLabel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents txtReportYear As CTextBox
        Friend WithEvents CLabel1 As CLabel
    End Class
End NameSpace