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
            Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.tbcEarning = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpMain = New System.Windows.Forms.TabPage()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpCalculation = New System.Windows.Forms.TabPage()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblTaxable = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblMultiplier = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDefaultQty = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCalculationType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBasePayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBasePaymentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblIncludeInGosi = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIncludeInPension = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblIncludeInEos = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIncludeInEOS = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboMultiplierType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.chkTaxable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewPayrollEarnAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EarningIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.tbcEarning.SuspendLayout()
            Me.tbpMain.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbpCalculation.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.tbpAccountPosting.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'txtEarningNameAra
            '
            Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
            Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel3.SetColumnSpan(Me.txtEarningNameAra, 3)
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
            Me.TableLayoutPanel3.SetColumnSpan(Me.txtEarningName, 3)
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
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
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
            'tbpCalculation
            '
            Me.tbpCalculation.Controls.Add(Me.CFlowLayout3)
            resources.ApplyResources(Me.tbpCalculation, "tbpCalculation")
            Me.tbpCalculation.Name = "tbpCalculation"
            Me.tbpCalculation.UseVisualStyleBackColor = True
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
            Me.TableLayoutPanel2.Controls.Add(Me.lblTaxable, 0, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.lblMultiplier, 0, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.lblDefaultQty, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblRate, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblCalculationType, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.cboCalculationType, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.txtRate, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.CTextBox2, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblBasePayment, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.cboBasePaymentIdNo, 1, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncludeInGosi, 0, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncludeInPension, 1, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncludeInEos, 0, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncludeInEOS, 1, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.CTextBox3, 1, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.cboMultiplierType, 2, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.chkTaxable, 2, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.cboUnit, 3, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayRate, 2, 1)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            '
            'lblTaxable
            '
            resources.ApplyResources(Me.lblTaxable, "lblTaxable")
            Me.TableLayoutPanel2.SetColumnSpan(Me.lblTaxable, 2)
            Me.lblTaxable.DisplayOnly = True
            Me.lblTaxable.EditingMode = False
            Me.lblTaxable.Name = "lblTaxable"
            '
            'lblMultiplier
            '
            resources.ApplyResources(Me.lblMultiplier, "lblMultiplier")
            Me.lblMultiplier.DisplayOnly = True
            Me.lblMultiplier.EditingMode = False
            Me.lblMultiplier.Name = "lblMultiplier"
            '
            'lblDefaultQty
            '
            resources.ApplyResources(Me.lblDefaultQty, "lblDefaultQty")
            Me.lblDefaultQty.DisplayOnly = True
            Me.lblDefaultQty.EditingMode = False
            Me.lblDefaultQty.Name = "lblDefaultQty"
            '
            'lblRate
            '
            resources.ApplyResources(Me.lblRate, "lblRate")
            Me.lblRate.DisplayOnly = True
            Me.lblRate.EditingMode = False
            Me.lblRate.Name = "lblRate"
            '
            'lblCalculationType
            '
            resources.ApplyResources(Me.lblCalculationType, "lblCalculationType")
            Me.lblCalculationType.DisplayOnly = True
            Me.lblCalculationType.EditingMode = False
            Me.lblCalculationType.Name = "lblCalculationType"
            '
            'cboCalculationType
            '
            Me.cboCalculationType.BackColor = System.Drawing.Color.White
            Me.cboCalculationType.ChangingSearchValueOnly = False
            Me.TableLayoutPanel2.SetColumnSpan(Me.cboCalculationType, 3)
            Me.cboCalculationType.CurrentSearchTerm = ""
            Me.cboCalculationType.DefaultValue = Nothing
            Me.cboCalculationType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboCalculationType, "cboCalculationType")
            Me.cboCalculationType.DropDownHeight = 200
            Me.cboCalculationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCalculationType.EditingMode = True
            Me.cboCalculationType.FilterRule = Nothing
            Me.cboCalculationType.ForeColor = System.Drawing.Color.Black
            Me.cboCalculationType.FormattingEnabled = True
            Me.cboCalculationType.HideWhenNotEditingOrAdding = False
            Me.cboCalculationType.LinkedLabel = Me.lblCalculationType
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
            Me.txtRate.LinkedLabel = Nothing
            Me.txtRate.MaximumValue = Nothing
            Me.txtRate.MinimumValue = Nothing
            Me.txtRate.Name = "txtRate"
            Me.txtRate.OldValue = Nothing
            '
            'CTextBox2
            '
            Me.CTextBox2.BackColor = System.Drawing.Color.White
            Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox2.ComputedValue = False
            Me.CTextBox2.CustomFormat = Nothing
            Me.CTextBox2.DataBoundControl = True
            resources.ApplyResources(Me.CTextBox2, "CTextBox2")
            Me.CTextBox2.EditingMode = True
            Me.CTextBox2.ForeColor = System.Drawing.Color.Black
            Me.CTextBox2.LinkedLabel = Me.lblDefaultQty
            Me.CTextBox2.MaximumValue = Nothing
            Me.CTextBox2.MinimumValue = Nothing
            Me.CTextBox2.Name = "CTextBox2"
            Me.CTextBox2.OldValue = Nothing
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
            Me.TableLayoutPanel2.SetColumnSpan(Me.cboBasePaymentIdNo, 3)
            Me.cboBasePaymentIdNo.CurrentSearchTerm = ""
            Me.cboBasePaymentIdNo.DefaultValue = Nothing
            Me.cboBasePaymentIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboBasePaymentIdNo, "cboBasePaymentIdNo")
            Me.cboBasePaymentIdNo.DropDownHeight = 200
            Me.cboBasePaymentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
            'lblIncludeInGosi
            '
            resources.ApplyResources(Me.lblIncludeInGosi, "lblIncludeInGosi")
            Me.TableLayoutPanel2.SetColumnSpan(Me.lblIncludeInGosi, 2)
            Me.lblIncludeInGosi.DisplayOnly = True
            Me.lblIncludeInGosi.EditingMode = False
            Me.lblIncludeInGosi.Name = "lblIncludeInGosi"
            '
            'chkIncludeInPension
            '
            resources.ApplyResources(Me.chkIncludeInPension, "chkIncludeInPension")
            Me.chkIncludeInPension.BackColor = System.Drawing.Color.White
            Me.chkIncludeInPension.DisplayOnly = False
            Me.chkIncludeInPension.EditingMode = True
            Me.chkIncludeInPension.FlatAppearance.BorderSize = 0
            Me.chkIncludeInPension.ForeColor = System.Drawing.Color.Black
            Me.chkIncludeInPension.LinkedLabel = Me.lblIncludeInGosi
            Me.chkIncludeInPension.Name = "chkIncludeInPension"
            Me.chkIncludeInPension.NoLabel = False
            Me.chkIncludeInPension.OldValue = Nothing
            Me.chkIncludeInPension.UseVisualStyleBackColor = True
            '
            'lblIncludeInEos
            '
            resources.ApplyResources(Me.lblIncludeInEos, "lblIncludeInEos")
            Me.TableLayoutPanel2.SetColumnSpan(Me.lblIncludeInEos, 2)
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
            Me.chkIncludeInEOS.NoLabel = False
            Me.chkIncludeInEOS.OldValue = Nothing
            Me.chkIncludeInEOS.UseVisualStyleBackColor = True
            '
            'CTextBox3
            '
            Me.CTextBox3.BackColor = System.Drawing.Color.White
            Me.CTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox3.ComputedValue = False
            Me.CTextBox3.CustomFormat = Nothing
            Me.CTextBox3.DataBoundControl = True
            resources.ApplyResources(Me.CTextBox3, "CTextBox3")
            Me.CTextBox3.EditingMode = True
            Me.CTextBox3.ForeColor = System.Drawing.Color.Black
            Me.CTextBox3.LinkedLabel = Me.lblMultiplier
            Me.CTextBox3.MaximumValue = Nothing
            Me.CTextBox3.MinimumValue = Nothing
            Me.CTextBox3.Name = "CTextBox3"
            Me.CTextBox3.OldValue = Nothing
            '
            'cboMultiplierType
            '
            Me.cboMultiplierType.BackColor = System.Drawing.Color.White
            Me.cboMultiplierType.ChangingSearchValueOnly = False
            Me.TableLayoutPanel2.SetColumnSpan(Me.cboMultiplierType, 2)
            Me.cboMultiplierType.CurrentSearchTerm = ""
            Me.cboMultiplierType.DefaultValue = Nothing
            Me.cboMultiplierType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboMultiplierType, "cboMultiplierType")
            Me.cboMultiplierType.DropDownHeight = 200
            Me.cboMultiplierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMultiplierType.EditingMode = True
            Me.cboMultiplierType.FilterRule = Nothing
            Me.cboMultiplierType.ForeColor = System.Drawing.Color.Black
            Me.cboMultiplierType.FormattingEnabled = True
            Me.cboMultiplierType.HideWhenNotEditingOrAdding = False
            Me.cboMultiplierType.LinkedLabel = Nothing
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
            Me.chkTaxable.NoLabel = False
            Me.chkTaxable.OldValue = Nothing
            Me.chkTaxable.UseVisualStyleBackColor = True
            '
            'cboUnit
            '
            Me.cboUnit.BackColor = System.Drawing.Color.White
            Me.cboUnit.ChangingSearchValueOnly = False
            Me.cboUnit.CurrentSearchTerm = ""
            Me.cboUnit.DefaultValue = Nothing
            Me.cboUnit.DisplayMember = "Name"
            Me.cboUnit.DropDownHeight = 200
            Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboUnit.EditingMode = True
            Me.cboUnit.FilterRule = Nothing
            resources.ApplyResources(Me.cboUnit, "cboUnit")
            Me.cboUnit.ForeColor = System.Drawing.Color.Black
            Me.cboUnit.FormattingEnabled = True
            Me.cboUnit.HideWhenNotEditingOrAdding = False
            Me.cboUnit.LinkedLabel = Me.lblRate
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
            'lblPayRate
            '
            resources.ApplyResources(Me.lblPayRate, "lblPayRate")
            Me.lblPayRate.DisplayOnly = True
            Me.lblPayRate.EditingMode = False
            Me.lblPayRate.Name = "lblPayRate"
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
            Me.CFlowLayout2.Controls.Add(Me.DataGridViewPayrollEarnAccounts)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
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
            'EarningEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "EarningEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.floDataDisplay.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            Me.tbcEarning.ResumeLayout(False)
            Me.tbpMain.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbpCalculation.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.tbpAccountPosting.ResumeLayout(False)
            Me.CFlowLayout2.ResumeLayout(False)
            CType(Me.DataGridViewPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents cboFrequency As CaComboBox
        Friend WithEvents lblFrequency As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents tbpCalculation As TabPage
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents lblTaxable As CLabel
        Friend WithEvents lblMultiplier As CLabel
        Friend WithEvents lblDefaultQty As CLabel
        Friend WithEvents lblRate As CLabel
        Friend WithEvents lblCalculationType As CLabel
        Friend WithEvents cboCalculationType As CaComboBox
        Friend WithEvents txtRate As CTextBox
        Friend WithEvents CTextBox2 As CTextBox
        Friend WithEvents lblBasePayment As CLabel
        Friend WithEvents cboBasePaymentIdNo As CaComboBox
        Friend WithEvents lblIncludeInGosi As CLabel
        Friend WithEvents chkIncludeInPension As CCheckBox
        Friend WithEvents lblIncludeInEos As CLabel
        Friend WithEvents chkIncludeInEOS As CCheckBox
        Friend WithEvents CTextBox3 As CTextBox
        Friend WithEvents cboMultiplierType As CaComboBox
        Friend WithEvents chkTaxable As CCheckBox
        Friend WithEvents cboUnit As CaComboBox
        Friend WithEvents lblPayRate As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents DataGridViewPayrollEarnAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents floDataDisplay As CFlowLayout
    End Class
End Namespace