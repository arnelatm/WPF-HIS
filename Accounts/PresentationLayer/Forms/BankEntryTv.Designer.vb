Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BankEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBankCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBankName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBankNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBankCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBankName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBankNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        'txtBankCode
        '
        Me.txtBankCode.BackColor = System.Drawing.Color.White
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.ComputedValue = false
        Me.txtBankCode.CustomFormat = Nothing
        Me.txtBankCode.DataBoundControl = true
        Me.txtBankCode.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtBankCode, true)
        resources.ApplyResources(Me.txtBankCode, "txtBankCode")
        Me.txtBankCode.ForeColor = System.Drawing.Color.Black
        Me.txtBankCode.LinkedLabel = Nothing
        Me.txtBankCode.MaximumValue = Nothing
        Me.txtBankCode.MinimumValue = Nothing
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.OldValue = Nothing
        Me.txtBankCode.ReadOnly = true
        Me.txtBankCode.ValueIsMandatory = true
        '
        'txtBankName
        '
        Me.txtBankName.BackColor = System.Drawing.Color.White
        Me.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankName.ComputedValue = false
        Me.txtBankName.CustomFormat = Nothing
        Me.txtBankName.DataBoundControl = true
        Me.txtBankName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtBankName, true)
        resources.ApplyResources(Me.txtBankName, "txtBankName")
        Me.txtBankName.ForeColor = System.Drawing.Color.Black
        Me.txtBankName.LinkedLabel = Nothing
        Me.txtBankName.MaximumValue = Nothing
        Me.txtBankName.MinimumValue = Nothing
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.OldValue = Nothing
        Me.txtBankName.ReadOnly = true
        Me.txtBankName.ValueIsMandatory = true
        '
        'txtBankNameAra
        '
        Me.txtBankNameAra.BackColor = System.Drawing.Color.White
        Me.txtBankNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankNameAra.ComputedValue = false
        Me.txtBankNameAra.CustomFormat = Nothing
        Me.txtBankNameAra.DataBoundControl = true
        Me.txtBankNameAra.EditingMode = false
        Me.txtBankNameAra.EnglishControl = Me.txtBankName
        Me.floDataDisplay.SetFlowBreak(Me.txtBankNameAra, true)
        resources.ApplyResources(Me.txtBankNameAra, "txtBankNameAra")
        Me.txtBankNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtBankNameAra.LinkedLabel = Nothing
        Me.txtBankNameAra.MaximumValue = Nothing
        Me.txtBankNameAra.MinimumValue = Nothing
        Me.txtBankNameAra.Name = "txtBankNameAra"
        Me.txtBankNameAra.OldValue = Nothing
        Me.txtBankNameAra.ReadOnly = true
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
        Me.floDataDisplay.Controls.Add(Me.lblBankCode)
        Me.floDataDisplay.Controls.Add(Me.txtBankCode)
        Me.floDataDisplay.Controls.Add(Me.lblBankName)
        Me.floDataDisplay.Controls.Add(Me.txtBankName)
        Me.floDataDisplay.Controls.Add(Me.lblBankNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtBankNameAra)
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
        'lblBankCode
        '
        Me.lblBankCode.DisplayOnly = true
        Me.lblBankCode.EditingMode = false
        resources.ApplyResources(Me.lblBankCode, "lblBankCode")
        Me.lblBankCode.Name = "lblBankCode"
        '
        'lblBankName
        '
        Me.lblBankName.DisplayOnly = true
        Me.lblBankName.EditingMode = false
        resources.ApplyResources(Me.lblBankName, "lblBankName")
        Me.lblBankName.Name = "lblBankName"
        '
        'lblBankNameAra
        '
        Me.lblBankNameAra.DisplayOnly = true
        Me.lblBankNameAra.EditingMode = false
        resources.ApplyResources(Me.lblBankNameAra, "lblBankNameAra")
        Me.lblBankNameAra.Name = "lblBankNameAra"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'BankEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "BankEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtBankCode As CTextBox
        Friend WithEvents txtBankName As CTextBox
        Friend WithEvents txtBankNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblBankCode As CLabel
        Friend WithEvents lblBankName As CLabel
        Friend WithEvents lblBankNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End Namespace