Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SaleEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaleEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboPatientType = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNationality = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboGender = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.lblAge = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboAgeYmd = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.lblPhoneNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPhoneNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDoctorIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDoctorIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.DataGridViewSaleDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvBatchNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvPrice = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvAmtBefVat = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.SaleIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitCount = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvNeedsExpiryDate = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.bsSaleDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.CtDataGridView2 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblExtraDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.bsSaleHistory = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ISPDATADataSet = New AATM.Accounts.ISPDATADataSet()
            Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
            Me.ProductIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitSalesPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NetAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatPercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            CType(Me.DataGridViewSaleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsSaleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.bsSaleHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.lblJournalIdNo)
            Me.CFlowLayout2.Controls.Add(Me.txtJournalIdNo)
            Me.CFlowLayout2.Location = New System.Drawing.Point(1026, 3)
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
            Me.chkCancelled.Size = New System.Drawing.Size(111, 21)
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
            Me.chkPosted.Location = New System.Drawing.Point(3, 30)
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
            Me.lblDateAdded.Location = New System.Drawing.Point(0, 54)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(87, 21)
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
            Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, True)
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.Location = New System.Drawing.Point(1, 76)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(131, 23)
            Me.txtDateCreated.TabIndex = 3
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'lblJournalIdNo
            '
            Me.lblJournalIdNo.DisplayOnly = True
            Me.lblJournalIdNo.EditingMode = False
            Me.lblJournalIdNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblJournalIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblJournalIdNo.Location = New System.Drawing.Point(0, 100)
            Me.lblJournalIdNo.Margin = New System.Windows.Forms.Padding(0)
            Me.lblJournalIdNo.Name = "lblJournalIdNo"
            Me.lblJournalIdNo.Size = New System.Drawing.Size(134, 21)
            Me.lblJournalIdNo.TabIndex = 5
            Me.lblJournalIdNo.Text = "Journal Id No."
            Me.lblJournalIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblJournalIdNo.Translatable = True
            '
            'txtJournalIdNo
            '
            Me.txtJournalIdNo.BackColor = System.Drawing.Color.White
            Me.txtJournalIdNo.BegFindValue = Nothing
            Me.txtJournalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalIdNo.ComputedValue = False
            Me.txtJournalIdNo.CustomFormat = Nothing
            Me.txtJournalIdNo.DataBoundControl = True
            Me.txtJournalIdNo.EditingMode = True
            Me.txtJournalIdNo.EndFindValue = Nothing
            Me.txtJournalIdNo.FieldDescription = Nothing
            Me.txtJournalIdNo.FieldName = Nothing
            Me.txtJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalIdNo.FindEnabled = False
            Me.txtJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtJournalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtJournalIdNo.LinkedLabel = Nothing
            Me.txtJournalIdNo.Location = New System.Drawing.Point(1, 122)
            Me.txtJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalIdNo.MaximumValue = Nothing
            Me.txtJournalIdNo.MinimumValue = Nothing
            Me.txtJournalIdNo.Name = "txtJournalIdNo"
            Me.txtJournalIdNo.OldValue = Nothing
            Me.txtJournalIdNo.OverrideMaxLength = 0
            Me.txtJournalIdNo.ReadOnly = True
            Me.txtJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalIdNo.Size = New System.Drawing.Size(134, 23)
            Me.txtJournalIdNo.TabIndex = 4
            Me.txtJournalIdNo.TabStop = False
            Me.txtJournalIdNo.Translatable = False
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout3)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewSaleDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.CtDataGridView2)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout4)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout1)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1178, 585)
            Me.FlowLayoutPanel1.TabIndex = 8
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout3.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.lblInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.txtInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.CLabel1)
            Me.CFlowLayout3.Controls.Add(Me.txtFileNo)
            Me.CFlowLayout3.Controls.Add(Me.cboPatientType)
            Me.CFlowLayout3.Controls.Add(Me.txtPatientName)
            Me.CFlowLayout3.Controls.Add(Me.lblNationality)
            Me.CFlowLayout3.Controls.Add(Me.cboNationalityCode)
            Me.CFlowLayout3.Controls.Add(Me.lblGender)
            Me.CFlowLayout3.Controls.Add(Me.cboGender)
            Me.CFlowLayout3.Controls.Add(Me.lblAge)
            Me.CFlowLayout3.Controls.Add(Me.txtAge)
            Me.CFlowLayout3.Controls.Add(Me.cboAgeYmd)
            Me.CFlowLayout3.Controls.Add(Me.lblPhoneNo)
            Me.CFlowLayout3.Controls.Add(Me.txtPhoneNo)
            Me.CFlowLayout3.Controls.Add(Me.lblDoctorIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboDoctorIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblCustomerIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboCustomerIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblDueDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpDueDate)
            Me.CFlowLayout3.Controls.Add(Me.CLabel2)
            Me.CFlowLayout3.Controls.Add(Me.cboUserIdNo)
            Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
            Me.CFlowLayout3.Size = New System.Drawing.Size(1017, 149)
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
            Me.TxtIdNo.Size = New System.Drawing.Size(116, 23)
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
            Me.lblTransactionDate.Location = New System.Drawing.Point(292, 16)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(148, 23)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Invoice Date:"
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(441, 15)
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
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(566, 16)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(298, 23)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Invoice No.:"
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
            Me.txtInvoiceNo.Location = New System.Drawing.Point(866, 16)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.OverrideMaxLength = 0
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(132, 23)
            Me.txtInvoiceNo.TabIndex = 2
            Me.txtInvoiceNo.Translatable = False
            Me.txtInvoiceNo.ValueIsMandatory = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(16, 41)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(156, 23)
            Me.CLabel1.TabIndex = 260
            Me.CLabel1.Text = "Patient File No./Name"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtFileNo
            '
            Me.txtFileNo.BackColor = System.Drawing.Color.White
            Me.txtFileNo.BegFindValue = Nothing
            Me.txtFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFileNo.ComputedValue = True
            Me.txtFileNo.CustomFormat = Nothing
            Me.txtFileNo.DataBoundControl = True
            Me.txtFileNo.EditingMode = True
            Me.txtFileNo.EndFindValue = Nothing
            Me.txtFileNo.FieldDescription = Nothing
            Me.txtFileNo.FieldName = Nothing
            Me.txtFileNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFileNo.FindEnabled = True
            Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFileNo.ForeColor = System.Drawing.Color.Black
            Me.txtFileNo.LinkedLabel = Me.lblIdNo
            Me.txtFileNo.Location = New System.Drawing.Point(174, 41)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(116, 23)
            Me.txtFileNo.TabIndex = 3
            Me.txtFileNo.Translatable = False
            Me.txtFileNo.ValueIsNumeric = True
            '
            'cboPatientType
            '
            Me.cboPatientType.BackColor = System.Drawing.Color.White
            Me.cboPatientType.BegFindValue = Nothing
            Me.cboPatientType.ChangingSearchValueOnly = False
            Me.cboPatientType.CurrentSearchTerm = ""
            Me.cboPatientType.DataValue = Nothing
            Me.cboPatientType.DefaultValue = Nothing
            Me.cboPatientType.DisplayMember = "Name"
            Me.cboPatientType.Editable = True
            Me.cboPatientType.EditingMode = True
            Me.cboPatientType.EndFindValue = Nothing
            Me.cboPatientType.FieldDescription = Nothing
            Me.cboPatientType.FieldName = Nothing
            Me.cboPatientType.FilterRule = Nothing
            Me.cboPatientType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPatientType.FindEnabled = False
            Me.cboPatientType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPatientType.ForeColor = System.Drawing.Color.Black
            Me.cboPatientType.FormattingEnabled = True
            Me.cboPatientType.HideWhenNotEditingOrAdding = False
            Me.cboPatientType.IgnoreCase = False
            Me.cboPatientType.IntegralHeight = False
            Me.cboPatientType.LimitToList = False
            Me.cboPatientType.LinkedLabel = Me.lblCustomerIdNo
            Me.cboPatientType.Location = New System.Drawing.Point(292, 41)
            Me.cboPatientType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPatientType.Name = "cboPatientType"
            Me.cboPatientType.OldValue = 0
            Me.cboPatientType.OriginalDataSource = Nothing
            Me.cboPatientType.OriginalList = Nothing
            Me.cboPatientType.OverrideDropDownStyleList = False
            Me.cboPatientType.PreviousSearchTerm = Nothing
            Me.cboPatientType.PropertySelector = Nothing
            Me.cboPatientType.Size = New System.Drawing.Size(177, 24)
            Me.cboPatientType.SuggestBoxHeight = 200
            Me.cboPatientType.SuggestCharCount = 1
            Me.cboPatientType.SuggestListOrderRule = Nothing
            Me.cboPatientType.TabIndex = 276
            Me.cboPatientType.TextToSearch = Nothing
            Me.cboPatientType.Translatable = False
            Me.cboPatientType.ValueIsMandatory = False
            Me.cboPatientType.ValueIsNullable = False
            Me.cboPatientType.ValueIsNumeric = False
            Me.cboPatientType.ValueMember = "IdNo"
            '
            'lblCustomerIdNo
            '
            Me.lblCustomerIdNo.DisplayOnly = True
            Me.lblCustomerIdNo.EditingMode = False
            Me.lblCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCustomerIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCustomerIdNo.Location = New System.Drawing.Point(410, 93)
            Me.lblCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCustomerIdNo.Name = "lblCustomerIdNo"
            Me.lblCustomerIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblCustomerIdNo.TabIndex = 254
            Me.lblCustomerIdNo.Text = "Customer Code/Name"
            Me.lblCustomerIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCustomerIdNo.Translatable = True
            '
            'txtPatientName
            '
            Me.txtPatientName.BackColor = System.Drawing.Color.White
            Me.txtPatientName.BegFindValue = Nothing
            Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPatientName.ComputedValue = True
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
            Me.txtPatientName.EditingMode = True
            Me.txtPatientName.EndFindValue = Nothing
            Me.txtPatientName.FieldDescription = Nothing
            Me.txtPatientName.FieldName = Nothing
            Me.txtPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientName.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.txtPatientName, True)
            Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientName.ForeColor = System.Drawing.Color.Black
            Me.txtPatientName.LinkedLabel = Me.lblIdNo
            Me.txtPatientName.Location = New System.Drawing.Point(471, 41)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(528, 23)
            Me.txtPatientName.TabIndex = 4
            Me.txtPatientName.Translatable = False
            Me.txtPatientName.ValueIsNumeric = True
            '
            'lblNationality
            '
            Me.lblNationality.DisplayOnly = True
            Me.lblNationality.EditingMode = False
            Me.lblNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNationality.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNationality.Location = New System.Drawing.Point(16, 67)
            Me.lblNationality.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNationality.Name = "lblNationality"
            Me.lblNationality.Size = New System.Drawing.Size(156, 23)
            Me.lblNationality.TabIndex = 265
            Me.lblNationality.Text = "Nationality"
            Me.lblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNationality.Translatable = True
            '
            'cboNationalityCode
            '
            Me.cboNationalityCode.BackColor = System.Drawing.Color.White
            Me.cboNationalityCode.BegFindValue = Nothing
            Me.cboNationalityCode.ChangingSearchValueOnly = False
            Me.cboNationalityCode.CurrentSearchTerm = ""
            Me.cboNationalityCode.DataValue = Nothing
            Me.cboNationalityCode.DefaultValue = Nothing
            Me.cboNationalityCode.DisplayMember = "Name"
            Me.cboNationalityCode.Editable = True
            Me.cboNationalityCode.EditingMode = True
            Me.cboNationalityCode.EndFindValue = Nothing
            Me.cboNationalityCode.FieldDescription = Nothing
            Me.cboNationalityCode.FieldName = Nothing
            Me.cboNationalityCode.FilterRule = Nothing
            Me.cboNationalityCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboNationalityCode.FindEnabled = False
            Me.cboNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboNationalityCode.ForeColor = System.Drawing.Color.Black
            Me.cboNationalityCode.FormattingEnabled = True
            Me.cboNationalityCode.HideWhenNotEditingOrAdding = False
            Me.cboNationalityCode.IgnoreCase = False
            Me.cboNationalityCode.IntegralHeight = False
            Me.cboNationalityCode.LimitToList = False
            Me.cboNationalityCode.LinkedLabel = Me.lblCustomerIdNo
            Me.cboNationalityCode.Location = New System.Drawing.Point(174, 67)
            Me.cboNationalityCode.Margin = New System.Windows.Forms.Padding(1)
            Me.cboNationalityCode.Name = "cboNationalityCode"
            Me.cboNationalityCode.OldValue = 0
            Me.cboNationalityCode.OriginalDataSource = Nothing
            Me.cboNationalityCode.OriginalList = Nothing
            Me.cboNationalityCode.OverrideDropDownStyleList = False
            Me.cboNationalityCode.PreviousSearchTerm = Nothing
            Me.cboNationalityCode.PropertySelector = Nothing
            Me.cboNationalityCode.Size = New System.Drawing.Size(234, 24)
            Me.cboNationalityCode.SuggestBoxHeight = 200
            Me.cboNationalityCode.SuggestCharCount = 1
            Me.cboNationalityCode.SuggestListOrderRule = Nothing
            Me.cboNationalityCode.TabIndex = 5
            Me.cboNationalityCode.TextToSearch = Nothing
            Me.cboNationalityCode.Translatable = False
            Me.cboNationalityCode.ValueIsMandatory = False
            Me.cboNationalityCode.ValueIsNullable = False
            Me.cboNationalityCode.ValueIsNumeric = False
            Me.cboNationalityCode.ValueMember = "Code"
            '
            'lblGender
            '
            Me.lblGender.DisplayOnly = True
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblGender.Location = New System.Drawing.Point(410, 67)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(70, 23)
            Me.lblGender.TabIndex = 268
            Me.lblGender.Text = "Gender"
            Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGender.Translatable = True
            '
            'cboGender
            '
            Me.cboGender.BackColor = System.Drawing.Color.White
            Me.cboGender.BegFindValue = Nothing
            Me.cboGender.ChangingSearchValueOnly = False
            Me.cboGender.CurrentSearchTerm = ""
            Me.cboGender.DataValue = Nothing
            Me.cboGender.DefaultValue = Nothing
            Me.cboGender.DisplayMember = "Name"
            Me.cboGender.Editable = True
            Me.cboGender.EditingMode = True
            Me.cboGender.EndFindValue = Nothing
            Me.cboGender.FieldDescription = Nothing
            Me.cboGender.FieldName = Nothing
            Me.cboGender.FilterRule = Nothing
            Me.cboGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboGender.FindEnabled = False
            Me.cboGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboGender.ForeColor = System.Drawing.Color.Black
            Me.cboGender.FormattingEnabled = True
            Me.cboGender.HideWhenNotEditingOrAdding = False
            Me.cboGender.IgnoreCase = False
            Me.cboGender.IntegralHeight = False
            Me.cboGender.LimitToList = False
            Me.cboGender.LinkedLabel = Me.lblCustomerIdNo
            Me.cboGender.Location = New System.Drawing.Point(482, 67)
            Me.cboGender.Margin = New System.Windows.Forms.Padding(1)
            Me.cboGender.Name = "cboGender"
            Me.cboGender.OldValue = 0
            Me.cboGender.OriginalDataSource = Nothing
            Me.cboGender.OriginalList = Nothing
            Me.cboGender.OverrideDropDownStyleList = False
            Me.cboGender.PreviousSearchTerm = Nothing
            Me.cboGender.PropertySelector = Nothing
            Me.cboGender.Size = New System.Drawing.Size(84, 24)
            Me.cboGender.SuggestBoxHeight = 200
            Me.cboGender.SuggestListOrderRule = Nothing
            Me.cboGender.TabIndex = 6
            Me.cboGender.TextToSearch = Nothing
            Me.cboGender.Translatable = False
            Me.cboGender.ValueIsMandatory = False
            Me.cboGender.ValueIsNullable = False
            Me.cboGender.ValueIsNumeric = False
            Me.cboGender.ValueMember = "IdNo"
            '
            'lblAge
            '
            Me.lblAge.DisplayOnly = True
            Me.lblAge.EditingMode = False
            Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAge.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAge.Location = New System.Drawing.Point(568, 67)
            Me.lblAge.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAge.Name = "lblAge"
            Me.lblAge.Size = New System.Drawing.Size(55, 23)
            Me.lblAge.TabIndex = 263
            Me.lblAge.Text = "Age"
            Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAge.Translatable = True
            '
            'txtAge
            '
            Me.txtAge.BackColor = System.Drawing.Color.White
            Me.txtAge.BegFindValue = Nothing
            Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAge.ComputedValue = True
            Me.txtAge.CustomFormat = Nothing
            Me.txtAge.DataBoundControl = True
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = True
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Me.lblIdNo
            Me.txtAge.Location = New System.Drawing.Point(625, 67)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(72, 23)
            Me.txtAge.TabIndex = 7
            Me.txtAge.Translatable = False
            Me.txtAge.ValueIsNumeric = True
            '
            'cboAgeYmd
            '
            Me.cboAgeYmd.BackColor = System.Drawing.Color.White
            Me.cboAgeYmd.BegFindValue = Nothing
            Me.cboAgeYmd.ChangingSearchValueOnly = False
            Me.cboAgeYmd.CurrentSearchTerm = ""
            Me.cboAgeYmd.DataValue = Nothing
            Me.cboAgeYmd.DefaultValue = Nothing
            Me.cboAgeYmd.DisplayMember = "Name"
            Me.cboAgeYmd.Editable = True
            Me.cboAgeYmd.EditingMode = True
            Me.cboAgeYmd.EndFindValue = Nothing
            Me.cboAgeYmd.FieldDescription = Nothing
            Me.cboAgeYmd.FieldName = Nothing
            Me.cboAgeYmd.FilterRule = Nothing
            Me.cboAgeYmd.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAgeYmd.FindEnabled = False
            Me.cboAgeYmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAgeYmd.ForeColor = System.Drawing.Color.Black
            Me.cboAgeYmd.FormattingEnabled = True
            Me.cboAgeYmd.HideWhenNotEditingOrAdding = False
            Me.cboAgeYmd.IgnoreCase = False
            Me.cboAgeYmd.IntegralHeight = False
            Me.cboAgeYmd.LimitToList = False
            Me.cboAgeYmd.LinkedLabel = Me.lblCustomerIdNo
            Me.cboAgeYmd.Location = New System.Drawing.Point(699, 67)
            Me.cboAgeYmd.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAgeYmd.Name = "cboAgeYmd"
            Me.cboAgeYmd.OldValue = 0
            Me.cboAgeYmd.OriginalDataSource = Nothing
            Me.cboAgeYmd.OriginalList = Nothing
            Me.cboAgeYmd.OverrideDropDownStyleList = False
            Me.cboAgeYmd.PreviousSearchTerm = Nothing
            Me.cboAgeYmd.PropertySelector = Nothing
            Me.cboAgeYmd.Size = New System.Drawing.Size(84, 24)
            Me.cboAgeYmd.SuggestBoxHeight = 200
            Me.cboAgeYmd.SuggestListOrderRule = Nothing
            Me.cboAgeYmd.TabIndex = 277
            Me.cboAgeYmd.TextToSearch = Nothing
            Me.cboAgeYmd.Translatable = False
            Me.cboAgeYmd.ValueIsMandatory = False
            Me.cboAgeYmd.ValueIsNullable = False
            Me.cboAgeYmd.ValueIsNumeric = False
            Me.cboAgeYmd.ValueMember = "IdNo"
            '
            'lblPhoneNo
            '
            Me.lblPhoneNo.DisplayOnly = True
            Me.lblPhoneNo.EditingMode = False
            Me.lblPhoneNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhoneNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPhoneNo.Location = New System.Drawing.Point(785, 67)
            Me.lblPhoneNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhoneNo.Name = "lblPhoneNo"
            Me.lblPhoneNo.Size = New System.Drawing.Size(89, 23)
            Me.lblPhoneNo.TabIndex = 270
            Me.lblPhoneNo.Text = "Phone No"
            Me.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPhoneNo.Translatable = True
            '
            'txtPhoneNo
            '
            Me.txtPhoneNo.BackColor = System.Drawing.Color.White
            Me.txtPhoneNo.BegFindValue = Nothing
            Me.txtPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhoneNo.ComputedValue = True
            Me.txtPhoneNo.CustomFormat = Nothing
            Me.txtPhoneNo.DataBoundControl = True
            Me.txtPhoneNo.EditingMode = True
            Me.txtPhoneNo.EndFindValue = Nothing
            Me.txtPhoneNo.FieldDescription = Nothing
            Me.txtPhoneNo.FieldName = Nothing
            Me.txtPhoneNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhoneNo.FindEnabled = True
            Me.txtPhoneNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhoneNo.ForeColor = System.Drawing.Color.Black
            Me.txtPhoneNo.LinkedLabel = Me.lblIdNo
            Me.txtPhoneNo.Location = New System.Drawing.Point(876, 67)
            Me.txtPhoneNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhoneNo.MaximumValue = Nothing
            Me.txtPhoneNo.MinimumValue = Nothing
            Me.txtPhoneNo.Name = "txtPhoneNo"
            Me.txtPhoneNo.OldValue = Nothing
            Me.txtPhoneNo.OverrideMaxLength = 0
            Me.txtPhoneNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhoneNo.Size = New System.Drawing.Size(123, 23)
            Me.txtPhoneNo.TabIndex = 8
            Me.txtPhoneNo.Translatable = False
            Me.txtPhoneNo.ValueIsNumeric = True
            '
            'lblDoctorIdNo
            '
            Me.lblDoctorIdNo.DisplayOnly = True
            Me.lblDoctorIdNo.EditingMode = False
            Me.lblDoctorIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDoctorIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDoctorIdNo.Location = New System.Drawing.Point(16, 93)
            Me.lblDoctorIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDoctorIdNo.Name = "lblDoctorIdNo"
            Me.lblDoctorIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblDoctorIdNo.TabIndex = 271
            Me.lblDoctorIdNo.Text = "Doctor Code/Name"
            Me.lblDoctorIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDoctorIdNo.Translatable = True
            '
            'cboDoctorIdNo
            '
            Me.cboDoctorIdNo.BackColor = System.Drawing.Color.White
            Me.cboDoctorIdNo.BegFindValue = Nothing
            Me.cboDoctorIdNo.ChangingSearchValueOnly = False
            Me.cboDoctorIdNo.CurrentSearchTerm = ""
            Me.cboDoctorIdNo.DataValue = Nothing
            Me.cboDoctorIdNo.DefaultValue = Nothing
            Me.cboDoctorIdNo.DisplayMember = "Name"
            Me.cboDoctorIdNo.Editable = True
            Me.cboDoctorIdNo.EditingMode = True
            Me.cboDoctorIdNo.EndFindValue = Nothing
            Me.cboDoctorIdNo.FieldDescription = Nothing
            Me.cboDoctorIdNo.FieldName = Nothing
            Me.cboDoctorIdNo.FilterRule = Nothing
            Me.cboDoctorIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDoctorIdNo.FindEnabled = False
            Me.cboDoctorIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDoctorIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDoctorIdNo.FormattingEnabled = True
            Me.cboDoctorIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDoctorIdNo.IgnoreCase = False
            Me.cboDoctorIdNo.IntegralHeight = False
            Me.cboDoctorIdNo.LimitToList = False
            Me.cboDoctorIdNo.LinkedLabel = Me.lblCustomerIdNo
            Me.cboDoctorIdNo.Location = New System.Drawing.Point(174, 93)
            Me.cboDoctorIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDoctorIdNo.Name = "cboDoctorIdNo"
            Me.cboDoctorIdNo.OldValue = 0
            Me.cboDoctorIdNo.OriginalDataSource = Nothing
            Me.cboDoctorIdNo.OriginalList = Nothing
            Me.cboDoctorIdNo.OverrideDropDownStyleList = False
            Me.cboDoctorIdNo.PreviousSearchTerm = Nothing
            Me.cboDoctorIdNo.PropertySelector = Nothing
            Me.cboDoctorIdNo.Size = New System.Drawing.Size(234, 24)
            Me.cboDoctorIdNo.SuggestBoxHeight = 200
            Me.cboDoctorIdNo.SuggestCharCount = 1
            Me.cboDoctorIdNo.SuggestListOrderRule = Nothing
            Me.cboDoctorIdNo.TabIndex = 9
            Me.cboDoctorIdNo.TextToSearch = Nothing
            Me.cboDoctorIdNo.Translatable = False
            Me.cboDoctorIdNo.ValueIsMandatory = False
            Me.cboDoctorIdNo.ValueIsNullable = False
            Me.cboDoctorIdNo.ValueIsNumeric = False
            Me.cboDoctorIdNo.ValueMember = "IdNo"
            '
            'cboCustomerIdNo
            '
            Me.cboCustomerIdNo.BackColor = System.Drawing.Color.White
            Me.cboCustomerIdNo.BegFindValue = Nothing
            Me.cboCustomerIdNo.ChangingSearchValueOnly = False
            Me.cboCustomerIdNo.CurrentSearchTerm = ""
            Me.cboCustomerIdNo.DataValue = Nothing
            Me.cboCustomerIdNo.DefaultValue = Nothing
            Me.cboCustomerIdNo.DisplayMember = "Name"
            Me.cboCustomerIdNo.Editable = True
            Me.cboCustomerIdNo.EditingMode = True
            Me.cboCustomerIdNo.EndFindValue = Nothing
            Me.cboCustomerIdNo.FieldDescription = Nothing
            Me.cboCustomerIdNo.FieldName = Nothing
            Me.cboCustomerIdNo.FilterRule = Nothing
            Me.cboCustomerIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboCustomerIdNo.FindEnabled = False
            Me.CFlowLayout3.SetFlowBreak(Me.cboCustomerIdNo, True)
            Me.cboCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboCustomerIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboCustomerIdNo.FormattingEnabled = True
            Me.cboCustomerIdNo.HideWhenNotEditingOrAdding = False
            Me.cboCustomerIdNo.IgnoreCase = False
            Me.cboCustomerIdNo.IntegralHeight = False
            Me.cboCustomerIdNo.LimitToList = False
            Me.cboCustomerIdNo.LinkedLabel = Me.lblCustomerIdNo
            Me.cboCustomerIdNo.Location = New System.Drawing.Point(568, 93)
            Me.cboCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboCustomerIdNo.Name = "cboCustomerIdNo"
            Me.cboCustomerIdNo.OldValue = 0
            Me.cboCustomerIdNo.OriginalDataSource = Nothing
            Me.cboCustomerIdNo.OriginalList = Nothing
            Me.cboCustomerIdNo.OverrideDropDownStyleList = False
            Me.cboCustomerIdNo.PreviousSearchTerm = Nothing
            Me.cboCustomerIdNo.PropertySelector = Nothing
            Me.cboCustomerIdNo.Size = New System.Drawing.Size(430, 24)
            Me.cboCustomerIdNo.SuggestBoxHeight = 200
            Me.cboCustomerIdNo.SuggestCharCount = 1
            Me.cboCustomerIdNo.SuggestListOrderRule = Nothing
            Me.cboCustomerIdNo.TabIndex = 10
            Me.cboCustomerIdNo.TextToSearch = Nothing
            Me.cboCustomerIdNo.Translatable = False
            Me.cboCustomerIdNo.ValueIsMandatory = False
            Me.cboCustomerIdNo.ValueIsNullable = False
            Me.cboCustomerIdNo.ValueIsNumeric = False
            Me.cboCustomerIdNo.ValueMember = "IdNo"
            '
            'lblWarehouseIdNo
            '
            Me.lblWarehouseIdNo.DisplayOnly = True
            Me.lblWarehouseIdNo.EditingMode = False
            Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(16, 119)
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
            Me.cboWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseIdNo.BegFindValue = Nothing
            Me.cboWarehouseIdNo.ChangingSearchValueOnly = False
            Me.cboWarehouseIdNo.CurrentSearchTerm = ""
            Me.cboWarehouseIdNo.DataValue = Nothing
            Me.cboWarehouseIdNo.DefaultValue = Nothing
            Me.cboWarehouseIdNo.DisplayMember = "Name"
            Me.cboWarehouseIdNo.Editable = True
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
            Me.cboWarehouseIdNo.LimitToList = False
            Me.cboWarehouseIdNo.LinkedLabel = Me.lblCustomerIdNo
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(174, 119)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(234, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestCharCount = 1
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 11
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
            Me.lblDueDate.Location = New System.Drawing.Point(410, 119)
            Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(156, 23)
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
            Me.dtpDueDate.Location = New System.Drawing.Point(567, 118)
            Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.ReadOnlyDp = False
            Me.dtpDueDate.SecurityKey = Nothing
            Me.dtpDueDate.ShowLongDate = False
            Me.dtpDueDate.ShowTime = False
            Me.dtpDueDate.Size = New System.Drawing.Size(124, 23)
            Me.dtpDueDate.TabIndex = 12
            Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDueDate.Translatable = False
            Me.dtpDueDate.Value = Nothing
            Me.dtpDueDate.ValueIsMandatory = False
            Me.dtpDueDate.ValueIsNullable = False
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(692, 119)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(129, 23)
            Me.CLabel2.TabIndex = 273
            Me.CLabel2.Text = "User Name"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel2.Translatable = True
            '
            'cboUserIdNo
            '
            Me.cboUserIdNo.BackColor = System.Drawing.Color.White
            Me.cboUserIdNo.BegFindValue = Nothing
            Me.cboUserIdNo.ChangingSearchValueOnly = False
            Me.cboUserIdNo.CurrentSearchTerm = ""
            Me.cboUserIdNo.DataValue = Nothing
            Me.cboUserIdNo.DefaultValue = Nothing
            Me.cboUserIdNo.DisplayMember = "Name"
            Me.cboUserIdNo.DisplayOnly = True
            Me.cboUserIdNo.DropDownHeight = 21
            Me.cboUserIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboUserIdNo.Editable = True
            Me.cboUserIdNo.EditingMode = True
            Me.cboUserIdNo.EndFindValue = Nothing
            Me.cboUserIdNo.FieldDescription = Nothing
            Me.cboUserIdNo.FieldName = Nothing
            Me.cboUserIdNo.FilterRule = Nothing
            Me.cboUserIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUserIdNo.FindEnabled = False
            Me.cboUserIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUserIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboUserIdNo.FormattingEnabled = True
            Me.cboUserIdNo.HideWhenNotEditingOrAdding = False
            Me.cboUserIdNo.IgnoreCase = False
            Me.cboUserIdNo.IntegralHeight = False
            Me.cboUserIdNo.LimitToList = False
            Me.cboUserIdNo.LinkedLabel = Me.lblCustomerIdNo
            Me.cboUserIdNo.Location = New System.Drawing.Point(823, 119)
            Me.cboUserIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUserIdNo.MaxDropDownItems = 1
            Me.cboUserIdNo.Name = "cboUserIdNo"
            Me.cboUserIdNo.OldValue = 0
            Me.cboUserIdNo.OriginalDataSource = Nothing
            Me.cboUserIdNo.OriginalList = Nothing
            Me.cboUserIdNo.OverrideDropDownStyleList = False
            Me.cboUserIdNo.PreviousSearchTerm = Nothing
            Me.cboUserIdNo.PropertySelector = Nothing
            Me.cboUserIdNo.Size = New System.Drawing.Size(175, 24)
            Me.cboUserIdNo.SuggestBoxHeight = 200
            Me.cboUserIdNo.SuggestCharCount = 1
            Me.cboUserIdNo.SuggestListOrderRule = Nothing
            Me.cboUserIdNo.TabIndex = 274
            Me.cboUserIdNo.TextToSearch = Nothing
            Me.cboUserIdNo.Translatable = False
            Me.cboUserIdNo.ValueIsMandatory = False
            Me.cboUserIdNo.ValueIsNullable = False
            Me.cboUserIdNo.ValueIsNumeric = False
            Me.cboUserIdNo.ValueMember = "IdNo"
            '
            'DataGridViewSaleDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewSaleDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewSaleDetails.AutoGenerateColumns = False
            Me.DataGridViewSaleDetails.BegFindValue = Nothing
            Me.DataGridViewSaleDetails.Cached = False
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewSaleDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewSaleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewSaleDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvUnitIdNo, Me.dgvBatchNo, Me.dgvExpiryDate, Me.dgvQuantity, Me.dgvPrice, Me.dgvGrossAmount, Me.dgvDiscountPercent, Me.dgvDiscountAmount, Me.dgvAmtBefVat, Me.dgvVatPercent, Me.dgvVatAmount, Me.dgvNetAmount, Me.dgvUnitCost, Me.SaleIdNoDataGridViewTextBoxColumn, Me.dgvProductIdNo, Me.dgvIdNo, Me.dgvUnitCount, Me.dgvNeedsExpiryDate})
            Me.DataGridViewSaleDetails.DataFilter = Nothing
            Me.DataGridViewSaleDetails.DataSource = Me.bsSaleDetails
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewSaleDetails.DefaultCellStyle = DataGridViewCellStyle19
            Me.DataGridViewSaleDetails.DgvFooter = Nothing
            Me.DataGridViewSaleDetails.DisplayOnly = False
            Me.DataGridViewSaleDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewSaleDetails.Ea = Nothing
            Me.DataGridViewSaleDetails.EditingMode = False
            Me.DataGridViewSaleDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewSaleDetails.EndFindValue = Nothing
            Me.DataGridViewSaleDetails.FieldDescription = Nothing
            Me.DataGridViewSaleDetails.FieldName = Nothing
            Me.DataGridViewSaleDetails.FieldsDictionary = Nothing
            Me.DataGridViewSaleDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewSaleDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewSaleDetails.FindEnabled = False
            Me.DataGridViewSaleDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewSaleDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewSaleDetails.IgnoreCase = False
            Me.DataGridViewSaleDetails.IsDirty = False
            Me.DataGridViewSaleDetails.Location = New System.Drawing.Point(3, 158)
            Me.DataGridViewSaleDetails.Name = "DataGridViewSaleDetails"
            Me.DataGridViewSaleDetails.ReadOnly = True
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewSaleDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
            Me.DataGridViewSaleDetails.Searchable = True
            Me.DataGridViewSaleDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewSaleDetails.SecurityKey = ""
            Me.DataGridViewSaleDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewSaleDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewSaleDetails.ShowFooter = False
            Me.DataGridViewSaleDetails.Size = New System.Drawing.Size(1155, 312)
            Me.DataGridViewSaleDetails.TabIndex = 0
            Me.DataGridViewSaleDetails.Translatable = True
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
            Me.dgvExpiryDate.BegFindValue = Nothing
            Me.dgvExpiryDate.DataPropertyName = "ExpiryDate"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvExpiryDate.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvExpiryDate.EditingMode = False
            Me.dgvExpiryDate.EndFindValue = Nothing
            Me.dgvExpiryDate.FieldDescription = Nothing
            Me.dgvExpiryDate.FieldName = Nothing
            Me.dgvExpiryDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvExpiryDate.FindEnabled = False
            Me.dgvExpiryDate.HeaderText = "Expiry Date"
            Me.dgvExpiryDate.IgnoreCase = False
            Me.dgvExpiryDate.Name = "dgvExpiryDate"
            Me.dgvExpiryDate.ReadOnly = True
            Me.dgvExpiryDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvExpiryDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvExpiryDate.Translatable = False
            Me.dgvExpiryDate.Width = 50
            '
            'dgvQuantity
            '
            Me.dgvQuantity.DataPropertyName = "Quantity"
            Me.dgvQuantity.DecimalPlaces = -1
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.HeaderText = "Qty."
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQuantity.Translatable = False
            Me.dgvQuantity.Width = 35
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
            'dgvUnitCost
            '
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            Me.dgvUnitCost.DecimalPlaces = -1
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 60
            '
            'SaleIdNoDataGridViewTextBoxColumn
            '
            Me.SaleIdNoDataGridViewTextBoxColumn.DataPropertyName = "SaleIdNo"
            Me.SaleIdNoDataGridViewTextBoxColumn.HeaderText = "SaleIdNo"
            Me.SaleIdNoDataGridViewTextBoxColumn.Name = "SaleIdNoDataGridViewTextBoxColumn"
            Me.SaleIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.SaleIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'dgvProductIdNo
            '
            Me.dgvProductIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductIdNo.DataPropertyName = "ProductIdNo"
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvProductIdNo.DefaultCellStyle = DataGridViewCellStyle17
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
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCount.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvUnitCount.EditingMode = False
            Me.dgvUnitCount.HeaderText = "UnitCount"
            Me.dgvUnitCount.Name = "dgvUnitCount"
            Me.dgvUnitCount.ReadOnly = True
            Me.dgvUnitCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCount.Translatable = False
            Me.dgvUnitCount.Visible = False
            '
            'dgvNeedsExpiryDate
            '
            Me.dgvNeedsExpiryDate.DataPropertyName = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.HeaderText = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.Name = "dgvNeedsExpiryDate"
            Me.dgvNeedsExpiryDate.ReadOnly = True
            Me.dgvNeedsExpiryDate.Visible = False
            '
            'bsSaleDetails
            '
            Me.bsSaleDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.SaleDetailModel)
            '
            'CtDataGridView2
            '
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.FloralWhite
            Me.CtDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle21
            Me.CtDataGridView2.BegFindValue = Nothing
            Me.CtDataGridView2.Cached = False
            DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
            Me.CtDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView2.DataFilter = Nothing
            DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView2.DefaultCellStyle = DataGridViewCellStyle23
            Me.CtDataGridView2.DgvFooter = Nothing
            Me.CtDataGridView2.DisplayOnly = False
            Me.CtDataGridView2.Ea = Nothing
            Me.CtDataGridView2.EditingMode = False
            Me.CtDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.CtDataGridView2.EndFindValue = Nothing
            Me.CtDataGridView2.FieldDescription = Nothing
            Me.CtDataGridView2.FieldName = Nothing
            Me.CtDataGridView2.FieldsDictionary = Nothing
            Me.CtDataGridView2.FindColumnNo = CType(0, Short)
            Me.CtDataGridView2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtDataGridView2.FindEnabled = False
            Me.CtDataGridView2.FirstRowDeletionEnabled = True
            Me.CtDataGridView2.FirstRowInsertionEnabled = True
            Me.FlowLayoutPanel1.SetFlowBreak(Me.CtDataGridView2, True)
            Me.CtDataGridView2.IgnoreCase = False
            Me.CtDataGridView2.IsDirty = False
            Me.CtDataGridView2.Location = New System.Drawing.Point(1164, 158)
            Me.CtDataGridView2.Name = "CtDataGridView2"
            Me.CtDataGridView2.ReadOnly = True
            DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
            Me.CtDataGridView2.Searchable = True
            Me.CtDataGridView2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CtDataGridView2.SecurityKey = ""
            Me.CtDataGridView2.SequenceColumn = "dgvSequence"
            Me.CtDataGridView2.SequenceFieldName = "Sequence"
            Me.CtDataGridView2.ShowFooter = False
            Me.CtDataGridView2.Size = New System.Drawing.Size(1, 312)
            Me.CtDataGridView2.TabIndex = 9
            Me.CtDataGridView2.Translatable = True
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Location = New System.Drawing.Point(3, 476)
            Me.CFlowLayout4.Name = "CFlowLayout4"
            Me.CFlowLayout4.Size = New System.Drawing.Size(891, 94)
            Me.CFlowLayout4.TabIndex = 11
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(900, 476)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(267, 121)
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
            Me.txtDiscountAmount.TabIndex = 1
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
            Me.txtVatAmount.TabIndex = 2
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
            'SaleEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1178, 639)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "SaleEntry"
            Me.Text = "Sale Entry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            CType(Me.DataGridViewSaleDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsSaleDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.bsSaleHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsSaleDetails As BindingSource
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
        Friend WithEvents lblCustomerIdNo As CLabel
        Friend WithEvents cboCustomerIdNo As CtComboBox
        Friend WithEvents lblDueDate As CLabel
        Friend WithEvents dtpDueDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtInvoiceNo As CTextBox
        Friend WithEvents DataGridViewSaleDetails As CtDataGridView
        Friend WithEvents ISPDATADataSet As ISPDATADataSet
        Friend WithEvents ProductBindingSource As BindingSource
        Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
        Friend WithEvents cboWarehouseIdNo As CtComboBox
        Friend WithEvents CtDataGridView2 As CtDataGridView
        Friend WithEvents bsSaleHistory As BindingSource
        Friend WithEvents ProductIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NetAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatPercentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SaleIdNo As CDgvTextColumn
        Friend WithEvents QuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents BonusQuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents BatchNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvExpiryDateH As CDgvTextColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents CustomerCode As CDgvTextColumn
        Friend WithEvents CustomerName As CDgvTextColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvBonusQuantity As CDgvDecimalColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductName As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvBatchNo As CDgvTextColumn
        Friend WithEvents dgvExpiryDate As CDgvTextColumn
        Friend WithEvents dgvQuantity As CDgvDecimalColumn
        Friend WithEvents dgvPrice As CdgvMoneyColumn
        Friend WithEvents dgvGrossAmount As CdgvMoneyColumn
        Friend WithEvents dgvDiscountPercent As CdgvMoneyColumn
        Friend WithEvents dgvDiscountAmount As CdgvMoneyColumn
        Friend WithEvents dgvAmtBefVat As CdgvMoneyColumn
        Friend WithEvents dgvVatPercent As CdgvMoneyColumn
        Friend WithEvents dgvVatAmount As CdgvMoneyColumn
        Friend WithEvents dgvNetAmount As CdgvMoneyColumn
        Friend WithEvents dgvUnitCost As CDgvDecimalColumn
        Friend WithEvents SaleIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductIdNo As DataGridViewComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitCount As CDgvDecimalColumn
        Friend WithEvents dgvNeedsExpiryDate As DataGridViewCheckBoxColumn
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblGrossAmount As CLabel
        Friend WithEvents txtGrossAmount As CTextBox
        Friend WithEvents lblExtraDiscount As CLabel
        Friend WithEvents txtDiscountAmount As CTextBox
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtFileNo As CTextBox
        Friend WithEvents txtPatientName As CTextBox
        Friend WithEvents lblNationality As CLabel
        Friend WithEvents cboNationalityCode As CtComboBox
        Friend WithEvents lblGender As CLabel
        Friend WithEvents cboGender As CtCombobox
        Friend WithEvents lblAge As CLabel
        Friend WithEvents txtAge As CTextBox
        Friend WithEvents lblPhoneNo As CLabel
        Friend WithEvents txtPhoneNo As CTextBox
        Friend WithEvents lblDoctorIdNo As CLabel
        Friend WithEvents cboDoctorIdNo As CtComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents cboUserIdNo As CtComboBox
        Friend WithEvents txtJournalIdNo As CTextBox
        Friend WithEvents lblJournalIdNo As CLabel
        Friend WithEvents cboPatientType As CtComboBox
        Friend WithEvents cboAgeYmd As CtCombobox
    End Class
End NameSpace