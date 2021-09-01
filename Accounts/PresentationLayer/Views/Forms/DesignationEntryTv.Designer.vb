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
            Me.lblDesignationNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtDesignationCode
            '
            Me.txtDesignationCode.BackColor = System.Drawing.Color.White
            Me.txtDesignationCode.BegFindValue = Nothing
            Me.txtDesignationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDesignationCode.ComputedValue = False
            Me.txtDesignationCode.CustomFormat = Nothing
            Me.txtDesignationCode.DataBoundControl = True
            Me.txtDesignationCode.EditingMode = False
            Me.txtDesignationCode.EndFindValue = Nothing
            Me.txtDesignationCode.FieldDescription = Nothing
            Me.txtDesignationCode.FieldName = Nothing
            Me.txtDesignationCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDesignationCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDesignationCode, True)
            resources.ApplyResources(Me.txtDesignationCode, "txtDesignationCode")
            Me.txtDesignationCode.ForeColor = System.Drawing.Color.Black
            Me.txtDesignationCode.LinkedLabel = Nothing
            Me.txtDesignationCode.MaximumValue = Nothing
            Me.txtDesignationCode.MinimumValue = Nothing
            Me.txtDesignationCode.Name = "txtDesignationCode"
            Me.txtDesignationCode.OldValue = Nothing
            Me.txtDesignationCode.ReadOnly = True
            Me.txtDesignationCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDesignationCode.Translatable = False
            Me.txtDesignationCode.ValueIsMandatory = True
            '
            'txtDesignationName
            '
            Me.txtDesignationName.BackColor = System.Drawing.Color.White
            Me.txtDesignationName.BegFindValue = Nothing
            Me.txtDesignationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDesignationName.ComputedValue = False
            Me.txtDesignationName.CustomFormat = Nothing
            Me.txtDesignationName.DataBoundControl = True
            Me.txtDesignationName.EditingMode = False
            Me.txtDesignationName.EndFindValue = Nothing
            Me.txtDesignationName.FieldDescription = Nothing
            Me.txtDesignationName.FieldName = Nothing
            Me.txtDesignationName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDesignationName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDesignationName, True)
            resources.ApplyResources(Me.txtDesignationName, "txtDesignationName")
            Me.txtDesignationName.ForeColor = System.Drawing.Color.Black
            Me.txtDesignationName.LinkedLabel = Nothing
            Me.txtDesignationName.MaximumValue = Nothing
            Me.txtDesignationName.MinimumValue = Nothing
            Me.txtDesignationName.Name = "txtDesignationName"
            Me.txtDesignationName.OldValue = Nothing
            Me.txtDesignationName.ReadOnly = True
            Me.txtDesignationName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDesignationName.Translatable = False
            Me.txtDesignationName.ValueIsMandatory = True
            '
            'txtDesignationNameAra
            '
            Me.txtDesignationNameAra.BackColor = System.Drawing.Color.White
            Me.txtDesignationNameAra.BegFindValue = Nothing
            Me.txtDesignationNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDesignationNameAra.ComputedValue = False
            Me.txtDesignationNameAra.CustomFormat = Nothing
            Me.txtDesignationNameAra.DataBoundControl = True
            Me.txtDesignationNameAra.EditingMode = False
            Me.txtDesignationNameAra.EndFindValue = Nothing
            Me.txtDesignationNameAra.EnglishControl = Me.txtDesignationName
            Me.txtDesignationNameAra.FieldDescription = Nothing
            Me.txtDesignationNameAra.FieldName = Nothing
            Me.txtDesignationNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDesignationNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDesignationNameAra, True)
            resources.ApplyResources(Me.txtDesignationNameAra, "txtDesignationNameAra")
            Me.txtDesignationNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDesignationNameAra.LinkedLabel = Nothing
            Me.txtDesignationNameAra.MaximumValue = Nothing
            Me.txtDesignationNameAra.MinimumValue = Nothing
            Me.txtDesignationNameAra.Name = "txtDesignationNameAra"
            Me.txtDesignationNameAra.OldValue = Nothing
            Me.txtDesignationNameAra.ReadOnly = True
            Me.txtDesignationNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDesignationNameAra.Translatable = False
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
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
            Me.floDataDisplay.Controls.Add(Me.lblDesignationNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtDesignationNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblDesignationCode
            '
            Me.lblDesignationCode.DisplayOnly = True
            Me.lblDesignationCode.EditingMode = False
            resources.ApplyResources(Me.lblDesignationCode, "lblDesignationCode")
            Me.lblDesignationCode.Name = "lblDesignationCode"
            Me.lblDesignationCode.Translatable = True
            '
            'lblDesignationName
            '
            Me.lblDesignationName.DisplayOnly = True
            Me.lblDesignationName.EditingMode = False
            resources.ApplyResources(Me.lblDesignationName, "lblDesignationName")
            Me.lblDesignationName.Name = "lblDesignationName"
            Me.lblDesignationName.Translatable = True
            '
            'lblDesignationNameAra
            '
            Me.lblDesignationNameAra.DisplayOnly = True
            Me.lblDesignationNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDesignationNameAra, "lblDesignationNameAra")
            Me.lblDesignationNameAra.Name = "lblDesignationNameAra"
            Me.lblDesignationNameAra.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'DesignationEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "DesignationEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
    End Class
End Namespace