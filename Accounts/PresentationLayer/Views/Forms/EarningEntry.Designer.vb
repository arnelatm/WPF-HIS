Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EarningEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EarningEntry))
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floJournalHeader.SuspendLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout4.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'floJournalHeader
            '
            Me.floJournalHeader.BackColor = System.Drawing.Color.Transparent
            Me.floJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floJournalHeader.Controls.Add(Me.DataGridViewPayrollEarnAccounts)
            resources.ApplyResources(Me.floJournalHeader, "floJournalHeader")
            Me.floJournalHeader.Name = "floJournalHeader"
            '
            'DataGridViewPayrollEarnAccounts
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollEarnAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayrollEarnAccounts.AutoGenerateColumns = False
            Me.DataGridViewPayrollEarnAccounts.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewPayrollEarnAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollEarnAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.EarningIdNoDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
            Me.DataGridViewPayrollEarnAccounts.DataInGridChanged = False
            Me.DataGridViewPayrollEarnAccounts.DataSource = Me.bsPayrollEarnAccounts
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayrollEarnAccounts.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewPayrollEarnAccounts.DisplayOnly = False
            Me.DataGridViewPayrollEarnAccounts.Ea = EventAggregator1
            Me.DataGridViewPayrollEarnAccounts.EditingMode = False
            Me.DataGridViewPayrollEarnAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollEarnAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollEarnAccounts.FirstRowInsertionEnabled = True
            resources.ApplyResources(Me.DataGridViewPayrollEarnAccounts, "DataGridViewPayrollEarnAccounts")
            Me.DataGridViewPayrollEarnAccounts.Name = "DataGridViewPayrollEarnAccounts"
            Me.DataGridViewPayrollEarnAccounts.ReadOnly = True
            Me.DataGridViewPayrollEarnAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollEarnAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPayrollEarnAccounts.StartTrackingChanges = False
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.EditingMode = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPayGroupIdNo
            '
            Me.dgvPayGroupIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvPayGroupIdNo.DataPropertyName = "PayGroupIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvPayGroupIdNo.DefaultCellStyle = DataGridViewCellStyle3
            resources.ApplyResources(Me.dgvPayGroupIdNo, "dgvPayGroupIdNo")
            Me.dgvPayGroupIdNo.Name = "dgvPayGroupIdNo"
            Me.dgvPayGroupIdNo.ReadOnly = True
            Me.dgvPayGroupIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle4
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
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CFlowLayout4)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.TableLayoutPanel1)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAccountIdNo, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAccountIdNo, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFrequency, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFrequency, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.cboEarningType, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEarningType, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningName, 0, 3)
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
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
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
            Me.cboAccountIdNo.ValueMember = "Code"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'cboFrequency
            '
            Me.cboFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboFrequency.BackColor = System.Drawing.Color.White
            Me.cboFrequency.ChangingSearchValueOnly = False
            Me.cboFrequency.CurrentSearchTerm = ""
            Me.cboFrequency.DefaultValue = Nothing
            Me.cboFrequency.DisplayMember = "Name"
            resources.ApplyResources(Me.cboFrequency, "cboFrequency")
            Me.cboFrequency.DropDownHeight = 1
            Me.cboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFrequency.EditingMode = False
            Me.cboFrequency.FilterRule = Nothing
            Me.cboFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboFrequency.FormattingEnabled = True
            Me.cboFrequency.HideWhenNotEditingOrAdding = False
            Me.cboFrequency.LinkedLabel = Nothing
            Me.cboFrequency.Name = "cboFrequency"
            Me.cboFrequency.OldValue = 0
            Me.cboFrequency.OriginalDataSource = Nothing
            Me.cboFrequency.OriginalList = Nothing
            Me.cboFrequency.OverrideDropDownStyleList = False
            Me.cboFrequency.PreviousSearchTerm = Nothing
            Me.cboFrequency.PreviousSelectedIndex = -1
            Me.cboFrequency.PropertySelector = Nothing
            Me.cboFrequency.ReadOnlyCombo = False
            Me.cboFrequency.SearchAnywhere = False
            Me.cboFrequency.SuggestBoxHeight = 200
            Me.cboFrequency.SuggestListOrderRule = Nothing
            Me.cboFrequency.TextToSearch = Nothing
            Me.cboFrequency.ValueIsMandatory = False
            Me.cboFrequency.ValueIsNullable = False
            Me.cboFrequency.ValueIsNumeric = False
            Me.cboFrequency.ValueMember = "Code"
            '
            'lblFrequency
            '
            Me.lblFrequency.DisplayOnly = True
            Me.lblFrequency.EditingMode = False
            resources.ApplyResources(Me.lblFrequency, "lblFrequency")
            Me.lblFrequency.Name = "lblFrequency"
            '
            'cboEarningType
            '
            Me.cboEarningType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboEarningType.BackColor = System.Drawing.Color.White
            Me.cboEarningType.ChangingSearchValueOnly = False
            Me.cboEarningType.CurrentSearchTerm = ""
            Me.cboEarningType.DefaultValue = ""
            Me.cboEarningType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboEarningType, "cboEarningType")
            Me.cboEarningType.DropDownHeight = 1
            Me.cboEarningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboEarningType.EditingMode = False
            Me.cboEarningType.FilterRule = Nothing
            Me.cboEarningType.ForeColor = System.Drawing.Color.Black
            Me.cboEarningType.HideWhenNotEditingOrAdding = False
            Me.cboEarningType.LinkedLabel = Me.lblEarningType
            Me.cboEarningType.Name = "cboEarningType"
            Me.cboEarningType.OldValue = 0
            Me.cboEarningType.OriginalDataSource = Nothing
            Me.cboEarningType.OriginalList = Nothing
            Me.cboEarningType.OverrideDropDownStyleList = False
            Me.cboEarningType.PreviousSearchTerm = Nothing
            Me.cboEarningType.PreviousSelectedIndex = 0
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
            'lblEarningType
            '
            Me.lblEarningType.DisplayOnly = True
            Me.lblEarningType.EditingMode = False
            resources.ApplyResources(Me.lblEarningType, "lblEarningType")
            Me.lblEarningType.Name = "lblEarningType"
            '
            'txtEarningNameAra
            '
            Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
            Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEarningNameAra, 2)
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEarningName, 2)
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
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            '
            'lblName
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
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
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'EarningEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CLabel1)
            Me.Controls.Add(Me.floJournalHeader)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "EarningEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            Me.Controls.SetChildIndex(Me.floJournalHeader, 0)
            Me.Controls.SetChildIndex(Me.CLabel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floJournalHeader.ResumeLayout(False)
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout4.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floJournalHeader As CFlowLayout
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents bsPayrollEarnAccounts As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SequenceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboFrequency As CaComboBox
        Friend WithEvents lblFrequency As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents txtEarningNameAra As CTextBoxArabic
        Friend WithEvents txtEarningName As CTextBox
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtEarningCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End NameSpace