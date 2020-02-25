Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DepartmentEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepartmentEntryTv))
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
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'CFlowLayout1
        '
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
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'TxtIDNo
        '
        Me.TxtIDNo.AcceptsReturn = false
        Me.TxtIDNo.AcceptsTab = false
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = True
            Me.TxtIDNo.EditingMode = True
            resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIDNo, True)
            Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIDNo.LinkedLabel = Nothing
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.TabStop = False
            '
            'lblDepartmentCode
            '
            resources.ApplyResources(Me.lblDepartmentCode, "lblDepartmentCode")
            Me.lblDepartmentCode.Name = "lblDepartmentCode"
            '
            'txtDepartmentCode
            '
            Me.txtDepartmentCode.AcceptsReturn = false
            Me.txtDepartmentCode.AcceptsTab = false
            Me.txtDepartmentCode.BackColor = System.Drawing.Color.White
            Me.txtDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentCode.ComputedValue = False
            Me.txtDepartmentCode.DataBoundControl = True
            Me.txtDepartmentCode.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentCode, True)
            resources.ApplyResources(Me.txtDepartmentCode, "txtDepartmentCode")
            Me.txtDepartmentCode.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentCode.LinkedLabel = Nothing
            Me.txtDepartmentCode.Name = "txtDepartmentCode"
            Me.txtDepartmentCode.ValueIsMandatory = True
            '
            'lblDepartmentName
            '
            resources.ApplyResources(Me.lblDepartmentName, "lblDepartmentName")
            Me.lblDepartmentName.Name = "lblDepartmentName"
            '
            'txtDepartmentName
            '
            Me.txtDepartmentName.AcceptsReturn = false
            Me.txtDepartmentName.AcceptsTab = false
            Me.txtDepartmentName.BackColor = System.Drawing.Color.White
            Me.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentName.ComputedValue = False
            Me.txtDepartmentName.DataBoundControl = True
            Me.txtDepartmentName.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentName, True)
            resources.ApplyResources(Me.txtDepartmentName, "txtDepartmentName")
            Me.txtDepartmentName.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentName.LinkedLabel = Nothing
            Me.txtDepartmentName.Name = "txtDepartmentName"
            Me.txtDepartmentName.ValueIsMandatory = True
            '
            'lblDepartmentNameAra
            '
            resources.ApplyResources(Me.lblDepartmentNameAra, "lblDepartmentNameAra")
            Me.lblDepartmentNameAra.Name = "lblDepartmentNameAra"
            '
            'txtDepartmentNameAra
            '
            Me.txtDepartmentNameAra.AcceptsReturn = false
            Me.txtDepartmentNameAra.AcceptsTab = false
            Me.txtDepartmentNameAra.BackColor = System.Drawing.Color.White
            Me.txtDepartmentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentNameAra.ComputedValue = False
            Me.txtDepartmentNameAra.DataBoundControl = True
            Me.txtDepartmentNameAra.EditingMode = False
            Me.txtDepartmentNameAra.EnglishControl = Me.txtDepartmentName
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentNameAra, True)
            resources.ApplyResources(Me.txtDepartmentNameAra, "txtDepartmentNameAra")
            Me.txtDepartmentNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentNameAra.LinkedLabel = Nothing
            Me.txtDepartmentNameAra.Name = "txtDepartmentNameAra"
            '
            'lblParentIdNo
            '
            resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
            Me.lblParentIdNo.Name = "lblParentIdNo"
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.DropDownHeight = 200
            Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.FilterRule = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.cacParentIdNo, True)
            resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = Nothing
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.SearchAnywhere = False
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblProfitCenterIdNo
            '
            resources.ApplyResources(Me.lblProfitCenterIdNo, "lblProfitCenterIdNo")
            Me.lblProfitCenterIdNo.Name = "lblProfitCenterIdNo"
            '
            'cacProfitCenterIDNo
            '
            Me.cacProfitCenterIDNo.BackColor = System.Drawing.Color.White
            Me.cacProfitCenterIDNo.ChangingSearchValueOnly = False
            Me.cacProfitCenterIDNo.CurrentSearchTerm = ""
            Me.cacProfitCenterIDNo.DefaultValue = Nothing
            Me.cacProfitCenterIDNo.DisplayMember = "Name"
            Me.cacProfitCenterIDNo.DropDownHeight = 200
            Me.cacProfitCenterIDNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacProfitCenterIDNo.EditingMode = False
            Me.cacProfitCenterIDNo.FilterRule = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.cacProfitCenterIDNo, True)
            resources.ApplyResources(Me.cacProfitCenterIDNo, "cacProfitCenterIDNo")
            Me.cacProfitCenterIDNo.ForeColor = System.Drawing.Color.Black
            Me.cacProfitCenterIDNo.FormattingEnabled = True
            Me.cacProfitCenterIDNo.HideWhenNotEditingOrAdding = False
            Me.cacProfitCenterIDNo.LinkedLabel = Nothing
            Me.cacProfitCenterIDNo.Name = "cacProfitCenterIDNo"
            Me.cacProfitCenterIDNo.OldValue = Nothing
            Me.cacProfitCenterIDNo.OriginalDataSource = Nothing
            Me.cacProfitCenterIDNo.OriginalList = Nothing
            Me.cacProfitCenterIDNo.OverrideDropDownStyleList = False
            Me.cacProfitCenterIDNo.PreviousSearchTerm = Nothing
            Me.cacProfitCenterIDNo.PreviousSelectedIndex = -1
            Me.cacProfitCenterIDNo.PropertySelector = Nothing
            Me.cacProfitCenterIDNo.ReadOnlyCombo = False
            Me.cacProfitCenterIDNo.SearchAnywhere = False
            Me.cacProfitCenterIDNo.SuggestBoxHeight = 200
            Me.cacProfitCenterIDNo.SuggestListOrderRule = Nothing
            Me.cacProfitCenterIDNo.TextToSearch = Nothing
            Me.cacProfitCenterIDNo.ValueIsMandatory = False
            Me.cacProfitCenterIDNo.ValueIsNullable = False
            Me.cacProfitCenterIDNo.ValueIsNumeric = False
            Me.cacProfitCenterIDNo.ValueMember = "IdNo"
            '
            'lblCostCenterIdNo
            '
            resources.ApplyResources(Me.lblCostCenterIdNo, "lblCostCenterIdNo")
            Me.lblCostCenterIdNo.Name = "lblCostCenterIdNo"
            '
            'cacCostCenterIDNo
            '
            Me.cacCostCenterIDNo.BackColor = System.Drawing.Color.White
            Me.cacCostCenterIDNo.ChangingSearchValueOnly = False
            Me.cacCostCenterIDNo.CurrentSearchTerm = ""
            Me.cacCostCenterIDNo.DefaultValue = Nothing
            Me.cacCostCenterIDNo.DisplayMember = "Name"
            Me.cacCostCenterIDNo.DropDownHeight = 200
            Me.cacCostCenterIDNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacCostCenterIDNo.EditingMode = False
            Me.cacCostCenterIDNo.FilterRule = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.cacCostCenterIDNo, True)
            resources.ApplyResources(Me.cacCostCenterIDNo, "cacCostCenterIDNo")
            Me.cacCostCenterIDNo.ForeColor = System.Drawing.Color.Black
            Me.cacCostCenterIDNo.FormattingEnabled = True
            Me.cacCostCenterIDNo.HideWhenNotEditingOrAdding = False
            Me.cacCostCenterIDNo.LinkedLabel = Nothing
            Me.cacCostCenterIDNo.Name = "cacCostCenterIDNo"
            Me.cacCostCenterIDNo.OldValue = Nothing
            Me.cacCostCenterIDNo.OriginalDataSource = Nothing
            Me.cacCostCenterIDNo.OriginalList = Nothing
            Me.cacCostCenterIDNo.OverrideDropDownStyleList = False
            Me.cacCostCenterIDNo.PreviousSearchTerm = Nothing
            Me.cacCostCenterIDNo.PreviousSelectedIndex = -1
            Me.cacCostCenterIDNo.PropertySelector = Nothing
            Me.cacCostCenterIDNo.ReadOnlyCombo = False
            Me.cacCostCenterIDNo.SearchAnywhere = False
            Me.cacCostCenterIDNo.SuggestBoxHeight = 200
            Me.cacCostCenterIDNo.SuggestListOrderRule = Nothing
            Me.cacCostCenterIDNo.TextToSearch = Nothing
            Me.cacCostCenterIDNo.ValueIsMandatory = False
            Me.cacCostCenterIDNo.ValueIsNullable = False
            Me.cacCostCenterIDNo.ValueIsNumeric = False
            Me.cacCostCenterIDNo.ValueMember = "IdNo"
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
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
            'txtSortKey
            '
            Me.txtSortKey.AcceptsReturn = false
            Me.txtSortKey.AcceptsTab = false
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.EditingMode = True
            resources.ApplyResources(Me.txtSortKey, "txtSortKey")
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
            Me.txtSortKey.LinkedLabel = Nothing
            Me.txtSortKey.Name = "txtSortKey"
            Me.txtSortKey.ReadOnly = True
            Me.txtSortKey.TabStop = False
            Me.txtSortKey.ValueIsMandatory = true
        '
        'DepartmentEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "DepartmentEntryTv"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents lblDepartmentCode As CLabel
        Friend WithEvents txtDepartmentCode As CTextBox
        Friend WithEvents lblDepartmentName As CLabel
        Friend WithEvents txtDepartmentName As CTextBox
        Friend WithEvents lblDepartmentNameAra As CLabel
        Friend WithEvents txtDepartmentNameAra As CTextBoxArabic
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblProfitCenterIdNo As CLabel
        Friend WithEvents lblCostCenterIdNo As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents cacProfitCenterIDNo As CaComboBox
        Friend WithEvents cacCostCenterIDNo As CaComboBox
        Friend WithEvents txtSortKey As CTextBox
    End Class
End NameSpace