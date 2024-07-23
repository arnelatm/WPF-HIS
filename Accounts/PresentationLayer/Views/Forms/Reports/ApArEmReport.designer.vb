Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ApArEmReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApArEmReport))
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEndingDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.floButtons = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
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
            Me.lblIdNo.Location = New System.Drawing.Point(1, 30)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(132, 24)
            Me.lblIdNo.TabIndex = 22
            Me.lblIdNo.Text = "Employee Code:"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblEndingDate
            '
            Me.lblEndingDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndingDate.DisplayOnly = True
            Me.lblEndingDate.EditingMode = False
            Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndingDate.Location = New System.Drawing.Point(256, 1)
            Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndingDate.Name = "lblEndingDate"
            Me.lblEndingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblEndingDate.Size = New System.Drawing.Size(349, 25)
            Me.lblEndingDate.TabIndex = 21
            Me.lblEndingDate.Text = "Ending Date:"
            Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndingDate.Translatable = True
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.BackColor = System.Drawing.Color.Transparent
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBeginningDate.Location = New System.Drawing.Point(1, 1)
            Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBeginningDate.Name = "lblBeginningDate"
            Me.lblBeginningDate.Size = New System.Drawing.Size(132, 25)
            Me.lblBeginningDate.TabIndex = 20
            Me.lblBeginningDate.Text = "Beginning Date :"
            Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBeginningDate.Translatable = True
            '
            'cboIdNo
            '
            Me.cboIdNo.BackColor = System.Drawing.Color.White
            Me.cboIdNo.BegFindValue = Nothing
            Me.cboIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboIdNo, 3)
            Me.cboIdNo.CurrentSearchTerm = ""
            Me.cboIdNo.DataValue = Nothing
            Me.cboIdNo.DefaultValue = Nothing
            Me.cboIdNo.DisplayMember = "Name"
            Me.cboIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboIdNo.DropDownHeight = 24
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
            Me.cboIdNo.Location = New System.Drawing.Point(135, 30)
            Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboIdNo.MaxDropDownItems = 1
            Me.cboIdNo.Name = "cboIdNo"
            Me.cboIdNo.OldValue = 0
            Me.cboIdNo.OriginalDataSource = Nothing
            Me.cboIdNo.OriginalList = Nothing
            Me.cboIdNo.OverrideDropDownStyleList = False
            Me.cboIdNo.PreviousSearchTerm = Nothing
            Me.cboIdNo.Size = New System.Drawing.Size(668, 25)
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
            'dtpEndingDate
            '
            Me.dtpEndingDate.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.dtpEndingDate.AutoSize = True
            Me.dtpEndingDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpEndingDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndingDate.DefaultValue = Nothing
            Me.dtpEndingDate.DisplayOnly = False
            Me.dtpEndingDate.DtpDefaultValue = Nothing
            Me.dtpEndingDate.EditingMode = True
            Me.dtpEndingDate.EditsAllowed = False
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(607, 1)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpEndingDate.TabIndex = 24
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Translatable = False
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'dtpBeginningDate
            '
            Me.dtpBeginningDate.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.dtpBeginningDate.AutoSize = True
            Me.dtpBeginningDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpBeginningDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBeginningDate.DefaultValue = Nothing
            Me.dtpBeginningDate.DisplayOnly = False
            Me.dtpBeginningDate.DtpDefaultValue = Nothing
            Me.dtpBeginningDate.EditingMode = True
            Me.dtpBeginningDate.EditsAllowed = False
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            Me.dtpBeginningDate.Location = New System.Drawing.Point(135, 1)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpBeginningDate.TabIndex = 23
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Translatable = False
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblTitle)
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 30)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(811, 180)
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
            Me.lblTitle.Size = New System.Drawing.Size(805, 24)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Statement of Employee Leaves"
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
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndingDate, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndingDate, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpBeginningDate, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBeginningDate, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.floButtons, 0, 3)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 29)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(804, 121)
            Me.TableLayoutPanel1.TabIndex = 30
            '
            'floButtons
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.floButtons, 4)
            Me.floButtons.Controls.Add(Me.btnCancel)
            Me.floButtons.Controls.Add(Me.btnOk)
            Me.floButtons.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floButtons.Location = New System.Drawing.Point(3, 74)
            Me.floButtons.Name = "floButtons"
            Me.floButtons.Padding = New System.Windows.Forms.Padding(300, 0, 0, 0)
            Me.floButtons.Size = New System.Drawing.Size(798, 44)
            Me.floButtons.TabIndex = 26
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
            Me.MyErrorProvider.SetIconAlignment(Me.btnCancel, System.Windows.Forms.ErrorIconAlignment.BottomLeft)
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(303, 3)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.btnCancel.Size = New System.Drawing.Size(90, 35)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(399, 3)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 35)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'ApArEmReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(828, 198)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.DoubleBuffered = True
            Me.FormCulture = New System.Globalization.CultureInfo("en-GB")
            Me.Name = "ApArEmReport"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.RightToLeftDisplay = "False"
            Me.Text = "Statement of Employee Leaves"
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.floButtons.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEndingDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CdtComboBox
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblTitle As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents floButtons As FlowLayoutPanel
    End Class
End Namespace