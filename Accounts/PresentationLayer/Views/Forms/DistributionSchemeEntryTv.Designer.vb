Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DistributionSchemeEntryTv
        Inherits CFormEntryTv

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dtpValidityStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblValidityEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpValidityEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDistributionSchemeItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvDistributionSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvCaComboboxColumn()
        Me.dgvPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
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
            'txtDistributionSchemeCode
            '
            Me.txtDistributionSchemeCode.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeCode.ComputedValue = False
            Me.txtDistributionSchemeCode.CustomFormat = Nothing
            Me.txtDistributionSchemeCode.DataBoundControl = True
            Me.txtDistributionSchemeCode.EditingMode = False
            Me.txtDistributionSchemeCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeCode, True)
            resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
            Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeCode.LinkedLabel = Nothing
            Me.txtDistributionSchemeCode.MaximumValue = Nothing
            Me.txtDistributionSchemeCode.MinimumValue = Nothing
            Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
            Me.txtDistributionSchemeCode.OldValue = Nothing
            Me.txtDistributionSchemeCode.ReadOnly = True
            Me.txtDistributionSchemeCode.ValueIsMandatory = True
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
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeName, True)
            resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
            Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeName.LinkedLabel = Nothing
            Me.txtDistributionSchemeName.MaximumValue = Nothing
            Me.txtDistributionSchemeName.MinimumValue = Nothing
            Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
            Me.txtDistributionSchemeName.OldValue = Nothing
            Me.txtDistributionSchemeName.ReadOnly = True
            Me.txtDistributionSchemeName.ValueIsMandatory = True
            '
            'txtDistributionSchemeNameAra
            '
            Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeNameAra.ComputedValue = False
            Me.txtDistributionSchemeNameAra.CustomFormat = Nothing
            Me.txtDistributionSchemeNameAra.DataBoundControl = True
            Me.txtDistributionSchemeNameAra.EditingMode = False
            Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
            Me.txtDistributionSchemeNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeNameAra, True)
            resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
            Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeNameAra.LinkedLabel = Nothing
            Me.txtDistributionSchemeNameAra.MaximumValue = Nothing
            Me.txtDistributionSchemeNameAra.MinimumValue = Nothing
            Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
            Me.txtDistributionSchemeNameAra.OldValue = Nothing
            Me.txtDistributionSchemeNameAra.ReadOnly = True
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
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblDistributionSchemeCode
            '
            Me.lblDistributionSchemeCode.DisplayOnly = True
            Me.lblDistributionSchemeCode.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeCode, "lblDistributionSchemeCode")
            Me.lblDistributionSchemeCode.Name = "lblDistributionSchemeCode"
            '
            'lblDistributionSchemeName
            '
            Me.lblDistributionSchemeName.DisplayOnly = True
            Me.lblDistributionSchemeName.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeName, "lblDistributionSchemeName")
            Me.lblDistributionSchemeName.Name = "lblDistributionSchemeName"
            '
            'lblDistributionSchemeNameAra
            '
            Me.lblDistributionSchemeNameAra.DisplayOnly = True
            Me.lblDistributionSchemeNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDistributionSchemeNameAra, "lblDistributionSchemeNameAra")
            Me.lblDistributionSchemeNameAra.Name = "lblDistributionSchemeNameAra"
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
            Me.dtpValidityStartDate.LinkedLabel = Me.lblValidityEndDate
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
            resources.ApplyResources(Me.dtpValidityEndDate, "dtpValidityEndDate")
            Me.dtpValidityEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpValidityEndDate.LinkedLabel = Me.lblValidityStartDate
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
            Me.floDataDisplay.SetFlowBreak(Me.lblNotes, True)
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'DataGridViewDistributionSchemeItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDistributionSchemeItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDistributionSchemeItems.AutoGenerateColumns = False
            Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDistributionSchemeItems.DataSource = Me.bsDistributionSchemeItems
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle2
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
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDistributionSchemeIdNo
            '
            Me.dgvDistributionSchemeIdNo.DataPropertyName = "DistributionSchemeIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvDistributionSchemeIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvDistributionSchemeIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvDistributionSchemeIdNo, "dgvDistributionSchemeIdNo")
            Me.dgvDistributionSchemeIdNo.Name = "dgvDistributionSchemeIdNo"
            Me.dgvDistributionSchemeIdNo.ReadOnly = True
            Me.dgvDistributionSchemeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvSequence
            '
            Me.dgvSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPercentage
            '
            Me.dgvPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvPercentage.DataPropertyName = "Percentage"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.Format = "N2"
            DataGridViewCellStyle7.NullValue = Nothing
            Me.dgvPercentage.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvPercentage.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvPercentage, "dgvPercentage")
            Me.dgvPercentage.Name = "dgvPercentage"
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
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
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
        Friend WithEvents dtpValidityStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblValidityEndDate As CLabel
        Friend WithEvents dtpValidityEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents DataGridViewDistributionSchemeItems As CDataGridView
        Friend WithEvents txtTotalPercentage As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents bsDistributionSchemeItems As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents dgvDistributionSchemeIdNo As CdgvColumnText
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvRevCostCenterIdNo As cDgvCaComboboxColumn
        Friend WithEvents dgvPercentage As Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace