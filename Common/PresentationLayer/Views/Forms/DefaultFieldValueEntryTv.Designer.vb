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
        Me.lblTableName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboViewName = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.TabStop = false
        '
        'txtFieldName
        '
        Me.txtFieldName.BackColor = System.Drawing.Color.White
        Me.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFieldName.ComputedValue = false
        Me.txtFieldName.CustomFormat = Nothing
        Me.txtFieldName.DataBoundControl = true
        Me.txtFieldName.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtFieldName, true)
        resources.ApplyResources(Me.txtFieldName, "txtFieldName")
        Me.txtFieldName.ForeColor = System.Drawing.Color.Black
        Me.txtFieldName.LinkedLabel = Nothing
        Me.txtFieldName.MaximumValue = Nothing
        Me.txtFieldName.MinimumValue = Nothing
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.OldValue = Nothing
        Me.txtFieldName.ReadOnly = true
        Me.txtFieldName.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblTableName)
        Me.floDataDisplay.Controls.Add(Me.cboViewName)
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
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblTableName
        '
        Me.lblTableName.DisplayOnly = true
        Me.lblTableName.EditingMode = false
        resources.ApplyResources(Me.lblTableName, "lblTableName")
        Me.lblTableName.Name = "lblTableName"
            '
            'cboViewName
            '
            Me.cboViewName.AutoCompleteCustomSource.AddRange(New String() {resources.GetString("cboViewName.AutoCompleteCustomSource"), resources.GetString("cboViewName.AutoCompleteCustomSource1"), resources.GetString("cboViewName.AutoCompleteCustomSource2"), resources.GetString("cboViewName.AutoCompleteCustomSource3"), resources.GetString("cboViewName.AutoCompleteCustomSource4"), resources.GetString("cboViewName.AutoCompleteCustomSource5"), resources.GetString("cboViewName.AutoCompleteCustomSource6"), resources.GetString("cboViewName.AutoCompleteCustomSource7"), resources.GetString("cboViewName.AutoCompleteCustomSource8"), resources.GetString("cboViewName.AutoCompleteCustomSource9"), resources.GetString("cboViewName.AutoCompleteCustomSource10"), resources.GetString("cboViewName.AutoCompleteCustomSource11"), resources.GetString("cboViewName.AutoCompleteCustomSource12"), resources.GetString("cboViewName.AutoCompleteCustomSource13"), resources.GetString("cboViewName.AutoCompleteCustomSource14"), resources.GetString("cboViewName.AutoCompleteCustomSource15")})
            Me.cboViewName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.cboViewName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
            Me.cboViewName.BackColor = System.Drawing.Color.White
            Me.cboViewName.DefaultValue = Nothing
            Me.cboViewName.DisplayOnly = False
            Me.cboViewName.EditingMode = True
            resources.ApplyResources(Me.cboViewName, "cboViewName")
            Me.cboViewName.ForeColor = System.Drawing.Color.Black
            Me.cboViewName.FormattingEnabled = True
            Me.cboViewName.HideWhenNotEditingOrAdding = False
            Me.cboViewName.Items.AddRange(New Object() {resources.GetString("cboViewName.Items"), resources.GetString("cboViewName.Items1"), resources.GetString("cboViewName.Items2"), resources.GetString("cboViewName.Items3"), resources.GetString("cboViewName.Items4"), resources.GetString("cboViewName.Items5"), resources.GetString("cboViewName.Items6"), resources.GetString("cboViewName.Items7"), resources.GetString("cboViewName.Items8"), resources.GetString("cboViewName.Items9"), resources.GetString("cboViewName.Items10"), resources.GetString("cboViewName.Items11"), resources.GetString("cboViewName.Items12"), resources.GetString("cboViewName.Items13"), resources.GetString("cboViewName.Items14"), resources.GetString("cboViewName.Items15"), resources.GetString("cboViewName.Items16"), resources.GetString("cboViewName.Items17"), resources.GetString("cboViewName.Items18"), resources.GetString("cboViewName.Items19")})
            Me.cboViewName.LinkedLabel = Nothing
            Me.cboViewName.MaximumValue = Nothing
            Me.cboViewName.MinimumValue = Nothing
            Me.cboViewName.Name = "cboViewName"
            Me.cboViewName.OldValue = 0
            Me.cboViewName.OriginalDataSource = Nothing
        Me.cboViewName.OriginalDropDownStyle = 1
        Me.cboViewName.OriginalList = Nothing
        Me.cboViewName.PreviousSelectedIndex = -1
        Me.cboViewName.ReadOnlyCombo = false
        Me.cboViewName.ValueIsMandatory = false
        Me.cboViewName.ValueIsNullable = false
        Me.cboViewName.ValueIsNumeric = false
        '
        'lblFieldName
        '
        Me.lblFieldName.DisplayOnly = true
        Me.lblFieldName.EditingMode = false
        resources.ApplyResources(Me.lblFieldName, "lblFieldName")
        Me.lblFieldName.Name = "lblFieldName"
        '
        'lblDataType
        '
        Me.lblDataType.DisplayOnly = true
        Me.lblDataType.EditingMode = false
        resources.ApplyResources(Me.lblDataType, "lblDataType")
        Me.lblDataType.Name = "lblDataType"
        '
        'cboDataType
        '
        Me.cboDataType.BackColor = System.Drawing.Color.White
        Me.cboDataType.ChangingSearchValueOnly = false
        Me.cboDataType.CurrentSearchTerm = ""
        Me.cboDataType.DefaultValue = Nothing
        Me.cboDataType.DisplayMember = "Name"
        Me.cboDataType.DropDownHeight = 200
        Me.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataType.EditingMode = true
        Me.cboDataType.FilterRule = Nothing
        resources.ApplyResources(Me.cboDataType, "cboDataType")
        Me.cboDataType.ForeColor = System.Drawing.Color.Black
        Me.cboDataType.FormattingEnabled = true
        Me.cboDataType.HideWhenNotEditingOrAdding = false
        Me.cboDataType.LinkedLabel = Nothing
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.OldValue = 0
        Me.cboDataType.OriginalDataSource = Nothing
        Me.cboDataType.OriginalList = Nothing
        Me.cboDataType.OverrideDropDownStyleList = false
        Me.cboDataType.PreviousSearchTerm = Nothing
        Me.cboDataType.PreviousSelectedIndex = -1
        Me.cboDataType.PropertySelector = Nothing
        Me.cboDataType.ReadOnlyCombo = false
        Me.cboDataType.SearchAnywhere = false
        Me.cboDataType.SuggestBoxHeight = 200
        Me.cboDataType.SuggestListOrderRule = Nothing
        Me.cboDataType.TextToSearch = Nothing
        Me.cboDataType.ValueIsMandatory = false
        Me.cboDataType.ValueIsNullable = false
        Me.cboDataType.ValueIsNumeric = false
        Me.cboDataType.ValueMember = "IdNo"
        '
        'lblLength
        '
        Me.lblLength.DisplayOnly = true
        Me.lblLength.EditingMode = false
        resources.ApplyResources(Me.lblLength, "lblLength")
        Me.lblLength.Name = "lblLength"
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.Color.White
        Me.txtLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLength.ComputedValue = false
        Me.txtLength.CustomFormat = Nothing
        Me.txtLength.DataBoundControl = true
        Me.txtLength.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLength, true)
        resources.ApplyResources(Me.txtLength, "txtLength")
        Me.txtLength.ForeColor = System.Drawing.Color.Black
        Me.txtLength.LinkedLabel = Nothing
        Me.txtLength.MaximumValue = Nothing
        Me.txtLength.MinimumValue = Nothing
        Me.txtLength.Name = "txtLength"
        Me.txtLength.OldValue = Nothing
        Me.txtLength.ReadOnly = true
        Me.txtLength.ValueIsMandatory = true
        Me.txtLength.ValueIsNumeric = true
        '
        'lblDecimalPart
        '
        Me.lblDecimalPart.DisplayOnly = true
        Me.lblDecimalPart.EditingMode = false
        resources.ApplyResources(Me.lblDecimalPart, "lblDecimalPart")
        Me.lblDecimalPart.Name = "lblDecimalPart"
        '
        'txtDecimalPart
        '
        Me.txtDecimalPart.BackColor = System.Drawing.Color.White
        Me.txtDecimalPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDecimalPart.ComputedValue = false
        Me.txtDecimalPart.CustomFormat = Nothing
        Me.txtDecimalPart.DataBoundControl = true
        Me.txtDecimalPart.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDecimalPart, true)
        resources.ApplyResources(Me.txtDecimalPart, "txtDecimalPart")
        Me.txtDecimalPart.ForeColor = System.Drawing.Color.Black
        Me.txtDecimalPart.LinkedLabel = Nothing
        Me.txtDecimalPart.MaximumValue = Nothing
        Me.txtDecimalPart.MinimumValue = Nothing
        Me.txtDecimalPart.Name = "txtDecimalPart"
        Me.txtDecimalPart.OldValue = Nothing
        Me.txtDecimalPart.ReadOnly = true
        Me.txtDecimalPart.ValueIsMandatory = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'txtLinkedTable
        '
        Me.txtLinkedTable.BackColor = System.Drawing.Color.White
        Me.txtLinkedTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinkedTable.ComputedValue = false
        Me.txtLinkedTable.CustomFormat = Nothing
        Me.txtLinkedTable.DataBoundControl = true
        Me.txtLinkedTable.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLinkedTable, true)
        resources.ApplyResources(Me.txtLinkedTable, "txtLinkedTable")
        Me.txtLinkedTable.ForeColor = System.Drawing.Color.Black
        Me.txtLinkedTable.LinkedLabel = Nothing
        Me.txtLinkedTable.MaximumValue = Nothing
        Me.txtLinkedTable.MinimumValue = Nothing
        Me.txtLinkedTable.Name = "txtLinkedTable"
        Me.txtLinkedTable.OldValue = Nothing
        Me.txtLinkedTable.ReadOnly = true
        Me.txtLinkedTable.ValueIsMandatory = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        '
        'txtLinkedField
        '
        Me.txtLinkedField.BackColor = System.Drawing.Color.White
        Me.txtLinkedField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinkedField.ComputedValue = false
        Me.txtLinkedField.CustomFormat = Nothing
        Me.txtLinkedField.DataBoundControl = true
        Me.txtLinkedField.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLinkedField, true)
        resources.ApplyResources(Me.txtLinkedField, "txtLinkedField")
        Me.txtLinkedField.ForeColor = System.Drawing.Color.Black
        Me.txtLinkedField.LinkedLabel = Nothing
        Me.txtLinkedField.MaximumValue = Nothing
        Me.txtLinkedField.MinimumValue = Nothing
        Me.txtLinkedField.Name = "txtLinkedField"
        Me.txtLinkedField.OldValue = Nothing
        Me.txtLinkedField.ReadOnly = true
        Me.txtLinkedField.ValueIsMandatory = true
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.Name = "CLabel3"
        '
        'txtDefaultValue
        '
        Me.txtDefaultValue.BackColor = System.Drawing.Color.White
        Me.txtDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDefaultValue.ComputedValue = false
        Me.txtDefaultValue.CustomFormat = Nothing
        Me.txtDefaultValue.DataBoundControl = true
        Me.txtDefaultValue.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDefaultValue, true)
        resources.ApplyResources(Me.txtDefaultValue, "txtDefaultValue")
        Me.txtDefaultValue.ForeColor = System.Drawing.Color.Black
        Me.txtDefaultValue.LinkedLabel = Nothing
        Me.txtDefaultValue.MaximumValue = Nothing
        Me.txtDefaultValue.MinimumValue = Nothing
        Me.txtDefaultValue.Name = "txtDefaultValue"
        Me.txtDefaultValue.OldValue = Nothing
        Me.txtDefaultValue.ReadOnly = true
        Me.txtDefaultValue.ValueIsMandatory = true
        '
        'DefaultFieldValueEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "DefaultFieldValueEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtFieldName As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblFieldName As CLabel
        Friend WithEvents lblTableName As CLabel
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
        Friend WithEvents cboViewName As CComboBox
    End Class
End NameSpace