Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvRequestForm

        Inherits AATM.PresentationLayer.Forms.CFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvRequestForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewInvTransactionRequests = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvDateCreated = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsInvTransactionRequest = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseSelector = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.DataGridViewInvTransItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsInvTranItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblRequestedItems = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProductName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnitName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.QtyOnHand = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.BaseUnitName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.QtySupplied = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvUnitCost = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvNetAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvProductIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CDgvTextColumn1 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewInvTransItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTranItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 73)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1229, 582)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewInvTransactionRequests, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblWarehouseIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboWarehouseSelector, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewInvTransItems, 0, 4)
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
            'DataGridViewInvTransactionRequests
            '
            Me.DataGridViewInvTransactionRequests.AllowUserToAddRows = False
            Me.DataGridViewInvTransactionRequests.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewInvTransactionRequests.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewInvTransactionRequests.AutoGenerateColumns = False
            Me.DataGridViewInvTransactionRequests.BegFindValue = Nothing
            Me.DataGridViewInvTransactionRequests.Cached = False
            Me.DataGridViewInvTransactionRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvTransactionRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvReferenceNo, Me.dgvWarehouseToIdNo, Me.dgvDateCreated, Me.dgvTransactionDate, Me.dgvAmount, Me.dgvUserIdNo, Me.dgvNotes})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewInvTransactionRequests, 4)
            Me.DataGridViewInvTransactionRequests.DataFilter = Nothing
            Me.DataGridViewInvTransactionRequests.DataSource = Me.bsInvTransactionRequest
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransactionRequests.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewInvTransactionRequests.DgvFooter = Nothing
            Me.DataGridViewInvTransactionRequests.DisplayOnly = False
            Me.DataGridViewInvTransactionRequests.Ea = Nothing
            Me.DataGridViewInvTransactionRequests.EditingMode = False
            Me.DataGridViewInvTransactionRequests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewInvTransactionRequests.EndFindValue = Nothing
            Me.DataGridViewInvTransactionRequests.FieldDescription = Nothing
            Me.DataGridViewInvTransactionRequests.FieldName = Nothing
            Me.DataGridViewInvTransactionRequests.FieldsDictionary = Nothing
            Me.DataGridViewInvTransactionRequests.FindColumnNo = CType(0, Short)
            Me.DataGridViewInvTransactionRequests.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewInvTransactionRequests.FindEnabled = False
            Me.DataGridViewInvTransactionRequests.FirstRowDeletionEnabled = True
            Me.DataGridViewInvTransactionRequests.FirstRowInsertionEnabled = True
            Me.DataGridViewInvTransactionRequests.IgnoreCase = False
            Me.DataGridViewInvTransactionRequests.IsDirty = False
            Me.DataGridViewInvTransactionRequests.Location = New System.Drawing.Point(4, 34)
            Me.DataGridViewInvTransactionRequests.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvTransactionRequests.Name = "DataGridViewInvTransactionRequests"
            Me.DataGridViewInvTransactionRequests.OldCellValue = Nothing
            Me.DataGridViewInvTransactionRequests.ReadOnly = True
            Me.DataGridViewInvTransactionRequests.RowHeadersWidth = 51
            Me.DataGridViewInvTransactionRequests.Searchable = True
            Me.DataGridViewInvTransactionRequests.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvTransactionRequests.SecurityKey = ""
            Me.DataGridViewInvTransactionRequests.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvTransactionRequests.SequenceFieldName = "Sequence"
            Me.DataGridViewInvTransactionRequests.ShowFooter = False
            Me.DataGridViewInvTransactionRequests.Size = New System.Drawing.Size(1203, 238)
            Me.DataGridViewInvTransactionRequests.TabIndex = 18
            Me.DataGridViewInvTransactionRequests.Translatable = True
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
            'dgvWarehouseToIdNo
            '
            Me.dgvWarehouseToIdNo.AutoComplete = False
            Me.dgvWarehouseToIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvWarehouseToIdNo.DataPropertyName = "WarehouseToIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvWarehouseToIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvWarehouseToIdNo.EditingMode = False
            Me.dgvWarehouseToIdNo.HeaderText = "Warehouse Requested"
            Me.dgvWarehouseToIdNo.MinimumWidth = 6
            Me.dgvWarehouseToIdNo.Name = "dgvWarehouseToIdNo"
            Me.dgvWarehouseToIdNo.ReadOnly = True
            Me.dgvWarehouseToIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvWarehouseToIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvWarehouseToIdNo.SuggestCharCount = 0
            Me.dgvWarehouseToIdNo.Translatable = False
            Me.dgvWarehouseToIdNo.Width = 161
            '
            'dgvDateCreated
            '
            Me.dgvDateCreated.BegFindValue = Nothing
            Me.dgvDateCreated.DataPropertyName = "DateCreated"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvDateCreated.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvDateCreated.EditingMode = False
            Me.dgvDateCreated.EndFindValue = Nothing
            Me.dgvDateCreated.FieldDescription = Nothing
            Me.dgvDateCreated.FieldName = Nothing
            Me.dgvDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDateCreated.FindEnabled = False
            Me.dgvDateCreated.HeaderText = "Date Created"
            Me.dgvDateCreated.IgnoreCase = False
            Me.dgvDateCreated.MinimumWidth = 6
            Me.dgvDateCreated.Name = "dgvDateCreated"
            Me.dgvDateCreated.ReadOnly = True
            Me.dgvDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDateCreated.Translatable = False
            Me.dgvDateCreated.Width = 125
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle6
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
            'bsInvTransactionRequest
            '
            Me.bsInvTransactionRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
            '
            'lblWarehouseIdNo
            '
            Me.lblWarehouseIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblWarehouseIdNo.DisplayOnly = True
            Me.lblWarehouseIdNo.EditingMode = False
            Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseIdNo.Name = "lblWarehouseIdNo"
            Me.lblWarehouseIdNo.Size = New System.Drawing.Size(228, 28)
            Me.lblWarehouseIdNo.TabIndex = 14
            Me.lblWarehouseIdNo.Text = "Warehouse Code - Name:"
            Me.lblWarehouseIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWarehouseIdNo.Translatable = True
            '
            'cboWarehouseSelector
            '
            Me.cboWarehouseSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboWarehouseSelector.BackColor = System.Drawing.Color.White
            Me.cboWarehouseSelector.BegFindValue = Nothing
            Me.cboWarehouseSelector.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboWarehouseSelector, 3)
            Me.cboWarehouseSelector.CurrentSearchTerm = ""
            Me.cboWarehouseSelector.DataValue = Nothing
            Me.cboWarehouseSelector.DefaultValue = Nothing
            Me.cboWarehouseSelector.DisplayMember = "Name"
            Me.cboWarehouseSelector.Editable = True
            Me.cboWarehouseSelector.EditingMode = True
            Me.cboWarehouseSelector.EndFindValue = Nothing
            Me.cboWarehouseSelector.FieldDescription = Nothing
            Me.cboWarehouseSelector.FieldName = Nothing
            Me.cboWarehouseSelector.FilterRule = Nothing
            Me.cboWarehouseSelector.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboWarehouseSelector.FindEnabled = False
            Me.cboWarehouseSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseSelector.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseSelector.FormattingEnabled = True
            Me.cboWarehouseSelector.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseSelector.IgnoreCase = False
            Me.cboWarehouseSelector.IntegralHeight = False
            Me.cboWarehouseSelector.LimitToList = False
            Me.cboWarehouseSelector.LinkedLabel = Nothing
            Me.cboWarehouseSelector.Location = New System.Drawing.Point(231, 1)
            Me.cboWarehouseSelector.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseSelector.Name = "cboWarehouseSelector"
            Me.cboWarehouseSelector.OldValue = 0
            Me.cboWarehouseSelector.OriginalDataSource = Nothing
            Me.cboWarehouseSelector.OriginalList = Nothing
            Me.cboWarehouseSelector.OverrideDropDownStyleList = False
            Me.cboWarehouseSelector.PreviousSearchTerm = Nothing
            Me.cboWarehouseSelector.PropertySelector = Nothing
            Me.cboWarehouseSelector.Size = New System.Drawing.Size(979, 28)
            Me.cboWarehouseSelector.SuggestBoxHeight = 200
            Me.cboWarehouseSelector.SuggestCharCount = 0
            Me.cboWarehouseSelector.SuggestListOrderRule = Nothing
            Me.cboWarehouseSelector.TabIndex = 15
            Me.cboWarehouseSelector.TextToSearch = Nothing
            Me.cboWarehouseSelector.Translatable = False
            Me.cboWarehouseSelector.ValueIsMandatory = False
            Me.cboWarehouseSelector.ValueIsNullable = False
            Me.cboWarehouseSelector.ValueIsNumeric = False
            Me.cboWarehouseSelector.ValueMember = "IdNo"
            '
            'DataGridViewInvTransItems
            '
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewInvTransItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewInvTransItems.AutoGenerateColumns = False
            Me.DataGridViewInvTransItems.BegFindValue = Nothing
            Me.DataGridViewInvTransItems.Cached = False
            Me.DataGridViewInvTransItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvTransItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvProductCode, Me.dgvProductName, Me.QuantityDataGridViewTextBoxColumn, Me.UnitName, Me.QtyOnHand, Me.BaseUnitName, Me.QtySupplied, Me.dgvUnitCost, Me.dgvUnitIdNo, Me.dgvNetAmount, Me.dgvProductIdNo, Me.CDgvTextColumn1})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewInvTransItems, 4)
            Me.DataGridViewInvTransItems.DataFilter = Nothing
            Me.DataGridViewInvTransItems.DataSource = Me.bsInvTranItems
            DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransItems.DefaultCellStyle = DataGridViewCellStyle23
            Me.DataGridViewInvTransItems.DgvFooter = Nothing
            Me.DataGridViewInvTransItems.DisplayOnly = False
            Me.DataGridViewInvTransItems.Ea = Nothing
            Me.DataGridViewInvTransItems.EditingMode = False
            Me.DataGridViewInvTransItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewInvTransItems.EndFindValue = Nothing
            Me.DataGridViewInvTransItems.FieldDescription = Nothing
            Me.DataGridViewInvTransItems.FieldName = Nothing
            Me.DataGridViewInvTransItems.FieldsDictionary = Nothing
            Me.DataGridViewInvTransItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewInvTransItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewInvTransItems.FindEnabled = False
            Me.DataGridViewInvTransItems.FirstRowDeletionEnabled = True
            Me.DataGridViewInvTransItems.FirstRowInsertionEnabled = True
            Me.DataGridViewInvTransItems.IgnoreCase = False
            Me.DataGridViewInvTransItems.IsDirty = False
            Me.DataGridViewInvTransItems.Location = New System.Drawing.Point(4, 305)
            Me.DataGridViewInvTransItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvTransItems.Name = "DataGridViewInvTransItems"
            Me.DataGridViewInvTransItems.OldCellValue = Nothing
            Me.DataGridViewInvTransItems.ReadOnly = True
            Me.DataGridViewInvTransItems.RowHeadersWidth = 51
            Me.DataGridViewInvTransItems.Searchable = True
            Me.DataGridViewInvTransItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvTransItems.SecurityKey = ""
            Me.DataGridViewInvTransItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvTransItems.SequenceFieldName = "Sequence"
            Me.DataGridViewInvTransItems.ShowFooter = False
            Me.DataGridViewInvTransItems.Size = New System.Drawing.Size(1203, 239)
            Me.DataGridViewInvTransItems.TabIndex = 19
            Me.DataGridViewInvTransItems.Translatable = True
            '
            'bsInvTranItems
            '
            Me.bsInvTranItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvRequestDetailModel)
            '
            'lblRequestedItems
            '
            Me.lblRequestedItems.AutoSize = True
            Me.lblRequestedItems.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestedItems.DisplayOnly = True
            Me.lblRequestedItems.EditingMode = False
            Me.lblRequestedItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRequestedItems.Location = New System.Drawing.Point(1, 277)
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
            'dgvSequence
            '
            Me.dgvSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.dgvSequence.Width = 61
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
            'QuantityDataGridViewTextBoxColumn
            '
            Me.QuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
            Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
            Me.QuantityDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
            Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
            Me.QuantityDataGridViewTextBoxColumn.Width = 84
            '
            'UnitName
            '
            Me.UnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.UnitName.BegFindValue = Nothing
            Me.UnitName.DataPropertyName = "UnitName"
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.UnitName.DefaultCellStyle = DataGridViewCellStyle15
            Me.UnitName.EditingMode = False
            Me.UnitName.EndFindValue = Nothing
            Me.UnitName.FieldDescription = Nothing
            Me.UnitName.FieldName = Nothing
            Me.UnitName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.UnitName.FindEnabled = False
            Me.UnitName.HeaderText = "Unit Name"
            Me.UnitName.IgnoreCase = False
            Me.UnitName.MinimumWidth = 6
            Me.UnitName.Name = "UnitName"
            Me.UnitName.ReadOnly = True
            Me.UnitName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.UnitName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.UnitName.Translatable = False
            Me.UnitName.Width = 99
            '
            'QtyOnHand
            '
            Me.QtyOnHand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.QtyOnHand.DataPropertyName = "QtyOnHand"
            Me.QtyOnHand.DecimalPlaces = -1
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.QtyOnHand.DefaultCellStyle = DataGridViewCellStyle16
            Me.QtyOnHand.EditingMode = False
            Me.QtyOnHand.HeaderText = "Qty. On Hand"
            Me.QtyOnHand.MinimumWidth = 6
            Me.QtyOnHand.Name = "QtyOnHand"
            Me.QtyOnHand.ReadOnly = True
            Me.QtyOnHand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.QtyOnHand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.QtyOnHand.Translatable = False
            Me.QtyOnHand.Width = 115
            '
            'BaseUnitName
            '
            Me.BaseUnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.BaseUnitName.BegFindValue = Nothing
            Me.BaseUnitName.DataPropertyName = "BaseUnitName"
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.BaseUnitName.DefaultCellStyle = DataGridViewCellStyle17
            Me.BaseUnitName.EditingMode = False
            Me.BaseUnitName.EndFindValue = Nothing
            Me.BaseUnitName.FieldDescription = Nothing
            Me.BaseUnitName.FieldName = Nothing
            Me.BaseUnitName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.BaseUnitName.FindEnabled = False
            Me.BaseUnitName.HeaderText = "Base Unit Name"
            Me.BaseUnitName.IgnoreCase = False
            Me.BaseUnitName.MinimumWidth = 6
            Me.BaseUnitName.Name = "BaseUnitName"
            Me.BaseUnitName.ReadOnly = True
            Me.BaseUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.BaseUnitName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.BaseUnitName.Translatable = False
            Me.BaseUnitName.Width = 123
            '
            'QtySupplied
            '
            Me.QtySupplied.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.QtySupplied.DataPropertyName = "QtySupplied"
            Me.QtySupplied.DecimalPlaces = -1
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.QtySupplied.DefaultCellStyle = DataGridViewCellStyle18
            Me.QtySupplied.EditingMode = False
            Me.QtySupplied.HeaderText = "Qty. Supplied"
            Me.QtySupplied.MinimumWidth = 6
            Me.QtySupplied.Name = "QtySupplied"
            Me.QtySupplied.ReadOnly = True
            Me.QtySupplied.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.QtySupplied.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.QtySupplied.Translatable = False
            Me.QtySupplied.Width = 107
            '
            'dgvUnitCost
            '
            Me.dgvUnitCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvUnitCost.BegFindValue = Nothing
            Me.dgvUnitCost.DataPropertyName = "UnitCost"
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle19.Format = "###,##0.00"
            Me.dgvUnitCost.DefaultCellStyle = DataGridViewCellStyle19
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
            Me.dgvUnitCost.Width = 83
            '
            'dgvUnitIdNo
            '
            Me.dgvUnitIdNo.BegFindValue = Nothing
            Me.dgvUnitIdNo.DataPropertyName = "UnitIdNo"
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            Me.dgvUnitIdNo.DefaultCellStyle = DataGridViewCellStyle20
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
            Me.dgvUnitIdNo.Width = 125
            '
            'dgvNetAmount
            '
            Me.dgvNetAmount.BegFindValue = Nothing
            Me.dgvNetAmount.DataPropertyName = "NetAmount"
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.Format = "###,##0.00"
            Me.dgvNetAmount.DefaultCellStyle = DataGridViewCellStyle21
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
            Me.dgvNetAmount.Width = 125
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
            'CDgvTextColumn1
            '
            Me.CDgvTextColumn1.BegFindValue = Nothing
            Me.CDgvTextColumn1.DataPropertyName = "BaseUnitIdNo"
            DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
            Me.CDgvTextColumn1.DefaultCellStyle = DataGridViewCellStyle22
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
            Me.CDgvTextColumn1.Width = 125
            '
            'InvRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(1231, 650)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "InvRequestForm"
            Me.Text = "Inventory Request Viewer"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewInvTransItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTranItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsInvTransactionRequest As BindingSource
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
        Friend WithEvents lblWarehouseIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboWarehouseSelector As Libraries.CBaseControlsLibrary.CtComboBox
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
        Friend WithEvents DataGridViewInvTransactionRequests As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents DataGridViewInvTransItems As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents lblRequestedItems As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents bsInvTranItems As BindingSource
        Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvReferenceNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvWarehouseToIdNo As Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn
        Friend WithEvents dgvDateCreated As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTransactionDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvUserIdNo As Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn
        Friend WithEvents dgvNotes As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvSequence As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvProductCode As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvProductName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents QuantityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnitName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents QtyOnHand As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents BaseUnitName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents QtySupplied As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents dgvUnitCost As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvUnitIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvNetAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvProductIdNo As DataGridViewTextBoxColumn
        Friend WithEvents CDgvTextColumn1 As Libraries.CBaseControlsLibrary.CDgvTextColumn
    End Class
End Namespace