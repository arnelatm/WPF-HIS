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
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tbcEarning = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpMain = New System.Windows.Forms.TabPage()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.tbpComputation = New System.Windows.Forms.TabPage()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.tbcEarning.SuspendLayout()
            Me.tbpMain.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbpAccountPosting.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpComputation.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
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
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.tbcEarning)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'tbcEarning
            '
            Me.tbcEarning.Controls.Add(Me.tbpMain)
            Me.tbcEarning.Controls.Add(Me.tbpAccountPosting)
            Me.tbcEarning.Controls.Add(Me.tbpComputation)
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
            Me.tbpMain.UseVisualStyleBackColor = True
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
            Me.cboAccountIdNo.ValueMember = "IdNo"
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
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'tbpAccountPosting
            '
            Me.tbpAccountPosting.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
            resources.ApplyResources(Me.tbpAccountPosting, "tbpAccountPosting")
            Me.tbpAccountPosting.Controls.Add(Me.CFlowLayout2)
            Me.tbpAccountPosting.Name = "tbpAccountPosting"
            Me.tbpAccountPosting.UseVisualStyleBackColor = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.txtName)
            Me.CFlowLayout2.Controls.Add(Me.txtNameAra)
            Me.CFlowLayout2.Controls.Add(Me.DataGridViewPayrollEarnAccounts)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.Color.White
            Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtName.ComputedValue = False
            Me.txtName.CustomFormat = Nothing
            Me.txtName.DataBoundControl = True
            Me.txtName.DisplayOnly = True
            Me.txtName.EditingMode = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtName, True)
            resources.ApplyResources(Me.txtName, "txtName")
            Me.txtName.ForeColor = System.Drawing.Color.Black
            Me.txtName.LinkedLabel = Nothing
            Me.txtName.MaximumValue = Nothing
            Me.txtName.MinimumValue = Nothing
            Me.txtName.Name = "txtName"
            Me.txtName.OldValue = Nothing
            Me.txtName.ReadOnly = True
            '
            'txtNameAra
            '
            Me.txtNameAra.BackColor = System.Drawing.Color.White
            Me.txtNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNameAra.ComputedValue = False
            Me.txtNameAra.CustomFormat = Nothing
            Me.txtNameAra.DataBoundControl = True
            Me.txtNameAra.EditingMode = True
            Me.txtNameAra.EnglishControl = Me.txtName
            resources.ApplyResources(Me.txtNameAra, "txtNameAra")
            Me.txtNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtNameAra.LinkedLabel = Nothing
            Me.txtNameAra.MaximumValue = Nothing
            Me.txtNameAra.MinimumValue = Nothing
            Me.txtNameAra.Name = "txtNameAra"
            Me.txtNameAra.OldValue = Nothing
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
            Me.DataGridViewPayrollEarnAccounts.DgvFooter = Nothing
            Me.DataGridViewPayrollEarnAccounts.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayrollEarnAccounts, "DataGridViewPayrollEarnAccounts")
            Me.DataGridViewPayrollEarnAccounts.Ea = EventAggregator1
            Me.DataGridViewPayrollEarnAccounts.EditingMode = False
            Me.DataGridViewPayrollEarnAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollEarnAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollEarnAccounts.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollEarnAccounts.Name = "DataGridViewPayrollEarnAccounts"
            Me.DataGridViewPayrollEarnAccounts.ReadOnly = True
            Me.DataGridViewPayrollEarnAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollEarnAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollEarnAccounts.ShowFooter = False
            Me.DataGridViewPayrollEarnAccounts.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPayrollEarnAccounts.StartTrackingChanges = False
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
            'tbpComputation
            '
            Me.tbpComputation.Controls.Add(Me.CFlowLayout3)
            resources.ApplyResources(Me.tbpComputation, "tbpComputation")
            Me.tbpComputation.Name = "tbpComputation"
            Me.tbpComputation.UseVisualStyleBackColor = True
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.TableLayoutPanel2)
            resources.ApplyResources(Me.CFlowLayout3, "CFlowLayout3")
            Me.CFlowLayout3.Name = "CFlowLayout3"
            '
            'TableLayoutPanel2
            '
            resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
            Me.TableLayoutPanel2.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.CLabel1, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.cboCalculationType, 1, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            '
            'CLabel1
            '
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Name = "CLabel1"
            '
            'cboCalculationType
            '
            Me.cboCalculationType.BackColor = System.Drawing.SystemColors.ControlLight
            Me.cboCalculationType.ChangingSearchValueOnly = False
            Me.cboCalculationType.CurrentSearchTerm = ""
            Me.cboCalculationType.DefaultValue = Nothing
            Me.cboCalculationType.DisplayMember = "Name"
            Me.cboCalculationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCalculationType.EditingMode = True
            Me.cboCalculationType.FilterRule = Nothing
            resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
            Me.cboCalculationType.FormattingEnabled = True
            Me.cboCalculationType.HideWhenNotEditingOrAdding = False
            Me.cboCalculationType.LinkedLabel = Nothing
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
            Me.cboCalculationType.ValueMember = "IdNo"
            '
            'CLabel2
            '
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Name = "CLabel2"
            '
            'EarningEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "EarningEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.tbcEarning.ResumeLayout(False)
            Me.tbpMain.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbpAccountPosting.ResumeLayout(False)
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpComputation.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtEarningCode As CTextBox
        Friend WithEvents txtEarningName As CTextBox
        Friend WithEvents txtEarningNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblFrequency As CLabel
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents cboFrequency As CaComboBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents tbcEarning As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents bsPayrollEarnAccounts As BindingSource
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents txtName As CTextBox
        Friend WithEvents txtNameAra As CTextBoxArabic
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tbpComputation As TabPage
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cboCalculationType As CaComboBox
        Friend WithEvents CLabel2 As CLabel
    End Class
End Namespace