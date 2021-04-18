Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
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
        Dim CBlendItems3 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
        Dim CBlendItems4 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
        Dim CBlendItems1 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.floHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpReconciliationDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
        Me.CFlowLayout8 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnClearAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnUnClearAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
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
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvDocumentNumber = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCleared = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvPayDescription = New AATM.Libraries.CBaseControlsLibrary.CDgvColumnText()
        Me.dgvAccountReconciliationIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsAccountReconciliationItems = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floHeader.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.CFlowLayout8.SuspendLayout
        Me.CFlowLayout5.SuspendLayout
        Me.CFlowLayout7.SuspendLayout
        Me.CFlowLayout6.SuspendLayout
        CType(Me.CsrOiItemModelBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        CType(Me.DataGridViewReconciliationItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsAccountReconciliationItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = false
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
        Me.lblTransactionDate.Name = "lblTransactionDate"
        '
        'dtpReconciliationDate
        '
        Me.dtpReconciliationDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpReconciliationDate.DefaultValue = Nothing
        Me.dtpReconciliationDate.DisplayOnly = false
        Me.dtpReconciliationDate.DtpDefaultValue = Nothing
        Me.dtpReconciliationDate.EditingMode = false
        Me.dtpReconciliationDate.EditsAllowed = false
        resources.ApplyResources(Me.dtpReconciliationDate, "dtpReconciliationDate")
        Me.dtpReconciliationDate.ForeColor = System.Drawing.Color.Black
        Me.dtpReconciliationDate.LinkedLabel = Nothing
        Me.dtpReconciliationDate.Name = "dtpReconciliationDate"
        Me.dtpReconciliationDate.ReadOnlyDp = false
        Me.dtpReconciliationDate.SecurityKey = Nothing
        Me.dtpReconciliationDate.ShowLongDate = false
        Me.dtpReconciliationDate.ShowTime = false
        Me.dtpReconciliationDate.TargetCalendar = CType(resources.GetObject("dtpReconciliationDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpReconciliationDate.Value = Nothing
        Me.dtpReconciliationDate.ValueIsMandatory = false
        Me.dtpReconciliationDate.ValueIsNullable = false
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblBalance.DisplayOnly = true
        Me.lblBalance.EditingMode = false
        resources.ApplyResources(Me.lblBalance, "lblBalance")
        Me.lblBalance.Name = "lblBalance"
        '
        'txtBalance
        '
        Me.txtBalance.AcceptsTab = true
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.BegFindValue = Nothing
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.ComputedValue = true
        Me.txtBalance.CustomFormat = Nothing
        Me.txtBalance.DataBoundControl = true
        Me.txtBalance.EditingMode = true
        Me.txtBalance.EndFindValue = Nothing
        Me.txtBalance.FieldName = Nothing
        Me.txtBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBalance.FindEnabled = false
        resources.ApplyResources(Me.txtBalance, "txtBalance")
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.LinkedLabel = Nothing
        Me.txtBalance.MaximumValue = Nothing
        Me.txtBalance.MinimumValue = Nothing
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.OldValue = Nothing
        Me.txtBalance.ReadOnly = true
        Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBalance.TabStop = false
        Me.txtBalance.ValueIsMandatory = true
        Me.txtBalance.ValueIsNumeric = true
        '
        'lblDateAdded
        '
        Me.lblDateAdded.BackColor = System.Drawing.Color.Transparent
        Me.lblDateAdded.DisplayOnly = true
        Me.lblDateAdded.EditingMode = false
        resources.ApplyResources(Me.lblDateAdded, "lblDateAdded")
        Me.lblDateAdded.Name = "lblDateAdded"
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = true
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.DisplayOnly = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = false
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Nothing
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.TabStop = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.BackColor = System.Drawing.Color.Transparent
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = ""
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.EndFindValue = Nothing
        Me.cboAccountIdNo.FieldName = Nothing
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PreviousSelectedIndex = 0
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblPosted
        '
        Me.lblPosted.BackColor = System.Drawing.Color.Transparent
        Me.lblPosted.DisplayOnly = true
        Me.lblPosted.EditingMode = false
        resources.ApplyResources(Me.lblPosted, "lblPosted")
        Me.lblPosted.Name = "lblPosted"
        '
        'chkPosted
        '
        resources.ApplyResources(Me.chkPosted, "chkPosted")
        Me.chkPosted.AutoCheck = false
        Me.chkPosted.BackColor = System.Drawing.Color.White
        Me.chkPosted.BegFindValue = Nothing
        Me.chkPosted.DisplayOnly = true
        Me.chkPosted.EditingMode = false
        Me.chkPosted.EndFindValue = Nothing
        Me.chkPosted.FieldName = Nothing
        Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkPosted.FindEnabled = false
        Me.chkPosted.FlatAppearance.BorderSize = 0
        Me.chkPosted.ForeColor = System.Drawing.Color.Black
        Me.chkPosted.IFindableControl_FindEnabled = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.NoLabel = true
        Me.chkPosted.OldValue = Nothing
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.TabStop = false
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'txtTotalOutstandingCredits
        '
        Me.txtTotalOutstandingCredits.BackColor = System.Drawing.Color.White
        Me.txtTotalOutstandingCredits.BegFindValue = Nothing
        Me.txtTotalOutstandingCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOutstandingCredits.ComputedValue = true
        Me.txtTotalOutstandingCredits.CustomFormat = Nothing
        Me.txtTotalOutstandingCredits.DataBoundControl = true
        Me.txtTotalOutstandingCredits.DisplayOnly = true
        Me.txtTotalOutstandingCredits.EditingMode = true
        Me.txtTotalOutstandingCredits.EndFindValue = Nothing
        Me.txtTotalOutstandingCredits.FieldName = Nothing
        Me.txtTotalOutstandingCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalOutstandingCredits.FindEnabled = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtTotalOutstandingCredits, true)
        resources.ApplyResources(Me.txtTotalOutstandingCredits, "txtTotalOutstandingCredits")
        Me.txtTotalOutstandingCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalOutstandingCredits.LinkedLabel = Nothing
        Me.txtTotalOutstandingCredits.MaximumValue = Nothing
        Me.txtTotalOutstandingCredits.MinimumValue = Nothing
        Me.txtTotalOutstandingCredits.Name = "txtTotalOutstandingCredits"
        Me.txtTotalOutstandingCredits.OldValue = Nothing
        Me.txtTotalOutstandingCredits.ReadOnly = true
        Me.txtTotalOutstandingCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalOutstandingCredits.TabStop = false
        Me.txtTotalOutstandingCredits.ValueIsMandatory = true
        Me.txtTotalOutstandingCredits.ValueIsNumeric = true
        '
        'txtTotalQtyCreditsCleared
        '
        Me.txtTotalQtyCreditsCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalQtyCreditsCleared.BegFindValue = Nothing
        Me.txtTotalQtyCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQtyCreditsCleared.ComputedValue = true
        Me.txtTotalQtyCreditsCleared.CustomFormat = Nothing
        Me.txtTotalQtyCreditsCleared.DataBoundControl = true
        Me.txtTotalQtyCreditsCleared.DisplayOnly = true
        Me.txtTotalQtyCreditsCleared.EditingMode = true
        Me.txtTotalQtyCreditsCleared.EndFindValue = Nothing
        Me.txtTotalQtyCreditsCleared.FieldName = Nothing
        Me.txtTotalQtyCreditsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalQtyCreditsCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalQtyCreditsCleared, "txtTotalQtyCreditsCleared")
        Me.txtTotalQtyCreditsCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalQtyCreditsCleared.LinkedLabel = Me.lblCreditsCleared
        Me.txtTotalQtyCreditsCleared.MaximumValue = Nothing
        Me.txtTotalQtyCreditsCleared.MinimumValue = Nothing
        Me.txtTotalQtyCreditsCleared.Name = "txtTotalQtyCreditsCleared"
        Me.txtTotalQtyCreditsCleared.OldValue = Nothing
        Me.txtTotalQtyCreditsCleared.ReadOnly = true
        Me.txtTotalQtyCreditsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalQtyCreditsCleared.TabStop = false
        Me.txtTotalQtyCreditsCleared.ValueIsMandatory = true
        Me.txtTotalQtyCreditsCleared.ValueIsNumeric = true
        '
        'lblCreditsCleared
        '
        Me.lblCreditsCleared.BackColor = System.Drawing.Color.Transparent
        Me.lblCreditsCleared.DisplayOnly = true
        Me.lblCreditsCleared.EditingMode = false
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
        Me.CFlowLayout2.Controls.Add(Me.lblDebitsCleared)
        Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyDebitsCleared)
        Me.CFlowLayout2.Controls.Add(Me.txtTotalDebitsCleared)
        Me.CFlowLayout2.Controls.Add(Me.lblCreditsCleared)
        Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyCreditsCleared)
        Me.CFlowLayout2.Controls.Add(Me.txtTotalCreditsCleared)
        Me.CFlowLayout2.Controls.Add(Me.CFlowLayout8)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblDebitsCleared
        '
        Me.lblDebitsCleared.BackColor = System.Drawing.Color.Transparent
        Me.lblDebitsCleared.DisplayOnly = true
        Me.lblDebitsCleared.EditingMode = false
        resources.ApplyResources(Me.lblDebitsCleared, "lblDebitsCleared")
        Me.lblDebitsCleared.Name = "lblDebitsCleared"
        '
        'txtTotalQtyDebitsCleared
        '
        Me.txtTotalQtyDebitsCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalQtyDebitsCleared.BegFindValue = Nothing
        Me.txtTotalQtyDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQtyDebitsCleared.ComputedValue = true
        Me.txtTotalQtyDebitsCleared.CustomFormat = Nothing
        Me.txtTotalQtyDebitsCleared.DataBoundControl = true
        Me.txtTotalQtyDebitsCleared.DisplayOnly = true
        Me.txtTotalQtyDebitsCleared.EditingMode = true
        Me.txtTotalQtyDebitsCleared.EndFindValue = Nothing
        Me.txtTotalQtyDebitsCleared.FieldName = Nothing
        Me.txtTotalQtyDebitsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalQtyDebitsCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalQtyDebitsCleared, "txtTotalQtyDebitsCleared")
        Me.txtTotalQtyDebitsCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalQtyDebitsCleared.LinkedLabel = Me.lblDebitsCleared
        Me.txtTotalQtyDebitsCleared.MaximumValue = Nothing
        Me.txtTotalQtyDebitsCleared.MinimumValue = Nothing
        Me.txtTotalQtyDebitsCleared.Name = "txtTotalQtyDebitsCleared"
        Me.txtTotalQtyDebitsCleared.OldValue = Nothing
        Me.txtTotalQtyDebitsCleared.ReadOnly = true
        Me.txtTotalQtyDebitsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalQtyDebitsCleared.TabStop = false
        Me.txtTotalQtyDebitsCleared.ValueIsMandatory = true
        Me.txtTotalQtyDebitsCleared.ValueIsNumeric = true
        '
        'txtTotalDebitsCleared
        '
        Me.txtTotalDebitsCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalDebitsCleared.BegFindValue = Nothing
        Me.txtTotalDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebitsCleared.ComputedValue = true
        Me.txtTotalDebitsCleared.CustomFormat = Nothing
        Me.txtTotalDebitsCleared.DataBoundControl = true
        Me.txtTotalDebitsCleared.DisplayOnly = true
        Me.txtTotalDebitsCleared.EditingMode = true
        Me.txtTotalDebitsCleared.EndFindValue = Nothing
        Me.txtTotalDebitsCleared.FieldName = Nothing
        Me.txtTotalDebitsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDebitsCleared.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtTotalDebitsCleared, true)
        resources.ApplyResources(Me.txtTotalDebitsCleared, "txtTotalDebitsCleared")
        Me.txtTotalDebitsCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebitsCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
        Me.txtTotalDebitsCleared.MaximumValue = Nothing
        Me.txtTotalDebitsCleared.MinimumValue = Nothing
        Me.txtTotalDebitsCleared.Name = "txtTotalDebitsCleared"
        Me.txtTotalDebitsCleared.OldValue = Nothing
        Me.txtTotalDebitsCleared.ReadOnly = true
        Me.txtTotalDebitsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebitsCleared.TabStop = false
        Me.txtTotalDebitsCleared.ValueIsMandatory = true
        Me.txtTotalDebitsCleared.ValueIsNumeric = true
        '
        'lblTotalCreditsNotCleared
        '
        Me.lblTotalCreditsNotCleared.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCreditsNotCleared.DisplayOnly = true
        Me.lblTotalCreditsNotCleared.EditingMode = false
        resources.ApplyResources(Me.lblTotalCreditsNotCleared, "lblTotalCreditsNotCleared")
        Me.lblTotalCreditsNotCleared.Name = "lblTotalCreditsNotCleared"
        '
        'txtTotalCreditsCleared
        '
        Me.txtTotalCreditsCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalCreditsCleared.BegFindValue = Nothing
        Me.txtTotalCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCreditsCleared.ComputedValue = true
        Me.txtTotalCreditsCleared.CustomFormat = Nothing
        Me.txtTotalCreditsCleared.DataBoundControl = true
        Me.txtTotalCreditsCleared.DisplayOnly = true
        Me.txtTotalCreditsCleared.EditingMode = true
        Me.txtTotalCreditsCleared.EndFindValue = Nothing
        Me.txtTotalCreditsCleared.FieldName = Nothing
        Me.txtTotalCreditsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalCreditsCleared.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtTotalCreditsCleared, true)
        resources.ApplyResources(Me.txtTotalCreditsCleared, "txtTotalCreditsCleared")
        Me.txtTotalCreditsCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCreditsCleared.LinkedLabel = Me.lblCreditsCleared
        Me.txtTotalCreditsCleared.MaximumValue = Nothing
        Me.txtTotalCreditsCleared.MinimumValue = Nothing
        Me.txtTotalCreditsCleared.Name = "txtTotalCreditsCleared"
        Me.txtTotalCreditsCleared.OldValue = Nothing
        Me.txtTotalCreditsCleared.ReadOnly = true
        Me.txtTotalCreditsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCreditsCleared.TabStop = false
        Me.txtTotalCreditsCleared.ValueIsMandatory = true
        Me.txtTotalCreditsCleared.ValueIsNumeric = true
        '
        'CFlowLayout8
        '
        Me.CFlowLayout8.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout8.Controls.Add(Me.btnClearAll)
        Me.CFlowLayout8.Controls.Add(Me.btnUnClearAll)
        resources.ApplyResources(Me.CFlowLayout8, "CFlowLayout8")
        Me.CFlowLayout8.Name = "CFlowLayout8"
        '
        'btnClearAll
        '
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(192,Byte),Integer)), System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer)), System.Drawing.Color.White}
        CBlendItems3.iPoint = New Single() {0!, 1.006211!, 1!}
        Me.btnClearAll.ColorFillBlend = CBlendItems3
        Me.btnClearAll.DesignerSelected = false
        Me.btnClearAll.DisplayOnly = true
        resources.ApplyResources(Me.btnClearAll, "btnClearAll")
        Me.btnClearAll.ImageIndex = 0
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.OriginalImageName = Nothing
        Me.btnClearAll.SecurityKey = ""
        '
        'btnUnClearAll
        '
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(192,Byte),Integer)), System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer)), System.Drawing.Color.White}
        CBlendItems4.iPoint = New Single() {0!, 1.006211!, 1!}
        Me.btnUnClearAll.ColorFillBlend = CBlendItems4
        Me.btnUnClearAll.DesignerSelected = false
        Me.btnUnClearAll.DisplayOnly = true
        resources.ApplyResources(Me.btnUnClearAll, "btnUnClearAll")
        Me.btnUnClearAll.ImageIndex = 0
        Me.btnUnClearAll.Name = "btnUnClearAll"
        Me.btnUnClearAll.OriginalImageName = Nothing
        Me.btnUnClearAll.SecurityKey = ""
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
        Me.CLabel9.DisplayOnly = true
        Me.CLabel9.EditingMode = false
        Me.CFlowLayout5.SetFlowBreak(Me.CLabel9, true)
        resources.ApplyResources(Me.CLabel9, "CLabel9")
        Me.CLabel9.Name = "CLabel9"
        '
        'txtTotalQtyCreditsNotCleared
        '
        Me.txtTotalQtyCreditsNotCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalQtyCreditsNotCleared.BegFindValue = Nothing
        Me.txtTotalQtyCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQtyCreditsNotCleared.ComputedValue = true
        Me.txtTotalQtyCreditsNotCleared.CustomFormat = Nothing
        Me.txtTotalQtyCreditsNotCleared.DataBoundControl = true
        Me.txtTotalQtyCreditsNotCleared.DisplayOnly = true
        Me.txtTotalQtyCreditsNotCleared.EditingMode = true
        Me.txtTotalQtyCreditsNotCleared.EndFindValue = Nothing
        Me.txtTotalQtyCreditsNotCleared.FieldName = Nothing
        Me.txtTotalQtyCreditsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalQtyCreditsNotCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalQtyCreditsNotCleared, "txtTotalQtyCreditsNotCleared")
        Me.txtTotalQtyCreditsNotCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalQtyCreditsNotCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
        Me.txtTotalQtyCreditsNotCleared.MaximumValue = Nothing
        Me.txtTotalQtyCreditsNotCleared.MinimumValue = Nothing
        Me.txtTotalQtyCreditsNotCleared.Name = "txtTotalQtyCreditsNotCleared"
        Me.txtTotalQtyCreditsNotCleared.OldValue = Nothing
        Me.txtTotalQtyCreditsNotCleared.ReadOnly = true
        Me.txtTotalQtyCreditsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalQtyCreditsNotCleared.TabStop = false
        Me.txtTotalQtyCreditsNotCleared.ValueIsMandatory = true
        Me.txtTotalQtyCreditsNotCleared.ValueIsNumeric = true
        '
        'txtTotalCreditsNotCleared
        '
        Me.txtTotalCreditsNotCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalCreditsNotCleared.BegFindValue = Nothing
        Me.txtTotalCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCreditsNotCleared.ComputedValue = true
        Me.txtTotalCreditsNotCleared.CustomFormat = Nothing
        Me.txtTotalCreditsNotCleared.DataBoundControl = true
        Me.txtTotalCreditsNotCleared.DisplayOnly = true
        Me.txtTotalCreditsNotCleared.EditingMode = true
        Me.txtTotalCreditsNotCleared.EndFindValue = Nothing
        Me.txtTotalCreditsNotCleared.FieldName = Nothing
        Me.txtTotalCreditsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalCreditsNotCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalCreditsNotCleared, "txtTotalCreditsNotCleared")
        Me.txtTotalCreditsNotCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCreditsNotCleared.LinkedLabel = Me.lblDebitsCleared
        Me.txtTotalCreditsNotCleared.MaximumValue = Nothing
        Me.txtTotalCreditsNotCleared.MinimumValue = Nothing
        Me.txtTotalCreditsNotCleared.Name = "txtTotalCreditsNotCleared"
        Me.txtTotalCreditsNotCleared.OldValue = Nothing
        Me.txtTotalCreditsNotCleared.ReadOnly = true
        Me.txtTotalCreditsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCreditsNotCleared.ValueIsMandatory = true
        Me.txtTotalCreditsNotCleared.ValueIsNumeric = true
        '
        'txtTotalQtyDebitsNotCleared
        '
        Me.txtTotalQtyDebitsNotCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalQtyDebitsNotCleared.BegFindValue = Nothing
        Me.txtTotalQtyDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQtyDebitsNotCleared.ComputedValue = true
        Me.txtTotalQtyDebitsNotCleared.CustomFormat = Nothing
        Me.txtTotalQtyDebitsNotCleared.DataBoundControl = true
        Me.txtTotalQtyDebitsNotCleared.DisplayOnly = true
        Me.txtTotalQtyDebitsNotCleared.EditingMode = true
        Me.txtTotalQtyDebitsNotCleared.EndFindValue = Nothing
        Me.txtTotalQtyDebitsNotCleared.FieldName = Nothing
        Me.txtTotalQtyDebitsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalQtyDebitsNotCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalQtyDebitsNotCleared, "txtTotalQtyDebitsNotCleared")
        Me.txtTotalQtyDebitsNotCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalQtyDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
        Me.txtTotalQtyDebitsNotCleared.MaximumValue = Nothing
        Me.txtTotalQtyDebitsNotCleared.MinimumValue = Nothing
        Me.txtTotalQtyDebitsNotCleared.Name = "txtTotalQtyDebitsNotCleared"
        Me.txtTotalQtyDebitsNotCleared.OldValue = Nothing
        Me.txtTotalQtyDebitsNotCleared.ReadOnly = true
        Me.txtTotalQtyDebitsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalQtyDebitsNotCleared.TabStop = false
        Me.txtTotalQtyDebitsNotCleared.ValueIsMandatory = true
        Me.txtTotalQtyDebitsNotCleared.ValueIsNumeric = true
        '
        'lblTotalDebitsNotCleared
        '
        Me.lblTotalDebitsNotCleared.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalDebitsNotCleared.DisplayOnly = true
        Me.lblTotalDebitsNotCleared.EditingMode = false
        resources.ApplyResources(Me.lblTotalDebitsNotCleared, "lblTotalDebitsNotCleared")
        Me.lblTotalDebitsNotCleared.Name = "lblTotalDebitsNotCleared"
        '
        'txtTotalDebitsNotCleared
        '
        Me.txtTotalDebitsNotCleared.BackColor = System.Drawing.Color.White
        Me.txtTotalDebitsNotCleared.BegFindValue = Nothing
        Me.txtTotalDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebitsNotCleared.ComputedValue = true
        Me.txtTotalDebitsNotCleared.CustomFormat = Nothing
        Me.txtTotalDebitsNotCleared.DataBoundControl = true
        Me.txtTotalDebitsNotCleared.DisplayOnly = true
        Me.txtTotalDebitsNotCleared.EditingMode = true
        Me.txtTotalDebitsNotCleared.EndFindValue = Nothing
        Me.txtTotalDebitsNotCleared.FieldName = Nothing
        Me.txtTotalDebitsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDebitsNotCleared.FindEnabled = false
        resources.ApplyResources(Me.txtTotalDebitsNotCleared, "txtTotalDebitsNotCleared")
        Me.txtTotalDebitsNotCleared.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
        Me.txtTotalDebitsNotCleared.MaximumValue = Nothing
        Me.txtTotalDebitsNotCleared.MinimumValue = Nothing
        Me.txtTotalDebitsNotCleared.Name = "txtTotalDebitsNotCleared"
        Me.txtTotalDebitsNotCleared.OldValue = Nothing
        Me.txtTotalDebitsNotCleared.ReadOnly = true
        Me.txtTotalDebitsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebitsNotCleared.TabStop = false
        Me.txtTotalDebitsNotCleared.ValueIsMandatory = true
        Me.txtTotalDebitsNotCleared.ValueIsNumeric = true
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
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(192,Byte),Integer)), System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer)), System.Drawing.Color.White}
        CBlendItems1.iPoint = New Single() {0!, 1.006211!, 1!}
        Me.btnPost.ColorFillBlend = CBlendItems1
        Me.btnPost.DesignerSelected = false
        Me.btnPost.DisplayOnly = true
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
        Me.lblEndingBankBalance.DisplayOnly = true
        Me.lblEndingBankBalance.EditingMode = false
        resources.ApplyResources(Me.lblEndingBankBalance, "lblEndingBankBalance")
        Me.lblEndingBankBalance.Name = "lblEndingBankBalance"
        '
        'txtBalance2
        '
        Me.txtBalance2.BackColor = System.Drawing.Color.White
        Me.txtBalance2.BegFindValue = Nothing
        Me.txtBalance2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance2.ComputedValue = true
        Me.txtBalance2.CustomFormat = Nothing
        Me.txtBalance2.DataBoundControl = true
        Me.txtBalance2.DisplayOnly = true
        Me.txtBalance2.EditingMode = true
        Me.txtBalance2.EndFindValue = Nothing
        Me.txtBalance2.FieldName = Nothing
        Me.txtBalance2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBalance2.FindEnabled = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtBalance2, true)
        resources.ApplyResources(Me.txtBalance2, "txtBalance2")
        Me.txtBalance2.ForeColor = System.Drawing.Color.Black
        Me.txtBalance2.LinkedLabel = Nothing
        Me.txtBalance2.MaximumValue = Nothing
        Me.txtBalance2.MinimumValue = Nothing
        Me.txtBalance2.Name = "txtBalance2"
        Me.txtBalance2.OldValue = Nothing
        Me.txtBalance2.ReadOnly = true
        Me.txtBalance2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBalance2.TabStop = false
        Me.txtBalance2.ValueIsMandatory = true
        Me.txtBalance2.ValueIsNumeric = true
        '
        'lblTotalDepositsInTransit
        '
        Me.lblTotalDepositsInTransit.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalDepositsInTransit.DisplayOnly = true
        Me.lblTotalDepositsInTransit.EditingMode = false
        resources.ApplyResources(Me.lblTotalDepositsInTransit, "lblTotalDepositsInTransit")
        Me.lblTotalDepositsInTransit.Name = "lblTotalDepositsInTransit"
        '
        'txtTotalOutstandingDeposits
        '
        Me.txtTotalOutstandingDeposits.BackColor = System.Drawing.Color.White
        Me.txtTotalOutstandingDeposits.BegFindValue = Nothing
        Me.txtTotalOutstandingDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOutstandingDeposits.ComputedValue = true
        Me.txtTotalOutstandingDeposits.CustomFormat = Nothing
        Me.txtTotalOutstandingDeposits.DataBoundControl = true
        Me.txtTotalOutstandingDeposits.DisplayOnly = true
        Me.txtTotalOutstandingDeposits.EditingMode = true
        Me.txtTotalOutstandingDeposits.EndFindValue = Nothing
        Me.txtTotalOutstandingDeposits.FieldName = Nothing
        Me.txtTotalOutstandingDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalOutstandingDeposits.FindEnabled = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtTotalOutstandingDeposits, true)
        resources.ApplyResources(Me.txtTotalOutstandingDeposits, "txtTotalOutstandingDeposits")
        Me.txtTotalOutstandingDeposits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalOutstandingDeposits.LinkedLabel = Nothing
        Me.txtTotalOutstandingDeposits.MaximumValue = Nothing
        Me.txtTotalOutstandingDeposits.MinimumValue = Nothing
        Me.txtTotalOutstandingDeposits.Name = "txtTotalOutstandingDeposits"
        Me.txtTotalOutstandingDeposits.OldValue = Nothing
        Me.txtTotalOutstandingDeposits.ReadOnly = true
        Me.txtTotalOutstandingDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalOutstandingDeposits.TabStop = false
        Me.txtTotalOutstandingDeposits.ValueIsMandatory = true
        Me.txtTotalOutstandingDeposits.ValueIsNumeric = true
        '
        'lblOutstandingCredits
        '
        Me.lblOutstandingCredits.BackColor = System.Drawing.Color.Transparent
        Me.lblOutstandingCredits.DisplayOnly = true
        Me.lblOutstandingCredits.EditingMode = false
        resources.ApplyResources(Me.lblOutstandingCredits, "lblOutstandingCredits")
        Me.lblOutstandingCredits.Name = "lblOutstandingCredits"
        '
        'lblGlSystemBalance
        '
        Me.lblGlSystemBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblGlSystemBalance.DisplayOnly = true
        Me.lblGlSystemBalance.EditingMode = false
        resources.ApplyResources(Me.lblGlSystemBalance, "lblGlSystemBalance")
        Me.lblGlSystemBalance.Name = "lblGlSystemBalance"
        '
        'txtGlSystemBalance
        '
        Me.txtGlSystemBalance.BackColor = System.Drawing.Color.White
        Me.txtGlSystemBalance.BegFindValue = Nothing
        Me.txtGlSystemBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlSystemBalance.ComputedValue = true
        Me.txtGlSystemBalance.CustomFormat = Nothing
        Me.txtGlSystemBalance.DataBoundControl = true
        Me.txtGlSystemBalance.DisplayOnly = true
        Me.txtGlSystemBalance.EditingMode = true
        Me.txtGlSystemBalance.EndFindValue = Nothing
        Me.txtGlSystemBalance.FieldName = Nothing
        Me.txtGlSystemBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtGlSystemBalance.FindEnabled = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtGlSystemBalance, true)
        resources.ApplyResources(Me.txtGlSystemBalance, "txtGlSystemBalance")
        Me.txtGlSystemBalance.ForeColor = System.Drawing.Color.Black
        Me.txtGlSystemBalance.LinkedLabel = Nothing
        Me.txtGlSystemBalance.MaximumValue = Nothing
        Me.txtGlSystemBalance.MinimumValue = Nothing
        Me.txtGlSystemBalance.Name = "txtGlSystemBalance"
        Me.txtGlSystemBalance.OldValue = Nothing
        Me.txtGlSystemBalance.ReadOnly = true
        Me.txtGlSystemBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtGlSystemBalance.TabStop = false
        Me.txtGlSystemBalance.ValueIsMandatory = true
        Me.txtGlSystemBalance.ValueIsNumeric = true
        '
        'CLabel7
        '
        Me.CLabel7.BackColor = System.Drawing.Color.Transparent
        Me.CLabel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CLabel7.DisplayOnly = true
        Me.CLabel7.EditingMode = false
        resources.ApplyResources(Me.CLabel7, "CLabel7")
        Me.CLabel7.Name = "CLabel7"
        '
        'lblUnreconciledDifference
        '
        Me.lblUnreconciledDifference.BackColor = System.Drawing.Color.Transparent
        Me.lblUnreconciledDifference.DisplayOnly = true
        Me.lblUnreconciledDifference.EditingMode = false
        resources.ApplyResources(Me.lblUnreconciledDifference, "lblUnreconciledDifference")
        Me.lblUnreconciledDifference.Name = "lblUnreconciledDifference"
        '
        'txtUnreconciledDifference
        '
        Me.txtUnreconciledDifference.BackColor = System.Drawing.Color.White
        Me.txtUnreconciledDifference.BegFindValue = Nothing
        Me.txtUnreconciledDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnreconciledDifference.ComputedValue = true
        Me.txtUnreconciledDifference.CustomFormat = Nothing
        Me.txtUnreconciledDifference.DataBoundControl = true
        Me.txtUnreconciledDifference.DisplayOnly = true
        Me.txtUnreconciledDifference.EditingMode = true
        Me.txtUnreconciledDifference.EndFindValue = Nothing
        Me.txtUnreconciledDifference.FieldName = Nothing
        Me.txtUnreconciledDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUnreconciledDifference.FindEnabled = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtUnreconciledDifference, true)
        resources.ApplyResources(Me.txtUnreconciledDifference, "txtUnreconciledDifference")
        Me.txtUnreconciledDifference.ForeColor = System.Drawing.Color.Black
        Me.txtUnreconciledDifference.LinkedLabel = Nothing
        Me.txtUnreconciledDifference.MaximumValue = Nothing
        Me.txtUnreconciledDifference.MinimumValue = Nothing
        Me.txtUnreconciledDifference.Name = "txtUnreconciledDifference"
        Me.txtUnreconciledDifference.OldValue = Nothing
        Me.txtUnreconciledDifference.ReadOnly = true
        Me.txtUnreconciledDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUnreconciledDifference.TabStop = false
        Me.txtUnreconciledDifference.ValueIsMandatory = true
        Me.txtUnreconciledDifference.ValueIsNumeric = true
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
        Me.DataGridViewReconciliationItems.AllowUserToAddRows = false
        Me.DataGridViewReconciliationItems.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewReconciliationItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewReconciliationItems.AutoGenerateColumns = false
        Me.DataGridViewReconciliationItems.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewReconciliationItems.BegFindValue = Nothing
        Me.DataGridViewReconciliationItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReconciliationItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvReferenceNo, Me.dgvJournalIdNo, Me.dgvDocumentNumber, Me.dgvDebit, Me.dgvCredit, Me.dgvCleared, Me.dgvPayDescription, Me.dgvAccountReconciliationIdNo})
        Me.DataGridViewReconciliationItems.DataSource = Me.bsAccountReconciliationItems
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewReconciliationItems.DefaultCellStyle = DataGridViewCellStyle67
        Me.DataGridViewReconciliationItems.DgvFooter = Nothing
        Me.DataGridViewReconciliationItems.DisplayOnly = false
        Me.DataGridViewReconciliationItems.Ea = Nothing
        Me.DataGridViewReconciliationItems.EditingMode = false
        Me.DataGridViewReconciliationItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewReconciliationItems.EndFindValue = Nothing
        Me.DataGridViewReconciliationItems.FieldName = Nothing
        Me.DataGridViewReconciliationItems.FieldsDictionary = Nothing
        Me.DataGridViewReconciliationItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewReconciliationItems.FindEnabled = false
        Me.DataGridViewReconciliationItems.FirstRowDeletionEnabled = false
        Me.DataGridViewReconciliationItems.FirstRowInsertionEnabled = false
        resources.ApplyResources(Me.DataGridViewReconciliationItems, "DataGridViewReconciliationItems")
        Me.DataGridViewReconciliationItems.Name = "DataGridViewReconciliationItems"
        Me.DataGridViewReconciliationItems.ReadOnly = true
        Me.DataGridViewReconciliationItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewReconciliationItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewReconciliationItems.SequenceFieldName = "Sequence"
        Me.DataGridViewReconciliationItems.ShowFooter = false
        Me.DataGridViewReconciliationItems.ShowInsertColumnWhenEditing = false
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle49.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle49
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvTransactionDate
        '
        Me.dgvTransactionDate.BegFindValue = Nothing
        Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle59.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle59.ForeColor = System.Drawing.Color.Black
        Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle59
        Me.dgvTransactionDate.EditingMode = false
        Me.dgvTransactionDate.EndFindValue = Nothing
        Me.dgvTransactionDate.FieldName = Nothing
        Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvTransactionDate.FindEnabled = false
        resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
        Me.dgvTransactionDate.Name = "dgvTransactionDate"
        Me.dgvTransactionDate.ReadOnly = true
        Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvJournalCode
        '
        Me.dgvJournalCode.BegFindValue = Nothing
        Me.dgvJournalCode.DataPropertyName = "JournalCode"
        DataGridViewCellStyle60.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle60.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle60.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle60
        Me.dgvJournalCode.EditingMode = false
        Me.dgvJournalCode.EndFindValue = Nothing
        Me.dgvJournalCode.FieldName = Nothing
        Me.dgvJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalCode.FindEnabled = false
        resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
        Me.dgvJournalCode.Name = "dgvJournalCode"
        Me.dgvJournalCode.ReadOnly = true
        Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvReferenceNo
        '
        Me.dgvReferenceNo.BegFindValue = Nothing
        Me.dgvReferenceNo.DataPropertyName = "ReferenceNo"
        DataGridViewCellStyle61.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle61.ForeColor = System.Drawing.Color.Black
        Me.dgvReferenceNo.DefaultCellStyle = DataGridViewCellStyle61
        Me.dgvReferenceNo.EditingMode = false
        Me.dgvReferenceNo.EndFindValue = Nothing
        Me.dgvReferenceNo.FieldName = Nothing
        Me.dgvReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvReferenceNo.FindEnabled = false
        resources.ApplyResources(Me.dgvReferenceNo, "dgvReferenceNo")
        Me.dgvReferenceNo.Name = "dgvReferenceNo"
        Me.dgvReferenceNo.ReadOnly = true
        Me.dgvReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvJournalIdNo
        '
        Me.dgvJournalIdNo.BegFindValue = Nothing
        Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
        DataGridViewCellStyle62.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle62.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalIdNo.DefaultCellStyle = DataGridViewCellStyle62
        Me.dgvJournalIdNo.EditingMode = false
        Me.dgvJournalIdNo.EndFindValue = Nothing
        Me.dgvJournalIdNo.FieldName = Nothing
        Me.dgvJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
        Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
        Me.dgvJournalIdNo.ReadOnly = true
        Me.dgvJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvDocumentNumber
        '
        Me.dgvDocumentNumber.BegFindValue = Nothing
        Me.dgvDocumentNumber.DataPropertyName = "DocumentNumber"
        DataGridViewCellStyle63.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle63.ForeColor = System.Drawing.Color.Black
        Me.dgvDocumentNumber.DefaultCellStyle = DataGridViewCellStyle63
        Me.dgvDocumentNumber.DisplayOnly = true
        Me.dgvDocumentNumber.EditingMode = false
        Me.dgvDocumentNumber.EndFindValue = Nothing
        Me.dgvDocumentNumber.FieldName = Nothing
        Me.dgvDocumentNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDocumentNumber.FindEnabled = false
        resources.ApplyResources(Me.dgvDocumentNumber, "dgvDocumentNumber")
        Me.dgvDocumentNumber.Name = "dgvDocumentNumber"
        Me.dgvDocumentNumber.ReadOnly = true
        Me.dgvDocumentNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvDebit
        '
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle64.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle64.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle64.Format = "###,##0.00"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle64
        Me.dgvDebit.EditingMode = false
        resources.ApplyResources(Me.dgvDebit, "dgvDebit")
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.ReadOnly = true
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvCredit
        '
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle65.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle65.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle65.Format = "###,##0.00"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle65
        Me.dgvCredit.EditingMode = false
        resources.ApplyResources(Me.dgvCredit, "dgvCredit")
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvCleared
        '
        Me.dgvCleared.DataPropertyName = "Cleared"
        resources.ApplyResources(Me.dgvCleared, "dgvCleared")
        Me.dgvCleared.Name = "dgvCleared"
        Me.dgvCleared.ReadOnly = true
        '
        'dgvPayDescription
        '
        Me.dgvPayDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvPayDescription.BegFindValue = Nothing
        Me.dgvPayDescription.DataPropertyName = "PayDescription"
        DataGridViewCellStyle66.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle66.ForeColor = System.Drawing.Color.Black
        Me.dgvPayDescription.DefaultCellStyle = DataGridViewCellStyle66
        Me.dgvPayDescription.DisplayOnly = true
        Me.dgvPayDescription.EditingMode = false
        Me.dgvPayDescription.EndFindValue = Nothing
        Me.dgvPayDescription.FieldName = Nothing
        Me.dgvPayDescription.FillWeight = 10!
        Me.dgvPayDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayDescription.FindEnabled = false
        resources.ApplyResources(Me.dgvPayDescription, "dgvPayDescription")
        Me.dgvPayDescription.Name = "dgvPayDescription"
        Me.dgvPayDescription.ReadOnly = true
        Me.dgvPayDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvAccountReconciliationIdNo
        '
        Me.dgvAccountReconciliationIdNo.DataPropertyName = "AccountReconciliationIdNo"
        resources.ApplyResources(Me.dgvAccountReconciliationIdNo, "dgvAccountReconciliationIdNo")
        Me.dgvAccountReconciliationIdNo.Name = "dgvAccountReconciliationIdNo"
        Me.dgvAccountReconciliationIdNo.ReadOnly = true
        '
        'AccountReconciliationEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout4)
        Me.Name = "AccountReconciliationEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floHeader.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.CFlowLayout8.ResumeLayout(false)
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
        Friend WithEvents CFlowLayout8 As CFlowLayout
        Friend WithEvents btnClearAll As CButton
        Friend WithEvents btnUnClearAll As CButton
    End Class
End NameSpace