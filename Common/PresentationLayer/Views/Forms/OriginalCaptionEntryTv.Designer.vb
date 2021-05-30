Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OriginalCaptionEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OriginalCaptionEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtLanguageIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtIdNoTranslated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
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
            'txtCaption
            '
            Me.txtCaption.BackColor = System.Drawing.Color.White
            Me.txtCaption.BegFindValue = Nothing
            Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCaption.ComputedValue = False
            Me.txtCaption.CustomFormat = Nothing
            Me.txtCaption.DataBoundControl = True
            Me.txtCaption.DisplayOnly = True
            Me.txtCaption.EditingMode = False
            Me.txtCaption.EndFindValue = Nothing
            Me.txtCaption.FieldDescription = Nothing
            Me.txtCaption.FieldName = Nothing
            Me.txtCaption.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCaption.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCaption, True)
            resources.ApplyResources(Me.txtCaption, "txtCaption")
            Me.txtCaption.ForeColor = System.Drawing.Color.Black
            Me.txtCaption.LinkedLabel = Nothing
            Me.txtCaption.MaximumValue = Nothing
            Me.txtCaption.MinimumValue = Nothing
            Me.txtCaption.Name = "txtCaption"
            Me.txtCaption.OldValue = Nothing
            Me.txtCaption.ReadOnly = True
            Me.txtCaption.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCaption.Translatable = False
            Me.txtCaption.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.Label1)
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCaption)
            Me.floDataDisplay.Controls.Add(Me.txtCaption)
            Me.floDataDisplay.Controls.Add(Me.lblTranslatedCaption)
            Me.floDataDisplay.Controls.Add(Me.txtTranslatedCaption)
            Me.floDataDisplay.Controls.Add(Me.txtLanguageIdNo)
            Me.floDataDisplay.Controls.Add(Me.txtIdNoTranslated)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'Label1
            '
            resources.ApplyResources(Me.Label1, "Label1")
            Me.Label1.Name = "Label1"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblCaption
            '
            Me.lblCaption.DisplayOnly = True
            Me.lblCaption.EditingMode = False
            resources.ApplyResources(Me.lblCaption, "lblCaption")
            Me.lblCaption.Name = "lblCaption"
            Me.lblCaption.Translatable = True
            '
            'lblTranslatedCaption
            '
            Me.lblTranslatedCaption.DisplayOnly = True
            Me.lblTranslatedCaption.EditingMode = False
            resources.ApplyResources(Me.lblTranslatedCaption, "lblTranslatedCaption")
            Me.lblTranslatedCaption.Name = "lblTranslatedCaption"
            Me.lblTranslatedCaption.Translatable = True
            '
            'txtTranslatedCaption
            '
            Me.txtTranslatedCaption.AutoFill = False
            Me.txtTranslatedCaption.BackColor = System.Drawing.Color.White
            Me.txtTranslatedCaption.BegFindValue = Nothing
            Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTranslatedCaption.ComputedValue = False
            Me.txtTranslatedCaption.CustomFormat = Nothing
            Me.txtTranslatedCaption.DataBoundControl = True
            Me.txtTranslatedCaption.EditingMode = False
            Me.txtTranslatedCaption.EndFindValue = Nothing
            Me.txtTranslatedCaption.EnglishControl = Me.txtCaption
            Me.txtTranslatedCaption.FieldDescription = Nothing
            Me.txtTranslatedCaption.FieldName = Nothing
            Me.txtTranslatedCaption.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTranslatedCaption.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, True)
            resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
            Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
            Me.txtTranslatedCaption.LinkedLabel = Me.lblTranslatedCaption
            Me.txtTranslatedCaption.MaximumValue = Nothing
            Me.txtTranslatedCaption.MinimumValue = Nothing
            Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
            Me.txtTranslatedCaption.OldValue = Nothing
            Me.txtTranslatedCaption.ReadOnly = True
            Me.txtTranslatedCaption.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTranslatedCaption.Translatable = False
            Me.txtTranslatedCaption.ValueIsMandatory = True
            '
            'txtLanguageIdNo
            '
            Me.txtLanguageIdNo.BackColor = System.Drawing.Color.White
            Me.txtLanguageIdNo.BegFindValue = Nothing
            Me.txtLanguageIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLanguageIdNo.ComputedValue = False
            Me.txtLanguageIdNo.CustomFormat = Nothing
            Me.txtLanguageIdNo.DataBoundControl = True
            Me.txtLanguageIdNo.DisplayOnly = True
            Me.txtLanguageIdNo.EditingMode = True
            resources.ApplyResources(Me.txtLanguageIdNo, "txtLanguageIdNo")
            Me.txtLanguageIdNo.EndFindValue = Nothing
            Me.txtLanguageIdNo.FieldDescription = Nothing
            Me.txtLanguageIdNo.FieldName = Nothing
            Me.txtLanguageIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLanguageIdNo.FindEnabled = True
            Me.txtLanguageIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtLanguageIdNo.LinkedLabel = Nothing
            Me.txtLanguageIdNo.MaximumValue = Nothing
            Me.txtLanguageIdNo.MinimumValue = Nothing
            Me.txtLanguageIdNo.Name = "txtLanguageIdNo"
            Me.txtLanguageIdNo.OldValue = Nothing
            Me.txtLanguageIdNo.ReadOnly = True
            Me.txtLanguageIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLanguageIdNo.TabStop = False
            Me.txtLanguageIdNo.Translatable = False
            '
            'txtIdNoTranslated
            '
            Me.txtIdNoTranslated.BackColor = System.Drawing.Color.White
            Me.txtIdNoTranslated.BegFindValue = Nothing
            Me.txtIdNoTranslated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNoTranslated.ComputedValue = False
            Me.txtIdNoTranslated.CustomFormat = Nothing
            Me.txtIdNoTranslated.DataBoundControl = True
            Me.txtIdNoTranslated.DisplayOnly = True
            Me.txtIdNoTranslated.EditingMode = True
            resources.ApplyResources(Me.txtIdNoTranslated, "txtIdNoTranslated")
            Me.txtIdNoTranslated.EndFindValue = Nothing
            Me.txtIdNoTranslated.FieldDescription = Nothing
            Me.txtIdNoTranslated.FieldName = Nothing
            Me.txtIdNoTranslated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNoTranslated.FindEnabled = True
            Me.txtIdNoTranslated.ForeColor = System.Drawing.Color.Black
            Me.txtIdNoTranslated.LinkedLabel = Nothing
            Me.txtIdNoTranslated.MaximumValue = Nothing
            Me.txtIdNoTranslated.MinimumValue = Nothing
            Me.txtIdNoTranslated.Name = "txtIdNoTranslated"
            Me.txtIdNoTranslated.OldValue = Nothing
            Me.txtIdNoTranslated.ReadOnly = True
            Me.txtIdNoTranslated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNoTranslated.TabStop = False
            Me.txtIdNoTranslated.Translatable = False
            '
            'OriginalCaptionEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "OriginalCaptionEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtCaption As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCaption As CLabel
        Friend WithEvents lblTranslatedCaption As CLabel
        Friend WithEvents txtLanguageIdNo As CTextBox
        Friend WithEvents txtIdNoTranslated As CTextBox
        Friend WithEvents txtTranslatedCaption As CTextBoxArabic
        Friend WithEvents Label1 As Label
    End Class
End NameSpace