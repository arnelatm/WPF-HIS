Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayGroupEntryTv
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
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 258)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 258)
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.Editable = True
            Me.TxtIdNo.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(213, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtPayGroupCode
            '
            Me.txtPayGroupCode.BackColor = System.Drawing.Color.White
            Me.txtPayGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayGroupCode.ComputedValue = False
            Me.txtPayGroupCode.CustomFormat = Nothing
            Me.txtPayGroupCode.DataBoundControl = True
            Me.txtPayGroupCode.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupCode, True)
            Me.txtPayGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayGroupCode.LinkedLabel = Nothing
            Me.txtPayGroupCode.Location = New System.Drawing.Point(213, 36)
            Me.txtPayGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayGroupCode.MaximumValue = Nothing
            Me.txtPayGroupCode.MinimumValue = Nothing
            Me.txtPayGroupCode.Name = "txtPayGroupCode"
            Me.txtPayGroupCode.OldValue = Nothing
            Me.txtPayGroupCode.ReadOnly = True
            Me.txtPayGroupCode.Size = New System.Drawing.Size(62, 23)
            Me.txtPayGroupCode.TabIndex = 0
            Me.txtPayGroupCode.ValueIsMandatory = True
            '
            'txtPayGroupName
            '
            Me.txtPayGroupName.BackColor = System.Drawing.Color.White
            Me.txtPayGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayGroupName.ComputedValue = False
            Me.txtPayGroupName.CustomFormat = Nothing
            Me.txtPayGroupName.DataBoundControl = True
            Me.txtPayGroupName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupName, True)
            Me.txtPayGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtPayGroupName.LinkedLabel = Nothing
            Me.txtPayGroupName.Location = New System.Drawing.Point(213, 61)
            Me.txtPayGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayGroupName.MaximumValue = Nothing
            Me.txtPayGroupName.MinimumValue = Nothing
            Me.txtPayGroupName.Name = "txtPayGroupName"
            Me.txtPayGroupName.OldValue = Nothing
            Me.txtPayGroupName.ReadOnly = True
            Me.txtPayGroupName.Size = New System.Drawing.Size(418, 23)
            Me.txtPayGroupName.TabIndex = 1
            Me.txtPayGroupName.ValueIsMandatory = True
            '
            'txtPayGroupNameAra
            '
            Me.txtPayGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayGroupNameAra.ComputedValue = False
            Me.txtPayGroupNameAra.CustomFormat = Nothing
            Me.txtPayGroupNameAra.DataBoundControl = True
            Me.txtPayGroupNameAra.EditingMode = False
            Me.txtPayGroupNameAra.EnglishControl = Me.txtPayGroupName
            Me.floDataDisplay.SetFlowBreak(Me.txtPayGroupNameAra, True)
            Me.txtPayGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayGroupNameAra.LinkedLabel = Nothing
            Me.txtPayGroupNameAra.Location = New System.Drawing.Point(213, 86)
            Me.txtPayGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayGroupNameAra.MaximumValue = Nothing
            Me.txtPayGroupNameAra.MinimumValue = Nothing
            Me.txtPayGroupNameAra.Name = "txtPayGroupNameAra"
            Me.txtPayGroupNameAra.OldValue = Nothing
            Me.txtPayGroupNameAra.ReadOnly = True
            Me.txtPayGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayGroupNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtPayGroupNameAra.TabIndex = 2
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(213, 165)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 6
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPayGroupCode)
            Me.floDataDisplay.Controls.Add(Me.txtPayGroupCode)
            Me.floDataDisplay.Controls.Add(Me.lblPayGroupName)
            Me.floDataDisplay.Controls.Add(Me.txtPayGroupName)
            Me.floDataDisplay.Controls.Add(Me.lblPayGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtPayGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.txtSortKey)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(654, 227)
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
            Me.lblIdNo.Size = New System.Drawing.Size(200, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayGroupCode
            '
            Me.lblPayGroupCode.DisplayOnly = True
            Me.lblPayGroupCode.EditingMode = False
            Me.lblPayGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayGroupCode.Location = New System.Drawing.Point(11, 36)
            Me.lblPayGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayGroupCode.Name = "lblPayGroupCode"
            Me.lblPayGroupCode.Size = New System.Drawing.Size(200, 23)
            Me.lblPayGroupCode.TabIndex = 156
            Me.lblPayGroupCode.Text = "Code"
            Me.lblPayGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayGroupName
            '
            Me.lblPayGroupName.DisplayOnly = True
            Me.lblPayGroupName.EditingMode = False
            Me.lblPayGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayGroupName.Location = New System.Drawing.Point(11, 61)
            Me.lblPayGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayGroupName.Name = "lblPayGroupName"
            Me.lblPayGroupName.Size = New System.Drawing.Size(200, 23)
            Me.lblPayGroupName.TabIndex = 157
            Me.lblPayGroupName.Text = "Name"
            Me.lblPayGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayGroupNameAra
            '
            Me.lblPayGroupNameAra.DisplayOnly = True
            Me.lblPayGroupNameAra.EditingMode = False
            Me.lblPayGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayGroupNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblPayGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayGroupNameAra.Name = "lblPayGroupNameAra"
            Me.lblPayGroupNameAra.Size = New System.Drawing.Size(200, 23)
            Me.lblPayGroupNameAra.TabIndex = 158
            Me.lblPayGroupNameAra.Text = "Name (Arabic)"
            Me.lblPayGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(11, 111)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(200, 23)
            Me.lblParentIdNo.TabIndex = 161
            Me.lblParentIdNo.Text = "Parent "
            Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.DropDownHeight = 200
            Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacParentIdNo.EditingMode = True
            Me.cacParentIdNo.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, True)
            Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.IntegralHeight = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Location = New System.Drawing.Point(213, 111)
            Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.SearchAnywhere = False
            Me.cacParentIdNo.Size = New System.Drawing.Size(418, 24)
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TabIndex = 3
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblLevelNumber
            '
            Me.lblLevelNumber.DisplayOnly = True
            Me.lblLevelNumber.EditingMode = False
            Me.lblLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblLevelNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblLevelNumber.Location = New System.Drawing.Point(11, 137)
            Me.lblLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblLevelNumber.Name = "lblLevelNumber"
            Me.lblLevelNumber.Size = New System.Drawing.Size(200, 26)
            Me.lblLevelNumber.TabIndex = 160
            Me.lblLevelNumber.Text = "Level"
            Me.lblLevelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLevelNumber
            '
            Me.txtLevelNumber.BackColor = System.Drawing.Color.White
            Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLevelNumber.ComputedValue = False
            Me.txtLevelNumber.CustomFormat = Nothing
            Me.txtLevelNumber.DataBoundControl = True
            Me.txtLevelNumber.DisplayOnly = True
            Me.txtLevelNumber.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, True)
            Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
            Me.txtLevelNumber.IgnoreNullCheck = True
            Me.txtLevelNumber.LinkedLabel = Me.lblLevelNumber
            Me.txtLevelNumber.Location = New System.Drawing.Point(213, 137)
            Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLevelNumber.MaximumValue = Nothing
            Me.txtLevelNumber.MinimumValue = Nothing
            Me.txtLevelNumber.Name = "txtLevelNumber"
            Me.txtLevelNumber.OldValue = Nothing
            Me.txtLevelNumber.ReadOnly = True
            Me.txtLevelNumber.Size = New System.Drawing.Size(72, 23)
            Me.txtLevelNumber.TabIndex = 4
            Me.txtLevelNumber.ValueIsMandatory = True
            Me.txtLevelNumber.ValueIsNumeric = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(11, 165)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(200, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSortKey
            '
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.CustomFormat = Nothing
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.EditingMode = False
            Me.txtSortKey.Enabled = False
            Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
            Me.txtSortKey.LinkedLabel = Nothing
            Me.txtSortKey.Location = New System.Drawing.Point(13, 230)
            Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtSortKey.MaximumValue = Nothing
            Me.txtSortKey.MinimumValue = Nothing
            Me.txtSortKey.Name = "txtSortKey"
            Me.txtSortKey.OldValue = Nothing
            Me.txtSortKey.ReadOnly = True
            Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
            Me.txtSortKey.TabIndex = 164
            Me.txtSortKey.ValueIsMandatory = True
            Me.txtSortKey.Visible = False
            '
            'PayGroupEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(955, 280)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayGroupEntryTv"
            Me.Text = "Pay Groups Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPayGroupCode As CTextBox
        Friend WithEvents txtPayGroupName As CTextBox
        Friend WithEvents txtPayGroupNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayGroupCode As CLabel
        Friend WithEvents lblPayGroupName As CLabel
        Friend WithEvents lblPayGroupNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBPayGroupCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
    End Class
End Namespace