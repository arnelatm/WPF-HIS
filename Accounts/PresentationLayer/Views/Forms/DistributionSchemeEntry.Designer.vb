Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DistributionSchemeEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DistributionSchemeEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.floJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDistributionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDistributionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDistributionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDistributionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDistributionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDistributionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblValidityStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDistributionSchemeItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.txtTotalPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvRevCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.Percentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvDistributionSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floJournalHeader.SuspendLayout
        CType(Me.DataGridViewDistributionSchemeItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDistributionSchemeItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'floJournalHeader
        '
        Me.floJournalHeader.BackColor = System.Drawing.Color.Transparent
        Me.floJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floJournalHeader.Controls.Add(Me.lblIdNo)
        Me.floJournalHeader.Controls.Add(Me.TxtIdNo)
        Me.floJournalHeader.Controls.Add(Me.lblDistributionSchemeCode)
        Me.floJournalHeader.Controls.Add(Me.txtDistributionSchemeCode)
        Me.floJournalHeader.Controls.Add(Me.lblDistributionSchemeName)
        Me.floJournalHeader.Controls.Add(Me.txtDistributionSchemeName)
        Me.floJournalHeader.Controls.Add(Me.lblDistributionSchemeNameAra)
        Me.floJournalHeader.Controls.Add(Me.txtDistributionSchemeNameAra)
        Me.floJournalHeader.Controls.Add(Me.lblValidityStartDate)
        Me.floJournalHeader.Controls.Add(Me.dtpValidityStartDate)
        Me.floJournalHeader.Controls.Add(Me.lblValidityEndDate)
        Me.floJournalHeader.Controls.Add(Me.dtpValidityEndDate)
        Me.floJournalHeader.Controls.Add(Me.lblNotes)
        Me.floJournalHeader.Controls.Add(Me.txtNotes)
        resources.ApplyResources(Me.floJournalHeader, "floJournalHeader")
        Me.floJournalHeader.Name = "floJournalHeader"
        '
        'lblIdNo
        '
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
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.floJournalHeader.SetFlowBreak(Me.TxtIdNo, true)
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
        'lblDistributionSchemeCode
        '
        Me.lblDistributionSchemeCode.DisplayOnly = true
        Me.lblDistributionSchemeCode.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeCode, "lblDistributionSchemeCode")
        Me.lblDistributionSchemeCode.Name = "lblDistributionSchemeCode"
        '
        'txtDistributionSchemeCode
        '
        Me.txtDistributionSchemeCode.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeCode.BegFindValue = Nothing
        Me.txtDistributionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeCode.ComputedValue = false
        Me.txtDistributionSchemeCode.CustomFormat = Nothing
        Me.txtDistributionSchemeCode.DataBoundControl = true
        Me.txtDistributionSchemeCode.EditingMode = false
        Me.txtDistributionSchemeCode.EndFindValue = Nothing
        Me.txtDistributionSchemeCode.FieldDescription = Nothing
        Me.txtDistributionSchemeCode.FieldName = Nothing
        Me.txtDistributionSchemeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDistributionSchemeCode.FindEnabled = true
        Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeCode, true)
        resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
        Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeCode.LinkedLabel = Me.lblDistributionSchemeCode
        Me.txtDistributionSchemeCode.MaximumValue = Nothing
        Me.txtDistributionSchemeCode.MinimumValue = Nothing
        Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
        Me.txtDistributionSchemeCode.OldValue = Nothing
        Me.txtDistributionSchemeCode.ReadOnly = true
        Me.txtDistributionSchemeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDistributionSchemeCode.ValueIsMandatory = true
        '
        'lblDistributionSchemeName
        '
        Me.lblDistributionSchemeName.DisplayOnly = true
        Me.lblDistributionSchemeName.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeName, "lblDistributionSchemeName")
        Me.lblDistributionSchemeName.Name = "lblDistributionSchemeName"
        '
        'txtDistributionSchemeName
        '
        Me.txtDistributionSchemeName.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeName.BegFindValue = Nothing
        Me.txtDistributionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeName.ComputedValue = false
        Me.txtDistributionSchemeName.CustomFormat = Nothing
        Me.txtDistributionSchemeName.DataBoundControl = true
        Me.txtDistributionSchemeName.EditingMode = false
        Me.txtDistributionSchemeName.EndFindValue = Nothing
        Me.txtDistributionSchemeName.FieldDescription = Nothing
        Me.txtDistributionSchemeName.FieldName = Nothing
        Me.txtDistributionSchemeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDistributionSchemeName.FindEnabled = true
        Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeName, true)
        resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
        Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeName.LinkedLabel = Me.lblDistributionSchemeName
        Me.txtDistributionSchemeName.MaximumValue = Nothing
        Me.txtDistributionSchemeName.MinimumValue = Nothing
        Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
        Me.txtDistributionSchemeName.OldValue = Nothing
        Me.txtDistributionSchemeName.ReadOnly = true
        Me.txtDistributionSchemeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDistributionSchemeName.ValueIsMandatory = true
        '
        'lblDistributionSchemeNameAra
        '
        Me.lblDistributionSchemeNameAra.DisplayOnly = true
        Me.lblDistributionSchemeNameAra.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeNameAra, "lblDistributionSchemeNameAra")
        Me.lblDistributionSchemeNameAra.Name = "lblDistributionSchemeNameAra"
        '
        'txtDistributionSchemeNameAra
        '
        Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeNameAra.BegFindValue = Nothing
        Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeNameAra.ComputedValue = false
        Me.txtDistributionSchemeNameAra.CustomFormat = Nothing
        Me.txtDistributionSchemeNameAra.DataBoundControl = true
        Me.txtDistributionSchemeNameAra.EditingMode = true
        Me.txtDistributionSchemeNameAra.EndFindValue = Nothing
        Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
        Me.txtDistributionSchemeNameAra.FieldDescription = Nothing
        Me.txtDistributionSchemeNameAra.FieldName = Nothing
        Me.txtDistributionSchemeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDistributionSchemeNameAra.FindEnabled = true
        Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeNameAra, true)
        resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
        Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeNameAra.LinkedLabel = Me.lblDistributionSchemeNameAra
        Me.txtDistributionSchemeNameAra.MaximumValue = Nothing
        Me.txtDistributionSchemeNameAra.MinimumValue = Nothing
        Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
        Me.txtDistributionSchemeNameAra.OldValue = Nothing
        Me.txtDistributionSchemeNameAra.ReadOnly = true
        Me.txtDistributionSchemeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'lblValidityStartDate
        '
        Me.lblValidityStartDate.DisplayOnly = true
        Me.lblValidityStartDate.EditingMode = false
        resources.ApplyResources(Me.lblValidityStartDate, "lblValidityStartDate")
        Me.lblValidityStartDate.Name = "lblValidityStartDate"
        '
        'dtpValidityStartDate
        '
        Me.dtpValidityStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpValidityStartDate.DefaultValue = Nothing
        Me.dtpValidityStartDate.DisplayOnly = false
        Me.dtpValidityStartDate.DtpDefaultValue = Nothing
        Me.dtpValidityStartDate.EditingMode = false
        Me.dtpValidityStartDate.EditsAllowed = false
        resources.ApplyResources(Me.dtpValidityStartDate, "dtpValidityStartDate")
        Me.dtpValidityStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpValidityStartDate.LinkedLabel = Me.lblValidityStartDate
        Me.dtpValidityStartDate.Name = "dtpValidityStartDate"
        Me.dtpValidityStartDate.ReadOnlyDp = false
        Me.dtpValidityStartDate.SecurityKey = Nothing
        Me.dtpValidityStartDate.ShowLongDate = false
        Me.dtpValidityStartDate.ShowTime = false
        Me.dtpValidityStartDate.TargetCalendar = CType(resources.GetObject("dtpValidityStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpValidityStartDate.Value = Nothing
        Me.dtpValidityStartDate.ValueIsMandatory = false
        Me.dtpValidityStartDate.ValueIsNullable = false
        '
        'lblValidityEndDate
        '
        Me.lblValidityEndDate.DisplayOnly = true
        Me.lblValidityEndDate.EditingMode = false
        resources.ApplyResources(Me.lblValidityEndDate, "lblValidityEndDate")
        Me.lblValidityEndDate.Name = "lblValidityEndDate"
        '
        'dtpValidityEndDate
        '
        Me.dtpValidityEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpValidityEndDate.DefaultValue = Nothing
        Me.dtpValidityEndDate.DisplayOnly = false
        Me.dtpValidityEndDate.DtpDefaultValue = Nothing
        Me.dtpValidityEndDate.EditingMode = false
        Me.dtpValidityEndDate.EditsAllowed = false
        Me.floJournalHeader.SetFlowBreak(Me.dtpValidityEndDate, true)
        resources.ApplyResources(Me.dtpValidityEndDate, "dtpValidityEndDate")
        Me.dtpValidityEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpValidityEndDate.LinkedLabel = Me.lblValidityEndDate
        Me.dtpValidityEndDate.Name = "dtpValidityEndDate"
        Me.dtpValidityEndDate.ReadOnlyDp = false
        Me.dtpValidityEndDate.SecurityKey = Nothing
        Me.dtpValidityEndDate.ShowLongDate = false
        Me.dtpValidityEndDate.ShowTime = false
        Me.dtpValidityEndDate.TargetCalendar = CType(resources.GetObject("dtpValidityEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpValidityEndDate.Value = Nothing
        Me.dtpValidityEndDate.ValueIsMandatory = false
        Me.dtpValidityEndDate.ValueIsNullable = false
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
        Me.txtNotes.ValueIsMandatory = true
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
        '
        'DataGridViewDistributionSchemeItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDistributionSchemeItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDistributionSchemeItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewDistributionSchemeItems.BegFindValue = Nothing
        Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDistributionSchemeItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvRevCostCenterIdNo, Me.dgvRevCostCenterName, Me.Percentage, Me.dgvIdNo, Me.dgvDistributionSchemeIdNo})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewDistributionSchemeItems.DgvFooter = Nothing
        Me.DataGridViewDistributionSchemeItems.DisplayOnly = false
        Me.DataGridViewDistributionSchemeItems.Ea = Nothing
        Me.DataGridViewDistributionSchemeItems.EditingMode = false
        Me.DataGridViewDistributionSchemeItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewDistributionSchemeItems.EndFindValue = Nothing
        Me.DataGridViewDistributionSchemeItems.FieldDescription = Nothing
        Me.DataGridViewDistributionSchemeItems.FieldName = Nothing
        Me.DataGridViewDistributionSchemeItems.FieldsDictionary = Nothing
        Me.DataGridViewDistributionSchemeItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewDistributionSchemeItems.FindEnabled = false
        Me.DataGridViewDistributionSchemeItems.FirstRowDeletionEnabled = true
        Me.DataGridViewDistributionSchemeItems.FirstRowInsertionEnabled = true
        resources.ApplyResources(Me.DataGridViewDistributionSchemeItems, "DataGridViewDistributionSchemeItems")
        Me.DataGridViewDistributionSchemeItems.Name = "DataGridViewDistributionSchemeItems"
        Me.DataGridViewDistributionSchemeItems.ReadOnly = true
        Me.DataGridViewDistributionSchemeItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDistributionSchemeItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewDistributionSchemeItems.SequenceFieldName = "Sequence"
        Me.DataGridViewDistributionSchemeItems.ShowFooter = false
        Me.DataGridViewDistributionSchemeItems.ShowInsertColumnWhenEditing = true
        '
        'txtTotalPercentage
        '
        Me.txtTotalPercentage.BackColor = System.Drawing.Color.White
        Me.txtTotalPercentage.BegFindValue = Nothing
        Me.txtTotalPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPercentage.ComputedValue = true
        Me.txtTotalPercentage.CustomFormat = Nothing
        Me.txtTotalPercentage.DataBoundControl = true
        Me.txtTotalPercentage.DisplayOnly = true
        Me.txtTotalPercentage.EditingMode = true
        Me.txtTotalPercentage.EndFindValue = Nothing
        Me.txtTotalPercentage.FieldDescription = Nothing
        Me.txtTotalPercentage.FieldName = Nothing
        Me.txtTotalPercentage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalPercentage.FindEnabled = false
        resources.ApplyResources(Me.txtTotalPercentage, "txtTotalPercentage")
        Me.txtTotalPercentage.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPercentage.LinkedLabel = Nothing
        Me.txtTotalPercentage.MaximumValue = Nothing
        Me.txtTotalPercentage.MinimumValue = Nothing
        Me.txtTotalPercentage.Name = "txtTotalPercentage"
        Me.txtTotalPercentage.OldValue = Nothing
        Me.txtTotalPercentage.ReadOnly = true
        Me.txtTotalPercentage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalPercentage.TabStop = false
        Me.txtTotalPercentage.ValueIsMandatory = true
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FillWeight = 1!
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRevCostCenterIdNo.EditingMode = false
        Me.dgvRevCostCenterIdNo.FillWeight = 1!
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvRevCostCenterName
        '
        Me.dgvRevCostCenterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRevCostCenterName.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterName.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRevCostCenterName.EditingMode = false
        resources.ApplyResources(Me.dgvRevCostCenterName, "dgvRevCostCenterName")
        Me.dgvRevCostCenterName.Name = "dgvRevCostCenterName"
        Me.dgvRevCostCenterName.ReadOnly = true
        Me.dgvRevCostCenterName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Percentage
        '
        Me.Percentage.DataPropertyName = "Percentage"
        Me.Percentage.FillWeight = 1!
        resources.ApplyResources(Me.Percentage, "Percentage")
        Me.Percentage.Name = "Percentage"
        Me.Percentage.ReadOnly = true
        '
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FillWeight = 10!
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvDistributionSchemeIdNo
        '
        Me.dgvDistributionSchemeIdNo.BegFindValue = Nothing
        Me.dgvDistributionSchemeIdNo.DataPropertyName = "DistributionSchemeIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvDistributionSchemeIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDistributionSchemeIdNo.EditingMode = false
        Me.dgvDistributionSchemeIdNo.EndFindValue = Nothing
        Me.dgvDistributionSchemeIdNo.FieldDescription = Nothing
        Me.dgvDistributionSchemeIdNo.FieldName = Nothing
        Me.dgvDistributionSchemeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDistributionSchemeIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvDistributionSchemeIdNo, "dgvDistributionSchemeIdNo")
        Me.dgvDistributionSchemeIdNo.Name = "dgvDistributionSchemeIdNo"
        Me.dgvDistributionSchemeIdNo.ReadOnly = true
        Me.dgvDistributionSchemeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDistributionSchemeIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'DistributionSchemeEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floJournalHeader)
        Me.Controls.Add(Me.DataGridViewDistributionSchemeItems)
        Me.Controls.Add(Me.txtTotalPercentage)
        Me.Controls.Add(Me.lblAmount)
        Me.Name = "DistributionSchemeEntry"
        Me.Controls.SetChildIndex(Me.lblAmount, 0)
        Me.Controls.SetChildIndex(Me.txtTotalPercentage, 0)
        Me.Controls.SetChildIndex(Me.DataGridViewDistributionSchemeItems, 0)
        Me.Controls.SetChildIndex(Me.floJournalHeader, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floJournalHeader.ResumeLayout(false)
        Me.floJournalHeader.PerformLayout
        CType(Me.DataGridViewDistributionSchemeItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDistributionSchemeItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floJournalHeader As CFlowLayout
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtDistributionSchemeCode As CTextBox
        Friend WithEvents lblDistributionSchemeCode As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents DataGridViewDistributionSchemeItems As CDataGridView
        Friend WithEvents txtTotalPercentage As CTextBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsDistributionSchemeItems As Windows.Forms.BindingSource
        Friend WithEvents lblDistributionSchemeName As CLabel
        Friend WithEvents txtDistributionSchemeName As CTextBox
        Friend WithEvents lblDistributionSchemeNameAra As CLabel
        Friend WithEvents txtDistributionSchemeNameAra As CTextBoxArabic
        Friend WithEvents lblValidityStartDate As CLabel
        Friend WithEvents dtpValidityStartDate As CCustomDateTimePicker
        Friend WithEvents lblValidityEndDate As CLabel
        Friend WithEvents dtpValidityEndDate As CCustomDateTimePicker
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvRevCostCenterName As CaDgvComboBoxColumn
        Friend WithEvents Percentage As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents dgvDistributionSchemeIdNo As CDgvTextColumn
    End Class
End NameSpace