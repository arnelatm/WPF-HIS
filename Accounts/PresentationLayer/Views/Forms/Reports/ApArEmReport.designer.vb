Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ApArEmReport
        Inherits AATM.PresentationLayer.Forms.BfMain

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
            Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 28)
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
            Me.lblEndingDate.DisplayOnly = True
            Me.lblEndingDate.EditingMode = False
            Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndingDate.Location = New System.Drawing.Point(269, 1)
            Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndingDate.Name = "lblEndingDate"
            Me.lblEndingDate.Size = New System.Drawing.Size(132, 25)
            Me.lblEndingDate.TabIndex = 21
            Me.lblEndingDate.Text = "Ending Date:"
            Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndingDate.Translatable = True
            '
            'lblBeginningDate
            '
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
            Me.cboIdNo.DropDownHeight = 21
            Me.cboIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboIdNo.Editable = True
            Me.cboIdNo.EditingMode = False
            Me.cboIdNo.EndFindValue = Nothing
            Me.cboIdNo.FieldDescription = Nothing
            Me.cboIdNo.FieldName = Nothing
            Me.cboIdNo.FilterRule = Nothing
            Me.cboIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboIdNo.FindEnabled = False
            Me.cboIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboIdNo.FormattingEnabled = True
            Me.cboIdNo.HideWhenNotEditingOrAdding = False
            Me.cboIdNo.IgnoreCase = False
            Me.cboIdNo.LimitToList = False
            Me.cboIdNo.LinkedLabel = Nothing
            Me.cboIdNo.Location = New System.Drawing.Point(135, 28)
            Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboIdNo.MaxDropDownItems = 1
            Me.cboIdNo.Name = "cboIdNo"
            Me.cboIdNo.OldValue = 0
            Me.cboIdNo.OriginalDataSource = Nothing
            Me.cboIdNo.OriginalList = Nothing
            Me.cboIdNo.OverrideDropDownStyleList = False
            Me.cboIdNo.PreviousSearchTerm = Nothing
            Me.cboIdNo.PropertySelector = Nothing
            Me.cboIdNo.ReadOnlyCombo = False
            Me.cboIdNo.Size = New System.Drawing.Size(399, 24)
            Me.cboIdNo.SuggestBoxHeight = 200
            Me.cboIdNo.SuggestListOrderRule = Nothing
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
            Me.dtpEndingDate.Location = New System.Drawing.Point(403, 2)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(118, 23)
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
            Me.dtpBeginningDate.Location = New System.Drawing.Point(135, 2)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(118, 23)
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(543, 148)
            Me.CFlowLayout1.TabIndex = 26
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblTitle.DisplayOnly = True
            Me.lblTitle.EditingMode = False
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.lblTitle.Location = New System.Drawing.Point(1, 1)
            Me.lblTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(534, 25)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Statement of Employee Leaves"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblTitle.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndingDate, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndingDate, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpBeginningDate, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBeginningDate, 0, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 30)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(537, 98)
            Me.TableLayoutPanel1.TabIndex = 30
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(290, 71)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 24)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(156, 71)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 24)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(25, 37)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(150, 25)
            Me.CLabel1.TabIndex = 26
            Me.CLabel1.Text = "Beginning Date :"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'ApArEmReport
            '
            Me.ClientSize = New System.Drawing.Size(556, 160)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "ApArEmReport"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Statement of Employee Leaves"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEndingDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblTitle As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    End Class
End NameSpace