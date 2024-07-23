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
            Me.lblBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblVatPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboVatPurchaseAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblVatSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboVatSaleAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblVatPercentage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkNeedsExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.txtVatPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPercentMark = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'txtCategoryCode
            '
            Me.txtCategoryCode.BackColor = System.Drawing.Color.White
            Me.txtCategoryCode.BegFindValue = Nothing
            Me.txtCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCategoryCode.ComputedValue = False
            Me.txtCategoryCode.CustomFormat = Nothing
            Me.txtCategoryCode.DataBoundControl = True
            Me.txtCategoryCode.EditingMode = True
            Me.txtCategoryCode.EndFindValue = Nothing
            Me.txtCategoryCode.FieldDescription = Nothing
            Me.txtCategoryCode.FieldName = Nothing
            Me.txtCategoryCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCategoryCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCategoryCode, True)
            resources.ApplyResources(Me.txtCategoryCode, "txtCategoryCode")
            Me.txtCategoryCode.ForeColor = System.Drawing.Color.Black
            Me.txtCategoryCode.LinkedLabel = Me.lblCode
            Me.txtCategoryCode.MaximumValue = Nothing
            Me.txtCategoryCode.MinimumValue = Nothing
            Me.txtCategoryCode.Name = "txtCategoryCode"
            Me.txtCategoryCode.OldValue = Nothing
            Me.txtCategoryCode.OverrideMaxLength = 0
            Me.txtCategoryCode.ReadOnly = True
            Me.txtCategoryCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCategoryCode.Translatable = False
            Me.txtCategoryCode.ValueIsMandatory = True
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
            '
            'txtCategoryName
            '
            Me.txtCategoryName.BackColor = System.Drawing.Color.White
            Me.txtCategoryName.BegFindValue = Nothing
            Me.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCategoryName.ComputedValue = False
            Me.txtCategoryName.CustomFormat = Nothing
            Me.txtCategoryName.DataBoundControl = True
            Me.txtCategoryName.EditingMode = False
            Me.txtCategoryName.EndFindValue = Nothing
            Me.txtCategoryName.FieldDescription = Nothing
            Me.txtCategoryName.FieldName = Nothing
            Me.txtCategoryName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCategoryName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCategoryName, True)
            resources.ApplyResources(Me.txtCategoryName, "txtCategoryName")
            Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
            Me.txtCategoryName.LinkedLabel = Me.lblName
            Me.txtCategoryName.MaximumValue = Nothing
            Me.txtCategoryName.MinimumValue = Nothing
            Me.txtCategoryName.Name = "txtCategoryName"
            Me.txtCategoryName.OldValue = Nothing
            Me.txtCategoryName.OverrideMaxLength = 0
            Me.txtCategoryName.ReadOnly = True
            Me.txtCategoryName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCategoryName.Translatable = False
            Me.txtCategoryName.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'txtCategoryNameAra
            '
            Me.txtCategoryNameAra.BackColor = System.Drawing.Color.White
            Me.txtCategoryNameAra.BegFindValue = Nothing
            Me.txtCategoryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCategoryNameAra.ComputedValue = False
            Me.txtCategoryNameAra.CustomFormat = Nothing
            Me.txtCategoryNameAra.DataBoundControl = True
            Me.txtCategoryNameAra.EditingMode = False
            Me.txtCategoryNameAra.EndFindValue = Nothing
            Me.txtCategoryNameAra.EnglishControl = Me.txtCategoryName
            Me.txtCategoryNameAra.FieldDescription = Nothing
            Me.txtCategoryNameAra.FieldName = Nothing
            Me.txtCategoryNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCategoryNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCategoryNameAra, True)
            resources.ApplyResources(Me.txtCategoryNameAra, "txtCategoryNameAra")
            Me.txtCategoryNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtCategoryNameAra.LinkedLabel = Me.lblNameAra
            Me.txtCategoryNameAra.MaximumValue = Nothing
            Me.txtCategoryNameAra.MinimumValue = Nothing
            Me.txtCategoryNameAra.Name = "txtCategoryNameAra"
            Me.txtCategoryNameAra.OldValue = Nothing
            Me.txtCategoryNameAra.OverrideMaxLength = 0
            Me.txtCategoryNameAra.ReadOnly = True
            Me.txtCategoryNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCategoryNameAra.Translatable = False
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
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
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.chkNeedsExpiryDate)
            Me.floDataDisplay.Controls.Add(Me.txtVatPercentage)
            Me.floDataDisplay.Controls.Add(Me.lblPercentMark)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblBranchIdNo
            '
            Me.lblBranchIdNo.DisplayOnly = True
            Me.lblBranchIdNo.EditingMode = False
            resources.ApplyResources(Me.lblBranchIdNo, "lblBranchIdNo")
            Me.lblBranchIdNo.Name = "lblBranchIdNo"
            Me.lblBranchIdNo.Translatable = True
            '
            'txtBranchIdNo
            '
            Me.txtBranchIdNo.BackColor = System.Drawing.Color.White
            Me.txtBranchIdNo.BegFindValue = Nothing
            Me.txtBranchIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchIdNo.ComputedValue = False
            Me.txtBranchIdNo.CustomFormat = Nothing
            Me.txtBranchIdNo.DataBoundControl = True
            Me.txtBranchIdNo.DisplayOnly = True
            Me.txtBranchIdNo.EditingMode = True
            Me.txtBranchIdNo.EndFindValue = Nothing
            Me.txtBranchIdNo.FieldDescription = Nothing
            Me.txtBranchIdNo.FieldName = Nothing
            Me.txtBranchIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchIdNo.FindEnabled = True
            resources.ApplyResources(Me.txtBranchIdNo, "txtBranchIdNo")
            Me.txtBranchIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtBranchIdNo.LinkedLabel = Me.lblBranchIdNo
            Me.txtBranchIdNo.MaximumValue = Nothing
            Me.txtBranchIdNo.MinimumValue = Nothing
            Me.txtBranchIdNo.Name = "txtBranchIdNo"
            Me.txtBranchIdNo.OldValue = Nothing
            Me.txtBranchIdNo.OverrideMaxLength = 0
            Me.txtBranchIdNo.ReadOnly = True
            Me.txtBranchIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchIdNo.TabStop = False
            Me.txtBranchIdNo.Translatable = False
            Me.txtBranchIdNo.ValueIsNumeric = True
            '
            'lblPurchaseAccountIdNo
            '
            Me.lblPurchaseAccountIdNo.DisplayOnly = True
            Me.lblPurchaseAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblPurchaseAccountIdNo, "lblPurchaseAccountIdNo")
            Me.lblPurchaseAccountIdNo.Name = "lblPurchaseAccountIdNo"
            Me.lblPurchaseAccountIdNo.Translatable = True
            '
            'cboPurchaseAccountIdNo
            '
            Me.cboPurchaseAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboPurchaseAccountIdNo.BegFindValue = Nothing
            Me.cboPurchaseAccountIdNo.ChangingSearchValueOnly = False
            Me.cboPurchaseAccountIdNo.CurrentSearchTerm = ""
            Me.cboPurchaseAccountIdNo.DataValue = Nothing
            Me.cboPurchaseAccountIdNo.DefaultValue = Nothing
            Me.cboPurchaseAccountIdNo.DisplayMember = "Name"
            Me.cboPurchaseAccountIdNo.Editable = True
            Me.cboPurchaseAccountIdNo.EditingMode = True
            Me.cboPurchaseAccountIdNo.EndFindValue = Nothing
            Me.cboPurchaseAccountIdNo.FieldDescription = Nothing
            Me.cboPurchaseAccountIdNo.FieldName = Nothing
            Me.cboPurchaseAccountIdNo.FilterRule = Nothing
            Me.cboPurchaseAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPurchaseAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboPurchaseAccountIdNo, True)
            resources.ApplyResources(Me.cboPurchaseAccountIdNo, "cboPurchaseAccountIdNo")
            Me.cboPurchaseAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPurchaseAccountIdNo.FormattingEnabled = True
            Me.cboPurchaseAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPurchaseAccountIdNo.IgnoreCase = False
            Me.cboPurchaseAccountIdNo.LimitToList = False
            Me.cboPurchaseAccountIdNo.LinkedLabel = Me.lblPurchaseAccountIdNo
            Me.cboPurchaseAccountIdNo.Name = "cboPurchaseAccountIdNo"
            Me.cboPurchaseAccountIdNo.OldValue = 0
            Me.cboPurchaseAccountIdNo.OriginalDataSource = Nothing
            Me.cboPurchaseAccountIdNo.OriginalList = Nothing
            Me.cboPurchaseAccountIdNo.OverrideDropDownStyleList = False
            Me.cboPurchaseAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboPurchaseAccountIdNo.PropertySelector = Nothing
            Me.cboPurchaseAccountIdNo.SuggestBoxHeight = 200
            Me.cboPurchaseAccountIdNo.SuggestCharCount = 1
            Me.cboPurchaseAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboPurchaseAccountIdNo.TextToSearch = Nothing
            Me.cboPurchaseAccountIdNo.Translatable = False
            Me.cboPurchaseAccountIdNo.ValueIsMandatory = False
            Me.cboPurchaseAccountIdNo.ValueIsNullable = False
            Me.cboPurchaseAccountIdNo.ValueIsNumeric = False
            Me.cboPurchaseAccountIdNo.ValueMember = "IdNo"
            '
            'lblSaleAccountIdNo
            '
            Me.lblSaleAccountIdNo.DisplayOnly = True
            Me.lblSaleAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblSaleAccountIdNo, "lblSaleAccountIdNo")
            Me.lblSaleAccountIdNo.Name = "lblSaleAccountIdNo"
            Me.lblSaleAccountIdNo.Translatable = True
            '
            'cboSaleAccountIdNo
            '
            Me.cboSaleAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboSaleAccountIdNo.BegFindValue = Nothing
            Me.cboSaleAccountIdNo.ChangingSearchValueOnly = False
            Me.cboSaleAccountIdNo.CurrentSearchTerm = ""
            Me.cboSaleAccountIdNo.DataValue = Nothing
            Me.cboSaleAccountIdNo.DefaultValue = Nothing
            Me.cboSaleAccountIdNo.DisplayMember = "Name"
            Me.cboSaleAccountIdNo.Editable = True
            Me.cboSaleAccountIdNo.EditingMode = True
            Me.cboSaleAccountIdNo.EndFindValue = Nothing
            Me.cboSaleAccountIdNo.FieldDescription = Nothing
            Me.cboSaleAccountIdNo.FieldName = Nothing
            Me.cboSaleAccountIdNo.FilterRule = Nothing
            Me.cboSaleAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSaleAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboSaleAccountIdNo, True)
            resources.ApplyResources(Me.cboSaleAccountIdNo, "cboSaleAccountIdNo")
            Me.cboSaleAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSaleAccountIdNo.FormattingEnabled = True
            Me.cboSaleAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSaleAccountIdNo.IgnoreCase = False
            Me.cboSaleAccountIdNo.LimitToList = False
            Me.cboSaleAccountIdNo.LinkedLabel = Nothing
            Me.cboSaleAccountIdNo.Name = "cboSaleAccountIdNo"
            Me.cboSaleAccountIdNo.OldValue = 0
            Me.cboSaleAccountIdNo.OriginalDataSource = Nothing
            Me.cboSaleAccountIdNo.OriginalList = Nothing
            Me.cboSaleAccountIdNo.OverrideDropDownStyleList = False
            Me.cboSaleAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboSaleAccountIdNo.PropertySelector = Nothing
            Me.cboSaleAccountIdNo.SuggestBoxHeight = 200
            Me.cboSaleAccountIdNo.SuggestCharCount = 1
            Me.cboSaleAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboSaleAccountIdNo.TextToSearch = Nothing
            Me.cboSaleAccountIdNo.Translatable = False
            Me.cboSaleAccountIdNo.ValueIsMandatory = False
            Me.cboSaleAccountIdNo.ValueIsNullable = False
            Me.cboSaleAccountIdNo.ValueIsNumeric = False
            Me.cboSaleAccountIdNo.ValueMember = "IdNo"
            '
            'lblVatPurchaseAccountIdNo
            '
            Me.lblVatPurchaseAccountIdNo.DisplayOnly = True
            Me.lblVatPurchaseAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblVatPurchaseAccountIdNo, "lblVatPurchaseAccountIdNo")
            Me.lblVatPurchaseAccountIdNo.Name = "lblVatPurchaseAccountIdNo"
            Me.lblVatPurchaseAccountIdNo.Translatable = True
            '
            'cboVatPurchaseAccountIdNo
            '
            Me.cboVatPurchaseAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboVatPurchaseAccountIdNo.BegFindValue = Nothing
            Me.cboVatPurchaseAccountIdNo.ChangingSearchValueOnly = False
            Me.cboVatPurchaseAccountIdNo.CurrentSearchTerm = ""
            Me.cboVatPurchaseAccountIdNo.DataValue = Nothing
            Me.cboVatPurchaseAccountIdNo.DefaultValue = Nothing
            Me.cboVatPurchaseAccountIdNo.DisplayMember = "Name"
            Me.cboVatPurchaseAccountIdNo.Editable = True
            Me.cboVatPurchaseAccountIdNo.EditingMode = True
            Me.cboVatPurchaseAccountIdNo.EndFindValue = Nothing
            Me.cboVatPurchaseAccountIdNo.FieldDescription = Nothing
            Me.cboVatPurchaseAccountIdNo.FieldName = Nothing
            Me.cboVatPurchaseAccountIdNo.FilterRule = Nothing
            Me.cboVatPurchaseAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboVatPurchaseAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboVatPurchaseAccountIdNo, True)
            resources.ApplyResources(Me.cboVatPurchaseAccountIdNo, "cboVatPurchaseAccountIdNo")
            Me.cboVatPurchaseAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboVatPurchaseAccountIdNo.FormattingEnabled = True
            Me.cboVatPurchaseAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboVatPurchaseAccountIdNo.IgnoreCase = False
            Me.cboVatPurchaseAccountIdNo.LimitToList = False
            Me.cboVatPurchaseAccountIdNo.LinkedLabel = Me.lblVatPurchaseAccountIdNo
            Me.cboVatPurchaseAccountIdNo.Name = "cboVatPurchaseAccountIdNo"
            Me.cboVatPurchaseAccountIdNo.OldValue = 0
            Me.cboVatPurchaseAccountIdNo.OriginalDataSource = Nothing
            Me.cboVatPurchaseAccountIdNo.OriginalList = Nothing
            Me.cboVatPurchaseAccountIdNo.OverrideDropDownStyleList = False
            Me.cboVatPurchaseAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboVatPurchaseAccountIdNo.PropertySelector = Nothing
            Me.cboVatPurchaseAccountIdNo.SuggestBoxHeight = 200
            Me.cboVatPurchaseAccountIdNo.SuggestCharCount = 1
            Me.cboVatPurchaseAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboVatPurchaseAccountIdNo.TextToSearch = Nothing
            Me.cboVatPurchaseAccountIdNo.Translatable = False
            Me.cboVatPurchaseAccountIdNo.ValueIsMandatory = False
            Me.cboVatPurchaseAccountIdNo.ValueIsNullable = False
            Me.cboVatPurchaseAccountIdNo.ValueIsNumeric = False
            Me.cboVatPurchaseAccountIdNo.ValueMember = "IdNo"
            '
            'lblVatSaleAccountIdNo
            '
            Me.lblVatSaleAccountIdNo.DisplayOnly = True
            Me.lblVatSaleAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblVatSaleAccountIdNo, "lblVatSaleAccountIdNo")
            Me.lblVatSaleAccountIdNo.Name = "lblVatSaleAccountIdNo"
            Me.lblVatSaleAccountIdNo.Translatable = True
            '
            'cboVatSaleAccountIdNo
            '
            Me.cboVatSaleAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboVatSaleAccountIdNo.BegFindValue = Nothing
            Me.cboVatSaleAccountIdNo.ChangingSearchValueOnly = False
            Me.cboVatSaleAccountIdNo.CurrentSearchTerm = ""
            Me.cboVatSaleAccountIdNo.DataValue = Nothing
            Me.cboVatSaleAccountIdNo.DefaultValue = Nothing
            Me.cboVatSaleAccountIdNo.DisplayMember = "Name"
            Me.cboVatSaleAccountIdNo.Editable = True
            Me.cboVatSaleAccountIdNo.EditingMode = True
            Me.cboVatSaleAccountIdNo.EndFindValue = Nothing
            Me.cboVatSaleAccountIdNo.FieldDescription = Nothing
            Me.cboVatSaleAccountIdNo.FieldName = Nothing
            Me.cboVatSaleAccountIdNo.FilterRule = Nothing
            Me.cboVatSaleAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboVatSaleAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboVatSaleAccountIdNo, True)
            resources.ApplyResources(Me.cboVatSaleAccountIdNo, "cboVatSaleAccountIdNo")
            Me.cboVatSaleAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboVatSaleAccountIdNo.FormattingEnabled = True
            Me.cboVatSaleAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboVatSaleAccountIdNo.IgnoreCase = False
            Me.cboVatSaleAccountIdNo.LimitToList = False
            Me.cboVatSaleAccountIdNo.LinkedLabel = Me.lblVatSaleAccountIdNo
            Me.cboVatSaleAccountIdNo.Name = "cboVatSaleAccountIdNo"
            Me.cboVatSaleAccountIdNo.OldValue = 0
            Me.cboVatSaleAccountIdNo.OriginalDataSource = Nothing
            Me.cboVatSaleAccountIdNo.OriginalList = Nothing
            Me.cboVatSaleAccountIdNo.OverrideDropDownStyleList = False
            Me.cboVatSaleAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboVatSaleAccountIdNo.PropertySelector = Nothing
            Me.cboVatSaleAccountIdNo.SuggestBoxHeight = 200
            Me.cboVatSaleAccountIdNo.SuggestCharCount = 1
            Me.cboVatSaleAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboVatSaleAccountIdNo.TextToSearch = Nothing
            Me.cboVatSaleAccountIdNo.Translatable = False
            Me.cboVatSaleAccountIdNo.ValueIsMandatory = False
            Me.cboVatSaleAccountIdNo.ValueIsNullable = False
            Me.cboVatSaleAccountIdNo.ValueIsNumeric = False
            Me.cboVatSaleAccountIdNo.ValueMember = "IdNo"
            '
            'lblVatPercentage
            '
            Me.lblVatPercentage.DisplayOnly = True
            Me.lblVatPercentage.EditingMode = False
            resources.ApplyResources(Me.lblVatPercentage, "lblVatPercentage")
            Me.lblVatPercentage.Name = "lblVatPercentage"
            Me.lblVatPercentage.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'chkNeedsExpiryDate
            '
            Me.chkNeedsExpiryDate.BegFindValue = Nothing
            Me.chkNeedsExpiryDate.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkNeedsExpiryDate.DisplayOnly = False
            Me.chkNeedsExpiryDate.EditingMode = True
            Me.chkNeedsExpiryDate.EndFindValue = Nothing
            Me.chkNeedsExpiryDate.FieldDescription = Nothing
            Me.chkNeedsExpiryDate.FieldName = Nothing
            Me.chkNeedsExpiryDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkNeedsExpiryDate.FindEnabled = False
            resources.ApplyResources(Me.chkNeedsExpiryDate, "chkNeedsExpiryDate")
            Me.chkNeedsExpiryDate.IFindableControl_FindEnabled = False
            Me.chkNeedsExpiryDate.IgnoreCase = False
            Me.chkNeedsExpiryDate.LinkedLabel = Nothing
            Me.chkNeedsExpiryDate.Name = "chkNeedsExpiryDate"
            Me.chkNeedsExpiryDate.OldValue = Nothing
            Me.chkNeedsExpiryDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkNeedsExpiryDate.Translatable = True
            Me.chkNeedsExpiryDate.UseVisualStyleBackColor = True
            '
            'txtVatPercentage
            '
            Me.txtVatPercentage.BackColor = System.Drawing.Color.White
            Me.txtVatPercentage.BegFindValue = Nothing
            Me.txtVatPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatPercentage.ComputedValue = False
            Me.txtVatPercentage.CustomFormat = Nothing
            Me.txtVatPercentage.DataBoundControl = True
            Me.txtVatPercentage.EditingMode = True
            Me.txtVatPercentage.EndFindValue = Nothing
            Me.txtVatPercentage.FieldDescription = Nothing
            Me.txtVatPercentage.FieldName = Nothing
            Me.txtVatPercentage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatPercentage.FindEnabled = True
            resources.ApplyResources(Me.txtVatPercentage, "txtVatPercentage")
            Me.txtVatPercentage.ForeColor = System.Drawing.Color.Black
            Me.txtVatPercentage.LinkedLabel = Me.lblVatPercentage
            Me.txtVatPercentage.MaximumValue = Nothing
            Me.txtVatPercentage.MinimumValue = Nothing
            Me.txtVatPercentage.Name = "txtVatPercentage"
            Me.txtVatPercentage.OldValue = Nothing
            Me.txtVatPercentage.OverrideMaxLength = 0
            Me.txtVatPercentage.ReadOnly = True
            Me.txtVatPercentage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatPercentage.Translatable = False
            Me.txtVatPercentage.ValueIsMandatory = True
            '
            'lblPercentMark
            '
            resources.ApplyResources(Me.lblPercentMark, "lblPercentMark")
            Me.lblPercentMark.DisplayOnly = True
            Me.lblPercentMark.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.lblPercentMark, True)
            Me.lblPercentMark.Name = "lblPercentMark"
            Me.lblPercentMark.Translatable = True
            '
            'CategoryEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "CategoryEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents cboPurchaseAccountIdNo As AtmComboBox
        Friend WithEvents lblSaleAccountIdNo As CLabel
        Friend WithEvents cboSaleAccountIdNo As AtmComboBox
        Friend WithEvents lblVatPurchaseAccountIdNo As CLabel
        Friend WithEvents cboVatPurchaseAccountIdNo As AtmComboBox
        Friend WithEvents lblVatPercentage As CLabel
        Friend WithEvents txtVatPercentage As CTextBox
        Friend WithEvents lblPercentMark As CLabel
        Friend WithEvents lblVatSaleAccountIdNo As CLabel
        Friend WithEvents cboVatSaleAccountIdNo As AtmComboBox
        Friend WithEvents lblBranchIdNo As CLabel
        Friend WithEvents txtBranchIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents chkNeedsExpiryDate As CCheckBoxNew
    End Class
End Namespace