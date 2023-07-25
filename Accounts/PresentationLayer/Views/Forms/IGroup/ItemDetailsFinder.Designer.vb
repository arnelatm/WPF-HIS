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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewItemDetails = New System.Windows.Forms.DataGridView()
        Me.bsItemDetails = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchaseDetailTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter()
        Me.ProductTableAdapter = New AATM.Accounts.ISPDATADataSetTableAdapters.ProductTableAdapter()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtFinder = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.ItemDetailsCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.ItemDetailsName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.GenericName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.GTin = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.IdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewItemDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsItemDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewItemDetails
        '
        Me.DataGridViewItemDetails.AutoGenerateColumns = False
        Me.DataGridViewItemDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewItemDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemDetailsCode, Me.ItemDetailsName, Me.GenericName, Me.GTin, Me.IdNo})
        Me.DataGridViewItemDetails.DataSource = Me.bsItemDetails
        Me.DataGridViewItemDetails.Location = New System.Drawing.Point(12, 37)
        Me.DataGridViewItemDetails.Name = "DataGridViewItemDetails"
        Me.DataGridViewItemDetails.Size = New System.Drawing.Size(970, 278)
        Me.DataGridViewItemDetails.TabIndex = 7
        '
        'bsItemDetails
        '
        Me.bsItemDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.ItemDetailsModel)
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
        Me.txtFinder.Location = New System.Drawing.Point(12, 10)
        Me.txtFinder.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFinder.MaximumValue = Nothing
        Me.txtFinder.MinimumValue = Nothing
        Me.txtFinder.Name = "txtFinder"
        Me.txtFinder.OldValue = Nothing
        Me.txtFinder.OverrideMaxLength = 0
        Me.txtFinder.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtFinder.Size = New System.Drawing.Size(962, 23)
        Me.txtFinder.TabIndex = 11
        Me.txtFinder.Translatable = False
        '
        'ItemDetailsCode
        '
        Me.ItemDetailsCode.BegFindValue = Nothing
        Me.ItemDetailsCode.DataPropertyName = "ItemDetailsCode"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.ItemDetailsCode.DefaultCellStyle = DataGridViewCellStyle1
        Me.ItemDetailsCode.EditingMode = False
        Me.ItemDetailsCode.EndFindValue = Nothing
        Me.ItemDetailsCode.FieldDescription = Nothing
        Me.ItemDetailsCode.FieldName = Nothing
        Me.ItemDetailsCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.ItemDetailsCode.FindEnabled = False
        Me.ItemDetailsCode.HeaderText = "Medicine Code"
        Me.ItemDetailsCode.IgnoreCase = False
        Me.ItemDetailsCode.Name = "ItemDetailsCode"
        Me.ItemDetailsCode.ReadOnly = True
        Me.ItemDetailsCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemDetailsCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.ItemDetailsCode.Translatable = False
        '
        'ItemDetailsName
        '
        Me.ItemDetailsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ItemDetailsName.BegFindValue = Nothing
        Me.ItemDetailsName.DataPropertyName = "ItemDetailsName"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.ItemDetailsName.DefaultCellStyle = DataGridViewCellStyle2
        Me.ItemDetailsName.EditingMode = False
        Me.ItemDetailsName.EndFindValue = Nothing
        Me.ItemDetailsName.FieldDescription = Nothing
        Me.ItemDetailsName.FieldName = Nothing
        Me.ItemDetailsName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.ItemDetailsName.FindEnabled = False
        Me.ItemDetailsName.HeaderText = "Medicine Name"
        Me.ItemDetailsName.IgnoreCase = False
        Me.ItemDetailsName.Name = "ItemDetailsName"
        Me.ItemDetailsName.ReadOnly = True
        Me.ItemDetailsName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemDetailsName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.ItemDetailsName.Translatable = False
        Me.ItemDetailsName.Width = 97
        '
        'GenericName
        '
        Me.GenericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.GenericName.BegFindValue = Nothing
        Me.GenericName.DataPropertyName = "GenericName"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.GenericName.DefaultCellStyle = DataGridViewCellStyle3
        Me.GenericName.EditingMode = False
        Me.GenericName.EndFindValue = Nothing
        Me.GenericName.FieldDescription = Nothing
        Me.GenericName.FieldName = Nothing
        Me.GenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.GenericName.FindEnabled = False
        Me.GenericName.HeaderText = "Generic Name"
        Me.GenericName.IgnoreCase = False
        Me.GenericName.Name = "GenericName"
        Me.GenericName.ReadOnly = True
        Me.GenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.GenericName.Translatable = False
        Me.GenericName.Width = 92
        '
        'GTin
        '
        Me.GTin.BegFindValue = Nothing
        Me.GTin.DataPropertyName = "GTin"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.GTin.DefaultCellStyle = DataGridViewCellStyle4
        Me.GTin.EditingMode = False
        Me.GTin.EndFindValue = Nothing
        Me.GTin.FieldDescription = Nothing
        Me.GTin.FieldName = Nothing
        Me.GTin.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.GTin.FindEnabled = False
        Me.GTin.HeaderText = "GTin"
        Me.GTin.IgnoreCase = False
        Me.GTin.Name = "GTin"
        Me.GTin.ReadOnly = True
        Me.GTin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GTin.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.GTin.Translatable = False
        '
        'IdNo
        '
        Me.IdNo.DataPropertyName = "IdNo"
        Me.IdNo.HeaderText = "IdNo"
        Me.IdNo.Name = "IdNo"
        Me.IdNo.Visible = False
        '
        'ItemDetailsFinder
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(984, 358)
        Me.Controls.Add(Me.txtFinder)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.DataGridViewItemDetails)
        Me.Name = "ItemDetailsFinder"
        Me.Text = "ItemDetailsFinder"
        CType(Me.DataGridViewItemDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsItemDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewItemDetails As DataGridView
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents bsItemDetails As BindingSource
    Friend WithEvents DataGridViewProductName As DataGridViewTextBoxColumn
    Friend WithEvents PurchaseDetailBindingSource As BindingSource
    Friend WithEvents PurchaseDetailTableAdapter As ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter
    Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
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
    Friend WithEvents txtFinder As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents ItemDetailsCode As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents ItemDetailsName As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents GenericName As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents GTin As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents IdNo As DataGridViewTextBoxColumn
End Class
