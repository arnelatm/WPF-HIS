Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AppSettingEntry
        Inherits CFormEntry

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppSettingEntry))
            Dim CBlendItems1 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblAppSettingName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAppSettingGroupSelector = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.btnLockGroup = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboSelector1IdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.LblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSelector2IdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtAppSettingGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblAppSettingName
            '
            Me.lblAppSettingName.DisplayOnly = True
            Me.lblAppSettingName.EditingMode = False
            resources.ApplyResources(Me.lblAppSettingName, "lblAppSettingName")
            Me.lblAppSettingName.Name = "lblAppSettingName"
            Me.lblAppSettingName.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.floDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.cboAppSettingGroupSelector)
            Me.floDataDisplay.Controls.Add(Me.btnLockGroup)
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblAppSettingName)
            Me.floDataDisplay.Controls.Add(Me.cboSelector1IdNo)
            Me.floDataDisplay.Controls.Add(Me.LblNote)
            Me.floDataDisplay.Controls.Add(Me.cboSelector2IdNo)
            Me.floDataDisplay.Controls.Add(Me.txtAppSettingGroupIdNo)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'cboAppSettingGroupSelector
            '
            Me.cboAppSettingGroupSelector.BackColor = System.Drawing.Color.White
            Me.cboAppSettingGroupSelector.BegFindValue = Nothing
            Me.cboAppSettingGroupSelector.ChangingSearchValueOnly = False
            Me.cboAppSettingGroupSelector.CurrentSearchTerm = ""
            Me.cboAppSettingGroupSelector.DataValue = Nothing
            Me.cboAppSettingGroupSelector.DefaultValue = Nothing
            Me.cboAppSettingGroupSelector.DisplayMember = "Name"
            Me.cboAppSettingGroupSelector.Editable = True
            Me.cboAppSettingGroupSelector.EditingMode = True
            Me.cboAppSettingGroupSelector.EndFindValue = Nothing
            Me.cboAppSettingGroupSelector.FieldDescription = Nothing
            Me.cboAppSettingGroupSelector.FieldName = Nothing
            Me.cboAppSettingGroupSelector.FilterRule = Nothing
            Me.cboAppSettingGroupSelector.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAppSettingGroupSelector.FindEnabled = False
            resources.ApplyResources(Me.cboAppSettingGroupSelector, "cboAppSettingGroupSelector")
            Me.cboAppSettingGroupSelector.ForeColor = System.Drawing.Color.Black
            Me.cboAppSettingGroupSelector.FormattingEnabled = True
            Me.cboAppSettingGroupSelector.HideWhenNotEditingOrAdding = False
            Me.cboAppSettingGroupSelector.IgnoreCase = False
            Me.cboAppSettingGroupSelector.LimitToList = False
            Me.cboAppSettingGroupSelector.LinkedLabel = Nothing
            Me.cboAppSettingGroupSelector.Name = "cboAppSettingGroupSelector"
            Me.cboAppSettingGroupSelector.OldValue = 0
            Me.cboAppSettingGroupSelector.OriginalDataSource = Nothing
            Me.cboAppSettingGroupSelector.OriginalList = Nothing
            Me.cboAppSettingGroupSelector.OverrideDropDownStyleList = False
            Me.cboAppSettingGroupSelector.PreviousSearchTerm = Nothing
            Me.cboAppSettingGroupSelector.PropertySelector = Nothing
            Me.cboAppSettingGroupSelector.SuggestBoxHeight = 200
            Me.cboAppSettingGroupSelector.SuggestCharCount = 0
            Me.cboAppSettingGroupSelector.SuggestListOrderRule = Nothing
            Me.cboAppSettingGroupSelector.TextToSearch = Nothing
            Me.cboAppSettingGroupSelector.Translatable = False
            Me.cboAppSettingGroupSelector.ValueIsMandatory = False
            Me.cboAppSettingGroupSelector.ValueIsNullable = False
            Me.cboAppSettingGroupSelector.ValueIsNumeric = False
            Me.cboAppSettingGroupSelector.ValueMember = "IdNo"
            '
            'btnLockGroup
            '
            Me.btnLockGroup.BackColor = System.Drawing.Color.GreenYellow
            resources.ApplyResources(Me.btnLockGroup, "btnLockGroup")
            CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
            CBlendItems1.iPoint = New Single() {0!, 1.0!}
            Me.btnLockGroup.ColorFillBlend = CBlendItems1
            Me.btnLockGroup.DesignerSelected = False
            Me.btnLockGroup.FillType = AATM.Libraries.CBaseControlsLibrary.CButton.eFillType.Solid
            Me.btnLockGroup.ImageIndex = 0
            Me.btnLockGroup.Name = "btnLockGroup"
            Me.btnLockGroup.OriginalImageName = Nothing
            Me.btnLockGroup.SecurityKey = ""
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
            'cboSelector1IdNo
            '
            Me.cboSelector1IdNo.BackColor = System.Drawing.Color.White
            Me.cboSelector1IdNo.BegFindValue = Nothing
            Me.cboSelector1IdNo.ChangingSearchValueOnly = False
            Me.cboSelector1IdNo.CurrentSearchTerm = ""
            Me.cboSelector1IdNo.DataValue = Nothing
            Me.cboSelector1IdNo.DefaultValue = Nothing
            Me.cboSelector1IdNo.DisplayMember = "Name"
            Me.cboSelector1IdNo.Editable = True
            Me.cboSelector1IdNo.EditingMode = True
            Me.cboSelector1IdNo.EndFindValue = Nothing
            Me.cboSelector1IdNo.FieldDescription = Nothing
            Me.cboSelector1IdNo.FieldName = Nothing
            Me.cboSelector1IdNo.FilterRule = Nothing
            Me.cboSelector1IdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSelector1IdNo.FindEnabled = False
            resources.ApplyResources(Me.cboSelector1IdNo, "cboSelector1IdNo")
            Me.cboSelector1IdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSelector1IdNo.FormattingEnabled = True
            Me.cboSelector1IdNo.HideWhenNotEditingOrAdding = False
            Me.cboSelector1IdNo.IgnoreCase = False
            Me.cboSelector1IdNo.LimitToList = False
            Me.cboSelector1IdNo.LinkedLabel = Nothing
            Me.cboSelector1IdNo.Name = "cboSelector1IdNo"
            Me.cboSelector1IdNo.OldValue = 0
            Me.cboSelector1IdNo.OriginalDataSource = Nothing
            Me.cboSelector1IdNo.OriginalList = Nothing
            Me.cboSelector1IdNo.OverrideDropDownStyleList = False
            Me.cboSelector1IdNo.PreviousSearchTerm = Nothing
            Me.cboSelector1IdNo.PropertySelector = Nothing
            Me.cboSelector1IdNo.ReadOnlyCombo = False
            Me.cboSelector1IdNo.SuggestBoxHeight = 200
            Me.cboSelector1IdNo.SuggestListOrderRule = Nothing
            Me.cboSelector1IdNo.TextToSearch = Nothing
            Me.cboSelector1IdNo.Translatable = False
            Me.cboSelector1IdNo.ValueIsMandatory = False
            Me.cboSelector1IdNo.ValueIsNullable = False
            Me.cboSelector1IdNo.ValueIsNumeric = False
            Me.cboSelector1IdNo.ValueMember = "IdNo"
            '
            'LblNote
            '
            Me.LblNote.DisplayOnly = True
            Me.LblNote.EditingMode = False
            resources.ApplyResources(Me.LblNote, "LblNote")
            Me.LblNote.Name = "LblNote"
            Me.LblNote.Translatable = True
            '
            'cboSelector2IdNo
            '
            Me.cboSelector2IdNo.BackColor = System.Drawing.Color.White
            Me.cboSelector2IdNo.BegFindValue = Nothing
            Me.cboSelector2IdNo.ChangingSearchValueOnly = False
            Me.cboSelector2IdNo.CurrentSearchTerm = ""
            Me.cboSelector2IdNo.DataValue = Nothing
            Me.cboSelector2IdNo.DefaultValue = Nothing
            Me.cboSelector2IdNo.DisplayMember = "Name"
            Me.cboSelector2IdNo.Editable = True
            Me.cboSelector2IdNo.EditingMode = True
            Me.cboSelector2IdNo.EndFindValue = Nothing
            Me.cboSelector2IdNo.FieldDescription = Nothing
            Me.cboSelector2IdNo.FieldName = Nothing
            Me.cboSelector2IdNo.FilterRule = Nothing
            Me.cboSelector2IdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSelector2IdNo.FindEnabled = False
            resources.ApplyResources(Me.cboSelector2IdNo, "cboSelector2IdNo")
            Me.cboSelector2IdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSelector2IdNo.FormattingEnabled = True
            Me.cboSelector2IdNo.HideWhenNotEditingOrAdding = False
            Me.cboSelector2IdNo.IgnoreCase = False
            Me.cboSelector2IdNo.LimitToList = False
            Me.cboSelector2IdNo.LinkedLabel = Nothing
            Me.cboSelector2IdNo.Name = "cboSelector2IdNo"
            Me.cboSelector2IdNo.OldValue = 0
            Me.cboSelector2IdNo.OriginalDataSource = Nothing
            Me.cboSelector2IdNo.OriginalList = Nothing
            Me.cboSelector2IdNo.OverrideDropDownStyleList = False
            Me.cboSelector2IdNo.PreviousSearchTerm = Nothing
            Me.cboSelector2IdNo.PropertySelector = Nothing
            Me.cboSelector2IdNo.ReadOnlyCombo = False
            Me.cboSelector2IdNo.SuggestBoxHeight = 200
            Me.cboSelector2IdNo.SuggestListOrderRule = Nothing
            Me.cboSelector2IdNo.TextToSearch = Nothing
            Me.cboSelector2IdNo.Translatable = False
            Me.cboSelector2IdNo.ValueIsMandatory = False
            Me.cboSelector2IdNo.ValueIsNullable = False
            Me.cboSelector2IdNo.ValueIsNumeric = False
            Me.cboSelector2IdNo.ValueMember = "IdNo"
            '
            'txtAppSettingGroupIdNo
            '
            Me.txtAppSettingGroupIdNo.BackColor = System.Drawing.Color.White
            Me.txtAppSettingGroupIdNo.BegFindValue = Nothing
            Me.txtAppSettingGroupIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAppSettingGroupIdNo.ComputedValue = False
            Me.txtAppSettingGroupIdNo.CustomFormat = Nothing
            Me.txtAppSettingGroupIdNo.DataBoundControl = True
            Me.txtAppSettingGroupIdNo.DisplayOnly = True
            Me.txtAppSettingGroupIdNo.EditingMode = True
            Me.txtAppSettingGroupIdNo.EndFindValue = Nothing
            Me.txtAppSettingGroupIdNo.FieldDescription = Nothing
            Me.txtAppSettingGroupIdNo.FieldName = Nothing
            Me.txtAppSettingGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAppSettingGroupIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtAppSettingGroupIdNo, True)
            resources.ApplyResources(Me.txtAppSettingGroupIdNo, "txtAppSettingGroupIdNo")
            Me.txtAppSettingGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtAppSettingGroupIdNo.LinkedLabel = Me.lblIdNo
            Me.txtAppSettingGroupIdNo.MaximumValue = Nothing
            Me.txtAppSettingGroupIdNo.MinimumValue = Nothing
            Me.txtAppSettingGroupIdNo.Name = "txtAppSettingGroupIdNo"
            Me.txtAppSettingGroupIdNo.OldValue = Nothing
            Me.txtAppSettingGroupIdNo.OverrideMaxLength = 0
            Me.txtAppSettingGroupIdNo.ReadOnly = True
            Me.txtAppSettingGroupIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAppSettingGroupIdNo.TabStop = False
            Me.txtAppSettingGroupIdNo.Translatable = False
            Me.txtAppSettingGroupIdNo.ValueIsNumeric = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'CrystalReportViewer1
            '
            Me.CrystalReportViewer1.ActiveViewIndex = -1
            Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            resources.ApplyResources(Me.CrystalReportViewer1, "CrystalReportViewer1")
            Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
            '
            'AppSettingEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "AppSettingEntryTv"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblAppSettingName As CLabel
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cboAppSettingGroupSelector As CtComboBox
        Friend WithEvents LblNote As CLabel
        Friend WithEvents btnLockGroup As CButton
        Friend WithEvents txtAppSettingGroupIdNo As CTextBox
        Friend WithEvents cboSelector1IdNo As CaComboBox
        Friend WithEvents cboSelector2IdNo As CaComboBox
        Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents TxtIdNo As CTextBox
    End Class
End Namespace