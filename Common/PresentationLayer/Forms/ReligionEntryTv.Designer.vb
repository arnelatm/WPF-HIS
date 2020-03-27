Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReligionEntryTv
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
        Me.lblIDNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReligionCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblReligionName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReligionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtReligionName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 25)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 186)
        '
        'lblIDNo
        '
        Me.lblIDNo.DisplayOnly = true
        Me.lblIDNo.EditingMode = false
        Me.lblIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIDNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIDNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIDNo.Name = "lblIDNo"
        Me.lblIDNo.Size = New System.Drawing.Size(171, 23)
        Me.lblIDNo.TabIndex = 126
        Me.lblIDNo.Text = "Religion ID No"
        Me.lblIDNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Location = New System.Drawing.Point(174, 1)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIDNo.TabIndex = 117
        Me.TxtIDNo.TabStop = false
        '
        'lblReligionCode
        '
        Me.lblReligionCode.DisplayOnly = true
        Me.lblReligionCode.EditingMode = false
        Me.lblReligionCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReligionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReligionCode.Location = New System.Drawing.Point(1, 26)
        Me.lblReligionCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReligionCode.Name = "lblReligionCode"
        Me.lblReligionCode.Size = New System.Drawing.Size(171, 17)
        Me.lblReligionCode.TabIndex = 122
        Me.lblReligionCode.Text = "Religion Code"
        Me.lblReligionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(1, 101)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(171, 23)
        Me.lblNotes.TabIndex = 125
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReligionNameAra
        '
        Me.lblReligionNameAra.DisplayOnly = true
        Me.lblReligionNameAra.EditingMode = false
        Me.lblReligionNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReligionNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReligionNameAra.Location = New System.Drawing.Point(1, 76)
        Me.lblReligionNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReligionNameAra.Name = "lblReligionNameAra"
        Me.lblReligionNameAra.Size = New System.Drawing.Size(171, 17)
        Me.lblReligionNameAra.TabIndex = 124
        Me.lblReligionNameAra.Text = "Religion Name Arabic"
        Me.lblReligionNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReligionName
        '
        Me.lblReligionName.DisplayOnly = true
        Me.lblReligionName.EditingMode = false
        Me.lblReligionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReligionName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReligionName.Location = New System.Drawing.Point(1, 51)
        Me.lblReligionName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReligionName.Name = "lblReligionName"
        Me.lblReligionName.Size = New System.Drawing.Size(171, 17)
        Me.lblReligionName.TabIndex = 123
        Me.lblReligionName.Text = "Religion Name"
        Me.lblReligionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReligionCode
        '
        Me.txtReligionCode.BackColor = System.Drawing.Color.White
        Me.txtReligionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReligionCode.ComputedValue = false
        Me.txtReligionCode.CustomFormat = Nothing
        Me.txtReligionCode.DataBoundControl = true
        Me.txtReligionCode.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtReligionCode, true)
        Me.txtReligionCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReligionCode.ForeColor = System.Drawing.Color.Black
        Me.txtReligionCode.LinkedLabel = Nothing
        Me.txtReligionCode.Location = New System.Drawing.Point(174, 26)
        Me.txtReligionCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReligionCode.Name = "txtReligionCode"
        Me.txtReligionCode.OldValue = Nothing
        Me.txtReligionCode.Size = New System.Drawing.Size(62, 23)
        Me.txtReligionCode.TabIndex = 118
        Me.txtReligionCode.ValueIsMandatory = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtNotes, true)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(174, 101)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(228, 44)
        Me.txtNotes.TabIndex = 121
        Me.txtNotes.ValueIsMandatory = true
        '
        'txtReligionNameAra
        '
        Me.txtReligionNameAra.BackColor = System.Drawing.Color.White
        Me.txtReligionNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReligionNameAra.ComputedValue = false
        Me.txtReligionNameAra.CustomFormat = Nothing
        Me.txtReligionNameAra.DataBoundControl = true
        Me.txtReligionNameAra.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtReligionNameAra, true)
        Me.txtReligionNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReligionNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtReligionNameAra.LinkedLabel = Nothing
        Me.txtReligionNameAra.Location = New System.Drawing.Point(174, 76)
        Me.txtReligionNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReligionNameAra.Name = "txtReligionNameAra"
        Me.txtReligionNameAra.OldValue = Nothing
        Me.txtReligionNameAra.Size = New System.Drawing.Size(228, 23)
        Me.txtReligionNameAra.TabIndex = 120
        Me.txtReligionNameAra.ValueIsMandatory = true
        '
        'txtReligionName
        '
        Me.txtReligionName.BackColor = System.Drawing.Color.White
        Me.txtReligionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReligionName.ComputedValue = false
        Me.txtReligionName.CustomFormat = Nothing
        Me.txtReligionName.DataBoundControl = true
        Me.txtReligionName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtReligionName, true)
        Me.txtReligionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReligionName.ForeColor = System.Drawing.Color.Black
        Me.txtReligionName.LinkedLabel = Nothing
        Me.txtReligionName.Location = New System.Drawing.Point(174, 51)
        Me.txtReligionName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReligionName.Name = "txtReligionName"
        Me.txtReligionName.OldValue = Nothing
        Me.txtReligionName.Size = New System.Drawing.Size(228, 23)
        Me.txtReligionName.TabIndex = 119
        Me.txtReligionName.ValueIsMandatory = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIDNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIDNo)
        Me.CFlowLayout1.Controls.Add(Me.lblReligionCode)
        Me.CFlowLayout1.Controls.Add(Me.txtReligionCode)
        Me.CFlowLayout1.Controls.Add(Me.lblReligionName)
        Me.CFlowLayout1.Controls.Add(Me.txtReligionName)
        Me.CFlowLayout1.Controls.Add(Me.lblReligionNameAra)
        Me.CFlowLayout1.Controls.Add(Me.txtReligionNameAra)
        Me.CFlowLayout1.Controls.Add(Me.lblNotes)
        Me.CFlowLayout1.Controls.Add(Me.txtNotes)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CFlowLayout1.Location = New System.Drawing.Point(308, 25)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(419, 186)
        Me.CFlowLayout1.TabIndex = 127
        '
        'ReligionEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(727, 211)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "ReligionEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIDNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIDNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblReligionCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblReligionNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblReligionName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtReligionCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtReligionNameAra As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtReligionName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    End Class
End Namespace