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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.SuspendLayout
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.Color.White
        Me.txtProductCode.BegFindValue = Nothing
        Me.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductCode.ComputedValue = false
        Me.txtProductCode.CustomFormat = Nothing
        Me.txtProductCode.DataBoundControl = true
        Me.txtProductCode.EditingMode = true
        Me.txtProductCode.EndFindValue = Nothing
        Me.txtProductCode.FieldDescription = Nothing
        Me.txtProductCode.FieldName = Nothing
        Me.txtProductCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtProductCode.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtProductCode, true)
        resources.ApplyResources(Me.txtProductCode, "txtProductCode")
        Me.txtProductCode.ForeColor = System.Drawing.Color.Black
        Me.txtProductCode.LinkedLabel = Me.lblProductCode
        Me.txtProductCode.MaximumValue = Nothing
        Me.txtProductCode.MinimumValue = Nothing
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.OldValue = Nothing
        Me.txtProductCode.ReadOnly = true
        Me.txtProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtProductCode.Translatable = false
        Me.txtProductCode.ValueIsMandatory = true
        Me.txtProductCode.ValueIsUnique = true
        '
        'lblProductCode
        '
        Me.lblProductCode.DisplayOnly = true
        Me.lblProductCode.EditingMode = false
        resources.ApplyResources(Me.lblProductCode, "lblProductCode")
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = false
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtDateCreated, true)
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
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
        Me.CFlowLayout4.Controls.Add(Me.lblBarcode)
        Me.CFlowLayout4.Controls.Add(Me.txtBarcode)
        Me.CFlowLayout4.Controls.Add(Me.lblGTIN)
        Me.CFlowLayout4.Controls.Add(Me.txtGTIN)
        Me.CFlowLayout4.Controls.Add(Me.lblInventory)
        Me.CFlowLayout4.Controls.Add(Me.chkInventory)
        Me.CFlowLayout4.Controls.Add(Me.lblActive)
        Me.CFlowLayout4.Controls.Add(Me.chkActive)
        Me.CFlowLayout4.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout4.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
        Me.CFlowLayout4.Name = "CFlowLayout4"
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblCategoryIdNo
        '
        Me.lblCategoryIdNo.DisplayOnly = true
        Me.lblCategoryIdNo.EditingMode = false
        resources.ApplyResources(Me.lblCategoryIdNo, "lblCategoryIdNo")
        Me.lblCategoryIdNo.Name = "lblCategoryIdNo"
        Me.lblCategoryIdNo.Translatable = true
        '
        'cboCategoryIdNo
        '
        Me.cboCategoryIdNo.AlwaysEditable = false
        Me.cboCategoryIdNo.BackColor = System.Drawing.Color.White
        Me.cboCategoryIdNo.BegFindValue = Nothing
        Me.cboCategoryIdNo.ChangingSearchValueOnly = false
        Me.cboCategoryIdNo.CurrentSearchTerm = ""
        Me.cboCategoryIdNo.DataValue = Nothing
        Me.cboCategoryIdNo.DefaultValue = ""
        Me.cboCategoryIdNo.DisplayMember = "Name"
        Me.cboCategoryIdNo.EditingMode = false
        Me.cboCategoryIdNo.EndFindValue = Nothing
        Me.cboCategoryIdNo.FieldDescription = Nothing
        Me.cboCategoryIdNo.FieldName = Nothing
        Me.cboCategoryIdNo.FilterRule = Nothing
        Me.cboCategoryIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboCategoryIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboCategoryIdNo, "cboCategoryIdNo")
        Me.cboCategoryIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboCategoryIdNo.HideWhenNotEditingOrAdding = false
        Me.cboCategoryIdNo.IgnoreCase = false
        Me.cboCategoryIdNo.LinkedLabel = Me.lblCategoryIdNo
        Me.cboCategoryIdNo.Name = "cboCategoryIdNo"
        Me.cboCategoryIdNo.OldValue = 0
        Me.cboCategoryIdNo.OriginalDataSource = Nothing
        Me.cboCategoryIdNo.OriginalList = Nothing
        Me.cboCategoryIdNo.OverrideDropDownStyleList = false
        Me.cboCategoryIdNo.PreviousSearchTerm = Nothing
        Me.cboCategoryIdNo.PropertySelector = Nothing
        Me.cboCategoryIdNo.ReadOnlyCombo = false
        Me.cboCategoryIdNo.SuggestBoxHeight = 200
        Me.cboCategoryIdNo.SuggestListOrderRule = Nothing
        Me.cboCategoryIdNo.TextToSearch = Nothing
        Me.cboCategoryIdNo.Translatable = false
        Me.cboCategoryIdNo.ValueIsMandatory = false
        Me.cboCategoryIdNo.ValueIsNullable = false
        Me.cboCategoryIdNo.ValueIsNumeric = false
        Me.cboCategoryIdNo.ValueMember = "IdNo"
        '
        'lblProductName
        '
        Me.lblProductName.DisplayOnly = true
        Me.lblProductName.EditingMode = false
        resources.ApplyResources(Me.lblProductName, "lblProductName")
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Translatable = true
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.Color.White
        Me.txtProductName.BegFindValue = Nothing
        Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductName.ComputedValue = false
        Me.txtProductName.CustomFormat = Nothing
        Me.txtProductName.DataBoundControl = true
        Me.txtProductName.EditingMode = true
        Me.txtProductName.EndFindValue = Nothing
        Me.txtProductName.FieldDescription = Nothing
        Me.txtProductName.FieldName = Nothing
        Me.txtProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtProductName.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtProductName, true)
        resources.ApplyResources(Me.txtProductName, "txtProductName")
        Me.txtProductName.ForeColor = System.Drawing.Color.Black
        Me.txtProductName.LinkedLabel = Me.lblProductName
        Me.txtProductName.MaximumValue = Nothing
        Me.txtProductName.MinimumValue = Nothing
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.OldValue = Nothing
        Me.txtProductName.ReadOnly = true
        Me.txtProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtProductName.Translatable = false
        Me.txtProductName.ValueIsMandatory = true
        Me.txtProductName.ValueIsUnique = true
        '
        'lblProductNameAra
        '
        Me.lblProductNameAra.DisplayOnly = true
        Me.lblProductNameAra.EditingMode = false
        resources.ApplyResources(Me.lblProductNameAra, "lblProductNameAra")
        Me.lblProductNameAra.Name = "lblProductNameAra"
        Me.lblProductNameAra.Translatable = true
        '
        'txtProductNameAra
        '
        Me.txtProductNameAra.BackColor = System.Drawing.Color.White
        Me.txtProductNameAra.BegFindValue = Nothing
        Me.txtProductNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductNameAra.ComputedValue = false
        Me.txtProductNameAra.CustomFormat = Nothing
        Me.txtProductNameAra.DataBoundControl = true
        Me.txtProductNameAra.EditingMode = true
        Me.txtProductNameAra.EndFindValue = Nothing
        Me.txtProductNameAra.EnglishControl = Me.txtProductName
        Me.txtProductNameAra.FieldDescription = Nothing
        Me.txtProductNameAra.FieldName = Nothing
        Me.txtProductNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtProductNameAra.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtProductNameAra, true)
        resources.ApplyResources(Me.txtProductNameAra, "txtProductNameAra")
        Me.txtProductNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtProductNameAra.LinkedLabel = Me.lblProductNameAra
        Me.txtProductNameAra.MaximumValue = Nothing
        Me.txtProductNameAra.MinimumValue = Nothing
        Me.txtProductNameAra.Name = "txtProductNameAra"
        Me.txtProductNameAra.OldValue = Nothing
        Me.txtProductNameAra.ReadOnly = true
        Me.txtProductNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtProductNameAra.Translatable = false
        Me.txtProductNameAra.ValueIsMandatory = true
        Me.txtProductNameAra.ValueIsUnique = true
        '
        'lblBaseUnit
        '
        Me.lblBaseUnit.DisplayOnly = true
        Me.lblBaseUnit.EditingMode = false
        resources.ApplyResources(Me.lblBaseUnit, "lblBaseUnit")
        Me.lblBaseUnit.Name = "lblBaseUnit"
        Me.lblBaseUnit.Translatable = true
        '
        'cboBaseUnitIdNo
        '
        Me.cboBaseUnitIdNo.AlwaysEditable = false
        Me.cboBaseUnitIdNo.BackColor = System.Drawing.Color.White
        Me.cboBaseUnitIdNo.BegFindValue = Nothing
        Me.cboBaseUnitIdNo.ChangingSearchValueOnly = false
        Me.cboBaseUnitIdNo.CurrentSearchTerm = ""
        Me.cboBaseUnitIdNo.DataValue = Nothing
        Me.cboBaseUnitIdNo.DefaultValue = ""
        Me.cboBaseUnitIdNo.DisplayMember = "Name"
        Me.cboBaseUnitIdNo.EditingMode = false
        Me.cboBaseUnitIdNo.EndFindValue = Nothing
        Me.cboBaseUnitIdNo.FieldDescription = Nothing
        Me.cboBaseUnitIdNo.FieldName = Nothing
        Me.cboBaseUnitIdNo.FilterRule = Nothing
        Me.cboBaseUnitIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboBaseUnitIdNo.FindEnabled = false
        Me.CFlowLayout4.SetFlowBreak(Me.cboBaseUnitIdNo, true)
        resources.ApplyResources(Me.cboBaseUnitIdNo, "cboBaseUnitIdNo")
        Me.cboBaseUnitIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBaseUnitIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBaseUnitIdNo.IgnoreCase = false
        Me.cboBaseUnitIdNo.LinkedLabel = Me.lblCategoryIdNo
        Me.cboBaseUnitIdNo.Name = "cboBaseUnitIdNo"
        Me.cboBaseUnitIdNo.OldValue = 0
        Me.cboBaseUnitIdNo.OriginalDataSource = Nothing
        Me.cboBaseUnitIdNo.OriginalList = Nothing
        Me.cboBaseUnitIdNo.OverrideDropDownStyleList = false
        Me.cboBaseUnitIdNo.PreviousSearchTerm = Nothing
        Me.cboBaseUnitIdNo.PropertySelector = Nothing
        Me.cboBaseUnitIdNo.ReadOnlyCombo = false
        Me.cboBaseUnitIdNo.SuggestBoxHeight = 200
        Me.cboBaseUnitIdNo.SuggestListOrderRule = Nothing
        Me.cboBaseUnitIdNo.TextToSearch = Nothing
        Me.cboBaseUnitIdNo.Translatable = false
        Me.cboBaseUnitIdNo.ValueIsMandatory = false
        Me.cboBaseUnitIdNo.ValueIsNullable = false
        Me.cboBaseUnitIdNo.ValueIsNumeric = false
        Me.cboBaseUnitIdNo.ValueMember = "IdNo"
        '
        'lblBarcode
        '
        Me.lblBarcode.DisplayOnly = true
        Me.lblBarcode.EditingMode = false
        resources.ApplyResources(Me.lblBarcode, "lblBarcode")
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Translatable = true
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.BegFindValue = Nothing
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.ComputedValue = false
        Me.txtBarcode.CustomFormat = Nothing
        Me.txtBarcode.DataBoundControl = true
        Me.txtBarcode.EditingMode = true
        Me.txtBarcode.EndFindValue = Nothing
        Me.txtBarcode.FieldDescription = Nothing
        Me.txtBarcode.FieldName = Nothing
        Me.txtBarcode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBarcode.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtBarcode, true)
        resources.ApplyResources(Me.txtBarcode, "txtBarcode")
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.LinkedLabel = Me.lblBarcode
        Me.txtBarcode.MaximumValue = Nothing
        Me.txtBarcode.MinimumValue = Nothing
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.OldValue = Nothing
        Me.txtBarcode.ReadOnly = true
        Me.txtBarcode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBarcode.Translatable = false
        Me.txtBarcode.ValueIsMandatory = true
        Me.txtBarcode.ValueIsUnique = true
        '
        'lblGTIN
        '
        Me.lblGTIN.DisplayOnly = true
        Me.lblGTIN.EditingMode = false
        resources.ApplyResources(Me.lblGTIN, "lblGTIN")
        Me.lblGTIN.Name = "lblGTIN"
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
        Me.txtGTIN.EditingMode = true
        Me.txtGTIN.EndFindValue = Nothing
        Me.txtGTIN.FieldDescription = Nothing
        Me.txtGTIN.FieldName = Nothing
        Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtGTIN.FindEnabled = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtGTIN, true)
        resources.ApplyResources(Me.txtGTIN, "txtGTIN")
        Me.txtGTIN.ForeColor = System.Drawing.Color.Black
        Me.txtGTIN.LinkedLabel = Me.lblGTIN
        Me.txtGTIN.MaximumValue = Nothing
        Me.txtGTIN.MinimumValue = Nothing
        Me.txtGTIN.Name = "txtGTIN"
        Me.txtGTIN.OldValue = Nothing
        Me.txtGTIN.ReadOnly = true
        Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtGTIN.Translatable = false
        Me.txtGTIN.ValueIsMandatory = true
        Me.txtGTIN.ValueIsUnique = true
        '
        'lblInventory
        '
        Me.lblInventory.DisplayOnly = true
        Me.lblInventory.EditingMode = false
        resources.ApplyResources(Me.lblInventory, "lblInventory")
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Translatable = true
        '
        'chkInventory
        '
        Me.chkInventory.AlwaysEditable = false
        Me.chkInventory.BackColor = System.Drawing.Color.White
        Me.chkInventory.BegFindValue = Nothing
        Me.chkInventory.DisplayOnly = false
        Me.chkInventory.EditingMode = true
        Me.chkInventory.EndFindValue = Nothing
        Me.chkInventory.FieldDescription = Nothing
        Me.chkInventory.FieldName = Nothing
        Me.chkInventory.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkInventory.FindEnabled = false
        resources.ApplyResources(Me.chkInventory, "chkInventory")
        Me.CFlowLayout4.SetFlowBreak(Me.chkInventory, true)
        Me.chkInventory.ForeColor = System.Drawing.Color.Black
        Me.chkInventory.IFindableControl_FindEnabled = false
        Me.chkInventory.IgnoreCase = false
        Me.chkInventory.LinkedLabel = Me.lblInventory
        Me.chkInventory.Name = "chkInventory"
        Me.chkInventory.NoLabel = true
        Me.chkInventory.OldValue = Nothing
        Me.chkInventory.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkInventory.Translatable = false
        Me.chkInventory.UseVisualStyleBackColor = false
        '
        'lblActive
        '
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        resources.ApplyResources(Me.lblActive, "lblActive")
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Translatable = true
        '
        'chkActive
        '
        Me.chkActive.AlwaysEditable = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = true
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = false
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.CFlowLayout4.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = false
        Me.chkActive.IgnoreCase = false
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.Translatable = false
        Me.chkActive.UseVisualStyleBackColor = false
        '
        'ProductEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout4)
        Me.Name = "ProductEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.CFlowLayout4.PerformLayout
        Me.ResumeLayout(false)
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
    End Class
End NameSpace