Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.BaseFormsLibrary

Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BalanceSheetMonthlyReport
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
        Me.dmpReportDate = New AATM.Libraries.CustomControlsLibrary.CMonthPicker()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(117, 164)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(196, 164)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(356, 159)
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(362, 0)
        '
        'dmpReportDate
        '
        Me.dmpReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dmpReportDate.Location = New System.Drawing.Point(89, 67)
        Me.dmpReportDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dmpReportDate.Name = "dmpReportDate"
        Me.dmpReportDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dmpReportDate.Size = New System.Drawing.Size(210, 22)
        Me.dmpReportDate.TabIndex = 13
        Me.dmpReportDate.Value = New Date(2019, 9, 1, 0, 0, 0, 0)
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(52, 37)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(297, 17)
        Me.CLabel1.TabIndex = 12
        Me.CLabel1.Text = "Enter Month of Balance Sheet Monthly Report"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BalanceSheetMonthlyReport
        '
        Me.ClientSize = New System.Drawing.Size(387, 198)
        Me.Controls.Add(Me.dmpReportDate)
        Me.Controls.Add(Me.CLabel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BalanceSheetMonthlyReport"
        Me.Text = "Balance Sheet Monthly"
        Me.Controls.SetChildIndex(Me.CrystalReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnQuit, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.CLabel1, 0)
        Me.Controls.SetChildIndex(Me.dmpReportDate, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents dmpReportDate As CMonthPicker
        Friend WithEvents CLabel1 As CLabel
    End Class
End NameSpace