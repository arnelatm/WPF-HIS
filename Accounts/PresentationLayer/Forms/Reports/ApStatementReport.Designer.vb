Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ApStatementReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApStatementReport))
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(280, 182)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(379, 182)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(731, 181)
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(737, 0)
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(277, 43)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(229, 17)
        Me.CLabel1.TabIndex = 10
        Me.CLabel1.Text = "Enter Date Coverage and Supplier "
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditsAllowed = false
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(185, 82)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = false
        Me.dtpBeginningDate.EditingMode = false
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = false
        Me.dtpBeginningDate.ShowTime = false
        Me.dtpBeginningDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpBeginningDate.TabIndex = 11
        Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = false
        Me.dtpBeginningDate.ValueIsNullable = false
        Me.dtpBeginningDate.DisplayOnly = false
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditsAllowed = false
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(185, 112)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = false
        Me.dtpEndingDate.EditingMode = false
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = false
        Me.dtpEndingDate.ShowTime = false
        Me.dtpEndingDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpEndingDate.TabIndex = 12
        Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = false
        Me.dtpEndingDate.ValueIsNullable = false
        Me.dtpEndingDate.DisplayOnly = false
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.AutoSize = true
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(31, 82)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(113, 17)
        Me.lblBeginningDate.TabIndex = 13
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(31, 112)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(90, 17)
        Me.CLabel3.TabIndex = 14
        Me.CLabel3.Text = "Ending Date:"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSupplierCode
        '
        Me.lblSupplierCode.AutoSize = true
        Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierCode.Location = New System.Drawing.Point(31, 145)
        Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierCode.Name = "lblSupplierCode"
        Me.lblSupplierCode.Size = New System.Drawing.Size(101, 17)
        Me.lblSupplierCode.TabIndex = 16
        Me.lblSupplierCode.Text = "Supplier Code:"
        Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacSupplierCode
        '
        Me.cacSupplierCode.BackColor = System.Drawing.Color.White
        Me.cacSupplierCode.ChangingSearchValueOnly = false
        Me.cacSupplierCode.CurrentSearchTerm = ""
        Me.cacSupplierCode.DefaultValue = Nothing
        Me.cacSupplierCode.DisplayMember = "Name"
        Me.cacSupplierCode.DropDownHeight = 200
        Me.cacSupplierCode.FilterRule = Nothing
        Me.cacSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSupplierCode.ForeColor = System.Drawing.Color.Black
        Me.cacSupplierCode.FormattingEnabled = true
        Me.cacSupplierCode.HideWhenNotEditingOrAdding = false
        Me.cacSupplierCode.LinkedLabel = Nothing
        Me.cacSupplierCode.Location = New System.Drawing.Point(185, 142)
        Me.cacSupplierCode.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSupplierCode.Name = "cacSupplierCode"
        Me.cacSupplierCode.OldValue = Nothing
        Me.cacSupplierCode.OriginalDataSource = Nothing
        Me.cacSupplierCode.OriginalList = Nothing
        Me.cacSupplierCode.OverrideDropDownStyleList = false
        Me.cacSupplierCode.PreviousSearchTerm = Nothing
        Me.cacSupplierCode.PreviousSelectedIndex = -1
        Me.cacSupplierCode.PropertySelector = Nothing
        Me.cacSupplierCode.ReadOnlyCombo = false
        Me.cacSupplierCode.EditingMode = false
        Me.cacSupplierCode.SearchAnywhere = false
        Me.cacSupplierCode.Size = New System.Drawing.Size(530, 24)
        Me.cacSupplierCode.SuggestBoxHeight = 200
        Me.cacSupplierCode.SuggestListOrderRule = Nothing
        Me.cacSupplierCode.TabIndex = 19
        Me.cacSupplierCode.TextToSearch = Nothing
        Me.cacSupplierCode.ValueIsMandatory = false
        Me.cacSupplierCode.ValueIsNullable = false
        Me.cacSupplierCode.ValueIsNumeric = false
        Me.cacSupplierCode.DisplayOnly = false
        Me.cacSupplierCode.ValueMember = "Code"
        '
        'ApStatementReport
        '
        Me.ClientSize = New System.Drawing.Size(759, 228)
        Me.Controls.Add(Me.cacSupplierCode)
        Me.Controls.Add(Me.lblSupplierCode)
        Me.Controls.Add(Me.CLabel3)
        Me.Controls.Add(Me.lblBeginningDate)
        Me.Controls.Add(Me.dtpEndingDate)
        Me.Controls.Add(Me.dtpBeginningDate)
        Me.Controls.Add(Me.CLabel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ApStatementReport"
        Me.Text = "Statement of Accounts Payable"
        Me.Controls.SetChildIndex(Me.CrystalReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnQuit, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.CLabel1, 0)
        Me.Controls.SetChildIndex(Me.dtpBeginningDate, 0)
        Me.Controls.SetChildIndex(Me.dtpEndingDate, 0)
        Me.Controls.SetChildIndex(Me.lblBeginningDate, 0)
        Me.Controls.SetChildIndex(Me.CLabel3, 0)
        Me.Controls.SetChildIndex(Me.lblSupplierCode, 0)
        Me.Controls.SetChildIndex(Me.cacSupplierCode, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents lblBeginningDate As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents lblSupplierCode As CLabel
        Friend WithEvents cacSupplierCode As CaComboBox
    End Class
End NameSpace