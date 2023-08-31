<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockRequestApprovalEntry
    Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewStockRequest = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsInvTransactionRequest = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        CType(Me.DataGridViewStockRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblWarehouseIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cboWarehouseIdNo)
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewStockRequest)
        Me.CFlowLayout1.Location = New System.Drawing.Point(4, 70)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1067, 542)
        Me.CFlowLayout1.TabIndex = 5
        '
        'DataGridViewStockRequest
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewStockRequest.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewStockRequest.AutoGenerateColumns = False
        Me.DataGridViewStockRequest.BegFindValue = Nothing
        Me.DataGridViewStockRequest.Cached = False
        Me.DataGridViewStockRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewStockRequest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.DataGridViewStockRequest.DataFilter = Nothing
        Me.DataGridViewStockRequest.DataSource = Me.bsInvTransactionRequest
        Me.DataGridViewStockRequest.DgvFooter = Nothing
        Me.DataGridViewStockRequest.DisplayOnly = False
        Me.DataGridViewStockRequest.Ea = Nothing
        Me.DataGridViewStockRequest.EditingMode = False
        Me.DataGridViewStockRequest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewStockRequest.EndFindValue = Nothing
        Me.DataGridViewStockRequest.FieldDescription = Nothing
        Me.DataGridViewStockRequest.FieldName = Nothing
        Me.DataGridViewStockRequest.FieldsDictionary = Nothing
        Me.DataGridViewStockRequest.FindColumnNo = CType(0, Short)
        Me.DataGridViewStockRequest.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewStockRequest.FindEnabled = False
        Me.DataGridViewStockRequest.FirstRowDeletionEnabled = True
        Me.DataGridViewStockRequest.FirstRowInsertionEnabled = True
        Me.DataGridViewStockRequest.IgnoreCase = False
        Me.DataGridViewStockRequest.IsDirty = False
        Me.DataGridViewStockRequest.Location = New System.Drawing.Point(3, 33)
        Me.DataGridViewStockRequest.Name = "DataGridViewStockRequest"
        Me.DataGridViewStockRequest.ReadOnly = True
        Me.DataGridViewStockRequest.RowHeadersWidth = 51
        Me.DataGridViewStockRequest.Searchable = True
        Me.DataGridViewStockRequest.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewStockRequest.SecurityKey = ""
        Me.DataGridViewStockRequest.SequenceColumn = "dgvSequence"
        Me.DataGridViewStockRequest.SequenceFieldName = "Sequence"
        Me.DataGridViewStockRequest.ShowFooter = False
        Me.DataGridViewStockRequest.Size = New System.Drawing.Size(1055, 482)
        Me.DataGridViewStockRequest.TabIndex = 3
        Me.DataGridViewStockRequest.Translatable = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Amount"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Cancelled"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Cancelled"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 6
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DateCreated"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DateCreated"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "InvTransTypeIdNo"
        Me.DataGridViewTextBoxColumn4.HeaderText = "InvTransTypeIdNo"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Notes"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Notes"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 125
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Posted"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Posted"
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 6
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Width = 125
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ReferenceNo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ReferenceNo"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "TransactionDate"
        Me.DataGridViewTextBoxColumn7.HeaderText = "TransactionDate"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "UserIdNo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "UserIdNo"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 125
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "WarehouseIdNo"
        Me.DataGridViewTextBoxColumn9.HeaderText = "WarehouseIdNo"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 125
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "WarehouseToIdNo"
        Me.DataGridViewTextBoxColumn10.HeaderText = "WarehouseToIdNo"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 125
        '
        'bsInvTransactionRequest
        '
        Me.bsInvTransactionRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
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
        Me.cboWarehouseIdNo.LinkedLabel = Nothing
        Me.cboWarehouseIdNo.Location = New System.Drawing.Point(239, 1)
        Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
        Me.cboWarehouseIdNo.OldValue = 0
        Me.cboWarehouseIdNo.OriginalDataSource = Nothing
        Me.cboWarehouseIdNo.OriginalList = Nothing
        Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
        Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
        Me.cboWarehouseIdNo.PropertySelector = Nothing
        Me.cboWarehouseIdNo.ReadOnlyCombo = False
        Me.cboWarehouseIdNo.Size = New System.Drawing.Size(340, 28)
        Me.cboWarehouseIdNo.SuggestBoxHeight = 200
        Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
        Me.cboWarehouseIdNo.TabIndex = 1
        Me.cboWarehouseIdNo.TextToSearch = Nothing
        Me.cboWarehouseIdNo.Translatable = False
        Me.cboWarehouseIdNo.ValueIsMandatory = False
        Me.cboWarehouseIdNo.ValueIsNullable = False
        Me.cboWarehouseIdNo.ValueIsNumeric = False
        Me.cboWarehouseIdNo.ValueMember = "IdNo"
        '
        'lblWarehouseIdNo
        '
        Me.lblWarehouseIdNo.DisplayOnly = True
        Me.lblWarehouseIdNo.EditingMode = False
        Me.lblWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblWarehouseIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWarehouseIdNo.Name = "lblWarehouseIdNo"
        Me.lblWarehouseIdNo.Size = New System.Drawing.Size(236, 24)
        Me.lblWarehouseIdNo.TabIndex = 8
        Me.lblWarehouseIdNo.Text = "Warehouse Code/Name :"
        Me.lblWarehouseIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarehouseIdNo.Translatable = True
        '
        'StockRequestApprovalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1073, 615)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "StockRequestApprovalEntry"
        Me.Text = "Employee Leave Approval"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        CType(Me.DataGridViewStockRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsInvTransactionRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents DataGridViewStockRequest As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents dgvStockRequestIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents dgvFullDay As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvStartDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEndDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveReason As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveStatus As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents enteredByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupervisorIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
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
    Friend WithEvents bsInvTransactionRequest As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents lblWarehouseIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cboWarehouseIdNo As Libraries.CBaseControlsLibrary.CaComboBox
End Class
