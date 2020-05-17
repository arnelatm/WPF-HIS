Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StatementOfAccountsPayable
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatementOfAccountsPayable))
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.Location = New System.Drawing.Point(280, 187)
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(361, 187)
            '
            'btnQuit
            '
            Me.btnQuit.Location = New System.Drawing.Point(702, 0)
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.Size = New System.Drawing.Size(702, 181)
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.AutoSize = True
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(26, 131)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(101, 17)
            Me.lblSupplierCode.TabIndex = 19
            Me.lblSupplierCode.Text = "Supplier Code:"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(26, 98)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(90, 17)
            Me.CLabel3.TabIndex = 18
            Me.CLabel3.Text = "Ending Date:"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.AutoSize = True
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBeginningDate.Location = New System.Drawing.Point(26, 68)
            Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBeginningDate.Name = "lblBeginningDate"
            Me.lblBeginningDate.Size = New System.Drawing.Size(113, 17)
            Me.lblBeginningDate.TabIndex = 17
            Me.lblBeginningDate.Text = "Beginning Date :"
            Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboSupplierCode
            '
            Me.cboSupplierCode.BackColor = System.Drawing.Color.White
            Me.cboSupplierCode.ChangingSearchValueOnly = False
            Me.cboSupplierCode.CurrentSearchTerm = ""
            Me.cboSupplierCode.DefaultValue = Nothing
            Me.cboSupplierCode.DisplayMember = "Name"
            Me.cboSupplierCode.DropDownHeight = 200
            Me.cboSupplierCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSupplierCode.EditingMode = False
            Me.cboSupplierCode.FilterRule = Nothing
            Me.cboSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierCode.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierCode.FormattingEnabled = True
            Me.cboSupplierCode.HideWhenNotEditingOrAdding = False
            Me.cboSupplierCode.LinkedLabel = Nothing
            Me.cboSupplierCode.Location = New System.Drawing.Point(174, 128)
            Me.cboSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierCode.Name = "cboSupplierCode"
            Me.cboSupplierCode.OldValue = 0
            Me.cboSupplierCode.OriginalDataSource = Nothing
            Me.cboSupplierCode.OriginalList = Nothing
            Me.cboSupplierCode.OverrideDropDownStyleList = False
            Me.cboSupplierCode.PreviousSearchTerm = Nothing
            Me.cboSupplierCode.PreviousSelectedIndex = -1
            Me.cboSupplierCode.PropertySelector = Nothing
            Me.cboSupplierCode.ReadOnlyCombo = False
            Me.cboSupplierCode.SearchAnywhere = False
            Me.cboSupplierCode.Size = New System.Drawing.Size(530, 24)
            Me.cboSupplierCode.SuggestBoxHeight = 200
            Me.cboSupplierCode.SuggestListOrderRule = Nothing
            Me.cboSupplierCode.TabIndex = 22
            Me.cboSupplierCode.TextToSearch = Nothing
            Me.cboSupplierCode.ValueIsMandatory = False
            Me.cboSupplierCode.ValueIsNullable = False
            Me.cboSupplierCode.ValueIsNumeric = False
            Me.cboSupplierCode.ValueMember = "Code"
            '
            'dtpEndingDate
            '
            Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndingDate.DefaultValue = Nothing
            Me.dtpEndingDate.DisplayOnly = False
            Me.dtpEndingDate.DtpDefaultValue = Nothing
            Me.dtpEndingDate.EditingMode = False
            Me.dtpEndingDate.EditsAllowed = False
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(174, 98)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(107, 25)
            Me.dtpEndingDate.TabIndex = 21
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'dtpBeginningDate
            '
            Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBeginningDate.DefaultValue = Nothing
            Me.dtpBeginningDate.DisplayOnly = False
            Me.dtpBeginningDate.DtpDefaultValue = Nothing
            Me.dtpBeginningDate.EditingMode = False
            Me.dtpBeginningDate.EditsAllowed = False
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            Me.dtpBeginningDate.Location = New System.Drawing.Point(174, 68)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(107, 25)
            Me.dtpBeginningDate.TabIndex = 20
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'StatementOfAccountsPayable
            '
            Me.ClientSize = New System.Drawing.Size(723, 222)
            Me.Controls.Add(Me.cboSupplierCode)
            Me.Controls.Add(Me.dtpEndingDate)
            Me.Controls.Add(Me.dtpBeginningDate)
            Me.Controls.Add(Me.lblSupplierCode)
            Me.Controls.Add(Me.CLabel3)
            Me.Controls.Add(Me.lblBeginningDate)
            Me.Name = "StatementOfAccountsPayable"
            Me.Controls.SetChildIndex(Me.lblBeginningDate, 0)
            Me.Controls.SetChildIndex(Me.CLabel3, 0)
            Me.Controls.SetChildIndex(Me.lblSupplierCode, 0)
            Me.Controls.SetChildIndex(Me.dtpBeginningDate, 0)
            Me.Controls.SetChildIndex(Me.dtpEndingDate, 0)
            Me.Controls.SetChildIndex(Me.cboSupplierCode, 0)
            Me.Controls.SetChildIndex(Me.CrystalReportViewer1, 0)
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            Me.Controls.SetChildIndex(Me.btnCancel, 0)
            Me.Controls.SetChildIndex(Me.btnQuit, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboSupplierCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dtpEndingDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
    End Class
End NameSpace