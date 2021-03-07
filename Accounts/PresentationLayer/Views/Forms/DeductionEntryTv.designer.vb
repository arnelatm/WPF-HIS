Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DeductionEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeductionEntryTv))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.bsPayrollDeductAccounts = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpDeduction = New System.Windows.Forms.TableLayoutPanel()
            Me.txtDeductionNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtDeductionName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDeductionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbcDeduction = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpMain = New System.Windows.Forms.TabPage()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpCalculation = New System.Windows.Forms.TabPage()
            Me.floCalculation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblMultiplier = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDefaultQty = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCalculationType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboCalculationType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDefaultQuantity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBasePayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBasePaymentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtMultiplier = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboMultiplierType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboDeductionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            Me.floPostingAccounts = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tloPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.DataGridViewPayrollDeductAccounts = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DeductionIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkUsePayGroups = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollDeductAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.tlpDeduction.SuspendLayout()
            Me.tbcDeduction.SuspendLayout()
            Me.tbpMain.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbpCalculation.SuspendLayout()
            Me.floCalculation.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.tbpAccountPosting.SuspendLayout()
            Me.floPostingAccounts.SuspendLayout()
            Me.tloPostingAccounts.SuspendLayout()
            CType(Me.DataGridViewPayrollDeductAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
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
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'bsPayrollDeductAccounts
            '
            Me.bsPayrollDeductAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollDeductAccountModel)
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.tlpDeduction)
            Me.CFlowLayout4.Controls.Add(Me.tbcDeduction)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'tlpDeduction
            '
            resources.ApplyResources(Me.tlpDeduction, "tlpDeduction")
            Me.tlpDeduction.Controls.Add(Me.txtDeductionNameAra, 1, 2)
            Me.tlpDeduction.Controls.Add(Me.lblName, 0, 1)
            Me.tlpDeduction.Controls.Add(Me.txtDeductionCode, 3, 0)
            Me.tlpDeduction.Controls.Add(Me.lblCode, 2, 0)
            Me.tlpDeduction.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.tlpDeduction.Controls.Add(Me.CLabel1, 0, 0)
            Me.tlpDeduction.Controls.Add(Me.txtDeductionName, 1, 1)
            Me.tlpDeduction.Controls.Add(Me.lblNameAra, 0, 2)
            Me.tlpDeduction.Name = "tlpDeduction"
            '
            'txtDeductionNameAra
            '
            Me.txtDeductionNameAra.BackColor = System.Drawing.Color.White
            Me.txtDeductionNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDeduction.SetColumnSpan(Me.txtDeductionNameAra, 3)
            Me.txtDeductionNameAra.ComputedValue = False
            Me.txtDeductionNameAra.CustomFormat = Nothing
            Me.txtDeductionNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtDeductionNameAra, "txtDeductionNameAra")
            Me.txtDeductionNameAra.EditingMode = False
            Me.txtDeductionNameAra.EnglishControl = Me.txtDeductionName
            Me.txtDeductionNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDeductionNameAra.LinkedLabel = Nothing
            Me.txtDeductionNameAra.MaximumValue = Nothing
            Me.txtDeductionNameAra.MinimumValue = Nothing
            Me.txtDeductionNameAra.Name = "txtDeductionNameAra"
            Me.txtDeductionNameAra.OldValue = Nothing
            Me.txtDeductionNameAra.ReadOnly = True
            '
            'txtDeductionName
            '
            Me.txtDeductionName.BackColor = System.Drawing.Color.White
            Me.txtDeductionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDeduction.SetColumnSpan(Me.txtDeductionName, 3)
            Me.txtDeductionName.ComputedValue = False
            Me.txtDeductionName.CustomFormat = Nothing
            Me.txtDeductionName.DataBoundControl = True
            resources.ApplyResources(Me.txtDeductionName, "txtDeductionName")
            Me.txtDeductionName.EditingMode = False
            Me.txtDeductionName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtDeductionName, CType(resources.GetObject("txtDeductionName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtDeductionName.LinkedLabel = Nothing
            Me.txtDeductionName.MaximumValue = Nothing
            Me.txtDeductionName.MinimumValue = Nothing
            Me.txtDeductionName.Name = "txtDeductionName"
            Me.txtDeductionName.OldValue = Nothing
            Me.txtDeductionName.ReadOnly = True
            Me.txtDeductionName.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'txtDeductionCode
            '
            Me.txtDeductionCode.BackColor = System.Drawing.Color.White
            Me.txtDeductionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeductionCode.ComputedValue = False
            Me.txtDeductionCode.CustomFormat = Nothing
            Me.txtDeductionCode.DataBoundControl = True
            Me.txtDeductionCode.EditingMode = True
            resources.ApplyResources(Me.txtDeductionCode, "txtDeductionCode")
            Me.txtDeductionCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtDeductionCode, CType(resources.GetObject("txtDeductionCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtDeductionCode, CType(resources.GetObject("txtDeductionCode.IconPadding"), Integer))
            Me.txtDeductionCode.LinkedLabel = Nothing
            Me.txtDeductionCode.MaximumValue = Nothing
            Me.txtDeductionCode.MinimumValue = Nothing
            Me.txtDeductionCode.Name = "txtDeductionCode"
            Me.txtDeductionCode.OldValue = Nothing
            Me.txtDeductionCode.ReadOnly = True
            Me.txtDeductionCode.ValueIsMandatory = True
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
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            '
            'tbcDeduction
            '
            Me.tbcDeduction.Controls.Add(Me.tbpMain)
            Me.tbcDeduction.Controls.Add(Me.tbpCalculation)
            Me.tbcDeduction.Controls.Add(Me.tbpAccountPosting)
            resources.ApplyResources(Me.tbcDeduction, "tbcDeduction")
            Me.tbcDeduction.Name = "tbcDeduction"
            Me.tbcDeduction.SelectedIndex = 0
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
            Me.tbpCalculation.Controls.Add(Me.floCalculation)
            resources.ApplyResources(Me.tbpCalculation, "tbpCalculation")
            Me.tbpCalculation.Name = "tbpCalculation"
            Me.tbpCalculation.UseVisualStyleBackColor = True
            '
            'floCalculation
            '
            Me.floCalculation.BackColor = System.Drawing.Color.Transparent
            Me.floCalculation.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            resources.ApplyResources(Me.floCalculation, "floCalculation")
            Me.floCalculation.Controls.Add(Me.TableLayoutPanel2)
            Me.floCalculation.Name = "floCalculation"
            '
            'TableLayoutPanel2
            '
            resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
            Me.TableLayoutPanel2.Controls.Add(Me.CLabel2, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblMultiplier, 0, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.lblDefaultQty, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblCalculationType, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.cboCalculationType, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtRate, 1, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.txtDefaultQuantity, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblBasePayment, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.cboBasePaymentIdNo, 1, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.txtMultiplier, 1, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.cboMultiplierType, 2, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayRate, 2, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblRate, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.cboUnit, 3, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.cboDeductionType, 1, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
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
            Me.txtDefaultQuantity.LinkedLabel = Me.lblDefaultQty
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
            'lblPayRate
            '
            resources.ApplyResources(Me.lblPayRate, "lblPayRate")
            Me.lblPayRate.DisplayOnly = True
            Me.lblPayRate.EditingMode = False
            Me.lblPayRate.Name = "lblPayRate"
            '
            'lblRate
            '
            resources.ApplyResources(Me.lblRate, "lblRate")
            Me.lblRate.DisplayOnly = True
            Me.lblRate.EditingMode = False
            Me.lblRate.Name = "lblRate"
            '
            'cboUnit
            '
            Me.cboUnit.BackColor = System.Drawing.Color.White
            Me.cboUnit.ChangingSearchValueOnly = False
            Me.cboUnit.CurrentSearchTerm = ""
            Me.cboUnit.DefaultValue = Nothing
            Me.cboUnit.DisplayMember = "Name"
            resources.ApplyResources(Me.cboUnit, "cboUnit")
            Me.cboUnit.DropDownHeight = 200
            Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboUnit.EditingMode = True
            Me.cboUnit.FilterRule = Nothing
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
            'cboDeductionType
            '
            Me.cboDeductionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDeductionType.BackColor = System.Drawing.Color.White
            Me.cboDeductionType.ChangingSearchValueOnly = False
            Me.TableLayoutPanel2.SetColumnSpan(Me.cboDeductionType, 3)
            Me.cboDeductionType.CurrentSearchTerm = ""
            Me.cboDeductionType.DefaultValue = ""
            Me.cboDeductionType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboDeductionType, "cboDeductionType")
            Me.cboDeductionType.DropDownHeight = 1
            Me.cboDeductionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboDeductionType.EditingMode = False
            Me.cboDeductionType.FilterRule = Nothing
            Me.cboDeductionType.ForeColor = System.Drawing.Color.Black
            Me.cboDeductionType.HideWhenNotEditingOrAdding = False
            Me.cboDeductionType.LinkedLabel = Nothing
            Me.cboDeductionType.Name = "cboDeductionType"
            Me.cboDeductionType.OldValue = 0
            Me.cboDeductionType.OriginalDataSource = Nothing
            Me.cboDeductionType.OriginalList = Nothing
            Me.cboDeductionType.OverrideDropDownStyleList = False
            Me.cboDeductionType.PreviousSearchTerm = Nothing
            Me.cboDeductionType.PreviousSelectedIndex = 0
            Me.cboDeductionType.PropertySelector = Nothing
            Me.cboDeductionType.ReadOnlyCombo = False
            Me.cboDeductionType.SearchAnywhere = False
            Me.cboDeductionType.SuggestBoxHeight = 200
            Me.cboDeductionType.SuggestListOrderRule = Nothing
            Me.cboDeductionType.TextToSearch = Nothing
            Me.cboDeductionType.ValueIsMandatory = False
            Me.cboDeductionType.ValueIsNullable = False
            Me.cboDeductionType.ValueIsNumeric = False
            Me.cboDeductionType.ValueMember = "Code"
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
            Me.floPostingAccounts.Controls.Add(Me.tloPostingAccounts)
            resources.ApplyResources(Me.floPostingAccounts, "floPostingAccounts")
            Me.floPostingAccounts.Name = "floPostingAccounts"
            '
            'tloPostingAccounts
            '
            resources.ApplyResources(Me.tloPostingAccounts, "tloPostingAccounts")
            Me.tloPostingAccounts.Controls.Add(Me.lblAccountIdNo, 0, 1)
            Me.tloPostingAccounts.Controls.Add(Me.cboAccountIdNo, 1, 1)
            Me.tloPostingAccounts.Controls.Add(Me.DataGridViewPayrollDeductAccounts, 0, 2)
            Me.tloPostingAccounts.Controls.Add(Me.lblUsePayGroups, 0, 0)
            Me.tloPostingAccounts.Controls.Add(Me.chkUsePayGroups, 2, 0)
            Me.tloPostingAccounts.Name = "tloPostingAccounts"
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
            Me.tloPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
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
            'DataGridViewPayrollDeductAccounts
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollDeductAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayrollDeductAccounts.AutoGenerateColumns = False
            Me.DataGridViewPayrollDeductAccounts.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewPayrollDeductAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollDeductAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.DeductionIdNoDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
            Me.tloPostingAccounts.SetColumnSpan(Me.DataGridViewPayrollDeductAccounts, 3)
            Me.DataGridViewPayrollDeductAccounts.DataSource = Me.bsPayrollDeductAccounts
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayrollDeductAccounts.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewPayrollDeductAccounts.DgvFooter = Nothing
            Me.DataGridViewPayrollDeductAccounts.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPayrollDeductAccounts, "DataGridViewPayrollDeductAccounts")
            Me.DataGridViewPayrollDeductAccounts.Ea = EventAggregator1
            Me.DataGridViewPayrollDeductAccounts.EditingMode = False
            Me.DataGridViewPayrollDeductAccounts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollDeductAccounts.FieldsDictionary = Nothing
            Me.DataGridViewPayrollDeductAccounts.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollDeductAccounts.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollDeductAccounts.Name = "DataGridViewPayrollDeductAccounts"
            Me.DataGridViewPayrollDeductAccounts.ReadOnly = True
            Me.DataGridViewPayrollDeductAccounts.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollDeductAccounts.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollDeductAccounts.ShowFooter = False
            Me.DataGridViewPayrollDeductAccounts.ShowInsertColumnWhenEditing = True
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
            'DeductionIdNoDataGridViewTextBoxColumn
            '
            Me.DeductionIdNoDataGridViewTextBoxColumn.DataPropertyName = "DeductionIdNo"
            resources.ApplyResources(Me.DeductionIdNoDataGridViewTextBoxColumn, "DeductionIdNoDataGridViewTextBoxColumn")
            Me.DeductionIdNoDataGridViewTextBoxColumn.Name = "DeductionIdNoDataGridViewTextBoxColumn"
            Me.DeductionIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayGroupNameDataGridViewTextBoxColumn
            '
            Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
            resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
            Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
            Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'lblUsePayGroups
            '
            resources.ApplyResources(Me.lblUsePayGroups, "lblUsePayGroups")
            Me.tloPostingAccounts.SetColumnSpan(Me.lblUsePayGroups, 2)
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
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'DeductionEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "DeductionEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollDeductAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.tlpDeduction.ResumeLayout(False)
            Me.tlpDeduction.PerformLayout()
            Me.tbcDeduction.ResumeLayout(False)
            Me.tbpMain.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbpCalculation.ResumeLayout(False)
            Me.floCalculation.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.tbpAccountPosting.ResumeLayout(False)
            Me.floPostingAccounts.ResumeLayout(False)
            Me.tloPostingAccounts.ResumeLayout(False)
            Me.tloPostingAccounts.PerformLayout()
            CType(Me.DataGridViewPayrollDeductAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPayrollDeductAccounts As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents tlpDeduction As TableLayoutPanel
        Friend WithEvents txtDeductionNameAra As CTextBoxArabic
        Friend WithEvents txtDeductionName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtDeductionCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents tbcDeduction As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpCalculation As TabPage
        Friend WithEvents floCalculation As CFlowLayout
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
        Friend WithEvents txtMultiplier As CTextBox
        Friend WithEvents cboMultiplierType As CaComboBox
        Friend WithEvents cboUnit As CaComboBox
        Friend WithEvents lblPayRate As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents floPostingAccounts As CFlowLayout
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents tloPostingAccounts As TableLayoutPanel
        Friend WithEvents DataGridViewPayrollDeductAccounts As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DeductionIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents lblUsePayGroups As CLabel
        Friend WithEvents chkUsePayGroups As CCheckBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents cboDeductionType As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
    End Class
End Namespace