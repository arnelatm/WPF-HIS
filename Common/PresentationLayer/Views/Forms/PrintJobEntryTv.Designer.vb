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
            Me.lblPrintJobName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.LblComputerName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.LblPaperSource = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.LblPaperSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.LblPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPrintJobName = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboComputerName = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboPrinterName = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboPaperSource = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboPaperSize = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            Me.SplitContainer1.Size = New System.Drawing.Size(687, 312)
            Me.SplitContainer1.SplitterDistance = 228
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(228, 312)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSize = True
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobName)
            Me.floDataDisplay.Controls.Add(Me.cboPrintJobName)
            Me.floDataDisplay.Controls.Add(Me.LblComputerName)
            Me.floDataDisplay.Controls.Add(Me.cboComputerName)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.cboPrinterName)
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
            Me.floDataDisplay.Size = New System.Drawing.Size(449, 312)
            Me.floDataDisplay.TabIndex = 148
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(184, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Print Job ID No."
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
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(197, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblPrintJobName
            '
            Me.lblPrintJobName.DisplayOnly = True
            Me.lblPrintJobName.EditingMode = False
            Me.lblPrintJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobName.Location = New System.Drawing.Point(11, 36)
            Me.lblPrintJobName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobName.Name = "lblPrintJobName"
            Me.lblPrintJobName.Size = New System.Drawing.Size(184, 23)
            Me.lblPrintJobName.TabIndex = 153
            Me.lblPrintJobName.Text = "Print Job Name"
            Me.lblPrintJobName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobName.Translatable = True
            '
            'LblComputerName
            '
            Me.LblComputerName.DisplayOnly = True
            Me.LblComputerName.EditingMode = False
            Me.LblComputerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblComputerName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblComputerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblComputerName.Location = New System.Drawing.Point(11, 62)
            Me.LblComputerName.Margin = New System.Windows.Forms.Padding(1)
            Me.LblComputerName.Name = "LblComputerName"
            Me.LblComputerName.Size = New System.Drawing.Size(184, 23)
            Me.LblComputerName.TabIndex = 157
            Me.LblComputerName.Text = "Computer Name"
            Me.LblComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblComputerName.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.CLabel1, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 88)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(184, 23)
            Me.CLabel1.TabIndex = 165
            Me.CLabel1.Text = "Printer Name"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'LblPaperSource
            '
            Me.LblPaperSource.DisplayOnly = True
            Me.LblPaperSource.EditingMode = False
            Me.LblPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSource.Location = New System.Drawing.Point(11, 114)
            Me.LblPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSource.Name = "LblPaperSource"
            Me.LblPaperSource.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperSource.TabIndex = 159
            Me.LblPaperSource.Text = "Paper Source"
            Me.LblPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSource.Translatable = True
            '
            'LblPaperSize
            '
            Me.LblPaperSize.DisplayOnly = True
            Me.LblPaperSize.EditingMode = False
            Me.LblPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSize.Location = New System.Drawing.Point(11, 140)
            Me.LblPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSize.Name = "LblPaperSize"
            Me.LblPaperSize.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperSize.TabIndex = 161
            Me.LblPaperSize.Text = "Paper Size"
            Me.LblPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSize.Translatable = True
            '
            'LblPaperOrientation
            '
            Me.LblPaperOrientation.DisplayOnly = True
            Me.LblPaperOrientation.EditingMode = False
            Me.LblPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperOrientation.Location = New System.Drawing.Point(11, 166)
            Me.LblPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperOrientation.Name = "LblPaperOrientation"
            Me.LblPaperOrientation.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperOrientation.TabIndex = 163
            Me.LblPaperOrientation.Text = "Paper Orientation"
            Me.LblPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperOrientation.Translatable = True
            '
            'cboPrintJobName
            '
            Me.cboPrintJobName.BackColor = System.Drawing.Color.White
            Me.cboPrintJobName.BegFindValue = Nothing
            Me.cboPrintJobName.ChangingSearchValueOnly = False
            Me.cboPrintJobName.CurrentSearchTerm = ""
            Me.cboPrintJobName.DataValue = Nothing
            Me.cboPrintJobName.DefaultValue = Nothing
            Me.cboPrintJobName.DisplayMember = "Name"
            Me.cboPrintJobName.EditingMode = True
            Me.cboPrintJobName.EndFindValue = Nothing
            Me.cboPrintJobName.FieldDescription = Nothing
            Me.cboPrintJobName.FieldName = Nothing
            Me.cboPrintJobName.FilterRule = Nothing
            Me.cboPrintJobName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPrintJobName.FindEnabled = False
            Me.cboPrintJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPrintJobName.FormattingEnabled = True
            Me.cboPrintJobName.HideWhenNotEditingOrAdding = False
            Me.cboPrintJobName.IgnoreCase = False
            Me.cboPrintJobName.LinkedLabel = Nothing
            Me.cboPrintJobName.Location = New System.Drawing.Point(197, 36)
            Me.cboPrintJobName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrintJobName.Name = "cboPrintJobName"
            Me.cboPrintJobName.OldValue = 0
            Me.cboPrintJobName.OriginalDataSource = Nothing
            Me.cboPrintJobName.OriginalList = Nothing
            Me.cboPrintJobName.OverrideDropDownStyleList = False
            Me.cboPrintJobName.PreviousSearchTerm = Nothing
            Me.cboPrintJobName.PropertySelector = Nothing
            Me.cboPrintJobName.ReadOnlyCombo = False
            Me.cboPrintJobName.Size = New System.Drawing.Size(221, 24)
            Me.cboPrintJobName.SuggestBoxHeight = 200
            Me.cboPrintJobName.SuggestListOrderRule = Nothing
            Me.cboPrintJobName.TabIndex = 166
            Me.cboPrintJobName.TextToSearch = Nothing
            Me.cboPrintJobName.Translatable = False
            Me.cboPrintJobName.ValueIsMandatory = False
            Me.cboPrintJobName.ValueIsNullable = False
            Me.cboPrintJobName.ValueIsNumeric = False
            Me.cboPrintJobName.ValueMember = "IdNo"
            '
            'cboComputerName
            '
            Me.cboComputerName.BackColor = System.Drawing.Color.White
            Me.cboComputerName.BegFindValue = Nothing
            Me.cboComputerName.ChangingSearchValueOnly = False
            Me.cboComputerName.CurrentSearchTerm = ""
            Me.cboComputerName.DataValue = Nothing
            Me.cboComputerName.DefaultValue = Nothing
            Me.cboComputerName.DisplayMember = "Name"
            Me.cboComputerName.EditingMode = True
            Me.cboComputerName.EndFindValue = Nothing
            Me.cboComputerName.FieldDescription = Nothing
            Me.cboComputerName.FieldName = Nothing
            Me.cboComputerName.FilterRule = Nothing
            Me.cboComputerName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboComputerName.FindEnabled = False
            Me.cboComputerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboComputerName.FormattingEnabled = True
            Me.cboComputerName.HideWhenNotEditingOrAdding = False
            Me.cboComputerName.IgnoreCase = False
            Me.cboComputerName.LinkedLabel = Nothing
            Me.cboComputerName.Location = New System.Drawing.Point(197, 62)
            Me.cboComputerName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboComputerName.Name = "cboComputerName"
            Me.cboComputerName.OldValue = 0
            Me.cboComputerName.OriginalDataSource = Nothing
            Me.cboComputerName.OriginalList = Nothing
            Me.cboComputerName.OverrideDropDownStyleList = False
            Me.cboComputerName.PreviousSearchTerm = Nothing
            Me.cboComputerName.PropertySelector = Nothing
            Me.cboComputerName.ReadOnlyCombo = False
            Me.cboComputerName.Size = New System.Drawing.Size(221, 24)
            Me.cboComputerName.SuggestBoxHeight = 200
            Me.cboComputerName.SuggestListOrderRule = Nothing
            Me.cboComputerName.TabIndex = 167
            Me.cboComputerName.TextToSearch = Nothing
            Me.cboComputerName.Translatable = False
            Me.cboComputerName.ValueIsMandatory = False
            Me.cboComputerName.ValueIsNullable = False
            Me.cboComputerName.ValueIsNumeric = False
            Me.cboComputerName.ValueMember = "IdNo"
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
            Me.cboPrinterName.FormattingEnabled = True
            Me.cboPrinterName.HideWhenNotEditingOrAdding = False
            Me.cboPrinterName.IgnoreCase = False
            Me.cboPrinterName.LinkedLabel = Nothing
            Me.cboPrinterName.Location = New System.Drawing.Point(197, 88)
            Me.cboPrinterName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrinterName.Name = "cboPrinterName"
            Me.cboPrinterName.OldValue = 0
            Me.cboPrinterName.OriginalDataSource = Nothing
            Me.cboPrinterName.OriginalList = Nothing
            Me.cboPrinterName.OverrideDropDownStyleList = False
            Me.cboPrinterName.PreviousSearchTerm = Nothing
            Me.cboPrinterName.PropertySelector = Nothing
            Me.cboPrinterName.ReadOnlyCombo = False
            Me.cboPrinterName.Size = New System.Drawing.Size(221, 24)
            Me.cboPrinterName.SuggestBoxHeight = 200
            Me.cboPrinterName.SuggestListOrderRule = Nothing
            Me.cboPrinterName.TabIndex = 168
            Me.cboPrinterName.TextToSearch = Nothing
            Me.cboPrinterName.Translatable = False
            Me.cboPrinterName.ValueIsMandatory = False
            Me.cboPrinterName.ValueIsNullable = False
            Me.cboPrinterName.ValueIsNumeric = False
            Me.cboPrinterName.ValueMember = "IdNo"
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
            Me.cboPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaperSource.FormattingEnabled = True
            Me.cboPaperSource.HideWhenNotEditingOrAdding = False
            Me.cboPaperSource.IgnoreCase = False
            Me.cboPaperSource.LinkedLabel = Nothing
            Me.cboPaperSource.Location = New System.Drawing.Point(197, 114)
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
            Me.cboPaperSource.TabIndex = 169
            Me.cboPaperSource.TextToSearch = Nothing
            Me.cboPaperSource.Translatable = False
            Me.cboPaperSource.ValueIsMandatory = False
            Me.cboPaperSource.ValueIsNullable = False
            Me.cboPaperSource.ValueIsNumeric = False
            Me.cboPaperSource.ValueMember = "IdNo"
            '
            'cboPaperSize
            '
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
            Me.cboPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaperSize.FormattingEnabled = True
            Me.cboPaperSize.HideWhenNotEditingOrAdding = False
            Me.cboPaperSize.IgnoreCase = False
            Me.cboPaperSize.LinkedLabel = Nothing
            Me.cboPaperSize.Location = New System.Drawing.Point(197, 140)
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
            Me.cboPaperSize.TabIndex = 170
            Me.cboPaperSize.TextToSearch = Nothing
            Me.cboPaperSize.Translatable = False
            Me.cboPaperSize.ValueIsMandatory = False
            Me.cboPaperSize.ValueIsNullable = False
            Me.cboPaperSize.ValueIsNumeric = False
            Me.cboPaperSize.ValueMember = "IdNo"
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
            Me.cboPaperOrientation.EditingMode = True
            Me.cboPaperOrientation.EndFindValue = Nothing
            Me.cboPaperOrientation.FieldDescription = Nothing
            Me.cboPaperOrientation.FieldName = Nothing
            Me.cboPaperOrientation.FilterRule = Nothing
            Me.cboPaperOrientation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaperOrientation.FindEnabled = False
            Me.cboPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaperOrientation.FormattingEnabled = True
            Me.cboPaperOrientation.HideWhenNotEditingOrAdding = False
            Me.cboPaperOrientation.IgnoreCase = False
            Me.cboPaperOrientation.LinkedLabel = Nothing
            Me.cboPaperOrientation.Location = New System.Drawing.Point(197, 166)
            Me.cboPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperOrientation.Name = "cboPaperOrientation"
            Me.cboPaperOrientation.OldValue = 0
            Me.cboPaperOrientation.OriginalDataSource = Nothing
            Me.cboPaperOrientation.OriginalList = Nothing
            Me.cboPaperOrientation.OverrideDropDownStyleList = False
            Me.cboPaperOrientation.PreviousSearchTerm = Nothing
            Me.cboPaperOrientation.PropertySelector = Nothing
            Me.cboPaperOrientation.ReadOnlyCombo = False
            Me.cboPaperOrientation.Size = New System.Drawing.Size(221, 24)
            Me.cboPaperOrientation.SuggestBoxHeight = 200
            Me.cboPaperOrientation.SuggestListOrderRule = Nothing
            Me.cboPaperOrientation.TabIndex = 171
            Me.cboPaperOrientation.TextToSearch = Nothing
            Me.cboPaperOrientation.Translatable = False
            Me.cboPaperOrientation.ValueIsMandatory = False
            Me.cboPaperOrientation.ValueIsNullable = False
            Me.cboPaperOrientation.ValueIsNumeric = False
            Me.cboPaperOrientation.ValueMember = "IdNo"
            '
            'PrintJobEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(687, 365)
            Me.MinimumSize = New System.Drawing.Size(703, 404)
            Me.Name = "PrintJobEntryTv"
            Me.Text = "Print Job Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.Panel2.PerformLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents LblComputerName As CLabel
        Friend WithEvents LblPaperSource As CLabel
        Friend WithEvents LblPaperSize As CLabel
        Friend WithEvents LblPaperOrientation As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblPrintJobName As CLabel
        Friend WithEvents cboPrintJobName As CaComboBox
        Friend WithEvents cboComputerName As CaComboBox
        Friend WithEvents cboPrinterName As CaComboBox
        Friend WithEvents cboPaperSource As CaComboBox
        Friend WithEvents cboPaperSize As CaComboBox
        Friend WithEvents cboPaperOrientation As CaComboBox
    End Class
End Namespace