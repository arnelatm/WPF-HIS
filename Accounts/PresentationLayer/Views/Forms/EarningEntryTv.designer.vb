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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.lblPostToSingleAccount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPostToSingleAccount = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.tbpCalculation = New System.Windows.Forms.TabPage()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMultiplier = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDefaultQty = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.TableLayoutPanel3.SuspendLayout
        Me.tbcEarning.SuspendLayout
        Me.tbpMain.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbpCalculation.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.tbpAccountPosting.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.TableLayoutPanel4.SuspendLayout
        CType(Me.DataGridViewPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
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
        'bsPayrollEarnAccounts
        '
        Me.bsPayrollEarnAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollEarnAccountModel)
        '
        'CFlowLayout4
        '
        Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout4.Controls.Add(Me.TableLayoutPanel3)
        Me.CFlowLayout4.Controls.Add(Me.tbcEarning)
        resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
        Me.CFlowLayout4.Name = "CFlowLayout4"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.txtEarningNameAra, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblName, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtEarningCode, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCode, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CLabel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtEarningName, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblNameAra, 0, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'txtEarningNameAra
        '
        Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
        Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtEarningNameAra, 3)
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
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtEarningName, 3)
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
        Me.lblNameAra.EditingMode = false
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblPostToSingleAccount, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboAccountIdNo, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAccountIdNo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboEarningType, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEarningType, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPostToSingleAccount, 1, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'lblPostToSingleAccount
        '
        Me.lblPostToSingleAccount.DisplayOnly = true
        resources.ApplyResources(Me.lblPostToSingleAccount, "lblPostToSingleAccount")
        Me.lblPostToSingleAccount.EditingMode = false
        Me.lblPostToSingleAccount.Name = "lblPostToSingleAccount"
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
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 2)
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
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
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
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        '
        'cboEarningType
        '
        Me.cboEarningType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEarningType.BackColor = System.Drawing.Color.White
        Me.cboEarningType.ChangingSearchValueOnly = false
        Me.cboEarningType.CurrentSearchTerm = ""
        Me.cboEarningType.DefaultValue = ""
        Me.cboEarningType.DisplayMember = "Name"
        Me.cboEarningType.DropDownHeight = 1
        Me.cboEarningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEarningType.EditingMode = false
        Me.cboEarningType.FilterRule = Nothing
        resources.ApplyResources(Me.cboEarningType, "cboEarningType")
        Me.cboEarningType.ForeColor = System.Drawing.Color.Black
        Me.cboEarningType.HideWhenNotEditingOrAdding = false
        Me.cboEarningType.LinkedLabel = Me.lblEarningType
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
        'lblEarningType
        '
        Me.lblEarningType.DisplayOnly = true
        Me.lblEarningType.EditingMode = false
        resources.ApplyResources(Me.lblEarningType, "lblEarningType")
        Me.lblEarningType.Name = "lblEarningType"
        '
        'chkPostToSingleAccount
        '
        Me.chkPostToSingleAccount.BackColor = System.Drawing.Color.White
        Me.chkPostToSingleAccount.DisplayOnly = false
        Me.chkPostToSingleAccount.EditingMode = true
        Me.chkPostToSingleAccount.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.chkPostToSingleAccount, "chkPostToSingleAccount")
        Me.chkPostToSingleAccount.ForeColor = System.Drawing.Color.Black
        Me.chkPostToSingleAccount.LinkedLabel = Me.lblPostToSingleAccount
        Me.chkPostToSingleAccount.Name = "chkPostToSingleAccount"
        Me.chkPostToSingleAccount.NoLabel = true
        Me.chkPostToSingleAccount.OldValue = Nothing
        Me.chkPostToSingleAccount.UseVisualStyleBackColor = true
        '
        'tbpCalculation
        '
        Me.tbpCalculation.Controls.Add(Me.CFlowLayout3)
        resources.ApplyResources(Me.tbpCalculation, "tbpCalculation")
        Me.tbpCalculation.Name = "tbpCalculation"
        Me.tbpCalculation.UseVisualStyleBackColor = true
        '
        'CFlowLayout3
        '
        Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout3.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        resources.ApplyResources(Me.CFlowLayout3, "CFlowLayout3")
        Me.CFlowLayout3.Controls.Add(Me.TableLayoutPanel2)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.lblMultiplier, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDefaultQty, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblRate, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCalculationType, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCalculationType, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtRate, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDefaultQuantity, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblBasePayment, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cboBasePaymentIdNo, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblIncludeInGosi, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.chkIncludeInPension, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblIncludeInEos, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.chkIncludeInEOS, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMultiplier, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.cboMultiplierType, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.chkTaxable, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.cboUnit, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPayRate, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTaxable, 0, 8)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'lblMultiplier
        '
        resources.ApplyResources(Me.lblMultiplier, "lblMultiplier")
        Me.lblMultiplier.DisplayOnly = true
        Me.lblMultiplier.EditingMode = false
        Me.lblMultiplier.Name = "lblMultiplier"
        '
        'lblDefaultQty
        '
        resources.ApplyResources(Me.lblDefaultQty, "lblDefaultQty")
        Me.lblDefaultQty.DisplayOnly = true
        Me.lblDefaultQty.EditingMode = false
        Me.lblDefaultQty.Name = "lblDefaultQty"
        '
        'lblRate
        '
        resources.ApplyResources(Me.lblRate, "lblRate")
        Me.lblRate.DisplayOnly = true
        Me.lblRate.EditingMode = false
        Me.lblRate.Name = "lblRate"
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboCalculationType, 3)
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
        Me.txtDefaultQuantity.LinkedLabel = Me.lblDefaultQty
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.lblIncludeInGosi, 2)
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.lblIncludeInEos, 2)
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboMultiplierType, 2)
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
        Me.TableLayoutPanel2.SetColumnSpan(Me.lblTaxable, 2)
        Me.lblTaxable.DisplayOnly = true
        Me.lblTaxable.EditingMode = false
        Me.lblTaxable.Name = "lblTaxable"
        '
        'cboUnit
        '
        Me.cboUnit.BackColor = System.Drawing.Color.White
        Me.cboUnit.ChangingSearchValueOnly = false
        Me.cboUnit.CurrentSearchTerm = ""
        Me.cboUnit.DefaultValue = Nothing
        Me.cboUnit.DisplayMember = "Name"
        Me.cboUnit.DropDownHeight = 200
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.EditingMode = true
        Me.cboUnit.FilterRule = Nothing
        resources.ApplyResources(Me.cboUnit, "cboUnit")
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
        'lblPayRate
        '
        resources.ApplyResources(Me.lblPayRate, "lblPayRate")
        Me.lblPayRate.DisplayOnly = true
        Me.lblPayRate.EditingMode = false
        Me.lblPayRate.Name = "lblPayRate"
        '
        'tbpAccountPosting
        '
        Me.tbpAccountPosting.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
        resources.ApplyResources(Me.tbpAccountPosting, "tbpAccountPosting")
        Me.tbpAccountPosting.Controls.Add(Me.CFlowLayout2)
        Me.tbpAccountPosting.Name = "tbpAccountPosting"
        Me.tbpAccountPosting.UseVisualStyleBackColor = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel4)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.DataGridViewPayrollEarnAccounts, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CLabel2, 0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'DataGridViewPayrollEarnAccounts
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayrollEarnAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewPayrollEarnAccounts.AutoGenerateColumns = false
        Me.DataGridViewPayrollEarnAccounts.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewPayrollEarnAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayrollEarnAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.EarningIdNoDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
        Me.TableLayoutPanel4.SetColumnSpan(Me.DataGridViewPayrollEarnAccounts, 2)
        Me.DataGridViewPayrollEarnAccounts.DataInGridChanged = false
        Me.DataGridViewPayrollEarnAccounts.DataSource = Me.bsPayrollEarnAccounts
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayrollEarnAccounts.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewPayrollEarnAccounts.DgvFooter = Nothing
        Me.DataGridViewPayrollEarnAccounts.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewPayrollEarnAccounts, "DataGridViewPayrollEarnAccounts")
        Me.DataGridViewPayrollEarnAccounts.Ea = EventAggregator2
        Me.DataGridViewPayrollEarnAccounts.EditingMode = false
        Me.DataGridViewPayrollEarnAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayrollEarnAccounts.FirstRowDeletionEnabled = true
        Me.DataGridViewPayrollEarnAccounts.FirstRowInsertionEnabled = true
        Me.DataGridViewPayrollEarnAccounts.Name = "DataGridViewPayrollEarnAccounts"
        Me.DataGridViewPayrollEarnAccounts.ReadOnly = true
        Me.DataGridViewPayrollEarnAccounts.SequenceColumn = "dgvSequence"
        Me.DataGridViewPayrollEarnAccounts.SequenceFieldName = "Sequence"
        Me.DataGridViewPayrollEarnAccounts.ShowFooter = false
        Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = true
        Me.DataGridViewPayrollEarnAccounts.StartTrackingChanges = false
        '
        'dgvSequence
        '
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
        Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
        Me.dgvPayGroupIdNo.ReadOnly = true
        Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle9
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
        'CLabel2
        '
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Name = "CLabel2"
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.TableLayoutPanel3.ResumeLayout(false)
        Me.TableLayoutPanel3.PerformLayout
        Me.tbcEarning.ResumeLayout(false)
        Me.tbpMain.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbpCalculation.ResumeLayout(false)
        Me.CFlowLayout3.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.tbpAccountPosting.ResumeLayout(false)
        Me.CFlowLayout2.ResumeLayout(false)
        Me.TableLayoutPanel4.ResumeLayout(false)
        Me.TableLayoutPanel4.PerformLayout
        CType(Me.DataGridViewPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsPayrollEarnAccounts As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
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
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents tbpCalculation As TabPage
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents lblMultiplier As CLabel
        Friend WithEvents lblDefaultQty As CLabel
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
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents chkTaxable As CCheckBox
        Friend WithEvents lblTaxable As CLabel
        Friend WithEvents lblPostToSingleAccount As CLabel
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents chkPostToSingleAccount As CCheckBox
        Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel2 As CLabel
    End Class
End Namespace