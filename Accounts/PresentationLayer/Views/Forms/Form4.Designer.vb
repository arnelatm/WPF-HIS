<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSearch = New System.Windows.Forms.ComboBox()
        Me.DataGridViewProducts = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ISPDATADataSet = New AATM.Accounts.ISPDATADataSet()
        Me.PurchaseDetailModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.QuantityDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BonusQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchaseDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewPurchase = New System.Windows.Forms.DataGridView()
        Me.PurchaseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductIdNoDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtFinder = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchaseDetailTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter()
        Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridViewProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtSearch.DisplayMember = "ProductName"
        Me.txtSearch.FormattingEnabled = True
        Me.txtSearch.Location = New System.Drawing.Point(252, 121)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(515, 21)
        Me.txtSearch.TabIndex = 6
        Me.txtSearch.ValueMember = "IdNo"
        '
        'DataGridViewProducts
        '
        Me.DataGridViewProducts.AutoGenerateColumns = False
        Me.DataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.ProductCode, Me.Barcode, Me.GTIN})
        Me.DataGridViewProducts.DataSource = Me.ProductBindingSource
        Me.DataGridViewProducts.Location = New System.Drawing.Point(252, 407)
        Me.DataGridViewProducts.Name = "DataGridViewProducts"
        Me.DataGridViewProducts.Size = New System.Drawing.Size(793, 173)
        Me.DataGridViewProducts.TabIndex = 7
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ProductName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
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
        'ProductBindingSource
        '
        Me.ProductBindingSource.DataMember = "Product"
        Me.ProductBindingSource.DataSource = Me.ISPDATADataSet
        '
        'ISPDATADataSet
        '
        Me.ISPDATADataSet.DataSetName = "ISPDATADataSet"
        Me.ISPDATADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QuantityDataGridViewTextBoxColumn1, Me.BonusQuantityDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PurchaseDetailBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(1087, 157)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(540, 250)
        Me.DataGridView1.TabIndex = 11
        '
        'QuantityDataGridViewTextBoxColumn1
        '
        Me.QuantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn1.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn1.Name = "QuantityDataGridViewTextBoxColumn1"
        '
        'BonusQuantityDataGridViewTextBoxColumn
        '
        Me.BonusQuantityDataGridViewTextBoxColumn.DataPropertyName = "BonusQuantity"
        Me.BonusQuantityDataGridViewTextBoxColumn.HeaderText = "BonusQuantity"
        Me.BonusQuantityDataGridViewTextBoxColumn.Name = "BonusQuantityDataGridViewTextBoxColumn"
        '
        'PurchaseDetailBindingSource
        '
        Me.PurchaseDetailBindingSource.DataMember = "PurchaseDetail"
        Me.PurchaseDetailBindingSource.DataSource = Me.ISPDATADataSet
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
        'DataGridViewPurchase
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPurchase.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPurchase.AutoGenerateColumns = False
        Me.DataGridViewPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPurchase.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseIdNoDataGridViewTextBoxColumn, Me.ProductIdNoDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn})
        Me.DataGridViewPurchase.DataSource = Me.PurchaseDetailBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPurchase.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewPurchase.Location = New System.Drawing.Point(252, 157)
        Me.DataGridViewPurchase.Name = "DataGridViewPurchase"
        Me.DataGridViewPurchase.Size = New System.Drawing.Size(793, 214)
        Me.DataGridViewPurchase.TabIndex = 9
        '
        'PurchaseIdNoDataGridViewTextBoxColumn
        '
        Me.PurchaseIdNoDataGridViewTextBoxColumn.DataPropertyName = "PurchaseIdNo"
        Me.PurchaseIdNoDataGridViewTextBoxColumn.HeaderText = "PurchaseIdNo"
        Me.PurchaseIdNoDataGridViewTextBoxColumn.Name = "PurchaseIdNoDataGridViewTextBoxColumn"
        '
        'ProductIdNoDataGridViewTextBoxColumn
        '
        Me.ProductIdNoDataGridViewTextBoxColumn.AutoComplete = False
        Me.ProductIdNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProductIdNoDataGridViewTextBoxColumn.DataPropertyName = "ProductIdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.ProductIdNoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProductIdNoDataGridViewTextBoxColumn.EditingMode = False
        Me.ProductIdNoDataGridViewTextBoxColumn.HeaderText = "ProductIdNo"
        Me.ProductIdNoDataGridViewTextBoxColumn.Name = "ProductIdNoDataGridViewTextBoxColumn"
        Me.ProductIdNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductIdNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductIdNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ProductIdNoDataGridViewTextBoxColumn.Translatable = False
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
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
        Me.txtFinder.Location = New System.Drawing.Point(252, 89)
        Me.txtFinder.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFinder.MaximumValue = Nothing
        Me.txtFinder.MinimumValue = Nothing
        Me.txtFinder.Name = "txtFinder"
        Me.txtFinder.OldValue = Nothing
        Me.txtFinder.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtFinder.Size = New System.Drawing.Size(793, 23)
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
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = False
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = True
        Me.CTextBox1.EditingMode = True
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = False
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(72, 43)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox1.TabIndex = 0
        Me.CTextBox1.Translatable = False
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = False
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(72, 87)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(90, 25)
        Me.CButton1.TabIndex = 1
        Me.CButton1.Text = "CButton1"
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(69, 138)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(93, 17)
        Me.CLabel1.TabIndex = 2
        Me.CLabel1.Text = "fraction value"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = True
        Me.CLabel2.DisplayOnly = True
        Me.CLabel2.EditingMode = False
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel2.Location = New System.Drawing.Point(69, 157)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(93, 17)
        Me.CLabel2.TabIndex = 3
        Me.CLabel2.Text = "fraction value"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = True
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = True
        Me.CLabel3.DisplayOnly = True
        Me.CLabel3.EditingMode = False
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel3.Location = New System.Drawing.Point(69, 176)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(93, 17)
        Me.CLabel3.TabIndex = 4
        Me.CLabel3.Text = "fraction value"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1809, 621)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridViewPurchase)
        Me.Controls.Add(Me.txtFinder)
        Me.Controls.Add(Me.DataGridViewProducts)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CLabel3)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.CButton1)
        Me.Controls.Add(Me.CTextBox1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.DataGridViewProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailModelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents txtSearch As ComboBox
    Friend WithEvents DataGridViewProducts As DataGridView
    Friend WithEvents txtFinder As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewPurchase As DataGridView
    Friend WithEvents ProductBindingSource1 As BindingSource
    Friend WithEvents DataGridViewProductName As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PurchaseDetailModelBindingSource As BindingSource
    Friend WithEvents ISPDATADataSet As ISPDATADataSet
    Friend WithEvents PurchaseDetailBindingSource As BindingSource
    Friend WithEvents PurchaseDetailTableAdapter As ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter
    Friend WithEvents ProductBindingSource As BindingSource
    Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
    Friend WithEvents ProductCode As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents GTIN As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DgProductName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents QuantityDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents BonusQuantityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PurchaseIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductIdNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CButton1 As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents ComboBox1 As ComboBox
End Class
