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
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.DataGridViewPurchaseDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvBatchNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvAmtBefVat = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitSalesPrice = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCount = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.CtDataGridView2 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblExtraDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewPurchaseHistory = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.PurchaseIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.UnitName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.SupplierCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.SupplierName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ISPDATADataSet = New AATM.Accounts.ISPDATADataSet()
            Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
            Me.ProductIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitSalesPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NetAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatPercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvBonusQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvPrice = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.PurchaseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPurchaseDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.QuantityDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.BonusQuantityDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.BatchNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ExpiryDateDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.UnitCostDataGridViewTextBoxColumn1 = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.UnitSalesPriceDataGridViewTextBoxColumn1 = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPurchaseHistory = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            CType(Me.DataGridViewPurchaseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.CGroupBox1.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.DataGridViewPurchaseHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPurchaseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPurchaseHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(1026, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(144, 119)
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
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewPurchaseDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.CtDataGridView2)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout4)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1181, 658)
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
            Me.CFlowLayout3.Size = New System.Drawing.Size(1017, 119)
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
            Me.lblTransactionDate.Size = New System.Drawing.Size(77, 23)
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
            Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(317, 15)
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
            Me.lblInvoiceDate.Location = New System.Drawing.Point(442, 16)
            Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(141, 23)
            Me.lblInvoiceDate.TabIndex = 257
            Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(584, 15)
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
            Me.lblInvoiceNo.Location = New System.Drawing.Point(709, 16)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(165, 23)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Invoice/Reference No.:"
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
            Me.txtInvoiceNo.Location = New System.Drawing.Point(876, 16)
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
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 41)
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
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(174, 41)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.ReadOnlyCombo = False
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(825, 24)
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
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(16, 67)
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
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(174, 67)
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
            Me.lblDueDate.Location = New System.Drawing.Point(407, 67)
            Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(176, 23)
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
            Me.dtpDueDate.Location = New System.Drawing.Point(584, 66)
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
            Me.lblVatNumber.Location = New System.Drawing.Point(709, 67)
            Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNumber.Name = "lblVatNumber"
            Me.lblVatNumber.Size = New System.Drawing.Size(156, 23)
            Me.lblVatNumber.TabIndex = 0
            Me.lblVatNumber.Text = "Vat Number:"
            Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.txtVatNumber.Location = New System.Drawing.Point(867, 67)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.OverrideMaxLength = 0
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(133, 23)
            Me.txtVatNumber.TabIndex = 7
            Me.txtVatNumber.Translatable = False
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'DataGridViewPurchaseDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPurchaseDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPurchaseDetails.AutoGenerateColumns = False
            Me.DataGridViewPurchaseDetails.BegFindValue = Nothing
            Me.DataGridViewPurchaseDetails.Cached = False
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewPurchaseDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewPurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPurchaseDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvUnitIdNo, Me.dgvBatchNo, Me.dgvExpiryDate, Me.dgvQuantity, Me.dgvBonusQuantity, Me.dgvPrice, Me.dgvGrossAmount, Me.dgvDiscountPercent, Me.dgvDiscountAmount, Me.dgvAmtBefVat, Me.dgvVatPercent, Me.dgvVatAmount, Me.dgvNetAmount, Me.dgvUnitSalesPrice, Me.dgvUnitCost, Me.PurchaseIdNoDataGridViewTextBoxColumn, Me.dgvProductIdNo, Me.dgvIdNo, Me.dgvUnitCount})
            Me.DataGridViewPurchaseDetails.DataFilter = Nothing
            Me.DataGridViewPurchaseDetails.DataSource = Me.bsPurchaseDetails
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPurchaseDetails.DefaultCellStyle = DataGridViewCellStyle20
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
            Me.DataGridViewPurchaseDetails.Location = New System.Drawing.Point(3, 128)
            Me.DataGridViewPurchaseDetails.Name = "DataGridViewPurchaseDetails"
            Me.DataGridViewPurchaseDetails.ReadOnly = True
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewPurchaseDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
            Me.DataGridViewPurchaseDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPurchaseDetails.SecurityKey = ""
            Me.DataGridViewPurchaseDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewPurchaseDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewPurchaseDetails.ShowFooter = False
            Me.DataGridViewPurchaseDetails.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPurchaseDetails.Size = New System.Drawing.Size(1155, 312)
            Me.DataGridViewPurchaseDetails.TabIndex = 0
            Me.DataGridViewPurchaseDetails.Translatable = True
            '
            'dgvProductCode
            '
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            Me.dgvProductCode.HeaderText = "Code"
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Width = 40
            '
            'dgvBatchNo
            '
            Me.dgvBatchNo.BegFindValue = Nothing
            Me.dgvBatchNo.DataPropertyName = "BatchNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvBatchNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvBatchNo.EditingMode = False
            Me.dgvBatchNo.EndFindValue = Nothing
            Me.dgvBatchNo.FieldDescription = Nothing
            Me.dgvBatchNo.FieldName = Nothing
            Me.dgvBatchNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvBatchNo.FindEnabled = False
            Me.dgvBatchNo.HeaderText = "Batch No."
            Me.dgvBatchNo.IgnoreCase = False
            Me.dgvBatchNo.MaxInputLength = 10
            Me.dgvBatchNo.Name = "dgvBatchNo"
            Me.dgvBatchNo.ReadOnly = True
            Me.dgvBatchNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvBatchNo.Translatable = False
            Me.dgvBatchNo.Width = 80
            '
            'dgvExpiryDate
            '
            Me.dgvExpiryDate.DataPropertyName = "ExpiryDate"
            Me.dgvExpiryDate.HeaderText = "Expiry Date"
            Me.dgvExpiryDate.Name = "dgvExpiryDate"
            Me.dgvExpiryDate.ReadOnly = True
            Me.dgvExpiryDate.Width = 50
            '
            'dgvGrossAmount
            '
            Me.dgvGrossAmount.BegFindValue = Nothing
            Me.dgvGrossAmount.DataPropertyName = "GrossAmount"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvGrossAmount.DefaultCellStyle = DataGridViewCellStyle9
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
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvDiscountPercent.DefaultCellStyle = DataGridViewCellStyle10
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
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.Format = "###,##0.00"
            Me.dgvDiscountAmount.DefaultCellStyle = DataGridViewCellStyle11
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
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Format = "###,##0.00"
            Me.dgvAmtBefVat.DefaultCellStyle = DataGridViewCellStyle12
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
            'dgvUnitSalesPrice
            '
            Me.dgvUnitSalesPrice.DataPropertyName = "UnitSalesPrice"
            Me.dgvUnitSalesPrice.DecimalPlaces = -1
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitSalesPrice.DefaultCellStyle = DataGridViewCellStyle16
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
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 60
            '
            'dgvUnitCount
            '
            Me.dgvUnitCount.DataPropertyName = "UnitCount"
            Me.dgvUnitCount.DecimalPlaces = -1
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCount.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvUnitCount.EditingMode = False
            Me.dgvUnitCount.HeaderText = "UnitCount"
            Me.dgvUnitCount.Name = "dgvUnitCount"
            Me.dgvUnitCount.ReadOnly = True
            Me.dgvUnitCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCount.Translatable = False
            Me.dgvUnitCount.Visible = False
            '
            'CtDataGridView2
            '
            DataGridViewCellStyle22.BackColor = System.Drawing.Color.FloralWhite
            Me.CtDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle22
            Me.CtDataGridView2.BegFindValue = Nothing
            Me.CtDataGridView2.Cached = False
            DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
            Me.CtDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView2.DataFilter = Nothing
            DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView2.DefaultCellStyle = DataGridViewCellStyle24
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
            Me.FlowLayoutPanel1.SetFlowBreak(Me.CtDataGridView2, True)
            Me.CtDataGridView2.IgnoreCase = False
            Me.CtDataGridView2.IsDirty = False
            Me.CtDataGridView2.Location = New System.Drawing.Point(1164, 128)
            Me.CtDataGridView2.Name = "CtDataGridView2"
            Me.CtDataGridView2.ReadOnly = True
            DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
            Me.CtDataGridView2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CtDataGridView2.SecurityKey = ""
            Me.CtDataGridView2.SequenceColumn = "dgvSequence"
            Me.CtDataGridView2.SequenceFieldName = "Sequence"
            Me.CtDataGridView2.ShowFooter = False
            Me.CtDataGridView2.ShowInsertColumnWhenEditing = True
            Me.CtDataGridView2.Size = New System.Drawing.Size(1, 312)
            Me.CtDataGridView2.TabIndex = 9
            Me.CtDataGridView2.Translatable = True
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.CGroupBox1)
            Me.CFlowLayout4.Location = New System.Drawing.Point(3, 446)
            Me.CFlowLayout4.Name = "CFlowLayout4"
            Me.CFlowLayout4.Size = New System.Drawing.Size(1166, 208)
            Me.CFlowLayout4.TabIndex = 12
            '
            'CGroupBox1
            '
            Me.CGroupBox1.AutoSize = True
            Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.CGroupBox1.Controls.Add(Me.CFlowLayout1)
            Me.CGroupBox1.Controls.Add(Me.DataGridViewPurchaseHistory)
            Me.CGroupBox1.DisplayOnly = True
            Me.CGroupBox1.Location = New System.Drawing.Point(3, 3)
            Me.CGroupBox1.Name = "CGroupBox1"
            Me.CGroupBox1.Size = New System.Drawing.Size(1170, 218)
            Me.CGroupBox1.TabIndex = 12
            Me.CGroupBox1.TabStop = False
            Me.CGroupBox1.Text = "Item Purchase History"
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(893, 0)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(271, 121)
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
            Me.txtGrossAmount.Size = New System.Drawing.Size(131, 23)
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
            Me.txtDiscountAmount.Size = New System.Drawing.Size(131, 23)
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
            Me.txtVatAmount.Size = New System.Drawing.Size(131, 23)
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
            Me.txtAmount.Size = New System.Drawing.Size(131, 23)
            Me.txtAmount.TabIndex = 3
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'DataGridViewPurchaseHistory
            '
            DataGridViewCellStyle26.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPurchaseHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
            Me.DataGridViewPurchaseHistory.AutoGenerateColumns = False
            Me.DataGridViewPurchaseHistory.BegFindValue = Nothing
            Me.DataGridViewPurchaseHistory.Cached = False
            DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewPurchaseHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
            Me.DataGridViewPurchaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPurchaseHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvTransactionDate, Me.PurchaseIdNo, Me.QuantityDataGridViewTextBoxColumn, Me.BonusQuantityDataGridViewTextBoxColumn, Me.UnitName, Me.BatchNoDataGridViewTextBoxColumn, Me.ExpiryDateDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn1, Me.UnitSalesPriceDataGridViewTextBoxColumn1, Me.SupplierCode, Me.SupplierName, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewPurchaseHistory.DataFilter = Nothing
            Me.DataGridViewPurchaseHistory.DataSource = Me.bsPurchaseHistory
            DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle38.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle38.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPurchaseHistory.DefaultCellStyle = DataGridViewCellStyle38
            Me.DataGridViewPurchaseHistory.DgSearch = Nothing
            Me.DataGridViewPurchaseHistory.DgvFooter = Nothing
            Me.DataGridViewPurchaseHistory.DisplayOnly = True
            Me.DataGridViewPurchaseHistory.Ea = Nothing
            Me.DataGridViewPurchaseHistory.EditingMode = False
            Me.DataGridViewPurchaseHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPurchaseHistory.EndFindValue = Nothing
            Me.DataGridViewPurchaseHistory.FieldDescription = Nothing
            Me.DataGridViewPurchaseHistory.FieldName = Nothing
            Me.DataGridViewPurchaseHistory.FieldsDictionary = Nothing
            Me.DataGridViewPurchaseHistory.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPurchaseHistory.FindEnabled = False
            Me.DataGridViewPurchaseHistory.FirstRowDeletionEnabled = True
            Me.DataGridViewPurchaseHistory.FirstRowInsertionEnabled = True
            Me.DataGridViewPurchaseHistory.IgnoreCase = False
            Me.DataGridViewPurchaseHistory.IsDirty = False
            Me.DataGridViewPurchaseHistory.Location = New System.Drawing.Point(6, 19)
            Me.DataGridViewPurchaseHistory.Name = "DataGridViewPurchaseHistory"
            Me.DataGridViewPurchaseHistory.ReadOnly = True
            DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewPurchaseHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle39
            Me.DataGridViewPurchaseHistory.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPurchaseHistory.SecurityKey = ""
            Me.DataGridViewPurchaseHistory.SequenceColumn = "dgvSequence"
            Me.DataGridViewPurchaseHistory.SequenceFieldName = "Sequence"
            Me.DataGridViewPurchaseHistory.ShowFooter = False
            Me.DataGridViewPurchaseHistory.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPurchaseHistory.Size = New System.Drawing.Size(881, 180)
            Me.DataGridViewPurchaseHistory.TabIndex = 11
            Me.DataGridViewPurchaseHistory.Translatable = True
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle28.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle28
            Me.dgvTransactionDate.EditingMode = False
            Me.dgvTransactionDate.EndFindValue = Nothing
            Me.dgvTransactionDate.FieldDescription = Nothing
            Me.dgvTransactionDate.FieldName = Nothing
            Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvTransactionDate.FindEnabled = False
            Me.dgvTransactionDate.HeaderText = "Purc. Date"
            Me.dgvTransactionDate.IgnoreCase = False
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvTransactionDate.Translatable = False
            Me.dgvTransactionDate.Width = 77
            '
            'PurchaseIdNo
            '
            Me.PurchaseIdNo.BegFindValue = Nothing
            Me.PurchaseIdNo.DataPropertyName = "PurchaseIdNo"
            DataGridViewCellStyle29.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black
            Me.PurchaseIdNo.DefaultCellStyle = DataGridViewCellStyle29
            Me.PurchaseIdNo.EditingMode = False
            Me.PurchaseIdNo.EndFindValue = Nothing
            Me.PurchaseIdNo.FieldDescription = Nothing
            Me.PurchaseIdNo.FieldName = Nothing
            Me.PurchaseIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.PurchaseIdNo.FindEnabled = False
            Me.PurchaseIdNo.HeaderText = "Purc. No"
            Me.PurchaseIdNo.IgnoreCase = False
            Me.PurchaseIdNo.Name = "PurchaseIdNo"
            Me.PurchaseIdNo.ReadOnly = True
            Me.PurchaseIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.PurchaseIdNo.Translatable = False
            Me.PurchaseIdNo.Width = 40
            '
            'UnitName
            '
            Me.UnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.UnitName.BegFindValue = Nothing
            Me.UnitName.DataPropertyName = "UnitName"
            DataGridViewCellStyle32.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle32.ForeColor = System.Drawing.Color.Black
            Me.UnitName.DefaultCellStyle = DataGridViewCellStyle32
            Me.UnitName.EditingMode = False
            Me.UnitName.EndFindValue = Nothing
            Me.UnitName.FieldDescription = Nothing
            Me.UnitName.FieldName = Nothing
            Me.UnitName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.UnitName.FindEnabled = False
            Me.UnitName.HeaderText = "Unit "
            Me.UnitName.IgnoreCase = False
            Me.UnitName.Name = "UnitName"
            Me.UnitName.ReadOnly = True
            Me.UnitName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.UnitName.Translatable = False
            Me.UnitName.Width = 51
            '
            'SupplierCode
            '
            Me.SupplierCode.BegFindValue = Nothing
            Me.SupplierCode.DataPropertyName = "SupplierCode"
            DataGridViewCellStyle36.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black
            Me.SupplierCode.DefaultCellStyle = DataGridViewCellStyle36
            Me.SupplierCode.EditingMode = False
            Me.SupplierCode.EndFindValue = Nothing
            Me.SupplierCode.FieldDescription = Nothing
            Me.SupplierCode.FieldName = Nothing
            Me.SupplierCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.SupplierCode.FindEnabled = False
            Me.SupplierCode.HeaderText = "Supp Code"
            Me.SupplierCode.IgnoreCase = False
            Me.SupplierCode.Name = "SupplierCode"
            Me.SupplierCode.ReadOnly = True
            Me.SupplierCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.SupplierCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.SupplierCode.Translatable = False
            Me.SupplierCode.Width = 40
            '
            'SupplierName
            '
            Me.SupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.SupplierName.BegFindValue = Nothing
            Me.SupplierName.DataPropertyName = "SupplierName"
            DataGridViewCellStyle37.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black
            Me.SupplierName.DefaultCellStyle = DataGridViewCellStyle37
            Me.SupplierName.EditingMode = False
            Me.SupplierName.EndFindValue = Nothing
            Me.SupplierName.FieldDescription = Nothing
            Me.SupplierName.FieldName = Nothing
            Me.SupplierName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.SupplierName.FindEnabled = False
            Me.SupplierName.HeaderText = "Supplier Name"
            Me.SupplierName.IgnoreCase = False
            Me.SupplierName.Name = "SupplierName"
            Me.SupplierName.ReadOnly = True
            Me.SupplierName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.SupplierName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.SupplierName.Translatable = False
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
            'ProductIdNoDataGridViewTextBoxColumn
            '
            Me.ProductIdNoDataGridViewTextBoxColumn.DataPropertyName = "ProductIdNo"
            Me.ProductIdNoDataGridViewTextBoxColumn.HeaderText = "ProductIdNo"
            Me.ProductIdNoDataGridViewTextBoxColumn.Name = "ProductIdNoDataGridViewTextBoxColumn"
            Me.ProductIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.ProductIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'UnitSalesPriceDataGridViewTextBoxColumn
            '
            Me.UnitSalesPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitSalesPrice"
            Me.UnitSalesPriceDataGridViewTextBoxColumn.HeaderText = "Unit Sales Price"
            Me.UnitSalesPriceDataGridViewTextBoxColumn.Name = "UnitSalesPriceDataGridViewTextBoxColumn"
            Me.UnitSalesPriceDataGridViewTextBoxColumn.ReadOnly = True
            Me.UnitSalesPriceDataGridViewTextBoxColumn.Width = 60
            '
            'UnitCostDataGridViewTextBoxColumn
            '
            Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
            Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "Unit Cost"
            Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
            Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
            Me.UnitCostDataGridViewTextBoxColumn.Width = 60
            '
            'NetAmountDataGridViewTextBoxColumn
            '
            Me.NetAmountDataGridViewTextBoxColumn.DataPropertyName = "NetAmount"
            Me.NetAmountDataGridViewTextBoxColumn.HeaderText = "Net Amount"
            Me.NetAmountDataGridViewTextBoxColumn.Name = "NetAmountDataGridViewTextBoxColumn"
            Me.NetAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.NetAmountDataGridViewTextBoxColumn.Width = 80
            '
            'VatAmountDataGridViewTextBoxColumn
            '
            Me.VatAmountDataGridViewTextBoxColumn.DataPropertyName = "VatAmount"
            Me.VatAmountDataGridViewTextBoxColumn.HeaderText = "Vat Amt."
            Me.VatAmountDataGridViewTextBoxColumn.Name = "VatAmountDataGridViewTextBoxColumn"
            Me.VatAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.VatAmountDataGridViewTextBoxColumn.Width = 60
            '
            'VatPercentDataGridViewTextBoxColumn
            '
            Me.VatPercentDataGridViewTextBoxColumn.DataPropertyName = "VatPercent"
            Me.VatPercentDataGridViewTextBoxColumn.HeaderText = "Vat %"
            Me.VatPercentDataGridViewTextBoxColumn.Name = "VatPercentDataGridViewTextBoxColumn"
            Me.VatPercentDataGridViewTextBoxColumn.ReadOnly = True
            Me.VatPercentDataGridViewTextBoxColumn.Width = 40
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle3
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
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle4
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
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle6
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
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvBonusQuantity.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvBonusQuantity.EditingMode = False
            Me.dgvBonusQuantity.HeaderText = "Bo- nus Qty."
            Me.dgvBonusQuantity.Name = "dgvBonusQuantity"
            Me.dgvBonusQuantity.ReadOnly = True
            Me.dgvBonusQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBonusQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvBonusQuantity.Translatable = False
            Me.dgvBonusQuantity.Width = 35
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
            Me.dgvPrice.Width = 60
            '
            'dgvVatPercent
            '
            Me.dgvVatPercent.BegFindValue = Nothing
            Me.dgvVatPercent.DataPropertyName = "VatPercent"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvVatPercent.DefaultCellStyle = DataGridViewCellStyle13
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
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "###,##0.00"
            Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle14
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
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle15
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
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.dgvProductIdNo.DefaultCellStyle = DataGridViewCellStyle18
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
            'bsPurchaseDetails
            '
            Me.bsPurchaseDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PurchaseDetailModel)
            '
            'QuantityDataGridViewTextBoxColumn
            '
            Me.QuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.QuantityDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
            DataGridViewCellStyle30.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black
            Me.QuantityDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle30
            Me.QuantityDataGridViewTextBoxColumn.EditingMode = False
            Me.QuantityDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.QuantityDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.QuantityDataGridViewTextBoxColumn.FieldName = Nothing
            Me.QuantityDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.QuantityDataGridViewTextBoxColumn.FindEnabled = False
            Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Qty"
            Me.QuantityDataGridViewTextBoxColumn.IgnoreCase = False
            Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
            Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
            Me.QuantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.QuantityDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.QuantityDataGridViewTextBoxColumn.Translatable = False
            Me.QuantityDataGridViewTextBoxColumn.Width = 48
            '
            'BonusQuantityDataGridViewTextBoxColumn
            '
            Me.BonusQuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.BonusQuantityDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.BonusQuantityDataGridViewTextBoxColumn.DataPropertyName = "BonusQuantity"
            DataGridViewCellStyle31.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle31.ForeColor = System.Drawing.Color.Black
            Me.BonusQuantityDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle31
            Me.BonusQuantityDataGridViewTextBoxColumn.EditingMode = False
            Me.BonusQuantityDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.BonusQuantityDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.BonusQuantityDataGridViewTextBoxColumn.FieldName = Nothing
            Me.BonusQuantityDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.BonusQuantityDataGridViewTextBoxColumn.FindEnabled = False
            Me.BonusQuantityDataGridViewTextBoxColumn.HeaderText = "Bon Qty"
            Me.BonusQuantityDataGridViewTextBoxColumn.IgnoreCase = False
            Me.BonusQuantityDataGridViewTextBoxColumn.Name = "BonusQuantityDataGridViewTextBoxColumn"
            Me.BonusQuantityDataGridViewTextBoxColumn.ReadOnly = True
            Me.BonusQuantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.BonusQuantityDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.BonusQuantityDataGridViewTextBoxColumn.Translatable = False
            Me.BonusQuantityDataGridViewTextBoxColumn.Width = 51
            '
            'BatchNoDataGridViewTextBoxColumn
            '
            Me.BatchNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.BatchNoDataGridViewTextBoxColumn.DataPropertyName = "BatchNo"
            Me.BatchNoDataGridViewTextBoxColumn.HeaderText = "Batch No"
            Me.BatchNoDataGridViewTextBoxColumn.Name = "BatchNoDataGridViewTextBoxColumn"
            Me.BatchNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.BatchNoDataGridViewTextBoxColumn.Width = 71
            '
            'ExpiryDateDataGridViewTextBoxColumn
            '
            Me.ExpiryDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.ExpiryDateDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.ExpiryDateDataGridViewTextBoxColumn.DataPropertyName = "ExpiryDate"
            DataGridViewCellStyle33.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black
            Me.ExpiryDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle33
            Me.ExpiryDateDataGridViewTextBoxColumn.EditingMode = False
            Me.ExpiryDateDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.ExpiryDateDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.ExpiryDateDataGridViewTextBoxColumn.FieldName = Nothing
            Me.ExpiryDateDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.ExpiryDateDataGridViewTextBoxColumn.FindEnabled = False
            Me.ExpiryDateDataGridViewTextBoxColumn.HeaderText = "Expiry Date"
            Me.ExpiryDateDataGridViewTextBoxColumn.IgnoreCase = False
            Me.ExpiryDateDataGridViewTextBoxColumn.Name = "ExpiryDateDataGridViewTextBoxColumn"
            Me.ExpiryDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.ExpiryDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ExpiryDateDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.ExpiryDateDataGridViewTextBoxColumn.Translatable = False
            Me.ExpiryDateDataGridViewTextBoxColumn.Width = 79
            '
            'UnitCostDataGridViewTextBoxColumn1
            '
            Me.UnitCostDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.UnitCostDataGridViewTextBoxColumn1.BegFindValue = Nothing
            Me.UnitCostDataGridViewTextBoxColumn1.DataPropertyName = "UnitCost"
            DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle34.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle34.Format = "###,##0.00"
            Me.UnitCostDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle34
            Me.UnitCostDataGridViewTextBoxColumn1.EditingMode = False
            Me.UnitCostDataGridViewTextBoxColumn1.EndFindValue = Nothing
            Me.UnitCostDataGridViewTextBoxColumn1.FieldDescription = Nothing
            Me.UnitCostDataGridViewTextBoxColumn1.FieldName = Nothing
            Me.UnitCostDataGridViewTextBoxColumn1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.UnitCostDataGridViewTextBoxColumn1.FindEnabled = False
            Me.UnitCostDataGridViewTextBoxColumn1.HeaderText = "Unit Cost"
            Me.UnitCostDataGridViewTextBoxColumn1.Name = "UnitCostDataGridViewTextBoxColumn1"
            Me.UnitCostDataGridViewTextBoxColumn1.ReadOnly = True
            Me.UnitCostDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.UnitCostDataGridViewTextBoxColumn1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.UnitCostDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.UnitCostDataGridViewTextBoxColumn1.Translatable = False
            Me.UnitCostDataGridViewTextBoxColumn1.Width = 21
            '
            'UnitSalesPriceDataGridViewTextBoxColumn1
            '
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.BegFindValue = Nothing
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.DataPropertyName = "UnitSalesPrice"
            DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle35.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle35.Format = "###,##0.00"
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle35
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.EditingMode = False
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.EndFindValue = Nothing
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.FieldDescription = Nothing
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.FieldName = Nothing
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.FindEnabled = False
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.HeaderText = "Unit Sales Price"
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.Name = "UnitSalesPriceDataGridViewTextBoxColumn1"
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.ReadOnly = True
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.Translatable = False
            Me.UnitSalesPriceDataGridViewTextBoxColumn1.Width = 21
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
            '
            'bsPurchaseHistory
            '
            Me.bsPurchaseHistory.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PurchaseHistoryModel)
            '
            'PurchaseEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1187, 788)
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
            CType(Me.DataGridViewPurchaseDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout()
            Me.CGroupBox1.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.DataGridViewPurchaseHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPurchaseDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPurchaseHistory, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents dgvBatchNo As CDgvTextColumn
        Friend WithEvents dgvExpiryDate As DataGridViewTextBoxColumn
        Friend WithEvents dgvQuantity As CDgvDecimalColumn
        Friend WithEvents dgvBonusQuantity As CDgvDecimalColumn
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
        Friend WithEvents DataGridViewPurchaseHistory As CtDataGridView
        Friend WithEvents CtDataGridView2 As CtDataGridView
        Friend WithEvents bsPurchaseHistory As BindingSource
        Friend WithEvents ProductIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NetAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatPercentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents PurchaseIdNo As CDgvTextColumn
        Friend WithEvents QuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents BonusQuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents UnitName As CDgvTextColumn
        Friend WithEvents BatchNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ExpiryDateDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents SupplierCode As CDgvTextColumn
        Friend WithEvents SupplierName As CDgvTextColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents CGroupBox1 As CGroupBox
    End Class
End NameSpace