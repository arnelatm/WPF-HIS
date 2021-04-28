Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OriginalMessagesEntryTv
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
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtMessageKey
        '
        Me.txtMessageKey.BackColor = System.Drawing.Color.White
        Me.txtMessageKey.BegFindValue = Nothing
        Me.txtMessageKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessageKey.ComputedValue = false
        Me.txtMessageKey.CustomFormat = Nothing
        Me.txtMessageKey.DataBoundControl = true
        Me.txtMessageKey.DisplayOnly = true
        Me.txtMessageKey.EditingMode = false
        Me.txtMessageKey.EndFindValue = Nothing
        Me.txtMessageKey.FieldName = Nothing
        Me.txtMessageKey.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMessageKey.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtMessageKey, true)
        resources.ApplyResources(Me.txtMessageKey, "txtMessageKey")
        Me.txtMessageKey.ForeColor = System.Drawing.Color.Black
        Me.txtMessageKey.LinkedLabel = Me.lblMessageKey
        Me.txtMessageKey.MaximumValue = Nothing
        Me.txtMessageKey.MinimumValue = Nothing
        Me.txtMessageKey.Name = "txtMessageKey"
        Me.txtMessageKey.OldValue = Nothing
        Me.txtMessageKey.ReadOnly = true
        Me.txtMessageKey.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtMessageKey.TabStop = false
        Me.txtMessageKey.ValueIsMandatory = true
        '
        'lblMessageKey
        '
        Me.lblMessageKey.DisplayOnly = true
        Me.lblMessageKey.EditingMode = false
        resources.ApplyResources(Me.lblMessageKey, "lblMessageKey")
        Me.lblMessageKey.Name = "lblMessageKey"
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.White
        Me.txtMessage.BegFindValue = Nothing
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.ComputedValue = false
        Me.txtMessage.CustomFormat = Nothing
        Me.txtMessage.DataBoundControl = true
        Me.txtMessage.DisplayOnly = true
        Me.txtMessage.EditingMode = false
        Me.txtMessage.EndFindValue = Nothing
        Me.txtMessage.FieldName = Nothing
        Me.txtMessage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMessage.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtMessage, true)
        resources.ApplyResources(Me.txtMessage, "txtMessage")
        Me.txtMessage.ForeColor = System.Drawing.Color.Black
        Me.txtMessage.LinkedLabel = Nothing
        Me.txtMessage.MaximumValue = Nothing
        Me.txtMessage.MinimumValue = Nothing
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.OldValue = Nothing
        Me.txtMessage.ReadOnly = true
        Me.txtMessage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtMessage.ValueIsMandatory = true
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
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.ValueIsMandatory = true
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblMessage
        '
        Me.lblMessage.DisplayOnly = true
        Me.lblMessage.EditingMode = false
        resources.ApplyResources(Me.lblMessage, "lblMessage")
        Me.lblMessage.Name = "lblMessage"
        '
        'lblTranslatedMessage
        '
        Me.lblTranslatedMessage.DisplayOnly = true
        Me.lblTranslatedMessage.EditingMode = false
        resources.ApplyResources(Me.lblTranslatedMessage, "lblTranslatedMessage")
        Me.lblTranslatedMessage.Name = "lblTranslatedMessage"
        '
        'txtTranslatedMessage
        '
        Me.txtTranslatedMessage.AutoFill = false
        Me.txtTranslatedMessage.BackColor = System.Drawing.Color.White
        Me.txtTranslatedMessage.BegFindValue = Nothing
        Me.txtTranslatedMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedMessage.ComputedValue = false
        Me.txtTranslatedMessage.CustomFormat = Nothing
        Me.txtTranslatedMessage.DataBoundControl = true
        Me.txtTranslatedMessage.EditingMode = false
        Me.txtTranslatedMessage.EndFindValue = Nothing
        Me.txtTranslatedMessage.EnglishControl = Me.txtMessage
        Me.txtTranslatedMessage.FieldName = Nothing
        Me.txtTranslatedMessage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTranslatedMessage.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedMessage, true)
        resources.ApplyResources(Me.txtTranslatedMessage, "txtTranslatedMessage")
        Me.txtTranslatedMessage.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedMessage.LinkedLabel = Me.lblTranslatedMessage
        Me.txtTranslatedMessage.MaximumValue = Nothing
        Me.txtTranslatedMessage.MinimumValue = Nothing
        Me.txtTranslatedMessage.Name = "txtTranslatedMessage"
        Me.txtTranslatedMessage.OldValue = Nothing
        Me.txtTranslatedMessage.ReadOnly = true
        Me.txtTranslatedMessage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTranslatedMessage.ValueIsMandatory = true
        '
        'lblCaption
        '
        Me.lblCaption.DisplayOnly = true
        Me.lblCaption.EditingMode = false
        resources.ApplyResources(Me.lblCaption, "lblCaption")
        Me.lblCaption.Name = "lblCaption"
        '
        'txtCaption
        '
        Me.txtCaption.BackColor = System.Drawing.Color.White
        Me.txtCaption.BegFindValue = Nothing
        Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaption.ComputedValue = false
        Me.txtCaption.CustomFormat = Nothing
        Me.txtCaption.DataBoundControl = true
        Me.txtCaption.DisplayOnly = true
        Me.txtCaption.EditingMode = false
        Me.txtCaption.EndFindValue = Nothing
        Me.txtCaption.FieldName = Nothing
        Me.txtCaption.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCaption.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCaption, true)
        resources.ApplyResources(Me.txtCaption, "txtCaption")
        Me.txtCaption.ForeColor = System.Drawing.Color.Black
        Me.txtCaption.LinkedLabel = Nothing
        Me.txtCaption.MaximumValue = Nothing
        Me.txtCaption.MinimumValue = Nothing
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.OldValue = Nothing
        Me.txtCaption.ReadOnly = true
        Me.txtCaption.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCaption.ValueIsMandatory = true
        '
        'lblTranslatedCaption
        '
        Me.lblTranslatedCaption.DisplayOnly = true
        Me.lblTranslatedCaption.EditingMode = false
        resources.ApplyResources(Me.lblTranslatedCaption, "lblTranslatedCaption")
        Me.lblTranslatedCaption.Name = "lblTranslatedCaption"
        '
        'txtTranslatedCaption
        '
        Me.txtTranslatedCaption.BackColor = System.Drawing.Color.White
        Me.txtTranslatedCaption.BegFindValue = Nothing
        Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedCaption.ComputedValue = false
        Me.txtTranslatedCaption.CustomFormat = Nothing
        Me.txtTranslatedCaption.DataBoundControl = true
        Me.txtTranslatedCaption.EditingMode = false
        Me.txtTranslatedCaption.EndFindValue = Nothing
        Me.txtTranslatedCaption.FieldName = Nothing
        Me.txtTranslatedCaption.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTranslatedCaption.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, true)
        resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
        Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedCaption.LinkedLabel = Nothing
        Me.txtTranslatedCaption.MaximumValue = Nothing
        Me.txtTranslatedCaption.MinimumValue = Nothing
        Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
        Me.txtTranslatedCaption.OldValue = Nothing
        Me.txtTranslatedCaption.ReadOnly = true
        Me.txtTranslatedCaption.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTranslatedCaption.TabStop = false
        Me.txtTranslatedCaption.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'OriginalMessagesEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "OriginalMessagesEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
End NameSpace