Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PaymentTypeEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentTypeEntryTv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpPaymentType = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPaymentTypeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtPaymentTypeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPaymentTypeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
        Me.floPostingAccounts = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tloPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewBankCharges = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.PayGroupNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.cboBankChargesAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblBankChargesAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbpMain = New System.Windows.Forms.TabPage()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.tbcPaymentType = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.tlpPaymentType.SuspendLayout
        Me.floDataDisplay.SuspendLayout
        Me.tbpAccountPosting.SuspendLayout
        Me.floPostingAccounts.SuspendLayout
        Me.tloPostingAccounts.SuspendLayout
        CType(Me.DataGridViewBankCharges,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpMain.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbcPaymentType.SuspendLayout
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
        Me.CFlowLayout4.Controls.Add(Me.tlpPaymentType)
        Me.CFlowLayout4.Controls.Add(Me.tbcPaymentType)
        resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
        Me.CFlowLayout4.Name = "CFlowLayout4"
        '
        'tlpPaymentType
        '
        resources.ApplyResources(Me.tlpPaymentType, "tlpPaymentType")
        Me.tlpPaymentType.Controls.Add(Me.txtPaymentTypeNameAra, 1, 2)
        Me.tlpPaymentType.Controls.Add(Me.lblName, 0, 1)
        Me.tlpPaymentType.Controls.Add(Me.txtPaymentTypeCode, 3, 0)
        Me.tlpPaymentType.Controls.Add(Me.lblCode, 2, 0)
        Me.tlpPaymentType.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.tlpPaymentType.Controls.Add(Me.CLabel1, 0, 0)
        Me.tlpPaymentType.Controls.Add(Me.txtPaymentTypeName, 1, 1)
        Me.tlpPaymentType.Controls.Add(Me.lblNameAra, 0, 2)
        Me.tlpPaymentType.Name = "tlpPaymentType"
        '
        'txtPaymentTypeNameAra
        '
        Me.txtPaymentTypeNameAra.BackColor = System.Drawing.Color.White
        Me.txtPaymentTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPaymentType.SetColumnSpan(Me.txtPaymentTypeNameAra, 3)
        Me.txtPaymentTypeNameAra.ComputedValue = false
        Me.txtPaymentTypeNameAra.CustomFormat = Nothing
        Me.txtPaymentTypeNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtPaymentTypeNameAra, "txtPaymentTypeNameAra")
        Me.txtPaymentTypeNameAra.EditingMode = false
        Me.txtPaymentTypeNameAra.EnglishControl = Me.txtPaymentTypeName
        Me.txtPaymentTypeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentTypeNameAra.LinkedLabel = Nothing
        Me.txtPaymentTypeNameAra.MaximumValue = Nothing
        Me.txtPaymentTypeNameAra.MinimumValue = Nothing
        Me.txtPaymentTypeNameAra.Name = "txtPaymentTypeNameAra"
        Me.txtPaymentTypeNameAra.OldValue = Nothing
        Me.txtPaymentTypeNameAra.ReadOnly = true
        '
        'txtPaymentTypeName
        '
        Me.txtPaymentTypeName.BackColor = System.Drawing.Color.White
        Me.txtPaymentTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPaymentType.SetColumnSpan(Me.txtPaymentTypeName, 3)
        Me.txtPaymentTypeName.ComputedValue = false
        Me.txtPaymentTypeName.CustomFormat = Nothing
        Me.txtPaymentTypeName.DataBoundControl = true
        resources.ApplyResources(Me.txtPaymentTypeName, "txtPaymentTypeName")
        Me.txtPaymentTypeName.EditingMode = false
        Me.txtPaymentTypeName.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPaymentTypeName, CType(resources.GetObject("txtPaymentTypeName.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtPaymentTypeName.LinkedLabel = Nothing
        Me.txtPaymentTypeName.MaximumValue = Nothing
        Me.txtPaymentTypeName.MinimumValue = Nothing
        Me.txtPaymentTypeName.Name = "txtPaymentTypeName"
        Me.txtPaymentTypeName.OldValue = Nothing
        Me.txtPaymentTypeName.ReadOnly = true
        Me.txtPaymentTypeName.ValueIsMandatory = true
        '
        'lblName
        '
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'txtPaymentTypeCode
        '
        Me.txtPaymentTypeCode.BackColor = System.Drawing.Color.White
        Me.txtPaymentTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentTypeCode.ComputedValue = false
        Me.txtPaymentTypeCode.CustomFormat = Nothing
        Me.txtPaymentTypeCode.DataBoundControl = true
        Me.txtPaymentTypeCode.EditingMode = true
        resources.ApplyResources(Me.txtPaymentTypeCode, "txtPaymentTypeCode")
        Me.txtPaymentTypeCode.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtPaymentTypeCode, CType(resources.GetObject("txtPaymentTypeCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.txtPaymentTypeCode, CType(resources.GetObject("txtPaymentTypeCode.IconPadding"),Integer))
        Me.txtPaymentTypeCode.LinkedLabel = Nothing
        Me.txtPaymentTypeCode.MaximumValue = Nothing
        Me.txtPaymentTypeCode.MinimumValue = Nothing
        Me.txtPaymentTypeCode.Name = "txtPaymentTypeCode"
        Me.txtPaymentTypeCode.OldValue = Nothing
        Me.txtPaymentTypeCode.ReadOnly = true
        Me.txtPaymentTypeCode.ValueIsMandatory = true
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
        Me.tloPostingAccounts.Controls.Add(Me.lblBankChargesAccountIdNo, 0, 1)
        Me.tloPostingAccounts.Controls.Add(Me.cboBankChargesAccountIdNo, 1, 1)
        Me.tloPostingAccounts.Controls.Add(Me.DataGridViewBankCharges, 0, 2)
        Me.tloPostingAccounts.Name = "tloPostingAccounts"
        '
        'DataGridViewBankCharges
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewBankCharges.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewBankCharges.AutoGenerateColumns = false
        Me.DataGridViewBankCharges.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewBankCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewBankCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPayGroupIdNo, Me.dgvAccountIdNo, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.PayGroupNameDataGridViewTextBoxColumn})
        Me.tloPostingAccounts.SetColumnSpan(Me.DataGridViewBankCharges, 3)
        Me.DataGridViewBankCharges.DataInGridChanged = false
        Me.DataGridViewBankCharges.DataSource = Me.bsPayrollEarnAccounts
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewBankCharges.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewBankCharges.DgvFooter = Nothing
        Me.DataGridViewBankCharges.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewBankCharges, "DataGridViewBankCharges")
        Me.DataGridViewBankCharges.Ea = EventAggregator1
        Me.DataGridViewBankCharges.EditingMode = false
        Me.DataGridViewBankCharges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewBankCharges.FirstRowDeletionEnabled = true
        Me.DataGridViewBankCharges.FirstRowInsertionEnabled = true
        Me.DataGridViewBankCharges.Name = "DataGridViewBankCharges"
        Me.DataGridViewBankCharges.ReadOnly = true
        Me.DataGridViewBankCharges.SequenceColumn = "dgvSequence"
        Me.DataGridViewBankCharges.SequenceFieldName = "Sequence"
        Me.DataGridViewBankCharges.ShowFooter = false
        Me.DataGridViewBankCharges.ShowInsertColumnWhenEditing = true
        Me.DataGridViewBankCharges.StartTrackingChanges = false
        '
        'PayGroupNameDataGridViewTextBoxColumn
        '
        Me.PayGroupNameDataGridViewTextBoxColumn.DataPropertyName = "PayGroupName"
        resources.ApplyResources(Me.PayGroupNameDataGridViewTextBoxColumn, "PayGroupNameDataGridViewTextBoxColumn")
        Me.PayGroupNameDataGridViewTextBoxColumn.Name = "PayGroupNameDataGridViewTextBoxColumn"
        Me.PayGroupNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
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
        'cboBankChargesAccountIdNo
        '
        Me.cboBankChargesAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankChargesAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboBankChargesAccountIdNo.ChangingSearchValueOnly = false
        Me.tloPostingAccounts.SetColumnSpan(Me.cboBankChargesAccountIdNo, 2)
        Me.cboBankChargesAccountIdNo.CurrentSearchTerm = ""
        Me.cboBankChargesAccountIdNo.DefaultValue = Nothing
        Me.cboBankChargesAccountIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboBankChargesAccountIdNo, "cboBankChargesAccountIdNo")
        Me.cboBankChargesAccountIdNo.DropDownHeight = 1
        Me.cboBankChargesAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankChargesAccountIdNo.EditingMode = false
        Me.cboBankChargesAccountIdNo.FilterRule = Nothing
        Me.cboBankChargesAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBankChargesAccountIdNo.FormattingEnabled = true
        Me.cboBankChargesAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBankChargesAccountIdNo.LinkedLabel = Nothing
        Me.cboBankChargesAccountIdNo.Name = "cboBankChargesAccountIdNo"
        Me.cboBankChargesAccountIdNo.OldValue = 0
        Me.cboBankChargesAccountIdNo.OriginalDataSource = Nothing
        Me.cboBankChargesAccountIdNo.OriginalList = Nothing
        Me.cboBankChargesAccountIdNo.OverrideDropDownStyleList = false
        Me.cboBankChargesAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboBankChargesAccountIdNo.PreviousSelectedIndex = -1
        Me.cboBankChargesAccountIdNo.PropertySelector = Nothing
        Me.cboBankChargesAccountIdNo.ReadOnlyCombo = false
        Me.cboBankChargesAccountIdNo.SearchAnywhere = false
        Me.cboBankChargesAccountIdNo.SuggestBoxHeight = 200
        Me.cboBankChargesAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboBankChargesAccountIdNo.TextToSearch = Nothing
        Me.cboBankChargesAccountIdNo.ValueIsMandatory = false
        Me.cboBankChargesAccountIdNo.ValueIsNullable = false
        Me.cboBankChargesAccountIdNo.ValueIsNumeric = false
        Me.cboBankChargesAccountIdNo.ValueMember = "IdNo"
        '
        'lblBankChargesAccountIdNo
        '
        Me.lblBankChargesAccountIdNo.DisplayOnly = true
        resources.ApplyResources(Me.lblBankChargesAccountIdNo, "lblBankChargesAccountIdNo")
        Me.lblBankChargesAccountIdNo.EditingMode = false
        Me.lblBankChargesAccountIdNo.Name = "lblBankChargesAccountIdNo"
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
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
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
        'tbcPaymentType
        '
        Me.tbcPaymentType.Controls.Add(Me.tbpMain)
        Me.tbcPaymentType.Controls.Add(Me.tbpAccountPosting)
        resources.ApplyResources(Me.tbcPaymentType, "tbcPaymentType")
        Me.tbcPaymentType.Name = "tbcPaymentType"
        Me.tbcPaymentType.SelectedIndex = 0
        '
        'PaymentTypeEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PaymentTypeEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayrollEarnAccounts,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.tlpPaymentType.ResumeLayout(false)
        Me.tlpPaymentType.PerformLayout
        Me.floDataDisplay.ResumeLayout(false)
        Me.tbpAccountPosting.ResumeLayout(false)
        Me.floPostingAccounts.ResumeLayout(false)
        Me.tloPostingAccounts.ResumeLayout(false)
        CType(Me.DataGridViewBankCharges,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpMain.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbcPaymentType.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsPayrollEarnAccounts As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents tlpPaymentType As TableLayoutPanel
        Friend WithEvents txtPaymentTypeNameAra As CTextBoxArabic
        Friend WithEvents txtPaymentTypeName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtPaymentTypeCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents PaymentTypeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tbcPaymentType As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents floPostingAccounts As CFlowLayout
        Friend WithEvents tloPostingAccounts As TableLayoutPanel
        Friend WithEvents lblBankChargesAccountIdNo As CLabel
        Friend WithEvents cboBankChargesAccountIdNo As CaComboBox
        Friend WithEvents DataGridViewBankCharges As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvPayGroupIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace