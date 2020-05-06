Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Forms
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
        Me.txtTableName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDataType = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblFieldName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblTableName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDataType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblLength = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLength = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLinkedTable = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtLinkedField = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDefaultValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
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
            Me.floDataDisplay.SetFlowBreak(Me.txtFieldName, True)
            resources.ApplyResources(Me.txtFieldName, "txtFieldName")
            Me.txtFieldName.ForeColor = System.Drawing.Color.Black
            Me.txtFieldName.LinkedLabel = Nothing
            Me.txtFieldName.Name = "txtFieldName"
            Me.txtFieldName.OldValue = Nothing
            Me.txtFieldName.ReadOnly = True
            Me.txtFieldName.ValueIsMandatory = True
            '
            'txtTableName
            '
            Me.txtTableName.BackColor = System.Drawing.Color.White
            Me.txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTableName.ComputedValue = False
            Me.txtTableName.CustomFormat = Nothing
            Me.txtTableName.DataBoundControl = True
            Me.txtTableName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtTableName, True)
            resources.ApplyResources(Me.txtTableName, "txtTableName")
            Me.txtTableName.ForeColor = System.Drawing.Color.Black
            Me.txtTableName.LinkedLabel = Nothing
            Me.txtTableName.Name = "txtTableName"
            Me.txtTableName.OldValue = Nothing
            Me.txtTableName.ValueIsMandatory = True
            '
            'txtDataType
            '
            Me.txtDataType.BackColor = System.Drawing.Color.White
            Me.txtDataType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDataType.ComputedValue = False
            Me.txtDataType.CustomFormat = Nothing
            Me.txtDataType.DataBoundControl = True
            Me.txtDataType.EditingMode = False
            Me.txtDataType.EnglishControl = Me.txtTableName
            Me.floDataDisplay.SetFlowBreak(Me.txtDataType, True)
            resources.ApplyResources(Me.txtDataType, "txtDataType")
            Me.txtDataType.ForeColor = System.Drawing.Color.Black
            Me.txtDataType.LinkedLabel = Nothing
            Me.txtDataType.Name = "txtDataType"
            Me.txtDataType.OldValue = Nothing
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblTableName)
            Me.floDataDisplay.Controls.Add(Me.txtTableName)
            Me.floDataDisplay.Controls.Add(Me.lblFieldName)
            Me.floDataDisplay.Controls.Add(Me.txtFieldName)
            Me.floDataDisplay.Controls.Add(Me.lblDataType)
            Me.floDataDisplay.Controls.Add(Me.txtDataType)
            Me.floDataDisplay.Controls.Add(Me.lblLength)
            Me.floDataDisplay.Controls.Add(Me.txtLength)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblFieldName
            '
            Me.lblFieldName.DisplayOnly = True
            Me.lblFieldName.EditingMode = False
            resources.ApplyResources(Me.lblFieldName, "lblFieldName")
            Me.lblFieldName.Name = "lblFieldName"
            '
            'lblTableName
            '
            Me.lblTableName.DisplayOnly = True
            Me.lblTableName.EditingMode = False
            resources.ApplyResources(Me.lblTableName, "lblTableName")
            Me.lblTableName.Name = "lblTableName"
            '
            'lblDataType
            '
            Me.lblDataType.DisplayOnly = True
            Me.lblDataType.EditingMode = False
            resources.ApplyResources(Me.lblDataType, "lblDataType")
            Me.lblDataType.Name = "lblDataType"
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
            Me.floDataDisplay.SetFlowBreak(Me.txtLength, True)
            resources.ApplyResources(Me.txtLength, "txtLength")
            Me.txtLength.ForeColor = System.Drawing.Color.Black
            Me.txtLength.LinkedLabel = Nothing
            Me.txtLength.Name = "txtLength"
            Me.txtLength.OldValue = Nothing
            Me.txtLength.ReadOnly = True
            Me.txtLength.ValueIsMandatory = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.Name = "CLabel3"
            '
            'txtLinkedTable
            '
            Me.txtLinkedTable.BackColor = System.Drawing.Color.White
            Me.txtLinkedTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLinkedTable.ComputedValue = False
            Me.txtLinkedTable.CustomFormat = Nothing
            Me.txtLinkedTable.DataBoundControl = True
            Me.txtLinkedTable.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLinkedTable, True)
            resources.ApplyResources(Me.txtLinkedTable, "txtLinkedTable")
            Me.txtLinkedTable.ForeColor = System.Drawing.Color.Black
            Me.txtLinkedTable.LinkedLabel = Nothing
            Me.txtLinkedTable.Name = "txtLinkedTable"
            Me.txtLinkedTable.OldValue = Nothing
            Me.txtLinkedTable.ReadOnly = True
            Me.txtLinkedTable.ValueIsMandatory = True
            '
            'txtLinkedField
            '
            Me.txtLinkedField.BackColor = System.Drawing.Color.White
            Me.txtLinkedField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLinkedField.ComputedValue = False
            Me.txtLinkedField.CustomFormat = Nothing
            Me.txtLinkedField.DataBoundControl = True
            Me.txtLinkedField.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLinkedField, True)
            resources.ApplyResources(Me.txtLinkedField, "txtLinkedField")
            Me.txtLinkedField.ForeColor = System.Drawing.Color.Black
            Me.txtLinkedField.LinkedLabel = Nothing
            Me.txtLinkedField.Name = "txtLinkedField"
            Me.txtLinkedField.OldValue = Nothing
            Me.txtLinkedField.ReadOnly = True
            Me.txtLinkedField.ValueIsMandatory = True
            '
            'txtDefaultValue
            '
            Me.txtDefaultValue.BackColor = System.Drawing.Color.White
            Me.txtDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDefaultValue.ComputedValue = False
            Me.txtDefaultValue.CustomFormat = Nothing
            Me.txtDefaultValue.DataBoundControl = True
            Me.txtDefaultValue.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDefaultValue, True)
            resources.ApplyResources(Me.txtDefaultValue, "txtDefaultValue")
            Me.txtDefaultValue.ForeColor = System.Drawing.Color.Black
            Me.txtDefaultValue.LinkedLabel = Nothing
            Me.txtDefaultValue.Name = "txtDefaultValue"
            Me.txtDefaultValue.OldValue = Nothing
            Me.txtDefaultValue.ReadOnly = True
            Me.txtDefaultValue.ValueIsMandatory = True
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
        Friend WithEvents txtTableName As CTextBox
        Friend WithEvents txtDataType As CTextBoxArabic
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
    End Class
End NameSpace