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
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpEarning = New System.Windows.Forms.TableLayoutPanel()
        Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbcEarning = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tbpMain = New System.Windows.Forms.TabPage()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbpCalculation = New System.Windows.Forms.TabPage()
        Me.floCalculation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpCalculation = New System.Windows.Forms.TableLayoutPanel()
        Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblFactoredUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblMultiplier = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCalculationType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblBasePayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboBasePaymentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblIncludeInGosi = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkIncludeInPension = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblIncludeInEos = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkIncludeInEOS = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.txtMultiplier = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboMultiplierType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.chkTaxable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblTaxable = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
        Me.floPostingAccounts = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tloPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.tlpEarning.SuspendLayout
        Me.tbcEarning.SuspendLayout
        Me.tbpMain.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbpCalculation.SuspendLayout
        Me.floCalculation.SuspendLayout
        Me.tlpCalculation.SuspendLayout
        Me.tbpAccountPosting.SuspendLayout
        Me.floPostingAccounts.SuspendLayout
        Me.tloPostingAccounts.SuspendLayout
        CType(Me.DataGridViewPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
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
        Me.tlpEarning.Controls.Add(Me.txtEarningNameAra, 1, 2)
        Me.tlpEarning.Controls.Add(Me.lblName, 0, 1)
        Me.tlpEarning.Controls.Add(Me.txtEarningCode, 3, 0)
        Me.tlpEarning.Controls.Add(Me.lblCode, 2, 0)
        Me.tlpEarning.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.tlpEarning.Controls.Add(Me.CLabel1, 0, 0)
        Me.tlpEarning.Controls.Add(Me.txtEarningName, 1, 1)
        Me.tlpEarning.Controls.Add(Me.lblNameAra, 0, 2)
        Me.tlpEarning.Name = "tlpEarning"
        '
        'txtEarningNameAra
        '
        Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
        Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpEarning.SetColumnSpan(Me.txtEarningNameAra, 3)
        Me.txtEarningNameAra.ComputedValue = false
        Me.txtEarningNameAra.CustomFormat = Nothing
        Me.txtEarningNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtEarningNameAra, "txtEarningNameAra")
        Me.txtEarningNameAra.EditingMode = false
        Me.txtEarningNameAra.EnglishControl = Me.txtEarningName
        Me.txtEarningNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtEarningNameAra.LinkedLabel = Nothing
        Me.txtEarningNameAra.MaximumValue = Nothing
        Me.txtEarningNameAra.MinimumValue = Nothing
        Me.txtEarningNameAra.Name = "txtEarningNameAra"
        Me.txtEarningNameAra.OldValue = Nothing
        Me.txtEarningNameAra.ReadOnly = true
        '
        'txtEarningName
        '
        Me.txtEarningName.BackColor = System.Drawing.Color.White
        Me.txtEarningName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpEarning.SetColumnSpan(Me.txtEarningName, 3)
        Me.txtEarningName.ComputedValue = false
        Me.txtEarningName.CustomFormat = Nothing
        Me.txtEarningName.DataBoundControl = true
        resources.ApplyResources(Me.txtEarningName, "txtEarningName")
        Me.txtEarningName.EditingMode = false
        Me.txtEarningName.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtEarningName, CType(resources.GetObject("txtEarningName.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtEarningName.LinkedLabel = Nothing
        Me.txtEarningName.MaximumValue = Nothing
        Me.txtEarningName.MinimumValue = Nothing
        Me.txtEarningName.Name = "txtEarningName"
        Me.txtEarningName.OldValue = Nothing
        Me.txtEarningName.ReadOnly = true
        Me.txtEarningName.ValueIsMandatory = true
        '
        'lblName
        '
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'txtEarningCode
        '
        Me.txtEarningCode.BackColor = System.Drawing.Color.White
        Me.txtEarningCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEarningCode.ComputedValue = false
        Me.txtEarningCode.CustomFormat = Nothing
        Me.txtEarningCode.DataBoundControl = true
        Me.txtEarningCode.EditingMode = true
        resources.ApplyResources(Me.txtEarningCode, "txtEarningCode")
        Me.txtEarningCode.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconPadding"),Integer))
        Me.txtEarningCode.LinkedLabel = Nothing
        Me.txtEarningCode.MaximumValue = Nothing
        Me.txtEarningCode.MinimumValue = Nothing
        Me.txtEarningCode.Name = "txtEarningCode"
        Me.txtEarningCode.OldValue = Nothing
        Me.txtEarningCode.ReadOnly = true
        Me.txtEarningCode.ValueIsMandatory = true
        '
        'lblCode
        '
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.Name = "lblCode"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'lblNameAra
        '
        Me.lblNameAra.DisplayOnly = true
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.lblNameAra.EditingMode = false
        Me.lblNameAra.Name = "lblNameAra"
        '
        'tbcEarning
        '
        Me.tbcEarning.Controls.Add(Me.tbpMain)
        Me.tbcEarning.Controls.Add(Me.tbpCalculation)
        Me.tbcEarning.Controls.Add(Me.tbpAccountPosting)
        resources.ApplyResources(Me.tbcEarning, "tbcEarning")
        Me.tbcEarning.Name = "tbcEarning"
        Me.tbcEarning.SelectedIndex = 0
        '
        'tbpMain
        '
        Me.tbpMain.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        resources.ApplyResources(Me.tbpMain, "tbpMain")
        Me.tbpMain.Controls.Add(Me.CFlowLayout1)
        Me.tbpMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbpMain.Name = "tbpMain"
        Me.tbpMain.UseVisualStyleBackColor = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
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
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = false
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'tbpCalculation
        '
        Me.tbpCalculation.Controls.Add(Me.floCalculation)
        resources.ApplyResources(Me.tbpCalculation, "tbpCalculation")
        Me.tbpCalculation.Name = "tbpCalculation"
        Me.tbpCalculation.UseVisualStyleBackColor = true
        '
        'floCalculation
        '
        Me.floCalculation.BackColor = System.Drawing.Color.Transparent
        Me.floCalculation.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        resources.ApplyResources(Me.floCalculation, "floCalculation")
        Me.floCalculation.Controls.Add(Me.tlpCalculation)
        Me.floCalculation.Name = "floCalculation"
        '
        'tlpCalculation
        '
        resources.ApplyResources(Me.tlpCalculation, "tlpCalculation")
        Me.tlpCalculation.Controls.Add(Me.lblFactoredUnit, 0, 3)
        Me.tlpCalculation.Controls.Add(Me.CLabel2, 0, 0)
        Me.tlpCalculation.Controls.Add(Me.lblMultiplier, 0, 6)
        Me.tlpCalculation.Controls.Add(Me.lblDefaultQuantity, 0, 4)
        Me.tlpCalculation.Controls.Add(Me.lblCalculationType, 0, 1)
        Me.tlpCalculation.Controls.Add(Me.cboCalculationType, 1, 1)
        Me.tlpCalculation.Controls.Add(Me.txtRate, 1, 2)
        Me.tlpCalculation.Controls.Add(Me.txtDefaultQuantity, 1, 4)
        Me.tlpCalculation.Controls.Add(Me.lblBasePayment, 0, 5)
        Me.tlpCalculation.Controls.Add(Me.cboBasePaymentIdNo, 1, 5)
        Me.tlpCalculation.Controls.Add(Me.lblIncludeInGosi, 0, 8)
        Me.tlpCalculation.Controls.Add(Me.chkIncludeInPension, 1, 8)
        Me.tlpCalculation.Controls.Add(Me.lblIncludeInEos, 0, 7)
        Me.tlpCalculation.Controls.Add(Me.chkIncludeInEOS, 1, 7)
        Me.tlpCalculation.Controls.Add(Me.txtMultiplier, 1, 6)
        Me.tlpCalculation.Controls.Add(Me.cboMultiplierType, 2, 6)
        Me.tlpCalculation.Controls.Add(Me.chkTaxable, 2, 9)
        Me.tlpCalculation.Controls.Add(Me.lblTaxable, 0, 9)
        Me.tlpCalculation.Controls.Add(Me.lblPayRate, 2, 2)
        Me.tlpCalculation.Controls.Add(Me.lblRate, 0, 2)
        Me.tlpCalculation.Controls.Add(Me.cboUnit, 3, 2)
        Me.tlpCalculation.Controls.Add(Me.cboEarningType, 1, 0)
        Me.tlpCalculation.Name = "tlpCalculation"
        '
        'lblRate
        '
        resources.ApplyResources(Me.lblRate, "lblRate")
        Me.lblRate.DisplayOnly = true
        Me.lblRate.EditingMode = false
        Me.lblRate.Name = "lblRate"
        '
        'lblFactoredUnit
        '
        resources.ApplyResources(Me.lblFactoredUnit, "lblFactoredUnit")
        Me.lblFactoredUnit.DisplayOnly = true
        Me.lblFactoredUnit.EditingMode = false
        Me.lblFactoredUnit.Name = "lblFactoredUnit"
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        '
        'lblMultiplier
        '
        resources.ApplyResources(Me.lblMultiplier, "lblMultiplier")
        Me.lblMultiplier.DisplayOnly = true
        Me.lblMultiplier.EditingMode = false
        Me.lblMultiplier.Name = "lblMultiplier"
        '
        'lblDefaultQuantity
        '
        resources.ApplyResources(Me.lblDefaultQuantity, "lblDefaultQuantity")
        Me.lblDefaultQuantity.DisplayOnly = true
        Me.lblDefaultQuantity.EditingMode = false
        Me.lblDefaultQuantity.Name = "lblDefaultQuantity"
        '
        'lblCalculationType
        '
        resources.ApplyResources(Me.lblCalculationType, "lblCalculationType")
        Me.lblCalculationType.DisplayOnly = true
        Me.lblCalculationType.EditingMode = false
        Me.lblCalculationType.Name = "lblCalculationType"
        '
        'cboCalculationType
        '
        Me.cboCalculationType.BackColor = System.Drawing.Color.White
        Me.cboCalculationType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboCalculationType, 3)
        Me.cboCalculationType.CurrentSearchTerm = ""
        Me.cboCalculationType.DefaultValue = Nothing
        Me.cboCalculationType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
        Me.cboCalculationType.DropDownHeight = 200
        Me.cboCalculationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalculationType.EditingMode = true
        Me.cboCalculationType.FilterRule = Nothing
        Me.cboCalculationType.ForeColor = System.Drawing.Color.Black
        Me.cboCalculationType.FormattingEnabled = true
        Me.cboCalculationType.HideWhenNotEditingOrAdding = false
        Me.cboCalculationType.LinkedLabel = Me.lblCalculationType
        Me.cboCalculationType.Name = "cboCalculationType"
        Me.cboCalculationType.OldValue = 0
        Me.cboCalculationType.OriginalDataSource = Nothing
        Me.cboCalculationType.OriginalList = Nothing
        Me.cboCalculationType.OverrideDropDownStyleList = false
        Me.cboCalculationType.PreviousSearchTerm = Nothing
        Me.cboCalculationType.PreviousSelectedIndex = -1
        Me.cboCalculationType.PropertySelector = Nothing
        Me.cboCalculationType.ReadOnlyCombo = false
        Me.cboCalculationType.SearchAnywhere = false
        Me.cboCalculationType.SuggestBoxHeight = 200
        Me.cboCalculationType.SuggestListOrderRule = Nothing
        Me.cboCalculationType.TextToSearch = Nothing
        Me.cboCalculationType.ValueIsMandatory = false
        Me.cboCalculationType.ValueIsNullable = false
        Me.cboCalculationType.ValueIsNumeric = false
        Me.cboCalculationType.ValueMember = "Code"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.White
        Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRate.ComputedValue = false
        Me.txtRate.CustomFormat = Nothing
        Me.txtRate.DataBoundControl = true
        resources.ApplyResources(Me.txtRate, "txtRate")
        Me.txtRate.EditingMode = true
        Me.txtRate.ForeColor = System.Drawing.Color.Black
        Me.txtRate.LinkedLabel = Nothing
        Me.txtRate.MaximumValue = Nothing
        Me.txtRate.MinimumValue = Nothing
        Me.txtRate.Name = "txtRate"
        Me.txtRate.OldValue = Nothing
        '
        'txtDefaultQuantity
        '
        Me.txtDefaultQuantity.BackColor = System.Drawing.Color.White
        Me.txtDefaultQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDefaultQuantity.ComputedValue = false
        Me.txtDefaultQuantity.CustomFormat = Nothing
        Me.txtDefaultQuantity.DataBoundControl = true
        resources.ApplyResources(Me.txtDefaultQuantity, "txtDefaultQuantity")
        Me.txtDefaultQuantity.EditingMode = true
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
        Me.lblBasePayment.DisplayOnly = true
        Me.lblBasePayment.EditingMode = false
        Me.lblBasePayment.Name = "lblBasePayment"
        '
        'cboBasePaymentIdNo
        '
        Me.cboBasePaymentIdNo.BackColor = System.Drawing.Color.White
        Me.cboBasePaymentIdNo.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
        Me.cboBasePaymentIdNo.CurrentSearchTerm = ""
        Me.cboBasePaymentIdNo.DefaultValue = Nothing
        Me.cboBasePaymentIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboBasePaymentIdNo, "cboBasePaymentIdNo")
        Me.cboBasePaymentIdNo.DropDownHeight = 200
        Me.cboBasePaymentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBasePaymentIdNo.EditingMode = true
        Me.cboBasePaymentIdNo.FilterRule = Nothing
        Me.cboBasePaymentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBasePaymentIdNo.FormattingEnabled = true
        Me.cboBasePaymentIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBasePaymentIdNo.LinkedLabel = Me.lblBasePayment
        Me.cboBasePaymentIdNo.Name = "cboBasePaymentIdNo"
        Me.cboBasePaymentIdNo.OldValue = 0
        Me.cboBasePaymentIdNo.OriginalDataSource = Nothing
        Me.cboBasePaymentIdNo.OriginalList = Nothing
        Me.cboBasePaymentIdNo.OverrideDropDownStyleList = false
        Me.cboBasePaymentIdNo.PreviousSearchTerm = Nothing
        Me.cboBasePaymentIdNo.PreviousSelectedIndex = -1
        Me.cboBasePaymentIdNo.PropertySelector = Nothing
        Me.cboBasePaymentIdNo.ReadOnlyCombo = false
        Me.cboBasePaymentIdNo.SearchAnywhere = false
        Me.cboBasePaymentIdNo.SuggestBoxHeight = 200
        Me.cboBasePaymentIdNo.SuggestListOrderRule = Nothing
        Me.cboBasePaymentIdNo.TextToSearch = Nothing
        Me.cboBasePaymentIdNo.ValueIsMandatory = false
        Me.cboBasePaymentIdNo.ValueIsNullable = false
        Me.cboBasePaymentIdNo.ValueIsNumeric = false
        Me.cboBasePaymentIdNo.ValueMember = "IdNo"
        '
        'lblIncludeInGosi
        '
        resources.ApplyResources(Me.lblIncludeInGosi, "lblIncludeInGosi")
        Me.tlpCalculation.SetColumnSpan(Me.lblIncludeInGosi, 2)
        Me.lblIncludeInGosi.DisplayOnly = true
        Me.lblIncludeInGosi.EditingMode = false
        Me.lblIncludeInGosi.Name = "lblIncludeInGosi"
        '
        'chkIncludeInPension
        '
        resources.ApplyResources(Me.chkIncludeInPension, "chkIncludeInPension")
        Me.chkIncludeInPension.BackColor = System.Drawing.Color.White
        Me.chkIncludeInPension.DisplayOnly = false
        Me.chkIncludeInPension.EditingMode = true
        Me.chkIncludeInPension.FlatAppearance.BorderSize = 0
        Me.chkIncludeInPension.ForeColor = System.Drawing.Color.Black
        Me.chkIncludeInPension.LinkedLabel = Me.lblIncludeInGosi
        Me.chkIncludeInPension.Name = "chkIncludeInPension"
        Me.chkIncludeInPension.NoLabel = true
        Me.chkIncludeInPension.OldValue = Nothing
        Me.chkIncludeInPension.UseVisualStyleBackColor = true
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
        Me.chkIncludeInEOS.DisplayOnly = false
        Me.chkIncludeInEOS.EditingMode = true
        Me.chkIncludeInEOS.FlatAppearance.BorderSize = 0
        Me.chkIncludeInEOS.ForeColor = System.Drawing.Color.Black
        Me.chkIncludeInEOS.LinkedLabel = Me.lblIncludeInEos
        Me.chkIncludeInEOS.Name = "chkIncludeInEOS"
        Me.chkIncludeInEOS.NoLabel = true
        Me.chkIncludeInEOS.OldValue = Nothing
        Me.chkIncludeInEOS.UseVisualStyleBackColor = true
        '
        'txtMultiplier
        '
        Me.txtMultiplier.BackColor = System.Drawing.Color.White
        Me.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier.ComputedValue = false
        Me.txtMultiplier.CustomFormat = Nothing
        Me.txtMultiplier.DataBoundControl = true
        resources.ApplyResources(Me.txtMultiplier, "txtMultiplier")
        Me.txtMultiplier.EditingMode = true
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
        Me.cboMultiplierType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboMultiplierType, 2)
        Me.cboMultiplierType.CurrentSearchTerm = ""
        Me.cboMultiplierType.DefaultValue = Nothing
        Me.cboMultiplierType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboMultiplierType, "cboMultiplierType")
        Me.cboMultiplierType.DropDownHeight = 200
        Me.cboMultiplierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMultiplierType.EditingMode = true
        Me.cboMultiplierType.FilterRule = Nothing
        Me.cboMultiplierType.ForeColor = System.Drawing.Color.Black
        Me.cboMultiplierType.FormattingEnabled = true
        Me.cboMultiplierType.HideWhenNotEditingOrAdding = false
        Me.cboMultiplierType.LinkedLabel = Nothing
        Me.cboMultiplierType.Name = "cboMultiplierType"
        Me.cboMultiplierType.OldValue = 0
        Me.cboMultiplierType.OriginalDataSource = Nothing
        Me.cboMultiplierType.OriginalList = Nothing
        Me.cboMultiplierType.OverrideDropDownStyleList = false
        Me.cboMultiplierType.PreviousSearchTerm = Nothing
        Me.cboMultiplierType.PreviousSelectedIndex = -1
        Me.cboMultiplierType.PropertySelector = Nothing
        Me.cboMultiplierType.ReadOnlyCombo = false
        Me.cboMultiplierType.SearchAnywhere = false
        Me.cboMultiplierType.SuggestBoxHeight = 200
        Me.cboMultiplierType.SuggestListOrderRule = Nothing
        Me.cboMultiplierType.TextToSearch = Nothing
        Me.cboMultiplierType.ValueIsMandatory = false
        Me.cboMultiplierType.ValueIsNullable = false
        Me.cboMultiplierType.ValueIsNumeric = false
        Me.cboMultiplierType.ValueMember = "Code"
        '
        'chkTaxable
        '
        resources.ApplyResources(Me.chkTaxable, "chkTaxable")
        Me.chkTaxable.BackColor = System.Drawing.Color.White
        Me.chkTaxable.DisplayOnly = false
        Me.chkTaxable.EditingMode = true
        Me.chkTaxable.FlatAppearance.BorderSize = 0
        Me.chkTaxable.ForeColor = System.Drawing.Color.Black
        Me.chkTaxable.LinkedLabel = Me.lblTaxable
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.NoLabel = true
        Me.chkTaxable.OldValue = Nothing
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
        'lblPayRate
        '
        resources.ApplyResources(Me.lblPayRate, "lblPayRate")
        Me.lblPayRate.DisplayOnly = true
        Me.lblPayRate.EditingMode = false
        Me.lblPayRate.Name = "lblPayRate"
        '
        'cboUnit
        '
        Me.cboUnit.BackColor = System.Drawing.Color.White
        Me.cboUnit.ChangingSearchValueOnly = false
        Me.cboUnit.CurrentSearchTerm = ""
        Me.cboUnit.DefaultValue = Nothing
        Me.cboUnit.DisplayMember = "Name"
        resources.ApplyResources(Me.cboUnit, "cboUnit")
        Me.cboUnit.DropDownHeight = 200
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.EditingMode = true
        Me.cboUnit.FilterRule = Nothing
        Me.cboUnit.ForeColor = System.Drawing.Color.Black
        Me.cboUnit.FormattingEnabled = true
        Me.cboUnit.HideWhenNotEditingOrAdding = false
        Me.cboUnit.LinkedLabel = Me.lblRate
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.OldValue = 0
        Me.cboUnit.OriginalDataSource = Nothing
        Me.cboUnit.OriginalList = Nothing
        Me.cboUnit.OverrideDropDownStyleList = false
        Me.cboUnit.PreviousSearchTerm = Nothing
        Me.cboUnit.PreviousSelectedIndex = -1
        Me.cboUnit.PropertySelector = Nothing
        Me.cboUnit.ReadOnlyCombo = false
        Me.cboUnit.SearchAnywhere = false
        Me.cboUnit.SuggestBoxHeight = 200
        Me.cboUnit.SuggestListOrderRule = Nothing
        Me.cboUnit.TextToSearch = Nothing
        Me.cboUnit.ValueIsMandatory = false
        Me.cboUnit.ValueIsNullable = false
        Me.cboUnit.ValueIsNumeric = false
        Me.cboUnit.ValueMember = "Code"
        '
        'cboEarningType
        '
        Me.cboEarningType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEarningType.BackColor = System.Drawing.Color.White
        Me.cboEarningType.ChangingSearchValueOnly = false
        Me.tlpCalculation.SetColumnSpan(Me.cboEarningType, 3)
        Me.cboEarningType.CurrentSearchTerm = ""
        Me.cboEarningType.DefaultValue = ""
        Me.cboEarningType.DisplayMember = "Name"
        resources.ApplyResources(Me.cboEarningType, "cboEarningType")
        Me.cboEarningType.DropDownHeight = 1
        Me.cboEarningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEarningType.EditingMode = false
        Me.cboEarningType.FilterRule = Nothing
        Me.cboEarningType.ForeColor = System.Drawing.Color.Black
        Me.cboEarningType.HideWhenNotEditingOrAdding = false
        Me.cboEarningType.LinkedLabel = Nothing
        Me.cboEarningType.Name = "cboEarningType"
        Me.cboEarningType.OldValue = 0
        Me.cboEarningType.OriginalDataSource = Nothing
        Me.cboEarningType.OriginalList = Nothing
        Me.cboEarningType.OverrideDropDownStyleList = false
        Me.cboEarningType.PreviousSearchTerm = Nothing
        Me.cboEarningType.PreviousSelectedIndex = 0
        Me.cboEarningType.PropertySelector = Nothing
        Me.cboEarningType.ReadOnlyCombo = false
        Me.cboEarningType.SearchAnywhere = false
        Me.cboEarningType.SuggestBoxHeight = 200
        Me.cboEarningType.SuggestListOrderRule = Nothing
        Me.cboEarningType.TextToSearch = Nothing
        Me.cboEarningType.ValueIsMandatory = false
        Me.cboEarningType.ValueIsNullable = false
        Me.cboEarningType.ValueIsNumeric = false
        Me.cboEarningType.ValueMember = "Code"
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
        Me.floPostingAccounts.Controls.Add(Me.tloPostingAccounts)
        resources.ApplyResources(Me.floPostingAccounts, "floPostingAccounts")
        Me.floPostingAccounts.Name = "floPostingAccounts"
        '
        'tloPostingAccounts
        '
        resources.ApplyResources(Me.tloPostingAccounts, "tloPostingAccounts")
        Me.tloPostingAccounts.Controls.Add(Me.lblAccountIdNo, 0, 1)
        Me.tloPostingAccounts.Controls.Add(Me.cboAccountIdNo, 1, 1)
        Me.tloPostingAccounts.Controls.Add(Me.DataGridViewPayrollEarnAccounts, 0, 2)
        Me.tloPostingAccounts.Controls.Add(Me.lblUsePayGroups, 0, 0)
        Me.tloPostingAccounts.Controls.Add(Me.chkUsePayGroups, 2, 0)
        Me.tloPostingAccounts.Name = "tloPostingAccounts"
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
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.tloPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = Nothing
        Me.cboAccountIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
        Me.cboAccountIdNo.DropDownHeight = 1
        Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.FormattingEnabled = true
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PreviousSelectedIndex = -1
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.SearchAnywhere = false
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'DataGridViewPayrollEarnAccounts
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayrollEarnAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPayrollEarnAccounts.AutoGenerateColumns = false
        Me.DataGridViewPayrollEarnAccounts.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewPayrollEarnAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayrollEarnAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.EarningIdNoDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
        Me.tloPostingAccounts.SetColumnSpan(Me.DataGridViewPayrollEarnAccounts, 3)
            Me.DataGridViewPayrollEarnAccounts.DataSource = Me.bsPayrollEarnAccounts
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayrollEarnAccounts.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewPayrollEarnAccounts.DgvFooter = Nothing
        Me.DataGridViewPayrollEarnAccounts.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewPayrollEarnAccounts, "DataGridViewPayrollEarnAccounts")
        Me.DataGridViewPayrollEarnAccounts.Ea = EventAggregator1
        Me.DataGridViewPayrollEarnAccounts.EditingMode = false
        Me.DataGridViewPayrollEarnAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayrollEarnAccounts.FirstRowDeletionEnabled = true
        Me.DataGridViewPayrollEarnAccounts.FirstRowInsertionEnabled = true
        Me.DataGridViewPayrollEarnAccounts.Name = "DataGridViewPayrollEarnAccounts"
        Me.DataGridViewPayrollEarnAccounts.ReadOnly = true
        Me.DataGridViewPayrollEarnAccounts.SequenceColumn = "dgvSequence"
        Me.DataGridViewPayrollEarnAccounts.SequenceFieldName = "Sequence"
        Me.DataGridViewPayrollEarnAccounts.ShowFooter = false
        Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = True
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvPayGroupIdNo
        '
        Me.dgvPayGroupIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
        Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
        Me.dgvPayGroupIdNo.ReadOnly = true
        Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        '
        'lblUsePayGroups
        '
        resources.ApplyResources(Me.lblUsePayGroups, "lblUsePayGroups")
        Me.tloPostingAccounts.SetColumnSpan(Me.lblUsePayGroups, 2)
        Me.lblUsePayGroups.DisplayOnly = true
        Me.lblUsePayGroups.EditingMode = false
        Me.lblUsePayGroups.Name = "lblUsePayGroups"
        '
        'chkUsePayGroups
        '
        Me.chkUsePayGroups.BackColor = System.Drawing.Color.White
        Me.chkUsePayGroups.DisplayOnly = false
        Me.chkUsePayGroups.EditingMode = true
        Me.chkUsePayGroups.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.chkUsePayGroups, "chkUsePayGroups")
        Me.chkUsePayGroups.ForeColor = System.Drawing.Color.Black
        Me.chkUsePayGroups.LinkedLabel = Me.lblUsePayGroups
        Me.chkUsePayGroups.Name = "chkUsePayGroups"
        Me.chkUsePayGroups.NoLabel = true
        Me.chkUsePayGroups.OldValue = Nothing
        Me.chkUsePayGroups.UseVisualStyleBackColor = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'EarningIdNoDataGridViewTextBoxColumn
        '
        Me.EarningIdNoDataGridViewTextBoxColumn.DataPropertyName = "EarningIdNo"
        resources.ApplyResources(Me.EarningIdNoDataGridViewTextBoxColumn, "EarningIdNoDataGridViewTextBoxColumn")
        Me.EarningIdNoDataGridViewTextBoxColumn.Name = "EarningIdNoDataGridViewTextBoxColumn"
        Me.EarningIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'PayGroupNameDataGridViewTextBoxColumn
        '
        Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
        resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
        Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
        Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'bsPayrollEarnAccounts
        '
        Me.bsPayrollEarnAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollEarnAccountModel)
        '
        'EarningEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "EarningEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.tlpEarning.ResumeLayout(false)
        Me.tlpEarning.PerformLayout
        Me.tbcEarning.ResumeLayout(false)
        Me.tbpMain.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbpCalculation.ResumeLayout(false)
        Me.floCalculation.ResumeLayout(false)
        Me.tlpCalculation.ResumeLayout(false)
        Me.tlpCalculation.PerformLayout
        Me.tbpAccountPosting.ResumeLayout(false)
        Me.floPostingAccounts.ResumeLayout(false)
        Me.tloPostingAccounts.ResumeLayout(false)
        Me.tloPostingAccounts.PerformLayout
        CType(Me.DataGridViewPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents CFlowLayout1 As CFlowLayout
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
        Friend WithEvents cboCalculationType As CaComboBox
        Friend WithEvents txtRate As CTextBox
        Friend WithEvents txtDefaultQuantity As CTextBox
        Friend WithEvents lblBasePayment As CLabel
        Friend WithEvents cboBasePaymentIdNo As CaComboBox
        Friend WithEvents lblIncludeInGosi As CLabel
        Friend WithEvents chkIncludeInPension As CCheckBox
        Friend WithEvents lblIncludeInEos As CLabel
        Friend WithEvents chkIncludeInEOS As CCheckBox
        Friend WithEvents txtMultiplier As CTextBox
        Friend WithEvents cboMultiplierType As CaComboBox
        Friend WithEvents cboUnit As CaComboBox
        Friend WithEvents lblPayRate As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents floPostingAccounts As CFlowLayout
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents chkTaxable As CCheckBox
        Friend WithEvents lblTaxable As CLabel
        Friend WithEvents tloPostingAccounts As TableLayoutPanel
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
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblFactoredUnit As CLabel
    End Class
End Namespace