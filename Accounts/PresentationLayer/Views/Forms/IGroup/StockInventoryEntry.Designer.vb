Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StockInventoryEntry
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
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblItemNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtItemNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtCashPrice = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCashPrice = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSerialNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSerialNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPurchaseNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPurchaseNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBatch = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBatch = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblItem_Code = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItem_Code = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblQuantity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblExpiry = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQuantity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtExpiry = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboItemFinder = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtBranchId = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblItemNameEnglish, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtItemNameEnglish, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtCashPrice, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtSerialNo, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPurchaseNo, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtBatch, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblItem_Code, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtItem_Code, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPurchaseNo, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblQuantity, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCashPrice, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSerialNo, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblExpiry, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBatch, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtQuantity, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtExpiry, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGTIN, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGTIN, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboItemFinder, 3, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 10
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(641, 254)
            Me.TableLayoutPanel1.TabIndex = 5
            '
            'lblItemNameEnglish
            '
            Me.lblItemNameEnglish.AutoSize = True
            Me.lblItemNameEnglish.DisplayOnly = True
            Me.lblItemNameEnglish.EditingMode = False
            Me.lblItemNameEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItemNameEnglish.Location = New System.Drawing.Point(1, 77)
            Me.lblItemNameEnglish.Margin = New System.Windows.Forms.Padding(1)
            Me.lblItemNameEnglish.Name = "lblItemNameEnglish"
            Me.lblItemNameEnglish.Size = New System.Drawing.Size(75, 17)
            Me.lblItemNameEnglish.TabIndex = 42
            Me.lblItemNameEnglish.Text = "Item Name"
            Me.lblItemNameEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItemNameEnglish.Translatable = True
            '
            'txtItemNameEnglish
            '
            Me.txtItemNameEnglish.BackColor = System.Drawing.Color.White
            Me.txtItemNameEnglish.BegFindValue = Nothing
            Me.txtItemNameEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtItemNameEnglish, 2)
            Me.txtItemNameEnglish.ComputedValue = False
            Me.txtItemNameEnglish.CustomFormat = Nothing
            Me.txtItemNameEnglish.DataBoundControl = True
            Me.txtItemNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtItemNameEnglish.EditingMode = True
            Me.txtItemNameEnglish.EndFindValue = Nothing
            Me.txtItemNameEnglish.FieldDescription = Nothing
            Me.txtItemNameEnglish.FieldName = Nothing
            Me.txtItemNameEnglish.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtItemNameEnglish.FindEnabled = True
            Me.txtItemNameEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtItemNameEnglish.ForeColor = System.Drawing.Color.Black
            Me.txtItemNameEnglish.LinkedLabel = Me.lblItemNameEnglish
            Me.txtItemNameEnglish.Location = New System.Drawing.Point(174, 77)
            Me.txtItemNameEnglish.Margin = New System.Windows.Forms.Padding(1)
            Me.txtItemNameEnglish.MaximumValue = Nothing
            Me.txtItemNameEnglish.MinimumValue = Nothing
            Me.txtItemNameEnglish.Name = "txtItemNameEnglish"
            Me.txtItemNameEnglish.OldValue = Nothing
            Me.txtItemNameEnglish.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtItemNameEnglish.Size = New System.Drawing.Size(466, 23)
            Me.txtItemNameEnglish.TabIndex = 4
            Me.txtItemNameEnglish.Translatable = False
            '
            'txtCashPrice
            '
            Me.txtCashPrice.BackColor = System.Drawing.Color.White
            Me.txtCashPrice.BegFindValue = Nothing
            Me.txtCashPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCashPrice.ComputedValue = False
            Me.txtCashPrice.CustomFormat = Nothing
            Me.txtCashPrice.DataBoundControl = True
            Me.txtCashPrice.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtCashPrice.EditingMode = True
            Me.txtCashPrice.EndFindValue = Nothing
            Me.txtCashPrice.FieldDescription = Nothing
            Me.txtCashPrice.FieldName = Nothing
            Me.txtCashPrice.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCashPrice.FindEnabled = True
            Me.txtCashPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCashPrice.ForeColor = System.Drawing.Color.Black
            Me.txtCashPrice.LinkedLabel = Me.lblCashPrice
            Me.txtCashPrice.Location = New System.Drawing.Point(174, 177)
            Me.txtCashPrice.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCashPrice.MaximumValue = Nothing
            Me.txtCashPrice.MinimumValue = Nothing
            Me.txtCashPrice.Name = "txtCashPrice"
            Me.txtCashPrice.OldValue = Nothing
            Me.txtCashPrice.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCashPrice.Size = New System.Drawing.Size(148, 23)
            Me.txtCashPrice.TabIndex = 8
            Me.txtCashPrice.Translatable = False
            '
            'lblCashPrice
            '
            Me.lblCashPrice.AutoSize = True
            Me.lblCashPrice.DisplayOnly = True
            Me.lblCashPrice.EditingMode = False
            Me.lblCashPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCashPrice.Location = New System.Drawing.Point(1, 177)
            Me.lblCashPrice.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCashPrice.Name = "lblCashPrice"
            Me.lblCashPrice.Size = New System.Drawing.Size(86, 17)
            Me.lblCashPrice.TabIndex = 29
            Me.lblCashPrice.Text = "Selling Price"
            Me.lblCashPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCashPrice.Translatable = True
            '
            'txtSerialNo
            '
            Me.txtSerialNo.BackColor = System.Drawing.Color.White
            Me.txtSerialNo.BegFindValue = Nothing
            Me.txtSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerialNo.ComputedValue = False
            Me.txtSerialNo.CustomFormat = Nothing
            Me.txtSerialNo.DataBoundControl = True
            Me.txtSerialNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtSerialNo.EditingMode = True
            Me.txtSerialNo.EndFindValue = Nothing
            Me.txtSerialNo.FieldDescription = Nothing
            Me.txtSerialNo.FieldName = Nothing
            Me.txtSerialNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSerialNo.FindEnabled = True
            Me.txtSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSerialNo.ForeColor = System.Drawing.Color.Black
            Me.txtSerialNo.LinkedLabel = Me.lblSerialNo
            Me.txtSerialNo.Location = New System.Drawing.Point(174, 152)
            Me.txtSerialNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSerialNo.MaximumValue = Nothing
            Me.txtSerialNo.MinimumValue = Nothing
            Me.txtSerialNo.Name = "txtSerialNo"
            Me.txtSerialNo.OldValue = Nothing
            Me.txtSerialNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSerialNo.Size = New System.Drawing.Size(148, 23)
            Me.txtSerialNo.TabIndex = 7
            Me.txtSerialNo.Translatable = False
            '
            'lblSerialNo
            '
            Me.lblSerialNo.AutoSize = True
            Me.lblSerialNo.DisplayOnly = True
            Me.lblSerialNo.EditingMode = False
            Me.lblSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSerialNo.Location = New System.Drawing.Point(1, 152)
            Me.lblSerialNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSerialNo.Name = "lblSerialNo"
            Me.lblSerialNo.Size = New System.Drawing.Size(139, 17)
            Me.lblSerialNo.TabIndex = 17
            Me.lblSerialNo.Text = "Serialization Number"
            Me.lblSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSerialNo.Translatable = True
            '
            'txtPurchaseNo
            '
            Me.txtPurchaseNo.BackColor = System.Drawing.Color.White
            Me.txtPurchaseNo.BegFindValue = Nothing
            Me.txtPurchaseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPurchaseNo.ComputedValue = False
            Me.txtPurchaseNo.CustomFormat = Nothing
            Me.txtPurchaseNo.DataBoundControl = True
            Me.txtPurchaseNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPurchaseNo.EditingMode = True
            Me.txtPurchaseNo.EndFindValue = Nothing
            Me.txtPurchaseNo.FieldDescription = Nothing
            Me.txtPurchaseNo.FieldName = Nothing
            Me.txtPurchaseNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPurchaseNo.FindEnabled = True
            Me.txtPurchaseNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPurchaseNo.ForeColor = System.Drawing.Color.Black
            Me.txtPurchaseNo.LinkedLabel = Me.lblPurchaseNo
            Me.txtPurchaseNo.Location = New System.Drawing.Point(174, 227)
            Me.txtPurchaseNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPurchaseNo.MaximumValue = Nothing
            Me.txtPurchaseNo.MinimumValue = Nothing
            Me.txtPurchaseNo.Name = "txtPurchaseNo"
            Me.txtPurchaseNo.OldValue = Nothing
            Me.txtPurchaseNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPurchaseNo.Size = New System.Drawing.Size(148, 23)
            Me.txtPurchaseNo.TabIndex = 10
            Me.txtPurchaseNo.Translatable = False
            '
            'lblPurchaseNo
            '
            Me.lblPurchaseNo.AutoSize = True
            Me.lblPurchaseNo.DisplayOnly = True
            Me.lblPurchaseNo.EditingMode = False
            Me.lblPurchaseNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPurchaseNo.Location = New System.Drawing.Point(1, 227)
            Me.lblPurchaseNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPurchaseNo.Name = "lblPurchaseNo"
            Me.lblPurchaseNo.Size = New System.Drawing.Size(122, 17)
            Me.lblPurchaseNo.TabIndex = 21
            Me.lblPurchaseNo.Text = "Purchase Number"
            Me.lblPurchaseNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPurchaseNo.Translatable = True
            '
            'txtBatch
            '
            Me.txtBatch.BackColor = System.Drawing.Color.White
            Me.txtBatch.BegFindValue = Nothing
            Me.txtBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBatch.ComputedValue = False
            Me.txtBatch.CustomFormat = Nothing
            Me.txtBatch.DataBoundControl = True
            Me.txtBatch.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtBatch.EditingMode = True
            Me.txtBatch.EndFindValue = Nothing
            Me.txtBatch.FieldDescription = Nothing
            Me.txtBatch.FieldName = Nothing
            Me.txtBatch.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBatch.FindEnabled = True
            Me.txtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBatch.ForeColor = System.Drawing.Color.Black
            Me.txtBatch.LinkedLabel = Me.lblBatch
            Me.txtBatch.Location = New System.Drawing.Point(174, 102)
            Me.txtBatch.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBatch.MaximumValue = Nothing
            Me.txtBatch.MinimumValue = Nothing
            Me.txtBatch.Name = "txtBatch"
            Me.txtBatch.OldValue = ""
            Me.txtBatch.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBatch.Size = New System.Drawing.Size(148, 23)
            Me.txtBatch.TabIndex = 5
            Me.txtBatch.Translatable = False
            '
            'lblBatch
            '
            Me.lblBatch.AutoSize = True
            Me.lblBatch.DisplayOnly = True
            Me.lblBatch.EditingMode = False
            Me.lblBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBatch.Location = New System.Drawing.Point(1, 102)
            Me.lblBatch.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBatch.Name = "lblBatch"
            Me.lblBatch.Size = New System.Drawing.Size(98, 17)
            Me.lblBatch.TabIndex = 4
            Me.lblBatch.Text = "Batch Number"
            Me.lblBatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBatch.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(174, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = ""
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(148, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.AutoSize = True
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(83, 17)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblItem_Code
            '
            Me.lblItem_Code.AutoSize = True
            Me.lblItem_Code.DisplayOnly = True
            Me.lblItem_Code.EditingMode = False
            Me.lblItem_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItem_Code.Location = New System.Drawing.Point(1, 52)
            Me.lblItem_Code.Margin = New System.Windows.Forms.Padding(1)
            Me.lblItem_Code.Name = "lblItem_Code"
            Me.lblItem_Code.Size = New System.Drawing.Size(71, 17)
            Me.lblItem_Code.TabIndex = 2
            Me.lblItem_Code.Text = "Item Code"
            Me.lblItem_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItem_Code.Translatable = True
            '
            'TxtItem_Code
            '
            Me.TxtItem_Code.BackColor = System.Drawing.Color.White
            Me.TxtItem_Code.BegFindValue = Nothing
            Me.TxtItem_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItem_Code.ComputedValue = False
            Me.TxtItem_Code.CustomFormat = Nothing
            Me.TxtItem_Code.DataBoundControl = True
            Me.TxtItem_Code.DisplayOnly = True
            Me.TxtItem_Code.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtItem_Code.EditingMode = True
            Me.TxtItem_Code.EndFindValue = Nothing
            Me.TxtItem_Code.FieldDescription = Nothing
            Me.TxtItem_Code.FieldName = "Item_Code"
            Me.TxtItem_Code.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItem_Code.FindEnabled = True
            Me.TxtItem_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItem_Code.ForeColor = System.Drawing.Color.Black
            Me.TxtItem_Code.LinkedLabel = Me.lblItem_Code
            Me.TxtItem_Code.Location = New System.Drawing.Point(174, 52)
            Me.TxtItem_Code.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItem_Code.MaximumValue = Nothing
            Me.TxtItem_Code.MinimumValue = Nothing
            Me.TxtItem_Code.Name = "TxtItem_Code"
            Me.TxtItem_Code.OldValue = Nothing
            Me.TxtItem_Code.ReadOnly = True
            Me.TxtItem_Code.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItem_Code.Size = New System.Drawing.Size(148, 23)
            Me.TxtItem_Code.TabIndex = 3
            Me.TxtItem_Code.Translatable = False
            '
            'lblQuantity
            '
            Me.lblQuantity.AutoSize = True
            Me.lblQuantity.DisplayOnly = True
            Me.lblQuantity.EditingMode = False
            Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQuantity.Location = New System.Drawing.Point(1, 202)
            Me.lblQuantity.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQuantity.Name = "lblQuantity"
            Me.lblQuantity.Size = New System.Drawing.Size(61, 17)
            Me.lblQuantity.TabIndex = 19
            Me.lblQuantity.Text = "Quantity"
            Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblQuantity.Translatable = True
            '
            'lblExpiry
            '
            Me.lblExpiry.AutoSize = True
            Me.lblExpiry.DisplayOnly = True
            Me.lblExpiry.EditingMode = False
            Me.lblExpiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExpiry.Location = New System.Drawing.Point(1, 127)
            Me.lblExpiry.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExpiry.Name = "lblExpiry"
            Me.lblExpiry.Size = New System.Drawing.Size(80, 17)
            Me.lblExpiry.TabIndex = 11
            Me.lblExpiry.Text = "Expiry Date"
            Me.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExpiry.Translatable = True
            '
            'txtQuantity
            '
            Me.txtQuantity.BackColor = System.Drawing.Color.White
            Me.txtQuantity.BegFindValue = Nothing
            Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQuantity.ComputedValue = False
            Me.txtQuantity.CustomFormat = Nothing
            Me.txtQuantity.DataBoundControl = True
            Me.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtQuantity.EditingMode = True
            Me.txtQuantity.EndFindValue = Nothing
            Me.txtQuantity.FieldDescription = Nothing
            Me.txtQuantity.FieldName = Nothing
            Me.txtQuantity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQuantity.FindEnabled = True
            Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtQuantity.ForeColor = System.Drawing.Color.Black
            Me.txtQuantity.LinkedLabel = Me.lblQuantity
            Me.txtQuantity.Location = New System.Drawing.Point(174, 202)
            Me.txtQuantity.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQuantity.MaximumValue = Nothing
            Me.txtQuantity.MinimumValue = Nothing
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.OldValue = Nothing
            Me.txtQuantity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQuantity.Size = New System.Drawing.Size(148, 23)
            Me.txtQuantity.TabIndex = 9
            Me.txtQuantity.Translatable = False
            '
            'txtExpiry
            '
            Me.txtExpiry.BackColor = System.Drawing.Color.White
            Me.txtExpiry.BegFindValue = Nothing
            Me.txtExpiry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtExpiry.ComputedValue = False
            Me.txtExpiry.CustomFormat = Nothing
            Me.txtExpiry.DataBoundControl = True
            Me.txtExpiry.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtExpiry.EditingMode = True
            Me.txtExpiry.EndFindValue = Nothing
            Me.txtExpiry.FieldDescription = Nothing
            Me.txtExpiry.FieldName = Nothing
            Me.txtExpiry.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtExpiry.FindEnabled = True
            Me.txtExpiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtExpiry.ForeColor = System.Drawing.Color.Black
            Me.txtExpiry.LinkedLabel = Me.lblExpiry
            Me.txtExpiry.Location = New System.Drawing.Point(174, 127)
            Me.txtExpiry.Margin = New System.Windows.Forms.Padding(1)
            Me.txtExpiry.MaximumValue = Nothing
            Me.txtExpiry.MinimumValue = Nothing
            Me.txtExpiry.Name = "txtExpiry"
            Me.txtExpiry.OldValue = Nothing
            Me.txtExpiry.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtExpiry.Size = New System.Drawing.Size(148, 23)
            Me.txtExpiry.TabIndex = 6
            Me.txtExpiry.Translatable = False
            '
            'lblGTIN
            '
            Me.lblGTIN.AutoSize = True
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            Me.lblGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGTIN.Location = New System.Drawing.Point(1, 27)
            Me.lblGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGTIN.Name = "lblGTIN"
            Me.lblGTIN.Size = New System.Drawing.Size(41, 17)
            Me.lblGTIN.TabIndex = 36
            Me.lblGTIN.Text = "GTIN"
            Me.lblGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGTIN.Translatable = True
            '
            'txtGTIN
            '
            Me.txtGTIN.BackColor = System.Drawing.Color.White
            Me.txtGTIN.BegFindValue = Nothing
            Me.txtGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGTIN.ComputedValue = False
            Me.txtGTIN.CustomFormat = Nothing
            Me.txtGTIN.DataBoundControl = True
            Me.txtGTIN.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Me.lblGTIN
            Me.txtGTIN.Location = New System.Drawing.Point(174, 27)
            Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = ""
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Size = New System.Drawing.Size(148, 23)
            Me.txtGTIN.TabIndex = 2
            Me.txtGTIN.Translatable = False
            '
            'cboItemFinder
            '
            Me.cboItemFinder.BackColor = System.Drawing.Color.White
            Me.cboItemFinder.BegFindValue = Nothing
            Me.cboItemFinder.ChangingSearchValueOnly = False
            Me.cboItemFinder.CurrentSearchTerm = ""
            Me.cboItemFinder.DataValue = Nothing
            Me.cboItemFinder.DefaultValue = Nothing
            Me.cboItemFinder.DisplayMember = "Name"
            Me.cboItemFinder.EditingMode = True
            Me.cboItemFinder.EndFindValue = Nothing
            Me.cboItemFinder.FieldDescription = Nothing
            Me.cboItemFinder.FieldName = Nothing
            Me.cboItemFinder.FilterRule = Nothing
            Me.cboItemFinder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboItemFinder.FindEnabled = True
            Me.cboItemFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboItemFinder.ForeColor = System.Drawing.Color.Black
            Me.cboItemFinder.FormattingEnabled = True
            Me.cboItemFinder.HideWhenNotEditingOrAdding = False
            Me.cboItemFinder.IgnoreCase = False
            Me.cboItemFinder.IntegralHeight = False
            Me.cboItemFinder.LinkedLabel = Nothing
            Me.cboItemFinder.Location = New System.Drawing.Point(324, 1)
            Me.cboItemFinder.Margin = New System.Windows.Forms.Padding(1)
            Me.cboItemFinder.Name = "cboItemFinder"
            Me.cboItemFinder.OldValue = 0
            Me.cboItemFinder.OriginalDataSource = Nothing
            Me.cboItemFinder.OriginalList = Nothing
            Me.cboItemFinder.OverrideDropDownStyleList = False
            Me.cboItemFinder.PreviousSearchTerm = Nothing
            Me.cboItemFinder.PropertySelector = Nothing
            Me.cboItemFinder.ReadOnlyCombo = False
            Me.cboItemFinder.Size = New System.Drawing.Size(316, 24)
            Me.cboItemFinder.SuggestBoxHeight = 200
            Me.cboItemFinder.SuggestListOrderRule = Nothing
            Me.cboItemFinder.TabIndex = 11
            Me.cboItemFinder.TextToSearch = Nothing
            Me.cboItemFinder.Translatable = False
            Me.cboItemFinder.ValueIsMandatory = False
            Me.cboItemFinder.ValueIsNullable = False
            Me.cboItemFinder.ValueIsNumeric = False
            Me.cboItemFinder.ValueMember = "Name"
            '
            'txtBranchId
            '
            Me.txtBranchId.BackColor = System.Drawing.Color.White
            Me.txtBranchId.BegFindValue = Nothing
            Me.txtBranchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchId.ComputedValue = False
            Me.txtBranchId.CustomFormat = Nothing
            Me.txtBranchId.DataBoundControl = True
            Me.txtBranchId.EditingMode = True
            Me.txtBranchId.EndFindValue = Nothing
            Me.txtBranchId.FieldDescription = Nothing
            Me.txtBranchId.FieldName = Nothing
            Me.txtBranchId.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchId.FindEnabled = True
            Me.txtBranchId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBranchId.ForeColor = System.Drawing.Color.Black
            Me.txtBranchId.LinkedLabel = Me.lblGTIN
            Me.txtBranchId.Location = New System.Drawing.Point(12, 315)
            Me.txtBranchId.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBranchId.MaximumValue = Nothing
            Me.txtBranchId.MinimumValue = Nothing
            Me.txtBranchId.Name = "txtBranchId"
            Me.txtBranchId.OldValue = ""
            Me.txtBranchId.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchId.Size = New System.Drawing.Size(171, 23)
            Me.txtBranchId.TabIndex = 44
            Me.txtBranchId.Translatable = False
            Me.txtBranchId.Visible = False
            '
            'StockInventoryEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(663, 526)
            Me.Controls.Add(Me.txtBranchId)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "StockInventoryEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            Me.Controls.SetChildIndex(Me.txtBranchId, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblItem_Code As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBatch As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItem_Code As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtExpiry As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtBatch As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblExpiry As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPurchaseNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblQuantity As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblSerialNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtQuantity As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboItemFinder As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblItemNameEnglish As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtItemNameEnglish As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtSerialNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPurchaseNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtCashPrice As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCashPrice As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBranchId As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace