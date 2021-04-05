Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RevCostCenterEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevCostCenterEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevCostCenterCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevCostCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevCostCenterCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevCostCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacRcType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 258)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 258)
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
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.Editable = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(213, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtRevCostCenterCode
            '
            Me.txtRevCostCenterCode.BackColor = System.Drawing.Color.White
            Me.txtRevCostCenterCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevCostCenterCode.ComputedValue = False
            Me.txtRevCostCenterCode.CustomFormat = Nothing
            Me.txtRevCostCenterCode.DataBoundControl = True
            Me.txtRevCostCenterCode.EditingMode = False
            Me.txtRevCostCenterCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevCostCenterCode, True)
            Me.txtRevCostCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevCostCenterCode.ForeColor = System.Drawing.Color.Black
            Me.txtRevCostCenterCode.LinkedLabel = Nothing
            Me.txtRevCostCenterCode.Location = New System.Drawing.Point(213, 36)
            Me.txtRevCostCenterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevCostCenterCode.MaximumValue = Nothing
            Me.txtRevCostCenterCode.MinimumValue = Nothing
            Me.txtRevCostCenterCode.Name = "txtRevCostCenterCode"
            Me.txtRevCostCenterCode.OldValue = Nothing
            Me.txtRevCostCenterCode.ReadOnly = True
            Me.txtRevCostCenterCode.Size = New System.Drawing.Size(62, 23)
            Me.txtRevCostCenterCode.TabIndex = 0
            Me.txtRevCostCenterCode.ValueIsMandatory = True
            '
            'txtRevCostCenterName
            '
            Me.txtRevCostCenterName.BackColor = System.Drawing.Color.White
            Me.txtRevCostCenterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevCostCenterName.ComputedValue = False
            Me.txtRevCostCenterName.CustomFormat = Nothing
            Me.txtRevCostCenterName.DataBoundControl = True
            Me.txtRevCostCenterName.EditingMode = False
            Me.txtRevCostCenterName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevCostCenterName, True)
            Me.txtRevCostCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevCostCenterName.ForeColor = System.Drawing.Color.Black
            Me.txtRevCostCenterName.LinkedLabel = Nothing
            Me.txtRevCostCenterName.Location = New System.Drawing.Point(213, 61)
            Me.txtRevCostCenterName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevCostCenterName.MaximumValue = Nothing
            Me.txtRevCostCenterName.MinimumValue = Nothing
            Me.txtRevCostCenterName.Name = "txtRevCostCenterName"
            Me.txtRevCostCenterName.OldValue = Nothing
            Me.txtRevCostCenterName.ReadOnly = True
            Me.txtRevCostCenterName.Size = New System.Drawing.Size(418, 23)
            Me.txtRevCostCenterName.TabIndex = 1
            Me.txtRevCostCenterName.ValueIsMandatory = True
            '
            'txtRevCostCenterNameAra
            '
            Me.txtRevCostCenterNameAra.BackColor = System.Drawing.Color.White
            Me.txtRevCostCenterNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevCostCenterNameAra.ComputedValue = False
            Me.txtRevCostCenterNameAra.CustomFormat = Nothing
            Me.txtRevCostCenterNameAra.DataBoundControl = True
            Me.txtRevCostCenterNameAra.EditingMode = False
            Me.txtRevCostCenterNameAra.EnglishControl = Me.txtRevCostCenterName
            Me.txtRevCostCenterNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevCostCenterNameAra, True)
            Me.txtRevCostCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevCostCenterNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtRevCostCenterNameAra.LinkedLabel = Nothing
            Me.txtRevCostCenterNameAra.Location = New System.Drawing.Point(213, 86)
            Me.txtRevCostCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevCostCenterNameAra.MaximumValue = Nothing
            Me.txtRevCostCenterNameAra.MinimumValue = Nothing
            Me.txtRevCostCenterNameAra.Name = "txtRevCostCenterNameAra"
            Me.txtRevCostCenterNameAra.OldValue = Nothing
            Me.txtRevCostCenterNameAra.ReadOnly = True
            Me.txtRevCostCenterNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtRevCostCenterNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtRevCostCenterNameAra.TabIndex = 2
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(213, 191)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 6
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblRevCostCenterCode)
            Me.floDataDisplay.Controls.Add(Me.txtRevCostCenterCode)
            Me.floDataDisplay.Controls.Add(Me.lblRevCostCenterName)
            Me.floDataDisplay.Controls.Add(Me.txtRevCostCenterName)
            Me.floDataDisplay.Controls.Add(Me.lblRevCostCenterNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtRevCostCenterNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.lblRevCostCenterIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacRcType)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.txtSortKey)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(654, 257)
            Me.floDataDisplay.TabIndex = 147
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(200, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevCostCenterCode
            '
            Me.lblRevCostCenterCode.DisplayOnly = True
            Me.lblRevCostCenterCode.EditingMode = False
            Me.lblRevCostCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevCostCenterCode.Location = New System.Drawing.Point(11, 36)
            Me.lblRevCostCenterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevCostCenterCode.Name = "lblRevCostCenterCode"
            Me.lblRevCostCenterCode.Size = New System.Drawing.Size(200, 23)
            Me.lblRevCostCenterCode.TabIndex = 156
            Me.lblRevCostCenterCode.Text = "Code"
            Me.lblRevCostCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevCostCenterName
            '
            Me.lblRevCostCenterName.DisplayOnly = True
            Me.lblRevCostCenterName.EditingMode = False
            Me.lblRevCostCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevCostCenterName.Location = New System.Drawing.Point(11, 61)
            Me.lblRevCostCenterName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevCostCenterName.Name = "lblRevCostCenterName"
            Me.lblRevCostCenterName.Size = New System.Drawing.Size(200, 23)
            Me.lblRevCostCenterName.TabIndex = 157
            Me.lblRevCostCenterName.Text = "Name"
            Me.lblRevCostCenterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevCostCenterNameAra
            '
            Me.lblRevCostCenterNameAra.DisplayOnly = True
            Me.lblRevCostCenterNameAra.EditingMode = False
            Me.lblRevCostCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevCostCenterNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblRevCostCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevCostCenterNameAra.Name = "lblRevCostCenterNameAra"
            Me.lblRevCostCenterNameAra.Size = New System.Drawing.Size(200, 23)
            Me.lblRevCostCenterNameAra.TabIndex = 158
            Me.lblRevCostCenterNameAra.Text = "Name (Arabic)"
            Me.lblRevCostCenterNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(11, 111)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(200, 23)
            Me.lblParentIdNo.TabIndex = 161
            Me.lblParentIdNo.Text = "Parent "
            Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.EditingMode = True
            Me.cacParentIdNo.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, True)
            Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.IntegralHeight = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Location = New System.Drawing.Point(213, 111)
            Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.SearchPlace = "1"
            Me.cacParentIdNo.SearchField = Nothing
            Me.cacParentIdNo.Size = New System.Drawing.Size(418, 24)
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TabIndex = 3
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblLevelNumber
            '
            Me.lblLevelNumber.DisplayOnly = True
            Me.lblLevelNumber.EditingMode = False
            Me.lblLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblLevelNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblLevelNumber.Location = New System.Drawing.Point(11, 137)
            Me.lblLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblLevelNumber.Name = "lblLevelNumber"
            Me.lblLevelNumber.Size = New System.Drawing.Size(200, 26)
            Me.lblLevelNumber.TabIndex = 160
            Me.lblLevelNumber.Text = "Level"
            Me.lblLevelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLevelNumber
            '
            Me.txtLevelNumber.BackColor = System.Drawing.Color.White
            Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLevelNumber.ComputedValue = False
            Me.txtLevelNumber.CustomFormat = Nothing
            Me.txtLevelNumber.DataBoundControl = True
            Me.txtLevelNumber.DisplayOnly = True
            Me.txtLevelNumber.EditingMode = True
            Me.txtLevelNumber.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, True)
            Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
            Me.txtLevelNumber.IgnoreNullCheck = True
            Me.txtLevelNumber.LinkedLabel = Me.lblLevelNumber
            Me.txtLevelNumber.Location = New System.Drawing.Point(213, 137)
            Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLevelNumber.MaximumValue = Nothing
            Me.txtLevelNumber.MinimumValue = Nothing
            Me.txtLevelNumber.Name = "txtLevelNumber"
            Me.txtLevelNumber.OldValue = Nothing
            Me.txtLevelNumber.ReadOnly = True
            Me.txtLevelNumber.Size = New System.Drawing.Size(72, 23)
            Me.txtLevelNumber.TabIndex = 4
            Me.txtLevelNumber.ValueIsMandatory = True
            Me.txtLevelNumber.ValueIsNumeric = True
            '
            'lblRevCostCenterIdNo
            '
            Me.lblRevCostCenterIdNo.DisplayOnly = True
            Me.lblRevCostCenterIdNo.EditingMode = False
            Me.lblRevCostCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevCostCenterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblRevCostCenterIdNo.Location = New System.Drawing.Point(11, 165)
            Me.lblRevCostCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevCostCenterIdNo.Name = "lblRevCostCenterIdNo"
            Me.lblRevCostCenterIdNo.Size = New System.Drawing.Size(200, 23)
            Me.lblRevCostCenterIdNo.TabIndex = 166
            Me.lblRevCostCenterIdNo.Text = "Revenue or Cost Center?"
            Me.lblRevCostCenterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacRcType
            '
            Me.cacRcType.BackColor = System.Drawing.Color.White
            Me.cacRcType.ChangingSearchValueOnly = False
            Me.cacRcType.CurrentSearchTerm = ""
            Me.cacRcType.DefaultValue = Nothing
            Me.cacRcType.DisplayMember = "Name"
            Me.cacRcType.EditingMode = True
            Me.cacRcType.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacRcType, True)
            Me.cacRcType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacRcType.ForeColor = System.Drawing.Color.Black
            Me.cacRcType.FormattingEnabled = True
            Me.cacRcType.HideWhenNotEditingOrAdding = False
            Me.cacRcType.IntegralHeight = False
            Me.cacRcType.LinkedLabel = Nothing
            Me.cacRcType.Location = New System.Drawing.Point(213, 165)
            Me.cacRcType.Margin = New System.Windows.Forms.Padding(1)
            Me.cacRcType.Name = "cacRcType"
            Me.cacRcType.OldValue = 0
            Me.cacRcType.OriginalDataSource = Nothing
            Me.cacRcType.OriginalList = Nothing
            Me.cacRcType.OverrideDropDownStyleList = False
            Me.cacRcType.PreviousSearchTerm = Nothing
            Me.cacRcType.PreviousSelectedIndex = -1
            Me.cacRcType.PropertySelector = Nothing
            Me.cacRcType.ReadOnlyCombo = False
            Me.cacRcType.SearchPlace = "1"
            Me.cacRcType.SearchField = Nothing
            Me.cacRcType.Size = New System.Drawing.Size(191, 24)
            Me.cacRcType.SuggestBoxHeight = 200
            Me.cacRcType.SuggestListOrderRule = Nothing
            Me.cacRcType.TabIndex = 5
            Me.cacRcType.TextToSearch = Nothing
            Me.cacRcType.ValueIsMandatory = False
            Me.cacRcType.ValueIsNullable = False
            Me.cacRcType.ValueIsNumeric = False
            Me.cacRcType.ValueMember = "Code"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(11, 191)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(200, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSortKey
            '
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.CustomFormat = Nothing
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.EditingMode = False
            Me.txtSortKey.Enabled = False
            Me.txtSortKey.FindEnabled = False
            Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
        Me.txtSortKey.LinkedLabel = Nothing
        Me.txtSortKey.Location = New System.Drawing.Point(13, 256)
        Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSortKey.MaximumValue = Nothing
        Me.txtSortKey.MinimumValue = Nothing
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.ReadOnly = true
        Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
        Me.txtSortKey.TabIndex = 164
        Me.txtSortKey.ValueIsMandatory = true
        Me.txtSortKey.Visible = false
        '
        'RevCostCenterEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(955, 310)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "RevCostCenterEntryTv"
        Me.Text = "Revenue/Cost Centers Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtRevCostCenterCode As CTextBox
        Friend WithEvents txtRevCostCenterName As CTextBox
        Friend WithEvents txtRevCostCenterNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblRevCostCenterCode As CLabel
        Friend WithEvents lblRevCostCenterName As CLabel
        Friend WithEvents lblRevCostCenterNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBRevCostCenterCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents lblRevCostCenterIdNo As CLabel
        Friend WithEvents cacRcType As CaComboBox
    End Class
End Namespace