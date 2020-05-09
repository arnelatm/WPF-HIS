Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.LocalizationUtilities

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CostCenterEntryTv
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
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCostCenterCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCostCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCostCenterCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCostCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 57)
        Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 258)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 258)
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(245, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        '
        'txtCostCenterCode
        '
        Me.txtCostCenterCode.BackColor = System.Drawing.Color.White
        Me.txtCostCenterCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostCenterCode.ComputedValue = false
        Me.txtCostCenterCode.CustomFormat = Nothing
        Me.txtCostCenterCode.DataBoundControl = true
        Me.txtCostCenterCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCostCenterCode, true)
        Me.txtCostCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCostCenterCode.ForeColor = System.Drawing.Color.Black
        Me.txtCostCenterCode.LinkedLabel = Nothing
        Me.txtCostCenterCode.Location = New System.Drawing.Point(245, 36)
        Me.txtCostCenterCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCostCenterCode.Name = "txtCostCenterCode"
        Me.txtCostCenterCode.OldValue = Nothing
        Me.txtCostCenterCode.Size = New System.Drawing.Size(62, 23)
        Me.txtCostCenterCode.TabIndex = 0
        Me.txtCostCenterCode.ValueIsMandatory = true
        '
        'txtCostCenterName
        '
        Me.txtCostCenterName.BackColor = System.Drawing.Color.White
        Me.txtCostCenterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostCenterName.ComputedValue = false
        Me.txtCostCenterName.CustomFormat = Nothing
        Me.txtCostCenterName.DataBoundControl = true
        Me.txtCostCenterName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCostCenterName, true)
        Me.txtCostCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCostCenterName.ForeColor = System.Drawing.Color.Black
        Me.txtCostCenterName.LinkedLabel = Nothing
        Me.txtCostCenterName.Location = New System.Drawing.Point(245, 61)
        Me.txtCostCenterName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCostCenterName.Name = "txtCostCenterName"
        Me.txtCostCenterName.OldValue = Nothing
        Me.txtCostCenterName.Size = New System.Drawing.Size(418, 23)
        Me.txtCostCenterName.TabIndex = 1
        Me.txtCostCenterName.ValueIsMandatory = true
        '
        'txtCostCenterNameAra
        '
        Me.txtCostCenterNameAra.BackColor = System.Drawing.Color.White
        Me.txtCostCenterNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostCenterNameAra.ComputedValue = false
        Me.txtCostCenterNameAra.CustomFormat = Nothing
        Me.txtCostCenterNameAra.DataBoundControl = true
        Me.txtCostCenterNameAra.EditingMode = false
        Me.txtCostCenterNameAra.EnglishControl = Me.txtCostCenterName
        Me.floDataDisplay.SetFlowBreak(Me.txtCostCenterNameAra, true)
        Me.txtCostCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCostCenterNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtCostCenterNameAra.LinkedLabel = Nothing
        Me.txtCostCenterNameAra.Location = New System.Drawing.Point(245, 86)
        Me.txtCostCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCostCenterNameAra.Name = "txtCostCenterNameAra"
        Me.txtCostCenterNameAra.OldValue = Nothing
        Me.txtCostCenterNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCostCenterNameAra.Size = New System.Drawing.Size(418, 23)
        Me.txtCostCenterNameAra.TabIndex = 2
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtNotes, true)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(245, 191)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(418, 60)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblCostCenterCode)
        Me.floDataDisplay.Controls.Add(Me.txtCostCenterCode)
        Me.floDataDisplay.Controls.Add(Me.lblCostCenterName)
        Me.floDataDisplay.Controls.Add(Me.txtCostCenterName)
        Me.floDataDisplay.Controls.Add(Me.lblCostCenterNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtCostCenterNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.lblProfitCenterIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacProfitCenterIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Controls.Add(Me.txtSortKey)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.floDataDisplay.Location = New System.Drawing.Point(300, 57)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(685, 258)
        Me.floDataDisplay.TabIndex = 147
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(232, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "CostCenter ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostCenterCode
        '
        Me.lblCostCenterCode.DisplayOnly = true
        Me.lblCostCenterCode.EditingMode = false
        Me.lblCostCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCostCenterCode.Location = New System.Drawing.Point(11, 36)
        Me.lblCostCenterCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCostCenterCode.Name = "lblCostCenterCode"
        Me.lblCostCenterCode.Size = New System.Drawing.Size(232, 23)
        Me.lblCostCenterCode.TabIndex = 156
        Me.lblCostCenterCode.Text = "CostCenter Code"
        Me.lblCostCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostCenterName
        '
        Me.lblCostCenterName.DisplayOnly = true
        Me.lblCostCenterName.EditingMode = false
        Me.lblCostCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCostCenterName.Location = New System.Drawing.Point(11, 61)
        Me.lblCostCenterName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCostCenterName.Name = "lblCostCenterName"
        Me.lblCostCenterName.Size = New System.Drawing.Size(232, 23)
        Me.lblCostCenterName.TabIndex = 157
        Me.lblCostCenterName.Text = "CostCenter Name"
        Me.lblCostCenterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostCenterNameAra
        '
        Me.lblCostCenterNameAra.DisplayOnly = true
        Me.lblCostCenterNameAra.EditingMode = false
        Me.lblCostCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCostCenterNameAra.Location = New System.Drawing.Point(11, 86)
        Me.lblCostCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCostCenterNameAra.Name = "lblCostCenterNameAra"
        Me.lblCostCenterNameAra.Size = New System.Drawing.Size(232, 23)
        Me.lblCostCenterNameAra.TabIndex = 158
        Me.lblCostCenterNameAra.Text = "CostCenter Name (Arabic)"
        Me.lblCostCenterNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParentIdNo.Location = New System.Drawing.Point(11, 111)
        Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblParentIdNo.Name = "lblParentIdNo"
        Me.lblParentIdNo.Size = New System.Drawing.Size(232, 23)
        Me.lblParentIdNo.TabIndex = 161
        Me.lblParentIdNo.Text = "Parent Cost Center"
        Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacParentIdNo
        '
        Me.cacParentIdNo.BackColor = System.Drawing.Color.White
        Me.cacParentIdNo.ChangingSearchValueOnly = false
        Me.cacParentIdNo.CurrentSearchTerm = ""
        Me.cacParentIdNo.DefaultValue = Nothing
        Me.cacParentIdNo.DisplayMember = "Name"
        Me.cacParentIdNo.DropDownHeight = 1
        Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacParentIdNo.EditingMode = true
        Me.cacParentIdNo.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, true)
        Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = true
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacParentIdNo.IntegralHeight = false
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Location = New System.Drawing.Point(245, 111)
        Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacParentIdNo.Name = "cacParentIdNo"
        Me.cacParentIdNo.OldValue = 0
        Me.cacParentIdNo.OriginalDataSource = Nothing
        Me.cacParentIdNo.OriginalList = Nothing
        Me.cacParentIdNo.OverrideDropDownStyleList = false
        Me.cacParentIdNo.PreviousSearchTerm = Nothing
        Me.cacParentIdNo.PreviousSelectedIndex = -1
        Me.cacParentIdNo.PropertySelector = Nothing
        Me.cacParentIdNo.ReadOnlyCombo = false
        Me.cacParentIdNo.SearchAnywhere = false
        Me.cacParentIdNo.Size = New System.Drawing.Size(418, 24)
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TabIndex = 3
        Me.cacParentIdNo.TextToSearch = Nothing
        Me.cacParentIdNo.ValueIsMandatory = false
        Me.cacParentIdNo.ValueIsNullable = false
        Me.cacParentIdNo.ValueIsNumeric = false
        Me.cacParentIdNo.ValueMember = "IdNo"
        '
        'lblLevelNumber
        '
        Me.lblLevelNumber.DisplayOnly = true
        Me.lblLevelNumber.EditingMode = false
        Me.lblLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblLevelNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLevelNumber.Location = New System.Drawing.Point(11, 137)
        Me.lblLevelNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLevelNumber.Name = "lblLevelNumber"
        Me.lblLevelNumber.Size = New System.Drawing.Size(232, 26)
        Me.lblLevelNumber.TabIndex = 160
        Me.lblLevelNumber.Text = "Level"
        Me.lblLevelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
        Me.txtLevelNumber.IgnoreNullCheck = true
        Me.txtLevelNumber.LinkedLabel = Me.lblLevelNumber
        Me.txtLevelNumber.Location = New System.Drawing.Point(245, 137)
        Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtLevelNumber.Name = "txtLevelNumber"
        Me.txtLevelNumber.OldValue = Nothing
        Me.txtLevelNumber.ReadOnly = true
        Me.txtLevelNumber.Size = New System.Drawing.Size(72, 23)
        Me.txtLevelNumber.TabIndex = 4
        Me.txtLevelNumber.ValueIsMandatory = true
        '
        'lblProfitCenterIdNo
        '
        Me.lblProfitCenterIdNo.DisplayOnly = true
        Me.lblProfitCenterIdNo.EditingMode = false
        Me.lblProfitCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblProfitCenterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProfitCenterIdNo.Location = New System.Drawing.Point(11, 165)
        Me.lblProfitCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProfitCenterIdNo.Name = "lblProfitCenterIdNo"
        Me.lblProfitCenterIdNo.Size = New System.Drawing.Size(232, 23)
        Me.lblProfitCenterIdNo.TabIndex = 166
        Me.lblProfitCenterIdNo.Text = "Profit Center Link"
        Me.lblProfitCenterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacProfitCenterIdNo
        '
        Me.cacProfitCenterIdNo.BackColor = System.Drawing.Color.White
        Me.cacProfitCenterIdNo.ChangingSearchValueOnly = false
        Me.cacProfitCenterIdNo.CurrentSearchTerm = ""
        Me.cacProfitCenterIdNo.DefaultValue = Nothing
        Me.cacProfitCenterIdNo.DisplayMember = "Name"
        Me.cacProfitCenterIdNo.DropDownHeight = 1
        Me.cacProfitCenterIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacProfitCenterIdNo.EditingMode = true
        Me.cacProfitCenterIdNo.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacProfitCenterIdNo, true)
        Me.cacProfitCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacProfitCenterIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacProfitCenterIdNo.FormattingEnabled = true
        Me.cacProfitCenterIdNo.HideWhenNotEditingOrAdding = false
        Me.cacProfitCenterIdNo.IntegralHeight = false
        Me.cacProfitCenterIdNo.LinkedLabel = Nothing
        Me.cacProfitCenterIdNo.Location = New System.Drawing.Point(245, 165)
        Me.cacProfitCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacProfitCenterIdNo.Name = "cacProfitCenterIdNo"
        Me.cacProfitCenterIdNo.OldValue = 0
        Me.cacProfitCenterIdNo.OriginalDataSource = Nothing
        Me.cacProfitCenterIdNo.OriginalList = Nothing
        Me.cacProfitCenterIdNo.OverrideDropDownStyleList = false
        Me.cacProfitCenterIdNo.PreviousSearchTerm = Nothing
        Me.cacProfitCenterIdNo.PreviousSelectedIndex = -1
        Me.cacProfitCenterIdNo.PropertySelector = Nothing
        Me.cacProfitCenterIdNo.ReadOnlyCombo = false
        Me.cacProfitCenterIdNo.SearchAnywhere = false
        Me.cacProfitCenterIdNo.Size = New System.Drawing.Size(418, 24)
        Me.cacProfitCenterIdNo.SuggestBoxHeight = 200
        Me.cacProfitCenterIdNo.SuggestListOrderRule = Nothing
        Me.cacProfitCenterIdNo.TabIndex = 5
        Me.cacProfitCenterIdNo.TextToSearch = Nothing
        Me.cacProfitCenterIdNo.ValueIsMandatory = false
        Me.cacProfitCenterIdNo.ValueIsNullable = false
        Me.cacProfitCenterIdNo.ValueIsNumeric = false
        Me.cacProfitCenterIdNo.ValueMember = "IdNo"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.Location = New System.Drawing.Point(11, 191)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(232, 23)
        Me.lblNotes.TabIndex = 159
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSortKey
        '
        Me.txtSortKey.BackColor = System.Drawing.Color.White
        Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSortKey.ComputedValue = false
        Me.txtSortKey.CustomFormat = Nothing
        Me.txtSortKey.DataBoundControl = true
        Me.txtSortKey.EditingMode = false
        Me.txtSortKey.Enabled = false
        Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSortKey.ForeColor = System.Drawing.Color.Black
        Me.txtSortKey.LinkedLabel = Nothing
        Me.txtSortKey.Location = New System.Drawing.Point(13, 256)
        Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
        Me.txtSortKey.TabIndex = 164
        Me.txtSortKey.ValueIsMandatory = true
        Me.txtSortKey.Visible = false
        '
        'CostCenterEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(979, 315)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "CostCenterEntryTv"
        Me.Text = "CostCenters Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtCostCenterCode As CTextBox
        Friend WithEvents txtCostCenterName As CTextBox
        Friend WithEvents txtCostCenterNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCostCenterCode As CLabel
        Friend WithEvents lblCostCenterName As CLabel
        Friend WithEvents lblCostCenterNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBCostCenterCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents lblProfitCenterIdNo As CLabel
        Friend WithEvents cacProfitCenterIdNo As CaComboBox
    End Class
End Namespace