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
        Me.dtpValidityStartDate = New CCustomDateTimePicker()
        Me.lblValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityEndDate = New CCustomDateTimePicker()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDistributionSchemeItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvDistributionSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnComboBox()
        Me.dgvRevCostCenterName = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnComboBox()
        Me.Percentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.FindEnabled = True
            Me.floJournalHeader.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblDistributionSchemeCode
            '
            Me.lblDistributionSchemeCode.DisplayOnly = True
            Me.lblDistributionSchemeCode.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeCode, "lblDistributionSchemeCode")
            Me.lblDistributionSchemeCode.Name = "lblDistributionSchemeCode"
            '
            'txtDistributionSchemeCode
            '
            Me.txtDistributionSchemeCode.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeCode.ComputedValue = False
            Me.txtDistributionSchemeCode.CustomFormat = Nothing
            Me.txtDistributionSchemeCode.DataBoundControl = True
            Me.txtDistributionSchemeCode.EditingMode = False
            Me.txtDistributionSchemeCode.FindEnabled = True
            Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeCode, True)
            resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
            Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeCode.LinkedLabel = Me.lblDistributionSchemeCode
            Me.txtDistributionSchemeCode.MaximumValue = Nothing
            Me.txtDistributionSchemeCode.MinimumValue = Nothing
            Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
            Me.txtDistributionSchemeCode.OldValue = Nothing
            Me.txtDistributionSchemeCode.ReadOnly = True
            Me.txtDistributionSchemeCode.ValueIsMandatory = True
            '
            'lblDistributionSchemeName
            '
            Me.lblDistributionSchemeName.DisplayOnly = True
            Me.lblDistributionSchemeName.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeName, "lblDistributionSchemeName")
            Me.lblDistributionSchemeName.Name = "lblDistributionSchemeName"
            '
            'txtDistributionSchemeName
            '
            Me.txtDistributionSchemeName.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeName.ComputedValue = False
            Me.txtDistributionSchemeName.CustomFormat = Nothing
            Me.txtDistributionSchemeName.DataBoundControl = True
            Me.txtDistributionSchemeName.EditingMode = False
            Me.txtDistributionSchemeName.FindEnabled = True
            Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeName, True)
            resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
            Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeName.LinkedLabel = Me.lblDistributionSchemeName
            Me.txtDistributionSchemeName.MaximumValue = Nothing
            Me.txtDistributionSchemeName.MinimumValue = Nothing
            Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
            Me.txtDistributionSchemeName.OldValue = Nothing
            Me.txtDistributionSchemeName.ReadOnly = True
            Me.txtDistributionSchemeName.ValueIsMandatory = True
            '
            'lblDistributionSchemeNameAra
            '
            Me.lblDistributionSchemeNameAra.DisplayOnly = True
            Me.lblDistributionSchemeNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeNameAra, "lblDistributionSchemeNameAra")
            Me.lblDistributionSchemeNameAra.Name = "lblDistributionSchemeNameAra"
            '
            'txtDistributionSchemeNameAra
            '
            Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeNameAra.ComputedValue = False
            Me.txtDistributionSchemeNameAra.CustomFormat = Nothing
            Me.txtDistributionSchemeNameAra.DataBoundControl = True
            Me.txtDistributionSchemeNameAra.EditingMode = True
            Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
            Me.txtDistributionSchemeNameAra.FindEnabled = True
            Me.floJournalHeader.SetFlowBreak(Me.txtDistributionSchemeNameAra, True)
            resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
            Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeNameAra.LinkedLabel = Me.lblDistributionSchemeNameAra
            Me.txtDistributionSchemeNameAra.MaximumValue = Nothing
            Me.txtDistributionSchemeNameAra.MinimumValue = Nothing
            Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
            Me.txtDistributionSchemeNameAra.OldValue = Nothing
            Me.txtDistributionSchemeNameAra.ReadOnly = True
            '
            'lblValidityStartDate
            '
            Me.lblValidityStartDate.DisplayOnly = True
            Me.lblValidityStartDate.EditingMode = False
            resources.ApplyResources(Me.lblValidityStartDate, "lblValidityStartDate")
            Me.lblValidityStartDate.Name = "lblValidityStartDate"
            '
            'dtpValidityStartDate
            '
            Me.dtpValidityStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpValidityStartDate.DefaultValue = Nothing
            Me.dtpValidityStartDate.DisplayOnly = False
            Me.dtpValidityStartDate.DtpDefaultValue = Nothing
            Me.dtpValidityStartDate.EditingMode = False
            Me.dtpValidityStartDate.EditsAllowed = False
            resources.ApplyResources(Me.dtpValidityStartDate, "dtpValidityStartDate")
            Me.dtpValidityStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpValidityStartDate.LinkedLabel = Me.lblValidityStartDate
            Me.dtpValidityStartDate.Name = "dtpValidityStartDate"
            Me.dtpValidityStartDate.ReadOnlyDp = False
            Me.dtpValidityStartDate.SecurityKey = Nothing
            Me.dtpValidityStartDate.ShowLongDate = False
            Me.dtpValidityStartDate.ShowTime = False
            Me.dtpValidityStartDate.TargetCalendar = CType(resources.GetObject("dtpValidityStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpValidityStartDate.Value = Nothing
            Me.dtpValidityStartDate.ValueIsMandatory = False
            Me.dtpValidityStartDate.ValueIsNullable = False
            '
            'lblValidityEndDate
            '
            Me.lblValidityEndDate.DisplayOnly = True
            Me.lblValidityEndDate.EditingMode = False
            resources.ApplyResources(Me.lblValidityEndDate, "lblValidityEndDate")
            Me.lblValidityEndDate.Name = "lblValidityEndDate"
            '
            'dtpValidityEndDate
            '
            Me.dtpValidityEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpValidityEndDate.DefaultValue = Nothing
            Me.dtpValidityEndDate.DisplayOnly = False
            Me.dtpValidityEndDate.DtpDefaultValue = Nothing
            Me.dtpValidityEndDate.EditingMode = False
            Me.dtpValidityEndDate.EditsAllowed = False
            Me.floJournalHeader.SetFlowBreak(Me.dtpValidityEndDate, True)
            resources.ApplyResources(Me.dtpValidityEndDate, "dtpValidityEndDate")
            Me.dtpValidityEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpValidityEndDate.LinkedLabel = Me.lblValidityEndDate
            Me.dtpValidityEndDate.Name = "dtpValidityEndDate"
            Me.dtpValidityEndDate.ReadOnlyDp = False
            Me.dtpValidityEndDate.SecurityKey = Nothing
            Me.dtpValidityEndDate.ShowLongDate = False
            Me.dtpValidityEndDate.ShowTime = False
            Me.dtpValidityEndDate.TargetCalendar = CType(resources.GetObject("dtpValidityEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpValidityEndDate.Value = Nothing
            Me.dtpValidityEndDate.ValueIsMandatory = False
            Me.dtpValidityEndDate.ValueIsNullable = False
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            resources.ApplyResources(Me.lblAmount, "lblAmount")
            Me.lblAmount.Name = "lblAmount"
            '
            'DataGridViewDistributionSchemeItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDistributionSchemeItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDistributionSchemeItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDistributionSchemeItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvDistributionSchemeIdNo, Me.dgvSequence, Me.dgvRevCostCenterIdNo, Me.dgvRevCostCenterName, Me.Percentage})
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewDistributionSchemeItems.DgvFooter = Nothing
            Me.DataGridViewDistributionSchemeItems.DisplayOnly = False
            Me.DataGridViewDistributionSchemeItems.Ea = Nothing
            Me.DataGridViewDistributionSchemeItems.EditingMode = False
            Me.DataGridViewDistributionSchemeItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDistributionSchemeItems.FieldsDictionary = Nothing
            Me.DataGridViewDistributionSchemeItems.FirstRowDeletionEnabled = True
            Me.DataGridViewDistributionSchemeItems.FirstRowInsertionEnabled = True
            resources.ApplyResources(Me.DataGridViewDistributionSchemeItems, "DataGridViewDistributionSchemeItems")
            Me.DataGridViewDistributionSchemeItems.Name = "DataGridViewDistributionSchemeItems"
            Me.DataGridViewDistributionSchemeItems.ReadOnly = True
            Me.DataGridViewDistributionSchemeItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewDistributionSchemeItems.SequenceFieldName = "Sequence"
            Me.DataGridViewDistributionSchemeItems.ShowFooter = False
            Me.DataGridViewDistributionSchemeItems.ShowInsertColumnWhenEditing = True
            '
            'dgvIdNo
            '
            Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDistributionSchemeIdNo
            '
            Me.dgvDistributionSchemeIdNo.DataPropertyName = "DistributionSchemeIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvDistributionSchemeIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDistributionSchemeIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvDistributionSchemeIdNo, "dgvDistributionSchemeIdNo")
            Me.dgvDistributionSchemeIdNo.Name = "dgvDistributionSchemeIdNo"
            Me.dgvDistributionSchemeIdNo.ReadOnly = True
            Me.dgvDistributionSchemeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvRevCostCenterIdNo.EditingMode = False
            Me.dgvRevCostCenterIdNo.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvRevCostCenterName
            '
            Me.dgvRevCostCenterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvRevCostCenterName.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterName.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvRevCostCenterName.EditingMode = False
            Me.dgvRevCostCenterName.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvRevCostCenterName, "dgvRevCostCenterName")
            Me.dgvRevCostCenterName.Name = "dgvRevCostCenterName"
            Me.dgvRevCostCenterName.ReadOnly = True
            Me.dgvRevCostCenterName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'Percentage
            '
            Me.Percentage.DataPropertyName = "Percentage"
            Me.Percentage.FillWeight = 1.0!
            resources.ApplyResources(Me.Percentage, "Percentage")
            Me.Percentage.Name = "Percentage"
            Me.Percentage.ReadOnly = True
            '
            'txtTotalPercentage
            '
            Me.txtTotalPercentage.BackColor = System.Drawing.Color.White
            Me.txtTotalPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalPercentage.ComputedValue = True
            Me.txtTotalPercentage.CustomFormat = Nothing
            Me.txtTotalPercentage.DataBoundControl = True
            Me.txtTotalPercentage.DisplayOnly = True
            Me.txtTotalPercentage.EditingMode = True
            Me.txtTotalPercentage.FindEnabled = False
            resources.ApplyResources(Me.txtTotalPercentage, "txtTotalPercentage")
            Me.txtTotalPercentage.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPercentage.LinkedLabel = Nothing
        Me.txtTotalPercentage.MaximumValue = Nothing
        Me.txtTotalPercentage.MinimumValue = Nothing
        Me.txtTotalPercentage.Name = "txtTotalPercentage"
        Me.txtTotalPercentage.OldValue = Nothing
        Me.txtTotalPercentage.ReadOnly = true
        Me.txtTotalPercentage.TabStop = false
        Me.txtTotalPercentage.ValueIsMandatory = true
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
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents dgvDistributionSchemeIdNo As CdgvColumnText
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvRevCostCenterIdNo As CdgvColumnComboBox
        Friend WithEvents dgvRevCostCenterName As CdgvColumnComboBox
        Friend WithEvents Percentage As Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace