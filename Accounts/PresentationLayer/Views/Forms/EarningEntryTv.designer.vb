Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EarningEntryTv
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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EarningEntryTv))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpEarning = New System.Windows.Forms.TableLayoutPanel()
            Me.lblSummary = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkSummary = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.tbcEarning = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpMain = New System.Windows.Forms.TabPage()
            Me.floMain = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpCalculation = New System.Windows.Forms.TabPage()
            Me.floCalculation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpCalculation = New System.Windows.Forms.TableLayoutPanel()
            Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblMultiplier = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCalculationType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBasePayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBasePaymentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblIncludeInEos = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIncludeInEOS = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.txtMultiplier = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboMultiplierType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblMultiplierType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkTaxable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblTaxable = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSlash = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            Me.floPostingAccounts = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.tbpSummaryDetail = New System.Windows.Forms.TabPage()
            Me.DataGridViewSummaryDetail = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvMultiplierSummary = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsEarningSummary = New System.Windows.Forms.BindingSource(Me.components)
            Me.tabPageImages = New System.Windows.Forms.ImageList(Me.components)
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.tlpEarning.SuspendLayout()
            Me.tbcEarning.SuspendLayout()
            Me.tbpMain.SuspendLayout()
            Me.floMain.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbpCalculation.SuspendLayout()
            Me.floCalculation.SuspendLayout()
            Me.tlpCalculation.SuspendLayout()
            Me.tbpAccountPosting.SuspendLayout()
            Me.floPostingAccounts.SuspendLayout()
            Me.tlpPostingAccounts.SuspendLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpSummaryDetail.SuspendLayout()
            CType(Me.DataGridViewSummaryDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsEarningSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
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
            Me.CFlowLayout4.Controls.Add(Me.tlpEarning)
            Me.CFlowLayout4.Controls.Add(Me.tbcEarning)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'tlpEarning
            '
            resources.ApplyResources(Me.tlpEarning, "tlpEarning")
            Me.tlpEarning.Controls.Add(Me.lblSummary, 0, 3)
            Me.tlpEarning.Controls.Add(Me.txtEarningNameAra, 1, 2)
            Me.tlpEarning.Controls.Add(Me.lblName, 0, 1)
            Me.tlpEarning.Controls.Add(Me.txtEarningCode, 3, 0)
            Me.tlpEarning.Controls.Add(Me.lblCode, 2, 0)
            Me.tlpEarning.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.tlpEarning.Controls.Add(Me.CLabel1, 0, 0)
            Me.tlpEarning.Controls.Add(Me.txtEarningName, 1, 1)
            Me.tlpEarning.Controls.Add(Me.lblNameAra, 0, 2)
            Me.tlpEarning.Controls.Add(Me.chkSummary, 1, 3)
            Me.tlpEarning.Name = "tlpEarning"
            '
            'lblSummary
            '
            Me.lblSummary.DisplayOnly = True
            Me.lblSummary.EditingMode = False
            resources.ApplyResources(Me.lblSummary, "lblSummary")
            Me.lblSummary.Name = "lblSummary"
            '
            'txtEarningNameAra
            '
            Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
            Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpEarning.SetColumnSpan(Me.txtEarningNameAra, 3)
            Me.txtEarningNameAra.ComputedValue = False
            Me.txtEarningNameAra.CustomFormat = Nothing
            Me.txtEarningNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtEarningNameAra, "txtEarningNameAra")
            Me.txtEarningNameAra.EditingMode = False
            Me.txtEarningNameAra.EnglishControl = Me.txtEarningName
            Me.txtEarningNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEarningNameAra.LinkedLabel = Nothing
            Me.txtEarningNameAra.MaximumValue = Nothing
            Me.txtEarningNameAra.MinimumValue = Nothing
            Me.txtEarningNameAra.Name = "txtEarningNameAra"
            Me.txtEarningNameAra.OldValue = Nothing
            Me.txtEarningNameAra.ReadOnly = True
            '
            'txtEarningName
            '
            Me.txtEarningName.BackColor = System.Drawing.Color.White
            Me.txtEarningName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpEarning.SetColumnSpan(Me.txtEarningName, 3)
            Me.txtEarningName.ComputedValue = False
            Me.txtEarningName.CustomFormat = Nothing
            Me.txtEarningName.DataBoundControl = True
            resources.ApplyResources(Me.txtEarningName, "txtEarningName")
            Me.txtEarningName.EditingMode = False
            Me.txtEarningName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtEarningName, CType(resources.GetObject("txtEarningName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtEarningName.LinkedLabel = Nothing
            Me.txtEarningName.MaximumValue = Nothing
            Me.txtEarningName.MinimumValue = Nothing
            Me.txtEarningName.Name = "txtEarningName"
            Me.txtEarningName.OldValue = Nothing
            Me.txtEarningName.ReadOnly = True
            Me.txtEarningName.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'txtEarningCode
            '
            Me.txtEarningCode.BackColor = System.Drawing.Color.White
            Me.txtEarningCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEarningCode.ComputedValue = False
            Me.txtEarningCode.CustomFormat = Nothing
            Me.txtEarningCode.DataBoundControl = True
            Me.txtEarningCode.EditingMode = True
            resources.ApplyResources(Me.txtEarningCode, "txtEarningCode")
            Me.txtEarningCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconPadding"), Integer))
            Me.txtEarningCode.LinkedLabel = Nothing
            Me.txtEarningCode.MaximumValue = Nothing
            Me.txtEarningCode.MinimumValue = Nothing
            Me.txtEarningCode.Name = "txtEarningCode"
            Me.txtEarningCode.OldValue = Nothing
            Me.txtEarningCode.ReadOnly = True
            Me.txtEarningCode.ValueIsMandatory = True
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
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
            Me.TxtIdNo.EditingMode = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
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
            'tbcEarning
            '
            Me.tbcEarning.Controls.Add(Me.tbpMain)
            Me.tbcEarning.Controls.Add(Me.tbpCalculation)
            Me.tbcEarning.Controls.Add(Me.tbpAccountPosting)
            Me.tbcEarning.Controls.Add(Me.tbpSummaryDetail)
            resources.ApplyResources(Me.tbcEarning, "tbcEarning")
            Me.tbcEarning.ImageList = Me.tabPageImages
            Me.tbcEarning.Name = "tbcEarning"
            Me.tbcEarning.SelectedIndex = 0
            '
            'tbpMain
            '
            Me.tbpMain.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            resources.ApplyResources(Me.tbpMain, "tbpMain")
            Me.tbpMain.Controls.Add(Me.floMain)
            Me.tbpMain.Cursor = System.Windows.Forms.Cursors.Default
            Me.tbpMain.Name = "tbpMain"
            Me.tbpMain.UseVisualStyleBackColor = True
            '
            'floMain
            '
            Me.floMain.BackColor = System.Drawing.Color.Transparent
            Me.floMain.Controls.Add(Me.TableLayoutPanel1)
            resources.ApplyResources(Me.floMain, "floMain")
            Me.floMain.Name = "floMain"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 5)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 2)
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
            Me.tlpCalculation.Controls.Add(Me.cboCalculationType, 1, 1)
            Me.tlpCalculation.Controls.Add(Me.lblUnit, 0, 3)
            Me.tlpCalculation.Controls.Add(Me.lblEarningType, 0, 0)
            Me.tlpCalculation.Controls.Add(Me.lblMultiplier, 0, 6)
            Me.tlpCalculation.Controls.Add(Me.lblDefaultQuantity, 0, 4)
            Me.tlpCalculation.Controls.Add(Me.lblCalculationType, 0, 1)
            Me.tlpCalculation.Controls.Add(Me.txtRate, 1, 2)
            Me.tlpCalculation.Controls.Add(Me.txtDefaultQuantity, 1, 4)
            Me.tlpCalculation.Controls.Add(Me.lblBasePayment, 0, 5)
            Me.tlpCalculation.Controls.Add(Me.cboBasePaymentIdNo, 1, 5)
            Me.tlpCalculation.Controls.Add(Me.lblIncludeInEos, 0, 7)
            Me.tlpCalculation.Controls.Add(Me.chkIncludeInEOS, 1, 7)
            Me.tlpCalculation.Controls.Add(Me.txtMultiplier, 1, 6)
            Me.tlpCalculation.Controls.Add(Me.cboMultiplierType, 2, 6)
            Me.tlpCalculation.Controls.Add(Me.chkTaxable, 2, 8)
            Me.tlpCalculation.Controls.Add(Me.lblTaxable, 0, 8)
            Me.tlpCalculation.Controls.Add(Me.lblSlash, 2, 2)
            Me.tlpCalculation.Controls.Add(Me.lblRate, 0, 2)
            Me.tlpCalculation.Controls.Add(Me.cboUnit, 3, 2)
            Me.tlpCalculation.Controls.Add(Me.lblMultiplierType, 3, 7)
            Me.tlpCalculation.Controls.Add(Me.cboEarningType, 1, 0)
            Me.tlpCalculation.Name = "tlpCalculation"
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
            Me.cboCalculationType.LinkedLabel = Me.lblEarningType
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
            'lblEarningType
            '
            Me.lblEarningType.DisplayOnly = True
            Me.lblEarningType.EditingMode = False
            resources.ApplyResources(Me.lblEarningType, "lblEarningType")
            Me.lblEarningType.Name = "lblEarningType"
            '
            'lblUnit
            '
            resources.ApplyResources(Me.lblUnit, "lblUnit")
            Me.lblUnit.DisplayOnly = True
            Me.lblUnit.EditingMode = False
            Me.lblUnit.Name = "lblUnit"
            '
            'lblMultiplier
            '
            resources.ApplyResources(Me.lblMultiplier, "lblMultiplier")
            Me.lblMultiplier.DisplayOnly = True
            Me.lblMultiplier.EditingMode = False
            Me.lblMultiplier.Name = "lblMultiplier"
            '
            'lblDefaultQuantity
            '
            resources.ApplyResources(Me.lblDefaultQuantity, "lblDefaultQuantity")
            Me.lblDefaultQuantity.DisplayOnly = True
            Me.lblDefaultQuantity.EditingMode = False
            Me.lblDefaultQuantity.Name = "lblDefaultQuantity"
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
            Me.txtMultiplier.LinkedLabel = Me.lblMultiplier
            Me.txtMultiplier.MaximumValue = Nothing
            Me.txtMultiplier.MinimumValue = Nothing
            Me.txtMultiplier.Name = "txtMultiplier"
            Me.txtMultiplier.OldValue = Nothing
            '
            'cboMultiplierType
            '
            Me.cboMultiplierType.BackColor = System.Drawing.Color.White
            Me.cboMultiplierType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboMultiplierType, 2)
            Me.cboMultiplierType.CurrentSearchTerm = ""
            Me.cboMultiplierType.DefaultValue = Nothing
            Me.cboMultiplierType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboMultiplierType, "cboMultiplierType")
            Me.cboMultiplierType.EditingMode = True
            Me.cboMultiplierType.FilterRule = Nothing
            Me.cboMultiplierType.ForeColor = System.Drawing.Color.Black
            Me.cboMultiplierType.FormattingEnabled = True
            Me.cboMultiplierType.HideWhenNotEditingOrAdding = False
            Me.cboMultiplierType.LinkedLabel = Me.lblMultiplierType
            Me.cboMultiplierType.Name = "cboMultiplierType"
            Me.cboMultiplierType.OldValue = 0
            Me.cboMultiplierType.OriginalDataSource = Nothing
            Me.cboMultiplierType.OriginalList = Nothing
            Me.cboMultiplierType.OverrideDropDownStyleList = False
            Me.cboMultiplierType.PreviousSearchTerm = Nothing
            Me.cboMultiplierType.PreviousSelectedIndex = -1
            Me.cboMultiplierType.PropertySelector = Nothing
            Me.cboMultiplierType.ReadOnlyCombo = False
            Me.cboMultiplierType.SearchAnywhere = False
            Me.cboMultiplierType.SuggestBoxHeight = 200
            Me.cboMultiplierType.SuggestListOrderRule = Nothing
            Me.cboMultiplierType.TextToSearch = Nothing
            Me.cboMultiplierType.ValueIsMandatory = False
            Me.cboMultiplierType.ValueIsNullable = False
            Me.cboMultiplierType.ValueIsNumeric = False
            Me.cboMultiplierType.ValueMember = "Code"
            '
            'lblMultiplierType
            '
            resources.ApplyResources(Me.lblMultiplierType, "lblMultiplierType")
            Me.lblMultiplierType.DisplayOnly = True
            Me.lblMultiplierType.EditingMode = False
            Me.lblMultiplierType.Name = "lblMultiplierType"
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
            'cboEarningType
            '
            Me.cboEarningType.BackColor = System.Drawing.Color.White
            Me.cboEarningType.ChangingSearchValueOnly = False
            Me.tlpCalculation.SetColumnSpan(Me.cboEarningType, 3)
            Me.cboEarningType.CurrentSearchTerm = ""
            Me.cboEarningType.DefaultValue = Nothing
            Me.cboEarningType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboEarningType, "cboEarningType")
            Me.cboEarningType.EditingMode = True
            Me.cboEarningType.FilterRule = Nothing
            Me.cboEarningType.ForeColor = System.Drawing.Color.Black
            Me.cboEarningType.FormattingEnabled = True
            Me.cboEarningType.HideWhenNotEditingOrAdding = False
            Me.cboEarningType.LinkedLabel = Me.lblEarningType
            Me.cboEarningType.Name = "cboEarningType"
            Me.cboEarningType.OldValue = 0
            Me.cboEarningType.OriginalDataSource = Nothing
            Me.cboEarningType.OriginalList = Nothing
            Me.cboEarningType.OverrideDropDownStyleList = False
            Me.cboEarningType.PreviousSearchTerm = Nothing
            Me.cboEarningType.PreviousSelectedIndex = -1
            Me.cboEarningType.PropertySelector = Nothing
            Me.cboEarningType.ReadOnlyCombo = False
            Me.cboEarningType.SearchAnywhere = False
            Me.cboEarningType.SuggestBoxHeight = 200
            Me.cboEarningType.SuggestListOrderRule = Nothing
            Me.cboEarningType.TextToSearch = Nothing
            Me.cboEarningType.ValueIsMandatory = False
            Me.cboEarningType.ValueIsNullable = False
            Me.cboEarningType.ValueIsNumeric = False
            Me.cboEarningType.ValueMember = "Code"
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
            Me.tlpPostingAccounts.Controls.Add(Me.DataGridViewPayrollEarnAccounts, 0, 2)
            Me.tlpPostingAccounts.Controls.Add(Me.lblUsePayGroups, 0, 0)
            Me.tlpPostingAccounts.Controls.Add(Me.chkUsePayGroups, 2, 0)
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
            'DataGridViewPayrollEarnAccounts
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollEarnAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayrollEarnAccounts.AutoGenerateColumns = False
            Me.DataGridViewPayrollEarnAccounts.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewPayrollEarnAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollEarnAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.EarningIdNoDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
            Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPayrollEarnAccounts, 3)
            Me.DataGridViewPayrollEarnAccounts.DataSource = Me.bsPayrollEarnAccounts
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayrollEarnAccounts.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewPayrollEarnAccounts.DgvFooter = Nothing
            Me.DataGridViewPayrollEarnAccounts.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayrollEarnAccounts, "DataGridViewPayrollEarnAccounts")
            Me.DataGridViewPayrollEarnAccounts.Ea = EventAggregator1
            Me.DataGridViewPayrollEarnAccounts.EditingMode = False
            Me.DataGridViewPayrollEarnAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollEarnAccounts.FieldsDictionary = Nothing
            Me.DataGridViewPayrollEarnAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollEarnAccounts.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollEarnAccounts.Name = "DataGridViewPayrollEarnAccounts"
            Me.DataGridViewPayrollEarnAccounts.ReadOnly = True
            Me.DataGridViewPayrollEarnAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollEarnAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollEarnAccounts.ShowFooter = False
            Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = True
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPayGroupIdNo
            '
            Me.dgvPayGroupIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvPayGroupIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
            Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
            Me.dgvPayGroupIdNo.ReadOnly = True
            Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'EarningIdNoDataGridViewTextBoxColumn
            '
            Me.EarningIdNoDataGridViewTextBoxColumn.DataPropertyName = "EarningIdNo"
            resources.ApplyResources(Me.EarningIdNoDataGridViewTextBoxColumn, "EarningIdNoDataGridViewTextBoxColumn")
            Me.EarningIdNoDataGridViewTextBoxColumn.Name = "EarningIdNoDataGridViewTextBoxColumn"
            Me.EarningIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayGroupNameDataGridViewTextBoxColumn
            '
            Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
            resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
            Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
            Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsPayrollEarnAccounts
            '
            Me.bsPayrollEarnAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollEarnAccountModel)
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
            'tbpSummaryDetail
            '
            Me.tbpSummaryDetail.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.tbpSummaryDetail.Controls.Add(Me.DataGridViewSummaryDetail)
            resources.ApplyResources(Me.tbpSummaryDetail, "tbpSummaryDetail")
            Me.tbpSummaryDetail.Name = "tbpSummaryDetail"
            Me.tbpSummaryDetail.UseVisualStyleBackColor = True
            '
            'DataGridViewSummaryDetail
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewSummaryDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewSummaryDetail.AutoGenerateColumns = False
            Me.DataGridViewSummaryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewSummaryDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEarningIdNo, Me.dgvMultiplierSummary, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewSummaryDetail.DataSource = Me.bsEarningSummary
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewSummaryDetail.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewSummaryDetail.DgvFooter = Nothing
            Me.DataGridViewSummaryDetail.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewSummaryDetail, "DataGridViewSummaryDetail")
            Me.DataGridViewSummaryDetail.Ea = Nothing
            Me.DataGridViewSummaryDetail.EditingMode = False
            Me.DataGridViewSummaryDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewSummaryDetail.FieldsDictionary = Nothing
            Me.DataGridViewSummaryDetail.FirstRowDeletionEnabled = True
            Me.DataGridViewSummaryDetail.FirstRowInsertionEnabled = True
            Me.DataGridViewSummaryDetail.Name = "DataGridViewSummaryDetail"
            Me.DataGridViewSummaryDetail.ReadOnly = True
            Me.DataGridViewSummaryDetail.SequenceColumn = "dgvSequence"
            Me.DataGridViewSummaryDetail.SequenceFieldName = "Sequence"
            Me.DataGridViewSummaryDetail.ShowFooter = False
            Me.DataGridViewSummaryDetail.ShowInsertColumnWhenEditing = True
            '
            'dgvEarningIdNo
            '
            Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEarningIdNo.DataPropertyName = "EarningIdNo"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningIdNo.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvEarningIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvEarningIdNo, "dgvEarningIdNo")
            Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
            Me.dgvEarningIdNo.ReadOnly = True
            Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvMultiplierSummary
            '
            Me.dgvMultiplierSummary.DataPropertyName = "Multiplier"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvMultiplierSummary.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvMultiplierSummary.EditingMode = False
            resources.ApplyResources(Me.dgvMultiplierSummary, "dgvMultiplierSummary")
            Me.dgvMultiplierSummary.Name = "dgvMultiplierSummary"
            Me.dgvMultiplierSummary.ReadOnly = True
            Me.dgvMultiplierSummary.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsEarningSummary
            '
            Me.bsEarningSummary.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EarningSummaryModel)
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
            'EarningEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "EarningEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.tlpEarning.ResumeLayout(False)
            Me.tlpEarning.PerformLayout()
            Me.tbcEarning.ResumeLayout(False)
            Me.tbpMain.ResumeLayout(False)
            Me.floMain.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbpCalculation.ResumeLayout(False)
            Me.floCalculation.ResumeLayout(False)
            Me.tlpCalculation.ResumeLayout(False)
            Me.tlpCalculation.PerformLayout()
            Me.tbpAccountPosting.ResumeLayout(False)
            Me.floPostingAccounts.ResumeLayout(False)
            Me.tlpPostingAccounts.ResumeLayout(False)
            Me.tlpPostingAccounts.PerformLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpSummaryDetail.ResumeLayout(False)
            CType(Me.DataGridViewSummaryDetail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsEarningSummary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPayrollEarnAccounts As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents tlpEarning As TableLayoutPanel
        Friend WithEvents txtEarningNameAra As CTextBoxArabic
        Friend WithEvents txtEarningName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtEarningCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents tbcEarning As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents floMain As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpCalculation As TabPage
        Friend WithEvents floCalculation As CFlowLayout
        Friend WithEvents tlpCalculation As TableLayoutPanel
        Friend WithEvents lblMultiplier As CLabel
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
        Friend WithEvents cboMultiplierType As CaComboBox
        Friend WithEvents cboUnit As CaComboBox
        Friend WithEvents lblSlash As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents floPostingAccounts As CFlowLayout
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents chkTaxable As CCheckBox
        Friend WithEvents lblTaxable As CLabel
        Friend WithEvents tlpPostingAccounts As TableLayoutPanel
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents lblUsePayGroups As CLabel
        Friend WithEvents chkUsePayGroups As CCheckBox
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblUnit As CLabel
        Friend WithEvents lblSummary As CLabel
        Friend WithEvents chkSummary As CCheckBox
        Friend WithEvents tbpSummaryDetail As TabPage
        Friend WithEvents DataGridViewSummaryDetail As CDataGridView
        Friend WithEvents bsEarningSummary As BindingSource
        Friend WithEvents dgvEarningIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvMultiplierSummary As CdgvColumnText
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tabPageImages As ImageList
        Friend WithEvents lblMultiplierType As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents cboCalculationType As CaComboBox
    End Class
End Namespace