Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ItemCodeEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemCodeEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtItemCodeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblItemCodeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtItemCodeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblItemCodeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtItemCodeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblItemCodeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboCodeGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNote = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnLockGroup = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
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
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
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
        'txtItemCodeCode
        '
        Me.txtItemCodeCode.BackColor = System.Drawing.Color.White
        Me.txtItemCodeCode.BegFindValue = Nothing
        Me.txtItemCodeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCodeCode.ComputedValue = false
        Me.txtItemCodeCode.CustomFormat = Nothing
        Me.txtItemCodeCode.DataBoundControl = true
        Me.txtItemCodeCode.EditingMode = true
        Me.txtItemCodeCode.EndFindValue = Nothing
        Me.txtItemCodeCode.FieldDescription = Nothing
        Me.txtItemCodeCode.FieldName = Nothing
        Me.txtItemCodeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtItemCodeCode.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtItemCodeCode, true)
        resources.ApplyResources(Me.txtItemCodeCode, "txtItemCodeCode")
        Me.txtItemCodeCode.ForeColor = System.Drawing.Color.Black
        Me.txtItemCodeCode.LinkedLabel = Me.lblItemCodeCode
        Me.txtItemCodeCode.MaximumValue = Nothing
        Me.txtItemCodeCode.MinimumValue = Nothing
        Me.txtItemCodeCode.Name = "txtItemCodeCode"
        Me.txtItemCodeCode.OldValue = Nothing
        Me.txtItemCodeCode.ReadOnly = true
        Me.txtItemCodeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtItemCodeCode.Translatable = false
        Me.txtItemCodeCode.ValueIsMandatory = true
        '
        'lblItemCodeCode
        '
        Me.lblItemCodeCode.DisplayOnly = true
        Me.lblItemCodeCode.EditingMode = false
        resources.ApplyResources(Me.lblItemCodeCode, "lblItemCodeCode")
        Me.lblItemCodeCode.Name = "lblItemCodeCode"
        Me.lblItemCodeCode.Translatable = true
        '
        'txtItemCodeName
        '
        Me.txtItemCodeName.BackColor = System.Drawing.Color.White
        Me.txtItemCodeName.BegFindValue = Nothing
        Me.txtItemCodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCodeName.ComputedValue = false
        Me.txtItemCodeName.CustomFormat = Nothing
        Me.txtItemCodeName.DataBoundControl = true
        Me.txtItemCodeName.EditingMode = false
        Me.txtItemCodeName.EndFindValue = Nothing
        Me.txtItemCodeName.FieldDescription = Nothing
        Me.txtItemCodeName.FieldName = Nothing
        Me.txtItemCodeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtItemCodeName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtItemCodeName, true)
        resources.ApplyResources(Me.txtItemCodeName, "txtItemCodeName")
        Me.txtItemCodeName.ForeColor = System.Drawing.Color.Black
        Me.txtItemCodeName.LinkedLabel = Me.lblItemCodeName
        Me.txtItemCodeName.MaximumValue = Nothing
        Me.txtItemCodeName.MinimumValue = Nothing
        Me.txtItemCodeName.Name = "txtItemCodeName"
        Me.txtItemCodeName.OldValue = Nothing
        Me.txtItemCodeName.ReadOnly = true
        Me.txtItemCodeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtItemCodeName.Translatable = false
        Me.txtItemCodeName.ValueIsMandatory = true
        Me.txtItemCodeName.ValueIsUnique = true
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.DisplayOnly = true
        Me.lblItemCodeName.EditingMode = false
        resources.ApplyResources(Me.lblItemCodeName, "lblItemCodeName")
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Translatable = true
        '
        'txtItemCodeNameAra
        '
        Me.txtItemCodeNameAra.BackColor = System.Drawing.Color.White
        Me.txtItemCodeNameAra.BegFindValue = Nothing
        Me.txtItemCodeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCodeNameAra.ComputedValue = false
        Me.txtItemCodeNameAra.CustomFormat = Nothing
        Me.txtItemCodeNameAra.DataBoundControl = true
        Me.txtItemCodeNameAra.EditingMode = false
        Me.txtItemCodeNameAra.EndFindValue = Nothing
        Me.txtItemCodeNameAra.EnglishControl = Me.txtItemCodeName
        Me.txtItemCodeNameAra.FieldDescription = Nothing
        Me.txtItemCodeNameAra.FieldName = Nothing
        Me.txtItemCodeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtItemCodeNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtItemCodeNameAra, true)
        resources.ApplyResources(Me.txtItemCodeNameAra, "txtItemCodeNameAra")
        Me.txtItemCodeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtItemCodeNameAra.LinkedLabel = Me.lblItemCodeNameAra
        Me.txtItemCodeNameAra.MaximumValue = Nothing
        Me.txtItemCodeNameAra.MinimumValue = Nothing
        Me.txtItemCodeNameAra.Name = "txtItemCodeNameAra"
        Me.txtItemCodeNameAra.OldValue = Nothing
        Me.txtItemCodeNameAra.ReadOnly = true
        Me.txtItemCodeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtItemCodeNameAra.Translatable = false
        Me.txtItemCodeNameAra.ValueIsUnique = true
        '
        'lblItemCodeNameAra
        '
        Me.lblItemCodeNameAra.DisplayOnly = true
        Me.lblItemCodeNameAra.EditingMode = false
        resources.ApplyResources(Me.lblItemCodeNameAra, "lblItemCodeNameAra")
        Me.lblItemCodeNameAra.Name = "lblItemCodeNameAra"
        Me.lblItemCodeNameAra.Translatable = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.floDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.CLabel1)
        Me.floDataDisplay.Controls.Add(Me.cboCodeGroupIdNo)
        Me.floDataDisplay.Controls.Add(Me.btnLockGroup)
        Me.floDataDisplay.Controls.Add(Me.lblItemCodeCode)
        Me.floDataDisplay.Controls.Add(Me.txtItemCodeCode)
        Me.floDataDisplay.Controls.Add(Me.lblItemCodeName)
        Me.floDataDisplay.Controls.Add(Me.txtItemCodeName)
        Me.floDataDisplay.Controls.Add(Me.lblItemCodeNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtItemCodeNameAra)
        Me.floDataDisplay.Controls.Add(Me.LblNote)
        Me.floDataDisplay.Controls.Add(Me.txtNote)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Translatable = true
        '
        'cboCodeGroupIdNo
        '
        Me.cboCodeGroupIdNo.BackColor = System.Drawing.Color.White
        Me.cboCodeGroupIdNo.BegFindValue = Nothing
        Me.cboCodeGroupIdNo.ChangingSearchValueOnly = false
        Me.cboCodeGroupIdNo.CurrentSearchTerm = ""
        Me.cboCodeGroupIdNo.DataValue = Nothing
        Me.cboCodeGroupIdNo.DefaultValue = Nothing
        Me.cboCodeGroupIdNo.DisplayMember = "Name"
        Me.cboCodeGroupIdNo.EditingMode = true
        Me.cboCodeGroupIdNo.EndFindValue = Nothing
        Me.cboCodeGroupIdNo.FieldDescription = Nothing
        Me.cboCodeGroupIdNo.FieldName = Nothing
        Me.cboCodeGroupIdNo.FilterRule = Nothing
        Me.cboCodeGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboCodeGroupIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboCodeGroupIdNo, "cboCodeGroupIdNo")
        Me.cboCodeGroupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboCodeGroupIdNo.FormattingEnabled = true
        Me.cboCodeGroupIdNo.HideWhenNotEditingOrAdding = false
        Me.cboCodeGroupIdNo.IgnoreCase = false
        Me.cboCodeGroupIdNo.LinkedLabel = Nothing
        Me.cboCodeGroupIdNo.Name = "cboCodeGroupIdNo"
        Me.cboCodeGroupIdNo.OldValue = 0
        Me.cboCodeGroupIdNo.OriginalDataSource = Nothing
        Me.cboCodeGroupIdNo.OriginalList = Nothing
        Me.cboCodeGroupIdNo.OverrideDropDownStyleList = false
        Me.cboCodeGroupIdNo.PreviousSearchTerm = Nothing
        Me.cboCodeGroupIdNo.PropertySelector = Nothing
        Me.cboCodeGroupIdNo.ReadOnlyCombo = false
        Me.cboCodeGroupIdNo.SuggestBoxHeight = 200
        Me.cboCodeGroupIdNo.SuggestListOrderRule = Nothing
        Me.cboCodeGroupIdNo.TextToSearch = Nothing
        Me.cboCodeGroupIdNo.Translatable = false
        Me.cboCodeGroupIdNo.ValueIsMandatory = false
        Me.cboCodeGroupIdNo.ValueIsNullable = false
        Me.cboCodeGroupIdNo.ValueIsNumeric = false
        Me.cboCodeGroupIdNo.ValueMember = "IdNo"
        '
        'LblNote
        '
        Me.LblNote.DisplayOnly = true
        Me.LblNote.EditingMode = false
        resources.ApplyResources(Me.LblNote, "LblNote")
        Me.LblNote.Name = "LblNote"
        Me.LblNote.Translatable = true
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.BegFindValue = Nothing
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.ComputedValue = false
        Me.txtNote.CustomFormat = Nothing
        Me.txtNote.DataBoundControl = true
        Me.txtNote.EditingMode = false
        Me.txtNote.EndFindValue = Nothing
        Me.txtNote.FieldDescription = Nothing
        Me.txtNote.FieldName = Nothing
        Me.txtNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNote.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtNote, true)
        resources.ApplyResources(Me.txtNote, "txtNote")
        Me.txtNote.ForeColor = System.Drawing.Color.Black
        Me.txtNote.LinkedLabel = Me.lblItemCodeName
        Me.txtNote.MaximumValue = Nothing
        Me.txtNote.MinimumValue = Nothing
        Me.txtNote.Name = "txtNote"
        Me.txtNote.OldValue = Nothing
        Me.txtNote.ReadOnly = true
        Me.txtNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNote.Translatable = false
        Me.txtNote.ValueIsMandatory = true
        Me.txtNote.ValueIsUnique = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.floDataDisplay)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'btnLockGroup
        '
        Me.btnLockGroup.BackColor = System.Drawing.Color.GreenYellow
        resources.ApplyResources(Me.btnLockGroup, "btnLockGroup")
        Me.btnLockGroup.DesignerSelected = true
        Me.btnLockGroup.ImageIndex = 0
        Me.btnLockGroup.Name = "btnLockGroup"
        Me.btnLockGroup.OriginalImageName = Nothing
        Me.btnLockGroup.SecurityKey = ""
        '
        'ItemCodeEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "ItemCodeEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtItemCodeCode As CTextBox
        Friend WithEvents txtItemCodeName As CTextBox
        Friend WithEvents txtItemCodeNameAra As CTextBoxArabic
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblItemCodeCode As CLabel
        Friend WithEvents lblItemCodeName As CLabel
        Friend WithEvents lblItemCodeNameAra As CLabel
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cboCodeGroupIdNo As CaComboBox
        Friend WithEvents LblNote As CLabel
        Friend WithEvents txtNote As CTextBox
        Friend WithEvents btnLockGroup As CButton
    End Class
End Namespace