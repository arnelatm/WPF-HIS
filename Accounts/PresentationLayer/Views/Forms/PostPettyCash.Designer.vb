Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PostPettyCash
        Inherits AATM.PresentationLayer.Forms.BfMain

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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(169, 23)
            Me.CLabel1.TabIndex = 1
            Me.CLabel1.Text = "Start Reference Number"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboStartIdNo
            '
            Me.cboStartIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.cboStartIdNo.BackColor = System.Drawing.Color.White
            Me.cboStartIdNo.DefaultValue = Nothing
            Me.cboStartIdNo.DisplayOnly = False
            Me.cboStartIdNo.EditingMode = True
            Me.cboStartIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.CFlowLayout1.SetFlowBreak(Me.cboStartIdNo, True)
            Me.cboStartIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboStartIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboStartIdNo.FormattingEnabled = True
            Me.cboStartIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cboStartIdNo.ReadOnlyCombo = False
            Me.cboStartIdNo.Size = New System.Drawing.Size(332, 24)
            Me.cboStartIdNo.TabIndex = 2
            Me.cboStartIdNo.ValueIsMandatory = False
            Me.cboStartIdNo.ValueIsNullable = False
            Me.cboStartIdNo.ValueIsNumeric = False
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 27)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(169, 24)
            Me.CLabel2.TabIndex = 3
            Me.CLabel2.Text = "End Reference Number"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboEndIdNo.DisplayOnly = False
            Me.cboEndIdNo.EditingMode = True
            Me.cboEndIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.CFlowLayout1.SetFlowBreak(Me.cboEndIdNo, True)
            Me.cboEndIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEndIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEndIdNo.FormattingEnabled = True
            Me.cboEndIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cboEndIdNo.ReadOnlyCombo = False
            Me.cboEndIdNo.Size = New System.Drawing.Size(332, 24)
            Me.cboEndIdNo.TabIndex = 4
            Me.cboEndIdNo.ValueIsMandatory = False
            Me.cboEndIdNo.ValueIsNullable = False
            Me.cboEndIdNo.ValueIsNumeric = False
            '
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 53)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(169, 24)
            Me.CLabel3.TabIndex = 5
            Me.CLabel3.Text = "Posting Account"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayOnly = False
            Me.cboAccountIdNo.EditingMode = True
            Me.cboAccountIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.Size = New System.Drawing.Size(332, 24)
            Me.cboAccountIdNo.TabIndex = 6
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            '
            'CLabel4
            '
            Me.CLabel4.BackColor = System.Drawing.Color.Green
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel4.ForeColor = System.Drawing.Color.White
            Me.CLabel4.Location = New System.Drawing.Point(0, 0)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(534, 33)
            Me.CLabel4.TabIndex = 7
            Me.CLabel4.Text = "Petty Cash Posting"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.DisplayOnly = True
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
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.DisplayOnly = True
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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

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