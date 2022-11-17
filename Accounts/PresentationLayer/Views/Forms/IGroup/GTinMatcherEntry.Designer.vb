Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GTinMatcherEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GTinMatcherEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboItemFinder = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.btnScanQrCode = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.EventLog1 = New System.Diagnostics.EventLog()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItemDetailsCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPacking = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPack1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtpack2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtpack3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItemDetailsName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGenericName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRegistrationCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDosageForm = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDosageForm = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPackageType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPackageType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboPackageSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPackageSize = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.bnDrugList = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
            Me.bsDrugList = New System.Windows.Forms.BindingSource(Me.components)
            Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
            Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
            Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
            Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugGTin = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugTradeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugDosageForm = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel13 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel14 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel15 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel16 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugPackageType = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel17 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugPackageSize = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel18 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewDrugs = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblSearcher = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPrice_Cash = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPrice_Cash = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.bnDrugList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.bnDrugList.SuspendLayout()
            CType(Me.bsDrugList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.TxtIdNo.Location = New System.Drawing.Point(106, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = ""
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(86, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(103, 23)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblGTIN
            '
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            Me.lblGTIN.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGTIN.Location = New System.Drawing.Point(1, 51)
            Me.lblGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGTIN.Name = "lblGTIN"
            Me.lblGTIN.Size = New System.Drawing.Size(103, 23)
            Me.lblGTIN.TabIndex = 36
            Me.lblGTIN.Text = "GTIN"
            Me.lblGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGTIN.Translatable = True
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
            Me.cboItemFinder.Location = New System.Drawing.Point(110, 55)
            Me.cboItemFinder.Margin = New System.Windows.Forms.Padding(1)
            Me.cboItemFinder.Name = "cboItemFinder"
            Me.cboItemFinder.OldValue = 0
            Me.cboItemFinder.OriginalDataSource = Nothing
            Me.cboItemFinder.OriginalList = Nothing
            Me.cboItemFinder.OverrideDropDownStyleList = False
            Me.cboItemFinder.PreviousSearchTerm = Nothing
            Me.cboItemFinder.PropertySelector = Nothing
            Me.cboItemFinder.ReadOnlyCombo = False
            Me.cboItemFinder.Size = New System.Drawing.Size(358, 24)
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
            'btnScanQrCode
            '
            Me.btnScanQrCode.DesignerSelected = False
            Me.CFlowLayout1.SetFlowBreak(Me.btnScanQrCode, True)
            Me.btnScanQrCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnScanQrCode.ImageIndex = 0
            Me.btnScanQrCode.Location = New System.Drawing.Point(255, 50)
            Me.btnScanQrCode.Margin = New System.Windows.Forms.Padding(0)
            Me.btnScanQrCode.Name = "btnScanQrCode"
            Me.btnScanQrCode.OriginalImageName = Nothing
            Me.btnScanQrCode.SecurityKey = ""
            Me.btnScanQrCode.Size = New System.Drawing.Size(90, 20)
            Me.btnScanQrCode.TabIndex = 39
            Me.btnScanQrCode.Text = "Scan Qr Code"
            Me.btnScanQrCode.TextMargin = New System.Windows.Forms.Padding(0)
            '
            'EventLog1
            '
            Me.EventLog1.SynchronizingObject = Me
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblCode)
            Me.CFlowLayout1.Controls.Add(Me.TxtItemDetailsCode)
            Me.CFlowLayout1.Controls.Add(Me.lblPrice_Cash)
            Me.CFlowLayout1.Controls.Add(Me.txtPrice_Cash)
            Me.CFlowLayout1.Controls.Add(Me.lblPacking)
            Me.CFlowLayout1.Controls.Add(Me.txtPack1)
            Me.CFlowLayout1.Controls.Add(Me.txtpack2)
            Me.CFlowLayout1.Controls.Add(Me.txtpack3)
            Me.CFlowLayout1.Controls.Add(Me.lblGTIN)
            Me.CFlowLayout1.Controls.Add(Me.txtGTIN)
            Me.CFlowLayout1.Controls.Add(Me.btnScanQrCode)
            Me.CFlowLayout1.Controls.Add(Me.lblName)
            Me.CFlowLayout1.Controls.Add(Me.TxtItemDetailsName)
            Me.CFlowLayout1.Controls.Add(Me.lblGenericName)
            Me.CFlowLayout1.Controls.Add(Me.txtGenericName)
            Me.CFlowLayout1.Controls.Add(Me.lblRegistrationCode)
            Me.CFlowLayout1.Controls.Add(Me.txtRegistrationNo)
            Me.CFlowLayout1.Controls.Add(Me.lblDosageForm)
            Me.CFlowLayout1.Controls.Add(Me.cboDosageForm)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.txtStrengthValue)
            Me.CFlowLayout1.Controls.Add(Me.lblUnitOfStrength)
            Me.CFlowLayout1.Controls.Add(Me.cboUnitOfStrength)
            Me.CFlowLayout1.Controls.Add(Me.lblVolume)
            Me.CFlowLayout1.Controls.Add(Me.txtVolume)
            Me.CFlowLayout1.Controls.Add(Me.lblUnitOfVolume)
            Me.CFlowLayout1.Controls.Add(Me.cboUnitOfVolume)
            Me.CFlowLayout1.Controls.Add(Me.lblPackageType)
            Me.CFlowLayout1.Controls.Add(Me.cboPackageType)
            Me.CFlowLayout1.Controls.Add(Me.cboPackageSize)
            Me.CFlowLayout1.Controls.Add(Me.txtPackageSize)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.cboRouteOfAdministration)
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Location = New System.Drawing.Point(4, 84)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(471, 360)
            Me.CFlowLayout1.TabIndex = 6
            '
            'lblCode
            '
            Me.lblCode.AutoSize = True
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCode.Location = New System.Drawing.Point(194, 1)
            Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(31, 16)
            Me.lblCode.TabIndex = 39
            Me.lblCode.Text = "Code"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCode.Translatable = True
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
            Me.TxtItemDetailsCode.EditingMode = True
            Me.TxtItemDetailsCode.EndFindValue = Nothing
            Me.TxtItemDetailsCode.FieldDescription = Nothing
            Me.TxtItemDetailsCode.FieldName = "Item_Code"
            Me.TxtItemDetailsCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsCode.FindEnabled = True
            Me.TxtItemDetailsCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItemDetailsCode.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsCode.LinkedLabel = Nothing
            Me.TxtItemDetailsCode.Location = New System.Drawing.Point(227, 1)
            Me.TxtItemDetailsCode.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsCode.MaximumValue = Nothing
            Me.TxtItemDetailsCode.MinimumValue = Nothing
            Me.TxtItemDetailsCode.Name = "TxtItemDetailsCode"
            Me.TxtItemDetailsCode.OldValue = Nothing
            Me.TxtItemDetailsCode.ReadOnly = True
            Me.TxtItemDetailsCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsCode.Size = New System.Drawing.Size(74, 23)
            Me.TxtItemDetailsCode.TabIndex = 38
            Me.TxtItemDetailsCode.Translatable = False
            '
            'lblPacking
            '
            Me.lblPacking.DisplayOnly = True
            Me.lblPacking.EditingMode = False
            Me.lblPacking.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPacking.Location = New System.Drawing.Point(1, 26)
            Me.lblPacking.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPacking.Name = "lblPacking"
            Me.lblPacking.Size = New System.Drawing.Size(103, 23)
            Me.lblPacking.TabIndex = 75
            Me.lblPacking.Text = "Packing"
            Me.lblPacking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPacking.Translatable = True
            '
            'txtPack1
            '
            Me.txtPack1.BackColor = System.Drawing.Color.White
            Me.txtPack1.BegFindValue = Nothing
            Me.txtPack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPack1.ComputedValue = False
            Me.txtPack1.CustomFormat = Nothing
            Me.txtPack1.DataBoundControl = True
            Me.txtPack1.DisplayOnly = True
            Me.txtPack1.EditingMode = True
            Me.txtPack1.EndFindValue = Nothing
            Me.txtPack1.FieldDescription = Nothing
            Me.txtPack1.FieldName = "Item_Code"
            Me.txtPack1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPack1.FindEnabled = True
            Me.txtPack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPack1.ForeColor = System.Drawing.Color.Black
            Me.txtPack1.LinkedLabel = Nothing
            Me.txtPack1.Location = New System.Drawing.Point(106, 26)
            Me.txtPack1.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPack1.MaximumValue = Nothing
            Me.txtPack1.MinimumValue = Nothing
            Me.txtPack1.Name = "txtPack1"
            Me.txtPack1.OldValue = Nothing
            Me.txtPack1.ReadOnly = True
            Me.txtPack1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPack1.Size = New System.Drawing.Size(86, 23)
            Me.txtPack1.TabIndex = 72
            Me.txtPack1.Translatable = False
            '
            'txtpack2
            '
            Me.txtpack2.BackColor = System.Drawing.Color.White
            Me.txtpack2.BegFindValue = Nothing
            Me.txtpack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtpack2.ComputedValue = False
            Me.txtpack2.CustomFormat = Nothing
            Me.txtpack2.DataBoundControl = True
            Me.txtpack2.DisplayOnly = True
            Me.txtpack2.EditingMode = True
            Me.txtpack2.EndFindValue = Nothing
            Me.txtpack2.FieldDescription = Nothing
            Me.txtpack2.FieldName = "Item_Code"
            Me.txtpack2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtpack2.FindEnabled = True
            Me.txtpack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtpack2.ForeColor = System.Drawing.Color.Black
            Me.txtpack2.LinkedLabel = Nothing
            Me.txtpack2.Location = New System.Drawing.Point(194, 26)
            Me.txtpack2.Margin = New System.Windows.Forms.Padding(1)
            Me.txtpack2.MaximumValue = Nothing
            Me.txtpack2.MinimumValue = Nothing
            Me.txtpack2.Name = "txtpack2"
            Me.txtpack2.OldValue = Nothing
            Me.txtpack2.ReadOnly = True
            Me.txtpack2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtpack2.Size = New System.Drawing.Size(86, 23)
            Me.txtpack2.TabIndex = 73
            Me.txtpack2.Translatable = False
            '
            'txtpack3
            '
            Me.txtpack3.BackColor = System.Drawing.Color.White
            Me.txtpack3.BegFindValue = Nothing
            Me.txtpack3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtpack3.ComputedValue = False
            Me.txtpack3.CustomFormat = Nothing
            Me.txtpack3.DataBoundControl = True
            Me.txtpack3.DisplayOnly = True
            Me.txtpack3.EditingMode = True
            Me.txtpack3.EndFindValue = Nothing
            Me.txtpack3.FieldDescription = Nothing
            Me.txtpack3.FieldName = "Item_Code"
            Me.txtpack3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtpack3.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtpack3, True)
            Me.txtpack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtpack3.ForeColor = System.Drawing.Color.Black
            Me.txtpack3.LinkedLabel = Nothing
            Me.txtpack3.Location = New System.Drawing.Point(282, 26)
            Me.txtpack3.Margin = New System.Windows.Forms.Padding(1)
            Me.txtpack3.MaximumValue = Nothing
            Me.txtpack3.MinimumValue = Nothing
            Me.txtpack3.Name = "txtpack3"
            Me.txtpack3.OldValue = Nothing
            Me.txtpack3.ReadOnly = True
            Me.txtpack3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtpack3.Size = New System.Drawing.Size(86, 23)
            Me.txtpack3.TabIndex = 74
            Me.txtpack3.Translatable = False
            '
            'txtGTIN
            '
            Me.txtGTIN.BackColor = System.Drawing.Color.White
            Me.txtGTIN.BegFindValue = Nothing
            Me.txtGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGTIN.ComputedValue = False
            Me.txtGTIN.CustomFormat = Nothing
            Me.txtGTIN.DataBoundControl = True
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Nothing
            Me.txtGTIN.Location = New System.Drawing.Point(106, 51)
            Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = ""
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Size = New System.Drawing.Size(148, 23)
            Me.txtGTIN.TabIndex = 37
            Me.txtGTIN.Translatable = False
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.Location = New System.Drawing.Point(1, 76)
            Me.lblName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(103, 23)
            Me.lblName.TabIndex = 41
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblName.Translatable = True
            '
            'TxtItemDetailsName
            '
            Me.TxtItemDetailsName.BackColor = System.Drawing.Color.White
            Me.TxtItemDetailsName.BegFindValue = Nothing
            Me.TxtItemDetailsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItemDetailsName.ComputedValue = False
            Me.TxtItemDetailsName.CustomFormat = Nothing
            Me.TxtItemDetailsName.DataBoundControl = True
            Me.TxtItemDetailsName.EditingMode = True
            Me.TxtItemDetailsName.EndFindValue = Nothing
            Me.TxtItemDetailsName.FieldDescription = Nothing
            Me.TxtItemDetailsName.FieldName = Nothing
            Me.TxtItemDetailsName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtItemDetailsName, True)
            Me.TxtItemDetailsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItemDetailsName.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsName.LinkedLabel = Nothing
            Me.TxtItemDetailsName.Location = New System.Drawing.Point(106, 76)
            Me.TxtItemDetailsName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsName.MaximumValue = Nothing
            Me.TxtItemDetailsName.MinimumValue = Nothing
            Me.TxtItemDetailsName.Name = "TxtItemDetailsName"
            Me.TxtItemDetailsName.OldValue = Nothing
            Me.TxtItemDetailsName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsName.Size = New System.Drawing.Size(358, 23)
            Me.TxtItemDetailsName.TabIndex = 40
            Me.TxtItemDetailsName.Translatable = False
            '
            'lblGenericName
            '
            Me.lblGenericName.DisplayOnly = True
            Me.lblGenericName.EditingMode = False
            Me.lblGenericName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGenericName.Location = New System.Drawing.Point(1, 101)
            Me.lblGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGenericName.Name = "lblGenericName"
            Me.lblGenericName.Size = New System.Drawing.Size(103, 23)
            Me.lblGenericName.TabIndex = 44
            Me.lblGenericName.Text = "Generic Name"
            Me.lblGenericName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGenericName.Translatable = True
            '
            'txtGenericName
            '
            Me.txtGenericName.BackColor = System.Drawing.Color.White
            Me.txtGenericName.BegFindValue = Nothing
            Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGenericName.ComputedValue = False
            Me.txtGenericName.CustomFormat = Nothing
            Me.txtGenericName.DataBoundControl = True
            Me.txtGenericName.EditingMode = True
            Me.txtGenericName.EndFindValue = Nothing
            Me.txtGenericName.FieldDescription = Nothing
            Me.txtGenericName.FieldName = Nothing
            Me.txtGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGenericName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtGenericName, True)
            Me.txtGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtGenericName.LinkedLabel = Nothing
            Me.txtGenericName.Location = New System.Drawing.Point(106, 101)
            Me.txtGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGenericName.MaximumValue = Nothing
            Me.txtGenericName.MinimumValue = Nothing
            Me.txtGenericName.Name = "txtGenericName"
            Me.txtGenericName.OldValue = ""
            Me.txtGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGenericName.Size = New System.Drawing.Size(358, 23)
            Me.txtGenericName.TabIndex = 43
            Me.txtGenericName.Translatable = False
            '
            'lblRegistrationCode
            '
            Me.lblRegistrationCode.DisplayOnly = True
            Me.lblRegistrationCode.EditingMode = False
            Me.lblRegistrationCode.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRegistrationCode.Location = New System.Drawing.Point(1, 126)
            Me.lblRegistrationCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRegistrationCode.Name = "lblRegistrationCode"
            Me.lblRegistrationCode.Size = New System.Drawing.Size(103, 23)
            Me.lblRegistrationCode.TabIndex = 62
            Me.lblRegistrationCode.Text = "Registration Number"
            Me.lblRegistrationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRegistrationCode.Translatable = True
            '
            'txtRegistrationNo
            '
            Me.txtRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtRegistrationNo.BegFindValue = Nothing
            Me.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRegistrationNo.ComputedValue = False
            Me.txtRegistrationNo.CustomFormat = Nothing
            Me.txtRegistrationNo.DataBoundControl = True
            Me.txtRegistrationNo.EditingMode = True
            Me.txtRegistrationNo.EndFindValue = Nothing
            Me.txtRegistrationNo.FieldDescription = Nothing
            Me.txtRegistrationNo.FieldName = Nothing
            Me.txtRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRegistrationNo.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtRegistrationNo, True)
            Me.txtRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtRegistrationNo.LinkedLabel = Nothing
            Me.txtRegistrationNo.Location = New System.Drawing.Point(106, 126)
            Me.txtRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRegistrationNo.MaximumValue = Nothing
            Me.txtRegistrationNo.MinimumValue = Nothing
            Me.txtRegistrationNo.Name = "txtRegistrationNo"
            Me.txtRegistrationNo.OldValue = ""
            Me.txtRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRegistrationNo.Size = New System.Drawing.Size(148, 23)
            Me.txtRegistrationNo.TabIndex = 69
            Me.txtRegistrationNo.Translatable = False
            '
            'lblDosageForm
            '
            Me.lblDosageForm.DisplayOnly = True
            Me.lblDosageForm.EditingMode = False
            Me.lblDosageForm.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDosageForm.Location = New System.Drawing.Point(1, 151)
            Me.lblDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDosageForm.Name = "lblDosageForm"
            Me.lblDosageForm.Size = New System.Drawing.Size(103, 23)
            Me.lblDosageForm.TabIndex = 60
            Me.lblDosageForm.Text = "Dosage Form"
            Me.lblDosageForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDosageForm.Translatable = True
            '
            'cboDosageForm
            '
            Me.cboDosageForm.BackColor = System.Drawing.Color.White
            Me.cboDosageForm.BegFindValue = Nothing
            Me.cboDosageForm.ChangingSearchValueOnly = False
            Me.cboDosageForm.CurrentSearchTerm = ""
            Me.cboDosageForm.DataValue = Nothing
            Me.cboDosageForm.DefaultValue = Nothing
            Me.cboDosageForm.DisplayMember = "Name"
            Me.cboDosageForm.EditingMode = True
            Me.cboDosageForm.EndFindValue = Nothing
            Me.cboDosageForm.FieldDescription = Nothing
            Me.cboDosageForm.FieldName = Nothing
            Me.cboDosageForm.FilterRule = Nothing
            Me.cboDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDosageForm.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboDosageForm, True)
            Me.cboDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDosageForm.ForeColor = System.Drawing.Color.Black
            Me.cboDosageForm.FormattingEnabled = True
            Me.cboDosageForm.HideWhenNotEditingOrAdding = False
            Me.cboDosageForm.IgnoreCase = False
            Me.cboDosageForm.IntegralHeight = False
            Me.cboDosageForm.LinkedLabel = Nothing
            Me.cboDosageForm.Location = New System.Drawing.Point(106, 151)
            Me.cboDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDosageForm.Name = "cboDosageForm"
            Me.cboDosageForm.OldValue = 0
            Me.cboDosageForm.OriginalDataSource = Nothing
            Me.cboDosageForm.OriginalList = Nothing
            Me.cboDosageForm.OverrideDropDownStyleList = False
            Me.cboDosageForm.PreviousSearchTerm = Nothing
            Me.cboDosageForm.PropertySelector = Nothing
            Me.cboDosageForm.ReadOnlyCombo = False
            Me.cboDosageForm.Size = New System.Drawing.Size(358, 24)
            Me.cboDosageForm.SuggestBoxHeight = 200
            Me.cboDosageForm.SuggestListOrderRule = Nothing
            Me.cboDosageForm.TabIndex = 65
            Me.cboDosageForm.TextToSearch = Nothing
            Me.cboDosageForm.Translatable = False
            Me.cboDosageForm.ValueIsMandatory = False
            Me.cboDosageForm.ValueIsNullable = False
            Me.cboDosageForm.ValueIsNumeric = False
            Me.cboDosageForm.ValueMember = "Name"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel1.Location = New System.Drawing.Point(1, 177)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(103, 23)
            Me.CLabel1.TabIndex = 51
            Me.CLabel1.Text = "Strength value"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtStrengthValue
            '
            Me.txtStrengthValue.BackColor = System.Drawing.Color.White
            Me.txtStrengthValue.BegFindValue = Nothing
            Me.txtStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStrengthValue.ComputedValue = False
            Me.txtStrengthValue.CustomFormat = Nothing
            Me.txtStrengthValue.DataBoundControl = True
            Me.txtStrengthValue.EditingMode = True
            Me.txtStrengthValue.EndFindValue = Nothing
            Me.txtStrengthValue.FieldDescription = Nothing
            Me.txtStrengthValue.FieldName = Nothing
            Me.txtStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStrengthValue.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtStrengthValue, True)
            Me.txtStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStrengthValue.ForeColor = System.Drawing.Color.Black
            Me.txtStrengthValue.LinkedLabel = Nothing
            Me.txtStrengthValue.Location = New System.Drawing.Point(106, 177)
            Me.txtStrengthValue.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStrengthValue.MaximumValue = Nothing
            Me.txtStrengthValue.MinimumValue = Nothing
            Me.txtStrengthValue.Name = "txtStrengthValue"
            Me.txtStrengthValue.OldValue = Nothing
            Me.txtStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStrengthValue.Size = New System.Drawing.Size(148, 23)
            Me.txtStrengthValue.TabIndex = 71
            Me.txtStrengthValue.Translatable = False
            '
            'lblUnitOfStrength
            '
            Me.lblUnitOfStrength.DisplayOnly = True
            Me.lblUnitOfStrength.EditingMode = False
            Me.lblUnitOfStrength.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitOfStrength.Location = New System.Drawing.Point(1, 202)
            Me.lblUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfStrength.Name = "lblUnitOfStrength"
            Me.lblUnitOfStrength.Size = New System.Drawing.Size(103, 23)
            Me.lblUnitOfStrength.TabIndex = 55
            Me.lblUnitOfStrength.Text = "Unit of Strength"
            Me.lblUnitOfStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfStrength.Translatable = True
            '
            'cboUnitOfStrength
            '
            Me.cboUnitOfStrength.BackColor = System.Drawing.Color.White
            Me.cboUnitOfStrength.BegFindValue = Nothing
            Me.cboUnitOfStrength.ChangingSearchValueOnly = False
            Me.cboUnitOfStrength.CurrentSearchTerm = ""
            Me.cboUnitOfStrength.DataValue = Nothing
            Me.cboUnitOfStrength.DefaultValue = Nothing
            Me.cboUnitOfStrength.DisplayMember = "Name"
            Me.cboUnitOfStrength.EditingMode = True
            Me.cboUnitOfStrength.EndFindValue = Nothing
            Me.cboUnitOfStrength.FieldDescription = Nothing
            Me.cboUnitOfStrength.FieldName = Nothing
            Me.cboUnitOfStrength.FilterRule = Nothing
            Me.cboUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfStrength.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboUnitOfStrength, True)
            Me.cboUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUnitOfStrength.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfStrength.FormattingEnabled = True
            Me.cboUnitOfStrength.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfStrength.IgnoreCase = False
            Me.cboUnitOfStrength.IntegralHeight = False
            Me.cboUnitOfStrength.LinkedLabel = Nothing
            Me.cboUnitOfStrength.Location = New System.Drawing.Point(106, 202)
            Me.cboUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfStrength.Name = "cboUnitOfStrength"
            Me.cboUnitOfStrength.OldValue = 0
            Me.cboUnitOfStrength.OriginalDataSource = Nothing
            Me.cboUnitOfStrength.OriginalList = Nothing
            Me.cboUnitOfStrength.OverrideDropDownStyleList = False
            Me.cboUnitOfStrength.PreviousSearchTerm = Nothing
            Me.cboUnitOfStrength.PropertySelector = Nothing
            Me.cboUnitOfStrength.ReadOnlyCombo = False
            Me.cboUnitOfStrength.Size = New System.Drawing.Size(358, 24)
            Me.cboUnitOfStrength.SuggestBoxHeight = 200
            Me.cboUnitOfStrength.SuggestListOrderRule = Nothing
            Me.cboUnitOfStrength.TabIndex = 70
            Me.cboUnitOfStrength.TextToSearch = Nothing
            Me.cboUnitOfStrength.Translatable = False
            Me.cboUnitOfStrength.ValueIsMandatory = False
            Me.cboUnitOfStrength.ValueIsNullable = False
            Me.cboUnitOfStrength.ValueIsNumeric = False
            Me.cboUnitOfStrength.ValueMember = "Name"
            '
            'lblVolume
            '
            Me.lblVolume.DisplayOnly = True
            Me.lblVolume.EditingMode = False
            Me.lblVolume.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblVolume.Location = New System.Drawing.Point(1, 228)
            Me.lblVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVolume.Name = "lblVolume"
            Me.lblVolume.Size = New System.Drawing.Size(103, 23)
            Me.lblVolume.TabIndex = 56
            Me.lblVolume.Text = "Volume"
            Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVolume.Translatable = True
            '
            'txtVolume
            '
            Me.txtVolume.BackColor = System.Drawing.Color.White
            Me.txtVolume.BegFindValue = Nothing
            Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVolume.ComputedValue = False
            Me.txtVolume.CustomFormat = Nothing
            Me.txtVolume.DataBoundControl = True
            Me.txtVolume.EditingMode = True
            Me.txtVolume.EndFindValue = Nothing
            Me.txtVolume.FieldDescription = Nothing
            Me.txtVolume.FieldName = Nothing
            Me.txtVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVolume.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtVolume, True)
            Me.txtVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVolume.ForeColor = System.Drawing.Color.Black
            Me.txtVolume.LinkedLabel = Nothing
            Me.txtVolume.Location = New System.Drawing.Point(106, 228)
            Me.txtVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVolume.MaximumValue = Nothing
            Me.txtVolume.MinimumValue = Nothing
            Me.txtVolume.Name = "txtVolume"
            Me.txtVolume.OldValue = Nothing
            Me.txtVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVolume.Size = New System.Drawing.Size(148, 23)
            Me.txtVolume.TabIndex = 64
            Me.txtVolume.Translatable = False
            '
            'lblUnitOfVolume
            '
            Me.lblUnitOfVolume.DisplayOnly = True
            Me.lblUnitOfVolume.EditingMode = False
            Me.lblUnitOfVolume.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitOfVolume.Location = New System.Drawing.Point(1, 253)
            Me.lblUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfVolume.Name = "lblUnitOfVolume"
            Me.lblUnitOfVolume.Size = New System.Drawing.Size(103, 23)
            Me.lblUnitOfVolume.TabIndex = 57
            Me.lblUnitOfVolume.Text = "Unit Of Volume"
            Me.lblUnitOfVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfVolume.Translatable = True
            '
            'cboUnitOfVolume
            '
            Me.cboUnitOfVolume.BackColor = System.Drawing.Color.White
            Me.cboUnitOfVolume.BegFindValue = Nothing
            Me.cboUnitOfVolume.ChangingSearchValueOnly = False
            Me.cboUnitOfVolume.CurrentSearchTerm = ""
            Me.cboUnitOfVolume.DataValue = Nothing
            Me.cboUnitOfVolume.DefaultValue = Nothing
            Me.cboUnitOfVolume.DisplayMember = "Name"
            Me.cboUnitOfVolume.EditingMode = True
            Me.cboUnitOfVolume.EndFindValue = Nothing
            Me.cboUnitOfVolume.FieldDescription = Nothing
            Me.cboUnitOfVolume.FieldName = Nothing
            Me.cboUnitOfVolume.FilterRule = Nothing
            Me.cboUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfVolume.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboUnitOfVolume, True)
            Me.cboUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboUnitOfVolume.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfVolume.FormattingEnabled = True
            Me.cboUnitOfVolume.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfVolume.IgnoreCase = False
            Me.cboUnitOfVolume.IntegralHeight = False
            Me.cboUnitOfVolume.LinkedLabel = Nothing
            Me.cboUnitOfVolume.Location = New System.Drawing.Point(106, 253)
            Me.cboUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfVolume.Name = "cboUnitOfVolume"
            Me.cboUnitOfVolume.OldValue = 0
            Me.cboUnitOfVolume.OriginalDataSource = Nothing
            Me.cboUnitOfVolume.OriginalList = Nothing
            Me.cboUnitOfVolume.OverrideDropDownStyleList = False
            Me.cboUnitOfVolume.PreviousSearchTerm = Nothing
            Me.cboUnitOfVolume.PropertySelector = Nothing
            Me.cboUnitOfVolume.ReadOnlyCombo = False
            Me.cboUnitOfVolume.Size = New System.Drawing.Size(358, 24)
            Me.cboUnitOfVolume.SuggestBoxHeight = 200
            Me.cboUnitOfVolume.SuggestListOrderRule = Nothing
            Me.cboUnitOfVolume.TabIndex = 68
            Me.cboUnitOfVolume.TextToSearch = Nothing
            Me.cboUnitOfVolume.Translatable = False
            Me.cboUnitOfVolume.ValueIsMandatory = False
            Me.cboUnitOfVolume.ValueIsNullable = False
            Me.cboUnitOfVolume.ValueIsNumeric = False
            Me.cboUnitOfVolume.ValueMember = "Name"
            '
            'lblPackageType
            '
            Me.lblPackageType.DisplayOnly = True
            Me.lblPackageType.EditingMode = False
            Me.lblPackageType.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPackageType.Location = New System.Drawing.Point(1, 279)
            Me.lblPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPackageType.Name = "lblPackageType"
            Me.lblPackageType.Size = New System.Drawing.Size(103, 23)
            Me.lblPackageType.TabIndex = 58
            Me.lblPackageType.Text = "Package Type"
            Me.lblPackageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPackageType.Translatable = True
            '
            'cboPackageType
            '
            Me.cboPackageType.BackColor = System.Drawing.Color.White
            Me.cboPackageType.BegFindValue = Nothing
            Me.cboPackageType.ChangingSearchValueOnly = False
            Me.cboPackageType.CurrentSearchTerm = ""
            Me.cboPackageType.DataValue = Nothing
            Me.cboPackageType.DefaultValue = Nothing
            Me.cboPackageType.DisplayMember = "Name"
            Me.cboPackageType.EditingMode = True
            Me.cboPackageType.EndFindValue = Nothing
            Me.cboPackageType.FieldDescription = Nothing
            Me.cboPackageType.FieldName = Nothing
            Me.cboPackageType.FilterRule = Nothing
            Me.cboPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPackageType.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboPackageType, True)
            Me.cboPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPackageType.ForeColor = System.Drawing.Color.Black
            Me.cboPackageType.FormattingEnabled = True
            Me.cboPackageType.HideWhenNotEditingOrAdding = False
            Me.cboPackageType.IgnoreCase = False
            Me.cboPackageType.IntegralHeight = False
            Me.cboPackageType.LinkedLabel = Nothing
            Me.cboPackageType.Location = New System.Drawing.Point(106, 279)
            Me.cboPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageType.Name = "cboPackageType"
            Me.cboPackageType.OldValue = 0
            Me.cboPackageType.OriginalDataSource = Nothing
            Me.cboPackageType.OriginalList = Nothing
            Me.cboPackageType.OverrideDropDownStyleList = False
            Me.cboPackageType.PreviousSearchTerm = Nothing
            Me.cboPackageType.PropertySelector = Nothing
            Me.cboPackageType.ReadOnlyCombo = False
            Me.cboPackageType.Size = New System.Drawing.Size(358, 24)
            Me.cboPackageType.SuggestBoxHeight = 200
            Me.cboPackageType.SuggestListOrderRule = Nothing
            Me.cboPackageType.TabIndex = 66
            Me.cboPackageType.TextToSearch = Nothing
            Me.cboPackageType.Translatable = False
            Me.cboPackageType.ValueIsMandatory = False
            Me.cboPackageType.ValueIsNullable = False
            Me.cboPackageType.ValueIsNumeric = False
            Me.cboPackageType.ValueMember = "Name"
            '
            'cboPackageSize
            '
            Me.cboPackageSize.DisplayOnly = True
            Me.cboPackageSize.EditingMode = False
            Me.cboPackageSize.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPackageSize.Location = New System.Drawing.Point(1, 305)
            Me.cboPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageSize.Name = "cboPackageSize"
            Me.cboPackageSize.Size = New System.Drawing.Size(103, 23)
            Me.cboPackageSize.TabIndex = 59
            Me.cboPackageSize.Text = "Package Size"
            Me.cboPackageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.cboPackageSize.Translatable = True
            '
            'txtPackageSize
            '
            Me.txtPackageSize.BackColor = System.Drawing.Color.White
            Me.txtPackageSize.BegFindValue = Nothing
            Me.txtPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPackageSize.ComputedValue = False
            Me.txtPackageSize.CustomFormat = Nothing
            Me.txtPackageSize.DataBoundControl = True
            Me.txtPackageSize.EditingMode = True
            Me.txtPackageSize.EndFindValue = Nothing
            Me.txtPackageSize.FieldDescription = Nothing
            Me.txtPackageSize.FieldName = Nothing
            Me.txtPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPackageSize.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtPackageSize, True)
            Me.txtPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPackageSize.ForeColor = System.Drawing.Color.Black
            Me.txtPackageSize.LinkedLabel = Nothing
            Me.txtPackageSize.Location = New System.Drawing.Point(106, 305)
            Me.txtPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPackageSize.MaximumValue = Nothing
            Me.txtPackageSize.MinimumValue = Nothing
            Me.txtPackageSize.Name = "txtPackageSize"
            Me.txtPackageSize.OldValue = Nothing
            Me.txtPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPackageSize.Size = New System.Drawing.Size(148, 23)
            Me.txtPackageSize.TabIndex = 67
            Me.txtPackageSize.Translatable = False
            '
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel3.Location = New System.Drawing.Point(1, 330)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(103, 23)
            Me.CLabel3.TabIndex = 63
            Me.CLabel3.Text = "Route of Administration"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'cboRouteOfAdministration
            '
            Me.cboRouteOfAdministration.BackColor = System.Drawing.Color.White
            Me.cboRouteOfAdministration.BegFindValue = Nothing
            Me.cboRouteOfAdministration.ChangingSearchValueOnly = False
            Me.cboRouteOfAdministration.CurrentSearchTerm = ""
            Me.cboRouteOfAdministration.DataValue = Nothing
            Me.cboRouteOfAdministration.DefaultValue = Nothing
            Me.cboRouteOfAdministration.DisplayMember = "Name"
            Me.cboRouteOfAdministration.EditingMode = True
            Me.cboRouteOfAdministration.EndFindValue = Nothing
            Me.cboRouteOfAdministration.FieldDescription = Nothing
            Me.cboRouteOfAdministration.FieldName = Nothing
            Me.cboRouteOfAdministration.FilterRule = Nothing
            Me.cboRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboRouteOfAdministration.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboRouteOfAdministration, True)
            Me.cboRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboRouteOfAdministration.ForeColor = System.Drawing.Color.Black
            Me.cboRouteOfAdministration.FormattingEnabled = True
            Me.cboRouteOfAdministration.HideWhenNotEditingOrAdding = False
            Me.cboRouteOfAdministration.IgnoreCase = False
            Me.cboRouteOfAdministration.IntegralHeight = False
            Me.cboRouteOfAdministration.LinkedLabel = Nothing
            Me.cboRouteOfAdministration.Location = New System.Drawing.Point(106, 330)
            Me.cboRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
            Me.cboRouteOfAdministration.Name = "cboRouteOfAdministration"
            Me.cboRouteOfAdministration.OldValue = 0
            Me.cboRouteOfAdministration.OriginalDataSource = Nothing
            Me.cboRouteOfAdministration.OriginalList = Nothing
            Me.cboRouteOfAdministration.OverrideDropDownStyleList = False
            Me.cboRouteOfAdministration.PreviousSearchTerm = Nothing
            Me.cboRouteOfAdministration.PropertySelector = Nothing
            Me.cboRouteOfAdministration.ReadOnlyCombo = False
            Me.cboRouteOfAdministration.Size = New System.Drawing.Size(358, 24)
            Me.cboRouteOfAdministration.SuggestBoxHeight = 200
            Me.cboRouteOfAdministration.SuggestListOrderRule = Nothing
            Me.cboRouteOfAdministration.TabIndex = 53
            Me.cboRouteOfAdministration.TextToSearch = Nothing
            Me.cboRouteOfAdministration.Translatable = False
            Me.cboRouteOfAdministration.ValueIsMandatory = False
            Me.cboRouteOfAdministration.ValueIsNullable = False
            Me.cboRouteOfAdministration.ValueIsNumeric = False
            Me.cboRouteOfAdministration.ValueMember = "Name"
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel2.Location = New System.Drawing.Point(1, 356)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(103, 23)
            Me.CLabel2.TabIndex = 76
            Me.CLabel2.Text = "I.D. Number"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.bnDrugList)
            Me.CFlowLayout2.Controls.Add(Me.CLabel4)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugIdNo)
            Me.CFlowLayout2.Controls.Add(Me.CLabel5)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugGTin)
            Me.CFlowLayout2.Controls.Add(Me.CLabel7)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugTradeName)
            Me.CFlowLayout2.Controls.Add(Me.CLabel8)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugGenericName)
            Me.CFlowLayout2.Controls.Add(Me.CLabel10)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugRegistrationNo)
            Me.CFlowLayout2.Controls.Add(Me.CLabel11)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugDosageForm)
            Me.CFlowLayout2.Controls.Add(Me.CLabel12)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugStrengthValue)
            Me.CFlowLayout2.Controls.Add(Me.CLabel13)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugUnitOfStrength)
            Me.CFlowLayout2.Controls.Add(Me.CLabel14)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugVolume)
            Me.CFlowLayout2.Controls.Add(Me.CLabel15)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugUnitOfVolume)
            Me.CFlowLayout2.Controls.Add(Me.CLabel16)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugPackageType)
            Me.CFlowLayout2.Controls.Add(Me.CLabel17)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugPackageSize)
            Me.CFlowLayout2.Controls.Add(Me.CLabel18)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugRouteOfAdministration)
            Me.CFlowLayout2.Location = New System.Drawing.Point(481, 85)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(477, 359)
            Me.CFlowLayout2.TabIndex = 38
            '
            'bnDrugList
            '
            Me.bnDrugList.AddNewItem = Me.BindingNavigatorAddNewItem
            Me.bnDrugList.AllowMerge = False
            Me.bnDrugList.BindingSource = Me.bsDrugList
            Me.bnDrugList.CountItem = Me.BindingNavigatorCountItem
            Me.bnDrugList.DeleteItem = Me.BindingNavigatorDeleteItem
            Me.CFlowLayout2.SetFlowBreak(Me.bnDrugList, True)
            Me.bnDrugList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
            Me.bnDrugList.Location = New System.Drawing.Point(0, 0)
            Me.bnDrugList.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
            Me.bnDrugList.MoveLastItem = Me.BindingNavigatorMoveLastItem
            Me.bnDrugList.MoveNextItem = Me.BindingNavigatorMoveNextItem
            Me.bnDrugList.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
            Me.bnDrugList.Name = "bnDrugList"
            Me.bnDrugList.PositionItem = Me.BindingNavigatorPositionItem
            Me.bnDrugList.Size = New System.Drawing.Size(209, 25)
            Me.bnDrugList.TabIndex = 72
            Me.bnDrugList.Text = "BindingNavigator1"
            '
            'BindingNavigatorAddNewItem
            '
            Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
            Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorAddNewItem.Text = "Add new"
            Me.BindingNavigatorAddNewItem.Visible = False
            '
            'BindingNavigatorCountItem
            '
            Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
            Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
            Me.BindingNavigatorCountItem.Text = "of {0}"
            Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
            '
            'BindingNavigatorDeleteItem
            '
            Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
            Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorDeleteItem.Text = "Delete"
            Me.BindingNavigatorDeleteItem.Visible = False
            '
            'BindingNavigatorMoveFirstItem
            '
            Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
            Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveFirstItem.Text = "Move first"
            '
            'BindingNavigatorMovePreviousItem
            '
            Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
            Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
            '
            'BindingNavigatorSeparator
            '
            Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
            Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorPositionItem
            '
            Me.BindingNavigatorPositionItem.AccessibleName = "Position"
            Me.BindingNavigatorPositionItem.AutoSize = False
            Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
            Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
            Me.BindingNavigatorPositionItem.Text = "0"
            Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
            '
            'BindingNavigatorSeparator1
            '
            Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
            Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorMoveNextItem
            '
            Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
            Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveNextItem.Text = "Move next"
            '
            'BindingNavigatorMoveLastItem
            '
            Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
            Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveLastItem.Text = "Move last"
            '
            'BindingNavigatorSeparator2
            '
            Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
            Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel4.Location = New System.Drawing.Point(1, 26)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(102, 23)
            Me.CLabel4.TabIndex = 1
            Me.CLabel4.Text = "I.D. Number"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'txtDrugIdNo
            '
            Me.txtDrugIdNo.BackColor = System.Drawing.Color.White
            Me.txtDrugIdNo.BegFindValue = Nothing
            Me.txtDrugIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugIdNo.ComputedValue = False
            Me.txtDrugIdNo.CustomFormat = Nothing
            Me.txtDrugIdNo.DataBoundControl = True
            Me.txtDrugIdNo.DisplayOnly = True
            Me.txtDrugIdNo.EditingMode = True
            Me.txtDrugIdNo.EndFindValue = Nothing
            Me.txtDrugIdNo.FieldDescription = Nothing
            Me.txtDrugIdNo.FieldName = Nothing
            Me.txtDrugIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugIdNo.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugIdNo, True)
            Me.txtDrugIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtDrugIdNo.LinkedLabel = Nothing
            Me.txtDrugIdNo.Location = New System.Drawing.Point(105, 26)
            Me.txtDrugIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugIdNo.MaximumValue = Nothing
            Me.txtDrugIdNo.MinimumValue = Nothing
            Me.txtDrugIdNo.Name = "txtDrugIdNo"
            Me.txtDrugIdNo.OldValue = ""
            Me.txtDrugIdNo.ReadOnly = True
            Me.txtDrugIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugIdNo.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugIdNo.TabIndex = 0
            Me.txtDrugIdNo.Translatable = False
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel5.Location = New System.Drawing.Point(1, 51)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(102, 23)
            Me.CLabel5.TabIndex = 36
            Me.CLabel5.Text = "GTIN"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtDrugGTin
            '
            Me.txtDrugGTin.BackColor = System.Drawing.Color.White
            Me.txtDrugGTin.BegFindValue = Nothing
            Me.txtDrugGTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugGTin.ComputedValue = False
            Me.txtDrugGTin.CustomFormat = Nothing
            Me.txtDrugGTin.DataBoundControl = True
            Me.txtDrugGTin.EditingMode = True
            Me.txtDrugGTin.EndFindValue = Nothing
            Me.txtDrugGTin.FieldDescription = Nothing
            Me.txtDrugGTin.FieldName = Nothing
            Me.txtDrugGTin.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugGTin.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugGTin, True)
            Me.txtDrugGTin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugGTin.ForeColor = System.Drawing.Color.Black
            Me.txtDrugGTin.LinkedLabel = Nothing
            Me.txtDrugGTin.Location = New System.Drawing.Point(105, 51)
            Me.txtDrugGTin.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugGTin.MaximumValue = Nothing
            Me.txtDrugGTin.MinimumValue = Nothing
            Me.txtDrugGTin.Name = "txtDrugGTin"
            Me.txtDrugGTin.OldValue = ""
            Me.txtDrugGTin.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugGTin.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugGTin.TabIndex = 37
            Me.txtDrugGTin.Translatable = False
            '
            'CLabel7
            '
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel7.Location = New System.Drawing.Point(1, 76)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(102, 23)
            Me.CLabel7.TabIndex = 41
            Me.CLabel7.Text = "Name"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'txtDrugTradeName
            '
            Me.txtDrugTradeName.BackColor = System.Drawing.Color.White
            Me.txtDrugTradeName.BegFindValue = Nothing
            Me.txtDrugTradeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugTradeName.ComputedValue = False
            Me.txtDrugTradeName.CustomFormat = Nothing
            Me.txtDrugTradeName.DataBoundControl = True
            Me.txtDrugTradeName.EditingMode = True
            Me.txtDrugTradeName.EndFindValue = Nothing
            Me.txtDrugTradeName.FieldDescription = Nothing
            Me.txtDrugTradeName.FieldName = Nothing
            Me.txtDrugTradeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugTradeName.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugTradeName, True)
            Me.txtDrugTradeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugTradeName.ForeColor = System.Drawing.Color.Black
            Me.txtDrugTradeName.LinkedLabel = Nothing
            Me.txtDrugTradeName.Location = New System.Drawing.Point(105, 76)
            Me.txtDrugTradeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugTradeName.MaximumValue = Nothing
            Me.txtDrugTradeName.MinimumValue = Nothing
            Me.txtDrugTradeName.Name = "txtDrugTradeName"
            Me.txtDrugTradeName.OldValue = Nothing
            Me.txtDrugTradeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugTradeName.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugTradeName.TabIndex = 40
            Me.txtDrugTradeName.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel8.Location = New System.Drawing.Point(1, 101)
            Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel8.Name = "CLabel8"
            Me.CLabel8.Size = New System.Drawing.Size(102, 23)
            Me.CLabel8.TabIndex = 44
            Me.CLabel8.Text = "Generic Name"
            Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel8.Translatable = True
            '
            'txtDrugGenericName
            '
            Me.txtDrugGenericName.BackColor = System.Drawing.Color.White
            Me.txtDrugGenericName.BegFindValue = Nothing
            Me.txtDrugGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugGenericName.ComputedValue = False
            Me.txtDrugGenericName.CustomFormat = Nothing
            Me.txtDrugGenericName.DataBoundControl = True
            Me.txtDrugGenericName.EditingMode = True
            Me.txtDrugGenericName.EndFindValue = Nothing
            Me.txtDrugGenericName.FieldDescription = Nothing
            Me.txtDrugGenericName.FieldName = Nothing
            Me.txtDrugGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugGenericName.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugGenericName, True)
            Me.txtDrugGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtDrugGenericName.LinkedLabel = Nothing
            Me.txtDrugGenericName.Location = New System.Drawing.Point(105, 101)
            Me.txtDrugGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugGenericName.MaximumValue = Nothing
            Me.txtDrugGenericName.MinimumValue = Nothing
            Me.txtDrugGenericName.Name = "txtDrugGenericName"
            Me.txtDrugGenericName.OldValue = "0"
            Me.txtDrugGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugGenericName.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugGenericName.TabIndex = 53
            Me.txtDrugGenericName.Translatable = False
            '
            'CLabel10
            '
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel10.Location = New System.Drawing.Point(1, 126)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(102, 23)
            Me.CLabel10.TabIndex = 62
            Me.CLabel10.Text = "Registration Number"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel10.Translatable = True
            '
            'txtDrugRegistrationNo
            '
            Me.txtDrugRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtDrugRegistrationNo.BegFindValue = Nothing
            Me.txtDrugRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugRegistrationNo.ComputedValue = False
            Me.txtDrugRegistrationNo.CustomFormat = Nothing
            Me.txtDrugRegistrationNo.DataBoundControl = True
            Me.txtDrugRegistrationNo.EditingMode = True
            Me.txtDrugRegistrationNo.EndFindValue = Nothing
            Me.txtDrugRegistrationNo.FieldDescription = Nothing
            Me.txtDrugRegistrationNo.FieldName = Nothing
            Me.txtDrugRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugRegistrationNo.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugRegistrationNo, True)
            Me.txtDrugRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtDrugRegistrationNo.LinkedLabel = Nothing
            Me.txtDrugRegistrationNo.Location = New System.Drawing.Point(105, 126)
            Me.txtDrugRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugRegistrationNo.MaximumValue = Nothing
            Me.txtDrugRegistrationNo.MinimumValue = Nothing
            Me.txtDrugRegistrationNo.Name = "txtDrugRegistrationNo"
            Me.txtDrugRegistrationNo.OldValue = ""
            Me.txtDrugRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugRegistrationNo.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugRegistrationNo.TabIndex = 69
            Me.txtDrugRegistrationNo.Translatable = False
            '
            'CLabel11
            '
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel11.Location = New System.Drawing.Point(1, 151)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(102, 23)
            Me.CLabel11.TabIndex = 60
            Me.CLabel11.Text = "Dosage Form"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel11.Translatable = True
            '
            'txtDrugDosageForm
            '
            Me.txtDrugDosageForm.BackColor = System.Drawing.Color.White
            Me.txtDrugDosageForm.BegFindValue = Nothing
            Me.txtDrugDosageForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugDosageForm.ComputedValue = False
            Me.txtDrugDosageForm.CustomFormat = Nothing
            Me.txtDrugDosageForm.DataBoundControl = True
            Me.txtDrugDosageForm.EditingMode = True
            Me.txtDrugDosageForm.EndFindValue = Nothing
            Me.txtDrugDosageForm.FieldDescription = Nothing
            Me.txtDrugDosageForm.FieldName = Nothing
            Me.txtDrugDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugDosageForm.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugDosageForm, True)
            Me.txtDrugDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugDosageForm.ForeColor = System.Drawing.Color.Black
            Me.txtDrugDosageForm.LinkedLabel = Nothing
            Me.txtDrugDosageForm.Location = New System.Drawing.Point(105, 151)
            Me.txtDrugDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugDosageForm.MaximumValue = Nothing
            Me.txtDrugDosageForm.MinimumValue = Nothing
            Me.txtDrugDosageForm.Name = "txtDrugDosageForm"
            Me.txtDrugDosageForm.OldValue = "0"
            Me.txtDrugDosageForm.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugDosageForm.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugDosageForm.TabIndex = 65
            Me.txtDrugDosageForm.Translatable = False
            '
            'CLabel12
            '
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel12.Location = New System.Drawing.Point(1, 176)
            Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel12.Name = "CLabel12"
            Me.CLabel12.Size = New System.Drawing.Size(102, 23)
            Me.CLabel12.TabIndex = 51
            Me.CLabel12.Text = "Strength value"
            Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel12.Translatable = True
            '
            'txtDrugStrengthValue
            '
            Me.txtDrugStrengthValue.BackColor = System.Drawing.Color.White
            Me.txtDrugStrengthValue.BegFindValue = Nothing
            Me.txtDrugStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugStrengthValue.ComputedValue = False
            Me.txtDrugStrengthValue.CustomFormat = Nothing
            Me.txtDrugStrengthValue.DataBoundControl = True
            Me.txtDrugStrengthValue.EditingMode = True
            Me.txtDrugStrengthValue.EndFindValue = Nothing
            Me.txtDrugStrengthValue.FieldDescription = Nothing
            Me.txtDrugStrengthValue.FieldName = Nothing
            Me.txtDrugStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugStrengthValue.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugStrengthValue, True)
            Me.txtDrugStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugStrengthValue.ForeColor = System.Drawing.Color.Black
            Me.txtDrugStrengthValue.LinkedLabel = Nothing
            Me.txtDrugStrengthValue.Location = New System.Drawing.Point(105, 176)
            Me.txtDrugStrengthValue.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugStrengthValue.MaximumValue = Nothing
            Me.txtDrugStrengthValue.MinimumValue = Nothing
            Me.txtDrugStrengthValue.Name = "txtDrugStrengthValue"
            Me.txtDrugStrengthValue.OldValue = Nothing
            Me.txtDrugStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugStrengthValue.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugStrengthValue.TabIndex = 71
            Me.txtDrugStrengthValue.Translatable = False
            '
            'CLabel13
            '
            Me.CLabel13.DisplayOnly = True
            Me.CLabel13.EditingMode = False
            Me.CLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel13.Location = New System.Drawing.Point(1, 201)
            Me.CLabel13.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel13.Name = "CLabel13"
            Me.CLabel13.Size = New System.Drawing.Size(102, 23)
            Me.CLabel13.TabIndex = 55
            Me.CLabel13.Text = "Unit of Strength"
            Me.CLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel13.Translatable = True
            '
            'txtDrugUnitOfStrength
            '
            Me.txtDrugUnitOfStrength.BackColor = System.Drawing.Color.White
            Me.txtDrugUnitOfStrength.BegFindValue = Nothing
            Me.txtDrugUnitOfStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugUnitOfStrength.ComputedValue = False
            Me.txtDrugUnitOfStrength.CustomFormat = Nothing
            Me.txtDrugUnitOfStrength.DataBoundControl = True
            Me.txtDrugUnitOfStrength.EditingMode = True
            Me.txtDrugUnitOfStrength.EndFindValue = Nothing
            Me.txtDrugUnitOfStrength.FieldDescription = Nothing
            Me.txtDrugUnitOfStrength.FieldName = Nothing
            Me.txtDrugUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugUnitOfStrength.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugUnitOfStrength, True)
            Me.txtDrugUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugUnitOfStrength.ForeColor = System.Drawing.Color.Black
            Me.txtDrugUnitOfStrength.LinkedLabel = Nothing
            Me.txtDrugUnitOfStrength.Location = New System.Drawing.Point(105, 201)
            Me.txtDrugUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugUnitOfStrength.MaximumValue = Nothing
            Me.txtDrugUnitOfStrength.MinimumValue = Nothing
            Me.txtDrugUnitOfStrength.Name = "txtDrugUnitOfStrength"
            Me.txtDrugUnitOfStrength.OldValue = "0"
            Me.txtDrugUnitOfStrength.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugUnitOfStrength.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugUnitOfStrength.TabIndex = 70
            Me.txtDrugUnitOfStrength.Translatable = False
            '
            'CLabel14
            '
            Me.CLabel14.DisplayOnly = True
            Me.CLabel14.EditingMode = False
            Me.CLabel14.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel14.Location = New System.Drawing.Point(1, 226)
            Me.CLabel14.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel14.Name = "CLabel14"
            Me.CLabel14.Size = New System.Drawing.Size(102, 23)
            Me.CLabel14.TabIndex = 56
            Me.CLabel14.Text = "Volume"
            Me.CLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel14.Translatable = True
            '
            'txtDrugVolume
            '
            Me.txtDrugVolume.BackColor = System.Drawing.Color.White
            Me.txtDrugVolume.BegFindValue = Nothing
            Me.txtDrugVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugVolume.ComputedValue = False
            Me.txtDrugVolume.CustomFormat = Nothing
            Me.txtDrugVolume.DataBoundControl = True
            Me.txtDrugVolume.EditingMode = True
            Me.txtDrugVolume.EndFindValue = Nothing
            Me.txtDrugVolume.FieldDescription = Nothing
            Me.txtDrugVolume.FieldName = Nothing
            Me.txtDrugVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugVolume.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugVolume, True)
            Me.txtDrugVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugVolume.ForeColor = System.Drawing.Color.Black
            Me.txtDrugVolume.LinkedLabel = Nothing
            Me.txtDrugVolume.Location = New System.Drawing.Point(105, 226)
            Me.txtDrugVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugVolume.MaximumValue = Nothing
            Me.txtDrugVolume.MinimumValue = Nothing
            Me.txtDrugVolume.Name = "txtDrugVolume"
            Me.txtDrugVolume.OldValue = Nothing
            Me.txtDrugVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugVolume.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugVolume.TabIndex = 64
            Me.txtDrugVolume.Translatable = False
            '
            'CLabel15
            '
            Me.CLabel15.DisplayOnly = True
            Me.CLabel15.EditingMode = False
            Me.CLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel15.Location = New System.Drawing.Point(1, 251)
            Me.CLabel15.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel15.Name = "CLabel15"
            Me.CLabel15.Size = New System.Drawing.Size(102, 23)
            Me.CLabel15.TabIndex = 57
            Me.CLabel15.Text = "Unit Of Volume"
            Me.CLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel15.Translatable = True
            '
            'txtDrugUnitOfVolume
            '
            Me.txtDrugUnitOfVolume.BackColor = System.Drawing.Color.White
            Me.txtDrugUnitOfVolume.BegFindValue = Nothing
            Me.txtDrugUnitOfVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugUnitOfVolume.ComputedValue = False
            Me.txtDrugUnitOfVolume.CustomFormat = Nothing
            Me.txtDrugUnitOfVolume.DataBoundControl = True
            Me.txtDrugUnitOfVolume.EditingMode = True
            Me.txtDrugUnitOfVolume.EndFindValue = Nothing
            Me.txtDrugUnitOfVolume.FieldDescription = Nothing
            Me.txtDrugUnitOfVolume.FieldName = Nothing
            Me.txtDrugUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugUnitOfVolume.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugUnitOfVolume, True)
            Me.txtDrugUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugUnitOfVolume.ForeColor = System.Drawing.Color.Black
            Me.txtDrugUnitOfVolume.LinkedLabel = Nothing
            Me.txtDrugUnitOfVolume.Location = New System.Drawing.Point(105, 251)
            Me.txtDrugUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugUnitOfVolume.MaximumValue = Nothing
            Me.txtDrugUnitOfVolume.MinimumValue = Nothing
            Me.txtDrugUnitOfVolume.Name = "txtDrugUnitOfVolume"
            Me.txtDrugUnitOfVolume.OldValue = "0"
            Me.txtDrugUnitOfVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugUnitOfVolume.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugUnitOfVolume.TabIndex = 68
            Me.txtDrugUnitOfVolume.Translatable = False
            '
            'CLabel16
            '
            Me.CLabel16.DisplayOnly = True
            Me.CLabel16.EditingMode = False
            Me.CLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel16.Location = New System.Drawing.Point(1, 276)
            Me.CLabel16.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel16.Name = "CLabel16"
            Me.CLabel16.Size = New System.Drawing.Size(102, 23)
            Me.CLabel16.TabIndex = 58
            Me.CLabel16.Text = "Package Type"
            Me.CLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel16.Translatable = True
            '
            'txtDrugPackageType
            '
            Me.txtDrugPackageType.BackColor = System.Drawing.Color.White
            Me.txtDrugPackageType.BegFindValue = Nothing
            Me.txtDrugPackageType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugPackageType.ComputedValue = False
            Me.txtDrugPackageType.CustomFormat = Nothing
            Me.txtDrugPackageType.DataBoundControl = True
            Me.txtDrugPackageType.EditingMode = True
            Me.txtDrugPackageType.EndFindValue = Nothing
            Me.txtDrugPackageType.FieldDescription = Nothing
            Me.txtDrugPackageType.FieldName = Nothing
            Me.txtDrugPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugPackageType.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugPackageType, True)
            Me.txtDrugPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugPackageType.ForeColor = System.Drawing.Color.Black
            Me.txtDrugPackageType.LinkedLabel = Nothing
            Me.txtDrugPackageType.Location = New System.Drawing.Point(105, 276)
            Me.txtDrugPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugPackageType.MaximumValue = Nothing
            Me.txtDrugPackageType.MinimumValue = Nothing
            Me.txtDrugPackageType.Name = "txtDrugPackageType"
            Me.txtDrugPackageType.OldValue = "0"
            Me.txtDrugPackageType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugPackageType.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugPackageType.TabIndex = 66
            Me.txtDrugPackageType.Translatable = False
            '
            'CLabel17
            '
            Me.CLabel17.DisplayOnly = True
            Me.CLabel17.EditingMode = False
            Me.CLabel17.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel17.Location = New System.Drawing.Point(1, 301)
            Me.CLabel17.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel17.Name = "CLabel17"
            Me.CLabel17.Size = New System.Drawing.Size(102, 23)
            Me.CLabel17.TabIndex = 59
            Me.CLabel17.Text = "Package Size"
            Me.CLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel17.Translatable = True
            '
            'txtDrugPackageSize
            '
            Me.txtDrugPackageSize.BackColor = System.Drawing.Color.White
            Me.txtDrugPackageSize.BegFindValue = Nothing
            Me.txtDrugPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugPackageSize.ComputedValue = False
            Me.txtDrugPackageSize.CustomFormat = Nothing
            Me.txtDrugPackageSize.DataBoundControl = True
            Me.txtDrugPackageSize.EditingMode = True
            Me.txtDrugPackageSize.EndFindValue = Nothing
            Me.txtDrugPackageSize.FieldDescription = Nothing
            Me.txtDrugPackageSize.FieldName = Nothing
            Me.txtDrugPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugPackageSize.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugPackageSize, True)
            Me.txtDrugPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugPackageSize.ForeColor = System.Drawing.Color.Black
            Me.txtDrugPackageSize.LinkedLabel = Nothing
            Me.txtDrugPackageSize.Location = New System.Drawing.Point(105, 301)
            Me.txtDrugPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugPackageSize.MaximumValue = Nothing
            Me.txtDrugPackageSize.MinimumValue = Nothing
            Me.txtDrugPackageSize.Name = "txtDrugPackageSize"
            Me.txtDrugPackageSize.OldValue = Nothing
            Me.txtDrugPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugPackageSize.Size = New System.Drawing.Size(148, 23)
            Me.txtDrugPackageSize.TabIndex = 67
            Me.txtDrugPackageSize.Translatable = False
            '
            'CLabel18
            '
            Me.CLabel18.DisplayOnly = True
            Me.CLabel18.EditingMode = False
            Me.CLabel18.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel18.Location = New System.Drawing.Point(1, 326)
            Me.CLabel18.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel18.Name = "CLabel18"
            Me.CLabel18.Size = New System.Drawing.Size(102, 23)
            Me.CLabel18.TabIndex = 63
            Me.CLabel18.Text = "Route of Administration"
            Me.CLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel18.Translatable = True
            '
            'txtDrugRouteOfAdministration
            '
            Me.txtDrugRouteOfAdministration.BackColor = System.Drawing.Color.White
            Me.txtDrugRouteOfAdministration.BegFindValue = Nothing
            Me.txtDrugRouteOfAdministration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugRouteOfAdministration.ComputedValue = False
            Me.txtDrugRouteOfAdministration.CustomFormat = Nothing
            Me.txtDrugRouteOfAdministration.DataBoundControl = True
            Me.txtDrugRouteOfAdministration.EditingMode = True
            Me.txtDrugRouteOfAdministration.EndFindValue = Nothing
            Me.txtDrugRouteOfAdministration.FieldDescription = Nothing
            Me.txtDrugRouteOfAdministration.FieldName = Nothing
            Me.txtDrugRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugRouteOfAdministration.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugRouteOfAdministration, True)
            Me.txtDrugRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDrugRouteOfAdministration.ForeColor = System.Drawing.Color.Black
            Me.txtDrugRouteOfAdministration.LinkedLabel = Nothing
            Me.txtDrugRouteOfAdministration.Location = New System.Drawing.Point(105, 326)
            Me.txtDrugRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugRouteOfAdministration.MaximumValue = Nothing
            Me.txtDrugRouteOfAdministration.MinimumValue = Nothing
            Me.txtDrugRouteOfAdministration.Name = "txtDrugRouteOfAdministration"
            Me.txtDrugRouteOfAdministration.OldValue = ""
            Me.txtDrugRouteOfAdministration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugRouteOfAdministration.Size = New System.Drawing.Size(368, 23)
            Me.txtDrugRouteOfAdministration.TabIndex = 43
            Me.txtDrugRouteOfAdministration.Translatable = False
            '
            'DataGridViewDrugs
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDrugs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDrugs.BegFindValue = Nothing
            Me.DataGridViewDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDrugs.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewDrugs.DgvFooter = Nothing
            Me.DataGridViewDrugs.DisplayOnly = False
            Me.DataGridViewDrugs.Ea = Nothing
            Me.DataGridViewDrugs.EditingMode = False
            Me.DataGridViewDrugs.EndFindValue = Nothing
            Me.DataGridViewDrugs.FieldDescription = Nothing
            Me.DataGridViewDrugs.FieldName = Nothing
            Me.DataGridViewDrugs.FieldsDictionary = Nothing
            Me.DataGridViewDrugs.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDrugs.FindEnabled = False
            Me.DataGridViewDrugs.FirstRowDeletionEnabled = True
            Me.DataGridViewDrugs.FirstRowInsertionEnabled = True
            Me.DataGridViewDrugs.IgnoreCase = False
            Me.DataGridViewDrugs.IsDirty = False
            Me.DataGridViewDrugs.Location = New System.Drawing.Point(4, 450)
            Me.DataGridViewDrugs.Name = "DataGridViewDrugs"
            Me.DataGridViewDrugs.ReadOnly = True
            Me.DataGridViewDrugs.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDrugs.SecurityKey = ""
            Me.DataGridViewDrugs.SequenceColumn = "dgvSequence"
            Me.DataGridViewDrugs.SequenceFieldName = "Sequence"
            Me.DataGridViewDrugs.ShowFooter = False
            Me.DataGridViewDrugs.ShowInsertColumnWhenEditing = True
            Me.DataGridViewDrugs.Size = New System.Drawing.Size(954, 273)
            Me.DataGridViewDrugs.TabIndex = 39
            Me.DataGridViewDrugs.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(429, 729)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 40
            Me.btnOk.Text = "Ok"
            '
            'lblSearcher
            '
            Me.lblSearcher.BackColor = System.Drawing.Color.Transparent
            Me.lblSearcher.DisplayOnly = True
            Me.lblSearcher.EditingMode = False
            Me.lblSearcher.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSearcher.Location = New System.Drawing.Point(0, 55)
            Me.lblSearcher.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSearcher.Name = "lblSearcher"
            Me.lblSearcher.Size = New System.Drawing.Size(103, 23)
            Me.lblSearcher.TabIndex = 77
            Me.lblSearcher.Text = "Selector"
            Me.lblSearcher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSearcher.Translatable = True
            '
            'lblPrice_Cash
            '
            Me.lblPrice_Cash.AutoSize = True
            Me.lblPrice_Cash.DisplayOnly = True
            Me.lblPrice_Cash.EditingMode = False
            Me.lblPrice_Cash.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrice_Cash.Location = New System.Drawing.Point(303, 1)
            Me.lblPrice_Cash.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrice_Cash.Name = "lblPrice_Cash"
            Me.lblPrice_Cash.Size = New System.Drawing.Size(30, 16)
            Me.lblPrice_Cash.TabIndex = 77
            Me.lblPrice_Cash.Text = "Price"
            Me.lblPrice_Cash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrice_Cash.Translatable = True
            '
            'txtPrice_Cash
            '
            Me.txtPrice_Cash.BackColor = System.Drawing.SystemColors.ControlLight
            Me.txtPrice_Cash.BegFindValue = Nothing
            Me.txtPrice_Cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrice_Cash.ComputedValue = False
            Me.txtPrice_Cash.CustomFormat = Nothing
            Me.txtPrice_Cash.DataBoundControl = True
            Me.txtPrice_Cash.EditingMode = True
            Me.txtPrice_Cash.EndFindValue = Nothing
            Me.txtPrice_Cash.FieldDescription = Nothing
            Me.txtPrice_Cash.FieldName = Nothing
            Me.txtPrice_Cash.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrice_Cash.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtPrice_Cash, True)
            Me.txtPrice_Cash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrice_Cash.LinkedLabel = Nothing
            Me.txtPrice_Cash.Location = New System.Drawing.Point(335, 1)
            Me.txtPrice_Cash.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrice_Cash.MaximumValue = Nothing
            Me.txtPrice_Cash.MinimumValue = Nothing
            Me.txtPrice_Cash.Name = "txtPrice_Cash"
            Me.txtPrice_Cash.OldValue = Nothing
            Me.txtPrice_Cash.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrice_Cash.Size = New System.Drawing.Size(100, 23)
            Me.txtPrice_Cash.TabIndex = 78
            Me.txtPrice_Cash.Translatable = False
            '
            'GTinMatcherEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(962, 761)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.DataGridViewDrugs)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.cboItemFinder)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.lblSearcher)
            Me.Name = "GTinMatcherEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.lblSearcher, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            Me.Controls.SetChildIndex(Me.cboItemFinder, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            Me.Controls.SetChildIndex(Me.DataGridViewDrugs, 0)
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            CType(Me.bnDrugList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.bnDrugList.ResumeLayout(False)
            Me.bnDrugList.PerformLayout()
            CType(Me.bsDrugList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewDrugs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboItemFinder As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents btnScanQrCode As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents EventLog1 As EventLog
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItemDetailsCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItemDetailsName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGenericName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboRouteOfAdministration As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblRegistrationCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDosageForm As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboDosageForm As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStrengthValue As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblUnitOfStrength As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboUnitOfStrength As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblUnitOfVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboUnitOfVolume As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPackageType As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPackageType As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboPackageSize As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGenericName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents DataGridViewDrugs As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugGTin As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugTradeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugGenericName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugDosageForm As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel12 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugStrengthValue As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel13 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugUnitOfStrength As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel14 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel15 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugUnitOfVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel16 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugPackageType As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel17 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel18 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugRouteOfAdministration As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPacking As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPack1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents bnDrugList As BindingNavigator
        Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
        Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
        Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
        Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
        Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
        Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
        Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
        Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
        Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
        Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
        Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblSearcher As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents bsDrugList As BindingSource
        Friend WithEvents lblPrice_Cash As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPrice_Cash As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace