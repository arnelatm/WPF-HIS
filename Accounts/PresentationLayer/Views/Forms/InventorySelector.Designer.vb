<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventorySelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridViewProducts = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BatchNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpiryDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyOnHandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsInventory = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblProductName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.DataGridViewProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewProducts
        '
        Me.DataGridViewProducts.AutoGenerateColumns = False
        Me.DataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNoDataGridViewTextBoxColumn, Me.ExpiryDateDataGridViewTextBoxColumn, Me.QtyOnHandDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn2})
        Me.DataGridViewProducts.DataSource = Me.bsInventory
        Me.DataGridViewProducts.Location = New System.Drawing.Point(12, 32)
        Me.DataGridViewProducts.Name = "DataGridViewProducts"
        Me.DataGridViewProducts.Size = New System.Drawing.Size(444, 140)
        Me.DataGridViewProducts.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ProductCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ProductCode"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "GTIN"
        Me.DataGridViewTextBoxColumn4.HeaderText = "GTIN"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn5.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PurchaseIdNo"
        Me.DataGridViewTextBoxColumn7.HeaderText = "PurchaseIdNo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ProductIdNo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "ProductIdNo"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = False
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(132, 178)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(244, 178)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'BatchNoDataGridViewTextBoxColumn
        '
        Me.BatchNoDataGridViewTextBoxColumn.DataPropertyName = "BatchNo"
        Me.BatchNoDataGridViewTextBoxColumn.HeaderText = "BatchNo"
        Me.BatchNoDataGridViewTextBoxColumn.Name = "BatchNoDataGridViewTextBoxColumn"
        '
        'ExpiryDateDataGridViewTextBoxColumn
        '
        Me.ExpiryDateDataGridViewTextBoxColumn.DataPropertyName = "ExpiryDate"
        Me.ExpiryDateDataGridViewTextBoxColumn.HeaderText = "ExpiryDate"
        Me.ExpiryDateDataGridViewTextBoxColumn.Name = "ExpiryDateDataGridViewTextBoxColumn"
        '
        'QtyOnHandDataGridViewTextBoxColumn
        '
        Me.QtyOnHandDataGridViewTextBoxColumn.DataPropertyName = "QtyOnHand"
        Me.QtyOnHandDataGridViewTextBoxColumn.HeaderText = "QtyOnHand"
        Me.QtyOnHandDataGridViewTextBoxColumn.Name = "QtyOnHandDataGridViewTextBoxColumn"
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'bsInventory
        '
        Me.bsInventory.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InventoryModel)
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.DisplayOnly = True
        Me.lblProductName.EditingMode = False
        Me.lblProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblProductName.Location = New System.Drawing.Point(12, 9)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(98, 17)
        Me.lblProductName.TabIndex = 11
        Me.lblProductName.Text = "Product Name"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProductName.Translatable = True
        '
        'InventorySelector
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(466, 217)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.DataGridViewProducts)
        Me.Name = "InventorySelector"
        Me.Text = "Inventory Selector"
        CType(Me.DataGridViewProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewProducts As DataGridView
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewProductName As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DgProductName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents bsInventory As BindingSource
    Friend WithEvents BatchNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpiryDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QtyOnHandDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents lblProductName As Libraries.CBaseControlsLibrary.CLabel
End Class
