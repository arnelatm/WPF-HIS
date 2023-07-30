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
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.dgvProductCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvBatchNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountPercent = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvAmtBefVat = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitSalesPrice = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCount = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvNeedsExpiryDate = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.bsInvTransactionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.CtDataGridView2 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGrossAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblExtraDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDiscountAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnPost = New AATM.Libraries.CBaseControlsLibrary.CButton()
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
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.CGroupBox1.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
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
            Me.FlowLayoutPanel1.Controls.Add(Me.CtDataGridView2)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout4)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 57)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1101, 617)
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
            Me.txtReferenceNo.DisplayOnly = True
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
            Me.txtReferenceNo.ReadOnly = True
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
            Me.txtNotes.DisplayOnly = True
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
            Me.txtNotes.ReadOnly = True
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
            Me.DataGridViewInvTransactionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvProductCode, Me.dgvBatchNo, Me.dgvExpiryDate, Me.dgvGrossAmount, Me.dgvDiscountPercent, Me.dgvDiscountAmount, Me.dgvAmtBefVat, Me.dgvUnitSalesPrice, Me.dgvUnitCost, Me.dgvUnitCount, Me.dgvNeedsExpiryDate})
            Me.DataGridViewInvTransactionDetails.DataFilter = Nothing
            Me.DataGridViewInvTransactionDetails.DataSource = Me.bsInvTransactionDetails
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransactionDetails.DefaultCellStyle = DataGridViewCellStyle13
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
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewInvTransactionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
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
            'dgvProductCode
            '
            Me.dgvProductCode.BegFindValue = Nothing
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvProductCode.DefaultCellStyle = DataGridViewCellStyle3
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
            'dgvBatchNo
            '
            Me.dgvBatchNo.BegFindValue = Nothing
            Me.dgvBatchNo.DataPropertyName = "BatchNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvBatchNo.DefaultCellStyle = DataGridViewCellStyle4
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
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvExpiryDate.DefaultCellStyle = DataGridViewCellStyle5
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
            'dgvGrossAmount
            '
            Me.dgvGrossAmount.BegFindValue = Nothing
            Me.dgvGrossAmount.DataPropertyName = "GrossAmount"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.Format = "###,##0.00"
            Me.dgvGrossAmount.DefaultCellStyle = DataGridViewCellStyle6
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
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvDiscountPercent.DefaultCellStyle = DataGridViewCellStyle7
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
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvDiscountAmount.DefaultCellStyle = DataGridViewCellStyle8
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
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvAmtBefVat.DefaultCellStyle = DataGridViewCellStyle9
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
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitSalesPrice.DefaultCellStyle = DataGridViewCellStyle10
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
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle11
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
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCount.DefaultCellStyle = DataGridViewCellStyle12
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
            'CtDataGridView2
            '
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.FloralWhite
            Me.CtDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
            Me.CtDataGridView2.BegFindValue = Nothing
            Me.CtDataGridView2.Cached = False
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
            Me.CtDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView2.DataFilter = Nothing
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView2.DefaultCellStyle = DataGridViewCellStyle17
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
            Me.CtDataGridView2.Location = New System.Drawing.Point(1083, 183)
            Me.CtDataGridView2.Name = "CtDataGridView2"
            Me.CtDataGridView2.ReadOnly = True
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CtDataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
            Me.CtDataGridView2.Searchable = True
            Me.CtDataGridView2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CtDataGridView2.SecurityKey = ""
            Me.CtDataGridView2.SequenceColumn = "dgvSequence"
            Me.CtDataGridView2.SequenceFieldName = "Sequence"
            Me.CtDataGridView2.ShowFooter = False
            Me.CtDataGridView2.Size = New System.Drawing.Size(10, 312)
            Me.CtDataGridView2.TabIndex = 9
            Me.CtDataGridView2.Translatable = True
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.CGroupBox1)
            Me.CFlowLayout4.Location = New System.Drawing.Point(3, 501)
            Me.CFlowLayout4.Name = "CFlowLayout4"
            Me.CFlowLayout4.Size = New System.Drawing.Size(1090, 159)
            Me.CFlowLayout4.TabIndex = 12
            '
            'CGroupBox1
            '
            Me.CGroupBox1.AutoSize = True
            Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.CGroupBox1.Controls.Add(Me.CFlowLayout1)
            Me.CGroupBox1.Controls.Add(Me.btnPost)
            Me.CGroupBox1.DisplayOnly = True
            Me.CGroupBox1.Location = New System.Drawing.Point(3, 3)
            Me.CGroupBox1.Name = "CGroupBox1"
            Me.CGroupBox1.Size = New System.Drawing.Size(1093, 171)
            Me.CGroupBox1.TabIndex = 12
            Me.CGroupBox1.TabStop = False
            Me.CGroupBox1.Text = "Item InvTransaction History"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblGrossAmount)
            Me.CFlowLayout1.Controls.Add(Me.txtGrossAmount)
            Me.CFlowLayout1.Controls.Add(Me.lblExtraDiscount)
            Me.CFlowLayout1.Controls.Add(Me.txtDiscountAmount)
            Me.CFlowLayout1.Controls.Add(Me.lblAmount)
            Me.CFlowLayout1.Controls.Add(Me.txtAmount)
            Me.CFlowLayout1.Location = New System.Drawing.Point(811, 0)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(276, 121)
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
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(1, 51)
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
            Me.txtAmount.Location = New System.Drawing.Point(129, 51)
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
            'btnPost
            '
            Me.btnPost.DesignerSelected = False
            Me.btnPost.ImageIndex = 0
            Me.btnPost.Location = New System.Drawing.Point(893, 127)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.OriginalImageName = Nothing
            Me.btnPost.SecurityKey = ""
            Me.btnPost.Size = New System.Drawing.Size(189, 25)
            Me.btnPost.TabIndex = 13
            Me.btnPost.Text = "Post InvTransaction"
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
            Me.ClientSize = New System.Drawing.Size(1115, 679)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "InvTransactionEntry"
            Me.Text = "InvTransaction Entry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            CType(Me.DataGridViewInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CtDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout()
            Me.CGroupBox1.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
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
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents DataGridViewInvTransactionDetails As CtDataGridView
        Friend WithEvents ProductBindingSource As BindingSource
        Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
        Friend WithEvents lblExtraDiscount As CLabel
        Friend WithEvents txtDiscountAmount As CTextBox
        Friend WithEvents cboWarehouseIdNo As CtComboBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblGrossAmount As CLabel
        Friend WithEvents txtGrossAmount As CTextBox
        Friend WithEvents CtDataGridView2 As CtDataGridView
        Friend WithEvents ProductIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitCostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NetAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatPercentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents CGroupBox1 As CGroupBox
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
        Friend WithEvents btnPost As CButton
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As CDgvTextColumn
        Friend WithEvents dgvProductName As CDgvTextColumn
        Friend WithEvents dgvUnitIdNo As CtDgvComboBoxColumn
        Friend WithEvents dgvBatchNo As CDgvTextColumn
        Friend WithEvents dgvExpiryDate As CDgvTextColumn
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
        Friend WithEvents InvTransactionIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductIdNo As DataGridViewComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitCount As CDgvDecimalColumn
        Friend WithEvents dgvNeedsExpiryDate As DataGridViewCheckBoxColumn
        Friend WithEvents lblWarehouseToIdNo As CLabel
        Friend WithEvents cboWarehouseToIdNo As CtComboBox
        Friend WithEvents cboUserIdNo As CtComboBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents CLabel5 As CLabel
    End Class
End NameSpace