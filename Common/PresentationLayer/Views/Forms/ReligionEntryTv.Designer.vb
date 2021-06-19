Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReligionEntryTv
        Inherits CFormEntryTvNew

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
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReligionCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReligionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReligionName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReligionName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReligionNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
            Me.SplitContainer1.Size = New System.Drawing.Size(659, 183)
            Me.SplitContainer1.SplitterDistance = 219
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(219, 183)
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
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.CFlowLayout1.Size = New System.Drawing.Size(436, 183)
            Me.CFlowLayout1.TabIndex = 128
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
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 117
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
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
            Me.lblReligionCode.Translatable = True
            '
            'txtReligionCode
            '
            Me.txtReligionCode.BackColor = System.Drawing.Color.White
            Me.txtReligionCode.BegFindValue = Nothing
            Me.txtReligionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReligionCode.ComputedValue = False
            Me.txtReligionCode.CustomFormat = Nothing
            Me.txtReligionCode.DataBoundControl = True
            Me.txtReligionCode.EditingMode = False
            Me.txtReligionCode.EndFindValue = Nothing
            Me.txtReligionCode.FieldDescription = Nothing
            Me.txtReligionCode.FieldName = Nothing
            Me.txtReligionCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.txtReligionCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReligionCode.Size = New System.Drawing.Size(62, 23)
            Me.txtReligionCode.TabIndex = 118
            Me.txtReligionCode.Translatable = False
            Me.txtReligionCode.ValueIsMandatory = True
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
            Me.lblReligionName.Translatable = True
            '
            'txtReligionName
            '
            Me.txtReligionName.BackColor = System.Drawing.Color.White
            Me.txtReligionName.BegFindValue = Nothing
            Me.txtReligionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReligionName.ComputedValue = False
            Me.txtReligionName.CustomFormat = Nothing
            Me.txtReligionName.DataBoundControl = True
            Me.txtReligionName.EditingMode = False
            Me.txtReligionName.EndFindValue = Nothing
            Me.txtReligionName.FieldDescription = Nothing
            Me.txtReligionName.FieldName = Nothing
            Me.txtReligionName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.txtReligionName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReligionName.Size = New System.Drawing.Size(228, 23)
            Me.txtReligionName.TabIndex = 119
            Me.txtReligionName.Translatable = False
            Me.txtReligionName.ValueIsMandatory = True
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
            Me.lblReligionNameAra.Translatable = True
            '
            'txtReligionNameAra
            '
            Me.txtReligionNameAra.BackColor = System.Drawing.Color.White
            Me.txtReligionNameAra.BegFindValue = Nothing
            Me.txtReligionNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReligionNameAra.ComputedValue = False
            Me.txtReligionNameAra.CustomFormat = Nothing
            Me.txtReligionNameAra.DataBoundControl = True
            Me.txtReligionNameAra.EditingMode = False
            Me.txtReligionNameAra.EndFindValue = Nothing
            Me.txtReligionNameAra.FieldDescription = Nothing
            Me.txtReligionNameAra.FieldName = Nothing
            Me.txtReligionNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.txtReligionNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReligionNameAra.Size = New System.Drawing.Size(228, 23)
            Me.txtReligionNameAra.TabIndex = 120
            Me.txtReligionNameAra.Translatable = False
            Me.txtReligionNameAra.ValueIsMandatory = True
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
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
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
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(228, 44)
            Me.txtNotes.TabIndex = 121
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'ReligionEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(659, 236)
            Me.MinimumSize = New System.Drawing.Size(675, 259)
            Me.Name = "ReligionEntryTv"
            Me.Text = "Religion Entry"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblReligionCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtReligionCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblReligionName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtReligionName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblReligionNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtReligionNameAra As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace