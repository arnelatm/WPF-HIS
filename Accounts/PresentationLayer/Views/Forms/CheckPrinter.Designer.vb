Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CheckPrinter
        Inherits CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckPrinter))
        Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.dtpCheckDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tlpDisbursement.SuspendLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'tlpDisbursement
            '
            Me.tlpDisbursement.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.ColumnCount = 6
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
            Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 0, 5)
            Me.tlpDisbursement.Controls.Add(Me.lblNotes, 0, 4)
            Me.tlpDisbursement.Controls.Add(Me.txtNotes, 1, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 0, 3)
            Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 1, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblPaymentType, 0, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 0, 1)
            Me.tlpDisbursement.Controls.Add(Me.cboPaymentType, 1, 2)
            Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 1, 1)
            Me.tlpDisbursement.Controls.Add(Me.lblAmount, 4, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 4, 1)
            Me.tlpDisbursement.Controls.Add(Me.txtAmount, 5, 2)
            Me.tlpDisbursement.Controls.Add(Me.dtpCheckDate, 5, 1)
            Me.tlpDisbursement.Controls.Add(Me.btnPrintCheck, 5, 5)
            Me.tlpDisbursement.Location = New System.Drawing.Point(0, 65)
            Me.tlpDisbursement.Margin = New System.Windows.Forms.Padding(4)
            Me.tlpDisbursement.Name = "tlpDisbursement"
            Me.tlpDisbursement.RowCount = 6
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.Size = New System.Drawing.Size(896, 175)
            Me.tlpDisbursement.TabIndex = 5
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BegFindValue = Nothing
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 5)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = "N2"
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayeeName.EditingMode = False
            Me.txtPayeeName.EndFindValue = Nothing
            Me.txtPayeeName.FieldDescription = Nothing
            Me.txtPayeeName.FieldName = Nothing
            Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayeeName.FindEnabled = False
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.Location = New System.Drawing.Point(1, 130)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.OverrideMaxLength = 0
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayeeName.Size = New System.Drawing.Size(730, 26)
            Me.txtPayeeName.TabIndex = 292
            Me.txtPayeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPayeeName.Translatable = False
            Me.txtPayeeName.ValueIsMandatory = True
            Me.txtPayeeName.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(414, 36)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(315, 30)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblAmount.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(1, 100)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(153, 28)
            Me.lblNotes.TabIndex = 161
            Me.lblNotes.Text = "Description/Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 5)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(156, 100)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(734, 28)
            Me.txtNotes.TabIndex = 14
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(1, 68)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(140, 30)
            Me.lblSupplierIdNo.TabIndex = 7
            Me.lblSupplierIdNo.Text = "Payee:"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSupplierIdNo.Translatable = True
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.BegFindValue = Nothing
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 5)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DataValue = Nothing
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            Me.cboPayeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayeeIdNo.DropDownHeight = 24
            Me.cboPayeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayeeIdNo.Editable = True
            Me.cboPayeeIdNo.EditingMode = False
            Me.cboPayeeIdNo.EndFindValue = Nothing
            Me.cboPayeeIdNo.FieldDescription = Nothing
            Me.cboPayeeIdNo.FieldName = Nothing
            Me.cboPayeeIdNo.FilterRule = Nothing
            Me.cboPayeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayeeIdNo.FindEnabled = False
            Me.cboPayeeIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.cboPayeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayeeIdNo.FormattingEnabled = True
            Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayeeIdNo.IgnoreCase = False
            Me.cboPayeeIdNo.IntegralHeight = False
            Me.cboPayeeIdNo.LimitToList = False
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Location = New System.Drawing.Point(156, 68)
            Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayeeIdNo.MaxDropDownItems = 1
            Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
            Me.cboPayeeIdNo.OldValue = 0
            Me.cboPayeeIdNo.OriginalDataSource = Nothing
            Me.cboPayeeIdNo.OriginalList = Nothing
            Me.cboPayeeIdNo.OverrideDropDownStyleList = False
            Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
            Me.cboPayeeIdNo.PropertySelector = Nothing
            Me.cboPayeeIdNo.Size = New System.Drawing.Size(741, 30)
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TabIndex = 5
            Me.cboPayeeIdNo.TextToSearch = Nothing
            Me.cboPayeeIdNo.Translatable = False
            Me.cboPayeeIdNo.ValueIsMandatory = False
            Me.cboPayeeIdNo.ValueIsNullable = False
            Me.cboPayeeIdNo.ValueIsNumeric = False
            Me.cboPayeeIdNo.ValueMember = "IdNo"
            '
            'lblPaymentType
            '
            Me.lblPaymentType.BackColor = System.Drawing.Color.Transparent
            Me.lblPaymentType.DisplayOnly = True
            Me.lblPaymentType.EditingMode = False
            Me.lblPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentType.Location = New System.Drawing.Point(1, 36)
            Me.lblPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentType.Name = "lblPaymentType"
            Me.lblPaymentType.Size = New System.Drawing.Size(153, 28)
            Me.lblPaymentType.TabIndex = 257
            Me.lblPaymentType.Text = "Payment Type:"
            Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPaymentType.Translatable = True
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckNumber.Location = New System.Drawing.Point(1, 1)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(149, 33)
            Me.lblCheckNumber.TabIndex = 290
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckNumber.Translatable = True
            '
            'cboPaymentType
            '
            Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPaymentType.BackColor = System.Drawing.Color.White
            Me.cboPaymentType.BegFindValue = Nothing
            Me.cboPaymentType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 3)
            Me.cboPaymentType.CurrentSearchTerm = ""
            Me.cboPaymentType.DataValue = Nothing
            Me.cboPaymentType.DefaultValue = "0"
            Me.cboPaymentType.DisplayMember = "Name"
            Me.cboPaymentType.DropDownHeight = 24
            Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPaymentType.Editable = True
            Me.cboPaymentType.EditingMode = False
            Me.cboPaymentType.EndFindValue = Nothing
            Me.cboPaymentType.FieldDescription = Nothing
            Me.cboPaymentType.FieldName = Nothing
            Me.cboPaymentType.FilterRule = Nothing
            Me.cboPaymentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaymentType.FindEnabled = False
            Me.cboPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
            Me.cboPaymentType.HideWhenNotEditingOrAdding = False
            Me.cboPaymentType.IgnoreCase = False
            Me.cboPaymentType.IntegralHeight = False
            Me.cboPaymentType.LimitToList = False
            Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
            Me.cboPaymentType.Location = New System.Drawing.Point(156, 36)
            Me.cboPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaymentType.MaxDropDownItems = 1
            Me.cboPaymentType.Name = "cboPaymentType"
            Me.cboPaymentType.OldValue = 0
            Me.cboPaymentType.OriginalDataSource = Nothing
            Me.cboPaymentType.OriginalList = Nothing
            Me.cboPaymentType.OverrideDropDownStyleList = False
            Me.cboPaymentType.PreviousSearchTerm = Nothing
            Me.cboPaymentType.PropertySelector = Nothing
            Me.cboPaymentType.Size = New System.Drawing.Size(256, 29)
            Me.cboPaymentType.SuggestBoxHeight = 200
            Me.cboPaymentType.SuggestListOrderRule = Nothing
            Me.cboPaymentType.TabIndex = 4
            Me.cboPaymentType.TextToSearch = Nothing
            Me.cboPaymentType.Translatable = False
            Me.cboPaymentType.ValueIsMandatory = False
            Me.cboPaymentType.ValueIsNullable = False
            Me.cboPaymentType.ValueIsNumeric = False
            Me.cboPaymentType.ValueMember = "Code"
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BegFindValue = Nothing
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = False
            Me.txtCheckNumber.EndFindValue = Nothing
            Me.txtCheckNumber.FieldDescription = Nothing
            Me.txtCheckNumber.FieldName = Nothing
            Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCheckNumber.FindEnabled = False
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Nothing
            Me.txtCheckNumber.Location = New System.Drawing.Point(156, 1)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.OverrideMaxLength = 0
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCheckNumber.Size = New System.Drawing.Size(157, 26)
            Me.txtCheckNumber.TabIndex = 11
            Me.txtCheckNumber.Translatable = False
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.BackColor = System.Drawing.Color.Transparent
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckDate.Location = New System.Drawing.Point(414, 1)
            Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckDate.Name = "lblCheckDate"
            Me.lblCheckDate.Size = New System.Drawing.Size(315, 31)
            Me.lblCheckDate.TabIndex = 284
            Me.lblCheckDate.Text = "Check Date"
            Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckDate.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = False
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(733, 36)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(157, 26)
            Me.txtAmount.TabIndex = 8
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'dtpCheckDate
            '
            Me.dtpCheckDate.AutoSize = True
            Me.dtpCheckDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpCheckDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCheckDate.DefaultValue = Nothing
            Me.dtpCheckDate.DisplayOnly = False
            Me.dtpCheckDate.DtpDefaultValue = Nothing
            Me.dtpCheckDate.EditingMode = False
            Me.dtpCheckDate.EditsAllowed = False
            Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
            Me.dtpCheckDate.LinkedLabel = Nothing
            Me.dtpCheckDate.Location = New System.Drawing.Point(733, 1)
            Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpCheckDate.TabIndex = 13
            Me.dtpCheckDate.TargetCalendar = Nothing
            Me.dtpCheckDate.Translatable = False
            Me.dtpCheckDate.Value = Nothing
            Me.dtpCheckDate.ValueIsMandatory = False
            Me.dtpCheckDate.ValueIsNullable = False
            '
            'btnPrintCheck
            '
            Me.btnPrintCheck.DesignerSelected = False
            Me.btnPrintCheck.ImageIndex = 0
            Me.btnPrintCheck.Location = New System.Drawing.Point(736, 133)
            Me.btnPrintCheck.Margin = New System.Windows.Forms.Padding(4)
            Me.btnPrintCheck.Name = "btnPrintCheck"
            Me.btnPrintCheck.OriginalImageName = Nothing
            Me.btnPrintCheck.SecurityKey = ""
            Me.btnPrintCheck.Size = New System.Drawing.Size(155, 38)
            Me.btnPrintCheck.TabIndex = 291
            Me.btnPrintCheck.TabStop = False
            Me.btnPrintCheck.Text = "Print Check"
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
            '
            'CheckPrinter
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(909, 304)
            Me.Controls.Add(Me.tlpDisbursement)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.MaximumSize = New System.Drawing.Size(1327, 358)
            Me.MinimumSize = New System.Drawing.Size(18, 112)
            Me.Name = "CheckPrinter"
            Me.Text = "Petty Cash Journal "
        Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.tlpDisbursement.ResumeLayout(false)
        Me.tlpDisbursement.PerformLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents bsDjOiItems As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tlpDisbursement As TableLayoutPanel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents cboPayeeIdNo As AtmComboBox
        Friend WithEvents dtpCheckDate As CCustomDateTimePicker
        Friend WithEvents lblCheckDate As CLabel
        Friend WithEvents txtCheckNumber As CTextBox
        Friend WithEvents lblCheckNumber As CLabel
        Friend WithEvents lblPaymentType As CLabel
        Friend WithEvents cboPaymentType As AtmComboBox
        Friend WithEvents btnPrintCheck As CButton
        Friend WithEvents txtPayeeName As CTextBox
    End Class
End Namespace