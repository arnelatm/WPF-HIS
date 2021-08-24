Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountReconciliationEntry
        Inherits CFormEntryNew

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
        Dim CBlendItems2 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
        Dim CBlendItems3 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.txtOutstandingCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalQtyCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtTotalCreditsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalQtyDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalDebitsCleared = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTotalCreditsNotCleared = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.txtOutstandingDeposits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblOutstandingCredits = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGlSystemBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGlSystemBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblUnreconciledDifference = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUnreconciledDifference = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CsrOiItemModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewReconciliationItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.bsAccountReconciliationItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvJournalItemIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDocumentNumber = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCleared = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvPayDescription = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floHeader.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            Me.CFlowLayout8.SuspendLayout()
            Me.CFlowLayout5.SuspendLayout()
            Me.CFlowLayout7.SuspendLayout()
            Me.CFlowLayout6.SuspendLayout()
            CType(Me.CsrOiItemModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            CType(Me.DataGridViewReconciliationItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsAccountReconciliationItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = False
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Translatable = True
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
            Me.dtpReconciliationDate.Translatable = False
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
            Me.lblBalance.Translatable = True
            '
            'txtBalance
            '
            Me.txtBalance.AcceptsTab = True
            Me.txtBalance.BackColor = System.Drawing.Color.White
            Me.txtBalance.BegFindValue = Nothing
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = True
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.EditingMode = True
            Me.txtBalance.EndFindValue = Nothing
            Me.txtBalance.FieldDescription = Nothing
            Me.txtBalance.FieldName = Nothing
            Me.txtBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBalance.FindEnabled = False
            resources.ApplyResources(Me.txtBalance, "txtBalance")
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Nothing
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBalance.TabStop = False
            Me.txtBalance.Translatable = False
            Me.txtBalance.ValueIsMandatory = True
            Me.txtBalance.ValueIsNumeric = True
            '
            'lblDateAdded
            '
            Me.lblDateAdded.BackColor = System.Drawing.Color.Transparent
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            resources.ApplyResources(Me.lblDateAdded, "lblDateAdded")
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = True
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
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
            Me.lblPosted.Translatable = True
            '
            'chkPosted
            '
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.BegFindValue = Nothing
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = False
            Me.chkPosted.EndFindValue = Nothing
            Me.chkPosted.FieldDescription = Nothing
            Me.chkPosted.FieldName = Nothing
            Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPosted.FindEnabled = False
            Me.chkPosted.FlatAppearance.BorderSize = 0
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.IFindableControl_FindEnabled = False
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.NoLabel = True
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.TabStop = False
            Me.chkPosted.Translatable = False
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'txtOutstandingCredits
            '
            Me.txtOutstandingCredits.BackColor = System.Drawing.Color.White
            Me.txtOutstandingCredits.BegFindValue = Nothing
            Me.txtOutstandingCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutstandingCredits.ComputedValue = True
            Me.txtOutstandingCredits.CustomFormat = Nothing
            Me.txtOutstandingCredits.DataBoundControl = True
            Me.txtOutstandingCredits.DisplayOnly = True
            Me.txtOutstandingCredits.EditingMode = True
            Me.txtOutstandingCredits.EndFindValue = Nothing
            Me.txtOutstandingCredits.FieldDescription = Nothing
            Me.txtOutstandingCredits.FieldName = Nothing
            Me.txtOutstandingCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtOutstandingCredits.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.txtOutstandingCredits, True)
            resources.ApplyResources(Me.txtOutstandingCredits, "txtOutstandingCredits")
            Me.txtOutstandingCredits.ForeColor = System.Drawing.Color.Black
            Me.txtOutstandingCredits.LinkedLabel = Nothing
            Me.txtOutstandingCredits.MaximumValue = Nothing
            Me.txtOutstandingCredits.MinimumValue = Nothing
            Me.txtOutstandingCredits.Name = "txtOutstandingCredits"
            Me.txtOutstandingCredits.OldValue = Nothing
            Me.txtOutstandingCredits.ReadOnly = True
            Me.txtOutstandingCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtOutstandingCredits.TabStop = False
            Me.txtOutstandingCredits.Translatable = False
            Me.txtOutstandingCredits.ValueIsMandatory = True
            Me.txtOutstandingCredits.ValueIsNumeric = True
            '
            'txtTotalQtyCreditsCleared
            '
            Me.txtTotalQtyCreditsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyCreditsCleared.BegFindValue = Nothing
            Me.txtTotalQtyCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyCreditsCleared.ComputedValue = True
            Me.txtTotalQtyCreditsCleared.CustomFormat = Nothing
            Me.txtTotalQtyCreditsCleared.DataBoundControl = True
            Me.txtTotalQtyCreditsCleared.DisplayOnly = True
            Me.txtTotalQtyCreditsCleared.EditingMode = True
            Me.txtTotalQtyCreditsCleared.EndFindValue = Nothing
            Me.txtTotalQtyCreditsCleared.FieldDescription = Nothing
            Me.txtTotalQtyCreditsCleared.FieldName = Nothing
            Me.txtTotalQtyCreditsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalQtyCreditsCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalQtyCreditsCleared, "txtTotalQtyCreditsCleared")
            Me.txtTotalQtyCreditsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyCreditsCleared.LinkedLabel = Me.lblCreditsCleared
            Me.txtTotalQtyCreditsCleared.MaximumValue = Nothing
            Me.txtTotalQtyCreditsCleared.MinimumValue = Nothing
            Me.txtTotalQtyCreditsCleared.Name = "txtTotalQtyCreditsCleared"
            Me.txtTotalQtyCreditsCleared.OldValue = Nothing
            Me.txtTotalQtyCreditsCleared.ReadOnly = True
            Me.txtTotalQtyCreditsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalQtyCreditsCleared.TabStop = False
            Me.txtTotalQtyCreditsCleared.Translatable = False
            Me.txtTotalQtyCreditsCleared.ValueIsMandatory = True
            Me.txtTotalQtyCreditsCleared.ValueIsNumeric = True
            '
            'lblCreditsCleared
            '
            Me.lblCreditsCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblCreditsCleared.DisplayOnly = True
            Me.lblCreditsCleared.EditingMode = False
            resources.ApplyResources(Me.lblCreditsCleared, "lblCreditsCleared")
            Me.lblCreditsCleared.Name = "lblCreditsCleared"
            Me.lblCreditsCleared.Translatable = True
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
            Me.CFlowLayout2.Controls.Add(Me.lblCreditsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyCreditsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalCreditsCleared)
            Me.CFlowLayout2.Controls.Add(Me.lblDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalQtyDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalDebitsCleared)
            Me.CFlowLayout2.Controls.Add(Me.CFlowLayout8)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'txtTotalCreditsCleared
            '
            Me.txtTotalCreditsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalCreditsCleared.BegFindValue = Nothing
            Me.txtTotalCreditsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCreditsCleared.ComputedValue = True
            Me.txtTotalCreditsCleared.CustomFormat = Nothing
            Me.txtTotalCreditsCleared.DataBoundControl = True
            Me.txtTotalCreditsCleared.DisplayOnly = True
            Me.txtTotalCreditsCleared.EditingMode = True
            Me.txtTotalCreditsCleared.EndFindValue = Nothing
            Me.txtTotalCreditsCleared.FieldDescription = Nothing
            Me.txtTotalCreditsCleared.FieldName = Nothing
            Me.txtTotalCreditsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalCreditsCleared.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtTotalCreditsCleared, True)
            resources.ApplyResources(Me.txtTotalCreditsCleared, "txtTotalCreditsCleared")
            Me.txtTotalCreditsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCreditsCleared.LinkedLabel = Me.lblCreditsCleared
            Me.txtTotalCreditsCleared.MaximumValue = Nothing
            Me.txtTotalCreditsCleared.MinimumValue = Nothing
            Me.txtTotalCreditsCleared.Name = "txtTotalCreditsCleared"
            Me.txtTotalCreditsCleared.OldValue = Nothing
            Me.txtTotalCreditsCleared.ReadOnly = True
            Me.txtTotalCreditsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCreditsCleared.TabStop = False
            Me.txtTotalCreditsCleared.Translatable = False
            Me.txtTotalCreditsCleared.ValueIsMandatory = True
            Me.txtTotalCreditsCleared.ValueIsNumeric = True
            '
            'lblDebitsCleared
            '
            Me.lblDebitsCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblDebitsCleared.DisplayOnly = True
            Me.lblDebitsCleared.EditingMode = False
            resources.ApplyResources(Me.lblDebitsCleared, "lblDebitsCleared")
            Me.lblDebitsCleared.Name = "lblDebitsCleared"
            Me.lblDebitsCleared.Translatable = True
            '
            'txtTotalQtyDebitsCleared
            '
            Me.txtTotalQtyDebitsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyDebitsCleared.BegFindValue = Nothing
            Me.txtTotalQtyDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyDebitsCleared.ComputedValue = True
            Me.txtTotalQtyDebitsCleared.CustomFormat = Nothing
            Me.txtTotalQtyDebitsCleared.DataBoundControl = True
            Me.txtTotalQtyDebitsCleared.DisplayOnly = True
            Me.txtTotalQtyDebitsCleared.EditingMode = True
            Me.txtTotalQtyDebitsCleared.EndFindValue = Nothing
            Me.txtTotalQtyDebitsCleared.FieldDescription = Nothing
            Me.txtTotalQtyDebitsCleared.FieldName = Nothing
            Me.txtTotalQtyDebitsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalQtyDebitsCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalQtyDebitsCleared, "txtTotalQtyDebitsCleared")
            Me.txtTotalQtyDebitsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyDebitsCleared.LinkedLabel = Me.lblDebitsCleared
            Me.txtTotalQtyDebitsCleared.MaximumValue = Nothing
            Me.txtTotalQtyDebitsCleared.MinimumValue = Nothing
            Me.txtTotalQtyDebitsCleared.Name = "txtTotalQtyDebitsCleared"
            Me.txtTotalQtyDebitsCleared.OldValue = Nothing
            Me.txtTotalQtyDebitsCleared.ReadOnly = True
            Me.txtTotalQtyDebitsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalQtyDebitsCleared.TabStop = False
            Me.txtTotalQtyDebitsCleared.Translatable = False
            Me.txtTotalQtyDebitsCleared.ValueIsMandatory = True
            Me.txtTotalQtyDebitsCleared.ValueIsNumeric = True
            '
            'txtTotalDebitsCleared
            '
            Me.txtTotalDebitsCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalDebitsCleared.BegFindValue = Nothing
            Me.txtTotalDebitsCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDebitsCleared.ComputedValue = True
            Me.txtTotalDebitsCleared.CustomFormat = Nothing
            Me.txtTotalDebitsCleared.DataBoundControl = True
            Me.txtTotalDebitsCleared.DisplayOnly = True
            Me.txtTotalDebitsCleared.EditingMode = True
            Me.txtTotalDebitsCleared.EndFindValue = Nothing
            Me.txtTotalDebitsCleared.FieldDescription = Nothing
            Me.txtTotalDebitsCleared.FieldName = Nothing
            Me.txtTotalDebitsCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDebitsCleared.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtTotalDebitsCleared, True)
            resources.ApplyResources(Me.txtTotalDebitsCleared, "txtTotalDebitsCleared")
            Me.txtTotalDebitsCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebitsCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
            Me.txtTotalDebitsCleared.MaximumValue = Nothing
            Me.txtTotalDebitsCleared.MinimumValue = Nothing
            Me.txtTotalDebitsCleared.Name = "txtTotalDebitsCleared"
            Me.txtTotalDebitsCleared.OldValue = Nothing
            Me.txtTotalDebitsCleared.ReadOnly = True
            Me.txtTotalDebitsCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebitsCleared.TabStop = False
            Me.txtTotalDebitsCleared.Translatable = False
            Me.txtTotalDebitsCleared.ValueIsMandatory = True
            Me.txtTotalDebitsCleared.ValueIsNumeric = True
            '
            'lblTotalCreditsNotCleared
            '
            Me.lblTotalCreditsNotCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalCreditsNotCleared.DisplayOnly = True
            Me.lblTotalCreditsNotCleared.EditingMode = False
            resources.ApplyResources(Me.lblTotalCreditsNotCleared, "lblTotalCreditsNotCleared")
            Me.lblTotalCreditsNotCleared.Name = "lblTotalCreditsNotCleared"
            Me.lblTotalCreditsNotCleared.Translatable = True
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
            CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.White}
            CBlendItems1.iPoint = New Single() {0!, 1.006211!, 1.0!}
            Me.btnClearAll.ColorFillBlend = CBlendItems1
            Me.btnClearAll.DesignerSelected = False
            Me.btnClearAll.DisplayOnly = True
            resources.ApplyResources(Me.btnClearAll, "btnClearAll")
            Me.btnClearAll.ImageIndex = 0
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.OriginalImageName = Nothing
            Me.btnClearAll.SecurityKey = ""
            '
            'btnUnClearAll
            '
            CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.White}
            CBlendItems2.iPoint = New Single() {0!, 1.006211!, 1.0!}
            Me.btnUnClearAll.ColorFillBlend = CBlendItems2
            Me.btnUnClearAll.DesignerSelected = False
            Me.btnUnClearAll.DisplayOnly = True
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
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.EditingMode = False
            Me.CFlowLayout5.SetFlowBreak(Me.CLabel9, True)
            resources.ApplyResources(Me.CLabel9, "CLabel9")
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Translatable = True
            '
            'txtTotalQtyCreditsNotCleared
            '
            Me.txtTotalQtyCreditsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyCreditsNotCleared.BegFindValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyCreditsNotCleared.ComputedValue = True
            Me.txtTotalQtyCreditsNotCleared.CustomFormat = Nothing
            Me.txtTotalQtyCreditsNotCleared.DataBoundControl = True
            Me.txtTotalQtyCreditsNotCleared.DisplayOnly = True
            Me.txtTotalQtyCreditsNotCleared.EditingMode = True
            Me.txtTotalQtyCreditsNotCleared.EndFindValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.FieldDescription = Nothing
            Me.txtTotalQtyCreditsNotCleared.FieldName = Nothing
            Me.txtTotalQtyCreditsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalQtyCreditsNotCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalQtyCreditsNotCleared, "txtTotalQtyCreditsNotCleared")
            Me.txtTotalQtyCreditsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyCreditsNotCleared.LinkedLabel = Me.lblTotalCreditsNotCleared
            Me.txtTotalQtyCreditsNotCleared.MaximumValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.MinimumValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.Name = "txtTotalQtyCreditsNotCleared"
            Me.txtTotalQtyCreditsNotCleared.OldValue = Nothing
            Me.txtTotalQtyCreditsNotCleared.ReadOnly = True
            Me.txtTotalQtyCreditsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalQtyCreditsNotCleared.TabStop = False
            Me.txtTotalQtyCreditsNotCleared.Translatable = False
            Me.txtTotalQtyCreditsNotCleared.ValueIsMandatory = True
            Me.txtTotalQtyCreditsNotCleared.ValueIsNumeric = True
            '
            'txtTotalCreditsNotCleared
            '
            Me.txtTotalCreditsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalCreditsNotCleared.BegFindValue = Nothing
            Me.txtTotalCreditsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCreditsNotCleared.ComputedValue = True
            Me.txtTotalCreditsNotCleared.CustomFormat = Nothing
            Me.txtTotalCreditsNotCleared.DataBoundControl = True
            Me.txtTotalCreditsNotCleared.DisplayOnly = True
            Me.txtTotalCreditsNotCleared.EditingMode = True
            Me.txtTotalCreditsNotCleared.EndFindValue = Nothing
            Me.txtTotalCreditsNotCleared.FieldDescription = Nothing
            Me.txtTotalCreditsNotCleared.FieldName = Nothing
            Me.txtTotalCreditsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalCreditsNotCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalCreditsNotCleared, "txtTotalCreditsNotCleared")
            Me.txtTotalCreditsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCreditsNotCleared.LinkedLabel = Me.lblDebitsCleared
            Me.txtTotalCreditsNotCleared.MaximumValue = Nothing
            Me.txtTotalCreditsNotCleared.MinimumValue = Nothing
            Me.txtTotalCreditsNotCleared.Name = "txtTotalCreditsNotCleared"
            Me.txtTotalCreditsNotCleared.OldValue = Nothing
            Me.txtTotalCreditsNotCleared.ReadOnly = True
            Me.txtTotalCreditsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCreditsNotCleared.Translatable = False
            Me.txtTotalCreditsNotCleared.ValueIsMandatory = True
            Me.txtTotalCreditsNotCleared.ValueIsNumeric = True
            '
            'txtTotalQtyDebitsNotCleared
            '
            Me.txtTotalQtyDebitsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalQtyDebitsNotCleared.BegFindValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalQtyDebitsNotCleared.ComputedValue = True
            Me.txtTotalQtyDebitsNotCleared.CustomFormat = Nothing
            Me.txtTotalQtyDebitsNotCleared.DataBoundControl = True
            Me.txtTotalQtyDebitsNotCleared.DisplayOnly = True
            Me.txtTotalQtyDebitsNotCleared.EditingMode = True
            Me.txtTotalQtyDebitsNotCleared.EndFindValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.FieldDescription = Nothing
            Me.txtTotalQtyDebitsNotCleared.FieldName = Nothing
            Me.txtTotalQtyDebitsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalQtyDebitsNotCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalQtyDebitsNotCleared, "txtTotalQtyDebitsNotCleared")
            Me.txtTotalQtyDebitsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalQtyDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
            Me.txtTotalQtyDebitsNotCleared.MaximumValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.MinimumValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.Name = "txtTotalQtyDebitsNotCleared"
            Me.txtTotalQtyDebitsNotCleared.OldValue = Nothing
            Me.txtTotalQtyDebitsNotCleared.ReadOnly = True
            Me.txtTotalQtyDebitsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalQtyDebitsNotCleared.TabStop = False
            Me.txtTotalQtyDebitsNotCleared.Translatable = False
            Me.txtTotalQtyDebitsNotCleared.ValueIsMandatory = True
            Me.txtTotalQtyDebitsNotCleared.ValueIsNumeric = True
            '
            'lblTotalDebitsNotCleared
            '
            Me.lblTotalDebitsNotCleared.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalDebitsNotCleared.DisplayOnly = True
            Me.lblTotalDebitsNotCleared.EditingMode = False
            resources.ApplyResources(Me.lblTotalDebitsNotCleared, "lblTotalDebitsNotCleared")
            Me.lblTotalDebitsNotCleared.Name = "lblTotalDebitsNotCleared"
            Me.lblTotalDebitsNotCleared.Translatable = True
            '
            'txtTotalDebitsNotCleared
            '
            Me.txtTotalDebitsNotCleared.BackColor = System.Drawing.Color.White
            Me.txtTotalDebitsNotCleared.BegFindValue = Nothing
            Me.txtTotalDebitsNotCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDebitsNotCleared.ComputedValue = True
            Me.txtTotalDebitsNotCleared.CustomFormat = Nothing
            Me.txtTotalDebitsNotCleared.DataBoundControl = True
            Me.txtTotalDebitsNotCleared.DisplayOnly = True
            Me.txtTotalDebitsNotCleared.EditingMode = True
            Me.txtTotalDebitsNotCleared.EndFindValue = Nothing
            Me.txtTotalDebitsNotCleared.FieldDescription = Nothing
            Me.txtTotalDebitsNotCleared.FieldName = Nothing
            Me.txtTotalDebitsNotCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDebitsNotCleared.FindEnabled = False
            resources.ApplyResources(Me.txtTotalDebitsNotCleared, "txtTotalDebitsNotCleared")
            Me.txtTotalDebitsNotCleared.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebitsNotCleared.LinkedLabel = Me.lblTotalDebitsNotCleared
            Me.txtTotalDebitsNotCleared.MaximumValue = Nothing
            Me.txtTotalDebitsNotCleared.MinimumValue = Nothing
            Me.txtTotalDebitsNotCleared.Name = "txtTotalDebitsNotCleared"
            Me.txtTotalDebitsNotCleared.OldValue = Nothing
            Me.txtTotalDebitsNotCleared.ReadOnly = True
            Me.txtTotalDebitsNotCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebitsNotCleared.TabStop = False
            Me.txtTotalDebitsNotCleared.Translatable = False
            Me.txtTotalDebitsNotCleared.ValueIsMandatory = True
            Me.txtTotalDebitsNotCleared.ValueIsNumeric = True
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
            CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.White}
            CBlendItems3.iPoint = New Single() {0!, 1.006211!, 1.0!}
            Me.btnPost.ColorFillBlend = CBlendItems3
            Me.btnPost.DesignerSelected = False
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
            Me.CFlowLayout6.Controls.Add(Me.txtOutstandingDeposits)
            Me.CFlowLayout6.Controls.Add(Me.lblOutstandingCredits)
            Me.CFlowLayout6.Controls.Add(Me.txtOutstandingCredits)
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
            Me.lblEndingBankBalance.Translatable = True
            '
            'txtBalance2
            '
            Me.txtBalance2.BackColor = System.Drawing.Color.White
            Me.txtBalance2.BegFindValue = Nothing
            Me.txtBalance2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance2.ComputedValue = True
            Me.txtBalance2.CustomFormat = Nothing
            Me.txtBalance2.DataBoundControl = True
            Me.txtBalance2.DisplayOnly = True
            Me.txtBalance2.EditingMode = True
            Me.txtBalance2.EndFindValue = Nothing
            Me.txtBalance2.FieldDescription = Nothing
            Me.txtBalance2.FieldName = Nothing
            Me.txtBalance2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBalance2.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.txtBalance2, True)
            resources.ApplyResources(Me.txtBalance2, "txtBalance2")
            Me.txtBalance2.ForeColor = System.Drawing.Color.Black
            Me.txtBalance2.LinkedLabel = Nothing
            Me.txtBalance2.MaximumValue = Nothing
            Me.txtBalance2.MinimumValue = Nothing
            Me.txtBalance2.Name = "txtBalance2"
            Me.txtBalance2.OldValue = Nothing
            Me.txtBalance2.ReadOnly = True
            Me.txtBalance2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBalance2.TabStop = False
            Me.txtBalance2.Translatable = False
            Me.txtBalance2.ValueIsMandatory = True
            Me.txtBalance2.ValueIsNumeric = True
            '
            'lblTotalDepositsInTransit
            '
            Me.lblTotalDepositsInTransit.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalDepositsInTransit.DisplayOnly = True
            Me.lblTotalDepositsInTransit.EditingMode = False
            resources.ApplyResources(Me.lblTotalDepositsInTransit, "lblTotalDepositsInTransit")
            Me.lblTotalDepositsInTransit.Name = "lblTotalDepositsInTransit"
            Me.lblTotalDepositsInTransit.Translatable = True
            '
            'txtOutstandingDeposits
            '
            Me.txtOutstandingDeposits.BackColor = System.Drawing.Color.White
            Me.txtOutstandingDeposits.BegFindValue = Nothing
            Me.txtOutstandingDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutstandingDeposits.ComputedValue = True
            Me.txtOutstandingDeposits.CustomFormat = Nothing
            Me.txtOutstandingDeposits.DataBoundControl = True
            Me.txtOutstandingDeposits.DisplayOnly = True
            Me.txtOutstandingDeposits.EditingMode = True
            Me.txtOutstandingDeposits.EndFindValue = Nothing
            Me.txtOutstandingDeposits.FieldDescription = Nothing
            Me.txtOutstandingDeposits.FieldName = Nothing
            Me.txtOutstandingDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtOutstandingDeposits.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.txtOutstandingDeposits, True)
            resources.ApplyResources(Me.txtOutstandingDeposits, "txtOutstandingDeposits")
            Me.txtOutstandingDeposits.ForeColor = System.Drawing.Color.Black
            Me.txtOutstandingDeposits.LinkedLabel = Nothing
            Me.txtOutstandingDeposits.MaximumValue = Nothing
            Me.txtOutstandingDeposits.MinimumValue = Nothing
            Me.txtOutstandingDeposits.Name = "txtOutstandingDeposits"
            Me.txtOutstandingDeposits.OldValue = Nothing
            Me.txtOutstandingDeposits.ReadOnly = True
            Me.txtOutstandingDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtOutstandingDeposits.TabStop = False
            Me.txtOutstandingDeposits.Translatable = False
            Me.txtOutstandingDeposits.ValueIsMandatory = True
            Me.txtOutstandingDeposits.ValueIsNumeric = True
            '
            'lblOutstandingCredits
            '
            Me.lblOutstandingCredits.BackColor = System.Drawing.Color.Transparent
            Me.lblOutstandingCredits.DisplayOnly = True
            Me.lblOutstandingCredits.EditingMode = False
            resources.ApplyResources(Me.lblOutstandingCredits, "lblOutstandingCredits")
            Me.lblOutstandingCredits.Name = "lblOutstandingCredits"
            Me.lblOutstandingCredits.Translatable = True
            '
            'lblGlSystemBalance
            '
            Me.lblGlSystemBalance.BackColor = System.Drawing.Color.Transparent
            Me.lblGlSystemBalance.DisplayOnly = True
            Me.lblGlSystemBalance.EditingMode = False
            resources.ApplyResources(Me.lblGlSystemBalance, "lblGlSystemBalance")
            Me.lblGlSystemBalance.Name = "lblGlSystemBalance"
            Me.lblGlSystemBalance.Translatable = True
            '
            'txtGlSystemBalance
            '
            Me.txtGlSystemBalance.BackColor = System.Drawing.Color.White
            Me.txtGlSystemBalance.BegFindValue = Nothing
            Me.txtGlSystemBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGlSystemBalance.ComputedValue = True
            Me.txtGlSystemBalance.CustomFormat = Nothing
            Me.txtGlSystemBalance.DataBoundControl = True
            Me.txtGlSystemBalance.DisplayOnly = True
            Me.txtGlSystemBalance.EditingMode = True
            Me.txtGlSystemBalance.EndFindValue = Nothing
            Me.txtGlSystemBalance.FieldDescription = Nothing
            Me.txtGlSystemBalance.FieldName = Nothing
            Me.txtGlSystemBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGlSystemBalance.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.txtGlSystemBalance, True)
            resources.ApplyResources(Me.txtGlSystemBalance, "txtGlSystemBalance")
            Me.txtGlSystemBalance.ForeColor = System.Drawing.Color.Black
            Me.txtGlSystemBalance.LinkedLabel = Nothing
            Me.txtGlSystemBalance.MaximumValue = Nothing
            Me.txtGlSystemBalance.MinimumValue = Nothing
            Me.txtGlSystemBalance.Name = "txtGlSystemBalance"
            Me.txtGlSystemBalance.OldValue = Nothing
            Me.txtGlSystemBalance.ReadOnly = True
            Me.txtGlSystemBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGlSystemBalance.TabStop = False
            Me.txtGlSystemBalance.Translatable = False
            Me.txtGlSystemBalance.ValueIsMandatory = True
            Me.txtGlSystemBalance.ValueIsNumeric = True
            '
            'CLabel7
            '
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.CLabel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            resources.ApplyResources(Me.CLabel7, "CLabel7")
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Translatable = True
            '
            'lblUnreconciledDifference
            '
            Me.lblUnreconciledDifference.BackColor = System.Drawing.Color.Transparent
            Me.lblUnreconciledDifference.DisplayOnly = True
            Me.lblUnreconciledDifference.EditingMode = False
            resources.ApplyResources(Me.lblUnreconciledDifference, "lblUnreconciledDifference")
            Me.lblUnreconciledDifference.Name = "lblUnreconciledDifference"
            Me.lblUnreconciledDifference.Translatable = True
            '
            'txtUnreconciledDifference
            '
            Me.txtUnreconciledDifference.BackColor = System.Drawing.Color.White
            Me.txtUnreconciledDifference.BegFindValue = Nothing
            Me.txtUnreconciledDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnreconciledDifference.ComputedValue = True
            Me.txtUnreconciledDifference.CustomFormat = Nothing
            Me.txtUnreconciledDifference.DataBoundControl = True
            Me.txtUnreconciledDifference.DisplayOnly = True
            Me.txtUnreconciledDifference.EditingMode = True
            Me.txtUnreconciledDifference.EndFindValue = Nothing
            Me.txtUnreconciledDifference.FieldDescription = Nothing
            Me.txtUnreconciledDifference.FieldName = Nothing
            Me.txtUnreconciledDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUnreconciledDifference.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.txtUnreconciledDifference, True)
            resources.ApplyResources(Me.txtUnreconciledDifference, "txtUnreconciledDifference")
            Me.txtUnreconciledDifference.ForeColor = System.Drawing.Color.Black
            Me.txtUnreconciledDifference.LinkedLabel = Nothing
            Me.txtUnreconciledDifference.MaximumValue = Nothing
            Me.txtUnreconciledDifference.MinimumValue = Nothing
            Me.txtUnreconciledDifference.Name = "txtUnreconciledDifference"
            Me.txtUnreconciledDifference.OldValue = Nothing
            Me.txtUnreconciledDifference.ReadOnly = True
            Me.txtUnreconciledDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUnreconciledDifference.TabStop = False
            Me.txtUnreconciledDifference.Translatable = False
            Me.txtUnreconciledDifference.ValueIsMandatory = True
            Me.txtUnreconciledDifference.ValueIsNumeric = True
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
            Me.DataGridViewReconciliationItems.AllowUserToAddRows = False
            Me.DataGridViewReconciliationItems.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewReconciliationItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewReconciliationItems.AutoGenerateColumns = False
            Me.DataGridViewReconciliationItems.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewReconciliationItems.BegFindValue = Nothing
            Me.DataGridViewReconciliationItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewReconciliationItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvReferenceNo, Me.dgvJournalIdNo, Me.dgvJournalItemIdNo, Me.dgvDocumentNumber, Me.dgvDebit, Me.dgvCredit, Me.dgvCleared, Me.dgvPayDescription})
            Me.DataGridViewReconciliationItems.DataSource = Me.bsAccountReconciliationItems
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewReconciliationItems.DefaultCellStyle = DataGridViewCellStyle13
            Me.DataGridViewReconciliationItems.DgvFooter = Nothing
            Me.DataGridViewReconciliationItems.DisplayOnly = False
            Me.DataGridViewReconciliationItems.Ea = Nothing
            Me.DataGridViewReconciliationItems.EditingMode = False
            Me.DataGridViewReconciliationItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewReconciliationItems.EndFindValue = Nothing
            Me.DataGridViewReconciliationItems.FieldDescription = Nothing
            Me.DataGridViewReconciliationItems.FieldName = Nothing
            Me.DataGridViewReconciliationItems.FieldsDictionary = Nothing
            Me.DataGridViewReconciliationItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewReconciliationItems.FindEnabled = False
            Me.DataGridViewReconciliationItems.FirstRowDeletionEnabled = False
            Me.DataGridViewReconciliationItems.FirstRowInsertionEnabled = False
            Me.DataGridViewReconciliationItems.IgnoreCase = False
            resources.ApplyResources(Me.DataGridViewReconciliationItems, "DataGridViewReconciliationItems")
            Me.DataGridViewReconciliationItems.Name = "DataGridViewReconciliationItems"
            Me.DataGridViewReconciliationItems.ReadOnly = True
            Me.DataGridViewReconciliationItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewReconciliationItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewReconciliationItems.SequenceFieldName = "Sequence"
            Me.DataGridViewReconciliationItems.ShowFooter = False
            Me.DataGridViewReconciliationItems.ShowInsertColumnWhenEditing = False
            Me.DataGridViewReconciliationItems.Translatable = True
            '
            'bsAccountReconciliationItems
            '
            Me.bsAccountReconciliationItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AccountReconciliationItemModel)
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTransactionDate.EditingMode = False
            Me.dgvTransactionDate.EndFindValue = Nothing
            Me.dgvTransactionDate.FieldDescription = Nothing
            Me.dgvTransactionDate.FieldName = Nothing
            Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvTransactionDate.FindEnabled = False
            resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
            Me.dgvTransactionDate.IgnoreCase = False
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvTransactionDate.Translatable = False
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.BegFindValue = Nothing
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvJournalCode.EditingMode = False
            Me.dgvJournalCode.EndFindValue = Nothing
            Me.dgvJournalCode.FieldDescription = Nothing
            Me.dgvJournalCode.FieldName = Nothing
            Me.dgvJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvJournalCode.FindEnabled = False
            resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
            Me.dgvJournalCode.IgnoreCase = False
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.ReadOnly = True
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalCode.Translatable = False
            '
            'dgvReferenceNo
            '
            Me.dgvReferenceNo.BegFindValue = Nothing
            Me.dgvReferenceNo.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvReferenceNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvReferenceNo.EditingMode = False
            Me.dgvReferenceNo.EndFindValue = Nothing
            Me.dgvReferenceNo.FieldDescription = Nothing
            Me.dgvReferenceNo.FieldName = Nothing
            Me.dgvReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvReferenceNo.FindEnabled = False
            resources.ApplyResources(Me.dgvReferenceNo, "dgvReferenceNo")
            Me.dgvReferenceNo.IgnoreCase = False
            Me.dgvReferenceNo.Name = "dgvReferenceNo"
            Me.dgvReferenceNo.ReadOnly = True
            Me.dgvReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvReferenceNo.Translatable = False
            '
            'dgvJournalIdNo
            '
            Me.dgvJournalIdNo.BegFindValue = Nothing
            Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvJournalIdNo.EditingMode = False
            Me.dgvJournalIdNo.EndFindValue = Nothing
            Me.dgvJournalIdNo.FieldDescription = Nothing
            Me.dgvJournalIdNo.FieldName = Nothing
            Me.dgvJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvJournalIdNo.FindEnabled = False
            resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
            Me.dgvJournalIdNo.IgnoreCase = False
            Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
            Me.dgvJournalIdNo.ReadOnly = True
            Me.dgvJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalIdNo.Translatable = False
            '
            'dgvJournalItemIdNo
            '
            Me.dgvJournalItemIdNo.BegFindValue = Nothing
            Me.dgvJournalItemIdNo.DataPropertyName = "JournalItemIDNo"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalItemIdNo.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvJournalItemIdNo.EditingMode = False
            Me.dgvJournalItemIdNo.EndFindValue = Nothing
            Me.dgvJournalItemIdNo.FieldDescription = Nothing
            Me.dgvJournalItemIdNo.FieldName = Nothing
            Me.dgvJournalItemIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvJournalItemIdNo.FindEnabled = False
            resources.ApplyResources(Me.dgvJournalItemIdNo, "dgvJournalItemIdNo")
            Me.dgvJournalItemIdNo.IgnoreCase = False
            Me.dgvJournalItemIdNo.Name = "dgvJournalItemIdNo"
            Me.dgvJournalItemIdNo.ReadOnly = True
            Me.dgvJournalItemIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalItemIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalItemIdNo.Translatable = False
            '
            'dgvDocumentNumber
            '
            Me.dgvDocumentNumber.BegFindValue = Nothing
            Me.dgvDocumentNumber.DataPropertyName = "DocumentNumber"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvDocumentNumber.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDocumentNumber.DisplayOnly = True
            Me.dgvDocumentNumber.EditingMode = False
            Me.dgvDocumentNumber.EndFindValue = Nothing
            Me.dgvDocumentNumber.FieldDescription = Nothing
            Me.dgvDocumentNumber.FieldName = Nothing
            Me.dgvDocumentNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDocumentNumber.FindEnabled = False
            resources.ApplyResources(Me.dgvDocumentNumber, "dgvDocumentNumber")
            Me.dgvDocumentNumber.IgnoreCase = False
            Me.dgvDocumentNumber.Name = "dgvDocumentNumber"
            Me.dgvDocumentNumber.ReadOnly = True
            Me.dgvDocumentNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDocumentNumber.Translatable = False
            '
            'dgvDebit
            '
            Me.dgvDebit.BegFindValue = Nothing
            Me.dgvDebit.DataPropertyName = "Debit"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDebit.EditingMode = False
            Me.dgvDebit.EndFindValue = Nothing
            Me.dgvDebit.FieldDescription = Nothing
            Me.dgvDebit.FieldName = Nothing
            Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDebit.FindEnabled = False
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDebit.Translatable = False
            '
            'dgvCredit
            '
            Me.dgvCredit.BegFindValue = Nothing
            Me.dgvCredit.DataPropertyName = "Credit"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvCredit.EditingMode = False
            Me.dgvCredit.EndFindValue = Nothing
            Me.dgvCredit.FieldDescription = Nothing
            Me.dgvCredit.FieldName = Nothing
            Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvCredit.FindEnabled = False
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvCredit.Translatable = False
            '
            'dgvCleared
            '
            Me.dgvCleared.BegFindValue = Nothing
            Me.dgvCleared.DataPropertyName = "Cleared"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Orange
            DataGridViewCellStyle11.NullValue = False
            Me.dgvCleared.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvCleared.EditingMode = False
            Me.dgvCleared.EndFindValue = Nothing
            Me.dgvCleared.FieldDescription = Nothing
            Me.dgvCleared.FieldName = Nothing
            Me.dgvCleared.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvCleared.FindEnabled = False
            resources.ApplyResources(Me.dgvCleared, "dgvCleared")
            Me.dgvCleared.IgnoreCase = False
            Me.dgvCleared.Name = "dgvCleared"
            Me.dgvCleared.ReadOnly = True
            Me.dgvCleared.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCleared.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvCleared.Translatable = False
            '
            'dgvPayDescription
            '
            Me.dgvPayDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvPayDescription.BegFindValue = Nothing
            Me.dgvPayDescription.DataPropertyName = "PayDescription"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvPayDescription.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvPayDescription.DisplayOnly = True
            Me.dgvPayDescription.EditingMode = False
            Me.dgvPayDescription.EndFindValue = Nothing
            Me.dgvPayDescription.FieldDescription = Nothing
            Me.dgvPayDescription.FieldName = Nothing
            Me.dgvPayDescription.FillWeight = 10.0!
            Me.dgvPayDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPayDescription.FindEnabled = False
            resources.ApplyResources(Me.dgvPayDescription, "dgvPayDescription")
            Me.dgvPayDescription.IgnoreCase = False
            Me.dgvPayDescription.Name = "dgvPayDescription"
            Me.dgvPayDescription.ReadOnly = True
            Me.dgvPayDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPayDescription.Translatable = False
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
        Friend WithEvents txtOutstandingCredits As CTextBox
        Friend WithEvents txtTotalQtyCreditsCleared As CTextBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblEndingBankBalance As CLabel
        Friend WithEvents lblCreditsCleared As CLabel
        Friend WithEvents txtTotalCreditsCleared As CTextBox
        Friend WithEvents lblOutstandingCredits As CLabel
        Friend WithEvents txtOutstandingDeposits As CTextBox
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
        Friend WithEvents dgvAccountIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents CFlowLayout7 As CFlowLayout
        Friend WithEvents btnPost As CButton
        Friend WithEvents CFlowLayout8 As CFlowLayout
        Friend WithEvents btnClearAll As CButton
        Friend WithEvents btnUnClearAll As CButton
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvJournalCode As CDgvTextColumn
        Friend WithEvents dgvReferenceNo As CDgvTextColumn
        Friend WithEvents dgvJournalIdNo As CDgvTextColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvDocumentNumber As CDgvTextColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvCleared As CDgvCheckBoxColumn
        Friend WithEvents dgvPayDescription As CDgvTextColumn
    End Class
End NameSpace