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
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUserSecurityName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewUserAccesses = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsUserAccesses = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvVisible = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvEditable = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvSecurityObjectIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvUserIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
            Me.lblIdNo.Location = New System.Drawing.Point(17, 13)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(219, 23)
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
            Me.TxtIdNo.Location = New System.Drawing.Point(238, 13)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
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
            Me.lblUserSecurityName.Location = New System.Drawing.Point(17, 39)
            Me.lblUserSecurityName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUserSecurityName.Name = "lblUserSecurityName"
            Me.lblUserSecurityName.Size = New System.Drawing.Size(219, 23)
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
            Me.txtUserName.Location = New System.Drawing.Point(238, 39)
            Me.txtUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtUserName.MaximumValue = Nothing
            Me.txtUserName.MinimumValue = Nothing
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.OldValue = Nothing
            Me.txtUserName.OverrideMaxLength = 0
            Me.txtUserName.ReadOnly = True
            Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUserName.Size = New System.Drawing.Size(437, 23)
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
            Me.DataGridViewUserAccesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSecurityObjectName, Me.dgvVisible, Me.dgvEditable, Me.dgvIdNo, Me.dgvSecurityObjectIdNo, Me.dgvUserIdNo})
            Me.DataGridViewUserAccesses.DataFilter = Nothing
            Me.DataGridViewUserAccesses.DataSource = Me.bsUserAccesses
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewUserAccesses.DefaultCellStyle = DataGridViewCellStyle5
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
            Me.DataGridViewUserAccesses.Location = New System.Drawing.Point(20, 66)
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
            Me.DataGridViewUserAccesses.Size = New System.Drawing.Size(655, 506)
            Me.DataGridViewUserAccesses.TabIndex = 178
            Me.DataGridViewUserAccesses.Translatable = True
            '
            'bsUserAccesses
            '
            Me.bsUserAccesses.DataSource = GetType(AATM.PresentationLayer.Models.UserAccessModel)
            '
            'dgvSecurityObjectName
            '
            Me.dgvSecurityObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvSecurityObjectName.BegFindValue = Nothing
            Me.dgvSecurityObjectName.DataPropertyName = "SecurityObjectName"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSecurityObjectName.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSecurityObjectName.EditingMode = False
            Me.dgvSecurityObjectName.EndFindValue = Nothing
            Me.dgvSecurityObjectName.FieldDescription = Nothing
            Me.dgvSecurityObjectName.FieldName = Nothing
            Me.dgvSecurityObjectName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSecurityObjectName.FindEnabled = False
            Me.dgvSecurityObjectName.HeaderText = "Security Object Name"
            Me.dgvSecurityObjectName.IgnoreCase = False
            Me.dgvSecurityObjectName.Name = "dgvSecurityObjectName"
            Me.dgvSecurityObjectName.ReadOnly = True
            Me.dgvSecurityObjectName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSecurityObjectName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSecurityObjectName.Translatable = False
            '
            'dgvVisible
            '
            Me.dgvVisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.dgvVisible.BegFindValue = Nothing
            Me.dgvVisible.DataPropertyName = "Visible"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.NullValue = False
            Me.dgvVisible.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvVisible.EditingMode = False
            Me.dgvVisible.EndFindValue = Nothing
            Me.dgvVisible.FieldDescription = Nothing
            Me.dgvVisible.FieldName = Nothing
            Me.dgvVisible.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVisible.FindEnabled = False
            Me.dgvVisible.HeaderText = "Visible"
            Me.dgvVisible.IgnoreCase = False
            Me.dgvVisible.Name = "dgvVisible"
            Me.dgvVisible.ReadOnly = True
            Me.dgvVisible.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVisible.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVisible.Translatable = False
            Me.dgvVisible.Width = 43
            '
            'dgvEditable
            '
            Me.dgvEditable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.dgvEditable.BegFindValue = Nothing
            Me.dgvEditable.DataPropertyName = "Editable"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.NullValue = False
            Me.dgvEditable.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvEditable.EditingMode = False
            Me.dgvEditable.EndFindValue = Nothing
            Me.dgvEditable.FieldDescription = Nothing
            Me.dgvEditable.FieldName = Nothing
            Me.dgvEditable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEditable.FindEnabled = False
            Me.dgvEditable.HeaderText = "Editable"
            Me.dgvEditable.IgnoreCase = False
            Me.dgvEditable.Name = "dgvEditable"
            Me.dgvEditable.ReadOnly = True
            Me.dgvEditable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEditable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEditable.Translatable = False
            Me.dgvEditable.Width = 51
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Visible = False
            '
            'dgvSecurityObjectIdNo
            '
            Me.dgvSecurityObjectIdNo.DataPropertyName = "SecurityObjectIdNo"
            Me.dgvSecurityObjectIdNo.HeaderText = "SecurityObjectIdNo"
            Me.dgvSecurityObjectIdNo.Name = "dgvSecurityObjectIdNo"
            Me.dgvSecurityObjectIdNo.ReadOnly = True
            Me.dgvSecurityObjectIdNo.Visible = False
            '
            'dgvUserIdNo
            '
            Me.dgvUserIdNo.DataPropertyName = "UserIdNo"
            Me.dgvUserIdNo.HeaderText = "UserIdNo"
            Me.dgvUserIdNo.Name = "dgvUserIdNo"
            Me.dgvUserIdNo.ReadOnly = True
            Me.dgvUserIdNo.Visible = False
            '
            'UserSecurityView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.lblIdNo)
            Me.Controls.Add(Me.TxtIdNo)
            Me.Controls.Add(Me.lblUserSecurityName)
            Me.Controls.Add(Me.txtUserName)
            Me.Controls.Add(Me.DataGridViewUserAccesses)
            Me.Name = "UserSecurityView"
            Me.Size = New System.Drawing.Size(694, 591)
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
        Friend WithEvents DgvUserSecurityIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Public WithEvents DataGridViewUserAccesses As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents dgvSecurityObjectName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvVisible As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvEditable As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvSecurityObjectIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvUserIdNo As DataGridViewTextBoxColumn
    End Class
End NameSpace