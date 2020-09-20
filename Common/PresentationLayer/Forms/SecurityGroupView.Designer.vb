Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SecurityGroupView
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.DataGridViewGroupAccesses = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.DgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DgvSecurityGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DgvSecurityObjectIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DgvSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DgvVisible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DgvEditable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsGroupAccesses = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridViewGroupAccesses,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsGroupAccesses,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(17, 13)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(219, 23)
        Me.lblIdNo.TabIndex = 184
        Me.lblIdNo.Text = "SecurityGroup ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(238, 13)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 179
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblSecurityGroupCode
        '
        Me.lblSecurityGroupCode.DisplayOnly = true
        Me.lblSecurityGroupCode.EditingMode = false
        Me.lblSecurityGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupCode.Location = New System.Drawing.Point(17, 38)
        Me.lblSecurityGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSecurityGroupCode.Name = "lblSecurityGroupCode"
        Me.lblSecurityGroupCode.Size = New System.Drawing.Size(219, 23)
        Me.lblSecurityGroupCode.TabIndex = 185
        Me.lblSecurityGroupCode.Text = "SecurityGroup Code"
        Me.lblSecurityGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSecurityGroupCode
        '
        Me.txtSecurityGroupCode.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupCode.ComputedValue = false
        Me.txtSecurityGroupCode.CustomFormat = Nothing
        Me.txtSecurityGroupCode.DataBoundControl = true
        Me.txtSecurityGroupCode.EditingMode = false
        Me.txtSecurityGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSecurityGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupCode.LinkedLabel = Nothing
        Me.txtSecurityGroupCode.Location = New System.Drawing.Point(238, 38)
        Me.txtSecurityGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSecurityGroupCode.MaximumValue = Nothing
        Me.txtSecurityGroupCode.MinimumValue = Nothing
        Me.txtSecurityGroupCode.Name = "txtSecurityGroupCode"
        Me.txtSecurityGroupCode.OldValue = Nothing
        Me.txtSecurityGroupCode.ReadOnly = true
        Me.txtSecurityGroupCode.Size = New System.Drawing.Size(62, 23)
        Me.txtSecurityGroupCode.TabIndex = 180
        Me.txtSecurityGroupCode.ValueIsMandatory = true
        '
        'lblSecurityGroupName
        '
        Me.lblSecurityGroupName.DisplayOnly = true
        Me.lblSecurityGroupName.EditingMode = false
        Me.lblSecurityGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupName.Location = New System.Drawing.Point(17, 63)
        Me.lblSecurityGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSecurityGroupName.Name = "lblSecurityGroupName"
        Me.lblSecurityGroupName.Size = New System.Drawing.Size(219, 23)
        Me.lblSecurityGroupName.TabIndex = 186
        Me.lblSecurityGroupName.Text = "SecurityGroup Name"
        Me.lblSecurityGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSecurityGroupName
        '
        Me.txtSecurityGroupName.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupName.ComputedValue = false
        Me.txtSecurityGroupName.CustomFormat = Nothing
        Me.txtSecurityGroupName.DataBoundControl = true
        Me.txtSecurityGroupName.EditingMode = true
        Me.txtSecurityGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSecurityGroupName.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupName.LinkedLabel = Nothing
        Me.txtSecurityGroupName.Location = New System.Drawing.Point(238, 63)
        Me.txtSecurityGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSecurityGroupName.MaximumValue = Nothing
        Me.txtSecurityGroupName.MinimumValue = Nothing
        Me.txtSecurityGroupName.Name = "txtSecurityGroupName"
        Me.txtSecurityGroupName.OldValue = Nothing
        Me.txtSecurityGroupName.ReadOnly = true
        Me.txtSecurityGroupName.Size = New System.Drawing.Size(437, 23)
        Me.txtSecurityGroupName.TabIndex = 181
        Me.txtSecurityGroupName.ValueIsMandatory = true
        '
        'lblSecurityGroupNameAra
        '
        Me.lblSecurityGroupNameAra.DisplayOnly = true
        Me.lblSecurityGroupNameAra.EditingMode = false
        Me.lblSecurityGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupNameAra.Location = New System.Drawing.Point(17, 88)
        Me.lblSecurityGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSecurityGroupNameAra.Name = "lblSecurityGroupNameAra"
        Me.lblSecurityGroupNameAra.Size = New System.Drawing.Size(219, 23)
        Me.lblSecurityGroupNameAra.TabIndex = 187
        Me.lblSecurityGroupNameAra.Text = "SecurityGroup Name (Arabic)"
        Me.lblSecurityGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSecurityGroupNameAra
        '
        Me.txtSecurityGroupNameAra.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupNameAra.ComputedValue = false
        Me.txtSecurityGroupNameAra.CustomFormat = Nothing
        Me.txtSecurityGroupNameAra.DataBoundControl = true
        Me.txtSecurityGroupNameAra.DisplayOnly = true
        Me.txtSecurityGroupNameAra.EditingMode = true
        Me.txtSecurityGroupNameAra.EnglishControl = Me.txtSecurityGroupName
        Me.txtSecurityGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSecurityGroupNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupNameAra.LinkedLabel = Nothing
        Me.txtSecurityGroupNameAra.Location = New System.Drawing.Point(238, 88)
        Me.txtSecurityGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSecurityGroupNameAra.MaximumValue = Nothing
        Me.txtSecurityGroupNameAra.MinimumValue = Nothing
        Me.txtSecurityGroupNameAra.Name = "txtSecurityGroupNameAra"
        Me.txtSecurityGroupNameAra.OldValue = Nothing
        Me.txtSecurityGroupNameAra.ReadOnly = true
        Me.txtSecurityGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSecurityGroupNameAra.Size = New System.Drawing.Size(437, 23)
        Me.txtSecurityGroupNameAra.TabIndex = 182
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParentIdNo.Location = New System.Drawing.Point(16, 112)
        Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblParentIdNo.Name = "lblParentIdNo"
        Me.lblParentIdNo.Size = New System.Drawing.Size(220, 24)
        Me.lblParentIdNo.TabIndex = 190
        Me.lblParentIdNo.Text = "Parent Account"
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
        Me.cacParentIdNo.EditingMode = false
        Me.cacParentIdNo.FilterRule = Nothing
        Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = true
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacParentIdNo.IntegralHeight = false
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Location = New System.Drawing.Point(237, 113)
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
        Me.cacParentIdNo.Size = New System.Drawing.Size(438, 24)
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TabIndex = 189
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
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(17, 139)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(219, 23)
        Me.lblNotes.TabIndex = 188
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(238, 139)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.Size = New System.Drawing.Size(437, 60)
        Me.txtNotes.TabIndex = 183
        Me.txtNotes.ValueIsMandatory = True
            '
            'DataGridViewGroupAccesses
            '
            Me.DataGridViewGroupAccesses.AllowUserToAddRows = False
            Me.DataGridViewGroupAccesses.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewGroupAccesses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewGroupAccesses.AutoGenerateColumns = False
            Me.DataGridViewGroupAccesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewGroupAccesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvIdNo, Me.DgvSecurityGroupIdNo, Me.DgvSecurityObjectIdNo, Me.DgvSecurityObjectName, Me.DgvVisible, Me.DgvEditable})
            Me.DataGridViewGroupAccesses.DataInGridChanged = False
            Me.DataGridViewGroupAccesses.DataSource = Me.bsGroupAccesses
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewGroupAccesses.DefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewGroupAccesses.DisplayOnly = False
            Me.DataGridViewGroupAccesses.Ea = Nothing
            Me.DataGridViewGroupAccesses.EditingMode = False
            Me.DataGridViewGroupAccesses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewGroupAccesses.FirstRowDeletionEnabled = False
            Me.DataGridViewGroupAccesses.FirstRowInsertionEnabled = False
            Me.DataGridViewGroupAccesses.Location = New System.Drawing.Point(20, 203)
            Me.DataGridViewGroupAccesses.Name = "DataGridViewGroupAccesses"
            Me.DataGridViewGroupAccesses.ReadOnly = True
            Me.DataGridViewGroupAccesses.SequenceColumn = "dgvSequence"
            Me.DataGridViewGroupAccesses.ShowInsertColumnWhenEditing = False
            Me.DataGridViewGroupAccesses.Size = New System.Drawing.Size(655, 368)
            Me.DataGridViewGroupAccesses.StartTrackingChanges = false
        Me.DataGridViewGroupAccesses.TabIndex = 178
        '
        'DgvIdNo
        '
        Me.DgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvIdNo.EditingMode = false
        Me.DgvIdNo.HeaderText = "IdNo"
        Me.DgvIdNo.Name = "DgvIdNo"
        Me.DgvIdNo.ReadOnly = true
        Me.DgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvIdNo.Visible = false
        '
        'DgvSecurityGroupIdNo
        '
        Me.DgvSecurityGroupIdNo.DataPropertyName = "SecurityGroupIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DgvSecurityGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvSecurityGroupIdNo.EditingMode = false
        Me.DgvSecurityGroupIdNo.HeaderText = "SecurityGroupIdNo"
        Me.DgvSecurityGroupIdNo.Name = "DgvSecurityGroupIdNo"
        Me.DgvSecurityGroupIdNo.ReadOnly = true
        Me.DgvSecurityGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSecurityGroupIdNo.Visible = false
        '
        'DgvSecurityObjectIdNo
        '
        Me.DgvSecurityObjectIdNo.DataPropertyName = "SecurityObjectIdNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DgvSecurityObjectIdNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvSecurityObjectIdNo.EditingMode = false
        Me.DgvSecurityObjectIdNo.HeaderText = "SecurityObjectIdNo"
        Me.DgvSecurityObjectIdNo.Name = "DgvSecurityObjectIdNo"
        Me.DgvSecurityObjectIdNo.ReadOnly = true
        Me.DgvSecurityObjectIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSecurityObjectIdNo.Visible = false
        '
        'DgvSecurityObjectName
        '
        Me.DgvSecurityObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DgvSecurityObjectName.DataPropertyName = "SecurityObjectName"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DgvSecurityObjectName.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvSecurityObjectName.EditingMode = false
        Me.DgvSecurityObjectName.HeaderText = "SecurityObjectName"
        Me.DgvSecurityObjectName.Name = "DgvSecurityObjectName"
        Me.DgvSecurityObjectName.ReadOnly = true
        Me.DgvSecurityObjectName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DgvVisible
        '
        Me.DgvVisible.DataPropertyName = "Visible"
        Me.DgvVisible.HeaderText = "Visible"
        Me.DgvVisible.Name = "DgvVisible"
        Me.DgvVisible.ReadOnly = true
        Me.DgvVisible.Width = 50
        '
        'DgvEditable
        '
        Me.DgvEditable.DataPropertyName = "Editable"
        Me.DgvEditable.HeaderText = "Editable"
        Me.DgvEditable.Name = "DgvEditable"
        Me.DgvEditable.ReadOnly = true
        Me.DgvEditable.Width = 50
        '
        'bsGroupAccesses
        '
        Me.bsGroupAccesses.DataSource = GetType(AATM.Common.PresentationLayer.Models.GroupAccessModel)
        '
        'SecurityGroupView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblIdNo)
        Me.Controls.Add(Me.TxtIdNo)
        Me.Controls.Add(Me.lblSecurityGroupCode)
        Me.Controls.Add(Me.txtSecurityGroupCode)
        Me.Controls.Add(Me.lblSecurityGroupName)
        Me.Controls.Add(Me.txtSecurityGroupName)
        Me.Controls.Add(Me.lblSecurityGroupNameAra)
        Me.Controls.Add(Me.txtSecurityGroupNameAra)
        Me.Controls.Add(Me.lblParentIdNo)
        Me.Controls.Add(Me.cacParentIdNo)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.DataGridViewGroupAccesses)
        Me.Name = "SecurityGroupView"
        Me.Size = New System.Drawing.Size(694, 591)
        CType(Me.DataGridViewGroupAccesses,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsGroupAccesses,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSecurityGroupCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSecurityGroupCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSecurityGroupName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSecurityGroupName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSecurityGroupNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSecurityGroupNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents lblParentIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacParentIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents DataGridViewGroupAccesses As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents bsGroupAccesses As Windows.Forms.BindingSource
        Friend WithEvents DgvIdNo As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents DgvSecurityGroupIdNo As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents DgvSecurityObjectIdNo As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents DgvSecurityObjectName As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents DgvVisible As DataGridViewCheckBoxColumn
        Friend WithEvents DgvEditable As DataGridViewCheckBoxColumn
    End Class
End NameSpace