Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
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
        Me.bsDistributionSchemeItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvDistributionSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvCaComboboxColumn()
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
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.TabStop = false
        '
        'txtDistributionSchemeCode
        '
        Me.txtDistributionSchemeCode.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeCode.ComputedValue = false
        Me.txtDistributionSchemeCode.CustomFormat = Nothing
        Me.txtDistributionSchemeCode.DataBoundControl = true
        Me.txtDistributionSchemeCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeCode, true)
        resources.ApplyResources(Me.txtDistributionSchemeCode, "txtDistributionSchemeCode")
        Me.txtDistributionSchemeCode.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeCode.LinkedLabel = Nothing
        Me.txtDistributionSchemeCode.Name = "txtDistributionSchemeCode"
        Me.txtDistributionSchemeCode.OldValue = Nothing
        Me.txtDistributionSchemeCode.ValueIsMandatory = true
        '
        'txtDistributionSchemeName
        '
        Me.txtDistributionSchemeName.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeName.ComputedValue = false
        Me.txtDistributionSchemeName.CustomFormat = Nothing
        Me.txtDistributionSchemeName.DataBoundControl = true
        Me.txtDistributionSchemeName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeName, true)
        resources.ApplyResources(Me.txtDistributionSchemeName, "txtDistributionSchemeName")
        Me.txtDistributionSchemeName.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeName.LinkedLabel = Nothing
        Me.txtDistributionSchemeName.Name = "txtDistributionSchemeName"
        Me.txtDistributionSchemeName.OldValue = Nothing
        Me.txtDistributionSchemeName.ValueIsMandatory = true
        '
        'txtDistributionSchemeNameAra
        '
        Me.txtDistributionSchemeNameAra.BackColor = System.Drawing.Color.White
        Me.txtDistributionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistributionSchemeNameAra.ComputedValue = false
        Me.txtDistributionSchemeNameAra.CustomFormat = Nothing
        Me.txtDistributionSchemeNameAra.DataBoundControl = true
        Me.txtDistributionSchemeNameAra.EditingMode = false
        Me.txtDistributionSchemeNameAra.EnglishControl = Me.txtDistributionSchemeName
        Me.floDataDisplay.SetFlowBreak(Me.txtDistributionSchemeNameAra, true)
        resources.ApplyResources(Me.txtDistributionSchemeNameAra, "txtDistributionSchemeNameAra")
        Me.txtDistributionSchemeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDistributionSchemeNameAra.LinkedLabel = Nothing
        Me.txtDistributionSchemeNameAra.Name = "txtDistributionSchemeNameAra"
        Me.txtDistributionSchemeNameAra.OldValue = Nothing
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
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
        Me.DataGridViewDistributionSchemeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDistributionSchemeItems.DataInGridChanged = false
        Me.DataGridViewDistributionSchemeItems.DataSource = Me.bsDistributionSchemeItems
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDistributionSchemeItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDistributionSchemeItems.DisplayOnly = false
        Me.DataGridViewDistributionSchemeItems.EditingMode = false
        Me.DataGridViewDistributionSchemeItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        resources.ApplyResources(Me.DataGridViewDistributionSchemeItems, "DataGridViewDistributionSchemeItems")
        Me.DataGridViewDistributionSchemeItems.Name = "DataGridViewDistributionSchemeItems"
        Me.DataGridViewDistributionSchemeItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewDistributionSchemeItems.StartTrackingChanges = false
        '
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvDistributionSchemeIdNo
        '
        Me.dgvDistributionSchemeIdNo.DataPropertyName = "DistributionSchemeIdNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvDistributionSchemeIdNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDistributionSchemeIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvDistributionSchemeIdNo, "dgvDistributionSchemeIdNo")
        Me.dgvDistributionSchemeIdNo.Name = "dgvDistributionSchemeIdNo"
        Me.dgvDistributionSchemeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvSequence
        '
        Me.dgvSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.FillWeight = 1!
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvProfitCenterIdNo
        '
        Me.dgvProfitCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvProfitCenterIdNo.DataPropertyName = "ProfitCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvProfitCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.dgvProfitCenterIdNo, "dgvProfitCenterIdNo")
        Me.dgvProfitCenterIdNo.Name = "dgvProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvPercentage
        '
        Me.dgvPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvPercentage.DataPropertyName = "Percentage"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.dgvPercentage.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPercentage.FillWeight = 1!
        resources.ApplyResources(Me.dgvPercentage, "dgvPercentage")
        Me.dgvPercentage.Name = "dgvPercentage"
        '
        'txtTotalPercentage
        '
        Me.txtTotalPercentage.BackColor = System.Drawing.Color.White
        Me.txtTotalPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPercentage.ComputedValue = true
        Me.txtTotalPercentage.CustomFormat = Nothing
        Me.txtTotalPercentage.DataBoundControl = true
        Me.txtTotalPercentage.DisplayOnly = true
        Me.txtTotalPercentage.EditingMode = true
        resources.ApplyResources(Me.txtTotalPercentage, "txtTotalPercentage")
        Me.txtTotalPercentage.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPercentage.LinkedLabel = Nothing
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