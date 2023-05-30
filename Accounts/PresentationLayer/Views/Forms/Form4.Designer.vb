<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ISPDATADataSet = New AATM.Accounts.ISPDATADataSet()
        Me.PurchaseDetailModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtResult1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtResult2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtResult3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtResult4 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAwayFromZero = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblToNegativeInfinity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtResult5 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'txtValue
        '
        Me.txtValue.BackColor = System.Drawing.Color.White
        Me.txtValue.BegFindValue = Nothing
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValue.ComputedValue = False
        Me.txtValue.CustomFormat = Nothing
        Me.txtValue.DataBoundControl = True
        Me.txtValue.EditingMode = True
        Me.txtValue.EndFindValue = Nothing
        Me.txtValue.FieldDescription = Nothing
        Me.txtValue.FieldName = Nothing
        Me.txtValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtValue.FindEnabled = False
        Me.txtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtValue.ForeColor = System.Drawing.Color.Black
        Me.txtValue.LinkedLabel = Nothing
        Me.txtValue.Location = New System.Drawing.Point(252, 10)
        Me.txtValue.Margin = New System.Windows.Forms.Padding(1)
        Me.txtValue.MaximumValue = Nothing
        Me.txtValue.MinimumValue = Nothing
        Me.txtValue.Name = "txtValue"
        Me.txtValue.OldValue = Nothing
        Me.txtValue.OverrideMaxLength = 0
        Me.txtValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtValue.Size = New System.Drawing.Size(793, 23)
        Me.txtValue.TabIndex = 12
        Me.txtValue.Translatable = False
        '
        'CButton2
        '
        Me.CButton2.DesignerSelected = False
        Me.CButton2.ImageIndex = 0
        Me.CButton2.Location = New System.Drawing.Point(1049, 10)
        Me.CButton2.Name = "CButton2"
        Me.CButton2.OriginalImageName = Nothing
        Me.CButton2.SecurityKey = ""
        Me.CButton2.Size = New System.Drawing.Size(90, 25)
        Me.CButton2.TabIndex = 13
        Me.CButton2.Text = "CButton2"
        '
        'txtResult1
        '
        Me.txtResult1.BackColor = System.Drawing.Color.White
        Me.txtResult1.BegFindValue = Nothing
        Me.txtResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult1.ComputedValue = False
        Me.txtResult1.CustomFormat = Nothing
        Me.txtResult1.DataBoundControl = True
        Me.txtResult1.EditingMode = True
        Me.txtResult1.EndFindValue = Nothing
        Me.txtResult1.FieldDescription = Nothing
        Me.txtResult1.FieldName = Nothing
        Me.txtResult1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtResult1.FindEnabled = False
        Me.txtResult1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtResult1.ForeColor = System.Drawing.Color.Black
        Me.txtResult1.LinkedLabel = Nothing
        Me.txtResult1.Location = New System.Drawing.Point(252, 35)
        Me.txtResult1.Margin = New System.Windows.Forms.Padding(1)
        Me.txtResult1.MaximumValue = Nothing
        Me.txtResult1.MinimumValue = Nothing
        Me.txtResult1.Name = "txtResult1"
        Me.txtResult1.OldValue = Nothing
        Me.txtResult1.OverrideMaxLength = 0
        Me.txtResult1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtResult1.Size = New System.Drawing.Size(130, 23)
        Me.txtResult1.TabIndex = 14
        Me.txtResult1.Translatable = False
        '
        'txtResult2
        '
        Me.txtResult2.BackColor = System.Drawing.Color.White
        Me.txtResult2.BegFindValue = Nothing
        Me.txtResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult2.ComputedValue = False
        Me.txtResult2.CustomFormat = Nothing
        Me.txtResult2.DataBoundControl = True
        Me.txtResult2.EditingMode = True
        Me.txtResult2.EndFindValue = Nothing
        Me.txtResult2.FieldDescription = Nothing
        Me.txtResult2.FieldName = Nothing
        Me.txtResult2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtResult2.FindEnabled = False
        Me.txtResult2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtResult2.ForeColor = System.Drawing.Color.Black
        Me.txtResult2.LinkedLabel = Nothing
        Me.txtResult2.Location = New System.Drawing.Point(396, 35)
        Me.txtResult2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtResult2.MaximumValue = Nothing
        Me.txtResult2.MinimumValue = Nothing
        Me.txtResult2.Name = "txtResult2"
        Me.txtResult2.OldValue = Nothing
        Me.txtResult2.OverrideMaxLength = 0
        Me.txtResult2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtResult2.Size = New System.Drawing.Size(130, 23)
        Me.txtResult2.TabIndex = 15
        Me.txtResult2.Translatable = False
        '
        'txtResult3
        '
        Me.txtResult3.BackColor = System.Drawing.Color.White
        Me.txtResult3.BegFindValue = Nothing
        Me.txtResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult3.ComputedValue = False
        Me.txtResult3.CustomFormat = Nothing
        Me.txtResult3.DataBoundControl = True
        Me.txtResult3.EditingMode = True
        Me.txtResult3.EndFindValue = Nothing
        Me.txtResult3.FieldDescription = Nothing
        Me.txtResult3.FieldName = Nothing
        Me.txtResult3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtResult3.FindEnabled = False
        Me.txtResult3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtResult3.ForeColor = System.Drawing.Color.Black
        Me.txtResult3.LinkedLabel = Nothing
        Me.txtResult3.Location = New System.Drawing.Point(540, 35)
        Me.txtResult3.Margin = New System.Windows.Forms.Padding(1)
        Me.txtResult3.MaximumValue = Nothing
        Me.txtResult3.MinimumValue = Nothing
        Me.txtResult3.Name = "txtResult3"
        Me.txtResult3.OldValue = Nothing
        Me.txtResult3.OverrideMaxLength = 0
        Me.txtResult3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtResult3.Size = New System.Drawing.Size(130, 23)
        Me.txtResult3.TabIndex = 16
        Me.txtResult3.Translatable = False
        '
        'txtResult4
        '
        Me.txtResult4.BackColor = System.Drawing.Color.White
        Me.txtResult4.BegFindValue = Nothing
        Me.txtResult4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult4.ComputedValue = False
        Me.txtResult4.CustomFormat = Nothing
        Me.txtResult4.DataBoundControl = True
        Me.txtResult4.EditingMode = True
        Me.txtResult4.EndFindValue = Nothing
        Me.txtResult4.FieldDescription = Nothing
        Me.txtResult4.FieldName = Nothing
        Me.txtResult4.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtResult4.FindEnabled = False
        Me.txtResult4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtResult4.ForeColor = System.Drawing.Color.Black
        Me.txtResult4.LinkedLabel = Nothing
        Me.txtResult4.Location = New System.Drawing.Point(686, 35)
        Me.txtResult4.Margin = New System.Windows.Forms.Padding(1)
        Me.txtResult4.MaximumValue = Nothing
        Me.txtResult4.MinimumValue = Nothing
        Me.txtResult4.Name = "txtResult4"
        Me.txtResult4.OldValue = Nothing
        Me.txtResult4.OverrideMaxLength = 0
        Me.txtResult4.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtResult4.Size = New System.Drawing.Size(130, 23)
        Me.txtResult4.TabIndex = 17
        Me.txtResult4.Translatable = False
        '
        'lblAwayFromZero
        '
        Me.lblAwayFromZero.AutoSize = True
        Me.lblAwayFromZero.DisplayOnly = True
        Me.lblAwayFromZero.EditingMode = False
        Me.lblAwayFromZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblAwayFromZero.Location = New System.Drawing.Point(249, 60)
        Me.lblAwayFromZero.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAwayFromZero.Name = "lblAwayFromZero"
        Me.lblAwayFromZero.Size = New System.Drawing.Size(103, 17)
        Me.lblAwayFromZero.TabIndex = 18
        Me.lblAwayFromZero.Text = "AwayFromZero"
        Me.lblAwayFromZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAwayFromZero.Translatable = True
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = True
        Me.CLabel5.DisplayOnly = True
        Me.CLabel5.EditingMode = False
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel5.Location = New System.Drawing.Point(393, 60)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(57, 17)
        Me.CLabel5.TabIndex = 19
        Me.CLabel5.Text = "ToEven"
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel5.Translatable = True
        '
        'lblToNegativeInfinity
        '
        Me.lblToNegativeInfinity.AutoSize = True
        Me.lblToNegativeInfinity.DisplayOnly = True
        Me.lblToNegativeInfinity.EditingMode = False
        Me.lblToNegativeInfinity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblToNegativeInfinity.Location = New System.Drawing.Point(537, 60)
        Me.lblToNegativeInfinity.Margin = New System.Windows.Forms.Padding(1)
        Me.lblToNegativeInfinity.Name = "lblToNegativeInfinity"
        Me.lblToNegativeInfinity.Size = New System.Drawing.Size(50, 17)
        Me.lblToNegativeInfinity.TabIndex = 20
        Me.lblToNegativeInfinity.Text = "Ceiling"
        Me.lblToNegativeInfinity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblToNegativeInfinity.Translatable = True
        '
        'CLabel7
        '
        Me.CLabel7.AutoSize = True
        Me.CLabel7.DisplayOnly = True
        Me.CLabel7.EditingMode = False
        Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel7.Location = New System.Drawing.Point(683, 60)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.Size = New System.Drawing.Size(40, 17)
        Me.CLabel7.TabIndex = 21
        Me.CLabel7.Text = "Floor"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel7.Translatable = True
        '
        'txtResult5
        '
        Me.txtResult5.BackColor = System.Drawing.Color.White
        Me.txtResult5.BegFindValue = Nothing
        Me.txtResult5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult5.ComputedValue = False
        Me.txtResult5.CustomFormat = Nothing
        Me.txtResult5.DataBoundControl = True
        Me.txtResult5.EditingMode = True
        Me.txtResult5.EndFindValue = Nothing
        Me.txtResult5.FieldDescription = Nothing
        Me.txtResult5.FieldName = Nothing
        Me.txtResult5.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtResult5.FindEnabled = False
        Me.txtResult5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtResult5.ForeColor = System.Drawing.Color.Black
        Me.txtResult5.LinkedLabel = Nothing
        Me.txtResult5.Location = New System.Drawing.Point(834, 35)
        Me.txtResult5.Margin = New System.Windows.Forms.Padding(1)
        Me.txtResult5.MaximumValue = Nothing
        Me.txtResult5.MinimumValue = Nothing
        Me.txtResult5.Name = "txtResult5"
        Me.txtResult5.OldValue = Nothing
        Me.txtResult5.OverrideMaxLength = 0
        Me.txtResult5.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtResult5.Size = New System.Drawing.Size(130, 23)
        Me.txtResult5.TabIndex = 22
        Me.txtResult5.Translatable = False
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = True
        Me.CLabel4.DisplayOnly = True
        Me.CLabel4.EditingMode = False
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel4.Location = New System.Drawing.Point(831, 60)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(88, 17)
        Me.CLabel4.TabIndex = 23
        Me.CLabel4.Text = "NotRounded"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel4.Translatable = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1809, 621)
        Me.Controls.Add(Me.CLabel4)
        Me.Controls.Add(Me.txtResult5)
        Me.Controls.Add(Me.CLabel7)
        Me.Controls.Add(Me.lblToNegativeInfinity)
        Me.Controls.Add(Me.CLabel5)
        Me.Controls.Add(Me.lblAwayFromZero)
        Me.Controls.Add(Me.txtResult4)
        Me.Controls.Add(Me.txtResult3)
        Me.Controls.Add(Me.txtResult2)
        Me.Controls.Add(Me.txtResult1)
        Me.Controls.Add(Me.CButton2)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ISPDATADataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailModelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductBindingSource1 As BindingSource
    Friend WithEvents DataGridViewProductName As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PurchaseDetailModelBindingSource As BindingSource
    Friend WithEvents ISPDATADataSet As ISPDATADataSet
    Friend WithEvents PurchaseDetailBindingSource As BindingSource
    Friend WithEvents PurchaseDetailTableAdapter As ISPDATADataSetTableAdapters.PurchaseDetailTableAdapter
    Friend WithEvents ProductBindingSource As BindingSource
    Friend WithEvents ProductTableAdapter As ISPDATADataSetTableAdapters.ProductTableAdapter
    Friend WithEvents DgProductName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents txtValue As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CButton2 As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents txtResult1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents txtResult2 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents txtResult3 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents txtResult4 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblAwayFromZero As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents lblToNegativeInfinity As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtResult5 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
End Class
