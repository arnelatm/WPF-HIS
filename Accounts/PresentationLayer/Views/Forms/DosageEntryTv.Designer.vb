Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DosageEntryTv
        Inherits CFormEntryTv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DosageEntryTv))
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboRoute = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtDosageNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDosageCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDosageName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboDirection = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.cboFrequencyTiming = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1274, 480)
        Me.SplitContainer1.SplitterDistance = 484
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(484, 480)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel3, 2)
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(11, 217)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(46, 17)
        Me.CLabel3.TabIndex = 4
        Me.CLabel3.Text = "Route"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = True
            '
            'cboRoute
            '
            Me.cboRoute.BackColor = System.Drawing.Color.White
            Me.cboRoute.BegFindValue = Nothing
            Me.cboRoute.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboRoute, 4)
            Me.cboRoute.CurrentSearchTerm = ""
            Me.cboRoute.DataValue = Nothing
            Me.cboRoute.DefaultValue = Nothing
            Me.cboRoute.DisplayMember = "Name"
            Me.cboRoute.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboRoute.EditingMode = True
            Me.cboRoute.EndFindValue = Nothing
            Me.cboRoute.FieldDescription = Nothing
            Me.cboRoute.FieldName = Nothing
            Me.cboRoute.FilterRule = Nothing
            Me.cboRoute.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboRoute.FindEnabled = False
            Me.cboRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboRoute.ForeColor = System.Drawing.Color.Black
            Me.cboRoute.FormattingEnabled = True
            Me.cboRoute.HideWhenNotEditingOrAdding = False
            Me.cboRoute.IgnoreCase = False
            Me.cboRoute.IntegralHeight = False
            Me.cboRoute.LinkedLabel = Nothing
            Me.cboRoute.Location = New System.Drawing.Point(11, 236)
            Me.cboRoute.Margin = New System.Windows.Forms.Padding(1)
            Me.cboRoute.Name = "cboRoute"
            Me.cboRoute.OldValue = 0
            Me.cboRoute.OriginalDataSource = Nothing
            Me.cboRoute.OriginalList = Nothing
            Me.cboRoute.OverrideDropDownStyleList = False
            Me.cboRoute.PreviousSearchTerm = Nothing
            Me.cboRoute.PropertySelector = Nothing
            Me.cboRoute.Size = New System.Drawing.Size(758, 24)
            Me.cboRoute.SuggestBoxHeight = 200
            Me.cboRoute.SuggestCharCount = 0
            Me.cboRoute.SuggestListOrderRule = Nothing
            Me.cboRoute.TabIndex = 5
            Me.cboRoute.TextToSearch = Nothing
            Me.cboRoute.Translatable = False
            Me.cboRoute.ValueIsMandatory = False
            Me.cboRoute.ValueIsNullable = False
            Me.cboRoute.ValueIsNumeric = False
            Me.cboRoute.ValueMember = "IdNo"
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(11, 172)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(75, 17)
            Me.CLabel4.TabIndex = 6
            Me.CLabel4.Text = "Frequency"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageNameAra, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageCode, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDirection, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.cboRoute, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFrequency, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFrequencyTiming, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 2, 5)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(10)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
            Me.TableLayoutPanel1.RowCount = 17
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(780, 383)
            Me.TableLayoutPanel1.TabIndex = 294
            '
            'txtDosageNameAra
            '
            Me.txtDosageNameAra.BackColor = System.Drawing.Color.White
            Me.txtDosageNameAra.BegFindValue = Nothing
            Me.txtDosageNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageNameAra, 4)
            Me.txtDosageNameAra.ComputedValue = False
            Me.txtDosageNameAra.CustomFormat = Nothing
            Me.txtDosageNameAra.DataBoundControl = True
            Me.txtDosageNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDosageNameAra.EditingMode = True
            Me.txtDosageNameAra.EndFindValue = Nothing
            Me.txtDosageNameAra.FieldDescription = Nothing
            Me.txtDosageNameAra.FieldName = Nothing
            Me.txtDosageNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageNameAra.FindEnabled = False
            Me.txtDosageNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDosageNameAra.LinkedLabel = Nothing
            Me.txtDosageNameAra.Location = New System.Drawing.Point(11, 123)
            Me.txtDosageNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageNameAra.MaximumValue = Nothing
            Me.txtDosageNameAra.MinimumValue = Nothing
            Me.txtDosageNameAra.Multiline = True
            Me.txtDosageNameAra.Name = "txtDosageNameAra"
            Me.txtDosageNameAra.OldValue = Nothing
            Me.txtDosageNameAra.OverrideMaxLength = 0
            Me.txtDosageNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageNameAra.Size = New System.Drawing.Size(758, 47)
            Me.txtDosageNameAra.TabIndex = 305
            Me.txtDosageNameAra.Translatable = False
            '
            'CLabel12
            '
            Me.CLabel12.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel12, 2)
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel12.Location = New System.Drawing.Point(11, 36)
            Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel12.Name = "CLabel12"
            Me.CLabel12.Size = New System.Drawing.Size(98, 17)
            Me.CLabel12.TabIndex = 304
            Me.CLabel12.Text = "Dosage Name"
            Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel12.Translatable = True
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(11, 104)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(142, 17)
            Me.CLabel11.TabIndex = 303
            Me.CLabel11.Text = "Dosage Name Arabic"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.CLabel11.Translatable = True
            '
            'txtDosageCode
            '
            Me.txtDosageCode.BackColor = System.Drawing.Color.White
            Me.txtDosageCode.BegFindValue = Nothing
            Me.txtDosageCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDosageCode.ComputedValue = False
            Me.txtDosageCode.CustomFormat = Nothing
            Me.txtDosageCode.DataBoundControl = True
            Me.txtDosageCode.EditingMode = True
            Me.txtDosageCode.EndFindValue = Nothing
            Me.txtDosageCode.FieldDescription = Nothing
            Me.txtDosageCode.FieldName = Nothing
            Me.txtDosageCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageCode.FindEnabled = False
            Me.txtDosageCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageCode.ForeColor = System.Drawing.Color.Black
            Me.txtDosageCode.LinkedLabel = Nothing
            Me.txtDosageCode.Location = New System.Drawing.Point(278, 11)
            Me.txtDosageCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageCode.MaximumValue = Nothing
            Me.txtDosageCode.MinimumValue = Nothing
            Me.txtDosageCode.Name = "txtDosageCode"
            Me.txtDosageCode.OldValue = Nothing
            Me.txtDosageCode.OverrideMaxLength = 0
            Me.txtDosageCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageCode.Size = New System.Drawing.Size(81, 23)
            Me.txtDosageCode.TabIndex = 301
            Me.txtDosageCode.Translatable = False
            '
            'txtDosageName
            '
            Me.txtDosageName.BackColor = System.Drawing.Color.White
            Me.txtDosageName.BegFindValue = Nothing
            Me.txtDosageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageName, 4)
            Me.txtDosageName.ComputedValue = False
            Me.txtDosageName.CustomFormat = Nothing
            Me.txtDosageName.DataBoundControl = True
            Me.txtDosageName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDosageName.EditingMode = True
            Me.txtDosageName.EndFindValue = Nothing
            Me.txtDosageName.FieldDescription = Nothing
            Me.txtDosageName.FieldName = Nothing
            Me.txtDosageName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageName.FindEnabled = False
            Me.txtDosageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageName.ForeColor = System.Drawing.Color.Black
            Me.txtDosageName.LinkedLabel = Nothing
            Me.txtDosageName.Location = New System.Drawing.Point(11, 55)
            Me.txtDosageName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageName.MaximumValue = Nothing
            Me.txtDosageName.MinimumValue = Nothing
            Me.txtDosageName.Multiline = True
            Me.txtDosageName.Name = "txtDosageName"
            Me.txtDosageName.OldValue = Nothing
            Me.txtDosageName.OverrideMaxLength = 0
            Me.txtDosageName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageName.Size = New System.Drawing.Size(758, 47)
            Me.txtDosageName.TabIndex = 302
            Me.txtDosageName.Translatable = False
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = False
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Nothing
            Me.txtIdNo.Location = New System.Drawing.Point(88, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(65, 23)
            Me.txtIdNo.TabIndex = 300
            Me.txtIdNo.Translatable = False
            '
            'cboDirection
            '
            Me.cboDirection.BackColor = System.Drawing.Color.White
            Me.cboDirection.BegFindValue = Nothing
            Me.cboDirection.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDirection, 4)
            Me.cboDirection.CurrentSearchTerm = ""
            Me.cboDirection.DataValue = Nothing
            Me.cboDirection.DefaultValue = Nothing
            Me.cboDirection.DisplayMember = "Name"
            Me.cboDirection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDirection.EditingMode = True
            Me.cboDirection.EndFindValue = Nothing
            Me.cboDirection.FieldDescription = Nothing
            Me.cboDirection.FieldName = Nothing
            Me.cboDirection.FilterRule = Nothing
            Me.cboDirection.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDirection.FindEnabled = False
            Me.cboDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDirection.ForeColor = System.Drawing.Color.Black
            Me.cboDirection.FormattingEnabled = True
            Me.cboDirection.HideWhenNotEditingOrAdding = False
            Me.cboDirection.IgnoreCase = False
            Me.cboDirection.IntegralHeight = False
            Me.cboDirection.LinkedLabel = Nothing
            Me.cboDirection.Location = New System.Drawing.Point(11, 281)
            Me.cboDirection.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDirection.Name = "cboDirection"
            Me.cboDirection.OldValue = 0
            Me.cboDirection.OriginalDataSource = Nothing
            Me.cboDirection.OriginalList = Nothing
            Me.cboDirection.OverrideDropDownStyleList = False
            Me.cboDirection.PreviousSearchTerm = Nothing
            Me.cboDirection.PropertySelector = Nothing
            Me.cboDirection.Size = New System.Drawing.Size(758, 24)
            Me.cboDirection.SuggestBoxHeight = 200
            Me.cboDirection.SuggestCharCount = 0
            Me.cboDirection.SuggestListOrderRule = Nothing
            Me.cboDirection.TabIndex = 298
            Me.cboDirection.TextToSearch = Nothing
            Me.cboDirection.Translatable = False
            Me.cboDirection.ValueIsMandatory = False
            Me.cboDirection.ValueIsNullable = False
            Me.cboDirection.ValueIsNumeric = False
            Me.cboDirection.ValueMember = "IdNo"
            '
            'CLabel6
            '
            Me.CLabel6.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel6, 2)
            Me.CLabel6.DisplayOnly = True
            Me.CLabel6.EditingMode = False
            Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel6.Location = New System.Drawing.Point(11, 262)
            Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel6.Name = "CLabel6"
            Me.CLabel6.Size = New System.Drawing.Size(64, 17)
            Me.CLabel6.TabIndex = 10
            Me.CLabel6.Text = "Direction"
            Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel6.Translatable = True
            '
            'cboFrequency
            '
            Me.cboFrequency.BackColor = System.Drawing.Color.White
            Me.cboFrequency.BegFindValue = Nothing
            Me.cboFrequency.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboFrequency, 2)
            Me.cboFrequency.CurrentSearchTerm = ""
            Me.cboFrequency.DataValue = Nothing
            Me.cboFrequency.DefaultValue = Nothing
            Me.cboFrequency.DisplayMember = "Name"
            Me.cboFrequency.EditingMode = True
            Me.cboFrequency.EndFindValue = Nothing
            Me.cboFrequency.FieldDescription = Nothing
            Me.cboFrequency.FieldName = Nothing
            Me.cboFrequency.FilterRule = Nothing
            Me.cboFrequency.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboFrequency.FindEnabled = False
            Me.cboFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboFrequency.FormattingEnabled = True
            Me.cboFrequency.HideWhenNotEditingOrAdding = False
            Me.cboFrequency.IgnoreCase = False
            Me.cboFrequency.IntegralHeight = False
            Me.cboFrequency.LinkedLabel = Nothing
            Me.cboFrequency.Location = New System.Drawing.Point(11, 191)
            Me.cboFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.cboFrequency.Name = "cboFrequency"
            Me.cboFrequency.OldValue = 0
            Me.cboFrequency.OriginalDataSource = Nothing
            Me.cboFrequency.OriginalList = Nothing
            Me.cboFrequency.OverrideDropDownStyleList = False
            Me.cboFrequency.PreviousSearchTerm = Nothing
            Me.cboFrequency.PropertySelector = Nothing
            Me.cboFrequency.Size = New System.Drawing.Size(142, 24)
            Me.cboFrequency.SuggestBoxHeight = 200
            Me.cboFrequency.SuggestCharCount = 0
            Me.cboFrequency.SuggestListOrderRule = Nothing
            Me.cboFrequency.TabIndex = 295
            Me.cboFrequency.TextToSearch = Nothing
            Me.cboFrequency.Translatable = False
            Me.cboFrequency.ValueIsMandatory = False
            Me.cboFrequency.ValueIsNullable = False
            Me.cboFrequency.ValueIsNumeric = False
            Me.cboFrequency.ValueMember = "IdNo"
            '
            'cboFrequencyTiming
            '
            Me.cboFrequencyTiming.BackColor = System.Drawing.Color.White
            Me.cboFrequencyTiming.BegFindValue = Nothing
            Me.cboFrequencyTiming.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboFrequencyTiming, 2)
            Me.cboFrequencyTiming.CurrentSearchTerm = ""
            Me.cboFrequencyTiming.DataValue = Nothing
            Me.cboFrequencyTiming.DefaultValue = Nothing
            Me.cboFrequencyTiming.DisplayMember = "Name"
            Me.cboFrequencyTiming.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboFrequencyTiming.EditingMode = True
            Me.cboFrequencyTiming.EndFindValue = Nothing
            Me.cboFrequencyTiming.FieldDescription = Nothing
            Me.cboFrequencyTiming.FieldName = Nothing
            Me.cboFrequencyTiming.FilterRule = Nothing
            Me.cboFrequencyTiming.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboFrequencyTiming.FindEnabled = False
            Me.cboFrequencyTiming.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboFrequencyTiming.ForeColor = System.Drawing.Color.Black
            Me.cboFrequencyTiming.FormattingEnabled = True
            Me.cboFrequencyTiming.HideWhenNotEditingOrAdding = False
            Me.cboFrequencyTiming.IgnoreCase = False
            Me.cboFrequencyTiming.IntegralHeight = False
            Me.cboFrequencyTiming.LinkedLabel = Nothing
            Me.cboFrequencyTiming.Location = New System.Drawing.Point(155, 191)
            Me.cboFrequencyTiming.Margin = New System.Windows.Forms.Padding(1)
            Me.cboFrequencyTiming.Name = "cboFrequencyTiming"
            Me.cboFrequencyTiming.OldValue = 0
            Me.cboFrequencyTiming.OriginalDataSource = Nothing
            Me.cboFrequencyTiming.OriginalList = Nothing
            Me.cboFrequencyTiming.OverrideDropDownStyleList = False
            Me.cboFrequencyTiming.PreviousSearchTerm = Nothing
            Me.cboFrequencyTiming.PropertySelector = Nothing
            Me.cboFrequencyTiming.Size = New System.Drawing.Size(614, 24)
            Me.cboFrequencyTiming.SuggestBoxHeight = 200
            Me.cboFrequencyTiming.SuggestCharCount = 0
            Me.cboFrequencyTiming.SuggestListOrderRule = Nothing
            Me.cboFrequencyTiming.TabIndex = 297
            Me.cboFrequencyTiming.TextToSearch = Nothing
            Me.cboFrequencyTiming.Translatable = False
            Me.cboFrequencyTiming.ValueIsMandatory = False
            Me.cboFrequencyTiming.ValueIsNullable = False
            Me.cboFrequencyTiming.ValueIsNumeric = False
            Me.cboFrequencyTiming.ValueMember = "IdNo"
            '
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(11, 11)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(47, 17)
            Me.CLabel5.TabIndex = 299
            Me.CLabel5.Text = "ID No."
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'CLabel10
            '
            Me.CLabel10.AutoSize = True
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(155, 11)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(45, 17)
            Me.CLabel10.TabIndex = 301
            Me.CLabel10.Text = "Code "
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel10.Translatable = True
            '
            'CLabel9
            '
            Me.CLabel9.AutoSize = True
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel9.Location = New System.Drawing.Point(155, 172)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(121, 17)
            Me.CLabel9.TabIndex = 296
            Me.CLabel9.Text = "Frequency Timing"
            Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel9.Translatable = True
            '
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.Color.White
            Me.CTextBox1.BegFindValue = Nothing
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.EndFindValue = Nothing
            Me.CTextBox1.FieldDescription = Nothing
            Me.CTextBox1.FieldName = Nothing
            Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox1.FindEnabled = False
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(11, 123)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Multiline = True
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.OverrideMaxLength = 0
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(505, 47)
        Me.CTextBox1.TabIndex = 305
        Me.CTextBox1.Translatable = false
        '
        'DosageEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(1274, 533)
        Me.MinimumSize = New System.Drawing.Size(16, 100)
        Me.Name = "DosageEntryTv"
        Me.Text = "Dosage Maintenance"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboRoute As CtComboBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CLabel6 As CLabel
        Friend WithEvents cboFrequency As CtComboBox
        Friend WithEvents CLabel9 As CLabel
        Friend WithEvents cboFrequencyTiming As CtComboBox
        Friend WithEvents cboDirection As CtComboBox
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents txtDosageCode As CTextBox
        Friend WithEvents CLabel10 As CLabel
        Friend WithEvents txtDosageName As CTextBox
        Friend WithEvents CLabel11 As CLabel
        Friend WithEvents CLabel12 As CLabel
        Friend WithEvents txtDosageNameAra As CTextBox
        Friend WithEvents CTextBox1 As CTextBox
    End Class
End Namespace