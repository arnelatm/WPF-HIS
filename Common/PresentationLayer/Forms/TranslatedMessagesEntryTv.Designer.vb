Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TranslatedMessagesEntryTv
        Inherits BfTvEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TranslatedMessagesEntryTv))
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtMessageKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblMessageKey = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtMessage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblMessage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTranslatedMessage = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTranslatedMessage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtLanguageIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtOriginalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'TxtIDNo
        '
        Me.TxtIDNo.AcceptsReturn = true
        Me.TxtIDNo.AcceptsTab = true
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.DataBoundControl = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.ReadOnlyMode = true
        Me.TxtIDNo.TabStop = false
        Me.TxtIDNo.ValueIsReadOnly = true
        '
        'txtMessageKey
        '
        Me.txtMessageKey.AcceptsReturn = true
        Me.txtMessageKey.AcceptsTab = true
        Me.txtMessageKey.BackColor = System.Drawing.Color.White
        Me.txtMessageKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessageKey.ComputedValue = false
        Me.txtMessageKey.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtMessageKey, true)
        resources.ApplyResources(Me.txtMessageKey, "txtMessageKey")
        Me.txtMessageKey.ForeColor = System.Drawing.Color.Black
        Me.txtMessageKey.LinkedLabel = Me.lblMessageKey
        Me.txtMessageKey.Name = "txtMessageKey"
        Me.txtMessageKey.ReadOnlyMode = false
        Me.txtMessageKey.ValueIsMandatory = true
        '
        'lblMessageKey
        '
        resources.ApplyResources(Me.lblMessageKey, "lblMessageKey")
        Me.lblMessageKey.Name = "lblMessageKey"
        '
        'txtMessage
        '
        Me.txtMessage.AcceptsReturn = true
        Me.txtMessage.AcceptsTab = true
        Me.txtMessage.BackColor = System.Drawing.Color.White
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.ComputedValue = false
        Me.txtMessage.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtMessage, true)
        resources.ApplyResources(Me.txtMessage, "txtMessage")
        Me.txtMessage.ForeColor = System.Drawing.Color.Black
        Me.txtMessage.LinkedLabel = Nothing
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnlyMode = false
        Me.txtMessage.ValueIsMandatory = true
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = true
        Me.txtNotes.AcceptsTab = true
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtNotes, true)
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnlyMode = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
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
        Me.floDataDisplay.Controls.Add(Me.txtOriginalIdNo)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblMessage
        '
        resources.ApplyResources(Me.lblMessage, "lblMessage")
        Me.lblMessage.Name = "lblMessage"
        '
        'lblCaption
        '
        resources.ApplyResources(Me.lblCaption, "lblCaption")
        Me.lblCaption.Name = "lblCaption"
        '
        'txtCaption
        '
        Me.txtCaption.AcceptsReturn = true
        Me.txtCaption.AcceptsTab = true
        Me.txtCaption.BackColor = System.Drawing.Color.White
        Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaption.ComputedValue = false
        Me.txtCaption.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCaption, true)
        resources.ApplyResources(Me.txtCaption, "txtCaption")
        Me.txtCaption.ForeColor = System.Drawing.Color.Black
        Me.txtCaption.LinkedLabel = Nothing
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.ReadOnlyMode = false
        Me.txtCaption.ValueIsMandatory = true
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'lblTranslatedMessage
        '
        resources.ApplyResources(Me.lblTranslatedMessage, "lblTranslatedMessage")
        Me.lblTranslatedMessage.Name = "lblTranslatedMessage"
        '
        'txtTranslatedMessage
        '
        Me.txtTranslatedMessage.AcceptsReturn = true
        Me.txtTranslatedMessage.AcceptsTab = true
        Me.txtTranslatedMessage.BackColor = System.Drawing.Color.White
        Me.txtTranslatedMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedMessage.ComputedValue = false
        Me.txtTranslatedMessage.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedMessage, true)
        resources.ApplyResources(Me.txtTranslatedMessage, "txtTranslatedMessage")
        Me.txtTranslatedMessage.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedMessage.LinkedLabel = Me.lblTranslatedMessage
        Me.txtTranslatedMessage.Name = "txtTranslatedMessage"
        Me.txtTranslatedMessage.ReadOnlyMode = false
        Me.txtTranslatedMessage.ValueIsMandatory = true
        '
        'lblTranslatedCaption
        '
        resources.ApplyResources(Me.lblTranslatedCaption, "lblTranslatedCaption")
        Me.lblTranslatedCaption.Name = "lblTranslatedCaption"
        '
        'txtTranslatedCaption
        '
        Me.txtTranslatedCaption.AcceptsReturn = true
        Me.txtTranslatedCaption.AcceptsTab = true
        Me.txtTranslatedCaption.BackColor = System.Drawing.Color.White
        Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedCaption.ComputedValue = false
        Me.txtTranslatedCaption.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, true)
        resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
        Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedCaption.LinkedLabel = Me.lblTranslatedCaption
        Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
        Me.txtTranslatedCaption.ReadOnlyMode = false
        Me.txtTranslatedCaption.ValueIsMandatory = true
        '
        'txtLanguageIdNo
        '
        Me.txtLanguageIdNo.AcceptsReturn = true
        Me.txtLanguageIdNo.AcceptsTab = true
        Me.txtLanguageIdNo.BackColor = System.Drawing.Color.White
        Me.txtLanguageIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLanguageIdNo.ComputedValue = false
        Me.txtLanguageIdNo.DataBoundControl = true
        resources.ApplyResources(Me.txtLanguageIdNo, "txtLanguageIdNo")
        Me.txtLanguageIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtLanguageIdNo.LinkedLabel = Nothing
        Me.txtLanguageIdNo.Name = "txtLanguageIdNo"
        Me.txtLanguageIdNo.ReadOnly = true
        Me.txtLanguageIdNo.ReadOnlyMode = true
        Me.txtLanguageIdNo.TabStop = false
        Me.txtLanguageIdNo.ValueIsReadOnly = true
        '
        'txtOriginalIdNo
        '
        Me.txtOriginalIdNo.AcceptsReturn = true
        Me.txtOriginalIdNo.AcceptsTab = true
        Me.txtOriginalIdNo.BackColor = System.Drawing.Color.White
        Me.txtOriginalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOriginalIdNo.ComputedValue = false
        Me.txtOriginalIdNo.DataBoundControl = true
        resources.ApplyResources(Me.txtOriginalIdNo, "txtOriginalIdNo")
        Me.floDataDisplay.SetFlowBreak(Me.txtOriginalIdNo, true)
        Me.txtOriginalIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtOriginalIdNo.LinkedLabel = Nothing
        Me.txtOriginalIdNo.Name = "txtOriginalIdNo"
        Me.txtOriginalIdNo.ReadOnly = true
        Me.txtOriginalIdNo.ReadOnlyMode = true
        Me.txtOriginalIdNo.TabStop = false
        Me.txtOriginalIdNo.ValueIsReadOnly = true
        '
        'TranslatedMessagesEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "TranslatedMessagesEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIDNo As CTextBox
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
        Friend WithEvents txtTranslatedMessage As CTextBox
        Friend WithEvents lblTranslatedCaption As CLabel
        Friend WithEvents txtTranslatedCaption As CTextBox
        Friend WithEvents txtLanguageIdNo As CTextBox
        Friend WithEvents txtOriginalIdNo As CTextBox
    End Class
End NameSpace