Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace Accounts.PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DateTimeRangeForm
        Inherits BfMain

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateTimeRangeForm))
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEndingDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(0, 0)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(478, 39)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Date Range Selection"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'cboContactIdNo
            '
            Me.cboContactIdNo.BackColor = System.Drawing.Color.White
            Me.cboContactIdNo.BegFindValue = Nothing
            Me.cboContactIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboContactIdNo, 2)
            Me.cboContactIdNo.CurrentSearchTerm = ""
            Me.cboContactIdNo.DataValue = Nothing
            Me.cboContactIdNo.DefaultValue = Nothing
            Me.cboContactIdNo.DisplayMember = "Name"
            Me.cboContactIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboContactIdNo.DropDownHeight = 24
            Me.cboContactIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboContactIdNo.Editable = True
            Me.cboContactIdNo.EditingMode = False
            Me.cboContactIdNo.EndFindValue = Nothing
            Me.cboContactIdNo.FieldDescription = Nothing
            Me.cboContactIdNo.FieldName = Nothing
            Me.cboContactIdNo.FilterRule = Nothing
            Me.cboContactIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboContactIdNo.FindEnabled = False
            Me.cboContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboContactIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboContactIdNo.FormattingEnabled = True
            Me.cboContactIdNo.HideWhenNotEditingOrAdding = False
            Me.cboContactIdNo.IgnoreCase = False
            Me.cboContactIdNo.LimitToList = False
            Me.cboContactIdNo.LinkedLabel = Nothing
            Me.cboContactIdNo.Location = New System.Drawing.Point(121, 70)
            Me.cboContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboContactIdNo.MaxDropDownItems = 1
            Me.cboContactIdNo.Name = "cboContactIdNo"
            Me.cboContactIdNo.OldValue = 0
            Me.cboContactIdNo.OriginalDataSource = Nothing
            Me.cboContactIdNo.OriginalList = Nothing
            Me.cboContactIdNo.OverrideDropDownStyleList = False
            Me.cboContactIdNo.PreviousSearchTerm = Nothing
            Me.cboContactIdNo.PropertySelector = Nothing
            Me.cboContactIdNo.Size = New System.Drawing.Size(342, 28)
            Me.cboContactIdNo.SuggestBoxHeight = 200
            Me.cboContactIdNo.SuggestCharCount = 0
            Me.cboContactIdNo.SuggestListOrderRule = Nothing
            Me.cboContactIdNo.TabIndex = 30
            Me.cboContactIdNo.TextToSearch = Nothing
            Me.cboContactIdNo.Translatable = False
            Me.cboContactIdNo.ValueIsMandatory = False
            Me.cboContactIdNo.ValueIsNullable = False
            Me.cboContactIdNo.ValueIsNumeric = False
            Me.cboContactIdNo.ValueMember = "IdNo"
            '
            'btnOk
            '
            Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(81, 7)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(65, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(299, 7)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(83, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'lblContactIdNo
            '
            Me.lblContactIdNo.AutoSize = True
            Me.lblContactIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblContactIdNo.DisplayOnly = True
            Me.lblContactIdNo.EditingMode = False
            Me.lblContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblContactIdNo.Location = New System.Drawing.Point(1, 70)
            Me.lblContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblContactIdNo.Name = "lblContactIdNo"
            Me.lblContactIdNo.Size = New System.Drawing.Size(116, 20)
            Me.lblContactIdNo.TabIndex = 31
            Me.lblContactIdNo.Text = "Contact Name"
            Me.lblContactIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblContactIdNo.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.86207!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.18103!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.9569!))
            Me.TableLayoutPanel1.Controls.Add(Me.cboContactIdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblContactIdNo, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CFlowLayout1, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndingDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBeginningDate, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndingDate, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpBeginningDate, 1, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 44)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(464, 139)
            Me.TableLayoutPanel1.TabIndex = 29
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.AutoSize = True
            Me.CFlowLayout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CFlowLayout1, 3)
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel2)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(3, 102)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(458, 45)
            Me.CFlowLayout1.TabIndex = 32
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.btnOk, 0, 0)
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 1
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(455, 39)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'dtpEndingDate
            '
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
            Me.dtpEndingDate.Location = New System.Drawing.Point(120, 42)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = True
            Me.dtpEndingDate.Size = New System.Drawing.Size(205, 27)
            Me.dtpEndingDate.TabIndex = 34
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Translatable = False
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.AutoSize = True
            Me.lblBeginningDate.BackColor = System.Drawing.Color.Transparent
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBeginningDate.Location = New System.Drawing.Point(1, 1)
            Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBeginningDate.Name = "lblBeginningDate"
            Me.lblBeginningDate.Size = New System.Drawing.Size(88, 40)
            Me.lblBeginningDate.TabIndex = 35
            Me.lblBeginningDate.Text = "Beginning Date"
            Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBeginningDate.Translatable = True
            '
            'lblEndingDate
            '
            Me.lblEndingDate.AutoSize = True
            Me.lblEndingDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndingDate.DisplayOnly = True
            Me.lblEndingDate.EditingMode = False
            Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndingDate.Location = New System.Drawing.Point(1, 43)
            Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndingDate.Name = "lblEndingDate"
            Me.lblEndingDate.Size = New System.Drawing.Size(101, 20)
            Me.lblEndingDate.TabIndex = 36
            Me.lblEndingDate.Text = "Ending Date"
            Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndingDate.Translatable = True
            '
            'dtpBeginningDate
            '
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
            Me.dtpBeginningDate.Location = New System.Drawing.Point(120, 0)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = True
            Me.dtpBeginningDate.Size = New System.Drawing.Size(205, 27)
            Me.dtpBeginningDate.TabIndex = 33
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Translatable = False
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'DateTimeRangeForm
            '
            Me.ClientSize = New System.Drawing.Size(478, 181)
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.Name = "DateTimeRangeForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Date Range Selection"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Private WithEvents btnOk As CButton
        Private WithEvents btnCancel As CButton
        Friend WithEvents cboContactIdNo As CtComboBox
        Friend WithEvents lblContactIdNo As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents lblBeginningDate As CLabel
        Friend WithEvents lblEndingDate As CLabel
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
    End Class
End Namespace