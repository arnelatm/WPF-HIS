Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PayGroupEntry
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
        Me.txtPayGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPayGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPayGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacRcType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
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
        Me.TxtIdNo.Editable = true
        Me.TxtIdNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(213, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtPayGroupCode
        '
        Me.txtPayGroupCode.BackColor = System.Drawing.Color.White
        Me.txtPayGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayGroupCode.ComputedValue = false
        Me.txtPayGroupCode.CustomFormat = Nothing
        Me.txtPayGroupCode.DataBoundControl = true
        Me.txtPayGroupCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupCode, true)
        Me.txtPayGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupCode.LinkedLabel = Nothing
        Me.txtPayGroupCode.Location = New System.Drawing.Point(213, 36)
        Me.txtPayGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayGroupCode.MaximumValue = Nothing
        Me.txtPayGroupCode.MinimumValue = Nothing
        Me.txtPayGroupCode.Name = "txtPayGroupCode"
        Me.txtPayGroupCode.OldValue = Nothing
        Me.txtPayGroupCode.ReadOnly = true
        Me.txtPayGroupCode.Size = New System.Drawing.Size(62, 23)
        Me.txtPayGroupCode.TabIndex = 0
        Me.txtPayGroupCode.ValueIsMandatory = true
        '
        'txtPayGroupName
        '
        Me.txtPayGroupName.BackColor = System.Drawing.Color.White
        Me.txtPayGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayGroupName.ComputedValue = false
        Me.txtPayGroupName.CustomFormat = Nothing
        Me.txtPayGroupName.DataBoundControl = true
        Me.txtPayGroupName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupName, true)
        Me.txtPayGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayGroupName.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupName.LinkedLabel = Nothing
        Me.txtPayGroupName.Location = New System.Drawing.Point(213, 61)
        Me.txtPayGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayGroupName.MaximumValue = Nothing
        Me.txtPayGroupName.MinimumValue = Nothing
        Me.txtPayGroupName.Name = "txtPayGroupName"
        Me.txtPayGroupName.OldValue = Nothing
        Me.txtPayGroupName.ReadOnly = true
        Me.txtPayGroupName.Size = New System.Drawing.Size(418, 23)
        Me.txtPayGroupName.TabIndex = 1
        Me.txtPayGroupName.ValueIsMandatory = true
        '
        'txtPayGroupNameAra
        '
        Me.txtPayGroupNameAra.BackColor = System.Drawing.Color.White
        Me.txtPayGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayGroupNameAra.ComputedValue = false
        Me.txtPayGroupNameAra.CustomFormat = Nothing
        Me.txtPayGroupNameAra.DataBoundControl = true
        Me.txtPayGroupNameAra.EditingMode = false
        Me.txtPayGroupNameAra.EnglishControl = Me.txtPayGroupName
        Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupNameAra, true)
        Me.txtPayGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayGroupNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupNameAra.LinkedLabel = Nothing
        Me.txtPayGroupNameAra.Location = New System.Drawing.Point(213, 86)
        Me.txtPayGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayGroupNameAra.MaximumValue = Nothing
        Me.txtPayGroupNameAra.MinimumValue = Nothing
        Me.txtPayGroupNameAra.Name = "txtPayGroupNameAra"
        Me.txtPayGroupNameAra.OldValue = Nothing
        Me.txtPayGroupNameAra.ReadOnly = true
        Me.txtPayGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPayGroupNameAra.Size = New System.Drawing.Size(418, 23)
        Me.txtPayGroupNameAra.TabIndex = 2
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
        Me.txtNotes.Location = New System.Drawing.Point(213, 191)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
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
        Me.floDataDisplay.Controls.Add(Me.lblPayGroupCode)
        Me.floDataDisplay.Controls.Add(Me.txtPayGroupCode)
        Me.floDataDisplay.Controls.Add(Me.lblPayGroupName)
        Me.floDataDisplay.Controls.Add(Me.txtPayGroupName)
        Me.floDataDisplay.Controls.Add(Me.lblPayGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtPayGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.lblPayGroupIdNo)
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(200, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayGroupCode
        '
        Me.lblPayGroupCode.DisplayOnly = true
        Me.lblPayGroupCode.EditingMode = false
        Me.lblPayGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayGroupCode.Location = New System.Drawing.Point(11, 36)
        Me.lblPayGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayGroupCode.Name = "lblPayGroupCode"
        Me.lblPayGroupCode.Size = New System.Drawing.Size(200, 23)
        Me.lblPayGroupCode.TabIndex = 156
        Me.lblPayGroupCode.Text = "Code"
        Me.lblPayGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayGroupName
        '
        Me.lblPayGroupName.DisplayOnly = true
        Me.lblPayGroupName.EditingMode = false
        Me.lblPayGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayGroupName.Location = New System.Drawing.Point(11, 61)
        Me.lblPayGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayGroupName.Name = "lblPayGroupName"
        Me.lblPayGroupName.Size = New System.Drawing.Size(200, 23)
        Me.lblPayGroupName.TabIndex = 157
        Me.lblPayGroupName.Text = "Name"
        Me.lblPayGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayGroupNameAra
        '
        Me.lblPayGroupNameAra.DisplayOnly = true
        Me.lblPayGroupNameAra.EditingMode = false
        Me.lblPayGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayGroupNameAra.Location = New System.Drawing.Point(11, 86)
        Me.lblPayGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayGroupNameAra.Name = "lblPayGroupNameAra"
        Me.lblPayGroupNameAra.Size = New System.Drawing.Size(200, 23)
        Me.lblPayGroupNameAra.TabIndex = 158
        Me.lblPayGroupNameAra.Text = "Name (Arabic)"
        Me.lblPayGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblParentIdNo.Size = New System.Drawing.Size(200, 23)
        Me.lblParentIdNo.TabIndex = 161
        Me.lblParentIdNo.Text = "Parent "
        Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacParentIdNo
        '
        Me.cacParentIdNo.BackColor = System.Drawing.Color.White
        Me.cacParentIdNo.ChangingSearchValueOnly = false
        Me.cacParentIdNo.CurrentSearchTerm = ""
        Me.cacParentIdNo.DefaultValue = Nothing
        Me.cacParentIdNo.DisplayMember = "Name"
        Me.cacParentIdNo.DropDownHeight = 200
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
        Me.cacParentIdNo.Location = New System.Drawing.Point(213, 111)
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
        Me.lblLevelNumber.Size = New System.Drawing.Size(200, 26)
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
        Me.txtLevelNumber.Location = New System.Drawing.Point(213, 137)
        Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtLevelNumber.MaximumValue = Nothing
        Me.txtLevelNumber.MinimumValue = Nothing
        Me.txtLevelNumber.Name = "txtLevelNumber"
        Me.txtLevelNumber.OldValue = Nothing
        Me.txtLevelNumber.ReadOnly = true
        Me.txtLevelNumber.Size = New System.Drawing.Size(72, 23)
        Me.txtLevelNumber.TabIndex = 4
        Me.txtLevelNumber.ValueIsMandatory = true
        Me.txtLevelNumber.ValueIsNumeric = true
        '
        'lblPayGroupIdNo
        '
        Me.lblPayGroupIdNo.DisplayOnly = true
        Me.lblPayGroupIdNo.EditingMode = false
        Me.lblPayGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayGroupIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayGroupIdNo.Location = New System.Drawing.Point(11, 165)
        Me.lblPayGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayGroupIdNo.Name = "lblPayGroupIdNo"
        Me.lblPayGroupIdNo.Size = New System.Drawing.Size(200, 23)
        Me.lblPayGroupIdNo.TabIndex = 166
        Me.lblPayGroupIdNo.Text = "Revenue or Cost Center?"
        Me.lblPayGroupIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacRcType
        '
        Me.cacRcType.BackColor = System.Drawing.Color.White
        Me.cacRcType.ChangingSearchValueOnly = false
        Me.cacRcType.CurrentSearchTerm = ""
        Me.cacRcType.DefaultValue = Nothing
        Me.cacRcType.DisplayMember = "Name"
        Me.cacRcType.DropDownHeight = 200
        Me.cacRcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacRcType.EditingMode = true
        Me.cacRcType.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacRcType, true)
        Me.cacRcType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacRcType.ForeColor = System.Drawing.Color.Black
        Me.cacRcType.FormattingEnabled = true
        Me.cacRcType.HideWhenNotEditingOrAdding = false
        Me.cacRcType.IntegralHeight = false
        Me.cacRcType.LinkedLabel = Nothing
        Me.cacRcType.Location = New System.Drawing.Point(213, 165)
        Me.cacRcType.Margin = New System.Windows.Forms.Padding(1)
        Me.cacRcType.Name = "cacRcType"
        Me.cacRcType.OldValue = 0
        Me.cacRcType.OriginalDataSource = Nothing
        Me.cacRcType.OriginalList = Nothing
        Me.cacRcType.OverrideDropDownStyleList = false
        Me.cacRcType.PreviousSearchTerm = Nothing
        Me.cacRcType.PreviousSelectedIndex = -1
        Me.cacRcType.PropertySelector = Nothing
        Me.cacRcType.ReadOnlyCombo = false
        Me.cacRcType.SearchAnywhere = false
        Me.cacRcType.Size = New System.Drawing.Size(191, 24)
        Me.cacRcType.SuggestBoxHeight = 200
        Me.cacRcType.SuggestListOrderRule = Nothing
        Me.cacRcType.TabIndex = 5
        Me.cacRcType.TextToSearch = Nothing
        Me.cacRcType.ValueIsMandatory = false
        Me.cacRcType.ValueIsNullable = false
        Me.cacRcType.ValueIsNumeric = false
        Me.cacRcType.ValueMember = "Code"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        'PayGroupEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(955, 310)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PayGroupEntry"
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
        Friend WithEvents txtPayGroupCode As CTextBox
        Friend WithEvents txtPayGroupName As CTextBox
        Friend WithEvents txtPayGroupNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayGroupCode As CLabel
        Friend WithEvents lblPayGroupName As CLabel
        Friend WithEvents lblPayGroupNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBPayGroupCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents lblPayGroupIdNo As CLabel
        Friend WithEvents cacRcType As CaComboBox
    End Class
End Namespace