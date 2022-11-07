Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
    Inherits CFormEntryTv

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestForm))
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.BTextBox1 = New AATM.Libraries.BaseControlsLibrary.BTextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 397)
        Me.SplitContainer1.SplitterDistance = 326
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(326, 397)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = ""
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = False
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = True
        Me.CTextBox1.EditingMode = True
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = False
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(99, 66)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox1.TabIndex = 0
        Me.CTextBox1.Translatable = False
        '
        'BTextBox1
        '
        Me.BTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BTextBox1.Location = New System.Drawing.Point(99, 103)
        Me.BTextBox1.Name = "BTextBox1"
        Me.BTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.BTextBox1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(99, 139)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(269, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CTextBox"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(269, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BTextBox"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TextBox"
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
        Me.txtNotes.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtNotes, True)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(192, 163)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(418, 60)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Translatable = False
        Me.txtNotes.ValueIsMandatory = True
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = True
        Me.lblNotes.EditingMode = False
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(1, 163)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(189, 23)
        Me.lblNotes.TabIndex = 169
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNotes.Translatable = True
        '
        'cacRevCostCenterIdNo
        '
        Me.cacRevCostCenterIdNo.BackColor = System.Drawing.Color.White
        Me.cacRevCostCenterIdNo.BegFindValue = Nothing
        Me.cacRevCostCenterIdNo.ChangingSearchValueOnly = False
        Me.cacRevCostCenterIdNo.CurrentSearchTerm = ""
        Me.cacRevCostCenterIdNo.DataValue = Nothing
        Me.cacRevCostCenterIdNo.DefaultValue = Nothing
        Me.cacRevCostCenterIdNo.DisplayMember = "Name"
        Me.cacRevCostCenterIdNo.EditingMode = False
        Me.cacRevCostCenterIdNo.EndFindValue = Nothing
        Me.cacRevCostCenterIdNo.FieldDescription = Nothing
        Me.cacRevCostCenterIdNo.FieldName = Nothing
        Me.cacRevCostCenterIdNo.FilterRule = Nothing
        Me.cacRevCostCenterIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacRevCostCenterIdNo.FindEnabled = False
        Me.CFlowLayout1.SetFlowBreak(Me.cacRevCostCenterIdNo, True)
        Me.cacRevCostCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cacRevCostCenterIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacRevCostCenterIdNo.FormattingEnabled = True
        Me.cacRevCostCenterIdNo.HideWhenNotEditingOrAdding = False
        Me.cacRevCostCenterIdNo.IgnoreCase = False
        Me.cacRevCostCenterIdNo.IntegralHeight = False
        Me.cacRevCostCenterIdNo.LinkedLabel = Nothing
        Me.cacRevCostCenterIdNo.Location = New System.Drawing.Point(192, 137)
        Me.cacRevCostCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacRevCostCenterIdNo.Name = "cacRevCostCenterIdNo"
        Me.cacRevCostCenterIdNo.OldValue = 0
        Me.cacRevCostCenterIdNo.OriginalDataSource = Nothing
        Me.cacRevCostCenterIdNo.OriginalList = Nothing
        Me.cacRevCostCenterIdNo.OverrideDropDownStyleList = False
        Me.cacRevCostCenterIdNo.PreviousSearchTerm = Nothing
        Me.cacRevCostCenterIdNo.PropertySelector = Nothing
        Me.cacRevCostCenterIdNo.ReadOnlyCombo = False
        Me.cacRevCostCenterIdNo.Size = New System.Drawing.Size(418, 24)
        Me.cacRevCostCenterIdNo.SuggestBoxHeight = 200
        Me.cacRevCostCenterIdNo.SuggestListOrderRule = Nothing
        Me.cacRevCostCenterIdNo.TabIndex = 5
        Me.cacRevCostCenterIdNo.TextToSearch = Nothing
        Me.cacRevCostCenterIdNo.Translatable = False
        Me.cacRevCostCenterIdNo.ValueIsMandatory = False
        Me.cacRevCostCenterIdNo.ValueIsNullable = False
        Me.cacRevCostCenterIdNo.ValueIsNumeric = False
        Me.cacRevCostCenterIdNo.ValueMember = "IdNo"
        '
        'lblRevCostCenterIdNo
        '
        Me.lblRevCostCenterIdNo.DisplayOnly = True
        Me.lblRevCostCenterIdNo.EditingMode = False
        Me.lblRevCostCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblRevCostCenterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRevCostCenterIdNo.Location = New System.Drawing.Point(1, 137)
        Me.lblRevCostCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRevCostCenterIdNo.Name = "lblRevCostCenterIdNo"
        Me.lblRevCostCenterIdNo.Size = New System.Drawing.Size(189, 23)
        Me.lblRevCostCenterIdNo.TabIndex = 171
        Me.lblRevCostCenterIdNo.Text = "Revenue Cost Center"
        Me.lblRevCostCenterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRevCostCenterIdNo.Translatable = True
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
        Me.cacParentIdNo.EditingMode = False
        Me.cacParentIdNo.EndFindValue = Nothing
        Me.cacParentIdNo.FieldDescription = Nothing
        Me.cacParentIdNo.FieldName = Nothing
        Me.cacParentIdNo.FilterRule = Nothing
        Me.cacParentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacParentIdNo.FindEnabled = False
        Me.CFlowLayout1.SetFlowBreak(Me.cacParentIdNo, True)
        Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = True
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
        Me.cacParentIdNo.IgnoreCase = False
        Me.cacParentIdNo.IntegralHeight = False
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Location = New System.Drawing.Point(191, 111)
        Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacParentIdNo.Name = "cacParentIdNo"
        Me.cacParentIdNo.OldValue = 0
        Me.cacParentIdNo.OriginalDataSource = Nothing
        Me.cacParentIdNo.OriginalList = Nothing
        Me.cacParentIdNo.OverrideDropDownStyleList = False
        Me.cacParentIdNo.PreviousSearchTerm = Nothing
        Me.cacParentIdNo.PropertySelector = Nothing
        Me.cacParentIdNo.ReadOnlyCombo = False
        Me.cacParentIdNo.Size = New System.Drawing.Size(419, 24)
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TabIndex = 3
        Me.cacParentIdNo.TextToSearch = Nothing
        Me.cacParentIdNo.Translatable = False
        Me.cacParentIdNo.ValueIsMandatory = False
        Me.cacParentIdNo.ValueIsNullable = False
        Me.cacParentIdNo.ValueIsNumeric = False
        Me.cacParentIdNo.ValueMember = "IdNo"
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = True
        Me.lblParentIdNo.EditingMode = False
        Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParentIdNo.Location = New System.Drawing.Point(0, 110)
        Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblParentIdNo.Name = "lblParentIdNo"
        Me.lblParentIdNo.Size = New System.Drawing.Size(190, 24)
        Me.lblParentIdNo.TabIndex = 163
        Me.lblParentIdNo.Text = "Parent Account"
        Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblParentIdNo.Translatable = True
        '
        'txtDepartmentNameAra
        '
        Me.txtDepartmentNameAra.BackColor = System.Drawing.Color.White
        Me.txtDepartmentNameAra.BegFindValue = Nothing
        Me.txtDepartmentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentNameAra.ComputedValue = False
        Me.txtDepartmentNameAra.CustomFormat = Nothing
        Me.txtDepartmentNameAra.DataBoundControl = True
        Me.txtDepartmentNameAra.EditingMode = False
        Me.txtDepartmentNameAra.EndFindValue = Nothing
        Me.txtDepartmentNameAra.EnglishControl = Me.txtDepartmentName
        Me.txtDepartmentNameAra.FieldDescription = Nothing
        Me.txtDepartmentNameAra.FieldName = Nothing
        Me.txtDepartmentNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepartmentNameAra.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentNameAra, True)
        Me.txtDepartmentNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDepartmentNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentNameAra.LinkedLabel = Nothing
        Me.txtDepartmentNameAra.Location = New System.Drawing.Point(192, 86)
        Me.txtDepartmentNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentNameAra.MaximumValue = Nothing
        Me.txtDepartmentNameAra.MinimumValue = Nothing
        Me.txtDepartmentNameAra.Name = "txtDepartmentNameAra"
        Me.txtDepartmentNameAra.OldValue = Nothing
        Me.txtDepartmentNameAra.ReadOnly = True
        Me.txtDepartmentNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDepartmentNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepartmentNameAra.Size = New System.Drawing.Size(418, 23)
        Me.txtDepartmentNameAra.TabIndex = 2
        Me.txtDepartmentNameAra.Translatable = False
        Me.txtDepartmentNameAra.ValueIsUnique = True
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.BackColor = System.Drawing.Color.White
        Me.txtDepartmentName.BegFindValue = Nothing
        Me.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentName.ComputedValue = False
        Me.txtDepartmentName.CustomFormat = Nothing
        Me.txtDepartmentName.DataBoundControl = True
        Me.txtDepartmentName.EditingMode = False
        Me.txtDepartmentName.EndFindValue = Nothing
        Me.txtDepartmentName.FieldDescription = Nothing
        Me.txtDepartmentName.FieldName = Nothing
        Me.txtDepartmentName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepartmentName.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentName, True)
        Me.txtDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDepartmentName.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentName.LinkedLabel = Nothing
        Me.txtDepartmentName.Location = New System.Drawing.Point(192, 61)
        Me.txtDepartmentName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentName.MaximumValue = Nothing
        Me.txtDepartmentName.MinimumValue = Nothing
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.OldValue = Nothing
        Me.txtDepartmentName.ReadOnly = True
        Me.txtDepartmentName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepartmentName.Size = New System.Drawing.Size(418, 23)
        Me.txtDepartmentName.TabIndex = 1
        Me.txtDepartmentName.Translatable = False
        Me.txtDepartmentName.ValueIsMandatory = True
        Me.txtDepartmentName.ValueIsUnique = True
        '
        'lblDepartmentNameAra
        '
        Me.lblDepartmentNameAra.DisplayOnly = True
        Me.lblDepartmentNameAra.EditingMode = False
        Me.lblDepartmentNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDepartmentNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentNameAra.Location = New System.Drawing.Point(1, 86)
        Me.lblDepartmentNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentNameAra.Name = "lblDepartmentNameAra"
        Me.lblDepartmentNameAra.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentNameAra.TabIndex = 168
        Me.lblDepartmentNameAra.Text = "Department Name (Arabic)"
        Me.lblDepartmentNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDepartmentNameAra.Translatable = True
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.DisplayOnly = True
        Me.lblDepartmentName.EditingMode = False
        Me.lblDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDepartmentName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentName.Location = New System.Drawing.Point(1, 61)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentName.TabIndex = 167
        Me.lblDepartmentName.Text = "Department Name"
        Me.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDepartmentName.Translatable = True
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.BackColor = System.Drawing.Color.White
        Me.txtDepartmentCode.BegFindValue = Nothing
        Me.txtDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentCode.ComputedValue = False
        Me.txtDepartmentCode.CustomFormat = Nothing
        Me.txtDepartmentCode.DataBoundControl = True
        Me.txtDepartmentCode.EditingMode = False
        Me.txtDepartmentCode.EndFindValue = Nothing
        Me.txtDepartmentCode.FieldDescription = Nothing
        Me.txtDepartmentCode.FieldName = Nothing
        Me.txtDepartmentCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepartmentCode.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentCode, True)
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDepartmentCode.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentCode.LinkedLabel = Nothing
        Me.txtDepartmentCode.Location = New System.Drawing.Point(192, 36)
        Me.txtDepartmentCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentCode.MaximumValue = Nothing
        Me.txtDepartmentCode.MinimumValue = Nothing
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.OldValue = Nothing
        Me.txtDepartmentCode.ReadOnly = True
        Me.txtDepartmentCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepartmentCode.Size = New System.Drawing.Size(62, 23)
        Me.txtDepartmentCode.TabIndex = 0
        Me.txtDepartmentCode.Translatable = False
        Me.txtDepartmentCode.ValueIsMandatory = True
        Me.txtDepartmentCode.ValueIsUnique = True
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.DisplayOnly = True
        Me.lblDepartmentCode.EditingMode = False
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblDepartmentCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentCode.Location = New System.Drawing.Point(1, 36)
        Me.lblDepartmentCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentCode.TabIndex = 166
        Me.lblDepartmentCode.Text = "Department Code"
        Me.lblDepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDepartmentCode.Translatable = True
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
        Me.TxtIdNo.FindEnabled = True
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(192, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = True
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 160
        Me.TxtIdNo.TabStop = False
        Me.TxtIdNo.Translatable = False
        Me.TxtIdNo.ValueIsNumeric = True
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = True
        Me.lblIdNo.EditingMode = False
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(189, 23)
        Me.lblIdNo.TabIndex = 165
        Me.lblIdNo.Text = "Department ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = True
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentCode)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentCode)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentName)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentName)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentNameAra)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentNameAra)
        Me.CFlowLayout1.Controls.Add(Me.lblParentIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacParentIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblRevCostCenterIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacRevCostCenterIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblNotes)
        Me.CFlowLayout1.Controls.Add(Me.txtNotes)
        Me.CFlowLayout1.Controls.Add(Me.CButton1)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.MaximumSize = New System.Drawing.Size(631, 0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.CFlowLayout1.Size = New System.Drawing.Size(631, 397)
        Me.CFlowLayout1.TabIndex = 17
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = False
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(3, 227)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(90, 25)
        Me.CButton1.TabIndex = 172
        Me.CButton1.Text = "CheckData"
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BTextBox1)
        Me.Controls.Add(Me.CTextBox1)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.Controls.SetChildIndex(Me.CTextBox1, 0)
        Me.Controls.SetChildIndex(Me.BTextBox1, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents BTextBox1 As Libraries.BaseControlsLibrary.BTextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents lblIdNo As CLabel
    Friend WithEvents TxtIdNo As CTextBox
    Friend WithEvents lblDepartmentCode As CLabel
    Friend WithEvents txtDepartmentCode As CTextBox
    Friend WithEvents lblDepartmentName As CLabel
    Friend WithEvents txtDepartmentName As CTextBox
    Friend WithEvents lblDepartmentNameAra As CLabel
    Friend WithEvents txtDepartmentNameAra As CTextBoxArabic
    Friend WithEvents lblParentIdNo As CLabel
    Friend WithEvents cacParentIdNo As CaComboBox
    Friend WithEvents lblRevCostCenterIdNo As CLabel
    Friend WithEvents cacRevCostCenterIdNo As CaComboBox
    Friend WithEvents lblNotes As CLabel
    Friend WithEvents txtNotes As CTextBox
    Friend WithEvents CButton1 As CButton
End Class
