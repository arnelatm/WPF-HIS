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
        Me.txtLanguageIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtMessageIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtIdNoTranslated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
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
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtMessageKey
        '
        Me.txtMessageKey.BackColor = System.Drawing.Color.White
        Me.txtMessageKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessageKey.ComputedValue = false
        Me.txtMessageKey.CustomFormat = Nothing
        Me.txtMessageKey.DataBoundControl = true
        Me.txtMessageKey.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtMessageKey, true)
        resources.ApplyResources(Me.txtMessageKey, "txtMessageKey")
        Me.txtMessageKey.ForeColor = System.Drawing.Color.Black
        Me.txtMessageKey.LinkedLabel = Me.lblMessageKey
        Me.txtMessageKey.MaximumValue = Nothing
        Me.txtMessageKey.MinimumValue = Nothing
        Me.txtMessageKey.Name = "txtMessageKey"
        Me.txtMessageKey.OldValue = Nothing
        Me.txtMessageKey.ReadOnly = true
        Me.txtMessageKey.SecurityKey = "Translators_Developer"
        Me.txtMessageKey.TabStop = false
        Me.txtMessageKey.ValueIsMandatory = true
        '
        'lblMessageKey
        '
        Me.lblMessageKey.DisplayOnly = true
        Me.lblMessageKey.EditingMode = false
        resources.ApplyResources(Me.lblMessageKey, "lblMessageKey")
        Me.lblMessageKey.Name = "lblMessageKey"
        Me.lblMessageKey.SecurityKey = "Translators_Developer"
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.White
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.ComputedValue = false
        Me.txtMessage.CustomFormat = Nothing
        Me.txtMessage.DataBoundControl = true
        Me.txtMessage.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtMessage, true)
        resources.ApplyResources(Me.txtMessage, "txtMessage")
        Me.txtMessage.ForeColor = System.Drawing.Color.Black
        Me.txtMessage.LinkedLabel = Nothing
        Me.txtMessage.MaximumValue = Nothing
        Me.txtMessage.MinimumValue = Nothing
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.OldValue = Nothing
        Me.txtMessage.ReadOnly = true
        Me.txtMessage.SecurityKey = "Translators_Developer"
        Me.txtMessage.ValueIsMandatory = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SecurityKey = "Translators_Developer"
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
        Me.floDataDisplay.Controls.Add(Me.txtLanguageIdNo)
        Me.floDataDisplay.Controls.Add(Me.txtMessageIdNo)
        Me.floDataDisplay.Controls.Add(Me.txtIdNoTranslated)
        Me.floDataDisplay.Controls.Add(Me.Button1)
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
        Me.lblMessage.SecurityKey = "Translators_Developer"
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
        Me.txtTranslatedMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedMessage.ComputedValue = false
        Me.txtTranslatedMessage.CustomFormat = Nothing
        Me.txtTranslatedMessage.DataBoundControl = true
        Me.txtTranslatedMessage.EditingMode = false
        Me.txtTranslatedMessage.EnglishControl = Me.txtMessage
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedMessage, true)
        resources.ApplyResources(Me.txtTranslatedMessage, "txtTranslatedMessage")
        Me.txtTranslatedMessage.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedMessage.LinkedLabel = Me.lblTranslatedMessage
        Me.txtTranslatedMessage.MaximumValue = Nothing
        Me.txtTranslatedMessage.MinimumValue = Nothing
        Me.txtTranslatedMessage.Name = "txtTranslatedMessage"
        Me.txtTranslatedMessage.OldValue = Nothing
        Me.txtTranslatedMessage.ReadOnly = true
        Me.txtTranslatedMessage.ValueIsMandatory = true
        '
        'lblCaption
        '
        Me.lblCaption.DisplayOnly = true
        Me.lblCaption.EditingMode = false
        resources.ApplyResources(Me.lblCaption, "lblCaption")
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.SecurityKey = "Translators_Developer"
        '
        'txtCaption
        '
        Me.txtCaption.BackColor = System.Drawing.Color.White
        Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaption.ComputedValue = false
        Me.txtCaption.CustomFormat = Nothing
        Me.txtCaption.DataBoundControl = true
        Me.txtCaption.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCaption, true)
        resources.ApplyResources(Me.txtCaption, "txtCaption")
        Me.txtCaption.ForeColor = System.Drawing.Color.Black
        Me.txtCaption.LinkedLabel = Nothing
        Me.txtCaption.MaximumValue = Nothing
        Me.txtCaption.MinimumValue = Nothing
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.OldValue = Nothing
        Me.txtCaption.ReadOnly = true
        Me.txtCaption.SecurityKey = "Translators_Developer"
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
        Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedCaption.ComputedValue = false
        Me.txtTranslatedCaption.CustomFormat = Nothing
        Me.txtTranslatedCaption.DataBoundControl = true
        Me.txtTranslatedCaption.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, true)
        resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
        Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedCaption.LinkedLabel = Nothing
        Me.txtTranslatedCaption.MaximumValue = Nothing
        Me.txtTranslatedCaption.MinimumValue = Nothing
        Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
        Me.txtTranslatedCaption.OldValue = Nothing
        Me.txtTranslatedCaption.ReadOnly = true
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
        'txtLanguageIdNo
        '
        Me.txtLanguageIdNo.BackColor = System.Drawing.Color.White
        Me.txtLanguageIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLanguageIdNo.ComputedValue = false
        Me.txtLanguageIdNo.CustomFormat = Nothing
        Me.txtLanguageIdNo.DataBoundControl = true
        Me.txtLanguageIdNo.DisplayOnly = true
        Me.txtLanguageIdNo.EditingMode = true
        resources.ApplyResources(Me.txtLanguageIdNo, "txtLanguageIdNo")
        Me.txtLanguageIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtLanguageIdNo.LinkedLabel = Nothing
        Me.txtLanguageIdNo.MaximumValue = Nothing
        Me.txtLanguageIdNo.MinimumValue = Nothing
        Me.txtLanguageIdNo.Name = "txtLanguageIdNo"
        Me.txtLanguageIdNo.OldValue = Nothing
        Me.txtLanguageIdNo.ReadOnly = true
        Me.txtLanguageIdNo.TabStop = false
        '
        'txtMessageIdNo
        '
        Me.txtMessageIdNo.BackColor = System.Drawing.Color.White
        Me.txtMessageIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessageIdNo.ComputedValue = false
        Me.txtMessageIdNo.CustomFormat = Nothing
        Me.txtMessageIdNo.DataBoundControl = true
        Me.txtMessageIdNo.DisplayOnly = true
        Me.txtMessageIdNo.EditingMode = true
        resources.ApplyResources(Me.txtMessageIdNo, "txtMessageIdNo")
        Me.txtMessageIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtMessageIdNo.LinkedLabel = Nothing
        Me.txtMessageIdNo.MaximumValue = Nothing
        Me.txtMessageIdNo.MinimumValue = Nothing
        Me.txtMessageIdNo.Name = "txtMessageIdNo"
        Me.txtMessageIdNo.OldValue = Nothing
        Me.txtMessageIdNo.ReadOnly = true
        Me.txtMessageIdNo.TabStop = false
        '
        'txtIdNoTranslated
        '
        Me.txtIdNoTranslated.BackColor = System.Drawing.Color.White
        Me.txtIdNoTranslated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNoTranslated.ComputedValue = false
        Me.txtIdNoTranslated.CustomFormat = Nothing
        Me.txtIdNoTranslated.DataBoundControl = true
        Me.txtIdNoTranslated.DisplayOnly = true
        Me.txtIdNoTranslated.EditingMode = true
        resources.ApplyResources(Me.txtIdNoTranslated, "txtIdNoTranslated")
        Me.txtIdNoTranslated.ForeColor = System.Drawing.Color.Black
        Me.txtIdNoTranslated.LinkedLabel = Nothing
        Me.txtIdNoTranslated.MaximumValue = Nothing
        Me.txtIdNoTranslated.MinimumValue = Nothing
        Me.txtIdNoTranslated.Name = "txtIdNoTranslated"
        Me.txtIdNoTranslated.OldValue = Nothing
        Me.txtIdNoTranslated.ReadOnly = true
        Me.txtIdNoTranslated.TabStop = false
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
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
        Friend WithEvents txtLanguageIdNo As CTextBox
        Friend WithEvents txtMessageIdNo As CTextBox
        Friend WithEvents txtIdNoTranslated As CTextBox
        Friend WithEvents Button1 As Windows.Forms.Button
        Friend WithEvents txtTranslatedMessage As CTextBoxArabic
    End Class
End NameSpace