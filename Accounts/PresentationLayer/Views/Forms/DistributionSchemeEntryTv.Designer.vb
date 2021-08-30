Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DistributionSchemeEntryTv
        Inherits CFormEntryTvNew

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DistributionSchemeEntryTv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDistributionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDistributionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDistributionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDistributionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDistributionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDistributionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblValidityStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDistributionSchemeItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtTotalPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvPercentage = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDistributionSchemeIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevCostCenterNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        CType(Me.DataGridViewDistributionSchemeItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDistributionSchemeItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
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
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeCode, true)
        resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
        Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeCode.LinkedLabel = Nothing
        Me.txtDistributionSchemeCode.MaximumValue = Nothing
        Me.txtDistributionSchemeCode.MinimumValue = Nothing
        Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
        Me.txtDistributionSchemeCode.OldValue = Nothing
        Me.txtDistributionSchemeCode.ReadOnly = true
        Me.txtDistributionSchemeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDistributionSchemeCode.ValueIsMandatory = true
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
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeName, true)
        resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
        Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeName.LinkedLabel = Nothing
        Me.txtDistributionSchemeName.MaximumValue = Nothing
        Me.txtDistributionSchemeName.MinimumValue = Nothing
        Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
        Me.txtDistributionSchemeName.OldValue = Nothing
        Me.txtDistributionSchemeName.ReadOnly = true
        Me.txtDistributionSchemeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDistributionSchemeName.ValueIsMandatory = true
        '
        'txtDistributionSchemeNameAra
        '
        Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeNameAra.BegFindValue = Nothing
        Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeNameAra.ComputedValue = false
        Me.txtDistributionSchemeNameAra.CustomFormat = Nothing
        Me.txtDistributionSchemeNameAra.DataBoundControl = true
        Me.txtDistributionSchemeNameAra.EditingMode = false
        Me.txtDistributionSchemeNameAra.EndFindValue = Nothing
        Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
        Me.txtDistributionSchemeNameAra.FieldDescription = Nothing
        Me.txtDistributionSchemeNameAra.FieldName = Nothing
        Me.txtDistributionSchemeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDistributionSchemeNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeNameAra, true)
        resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
        Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeNameAra.LinkedLabel = Nothing
        Me.txtDistributionSchemeNameAra.MaximumValue = Nothing
        Me.txtDistributionSchemeNameAra.MinimumValue = Nothing
        Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
        Me.txtDistributionSchemeNameAra.OldValue = Nothing
        Me.txtDistributionSchemeNameAra.ReadOnly = true
        Me.txtDistributionSchemeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblDistributionSchemeCode)
        Me.floDataDisplay.Controls.Add(Me.txtDistributionSchemeCode)
        Me.floDataDisplay.Controls.Add(Me.lblDistributionSchemeName)
        Me.floDataDisplay.Controls.Add(Me.txtDistributionSchemeName)
        Me.floDataDisplay.Controls.Add(Me.lblDistributionSchemeNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtDistributionSchemeNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblValidityStartDate)
        Me.floDataDisplay.Controls.Add(Me.dtpValidityStartDate)
        Me.floDataDisplay.Controls.Add(Me.lblValidityEndDate)
        Me.floDataDisplay.Controls.Add(Me.dtpValidityEndDate)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblDistributionSchemeCode
        '
        Me.lblDistributionSchemeCode.DisplayOnly = true
        Me.lblDistributionSchemeCode.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeCode, "lblDistributionSchemeCode")
        Me.lblDistributionSchemeCode.Name = "lblDistributionSchemeCode"
        '
        'lblDistributionSchemeName
        '
        Me.lblDistributionSchemeName.DisplayOnly = true
        Me.lblDistributionSchemeName.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeName, "lblDistributionSchemeName")
        Me.lblDistributionSchemeName.Name = "lblDistributionSchemeName"
        '
        'lblDistributionSchemeNameAra
        '
        Me.lblDistributionSchemeNameAra.DisplayOnly = true
        Me.lblDistributionSchemeNameAra.EditingMode = false
        resources.ApplyResources(Me.lblDistributionSchemeNameAra, "lblDistributionSchemeNameAra")
        Me.lblDistributionSchemeNameAra.Name = "lblDistributionSchemeNameAra"
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
        Me.dtpValidityStartDate.LinkedLabel = Me.lblValidityEndDate
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
        resources.ApplyResources(Me.dtpValidityEndDate, "dtpValidityEndDate")
        Me.dtpValidityEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpValidityEndDate.LinkedLabel = Me.lblValidityStartDate
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
        Me.floDataDisplay.SetFlowBreak(Me.lblNotes, true)
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'DataGridViewDistributionSchemeItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDistributionSchemeItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDistributionSchemeItems.AutoGenerateColumns = false
        Me.DataGridViewDistributionSchemeItems.BegFindValue = Nothing
        Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDistributionSchemeItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvRevCostCenterIdNo, Me.dgvPercentage, Me.IdNoDataGridViewTextBoxColumn, Me.dgvDistributionSchemeIdNo, Me.RevCostCenterNameDataGridViewTextBoxColumn})
        Me.DataGridViewDistributionSchemeItems.DataSource = Me.bsDistributionSchemeItems
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle3
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
        'bsDistributionSchemeItems
        '
        Me.bsDistributionSchemeItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DistributionSchemeItemModel)
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
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
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
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvPercentage
        '
        Me.dgvPercentage.DataPropertyName = "Percentage"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvPercentage.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPercentage.EditingMode = false
        resources.ApplyResources(Me.dgvPercentage, "dgvPercentage")
        Me.dgvPercentage.Name = "dgvPercentage"
        Me.dgvPercentage.ReadOnly = true
        Me.dgvPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'dgvDistributionSchemeIdNo
        '
        Me.dgvDistributionSchemeIdNo.DataPropertyName = "DistributionSchemeIdNo"
        resources.ApplyResources(Me.dgvDistributionSchemeIdNo, "dgvDistributionSchemeIdNo")
        Me.dgvDistributionSchemeIdNo.Name = "dgvDistributionSchemeIdNo"
        Me.dgvDistributionSchemeIdNo.ReadOnly = true
        '
        'RevCostCenterNameDataGridViewTextBoxColumn
        '
        Me.RevCostCenterNameDataGridViewTextBoxColumn.DataPropertyName = "RevCostCenterName"
        resources.ApplyResources(Me.RevCostCenterNameDataGridViewTextBoxColumn, "RevCostCenterNameDataGridViewTextBoxColumn")
        Me.RevCostCenterNameDataGridViewTextBoxColumn.Name = "RevCostCenterNameDataGridViewTextBoxColumn"
        Me.RevCostCenterNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'DistributionSchemeEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtTotalPercentage)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.DataGridViewDistributionSchemeItems)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "DistributionSchemeEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.DataGridViewDistributionSchemeItems, 0)
        Me.Controls.SetChildIndex(Me.lblAmount, 0)
        Me.Controls.SetChildIndex(Me.txtTotalPercentage, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        CType(Me.DataGridViewDistributionSchemeItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDistributionSchemeItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtDistributionSchemeCode As CTextBox
        Friend WithEvents txtDistributionSchemeName As CTextBox
        Friend WithEvents txtDistributionSchemeNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblDistributionSchemeCode As CLabel
        Friend WithEvents lblDistributionSchemeName As CLabel
        Friend WithEvents lblDistributionSchemeNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblValidityStartDate As CLabel
        Friend WithEvents dtpValidityStartDate As CCustomDateTimePicker
        Friend WithEvents lblValidityEndDate As CLabel
        Friend WithEvents dtpValidityEndDate As CCustomDateTimePicker
        Friend WithEvents DataGridViewDistributionSchemeItems As CDataGridView
        Friend WithEvents txtTotalPercentage As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents bsDistributionSchemeItems As Windows.Forms.BindingSource
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvPercentage As CdgvDecimalColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvDistributionSchemeIdNo As DataGridViewTextBoxColumn
        Friend WithEvents RevCostCenterNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End NameSpace