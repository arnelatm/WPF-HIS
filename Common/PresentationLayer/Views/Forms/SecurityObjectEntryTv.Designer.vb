Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms


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
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSecurityObjectCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSecurityObjectName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSecurityObjectNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
            Me.TxtIdNo.FindEnabled = True
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
            'txtSecurityObjectName
            '
            Me.txtSecurityObjectName.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectName.ComputedValue = False
            Me.txtSecurityObjectName.CustomFormat = Nothing
            Me.txtSecurityObjectName.DataBoundControl = True
            Me.txtSecurityObjectName.EditingMode = False
            Me.txtSecurityObjectName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectName, True)
            resources.ApplyResources(Me.txtSecurityObjectName, "txtSecurityObjectName")
            Me.txtSecurityObjectName.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectName.LinkedLabel = Nothing
            Me.txtSecurityObjectName.MaximumValue = Nothing
            Me.txtSecurityObjectName.MinimumValue = Nothing
            Me.txtSecurityObjectName.Name = "txtSecurityObjectName"
            Me.txtSecurityObjectName.OldValue = Nothing
            Me.txtSecurityObjectName.ReadOnly = True
            Me.txtSecurityObjectName.ValueIsMandatory = True
            '
            'txtSecurityObjectNameAra
            '
            Me.txtSecurityObjectNameAra.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectNameAra.ComputedValue = False
            Me.txtSecurityObjectNameAra.CustomFormat = Nothing
            Me.txtSecurityObjectNameAra.DataBoundControl = True
            Me.txtSecurityObjectNameAra.EditingMode = False
            Me.txtSecurityObjectNameAra.EnglishControl = Me.txtSecurityObjectName
            Me.txtSecurityObjectNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectNameAra, True)
            resources.ApplyResources(Me.txtSecurityObjectNameAra, "txtSecurityObjectNameAra")
            Me.txtSecurityObjectNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectNameAra.LinkedLabel = Nothing
            Me.txtSecurityObjectNameAra.MaximumValue = Nothing
            Me.txtSecurityObjectNameAra.MinimumValue = Nothing
            Me.txtSecurityObjectNameAra.Name = "txtSecurityObjectNameAra"
            Me.txtSecurityObjectNameAra.OldValue = Nothing
            Me.txtSecurityObjectNameAra.ReadOnly = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.FindEnabled = True
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
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtSecurityObjectCode)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'txtSecurityObjectCode
            '
            Me.txtSecurityObjectCode.BackColor = System.Drawing.Color.White
            Me.txtSecurityObjectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSecurityObjectCode.ComputedValue = False
            Me.txtSecurityObjectCode.CustomFormat = Nothing
            Me.txtSecurityObjectCode.DataBoundControl = True
            Me.txtSecurityObjectCode.EditingMode = False
            Me.txtSecurityObjectCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSecurityObjectCode, True)
            resources.ApplyResources(Me.txtSecurityObjectCode, "txtSecurityObjectCode")
            Me.txtSecurityObjectCode.ForeColor = System.Drawing.Color.Black
            Me.txtSecurityObjectCode.LinkedLabel = Nothing
            Me.txtSecurityObjectCode.MaximumValue = Nothing
            Me.txtSecurityObjectCode.MinimumValue = Nothing
            Me.txtSecurityObjectCode.Name = "txtSecurityObjectCode"
            Me.txtSecurityObjectCode.OldValue = Nothing
            Me.txtSecurityObjectCode.ReadOnly = True
            Me.txtSecurityObjectCode.ValueIsMandatory = True
            '
            'lblSecurityObjectName
            '
            Me.lblSecurityObjectName.DisplayOnly = True
            Me.lblSecurityObjectName.EditingMode = False
            resources.ApplyResources(Me.lblSecurityObjectName, "lblSecurityObjectName")
            Me.lblSecurityObjectName.Name = "lblSecurityObjectName"
            '
            'lblSecurityObjectNameAra
            '
            Me.lblSecurityObjectNameAra.DisplayOnly = True
            Me.lblSecurityObjectNameAra.EditingMode = False
            resources.ApplyResources(Me.lblSecurityObjectNameAra, "lblSecurityObjectNameAra")
            Me.lblSecurityObjectNameAra.Name = "lblSecurityObjectNameAra"
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
            Me.lblParentIdNo.Name = "lblParentIdNo"
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cacParentIdNo, "cacParentIdNo")
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.SearchAnywhere = False
            Me.cacParentIdNo.SearchField = Nothing
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
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
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtSecurityObjectCode As CTextBox
    End Class
End NameSpace