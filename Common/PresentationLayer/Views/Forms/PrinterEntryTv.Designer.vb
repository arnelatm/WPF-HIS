Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PrinterEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrinterEntryTv))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnCheckPrinter = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblPrinterCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPrinterCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPrinterName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPrinterName = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblHostName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtHostOrIpName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.LblDefaultPaperSource = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaperSource = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblDefaultPaperSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaperSize = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblDefaultPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
        Me.SplitContainer1.Size = New System.Drawing.Size(955, 329)
        Me.SplitContainer1.SplitterDistance = 315
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(315, 329)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = ""
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSize = true
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.btnCheckPrinter)
        Me.floDataDisplay.Controls.Add(Me.lblPrinterCode)
        Me.floDataDisplay.Controls.Add(Me.txtPrinterCode)
        Me.floDataDisplay.Controls.Add(Me.lblPrinterName)
        Me.floDataDisplay.Controls.Add(Me.cboPrinterName)
        Me.floDataDisplay.Controls.Add(Me.lblHostName)
        Me.floDataDisplay.Controls.Add(Me.txtHostOrIpName)
        Me.floDataDisplay.Controls.Add(Me.LblDefaultPaperSource)
        Me.floDataDisplay.Controls.Add(Me.cboPaperSource)
        Me.floDataDisplay.Controls.Add(Me.LblDefaultPaperSize)
        Me.floDataDisplay.Controls.Add(Me.cboPaperSize)
        Me.floDataDisplay.Controls.Add(Me.LblDefaultPaperOrientation)
        Me.floDataDisplay.Controls.Add(Me.cboPaperOrientation)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(440, 300)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(630, 329)
        Me.floDataDisplay.TabIndex = 148
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(183, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Printer ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(196, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'btnCheckPrinter
            '
            Me.btnCheckPrinter.DesignerSelected = False
            Me.floDataDisplay.SetFlowBreak(Me.btnCheckPrinter, True)
            Me.btnCheckPrinter.ImageIndex = 0
            Me.btnCheckPrinter.Location = New System.Drawing.Point(262, 13)
            Me.btnCheckPrinter.Name = "btnCheckPrinter"
            Me.btnCheckPrinter.OriginalImageName = Nothing
            Me.btnCheckPrinter.SecurityKey = ""
            Me.btnCheckPrinter.Size = New System.Drawing.Size(128, 25)
            Me.btnCheckPrinter.TabIndex = 178
            Me.btnCheckPrinter.Text = "Check Printer"
            '
            'lblPrinterCode
            '
            Me.lblPrinterCode.DisplayOnly = True
            Me.lblPrinterCode.EditingMode = False
            Me.lblPrinterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterCode, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrinterCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrinterCode.Location = New System.Drawing.Point(11, 42)
            Me.lblPrinterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrinterCode.Name = "lblPrinterCode"
            Me.lblPrinterCode.Size = New System.Drawing.Size(183, 23)
            Me.lblPrinterCode.TabIndex = 157
            Me.lblPrinterCode.Text = "Printer Code"
            Me.lblPrinterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrinterCode.Translatable = True
            '
            'txtPrinterCode
            '
            Me.txtPrinterCode.BackColor = System.Drawing.Color.White
            Me.txtPrinterCode.BegFindValue = Nothing
            Me.txtPrinterCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrinterCode.ComputedValue = False
            Me.txtPrinterCode.CustomFormat = Nothing
            Me.txtPrinterCode.DataBoundControl = True
            Me.txtPrinterCode.EditingMode = True
            Me.txtPrinterCode.EndFindValue = Nothing
            Me.txtPrinterCode.FieldDescription = Nothing
            Me.txtPrinterCode.FieldName = Nothing
            Me.txtPrinterCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrinterCode.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtPrinterCode, True)
            Me.txtPrinterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrinterCode.ForeColor = System.Drawing.Color.Black
            Me.txtPrinterCode.LinkedLabel = Me.lblPrinterName
            Me.txtPrinterCode.Location = New System.Drawing.Point(196, 42)
            Me.txtPrinterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrinterCode.MaximumValue = Nothing
            Me.txtPrinterCode.MinimumValue = Nothing
            Me.txtPrinterCode.Name = "txtPrinterCode"
            Me.txtPrinterCode.OldValue = "0"
            Me.txtPrinterCode.OverrideMaxLength = 0
            Me.txtPrinterCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrinterCode.Size = New System.Drawing.Size(108, 23)
            Me.txtPrinterCode.TabIndex = 1
            Me.txtPrinterCode.Translatable = False
            '
            'lblPrinterName
            '
            Me.lblPrinterName.DisplayOnly = True
            Me.lblPrinterName.EditingMode = False
            Me.lblPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrinterName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrinterName.Location = New System.Drawing.Point(11, 67)
            Me.lblPrinterName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrinterName.Name = "lblPrinterName"
            Me.lblPrinterName.Size = New System.Drawing.Size(183, 23)
            Me.lblPrinterName.TabIndex = 165
            Me.lblPrinterName.Text = "Printer Name"
            Me.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrinterName.Translatable = True
            '
            'cboPrinterName
            '
            Me.cboPrinterName.BackColor = System.Drawing.Color.White
            Me.cboPrinterName.BegFindValue = Nothing
            Me.cboPrinterName.ChangingSearchValueOnly = False
            Me.cboPrinterName.CurrentSearchTerm = ""
            Me.cboPrinterName.DataValue = Nothing
            Me.cboPrinterName.DefaultValue = Nothing
            Me.cboPrinterName.DisplayMember = "Name"
            Me.cboPrinterName.EditingMode = True
            Me.cboPrinterName.EndFindValue = Nothing
            Me.cboPrinterName.FieldDescription = Nothing
            Me.cboPrinterName.FieldName = Nothing
            Me.cboPrinterName.FilterRule = Nothing
            Me.cboPrinterName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPrinterName.FindEnabled = False
            Me.cboPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPrinterName.ForeColor = System.Drawing.Color.Black
            Me.cboPrinterName.FormattingEnabled = True
            Me.cboPrinterName.HideWhenNotEditingOrAdding = False
            Me.cboPrinterName.IgnoreCase = False
            Me.cboPrinterName.IntegralHeight = False
            Me.cboPrinterName.LimitToList = False
            Me.cboPrinterName.LinkedLabel = Nothing
            Me.cboPrinterName.Location = New System.Drawing.Point(196, 67)
            Me.cboPrinterName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrinterName.Name = "cboPrinterName"
            Me.cboPrinterName.OldValue = 0
            Me.cboPrinterName.OriginalDataSource = Nothing
            Me.cboPrinterName.OriginalList = Nothing
            Me.cboPrinterName.OverrideDropDownStyleList = False
            Me.cboPrinterName.PreviousSearchTerm = Nothing
            Me.cboPrinterName.PropertySelector = Nothing
            Me.cboPrinterName.ReadOnlyCombo = False
            Me.cboPrinterName.Size = New System.Drawing.Size(423, 24)
            Me.cboPrinterName.SuggestBoxHeight = 200
            Me.cboPrinterName.SuggestListOrderRule = Nothing
            Me.cboPrinterName.TabIndex = 179
            Me.cboPrinterName.TextToSearch = Nothing
            Me.cboPrinterName.Translatable = False
            Me.cboPrinterName.ValueIsMandatory = False
            Me.cboPrinterName.ValueIsNullable = False
            Me.cboPrinterName.ValueIsNumeric = False
            Me.cboPrinterName.ValueMember = "IdNo"
            '
            'lblHostName
            '
            Me.lblHostName.DisplayOnly = True
            Me.lblHostName.EditingMode = False
            Me.lblHostName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblHostName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblHostName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblHostName.Location = New System.Drawing.Point(11, 93)
            Me.lblHostName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblHostName.Name = "lblHostName"
            Me.lblHostName.Size = New System.Drawing.Size(183, 23)
            Me.lblHostName.TabIndex = 176
            Me.lblHostName.Text = "Host or IP Name"
            Me.lblHostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblHostName.Translatable = True
            '
            'txtHostOrIpName
            '
            Me.txtHostOrIpName.BackColor = System.Drawing.Color.White
            Me.txtHostOrIpName.BegFindValue = Nothing
            Me.txtHostOrIpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtHostOrIpName.ComputedValue = False
            Me.txtHostOrIpName.CustomFormat = Nothing
            Me.txtHostOrIpName.DataBoundControl = True
            Me.txtHostOrIpName.EditingMode = True
            Me.txtHostOrIpName.EndFindValue = Nothing
            Me.txtHostOrIpName.FieldDescription = Nothing
            Me.txtHostOrIpName.FieldName = Nothing
            Me.txtHostOrIpName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtHostOrIpName.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtHostOrIpName, True)
            Me.txtHostOrIpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtHostOrIpName.ForeColor = System.Drawing.Color.Black
            Me.txtHostOrIpName.LinkedLabel = Me.lblHostName
            Me.txtHostOrIpName.Location = New System.Drawing.Point(196, 93)
            Me.txtHostOrIpName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtHostOrIpName.MaximumValue = Nothing
            Me.txtHostOrIpName.MinimumValue = Nothing
            Me.txtHostOrIpName.Name = "txtHostOrIpName"
            Me.txtHostOrIpName.OldValue = "0"
            Me.txtHostOrIpName.OverrideMaxLength = 0
            Me.txtHostOrIpName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtHostOrIpName.Size = New System.Drawing.Size(423, 23)
            Me.txtHostOrIpName.TabIndex = 3
            Me.txtHostOrIpName.Translatable = False
            '
            'LblDefaultPaperSource
            '
            Me.LblDefaultPaperSource.DisplayOnly = True
            Me.LblDefaultPaperSource.EditingMode = False
            Me.LblDefaultPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblDefaultPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblDefaultPaperSource.Location = New System.Drawing.Point(11, 118)
            Me.LblDefaultPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.LblDefaultPaperSource.Name = "LblDefaultPaperSource"
            Me.LblDefaultPaperSource.Size = New System.Drawing.Size(183, 23)
            Me.LblDefaultPaperSource.TabIndex = 159
            Me.LblDefaultPaperSource.Text = "Default Paper Source"
            Me.LblDefaultPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblDefaultPaperSource.Translatable = True
            '
            'cboPaperSource
            '
            Me.cboPaperSource.BackColor = System.Drawing.Color.White
            Me.cboPaperSource.BegFindValue = Nothing
            Me.cboPaperSource.ChangingSearchValueOnly = False
            Me.cboPaperSource.CurrentSearchTerm = ""
            Me.cboPaperSource.DataValue = Nothing
            Me.cboPaperSource.DefaultValue = Nothing
            Me.cboPaperSource.DisplayMember = "Name"
            Me.cboPaperSource.EditingMode = True
            Me.cboPaperSource.EndFindValue = Nothing
            Me.cboPaperSource.FieldDescription = Nothing
            Me.cboPaperSource.FieldName = Nothing
            Me.cboPaperSource.FilterRule = Nothing
            Me.cboPaperSource.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaperSource.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboPaperSource, True)
            Me.cboPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaperSource.ForeColor = System.Drawing.Color.Black
            Me.cboPaperSource.FormattingEnabled = True
            Me.cboPaperSource.HideWhenNotEditingOrAdding = False
            Me.cboPaperSource.IgnoreCase = False
            Me.cboPaperSource.IntegralHeight = False
            Me.cboPaperSource.LimitToList = False
            Me.cboPaperSource.LinkedLabel = Me.LblDefaultPaperSource
            Me.cboPaperSource.Location = New System.Drawing.Point(196, 118)
            Me.cboPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperSource.Name = "cboPaperSource"
            Me.cboPaperSource.OldValue = 0
            Me.cboPaperSource.OriginalDataSource = Nothing
            Me.cboPaperSource.OriginalList = Nothing
            Me.cboPaperSource.OverrideDropDownStyleList = False
            Me.cboPaperSource.PreviousSearchTerm = Nothing
            Me.cboPaperSource.PropertySelector = Nothing
            Me.cboPaperSource.ReadOnlyCombo = False
            Me.cboPaperSource.Size = New System.Drawing.Size(221, 24)
            Me.cboPaperSource.SuggestBoxHeight = 200
            Me.cboPaperSource.SuggestListOrderRule = Nothing
            Me.cboPaperSource.TabIndex = 4
            Me.cboPaperSource.TextToSearch = Nothing
            Me.cboPaperSource.Translatable = False
            Me.cboPaperSource.ValueIsMandatory = False
            Me.cboPaperSource.ValueIsNullable = False
            Me.cboPaperSource.ValueIsNumeric = False
            Me.cboPaperSource.ValueMember = "IdNo"
            '
            'LblDefaultPaperSize
            '
            Me.LblDefaultPaperSize.DisplayOnly = True
            Me.LblDefaultPaperSize.EditingMode = False
            Me.LblDefaultPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblDefaultPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblDefaultPaperSize.Location = New System.Drawing.Point(11, 144)
            Me.LblDefaultPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.LblDefaultPaperSize.Name = "LblDefaultPaperSize"
            Me.LblDefaultPaperSize.Size = New System.Drawing.Size(183, 23)
            Me.LblDefaultPaperSize.TabIndex = 161
            Me.LblDefaultPaperSize.Text = "Default Paper Size"
            Me.LblDefaultPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblDefaultPaperSize.Translatable = True
            '
            'cboPaperSize
            '
            Me.cboPaperSize.AlwaysEditable = True
            Me.cboPaperSize.BackColor = System.Drawing.Color.White
            Me.cboPaperSize.BegFindValue = Nothing
            Me.cboPaperSize.ChangingSearchValueOnly = False
            Me.cboPaperSize.CurrentSearchTerm = ""
            Me.cboPaperSize.DataValue = Nothing
            Me.cboPaperSize.DefaultValue = Nothing
            Me.cboPaperSize.DisplayMember = "Name"
            Me.cboPaperSize.EditingMode = True
            Me.cboPaperSize.EndFindValue = Nothing
            Me.cboPaperSize.FieldDescription = Nothing
            Me.cboPaperSize.FieldName = Nothing
            Me.cboPaperSize.FilterRule = Nothing
            Me.cboPaperSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaperSize.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboPaperSize, True)
            Me.cboPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaperSize.ForeColor = System.Drawing.Color.Black
            Me.cboPaperSize.FormattingEnabled = True
            Me.cboPaperSize.HideWhenNotEditingOrAdding = False
            Me.cboPaperSize.IgnoreCase = False
            Me.cboPaperSize.IntegralHeight = False
            Me.cboPaperSize.LimitToList = False
            Me.cboPaperSize.LinkedLabel = Me.LblDefaultPaperSize
            Me.cboPaperSize.Location = New System.Drawing.Point(196, 144)
            Me.cboPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperSize.Name = "cboPaperSize"
            Me.cboPaperSize.OldValue = 0
            Me.cboPaperSize.OriginalDataSource = Nothing
            Me.cboPaperSize.OriginalList = Nothing
            Me.cboPaperSize.OverrideDropDownStyleList = False
            Me.cboPaperSize.PreviousSearchTerm = Nothing
            Me.cboPaperSize.PropertySelector = Nothing
            Me.cboPaperSize.ReadOnlyCombo = False
            Me.cboPaperSize.Size = New System.Drawing.Size(221, 24)
            Me.cboPaperSize.SuggestBoxHeight = 200
            Me.cboPaperSize.SuggestListOrderRule = Nothing
            Me.cboPaperSize.TabIndex = 5
            Me.cboPaperSize.TextToSearch = Nothing
            Me.cboPaperSize.Translatable = False
            Me.cboPaperSize.ValueIsMandatory = False
            Me.cboPaperSize.ValueIsNullable = False
            Me.cboPaperSize.ValueIsNumeric = True
            Me.cboPaperSize.ValueMember = "IdNo"
            '
            'LblDefaultPaperOrientation
            '
            Me.LblDefaultPaperOrientation.DisplayOnly = True
            Me.LblDefaultPaperOrientation.EditingMode = False
            Me.LblDefaultPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblDefaultPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblDefaultPaperOrientation.Location = New System.Drawing.Point(11, 170)
            Me.LblDefaultPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.LblDefaultPaperOrientation.Name = "LblDefaultPaperOrientation"
            Me.LblDefaultPaperOrientation.Size = New System.Drawing.Size(183, 23)
            Me.LblDefaultPaperOrientation.TabIndex = 163
            Me.LblDefaultPaperOrientation.Text = "Default Paper Orientation"
            Me.LblDefaultPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblDefaultPaperOrientation.Translatable = True
            '
            'cboPaperOrientation
            '
            Me.cboPaperOrientation.BackColor = System.Drawing.Color.White
            Me.cboPaperOrientation.BegFindValue = Nothing
            Me.cboPaperOrientation.ChangingSearchValueOnly = False
            Me.cboPaperOrientation.CurrentSearchTerm = ""
        Me.cboPaperOrientation.DataValue = Nothing
        Me.cboPaperOrientation.DefaultValue = Nothing
        Me.cboPaperOrientation.DisplayMember = "Name"
        Me.cboPaperOrientation.EditingMode = true
        Me.cboPaperOrientation.EndFindValue = Nothing
        Me.cboPaperOrientation.FieldDescription = Nothing
        Me.cboPaperOrientation.FieldName = Nothing
        Me.cboPaperOrientation.FilterRule = Nothing
        Me.cboPaperOrientation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPaperOrientation.FindEnabled = false
        Me.cboPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPaperOrientation.ForeColor = System.Drawing.Color.Black
        Me.cboPaperOrientation.FormattingEnabled = true
        Me.cboPaperOrientation.HideWhenNotEditingOrAdding = false
        Me.cboPaperOrientation.IgnoreCase = false
        Me.cboPaperOrientation.IntegralHeight = false
        Me.cboPaperOrientation.LimitToList = false
        Me.cboPaperOrientation.LinkedLabel = Me.LblDefaultPaperOrientation
        Me.cboPaperOrientation.Location = New System.Drawing.Point(196, 170)
        Me.cboPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPaperOrientation.Name = "cboPaperOrientation"
        Me.cboPaperOrientation.OldValue = 0
        Me.cboPaperOrientation.OriginalDataSource = Nothing
        Me.cboPaperOrientation.OriginalList = Nothing
        Me.cboPaperOrientation.OverrideDropDownStyleList = false
        Me.cboPaperOrientation.PreviousSearchTerm = Nothing
        Me.cboPaperOrientation.PropertySelector = Nothing
        Me.cboPaperOrientation.ReadOnlyCombo = false
        Me.cboPaperOrientation.Size = New System.Drawing.Size(221, 24)
        Me.cboPaperOrientation.SuggestBoxHeight = 200
        Me.cboPaperOrientation.SuggestListOrderRule = Nothing
        Me.cboPaperOrientation.TabIndex = 6
        Me.cboPaperOrientation.TextToSearch = Nothing
        Me.cboPaperOrientation.Translatable = false
        Me.cboPaperOrientation.ValueIsMandatory = false
        Me.cboPaperOrientation.ValueIsNullable = false
        Me.cboPaperOrientation.ValueIsNumeric = false
        Me.cboPaperOrientation.ValueMember = "IdNo"
        '
        'PrinterEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(955, 382)
        Me.MinimumSize = New System.Drawing.Size(703, 404)
        Me.Name = "PrinterEntryTv"
        Me.Text = "Printer Maintenance Form"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel2.PerformLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblPrinterCode As CLabel
        Friend WithEvents LblDefaultPaperSource As CLabel
        Friend WithEvents LblDefaultPaperSize As CLabel
        Friend WithEvents LblDefaultPaperOrientation As CLabel
        Friend WithEvents lblPrinterName As CLabel
        Friend WithEvents cboPaperSource As CaComboBox
        Friend WithEvents cboPaperSize As CaComboBox
        Friend WithEvents cboPaperOrientation As CaComboBox
        Friend WithEvents txtPrinterCode As CTextBox
        Friend WithEvents lblHostName As CLabel
        Friend WithEvents txtHostOrIpName As CTextBox
        Friend WithEvents btnCheckPrinter As CButton
        Friend WithEvents cboPrinterName As CaComboBox
    End Class
End Namespace