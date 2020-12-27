Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TrialBalance
        Inherits AATM.PresentationLayer.Forms.BfMain

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrialBalance))
        Me.lblEndDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblBegDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnTranslate = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblEndDateCaption
            '
            Me.lblEndDateCaption.DisplayOnly = True
            Me.lblEndDateCaption.EditingMode = False
            Me.lblEndDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.dtpEndingDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpEndingDate.TabIndex = 24
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(309, 79)
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
            Me.lblBegDateCaption.Text = "Beginning Date:"
            Me.lblBegDateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpBeginningDate
            '
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
            Me.dtpBeginningDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpBeginningDate.TabIndex = 26
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
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
            Me.lblTitle.Size = New System.Drawing.Size(339, 25)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Trial Balance"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.DisplayOnly = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(122, 131)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(231, 131)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnTranslate
            '
            Me.btnTranslate.DesignerSelected = True
            Me.btnTranslate.DisplayOnly = True
            Me.btnTranslate.ImageIndex = 0
            Me.btnTranslate.Location = New System.Drawing.Point(12, 131)
            Me.btnTranslate.Name = "btnTranslate"
            Me.btnTranslate.OriginalImageName = Nothing
            Me.btnTranslate.SecurityKey = ""
            Me.btnTranslate.Size = New System.Drawing.Size(89, 25)
            Me.btnTranslate.TabIndex = 30
            Me.btnTranslate.Text = "Translate"
            '
            'TrialBalance
            '
            Me.ClientSize = New System.Drawing.Size(337, 171)
            Me.Controls.Add(Me.btnTranslate)
            Me.Controls.Add(Me.lblTitle)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
        Me.Name = "TrialBalance"
            Me.Text = "Trial Balance"
            CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents lblEndDateCaption As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpEndingDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblTitle As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents dtpBeginningDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblBegDateCaption As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnTranslate As Libraries.CBaseControlsLibrary.CButton
    End Class
End NameSpace