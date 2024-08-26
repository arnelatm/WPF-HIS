Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GeneralJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralJournalEntry))
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkClosingJournal = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblClosing = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblApproved = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SpecialAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DiscountTakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaidAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floJournalHeader.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.SuspendLayout()
            '
            'floJournalHeader
            '
            Me.floJournalHeader.BackColor = System.Drawing.Color.Transparent
            Me.floJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floJournalHeader.Controls.Add(Me.CFlowLayout1)
            Me.floJournalHeader.Controls.Add(Me.CFlowLayout2)
            resources.ApplyResources(Me.floJournalHeader, "floJournalHeader")
            Me.floJournalHeader.Name = "floJournalHeader"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.txtJournalCode)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblReferenceNo)
            Me.CFlowLayout1.Controls.Add(Me.txtReferenceNo)
            Me.CFlowLayout1.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.chkClosingJournal)
            Me.CFlowLayout1.Controls.Add(Me.lblClosing)
            Me.CFlowLayout1.Controls.Add(Me.lblNotes)
            Me.CFlowLayout1.Controls.Add(Me.txtNotes)
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
            'txtJournalCode
            '
            Me.txtJournalCode.BackColor = System.Drawing.Color.White
            Me.txtJournalCode.BegFindValue = Nothing
            Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalCode.ComputedValue = False
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.EditingMode = True
            Me.txtJournalCode.EndFindValue = Nothing
            Me.txtJournalCode.FieldDescription = Nothing
            Me.txtJournalCode.FieldName = Nothing
            Me.txtJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalCode.FindEnabled = False
            resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.OverrideMaxLength = 0
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.Translatable = False
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
            Me.TxtIdNo.FindEnabled = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Translatable = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BegFindValue = Nothing
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.EndFindValue = Nothing
            Me.txtReferenceNo.FieldDescription = Nothing
            Me.txtReferenceNo.FieldName = Nothing
            Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReferenceNo.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtReferenceNo, True)
            resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
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
            'dtpTransactionDate
            '
            resources.ApplyResources(Me.dtpTransactionDate, "dtpTransactionDate")
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Translatable = True
            '
            'chkClosingJournal
            '
            Me.chkClosingJournal.AutoCheck = False
            Me.chkClosingJournal.BackColor = System.Drawing.Color.White
            Me.chkClosingJournal.BegFindValue = Nothing
            Me.chkClosingJournal.DisplayOnly = True
            Me.chkClosingJournal.EditingMode = True
            Me.chkClosingJournal.EndFindValue = Nothing
            Me.chkClosingJournal.FieldDescription = Nothing
            Me.chkClosingJournal.FieldName = Nothing
            Me.chkClosingJournal.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkClosingJournal.FindEnabled = False
            resources.ApplyResources(Me.chkClosingJournal, "chkClosingJournal")
            Me.chkClosingJournal.ForeColor = System.Drawing.Color.Black
            Me.chkClosingJournal.IFindableControl_FindEnabled = False
            Me.chkClosingJournal.IgnoreCase = False
            Me.chkClosingJournal.LinkedLabel = Nothing
            Me.chkClosingJournal.Name = "chkClosingJournal"
            Me.chkClosingJournal.NoLabel = True
            Me.chkClosingJournal.OldValue = Nothing
            Me.chkClosingJournal.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkClosingJournal.Translatable = False
            Me.chkClosingJournal.UseVisualStyleBackColor = False
            '
            'lblClosing
            '
            resources.ApplyResources(Me.lblClosing, "lblClosing")
            Me.lblClosing.BackColor = System.Drawing.Color.Transparent
            Me.lblClosing.DisplayOnly = True
            Me.lblClosing.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.lblClosing, True)
            Me.lblClosing.Name = "lblClosing"
            Me.lblClosing.Translatable = True
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
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.CLabel3)
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.lblCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkApproved)
            Me.CFlowLayout2.Controls.Add(Me.lblApproved)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.dtpDateCreated)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'chkPosted
            '
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.BegFindValue = Nothing
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = True
            Me.chkPosted.EndFindValue = Nothing
            Me.chkPosted.FieldDescription = Nothing
            Me.chkPosted.FieldName = Nothing
            Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPosted.FindEnabled = False
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.IFindableControl_FindEnabled = False
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.NoLabel = True
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.Translatable = False
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'CLabel3
            '
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.CLabel3, True)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Translatable = True
            '
            'chkCancelled
            '
            Me.chkCancelled.AutoCheck = False
            Me.chkCancelled.BackColor = System.Drawing.Color.White
            Me.chkCancelled.BegFindValue = Nothing
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = True
            Me.chkCancelled.EndFindValue = Nothing
            Me.chkCancelled.FieldDescription = Nothing
            Me.chkCancelled.FieldName = Nothing
            Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCancelled.FindEnabled = False
            resources.ApplyResources(Me.chkCancelled, "chkCancelled")
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.IFindableControl_FindEnabled = False
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.NoLabel = True
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCancelled.Translatable = False
            Me.chkCancelled.UseVisualStyleBackColor = False
            '
            'lblCancelled
            '
            resources.ApplyResources(Me.lblCancelled, "lblCancelled")
            Me.lblCancelled.BackColor = System.Drawing.Color.Transparent
            Me.lblCancelled.DisplayOnly = True
            Me.lblCancelled.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblCancelled, True)
            Me.lblCancelled.Name = "lblCancelled"
            Me.lblCancelled.Translatable = True
            '
            'chkApproved
            '
            Me.chkApproved.BackColor = System.Drawing.Color.White
            Me.chkApproved.BegFindValue = Nothing
            Me.chkApproved.DisplayOnly = False
            Me.chkApproved.EditingMode = True
            Me.chkApproved.EndFindValue = Nothing
            Me.chkApproved.FieldDescription = Nothing
            Me.chkApproved.FieldName = Nothing
            Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkApproved.FindEnabled = False
            resources.ApplyResources(Me.chkApproved, "chkApproved")
            Me.chkApproved.ForeColor = System.Drawing.Color.Black
            Me.chkApproved.IFindableControl_FindEnabled = False
            Me.chkApproved.IgnoreCase = False
            Me.chkApproved.LinkedLabel = Nothing
            Me.chkApproved.Name = "chkApproved"
            Me.chkApproved.NoLabel = True
            Me.chkApproved.OldValue = Nothing
            Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkApproved.Translatable = False
            Me.chkApproved.UseVisualStyleBackColor = False
            '
            'lblApproved
            '
            resources.ApplyResources(Me.lblApproved, "lblApproved")
            Me.lblApproved.BackColor = System.Drawing.Color.Transparent
            Me.lblApproved.DisplayOnly = True
            Me.lblApproved.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblApproved, True)
            Me.lblApproved.Name = "lblApproved"
            Me.lblApproved.Translatable = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Translatable = True
            '
            'dtpDateCreated
            '
            resources.ApplyResources(Me.dtpDateCreated, "dtpDateCreated")
            Me.dtpDateCreated.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDateCreated.DefaultValue = Nothing
            Me.dtpDateCreated.DisplayOnly = True
            Me.dtpDateCreated.DtpDefaultValue = Nothing
            Me.dtpDateCreated.EditingMode = False
            Me.dtpDateCreated.EditsAllowed = False
            Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
            Me.dtpDateCreated.LinkedLabel = Nothing
            Me.dtpDateCreated.Name = "dtpDateCreated"
            Me.dtpDateCreated.ReadOnlyDp = True
            Me.dtpDateCreated.SecurityKey = Nothing
            Me.dtpDateCreated.ShowLongDate = False
            Me.dtpDateCreated.ShowTime = True
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Translatable = False
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewJournalItems.BegFindValue = Nothing
            Me.DataGridViewJournalItems.Cached = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvContactIdNo, Me.dgvNotes, Me.dgvIdNo, Me.SpecialAccount, Me.AccountIdNoDataGridViewTextBoxColumn, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.DiscountTakenDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn})
            Me.DataGridViewJournalItems.DataFilter = Nothing
            Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle18
            Me.DataGridViewJournalItems.DgvFooter = Nothing
            Me.DataGridViewJournalItems.DisplayOnly = False
            Me.DataGridViewJournalItems.Ea = EventAggregator2
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.EndFindValue = Nothing
            Me.DataGridViewJournalItems.FieldDescription = Nothing
            Me.DataGridViewJournalItems.FieldName = Nothing
            Me.DataGridViewJournalItems.FieldsDictionary = Nothing
            Me.DataGridViewJournalItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewJournalItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewJournalItems.FindEnabled = False
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = True
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.DataGridViewJournalItems, True)
            Me.DataGridViewJournalItems.IgnoreCase = False
            Me.DataGridViewJournalItems.IsDirty = False
            resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.OldCellValue = Nothing
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.Searchable = True
            Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewJournalItems.SecurityKey = ""
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.Translatable = True
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle11
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
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoComplete = False
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.SuggestCharCount = 0
            Me.dgvAccountIdNo.Translatable = False
            '
            'dgvDebit
            '
            Me.dgvDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvDebit.BegFindValue = Nothing
            Me.dgvDebit.DataPropertyName = "Debit"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "N2"
            Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle13
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
            Me.dgvCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvCredit.BegFindValue = Nothing
            Me.dgvCredit.DataPropertyName = "Credit"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "N2"
            Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle14
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
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoComplete = False
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvRevCostCenterIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRevCostCenterIdNo.SuggestCharCount = 0
            Me.dgvRevCostCenterIdNo.Translatable = False
            '
            'dgvContactIdNo
            '
            Me.dgvContactIdNo.AutoComplete = False
            Me.dgvContactIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvContactIdNo.DataPropertyName = "ContactIdNo"
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvContactIdNo.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvContactIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvContactIdNo, "dgvContactIdNo")
            Me.dgvContactIdNo.Name = "dgvContactIdNo"
            Me.dgvContactIdNo.ReadOnly = True
            Me.dgvContactIdNo.SuggestCharCount = 0
            Me.dgvContactIdNo.Translatable = False
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.BegFindValue = Nothing
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.EndFindValue = Nothing
            Me.dgvNotes.FieldDescription = Nothing
            Me.dgvNotes.FieldName = Nothing
            Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNotes.FindEnabled = False
            resources.ApplyResources(Me.dgvNotes, "dgvNotes")
            Me.dgvNotes.IgnoreCase = False
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNotes.Translatable = False
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            '
            'SpecialAccount
            '
            Me.SpecialAccount.DataPropertyName = "SpecialAccount"
            resources.ApplyResources(Me.SpecialAccount, "SpecialAccount")
            Me.SpecialAccount.Name = "SpecialAccount"
            Me.SpecialAccount.ReadOnly = True
            '
            'AccountIdNoDataGridViewTextBoxColumn
            '
            Me.AccountIdNoDataGridViewTextBoxColumn.DataPropertyName = "AccountIdNo"
            resources.ApplyResources(Me.AccountIdNoDataGridViewTextBoxColumn, "AccountIdNoDataGridViewTextBoxColumn")
            Me.AccountIdNoDataGridViewTextBoxColumn.Name = "AccountIdNoDataGridViewTextBoxColumn"
            Me.AccountIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            resources.ApplyResources(Me.CancelledDataGridViewCheckBoxColumn, "CancelledDataGridViewCheckBoxColumn")
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'DiscountTakenDataGridViewTextBoxColumn
            '
            Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
            resources.ApplyResources(Me.DiscountTakenDataGridViewTextBoxColumn, "DiscountTakenDataGridViewTextBoxColumn")
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            resources.ApplyResources(Me.JournalIdNoDataGridViewTextBoxColumn, "JournalIdNoDataGridViewTextBoxColumn")
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OpenInvoiceIdNoDataGridViewTextBoxColumn
            '
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.DataPropertyName = "OpenInvoiceIdNo"
            resources.ApplyResources(Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, "OpenInvoiceIdNoDataGridViewTextBoxColumn")
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OriginalAmountDataGridViewTextBoxColumn
            '
            Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
            resources.ApplyResources(Me.OriginalAmountDataGridViewTextBoxColumn, "OriginalAmountDataGridViewTextBoxColumn")
            Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
            Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaidAmountDataGridViewTextBoxColumn
            '
            Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
            resources.ApplyResources(Me.PaidAmountDataGridViewTextBoxColumn, "PaidAmountDataGridViewTextBoxColumn")
            Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
            Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayeeTypeDataGridViewTextBoxColumn
            '
            Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
            resources.ApplyResources(Me.PayeeTypeDataGridViewTextBoxColumn, "PayeeTypeDataGridViewTextBoxColumn")
            Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
            Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.floJournalHeader)
            Me.CFlowLayout4.Controls.Add(Me.DataGridViewJournalItems)
            Me.CFlowLayout4.Controls.Add(Me.txtTotalCredits)
            Me.CFlowLayout4.Controls.Add(Me.txtTotalDebits)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'txtTotalCredits
            '
            Me.txtTotalCredits.BackColor = System.Drawing.Color.White
            Me.txtTotalCredits.BegFindValue = Nothing
            Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCredits.ComputedValue = False
            Me.txtTotalCredits.CustomFormat = Nothing
            Me.txtTotalCredits.DataBoundControl = True
            Me.txtTotalCredits.EditingMode = True
            Me.txtTotalCredits.EndFindValue = Nothing
            Me.txtTotalCredits.FieldDescription = Nothing
            Me.txtTotalCredits.FieldName = Nothing
            Me.txtTotalCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalCredits.FindEnabled = False
            resources.ApplyResources(Me.txtTotalCredits, "txtTotalCredits")
            Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCredits.LinkedLabel = Nothing
            Me.txtTotalCredits.MaximumValue = Nothing
            Me.txtTotalCredits.MinimumValue = Nothing
            Me.txtTotalCredits.Name = "txtTotalCredits"
            Me.txtTotalCredits.OldValue = Nothing
            Me.txtTotalCredits.OverrideMaxLength = 0
            Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCredits.Translatable = False
            '
            'txtTotalDebits
            '
            Me.txtTotalDebits.BackColor = System.Drawing.Color.White
            Me.txtTotalDebits.BegFindValue = Nothing
            Me.txtTotalDebits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDebits.ComputedValue = False
            Me.txtTotalDebits.CustomFormat = Nothing
            Me.txtTotalDebits.DataBoundControl = True
            Me.txtTotalDebits.EditingMode = True
            Me.txtTotalDebits.EndFindValue = Nothing
            Me.txtTotalDebits.FieldDescription = Nothing
            Me.txtTotalDebits.FieldName = Nothing
            Me.txtTotalDebits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDebits.FindEnabled = False
            resources.ApplyResources(Me.txtTotalDebits, "txtTotalDebits")
            Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebits.LinkedLabel = Nothing
            Me.txtTotalDebits.MaximumValue = Nothing
            Me.txtTotalDebits.MinimumValue = Nothing
            Me.txtTotalDebits.Name = "txtTotalDebits"
            Me.txtTotalDebits.OldValue = Nothing
            Me.txtTotalDebits.OverrideMaxLength = 0
            Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebits.Translatable = False
            '
            'GeneralJournalEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CFlowLayout4)
            Me.Name = "GeneralJournalEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floJournalHeader.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floJournalHeader As CFlowLayout
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents DataGridViewJournalItems As CtDataGridView
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkApproved As CCheckBox
        Friend WithEvents lblApproved As CLabel
        Friend WithEvents chkClosingJournal As CCheckBox
        Friend WithEvents lblClosing As CLabel
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents dgvPayIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvContactIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccount As DataGridViewTextBoxColumn
        Friend WithEvents AccountIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End NameSpace