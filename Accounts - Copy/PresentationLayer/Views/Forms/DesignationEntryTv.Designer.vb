Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DesignationEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignationEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDesignationCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDesignationName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDesignationNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDesignationCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDesignationName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDesignationNameFemale = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDesignationNameFemale = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDesignationNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDesignationNameFemaleAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDesignationNameFemaleAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtDesignationCode
        '
        Me.txtDesignationCode.BackColor = System.Drawing.Color.White
        Me.txtDesignationCode.BegFindValue = Nothing
        Me.txtDesignationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationCode.ComputedValue = false
        Me.txtDesignationCode.CustomFormat = Nothing
        Me.txtDesignationCode.DataBoundControl = true
        Me.txtDesignationCode.EditingMode = false
        Me.txtDesignationCode.EndFindValue = Nothing
        Me.txtDesignationCode.FieldDescription = Nothing
        Me.txtDesignationCode.FieldName = Nothing
        Me.txtDesignationCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDesignationCode.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationCode, true)
        resources.ApplyResources(Me.txtDesignationCode, "txtDesignationCode")
        Me.txtDesignationCode.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationCode.LinkedLabel = Me.lblDesignationCode
        Me.txtDesignationCode.MaximumValue = Nothing
        Me.txtDesignationCode.MinimumValue = Nothing
        Me.txtDesignationCode.Name = "txtDesignationCode"
        Me.txtDesignationCode.OldValue = Nothing
        Me.txtDesignationCode.ReadOnly = true
        Me.txtDesignationCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDesignationCode.Translatable = false
        Me.txtDesignationCode.ValueIsMandatory = true
        '
        'txtDesignationName
        '
        Me.txtDesignationName.BackColor = System.Drawing.Color.White
        Me.txtDesignationName.BegFindValue = Nothing
        Me.txtDesignationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationName.ComputedValue = false
        Me.txtDesignationName.CustomFormat = Nothing
        Me.txtDesignationName.DataBoundControl = true
        Me.txtDesignationName.EditingMode = false
        Me.txtDesignationName.EndFindValue = Nothing
        Me.txtDesignationName.FieldDescription = Nothing
        Me.txtDesignationName.FieldName = Nothing
        Me.txtDesignationName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDesignationName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationName, true)
        resources.ApplyResources(Me.txtDesignationName, "txtDesignationName")
        Me.txtDesignationName.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationName.LinkedLabel = Me.lblDesignationCode
        Me.txtDesignationName.MaximumValue = Nothing
        Me.txtDesignationName.MinimumValue = Nothing
        Me.txtDesignationName.Name = "txtDesignationName"
        Me.txtDesignationName.OldValue = Nothing
        Me.txtDesignationName.ReadOnly = true
        Me.txtDesignationName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDesignationName.Translatable = false
        Me.txtDesignationName.ValueIsMandatory = true
        '
        'txtDesignationNameAra
        '
        Me.txtDesignationNameAra.BackColor = System.Drawing.Color.White
        Me.txtDesignationNameAra.BegFindValue = Nothing
        Me.txtDesignationNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationNameAra.ComputedValue = false
        Me.txtDesignationNameAra.CustomFormat = Nothing
        Me.txtDesignationNameAra.DataBoundControl = true
        Me.txtDesignationNameAra.EditingMode = false
        Me.txtDesignationNameAra.EndFindValue = Nothing
        Me.txtDesignationNameAra.EnglishControl = Me.txtDesignationName
        Me.txtDesignationNameAra.FieldDescription = Nothing
        Me.txtDesignationNameAra.FieldName = Nothing
        Me.txtDesignationNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDesignationNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationNameAra, true)
        resources.ApplyResources(Me.txtDesignationNameAra, "txtDesignationNameAra")
        Me.txtDesignationNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationNameAra.LinkedLabel = Me.lblDesignationNameAra
        Me.txtDesignationNameAra.MaximumValue = Nothing
        Me.txtDesignationNameAra.MinimumValue = Nothing
        Me.txtDesignationNameAra.Name = "txtDesignationNameAra"
        Me.txtDesignationNameAra.OldValue = Nothing
        Me.txtDesignationNameAra.ReadOnly = true
        Me.txtDesignationNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDesignationNameAra.Translatable = false
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Me.lblNotes
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblDesignationCode)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationCode)
        Me.floDataDisplay.Controls.Add(Me.lblDesignationName)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationName)
        Me.floDataDisplay.Controls.Add(Me.lblDesignationNameFemale)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationNameFemale)
        Me.floDataDisplay.Controls.Add(Me.lblDesignationNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblDesignationNameFemaleAra)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationNameFemaleAra)
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
        Me.lblIdNo.Translatable = true
        '
        'lblDesignationCode
        '
        Me.lblDesignationCode.DisplayOnly = true
        Me.lblDesignationCode.EditingMode = false
        resources.ApplyResources(Me.lblDesignationCode, "lblDesignationCode")
        Me.lblDesignationCode.Name = "lblDesignationCode"
        Me.lblDesignationCode.Translatable = true
        '
        'lblDesignationName
        '
        Me.lblDesignationName.DisplayOnly = true
        Me.lblDesignationName.EditingMode = false
        resources.ApplyResources(Me.lblDesignationName, "lblDesignationName")
        Me.lblDesignationName.Name = "lblDesignationName"
        Me.lblDesignationName.Translatable = true
        '
        'lblDesignationNameFemale
        '
        Me.lblDesignationNameFemale.DisplayOnly = true
        Me.lblDesignationNameFemale.EditingMode = false
        resources.ApplyResources(Me.lblDesignationNameFemale, "lblDesignationNameFemale")
        Me.lblDesignationNameFemale.Name = "lblDesignationNameFemale"
        Me.lblDesignationNameFemale.Translatable = true
        '
        'txtDesignationNameFemale
        '
        Me.txtDesignationNameFemale.BackColor = System.Drawing.Color.White
        Me.txtDesignationNameFemale.BegFindValue = Nothing
        Me.txtDesignationNameFemale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationNameFemale.ComputedValue = false
        Me.txtDesignationNameFemale.CustomFormat = Nothing
        Me.txtDesignationNameFemale.DataBoundControl = true
        Me.txtDesignationNameFemale.EditingMode = false
        Me.txtDesignationNameFemale.EndFindValue = Nothing
        Me.txtDesignationNameFemale.FieldDescription = Nothing
        Me.txtDesignationNameFemale.FieldName = Nothing
        Me.txtDesignationNameFemale.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDesignationNameFemale.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationNameFemale, true)
        resources.ApplyResources(Me.txtDesignationNameFemale, "txtDesignationNameFemale")
        Me.txtDesignationNameFemale.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationNameFemale.LinkedLabel = Me.lblDesignationNameFemale
        Me.txtDesignationNameFemale.MaximumValue = Nothing
        Me.txtDesignationNameFemale.MinimumValue = Nothing
        Me.txtDesignationNameFemale.Name = "txtDesignationNameFemale"
        Me.txtDesignationNameFemale.OldValue = Nothing
        Me.txtDesignationNameFemale.ReadOnly = true
        Me.txtDesignationNameFemale.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDesignationNameFemale.Translatable = false
        Me.txtDesignationNameFemale.ValueIsMandatory = true
        '
        'lblDesignationNameAra
        '
        Me.lblDesignationNameAra.DisplayOnly = true
        Me.lblDesignationNameAra.EditingMode = false
        resources.ApplyResources(Me.lblDesignationNameAra, "lblDesignationNameAra")
        Me.lblDesignationNameAra.Name = "lblDesignationNameAra"
        Me.lblDesignationNameAra.Translatable = true
        '
        'lblDesignationNameFemaleAra
        '
        Me.lblDesignationNameFemaleAra.DisplayOnly = true
        Me.lblDesignationNameFemaleAra.EditingMode = false
        resources.ApplyResources(Me.lblDesignationNameFemaleAra, "lblDesignationNameFemaleAra")
        Me.lblDesignationNameFemaleAra.Name = "lblDesignationNameFemaleAra"
        Me.lblDesignationNameFemaleAra.Translatable = true
        '
        'txtDesignationNameFemaleAra
        '
        Me.txtDesignationNameFemaleAra.BackColor = System.Drawing.Color.White
        Me.txtDesignationNameFemaleAra.BegFindValue = Nothing
        Me.txtDesignationNameFemaleAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationNameFemaleAra.ComputedValue = false
        Me.txtDesignationNameFemaleAra.CustomFormat = Nothing
        Me.txtDesignationNameFemaleAra.DataBoundControl = true
        Me.txtDesignationNameFemaleAra.EditingMode = false
        Me.txtDesignationNameFemaleAra.EndFindValue = Nothing
        Me.txtDesignationNameFemaleAra.EnglishControl = Me.txtDesignationNameFemale
        Me.txtDesignationNameFemaleAra.FieldDescription = Nothing
        Me.txtDesignationNameFemaleAra.FieldName = Nothing
        Me.txtDesignationNameFemaleAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDesignationNameFemaleAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationNameFemaleAra, true)
        resources.ApplyResources(Me.txtDesignationNameFemaleAra, "txtDesignationNameFemaleAra")
        Me.txtDesignationNameFemaleAra.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationNameFemaleAra.LinkedLabel = Me.lblDesignationNameFemaleAra
        Me.txtDesignationNameFemaleAra.MaximumValue = Nothing
        Me.txtDesignationNameFemaleAra.MinimumValue = Nothing
        Me.txtDesignationNameFemaleAra.Name = "txtDesignationNameFemaleAra"
        Me.txtDesignationNameFemaleAra.OldValue = Nothing
        Me.txtDesignationNameFemaleAra.ReadOnly = true
        Me.txtDesignationNameFemaleAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDesignationNameFemaleAra.Translatable = false
        Me.txtDesignationNameFemaleAra.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'DesignationEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "DesignationEntryTv"
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
        Friend WithEvents txtDesignationCode As CTextBox
        Friend WithEvents txtDesignationName As CTextBox
        Friend WithEvents txtDesignationNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblDesignationCode As CLabel
        Friend WithEvents lblDesignationName As CLabel
        Friend WithEvents lblDesignationNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblDesignationNameFemale As CLabel
        Friend WithEvents txtDesignationNameFemale As CTextBox
        Friend WithEvents lblDesignationNameFemaleAra As CLabel
        Friend WithEvents txtDesignationNameFemaleAra As CTextBoxArabic
    End Class
End Namespace