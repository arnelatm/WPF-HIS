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
            Me.lblReportGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboReportGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblPrintJobIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblQueryForm = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryForm = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblQueryFormParameters = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryFormParameters = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblQueryParameters = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQueryParameters = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportTitle = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportTitleAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportTitleAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblReportFileName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportFileName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboPrintJobIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblReportOrder = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportOrder = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDataBaseName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.SplitContainer1.Size = New System.Drawing.Size(1128, 497)
            Me.SplitContainer1.SplitterDistance = 470
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(470, 497)
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
            Me.floDataDisplay.Controls.Add(Me.lblReportGroupIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboReportGroupIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblQueryForm)
            Me.floDataDisplay.Controls.Add(Me.txtQueryForm)
            Me.floDataDisplay.Controls.Add(Me.lblQueryFormParameters)
            Me.floDataDisplay.Controls.Add(Me.txtQueryFormParameters)
            Me.floDataDisplay.Controls.Add(Me.lblQueryParameters)
            Me.floDataDisplay.Controls.Add(Me.txtQueryParameters)
            Me.floDataDisplay.Controls.Add(Me.lblReportTitle)
            Me.floDataDisplay.Controls.Add(Me.txtReportTitle)
            Me.floDataDisplay.Controls.Add(Me.lblReportTitleAra)
            Me.floDataDisplay.Controls.Add(Me.txtReportTitleAra)
            Me.floDataDisplay.Controls.Add(Me.lblReportFileName)
            Me.floDataDisplay.Controls.Add(Me.txtReportFileName)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboPrintJobIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblReportOrder)
            Me.floDataDisplay.Controls.Add(Me.txtReportOrder)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtDataBaseName)
            Me.floDataDisplay.Controls.Add(Me.lblDateCreated)
            Me.floDataDisplay.Controls.Add(Me.txtDateCreated)
            Me.floDataDisplay.Controls.Add(Me.lblActive)
            Me.floDataDisplay.Controls.Add(Me.chkActive)
            Me.floDataDisplay.Controls.Add(Me.lblBranchIdNo)
            Me.floDataDisplay.Controls.Add(Me.txtBranchIdNo)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(440, 300)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(648, 497)
            Me.floDataDisplay.TabIndex = 148
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(193, 23)
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
            Me.txtIdNo.DisplayOnly = True
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
            Me.txtIdNo.Location = New System.Drawing.Point(206, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.ReadOnly = True
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.txtIdNo.TabIndex = 0
            Me.txtIdNo.Translatable = False
            '
            'lblReportCode
            '
            Me.lblReportCode.BackColor = System.Drawing.Color.Transparent
            Me.lblReportCode.DisplayOnly = True
            Me.lblReportCode.EditingMode = False
            Me.lblReportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportCode.Location = New System.Drawing.Point(11, 36)
            Me.lblReportCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportCode.Name = "lblReportCode"
            Me.lblReportCode.Size = New System.Drawing.Size(193, 23)
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
            Me.txtReportCode.Location = New System.Drawing.Point(206, 36)
            Me.txtReportCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportCode.MaximumValue = Nothing
            Me.txtReportCode.MinimumValue = Nothing
            Me.txtReportCode.Name = "txtReportCode"
            Me.txtReportCode.OldValue = Nothing
            Me.txtReportCode.OverrideMaxLength = 0
            Me.txtReportCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportCode.Size = New System.Drawing.Size(403, 23)
            Me.txtReportCode.TabIndex = 1
            Me.txtReportCode.Translatable = False
            '
            'lblReportName
            '
            Me.lblReportName.BackColor = System.Drawing.Color.Transparent
            Me.lblReportName.DisplayOnly = True
            Me.lblReportName.EditingMode = False
            Me.lblReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportName.Location = New System.Drawing.Point(11, 61)
            Me.lblReportName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportName.Name = "lblReportName"
            Me.lblReportName.Size = New System.Drawing.Size(193, 23)
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
            Me.txtReportName.Location = New System.Drawing.Point(206, 61)
            Me.txtReportName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportName.MaximumValue = Nothing
            Me.txtReportName.MinimumValue = Nothing
            Me.txtReportName.Name = "txtReportName"
            Me.txtReportName.OldValue = Nothing
            Me.txtReportName.OverrideMaxLength = 0
            Me.txtReportName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportName.Size = New System.Drawing.Size(403, 23)
            Me.txtReportName.TabIndex = 2
            Me.txtReportName.Translatable = False
            '
            'lblReportNameAra
            '
            Me.lblReportNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblReportNameAra.DisplayOnly = True
            Me.lblReportNameAra.EditingMode = False
            Me.lblReportNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblReportNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportNameAra.Name = "lblReportNameAra"
            Me.lblReportNameAra.Size = New System.Drawing.Size(193, 23)
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
            Me.txtReportNameAra.EnglishControl = Me.txtReportName
            Me.txtReportNameAra.FieldDescription = Nothing
            Me.txtReportNameAra.FieldName = Nothing
            Me.txtReportNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportNameAra.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtReportNameAra, True)
            Me.txtReportNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtReportNameAra.LinkedLabel = Nothing
            Me.txtReportNameAra.Location = New System.Drawing.Point(206, 86)
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
            'lblReportGroupIdNo
            '
            Me.lblReportGroupIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblReportGroupIdNo.DisplayOnly = True
            Me.lblReportGroupIdNo.EditingMode = False
            Me.lblReportGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportGroupIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportGroupIdNo.Location = New System.Drawing.Point(11, 111)
            Me.lblReportGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportGroupIdNo.Name = "lblReportGroupIdNo"
            Me.lblReportGroupIdNo.Size = New System.Drawing.Size(193, 23)
            Me.lblReportGroupIdNo.TabIndex = 281
            Me.lblReportGroupIdNo.Text = "Report Group"
            Me.lblReportGroupIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportGroupIdNo.Translatable = True
            '
            'cboReportGroupIdNo
            '
            Me.cboReportGroupIdNo.BackColor = System.Drawing.Color.White
            Me.cboReportGroupIdNo.BegFindValue = Nothing
            Me.cboReportGroupIdNo.ChangingSearchValueOnly = False
            Me.cboReportGroupIdNo.CurrentSearchTerm = ""
            Me.cboReportGroupIdNo.DataValue = Nothing
            Me.cboReportGroupIdNo.DefaultValue = Nothing
            Me.cboReportGroupIdNo.DisplayMember = "Name"
            Me.cboReportGroupIdNo.Editable = True
            Me.cboReportGroupIdNo.EditingMode = True
            Me.cboReportGroupIdNo.EndFindValue = Nothing
            Me.cboReportGroupIdNo.FieldDescription = Nothing
            Me.cboReportGroupIdNo.FieldName = Nothing
            Me.cboReportGroupIdNo.FilterRule = Nothing
            Me.cboReportGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboReportGroupIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboReportGroupIdNo, True)
            Me.cboReportGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboReportGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboReportGroupIdNo.FormattingEnabled = True
            Me.cboReportGroupIdNo.HideWhenNotEditingOrAdding = False
            Me.cboReportGroupIdNo.IgnoreCase = False
            Me.cboReportGroupIdNo.IntegralHeight = False
            Me.cboReportGroupIdNo.LimitToList = False
            Me.cboReportGroupIdNo.LinkedLabel = Me.lblPrintJobIdNo
            Me.cboReportGroupIdNo.Location = New System.Drawing.Point(206, 111)
            Me.cboReportGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboReportGroupIdNo.Name = "cboReportGroupIdNo"
            Me.cboReportGroupIdNo.OldValue = 0
            Me.cboReportGroupIdNo.OriginalDataSource = Nothing
            Me.cboReportGroupIdNo.OriginalList = Nothing
            Me.cboReportGroupIdNo.OverrideDropDownStyleList = False
            Me.cboReportGroupIdNo.PreviousSearchTerm = Nothing
            Me.cboReportGroupIdNo.PropertySelector = Nothing
            Me.cboReportGroupIdNo.Size = New System.Drawing.Size(403, 24)
            Me.cboReportGroupIdNo.SuggestBoxHeight = 200
            Me.cboReportGroupIdNo.SuggestCharCount = 0
            Me.cboReportGroupIdNo.SuggestListOrderRule = Nothing
            Me.cboReportGroupIdNo.TabIndex = 4
            Me.cboReportGroupIdNo.TextToSearch = Nothing
            Me.cboReportGroupIdNo.Translatable = False
            Me.cboReportGroupIdNo.ValueIsMandatory = False
            Me.cboReportGroupIdNo.ValueIsNullable = False
            Me.cboReportGroupIdNo.ValueIsNumeric = False
            Me.cboReportGroupIdNo.ValueMember = "IdNo"
            '
            'lblPrintJobIdNo
            '
            Me.lblPrintJobIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblPrintJobIdNo.DisplayOnly = True
            Me.lblPrintJobIdNo.EditingMode = False
            Me.lblPrintJobIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobIdNo.Location = New System.Drawing.Point(11, 288)
            Me.lblPrintJobIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobIdNo.Name = "lblPrintJobIdNo"
            Me.lblPrintJobIdNo.Size = New System.Drawing.Size(193, 23)
            Me.lblPrintJobIdNo.TabIndex = 153
            Me.lblPrintJobIdNo.Text = "Print Job Name"
            Me.lblPrintJobIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobIdNo.Translatable = True
            '
            'lblQueryForm
            '
            Me.lblQueryForm.BackColor = System.Drawing.Color.Transparent
            Me.lblQueryForm.DisplayOnly = True
            Me.lblQueryForm.EditingMode = False
            Me.lblQueryForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryForm.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryForm.Location = New System.Drawing.Point(11, 138)
            Me.lblQueryForm.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryForm.Name = "lblQueryForm"
            Me.lblQueryForm.Size = New System.Drawing.Size(193, 23)
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
            Me.txtQueryForm.Location = New System.Drawing.Point(206, 138)
            Me.txtQueryForm.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryForm.MaximumValue = Nothing
            Me.txtQueryForm.MinimumValue = Nothing
            Me.txtQueryForm.Name = "txtQueryForm"
            Me.txtQueryForm.OldValue = Nothing
            Me.txtQueryForm.OverrideMaxLength = 0
            Me.txtQueryForm.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryForm.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryForm.TabIndex = 5
            Me.txtQueryForm.Translatable = False
            '
            'lblQueryFormParameters
            '
            Me.lblQueryFormParameters.BackColor = System.Drawing.Color.Transparent
            Me.lblQueryFormParameters.DisplayOnly = True
            Me.lblQueryFormParameters.EditingMode = False
            Me.lblQueryFormParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryFormParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryFormParameters.Location = New System.Drawing.Point(11, 163)
            Me.lblQueryFormParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryFormParameters.Name = "lblQueryFormParameters"
            Me.lblQueryFormParameters.Size = New System.Drawing.Size(193, 23)
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
            Me.txtQueryFormParameters.Location = New System.Drawing.Point(206, 163)
            Me.txtQueryFormParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryFormParameters.MaximumValue = Nothing
            Me.txtQueryFormParameters.MinimumValue = Nothing
            Me.txtQueryFormParameters.Name = "txtQueryFormParameters"
            Me.txtQueryFormParameters.OldValue = Nothing
            Me.txtQueryFormParameters.OverrideMaxLength = 0
            Me.txtQueryFormParameters.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryFormParameters.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryFormParameters.TabIndex = 6
            Me.txtQueryFormParameters.Translatable = False
            '
            'lblQueryParameters
            '
            Me.lblQueryParameters.BackColor = System.Drawing.Color.Transparent
            Me.lblQueryParameters.DisplayOnly = True
            Me.lblQueryParameters.EditingMode = False
            Me.lblQueryParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblQueryParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblQueryParameters.Location = New System.Drawing.Point(11, 188)
            Me.lblQueryParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.lblQueryParameters.Name = "lblQueryParameters"
            Me.lblQueryParameters.Size = New System.Drawing.Size(193, 23)
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
            Me.txtQueryParameters.Location = New System.Drawing.Point(206, 188)
            Me.txtQueryParameters.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQueryParameters.MaximumValue = Nothing
            Me.txtQueryParameters.MinimumValue = Nothing
            Me.txtQueryParameters.Name = "txtQueryParameters"
            Me.txtQueryParameters.OldValue = Nothing
            Me.txtQueryParameters.OverrideMaxLength = 0
            Me.txtQueryParameters.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQueryParameters.Size = New System.Drawing.Size(403, 23)
            Me.txtQueryParameters.TabIndex = 7
            Me.txtQueryParameters.Translatable = False
            '
            'lblReportTitle
            '
            Me.lblReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblReportTitle.DisplayOnly = True
            Me.lblReportTitle.EditingMode = False
            Me.lblReportTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportTitle.Location = New System.Drawing.Point(11, 213)
            Me.lblReportTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Size = New System.Drawing.Size(193, 23)
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
            Me.txtReportTitle.Location = New System.Drawing.Point(206, 213)
            Me.txtReportTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportTitle.MaximumValue = Nothing
            Me.txtReportTitle.MinimumValue = Nothing
            Me.txtReportTitle.Name = "txtReportTitle"
            Me.txtReportTitle.OldValue = Nothing
            Me.txtReportTitle.OverrideMaxLength = 0
            Me.txtReportTitle.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportTitle.Size = New System.Drawing.Size(403, 23)
            Me.txtReportTitle.TabIndex = 8
            Me.txtReportTitle.Translatable = False
            '
            'lblReportTitleAra
            '
            Me.lblReportTitleAra.BackColor = System.Drawing.Color.Transparent
            Me.lblReportTitleAra.DisplayOnly = True
            Me.lblReportTitleAra.EditingMode = False
            Me.lblReportTitleAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportTitleAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportTitleAra.Location = New System.Drawing.Point(11, 238)
            Me.lblReportTitleAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportTitleAra.Name = "lblReportTitleAra"
            Me.lblReportTitleAra.Size = New System.Drawing.Size(193, 23)
            Me.lblReportTitleAra.TabIndex = 195
            Me.lblReportTitleAra.Text = "Report Title Arabic"
            Me.lblReportTitleAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportTitleAra.Translatable = True
            '
            'txtReportTitleAra
            '
            Me.txtReportTitleAra.BackColor = System.Drawing.Color.White
            Me.txtReportTitleAra.BegFindValue = Nothing
            Me.txtReportTitleAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportTitleAra.ComputedValue = False
            Me.txtReportTitleAra.CustomFormat = Nothing
            Me.txtReportTitleAra.DataBoundControl = True
            Me.txtReportTitleAra.EditingMode = True
            Me.txtReportTitleAra.EndFindValue = Nothing
            Me.txtReportTitleAra.EnglishControl = Me.txtReportTitle
            Me.txtReportTitleAra.FieldDescription = Nothing
            Me.txtReportTitleAra.FieldName = Nothing
            Me.txtReportTitleAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportTitleAra.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtReportTitleAra, True)
            Me.txtReportTitleAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportTitleAra.ForeColor = System.Drawing.Color.Black
            Me.txtReportTitleAra.LinkedLabel = Nothing
            Me.txtReportTitleAra.Location = New System.Drawing.Point(206, 238)
            Me.txtReportTitleAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportTitleAra.MaximumValue = Nothing
            Me.txtReportTitleAra.MinimumValue = Nothing
            Me.txtReportTitleAra.Name = "txtReportTitleAra"
            Me.txtReportTitleAra.OldValue = Nothing
            Me.txtReportTitleAra.OverrideMaxLength = 0
            Me.txtReportTitleAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtReportTitleAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportTitleAra.Size = New System.Drawing.Size(403, 23)
            Me.txtReportTitleAra.TabIndex = 9
            Me.txtReportTitleAra.Translatable = False
            '
            'lblReportFileName
            '
            Me.lblReportFileName.BackColor = System.Drawing.Color.Transparent
            Me.lblReportFileName.DisplayOnly = True
            Me.lblReportFileName.EditingMode = False
            Me.lblReportFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportFileName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportFileName.Location = New System.Drawing.Point(11, 263)
            Me.lblReportFileName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportFileName.Name = "lblReportFileName"
            Me.lblReportFileName.Size = New System.Drawing.Size(193, 23)
            Me.lblReportFileName.TabIndex = 191
            Me.lblReportFileName.Text = "Report File Name"
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
            Me.txtReportFileName.Location = New System.Drawing.Point(206, 263)
            Me.txtReportFileName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportFileName.MaximumValue = Nothing
            Me.txtReportFileName.MinimumValue = Nothing
            Me.txtReportFileName.Name = "txtReportFileName"
            Me.txtReportFileName.OldValue = Nothing
            Me.txtReportFileName.OverrideMaxLength = 0
            Me.txtReportFileName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportFileName.Size = New System.Drawing.Size(403, 23)
            Me.txtReportFileName.TabIndex = 10
            Me.txtReportFileName.Translatable = False
            '
            'cboPrintJobIdNo
            '
            Me.cboPrintJobIdNo.BackColor = System.Drawing.Color.White
            Me.cboPrintJobIdNo.BegFindValue = Nothing
            Me.cboPrintJobIdNo.ChangingSearchValueOnly = False
            Me.cboPrintJobIdNo.CurrentSearchTerm = ""
            Me.cboPrintJobIdNo.DataValue = Nothing
            Me.cboPrintJobIdNo.DefaultValue = Nothing
            Me.cboPrintJobIdNo.DisplayMember = "Name"
            Me.cboPrintJobIdNo.Editable = True
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
            Me.cboPrintJobIdNo.Location = New System.Drawing.Point(206, 288)
            Me.cboPrintJobIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPrintJobIdNo.Name = "cboPrintJobIdNo"
            Me.cboPrintJobIdNo.OldValue = 0
            Me.cboPrintJobIdNo.OriginalDataSource = Nothing
            Me.cboPrintJobIdNo.OriginalList = Nothing
            Me.cboPrintJobIdNo.OverrideDropDownStyleList = False
            Me.cboPrintJobIdNo.PreviousSearchTerm = Nothing
            Me.cboPrintJobIdNo.PropertySelector = Nothing
            Me.cboPrintJobIdNo.Size = New System.Drawing.Size(403, 24)
            Me.cboPrintJobIdNo.SuggestBoxHeight = 200
            Me.cboPrintJobIdNo.SuggestCharCount = 0
            Me.cboPrintJobIdNo.SuggestListOrderRule = Nothing
            Me.cboPrintJobIdNo.TabIndex = 11
            Me.cboPrintJobIdNo.TextToSearch = Nothing
            Me.cboPrintJobIdNo.Translatable = False
            Me.cboPrintJobIdNo.ValueIsMandatory = False
            Me.cboPrintJobIdNo.ValueIsNullable = False
            Me.cboPrintJobIdNo.ValueIsNumeric = False
            Me.cboPrintJobIdNo.ValueMember = "IdNo"
            '
            'lblReportOrder
            '
            Me.lblReportOrder.BackColor = System.Drawing.Color.Transparent
            Me.lblReportOrder.DisplayOnly = True
            Me.lblReportOrder.EditingMode = False
            Me.lblReportOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReportOrder.Location = New System.Drawing.Point(11, 315)
            Me.lblReportOrder.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportOrder.Name = "lblReportOrder"
            Me.lblReportOrder.Size = New System.Drawing.Size(193, 23)
            Me.lblReportOrder.TabIndex = 193
            Me.lblReportOrder.Text = "Report Sort Order Number"
            Me.lblReportOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportOrder.Translatable = True
            '
            'txtReportOrder
            '
            Me.txtReportOrder.BackColor = System.Drawing.Color.White
            Me.txtReportOrder.BegFindValue = Nothing
            Me.txtReportOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportOrder.ComputedValue = False
            Me.txtReportOrder.CustomFormat = Nothing
            Me.txtReportOrder.DataBoundControl = True
            Me.txtReportOrder.EditingMode = True
            Me.txtReportOrder.EndFindValue = Nothing
            Me.txtReportOrder.FieldDescription = Nothing
            Me.txtReportOrder.FieldName = Nothing
            Me.txtReportOrder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportOrder.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtReportOrder, True)
            Me.txtReportOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReportOrder.ForeColor = System.Drawing.Color.Black
            Me.txtReportOrder.LinkedLabel = Me.lblReportOrder
            Me.txtReportOrder.Location = New System.Drawing.Point(206, 315)
            Me.txtReportOrder.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReportOrder.MaximumValue = Nothing
            Me.txtReportOrder.MinimumValue = Nothing
            Me.txtReportOrder.Name = "txtReportOrder"
            Me.txtReportOrder.OldValue = Nothing
            Me.txtReportOrder.OverrideMaxLength = 0
            Me.txtReportOrder.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportOrder.Size = New System.Drawing.Size(403, 23)
            Me.txtReportOrder.TabIndex = 12
            Me.txtReportOrder.Translatable = False
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateCreated.Location = New System.Drawing.Point(11, 365)
            Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Size = New System.Drawing.Size(193, 23)
            Me.lblDateCreated.TabIndex = 200
            Me.lblDateCreated.Text = "Date Created"
            Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateCreated.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDateCreated, True)
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.Location = New System.Drawing.Point(206, 365)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(403, 23)
            Me.txtDateCreated.TabIndex = 14
            Me.txtDateCreated.Translatable = False
            '
            'lblActive
            '
            Me.lblActive.BackColor = System.Drawing.Color.Transparent
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblActive.Location = New System.Drawing.Point(11, 390)
            Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Size = New System.Drawing.Size(193, 24)
            Me.lblActive.TabIndex = 279
            Me.lblActive.Text = "Active?"
            Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblActive.Translatable = True
            '
            'chkActive
            '
            Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkActive.AutoCheck = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = True
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.floDataDisplay.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Location = New System.Drawing.Point(206, 390)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = False
            Me.chkActive.OldValue = ""
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Size = New System.Drawing.Size(13, 13)
            Me.chkActive.TabIndex = 15
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'lblBranchIdNo
            '
            Me.lblBranchIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblBranchIdNo.DisplayOnly = True
            Me.lblBranchIdNo.EditingMode = False
            Me.lblBranchIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblBranchIdNo, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblBranchIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBranchIdNo.Location = New System.Drawing.Point(11, 416)
            Me.lblBranchIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBranchIdNo.Name = "lblBranchIdNo"
            Me.lblBranchIdNo.Size = New System.Drawing.Size(193, 23)
            Me.lblBranchIdNo.TabIndex = 197
            Me.lblBranchIdNo.Text = "Branch Id No."
            Me.lblBranchIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBranchIdNo.Translatable = True
            Me.lblBranchIdNo.Visible = False
            '
            'txtBranchIdNo
            '
            Me.txtBranchIdNo.BackColor = System.Drawing.Color.White
            Me.txtBranchIdNo.BegFindValue = Nothing
            Me.txtBranchIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchIdNo.ComputedValue = False
            Me.txtBranchIdNo.CustomFormat = Nothing
            Me.txtBranchIdNo.DataBoundControl = True
            Me.txtBranchIdNo.EditingMode = True
            Me.txtBranchIdNo.EndFindValue = Nothing
            Me.txtBranchIdNo.FieldDescription = Nothing
            Me.txtBranchIdNo.FieldName = Nothing
            Me.txtBranchIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBranchIdNo, True)
            Me.txtBranchIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBranchIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtBranchIdNo.LinkedLabel = Me.lblReportOrder
            Me.txtBranchIdNo.Location = New System.Drawing.Point(206, 416)
            Me.txtBranchIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBranchIdNo.MaximumValue = Nothing
            Me.txtBranchIdNo.MinimumValue = Nothing
            Me.txtBranchIdNo.Name = "txtBranchIdNo"
            Me.txtBranchIdNo.OldValue = Nothing
            Me.txtBranchIdNo.OverrideMaxLength = 0
            Me.txtBranchIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchIdNo.Size = New System.Drawing.Size(403, 23)
            Me.txtBranchIdNo.TabIndex = 16
            Me.txtBranchIdNo.Translatable = False
            Me.txtBranchIdNo.Visible = False
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 340)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(193, 23)
            Me.CLabel1.TabIndex = 283
            Me.CLabel1.Text = "Database Name"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtDataBaseName
            '
            Me.txtDataBaseName.BackColor = System.Drawing.Color.White
            Me.txtDataBaseName.BegFindValue = Nothing
            Me.txtDataBaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDataBaseName.ComputedValue = False
            Me.txtDataBaseName.CustomFormat = Nothing
            Me.txtDataBaseName.DataBoundControl = True
            Me.txtDataBaseName.EditingMode = True
            Me.txtDataBaseName.EndFindValue = Nothing
            Me.txtDataBaseName.FieldDescription = Nothing
            Me.txtDataBaseName.FieldName = Nothing
            Me.txtDataBaseName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDataBaseName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDataBaseName, True)
            Me.txtDataBaseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDataBaseName.ForeColor = System.Drawing.Color.Black
            Me.txtDataBaseName.LinkedLabel = Me.CLabel1
            Me.txtDataBaseName.Location = New System.Drawing.Point(206, 340)
            Me.txtDataBaseName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDataBaseName.MaximumValue = Nothing
            Me.txtDataBaseName.MinimumValue = Nothing
            Me.txtDataBaseName.Name = "txtDataBaseName"
            Me.txtDataBaseName.OldValue = Nothing
            Me.txtDataBaseName.OverrideMaxLength = 0
            Me.txtDataBaseName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDataBaseName.Size = New System.Drawing.Size(403, 23)
            Me.txtDataBaseName.TabIndex = 13
            Me.txtDataBaseName.Translatable = False
            '
            'ReportEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1128, 552)
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
        Friend WithEvents cboPrintJobIdNo As AtmComboBox
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
        Friend WithEvents lblReportOrder As CLabel
        Friend WithEvents txtReportOrder As CTextBox
        Friend WithEvents lblReportTitleAra As CLabel
        Friend WithEvents txtReportTitleAra As CTextBoxArabic
        Friend WithEvents lblBranchIdNo As CLabel
        Friend WithEvents txtBranchIdNo As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblActive As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents cboReportGroupIdNo As AtmComboBox
        Friend WithEvents lblReportGroupIdNo As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtDataBaseName As CTextBox
    End Class
End Namespace