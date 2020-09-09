Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FringeBenefitEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FringeBenefitEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblDefaultFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDefaultFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFringeBenefitType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboFringeBenefitType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtFringeBenefitCode
            '
            Me.txtFringeBenefitCode.BackColor = System.Drawing.Color.White
            Me.txtFringeBenefitCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFringeBenefitCode.ComputedValue = False
            Me.txtFringeBenefitCode.CustomFormat = Nothing
            Me.txtFringeBenefitCode.DataBoundControl = True
            Me.txtFringeBenefitCode.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitCode, True)
            resources.ApplyResources(Me.txtFringeBenefitCode, "txtFringeBenefitCode")
            Me.txtFringeBenefitCode.ForeColor = System.Drawing.Color.Black
            Me.txtFringeBenefitCode.LinkedLabel = Nothing
            Me.txtFringeBenefitCode.MaximumValue = Nothing
            Me.txtFringeBenefitCode.MinimumValue = Nothing
            Me.txtFringeBenefitCode.Name = "txtFringeBenefitCode"
            Me.txtFringeBenefitCode.OldValue = Nothing
            Me.txtFringeBenefitCode.ReadOnly = True
            Me.txtFringeBenefitCode.ValueIsMandatory = True
            '
            'txtFringeBenefitName
            '
            Me.txtFringeBenefitName.BackColor = System.Drawing.Color.White
            Me.txtFringeBenefitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFringeBenefitName.ComputedValue = False
            Me.txtFringeBenefitName.CustomFormat = Nothing
            Me.txtFringeBenefitName.DataBoundControl = True
            Me.txtFringeBenefitName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitName, True)
            resources.ApplyResources(Me.txtFringeBenefitName, "txtFringeBenefitName")
            Me.txtFringeBenefitName.ForeColor = System.Drawing.Color.Black
            Me.txtFringeBenefitName.LinkedLabel = Nothing
            Me.txtFringeBenefitName.MaximumValue = Nothing
            Me.txtFringeBenefitName.MinimumValue = Nothing
            Me.txtFringeBenefitName.Name = "txtFringeBenefitName"
            Me.txtFringeBenefitName.OldValue = Nothing
            Me.txtFringeBenefitName.ReadOnly = True
            Me.txtFringeBenefitName.ValueIsMandatory = True
            '
            'txtFringeBenefitNameAra
            '
            Me.txtFringeBenefitNameAra.BackColor = System.Drawing.Color.White
            Me.txtFringeBenefitNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFringeBenefitNameAra.ComputedValue = False
            Me.txtFringeBenefitNameAra.CustomFormat = Nothing
            Me.txtFringeBenefitNameAra.DataBoundControl = True
            Me.txtFringeBenefitNameAra.EditingMode = False
            Me.txtFringeBenefitNameAra.EnglishControl = Me.txtFringeBenefitName
            Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitNameAra, True)
            resources.ApplyResources(Me.txtFringeBenefitNameAra, "txtFringeBenefitNameAra")
            Me.txtFringeBenefitNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtFringeBenefitNameAra.LinkedLabel = Nothing
            Me.txtFringeBenefitNameAra.MaximumValue = Nothing
            Me.txtFringeBenefitNameAra.MinimumValue = Nothing
            Me.txtFringeBenefitNameAra.Name = "txtFringeBenefitNameAra"
            Me.txtFringeBenefitNameAra.OldValue = Nothing
            Me.txtFringeBenefitNameAra.ReadOnly = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCode)
            Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitCode)
            Me.floDataDisplay.Controls.Add(Me.lblName)
            Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitName)
            Me.floDataDisplay.Controls.Add(Me.lblNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblDefaultFrequency)
            Me.floDataDisplay.Controls.Add(Me.cboDefaultFrequency)
            Me.floDataDisplay.Controls.Add(Me.lblFringeBenefitType)
            Me.floDataDisplay.Controls.Add(Me.cboFringeBenefitType)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cboAccountIdNo, True)
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = 0
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SearchAnywhere = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblDefaultFrequency
            '
            Me.lblDefaultFrequency.DisplayOnly = True
            Me.lblDefaultFrequency.EditingMode = False
            resources.ApplyResources(Me.lblDefaultFrequency, "lblDefaultFrequency")
            Me.lblDefaultFrequency.Name = "lblDefaultFrequency"
            '
            'cboDefaultFrequency
            '
            Me.cboDefaultFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDefaultFrequency.BackColor = System.Drawing.Color.White
            Me.cboDefaultFrequency.ChangingSearchValueOnly = False
            Me.cboDefaultFrequency.CurrentSearchTerm = ""
            Me.cboDefaultFrequency.DefaultValue = ""
            Me.cboDefaultFrequency.DisplayMember = "Name"
            Me.cboDefaultFrequency.DropDownHeight = 1
            Me.cboDefaultFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDefaultFrequency.EditingMode = False
            Me.cboDefaultFrequency.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cboDefaultFrequency, True)
            resources.ApplyResources(Me.cboDefaultFrequency, "cboDefaultFrequency")
            Me.cboDefaultFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboDefaultFrequency.HideWhenNotEditingOrAdding = False
            Me.cboDefaultFrequency.LinkedLabel = Me.lblDefaultFrequency
            Me.cboDefaultFrequency.Name = "cboDefaultFrequency"
            Me.cboDefaultFrequency.OldValue = 0
            Me.cboDefaultFrequency.OriginalDataSource = Nothing
            Me.cboDefaultFrequency.OriginalList = Nothing
            Me.cboDefaultFrequency.OverrideDropDownStyleList = False
            Me.cboDefaultFrequency.PreviousSearchTerm = Nothing
            Me.cboDefaultFrequency.PreviousSelectedIndex = 0
            Me.cboDefaultFrequency.PropertySelector = Nothing
            Me.cboDefaultFrequency.ReadOnlyCombo = False
            Me.cboDefaultFrequency.SearchAnywhere = False
            Me.cboDefaultFrequency.SuggestBoxHeight = 200
            Me.cboDefaultFrequency.SuggestListOrderRule = Nothing
            Me.cboDefaultFrequency.TextToSearch = Nothing
            Me.cboDefaultFrequency.ValueIsMandatory = False
            Me.cboDefaultFrequency.ValueIsNullable = False
            Me.cboDefaultFrequency.ValueIsNumeric = False
            Me.cboDefaultFrequency.ValueMember = "Code"
            '
            'lblFringeBenefitType
            '
            Me.lblFringeBenefitType.DisplayOnly = True
            Me.lblFringeBenefitType.EditingMode = False
            resources.ApplyResources(Me.lblFringeBenefitType, "lblFringeBenefitType")
            Me.lblFringeBenefitType.Name = "lblFringeBenefitType"
            '
            'cboFringeBenefitType
            '
            Me.cboFringeBenefitType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboFringeBenefitType.BackColor = System.Drawing.Color.White
            Me.cboFringeBenefitType.ChangingSearchValueOnly = False
            Me.cboFringeBenefitType.CurrentSearchTerm = ""
            Me.cboFringeBenefitType.DefaultValue = ""
            Me.cboFringeBenefitType.DisplayMember = "Name"
            Me.cboFringeBenefitType.DropDownHeight = 1
            Me.cboFringeBenefitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFringeBenefitType.EditingMode = False
            Me.cboFringeBenefitType.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cboFringeBenefitType, True)
            resources.ApplyResources(Me.cboFringeBenefitType, "cboFringeBenefitType")
            Me.cboFringeBenefitType.ForeColor = System.Drawing.Color.Black
            Me.cboFringeBenefitType.HideWhenNotEditingOrAdding = False
            Me.cboFringeBenefitType.LinkedLabel = Me.lblFringeBenefitType
            Me.cboFringeBenefitType.Name = "cboFringeBenefitType"
            Me.cboFringeBenefitType.OldValue = 0
            Me.cboFringeBenefitType.OriginalDataSource = Nothing
            Me.cboFringeBenefitType.OriginalList = Nothing
            Me.cboFringeBenefitType.OverrideDropDownStyleList = False
            Me.cboFringeBenefitType.PreviousSearchTerm = Nothing
            Me.cboFringeBenefitType.PreviousSelectedIndex = 0
            Me.cboFringeBenefitType.PropertySelector = Nothing
            Me.cboFringeBenefitType.ReadOnlyCombo = False
            Me.cboFringeBenefitType.SearchAnywhere = False
            Me.cboFringeBenefitType.SuggestBoxHeight = 200
            Me.cboFringeBenefitType.SuggestListOrderRule = Nothing
            Me.cboFringeBenefitType.TextToSearch = Nothing
            Me.cboFringeBenefitType.ValueIsMandatory = False
            Me.cboFringeBenefitType.ValueIsNullable = False
            Me.cboFringeBenefitType.ValueIsNumeric = False
            Me.cboFringeBenefitType.ValueMember = "Code"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'FringeBenefitEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "FringeBenefitEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtFringeBenefitCode As CTextBox
        Friend WithEvents txtFringeBenefitName As CTextBox
        Friend WithEvents txtFringeBenefitNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblDefaultFrequency As CLabel
        Friend WithEvents cboDefaultFrequency As CaComboBox
        Friend WithEvents lblFringeBenefitType As CLabel
        Friend WithEvents cboFringeBenefitType As CaComboBox
    End Class
End Namespace