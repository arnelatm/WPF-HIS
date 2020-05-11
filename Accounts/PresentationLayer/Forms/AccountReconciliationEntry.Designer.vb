Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountReconciliationEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountReconciliationEntry))
        Dim CBlendItems1 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpReconciliationDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalOutstandingCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalQtyCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalQtyDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTotalCreditsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout5 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalQtyCreditsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalCreditsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalQtyDebitsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTotalDebitsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalDebitsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout7 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnPost = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout6 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblEndingBankBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBalance2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTotalDepositsInTransit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalOutstandingDeposits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblOutstandingCredits = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGlSystemBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGlSystemBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblUnreconciledDifference = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUnreconciledDifference = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CsrOiItemModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewReconciliationItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDocumentNumber = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCleared = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvPayDescription = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAccountReconciliationIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsAccountReconciliationItems = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floHeader.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            Me.CFlowLayout5.SuspendLayout()
            Me.CFlowLayout7.SuspendLayout()
            Me.CFlowLayout6.SuspendLayout()
            CType(Me.CsrOiItemModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            CType(Me.DataGridViewReconciliationItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsAccountReconciliationItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'floHeader
            '
            Me.floHeader.BackColor = System.Drawing.Color.Transparent
            Me.floHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floHeader.Controls.Add(Me.CFlowLayout1)
            resources.ApplyResources(Me.floHeader, "floHeader")
            Me.floHeader.Name = "floHeader"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpReconciliationDate)
            Me.CFlowLayout1.Controls.Add(Me.lblBalance)
            Me.CFlowLayout1.Controls.Add(Me.txtBalance)
            Me.CFlowLayout1.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout1.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout1.Controls.Add(Me.lblNotes)
            Me.CFlowLayout1.Controls.Add(Me.cboAccountIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblPosted)
            Me.CFlowLayout1.Controls.Add(Me.chkPosted)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
            Me.lblTransactionDate.Name = "lblTransactionDate"
            '
            'dtpReconciliationDate
            '
            Me.dtpReconciliationDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpReconciliationDate.DefaultValue = Nothing
            Me.dtpReconciliationDate.DisplayOnly = False
            Me.dtpReconciliationDate.DtpDefaultValue = Nothing
            Me.dtpReconciliationDate.EditingMode = False
            Me.dtpReconciliationDate.EditsAllowed = False
            resources.ApplyResources(Me.dtpReconciliationDate, "dtpReconciliationDate")
            Me.dtpReconciliationDate.ForeColor = System.Drawing.Color.Black
            Me.dtpReconciliationDate.LinkedLabel = Nothing
            Me.dtpReconciliationDate.Name = "dtpReconciliationDate"
            Me.dtpReconciliationDate.ReadOnlyDp = False
            Me.dtpReconciliationDate.SecurityKey = Nothing
            Me.dtpReconciliationDate.ShowLongDate = False
            Me.dtpReconciliationDate.ShowTime = False
            Me.dtpReconciliationDate.TargetCalendar = CType(resources.GetObject("dtpReconciliationDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpReconciliationDate.Value = Nothing
            Me.dtpReconciliationDate.ValueIsMandatory = False
            Me.dtpReconciliationDate.ValueIsNullable = False
            '
            'lblBalance
            '
            Me.lblBalance.BackColor = System.Drawing.Color.Transparent
            Me.lblBalance.DisplayOnly = True
            Me.lblBalance.EditingMode = False
            resources.ApplyResources(Me.lblBalance, "lblBalance")
            Me.lblBalance.Name = "lblBalance"
            '
            'txtBalance
            '
            Me.txtBalance.AcceptsTab = True
            Me.txtBalance.BackColor = System.Drawing.Color.White
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = True
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.EditingMode = True
            resources.ApplyResources(Me.txtBalance, "txtBalance")
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Nothing
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.TabStop = False
            Me.txtBalance.ValueIsMandatory = True
            '
            'lblDateAdded
            '
            Me.lblDateAdded.BackColor = System.Drawing.Color.Transparent
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            resources.ApplyResources(Me.lblDateAdded, "lblDateAdded")
            Me.lblDateAdded.Name = "lblDateAdded"
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = True
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.EditingMode = True
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 200
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = 0
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
            'lblPosted
            '
            Me.lblPosted.BackColor = System.Drawing.Color.Transparent
            Me.lblPosted.DisplayOnly = True
            Me.lblPosted.EditingMode = False
            resources.ApplyResources(Me.lblPosted, "lblPosted")
            Me.lblPosted.Name = "lblPosted"
            '
            'chkPosted
            '
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = False
            Me.chkPosted.FlatAppearance.BorderSize = 0
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.TabStop = False
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblAmount, True)
            resources.ApplyResources(Me.lblAmount, "lblAmount")
            Me.lblAmount.Name = "lblAmount"
            '
            'txtTotalOutstandingCredits
            '
            Me.txtTotalOutstandingCredits.BackColor = System.Drawing.Color.White
            Me.txtTotalOutstandingCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalOutstandingCredits.ComputedValue = True
            Me.txtTotalOutstandingCredits.CustomFormat = Nothing
            Me.txtTotalOutstandingCredits.DataBoundControl = True
            Me.txtTotalOutstandingCredits.DisplayOnly = True
            Me.txtTotalOutstandingCredits.EditingMode = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtTotalOutstandingCredits, True)
            resources.ApplyResources(Me.txtTotalOutstandingCredits, "txtTotalOutstandingCredits")
            Me.txtTotalOutstandingCredits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalOutstandingCredits.LinkedLabel = Nothing
            Me.txtTotalOutstandingCredits.MaximumValue = Nothing
            Me.txtTotalOutstandingCredits.MinimumValue = Nothing
            Me.txtTotalOutstandingCredits.Name = "txtTotalOutstandingCredits"
            Me.txtTotalOutstandingCredits.OldValue = Nothing
            Me.txtTotalOutstandingCredits.ReadOnly = True
            Me.txtTotalOutstandingCredits.TabStop = False
            Me.txtTotalOutstandingCredits.ValueIsMandatory = True
            '
            'txtTotalQtyCreditsCleared
            '
            Me.txtTotalQtyCreditsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyCreditsCleared.ComputedValue = True
            Me.txtTotalQtyCreditsCleared.CustomFormat = Nothing
            Me.txtTotalQtyCreditsCleared.DataBoundControl = True
            Me.txtTotalQtyCreditsCleared.DisplayOnly = True
            Me.txtTotalQtyCreditsCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalQtyCreditsCleared, "txtTotalQtyCreditsCleared")
            Me.txtTotalQtyCreditsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyCreditsCleared.LinkedLabel = Me.lblCreditsCleared
            Me.txtTotalQtyCreditsCleared.MaximumValue = Nothing
            Me.txtTotalQtyCreditsCleared.MinimumValue = Nothing
            Me.txtTotalQtyCreditsCleared.Name = "txtTotalQtyCreditsCleared"
            Me.txtTotalQtyCreditsCleared.OldValue = Nothing
            Me.txtTotalQtyCreditsCleared.ReadOnly = True
            Me.txtTotalQtyCreditsCleared.TabStop = False
            Me.txtTotalQtyCreditsCleared.ValueIsMandatory = True
            '
            'lblCreditsCleared
            '
            Me.lblCreditsCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblCreditsCleared.DisplayOnly = True
            Me.lblCreditsCleared.EditingMode = False
            resources.ApplyResources(Me.lblCreditsCleared, "lblCreditsCleared")
            Me.lblCreditsCleared.Name = "lblCreditsCleared"
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.CFlowLayout2)
            Me.CFlowLayout3.Controls.Add(Me.CFlowLayout5)
            Me.CFlowLayout3.Controls.Add(Me.CFlowLayout6)
            resources.ApplyResources(Me.CFlowLayout3, "CFlowLayout3")
            Me.CFlowLayout3.Name = "CFlowLayout3"
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblAmount)
            Me.CFlowLayout2.Controls.Add(Me.lblDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.lblCreditsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyCreditsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalCreditsCleared)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'lblDebitsCleared
            '
            Me.lblDebitsCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblDebitsCleared.DisplayOnly = True
            Me.lblDebitsCleared.EditingMode = False
            resources.ApplyResources(Me.lblDebitsCleared, "lblDebitsCleared")
            Me.lblDebitsCleared.Name = "lblDebitsCleared"
            '
            'txtTotalQtyDebitsCleared
            '
            Me.txtTotalQtyDebitsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyDebitsCleared.ComputedValue = True
            Me.txtTotalQtyDebitsCleared.CustomFormat = Nothing
            Me.txtTotalQtyDebitsCleared.DataBoundControl = True
            Me.txtTotalQtyDebitsCleared.DisplayOnly = True
            Me.txtTotalQtyDebitsCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalQtyDebitsCleared, "txtTotalQtyDebitsCleared")
            Me.txtTotalQtyDebitsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyDebitsCleared.LinkedLabel = Me.lblDebitsCleared
            Me.txtTotalQtyDebitsCleared.MaximumValue = Nothing
            Me.txtTotalQtyDebitsCleared.MinimumValue = Nothing
            Me.txtTotalQtyDebitsCleared.Name = "txtTotalQtyDebitsCleared"
            Me.txtTotalQtyDebitsCleared.OldValue = Nothing
            Me.txtTotalQtyDebitsCleared.ReadOnly = True
            Me.txtTotalQtyDebitsCleared.TabStop = False
            Me.txtTotalQtyDebitsCleared.ValueIsMandatory = True
            '
            'txtTotalDebitsCleared
            '
            Me.txtTotalDebitsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDebitsCleared.ComputedValue = True
            Me.txtTotalDebitsCleared.CustomFormat = Nothing
            Me.txtTotalDebitsCleared.DataBoundControl = True
            Me.txtTotalDebitsCleared.DisplayOnly = True
            Me.txtTotalDebitsCleared.EditingMode = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtTotalDebitsCleared, True)
            resources.ApplyResources(Me.txtTotalDebitsCleared, "txtTotalDebitsCleared")
            Me.txtTotalDebitsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebitsCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
            Me.txtTotalDebitsCleared.MaximumValue = Nothing
            Me.txtTotalDebitsCleared.MinimumValue = Nothing
            Me.txtTotalDebitsCleared.Name = "txtTotalDebitsCleared"
            Me.txtTotalDebitsCleared.OldValue = Nothing
            Me.txtTotalDebitsCleared.ReadOnly = True
            Me.txtTotalDebitsCleared.TabStop = False
            Me.txtTotalDebitsCleared.ValueIsMandatory = True
            '
            'lblTotalCreditsNotCleared
            '
            Me.lblTotalCreditsNotCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalCreditsNotCleared.DisplayOnly = True
            Me.lblTotalCreditsNotCleared.EditingMode = False
            resources.ApplyResources(Me.lblTotalCreditsNotCleared, "lblTotalCreditsNotCleared")
            Me.lblTotalCreditsNotCleared.Name = "lblTotalCreditsNotCleared"
            '
            'txtTotalCreditsCleared
            '
            Me.txtTotalCreditsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCreditsCleared.ComputedValue = True
            Me.txtTotalCreditsCleared.CustomFormat = Nothing
            Me.txtTotalCreditsCleared.DataBoundControl = True
            Me.txtTotalCreditsCleared.DisplayOnly = True
            Me.txtTotalCreditsCleared.EditingMode = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtTotalCreditsCleared, True)
            resources.ApplyResources(Me.txtTotalCreditsCleared, "txtTotalCreditsCleared")
            Me.txtTotalCreditsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCreditsCleared.LinkedLabel = Me.lblCreditsCleared
            Me.txtTotalCreditsCleared.MaximumValue = Nothing
            Me.txtTotalCreditsCleared.MinimumValue = Nothing
            Me.txtTotalCreditsCleared.Name = "txtTotalCreditsCleared"
            Me.txtTotalCreditsCleared.OldValue = Nothing
            Me.txtTotalCreditsCleared.ReadOnly = True
            Me.txtTotalCreditsCleared.TabStop = False
            Me.txtTotalCreditsCleared.ValueIsMandatory = True
            '
            'CFlowLayout5
            '
            Me.CFlowLayout5.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout5.Controls.Add(Me.CLabel9)
            Me.CFlowLayout5.Controls.Add(Me.txtTotalQtyCreditsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.lblTotalCreditsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.txtTotalCreditsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.txtTotalQtyDebitsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.lblTotalDebitsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.txtTotalDebitsNotCleared)
            Me.CFlowLayout5.Controls.Add(Me.CFlowLayout7)
            resources.ApplyResources(Me.CFlowLayout5, "CFlowLayout5")
            Me.CFlowLayout5.Name = "CFlowLayout5"
            '
            'CLabel9
            '
            Me.CLabel9.BackColor = System.Drawing.Color.Transparent
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.EditingMode = False
            Me.CFlowLayout5.SetFlowBreak(Me.CLabel9, True)
            resources.ApplyResources(Me.CLabel9, "CLabel9")
            Me.CLabel9.Name = "CLabel9"
            '
            'txtTotalQtyCreditsNotCleared
            '
            Me.txtTotalQtyCreditsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyCreditsNotCleared.ComputedValue = True
            Me.txtTotalQtyCreditsNotCleared.CustomFormat = Nothing
            Me.txtTotalQtyCreditsNotCleared.DataBoundControl = True
            Me.txtTotalQtyCreditsNotCleared.DisplayOnly = True
            Me.txtTotalQtyCreditsNotCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalQtyCreditsNotCleared, "txtTotalQtyCreditsNotCleared")
            Me.txtTotalQtyCreditsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyCreditsNotCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
            Me.txtTotalQtyCreditsNotCleared.MaximumValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.MinimumValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.Name = "txtTotalQtyCreditsNotCleared"
            Me.txtTotalQtyCreditsNotCleared.OldValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.ReadOnly = True
            Me.txtTotalQtyCreditsNotCleared.TabStop = False
            Me.txtTotalQtyCreditsNotCleared.ValueIsMandatory = True
            '
            'txtTotalCreditsNotCleared
            '
            Me.txtTotalCreditsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCreditsNotCleared.ComputedValue = True
            Me.txtTotalCreditsNotCleared.CustomFormat = Nothing
            Me.txtTotalCreditsNotCleared.DataBoundControl = True
            Me.txtTotalCreditsNotCleared.DisplayOnly = True
            Me.txtTotalCreditsNotCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalCreditsNotCleared, "txtTotalCreditsNotCleared")
            Me.txtTotalCreditsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCreditsNotCleared.LinkedLabel = Me.lblDebitsCleared
            Me.txtTotalCreditsNotCleared.MaximumValue = Nothing
            Me.txtTotalCreditsNotCleared.MinimumValue = Nothing
            Me.txtTotalCreditsNotCleared.Name = "txtTotalCreditsNotCleared"
            Me.txtTotalCreditsNotCleared.OldValue = Nothing
            Me.txtTotalCreditsNotCleared.ReadOnly = True
            Me.txtTotalCreditsNotCleared.ValueIsMandatory = True
            '
            'txtTotalQtyDebitsNotCleared
            '
            Me.txtTotalQtyDebitsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyDebitsNotCleared.ComputedValue = True
            Me.txtTotalQtyDebitsNotCleared.CustomFormat = Nothing
            Me.txtTotalQtyDebitsNotCleared.DataBoundControl = True
            Me.txtTotalQtyDebitsNotCleared.DisplayOnly = True
            Me.txtTotalQtyDebitsNotCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalQtyDebitsNotCleared, "txtTotalQtyDebitsNotCleared")
            Me.txtTotalQtyDebitsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
            Me.txtTotalQtyDebitsNotCleared.MaximumValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.MinimumValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.Name = "txtTotalQtyDebitsNotCleared"
            Me.txtTotalQtyDebitsNotCleared.OldValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.ReadOnly = True
            Me.txtTotalQtyDebitsNotCleared.TabStop = False
            Me.txtTotalQtyDebitsNotCleared.ValueIsMandatory = True
            '
            'lblTotalDebitsNotCleared
            '
            Me.lblTotalDebitsNotCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalDebitsNotCleared.DisplayOnly = True
            Me.lblTotalDebitsNotCleared.EditingMode = False
            resources.ApplyResources(Me.lblTotalDebitsNotCleared, "lblTotalDebitsNotCleared")
            Me.lblTotalDebitsNotCleared.Name = "lblTotalDebitsNotCleared"
            '
            'txtTotalDebitsNotCleared
            '
            Me.txtTotalDebitsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDebitsNotCleared.ComputedValue = True
            Me.txtTotalDebitsNotCleared.CustomFormat = Nothing
            Me.txtTotalDebitsNotCleared.DataBoundControl = True
            Me.txtTotalDebitsNotCleared.DisplayOnly = True
            Me.txtTotalDebitsNotCleared.EditingMode = True
            resources.ApplyResources(Me.txtTotalDebitsNotCleared, "txtTotalDebitsNotCleared")
            Me.txtTotalDebitsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
            Me.txtTotalDebitsNotCleared.MaximumValue = Nothing
            Me.txtTotalDebitsNotCleared.MinimumValue = Nothing
            Me.txtTotalDebitsNotCleared.Name = "txtTotalDebitsNotCleared"
            Me.txtTotalDebitsNotCleared.OldValue = Nothing
            Me.txtTotalDebitsNotCleared.ReadOnly = True
            Me.txtTotalDebitsNotCleared.TabStop = False
            Me.txtTotalDebitsNotCleared.ValueIsMandatory = True
            '
            'CFlowLayout7
            '
            Me.CFlowLayout7.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout7.Controls.Add(Me.btnPost)
            resources.ApplyResources(Me.CFlowLayout7, "CFlowLayout7")
            Me.CFlowLayout7.Name = "CFlowLayout7"
            '
            'btnPost
            '
            CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.White}
            CBlendItems1.iPoint = New Single() {0!, 1.006211!, 1.0!}
            Me.btnPost.ColorFillBlend = CBlendItems1
            Me.btnPost.DesignerSelected = True
            Me.btnPost.DisplayOnly = True
            Me.btnPost.ImageIndex = 0
            resources.ApplyResources(Me.btnPost, "btnPost")
            Me.btnPost.Name = "btnPost"
            Me.btnPost.OriginalImageName = Nothing
            Me.btnPost.SecurityKey = ""
            '
            'CFlowLayout6
            '
            Me.CFlowLayout6.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout6.Controls.Add(Me.lblEndingBankBalance)
            Me.CFlowLayout6.Controls.Add(Me.txtBalance2)
            Me.CFlowLayout6.Controls.Add(Me.lblTotalDepositsInTransit)
            Me.CFlowLayout6.Controls.Add(Me.txtTotalOutstandingDeposits)
            Me.CFlowLayout6.Controls.Add(Me.lblOutstandingCredits)
            Me.CFlowLayout6.Controls.Add(Me.txtTotalOutstandingCredits)
            Me.CFlowLayout6.Controls.Add(Me.lblGlSystemBalance)
            Me.CFlowLayout6.Controls.Add(Me.txtGlSystemBalance)
            Me.CFlowLayout6.Controls.Add(Me.CLabel7)
            Me.CFlowLayout6.Controls.Add(Me.lblUnreconciledDifference)
            Me.CFlowLayout6.Controls.Add(Me.txtUnreconciledDifference)
            resources.ApplyResources(Me.CFlowLayout6, "CFlowLayout6")
            Me.CFlowLayout6.Name = "CFlowLayout6"
            '
            'lblEndingBankBalance
            '
            Me.lblEndingBankBalance.BackColor = System.Drawing.Color.Transparent
            Me.lblEndingBankBalance.DisplayOnly = True
            Me.lblEndingBankBalance.EditingMode = False
            resources.ApplyResources(Me.lblEndingBankBalance, "lblEndingBankBalance")
            Me.lblEndingBankBalance.Name = "lblEndingBankBalance"
            '
            'txtBalance2
            '
            Me.txtBalance2.BackColor = System.Drawing.Color.White
            Me.txtBalance2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance2.ComputedValue = True
            Me.txtBalance2.CustomFormat = Nothing
            Me.txtBalance2.DataBoundControl = True
            Me.txtBalance2.DisplayOnly = True
            Me.txtBalance2.EditingMode = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtBalance2, True)
            resources.ApplyResources(Me.txtBalance2, "txtBalance2")
            Me.txtBalance2.ForeColor = System.Drawing.Color.Black
            Me.txtBalance2.LinkedLabel = Nothing
            Me.txtBalance2.MaximumValue = Nothing
            Me.txtBalance2.MinimumValue = Nothing
            Me.txtBalance2.Name = "txtBalance2"
            Me.txtBalance2.OldValue = Nothing
            Me.txtBalance2.ReadOnly = True
            Me.txtBalance2.TabStop = False
            Me.txtBalance2.ValueIsMandatory = True
            '
            'lblTotalDepositsInTransit
            '
            Me.lblTotalDepositsInTransit.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalDepositsInTransit.DisplayOnly = True
            Me.lblTotalDepositsInTransit.EditingMode = False
            resources.ApplyResources(Me.lblTotalDepositsInTransit, "lblTotalDepositsInTransit")
            Me.lblTotalDepositsInTransit.Name = "lblTotalDepositsInTransit"
            '
            'txtTotalOutstandingDeposits
            '
            Me.txtTotalOutstandingDeposits.BackColor = System.Drawing.Color.White
            Me.txtTotalOutstandingDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalOutstandingDeposits.ComputedValue = True
            Me.txtTotalOutstandingDeposits.CustomFormat = Nothing
            Me.txtTotalOutstandingDeposits.DataBoundControl = True
            Me.txtTotalOutstandingDeposits.DisplayOnly = True
            Me.txtTotalOutstandingDeposits.EditingMode = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtTotalOutstandingDeposits, True)
            resources.ApplyResources(Me.txtTotalOutstandingDeposits, "txtTotalOutstandingDeposits")
            Me.txtTotalOutstandingDeposits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalOutstandingDeposits.LinkedLabel = Nothing
            Me.txtTotalOutstandingDeposits.MaximumValue = Nothing
            Me.txtTotalOutstandingDeposits.MinimumValue = Nothing
            Me.txtTotalOutstandingDeposits.Name = "txtTotalOutstandingDeposits"
            Me.txtTotalOutstandingDeposits.OldValue = Nothing
            Me.txtTotalOutstandingDeposits.ReadOnly = True
            Me.txtTotalOutstandingDeposits.TabStop = False
            Me.txtTotalOutstandingDeposits.ValueIsMandatory = True
            '
            'lblOutstandingCredits
            '
            Me.lblOutstandingCredits.BackColor = System.Drawing.Color.Transparent
            Me.lblOutstandingCredits.DisplayOnly = True
            Me.lblOutstandingCredits.EditingMode = False
            resources.ApplyResources(Me.lblOutstandingCredits, "lblOutstandingCredits")
            Me.lblOutstandingCredits.Name = "lblOutstandingCredits"
            '
            'lblGlSystemBalance
            '
            Me.lblGlSystemBalance.BackColor = System.Drawing.Color.Transparent
            Me.lblGlSystemBalance.DisplayOnly = True
            Me.lblGlSystemBalance.EditingMode = False
            resources.ApplyResources(Me.lblGlSystemBalance, "lblGlSystemBalance")
            Me.lblGlSystemBalance.Name = "lblGlSystemBalance"
            '
            'txtGlSystemBalance
            '
            Me.txtGlSystemBalance.BackColor = System.Drawing.Color.White
            Me.txtGlSystemBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGlSystemBalance.ComputedValue = True
            Me.txtGlSystemBalance.CustomFormat = Nothing
            Me.txtGlSystemBalance.DataBoundControl = True
            Me.txtGlSystemBalance.DisplayOnly = True
            Me.txtGlSystemBalance.EditingMode = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtGlSystemBalance, True)
            resources.ApplyResources(Me.txtGlSystemBalance, "txtGlSystemBalance")
            Me.txtGlSystemBalance.ForeColor = System.Drawing.Color.Black
            Me.txtGlSystemBalance.LinkedLabel = Nothing
            Me.txtGlSystemBalance.MaximumValue = Nothing
            Me.txtGlSystemBalance.MinimumValue = Nothing
            Me.txtGlSystemBalance.Name = "txtGlSystemBalance"
            Me.txtGlSystemBalance.OldValue = Nothing
            Me.txtGlSystemBalance.ReadOnly = True
            Me.txtGlSystemBalance.TabStop = False
            Me.txtGlSystemBalance.ValueIsMandatory = True
            '
            'CLabel7
            '
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.CLabel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            resources.ApplyResources(Me.CLabel7, "CLabel7")
            Me.CLabel7.Name = "CLabel7"
            '
            'lblUnreconciledDifference
            '
            Me.lblUnreconciledDifference.BackColor = System.Drawing.Color.Transparent
            Me.lblUnreconciledDifference.DisplayOnly = True
            Me.lblUnreconciledDifference.EditingMode = False
            resources.ApplyResources(Me.lblUnreconciledDifference, "lblUnreconciledDifference")
            Me.lblUnreconciledDifference.Name = "lblUnreconciledDifference"
            '
            'txtUnreconciledDifference
            '
            Me.txtUnreconciledDifference.BackColor = System.Drawing.Color.White
            Me.txtUnreconciledDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnreconciledDifference.ComputedValue = True
            Me.txtUnreconciledDifference.CustomFormat = Nothing
            Me.txtUnreconciledDifference.DataBoundControl = True
            Me.txtUnreconciledDifference.DisplayOnly = True
            Me.txtUnreconciledDifference.EditingMode = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtUnreconciledDifference, True)
            resources.ApplyResources(Me.txtUnreconciledDifference, "txtUnreconciledDifference")
            Me.txtUnreconciledDifference.ForeColor = System.Drawing.Color.Black
            Me.txtUnreconciledDifference.LinkedLabel = Nothing
            Me.txtUnreconciledDifference.MaximumValue = Nothing
            Me.txtUnreconciledDifference.MinimumValue = Nothing
            Me.txtUnreconciledDifference.Name = "txtUnreconciledDifference"
            Me.txtUnreconciledDifference.OldValue = Nothing
            Me.txtUnreconciledDifference.ReadOnly = True
            Me.txtUnreconciledDifference.TabStop = False
            Me.txtUnreconciledDifference.ValueIsMandatory = True
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.floHeader)
            Me.CFlowLayout4.Controls.Add(Me.DataGridViewReconciliationItems)
            Me.CFlowLayout4.Controls.Add(Me.CFlowLayout3)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'DataGridViewReconciliationItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewReconciliationItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewReconciliationItems.AutoGenerateColumns = False
            Me.DataGridViewReconciliationItems.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewReconciliationItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewReconciliationItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvReferenceNo, Me.dgvJournalIdNo, Me.dgvDocumentNumber, Me.dgvDebit, Me.dgvCredit, Me.dgvCleared, Me.dgvPayDescription, Me.dgvAccountReconciliationIdNo})
            Me.DataGridViewReconciliationItems.DataInGridChanged = False
            Me.DataGridViewReconciliationItems.DataSource = Me.bsAccountReconciliationItems
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewReconciliationItems.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewReconciliationItems.DisplayOnly = False
            Me.DataGridViewReconciliationItems.EditingMode = False
            Me.DataGridViewReconciliationItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            resources.ApplyResources(Me.DataGridViewReconciliationItems, "DataGridViewReconciliationItems")
            Me.DataGridViewReconciliationItems.Name = "DataGridViewReconciliationItems"
            Me.DataGridViewReconciliationItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewReconciliationItems.StartTrackingChanges = False
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
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTransactionDate.EditingMode = False
            resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvJournalCode.EditingMode = False
            resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvReferenceNo
            '
            Me.dgvReferenceNo.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvReferenceNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvReferenceNo.EditingMode = False
            resources.ApplyResources(Me.dgvReferenceNo, "dgvReferenceNo")
            Me.dgvReferenceNo.Name = "dgvReferenceNo"
            '
            'dgvJournalIdNo
            '
            Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvJournalIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
            Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
            '
            'dgvDocumentNumber
            '
            Me.dgvDocumentNumber.DataPropertyName = "DocumentNumber"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvDocumentNumber.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDocumentNumber.DisplayOnly = True
            Me.dgvDocumentNumber.EditingMode = False
            resources.ApplyResources(Me.dgvDocumentNumber, "dgvDocumentNumber")
            Me.dgvDocumentNumber.Name = "dgvDocumentNumber"
            Me.dgvDocumentNumber.ReadOnly = True
            '
            'dgvDebit
            '
            Me.dgvDebit.DataPropertyName = "Debit"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDebit.EditingMode = False
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvCredit
            '
            Me.dgvCredit.DataPropertyName = "Credit"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvCredit.EditingMode = False
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvCleared
            '
            Me.dgvCleared.DataPropertyName = "Cleared"
            resources.ApplyResources(Me.dgvCleared, "dgvCleared")
            Me.dgvCleared.Name = "dgvCleared"
            '
            'dgvPayDescription
            '
            Me.dgvPayDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvPayDescription.DataPropertyName = "PayDescription"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvPayDescription.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvPayDescription.DisplayOnly = True
            Me.dgvPayDescription.EditingMode = False
            Me.dgvPayDescription.FillWeight = 10.0!
            resources.ApplyResources(Me.dgvPayDescription, "dgvPayDescription")
            Me.dgvPayDescription.Name = "dgvPayDescription"
            Me.dgvPayDescription.ReadOnly = True
            Me.dgvPayDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvAccountReconciliationIdNo
            '
            Me.dgvAccountReconciliationIdNo.DataPropertyName = "AccountReconciliationIdNo"
            resources.ApplyResources(Me.dgvAccountReconciliationIdNo, "dgvAccountReconciliationIdNo")
            Me.dgvAccountReconciliationIdNo.Name = "dgvAccountReconciliationIdNo"
            '
            'AccountReconciliationEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CFlowLayout4)
            Me.Name = "AccountReconciliationEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floHeader.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.CFlowLayout5.ResumeLayout(false)
        Me.CFlowLayout5.PerformLayout
        Me.CFlowLayout7.ResumeLayout(false)
        Me.CFlowLayout6.ResumeLayout(false)
        Me.CFlowLayout6.PerformLayout
        CType(Me.CsrOiItemModelBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        CType(Me.DataGridViewReconciliationItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsAccountReconciliationItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floHeader As CFlowLayout
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpReconciliationDate As CCustomDateTimePicker
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtTotalOutstandingCredits As CTextBox
        Friend WithEvents txtTotalQtyCreditsCleared As CTextBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblEndingBankBalance As CLabel
        Friend WithEvents lblCreditsCleared As CLabel
        Friend WithEvents txtTotalCreditsCleared As CTextBox
        Friend WithEvents lblOutstandingCredits As CLabel
        Friend WithEvents txtTotalOutstandingDeposits As CTextBox
        Friend WithEvents txtTotalQtyDebitsCleared As CTextBox
        Friend WithEvents lblDebitsCleared As CLabel
        Friend WithEvents txtTotalDebitsCleared As CTextBox
        Friend WithEvents lblTotalDepositsInTransit As CLabel
        Friend WithEvents txtBalance2 As CTextBox
        Friend WithEvents CLabel9 As CLabel
        Friend WithEvents lblGlSystemBalance As CLabel
        Friend WithEvents txtGlSystemBalance As CTextBox
        Friend WithEvents txtTotalQtyDebitsNotCleared As CTextBox
        Friend WithEvents lblTotalCreditsNotCleared As CLabel
        Friend WithEvents txtTotalCreditsNotCleared As CTextBox
        Friend WithEvents CLabel7 As CLabel
        Friend WithEvents txtTotalQtyCreditsNotCleared As CTextBox
        Friend WithEvents lblTotalDebitsNotCleared As CLabel
        Friend WithEvents txtTotalDebitsNotCleared As CTextBox
        Friend WithEvents lblUnreconciledDifference As CLabel
        Friend WithEvents txtUnreconciledDifference As CTextBox
        Friend WithEvents bsAccountReconciliationItems As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents CFlowLayout6 As CFlowLayout
        Friend WithEvents CFlowLayout5 As CFlowLayout
        Friend WithEvents lblBalance As CLabel
        Friend WithEvents txtBalance As CTextBox
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents DataGridViewReconciliationItems As CDataGridView
        Friend WithEvents CsrOiItemModelBindingSource As Windows.Forms.BindingSource
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvTransactionDate As CdgvColumnText
        Friend WithEvents dgvJournalCode As CdgvColumnText
        Friend WithEvents dgvReferenceNo As CdgvColumnText
        Friend WithEvents dgvJournalIdNo As CdgvColumnText
        Friend WithEvents dgvDocumentNumber As CdgvColumnText
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvCleared As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents dgvPayDescription As CdgvColumnText
        Friend WithEvents dgvAccountReconciliationIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvAccountIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents CFlowLayout7 As CFlowLayout
        Friend WithEvents btnPost As CButton
    End Class
End NameSpace