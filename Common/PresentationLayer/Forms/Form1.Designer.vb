<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartmentEntryTv1
    Inherits AATM.PresentationLayer.Forms.CFormEntryTv

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
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacProfitCenterIDNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacCostCenterIDNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 246)
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIDNo)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentCode)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentCode)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentName)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentName)
        Me.CFlowLayout1.Controls.Add(Me.lblDepartmentNameAra)
        Me.CFlowLayout1.Controls.Add(Me.txtDepartmentNameAra)
        Me.CFlowLayout1.Controls.Add(Me.lblParentIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacParentIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblProfitCenterIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacProfitCenterIDNo)
        Me.CFlowLayout1.Controls.Add(Me.lblCostCenterIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacCostCenterIDNo)
        Me.CFlowLayout1.Controls.Add(Me.lblNotes)
        Me.CFlowLayout1.Controls.Add(Me.txtNotes)
        Me.CFlowLayout1.Controls.Add(Me.txtSortKey)
        Me.CFlowLayout1.Location = New System.Drawing.Point(306, 3)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(622, 246)
        Me.CFlowLayout1.TabIndex = 17
        '
        'lblIdNo
        '
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(189, 23)
        Me.lblIdNo.TabIndex = 165
        Me.lblIdNo.Text = "Department ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TxtIDNo.Enabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Location = New System.Drawing.Point(192, 1)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIDNo.TabIndex = 160
        Me.TxtIDNo.TabStop = false
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDepartmentCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentCode.Location = New System.Drawing.Point(1, 26)
        Me.lblDepartmentCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentCode.TabIndex = 166
        Me.lblDepartmentCode.Text = "Department Code"
        Me.lblDepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.BackColor = System.Drawing.Color.White
        Me.txtDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentCode.ComputedValue = false
        Me.txtDepartmentCode.CustomFormat = Nothing
        Me.txtDepartmentCode.DataBoundControl = true
        Me.txtDepartmentCode.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentCode, true)
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDepartmentCode.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentCode.LinkedLabel = Nothing
        Me.txtDepartmentCode.Location = New System.Drawing.Point(192, 26)
        Me.txtDepartmentCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.OldValue = Nothing
        Me.txtDepartmentCode.Size = New System.Drawing.Size(62, 23)
        Me.txtDepartmentCode.TabIndex = 0
        Me.txtDepartmentCode.ValueIsMandatory = true
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDepartmentName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentName.Location = New System.Drawing.Point(1, 51)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentName.TabIndex = 167
        Me.lblDepartmentName.Text = "Department Name"
        Me.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.BackColor = System.Drawing.Color.White
        Me.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentName.ComputedValue = false
        Me.txtDepartmentName.CustomFormat = Nothing
        Me.txtDepartmentName.DataBoundControl = true
        Me.txtDepartmentName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentName, true)
        Me.txtDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDepartmentName.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentName.LinkedLabel = Nothing
        Me.txtDepartmentName.Location = New System.Drawing.Point(192, 51)
        Me.txtDepartmentName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.OldValue = Nothing
        Me.txtDepartmentName.Size = New System.Drawing.Size(418, 23)
        Me.txtDepartmentName.TabIndex = 1
        Me.txtDepartmentName.ValueIsMandatory = true
        '
        'lblDepartmentNameAra
        '
        Me.lblDepartmentNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDepartmentNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentNameAra.Location = New System.Drawing.Point(1, 76)
        Me.lblDepartmentNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentNameAra.Name = "lblDepartmentNameAra"
        Me.lblDepartmentNameAra.Size = New System.Drawing.Size(189, 23)
        Me.lblDepartmentNameAra.TabIndex = 168
        Me.lblDepartmentNameAra.Text = "Department Name (Arabic)"
        Me.lblDepartmentNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartmentNameAra
        '
        Me.txtDepartmentNameAra.BackColor = System.Drawing.Color.White
        Me.txtDepartmentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentNameAra.ComputedValue = false
        Me.txtDepartmentNameAra.CustomFormat = Nothing
        Me.txtDepartmentNameAra.DataBoundControl = true
        Me.txtDepartmentNameAra.EditingMode = false
        Me.txtDepartmentNameAra.EnglishControl = Me.txtDepartmentName
        Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentNameAra, true)
        Me.txtDepartmentNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDepartmentNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDepartmentNameAra.LinkedLabel = Nothing
        Me.txtDepartmentNameAra.Location = New System.Drawing.Point(192, 76)
        Me.txtDepartmentNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDepartmentNameAra.Name = "txtDepartmentNameAra"
        Me.txtDepartmentNameAra.OldValue = Nothing
        Me.txtDepartmentNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDepartmentNameAra.Size = New System.Drawing.Size(418, 23)
        Me.txtDepartmentNameAra.TabIndex = 2
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParentIdNo.Location = New System.Drawing.Point(0, 100)
        Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblParentIdNo.Name = "lblParentIdNo"
        Me.lblParentIdNo.Size = New System.Drawing.Size(190, 24)
        Me.lblParentIdNo.TabIndex = 163
        Me.lblParentIdNo.Text = "Parent Account"
        Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacParentIdNo
        '
        Me.cacParentIdNo.BackColor = System.Drawing.Color.White
        Me.cacParentIdNo.ChangingSearchValueOnly = false
        Me.cacParentIdNo.CurrentSearchTerm = ""
        Me.cacParentIdNo.DefaultValue = Nothing
        Me.cacParentIdNo.DisplayMember = "Name"
        Me.cacParentIdNo.DropDownHeight = 200
        Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacParentIdNo.EditingMode = false
        Me.cacParentIdNo.FilterRule = Nothing
        Me.CFlowLayout1.SetFlowBreak(Me.cacParentIdNo, true)
        Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = true
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Location = New System.Drawing.Point(191, 101)
        Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacParentIdNo.Name = "cacParentIdNo"
        Me.cacParentIdNo.OldValue = 0
        Me.cacParentIdNo.OriginalDataSource = Nothing
        Me.cacParentIdNo.OriginalList = Nothing
        Me.cacParentIdNo.OverrideDropDownStyleList = false
        Me.cacParentIdNo.PreviousSearchTerm = Nothing
        Me.cacParentIdNo.PreviousSelectedIndex = -1
        Me.cacParentIdNo.PropertySelector = Nothing
        Me.cacParentIdNo.ReadOnlyCombo = false
        Me.cacParentIdNo.SearchAnywhere = false
        Me.cacParentIdNo.Size = New System.Drawing.Size(419, 24)
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TabIndex = 3
        Me.cacParentIdNo.TextToSearch = Nothing
        Me.cacParentIdNo.ValueIsMandatory = false
        Me.cacParentIdNo.ValueIsNullable = false
        Me.cacParentIdNo.ValueIsNumeric = false
        Me.cacParentIdNo.ValueMember = "IdNo"
        '
        'lblProfitCenterIdNo
        '
        Me.lblProfitCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblProfitCenterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProfitCenterIdNo.Location = New System.Drawing.Point(1, 127)
        Me.lblProfitCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProfitCenterIdNo.Name = "lblProfitCenterIdNo"
        Me.lblProfitCenterIdNo.Size = New System.Drawing.Size(189, 23)
        Me.lblProfitCenterIdNo.TabIndex = 168
        Me.lblProfitCenterIdNo.Text = "Profit Center"
        Me.lblProfitCenterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacProfitCenterIDNo
        '
        Me.cacProfitCenterIDNo.BackColor = System.Drawing.Color.White
        Me.cacProfitCenterIDNo.ChangingSearchValueOnly = false
        Me.cacProfitCenterIDNo.CurrentSearchTerm = ""
        Me.cacProfitCenterIDNo.DefaultValue = Nothing
        Me.cacProfitCenterIDNo.DisplayMember = "Name"
        Me.cacProfitCenterIDNo.DropDownHeight = 200
        Me.cacProfitCenterIDNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacProfitCenterIDNo.EditingMode = false
        Me.cacProfitCenterIDNo.FilterRule = Nothing
        Me.CFlowLayout1.SetFlowBreak(Me.cacProfitCenterIDNo, true)
        Me.cacProfitCenterIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacProfitCenterIDNo.ForeColor = System.Drawing.Color.Black
        Me.cacProfitCenterIDNo.FormattingEnabled = true
        Me.cacProfitCenterIDNo.HideWhenNotEditingOrAdding = false
        Me.cacProfitCenterIDNo.LinkedLabel = Nothing
        Me.cacProfitCenterIDNo.Location = New System.Drawing.Point(192, 127)
        Me.cacProfitCenterIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacProfitCenterIDNo.Name = "cacProfitCenterIDNo"
        Me.cacProfitCenterIDNo.OldValue = 0
        Me.cacProfitCenterIDNo.OriginalDataSource = Nothing
        Me.cacProfitCenterIDNo.OriginalList = Nothing
        Me.cacProfitCenterIDNo.OverrideDropDownStyleList = false
        Me.cacProfitCenterIDNo.PreviousSearchTerm = Nothing
        Me.cacProfitCenterIDNo.PreviousSelectedIndex = -1
        Me.cacProfitCenterIDNo.PropertySelector = Nothing
        Me.cacProfitCenterIDNo.ReadOnlyCombo = false
        Me.cacProfitCenterIDNo.SearchAnywhere = false
        Me.cacProfitCenterIDNo.Size = New System.Drawing.Size(418, 24)
        Me.cacProfitCenterIDNo.SuggestBoxHeight = 200
        Me.cacProfitCenterIDNo.SuggestListOrderRule = Nothing
        Me.cacProfitCenterIDNo.TabIndex = 4
        Me.cacProfitCenterIDNo.TextToSearch = Nothing
        Me.cacProfitCenterIDNo.ValueIsMandatory = false
        Me.cacProfitCenterIDNo.ValueIsNullable = false
        Me.cacProfitCenterIDNo.ValueIsNumeric = false
        Me.cacProfitCenterIDNo.ValueMember = "IdNo"
        '
        'lblCostCenterIdNo
        '
        Me.lblCostCenterIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCostCenterIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCostCenterIdNo.Location = New System.Drawing.Point(1, 153)
        Me.lblCostCenterIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCostCenterIdNo.Name = "lblCostCenterIdNo"
        Me.lblCostCenterIdNo.Size = New System.Drawing.Size(189, 23)
        Me.lblCostCenterIdNo.TabIndex = 171
        Me.lblCostCenterIdNo.Text = "Cost Center"
        Me.lblCostCenterIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacCostCenterIDNo
        '
        Me.cacCostCenterIDNo.BackColor = System.Drawing.Color.White
        Me.cacCostCenterIDNo.ChangingSearchValueOnly = false
        Me.cacCostCenterIDNo.CurrentSearchTerm = ""
        Me.cacCostCenterIDNo.DefaultValue = Nothing
        Me.cacCostCenterIDNo.DisplayMember = "Name"
        Me.cacCostCenterIDNo.DropDownHeight = 200
        Me.cacCostCenterIDNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacCostCenterIDNo.EditingMode = false
        Me.cacCostCenterIDNo.FilterRule = Nothing
        Me.CFlowLayout1.SetFlowBreak(Me.cacCostCenterIDNo, true)
        Me.cacCostCenterIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacCostCenterIDNo.ForeColor = System.Drawing.Color.Black
        Me.cacCostCenterIDNo.FormattingEnabled = true
        Me.cacCostCenterIDNo.HideWhenNotEditingOrAdding = false
        Me.cacCostCenterIDNo.LinkedLabel = Nothing
        Me.cacCostCenterIDNo.Location = New System.Drawing.Point(192, 153)
        Me.cacCostCenterIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacCostCenterIDNo.Name = "cacCostCenterIDNo"
        Me.cacCostCenterIDNo.OldValue = 0
        Me.cacCostCenterIDNo.OriginalDataSource = Nothing
        Me.cacCostCenterIDNo.OriginalList = Nothing
        Me.cacCostCenterIDNo.OverrideDropDownStyleList = false
        Me.cacCostCenterIDNo.PreviousSearchTerm = Nothing
        Me.cacCostCenterIDNo.PreviousSelectedIndex = -1
        Me.cacCostCenterIDNo.PropertySelector = Nothing
        Me.cacCostCenterIDNo.ReadOnlyCombo = false
        Me.cacCostCenterIDNo.SearchAnywhere = false
        Me.cacCostCenterIDNo.Size = New System.Drawing.Size(418, 24)
        Me.cacCostCenterIDNo.SuggestBoxHeight = 200
        Me.cacCostCenterIDNo.SuggestListOrderRule = Nothing
        Me.cacCostCenterIDNo.TabIndex = 5
        Me.cacCostCenterIDNo.TextToSearch = Nothing
        Me.cacCostCenterIDNo.ValueIsMandatory = false
        Me.cacCostCenterIDNo.ValueIsNullable = false
        Me.cacCostCenterIDNo.ValueIsNumeric = false
        Me.cacCostCenterIDNo.ValueMember = "IdNo"
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(1, 179)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(189, 23)
        Me.lblNotes.TabIndex = 169
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(192, 179)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(418, 60)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.ValueIsMandatory = true
        '
        'txtSortKey
        '
        Me.txtSortKey.BackColor = System.Drawing.Color.White
        Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSortKey.ComputedValue = false
        Me.txtSortKey.CustomFormat = Nothing
        Me.txtSortKey.DataBoundControl = true
        Me.txtSortKey.EditingMode = true
        Me.txtSortKey.Enabled = false
        Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSortKey.ForeColor = System.Drawing.Color.Black
        Me.txtSortKey.LinkedLabel = Nothing
        Me.txtSortKey.Location = New System.Drawing.Point(0, 240)
        Me.txtSortKey.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.ReadOnly = true
        Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
        Me.txtSortKey.TabIndex = 165
        Me.txtSortKey.TabStop = false
        Me.txtSortKey.ValueIsMandatory = true
        Me.txtSortKey.Visible = false
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(929, 332)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "Form1"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents TxtIDNo As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblDepartmentCode As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtDepartmentCode As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblDepartmentName As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtDepartmentName As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblDepartmentNameAra As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtDepartmentNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
    Friend WithEvents lblParentIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cacParentIdNo As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents lblProfitCenterIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cacProfitCenterIDNo As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents lblCostCenterIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cacCostCenterIDNo As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents txtSortKey As Libraries.CBaseControlsLibrary.CTextBox
End Class
