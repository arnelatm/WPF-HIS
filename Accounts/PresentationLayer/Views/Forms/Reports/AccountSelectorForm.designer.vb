Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountSelectorForm
        Inherits DFormBasic

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
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.floButtons = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.floButtons.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 21)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(146, 20)
            Me.lblIdNo.TabIndex = 22
            Me.lblIdNo.Text = "Posting Account:"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'cboIdNo
            '
            Me.cboIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboIdNo.BackColor = System.Drawing.Color.White
            Me.cboIdNo.BegFindValue = Nothing
            Me.cboIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboIdNo, 3)
            Me.cboIdNo.CurrentSearchTerm = ""
            Me.cboIdNo.DataValue = Nothing
            Me.cboIdNo.DefaultValue = Nothing
            Me.cboIdNo.DisplayMember = "Name"
            Me.cboIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboIdNo.DropDownHeight = 21
            Me.cboIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboIdNo.Editable = True
            Me.cboIdNo.EditingMode = False
            Me.cboIdNo.EndFindValue = Nothing
            Me.cboIdNo.FieldDescription = Nothing
            Me.cboIdNo.FieldName = Nothing
            Me.cboIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboIdNo.FindEnabled = False
            Me.cboIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboIdNo.FormattingEnabled = True
            Me.cboIdNo.HideWhenNotEditingOrAdding = False
            Me.cboIdNo.IgnoreCase = False
            Me.cboIdNo.LimitToList = False
            Me.cboIdNo.LinkedLabel = Nothing
            Me.cboIdNo.Location = New System.Drawing.Point(149, 21)
            Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboIdNo.MaxDropDownItems = 1
            Me.cboIdNo.Name = "cboIdNo"
            Me.cboIdNo.OldValue = 0
            Me.cboIdNo.OriginalDataSource = Nothing
            Me.cboIdNo.OriginalList = Nothing
            Me.cboIdNo.OverrideDropDownStyleList = False
            Me.cboIdNo.PreviousSearchTerm = Nothing
            Me.cboIdNo.Size = New System.Drawing.Size(502, 21)
            Me.cboIdNo.SuggestBoxHeight = 200
            Me.cboIdNo.SuggestCharCount = 0
            Me.cboIdNo.TabIndex = 25
            Me.cboIdNo.TextToSearch = Nothing
            Me.cboIdNo.Translatable = False
            Me.cboIdNo.ValueIsMandatory = False
            Me.cboIdNo.ValueIsNullable = False
            Me.cboIdNo.ValueIsNumeric = False
            Me.cboIdNo.ValueMember = "IdNo"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblTitle)
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout1.Location = New System.Drawing.Point(9, 24)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(2)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(659, 208)
            Me.CFlowLayout1.TabIndex = 26
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblTitle.DisplayOnly = True
            Me.lblTitle.EditingMode = False
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.lblTitle.Location = New System.Drawing.Point(1, 1)
            Me.lblTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(658, 20)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Payroll Posting"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblTitle.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.floButtons, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 3)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 24)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(652, 179)
            Me.TableLayoutPanel1.TabIndex = 30
            '
            'floButtons
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.floButtons, 4)
            Me.floButtons.Controls.Add(Me.btnCancel)
            Me.floButtons.Controls.Add(Me.btnOk)
            Me.floButtons.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floButtons.Location = New System.Drawing.Point(2, 140)
            Me.floButtons.Margin = New System.Windows.Forms.Padding(2)
            Me.floButtons.Name = "floButtons"
            Me.floButtons.Padding = New System.Windows.Forms.Padding(225, 0, 0, 0)
            Me.floButtons.Size = New System.Drawing.Size(648, 37)
            Me.floButtons.TabIndex = 26
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
            Me.MyErrorProvider.SetIconAlignment(Me.btnCancel, System.Windows.Forms.ErrorIconAlignment.BottomLeft)
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(227, 2)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.btnCancel.Size = New System.Drawing.Size(68, 28)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(299, 2)
            Me.btnOk.Margin = New System.Windows.Forms.Padding(2)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(68, 28)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 4)
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 64)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(650, 41)
            Me.CLabel1.TabIndex = 27
            Me.CLabel1.Text = "Note: You are about to post Payroll Number <xx>.  Please Make sure that all entri" &
    "es are ok before posting this entry.  Posted entries cannot be changed anymore."
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel1.Translatable = True
            '
            'AccountSelectorForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(671, 233)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.DoubleBuffered = True
            Me.Name = "AccountSelectorForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.RightToLeftDisplay = "False"
            Me.Text = "Payroll Posting"
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.floButtons.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CdtComboBox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblTitle As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents floButtons As FlowLayoutPanel
        Friend WithEvents CLabel1 As CLabel
    End Class
End Namespace