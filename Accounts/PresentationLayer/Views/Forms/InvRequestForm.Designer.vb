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
            Me.bsInvTransactionRequest = New System.Windows.Forms.BindingSource(Me.components)
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewInvTransactionRequests = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDateCreated = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseSelector = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.txtWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'bsInvTransactionRequest
            '
            Me.bsInvTransactionRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
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
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(916, 498)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewInvTransactionRequests, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblWarehouseIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboWarehouseSelector, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(906, 278)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewInvTransactionRequests
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewInvTransactionRequests.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewInvTransactionRequests.AutoGenerateColumns = False
            Me.DataGridViewInvTransactionRequests.BegFindValue = Nothing
            Me.DataGridViewInvTransactionRequests.Cached = False
            Me.DataGridViewInvTransactionRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvTransactionRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvReferenceNo, Me.dgvWarehouseToIdNo, Me.dgvTransactionDate, Me.dgvDateCreated, Me.dgvAmount, Me.dgvUserIdNo, Me.dgvNotes})
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
            Me.DataGridViewInvTransactionRequests.Dock = System.Windows.Forms.DockStyle.Fill
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
            Me.DataGridViewInvTransactionRequests.Location = New System.Drawing.Point(3, 33)
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
            Me.DataGridViewInvTransactionRequests.Size = New System.Drawing.Size(900, 242)
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
            Me.dgvIdNo.Width = 62
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
            Me.dgvReferenceNo.Width = 106
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
            Me.dgvWarehouseToIdNo.Translatable = False
            Me.dgvWarehouseToIdNo.Width = 148
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle5
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
            Me.dgvTransactionDate.Width = 119
            '
            'dgvDateCreated
            '
            Me.dgvDateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvDateCreated.BegFindValue = Nothing
            Me.dgvDateCreated.DataPropertyName = "DateCreated"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvDateCreated.DefaultCellStyle = DataGridViewCellStyle6
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
            Me.dgvDateCreated.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDateCreated.Translatable = False
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
            Me.dgvAmount.Width = 78
            '
            'dgvUserIdNo
            '
            Me.dgvUserIdNo.AutoComplete = False
            Me.dgvUserIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.dgvUserIdNo.Width = 64
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
            'lblWarehouseIdNo
            '
            Me.lblWarehouseIdNo.DisplayOnly = True
            Me.lblWarehouseIdNo.EditingMode = False
            Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWarehouseIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWarehouseIdNo.Name = "lblWarehouseIdNo"
            Me.lblWarehouseIdNo.Size = New System.Drawing.Size(171, 23)
            Me.lblWarehouseIdNo.TabIndex = 14
            Me.lblWarehouseIdNo.Text = "Warehouse Code - Name:"
            Me.lblWarehouseIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWarehouseIdNo.Translatable = True
            '
            'cboWarehouseSelector
            '
            Me.cboWarehouseSelector.BackColor = System.Drawing.Color.White
            Me.cboWarehouseSelector.BegFindValue = Nothing
            Me.cboWarehouseSelector.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboWarehouseSelector, 3)
            Me.cboWarehouseSelector.CurrentSearchTerm = ""
            Me.cboWarehouseSelector.DataValue = Nothing
            Me.cboWarehouseSelector.DefaultValue = Nothing
            Me.cboWarehouseSelector.DisplayMember = "Name"
            Me.cboWarehouseSelector.Dock = System.Windows.Forms.DockStyle.Fill
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
            Me.cboWarehouseSelector.Location = New System.Drawing.Point(174, 1)
            Me.cboWarehouseSelector.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseSelector.Name = "cboWarehouseSelector"
            Me.cboWarehouseSelector.OldValue = 0
            Me.cboWarehouseSelector.OriginalDataSource = Nothing
            Me.cboWarehouseSelector.OriginalList = Nothing
            Me.cboWarehouseSelector.OverrideDropDownStyleList = False
            Me.cboWarehouseSelector.PreviousSearchTerm = Nothing
            Me.cboWarehouseSelector.PropertySelector = Nothing
            Me.cboWarehouseSelector.Size = New System.Drawing.Size(731, 28)
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
            Me.txtWarehouseIdNo.Location = New System.Drawing.Point(1, 285)
            Me.txtWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtWarehouseIdNo.MaximumValue = Nothing
            Me.txtWarehouseIdNo.MinimumValue = Nothing
            Me.txtWarehouseIdNo.Name = "txtWarehouseIdNo"
            Me.txtWarehouseIdNo.OldValue = Nothing
            Me.txtWarehouseIdNo.OverrideMaxLength = 0
            Me.txtWarehouseIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtWarehouseIdNo.Size = New System.Drawing.Size(100, 26)
            Me.txtWarehouseIdNo.TabIndex = 16
            Me.txtWarehouseIdNo.Translatable = False
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
            Me.txtDoctorCode.Location = New System.Drawing.Point(693, 89)
            Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.OverrideMaxLength = 0
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(80, 26)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'InvRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(916, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "InvRequestForm"
            Me.Text = "Inventory Request Viewer"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvReferenceNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvWarehouseToIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvTransactionDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvDateCreated As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvUserIdNo As Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn
        Friend WithEvents dgvNotes As Libraries.CBaseControlsLibrary.CDgvTextColumn
    End Class
End Namespace