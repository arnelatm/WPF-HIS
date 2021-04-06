Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DepartmentEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepartmentEntryTv))
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepartmentNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblDepartmentCode)
            Me.CFlowLayout1.Controls.Add(Me.txtDepartmentCode)
            Me.CFlowLayout1.Controls.Add(Me.lblDepartmentName)
            Me.CFlowLayout1.Controls.Add(Me.txtDepartmentName)
            Me.CFlowLayout1.Controls.Add(Me.lblDepartmentNameAra)
            Me.CFlowLayout1.Controls.Add(Me.txtDepartmentNameAra)
            Me.CFlowLayout1.Controls.Add(Me.lblParentIdNo)
            Me.CFlowLayout1.Controls.Add(Me.cacParentIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblRevCostCenterIdNo)
            Me.CFlowLayout1.Controls.Add(Me.cacRevCostCenterIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblNotes)
            Me.CFlowLayout1.Controls.Add(Me.txtNotes)
            Me.CFlowLayout1.Controls.Add(Me.txtSortKey)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
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
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
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
            'lblDepartmentCode
            '
            Me.lblDepartmentCode.DisplayOnly = True
            Me.lblDepartmentCode.EditingMode = False
            resources.ApplyResources(Me.lblDepartmentCode, "lblDepartmentCode")
            Me.lblDepartmentCode.Name = "lblDepartmentCode"
            '
            'txtDepartmentCode
            '
            Me.txtDepartmentCode.BackColor = System.Drawing.Color.White
            Me.txtDepartmentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentCode.ComputedValue = False
            Me.txtDepartmentCode.CustomFormat = Nothing
            Me.txtDepartmentCode.DataBoundControl = True
            Me.txtDepartmentCode.EditingMode = False
            Me.txtDepartmentCode.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentCode, True)
            resources.ApplyResources(Me.txtDepartmentCode, "txtDepartmentCode")
            Me.txtDepartmentCode.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentCode.LinkedLabel = Nothing
            Me.txtDepartmentCode.MaximumValue = Nothing
            Me.txtDepartmentCode.MinimumValue = Nothing
            Me.txtDepartmentCode.Name = "txtDepartmentCode"
            Me.txtDepartmentCode.OldValue = Nothing
            Me.txtDepartmentCode.ReadOnly = True
            Me.txtDepartmentCode.ValueIsMandatory = True
            '
            'lblDepartmentName
            '
            Me.lblDepartmentName.DisplayOnly = True
            Me.lblDepartmentName.EditingMode = False
            resources.ApplyResources(Me.lblDepartmentName, "lblDepartmentName")
            Me.lblDepartmentName.Name = "lblDepartmentName"
            '
            'txtDepartmentName
            '
            Me.txtDepartmentName.BackColor = System.Drawing.Color.White
            Me.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentName.ComputedValue = False
            Me.txtDepartmentName.CustomFormat = Nothing
            Me.txtDepartmentName.DataBoundControl = True
            Me.txtDepartmentName.EditingMode = False
            Me.txtDepartmentName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentName, True)
            resources.ApplyResources(Me.txtDepartmentName, "txtDepartmentName")
            Me.txtDepartmentName.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentName.LinkedLabel = Nothing
            Me.txtDepartmentName.MaximumValue = Nothing
            Me.txtDepartmentName.MinimumValue = Nothing
            Me.txtDepartmentName.Name = "txtDepartmentName"
            Me.txtDepartmentName.OldValue = Nothing
            Me.txtDepartmentName.ReadOnly = True
            Me.txtDepartmentName.ValueIsMandatory = True
            '
            'lblDepartmentNameAra
            '
            Me.lblDepartmentNameAra.DisplayOnly = True
            Me.lblDepartmentNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDepartmentNameAra, "lblDepartmentNameAra")
            Me.lblDepartmentNameAra.Name = "lblDepartmentNameAra"
            '
            'txtDepartmentNameAra
            '
            Me.txtDepartmentNameAra.BackColor = System.Drawing.Color.White
            Me.txtDepartmentNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepartmentNameAra.ComputedValue = False
            Me.txtDepartmentNameAra.CustomFormat = Nothing
            Me.txtDepartmentNameAra.DataBoundControl = True
            Me.txtDepartmentNameAra.EditingMode = False
            Me.txtDepartmentNameAra.EnglishControl = Me.txtDepartmentName
            Me.txtDepartmentNameAra.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtDepartmentNameAra, True)
            resources.ApplyResources(Me.txtDepartmentNameAra, "txtDepartmentNameAra")
            Me.txtDepartmentNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDepartmentNameAra.LinkedLabel = Nothing
            Me.txtDepartmentNameAra.MaximumValue = Nothing
            Me.txtDepartmentNameAra.MinimumValue = Nothing
            Me.txtDepartmentNameAra.Name = "txtDepartmentNameAra"
            Me.txtDepartmentNameAra.OldValue = Nothing
            Me.txtDepartmentNameAra.ReadOnly = True
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
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
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.FilterRule = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.cacParentIdNo, True)
            resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.SearchPlace = "A"
            Me.cacParentIdNo.SearchField = Nothing
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblRevCostCenterIdNo
            '
            Me.lblRevCostCenterIdNo.DisplayOnly = True
            Me.lblRevCostCenterIdNo.EditingMode = False
            resources.ApplyResources(Me.lblRevCostCenterIdNo, "lblRevCostCenterIdNo")
            Me.lblRevCostCenterIdNo.Name = "lblRevCostCenterIdNo"
            '
            'cacRevCostCenterIdNo
            '
            Me.cacRevCostCenterIdNo.BackColor = System.Drawing.Color.White
            Me.cacRevCostCenterIdNo.ChangingSearchValueOnly = False
            Me.cacRevCostCenterIdNo.CurrentSearchTerm = ""
            Me.cacRevCostCenterIdNo.DefaultValue = Nothing
            Me.cacRevCostCenterIdNo.DisplayMember = "Name"
            Me.cacRevCostCenterIdNo.EditingMode = False
            Me.cacRevCostCenterIdNo.FilterRule = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.cacRevCostCenterIdNo, True)
            resources.ApplyResources(Me.cacRevCostCenterIdNo, "cacRevCostCenterIdNo")
            Me.cacRevCostCenterIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacRevCostCenterIdNo.FormattingEnabled = True
            Me.cacRevCostCenterIdNo.HideWhenNotEditingOrAdding = False
            Me.cacRevCostCenterIdNo.LinkedLabel = Nothing
            Me.cacRevCostCenterIdNo.Name = "cacRevCostCenterIdNo"
            Me.cacRevCostCenterIdNo.OldValue = 0
            Me.cacRevCostCenterIdNo.OriginalDataSource = Nothing
            Me.cacRevCostCenterIdNo.OriginalList = Nothing
            Me.cacRevCostCenterIdNo.OverrideDropDownStyleList = False
            Me.cacRevCostCenterIdNo.PreviousSearchTerm = Nothing
            Me.cacRevCostCenterIdNo.PreviousSelectedIndex = -1
            Me.cacRevCostCenterIdNo.PropertySelector = Nothing
            Me.cacRevCostCenterIdNo.ReadOnlyCombo = False
            Me.cacRevCostCenterIdNo.SearchPlace = "A"
            Me.cacRevCostCenterIdNo.SearchField = Nothing
            Me.cacRevCostCenterIdNo.SuggestBoxHeight = 200
            Me.cacRevCostCenterIdNo.SuggestListOrderRule = Nothing
            Me.cacRevCostCenterIdNo.TextToSearch = Nothing
            Me.cacRevCostCenterIdNo.ValueIsMandatory = False
            Me.cacRevCostCenterIdNo.ValueIsNullable = False
            Me.cacRevCostCenterIdNo.ValueIsNumeric = False
            Me.cacRevCostCenterIdNo.ValueMember = "IdNo"
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
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtSortKey
            '
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.CustomFormat = Nothing
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.EditingMode = True
            resources.ApplyResources(Me.txtSortKey, "txtSortKey")
            Me.txtSortKey.FindEnabled = False
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
            Me.txtSortKey.LinkedLabel = Nothing
            Me.txtSortKey.MaximumValue = Nothing
            Me.txtSortKey.MinimumValue = Nothing
            Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.ReadOnly = true
        Me.txtSortKey.TabStop = false
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
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblDepartmentCode As CLabel
        Friend WithEvents txtDepartmentCode As CTextBox
        Friend WithEvents lblDepartmentName As CLabel
        Friend WithEvents txtDepartmentName As CTextBox
        Friend WithEvents lblDepartmentNameAra As CLabel
        Friend WithEvents txtDepartmentNameAra As CTextBoxArabic
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblRevCostCenterIdNo As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents cacRevCostCenterIdNo As CaComboBox
        Friend WithEvents txtSortKey As CTextBox
    End Class
End NameSpace