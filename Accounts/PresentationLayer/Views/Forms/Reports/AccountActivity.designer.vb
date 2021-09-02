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
        Me.cboStartAccountCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEndAccountCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DisplayOnly = false
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditingMode = true
        Me.dtpEndingDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, true)
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(184, 38)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = false
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = false
        Me.dtpEndingDate.ShowTime = false
        Me.dtpEndingDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpEndingDate.TabIndex = 1
        Me.dtpEndingDate.TargetCalendar = Nothing
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = false
        Me.dtpEndingDate.ValueIsNullable = false
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
        Me.lblBegDateCaption.DisplayOnly = true
        Me.lblBegDateCaption.EditingMode = false
        Me.lblBegDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBegDateCaption.Location = New System.Drawing.Point(11, 11)
        Me.lblBegDateCaption.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBegDateCaption.Name = "lblBegDateCaption"
        Me.lblBegDateCaption.Size = New System.Drawing.Size(171, 25)
        Me.lblBegDateCaption.TabIndex = 25
        Me.lblBegDateCaption.Text = "Start Date:"
        Me.lblBegDateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DisplayOnly = false
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditingMode = true
        Me.dtpBeginningDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, true)
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(184, 11)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = false
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = false
        Me.dtpBeginningDate.ShowTime = false
        Me.dtpBeginningDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpBeginningDate.TabIndex = 0
        Me.dtpBeginningDate.TargetCalendar = Nothing
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = false
        Me.dtpBeginningDate.ValueIsNullable = false
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(11, 65)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(171, 25)
        Me.CLabel2.TabIndex = 27
        Me.CLabel2.Text = "Starting Account"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStartAccountCode
        '
        Me.cboStartAccountCode.BackColor = System.Drawing.Color.White
        Me.cboStartAccountCode.BegFindValue = Nothing
        Me.cboStartAccountCode.ChangingSearchValueOnly = false
        Me.cboStartAccountCode.CurrentSearchTerm = ""
        Me.cboStartAccountCode.DefaultValue = Nothing
        Me.cboStartAccountCode.DisplayMember = "Name"
        Me.cboStartAccountCode.EditingMode = true
        Me.cboStartAccountCode.EndFindValue = Nothing
        Me.cboStartAccountCode.FieldName = Nothing
        Me.cboStartAccountCode.FilterRule = Nothing
        Me.cboStartAccountCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboStartAccountCode.FindEnabled = false
        Me.cboStartAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboStartAccountCode.ForeColor = System.Drawing.Color.Black
        Me.cboStartAccountCode.FormattingEnabled = true
        Me.cboStartAccountCode.HideWhenNotEditingOrAdding = false
        Me.cboStartAccountCode.IntegralHeight = false
        Me.cboStartAccountCode.LinkedLabel = Nothing
        Me.cboStartAccountCode.Location = New System.Drawing.Point(184, 65)
        Me.cboStartAccountCode.Margin = New System.Windows.Forms.Padding(1)
        Me.cboStartAccountCode.Name = "cboStartAccountCode"
        Me.cboStartAccountCode.OldValue = 0
        Me.cboStartAccountCode.OriginalDataSource = Nothing
        Me.cboStartAccountCode.OriginalList = Nothing
        Me.cboStartAccountCode.OverrideDropDownStyleList = false
        Me.cboStartAccountCode.PreviousSearchTerm = Nothing
        Me.cboStartAccountCode.PropertySelector = Nothing
        Me.cboStartAccountCode.ReadOnlyCombo = false
        Me.cboStartAccountCode.Size = New System.Drawing.Size(520, 24)
        Me.cboStartAccountCode.SuggestBoxHeight = 200
        Me.cboStartAccountCode.SuggestListOrderRule = Nothing
        Me.cboStartAccountCode.TabIndex = 2
        Me.cboStartAccountCode.TextToSearch = Nothing
        Me.cboStartAccountCode.ValueIsMandatory = false
        Me.cboStartAccountCode.ValueIsNullable = false
        Me.cboStartAccountCode.ValueIsNumeric = false
        Me.cboStartAccountCode.ValueMember = "Code"
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(11, 92)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(171, 25)
        Me.CLabel3.TabIndex = 28
        Me.CLabel3.Text = "Ending Account"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEndAccountCode
        '
        Me.cboEndAccountCode.BackColor = System.Drawing.Color.White
        Me.cboEndAccountCode.BegFindValue = Nothing
        Me.cboEndAccountCode.ChangingSearchValueOnly = false
        Me.cboEndAccountCode.CurrentSearchTerm = ""
        Me.cboEndAccountCode.DefaultValue = Nothing
        Me.cboEndAccountCode.DisplayMember = "Name"
        Me.cboEndAccountCode.EditingMode = true
        Me.cboEndAccountCode.EndFindValue = Nothing
        Me.cboEndAccountCode.FieldName = Nothing
        Me.cboEndAccountCode.FilterRule = Nothing
        Me.cboEndAccountCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEndAccountCode.FindEnabled = false
        Me.cboEndAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEndAccountCode.ForeColor = System.Drawing.Color.Black
        Me.cboEndAccountCode.FormattingEnabled = true
        Me.cboEndAccountCode.HideWhenNotEditingOrAdding = false
        Me.cboEndAccountCode.IntegralHeight = false
        Me.cboEndAccountCode.LinkedLabel = Nothing
        Me.cboEndAccountCode.Location = New System.Drawing.Point(184, 92)
        Me.cboEndAccountCode.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEndAccountCode.Name = "cboEndAccountCode"
        Me.cboEndAccountCode.OldValue = 0
        Me.cboEndAccountCode.OriginalDataSource = Nothing
        Me.cboEndAccountCode.OriginalList = Nothing
        Me.cboEndAccountCode.OverrideDropDownStyleList = false
        Me.cboEndAccountCode.PreviousSearchTerm = Nothing
        Me.cboEndAccountCode.PropertySelector = Nothing
        Me.cboEndAccountCode.ReadOnlyCombo = false
        Me.cboEndAccountCode.Size = New System.Drawing.Size(520, 24)
        Me.cboEndAccountCode.SuggestBoxHeight = 200
        Me.cboEndAccountCode.SuggestListOrderRule = Nothing
        Me.cboEndAccountCode.TabIndex = 3
        Me.cboEndAccountCode.TextToSearch = Nothing
        Me.cboEndAccountCode.ValueIsMandatory = false
        Me.cboEndAccountCode.ValueIsNullable = false
        Me.cboEndAccountCode.ValueIsNumeric = false
        Me.cboEndAccountCode.ValueMember = "Code"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.lblTitle.DisplayOnly = true
        Me.lblTitle.EditingMode = false
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(740, 25)
        Me.lblTitle.TabIndex = 26
        Me.lblTitle.Text = "Account Activity Report"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(25, 37)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(150, 25)
        Me.CLabel1.TabIndex = 26
        Me.CLabel1.Text = "Beginning Date :"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.DisplayOnly = true
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
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DisplayOnly = true
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
        Me.btnTranslate.DesignerSelected = false
        Me.btnTranslate.DisplayOnly = true
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

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