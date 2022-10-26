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
        Me.txtPrinterName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(896, 329)
        Me.SplitContainer1.SplitterDistance = 296
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(296, 329)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
        Me.floDataDisplay.Controls.Add(Me.txtPrinterName)
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
        Me.floDataDisplay.Size = New System.Drawing.Size(590, 329)
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
        Me.lblIdNo.Size = New System.Drawing.Size(144, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Print Job ID No."
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
        Me.TxtIdNo.Location = New System.Drawing.Point(157, 11)
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
        Me.btnCheckPrinter.Location = New System.Drawing.Point(223, 13)
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
        Me.lblPrinterCode.Size = New System.Drawing.Size(144, 23)
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
        Me.txtPrinterCode.Location = New System.Drawing.Point(157, 42)
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
        Me.lblPrinterName.Size = New System.Drawing.Size(144, 23)
        Me.lblPrinterName.TabIndex = 165
        Me.lblPrinterName.Text = "Printer Name"
        Me.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrinterName.Translatable = true
        '
        'txtPrinterName
        '
        Me.txtPrinterName.BackColor = System.Drawing.Color.White
        Me.txtPrinterName.BegFindValue = Nothing
        Me.txtPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrinterName.ComputedValue = false
        Me.txtPrinterName.CustomFormat = Nothing
        Me.txtPrinterName.DataBoundControl = true
        Me.txtPrinterName.EditingMode = true
        Me.txtPrinterName.EndFindValue = Nothing
        Me.txtPrinterName.FieldDescription = Nothing
        Me.txtPrinterName.FieldName = Nothing
        Me.txtPrinterName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPrinterName.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPrinterName, true)
        Me.txtPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPrinterName.ForeColor = System.Drawing.Color.Black
        Me.txtPrinterName.LinkedLabel = Me.lblPrinterName
        Me.txtPrinterName.Location = New System.Drawing.Point(157, 67)
        Me.txtPrinterName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPrinterName.MaximumValue = Nothing
        Me.txtPrinterName.MinimumValue = Nothing
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.OldValue = "0"
        Me.txtPrinterName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPrinterName.Size = New System.Drawing.Size(423, 23)
        Me.txtPrinterName.TabIndex = 2
        Me.txtPrinterName.Translatable = false
        '
        'lblHostName
        '
        Me.lblHostName.DisplayOnly = true
        Me.lblHostName.EditingMode = false
        Me.lblHostName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblHostName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblHostName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHostName.Location = New System.Drawing.Point(11, 92)
        Me.lblHostName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblHostName.Name = "lblHostName"
        Me.lblHostName.Size = New System.Drawing.Size(144, 23)
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
        Me.txtHostOrIpName.Location = New System.Drawing.Point(157, 92)
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
        Me.LblDefaultPaperSource.Location = New System.Drawing.Point(11, 117)
        Me.LblDefaultPaperSource.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperSource.Name = "LblDefaultPaperSource"
        Me.LblDefaultPaperSource.Size = New System.Drawing.Size(144, 23)
        Me.LblDefaultPaperSource.TabIndex = 159
        Me.LblDefaultPaperSource.Text = "Paper Source"
        Me.LblDefaultPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperSource.Translatable = true
        '
        'cboPaperSource
        '
        Me.cboPaperSource.BackColor = System.Drawing.Color.White
        Me.cboPaperSource.BegFindValue = Nothing
        Me.cboPaperSource.ChangingSearchValueOnly = false
        Me.cboPaperSource.CurrentSearchTerm = ""
        Me.cboPaperSource.DataValue = Nothing
        Me.cboPaperSource.DefaultValue = Nothing
        Me.cboPaperSource.DisplayMember = "Name"
        Me.cboPaperSource.EditingMode = true
        Me.cboPaperSource.EndFindValue = Nothing
        Me.cboPaperSource.FieldDescription = Nothing
        Me.cboPaperSource.FieldName = Nothing
        Me.cboPaperSource.FilterRule = Nothing
        Me.cboPaperSource.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPaperSource.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboPaperSource, true)
        Me.cboPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPaperSource.ForeColor = System.Drawing.Color.Black
        Me.cboPaperSource.FormattingEnabled = true
        Me.cboPaperSource.HideWhenNotEditingOrAdding = false
        Me.cboPaperSource.IgnoreCase = false
        Me.cboPaperSource.IntegralHeight = false
        Me.cboPaperSource.LinkedLabel = Me.LblDefaultPaperSource
        Me.cboPaperSource.Location = New System.Drawing.Point(157, 117)
        Me.cboPaperSource.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPaperSource.Name = "cboPaperSource"
        Me.cboPaperSource.OldValue = 0
        Me.cboPaperSource.OriginalDataSource = Nothing
        Me.cboPaperSource.OriginalList = Nothing
        Me.cboPaperSource.OverrideDropDownStyleList = false
        Me.cboPaperSource.PreviousSearchTerm = Nothing
        Me.cboPaperSource.PropertySelector = Nothing
        Me.cboPaperSource.ReadOnlyCombo = false
        Me.cboPaperSource.Size = New System.Drawing.Size(221, 24)
        Me.cboPaperSource.SuggestBoxHeight = 200
        Me.cboPaperSource.SuggestListOrderRule = Nothing
        Me.cboPaperSource.TabIndex = 4
        Me.cboPaperSource.TextToSearch = Nothing
        Me.cboPaperSource.Translatable = false
        Me.cboPaperSource.ValueIsMandatory = false
        Me.cboPaperSource.ValueIsNullable = false
        Me.cboPaperSource.ValueIsNumeric = false
        Me.cboPaperSource.ValueMember = "IdNo"
        '
        'LblDefaultPaperSize
        '
        Me.LblDefaultPaperSize.DisplayOnly = true
        Me.LblDefaultPaperSize.EditingMode = false
        Me.LblDefaultPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblDefaultPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblDefaultPaperSize.Location = New System.Drawing.Point(11, 143)
        Me.LblDefaultPaperSize.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperSize.Name = "LblDefaultPaperSize"
        Me.LblDefaultPaperSize.Size = New System.Drawing.Size(144, 23)
        Me.LblDefaultPaperSize.TabIndex = 161
        Me.LblDefaultPaperSize.Text = "Paper Size"
        Me.LblDefaultPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperSize.Translatable = true
        '
        'cboPaperSize
        '
        Me.cboPaperSize.BackColor = System.Drawing.Color.White
        Me.cboPaperSize.BegFindValue = Nothing
        Me.cboPaperSize.ChangingSearchValueOnly = false
        Me.cboPaperSize.CurrentSearchTerm = ""
        Me.cboPaperSize.DataValue = Nothing
        Me.cboPaperSize.DefaultValue = Nothing
        Me.cboPaperSize.DisplayMember = "Name"
        Me.cboPaperSize.EditingMode = true
        Me.cboPaperSize.EndFindValue = Nothing
        Me.cboPaperSize.FieldDescription = Nothing
        Me.cboPaperSize.FieldName = Nothing
        Me.cboPaperSize.FilterRule = Nothing
        Me.cboPaperSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPaperSize.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboPaperSize, true)
        Me.cboPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPaperSize.ForeColor = System.Drawing.Color.Black
        Me.cboPaperSize.FormattingEnabled = true
        Me.cboPaperSize.HideWhenNotEditingOrAdding = false
        Me.cboPaperSize.IgnoreCase = false
        Me.cboPaperSize.IntegralHeight = false
        Me.cboPaperSize.LinkedLabel = Me.LblDefaultPaperSource
        Me.cboPaperSize.Location = New System.Drawing.Point(157, 143)
        Me.cboPaperSize.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPaperSize.Name = "cboPaperSize"
        Me.cboPaperSize.OldValue = 0
        Me.cboPaperSize.OriginalDataSource = Nothing
        Me.cboPaperSize.OriginalList = Nothing
        Me.cboPaperSize.OverrideDropDownStyleList = false
        Me.cboPaperSize.PreviousSearchTerm = Nothing
        Me.cboPaperSize.PropertySelector = Nothing
        Me.cboPaperSize.ReadOnlyCombo = false
        Me.cboPaperSize.Size = New System.Drawing.Size(221, 24)
        Me.cboPaperSize.SuggestBoxHeight = 200
        Me.cboPaperSize.SuggestListOrderRule = Nothing
        Me.cboPaperSize.TabIndex = 5
        Me.cboPaperSize.TextToSearch = Nothing
        Me.cboPaperSize.Translatable = false
        Me.cboPaperSize.ValueIsMandatory = false
        Me.cboPaperSize.ValueIsNullable = false
        Me.cboPaperSize.ValueIsNumeric = false
        Me.cboPaperSize.ValueMember = "IdNo"
        '
        'LblDefaultPaperOrientation
        '
        Me.LblDefaultPaperOrientation.DisplayOnly = true
        Me.LblDefaultPaperOrientation.EditingMode = false
        Me.LblDefaultPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblDefaultPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblDefaultPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblDefaultPaperOrientation.Location = New System.Drawing.Point(11, 169)
        Me.LblDefaultPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
        Me.LblDefaultPaperOrientation.Name = "LblDefaultPaperOrientation"
        Me.LblDefaultPaperOrientation.Size = New System.Drawing.Size(144, 23)
        Me.LblDefaultPaperOrientation.TabIndex = 163
        Me.LblDefaultPaperOrientation.Text = "Paper Orientation"
        Me.LblDefaultPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDefaultPaperOrientation.Translatable = true
        '
        'cboPaperOrientation
        '
        Me.cboPaperOrientation.BackColor = System.Drawing.Color.White
        Me.cboPaperOrientation.BegFindValue = Nothing
        Me.cboPaperOrientation.ChangingSearchValueOnly = false
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
        Me.cboPaperOrientation.LinkedLabel = Me.LblDefaultPaperOrientation
        Me.cboPaperOrientation.Location = New System.Drawing.Point(157, 169)
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
        Me.ClientSize = New System.Drawing.Size(896, 382)
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
        Friend WithEvents txtPrinterName As CTextBox
        Friend WithEvents cboPaperSource As CaComboBox
        Friend WithEvents cboPaperSize As CaComboBox
        Friend WithEvents cboPaperOrientation As CaComboBox
        Friend WithEvents txtPrinterCode As CTextBox
        Friend WithEvents lblHostName As CLabel
        Friend WithEvents txtHostOrIpName As CTextBox
        Friend WithEvents btnCheckPrinter As CButton
    End Class
End Namespace