Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayCycleEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayCycleEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayCycleCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayCycleName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayCycleNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayCycleCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayCycleName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayCycleNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
            'txtPayCycleCode
            '
            Me.txtPayCycleCode.BackColor = System.Drawing.Color.White
            Me.txtPayCycleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayCycleCode.ComputedValue = False
            Me.txtPayCycleCode.CustomFormat = Nothing
            Me.txtPayCycleCode.DataBoundControl = True
            Me.txtPayCycleCode.EditingMode = False
            Me.txtPayCycleCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPayCycleCode, True)
            Me.txtPayCycleCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayCycleCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayCycleCode.LinkedLabel = Nothing
            Me.txtPayCycleCode.Location = New System.Drawing.Point(213, 36)
            Me.txtPayCycleCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayCycleCode.MaximumValue = Nothing
            Me.txtPayCycleCode.MinimumValue = Nothing
            Me.txtPayCycleCode.Name = "txtPayCycleCode"
            Me.txtPayCycleCode.OldValue = Nothing
            Me.txtPayCycleCode.ReadOnly = True
            Me.txtPayCycleCode.Size = New System.Drawing.Size(62, 23)
            Me.txtPayCycleCode.TabIndex = 1
            Me.txtPayCycleCode.ValueIsMandatory = True
            '
            'txtPayCycleName
            '
            Me.txtPayCycleName.BackColor = System.Drawing.Color.White
            Me.txtPayCycleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayCycleName.ComputedValue = False
            Me.txtPayCycleName.CustomFormat = Nothing
            Me.txtPayCycleName.DataBoundControl = True
            Me.txtPayCycleName.EditingMode = False
            Me.txtPayCycleName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPayCycleName, True)
            Me.txtPayCycleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayCycleName.ForeColor = System.Drawing.Color.Black
            Me.txtPayCycleName.LinkedLabel = Nothing
            Me.txtPayCycleName.Location = New System.Drawing.Point(213, 61)
            Me.txtPayCycleName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayCycleName.MaximumValue = Nothing
            Me.txtPayCycleName.MinimumValue = Nothing
            Me.txtPayCycleName.Name = "txtPayCycleName"
            Me.txtPayCycleName.OldValue = Nothing
            Me.txtPayCycleName.ReadOnly = True
            Me.txtPayCycleName.Size = New System.Drawing.Size(418, 23)
            Me.txtPayCycleName.TabIndex = 2
            Me.txtPayCycleName.ValueIsMandatory = True
            '
            'txtPayCycleNameAra
            '
            Me.txtPayCycleNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayCycleNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayCycleNameAra.ComputedValue = False
            Me.txtPayCycleNameAra.CustomFormat = Nothing
            Me.txtPayCycleNameAra.DataBoundControl = True
            Me.txtPayCycleNameAra.EditingMode = False
            Me.txtPayCycleNameAra.EnglishControl = Me.txtPayCycleName
            Me.txtPayCycleNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPayCycleNameAra, True)
            Me.txtPayCycleNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayCycleNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayCycleNameAra.LinkedLabel = Nothing
            Me.txtPayCycleNameAra.Location = New System.Drawing.Point(213, 112)
            Me.txtPayCycleNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayCycleNameAra.MaximumValue = Nothing
            Me.txtPayCycleNameAra.MinimumValue = Nothing
            Me.txtPayCycleNameAra.Name = "txtPayCycleNameAra"
            Me.txtPayCycleNameAra.OldValue = Nothing
            Me.txtPayCycleNameAra.ReadOnly = True
            Me.txtPayCycleNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayCycleNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtPayCycleNameAra.TabIndex = 4
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
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(213, 137)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 5
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPayCycleCode)
            Me.floDataDisplay.Controls.Add(Me.txtPayCycleCode)
            Me.floDataDisplay.Controls.Add(Me.lblPayCycleName)
            Me.floDataDisplay.Controls.Add(Me.txtPayCycleName)
            Me.floDataDisplay.Controls.Add(Me.lblPayFrequency)
            Me.floDataDisplay.Controls.Add(Me.cboPayFrequency)
            Me.floDataDisplay.Controls.Add(Me.lblPayCycleNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtPayCycleNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(654, 207)
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
            'lblPayCycleCode
            '
            Me.lblPayCycleCode.DisplayOnly = True
            Me.lblPayCycleCode.EditingMode = False
            Me.lblPayCycleCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleCode.Location = New System.Drawing.Point(11, 36)
            Me.lblPayCycleCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleCode.Name = "lblPayCycleCode"
            Me.lblPayCycleCode.Size = New System.Drawing.Size(200, 23)
            Me.lblPayCycleCode.TabIndex = 156
            Me.lblPayCycleCode.Text = "Code"
            Me.lblPayCycleCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayCycleName
            '
            Me.lblPayCycleName.DisplayOnly = True
            Me.lblPayCycleName.EditingMode = False
            Me.lblPayCycleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleName.Location = New System.Drawing.Point(11, 61)
            Me.lblPayCycleName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleName.Name = "lblPayCycleName"
            Me.lblPayCycleName.Size = New System.Drawing.Size(200, 23)
            Me.lblPayCycleName.TabIndex = 157
            Me.lblPayCycleName.Text = "Name"
            Me.lblPayCycleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayFrequency
            '
            Me.lblPayFrequency.DisplayOnly = True
            Me.lblPayFrequency.EditingMode = False
            Me.lblPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayFrequency.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayFrequency.Location = New System.Drawing.Point(11, 86)
            Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayFrequency.Name = "lblPayFrequency"
            Me.lblPayFrequency.Size = New System.Drawing.Size(200, 23)
            Me.lblPayFrequency.TabIndex = 288
            Me.lblPayFrequency.Text = "Pay Frequency"
            Me.lblPayFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPayFrequency
            '
            Me.cboPayFrequency.BackColor = System.Drawing.Color.White
            Me.cboPayFrequency.ChangingSearchValueOnly = False
            Me.cboPayFrequency.CurrentSearchTerm = ""
            Me.cboPayFrequency.DefaultValue = Nothing
            Me.cboPayFrequency.DisplayMember = "Name"
            Me.cboPayFrequency.EditingMode = False
            Me.cboPayFrequency.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cboPayFrequency, True)
            Me.cboPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboPayFrequency.FormattingEnabled = True
            Me.cboPayFrequency.HideWhenNotEditingOrAdding = False
            Me.cboPayFrequency.IntegralHeight = False
            Me.cboPayFrequency.LinkedLabel = Me.lblPayFrequency
            Me.cboPayFrequency.Location = New System.Drawing.Point(212, 86)
            Me.cboPayFrequency.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPayFrequency.Name = "cboPayFrequency"
            Me.cboPayFrequency.OldValue = 0
            Me.cboPayFrequency.OriginalDataSource = Nothing
            Me.cboPayFrequency.OriginalList = Nothing
            Me.cboPayFrequency.OverrideDropDownStyleList = False
            Me.cboPayFrequency.PreviousSearchTerm = Nothing
            Me.cboPayFrequency.PropertySelector = Nothing
            Me.cboPayFrequency.ReadOnlyCombo = False
            Me.cboPayFrequency.Size = New System.Drawing.Size(202, 24)
            Me.cboPayFrequency.SuggestBoxHeight = 200
            Me.cboPayFrequency.SuggestListOrderRule = Nothing
            Me.cboPayFrequency.TabIndex = 3
            Me.cboPayFrequency.TextToSearch = Nothing
            Me.cboPayFrequency.ValueIsMandatory = False
            Me.cboPayFrequency.ValueIsNullable = False
            Me.cboPayFrequency.ValueIsNumeric = False
            Me.cboPayFrequency.ValueMember = "Code"
            '
            'lblPayCycleNameAra
            '
            Me.lblPayCycleNameAra.DisplayOnly = True
            Me.lblPayCycleNameAra.EditingMode = False
            Me.lblPayCycleNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleNameAra.Location = New System.Drawing.Point(11, 112)
            Me.lblPayCycleNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleNameAra.Name = "lblPayCycleNameAra"
            Me.lblPayCycleNameAra.Size = New System.Drawing.Size(200, 23)
            Me.lblPayCycleNameAra.TabIndex = 158
            Me.lblPayCycleNameAra.Text = "Name (Arabic)"
            Me.lblPayCycleNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(11, 137)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(200, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PayCycleEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(955, 260)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayCycleEntryTv"
            Me.Text = "Pay Cycles Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPayCycleCode As CTextBox
        Friend WithEvents txtPayCycleName As CTextBox
        Friend WithEvents txtPayCycleNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayCycleCode As CLabel
        Friend WithEvents lblPayCycleName As CLabel
        Friend WithEvents lblPayCycleNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents _MBPayCycleCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents lblPayFrequency As CLabel
        Friend WithEvents cboPayFrequency As CaComboBox
    End Class
End Namespace