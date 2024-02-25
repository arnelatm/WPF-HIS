Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DocumentEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDocumentCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDocumentCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDocumentName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblDocumentName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDocumentNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDocumentNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblDocumentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDocumentType = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.lblImageType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboImageType = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkNeedsNumber = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkNeedsIssueDate = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkNeedsExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
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
            'txtDocumentCode
            '
            Me.txtDocumentCode.BackColor = System.Drawing.Color.White
            Me.txtDocumentCode.BegFindValue = Nothing
            Me.txtDocumentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDocumentCode.ComputedValue = False
            Me.txtDocumentCode.CustomFormat = Nothing
            Me.txtDocumentCode.DataBoundControl = True
            Me.txtDocumentCode.EditingMode = False
            Me.txtDocumentCode.EndFindValue = Nothing
            Me.txtDocumentCode.FieldDescription = Nothing
            Me.txtDocumentCode.FieldName = Nothing
            Me.txtDocumentCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDocumentCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDocumentCode, True)
            resources.ApplyResources(Me.txtDocumentCode, "txtDocumentCode")
            Me.txtDocumentCode.ForeColor = System.Drawing.Color.Black
            Me.txtDocumentCode.LinkedLabel = Me.lblDocumentCode
            Me.txtDocumentCode.MaximumValue = Nothing
            Me.txtDocumentCode.MinimumValue = Nothing
            Me.txtDocumentCode.Name = "txtDocumentCode"
            Me.txtDocumentCode.OldValue = Nothing
            Me.txtDocumentCode.OverrideMaxLength = 0
            Me.txtDocumentCode.ReadOnly = True
            Me.txtDocumentCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDocumentCode.Translatable = False
            Me.txtDocumentCode.ValueIsMandatory = True
            '
            'lblDocumentCode
            '
            Me.lblDocumentCode.DisplayOnly = True
            Me.lblDocumentCode.EditingMode = False
            resources.ApplyResources(Me.lblDocumentCode, "lblDocumentCode")
            Me.lblDocumentCode.Name = "lblDocumentCode"
            Me.lblDocumentCode.Translatable = True
            '
            'txtDocumentName
            '
            Me.txtDocumentName.BackColor = System.Drawing.Color.White
            Me.txtDocumentName.BegFindValue = Nothing
            Me.txtDocumentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDocumentName.ComputedValue = False
            Me.txtDocumentName.CustomFormat = Nothing
            Me.txtDocumentName.DataBoundControl = True
            Me.txtDocumentName.EditingMode = False
            Me.txtDocumentName.EndFindValue = Nothing
            Me.txtDocumentName.FieldDescription = Nothing
            Me.txtDocumentName.FieldName = Nothing
            Me.txtDocumentName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDocumentName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDocumentName, True)
            resources.ApplyResources(Me.txtDocumentName, "txtDocumentName")
            Me.txtDocumentName.ForeColor = System.Drawing.Color.Black
            Me.txtDocumentName.LinkedLabel = Me.lblDocumentCode
            Me.txtDocumentName.MaximumValue = Nothing
            Me.txtDocumentName.MinimumValue = Nothing
            Me.txtDocumentName.Name = "txtDocumentName"
            Me.txtDocumentName.OldValue = Nothing
            Me.txtDocumentName.OverrideMaxLength = 0
            Me.txtDocumentName.ReadOnly = True
            Me.txtDocumentName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDocumentName.Translatable = False
            Me.txtDocumentName.ValueIsMandatory = True
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
            Me.floDataDisplay.Controls.Add(Me.lblDocumentCode)
            Me.floDataDisplay.Controls.Add(Me.txtDocumentCode)
            Me.floDataDisplay.Controls.Add(Me.lblDocumentName)
            Me.floDataDisplay.Controls.Add(Me.txtDocumentName)
            Me.floDataDisplay.Controls.Add(Me.lblDocumentNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtDocumentNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblDocumentType)
            Me.floDataDisplay.Controls.Add(Me.cboDocumentType)
            Me.floDataDisplay.Controls.Add(Me.lblImageType)
            Me.floDataDisplay.Controls.Add(Me.cboImageType)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.chkNeedsNumber)
            Me.floDataDisplay.Controls.Add(Me.CLabel2)
            Me.floDataDisplay.Controls.Add(Me.chkNeedsIssueDate)
            Me.floDataDisplay.Controls.Add(Me.CLabel3)
            Me.floDataDisplay.Controls.Add(Me.chkNeedsExpiryDate)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblDocumentName
            '
            Me.lblDocumentName.DisplayOnly = True
            Me.lblDocumentName.EditingMode = False
            resources.ApplyResources(Me.lblDocumentName, "lblDocumentName")
            Me.lblDocumentName.Name = "lblDocumentName"
            Me.lblDocumentName.Translatable = True
            '
            'lblDocumentNameAra
            '
            Me.lblDocumentNameAra.DisplayOnly = True
            Me.lblDocumentNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDocumentNameAra, "lblDocumentNameAra")
            Me.lblDocumentNameAra.Name = "lblDocumentNameAra"
            Me.lblDocumentNameAra.Translatable = True
            '
            'txtDocumentNameAra
            '
            Me.txtDocumentNameAra.BackColor = System.Drawing.Color.White
            Me.txtDocumentNameAra.BegFindValue = Nothing
            Me.txtDocumentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDocumentNameAra.ComputedValue = False
            Me.txtDocumentNameAra.CustomFormat = Nothing
            Me.txtDocumentNameAra.DataBoundControl = True
            Me.txtDocumentNameAra.EditingMode = False
            Me.txtDocumentNameAra.EndFindValue = Nothing
            Me.txtDocumentNameAra.EnglishControl = Me.txtDocumentName
            Me.txtDocumentNameAra.FieldDescription = Nothing
            Me.txtDocumentNameAra.FieldName = Nothing
            Me.txtDocumentNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDocumentNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDocumentNameAra, True)
            resources.ApplyResources(Me.txtDocumentNameAra, "txtDocumentNameAra")
            Me.txtDocumentNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDocumentNameAra.LinkedLabel = Me.lblDocumentNameAra
            Me.txtDocumentNameAra.MaximumValue = Nothing
            Me.txtDocumentNameAra.MinimumValue = Nothing
            Me.txtDocumentNameAra.Name = "txtDocumentNameAra"
            Me.txtDocumentNameAra.OldValue = Nothing
            Me.txtDocumentNameAra.OverrideMaxLength = 0
            Me.txtDocumentNameAra.ReadOnly = True
            Me.txtDocumentNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDocumentNameAra.Translatable = False
            '
            'lblDocumentType
            '
            Me.lblDocumentType.DisplayOnly = True
            Me.lblDocumentType.EditingMode = False
            resources.ApplyResources(Me.lblDocumentType, "lblDocumentType")
            Me.lblDocumentType.Name = "lblDocumentType"
            Me.lblDocumentType.Translatable = True
            '
            'cboDocumentType
            '
            Me.cboDocumentType.BackColor = System.Drawing.Color.White
            Me.cboDocumentType.BegFindValue = Nothing
            Me.cboDocumentType.ChangingSearchValueOnly = False
            Me.cboDocumentType.CurrentSearchTerm = ""
            Me.cboDocumentType.DataValue = Nothing
            Me.cboDocumentType.DefaultValue = Nothing
            Me.cboDocumentType.DisplayMember = "Name"
            Me.cboDocumentType.Editable = True
            Me.cboDocumentType.EditingMode = True
            Me.cboDocumentType.EndFindValue = Nothing
            Me.cboDocumentType.FieldDescription = Nothing
            Me.cboDocumentType.FieldName = Nothing
            Me.cboDocumentType.FilterRule = Nothing
            Me.cboDocumentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDocumentType.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.cboDocumentType, True)
            resources.ApplyResources(Me.cboDocumentType, "cboDocumentType")
            Me.cboDocumentType.ForeColor = System.Drawing.Color.Black
            Me.cboDocumentType.FormattingEnabled = True
            Me.cboDocumentType.HideWhenNotEditingOrAdding = False
            Me.cboDocumentType.IgnoreCase = False
            Me.cboDocumentType.LimitToList = False
            Me.cboDocumentType.LinkedLabel = Me.lblDocumentType
            Me.cboDocumentType.Name = "cboDocumentType"
            Me.cboDocumentType.OldValue = 0
            Me.cboDocumentType.OriginalDataSource = Nothing
            Me.cboDocumentType.OriginalList = Nothing
            Me.cboDocumentType.OverrideDropDownStyleList = False
            Me.cboDocumentType.PreviousSearchTerm = Nothing
            Me.cboDocumentType.PropertySelector = Nothing
            Me.cboDocumentType.SuggestBoxHeight = 200
            Me.cboDocumentType.SuggestListOrderRule = Nothing
            Me.cboDocumentType.TextToSearch = Nothing
            Me.cboDocumentType.Translatable = False
            Me.cboDocumentType.ValueIsMandatory = False
            Me.cboDocumentType.ValueIsNullable = False
            Me.cboDocumentType.ValueIsNumeric = False
            Me.cboDocumentType.ValueMember = "Code"
            '
            'lblImageType
            '
            Me.lblImageType.DisplayOnly = True
            Me.lblImageType.EditingMode = False
            resources.ApplyResources(Me.lblImageType, "lblImageType")
            Me.lblImageType.Name = "lblImageType"
            Me.lblImageType.Translatable = True
            '
            'cboImageType
            '
            Me.cboImageType.BackColor = System.Drawing.Color.White
            Me.cboImageType.BegFindValue = Nothing
            Me.cboImageType.ChangingSearchValueOnly = False
            Me.cboImageType.CurrentSearchTerm = ""
            Me.cboImageType.DataValue = Nothing
            Me.cboImageType.DefaultValue = Nothing
            Me.cboImageType.DisplayMember = "Name"
            Me.cboImageType.Editable = True
            Me.cboImageType.EditingMode = True
            Me.cboImageType.EndFindValue = Nothing
            Me.cboImageType.FieldDescription = Nothing
            Me.cboImageType.FieldName = Nothing
            Me.cboImageType.FilterRule = Nothing
            Me.cboImageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboImageType.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboImageType, True)
            resources.ApplyResources(Me.cboImageType, "cboImageType")
            Me.cboImageType.ForeColor = System.Drawing.Color.Black
            Me.cboImageType.FormattingEnabled = True
            Me.cboImageType.HideWhenNotEditingOrAdding = False
            Me.cboImageType.IgnoreCase = False
            Me.cboImageType.LimitToList = False
            Me.cboImageType.LinkedLabel = Nothing
            Me.cboImageType.Name = "cboImageType"
            Me.cboImageType.OldValue = 0
            Me.cboImageType.OriginalDataSource = Nothing
            Me.cboImageType.OriginalList = Nothing
            Me.cboImageType.OverrideDropDownStyleList = False
            Me.cboImageType.PreviousSearchTerm = Nothing
            Me.cboImageType.PropertySelector = Nothing
            Me.cboImageType.SuggestBoxHeight = 200
            Me.cboImageType.SuggestListOrderRule = Nothing
            Me.cboImageType.TextToSearch = Nothing
            Me.cboImageType.Translatable = False
            Me.cboImageType.ValueIsMandatory = False
            Me.cboImageType.ValueIsNullable = False
            Me.cboImageType.ValueIsNumeric = False
            Me.cboImageType.ValueMember = "Code"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'chkNeedsNumber
            '
            resources.ApplyResources(Me.chkNeedsNumber, "chkNeedsNumber")
            Me.chkNeedsNumber.AutoCheck = False
            Me.chkNeedsNumber.BackColor = System.Drawing.Color.White
            Me.chkNeedsNumber.BegFindValue = Nothing
            Me.chkNeedsNumber.DisplayOnly = False
            Me.chkNeedsNumber.EditingMode = False
            Me.chkNeedsNumber.EndFindValue = Nothing
            Me.chkNeedsNumber.FieldDescription = Nothing
            Me.chkNeedsNumber.FieldName = Nothing
            Me.chkNeedsNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkNeedsNumber.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.chkNeedsNumber, True)
            Me.chkNeedsNumber.ForeColor = System.Drawing.Color.Black
            Me.chkNeedsNumber.IFindableControl_FindEnabled = False
            Me.chkNeedsNumber.IgnoreCase = False
            Me.chkNeedsNumber.LinkedLabel = Nothing
            Me.chkNeedsNumber.Name = "chkNeedsNumber"
            Me.chkNeedsNumber.NoLabel = False
            Me.chkNeedsNumber.OldValue = ""
            Me.chkNeedsNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkNeedsNumber.Translatable = False
            Me.chkNeedsNumber.UseVisualStyleBackColor = False
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Translatable = True
            '
            'chkNeedsIssueDate
            '
            resources.ApplyResources(Me.chkNeedsIssueDate, "chkNeedsIssueDate")
            Me.chkNeedsIssueDate.AutoCheck = False
            Me.chkNeedsIssueDate.BackColor = System.Drawing.Color.White
            Me.chkNeedsIssueDate.BegFindValue = Nothing
            Me.chkNeedsIssueDate.DisplayOnly = False
            Me.chkNeedsIssueDate.EditingMode = False
            Me.chkNeedsIssueDate.EndFindValue = Nothing
            Me.chkNeedsIssueDate.FieldDescription = Nothing
            Me.chkNeedsIssueDate.FieldName = Nothing
            Me.chkNeedsIssueDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkNeedsIssueDate.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.chkNeedsIssueDate, True)
            Me.chkNeedsIssueDate.ForeColor = System.Drawing.Color.Black
            Me.chkNeedsIssueDate.IFindableControl_FindEnabled = False
            Me.chkNeedsIssueDate.IgnoreCase = False
            Me.chkNeedsIssueDate.LinkedLabel = Nothing
            Me.chkNeedsIssueDate.Name = "chkNeedsIssueDate"
            Me.chkNeedsIssueDate.NoLabel = False
            Me.chkNeedsIssueDate.OldValue = ""
            Me.chkNeedsIssueDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkNeedsIssueDate.Translatable = False
            Me.chkNeedsIssueDate.UseVisualStyleBackColor = False
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Translatable = True
            '
            'chkNeedsExpiryDate
            '
            resources.ApplyResources(Me.chkNeedsExpiryDate, "chkNeedsExpiryDate")
            Me.chkNeedsExpiryDate.AutoCheck = False
            Me.chkNeedsExpiryDate.BackColor = System.Drawing.Color.White
            Me.chkNeedsExpiryDate.BegFindValue = Nothing
            Me.chkNeedsExpiryDate.DisplayOnly = False
            Me.chkNeedsExpiryDate.EditingMode = False
            Me.chkNeedsExpiryDate.EndFindValue = Nothing
            Me.chkNeedsExpiryDate.FieldDescription = Nothing
        Me.chkNeedsExpiryDate.FieldName = Nothing
        Me.chkNeedsExpiryDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkNeedsExpiryDate.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.chkNeedsExpiryDate, true)
        Me.chkNeedsExpiryDate.ForeColor = System.Drawing.Color.Black
        Me.chkNeedsExpiryDate.IFindableControl_FindEnabled = false
        Me.chkNeedsExpiryDate.IgnoreCase = false
        Me.chkNeedsExpiryDate.LinkedLabel = Nothing
        Me.chkNeedsExpiryDate.Name = "chkNeedsExpiryDate"
        Me.chkNeedsExpiryDate.NoLabel = false
        Me.chkNeedsExpiryDate.OldValue = ""
        Me.chkNeedsExpiryDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkNeedsExpiryDate.Translatable = false
        Me.chkNeedsExpiryDate.UseVisualStyleBackColor = false
        '
        'DocumentEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "DocumentEntryTv"
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
        Friend WithEvents txtDocumentCode As CTextBox
        Friend WithEvents txtDocumentName As CTextBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblDocumentCode As CLabel
        Friend WithEvents lblDocumentName As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblDocumentType As CLabel
        Friend WithEvents cboDocumentType As CtCombobox
        Friend WithEvents lblImageType As CLabel
        Friend WithEvents cboImageType As CtCombobox
        Friend WithEvents lblDocumentNameAra As CLabel
        Friend WithEvents txtDocumentNameAra As CTextBoxArabic
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents chkNeedsNumber As CCheckBox
        Friend WithEvents chkNeedsIssueDate As CCheckBox
        Friend WithEvents chkNeedsExpiryDate As CCheckBox
    End Class
End Namespace