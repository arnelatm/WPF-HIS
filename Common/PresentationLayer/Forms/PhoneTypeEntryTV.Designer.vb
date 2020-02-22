Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PhoneTypeEntryTv
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
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.RightToLeftLayout = false
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 194)
        '
        'TxtIDNo
        '
        Me.TxtIDNo.AcceptsReturn = false
        Me.TxtIDNo.AcceptsTab = false
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Location = New System.Drawing.Point(189, 1)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.EditingMode = true
        Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIDNo.TabIndex = 0
        Me.TxtIDNo.TabStop = false
        Me.TxtIDNo.DisplayOnly = true
        '
        'txtPhoneTypeCode
        '
        Me.txtPhoneTypeCode.AcceptsReturn = false
        Me.txtPhoneTypeCode.AcceptsTab = false
        Me.txtPhoneTypeCode.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeCode.ComputedValue = false
        Me.txtPhoneTypeCode.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeCode, true)
        Me.txtPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeCode.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeCode.LinkedLabel = Nothing
        Me.txtPhoneTypeCode.Location = New System.Drawing.Point(189, 26)
        Me.txtPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeCode.Name = "txtPhoneTypeCode"
        Me.txtPhoneTypeCode.EditingMode = false
        Me.txtPhoneTypeCode.Size = New System.Drawing.Size(100, 23)
        Me.txtPhoneTypeCode.TabIndex = 152
        Me.txtPhoneTypeCode.ValueIsMandatory = true
        '
        'txtPhoneTypeName
        '
        Me.txtPhoneTypeName.AcceptsReturn = false
        Me.txtPhoneTypeName.AcceptsTab = false
        Me.txtPhoneTypeName.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeName.ComputedValue = false
        Me.txtPhoneTypeName.DataBoundControl = true
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeName, true)
        Me.txtPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeName.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeName.LinkedLabel = Nothing
        Me.txtPhoneTypeName.Location = New System.Drawing.Point(189, 51)
        Me.txtPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeName.Name = "txtPhoneTypeName"
        Me.txtPhoneTypeName.EditingMode = false
        Me.txtPhoneTypeName.Size = New System.Drawing.Size(388, 23)
        Me.txtPhoneTypeName.TabIndex = 154
        Me.txtPhoneTypeName.ValueIsMandatory = true
        '
        'txtPhoneTypeNameAra
        '
        Me.txtPhoneTypeNameAra.AcceptsReturn = false
        Me.txtPhoneTypeNameAra.AcceptsTab = false
        Me.txtPhoneTypeNameAra.BackColor = System.Drawing.Color.White
        Me.txtPhoneTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoneTypeNameAra.ComputedValue = false
        Me.txtPhoneTypeNameAra.DataBoundControl = true
        Me.txtPhoneTypeNameAra.EnglishControl = Me.txtPhoneTypeName
        Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeNameAra, true)
        Me.txtPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhoneTypeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPhoneTypeNameAra.LinkedLabel = Nothing
        Me.txtPhoneTypeNameAra.Location = New System.Drawing.Point(189, 76)
        Me.txtPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneTypeNameAra.Name = "txtPhoneTypeNameAra"
        Me.txtPhoneTypeNameAra.EditingMode = false
        Me.txtPhoneTypeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhoneTypeNameAra.Size = New System.Drawing.Size(388, 23)
        Me.txtPhoneTypeNameAra.TabIndex = 156
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = false
        Me.txtNotes.AcceptsTab = false
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(189, 101)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.EditingMode = false
        Me.txtNotes.Size = New System.Drawing.Size(388, 60)
        Me.txtNotes.TabIndex = 3
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeCode)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeCode)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeName)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeName)
        Me.floDataDisplay.Controls.Add(Me.lblPhoneTypeNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtPhoneTypeNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Location = New System.Drawing.Point(309, 3)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Size = New System.Drawing.Size(587, 180)
        Me.floDataDisplay.TabIndex = 147
        '
        'lblIdNo
        '
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(186, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Phone Type Id No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeCode
        '
        Me.lblPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeCode.Location = New System.Drawing.Point(1, 26)
        Me.lblPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeCode.Name = "lblPhoneTypeCode"
        Me.lblPhoneTypeCode.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeCode.TabIndex = 151
        Me.lblPhoneTypeCode.Text = "Phone Type Code"
        Me.lblPhoneTypeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeName
        '
        Me.lblPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeName.Location = New System.Drawing.Point(1, 51)
        Me.lblPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeName.Name = "lblPhoneTypeName"
        Me.lblPhoneTypeName.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeName.TabIndex = 153
        Me.lblPhoneTypeName.Text = "Phone Type Name"
        Me.lblPhoneTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhoneTypeNameAra
        '
        Me.lblPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhoneTypeNameAra.Location = New System.Drawing.Point(1, 76)
        Me.lblPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneTypeNameAra.Name = "lblPhoneTypeNameAra"
        Me.lblPhoneTypeNameAra.Size = New System.Drawing.Size(186, 23)
        Me.lblPhoneTypeNameAra.TabIndex = 155
        Me.lblPhoneTypeNameAra.Text = "Phone Type Name Arabic"
        Me.lblPhoneTypeNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.Location = New System.Drawing.Point(1, 101)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(186, 23)
        Me.lblNotes.TabIndex = 159
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PhoneTypeEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(897, 251)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PhoneTypeEntryTv"
        Me.Text = "Branches Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIDNo As CTextBox
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