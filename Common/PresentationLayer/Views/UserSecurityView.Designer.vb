Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UserSecurityView
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUserSecurityName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewUserAccesses = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.DgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvSecurityObjectIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DgvVisible = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.DgvEditable = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.bsUserAccesses = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.DataGridViewUserAccesses, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsUserAccesses, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblIdNo.Text = "User Id No."
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
            'lblUserSecurityName
            '
            Me.lblUserSecurityName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserSecurityName.DisplayOnly = True
            Me.lblUserSecurityName.EditingMode = False
            Me.lblUserSecurityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblUserSecurityName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblUserSecurityName.Location = New System.Drawing.Point(23, 48)
            Me.lblUserSecurityName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUserSecurityName.Name = "lblUserSecurityName"
            Me.lblUserSecurityName.Size = New System.Drawing.Size(292, 28)
            Me.lblUserSecurityName.TabIndex = 186
            Me.lblUserSecurityName.Text = "User Name"
            Me.lblUserSecurityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUserSecurityName.Translatable = True
            '
            'txtUserName
            '
            Me.txtUserName.BackColor = System.Drawing.Color.White
            Me.txtUserName.BegFindValue = Nothing
            Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUserName.ComputedValue = False
            Me.txtUserName.CustomFormat = Nothing
            Me.txtUserName.DataBoundControl = True
            Me.txtUserName.EditingMode = True
            Me.txtUserName.EndFindValue = Nothing
            Me.txtUserName.FieldDescription = Nothing
            Me.txtUserName.FieldName = Nothing
            Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUserName.FindEnabled = False
            Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtUserName.ForeColor = System.Drawing.Color.Black
            Me.txtUserName.LinkedLabel = Nothing
            Me.txtUserName.Location = New System.Drawing.Point(317, 48)
            Me.txtUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtUserName.MaximumValue = Nothing
            Me.txtUserName.MinimumValue = Nothing
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.OldValue = Nothing
            Me.txtUserName.OverrideMaxLength = 0
            Me.txtUserName.ReadOnly = True
            Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUserName.Size = New System.Drawing.Size(582, 26)
            Me.txtUserName.TabIndex = 181
            Me.txtUserName.Translatable = False
            Me.txtUserName.ValueIsMandatory = True
            '
            'DataGridViewUserAccesses
            '
            Me.DataGridViewUserAccesses.AllowUserToAddRows = False
            Me.DataGridViewUserAccesses.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewUserAccesses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewUserAccesses.AutoGenerateColumns = False
            Me.DataGridViewUserAccesses.BegFindValue = Nothing
            Me.DataGridViewUserAccesses.Cached = False
            Me.DataGridViewUserAccesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewUserAccesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvIdNo, Me.DgvSecurityObjectIdNo, Me.DgvSecurityObjectName, Me.DgvVisible, Me.DgvEditable})
            Me.DataGridViewUserAccesses.DataFilter = Nothing
            Me.DataGridViewUserAccesses.DataSource = Me.bsUserAccesses
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewUserAccesses.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewUserAccesses.DgvFooter = Nothing
            Me.DataGridViewUserAccesses.DisplayOnly = False
            Me.DataGridViewUserAccesses.Ea = Nothing
            Me.DataGridViewUserAccesses.EditingMode = False
            Me.DataGridViewUserAccesses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewUserAccesses.EndFindValue = Nothing
            Me.DataGridViewUserAccesses.FieldDescription = Nothing
            Me.DataGridViewUserAccesses.FieldName = Nothing
            Me.DataGridViewUserAccesses.FieldsDictionary = Nothing
            Me.DataGridViewUserAccesses.FindColumnNo = CType(0, Short)
            Me.DataGridViewUserAccesses.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewUserAccesses.FindEnabled = False
            Me.DataGridViewUserAccesses.FirstRowDeletionEnabled = False
            Me.DataGridViewUserAccesses.FirstRowInsertionEnabled = False
            Me.DataGridViewUserAccesses.IgnoreCase = False
            Me.DataGridViewUserAccesses.IsDirty = False
            Me.DataGridViewUserAccesses.Location = New System.Drawing.Point(26, 81)
            Me.DataGridViewUserAccesses.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewUserAccesses.Name = "DataGridViewUserAccesses"
            Me.DataGridViewUserAccesses.OldCellValue = Nothing
            Me.DataGridViewUserAccesses.ReadOnly = True
            Me.DataGridViewUserAccesses.RowHeadersWidth = 51
            Me.DataGridViewUserAccesses.Searchable = True
            Me.DataGridViewUserAccesses.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewUserAccesses.SecurityKey = ""
            Me.DataGridViewUserAccesses.SequenceColumn = "dgvSequence"
            Me.DataGridViewUserAccesses.SequenceFieldName = "Sequence"
            Me.DataGridViewUserAccesses.ShowFooter = False
            Me.DataGridViewUserAccesses.Size = New System.Drawing.Size(873, 623)
            Me.DataGridViewUserAccesses.TabIndex = 178
            Me.DataGridViewUserAccesses.Translatable = True
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
            'DgvSecurityObjectIdNo
            '
            Me.DgvSecurityObjectIdNo.BegFindValue = Nothing
            Me.DgvSecurityObjectIdNo.DataPropertyName = "SecurityObjectIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.DgvSecurityObjectIdNo.DefaultCellStyle = DataGridViewCellStyle3
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
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.DgvSecurityObjectName.DefaultCellStyle = DataGridViewCellStyle4
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
            Me.DgvVisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DgvVisible.BegFindValue = Nothing
            Me.DgvVisible.DataPropertyName = "Visible"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.NullValue = False
            Me.DgvVisible.DefaultCellStyle = DataGridViewCellStyle5
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
            Me.DgvVisible.Width = 54
            '
            'DgvEditable
            '
            Me.DgvEditable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DgvEditable.BegFindValue = Nothing
            Me.DgvEditable.DataPropertyName = "Editable"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.NullValue = False
            Me.DgvEditable.DefaultCellStyle = DataGridViewCellStyle6
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
            Me.DgvEditable.Width = 63
            '
            'bsUserAccesses
            '
            Me.bsUserAccesses.DataSource = GetType(AATM.PresentationLayer.Models.UserAccessModel)
            '
            'UserSecurityView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.lblIdNo)
            Me.Controls.Add(Me.TxtIdNo)
            Me.Controls.Add(Me.lblUserSecurityName)
            Me.Controls.Add(Me.txtUserName)
            Me.Controls.Add(Me.DataGridViewUserAccesses)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "UserSecurityView"
            Me.Size = New System.Drawing.Size(925, 727)
            CType(Me.DataGridViewUserAccesses, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsUserAccesses, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblUserSecurityName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtUserName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents bsUserAccesses As Windows.Forms.BindingSource
        Friend WithEvents DgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvUserSecurityIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvSecurityObjectIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvSecurityObjectName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DgvVisible As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents DgvEditable As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Public WithEvents DataGridViewUserAccesses As Libraries.CBaseControlsLibrary.CtDataGridView
    End Class
End NameSpace