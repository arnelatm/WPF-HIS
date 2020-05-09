Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SecurityObjectEntryTv
        Inherits CFormEntryTv

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
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = true
            Me.TxtIdNo.TabStop = false
            '
            'txtSecurityObjectName
            '
            Me.txtSecurityObjectName.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectName.ComputedValue = false
            Me.txtSecurityObjectName.CustomFormat = Nothing
            Me.txtSecurityObjectName.DataBoundControl = true
            Me.txtSecurityObjectName.EditingMode = false
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectName, true)
            resources.ApplyResources(Me.txtSecurityObjectName, "txtSecurityObjectName")
            Me.txtSecurityObjectName.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectName.LinkedLabel = Nothing
            Me.txtSecurityObjectName.Name = "txtSecurityObjectName"
            Me.txtSecurityObjectName.OldValue = Nothing
            Me.txtSecurityObjectName.ValueIsMandatory = true
            '
            'txtSecurityObjectNameAra
            '
            Me.txtSecurityObjectNameAra.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectNameAra.ComputedValue = false
            Me.txtSecurityObjectNameAra.CustomFormat = Nothing
            Me.txtSecurityObjectNameAra.DataBoundControl = true
            Me.txtSecurityObjectNameAra.EditingMode = false
            Me.txtSecurityObjectNameAra.EnglishControl = Me.txtSecurityObjectName
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectNameAra, true)
            resources.ApplyResources(Me.txtSecurityObjectNameAra, "txtSecurityObjectNameAra")
            Me.txtSecurityObjectNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectNameAra.LinkedLabel = Nothing
            Me.txtSecurityObjectNameAra.Name = "txtSecurityObjectNameAra"
            Me.txtSecurityObjectNameAra.OldValue = Nothing
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
            Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectName)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectName)
            Me.floDataDisplay.Controls.Add(Me.lblSecurityObjectNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
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
            'lblSecurityObjectName
            '
            Me.lblSecurityObjectName.DisplayOnly = true
            Me.lblSecurityObjectName.EditingMode = false
            resources.ApplyResources(Me.lblSecurityObjectName, "lblSecurityObjectName")
            Me.lblSecurityObjectName.Name = "lblSecurityObjectName"
            '
            'lblSecurityObjectNameAra
            '
            Me.lblSecurityObjectNameAra.DisplayOnly = true
            Me.lblSecurityObjectNameAra.EditingMode = false
            resources.ApplyResources(Me.lblSecurityObjectNameAra, "lblSecurityObjectNameAra")
            Me.lblSecurityObjectNameAra.Name = "lblSecurityObjectNameAra"
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = true
            Me.lblParentIdNo.EditingMode = false
            resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
            Me.lblParentIdNo.Name = "lblParentIdNo"
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.ChangingSearchValueOnly = false
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.DropDownHeight = 200
            Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacParentIdNo.EditingMode = false
            Me.cacParentIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = true
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = false
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = false
            Me.cacParentIdNo.SearchAnywhere = false
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = false
            Me.cacParentIdNo.ValueIsNullable = false
            Me.cacParentIdNo.ValueIsNumeric = false
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = true
            Me.lblNotes.EditingMode = false
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'SecurityObjectEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "SecurityObjectEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
            Me.floDataDisplay.ResumeLayout(false)
            Me.floDataDisplay.PerformLayout
            Me.ResumeLayout(false)
            Me.PerformLayout

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtSecurityObjectName As CTextBox
        Friend WithEvents txtSecurityObjectNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblSecurityObjectName As CLabel
        Friend WithEvents lblSecurityObjectNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents cacParentIdNo As CaComboBox
    End Class
End NameSpace