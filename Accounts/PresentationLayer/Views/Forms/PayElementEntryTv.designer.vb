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
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpPayElement = New System.Windows.Forms.TableLayoutPanel()
            Me.cboReportGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayElementType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayElementGroup = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayElementKind = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayElementKind = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayElementNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtPayElementName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayElementCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkSummary = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblSummary = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayElementIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayElementAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.tbpSummaryDetail = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayElementItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceSummary = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayElementIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvFactorValue = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
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
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
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
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.tlpPayElement)
            Me.CFlowLayout4.Controls.Add(Me.tbcPayElement)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'tlpPayElement
            '
            resources.ApplyResources(Me.tlpPayElement, "tlpPayElement")
            Me.tlpPayElement.Controls.Add(Me.cboReportGroupIdNo, 1, 4)
            Me.tlpPayElement.Controls.Add(Me.lblPayElementGroup, 0, 4)
            Me.tlpPayElement.Controls.Add(Me.cboPayElementKind, 1, 3)
            Me.tlpPayElement.Controls.Add(Me.lblPayElementKind, 0, 3)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementNameAra, 1, 2)
            Me.tlpPayElement.Controls.Add(Me.lblName, 0, 1)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementCode, 3, 0)
            Me.tlpPayElement.Controls.Add(Me.lblCode, 2, 0)
            Me.tlpPayElement.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.tlpPayElement.Controls.Add(Me.CLabel1, 0, 0)
            Me.tlpPayElement.Controls.Add(Me.txtPayElementName, 1, 1)
            Me.tlpPayElement.Controls.Add(Me.lblNameAra, 0, 2)
            Me.tlpPayElement.Controls.Add(Me.chkSummary, 3, 3)
            Me.tlpPayElement.Controls.Add(Me.lblSummary, 2, 3)
            Me.tlpPayElement.Name = "tlpPayElement"
            '
            'cboReportGroupIdNo
            '
            Me.cboReportGroupIdNo.BackColor = System.Drawing.Color.White
            Me.cboReportGroupIdNo.ChangingSearchValueOnly = False
            Me.tlpPayElement.SetColumnSpan(Me.cboReportGroupIdNo, 2)
            Me.cboReportGroupIdNo.CurrentSearchTerm = ""
            Me.cboReportGroupIdNo.DefaultValue = Nothing
            Me.cboReportGroupIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboReportGroupIdNo, "cboReportGroupIdNo")
            Me.cboReportGroupIdNo.EditingMode = True
            Me.cboReportGroupIdNo.FilterRule = Nothing
            Me.cboReportGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboReportGroupIdNo.FormattingEnabled = True
            Me.cboReportGroupIdNo.HideWhenNotEditingOrAdding = False
            Me.cboReportGroupIdNo.LinkedLabel = Me.lblPayElementType
            Me.cboReportGroupIdNo.Name = "cboReportGroupIdNo"
            Me.cboReportGroupIdNo.OldValue = 0
            Me.cboReportGroupIdNo.OriginalDataSource = Nothing
            Me.cboReportGroupIdNo.OriginalList = Nothing
            Me.cboReportGroupIdNo.OverrideDropDownStyleList = False
            Me.cboReportGroupIdNo.PreviousSearchTerm = Nothing
            Me.cboReportGroupIdNo.PreviousSelectedIndex = -1
            Me.cboReportGroupIdNo.PropertySelector = Nothing
            Me.cboReportGroupIdNo.ReadOnlyCombo = False
            Me.cboReportGroupIdNo.SearchAnywhere = False
            Me.cboReportGroupIdNo.SuggestBoxHeight = 200
            Me.cboReportGroupIdNo.SuggestListOrderRule = Nothing
            Me.cboReportGroupIdNo.TextToSearch = Nothing
            Me.cboReportGroupIdNo.ValueIsMandatory = False
            Me.cboReportGroupIdNo.ValueIsNullable = False
            Me.cboReportGroupIdNo.ValueIsNumeric = False
            Me.cboReportGroupIdNo.ValueMember = "Code"
            '
            'lblPayElementType
            '
            Me.lblPayElementType.DisplayOnly = True
            Me.lblPayElementType.EditingMode = False
            resources.ApplyResources(Me.lblPayElementType, "lblPayElementType")
            Me.lblPayElementType.Name = "lblPayElementType"
            '
            'lblPayElementGroup
            '
            Me.lblPayElementGroup.DisplayOnly = True
            Me.lblPayElementGroup.EditingMode = False
            resources.ApplyResources(Me.lblPayElementGroup, "lblPayElementGroup")
            Me.lblPayElementGroup.Name = "lblPayElementGroup"
            '
            'cboPayElementKind
            '
            Me.cboPayElementKind.BackColor = System.Drawing.Color.White
            Me.cboPayElementKind.ChangingSearchValueOnly = False
            Me.cboPayElementKind.CurrentSearchTerm = ""
            Me.cboPayElementKind.DefaultValue = Nothing
            Me.cboPayElementKind.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayElementKind, "cboPayElementKind")
            Me.cboPayElementKind.EditingMode = True
            Me.cboPayElementKind.FilterRule = Nothing
            Me.cboPayElementKind.ForeColor = System.Drawing.Color.Black
            Me.cboPayElementKind.FormattingEnabled = True
            Me.cboPayElementKind.HideWhenNotEditingOrAdding = False
            Me.cboPayElementKind.LinkedLabel = Me.lblPayElementType
            Me.cboPayElementKind.Name = "cboPayElementKind"
            Me.cboPayElementKind.OldValue = 0
            Me.cboPayElementKind.OriginalDataSource = Nothing
            Me.cboPayElementKind.OriginalList = Nothing
            Me.cboPayElementKind.OverrideDropDownStyleList = False
            Me.cboPayElementKind.PreviousSearchTerm = Nothing
            Me.cboPayElementKind.PreviousSelectedIndex = -1
            Me.cboPayElementKind.PropertySelector = Nothing
            Me.cboPayElementKind.ReadOnlyCombo = False
            Me.cboPayElementKind.SearchAnywhere = False
            Me.cboPayElementKind.SuggestBoxHeight = 200
            Me.cboPayElementKind.SuggestListOrderRule = Nothing
            Me.cboPayElementKind.TextToSearch = Nothing
            Me.cboPayElementKind.ValueIsMandatory = False
            Me.cboPayElementKind.ValueIsNullable = False
            Me.cboPayElementKind.ValueIsNumeric = False
            Me.cboPayElementKind.ValueMember = "Code"
            '
            'lblPayElementKind
            '
            Me.lblPayElementKind.DisplayOnly = True
            Me.lblPayElementKind.EditingMode = False
            resources.ApplyResources(Me.lblPayElementKind, "lblPayElementKind")
            Me.lblPayElementKind.Name = "lblPayElementKind"
            '
            'txtPayElementNameAra
            '
            Me.txtPayElementNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayElementNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPayElement.SetColumnSpan(Me.txtPayElementNameAra, 3)
            Me.txtPayElementNameAra.ComputedValue = False
            Me.txtPayElementNameAra.CustomFormat = Nothing
            Me.txtPayElementNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtPayElementNameAra, "txtPayElementNameAra")
            Me.txtPayElementNameAra.EditingMode = False
            Me.txtPayElementNameAra.EnglishControl = Me.txtPayElementName
            Me.txtPayElementNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayElementNameAra.LinkedLabel = Nothing
            Me.txtPayElementNameAra.MaximumValue = Nothing
            Me.txtPayElementNameAra.MinimumValue = Nothing
            Me.txtPayElementNameAra.Name = "txtPayElementNameAra"
            Me.txtPayElementNameAra.OldValue = Nothing
            Me.txtPayElementNameAra.ReadOnly = True
            '
            'txtPayElementName
            '
            Me.txtPayElementName.BackColor = System.Drawing.Color.White
            Me.txtPayElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPayElement.SetColumnSpan(Me.txtPayElementName, 3)
            Me.txtPayElementName.ComputedValue = False
            Me.txtPayElementName.CustomFormat = Nothing
            Me.txtPayElementName.DataBoundControl = True
            resources.ApplyResources(Me.txtPayElementName, "txtPayElementName")
            Me.txtPayElementName.EditingMode = False
            Me.txtPayElementName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementName, CType(resources.GetObject("txtPayElementName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtPayElementName.LinkedLabel = Nothing
            Me.txtPayElementName.MaximumValue = Nothing
            Me.txtPayElementName.MinimumValue = Nothing
            Me.txtPayElementName.Name = "txtPayElementName"
            Me.txtPayElementName.OldValue = Nothing
            Me.txtPayElementName.ReadOnly = True
            Me.txtPayElementName.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'txtPayElementCode
            '
            Me.txtPayElementCode.BackColor = System.Drawing.Color.White
            Me.txtPayElementCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayElementCode.ComputedValue = False
            Me.txtPayElementCode.CustomFormat = Nothing
            Me.txtPayElementCode.DataBoundControl = True
            Me.txtPayElementCode.EditingMode = True
            resources.ApplyResources(Me.txtPayElementCode, "txtPayElementCode")
            Me.txtPayElementCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtPayElementCode, CType(resources.GetObject("txtPayElementCode.IconPadding"), Integer))
            Me.txtPayElementCode.LinkedLabel = Nothing
            Me.txtPayElementCode.MaximumValue = Nothing
            Me.txtPayElementCode.MinimumValue = Nothing
            Me.txtPayElementCode.Name = "txtPayElementCode"
            Me.txtPayElementCode.OldValue = Nothing
            Me.txtPayElementCode.ReadOnly = True
            Me.txtPayElementCode.ValueIsMandatory = True
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            '
            'chkSummary
            '
            Me.chkSummary.BackColor = System.Drawing.Color.White
            Me.chkSummary.DisplayOnly = False
            Me.chkSummary.EditingMode = True
            Me.chkSummary.FlatAppearance.BorderSize = 0
            resources.ApplyResources(Me.chkSummary, "chkSummary")
            Me.chkSummary.ForeColor = System.Drawing.Color.Black
            Me.chkSummary.LinkedLabel = Nothing
            Me.chkSummary.Name = "chkSummary"
            Me.chkSummary.NoLabel = True
            Me.chkSummary.OldValue = Nothing
            Me.chkSummary.UseVisualStyleBackColor = True
            '
            'lblSummary
            '
            Me.lblSummary.DisplayOnly = True
            Me.lblSummary.EditingMode = False
            resources.ApplyResources(Me.lblSummary, "lblSummary")
            Me.lblSummary.Name = "lblSummary"
            '
            'tbcPayElement
            '
            Me.tbcPayElement.Controls.Add(Me.tbpCalculation)
            Me.tbcPayElement.Controls.Add(Me.tbpAccountPosting)
            Me.tbcPayElement.Controls.Add(Me.tbpSummaryDetail)
            Me.tbcPayElement.Controls.Add(Me.tbpNotes)
            resources.ApplyResources(Me.tbcPayElement, "tbcPayElement")
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
            '
            'cboQuantityType
            '
            Me.cboQuantityType.BackColor = System.Drawing.Color.White
            Me.cboQuantityType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboQuantityType, 2)
            Me.cboQuantityType.CurrentSearchTerm = ""
            Me.cboQuantityType.DefaultValue = Nothing
            Me.cboQuantityType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboQuantityType, "cboQuantityType")
            Me.cboQuantityType.EditingMode = True
            Me.cboQuantityType.FilterRule = Nothing
            Me.cboQuantityType.ForeColor = System.Drawing.Color.Black
            Me.cboQuantityType.FormattingEnabled = True
            Me.cboQuantityType.HideWhenNotEditingOrAdding = False
            Me.cboQuantityType.LinkedLabel = Me.lblQuantityType
            Me.cboQuantityType.Name = "cboQuantityType"
            Me.cboQuantityType.OldValue = 0
            Me.cboQuantityType.OriginalDataSource = Nothing
            Me.cboQuantityType.OriginalList = Nothing
            Me.cboQuantityType.OverrideDropDownStyleList = False
            Me.cboQuantityType.PreviousSearchTerm = Nothing
            Me.cboQuantityType.PreviousSelectedIndex = -1
            Me.cboQuantityType.PropertySelector = Nothing
            Me.cboQuantityType.ReadOnlyCombo = False
            Me.cboQuantityType.SearchAnywhere = False
            Me.cboQuantityType.SuggestBoxHeight = 200
            Me.cboQuantityType.SuggestListOrderRule = Nothing
            Me.cboQuantityType.TextToSearch = Nothing
            Me.cboQuantityType.ValueIsMandatory = False
            Me.cboQuantityType.ValueIsNullable = False
            Me.cboQuantityType.ValueIsNumeric = False
            Me.cboQuantityType.ValueMember = "Code"
            '
            'cboCalculationType
            '
            Me.cboCalculationType.BackColor = System.Drawing.Color.White
            Me.cboCalculationType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboCalculationType, 3)
            Me.cboCalculationType.CurrentSearchTerm = ""
            Me.cboCalculationType.DefaultValue = Nothing
            Me.cboCalculationType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
            Me.cboCalculationType.EditingMode = True
            Me.cboCalculationType.FilterRule = Nothing
            Me.cboCalculationType.ForeColor = System.Drawing.Color.Black
            Me.cboCalculationType.FormattingEnabled = True
            Me.cboCalculationType.HideWhenNotEditingOrAdding = False
            Me.cboCalculationType.LinkedLabel = Me.lblPayElementType
            Me.cboCalculationType.Name = "cboCalculationType"
            Me.cboCalculationType.OldValue = 0
            Me.cboCalculationType.OriginalDataSource = Nothing
            Me.cboCalculationType.OriginalList = Nothing
            Me.cboCalculationType.OverrideDropDownStyleList = False
            Me.cboCalculationType.PreviousSearchTerm = Nothing
            Me.cboCalculationType.PreviousSelectedIndex = -1
            Me.cboCalculationType.PropertySelector = Nothing
            Me.cboCalculationType.ReadOnlyCombo = False
            Me.cboCalculationType.SearchAnywhere = False
            Me.cboCalculationType.SuggestBoxHeight = 200
            Me.cboCalculationType.SuggestListOrderRule = Nothing
            Me.cboCalculationType.TextToSearch = Nothing
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
            '
            'lblCalculationType
            '
            resources.ApplyResources(Me.lblCalculationType, "lblCalculationType")
            Me.lblCalculationType.DisplayOnly = True
            Me.lblCalculationType.EditingMode = False
            Me.lblCalculationType.Name = "lblCalculationType"
            '
            'txtRate
            '
            Me.txtRate.BackColor = System.Drawing.Color.White
            Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRate.ComputedValue = False
            Me.txtRate.CustomFormat = Nothing
            Me.txtRate.DataBoundControl = True
            resources.ApplyResources(Me.txtRate, "txtRate")
            Me.txtRate.EditingMode = True
            Me.txtRate.ForeColor = System.Drawing.Color.Black
            Me.txtRate.LinkedLabel = Me.lblRate
            Me.txtRate.MaximumValue = Nothing
            Me.txtRate.MinimumValue = Nothing
            Me.txtRate.Name = "txtRate"
            Me.txtRate.OldValue = Nothing
            '
            'lblRate
            '
            resources.ApplyResources(Me.lblRate, "lblRate")
            Me.lblRate.DisplayOnly = True
            Me.lblRate.EditingMode = False
            Me.lblRate.Name = "lblRate"
            '
            'txtDefaultQuantity
            '
            Me.txtDefaultQuantity.BackColor = System.Drawing.Color.White
            Me.txtDefaultQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDefaultQuantity.ComputedValue = False
            Me.txtDefaultQuantity.CustomFormat = Nothing
            Me.txtDefaultQuantity.DataBoundControl = True
            resources.ApplyResources(Me.txtDefaultQuantity, "txtDefaultQuantity")
            Me.txtDefaultQuantity.EditingMode = True
            Me.txtDefaultQuantity.ForeColor = System.Drawing.Color.Black
            Me.txtDefaultQuantity.LinkedLabel = Me.lblDefaultQuantity
            Me.txtDefaultQuantity.MaximumValue = Nothing
            Me.txtDefaultQuantity.MinimumValue = Nothing
            Me.txtDefaultQuantity.Name = "txtDefaultQuantity"
            Me.txtDefaultQuantity.OldValue = Nothing
            '
            'lblDefaultQuantity
            '
            resources.ApplyResources(Me.lblDefaultQuantity, "lblDefaultQuantity")
            Me.lblDefaultQuantity.DisplayOnly = True
            Me.lblDefaultQuantity.EditingMode = False
            Me.lblDefaultQuantity.Name = "lblDefaultQuantity"
            '
            'lblBasePayment
            '
            resources.ApplyResources(Me.lblBasePayment, "lblBasePayment")
            Me.lblBasePayment.DisplayOnly = True
            Me.lblBasePayment.EditingMode = False
            Me.lblBasePayment.Name = "lblBasePayment"
            '
            'cboBasePaymentIdNo
            '
            Me.cboBasePaymentIdNo.BackColor = System.Drawing.Color.White
            Me.cboBasePaymentIdNo.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
            Me.cboBasePaymentIdNo.CurrentSearchTerm = ""
            Me.cboBasePaymentIdNo.DefaultValue = Nothing
            Me.cboBasePaymentIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboBasePaymentIdNo, "cboBasePaymentIdNo")
            Me.cboBasePaymentIdNo.EditingMode = True
            Me.cboBasePaymentIdNo.FilterRule = Nothing
            Me.cboBasePaymentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBasePaymentIdNo.FormattingEnabled = True
            Me.cboBasePaymentIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBasePaymentIdNo.LinkedLabel = Me.lblBasePayment
            Me.cboBasePaymentIdNo.Name = "cboBasePaymentIdNo"
            Me.cboBasePaymentIdNo.OldValue = 0
            Me.cboBasePaymentIdNo.OriginalDataSource = Nothing
            Me.cboBasePaymentIdNo.OriginalList = Nothing
            Me.cboBasePaymentIdNo.OverrideDropDownStyleList = False
            Me.cboBasePaymentIdNo.PreviousSearchTerm = Nothing
            Me.cboBasePaymentIdNo.PreviousSelectedIndex = -1
            Me.cboBasePaymentIdNo.PropertySelector = Nothing
            Me.cboBasePaymentIdNo.ReadOnlyCombo = False
            Me.cboBasePaymentIdNo.SearchAnywhere = False
            Me.cboBasePaymentIdNo.SuggestBoxHeight = 200
            Me.cboBasePaymentIdNo.SuggestListOrderRule = Nothing
            Me.cboBasePaymentIdNo.TextToSearch = Nothing
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
            '
            'chkIncludeInEOS
            '
            resources.ApplyResources(Me.chkIncludeInEOS, "chkIncludeInEOS")
            Me.chkIncludeInEOS.BackColor = System.Drawing.Color.White
            Me.chkIncludeInEOS.DisplayOnly = False
            Me.chkIncludeInEOS.EditingMode = True
            Me.chkIncludeInEOS.FlatAppearance.BorderSize = 0
            Me.chkIncludeInEOS.ForeColor = System.Drawing.Color.Black
            Me.chkIncludeInEOS.LinkedLabel = Me.lblIncludeInEos
            Me.chkIncludeInEOS.Name = "chkIncludeInEOS"
            Me.chkIncludeInEOS.NoLabel = True
            Me.chkIncludeInEOS.OldValue = Nothing
            Me.chkIncludeInEOS.UseVisualStyleBackColor = True
            '
            'txtMultiplier
            '
            Me.txtMultiplier.BackColor = System.Drawing.Color.White
            Me.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplier.ComputedValue = False
            Me.txtMultiplier.CustomFormat = Nothing
            Me.txtMultiplier.DataBoundControl = True
            resources.ApplyResources(Me.txtMultiplier, "txtMultiplier")
            Me.txtMultiplier.EditingMode = True
            Me.txtMultiplier.ForeColor = System.Drawing.Color.Black
            Me.txtMultiplier.LinkedLabel = Me.lblFactorValue
            Me.txtMultiplier.MaximumValue = Nothing
            Me.txtMultiplier.MinimumValue = Nothing
            Me.txtMultiplier.Name = "txtMultiplier"
            Me.txtMultiplier.OldValue = Nothing
            '
            'cboFactorType
            '
            Me.cboFactorType.BackColor = System.Drawing.Color.White
            Me.cboFactorType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboFactorType, 2)
            Me.cboFactorType.CurrentSearchTerm = ""
            Me.cboFactorType.DefaultValue = Nothing
            Me.cboFactorType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboFactorType, "cboFactorType")
            Me.cboFactorType.EditingMode = True
            Me.cboFactorType.FilterRule = Nothing
            Me.cboFactorType.ForeColor = System.Drawing.Color.Black
            Me.cboFactorType.FormattingEnabled = True
            Me.cboFactorType.HideWhenNotEditingOrAdding = False
            Me.cboFactorType.LinkedLabel = Me.lblFactorType
            Me.cboFactorType.Name = "cboFactorType"
            Me.cboFactorType.OldValue = 0
            Me.cboFactorType.OriginalDataSource = Nothing
            Me.cboFactorType.OriginalList = Nothing
            Me.cboFactorType.OverrideDropDownStyleList = False
            Me.cboFactorType.PreviousSearchTerm = Nothing
            Me.cboFactorType.PreviousSelectedIndex = -1
            Me.cboFactorType.PropertySelector = Nothing
            Me.cboFactorType.ReadOnlyCombo = False
            Me.cboFactorType.SearchAnywhere = False
            Me.cboFactorType.SuggestBoxHeight = 200
            Me.cboFactorType.SuggestListOrderRule = Nothing
            Me.cboFactorType.TextToSearch = Nothing
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
            '
            'chkTaxable
            '
            resources.ApplyResources(Me.chkTaxable, "chkTaxable")
            Me.chkTaxable.BackColor = System.Drawing.Color.White
            Me.chkTaxable.DisplayOnly = False
            Me.chkTaxable.EditingMode = True
            Me.chkTaxable.FlatAppearance.BorderSize = 0
            Me.chkTaxable.ForeColor = System.Drawing.Color.Black
            Me.chkTaxable.LinkedLabel = Me.lblTaxable
            Me.chkTaxable.Name = "chkTaxable"
            Me.chkTaxable.NoLabel = True
            Me.chkTaxable.OldValue = Nothing
            Me.chkTaxable.UseVisualStyleBackColor = True
            '
            'lblTaxable
            '
            resources.ApplyResources(Me.lblTaxable, "lblTaxable")
            Me.tlpCalculation.SetColumnSpan(Me.lblTaxable, 2)
            Me.lblTaxable.DisplayOnly = True
            Me.lblTaxable.EditingMode = False
            Me.lblTaxable.Name = "lblTaxable"
            '
            'lblSlash
            '
            resources.ApplyResources(Me.lblSlash, "lblSlash")
            Me.lblSlash.DisplayOnly = True
            Me.lblSlash.EditingMode = False
            Me.lblSlash.Name = "lblSlash"
            '
            'cboUnit
            '
            Me.cboUnit.BackColor = System.Drawing.Color.White
            Me.cboUnit.ChangingSearchValueOnly = False
            Me.cboUnit.CurrentSearchTerm = ""
            Me.cboUnit.DefaultValue = Nothing
            Me.cboUnit.DisplayMember = "Name"
            resources.ApplyResources(Me.cboUnit, "cboUnit")
            Me.cboUnit.EditingMode = True
            Me.cboUnit.FilterRule = Nothing
            Me.cboUnit.ForeColor = System.Drawing.Color.Black
            Me.cboUnit.FormattingEnabled = True
            Me.cboUnit.HideWhenNotEditingOrAdding = False
            Me.cboUnit.LinkedLabel = Me.lblUnit
            Me.cboUnit.Name = "cboUnit"
            Me.cboUnit.OldValue = 0
            Me.cboUnit.OriginalDataSource = Nothing
            Me.cboUnit.OriginalList = Nothing
            Me.cboUnit.OverrideDropDownStyleList = False
            Me.cboUnit.PreviousSearchTerm = Nothing
            Me.cboUnit.PreviousSelectedIndex = -1
            Me.cboUnit.PropertySelector = Nothing
            Me.cboUnit.ReadOnlyCombo = False
            Me.cboUnit.SearchAnywhere = False
            Me.cboUnit.SuggestBoxHeight = 200
            Me.cboUnit.SuggestListOrderRule = Nothing
            Me.cboUnit.TextToSearch = Nothing
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
            '
            'cboPayElementType
            '
            Me.cboPayElementType.BackColor = System.Drawing.Color.White
            Me.cboPayElementType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboPayElementType, 3)
            Me.cboPayElementType.CurrentSearchTerm = ""
            Me.cboPayElementType.DefaultValue = Nothing
            Me.cboPayElementType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayElementType, "cboPayElementType")
            Me.cboPayElementType.EditingMode = True
            Me.cboPayElementType.FilterRule = Nothing
            Me.cboPayElementType.ForeColor = System.Drawing.Color.Black
            Me.cboPayElementType.FormattingEnabled = True
            Me.cboPayElementType.HideWhenNotEditingOrAdding = False
            Me.cboPayElementType.LinkedLabel = Me.lblPayElementType
            Me.cboPayElementType.Name = "cboPayElementType"
            Me.cboPayElementType.OldValue = 0
            Me.cboPayElementType.OriginalDataSource = Nothing
            Me.cboPayElementType.OriginalList = Nothing
            Me.cboPayElementType.OverrideDropDownStyleList = False
            Me.cboPayElementType.PreviousSearchTerm = Nothing
            Me.cboPayElementType.PreviousSelectedIndex = -1
            Me.cboPayElementType.PropertySelector = Nothing
            Me.cboPayElementType.ReadOnlyCombo = False
            Me.cboPayElementType.SearchAnywhere = False
            Me.cboPayElementType.SuggestBoxHeight = 200
            Me.cboPayElementType.SuggestListOrderRule = Nothing
            Me.cboPayElementType.TextToSearch = Nothing
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
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = -1
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SearchAnywhere = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
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
            '
            'chkUsePayGroups
            '
            Me.chkUsePayGroups.BackColor = System.Drawing.Color.White
            Me.chkUsePayGroups.DisplayOnly = False
            Me.chkUsePayGroups.EditingMode = True
            Me.chkUsePayGroups.FlatAppearance.BorderSize = 0
            resources.ApplyResources(Me.chkUsePayGroups, "chkUsePayGroups")
            Me.chkUsePayGroups.ForeColor = System.Drawing.Color.Black
            Me.chkUsePayGroups.LinkedLabel = Me.lblUsePayGroups
            Me.chkUsePayGroups.Name = "chkUsePayGroups"
            Me.chkUsePayGroups.NoLabel = True
            Me.chkUsePayGroups.OldValue = Nothing
            Me.chkUsePayGroups.UseVisualStyleBackColor = True
            '
            'DataGridViewPayElementAccounts
            '
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayElementAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
            Me.DataGridViewPayElementAccounts.AutoGenerateColumns = False
            Me.DataGridViewPayElementAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayElementAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.PayElementIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1, Me.PayGroupNameDataGridViewTextBoxColumn})
            Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPayElementAccounts, 3)
            Me.DataGridViewPayElementAccounts.DataSource = Me.bsPayElementAccounts
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayElementAccounts.DefaultCellStyle = DataGridViewCellStyle16
            Me.DataGridViewPayElementAccounts.DgvFooter = Nothing
            Me.DataGridViewPayElementAccounts.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayElementAccounts, "DataGridViewPayElementAccounts")
            Me.DataGridViewPayElementAccounts.Ea = Nothing
            Me.DataGridViewPayElementAccounts.EditingMode = False
            Me.DataGridViewPayElementAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayElementAccounts.FieldsDictionary = Nothing
            Me.DataGridViewPayElementAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayElementAccounts.FirstRowInsertionEnabled = True
            Me.DataGridViewPayElementAccounts.Name = "DataGridViewPayElementAccounts"
            Me.DataGridViewPayElementAccounts.ReadOnly = True
            Me.DataGridViewPayElementAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayElementAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayElementAccounts.ShowFooter = False
            Me.DataGridViewPayElementAccounts.ShowInsertColumnWhenEditing = True
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPayGroupIdNo
            '
            Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvPayGroupIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
            Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
            Me.dgvPayGroupIdNo.ReadOnly = True
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
            Me.dgvAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayElementItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayElementItems.AutoGenerateColumns = False
            Me.DataGridViewPayElementItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayElementItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSummary, Me.dgvPayElementIdNo, Me.dgvFactorValue, Me.dgvFactorType, Me.ParentIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewPayElementItems.DataSource = Me.bsPayElementItems
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayElementItems.DefaultCellStyle = DataGridViewCellStyle20
            Me.DataGridViewPayElementItems.DgvFooter = Nothing
            Me.DataGridViewPayElementItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayElementItems, "DataGridViewPayElementItems")
            Me.DataGridViewPayElementItems.Ea = Nothing
            Me.DataGridViewPayElementItems.EditingMode = False
            Me.DataGridViewPayElementItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayElementItems.FieldsDictionary = Nothing
            Me.DataGridViewPayElementItems.FirstRowDeletionEnabled = True
            Me.DataGridViewPayElementItems.FirstRowInsertionEnabled = True
            Me.DataGridViewPayElementItems.Name = "DataGridViewPayElementItems"
            Me.DataGridViewPayElementItems.ReadOnly = True
            Me.DataGridViewPayElementItems.SequenceColumn = "dgvSequenceSummary"
            Me.DataGridViewPayElementItems.SequenceFieldName = "Sequence"
            Me.DataGridViewPayElementItems.ShowFooter = False
            Me.DataGridViewPayElementItems.ShowInsertColumnWhenEditing = True
            '
            'dgvSequenceSummary
            '
            Me.dgvSequenceSummary.DataPropertyName = "Sequence"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceSummary.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvSequenceSummary.EditingMode = False
            resources.ApplyResources(Me.dgvSequenceSummary, "dgvSequenceSummary")
            Me.dgvSequenceSummary.Name = "dgvSequenceSummary"
            Me.dgvSequenceSummary.ReadOnly = True
            Me.dgvSequenceSummary.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPayElementIdNo
            '
            Me.dgvPayElementIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvPayElementIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvPayElementIdNo.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvPayElementIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvPayElementIdNo, "dgvPayElementIdNo")
            Me.dgvPayElementIdNo.Name = "dgvPayElementIdNo"
            Me.dgvPayElementIdNo.ReadOnly = True
            Me.dgvPayElementIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayElementIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvFactorValue
            '
            Me.dgvFactorValue.DataPropertyName = "FactorValue"
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.dgvFactorValue.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvFactorValue.EditingMode = False
            resources.ApplyResources(Me.dgvFactorValue, "dgvFactorValue")
            Me.dgvFactorValue.Name = "dgvFactorValue"
            Me.dgvFactorValue.ReadOnly = True
            Me.dgvFactorValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvFactorType
            '
            Me.dgvFactorType.DataPropertyName = "FactorType"
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            Me.dgvFactorType.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvFactorType.EditingMode = False
            resources.ApplyResources(Me.dgvFactorType, "dgvFactorType")
            Me.dgvFactorType.Name = "dgvFactorType"
            Me.dgvFactorType.ReadOnly = True
            Me.dgvFactorType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvFactorType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpNotes.SetColumnSpan(Me.txtNotes, 2)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'tabPageImages
            '
            Me.tabPageImages.ImageStream = CType(resources.GetObject("tabPageImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.tabPageImages.TransparentColor = System.Drawing.Color.Transparent
            Me.tabPageImages.Images.SetKeyName(0, "error.png")
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'PayElementEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayElementEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
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
        Friend WithEvents CFlowLayout4 As CFlowLayout
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
        Friend WithEvents lblSummary As CLabel
        Friend WithEvents chkSummary As CCheckBox
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
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayElementIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents cboPayElementKind As CaComboBox
        Friend WithEvents lblPayElementKind As CLabel
        Friend WithEvents dgvSequenceSummary As CdgvColumnText
        Friend WithEvents dgvPayElementIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvFactorValue As CdgvColumnText
        Friend WithEvents dgvFactorType As CaDgvComboBoxColumn
        Friend WithEvents ParentIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents cboReportGroupIdNo As CaComboBox
        Friend WithEvents lblPayElementGroup As CLabel
    End Class
End Namespace