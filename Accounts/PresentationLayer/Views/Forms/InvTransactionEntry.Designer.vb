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
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.floInventoryHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblInvTransTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboInvTransTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.DataGridViewInvTransactionDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsInvTransactionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.btnPost = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvBatchNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CDgvExpiryColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCategoryIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvInvTransactionIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvNeedsExpiryDate = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvBaseUnitIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvProductNameAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUnitCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvInventoryIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.floInventoryHeader.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewInvTransactionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTransactionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.FlowLayoutPanel1.SetFlowBreak(Me.CFlowLayout2, True)
            Me.CFlowLayout2.Location = New System.Drawing.Point(672, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(135, 128)
            Me.CFlowLayout2.TabIndex = 0
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
            Me.chkCancelled.Location = New System.Drawing.Point(4, 4)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
            Me.chkPosted.Location = New System.Drawing.Point(4, 35)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.Size = New System.Drawing.Size(111, 21)
            Me.chkPosted.TabIndex = 0
            Me.chkPosted.Text = "Posted?"
            Me.chkPosted.Translatable = True
            '
            'lblDateAdded
            '
            Me.lblDateAdded.BackColor = System.Drawing.Color.Transparent
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            Me.lblDateAdded.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAdded.Location = New System.Drawing.Point(0, 60)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(87, 26)
            Me.lblDateAdded.TabIndex = 1
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
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.Location = New System.Drawing.Point(1, 87)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(123, 23)
            Me.txtDateCreated.TabIndex = 0
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.AutoSize = True
            Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.FlowLayoutPanel1.Controls.Add(Me.floInventoryHeader)
            Me.FlowLayoutPanel1.Controls.Add(Me.CFlowLayout2)
            Me.FlowLayoutPanel1.Controls.Add(Me.DataGridViewInvTransactionDetails)
            Me.FlowLayoutPanel1.Controls.Add(Me.btnPost)
            Me.FlowLayoutPanel1.Controls.Add(Me.CLabel4)
            Me.FlowLayoutPanel1.Controls.Add(Me.txtAmount)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 55)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(815, 523)
            Me.FlowLayoutPanel1.TabIndex = 2
            '
            'floInventoryHeader
            '
            Me.floInventoryHeader.AutoSize = True
            Me.floInventoryHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floInventoryHeader.BackColor = System.Drawing.Color.Transparent
            Me.floInventoryHeader.Controls.Add(Me.TableLayoutPanel1)
            Me.floInventoryHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.floInventoryHeader.Location = New System.Drawing.Point(1, 1)
            Me.floInventoryHeader.Margin = New System.Windows.Forms.Padding(1)
            Me.floInventoryHeader.Name = "floInventoryHeader"
            Me.floInventoryHeader.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.floInventoryHeader.Size = New System.Drawing.Size(667, 133)
            Me.floInventoryHeader.TabIndex = 10
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboWarehouseToIdNo, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblWarehouseIdNo, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblInvTransTypeIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtReferenceNo, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboInvTransTypeIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboWarehouseIdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblWarehouseToIdNo, 3, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtJournalIdNo, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 4, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTransactionDate, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboUserIdNo, 5, 4)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(659, 125)
            Me.TableLayoutPanel1.TabIndex = 272
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(210, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(117, 23)
            Me.CLabel2.TabIndex = 261
            Me.CLabel2.Text = "Reference No."
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel2.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(1, 103)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(122, 23)
            Me.CLabel1.TabIndex = 260
            Me.CLabel1.Text = "Journal Id No."
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 5)
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
            Me.txtNotes.Location = New System.Drawing.Point(125, 78)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(498, 23)
            Me.txtNotes.TabIndex = 6
            Me.txtNotes.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(122, 23)
            Me.lblIdNo.TabIndex = 160
            Me.lblIdNo.Text = "Transaction No.:"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'CLabel5
            '
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(1, 78)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(122, 15)
            Me.CLabel5.TabIndex = 271
            Me.CLabel5.Text = "Notes :"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'cboWarehouseToIdNo
            '
            Me.cboWarehouseToIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseToIdNo.BegFindValue = Nothing
            Me.cboWarehouseToIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboWarehouseToIdNo, 2)
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
            Me.cboWarehouseToIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseToIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseToIdNo.FormattingEnabled = True
            Me.cboWarehouseToIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseToIdNo.IgnoreCase = False
            Me.cboWarehouseToIdNo.IntegralHeight = False
            Me.cboWarehouseToIdNo.LimitToList = True
            Me.cboWarehouseToIdNo.LinkedLabel = Me.lblInvTransTypeIdNo
            Me.cboWarehouseToIdNo.Location = New System.Drawing.Point(443, 52)
            Me.cboWarehouseToIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseToIdNo.Name = "cboWarehouseToIdNo"
            Me.cboWarehouseToIdNo.OldValue = 0
            Me.cboWarehouseToIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseToIdNo.OriginalList = Nothing
            Me.cboWarehouseToIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseToIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseToIdNo.PropertySelector = Nothing
            Me.cboWarehouseToIdNo.Size = New System.Drawing.Size(183, 24)
            Me.cboWarehouseToIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseToIdNo.SuggestCharCount = 1
            Me.cboWarehouseToIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseToIdNo.TabIndex = 5
            Me.cboWarehouseToIdNo.TextToSearch = Nothing
            Me.cboWarehouseToIdNo.Translatable = False
            Me.cboWarehouseToIdNo.ValueIsMandatory = False
            Me.cboWarehouseToIdNo.ValueIsNullable = False
            Me.cboWarehouseToIdNo.ValueIsNumeric = False
            Me.cboWarehouseToIdNo.ValueMember = "IdNo"
            '
            'lblInvTransTypeIdNo
            '
            Me.lblInvTransTypeIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblInvTransTypeIdNo.DisplayOnly = True
            Me.lblInvTransTypeIdNo.EditingMode = False
            Me.lblInvTransTypeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvTransTypeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvTransTypeIdNo.Location = New System.Drawing.Point(1, 26)
            Me.lblInvTransTypeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvTransTypeIdNo.Name = "lblInvTransTypeIdNo"
            Me.lblInvTransTypeIdNo.Size = New System.Drawing.Size(122, 23)
            Me.lblInvTransTypeIdNo.TabIndex = 254
            Me.lblInvTransTypeIdNo.Text = "Inv. Trans. Type :"
            Me.lblInvTransTypeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblInvTransTypeIdNo.Translatable = True
            '
            'lblWarehouseIdNo
            '
            Me.lblWarehouseIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblWarehouseIdNo.DisplayOnly = True
            Me.lblWarehouseIdNo.EditingMode = False
            Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(1, 52)
            Me.lblWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseIdNo.Name = "lblWarehouseIdNo"
            Me.lblWarehouseIdNo.Size = New System.Drawing.Size(122, 23)
            Me.lblWarehouseIdNo.TabIndex = 158
            Me.lblWarehouseIdNo.Text = "Warehouse Name :"
            Me.lblWarehouseIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWarehouseIdNo.Translatable = True
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
            Me.TxtIdNo.Location = New System.Drawing.Point(125, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(83, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
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
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblIdNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(329, 1)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(94, 23)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsNumeric = True
            '
            'cboInvTransTypeIdNo
            '
            Me.cboInvTransTypeIdNo.BackColor = System.Drawing.Color.White
            Me.cboInvTransTypeIdNo.BegFindValue = Nothing
            Me.cboInvTransTypeIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboInvTransTypeIdNo, 5)
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
            Me.cboInvTransTypeIdNo.Location = New System.Drawing.Point(125, 26)
            Me.cboInvTransTypeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboInvTransTypeIdNo.Name = "cboInvTransTypeIdNo"
            Me.cboInvTransTypeIdNo.OldValue = 0
            Me.cboInvTransTypeIdNo.OriginalDataSource = Nothing
            Me.cboInvTransTypeIdNo.OriginalList = Nothing
            Me.cboInvTransTypeIdNo.OverrideDropDownStyleList = False
            Me.cboInvTransTypeIdNo.PreviousSearchTerm = Nothing
            Me.cboInvTransTypeIdNo.PropertySelector = Nothing
            Me.cboInvTransTypeIdNo.Size = New System.Drawing.Size(499, 24)
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
            'cboWarehouseIdNo
            '
            Me.cboWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseIdNo.BegFindValue = Nothing
            Me.cboWarehouseIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboWarehouseIdNo, 2)
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
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(125, 52)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(202, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestCharCount = 1
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 4
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'lblWarehouseToIdNo
            '
            Me.lblWarehouseToIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblWarehouseToIdNo.DisplayOnly = True
            Me.lblWarehouseToIdNo.EditingMode = False
            Me.lblWarehouseToIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseToIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarehouseToIdNo.Location = New System.Drawing.Point(329, 52)
            Me.lblWarehouseToIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseToIdNo.Name = "lblWarehouseToIdNo"
            Me.lblWarehouseToIdNo.Size = New System.Drawing.Size(112, 23)
            Me.lblWarehouseToIdNo.TabIndex = 267
            Me.lblWarehouseToIdNo.Text = "Warehouse To :"
            Me.lblWarehouseToIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblWarehouseToIdNo.Translatable = True
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
            Me.txtJournalIdNo.Location = New System.Drawing.Point(125, 103)
            Me.txtJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalIdNo.MaximumValue = Nothing
            Me.txtJournalIdNo.MaxLength = 15
            Me.txtJournalIdNo.MinimumValue = Nothing
            Me.txtJournalIdNo.Name = "txtJournalIdNo"
            Me.txtJournalIdNo.OldValue = Nothing
            Me.txtJournalIdNo.OverrideMaxLength = 0
            Me.txtJournalIdNo.ReadOnly = True
            Me.txtJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalIdNo.Size = New System.Drawing.Size(83, 23)
            Me.txtJournalIdNo.TabIndex = 7
            Me.txtJournalIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtJournalIdNo.Translatable = False
            Me.txtJournalIdNo.ValueIsMandatory = True
            Me.txtJournalIdNo.ValueIsNumeric = True
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(544, 0)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = ""
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
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel3.Location = New System.Drawing.Point(443, 103)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(71, 23)
            Me.CLabel3.TabIndex = 264
            Me.CLabel3.Text = "User Name"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel3.Translatable = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(443, 1)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(100, 23)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Transaction Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTransactionDate.Translatable = True
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
            Me.cboUserIdNo.EditingMode = False
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
            Me.cboUserIdNo.LimitToList = False
            Me.cboUserIdNo.LinkedLabel = Nothing
            Me.cboUserIdNo.Location = New System.Drawing.Point(545, 103)
            Me.cboUserIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUserIdNo.MaxDropDownItems = 1
            Me.cboUserIdNo.Name = "cboUserIdNo"
            Me.cboUserIdNo.OldValue = 0
            Me.cboUserIdNo.OriginalDataSource = Nothing
            Me.cboUserIdNo.OriginalList = Nothing
            Me.cboUserIdNo.OverrideDropDownStyleList = False
            Me.cboUserIdNo.PreviousSearchTerm = Nothing
            Me.cboUserIdNo.PropertySelector = Nothing
            Me.cboUserIdNo.Size = New System.Drawing.Size(82, 27)
            Me.cboUserIdNo.SuggestBoxHeight = 246
            Me.cboUserIdNo.SuggestCharCount = 0
            Me.cboUserIdNo.SuggestListOrderRule = Nothing
            Me.cboUserIdNo.TabIndex = 8
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
            Me.DataGridViewInvTransactionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvTransactionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvBatchNo, Me.dgvExpiryDate, Me.dgvQuantity, Me.dgvUnitIdNo, Me.dgvUnitCost, Me.dgvNetAmount, Me.dgvCategoryIdNo, Me.IdNoDataGridViewTextBoxColumn, Me.dgvInvTransactionIdNo, Me.dgvNeedsExpiryDate, Me.dgvBaseUnitIdNo, Me.dgvProductIdNo, Me.dgvProductNameAra, Me.dgvUnitCount, Me.dgvInventoryIdNo})
            Me.DataGridViewInvTransactionDetails.DataFilter = Nothing
            Me.DataGridViewInvTransactionDetails.DataSource = Me.bsInvTransactionDetails
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransactionDetails.DefaultCellStyle = DataGridViewCellStyle11
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
            Me.FlowLayoutPanel1.SetFlowBreak(Me.DataGridViewInvTransactionDetails, True)
            Me.DataGridViewInvTransactionDetails.IgnoreCase = False
            Me.DataGridViewInvTransactionDetails.IsDirty = False
            Me.DataGridViewInvTransactionDetails.Location = New System.Drawing.Point(3, 138)
            Me.DataGridViewInvTransactionDetails.Name = "DataGridViewInvTransactionDetails"
            Me.DataGridViewInvTransactionDetails.OldCellValue = Nothing
            Me.DataGridViewInvTransactionDetails.ReadOnly = True
            Me.DataGridViewInvTransactionDetails.RowHeadersWidth = 51
            Me.DataGridViewInvTransactionDetails.Searchable = True
            Me.DataGridViewInvTransactionDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvTransactionDetails.SecurityKey = ""
            Me.DataGridViewInvTransactionDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvTransactionDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewInvTransactionDetails.ShowFooter = False
            Me.DataGridViewInvTransactionDetails.Size = New System.Drawing.Size(802, 332)
            Me.DataGridViewInvTransactionDetails.TabIndex = 0
            Me.DataGridViewInvTransactionDetails.Translatable = True
            '
            'bsInvTransactionDetails
            '
            Me.bsInvTransactionDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionDetailModel)
            '
            'btnPost
            '
            Me.btnPost.DesignerSelected = False
            Me.btnPost.ImageIndex = 0
            Me.btnPost.Location = New System.Drawing.Point(3, 476)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.OriginalImageName = Nothing
            Me.btnPost.SecurityKey = ""
            Me.btnPost.Size = New System.Drawing.Size(229, 25)
            Me.btnPost.TabIndex = 275
            Me.btnPost.Text = "Post Inventory Transaction"
            '
            'CLabel4
            '
            Me.CLabel4.BackColor = System.Drawing.Color.Transparent
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(236, 474)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(469, 23)
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
            Me.txtAmount.Location = New System.Drawing.Point(707, 474)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(100, 23)
            Me.txtAmount.TabIndex = 1
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            '
            'ProductTableAdapter
            '
            Me.ProductTableAdapter.ClearBeforeFill = True
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
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.MinimumWidth = 6
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
            Me.dgvProductCode.MinimumWidth = 6
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProductCode.Translatable = False
            Me.dgvProductCode.Width = 60
            '
            'dgvProductName
            '
            Me.dgvProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductName.BegFindValue = Nothing
            Me.dgvProductName.DataPropertyName = "ProductName"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvProductName.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvProductName.EditingMode = False
            Me.dgvProductName.EndFindValue = Nothing
            Me.dgvProductName.FieldDescription = Nothing
            Me.dgvProductName.FieldName = Nothing
            Me.dgvProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvProductName.FindEnabled = False
            Me.dgvProductName.HeaderText = "Product Name"
            Me.dgvProductName.IgnoreCase = False
            Me.dgvProductName.MinimumWidth = 6
            Me.dgvProductName.Name = "dgvProductName"
            Me.dgvProductName.ReadOnly = True
            Me.dgvProductName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProductName.Translatable = False
            '
            'dgvBatchNo
            '
            Me.dgvBatchNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.dgvBatchNo.HeaderText = "Batch No"
            Me.dgvBatchNo.IgnoreCase = False
            Me.dgvBatchNo.MinimumWidth = 6
            Me.dgvBatchNo.Name = "dgvBatchNo"
            Me.dgvBatchNo.ReadOnly = True
            Me.dgvBatchNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBatchNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvBatchNo.Translatable = False
            Me.dgvBatchNo.Width = 77
            '
            'dgvExpiryDate
            '
            Me.dgvExpiryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.dgvExpiryDate.MinimumWidth = 6
            Me.dgvExpiryDate.Name = "dgvExpiryDate"
            Me.dgvExpiryDate.ReadOnly = True
            Me.dgvExpiryDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvExpiryDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvExpiryDate.Translatable = False
            Me.dgvExpiryDate.Width = 86
            '
            'dgvQuantity
            '
            Me.dgvQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvQuantity.DataPropertyName = "Quantity"
            Me.dgvQuantity.DecimalPlaces = -1
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.HeaderText = "Quantity"
            Me.dgvQuantity.MinimumWidth = 6
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQuantity.Translatable = False
            Me.dgvQuantity.Width = 71
            '
            'dgvUnitIdNo
            '
            Me.dgvUnitIdNo.AutoComplete = False
            Me.dgvUnitIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitIdNo.DataPropertyName = "UnitIdNo"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvUnitIdNo.EditingMode = False
            Me.dgvUnitIdNo.HeaderText = "Unit "
            Me.dgvUnitIdNo.MinimumWidth = 6
            Me.dgvUnitIdNo.Name = "dgvUnitIdNo"
            Me.dgvUnitIdNo.ReadOnly = True
            Me.dgvUnitIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitIdNo.SuggestCharCount = 0
            Me.dgvUnitIdNo.Translatable = False
            Me.dgvUnitIdNo.Width = 51
            '
            'dgvUnitCost
            '
            Me.dgvUnitCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            Me.dgvUnitCost.DecimalPlaces = -1
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.MinimumWidth = 6
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 75
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvNetAmount.EditingMode = False
            Me.dgvNetAmount.EndFindValue = Nothing
            Me.dgvNetAmount.FieldDescription = Nothing
            Me.dgvNetAmount.FieldName = Nothing
            Me.dgvNetAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNetAmount.FindEnabled = False
            Me.dgvNetAmount.HeaderText = "Net Amount"
            Me.dgvNetAmount.MinimumWidth = 6
            Me.dgvNetAmount.Name = "dgvNetAmount"
            Me.dgvNetAmount.ReadOnly = True
            Me.dgvNetAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNetAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNetAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvNetAmount.Translatable = False
            Me.dgvNetAmount.Width = 88
            '
            'dgvCategoryIdNo
            '
            Me.dgvCategoryIdNo.DataPropertyName = "CategoryIdNo"
            Me.dgvCategoryIdNo.HeaderText = "CategoryIdNo"
            Me.dgvCategoryIdNo.MinimumWidth = 6
            Me.dgvCategoryIdNo.Name = "dgvCategoryIdNo"
            Me.dgvCategoryIdNo.ReadOnly = True
            Me.dgvCategoryIdNo.Visible = False
            Me.dgvCategoryIdNo.Width = 125
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
            '
            'dgvInvTransactionIdNo
            '
            Me.dgvInvTransactionIdNo.DataPropertyName = "InvTransactionIdNo"
            Me.dgvInvTransactionIdNo.HeaderText = "InvTransactionIdNo"
            Me.dgvInvTransactionIdNo.MinimumWidth = 6
            Me.dgvInvTransactionIdNo.Name = "dgvInvTransactionIdNo"
            Me.dgvInvTransactionIdNo.ReadOnly = True
            Me.dgvInvTransactionIdNo.Visible = False
            Me.dgvInvTransactionIdNo.Width = 125
            '
            'dgvNeedsExpiryDate
            '
            Me.dgvNeedsExpiryDate.DataPropertyName = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.HeaderText = "NeedsExpiryDate"
            Me.dgvNeedsExpiryDate.MinimumWidth = 6
            Me.dgvNeedsExpiryDate.Name = "dgvNeedsExpiryDate"
            Me.dgvNeedsExpiryDate.ReadOnly = True
            Me.dgvNeedsExpiryDate.Visible = False
            Me.dgvNeedsExpiryDate.Width = 125
            '
            'dgvBaseUnitIdNo
            '
            Me.dgvBaseUnitIdNo.DataPropertyName = "BaseUnitIdNo"
            Me.dgvBaseUnitIdNo.HeaderText = "BaseUnitIdNo"
            Me.dgvBaseUnitIdNo.MinimumWidth = 6
            Me.dgvBaseUnitIdNo.Name = "dgvBaseUnitIdNo"
            Me.dgvBaseUnitIdNo.ReadOnly = True
            Me.dgvBaseUnitIdNo.Visible = False
            Me.dgvBaseUnitIdNo.Width = 125
            '
            'dgvProductIdNo
            '
            Me.dgvProductIdNo.DataPropertyName = "ProductIdNo"
            Me.dgvProductIdNo.HeaderText = "ProductIdNo"
            Me.dgvProductIdNo.MinimumWidth = 6
            Me.dgvProductIdNo.Name = "dgvProductIdNo"
            Me.dgvProductIdNo.ReadOnly = True
            Me.dgvProductIdNo.Visible = False
            Me.dgvProductIdNo.Width = 125
            '
            'dgvProductNameAra
            '
            Me.dgvProductNameAra.DataPropertyName = "ProductNameAra"
            Me.dgvProductNameAra.HeaderText = "ProductNameAra"
            Me.dgvProductNameAra.MinimumWidth = 6
            Me.dgvProductNameAra.Name = "dgvProductNameAra"
            Me.dgvProductNameAra.ReadOnly = True
            Me.dgvProductNameAra.Visible = False
            Me.dgvProductNameAra.Width = 125
            '
            'dgvUnitCount
            '
            Me.dgvUnitCount.DataPropertyName = "UnitCount"
            Me.dgvUnitCount.HeaderText = "UnitCount"
            Me.dgvUnitCount.MinimumWidth = 6
            Me.dgvUnitCount.Name = "dgvUnitCount"
            Me.dgvUnitCount.ReadOnly = True
            Me.dgvUnitCount.Visible = False
            Me.dgvUnitCount.Width = 125
            '
            'dgvInventoryIdNo
            '
            Me.dgvInventoryIdNo.DataPropertyName = "InventoryIdNo"
            Me.dgvInventoryIdNo.HeaderText = "InventoryIdNo"
            Me.dgvInventoryIdNo.MinimumWidth = 6
            Me.dgvInventoryIdNo.Name = "dgvInventoryIdNo"
            Me.dgvInventoryIdNo.ReadOnly = True
            Me.dgvInventoryIdNo.Visible = False
            Me.dgvInventoryIdNo.Width = 125
            '
            'InvTransactionEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(815, 578)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "InvTransactionEntry"
            Me.Text = "InvTransaction Entry"
            Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.floInventoryHeader.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionDetails, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents floInventoryHeader As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblWarehouseIdNo As CLabel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents lblInvTransTypeIdNo As CLabel
        Friend WithEvents cboInvTransTypeIdNo As CtComboBox
        Friend WithEvents ProductBindingSource As BindingSource
        Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
        Friend WithEvents cboWarehouseIdNo As CtComboBox
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
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents UnitSalesPriceDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents PriceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents btnPost As CButton
        Friend WithEvents DataGridViewInvTransactionDetails As CtDataGridView
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents cboUserIdNo As CtComboBox
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvProductCode As CDgvTextColumn
        Friend WithEvents dgvProductName As CDgvTextColumn
        Friend WithEvents dgvBatchNo As CDgvTextColumn
        Friend WithEvents dgvExpiryDate As CDgvExpiryColumn
        Friend WithEvents dgvQuantity As CDgvDecimalColumn
        Friend WithEvents dgvUnitIdNo As CtDgvComboBoxColumn
        Friend WithEvents dgvUnitCost As CDgvDecimalColumn
        Friend WithEvents dgvNetAmount As CdgvMoneyColumn
        Friend WithEvents dgvCategoryIdNo As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvInvTransactionIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvNeedsExpiryDate As DataGridViewCheckBoxColumn
        Friend WithEvents dgvBaseUnitIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvProductNameAra As DataGridViewTextBoxColumn
        Friend WithEvents dgvUnitCount As DataGridViewTextBoxColumn
        Friend WithEvents dgvInventoryIdNo As DataGridViewTextBoxColumn
    End Class
End NameSpace