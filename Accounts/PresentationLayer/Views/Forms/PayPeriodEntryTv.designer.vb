Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayPeriodEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayPeriodEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CacPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
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
            Me.TxtIdNo.Editable = True
            Me.TxtIdNo.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(161, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(72, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtPayPeriodName
            '
            Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayPeriodName.ComputedValue = False
            Me.txtPayPeriodName.CustomFormat = Nothing
            Me.txtPayPeriodName.DataBoundControl = True
            Me.txtPayPeriodName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtPayPeriodName, True)
            Me.txtPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodName.LinkedLabel = Nothing
            Me.txtPayPeriodName.Location = New System.Drawing.Point(161, 87)
            Me.txtPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodName.MaximumValue = Nothing
            Me.txtPayPeriodName.MinimumValue = Nothing
            Me.txtPayPeriodName.Name = "txtPayPeriodName"
            Me.txtPayPeriodName.OldValue = Nothing
            Me.txtPayPeriodName.ReadOnly = True
            Me.txtPayPeriodName.Size = New System.Drawing.Size(418, 23)
            Me.txtPayPeriodName.TabIndex = 3
            Me.txtPayPeriodName.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPayCycleIdNo)
            Me.floDataDisplay.Controls.Add(Me.CacPayCycleIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPayPeriodCode)
            Me.floDataDisplay.Controls.Add(Me.txtPayPeriodCode)
            Me.floDataDisplay.Controls.Add(Me.lblPayPeriodName)
            Me.floDataDisplay.Controls.Add(Me.txtPayPeriodName)
            Me.floDataDisplay.Controls.Add(Me.lblPayPeriodNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtPayPeriodNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblStartDate)
            Me.floDataDisplay.Controls.Add(Me.dtpStartDate)
            Me.floDataDisplay.Controls.Add(Me.lblEndDate)
            Me.floDataDisplay.Controls.Add(Me.dtpEndDate)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(597, 208)
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
            Me.lblIdNo.Size = New System.Drawing.Size(148, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayCycleIdNo
            '
            Me.lblPayCycleIdNo.DisplayOnly = True
            Me.lblPayCycleIdNo.EditingMode = False
            Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleIdNo.Location = New System.Drawing.Point(11, 36)
            Me.lblPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
            Me.lblPayCycleIdNo.Size = New System.Drawing.Size(148, 23)
            Me.lblPayCycleIdNo.TabIndex = 156
            Me.lblPayCycleIdNo.Text = "Pay Cycle "
            Me.lblPayCycleIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CacPayCycleIdNo
            '
            Me.CacPayCycleIdNo.BackColor = System.Drawing.Color.White
            Me.CacPayCycleIdNo.ChangingSearchValueOnly = False
            Me.CacPayCycleIdNo.CurrentSearchTerm = ""
            Me.CacPayCycleIdNo.DefaultValue = Nothing
            Me.CacPayCycleIdNo.DisplayMember = "Name"
            Me.CacPayCycleIdNo.DropDownHeight = 200
            Me.CacPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CacPayCycleIdNo.EditingMode = True
            Me.CacPayCycleIdNo.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.CacPayCycleIdNo, True)
            Me.CacPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CacPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.CacPayCycleIdNo.FormattingEnabled = True
            Me.CacPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.CacPayCycleIdNo.LinkedLabel = Nothing
            Me.CacPayCycleIdNo.Location = New System.Drawing.Point(161, 36)
            Me.CacPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.CacPayCycleIdNo.Name = "CacPayCycleIdNo"
            Me.CacPayCycleIdNo.OldValue = 0
            Me.CacPayCycleIdNo.OriginalDataSource = Nothing
            Me.CacPayCycleIdNo.OriginalList = Nothing
            Me.CacPayCycleIdNo.OverrideDropDownStyleList = False
            Me.CacPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.CacPayCycleIdNo.PreviousSelectedIndex = -1
            Me.CacPayCycleIdNo.PropertySelector = Nothing
            Me.CacPayCycleIdNo.ReadOnlyCombo = False
            Me.CacPayCycleIdNo.SearchAnywhere = False
            Me.CacPayCycleIdNo.Size = New System.Drawing.Size(418, 24)
            Me.CacPayCycleIdNo.SuggestBoxHeight = 200
            Me.CacPayCycleIdNo.SuggestListOrderRule = Nothing
            Me.CacPayCycleIdNo.TabIndex = 1
            Me.CacPayCycleIdNo.TextToSearch = Nothing
            Me.CacPayCycleIdNo.ValueIsMandatory = False
            Me.CacPayCycleIdNo.ValueIsNullable = False
            Me.CacPayCycleIdNo.ValueIsNumeric = False
            Me.CacPayCycleIdNo.ValueMember = "IdNo"
            '
            'lblPayPeriodCode
            '
            Me.lblPayPeriodCode.DisplayOnly = True
            Me.lblPayPeriodCode.EditingMode = False
            Me.lblPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodCode.Location = New System.Drawing.Point(11, 62)
            Me.lblPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodCode.Name = "lblPayPeriodCode"
            Me.lblPayPeriodCode.Size = New System.Drawing.Size(148, 23)
            Me.lblPayPeriodCode.TabIndex = 168
            Me.lblPayPeriodCode.Text = "Code"
            Me.lblPayPeriodCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayPeriodCode
            '
            Me.txtPayPeriodCode.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayPeriodCode.ComputedValue = False
            Me.txtPayPeriodCode.CustomFormat = Nothing
            Me.txtPayPeriodCode.DataBoundControl = True
            Me.txtPayPeriodCode.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtPayPeriodCode, True)
            Me.txtPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodCode.LinkedLabel = Nothing
            Me.txtPayPeriodCode.Location = New System.Drawing.Point(161, 62)
            Me.txtPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodCode.MaximumValue = Nothing
            Me.txtPayPeriodCode.MinimumValue = Nothing
            Me.txtPayPeriodCode.Name = "txtPayPeriodCode"
            Me.txtPayPeriodCode.OldValue = Nothing
            Me.txtPayPeriodCode.ReadOnly = True
            Me.txtPayPeriodCode.Size = New System.Drawing.Size(72, 23)
            Me.txtPayPeriodCode.TabIndex = 2
            Me.txtPayPeriodCode.ValueIsMandatory = True
            '
            'lblPayPeriodName
            '
            Me.lblPayPeriodName.DisplayOnly = True
            Me.lblPayPeriodName.EditingMode = False
            Me.lblPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodName.Location = New System.Drawing.Point(11, 87)
            Me.lblPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodName.Name = "lblPayPeriodName"
            Me.lblPayPeriodName.Size = New System.Drawing.Size(148, 23)
            Me.lblPayPeriodName.TabIndex = 164
            Me.lblPayPeriodName.Text = "Name"
            Me.lblPayPeriodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayPeriodNameAra
            '
            Me.lblPayPeriodNameAra.DisplayOnly = True
            Me.lblPayPeriodNameAra.EditingMode = False
            Me.lblPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodNameAra.Location = New System.Drawing.Point(11, 112)
            Me.lblPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodNameAra.Name = "lblPayPeriodNameAra"
            Me.lblPayPeriodNameAra.Size = New System.Drawing.Size(148, 23)
            Me.lblPayPeriodNameAra.TabIndex = 167
            Me.lblPayPeriodNameAra.Text = "Name (Arabic)"
            Me.lblPayPeriodNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayPeriodNameAra
            '
            Me.txtPayPeriodNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayPeriodNameAra.ComputedValue = False
            Me.txtPayPeriodNameAra.CustomFormat = Nothing
            Me.txtPayPeriodNameAra.DataBoundControl = True
            Me.txtPayPeriodNameAra.EditingMode = False
            Me.txtPayPeriodNameAra.EnglishControl = Me.txtPayPeriodName
            Me.floDataDisplay.SetFlowBreak(Me.txtPayPeriodNameAra, True)
            Me.txtPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodNameAra.LinkedLabel = Nothing
            Me.txtPayPeriodNameAra.Location = New System.Drawing.Point(161, 112)
            Me.txtPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodNameAra.MaximumValue = Nothing
            Me.txtPayPeriodNameAra.MinimumValue = Nothing
            Me.txtPayPeriodNameAra.Name = "txtPayPeriodNameAra"
            Me.txtPayPeriodNameAra.OldValue = Nothing
            Me.txtPayPeriodNameAra.ReadOnly = True
            Me.txtPayPeriodNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayPeriodNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtPayPeriodNameAra.TabIndex = 4
            '
            'lblStartDate
            '
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.Location = New System.Drawing.Point(11, 137)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(148, 23)
            Me.lblStartDate.TabIndex = 157
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.floDataDisplay.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Nothing
            Me.dtpStartDate.Location = New System.Drawing.Point(161, 137)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(107, 25)
            Me.dtpStartDate.TabIndex = 5
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblEndDate
            '
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEndDate.Location = New System.Drawing.Point(11, 164)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(148, 23)
            Me.lblEndDate.TabIndex = 161
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = False
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Nothing
            Me.dtpEndDate.Location = New System.Drawing.Point(161, 164)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(107, 25)
            Me.dtpEndDate.TabIndex = 6
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'PayPeriodEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(898, 261)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayPeriodEntryTv"
            Me.Text = "Pay Period Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPayPeriodName As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayCycleIdNo As CLabel
        Friend WithEvents lblStartDate As CLabel
        Friend WithEvents lblEndDate As CLabel
        Friend WithEvents _MBPayPeriodCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents lblPayPeriodName As CLabel
        Friend WithEvents CacPayCycleIdNo As CaComboBox
        Friend WithEvents dtpStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblPayPeriodNameAra As CLabel
        Friend WithEvents txtPayPeriodNameAra As CTextBoxArabic
        Friend WithEvents lblPayPeriodCode As CLabel
        Friend WithEvents txtPayPeriodCode As CTextBox
    End Class
End Namespace