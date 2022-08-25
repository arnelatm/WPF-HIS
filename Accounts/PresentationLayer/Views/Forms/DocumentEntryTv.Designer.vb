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
        Me.cboDocumentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblImageType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboImageType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkNeedsNumber = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.chkNeedsIssueDate = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.chkNeedsExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
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
        'txtDocumentCode
        '
        Me.txtDocumentCode.BackColor = System.Drawing.Color.White
        Me.txtDocumentCode.BegFindValue = Nothing
        Me.txtDocumentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentCode.ComputedValue = false
        Me.txtDocumentCode.CustomFormat = Nothing
        Me.txtDocumentCode.DataBoundControl = true
        Me.txtDocumentCode.EditingMode = false
        Me.txtDocumentCode.EndFindValue = Nothing
        Me.txtDocumentCode.FieldDescription = Nothing
        Me.txtDocumentCode.FieldName = Nothing
        Me.txtDocumentCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDocumentCode.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDocumentCode, true)
        resources.ApplyResources(Me.txtDocumentCode, "txtDocumentCode")
        Me.txtDocumentCode.ForeColor = System.Drawing.Color.Black
        Me.txtDocumentCode.LinkedLabel = Me.lblDocumentCode
        Me.txtDocumentCode.MaximumValue = Nothing
        Me.txtDocumentCode.MinimumValue = Nothing
        Me.txtDocumentCode.Name = "txtDocumentCode"
        Me.txtDocumentCode.OldValue = Nothing
        Me.txtDocumentCode.ReadOnly = true
        Me.txtDocumentCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDocumentCode.Translatable = false
        Me.txtDocumentCode.ValueIsMandatory = true
        '
        'lblDocumentCode
        '
        Me.lblDocumentCode.DisplayOnly = true
        Me.lblDocumentCode.EditingMode = false
        resources.ApplyResources(Me.lblDocumentCode, "lblDocumentCode")
        Me.lblDocumentCode.Name = "lblDocumentCode"
        Me.lblDocumentCode.Translatable = true
        '
        'txtDocumentName
        '
        Me.txtDocumentName.BackColor = System.Drawing.Color.White
        Me.txtDocumentName.BegFindValue = Nothing
        Me.txtDocumentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentName.ComputedValue = false
        Me.txtDocumentName.CustomFormat = Nothing
        Me.txtDocumentName.DataBoundControl = true
        Me.txtDocumentName.EditingMode = false
        Me.txtDocumentName.EndFindValue = Nothing
        Me.txtDocumentName.FieldDescription = Nothing
        Me.txtDocumentName.FieldName = Nothing
        Me.txtDocumentName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDocumentName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDocumentName, true)
        resources.ApplyResources(Me.txtDocumentName, "txtDocumentName")
        Me.txtDocumentName.ForeColor = System.Drawing.Color.Black
        Me.txtDocumentName.LinkedLabel = Me.lblDocumentCode
        Me.txtDocumentName.MaximumValue = Nothing
        Me.txtDocumentName.MinimumValue = Nothing
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.OldValue = Nothing
        Me.txtDocumentName.ReadOnly = true
        Me.txtDocumentName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDocumentName.Translatable = false
        Me.txtDocumentName.ValueIsMandatory = true
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
        Me.lblDocumentName.DisplayOnly = true
        Me.lblDocumentName.EditingMode = false
        resources.ApplyResources(Me.lblDocumentName, "lblDocumentName")
        Me.lblDocumentName.Name = "lblDocumentName"
        Me.lblDocumentName.Translatable = true
        '
        'lblDocumentNameAra
        '
        Me.lblDocumentNameAra.DisplayOnly = true
        Me.lblDocumentNameAra.EditingMode = false
        resources.ApplyResources(Me.lblDocumentNameAra, "lblDocumentNameAra")
        Me.lblDocumentNameAra.Name = "lblDocumentNameAra"
        Me.lblDocumentNameAra.Translatable = true
        '
        'txtDocumentNameAra
        '
        Me.txtDocumentNameAra.BackColor = System.Drawing.Color.White
        Me.txtDocumentNameAra.BegFindValue = Nothing
        Me.txtDocumentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentNameAra.ComputedValue = false
        Me.txtDocumentNameAra.CustomFormat = Nothing
        Me.txtDocumentNameAra.DataBoundControl = true
        Me.txtDocumentNameAra.EditingMode = false
        Me.txtDocumentNameAra.EndFindValue = Nothing
        Me.txtDocumentNameAra.EnglishControl = Me.txtDocumentName
        Me.txtDocumentNameAra.FieldDescription = Nothing
        Me.txtDocumentNameAra.FieldName = Nothing
        Me.txtDocumentNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDocumentNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDocumentNameAra, true)
        resources.ApplyResources(Me.txtDocumentNameAra, "txtDocumentNameAra")
        Me.txtDocumentNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDocumentNameAra.LinkedLabel = Me.lblDocumentNameAra
        Me.txtDocumentNameAra.MaximumValue = Nothing
        Me.txtDocumentNameAra.MinimumValue = Nothing
        Me.txtDocumentNameAra.Name = "txtDocumentNameAra"
        Me.txtDocumentNameAra.OldValue = Nothing
        Me.txtDocumentNameAra.ReadOnly = true
        Me.txtDocumentNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDocumentNameAra.Translatable = false
        '
        'lblDocumentType
        '
        Me.lblDocumentType.DisplayOnly = true
        Me.lblDocumentType.EditingMode = false
        resources.ApplyResources(Me.lblDocumentType, "lblDocumentType")
        Me.lblDocumentType.Name = "lblDocumentType"
        Me.lblDocumentType.Translatable = true
        '
        'cboDocumentType
        '
        Me.cboDocumentType.BackColor = System.Drawing.Color.White
        Me.cboDocumentType.BegFindValue = Nothing
        Me.cboDocumentType.ChangingSearchValueOnly = false
        Me.cboDocumentType.CurrentSearchTerm = ""
        Me.cboDocumentType.DataValue = Nothing
        Me.cboDocumentType.DefaultValue = Nothing
        Me.cboDocumentType.DisplayMember = "Name"
        Me.cboDocumentType.EditingMode = true
        Me.cboDocumentType.EndFindValue = Nothing
        Me.cboDocumentType.FieldDescription = Nothing
        Me.cboDocumentType.FieldName = Nothing
        Me.cboDocumentType.FilterRule = Nothing
        Me.cboDocumentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDocumentType.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboDocumentType, true)
        resources.ApplyResources(Me.cboDocumentType, "cboDocumentType")
        Me.cboDocumentType.ForeColor = System.Drawing.Color.Black
        Me.cboDocumentType.FormattingEnabled = true
        Me.cboDocumentType.HideWhenNotEditingOrAdding = false
        Me.cboDocumentType.IgnoreCase = false
        Me.cboDocumentType.LinkedLabel = Nothing
        Me.cboDocumentType.Name = "cboDocumentType"
        Me.cboDocumentType.OldValue = 0
        Me.cboDocumentType.OriginalDataSource = Nothing
        Me.cboDocumentType.OriginalList = Nothing
        Me.cboDocumentType.OverrideDropDownStyleList = false
        Me.cboDocumentType.PreviousSearchTerm = Nothing
        Me.cboDocumentType.PropertySelector = Nothing
        Me.cboDocumentType.ReadOnlyCombo = false
        Me.cboDocumentType.SuggestBoxHeight = 200
        Me.cboDocumentType.SuggestListOrderRule = Nothing
        Me.cboDocumentType.TextToSearch = Nothing
        Me.cboDocumentType.Translatable = false
        Me.cboDocumentType.ValueIsMandatory = false
        Me.cboDocumentType.ValueIsNullable = false
        Me.cboDocumentType.ValueIsNumeric = false
        Me.cboDocumentType.ValueMember = "IdNo"
        '
        'lblImageType
        '
        Me.lblImageType.DisplayOnly = true
        Me.lblImageType.EditingMode = false
        resources.ApplyResources(Me.lblImageType, "lblImageType")
        Me.lblImageType.Name = "lblImageType"
        Me.lblImageType.Translatable = true
        '
        'cboImageType
        '
        Me.cboImageType.BackColor = System.Drawing.Color.White
        Me.cboImageType.BegFindValue = Nothing
        Me.cboImageType.ChangingSearchValueOnly = false
        Me.cboImageType.CurrentSearchTerm = ""
        Me.cboImageType.DataValue = Nothing
        Me.cboImageType.DefaultValue = Nothing
        Me.cboImageType.DisplayMember = "Name"
        Me.cboImageType.EditingMode = true
        Me.cboImageType.EndFindValue = Nothing
        Me.cboImageType.FieldDescription = Nothing
        Me.cboImageType.FieldName = Nothing
        Me.cboImageType.FilterRule = Nothing
        Me.cboImageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboImageType.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboImageType, true)
        resources.ApplyResources(Me.cboImageType, "cboImageType")
        Me.cboImageType.ForeColor = System.Drawing.Color.Black
        Me.cboImageType.FormattingEnabled = true
        Me.cboImageType.HideWhenNotEditingOrAdding = false
        Me.cboImageType.IgnoreCase = false
        Me.cboImageType.LinkedLabel = Nothing
        Me.cboImageType.Name = "cboImageType"
        Me.cboImageType.OldValue = 0
        Me.cboImageType.OriginalDataSource = Nothing
        Me.cboImageType.OriginalList = Nothing
        Me.cboImageType.OverrideDropDownStyleList = false
        Me.cboImageType.PreviousSearchTerm = Nothing
        Me.cboImageType.PropertySelector = Nothing
        Me.cboImageType.ReadOnlyCombo = false
        Me.cboImageType.SuggestBoxHeight = 200
        Me.cboImageType.SuggestListOrderRule = Nothing
        Me.cboImageType.TextToSearch = Nothing
        Me.cboImageType.Translatable = false
        Me.cboImageType.ValueIsMandatory = false
        Me.cboImageType.ValueIsNullable = false
        Me.cboImageType.ValueIsNumeric = false
        Me.cboImageType.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Translatable = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Translatable = true
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Translatable = true
        '
        'chkNeedsNumber
        '
        resources.ApplyResources(Me.chkNeedsNumber, "chkNeedsNumber")
        Me.chkNeedsNumber.AutoCheck = false
        Me.chkNeedsNumber.BackColor = System.Drawing.Color.White
        Me.chkNeedsNumber.BegFindValue = Nothing
        Me.chkNeedsNumber.DisplayOnly = false
        Me.chkNeedsNumber.EditingMode = false
        Me.chkNeedsNumber.EndFindValue = Nothing
        Me.chkNeedsNumber.FieldDescription = Nothing
        Me.chkNeedsNumber.FieldName = Nothing
        Me.chkNeedsNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkNeedsNumber.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.chkNeedsNumber, true)
        Me.chkNeedsNumber.ForeColor = System.Drawing.Color.Black
        Me.chkNeedsNumber.IFindableControl_FindEnabled = false
        Me.chkNeedsNumber.IgnoreCase = false
        Me.chkNeedsNumber.LinkedLabel = Nothing
        Me.chkNeedsNumber.Name = "chkNeedsNumber"
        Me.chkNeedsNumber.NoLabel = false
        Me.chkNeedsNumber.OldValue = ""
        Me.chkNeedsNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkNeedsNumber.Translatable = false
        Me.chkNeedsNumber.UseVisualStyleBackColor = false
        '
        'chkNeedsIssueDate
        '
        resources.ApplyResources(Me.chkNeedsIssueDate, "chkNeedsIssueDate")
        Me.chkNeedsIssueDate.AutoCheck = false
        Me.chkNeedsIssueDate.BackColor = System.Drawing.Color.White
        Me.chkNeedsIssueDate.BegFindValue = Nothing
        Me.chkNeedsIssueDate.DisplayOnly = false
        Me.chkNeedsIssueDate.EditingMode = false
        Me.chkNeedsIssueDate.EndFindValue = Nothing
        Me.chkNeedsIssueDate.FieldDescription = Nothing
        Me.chkNeedsIssueDate.FieldName = Nothing
        Me.chkNeedsIssueDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkNeedsIssueDate.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.chkNeedsIssueDate, true)
        Me.chkNeedsIssueDate.ForeColor = System.Drawing.Color.Black
        Me.chkNeedsIssueDate.IFindableControl_FindEnabled = false
        Me.chkNeedsIssueDate.IgnoreCase = false
        Me.chkNeedsIssueDate.LinkedLabel = Nothing
        Me.chkNeedsIssueDate.Name = "chkNeedsIssueDate"
        Me.chkNeedsIssueDate.NoLabel = false
        Me.chkNeedsIssueDate.OldValue = ""
        Me.chkNeedsIssueDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkNeedsIssueDate.Translatable = false
        Me.chkNeedsIssueDate.UseVisualStyleBackColor = false
        '
        'chkNeedsExpiryDate
        '
        resources.ApplyResources(Me.chkNeedsExpiryDate, "chkNeedsExpiryDate")
        Me.chkNeedsExpiryDate.AutoCheck = false
        Me.chkNeedsExpiryDate.BackColor = System.Drawing.Color.White
        Me.chkNeedsExpiryDate.BegFindValue = Nothing
        Me.chkNeedsExpiryDate.DisplayOnly = false
        Me.chkNeedsExpiryDate.EditingMode = false
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
        Friend WithEvents cboDocumentType As CaComboBox
        Friend WithEvents lblImageType As CLabel
        Friend WithEvents cboImageType As CaComboBox
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