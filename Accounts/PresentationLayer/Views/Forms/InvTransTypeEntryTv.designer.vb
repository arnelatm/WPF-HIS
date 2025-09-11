Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvTransTypeEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvTransTypeEntryTv))
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.cboInventoryAction = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.lblInventoryAction = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtInvTransTypeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtInvTransTypeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtInvTransTypeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblInvTransTypeCycle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
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
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.cboInventoryAction, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.lblInventoryAction, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvTransTypeNameAra, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvTransTypeName, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvTransTypeCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAccountIdNo, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.lblInvTransTypeCycle, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAccountIdNo, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.chkActive, 2, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.lblActive, 2, 11)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'cboInventoryAction
            '
            Me.cboInventoryAction.BackColor = System.Drawing.Color.White
            Me.cboInventoryAction.BegFindValue = Nothing
            Me.cboInventoryAction.ChangingSearchValueOnly = False
            Me.cboInventoryAction.CurrentSearchTerm = ""
            Me.cboInventoryAction.DataValue = Nothing
            Me.cboInventoryAction.DefaultValue = Nothing
            Me.cboInventoryAction.DisplayMember = "Name"
            resources.ApplyResources(Me.cboInventoryAction, "cboInventoryAction")
            Me.cboInventoryAction.Editable = True
            Me.cboInventoryAction.EditingMode = True
            Me.cboInventoryAction.EndFindValue = Nothing
            Me.cboInventoryAction.FieldDescription = Nothing
            Me.cboInventoryAction.FieldName = Nothing
            Me.cboInventoryAction.FilterRule = Nothing
            Me.cboInventoryAction.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboInventoryAction.FindEnabled = False
            Me.cboInventoryAction.ForeColor = System.Drawing.Color.Black
            Me.cboInventoryAction.FormattingEnabled = True
            Me.cboInventoryAction.HideWhenNotEditingOrAdding = False
            Me.cboInventoryAction.IgnoreCase = False
            Me.cboInventoryAction.LimitToList = False
            Me.cboInventoryAction.LinkedLabel = Me.lblInventoryAction
            Me.cboInventoryAction.Name = "cboInventoryAction"
            Me.cboInventoryAction.OldValue = 0
            Me.cboInventoryAction.OriginalDataSource = Nothing
            Me.cboInventoryAction.OriginalList = Nothing
            Me.cboInventoryAction.OverrideDropDownStyleList = False
            Me.cboInventoryAction.PreviousSearchTerm = Nothing
            Me.cboInventoryAction.PropertySelector = Nothing
            Me.cboInventoryAction.SuggestListOrderRule = Nothing
            Me.cboInventoryAction.TextToSearch = Nothing
            Me.cboInventoryAction.Translatable = False
            Me.cboInventoryAction.ValueIsMandatory = False
            Me.cboInventoryAction.ValueIsNullable = False
            Me.cboInventoryAction.ValueIsNumeric = False
            Me.cboInventoryAction.ValueMember = "Code"
            '
            'lblInventoryAction
            '
            resources.ApplyResources(Me.lblInventoryAction, "lblInventoryAction")
            Me.lblInventoryAction.BackColor = System.Drawing.Color.Transparent
            Me.lblInventoryAction.DisplayOnly = True
            Me.lblInventoryAction.EditingMode = False
            Me.lblInventoryAction.Name = "lblInventoryAction"
            Me.lblInventoryAction.Translatable = True
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 3)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
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
            'txtInvTransTypeNameAra
            '
            Me.txtInvTransTypeNameAra.BackColor = System.Drawing.Color.White
            Me.txtInvTransTypeNameAra.BegFindValue = Nothing
            Me.txtInvTransTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtInvTransTypeNameAra, 3)
            Me.txtInvTransTypeNameAra.ComputedValue = False
            Me.txtInvTransTypeNameAra.CustomFormat = Nothing
            Me.txtInvTransTypeNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtInvTransTypeNameAra, "txtInvTransTypeNameAra")
            Me.txtInvTransTypeNameAra.EditingMode = False
            Me.txtInvTransTypeNameAra.EndFindValue = Nothing
            Me.txtInvTransTypeNameAra.EnglishControl = Me.txtInvTransTypeName
            Me.txtInvTransTypeNameAra.FieldDescription = Nothing
            Me.txtInvTransTypeNameAra.FieldName = Nothing
            Me.txtInvTransTypeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvTransTypeNameAra.FindEnabled = True
            Me.txtInvTransTypeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtInvTransTypeNameAra.LinkedLabel = Me.lblNameAra
            Me.txtInvTransTypeNameAra.MaximumValue = Nothing
            Me.txtInvTransTypeNameAra.MinimumValue = Nothing
            Me.txtInvTransTypeNameAra.Name = "txtInvTransTypeNameAra"
            Me.txtInvTransTypeNameAra.OldValue = Nothing
            Me.txtInvTransTypeNameAra.OverrideMaxLength = 0
            Me.txtInvTransTypeNameAra.ReadOnly = True
            Me.txtInvTransTypeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvTransTypeNameAra.Translatable = False
            '
            'txtInvTransTypeName
            '
            Me.txtInvTransTypeName.BackColor = System.Drawing.Color.White
            Me.txtInvTransTypeName.BegFindValue = Nothing
            Me.txtInvTransTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtInvTransTypeName, 3)
            Me.txtInvTransTypeName.ComputedValue = False
            Me.txtInvTransTypeName.CustomFormat = Nothing
            Me.txtInvTransTypeName.DataBoundControl = True
            resources.ApplyResources(Me.txtInvTransTypeName, "txtInvTransTypeName")
            Me.txtInvTransTypeName.EditingMode = False
            Me.txtInvTransTypeName.EndFindValue = Nothing
            Me.txtInvTransTypeName.FieldDescription = Nothing
            Me.txtInvTransTypeName.FieldName = Nothing
            Me.txtInvTransTypeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvTransTypeName.FindEnabled = True
            Me.txtInvTransTypeName.ForeColor = System.Drawing.Color.Black
            Me.txtInvTransTypeName.LinkedLabel = Me.lblName
            Me.txtInvTransTypeName.MaximumValue = Nothing
            Me.txtInvTransTypeName.MinimumValue = Nothing
            Me.txtInvTransTypeName.Name = "txtInvTransTypeName"
            Me.txtInvTransTypeName.OldValue = Nothing
            Me.txtInvTransTypeName.OverrideMaxLength = 0
            Me.txtInvTransTypeName.ReadOnly = True
            Me.txtInvTransTypeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvTransTypeName.Translatable = False
            Me.txtInvTransTypeName.ValueIsMandatory = True
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'lblNameAra
            '
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'txtInvTransTypeCode
            '
            Me.txtInvTransTypeCode.BackColor = System.Drawing.Color.White
            Me.txtInvTransTypeCode.BegFindValue = Nothing
            Me.txtInvTransTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInvTransTypeCode.ComputedValue = False
            Me.txtInvTransTypeCode.CustomFormat = Nothing
            Me.txtInvTransTypeCode.DataBoundControl = True
            Me.txtInvTransTypeCode.EditingMode = True
            Me.txtInvTransTypeCode.EndFindValue = Nothing
            Me.txtInvTransTypeCode.FieldDescription = Nothing
            Me.txtInvTransTypeCode.FieldName = Nothing
            Me.txtInvTransTypeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvTransTypeCode.FindEnabled = True
            resources.ApplyResources(Me.txtInvTransTypeCode, "txtInvTransTypeCode")
            Me.txtInvTransTypeCode.ForeColor = System.Drawing.Color.Black
            Me.txtInvTransTypeCode.LinkedLabel = Me.lblCode
            Me.txtInvTransTypeCode.MaximumValue = Nothing
            Me.txtInvTransTypeCode.MinimumValue = Nothing
            Me.txtInvTransTypeCode.Name = "txtInvTransTypeCode"
            Me.txtInvTransTypeCode.OldValue = Nothing
            Me.txtInvTransTypeCode.OverrideMaxLength = 0
            Me.txtInvTransTypeCode.ReadOnly = True
            Me.txtInvTransTypeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvTransTypeCode.Translatable = False
            Me.txtInvTransTypeCode.ValueIsMandatory = True
            '
            'lblCode
            '
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.BackColor = System.Drawing.Color.Transparent
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
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
            Me.TxtIdNo.LinkedLabel = Nothing
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
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 3)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DataValue = Nothing
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.Editable = True
            Me.cboAccountIdNo.EditingMode = True
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LimitToList = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestCharCount = 0
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblInvTransTypeCycle
            '
            Me.lblInvTransTypeCycle.BackColor = System.Drawing.Color.Transparent
            Me.lblInvTransTypeCycle.DisplayOnly = True
            Me.lblInvTransTypeCycle.EditingMode = False
            resources.ApplyResources(Me.lblInvTransTypeCycle, "lblInvTransTypeCycle")
            Me.lblInvTransTypeCycle.Name = "lblInvTransTypeCycle"
            Me.lblInvTransTypeCycle.Translatable = True
            '
            'lblAccountIdNo
            '
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Translatable = True
            '
            'chkActive
            '
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            Me.chkActive.FlatAppearance.BorderSize = 0
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
            'lblActive
            '
            resources.ApplyResources(Me.lblActive, "lblActive")
            Me.lblActive.BackColor = System.Drawing.Color.Transparent
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Translatable = True
            '
            'InvTransTypeEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "InvTransTypeEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents txtInvTransTypeName As CTextBox
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtInvTransTypeCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblInvTransTypeCycle As CLabel
        Friend WithEvents cboAccountIdNo As CtComboBox
        Friend WithEvents cboInventoryAction As CtCombobox
        Friend WithEvents lblInventoryAction As CLabel
        Friend WithEvents txtInvTransTypeNameAra As CTextBoxArabic
    End Class
End Namespace