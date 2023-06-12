Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportEntry))
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.cboPrintJobIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPrintJobIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblQueryForm = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryForm = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblQueryFormParameters = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryFormParameters = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportTitle = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblQueryParameters = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryParameters = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportFileName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportFileName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.SplitContainer1.Size = New System.Drawing.Size(1040, 312)
            Me.SplitContainer1.SplitterDistance = 434
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(434, 312)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.txtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblReportCode)
            Me.floDataDisplay.Controls.Add(Me.txtReportCode)
            Me.floDataDisplay.Controls.Add(Me.lblReportName)
            Me.floDataDisplay.Controls.Add(Me.txtReportName)
            Me.floDataDisplay.Controls.Add(Me.lblReportNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtReportNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblQueryForm)
            Me.floDataDisplay.Controls.Add(Me.txtQueryForm)
            Me.floDataDisplay.Controls.Add(Me.lblQueryFormParameters)
            Me.floDataDisplay.Controls.Add(Me.txtQueryFormParameters)
            Me.floDataDisplay.Controls.Add(Me.lblQueryParameters)
            Me.floDataDisplay.Controls.Add(Me.txtQueryParameters)
            Me.floDataDisplay.Controls.Add(Me.lblReportTitle)
            Me.floDataDisplay.Controls.Add(Me.txtReportTitle)
            Me.floDataDisplay.Controls.Add(Me.lblReportFileName)
            Me.floDataDisplay.Controls.Add(Me.txtReportFileName)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboPrintJobIdNo)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(440, 300)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(596, 312)
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
            Me.lblIdNo.Size = New System.Drawing.Size(167, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Report ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtIdNo, True)
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Me.lblIdNo
            Me.txtIdNo.Location = New System.Drawing.Point(180, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.txtIdNo.TabIndex = 0
            Me.txtIdNo.Translatable = False
            '
            'lblReportCode
            '
            Me.lblReportCode.DisplayOnly = True
            Me.lblReportCode.EditingMode = False
            Me.lblReportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportCode.Location = New System.Drawing.Point(11, 36)
            Me.lblReportCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportCode.Name = "lblReportCode"
            Me.lblReportCode.Size = New System.Drawing.Size(167, 23)
            Me.lblReportCode.TabIndex = 179
            Me.lblReportCode.Text = "Report Code"
            Me.lblReportCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportCode.Translatable = True
            '
            'txtReportCode
            '
            Me.txtReportCode.BackColor = System.Drawing.Color.White
            Me.txtReportCode.BegFindValue = Nothing
            Me.txtReportCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportCode.ComputedValue = False
            Me.txtReportCode.CustomFormat = Nothing
            Me.txtReportCode.DataBoundControl = True
            Me.txtReportCode.DisplayOnly = True
            Me.txtReportCode.EditingMode = True
            Me.txtReportCode.EndFindValue = Nothing
            Me.txtReportCode.FieldDescription = Nothing
            Me.txtReportCode.FieldName = Nothing
            Me.txtReportCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtReportCode, True)
            Me.txtReportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportCode.ForeColor = System.Drawing.Color.Black
            Me.txtReportCode.LinkedLabel = Me.lblReportCode
            Me.txtReportCode.Location = New System.Drawing.Point(180, 36)
            Me.txtReportCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportCode.MaximumValue = Nothing
            Me.txtReportCode.MinimumValue = Nothing
            Me.txtReportCode.Name = "txtReportCode"
            Me.txtReportCode.OldValue = Nothing
            Me.txtReportCode.OverrideMaxLength = 0
            Me.txtReportCode.ReadOnly = True
            Me.txtReportCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportCode.Size = New System.Drawing.Size(403, 23)
            Me.txtReportCode.TabIndex = 1
            Me.txtReportCode.Translatable = False
            '
            'lblReportName
            '
            Me.lblReportName.DisplayOnly = True
            Me.lblReportName.EditingMode = False
            Me.lblReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportName.Location = New System.Drawing.Point(11, 61)
            Me.lblReportName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportName.Name = "lblReportName"
            Me.lblReportName.Size = New System.Drawing.Size(167, 23)
            Me.lblReportName.TabIndex = 177
            Me.lblReportName.Text = "Report Name"
            Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportName.Translatable = True
            '
            'txtReportName
            '
            Me.txtReportName.BackColor = System.Drawing.Color.White
            Me.txtReportName.BegFindValue = Nothing
            Me.txtReportName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportName.ComputedValue = False
            Me.txtReportName.CustomFormat = Nothing
            Me.txtReportName.DataBoundControl = True
            Me.txtReportName.DisplayOnly = True
            Me.txtReportName.EditingMode = True
            Me.txtReportName.EndFindValue = Nothing
            Me.txtReportName.FieldDescription = Nothing
            Me.txtReportName.FieldName = Nothing
            Me.txtReportName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtReportName, True)
            Me.txtReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportName.ForeColor = System.Drawing.Color.Black
            Me.txtReportName.LinkedLabel = Me.lblReportName
            Me.txtReportName.Location = New System.Drawing.Point(180, 61)
            Me.txtReportName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportName.MaximumValue = Nothing
            Me.txtReportName.MinimumValue = Nothing
            Me.txtReportName.Name = "txtReportName"
            Me.txtReportName.OldValue = Nothing
            Me.txtReportName.OverrideMaxLength = 0
            Me.txtReportName.ReadOnly = True
            Me.txtReportName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportName.Size = New System.Drawing.Size(403, 23)
            Me.txtReportName.TabIndex = 2
            Me.txtReportName.Translatable = False
            '
            'lblReportNameAra
            '
            Me.lblReportNameAra.DisplayOnly = True
            Me.lblReportNameAra.EditingMode = False
            Me.lblReportNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblReportNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportNameAra.Name = "lblReportNameAra"
            Me.lblReportNameAra.Size = New System.Drawing.Size(167, 23)
            Me.lblReportNameAra.TabIndex = 181
            Me.lblReportNameAra.Text = "Report Name Arabic"
            Me.lblReportNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportNameAra.Translatable = True
            '
            'txtReportNameAra
            '
            Me.txtReportNameAra.BackColor = System.Drawing.Color.White
            Me.txtReportNameAra.BegFindValue = Nothing
            Me.txtReportNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportNameAra.ComputedValue = False
            Me.txtReportNameAra.CustomFormat = Nothing
            Me.txtReportNameAra.DataBoundControl = True
            Me.txtReportNameAra.EditingMode = True
            Me.txtReportNameAra.EndFindValue = Nothing
            Me.txtReportNameAra.EnglishControl = Nothing
            Me.txtReportNameAra.FieldDescription = Nothing
            Me.txtReportNameAra.FieldName = Nothing
            Me.txtReportNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportNameAra.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtReportNameAra, True)
            Me.txtReportNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtReportNameAra.LinkedLabel = Nothing
            Me.txtReportNameAra.Location = New System.Drawing.Point(180, 86)
            Me.txtReportNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportNameAra.MaximumValue = Nothing
            Me.txtReportNameAra.MinimumValue = Nothing
            Me.txtReportNameAra.Name = "txtReportNameAra"
            Me.txtReportNameAra.OldValue = Nothing
            Me.txtReportNameAra.OverrideMaxLength = 0
            Me.txtReportNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtReportNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportNameAra.Size = New System.Drawing.Size(403, 23)
            Me.txtReportNameAra.TabIndex = 3
            Me.txtReportNameAra.Translatable = False
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
            Me.cboPrintJobIdNo.LinkedLabel = Me.lblPrintJobIdNo
            Me.cboPrintJobIdNo.Location = New System.Drawing.Point(180, 236)
            Me.cboPrintJobIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrintJobIdNo.Name = "cboPrintJobIdNo"
            Me.cboPrintJobIdNo.OldValue = 0
            Me.cboPrintJobIdNo.OriginalDataSource = Nothing
            Me.cboPrintJobIdNo.OriginalList = Nothing
            Me.cboPrintJobIdNo.OverrideDropDownStyleList = False
            Me.cboPrintJobIdNo.PreviousSearchTerm = Nothing
            Me.cboPrintJobIdNo.PropertySelector = Nothing
            Me.cboPrintJobIdNo.ReadOnlyCombo = False
            Me.cboPrintJobIdNo.Size = New System.Drawing.Size(403, 24)
            Me.cboPrintJobIdNo.SuggestBoxHeight = 200
            Me.cboPrintJobIdNo.SuggestListOrderRule = Nothing
            Me.cboPrintJobIdNo.TabIndex = 8
            Me.cboPrintJobIdNo.TextToSearch = Nothing
            Me.cboPrintJobIdNo.Translatable = False
            Me.cboPrintJobIdNo.ValueIsMandatory = False
            Me.cboPrintJobIdNo.ValueIsNullable = False
            Me.cboPrintJobIdNo.ValueIsNumeric = False
            Me.cboPrintJobIdNo.ValueMember = "IdNo"
            '
            'lblPrintJobIdNo
            '
            Me.lblPrintJobIdNo.DisplayOnly = True
            Me.lblPrintJobIdNo.EditingMode = False
            Me.lblPrintJobIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobIdNo.Location = New System.Drawing.Point(11, 236)
            Me.lblPrintJobIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobIdNo.Name = "lblPrintJobIdNo"
            Me.lblPrintJobIdNo.Size = New System.Drawing.Size(167, 23)
            Me.lblPrintJobIdNo.TabIndex = 153
            Me.lblPrintJobIdNo.Text = "Print Job Name"
            Me.lblPrintJobIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobIdNo.Translatable = True
            '
            'lblQueryForm
            '
            Me.lblQueryForm.DisplayOnly = True
            Me.lblQueryForm.EditingMode = False
            Me.lblQueryForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryForm.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryForm.Location = New System.Drawing.Point(11, 111)
            Me.lblQueryForm.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryForm.Name = "lblQueryForm"
            Me.lblQueryForm.Size = New System.Drawing.Size(167, 23)
            Me.lblQueryForm.TabIndex = 183
            Me.lblQueryForm.Text = "Query Form"
            Me.lblQueryForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblQueryForm.Translatable = True
            '
            'txtQueryForm
            '
            Me.txtQueryForm.BackColor = System.Drawing.Color.White
            Me.txtQueryForm.BegFindValue = Nothing
            Me.txtQueryForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQueryForm.ComputedValue = False
            Me.txtQueryForm.CustomFormat = Nothing
            Me.txtQueryForm.DataBoundControl = True
            Me.txtQueryForm.DisplayOnly = True
            Me.txtQueryForm.EditingMode = True
            Me.txtQueryForm.EndFindValue = Nothing
            Me.txtQueryForm.FieldDescription = Nothing
            Me.txtQueryForm.FieldName = Nothing
            Me.txtQueryForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQueryForm.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtQueryForm, True)
            Me.txtQueryForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtQueryForm.ForeColor = System.Drawing.Color.Black
            Me.txtQueryForm.LinkedLabel = Me.lblQueryForm
            Me.txtQueryForm.Location = New System.Drawing.Point(180, 111)
            Me.txtQueryForm.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryForm.MaximumValue = Nothing
            Me.txtQueryForm.MinimumValue = Nothing
            Me.txtQueryForm.Name = "txtQueryForm"
            Me.txtQueryForm.OldValue = Nothing
            Me.txtQueryForm.OverrideMaxLength = 0
            Me.txtQueryForm.ReadOnly = True
            Me.txtQueryForm.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryForm.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryForm.TabIndex = 4
            Me.txtQueryForm.Translatable = False
            '
            'lblQueryFormParameters
            '
            Me.lblQueryFormParameters.DisplayOnly = True
            Me.lblQueryFormParameters.EditingMode = False
            Me.lblQueryFormParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryFormParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryFormParameters.Location = New System.Drawing.Point(11, 136)
            Me.lblQueryFormParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryFormParameters.Name = "lblQueryFormParameters"
            Me.lblQueryFormParameters.Size = New System.Drawing.Size(167, 23)
            Me.lblQueryFormParameters.TabIndex = 185
            Me.lblQueryFormParameters.Text = "Query Form Parameters"
            Me.lblQueryFormParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblQueryFormParameters.Translatable = True
            '
            'txtQueryFormParameters
            '
            Me.txtQueryFormParameters.BackColor = System.Drawing.Color.White
            Me.txtQueryFormParameters.BegFindValue = Nothing
            Me.txtQueryFormParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQueryFormParameters.ComputedValue = False
            Me.txtQueryFormParameters.CustomFormat = Nothing
            Me.txtQueryFormParameters.DataBoundControl = True
            Me.txtQueryFormParameters.DisplayOnly = True
            Me.txtQueryFormParameters.EditingMode = True
            Me.txtQueryFormParameters.EndFindValue = Nothing
            Me.txtQueryFormParameters.FieldDescription = Nothing
            Me.txtQueryFormParameters.FieldName = Nothing
            Me.txtQueryFormParameters.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQueryFormParameters.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtQueryFormParameters, True)
            Me.txtQueryFormParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtQueryFormParameters.ForeColor = System.Drawing.Color.Black
            Me.txtQueryFormParameters.LinkedLabel = Me.lblQueryFormParameters
            Me.txtQueryFormParameters.Location = New System.Drawing.Point(180, 136)
            Me.txtQueryFormParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryFormParameters.MaximumValue = Nothing
            Me.txtQueryFormParameters.MinimumValue = Nothing
            Me.txtQueryFormParameters.Name = "txtQueryFormParameters"
            Me.txtQueryFormParameters.OldValue = Nothing
            Me.txtQueryFormParameters.OverrideMaxLength = 0
            Me.txtQueryFormParameters.ReadOnly = True
            Me.txtQueryFormParameters.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryFormParameters.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryFormParameters.TabIndex = 5
            Me.txtQueryFormParameters.Translatable = False
            '
            'lblReportTitle
            '
            Me.lblReportTitle.DisplayOnly = True
            Me.lblReportTitle.EditingMode = False
            Me.lblReportTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportTitle.Location = New System.Drawing.Point(11, 186)
            Me.lblReportTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Size = New System.Drawing.Size(167, 23)
            Me.lblReportTitle.TabIndex = 187
            Me.lblReportTitle.Text = "Report Title"
            Me.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportTitle.Translatable = True
            '
            'txtReportTitle
            '
            Me.txtReportTitle.BackColor = System.Drawing.Color.White
            Me.txtReportTitle.BegFindValue = Nothing
            Me.txtReportTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportTitle.ComputedValue = False
            Me.txtReportTitle.CustomFormat = Nothing
            Me.txtReportTitle.DataBoundControl = True
            Me.txtReportTitle.DisplayOnly = True
            Me.txtReportTitle.EditingMode = True
            Me.txtReportTitle.EndFindValue = Nothing
            Me.txtReportTitle.FieldDescription = Nothing
            Me.txtReportTitle.FieldName = Nothing
            Me.txtReportTitle.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportTitle.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtReportTitle, True)
            Me.txtReportTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportTitle.ForeColor = System.Drawing.Color.Black
            Me.txtReportTitle.LinkedLabel = Me.lblReportTitle
            Me.txtReportTitle.Location = New System.Drawing.Point(180, 186)
            Me.txtReportTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportTitle.MaximumValue = Nothing
            Me.txtReportTitle.MinimumValue = Nothing
            Me.txtReportTitle.Name = "txtReportTitle"
            Me.txtReportTitle.OldValue = Nothing
            Me.txtReportTitle.OverrideMaxLength = 0
            Me.txtReportTitle.ReadOnly = True
            Me.txtReportTitle.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportTitle.Size = New System.Drawing.Size(403, 23)
            Me.txtReportTitle.TabIndex = 7
            Me.txtReportTitle.Translatable = False
            '
            'lblQueryParameters
            '
            Me.lblQueryParameters.DisplayOnly = True
            Me.lblQueryParameters.EditingMode = False
            Me.lblQueryParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryParameters.Location = New System.Drawing.Point(11, 161)
            Me.lblQueryParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryParameters.Name = "lblQueryParameters"
            Me.lblQueryParameters.Size = New System.Drawing.Size(167, 23)
            Me.lblQueryParameters.TabIndex = 189
            Me.lblQueryParameters.Text = "Query Parameters"
            Me.lblQueryParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblQueryParameters.Translatable = True
            '
            'txtQueryParameters
            '
            Me.txtQueryParameters.BackColor = System.Drawing.Color.White
            Me.txtQueryParameters.BegFindValue = Nothing
            Me.txtQueryParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQueryParameters.ComputedValue = False
            Me.txtQueryParameters.CustomFormat = Nothing
            Me.txtQueryParameters.DataBoundControl = True
            Me.txtQueryParameters.DisplayOnly = True
            Me.txtQueryParameters.EditingMode = True
            Me.txtQueryParameters.EndFindValue = Nothing
            Me.txtQueryParameters.FieldDescription = Nothing
            Me.txtQueryParameters.FieldName = Nothing
            Me.txtQueryParameters.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQueryParameters.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtQueryParameters, True)
            Me.txtQueryParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtQueryParameters.ForeColor = System.Drawing.Color.Black
            Me.txtQueryParameters.LinkedLabel = Me.lblQueryParameters
            Me.txtQueryParameters.Location = New System.Drawing.Point(180, 161)
            Me.txtQueryParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryParameters.MaximumValue = Nothing
            Me.txtQueryParameters.MinimumValue = Nothing
            Me.txtQueryParameters.Name = "txtQueryParameters"
            Me.txtQueryParameters.OldValue = Nothing
            Me.txtQueryParameters.OverrideMaxLength = 0
            Me.txtQueryParameters.ReadOnly = True
            Me.txtQueryParameters.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryParameters.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryParameters.TabIndex = 6
            Me.txtQueryParameters.Translatable = False
            '
            'lblReportFileName
            '
            Me.lblReportFileName.DisplayOnly = True
            Me.lblReportFileName.EditingMode = False
            Me.lblReportFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportFileName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportFileName.Location = New System.Drawing.Point(11, 211)
            Me.lblReportFileName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportFileName.Name = "lblReportFileName"
            Me.lblReportFileName.Size = New System.Drawing.Size(167, 23)
            Me.lblReportFileName.TabIndex = 191
            Me.lblReportFileName.Text = "Report Title"
            Me.lblReportFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportFileName.Translatable = True
            '
            'txtReportFileName
            '
            Me.txtReportFileName.BackColor = System.Drawing.Color.White
            Me.txtReportFileName.BegFindValue = Nothing
            Me.txtReportFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportFileName.ComputedValue = False
            Me.txtReportFileName.CustomFormat = Nothing
            Me.txtReportFileName.DataBoundControl = True
            Me.txtReportFileName.DisplayOnly = True
            Me.txtReportFileName.EditingMode = True
            Me.txtReportFileName.EndFindValue = Nothing
            Me.txtReportFileName.FieldDescription = Nothing
            Me.txtReportFileName.FieldName = Nothing
            Me.txtReportFileName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportFileName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtReportFileName, True)
            Me.txtReportFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportFileName.ForeColor = System.Drawing.Color.Black
            Me.txtReportFileName.LinkedLabel = Me.lblReportFileName
            Me.txtReportFileName.Location = New System.Drawing.Point(180, 211)
            Me.txtReportFileName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportFileName.MaximumValue = Nothing
            Me.txtReportFileName.MinimumValue = Nothing
            Me.txtReportFileName.Name = "txtReportFileName"
            Me.txtReportFileName.OldValue = Nothing
            Me.txtReportFileName.OverrideMaxLength = 0
            Me.txtReportFileName.ReadOnly = True
            Me.txtReportFileName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportFileName.Size = New System.Drawing.Size(403, 23)
            Me.txtReportFileName.TabIndex = 190
            Me.txtReportFileName.Translatable = False
            '
            'ReportEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1040, 365)
            Me.MinimumSize = New System.Drawing.Size(703, 404)
            Me.Name = "ReportEntry"
            Me.Text = "Report Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
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
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents lblReportName As CLabel
        Friend WithEvents txtReportName As CTextBox
        Friend WithEvents lblReportCode As CLabel
        Friend WithEvents txtReportCode As CTextBox
        Friend WithEvents lblReportNameAra As CLabel
        Friend WithEvents txtReportNameAra As CTextBoxArabic
        Friend WithEvents lblPrintJobIdNo As CLabel
        Friend WithEvents cboPrintJobIdNo As CaComboBox
        Friend WithEvents lblQueryForm As CLabel
        Friend WithEvents txtQueryForm As CTextBox
        Friend WithEvents lblQueryFormParameters As CLabel
        Friend WithEvents txtQueryFormParameters As CTextBox
        Friend WithEvents lblReportTitle As CLabel
        Friend WithEvents txtReportTitle As CTextBox
        Friend WithEvents lblQueryParameters As CLabel
        Friend WithEvents txtQueryParameters As CTextBox
        Friend WithEvents lblReportFileName As CLabel
        Friend WithEvents txtReportFileName As CTextBox
    End Class
End Namespace