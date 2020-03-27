Imports AATM.Accounts.My.Resources
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseItemEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseItemEntry))
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtPurchaseItemNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtPurchaseItemName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPurchaseItemName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPurchaseItemNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPurchaseItemCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPurchaseItemCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblGlAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboGlAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblVatAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboVatAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnitArabic = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnitStdPrice = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblUnit1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUnit1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtUnit1Ara = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtStdPrice1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUnit2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUnit2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtUnit2Ara = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtStdPrice2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUnit3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUnit3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtUnit3Ara = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtStdPrice3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.SuspendLayout
        '
        'txtPurchaseItemNameAra
        '
        Me.txtPurchaseItemNameAra.BackColor = System.Drawing.Color.White
        Me.txtPurchaseItemNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseItemNameAra.ComputedValue = false
        Me.txtPurchaseItemNameAra.CustomFormat = Nothing
        Me.txtPurchaseItemNameAra.DataBoundControl = true
        Me.txtPurchaseItemNameAra.EditingMode = false
        Me.txtPurchaseItemNameAra.EnglishControl = Me.txtPurchaseItemName
        Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemNameAra, true)
        resources.ApplyResources(Me.txtPurchaseItemNameAra, "txtPurchaseItemNameAra")
        Me.txtPurchaseItemNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPurchaseItemNameAra.LinkedLabel = Me.lblPurchaseItemNameAra
        Me.txtPurchaseItemNameAra.Name = "txtPurchaseItemNameAra"
        Me.txtPurchaseItemNameAra.OldValue = Nothing
        '
        'txtPurchaseItemName
        '
        Me.txtPurchaseItemName.BackColor = System.Drawing.Color.White
        Me.txtPurchaseItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseItemName.ComputedValue = false
        Me.txtPurchaseItemName.CustomFormat = Nothing
        Me.txtPurchaseItemName.DataBoundControl = true
        Me.txtPurchaseItemName.EditingMode = false
        Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemName, true)
        resources.ApplyResources(Me.txtPurchaseItemName, "txtPurchaseItemName")
        Me.txtPurchaseItemName.ForeColor = System.Drawing.Color.Black
        Me.txtPurchaseItemName.LinkedLabel = Me.lblPurchaseItemName
        Me.txtPurchaseItemName.Name = "txtPurchaseItemName"
        Me.txtPurchaseItemName.OldValue = Nothing
        Me.txtPurchaseItemName.ValueIsMandatory = true
        '
        'lblPurchaseItemName
        '
        Me.lblPurchaseItemName.DisplayOnly = true
        Me.lblPurchaseItemName.EditingMode = false
        resources.ApplyResources(Me.lblPurchaseItemName, "lblPurchaseItemName")
        Me.lblPurchaseItemName.Name = "lblPurchaseItemName"
        '
        'lblPurchaseItemNameAra
        '
        Me.lblPurchaseItemNameAra.DisplayOnly = true
        Me.lblPurchaseItemNameAra.EditingMode = false
        resources.ApplyResources(Me.lblPurchaseItemNameAra, "lblPurchaseItemNameAra")
        Me.lblPurchaseItemNameAra.Name = "lblPurchaseItemNameAra"
        '
        'txtPurchaseItemCode
        '
        Me.txtPurchaseItemCode.BackColor = System.Drawing.Color.White
        Me.txtPurchaseItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseItemCode.ComputedValue = false
        Me.txtPurchaseItemCode.CustomFormat = Nothing
        Me.txtPurchaseItemCode.DataBoundControl = true
        Me.txtPurchaseItemCode.EditingMode = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemCode, true)
        resources.ApplyResources(Me.txtPurchaseItemCode, "txtPurchaseItemCode")
        Me.txtPurchaseItemCode.ForeColor = System.Drawing.Color.Black
        Me.txtPurchaseItemCode.LinkedLabel = Me.lblPurchaseItemCode
        Me.txtPurchaseItemCode.Name = "txtPurchaseItemCode"
        Me.txtPurchaseItemCode.OldValue = Nothing
        Me.txtPurchaseItemCode.ReadOnly = true
        Me.txtPurchaseItemCode.ValueIsMandatory = true
        '
        'lblPurchaseItemCode
        '
        Me.lblPurchaseItemCode.DisplayOnly = true
        Me.lblPurchaseItemCode.EditingMode = false
        resources.ApplyResources(Me.lblPurchaseItemCode, "lblPurchaseItemCode")
        Me.lblPurchaseItemCode.Name = "lblPurchaseItemCode"
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = false
        Me.CFlowLayout4.SetFlowBreak(Me.txtDateCreated, true)
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        '
        'CFlowLayout4
        '
        Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout4.Controls.Add(Me.TxtIDNo)
        Me.CFlowLayout4.Controls.Add(Me.lblCategoryIdNo)
        Me.CFlowLayout4.Controls.Add(Me.cboCategoryIdNo)
        Me.CFlowLayout4.Controls.Add(Me.lblPurchaseItemCode)
        Me.CFlowLayout4.Controls.Add(Me.txtPurchaseItemCode)
        Me.CFlowLayout4.Controls.Add(Me.lblPurchaseItemName)
        Me.CFlowLayout4.Controls.Add(Me.txtPurchaseItemName)
        Me.CFlowLayout4.Controls.Add(Me.lblPurchaseItemNameAra)
        Me.CFlowLayout4.Controls.Add(Me.txtPurchaseItemNameAra)
        Me.CFlowLayout4.Controls.Add(Me.lblGlAccountIdNo)
        Me.CFlowLayout4.Controls.Add(Me.cboGlAccountIdNo)
        Me.CFlowLayout4.Controls.Add(Me.lblVatAccountIdNo)
        Me.CFlowLayout4.Controls.Add(Me.cboVatAccountIdNo)
        Me.CFlowLayout4.Controls.Add(Me.CLabel4)
        Me.CFlowLayout4.Controls.Add(Me.lblUnit)
        Me.CFlowLayout4.Controls.Add(Me.lblUnitArabic)
        Me.CFlowLayout4.Controls.Add(Me.lblUnitStdPrice)
        Me.CFlowLayout4.Controls.Add(Me.lblUnit1)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit1)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit1Ara)
        Me.CFlowLayout4.Controls.Add(Me.txtStdPrice1)
        Me.CFlowLayout4.Controls.Add(Me.lblUnit2)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit2)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit2Ara)
        Me.CFlowLayout4.Controls.Add(Me.txtStdPrice2)
        Me.CFlowLayout4.Controls.Add(Me.lblUnit3)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit3)
        Me.CFlowLayout4.Controls.Add(Me.txtUnit3Ara)
        Me.CFlowLayout4.Controls.Add(Me.txtStdPrice3)
        Me.CFlowLayout4.Controls.Add(Me.lblCancelled)
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
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = true
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.CFlowLayout4.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Me.lblIdNo
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        '
        'lblCategoryIdNo
        '
        Me.lblCategoryIdNo.DisplayOnly = true
        Me.lblCategoryIdNo.EditingMode = false
        resources.ApplyResources(Me.lblCategoryIdNo, "lblCategoryIdNo")
        Me.lblCategoryIdNo.Name = "lblCategoryIdNo"
        '
        'cboCategoryIdNo
        '
        Me.cboCategoryIdNo.BackColor = System.Drawing.Color.White
        Me.cboCategoryIdNo.ChangingSearchValueOnly = false
        Me.cboCategoryIdNo.CurrentSearchTerm = ""
        Me.cboCategoryIdNo.DefaultValue = ""
        Me.cboCategoryIdNo.DisplayMember = "Name"
        Me.cboCategoryIdNo.DropDownHeight = 200
        Me.cboCategoryIdNo.EditingMode = false
        Me.cboCategoryIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cboCategoryIdNo, "cboCategoryIdNo")
        Me.cboCategoryIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboCategoryIdNo.HideWhenNotEditingOrAdding = false
        Me.cboCategoryIdNo.LinkedLabel = Me.lblCategoryIdNo
        Me.cboCategoryIdNo.Name = "cboCategoryIdNo"
        Me.cboCategoryIdNo.OldValue = 0
        Me.cboCategoryIdNo.OriginalDataSource = Nothing
        Me.cboCategoryIdNo.OriginalList = Nothing
        Me.cboCategoryIdNo.OverrideDropDownStyleList = false
        Me.cboCategoryIdNo.PreviousSearchTerm = Nothing
        Me.cboCategoryIdNo.PreviousSelectedIndex = 0
        Me.cboCategoryIdNo.PropertySelector = Nothing
        Me.cboCategoryIdNo.ReadOnlyCombo = false
        Me.cboCategoryIdNo.SearchAnywhere = false
        Me.cboCategoryIdNo.SuggestBoxHeight = 200
        Me.cboCategoryIdNo.SuggestListOrderRule = Nothing
        Me.cboCategoryIdNo.TextToSearch = Nothing
        Me.cboCategoryIdNo.ValueIsMandatory = false
        Me.cboCategoryIdNo.ValueIsNullable = false
        Me.cboCategoryIdNo.ValueIsNumeric = false
        Me.cboCategoryIdNo.ValueMember = "IdNo"
        '
        'lblGlAccountIdNo
        '
        Me.lblGlAccountIdNo.DisplayOnly = true
        Me.lblGlAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblGlAccountIdNo, "lblGlAccountIdNo")
        Me.lblGlAccountIdNo.Name = "lblGlAccountIdNo"
        '
        'cboGlAccountIdNo
        '
        Me.cboGlAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboGlAccountIdNo.ChangingSearchValueOnly = false
        Me.cboGlAccountIdNo.CurrentSearchTerm = ""
        Me.cboGlAccountIdNo.DefaultValue = ""
        Me.cboGlAccountIdNo.DisplayMember = "Name"
        Me.cboGlAccountIdNo.DropDownHeight = 200
        Me.cboGlAccountIdNo.EditingMode = false
        Me.cboGlAccountIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cboGlAccountIdNo, "cboGlAccountIdNo")
        Me.cboGlAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboGlAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboGlAccountIdNo.LinkedLabel = Me.lblGlAccountIdNo
        Me.cboGlAccountIdNo.Name = "cboGlAccountIdNo"
        Me.cboGlAccountIdNo.OldValue = 0
        Me.cboGlAccountIdNo.OriginalDataSource = Nothing
        Me.cboGlAccountIdNo.OriginalList = Nothing
        Me.cboGlAccountIdNo.OverrideDropDownStyleList = false
        Me.cboGlAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboGlAccountIdNo.PreviousSelectedIndex = 0
        Me.cboGlAccountIdNo.PropertySelector = Nothing
        Me.cboGlAccountIdNo.ReadOnlyCombo = false
        Me.cboGlAccountIdNo.SearchAnywhere = false
        Me.cboGlAccountIdNo.SuggestBoxHeight = 200
        Me.cboGlAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboGlAccountIdNo.TextToSearch = Nothing
        Me.cboGlAccountIdNo.ValueIsMandatory = false
        Me.cboGlAccountIdNo.ValueIsNullable = false
        Me.cboGlAccountIdNo.ValueIsNumeric = false
        Me.cboGlAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatAccountIdNo
        '
        Me.lblVatAccountIdNo.DisplayOnly = true
        Me.lblVatAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblVatAccountIdNo, "lblVatAccountIdNo")
        Me.lblVatAccountIdNo.Name = "lblVatAccountIdNo"
        '
        'cboVatAccountIdNo
        '
        Me.cboVatAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboVatAccountIdNo.ChangingSearchValueOnly = false
        Me.cboVatAccountIdNo.CurrentSearchTerm = ""
        Me.cboVatAccountIdNo.DefaultValue = ""
        Me.cboVatAccountIdNo.DisplayMember = "Name"
        Me.cboVatAccountIdNo.DropDownHeight = 200
        Me.cboVatAccountIdNo.EditingMode = false
        Me.cboVatAccountIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cboVatAccountIdNo, "cboVatAccountIdNo")
        Me.cboVatAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboVatAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboVatAccountIdNo.LinkedLabel = Me.lblVatAccountIdNo
        Me.cboVatAccountIdNo.Name = "cboVatAccountIdNo"
        Me.cboVatAccountIdNo.OldValue = 0
        Me.cboVatAccountIdNo.OriginalDataSource = Nothing
        Me.cboVatAccountIdNo.OriginalList = Nothing
        Me.cboVatAccountIdNo.OverrideDropDownStyleList = false
        Me.cboVatAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboVatAccountIdNo.PreviousSelectedIndex = 0
        Me.cboVatAccountIdNo.PropertySelector = Nothing
        Me.cboVatAccountIdNo.ReadOnlyCombo = false
        Me.cboVatAccountIdNo.SearchAnywhere = false
        Me.cboVatAccountIdNo.SuggestBoxHeight = 200
        Me.cboVatAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboVatAccountIdNo.TextToSearch = Nothing
        Me.cboVatAccountIdNo.ValueIsMandatory = false
        Me.cboVatAccountIdNo.ValueIsNullable = false
        Me.cboVatAccountIdNo.ValueIsNumeric = false
        Me.cboVatAccountIdNo.ValueMember = "IdNo"
        '
        'CLabel4
        '
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        resources.ApplyResources(Me.CLabel4, "CLabel4")
        Me.CLabel4.Name = "CLabel4"
        '
        'lblUnit
        '
        Me.lblUnit.DisplayOnly = true
        Me.lblUnit.EditingMode = false
        resources.ApplyResources(Me.lblUnit, "lblUnit")
        Me.lblUnit.Name = "lblUnit"
        '
        'lblUnitArabic
        '
        Me.lblUnitArabic.DisplayOnly = true
        Me.lblUnitArabic.EditingMode = false
        resources.ApplyResources(Me.lblUnitArabic, "lblUnitArabic")
        Me.lblUnitArabic.Name = "lblUnitArabic"
        '
        'lblUnitStdPrice
        '
        Me.lblUnitStdPrice.DisplayOnly = true
        Me.lblUnitStdPrice.EditingMode = false
        Me.CFlowLayout4.SetFlowBreak(Me.lblUnitStdPrice, true)
        resources.ApplyResources(Me.lblUnitStdPrice, "lblUnitStdPrice")
        Me.lblUnitStdPrice.Name = "lblUnitStdPrice"
        '
        'lblUnit1
        '
        Me.lblUnit1.DisplayOnly = true
        Me.lblUnit1.EditingMode = false
        resources.ApplyResources(Me.lblUnit1, "lblUnit1")
        Me.lblUnit1.Name = "lblUnit1"
        '
        'txtUnit1
        '
        Me.txtUnit1.BackColor = System.Drawing.Color.White
        Me.txtUnit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit1.ComputedValue = false
        Me.txtUnit1.CustomFormat = Nothing
        Me.txtUnit1.DataBoundControl = true
        Me.txtUnit1.EditingMode = true
        resources.ApplyResources(Me.txtUnit1, "txtUnit1")
        Me.txtUnit1.ForeColor = System.Drawing.Color.Black
        Me.txtUnit1.LinkedLabel = Me.lblUnit
        Me.txtUnit1.Name = "txtUnit1"
        Me.txtUnit1.OldValue = Nothing
        Me.txtUnit1.ReadOnly = true
        Me.txtUnit1.ValueIsMandatory = true
        '
        'txtUnit1Ara
        '
        Me.txtUnit1Ara.BackColor = System.Drawing.Color.White
        Me.txtUnit1Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit1Ara.ComputedValue = false
        Me.txtUnit1Ara.CustomFormat = Nothing
        Me.txtUnit1Ara.DataBoundControl = true
        Me.txtUnit1Ara.EditingMode = false
        Me.txtUnit1Ara.EnglishControl = Me.txtUnit1
        resources.ApplyResources(Me.txtUnit1Ara, "txtUnit1Ara")
        Me.txtUnit1Ara.ForeColor = System.Drawing.Color.Black
        Me.txtUnit1Ara.LinkedLabel = Me.lblPurchaseItemNameAra
        Me.txtUnit1Ara.Name = "txtUnit1Ara"
        Me.txtUnit1Ara.OldValue = Nothing
        '
        'txtStdPrice1
        '
        Me.txtStdPrice1.BackColor = System.Drawing.Color.White
        Me.txtStdPrice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdPrice1.ComputedValue = false
        Me.txtStdPrice1.CustomFormat = Nothing
        Me.txtStdPrice1.DataBoundControl = true
        Me.txtStdPrice1.EditingMode = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice1, true)
        resources.ApplyResources(Me.txtStdPrice1, "txtStdPrice1")
        Me.txtStdPrice1.ForeColor = System.Drawing.Color.Black
        Me.txtStdPrice1.LinkedLabel = Me.lblUnitStdPrice
        Me.txtStdPrice1.Name = "txtStdPrice1"
        Me.txtStdPrice1.OldValue = Nothing
        Me.txtStdPrice1.ReadOnly = true
        Me.txtStdPrice1.ValueIsMandatory = true
        '
        'lblUnit2
        '
        Me.lblUnit2.DisplayOnly = true
        Me.lblUnit2.EditingMode = false
        resources.ApplyResources(Me.lblUnit2, "lblUnit2")
        Me.lblUnit2.Name = "lblUnit2"
        '
        'txtUnit2
        '
        Me.txtUnit2.BackColor = System.Drawing.Color.White
        Me.txtUnit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit2.ComputedValue = false
        Me.txtUnit2.CustomFormat = Nothing
        Me.txtUnit2.DataBoundControl = true
        Me.txtUnit2.EditingMode = true
        resources.ApplyResources(Me.txtUnit2, "txtUnit2")
        Me.txtUnit2.ForeColor = System.Drawing.Color.Black
        Me.txtUnit2.LinkedLabel = Me.lblUnit
        Me.txtUnit2.Name = "txtUnit2"
        Me.txtUnit2.OldValue = Nothing
        Me.txtUnit2.ReadOnly = true
        Me.txtUnit2.ValueIsMandatory = true
        '
        'txtUnit2Ara
        '
        Me.txtUnit2Ara.BackColor = System.Drawing.Color.White
        Me.txtUnit2Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit2Ara.ComputedValue = false
        Me.txtUnit2Ara.CustomFormat = Nothing
        Me.txtUnit2Ara.DataBoundControl = true
        Me.txtUnit2Ara.EditingMode = false
        Me.txtUnit2Ara.EnglishControl = Me.txtUnit2
        resources.ApplyResources(Me.txtUnit2Ara, "txtUnit2Ara")
        Me.txtUnit2Ara.ForeColor = System.Drawing.Color.Black
        Me.txtUnit2Ara.LinkedLabel = Me.lblPurchaseItemNameAra
        Me.txtUnit2Ara.Name = "txtUnit2Ara"
        Me.txtUnit2Ara.OldValue = Nothing
        '
        'txtStdPrice2
        '
        Me.txtStdPrice2.BackColor = System.Drawing.Color.White
        Me.txtStdPrice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdPrice2.ComputedValue = false
        Me.txtStdPrice2.CustomFormat = Nothing
        Me.txtStdPrice2.DataBoundControl = true
        Me.txtStdPrice2.EditingMode = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice2, true)
        resources.ApplyResources(Me.txtStdPrice2, "txtStdPrice2")
        Me.txtStdPrice2.ForeColor = System.Drawing.Color.Black
        Me.txtStdPrice2.LinkedLabel = Me.lblUnitStdPrice
        Me.txtStdPrice2.Name = "txtStdPrice2"
        Me.txtStdPrice2.OldValue = Nothing
        Me.txtStdPrice2.ReadOnly = true
        Me.txtStdPrice2.ValueIsMandatory = true
        '
        'lblUnit3
        '
        Me.lblUnit3.DisplayOnly = true
        Me.lblUnit3.EditingMode = false
        resources.ApplyResources(Me.lblUnit3, "lblUnit3")
        Me.lblUnit3.Name = "lblUnit3"
        '
        'txtUnit3
        '
        Me.txtUnit3.BackColor = System.Drawing.Color.White
        Me.txtUnit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit3.ComputedValue = false
        Me.txtUnit3.CustomFormat = Nothing
        Me.txtUnit3.DataBoundControl = true
        Me.txtUnit3.EditingMode = true
        resources.ApplyResources(Me.txtUnit3, "txtUnit3")
        Me.txtUnit3.ForeColor = System.Drawing.Color.Black
        Me.txtUnit3.LinkedLabel = Me.lblUnit
        Me.txtUnit3.Name = "txtUnit3"
        Me.txtUnit3.OldValue = Nothing
        Me.txtUnit3.ReadOnly = true
        Me.txtUnit3.ValueIsMandatory = true
        '
        'txtUnit3Ara
        '
        Me.txtUnit3Ara.BackColor = System.Drawing.Color.White
        Me.txtUnit3Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit3Ara.ComputedValue = false
        Me.txtUnit3Ara.CustomFormat = Nothing
        Me.txtUnit3Ara.DataBoundControl = true
        Me.txtUnit3Ara.EditingMode = false
        Me.txtUnit3Ara.EnglishControl = Me.txtUnit3
        resources.ApplyResources(Me.txtUnit3Ara, "txtUnit3Ara")
        Me.txtUnit3Ara.ForeColor = System.Drawing.Color.Black
        Me.txtUnit3Ara.LinkedLabel = Me.lblPurchaseItemNameAra
        Me.txtUnit3Ara.Name = "txtUnit3Ara"
        Me.txtUnit3Ara.OldValue = Nothing
        '
        'txtStdPrice3
        '
        Me.txtStdPrice3.BackColor = System.Drawing.Color.White
        Me.txtStdPrice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStdPrice3.ComputedValue = false
        Me.txtStdPrice3.CustomFormat = Nothing
        Me.txtStdPrice3.DataBoundControl = true
        Me.txtStdPrice3.EditingMode = true
        Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice3, true)
        resources.ApplyResources(Me.txtStdPrice3, "txtStdPrice3")
        Me.txtStdPrice3.ForeColor = System.Drawing.Color.Black
        Me.txtStdPrice3.LinkedLabel = Me.lblUnitStdPrice
        Me.txtStdPrice3.Name = "txtStdPrice3"
        Me.txtStdPrice3.OldValue = Nothing
        Me.txtStdPrice3.ReadOnly = true
        Me.txtStdPrice3.ValueIsMandatory = true
        '
        'lblCancelled
        '
        Me.lblCancelled.DisplayOnly = true
        Me.lblCancelled.EditingMode = false
        resources.ApplyResources(Me.lblCancelled, "lblCancelled")
        Me.lblCancelled.Name = "lblCancelled"
        '
        'chkActive
        '
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.chkActive.AutoCheck = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.Checked = true
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = true
        Me.CFlowLayout4.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.LinkedLabel = Me.lblCancelled
        Me.chkActive.Name = "chkActive"
        Me.chkActive.UseVisualStyleBackColor = false
        '
        'PurchaseItemEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout4)
        Me.Name = "PurchaseItemEntry"
        Me.SecurityPresenterObj = SecurityPresenter1
        Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.CFlowLayout4.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents txtPurchaseItemNameAra As CTextBoxArabic
        Friend WithEvents txtPurchaseItemName As CTextBox
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents lblPurchaseItemCode As CLabel
        Friend WithEvents txtPurchaseItemCode As CTextBox
        Friend WithEvents lblPurchaseItemName As CLabel
        Friend WithEvents lblPurchaseItemNameAra As CLabel
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents lblUnit As CLabel
        Friend WithEvents lblUnitStdPrice As CLabel
        Friend WithEvents txtStdPrice3 As CTextBox
        Friend WithEvents lblUnit2 As CLabel
        Friend WithEvents txtUnit2 As CTextBox
        Friend WithEvents txtStdPrice2 As CTextBox
        Friend WithEvents lblUnit3 As CLabel
        Friend WithEvents txtUnit3 As CTextBox
        Friend WithEvents txtStdPrice1 As CTextBox
        Friend WithEvents lblCategoryIdNo As CLabel
        Friend WithEvents lblGlAccountIdNo As CLabel
        Friend WithEvents cboGlAccountIdNo As CaComboBox
        Friend WithEvents lblVatAccountIdNo As CLabel
        Friend WithEvents cboVatAccountIdNo As CaComboBox
        Friend WithEvents lblUnitArabic As CLabel
        Friend WithEvents txtUnit1Ara As CTextBoxArabic
        Friend WithEvents txtUnit2Ara As CTextBoxArabic
        Friend WithEvents txtUnit3Ara As CTextBoxArabic
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblUnit1 As CLabel
        Friend WithEvents txtUnit1 As CTextBox
        Friend WithEvents cboCategoryIdNo As CaComboBox
    End Class
End NameSpace