Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ItemDetailsEntry
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
        Me.txtPrice_Cash = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPack1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtpack2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtpack3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtQtyOnHand = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.txtGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtItemDetailsCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtItemDetailsName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboPackageSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPackageType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDosageForm = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblGenericName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPackageSize = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboPackageType = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.cboUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.txtVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboDosageForm = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.cboUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.txtStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.chkPrescriptionDrug = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblRegistrationCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboItemFinder = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.btnScanQrCode = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.EventLog1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtPrice_Cash, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPack1, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtpack2, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtpack3, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtQtyOnHand, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboRouteOfAdministration, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGenericName, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtItemDetailsCode, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtItemDetailsName, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPackageSize, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPackageType, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUnitOfVolume, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVolume, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDosageForm, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUnitOfStrength, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGenericName, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPackageSize, 1, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPackageType, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.cboUnitOfVolume, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtVolume, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDosageForm, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cboUnitOfStrength, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStrengthValue, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPrescriptionDrug, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRegistrationNo, 1, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRegistrationCode, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGTIN, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGTIN, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboItemFinder, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnScanQrCode, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 3, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 17
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(611, 379)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'txtPrice_Cash
        '
        Me.txtPrice_Cash.BackColor = System.Drawing.Color.White
        Me.txtPrice_Cash.BegFindValue = Nothing
        Me.txtPrice_Cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPrice_Cash, 4)
        Me.txtPrice_Cash.ComputedValue = false
        Me.txtPrice_Cash.CustomFormat = Nothing
        Me.txtPrice_Cash.DataBoundControl = true
        Me.txtPrice_Cash.DisplayOnly = true
        Me.txtPrice_Cash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPrice_Cash.EditingMode = false
        Me.txtPrice_Cash.EndFindValue = Nothing
        Me.txtPrice_Cash.FieldDescription = Nothing
        Me.txtPrice_Cash.FieldName = "Item_Code"
        Me.txtPrice_Cash.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPrice_Cash.FindEnabled = true
        Me.txtPrice_Cash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPrice_Cash.ForeColor = System.Drawing.Color.Black
        Me.txtPrice_Cash.LinkedLabel = Nothing
        Me.txtPrice_Cash.Location = New System.Drawing.Point(444, 97)
        Me.txtPrice_Cash.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPrice_Cash.MaximumValue = Nothing
        Me.txtPrice_Cash.MinimumValue = Nothing
        Me.txtPrice_Cash.Name = "txtPrice_Cash"
        Me.txtPrice_Cash.OldValue = Nothing
        Me.txtPrice_Cash.ReadOnly = true
        Me.txtPrice_Cash.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPrice_Cash.Size = New System.Drawing.Size(166, 23)
        Me.txtPrice_Cash.TabIndex = 80
        Me.txtPrice_Cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPrice_Cash.Translatable = false
        '
        'CLabel6
        '
        Me.CLabel6.AutoSize = true
        Me.CLabel6.DisplayOnly = true
        Me.CLabel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.CLabel6.EditingMode = false
        Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel6.Location = New System.Drawing.Point(366, 97)
        Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel6.Name = "CLabel6"
        Me.CLabel6.Size = New System.Drawing.Size(76, 23)
        Me.CLabel6.TabIndex = 79
        Me.CLabel6.Text = "Cash Price"
        Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel6.Translatable = true
        '
        'txtPack1
        '
        Me.txtPack1.BackColor = System.Drawing.Color.White
        Me.txtPack1.BegFindValue = Nothing
        Me.txtPack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPack1.ComputedValue = false
        Me.txtPack1.CustomFormat = Nothing
        Me.txtPack1.DataBoundControl = true
        Me.txtPack1.DisplayOnly = true
        Me.txtPack1.EditingMode = false
        Me.txtPack1.EndFindValue = Nothing
        Me.txtPack1.FieldDescription = Nothing
        Me.txtPack1.FieldName = "Item_Code"
        Me.txtPack1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPack1.FindEnabled = true
        Me.txtPack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPack1.ForeColor = System.Drawing.Color.Black
        Me.txtPack1.LinkedLabel = Nothing
        Me.txtPack1.Location = New System.Drawing.Point(514, 27)
        Me.txtPack1.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPack1.MaximumValue = Nothing
        Me.txtPack1.MinimumValue = Nothing
        Me.txtPack1.Name = "txtPack1"
        Me.txtPack1.OldValue = Nothing
        Me.txtPack1.ReadOnly = true
        Me.txtPack1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPack1.Size = New System.Drawing.Size(30, 21)
        Me.txtPack1.TabIndex = 75
        Me.txtPack1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPack1.Translatable = false
        '
        'txtpack2
        '
        Me.txtpack2.BackColor = System.Drawing.Color.White
        Me.txtpack2.BegFindValue = Nothing
        Me.txtpack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpack2.ComputedValue = false
        Me.txtpack2.CustomFormat = Nothing
        Me.txtpack2.DataBoundControl = true
        Me.txtpack2.DisplayOnly = true
        Me.txtpack2.EditingMode = false
        Me.txtpack2.EndFindValue = Nothing
        Me.txtpack2.FieldDescription = Nothing
        Me.txtpack2.FieldName = "Item_Code"
        Me.txtpack2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtpack2.FindEnabled = true
        Me.txtpack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtpack2.ForeColor = System.Drawing.Color.Black
        Me.txtpack2.LinkedLabel = Nothing
        Me.txtpack2.Location = New System.Drawing.Point(547, 27)
        Me.txtpack2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtpack2.MaximumValue = Nothing
        Me.txtpack2.MinimumValue = Nothing
        Me.txtpack2.Name = "txtpack2"
        Me.txtpack2.OldValue = Nothing
        Me.txtpack2.ReadOnly = true
        Me.txtpack2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtpack2.Size = New System.Drawing.Size(29, 21)
        Me.txtpack2.TabIndex = 76
        Me.txtpack2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtpack2.Translatable = false
        '
        'txtpack3
        '
        Me.txtpack3.BackColor = System.Drawing.Color.White
        Me.txtpack3.BegFindValue = Nothing
        Me.txtpack3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpack3.ComputedValue = false
        Me.txtpack3.CustomFormat = Nothing
        Me.txtpack3.DataBoundControl = true
        Me.txtpack3.DisplayOnly = true
        Me.txtpack3.EditingMode = false
        Me.txtpack3.EndFindValue = Nothing
        Me.txtpack3.FieldDescription = Nothing
        Me.txtpack3.FieldName = "Item_Code"
        Me.txtpack3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtpack3.FindEnabled = true
        Me.txtpack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtpack3.ForeColor = System.Drawing.Color.Black
        Me.txtpack3.LinkedLabel = Nothing
        Me.txtpack3.Location = New System.Drawing.Point(578, 27)
        Me.txtpack3.Margin = New System.Windows.Forms.Padding(1)
        Me.txtpack3.MaximumValue = Nothing
        Me.txtpack3.MinimumValue = Nothing
        Me.txtpack3.Name = "txtpack3"
        Me.txtpack3.OldValue = Nothing
        Me.txtpack3.ReadOnly = true
        Me.txtpack3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtpack3.Size = New System.Drawing.Size(30, 21)
        Me.txtpack3.TabIndex = 77
        Me.txtpack3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtpack3.Translatable = false
        '
        'txtQtyOnHand
        '
        Me.txtQtyOnHand.BackColor = System.Drawing.Color.White
        Me.txtQtyOnHand.BegFindValue = Nothing
        Me.txtQtyOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyOnHand.ComputedValue = false
        Me.txtQtyOnHand.CustomFormat = Nothing
        Me.txtQtyOnHand.DataBoundControl = true
        Me.txtQtyOnHand.DisplayOnly = true
        Me.txtQtyOnHand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQtyOnHand.EditingMode = false
        Me.txtQtyOnHand.EndFindValue = Nothing
        Me.txtQtyOnHand.FieldDescription = Nothing
        Me.txtQtyOnHand.FieldName = "Item_Code"
        Me.txtQtyOnHand.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtQtyOnHand.FindEnabled = true
        Me.txtQtyOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtQtyOnHand.ForeColor = System.Drawing.Color.Black
        Me.txtQtyOnHand.LinkedLabel = Nothing
        Me.txtQtyOnHand.Location = New System.Drawing.Point(444, 47)
        Me.txtQtyOnHand.Margin = New System.Windows.Forms.Padding(1)
        Me.txtQtyOnHand.MaximumValue = Nothing
        Me.txtQtyOnHand.MinimumValue = Nothing
        Me.txtQtyOnHand.Name = "txtQtyOnHand"
        Me.txtQtyOnHand.OldValue = Nothing
        Me.txtQtyOnHand.ReadOnly = true
        Me.txtQtyOnHand.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtQtyOnHand.Size = New System.Drawing.Size(68, 23)
        Me.txtQtyOnHand.TabIndex = 41
        Me.txtQtyOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQtyOnHand.Translatable = false
        '
        'cboRouteOfAdministration
        '
        Me.cboRouteOfAdministration.AlwaysEditable = false
        Me.cboRouteOfAdministration.BackColor = System.Drawing.Color.White
        Me.cboRouteOfAdministration.BegFindValue = Nothing
        Me.cboRouteOfAdministration.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboRouteOfAdministration, 6)
        Me.cboRouteOfAdministration.CurrentSearchTerm = ""
        Me.cboRouteOfAdministration.DataValue = Nothing
        Me.cboRouteOfAdministration.DefaultValue = Nothing
        Me.cboRouteOfAdministration.DisplayMember = "Name"
        Me.cboRouteOfAdministration.DisplayOnly = true
        Me.cboRouteOfAdministration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRouteOfAdministration.DropDownHeight = 24
        Me.cboRouteOfAdministration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboRouteOfAdministration.EditingMode = false
        Me.cboRouteOfAdministration.EndFindValue = Nothing
        Me.cboRouteOfAdministration.FieldDescription = Nothing
        Me.cboRouteOfAdministration.FieldName = Nothing
        Me.cboRouteOfAdministration.FilterRule = Nothing
        Me.cboRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboRouteOfAdministration.FindEnabled = true
        Me.cboRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboRouteOfAdministration.ForeColor = System.Drawing.Color.Black
        Me.cboRouteOfAdministration.FormattingEnabled = true
        Me.cboRouteOfAdministration.HideWhenNotEditingOrAdding = false
        Me.cboRouteOfAdministration.IgnoreCase = false
        Me.cboRouteOfAdministration.IntegralHeight = false
        Me.cboRouteOfAdministration.LimitToList = false
        Me.cboRouteOfAdministration.LinkedLabel = Nothing
        Me.cboRouteOfAdministration.Location = New System.Drawing.Point(174, 326)
        Me.cboRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
        Me.cboRouteOfAdministration.MaxDropDownItems = 1
        Me.cboRouteOfAdministration.Name = "cboRouteOfAdministration"
        Me.cboRouteOfAdministration.OldValue = 0
        Me.cboRouteOfAdministration.OriginalDataSource = Nothing
        Me.cboRouteOfAdministration.OriginalList = Nothing
        Me.cboRouteOfAdministration.OverrideDropDownStyleList = false
        Me.cboRouteOfAdministration.PreviousSearchTerm = Nothing
        Me.cboRouteOfAdministration.PropertySelector = Nothing
            Me.cboRouteOfAdministration.Size = New System.Drawing.Size(436, 24)
            Me.cboRouteOfAdministration.SuggestBoxHeight = 200
        Me.cboRouteOfAdministration.SuggestListOrderRule = Nothing
        Me.cboRouteOfAdministration.TabIndex = 12
        Me.cboRouteOfAdministration.TextToSearch = Nothing
        Me.cboRouteOfAdministration.Translatable = false
        Me.cboRouteOfAdministration.ValueIsMandatory = false
        Me.cboRouteOfAdministration.ValueIsNullable = false
        Me.cboRouteOfAdministration.ValueIsNumeric = false
        Me.cboRouteOfAdministration.ValueMember = "Name"
        '
        'txtGenericName
        '
        Me.txtGenericName.BackColor = System.Drawing.Color.White
        Me.txtGenericName.BegFindValue = Nothing
        Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtGenericName, 6)
        Me.txtGenericName.ComputedValue = false
        Me.txtGenericName.CustomFormat = Nothing
        Me.txtGenericName.DataBoundControl = true
        Me.txtGenericName.DisplayOnly = true
        Me.txtGenericName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGenericName.EditingMode = false
        Me.txtGenericName.EndFindValue = Nothing
        Me.txtGenericName.FieldDescription = Nothing
        Me.txtGenericName.FieldName = Nothing
        Me.txtGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtGenericName.FindEnabled = true
        Me.txtGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtGenericName.ForeColor = System.Drawing.Color.Black
        Me.txtGenericName.LinkedLabel = Nothing
        Me.txtGenericName.Location = New System.Drawing.Point(174, 122)
        Me.txtGenericName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtGenericName.MaximumValue = Nothing
        Me.txtGenericName.MinimumValue = Nothing
        Me.txtGenericName.Name = "txtGenericName"
        Me.txtGenericName.OldValue = ""
        Me.txtGenericName.ReadOnly = true
        Me.txtGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtGenericName.Size = New System.Drawing.Size(436, 23)
        Me.txtGenericName.TabIndex = 4
        Me.txtGenericName.Translatable = false
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(174, 1)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = ""
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(148, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.Translatable = false
        '
        'lblIdNo
        '
        Me.lblIdNo.AutoSize = true
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(83, 17)
        Me.lblIdNo.TabIndex = 1
        Me.lblIdNo.Text = "I.D. Number"
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'lblCode
        '
        Me.lblCode.AutoSize = true
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCode.Location = New System.Drawing.Point(1, 47)
        Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(41, 17)
        Me.lblCode.TabIndex = 2
        Me.lblCode.Text = "Code"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCode.Translatable = true
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblName.Location = New System.Drawing.Point(1, 72)
        Me.lblName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 17)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblName.Translatable = true
        '
        'TxtItemDetailsCode
        '
        Me.TxtItemDetailsCode.BackColor = System.Drawing.Color.White
        Me.TxtItemDetailsCode.BegFindValue = Nothing
        Me.TxtItemDetailsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItemDetailsCode.ComputedValue = false
        Me.TxtItemDetailsCode.CustomFormat = Nothing
        Me.TxtItemDetailsCode.DataBoundControl = true
        Me.TxtItemDetailsCode.DisplayOnly = true
        Me.TxtItemDetailsCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtItemDetailsCode.EditingMode = true
        Me.TxtItemDetailsCode.EndFindValue = Nothing
        Me.TxtItemDetailsCode.FieldDescription = Nothing
        Me.TxtItemDetailsCode.FieldName = "Item_Code"
        Me.TxtItemDetailsCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtItemDetailsCode.FindEnabled = true
        Me.TxtItemDetailsCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtItemDetailsCode.ForeColor = System.Drawing.Color.Black
        Me.TxtItemDetailsCode.LinkedLabel = Nothing
        Me.TxtItemDetailsCode.Location = New System.Drawing.Point(174, 47)
        Me.TxtItemDetailsCode.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtItemDetailsCode.MaximumValue = Nothing
        Me.TxtItemDetailsCode.MinimumValue = Nothing
        Me.TxtItemDetailsCode.Name = "TxtItemDetailsCode"
        Me.TxtItemDetailsCode.OldValue = Nothing
        Me.TxtItemDetailsCode.ReadOnly = true
        Me.TxtItemDetailsCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtItemDetailsCode.Size = New System.Drawing.Size(148, 23)
        Me.TxtItemDetailsCode.TabIndex = 1
        Me.TxtItemDetailsCode.Translatable = false
        '
        'TxtItemDetailsName
        '
        Me.TxtItemDetailsName.BackColor = System.Drawing.Color.White
        Me.TxtItemDetailsName.BegFindValue = Nothing
        Me.TxtItemDetailsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtItemDetailsName, 6)
        Me.TxtItemDetailsName.ComputedValue = false
        Me.TxtItemDetailsName.CustomFormat = Nothing
        Me.TxtItemDetailsName.DataBoundControl = true
        Me.TxtItemDetailsName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtItemDetailsName.EditingMode = true
        Me.TxtItemDetailsName.EndFindValue = Nothing
        Me.TxtItemDetailsName.FieldDescription = Nothing
        Me.TxtItemDetailsName.FieldName = Nothing
        Me.TxtItemDetailsName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtItemDetailsName.FindEnabled = true
        Me.TxtItemDetailsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtItemDetailsName.ForeColor = System.Drawing.Color.Black
        Me.TxtItemDetailsName.LinkedLabel = Nothing
        Me.TxtItemDetailsName.Location = New System.Drawing.Point(174, 72)
        Me.TxtItemDetailsName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtItemDetailsName.MaximumValue = Nothing
        Me.TxtItemDetailsName.MinimumValue = Nothing
        Me.TxtItemDetailsName.Name = "TxtItemDetailsName"
        Me.TxtItemDetailsName.OldValue = Nothing
        Me.TxtItemDetailsName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtItemDetailsName.Size = New System.Drawing.Size(436, 23)
        Me.TxtItemDetailsName.TabIndex = 2
        Me.TxtItemDetailsName.Translatable = false
        '
        'cboPackageSize
        '
        Me.cboPackageSize.AutoSize = true
        Me.cboPackageSize.DisplayOnly = true
        Me.cboPackageSize.EditingMode = false
        Me.cboPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPackageSize.Location = New System.Drawing.Point(1, 301)
        Me.cboPackageSize.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPackageSize.Name = "cboPackageSize"
        Me.cboPackageSize.Size = New System.Drawing.Size(94, 17)
        Me.cboPackageSize.TabIndex = 27
        Me.cboPackageSize.Text = "Package Size"
        Me.cboPackageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cboPackageSize.Translatable = true
        '
        'lblPackageType
        '
        Me.lblPackageType.AutoSize = true
        Me.lblPackageType.DisplayOnly = true
        Me.lblPackageType.EditingMode = false
        Me.lblPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPackageType.Location = New System.Drawing.Point(1, 275)
        Me.lblPackageType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPackageType.Name = "lblPackageType"
        Me.lblPackageType.Size = New System.Drawing.Size(99, 17)
        Me.lblPackageType.TabIndex = 25
        Me.lblPackageType.Text = "Package Type"
        Me.lblPackageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPackageType.Translatable = true
        '
        'lblUnitOfVolume
        '
        Me.lblUnitOfVolume.AutoSize = true
        Me.lblUnitOfVolume.DisplayOnly = true
        Me.lblUnitOfVolume.EditingMode = false
        Me.lblUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblUnitOfVolume.Location = New System.Drawing.Point(1, 249)
        Me.lblUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUnitOfVolume.Name = "lblUnitOfVolume"
        Me.lblUnitOfVolume.Size = New System.Drawing.Size(103, 17)
        Me.lblUnitOfVolume.TabIndex = 21
        Me.lblUnitOfVolume.Text = "Unit Of Volume"
        Me.lblUnitOfVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUnitOfVolume.Translatable = true
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = true
        Me.lblVolume.DisplayOnly = true
        Me.lblVolume.EditingMode = false
        Me.lblVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVolume.Location = New System.Drawing.Point(1, 224)
        Me.lblVolume.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(55, 17)
        Me.lblVolume.TabIndex = 19
        Me.lblVolume.Text = "Volume"
        Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVolume.Translatable = true
        '
        'lblDosageForm
        '
        Me.lblDosageForm.AutoSize = true
        Me.lblDosageForm.DisplayOnly = true
        Me.lblDosageForm.EditingMode = false
        Me.lblDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDosageForm.Location = New System.Drawing.Point(1, 198)
        Me.lblDosageForm.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDosageForm.Name = "lblDosageForm"
        Me.lblDosageForm.Size = New System.Drawing.Size(93, 17)
        Me.lblDosageForm.TabIndex = 29
        Me.lblDosageForm.Text = "Dosage Form"
        Me.lblDosageForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDosageForm.Translatable = true
        '
        'lblUnitOfStrength
        '
        Me.lblUnitOfStrength.AutoSize = true
        Me.lblUnitOfStrength.DisplayOnly = true
        Me.lblUnitOfStrength.EditingMode = false
        Me.lblUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblUnitOfStrength.Location = New System.Drawing.Point(1, 172)
        Me.lblUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUnitOfStrength.Name = "lblUnitOfStrength"
        Me.lblUnitOfStrength.Size = New System.Drawing.Size(107, 17)
        Me.lblUnitOfStrength.TabIndex = 17
        Me.lblUnitOfStrength.Text = "Unit of Strength"
        Me.lblUnitOfStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUnitOfStrength.Translatable = true
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(1, 147)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(100, 17)
        Me.CLabel1.TabIndex = 11
        Me.CLabel1.Text = "Strength value"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'lblGenericName
        '
        Me.lblGenericName.AutoSize = true
        Me.lblGenericName.DisplayOnly = true
        Me.lblGenericName.EditingMode = false
        Me.lblGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblGenericName.Location = New System.Drawing.Point(1, 122)
        Me.lblGenericName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblGenericName.Name = "lblGenericName"
        Me.lblGenericName.Size = New System.Drawing.Size(99, 17)
        Me.lblGenericName.TabIndex = 4
        Me.lblGenericName.Text = "Generic Name"
        Me.lblGenericName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGenericName.Translatable = true
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(1, 97)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(126, 17)
        Me.CLabel2.TabIndex = 31
        Me.CLabel2.Text = "Prescription Drug?"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'txtPackageSize
        '
        Me.txtPackageSize.BackColor = System.Drawing.Color.White
        Me.txtPackageSize.BegFindValue = Nothing
        Me.txtPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackageSize.ComputedValue = false
        Me.txtPackageSize.CustomFormat = Nothing
        Me.txtPackageSize.DataBoundControl = true
        Me.txtPackageSize.DisplayOnly = true
        Me.txtPackageSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPackageSize.EditingMode = false
        Me.txtPackageSize.EndFindValue = Nothing
        Me.txtPackageSize.FieldDescription = Nothing
        Me.txtPackageSize.FieldName = Nothing
        Me.txtPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPackageSize.FindEnabled = true
        Me.txtPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPackageSize.ForeColor = System.Drawing.Color.Black
        Me.txtPackageSize.LinkedLabel = Nothing
        Me.txtPackageSize.Location = New System.Drawing.Point(174, 301)
        Me.txtPackageSize.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPackageSize.MaximumValue = Nothing
        Me.txtPackageSize.MinimumValue = Nothing
        Me.txtPackageSize.Name = "txtPackageSize"
        Me.txtPackageSize.OldValue = Nothing
        Me.txtPackageSize.ReadOnly = true
        Me.txtPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPackageSize.Size = New System.Drawing.Size(148, 23)
        Me.txtPackageSize.TabIndex = 11
        Me.txtPackageSize.Translatable = false
        '
        'cboPackageType
        '
        Me.cboPackageType.AlwaysEditable = false
        Me.cboPackageType.BackColor = System.Drawing.Color.White
        Me.cboPackageType.BegFindValue = Nothing
        Me.cboPackageType.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboPackageType, 6)
        Me.cboPackageType.CurrentSearchTerm = ""
        Me.cboPackageType.DataValue = Nothing
        Me.cboPackageType.DefaultValue = Nothing
        Me.cboPackageType.DisplayMember = "Name"
        Me.cboPackageType.DisplayOnly = true
        Me.cboPackageType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPackageType.DropDownHeight = 24
        Me.cboPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboPackageType.EditingMode = false
        Me.cboPackageType.EndFindValue = Nothing
        Me.cboPackageType.FieldDescription = Nothing
        Me.cboPackageType.FieldName = Nothing
        Me.cboPackageType.FilterRule = Nothing
        Me.cboPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPackageType.FindEnabled = true
        Me.cboPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPackageType.ForeColor = System.Drawing.Color.Black
        Me.cboPackageType.FormattingEnabled = true
        Me.cboPackageType.HideWhenNotEditingOrAdding = false
        Me.cboPackageType.IgnoreCase = false
        Me.cboPackageType.IntegralHeight = false
        Me.cboPackageType.LimitToList = false
        Me.cboPackageType.LinkedLabel = Nothing
        Me.cboPackageType.Location = New System.Drawing.Point(174, 275)
        Me.cboPackageType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPackageType.MaxDropDownItems = 1
        Me.cboPackageType.Name = "cboPackageType"
        Me.cboPackageType.OldValue = 0
        Me.cboPackageType.OriginalDataSource = Nothing
        Me.cboPackageType.OriginalList = Nothing
        Me.cboPackageType.OverrideDropDownStyleList = false
        Me.cboPackageType.PreviousSearchTerm = Nothing
        Me.cboPackageType.PropertySelector = Nothing
            Me.cboPackageType.Size = New System.Drawing.Size(436, 24)
            Me.cboPackageType.SuggestBoxHeight = 200
        Me.cboPackageType.SuggestListOrderRule = Nothing
        Me.cboPackageType.TabIndex = 10
        Me.cboPackageType.TextToSearch = Nothing
        Me.cboPackageType.Translatable = false
        Me.cboPackageType.ValueIsMandatory = false
        Me.cboPackageType.ValueIsNullable = false
        Me.cboPackageType.ValueIsNumeric = false
        Me.cboPackageType.ValueMember = "Name"
        '
        'cboUnitOfVolume
        '
        Me.cboUnitOfVolume.AlwaysEditable = false
        Me.cboUnitOfVolume.BackColor = System.Drawing.Color.White
        Me.cboUnitOfVolume.BegFindValue = Nothing
        Me.cboUnitOfVolume.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboUnitOfVolume, 6)
        Me.cboUnitOfVolume.CurrentSearchTerm = ""
        Me.cboUnitOfVolume.DataValue = Nothing
        Me.cboUnitOfVolume.DefaultValue = Nothing
        Me.cboUnitOfVolume.DisplayMember = "Name"
        Me.cboUnitOfVolume.DisplayOnly = true
        Me.cboUnitOfVolume.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboUnitOfVolume.DropDownHeight = 24
        Me.cboUnitOfVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboUnitOfVolume.EditingMode = false
        Me.cboUnitOfVolume.EndFindValue = Nothing
        Me.cboUnitOfVolume.FieldDescription = Nothing
        Me.cboUnitOfVolume.FieldName = Nothing
        Me.cboUnitOfVolume.FilterRule = Nothing
        Me.cboUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboUnitOfVolume.FindEnabled = true
        Me.cboUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboUnitOfVolume.ForeColor = System.Drawing.Color.Black
        Me.cboUnitOfVolume.FormattingEnabled = true
        Me.cboUnitOfVolume.HideWhenNotEditingOrAdding = false
        Me.cboUnitOfVolume.IgnoreCase = false
        Me.cboUnitOfVolume.IntegralHeight = false
        Me.cboUnitOfVolume.LimitToList = false
        Me.cboUnitOfVolume.LinkedLabel = Nothing
        Me.cboUnitOfVolume.Location = New System.Drawing.Point(174, 249)
        Me.cboUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
        Me.cboUnitOfVolume.MaxDropDownItems = 1
        Me.cboUnitOfVolume.Name = "cboUnitOfVolume"
        Me.cboUnitOfVolume.OldValue = 0
        Me.cboUnitOfVolume.OriginalDataSource = Nothing
        Me.cboUnitOfVolume.OriginalList = Nothing
        Me.cboUnitOfVolume.OverrideDropDownStyleList = false
        Me.cboUnitOfVolume.PreviousSearchTerm = Nothing
        Me.cboUnitOfVolume.PropertySelector = Nothing
            Me.cboUnitOfVolume.Size = New System.Drawing.Size(436, 24)
            Me.cboUnitOfVolume.SuggestBoxHeight = 200
        Me.cboUnitOfVolume.SuggestListOrderRule = Nothing
        Me.cboUnitOfVolume.TabIndex = 9
        Me.cboUnitOfVolume.TextToSearch = Nothing
        Me.cboUnitOfVolume.Translatable = false
        Me.cboUnitOfVolume.ValueIsMandatory = false
        Me.cboUnitOfVolume.ValueIsNullable = false
        Me.cboUnitOfVolume.ValueIsNumeric = false
        Me.cboUnitOfVolume.ValueMember = "Name"
        '
        'txtVolume
        '
        Me.txtVolume.BackColor = System.Drawing.Color.White
        Me.txtVolume.BegFindValue = Nothing
        Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVolume.ComputedValue = false
        Me.txtVolume.CustomFormat = Nothing
        Me.txtVolume.DataBoundControl = true
        Me.txtVolume.DisplayOnly = true
        Me.txtVolume.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVolume.EditingMode = false
        Me.txtVolume.EndFindValue = Nothing
        Me.txtVolume.FieldDescription = Nothing
        Me.txtVolume.FieldName = Nothing
        Me.txtVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVolume.FindEnabled = true
        Me.txtVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVolume.ForeColor = System.Drawing.Color.Black
        Me.txtVolume.LinkedLabel = Nothing
        Me.txtVolume.Location = New System.Drawing.Point(174, 224)
        Me.txtVolume.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVolume.MaximumValue = Nothing
        Me.txtVolume.MinimumValue = Nothing
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.OldValue = Nothing
        Me.txtVolume.ReadOnly = true
        Me.txtVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVolume.Size = New System.Drawing.Size(148, 23)
        Me.txtVolume.TabIndex = 8
        Me.txtVolume.Translatable = false
        '
        'cboDosageForm
        '
        Me.cboDosageForm.AlwaysEditable = false
        Me.cboDosageForm.BackColor = System.Drawing.Color.White
        Me.cboDosageForm.BegFindValue = Nothing
        Me.cboDosageForm.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDosageForm, 6)
        Me.cboDosageForm.CurrentSearchTerm = ""
        Me.cboDosageForm.DataValue = Nothing
        Me.cboDosageForm.DefaultValue = Nothing
        Me.cboDosageForm.DisplayMember = "Name"
        Me.cboDosageForm.DisplayOnly = true
        Me.cboDosageForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDosageForm.DropDownHeight = 24
        Me.cboDosageForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboDosageForm.EditingMode = false
        Me.cboDosageForm.EndFindValue = Nothing
        Me.cboDosageForm.FieldDescription = Nothing
        Me.cboDosageForm.FieldName = Nothing
        Me.cboDosageForm.FilterRule = Nothing
        Me.cboDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDosageForm.FindEnabled = true
        Me.cboDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDosageForm.ForeColor = System.Drawing.Color.Black
        Me.cboDosageForm.FormattingEnabled = true
        Me.cboDosageForm.HideWhenNotEditingOrAdding = false
        Me.cboDosageForm.IgnoreCase = false
        Me.cboDosageForm.IntegralHeight = false
        Me.cboDosageForm.LimitToList = false
        Me.cboDosageForm.LinkedLabel = Nothing
        Me.cboDosageForm.Location = New System.Drawing.Point(174, 198)
        Me.cboDosageForm.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDosageForm.MaxDropDownItems = 1
        Me.cboDosageForm.Name = "cboDosageForm"
        Me.cboDosageForm.OldValue = 0
        Me.cboDosageForm.OriginalDataSource = Nothing
        Me.cboDosageForm.OriginalList = Nothing
        Me.cboDosageForm.OverrideDropDownStyleList = false
        Me.cboDosageForm.PreviousSearchTerm = Nothing
        Me.cboDosageForm.PropertySelector = Nothing
            Me.cboDosageForm.Size = New System.Drawing.Size(436, 24)
            Me.cboDosageForm.SuggestBoxHeight = 200
        Me.cboDosageForm.SuggestListOrderRule = Nothing
        Me.cboDosageForm.TabIndex = 7
        Me.cboDosageForm.TextToSearch = Nothing
        Me.cboDosageForm.Translatable = false
        Me.cboDosageForm.ValueIsMandatory = false
        Me.cboDosageForm.ValueIsNullable = false
        Me.cboDosageForm.ValueIsNumeric = false
        Me.cboDosageForm.ValueMember = "Name"
        '
        'cboUnitOfStrength
        '
        Me.cboUnitOfStrength.AlwaysEditable = false
        Me.cboUnitOfStrength.BackColor = System.Drawing.Color.White
        Me.cboUnitOfStrength.BegFindValue = Nothing
        Me.cboUnitOfStrength.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboUnitOfStrength, 6)
        Me.cboUnitOfStrength.CurrentSearchTerm = ""
        Me.cboUnitOfStrength.DataValue = Nothing
        Me.cboUnitOfStrength.DefaultValue = Nothing
        Me.cboUnitOfStrength.DisplayMember = "Name"
        Me.cboUnitOfStrength.DisplayOnly = true
        Me.cboUnitOfStrength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboUnitOfStrength.DropDownHeight = 24
        Me.cboUnitOfStrength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboUnitOfStrength.EditingMode = false
        Me.cboUnitOfStrength.EndFindValue = Nothing
        Me.cboUnitOfStrength.FieldDescription = Nothing
        Me.cboUnitOfStrength.FieldName = Nothing
        Me.cboUnitOfStrength.FilterRule = Nothing
        Me.cboUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboUnitOfStrength.FindEnabled = true
        Me.cboUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboUnitOfStrength.ForeColor = System.Drawing.Color.Black
        Me.cboUnitOfStrength.FormattingEnabled = true
        Me.cboUnitOfStrength.HideWhenNotEditingOrAdding = false
        Me.cboUnitOfStrength.IgnoreCase = false
        Me.cboUnitOfStrength.IntegralHeight = false
        Me.cboUnitOfStrength.LimitToList = false
        Me.cboUnitOfStrength.LinkedLabel = Nothing
        Me.cboUnitOfStrength.Location = New System.Drawing.Point(174, 172)
        Me.cboUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
        Me.cboUnitOfStrength.MaxDropDownItems = 1
        Me.cboUnitOfStrength.Name = "cboUnitOfStrength"
        Me.cboUnitOfStrength.OldValue = 0
        Me.cboUnitOfStrength.OriginalDataSource = Nothing
        Me.cboUnitOfStrength.OriginalList = Nothing
        Me.cboUnitOfStrength.OverrideDropDownStyleList = false
        Me.cboUnitOfStrength.PreviousSearchTerm = Nothing
        Me.cboUnitOfStrength.PropertySelector = Nothing
            Me.cboUnitOfStrength.Size = New System.Drawing.Size(436, 24)
            Me.cboUnitOfStrength.SuggestBoxHeight = 200
        Me.cboUnitOfStrength.SuggestListOrderRule = Nothing
        Me.cboUnitOfStrength.TabIndex = 6
        Me.cboUnitOfStrength.TextToSearch = Nothing
        Me.cboUnitOfStrength.Translatable = false
        Me.cboUnitOfStrength.ValueIsMandatory = false
        Me.cboUnitOfStrength.ValueIsNullable = false
        Me.cboUnitOfStrength.ValueIsNumeric = false
        Me.cboUnitOfStrength.ValueMember = "Name"
        '
        'txtStrengthValue
        '
        Me.txtStrengthValue.BackColor = System.Drawing.Color.White
        Me.txtStrengthValue.BegFindValue = Nothing
        Me.txtStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStrengthValue.ComputedValue = false
        Me.txtStrengthValue.CustomFormat = Nothing
        Me.txtStrengthValue.DataBoundControl = true
        Me.txtStrengthValue.DisplayOnly = true
        Me.txtStrengthValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStrengthValue.EditingMode = false
        Me.txtStrengthValue.EndFindValue = Nothing
        Me.txtStrengthValue.FieldDescription = Nothing
        Me.txtStrengthValue.FieldName = Nothing
        Me.txtStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtStrengthValue.FindEnabled = true
        Me.txtStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtStrengthValue.ForeColor = System.Drawing.Color.Black
        Me.txtStrengthValue.LinkedLabel = Nothing
        Me.txtStrengthValue.Location = New System.Drawing.Point(174, 147)
        Me.txtStrengthValue.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStrengthValue.MaximumValue = Nothing
        Me.txtStrengthValue.MinimumValue = Nothing
        Me.txtStrengthValue.Name = "txtStrengthValue"
        Me.txtStrengthValue.OldValue = Nothing
        Me.txtStrengthValue.ReadOnly = true
        Me.txtStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtStrengthValue.Size = New System.Drawing.Size(148, 23)
        Me.txtStrengthValue.TabIndex = 5
        Me.txtStrengthValue.Translatable = false
        '
        'chkPrescriptionDrug
        '
        Me.chkPrescriptionDrug.AlwaysEditable = false
        Me.chkPrescriptionDrug.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPrescriptionDrug.AutoCheck = false
        Me.chkPrescriptionDrug.BackColor = System.Drawing.Color.White
        Me.chkPrescriptionDrug.BegFindValue = Nothing
        Me.chkPrescriptionDrug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrescriptionDrug.DisplayOnly = false
        Me.chkPrescriptionDrug.EditingMode = false
        Me.chkPrescriptionDrug.EndFindValue = Nothing
        Me.chkPrescriptionDrug.FieldDescription = Nothing
        Me.chkPrescriptionDrug.FieldName = Nothing
        Me.chkPrescriptionDrug.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkPrescriptionDrug.FindEnabled = true
        Me.chkPrescriptionDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPrescriptionDrug.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.chkPrescriptionDrug.ForeColor = System.Drawing.Color.Black
        Me.chkPrescriptionDrug.IFindableControl_FindEnabled = false
        Me.chkPrescriptionDrug.IgnoreCase = false
        Me.chkPrescriptionDrug.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPrescriptionDrug.LinkedLabel = Nothing
        Me.chkPrescriptionDrug.Location = New System.Drawing.Point(174, 97)
        Me.chkPrescriptionDrug.Margin = New System.Windows.Forms.Padding(1)
        Me.chkPrescriptionDrug.Name = "chkPrescriptionDrug"
        Me.chkPrescriptionDrug.NoLabel = false
        Me.chkPrescriptionDrug.OldValue = ""
        Me.chkPrescriptionDrug.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPrescriptionDrug.Size = New System.Drawing.Size(13, 13)
        Me.chkPrescriptionDrug.TabIndex = 3
        Me.chkPrescriptionDrug.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrescriptionDrug.Translatable = false
        Me.chkPrescriptionDrug.UseVisualStyleBackColor = false
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 326)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(155, 17)
        Me.CLabel3.TabIndex = 34
        Me.CLabel3.Text = "Route of Administration"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'txtRegistrationNo
        '
        Me.txtRegistrationNo.BackColor = System.Drawing.Color.White
        Me.txtRegistrationNo.BegFindValue = Nothing
        Me.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegistrationNo.ComputedValue = false
        Me.txtRegistrationNo.CustomFormat = Nothing
        Me.txtRegistrationNo.DataBoundControl = true
        Me.txtRegistrationNo.DisplayOnly = true
        Me.txtRegistrationNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRegistrationNo.EditingMode = false
        Me.txtRegistrationNo.EndFindValue = Nothing
        Me.txtRegistrationNo.FieldDescription = Nothing
        Me.txtRegistrationNo.FieldName = Nothing
        Me.txtRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtRegistrationNo.FindEnabled = true
        Me.txtRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtRegistrationNo.ForeColor = System.Drawing.Color.Black
        Me.txtRegistrationNo.LinkedLabel = Nothing
        Me.txtRegistrationNo.Location = New System.Drawing.Point(174, 352)
        Me.txtRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRegistrationNo.MaximumValue = Nothing
        Me.txtRegistrationNo.MinimumValue = Nothing
        Me.txtRegistrationNo.Name = "txtRegistrationNo"
        Me.txtRegistrationNo.OldValue = ""
        Me.txtRegistrationNo.ReadOnly = true
        Me.txtRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtRegistrationNo.Size = New System.Drawing.Size(148, 23)
        Me.txtRegistrationNo.TabIndex = 13
        Me.txtRegistrationNo.Translatable = false
        '
        'lblRegistrationCode
        '
        Me.lblRegistrationCode.AutoSize = true
        Me.lblRegistrationCode.DisplayOnly = true
        Me.lblRegistrationCode.EditingMode = false
        Me.lblRegistrationCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblRegistrationCode.Location = New System.Drawing.Point(1, 352)
        Me.lblRegistrationCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRegistrationCode.Name = "lblRegistrationCode"
        Me.lblRegistrationCode.Size = New System.Drawing.Size(138, 17)
        Me.lblRegistrationCode.TabIndex = 33
        Me.lblRegistrationCode.Text = "Registration Number"
        Me.lblRegistrationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRegistrationCode.Translatable = true
        '
        'lblGTIN
        '
        Me.lblGTIN.AutoSize = true
        Me.lblGTIN.DisplayOnly = true
        Me.lblGTIN.EditingMode = false
        Me.lblGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblGTIN.Location = New System.Drawing.Point(1, 27)
        Me.lblGTIN.Margin = New System.Windows.Forms.Padding(1)
        Me.lblGTIN.Name = "lblGTIN"
        Me.lblGTIN.Size = New System.Drawing.Size(41, 17)
        Me.lblGTIN.TabIndex = 36
        Me.lblGTIN.Text = "GTIN"
        Me.lblGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGTIN.Translatable = true
        '
        'txtGTIN
        '
        Me.txtGTIN.BackColor = System.Drawing.Color.White
        Me.txtGTIN.BegFindValue = Nothing
        Me.txtGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGTIN.ComputedValue = false
        Me.txtGTIN.CustomFormat = Nothing
        Me.txtGTIN.DataBoundControl = true
        Me.txtGTIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGTIN.EditingMode = true
        Me.txtGTIN.EndFindValue = Nothing
        Me.txtGTIN.FieldDescription = Nothing
        Me.txtGTIN.FieldName = Nothing
        Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtGTIN.FindEnabled = true
        Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtGTIN.ForeColor = System.Drawing.Color.Black
        Me.txtGTIN.LinkedLabel = Nothing
        Me.txtGTIN.Location = New System.Drawing.Point(174, 27)
        Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
        Me.txtGTIN.MaximumValue = Nothing
        Me.txtGTIN.MinimumValue = Nothing
        Me.txtGTIN.Name = "txtGTIN"
        Me.txtGTIN.OldValue = ""
        Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtGTIN.Size = New System.Drawing.Size(148, 23)
        Me.txtGTIN.TabIndex = 35
        Me.txtGTIN.Translatable = false
        '
        'cboItemFinder
        '
        Me.cboItemFinder.AlwaysEditable = false
        Me.cboItemFinder.BackColor = System.Drawing.Color.White
        Me.cboItemFinder.BegFindValue = Nothing
        Me.cboItemFinder.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboItemFinder, 4)
        Me.cboItemFinder.CurrentSearchTerm = ""
        Me.cboItemFinder.DataValue = Nothing
        Me.cboItemFinder.DefaultValue = Nothing
        Me.cboItemFinder.DisplayMember = "Name"
        Me.cboItemFinder.EditingMode = true
        Me.cboItemFinder.EndFindValue = Nothing
        Me.cboItemFinder.FieldDescription = Nothing
        Me.cboItemFinder.FieldName = Nothing
        Me.cboItemFinder.FilterRule = Nothing
        Me.cboItemFinder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboItemFinder.FindEnabled = true
        Me.cboItemFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboItemFinder.ForeColor = System.Drawing.Color.Black
        Me.cboItemFinder.FormattingEnabled = true
        Me.cboItemFinder.HideWhenNotEditingOrAdding = false
        Me.cboItemFinder.IgnoreCase = false
        Me.cboItemFinder.IntegralHeight = false
        Me.cboItemFinder.LimitToList = false
        Me.cboItemFinder.LinkedLabel = Nothing
        Me.cboItemFinder.Location = New System.Drawing.Point(444, 1)
        Me.cboItemFinder.Margin = New System.Windows.Forms.Padding(1)
        Me.cboItemFinder.Name = "cboItemFinder"
        Me.cboItemFinder.OldValue = 0
        Me.cboItemFinder.OriginalDataSource = Nothing
        Me.cboItemFinder.OriginalList = Nothing
        Me.cboItemFinder.OverrideDropDownStyleList = false
        Me.cboItemFinder.PreviousSearchTerm = Nothing
        Me.cboItemFinder.PropertySelector = Nothing
            Me.cboItemFinder.Size = New System.Drawing.Size(164, 24)
            Me.cboItemFinder.SuggestBoxHeight = 200
        Me.cboItemFinder.SuggestListOrderRule = Nothing
        Me.cboItemFinder.TabIndex = 37
        Me.cboItemFinder.TextToSearch = Nothing
        Me.cboItemFinder.Translatable = false
        Me.cboItemFinder.ValueIsMandatory = false
        Me.cboItemFinder.ValueIsNullable = false
        Me.cboItemFinder.ValueIsNumeric = false
        Me.cboItemFinder.ValueMember = "Name"
        '
        'btnScanQrCode
        '
        Me.btnScanQrCode.DesignerSelected = false
        Me.btnScanQrCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnScanQrCode.ImageIndex = 0
        Me.btnScanQrCode.Location = New System.Drawing.Point(323, 26)
        Me.btnScanQrCode.Margin = New System.Windows.Forms.Padding(0)
        Me.btnScanQrCode.Name = "btnScanQrCode"
        Me.btnScanQrCode.OriginalImageName = Nothing
        Me.btnScanQrCode.SecurityKey = ""
        Me.btnScanQrCode.Size = New System.Drawing.Size(90, 20)
        Me.btnScanQrCode.TabIndex = 39
        Me.btnScanQrCode.Text = "Scan Qr Code"
        Me.btnScanQrCode.TextMargin = New System.Windows.Forms.Padding(0)
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = true
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel4.Location = New System.Drawing.Point(350, 47)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(92, 23)
        Me.CLabel4.TabIndex = 40
        Me.CLabel4.Text = "Qty. on Hand"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel4.Translatable = true
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = true
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.Location = New System.Drawing.Point(444, 27)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(58, 17)
        Me.CLabel5.TabIndex = 78
        Me.CLabel5.Text = "Packing"
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel5.Translatable = true
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'ItemDetailsEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.ClientSize = New System.Drawing.Size(632, 439)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ItemDetailsEntry"
        Me.Text = "Item Details Entry"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.EventLog1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblGenericName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItemDetailsCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents TxtItemDetailsName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDosageForm As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStrengthValue As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGenericName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboUnitOfStrength As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents cboPackageSize As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPackageType As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblUnitOfVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblUnitOfStrength As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboPackageType As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents cboUnitOfVolume As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents txtVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboDosageForm As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkPrescriptionDrug As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboRouteOfAdministration As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents txtRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblRegistrationCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboItemFinder As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents btnScanQrCode As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents EventLog1 As EventLog
        Friend WithEvents txtQtyOnHand As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPack1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPrice_Cash As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
    End Class
End Namespace