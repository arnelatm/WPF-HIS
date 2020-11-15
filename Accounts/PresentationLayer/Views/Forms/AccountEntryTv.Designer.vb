Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountEntryTv))
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAccountCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAccountName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAccountNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblAccountNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountGroup = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountGroup = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblSpecialAccount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboSpecialAccount = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkDetailAccount = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblWithReconciliation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkWithReconciliation = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblNormalBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboNormalBalance = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayeeType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayeeType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.DisplayOnly = true
        Me.txtIdNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtIdNo, true)
        resources.ApplyResources(Me.txtIdNo, "txtIdNo")
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Me.lblIdNo
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.ReadOnly = true
        Me.txtIdNo.TabStop = false
        Me.txtIdNo.ValueIsNumeric = true
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'txtAccountCode
        '
        Me.txtAccountCode.BackColor = System.Drawing.Color.White
        Me.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountCode.ComputedValue = false
        Me.txtAccountCode.CustomFormat = Nothing
        Me.txtAccountCode.DataBoundControl = true
        Me.txtAccountCode.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtAccountCode, true)
        resources.ApplyResources(Me.txtAccountCode, "txtAccountCode")
        Me.txtAccountCode.ForeColor = System.Drawing.Color.Black
        Me.txtAccountCode.LinkedLabel = Me.lblAccountCode
        Me.txtAccountCode.MaximumValue = Nothing
        Me.txtAccountCode.MinimumValue = Nothing
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.OldValue = Nothing
        Me.txtAccountCode.ReadOnly = true
        Me.txtAccountCode.ValueIsMandatory = true
        '
        'lblAccountCode
        '
        Me.lblAccountCode.DisplayOnly = true
        Me.lblAccountCode.EditingMode = false
        resources.ApplyResources(Me.lblAccountCode, "lblAccountCode")
        Me.lblAccountCode.Name = "lblAccountCode"
        '
        'txtAccountName
        '
        Me.txtAccountName.BackColor = System.Drawing.Color.White
        Me.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountName.ComputedValue = false
        Me.txtAccountName.CustomFormat = Nothing
        Me.txtAccountName.DataBoundControl = true
        Me.txtAccountName.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtAccountName, true)
        resources.ApplyResources(Me.txtAccountName, "txtAccountName")
        Me.txtAccountName.ForeColor = System.Drawing.Color.Black
        Me.txtAccountName.LinkedLabel = Me.lblAccountName
        Me.txtAccountName.MaximumValue = Nothing
        Me.txtAccountName.MinimumValue = Nothing
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.OldValue = Nothing
        Me.txtAccountName.ReadOnly = true
        Me.txtAccountName.ValueIsMandatory = true
        '
        'lblAccountName
        '
        Me.lblAccountName.DisplayOnly = true
        Me.lblAccountName.EditingMode = false
        resources.ApplyResources(Me.lblAccountName, "lblAccountName")
        Me.lblAccountName.Name = "lblAccountName"
        '
        'txtAccountNameAra
        '
        Me.txtAccountNameAra.BackColor = System.Drawing.Color.White
        Me.txtAccountNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountNameAra.ComputedValue = false
        Me.txtAccountNameAra.CustomFormat = Nothing
        Me.txtAccountNameAra.DataBoundControl = true
        Me.txtAccountNameAra.EditingMode = true
        Me.txtAccountNameAra.EnglishControl = Me.txtAccountName
        Me.floDataDisplay.SetFlowBreak(Me.txtAccountNameAra, true)
        resources.ApplyResources(Me.txtAccountNameAra, "txtAccountNameAra")
        Me.txtAccountNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtAccountNameAra.LinkedLabel = Me.lblAccountNameAra
        Me.txtAccountNameAra.MaximumValue = Nothing
        Me.txtAccountNameAra.MinimumValue = Nothing
        Me.txtAccountNameAra.Name = "txtAccountNameAra"
        Me.txtAccountNameAra.OldValue = Nothing
        Me.txtAccountNameAra.ReadOnly = true
        '
        'lblAccountNameAra
        '
        Me.lblAccountNameAra.DisplayOnly = true
        Me.lblAccountNameAra.EditingMode = false
        resources.ApplyResources(Me.lblAccountNameAra, "lblAccountNameAra")
        Me.lblAccountNameAra.Name = "lblAccountNameAra"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtNotes, true)
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.txtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblAccountCode)
        Me.floDataDisplay.Controls.Add(Me.txtAccountCode)
        Me.floDataDisplay.Controls.Add(Me.lblAccountName)
        Me.floDataDisplay.Controls.Add(Me.txtAccountName)
        Me.floDataDisplay.Controls.Add(Me.lblAccountNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtAccountNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.lblAccountGroup)
        Me.floDataDisplay.Controls.Add(Me.cboAccountGroup)
        Me.floDataDisplay.Controls.Add(Me.lblSpecialAccount)
        Me.floDataDisplay.Controls.Add(Me.cboSpecialAccount)
        Me.floDataDisplay.Controls.Add(Me.CLabel1)
        Me.floDataDisplay.Controls.Add(Me.chkDetailAccount)
        Me.floDataDisplay.Controls.Add(Me.lblWithReconciliation)
        Me.floDataDisplay.Controls.Add(Me.chkWithReconciliation)
        Me.floDataDisplay.Controls.Add(Me.lblActive)
        Me.floDataDisplay.Controls.Add(Me.chkActive)
        Me.floDataDisplay.Controls.Add(Me.lblNormalBalance)
        Me.floDataDisplay.Controls.Add(Me.cboNormalBalance)
        Me.floDataDisplay.Controls.Add(Me.lblPayeeType)
        Me.floDataDisplay.Controls.Add(Me.cboPayeeType)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Controls.Add(Me.txtSortKey)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
        Me.lblParentIdNo.Name = "lblParentIdNo"
        '
        'cboParentIdNo
        '
        Me.cboParentIdNo.BackColor = System.Drawing.Color.White
        Me.cboParentIdNo.ChangingSearchValueOnly = false
        Me.cboParentIdNo.CurrentSearchTerm = ""
        Me.cboParentIdNo.DefaultValue = Nothing
        Me.cboParentIdNo.DisplayMember = "Name"
        Me.cboParentIdNo.DropDownHeight = 1
        Me.cboParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParentIdNo.EditingMode = false
        Me.cboParentIdNo.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cboParentIdNo, true)
        resources.ApplyResources(Me.cboParentIdNo, "cboParentIdNo")
        Me.cboParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboParentIdNo.FormattingEnabled = true
        Me.cboParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cboParentIdNo.LinkedLabel = Nothing
        Me.cboParentIdNo.Name = "cboParentIdNo"
        Me.cboParentIdNo.OldValue = 0
        Me.cboParentIdNo.OriginalDataSource = Nothing
        Me.cboParentIdNo.OriginalList = Nothing
        Me.cboParentIdNo.OverrideDropDownStyleList = false
        Me.cboParentIdNo.PreviousSearchTerm = Nothing
        Me.cboParentIdNo.PreviousSelectedIndex = -1
        Me.cboParentIdNo.PropertySelector = Nothing
        Me.cboParentIdNo.ReadOnlyCombo = false
        Me.cboParentIdNo.SearchAnywhere = false
        Me.cboParentIdNo.SuggestBoxHeight = 200
        Me.cboParentIdNo.SuggestListOrderRule = Nothing
        Me.cboParentIdNo.TextToSearch = Nothing
        Me.cboParentIdNo.ValueIsMandatory = false
        Me.cboParentIdNo.ValueIsNullable = false
        Me.cboParentIdNo.ValueIsNumeric = false
        Me.cboParentIdNo.ValueMember = "IdNo"
        '
        'lblLevelNumber
        '
        Me.lblLevelNumber.DisplayOnly = true
        Me.lblLevelNumber.EditingMode = false
        resources.ApplyResources(Me.lblLevelNumber, "lblLevelNumber")
        Me.lblLevelNumber.Name = "lblLevelNumber"
        '
        'txtLevelNumber
        '
        Me.txtLevelNumber.BackColor = System.Drawing.Color.White
        Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLevelNumber.ComputedValue = false
        Me.txtLevelNumber.CustomFormat = Nothing
        Me.txtLevelNumber.DataBoundControl = true
        Me.txtLevelNumber.DisplayOnly = true
        Me.txtLevelNumber.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, true)
        resources.ApplyResources(Me.txtLevelNumber, "txtLevelNumber")
        Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
        Me.txtLevelNumber.IgnoreNullCheck = true
        Me.txtLevelNumber.LinkedLabel = Me.lblLevelNumber
        Me.txtLevelNumber.MaximumValue = Nothing
        Me.txtLevelNumber.MinimumValue = Nothing
        Me.txtLevelNumber.Name = "txtLevelNumber"
        Me.txtLevelNumber.OldValue = Nothing
        Me.txtLevelNumber.ReadOnly = true
        Me.txtLevelNumber.ValueIsMandatory = true
        Me.txtLevelNumber.ValueIsNumeric = true
        '
        'lblAccountGroup
        '
        Me.lblAccountGroup.DisplayOnly = true
        Me.lblAccountGroup.EditingMode = false
        resources.ApplyResources(Me.lblAccountGroup, "lblAccountGroup")
        Me.lblAccountGroup.Name = "lblAccountGroup"
        '
        'cboAccountGroup
        '
        Me.cboAccountGroup.BackColor = System.Drawing.Color.White
        Me.cboAccountGroup.ChangingSearchValueOnly = false
        Me.cboAccountGroup.CurrentSearchTerm = ""
        Me.cboAccountGroup.DefaultValue = Nothing
        Me.cboAccountGroup.DisplayMember = "Name"
        Me.cboAccountGroup.DropDownHeight = 1
        Me.cboAccountGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountGroup.EditingMode = false
        Me.cboAccountGroup.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cboAccountGroup, true)
        resources.ApplyResources(Me.cboAccountGroup, "cboAccountGroup")
        Me.cboAccountGroup.ForeColor = System.Drawing.Color.Black
        Me.cboAccountGroup.FormattingEnabled = true
        Me.cboAccountGroup.HideWhenNotEditingOrAdding = false
        Me.cboAccountGroup.LinkedLabel = Nothing
        Me.cboAccountGroup.Name = "cboAccountGroup"
        Me.cboAccountGroup.OldValue = 0
        Me.cboAccountGroup.OriginalDataSource = Nothing
        Me.cboAccountGroup.OriginalList = Nothing
        Me.cboAccountGroup.OverrideDropDownStyleList = false
        Me.cboAccountGroup.PreviousSearchTerm = Nothing
        Me.cboAccountGroup.PreviousSelectedIndex = -1
        Me.cboAccountGroup.PropertySelector = Nothing
        Me.cboAccountGroup.ReadOnlyCombo = false
        Me.cboAccountGroup.SearchAnywhere = false
        Me.cboAccountGroup.SuggestBoxHeight = 200
        Me.cboAccountGroup.SuggestListOrderRule = Nothing
        Me.cboAccountGroup.TextToSearch = Nothing
        Me.cboAccountGroup.ValueIsMandatory = false
        Me.cboAccountGroup.ValueIsNullable = false
        Me.cboAccountGroup.ValueIsNumeric = false
        Me.cboAccountGroup.ValueMember = "Code"
        '
        'lblSpecialAccount
        '
        Me.lblSpecialAccount.DisplayOnly = true
        Me.lblSpecialAccount.EditingMode = false
        resources.ApplyResources(Me.lblSpecialAccount, "lblSpecialAccount")
        Me.lblSpecialAccount.Name = "lblSpecialAccount"
        '
        'cboSpecialAccount
        '
        Me.cboSpecialAccount.BackColor = System.Drawing.Color.White
        Me.cboSpecialAccount.ChangingSearchValueOnly = false
        Me.cboSpecialAccount.CurrentSearchTerm = ""
        Me.cboSpecialAccount.DefaultValue = Nothing
        Me.cboSpecialAccount.DisplayMember = "Name"
        Me.cboSpecialAccount.DropDownHeight = 1
        Me.cboSpecialAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpecialAccount.EditingMode = false
        Me.cboSpecialAccount.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cboSpecialAccount, true)
        resources.ApplyResources(Me.cboSpecialAccount, "cboSpecialAccount")
        Me.cboSpecialAccount.ForeColor = System.Drawing.Color.Black
        Me.cboSpecialAccount.FormattingEnabled = true
        Me.cboSpecialAccount.HideWhenNotEditingOrAdding = false
        Me.cboSpecialAccount.LinkedLabel = Me.lblAccountGroup
        Me.cboSpecialAccount.Name = "cboSpecialAccount"
        Me.cboSpecialAccount.OldValue = 0
        Me.cboSpecialAccount.OriginalDataSource = Nothing
        Me.cboSpecialAccount.OriginalList = Nothing
        Me.cboSpecialAccount.OverrideDropDownStyleList = false
        Me.cboSpecialAccount.PreviousSearchTerm = Nothing
        Me.cboSpecialAccount.PreviousSelectedIndex = -1
        Me.cboSpecialAccount.PropertySelector = Nothing
        Me.cboSpecialAccount.ReadOnlyCombo = false
        Me.cboSpecialAccount.SearchAnywhere = false
        Me.cboSpecialAccount.SuggestBoxHeight = 200
        Me.cboSpecialAccount.SuggestListOrderRule = Nothing
        Me.cboSpecialAccount.TextToSearch = Nothing
        Me.cboSpecialAccount.ValueIsMandatory = false
        Me.cboSpecialAccount.ValueIsNullable = false
        Me.cboSpecialAccount.ValueIsNumeric = false
        Me.cboSpecialAccount.ValueMember = "Code"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'chkDetailAccount
        '
        resources.ApplyResources(Me.chkDetailAccount, "chkDetailAccount")
        Me.chkDetailAccount.AutoCheck = false
        Me.chkDetailAccount.BackColor = System.Drawing.Color.White
        Me.chkDetailAccount.DisplayOnly = false
        Me.chkDetailAccount.EditingMode = false
        Me.chkDetailAccount.ForeColor = System.Drawing.Color.Black
        Me.chkDetailAccount.LinkedLabel = Nothing
        Me.chkDetailAccount.Name = "chkDetailAccount"
        Me.chkDetailAccount.NoLabel = true
        Me.chkDetailAccount.OldValue = Nothing
        Me.chkDetailAccount.UseVisualStyleBackColor = true
        '
        'lblWithReconciliation
        '
        Me.lblWithReconciliation.DisplayOnly = true
        Me.lblWithReconciliation.EditingMode = false
        resources.ApplyResources(Me.lblWithReconciliation, "lblWithReconciliation")
        Me.lblWithReconciliation.Name = "lblWithReconciliation"
        '
        'chkWithReconciliation
        '
        resources.ApplyResources(Me.chkWithReconciliation, "chkWithReconciliation")
        Me.chkWithReconciliation.AutoCheck = false
        Me.chkWithReconciliation.BackColor = System.Drawing.Color.White
        Me.chkWithReconciliation.Checked = true
        Me.chkWithReconciliation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWithReconciliation.DisplayOnly = false
        Me.chkWithReconciliation.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.chkWithReconciliation, true)
        Me.chkWithReconciliation.ForeColor = System.Drawing.Color.Black
        Me.chkWithReconciliation.LinkedLabel = Nothing
        Me.chkWithReconciliation.Name = "chkWithReconciliation"
        Me.chkWithReconciliation.NoLabel = true
        Me.chkWithReconciliation.OldValue = Nothing
        Me.chkWithReconciliation.UseVisualStyleBackColor = false
        '
        'lblActive
        '
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        resources.ApplyResources(Me.lblActive, "lblActive")
        Me.lblActive.Name = "lblActive"
        '
        'chkActive
        '
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.chkActive.AutoCheck = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.LinkedLabel = Nothing
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'lblNormalBalance
        '
        Me.lblNormalBalance.DisplayOnly = true
        Me.lblNormalBalance.EditingMode = false
        resources.ApplyResources(Me.lblNormalBalance, "lblNormalBalance")
        Me.lblNormalBalance.Name = "lblNormalBalance"
        '
        'cboNormalBalance
        '
        Me.cboNormalBalance.BackColor = System.Drawing.Color.White
        Me.cboNormalBalance.ChangingSearchValueOnly = false
        Me.cboNormalBalance.CurrentSearchTerm = ""
        Me.cboNormalBalance.DefaultValue = Nothing
        Me.cboNormalBalance.DisplayMember = "Name"
        Me.cboNormalBalance.DropDownHeight = 1
        Me.cboNormalBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNormalBalance.EditingMode = false
        Me.cboNormalBalance.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cboNormalBalance, true)
        resources.ApplyResources(Me.cboNormalBalance, "cboNormalBalance")
        Me.cboNormalBalance.ForeColor = System.Drawing.Color.Black
        Me.cboNormalBalance.FormattingEnabled = true
        Me.cboNormalBalance.HideWhenNotEditingOrAdding = false
        Me.cboNormalBalance.LinkedLabel = Nothing
        Me.cboNormalBalance.Name = "cboNormalBalance"
        Me.cboNormalBalance.OldValue = 0
        Me.cboNormalBalance.OriginalDataSource = Nothing
        Me.cboNormalBalance.OriginalList = Nothing
        Me.cboNormalBalance.OverrideDropDownStyleList = false
        Me.cboNormalBalance.PreviousSearchTerm = Nothing
        Me.cboNormalBalance.PreviousSelectedIndex = -1
        Me.cboNormalBalance.PropertySelector = Nothing
        Me.cboNormalBalance.ReadOnlyCombo = false
        Me.cboNormalBalance.SearchAnywhere = false
        Me.cboNormalBalance.SuggestBoxHeight = 200
        Me.cboNormalBalance.SuggestListOrderRule = Nothing
        Me.cboNormalBalance.TextToSearch = Nothing
        Me.cboNormalBalance.ValueIsMandatory = false
        Me.cboNormalBalance.ValueIsNullable = false
        Me.cboNormalBalance.ValueIsNumeric = false
        Me.cboNormalBalance.ValueMember = "Code"
        '
        'lblPayeeType
        '
        Me.lblPayeeType.DisplayOnly = true
        Me.lblPayeeType.EditingMode = false
        resources.ApplyResources(Me.lblPayeeType, "lblPayeeType")
        Me.lblPayeeType.Name = "lblPayeeType"
        '
        'cboPayeeType
        '
        Me.cboPayeeType.BackColor = System.Drawing.Color.White
        Me.cboPayeeType.ChangingSearchValueOnly = false
        Me.cboPayeeType.CurrentSearchTerm = ""
        Me.cboPayeeType.DefaultValue = Nothing
        Me.cboPayeeType.DisplayMember = "Name"
        Me.cboPayeeType.DropDownHeight = 1
        Me.cboPayeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayeeType.EditingMode = false
        Me.cboPayeeType.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cboPayeeType, true)
        resources.ApplyResources(Me.cboPayeeType, "cboPayeeType")
        Me.cboPayeeType.ForeColor = System.Drawing.Color.Black
        Me.cboPayeeType.FormattingEnabled = true
        Me.cboPayeeType.HideWhenNotEditingOrAdding = false
        Me.cboPayeeType.LinkedLabel = Nothing
        Me.cboPayeeType.Name = "cboPayeeType"
        Me.cboPayeeType.OldValue = 0
        Me.cboPayeeType.OriginalDataSource = Nothing
        Me.cboPayeeType.OriginalList = Nothing
        Me.cboPayeeType.OverrideDropDownStyleList = false
        Me.cboPayeeType.PreviousSearchTerm = Nothing
        Me.cboPayeeType.PreviousSelectedIndex = -1
        Me.cboPayeeType.PropertySelector = Nothing
        Me.cboPayeeType.ReadOnlyCombo = false
        Me.cboPayeeType.SearchAnywhere = false
        Me.cboPayeeType.SuggestBoxHeight = 200
        Me.cboPayeeType.SuggestListOrderRule = Nothing
        Me.cboPayeeType.TextToSearch = Nothing
        Me.cboPayeeType.ValueIsMandatory = false
        Me.cboPayeeType.ValueIsNullable = false
        Me.cboPayeeType.ValueIsNumeric = false
        Me.cboPayeeType.ValueMember = "Code"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'txtSortKey
        '
        Me.txtSortKey.BackColor = System.Drawing.Color.White
        Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSortKey.ComputedValue = false
        Me.txtSortKey.CustomFormat = Nothing
        Me.txtSortKey.DataBoundControl = true
        Me.txtSortKey.EditingMode = true
        resources.ApplyResources(Me.txtSortKey, "txtSortKey")
        Me.txtSortKey.ForeColor = System.Drawing.Color.Black
        Me.txtSortKey.LinkedLabel = Nothing
        Me.txtSortKey.MaximumValue = Nothing
        Me.txtSortKey.MinimumValue = Nothing
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.ReadOnly = true
        Me.txtSortKey.TabStop = false
        Me.txtSortKey.ValueIsMandatory = true
        '
        'AccountEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "AccountEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents txtAccountCode As CTextBox
        Friend WithEvents txtAccountName As CTextBox
        Friend WithEvents txtAccountNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblAccountCode As CLabel
        Friend WithEvents lblAccountName As CLabel
        Friend WithEvents lblAccountNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents lblAccountGroup As CLabel
        Friend WithEvents lblPayeeType As CLabel
        Friend WithEvents lblNormalBalance As CLabel
        Friend WithEvents chkWithReconciliation As CCheckBox
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblWithReconciliation As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents chkDetailAccount As CCheckBox
        Friend WithEvents cboNormalBalance As CaComboBox
        Friend WithEvents cboPayeeType As CaComboBox
        Friend WithEvents cboAccountGroup As CaComboBox
        Friend WithEvents cboParentIdNo As CaComboBox
        Friend WithEvents lblSpecialAccount As CLabel
        Friend WithEvents cboSpecialAccount As CaComboBox
    End Class
End NameSpace