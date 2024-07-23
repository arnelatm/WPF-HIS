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
        Me.cboSystemViewIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.lblFieldName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDataType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDataType = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
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
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.FormTreeView, "FormTreeView")
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        '
        'txtFieldName
        '
        Me.txtFieldName.BackColor = System.Drawing.Color.White
        Me.txtFieldName.BegFindValue = Nothing
        Me.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFieldName.ComputedValue = false
        Me.txtFieldName.CustomFormat = Nothing
        Me.txtFieldName.DataBoundControl = true
        Me.txtFieldName.EditingMode = true
        Me.txtFieldName.EndFindValue = Nothing
        Me.txtFieldName.FieldDescription = Nothing
        Me.txtFieldName.FieldName = Nothing
        Me.txtFieldName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtFieldName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtFieldName, true)
        resources.ApplyResources(Me.txtFieldName, "txtFieldName")
        Me.txtFieldName.ForeColor = System.Drawing.Color.Black
        Me.txtFieldName.LinkedLabel = Nothing
        Me.txtFieldName.MaximumValue = Nothing
        Me.txtFieldName.MinimumValue = Nothing
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.OldValue = Nothing
        Me.txtFieldName.ReadOnly = true
        Me.txtFieldName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtFieldName.Translatable = false
        Me.txtFieldName.ValueIsMandatory = true
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'lblSystemViewIdNo
        '
        Me.lblSystemViewIdNo.DisplayOnly = true
        Me.lblSystemViewIdNo.EditingMode = false
        resources.ApplyResources(Me.lblSystemViewIdNo, "lblSystemViewIdNo")
        Me.lblSystemViewIdNo.Name = "lblSystemViewIdNo"
        Me.lblSystemViewIdNo.Translatable = true
        '
        'cboSystemViewIdNo
        '
        Me.cboSystemViewIdNo.BackColor = System.Drawing.Color.White
        Me.cboSystemViewIdNo.BegFindValue = Nothing
        Me.cboSystemViewIdNo.ChangingSearchValueOnly = false
        Me.cboSystemViewIdNo.CurrentSearchTerm = ""
        Me.cboSystemViewIdNo.DefaultValue = Nothing
        Me.cboSystemViewIdNo.DisplayMember = "Name"
        Me.cboSystemViewIdNo.EditingMode = true
        Me.cboSystemViewIdNo.EndFindValue = Nothing
        Me.cboSystemViewIdNo.FieldDescription = Nothing
        Me.cboSystemViewIdNo.FieldName = Nothing
        Me.cboSystemViewIdNo.FilterRule = Nothing
        Me.cboSystemViewIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboSystemViewIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboSystemViewIdNo, "cboSystemViewIdNo")
        Me.cboSystemViewIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSystemViewIdNo.FormattingEnabled = true
        Me.cboSystemViewIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSystemViewIdNo.IgnoreCase = false
        Me.cboSystemViewIdNo.LinkedLabel = Nothing
        Me.cboSystemViewIdNo.Name = "cboSystemViewIdNo"
        Me.cboSystemViewIdNo.OldValue = 0
        Me.cboSystemViewIdNo.OriginalDataSource = Nothing
        Me.cboSystemViewIdNo.OriginalList = Nothing
        Me.cboSystemViewIdNo.OverrideDropDownStyleList = false
        Me.cboSystemViewIdNo.PreviousSearchTerm = Nothing
        Me.cboSystemViewIdNo.PropertySelector = Nothing
            Me.cboSystemViewIdNo.SuggestBoxHeight = 200
            Me.cboSystemViewIdNo.SuggestListOrderRule = Nothing
        Me.cboSystemViewIdNo.TextToSearch = Nothing
        Me.cboSystemViewIdNo.Translatable = false
        Me.cboSystemViewIdNo.ValueIsMandatory = false
        Me.cboSystemViewIdNo.ValueIsNullable = false
        Me.cboSystemViewIdNo.ValueIsNumeric = false
        Me.cboSystemViewIdNo.ValueMember = "IdNo"
        '
        'lblFieldName
        '
        Me.lblFieldName.DisplayOnly = true
        Me.lblFieldName.EditingMode = false
        resources.ApplyResources(Me.lblFieldName, "lblFieldName")
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Translatable = true
        '
        'lblDataType
        '
        Me.lblDataType.DisplayOnly = true
        Me.lblDataType.EditingMode = false
        resources.ApplyResources(Me.lblDataType, "lblDataType")
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Translatable = true
        '
        'cboDataType
        '
        Me.cboDataType.BackColor = System.Drawing.Color.White
        Me.cboDataType.BegFindValue = Nothing
        Me.cboDataType.ChangingSearchValueOnly = false
        Me.cboDataType.CurrentSearchTerm = ""
        Me.cboDataType.DefaultValue = Nothing
        Me.cboDataType.DisplayMember = "Name"
        Me.cboDataType.EditingMode = true
        Me.cboDataType.EndFindValue = Nothing
        Me.cboDataType.FieldDescription = Nothing
        Me.cboDataType.FieldName = Nothing
        Me.cboDataType.FilterRule = Nothing
        Me.cboDataType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDataType.FindEnabled = false
        resources.ApplyResources(Me.cboDataType, "cboDataType")
        Me.cboDataType.ForeColor = System.Drawing.Color.Black
        Me.cboDataType.FormattingEnabled = true
        Me.cboDataType.HideWhenNotEditingOrAdding = false
        Me.cboDataType.IgnoreCase = false
        Me.cboDataType.LinkedLabel = Nothing
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.OldValue = 0
        Me.cboDataType.OriginalDataSource = Nothing
        Me.cboDataType.OriginalList = Nothing
        Me.cboDataType.OverrideDropDownStyleList = false
        Me.cboDataType.PreviousSearchTerm = Nothing
        Me.cboDataType.PropertySelector = Nothing
            Me.cboDataType.SuggestBoxHeight = 200
            Me.cboDataType.SuggestListOrderRule = Nothing
        Me.cboDataType.TextToSearch = Nothing
        Me.cboDataType.Translatable = false
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
        Me.lblLength.Translatable = true
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.Color.White
        Me.txtLength.BegFindValue = Nothing
        Me.txtLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLength.ComputedValue = false
        Me.txtLength.CustomFormat = Nothing
        Me.txtLength.DataBoundControl = true
        Me.txtLength.EditingMode = true
        Me.txtLength.EndFindValue = Nothing
        Me.txtLength.FieldDescription = Nothing
        Me.txtLength.FieldName = Nothing
        Me.txtLength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLength.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLength, true)
        resources.ApplyResources(Me.txtLength, "txtLength")
        Me.txtLength.ForeColor = System.Drawing.Color.Black
        Me.txtLength.LinkedLabel = Nothing
        Me.txtLength.MaximumValue = Nothing
        Me.txtLength.MinimumValue = Nothing
        Me.txtLength.Name = "txtLength"
        Me.txtLength.OldValue = Nothing
        Me.txtLength.ReadOnly = true
        Me.txtLength.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLength.Translatable = false
        Me.txtLength.ValueIsMandatory = true
        Me.txtLength.ValueIsNumeric = true
        '
        'lblDecimalPart
        '
        Me.lblDecimalPart.DisplayOnly = true
        Me.lblDecimalPart.EditingMode = false
        resources.ApplyResources(Me.lblDecimalPart, "lblDecimalPart")
        Me.lblDecimalPart.Name = "lblDecimalPart"
        Me.lblDecimalPart.Translatable = true
        '
        'txtDecimalPart
        '
        Me.txtDecimalPart.BackColor = System.Drawing.Color.White
        Me.txtDecimalPart.BegFindValue = Nothing
        Me.txtDecimalPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDecimalPart.ComputedValue = false
        Me.txtDecimalPart.CustomFormat = Nothing
        Me.txtDecimalPart.DataBoundControl = true
        Me.txtDecimalPart.EditingMode = true
        Me.txtDecimalPart.EndFindValue = Nothing
        Me.txtDecimalPart.FieldDescription = Nothing
        Me.txtDecimalPart.FieldName = Nothing
        Me.txtDecimalPart.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDecimalPart.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDecimalPart, true)
        resources.ApplyResources(Me.txtDecimalPart, "txtDecimalPart")
        Me.txtDecimalPart.ForeColor = System.Drawing.Color.Black
        Me.txtDecimalPart.LinkedLabel = Nothing
        Me.txtDecimalPart.MaximumValue = Nothing
        Me.txtDecimalPart.MinimumValue = Nothing
        Me.txtDecimalPart.Name = "txtDecimalPart"
        Me.txtDecimalPart.OldValue = Nothing
        Me.txtDecimalPart.ReadOnly = true
        Me.txtDecimalPart.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDecimalPart.Translatable = false
        Me.txtDecimalPart.ValueIsMandatory = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Translatable = true
        '
        'txtLinkedTable
        '
        Me.txtLinkedTable.BackColor = System.Drawing.Color.White
        Me.txtLinkedTable.BegFindValue = Nothing
        Me.txtLinkedTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinkedTable.ComputedValue = false
        Me.txtLinkedTable.CustomFormat = Nothing
        Me.txtLinkedTable.DataBoundControl = true
        Me.txtLinkedTable.EditingMode = true
        Me.txtLinkedTable.EndFindValue = Nothing
        Me.txtLinkedTable.FieldDescription = Nothing
        Me.txtLinkedTable.FieldName = Nothing
        Me.txtLinkedTable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLinkedTable.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLinkedTable, true)
        resources.ApplyResources(Me.txtLinkedTable, "txtLinkedTable")
        Me.txtLinkedTable.ForeColor = System.Drawing.Color.Black
        Me.txtLinkedTable.LinkedLabel = Nothing
        Me.txtLinkedTable.MaximumValue = Nothing
        Me.txtLinkedTable.MinimumValue = Nothing
        Me.txtLinkedTable.Name = "txtLinkedTable"
        Me.txtLinkedTable.OldValue = Nothing
        Me.txtLinkedTable.ReadOnly = true
        Me.txtLinkedTable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLinkedTable.Translatable = false
        Me.txtLinkedTable.ValueIsMandatory = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Translatable = true
        '
        'txtLinkedField
        '
        Me.txtLinkedField.BackColor = System.Drawing.Color.White
        Me.txtLinkedField.BegFindValue = Nothing
        Me.txtLinkedField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinkedField.ComputedValue = false
        Me.txtLinkedField.CustomFormat = Nothing
        Me.txtLinkedField.DataBoundControl = true
        Me.txtLinkedField.EditingMode = true
        Me.txtLinkedField.EndFindValue = Nothing
        Me.txtLinkedField.FieldDescription = Nothing
        Me.txtLinkedField.FieldName = Nothing
        Me.txtLinkedField.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLinkedField.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLinkedField, true)
        resources.ApplyResources(Me.txtLinkedField, "txtLinkedField")
        Me.txtLinkedField.ForeColor = System.Drawing.Color.Black
        Me.txtLinkedField.LinkedLabel = Nothing
        Me.txtLinkedField.MaximumValue = Nothing
        Me.txtLinkedField.MinimumValue = Nothing
        Me.txtLinkedField.Name = "txtLinkedField"
        Me.txtLinkedField.OldValue = Nothing
        Me.txtLinkedField.ReadOnly = true
        Me.txtLinkedField.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLinkedField.Translatable = false
        Me.txtLinkedField.ValueIsMandatory = true
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Translatable = true
        '
        'txtDefaultValue
        '
        Me.txtDefaultValue.BackColor = System.Drawing.Color.White
        Me.txtDefaultValue.BegFindValue = Nothing
        Me.txtDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDefaultValue.ComputedValue = false
        Me.txtDefaultValue.CustomFormat = Nothing
        Me.txtDefaultValue.DataBoundControl = true
        Me.txtDefaultValue.EditingMode = true
        Me.txtDefaultValue.EndFindValue = Nothing
        Me.txtDefaultValue.FieldDescription = Nothing
        Me.txtDefaultValue.FieldName = Nothing
        Me.txtDefaultValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDefaultValue.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDefaultValue, true)
        resources.ApplyResources(Me.txtDefaultValue, "txtDefaultValue")
        Me.txtDefaultValue.ForeColor = System.Drawing.Color.Black
        Me.txtDefaultValue.LinkedLabel = Nothing
        Me.txtDefaultValue.MaximumValue = Nothing
        Me.txtDefaultValue.MinimumValue = Nothing
        Me.txtDefaultValue.Name = "txtDefaultValue"
        Me.txtDefaultValue.OldValue = Nothing
        Me.txtDefaultValue.ReadOnly = true
        Me.txtDefaultValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDefaultValue.Translatable = false
        Me.txtDefaultValue.ValueIsMandatory = true
        '
        'txtSystemViewNameAra
        '
        Me.txtSystemViewNameAra.BackColor = System.Drawing.Color.White
        Me.txtSystemViewNameAra.BegFindValue = Nothing
        Me.txtSystemViewNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSystemViewNameAra.ComputedValue = false
        Me.txtSystemViewNameAra.CustomFormat = Nothing
        Me.txtSystemViewNameAra.DataBoundControl = true
        Me.txtSystemViewNameAra.EditingMode = true
        Me.txtSystemViewNameAra.EndFindValue = Nothing
        Me.txtSystemViewNameAra.FieldDescription = Nothing
        Me.txtSystemViewNameAra.FieldName = Nothing
        Me.txtSystemViewNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSystemViewNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSystemViewNameAra, true)
        resources.ApplyResources(Me.txtSystemViewNameAra, "txtSystemViewNameAra")
        Me.txtSystemViewNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSystemViewNameAra.LinkedLabel = Nothing
        Me.txtSystemViewNameAra.MaximumValue = Nothing
        Me.txtSystemViewNameAra.MinimumValue = Nothing
        Me.txtSystemViewNameAra.Name = "txtSystemViewNameAra"
        Me.txtSystemViewNameAra.OldValue = Nothing
        Me.txtSystemViewNameAra.ReadOnly = true
        Me.txtSystemViewNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSystemViewNameAra.Translatable = false
        Me.txtSystemViewNameAra.ValueIsMandatory = true
        '
        'txtSystemViewName
        '
        Me.txtSystemViewName.BackColor = System.Drawing.Color.White
        Me.txtSystemViewName.BegFindValue = Nothing
        Me.txtSystemViewName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSystemViewName.ComputedValue = false
        Me.txtSystemViewName.CustomFormat = Nothing
        Me.txtSystemViewName.DataBoundControl = true
        Me.txtSystemViewName.EditingMode = true
        Me.txtSystemViewName.EndFindValue = Nothing
        Me.txtSystemViewName.FieldDescription = Nothing
        Me.txtSystemViewName.FieldName = Nothing
        Me.txtSystemViewName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSystemViewName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSystemViewName, true)
        resources.ApplyResources(Me.txtSystemViewName, "txtSystemViewName")
        Me.txtSystemViewName.ForeColor = System.Drawing.Color.Black
        Me.txtSystemViewName.LinkedLabel = Nothing
        Me.txtSystemViewName.MaximumValue = Nothing
        Me.txtSystemViewName.MinimumValue = Nothing
        Me.txtSystemViewName.Name = "txtSystemViewName"
        Me.txtSystemViewName.OldValue = Nothing
        Me.txtSystemViewName.ReadOnly = true
        Me.txtSystemViewName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSystemViewName.Translatable = false
        Me.txtSystemViewName.ValueIsMandatory = true
        '
        'DefaultFieldValueEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "DefaultFieldValueEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
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
        Friend WithEvents cboDataType As AtmComboBox
        Friend WithEvents cboSystemViewIdNo As AtmComboBox
        Friend WithEvents txtSystemViewNameAra As CTextBox
        Friend WithEvents txtSystemViewName As CTextBox
    End Class
End NameSpace