Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CategoryEntryTv
        Inherits CFormEntryTv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoryEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCategoryCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCategoryName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCategoryNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblVatPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboVatPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblVatSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboVatSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.lblVatPercentage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPercentMark = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.FormTreeView, "FormTreeView")
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'txtCategoryCode
        '
        Me.txtCategoryCode.BackColor = System.Drawing.Color.White
        Me.txtCategoryCode.BegFindValue = Nothing
        Me.txtCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryCode.ComputedValue = false
        Me.txtCategoryCode.CustomFormat = Nothing
        Me.txtCategoryCode.DataBoundControl = true
        Me.txtCategoryCode.EditingMode = true
        Me.txtCategoryCode.EndFindValue = Nothing
        Me.txtCategoryCode.FieldDescription = Nothing
        Me.txtCategoryCode.FieldName = Nothing
        Me.txtCategoryCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCategoryCode.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryCode, true)
        resources.ApplyResources(Me.txtCategoryCode, "txtCategoryCode")
        Me.txtCategoryCode.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryCode.LinkedLabel = Me.lblCode
        Me.txtCategoryCode.MaximumValue = Nothing
        Me.txtCategoryCode.MinimumValue = Nothing
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.OldValue = Nothing
        Me.txtCategoryCode.ReadOnly = true
        Me.txtCategoryCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCategoryCode.Translatable = false
        Me.txtCategoryCode.ValueIsMandatory = true
        '
        'lblCode
        '
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Translatable = true
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BackColor = System.Drawing.Color.White
        Me.txtCategoryName.BegFindValue = Nothing
        Me.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryName.ComputedValue = false
        Me.txtCategoryName.CustomFormat = Nothing
        Me.txtCategoryName.DataBoundControl = true
        Me.txtCategoryName.EditingMode = false
        Me.txtCategoryName.EndFindValue = Nothing
        Me.txtCategoryName.FieldDescription = Nothing
        Me.txtCategoryName.FieldName = Nothing
        Me.txtCategoryName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCategoryName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryName, true)
        resources.ApplyResources(Me.txtCategoryName, "txtCategoryName")
        Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryName.LinkedLabel = Me.lblName
        Me.txtCategoryName.MaximumValue = Nothing
        Me.txtCategoryName.MinimumValue = Nothing
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.OldValue = Nothing
        Me.txtCategoryName.ReadOnly = true
        Me.txtCategoryName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCategoryName.Translatable = false
        Me.txtCategoryName.ValueIsMandatory = true
        '
        'lblName
        '
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        Me.lblName.Translatable = true
        '
        'txtCategoryNameAra
        '
        Me.txtCategoryNameAra.BackColor = System.Drawing.Color.White
        Me.txtCategoryNameAra.BegFindValue = Nothing
        Me.txtCategoryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryNameAra.ComputedValue = false
        Me.txtCategoryNameAra.CustomFormat = Nothing
        Me.txtCategoryNameAra.DataBoundControl = true
        Me.txtCategoryNameAra.EditingMode = false
        Me.txtCategoryNameAra.EndFindValue = Nothing
        Me.txtCategoryNameAra.EnglishControl = Me.txtCategoryName
        Me.txtCategoryNameAra.FieldDescription = Nothing
        Me.txtCategoryNameAra.FieldName = Nothing
        Me.txtCategoryNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCategoryNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryNameAra, true)
        resources.ApplyResources(Me.txtCategoryNameAra, "txtCategoryNameAra")
        Me.txtCategoryNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryNameAra.LinkedLabel = Me.lblNameAra
        Me.txtCategoryNameAra.MaximumValue = Nothing
        Me.txtCategoryNameAra.MinimumValue = Nothing
        Me.txtCategoryNameAra.Name = "txtCategoryNameAra"
        Me.txtCategoryNameAra.OldValue = Nothing
        Me.txtCategoryNameAra.ReadOnly = true
        Me.txtCategoryNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCategoryNameAra.Translatable = false
        '
        'lblNameAra
        '
        Me.lblNameAra.DisplayOnly = true
        Me.lblNameAra.EditingMode = false
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.lblNameAra.Name = "lblNameAra"
        Me.lblNameAra.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Me.lblNotes
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblBranchIdNo)
        Me.floDataDisplay.Controls.Add(Me.txtBranchIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblCode)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryCode)
        Me.floDataDisplay.Controls.Add(Me.lblName)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryName)
        Me.floDataDisplay.Controls.Add(Me.lblNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblPurchaseAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboPurchaseAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblSaleAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboSaleAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblVatPurchaseAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboVatPurchaseAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblVatSaleAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboVatSaleAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblVatPercentage)
        Me.floDataDisplay.Controls.Add(Me.txtVatPercentage)
        Me.floDataDisplay.Controls.Add(Me.lblPercentMark)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblPurchaseAccountIdNo
        '
        Me.lblPurchaseAccountIdNo.DisplayOnly = true
        Me.lblPurchaseAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblPurchaseAccountIdNo, "lblPurchaseAccountIdNo")
        Me.lblPurchaseAccountIdNo.Name = "lblPurchaseAccountIdNo"
        Me.lblPurchaseAccountIdNo.Translatable = true
        '
        'cboPurchaseAccountIdNo
        '
        Me.cboPurchaseAccountIdNo.AlwaysEditable = false
        Me.cboPurchaseAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboPurchaseAccountIdNo.BegFindValue = Nothing
        Me.cboPurchaseAccountIdNo.ChangingSearchValueOnly = false
        Me.cboPurchaseAccountIdNo.CurrentSearchTerm = ""
        Me.cboPurchaseAccountIdNo.DataValue = Nothing
        Me.cboPurchaseAccountIdNo.DefaultValue = Nothing
        Me.cboPurchaseAccountIdNo.DisplayMember = "Name"
        Me.cboPurchaseAccountIdNo.EditingMode = true
        Me.cboPurchaseAccountIdNo.EndFindValue = Nothing
        Me.cboPurchaseAccountIdNo.FieldDescription = Nothing
        Me.cboPurchaseAccountIdNo.FieldName = Nothing
        Me.cboPurchaseAccountIdNo.FilterRule = Nothing
        Me.cboPurchaseAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPurchaseAccountIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboPurchaseAccountIdNo, true)
        resources.ApplyResources(Me.cboPurchaseAccountIdNo, "cboPurchaseAccountIdNo")
        Me.cboPurchaseAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPurchaseAccountIdNo.FormattingEnabled = true
        Me.cboPurchaseAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPurchaseAccountIdNo.IgnoreCase = false
        Me.cboPurchaseAccountIdNo.LinkedLabel = Me.lblPurchaseAccountIdNo
        Me.cboPurchaseAccountIdNo.Name = "cboPurchaseAccountIdNo"
        Me.cboPurchaseAccountIdNo.OldValue = 0
        Me.cboPurchaseAccountIdNo.OriginalDataSource = Nothing
        Me.cboPurchaseAccountIdNo.OriginalList = Nothing
        Me.cboPurchaseAccountIdNo.OverrideDropDownStyleList = false
        Me.cboPurchaseAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboPurchaseAccountIdNo.PropertySelector = Nothing
        Me.cboPurchaseAccountIdNo.ReadOnlyCombo = false
        Me.cboPurchaseAccountIdNo.SuggestBoxHeight = 200
        Me.cboPurchaseAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboPurchaseAccountIdNo.TextToSearch = Nothing
        Me.cboPurchaseAccountIdNo.Translatable = false
        Me.cboPurchaseAccountIdNo.ValueIsMandatory = false
        Me.cboPurchaseAccountIdNo.ValueIsNullable = false
        Me.cboPurchaseAccountIdNo.ValueIsNumeric = false
        Me.cboPurchaseAccountIdNo.ValueMember = "IdNo"
        '
        'lblSaleAccountIdNo
        '
        Me.lblSaleAccountIdNo.DisplayOnly = true
        Me.lblSaleAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblSaleAccountIdNo, "lblSaleAccountIdNo")
        Me.lblSaleAccountIdNo.Name = "lblSaleAccountIdNo"
        Me.lblSaleAccountIdNo.Translatable = true
        '
        'cboSaleAccountIdNo
        '
        Me.cboSaleAccountIdNo.AlwaysEditable = false
        Me.cboSaleAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboSaleAccountIdNo.BegFindValue = Nothing
        Me.cboSaleAccountIdNo.ChangingSearchValueOnly = false
        Me.cboSaleAccountIdNo.CurrentSearchTerm = ""
        Me.cboSaleAccountIdNo.DataValue = Nothing
        Me.cboSaleAccountIdNo.DefaultValue = Nothing
        Me.cboSaleAccountIdNo.DisplayMember = "Name"
        Me.cboSaleAccountIdNo.EditingMode = true
        Me.cboSaleAccountIdNo.EndFindValue = Nothing
        Me.cboSaleAccountIdNo.FieldDescription = Nothing
        Me.cboSaleAccountIdNo.FieldName = Nothing
        Me.cboSaleAccountIdNo.FilterRule = Nothing
        Me.cboSaleAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboSaleAccountIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboSaleAccountIdNo, true)
        resources.ApplyResources(Me.cboSaleAccountIdNo, "cboSaleAccountIdNo")
        Me.cboSaleAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSaleAccountIdNo.FormattingEnabled = true
        Me.cboSaleAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSaleAccountIdNo.IgnoreCase = false
        Me.cboSaleAccountIdNo.LinkedLabel = Nothing
        Me.cboSaleAccountIdNo.Name = "cboSaleAccountIdNo"
        Me.cboSaleAccountIdNo.OldValue = 0
        Me.cboSaleAccountIdNo.OriginalDataSource = Nothing
        Me.cboSaleAccountIdNo.OriginalList = Nothing
        Me.cboSaleAccountIdNo.OverrideDropDownStyleList = false
        Me.cboSaleAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboSaleAccountIdNo.PropertySelector = Nothing
        Me.cboSaleAccountIdNo.ReadOnlyCombo = false
        Me.cboSaleAccountIdNo.SuggestBoxHeight = 200
        Me.cboSaleAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboSaleAccountIdNo.TextToSearch = Nothing
        Me.cboSaleAccountIdNo.Translatable = false
        Me.cboSaleAccountIdNo.ValueIsMandatory = false
        Me.cboSaleAccountIdNo.ValueIsNullable = false
        Me.cboSaleAccountIdNo.ValueIsNumeric = false
        Me.cboSaleAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatPurchaseAccountIdNo
        '
        Me.lblVatPurchaseAccountIdNo.DisplayOnly = true
        Me.lblVatPurchaseAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblVatPurchaseAccountIdNo, "lblVatPurchaseAccountIdNo")
        Me.lblVatPurchaseAccountIdNo.Name = "lblVatPurchaseAccountIdNo"
        Me.lblVatPurchaseAccountIdNo.Translatable = true
        '
        'cboVatPurchaseAccountIdNo
        '
        Me.cboVatPurchaseAccountIdNo.AlwaysEditable = false
        Me.cboVatPurchaseAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboVatPurchaseAccountIdNo.BegFindValue = Nothing
        Me.cboVatPurchaseAccountIdNo.ChangingSearchValueOnly = false
        Me.cboVatPurchaseAccountIdNo.CurrentSearchTerm = ""
        Me.cboVatPurchaseAccountIdNo.DataValue = Nothing
        Me.cboVatPurchaseAccountIdNo.DefaultValue = Nothing
        Me.cboVatPurchaseAccountIdNo.DisplayMember = "Name"
        Me.cboVatPurchaseAccountIdNo.EditingMode = true
        Me.cboVatPurchaseAccountIdNo.EndFindValue = Nothing
        Me.cboVatPurchaseAccountIdNo.FieldDescription = Nothing
        Me.cboVatPurchaseAccountIdNo.FieldName = Nothing
        Me.cboVatPurchaseAccountIdNo.FilterRule = Nothing
        Me.cboVatPurchaseAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboVatPurchaseAccountIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboVatPurchaseAccountIdNo, true)
        resources.ApplyResources(Me.cboVatPurchaseAccountIdNo, "cboVatPurchaseAccountIdNo")
        Me.cboVatPurchaseAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboVatPurchaseAccountIdNo.FormattingEnabled = true
        Me.cboVatPurchaseAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboVatPurchaseAccountIdNo.IgnoreCase = false
        Me.cboVatPurchaseAccountIdNo.LinkedLabel = Me.lblVatPurchaseAccountIdNo
        Me.cboVatPurchaseAccountIdNo.Name = "cboVatPurchaseAccountIdNo"
        Me.cboVatPurchaseAccountIdNo.OldValue = 0
        Me.cboVatPurchaseAccountIdNo.OriginalDataSource = Nothing
        Me.cboVatPurchaseAccountIdNo.OriginalList = Nothing
        Me.cboVatPurchaseAccountIdNo.OverrideDropDownStyleList = false
        Me.cboVatPurchaseAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboVatPurchaseAccountIdNo.PropertySelector = Nothing
        Me.cboVatPurchaseAccountIdNo.ReadOnlyCombo = false
        Me.cboVatPurchaseAccountIdNo.SuggestBoxHeight = 200
        Me.cboVatPurchaseAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboVatPurchaseAccountIdNo.TextToSearch = Nothing
        Me.cboVatPurchaseAccountIdNo.Translatable = false
        Me.cboVatPurchaseAccountIdNo.ValueIsMandatory = false
        Me.cboVatPurchaseAccountIdNo.ValueIsNullable = false
        Me.cboVatPurchaseAccountIdNo.ValueIsNumeric = false
        Me.cboVatPurchaseAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatSaleAccountIdNo
        '
        Me.lblVatSaleAccountIdNo.DisplayOnly = true
        Me.lblVatSaleAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblVatSaleAccountIdNo, "lblVatSaleAccountIdNo")
        Me.lblVatSaleAccountIdNo.Name = "lblVatSaleAccountIdNo"
        Me.lblVatSaleAccountIdNo.Translatable = true
        '
        'cboVatSaleAccountIdNo
        '
        Me.cboVatSaleAccountIdNo.AlwaysEditable = false
        Me.cboVatSaleAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboVatSaleAccountIdNo.BegFindValue = Nothing
        Me.cboVatSaleAccountIdNo.ChangingSearchValueOnly = false
        Me.cboVatSaleAccountIdNo.CurrentSearchTerm = ""
        Me.cboVatSaleAccountIdNo.DataValue = Nothing
        Me.cboVatSaleAccountIdNo.DefaultValue = Nothing
        Me.cboVatSaleAccountIdNo.DisplayMember = "Name"
        Me.cboVatSaleAccountIdNo.EditingMode = true
        Me.cboVatSaleAccountIdNo.EndFindValue = Nothing
        Me.cboVatSaleAccountIdNo.FieldDescription = Nothing
        Me.cboVatSaleAccountIdNo.FieldName = Nothing
        Me.cboVatSaleAccountIdNo.FilterRule = Nothing
        Me.cboVatSaleAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboVatSaleAccountIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboVatSaleAccountIdNo, true)
        resources.ApplyResources(Me.cboVatSaleAccountIdNo, "cboVatSaleAccountIdNo")
        Me.cboVatSaleAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboVatSaleAccountIdNo.FormattingEnabled = true
        Me.cboVatSaleAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboVatSaleAccountIdNo.IgnoreCase = false
        Me.cboVatSaleAccountIdNo.LinkedLabel = Me.lblVatSaleAccountIdNo
        Me.cboVatSaleAccountIdNo.Name = "cboVatSaleAccountIdNo"
        Me.cboVatSaleAccountIdNo.OldValue = 0
        Me.cboVatSaleAccountIdNo.OriginalDataSource = Nothing
        Me.cboVatSaleAccountIdNo.OriginalList = Nothing
        Me.cboVatSaleAccountIdNo.OverrideDropDownStyleList = false
        Me.cboVatSaleAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboVatSaleAccountIdNo.PropertySelector = Nothing
        Me.cboVatSaleAccountIdNo.ReadOnlyCombo = false
        Me.cboVatSaleAccountIdNo.SuggestBoxHeight = 200
        Me.cboVatSaleAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboVatSaleAccountIdNo.TextToSearch = Nothing
        Me.cboVatSaleAccountIdNo.Translatable = false
        Me.cboVatSaleAccountIdNo.ValueIsMandatory = false
        Me.cboVatSaleAccountIdNo.ValueIsNullable = false
        Me.cboVatSaleAccountIdNo.ValueIsNumeric = false
        Me.cboVatSaleAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatPercentage
        '
        Me.lblVatPercentage.DisplayOnly = true
        Me.lblVatPercentage.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.lblVatPercentage, true)
        resources.ApplyResources(Me.lblVatPercentage, "lblVatPercentage")
        Me.lblVatPercentage.Name = "lblVatPercentage"
        Me.lblVatPercentage.Translatable = true
        '
        'txtVatPercentage
        '
        Me.txtVatPercentage.BackColor = System.Drawing.Color.White
        Me.txtVatPercentage.BegFindValue = Nothing
        Me.txtVatPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatPercentage.ComputedValue = false
        Me.txtVatPercentage.CustomFormat = Nothing
        Me.txtVatPercentage.DataBoundControl = true
        Me.txtVatPercentage.EditingMode = true
        Me.txtVatPercentage.EndFindValue = Nothing
        Me.txtVatPercentage.FieldDescription = Nothing
        Me.txtVatPercentage.FieldName = Nothing
        Me.txtVatPercentage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatPercentage.FindEnabled = true
        resources.ApplyResources(Me.txtVatPercentage, "txtVatPercentage")
        Me.txtVatPercentage.ForeColor = System.Drawing.Color.Black
        Me.txtVatPercentage.LinkedLabel = Me.lblVatPercentage
        Me.txtVatPercentage.MaximumValue = Nothing
        Me.txtVatPercentage.MinimumValue = Nothing
        Me.txtVatPercentage.Name = "txtVatPercentage"
        Me.txtVatPercentage.OldValue = Nothing
        Me.txtVatPercentage.ReadOnly = true
        Me.txtVatPercentage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatPercentage.Translatable = false
        Me.txtVatPercentage.ValueIsMandatory = true
        '
        'lblPercentMark
        '
        resources.ApplyResources(Me.lblPercentMark, "lblPercentMark")
        Me.lblPercentMark.DisplayOnly = true
        Me.lblPercentMark.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.lblPercentMark, true)
        Me.lblPercentMark.Name = "lblPercentMark"
        Me.lblPercentMark.Translatable = true
        '
        'lblBranchIdNo
        '
        Me.lblBranchIdNo.DisplayOnly = true
        Me.lblBranchIdNo.EditingMode = false
        resources.ApplyResources(Me.lblBranchIdNo, "lblBranchIdNo")
        Me.lblBranchIdNo.Name = "lblBranchIdNo"
        Me.lblBranchIdNo.Translatable = true
        '
        'txtBranchIdNo
        '
        Me.txtBranchIdNo.BackColor = System.Drawing.Color.White
        Me.txtBranchIdNo.BegFindValue = Nothing
        Me.txtBranchIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchIdNo.ComputedValue = false
        Me.txtBranchIdNo.CustomFormat = Nothing
        Me.txtBranchIdNo.DataBoundControl = true
        Me.txtBranchIdNo.DisplayOnly = true
        Me.txtBranchIdNo.EditingMode = true
        Me.txtBranchIdNo.EndFindValue = Nothing
        Me.txtBranchIdNo.FieldDescription = Nothing
        Me.txtBranchIdNo.FieldName = Nothing
        Me.txtBranchIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBranchIdNo.FindEnabled = true
        resources.ApplyResources(Me.txtBranchIdNo, "txtBranchIdNo")
        Me.txtBranchIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtBranchIdNo.LinkedLabel = Me.lblBranchIdNo
        Me.txtBranchIdNo.MaximumValue = Nothing
        Me.txtBranchIdNo.MinimumValue = Nothing
        Me.txtBranchIdNo.Name = "txtBranchIdNo"
        Me.txtBranchIdNo.OldValue = Nothing
        Me.txtBranchIdNo.ReadOnly = true
        Me.txtBranchIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBranchIdNo.TabStop = false
        Me.txtBranchIdNo.Translatable = false
        Me.txtBranchIdNo.ValueIsNumeric = true
        '
        'CategoryEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "CategoryEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtCategoryCode As CTextBox
        Friend WithEvents txtCategoryName As CTextBox
        Friend WithEvents txtCategoryNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblPurchaseAccountIdNo As CLabel
        Friend WithEvents cboPurchaseAccountIdNo As CtComboBox
        Friend WithEvents lblSaleAccountIdNo As CLabel
        Friend WithEvents cboSaleAccountIdNo As CtComboBox
        Friend WithEvents lblVatPurchaseAccountIdNo As CLabel
        Friend WithEvents cboVatPurchaseAccountIdNo As CtComboBox
        Friend WithEvents lblVatPercentage As CLabel
        Friend WithEvents txtVatPercentage As CTextBox
        Friend WithEvents lblPercentMark As CLabel
        Friend WithEvents lblVatSaleAccountIdNo As CLabel
        Friend WithEvents cboVatSaleAccountIdNo As CtComboBox
        Friend WithEvents lblBranchIdNo As CLabel
        Friend WithEvents txtBranchIdNo As CTextBox
    End Class
End Namespace