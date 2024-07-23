Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Views
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
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewGroupAccesses = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.DgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvSecurityGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvSecurityObjectIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvVisible = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.DgvEditable = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.bsGroupAccesses = New System.Windows.Forms.BindingSource(Me.components)
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            CType(Me.DataGridViewGroupAccesses, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsGroupAccesses, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(23, 16)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(292, 28)
            Me.lblIdNo.TabIndex = 184
            Me.lblIdNo.Text = "SecurityGroup ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
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
            Me.TxtIdNo.FindEnabled = False
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(317, 16)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(82, 26)
            Me.TxtIdNo.TabIndex = 179
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblSecurityGroupCode
            '
            Me.lblSecurityGroupCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSecurityGroupCode.DisplayOnly = True
            Me.lblSecurityGroupCode.EditingMode = False
            Me.lblSecurityGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSecurityGroupCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSecurityGroupCode.Location = New System.Drawing.Point(23, 47)
            Me.lblSecurityGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSecurityGroupCode.Name = "lblSecurityGroupCode"
            Me.lblSecurityGroupCode.Size = New System.Drawing.Size(292, 28)
            Me.lblSecurityGroupCode.TabIndex = 185
            Me.lblSecurityGroupCode.Text = "SecurityGroup Code"
            Me.lblSecurityGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSecurityGroupCode.Translatable = True
            '
            'txtSecurityGroupCode
            '
            Me.txtSecurityGroupCode.BackColor = System.Drawing.Color.White
            Me.txtSecurityGroupCode.BegFindValue = Nothing
            Me.txtSecurityGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityGroupCode.ComputedValue = False
            Me.txtSecurityGroupCode.CustomFormat = Nothing
            Me.txtSecurityGroupCode.DataBoundControl = True
            Me.txtSecurityGroupCode.EditingMode = False
            Me.txtSecurityGroupCode.EndFindValue = Nothing
            Me.txtSecurityGroupCode.FieldDescription = Nothing
            Me.txtSecurityGroupCode.FieldName = Nothing
            Me.txtSecurityGroupCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityGroupCode.FindEnabled = False
            Me.txtSecurityGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSecurityGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityGroupCode.LinkedLabel = Nothing
            Me.txtSecurityGroupCode.Location = New System.Drawing.Point(317, 47)
            Me.txtSecurityGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSecurityGroupCode.MaximumValue = Nothing
            Me.txtSecurityGroupCode.MinimumValue = Nothing
            Me.txtSecurityGroupCode.Name = "txtSecurityGroupCode"
            Me.txtSecurityGroupCode.OldValue = Nothing
            Me.txtSecurityGroupCode.OverrideMaxLength = 0
            Me.txtSecurityGroupCode.ReadOnly = True
            Me.txtSecurityGroupCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityGroupCode.Size = New System.Drawing.Size(82, 26)
            Me.txtSecurityGroupCode.TabIndex = 180
            Me.txtSecurityGroupCode.Translatable = False
            Me.txtSecurityGroupCode.ValueIsMandatory = True
            '
            'lblSecurityGroupName
            '
            Me.lblSecurityGroupName.BackColor = System.Drawing.Color.Transparent
            Me.lblSecurityGroupName.DisplayOnly = True
            Me.lblSecurityGroupName.EditingMode = False
            Me.lblSecurityGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSecurityGroupName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSecurityGroupName.Location = New System.Drawing.Point(23, 78)
            Me.lblSecurityGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSecurityGroupName.Name = "lblSecurityGroupName"
            Me.lblSecurityGroupName.Size = New System.Drawing.Size(292, 28)
            Me.lblSecurityGroupName.TabIndex = 186
            Me.lblSecurityGroupName.Text = "SecurityGroup Name"
            Me.lblSecurityGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSecurityGroupName.Translatable = True
            '
            'txtSecurityGroupName
            '
            Me.txtSecurityGroupName.BackColor = System.Drawing.Color.White
            Me.txtSecurityGroupName.BegFindValue = Nothing
            Me.txtSecurityGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityGroupName.ComputedValue = False
            Me.txtSecurityGroupName.CustomFormat = Nothing
            Me.txtSecurityGroupName.DataBoundControl = True
            Me.txtSecurityGroupName.EditingMode = True
            Me.txtSecurityGroupName.EndFindValue = Nothing
            Me.txtSecurityGroupName.FieldDescription = Nothing
            Me.txtSecurityGroupName.FieldName = Nothing
            Me.txtSecurityGroupName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityGroupName.FindEnabled = False
            Me.txtSecurityGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSecurityGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityGroupName.LinkedLabel = Nothing
            Me.txtSecurityGroupName.Location = New System.Drawing.Point(317, 78)
            Me.txtSecurityGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSecurityGroupName.MaximumValue = Nothing
            Me.txtSecurityGroupName.MinimumValue = Nothing
            Me.txtSecurityGroupName.Name = "txtSecurityGroupName"
            Me.txtSecurityGroupName.OldValue = Nothing
            Me.txtSecurityGroupName.OverrideMaxLength = 0
            Me.txtSecurityGroupName.ReadOnly = True
            Me.txtSecurityGroupName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityGroupName.Size = New System.Drawing.Size(582, 26)
            Me.txtSecurityGroupName.TabIndex = 181
            Me.txtSecurityGroupName.Translatable = False
            Me.txtSecurityGroupName.ValueIsMandatory = True
            '
            'lblSecurityGroupNameAra
            '
            Me.lblSecurityGroupNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblSecurityGroupNameAra.DisplayOnly = True
            Me.lblSecurityGroupNameAra.EditingMode = False
            Me.lblSecurityGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSecurityGroupNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSecurityGroupNameAra.Location = New System.Drawing.Point(23, 108)
            Me.lblSecurityGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSecurityGroupNameAra.Name = "lblSecurityGroupNameAra"
            Me.lblSecurityGroupNameAra.Size = New System.Drawing.Size(292, 28)
            Me.lblSecurityGroupNameAra.TabIndex = 187
            Me.lblSecurityGroupNameAra.Text = "SecurityGroup Name (Arabic)"
            Me.lblSecurityGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSecurityGroupNameAra.Translatable = True
            '
            'txtSecurityGroupNameAra
            '
            Me.txtSecurityGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtSecurityGroupNameAra.BegFindValue = Nothing
            Me.txtSecurityGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityGroupNameAra.ComputedValue = False
            Me.txtSecurityGroupNameAra.CustomFormat = Nothing
            Me.txtSecurityGroupNameAra.DataBoundControl = True
            Me.txtSecurityGroupNameAra.EditingMode = True
            Me.txtSecurityGroupNameAra.EndFindValue = Nothing
            Me.txtSecurityGroupNameAra.EnglishControl = Me.txtSecurityGroupName
            Me.txtSecurityGroupNameAra.FieldDescription = Nothing
            Me.txtSecurityGroupNameAra.FieldName = Nothing
            Me.txtSecurityGroupNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSecurityGroupNameAra.FindEnabled = False
            Me.txtSecurityGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSecurityGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityGroupNameAra.LinkedLabel = Nothing
            Me.txtSecurityGroupNameAra.Location = New System.Drawing.Point(317, 108)
            Me.txtSecurityGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSecurityGroupNameAra.MaximumValue = Nothing
            Me.txtSecurityGroupNameAra.MinimumValue = Nothing
            Me.txtSecurityGroupNameAra.Name = "txtSecurityGroupNameAra"
            Me.txtSecurityGroupNameAra.OldValue = Nothing
            Me.txtSecurityGroupNameAra.OverrideMaxLength = 0
            Me.txtSecurityGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtSecurityGroupNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSecurityGroupNameAra.Size = New System.Drawing.Size(582, 26)
            Me.txtSecurityGroupNameAra.TabIndex = 182
            Me.txtSecurityGroupNameAra.Translatable = False
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(21, 138)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(0)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(293, 30)
            Me.lblParentIdNo.TabIndex = 190
            Me.lblParentIdNo.Text = "Parent Account"
            Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblParentIdNo.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(23, 171)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(292, 28)
            Me.lblNotes.TabIndex = 188
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(317, 171)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(582, 73)
            Me.txtNotes.TabIndex = 183
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'DataGridViewGroupAccesses
            '
            Me.DataGridViewGroupAccesses.AllowUserToAddRows = False
            Me.DataGridViewGroupAccesses.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewGroupAccesses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewGroupAccesses.AutoGenerateColumns = False
            Me.DataGridViewGroupAccesses.BegFindValue = Nothing
            Me.DataGridViewGroupAccesses.Cached = False
            Me.DataGridViewGroupAccesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewGroupAccesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvIdNo, Me.DgvSecurityGroupIdNo, Me.DgvSecurityObjectIdNo, Me.DgvSecurityObjectName, Me.DgvVisible, Me.DgvEditable})
            Me.DataGridViewGroupAccesses.DataFilter = Nothing
            Me.DataGridViewGroupAccesses.DataSource = Me.bsGroupAccesses
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewGroupAccesses.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewGroupAccesses.DgvFooter = Nothing
            Me.DataGridViewGroupAccesses.DisplayOnly = False
            Me.DataGridViewGroupAccesses.Ea = Nothing
            Me.DataGridViewGroupAccesses.EditingMode = False
            Me.DataGridViewGroupAccesses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewGroupAccesses.EndFindValue = Nothing
            Me.DataGridViewGroupAccesses.FieldDescription = Nothing
            Me.DataGridViewGroupAccesses.FieldName = Nothing
            Me.DataGridViewGroupAccesses.FieldsDictionary = Nothing
            Me.DataGridViewGroupAccesses.FindColumnNo = CType(0, Short)
            Me.DataGridViewGroupAccesses.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewGroupAccesses.FindEnabled = False
            Me.DataGridViewGroupAccesses.FirstRowDeletionEnabled = False
            Me.DataGridViewGroupAccesses.FirstRowInsertionEnabled = False
            Me.DataGridViewGroupAccesses.IgnoreCase = False
            Me.DataGridViewGroupAccesses.IsDirty = False
            Me.DataGridViewGroupAccesses.Location = New System.Drawing.Point(27, 250)
            Me.DataGridViewGroupAccesses.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewGroupAccesses.Name = "DataGridViewGroupAccesses"
            Me.DataGridViewGroupAccesses.ReadOnly = True
            Me.DataGridViewGroupAccesses.RowHeadersWidth = 51
            Me.DataGridViewGroupAccesses.Searchable = True
            Me.DataGridViewGroupAccesses.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewGroupAccesses.SecurityKey = ""
            Me.DataGridViewGroupAccesses.SequenceColumn = "dgvSequence"
            Me.DataGridViewGroupAccesses.SequenceFieldName = "Sequence"
            Me.DataGridViewGroupAccesses.ShowFooter = False
            Me.DataGridViewGroupAccesses.Size = New System.Drawing.Size(873, 453)
            Me.DataGridViewGroupAccesses.TabIndex = 178
            Me.DataGridViewGroupAccesses.Translatable = True
            '
            'DgvIdNo
            '
            Me.DgvIdNo.BegFindValue = Nothing
            Me.DgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.DgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.DgvIdNo.EditingMode = False
            Me.DgvIdNo.EndFindValue = Nothing
            Me.DgvIdNo.FieldDescription = Nothing
            Me.DgvIdNo.FieldName = Nothing
            Me.DgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvIdNo.FindEnabled = False
            Me.DgvIdNo.HeaderText = "IdNo"
            Me.DgvIdNo.IgnoreCase = False
            Me.DgvIdNo.MinimumWidth = 6
            Me.DgvIdNo.Name = "DgvIdNo"
            Me.DgvIdNo.ReadOnly = True
            Me.DgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvIdNo.Translatable = False
            Me.DgvIdNo.Visible = False
            Me.DgvIdNo.Width = 125
            '
            'DgvSecurityGroupIdNo
            '
            Me.DgvSecurityGroupIdNo.BegFindValue = Nothing
            Me.DgvSecurityGroupIdNo.DataPropertyName = "SecurityGroupIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.DgvSecurityGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.DgvSecurityGroupIdNo.EditingMode = False
            Me.DgvSecurityGroupIdNo.EndFindValue = Nothing
            Me.DgvSecurityGroupIdNo.FieldDescription = Nothing
            Me.DgvSecurityGroupIdNo.FieldName = Nothing
            Me.DgvSecurityGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvSecurityGroupIdNo.FindEnabled = False
            Me.DgvSecurityGroupIdNo.HeaderText = "SecurityGroupIdNo"
            Me.DgvSecurityGroupIdNo.IgnoreCase = False
            Me.DgvSecurityGroupIdNo.MinimumWidth = 6
            Me.DgvSecurityGroupIdNo.Name = "DgvSecurityGroupIdNo"
            Me.DgvSecurityGroupIdNo.ReadOnly = True
            Me.DgvSecurityGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvSecurityGroupIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvSecurityGroupIdNo.Translatable = False
            Me.DgvSecurityGroupIdNo.Visible = False
            Me.DgvSecurityGroupIdNo.Width = 125
            '
            'DgvSecurityObjectIdNo
            '
            Me.DgvSecurityObjectIdNo.BegFindValue = Nothing
            Me.DgvSecurityObjectIdNo.DataPropertyName = "SecurityObjectIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.DgvSecurityObjectIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.DgvSecurityObjectIdNo.EditingMode = False
            Me.DgvSecurityObjectIdNo.EndFindValue = Nothing
            Me.DgvSecurityObjectIdNo.FieldDescription = Nothing
            Me.DgvSecurityObjectIdNo.FieldName = Nothing
            Me.DgvSecurityObjectIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvSecurityObjectIdNo.FindEnabled = False
            Me.DgvSecurityObjectIdNo.HeaderText = "SecurityObjectIdNo"
            Me.DgvSecurityObjectIdNo.IgnoreCase = False
            Me.DgvSecurityObjectIdNo.MinimumWidth = 6
            Me.DgvSecurityObjectIdNo.Name = "DgvSecurityObjectIdNo"
            Me.DgvSecurityObjectIdNo.ReadOnly = True
            Me.DgvSecurityObjectIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvSecurityObjectIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvSecurityObjectIdNo.Translatable = False
            Me.DgvSecurityObjectIdNo.Visible = False
            Me.DgvSecurityObjectIdNo.Width = 125
            '
            'DgvSecurityObjectName
            '
            Me.DgvSecurityObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DgvSecurityObjectName.BegFindValue = Nothing
            Me.DgvSecurityObjectName.DataPropertyName = "SecurityObjectName"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.DgvSecurityObjectName.DefaultCellStyle = DataGridViewCellStyle5
            Me.DgvSecurityObjectName.EditingMode = False
            Me.DgvSecurityObjectName.EndFindValue = Nothing
            Me.DgvSecurityObjectName.FieldDescription = Nothing
            Me.DgvSecurityObjectName.FieldName = Nothing
            Me.DgvSecurityObjectName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvSecurityObjectName.FindEnabled = False
            Me.DgvSecurityObjectName.HeaderText = "SecurityObjectName"
            Me.DgvSecurityObjectName.IgnoreCase = False
            Me.DgvSecurityObjectName.MinimumWidth = 6
            Me.DgvSecurityObjectName.Name = "DgvSecurityObjectName"
            Me.DgvSecurityObjectName.ReadOnly = True
            Me.DgvSecurityObjectName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvSecurityObjectName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvSecurityObjectName.Translatable = False
            '
            'DgvVisible
            '
            Me.DgvVisible.BegFindValue = Nothing
            Me.DgvVisible.DataPropertyName = "Visible"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Orange
            DataGridViewCellStyle6.NullValue = False
            Me.DgvVisible.DefaultCellStyle = DataGridViewCellStyle6
            Me.DgvVisible.EditingMode = False
            Me.DgvVisible.EndFindValue = Nothing
            Me.DgvVisible.FieldDescription = Nothing
            Me.DgvVisible.FieldName = Nothing
            Me.DgvVisible.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvVisible.FindEnabled = False
            Me.DgvVisible.HeaderText = "Visible"
            Me.DgvVisible.IgnoreCase = False
            Me.DgvVisible.MinimumWidth = 6
            Me.DgvVisible.Name = "DgvVisible"
            Me.DgvVisible.ReadOnly = True
            Me.DgvVisible.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvVisible.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvVisible.Translatable = False
            Me.DgvVisible.Width = 50
            '
            'DgvEditable
            '
            Me.DgvEditable.BegFindValue = Nothing
            Me.DgvEditable.DataPropertyName = "Editable"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Orange
            DataGridViewCellStyle7.NullValue = False
            Me.DgvEditable.DefaultCellStyle = DataGridViewCellStyle7
            Me.DgvEditable.EditingMode = False
            Me.DgvEditable.EndFindValue = Nothing
            Me.DgvEditable.FieldDescription = Nothing
            Me.DgvEditable.FieldName = Nothing
            Me.DgvEditable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvEditable.FindEnabled = False
            Me.DgvEditable.HeaderText = "Editable"
            Me.DgvEditable.IgnoreCase = False
            Me.DgvEditable.MinimumWidth = 6
            Me.DgvEditable.Name = "DgvEditable"
            Me.DgvEditable.ReadOnly = True
            Me.DgvEditable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvEditable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvEditable.Translatable = False
            Me.DgvEditable.Width = 50
            '
            'bsGroupAccesses
            '
            Me.bsGroupAccesses.DataSource = GetType(AATM.PresentationLayer.Models.GroupAccessModel)
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.BegFindValue = Nothing
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DataValue = Nothing
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.DropDownHeight = 26
            Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cacParentIdNo.Editable = True
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.EndFindValue = Nothing
            Me.cacParentIdNo.FieldDescription = Nothing
            Me.cacParentIdNo.FieldName = Nothing
            Me.cacParentIdNo.FilterRule = Nothing
            Me.cacParentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacParentIdNo.FindEnabled = False
            Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.IgnoreCase = False
            Me.cacParentIdNo.IntegralHeight = False
            Me.cacParentIdNo.LimitToList = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Location = New System.Drawing.Point(318, 139)
            Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacParentIdNo.MaxDropDownItems = 1
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.Size = New System.Drawing.Size(581, 30)
            Me.cacParentIdNo.SuggestBoxHeight = 246
            Me.cacParentIdNo.SuggestCharCount = 0
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TabIndex = 191
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.Translatable = False
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'SecurityGroupView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.cacParentIdNo)
            Me.Controls.Add(Me.lblIdNo)
            Me.Controls.Add(Me.TxtIdNo)
            Me.Controls.Add(Me.lblSecurityGroupCode)
            Me.Controls.Add(Me.txtSecurityGroupCode)
            Me.Controls.Add(Me.lblSecurityGroupName)
            Me.Controls.Add(Me.txtSecurityGroupName)
            Me.Controls.Add(Me.lblSecurityGroupNameAra)
            Me.Controls.Add(Me.txtSecurityGroupNameAra)
            Me.Controls.Add(Me.lblParentIdNo)
            Me.Controls.Add(Me.lblNotes)
            Me.Controls.Add(Me.txtNotes)
            Me.Controls.Add(Me.DataGridViewGroupAccesses)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "SecurityGroupView"
            Me.Size = New System.Drawing.Size(925, 727)
            CType(Me.DataGridViewGroupAccesses, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsGroupAccesses, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents bsGroupAccesses As Windows.Forms.BindingSource
        Friend WithEvents DgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvSecurityGroupIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvSecurityObjectIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvSecurityObjectName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvVisible As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents DgvEditable As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Public WithEvents DataGridViewGroupAccesses As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents cacParentIdNo As Libraries.CBaseControlsLibrary.AtmComboBox
    End Class
End NameSpace