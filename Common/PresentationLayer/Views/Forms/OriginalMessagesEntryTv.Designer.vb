Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class OriginalMessagesEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OriginalMessagesEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtMessageKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblMessageKey = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMessage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblMessage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblTranslatedMessage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTranslatedMessage = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            'txtMessageKey
            '
            Me.txtMessageKey.BackColor = System.Drawing.Color.White
            Me.txtMessageKey.BegFindValue = Nothing
            Me.txtMessageKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMessageKey.ComputedValue = False
            Me.txtMessageKey.CustomFormat = Nothing
            Me.txtMessageKey.DataBoundControl = True
            Me.txtMessageKey.DisplayOnly = True
            Me.txtMessageKey.EditingMode = False
            Me.txtMessageKey.EndFindValue = Nothing
            Me.txtMessageKey.FieldDescription = Nothing
            Me.txtMessageKey.FieldName = Nothing
            Me.txtMessageKey.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMessageKey.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtMessageKey, True)
            resources.ApplyResources(Me.txtMessageKey, "txtMessageKey")
            Me.txtMessageKey.ForeColor = System.Drawing.Color.Black
            Me.txtMessageKey.LinkedLabel = Me.lblMessageKey
            Me.txtMessageKey.MaximumValue = Nothing
            Me.txtMessageKey.MinimumValue = Nothing
            Me.txtMessageKey.Name = "txtMessageKey"
            Me.txtMessageKey.OldValue = Nothing
            Me.txtMessageKey.ReadOnly = True
            Me.txtMessageKey.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMessageKey.TabStop = False
            Me.txtMessageKey.Translatable = False
            Me.txtMessageKey.ValueIsMandatory = True
            '
            'lblMessageKey
            '
            Me.lblMessageKey.DisplayOnly = True
            Me.lblMessageKey.EditingMode = False
            resources.ApplyResources(Me.lblMessageKey, "lblMessageKey")
            Me.lblMessageKey.Name = "lblMessageKey"
            Me.lblMessageKey.Translatable = True
            '
            'txtMessage
            '
            Me.txtMessage.BackColor = System.Drawing.Color.White
            Me.txtMessage.BegFindValue = Nothing
            Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMessage.ComputedValue = False
            Me.txtMessage.CustomFormat = Nothing
            Me.txtMessage.DataBoundControl = True
            Me.txtMessage.DisplayOnly = True
            Me.txtMessage.EditingMode = False
            Me.txtMessage.EndFindValue = Nothing
            Me.txtMessage.FieldDescription = Nothing
            Me.txtMessage.FieldName = Nothing
            Me.txtMessage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMessage.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtMessage, True)
            resources.ApplyResources(Me.txtMessage, "txtMessage")
            Me.txtMessage.ForeColor = System.Drawing.Color.Black
            Me.txtMessage.LinkedLabel = Nothing
            Me.txtMessage.MaximumValue = Nothing
            Me.txtMessage.MinimumValue = Nothing
            Me.txtMessage.Name = "txtMessage"
            Me.txtMessage.OldValue = Nothing
            Me.txtMessage.ReadOnly = True
            Me.txtMessage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMessage.Translatable = False
            Me.txtMessage.ValueIsMandatory = True
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
            Me.floDataDisplay.Controls.Add(Me.lblMessageKey)
            Me.floDataDisplay.Controls.Add(Me.txtMessageKey)
            Me.floDataDisplay.Controls.Add(Me.lblMessage)
            Me.floDataDisplay.Controls.Add(Me.txtMessage)
            Me.floDataDisplay.Controls.Add(Me.lblTranslatedMessage)
            Me.floDataDisplay.Controls.Add(Me.txtTranslatedMessage)
            Me.floDataDisplay.Controls.Add(Me.lblCaption)
            Me.floDataDisplay.Controls.Add(Me.txtCaption)
            Me.floDataDisplay.Controls.Add(Me.lblTranslatedCaption)
            Me.floDataDisplay.Controls.Add(Me.txtTranslatedCaption)
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
            'lblMessage
            '
            Me.lblMessage.DisplayOnly = True
            Me.lblMessage.EditingMode = False
            resources.ApplyResources(Me.lblMessage, "lblMessage")
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Translatable = True
            '
            'lblTranslatedMessage
            '
            Me.lblTranslatedMessage.DisplayOnly = True
            Me.lblTranslatedMessage.EditingMode = False
            resources.ApplyResources(Me.lblTranslatedMessage, "lblTranslatedMessage")
            Me.lblTranslatedMessage.Name = "lblTranslatedMessage"
            Me.lblTranslatedMessage.Translatable = True
            '
            'txtTranslatedMessage
            '
            Me.txtTranslatedMessage.AutoFill = False
            Me.txtTranslatedMessage.BackColor = System.Drawing.Color.White
            Me.txtTranslatedMessage.BegFindValue = Nothing
            Me.txtTranslatedMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTranslatedMessage.ComputedValue = False
            Me.txtTranslatedMessage.CustomFormat = Nothing
            Me.txtTranslatedMessage.DataBoundControl = True
            Me.txtTranslatedMessage.EditingMode = False
            Me.txtTranslatedMessage.EndFindValue = Nothing
            Me.txtTranslatedMessage.EnglishControl = Me.txtMessage
            Me.txtTranslatedMessage.FieldDescription = Nothing
            Me.txtTranslatedMessage.FieldName = Nothing
            Me.txtTranslatedMessage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTranslatedMessage.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedMessage, True)
            resources.ApplyResources(Me.txtTranslatedMessage, "txtTranslatedMessage")
            Me.txtTranslatedMessage.ForeColor = System.Drawing.Color.Black
            Me.txtTranslatedMessage.LinkedLabel = Me.lblTranslatedMessage
            Me.txtTranslatedMessage.MaximumValue = Nothing
            Me.txtTranslatedMessage.MinimumValue = Nothing
            Me.txtTranslatedMessage.Name = "txtTranslatedMessage"
            Me.txtTranslatedMessage.OldValue = Nothing
            Me.txtTranslatedMessage.ReadOnly = True
            Me.txtTranslatedMessage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTranslatedMessage.Translatable = False
            Me.txtTranslatedMessage.ValueIsMandatory = True
            '
            'lblCaption
            '
            Me.lblCaption.DisplayOnly = True
            Me.lblCaption.EditingMode = False
            resources.ApplyResources(Me.lblCaption, "lblCaption")
            Me.lblCaption.Name = "lblCaption"
            Me.lblCaption.Translatable = True
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
            Me.txtTranslatedCaption.BackColor = System.Drawing.Color.White
            Me.txtTranslatedCaption.BegFindValue = Nothing
            Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTranslatedCaption.ComputedValue = False
            Me.txtTranslatedCaption.CustomFormat = Nothing
            Me.txtTranslatedCaption.DataBoundControl = True
            Me.txtTranslatedCaption.EditingMode = False
            Me.txtTranslatedCaption.EndFindValue = Nothing
            Me.txtTranslatedCaption.FieldDescription = Nothing
            Me.txtTranslatedCaption.FieldName = Nothing
            Me.txtTranslatedCaption.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTranslatedCaption.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, True)
            resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
            Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
            Me.txtTranslatedCaption.LinkedLabel = Nothing
            Me.txtTranslatedCaption.MaximumValue = Nothing
            Me.txtTranslatedCaption.MinimumValue = Nothing
            Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
            Me.txtTranslatedCaption.OldValue = Nothing
            Me.txtTranslatedCaption.ReadOnly = True
            Me.txtTranslatedCaption.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTranslatedCaption.TabStop = False
            Me.txtTranslatedCaption.Translatable = False
            Me.txtTranslatedCaption.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'OriginalMessagesEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "OriginalMessagesEntryTv"
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
        Friend WithEvents txtMessageKey As CTextBox
        Friend WithEvents txtMessage As CTextBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblMessageKey As CLabel
        Friend WithEvents lblMessage As CLabel
        Friend WithEvents lblCaption As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtCaption As CTextBox
        Friend WithEvents lblTranslatedMessage As CLabel
        Friend WithEvents lblTranslatedCaption As CLabel
        Friend WithEvents txtTranslatedCaption As CTextBox
        Friend WithEvents txtTranslatedMessage As CTextBoxArabic
    End Class
End Namespace