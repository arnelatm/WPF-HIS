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
        Me.cboDefaultPaperSource = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblDefaultPaperSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDefaultPaperSize = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblDefaultPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDefaultPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
        Me.floDataDisplay.Controls.Add(Me.cboDefaultPaperSource)
        Me.floDataDisplay.Controls.Add(Me.LblDefaultPaperSize)
        Me.floDataDisplay.Controls.Add(Me.cboDefaultPaperSize)
        Me.floDataDisplay.Controls.Add(Me.LblDefaultPaperOrientation)
        Me.floDataDisplay.Controls.Add(Me.cboDefaultPaperOrientation)
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
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.Translatable = false
        '
        'btnCheckPrinter
        '
        Me.btnCheckPrinter.DesignerSelected = false
        Me.floDataDisplay.SetFlowBreak(Me.btnCheckPrinter, true)
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
        Me.lblPrinterCode.DisplayOnly = true
        Me.lblPrinterCode.EditingMode = false
        Me.lblPrinterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterCode, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblPrinterCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrinterCode.Location = New System.Drawing.Point(11, 42)
        Me.lblPrinterCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrinterCode.Name = "lblPrinterCode"
        Me.lblPrinterCode.Size = New System.Drawing.Size(183, 23)
        Me.lblPrinterCode.TabIndex = 157
        Me.lblPrinterCode.Text = "Printer Code"
        Me.lblPrinterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrinterCode.Translatable = true
        '
        'txtPrinterCode
        '
        Me.txtPrinterCode.BackColor = System.Drawing.Color.White
        Me.txtPrinterCode.BegFindValue = Nothing
        Me.txtPrinterCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrinterCode.ComputedValue = false
        Me.txtPrinterCode.CustomFormat = Nothing
        Me.txtPrinterCode.DataBoundControl = true
        Me.txtPrinterCode.EditingMode = true
        Me.txtPrinterCode.EndFindValue = Nothing
        Me.txtPrinterCode.FieldDescription = Nothing
        Me.txtPrinterCode.FieldName = Nothing
        Me.txtPrinterCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPrinterCode.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPrinterCode, true)
        Me.txtPrinterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPrinterCode.ForeColor = System.Drawing.Color.Black
        Me.txtPrinterCode.LinkedLabel = Me.lblPrinterName
        Me.txtPrinterCode.Location = New System.Drawing.Point(196, 42)
        Me.txtPrinterCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPrinterCode.MaximumValue = Nothing
        Me.txtPrinterCode.MinimumValue = Nothing
        Me.txtPrinterCode.Name = "txtPrinterCode"
        Me.txtPrinterCode.OldValue = "0"
        Me.txtPrinterCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPrinterCode.Size = New System.Drawing.Size(108, 23)
        Me.txtPrinterCode.TabIndex = 1
        Me.txtPrinterCode.Translatable = false
        '
        'lblPrinterName
        '
        Me.lblPrinterName.DisplayOnly = true
        Me.lblPrinterName.EditingMode = false
        Me.lblPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblPrinterName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrinterName.Location = New System.Drawing.Point(11, 67)
        Me.lblPrinterName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrinterName.Name = "lblPrinterName"
        Me.lblPrinterName.Size = New System.Drawing.Size(183, 23)
        Me.lblPrinterName.TabIndex = 165
        Me.lblPrinterName.Text = "Printer Name"
        Me.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrinterName.Translatable = true
        '
        'cboPrinterName
        '
        Me.cboPrinterName.AlwaysEditable = false
        Me.cboPrinterName.BackColor = System.Drawing.Color.White
        Me.cboPrinterName.BegFindValue = Nothing
        Me.cboPrinterName.ChangingSearchValueOnly = false
        Me.cboPrinterName.CurrentSearchTerm = ""
        Me.cboPrinterName.DataValue = Nothing
        Me.cboPrinterName.DefaultValue = Nothing
        Me.cboPrinterName.DisplayMember = "Name"
        Me.cboPrinterName.EditingMode = true
        Me.cboPrinterName.EndFindValue = Nothing
        Me.cboPrinterName.FieldDescription = Nothing
        Me.cboPrinterName.FieldName = Nothing
        Me.cboPrinterName.FilterRule = Nothing
        Me.cboPrinterName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPrinterName.FindEnabled = false
        Me.cboPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPrinterName.ForeColor = System.Drawing.Color.Black
        Me.cboPrinterName.FormattingEnabled = true
        Me.cboPrinterName.HideWhenNotEditingOrAdding = false
        Me.cboPrinterName.IgnoreCase = false
        Me.cboPrinterName.IntegralHeight = false
        Me.cboPrinterName.LimitToList = false
        Me.cboPrinterName.LinkedLabel = Nothing
        Me.cboPrinterName.Location = New System.Drawing.Point(196, 67)
        Me.cboPrinterName.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPrinterName.Name = "cboPrinterName"
        Me.cboPrinterName.OldValue = 0
        Me.cboPrinterName.OriginalDataSource = Nothing
        Me.cboPrinterName.OriginalList = Nothing
        Me.cboPrinterName.OverrideDropDownStyleList = false
        Me.cboPrinterName.PreviousSearchTerm = Nothing
        Me.cboPrinterName.PropertySelector = Nothing
        Me.cboPrinterName.ReadOnlyCombo = false
        Me.cboPrinterName.Size = New System.Drawing.Size(423, 24)
        Me.cboPrinterName.SuggestBoxHeight = 200
        Me.cboPrinterName.SuggestListOrderRule = Nothing
        Me.cboPrinterName.TabIndex = 179
        Me.cboPrinterName.TextToSearch = Nothing
        Me.cboPrinterName.Translatable = false
        Me.cboPrinterName.ValueIsMandatory = false
        Me.cboPrinterName.ValueIsNullable = false
        Me.cboPrinterName.ValueIsNumeric = false
        Me.cboPrinterName.ValueMember = "IdNo"
        '
        'lblHostName
        '
        Me.lblHostName.DisplayOnly = true
        Me.lblHostName.EditingMode = false
        Me.lblHostName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblHostName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblHostName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHostName.Location = New System.Drawing.Point(11, 93)
        Me.lblHostName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblHostName.Name = "lblHostName"
        Me.lblHostName.Size = New System.Drawing.Size(183, 23)
        Me.lblHostName.TabIndex = 176
        Me.lblHostName.Text = "Host or IP Name"
        Me.lblHostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHostName.Translatable = true
        '
        'txtHostOrIpName
        '
        Me.txtHostOrIpName.BackColor = System.Drawing.Color.White
        Me.txtHostOrIpName.BegFindValue = Nothing
        Me.txtHostOrIpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHostOrIpName.ComputedValue = false
        Me.txtHostOrIpName.CustomFormat = Nothing
        Me.txtHostOrIpName.DataBoundControl = true
        Me.txtHostOrIpName.EditingMode = true
        Me.txtHostOrIpName.EndFindValue = Nothing
        Me.txtHostOrIpName.FieldDescription = Nothing
        Me.txtHostOrIpName.FieldName = Nothing
        Me.txtHostOrIpName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtHostOrIpName.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.txtHostOrIpName, true)
        Me.txtHostOrIpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtHostOrIpName.ForeColor = System.Drawing.Color.Black
        Me.txtHostOrIpName.LinkedLabel = Me.lblHostName
        Me.txtHostOrIpName.Location = New System.Drawing.Point(196, 93)
        Me.txtHostOrIpName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtHostOrIpName.MaximumValue = Nothing
        Me.txtHostOrIpName.MinimumValue = Nothing
        Me.txtHostOrIpName.Name = "txtHostOrIpName"
        Me.txtHostOrIpName.OldValue = "0"
        Me.txtHostOrIpName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtHostOrIpName.Size = New System.Drawing.Size(423, 23)
        Me.txtHostOrIpName.TabIndex = 3
        Me.txtHostOrIpName.Translatable = false
        '
        'LblDefaultPaperSource
        '
        Me.LblDefaultPaperSource.DisplayOnly = true
        Me.LblDefaultPaperSource.EditingMode = false
        Me.LblDefaultPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblDefaultPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblDefaultPaperSource.Location = New System.Drawing.Point(11, 118)
        Me.LblDefaultPaperSource.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperSource.Name = "LblDefaultPaperSource"
        Me.LblDefaultPaperSource.Size = New System.Drawing.Size(183, 23)
        Me.LblDefaultPaperSource.TabIndex = 159
        Me.LblDefaultPaperSource.Text = "Default Paper Source"
        Me.LblDefaultPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperSource.Translatable = true
        '
        'cboDefaultPaperSource
        '
        Me.cboDefaultPaperSource.AlwaysEditable = false
        Me.cboDefaultPaperSource.BackColor = System.Drawing.Color.White
        Me.cboDefaultPaperSource.BegFindValue = Nothing
        Me.cboDefaultPaperSource.ChangingSearchValueOnly = false
        Me.cboDefaultPaperSource.CurrentSearchTerm = ""
        Me.cboDefaultPaperSource.DataValue = Nothing
        Me.cboDefaultPaperSource.DefaultValue = Nothing
        Me.cboDefaultPaperSource.DisplayMember = "Name"
        Me.cboDefaultPaperSource.EditingMode = true
        Me.cboDefaultPaperSource.EndFindValue = Nothing
        Me.cboDefaultPaperSource.FieldDescription = Nothing
        Me.cboDefaultPaperSource.FieldName = Nothing
        Me.cboDefaultPaperSource.FilterRule = Nothing
        Me.cboDefaultPaperSource.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDefaultPaperSource.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboDefaultPaperSource, true)
        Me.cboDefaultPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDefaultPaperSource.ForeColor = System.Drawing.Color.Black
        Me.cboDefaultPaperSource.FormattingEnabled = true
        Me.cboDefaultPaperSource.HideWhenNotEditingOrAdding = false
        Me.cboDefaultPaperSource.IgnoreCase = false
        Me.cboDefaultPaperSource.IntegralHeight = false
        Me.cboDefaultPaperSource.LimitToList = false
        Me.cboDefaultPaperSource.LinkedLabel = Me.LblDefaultPaperSource
        Me.cboDefaultPaperSource.Location = New System.Drawing.Point(196, 118)
        Me.cboDefaultPaperSource.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDefaultPaperSource.Name = "cboDefaultPaperSource"
        Me.cboDefaultPaperSource.OldValue = 0
        Me.cboDefaultPaperSource.OriginalDataSource = Nothing
        Me.cboDefaultPaperSource.OriginalList = Nothing
        Me.cboDefaultPaperSource.OverrideDropDownStyleList = false
        Me.cboDefaultPaperSource.PreviousSearchTerm = Nothing
        Me.cboDefaultPaperSource.PropertySelector = Nothing
        Me.cboDefaultPaperSource.ReadOnlyCombo = false
        Me.cboDefaultPaperSource.Size = New System.Drawing.Size(221, 24)
        Me.cboDefaultPaperSource.SuggestBoxHeight = 200
        Me.cboDefaultPaperSource.SuggestListOrderRule = Nothing
        Me.cboDefaultPaperSource.TabIndex = 4
        Me.cboDefaultPaperSource.TextToSearch = Nothing
        Me.cboDefaultPaperSource.Translatable = false
        Me.cboDefaultPaperSource.ValueIsMandatory = false
        Me.cboDefaultPaperSource.ValueIsNullable = false
        Me.cboDefaultPaperSource.ValueIsNumeric = false
        Me.cboDefaultPaperSource.ValueMember = "IdNo"
        '
        'LblDefaultPaperSize
        '
        Me.LblDefaultPaperSize.DisplayOnly = true
        Me.LblDefaultPaperSize.EditingMode = false
        Me.LblDefaultPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblDefaultPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblDefaultPaperSize.Location = New System.Drawing.Point(11, 144)
        Me.LblDefaultPaperSize.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperSize.Name = "LblDefaultPaperSize"
        Me.LblDefaultPaperSize.Size = New System.Drawing.Size(183, 23)
        Me.LblDefaultPaperSize.TabIndex = 161
        Me.LblDefaultPaperSize.Text = "Default Paper Size"
        Me.LblDefaultPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperSize.Translatable = true
        '
        'cboDefaultPaperSize
        '
        Me.cboDefaultPaperSize.AlwaysEditable = false
        Me.cboDefaultPaperSize.BackColor = System.Drawing.Color.White
        Me.cboDefaultPaperSize.BegFindValue = Nothing
        Me.cboDefaultPaperSize.ChangingSearchValueOnly = false
        Me.cboDefaultPaperSize.CurrentSearchTerm = ""
        Me.cboDefaultPaperSize.DataValue = Nothing
        Me.cboDefaultPaperSize.DefaultValue = Nothing
        Me.cboDefaultPaperSize.DisplayMember = "Name"
        Me.cboDefaultPaperSize.EditingMode = true
        Me.cboDefaultPaperSize.EndFindValue = Nothing
        Me.cboDefaultPaperSize.FieldDescription = Nothing
        Me.cboDefaultPaperSize.FieldName = Nothing
        Me.cboDefaultPaperSize.FilterRule = Nothing
        Me.cboDefaultPaperSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDefaultPaperSize.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboDefaultPaperSize, true)
        Me.cboDefaultPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDefaultPaperSize.ForeColor = System.Drawing.Color.Black
        Me.cboDefaultPaperSize.FormattingEnabled = true
        Me.cboDefaultPaperSize.HideWhenNotEditingOrAdding = false
        Me.cboDefaultPaperSize.IgnoreCase = false
        Me.cboDefaultPaperSize.IntegralHeight = false
        Me.cboDefaultPaperSize.LimitToList = false
        Me.cboDefaultPaperSize.LinkedLabel = Me.LblDefaultPaperSize
        Me.cboDefaultPaperSize.Location = New System.Drawing.Point(196, 144)
        Me.cboDefaultPaperSize.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDefaultPaperSize.Name = "cboDefaultPaperSize"
        Me.cboDefaultPaperSize.OldValue = 0
        Me.cboDefaultPaperSize.OriginalDataSource = Nothing
        Me.cboDefaultPaperSize.OriginalList = Nothing
        Me.cboDefaultPaperSize.OverrideDropDownStyleList = false
        Me.cboDefaultPaperSize.PreviousSearchTerm = Nothing
        Me.cboDefaultPaperSize.PropertySelector = Nothing
        Me.cboDefaultPaperSize.ReadOnlyCombo = false
        Me.cboDefaultPaperSize.Size = New System.Drawing.Size(221, 24)
        Me.cboDefaultPaperSize.SuggestBoxHeight = 200
        Me.cboDefaultPaperSize.SuggestListOrderRule = Nothing
        Me.cboDefaultPaperSize.TabIndex = 5
        Me.cboDefaultPaperSize.TextToSearch = Nothing
        Me.cboDefaultPaperSize.Translatable = false
        Me.cboDefaultPaperSize.ValueIsMandatory = false
        Me.cboDefaultPaperSize.ValueIsNullable = false
        Me.cboDefaultPaperSize.ValueIsNumeric = true
        Me.cboDefaultPaperSize.ValueMember = "IdNo"
        '
        'LblDefaultPaperOrientation
        '
        Me.LblDefaultPaperOrientation.DisplayOnly = true
        Me.LblDefaultPaperOrientation.EditingMode = false
        Me.LblDefaultPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblDefaultPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblDefaultPaperOrientation.Location = New System.Drawing.Point(11, 170)
        Me.LblDefaultPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperOrientation.Name = "LblDefaultPaperOrientation"
        Me.LblDefaultPaperOrientation.Size = New System.Drawing.Size(183, 23)
        Me.LblDefaultPaperOrientation.TabIndex = 163
        Me.LblDefaultPaperOrientation.Text = "Default Paper Orientation"
        Me.LblDefaultPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperOrientation.Translatable = true
        '
        'cboDefaultPaperOrientation
        '
        Me.cboDefaultPaperOrientation.AlwaysEditable = false
        Me.cboDefaultPaperOrientation.BackColor = System.Drawing.Color.White
        Me.cboDefaultPaperOrientation.BegFindValue = Nothing
        Me.cboDefaultPaperOrientation.ChangingSearchValueOnly = false
        Me.cboDefaultPaperOrientation.CurrentSearchTerm = ""
        Me.cboDefaultPaperOrientation.DataValue = Nothing
        Me.cboDefaultPaperOrientation.DefaultValue = Nothing
        Me.cboDefaultPaperOrientation.DisplayMember = "Name"
        Me.cboDefaultPaperOrientation.EditingMode = true
        Me.cboDefaultPaperOrientation.EndFindValue = Nothing
        Me.cboDefaultPaperOrientation.FieldDescription = Nothing
        Me.cboDefaultPaperOrientation.FieldName = Nothing
        Me.cboDefaultPaperOrientation.FilterRule = Nothing
        Me.cboDefaultPaperOrientation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDefaultPaperOrientation.FindEnabled = false
        Me.cboDefaultPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDefaultPaperOrientation.ForeColor = System.Drawing.Color.Black
        Me.cboDefaultPaperOrientation.FormattingEnabled = true
        Me.cboDefaultPaperOrientation.HideWhenNotEditingOrAdding = false
        Me.cboDefaultPaperOrientation.IgnoreCase = false
        Me.cboDefaultPaperOrientation.IntegralHeight = false
        Me.cboDefaultPaperOrientation.LimitToList = false
        Me.cboDefaultPaperOrientation.LinkedLabel = Me.LblDefaultPaperOrientation
        Me.cboDefaultPaperOrientation.Location = New System.Drawing.Point(196, 170)
        Me.cboDefaultPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDefaultPaperOrientation.Name = "cboDefaultPaperOrientation"
        Me.cboDefaultPaperOrientation.OldValue = 0
        Me.cboDefaultPaperOrientation.OriginalDataSource = Nothing
        Me.cboDefaultPaperOrientation.OriginalList = Nothing
        Me.cboDefaultPaperOrientation.OverrideDropDownStyleList = false
        Me.cboDefaultPaperOrientation.PreviousSearchTerm = Nothing
        Me.cboDefaultPaperOrientation.PropertySelector = Nothing
        Me.cboDefaultPaperOrientation.ReadOnlyCombo = false
        Me.cboDefaultPaperOrientation.Size = New System.Drawing.Size(221, 24)
        Me.cboDefaultPaperOrientation.SuggestBoxHeight = 200
        Me.cboDefaultPaperOrientation.SuggestListOrderRule = Nothing
        Me.cboDefaultPaperOrientation.TabIndex = 6
        Me.cboDefaultPaperOrientation.TextToSearch = Nothing
        Me.cboDefaultPaperOrientation.Translatable = false
        Me.cboDefaultPaperOrientation.ValueIsMandatory = false
        Me.cboDefaultPaperOrientation.ValueIsNullable = false
        Me.cboDefaultPaperOrientation.ValueIsNumeric = false
        Me.cboDefaultPaperOrientation.ValueMember = "IdNo"
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
        Friend WithEvents cboDefaultPaperSource As CaComboBox
        Friend WithEvents cboDefaultPaperSize As CaComboBox
        Friend WithEvents cboDefaultPaperOrientation As CaComboBox
        Friend WithEvents txtPrinterCode As CTextBox
        Friend WithEvents lblHostName As CLabel
        Friend WithEvents txtHostOrIpName As CTextBox
        Friend WithEvents btnCheckPrinter As CButton
        Friend WithEvents cboPrinterName As CaComboBox
    End Class
End Namespace