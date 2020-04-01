Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
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
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTranslatedCaption = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtLanguageIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCaptionIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtIdNoTranslated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.TabStop = false
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
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.OldValue = Nothing
        Me.txtCaption.SecurityKey = "Translators_Developer"
        Me.txtCaption.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.Label1)
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
        Me.floDataDisplay.Controls.Add(Me.lblCaption)
        Me.floDataDisplay.Controls.Add(Me.txtCaption)
        Me.floDataDisplay.Controls.Add(Me.lblTranslatedCaption)
        Me.floDataDisplay.Controls.Add(Me.txtTranslatedCaption)
        Me.floDataDisplay.Controls.Add(Me.txtLanguageIdNo)
        Me.floDataDisplay.Controls.Add(Me.txtCaptionIdNo)
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
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblCaption
        '
        Me.lblCaption.DisplayOnly = true
        Me.lblCaption.EditingMode = false
        resources.ApplyResources(Me.lblCaption, "lblCaption")
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.SecurityKey = "Translators_Developer"
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
        Me.txtTranslatedCaption.AutoFill = false
        Me.txtTranslatedCaption.BackColor = System.Drawing.Color.White
        Me.txtTranslatedCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranslatedCaption.ComputedValue = false
        Me.txtTranslatedCaption.CustomFormat = Nothing
        Me.txtTranslatedCaption.DataBoundControl = true
        Me.txtTranslatedCaption.EditingMode = false
        Me.txtTranslatedCaption.EnglishControl = Me.txtCaption
        Me.floDataDisplay.SetFlowBreak(Me.txtTranslatedCaption, true)
        resources.ApplyResources(Me.txtTranslatedCaption, "txtTranslatedCaption")
        Me.txtTranslatedCaption.ForeColor = System.Drawing.Color.Black
        Me.txtTranslatedCaption.LinkedLabel = Me.lblTranslatedCaption
        Me.txtTranslatedCaption.Name = "txtTranslatedCaption"
        Me.txtTranslatedCaption.OldValue = Nothing
        Me.txtTranslatedCaption.ValueIsMandatory = true
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
        Me.txtLanguageIdNo.Name = "txtLanguageIdNo"
        Me.txtLanguageIdNo.OldValue = Nothing
        Me.txtLanguageIdNo.ReadOnly = true
        Me.txtLanguageIdNo.TabStop = false
        '
        'txtCaptionIdNo
        '
        Me.txtCaptionIdNo.BackColor = System.Drawing.Color.White
        Me.txtCaptionIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaptionIdNo.ComputedValue = false
        Me.txtCaptionIdNo.CustomFormat = Nothing
        Me.txtCaptionIdNo.DataBoundControl = true
        Me.txtCaptionIdNo.DisplayOnly = true
        Me.txtCaptionIdNo.EditingMode = true
        resources.ApplyResources(Me.txtCaptionIdNo, "txtCaptionIdNo")
        Me.txtCaptionIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtCaptionIdNo.LinkedLabel = Nothing
        Me.txtCaptionIdNo.Name = "txtCaptionIdNo"
        Me.txtCaptionIdNo.OldValue = Nothing
        Me.txtCaptionIdNo.ReadOnly = true
        Me.txtCaptionIdNo.TabStop = false
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
        Me.txtIdNoTranslated.Name = "txtIdNoTranslated"
        Me.txtIdNoTranslated.OldValue = Nothing
        Me.txtIdNoTranslated.ReadOnly = true
        Me.txtIdNoTranslated.TabStop = false
        '
        'OriginalCaptionsEntryTv
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
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtCaption As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCaption As CLabel
        Friend WithEvents lblTranslatedCaption As CLabel
        Friend WithEvents txtLanguageIdNo As CTextBox
        Friend WithEvents txtCaptionIdNo As CTextBox
        Friend WithEvents txtIdNoTranslated As CTextBox
        Friend WithEvents txtTranslatedCaption As CTextBoxArabic
        Friend WithEvents Label1 As Label
    End Class
End NameSpace