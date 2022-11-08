Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DrugSaleEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DrugSaleEntry))
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblManufactureDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblItemNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtItemNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSerializationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSerialNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBatchNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBatch = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblItem_Code = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItem_Code = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSaleDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpSaleDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblExpiry = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQrCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpExpiry = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.dtpManufactureDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnValidate = New AATM.Libraries.CBaseControlsLibrary.CButton()
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
            Me.TableLayoutPanel1.Controls.Add(Me.lblManufactureDate, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblItemNameEnglish, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtItemNameEnglish, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtSerializationNo, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtBatchNo, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblItem_Code, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtItem_Code, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSerialNo, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBatch, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGTIN, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGTIN, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSaleDate, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpSaleDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CButton1, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtQrCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpExpiry, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblExpiry, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpManufactureDate, 1, 7)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 11
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
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(641, 253)
            Me.TableLayoutPanel1.TabIndex = 5
            '
            'lblManufactureDate
            '
            Me.lblManufactureDate.AutoSize = True
            Me.lblManufactureDate.DisplayOnly = True
            Me.lblManufactureDate.EditingMode = False
            Me.lblManufactureDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblManufactureDate.Location = New System.Drawing.Point(1, 180)
            Me.lblManufactureDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblManufactureDate.Name = "lblManufactureDate"
            Me.lblManufactureDate.Size = New System.Drawing.Size(121, 17)
            Me.lblManufactureDate.TabIndex = 51
            Me.lblManufactureDate.Text = "Manufacture Date"
            Me.lblManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblManufactureDate.Translatable = True
            '
            'lblItemNameEnglish
            '
            Me.lblItemNameEnglish.AutoSize = True
            Me.lblItemNameEnglish.DisplayOnly = True
            Me.lblItemNameEnglish.EditingMode = False
            Me.lblItemNameEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItemNameEnglish.Location = New System.Drawing.Point(1, 130)
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
            Me.txtItemNameEnglish.Location = New System.Drawing.Point(174, 130)
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
            'txtSerializationNo
            '
            Me.txtSerializationNo.BackColor = System.Drawing.Color.White
            Me.txtSerializationNo.BegFindValue = Nothing
            Me.txtSerializationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerializationNo.ComputedValue = False
            Me.txtSerializationNo.CustomFormat = Nothing
            Me.txtSerializationNo.DataBoundControl = True
            Me.txtSerializationNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtSerializationNo.EditingMode = True
            Me.txtSerializationNo.EndFindValue = Nothing
            Me.txtSerializationNo.FieldDescription = Nothing
            Me.txtSerializationNo.FieldName = Nothing
            Me.txtSerializationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSerializationNo.FindEnabled = True
            Me.txtSerializationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSerializationNo.ForeColor = System.Drawing.Color.Black
            Me.txtSerializationNo.LinkedLabel = Me.lblSerialNo
            Me.txtSerializationNo.Location = New System.Drawing.Point(174, 226)
            Me.txtSerializationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSerializationNo.MaximumValue = Nothing
            Me.txtSerializationNo.MinimumValue = Nothing
            Me.txtSerializationNo.Name = "txtSerializationNo"
            Me.txtSerializationNo.OldValue = Nothing
            Me.txtSerializationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSerializationNo.Size = New System.Drawing.Size(148, 23)
            Me.txtSerializationNo.TabIndex = 7
            Me.txtSerializationNo.Translatable = False
            '
            'lblSerialNo
            '
            Me.lblSerialNo.AutoSize = True
            Me.lblSerialNo.DisplayOnly = True
            Me.lblSerialNo.EditingMode = False
            Me.lblSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSerialNo.Location = New System.Drawing.Point(1, 226)
            Me.lblSerialNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSerialNo.Name = "lblSerialNo"
            Me.lblSerialNo.Size = New System.Drawing.Size(139, 17)
            Me.lblSerialNo.TabIndex = 17
            Me.lblSerialNo.Text = "Serialization Number"
            Me.lblSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSerialNo.Translatable = True
            '
            'txtBatchNo
            '
            Me.txtBatchNo.BackColor = System.Drawing.Color.White
            Me.txtBatchNo.BegFindValue = Nothing
            Me.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBatchNo.ComputedValue = False
            Me.txtBatchNo.CustomFormat = Nothing
            Me.txtBatchNo.DataBoundControl = True
            Me.txtBatchNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtBatchNo.EditingMode = True
            Me.txtBatchNo.EndFindValue = Nothing
            Me.txtBatchNo.FieldDescription = Nothing
            Me.txtBatchNo.FieldName = Nothing
            Me.txtBatchNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBatchNo.FindEnabled = True
            Me.txtBatchNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBatchNo.ForeColor = System.Drawing.Color.Black
            Me.txtBatchNo.LinkedLabel = Me.lblBatch
            Me.txtBatchNo.Location = New System.Drawing.Point(174, 155)
            Me.txtBatchNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBatchNo.MaximumValue = Nothing
            Me.txtBatchNo.MinimumValue = Nothing
            Me.txtBatchNo.Name = "txtBatchNo"
            Me.txtBatchNo.OldValue = ""
            Me.txtBatchNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBatchNo.Size = New System.Drawing.Size(148, 23)
            Me.txtBatchNo.TabIndex = 5
            Me.txtBatchNo.Translatable = False
            '
            'lblBatch
            '
            Me.lblBatch.AutoSize = True
            Me.lblBatch.DisplayOnly = True
            Me.lblBatch.EditingMode = False
            Me.lblBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBatch.Location = New System.Drawing.Point(1, 155)
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
            Me.TxtIdNo.Location = New System.Drawing.Point(174, 49)
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
            Me.lblIdNo.Location = New System.Drawing.Point(1, 49)
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
            Me.lblItem_Code.Location = New System.Drawing.Point(1, 105)
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
            Me.TxtItem_Code.Location = New System.Drawing.Point(174, 105)
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
            'lblGTIN
            '
            Me.lblGTIN.AutoSize = True
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            Me.lblGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGTIN.Location = New System.Drawing.Point(1, 74)
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
            Me.txtGTIN.Location = New System.Drawing.Point(174, 74)
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
            'lblSaleDate
            '
            Me.lblSaleDate.AutoSize = True
            Me.lblSaleDate.DisplayOnly = True
            Me.lblSaleDate.EditingMode = False
            Me.lblSaleDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSaleDate.Location = New System.Drawing.Point(1, 26)
            Me.lblSaleDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSaleDate.Name = "lblSaleDate"
            Me.lblSaleDate.Size = New System.Drawing.Size(77, 17)
            Me.lblSaleDate.TabIndex = 46
            Me.lblSaleDate.Text = "Sales Date"
            Me.lblSaleDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSaleDate.Translatable = True
            '
            'dtpSaleDate
            '
            Me.dtpSaleDate.AutoSize = True
            Me.dtpSaleDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpSaleDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpSaleDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpSaleDate.DefaultValue = Nothing
            Me.dtpSaleDate.DisplayOnly = False
            Me.dtpSaleDate.DtpDefaultValue = Nothing
            Me.dtpSaleDate.EditingMode = True
            Me.dtpSaleDate.EditsAllowed = False
            Me.dtpSaleDate.ForeColor = System.Drawing.Color.Black
            Me.dtpSaleDate.LinkedLabel = Me.lblExpiry
            Me.dtpSaleDate.Location = New System.Drawing.Point(173, 25)
            Me.dtpSaleDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpSaleDate.Name = "dtpSaleDate"
            Me.dtpSaleDate.ReadOnlyDp = False
            Me.dtpSaleDate.SecurityKey = Nothing
            Me.dtpSaleDate.ShowLongDate = False
            Me.dtpSaleDate.ShowTime = False
            Me.dtpSaleDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpSaleDate.TabIndex = 47
            Me.dtpSaleDate.TargetCalendar = CType(resources.GetObject("dtpSaleDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpSaleDate.Translatable = False
            Me.dtpSaleDate.Value = Nothing
            Me.dtpSaleDate.ValueIsMandatory = False
            Me.dtpSaleDate.ValueIsNullable = False
            '
            'lblExpiry
            '
            Me.lblExpiry.AutoSize = True
            Me.lblExpiry.DisplayOnly = True
            Me.lblExpiry.EditingMode = False
            Me.lblExpiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExpiry.Location = New System.Drawing.Point(1, 203)
            Me.lblExpiry.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExpiry.Name = "lblExpiry"
            Me.lblExpiry.Size = New System.Drawing.Size(80, 17)
            Me.lblExpiry.TabIndex = 11
            Me.lblExpiry.Text = "Expiry Date"
            Me.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExpiry.Translatable = True
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Location = New System.Drawing.Point(326, 76)
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            Me.CButton1.Size = New System.Drawing.Size(126, 25)
            Me.CButton1.TabIndex = 48
            Me.CButton1.Text = "Scan QR Code"
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(97, 17)
            Me.CLabel1.TabIndex = 49
            Me.CLabel1.Text = "Scan Qr Code"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtQrCode
            '
            Me.txtQrCode.BackColor = System.Drawing.Color.White
            Me.txtQrCode.BegFindValue = Nothing
            Me.txtQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtQrCode, 2)
            Me.txtQrCode.ComputedValue = False
            Me.txtQrCode.CustomFormat = Nothing
            Me.txtQrCode.DataBoundControl = True
            Me.txtQrCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtQrCode.EditingMode = True
            Me.txtQrCode.EndFindValue = Nothing
            Me.txtQrCode.FieldDescription = Nothing
            Me.txtQrCode.FieldName = Nothing
            Me.txtQrCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQrCode.FindEnabled = False
            Me.txtQrCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtQrCode.ForeColor = System.Drawing.Color.Black
            Me.txtQrCode.LinkedLabel = Nothing
            Me.txtQrCode.Location = New System.Drawing.Point(174, 1)
            Me.txtQrCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQrCode.MaximumValue = Nothing
            Me.txtQrCode.MinimumValue = Nothing
            Me.txtQrCode.Name = "txtQrCode"
            Me.txtQrCode.OldValue = Nothing
            Me.txtQrCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQrCode.Size = New System.Drawing.Size(466, 23)
            Me.txtQrCode.TabIndex = 50
            Me.txtQrCode.Translatable = False
            '
            'dtpExpiry
            '
            Me.dtpExpiry.AutoSize = True
            Me.dtpExpiry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpExpiry.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpExpiry.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpExpiry.DefaultValue = Nothing
            Me.dtpExpiry.DisplayOnly = False
            Me.dtpExpiry.DtpDefaultValue = Nothing
            Me.dtpExpiry.EditingMode = True
            Me.dtpExpiry.EditsAllowed = False
            Me.dtpExpiry.ForeColor = System.Drawing.Color.Black
            Me.dtpExpiry.LinkedLabel = Me.lblExpiry
            Me.dtpExpiry.Location = New System.Drawing.Point(173, 202)
            Me.dtpExpiry.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpExpiry.Name = "dtpExpiry"
            Me.dtpExpiry.ReadOnlyDp = False
            Me.dtpExpiry.SecurityKey = Nothing
            Me.dtpExpiry.ShowLongDate = False
            Me.dtpExpiry.ShowTime = False
            Me.dtpExpiry.Size = New System.Drawing.Size(118, 23)
            Me.dtpExpiry.TabIndex = 45
            Me.dtpExpiry.TargetCalendar = CType(resources.GetObject("dtpExpiry.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpExpiry.Translatable = False
            Me.dtpExpiry.Value = Nothing
            Me.dtpExpiry.ValueIsMandatory = False
            Me.dtpExpiry.ValueIsNullable = False
            '
            'dtpManufactureDate
            '
            Me.dtpManufactureDate.AutoSize = True
            Me.dtpManufactureDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpManufactureDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpManufactureDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpManufactureDate.DefaultValue = Nothing
            Me.dtpManufactureDate.DisplayOnly = False
            Me.dtpManufactureDate.DtpDefaultValue = Nothing
            Me.dtpManufactureDate.EditingMode = True
            Me.dtpManufactureDate.EditsAllowed = False
            Me.dtpManufactureDate.ForeColor = System.Drawing.Color.Black
            Me.dtpManufactureDate.LinkedLabel = Me.lblManufactureDate
            Me.dtpManufactureDate.Location = New System.Drawing.Point(173, 179)
            Me.dtpManufactureDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpManufactureDate.Name = "dtpManufactureDate"
            Me.dtpManufactureDate.ReadOnlyDp = False
            Me.dtpManufactureDate.SecurityKey = Nothing
            Me.dtpManufactureDate.ShowLongDate = False
            Me.dtpManufactureDate.ShowTime = False
            Me.dtpManufactureDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpManufactureDate.TabIndex = 52
            Me.dtpManufactureDate.TargetCalendar = CType(resources.GetObject("dtpManufactureDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpManufactureDate.Translatable = False
            Me.dtpManufactureDate.Value = Nothing
            Me.dtpManufactureDate.ValueIsMandatory = False
            Me.dtpManufactureDate.ValueIsNullable = False
            '
            'CButton2
            '
            Me.CButton2.DesignerSelected = False
            Me.CButton2.ImageIndex = 0
            Me.CButton2.Location = New System.Drawing.Point(12, 316)
            Me.CButton2.Name = "CButton2"
            Me.CButton2.OriginalImageName = Nothing
            Me.CButton2.SecurityKey = ""
            Me.CButton2.Size = New System.Drawing.Size(126, 25)
            Me.CButton2.TabIndex = 54
            Me.CButton2.Text = "Clear Entry"
            '
            'btnValidate
            '
            Me.btnValidate.DesignerSelected = False
            Me.btnValidate.ImageIndex = 0
            Me.btnValidate.Location = New System.Drawing.Point(526, 316)
            Me.btnValidate.Name = "btnValidate"
            Me.btnValidate.OriginalImageName = Nothing
            Me.btnValidate.SecurityKey = ""
            Me.btnValidate.Size = New System.Drawing.Size(126, 25)
            Me.btnValidate.TabIndex = 55
            Me.btnValidate.Text = "Validate Entry"
            '
            'DrugSaleEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(663, 447)
            Me.Controls.Add(Me.btnValidate)
            Me.Controls.Add(Me.CButton2)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "DrugSaleEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            Me.Controls.SetChildIndex(Me.CButton2, 0)
            Me.Controls.SetChildIndex(Me.btnValidate, 0)
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
        Friend WithEvents txtBatchNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblExpiry As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblSerialNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblItemNameEnglish As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtItemNameEnglish As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtSerializationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents dtpExpiry As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblSaleDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpSaleDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CButton1 As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtQrCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblManufactureDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpManufactureDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CButton2 As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnValidate As Libraries.CBaseControlsLibrary.CButton
    End Class
End Namespace