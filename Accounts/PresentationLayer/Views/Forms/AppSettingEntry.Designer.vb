Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AppSettingEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim CBlendItems1 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.btnLockGroup = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblAppSettingGroupSelector = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAppSettingGroupSelector = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSelector2IdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblSelector2IdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSelector1IdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblSelector1IdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAppSettingGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.btnLockGroup, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAppSettingGroupSelector, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAppSettingGroupSelector, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboSelector2IdNo, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSelector2IdNo, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboSelector1IdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSelector1IdNo, 0, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(577, 140)
            Me.TableLayoutPanel1.TabIndex = 5
            '
            'btnLockGroup
            '
            Me.btnLockGroup.BackColor = System.Drawing.Color.GreenYellow
            Me.btnLockGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
            CBlendItems1.iPoint = New Single() {0!, 1.0!}
            Me.btnLockGroup.ColorFillBlend = CBlendItems1
            Me.btnLockGroup.DesignerSelected = False
            Me.btnLockGroup.FillType = AATM.Libraries.CBaseControlsLibrary.CButton.eFillType.Solid
            Me.btnLockGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLockGroup.ImageIndex = 0
            Me.btnLockGroup.Location = New System.Drawing.Point(533, 3)
            Me.btnLockGroup.Name = "btnLockGroup"
            Me.btnLockGroup.OriginalImageName = Nothing
            Me.btnLockGroup.SecurityKey = ""
            Me.btnLockGroup.Size = New System.Drawing.Size(23, 21)
            Me.btnLockGroup.TabIndex = 164
            Me.btnLockGroup.Text = ""
            '
            'lblAppSettingGroupSelector
            '
            Me.lblAppSettingGroupSelector.AutoSize = True
            Me.lblAppSettingGroupSelector.BackColor = System.Drawing.Color.Transparent
            Me.lblAppSettingGroupSelector.DisplayOnly = True
            Me.lblAppSettingGroupSelector.EditingMode = False
            Me.lblAppSettingGroupSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAppSettingGroupSelector.Location = New System.Drawing.Point(1, 1)
            Me.lblAppSettingGroupSelector.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAppSettingGroupSelector.Name = "lblAppSettingGroupSelector"
            Me.lblAppSettingGroupSelector.Size = New System.Drawing.Size(104, 17)
            Me.lblAppSettingGroupSelector.TabIndex = 11
            Me.lblAppSettingGroupSelector.Text = "Group Selector"
            Me.lblAppSettingGroupSelector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAppSettingGroupSelector.Translatable = True
            '
            'cboAppSettingGroupSelector
            '
            Me.cboAppSettingGroupSelector.BackColor = System.Drawing.Color.White
            Me.cboAppSettingGroupSelector.BegFindValue = Nothing
            Me.cboAppSettingGroupSelector.ChangingSearchValueOnly = False
            Me.cboAppSettingGroupSelector.CurrentSearchTerm = ""
            Me.cboAppSettingGroupSelector.DataValue = Nothing
            Me.cboAppSettingGroupSelector.DefaultValue = Nothing
            Me.cboAppSettingGroupSelector.DisplayMember = "Name"
            Me.cboAppSettingGroupSelector.DropDownHeight = 21
            Me.cboAppSettingGroupSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAppSettingGroupSelector.Editable = True
            Me.cboAppSettingGroupSelector.EditingMode = False
            Me.cboAppSettingGroupSelector.EndFindValue = Nothing
            Me.cboAppSettingGroupSelector.FieldDescription = Nothing
            Me.cboAppSettingGroupSelector.FieldName = Nothing
            Me.cboAppSettingGroupSelector.FilterRule = Nothing
            Me.cboAppSettingGroupSelector.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAppSettingGroupSelector.FindEnabled = False
            Me.cboAppSettingGroupSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAppSettingGroupSelector.ForeColor = System.Drawing.Color.Black
            Me.cboAppSettingGroupSelector.FormattingEnabled = True
            Me.cboAppSettingGroupSelector.HideWhenNotEditingOrAdding = False
            Me.cboAppSettingGroupSelector.IgnoreCase = False
            Me.cboAppSettingGroupSelector.LimitToList = False
            Me.cboAppSettingGroupSelector.LinkedLabel = Nothing
            Me.cboAppSettingGroupSelector.Location = New System.Drawing.Point(151, 1)
            Me.cboAppSettingGroupSelector.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAppSettingGroupSelector.MaxDropDownItems = 1
            Me.cboAppSettingGroupSelector.Name = "cboAppSettingGroupSelector"
            Me.cboAppSettingGroupSelector.OldValue = 0
            Me.cboAppSettingGroupSelector.OriginalDataSource = Nothing
            Me.cboAppSettingGroupSelector.OriginalList = Nothing
            Me.cboAppSettingGroupSelector.OverrideDropDownStyleList = False
            Me.cboAppSettingGroupSelector.PreviousSearchTerm = Nothing
            Me.cboAppSettingGroupSelector.PropertySelector = Nothing
            Me.cboAppSettingGroupSelector.Size = New System.Drawing.Size(378, 24)
            Me.cboAppSettingGroupSelector.SuggestBoxHeight = 200
            Me.cboAppSettingGroupSelector.SuggestCharCount = 0
            Me.cboAppSettingGroupSelector.SuggestListOrderRule = Nothing
            Me.cboAppSettingGroupSelector.TabIndex = 10
            Me.cboAppSettingGroupSelector.TextToSearch = Nothing
            Me.cboAppSettingGroupSelector.Translatable = False
            Me.cboAppSettingGroupSelector.ValueIsMandatory = False
            Me.cboAppSettingGroupSelector.ValueIsNullable = False
            Me.cboAppSettingGroupSelector.ValueIsNumeric = False
            Me.cboAppSettingGroupSelector.ValueMember = "IdNo"
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
            Me.TxtIdNo.EditingMode = False
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(151, 28)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(88, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.AutoSize = True
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 28)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(83, 17)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'cboSelector2IdNo
            '
            Me.cboSelector2IdNo.BackColor = System.Drawing.Color.White
            Me.cboSelector2IdNo.BegFindValue = Nothing
            Me.cboSelector2IdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboSelector2IdNo, 2)
            Me.cboSelector2IdNo.CurrentSearchTerm = ""
            Me.cboSelector2IdNo.DataValue = Nothing
            Me.cboSelector2IdNo.DefaultValue = Nothing
            Me.cboSelector2IdNo.DisplayMember = "Name"
            Me.cboSelector2IdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboSelector2IdNo.DropDownHeight = 21
            Me.cboSelector2IdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboSelector2IdNo.Editable = True
            Me.cboSelector2IdNo.EditingMode = False
            Me.cboSelector2IdNo.EndFindValue = Nothing
            Me.cboSelector2IdNo.FieldDescription = Nothing
            Me.cboSelector2IdNo.FieldName = Nothing
            Me.cboSelector2IdNo.FilterRule = Nothing
            Me.cboSelector2IdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSelector2IdNo.FindEnabled = False
            Me.cboSelector2IdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSelector2IdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSelector2IdNo.FormattingEnabled = True
            Me.cboSelector2IdNo.HideWhenNotEditingOrAdding = False
            Me.cboSelector2IdNo.IgnoreCase = False
            Me.cboSelector2IdNo.LimitToList = False
            Me.cboSelector2IdNo.LinkedLabel = Nothing
            Me.cboSelector2IdNo.Location = New System.Drawing.Point(151, 79)
            Me.cboSelector2IdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSelector2IdNo.MaxDropDownItems = 1
            Me.cboSelector2IdNo.Name = "cboSelector2IdNo"
            Me.cboSelector2IdNo.OldValue = 0
            Me.cboSelector2IdNo.OriginalDataSource = Nothing
            Me.cboSelector2IdNo.OriginalList = Nothing
            Me.cboSelector2IdNo.OverrideDropDownStyleList = False
            Me.cboSelector2IdNo.PreviousSearchTerm = Nothing
            Me.cboSelector2IdNo.PropertySelector = Nothing
            Me.cboSelector2IdNo.Size = New System.Drawing.Size(426, 24)
            Me.cboSelector2IdNo.SuggestBoxHeight = 200
            Me.cboSelector2IdNo.SuggestCharCount = 0
            Me.cboSelector2IdNo.SuggestListOrderRule = Nothing
            Me.cboSelector2IdNo.TabIndex = 7
            Me.cboSelector2IdNo.TextToSearch = Nothing
            Me.cboSelector2IdNo.Translatable = False
            Me.cboSelector2IdNo.ValueIsMandatory = False
            Me.cboSelector2IdNo.ValueIsNullable = False
            Me.cboSelector2IdNo.ValueIsNumeric = False
            Me.cboSelector2IdNo.ValueMember = "IdNo"
            '
            'lblSelector2IdNo
            '
            Me.lblSelector2IdNo.AutoSize = True
            Me.lblSelector2IdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSelector2IdNo.DisplayOnly = True
            Me.lblSelector2IdNo.EditingMode = False
            Me.lblSelector2IdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSelector2IdNo.Location = New System.Drawing.Point(1, 79)
            Me.lblSelector2IdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSelector2IdNo.Name = "lblSelector2IdNo"
            Me.lblSelector2IdNo.Size = New System.Drawing.Size(72, 17)
            Me.lblSelector2IdNo.TabIndex = 8
            Me.lblSelector2IdNo.Text = "Selector 2"
            Me.lblSelector2IdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSelector2IdNo.Translatable = True
            '
            'cboSelector1IdNo
            '
            Me.cboSelector1IdNo.BackColor = System.Drawing.Color.White
            Me.cboSelector1IdNo.BegFindValue = Nothing
            Me.cboSelector1IdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboSelector1IdNo, 2)
            Me.cboSelector1IdNo.CurrentSearchTerm = ""
            Me.cboSelector1IdNo.DataValue = Nothing
            Me.cboSelector1IdNo.DefaultValue = Nothing
            Me.cboSelector1IdNo.DisplayMember = "Name"
            Me.cboSelector1IdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboSelector1IdNo.DropDownHeight = 21
            Me.cboSelector1IdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboSelector1IdNo.Editable = True
            Me.cboSelector1IdNo.EditingMode = False
            Me.cboSelector1IdNo.EndFindValue = Nothing
            Me.cboSelector1IdNo.FieldDescription = Nothing
            Me.cboSelector1IdNo.FieldName = Nothing
            Me.cboSelector1IdNo.FilterRule = Nothing
            Me.cboSelector1IdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSelector1IdNo.FindEnabled = False
            Me.cboSelector1IdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSelector1IdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSelector1IdNo.FormattingEnabled = True
            Me.cboSelector1IdNo.HideWhenNotEditingOrAdding = False
            Me.cboSelector1IdNo.IgnoreCase = False
            Me.cboSelector1IdNo.LimitToList = False
            Me.cboSelector1IdNo.LinkedLabel = Nothing
            Me.cboSelector1IdNo.Location = New System.Drawing.Point(151, 53)
            Me.cboSelector1IdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSelector1IdNo.MaxDropDownItems = 1
            Me.cboSelector1IdNo.Name = "cboSelector1IdNo"
            Me.cboSelector1IdNo.OldValue = 0
            Me.cboSelector1IdNo.OriginalDataSource = Nothing
            Me.cboSelector1IdNo.OriginalList = Nothing
            Me.cboSelector1IdNo.OverrideDropDownStyleList = False
            Me.cboSelector1IdNo.PreviousSearchTerm = Nothing
            Me.cboSelector1IdNo.PropertySelector = Nothing
            Me.cboSelector1IdNo.Size = New System.Drawing.Size(426, 24)
            Me.cboSelector1IdNo.SuggestBoxHeight = 200
            Me.cboSelector1IdNo.SuggestCharCount = 0
            Me.cboSelector1IdNo.SuggestListOrderRule = Nothing
            Me.cboSelector1IdNo.TabIndex = 9
            Me.cboSelector1IdNo.TextToSearch = Nothing
            Me.cboSelector1IdNo.Translatable = False
            Me.cboSelector1IdNo.ValueIsMandatory = False
            Me.cboSelector1IdNo.ValueIsNullable = False
            Me.cboSelector1IdNo.ValueIsNumeric = False
            Me.cboSelector1IdNo.ValueMember = "IdNo"
            '
            'lblSelector1IdNo
            '
            Me.lblSelector1IdNo.AutoSize = True
            Me.lblSelector1IdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSelector1IdNo.DisplayOnly = True
            Me.lblSelector1IdNo.EditingMode = False
            Me.lblSelector1IdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSelector1IdNo.Location = New System.Drawing.Point(1, 53)
            Me.lblSelector1IdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSelector1IdNo.Name = "lblSelector1IdNo"
            Me.lblSelector1IdNo.Size = New System.Drawing.Size(72, 17)
            Me.lblSelector1IdNo.TabIndex = 3
            Me.lblSelector1IdNo.Text = "Selector 1"
            Me.lblSelector1IdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSelector1IdNo.Translatable = True
            '
            'txtAppSettingGroupIdNo
            '
            Me.txtAppSettingGroupIdNo.BackColor = System.Drawing.Color.White
            Me.txtAppSettingGroupIdNo.BegFindValue = Nothing
            Me.txtAppSettingGroupIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAppSettingGroupIdNo.ComputedValue = False
            Me.txtAppSettingGroupIdNo.CustomFormat = Nothing
            Me.txtAppSettingGroupIdNo.DataBoundControl = True
            Me.txtAppSettingGroupIdNo.DisplayOnly = True
            Me.txtAppSettingGroupIdNo.EditingMode = True
            Me.txtAppSettingGroupIdNo.EndFindValue = Nothing
            Me.txtAppSettingGroupIdNo.FieldDescription = Nothing
            Me.txtAppSettingGroupIdNo.FieldName = Nothing
            Me.txtAppSettingGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAppSettingGroupIdNo.FindEnabled = True
            Me.txtAppSettingGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAppSettingGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtAppSettingGroupIdNo.LinkedLabel = Nothing
            Me.txtAppSettingGroupIdNo.Location = New System.Drawing.Point(12, 201)
            Me.txtAppSettingGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAppSettingGroupIdNo.MaximumValue = Nothing
            Me.txtAppSettingGroupIdNo.MinimumValue = Nothing
            Me.txtAppSettingGroupIdNo.Name = "txtAppSettingGroupIdNo"
            Me.txtAppSettingGroupIdNo.OldValue = Nothing
            Me.txtAppSettingGroupIdNo.OverrideMaxLength = 0
            Me.txtAppSettingGroupIdNo.ReadOnly = True
            Me.txtAppSettingGroupIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAppSettingGroupIdNo.Size = New System.Drawing.Size(88, 23)
            Me.txtAppSettingGroupIdNo.TabIndex = 165
            Me.txtAppSettingGroupIdNo.Translatable = False
            Me.txtAppSettingGroupIdNo.Visible = False
            '
            'AppSettingEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(601, 230)
            Me.Controls.Add(Me.txtAppSettingGroupIdNo)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "AppSettingEntry"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            Me.Controls.SetChildIndex(Me.txtAppSettingGroupIdNo, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblSelector1IdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboSelector2IdNo As Libraries.CBaseControlsLibrary.AtmComboBox
        Friend WithEvents lblSelector2IdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboSelector1IdNo As Libraries.CBaseControlsLibrary.AtmComboBox
        Friend WithEvents lblAppSettingGroupSelector As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboAppSettingGroupSelector As Libraries.CBaseControlsLibrary.AtmComboBox
        Friend WithEvents btnLockGroup As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents txtAppSettingGroupIdNo As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace