Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayElementEntryTv
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

        'NOTE: The following procedure is required by the Windodgvfactorytypews Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayElementEntryTv))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floPayElement = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpPayElement = New System.Windows.Forms.TableLayoutPanel()
            Me.cboReportGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblReportGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayElementKind = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayElementType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayElementKind = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayElementNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtPayElementName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayElementCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkSummary = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblSummary = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbcPayElement = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpCalculation = New System.Windows.Forms.TabPage()
            Me.floCalculation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpCalculation = New System.Windows.Forms.TableLayoutPanel()
            Me.lblQuantityType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboQuantityType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFactorValue = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCalculationType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBasePayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBasePaymentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblIncludeInEos = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIncludeInEOS = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.txtMultiplier = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboFactorType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFactorType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkTaxable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblTaxable = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSlash = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayElementType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblSlash2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            Me.floPostingAccounts = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.DataGridViewPayElementAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayElementIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayElementAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.tbpSummaryDetail = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayElementItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceSummary = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPayElementIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvFactorValue = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvFactorType = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.ParentIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayElementItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.tbpNotes = New System.Windows.Forms.TabPage()
            Me.floMain = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpNotes = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tabPageImages = New System.Windows.Forms.ImageList(Me.components)
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floPayElement.SuspendLayout()
            Me.tlpPayElement.SuspendLayout()
            Me.tbcPayElement.SuspendLayout()
            Me.tbpCalculation.SuspendLayout()
            Me.floCalculation.SuspendLayout()
            Me.tlpCalculation.SuspendLayout()
            Me.tbpAccountPosting.SuspendLayout()
            Me.floPostingAccounts.SuspendLayout()
            Me.tlpPostingAccounts.SuspendLayout()
            CType(Me.DataGridViewPayElementAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayElementAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpSummaryDetail.SuspendLayout()
            CType(Me.DataGridViewPayElementItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayElementItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpNotes.SuspendLayout()
            Me.floMain.SuspendLayout()
            Me.tlpNotes.SuspendLayout()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.FormTreeView, "FormTreeView")
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
            Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
            '
            'floPayElement
            '
            Me.floPayElement.BackColor = System.Drawing.Color.Transparent
            Me.floPayElement.Controls.Add(Me.tlpPayElement)
            Me.floPayElement.Controls.Add(Me.tbcPayElement)
            Me.floPayElement.Controls.Add(Me.CLabel1)
            resources.ApplyResources(Me.floPayElement, "floPayElement")
            Me.floPayElement.Name = "floPayElement"
            '
            'tlpPayElement
            '
            resources.ApplyResources(Me.tlpPayElement, "tlpPayElement")
            Me.tlpPayElement.Controls.Add(Me.cboReportGroupIdNo, 1, 4)
            Me.tlpPayElement.Controls.Add(Me.lblReportGroupIdNo, 0, 4)
            Me.tlpPayElement.Controls.Add(Me.cboPayElementKind, 1, 3)
            Me.tlpPayElement.Controls.Add(Me.lblPayElementKind, 0, 3)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementNameAra, 1, 2)
            Me.tlpPayElement.Controls.Add(Me.lblName, 0, 1)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementCode, 3, 0)
            Me.tlpPayElement.Controls.Add(Me.lblCode, 2, 0)
            Me.tlpPayElement.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementName, 1, 1)
            Me.tlpPayElement.Controls.Add(Me.lblNameAra, 0, 2)
            Me.tlpPayElement.Controls.Add(Me.chkSummary, 4, 3)
            Me.tlpPayElement.Controls.Add(Me.chkActive, 4, 4)
            Me.tlpPayElement.Controls.Add(Me.lblSummary, 3, 3)
            Me.tlpPayElement.Controls.Add(Me.lblActive, 3, 4)
            Me.tlpPayElement.Name = "tlpPayElement"
            '
            'cboReportGroupIdNo
            '
            Me.cboReportGroupIdNo.BackColor = System.Drawing.Color.White
            Me.cboReportGroupIdNo.BegFindValue = Nothing
            Me.cboReportGroupIdNo.ChangingSearchValueOnly = False
            Me.tlpPayElement.SetColumnSpan(Me.cboReportGroupIdNo, 2)
            Me.cboReportGroupIdNo.CurrentSearchTerm = ""
            Me.cboReportGroupIdNo.DefaultValue = Nothing
            Me.cboReportGroupIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboReportGroupIdNo, "cboReportGroupIdNo")
            Me.cboReportGroupIdNo.EditingMode = True
            Me.cboReportGroupIdNo.EndFindValue = Nothing
            Me.cboReportGroupIdNo.FieldDescription = Nothing
            Me.cboReportGroupIdNo.FieldName = Nothing
            Me.cboReportGroupIdNo.FilterRule = Nothing
            Me.cboReportGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboReportGroupIdNo.FindEnabled = False
            Me.cboReportGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboReportGroupIdNo.FormattingEnabled = True
            Me.cboReportGroupIdNo.HideWhenNotEditingOrAdding = False
            Me.cboReportGroupIdNo.IgnoreCase = False
            Me.cboReportGroupIdNo.LinkedLabel = Me.lblReportGroupIdNo
            Me.cboReportGroupIdNo.Name = "cboReportGroupIdNo"
            Me.cboReportGroupIdNo.OldValue = 0
            Me.cboReportGroupIdNo.OriginalDataSource = Nothing
            Me.cboReportGroupIdNo.OriginalList = Nothing
            Me.cboReportGroupIdNo.OverrideDropDownStyleList = False
            Me.cboReportGroupIdNo.PreviousSearchTerm = Nothing
            Me.cboReportGroupIdNo.PropertySelector = Nothing
            Me.cboReportGroupIdNo.ReadOnlyCombo = False
            Me.cboReportGroupIdNo.SuggestBoxHeight = 200
            Me.cboReportGroupIdNo.SuggestListOrderRule = Nothing
            Me.cboReportGroupIdNo.TextToSearch = Nothing
            Me.cboReportGroupIdNo.Translatable = False
            Me.cboReportGroupIdNo.ValueIsMandatory = False
            Me.cboReportGroupIdNo.ValueIsNullable = False
            Me.cboReportGroupIdNo.ValueIsNumeric = False
            Me.cboReportGroupIdNo.ValueMember = "IdNo"
            '
            'lblReportGroupIdNo
            '
            Me.lblReportGroupIdNo.DisplayOnly = True
            Me.lblReportGroupIdNo.EditingMode = False
            resources.ApplyResources(Me.lblReportGroupIdNo, "lblReportGroupIdNo")
            Me.lblReportGroupIdNo.Name = "lblReportGroupIdNo"
            Me.lblReportGroupIdNo.Translatable = True
            '
            'cboPayElementKind
            '
            Me.cboPayElementKind.BackColor = System.Drawing.Color.White
            Me.cboPayElementKind.BegFindValue = Nothing
            Me.cboPayElementKind.ChangingSearchValueOnly = False
            Me.cboPayElementKind.CurrentSearchTerm = ""
            Me.cboPayElementKind.DefaultValue = Nothing
            Me.cboPayElementKind.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayElementKind, "cboPayElementKind")
            Me.cboPayElementKind.EditingMode = True
            Me.cboPayElementKind.EndFindValue = Nothing
            Me.cboPayElementKind.FieldDescription = Nothing
            Me.cboPayElementKind.FieldName = Nothing
            Me.cboPayElementKind.FilterRule = Nothing
            Me.cboPayElementKind.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayElementKind.FindEnabled = False
            Me.cboPayElementKind.ForeColor = System.Drawing.Color.Black
            Me.cboPayElementKind.FormattingEnabled = True
            Me.cboPayElementKind.HideWhenNotEditingOrAdding = False
            Me.cboPayElementKind.IgnoreCase = False
            Me.cboPayElementKind.LinkedLabel = Me.lblPayElementType
            Me.cboPayElementKind.Name = "cboPayElementKind"
            Me.cboPayElementKind.OldValue = 0
            Me.cboPayElementKind.OriginalDataSource = Nothing
            Me.cboPayElementKind.OriginalList = Nothing
            Me.cboPayElementKind.OverrideDropDownStyleList = False
            Me.cboPayElementKind.PreviousSearchTerm = Nothing
            Me.cboPayElementKind.PropertySelector = Nothing
            Me.cboPayElementKind.ReadOnlyCombo = False
            Me.cboPayElementKind.SuggestBoxHeight = 200
            Me.cboPayElementKind.SuggestListOrderRule = Nothing
            Me.cboPayElementKind.TextToSearch = Nothing
            Me.cboPayElementKind.Translatable = False
            Me.cboPayElementKind.ValueIsMandatory = False
            Me.cboPayElementKind.ValueIsNullable = False
            Me.cboPayElementKind.ValueIsNumeric = False
            Me.cboPayElementKind.ValueMember = "Code"
            '
            'lblPayElementType
            '
            Me.lblPayElementType.DisplayOnly = True
            Me.lblPayElementType.EditingMode = False
            resources.ApplyResources(Me.lblPayElementType, "lblPayElementType")
            Me.lblPayElementType.Name = "lblPayElementType"
            Me.lblPayElementType.Translatable = True
            '
            'lblPayElementKind
            '
            Me.lblPayElementKind.DisplayOnly = True
            Me.lblPayElementKind.EditingMode = False
            resources.ApplyResources(Me.lblPayElementKind, "lblPayElementKind")
            Me.lblPayElementKind.Name = "lblPayElementKind"
            Me.lblPayElementKind.Translatable = True
            '
            'txtPayElementNameAra
            '
            Me.txtPayElementNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayElementNameAra.BegFindValue = Nothing
            Me.txtPayElementNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPayElement.SetColumnSpan(Me.txtPayElementNameAra, 4)
            Me.txtPayElementNameAra.ComputedValue = False
            Me.txtPayElementNameAra.CustomFormat = Nothing
            Me.txtPayElementNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtPayElementNameAra, "txtPayElementNameAra")
            Me.txtPayElementNameAra.EditingMode = False
            Me.txtPayElementNameAra.EndFindValue = Nothing
            Me.txtPayElementNameAra.EnglishControl = Me.txtPayElementName
            Me.txtPayElementNameAra.FieldDescription = Nothing
            Me.txtPayElementNameAra.FieldName = Nothing
            Me.txtPayElementNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayElementNameAra.FindEnabled = True
            Me.txtPayElementNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayElementNameAra.LinkedLabel = Nothing
            Me.txtPayElementNameAra.MaximumValue = Nothing
            Me.txtPayElementNameAra.MinimumValue = Nothing
            Me.txtPayElementNameAra.Name = "txtPayElementNameAra"
            Me.txtPayElementNameAra.OldValue = Nothing
            Me.txtPayElementNameAra.ReadOnly = True
            Me.txtPayElementNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayElementNameAra.Translatable = False
            Me.txtPayElementNameAra.ValueIsUnique = True
            '
            'txtPayElementName
            '
            Me.txtPayElementName.BackColor = System.Drawing.Color.White
            Me.txtPayElementName.BegFindValue = Nothing
            Me.txtPayElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPayElement.SetColumnSpan(Me.txtPayElementName, 4)
            Me.txtPayElementName.ComputedValue = False
            Me.txtPayElementName.CustomFormat = Nothing
            Me.txtPayElementName.DataBoundControl = True
            resources.ApplyResources(Me.txtPayElementName, "txtPayElementName")
            Me.txtPayElementName.EditingMode = False
            Me.txtPayElementName.EndFindValue = Nothing
            Me.txtPayElementName.FieldDescription = Nothing
            Me.txtPayElementName.FieldName = Nothing
            Me.txtPayElementName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayElementName.FindEnabled = True
            Me.txtPayElementName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementName, CType(resources.GetObject("txtPayElementName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtPayElementName.LinkedLabel = Nothing
            Me.txtPayElementName.MaximumValue = Nothing
            Me.txtPayElementName.MinimumValue = Nothing
            Me.txtPayElementName.Name = "txtPayElementName"
            Me.txtPayElementName.OldValue = Nothing
            Me.txtPayElementName.ReadOnly = True
            Me.txtPayElementName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayElementName.Translatable = False
            Me.txtPayElementName.ValueIsMandatory = True
            Me.txtPayElementName.ValueIsUnique = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'txtPayElementCode
            '
            Me.txtPayElementCode.BackColor = System.Drawing.Color.White
            Me.txtPayElementCode.BegFindValue = Nothing
            Me.txtPayElementCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPayElement.SetColumnSpan(Me.txtPayElementCode, 2)
            Me.txtPayElementCode.ComputedValue = False
            Me.txtPayElementCode.CustomFormat = Nothing
            Me.txtPayElementCode.DataBoundControl = True
            resources.ApplyResources(Me.txtPayElementCode, "txtPayElementCode")
            Me.txtPayElementCode.EditingMode = True
            Me.txtPayElementCode.EndFindValue = Nothing
            Me.txtPayElementCode.FieldDescription = Nothing
            Me.txtPayElementCode.FieldName = Nothing
            Me.txtPayElementCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayElementCode.FindEnabled = True
            Me.txtPayElementCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconPadding"), Integer))
            Me.txtPayElementCode.LinkedLabel = Nothing
            Me.txtPayElementCode.MaximumValue = Nothing
            Me.txtPayElementCode.MinimumValue = Nothing
            Me.txtPayElementCode.Name = "txtPayElementCode"
            Me.txtPayElementCode.OldValue = Nothing
            Me.txtPayElementCode.ReadOnly = True
            Me.txtPayElementCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayElementCode.Translatable = False
            Me.txtPayElementCode.ValueIsMandatory = True
            Me.txtPayElementCode.ValueIsUnique = True
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'chkSummary
            '
            Me.chkSummary.BackColor = System.Drawing.Color.White
            Me.chkSummary.BegFindValue = Nothing
            Me.chkSummary.DisplayOnly = False
            Me.chkSummary.EditingMode = True
            Me.chkSummary.EndFindValue = Nothing
            Me.chkSummary.FieldDescription = Nothing
            Me.chkSummary.FieldName = Nothing
            Me.chkSummary.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkSummary.FindEnabled = False
            resources.ApplyResources(Me.chkSummary, "chkSummary")
            Me.chkSummary.ForeColor = System.Drawing.Color.Black
            Me.chkSummary.IFindableControl_FindEnabled = False
            Me.chkSummary.IgnoreCase = False
            Me.chkSummary.LinkedLabel = Me.lblSummary
            Me.chkSummary.Name = "chkSummary"
            Me.chkSummary.NoLabel = True
            Me.chkSummary.OldValue = Nothing
            Me.chkSummary.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkSummary.Translatable = False
            Me.chkSummary.UseVisualStyleBackColor = False
            '
            'lblSummary
            '
            resources.ApplyResources(Me.lblSummary, "lblSummary")
            Me.lblSummary.DisplayOnly = True
            Me.lblSummary.EditingMode = False
            Me.lblSummary.Name = "lblSummary"
            Me.lblSummary.Translatable = True
            '
            'chkActive
            '
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = True
            Me.chkActive.OldValue = Nothing
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'lblActive
            '
            resources.ApplyResources(Me.lblActive, "lblActive")
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Translatable = True
            '
            'tbcPayElement
            '
            resources.ApplyResources(Me.tbcPayElement, "tbcPayElement")
            Me.tbcPayElement.Controls.Add(Me.tbpCalculation)
            Me.tbcPayElement.Controls.Add(Me.tbpAccountPosting)
            Me.tbcPayElement.Controls.Add(Me.tbpSummaryDetail)
            Me.tbcPayElement.Controls.Add(Me.tbpNotes)
            Me.tbcPayElement.ImageList = Me.tabPageImages
            Me.tbcPayElement.Name = "tbcPayElement"
            Me.tbcPayElement.SelectedIndex = 0
            '
            'tbpCalculation
            '
            Me.tbpCalculation.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.tbpCalculation.Controls.Add(Me.floCalculation)
            resources.ApplyResources(Me.tbpCalculation, "tbpCalculation")
            Me.tbpCalculation.Name = "tbpCalculation"
            Me.tbpCalculation.UseVisualStyleBackColor = True
            '
            'floCalculation
            '
            Me.floCalculation.BackColor = System.Drawing.Color.Transparent
            resources.ApplyResources(Me.floCalculation, "floCalculation")
            Me.floCalculation.Controls.Add(Me.tlpCalculation)
            Me.floCalculation.Name = "floCalculation"
            '
            'tlpCalculation
            '
            resources.ApplyResources(Me.tlpCalculation, "tlpCalculation")
            Me.tlpCalculation.Controls.Add(Me.lblQuantityType, 0, 5)
            Me.tlpCalculation.Controls.Add(Me.cboQuantityType, 1, 5)
            Me.tlpCalculation.Controls.Add(Me.cboCalculationType, 1, 1)
            Me.tlpCalculation.Controls.Add(Me.lblPayElementType, 0, 0)
            Me.tlpCalculation.Controls.Add(Me.lblFactorValue, 0, 4)
            Me.tlpCalculation.Controls.Add(Me.lblCalculationType, 0, 1)
            Me.tlpCalculation.Controls.Add(Me.txtRate, 1, 2)
            Me.tlpCalculation.Controls.Add(Me.txtDefaultQuantity, 1, 6)
            Me.tlpCalculation.Controls.Add(Me.lblBasePayment, 0, 3)
            Me.tlpCalculation.Controls.Add(Me.cboBasePaymentIdNo, 1, 3)
            Me.tlpCalculation.Controls.Add(Me.lblIncludeInEos, 0, 7)
            Me.tlpCalculation.Controls.Add(Me.chkIncludeInEOS, 2, 7)
            Me.tlpCalculation.Controls.Add(Me.txtMultiplier, 1, 4)
            Me.tlpCalculation.Controls.Add(Me.cboFactorType, 2, 4)
            Me.tlpCalculation.Controls.Add(Me.chkTaxable, 2, 8)
            Me.tlpCalculation.Controls.Add(Me.lblSlash, 2, 2)
            Me.tlpCalculation.Controls.Add(Me.cboUnit, 3, 2)
            Me.tlpCalculation.Controls.Add(Me.cboPayElementType, 1, 0)
            Me.tlpCalculation.Controls.Add(Me.lblRate, 0, 2)
            Me.tlpCalculation.Controls.Add(Me.lblDefaultQuantity, 0, 6)
            Me.tlpCalculation.Controls.Add(Me.lblSlash2, 2, 6)
            Me.tlpCalculation.Controls.Add(Me.lblTaxable, 0, 8)
            Me.tlpCalculation.Controls.Add(Me.lblUnit, 3, 7)
            Me.tlpCalculation.Controls.Add(Me.lblFactorType, 3, 8)
            Me.tlpCalculation.Name = "tlpCalculation"
            '
            'lblQuantityType
            '
            resources.ApplyResources(Me.lblQuantityType, "lblQuantityType")
            Me.lblQuantityType.DisplayOnly = True
            Me.lblQuantityType.EditingMode = False
            Me.lblQuantityType.Name = "lblQuantityType"
            Me.lblQuantityType.Translatable = True
            '
            'cboQuantityType
            '
            Me.cboQuantityType.BackColor = System.Drawing.Color.White
            Me.cboQuantityType.BegFindValue = Nothing
            Me.cboQuantityType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboQuantityType, 2)
            Me.cboQuantityType.CurrentSearchTerm = ""
            Me.cboQuantityType.DefaultValue = Nothing
            Me.cboQuantityType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboQuantityType, "cboQuantityType")
            Me.cboQuantityType.EditingMode = True
            Me.cboQuantityType.EndFindValue = Nothing
            Me.cboQuantityType.FieldDescription = Nothing
            Me.cboQuantityType.FieldName = Nothing
            Me.cboQuantityType.FilterRule = Nothing
            Me.cboQuantityType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboQuantityType.FindEnabled = False
            Me.cboQuantityType.ForeColor = System.Drawing.Color.Black
            Me.cboQuantityType.FormattingEnabled = True
            Me.cboQuantityType.HideWhenNotEditingOrAdding = False
            Me.cboQuantityType.IgnoreCase = False
            Me.cboQuantityType.LinkedLabel = Me.lblQuantityType
            Me.cboQuantityType.Name = "cboQuantityType"
            Me.cboQuantityType.OldValue = 0
            Me.cboQuantityType.OriginalDataSource = Nothing
            Me.cboQuantityType.OriginalList = Nothing
            Me.cboQuantityType.OverrideDropDownStyleList = False
            Me.cboQuantityType.PreviousSearchTerm = Nothing
            Me.cboQuantityType.PropertySelector = Nothing
            Me.cboQuantityType.ReadOnlyCombo = False
            Me.cboQuantityType.SuggestBoxHeight = 200
            Me.cboQuantityType.SuggestListOrderRule = Nothing
            Me.cboQuantityType.TextToSearch = Nothing
            Me.cboQuantityType.Translatable = False
            Me.cboQuantityType.ValueIsMandatory = False
            Me.cboQuantityType.ValueIsNullable = False
            Me.cboQuantityType.ValueIsNumeric = False
            Me.cboQuantityType.ValueMember = "Code"
            '
            'cboCalculationType
            '
            Me.cboCalculationType.BackColor = System.Drawing.Color.White
            Me.cboCalculationType.BegFindValue = Nothing
            Me.cboCalculationType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboCalculationType, 3)
            Me.cboCalculationType.CurrentSearchTerm = ""
            Me.cboCalculationType.DefaultValue = Nothing
            Me.cboCalculationType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
            Me.cboCalculationType.EditingMode = True
            Me.cboCalculationType.EndFindValue = Nothing
            Me.cboCalculationType.FieldDescription = Nothing
            Me.cboCalculationType.FieldName = Nothing
            Me.cboCalculationType.FilterRule = Nothing
            Me.cboCalculationType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboCalculationType.FindEnabled = False
            Me.cboCalculationType.ForeColor = System.Drawing.Color.Black
            Me.cboCalculationType.FormattingEnabled = True
            Me.cboCalculationType.HideWhenNotEditingOrAdding = False
            Me.cboCalculationType.IgnoreCase = False
            Me.cboCalculationType.LinkedLabel = Me.lblPayElementType
            Me.cboCalculationType.Name = "cboCalculationType"
            Me.cboCalculationType.OldValue = 0
            Me.cboCalculationType.OriginalDataSource = Nothing
            Me.cboCalculationType.OriginalList = Nothing
            Me.cboCalculationType.OverrideDropDownStyleList = False
            Me.cboCalculationType.PreviousSearchTerm = Nothing
            Me.cboCalculationType.PropertySelector = Nothing
            Me.cboCalculationType.ReadOnlyCombo = False
            Me.cboCalculationType.SuggestBoxHeight = 200
            Me.cboCalculationType.SuggestListOrderRule = Nothing
            Me.cboCalculationType.TextToSearch = Nothing
            Me.cboCalculationType.Translatable = False
            Me.cboCalculationType.ValueIsMandatory = False
            Me.cboCalculationType.ValueIsNullable = False
            Me.cboCalculationType.ValueIsNumeric = False
            Me.cboCalculationType.ValueMember = "Code"
            '
            'lblFactorValue
            '
            resources.ApplyResources(Me.lblFactorValue, "lblFactorValue")
            Me.lblFactorValue.DisplayOnly = True
            Me.lblFactorValue.EditingMode = False
            Me.lblFactorValue.Name = "lblFactorValue"
            Me.lblFactorValue.Translatable = True
            '
            'lblCalculationType
            '
            resources.ApplyResources(Me.lblCalculationType, "lblCalculationType")
            Me.lblCalculationType.DisplayOnly = True
            Me.lblCalculationType.EditingMode = False
            Me.lblCalculationType.Name = "lblCalculationType"
            Me.lblCalculationType.Translatable = True
            '
            'txtRate
            '
            Me.txtRate.BackColor = System.Drawing.Color.White
            Me.txtRate.BegFindValue = Nothing
            Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRate.ComputedValue = False
            Me.txtRate.CustomFormat = Nothing
            Me.txtRate.DataBoundControl = True
            resources.ApplyResources(Me.txtRate, "txtRate")
            Me.txtRate.EditingMode = True
            Me.txtRate.EndFindValue = Nothing
            Me.txtRate.FieldDescription = Nothing
            Me.txtRate.FieldName = Nothing
            Me.txtRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRate.FindEnabled = True
            Me.txtRate.ForeColor = System.Drawing.Color.Black
            Me.txtRate.LinkedLabel = Me.lblRate
            Me.txtRate.MaximumValue = Nothing
            Me.txtRate.MinimumValue = Nothing
            Me.txtRate.Name = "txtRate"
            Me.txtRate.OldValue = Nothing
            Me.txtRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRate.Translatable = False
            '
            'lblRate
            '
            resources.ApplyResources(Me.lblRate, "lblRate")
            Me.lblRate.DisplayOnly = True
            Me.lblRate.EditingMode = False
            Me.lblRate.Name = "lblRate"
            Me.lblRate.Translatable = True
            '
            'txtDefaultQuantity
            '
            Me.txtDefaultQuantity.BackColor = System.Drawing.Color.White
            Me.txtDefaultQuantity.BegFindValue = Nothing
            Me.txtDefaultQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDefaultQuantity.ComputedValue = False
            Me.txtDefaultQuantity.CustomFormat = Nothing
            Me.txtDefaultQuantity.DataBoundControl = True
            resources.ApplyResources(Me.txtDefaultQuantity, "txtDefaultQuantity")
            Me.txtDefaultQuantity.EditingMode = True
            Me.txtDefaultQuantity.EndFindValue = Nothing
            Me.txtDefaultQuantity.FieldDescription = Nothing
            Me.txtDefaultQuantity.FieldName = Nothing
            Me.txtDefaultQuantity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDefaultQuantity.FindEnabled = True
            Me.txtDefaultQuantity.ForeColor = System.Drawing.Color.Black
            Me.txtDefaultQuantity.LinkedLabel = Me.lblDefaultQuantity
            Me.txtDefaultQuantity.MaximumValue = Nothing
            Me.txtDefaultQuantity.MinimumValue = Nothing
            Me.txtDefaultQuantity.Name = "txtDefaultQuantity"
            Me.txtDefaultQuantity.OldValue = Nothing
            Me.txtDefaultQuantity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDefaultQuantity.Translatable = False
            '
            'lblDefaultQuantity
            '
            resources.ApplyResources(Me.lblDefaultQuantity, "lblDefaultQuantity")
            Me.lblDefaultQuantity.DisplayOnly = True
            Me.lblDefaultQuantity.EditingMode = False
            Me.lblDefaultQuantity.Name = "lblDefaultQuantity"
            Me.lblDefaultQuantity.Translatable = True
            '
            'lblBasePayment
            '
            resources.ApplyResources(Me.lblBasePayment, "lblBasePayment")
            Me.lblBasePayment.DisplayOnly = True
            Me.lblBasePayment.EditingMode = False
            Me.lblBasePayment.Name = "lblBasePayment"
            Me.lblBasePayment.Translatable = True
            '
            'cboBasePaymentIdNo
            '
            Me.cboBasePaymentIdNo.BackColor = System.Drawing.Color.White
            Me.cboBasePaymentIdNo.BegFindValue = Nothing
            Me.cboBasePaymentIdNo.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
            Me.cboBasePaymentIdNo.CurrentSearchTerm = ""
            Me.cboBasePaymentIdNo.DefaultValue = Nothing
            Me.cboBasePaymentIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboBasePaymentIdNo, "cboBasePaymentIdNo")
            Me.cboBasePaymentIdNo.EditingMode = True
            Me.cboBasePaymentIdNo.EndFindValue = Nothing
            Me.cboBasePaymentIdNo.FieldDescription = Nothing
            Me.cboBasePaymentIdNo.FieldName = Nothing
            Me.cboBasePaymentIdNo.FilterRule = Nothing
            Me.cboBasePaymentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboBasePaymentIdNo.FindEnabled = False
            Me.cboBasePaymentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBasePaymentIdNo.FormattingEnabled = True
            Me.cboBasePaymentIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBasePaymentIdNo.IgnoreCase = False
            Me.cboBasePaymentIdNo.LinkedLabel = Me.lblBasePayment
            Me.cboBasePaymentIdNo.Name = "cboBasePaymentIdNo"
            Me.cboBasePaymentIdNo.OldValue = 0
            Me.cboBasePaymentIdNo.OriginalDataSource = Nothing
            Me.cboBasePaymentIdNo.OriginalList = Nothing
            Me.cboBasePaymentIdNo.OverrideDropDownStyleList = False
            Me.cboBasePaymentIdNo.PreviousSearchTerm = Nothing
            Me.cboBasePaymentIdNo.PropertySelector = Nothing
            Me.cboBasePaymentIdNo.ReadOnlyCombo = False
            Me.cboBasePaymentIdNo.SuggestBoxHeight = 200
            Me.cboBasePaymentIdNo.SuggestListOrderRule = Nothing
            Me.cboBasePaymentIdNo.TextToSearch = Nothing
            Me.cboBasePaymentIdNo.Translatable = False
            Me.cboBasePaymentIdNo.ValueIsMandatory = False
            Me.cboBasePaymentIdNo.ValueIsNullable = False
            Me.cboBasePaymentIdNo.ValueIsNumeric = False
            Me.cboBasePaymentIdNo.ValueMember = "IdNo"
            '
            'lblIncludeInEos
            '
            resources.ApplyResources(Me.lblIncludeInEos, "lblIncludeInEos")
            Me.tlpCalculation.SetColumnSpan(Me.lblIncludeInEos, 2)
            Me.lblIncludeInEos.DisplayOnly = True
            Me.lblIncludeInEos.EditingMode = False
            Me.lblIncludeInEos.Name = "lblIncludeInEos"
            Me.lblIncludeInEos.Translatable = True
            '
            'chkIncludeInEOS
            '
            resources.ApplyResources(Me.chkIncludeInEOS, "chkIncludeInEOS")
            Me.chkIncludeInEOS.BackColor = System.Drawing.Color.White
            Me.chkIncludeInEOS.BegFindValue = Nothing
            Me.chkIncludeInEOS.DisplayOnly = False
            Me.chkIncludeInEOS.EditingMode = True
            Me.chkIncludeInEOS.EndFindValue = Nothing
            Me.chkIncludeInEOS.FieldDescription = Nothing
            Me.chkIncludeInEOS.FieldName = Nothing
            Me.chkIncludeInEOS.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkIncludeInEOS.FindEnabled = False
            Me.chkIncludeInEOS.FlatAppearance.BorderSize = 0
            Me.chkIncludeInEOS.ForeColor = System.Drawing.Color.Black
            Me.chkIncludeInEOS.IFindableControl_FindEnabled = False
            Me.chkIncludeInEOS.IgnoreCase = False
            Me.chkIncludeInEOS.LinkedLabel = Me.lblIncludeInEos
            Me.chkIncludeInEOS.Name = "chkIncludeInEOS"
            Me.chkIncludeInEOS.NoLabel = True
            Me.chkIncludeInEOS.OldValue = Nothing
            Me.chkIncludeInEOS.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkIncludeInEOS.Translatable = False
            Me.chkIncludeInEOS.UseVisualStyleBackColor = True
            '
            'txtMultiplier
            '
            Me.txtMultiplier.BackColor = System.Drawing.Color.White
            Me.txtMultiplier.BegFindValue = Nothing
            Me.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplier.ComputedValue = False
            Me.txtMultiplier.CustomFormat = Nothing
            Me.txtMultiplier.DataBoundControl = True
            resources.ApplyResources(Me.txtMultiplier, "txtMultiplier")
            Me.txtMultiplier.EditingMode = True
            Me.txtMultiplier.EndFindValue = Nothing
            Me.txtMultiplier.FieldDescription = Nothing
            Me.txtMultiplier.FieldName = Nothing
            Me.txtMultiplier.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMultiplier.FindEnabled = True
            Me.txtMultiplier.ForeColor = System.Drawing.Color.Black
            Me.txtMultiplier.LinkedLabel = Me.lblFactorValue
            Me.txtMultiplier.MaximumValue = Nothing
            Me.txtMultiplier.MinimumValue = Nothing
            Me.txtMultiplier.Name = "txtMultiplier"
            Me.txtMultiplier.OldValue = Nothing
            Me.txtMultiplier.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMultiplier.Translatable = False
            '
            'cboFactorType
            '
            Me.cboFactorType.BackColor = System.Drawing.Color.White
            Me.cboFactorType.BegFindValue = Nothing
            Me.cboFactorType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboFactorType, 2)
            Me.cboFactorType.CurrentSearchTerm = ""
            Me.cboFactorType.DefaultValue = Nothing
            Me.cboFactorType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboFactorType, "cboFactorType")
            Me.cboFactorType.EditingMode = True
            Me.cboFactorType.EndFindValue = Nothing
            Me.cboFactorType.FieldDescription = Nothing
            Me.cboFactorType.FieldName = Nothing
            Me.cboFactorType.FilterRule = Nothing
            Me.cboFactorType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboFactorType.FindEnabled = False
            Me.cboFactorType.ForeColor = System.Drawing.Color.Black
            Me.cboFactorType.FormattingEnabled = True
            Me.cboFactorType.HideWhenNotEditingOrAdding = False
            Me.cboFactorType.IgnoreCase = False
            Me.cboFactorType.LinkedLabel = Me.lblFactorType
            Me.cboFactorType.Name = "cboFactorType"
            Me.cboFactorType.OldValue = 0
            Me.cboFactorType.OriginalDataSource = Nothing
            Me.cboFactorType.OriginalList = Nothing
            Me.cboFactorType.OverrideDropDownStyleList = False
            Me.cboFactorType.PreviousSearchTerm = Nothing
            Me.cboFactorType.PropertySelector = Nothing
            Me.cboFactorType.ReadOnlyCombo = False
            Me.cboFactorType.SuggestBoxHeight = 200
            Me.cboFactorType.SuggestListOrderRule = Nothing
            Me.cboFactorType.TextToSearch = Nothing
            Me.cboFactorType.Translatable = False
            Me.cboFactorType.ValueIsMandatory = False
            Me.cboFactorType.ValueIsNullable = False
            Me.cboFactorType.ValueIsNumeric = False
            Me.cboFactorType.ValueMember = "Code"
            '
            'lblFactorType
            '
            resources.ApplyResources(Me.lblFactorType, "lblFactorType")
            Me.lblFactorType.DisplayOnly = True
            Me.lblFactorType.EditingMode = False
            Me.lblFactorType.Name = "lblFactorType"
            Me.lblFactorType.Translatable = True
            '
            'chkTaxable
            '
            resources.ApplyResources(Me.chkTaxable, "chkTaxable")
            Me.chkTaxable.BackColor = System.Drawing.Color.White
            Me.chkTaxable.BegFindValue = Nothing
            Me.chkTaxable.DisplayOnly = False
            Me.chkTaxable.EditingMode = True
            Me.chkTaxable.EndFindValue = Nothing
            Me.chkTaxable.FieldDescription = Nothing
            Me.chkTaxable.FieldName = Nothing
            Me.chkTaxable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkTaxable.FindEnabled = False
            Me.chkTaxable.FlatAppearance.BorderSize = 0
            Me.chkTaxable.ForeColor = System.Drawing.Color.Black
            Me.chkTaxable.IFindableControl_FindEnabled = False
            Me.chkTaxable.IgnoreCase = False
            Me.chkTaxable.LinkedLabel = Me.lblTaxable
            Me.chkTaxable.Name = "chkTaxable"
            Me.chkTaxable.NoLabel = True
            Me.chkTaxable.OldValue = Nothing
            Me.chkTaxable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkTaxable.Translatable = False
            Me.chkTaxable.UseVisualStyleBackColor = True
            '
            'lblTaxable
            '
            resources.ApplyResources(Me.lblTaxable, "lblTaxable")
            Me.tlpCalculation.SetColumnSpan(Me.lblTaxable, 2)
            Me.lblTaxable.DisplayOnly = True
            Me.lblTaxable.EditingMode = False
            Me.lblTaxable.Name = "lblTaxable"
            Me.lblTaxable.Translatable = True
            '
            'lblSlash
            '
            resources.ApplyResources(Me.lblSlash, "lblSlash")
            Me.lblSlash.DisplayOnly = True
            Me.lblSlash.EditingMode = False
            Me.lblSlash.Name = "lblSlash"
            Me.lblSlash.Translatable = True
            '
            'cboUnit
            '
            Me.cboUnit.BackColor = System.Drawing.Color.White
            Me.cboUnit.BegFindValue = Nothing
            Me.cboUnit.ChangingSearchValueOnly = False
            Me.cboUnit.CurrentSearchTerm = ""
            Me.cboUnit.DefaultValue = Nothing
            Me.cboUnit.DisplayMember = "Name"
            resources.ApplyResources(Me.cboUnit, "cboUnit")
            Me.cboUnit.EditingMode = True
            Me.cboUnit.EndFindValue = Nothing
            Me.cboUnit.FieldDescription = Nothing
            Me.cboUnit.FieldName = Nothing
            Me.cboUnit.FilterRule = Nothing
            Me.cboUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnit.FindEnabled = False
            Me.cboUnit.ForeColor = System.Drawing.Color.Black
            Me.cboUnit.FormattingEnabled = True
            Me.cboUnit.HideWhenNotEditingOrAdding = False
            Me.cboUnit.IgnoreCase = False
            Me.cboUnit.LinkedLabel = Me.lblUnit
            Me.cboUnit.Name = "cboUnit"
            Me.cboUnit.OldValue = 0
            Me.cboUnit.OriginalDataSource = Nothing
            Me.cboUnit.OriginalList = Nothing
            Me.cboUnit.OverrideDropDownStyleList = False
            Me.cboUnit.PreviousSearchTerm = Nothing
            Me.cboUnit.PropertySelector = Nothing
            Me.cboUnit.ReadOnlyCombo = False
            Me.cboUnit.SuggestBoxHeight = 200
            Me.cboUnit.SuggestListOrderRule = Nothing
            Me.cboUnit.TextToSearch = Nothing
            Me.cboUnit.Translatable = False
            Me.cboUnit.ValueIsMandatory = False
            Me.cboUnit.ValueIsNullable = False
            Me.cboUnit.ValueIsNumeric = False
            Me.cboUnit.ValueMember = "Code"
            '
            'lblUnit
            '
            resources.ApplyResources(Me.lblUnit, "lblUnit")
            Me.lblUnit.DisplayOnly = True
            Me.lblUnit.EditingMode = False
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Translatable = True
            '
            'cboPayElementType
            '
            Me.cboPayElementType.BackColor = System.Drawing.Color.White
            Me.cboPayElementType.BegFindValue = Nothing
            Me.cboPayElementType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboPayElementType, 3)
            Me.cboPayElementType.CurrentSearchTerm = ""
            Me.cboPayElementType.DefaultValue = Nothing
            Me.cboPayElementType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayElementType, "cboPayElementType")
            Me.cboPayElementType.EditingMode = True
            Me.cboPayElementType.EndFindValue = Nothing
            Me.cboPayElementType.FieldDescription = Nothing
            Me.cboPayElementType.FieldName = Nothing
            Me.cboPayElementType.FilterRule = Nothing
            Me.cboPayElementType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayElementType.FindEnabled = False
            Me.cboPayElementType.ForeColor = System.Drawing.Color.Black
            Me.cboPayElementType.FormattingEnabled = True
            Me.cboPayElementType.HideWhenNotEditingOrAdding = False
            Me.cboPayElementType.IgnoreCase = False
            Me.cboPayElementType.LinkedLabel = Me.lblPayElementType
            Me.cboPayElementType.Name = "cboPayElementType"
            Me.cboPayElementType.OldValue = 0
            Me.cboPayElementType.OriginalDataSource = Nothing
            Me.cboPayElementType.OriginalList = Nothing
            Me.cboPayElementType.OverrideDropDownStyleList = False
            Me.cboPayElementType.PreviousSearchTerm = Nothing
            Me.cboPayElementType.PropertySelector = Nothing
            Me.cboPayElementType.ReadOnlyCombo = False
            Me.cboPayElementType.SuggestBoxHeight = 200
            Me.cboPayElementType.SuggestListOrderRule = Nothing
            Me.cboPayElementType.TextToSearch = Nothing
            Me.cboPayElementType.Translatable = False
            Me.cboPayElementType.ValueIsMandatory = False
            Me.cboPayElementType.ValueIsNullable = False
            Me.cboPayElementType.ValueIsNumeric = False
            Me.cboPayElementType.ValueMember = "Code"
            '
            'lblSlash2
            '
            resources.ApplyResources(Me.lblSlash2, "lblSlash2")
            Me.lblSlash2.DisplayOnly = True
            Me.lblSlash2.EditingMode = False
            Me.lblSlash2.Name = "lblSlash2"
            Me.lblSlash2.Translatable = True
            '
            'tbpAccountPosting
            '
            Me.tbpAccountPosting.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
            resources.ApplyResources(Me.tbpAccountPosting, "tbpAccountPosting")
            Me.tbpAccountPosting.Controls.Add(Me.floPostingAccounts)
            Me.tbpAccountPosting.Name = "tbpAccountPosting"
            Me.tbpAccountPosting.UseVisualStyleBackColor = True
            '
            'floPostingAccounts
            '
            Me.floPostingAccounts.BackColor = System.Drawing.Color.Transparent
            Me.floPostingAccounts.Controls.Add(Me.tlpPostingAccounts)
            resources.ApplyResources(Me.floPostingAccounts, "floPostingAccounts")
            Me.floPostingAccounts.Name = "floPostingAccounts"
            '
            'tlpPostingAccounts
            '
            resources.ApplyResources(Me.tlpPostingAccounts, "tlpPostingAccounts")
            Me.tlpPostingAccounts.Controls.Add(Me.lblAccountIdNo, 0, 1)
            Me.tlpPostingAccounts.Controls.Add(Me.cboAccountIdNo, 1, 1)
            Me.tlpPostingAccounts.Controls.Add(Me.lblUsePayGroups, 0, 0)
            Me.tlpPostingAccounts.Controls.Add(Me.chkUsePayGroups, 2, 0)
            Me.tlpPostingAccounts.Controls.Add(Me.DataGridViewPayElementAccounts, 0, 2)
            Me.tlpPostingAccounts.Name = "tlpPostingAccounts"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblUsePayGroups
            '
            resources.ApplyResources(Me.lblUsePayGroups, "lblUsePayGroups")
            Me.tlpPostingAccounts.SetColumnSpan(Me.lblUsePayGroups, 2)
            Me.lblUsePayGroups.DisplayOnly = True
            Me.lblUsePayGroups.EditingMode = False
            Me.lblUsePayGroups.Name = "lblUsePayGroups"
            Me.lblUsePayGroups.Translatable = True
            '
            'chkUsePayGroups
            '
            Me.chkUsePayGroups.BackColor = System.Drawing.Color.White
            Me.chkUsePayGroups.BegFindValue = Nothing
            resources.ApplyResources(Me.chkUsePayGroups, "chkUsePayGroups")
            Me.chkUsePayGroups.DisplayOnly = False
            Me.chkUsePayGroups.EditingMode = True
            Me.chkUsePayGroups.EndFindValue = Nothing
            Me.chkUsePayGroups.FieldDescription = Nothing
            Me.chkUsePayGroups.FieldName = Nothing
            Me.chkUsePayGroups.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkUsePayGroups.FindEnabled = False
            Me.chkUsePayGroups.FlatAppearance.BorderSize = 0
            Me.chkUsePayGroups.ForeColor = System.Drawing.Color.Black
            Me.chkUsePayGroups.IFindableControl_FindEnabled = False
            Me.chkUsePayGroups.IgnoreCase = False
            Me.chkUsePayGroups.LinkedLabel = Me.lblUsePayGroups
            Me.chkUsePayGroups.Name = "chkUsePayGroups"
            Me.chkUsePayGroups.NoLabel = True
            Me.chkUsePayGroups.OldValue = Nothing
            Me.chkUsePayGroups.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkUsePayGroups.Translatable = False
            Me.chkUsePayGroups.UseVisualStyleBackColor = True
            '
            'DataGridViewPayElementAccounts
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayElementAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayElementAccounts.AutoGenerateColumns = False
            Me.DataGridViewPayElementAccounts.BegFindValue = Nothing
            Me.DataGridViewPayElementAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayElementAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.PayElementIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1, Me.PayGroupNameDataGridViewTextBoxColumn})
            Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPayElementAccounts, 3)
            Me.DataGridViewPayElementAccounts.DataSource = Me.bsPayElementAccounts
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayElementAccounts.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewPayElementAccounts.DgvFooter = Nothing
            Me.DataGridViewPayElementAccounts.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayElementAccounts, "DataGridViewPayElementAccounts")
            Me.DataGridViewPayElementAccounts.Ea = Nothing
            Me.DataGridViewPayElementAccounts.EditingMode = False
            Me.DataGridViewPayElementAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayElementAccounts.EndFindValue = Nothing
            Me.DataGridViewPayElementAccounts.FieldDescription = Nothing
            Me.DataGridViewPayElementAccounts.FieldName = Nothing
            Me.DataGridViewPayElementAccounts.FieldsDictionary = Nothing
            Me.DataGridViewPayElementAccounts.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPayElementAccounts.FindEnabled = False
            Me.DataGridViewPayElementAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayElementAccounts.FirstRowInsertionEnabled = True
            Me.DataGridViewPayElementAccounts.IgnoreCase = False
            Me.DataGridViewPayElementAccounts.Name = "DataGridViewPayElementAccounts"
            Me.DataGridViewPayElementAccounts.ReadOnly = True
            Me.DataGridViewPayElementAccounts.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPayElementAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayElementAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayElementAccounts.ShowFooter = False
            Me.DataGridViewPayElementAccounts.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPayElementAccounts.Translatable = True
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            '
            'dgvPayGroupIdNo
            '
            Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvPayGroupIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
            Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
            Me.dgvPayGroupIdNo.ReadOnly = True
            Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayGroupIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvPayGroupIdNo.Translatable = False
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvAccountIdNo.Translatable = False
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayElementIdNoDataGridViewTextBoxColumn
            '
            Me.PayElementIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayElementIdNo"
            resources.ApplyResources(Me.PayElementIdNoDataGridViewTextBoxColumn, "PayElementIdNoDataGridViewTextBoxColumn")
            Me.PayElementIdNoDataGridViewTextBoxColumn.Name = "PayElementIdNoDataGridViewTextBoxColumn"
            Me.PayElementIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn1
            '
            Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn1, "IdNoDataGridViewTextBoxColumn1")
            Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
            Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = True
            '
            'PayGroupNameDataGridViewTextBoxColumn
            '
            Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
            resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
            Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
            Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsPayElementAccounts
            '
            Me.bsPayElementAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayElementAccountModel)
            '
            'tbpSummaryDetail
            '
            Me.tbpSummaryDetail.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.tbpSummaryDetail.Controls.Add(Me.DataGridViewPayElementItems)
            resources.ApplyResources(Me.tbpSummaryDetail, "tbpSummaryDetail")
            Me.tbpSummaryDetail.Name = "tbpSummaryDetail"
            Me.tbpSummaryDetail.UseVisualStyleBackColor = True
            '
            'DataGridViewPayElementItems
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayElementItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewPayElementItems.AutoGenerateColumns = False
            Me.DataGridViewPayElementItems.BegFindValue = Nothing
            Me.DataGridViewPayElementItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayElementItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSummary, Me.dgvPayElementIdNo, Me.dgvFactorValue, Me.dgvFactorType, Me.ParentIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewPayElementItems.DataSource = Me.bsPayElementItems
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayElementItems.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewPayElementItems.DgvFooter = Nothing
            Me.DataGridViewPayElementItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayElementItems, "DataGridViewPayElementItems")
            Me.DataGridViewPayElementItems.Ea = Nothing
            Me.DataGridViewPayElementItems.EditingMode = False
            Me.DataGridViewPayElementItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayElementItems.EndFindValue = Nothing
            Me.DataGridViewPayElementItems.FieldDescription = Nothing
            Me.DataGridViewPayElementItems.FieldName = Nothing
            Me.DataGridViewPayElementItems.FieldsDictionary = Nothing
            Me.DataGridViewPayElementItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPayElementItems.FindEnabled = False
            Me.DataGridViewPayElementItems.FirstRowDeletionEnabled = True
            Me.DataGridViewPayElementItems.FirstRowInsertionEnabled = True
            Me.DataGridViewPayElementItems.IgnoreCase = False
            Me.DataGridViewPayElementItems.Name = "DataGridViewPayElementItems"
            Me.DataGridViewPayElementItems.ReadOnly = True
            Me.DataGridViewPayElementItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPayElementItems.SequenceColumn = "dgvSequenceSummary"
            Me.DataGridViewPayElementItems.SequenceFieldName = "Sequence"
            Me.DataGridViewPayElementItems.ShowFooter = False
            Me.DataGridViewPayElementItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPayElementItems.Translatable = True
            '
            'dgvSequenceSummary
            '
            Me.dgvSequenceSummary.BegFindValue = Nothing
            Me.dgvSequenceSummary.DataPropertyName = "Sequence"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceSummary.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvSequenceSummary.DisplayOnly = True
            Me.dgvSequenceSummary.EditingMode = False
            Me.dgvSequenceSummary.EndFindValue = Nothing
            Me.dgvSequenceSummary.FieldDescription = Nothing
            Me.dgvSequenceSummary.FieldName = Nothing
            Me.dgvSequenceSummary.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceSummary.FindEnabled = False
            resources.ApplyResources(Me.dgvSequenceSummary, "dgvSequenceSummary")
            Me.dgvSequenceSummary.IgnoreCase = False
            Me.dgvSequenceSummary.Name = "dgvSequenceSummary"
            Me.dgvSequenceSummary.ReadOnly = True
            Me.dgvSequenceSummary.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequenceSummary.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceSummary.Translatable = False
            '
            'dgvPayElementIdNo
            '
            Me.dgvPayElementIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvPayElementIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvPayElementIdNo.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvPayElementIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvPayElementIdNo, "dgvPayElementIdNo")
            Me.dgvPayElementIdNo.Name = "dgvPayElementIdNo"
            Me.dgvPayElementIdNo.ReadOnly = True
            Me.dgvPayElementIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayElementIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvPayElementIdNo.Translatable = False
            '
            'dgvFactorValue
            '
            Me.dgvFactorValue.BegFindValue = Nothing
            Me.dgvFactorValue.DataPropertyName = "FactorValue"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvFactorValue.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvFactorValue.EditingMode = False
            Me.dgvFactorValue.EndFindValue = Nothing
            Me.dgvFactorValue.FieldDescription = Nothing
            Me.dgvFactorValue.FieldName = Nothing
            Me.dgvFactorValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvFactorValue.FindEnabled = False
            resources.ApplyResources(Me.dgvFactorValue, "dgvFactorValue")
            Me.dgvFactorValue.IgnoreCase = False
            Me.dgvFactorValue.Name = "dgvFactorValue"
            Me.dgvFactorValue.ReadOnly = True
            Me.dgvFactorValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvFactorValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvFactorValue.Translatable = False
            '
            'dgvFactorType
            '
            Me.dgvFactorType.DataPropertyName = "FactorType"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvFactorType.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvFactorType.EditingMode = False
            resources.ApplyResources(Me.dgvFactorType, "dgvFactorType")
            Me.dgvFactorType.Name = "dgvFactorType"
            Me.dgvFactorType.ReadOnly = True
            Me.dgvFactorType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvFactorType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvFactorType.Translatable = False
            '
            'ParentIdNoDataGridViewTextBoxColumn
            '
            Me.ParentIdNoDataGridViewTextBoxColumn.DataPropertyName = "ParentIdNo"
            resources.ApplyResources(Me.ParentIdNoDataGridViewTextBoxColumn, "ParentIdNoDataGridViewTextBoxColumn")
            Me.ParentIdNoDataGridViewTextBoxColumn.Name = "ParentIdNoDataGridViewTextBoxColumn"
            Me.ParentIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsPayElementItems
            '
            Me.bsPayElementItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayElementItemModel)
            '
            'tbpNotes
            '
            Me.tbpNotes.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            resources.ApplyResources(Me.tbpNotes, "tbpNotes")
            Me.tbpNotes.Controls.Add(Me.floMain)
            Me.tbpNotes.Cursor = System.Windows.Forms.Cursors.Default
            Me.tbpNotes.Name = "tbpNotes"
            Me.tbpNotes.UseVisualStyleBackColor = True
            '
            'floMain
            '
            Me.floMain.BackColor = System.Drawing.Color.Transparent
            Me.floMain.Controls.Add(Me.tlpNotes)
            resources.ApplyResources(Me.floMain, "floMain")
            Me.floMain.Name = "floMain"
            '
            'tlpNotes
            '
            resources.ApplyResources(Me.tlpNotes, "tlpNotes")
            Me.tlpNotes.Controls.Add(Me.txtNotes, 0, 6)
            Me.tlpNotes.Controls.Add(Me.lblNotes, 0, 5)
            Me.tlpNotes.Name = "tlpNotes"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpNotes.SetColumnSpan(Me.txtNotes, 2)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'tabPageImages
            '
            Me.tabPageImages.ImageStream = CType(resources.GetObject("tabPageImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.tabPageImages.TransparentColor = System.Drawing.Color.Transparent
            Me.tabPageImages.Images.SetKeyName(0, "error.png")
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.floPayElement)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'PayElementEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "PayElementEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floPayElement.ResumeLayout(False)
            Me.tlpPayElement.ResumeLayout(False)
            Me.tlpPayElement.PerformLayout()
            Me.tbcPayElement.ResumeLayout(False)
            Me.tbpCalculation.ResumeLayout(False)
            Me.floCalculation.ResumeLayout(False)
            Me.tlpCalculation.ResumeLayout(False)
            Me.tlpCalculation.PerformLayout()
            Me.tbpAccountPosting.ResumeLayout(False)
            Me.floPostingAccounts.ResumeLayout(False)
            Me.tlpPostingAccounts.ResumeLayout(False)
            Me.tlpPostingAccounts.PerformLayout()
            CType(Me.DataGridViewPayElementAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayElementAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpSummaryDetail.ResumeLayout(False)
            CType(Me.DataGridViewPayElementItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayElementItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpNotes.ResumeLayout(False)
            Me.floMain.ResumeLayout(False)
            Me.tlpNotes.ResumeLayout(False)
            Me.tlpNotes.PerformLayout()
            Me.floDataDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents floPayElement As CFlowLayout
        Friend WithEvents tlpPayElement As TableLayoutPanel
        Friend WithEvents txtPayElementNameAra As CTextBoxArabic
        Friend WithEvents txtPayElementName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtPayElementCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents tbcPayElement As CTabControl
        Friend WithEvents tbpNotes As TabPage
        Friend WithEvents floMain As CFlowLayout
        Friend WithEvents tlpNotes As TableLayoutPanel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpCalculation As TabPage
        Friend WithEvents floCalculation As CFlowLayout
        Friend WithEvents tlpCalculation As TableLayoutPanel
        Friend WithEvents lblFactorValue As CLabel
        Friend WithEvents lblDefaultQuantity As CLabel
        Friend WithEvents lblRate As CLabel
        Friend WithEvents lblCalculationType As CLabel
        Friend WithEvents txtRate As CTextBox
        Friend WithEvents txtDefaultQuantity As CTextBox
        Friend WithEvents lblBasePayment As CLabel
        Friend WithEvents cboBasePaymentIdNo As CaComboBox
        Friend WithEvents lblIncludeInEos As CLabel
        Friend WithEvents chkIncludeInEOS As CCheckBox
        Friend WithEvents txtMultiplier As CTextBox
        Friend WithEvents cboFactorType As CaComboBox
        Friend WithEvents cboUnit As CaComboBox
        Friend WithEvents lblSlash As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents floPostingAccounts As CFlowLayout
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents chkTaxable As CCheckBox
        Friend WithEvents lblTaxable As CLabel
        Friend WithEvents tlpPostingAccounts As TableLayoutPanel
        Friend WithEvents lblUsePayGroups As CLabel
        Friend WithEvents chkUsePayGroups As CCheckBox
        Friend WithEvents lblPayElementType As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblUnit As CLabel
        Friend WithEvents tbpSummaryDetail As TabPage
        Friend WithEvents tabPageImages As ImageList
        Friend WithEvents lblFactorType As CLabel
        Friend WithEvents cboPayElementType As CaComboBox
        Friend WithEvents cboCalculationType As CaComboBox
        Friend WithEvents cboQuantityType As CaComboBox
        Friend WithEvents lblSlash2 As CLabel
        Friend WithEvents lblQuantityType As CLabel
        Friend WithEvents DataGridViewPayElementItems As CDataGridView
        Friend WithEvents bsPayElementItems As BindingSource
        Friend WithEvents DataGridViewPayElementAccounts As CDataGridView
        Friend WithEvents bsPayElementAccounts As BindingSource
        Friend WithEvents cboPayElementKind As CaComboBox
        Friend WithEvents lblPayElementKind As CLabel
        Friend WithEvents cboReportGroupIdNo As CaComboBox
        Friend WithEvents lblReportGroupIdNo As CLabel
        Friend WithEvents chkSummary As CCheckBox
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblSummary As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents dgvSequenceSummary As CDgvTextColumn
        Friend WithEvents dgvPayElementIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvFactorValue As CDgvTextColumn
        Friend WithEvents dgvFactorType As CDgvComboBoxColumn
        Friend WithEvents ParentIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvPayGroupIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayElementIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace