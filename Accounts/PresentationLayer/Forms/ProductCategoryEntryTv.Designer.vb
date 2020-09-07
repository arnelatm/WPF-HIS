Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductCategoryEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductCategoryEntryTv))
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtProductCategoryCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtProductCategoryName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtProductCategoryNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
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
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtProductCategoryCode
            '
            Me.txtProductCategoryCode.BackColor = System.Drawing.Color.White
            Me.txtProductCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductCategoryCode.ComputedValue = False
            Me.txtProductCategoryCode.CustomFormat = Nothing
            Me.txtProductCategoryCode.DataBoundControl = True
            Me.txtProductCategoryCode.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtProductCategoryCode, True)
            resources.ApplyResources(Me.txtProductCategoryCode, "txtProductCategoryCode")
            Me.txtProductCategoryCode.ForeColor = System.Drawing.Color.Black
            Me.txtProductCategoryCode.LinkedLabel = Nothing
            Me.txtProductCategoryCode.MaximumValue = Nothing
            Me.txtProductCategoryCode.MinimumValue = Nothing
            Me.txtProductCategoryCode.Name = "txtProductCategoryCode"
            Me.txtProductCategoryCode.OldValue = Nothing
            Me.txtProductCategoryCode.ReadOnly = True
            Me.txtProductCategoryCode.ValueIsMandatory = True
            '
            'txtProductCategoryName
            '
            Me.txtProductCategoryName.BackColor = System.Drawing.Color.White
            Me.txtProductCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductCategoryName.ComputedValue = False
            Me.txtProductCategoryName.CustomFormat = Nothing
            Me.txtProductCategoryName.DataBoundControl = True
            Me.txtProductCategoryName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtProductCategoryName, True)
            resources.ApplyResources(Me.txtProductCategoryName, "txtProductCategoryName")
            Me.txtProductCategoryName.ForeColor = System.Drawing.Color.Black
            Me.txtProductCategoryName.LinkedLabel = Nothing
            Me.txtProductCategoryName.MaximumValue = Nothing
            Me.txtProductCategoryName.MinimumValue = Nothing
            Me.txtProductCategoryName.Name = "txtProductCategoryName"
            Me.txtProductCategoryName.OldValue = Nothing
            Me.txtProductCategoryName.ReadOnly = True
            Me.txtProductCategoryName.ValueIsMandatory = True
            '
            'txtProductCategoryNameAra
            '
            Me.txtProductCategoryNameAra.BackColor = System.Drawing.Color.White
            Me.txtProductCategoryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductCategoryNameAra.ComputedValue = False
            Me.txtProductCategoryNameAra.CustomFormat = Nothing
            Me.txtProductCategoryNameAra.DataBoundControl = True
            Me.txtProductCategoryNameAra.EditingMode = False
            Me.txtProductCategoryNameAra.EnglishControl = Me.txtProductCategoryName
            Me.floDataDisplay.SetFlowBreak(Me.txtProductCategoryNameAra, True)
            resources.ApplyResources(Me.txtProductCategoryNameAra, "txtProductCategoryNameAra")
            Me.txtProductCategoryNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtProductCategoryNameAra.LinkedLabel = Nothing
            Me.txtProductCategoryNameAra.MaximumValue = Nothing
            Me.txtProductCategoryNameAra.MinimumValue = Nothing
            Me.txtProductCategoryNameAra.Name = "txtProductCategoryNameAra"
            Me.txtProductCategoryNameAra.OldValue = Nothing
            Me.txtProductCategoryNameAra.ReadOnly = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCode)
            Me.floDataDisplay.Controls.Add(Me.txtProductCategoryCode)
            Me.floDataDisplay.Controls.Add(Me.lblName)
            Me.floDataDisplay.Controls.Add(Me.txtProductCategoryName)
            Me.floDataDisplay.Controls.Add(Me.lblNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtProductCategoryNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'ProductCategoryEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "ProductCategoryEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtProductCategoryCode As CTextBox
        Friend WithEvents txtProductCategoryName As CTextBox
        Friend WithEvents txtProductCategoryNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End NameSpace