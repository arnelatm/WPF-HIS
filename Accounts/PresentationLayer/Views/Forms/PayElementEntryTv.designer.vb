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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayElementIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPayElementAccounts = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbpSummaryDetail = New System.Windows.Forms.TabPage()
        Me.DataGridViewPayElementItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceSummary = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPayElementIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvFactorValue = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvFactorType = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floPayElement.SuspendLayout
        Me.tlpPayElement.SuspendLayout
        Me.tbcPayElement.SuspendLayout
        Me.tbpCalculation.SuspendLayout
        Me.floCalculation.SuspendLayout
        Me.tlpCalculation.SuspendLayout
        Me.tbpAccountPosting.SuspendLayout
        Me.floPostingAccounts.SuspendLayout
        Me.tlpPostingAccounts.SuspendLayout
        CType(Me.DataGridViewPayElementAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayElementAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpSummaryDetail.SuspendLayout
        CType(Me.DataGridViewPayElementItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayElementItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpNotes.SuspendLayout
        Me.floMain.SuspendLayout
        Me.tlpNotes.SuspendLayout
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
        Me.cboReportGroupIdNo.ChangingSearchValueOnly = false
        Me.tlpPayElement.SetColumnSpan(Me.cboReportGroupIdNo, 2)
        Me.cboReportGroupIdNo.CurrentSearchTerm = ""
        Me.cboReportGroupIdNo.DefaultValue = Nothing
        Me.cboReportGroupIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboReportGroupIdNo, "cboReportGroupIdNo")
        Me.cboReportGroupIdNo.EditingMode = true
        Me.cboReportGroupIdNo.EndFindValue = Nothing
        Me.cboReportGroupIdNo.FieldDescription = Nothing
        Me.cboReportGroupIdNo.FieldName = Nothing
        Me.cboReportGroupIdNo.FilterRule = Nothing
        Me.cboReportGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboReportGroupIdNo.FindEnabled = false
        Me.cboReportGroupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboReportGroupIdNo.FormattingEnabled = true
        Me.cboReportGroupIdNo.HideWhenNotEditingOrAdding = false
        Me.cboReportGroupIdNo.IgnoreCase = false
        Me.cboReportGroupIdNo.LinkedLabel = Me.lblReportGroupIdNo
        Me.cboReportGroupIdNo.Name = "cboReportGroupIdNo"
        Me.cboReportGroupIdNo.OldValue = 0
        Me.cboReportGroupIdNo.OriginalDataSource = Nothing
        Me.cboReportGroupIdNo.OriginalList = Nothing
        Me.cboReportGroupIdNo.OverrideDropDownStyleList = false
        Me.cboReportGroupIdNo.PreviousSearchTerm = Nothing
        Me.cboReportGroupIdNo.PropertySelector = Nothing
        Me.cboReportGroupIdNo.ReadOnlyCombo = false
        Me.cboReportGroupIdNo.SuggestBoxHeight = 200
        Me.cboReportGroupIdNo.SuggestListOrderRule = Nothing
        Me.cboReportGroupIdNo.TextToSearch = Nothing
        Me.cboReportGroupIdNo.ValueIsMandatory = false
        Me.cboReportGroupIdNo.ValueIsNullable = false
        Me.cboReportGroupIdNo.ValueIsNumeric = false
        Me.cboReportGroupIdNo.ValueMember = "IdNo"
        '
        'lblReportGroupIdNo
        '
        Me.lblReportGroupIdNo.DisplayOnly = true
        Me.lblReportGroupIdNo.EditingMode = false
        resources.ApplyResources(Me.lblReportGroupIdNo, "lblReportGroupIdNo")
        Me.lblReportGroupIdNo.Name = "lblReportGroupIdNo"
        '
        'cboPayElementKind
        '
        Me.cboPayElementKind.BackColor = System.Drawing.Color.White
        Me.cboPayElementKind.BegFindValue = Nothing
        Me.cboPayElementKind.ChangingSearchValueOnly = false
        Me.cboPayElementKind.CurrentSearchTerm = ""
        Me.cboPayElementKind.DefaultValue = Nothing
        Me.cboPayElementKind.DisplayMember = "Name"
        resources.ApplyResources(Me.cboPayElementKind, "cboPayElementKind")
        Me.cboPayElementKind.EditingMode = true
        Me.cboPayElementKind.EndFindValue = Nothing
        Me.cboPayElementKind.FieldDescription = Nothing
        Me.cboPayElementKind.FieldName = Nothing
        Me.cboPayElementKind.FilterRule = Nothing
        Me.cboPayElementKind.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayElementKind.FindEnabled = false
        Me.cboPayElementKind.ForeColor = System.Drawing.Color.Black
        Me.cboPayElementKind.FormattingEnabled = true
        Me.cboPayElementKind.HideWhenNotEditingOrAdding = false
        Me.cboPayElementKind.IgnoreCase = false
        Me.cboPayElementKind.LinkedLabel = Me.lblPayElementType
        Me.cboPayElementKind.Name = "cboPayElementKind"
        Me.cboPayElementKind.OldValue = 0
        Me.cboPayElementKind.OriginalDataSource = Nothing
        Me.cboPayElementKind.OriginalList = Nothing
        Me.cboPayElementKind.OverrideDropDownStyleList = false
        Me.cboPayElementKind.PreviousSearchTerm = Nothing
        Me.cboPayElementKind.PropertySelector = Nothing
        Me.cboPayElementKind.ReadOnlyCombo = false
        Me.cboPayElementKind.SuggestBoxHeight = 200
        Me.cboPayElementKind.SuggestListOrderRule = Nothing
        Me.cboPayElementKind.TextToSearch = Nothing
        Me.cboPayElementKind.ValueIsMandatory = false
        Me.cboPayElementKind.ValueIsNullable = false
        Me.cboPayElementKind.ValueIsNumeric = false
        Me.cboPayElementKind.ValueMember = "Code"
        '
        'lblPayElementType
        '
        Me.lblPayElementType.DisplayOnly = true
        Me.lblPayElementType.EditingMode = false
        resources.ApplyResources(Me.lblPayElementType, "lblPayElementType")
        Me.lblPayElementType.Name = "lblPayElementType"
        '
        'lblPayElementKind
        '
        Me.lblPayElementKind.DisplayOnly = true
        Me.lblPayElementKind.EditingMode = false
        resources.ApplyResources(Me.lblPayElementKind, "lblPayElementKind")
        Me.lblPayElementKind.Name = "lblPayElementKind"
        '
        'txtPayElementNameAra
        '
        Me.txtPayElementNameAra.BackColor = System.Drawing.Color.White
        Me.txtPayElementNameAra.BegFindValue = Nothing
        Me.txtPayElementNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPayElement.SetColumnSpan(Me.txtPayElementNameAra, 4)
        Me.txtPayElementNameAra.ComputedValue = false
        Me.txtPayElementNameAra.CustomFormat = Nothing
        Me.txtPayElementNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtPayElementNameAra, "txtPayElementNameAra")
        Me.txtPayElementNameAra.EditingMode = false
        Me.txtPayElementNameAra.EndFindValue = Nothing
        Me.txtPayElementNameAra.EnglishControl = Me.txtPayElementName
        Me.txtPayElementNameAra.FieldDescription = Nothing
        Me.txtPayElementNameAra.FieldName = Nothing
        Me.txtPayElementNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayElementNameAra.FindEnabled = true
        Me.txtPayElementNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPayElementNameAra.LinkedLabel = Nothing
        Me.txtPayElementNameAra.MaximumValue = Nothing
        Me.txtPayElementNameAra.MinimumValue = Nothing
        Me.txtPayElementNameAra.Name = "txtPayElementNameAra"
        Me.txtPayElementNameAra.OldValue = Nothing
        Me.txtPayElementNameAra.ReadOnly = true
        Me.txtPayElementNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'txtPayElementName
        '
        Me.txtPayElementName.BackColor = System.Drawing.Color.White
        Me.txtPayElementName.BegFindValue = Nothing
        Me.txtPayElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPayElement.SetColumnSpan(Me.txtPayElementName, 4)
        Me.txtPayElementName.ComputedValue = false
        Me.txtPayElementName.CustomFormat = Nothing
        Me.txtPayElementName.DataBoundControl = true
        resources.ApplyResources(Me.txtPayElementName, "txtPayElementName")
        Me.txtPayElementName.EditingMode = false
        Me.txtPayElementName.EndFindValue = Nothing
        Me.txtPayElementName.FieldDescription = Nothing
        Me.txtPayElementName.FieldName = Nothing
        Me.txtPayElementName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayElementName.FindEnabled = true
        Me.txtPayElementName.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementName, CType(resources.GetObject("txtPayElementName.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtPayElementName.LinkedLabel = Nothing
        Me.txtPayElementName.MaximumValue = Nothing
        Me.txtPayElementName.MinimumValue = Nothing
        Me.txtPayElementName.Name = "txtPayElementName"
        Me.txtPayElementName.OldValue = Nothing
        Me.txtPayElementName.ReadOnly = true
        Me.txtPayElementName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayElementName.ValueIsMandatory = true
        '
        'lblName
        '
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'txtPayElementCode
        '
        Me.txtPayElementCode.BackColor = System.Drawing.Color.White
        Me.txtPayElementCode.BegFindValue = Nothing
        Me.txtPayElementCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPayElement.SetColumnSpan(Me.txtPayElementCode, 2)
        Me.txtPayElementCode.ComputedValue = false
        Me.txtPayElementCode.CustomFormat = Nothing
        Me.txtPayElementCode.DataBoundControl = true
        resources.ApplyResources(Me.txtPayElementCode, "txtPayElementCode")
        Me.txtPayElementCode.EditingMode = true
        Me.txtPayElementCode.EndFindValue = Nothing
        Me.txtPayElementCode.FieldDescription = Nothing
        Me.txtPayElementCode.FieldName = Nothing
        Me.txtPayElementCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayElementCode.FindEnabled = true
        Me.txtPayElementCode.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconPadding"),Integer))
        Me.txtPayElementCode.LinkedLabel = Nothing
        Me.txtPayElementCode.MaximumValue = Nothing
        Me.txtPayElementCode.MinimumValue = Nothing
        Me.txtPayElementCode.Name = "txtPayElementCode"
        Me.txtPayElementCode.OldValue = Nothing
        Me.txtPayElementCode.ReadOnly = true
        Me.txtPayElementCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayElementCode.ValueIsMandatory = true
        '
        'lblCode
        '
        Me.lblCode.DisplayOnly = true
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.EditingMode = false
        Me.lblCode.Name = "lblCode"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblNameAra
        '
        Me.lblNameAra.DisplayOnly = true
        Me.lblNameAra.EditingMode = false
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.lblNameAra.Name = "lblNameAra"
        '
        'chkSummary
        '
        Me.chkSummary.BackColor = System.Drawing.Color.White
        Me.chkSummary.BegFindValue = Nothing
        Me.chkSummary.DisplayOnly = false
        Me.chkSummary.EditingMode = true
        Me.chkSummary.EndFindValue = Nothing
        Me.chkSummary.FieldDescription = Nothing
        Me.chkSummary.FieldName = Nothing
        Me.chkSummary.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkSummary.FindEnabled = false
        resources.ApplyResources(Me.chkSummary, "chkSummary")
        Me.chkSummary.ForeColor = System.Drawing.Color.Black
        Me.chkSummary.IFindableControl_FindEnabled = false
        Me.chkSummary.IgnoreCase = false
        Me.chkSummary.LinkedLabel = Me.lblSummary
        Me.chkSummary.Name = "chkSummary"
        Me.chkSummary.NoLabel = true
        Me.chkSummary.OldValue = Nothing
        Me.chkSummary.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkSummary.UseVisualStyleBackColor = false
        '
        'lblSummary
        '
        resources.ApplyResources(Me.lblSummary, "lblSummary")
        Me.lblSummary.DisplayOnly = true
        Me.lblSummary.EditingMode = false
        Me.lblSummary.Name = "lblSummary"
        '
        'chkActive
        '
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = true
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = false
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = false
        Me.chkActive.IgnoreCase = false
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.UseVisualStyleBackColor = false
        '
        'lblActive
        '
        resources.ApplyResources(Me.lblActive, "lblActive")
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        Me.lblActive.Name = "lblActive"
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
        Me.tbpCalculation.UseVisualStyleBackColor = true
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
        Me.lblQuantityType.DisplayOnly = true
        Me.lblQuantityType.EditingMode = false
        Me.lblQuantityType.Name = "lblQuantityType"
        '
        'cboQuantityType
        '
        Me.cboQuantityType.BackColor = System.Drawing.Color.White
        Me.cboQuantityType.BegFindValue = Nothing
        Me.cboQuantityType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboQuantityType, 2)
        Me.cboQuantityType.CurrentSearchTerm = ""
        Me.cboQuantityType.DefaultValue = Nothing
        Me.cboQuantityType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboQuantityType, "cboQuantityType")
        Me.cboQuantityType.EditingMode = true
        Me.cboQuantityType.EndFindValue = Nothing
        Me.cboQuantityType.FieldDescription = Nothing
        Me.cboQuantityType.FieldName = Nothing
        Me.cboQuantityType.FilterRule = Nothing
        Me.cboQuantityType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboQuantityType.FindEnabled = false
        Me.cboQuantityType.ForeColor = System.Drawing.Color.Black
        Me.cboQuantityType.FormattingEnabled = true
        Me.cboQuantityType.HideWhenNotEditingOrAdding = false
        Me.cboQuantityType.IgnoreCase = false
        Me.cboQuantityType.LinkedLabel = Me.lblQuantityType
        Me.cboQuantityType.Name = "cboQuantityType"
        Me.cboQuantityType.OldValue = 0
        Me.cboQuantityType.OriginalDataSource = Nothing
        Me.cboQuantityType.OriginalList = Nothing
        Me.cboQuantityType.OverrideDropDownStyleList = false
        Me.cboQuantityType.PreviousSearchTerm = Nothing
        Me.cboQuantityType.PropertySelector = Nothing
        Me.cboQuantityType.ReadOnlyCombo = false
        Me.cboQuantityType.SuggestBoxHeight = 200
        Me.cboQuantityType.SuggestListOrderRule = Nothing
        Me.cboQuantityType.TextToSearch = Nothing
        Me.cboQuantityType.ValueIsMandatory = false
        Me.cboQuantityType.ValueIsNullable = false
        Me.cboQuantityType.ValueIsNumeric = false
        Me.cboQuantityType.ValueMember = "Code"
        '
        'cboCalculationType
        '
        Me.cboCalculationType.BackColor = System.Drawing.Color.White
        Me.cboCalculationType.BegFindValue = Nothing
        Me.cboCalculationType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboCalculationType, 3)
        Me.cboCalculationType.CurrentSearchTerm = ""
        Me.cboCalculationType.DefaultValue = Nothing
        Me.cboCalculationType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
        Me.cboCalculationType.EditingMode = true
        Me.cboCalculationType.EndFindValue = Nothing
        Me.cboCalculationType.FieldDescription = Nothing
        Me.cboCalculationType.FieldName = Nothing
        Me.cboCalculationType.FilterRule = Nothing
        Me.cboCalculationType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboCalculationType.FindEnabled = false
        Me.cboCalculationType.ForeColor = System.Drawing.Color.Black
        Me.cboCalculationType.FormattingEnabled = true
        Me.cboCalculationType.HideWhenNotEditingOrAdding = false
        Me.cboCalculationType.IgnoreCase = false
        Me.cboCalculationType.LinkedLabel = Me.lblPayElementType
        Me.cboCalculationType.Name = "cboCalculationType"
        Me.cboCalculationType.OldValue = 0
        Me.cboCalculationType.OriginalDataSource = Nothing
        Me.cboCalculationType.OriginalList = Nothing
        Me.cboCalculationType.OverrideDropDownStyleList = false
        Me.cboCalculationType.PreviousSearchTerm = Nothing
        Me.cboCalculationType.PropertySelector = Nothing
        Me.cboCalculationType.ReadOnlyCombo = false
        Me.cboCalculationType.SuggestBoxHeight = 200
        Me.cboCalculationType.SuggestListOrderRule = Nothing
        Me.cboCalculationType.TextToSearch = Nothing
        Me.cboCalculationType.ValueIsMandatory = false
        Me.cboCalculationType.ValueIsNullable = false
        Me.cboCalculationType.ValueIsNumeric = false
        Me.cboCalculationType.ValueMember = "Code"
        '
        'lblFactorValue
        '
        resources.ApplyResources(Me.lblFactorValue, "lblFactorValue")
        Me.lblFactorValue.DisplayOnly = true
        Me.lblFactorValue.EditingMode = false
        Me.lblFactorValue.Name = "lblFactorValue"
        '
        'lblCalculationType
        '
        resources.ApplyResources(Me.lblCalculationType, "lblCalculationType")
        Me.lblCalculationType.DisplayOnly = true
        Me.lblCalculationType.EditingMode = false
        Me.lblCalculationType.Name = "lblCalculationType"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.White
        Me.txtRate.BegFindValue = Nothing
        Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRate.ComputedValue = false
        Me.txtRate.CustomFormat = Nothing
        Me.txtRate.DataBoundControl = true
        resources.ApplyResources(Me.txtRate, "txtRate")
        Me.txtRate.EditingMode = true
        Me.txtRate.EndFindValue = Nothing
        Me.txtRate.FieldDescription = Nothing
        Me.txtRate.FieldName = Nothing
        Me.txtRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtRate.FindEnabled = true
        Me.txtRate.ForeColor = System.Drawing.Color.Black
        Me.txtRate.LinkedLabel = Me.lblRate
        Me.txtRate.MaximumValue = Nothing
        Me.txtRate.MinimumValue = Nothing
        Me.txtRate.Name = "txtRate"
        Me.txtRate.OldValue = Nothing
        Me.txtRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'lblRate
        '
        resources.ApplyResources(Me.lblRate, "lblRate")
        Me.lblRate.DisplayOnly = true
        Me.lblRate.EditingMode = false
        Me.lblRate.Name = "lblRate"
        '
        'txtDefaultQuantity
        '
        Me.txtDefaultQuantity.BackColor = System.Drawing.Color.White
        Me.txtDefaultQuantity.BegFindValue = Nothing
        Me.txtDefaultQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDefaultQuantity.ComputedValue = false
        Me.txtDefaultQuantity.CustomFormat = Nothing
        Me.txtDefaultQuantity.DataBoundControl = true
        resources.ApplyResources(Me.txtDefaultQuantity, "txtDefaultQuantity")
        Me.txtDefaultQuantity.EditingMode = true
        Me.txtDefaultQuantity.EndFindValue = Nothing
        Me.txtDefaultQuantity.FieldDescription = Nothing
        Me.txtDefaultQuantity.FieldName = Nothing
        Me.txtDefaultQuantity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDefaultQuantity.FindEnabled = true
        Me.txtDefaultQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtDefaultQuantity.LinkedLabel = Me.lblDefaultQuantity
        Me.txtDefaultQuantity.MaximumValue = Nothing
        Me.txtDefaultQuantity.MinimumValue = Nothing
        Me.txtDefaultQuantity.Name = "txtDefaultQuantity"
        Me.txtDefaultQuantity.OldValue = Nothing
        Me.txtDefaultQuantity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'lblDefaultQuantity
        '
        resources.ApplyResources(Me.lblDefaultQuantity, "lblDefaultQuantity")
        Me.lblDefaultQuantity.DisplayOnly = true
        Me.lblDefaultQuantity.EditingMode = false
        Me.lblDefaultQuantity.Name = "lblDefaultQuantity"
        '
        'lblBasePayment
        '
        resources.ApplyResources(Me.lblBasePayment, "lblBasePayment")
        Me.lblBasePayment.DisplayOnly = true
        Me.lblBasePayment.EditingMode = false
        Me.lblBasePayment.Name = "lblBasePayment"
        '
        'cboBasePaymentIdNo
        '
        Me.cboBasePaymentIdNo.BackColor = System.Drawing.Color.White
        Me.cboBasePaymentIdNo.BegFindValue = Nothing
        Me.cboBasePaymentIdNo.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
        Me.cboBasePaymentIdNo.CurrentSearchTerm = ""
        Me.cboBasePaymentIdNo.DefaultValue = Nothing
        Me.cboBasePaymentIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboBasePaymentIdNo, "cboBasePaymentIdNo")
        Me.cboBasePaymentIdNo.EditingMode = true
        Me.cboBasePaymentIdNo.EndFindValue = Nothing
        Me.cboBasePaymentIdNo.FieldDescription = Nothing
        Me.cboBasePaymentIdNo.FieldName = Nothing
        Me.cboBasePaymentIdNo.FilterRule = Nothing
        Me.cboBasePaymentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboBasePaymentIdNo.FindEnabled = false
        Me.cboBasePaymentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBasePaymentIdNo.FormattingEnabled = true
        Me.cboBasePaymentIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBasePaymentIdNo.IgnoreCase = false
        Me.cboBasePaymentIdNo.LinkedLabel = Me.lblBasePayment
        Me.cboBasePaymentIdNo.Name = "cboBasePaymentIdNo"
        Me.cboBasePaymentIdNo.OldValue = 0
        Me.cboBasePaymentIdNo.OriginalDataSource = Nothing
        Me.cboBasePaymentIdNo.OriginalList = Nothing
        Me.cboBasePaymentIdNo.OverrideDropDownStyleList = false
        Me.cboBasePaymentIdNo.PreviousSearchTerm = Nothing
        Me.cboBasePaymentIdNo.PropertySelector = Nothing
        Me.cboBasePaymentIdNo.ReadOnlyCombo = false
        Me.cboBasePaymentIdNo.SuggestBoxHeight = 200
        Me.cboBasePaymentIdNo.SuggestListOrderRule = Nothing
        Me.cboBasePaymentIdNo.TextToSearch = Nothing
        Me.cboBasePaymentIdNo.ValueIsMandatory = false
        Me.cboBasePaymentIdNo.ValueIsNullable = false
        Me.cboBasePaymentIdNo.ValueIsNumeric = false
        Me.cboBasePaymentIdNo.ValueMember = "IdNo"
        '
        'lblIncludeInEos
        '
        resources.ApplyResources(Me.lblIncludeInEos, "lblIncludeInEos")
        Me.tlpCalculation.SetColumnSpan(Me.lblIncludeInEos, 2)
        Me.lblIncludeInEos.DisplayOnly = true
        Me.lblIncludeInEos.EditingMode = false
        Me.lblIncludeInEos.Name = "lblIncludeInEos"
        '
        'chkIncludeInEOS
        '
        resources.ApplyResources(Me.chkIncludeInEOS, "chkIncludeInEOS")
        Me.chkIncludeInEOS.BackColor = System.Drawing.Color.White
        Me.chkIncludeInEOS.BegFindValue = Nothing
        Me.chkIncludeInEOS.DisplayOnly = false
        Me.chkIncludeInEOS.EditingMode = true
        Me.chkIncludeInEOS.EndFindValue = Nothing
        Me.chkIncludeInEOS.FieldDescription = Nothing
        Me.chkIncludeInEOS.FieldName = Nothing
        Me.chkIncludeInEOS.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkIncludeInEOS.FindEnabled = false
        Me.chkIncludeInEOS.FlatAppearance.BorderSize = 0
        Me.chkIncludeInEOS.ForeColor = System.Drawing.Color.Black
        Me.chkIncludeInEOS.IFindableControl_FindEnabled = false
        Me.chkIncludeInEOS.IgnoreCase = false
        Me.chkIncludeInEOS.LinkedLabel = Me.lblIncludeInEos
        Me.chkIncludeInEOS.Name = "chkIncludeInEOS"
        Me.chkIncludeInEOS.NoLabel = true
        Me.chkIncludeInEOS.OldValue = Nothing
        Me.chkIncludeInEOS.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkIncludeInEOS.UseVisualStyleBackColor = true
        '
        'txtMultiplier
        '
        Me.txtMultiplier.BackColor = System.Drawing.Color.White
        Me.txtMultiplier.BegFindValue = Nothing
        Me.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier.ComputedValue = false
        Me.txtMultiplier.CustomFormat = Nothing
        Me.txtMultiplier.DataBoundControl = true
        resources.ApplyResources(Me.txtMultiplier, "txtMultiplier")
        Me.txtMultiplier.EditingMode = true
        Me.txtMultiplier.EndFindValue = Nothing
        Me.txtMultiplier.FieldDescription = Nothing
        Me.txtMultiplier.FieldName = Nothing
        Me.txtMultiplier.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMultiplier.FindEnabled = true
        Me.txtMultiplier.ForeColor = System.Drawing.Color.Black
        Me.txtMultiplier.LinkedLabel = Me.lblFactorValue
        Me.txtMultiplier.MaximumValue = Nothing
        Me.txtMultiplier.MinimumValue = Nothing
        Me.txtMultiplier.Name = "txtMultiplier"
        Me.txtMultiplier.OldValue = Nothing
        Me.txtMultiplier.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'cboFactorType
        '
        Me.cboFactorType.BackColor = System.Drawing.Color.White
        Me.cboFactorType.BegFindValue = Nothing
        Me.cboFactorType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboFactorType, 2)
        Me.cboFactorType.CurrentSearchTerm = ""
        Me.cboFactorType.DefaultValue = Nothing
        Me.cboFactorType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboFactorType, "cboFactorType")
        Me.cboFactorType.EditingMode = true
        Me.cboFactorType.EndFindValue = Nothing
        Me.cboFactorType.FieldDescription = Nothing
        Me.cboFactorType.FieldName = Nothing
        Me.cboFactorType.FilterRule = Nothing
        Me.cboFactorType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboFactorType.FindEnabled = false
        Me.cboFactorType.ForeColor = System.Drawing.Color.Black
        Me.cboFactorType.FormattingEnabled = true
        Me.cboFactorType.HideWhenNotEditingOrAdding = false
        Me.cboFactorType.IgnoreCase = false
        Me.cboFactorType.LinkedLabel = Me.lblFactorType
        Me.cboFactorType.Name = "cboFactorType"
        Me.cboFactorType.OldValue = 0
        Me.cboFactorType.OriginalDataSource = Nothing
        Me.cboFactorType.OriginalList = Nothing
        Me.cboFactorType.OverrideDropDownStyleList = false
        Me.cboFactorType.PreviousSearchTerm = Nothing
        Me.cboFactorType.PropertySelector = Nothing
        Me.cboFactorType.ReadOnlyCombo = false
        Me.cboFactorType.SuggestBoxHeight = 200
        Me.cboFactorType.SuggestListOrderRule = Nothing
        Me.cboFactorType.TextToSearch = Nothing
        Me.cboFactorType.ValueIsMandatory = false
        Me.cboFactorType.ValueIsNullable = false
        Me.cboFactorType.ValueIsNumeric = false
        Me.cboFactorType.ValueMember = "Code"
        '
        'lblFactorType
        '
        resources.ApplyResources(Me.lblFactorType, "lblFactorType")
        Me.lblFactorType.DisplayOnly = true
        Me.lblFactorType.EditingMode = false
        Me.lblFactorType.Name = "lblFactorType"
        '
        'chkTaxable
        '
        resources.ApplyResources(Me.chkTaxable, "chkTaxable")
        Me.chkTaxable.BackColor = System.Drawing.Color.White
        Me.chkTaxable.BegFindValue = Nothing
        Me.chkTaxable.DisplayOnly = false
        Me.chkTaxable.EditingMode = true
        Me.chkTaxable.EndFindValue = Nothing
        Me.chkTaxable.FieldDescription = Nothing
        Me.chkTaxable.FieldName = Nothing
        Me.chkTaxable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkTaxable.FindEnabled = false
        Me.chkTaxable.FlatAppearance.BorderSize = 0
        Me.chkTaxable.ForeColor = System.Drawing.Color.Black
        Me.chkTaxable.IFindableControl_FindEnabled = false
        Me.chkTaxable.IgnoreCase = false
        Me.chkTaxable.LinkedLabel = Me.lblTaxable
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.NoLabel = true
        Me.chkTaxable.OldValue = Nothing
        Me.chkTaxable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkTaxable.UseVisualStyleBackColor = true
        '
        'lblTaxable
        '
        resources.ApplyResources(Me.lblTaxable, "lblTaxable")
        Me.tlpCalculation.SetColumnSpan(Me.lblTaxable, 2)
        Me.lblTaxable.DisplayOnly = true
        Me.lblTaxable.EditingMode = false
        Me.lblTaxable.Name = "lblTaxable"
        '
        'lblSlash
        '
        resources.ApplyResources(Me.lblSlash, "lblSlash")
        Me.lblSlash.DisplayOnly = true
        Me.lblSlash.EditingMode = false
        Me.lblSlash.Name = "lblSlash"
        '
        'cboUnit
        '
        Me.cboUnit.BackColor = System.Drawing.Color.White
        Me.cboUnit.BegFindValue = Nothing
        Me.cboUnit.ChangingSearchValueOnly = false
        Me.cboUnit.CurrentSearchTerm = ""
        Me.cboUnit.DefaultValue = Nothing
        Me.cboUnit.DisplayMember = "Name"
        resources.ApplyResources(Me.cboUnit, "cboUnit")
        Me.cboUnit.EditingMode = true
        Me.cboUnit.EndFindValue = Nothing
        Me.cboUnit.FieldDescription = Nothing
        Me.cboUnit.FieldName = Nothing
        Me.cboUnit.FilterRule = Nothing
        Me.cboUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboUnit.FindEnabled = false
        Me.cboUnit.ForeColor = System.Drawing.Color.Black
        Me.cboUnit.FormattingEnabled = true
        Me.cboUnit.HideWhenNotEditingOrAdding = false
        Me.cboUnit.IgnoreCase = false
        Me.cboUnit.LinkedLabel = Me.lblUnit
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.OldValue = 0
        Me.cboUnit.OriginalDataSource = Nothing
        Me.cboUnit.OriginalList = Nothing
        Me.cboUnit.OverrideDropDownStyleList = false
        Me.cboUnit.PreviousSearchTerm = Nothing
        Me.cboUnit.PropertySelector = Nothing
        Me.cboUnit.ReadOnlyCombo = false
        Me.cboUnit.SuggestBoxHeight = 200
        Me.cboUnit.SuggestListOrderRule = Nothing
        Me.cboUnit.TextToSearch = Nothing
        Me.cboUnit.ValueIsMandatory = false
        Me.cboUnit.ValueIsNullable = false
        Me.cboUnit.ValueIsNumeric = false
        Me.cboUnit.ValueMember = "Code"
        '
        'lblUnit
        '
        resources.ApplyResources(Me.lblUnit, "lblUnit")
        Me.lblUnit.DisplayOnly = true
        Me.lblUnit.EditingMode = false
        Me.lblUnit.Name = "lblUnit"
        '
        'cboPayElementType
        '
        Me.cboPayElementType.BackColor = System.Drawing.Color.White
        Me.cboPayElementType.BegFindValue = Nothing
        Me.cboPayElementType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboPayElementType, 3)
        Me.cboPayElementType.CurrentSearchTerm = ""
        Me.cboPayElementType.DefaultValue = Nothing
        Me.cboPayElementType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboPayElementType, "cboPayElementType")
        Me.cboPayElementType.EditingMode = true
        Me.cboPayElementType.EndFindValue = Nothing
        Me.cboPayElementType.FieldDescription = Nothing
        Me.cboPayElementType.FieldName = Nothing
        Me.cboPayElementType.FilterRule = Nothing
        Me.cboPayElementType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayElementType.FindEnabled = false
        Me.cboPayElementType.ForeColor = System.Drawing.Color.Black
        Me.cboPayElementType.FormattingEnabled = true
        Me.cboPayElementType.HideWhenNotEditingOrAdding = false
        Me.cboPayElementType.IgnoreCase = false
        Me.cboPayElementType.LinkedLabel = Me.lblPayElementType
        Me.cboPayElementType.Name = "cboPayElementType"
        Me.cboPayElementType.OldValue = 0
        Me.cboPayElementType.OriginalDataSource = Nothing
        Me.cboPayElementType.OriginalList = Nothing
        Me.cboPayElementType.OverrideDropDownStyleList = false
        Me.cboPayElementType.PreviousSearchTerm = Nothing
        Me.cboPayElementType.PropertySelector = Nothing
        Me.cboPayElementType.ReadOnlyCombo = false
        Me.cboPayElementType.SuggestBoxHeight = 200
        Me.cboPayElementType.SuggestListOrderRule = Nothing
        Me.cboPayElementType.TextToSearch = Nothing
        Me.cboPayElementType.ValueIsMandatory = false
        Me.cboPayElementType.ValueIsNullable = false
        Me.cboPayElementType.ValueIsNumeric = false
        Me.cboPayElementType.ValueMember = "Code"
        '
        'lblSlash2
        '
        resources.ApplyResources(Me.lblSlash2, "lblSlash2")
        Me.lblSlash2.DisplayOnly = true
        Me.lblSlash2.EditingMode = false
        Me.lblSlash2.Name = "lblSlash2"
        '
        'tbpAccountPosting
        '
        Me.tbpAccountPosting.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
        resources.ApplyResources(Me.tbpAccountPosting, "tbpAccountPosting")
        Me.tbpAccountPosting.Controls.Add(Me.floPostingAccounts)
        Me.tbpAccountPosting.Name = "tbpAccountPosting"
        Me.tbpAccountPosting.UseVisualStyleBackColor = true
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
        Me.lblAccountIdNo.DisplayOnly = true
        resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = Nothing
        Me.cboAccountIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.EndFindValue = Nothing
        Me.cboAccountIdNo.FieldDescription = Nothing
        Me.cboAccountIdNo.FieldName = Nothing
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboAccountIdNo.FindEnabled = false
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.FormattingEnabled = true
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblUsePayGroups
        '
        resources.ApplyResources(Me.lblUsePayGroups, "lblUsePayGroups")
        Me.tlpPostingAccounts.SetColumnSpan(Me.lblUsePayGroups, 2)
        Me.lblUsePayGroups.DisplayOnly = true
        Me.lblUsePayGroups.EditingMode = false
        Me.lblUsePayGroups.Name = "lblUsePayGroups"
        '
        'chkUsePayGroups
        '
        Me.chkUsePayGroups.BackColor = System.Drawing.Color.White
        Me.chkUsePayGroups.BegFindValue = Nothing
        resources.ApplyResources(Me.chkUsePayGroups, "chkUsePayGroups")
        Me.chkUsePayGroups.DisplayOnly = false
        Me.chkUsePayGroups.EditingMode = true
        Me.chkUsePayGroups.EndFindValue = Nothing
        Me.chkUsePayGroups.FieldDescription = Nothing
        Me.chkUsePayGroups.FieldName = Nothing
        Me.chkUsePayGroups.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkUsePayGroups.FindEnabled = false
        Me.chkUsePayGroups.FlatAppearance.BorderSize = 0
        Me.chkUsePayGroups.ForeColor = System.Drawing.Color.Black
        Me.chkUsePayGroups.IFindableControl_FindEnabled = false
        Me.chkUsePayGroups.IgnoreCase = false
        Me.chkUsePayGroups.LinkedLabel = Me.lblUsePayGroups
        Me.chkUsePayGroups.Name = "chkUsePayGroups"
        Me.chkUsePayGroups.NoLabel = true
        Me.chkUsePayGroups.OldValue = Nothing
        Me.chkUsePayGroups.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkUsePayGroups.UseVisualStyleBackColor = true
        '
        'DataGridViewPayElementAccounts
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayElementAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewPayElementAccounts.AutoGenerateColumns = false
        Me.DataGridViewPayElementAccounts.BegFindValue = Nothing
        Me.DataGridViewPayElementAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayElementAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.PayElementIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1, Me.PayGroupNameDataGridViewTextBoxColumn})
        Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPayElementAccounts, 3)
        Me.DataGridViewPayElementAccounts.DataSource = Me.bsPayElementAccounts
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayElementAccounts.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewPayElementAccounts.DgvFooter = Nothing
        Me.DataGridViewPayElementAccounts.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewPayElementAccounts, "DataGridViewPayElementAccounts")
        Me.DataGridViewPayElementAccounts.Ea = Nothing
        Me.DataGridViewPayElementAccounts.EditingMode = false
        Me.DataGridViewPayElementAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayElementAccounts.EndFindValue = Nothing
        Me.DataGridViewPayElementAccounts.FieldDescription = Nothing
        Me.DataGridViewPayElementAccounts.FieldName = Nothing
        Me.DataGridViewPayElementAccounts.FieldsDictionary = Nothing
        Me.DataGridViewPayElementAccounts.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPayElementAccounts.FindEnabled = false
        Me.DataGridViewPayElementAccounts.FirstRowDeletionEnabled = true
        Me.DataGridViewPayElementAccounts.FirstRowInsertionEnabled = true
        Me.DataGridViewPayElementAccounts.IgnoreCase = false
        Me.DataGridViewPayElementAccounts.Name = "DataGridViewPayElementAccounts"
        Me.DataGridViewPayElementAccounts.ReadOnly = true
        Me.DataGridViewPayElementAccounts.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPayElementAccounts.SequenceColumn = "dgvSequence"
        Me.DataGridViewPayElementAccounts.SequenceFieldName = "Sequence"
        Me.DataGridViewPayElementAccounts.ShowFooter = false
        Me.DataGridViewPayElementAccounts.ShowInsertColumnWhenEditing = true
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvPayGroupIdNo
        '
        Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPayGroupIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
        Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
        Me.dgvPayGroupIdNo.ReadOnly = true
        Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayGroupIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'PayElementIdNoDataGridViewTextBoxColumn
        '
        Me.PayElementIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayElementIdNo"
        resources.ApplyResources(Me.PayElementIdNoDataGridViewTextBoxColumn, "PayElementIdNoDataGridViewTextBoxColumn")
        Me.PayElementIdNoDataGridViewTextBoxColumn.Name = "PayElementIdNoDataGridViewTextBoxColumn"
        Me.PayElementIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'IdNoDataGridViewTextBoxColumn1
        '
        Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn1, "IdNoDataGridViewTextBoxColumn1")
        Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
        Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = true
        '
        'PayGroupNameDataGridViewTextBoxColumn
        '
        Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
        resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
        Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
        Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = true
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
        Me.tbpSummaryDetail.UseVisualStyleBackColor = true
        '
        'DataGridViewPayElementItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayElementItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPayElementItems.AutoGenerateColumns = false
        Me.DataGridViewPayElementItems.BegFindValue = Nothing
        Me.DataGridViewPayElementItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayElementItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSummary, Me.dgvPayElementIdNo, Me.dgvFactorValue, Me.dgvFactorType, Me.ParentIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
        Me.DataGridViewPayElementItems.DataSource = Me.bsPayElementItems
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayElementItems.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewPayElementItems.DgvFooter = Nothing
        Me.DataGridViewPayElementItems.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewPayElementItems, "DataGridViewPayElementItems")
        Me.DataGridViewPayElementItems.Ea = Nothing
        Me.DataGridViewPayElementItems.EditingMode = false
        Me.DataGridViewPayElementItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayElementItems.EndFindValue = Nothing
        Me.DataGridViewPayElementItems.FieldDescription = Nothing
        Me.DataGridViewPayElementItems.FieldName = Nothing
        Me.DataGridViewPayElementItems.FieldsDictionary = Nothing
        Me.DataGridViewPayElementItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPayElementItems.FindEnabled = false
        Me.DataGridViewPayElementItems.FirstRowDeletionEnabled = true
        Me.DataGridViewPayElementItems.FirstRowInsertionEnabled = true
        Me.DataGridViewPayElementItems.IgnoreCase = false
        Me.DataGridViewPayElementItems.Name = "DataGridViewPayElementItems"
        Me.DataGridViewPayElementItems.ReadOnly = true
        Me.DataGridViewPayElementItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPayElementItems.SequenceColumn = "dgvSequenceSummary"
        Me.DataGridViewPayElementItems.SequenceFieldName = "Sequence"
        Me.DataGridViewPayElementItems.ShowFooter = false
        Me.DataGridViewPayElementItems.ShowInsertColumnWhenEditing = true
        '
        'dgvSequenceSummary
        '
        Me.dgvSequenceSummary.BegFindValue = Nothing
        Me.dgvSequenceSummary.DataPropertyName = "Sequence"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceSummary.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSequenceSummary.EditingMode = false
        Me.dgvSequenceSummary.EndFindValue = Nothing
        Me.dgvSequenceSummary.FieldDescription = Nothing
        Me.dgvSequenceSummary.FieldName = Nothing
        Me.dgvSequenceSummary.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequenceSummary.FindEnabled = false
        resources.ApplyResources(Me.dgvSequenceSummary, "dgvSequenceSummary")
        Me.dgvSequenceSummary.IgnoreCase = false
        Me.dgvSequenceSummary.Name = "dgvSequenceSummary"
        Me.dgvSequenceSummary.ReadOnly = true
        Me.dgvSequenceSummary.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequenceSummary.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvPayElementIdNo
        '
        Me.dgvPayElementIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvPayElementIdNo.DataPropertyName = "PayElementIdNo"
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        Me.dgvPayElementIdNo.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvPayElementIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvPayElementIdNo, "dgvPayElementIdNo")
        Me.dgvPayElementIdNo.Name = "dgvPayElementIdNo"
        Me.dgvPayElementIdNo.ReadOnly = true
        Me.dgvPayElementIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayElementIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvFactorValue
        '
        Me.dgvFactorValue.BegFindValue = Nothing
        Me.dgvFactorValue.DataPropertyName = "FactorValue"
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        Me.dgvFactorValue.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvFactorValue.EditingMode = false
        Me.dgvFactorValue.EndFindValue = Nothing
        Me.dgvFactorValue.FieldDescription = Nothing
        Me.dgvFactorValue.FieldName = Nothing
        Me.dgvFactorValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvFactorValue.FindEnabled = false
        resources.ApplyResources(Me.dgvFactorValue, "dgvFactorValue")
        Me.dgvFactorValue.IgnoreCase = false
        Me.dgvFactorValue.Name = "dgvFactorValue"
        Me.dgvFactorValue.ReadOnly = true
        Me.dgvFactorValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactorValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvFactorType
        '
        Me.dgvFactorType.DataPropertyName = "FactorType"
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        Me.dgvFactorType.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvFactorType.EditingMode = false
        resources.ApplyResources(Me.dgvFactorType, "dgvFactorType")
        Me.dgvFactorType.Name = "dgvFactorType"
        Me.dgvFactorType.ReadOnly = true
        Me.dgvFactorType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactorType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ParentIdNoDataGridViewTextBoxColumn
        '
        Me.ParentIdNoDataGridViewTextBoxColumn.DataPropertyName = "ParentIdNo"
        resources.ApplyResources(Me.ParentIdNoDataGridViewTextBoxColumn, "ParentIdNoDataGridViewTextBoxColumn")
        Me.ParentIdNoDataGridViewTextBoxColumn.Name = "ParentIdNoDataGridViewTextBoxColumn"
        Me.ParentIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
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
        Me.tbpNotes.UseVisualStyleBackColor = true
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
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'tabPageImages
        '
        Me.tabPageImages.ImageStream = CType(resources.GetObject("tabPageImages.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.tabPageImages.TransparentColor = System.Drawing.Color.Transparent
        Me.tabPageImages.Images.SetKeyName(0, "error.png")
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
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
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PayElementEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floPayElement.ResumeLayout(false)
        Me.tlpPayElement.ResumeLayout(false)
        Me.tlpPayElement.PerformLayout
        Me.tbcPayElement.ResumeLayout(false)
        Me.tbpCalculation.ResumeLayout(false)
        Me.floCalculation.ResumeLayout(false)
        Me.tlpCalculation.ResumeLayout(false)
        Me.tlpCalculation.PerformLayout
        Me.tbpAccountPosting.ResumeLayout(false)
        Me.floPostingAccounts.ResumeLayout(false)
        Me.tlpPostingAccounts.ResumeLayout(false)
        Me.tlpPostingAccounts.PerformLayout
        CType(Me.DataGridViewPayElementAccounts,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayElementAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpSummaryDetail.ResumeLayout(false)
        CType(Me.DataGridViewPayElementItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayElementItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpNotes.ResumeLayout(false)
        Me.floMain.ResumeLayout(false)
        Me.tlpNotes.ResumeLayout(false)
        Me.tlpNotes.PerformLayout
        Me.floDataDisplay.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayElementIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents cboPayElementKind As CaComboBox
        Friend WithEvents lblPayElementKind As CLabel
        Friend WithEvents dgvSequenceSummary As CDgvTextColumn
        Friend WithEvents dgvPayElementIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvFactorValue As CDgvTextColumn
        Friend WithEvents dgvFactorType As CaDgvComboBoxColumn
        Friend WithEvents ParentIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents cboReportGroupIdNo As CaComboBox
        Friend WithEvents lblReportGroupIdNo As CLabel
        Friend WithEvents chkSummary As CCheckBox
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblSummary As CLabel
        Friend WithEvents lblActive As CLabel
    End Class
End Namespace