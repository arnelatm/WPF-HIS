Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SecurityGroupEntryTv
    Inherits CFormEntryTv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityGroupEntryTv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewGroupAccesses = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.DGVIDNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVSecurityGroupIDNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVSecurityObjectIDNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DGVVisible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Selectable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Viewable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DGVEditable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsGroupAccesses = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        CType(Me.DataGridViewGroupAccesses,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsGroupAccesses,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
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
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.TabStop = false
        '
        'txtSecurityGroupCode
        '
        Me.txtSecurityGroupCode.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupCode.ComputedValue = false
        Me.txtSecurityGroupCode.CustomFormat = Nothing
        Me.txtSecurityGroupCode.DataBoundControl = true
        Me.txtSecurityGroupCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityGroupCode, true)
        resources.ApplyResources(Me.txtSecurityGroupCode, "txtSecurityGroupCode")
        Me.txtSecurityGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupCode.LinkedLabel = Nothing
        Me.txtSecurityGroupCode.Name = "txtSecurityGroupCode"
        Me.txtSecurityGroupCode.OldValue = Nothing
        Me.txtSecurityGroupCode.ValueIsMandatory = true
        '
        'txtSecurityGroupName
        '
        Me.txtSecurityGroupName.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupName.ComputedValue = false
        Me.txtSecurityGroupName.CustomFormat = Nothing
        Me.txtSecurityGroupName.DataBoundControl = true
        Me.txtSecurityGroupName.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityGroupName, true)
        resources.ApplyResources(Me.txtSecurityGroupName, "txtSecurityGroupName")
        Me.txtSecurityGroupName.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupName.LinkedLabel = Nothing
        Me.txtSecurityGroupName.Name = "txtSecurityGroupName"
        Me.txtSecurityGroupName.OldValue = Nothing
        Me.txtSecurityGroupName.ReadOnly = true
        Me.txtSecurityGroupName.ValueIsMandatory = true
        '
        'txtSecurityGroupNameAra
        '
        Me.txtSecurityGroupNameAra.BackColor = System.Drawing.Color.White
        Me.txtSecurityGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityGroupNameAra.ComputedValue = false
        Me.txtSecurityGroupNameAra.CustomFormat = Nothing
        Me.txtSecurityGroupNameAra.DataBoundControl = true
        Me.txtSecurityGroupNameAra.DisplayOnly = true
        Me.txtSecurityGroupNameAra.EditingMode = true
        Me.txtSecurityGroupNameAra.EnglishControl = Me.txtSecurityGroupName
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityGroupNameAra, true)
        resources.ApplyResources(Me.txtSecurityGroupNameAra, "txtSecurityGroupNameAra")
        Me.txtSecurityGroupNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityGroupNameAra.LinkedLabel = Nothing
        Me.txtSecurityGroupNameAra.Name = "txtSecurityGroupNameAra"
        Me.txtSecurityGroupNameAra.OldValue = Nothing
        Me.txtSecurityGroupNameAra.ReadOnly = true
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
        Me.floDataDisplay.Controls.Add(Me.lblSecurityGroupCode)
        Me.floDataDisplay.Controls.Add(Me.txtSecurityGroupCode)
        Me.floDataDisplay.Controls.Add(Me.lblSecurityGroupName)
        Me.floDataDisplay.Controls.Add(Me.txtSecurityGroupName)
        Me.floDataDisplay.Controls.Add(Me.lblSecurityGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtSecurityGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblSecurityGroupCode
        '
        resources.ApplyResources(Me.lblSecurityGroupCode, "lblSecurityGroupCode")
        Me.lblSecurityGroupCode.Name = "lblSecurityGroupCode"
        '
        'lblSecurityGroupName
        '
        resources.ApplyResources(Me.lblSecurityGroupName, "lblSecurityGroupName")
        Me.lblSecurityGroupName.Name = "lblSecurityGroupName"
        '
        'lblSecurityGroupNameAra
        '
        resources.ApplyResources(Me.lblSecurityGroupNameAra, "lblSecurityGroupNameAra")
        Me.lblSecurityGroupNameAra.Name = "lblSecurityGroupNameAra"
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'DataGridViewGroupAccesses
        '
        Me.DataGridViewGroupAccesses.AllowUserToAddRows = false
        Me.DataGridViewGroupAccesses.AllowUserToDeleteRows = false
        Me.DataGridViewGroupAccesses.AllowUserToOrderColumns = true
        Me.DataGridViewGroupAccesses.AllowUserToResizeRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.DataGridViewGroupAccesses.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewGroupAccesses.AutoGenerateColumns = false
        Me.DataGridViewGroupAccesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewGroupAccesses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewGroupAccesses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridViewGroupAccesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewGroupAccesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVIDNo, Me.DGVSecurityGroupIDNo, Me.DGVSecurityObjectIDNo, Me.DGVSecurityObjectName, Me.DGVVisible, Me.Selectable, Me.Viewable, Me.DGVEditable})
        Me.DataGridViewGroupAccesses.DataInGridChanged = false
        Me.DataGridViewGroupAccesses.DataSource = Me.bsGroupAccesses
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewGroupAccesses.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewGroupAccesses.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewGroupAccesses, "DataGridViewGroupAccesses")
        Me.DataGridViewGroupAccesses.EditingMode = false
        Me.DataGridViewGroupAccesses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewGroupAccesses.Name = "DataGridViewGroupAccesses"
        Me.DataGridViewGroupAccesses.SequenceColumn = "dgvSequence"
        Me.DataGridViewGroupAccesses.StartTrackingChanges = false
        '
        'DGVIDNo
        '
        Me.DGVIDNo.DataPropertyName = "IDNo"
        resources.ApplyResources(Me.DGVIDNo, "DGVIDNo")
        Me.DGVIDNo.Name = "DGVIDNo"
        '
        'DGVSecurityGroupIDNo
        '
        Me.DGVSecurityGroupIDNo.DataPropertyName = "SecurityGroupIDNo"
        resources.ApplyResources(Me.DGVSecurityGroupIDNo, "DGVSecurityGroupIDNo")
        Me.DGVSecurityGroupIDNo.Name = "DGVSecurityGroupIDNo"
        '
        'DGVSecurityObjectIDNo
        '
        Me.DGVSecurityObjectIDNo.DataPropertyName = "SecurityObjectIDNo"
        Me.DGVSecurityObjectIDNo.FillWeight = 20!
        resources.ApplyResources(Me.DGVSecurityObjectIDNo, "DGVSecurityObjectIDNo")
        Me.DGVSecurityObjectIDNo.Name = "DGVSecurityObjectIDNo"
        '
        'DGVSecurityObjectName
        '
        Me.DGVSecurityObjectName.DataPropertyName = "SecurityObjectName"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGVSecurityObjectName.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVSecurityObjectName.EditingMode = false
        Me.DGVSecurityObjectName.FillWeight = 168.5721!
        resources.ApplyResources(Me.DGVSecurityObjectName, "DGVSecurityObjectName")
        Me.DGVSecurityObjectName.Name = "DGVSecurityObjectName"
        Me.DGVSecurityObjectName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DGVVisible
        '
        Me.DGVVisible.DataPropertyName = "Visible"
        Me.DGVVisible.FillWeight = 10!
        resources.ApplyResources(Me.DGVVisible, "DGVVisible")
        Me.DGVVisible.Name = "DGVVisible"
        Me.DGVVisible.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Selectable
        '
        Me.Selectable.DataPropertyName = "Selectable"
        Me.Selectable.FillWeight = 10!
        resources.ApplyResources(Me.Selectable, "Selectable")
        Me.Selectable.Name = "Selectable"
        Me.Selectable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Selectable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Viewable
        '
        Me.Viewable.DataPropertyName = "Viewable"
        Me.Viewable.FillWeight = 10!
        resources.ApplyResources(Me.Viewable, "Viewable")
        Me.Viewable.Name = "Viewable"
        '
        'DGVEditable
        '
        Me.DGVEditable.DataPropertyName = "Editable"
        Me.DGVEditable.FillWeight = 10!
        resources.ApplyResources(Me.DGVEditable, "DGVEditable")
        Me.DGVEditable.Name = "DGVEditable"
        Me.DGVEditable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVEditable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewGroupAccesses)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'SecurityGroupEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "SecurityGroupEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        CType(Me.DataGridViewGroupAccesses,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsGroupAccesses,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents TxtIDNo As CTextBox
    Friend WithEvents txtSecurityGroupCode As CTextBox
    Friend WithEvents txtSecurityGroupName As CTextBox
    Friend WithEvents txtSecurityGroupNameAra As CTextBoxArabic
    Friend WithEvents txtNotes As CTextBox
    Friend WithEvents floDataDisplay As CFlowLayout
    Friend WithEvents lblIdNo As CLabel
    Friend WithEvents lblSecurityGroupCode As CLabel
    Friend WithEvents lblSecurityGroupName As CLabel
    Friend WithEvents lblSecurityGroupNameAra As CLabel
    Friend WithEvents lblNotes As CLabel
    Friend WithEvents DataGridViewGroupAccesses As CDataGridView
    Friend WithEvents bsGroupAccesses As Windows.Forms.BindingSource
    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents DGVIDNo As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVSecurityGroupIDNo As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVSecurityObjectIDNo As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVSecurityObjectName As CdgvColumnText
    Friend WithEvents DGVVisible As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Selectable As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Viewable As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DGVEditable As Windows.Forms.DataGridViewCheckBoxColumn
End Class