Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SecurityObjectEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityObjectEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSecurityObjectCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblManuallyGenerated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkManuallyAdded = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtSecurityObjectName
            '
            Me.txtSecurityObjectName.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectName.BegFindValue = Nothing
            Me.txtSecurityObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectName.ComputedValue = False
            Me.txtSecurityObjectName.CustomFormat = Nothing
            Me.txtSecurityObjectName.DataBoundControl = True
            Me.txtSecurityObjectName.EditingMode = False
            Me.txtSecurityObjectName.EndFindValue = Nothing
            Me.txtSecurityObjectName.FieldDescription = Nothing
            Me.txtSecurityObjectName.FieldName = Nothing
            Me.txtSecurityObjectName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityObjectName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectName, True)
            resources.ApplyResources(Me.txtSecurityObjectName, "txtSecurityObjectName")
            Me.txtSecurityObjectName.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectName.LinkedLabel = Nothing
            Me.txtSecurityObjectName.MaximumValue = Nothing
            Me.txtSecurityObjectName.MinimumValue = Nothing
            Me.txtSecurityObjectName.Name = "txtSecurityObjectName"
            Me.txtSecurityObjectName.OldValue = Nothing
            Me.txtSecurityObjectName.ReadOnly = True
            Me.txtSecurityObjectName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityObjectName.Translatable = False
            Me.txtSecurityObjectName.ValueIsMandatory = True
            Me.txtSecurityObjectName.ValueIsUnique = True
            '
            'txtSecurityObjectNameAra
            '
            Me.txtSecurityObjectNameAra.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectNameAra.BegFindValue = Nothing
            Me.txtSecurityObjectNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectNameAra.ComputedValue = False
            Me.txtSecurityObjectNameAra.CustomFormat = Nothing
            Me.txtSecurityObjectNameAra.DataBoundControl = True
            Me.txtSecurityObjectNameAra.EditingMode = False
            Me.txtSecurityObjectNameAra.EndFindValue = Nothing
            Me.txtSecurityObjectNameAra.EnglishControl = Me.txtSecurityObjectName
            Me.txtSecurityObjectNameAra.FieldDescription = Nothing
            Me.txtSecurityObjectNameAra.FieldName = Nothing
            Me.txtSecurityObjectNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityObjectNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectNameAra, True)
            resources.ApplyResources(Me.txtSecurityObjectNameAra, "txtSecurityObjectNameAra")
            Me.txtSecurityObjectNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectNameAra.LinkedLabel = Nothing
            Me.txtSecurityObjectNameAra.MaximumValue = Nothing
            Me.txtSecurityObjectNameAra.MinimumValue = Nothing
            Me.txtSecurityObjectNameAra.Name = "txtSecurityObjectNameAra"
            Me.txtSecurityObjectNameAra.OldValue = Nothing
            Me.txtSecurityObjectNameAra.ReadOnly = True
            Me.txtSecurityObjectNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityObjectNameAra.Translatable = False
            Me.txtSecurityObjectNameAra.ValueIsUnique = True
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
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectCode)
            Me.floDataDisplay.Controls.Add(Me.lblSystemViewIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboSystemViewIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectName)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectName)
            Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.lblManuallyGenerated)
            Me.floDataDisplay.Controls.Add(Me.chkManuallyAdded)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'txtSecurityObjectCode
            '
            Me.txtSecurityObjectCode.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectCode.BegFindValue = Nothing
            Me.txtSecurityObjectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectCode.ComputedValue = False
            Me.txtSecurityObjectCode.CustomFormat = Nothing
            Me.txtSecurityObjectCode.DataBoundControl = True
            Me.txtSecurityObjectCode.EditingMode = False
            Me.txtSecurityObjectCode.EndFindValue = Nothing
            Me.txtSecurityObjectCode.FieldDescription = Nothing
            Me.txtSecurityObjectCode.FieldName = Nothing
            Me.txtSecurityObjectCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityObjectCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectCode, True)
            resources.ApplyResources(Me.txtSecurityObjectCode, "txtSecurityObjectCode")
            Me.txtSecurityObjectCode.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectCode.LinkedLabel = Nothing
            Me.txtSecurityObjectCode.MaximumValue = Nothing
            Me.txtSecurityObjectCode.MinimumValue = Nothing
            Me.txtSecurityObjectCode.Name = "txtSecurityObjectCode"
            Me.txtSecurityObjectCode.OldValue = Nothing
            Me.txtSecurityObjectCode.ReadOnly = True
            Me.txtSecurityObjectCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityObjectCode.Translatable = False
            Me.txtSecurityObjectCode.ValueIsMandatory = True
            Me.txtSecurityObjectCode.ValueIsUnique = True
            '
            'lblSystemViewIdNo
            '
            Me.lblSystemViewIdNo.DisplayOnly = True
            Me.lblSystemViewIdNo.EditingMode = False
            resources.ApplyResources(Me.lblSystemViewIdNo, "lblSystemViewIdNo")
            Me.lblSystemViewIdNo.Name = "lblSystemViewIdNo"
            Me.lblSystemViewIdNo.Translatable = True
            '
            'cboSystemViewIdNo
            '
            Me.cboSystemViewIdNo.BackColor = System.Drawing.Color.White
            Me.cboSystemViewIdNo.BegFindValue = Nothing
            Me.cboSystemViewIdNo.ChangingSearchValueOnly = False
            Me.cboSystemViewIdNo.CurrentSearchTerm = ""
            Me.cboSystemViewIdNo.DefaultValue = Nothing
            Me.cboSystemViewIdNo.DisplayMember = "Name"
            Me.cboSystemViewIdNo.EditingMode = True
            Me.cboSystemViewIdNo.EndFindValue = Nothing
            Me.cboSystemViewIdNo.FieldDescription = Nothing
            Me.cboSystemViewIdNo.FieldName = Nothing
            Me.cboSystemViewIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSystemViewIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboSystemViewIdNo, True)
            resources.ApplyResources(Me.cboSystemViewIdNo, "cboSystemViewIdNo")
            Me.cboSystemViewIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSystemViewIdNo.FormattingEnabled = True
            Me.cboSystemViewIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSystemViewIdNo.IgnoreCase = False
            Me.cboSystemViewIdNo.LinkedLabel = Me.lblSystemViewIdNo
            Me.cboSystemViewIdNo.Name = "cboSystemViewIdNo"
            Me.cboSystemViewIdNo.OldValue = 0
            Me.cboSystemViewIdNo.OriginalDataSource = Nothing
            Me.cboSystemViewIdNo.OriginalList = Nothing
            Me.cboSystemViewIdNo.OverrideDropDownStyleList = False
            Me.cboSystemViewIdNo.PreviousSearchTerm = Nothing
            Me.cboSystemViewIdNo.SuggestBoxHeight = 200
            Me.cboSystemViewIdNo.TextToSearch = Nothing
            Me.cboSystemViewIdNo.Translatable = False
            Me.cboSystemViewIdNo.ValueIsMandatory = False
            Me.cboSystemViewIdNo.ValueIsNullable = False
            Me.cboSystemViewIdNo.ValueIsNumeric = False
            Me.cboSystemViewIdNo.ValueMember = "IdNo"
            '
            'lblSecurityObjectName
            '
            Me.lblSecurityObjectName.DisplayOnly = True
            Me.lblSecurityObjectName.EditingMode = False
            resources.ApplyResources(Me.lblSecurityObjectName, "lblSecurityObjectName")
            Me.lblSecurityObjectName.Name = "lblSecurityObjectName"
            Me.lblSecurityObjectName.Translatable = True
            '
            'lblSecurityObjectNameAra
            '
            Me.lblSecurityObjectNameAra.DisplayOnly = True
            Me.lblSecurityObjectNameAra.EditingMode = False
            resources.ApplyResources(Me.lblSecurityObjectNameAra, "lblSecurityObjectNameAra")
            Me.lblSecurityObjectNameAra.Name = "lblSecurityObjectNameAra"
            Me.lblSecurityObjectNameAra.Translatable = True
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Translatable = True
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.BegFindValue = Nothing
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.EndFindValue = Nothing
            Me.cacParentIdNo.FieldDescription = Nothing
            Me.cacParentIdNo.FieldName = Nothing
            Me.cacParentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacParentIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, True)
            resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.IgnoreCase = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.Translatable = False
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'lblManuallyGenerated
            '
            Me.lblManuallyGenerated.DisplayOnly = True
            Me.lblManuallyGenerated.EditingMode = False
            resources.ApplyResources(Me.lblManuallyGenerated, "lblManuallyGenerated")
            Me.lblManuallyGenerated.Name = "lblManuallyGenerated"
            Me.lblManuallyGenerated.Translatable = True
            '
            'chkManuallyAdded
            '
            Me.chkManuallyAdded.BackColor = System.Drawing.Color.Transparent
            Me.chkManuallyAdded.BegFindValue = Nothing
            Me.chkManuallyAdded.DisplayOnly = False
            Me.chkManuallyAdded.EditingMode = True
            Me.chkManuallyAdded.EndFindValue = Nothing
            Me.chkManuallyAdded.FieldDescription = Nothing
            Me.chkManuallyAdded.FieldName = Nothing
            Me.chkManuallyAdded.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkManuallyAdded.FindEnabled = False
            resources.ApplyResources(Me.chkManuallyAdded, "chkManuallyAdded")
            Me.chkManuallyAdded.IFindableControl_FindEnabled = False
            Me.chkManuallyAdded.IgnoreCase = False
            Me.chkManuallyAdded.LinkedLabel = Nothing
            Me.chkManuallyAdded.Name = "chkManuallyAdded"
            Me.chkManuallyAdded.NoLabel = True
            Me.chkManuallyAdded.OldValue = Nothing
            Me.chkManuallyAdded.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkManuallyAdded.Translatable = False
            Me.chkManuallyAdded.UseVisualStyleBackColor = False
            '
            'SecurityObjectEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "SecurityObjectEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtSecurityObjectName As CTextBox
        Friend WithEvents txtSecurityObjectNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblSecurityObjectName As CLabel
        Friend WithEvents lblSecurityObjectNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents cacParentIdNo As CdtComboBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtSecurityObjectCode As CTextBox
        Friend WithEvents lblSystemViewIdNo As CLabel
        Friend WithEvents cboSystemViewIdNo As CdtComboBox
        Friend WithEvents lblManuallyGenerated As CLabel
        Friend WithEvents chkManuallyAdded As CCheckBox
    End Class
End NameSpace