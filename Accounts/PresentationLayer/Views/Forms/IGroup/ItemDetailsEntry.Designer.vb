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
            Me.CaComboBox2 = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.cboPackageType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboDosageForm = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.chkPrescriptionDrug = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRegistrationCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboItemFinder = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.TableLayoutPanel1.Controls.Add(Me.CaComboBox2, 0, 16)
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
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 17
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
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
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(641, 371)
            Me.TableLayoutPanel1.TabIndex = 5
            '
            'CaComboBox2
            '
            Me.CaComboBox2.BackColor = System.Drawing.Color.White
            Me.CaComboBox2.BegFindValue = Nothing
            Me.CaComboBox2.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.CaComboBox2, 2)
            Me.CaComboBox2.CurrentSearchTerm = ""
            Me.CaComboBox2.DataValue = Nothing
            Me.CaComboBox2.DefaultValue = Nothing
            Me.CaComboBox2.DisplayMember = "Name"
            Me.CaComboBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CaComboBox2.EditingMode = True
            Me.CaComboBox2.EndFindValue = Nothing
            Me.CaComboBox2.FieldDescription = Nothing
            Me.CaComboBox2.FieldName = Nothing
            Me.CaComboBox2.FilterRule = Nothing
            Me.CaComboBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CaComboBox2.FindEnabled = True
            Me.CaComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CaComboBox2.ForeColor = System.Drawing.Color.Black
            Me.CaComboBox2.FormattingEnabled = True
            Me.CaComboBox2.HideWhenNotEditingOrAdding = False
            Me.CaComboBox2.IgnoreCase = False
            Me.CaComboBox2.IntegralHeight = False
            Me.CaComboBox2.LinkedLabel = Nothing
            Me.CaComboBox2.Location = New System.Drawing.Point(1, 371)
            Me.CaComboBox2.Margin = New System.Windows.Forms.Padding(1)
            Me.CaComboBox2.Name = "CaComboBox2"
            Me.CaComboBox2.OldValue = 0
            Me.CaComboBox2.OriginalDataSource = Nothing
            Me.CaComboBox2.OriginalList = Nothing
            Me.CaComboBox2.OverrideDropDownStyleList = False
            Me.CaComboBox2.PreviousSearchTerm = Nothing
            Me.CaComboBox2.PropertySelector = Nothing
            Me.CaComboBox2.ReadOnlyCombo = False
            Me.CaComboBox2.Size = New System.Drawing.Size(321, 24)
            Me.CaComboBox2.SuggestBoxHeight = 200
            Me.CaComboBox2.SuggestListOrderRule = Nothing
            Me.CaComboBox2.TabIndex = 38
            Me.CaComboBox2.TextToSearch = Nothing
            Me.CaComboBox2.Translatable = False
            Me.CaComboBox2.ValueIsMandatory = False
            Me.CaComboBox2.ValueIsNullable = False
            Me.CaComboBox2.ValueIsNumeric = False
            Me.CaComboBox2.ValueMember = "Name"
            '
            'cboRouteOfAdministration
            '
            Me.cboRouteOfAdministration.BackColor = System.Drawing.Color.White
            Me.cboRouteOfAdministration.BegFindValue = Nothing
            Me.cboRouteOfAdministration.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboRouteOfAdministration, 2)
            Me.cboRouteOfAdministration.CurrentSearchTerm = ""
            Me.cboRouteOfAdministration.DataValue = Nothing
            Me.cboRouteOfAdministration.DefaultValue = Nothing
            Me.cboRouteOfAdministration.DisplayMember = "Name"
            Me.cboRouteOfAdministration.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboRouteOfAdministration.EditingMode = True
            Me.cboRouteOfAdministration.EndFindValue = Nothing
            Me.cboRouteOfAdministration.FieldDescription = Nothing
            Me.cboRouteOfAdministration.FieldName = Nothing
            Me.cboRouteOfAdministration.FilterRule = Nothing
            Me.cboRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboRouteOfAdministration.FindEnabled = True
            Me.cboRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboRouteOfAdministration.ForeColor = System.Drawing.Color.Black
            Me.cboRouteOfAdministration.FormattingEnabled = True
            Me.cboRouteOfAdministration.HideWhenNotEditingOrAdding = False
            Me.cboRouteOfAdministration.IgnoreCase = False
            Me.cboRouteOfAdministration.IntegralHeight = False
            Me.cboRouteOfAdministration.LinkedLabel = Nothing
            Me.cboRouteOfAdministration.Location = New System.Drawing.Point(174, 320)
            Me.cboRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
            Me.cboRouteOfAdministration.Name = "cboRouteOfAdministration"
            Me.cboRouteOfAdministration.OldValue = 0
            Me.cboRouteOfAdministration.OriginalDataSource = Nothing
            Me.cboRouteOfAdministration.OriginalList = Nothing
            Me.cboRouteOfAdministration.OverrideDropDownStyleList = False
            Me.cboRouteOfAdministration.PreviousSearchTerm = Nothing
            Me.cboRouteOfAdministration.PropertySelector = Nothing
            Me.cboRouteOfAdministration.ReadOnlyCombo = False
            Me.cboRouteOfAdministration.Size = New System.Drawing.Size(466, 24)
            Me.cboRouteOfAdministration.SuggestBoxHeight = 200
            Me.cboRouteOfAdministration.SuggestListOrderRule = Nothing
            Me.cboRouteOfAdministration.TabIndex = 12
            Me.cboRouteOfAdministration.TextToSearch = Nothing
            Me.cboRouteOfAdministration.Translatable = False
            Me.cboRouteOfAdministration.ValueIsMandatory = False
            Me.cboRouteOfAdministration.ValueIsNullable = False
            Me.cboRouteOfAdministration.ValueIsNumeric = False
            Me.cboRouteOfAdministration.ValueMember = "Name"
            '
            'txtGenericName
            '
            Me.txtGenericName.BackColor = System.Drawing.Color.White
            Me.txtGenericName.BegFindValue = Nothing
            Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtGenericName, 2)
            Me.txtGenericName.ComputedValue = False
            Me.txtGenericName.CustomFormat = Nothing
            Me.txtGenericName.DataBoundControl = True
            Me.txtGenericName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtGenericName.EditingMode = True
            Me.txtGenericName.EndFindValue = Nothing
            Me.txtGenericName.FieldDescription = Nothing
            Me.txtGenericName.FieldName = Nothing
            Me.txtGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGenericName.FindEnabled = True
            Me.txtGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtGenericName.LinkedLabel = Nothing
            Me.txtGenericName.Location = New System.Drawing.Point(174, 116)
            Me.txtGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGenericName.MaximumValue = Nothing
            Me.txtGenericName.MinimumValue = Nothing
            Me.txtGenericName.Name = "txtGenericName"
            Me.txtGenericName.OldValue = ""
            Me.txtGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGenericName.Size = New System.Drawing.Size(466, 23)
            Me.txtGenericName.TabIndex = 4
            Me.txtGenericName.Translatable = False
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
            Me.TxtIdNo.LinkedLabel = Nothing
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
            'lblCode
            '
            Me.lblCode.AutoSize = True
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCode.Location = New System.Drawing.Point(1, 47)
            Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(41, 17)
            Me.lblCode.TabIndex = 2
            Me.lblCode.Text = "Code"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCode.Translatable = True
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblName.Location = New System.Drawing.Point(1, 72)
            Me.lblName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(45, 17)
            Me.lblName.TabIndex = 3
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblName.Translatable = True
            '
            'TxtItemDetailsCode
            '
            Me.TxtItemDetailsCode.BackColor = System.Drawing.Color.White
            Me.TxtItemDetailsCode.BegFindValue = Nothing
            Me.TxtItemDetailsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItemDetailsCode.ComputedValue = False
            Me.TxtItemDetailsCode.CustomFormat = Nothing
            Me.TxtItemDetailsCode.DataBoundControl = True
            Me.TxtItemDetailsCode.DisplayOnly = True
            Me.TxtItemDetailsCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtItemDetailsCode.EditingMode = True
            Me.TxtItemDetailsCode.EndFindValue = Nothing
            Me.TxtItemDetailsCode.FieldDescription = Nothing
            Me.TxtItemDetailsCode.FieldName = "Item_Code"
            Me.TxtItemDetailsCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsCode.FindEnabled = True
            Me.TxtItemDetailsCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItemDetailsCode.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsCode.LinkedLabel = Nothing
            Me.TxtItemDetailsCode.Location = New System.Drawing.Point(174, 47)
            Me.TxtItemDetailsCode.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsCode.MaximumValue = Nothing
            Me.TxtItemDetailsCode.MinimumValue = Nothing
            Me.TxtItemDetailsCode.Name = "TxtItemDetailsCode"
            Me.TxtItemDetailsCode.OldValue = Nothing
            Me.TxtItemDetailsCode.ReadOnly = True
            Me.TxtItemDetailsCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsCode.Size = New System.Drawing.Size(148, 23)
            Me.TxtItemDetailsCode.TabIndex = 1
            Me.TxtItemDetailsCode.Translatable = False
            '
            'TxtItemDetailsName
            '
            Me.TxtItemDetailsName.BackColor = System.Drawing.Color.White
            Me.TxtItemDetailsName.BegFindValue = Nothing
            Me.TxtItemDetailsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtItemDetailsName, 2)
            Me.TxtItemDetailsName.ComputedValue = False
            Me.TxtItemDetailsName.CustomFormat = Nothing
            Me.TxtItemDetailsName.DataBoundControl = True
            Me.TxtItemDetailsName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtItemDetailsName.EditingMode = True
            Me.TxtItemDetailsName.EndFindValue = Nothing
            Me.TxtItemDetailsName.FieldDescription = Nothing
            Me.TxtItemDetailsName.FieldName = Nothing
            Me.TxtItemDetailsName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsName.FindEnabled = True
            Me.TxtItemDetailsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItemDetailsName.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsName.LinkedLabel = Nothing
            Me.TxtItemDetailsName.Location = New System.Drawing.Point(174, 72)
            Me.TxtItemDetailsName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsName.MaximumValue = Nothing
            Me.TxtItemDetailsName.MinimumValue = Nothing
            Me.TxtItemDetailsName.Name = "TxtItemDetailsName"
            Me.TxtItemDetailsName.OldValue = Nothing
            Me.TxtItemDetailsName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsName.Size = New System.Drawing.Size(466, 23)
            Me.TxtItemDetailsName.TabIndex = 2
            Me.TxtItemDetailsName.Translatable = False
            '
            'cboPackageSize
            '
            Me.cboPackageSize.AutoSize = True
            Me.cboPackageSize.DisplayOnly = True
            Me.cboPackageSize.EditingMode = False
            Me.cboPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPackageSize.Location = New System.Drawing.Point(1, 295)
            Me.cboPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageSize.Name = "cboPackageSize"
            Me.cboPackageSize.Size = New System.Drawing.Size(94, 17)
            Me.cboPackageSize.TabIndex = 27
            Me.cboPackageSize.Text = "Package Size"
            Me.cboPackageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.cboPackageSize.Translatable = True
            '
            'lblPackageType
            '
            Me.lblPackageType.AutoSize = True
            Me.lblPackageType.DisplayOnly = True
            Me.lblPackageType.EditingMode = False
            Me.lblPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPackageType.Location = New System.Drawing.Point(1, 269)
            Me.lblPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPackageType.Name = "lblPackageType"
            Me.lblPackageType.Size = New System.Drawing.Size(99, 17)
            Me.lblPackageType.TabIndex = 25
            Me.lblPackageType.Text = "Package Type"
            Me.lblPackageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPackageType.Translatable = True
            '
            'lblUnitOfVolume
            '
            Me.lblUnitOfVolume.AutoSize = True
            Me.lblUnitOfVolume.DisplayOnly = True
            Me.lblUnitOfVolume.EditingMode = False
            Me.lblUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblUnitOfVolume.Location = New System.Drawing.Point(1, 243)
            Me.lblUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfVolume.Name = "lblUnitOfVolume"
            Me.lblUnitOfVolume.Size = New System.Drawing.Size(103, 17)
            Me.lblUnitOfVolume.TabIndex = 21
            Me.lblUnitOfVolume.Text = "Unit Of Volume"
            Me.lblUnitOfVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfVolume.Translatable = True
            '
            'lblVolume
            '
            Me.lblVolume.AutoSize = True
            Me.lblVolume.DisplayOnly = True
            Me.lblVolume.EditingMode = False
            Me.lblVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVolume.Location = New System.Drawing.Point(1, 218)
            Me.lblVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVolume.Name = "lblVolume"
            Me.lblVolume.Size = New System.Drawing.Size(55, 17)
            Me.lblVolume.TabIndex = 19
            Me.lblVolume.Text = "Volume"
            Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVolume.Translatable = True
            '
            'lblDosageForm
            '
            Me.lblDosageForm.AutoSize = True
            Me.lblDosageForm.DisplayOnly = True
            Me.lblDosageForm.EditingMode = False
            Me.lblDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDosageForm.Location = New System.Drawing.Point(1, 192)
            Me.lblDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDosageForm.Name = "lblDosageForm"
            Me.lblDosageForm.Size = New System.Drawing.Size(93, 17)
            Me.lblDosageForm.TabIndex = 29
            Me.lblDosageForm.Text = "Dosage Form"
            Me.lblDosageForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDosageForm.Translatable = True
            '
            'lblUnitOfStrength
            '
            Me.lblUnitOfStrength.AutoSize = True
            Me.lblUnitOfStrength.DisplayOnly = True
            Me.lblUnitOfStrength.EditingMode = False
            Me.lblUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblUnitOfStrength.Location = New System.Drawing.Point(1, 166)
            Me.lblUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfStrength.Name = "lblUnitOfStrength"
            Me.lblUnitOfStrength.Size = New System.Drawing.Size(107, 17)
            Me.lblUnitOfStrength.TabIndex = 17
            Me.lblUnitOfStrength.Text = "Unit of Strength"
            Me.lblUnitOfStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfStrength.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 141)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(100, 17)
            Me.CLabel1.TabIndex = 11
            Me.CLabel1.Text = "Strength value"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'lblGenericName
            '
            Me.lblGenericName.AutoSize = True
            Me.lblGenericName.DisplayOnly = True
            Me.lblGenericName.EditingMode = False
            Me.lblGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGenericName.Location = New System.Drawing.Point(1, 116)
            Me.lblGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGenericName.Name = "lblGenericName"
            Me.lblGenericName.Size = New System.Drawing.Size(99, 17)
            Me.lblGenericName.TabIndex = 4
            Me.lblGenericName.Text = "Generic Name"
            Me.lblGenericName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGenericName.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 97)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(126, 17)
            Me.CLabel2.TabIndex = 31
            Me.CLabel2.Text = "Prescription Drug?"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'txtPackageSize
            '
            Me.txtPackageSize.BackColor = System.Drawing.Color.White
            Me.txtPackageSize.BegFindValue = Nothing
            Me.txtPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPackageSize.ComputedValue = False
            Me.txtPackageSize.CustomFormat = Nothing
            Me.txtPackageSize.DataBoundControl = True
            Me.txtPackageSize.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPackageSize.EditingMode = True
            Me.txtPackageSize.EndFindValue = Nothing
            Me.txtPackageSize.FieldDescription = Nothing
            Me.txtPackageSize.FieldName = Nothing
            Me.txtPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPackageSize.FindEnabled = True
            Me.txtPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPackageSize.ForeColor = System.Drawing.Color.Black
            Me.txtPackageSize.LinkedLabel = Nothing
            Me.txtPackageSize.Location = New System.Drawing.Point(174, 295)
            Me.txtPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPackageSize.MaximumValue = Nothing
            Me.txtPackageSize.MinimumValue = Nothing
            Me.txtPackageSize.Name = "txtPackageSize"
            Me.txtPackageSize.OldValue = Nothing
            Me.txtPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPackageSize.Size = New System.Drawing.Size(148, 23)
            Me.txtPackageSize.TabIndex = 11
            Me.txtPackageSize.Translatable = False
            '
            'cboPackageType
            '
            Me.cboPackageType.BackColor = System.Drawing.Color.White
            Me.cboPackageType.BegFindValue = Nothing
            Me.cboPackageType.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboPackageType, 2)
            Me.cboPackageType.CurrentSearchTerm = ""
            Me.cboPackageType.DataValue = Nothing
            Me.cboPackageType.DefaultValue = Nothing
            Me.cboPackageType.DisplayMember = "Name"
            Me.cboPackageType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPackageType.EditingMode = True
            Me.cboPackageType.EndFindValue = Nothing
            Me.cboPackageType.FieldDescription = Nothing
            Me.cboPackageType.FieldName = Nothing
            Me.cboPackageType.FilterRule = Nothing
            Me.cboPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPackageType.FindEnabled = True
            Me.cboPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPackageType.ForeColor = System.Drawing.Color.Black
            Me.cboPackageType.FormattingEnabled = True
            Me.cboPackageType.HideWhenNotEditingOrAdding = False
            Me.cboPackageType.IgnoreCase = False
            Me.cboPackageType.IntegralHeight = False
            Me.cboPackageType.LinkedLabel = Nothing
            Me.cboPackageType.Location = New System.Drawing.Point(174, 269)
            Me.cboPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageType.Name = "cboPackageType"
            Me.cboPackageType.OldValue = 0
            Me.cboPackageType.OriginalDataSource = Nothing
            Me.cboPackageType.OriginalList = Nothing
            Me.cboPackageType.OverrideDropDownStyleList = False
            Me.cboPackageType.PreviousSearchTerm = Nothing
            Me.cboPackageType.PropertySelector = Nothing
            Me.cboPackageType.ReadOnlyCombo = False
            Me.cboPackageType.Size = New System.Drawing.Size(466, 24)
            Me.cboPackageType.SuggestBoxHeight = 200
            Me.cboPackageType.SuggestListOrderRule = Nothing
            Me.cboPackageType.TabIndex = 10
            Me.cboPackageType.TextToSearch = Nothing
            Me.cboPackageType.Translatable = False
            Me.cboPackageType.ValueIsMandatory = False
            Me.cboPackageType.ValueIsNullable = False
            Me.cboPackageType.ValueIsNumeric = False
            Me.cboPackageType.ValueMember = "Name"
            '
            'cboUnitOfVolume
            '
            Me.cboUnitOfVolume.BackColor = System.Drawing.Color.White
            Me.cboUnitOfVolume.BegFindValue = Nothing
            Me.cboUnitOfVolume.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboUnitOfVolume, 2)
            Me.cboUnitOfVolume.CurrentSearchTerm = ""
            Me.cboUnitOfVolume.DataValue = Nothing
            Me.cboUnitOfVolume.DefaultValue = Nothing
            Me.cboUnitOfVolume.DisplayMember = "Name"
            Me.cboUnitOfVolume.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboUnitOfVolume.EditingMode = True
            Me.cboUnitOfVolume.EndFindValue = Nothing
            Me.cboUnitOfVolume.FieldDescription = Nothing
            Me.cboUnitOfVolume.FieldName = Nothing
            Me.cboUnitOfVolume.FilterRule = Nothing
            Me.cboUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfVolume.FindEnabled = True
            Me.cboUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUnitOfVolume.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfVolume.FormattingEnabled = True
            Me.cboUnitOfVolume.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfVolume.IgnoreCase = False
            Me.cboUnitOfVolume.IntegralHeight = False
            Me.cboUnitOfVolume.LinkedLabel = Nothing
            Me.cboUnitOfVolume.Location = New System.Drawing.Point(174, 243)
            Me.cboUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfVolume.Name = "cboUnitOfVolume"
            Me.cboUnitOfVolume.OldValue = 0
            Me.cboUnitOfVolume.OriginalDataSource = Nothing
            Me.cboUnitOfVolume.OriginalList = Nothing
            Me.cboUnitOfVolume.OverrideDropDownStyleList = False
            Me.cboUnitOfVolume.PreviousSearchTerm = Nothing
            Me.cboUnitOfVolume.PropertySelector = Nothing
            Me.cboUnitOfVolume.ReadOnlyCombo = False
            Me.cboUnitOfVolume.Size = New System.Drawing.Size(466, 24)
            Me.cboUnitOfVolume.SuggestBoxHeight = 200
            Me.cboUnitOfVolume.SuggestListOrderRule = Nothing
            Me.cboUnitOfVolume.TabIndex = 9
            Me.cboUnitOfVolume.TextToSearch = Nothing
            Me.cboUnitOfVolume.Translatable = False
            Me.cboUnitOfVolume.ValueIsMandatory = False
            Me.cboUnitOfVolume.ValueIsNullable = False
            Me.cboUnitOfVolume.ValueIsNumeric = False
            Me.cboUnitOfVolume.ValueMember = "Name"
            '
            'txtVolume
            '
            Me.txtVolume.BackColor = System.Drawing.Color.White
            Me.txtVolume.BegFindValue = Nothing
            Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVolume.ComputedValue = False
            Me.txtVolume.CustomFormat = Nothing
            Me.txtVolume.DataBoundControl = True
            Me.txtVolume.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtVolume.EditingMode = True
            Me.txtVolume.EndFindValue = Nothing
            Me.txtVolume.FieldDescription = Nothing
            Me.txtVolume.FieldName = Nothing
            Me.txtVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVolume.FindEnabled = True
            Me.txtVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVolume.ForeColor = System.Drawing.Color.Black
            Me.txtVolume.LinkedLabel = Nothing
            Me.txtVolume.Location = New System.Drawing.Point(174, 218)
            Me.txtVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVolume.MaximumValue = Nothing
            Me.txtVolume.MinimumValue = Nothing
            Me.txtVolume.Name = "txtVolume"
            Me.txtVolume.OldValue = Nothing
            Me.txtVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVolume.Size = New System.Drawing.Size(148, 23)
            Me.txtVolume.TabIndex = 8
            Me.txtVolume.Translatable = False
            '
            'cboDosageForm
            '
            Me.cboDosageForm.BackColor = System.Drawing.Color.White
            Me.cboDosageForm.BegFindValue = Nothing
            Me.cboDosageForm.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDosageForm, 2)
            Me.cboDosageForm.CurrentSearchTerm = ""
            Me.cboDosageForm.DataValue = Nothing
            Me.cboDosageForm.DefaultValue = Nothing
            Me.cboDosageForm.DisplayMember = "Name"
            Me.cboDosageForm.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDosageForm.EditingMode = True
            Me.cboDosageForm.EndFindValue = Nothing
            Me.cboDosageForm.FieldDescription = Nothing
            Me.cboDosageForm.FieldName = Nothing
            Me.cboDosageForm.FilterRule = Nothing
            Me.cboDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDosageForm.FindEnabled = True
            Me.cboDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDosageForm.ForeColor = System.Drawing.Color.Black
            Me.cboDosageForm.FormattingEnabled = True
            Me.cboDosageForm.HideWhenNotEditingOrAdding = False
            Me.cboDosageForm.IgnoreCase = False
            Me.cboDosageForm.IntegralHeight = False
            Me.cboDosageForm.LinkedLabel = Nothing
            Me.cboDosageForm.Location = New System.Drawing.Point(174, 192)
            Me.cboDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDosageForm.Name = "cboDosageForm"
            Me.cboDosageForm.OldValue = 0
            Me.cboDosageForm.OriginalDataSource = Nothing
            Me.cboDosageForm.OriginalList = Nothing
            Me.cboDosageForm.OverrideDropDownStyleList = False
            Me.cboDosageForm.PreviousSearchTerm = Nothing
            Me.cboDosageForm.PropertySelector = Nothing
            Me.cboDosageForm.ReadOnlyCombo = False
            Me.cboDosageForm.Size = New System.Drawing.Size(466, 24)
            Me.cboDosageForm.SuggestBoxHeight = 200
            Me.cboDosageForm.SuggestListOrderRule = Nothing
            Me.cboDosageForm.TabIndex = 7
            Me.cboDosageForm.TextToSearch = Nothing
            Me.cboDosageForm.Translatable = False
            Me.cboDosageForm.ValueIsMandatory = False
            Me.cboDosageForm.ValueIsNullable = False
            Me.cboDosageForm.ValueIsNumeric = False
            Me.cboDosageForm.ValueMember = "Name"
            '
            'cboUnitOfStrength
            '
            Me.cboUnitOfStrength.BackColor = System.Drawing.Color.White
            Me.cboUnitOfStrength.BegFindValue = Nothing
            Me.cboUnitOfStrength.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboUnitOfStrength, 2)
            Me.cboUnitOfStrength.CurrentSearchTerm = ""
            Me.cboUnitOfStrength.DataValue = Nothing
            Me.cboUnitOfStrength.DefaultValue = Nothing
            Me.cboUnitOfStrength.DisplayMember = "Name"
            Me.cboUnitOfStrength.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboUnitOfStrength.EditingMode = True
            Me.cboUnitOfStrength.EndFindValue = Nothing
            Me.cboUnitOfStrength.FieldDescription = Nothing
            Me.cboUnitOfStrength.FieldName = Nothing
            Me.cboUnitOfStrength.FilterRule = Nothing
            Me.cboUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfStrength.FindEnabled = True
            Me.cboUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUnitOfStrength.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfStrength.FormattingEnabled = True
            Me.cboUnitOfStrength.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfStrength.IgnoreCase = False
            Me.cboUnitOfStrength.IntegralHeight = False
            Me.cboUnitOfStrength.LinkedLabel = Nothing
            Me.cboUnitOfStrength.Location = New System.Drawing.Point(174, 166)
            Me.cboUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfStrength.Name = "cboUnitOfStrength"
            Me.cboUnitOfStrength.OldValue = 0
            Me.cboUnitOfStrength.OriginalDataSource = Nothing
            Me.cboUnitOfStrength.OriginalList = Nothing
            Me.cboUnitOfStrength.OverrideDropDownStyleList = False
            Me.cboUnitOfStrength.PreviousSearchTerm = Nothing
            Me.cboUnitOfStrength.PropertySelector = Nothing
            Me.cboUnitOfStrength.ReadOnlyCombo = False
            Me.cboUnitOfStrength.Size = New System.Drawing.Size(466, 24)
            Me.cboUnitOfStrength.SuggestBoxHeight = 200
            Me.cboUnitOfStrength.SuggestListOrderRule = Nothing
            Me.cboUnitOfStrength.TabIndex = 6
            Me.cboUnitOfStrength.TextToSearch = Nothing
            Me.cboUnitOfStrength.Translatable = False
            Me.cboUnitOfStrength.ValueIsMandatory = False
            Me.cboUnitOfStrength.ValueIsNullable = False
            Me.cboUnitOfStrength.ValueIsNumeric = False
            Me.cboUnitOfStrength.ValueMember = "Name"
            '
            'txtStrengthValue
            '
            Me.txtStrengthValue.BackColor = System.Drawing.Color.White
            Me.txtStrengthValue.BegFindValue = Nothing
            Me.txtStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStrengthValue.ComputedValue = False
            Me.txtStrengthValue.CustomFormat = Nothing
            Me.txtStrengthValue.DataBoundControl = True
            Me.txtStrengthValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtStrengthValue.EditingMode = True
            Me.txtStrengthValue.EndFindValue = Nothing
            Me.txtStrengthValue.FieldDescription = Nothing
            Me.txtStrengthValue.FieldName = Nothing
            Me.txtStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStrengthValue.FindEnabled = True
            Me.txtStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStrengthValue.ForeColor = System.Drawing.Color.Black
            Me.txtStrengthValue.LinkedLabel = Nothing
            Me.txtStrengthValue.Location = New System.Drawing.Point(174, 141)
            Me.txtStrengthValue.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStrengthValue.MaximumValue = Nothing
            Me.txtStrengthValue.MinimumValue = Nothing
            Me.txtStrengthValue.Name = "txtStrengthValue"
            Me.txtStrengthValue.OldValue = Nothing
            Me.txtStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStrengthValue.Size = New System.Drawing.Size(148, 23)
            Me.txtStrengthValue.TabIndex = 5
            Me.txtStrengthValue.Translatable = False
            '
            'chkPrescriptionDrug
            '
            Me.chkPrescriptionDrug.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkPrescriptionDrug.AutoCheck = False
            Me.chkPrescriptionDrug.BackColor = System.Drawing.Color.White
            Me.chkPrescriptionDrug.BegFindValue = Nothing
            Me.chkPrescriptionDrug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPrescriptionDrug.DisplayOnly = False
            Me.chkPrescriptionDrug.EditingMode = False
            Me.chkPrescriptionDrug.EndFindValue = Nothing
            Me.chkPrescriptionDrug.FieldDescription = Nothing
            Me.chkPrescriptionDrug.FieldName = Nothing
            Me.chkPrescriptionDrug.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPrescriptionDrug.FindEnabled = True
            Me.chkPrescriptionDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPrescriptionDrug.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkPrescriptionDrug.ForeColor = System.Drawing.Color.Black
            Me.chkPrescriptionDrug.IFindableControl_FindEnabled = False
            Me.chkPrescriptionDrug.IgnoreCase = False
            Me.chkPrescriptionDrug.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkPrescriptionDrug.LinkedLabel = Nothing
            Me.chkPrescriptionDrug.Location = New System.Drawing.Point(174, 97)
            Me.chkPrescriptionDrug.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPrescriptionDrug.Name = "chkPrescriptionDrug"
            Me.chkPrescriptionDrug.NoLabel = False
            Me.chkPrescriptionDrug.OldValue = ""
            Me.chkPrescriptionDrug.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPrescriptionDrug.Size = New System.Drawing.Size(13, 13)
            Me.chkPrescriptionDrug.TabIndex = 3
            Me.chkPrescriptionDrug.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPrescriptionDrug.Translatable = False
            Me.chkPrescriptionDrug.UseVisualStyleBackColor = False
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 320)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(155, 17)
            Me.CLabel3.TabIndex = 34
            Me.CLabel3.Text = "Route of Administration"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'txtRegistrationNo
            '
            Me.txtRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtRegistrationNo.BegFindValue = Nothing
            Me.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRegistrationNo.ComputedValue = False
            Me.txtRegistrationNo.CustomFormat = Nothing
            Me.txtRegistrationNo.DataBoundControl = True
            Me.txtRegistrationNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtRegistrationNo.EditingMode = True
            Me.txtRegistrationNo.EndFindValue = Nothing
            Me.txtRegistrationNo.FieldDescription = Nothing
            Me.txtRegistrationNo.FieldName = Nothing
            Me.txtRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRegistrationNo.FindEnabled = True
            Me.txtRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtRegistrationNo.LinkedLabel = Nothing
            Me.txtRegistrationNo.Location = New System.Drawing.Point(174, 346)
            Me.txtRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRegistrationNo.MaximumValue = Nothing
            Me.txtRegistrationNo.MinimumValue = Nothing
            Me.txtRegistrationNo.Name = "txtRegistrationNo"
            Me.txtRegistrationNo.OldValue = ""
            Me.txtRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRegistrationNo.Size = New System.Drawing.Size(148, 23)
            Me.txtRegistrationNo.TabIndex = 13
            Me.txtRegistrationNo.Translatable = False
            '
            'lblRegistrationCode
            '
            Me.lblRegistrationCode.AutoSize = True
            Me.lblRegistrationCode.DisplayOnly = True
            Me.lblRegistrationCode.EditingMode = False
            Me.lblRegistrationCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRegistrationCode.Location = New System.Drawing.Point(1, 346)
            Me.lblRegistrationCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRegistrationCode.Name = "lblRegistrationCode"
            Me.lblRegistrationCode.Size = New System.Drawing.Size(138, 17)
            Me.lblRegistrationCode.TabIndex = 33
            Me.lblRegistrationCode.Text = "Registration Number"
            Me.lblRegistrationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRegistrationCode.Translatable = True
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
            Me.txtGTIN.DisplayOnly = True
            Me.txtGTIN.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Nothing
            Me.txtGTIN.Location = New System.Drawing.Point(174, 27)
            Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = ""
            Me.txtGTIN.ReadOnly = True
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Size = New System.Drawing.Size(148, 23)
            Me.txtGTIN.TabIndex = 35
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
            Me.cboItemFinder.TabIndex = 37
            Me.cboItemFinder.TextToSearch = Nothing
            Me.cboItemFinder.Translatable = False
            Me.cboItemFinder.ValueIsMandatory = False
            Me.cboItemFinder.ValueIsNullable = False
            Me.cboItemFinder.ValueIsNumeric = False
            Me.cboItemFinder.ValueMember = "Name"
            '
            'ItemDetailsEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(663, 526)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "ItemDetailsEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents cboUnitOfStrength As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboPackageSize As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPackageType As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblUnitOfVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblUnitOfStrength As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboPackageType As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboUnitOfVolume As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents txtVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboDosageForm As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkPrescriptionDrug As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboRouteOfAdministration As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents txtRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblRegistrationCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CaComboBox2 As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboItemFinder As Libraries.CBaseControlsLibrary.CaComboBox
    End Class
End Namespace