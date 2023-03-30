Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PurchaseEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout3.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        CType(Me.CDataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CFlowLayout3
        '
        Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout3.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblReferenceNo)
        Me.CFlowLayout3.Controls.Add(Me.txtReferenceNo)
        Me.CFlowLayout3.Controls.Add(Me.lblTransactionDate)
        Me.CFlowLayout3.Controls.Add(Me.dtpTransactionDate)
        Me.CFlowLayout3.Controls.Add(Me.lblSupplierIdNo)
        Me.CFlowLayout3.Controls.Add(Me.cboSupplierIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblTransactionType)
        Me.CFlowLayout3.Controls.Add(Me.cboTransactionType)
        Me.CFlowLayout3.Controls.Add(Me.lblAmount)
        Me.CFlowLayout3.Controls.Add(Me.txtAmount)
        Me.CFlowLayout3.Controls.Add(Me.lblInvoiceDate)
        Me.CFlowLayout3.Controls.Add(Me.dtpInvoiceDate)
        Me.CFlowLayout3.Controls.Add(Me.lblDueDate)
        Me.CFlowLayout3.Controls.Add(Me.dtpDueDate)
        Me.CFlowLayout3.Controls.Add(Me.lblInvoiceNo)
        Me.CFlowLayout3.Controls.Add(Me.txtInvoiceNo)
        Me.CFlowLayout3.Controls.Add(Me.lblAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.cboAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblVatNumber)
        Me.CFlowLayout3.Controls.Add(Me.txtVatNumber)
        Me.CFlowLayout3.Controls.Add(Me.lblNotes)
        Me.CFlowLayout3.Controls.Add(Me.txtNotes)
        Me.CFlowLayout3.Location = New System.Drawing.Point(12, 66)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
        Me.CFlowLayout3.Size = New System.Drawing.Size(758, 204)
        Me.CFlowLayout3.TabIndex = 4
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(16, 16)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblIdNo.TabIndex = 160
        Me.lblIdNo.Text = "Transaction No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(163, 16)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(63, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(228, 16)
        Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(128, 23)
        Me.lblReferenceNo.TabIndex = 158
        Me.lblReferenceNo.Text = "Reference No.:"
        Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblReferenceNo.Translatable = true
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BegFindValue = Nothing
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = false
        Me.txtReferenceNo.EndFindValue = Nothing
        Me.txtReferenceNo.FieldDescription = Nothing
        Me.txtReferenceNo.FieldName = Nothing
        Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtReferenceNo.FindEnabled = true
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.Location = New System.Drawing.Point(358, 16)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
        Me.txtReferenceNo.TabIndex = 1
        Me.txtReferenceNo.Translatable = false
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionDate.Location = New System.Drawing.Point(450, 16)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionDate.TabIndex = 5
        Me.lblTransactionDate.Text = "Transaction Date:"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTransactionDate.Translatable = true
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.AutoSize = true
        Me.dtpTransactionDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpTransactionDate.DefaultValue = Nothing
        Me.dtpTransactionDate.DisplayOnly = false
        Me.dtpTransactionDate.DtpDefaultValue = Nothing
        Me.dtpTransactionDate.EditingMode = false
        Me.dtpTransactionDate.EditsAllowed = false
        Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, true)
        Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        Me.dtpTransactionDate.Location = New System.Drawing.Point(581, 15)
        Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.Size = New System.Drawing.Size(123, 23)
        Me.dtpTransactionDate.TabIndex = 2
        Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblSupplierIdNo
        '
        Me.lblSupplierIdNo.DisplayOnly = true
        Me.lblSupplierIdNo.EditingMode = false
        Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 41)
        Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        Me.lblSupplierIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblSupplierIdNo.TabIndex = 254
        Me.lblSupplierIdNo.Text = "Supplier Code/Name"
        Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSupplierIdNo.Translatable = true
        '
        'cboSupplierIdNo
        '
        Me.cboSupplierIdNo.AlwaysEditable = false
        Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
        Me.cboSupplierIdNo.BegFindValue = Nothing
        Me.cboSupplierIdNo.ChangingSearchValueOnly = false
        Me.cboSupplierIdNo.CurrentSearchTerm = ""
        Me.cboSupplierIdNo.DataValue = Nothing
        Me.cboSupplierIdNo.DefaultValue = Nothing
        Me.cboSupplierIdNo.DisplayMember = "Name"
        Me.cboSupplierIdNo.EditingMode = true
        Me.cboSupplierIdNo.EndFindValue = Nothing
        Me.cboSupplierIdNo.FieldDescription = Nothing
        Me.cboSupplierIdNo.FieldName = Nothing
        Me.cboSupplierIdNo.FilterRule = Nothing
        Me.cboSupplierIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboSupplierIdNo.FindEnabled = false
        Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSupplierIdNo.FormattingEnabled = true
        Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSupplierIdNo.IgnoreCase = false
        Me.cboSupplierIdNo.IntegralHeight = false
        Me.cboSupplierIdNo.LimitToList = false
        Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
        Me.cboSupplierIdNo.Location = New System.Drawing.Point(163, 41)
        Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
        Me.cboSupplierIdNo.OldValue = 0
        Me.cboSupplierIdNo.OriginalDataSource = Nothing
        Me.cboSupplierIdNo.OriginalList = Nothing
        Me.cboSupplierIdNo.OverrideDropDownStyleList = false
        Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
        Me.cboSupplierIdNo.PropertySelector = Nothing
        Me.cboSupplierIdNo.ReadOnlyCombo = false
        Me.cboSupplierIdNo.Size = New System.Drawing.Size(575, 24)
        Me.cboSupplierIdNo.SuggestBoxHeight = 200
        Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
        Me.cboSupplierIdNo.TabIndex = 3
        Me.cboSupplierIdNo.TextToSearch = Nothing
        Me.cboSupplierIdNo.Translatable = false
        Me.cboSupplierIdNo.ValueIsMandatory = false
        Me.cboSupplierIdNo.ValueIsNullable = false
        Me.cboSupplierIdNo.ValueIsNumeric = false
        Me.cboSupplierIdNo.ValueMember = "IdNo"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.DisplayOnly = true
        Me.lblTransactionType.EditingMode = false
        Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionType.Location = New System.Drawing.Point(16, 67)
        Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Size = New System.Drawing.Size(145, 23)
        Me.lblTransactionType.TabIndex = 267
        Me.lblTransactionType.Text = "Transaction Type:"
        Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTransactionType.Translatable = true
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AlwaysEditable = false
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.BackColor = System.Drawing.Color.White
        Me.cboTransactionType.BegFindValue = Nothing
        Me.cboTransactionType.ChangingSearchValueOnly = false
        Me.cboTransactionType.CurrentSearchTerm = ""
        Me.cboTransactionType.DataValue = Nothing
        Me.cboTransactionType.DefaultValue = "0"
        Me.cboTransactionType.DisplayMember = "Name"
        Me.cboTransactionType.EditingMode = false
        Me.cboTransactionType.EndFindValue = Nothing
        Me.cboTransactionType.FieldDescription = Nothing
        Me.cboTransactionType.FieldName = Nothing
        Me.cboTransactionType.FilterRule = Nothing
        Me.cboTransactionType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboTransactionType.FindEnabled = false
        Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
        Me.cboTransactionType.HideWhenNotEditingOrAdding = false
        Me.cboTransactionType.IgnoreCase = false
        Me.cboTransactionType.IntegralHeight = false
        Me.cboTransactionType.LimitToList = false
        Me.cboTransactionType.LinkedLabel = Nothing
        Me.cboTransactionType.Location = New System.Drawing.Point(163, 67)
        Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.OldValue = 0
        Me.cboTransactionType.OriginalDataSource = Nothing
        Me.cboTransactionType.OriginalList = Nothing
        Me.cboTransactionType.OverrideDropDownStyleList = false
        Me.cboTransactionType.PreviousSearchTerm = Nothing
        Me.cboTransactionType.PropertySelector = Nothing
        Me.cboTransactionType.ReadOnlyCombo = false
        Me.cboTransactionType.Size = New System.Drawing.Size(122, 24)
        Me.cboTransactionType.SuggestBoxHeight = 200
        Me.cboTransactionType.SuggestListOrderRule = Nothing
        Me.cboTransactionType.TabIndex = 4
        Me.cboTransactionType.TextToSearch = Nothing
        Me.cboTransactionType.Translatable = false
        Me.cboTransactionType.ValueIsMandatory = false
        Me.cboTransactionType.ValueIsNullable = false
        Me.cboTransactionType.ValueIsNumeric = false
        Me.cboTransactionType.ValueMember = "Code"
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(287, 67)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(96, 23)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Amount:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAmount.Translatable = true
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = Nothing
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = false
        Me.txtAmount.EndFindValue = Nothing
        Me.txtAmount.FieldDescription = Nothing
        Me.txtAmount.FieldName = Nothing
        Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAmount.FindEnabled = true
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.Location = New System.Drawing.Point(385, 67)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(90, 23)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.DisplayOnly = true
        Me.lblInvoiceDate.EditingMode = false
        Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceDate.Location = New System.Drawing.Point(477, 67)
        Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(130, 23)
        Me.lblInvoiceDate.TabIndex = 257
        Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
        Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvoiceDate.Translatable = true
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.AutoSize = true
        Me.dtpInvoiceDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpInvoiceDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpInvoiceDate.DefaultValue = Nothing
        Me.dtpInvoiceDate.DisplayOnly = false
        Me.dtpInvoiceDate.DtpDefaultValue = Nothing
        Me.dtpInvoiceDate.EditingMode = false
        Me.dtpInvoiceDate.EditsAllowed = false
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
        Me.dtpInvoiceDate.LinkedLabel = Nothing
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(608, 66)
        Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ReadOnlyDp = false
        Me.dtpInvoiceDate.SecurityKey = Nothing
        Me.dtpInvoiceDate.ShowLongDate = false
        Me.dtpInvoiceDate.ShowTime = false
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(123, 23)
        Me.dtpInvoiceDate.TabIndex = 6
        Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpInvoiceDate.Translatable = false
        Me.dtpInvoiceDate.Value = Nothing
        Me.dtpInvoiceDate.ValueIsMandatory = false
        Me.dtpInvoiceDate.ValueIsNullable = false
        '
        'lblDueDate
        '
        Me.lblDueDate.DisplayOnly = true
        Me.lblDueDate.EditingMode = false
        Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDueDate.Location = New System.Drawing.Point(16, 93)
        Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(145, 23)
        Me.lblDueDate.TabIndex = 259
        Me.lblDueDate.Text = "Due Date:"
        Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDueDate.Translatable = true
        '
        'dtpDueDate
        '
        Me.dtpDueDate.AutoSize = true
        Me.dtpDueDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpDueDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDueDate.DefaultValue = Nothing
        Me.dtpDueDate.DisplayOnly = false
        Me.dtpDueDate.DtpDefaultValue = Nothing
        Me.dtpDueDate.EditingMode = false
        Me.dtpDueDate.EditsAllowed = false
        Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
        Me.dtpDueDate.LinkedLabel = Nothing
        Me.dtpDueDate.Location = New System.Drawing.Point(162, 92)
        Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.ReadOnlyDp = false
        Me.dtpDueDate.SecurityKey = Nothing
        Me.dtpDueDate.ShowLongDate = false
        Me.dtpDueDate.ShowTime = false
        Me.dtpDueDate.Size = New System.Drawing.Size(123, 23)
        Me.dtpDueDate.TabIndex = 7
        Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDueDate.Translatable = false
        Me.dtpDueDate.Value = Nothing
        Me.dtpDueDate.ValueIsMandatory = false
        Me.dtpDueDate.ValueIsNullable = false
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.DisplayOnly = true
        Me.lblInvoiceNo.EditingMode = false
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceNo.Location = New System.Drawing.Point(286, 93)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(325, 23)
        Me.lblInvoiceNo.TabIndex = 254
        Me.lblInvoiceNo.Text = "Supplier Invoice/Reference No.:"
        Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblInvoiceNo.Translatable = true
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNo.BegFindValue = Nothing
        Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNo.ComputedValue = false
        Me.txtInvoiceNo.CustomFormat = Nothing
        Me.txtInvoiceNo.DataBoundControl = true
        Me.txtInvoiceNo.EditingMode = false
        Me.txtInvoiceNo.EndFindValue = Nothing
        Me.txtInvoiceNo.FieldDescription = Nothing
        Me.txtInvoiceNo.FieldName = Nothing
        Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtInvoiceNo.FindEnabled = true
        Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, true)
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
        Me.txtInvoiceNo.Location = New System.Drawing.Point(613, 93)
        Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtInvoiceNo.MaximumValue = Nothing
        Me.txtInvoiceNo.MinimumValue = Nothing
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.OldValue = Nothing
        Me.txtInvoiceNo.ReadOnly = true
        Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
        Me.txtInvoiceNo.TabIndex = 8
        Me.txtInvoiceNo.Translatable = false
        Me.txtInvoiceNo.ValueIsMandatory = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(16, 118)
        Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Size = New System.Drawing.Size(145, 24)
        Me.lblAccountIdNo.TabIndex = 266
        Me.lblAccountIdNo.Text = "Acct. to Credit:"
        Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountIdNo.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AlwaysEditable = false
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DataValue = Nothing
        Me.cboAccountIdNo.DefaultValue = ""
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.EndFindValue = Nothing
        Me.cboAccountIdNo.FieldDescription = Nothing
        Me.cboAccountIdNo.FieldName = Nothing
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboAccountIdNo.FindEnabled = false
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.IntegralHeight = false
        Me.cboAccountIdNo.LimitToList = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Location = New System.Drawing.Point(163, 118)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(355, 24)
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TabIndex = 9
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatNumber.Location = New System.Drawing.Point(520, 118)
        Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatNumber.Name = "lblVatNumber"
        Me.lblVatNumber.Size = New System.Drawing.Size(97, 23)
        Me.lblVatNumber.TabIndex = 0
        Me.lblVatNumber.Text = "Vat Number:"
        Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVatNumber.Translatable = true
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BegFindValue = Nothing
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.txtVatNumber.EndFindValue = Nothing
        Me.txtVatNumber.FieldDescription = Nothing
        Me.txtVatNumber.FieldName = Nothing
        Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatNumber.FindEnabled = true
        Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
        Me.txtVatNumber.Location = New System.Drawing.Point(619, 118)
        Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MaxLength = 15
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatNumber.Size = New System.Drawing.Size(122, 23)
        Me.txtVatNumber.TabIndex = 10
        Me.txtVatNumber.Translatable = false
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(16, 144)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(145, 23)
        Me.lblNotes.TabIndex = 161
        Me.lblNotes.Text = "Description/Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNotes.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(163, 144)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(579, 46)
        Me.txtNotes.TabIndex = 11
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.CDataGridView1)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 276)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(859, 345)
        Me.CFlowLayout1.TabIndex = 6
        '
        'CDataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.CDataGridView1.BegFindValue = Nothing
        Me.CDataGridView1.Cached = false
        Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CDataGridView1.DataFilter = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CDataGridView1.DgvFooter = Nothing
        Me.CDataGridView1.DisplayOnly = false
        Me.CDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CDataGridView1.Ea = Nothing
        Me.CDataGridView1.EditingMode = false
        Me.CDataGridView1.EndFindValue = Nothing
        Me.CDataGridView1.FieldDescription = Nothing
        Me.CDataGridView1.FieldName = Nothing
        Me.CDataGridView1.FieldsDictionary = Nothing
        Me.CDataGridView1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CDataGridView1.FindEnabled = false
        Me.CDataGridView1.FirstRowDeletionEnabled = true
        Me.CDataGridView1.FirstRowInsertionEnabled = true
        Me.CDataGridView1.IgnoreCase = false
        Me.CDataGridView1.IsDirty = false
        Me.CDataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.CDataGridView1.Name = "CDataGridView1"
        Me.CDataGridView1.ReadOnly = true
        Me.CDataGridView1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CDataGridView1.SecurityKey = ""
        Me.CDataGridView1.SequenceColumn = "dgvSequence"
        Me.CDataGridView1.SequenceFieldName = "Sequence"
        Me.CDataGridView1.ShowFooter = false
        Me.CDataGridView1.ShowInsertColumnWhenEditing = true
        Me.CDataGridView1.Size = New System.Drawing.Size(594, 0)
        Me.CDataGridView1.TabIndex = 6
        Me.CDataGridView1.Translatable = true
        '
        'PurchaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1281, 777)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CFlowLayout3)
        Me.Name = "PurchaseEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout3, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout3.PerformLayout
        Me.CFlowLayout1.ResumeLayout(false)
        CType(Me.CDataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents cboSupplierIdNo As CaComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CaComboBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblInvoiceDate As CLabel
        Friend WithEvents dtpInvoiceDate As CCustomDateTimePicker
        Friend WithEvents lblDueDate As CLabel
        Friend WithEvents dtpDueDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtInvoiceNo As CTextBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CDataGridView1 As CDataGridView
    End Class
End NameSpace