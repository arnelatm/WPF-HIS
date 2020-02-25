Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.BaseFormsLibrary

Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ArStatementReport
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
        Me.cboCustomerCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCustomerCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(277, 217)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(358, 217)
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(686, 211)
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(692, 0)
        '
        'cboCustomerCode
        '
        Me.cboCustomerCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCustomerCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerCode.BackColor = System.Drawing.Color.White
        Me.cboCustomerCode.DefaultValue = Nothing
        Me.cboCustomerCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboCustomerCode.ForeColor = System.Drawing.Color.Black
        Me.cboCustomerCode.FormattingEnabled = true
        Me.cboCustomerCode.HideWhenNotEditingOrAdding = false
        Me.cboCustomerCode.LinkedLabel = Nothing
        Me.cboCustomerCode.Location = New System.Drawing.Point(140, 115)
        Me.cboCustomerCode.Margin = New System.Windows.Forms.Padding(1)
        Me.cboCustomerCode.Name = "cboCustomerCode"
        Me.cboCustomerCode.OriginalDataSource = Nothing
        Me.cboCustomerCode.OriginalList = Nothing
        Me.cboCustomerCode.PreviousSelectedIndex = -1
        Me.cboCustomerCode.ReadOnlyCombo = false
        Me.cboCustomerCode.EditingMode = false
        Me.cboCustomerCode.Size = New System.Drawing.Size(543, 24)
        Me.cboCustomerCode.TabIndex = 26
        Me.cboCustomerCode.ValueIsMandatory = false
        Me.cboCustomerCode.ValueIsNullable = false
        Me.cboCustomerCode.ValueIsNumeric = false
        Me.cboCustomerCode.DisplayOnly = false
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(18, 85)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(90, 17)
        Me.CLabel3.TabIndex = 22
        Me.CLabel3.Text = "Ending Date:"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomerCode
        '
        Me.lblCustomerCode.AutoSize = true
        Me.lblCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCustomerCode.Location = New System.Drawing.Point(18, 118)
        Me.lblCustomerCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCustomerCode.Name = "lblCustomerCode"
        Me.lblCustomerCode.Size = New System.Drawing.Size(109, 17)
        Me.lblCustomerCode.TabIndex = 25
        Me.lblCustomerCode.Text = "Customer Code:"
        Me.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.AutoSize = true
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(18, 55)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(113, 17)
        Me.lblBeginningDate.TabIndex = 21
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditsAllowed = false
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(140, 85)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = false
        Me.dtpEndingDate.EditingMode = false
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = false
        Me.dtpEndingDate.ShowTime = false
        Me.dtpEndingDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpEndingDate.TabIndex = 20
        Me.dtpEndingDate.TargetCalendar = Nothing
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = false
        Me.dtpEndingDate.ValueIsNullable = false
        Me.dtpEndingDate.DisplayOnly = false
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditsAllowed = false
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(140, 55)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = false
        Me.dtpBeginningDate.EditingMode = false
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = false
        Me.dtpBeginningDate.ShowTime = false
        Me.dtpBeginningDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpBeginningDate.TabIndex = 19
        Me.dtpBeginningDate.TargetCalendar = Nothing
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = false
        Me.dtpBeginningDate.ValueIsNullable = false
        Me.dtpBeginningDate.DisplayOnly = false
        '
        'ArStatementReport
        '
        Me.ClientSize = New System.Drawing.Size(716, 252)
        Me.Controls.Add(Me.cboCustomerCode)
        Me.Controls.Add(Me.lblCustomerCode)
        Me.Controls.Add(Me.CLabel3)
        Me.Controls.Add(Me.lblBeginningDate)
        Me.Controls.Add(Me.dtpEndingDate)
        Me.Controls.Add(Me.dtpBeginningDate)
        Me.Name = "ArStatementReport"
        Me.Controls.SetChildIndex(Me.CrystalReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnQuit, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dtpBeginningDate, 0)
        Me.Controls.SetChildIndex(Me.dtpEndingDate, 0)
        Me.Controls.SetChildIndex(Me.lblBeginningDate, 0)
        Me.Controls.SetChildIndex(Me.CLabel3, 0)
        Me.Controls.SetChildIndex(Me.lblCustomerCode, 0)
        Me.Controls.SetChildIndex(Me.cboCustomerCode, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents dmpReportDate As CMonthPicker
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cboCustomerCode As CaComboBox
        Friend WithEvents lblCustomerCode As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents lblBeginningDate As CLabel
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
    End Class
End NameSpace