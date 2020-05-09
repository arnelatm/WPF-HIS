Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CategoryEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoryEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtCategoryCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCategoryName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCategoryNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCategoryCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCategoryName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCategoryNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        'txtCategoryCode
        '
        Me.txtCategoryCode.BackColor = System.Drawing.Color.White
        Me.txtCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryCode.ComputedValue = false
        Me.txtCategoryCode.CustomFormat = Nothing
        Me.txtCategoryCode.DataBoundControl = true
        Me.txtCategoryCode.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryCode, true)
        resources.ApplyResources(Me.txtCategoryCode, "txtCategoryCode")
        Me.txtCategoryCode.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryCode.LinkedLabel = Nothing
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.OldValue = Nothing
        Me.txtCategoryCode.ReadOnly = true
        Me.txtCategoryCode.ValueIsMandatory = true
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BackColor = System.Drawing.Color.White
        Me.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryName.ComputedValue = false
        Me.txtCategoryName.CustomFormat = Nothing
        Me.txtCategoryName.DataBoundControl = true
        Me.txtCategoryName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryName, true)
        resources.ApplyResources(Me.txtCategoryName, "txtCategoryName")
        Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryName.LinkedLabel = Nothing
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.OldValue = Nothing
        Me.txtCategoryName.ValueIsMandatory = true
        '
        'txtCategoryNameAra
        '
        Me.txtCategoryNameAra.BackColor = System.Drawing.Color.White
        Me.txtCategoryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryNameAra.ComputedValue = false
        Me.txtCategoryNameAra.CustomFormat = Nothing
        Me.txtCategoryNameAra.DataBoundControl = true
        Me.txtCategoryNameAra.EditingMode = false
        Me.txtCategoryNameAra.EnglishControl = Me.txtCategoryName
        Me.floDataDisplay.SetFlowBreak(Me.txtCategoryNameAra, true)
        resources.ApplyResources(Me.txtCategoryNameAra, "txtCategoryNameAra")
        Me.txtCategoryNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryNameAra.LinkedLabel = Nothing
        Me.txtCategoryNameAra.Name = "txtCategoryNameAra"
        Me.txtCategoryNameAra.OldValue = Nothing
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
        Me.floDataDisplay.Controls.Add(Me.lblCategoryCode)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryCode)
        Me.floDataDisplay.Controls.Add(Me.lblCategoryName)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryName)
        Me.floDataDisplay.Controls.Add(Me.lblCategoryNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtCategoryNameAra)
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
        'lblCategoryCode
        '
        Me.lblCategoryCode.DisplayOnly = true
        Me.lblCategoryCode.EditingMode = false
        resources.ApplyResources(Me.lblCategoryCode, "lblCategoryCode")
        Me.lblCategoryCode.Name = "lblCategoryCode"
        '
        'lblCategoryName
        '
        Me.lblCategoryName.DisplayOnly = true
        Me.lblCategoryName.EditingMode = false
        resources.ApplyResources(Me.lblCategoryName, "lblCategoryName")
        Me.lblCategoryName.Name = "lblCategoryName"
        '
        'lblCategoryNameAra
        '
        Me.lblCategoryNameAra.DisplayOnly = true
        Me.lblCategoryNameAra.EditingMode = false
        resources.ApplyResources(Me.lblCategoryNameAra, "lblCategoryNameAra")
        Me.lblCategoryNameAra.Name = "lblCategoryNameAra"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'CategoryEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "CategoryEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtCategoryCode As CTextBox
        Friend WithEvents txtCategoryName As CTextBox
        Friend WithEvents txtCategoryNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCategoryCode As CLabel
        Friend WithEvents lblCategoryName As CLabel
        Friend WithEvents lblCategoryNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End NameSpace