Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.LocalizationUtilities

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RevenueGroupEntryTv
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
            Me._MBRevenueGroupCannotBeParentToItself = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
            Me._MBParentWithChildrenChangedDisallowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
            Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
            Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevenueGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevenueGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRevenueGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevenueGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevenueGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevenueGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblProfitCenter = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CaComboBox1 = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            '
            'LocalizableContent1
            '
            LocalizableContent1.MessageBoxes.Add(Me._MBRevenueGroupCannotBeParentToItself)
            LocalizableContent1.MessageBoxes.Add(Me._MBParentWithChildrenChangedDisallowed)
            LocalizableContent1.Messages.Add(Me._MSGMandatoryFields)
            '
            '_MBRevenueGroupCannotBeParentToItself
            '
            Me._MBRevenueGroupCannotBeParentToItself.Caption = "Invalid Parent"
            Me._MBRevenueGroupCannotBeParentToItself.Text = "Sorry, a Profit Center cannot be a parent to itself."
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
            Me.TxtIDNo.LinkedLabel = Nothing
            Me.TxtIDNo.Location = New System.Drawing.Point(246, 1)
            Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.EditingMode = True
            Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIDNo.TabIndex = 0
            Me.TxtIDNo.TabStop = False
            '
            'txtRevenueGroupCode
            '
            Me.txtRevenueGroupCode.AcceptsReturn = false
            Me.txtRevenueGroupCode.AcceptsTab = false
            Me.txtRevenueGroupCode.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupCode.ComputedValue = False
            Me.txtRevenueGroupCode.DataBoundControl = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupCode, True)
            Me.txtRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtRevenueGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupCode.LinkedLabel = Nothing
            Me.txtRevenueGroupCode.Location = New System.Drawing.Point(246, 26)
            Me.txtRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupCode.Name = "txtRevenueGroupCode"
            Me.txtRevenueGroupCode.EditingMode = False
            Me.txtRevenueGroupCode.Size = New System.Drawing.Size(62, 23)
            Me.txtRevenueGroupCode.TabIndex = 0
            Me.txtRevenueGroupCode.ValueIsMandatory = True
            '
            'txtRevenueGroupName
            '
            Me.txtRevenueGroupName.AcceptsReturn = false
            Me.txtRevenueGroupName.AcceptsTab = false
            Me.txtRevenueGroupName.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupName.ComputedValue = False
            Me.txtRevenueGroupName.DataBoundControl = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupName, True)
            Me.txtRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtRevenueGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupName.LinkedLabel = Nothing
            Me.txtRevenueGroupName.Location = New System.Drawing.Point(246, 51)
            Me.txtRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupName.Name = "txtRevenueGroupName"
            Me.txtRevenueGroupName.EditingMode = False
            Me.txtRevenueGroupName.Size = New System.Drawing.Size(418, 23)
            Me.txtRevenueGroupName.TabIndex = 1
            Me.txtRevenueGroupName.ValueIsMandatory = True
            '
            'txtRevenueGroupNameAra
            '
            Me.txtRevenueGroupNameAra.AcceptsReturn = false
            Me.txtRevenueGroupNameAra.AcceptsTab = false
            Me.txtRevenueGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupNameAra.ComputedValue = False
            Me.txtRevenueGroupNameAra.DataBoundControl = True
            Me.txtRevenueGroupNameAra.EnglishControl = Me.txtRevenueGroupName
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupNameAra, True)
            Me.txtRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.txtRevenueGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupNameAra.LinkedLabel = Nothing
            Me.txtRevenueGroupNameAra.Location = New System.Drawing.Point(246, 76)
            Me.txtRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupNameAra.Name = "txtRevenueGroupNameAra"
            Me.txtRevenueGroupNameAra.EditingMode = False
            Me.txtRevenueGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtRevenueGroupNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtRevenueGroupNameAra.TabIndex = 2
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
            Me.txtNotes.Location = New System.Drawing.Point(246, 183)
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
            Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupCode)
            Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupCode)
            Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupName)
            Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupName)
            Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblProfitCenter)
            Me.floDataDisplay.Controls.Add(Me.CaComboBox1)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.txtSortKey)
            Me.floDataDisplay.Location = New System.Drawing.Point(309, 3)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Size = New System.Drawing.Size(691, 230)
            Me.floDataDisplay.TabIndex = 147
            '
            'lblIdNo
            '
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(243, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Revenue Group ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevenueGroupCode
            '
            Me.lblRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblRevenueGroupCode.Location = New System.Drawing.Point(1, 26)
            Me.lblRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupCode.Name = "lblRevenueGroupCode"
            Me.lblRevenueGroupCode.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupCode.TabIndex = 156
            Me.lblRevenueGroupCode.Text = "Revenue Group Code"
            Me.lblRevenueGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevenueGroupName
            '
            Me.lblRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblRevenueGroupName.Location = New System.Drawing.Point(1, 51)
            Me.lblRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupName.Name = "lblRevenueGroupName"
            Me.lblRevenueGroupName.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupName.TabIndex = 157
            Me.lblRevenueGroupName.Text = "Revenue Group Name"
            Me.lblRevenueGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevenueGroupNameAra
            '
            Me.lblRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblRevenueGroupNameAra.Location = New System.Drawing.Point(1, 76)
            Me.lblRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupNameAra.Name = "lblRevenueGroupNameAra"
            Me.lblRevenueGroupNameAra.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupNameAra.TabIndex = 158
            Me.lblRevenueGroupNameAra.Text = "RevenueGroup Name (Arabic)"
            Me.lblRevenueGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(1, 101)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(243, 23)
            Me.lblParentIdNo.TabIndex = 161
            Me.lblParentIdNo.Text = "Parent Rev. Group"
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
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Location = New System.Drawing.Point(246, 101)
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
            'lblProfitCenter
            '
            Me.lblProfitCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.lblProfitCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblProfitCenter.Location = New System.Drawing.Point(1, 127)
            Me.lblProfitCenter.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProfitCenter.Name = "lblProfitCenter"
            Me.lblProfitCenter.Size = New System.Drawing.Size(243, 26)
            Me.lblProfitCenter.TabIndex = 160
            Me.lblProfitCenter.Text = "Level"
            Me.lblProfitCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CaComboBox1
            '
            Me.CaComboBox1.BackColor = System.Drawing.Color.White
            Me.CaComboBox1.ChangingSearchValueOnly = False
            Me.CaComboBox1.CurrentSearchTerm = ""
            Me.CaComboBox1.DefaultValue = Nothing
            Me.CaComboBox1.DisplayMember = "Name"
            Me.CaComboBox1.DropDownHeight = 200
            Me.CaComboBox1.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.CaComboBox1, True)
            Me.CaComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.CaComboBox1.ForeColor = System.Drawing.Color.Black
            Me.CaComboBox1.FormattingEnabled = True
            Me.CaComboBox1.HideWhenNotEditingOrAdding = False
            Me.CaComboBox1.LinkedLabel = Nothing
            Me.CaComboBox1.Location = New System.Drawing.Point(246, 127)
            Me.CaComboBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CaComboBox1.Name = "CaComboBox1"
            Me.CaComboBox1.OldValue = Nothing
            Me.CaComboBox1.OriginalDataSource = Nothing
            Me.CaComboBox1.OriginalList = Nothing
            Me.CaComboBox1.OverrideDropDownStyleList = False
            Me.CaComboBox1.PreviousSearchTerm = Nothing
            Me.CaComboBox1.PreviousSelectedIndex = -1
            Me.CaComboBox1.PropertySelector = Nothing
            Me.CaComboBox1.ReadOnlyCombo = False
            Me.CaComboBox1.EditingMode = False
            Me.CaComboBox1.SearchAnywhere = False
            Me.CaComboBox1.Size = New System.Drawing.Size(418, 24)
            Me.CaComboBox1.SuggestBoxHeight = 200
            Me.CaComboBox1.SuggestListOrderRule = Nothing
            Me.CaComboBox1.TabIndex = 165
            Me.CaComboBox1.TextToSearch = Nothing
            Me.CaComboBox1.ValueIsMandatory = False
            Me.CaComboBox1.ValueIsNullable = False
            Me.CaComboBox1.ValueIsNumeric = False
            Me.CaComboBox1.ValueMember = "IdNo"
            '
            'CLabel1
            '
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(1, 155)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(243, 26)
            Me.CLabel1.TabIndex = 166
            Me.CLabel1.Text = "Level"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.txtLevelNumber.LinkedLabel = Me.lblProfitCenter
            Me.txtLevelNumber.Location = New System.Drawing.Point(246, 155)
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
            Me.lblNotes.Location = New System.Drawing.Point(1, 183)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(243, 30)
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
            Me.txtSortKey.Location = New System.Drawing.Point(3, 248)
            Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtSortKey.Name = "txtSortKey"
            Me.txtSortKey.EditingMode = False
            Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
            Me.txtSortKey.TabIndex = 164
            Me.txtSortKey.ValueIsMandatory = True
            Me.txtSortKey.Visible = False
            '
            'RevenueGroupEntryTv
            '
            Me.ClientSize = New System.Drawing.Size(1000, 298)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "RevenueGroupEntryTv"
            Me.Text = "RevenueGroups Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout

        End Sub
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtRevenueGroupCode As CTextBox
        Friend WithEvents txtRevenueGroupName As CTextBox
        Friend WithEvents txtRevenueGroupNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblRevenueGroupCode As CLabel
        Friend WithEvents lblRevenueGroupName As CLabel
        Friend WithEvents lblRevenueGroupNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblProfitCenter As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBRevenueGroupCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents CaComboBox1 As CaComboBox
        Friend WithEvents CLabel1 As CLabel
    End Class
End Namespace