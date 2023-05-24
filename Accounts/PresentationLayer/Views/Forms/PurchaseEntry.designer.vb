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
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblExtraDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewPurchaseDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.CtDataGridView2 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ISPDATADataSet = New AATM.Accounts.ISPDATADataSet()
            Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
            Me.bsPurchaseDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvBonusQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvPrice = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvAmtBefVat = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitSalesPrice = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.PurchaseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitCount = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.DataGridViewPurchaseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPurchaseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(1016, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(144, 149)
            Me.CFlowLayout2.TabIndex = 7
            '
            'chkCancelled
            '
            Me.chkCancelled.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkCancelled.BackColor = System.Drawing.Color.Transparent
            Me.chkCancelled.BegFindValue = Nothing
            Me.chkCancelled.Checked = False
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = False
            Me.chkCancelled.EndFindValue = Nothing
            Me.chkCancelled.FieldDescription = Nothing
            Me.chkCancelled.FieldName = Nothing
            Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCancelled.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.chkCancelled, True)
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Location = New System.Drawing.Point(3, 3)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCancelled.Size = New System.Drawing.Size(111, 23)
            Me.chkCancelled.TabIndex = 0
            Me.chkCancelled.Text = "Cancelled?"
            Me.chkCancelled.Translatable = True
            '
            'chkPosted
            '
            Me.chkPosted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkPosted.BackColor = System.Drawing.Color.Transparent
            Me.chkPosted.BegFindValue = Nothing
            Me.chkPosted.Checked = False
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = False
            Me.chkPosted.EndFindValue = Nothing
            Me.chkPosted.FieldDescription = Nothing
            Me.chkPosted.FieldName = Nothing
            Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPosted.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, True)
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Location = New System.Drawing.Point(3, 32)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.Size = New System.Drawing.Size(111, 21)
            Me.chkPosted.TabIndex = 1
            Me.chkPosted.Text = "Posted?"
            Me.chkPosted.Translatable = True
            '
            'lblDateAdded
            '
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            Me.lblDateAdded.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAdded.Location = New System.Drawing.Point(0, 56)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(87, 26)
            Me.lblDateAdded.TabIndex = 2
            Me.lblDateAdded.Text = "Date Added:"
            Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateAdded.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.Location = New System.Drawing.Point(1, 83)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(134, 23)
            Me.txtDateCreated.TabIndex = 3
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout3)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout1)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewPurchaseDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.CtDataGridView2)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1181, 505)
            Me.FlowLayoutPanel1.TabIndex = 8
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout3.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.lblInvoiceDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpInvoiceDate)
            Me.CFlowLayout3.Controls.Add(Me.lblInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.txtInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.lblSupplierIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboSupplierIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblDueDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpDueDate)
            Me.CFlowLayout3.Controls.Add(Me.lblVatNumber)
            Me.CFlowLayout3.Controls.Add(Me.txtVatNumber)
            Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
            Me.CFlowLayout3.Size = New System.Drawing.Size(751, 149)
            Me.CFlowLayout3.TabIndex = 10
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(16, 16)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblIdNo.TabIndex = 160
            Me.lblIdNo.Text = "Transaction No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(174, 16)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(63, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(239, 16)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(368, 23)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTransactionDate.Translatable = True
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.AutoSize = True
            Me.dtpTransactionDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(608, 15)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpTransactionDate.TabIndex = 1
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.DisplayOnly = True
            Me.lblInvoiceDate.EditingMode = False
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceDate.Location = New System.Drawing.Point(16, 41)
            Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(156, 23)
            Me.lblInvoiceDate.TabIndex = 257
            Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblInvoiceDate.Translatable = True
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.AutoSize = True
            Me.dtpInvoiceDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpInvoiceDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpInvoiceDate.DefaultValue = Nothing
            Me.dtpInvoiceDate.DisplayOnly = False
            Me.dtpInvoiceDate.DtpDefaultValue = Nothing
            Me.dtpInvoiceDate.EditingMode = False
            Me.dtpInvoiceDate.EditsAllowed = False
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.dtpInvoiceDate.LinkedLabel = Nothing
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(173, 40)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = False
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpInvoiceDate.TabIndex = 2
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Translatable = False
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(298, 41)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(309, 23)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Supplier Invoice/Reference No.:"
            Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblInvoiceNo.Translatable = True
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
            Me.txtInvoiceNo.BegFindValue = Nothing
            Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInvoiceNo.ComputedValue = False
            Me.txtInvoiceNo.CustomFormat = Nothing
            Me.txtInvoiceNo.DataBoundControl = True
            Me.txtInvoiceNo.EditingMode = False
            Me.txtInvoiceNo.EndFindValue = Nothing
            Me.txtInvoiceNo.FieldDescription = Nothing
            Me.txtInvoiceNo.FieldName = Nothing
            Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvoiceNo.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, True)
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
            Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
            Me.txtInvoiceNo.Location = New System.Drawing.Point(609, 41)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.OverrideMaxLength = 0
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(123, 23)
            Me.txtInvoiceNo.TabIndex = 3
            Me.txtInvoiceNo.Translatable = False
            Me.txtInvoiceNo.ValueIsMandatory = True
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 66)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblSupplierIdNo.TabIndex = 254
            Me.lblSupplierIdNo.Text = "Supplier Code/Name"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierIdNo.Translatable = True
            '
            'cboSupplierIdNo
            '
            Me.cboSupplierIdNo.AlwaysEditable = False
            Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
            Me.cboSupplierIdNo.BegFindValue = Nothing
            Me.cboSupplierIdNo.ChangingSearchValueOnly = False
            Me.cboSupplierIdNo.CurrentSearchTerm = ""
            Me.cboSupplierIdNo.DataValue = Nothing
            Me.cboSupplierIdNo.DefaultValue = Nothing
            Me.cboSupplierIdNo.DisplayMember = "Name"
            Me.cboSupplierIdNo.EditingMode = True
            Me.cboSupplierIdNo.EndFindValue = Nothing
            Me.cboSupplierIdNo.FieldDescription = Nothing
            Me.cboSupplierIdNo.FieldName = Nothing
            Me.cboSupplierIdNo.FilterRule = Nothing
            Me.cboSupplierIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSupplierIdNo.FindEnabled = False
            Me.CFlowLayout3.SetFlowBreak(Me.cboSupplierIdNo, True)
            Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.FormattingEnabled = True
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IgnoreCase = False
            Me.cboSupplierIdNo.IntegralHeight = False
            Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(174, 66)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.ReadOnlyCombo = False
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(558, 24)
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestCharCount = 1
            Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
            Me.cboSupplierIdNo.TabIndex = 4
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.Translatable = False
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'lblWarehouseIdNo
            '
            Me.lblWarehouseIdNo.DisplayOnly = True
            Me.lblWarehouseIdNo.EditingMode = False
            Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(16, 92)
            Me.lblWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseIdNo.Name = "lblWarehouseIdNo"
            Me.lblWarehouseIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblWarehouseIdNo.TabIndex = 158
            Me.lblWarehouseIdNo.Text = "Warehouse Name :"
            Me.lblWarehouseIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWarehouseIdNo.Translatable = True
            '
            'cboWarehouseIdNo
            '
            Me.cboWarehouseIdNo.AlwaysEditable = False
            Me.cboWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseIdNo.BegFindValue = Nothing
            Me.cboWarehouseIdNo.ChangingSearchValueOnly = False
            Me.cboWarehouseIdNo.CurrentSearchTerm = ""
            Me.cboWarehouseIdNo.DataValue = Nothing
            Me.cboWarehouseIdNo.DefaultValue = Nothing
            Me.cboWarehouseIdNo.DisplayMember = "Name"
            Me.cboWarehouseIdNo.EditingMode = True
            Me.cboWarehouseIdNo.EndFindValue = Nothing
            Me.cboWarehouseIdNo.FieldDescription = Nothing
            Me.cboWarehouseIdNo.FieldName = Nothing
            Me.cboWarehouseIdNo.FilterRule = Nothing
            Me.cboWarehouseIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboWarehouseIdNo.FindEnabled = False
            Me.cboWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseIdNo.FormattingEnabled = True
            Me.cboWarehouseIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseIdNo.IgnoreCase = False
            Me.cboWarehouseIdNo.IntegralHeight = False
            Me.cboWarehouseIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(174, 92)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.ReadOnlyCombo = False
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(231, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestCharCount = 1
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 5
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'lblDueDate
            '
            Me.lblDueDate.DisplayOnly = True
            Me.lblDueDate.EditingMode = False
            Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDueDate.Location = New System.Drawing.Point(407, 92)
            Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(200, 23)
            Me.lblDueDate.TabIndex = 259
            Me.lblDueDate.Text = "Due Date:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblDueDate.Translatable = True
            '
            'dtpDueDate
            '
            Me.dtpDueDate.AutoSize = True
            Me.dtpDueDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpDueDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDueDate.DefaultValue = Nothing
            Me.dtpDueDate.DisplayOnly = False
            Me.dtpDueDate.DtpDefaultValue = Nothing
            Me.dtpDueDate.EditingMode = False
            Me.dtpDueDate.EditsAllowed = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpDueDate.LinkedLabel = Nothing
            Me.dtpDueDate.Location = New System.Drawing.Point(608, 91)
            Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.ReadOnlyDp = False
            Me.dtpDueDate.SecurityKey = Nothing
            Me.dtpDueDate.ShowLongDate = False
            Me.dtpDueDate.ShowTime = False
            Me.dtpDueDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpDueDate.TabIndex = 6
            Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDueDate.Translatable = False
            Me.dtpDueDate.Value = Nothing
            Me.dtpDueDate.ValueIsMandatory = False
            Me.dtpDueDate.ValueIsNullable = False
            '
            'lblVatNumber
            '
            Me.lblVatNumber.DisplayOnly = True
            Me.lblVatNumber.EditingMode = False
            Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNumber.Location = New System.Drawing.Point(16, 118)
            Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNumber.Name = "lblVatNumber"
            Me.lblVatNumber.Size = New System.Drawing.Size(156, 23)
            Me.lblVatNumber.TabIndex = 0
            Me.lblVatNumber.Text = "Vat Number:"
            Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVatNumber.Translatable = True
            '
            'txtVatNumber
            '
            Me.txtVatNumber.BackColor = System.Drawing.Color.White
            Me.txtVatNumber.BegFindValue = Nothing
            Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.EndFindValue = Nothing
            Me.txtVatNumber.FieldDescription = Nothing
            Me.txtVatNumber.FieldName = Nothing
            Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatNumber.FindEnabled = True
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
            Me.txtVatNumber.Location = New System.Drawing.Point(174, 118)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.OverrideMaxLength = 0
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(146, 23)
            Me.txtVatNumber.TabIndex = 7
            Me.txtVatNumber.Translatable = False
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblGrossAmount)
            Me.CFlowLayout1.Controls.Add(Me.txtGrossAmount)
            Me.CFlowLayout1.Controls.Add(Me.lblExtraDiscount)
            Me.CFlowLayout1.Controls.Add(Me.txtDiscountAmount)
            Me.CFlowLayout1.Controls.Add(Me.lblVatAmount)
            Me.CFlowLayout1.Controls.Add(Me.txtVatAmount)
            Me.CFlowLayout1.Controls.Add(Me.lblAmount)
            Me.CFlowLayout1.Controls.Add(Me.txtAmount)
            Me.CFlowLayout1.Location = New System.Drawing.Point(760, 3)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(250, 149)
            Me.CFlowLayout1.TabIndex = 7
            '
            'lblGrossAmount
            '
            Me.lblGrossAmount.DisplayOnly = True
            Me.lblGrossAmount.EditingMode = False
            Me.lblGrossAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGrossAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblGrossAmount.Location = New System.Drawing.Point(1, 1)
            Me.lblGrossAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGrossAmount.Name = "lblGrossAmount"
            Me.lblGrossAmount.Size = New System.Drawing.Size(126, 23)
            Me.lblGrossAmount.TabIndex = 273
            Me.lblGrossAmount.Text = "Gross Amount"
            Me.lblGrossAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGrossAmount.Translatable = True
            '
            'txtGrossAmount
            '
            Me.txtGrossAmount.BackColor = System.Drawing.Color.White
            Me.txtGrossAmount.BegFindValue = Nothing
            Me.txtGrossAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGrossAmount.ComputedValue = False
            Me.txtGrossAmount.CustomFormat = Nothing
            Me.txtGrossAmount.DataBoundControl = True
            Me.txtGrossAmount.EditingMode = False
            Me.txtGrossAmount.EndFindValue = Nothing
            Me.txtGrossAmount.FieldDescription = Nothing
            Me.txtGrossAmount.FieldName = Nothing
            Me.txtGrossAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGrossAmount.FindEnabled = True
            Me.txtGrossAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGrossAmount.ForeColor = System.Drawing.Color.Black
            Me.txtGrossAmount.LinkedLabel = Me.lblGrossAmount
            Me.txtGrossAmount.Location = New System.Drawing.Point(129, 1)
            Me.txtGrossAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGrossAmount.MaximumValue = Nothing
            Me.txtGrossAmount.MinimumValue = Nothing
            Me.txtGrossAmount.Name = "txtGrossAmount"
            Me.txtGrossAmount.OldValue = Nothing
            Me.txtGrossAmount.OverrideMaxLength = 0
            Me.txtGrossAmount.ReadOnly = True
            Me.txtGrossAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGrossAmount.Size = New System.Drawing.Size(114, 23)
            Me.txtGrossAmount.TabIndex = 0
            Me.txtGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtGrossAmount.Translatable = False
            Me.txtGrossAmount.ValueIsMandatory = True
            Me.txtGrossAmount.ValueIsNumeric = True
            '
            'lblExtraDiscount
            '
            Me.lblExtraDiscount.DisplayOnly = True
            Me.lblExtraDiscount.EditingMode = False
            Me.lblExtraDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExtraDiscount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblExtraDiscount.Location = New System.Drawing.Point(1, 26)
            Me.lblExtraDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExtraDiscount.Name = "lblExtraDiscount"
            Me.lblExtraDiscount.Size = New System.Drawing.Size(126, 23)
            Me.lblExtraDiscount.TabIndex = 271
            Me.lblExtraDiscount.Text = "Discount Amount"
            Me.lblExtraDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExtraDiscount.Translatable = True
            '
            'txtDiscountAmount
            '
            Me.txtDiscountAmount.BackColor = System.Drawing.Color.White
            Me.txtDiscountAmount.BegFindValue = Nothing
            Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiscountAmount.ComputedValue = False
            Me.txtDiscountAmount.CustomFormat = Nothing
            Me.txtDiscountAmount.DataBoundControl = True
            Me.txtDiscountAmount.EditingMode = False
            Me.txtDiscountAmount.EndFindValue = Nothing
            Me.txtDiscountAmount.FieldDescription = Nothing
            Me.txtDiscountAmount.FieldName = Nothing
            Me.txtDiscountAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDiscountAmount.FindEnabled = True
            Me.txtDiscountAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDiscountAmount.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountAmount.LinkedLabel = Me.lblExtraDiscount
            Me.txtDiscountAmount.Location = New System.Drawing.Point(129, 26)
            Me.txtDiscountAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDiscountAmount.MaximumValue = Nothing
            Me.txtDiscountAmount.MinimumValue = Nothing
            Me.txtDiscountAmount.Name = "txtDiscountAmount"
            Me.txtDiscountAmount.OldValue = Nothing
            Me.txtDiscountAmount.OverrideMaxLength = 0
            Me.txtDiscountAmount.ReadOnly = True
            Me.txtDiscountAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDiscountAmount.Size = New System.Drawing.Size(114, 23)
            Me.txtDiscountAmount.TabIndex = 2
            Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtDiscountAmount.Translatable = False
            Me.txtDiscountAmount.ValueIsMandatory = True
            Me.txtDiscountAmount.ValueIsNumeric = True
            '
            'lblVatAmount
            '
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(1, 51)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(126, 23)
            Me.lblVatAmount.TabIndex = 268
            Me.lblVatAmount.Text = "Vat Amount"
            Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVatAmount.Translatable = True
            '
            'txtVatAmount
            '
            Me.txtVatAmount.BackColor = System.Drawing.Color.White
            Me.txtVatAmount.BegFindValue = Nothing
            Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = Nothing
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.EditingMode = False
            Me.txtVatAmount.EndFindValue = Nothing
            Me.txtVatAmount.FieldDescription = Nothing
            Me.txtVatAmount.FieldName = Nothing
            Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatAmount.FindEnabled = True
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblVatAmount
            Me.txtVatAmount.Location = New System.Drawing.Point(129, 51)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MaxLength = 15
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.OverrideMaxLength = 0
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatAmount.Size = New System.Drawing.Size(114, 23)
            Me.txtVatAmount.TabIndex = 1
            Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVatAmount.Translatable = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(1, 76)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(126, 23)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Invoice Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAmount.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = True
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(129, 76)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(114, 23)
            Me.txtAmount.TabIndex = 3
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'DataGridViewPurchaseDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPurchaseDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPurchaseDetails.AutoGenerateColumns = False
            Me.DataGridViewPurchaseDetails.BegFindValue = Nothing
            Me.DataGridViewPurchaseDetails.Cached = False
            Me.DataGridViewPurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPurchaseDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvUnitIdNo, Me.dgvQuantity, Me.dgvBonusQuantity, Me.dgvExpiryDate, Me.dgvPrice, Me.dgvGrossAmount, Me.dgvDiscountPercent, Me.dgvDiscountAmount, Me.dgvAmtBefVat, Me.dgvVatPercent, Me.dgvVatAmount, Me.dgvNetAmount, Me.dgvUnitSalesPrice, Me.dgvUnitCost, Me.PurchaseIdNoDataGridViewTextBoxColumn, Me.dgvProductIdNo, Me.dgvIdNo, Me.dgvUnitCount})
            Me.DataGridViewPurchaseDetails.DataFilter = Nothing
            Me.DataGridViewPurchaseDetails.DataSource = Me.bsPurchaseDetails
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPurchaseDetails.DefaultCellStyle = DataGridViewCellStyle18
            Me.DataGridViewPurchaseDetails.DgSearch = Nothing
            Me.DataGridViewPurchaseDetails.DgvFooter = Nothing
            Me.DataGridViewPurchaseDetails.DisplayOnly = False
            Me.DataGridViewPurchaseDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPurchaseDetails.Ea = Nothing
            Me.DataGridViewPurchaseDetails.EditingMode = False
            Me.DataGridViewPurchaseDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPurchaseDetails.EndFindValue = Nothing
            Me.DataGridViewPurchaseDetails.FieldDescription = Nothing
            Me.DataGridViewPurchaseDetails.FieldName = Nothing
            Me.DataGridViewPurchaseDetails.FieldsDictionary = Nothing
            Me.DataGridViewPurchaseDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPurchaseDetails.FindEnabled = False
            Me.DataGridViewPurchaseDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewPurchaseDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewPurchaseDetails.IgnoreCase = False
            Me.DataGridViewPurchaseDetails.IsDirty = False
            Me.DataGridViewPurchaseDetails.Location = New System.Drawing.Point(3, 158)
            Me.DataGridViewPurchaseDetails.Name = "DataGridViewPurchaseDetails"
            Me.DataGridViewPurchaseDetails.ReadOnly = True
            Me.DataGridViewPurchaseDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPurchaseDetails.SecurityKey = ""
            Me.DataGridViewPurchaseDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewPurchaseDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewPurchaseDetails.ShowFooter = False
            Me.DataGridViewPurchaseDetails.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPurchaseDetails.Size = New System.Drawing.Size(1150, 335)
            Me.DataGridViewPurchaseDetails.TabIndex = 0
            Me.DataGridViewPurchaseDetails.Translatable = True
            '
            'CtDataGridView2
            '
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.FloralWhite
            Me.CtDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
            Me.CtDataGridView2.BegFindValue = Nothing
            Me.CtDataGridView2.Cached = False
            Me.CtDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView2.DataFilter = Nothing
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView2.DefaultCellStyle = DataGridViewCellStyle20
            Me.CtDataGridView2.DgSearch = Nothing
            Me.CtDataGridView2.DgvFooter = Nothing
            Me.CtDataGridView2.DisplayOnly = False
            Me.CtDataGridView2.Ea = Nothing
            Me.CtDataGridView2.EditingMode = False
            Me.CtDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.CtDataGridView2.EndFindValue = Nothing
            Me.CtDataGridView2.FieldDescription = Nothing
            Me.CtDataGridView2.FieldName = Nothing
            Me.CtDataGridView2.FieldsDictionary = Nothing
            Me.CtDataGridView2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtDataGridView2.FindEnabled = False
            Me.CtDataGridView2.FirstRowDeletionEnabled = True
            Me.CtDataGridView2.FirstRowInsertionEnabled = True
            Me.CtDataGridView2.IgnoreCase = False
            Me.CtDataGridView2.IsDirty = False
            Me.CtDataGridView2.Location = New System.Drawing.Point(1159, 158)
            Me.CtDataGridView2.Name = "CtDataGridView2"
            Me.CtDataGridView2.ReadOnly = True
            Me.CtDataGridView2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CtDataGridView2.SecurityKey = ""
            Me.CtDataGridView2.SequenceColumn = "dgvSequence"
            Me.CtDataGridView2.SequenceFieldName = "Sequence"
            Me.CtDataGridView2.ShowFooter = False
            Me.CtDataGridView2.ShowInsertColumnWhenEditing = True
            Me.CtDataGridView2.Size = New System.Drawing.Size(10, 335)
            Me.CtDataGridView2.TabIndex = 9
            Me.CtDataGridView2.Translatable = True
            '
            'ProductBindingSource
            '
            Me.ProductBindingSource.DataMember = "Product"
            Me.ProductBindingSource.DataSource = Me.ISPDATADataSet
            '
            'ISPDATADataSet
            '
            Me.ISPDATADataSet.DataSetName = "ISPDATADataSet"
            Me.ISPDATADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ProductTableAdapter
            '
            Me.ProductTableAdapter.ClearBeforeFill = True
            '
            'bsPurchaseDetails
            '
            Me.bsPurchaseDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PurchaseDetailModel)
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FillWeight = 1.0!
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            Me.dgvSequence.Width = 30
            '
            'dgvProductCode
            '
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            Me.dgvProductCode.HeaderText = "Code"
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Width = 40
            '
            'dgvProductName
            '
            Me.dgvProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductName.DataPropertyName = "ProductName"
            Me.dgvProductName.HeaderText = "ProductName"
            Me.dgvProductName.MinimumWidth = 150
            Me.dgvProductName.Name = "dgvProductName"
            Me.dgvProductName.ReadOnly = True
            '
            'dgvUnitIdNo
            '
            Me.dgvUnitIdNo.AutoComplete = False
            Me.dgvUnitIdNo.DataPropertyName = "UnitIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvUnitIdNo.EditingMode = False
            Me.dgvUnitIdNo.FillWeight = 80.0!
            Me.dgvUnitIdNo.HeaderText = "Unit"
            Me.dgvUnitIdNo.Name = "dgvUnitIdNo"
            Me.dgvUnitIdNo.ReadOnly = True
            Me.dgvUnitIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitIdNo.SuggestCharCount = 0
            Me.dgvUnitIdNo.Translatable = False
            Me.dgvUnitIdNo.Width = 60
            '
            'dgvQuantity
            '
            Me.dgvQuantity.DataPropertyName = "Quantity"
            Me.dgvQuantity.DecimalPlaces = -1
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.HeaderText = "Qty."
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQuantity.Translatable = False
            Me.dgvQuantity.Width = 35
            '
            'dgvBonusQuantity
            '
            Me.dgvBonusQuantity.DataPropertyName = "BonusQuantity"
            Me.dgvBonusQuantity.DecimalPlaces = -1
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvBonusQuantity.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvBonusQuantity.EditingMode = False
            Me.dgvBonusQuantity.HeaderText = "Bo- nus Qty."
            Me.dgvBonusQuantity.Name = "dgvBonusQuantity"
            Me.dgvBonusQuantity.ReadOnly = True
            Me.dgvBonusQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBonusQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvBonusQuantity.Translatable = False
            Me.dgvBonusQuantity.Width = 35
            '
            'dgvExpiryDate
            '
            Me.dgvExpiryDate.DataPropertyName = "ExpiryDate"
            Me.dgvExpiryDate.HeaderText = "Expiry Date"
            Me.dgvExpiryDate.Name = "dgvExpiryDate"
            Me.dgvExpiryDate.ReadOnly = True
            '
            'dgvPrice
            '
            Me.dgvPrice.BegFindValue = Nothing
            Me.dgvPrice.DataPropertyName = "Price"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.Format = "###,##0.00"
            Me.dgvPrice.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvPrice.EditingMode = False
            Me.dgvPrice.EndFindValue = Nothing
            Me.dgvPrice.FieldDescription = Nothing
            Me.dgvPrice.FieldName = Nothing
            Me.dgvPrice.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPrice.FindEnabled = False
            Me.dgvPrice.HeaderText = "Price"
            Me.dgvPrice.Name = "dgvPrice"
            Me.dgvPrice.ReadOnly = True
            Me.dgvPrice.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPrice.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvPrice.Translatable = False
            Me.dgvPrice.Width = 60
            '
            'dgvGrossAmount
            '
            Me.dgvGrossAmount.BegFindValue = Nothing
            Me.dgvGrossAmount.DataPropertyName = "GrossAmount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvGrossAmount.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvGrossAmount.EditingMode = False
            Me.dgvGrossAmount.EndFindValue = Nothing
            Me.dgvGrossAmount.FieldDescription = Nothing
            Me.dgvGrossAmount.FieldName = Nothing
            Me.dgvGrossAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvGrossAmount.FindEnabled = False
            Me.dgvGrossAmount.HeaderText = "Gross Amount"
            Me.dgvGrossAmount.Name = "dgvGrossAmount"
            Me.dgvGrossAmount.ReadOnly = True
            Me.dgvGrossAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvGrossAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvGrossAmount.Translatable = False
            Me.dgvGrossAmount.Width = 70
            '
            'dgvDiscountPercent
            '
            Me.dgvDiscountPercent.BegFindValue = Nothing
            Me.dgvDiscountPercent.DataPropertyName = "DiscountPercent"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvDiscountPercent.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDiscountPercent.EditingMode = False
            Me.dgvDiscountPercent.EndFindValue = Nothing
            Me.dgvDiscountPercent.FieldDescription = Nothing
            Me.dgvDiscountPercent.FieldName = Nothing
            Me.dgvDiscountPercent.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDiscountPercent.FindEnabled = False
            Me.dgvDiscountPercent.HeaderText = "% Disc."
            Me.dgvDiscountPercent.Name = "dgvDiscountPercent"
            Me.dgvDiscountPercent.ReadOnly = True
            Me.dgvDiscountPercent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDiscountPercent.Translatable = False
            Me.dgvDiscountPercent.Width = 40
            '
            'dgvDiscountAmount
            '
            Me.dgvDiscountAmount.BegFindValue = Nothing
            Me.dgvDiscountAmount.DataPropertyName = "DiscountAmount"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvDiscountAmount.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDiscountAmount.EditingMode = False
            Me.dgvDiscountAmount.EndFindValue = Nothing
            Me.dgvDiscountAmount.FieldDescription = Nothing
            Me.dgvDiscountAmount.FieldName = Nothing
            Me.dgvDiscountAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDiscountAmount.FindEnabled = False
            Me.dgvDiscountAmount.HeaderText = "Disc. Amt."
            Me.dgvDiscountAmount.Name = "dgvDiscountAmount"
            Me.dgvDiscountAmount.ReadOnly = True
            Me.dgvDiscountAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDiscountAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDiscountAmount.Translatable = False
            Me.dgvDiscountAmount.Width = 60
            '
            'dgvAmtBefVat
            '
            Me.dgvAmtBefVat.BegFindValue = Nothing
            Me.dgvAmtBefVat.DataPropertyName = "AmtBefVat"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvAmtBefVat.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvAmtBefVat.EditingMode = False
            Me.dgvAmtBefVat.EndFindValue = Nothing
            Me.dgvAmtBefVat.FieldDescription = Nothing
            Me.dgvAmtBefVat.FieldName = Nothing
            Me.dgvAmtBefVat.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvAmtBefVat.FindEnabled = False
            Me.dgvAmtBefVat.HeaderText = "Amt. Before Vat"
            Me.dgvAmtBefVat.Name = "dgvAmtBefVat"
            Me.dgvAmtBefVat.ReadOnly = True
            Me.dgvAmtBefVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmtBefVat.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvAmtBefVat.Translatable = False
            Me.dgvAmtBefVat.Width = 60
            '
            'dgvVatPercent
            '
            Me.dgvVatPercent.BegFindValue = Nothing
            Me.dgvVatPercent.DataPropertyName = "VatPercent"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.Format = "###,##0.00"
            Me.dgvVatPercent.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvVatPercent.EditingMode = False
            Me.dgvVatPercent.EndFindValue = Nothing
            Me.dgvVatPercent.FieldDescription = Nothing
            Me.dgvVatPercent.FieldName = Nothing
            Me.dgvVatPercent.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVatPercent.FindEnabled = False
            Me.dgvVatPercent.HeaderText = "VAT %"
            Me.dgvVatPercent.Name = "dgvVatPercent"
            Me.dgvVatPercent.ReadOnly = True
            Me.dgvVatPercent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVatPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvVatPercent.Translatable = False
            Me.dgvVatPercent.Width = 40
            '
            'dgvVatAmount
            '
            Me.dgvVatAmount.BegFindValue = Nothing
            Me.dgvVatAmount.DataPropertyName = "VatAmount"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Format = "###,##0.00"
            Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvVatAmount.EditingMode = False
            Me.dgvVatAmount.EndFindValue = Nothing
            Me.dgvVatAmount.FieldDescription = Nothing
            Me.dgvVatAmount.FieldName = Nothing
            Me.dgvVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVatAmount.FindEnabled = False
            Me.dgvVatAmount.HeaderText = "VAT Amount"
            Me.dgvVatAmount.Name = "dgvVatAmount"
            Me.dgvVatAmount.ReadOnly = True
            Me.dgvVatAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvVatAmount.Translatable = False
            Me.dgvVatAmount.Width = 60
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvNetAmount.EditingMode = False
            Me.dgvNetAmount.EndFindValue = Nothing
            Me.dgvNetAmount.FieldDescription = Nothing
            Me.dgvNetAmount.FieldName = Nothing
            Me.dgvNetAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNetAmount.FindEnabled = False
            Me.dgvNetAmount.HeaderText = "Net Amount"
            Me.dgvNetAmount.Name = "dgvNetAmount"
            Me.dgvNetAmount.ReadOnly = True
            Me.dgvNetAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNetAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNetAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvNetAmount.Translatable = False
            Me.dgvNetAmount.Width = 70
            '
            'dgvUnitSalesPrice
            '
            Me.dgvUnitSalesPrice.DataPropertyName = "UnitSalesPrice"
            Me.dgvUnitSalesPrice.DecimalPlaces = -1
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitSalesPrice.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvUnitSalesPrice.EditingMode = False
            Me.dgvUnitSalesPrice.HeaderText = "Unit Sales Price"
            Me.dgvUnitSalesPrice.Name = "dgvUnitSalesPrice"
            Me.dgvUnitSalesPrice.ReadOnly = True
            Me.dgvUnitSalesPrice.Translatable = False
            Me.dgvUnitSalesPrice.Width = 60
            '
            'dgvUnitCost
            '
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            Me.dgvUnitCost.DecimalPlaces = -1
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 60
            '
            'PurchaseIdNoDataGridViewTextBoxColumn
            '
            Me.PurchaseIdNoDataGridViewTextBoxColumn.DataPropertyName = "PurchaseIdNo"
            Me.PurchaseIdNoDataGridViewTextBoxColumn.HeaderText = "PurchaseIdNo"
            Me.PurchaseIdNoDataGridViewTextBoxColumn.Name = "PurchaseIdNoDataGridViewTextBoxColumn"
            Me.PurchaseIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.PurchaseIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'dgvProductIdNo
            '
            Me.dgvProductIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductIdNo.DataPropertyName = "ProductIdNo"
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvProductIdNo.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvProductIdNo.HeaderText = "Product Id No."
            Me.dgvProductIdNo.Name = "dgvProductIdNo"
            Me.dgvProductIdNo.ReadOnly = True
            Me.dgvProductIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvProductIdNo.Visible = False
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Visible = False
            '
            'dgvUnitCount
            '
            Me.dgvUnitCount.DataPropertyName = "UnitCount"
            Me.dgvUnitCount.DecimalPlaces = -1
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCount.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvUnitCount.EditingMode = False
            Me.dgvUnitCount.HeaderText = "UnitCount"
            Me.dgvUnitCount.Name = "dgvUnitCount"
            Me.dgvUnitCount.ReadOnly = True
            Me.dgvUnitCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCount.Translatable = False
            Me.dgvUnitCount.Visible = False
            '
            'PurchaseEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1186, 570)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "PurchaseEntry"
            Me.Text = "Purchase Entry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.DataGridViewPurchaseDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPurchaseDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPurchaseDetails As BindingSource
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblWarehouseIdNo As CLabel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents cboSupplierIdNo As CtComboBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblInvoiceDate As CLabel
        Friend WithEvents dtpInvoiceDate As CCustomDateTimePicker
        Friend WithEvents lblDueDate As CLabel
        Friend WithEvents dtpDueDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtInvoiceNo As CTextBox
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents DataGridViewPurchaseDetails As CtDataGridView
        Friend WithEvents CtDataGridView2 As CtDataGridView
        Friend WithEvents ISPDATADataSet As ISPDATADataSet
        Friend WithEvents ProductBindingSource As BindingSource
        Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
        Friend WithEvents lblExtraDiscount As CLabel
        Friend WithEvents txtDiscountAmount As CTextBox
        Friend WithEvents cboWarehouseIdNo As CtComboBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblGrossAmount As CLabel
        Friend WithEvents txtGrossAmount As CTextBox
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductName As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitIdNo As CtDgvComboBoxColumn
        Friend WithEvents dgvQuantity As CDgvDecimalColumn
        Friend WithEvents dgvBonusQuantity As CDgvDecimalColumn
        Friend WithEvents dgvExpiryDate As DataGridViewTextBoxColumn
        Friend WithEvents dgvPrice As CdgvMoneyColumn
        Friend WithEvents dgvGrossAmount As CdgvMoneyColumn
        Friend WithEvents dgvDiscountPercent As CdgvMoneyColumn
        Friend WithEvents dgvDiscountAmount As CdgvMoneyColumn
        Friend WithEvents dgvAmtBefVat As CdgvMoneyColumn
        Friend WithEvents dgvVatPercent As CdgvMoneyColumn
        Friend WithEvents dgvVatAmount As CdgvMoneyColumn
        Friend WithEvents dgvNetAmount As CdgvMoneyColumn
        Friend WithEvents dgvUnitSalesPrice As CDgvDecimalColumn
        Friend WithEvents dgvUnitCost As CDgvDecimalColumn
        Friend WithEvents PurchaseIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductIdNo As DataGridViewComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitCount As CDgvDecimalColumn
    End Class
End NameSpace