Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FringeBenefitEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FringeBenefitEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtFringeBenefitNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblFringeBenefitCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblFringeBenefitName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblFringeBenefitNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        'txtFringeBenefitCode
        '
        Me.txtFringeBenefitCode.BackColor = System.Drawing.Color.White
        Me.txtFringeBenefitCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFringeBenefitCode.ComputedValue = false
        Me.txtFringeBenefitCode.CustomFormat = Nothing
        Me.txtFringeBenefitCode.DataBoundControl = true
        Me.txtFringeBenefitCode.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitCode, true)
        resources.ApplyResources(Me.txtFringeBenefitCode, "txtFringeBenefitCode")
        Me.txtFringeBenefitCode.ForeColor = System.Drawing.Color.Black
        Me.txtFringeBenefitCode.LinkedLabel = Nothing
        Me.txtFringeBenefitCode.MaximumValue = Nothing
        Me.txtFringeBenefitCode.MinimumValue = Nothing
        Me.txtFringeBenefitCode.Name = "txtFringeBenefitCode"
        Me.txtFringeBenefitCode.OldValue = Nothing
        Me.txtFringeBenefitCode.ReadOnly = true
        Me.txtFringeBenefitCode.ValueIsMandatory = true
        '
        'txtFringeBenefitName
        '
        Me.txtFringeBenefitName.BackColor = System.Drawing.Color.White
        Me.txtFringeBenefitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFringeBenefitName.ComputedValue = false
        Me.txtFringeBenefitName.CustomFormat = Nothing
        Me.txtFringeBenefitName.DataBoundControl = true
        Me.txtFringeBenefitName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitName, true)
        resources.ApplyResources(Me.txtFringeBenefitName, "txtFringeBenefitName")
        Me.txtFringeBenefitName.ForeColor = System.Drawing.Color.Black
        Me.txtFringeBenefitName.LinkedLabel = Nothing
        Me.txtFringeBenefitName.MaximumValue = Nothing
        Me.txtFringeBenefitName.MinimumValue = Nothing
        Me.txtFringeBenefitName.Name = "txtFringeBenefitName"
        Me.txtFringeBenefitName.OldValue = Nothing
        Me.txtFringeBenefitName.ReadOnly = true
        Me.txtFringeBenefitName.ValueIsMandatory = true
        '
        'txtFringeBenefitNameAra
        '
        Me.txtFringeBenefitNameAra.BackColor = System.Drawing.Color.White
        Me.txtFringeBenefitNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFringeBenefitNameAra.ComputedValue = false
        Me.txtFringeBenefitNameAra.CustomFormat = Nothing
        Me.txtFringeBenefitNameAra.DataBoundControl = true
        Me.txtFringeBenefitNameAra.EditingMode = false
        Me.txtFringeBenefitNameAra.EnglishControl = Me.txtFringeBenefitName
        Me.floDataDisplay.SetFlowBreak(Me.txtFringeBenefitNameAra, true)
        resources.ApplyResources(Me.txtFringeBenefitNameAra, "txtFringeBenefitNameAra")
        Me.txtFringeBenefitNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtFringeBenefitNameAra.LinkedLabel = Nothing
        Me.txtFringeBenefitNameAra.MaximumValue = Nothing
        Me.txtFringeBenefitNameAra.MinimumValue = Nothing
        Me.txtFringeBenefitNameAra.Name = "txtFringeBenefitNameAra"
        Me.txtFringeBenefitNameAra.OldValue = Nothing
        Me.txtFringeBenefitNameAra.ReadOnly = true
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
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblFringeBenefitCode)
        Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitCode)
        Me.floDataDisplay.Controls.Add(Me.lblFringeBenefitName)
        Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitName)
        Me.floDataDisplay.Controls.Add(Me.lblFringeBenefitNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtFringeBenefitNameAra)
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
        'lblFringeBenefitCode
        '
        Me.lblFringeBenefitCode.DisplayOnly = true
        Me.lblFringeBenefitCode.EditingMode = false
        resources.ApplyResources(Me.lblFringeBenefitCode, "lblFringeBenefitCode")
        Me.lblFringeBenefitCode.Name = "lblFringeBenefitCode"
        '
        'lblFringeBenefitName
        '
        Me.lblFringeBenefitName.DisplayOnly = true
        Me.lblFringeBenefitName.EditingMode = false
        resources.ApplyResources(Me.lblFringeBenefitName, "lblFringeBenefitName")
        Me.lblFringeBenefitName.Name = "lblFringeBenefitName"
        '
        'lblFringeBenefitNameAra
        '
        Me.lblFringeBenefitNameAra.DisplayOnly = true
        Me.lblFringeBenefitNameAra.EditingMode = false
        resources.ApplyResources(Me.lblFringeBenefitNameAra, "lblFringeBenefitNameAra")
        Me.lblFringeBenefitNameAra.Name = "lblFringeBenefitNameAra"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'FringeBenefitEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "FringeBenefitEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtFringeBenefitCode As CTextBox
        Friend WithEvents txtFringeBenefitName As CTextBox
        Friend WithEvents txtFringeBenefitNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblFringeBenefitCode As CLabel
        Friend WithEvents lblFringeBenefitName As CLabel
        Friend WithEvents lblFringeBenefitNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End NameSpace