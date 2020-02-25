Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.BaseFormsLibrary

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DistributionSchemeEntryTv
        Inherits BfTvEntry

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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDistributionSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvCaComboboxColumn()
            Me.dgvPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtTotalPercentage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            CType(Me.DataGridViewDistributionSchemeItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDistributionSchemeItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            '
            'TxtIDNo
            '
            Me.TxtIDNo.AcceptsReturn = false
            Me.TxtIDNo.AcceptsTab = false
            Me.TxtIDNo.BackColor = System.Drawing.Color.White
            Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIDNo.ComputedValue = False
            Me.TxtIDNo.DataBoundControl = True
            Me.TxtIDNo.DisplayOnly = True
            Me.TxtIDNo.EditingMode = True
            resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
            Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, True)
            Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIDNo.LinkedLabel = Nothing
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.TabStop = False
            '
            'txtDistributionSchemeCode
            '
            Me.txtDistributionSchemeCode.AcceptsReturn = false
            Me.txtDistributionSchemeCode.AcceptsTab = false
            Me.txtDistributionSchemeCode.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeCode.ComputedValue = False
            Me.txtDistributionSchemeCode.DataBoundControl = True
            Me.txtDistributionSchemeCode.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeCode, True)
            resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
            Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeCode.LinkedLabel = Nothing
            Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
            Me.txtDistributionSchemeCode.ValueIsMandatory = True
            '
            'txtDistributionSchemeName
            '
            Me.txtDistributionSchemeName.AcceptsReturn = false
            Me.txtDistributionSchemeName.AcceptsTab = false
            Me.txtDistributionSchemeName.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeName.ComputedValue = False
            Me.txtDistributionSchemeName.DataBoundControl = True
            Me.txtDistributionSchemeName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeName, True)
            resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
            Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeName.LinkedLabel = Nothing
            Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
            Me.txtDistributionSchemeName.ValueIsMandatory = True
            '
            'txtDistributionSchemeNameAra
            '
            Me.txtDistributionSchemeNameAra.AcceptsReturn = false
            Me.txtDistributionSchemeNameAra.AcceptsTab = false
            Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
            Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistributionSchemeNameAra.ComputedValue = False
            Me.txtDistributionSchemeNameAra.DataBoundControl = True
            Me.txtDistributionSchemeNameAra.EditingMode = False
            Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
            Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeNameAra, True)
            resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
            Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDistributionSchemeNameAra.LinkedLabel = Nothing
            Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
            '
            'txtNotes
            '
            Me.txtNotes.AcceptsReturn = false
            Me.txtNotes.AcceptsTab = false
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
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
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblDistributionSchemeCode
            '
            resources.ApplyResources(Me.lblDistributionSchemeCode, "lblDistributionSchemeCode")
            Me.lblDistributionSchemeCode.Name = "lblDistributionSchemeCode"
            '
            'lblDistributionSchemeName
            '
            resources.ApplyResources(Me.lblDistributionSchemeName, "lblDistributionSchemeName")
            Me.lblDistributionSchemeName.Name = "lblDistributionSchemeName"
            '
            'lblDistributionSchemeNameAra
            '
            resources.ApplyResources(Me.lblDistributionSchemeNameAra, "lblDistributionSchemeNameAra")
            Me.lblDistributionSchemeNameAra.Name = "lblDistributionSchemeNameAra"
            '
            'lblValidityStartDate
            '
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
            Me.floDataDisplay.SetFlowBreak(Me.lblNotes, True)
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'DataGridViewDistributionSchemeItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDistributionSchemeItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDistributionSchemeItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvDistributionSchemeIdNo, Me.dgvSequence, Me.dgvProfitCenterIdNo, Me.dgvPercentage})
            Me.DataGridViewDistributionSchemeItems.DataInGridChanged = False
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.0!)
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewDistributionSchemeItems.DisplayOnly = False
            Me.DataGridViewDistributionSchemeItems.EditingMode = False
            Me.DataGridViewDistributionSchemeItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            resources.ApplyResources(Me.DataGridViewDistributionSchemeItems, "DataGridViewDistributionSchemeItems")
            Me.DataGridViewDistributionSchemeItems.Name = "DataGridViewDistributionSchemeItems"
            Me.DataGridViewDistributionSchemeItems.StartTrackingChanges = False
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
            Me.dgvDistributionSchemeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvSequence
            '
            Me.dgvSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvProfitCenterIdNo
            '
            Me.dgvProfitCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvProfitCenterIdNo.DataPropertyName = "ProfitCenterIdNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvProfitCenterIdNo.DefaultCellStyle = DataGridViewCellStyle5
            resources.ApplyResources(Me.dgvProfitCenterIdNo, "dgvProfitCenterIdNo")
            Me.dgvProfitCenterIdNo.Name = "dgvProfitCenterIdNo"
            Me.dgvProfitCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPercentage
            '
            Me.dgvPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvPercentage.DataPropertyName = "Percentage"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.Format = "N2"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.dgvPercentage.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvPercentage.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvPercentage, "dgvPercentage")
            Me.dgvPercentage.Name = "dgvPercentage"
            '
            'txtTotalPercentage
            '
            Me.txtTotalPercentage.AcceptsReturn = false
            Me.txtTotalPercentage.AcceptsTab = false
            Me.txtTotalPercentage.BackColor = System.Drawing.Color.White
            Me.txtTotalPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalPercentage.ComputedValue = True
            Me.txtTotalPercentage.DataBoundControl = True
            Me.txtTotalPercentage.DisplayOnly = True
            Me.txtTotalPercentage.EditingMode = True
            resources.ApplyResources(Me.txtTotalPercentage, "txtTotalPercentage")
            Me.txtTotalPercentage.ForeColor = System.Drawing.Color.Black
            Me.txtTotalPercentage.LinkedLabel = Nothing
            Me.txtTotalPercentage.Name = "txtTotalPercentage"
            Me.txtTotalPercentage.ReadOnly = True
            Me.txtTotalPercentage.TabStop = False
            Me.txtTotalPercentage.ValueIsMandatory = True
            '
            'lblAmount
            '
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
        Friend WithEvents TxtIDNo As CTextBox
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
        Friend WithEvents dgvProfitCenterIdNo As cDgvCaComboboxColumn
        Friend WithEvents dgvPercentage As Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace