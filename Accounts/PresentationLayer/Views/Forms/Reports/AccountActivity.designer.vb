Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountActivity
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Me.lblEndDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblBegDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboStartAccountCode = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEndAccountCode = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnTranslate = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'lblEndDateCaption
        '
        Me.lblEndDateCaption.DisplayOnly = true
        Me.lblEndDateCaption.EditingMode = false
        Me.lblEndDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndDateCaption.Location = New System.Drawing.Point(11, 38)
        Me.lblEndDateCaption.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDateCaption.Name = "lblEndDateCaption"
        Me.lblEndDateCaption.Size = New System.Drawing.Size(171, 25)
        Me.lblEndDateCaption.TabIndex = 21
        Me.lblEndDateCaption.Text = "Ending Date:"
        Me.lblEndDateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDateCaption.Translatable = True
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
            Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, True)
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(184, 38)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpEndingDate.TabIndex = 1
            Me.dtpEndingDate.TargetCalendar = Nothing
            Me.dtpEndingDate.Translatable = False
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblBegDateCaption)
            Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.lblEndDateCaption)
            Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.cboStartAccountCode)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.cboEndAccountCode)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(719, 133)
            Me.CFlowLayout1.TabIndex = 26
            '
            'lblBegDateCaption
            '
            Me.lblBegDateCaption.DisplayOnly = True
            Me.lblBegDateCaption.EditingMode = False
            Me.lblBegDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBegDateCaption.Location = New System.Drawing.Point(11, 11)
            Me.lblBegDateCaption.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBegDateCaption.Name = "lblBegDateCaption"
            Me.lblBegDateCaption.Size = New System.Drawing.Size(171, 25)
            Me.lblBegDateCaption.TabIndex = 25
            Me.lblBegDateCaption.Text = "Start Date:"
            Me.lblBegDateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBegDateCaption.Translatable = True
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
            Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, True)
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            Me.dtpBeginningDate.Location = New System.Drawing.Point(184, 11)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpBeginningDate.TabIndex = 0
            Me.dtpBeginningDate.TargetCalendar = Nothing
            Me.dtpBeginningDate.Translatable = False
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(11, 65)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(171, 25)
            Me.CLabel2.TabIndex = 27
            Me.CLabel2.Text = "Starting Account"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'cboStartAccountCode
            '
            Me.cboStartAccountCode.BackColor = System.Drawing.Color.White
            Me.cboStartAccountCode.BegFindValue = Nothing
            Me.cboStartAccountCode.ChangingSearchValueOnly = False
            Me.cboStartAccountCode.CurrentSearchTerm = ""
            Me.cboStartAccountCode.DataValue = Nothing
            Me.cboStartAccountCode.DefaultValue = Nothing
            Me.cboStartAccountCode.DisplayMember = "Name"
            Me.cboStartAccountCode.DropDownHeight = 24
            Me.cboStartAccountCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboStartAccountCode.Editable = True
            Me.cboStartAccountCode.EditingMode = False
            Me.cboStartAccountCode.EndFindValue = Nothing
            Me.cboStartAccountCode.FieldDescription = Nothing
            Me.cboStartAccountCode.FieldName = Nothing
            Me.cboStartAccountCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboStartAccountCode.FindEnabled = False
            Me.cboStartAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboStartAccountCode.ForeColor = System.Drawing.Color.Black
            Me.cboStartAccountCode.FormattingEnabled = True
            Me.cboStartAccountCode.HideWhenNotEditingOrAdding = False
            Me.cboStartAccountCode.IgnoreCase = False
            Me.cboStartAccountCode.LimitToList = False
            Me.cboStartAccountCode.LinkedLabel = Nothing
            Me.cboStartAccountCode.Location = New System.Drawing.Point(184, 65)
            Me.cboStartAccountCode.Margin = New System.Windows.Forms.Padding(1)
            Me.cboStartAccountCode.MaxDropDownItems = 1
            Me.cboStartAccountCode.Name = "cboStartAccountCode"
            Me.cboStartAccountCode.OldValue = 0
            Me.cboStartAccountCode.OriginalDataSource = Nothing
            Me.cboStartAccountCode.OriginalList = Nothing
            Me.cboStartAccountCode.OverrideDropDownStyleList = False
            Me.cboStartAccountCode.PreviousSearchTerm = Nothing
            Me.cboStartAccountCode.Size = New System.Drawing.Size(520, 24)
            Me.cboStartAccountCode.SuggestBoxHeight = 200
            Me.cboStartAccountCode.TabIndex = 2
            Me.cboStartAccountCode.TextToSearch = Nothing
            Me.cboStartAccountCode.Translatable = False
            Me.cboStartAccountCode.ValueIsMandatory = False
            Me.cboStartAccountCode.ValueIsNullable = False
            Me.cboStartAccountCode.ValueIsNumeric = False
            Me.cboStartAccountCode.ValueMember = "Code"
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(11, 92)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(171, 25)
            Me.CLabel3.TabIndex = 28
            Me.CLabel3.Text = "Ending Account"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'cboEndAccountCode
            '
            Me.cboEndAccountCode.BackColor = System.Drawing.Color.White
            Me.cboEndAccountCode.BegFindValue = Nothing
            Me.cboEndAccountCode.ChangingSearchValueOnly = False
            Me.cboEndAccountCode.CurrentSearchTerm = ""
            Me.cboEndAccountCode.DataValue = Nothing
            Me.cboEndAccountCode.DefaultValue = Nothing
            Me.cboEndAccountCode.DisplayMember = "Name"
            Me.cboEndAccountCode.DropDownHeight = 24
            Me.cboEndAccountCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboEndAccountCode.Editable = True
            Me.cboEndAccountCode.EditingMode = False
            Me.cboEndAccountCode.EndFindValue = Nothing
            Me.cboEndAccountCode.FieldDescription = Nothing
            Me.cboEndAccountCode.FieldName = Nothing
            Me.cboEndAccountCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEndAccountCode.FindEnabled = False
            Me.cboEndAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEndAccountCode.ForeColor = System.Drawing.Color.Black
            Me.cboEndAccountCode.FormattingEnabled = True
            Me.cboEndAccountCode.HideWhenNotEditingOrAdding = False
            Me.cboEndAccountCode.IgnoreCase = False
            Me.cboEndAccountCode.LimitToList = False
            Me.cboEndAccountCode.LinkedLabel = Nothing
            Me.cboEndAccountCode.Location = New System.Drawing.Point(184, 92)
            Me.cboEndAccountCode.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEndAccountCode.MaxDropDownItems = 1
            Me.cboEndAccountCode.Name = "cboEndAccountCode"
            Me.cboEndAccountCode.OldValue = 0
            Me.cboEndAccountCode.OriginalDataSource = Nothing
            Me.cboEndAccountCode.OriginalList = Nothing
            Me.cboEndAccountCode.OverrideDropDownStyleList = False
            Me.cboEndAccountCode.PreviousSearchTerm = Nothing
            Me.cboEndAccountCode.Size = New System.Drawing.Size(520, 24)
            Me.cboEndAccountCode.SuggestBoxHeight = 200
            Me.cboEndAccountCode.TabIndex = 3
            Me.cboEndAccountCode.TextToSearch = Nothing
            Me.cboEndAccountCode.Translatable = False
            Me.cboEndAccountCode.ValueIsMandatory = False
            Me.cboEndAccountCode.ValueIsNullable = False
            Me.cboEndAccountCode.ValueIsNumeric = False
            Me.cboEndAccountCode.ValueMember = "Code"
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblTitle.DisplayOnly = True
            Me.lblTitle.EditingMode = False
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(740, 25)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Account Activity Report"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblTitle.Translatable = True
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
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(316, 189)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 1
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(425, 189)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnTranslate
            '
            Me.btnTranslate.DesignerSelected = False
            Me.btnTranslate.ImageIndex = 0
            Me.btnTranslate.Location = New System.Drawing.Point(206, 189)
            Me.btnTranslate.Name = "btnTranslate"
            Me.btnTranslate.OriginalImageName = Nothing
            Me.btnTranslate.SecurityKey = ""
            Me.btnTranslate.Size = New System.Drawing.Size(89, 25)
            Me.btnTranslate.TabIndex = 29
            Me.btnTranslate.Text = "Translate"
            '
            'AccountActivity
            '
            Me.ClientSize = New System.Drawing.Size(738, 226)
            Me.Controls.Add(Me.btnTranslate)
            Me.Controls.Add(Me.lblTitle)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "AccountActivity"
            Me.Text = "Account Activity Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblEndDateCaption As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblTitle As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnTranslate As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents lblBegDateCaption As Libraries.CBaseControlsLibrary.CLabel
    End Class
End NameSpace