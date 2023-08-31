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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewInvTransactionRequests = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.bsInvTransactionRequest = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvWarehouseToIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn()
            Me.dgvDateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cancelled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
            Me.DataGridViewInvTransactionRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvReferenceNo, Me.dgvWarehouseToIdNo, Me.dgvUserIdNo, Me.dgvDateCreated, Me.dgvNotes, Me.dgvTransactionDate, Me.IdNo, Me.Amount, Me.Cancelled})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewInvTransactionRequests, 4)
            Me.DataGridViewInvTransactionRequests.DataFilter = Nothing
            Me.DataGridViewInvTransactionRequests.DataSource = Me.bsInvTransactionRequest
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
            'bsInvTransactionRequest
            '
            Me.bsInvTransactionRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
            '
            'dgvReferenceNo
            '
            Me.dgvReferenceNo.BegFindValue = Nothing
            Me.dgvReferenceNo.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvReferenceNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvReferenceNo.EditingMode = False
            Me.dgvReferenceNo.EndFindValue = Nothing
            Me.dgvReferenceNo.FieldDescription = Nothing
            Me.dgvReferenceNo.FieldName = Nothing
            Me.dgvReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvReferenceNo.FindEnabled = False
            Me.dgvReferenceNo.HeaderText = "ReferenceNo"
            Me.dgvReferenceNo.IgnoreCase = False
            Me.dgvReferenceNo.MinimumWidth = 6
            Me.dgvReferenceNo.Name = "dgvReferenceNo"
            Me.dgvReferenceNo.ReadOnly = True
            Me.dgvReferenceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvReferenceNo.Translatable = False
            Me.dgvReferenceNo.Width = 125
            '
            'dgvWarehouseToIdNo
            '
            Me.dgvWarehouseToIdNo.AutoComplete = False
            Me.dgvWarehouseToIdNo.DataPropertyName = "WarehouseToIdNo"
            Me.dgvWarehouseToIdNo.EditingMode = False
            Me.dgvWarehouseToIdNo.HeaderText = "WarehouseToIdNo"
            Me.dgvWarehouseToIdNo.MinimumWidth = 6
            Me.dgvWarehouseToIdNo.Name = "dgvWarehouseToIdNo"
            Me.dgvWarehouseToIdNo.ReadOnly = True
            Me.dgvWarehouseToIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvWarehouseToIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvWarehouseToIdNo.SuggestCharCount = 0
            Me.dgvWarehouseToIdNo.Translatable = False
            Me.dgvWarehouseToIdNo.Width = 125
            '
            'dgvUserIdNo
            '
            Me.dgvUserIdNo.AutoComplete = False
            Me.dgvUserIdNo.DataPropertyName = "UserIdNo"
            Me.dgvUserIdNo.EditingMode = False
            Me.dgvUserIdNo.HeaderText = "UserIdNo"
            Me.dgvUserIdNo.MinimumWidth = 6
            Me.dgvUserIdNo.Name = "dgvUserIdNo"
            Me.dgvUserIdNo.ReadOnly = True
            Me.dgvUserIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvUserIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvUserIdNo.SuggestCharCount = 0
            Me.dgvUserIdNo.Translatable = False
            Me.dgvUserIdNo.Width = 125
            '
            'dgvDateCreated
            '
            Me.dgvDateCreated.DataPropertyName = "DateCreated"
            Me.dgvDateCreated.HeaderText = "DateCreated"
            Me.dgvDateCreated.MinimumWidth = 6
            Me.dgvDateCreated.Name = "dgvDateCreated"
            Me.dgvDateCreated.ReadOnly = True
            Me.dgvDateCreated.Width = 125
            '
            'dgvNotes
            '
            Me.dgvNotes.DataPropertyName = "Notes"
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.MinimumWidth = 6
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Width = 125
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            Me.dgvTransactionDate.HeaderText = "TransactionDate"
            Me.dgvTransactionDate.MinimumWidth = 6
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.Width = 125
            '
            'IdNo
            '
            Me.IdNo.DataPropertyName = "IdNo"
            Me.IdNo.HeaderText = "IdNo"
            Me.IdNo.MinimumWidth = 6
            Me.IdNo.Name = "IdNo"
            Me.IdNo.ReadOnly = True
            Me.IdNo.Visible = False
            Me.IdNo.Width = 125
            '
            'Amount
            '
            Me.Amount.DataPropertyName = "Amount"
            Me.Amount.HeaderText = "Amount"
            Me.Amount.MinimumWidth = 6
            Me.Amount.Name = "Amount"
            Me.Amount.ReadOnly = True
            Me.Amount.Visible = False
            Me.Amount.Width = 125
            '
            'Cancelled
            '
            Me.Cancelled.DataPropertyName = "Cancelled"
            Me.Cancelled.HeaderText = "Cancelled"
            Me.Cancelled.MinimumWidth = 6
            Me.Cancelled.Name = "Cancelled"
            Me.Cancelled.ReadOnly = True
            Me.Cancelled.Visible = False
            Me.Cancelled.Width = 125
            '
            'InvRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(790, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "InvRequestForm"
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
        Friend WithEvents cboWarehouseSelector As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents dgvReferenceNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvWarehouseToIdNo As Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn
        Friend WithEvents dgvUserIdNo As Libraries.CBaseControlsLibrary.CtDgvComboBoxColumn
        Friend WithEvents dgvDateCreated As DataGridViewTextBoxColumn
        Friend WithEvents dgvNotes As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransactionDate As DataGridViewTextBoxColumn
        Friend WithEvents IdNo As DataGridViewTextBoxColumn
        Friend WithEvents Amount As DataGridViewTextBoxColumn
        Friend WithEvents Cancelled As DataGridViewCheckBoxColumn
    End Class
End Namespace