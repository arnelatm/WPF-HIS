<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PurchaseOrderApprovalEntry
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.DataGridViewPurchaseOrder = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
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
        Me.bsPurchaseOrders = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        CType(Me.DataGridViewPurchaseOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblWarehouseIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cboWarehouseIdNo)
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewPurchaseOrder)
        Me.CFlowLayout1.Location = New System.Drawing.Point(5, 86)
        Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1423, 667)
        Me.CFlowLayout1.TabIndex = 5
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
        Me.lblWarehouseIdNo.Size = New System.Drawing.Size(315, 30)
        Me.lblWarehouseIdNo.TabIndex = 8
        Me.lblWarehouseIdNo.Text = "Warehouse Code/Name2 :"
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
        Me.cboWarehouseIdNo.LinkedLabel = Nothing
        Me.cboWarehouseIdNo.Location = New System.Drawing.Point(318, 1)
        Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
        Me.cboWarehouseIdNo.OldValue = 0
        Me.cboWarehouseIdNo.OriginalDataSource = Nothing
        Me.cboWarehouseIdNo.OriginalList = Nothing
        Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
        Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
        Me.cboWarehouseIdNo.PropertySelector = Nothing
        Me.cboWarehouseIdNo.ReadOnlyCombo = False
        Me.cboWarehouseIdNo.Size = New System.Drawing.Size(452, 28)
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
        'DataGridViewPurchaseOrder
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPurchaseOrder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPurchaseOrder.AutoGenerateColumns = False
        Me.DataGridViewPurchaseOrder.BegFindValue = Nothing
        Me.DataGridViewPurchaseOrder.Cached = False
        Me.DataGridViewPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPurchaseOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.DataGridViewPurchaseOrder.DataFilter = Nothing
        Me.DataGridViewPurchaseOrder.DataSource = Me.bsPurchaseOrders
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPurchaseOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewPurchaseOrder.DgvFooter = Nothing
        Me.DataGridViewPurchaseOrder.DisplayOnly = False
        Me.DataGridViewPurchaseOrder.Ea = Nothing
        Me.DataGridViewPurchaseOrder.EditingMode = False
        Me.DataGridViewPurchaseOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPurchaseOrder.EndFindValue = Nothing
        Me.DataGridViewPurchaseOrder.FieldDescription = Nothing
        Me.DataGridViewPurchaseOrder.FieldName = Nothing
        Me.DataGridViewPurchaseOrder.FieldsDictionary = Nothing
        Me.DataGridViewPurchaseOrder.FindColumnNo = CType(0, Short)
        Me.DataGridViewPurchaseOrder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPurchaseOrder.FindEnabled = False
        Me.DataGridViewPurchaseOrder.FirstRowDeletionEnabled = True
        Me.DataGridViewPurchaseOrder.FirstRowInsertionEnabled = True
        Me.DataGridViewPurchaseOrder.IgnoreCase = False
        Me.DataGridViewPurchaseOrder.IsDirty = False
        Me.DataGridViewPurchaseOrder.Location = New System.Drawing.Point(4, 36)
        Me.DataGridViewPurchaseOrder.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridViewPurchaseOrder.Name = "DataGridViewPurchaseOrder"
        Me.DataGridViewPurchaseOrder.ReadOnly = True
        Me.DataGridViewPurchaseOrder.RowHeadersWidth = 51
        Me.DataGridViewPurchaseOrder.Searchable = True
        Me.DataGridViewPurchaseOrder.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPurchaseOrder.SecurityKey = ""
        Me.DataGridViewPurchaseOrder.SequenceColumn = "dgvSequence"
        Me.DataGridViewPurchaseOrder.SequenceFieldName = "Sequence"
        Me.DataGridViewPurchaseOrder.ShowFooter = False
        Me.DataGridViewPurchaseOrder.Size = New System.Drawing.Size(1407, 593)
        Me.DataGridViewPurchaseOrder.TabIndex = 3
        Me.DataGridViewPurchaseOrder.Translatable = True
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
        'bsPurchaseOrders
        '
        Me.bsPurchaseOrders.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
        '
        'PurchaseOrderApprovalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1431, 757)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "PurchaseOrderApprovalEntry"
        Me.Text = "Employee Leave Approval"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        CType(Me.DataGridViewPurchaseOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents DataGridViewPurchaseOrder As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents dgvPurchaseOrderIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
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
    Friend WithEvents bsPurchaseOrders As BindingSource
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
