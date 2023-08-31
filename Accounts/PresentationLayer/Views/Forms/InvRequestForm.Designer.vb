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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewInvTransactionRequests = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvFileType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PostedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.ReferenceNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UserIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WarehouseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WarehouseToIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsInvTransactionRequest = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(687, 3)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(90, 25)
            Me.btnRefresh.TabIndex = 11
            Me.btnRefresh.Text = "Refresh"
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
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 59)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(790, 494)
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
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboWarehouseIdNo, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(783, 468)
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
            Me.DataGridViewInvTransactionRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvFileType, Me.dgvTime, Me.dgvTransKey, Me.AmountDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.InvTransTypeIdNoDataGridViewTextBoxColumn, Me.NotesDataGridViewTextBoxColumn, Me.PostedDataGridViewCheckBoxColumn, Me.ReferenceNoDataGridViewTextBoxColumn, Me.TransactionDateDataGridViewTextBoxColumn, Me.UserIdNoDataGridViewTextBoxColumn, Me.WarehouseIdNoDataGridViewTextBoxColumn, Me.WarehouseToIdNoDataGridViewTextBoxColumn})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewInvTransactionRequests, 4)
            Me.DataGridViewInvTransactionRequests.DataFilter = Nothing
            Me.DataGridViewInvTransactionRequests.DataSource = Me.bsInvTransactionRequest
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvTransactionRequests.DefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewInvTransactionRequests.DgvFooter = Nothing
            Me.DataGridViewInvTransactionRequests.DisplayOnly = True
            Me.DataGridViewInvTransactionRequests.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewInvTransactionRequests.Ea = Nothing
            Me.DataGridViewInvTransactionRequests.EditingMode = False
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
            Me.DataGridViewInvTransactionRequests.Location = New System.Drawing.Point(3, 34)
            Me.DataGridViewInvTransactionRequests.Name = "DataGridViewInvTransactionRequests"
            Me.DataGridViewInvTransactionRequests.ReadOnly = True
            Me.DataGridViewInvTransactionRequests.RowHeadersWidth = 51
            Me.DataGridViewInvTransactionRequests.Searchable = True
            Me.DataGridViewInvTransactionRequests.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvTransactionRequests.SecurityKey = ""
            Me.DataGridViewInvTransactionRequests.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvTransactionRequests.SequenceFieldName = "Sequence"
            Me.DataGridViewInvTransactionRequests.ShowFooter = False
            Me.DataGridViewInvTransactionRequests.Size = New System.Drawing.Size(777, 431)
            Me.DataGridViewInvTransactionRequests.TabIndex = 11
            Me.DataGridViewInvTransactionRequests.Translatable = True
            '
            'dgvFileType
            '
            Me.dgvFileType.BegFindValue = Nothing
            Me.dgvFileType.DataPropertyName = "InvType"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvFileType.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvFileType.EditingMode = False
            Me.dgvFileType.EndFindValue = Nothing
            Me.dgvFileType.FieldDescription = Nothing
            Me.dgvFileType.FieldName = Nothing
            Me.dgvFileType.FillWeight = 60.0!
            Me.dgvFileType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvFileType.FindEnabled = False
            Me.dgvFileType.HeaderText = "Patient Type"
            Me.dgvFileType.IgnoreCase = False
            Me.dgvFileType.MinimumWidth = 6
            Me.dgvFileType.Name = "dgvFileType"
            Me.dgvFileType.ReadOnly = True
            Me.dgvFileType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvFileType.Translatable = False
            Me.dgvFileType.Width = 60
            '
            'dgvTime
            '
            Me.dgvTime.DataPropertyName = "InvTime"
            DataGridViewCellStyle3.Format = "hh:mm tt"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.dgvTime.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTime.HeaderText = "Time"
            Me.dgvTime.MinimumWidth = 6
            Me.dgvTime.Name = "dgvTime"
            Me.dgvTime.ReadOnly = True
            Me.dgvTime.Width = 125
            '
            'dgvTransKey
            '
            Me.dgvTransKey.DataPropertyName = "TransKey"
            Me.dgvTransKey.HeaderText = "TransKey"
            Me.dgvTransKey.MinimumWidth = 6
            Me.dgvTransKey.Name = "dgvTransKey"
            Me.dgvTransKey.ReadOnly = True
            Me.dgvTransKey.Visible = False
            Me.dgvTransKey.Width = 125
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
            Me.cboWarehouseIdNo.FindEnabled = False
            Me.cboWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseIdNo.FormattingEnabled = True
            Me.cboWarehouseIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseIdNo.IgnoreCase = False
            Me.cboWarehouseIdNo.IntegralHeight = False
            Me.cboWarehouseIdNo.LimitToList = False
            Me.cboWarehouseIdNo.LinkedLabel = Nothing
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(174, 1)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.ReadOnlyCombo = False
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(509, 28)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 15
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
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
            'AmountDataGridViewTextBoxColumn
            '
            Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
            Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.AmountDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
            Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.AmountDataGridViewTextBoxColumn.Width = 125
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            Me.CancelledDataGridViewCheckBoxColumn.Width = 125
            '
            'DateCreatedDataGridViewTextBoxColumn
            '
            Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
            Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
            Me.DateCreatedDataGridViewTextBoxColumn.Width = 125
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
            '
            'InvTransTypeIdNoDataGridViewTextBoxColumn
            '
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.DataPropertyName = "InvTransTypeIdNo"
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.HeaderText = "InvTransTypeIdNo"
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.Name = "InvTransTypeIdNoDataGridViewTextBoxColumn"
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.InvTransTypeIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'NotesDataGridViewTextBoxColumn
            '
            Me.NotesDataGridViewTextBoxColumn.DataPropertyName = "Notes"
            Me.NotesDataGridViewTextBoxColumn.HeaderText = "Notes"
            Me.NotesDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.NotesDataGridViewTextBoxColumn.Name = "NotesDataGridViewTextBoxColumn"
            Me.NotesDataGridViewTextBoxColumn.ReadOnly = True
            Me.NotesDataGridViewTextBoxColumn.Width = 125
            '
            'PostedDataGridViewCheckBoxColumn
            '
            Me.PostedDataGridViewCheckBoxColumn.DataPropertyName = "Posted"
            Me.PostedDataGridViewCheckBoxColumn.HeaderText = "Posted"
            Me.PostedDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.PostedDataGridViewCheckBoxColumn.Name = "PostedDataGridViewCheckBoxColumn"
            Me.PostedDataGridViewCheckBoxColumn.ReadOnly = True
            Me.PostedDataGridViewCheckBoxColumn.Width = 125
            '
            'ReferenceNoDataGridViewTextBoxColumn
            '
            Me.ReferenceNoDataGridViewTextBoxColumn.DataPropertyName = "ReferenceNo"
            Me.ReferenceNoDataGridViewTextBoxColumn.HeaderText = "ReferenceNo"
            Me.ReferenceNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReferenceNoDataGridViewTextBoxColumn.Name = "ReferenceNoDataGridViewTextBoxColumn"
            Me.ReferenceNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReferenceNoDataGridViewTextBoxColumn.Width = 125
            '
            'TransactionDateDataGridViewTextBoxColumn
            '
            Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate"
            Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "TransactionDate"
            Me.TransactionDateDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
            Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.TransactionDateDataGridViewTextBoxColumn.Width = 125
            '
            'UserIdNoDataGridViewTextBoxColumn
            '
            Me.UserIdNoDataGridViewTextBoxColumn.DataPropertyName = "UserIdNo"
            Me.UserIdNoDataGridViewTextBoxColumn.HeaderText = "UserIdNo"
            Me.UserIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.UserIdNoDataGridViewTextBoxColumn.Name = "UserIdNoDataGridViewTextBoxColumn"
            Me.UserIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.UserIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'WarehouseIdNoDataGridViewTextBoxColumn
            '
            Me.WarehouseIdNoDataGridViewTextBoxColumn.DataPropertyName = "WarehouseIdNo"
            Me.WarehouseIdNoDataGridViewTextBoxColumn.HeaderText = "WarehouseIdNo"
            Me.WarehouseIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.WarehouseIdNoDataGridViewTextBoxColumn.Name = "WarehouseIdNoDataGridViewTextBoxColumn"
            Me.WarehouseIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.WarehouseIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'WarehouseToIdNoDataGridViewTextBoxColumn
            '
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.DataPropertyName = "WarehouseToIdNo"
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.HeaderText = "WarehouseToIdNo"
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.Name = "WarehouseToIdNoDataGridViewTextBoxColumn"
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.WarehouseToIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'bsInvTransactionRequest
            '
            Me.bsInvTransactionRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
            '
            'InvTransactionRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(790, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "InvTransactionRequestForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Inventory Request Viewer"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            CType(Me.DataGridViewInvTransactionRequests, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents btnRefresh As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents DataGridViewInvTransactionRequests As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents lblWarehouseIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dgvFileType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTime As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents cboWarehouseIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
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
    End Class
End Namespace