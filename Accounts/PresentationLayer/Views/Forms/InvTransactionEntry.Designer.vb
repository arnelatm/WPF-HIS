Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvTransactionEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvTransactionEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblInvTransTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboInvTransTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.DataGridViewInvTransactionDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvBatchNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvDtComboBoxColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitCount = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvProductIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvDtComboBoxColumn()
            Me.dgvNeedsExpiryDate = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.BaseUnitIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CategoryIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.ProductNameAraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsInvTransactionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.DGVDummy = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.btnPost = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
            CType(Me.DataGridViewInvTransactionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTransactionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DGVDummy, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(933, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(144, 174)
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
            Me.txtDateCreated.TabIndex = 0
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout3)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewInvTransactionDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.DGVDummy)
            Me.FlowLayoutPanel1.Controls.Add(Me.btnPost)
            Me.FlowLayoutPanel1.Controls.Add(Me.CLabel4)
            Me.FlowLayoutPanel1.Controls.Add(Me.txtAmount)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1101, 562)
            Me.FlowLayoutPanel1.TabIndex = 8
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout3.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout3.Controls.Add(Me.CLabel2)
            Me.CFlowLayout3.Controls.Add(Me.txtReferenceNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.lblInvTransTypeIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboInvTransTypeIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblWarehouseToIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboWarehouseToIdNo)
            Me.CFlowLayout3.Controls.Add(Me.CLabel5)
            Me.CFlowLayout3.Controls.Add(Me.txtNotes)
            Me.CFlowLayout3.Controls.Add(Me.CLabel1)
            Me.CFlowLayout3.Controls.Add(Me.txtJournalIdNo)
            Me.CFlowLayout3.Controls.Add(Me.CLabel3)
            Me.CFlowLayout3.Controls.Add(Me.cboUserIdNo)
            Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
            Me.CFlowLayout3.Size = New System.Drawing.Size(924, 174)
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
            Me.TxtIdNo.Size = New System.Drawing.Size(123, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(299, 16)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(446, 23)
            Me.CLabel2.TabIndex = 261
            Me.CLabel2.Text = "Reference No."
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel2.Translatable = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BegFindValue = Nothing
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = True
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = True
            Me.txtReferenceNo.EndFindValue = Nothing
            Me.txtReferenceNo.FieldDescription = Nothing
            Me.txtReferenceNo.FieldName = Nothing
            Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReferenceNo.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.txtReferenceNo, True)
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblIdNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(747, 16)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(160, 23)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsNumeric = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(16, 41)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(156, 23)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Transaction Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(173, 40)
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
            'lblInvTransTypeIdNo
            '
            Me.lblInvTransTypeIdNo.DisplayOnly = True
            Me.lblInvTransTypeIdNo.EditingMode = False
            Me.lblInvTransTypeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvTransTypeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvTransTypeIdNo.Location = New System.Drawing.Point(298, 41)
            Me.lblInvTransTypeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvTransTypeIdNo.Name = "lblInvTransTypeIdNo"
            Me.lblInvTransTypeIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblInvTransTypeIdNo.TabIndex = 254
            Me.lblInvTransTypeIdNo.Text = "Inv. Trans. Type"
            Me.lblInvTransTypeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblInvTransTypeIdNo.Translatable = True
            '
            'cboInvTransTypeIdNo
            '
            Me.cboInvTransTypeIdNo.BackColor = System.Drawing.Color.White
            Me.cboInvTransTypeIdNo.BegFindValue = Nothing
            Me.cboInvTransTypeIdNo.ChangingSearchValueOnly = False
            Me.cboInvTransTypeIdNo.CurrentSearchTerm = ""
            Me.cboInvTransTypeIdNo.DataValue = Nothing
            Me.cboInvTransTypeIdNo.DefaultValue = Nothing
            Me.cboInvTransTypeIdNo.DisplayMember = "Name"
            Me.cboInvTransTypeIdNo.Editable = True
            Me.cboInvTransTypeIdNo.EditingMode = True
            Me.cboInvTransTypeIdNo.EndFindValue = Nothing
            Me.cboInvTransTypeIdNo.FieldDescription = Nothing
            Me.cboInvTransTypeIdNo.FieldName = Nothing
            Me.cboInvTransTypeIdNo.FilterRule = Nothing
            Me.cboInvTransTypeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboInvTransTypeIdNo.FindEnabled = True
            Me.cboInvTransTypeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboInvTransTypeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboInvTransTypeIdNo.FormattingEnabled = True
            Me.cboInvTransTypeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboInvTransTypeIdNo.IgnoreCase = False
            Me.cboInvTransTypeIdNo.IntegralHeight = False
            Me.cboInvTransTypeIdNo.LimitToList = False
            Me.cboInvTransTypeIdNo.LinkedLabel = Me.lblInvTransTypeIdNo
            Me.cboInvTransTypeIdNo.Location = New System.Drawing.Point(456, 41)
            Me.cboInvTransTypeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboInvTransTypeIdNo.Name = "cboInvTransTypeIdNo"
            Me.cboInvTransTypeIdNo.OldValue = 0
            Me.cboInvTransTypeIdNo.OriginalDataSource = Nothing
            Me.cboInvTransTypeIdNo.OriginalList = Nothing
            Me.cboInvTransTypeIdNo.OverrideDropDownStyleList = False
            Me.cboInvTransTypeIdNo.PreviousSearchTerm = Nothing
            Me.cboInvTransTypeIdNo.PropertySelector = Nothing
            Me.cboInvTransTypeIdNo.Size = New System.Drawing.Size(452, 24)
            Me.cboInvTransTypeIdNo.SuggestBoxHeight = 200
            Me.cboInvTransTypeIdNo.SuggestCharCount = 1
            Me.cboInvTransTypeIdNo.SuggestListOrderRule = Nothing
            Me.cboInvTransTypeIdNo.TabIndex = 3
            Me.cboInvTransTypeIdNo.TextToSearch = Nothing
            Me.cboInvTransTypeIdNo.Translatable = False
            Me.cboInvTransTypeIdNo.ValueIsMandatory = False
            Me.cboInvTransTypeIdNo.ValueIsNullable = False
            Me.cboInvTransTypeIdNo.ValueIsNumeric = False
            Me.cboInvTransTypeIdNo.ValueMember = "IdNo"
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
            Me.cboWarehouseIdNo.FindEnabled = True
            Me.cboWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseIdNo.FormattingEnabled = True
            Me.cboWarehouseIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseIdNo.IgnoreCase = False
            Me.cboWarehouseIdNo.IntegralHeight = False
            Me.cboWarehouseIdNo.LimitToList = True
            Me.cboWarehouseIdNo.LinkedLabel = Me.lblInvTransTypeIdNo
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(174, 67)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(278, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestCharCount = 1
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 8
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'lblWarehouseToIdNo
            '
            Me.lblWarehouseToIdNo.DisplayOnly = True
            Me.lblWarehouseToIdNo.EditingMode = False
            Me.lblWarehouseToIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseToIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarehouseToIdNo.Location = New System.Drawing.Point(454, 67)
            Me.lblWarehouseToIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseToIdNo.Name = "lblWarehouseToIdNo"
            Me.lblWarehouseToIdNo.Size = New System.Drawing.Size(156, 23)
            Me.lblWarehouseToIdNo.TabIndex = 267
            Me.lblWarehouseToIdNo.Text = "Warehouse To :"
            Me.lblWarehouseToIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblWarehouseToIdNo.Translatable = True
            '
            'cboWarehouseToIdNo
            '
            Me.cboWarehouseToIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseToIdNo.BegFindValue = Nothing
            Me.cboWarehouseToIdNo.ChangingSearchValueOnly = False
            Me.cboWarehouseToIdNo.CurrentSearchTerm = ""
            Me.cboWarehouseToIdNo.DataValue = Nothing
            Me.cboWarehouseToIdNo.DefaultValue = Nothing
            Me.cboWarehouseToIdNo.DisplayMember = "Name"
            Me.cboWarehouseToIdNo.Editable = True
            Me.cboWarehouseToIdNo.EditingMode = True
            Me.cboWarehouseToIdNo.EndFindValue = Nothing
            Me.cboWarehouseToIdNo.FieldDescription = Nothing
            Me.cboWarehouseToIdNo.FieldName = Nothing
            Me.cboWarehouseToIdNo.FilterRule = Nothing
            Me.cboWarehouseToIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboWarehouseToIdNo.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.cboWarehouseToIdNo, True)
            Me.cboWarehouseToIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseToIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseToIdNo.FormattingEnabled = True
            Me.cboWarehouseToIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseToIdNo.IgnoreCase = False
            Me.cboWarehouseToIdNo.IntegralHeight = False
            Me.cboWarehouseToIdNo.LimitToList = True
            Me.cboWarehouseToIdNo.LinkedLabel = Me.lblInvTransTypeIdNo
            Me.cboWarehouseToIdNo.Location = New System.Drawing.Point(612, 67)
            Me.cboWarehouseToIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseToIdNo.Name = "cboWarehouseToIdNo"
            Me.cboWarehouseToIdNo.OldValue = 0
            Me.cboWarehouseToIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseToIdNo.OriginalList = Nothing
            Me.cboWarehouseToIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseToIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseToIdNo.PropertySelector = Nothing
            Me.cboWarehouseToIdNo.Size = New System.Drawing.Size(296, 24)
            Me.cboWarehouseToIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseToIdNo.SuggestCharCount = 1
            Me.cboWarehouseToIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseToIdNo.TabIndex = 266
            Me.cboWarehouseToIdNo.TextToSearch = Nothing
            Me.cboWarehouseToIdNo.Translatable = False
            Me.cboWarehouseToIdNo.ValueIsMandatory = False
            Me.cboWarehouseToIdNo.ValueIsNullable = False
            Me.cboWarehouseToIdNo.ValueIsNumeric = False
            Me.cboWarehouseToIdNo.ValueMember = "IdNo"
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(16, 93)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(156, 23)
            Me.CLabel5.TabIndex = 271
            Me.CLabel5.Text = "Notes"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = True
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = True
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblIdNo
            Me.txtNotes.Location = New System.Drawing.Point(174, 93)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(734, 48)
            Me.txtNotes.TabIndex = 269
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsNumeric = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(16, 143)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(156, 23)
            Me.CLabel1.TabIndex = 260
            Me.CLabel1.Text = "Journal Id No."
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtJournalIdNo
            '
            Me.txtJournalIdNo.BackColor = System.Drawing.Color.White
            Me.txtJournalIdNo.BegFindValue = Nothing
            Me.txtJournalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalIdNo.ComputedValue = False
            Me.txtJournalIdNo.CustomFormat = Nothing
            Me.txtJournalIdNo.DataBoundControl = True
            Me.txtJournalIdNo.DisplayOnly = True
            Me.txtJournalIdNo.EditingMode = False
            Me.txtJournalIdNo.EndFindValue = Nothing
            Me.txtJournalIdNo.FieldDescription = Nothing
            Me.txtJournalIdNo.FieldName = Nothing
            Me.txtJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalIdNo.FindEnabled = True
            Me.txtJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtJournalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtJournalIdNo.LinkedLabel = Nothing
            Me.txtJournalIdNo.Location = New System.Drawing.Point(174, 143)
            Me.txtJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalIdNo.MaximumValue = Nothing
            Me.txtJournalIdNo.MaxLength = 15
            Me.txtJournalIdNo.MinimumValue = Nothing
            Me.txtJournalIdNo.Name = "txtJournalIdNo"
            Me.txtJournalIdNo.OldValue = Nothing
            Me.txtJournalIdNo.OverrideMaxLength = 0
            Me.txtJournalIdNo.ReadOnly = True
            Me.txtJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalIdNo.Size = New System.Drawing.Size(133, 23)
            Me.txtJournalIdNo.TabIndex = 262
            Me.txtJournalIdNo.Translatable = False
            Me.txtJournalIdNo.ValueIsMandatory = True
            Me.txtJournalIdNo.ValueIsNumeric = True
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel3.Location = New System.Drawing.Point(309, 143)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(366, 23)
            Me.CLabel3.TabIndex = 264
            Me.CLabel3.Text = "User Name"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel3.Translatable = True
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
            Me.cboUserIdNo.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.cboUserIdNo, True)
            Me.cboUserIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUserIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboUserIdNo.FormattingEnabled = True
            Me.cboUserIdNo.HideWhenNotEditingOrAdding = False
            Me.cboUserIdNo.IgnoreCase = False
            Me.cboUserIdNo.IntegralHeight = False
            Me.cboUserIdNo.LimitToList = True
            Me.cboUserIdNo.LinkedLabel = Me.lblInvTransTypeIdNo
            Me.cboUserIdNo.Location = New System.Drawing.Point(677, 143)
            Me.cboUserIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUserIdNo.MaxDropDownItems = 1
            Me.cboUserIdNo.Name = "cboUserIdNo"
            Me.cboUserIdNo.OldValue = 0
            Me.cboUserIdNo.OriginalDataSource = Nothing
            Me.cboUserIdNo.OriginalList = Nothing
            Me.cboUserIdNo.OverrideDropDownStyleList = False
            Me.cboUserIdNo.PreviousSearchTerm = Nothing
            Me.cboUserIdNo.PropertySelector = Nothing
            Me.cboUserIdNo.Size = New System.Drawing.Size(231, 24)
            Me.cboUserIdNo.SuggestBoxHeight = 200
            Me.cboUserIdNo.SuggestCharCount = 1
            Me.cboUserIdNo.SuggestListOrderRule = Nothing
            Me.cboUserIdNo.TabIndex = 268
            Me.cboUserIdNo.TextToSearch = Nothing
            Me.cboUserIdNo.Translatable = False
            Me.cboUserIdNo.ValueIsMandatory = False
            Me.cboUserIdNo.ValueIsNullable = False
            Me.cboUserIdNo.ValueIsNumeric = False
            Me.cboUserIdNo.ValueMember = "IdNo"
            '
            'DataGridViewInvTransactionDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewInvTransactionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewInvTransactionDetails.AutoGenerateColumns = False
            Me.DataGridViewInvTransactionDetails.BegFindValue = Nothing
            Me.DataGridViewInvTransactionDetails.Cached = False
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewInvTransactionDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewInvTransactionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvTransactionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvBatchNo, Me.dgvExpiryDate, Me.dgvQuantity, Me.dgvUnitIdNo, Me.dgvUnitCost, Me.dgvNetAmount, Me.dgvGrossAmount, Me.dgvDiscountPercent, Me.dgvDiscountAmount, Me.dgvUnitCount, Me.dgvProductIdNo, Me.dgvNeedsExpiryDate, Me.BaseUnitIdNoDataGridViewTextBoxColumn, Me.CategoryIdNoDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn3, Me.NeedsExpiryDateDataGridViewCheckBoxColumn, Me.ProductNameAraDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn4, Me.UnitCountDataGridViewTextBoxColumn})
            Me.DataGridViewInvTransactionDetails.DataFilter = Nothing
            Me.DataGridViewInvTransactionDetails.DataSource = Me.bsInvTransactionDetails
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransactionDetails.DefaultCellStyle = DataGridViewCellStyle17
            Me.DataGridViewInvTransactionDetails.DgvFooter = Nothing
            Me.DataGridViewInvTransactionDetails.DisplayOnly = False
            Me.DataGridViewInvTransactionDetails.Ea = Nothing
            Me.DataGridViewInvTransactionDetails.EditingMode = False
            Me.DataGridViewInvTransactionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewInvTransactionDetails.EndFindValue = Nothing
            Me.DataGridViewInvTransactionDetails.FieldDescription = Nothing
            Me.DataGridViewInvTransactionDetails.FieldName = Nothing
            Me.DataGridViewInvTransactionDetails.FieldsDictionary = Nothing
            Me.DataGridViewInvTransactionDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewInvTransactionDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewInvTransactionDetails.FindEnabled = False
            Me.DataGridViewInvTransactionDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewInvTransactionDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewInvTransactionDetails.IgnoreCase = False
            Me.DataGridViewInvTransactionDetails.IsDirty = False
            Me.DataGridViewInvTransactionDetails.Location = New System.Drawing.Point(3, 183)
            Me.DataGridViewInvTransactionDetails.Name = "DataGridViewInvTransactionDetails"
            Me.DataGridViewInvTransactionDetails.ReadOnly = True
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewInvTransactionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
            Me.DataGridViewInvTransactionDetails.Searchable = True
            Me.DataGridViewInvTransactionDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvTransactionDetails.SecurityKey = ""
            Me.DataGridViewInvTransactionDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvTransactionDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewInvTransactionDetails.ShowFooter = False
            Me.DataGridViewInvTransactionDetails.Size = New System.Drawing.Size(1074, 312)
            Me.DataGridViewInvTransactionDetails.TabIndex = 0
            Me.DataGridViewInvTransactionDetails.Translatable = True
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
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            Me.dgvSequence.HeaderText = "Seq."
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
            Me.dgvProductCode.BegFindValue = Nothing
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvProductCode.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvProductCode.EditingMode = False
            Me.dgvProductCode.EndFindValue = Nothing
            Me.dgvProductCode.FieldDescription = Nothing
            Me.dgvProductCode.FieldName = Nothing
            Me.dgvProductCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvProductCode.FindEnabled = False
            Me.dgvProductCode.HeaderText = "Code"
            Me.dgvProductCode.IgnoreCase = False
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProductCode.Translatable = False
            Me.dgvProductCode.Width = 40
            '
            'dgvProductName
            '
            Me.dgvProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductName.BegFindValue = Nothing
            Me.dgvProductName.DataPropertyName = "ProductName"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvProductName.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvProductName.EditingMode = False
            Me.dgvProductName.EndFindValue = Nothing
            Me.dgvProductName.FieldDescription = Nothing
            Me.dgvProductName.FieldName = Nothing
            Me.dgvProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvProductName.FindEnabled = False
            Me.dgvProductName.HeaderText = "ProductName"
            Me.dgvProductName.IgnoreCase = False
            Me.dgvProductName.Name = "dgvProductName"
            Me.dgvProductName.ReadOnly = True
            Me.dgvProductName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProductName.Translatable = False
            '
            'dgvBatchNo
            '
            Me.dgvBatchNo.BegFindValue = Nothing
            Me.dgvBatchNo.DataPropertyName = "BatchNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvBatchNo.DefaultCellStyle = DataGridViewCellStyle6
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
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvExpiryDate.DefaultCellStyle = DataGridViewCellStyle7
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
            Me.dgvQuantity.BegFindValue = Nothing
            Me.dgvQuantity.DataPropertyName = "Quantity"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.EndFindValue = Nothing
            Me.dgvQuantity.FieldDescription = Nothing
            Me.dgvQuantity.FieldName = Nothing
            Me.dgvQuantity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvQuantity.FindEnabled = False
            Me.dgvQuantity.HeaderText = "Quantity"
            Me.dgvQuantity.IgnoreCase = False
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvQuantity.Translatable = False
            '
            'dgvUnitIdNo
            '
            Me.dgvUnitIdNo.AutoComplete = False
            Me.dgvUnitIdNo.DataPropertyName = "UnitIdNo"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            Me.dgvUnitIdNo.EditingMode = False
            Me.dgvUnitIdNo.HeaderText = "Unit"
            Me.dgvUnitIdNo.Name = "dgvUnitIdNo"
            Me.dgvUnitIdNo.ReadOnly = True
            Me.dgvUnitIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitIdNo.Translatable = False
            '
            'dgvUnitCost
            '
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            Me.dgvUnitCost.DecimalPlaces = -1
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 60
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvNetAmount.EditingMode = False
            Me.dgvNetAmount.EndFindValue = Nothing
            Me.dgvNetAmount.FieldDescription = Nothing
            Me.dgvNetAmount.FieldName = Nothing
            Me.dgvNetAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNetAmount.FindEnabled = False
            Me.dgvNetAmount.HeaderText = "NetAmount"
            Me.dgvNetAmount.Name = "dgvNetAmount"
            Me.dgvNetAmount.ReadOnly = True
            Me.dgvNetAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNetAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNetAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvNetAmount.Translatable = False
            '
            'dgvGrossAmount
            '
            Me.dgvGrossAmount.BegFindValue = Nothing
            Me.dgvGrossAmount.DataPropertyName = "GrossAmount"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Format = "###,##0.00"
            Me.dgvGrossAmount.DefaultCellStyle = DataGridViewCellStyle12
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
            Me.dgvGrossAmount.Visible = False
            Me.dgvGrossAmount.Width = 70
            '
            'dgvDiscountPercent
            '
            Me.dgvDiscountPercent.BegFindValue = Nothing
            Me.dgvDiscountPercent.DataPropertyName = "DiscountPercent"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvDiscountPercent.DefaultCellStyle = DataGridViewCellStyle13
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
            Me.dgvDiscountPercent.Visible = False
            Me.dgvDiscountPercent.Width = 40
            '
            'dgvDiscountAmount
            '
            Me.dgvDiscountAmount.BegFindValue = Nothing
            Me.dgvDiscountAmount.DataPropertyName = "DiscountAmount"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "###,##0.00"
            Me.dgvDiscountAmount.DefaultCellStyle = DataGridViewCellStyle14
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
            Me.dgvDiscountAmount.Visible = False
            Me.dgvDiscountAmount.Width = 60
            '
            'dgvUnitCount
            '
            Me.dgvUnitCount.DataPropertyName = "UnitCount"
            Me.dgvUnitCount.DecimalPlaces = -1
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCount.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvUnitCount.EditingMode = False
            Me.dgvUnitCount.HeaderText = "UnitCount"
            Me.dgvUnitCount.Name = "dgvUnitCount"
            Me.dgvUnitCount.ReadOnly = True
            Me.dgvUnitCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCount.Translatable = False
            Me.dgvUnitCount.Visible = False
            '
            'dgvProductIdNo
            '
            Me.dgvProductIdNo.AutoComplete = False
            Me.dgvProductIdNo.DataPropertyName = "ProductIdNo"
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvProductIdNo.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvProductIdNo.EditingMode = False
            Me.dgvProductIdNo.HeaderText = "ProductIdNo"
            Me.dgvProductIdNo.Name = "dgvProductIdNo"
            Me.dgvProductIdNo.ReadOnly = True
            Me.dgvProductIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvProductIdNo.Translatable = False
            Me.dgvProductIdNo.Visible = False
            '
            'dgvNeedsExpiryDate
            '
            Me.dgvNeedsExpiryDate.DataPropertyName = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.HeaderText = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.Name = "dgvNeedsExpiryDate"
            Me.dgvNeedsExpiryDate.ReadOnly = True
            Me.dgvNeedsExpiryDate.Visible = False
            '
            'BaseUnitIdNoDataGridViewTextBoxColumn
            '
            Me.BaseUnitIdNoDataGridViewTextBoxColumn.DataPropertyName = "BaseUnitIdNo"
            Me.BaseUnitIdNoDataGridViewTextBoxColumn.HeaderText = "BaseUnitIdNo"
            Me.BaseUnitIdNoDataGridViewTextBoxColumn.Name = "BaseUnitIdNoDataGridViewTextBoxColumn"
            Me.BaseUnitIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.BaseUnitIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'CategoryIdNoDataGridViewTextBoxColumn
            '
            Me.CategoryIdNoDataGridViewTextBoxColumn.DataPropertyName = "CategoryIdNo"
            Me.CategoryIdNoDataGridViewTextBoxColumn.HeaderText = "CategoryIdNo"
            Me.CategoryIdNoDataGridViewTextBoxColumn.Name = "CategoryIdNoDataGridViewTextBoxColumn"
            Me.CategoryIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.CategoryIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn3.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            '
            'NeedsExpiryDateDataGridViewCheckBoxColumn
            '
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn.DataPropertyName = "NeedsExpiryDate"
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn.HeaderText = "NeedsExpiryDate"
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn.Name = "NeedsExpiryDateDataGridViewCheckBoxColumn"
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn.ReadOnly = True
            Me.NeedsExpiryDateDataGridViewCheckBoxColumn.Visible = False
            '
            'ProductNameAraDataGridViewTextBoxColumn
            '
            Me.ProductNameAraDataGridViewTextBoxColumn.DataPropertyName = "ProductNameAra"
            Me.ProductNameAraDataGridViewTextBoxColumn.HeaderText = "ProductNameAra"
            Me.ProductNameAraDataGridViewTextBoxColumn.Name = "ProductNameAraDataGridViewTextBoxColumn"
            Me.ProductNameAraDataGridViewTextBoxColumn.ReadOnly = True
            Me.ProductNameAraDataGridViewTextBoxColumn.Visible = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "InvTransactionIdNo"
            Me.DataGridViewTextBoxColumn4.HeaderText = "InvTransactionIdNo"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Visible = False
            '
            'UnitCountDataGridViewTextBoxColumn
            '
            Me.UnitCountDataGridViewTextBoxColumn.DataPropertyName = "UnitCount"
            Me.UnitCountDataGridViewTextBoxColumn.HeaderText = "UnitCount"
            Me.UnitCountDataGridViewTextBoxColumn.Name = "UnitCountDataGridViewTextBoxColumn"
            Me.UnitCountDataGridViewTextBoxColumn.ReadOnly = True
            Me.UnitCountDataGridViewTextBoxColumn.Visible = False
            '
            'bsInvTransactionDetails
            '
            Me.bsInvTransactionDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionDetailModel)
            '
            'DGVDummy
            '
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.FloralWhite
            Me.DGVDummy.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
            Me.DGVDummy.BegFindValue = Nothing
            Me.DGVDummy.Cached = False
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DGVDummy.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle20
            Me.DGVDummy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DGVDummy.DataFilter = Nothing
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DGVDummy.DefaultCellStyle = DataGridViewCellStyle21
            Me.DGVDummy.DgvFooter = Nothing
            Me.DGVDummy.DisplayOnly = False
            Me.DGVDummy.Ea = Nothing
            Me.DGVDummy.EditingMode = False
            Me.DGVDummy.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DGVDummy.EndFindValue = Nothing
            Me.DGVDummy.FieldDescription = Nothing
            Me.DGVDummy.FieldName = Nothing
            Me.DGVDummy.FieldsDictionary = Nothing
            Me.DGVDummy.FindColumnNo = CType(0, Short)
            Me.DGVDummy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DGVDummy.FindEnabled = False
            Me.DGVDummy.FirstRowDeletionEnabled = True
            Me.DGVDummy.FirstRowInsertionEnabled = True
            Me.FlowLayoutPanel1.SetFlowBreak(Me.DGVDummy, True)
            Me.DGVDummy.IgnoreCase = False
            Me.DGVDummy.IsDirty = False
            Me.DGVDummy.Location = New System.Drawing.Point(1083, 183)
            Me.DGVDummy.Name = "DGVDummy"
            Me.DGVDummy.ReadOnly = True
            DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DGVDummy.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
            Me.DGVDummy.Searchable = True
            Me.DGVDummy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DGVDummy.SecurityKey = ""
            Me.DGVDummy.SequenceColumn = "dgvSequence"
            Me.DGVDummy.SequenceFieldName = "Sequence"
            Me.DGVDummy.ShowFooter = False
            Me.DGVDummy.Size = New System.Drawing.Size(10, 312)
            Me.DGVDummy.TabIndex = 9
            Me.DGVDummy.Translatable = True
            '
            'btnPost
            '
            Me.btnPost.DesignerSelected = False
            Me.btnPost.ImageIndex = 0
            Me.btnPost.Location = New System.Drawing.Point(3, 501)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.OriginalImageName = Nothing
            Me.btnPost.SecurityKey = ""
            Me.btnPost.Size = New System.Drawing.Size(229, 25)
            Me.btnPost.TabIndex = 275
            Me.btnPost.Text = "Post Inventory Transaction"
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(236, 499)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(739, 23)
            Me.CLabel4.TabIndex = 273
            Me.CLabel4.Text = "Total"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel4.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = True
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = False
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Nothing
            Me.txtAmount.Location = New System.Drawing.Point(977, 499)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(100, 23)
            Me.txtAmount.TabIndex = 274
            Me.txtAmount.Translatable = False
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
            'InvTransactionEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1115, 592)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "InvTransactionEntry"
            Me.Text = "InvTransaction Entry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            CType(Me.DataGridViewInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DGVDummy, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsInvTransactionDetails As BindingSource
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
        Friend WithEvents lblInvTransTypeIdNo As CLabel
        Friend WithEvents cboInvTransTypeIdNo As CtComboBox
        Friend WithEvents DataGridViewInvTransactionDetails As CtDataGridView
        Friend WithEvents ProductBindingSource As BindingSource
        Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
        Friend WithEvents cboWarehouseIdNo As CtComboBox
        Friend WithEvents DGVDummy As CtDataGridView
        Friend WithEvents ProductIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NetAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatPercentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents InvTransactionIdNo As CDgvTextColumn
        Friend WithEvents QuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents BonusQuantityDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents BatchNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents dgvExpiryDateH As CDgvTextColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn1 As CdgvMoneyColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtJournalIdNo As CTextBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents dgvPrice As CdgvMoneyColumn
        Friend WithEvents InvTransactionIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents lblWarehouseToIdNo As CLabel
        Friend WithEvents cboWarehouseToIdNo As CtComboBox
        Friend WithEvents cboUserIdNo As CtComboBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents PriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents btnPost As CButton
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As CDgvTextColumn
        Friend WithEvents dgvProductName As CDgvTextColumn
        Friend WithEvents dgvBatchNo As CDgvTextColumn
        Friend WithEvents dgvExpiryDate As CDgvTextColumn
        Friend WithEvents dgvQuantity As CDgvTextColumn
        Friend WithEvents dgvUnitIdNo As CDgvDtComboBoxColumn
        Friend WithEvents dgvUnitCost As CDgvDecimalColumn
        Friend WithEvents dgvNetAmount As CdgvMoneyColumn
        Friend WithEvents dgvGrossAmount As CdgvMoneyColumn
        Friend WithEvents dgvDiscountPercent As CdgvMoneyColumn
        Friend WithEvents dgvDiscountAmount As CdgvMoneyColumn
        Friend WithEvents dgvUnitCount As CDgvDecimalColumn
        Friend WithEvents dgvProductIdNo As CDgvDtComboBoxColumn
        Friend WithEvents dgvNeedsExpiryDate As DataGridViewCheckBoxColumn
        Friend WithEvents BaseUnitIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CategoryIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents NeedsExpiryDateDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents ProductNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Friend WithEvents UnitCountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End NameSpace