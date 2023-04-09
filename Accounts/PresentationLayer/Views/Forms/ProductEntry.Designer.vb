Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.txtProductCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProductCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblProductName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProductName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProductNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProductNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblBaseUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBaseUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblBarcode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBarcode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblInventory = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkInventory = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblDrug = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkDrug = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.btnUnits = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtProductCode
            '
            Me.txtProductCode.BackColor = System.Drawing.Color.White
            Me.txtProductCode.BegFindValue = Nothing
            Me.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductCode.ComputedValue = False
            Me.txtProductCode.CustomFormat = Nothing
            Me.txtProductCode.DataBoundControl = True
            Me.txtProductCode.EditingMode = True
            Me.txtProductCode.EndFindValue = Nothing
            Me.txtProductCode.FieldDescription = Nothing
            Me.txtProductCode.FieldName = Nothing
            Me.txtProductCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProductCode.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtProductCode, True)
            resources.ApplyResources(Me.txtProductCode, "txtProductCode")
            Me.txtProductCode.ForeColor = System.Drawing.Color.Black
            Me.txtProductCode.LinkedLabel = Me.lblProductCode
            Me.txtProductCode.MaximumValue = Nothing
            Me.txtProductCode.MinimumValue = Nothing
            Me.txtProductCode.Name = "txtProductCode"
            Me.txtProductCode.OldValue = Nothing
            Me.txtProductCode.ReadOnly = True
            Me.txtProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProductCode.Translatable = False
            Me.txtProductCode.ValueIsMandatory = True
            Me.txtProductCode.ValueIsUnique = True
            '
            'lblProductCode
            '
            Me.lblProductCode.DisplayOnly = True
            Me.lblProductCode.EditingMode = False
            resources.ApplyResources(Me.lblProductCode, "lblProductCode")
            Me.lblProductCode.Name = "lblProductCode"
            Me.lblProductCode.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = False
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Translatable = True
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout4.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblCategoryIdNo)
            Me.CFlowLayout4.Controls.Add(Me.cboCategoryIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblProductCode)
            Me.CFlowLayout4.Controls.Add(Me.txtProductCode)
            Me.CFlowLayout4.Controls.Add(Me.lblProductName)
            Me.CFlowLayout4.Controls.Add(Me.txtProductName)
            Me.CFlowLayout4.Controls.Add(Me.lblProductNameAra)
            Me.CFlowLayout4.Controls.Add(Me.txtProductNameAra)
            Me.CFlowLayout4.Controls.Add(Me.lblBaseUnit)
            Me.CFlowLayout4.Controls.Add(Me.cboBaseUnitIdNo)
            Me.CFlowLayout4.Controls.Add(Me.btnUnits)
            Me.CFlowLayout4.Controls.Add(Me.CFlowLayout1)
            Me.CFlowLayout4.Controls.Add(Me.CFlowLayout2)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblCategoryIdNo
            '
            Me.lblCategoryIdNo.DisplayOnly = True
            Me.lblCategoryIdNo.EditingMode = False
            resources.ApplyResources(Me.lblCategoryIdNo, "lblCategoryIdNo")
            Me.lblCategoryIdNo.Name = "lblCategoryIdNo"
            Me.lblCategoryIdNo.Translatable = True
            '
            'cboCategoryIdNo
            '
            Me.cboCategoryIdNo.AlwaysEditable = False
            Me.cboCategoryIdNo.BackColor = System.Drawing.Color.White
            Me.cboCategoryIdNo.BegFindValue = Nothing
            Me.cboCategoryIdNo.ChangingSearchValueOnly = False
            Me.cboCategoryIdNo.CurrentSearchTerm = ""
            Me.cboCategoryIdNo.DataValue = Nothing
            Me.cboCategoryIdNo.DefaultValue = ""
            Me.cboCategoryIdNo.DisplayMember = "Name"
            Me.cboCategoryIdNo.EditingMode = False
            Me.cboCategoryIdNo.EndFindValue = Nothing
            Me.cboCategoryIdNo.FieldDescription = Nothing
            Me.cboCategoryIdNo.FieldName = Nothing
            Me.cboCategoryIdNo.FilterRule = Nothing
            Me.cboCategoryIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboCategoryIdNo.FindEnabled = False
            resources.ApplyResources(Me.cboCategoryIdNo, "cboCategoryIdNo")
            Me.cboCategoryIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboCategoryIdNo.HideWhenNotEditingOrAdding = False
            Me.cboCategoryIdNo.IgnoreCase = False
            Me.cboCategoryIdNo.LinkedLabel = Me.lblCategoryIdNo
            Me.cboCategoryIdNo.Name = "cboCategoryIdNo"
            Me.cboCategoryIdNo.OldValue = 0
            Me.cboCategoryIdNo.OriginalDataSource = Nothing
            Me.cboCategoryIdNo.OriginalList = Nothing
            Me.cboCategoryIdNo.OverrideDropDownStyleList = False
            Me.cboCategoryIdNo.PreviousSearchTerm = Nothing
            Me.cboCategoryIdNo.PropertySelector = Nothing
            Me.cboCategoryIdNo.ReadOnlyCombo = False
            Me.cboCategoryIdNo.SuggestBoxHeight = 200
            Me.cboCategoryIdNo.SuggestCharCount = 1
            Me.cboCategoryIdNo.SuggestListOrderRule = Nothing
            Me.cboCategoryIdNo.TextToSearch = Nothing
            Me.cboCategoryIdNo.Translatable = False
            Me.cboCategoryIdNo.ValueIsMandatory = False
            Me.cboCategoryIdNo.ValueIsNullable = False
            Me.cboCategoryIdNo.ValueIsNumeric = False
            Me.cboCategoryIdNo.ValueMember = "IdNo"
            '
            'lblProductName
            '
            Me.lblProductName.DisplayOnly = True
            Me.lblProductName.EditingMode = False
            resources.ApplyResources(Me.lblProductName, "lblProductName")
            Me.lblProductName.Name = "lblProductName"
            Me.lblProductName.Translatable = True
            '
            'txtProductName
            '
            Me.txtProductName.BackColor = System.Drawing.Color.White
            Me.txtProductName.BegFindValue = Nothing
            Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductName.ComputedValue = False
            Me.txtProductName.CustomFormat = Nothing
            Me.txtProductName.DataBoundControl = True
            Me.txtProductName.EditingMode = True
            Me.txtProductName.EndFindValue = Nothing
            Me.txtProductName.FieldDescription = Nothing
            Me.txtProductName.FieldName = Nothing
            Me.txtProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProductName.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtProductName, True)
            resources.ApplyResources(Me.txtProductName, "txtProductName")
            Me.txtProductName.ForeColor = System.Drawing.Color.Black
            Me.txtProductName.LinkedLabel = Me.lblProductName
            Me.txtProductName.MaximumValue = Nothing
            Me.txtProductName.MinimumValue = Nothing
            Me.txtProductName.Name = "txtProductName"
            Me.txtProductName.OldValue = Nothing
            Me.txtProductName.ReadOnly = True
            Me.txtProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProductName.Translatable = False
            Me.txtProductName.ValueIsMandatory = True
            Me.txtProductName.ValueIsUnique = True
            '
            'lblProductNameAra
            '
            Me.lblProductNameAra.DisplayOnly = True
            Me.lblProductNameAra.EditingMode = False
            resources.ApplyResources(Me.lblProductNameAra, "lblProductNameAra")
            Me.lblProductNameAra.Name = "lblProductNameAra"
            Me.lblProductNameAra.Translatable = True
            '
            'txtProductNameAra
            '
            Me.txtProductNameAra.BackColor = System.Drawing.Color.White
            Me.txtProductNameAra.BegFindValue = Nothing
            Me.txtProductNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductNameAra.ComputedValue = False
            Me.txtProductNameAra.CustomFormat = Nothing
            Me.txtProductNameAra.DataBoundControl = True
            Me.txtProductNameAra.EditingMode = True
            Me.txtProductNameAra.EndFindValue = Nothing
            Me.txtProductNameAra.EnglishControl = Me.txtProductName
            Me.txtProductNameAra.FieldDescription = Nothing
            Me.txtProductNameAra.FieldName = Nothing
            Me.txtProductNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProductNameAra.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtProductNameAra, True)
            resources.ApplyResources(Me.txtProductNameAra, "txtProductNameAra")
            Me.txtProductNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtProductNameAra.LinkedLabel = Me.lblProductNameAra
            Me.txtProductNameAra.MaximumValue = Nothing
            Me.txtProductNameAra.MinimumValue = Nothing
            Me.txtProductNameAra.Name = "txtProductNameAra"
            Me.txtProductNameAra.OldValue = Nothing
            Me.txtProductNameAra.ReadOnly = True
            Me.txtProductNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProductNameAra.Translatable = False
            Me.txtProductNameAra.ValueIsMandatory = True
            Me.txtProductNameAra.ValueIsUnique = True
            '
            'lblBaseUnit
            '
            Me.lblBaseUnit.DisplayOnly = True
            Me.lblBaseUnit.EditingMode = False
            resources.ApplyResources(Me.lblBaseUnit, "lblBaseUnit")
            Me.lblBaseUnit.Name = "lblBaseUnit"
            Me.lblBaseUnit.Translatable = True
            '
            'cboBaseUnitIdNo
            '
            Me.cboBaseUnitIdNo.AlwaysEditable = False
            Me.cboBaseUnitIdNo.BackColor = System.Drawing.Color.White
            Me.cboBaseUnitIdNo.BegFindValue = Nothing
            Me.cboBaseUnitIdNo.ChangingSearchValueOnly = False
            Me.cboBaseUnitIdNo.CurrentSearchTerm = ""
            Me.cboBaseUnitIdNo.DataValue = Nothing
            Me.cboBaseUnitIdNo.DefaultValue = ""
            Me.cboBaseUnitIdNo.DisplayMember = "Name"
            Me.cboBaseUnitIdNo.EditingMode = False
            Me.cboBaseUnitIdNo.EndFindValue = Nothing
            Me.cboBaseUnitIdNo.FieldDescription = Nothing
            Me.cboBaseUnitIdNo.FieldName = Nothing
            Me.cboBaseUnitIdNo.FilterRule = Nothing
            Me.cboBaseUnitIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboBaseUnitIdNo.FindEnabled = False
            resources.ApplyResources(Me.cboBaseUnitIdNo, "cboBaseUnitIdNo")
            Me.cboBaseUnitIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBaseUnitIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBaseUnitIdNo.IgnoreCase = False
            Me.cboBaseUnitIdNo.LinkedLabel = Me.lblCategoryIdNo
            Me.cboBaseUnitIdNo.Name = "cboBaseUnitIdNo"
            Me.cboBaseUnitIdNo.OldValue = 0
            Me.cboBaseUnitIdNo.OriginalDataSource = Nothing
            Me.cboBaseUnitIdNo.OriginalList = Nothing
            Me.cboBaseUnitIdNo.OverrideDropDownStyleList = False
            Me.cboBaseUnitIdNo.PreviousSearchTerm = Nothing
            Me.cboBaseUnitIdNo.PropertySelector = Nothing
            Me.cboBaseUnitIdNo.ReadOnlyCombo = False
            Me.cboBaseUnitIdNo.SuggestBoxHeight = 200
            Me.cboBaseUnitIdNo.SuggestCharCount = 1
            Me.cboBaseUnitIdNo.SuggestListOrderRule = Nothing
            Me.cboBaseUnitIdNo.TextToSearch = Nothing
            Me.cboBaseUnitIdNo.Translatable = False
            Me.cboBaseUnitIdNo.ValueIsMandatory = False
            Me.cboBaseUnitIdNo.ValueIsNullable = False
            Me.cboBaseUnitIdNo.ValueIsNumeric = False
            Me.cboBaseUnitIdNo.ValueMember = "IdNo"
            '
            'lblBarcode
            '
            Me.lblBarcode.DisplayOnly = True
            Me.lblBarcode.EditingMode = False
            resources.ApplyResources(Me.lblBarcode, "lblBarcode")
            Me.lblBarcode.Name = "lblBarcode"
            Me.lblBarcode.Translatable = True
            '
            'txtBarcode
            '
            Me.txtBarcode.BackColor = System.Drawing.Color.White
            Me.txtBarcode.BegFindValue = Nothing
            Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBarcode.ComputedValue = False
            Me.txtBarcode.CustomFormat = Nothing
            Me.txtBarcode.DataBoundControl = True
            Me.txtBarcode.EditingMode = True
            Me.txtBarcode.EndFindValue = Nothing
            Me.txtBarcode.FieldDescription = Nothing
            Me.txtBarcode.FieldName = Nothing
            Me.txtBarcode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBarcode.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtBarcode, True)
            resources.ApplyResources(Me.txtBarcode, "txtBarcode")
            Me.txtBarcode.ForeColor = System.Drawing.Color.Black
            Me.txtBarcode.LinkedLabel = Me.lblBarcode
            Me.txtBarcode.MaximumValue = Nothing
            Me.txtBarcode.MinimumValue = Nothing
            Me.txtBarcode.Name = "txtBarcode"
            Me.txtBarcode.OldValue = Nothing
            Me.txtBarcode.ReadOnly = True
            Me.txtBarcode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBarcode.Translatable = False
            Me.txtBarcode.ValueIsMandatory = True
            Me.txtBarcode.ValueIsUnique = True
            '
            'lblGTIN
            '
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            resources.ApplyResources(Me.lblGTIN, "lblGTIN")
            Me.lblGTIN.Name = "lblGTIN"
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
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtGTIN, True)
            resources.ApplyResources(Me.txtGTIN, "txtGTIN")
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Me.lblGTIN
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = Nothing
            Me.txtGTIN.ReadOnly = True
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Translatable = False
            Me.txtGTIN.ValueIsMandatory = True
            Me.txtGTIN.ValueIsUnique = True
            '
            'lblInventory
            '
            Me.lblInventory.DisplayOnly = True
            Me.lblInventory.EditingMode = False
            resources.ApplyResources(Me.lblInventory, "lblInventory")
            Me.lblInventory.Name = "lblInventory"
            Me.lblInventory.Translatable = True
            '
            'chkInventory
            '
            Me.chkInventory.AlwaysEditable = False
            Me.chkInventory.BackColor = System.Drawing.Color.White
            Me.chkInventory.BegFindValue = Nothing
            Me.chkInventory.DisplayOnly = False
            Me.chkInventory.EditingMode = True
            Me.chkInventory.EndFindValue = Nothing
            Me.chkInventory.FieldDescription = Nothing
            Me.chkInventory.FieldName = Nothing
            Me.chkInventory.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkInventory.FindEnabled = False
            resources.ApplyResources(Me.chkInventory, "chkInventory")
            Me.CFlowLayout1.SetFlowBreak(Me.chkInventory, True)
            Me.chkInventory.ForeColor = System.Drawing.Color.Black
            Me.chkInventory.IFindableControl_FindEnabled = False
            Me.chkInventory.IgnoreCase = False
            Me.chkInventory.LinkedLabel = Me.lblInventory
            Me.chkInventory.Name = "chkInventory"
            Me.chkInventory.NoLabel = True
            Me.chkInventory.OldValue = Nothing
            Me.chkInventory.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkInventory.Translatable = False
            Me.chkInventory.UseVisualStyleBackColor = False
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            resources.ApplyResources(Me.lblActive, "lblActive")
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Translatable = True
            '
            'chkActive
            '
            Me.chkActive.AlwaysEditable = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.CFlowLayout1.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = True
            Me.chkActive.OldValue = Nothing
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'lblDrug
            '
            Me.lblDrug.DisplayOnly = True
            Me.lblDrug.EditingMode = False
            resources.ApplyResources(Me.lblDrug, "lblDrug")
            Me.lblDrug.Name = "lblDrug"
            Me.lblDrug.Translatable = True
            '
            'chkDrug
            '
            Me.chkDrug.AlwaysEditable = False
            Me.chkDrug.BackColor = System.Drawing.Color.White
            Me.chkDrug.BegFindValue = Nothing
            Me.chkDrug.DisplayOnly = False
            Me.chkDrug.EditingMode = True
            Me.chkDrug.EndFindValue = Nothing
            Me.chkDrug.FieldDescription = Nothing
            Me.chkDrug.FieldName = Nothing
            Me.chkDrug.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkDrug.FindEnabled = False
            resources.ApplyResources(Me.chkDrug, "chkDrug")
            Me.CFlowLayout1.SetFlowBreak(Me.chkDrug, True)
            Me.chkDrug.ForeColor = System.Drawing.Color.Black
            Me.chkDrug.IFindableControl_FindEnabled = False
            Me.chkDrug.IgnoreCase = False
            Me.chkDrug.LinkedLabel = Me.lblDrug
            Me.chkDrug.Name = "chkDrug"
            Me.chkDrug.NoLabel = True
            Me.chkDrug.OldValue = Nothing
            Me.chkDrug.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkDrug.Translatable = False
            Me.chkDrug.UseVisualStyleBackColor = False
            '
            'btnUnits
            '
            Me.btnUnits.DesignerSelected = False
            Me.CFlowLayout4.SetFlowBreak(Me.btnUnits, True)
            Me.btnUnits.ImageIndex = 0
            resources.ApplyResources(Me.btnUnits, "btnUnits")
            Me.btnUnits.Name = "btnUnits"
            Me.btnUnits.OriginalImageName = Nothing
            Me.btnUnits.SecurityKey = ""
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblBarcode)
            Me.CFlowLayout1.Controls.Add(Me.txtBarcode)
            Me.CFlowLayout1.Controls.Add(Me.lblGTIN)
            Me.CFlowLayout1.Controls.Add(Me.txtGTIN)
            Me.CFlowLayout1.Controls.Add(Me.lblDrug)
            Me.CFlowLayout1.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout1.Controls.Add(Me.lblInventory)
            Me.CFlowLayout1.Controls.Add(Me.chkInventory)
            Me.CFlowLayout1.Controls.Add(Me.lblActive)
            Me.CFlowLayout1.Controls.Add(Me.chkDrug)
            Me.CFlowLayout1.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout1.Controls.Add(Me.chkActive)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.CDataGridView1)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'CDataGridView1
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.CDataGridView1.BegFindValue = Nothing
            Me.CDataGridView1.Cached = False
            Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CDataGridView1.DataFilter = Nothing
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
            Me.CDataGridView1.DgSearch = CType(resources.GetObject("CDataGridView1.DgSearch"), System.Collections.Generic.List(Of AATM.Libraries.CBaseControlsLibrary.CDataGridView.DataGridSearch))
            Me.CDataGridView1.DgvFooter = Nothing
            Me.CDataGridView1.DisplayOnly = False
            Me.CDataGridView1.Ea = Nothing
            Me.CDataGridView1.EditingMode = False
            Me.CDataGridView1.EndFindValue = Nothing
            Me.CDataGridView1.FieldDescription = Nothing
            Me.CDataGridView1.FieldName = Nothing
            Me.CDataGridView1.FieldsDictionary = Nothing
            Me.CDataGridView1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CDataGridView1.FindEnabled = False
            Me.CDataGridView1.FirstRowDeletionEnabled = True
            Me.CDataGridView1.FirstRowInsertionEnabled = True
            Me.CDataGridView1.IgnoreCase = False
            Me.CDataGridView1.IsDirty = False
            resources.ApplyResources(Me.CDataGridView1, "CDataGridView1")
            Me.CDataGridView1.Name = "CDataGridView1"
            Me.CDataGridView1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CDataGridView1.SecurityKey = ""
            Me.CDataGridView1.SequenceColumn = "dgvSequence"
            Me.CDataGridView1.SequenceFieldName = "Sequence"
            Me.CDataGridView1.ShowFooter = False
            Me.CDataGridView1.ShowInsertColumnWhenEditing = True
            Me.CDataGridView1.Translatable = True
            '
            'ProductEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CFlowLayout4)
            Me.Name = "ProductEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.CFlowLayout2.ResumeLayout(False)
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblProductCode As CLabel
        Friend WithEvents txtProductCode As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblCategoryIdNo As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents cboCategoryIdNo As CtComboBox
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblProductName As CLabel
        Friend WithEvents txtProductName As CTextBox
        Friend WithEvents lblProductNameAra As CLabel
        Friend WithEvents txtProductNameAra As CTextBoxArabic
        Friend WithEvents lblBarcode As CLabel
        Friend WithEvents txtBarcode As CTextBox
        Friend WithEvents lblGTIN As CLabel
        Friend WithEvents txtGTIN As CTextBox
        Friend WithEvents lblInventory As CLabel
        Friend WithEvents chkInventory As CCheckBox
        Friend WithEvents lblBaseUnit As CLabel
        Friend WithEvents cboBaseUnitIdNo As CtComboBox
        Friend WithEvents lblDrug As CLabel
        Friend WithEvents chkDrug As CCheckBox
        Friend WithEvents btnUnits As CButton
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents CDataGridView1 As CDataGridView
    End Class
End NameSpace