Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
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
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboProductCategoryIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.txtPurchaseItemNameAra.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemNameAra, True)
            resources.ApplyResources(Me.txtPurchaseItemNameAra, "txtPurchaseItemNameAra")
            Me.txtPurchaseItemNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPurchaseItemNameAra.LinkedLabel = Me.lblPurchaseItemNameAra
            Me.txtPurchaseItemNameAra.MaximumValue = Nothing
            Me.txtPurchaseItemNameAra.MinimumValue = Nothing
            Me.txtPurchaseItemNameAra.Name = "txtPurchaseItemNameAra"
            Me.txtPurchaseItemNameAra.OldValue = Nothing
            Me.txtPurchaseItemNameAra.ReadOnly = True
            '
            'txtPurchaseItemName
            '
            Me.txtPurchaseItemName.BackColor = System.Drawing.Color.White
            Me.txtPurchaseItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPurchaseItemName.ComputedValue = False
            Me.txtPurchaseItemName.CustomFormat = Nothing
            Me.txtPurchaseItemName.DataBoundControl = True
            Me.txtPurchaseItemName.EditingMode = False
            Me.txtPurchaseItemName.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemName, True)
            resources.ApplyResources(Me.txtPurchaseItemName, "txtPurchaseItemName")
            Me.txtPurchaseItemName.ForeColor = System.Drawing.Color.Black
            Me.txtPurchaseItemName.LinkedLabel = Me.lblPurchaseItemName
            Me.txtPurchaseItemName.MaximumValue = Nothing
            Me.txtPurchaseItemName.MinimumValue = Nothing
            Me.txtPurchaseItemName.Name = "txtPurchaseItemName"
            Me.txtPurchaseItemName.OldValue = Nothing
            Me.txtPurchaseItemName.ReadOnly = True
            Me.txtPurchaseItemName.ValueIsMandatory = True
            '
            'lblPurchaseItemName
            '
            Me.lblPurchaseItemName.DisplayOnly = True
            Me.lblPurchaseItemName.EditingMode = False
            resources.ApplyResources(Me.lblPurchaseItemName, "lblPurchaseItemName")
            Me.lblPurchaseItemName.Name = "lblPurchaseItemName"
            '
            'lblPurchaseItemNameAra
            '
            Me.lblPurchaseItemNameAra.DisplayOnly = True
            Me.lblPurchaseItemNameAra.EditingMode = False
            resources.ApplyResources(Me.lblPurchaseItemNameAra, "lblPurchaseItemNameAra")
            Me.lblPurchaseItemNameAra.Name = "lblPurchaseItemNameAra"
            '
            'txtPurchaseItemCode
            '
            Me.txtPurchaseItemCode.BackColor = System.Drawing.Color.White
            Me.txtPurchaseItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPurchaseItemCode.ComputedValue = False
            Me.txtPurchaseItemCode.CustomFormat = Nothing
            Me.txtPurchaseItemCode.DataBoundControl = True
            Me.txtPurchaseItemCode.EditingMode = True
            Me.txtPurchaseItemCode.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtPurchaseItemCode, True)
            resources.ApplyResources(Me.txtPurchaseItemCode, "txtPurchaseItemCode")
            Me.txtPurchaseItemCode.ForeColor = System.Drawing.Color.Black
            Me.txtPurchaseItemCode.LinkedLabel = Me.lblPurchaseItemCode
            Me.txtPurchaseItemCode.MaximumValue = Nothing
            Me.txtPurchaseItemCode.MinimumValue = Nothing
            Me.txtPurchaseItemCode.Name = "txtPurchaseItemCode"
            Me.txtPurchaseItemCode.OldValue = Nothing
            Me.txtPurchaseItemCode.ReadOnly = True
            Me.txtPurchaseItemCode.ValueIsMandatory = True
            '
            'lblPurchaseItemCode
            '
            Me.lblPurchaseItemCode.DisplayOnly = True
            Me.lblPurchaseItemCode.EditingMode = False
            resources.ApplyResources(Me.lblPurchaseItemCode, "lblPurchaseItemCode")
            Me.lblPurchaseItemCode.Name = "lblPurchaseItemCode"
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = False
            Me.txtDateCreated.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout4.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblCategoryIdNo)
            Me.CFlowLayout4.Controls.Add(Me.cboProductCategoryIdNo)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
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
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblCategoryIdNo
            '
            Me.lblCategoryIdNo.DisplayOnly = True
            Me.lblCategoryIdNo.EditingMode = False
            resources.ApplyResources(Me.lblCategoryIdNo, "lblCategoryIdNo")
            Me.lblCategoryIdNo.Name = "lblCategoryIdNo"
            '
            'cboProductCategoryIdNo
            '
            Me.cboProductCategoryIdNo.BackColor = System.Drawing.Color.White
            Me.cboProductCategoryIdNo.ChangingSearchValueOnly = False
            Me.cboProductCategoryIdNo.CurrentSearchTerm = ""
            Me.cboProductCategoryIdNo.DefaultValue = ""
            Me.cboProductCategoryIdNo.DisplayMember = "Name"
            Me.cboProductCategoryIdNo.EditingMode = False
            Me.cboProductCategoryIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboProductCategoryIdNo, "cboProductCategoryIdNo")
            Me.cboProductCategoryIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboProductCategoryIdNo.HideWhenNotEditingOrAdding = False
            Me.cboProductCategoryIdNo.LinkedLabel = Me.lblCategoryIdNo
            Me.cboProductCategoryIdNo.Name = "cboProductCategoryIdNo"
            Me.cboProductCategoryIdNo.OldValue = 0
            Me.cboProductCategoryIdNo.OriginalDataSource = Nothing
            Me.cboProductCategoryIdNo.OriginalList = Nothing
            Me.cboProductCategoryIdNo.OverrideDropDownStyleList = False
            Me.cboProductCategoryIdNo.PreviousSearchTerm = Nothing
            Me.cboProductCategoryIdNo.PreviousSelectedIndex = 0
            Me.cboProductCategoryIdNo.PropertySelector = Nothing
            Me.cboProductCategoryIdNo.ReadOnlyCombo = False
            Me.cboProductCategoryIdNo.SearchAnywhere = False
            Me.cboProductCategoryIdNo.SearchField = Nothing
            Me.cboProductCategoryIdNo.SuggestBoxHeight = 200
            Me.cboProductCategoryIdNo.SuggestListOrderRule = Nothing
            Me.cboProductCategoryIdNo.TextToSearch = Nothing
            Me.cboProductCategoryIdNo.ValueIsMandatory = False
            Me.cboProductCategoryIdNo.ValueIsNullable = False
            Me.cboProductCategoryIdNo.ValueIsNumeric = False
            Me.cboProductCategoryIdNo.ValueMember = "IdNo"
            '
            'lblGlAccountIdNo
            '
            Me.lblGlAccountIdNo.DisplayOnly = True
            Me.lblGlAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblGlAccountIdNo, "lblGlAccountIdNo")
            Me.lblGlAccountIdNo.Name = "lblGlAccountIdNo"
            '
            'cboGlAccountIdNo
            '
            Me.cboGlAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboGlAccountIdNo.ChangingSearchValueOnly = False
            Me.cboGlAccountIdNo.CurrentSearchTerm = ""
            Me.cboGlAccountIdNo.DefaultValue = ""
            Me.cboGlAccountIdNo.DisplayMember = "Name"
            Me.cboGlAccountIdNo.EditingMode = False
            Me.cboGlAccountIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboGlAccountIdNo, "cboGlAccountIdNo")
            Me.cboGlAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboGlAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboGlAccountIdNo.LinkedLabel = Me.lblGlAccountIdNo
            Me.cboGlAccountIdNo.Name = "cboGlAccountIdNo"
            Me.cboGlAccountIdNo.OldValue = 0
            Me.cboGlAccountIdNo.OriginalDataSource = Nothing
            Me.cboGlAccountIdNo.OriginalList = Nothing
            Me.cboGlAccountIdNo.OverrideDropDownStyleList = False
            Me.cboGlAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboGlAccountIdNo.PreviousSelectedIndex = 0
            Me.cboGlAccountIdNo.PropertySelector = Nothing
            Me.cboGlAccountIdNo.ReadOnlyCombo = False
            Me.cboGlAccountIdNo.SearchAnywhere = False
            Me.cboGlAccountIdNo.SearchField = Nothing
            Me.cboGlAccountIdNo.SuggestBoxHeight = 200
            Me.cboGlAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboGlAccountIdNo.TextToSearch = Nothing
            Me.cboGlAccountIdNo.ValueIsMandatory = False
            Me.cboGlAccountIdNo.ValueIsNullable = False
            Me.cboGlAccountIdNo.ValueIsNumeric = False
            Me.cboGlAccountIdNo.ValueMember = "IdNo"
            '
            'lblVatAccountIdNo
            '
            Me.lblVatAccountIdNo.DisplayOnly = True
            Me.lblVatAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblVatAccountIdNo, "lblVatAccountIdNo")
            Me.lblVatAccountIdNo.Name = "lblVatAccountIdNo"
            '
            'cboVatAccountIdNo
            '
            Me.cboVatAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboVatAccountIdNo.ChangingSearchValueOnly = False
            Me.cboVatAccountIdNo.CurrentSearchTerm = ""
            Me.cboVatAccountIdNo.DefaultValue = ""
            Me.cboVatAccountIdNo.DisplayMember = "Name"
            Me.cboVatAccountIdNo.EditingMode = False
            Me.cboVatAccountIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboVatAccountIdNo, "cboVatAccountIdNo")
            Me.cboVatAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboVatAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboVatAccountIdNo.LinkedLabel = Me.lblVatAccountIdNo
            Me.cboVatAccountIdNo.Name = "cboVatAccountIdNo"
            Me.cboVatAccountIdNo.OldValue = 0
            Me.cboVatAccountIdNo.OriginalDataSource = Nothing
            Me.cboVatAccountIdNo.OriginalList = Nothing
            Me.cboVatAccountIdNo.OverrideDropDownStyleList = False
            Me.cboVatAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboVatAccountIdNo.PreviousSelectedIndex = 0
            Me.cboVatAccountIdNo.PropertySelector = Nothing
            Me.cboVatAccountIdNo.ReadOnlyCombo = False
            Me.cboVatAccountIdNo.SearchAnywhere = False
            Me.cboVatAccountIdNo.SearchField = Nothing
            Me.cboVatAccountIdNo.SuggestBoxHeight = 200
            Me.cboVatAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboVatAccountIdNo.TextToSearch = Nothing
            Me.cboVatAccountIdNo.ValueIsMandatory = False
            Me.cboVatAccountIdNo.ValueIsNullable = False
            Me.cboVatAccountIdNo.ValueIsNumeric = False
            Me.cboVatAccountIdNo.ValueMember = "IdNo"
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            resources.ApplyResources(Me.CLabel4, "CLabel4")
            Me.CLabel4.Name = "CLabel4"
            '
            'lblUnit
            '
            Me.lblUnit.DisplayOnly = True
            Me.lblUnit.EditingMode = False
            resources.ApplyResources(Me.lblUnit, "lblUnit")
            Me.lblUnit.Name = "lblUnit"
            '
            'lblUnitArabic
            '
            Me.lblUnitArabic.DisplayOnly = True
            Me.lblUnitArabic.EditingMode = False
            resources.ApplyResources(Me.lblUnitArabic, "lblUnitArabic")
            Me.lblUnitArabic.Name = "lblUnitArabic"
            '
            'lblUnitStdPrice
            '
            Me.lblUnitStdPrice.DisplayOnly = True
            Me.lblUnitStdPrice.EditingMode = False
            Me.CFlowLayout4.SetFlowBreak(Me.lblUnitStdPrice, True)
            resources.ApplyResources(Me.lblUnitStdPrice, "lblUnitStdPrice")
            Me.lblUnitStdPrice.Name = "lblUnitStdPrice"
            '
            'lblUnit1
            '
            Me.lblUnit1.DisplayOnly = True
            Me.lblUnit1.EditingMode = False
            resources.ApplyResources(Me.lblUnit1, "lblUnit1")
            Me.lblUnit1.Name = "lblUnit1"
            '
            'txtUnit1
            '
            Me.txtUnit1.BackColor = System.Drawing.Color.White
            Me.txtUnit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit1.ComputedValue = False
            Me.txtUnit1.CustomFormat = Nothing
            Me.txtUnit1.DataBoundControl = True
            Me.txtUnit1.EditingMode = True
            Me.txtUnit1.FindEnabled = True
            resources.ApplyResources(Me.txtUnit1, "txtUnit1")
            Me.txtUnit1.ForeColor = System.Drawing.Color.Black
            Me.txtUnit1.LinkedLabel = Me.lblUnit
            Me.txtUnit1.MaximumValue = Nothing
            Me.txtUnit1.MinimumValue = Nothing
            Me.txtUnit1.Name = "txtUnit1"
            Me.txtUnit1.OldValue = Nothing
            Me.txtUnit1.ReadOnly = True
            Me.txtUnit1.ValueIsMandatory = True
            '
            'txtUnit1Ara
            '
            Me.txtUnit1Ara.BackColor = System.Drawing.Color.White
            Me.txtUnit1Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit1Ara.ComputedValue = False
            Me.txtUnit1Ara.CustomFormat = Nothing
            Me.txtUnit1Ara.DataBoundControl = True
            Me.txtUnit1Ara.EditingMode = False
            Me.txtUnit1Ara.EnglishControl = Me.txtUnit1
            Me.txtUnit1Ara.FindEnabled = True
            resources.ApplyResources(Me.txtUnit1Ara, "txtUnit1Ara")
            Me.txtUnit1Ara.ForeColor = System.Drawing.Color.Black
            Me.txtUnit1Ara.LinkedLabel = Me.lblPurchaseItemNameAra
            Me.txtUnit1Ara.MaximumValue = Nothing
            Me.txtUnit1Ara.MinimumValue = Nothing
            Me.txtUnit1Ara.Name = "txtUnit1Ara"
            Me.txtUnit1Ara.OldValue = Nothing
            Me.txtUnit1Ara.ReadOnly = True
            '
            'txtStdPrice1
            '
            Me.txtStdPrice1.BackColor = System.Drawing.Color.White
            Me.txtStdPrice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStdPrice1.ComputedValue = False
            Me.txtStdPrice1.CustomFormat = Nothing
            Me.txtStdPrice1.DataBoundControl = True
            Me.txtStdPrice1.EditingMode = True
            Me.txtStdPrice1.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice1, True)
            resources.ApplyResources(Me.txtStdPrice1, "txtStdPrice1")
            Me.txtStdPrice1.ForeColor = System.Drawing.Color.Black
            Me.txtStdPrice1.LinkedLabel = Me.lblUnitStdPrice
            Me.txtStdPrice1.MaximumValue = Nothing
            Me.txtStdPrice1.MinimumValue = Nothing
            Me.txtStdPrice1.Name = "txtStdPrice1"
            Me.txtStdPrice1.OldValue = Nothing
            Me.txtStdPrice1.ReadOnly = True
            Me.txtStdPrice1.ValueIsMandatory = True
            Me.txtStdPrice1.ValueIsNumeric = True
            '
            'lblUnit2
            '
            Me.lblUnit2.DisplayOnly = True
            Me.lblUnit2.EditingMode = False
            resources.ApplyResources(Me.lblUnit2, "lblUnit2")
            Me.lblUnit2.Name = "lblUnit2"
            '
            'txtUnit2
            '
            Me.txtUnit2.BackColor = System.Drawing.Color.White
            Me.txtUnit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit2.ComputedValue = False
            Me.txtUnit2.CustomFormat = Nothing
            Me.txtUnit2.DataBoundControl = True
            Me.txtUnit2.EditingMode = True
            Me.txtUnit2.FindEnabled = True
            resources.ApplyResources(Me.txtUnit2, "txtUnit2")
            Me.txtUnit2.ForeColor = System.Drawing.Color.Black
            Me.txtUnit2.LinkedLabel = Me.lblUnit
            Me.txtUnit2.MaximumValue = Nothing
            Me.txtUnit2.MinimumValue = Nothing
            Me.txtUnit2.Name = "txtUnit2"
            Me.txtUnit2.OldValue = Nothing
            Me.txtUnit2.ReadOnly = True
            Me.txtUnit2.ValueIsMandatory = True
            '
            'txtUnit2Ara
            '
            Me.txtUnit2Ara.BackColor = System.Drawing.Color.White
            Me.txtUnit2Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit2Ara.ComputedValue = False
            Me.txtUnit2Ara.CustomFormat = Nothing
            Me.txtUnit2Ara.DataBoundControl = True
            Me.txtUnit2Ara.EditingMode = False
            Me.txtUnit2Ara.EnglishControl = Me.txtUnit2
            Me.txtUnit2Ara.FindEnabled = True
            resources.ApplyResources(Me.txtUnit2Ara, "txtUnit2Ara")
            Me.txtUnit2Ara.ForeColor = System.Drawing.Color.Black
            Me.txtUnit2Ara.LinkedLabel = Me.lblPurchaseItemNameAra
            Me.txtUnit2Ara.MaximumValue = Nothing
            Me.txtUnit2Ara.MinimumValue = Nothing
            Me.txtUnit2Ara.Name = "txtUnit2Ara"
            Me.txtUnit2Ara.OldValue = Nothing
            Me.txtUnit2Ara.ReadOnly = True
            '
            'txtStdPrice2
            '
            Me.txtStdPrice2.BackColor = System.Drawing.Color.White
            Me.txtStdPrice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStdPrice2.ComputedValue = False
            Me.txtStdPrice2.CustomFormat = Nothing
            Me.txtStdPrice2.DataBoundControl = True
            Me.txtStdPrice2.EditingMode = True
            Me.txtStdPrice2.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice2, True)
            resources.ApplyResources(Me.txtStdPrice2, "txtStdPrice2")
            Me.txtStdPrice2.ForeColor = System.Drawing.Color.Black
            Me.txtStdPrice2.LinkedLabel = Me.lblUnitStdPrice
            Me.txtStdPrice2.MaximumValue = Nothing
            Me.txtStdPrice2.MinimumValue = Nothing
            Me.txtStdPrice2.Name = "txtStdPrice2"
            Me.txtStdPrice2.OldValue = Nothing
            Me.txtStdPrice2.ReadOnly = True
            Me.txtStdPrice2.ValueIsMandatory = True
            Me.txtStdPrice2.ValueIsNumeric = True
            '
            'lblUnit3
            '
            Me.lblUnit3.DisplayOnly = True
            Me.lblUnit3.EditingMode = False
            resources.ApplyResources(Me.lblUnit3, "lblUnit3")
            Me.lblUnit3.Name = "lblUnit3"
            '
            'txtUnit3
            '
            Me.txtUnit3.BackColor = System.Drawing.Color.White
            Me.txtUnit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit3.ComputedValue = False
            Me.txtUnit3.CustomFormat = Nothing
            Me.txtUnit3.DataBoundControl = True
            Me.txtUnit3.EditingMode = True
            Me.txtUnit3.FindEnabled = True
            resources.ApplyResources(Me.txtUnit3, "txtUnit3")
            Me.txtUnit3.ForeColor = System.Drawing.Color.Black
            Me.txtUnit3.LinkedLabel = Me.lblUnit
            Me.txtUnit3.MaximumValue = Nothing
            Me.txtUnit3.MinimumValue = Nothing
            Me.txtUnit3.Name = "txtUnit3"
            Me.txtUnit3.OldValue = Nothing
            Me.txtUnit3.ReadOnly = True
            Me.txtUnit3.ValueIsMandatory = True
            '
            'txtUnit3Ara
            '
            Me.txtUnit3Ara.BackColor = System.Drawing.Color.White
            Me.txtUnit3Ara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnit3Ara.ComputedValue = False
            Me.txtUnit3Ara.CustomFormat = Nothing
            Me.txtUnit3Ara.DataBoundControl = True
            Me.txtUnit3Ara.EditingMode = False
            Me.txtUnit3Ara.EnglishControl = Me.txtUnit3
            Me.txtUnit3Ara.FindEnabled = True
            resources.ApplyResources(Me.txtUnit3Ara, "txtUnit3Ara")
            Me.txtUnit3Ara.ForeColor = System.Drawing.Color.Black
            Me.txtUnit3Ara.LinkedLabel = Me.lblPurchaseItemNameAra
            Me.txtUnit3Ara.MaximumValue = Nothing
            Me.txtUnit3Ara.MinimumValue = Nothing
            Me.txtUnit3Ara.Name = "txtUnit3Ara"
            Me.txtUnit3Ara.OldValue = Nothing
            Me.txtUnit3Ara.ReadOnly = True
            '
            'txtStdPrice3
            '
            Me.txtStdPrice3.BackColor = System.Drawing.Color.White
            Me.txtStdPrice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStdPrice3.ComputedValue = False
            Me.txtStdPrice3.CustomFormat = Nothing
            Me.txtStdPrice3.DataBoundControl = True
            Me.txtStdPrice3.EditingMode = True
            Me.txtStdPrice3.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtStdPrice3, True)
            resources.ApplyResources(Me.txtStdPrice3, "txtStdPrice3")
            Me.txtStdPrice3.ForeColor = System.Drawing.Color.Black
            Me.txtStdPrice3.LinkedLabel = Me.lblUnitStdPrice
            Me.txtStdPrice3.MaximumValue = Nothing
            Me.txtStdPrice3.MinimumValue = Nothing
            Me.txtStdPrice3.Name = "txtStdPrice3"
            Me.txtStdPrice3.OldValue = Nothing
            Me.txtStdPrice3.ReadOnly = True
            Me.txtStdPrice3.ValueIsMandatory = True
            Me.txtStdPrice3.ValueIsNumeric = True
            '
            'lblCancelled
            '
            Me.lblCancelled.DisplayOnly = True
            Me.lblCancelled.EditingMode = False
            resources.ApplyResources(Me.lblCancelled, "lblCancelled")
            Me.lblCancelled.Name = "lblCancelled"
            '
            'chkActive
            '
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.Checked = True
            Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.CFlowLayout4.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.LinkedLabel = Me.lblCancelled
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = True
            Me.chkActive.OldValue = Nothing
            Me.chkActive.UseVisualStyleBackColor = false
        '
        'PurchaseItemEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout4)
        Me.Name = "PurchaseItemEntry"
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
        Friend WithEvents TxtIdNo As CTextBox
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
        Friend WithEvents cboProductCategoryIdNo As CaComboBox
    End Class
End NameSpace