Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PhoneTypeEntryTv
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
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPhoneTypeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPhoneTypeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPhoneTypeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPhoneTypeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPhoneTypeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPhoneTypeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 57)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 179)
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
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(199, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        '
        'txtPhoneTypeCode
        '
        Me.txtPhoneTypeCode.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeCode.ComputedValue = false
        Me.txtPhoneTypeCode.CustomFormat = Nothing
        Me.txtPhoneTypeCode.DataBoundControl = true
        Me.txtPhoneTypeCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeCode, true)
        Me.txtPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeCode.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeCode.LinkedLabel = Nothing
        Me.txtPhoneTypeCode.Location = New System.Drawing.Point(199, 36)
        Me.txtPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeCode.Name = "txtPhoneTypeCode"
        Me.txtPhoneTypeCode.OldValue = Nothing
        Me.txtPhoneTypeCode.Size = New System.Drawing.Size(100, 23)
        Me.txtPhoneTypeCode.TabIndex = 152
        Me.txtPhoneTypeCode.ValueIsMandatory = true
        '
        'txtPhoneTypeName
        '
        Me.txtPhoneTypeName.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeName.ComputedValue = false
        Me.txtPhoneTypeName.CustomFormat = Nothing
        Me.txtPhoneTypeName.DataBoundControl = true
        Me.txtPhoneTypeName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeName, true)
        Me.txtPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeName.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeName.LinkedLabel = Nothing
        Me.txtPhoneTypeName.Location = New System.Drawing.Point(199, 61)
        Me.txtPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeName.Name = "txtPhoneTypeName"
        Me.txtPhoneTypeName.OldValue = Nothing
        Me.txtPhoneTypeName.Size = New System.Drawing.Size(388, 23)
        Me.txtPhoneTypeName.TabIndex = 154
        Me.txtPhoneTypeName.ValueIsMandatory = true
        '
        'txtPhoneTypeNameAra
        '
        Me.txtPhoneTypeNameAra.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeNameAra.ComputedValue = false
        Me.txtPhoneTypeNameAra.CustomFormat = Nothing
        Me.txtPhoneTypeNameAra.DataBoundControl = true
        Me.txtPhoneTypeNameAra.EditingMode = false
        Me.txtPhoneTypeNameAra.EnglishControl = Me.txtPhoneTypeName
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeNameAra, true)
        Me.txtPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeNameAra.LinkedLabel = Nothing
        Me.txtPhoneTypeNameAra.Location = New System.Drawing.Point(199, 86)
        Me.txtPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeNameAra.Name = "txtPhoneTypeNameAra"
        Me.txtPhoneTypeNameAra.OldValue = Nothing
        Me.txtPhoneTypeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhoneTypeNameAra.Size = New System.Drawing.Size(388, 23)
        Me.txtPhoneTypeNameAra.TabIndex = 156
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(199, 111)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(388, 60)
        Me.txtNotes.TabIndex = 3
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeCode)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeCode)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeName)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeName)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.floDataDisplay.Location = New System.Drawing.Point(300, 57)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(598, 180)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(607, 180)
        Me.floDataDisplay.TabIndex = 147
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(186, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Phone Type Id No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeCode
        '
        Me.lblPhoneTypeCode.DisplayOnly = true
        Me.lblPhoneTypeCode.EditingMode = false
        Me.lblPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeCode.Location = New System.Drawing.Point(11, 36)
        Me.lblPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeCode.Name = "lblPhoneTypeCode"
        Me.lblPhoneTypeCode.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeCode.TabIndex = 151
        Me.lblPhoneTypeCode.Text = "Phone Type Code"
        Me.lblPhoneTypeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeName
        '
        Me.lblPhoneTypeName.DisplayOnly = true
        Me.lblPhoneTypeName.EditingMode = false
        Me.lblPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeName.Location = New System.Drawing.Point(11, 61)
        Me.lblPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeName.Name = "lblPhoneTypeName"
        Me.lblPhoneTypeName.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeName.TabIndex = 153
        Me.lblPhoneTypeName.Text = "Phone Type Name"
        Me.lblPhoneTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeNameAra
        '
        Me.lblPhoneTypeNameAra.DisplayOnly = true
        Me.lblPhoneTypeNameAra.EditingMode = false
        Me.lblPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeNameAra.Location = New System.Drawing.Point(11, 86)
        Me.lblPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeNameAra.Name = "lblPhoneTypeNameAra"
        Me.lblPhoneTypeNameAra.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeNameAra.TabIndex = 155
        Me.lblPhoneTypeNameAra.Text = "Phone Type Name Arabic"
        Me.lblPhoneTypeNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.Location = New System.Drawing.Point(11, 111)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(186, 23)
        Me.lblNotes.TabIndex = 159
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PhoneTypeEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(905, 236)
        Me.Controls.Add(Me.floDataDisplay)
        Me.MinimumSize = New System.Drawing.Size(914, 265)
        Me.Name = "PhoneTypeEntryTv"
        Me.Text = "Phone Type Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPhoneTypeCode As CTextBox
        Friend WithEvents txtPhoneTypeName As CTextBox
        Friend WithEvents txtPhoneTypeNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPhoneTypeCode As CLabel
        Friend WithEvents lblPhoneTypeName As CLabel
        Friend WithEvents lblPhoneTypeNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End NameSpace