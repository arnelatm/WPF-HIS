Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DesignationEntryTv
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
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.TabStop = false
        '
        'txtDesignationCode
        '
        Me.txtDesignationCode.BackColor = System.Drawing.Color.White
        Me.txtDesignationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationCode.ComputedValue = false
        Me.txtDesignationCode.CustomFormat = Nothing
        Me.txtDesignationCode.DataBoundControl = true
        Me.txtDesignationCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationCode, true)
        resources.ApplyResources(Me.txtDesignationCode, "txtDesignationCode")
        Me.txtDesignationCode.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationCode.LinkedLabel = Nothing
        Me.txtDesignationCode.Name = "txtDesignationCode"
        Me.txtDesignationCode.OldValue = Nothing
        Me.txtDesignationCode.ReadOnly = true
        Me.txtDesignationCode.ValueIsMandatory = true
        '
        'txtDesignationName
        '
        Me.txtDesignationName.BackColor = System.Drawing.Color.White
        Me.txtDesignationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationName.ComputedValue = false
        Me.txtDesignationName.CustomFormat = Nothing
        Me.txtDesignationName.DataBoundControl = true
        Me.txtDesignationName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationName, true)
        resources.ApplyResources(Me.txtDesignationName, "txtDesignationName")
        Me.txtDesignationName.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationName.LinkedLabel = Nothing
        Me.txtDesignationName.Name = "txtDesignationName"
        Me.txtDesignationName.OldValue = Nothing
        Me.txtDesignationName.ValueIsMandatory = true
        '
        'txtDesignationNameAra
        '
        Me.txtDesignationNameAra.BackColor = System.Drawing.Color.White
        Me.txtDesignationNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignationNameAra.ComputedValue = false
        Me.txtDesignationNameAra.CustomFormat = Nothing
        Me.txtDesignationNameAra.DataBoundControl = true
        Me.txtDesignationNameAra.EditingMode = false
        Me.txtDesignationNameAra.EnglishControl = Me.txtDesignationName
        Me.floDataDisplay.SetFlowBreak(Me.txtDesignationNameAra, true)
        resources.ApplyResources(Me.txtDesignationNameAra, "txtDesignationNameAra")
        Me.txtDesignationNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDesignationNameAra.LinkedLabel = Nothing
        Me.txtDesignationNameAra.Name = "txtDesignationNameAra"
        Me.txtDesignationNameAra.OldValue = Nothing
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
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
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
        Me.floDataDisplay.Controls.Add(Me.lblDesignationNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtDesignationNameAra)
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
        'lblDesignationCode
        '
        Me.lblDesignationCode.DisplayOnly = true
        Me.lblDesignationCode.EditingMode = false
        resources.ApplyResources(Me.lblDesignationCode, "lblDesignationCode")
        Me.lblDesignationCode.Name = "lblDesignationCode"
        '
        'lblDesignationName
        '
        Me.lblDesignationName.DisplayOnly = true
        Me.lblDesignationName.EditingMode = false
        resources.ApplyResources(Me.lblDesignationName, "lblDesignationName")
        Me.lblDesignationName.Name = "lblDesignationName"
        '
        'lblDesignationNameAra
        '
        Me.lblDesignationNameAra.DisplayOnly = true
        Me.lblDesignationNameAra.EditingMode = false
        resources.ApplyResources(Me.lblDesignationNameAra, "lblDesignationNameAra")
        Me.lblDesignationNameAra.Name = "lblDesignationNameAra"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'DesignationEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "DesignationEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
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
    End Class
End NameSpace