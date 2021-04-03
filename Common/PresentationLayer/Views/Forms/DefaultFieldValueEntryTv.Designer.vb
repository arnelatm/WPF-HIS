Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DefaultFieldValueEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefaultFieldValueEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFieldName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFieldName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDataType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDataType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblLength = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLength = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDecimalPart = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDecimalPart = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLinkedTable = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLinkedField = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDefaultValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSystemViewNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSystemViewName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
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
            '
            'txtFieldName
            '
            Me.txtFieldName.BackColor = System.Drawing.Color.White
            Me.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFieldName.ComputedValue = False
            Me.txtFieldName.CustomFormat = Nothing
            Me.txtFieldName.DataBoundControl = True
            Me.txtFieldName.EditingMode = True
            Me.txtFieldName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtFieldName, True)
            resources.ApplyResources(Me.txtFieldName, "txtFieldName")
            Me.txtFieldName.ForeColor = System.Drawing.Color.Black
            Me.txtFieldName.LinkedLabel = Nothing
            Me.txtFieldName.MaximumValue = Nothing
            Me.txtFieldName.MinimumValue = Nothing
            Me.txtFieldName.Name = "txtFieldName"
            Me.txtFieldName.OldValue = Nothing
            Me.txtFieldName.ReadOnly = True
            Me.txtFieldName.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblSystemViewIdNo)
            Me.floDataDisplay.Controls.Add(Me.cboSystemViewIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblFieldName)
            Me.floDataDisplay.Controls.Add(Me.txtFieldName)
            Me.floDataDisplay.Controls.Add(Me.lblDataType)
            Me.floDataDisplay.Controls.Add(Me.cboDataType)
            Me.floDataDisplay.Controls.Add(Me.lblLength)
            Me.floDataDisplay.Controls.Add(Me.txtLength)
            Me.floDataDisplay.Controls.Add(Me.lblDecimalPart)
            Me.floDataDisplay.Controls.Add(Me.txtDecimalPart)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtLinkedTable)
            Me.floDataDisplay.Controls.Add(Me.CLabel2)
            Me.floDataDisplay.Controls.Add(Me.txtLinkedField)
            Me.floDataDisplay.Controls.Add(Me.CLabel3)
            Me.floDataDisplay.Controls.Add(Me.txtDefaultValue)
            Me.floDataDisplay.Controls.Add(Me.txtSystemViewNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtSystemViewName)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblSystemViewIdNo
            '
            Me.lblSystemViewIdNo.DisplayOnly = True
            Me.lblSystemViewIdNo.EditingMode = False
            resources.ApplyResources(Me.lblSystemViewIdNo, "lblSystemViewIdNo")
            Me.lblSystemViewIdNo.Name = "lblSystemViewIdNo"
            '
            'cboSystemViewIdNo
            '
            Me.cboSystemViewIdNo.BackColor = System.Drawing.Color.White
            Me.cboSystemViewIdNo.ChangingSearchValueOnly = False
            Me.cboSystemViewIdNo.CurrentSearchTerm = ""
            Me.cboSystemViewIdNo.DefaultValue = Nothing
            Me.cboSystemViewIdNo.DisplayMember = "Name"
            Me.cboSystemViewIdNo.EditingMode = True
            Me.cboSystemViewIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboSystemViewIdNo, "cboSystemViewIdNo")
            Me.cboSystemViewIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSystemViewIdNo.FormattingEnabled = True
            Me.cboSystemViewIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSystemViewIdNo.LinkedLabel = Nothing
            Me.cboSystemViewIdNo.Name = "cboSystemViewIdNo"
            Me.cboSystemViewIdNo.OldValue = 0
            Me.cboSystemViewIdNo.OriginalDataSource = Nothing
            Me.cboSystemViewIdNo.OriginalList = Nothing
            Me.cboSystemViewIdNo.OverrideDropDownStyleList = False
            Me.cboSystemViewIdNo.PreviousSearchTerm = Nothing
            Me.cboSystemViewIdNo.PreviousSelectedIndex = -1
            Me.cboSystemViewIdNo.PropertySelector = Nothing
            Me.cboSystemViewIdNo.ReadOnlyCombo = False
            Me.cboSystemViewIdNo.SearchAnywhere = False
            Me.cboSystemViewIdNo.SearchField = Nothing
            Me.cboSystemViewIdNo.SuggestBoxHeight = 200
            Me.cboSystemViewIdNo.SuggestListOrderRule = Nothing
            Me.cboSystemViewIdNo.TextToSearch = Nothing
            Me.cboSystemViewIdNo.ValueIsMandatory = False
            Me.cboSystemViewIdNo.ValueIsNullable = False
            Me.cboSystemViewIdNo.ValueIsNumeric = False
            Me.cboSystemViewIdNo.ValueMember = "IdNo"
            '
            'lblFieldName
            '
            Me.lblFieldName.DisplayOnly = True
            Me.lblFieldName.EditingMode = False
            resources.ApplyResources(Me.lblFieldName, "lblFieldName")
            Me.lblFieldName.Name = "lblFieldName"
            '
            'lblDataType
            '
            Me.lblDataType.DisplayOnly = True
            Me.lblDataType.EditingMode = False
            resources.ApplyResources(Me.lblDataType, "lblDataType")
            Me.lblDataType.Name = "lblDataType"
            '
            'cboDataType
            '
            Me.cboDataType.BackColor = System.Drawing.Color.White
            Me.cboDataType.ChangingSearchValueOnly = False
            Me.cboDataType.CurrentSearchTerm = ""
            Me.cboDataType.DefaultValue = Nothing
            Me.cboDataType.DisplayMember = "Name"
            Me.cboDataType.EditingMode = True
            Me.cboDataType.FilterRule = Nothing
            resources.ApplyResources(Me.cboDataType, "cboDataType")
            Me.cboDataType.ForeColor = System.Drawing.Color.Black
            Me.cboDataType.FormattingEnabled = True
            Me.cboDataType.HideWhenNotEditingOrAdding = False
            Me.cboDataType.LinkedLabel = Nothing
            Me.cboDataType.Name = "cboDataType"
            Me.cboDataType.OldValue = 0
            Me.cboDataType.OriginalDataSource = Nothing
            Me.cboDataType.OriginalList = Nothing
            Me.cboDataType.OverrideDropDownStyleList = False
            Me.cboDataType.PreviousSearchTerm = Nothing
            Me.cboDataType.PreviousSelectedIndex = -1
            Me.cboDataType.PropertySelector = Nothing
            Me.cboDataType.ReadOnlyCombo = False
            Me.cboDataType.SearchAnywhere = False
            Me.cboDataType.SearchField = Nothing
            Me.cboDataType.SuggestBoxHeight = 200
            Me.cboDataType.SuggestListOrderRule = Nothing
            Me.cboDataType.TextToSearch = Nothing
            Me.cboDataType.ValueIsMandatory = False
            Me.cboDataType.ValueIsNullable = False
            Me.cboDataType.ValueIsNumeric = False
            Me.cboDataType.ValueMember = "IdNo"
            '
            'lblLength
            '
            Me.lblLength.DisplayOnly = True
            Me.lblLength.EditingMode = False
            resources.ApplyResources(Me.lblLength, "lblLength")
            Me.lblLength.Name = "lblLength"
            '
            'txtLength
            '
            Me.txtLength.BackColor = System.Drawing.Color.White
            Me.txtLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLength.ComputedValue = False
            Me.txtLength.CustomFormat = Nothing
            Me.txtLength.DataBoundControl = True
            Me.txtLength.EditingMode = True
            Me.txtLength.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLength, True)
            resources.ApplyResources(Me.txtLength, "txtLength")
            Me.txtLength.ForeColor = System.Drawing.Color.Black
            Me.txtLength.LinkedLabel = Nothing
            Me.txtLength.MaximumValue = Nothing
            Me.txtLength.MinimumValue = Nothing
            Me.txtLength.Name = "txtLength"
            Me.txtLength.OldValue = Nothing
            Me.txtLength.ReadOnly = True
            Me.txtLength.ValueIsMandatory = True
            Me.txtLength.ValueIsNumeric = True
            '
            'lblDecimalPart
            '
            Me.lblDecimalPart.DisplayOnly = True
            Me.lblDecimalPart.EditingMode = False
            resources.ApplyResources(Me.lblDecimalPart, "lblDecimalPart")
            Me.lblDecimalPart.Name = "lblDecimalPart"
            '
            'txtDecimalPart
            '
            Me.txtDecimalPart.BackColor = System.Drawing.Color.White
            Me.txtDecimalPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDecimalPart.ComputedValue = False
            Me.txtDecimalPart.CustomFormat = Nothing
            Me.txtDecimalPart.DataBoundControl = True
            Me.txtDecimalPart.EditingMode = True
            Me.txtDecimalPart.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDecimalPart, True)
            resources.ApplyResources(Me.txtDecimalPart, "txtDecimalPart")
            Me.txtDecimalPart.ForeColor = System.Drawing.Color.Black
            Me.txtDecimalPart.LinkedLabel = Nothing
            Me.txtDecimalPart.MaximumValue = Nothing
            Me.txtDecimalPart.MinimumValue = Nothing
            Me.txtDecimalPart.Name = "txtDecimalPart"
            Me.txtDecimalPart.OldValue = Nothing
            Me.txtDecimalPart.ReadOnly = True
            Me.txtDecimalPart.ValueIsMandatory = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'txtLinkedTable
            '
            Me.txtLinkedTable.BackColor = System.Drawing.Color.White
            Me.txtLinkedTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLinkedTable.ComputedValue = False
            Me.txtLinkedTable.CustomFormat = Nothing
            Me.txtLinkedTable.DataBoundControl = True
            Me.txtLinkedTable.EditingMode = True
            Me.txtLinkedTable.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLinkedTable, True)
            resources.ApplyResources(Me.txtLinkedTable, "txtLinkedTable")
            Me.txtLinkedTable.ForeColor = System.Drawing.Color.Black
            Me.txtLinkedTable.LinkedLabel = Nothing
            Me.txtLinkedTable.MaximumValue = Nothing
            Me.txtLinkedTable.MinimumValue = Nothing
            Me.txtLinkedTable.Name = "txtLinkedTable"
            Me.txtLinkedTable.OldValue = Nothing
            Me.txtLinkedTable.ReadOnly = True
            Me.txtLinkedTable.ValueIsMandatory = True
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            '
            'txtLinkedField
            '
            Me.txtLinkedField.BackColor = System.Drawing.Color.White
            Me.txtLinkedField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLinkedField.ComputedValue = False
            Me.txtLinkedField.CustomFormat = Nothing
            Me.txtLinkedField.DataBoundControl = True
            Me.txtLinkedField.EditingMode = True
            Me.txtLinkedField.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLinkedField, True)
            resources.ApplyResources(Me.txtLinkedField, "txtLinkedField")
            Me.txtLinkedField.ForeColor = System.Drawing.Color.Black
            Me.txtLinkedField.LinkedLabel = Nothing
            Me.txtLinkedField.MaximumValue = Nothing
            Me.txtLinkedField.MinimumValue = Nothing
            Me.txtLinkedField.Name = "txtLinkedField"
            Me.txtLinkedField.OldValue = Nothing
            Me.txtLinkedField.ReadOnly = True
            Me.txtLinkedField.ValueIsMandatory = True
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.Name = "CLabel3"
            '
            'txtDefaultValue
            '
            Me.txtDefaultValue.BackColor = System.Drawing.Color.White
            Me.txtDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDefaultValue.ComputedValue = False
            Me.txtDefaultValue.CustomFormat = Nothing
            Me.txtDefaultValue.DataBoundControl = True
            Me.txtDefaultValue.EditingMode = True
            Me.txtDefaultValue.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDefaultValue, True)
            resources.ApplyResources(Me.txtDefaultValue, "txtDefaultValue")
            Me.txtDefaultValue.ForeColor = System.Drawing.Color.Black
            Me.txtDefaultValue.LinkedLabel = Nothing
            Me.txtDefaultValue.MaximumValue = Nothing
            Me.txtDefaultValue.MinimumValue = Nothing
            Me.txtDefaultValue.Name = "txtDefaultValue"
            Me.txtDefaultValue.OldValue = Nothing
            Me.txtDefaultValue.ReadOnly = True
            Me.txtDefaultValue.ValueIsMandatory = True
            '
            'txtSystemViewNameAra
            '
            Me.txtSystemViewNameAra.BackColor = System.Drawing.Color.White
            Me.txtSystemViewNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSystemViewNameAra.ComputedValue = False
            Me.txtSystemViewNameAra.CustomFormat = Nothing
            Me.txtSystemViewNameAra.DataBoundControl = True
            Me.txtSystemViewNameAra.EditingMode = True
            Me.txtSystemViewNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSystemViewNameAra, True)
            resources.ApplyResources(Me.txtSystemViewNameAra, "txtSystemViewNameAra")
            Me.txtSystemViewNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSystemViewNameAra.LinkedLabel = Nothing
            Me.txtSystemViewNameAra.MaximumValue = Nothing
            Me.txtSystemViewNameAra.MinimumValue = Nothing
            Me.txtSystemViewNameAra.Name = "txtSystemViewNameAra"
            Me.txtSystemViewNameAra.OldValue = Nothing
            Me.txtSystemViewNameAra.ReadOnly = True
            Me.txtSystemViewNameAra.ValueIsMandatory = True
            '
            'txtSystemViewName
            '
            Me.txtSystemViewName.BackColor = System.Drawing.Color.White
            Me.txtSystemViewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSystemViewName.ComputedValue = False
            Me.txtSystemViewName.CustomFormat = Nothing
            Me.txtSystemViewName.DataBoundControl = True
            Me.txtSystemViewName.EditingMode = True
            Me.txtSystemViewName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSystemViewName, True)
            resources.ApplyResources(Me.txtSystemViewName, "txtSystemViewName")
            Me.txtSystemViewName.ForeColor = System.Drawing.Color.Black
            Me.txtSystemViewName.LinkedLabel = Nothing
            Me.txtSystemViewName.MaximumValue = Nothing
            Me.txtSystemViewName.MinimumValue = Nothing
            Me.txtSystemViewName.Name = "txtSystemViewName"
            Me.txtSystemViewName.OldValue = Nothing
            Me.txtSystemViewName.ReadOnly = True
            Me.txtSystemViewName.ValueIsMandatory = True
            '
            'DefaultFieldValueEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "DefaultFieldValueEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtFieldName As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblFieldName As CLabel
        Friend WithEvents lblSystemViewIdNo As CLabel
        Friend WithEvents lblDataType As CLabel
        Friend WithEvents lblLength As CLabel
        Friend WithEvents txtLength As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtLinkedTable As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtLinkedField As CTextBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents txtDefaultValue As CTextBox
        Friend WithEvents lblDecimalPart As CLabel
        Friend WithEvents txtDecimalPart As CTextBox
        Friend WithEvents cboDataType As CaComboBox
        Friend WithEvents cboSystemViewIdNo As CaComboBox
        Friend WithEvents txtSystemViewNameAra As CTextBox
        Friend WithEvents txtSystemViewName As CTextBox
    End Class
End NameSpace