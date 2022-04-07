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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecialAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floJournalHeader.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout4.SuspendLayout
        Me.SuspendLayout
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'txtJournalCode
        '
        Me.txtJournalCode.BackColor = System.Drawing.Color.White
        Me.txtJournalCode.BegFindValue = Nothing
        Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJournalCode.ComputedValue = false
        Me.txtJournalCode.CustomFormat = Nothing
        Me.txtJournalCode.DataBoundControl = true
        Me.txtJournalCode.EditingMode = true
        Me.txtJournalCode.EndFindValue = Nothing
        Me.txtJournalCode.FieldDescription = Nothing
        Me.txtJournalCode.FieldName = Nothing
        Me.txtJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtJournalCode.FindEnabled = false
        resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
        Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
        Me.txtJournalCode.LinkedLabel = Nothing
        Me.txtJournalCode.MaximumValue = Nothing
        Me.txtJournalCode.MinimumValue = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtJournalCode.Translatable = false
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
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Translatable = true
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BegFindValue = Nothing
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = false
        Me.txtReferenceNo.EndFindValue = Nothing
        Me.txtReferenceNo.FieldDescription = Nothing
        Me.txtReferenceNo.FieldName = Nothing
        Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtReferenceNo.FindEnabled = true
        Me.CFlowLayout1.SetFlowBreak(Me.txtReferenceNo, true)
        resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Translatable = false
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Translatable = true
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpTransactionDate.DefaultValue = Nothing
        Me.dtpTransactionDate.DisplayOnly = false
        Me.dtpTransactionDate.DtpDefaultValue = Nothing
        Me.dtpTransactionDate.EditingMode = false
        Me.dtpTransactionDate.EditsAllowed = false
        resources.ApplyResources(Me.dtpTransactionDate, "dtpTransactionDate")
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Translatable = true
        '
        'chkClosingJournal
        '
        Me.chkClosingJournal.AutoCheck = false
        Me.chkClosingJournal.BackColor = System.Drawing.Color.White
        Me.chkClosingJournal.BegFindValue = Nothing
        Me.chkClosingJournal.DisplayOnly = true
        Me.chkClosingJournal.EditingMode = true
        Me.chkClosingJournal.EndFindValue = Nothing
        Me.chkClosingJournal.FieldDescription = Nothing
        Me.chkClosingJournal.FieldName = Nothing
        Me.chkClosingJournal.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkClosingJournal.FindEnabled = false
        resources.ApplyResources(Me.chkClosingJournal, "chkClosingJournal")
        Me.chkClosingJournal.ForeColor = System.Drawing.Color.Black
        Me.chkClosingJournal.IFindableControl_FindEnabled = false
        Me.chkClosingJournal.IgnoreCase = false
        Me.chkClosingJournal.LinkedLabel = Nothing
        Me.chkClosingJournal.Name = "chkClosingJournal"
        Me.chkClosingJournal.NoLabel = true
        Me.chkClosingJournal.OldValue = Nothing
        Me.chkClosingJournal.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkClosingJournal.Translatable = false
        Me.chkClosingJournal.UseVisualStyleBackColor = false
        '
        'lblClosing
        '
        resources.ApplyResources(Me.lblClosing, "lblClosing")
        Me.lblClosing.DisplayOnly = true
        Me.lblClosing.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.lblClosing, true)
        Me.lblClosing.Name = "lblClosing"
        Me.lblClosing.Translatable = true
        '
        'lblNotes
        '
        Me.lblNotes.BackColor = System.Drawing.Color.Transparent
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Me.lblNotes
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
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
        Me.chkPosted.AutoCheck = false
        Me.chkPosted.BackColor = System.Drawing.Color.White
        Me.chkPosted.BegFindValue = Nothing
        Me.chkPosted.DisplayOnly = true
        Me.chkPosted.EditingMode = true
        Me.chkPosted.EndFindValue = Nothing
        Me.chkPosted.FieldDescription = Nothing
        Me.chkPosted.FieldName = Nothing
        Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkPosted.FindEnabled = false
        resources.ApplyResources(Me.chkPosted, "chkPosted")
        Me.chkPosted.ForeColor = System.Drawing.Color.Black
        Me.chkPosted.IFindableControl_FindEnabled = false
        Me.chkPosted.IgnoreCase = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.NoLabel = true
        Me.chkPosted.OldValue = Nothing
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.Translatable = false
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'CLabel3
        '
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CFlowLayout2.SetFlowBreak(Me.CLabel3, true)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Translatable = true
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoCheck = false
        Me.chkCancelled.BackColor = System.Drawing.Color.White
        Me.chkCancelled.BegFindValue = Nothing
        Me.chkCancelled.DisplayOnly = true
        Me.chkCancelled.EditingMode = true
        Me.chkCancelled.EndFindValue = Nothing
        Me.chkCancelled.FieldDescription = Nothing
        Me.chkCancelled.FieldName = Nothing
        Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkCancelled.FindEnabled = false
        resources.ApplyResources(Me.chkCancelled, "chkCancelled")
        Me.chkCancelled.ForeColor = System.Drawing.Color.Black
        Me.chkCancelled.IFindableControl_FindEnabled = false
        Me.chkCancelled.IgnoreCase = false
        Me.chkCancelled.LinkedLabel = Nothing
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.NoLabel = true
        Me.chkCancelled.OldValue = Nothing
        Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkCancelled.Translatable = false
        Me.chkCancelled.UseVisualStyleBackColor = false
        '
        'lblCancelled
        '
        resources.ApplyResources(Me.lblCancelled, "lblCancelled")
        Me.lblCancelled.DisplayOnly = true
        Me.lblCancelled.EditingMode = false
        Me.CFlowLayout2.SetFlowBreak(Me.lblCancelled, true)
        Me.lblCancelled.Name = "lblCancelled"
        Me.lblCancelled.Translatable = true
        '
        'chkApproved
        '
        Me.chkApproved.BackColor = System.Drawing.Color.White
        Me.chkApproved.BegFindValue = Nothing
        Me.chkApproved.DisplayOnly = false
        Me.chkApproved.EditingMode = true
        Me.chkApproved.EndFindValue = Nothing
        Me.chkApproved.FieldDescription = Nothing
        Me.chkApproved.FieldName = Nothing
        Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkApproved.FindEnabled = false
        resources.ApplyResources(Me.chkApproved, "chkApproved")
        Me.chkApproved.ForeColor = System.Drawing.Color.Black
        Me.chkApproved.IFindableControl_FindEnabled = false
        Me.chkApproved.IgnoreCase = false
        Me.chkApproved.LinkedLabel = Nothing
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.NoLabel = true
        Me.chkApproved.OldValue = Nothing
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Translatable = false
        Me.chkApproved.UseVisualStyleBackColor = false
        '
        'lblApproved
        '
        resources.ApplyResources(Me.lblApproved, "lblApproved")
        Me.lblApproved.DisplayOnly = true
        Me.lblApproved.EditingMode = false
        Me.CFlowLayout2.SetFlowBreak(Me.lblApproved, true)
        Me.lblApproved.Name = "lblApproved"
        Me.lblApproved.Translatable = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateCreated.DefaultValue = Nothing
        Me.dtpDateCreated.DisplayOnly = true
        Me.dtpDateCreated.DtpDefaultValue = Nothing
        Me.dtpDateCreated.EditingMode = false
        Me.dtpDateCreated.EditsAllowed = false
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        resources.ApplyResources(Me.dtpDateCreated, "dtpDateCreated")
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = true
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.TargetCalendar = Nothing
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.SpecialAccount, Me.PayIdNoDataGridViewTextBoxColumn})
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewJournalItems.DgvFooter = Nothing
        Me.DataGridViewJournalItems.DisplayOnly = false
        Me.DataGridViewJournalItems.Ea = EventAggregator1
        Me.DataGridViewJournalItems.EditingMode = false
        Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewJournalItems.EndFindValue = Nothing
        Me.DataGridViewJournalItems.FieldDescription = Nothing
        Me.DataGridViewJournalItems.FieldName = Nothing
        Me.DataGridViewJournalItems.FieldsDictionary = Nothing
        Me.DataGridViewJournalItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewJournalItems.FindEnabled = false
        Me.DataGridViewJournalItems.FirstRowDeletionEnabled = true
        Me.DataGridViewJournalItems.FirstRowInsertionEnabled = true
        Me.DataGridViewJournalItems.IgnoreCase = false
        Me.DataGridViewJournalItems.IsDirty = false
        resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewJournalItems.SecurityKey = ""
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewJournalItems.Translatable = true
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
        resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
        Me.CFlowLayout4.Name = "CFlowLayout4"
        '
        'txtTotalDebits
        '
        Me.txtTotalDebits.BackColor = System.Drawing.Color.White
        Me.txtTotalDebits.BegFindValue = Nothing
        Me.txtTotalDebits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebits.ComputedValue = false
        Me.txtTotalDebits.CustomFormat = Nothing
        Me.txtTotalDebits.DataBoundControl = true
        Me.txtTotalDebits.EditingMode = true
        Me.txtTotalDebits.EndFindValue = Nothing
        Me.txtTotalDebits.FieldDescription = Nothing
        Me.txtTotalDebits.FieldName = Nothing
        Me.txtTotalDebits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDebits.FindEnabled = false
        resources.ApplyResources(Me.txtTotalDebits, "txtTotalDebits")
        Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebits.LinkedLabel = Nothing
        Me.txtTotalDebits.MaximumValue = Nothing
        Me.txtTotalDebits.MinimumValue = Nothing
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebits.Translatable = false
        '
        'txtTotalCredits
        '
        Me.txtTotalCredits.BackColor = System.Drawing.Color.White
        Me.txtTotalCredits.BegFindValue = Nothing
        Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCredits.ComputedValue = false
        Me.txtTotalCredits.CustomFormat = Nothing
        Me.txtTotalCredits.DataBoundControl = true
        Me.txtTotalCredits.EditingMode = true
        Me.txtTotalCredits.EndFindValue = Nothing
        Me.txtTotalCredits.FieldDescription = Nothing
        Me.txtTotalCredits.FieldName = Nothing
        Me.txtTotalCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalCredits.FindEnabled = false
        resources.ApplyResources(Me.txtTotalCredits, "txtTotalCredits")
        Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredits.LinkedLabel = Nothing
        Me.txtTotalCredits.MaximumValue = Nothing
        Me.txtTotalCredits.MinimumValue = Nothing
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCredits.Translatable = false
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.Translatable = false
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoComplete = false
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.Translatable = false
        '
        'dgvDebit
        '
        Me.dgvDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDebit.BegFindValue = Nothing
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.EndFindValue = Nothing
        Me.dgvDebit.FieldDescription = Nothing
        Me.dgvDebit.FieldName = Nothing
        Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDebit.FindEnabled = false
        resources.ApplyResources(Me.dgvDebit, "dgvDebit")
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.ReadOnly = true
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDebit.Translatable = false
        '
        'dgvCredit
        '
        Me.dgvCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCredit.BegFindValue = Nothing
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "N2"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCredit.EditingMode = false
        Me.dgvCredit.EndFindValue = Nothing
        Me.dgvCredit.FieldDescription = Nothing
        Me.dgvCredit.FieldName = Nothing
        Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvCredit.FindEnabled = false
        resources.ApplyResources(Me.dgvCredit, "dgvCredit")
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvCredit.Translatable = false
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.AutoComplete = false
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.Translatable = false
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.BegFindValue = Nothing
        Me.dgvNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.EndFindValue = Nothing
        Me.dgvNotes.FieldDescription = Nothing
        Me.dgvNotes.FieldName = Nothing
        Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotes.FindEnabled = false
        resources.ApplyResources(Me.dgvNotes, "dgvNotes")
        Me.dgvNotes.IgnoreCase = false
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotes.Translatable = false
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        '
        'SpecialAccount
        '
        Me.SpecialAccount.DataPropertyName = "SpecialAccount"
        resources.ApplyResources(Me.SpecialAccount, "SpecialAccount")
        Me.SpecialAccount.Name = "SpecialAccount"
        Me.SpecialAccount.ReadOnly = true
        '
        'PayIdNoDataGridViewTextBoxColumn
        '
        Me.PayIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayIdNo"
        resources.ApplyResources(Me.PayIdNoDataGridViewTextBoxColumn, "PayIdNoDataGridViewTextBoxColumn")
        Me.PayIdNoDataGridViewTextBoxColumn.Name = "PayIdNoDataGridViewTextBoxColumn"
        Me.PayIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'GeneralJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtTotalCredits)
        Me.Controls.Add(Me.txtTotalDebits)
        Me.Controls.Add(Me.CFlowLayout4)
        Me.Name = "GeneralJournalEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDebits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalCredits, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floJournalHeader.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout4.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floJournalHeader As CFlowLayout
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents DataGridViewJournalItems As CDataGridView
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
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccount As DataGridViewTextBoxColumn
        Friend WithEvents PayIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End NameSpace