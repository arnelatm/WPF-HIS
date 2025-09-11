Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PurchaseOrderApprovalForm

        Inherits AATM.Presentation.Forms.CFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderApprovalForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewPoUnposted = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.DataGridViewPoItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvUnitName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvQtyOnHand = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvQtySupplied = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvQtyApproved = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CDgvTextColumn1 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.lblRequestedItems = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnSupplyQuantity = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnApproveOrder = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsPurchaseOrders = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvQuantity = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.bsPurchaseOrderDetails = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPoUnposted, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewPoItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPurchaseOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imgList
            '
            Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgList.TransparentColor = System.Drawing.Color.Transparent
            Me.imgList.Images.SetKeyName(0, "btnPrint.png")
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Controls.Add(Me.txtWarehouseIdNo)
            Me.CFlowLayout2.Controls.Add(Me.btnSupplyQuantity)
            Me.CFlowLayout2.Controls.Add(Me.btnApproveOrder)
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 73)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1229, 633)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPoUnposted, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPoItems, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblRequestedItems, 0, 3)
            Me.CFlowLayout2.SetFlowBreak(Me.TableLayoutPanel1, True)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1211, 549)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewPoUnposted
            '
            Me.DataGridViewPoUnposted.AllowUserToAddRows = False
            Me.DataGridViewPoUnposted.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPoUnposted.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPoUnposted.AutoGenerateColumns = False
            Me.DataGridViewPoUnposted.BegFindValue = Nothing
            Me.DataGridViewPoUnposted.Cached = False
            Me.DataGridViewPoUnposted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPoUnposted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvReferenceNo, Me.dgvTransactionDate, Me.dgvWarehouseIdNo, Me.dgvSupplierIdNo, Me.dgvAmount, Me.dgvUserIdNo, Me.dgvNotes})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPoUnposted, 4)
            Me.DataGridViewPoUnposted.DataFilter = Nothing
            Me.DataGridViewPoUnposted.DataSource = Me.bsPurchaseOrders
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPoUnposted.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewPoUnposted.DgvFooter = Nothing
            Me.DataGridViewPoUnposted.DisplayOnly = True
            Me.DataGridViewPoUnposted.Ea = Nothing
            Me.DataGridViewPoUnposted.EditingMode = False
            Me.DataGridViewPoUnposted.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPoUnposted.EndFindValue = Nothing
            Me.DataGridViewPoUnposted.FieldDescription = Nothing
            Me.DataGridViewPoUnposted.FieldName = Nothing
            Me.DataGridViewPoUnposted.FieldsDictionary = Nothing
            Me.DataGridViewPoUnposted.FindColumnNo = CType(0, Short)
            Me.DataGridViewPoUnposted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPoUnposted.FindEnabled = False
            Me.DataGridViewPoUnposted.FirstRowDeletionEnabled = True
            Me.DataGridViewPoUnposted.FirstRowInsertionEnabled = True
            Me.DataGridViewPoUnposted.IgnoreCase = False
            Me.DataGridViewPoUnposted.IsDirty = False
            Me.DataGridViewPoUnposted.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPoUnposted.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPoUnposted.Name = "DataGridViewPoUnposted"
            Me.DataGridViewPoUnposted.OldCellValue = Nothing
            Me.DataGridViewPoUnposted.ReadOnly = True
            Me.DataGridViewPoUnposted.RowHeadersWidth = 25
            Me.DataGridViewPoUnposted.Searchable = True
            Me.DataGridViewPoUnposted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPoUnposted.SecurityKey = ""
            Me.DataGridViewPoUnposted.SequenceColumn = "dgvSequence"
            Me.DataGridViewPoUnposted.SequenceFieldName = "Sequence"
            Me.DataGridViewPoUnposted.ShowFooter = False
            Me.DataGridViewPoUnposted.Size = New System.Drawing.Size(1203, 238)
            Me.DataGridViewPoUnposted.TabIndex = 18
            Me.DataGridViewPoUnposted.Translatable = True
            '
            'dgvWarehouseIdNo
            '
            Me.dgvWarehouseIdNo.AutoComplete = False
            Me.dgvWarehouseIdNo.DataPropertyName = "WarehouseIdNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvWarehouseIdNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvWarehouseIdNo.EditingMode = False
            Me.dgvWarehouseIdNo.HeaderText = "WarehouseIdNo"
            Me.dgvWarehouseIdNo.MinimumWidth = 6
            Me.dgvWarehouseIdNo.Name = "dgvWarehouseIdNo"
            Me.dgvWarehouseIdNo.ReadOnly = True
            Me.dgvWarehouseIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvWarehouseIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvWarehouseIdNo.SuggestCharCount = 0
            Me.dgvWarehouseIdNo.Translatable = False
            Me.dgvWarehouseIdNo.Width = 125
            '
            'dgvSupplierIdNo
            '
            Me.dgvSupplierIdNo.AutoComplete = False
            Me.dgvSupplierIdNo.DataPropertyName = "SupplierIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvSupplierIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvSupplierIdNo.EditingMode = False
            Me.dgvSupplierIdNo.HeaderText = "SupplierIdNo"
            Me.dgvSupplierIdNo.MinimumWidth = 6
            Me.dgvSupplierIdNo.Name = "dgvSupplierIdNo"
            Me.dgvSupplierIdNo.ReadOnly = True
            Me.dgvSupplierIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSupplierIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvSupplierIdNo.SuggestCharCount = 0
            Me.dgvSupplierIdNo.Translatable = False
            Me.dgvSupplierIdNo.Width = 125
            '
            'DataGridViewPoItems
            '
            Me.DataGridViewPoItems.AllowUserToAddRows = False
            Me.DataGridViewPoItems.AllowUserToDeleteRows = False
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPoItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewPoItems.AutoGenerateColumns = False
            Me.DataGridViewPoItems.BegFindValue = Nothing
            Me.DataGridViewPoItems.Cached = False
            Me.DataGridViewPoItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPoItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.dgvQuantity, Me.dgvUnitName, Me.dgvQtyOnHand, Me.dgvQtySupplied, Me.dgvQtyApproved, Me.dgvUnitCost, Me.dgvUnitIdNo, Me.dgvNetAmount, Me.dgvProductIdNo, Me.CDgvTextColumn1})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPoItems, 4)
            Me.DataGridViewPoItems.DataFilter = Nothing
            Me.DataGridViewPoItems.DataSource = Me.bsPurchaseOrderDetails
            DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPoItems.DefaultCellStyle = DataGridViewCellStyle24
            Me.DataGridViewPoItems.DgvFooter = Nothing
            Me.DataGridViewPoItems.DisplayOnly = False
            Me.DataGridViewPoItems.Ea = Nothing
            Me.DataGridViewPoItems.EditingMode = False
            Me.DataGridViewPoItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPoItems.EndFindValue = Nothing
            Me.DataGridViewPoItems.FieldDescription = Nothing
            Me.DataGridViewPoItems.FieldName = Nothing
            Me.DataGridViewPoItems.FieldsDictionary = Nothing
            Me.DataGridViewPoItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewPoItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPoItems.FindEnabled = False
            Me.DataGridViewPoItems.FirstRowDeletionEnabled = True
            Me.DataGridViewPoItems.FirstRowInsertionEnabled = True
            Me.DataGridViewPoItems.IgnoreCase = False
            Me.DataGridViewPoItems.IsDirty = False
            Me.DataGridViewPoItems.Location = New System.Drawing.Point(4, 275)
            Me.DataGridViewPoItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPoItems.Name = "DataGridViewPoItems"
            Me.DataGridViewPoItems.OldCellValue = Nothing
            Me.DataGridViewPoItems.ReadOnly = True
            Me.DataGridViewPoItems.RowHeadersWidth = 25
            Me.DataGridViewPoItems.Searchable = True
            Me.DataGridViewPoItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPoItems.SecurityKey = ""
            Me.DataGridViewPoItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewPoItems.SequenceFieldName = "Sequence"
            Me.DataGridViewPoItems.ShowFooter = False
            Me.DataGridViewPoItems.Size = New System.Drawing.Size(1203, 239)
            Me.DataGridViewPoItems.TabIndex = 19
            Me.DataGridViewPoItems.Translatable = True
            '
            'dgvUnitName
            '
            Me.dgvUnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitName.BegFindValue = Nothing
            Me.dgvUnitName.DataPropertyName = "UnitName"
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitName.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvUnitName.EditingMode = False
            Me.dgvUnitName.EndFindValue = Nothing
            Me.dgvUnitName.FieldDescription = Nothing
            Me.dgvUnitName.FieldName = Nothing
            Me.dgvUnitName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvUnitName.FindEnabled = False
            Me.dgvUnitName.HeaderText = "Unit Name"
            Me.dgvUnitName.IgnoreCase = False
            Me.dgvUnitName.MinimumWidth = 6
            Me.dgvUnitName.Name = "dgvUnitName"
            Me.dgvUnitName.ReadOnly = True
            Me.dgvUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvUnitName.Translatable = False
            Me.dgvUnitName.Width = 99
            '
            'dgvQtyOnHand
            '
            Me.dgvQtyOnHand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvQtyOnHand.DataPropertyName = "QtyOnHand"
            Me.dgvQtyOnHand.DecimalPlaces = -1
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvQtyOnHand.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvQtyOnHand.EditingMode = False
            Me.dgvQtyOnHand.HeaderText = "Qty. On Hand"
            Me.dgvQtyOnHand.MinimumWidth = 6
            Me.dgvQtyOnHand.Name = "dgvQtyOnHand"
            Me.dgvQtyOnHand.ReadOnly = True
            Me.dgvQtyOnHand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQtyOnHand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQtyOnHand.Translatable = False
            Me.dgvQtyOnHand.Width = 115
            '
            'dgvQtySupplied
            '
            Me.dgvQtySupplied.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvQtySupplied.DataPropertyName = "QtySupplied"
            Me.dgvQtySupplied.DecimalPlaces = -1
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.dgvQtySupplied.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvQtySupplied.EditingMode = False
            Me.dgvQtySupplied.HeaderText = "Qty. Supplied"
            Me.dgvQtySupplied.MinimumWidth = 6
            Me.dgvQtySupplied.Name = "dgvQtySupplied"
            Me.dgvQtySupplied.ReadOnly = True
            Me.dgvQtySupplied.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQtySupplied.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQtySupplied.Translatable = False
            Me.dgvQtySupplied.Width = 116
            '
            'dgvQtyApproved
            '
            Me.dgvQtyApproved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvQtyApproved.DataPropertyName = "QtyApproved"
            Me.dgvQtyApproved.DecimalPlaces = -1
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            Me.dgvQtyApproved.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvQtyApproved.EditingMode = False
            Me.dgvQtyApproved.HeaderText = "Qty. Approved"
            Me.dgvQtyApproved.MinimumWidth = 6
            Me.dgvQtyApproved.Name = "dgvQtyApproved"
            Me.dgvQtyApproved.ReadOnly = True
            Me.dgvQtyApproved.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQtyApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvQtyApproved.Translatable = False
            Me.dgvQtyApproved.Width = 122
            '
            'dgvProductIdNo
            '
            Me.dgvProductIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvProductIdNo.DataPropertyName = "ProductIdNo"
            Me.dgvProductIdNo.HeaderText = "ProductIdNo"
            Me.dgvProductIdNo.MinimumWidth = 6
            Me.dgvProductIdNo.Name = "dgvProductIdNo"
            Me.dgvProductIdNo.ReadOnly = True
            Me.dgvProductIdNo.Visible = False
            Me.dgvProductIdNo.Width = 111
            '
            'CDgvTextColumn1
            '
            Me.CDgvTextColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.CDgvTextColumn1.BegFindValue = Nothing
            Me.CDgvTextColumn1.DataPropertyName = "BaseUnitIdNo"
            DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
            Me.CDgvTextColumn1.DefaultCellStyle = DataGridViewCellStyle23
            Me.CDgvTextColumn1.EditingMode = False
            Me.CDgvTextColumn1.EndFindValue = Nothing
            Me.CDgvTextColumn1.FieldDescription = Nothing
            Me.CDgvTextColumn1.FieldName = Nothing
            Me.CDgvTextColumn1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CDgvTextColumn1.FindEnabled = False
            Me.CDgvTextColumn1.HeaderText = "BaseUnitIdNo"
            Me.CDgvTextColumn1.IgnoreCase = False
            Me.CDgvTextColumn1.MinimumWidth = 6
            Me.CDgvTextColumn1.Name = "CDgvTextColumn1"
            Me.CDgvTextColumn1.ReadOnly = True
            Me.CDgvTextColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CDgvTextColumn1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CDgvTextColumn1.Translatable = False
            Me.CDgvTextColumn1.Visible = False
            Me.CDgvTextColumn1.Width = 120
            '
            'lblRequestedItems
            '
            Me.lblRequestedItems.AutoSize = True
            Me.lblRequestedItems.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestedItems.DisplayOnly = True
            Me.lblRequestedItems.EditingMode = False
            Me.lblRequestedItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRequestedItems.Location = New System.Drawing.Point(1, 247)
            Me.lblRequestedItems.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRequestedItems.Name = "lblRequestedItems"
            Me.lblRequestedItems.Size = New System.Drawing.Size(140, 20)
            Me.lblRequestedItems.TabIndex = 20
            Me.lblRequestedItems.Text = "Requested Items:"
            Me.lblRequestedItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRequestedItems.Translatable = True
            '
            'txtWarehouseIdNo
            '
            Me.txtWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.txtWarehouseIdNo.BegFindValue = Nothing
            Me.txtWarehouseIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWarehouseIdNo.ComputedValue = False
            Me.txtWarehouseIdNo.CustomFormat = Nothing
            Me.txtWarehouseIdNo.DataBoundControl = True
            Me.txtWarehouseIdNo.EditingMode = True
            Me.txtWarehouseIdNo.EndFindValue = Nothing
            Me.txtWarehouseIdNo.FieldDescription = Nothing
            Me.txtWarehouseIdNo.FieldName = Nothing
            Me.txtWarehouseIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtWarehouseIdNo.FindEnabled = False
            Me.txtWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtWarehouseIdNo.LinkedLabel = Nothing
            Me.txtWarehouseIdNo.Location = New System.Drawing.Point(1, 558)
            Me.txtWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtWarehouseIdNo.MaximumValue = Nothing
            Me.txtWarehouseIdNo.MinimumValue = Nothing
            Me.txtWarehouseIdNo.Name = "txtWarehouseIdNo"
            Me.txtWarehouseIdNo.OldValue = Nothing
            Me.txtWarehouseIdNo.OverrideMaxLength = 0
            Me.txtWarehouseIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtWarehouseIdNo.Size = New System.Drawing.Size(133, 26)
            Me.txtWarehouseIdNo.TabIndex = 16
            Me.txtWarehouseIdNo.Translatable = False
            Me.txtWarehouseIdNo.Visible = False
            '
            'btnSupplyQuantity
            '
            Me.btnSupplyQuantity.DesignerSelected = False
            Me.btnSupplyQuantity.ImageIndex = 0
            Me.btnSupplyQuantity.Location = New System.Drawing.Point(138, 559)
            Me.btnSupplyQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnSupplyQuantity.Name = "btnSupplyQuantity"
            Me.btnSupplyQuantity.OriginalImageName = Nothing
            Me.btnSupplyQuantity.SecurityKey = ""
            Me.btnSupplyQuantity.Size = New System.Drawing.Size(288, 33)
            Me.btnSupplyQuantity.TabIndex = 19
            Me.btnSupplyQuantity.Text = "Supply Requested Quantity"
            '
            'btnApproveOrder
            '
            Me.btnApproveOrder.DesignerSelected = True
            Me.btnApproveOrder.ImageIndex = 0
            Me.btnApproveOrder.Location = New System.Drawing.Point(432, 559)
            Me.btnApproveOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnApproveOrder.Name = "btnApproveOrder"
            Me.btnApproveOrder.OriginalImageName = Nothing
            Me.btnApproveOrder.SecurityKey = ""
            Me.btnApproveOrder.Size = New System.Drawing.Size(251, 33)
            Me.btnApproveOrder.TabIndex = 18
            Me.btnApproveOrder.Text = "Approve Selected Order"
            '
            'txtDoctorCode
            '
            Me.txtDoctorCode.BackColor = System.Drawing.Color.White
            Me.txtDoctorCode.BegFindValue = Nothing
            Me.txtDoctorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorCode.ComputedValue = False
            Me.txtDoctorCode.CustomFormat = Nothing
            Me.txtDoctorCode.DataBoundControl = True
            Me.txtDoctorCode.EditingMode = True
            Me.txtDoctorCode.EndFindValue = Nothing
            Me.txtDoctorCode.FieldDescription = Nothing
            Me.txtDoctorCode.FieldName = Nothing
            Me.txtDoctorCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorCode.FindEnabled = False
            Me.txtDoctorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorCode.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorCode.LinkedLabel = Nothing
            Me.txtDoctorCode.Location = New System.Drawing.Point(924, 110)
            Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.OverrideMaxLength = 0
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(106, 26)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'dgvIdNo
            '
            Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvIdNo.BegFindValue = Nothing
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.EndFindValue = Nothing
            Me.dgvIdNo.FieldDescription = Nothing
            Me.dgvIdNo.FieldName = Nothing
            Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIdNo.FindEnabled = False
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.IgnoreCase = False
            Me.dgvIdNo.MinimumWidth = 6
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIdNo.Translatable = False
            Me.dgvIdNo.Width = 65
            '
            'dgvReferenceNo
            '
            Me.dgvReferenceNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvReferenceNo.BegFindValue = Nothing
            Me.dgvReferenceNo.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvReferenceNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvReferenceNo.EditingMode = False
            Me.dgvReferenceNo.EndFindValue = Nothing
            Me.dgvReferenceNo.FieldDescription = Nothing
            Me.dgvReferenceNo.FieldName = Nothing
            Me.dgvReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvReferenceNo.FindEnabled = False
            Me.dgvReferenceNo.HeaderText = "Reference No."
            Me.dgvReferenceNo.IgnoreCase = False
            Me.dgvReferenceNo.MinimumWidth = 6
            Me.dgvReferenceNo.Name = "dgvReferenceNo"
            Me.dgvReferenceNo.ReadOnly = True
            Me.dgvReferenceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvReferenceNo.Translatable = False
            Me.dgvReferenceNo.Width = 113
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvTransactionDate.EditingMode = False
            Me.dgvTransactionDate.EndFindValue = Nothing
            Me.dgvTransactionDate.FieldDescription = Nothing
            Me.dgvTransactionDate.FieldName = Nothing
            Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvTransactionDate.FindEnabled = False
            Me.dgvTransactionDate.HeaderText = "Transaction Date"
            Me.dgvTransactionDate.IgnoreCase = False
            Me.dgvTransactionDate.MinimumWidth = 6
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvTransactionDate.Translatable = False
            Me.dgvTransactionDate.Width = 128
            '
            'dgvAmount
            '
            Me.dgvAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvAmount.BegFindValue = Nothing
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvAmount.EditingMode = False
            Me.dgvAmount.EndFindValue = Nothing
            Me.dgvAmount.FieldDescription = Nothing
            Me.dgvAmount.FieldName = Nothing
            Me.dgvAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvAmount.FindEnabled = False
            Me.dgvAmount.HeaderText = "Amount"
            Me.dgvAmount.MinimumWidth = 6
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvAmount.Translatable = False
            Me.dgvAmount.Width = 81
            '
            'dgvUserIdNo
            '
            Me.dgvUserIdNo.AutoComplete = False
            Me.dgvUserIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvUserIdNo.DataPropertyName = "UserIdNo"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvUserIdNo.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvUserIdNo.EditingMode = False
            Me.dgvUserIdNo.HeaderText = "User    "
            Me.dgvUserIdNo.MinimumWidth = 6
            Me.dgvUserIdNo.Name = "dgvUserIdNo"
            Me.dgvUserIdNo.ReadOnly = True
            Me.dgvUserIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUserIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUserIdNo.SuggestCharCount = 0
            Me.dgvUserIdNo.Translatable = False
            Me.dgvUserIdNo.Width = 125
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.BegFindValue = Nothing
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.EndFindValue = Nothing
            Me.dgvNotes.FieldDescription = Nothing
            Me.dgvNotes.FieldName = Nothing
            Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNotes.FindEnabled = False
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.IgnoreCase = False
            Me.dgvNotes.MinimumWidth = 6
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNotes.Translatable = False
            '
            'bsPurchaseOrders
            '
            Me.bsPurchaseOrders.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PurchaseModel)
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle12
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
            Me.dgvSequence.Width = 30
            '
            'dgvProductCode
            '
            Me.dgvProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvProductCode.BegFindValue = Nothing
            Me.dgvProductCode.DataPropertyName = "ProductCode"
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            Me.dgvProductCode.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvProductCode.EditingMode = False
            Me.dgvProductCode.EndFindValue = Nothing
            Me.dgvProductCode.FieldDescription = Nothing
            Me.dgvProductCode.FieldName = Nothing
            Me.dgvProductCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvProductCode.FindEnabled = False
            Me.dgvProductCode.HeaderText = "Product Code"
            Me.dgvProductCode.IgnoreCase = False
            Me.dgvProductCode.MinimumWidth = 6
            Me.dgvProductCode.Name = "dgvProductCode"
            Me.dgvProductCode.ReadOnly = True
            Me.dgvProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProductCode.Translatable = False
            Me.dgvProductCode.Width = 118
            '
            'dgvProductName
            '
            Me.dgvProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProductName.BegFindValue = Nothing
            Me.dgvProductName.DataPropertyName = "ProductName"
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.dgvProductName.DefaultCellStyle = DataGridViewCellStyle14
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
            'dgvQuantity
            '
            Me.dgvQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvQuantity.BegFindValue = Nothing
            Me.dgvQuantity.DataPropertyName = "Quantity"
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.dgvQuantity.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvQuantity.EditingMode = False
            Me.dgvQuantity.EndFindValue = Nothing
            Me.dgvQuantity.FieldDescription = Nothing
            Me.dgvQuantity.FieldName = Nothing
            Me.dgvQuantity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvQuantity.FindEnabled = False
            Me.dgvQuantity.HeaderText = "Quantity"
            Me.dgvQuantity.IgnoreCase = False
            Me.dgvQuantity.MinimumWidth = 6
            Me.dgvQuantity.Name = "dgvQuantity"
            Me.dgvQuantity.ReadOnly = True
            Me.dgvQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuantity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvQuantity.Translatable = False
            Me.dgvQuantity.Width = 84
            '
            'dgvUnitCost
            '
            Me.dgvUnitCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitCost.BegFindValue = Nothing
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.Format = "###,##0.00"
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle20
            Me.dgvUnitCost.EditingMode = False
            Me.dgvUnitCost.EndFindValue = Nothing
            Me.dgvUnitCost.FieldDescription = Nothing
            Me.dgvUnitCost.FieldName = Nothing
            Me.dgvUnitCost.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvUnitCost.FindEnabled = False
            Me.dgvUnitCost.HeaderText = "Unit Cost"
            Me.dgvUnitCost.MinimumWidth = 6
            Me.dgvUnitCost.Name = "dgvUnitCost"
            Me.dgvUnitCost.ReadOnly = True
            Me.dgvUnitCost.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitCost.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUnitCost.Translatable = False
            Me.dgvUnitCost.Width = 89
            '
            'dgvUnitIdNo
            '
            Me.dgvUnitIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitIdNo.BegFindValue = Nothing
            Me.dgvUnitIdNo.DataPropertyName = "UnitIdNo"
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle21
            Me.dgvUnitIdNo.EditingMode = False
            Me.dgvUnitIdNo.EndFindValue = Nothing
            Me.dgvUnitIdNo.FieldDescription = Nothing
            Me.dgvUnitIdNo.FieldName = Nothing
            Me.dgvUnitIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvUnitIdNo.FindEnabled = False
            Me.dgvUnitIdNo.HeaderText = "Unit "
            Me.dgvUnitIdNo.IgnoreCase = False
            Me.dgvUnitIdNo.MinimumWidth = 6
            Me.dgvUnitIdNo.Name = "dgvUnitIdNo"
            Me.dgvUnitIdNo.ReadOnly = True
            Me.dgvUnitIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUnitIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvUnitIdNo.Translatable = False
            Me.dgvUnitIdNo.Visible = False
            Me.dgvUnitIdNo.Width = 62
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle22.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle22
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
            Me.dgvNetAmount.Width = 105
            '
            'bsPurchaseOrderDetails
            '
            Me.bsPurchaseOrderDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PurchaseOrderApprovalDetailModel)
            '
            'PurchaseOrderApprovalForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(1231, 718)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "PurchaseOrderApprovalForm"
            Me.Text = "Purchase Order Approval Viewer"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewPoUnposted, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewPoItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPurchaseOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPurchaseOrders As BindingSource
        Friend WithEvents TransKeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RegistrationNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PatientNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SeriesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SexDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DoctorIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransDateEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtWarehouseIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents InvTransTypeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NotesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PostedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents ReferenceNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransactionDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UserIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents WarehouseIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents WarehouseToIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewPoUnposted As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents DataGridViewPoItems As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents lblRequestedItems As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents bsPurchaseOrderDetails As BindingSource
        Friend WithEvents btnApproveOrder As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnSupplyQuantity As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents dgvSequence As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvProductCode As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvProductName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvQuantity As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvUnitName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvQtyOnHand As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents dgvQtySupplied As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents dgvQtyApproved As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents dgvUnitCost As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvUnitIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvNetAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvProductIdNo As DataGridViewTextBoxColumn
        Friend WithEvents CDgvTextColumn1 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvReferenceNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTransactionDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvWarehouseIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvSupplierIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvUserIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvNotes As Libraries.CBaseControlsLibrary.CDgvTextColumn
    End Class
End Namespace