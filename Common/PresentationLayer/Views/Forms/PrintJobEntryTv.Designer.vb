Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PrintJobEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintJobEntryTv))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPrintSetupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPrintSetupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblComputerIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboComputerIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPrinterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPrinterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblPaperSource = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaperSource = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblPaperSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaperSize = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.LblPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(723, 312)
        Me.SplitContainer1.SplitterDistance = 239
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(239, 312)
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
        Me.floDataDisplay.Controls.Add(Me.lblPrintSetupIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboPrintSetupIdNo)
        Me.floDataDisplay.Controls.Add(Me.LblComputerIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboComputerIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblPrinterIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboPrinterIdNo)
        Me.floDataDisplay.Controls.Add(Me.LblPaperSource)
        Me.floDataDisplay.Controls.Add(Me.cboPaperSource)
        Me.floDataDisplay.Controls.Add(Me.LblPaperSize)
        Me.floDataDisplay.Controls.Add(Me.cboPaperSize)
        Me.floDataDisplay.Controls.Add(Me.LblPaperOrientation)
        Me.floDataDisplay.Controls.Add(Me.cboPaperOrientation)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(440, 300)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(474, 312)
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
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
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
        'lblPrintSetupIdNo
        '
        Me.lblPrintSetupIdNo.DisplayOnly = true
        Me.lblPrintSetupIdNo.EditingMode = false
        Me.lblPrintSetupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblPrintSetupIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblPrintSetupIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrintSetupIdNo.Location = New System.Drawing.Point(11, 36)
        Me.lblPrintSetupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrintSetupIdNo.Name = "lblPrintSetupIdNo"
        Me.lblPrintSetupIdNo.Size = New System.Drawing.Size(144, 23)
        Me.lblPrintSetupIdNo.TabIndex = 153
        Me.lblPrintSetupIdNo.Text = "Print Setup Name"
        Me.lblPrintSetupIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrintSetupIdNo.Translatable = true
        '
        'cboPrintSetupIdNo
        '
        Me.cboPrintSetupIdNo.BackColor = System.Drawing.Color.White
        Me.cboPrintSetupIdNo.BegFindValue = Nothing
        Me.cboPrintSetupIdNo.ChangingSearchValueOnly = false
        Me.cboPrintSetupIdNo.CurrentSearchTerm = ""
        Me.cboPrintSetupIdNo.DataValue = Nothing
        Me.cboPrintSetupIdNo.DefaultValue = Nothing
        Me.cboPrintSetupIdNo.DisplayMember = "Name"
        Me.cboPrintSetupIdNo.EditingMode = true
        Me.cboPrintSetupIdNo.EndFindValue = Nothing
        Me.cboPrintSetupIdNo.FieldDescription = Nothing
        Me.cboPrintSetupIdNo.FieldName = Nothing
        Me.cboPrintSetupIdNo.FilterRule = Nothing
        Me.cboPrintSetupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPrintSetupIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboPrintSetupIdNo, true)
        Me.cboPrintSetupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPrintSetupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPrintSetupIdNo.FormattingEnabled = true
        Me.cboPrintSetupIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPrintSetupIdNo.IgnoreCase = false
        Me.cboPrintSetupIdNo.IntegralHeight = false
        Me.cboPrintSetupIdNo.LinkedLabel = Me.lblPrintSetupIdNo
        Me.cboPrintSetupIdNo.Location = New System.Drawing.Point(157, 36)
        Me.cboPrintSetupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPrintSetupIdNo.Name = "cboPrintSetupIdNo"
        Me.cboPrintSetupIdNo.OldValue = 0
        Me.cboPrintSetupIdNo.OriginalDataSource = Nothing
        Me.cboPrintSetupIdNo.OriginalList = Nothing
        Me.cboPrintSetupIdNo.OverrideDropDownStyleList = false
        Me.cboPrintSetupIdNo.PreviousSearchTerm = Nothing
        Me.cboPrintSetupIdNo.PropertySelector = Nothing
        Me.cboPrintSetupIdNo.ReadOnlyCombo = false
        Me.cboPrintSetupIdNo.Size = New System.Drawing.Size(221, 24)
        Me.cboPrintSetupIdNo.SuggestBoxHeight = 200
        Me.cboPrintSetupIdNo.SuggestListOrderRule = Nothing
        Me.cboPrintSetupIdNo.TabIndex = 1
        Me.cboPrintSetupIdNo.TextToSearch = Nothing
        Me.cboPrintSetupIdNo.Translatable = false
        Me.cboPrintSetupIdNo.ValueIsMandatory = false
        Me.cboPrintSetupIdNo.ValueIsNullable = false
        Me.cboPrintSetupIdNo.ValueIsNumeric = false
        Me.cboPrintSetupIdNo.ValueMember = "IdNo"
        '
        'LblComputerIdNo
        '
        Me.LblComputerIdNo.DisplayOnly = true
        Me.LblComputerIdNo.EditingMode = false
        Me.LblComputerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblComputerIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblComputerIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblComputerIdNo.Location = New System.Drawing.Point(11, 62)
        Me.LblComputerIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.LblComputerIdNo.Name = "LblComputerIdNo"
        Me.LblComputerIdNo.Size = New System.Drawing.Size(144, 23)
        Me.LblComputerIdNo.TabIndex = 157
        Me.LblComputerIdNo.Text = "Computer Name"
        Me.LblComputerIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblComputerIdNo.Translatable = true
        '
        'cboComputerIdNo
        '
        Me.cboComputerIdNo.BackColor = System.Drawing.Color.White
        Me.cboComputerIdNo.BegFindValue = Nothing
        Me.cboComputerIdNo.ChangingSearchValueOnly = false
        Me.cboComputerIdNo.CurrentSearchTerm = ""
        Me.cboComputerIdNo.DataValue = Nothing
        Me.cboComputerIdNo.DefaultValue = Nothing
        Me.cboComputerIdNo.DisplayMember = "Name"
        Me.cboComputerIdNo.EditingMode = true
        Me.cboComputerIdNo.EndFindValue = Nothing
        Me.cboComputerIdNo.FieldDescription = Nothing
        Me.cboComputerIdNo.FieldName = Nothing
        Me.cboComputerIdNo.FilterRule = Nothing
        Me.cboComputerIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboComputerIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboComputerIdNo, true)
        Me.cboComputerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboComputerIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboComputerIdNo.FormattingEnabled = true
        Me.cboComputerIdNo.HideWhenNotEditingOrAdding = false
        Me.cboComputerIdNo.IgnoreCase = false
        Me.cboComputerIdNo.IntegralHeight = false
        Me.cboComputerIdNo.LinkedLabel = Me.LblComputerIdNo
        Me.cboComputerIdNo.Location = New System.Drawing.Point(157, 62)
        Me.cboComputerIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboComputerIdNo.Name = "cboComputerIdNo"
        Me.cboComputerIdNo.OldValue = 0
        Me.cboComputerIdNo.OriginalDataSource = Nothing
        Me.cboComputerIdNo.OriginalList = Nothing
        Me.cboComputerIdNo.OverrideDropDownStyleList = false
        Me.cboComputerIdNo.PreviousSearchTerm = Nothing
        Me.cboComputerIdNo.PropertySelector = Nothing
        Me.cboComputerIdNo.ReadOnlyCombo = false
        Me.cboComputerIdNo.Size = New System.Drawing.Size(221, 24)
        Me.cboComputerIdNo.SuggestBoxHeight = 200
        Me.cboComputerIdNo.SuggestListOrderRule = Nothing
        Me.cboComputerIdNo.TabIndex = 2
        Me.cboComputerIdNo.TextToSearch = Nothing
        Me.cboComputerIdNo.Translatable = false
        Me.cboComputerIdNo.ValueIsMandatory = false
        Me.cboComputerIdNo.ValueIsNullable = false
        Me.cboComputerIdNo.ValueIsNumeric = false
        Me.cboComputerIdNo.ValueMember = "IdNo"
        '
        'lblPrinterIdNo
        '
        Me.lblPrinterIdNo.DisplayOnly = true
        Me.lblPrinterIdNo.EditingMode = false
        Me.lblPrinterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblPrinterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrinterIdNo.Location = New System.Drawing.Point(11, 88)
        Me.lblPrinterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrinterIdNo.Name = "lblPrinterIdNo"
        Me.lblPrinterIdNo.Size = New System.Drawing.Size(144, 23)
        Me.lblPrinterIdNo.TabIndex = 165
        Me.lblPrinterIdNo.Text = "Printer Name"
        Me.lblPrinterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrinterIdNo.Translatable = true
        '
        'cboPrinterIdNo
        '
        Me.cboPrinterIdNo.BackColor = System.Drawing.Color.White
        Me.cboPrinterIdNo.BegFindValue = Nothing
        Me.cboPrinterIdNo.ChangingSearchValueOnly = false
        Me.cboPrinterIdNo.CurrentSearchTerm = ""
        Me.cboPrinterIdNo.DataValue = Nothing
        Me.cboPrinterIdNo.DefaultValue = Nothing
        Me.cboPrinterIdNo.DisplayMember = "Name"
        Me.cboPrinterIdNo.EditingMode = true
        Me.cboPrinterIdNo.EndFindValue = Nothing
        Me.cboPrinterIdNo.FieldDescription = Nothing
        Me.cboPrinterIdNo.FieldName = Nothing
        Me.cboPrinterIdNo.FilterRule = Nothing
        Me.cboPrinterIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPrinterIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cboPrinterIdNo, true)
        Me.cboPrinterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPrinterIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPrinterIdNo.FormattingEnabled = true
        Me.cboPrinterIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPrinterIdNo.IgnoreCase = false
        Me.cboPrinterIdNo.IntegralHeight = false
        Me.cboPrinterIdNo.LinkedLabel = Me.lblPrintSetupIdNo
        Me.cboPrinterIdNo.Location = New System.Drawing.Point(157, 88)
        Me.cboPrinterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPrinterIdNo.Name = "cboPrinterIdNo"
        Me.cboPrinterIdNo.OldValue = 0
        Me.cboPrinterIdNo.OriginalDataSource = Nothing
        Me.cboPrinterIdNo.OriginalList = Nothing
        Me.cboPrinterIdNo.OverrideDropDownStyleList = false
        Me.cboPrinterIdNo.PreviousSearchTerm = Nothing
        Me.cboPrinterIdNo.PropertySelector = Nothing
        Me.cboPrinterIdNo.ReadOnlyCombo = false
        Me.cboPrinterIdNo.Size = New System.Drawing.Size(221, 24)
        Me.cboPrinterIdNo.SuggestBoxHeight = 200
        Me.cboPrinterIdNo.SuggestListOrderRule = Nothing
        Me.cboPrinterIdNo.TabIndex = 175
        Me.cboPrinterIdNo.TextToSearch = Nothing
        Me.cboPrinterIdNo.Translatable = false
        Me.cboPrinterIdNo.ValueIsMandatory = false
        Me.cboPrinterIdNo.ValueIsNullable = false
        Me.cboPrinterIdNo.ValueIsNumeric = false
        Me.cboPrinterIdNo.ValueMember = "IdNo"
        '
        'LblPaperSource
        '
        Me.LblPaperSource.DisplayOnly = true
        Me.LblPaperSource.EditingMode = false
        Me.LblPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblPaperSource.Location = New System.Drawing.Point(11, 114)
        Me.LblPaperSource.Margin = New System.Windows.Forms.Padding(1)
        Me.LblPaperSource.Name = "LblPaperSource"
        Me.LblPaperSource.Size = New System.Drawing.Size(144, 23)
        Me.LblPaperSource.TabIndex = 159
        Me.LblPaperSource.Text = "Paper Source"
        Me.LblPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPaperSource.Translatable = true
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
        Me.cboPaperSource.LinkedLabel = Me.LblPaperSource
        Me.cboPaperSource.Location = New System.Drawing.Point(157, 114)
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
        Me.cboPaperSource.TabIndex = 5
        Me.cboPaperSource.TextToSearch = Nothing
        Me.cboPaperSource.Translatable = false
        Me.cboPaperSource.ValueIsMandatory = false
        Me.cboPaperSource.ValueIsNullable = false
        Me.cboPaperSource.ValueIsNumeric = false
        Me.cboPaperSource.ValueMember = "IdNo"
        '
        'LblPaperSize
        '
        Me.LblPaperSize.DisplayOnly = true
        Me.LblPaperSize.EditingMode = false
        Me.LblPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblPaperSize.Location = New System.Drawing.Point(11, 140)
        Me.LblPaperSize.Margin = New System.Windows.Forms.Padding(1)
        Me.LblPaperSize.Name = "LblPaperSize"
        Me.LblPaperSize.Size = New System.Drawing.Size(144, 23)
        Me.LblPaperSize.TabIndex = 161
        Me.LblPaperSize.Text = "Paper Size"
        Me.LblPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPaperSize.Translatable = true
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
        Me.cboPaperSize.LinkedLabel = Me.LblPaperSource
        Me.cboPaperSize.Location = New System.Drawing.Point(157, 140)
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
        Me.cboPaperSize.TabIndex = 6
        Me.cboPaperSize.TextToSearch = Nothing
        Me.cboPaperSize.Translatable = false
        Me.cboPaperSize.ValueIsMandatory = false
        Me.cboPaperSize.ValueIsNullable = false
        Me.cboPaperSize.ValueIsNumeric = false
        Me.cboPaperSize.ValueMember = "IdNo"
        '
        'LblPaperOrientation
        '
        Me.LblPaperOrientation.DisplayOnly = true
        Me.LblPaperOrientation.EditingMode = false
        Me.LblPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblPaperOrientation.Location = New System.Drawing.Point(11, 166)
        Me.LblPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
        Me.LblPaperOrientation.Name = "LblPaperOrientation"
        Me.LblPaperOrientation.Size = New System.Drawing.Size(144, 23)
        Me.LblPaperOrientation.TabIndex = 163
        Me.LblPaperOrientation.Text = "Paper Orientation"
        Me.LblPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPaperOrientation.Translatable = true
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
        Me.cboPaperOrientation.LinkedLabel = Me.LblPaperOrientation
        Me.cboPaperOrientation.Location = New System.Drawing.Point(157, 166)
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
        Me.cboPaperOrientation.TabIndex = 7
        Me.cboPaperOrientation.TextToSearch = Nothing
        Me.cboPaperOrientation.Translatable = false
        Me.cboPaperOrientation.ValueIsMandatory = false
        Me.cboPaperOrientation.ValueIsNullable = false
        Me.cboPaperOrientation.ValueIsNumeric = false
        Me.cboPaperOrientation.ValueMember = "IdNo"
        '
        'PrintJobEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(723, 365)
        Me.MinimumSize = New System.Drawing.Size(703, 404)
        Me.Name = "PrintJobEntryTv"
        Me.Text = "Print Job Maintenance Form"
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
        Friend WithEvents LblComputerIdNo As CLabel
        Friend WithEvents LblPaperSource As CLabel
        Friend WithEvents LblPaperSize As CLabel
        Friend WithEvents LblPaperOrientation As CLabel
        Friend WithEvents lblPrinterIdNo As CLabel
        Friend WithEvents lblPrintSetupIdNo As CLabel
        Friend WithEvents cboPrintSetupIdNo As CaComboBox
        Friend WithEvents cboPaperSource As CaComboBox
        Friend WithEvents cboPaperSize As CaComboBox
        Friend WithEvents cboPaperOrientation As CaComboBox
        Friend WithEvents cboComputerIdNo As CaComboBox
        Friend WithEvents cboPrinterIdNo As CaComboBox
    End Class
End Namespace