Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PhoneTypeEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PhoneTypeEntryTv))
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
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            Me.SplitContainer1.Size = New System.Drawing.Size(905, 183)
            Me.SplitContainer1.SplitterDistance = 300
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(300, 183)
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
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(199, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtPhoneTypeCode
            '
            Me.txtPhoneTypeCode.BackColor = System.Drawing.Color.White
            Me.txtPhoneTypeCode.BegFindValue = Nothing
            Me.txtPhoneTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhoneTypeCode.ComputedValue = False
            Me.txtPhoneTypeCode.CustomFormat = Nothing
            Me.txtPhoneTypeCode.DataBoundControl = True
            Me.txtPhoneTypeCode.EditingMode = False
            Me.txtPhoneTypeCode.EndFindValue = Nothing
            Me.txtPhoneTypeCode.FieldDescription = Nothing
            Me.txtPhoneTypeCode.FieldName = Nothing
            Me.txtPhoneTypeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhoneTypeCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeCode, True)
            Me.txtPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhoneTypeCode.ForeColor = System.Drawing.Color.Black
            Me.txtPhoneTypeCode.LinkedLabel = Nothing
            Me.txtPhoneTypeCode.Location = New System.Drawing.Point(199, 36)
            Me.txtPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhoneTypeCode.MaximumValue = Nothing
            Me.txtPhoneTypeCode.MinimumValue = Nothing
            Me.txtPhoneTypeCode.Name = "txtPhoneTypeCode"
            Me.txtPhoneTypeCode.OldValue = Nothing
            Me.txtPhoneTypeCode.ReadOnly = True
            Me.txtPhoneTypeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhoneTypeCode.Size = New System.Drawing.Size(100, 23)
            Me.txtPhoneTypeCode.TabIndex = 152
            Me.txtPhoneTypeCode.Translatable = False
            Me.txtPhoneTypeCode.ValueIsMandatory = True
            Me.txtPhoneTypeCode.ValueIsUnique = True
            '
            'txtPhoneTypeName
            '
            Me.txtPhoneTypeName.BackColor = System.Drawing.Color.White
            Me.txtPhoneTypeName.BegFindValue = Nothing
            Me.txtPhoneTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhoneTypeName.ComputedValue = False
            Me.txtPhoneTypeName.CustomFormat = Nothing
            Me.txtPhoneTypeName.DataBoundControl = True
            Me.txtPhoneTypeName.EditingMode = False
            Me.txtPhoneTypeName.EndFindValue = Nothing
            Me.txtPhoneTypeName.FieldDescription = Nothing
            Me.txtPhoneTypeName.FieldName = Nothing
            Me.txtPhoneTypeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhoneTypeName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeName, True)
            Me.txtPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhoneTypeName.ForeColor = System.Drawing.Color.Black
            Me.txtPhoneTypeName.LinkedLabel = Nothing
            Me.txtPhoneTypeName.Location = New System.Drawing.Point(199, 61)
            Me.txtPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhoneTypeName.MaximumValue = Nothing
            Me.txtPhoneTypeName.MinimumValue = Nothing
            Me.txtPhoneTypeName.Name = "txtPhoneTypeName"
            Me.txtPhoneTypeName.OldValue = Nothing
            Me.txtPhoneTypeName.ReadOnly = True
            Me.txtPhoneTypeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhoneTypeName.Size = New System.Drawing.Size(388, 23)
            Me.txtPhoneTypeName.TabIndex = 154
            Me.txtPhoneTypeName.Translatable = False
            Me.txtPhoneTypeName.ValueIsMandatory = True
            Me.txtPhoneTypeName.ValueIsUnique = True
            '
            'txtPhoneTypeNameAra
            '
            Me.txtPhoneTypeNameAra.BackColor = System.Drawing.Color.White
            Me.txtPhoneTypeNameAra.BegFindValue = Nothing
            Me.txtPhoneTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhoneTypeNameAra.ComputedValue = False
            Me.txtPhoneTypeNameAra.CustomFormat = Nothing
            Me.txtPhoneTypeNameAra.DataBoundControl = True
            Me.txtPhoneTypeNameAra.EditingMode = False
            Me.txtPhoneTypeNameAra.EndFindValue = Nothing
            Me.txtPhoneTypeNameAra.EnglishControl = Me.txtPhoneTypeName
            Me.txtPhoneTypeNameAra.FieldDescription = Nothing
            Me.txtPhoneTypeNameAra.FieldName = Nothing
            Me.txtPhoneTypeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhoneTypeNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPhoneTypeNameAra, True)
            Me.txtPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhoneTypeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPhoneTypeNameAra.LinkedLabel = Nothing
            Me.txtPhoneTypeNameAra.Location = New System.Drawing.Point(199, 86)
            Me.txtPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhoneTypeNameAra.MaximumValue = Nothing
            Me.txtPhoneTypeNameAra.MinimumValue = Nothing
            Me.txtPhoneTypeNameAra.Name = "txtPhoneTypeNameAra"
            Me.txtPhoneTypeNameAra.OldValue = Nothing
            Me.txtPhoneTypeNameAra.ReadOnly = True
            Me.txtPhoneTypeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPhoneTypeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhoneTypeNameAra.Size = New System.Drawing.Size(388, 23)
            Me.txtPhoneTypeNameAra.TabIndex = 156
            Me.txtPhoneTypeNameAra.Translatable = False
            Me.txtPhoneTypeNameAra.ValueIsUnique = True
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
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(199, 111)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(388, 60)
            Me.txtNotes.TabIndex = 3
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
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
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(598, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(598, 183)
            Me.floDataDisplay.TabIndex = 147
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(186, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Phone Type Id No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblPhoneTypeCode
            '
            Me.lblPhoneTypeCode.DisplayOnly = True
            Me.lblPhoneTypeCode.EditingMode = False
            Me.lblPhoneTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhoneTypeCode.Location = New System.Drawing.Point(11, 36)
            Me.lblPhoneTypeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhoneTypeCode.Name = "lblPhoneTypeCode"
            Me.lblPhoneTypeCode.Size = New System.Drawing.Size(186, 23)
            Me.lblPhoneTypeCode.TabIndex = 151
            Me.lblPhoneTypeCode.Text = "Phone Type Code"
            Me.lblPhoneTypeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPhoneTypeCode.Translatable = True
            '
            'lblPhoneTypeName
            '
            Me.lblPhoneTypeName.DisplayOnly = True
            Me.lblPhoneTypeName.EditingMode = False
            Me.lblPhoneTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhoneTypeName.Location = New System.Drawing.Point(11, 61)
            Me.lblPhoneTypeName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhoneTypeName.Name = "lblPhoneTypeName"
            Me.lblPhoneTypeName.Size = New System.Drawing.Size(186, 23)
            Me.lblPhoneTypeName.TabIndex = 153
            Me.lblPhoneTypeName.Text = "Phone Type Name"
            Me.lblPhoneTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPhoneTypeName.Translatable = True
            '
            'lblPhoneTypeNameAra
            '
            Me.lblPhoneTypeNameAra.DisplayOnly = True
            Me.lblPhoneTypeNameAra.EditingMode = False
            Me.lblPhoneTypeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhoneTypeNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblPhoneTypeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhoneTypeNameAra.Name = "lblPhoneTypeNameAra"
            Me.lblPhoneTypeNameAra.Size = New System.Drawing.Size(186, 23)
            Me.lblPhoneTypeNameAra.TabIndex = 155
            Me.lblPhoneTypeNameAra.Text = "Phone Type Name Arabic"
            Me.lblPhoneTypeNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPhoneTypeNameAra.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(11, 111)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(186, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'PhoneTypeEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(905, 236)
            Me.MinimumSize = New System.Drawing.Size(914, 265)
            Me.Name = "PhoneTypeEntryTv"
            Me.Text = ""
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
End Namespace