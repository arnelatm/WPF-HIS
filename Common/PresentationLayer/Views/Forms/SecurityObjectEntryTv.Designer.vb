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
        Me.cboSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblManuallyGenerated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkManuallyAdded = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
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
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtSecurityObjectName
        '
        Me.txtSecurityObjectName.BackColor = System.Drawing.Color.White
        Me.txtSecurityObjectName.BegFindValue = Nothing
        Me.txtSecurityObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityObjectName.ComputedValue = false
        Me.txtSecurityObjectName.CustomFormat = Nothing
        Me.txtSecurityObjectName.DataBoundControl = true
        Me.txtSecurityObjectName.EditingMode = false
        Me.txtSecurityObjectName.EndFindValue = Nothing
        Me.txtSecurityObjectName.FieldName = Nothing
        Me.txtSecurityObjectName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSecurityObjectName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectName, true)
        resources.ApplyResources(Me.txtSecurityObjectName, "txtSecurityObjectName")
        Me.txtSecurityObjectName.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityObjectName.LinkedLabel = Nothing
        Me.txtSecurityObjectName.MaximumValue = Nothing
        Me.txtSecurityObjectName.MinimumValue = Nothing
        Me.txtSecurityObjectName.Name = "txtSecurityObjectName"
        Me.txtSecurityObjectName.OldValue = Nothing
        Me.txtSecurityObjectName.ReadOnly = true
        Me.txtSecurityObjectName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSecurityObjectName.ValueIsMandatory = true
        '
        'txtSecurityObjectNameAra
        '
        Me.txtSecurityObjectNameAra.BackColor = System.Drawing.Color.White
        Me.txtSecurityObjectNameAra.BegFindValue = Nothing
        Me.txtSecurityObjectNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityObjectNameAra.ComputedValue = false
        Me.txtSecurityObjectNameAra.CustomFormat = Nothing
        Me.txtSecurityObjectNameAra.DataBoundControl = true
        Me.txtSecurityObjectNameAra.EditingMode = false
        Me.txtSecurityObjectNameAra.EndFindValue = Nothing
        Me.txtSecurityObjectNameAra.EnglishControl = Me.txtSecurityObjectName
        Me.txtSecurityObjectNameAra.FieldName = Nothing
        Me.txtSecurityObjectNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSecurityObjectNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectNameAra, true)
        resources.ApplyResources(Me.txtSecurityObjectNameAra, "txtSecurityObjectNameAra")
        Me.txtSecurityObjectNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityObjectNameAra.LinkedLabel = Nothing
        Me.txtSecurityObjectNameAra.MaximumValue = Nothing
        Me.txtSecurityObjectNameAra.MinimumValue = Nothing
        Me.txtSecurityObjectNameAra.Name = "txtSecurityObjectNameAra"
        Me.txtSecurityObjectNameAra.OldValue = Nothing
        Me.txtSecurityObjectNameAra.ReadOnly = true
        Me.txtSecurityObjectNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.ValueIsMandatory = true
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'txtSecurityObjectCode
        '
        Me.txtSecurityObjectCode.BackColor = System.Drawing.Color.White
        Me.txtSecurityObjectCode.BegFindValue = Nothing
        Me.txtSecurityObjectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityObjectCode.ComputedValue = false
        Me.txtSecurityObjectCode.CustomFormat = Nothing
        Me.txtSecurityObjectCode.DataBoundControl = true
        Me.txtSecurityObjectCode.EditingMode = false
        Me.txtSecurityObjectCode.EndFindValue = Nothing
        Me.txtSecurityObjectCode.FieldName = Nothing
        Me.txtSecurityObjectCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSecurityObjectCode.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectCode, true)
        resources.ApplyResources(Me.txtSecurityObjectCode, "txtSecurityObjectCode")
        Me.txtSecurityObjectCode.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityObjectCode.LinkedLabel = Nothing
        Me.txtSecurityObjectCode.MaximumValue = Nothing
        Me.txtSecurityObjectCode.MinimumValue = Nothing
        Me.txtSecurityObjectCode.Name = "txtSecurityObjectCode"
        Me.txtSecurityObjectCode.OldValue = Nothing
        Me.txtSecurityObjectCode.ReadOnly = true
        Me.txtSecurityObjectCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSecurityObjectCode.ValueIsMandatory = true
        '
        'lblSystemViewIdNo
        '
        Me.lblSystemViewIdNo.DisplayOnly = true
        Me.lblSystemViewIdNo.EditingMode = false
        resources.ApplyResources(Me.lblSystemViewIdNo, "lblSystemViewIdNo")
        Me.lblSystemViewIdNo.Name = "lblSystemViewIdNo"
        '
        'cboSystemViewIdNo
        '
        Me.cboSystemViewIdNo.BackColor = System.Drawing.Color.White
        Me.cboSystemViewIdNo.BegFindValue = Nothing
        Me.cboSystemViewIdNo.ChangingSearchValueOnly = false
        Me.cboSystemViewIdNo.CurrentSearchTerm = ""
        Me.cboSystemViewIdNo.DefaultValue = Nothing
        Me.cboSystemViewIdNo.DisplayMember = "Name"
        Me.cboSystemViewIdNo.EditingMode = true
        Me.cboSystemViewIdNo.EndFindValue = Nothing
        Me.cboSystemViewIdNo.FieldName = Nothing
        Me.cboSystemViewIdNo.FilterRule = Nothing
        Me.cboSystemViewIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboSystemViewIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboSystemViewIdNo, true)
        resources.ApplyResources(Me.cboSystemViewIdNo, "cboSystemViewIdNo")
        Me.cboSystemViewIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSystemViewIdNo.FormattingEnabled = true
        Me.cboSystemViewIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSystemViewIdNo.LinkedLabel = Me.lblSystemViewIdNo
        Me.cboSystemViewIdNo.Name = "cboSystemViewIdNo"
        Me.cboSystemViewIdNo.OldValue = 0
        Me.cboSystemViewIdNo.OriginalDataSource = Nothing
        Me.cboSystemViewIdNo.OriginalList = Nothing
        Me.cboSystemViewIdNo.OverrideDropDownStyleList = false
        Me.cboSystemViewIdNo.PreviousSearchTerm = Nothing
        Me.cboSystemViewIdNo.PropertySelector = Nothing
        Me.cboSystemViewIdNo.ReadOnlyCombo = false
        Me.cboSystemViewIdNo.SuggestBoxHeight = 200
        Me.cboSystemViewIdNo.SuggestListOrderRule = Nothing
        Me.cboSystemViewIdNo.TextToSearch = Nothing
        Me.cboSystemViewIdNo.ValueIsMandatory = false
        Me.cboSystemViewIdNo.ValueIsNullable = false
        Me.cboSystemViewIdNo.ValueIsNumeric = false
        Me.cboSystemViewIdNo.ValueMember = "IdNo"
        '
        'lblSecurityObjectName
        '
        Me.lblSecurityObjectName.DisplayOnly = true
        Me.lblSecurityObjectName.EditingMode = false
        resources.ApplyResources(Me.lblSecurityObjectName, "lblSecurityObjectName")
        Me.lblSecurityObjectName.Name = "lblSecurityObjectName"
        '
        'lblSecurityObjectNameAra
        '
        Me.lblSecurityObjectNameAra.DisplayOnly = true
        Me.lblSecurityObjectNameAra.EditingMode = false
        resources.ApplyResources(Me.lblSecurityObjectNameAra, "lblSecurityObjectNameAra")
        Me.lblSecurityObjectNameAra.Name = "lblSecurityObjectNameAra"
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
        Me.lblParentIdNo.Name = "lblParentIdNo"
        '
        'cacParentIdNo
        '
        Me.cacParentIdNo.BackColor = System.Drawing.Color.White
        Me.cacParentIdNo.BegFindValue = Nothing
        Me.cacParentIdNo.ChangingSearchValueOnly = false
        Me.cacParentIdNo.CurrentSearchTerm = ""
        Me.cacParentIdNo.DefaultValue = Nothing
        Me.cacParentIdNo.DisplayMember = "Name"
        Me.cacParentIdNo.EditingMode = false
        Me.cacParentIdNo.EndFindValue = Nothing
        Me.cacParentIdNo.FieldName = Nothing
        Me.cacParentIdNo.FilterRule = Nothing
        Me.cacParentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacParentIdNo.FindEnabled = false
        resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = true
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Name = "cacParentIdNo"
        Me.cacParentIdNo.OldValue = 0
        Me.cacParentIdNo.OriginalDataSource = Nothing
        Me.cacParentIdNo.OriginalList = Nothing
        Me.cacParentIdNo.OverrideDropDownStyleList = false
        Me.cacParentIdNo.PreviousSearchTerm = Nothing
        Me.cacParentIdNo.PropertySelector = Nothing
        Me.cacParentIdNo.ReadOnlyCombo = false
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TextToSearch = Nothing
        Me.cacParentIdNo.ValueIsMandatory = false
        Me.cacParentIdNo.ValueIsNullable = false
        Me.cacParentIdNo.ValueIsNumeric = false
        Me.cacParentIdNo.ValueMember = "IdNo"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'lblManuallyGenerated
        '
        Me.lblManuallyGenerated.DisplayOnly = true
        Me.lblManuallyGenerated.EditingMode = false
        resources.ApplyResources(Me.lblManuallyGenerated, "lblManuallyGenerated")
        Me.lblManuallyGenerated.Name = "lblManuallyGenerated"
        '
        'chkManuallyAdded
        '
        Me.chkManuallyAdded.BackColor = System.Drawing.Color.White
        Me.chkManuallyAdded.BegFindValue = Nothing
        Me.chkManuallyAdded.DisplayOnly = true
        Me.chkManuallyAdded.EditingMode = true
        Me.chkManuallyAdded.EndFindValue = Nothing
        Me.chkManuallyAdded.FieldName = Nothing
        Me.chkManuallyAdded.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkManuallyAdded.FindEnabled = false
        Me.chkManuallyAdded.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.chkManuallyAdded, "chkManuallyAdded")
        Me.chkManuallyAdded.ForeColor = System.Drawing.Color.Black
        Me.chkManuallyAdded.IFindableControl_FindEnabled = false
        Me.chkManuallyAdded.LinkedLabel = Nothing
        Me.chkManuallyAdded.Name = "chkManuallyAdded"
        Me.chkManuallyAdded.NoLabel = true
        Me.chkManuallyAdded.OldValue = Nothing
        Me.chkManuallyAdded.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkManuallyAdded.UseVisualStyleBackColor = false
        '
        'SecurityObjectEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "SecurityObjectEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtSecurityObjectCode As CTextBox
        Friend WithEvents lblSystemViewIdNo As CLabel
        Friend WithEvents cboSystemViewIdNo As CaComboBox
        Friend WithEvents lblManuallyGenerated As CLabel
        Friend WithEvents chkManuallyAdded As CCheckBox
    End Class
End NameSpace