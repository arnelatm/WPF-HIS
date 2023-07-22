<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemDetailsFinder
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
        Me.DataGridViewItemDetails = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemDetailModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtFinder = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchaseDetailTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter()
        Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.DataGridViewItemDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemDetailModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewItemDetails
        '
        Me.DataGridViewItemDetails.AutoGenerateColumns = False
        Me.DataGridViewItemDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewItemDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.ProductCode, Me.Barcode, Me.GTIN})
        Me.DataGridViewItemDetails.DataSource = Me.ProductBindingSource
        Me.DataGridViewItemDetails.Location = New System.Drawing.Point(10, 37)
        Me.DataGridViewItemDetails.Name = "DataGridViewItemDetails"
        Me.DataGridViewItemDetails.Size = New System.Drawing.Size(962, 278)
        Me.DataGridViewItemDetails.TabIndex = 7
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ProductName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "ProductCode"
        Me.ProductCode.Name = "ProductCode"
        '
        'Barcode
        '
        Me.Barcode.DataPropertyName = "Barcode"
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        '
        'GTIN
        '
        Me.GTIN.DataPropertyName = "GTIN"
        Me.GTIN.HeaderText = "GTIN"
        Me.GTIN.Name = "GTIN"
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
        'txtFinder
        '
        Me.txtFinder.BackColor = System.Drawing.Color.White
        Me.txtFinder.BegFindValue = Nothing
        Me.txtFinder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinder.ComputedValue = False
        Me.txtFinder.CustomFormat = Nothing
        Me.txtFinder.DataBoundControl = True
        Me.txtFinder.EditingMode = True
        Me.txtFinder.EndFindValue = Nothing
        Me.txtFinder.FieldDescription = Nothing
        Me.txtFinder.FieldName = Nothing
        Me.txtFinder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtFinder.FindEnabled = False
        Me.txtFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtFinder.ForeColor = System.Drawing.Color.Black
        Me.txtFinder.LinkedLabel = Nothing
        Me.txtFinder.Location = New System.Drawing.Point(10, 10)
        Me.txtFinder.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFinder.MaximumValue = Nothing
        Me.txtFinder.MinimumValue = Nothing
        Me.txtFinder.Name = "txtFinder"
        Me.txtFinder.OldValue = Nothing
        Me.txtFinder.OverrideMaxLength = 0
        Me.txtFinder.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtFinder.Size = New System.Drawing.Size(962, 23)
        Me.txtFinder.TabIndex = 8
        Me.txtFinder.Translatable = False
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
        'PurchaseDetailTableAdapter
        '
        Me.PurchaseDetailTableAdapter.ClearBeforeFill = True
        '
        'ProductTableAdapter
        '
        Me.ProductTableAdapter.ClearBeforeFill = True
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = False
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(401, 321)
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
        Me.btnCancel.Location = New System.Drawing.Point(513, 321)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'ItemDetailsFinder
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(984, 358)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtFinder)
        Me.Controls.Add(Me.DataGridViewItemDetails)
        Me.Name = "ItemDetailsFinder"
        Me.Text = "ItemDetailsFinder"
        CType(Me.DataGridViewItemDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemDetailModelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewItemDetails As DataGridView
    Friend WithEvents txtFinder As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ItemBindingSource As BindingSource
    Friend WithEvents DataGridViewProductName As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ItemDetailModelBindingSource As BindingSource
    Friend WithEvents PurchaseDetailBindingSource As BindingSource
    Friend WithEvents PurchaseDetailTableAdapter As ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter
    Friend WithEvents ProductBindingSource As BindingSource
    Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
    Friend WithEvents ProductCode As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents GTIN As DataGridViewTextBoxColumn
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
End Class
