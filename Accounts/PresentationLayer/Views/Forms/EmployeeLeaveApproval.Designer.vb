<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeLeaveApproval
    Inherits AATM.PresentationLayer.Forms.CFormBase

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewEmployeeLeave = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsEmployeeLeave = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvFullDay = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvStartDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEndDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvLeaveReason = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.AppliedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeaveStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupervisorIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewEmployeeLeave,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEmployeeLeave,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGridViewEmployeeLeave
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEmployeeLeave.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewEmployeeLeave.AutoGenerateColumns = false
        Me.DataGridViewEmployeeLeave.BegFindValue = Nothing
        Me.DataGridViewEmployeeLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEmployeeLeave.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEmployeeIdNo, Me.dgvFullDay, Me.dgvStartDate, Me.dgvEndDate, Me.dgvLeaveIdNo, Me.dgvLeaveReason, Me.AppliedByDataGridViewTextBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.dgvIdNo, Me.LeaveStatusDataGridViewTextBoxColumn, Me.SupervisorIdNoDataGridViewTextBoxColumn})
        Me.DataGridViewEmployeeLeave.DataSource = Me.bsEmployeeLeave
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEmployeeLeave.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewEmployeeLeave.DgvFooter = Nothing
        Me.DataGridViewEmployeeLeave.DisplayOnly = false
        Me.DataGridViewEmployeeLeave.Ea = Nothing
        Me.DataGridViewEmployeeLeave.EditingMode = false
        Me.DataGridViewEmployeeLeave.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEmployeeLeave.EndFindValue = Nothing
        Me.DataGridViewEmployeeLeave.FieldDescription = Nothing
        Me.DataGridViewEmployeeLeave.FieldName = Nothing
        Me.DataGridViewEmployeeLeave.FieldsDictionary = Nothing
        Me.DataGridViewEmployeeLeave.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewEmployeeLeave.FindEnabled = false
        Me.DataGridViewEmployeeLeave.FirstRowDeletionEnabled = true
        Me.DataGridViewEmployeeLeave.FirstRowInsertionEnabled = true
        Me.DataGridViewEmployeeLeave.IgnoreCase = false
        Me.DataGridViewEmployeeLeave.Location = New System.Drawing.Point(4, 57)
        Me.DataGridViewEmployeeLeave.Name = "DataGridViewEmployeeLeave"
        Me.DataGridViewEmployeeLeave.ReadOnly = true
        Me.DataGridViewEmployeeLeave.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewEmployeeLeave.SecurityKey = ""
        Me.DataGridViewEmployeeLeave.SequenceColumn = "dgvSequence"
        Me.DataGridViewEmployeeLeave.SequenceFieldName = "Sequence"
        Me.DataGridViewEmployeeLeave.ShowFooter = false
        Me.DataGridViewEmployeeLeave.ShowInsertColumnWhenEditing = true
        Me.DataGridViewEmployeeLeave.Size = New System.Drawing.Size(1114, 389)
        Me.DataGridViewEmployeeLeave.TabIndex = 4
        Me.DataGridViewEmployeeLeave.Translatable = true
        '
        'bsEmployeeLeave
        '
        Me.bsEmployeeLeave.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeLeaveModel)
        '
        'dgvEmployeeIdNo
        '
        Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
        Me.dgvEmployeeIdNo.EditingMode = false
        Me.dgvEmployeeIdNo.HeaderText = "Employee Name"
        Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
        Me.dgvEmployeeIdNo.ReadOnly = true
        Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEmployeeIdNo.Translatable = false
        Me.dgvEmployeeIdNo.Width = 200
        '
        'dgvFullDay
        '
        Me.dgvFullDay.BegFindValue = Nothing
        Me.dgvFullDay.DataPropertyName = "FullDay"
        Me.dgvFullDay.EditingMode = false
        Me.dgvFullDay.EndFindValue = Nothing
        Me.dgvFullDay.FieldDescription = Nothing
        Me.dgvFullDay.FieldName = Nothing
        Me.dgvFullDay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvFullDay.FindEnabled = false
        Me.dgvFullDay.HeaderText = "Full Day"
        Me.dgvFullDay.IgnoreCase = false
        Me.dgvFullDay.Name = "dgvFullDay"
        Me.dgvFullDay.ReadOnly = true
        Me.dgvFullDay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFullDay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvFullDay.Translatable = false
        Me.dgvFullDay.Width = 30
        '
        'dgvStartDate
        '
        Me.dgvStartDate.BegFindValue = Nothing
        Me.dgvStartDate.DataPropertyName = "StartDate"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvStartDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStartDate.EditingMode = false
        Me.dgvStartDate.EndFindValue = Nothing
        Me.dgvStartDate.FieldDescription = Nothing
        Me.dgvStartDate.FieldName = Nothing
        Me.dgvStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvStartDate.FindEnabled = false
        Me.dgvStartDate.HeaderText = "Start Date"
        Me.dgvStartDate.IgnoreCase = false
        Me.dgvStartDate.Name = "dgvStartDate"
        Me.dgvStartDate.ReadOnly = true
        Me.dgvStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvStartDate.Translatable = false
        '
        'dgvEndDate
        '
        Me.dgvEndDate.BegFindValue = Nothing
        Me.dgvEndDate.DataPropertyName = "EndDate"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvEndDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEndDate.EditingMode = false
        Me.dgvEndDate.EndFindValue = Nothing
        Me.dgvEndDate.FieldDescription = Nothing
        Me.dgvEndDate.FieldName = Nothing
        Me.dgvEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEndDate.FindEnabled = false
        Me.dgvEndDate.HeaderText = "End Date"
        Me.dgvEndDate.IgnoreCase = false
        Me.dgvEndDate.Name = "dgvEndDate"
        Me.dgvEndDate.ReadOnly = true
        Me.dgvEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEndDate.Translatable = false
        '
        'dgvLeaveIdNo
        '
        Me.dgvLeaveIdNo.DataPropertyName = "LeaveIdNo"
        Me.dgvLeaveIdNo.EditingMode = false
        Me.dgvLeaveIdNo.HeaderText = "Leave Name"
        Me.dgvLeaveIdNo.Name = "dgvLeaveIdNo"
        Me.dgvLeaveIdNo.ReadOnly = true
        Me.dgvLeaveIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvLeaveIdNo.Translatable = false
        Me.dgvLeaveIdNo.Width = 200
        '
        'dgvLeaveReason
        '
        Me.dgvLeaveReason.BegFindValue = Nothing
        Me.dgvLeaveReason.DataPropertyName = "LeaveReason"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveReason.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLeaveReason.EditingMode = false
        Me.dgvLeaveReason.EndFindValue = Nothing
        Me.dgvLeaveReason.FieldDescription = Nothing
        Me.dgvLeaveReason.FieldName = Nothing
        Me.dgvLeaveReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvLeaveReason.FindEnabled = false
        Me.dgvLeaveReason.HeaderText = "Leave Reason"
        Me.dgvLeaveReason.IgnoreCase = false
        Me.dgvLeaveReason.Name = "dgvLeaveReason"
        Me.dgvLeaveReason.ReadOnly = true
        Me.dgvLeaveReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvLeaveReason.Translatable = false
        Me.dgvLeaveReason.Width = 200
        '
        'AppliedByDataGridViewTextBoxColumn
        '
        Me.AppliedByDataGridViewTextBoxColumn.DataPropertyName = "AppliedBy"
        Me.AppliedByDataGridViewTextBoxColumn.HeaderText = "AppliedBy"
        Me.AppliedByDataGridViewTextBoxColumn.Name = "AppliedByDataGridViewTextBoxColumn"
        Me.AppliedByDataGridViewTextBoxColumn.ReadOnly = true
        Me.AppliedByDataGridViewTextBoxColumn.Visible = false
        '
        'DateCreatedDataGridViewTextBoxColumn
        '
        Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
        Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = true
        Me.DateCreatedDataGridViewTextBoxColumn.Visible = false
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Visible = false
        '
        'LeaveStatusDataGridViewTextBoxColumn
        '
        Me.LeaveStatusDataGridViewTextBoxColumn.DataPropertyName = "LeaveStatus"
        Me.LeaveStatusDataGridViewTextBoxColumn.HeaderText = "Leave Status"
        Me.LeaveStatusDataGridViewTextBoxColumn.Name = "LeaveStatusDataGridViewTextBoxColumn"
        Me.LeaveStatusDataGridViewTextBoxColumn.ReadOnly = true
        '
        'SupervisorIdNoDataGridViewTextBoxColumn
        '
        Me.SupervisorIdNoDataGridViewTextBoxColumn.DataPropertyName = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.HeaderText = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Name = "SupervisorIdNoDataGridViewTextBoxColumn"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'EmployeeLeaveApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1130, 571)
        Me.Controls.Add(Me.DataGridViewEmployeeLeave)
        Me.Name = "EmployeeLeaveApproval"
        Me.Controls.SetChildIndex(Me.DataGridViewEmployeeLeave, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewEmployeeLeave,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEmployeeLeave,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents DataGridViewEmployeeLeave As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents bsEmployeeLeave As BindingSource
    Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
    Friend WithEvents dgvFullDay As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvStartDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEndDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
    Friend WithEvents dgvLeaveReason As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents AppliedByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
    Friend WithEvents LeaveStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupervisorIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
