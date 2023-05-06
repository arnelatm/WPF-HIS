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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvPrice = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatPercent = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.PurchaseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
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
            Me.CFlowLayout2.Location = New System.Drawing.Point(767, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(200, 149)
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
            Me.chkCancelled.TabIndex = 298
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
            Me.chkPosted.TabIndex = 299
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
            Me.lblDateAdded.TabIndex = 296
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
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(134, 23)
            Me.txtDateCreated.TabIndex = 297
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout3)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewPurchaseDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.CtDataGridView2)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(980, 543)
            Me.FlowLayoutPanel1.TabIndex = 8
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
            Me.CFlowLayout3.Controls.Add(Me.lblVatNumber)
            Me.CFlowLayout3.Controls.Add(Me.txtVatNumber)
            Me.CFlowLayout3.Controls.Add(Me.lblVatAmount)
            Me.CFlowLayout3.Controls.Add(Me.txtVatAmount)
            Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
            Me.CFlowLayout3.Size = New System.Drawing.Size(758, 149)
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
            Me.lblIdNo.Size = New System.Drawing.Size(145, 23)
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
            Me.TxtIdNo.Location = New System.Drawing.Point(163, 16)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(63, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(228, 16)
            Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Size = New System.Drawing.Size(128, 23)
            Me.lblReferenceNo.TabIndex = 158
            Me.lblReferenceNo.Text = "Reference No.:"
            Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReferenceNo.Translatable = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BegFindValue = Nothing
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.EndFindValue = Nothing
            Me.txtReferenceNo.FieldDescription = Nothing
            Me.txtReferenceNo.FieldName = Nothing
            Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReferenceNo.FindEnabled = True
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(358, 16)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(450, 16)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(130, 23)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Transaction Date:"
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(581, 15)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpTransactionDate.TabIndex = 2
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 41)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(145, 23)
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
            Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.FormattingEnabled = True
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IgnoreCase = False
            Me.cboSupplierIdNo.IntegralHeight = False
            Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(163, 41)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.ReadOnlyCombo = False
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(575, 24)
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestCharCount = 1
            Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
            Me.cboSupplierIdNo.TabIndex = 3
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.Translatable = False
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'lblTransactionType
            '
            Me.lblTransactionType.DisplayOnly = True
            Me.lblTransactionType.EditingMode = False
            Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionType.Location = New System.Drawing.Point(16, 67)
            Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionType.Name = "lblTransactionType"
            Me.lblTransactionType.Size = New System.Drawing.Size(145, 23)
            Me.lblTransactionType.TabIndex = 267
            Me.lblTransactionType.Text = "Transaction Type:"
            Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblTransactionType.Translatable = True
            '
            'cboTransactionType
            '
            Me.cboTransactionType.AlwaysEditable = False
            Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboTransactionType.BackColor = System.Drawing.Color.White
            Me.cboTransactionType.BegFindValue = Nothing
            Me.cboTransactionType.ChangingSearchValueOnly = False
            Me.cboTransactionType.CurrentSearchTerm = ""
            Me.cboTransactionType.DataValue = Nothing
            Me.cboTransactionType.DefaultValue = "0"
            Me.cboTransactionType.DisplayMember = "Name"
            Me.cboTransactionType.EditingMode = False
            Me.cboTransactionType.EndFindValue = Nothing
            Me.cboTransactionType.FieldDescription = Nothing
            Me.cboTransactionType.FieldName = Nothing
            Me.cboTransactionType.FilterRule = Nothing
            Me.cboTransactionType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboTransactionType.FindEnabled = False
            Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
            Me.cboTransactionType.HideWhenNotEditingOrAdding = False
            Me.cboTransactionType.IgnoreCase = False
            Me.cboTransactionType.IntegralHeight = False
            Me.cboTransactionType.LinkedLabel = Nothing
            Me.cboTransactionType.Location = New System.Drawing.Point(163, 67)
            Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboTransactionType.Name = "cboTransactionType"
            Me.cboTransactionType.OldValue = 0
            Me.cboTransactionType.OriginalDataSource = Nothing
            Me.cboTransactionType.OriginalList = Nothing
            Me.cboTransactionType.OverrideDropDownStyleList = False
            Me.cboTransactionType.PreviousSearchTerm = Nothing
            Me.cboTransactionType.PropertySelector = Nothing
            Me.cboTransactionType.ReadOnlyCombo = False
            Me.cboTransactionType.Size = New System.Drawing.Size(122, 24)
            Me.cboTransactionType.SuggestBoxHeight = 200
            Me.cboTransactionType.SuggestCharCount = 1
            Me.cboTransactionType.SuggestListOrderRule = Nothing
            Me.cboTransactionType.TabIndex = 4
            Me.cboTransactionType.TextToSearch = Nothing
            Me.cboTransactionType.Translatable = False
            Me.cboTransactionType.ValueIsMandatory = False
            Me.cboTransactionType.ValueIsNullable = False
            Me.cboTransactionType.ValueIsNumeric = False
            Me.cboTransactionType.ValueMember = "Code"
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(287, 67)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(96, 23)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
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
            Me.txtAmount.Location = New System.Drawing.Point(385, 67)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(90, 23)
            Me.txtAmount.TabIndex = 5
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.DisplayOnly = True
            Me.lblInvoiceDate.EditingMode = False
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceDate.Location = New System.Drawing.Point(477, 67)
            Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(130, 23)
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
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(608, 66)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = False
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpInvoiceDate.TabIndex = 6
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Translatable = False
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
            '
            'lblDueDate
            '
            Me.lblDueDate.DisplayOnly = True
            Me.lblDueDate.EditingMode = False
            Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDueDate.Location = New System.Drawing.Point(16, 93)
            Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(145, 23)
            Me.lblDueDate.TabIndex = 259
            Me.lblDueDate.Text = "Due Date:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpDueDate.Location = New System.Drawing.Point(162, 92)
            Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.ReadOnlyDp = False
            Me.dtpDueDate.SecurityKey = Nothing
            Me.dtpDueDate.ShowLongDate = False
            Me.dtpDueDate.ShowTime = False
            Me.dtpDueDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpDueDate.TabIndex = 7
            Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDueDate.Translatable = False
            Me.dtpDueDate.Value = Nothing
            Me.dtpDueDate.ValueIsMandatory = False
            Me.dtpDueDate.ValueIsNullable = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(287, 93)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(325, 23)
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
            Me.txtInvoiceNo.Location = New System.Drawing.Point(614, 93)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
            Me.txtInvoiceNo.TabIndex = 8
            Me.txtInvoiceNo.Translatable = False
            Me.txtInvoiceNo.ValueIsMandatory = True
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
            Me.lblVatNumber.Size = New System.Drawing.Size(145, 23)
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
            Me.txtVatNumber.Location = New System.Drawing.Point(163, 118)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(122, 23)
            Me.txtVatNumber.TabIndex = 10
            Me.txtVatNumber.Translatable = False
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'lblVatAmount
            '
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(287, 118)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(324, 23)
            Me.lblVatAmount.TabIndex = 268
            Me.lblVatAmount.Text = "Vat Number:"
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
            Me.txtVatAmount.Location = New System.Drawing.Point(613, 118)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MaxLength = 15
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatAmount.Size = New System.Drawing.Size(122, 23)
            Me.txtVatAmount.TabIndex = 269
            Me.txtVatAmount.Translatable = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'DataGridViewPurchaseDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPurchaseDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPurchaseDetails.AutoGenerateColumns = False
            Me.DataGridViewPurchaseDetails.BegFindValue = Nothing
            Me.DataGridViewPurchaseDetails.Cached = False
            Me.DataGridViewPurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPurchaseDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvUnitIdNo, Me.dgvQuantity, Me.dgvBonusQuantity, Me.dgvDiscountAmount, Me.dgvNetAmount, Me.dgvPrice, Me.dgvVatPercent, Me.dgvVatAmount, Me.PurchaseIdNoDataGridViewTextBoxColumn, Me.dgvProductIdNo, Me.dgvIdNo})
            Me.DataGridViewPurchaseDetails.DataFilter = Nothing
            Me.DataGridViewPurchaseDetails.DataSource = Me.bsPurchaseDetails
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPurchaseDetails.DefaultCellStyle = DataGridViewCellStyle12
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
            Me.DataGridViewPurchaseDetails.Size = New System.Drawing.Size(950, 335)
            Me.DataGridViewPurchaseDetails.TabIndex = 8
            Me.DataGridViewPurchaseDetails.Translatable = True
            '
            'CtDataGridView2
            '
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.FloralWhite
            Me.CtDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
            Me.CtDataGridView2.BegFindValue = Nothing
            Me.CtDataGridView2.Cached = False
            Me.CtDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView2.DataFilter = Nothing
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView2.DefaultCellStyle = DataGridViewCellStyle14
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
            Me.CtDataGridView2.Location = New System.Drawing.Point(959, 158)
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
            Me.dgvSequence.Width = 40
            '
            'dgvProductCode
            '
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            Me.dgvProductCode.HeaderText = "Product Code"
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Width = 60
            '
            'dgvProductName
            '
            Me.dgvProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductName.DataPropertyName = "ProductName"
            Me.dgvProductName.HeaderText = "ProductName"
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
            Me.dgvUnitIdNo.Width = 80
            '
            'dgvQuantity
            '
            Me.dgvQuantity.DataPropertyName = "Quantity"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.HeaderText = "Quantity"
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQuantity.Translatable = False
            Me.dgvQuantity.Width = 60
            '
            'dgvBonusQuantity
            '
            Me.dgvBonusQuantity.DataPropertyName = "BonusQuantity"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvBonusQuantity.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvBonusQuantity.EditingMode = False
            Me.dgvBonusQuantity.HeaderText = "Bonus Quantity"
            Me.dgvBonusQuantity.Name = "dgvBonusQuantity"
            Me.dgvBonusQuantity.ReadOnly = True
            Me.dgvBonusQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBonusQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvBonusQuantity.Translatable = False
            Me.dgvBonusQuantity.Width = 60
            '
            'dgvDiscountAmount
            '
            Me.dgvDiscountAmount.BegFindValue = Nothing
            Me.dgvDiscountAmount.DataPropertyName = "DiscountAmount"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.Format = "###,##0.00"
            Me.dgvDiscountAmount.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvDiscountAmount.EditingMode = False
            Me.dgvDiscountAmount.EndFindValue = Nothing
            Me.dgvDiscountAmount.FieldDescription = Nothing
            Me.dgvDiscountAmount.FieldName = Nothing
            Me.dgvDiscountAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDiscountAmount.FindEnabled = False
            Me.dgvDiscountAmount.HeaderText = "Discount Amount"
            Me.dgvDiscountAmount.Name = "dgvDiscountAmount"
            Me.dgvDiscountAmount.ReadOnly = True
            Me.dgvDiscountAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDiscountAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDiscountAmount.Translatable = False
            Me.dgvDiscountAmount.Width = 80
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle7
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
            Me.dgvNetAmount.Width = 80
            '
            'dgvPrice
            '
            Me.dgvPrice.BegFindValue = Nothing
            Me.dgvPrice.DataPropertyName = "Price"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvPrice.DefaultCellStyle = DataGridViewCellStyle8
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
            Me.dgvPrice.Width = 80
            '
            'dgvVatPercent
            '
            Me.dgvVatPercent.DataPropertyName = "VatPercent"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvVatPercent.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvVatPercent.EditingMode = False
            Me.dgvVatPercent.HeaderText = "VAT %"
            Me.dgvVatPercent.Name = "dgvVatPercent"
            Me.dgvVatPercent.ReadOnly = True
            Me.dgvVatPercent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVatPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvVatPercent.Translatable = False
            Me.dgvVatPercent.Width = 40
            '
            'dgvVatAmount
            '
            Me.dgvVatAmount.BegFindValue = Nothing
            Me.dgvVatAmount.DataPropertyName = "VatAmount"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle10
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
            Me.dgvVatAmount.Width = 70
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
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvProductIdNo.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvProductIdNo.HeaderText = "ProductId Name - Code"
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
            'PurchaseEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(984, 627)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "PurchaseEntry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
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
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents cboSupplierIdNo As CtComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CtComboBox
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
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductName As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitIdNo As CtDgvComboBoxColumn
        Friend WithEvents dgvQuantity As CDgvDecimalColumn
        Friend WithEvents dgvBonusQuantity As CDgvDecimalColumn
        Friend WithEvents dgvDiscountAmount As CdgvMoneyColumn
        Friend WithEvents dgvNetAmount As CdgvMoneyColumn
        Friend WithEvents dgvPrice As CdgvMoneyColumn
        Friend WithEvents dgvVatPercent As CDgvDecimalColumn
        Friend WithEvents dgvVatAmount As CdgvMoneyColumn
        Friend WithEvents PurchaseIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductIdNo As DataGridViewComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
    End Class
End NameSpace