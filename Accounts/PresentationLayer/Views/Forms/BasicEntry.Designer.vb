Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BasicEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtNote = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtName, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNote, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtNote, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNameAra, 1, 3)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 57)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(577, 140)
            Me.TableLayoutPanel1.TabIndex = 5
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
            Me.TxtIdNo.FindEnabled = False
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(151, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(88, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.AutoSize = True
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(83, 17)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblCode
            '
            Me.lblCode.AutoSize = True
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCode.Location = New System.Drawing.Point(1, 26)
            Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(41, 17)
            Me.lblCode.TabIndex = 2
            Me.lblCode.Text = "Code"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCode.Translatable = True
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblName.Location = New System.Drawing.Point(1, 51)
            Me.lblName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(45, 17)
            Me.lblName.TabIndex = 3
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblName.Translatable = True
            '
            'lblNameAra
            '
            Me.lblNameAra.AutoSize = True
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNameAra.Location = New System.Drawing.Point(1, 76)
            Me.lblNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Size = New System.Drawing.Size(89, 17)
            Me.lblNameAra.TabIndex = 4
            Me.lblNameAra.Text = "Name Arabic"
            Me.lblNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNameAra.Translatable = True
            '
            'TxtCode
            '
            Me.TxtCode.BackColor = System.Drawing.Color.White
            Me.TxtCode.BegFindValue = Nothing
            Me.TxtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtCode.ComputedValue = False
            Me.TxtCode.CustomFormat = Nothing
            Me.TxtCode.DataBoundControl = True
            Me.TxtCode.EditingMode = True
            Me.TxtCode.EndFindValue = Nothing
            Me.TxtCode.FieldDescription = Nothing
            Me.TxtCode.FieldName = Nothing
            Me.TxtCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtCode.FindEnabled = False
            Me.TxtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtCode.ForeColor = System.Drawing.Color.Black
            Me.TxtCode.LinkedLabel = Nothing
            Me.TxtCode.Location = New System.Drawing.Point(151, 26)
            Me.TxtCode.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtCode.MaximumValue = Nothing
            Me.TxtCode.MinimumValue = Nothing
            Me.TxtCode.Name = "TxtCode"
            Me.TxtCode.OldValue = Nothing
            Me.TxtCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtCode.Size = New System.Drawing.Size(88, 23)
            Me.TxtCode.TabIndex = 5
            Me.TxtCode.Translatable = False
            '
            'TxtName
            '
            Me.TxtName.BackColor = System.Drawing.Color.White
            Me.TxtName.BegFindValue = Nothing
            Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtName, 2)
            Me.TxtName.ComputedValue = False
            Me.TxtName.CustomFormat = Nothing
            Me.TxtName.DataBoundControl = True
            Me.TxtName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtName.EditingMode = True
            Me.TxtName.EndFindValue = Nothing
            Me.TxtName.FieldDescription = Nothing
            Me.TxtName.FieldName = Nothing
            Me.TxtName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtName.FindEnabled = False
            Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtName.ForeColor = System.Drawing.Color.Black
            Me.TxtName.LinkedLabel = Nothing
            Me.TxtName.Location = New System.Drawing.Point(151, 51)
            Me.TxtName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtName.MaximumValue = Nothing
            Me.TxtName.MinimumValue = Nothing
            Me.TxtName.Name = "TxtName"
            Me.TxtName.OldValue = Nothing
            Me.TxtName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtName.Size = New System.Drawing.Size(425, 23)
            Me.TxtName.TabIndex = 6
            Me.TxtName.Translatable = False
            '
            'lblNote
            '
            Me.lblNote.AutoSize = True
            Me.lblNote.DisplayOnly = True
            Me.lblNote.EditingMode = False
            Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNote.Location = New System.Drawing.Point(1, 101)
            Me.lblNote.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(45, 17)
            Me.lblNote.TabIndex = 8
            Me.lblNote.Text = "Notes"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNote.Translatable = True
            '
            'TxtNote
            '
            Me.TxtNote.BackColor = System.Drawing.Color.White
            Me.TxtNote.BegFindValue = Nothing
            Me.TxtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNote, 2)
            Me.TxtNote.ComputedValue = False
            Me.TxtNote.CustomFormat = Nothing
            Me.TxtNote.DataBoundControl = True
            Me.TxtNote.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtNote.EditingMode = True
            Me.TxtNote.EndFindValue = Nothing
            Me.TxtNote.FieldDescription = Nothing
            Me.TxtNote.FieldName = Nothing
            Me.TxtNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtNote.FindEnabled = False
            Me.TxtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtNote.ForeColor = System.Drawing.Color.Black
            Me.TxtNote.LinkedLabel = Nothing
            Me.TxtNote.Location = New System.Drawing.Point(151, 101)
            Me.TxtNote.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtNote.MaximumValue = Nothing
            Me.TxtNote.MinimumValue = Nothing
            Me.TxtNote.Multiline = True
            Me.TxtNote.Name = "TxtNote"
            Me.TxtNote.OldValue = Nothing
            Me.TxtNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtNote.Size = New System.Drawing.Size(425, 38)
            Me.TxtNote.TabIndex = 9
            Me.TxtNote.Translatable = False
            '
            'txtNameAra
            '
            Me.txtNameAra.BackColor = System.Drawing.Color.White
            Me.txtNameAra.BegFindValue = Nothing
            Me.txtNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNameAra, 2)
            Me.txtNameAra.ComputedValue = False
            Me.txtNameAra.CustomFormat = Nothing
            Me.txtNameAra.DataBoundControl = True
            Me.txtNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNameAra.EditingMode = True
            Me.txtNameAra.EndFindValue = Nothing
            Me.txtNameAra.EnglishControl = Me.TxtName
            Me.txtNameAra.FieldDescription = Nothing
            Me.txtNameAra.FieldName = Nothing
            Me.txtNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNameAra.FindEnabled = False
            Me.txtNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtNameAra.LinkedLabel = Nothing
            Me.txtNameAra.Location = New System.Drawing.Point(151, 76)
            Me.txtNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNameAra.MaximumValue = Nothing
            Me.txtNameAra.MinimumValue = Nothing
            Me.txtNameAra.Name = "txtNameAra"
            Me.txtNameAra.OldValue = Nothing
            Me.txtNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNameAra.Size = New System.Drawing.Size(425, 23)
            Me.txtNameAra.TabIndex = 10
            Me.txtNameAra.Translatable = False
            '
            'BasicEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(601, 214)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "BasicEntry"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents TxtName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNote As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtNote As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
    End Class
End Namespace