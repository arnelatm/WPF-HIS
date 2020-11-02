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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CacPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnInitialize = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton3 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
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
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.Editable = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(145, 27)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(72, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtPayPeriodName
        '
        Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
        Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodName, 3)
        Me.txtPayPeriodName.ComputedValue = false
        Me.txtPayPeriodName.CustomFormat = Nothing
        Me.txtPayPeriodName.DataBoundControl = true
        Me.txtPayPeriodName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayPeriodName.EditingMode = false
        Me.txtPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
        Me.txtPayPeriodName.LinkedLabel = Nothing
        Me.txtPayPeriodName.Location = New System.Drawing.Point(145, 52)
        Me.txtPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayPeriodName.MaximumValue = Nothing
        Me.txtPayPeriodName.MinimumValue = Nothing
        Me.txtPayPeriodName.Name = "txtPayPeriodName"
        Me.txtPayPeriodName.OldValue = Nothing
        Me.txtPayPeriodName.ReadOnly = true
        Me.txtPayPeriodName.Size = New System.Drawing.Size(432, 23)
        Me.txtPayPeriodName.TabIndex = 3
        Me.txtPayPeriodName.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(599, 208)
        Me.floDataDisplay.TabIndex = 147
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStartDate, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodNameAra, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodNameAra, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodCode, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodCode, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CacPayCycleIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayCycleIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodName, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInitialize, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CButton2, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CButton3, 2, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(578, 182)
        Me.TableLayoutPanel1.TabIndex = 169
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = false
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = true
        Me.dtpStartDate.EditsAllowed = false
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Nothing
        Me.dtpStartDate.Location = New System.Drawing.Point(145, 102)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpStartDate.TabIndex = 5
        Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = false
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(433, 102)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpEndDate.TabIndex = 6
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'lblStartDate
        '
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStartDate.Location = New System.Drawing.Point(1, 102)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(142, 23)
        Me.lblStartDate.TabIndex = 157
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayPeriodNameAra
        '
        Me.txtPayPeriodNameAra.BackColor = System.Drawing.Color.White
        Me.txtPayPeriodNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodNameAra, 3)
        Me.txtPayPeriodNameAra.ComputedValue = false
        Me.txtPayPeriodNameAra.CustomFormat = Nothing
        Me.txtPayPeriodNameAra.DataBoundControl = true
        Me.txtPayPeriodNameAra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayPeriodNameAra.EditingMode = false
        Me.txtPayPeriodNameAra.EnglishControl = Me.txtPayPeriodName
        Me.txtPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayPeriodNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPayPeriodNameAra.LinkedLabel = Nothing
        Me.txtPayPeriodNameAra.Location = New System.Drawing.Point(145, 77)
        Me.txtPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayPeriodNameAra.MaximumValue = Nothing
        Me.txtPayPeriodNameAra.MinimumValue = Nothing
        Me.txtPayPeriodNameAra.Name = "txtPayPeriodNameAra"
        Me.txtPayPeriodNameAra.OldValue = Nothing
        Me.txtPayPeriodNameAra.ReadOnly = true
        Me.txtPayPeriodNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPayPeriodNameAra.Size = New System.Drawing.Size(432, 23)
        Me.txtPayPeriodNameAra.TabIndex = 4
        '
        'lblPayPeriodNameAra
        '
        Me.lblPayPeriodNameAra.DisplayOnly = true
        Me.lblPayPeriodNameAra.EditingMode = false
        Me.lblPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayPeriodNameAra.Location = New System.Drawing.Point(1, 77)
        Me.lblPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayPeriodNameAra.Name = "lblPayPeriodNameAra"
        Me.lblPayPeriodNameAra.Size = New System.Drawing.Size(142, 23)
        Me.lblPayPeriodNameAra.TabIndex = 167
        Me.lblPayPeriodNameAra.Text = "Name (Arabic)"
        Me.lblPayPeriodNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayPeriodName
        '
        Me.lblPayPeriodName.DisplayOnly = true
        Me.lblPayPeriodName.EditingMode = false
        Me.lblPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayPeriodName.Location = New System.Drawing.Point(1, 52)
        Me.lblPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayPeriodName.Name = "lblPayPeriodName"
        Me.lblPayPeriodName.Size = New System.Drawing.Size(142, 23)
        Me.lblPayPeriodName.TabIndex = 164
        Me.lblPayPeriodName.Text = "Name"
        Me.lblPayPeriodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEndDate.Location = New System.Drawing.Point(289, 102)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(142, 23)
        Me.lblEndDate.TabIndex = 161
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayPeriodCode
        '
        Me.txtPayPeriodCode.BackColor = System.Drawing.Color.White
        Me.txtPayPeriodCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayPeriodCode.ComputedValue = false
        Me.txtPayPeriodCode.CustomFormat = Nothing
        Me.txtPayPeriodCode.DataBoundControl = true
        Me.txtPayPeriodCode.EditingMode = false
        Me.txtPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayPeriodCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayPeriodCode.LinkedLabel = Nothing
        Me.txtPayPeriodCode.Location = New System.Drawing.Point(433, 27)
        Me.txtPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayPeriodCode.MaximumValue = Nothing
        Me.txtPayPeriodCode.MinimumValue = Nothing
        Me.txtPayPeriodCode.Name = "txtPayPeriodCode"
        Me.txtPayPeriodCode.OldValue = Nothing
        Me.txtPayPeriodCode.ReadOnly = true
        Me.txtPayPeriodCode.Size = New System.Drawing.Size(72, 23)
        Me.txtPayPeriodCode.TabIndex = 2
        Me.txtPayPeriodCode.ValueIsMandatory = true
        '
        'lblPayPeriodCode
        '
        Me.lblPayPeriodCode.DisplayOnly = true
        Me.lblPayPeriodCode.EditingMode = false
        Me.lblPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayPeriodCode.Location = New System.Drawing.Point(289, 27)
        Me.lblPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayPeriodCode.Name = "lblPayPeriodCode"
        Me.lblPayPeriodCode.Size = New System.Drawing.Size(78, 23)
        Me.lblPayPeriodCode.TabIndex = 168
        Me.lblPayPeriodCode.Text = "Code"
        Me.lblPayPeriodCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CacPayCycleIdNo
        '
        Me.CacPayCycleIdNo.BackColor = System.Drawing.Color.White
        Me.CacPayCycleIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.CacPayCycleIdNo, 3)
        Me.CacPayCycleIdNo.CurrentSearchTerm = ""
        Me.CacPayCycleIdNo.DefaultValue = Nothing
        Me.CacPayCycleIdNo.DisplayMember = "Name"
        Me.CacPayCycleIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CacPayCycleIdNo.DropDownHeight = 200
        Me.CacPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CacPayCycleIdNo.EditingMode = true
        Me.CacPayCycleIdNo.FilterRule = Nothing
        Me.CacPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CacPayCycleIdNo.ForeColor = System.Drawing.Color.Black
        Me.CacPayCycleIdNo.FormattingEnabled = true
        Me.CacPayCycleIdNo.HideWhenNotEditingOrAdding = false
        Me.CacPayCycleIdNo.LinkedLabel = Nothing
        Me.CacPayCycleIdNo.Location = New System.Drawing.Point(145, 1)
        Me.CacPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.CacPayCycleIdNo.Name = "CacPayCycleIdNo"
        Me.CacPayCycleIdNo.OldValue = 0
        Me.CacPayCycleIdNo.OriginalDataSource = Nothing
        Me.CacPayCycleIdNo.OriginalList = Nothing
        Me.CacPayCycleIdNo.OverrideDropDownStyleList = false
        Me.CacPayCycleIdNo.PreviousSearchTerm = Nothing
        Me.CacPayCycleIdNo.PreviousSelectedIndex = -1
        Me.CacPayCycleIdNo.PropertySelector = Nothing
        Me.CacPayCycleIdNo.ReadOnlyCombo = false
        Me.CacPayCycleIdNo.SearchAnywhere = false
        Me.CacPayCycleIdNo.Size = New System.Drawing.Size(432, 24)
        Me.CacPayCycleIdNo.SuggestBoxHeight = 200
        Me.CacPayCycleIdNo.SuggestListOrderRule = Nothing
        Me.CacPayCycleIdNo.TabIndex = 1
        Me.CacPayCycleIdNo.TextToSearch = Nothing
        Me.CacPayCycleIdNo.ValueIsMandatory = false
        Me.CacPayCycleIdNo.ValueIsNullable = false
        Me.CacPayCycleIdNo.ValueIsNumeric = false
        Me.CacPayCycleIdNo.ValueMember = "IdNo"
        '
        'lblPayCycleIdNo
        '
        Me.lblPayCycleIdNo.DisplayOnly = true
        Me.lblPayCycleIdNo.EditingMode = false
        Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayCycleIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
        Me.lblPayCycleIdNo.Size = New System.Drawing.Size(142, 23)
        Me.lblPayCycleIdNo.TabIndex = 156
        Me.lblPayCycleIdNo.Text = "Pay Cycle "
        Me.lblPayCycleIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 27)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(142, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnInitialize
        '
        Me.btnInitialize.DesignerSelected = true
        Me.btnInitialize.DisplayOnly = true
        Me.btnInitialize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInitialize.ImageIndex = 0
        Me.btnInitialize.Location = New System.Drawing.Point(3, 131)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.OriginalImageName = Nothing
        Me.btnInitialize.SecurityKey = ""
        Me.btnInitialize.Size = New System.Drawing.Size(138, 48)
        Me.btnInitialize.TabIndex = 169
        Me.btnInitialize.Text = "Initialize Payroll"
        '
        'CButton2
        '
        Me.CButton2.DesignerSelected = false
        Me.CButton2.DisplayOnly = true
        Me.CButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CButton2.ImageIndex = 0
        Me.CButton2.Location = New System.Drawing.Point(147, 131)
        Me.CButton2.Name = "CButton2"
        Me.CButton2.OriginalImageName = Nothing
        Me.CButton2.SecurityKey = ""
        Me.CButton2.Size = New System.Drawing.Size(138, 48)
        Me.CButton2.TabIndex = 170
        Me.CButton2.Text = "Enter Payments/ Deductions"
        '
        'CButton3
        '
        Me.CButton3.DesignerSelected = false
        Me.CButton3.DisplayOnly = true
        Me.CButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CButton3.ImageIndex = 0
        Me.CButton3.Location = New System.Drawing.Point(291, 131)
        Me.CButton3.Name = "CButton3"
        Me.CButton3.OriginalImageName = Nothing
        Me.CButton3.SecurityKey = ""
        Me.CButton3.Size = New System.Drawing.Size(138, 48)
        Me.CButton3.TabIndex = 171
        Me.CButton3.Text = "View Payroll Report"
        '
        'PayPeriodEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(906, 261)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PayPeriodEntryTv"
        Me.Text = "Pay Period Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnInitialize As CButton
        Friend WithEvents CButton2 As CButton
        Friend WithEvents CButton3 As CButton
    End Class
End Namespace