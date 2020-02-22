Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BalanceSheetYearlyReport
        Inherits AATM.PresentationLayer.Forms.CrReportViewer

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
        Me.components = New System.ComponentModel.Container()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReportYear = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(139, 200)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(220, 200)
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(404, 194)
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(404, 0)
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(47, 74)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(290, 17)
        Me.CLabel1.TabIndex = 13
        Me.CLabel1.Text = "Enter Desired Year for Yearly Balance Sheet"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtReportYear.Location = New System.Drawing.Point(152, 116)
        Me.txtReportYear.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReportYear.Name = "txtReportYear"
        Me.txtReportYear.EditingMode = false
        Me.txtReportYear.Size = New System.Drawing.Size(66, 23)
        Me.txtReportYear.TabIndex = 12
        '
        'BalanceSheetYearlyReport
        '
        Me.ClientSize = New System.Drawing.Size(428, 235)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.txtReportYear)
        Me.Name = "BalanceSheetYearlyReport"
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

        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtReportYear As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace
