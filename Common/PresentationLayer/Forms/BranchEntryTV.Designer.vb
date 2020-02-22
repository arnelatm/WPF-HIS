Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BranchEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BranchEntryTv))
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBranchCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBranchName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBranchNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBranchCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBranchName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBranchNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.TabStop = false
        '
        'txtBranchCode
        '
        Me.txtBranchCode.AcceptsReturn = false
        Me.txtBranchCode.AcceptsTab = false
        Me.txtBranchCode.BackColor = System.Drawing.Color.White
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.ComputedValue = false
        Me.txtBranchCode.DataBoundControl = true
        Me.txtBranchCode.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtBranchCode, true)
        resources.ApplyResources(Me.txtBranchCode, "txtBranchCode")
        Me.txtBranchCode.ForeColor = System.Drawing.Color.Black
        Me.txtBranchCode.LinkedLabel = Nothing
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = true
        Me.txtBranchCode.ValueIsMandatory = true
        '
        'txtBranchName
        '
        Me.txtBranchName.AcceptsReturn = false
        Me.txtBranchName.AcceptsTab = false
        Me.txtBranchName.BackColor = System.Drawing.Color.White
        Me.txtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchName.ComputedValue = false
        Me.txtBranchName.DataBoundControl = true
        Me.txtBranchName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtBranchName, true)
        resources.ApplyResources(Me.txtBranchName, "txtBranchName")
        Me.txtBranchName.ForeColor = System.Drawing.Color.Black
        Me.txtBranchName.LinkedLabel = Nothing
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.ValueIsMandatory = true
        '
        'txtBranchNameAra
        '
        Me.txtBranchNameAra.AcceptsReturn = false
        Me.txtBranchNameAra.AcceptsTab = false
        Me.txtBranchNameAra.BackColor = System.Drawing.Color.White
        Me.txtBranchNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchNameAra.ComputedValue = false
        Me.txtBranchNameAra.DataBoundControl = true
        Me.txtBranchNameAra.EditingMode = false
        Me.txtBranchNameAra.EnglishControl = Me.txtBranchName
        Me.floDataDisplay.SetFlowBreak(Me.txtBranchNameAra, true)
        resources.ApplyResources(Me.txtBranchNameAra, "txtBranchNameAra")
        Me.txtBranchNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtBranchNameAra.LinkedLabel = Nothing
        Me.txtBranchNameAra.Name = "txtBranchNameAra"
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = false
        Me.txtNotes.AcceptsTab = false
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
        Me.floDataDisplay.Controls.Add(Me.lblBranchCode)
        Me.floDataDisplay.Controls.Add(Me.txtBranchCode)
        Me.floDataDisplay.Controls.Add(Me.lblBranchName)
        Me.floDataDisplay.Controls.Add(Me.txtBranchName)
        Me.floDataDisplay.Controls.Add(Me.lblBranchNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtBranchNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblBranchCode
        '
        resources.ApplyResources(Me.lblBranchCode, "lblBranchCode")
        Me.lblBranchCode.Name = "lblBranchCode"
        '
        'lblBranchName
        '
        resources.ApplyResources(Me.lblBranchName, "lblBranchName")
        Me.lblBranchName.Name = "lblBranchName"
        '
        'lblBranchNameAra
        '
        resources.ApplyResources(Me.lblBranchNameAra, "lblBranchNameAra")
        Me.lblBranchNameAra.Name = "lblBranchNameAra"
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'BranchEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "BranchEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtBranchCode As CTextBox
        Friend WithEvents txtBranchName As CTextBox
        Friend WithEvents txtBranchNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblBranchCode As CLabel
        Friend WithEvents lblBranchName As CLabel
        Friend WithEvents lblBranchNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End NameSpace