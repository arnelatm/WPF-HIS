Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReligionEntryTv))
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReligionCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblReligionName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReligionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReligionName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 167)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(171, 23)
            Me.lblIdNo.TabIndex = 126
            Me.lblIdNo.Text = "Religion ID No"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(184, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 117
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReligionCode
            '
            Me.lblReligionCode.DisplayOnly = True
            Me.lblReligionCode.EditingMode = False
            Me.lblReligionCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReligionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReligionCode.Location = New System.Drawing.Point(11, 36)
            Me.lblReligionCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReligionCode.Name = "lblReligionCode"
            Me.lblReligionCode.Size = New System.Drawing.Size(171, 17)
            Me.lblReligionCode.TabIndex = 122
            Me.lblReligionCode.Text = "Religion Code"
            Me.lblReligionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(11, 111)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(171, 23)
            Me.lblNotes.TabIndex = 125
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblReligionNameAra
            '
            Me.lblReligionNameAra.DisplayOnly = True
            Me.lblReligionNameAra.EditingMode = False
            Me.lblReligionNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReligionNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReligionNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblReligionNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReligionNameAra.Name = "lblReligionNameAra"
            Me.lblReligionNameAra.Size = New System.Drawing.Size(171, 17)
            Me.lblReligionNameAra.TabIndex = 124
            Me.lblReligionNameAra.Text = "Religion Name Arabic"
            Me.lblReligionNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblReligionName
            '
            Me.lblReligionName.DisplayOnly = True
            Me.lblReligionName.EditingMode = False
            Me.lblReligionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReligionName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReligionName.Location = New System.Drawing.Point(11, 61)
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
            Me.txtReligionCode.ComputedValue = False
            Me.txtReligionCode.CustomFormat = Nothing
            Me.txtReligionCode.DataBoundControl = True
            Me.txtReligionCode.EditingMode = False
            Me.txtReligionCode.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtReligionCode, True)
            Me.txtReligionCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReligionCode.ForeColor = System.Drawing.Color.Black
            Me.txtReligionCode.LinkedLabel = Nothing
            Me.txtReligionCode.Location = New System.Drawing.Point(184, 36)
            Me.txtReligionCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReligionCode.MaximumValue = Nothing
            Me.txtReligionCode.MinimumValue = Nothing
            Me.txtReligionCode.Name = "txtReligionCode"
            Me.txtReligionCode.OldValue = Nothing
            Me.txtReligionCode.ReadOnly = True
            Me.txtReligionCode.Size = New System.Drawing.Size(62, 23)
            Me.txtReligionCode.TabIndex = 118
            Me.txtReligionCode.ValueIsMandatory = True
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
            Me.CFlowLayout1.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(184, 111)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(228, 44)
            Me.txtNotes.TabIndex = 121
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtReligionNameAra
            '
            Me.txtReligionNameAra.BackColor = System.Drawing.Color.White
            Me.txtReligionNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReligionNameAra.ComputedValue = False
            Me.txtReligionNameAra.CustomFormat = Nothing
            Me.txtReligionNameAra.DataBoundControl = True
            Me.txtReligionNameAra.EditingMode = False
            Me.txtReligionNameAra.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtReligionNameAra, True)
            Me.txtReligionNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReligionNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtReligionNameAra.LinkedLabel = Nothing
            Me.txtReligionNameAra.Location = New System.Drawing.Point(184, 86)
            Me.txtReligionNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReligionNameAra.MaximumValue = Nothing
            Me.txtReligionNameAra.MinimumValue = Nothing
            Me.txtReligionNameAra.Name = "txtReligionNameAra"
            Me.txtReligionNameAra.OldValue = Nothing
            Me.txtReligionNameAra.ReadOnly = True
            Me.txtReligionNameAra.Size = New System.Drawing.Size(228, 23)
            Me.txtReligionNameAra.TabIndex = 120
            Me.txtReligionNameAra.ValueIsMandatory = True
            '
            'txtReligionName
            '
            Me.txtReligionName.BackColor = System.Drawing.Color.White
            Me.txtReligionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReligionName.ComputedValue = False
            Me.txtReligionName.CustomFormat = Nothing
            Me.txtReligionName.DataBoundControl = True
            Me.txtReligionName.EditingMode = False
            Me.txtReligionName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtReligionName, True)
            Me.txtReligionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReligionName.ForeColor = System.Drawing.Color.Black
            Me.txtReligionName.LinkedLabel = Nothing
            Me.txtReligionName.Location = New System.Drawing.Point(184, 61)
            Me.txtReligionName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReligionName.MaximumValue = Nothing
            Me.txtReligionName.MinimumValue = Nothing
            Me.txtReligionName.Name = "txtReligionName"
            Me.txtReligionName.OldValue = Nothing
            Me.txtReligionName.ReadOnly = True
            Me.txtReligionName.Size = New System.Drawing.Size(228, 23)
            Me.txtReligionName.TabIndex = 119
            Me.txtReligionName.ValueIsMandatory = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblReligionCode)
            Me.CFlowLayout1.Controls.Add(Me.txtReligionCode)
            Me.CFlowLayout1.Controls.Add(Me.lblReligionName)
            Me.CFlowLayout1.Controls.Add(Me.txtReligionName)
            Me.CFlowLayout1.Controls.Add(Me.lblReligionNameAra)
            Me.CFlowLayout1.Controls.Add(Me.txtReligionNameAra)
            Me.CFlowLayout1.Controls.Add(Me.lblNotes)
            Me.CFlowLayout1.Controls.Add(Me.txtNotes)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Left
            Me.CFlowLayout1.Location = New System.Drawing.Point(300, 53)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.CFlowLayout1.Size = New System.Drawing.Size(428, 167)
            Me.CFlowLayout1.TabIndex = 127
            '
            'ReligionEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(729, 220)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.MinimumSize = New System.Drawing.Size(745, 259)
            Me.Name = "ReligionEntryTv"
            Me.Text = "Religion Entry"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
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