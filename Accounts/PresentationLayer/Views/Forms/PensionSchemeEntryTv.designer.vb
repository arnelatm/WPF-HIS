Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PensionSchemeEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PensionSchemeEntryTv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bsPensionRates = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpPensionScheme = New System.Windows.Forms.TableLayoutPanel()
        Me.tbcPensionScheme = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tbpMain = New System.Windows.Forms.TabPage()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpMainTab = New System.Windows.Forms.TableLayoutPanel()
        Me.cboPensionProviderIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPensionProviderIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbpPensionRates = New System.Windows.Forms.TabPage()
        Me.tlpPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.txtPensionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtPensionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPensionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPensionRates,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.tlpPensionScheme.SuspendLayout
        Me.tbcPensionScheme.SuspendLayout
        Me.tbpMain.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.tlpMainTab.SuspendLayout
        Me.tbpPensionRates.SuspendLayout
        Me.tlpPostingAccounts.SuspendLayout
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
        'bsPensionRates
        '
        Me.bsPensionRates.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollEarnAccountModel)
        '
        'CFlowLayout4
        '
        Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout4.Controls.Add(Me.tlpPensionScheme)
        resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
        Me.CFlowLayout4.Name = "CFlowLayout4"
        '
        'tlpPensionScheme
        '
        Me.tlpPensionScheme.Controls.Add(Me.tbcPensionScheme, 0, 3)
        Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeNameAra, 1, 2)
        Me.tlpPensionScheme.Controls.Add(Me.lblName, 0, 1)
        Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeCode, 3, 0)
        Me.tlpPensionScheme.Controls.Add(Me.lblCode, 2, 0)
        Me.tlpPensionScheme.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.tlpPensionScheme.Controls.Add(Me.CLabel1, 0, 0)
        Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeName, 1, 1)
        Me.tlpPensionScheme.Controls.Add(Me.lblNameAra, 0, 2)
        Me.CFlowLayout4.SetFlowBreak(Me.tlpPensionScheme, true)
        resources.ApplyResources(Me.tlpPensionScheme, "tlpPensionScheme")
        Me.tlpPensionScheme.Name = "tlpPensionScheme"
        '
        'tbcPensionScheme
        '
        Me.tlpPensionScheme.SetColumnSpan(Me.tbcPensionScheme, 4)
        Me.tbcPensionScheme.Controls.Add(Me.tbpMain)
        Me.tbcPensionScheme.Controls.Add(Me.tbpPensionRates)
        resources.ApplyResources(Me.tbcPensionScheme, "tbcPensionScheme")
        Me.tbcPensionScheme.Name = "tbcPensionScheme"
        Me.tbcPensionScheme.SelectedIndex = 0
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
        Me.CFlowLayout1.Controls.Add(Me.tlpMainTab)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'tlpMainTab
        '
        resources.ApplyResources(Me.tlpMainTab, "tlpMainTab")
        Me.tlpMainTab.Controls.Add(Me.cboPensionProviderIdNo, 0, 1)
        Me.tlpMainTab.Controls.Add(Me.lblPensionProviderIdNo, 0, 0)
        Me.tlpMainTab.Controls.Add(Me.txtNotes, 0, 3)
        Me.tlpMainTab.Controls.Add(Me.lblNotes, 0, 2)
        Me.tlpMainTab.Name = "tlpMainTab"
        '
        'cboPensionProviderIdNo
        '
        Me.cboPensionProviderIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPensionProviderIdNo.BackColor = System.Drawing.Color.White
        Me.cboPensionProviderIdNo.ChangingSearchValueOnly = false
        Me.tlpMainTab.SetColumnSpan(Me.cboPensionProviderIdNo, 2)
        Me.cboPensionProviderIdNo.CurrentSearchTerm = ""
        Me.cboPensionProviderIdNo.DefaultValue = Nothing
        Me.cboPensionProviderIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboPensionProviderIdNo, "cboPensionProviderIdNo")
        Me.cboPensionProviderIdNo.DropDownHeight = 1
        Me.cboPensionProviderIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPensionProviderIdNo.EditingMode = false
        Me.cboPensionProviderIdNo.FilterRule = Nothing
        Me.cboPensionProviderIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPensionProviderIdNo.FormattingEnabled = true
        Me.cboPensionProviderIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPensionProviderIdNo.LinkedLabel = Nothing
        Me.cboPensionProviderIdNo.Name = "cboPensionProviderIdNo"
        Me.cboPensionProviderIdNo.OldValue = 0
        Me.cboPensionProviderIdNo.OriginalDataSource = Nothing
        Me.cboPensionProviderIdNo.OriginalList = Nothing
        Me.cboPensionProviderIdNo.OverrideDropDownStyleList = false
        Me.cboPensionProviderIdNo.PreviousSearchTerm = Nothing
        Me.cboPensionProviderIdNo.PreviousSelectedIndex = -1
        Me.cboPensionProviderIdNo.PropertySelector = Nothing
        Me.cboPensionProviderIdNo.ReadOnlyCombo = false
        Me.cboPensionProviderIdNo.SearchAnywhere = false
        Me.cboPensionProviderIdNo.SuggestBoxHeight = 200
        Me.cboPensionProviderIdNo.SuggestListOrderRule = Nothing
        Me.cboPensionProviderIdNo.TextToSearch = Nothing
        Me.cboPensionProviderIdNo.ValueIsMandatory = false
        Me.cboPensionProviderIdNo.ValueIsNullable = false
        Me.cboPensionProviderIdNo.ValueIsNumeric = false
        Me.cboPensionProviderIdNo.ValueMember = "IdNo"
        '
        'lblPensionProviderIdNo
        '
        Me.lblPensionProviderIdNo.DisplayOnly = true
        Me.lblPensionProviderIdNo.EditingMode = false
        resources.ApplyResources(Me.lblPensionProviderIdNo, "lblPensionProviderIdNo")
        Me.lblPensionProviderIdNo.Name = "lblPensionProviderIdNo"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpMainTab.SetColumnSpan(Me.txtNotes, 2)
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
        'tbpPensionRates
        '
        Me.tbpPensionRates.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
        resources.ApplyResources(Me.tbpPensionRates, "tbpPensionRates")
        Me.tbpPensionRates.Controls.Add(Me.tlpPostingAccounts)
        Me.tbpPensionRates.Name = "tbpPensionRates"
        Me.tbpPensionRates.UseVisualStyleBackColor = true
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
        Me.tlpPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
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
        Me.DataGridViewPayrollEarnAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
        Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPayrollEarnAccounts, 3)
        Me.DataGridViewPayrollEarnAccounts.DataInGridChanged = false
        Me.DataGridViewPayrollEarnAccounts.DataSource = Me.bsPensionRates
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
        Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = true
        Me.DataGridViewPayrollEarnAccounts.StartTrackingChanges = false
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
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'PayGroupNameDataGridViewTextBoxColumn
        '
        Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
        resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
        Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
        Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = true
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
        'txtPensionSchemeNameAra
        '
        Me.txtPensionSchemeNameAra.BackColor = System.Drawing.Color.White
        Me.txtPensionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPensionScheme.SetColumnSpan(Me.txtPensionSchemeNameAra, 3)
        Me.txtPensionSchemeNameAra.ComputedValue = false
        Me.txtPensionSchemeNameAra.CustomFormat = Nothing
        Me.txtPensionSchemeNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtPensionSchemeNameAra, "txtPensionSchemeNameAra")
        Me.txtPensionSchemeNameAra.EditingMode = false
        Me.txtPensionSchemeNameAra.EnglishControl = Me.txtPensionSchemeName
        Me.txtPensionSchemeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPensionSchemeNameAra.LinkedLabel = Nothing
        Me.txtPensionSchemeNameAra.MaximumValue = Nothing
        Me.txtPensionSchemeNameAra.MinimumValue = Nothing
        Me.txtPensionSchemeNameAra.Name = "txtPensionSchemeNameAra"
        Me.txtPensionSchemeNameAra.OldValue = Nothing
        Me.txtPensionSchemeNameAra.ReadOnly = true
        '
        'txtPensionSchemeName
        '
        Me.txtPensionSchemeName.BackColor = System.Drawing.Color.White
        Me.txtPensionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPensionScheme.SetColumnSpan(Me.txtPensionSchemeName, 3)
        Me.txtPensionSchemeName.ComputedValue = false
        Me.txtPensionSchemeName.CustomFormat = Nothing
        Me.txtPensionSchemeName.DataBoundControl = true
        resources.ApplyResources(Me.txtPensionSchemeName, "txtPensionSchemeName")
        Me.txtPensionSchemeName.EditingMode = false
        Me.txtPensionSchemeName.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPensionSchemeName, CType(resources.GetObject("txtPensionSchemeName.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtPensionSchemeName.LinkedLabel = Nothing
        Me.txtPensionSchemeName.MaximumValue = Nothing
        Me.txtPensionSchemeName.MinimumValue = Nothing
        Me.txtPensionSchemeName.Name = "txtPensionSchemeName"
        Me.txtPensionSchemeName.OldValue = Nothing
        Me.txtPensionSchemeName.ReadOnly = true
        Me.txtPensionSchemeName.ValueIsMandatory = true
        '
        'lblName
        '
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'txtPensionSchemeCode
        '
        Me.txtPensionSchemeCode.BackColor = System.Drawing.Color.White
        Me.txtPensionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPensionSchemeCode.ComputedValue = false
        Me.txtPensionSchemeCode.CustomFormat = Nothing
        Me.txtPensionSchemeCode.DataBoundControl = true
        Me.txtPensionSchemeCode.EditingMode = true
        resources.ApplyResources(Me.txtPensionSchemeCode, "txtPensionSchemeCode")
        Me.txtPensionSchemeCode.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPensionSchemeCode, CType(resources.GetObject("txtPensionSchemeCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtPensionSchemeCode.LinkedLabel = Nothing
        Me.txtPensionSchemeCode.MaximumValue = Nothing
        Me.txtPensionSchemeCode.MinimumValue = Nothing
        Me.txtPensionSchemeCode.Name = "txtPensionSchemeCode"
        Me.txtPensionSchemeCode.OldValue = Nothing
        Me.txtPensionSchemeCode.ReadOnly = true
        Me.txtPensionSchemeCode.ValueIsMandatory = true
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
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'PensionSchemeEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PensionSchemeEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPensionRates,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.tlpPensionScheme.ResumeLayout(false)
        Me.tlpPensionScheme.PerformLayout
        Me.tbcPensionScheme.ResumeLayout(false)
        Me.tbpMain.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.tlpMainTab.ResumeLayout(false)
        Me.tlpMainTab.PerformLayout
        Me.tbpPensionRates.ResumeLayout(false)
        Me.tbpPensionRates.PerformLayout
        Me.tlpPostingAccounts.ResumeLayout(false)
        Me.tlpPostingAccounts.PerformLayout
        CType(Me.DataGridViewPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsPensionRates As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents tlpPensionScheme As TableLayoutPanel
        Friend WithEvents txtPensionSchemeNameAra As CTextBoxArabic
        Friend WithEvents txtPensionSchemeName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtPensionSchemeCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents PensionSchemeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tbcPensionScheme As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents tlpMainTab As TableLayoutPanel
        Friend WithEvents cboPensionProviderIdNo As CaComboBox
        Friend WithEvents lblPensionProviderIdNo As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpPensionRates As TabPage
        Friend WithEvents tlpPostingAccounts As TableLayoutPanel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents lblUsePayGroups As CLabel
        Friend WithEvents chkUsePayGroups As CCheckBox
    End Class
End Namespace