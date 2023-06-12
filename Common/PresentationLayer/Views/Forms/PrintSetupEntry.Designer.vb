Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PrintSetupEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintSetupEntry))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPrintSetupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPrintSetupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPrintSetupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPrintJobIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
        Me.floDataDisplay.Controls.Add(Me.lblPrintSetupName)
        Me.floDataDisplay.Controls.Add(Me.txtPrintSetupName)
        Me.floDataDisplay.Controls.Add(Me.lblPrintSetupIdNo)
        Me.floDataDisplay.Controls.Add(Me.cboPrintJobIdNo)
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
        Me.lblIdNo.Text = "Print Setup ID No."
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
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblPrintSetupName
            '
            Me.lblPrintSetupName.DisplayOnly = True
            Me.lblPrintSetupName.EditingMode = False
            Me.lblPrintSetupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPrintSetupName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintSetupName.Location = New System.Drawing.Point(11, 36)
            Me.lblPrintSetupName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintSetupName.Name = "lblPrintSetupName"
            Me.lblPrintSetupName.Size = New System.Drawing.Size(144, 23)
            Me.lblPrintSetupName.TabIndex = 177
            Me.lblPrintSetupName.Text = "Print Setup Name"
            Me.lblPrintSetupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintSetupName.Translatable = True
            '
            'txtPrintSetupName
            '
            Me.txtPrintSetupName.BackColor = System.Drawing.Color.White
            Me.txtPrintSetupName.BegFindValue = Nothing
            Me.txtPrintSetupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrintSetupName.ComputedValue = False
            Me.txtPrintSetupName.CustomFormat = Nothing
            Me.txtPrintSetupName.DataBoundControl = True
            Me.txtPrintSetupName.DisplayOnly = True
            Me.txtPrintSetupName.EditingMode = True
            Me.txtPrintSetupName.EndFindValue = Nothing
            Me.txtPrintSetupName.FieldDescription = Nothing
            Me.txtPrintSetupName.FieldName = Nothing
            Me.txtPrintSetupName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrintSetupName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPrintSetupName, True)
            Me.txtPrintSetupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrintSetupName.ForeColor = System.Drawing.Color.Black
            Me.txtPrintSetupName.LinkedLabel = Me.lblPrintSetupName
            Me.txtPrintSetupName.Location = New System.Drawing.Point(157, 36)
            Me.txtPrintSetupName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrintSetupName.MaximumValue = Nothing
            Me.txtPrintSetupName.MinimumValue = Nothing
            Me.txtPrintSetupName.Name = "txtPrintSetupName"
            Me.txtPrintSetupName.OldValue = Nothing
            Me.txtPrintSetupName.OverrideMaxLength = 0
            Me.txtPrintSetupName.ReadOnly = True
            Me.txtPrintSetupName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrintSetupName.Size = New System.Drawing.Size(307, 23)
            Me.txtPrintSetupName.TabIndex = 1
            Me.txtPrintSetupName.Translatable = False
            '
            'lblPrintSetupIdNo
            '
            Me.lblPrintSetupIdNo.DisplayOnly = True
            Me.lblPrintSetupIdNo.EditingMode = False
            Me.lblPrintSetupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintSetupIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintSetupIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintSetupIdNo.Location = New System.Drawing.Point(11, 61)
            Me.lblPrintSetupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintSetupIdNo.Name = "lblPrintSetupIdNo"
            Me.lblPrintSetupIdNo.Size = New System.Drawing.Size(144, 23)
            Me.lblPrintSetupIdNo.TabIndex = 153
            Me.lblPrintSetupIdNo.Text = "Print Job Name"
            Me.lblPrintSetupIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintSetupIdNo.Translatable = True
            '
            'cboPrintJobIdNo
            '
            Me.cboPrintJobIdNo.AlwaysEditable = False
            Me.cboPrintJobIdNo.BackColor = System.Drawing.Color.White
            Me.cboPrintJobIdNo.BegFindValue = Nothing
            Me.cboPrintJobIdNo.ChangingSearchValueOnly = False
            Me.cboPrintJobIdNo.CurrentSearchTerm = ""
            Me.cboPrintJobIdNo.DataValue = Nothing
            Me.cboPrintJobIdNo.DefaultValue = Nothing
            Me.cboPrintJobIdNo.DisplayMember = "Name"
            Me.cboPrintJobIdNo.EditingMode = True
            Me.cboPrintJobIdNo.EndFindValue = Nothing
            Me.cboPrintJobIdNo.FieldDescription = Nothing
            Me.cboPrintJobIdNo.FieldName = Nothing
            Me.cboPrintJobIdNo.FilterRule = Nothing
            Me.cboPrintJobIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPrintJobIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboPrintJobIdNo, True)
            Me.cboPrintJobIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPrintJobIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPrintJobIdNo.FormattingEnabled = True
            Me.cboPrintJobIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPrintJobIdNo.IgnoreCase = False
            Me.cboPrintJobIdNo.IntegralHeight = False
            Me.cboPrintJobIdNo.LimitToList = False
            Me.cboPrintJobIdNo.LinkedLabel = Me.lblPrintSetupIdNo
            Me.cboPrintJobIdNo.Location = New System.Drawing.Point(157, 61)
            Me.cboPrintJobIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrintJobIdNo.Name = "cboPrintJobIdNo"
            Me.cboPrintJobIdNo.OldValue = 0
            Me.cboPrintJobIdNo.OriginalDataSource = Nothing
            Me.cboPrintJobIdNo.OriginalList = Nothing
            Me.cboPrintJobIdNo.OverrideDropDownStyleList = False
            Me.cboPrintJobIdNo.PreviousSearchTerm = Nothing
            Me.cboPrintJobIdNo.PropertySelector = Nothing
            Me.cboPrintJobIdNo.ReadOnlyCombo = False
            Me.cboPrintJobIdNo.Size = New System.Drawing.Size(307, 24)
            Me.cboPrintJobIdNo.SuggestBoxHeight = 200
            Me.cboPrintJobIdNo.SuggestListOrderRule = Nothing
            Me.cboPrintJobIdNo.TabIndex = 2
            Me.cboPrintJobIdNo.TextToSearch = Nothing
            Me.cboPrintJobIdNo.Translatable = False
            Me.cboPrintJobIdNo.ValueIsMandatory = False
            Me.cboPrintJobIdNo.ValueIsNullable = False
            Me.cboPrintJobIdNo.ValueIsNumeric = False
            Me.cboPrintJobIdNo.ValueMember = "IdNo"
            '
            'LblComputerIdNo
            '
            Me.LblComputerIdNo.DisplayOnly = True
            Me.LblComputerIdNo.EditingMode = False
            Me.LblComputerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblComputerIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblComputerIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblComputerIdNo.Location = New System.Drawing.Point(11, 87)
            Me.LblComputerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.LblComputerIdNo.Name = "LblComputerIdNo"
            Me.LblComputerIdNo.Size = New System.Drawing.Size(144, 23)
            Me.LblComputerIdNo.TabIndex = 157
            Me.LblComputerIdNo.Text = "Computer Name"
            Me.LblComputerIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblComputerIdNo.Translatable = True
            '
            'cboComputerIdNo
            '
            Me.cboComputerIdNo.AlwaysEditable = False
            Me.cboComputerIdNo.BackColor = System.Drawing.Color.White
            Me.cboComputerIdNo.BegFindValue = Nothing
            Me.cboComputerIdNo.ChangingSearchValueOnly = False
            Me.cboComputerIdNo.CurrentSearchTerm = ""
            Me.cboComputerIdNo.DataValue = Nothing
            Me.cboComputerIdNo.DefaultValue = Nothing
            Me.cboComputerIdNo.DisplayMember = "Name"
            Me.cboComputerIdNo.EditingMode = True
            Me.cboComputerIdNo.EndFindValue = Nothing
            Me.cboComputerIdNo.FieldDescription = Nothing
            Me.cboComputerIdNo.FieldName = Nothing
            Me.cboComputerIdNo.FilterRule = Nothing
            Me.cboComputerIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboComputerIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboComputerIdNo, True)
            Me.cboComputerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboComputerIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboComputerIdNo.FormattingEnabled = True
            Me.cboComputerIdNo.HideWhenNotEditingOrAdding = False
            Me.cboComputerIdNo.IgnoreCase = False
            Me.cboComputerIdNo.IntegralHeight = False
            Me.cboComputerIdNo.LimitToList = False
            Me.cboComputerIdNo.LinkedLabel = Me.LblComputerIdNo
            Me.cboComputerIdNo.Location = New System.Drawing.Point(157, 87)
            Me.cboComputerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboComputerIdNo.Name = "cboComputerIdNo"
            Me.cboComputerIdNo.OldValue = 0
            Me.cboComputerIdNo.OriginalDataSource = Nothing
            Me.cboComputerIdNo.OriginalList = Nothing
            Me.cboComputerIdNo.OverrideDropDownStyleList = False
            Me.cboComputerIdNo.PreviousSearchTerm = Nothing
            Me.cboComputerIdNo.PropertySelector = Nothing
            Me.cboComputerIdNo.ReadOnlyCombo = False
            Me.cboComputerIdNo.Size = New System.Drawing.Size(307, 24)
            Me.cboComputerIdNo.SuggestBoxHeight = 200
            Me.cboComputerIdNo.SuggestListOrderRule = Nothing
            Me.cboComputerIdNo.TabIndex = 3
            Me.cboComputerIdNo.TextToSearch = Nothing
            Me.cboComputerIdNo.Translatable = False
            Me.cboComputerIdNo.ValueIsMandatory = False
            Me.cboComputerIdNo.ValueIsNullable = False
            Me.cboComputerIdNo.ValueIsNumeric = False
            Me.cboComputerIdNo.ValueMember = "IdNo"
            '
            'lblPrinterIdNo
            '
            Me.lblPrinterIdNo.DisplayOnly = True
            Me.lblPrinterIdNo.EditingMode = False
            Me.lblPrinterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrinterIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrinterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrinterIdNo.Location = New System.Drawing.Point(11, 113)
            Me.lblPrinterIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrinterIdNo.Name = "lblPrinterIdNo"
            Me.lblPrinterIdNo.Size = New System.Drawing.Size(144, 23)
            Me.lblPrinterIdNo.TabIndex = 165
            Me.lblPrinterIdNo.Text = "Printer Name"
            Me.lblPrinterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrinterIdNo.Translatable = True
            '
            'cboPrinterIdNo
            '
            Me.cboPrinterIdNo.AlwaysEditable = False
            Me.cboPrinterIdNo.BackColor = System.Drawing.Color.White
            Me.cboPrinterIdNo.BegFindValue = Nothing
            Me.cboPrinterIdNo.ChangingSearchValueOnly = False
            Me.cboPrinterIdNo.CurrentSearchTerm = ""
            Me.cboPrinterIdNo.DataValue = Nothing
            Me.cboPrinterIdNo.DefaultValue = Nothing
            Me.cboPrinterIdNo.DisplayMember = "Name"
            Me.cboPrinterIdNo.EditingMode = True
            Me.cboPrinterIdNo.EndFindValue = Nothing
            Me.cboPrinterIdNo.FieldDescription = Nothing
            Me.cboPrinterIdNo.FieldName = Nothing
            Me.cboPrinterIdNo.FilterRule = Nothing
            Me.cboPrinterIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPrinterIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboPrinterIdNo, True)
            Me.cboPrinterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPrinterIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPrinterIdNo.FormattingEnabled = True
            Me.cboPrinterIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPrinterIdNo.IgnoreCase = False
            Me.cboPrinterIdNo.IntegralHeight = False
            Me.cboPrinterIdNo.LimitToList = False
            Me.cboPrinterIdNo.LinkedLabel = Me.lblPrintSetupIdNo
            Me.cboPrinterIdNo.Location = New System.Drawing.Point(157, 113)
            Me.cboPrinterIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrinterIdNo.Name = "cboPrinterIdNo"
            Me.cboPrinterIdNo.OldValue = 0
            Me.cboPrinterIdNo.OriginalDataSource = Nothing
            Me.cboPrinterIdNo.OriginalList = Nothing
            Me.cboPrinterIdNo.OverrideDropDownStyleList = False
            Me.cboPrinterIdNo.PreviousSearchTerm = Nothing
            Me.cboPrinterIdNo.PropertySelector = Nothing
            Me.cboPrinterIdNo.ReadOnlyCombo = False
            Me.cboPrinterIdNo.Size = New System.Drawing.Size(307, 24)
            Me.cboPrinterIdNo.SuggestBoxHeight = 200
            Me.cboPrinterIdNo.SuggestListOrderRule = Nothing
            Me.cboPrinterIdNo.TabIndex = 4
            Me.cboPrinterIdNo.TextToSearch = Nothing
            Me.cboPrinterIdNo.Translatable = False
            Me.cboPrinterIdNo.ValueIsMandatory = False
            Me.cboPrinterIdNo.ValueIsNullable = False
            Me.cboPrinterIdNo.ValueIsNumeric = False
            Me.cboPrinterIdNo.ValueMember = "IdNo"
            '
            'LblPaperSource
            '
            Me.LblPaperSource.DisplayOnly = True
            Me.LblPaperSource.EditingMode = False
            Me.LblPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSource.Location = New System.Drawing.Point(11, 139)
            Me.LblPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSource.Name = "LblPaperSource"
            Me.LblPaperSource.Size = New System.Drawing.Size(144, 23)
            Me.LblPaperSource.TabIndex = 159
            Me.LblPaperSource.Text = "Paper Source"
            Me.LblPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSource.Translatable = True
            '
            'cboPaperSource
            '
            Me.cboPaperSource.AlwaysEditable = False
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
            Me.cboPaperSource.LinkedLabel = Me.LblPaperSource
            Me.cboPaperSource.Location = New System.Drawing.Point(157, 139)
            Me.cboPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperSource.Name = "cboPaperSource"
            Me.cboPaperSource.OldValue = 0
            Me.cboPaperSource.OriginalDataSource = Nothing
            Me.cboPaperSource.OriginalList = Nothing
            Me.cboPaperSource.OverrideDropDownStyleList = False
            Me.cboPaperSource.PreviousSearchTerm = Nothing
            Me.cboPaperSource.PropertySelector = Nothing
            Me.cboPaperSource.ReadOnlyCombo = False
            Me.cboPaperSource.Size = New System.Drawing.Size(307, 24)
            Me.cboPaperSource.SuggestBoxHeight = 200
            Me.cboPaperSource.SuggestListOrderRule = Nothing
            Me.cboPaperSource.TabIndex = 5
            Me.cboPaperSource.TextToSearch = Nothing
            Me.cboPaperSource.Translatable = False
            Me.cboPaperSource.ValueIsMandatory = False
            Me.cboPaperSource.ValueIsNullable = False
            Me.cboPaperSource.ValueIsNumeric = False
            Me.cboPaperSource.ValueMember = "IdNo"
            '
            'LblPaperSize
            '
            Me.LblPaperSize.DisplayOnly = True
            Me.LblPaperSize.EditingMode = False
            Me.LblPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSize.Location = New System.Drawing.Point(11, 165)
            Me.LblPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSize.Name = "LblPaperSize"
            Me.LblPaperSize.Size = New System.Drawing.Size(144, 23)
            Me.LblPaperSize.TabIndex = 161
            Me.LblPaperSize.Text = "Paper Size"
            Me.LblPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSize.Translatable = True
            '
            'cboPaperSize
            '
            Me.cboPaperSize.AlwaysEditable = False
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
            Me.cboPaperSize.LinkedLabel = Me.LblPaperSource
            Me.cboPaperSize.Location = New System.Drawing.Point(157, 165)
            Me.cboPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperSize.Name = "cboPaperSize"
            Me.cboPaperSize.OldValue = 0
            Me.cboPaperSize.OriginalDataSource = Nothing
            Me.cboPaperSize.OriginalList = Nothing
            Me.cboPaperSize.OverrideDropDownStyleList = False
            Me.cboPaperSize.PreviousSearchTerm = Nothing
            Me.cboPaperSize.PropertySelector = Nothing
            Me.cboPaperSize.ReadOnlyCombo = False
            Me.cboPaperSize.Size = New System.Drawing.Size(307, 24)
            Me.cboPaperSize.SuggestBoxHeight = 200
            Me.cboPaperSize.SuggestListOrderRule = Nothing
            Me.cboPaperSize.TabIndex = 6
            Me.cboPaperSize.TextToSearch = Nothing
            Me.cboPaperSize.Translatable = False
            Me.cboPaperSize.ValueIsMandatory = False
            Me.cboPaperSize.ValueIsNullable = False
            Me.cboPaperSize.ValueIsNumeric = False
            Me.cboPaperSize.ValueMember = "IdNo"
            '
            'LblPaperOrientation
            '
            Me.LblPaperOrientation.DisplayOnly = True
            Me.LblPaperOrientation.EditingMode = False
            Me.LblPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperOrientation.Location = New System.Drawing.Point(11, 191)
            Me.LblPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperOrientation.Name = "LblPaperOrientation"
            Me.LblPaperOrientation.Size = New System.Drawing.Size(144, 23)
            Me.LblPaperOrientation.TabIndex = 163
            Me.LblPaperOrientation.Text = "Paper Orientation"
            Me.LblPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperOrientation.Translatable = True
            '
            'cboPaperOrientation
            '
            Me.cboPaperOrientation.AlwaysEditable = False
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
            Me.cboPaperOrientation.ForeColor = System.Drawing.Color.Black
            Me.cboPaperOrientation.FormattingEnabled = True
            Me.cboPaperOrientation.HideWhenNotEditingOrAdding = False
            Me.cboPaperOrientation.IgnoreCase = False
            Me.cboPaperOrientation.IntegralHeight = False
            Me.cboPaperOrientation.LimitToList = False
            Me.cboPaperOrientation.LinkedLabel = Me.LblPaperOrientation
            Me.cboPaperOrientation.Location = New System.Drawing.Point(157, 191)
            Me.cboPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaperOrientation.Name = "cboPaperOrientation"
            Me.cboPaperOrientation.OldValue = 0
            Me.cboPaperOrientation.OriginalDataSource = Nothing
            Me.cboPaperOrientation.OriginalList = Nothing
            Me.cboPaperOrientation.OverrideDropDownStyleList = False
            Me.cboPaperOrientation.PreviousSearchTerm = Nothing
            Me.cboPaperOrientation.PropertySelector = Nothing
            Me.cboPaperOrientation.ReadOnlyCombo = False
            Me.cboPaperOrientation.Size = New System.Drawing.Size(307, 24)
            Me.cboPaperOrientation.SuggestBoxHeight = 200
            Me.cboPaperOrientation.SuggestListOrderRule = Nothing
            Me.cboPaperOrientation.TabIndex = 7
            Me.cboPaperOrientation.TextToSearch = Nothing
            Me.cboPaperOrientation.Translatable = False
            Me.cboPaperOrientation.ValueIsMandatory = False
            Me.cboPaperOrientation.ValueIsNullable = False
            Me.cboPaperOrientation.ValueIsNumeric = False
            Me.cboPaperOrientation.ValueMember = "IdNo"
            '
            'PrintSetupEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(723, 365)
            Me.MinimumSize = New System.Drawing.Size(703, 404)
            Me.Name = "PrintSetupEntry"
            Me.Text = "Print Setup Maintenance Form"
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
        Friend WithEvents cboPrintJobIdNo As CaComboBox
        Friend WithEvents cboPaperSource As CaComboBox
        Friend WithEvents cboPaperSize As CaComboBox
        Friend WithEvents cboPaperOrientation As CaComboBox
        Friend WithEvents cboComputerIdNo As CaComboBox
        Friend WithEvents cboPrinterIdNo As CaComboBox
        Friend WithEvents lblPrintSetupName As CLabel
        Friend WithEvents txtPrintSetupName As CTextBox
    End Class
End Namespace