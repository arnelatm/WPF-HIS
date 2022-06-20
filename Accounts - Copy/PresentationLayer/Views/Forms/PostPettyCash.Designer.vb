Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PostPettyCash
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboStartIdNo = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.cboEndIdNo = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'CLabel1
        '
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(1, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(169, 23)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Start Reference Number"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'cboStartIdNo
        '
        Me.cboStartIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboStartIdNo.BackColor = System.Drawing.Color.White
        Me.cboStartIdNo.DefaultValue = Nothing
        Me.cboStartIdNo.DisplayOnly = false
        Me.cboStartIdNo.EditingMode = true
        Me.cboStartIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CFlowLayout1.SetFlowBreak(Me.cboStartIdNo, true)
        Me.cboStartIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboStartIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboStartIdNo.FormattingEnabled = true
        Me.cboStartIdNo.HideWhenNotEditingOrAdding = false
        Me.cboStartIdNo.LinkedLabel = Nothing
        Me.cboStartIdNo.Location = New System.Drawing.Point(172, 1)
        Me.cboStartIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboStartIdNo.MaximumValue = Nothing
        Me.cboStartIdNo.MinimumValue = Nothing
        Me.cboStartIdNo.Name = "cboStartIdNo"
        Me.cboStartIdNo.OldValue = 0
        Me.cboStartIdNo.OriginalDataSource = Nothing
        Me.cboStartIdNo.OriginalDropDownStyle = 1
        Me.cboStartIdNo.OriginalList = Nothing
        Me.cboStartIdNo.ReadOnlyCombo = false
        Me.cboStartIdNo.Size = New System.Drawing.Size(332, 24)
        Me.cboStartIdNo.TabIndex = 2
        Me.cboStartIdNo.Translatable = false
        Me.cboStartIdNo.ValueIsMandatory = false
        Me.cboStartIdNo.ValueIsNullable = false
        Me.cboStartIdNo.ValueIsNumeric = false
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.Transparent
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(1, 27)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(169, 24)
        Me.CLabel2.TabIndex = 3
        Me.CLabel2.Text = "End Reference Number"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.cboStartIdNo)
        Me.CFlowLayout1.Controls.Add(Me.CLabel2)
        Me.CFlowLayout1.Controls.Add(Me.cboEndIdNo)
        Me.CFlowLayout1.Controls.Add(Me.CLabel3)
        Me.CFlowLayout1.Controls.Add(Me.cboAccountIdNo)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(522, 89)
        Me.CFlowLayout1.TabIndex = 4
        '
        'cboEndIdNo
        '
        Me.cboEndIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboEndIdNo.BackColor = System.Drawing.Color.White
        Me.cboEndIdNo.DefaultValue = Nothing
        Me.cboEndIdNo.DisplayOnly = false
        Me.cboEndIdNo.EditingMode = true
        Me.cboEndIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CFlowLayout1.SetFlowBreak(Me.cboEndIdNo, true)
        Me.cboEndIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEndIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEndIdNo.FormattingEnabled = true
        Me.cboEndIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEndIdNo.LinkedLabel = Nothing
        Me.cboEndIdNo.Location = New System.Drawing.Point(172, 27)
        Me.cboEndIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEndIdNo.MaximumValue = Nothing
        Me.cboEndIdNo.MinimumValue = Nothing
        Me.cboEndIdNo.Name = "cboEndIdNo"
        Me.cboEndIdNo.OldValue = 0
        Me.cboEndIdNo.OriginalDataSource = Nothing
        Me.cboEndIdNo.OriginalDropDownStyle = 1
        Me.cboEndIdNo.OriginalList = Nothing
        Me.cboEndIdNo.ReadOnlyCombo = false
        Me.cboEndIdNo.Size = New System.Drawing.Size(332, 24)
        Me.cboEndIdNo.TabIndex = 4
        Me.cboEndIdNo.Translatable = false
        Me.cboEndIdNo.ValueIsMandatory = false
        Me.cboEndIdNo.ValueIsNullable = false
        Me.cboEndIdNo.ValueIsNumeric = false
        '
        'CLabel3
        '
        Me.CLabel3.BackColor = System.Drawing.Color.Transparent
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 53)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(169, 24)
        Me.CLabel3.TabIndex = 5
        Me.CLabel3.Text = "Posting Account"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.DefaultValue = Nothing
        Me.cboAccountIdNo.DisplayOnly = false
        Me.cboAccountIdNo.EditingMode = true
        Me.cboAccountIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.FormattingEnabled = true
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Location = New System.Drawing.Point(172, 53)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.MaximumValue = Nothing
        Me.cboAccountIdNo.MinimumValue = Nothing
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalDropDownStyle = 1
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(332, 24)
        Me.cboAccountIdNo.TabIndex = 6
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        '
        'CLabel4
        '
        Me.CLabel4.BackColor = System.Drawing.Color.Green
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CLabel4.ForeColor = System.Drawing.Color.White
        Me.CLabel4.Location = New System.Drawing.Point(0, 0)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(534, 33)
        Me.CLabel4.TabIndex = 7
        Me.CLabel4.Text = "Petty Cash Posting"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel4.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(184, 132)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(280, 132)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'PostPettyCash
        '
        Me.AcceptButton = Me.btnOk
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(537, 166)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel4)
        Me.Name = "PostPettyCash"
        Me.Text = "Petty Cash Posting"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboStartIdNo As Libraries.CBaseControlsLibrary.CComboBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents cboEndIdNo As Libraries.CBaseControlsLibrary.CComboBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboAccountIdNo As Libraries.CBaseControlsLibrary.CComboBox
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    End Class
End NameSpace