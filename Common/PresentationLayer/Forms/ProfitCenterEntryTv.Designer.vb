Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.LocalizationUtilities

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProfitCenterEntryTv
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
            Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
            Me._MBProfitCenterCannotBeParentToItself = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
            Me._MBParentWithChildrenChangedDisallowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
            Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
            Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProfitCenterCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProfitCenterCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProfitCenterName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProfitCenterName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProfitCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblProfitCenterNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblProfitCenterType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacProfitCenterType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit
            Me.floDataDisplay.SuspendLayout
            Me.SuspendLayout
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.RightToLeftLayout = False
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 240)
            '
            'LocalizableContent1
            '
            LocalizableContent1.MessageBoxes.Add(Me._MBProfitCenterCannotBeParentToItself)
            LocalizableContent1.MessageBoxes.Add(Me._MBParentWithChildrenChangedDisallowed)
            LocalizableContent1.Messages.Add(Me._MSGMandatoryFields)
            '
            '_MBProfitCenterCannotBeParentToItself
            '
            Me._MBProfitCenterCannotBeParentToItself.Caption = "Invalid Parent"
            Me._MBProfitCenterCannotBeParentToItself.Text = "Sorry, a Profit Center cannot be a parent to itself."
            '
            '_MBParentWithChildrenChangedDisallowed
            '
            Me._MBParentWithChildrenChangedDisallowed.Text = """Sorry, this Profit Center is a parent, you cannot change it's parent while child" & _
        "ren exists."""
            '
            '_MSGMandatoryFields
            '
            Me._MSGMandatoryFields.Value = "Following fields are mandatory, "
            '
            'TxtIDNo
            '
            Me.TxtIDNo.AcceptsReturn = false
            Me.TxtIDNo.AcceptsTab = false
            Me.TxtIDNo.BackColor = System.Drawing.Color.White
            Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIDNo.ComputedValue = False
            Me.TxtIDNo.DataBoundControl = True
            Me.TxtIDNo.DisplayOnly = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, True)
            Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIDNo.LinkedLabel = Me.lblIdNo
            Me.TxtIDNo.Location = New System.Drawing.Point(235, 1)
            Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.EditingMode = True
            Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIDNo.TabIndex = 0
            Me.TxtIDNo.TabStop = False
            '
            'lblIdNo
            '
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(232, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ProfitCenter ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtProfitCenterCode
            '
            Me.txtProfitCenterCode.AcceptsReturn = false
            Me.txtProfitCenterCode.AcceptsTab = false
            Me.txtProfitCenterCode.BackColor = System.Drawing.Color.White
            Me.txtProfitCenterCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProfitCenterCode.ComputedValue = False
            Me.txtProfitCenterCode.DataBoundControl = True
            Me.floDataDisplay.SetFlowBreak(Me.txtProfitCenterCode, True)
            Me.txtProfitCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtProfitCenterCode.ForeColor = System.Drawing.Color.Black
            Me.txtProfitCenterCode.LinkedLabel = Me.lblProfitCenterCode
            Me.txtProfitCenterCode.Location = New System.Drawing.Point(235, 26)
            Me.txtProfitCenterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProfitCenterCode.Name = "txtProfitCenterCode"
            Me.txtProfitCenterCode.EditingMode = False
            Me.txtProfitCenterCode.Size = New System.Drawing.Size(62, 23)
            Me.txtProfitCenterCode.TabIndex = 0
            Me.txtProfitCenterCode.ValueIsMandatory = True
            '
            'lblProfitCenterCode
            '
            Me.lblProfitCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblProfitCenterCode.Location = New System.Drawing.Point(1, 26)
            Me.lblProfitCenterCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProfitCenterCode.Name = "lblProfitCenterCode"
            Me.lblProfitCenterCode.Size = New System.Drawing.Size(232, 23)
            Me.lblProfitCenterCode.TabIndex = 156
            Me.lblProfitCenterCode.Text = "ProfitCenter Code"
            Me.lblProfitCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtProfitCenterName
            '
            Me.txtProfitCenterName.AcceptsReturn = false
            Me.txtProfitCenterName.AcceptsTab = false
            Me.txtProfitCenterName.BackColor = System.Drawing.Color.White
            Me.txtProfitCenterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProfitCenterName.ComputedValue = False
            Me.txtProfitCenterName.DataBoundControl = True
            Me.floDataDisplay.SetFlowBreak(Me.txtProfitCenterName, True)
            Me.txtProfitCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtProfitCenterName.ForeColor = System.Drawing.Color.Black
            Me.txtProfitCenterName.LinkedLabel = Me.lblProfitCenterName
            Me.txtProfitCenterName.Location = New System.Drawing.Point(235, 51)
            Me.txtProfitCenterName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProfitCenterName.Name = "txtProfitCenterName"
            Me.txtProfitCenterName.EditingMode = False
            Me.txtProfitCenterName.Size = New System.Drawing.Size(418, 23)
            Me.txtProfitCenterName.TabIndex = 1
            Me.txtProfitCenterName.ValueIsMandatory = True
            '
            'lblProfitCenterName
            '
            Me.lblProfitCenterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblProfitCenterName.Location = New System.Drawing.Point(1, 51)
            Me.lblProfitCenterName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProfitCenterName.Name = "lblProfitCenterName"
            Me.lblProfitCenterName.Size = New System.Drawing.Size(232, 23)
            Me.lblProfitCenterName.TabIndex = 157
            Me.lblProfitCenterName.Text = "ProfitCenter Name"
            Me.lblProfitCenterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtProfitCenterNameAra
            '
            Me.txtProfitCenterNameAra.AcceptsReturn = false
            Me.txtProfitCenterNameAra.AcceptsTab = false
            Me.txtProfitCenterNameAra.BackColor = System.Drawing.Color.White
            Me.txtProfitCenterNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProfitCenterNameAra.ComputedValue = False
            Me.txtProfitCenterNameAra.DataBoundControl = True
            Me.txtProfitCenterNameAra.EnglishControl = Me.txtProfitCenterName
            Me.floDataDisplay.SetFlowBreak(Me.txtProfitCenterNameAra, True)
            Me.txtProfitCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtProfitCenterNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtProfitCenterNameAra.LinkedLabel = Me.lblProfitCenterNameAra
            Me.txtProfitCenterNameAra.Location = New System.Drawing.Point(235, 76)
            Me.txtProfitCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProfitCenterNameAra.Name = "txtProfitCenterNameAra"
            Me.txtProfitCenterNameAra.EditingMode = False
            Me.txtProfitCenterNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtProfitCenterNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtProfitCenterNameAra.TabIndex = 2
            '
            'lblProfitCenterNameAra
            '
            Me.lblProfitCenterNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblProfitCenterNameAra.Location = New System.Drawing.Point(1, 76)
            Me.lblProfitCenterNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProfitCenterNameAra.Name = "lblProfitCenterNameAra"
            Me.lblProfitCenterNameAra.Size = New System.Drawing.Size(232, 23)
            Me.lblProfitCenterNameAra.TabIndex = 158
            Me.lblProfitCenterNameAra.Text = "ProfitCenter Name (Arabic)"
            Me.lblProfitCenterNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNotes
            '
            Me.txtNotes.AcceptsReturn = false
            Me.txtNotes.AcceptsTab = false
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.DataBoundControl = True
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(235, 181)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 3
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
            Me.floDataDisplay.Controls.Add(Me.lblProfitCenterCode)
            Me.floDataDisplay.Controls.Add(Me.txtProfitCenterCode)
            Me.floDataDisplay.Controls.Add(Me.lblProfitCenterName)
            Me.floDataDisplay.Controls.Add(Me.txtProfitCenterName)
            Me.floDataDisplay.Controls.Add(Me.lblProfitCenterNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtProfitCenterNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblProfitCenterType)
            Me.floDataDisplay.Controls.Add(Me.cacProfitCenterType)
            Me.floDataDisplay.Controls.Add(Me.lblLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.txtSortKey)
            Me.floDataDisplay.Location = New System.Drawing.Point(309, 3)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Size = New System.Drawing.Size(677, 248)
            Me.floDataDisplay.TabIndex = 147
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(1, 101)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(232, 23)
            Me.lblParentIdNo.TabIndex = 161
            Me.lblParentIdNo.Text = "Parent Profit Center"
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
            Me.cacParentIdNo.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, True)
            Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.LinkedLabel = Me.lblParentIdNo
            Me.cacParentIdNo.Location = New System.Drawing.Point(235, 101)
            Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = Nothing
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PreviousSelectedIndex = -1
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.EditingMode = False
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
            'lblProfitCenterType
            '
            Me.lblProfitCenterType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblProfitCenterType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblProfitCenterType.Location = New System.Drawing.Point(1, 127)
            Me.lblProfitCenterType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProfitCenterType.Name = "lblProfitCenterType"
            Me.lblProfitCenterType.Size = New System.Drawing.Size(232, 23)
            Me.lblProfitCenterType.TabIndex = 166
            Me.lblProfitCenterType.Text = "Profit Center Type"
            Me.lblProfitCenterType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacProfitCenterType
            '
            Me.cacProfitCenterType.BackColor = System.Drawing.Color.White
            Me.cacProfitCenterType.ChangingSearchValueOnly = False
            Me.cacProfitCenterType.CurrentSearchTerm = ""
            Me.cacProfitCenterType.DefaultValue = Nothing
            Me.cacProfitCenterType.DisplayMember = "Name"
            Me.cacProfitCenterType.DropDownHeight = 200
            Me.cacProfitCenterType.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacProfitCenterType, True)
            Me.cacProfitCenterType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.cacProfitCenterType.ForeColor = System.Drawing.Color.Black
            Me.cacProfitCenterType.FormattingEnabled = True
            Me.cacProfitCenterType.HideWhenNotEditingOrAdding = False
            Me.cacProfitCenterType.LinkedLabel = Me.lblProfitCenterType
            Me.cacProfitCenterType.Location = New System.Drawing.Point(235, 127)
            Me.cacProfitCenterType.Margin = New System.Windows.Forms.Padding(1)
            Me.cacProfitCenterType.Name = "cacProfitCenterType"
            Me.cacProfitCenterType.OldValue = Nothing
            Me.cacProfitCenterType.OriginalDataSource = Nothing
            Me.cacProfitCenterType.OriginalList = Nothing
            Me.cacProfitCenterType.OverrideDropDownStyleList = False
            Me.cacProfitCenterType.PreviousSearchTerm = Nothing
            Me.cacProfitCenterType.PreviousSelectedIndex = -1
            Me.cacProfitCenterType.PropertySelector = Nothing
            Me.cacProfitCenterType.ReadOnlyCombo = False
            Me.cacProfitCenterType.EditingMode = False
            Me.cacProfitCenterType.SearchAnywhere = False
            Me.cacProfitCenterType.Size = New System.Drawing.Size(418, 24)
            Me.cacProfitCenterType.SuggestBoxHeight = 200
            Me.cacProfitCenterType.SuggestListOrderRule = Nothing
            Me.cacProfitCenterType.TabIndex = 165
            Me.cacProfitCenterType.TextToSearch = Nothing
            Me.cacProfitCenterType.ValueIsMandatory = False
            Me.cacProfitCenterType.ValueIsNullable = False
            Me.cacProfitCenterType.ValueIsNumeric = False
            Me.cacProfitCenterType.ValueMember = "Code"
            '
            'lblLevelNumber
            '
            Me.lblLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblLevelNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblLevelNumber.Location = New System.Drawing.Point(1, 153)
            Me.lblLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblLevelNumber.Name = "lblLevelNumber"
            Me.lblLevelNumber.Size = New System.Drawing.Size(232, 26)
            Me.lblLevelNumber.TabIndex = 160
            Me.lblLevelNumber.Text = "Level"
            Me.lblLevelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLevelNumber
            '
            Me.txtLevelNumber.AcceptsReturn = false
            Me.txtLevelNumber.AcceptsTab = false
            Me.txtLevelNumber.BackColor = System.Drawing.Color.White
            Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLevelNumber.ComputedValue = False
            Me.txtLevelNumber.DataBoundControl = True
            Me.txtLevelNumber.DisplayOnly = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, True)
            Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
            Me.txtLevelNumber.IgnoreNullCheck = True
            Me.txtLevelNumber.LinkedLabel = Me.lblLevelNumber
            Me.txtLevelNumber.Location = New System.Drawing.Point(235, 153)
            Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLevelNumber.Name = "txtLevelNumber"
            Me.txtLevelNumber.ReadOnly = True
            Me.txtLevelNumber.EditingMode = True
            Me.txtLevelNumber.Size = New System.Drawing.Size(74, 23)
            Me.txtLevelNumber.TabIndex = 163
            Me.txtLevelNumber.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblNotes.Location = New System.Drawing.Point(1, 181)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(232, 30)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSortKey
            '
            Me.txtSortKey.AcceptsReturn = false
            Me.txtSortKey.AcceptsTab = false
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.Enabled = False
            Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
            Me.txtSortKey.LinkedLabel = Nothing
            Me.txtSortKey.Location = New System.Drawing.Point(3, 246)
            Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtSortKey.Name = "txtSortKey"
            Me.txtSortKey.EditingMode = False
            Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
            Me.txtSortKey.TabIndex = 164
            Me.txtSortKey.ValueIsMandatory = True
            Me.txtSortKey.Visible = False
            '
            'ProfitCenterEntryTv
            '
            Me.ClientSize = New System.Drawing.Size(986, 323)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "ProfitCenterEntryTv"
            Me.Text = "ProfitCenters Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout

        End Sub
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtProfitCenterCode As CTextBox
        Friend WithEvents txtProfitCenterName As CTextBox
        Friend WithEvents txtProfitCenterNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblProfitCenterCode As CLabel
        Friend WithEvents lblProfitCenterName As CLabel
        Friend WithEvents lblProfitCenterNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblLevelNumber As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBProfitCenterCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents lblProfitCenterType As CLabel
        Friend WithEvents cacProfitCenterType As CaComboBox
    End Class
End Namespace