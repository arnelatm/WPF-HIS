Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DiagnosticTestSummary
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiagnosticTestSummary))
        Me.lblEndingDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboReportSelector = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
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
        'lblEndingDate
        '
        Me.lblEndingDate.DisplayOnly = true
        Me.lblEndingDate.EditingMode = false
        Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndingDate.Location = New System.Drawing.Point(11, 38)
        Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(171, 25)
        Me.lblEndingDate.TabIndex = 21
        Me.lblEndingDate.Text = "Ending Date:"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndingDate.Translatable = true
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.DisplayOnly = true
        Me.lblBeginningDate.EditingMode = false
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(11, 11)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(171, 25)
        Me.lblBeginningDate.TabIndex = 20
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBeginningDate.Translatable = true
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.AutoSize = true
        Me.dtpEndingDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpEndingDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DisplayOnly = false
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditingMode = true
        Me.dtpEndingDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, true)
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(184, 38)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = false
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = false
        Me.dtpEndingDate.ShowTime = false
        Me.dtpEndingDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpEndingDate.TabIndex = 24
        Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndingDate.Translatable = false
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = false
        Me.dtpEndingDate.ValueIsNullable = false
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.AutoSize = true
        Me.dtpBeginningDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpBeginningDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DisplayOnly = false
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditingMode = true
        Me.dtpBeginningDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, true)
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(184, 11)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = false
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = false
        Me.dtpBeginningDate.ShowTime = false
        Me.dtpBeginningDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpBeginningDate.TabIndex = 23
        Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpBeginningDate.Translatable = false
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = false
        Me.dtpBeginningDate.ValueIsNullable = false
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.lblEndingDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
        Me.CFlowLayout1.Controls.Add(Me.CLabel3)
        Me.CFlowLayout1.Controls.Add(Me.cboReportSelector)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout1.Size = New System.Drawing.Size(318, 129)
        Me.CFlowLayout1.TabIndex = 26
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(11, 65)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(285, 25)
        Me.CLabel3.TabIndex = 26
        Me.CLabel3.Text = "Select Test to print"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'cboReportSelector
        '
        Me.cboReportSelector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboReportSelector.BackColor = System.Drawing.Color.White
        Me.cboReportSelector.DefaultValue = Nothing
        Me.cboReportSelector.DisplayOnly = false
        Me.cboReportSelector.EditingMode = true
        Me.cboReportSelector.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboReportSelector.Font = New System.Drawing.Font("Arial", 10!)
        Me.cboReportSelector.ForeColor = System.Drawing.Color.Black
        Me.cboReportSelector.FormattingEnabled = true
        Me.cboReportSelector.HideWhenNotEditingOrAdding = false
        Me.cboReportSelector.Items.AddRange(New Object() {"Iqama Test", "Health Card Test", "Driver License Test", "Food Delivery Driver Test"})
        Me.cboReportSelector.LinkedLabel = Nothing
        Me.cboReportSelector.Location = New System.Drawing.Point(11, 92)
        Me.cboReportSelector.Margin = New System.Windows.Forms.Padding(1)
        Me.cboReportSelector.MaximumValue = Nothing
        Me.cboReportSelector.MinimumValue = Nothing
        Me.cboReportSelector.Name = "cboReportSelector"
        Me.cboReportSelector.OldValue = 0
        Me.cboReportSelector.OriginalDataSource = Nothing
        Me.cboReportSelector.OriginalDropDownStyle = 1
        Me.cboReportSelector.OriginalList = Nothing
        Me.cboReportSelector.ReadOnlyCombo = false
        Me.cboReportSelector.Size = New System.Drawing.Size(285, 24)
        Me.cboReportSelector.TabIndex = 27
        Me.cboReportSelector.Translatable = false
        Me.cboReportSelector.ValueIsMandatory = false
        Me.cboReportSelector.ValueIsNullable = false
        Me.cboReportSelector.ValueIsNumeric = false
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CLabel2.Location = New System.Drawing.Point(0, 0)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(321, 25)
        Me.CLabel2.TabIndex = 26
        Me.CLabel2.Text = "Diagnostic Test Summary"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel2.Translatable = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(25, 37)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(150, 25)
        Me.CLabel1.TabIndex = 26
        Me.CLabel1.Text = "Beginning Date :"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(65, 184)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 27
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(171, 184)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'DiagnosticTestSummary
        '
        Me.ClientSize = New System.Drawing.Size(332, 221)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "DiagnosticTestSummary"
        Me.Text = "Diagnostic Test Summary"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents lblEndingDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboReportSelector As CComboBox
    End Class
End NameSpace