Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SecurityObjectEntryTv
        Inherits AATM.PresentationLayer.Forms.BfTvEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityObjectEntryTv))
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        'TxtIDNo
        '
        Me.TxtIDNo.AcceptsReturn = false
        Me.TxtIDNo.AcceptsTab = false
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
        Me.TxtIDNo.EditingMode = true
        Me.TxtIDNo.TabStop = false
        Me.TxtIDNo.DisplayOnly = true
        '
        'txtSecurityObjectName
        '
        Me.txtSecurityObjectName.AcceptsReturn = false
        Me.txtSecurityObjectName.AcceptsTab = false
        Me.txtSecurityObjectName.BackColor = System.Drawing.Color.White
        Me.txtSecurityObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityObjectName.ComputedValue = false
        Me.txtSecurityObjectName.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectName, true)
        resources.ApplyResources(Me.txtSecurityObjectName, "txtSecurityObjectName")
        Me.txtSecurityObjectName.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityObjectName.LinkedLabel = Nothing
        Me.txtSecurityObjectName.Name = "txtSecurityObjectName"
        Me.txtSecurityObjectName.EditingMode = false
        Me.txtSecurityObjectName.ValueIsMandatory = true
        '
        'txtSecurityObjectNameAra
        '
        Me.txtSecurityObjectNameAra.AcceptsReturn = false
        Me.txtSecurityObjectNameAra.AcceptsTab = false
        Me.txtSecurityObjectNameAra.BackColor = System.Drawing.Color.White
        Me.txtSecurityObjectNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSecurityObjectNameAra.ComputedValue = false
        Me.txtSecurityObjectNameAra.DataBoundControl = true
        Me.txtSecurityObjectNameAra.EnglishControl = Me.txtSecurityObjectName
        Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectNameAra, true)
        resources.ApplyResources(Me.txtSecurityObjectNameAra, "txtSecurityObjectNameAra")
        Me.txtSecurityObjectNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSecurityObjectNameAra.LinkedLabel = Nothing
        Me.txtSecurityObjectNameAra.Name = "txtSecurityObjectNameAra"
        Me.txtSecurityObjectNameAra.EditingMode = false
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = false
        Me.txtNotes.AcceptsTab = false
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.EditingMode = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
        Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectName)
        Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectName)
        Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblSecurityObjectName
        '
        resources.ApplyResources(Me.lblSecurityObjectName, "lblSecurityObjectName")
        Me.lblSecurityObjectName.Name = "lblSecurityObjectName"
        '
        'lblSecurityObjectNameAra
        '
        resources.ApplyResources(Me.lblSecurityObjectNameAra, "lblSecurityObjectNameAra")
        Me.lblSecurityObjectNameAra.Name = "lblSecurityObjectNameAra"
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'SecurityObjectEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "SecurityObjectEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtSecurityObjectName As CTextBox
        Friend WithEvents txtSecurityObjectNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblSecurityObjectName As CLabel
        Friend WithEvents lblSecurityObjectNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End Namespace