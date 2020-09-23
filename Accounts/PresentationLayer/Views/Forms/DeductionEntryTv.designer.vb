Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DeductionEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeductionEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDeductionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDeductionName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDeductionNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDeductionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDeductionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblDefaultFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDefaultFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            'txtDeductionCode
            '
            Me.txtDeductionCode.BackColor = System.Drawing.Color.White
            Me.txtDeductionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeductionCode.ComputedValue = False
            Me.txtDeductionCode.CustomFormat = Nothing
            Me.txtDeductionCode.DataBoundControl = True
            Me.txtDeductionCode.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDeductionCode, True)
            resources.ApplyResources(Me.txtDeductionCode, "txtDeductionCode")
            Me.txtDeductionCode.ForeColor = System.Drawing.Color.Black
            Me.txtDeductionCode.LinkedLabel = Nothing
            Me.txtDeductionCode.MaximumValue = Nothing
            Me.txtDeductionCode.MinimumValue = Nothing
            Me.txtDeductionCode.Name = "txtDeductionCode"
            Me.txtDeductionCode.OldValue = Nothing
            Me.txtDeductionCode.ReadOnly = True
            Me.txtDeductionCode.ValueIsMandatory = True
            '
            'txtDeductionName
            '
            Me.txtDeductionName.BackColor = System.Drawing.Color.White
            Me.txtDeductionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeductionName.ComputedValue = False
            Me.txtDeductionName.CustomFormat = Nothing
            Me.txtDeductionName.DataBoundControl = True
            Me.txtDeductionName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtDeductionName, True)
            resources.ApplyResources(Me.txtDeductionName, "txtDeductionName")
            Me.txtDeductionName.ForeColor = System.Drawing.Color.Black
            Me.txtDeductionName.LinkedLabel = Nothing
            Me.txtDeductionName.MaximumValue = Nothing
            Me.txtDeductionName.MinimumValue = Nothing
            Me.txtDeductionName.Name = "txtDeductionName"
            Me.txtDeductionName.OldValue = Nothing
            Me.txtDeductionName.ReadOnly = True
            Me.txtDeductionName.ValueIsMandatory = True
            '
            'txtDeductionNameAra
            '
            Me.txtDeductionNameAra.BackColor = System.Drawing.Color.White
            Me.txtDeductionNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeductionNameAra.ComputedValue = False
            Me.txtDeductionNameAra.CustomFormat = Nothing
            Me.txtDeductionNameAra.DataBoundControl = True
            Me.txtDeductionNameAra.EditingMode = False
            Me.txtDeductionNameAra.EnglishControl = Me.txtDeductionName
            Me.floDataDisplay.SetFlowBreak(Me.txtDeductionNameAra, True)
            resources.ApplyResources(Me.txtDeductionNameAra, "txtDeductionNameAra")
            Me.txtDeductionNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDeductionNameAra.LinkedLabel = Nothing
            Me.txtDeductionNameAra.MaximumValue = Nothing
            Me.txtDeductionNameAra.MinimumValue = Nothing
            Me.txtDeductionNameAra.Name = "txtDeductionNameAra"
            Me.txtDeductionNameAra.OldValue = Nothing
            Me.txtDeductionNameAra.ReadOnly = True
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
            Me.floDataDisplay.Controls.Add(Me.txtDeductionCode)
            Me.floDataDisplay.Controls.Add(Me.lblName)
            Me.floDataDisplay.Controls.Add(Me.txtDeductionName)
            Me.floDataDisplay.Controls.Add(Me.lblNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtDeductionNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblDeductionType)
            Me.floDataDisplay.Controls.Add(Me.cboDeductionType)
            Me.floDataDisplay.Controls.Add(Me.lblDefaultFrequency)
            Me.floDataDisplay.Controls.Add(Me.cboDefaultFrequency)
            Me.floDataDisplay.Controls.Add(Me.lblAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboAccountIdNo)
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
            'lblDeductionType
            '
            Me.lblDeductionType.DisplayOnly = True
            Me.lblDeductionType.EditingMode = False
            resources.ApplyResources(Me.lblDeductionType, "lblDeductionType")
            Me.lblDeductionType.Name = "lblDeductionType"
            '
            'cboDeductionType
            '
            Me.cboDeductionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDeductionType.BackColor = System.Drawing.Color.White
            Me.cboDeductionType.ChangingSearchValueOnly = False
            Me.cboDeductionType.CurrentSearchTerm = ""
            Me.cboDeductionType.DefaultValue = ""
            Me.cboDeductionType.DisplayMember = "Name"
            Me.cboDeductionType.DropDownHeight = 1
            Me.cboDeductionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDeductionType.EditingMode = False
            Me.cboDeductionType.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cboDeductionType, True)
            resources.ApplyResources(Me.cboDeductionType, "cboDeductionType")
            Me.cboDeductionType.ForeColor = System.Drawing.Color.Black
            Me.cboDeductionType.HideWhenNotEditingOrAdding = False
            Me.cboDeductionType.LinkedLabel = Me.lblDeductionType
            Me.cboDeductionType.Name = "cboDeductionType"
            Me.cboDeductionType.OldValue = 0
            Me.cboDeductionType.OriginalDataSource = Nothing
            Me.cboDeductionType.OriginalList = Nothing
            Me.cboDeductionType.OverrideDropDownStyleList = False
            Me.cboDeductionType.PreviousSearchTerm = Nothing
            Me.cboDeductionType.PreviousSelectedIndex = 0
            Me.cboDeductionType.PropertySelector = Nothing
            Me.cboDeductionType.ReadOnlyCombo = False
            Me.cboDeductionType.SearchAnywhere = False
            Me.cboDeductionType.SuggestBoxHeight = 200
            Me.cboDeductionType.SuggestListOrderRule = Nothing
            Me.cboDeductionType.TextToSearch = Nothing
            Me.cboDeductionType.ValueIsMandatory = False
            Me.cboDeductionType.ValueIsNullable = False
            Me.cboDeductionType.ValueIsNumeric = False
            Me.cboDeductionType.ValueMember = "Code"
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
            Me.cboDefaultFrequency.DefaultValue = Nothing
            Me.cboDefaultFrequency.DisplayMember = "Name"
            Me.cboDefaultFrequency.DropDownHeight = 1
            Me.cboDefaultFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDefaultFrequency.EditingMode = False
            Me.cboDefaultFrequency.FilterRule = Nothing
            resources.ApplyResources(Me.cboDefaultFrequency, "cboDefaultFrequency")
            Me.floDataDisplay.SetFlowBreak(Me.cboDefaultFrequency, True)
            Me.cboDefaultFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboDefaultFrequency.FormattingEnabled = True
            Me.cboDefaultFrequency.HideWhenNotEditingOrAdding = False
            Me.cboDefaultFrequency.LinkedLabel = Nothing
            Me.cboDefaultFrequency.Name = "cboDefaultFrequency"
            Me.cboDefaultFrequency.OldValue = 0
            Me.cboDefaultFrequency.OriginalDataSource = Nothing
            Me.cboDefaultFrequency.OriginalList = Nothing
            Me.cboDefaultFrequency.OverrideDropDownStyleList = False
            Me.cboDefaultFrequency.PreviousSearchTerm = Nothing
            Me.cboDefaultFrequency.PreviousSelectedIndex = -1
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
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.floDataDisplay.SetFlowBreak(Me.cboAccountIdNo, True)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = -1
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
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'DeductionEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "DeductionEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtDeductionCode As CTextBox
        Friend WithEvents txtDeductionName As CTextBox
        Friend WithEvents txtDeductionNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents lblDefaultFrequency As CLabel
        Friend WithEvents lblDeductionType As CLabel
        Friend WithEvents cboDeductionType As CaComboBox
        Friend WithEvents cboDefaultFrequency As CaComboBox
        Friend WithEvents cboAccountIdNo As CaComboBox
    End Class
End Namespace