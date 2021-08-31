Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TransactionSummary
        Inherits AATM.PresentationLayer.Forms.BfMainNew

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
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnTranslate = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
            Me.lblEndDateCaption.Translatable = True
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
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(327, 89)
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
            Me.dtpBeginningDate.TabIndex = 0
            Me.dtpBeginningDate.TargetCalendar = Nothing
            Me.dtpBeginningDate.Translatable = False
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
            Me.lblTitle.Size = New System.Drawing.Size(352, 25)
            Me.lblTitle.TabIndex = 26
            Me.lblTitle.Text = "Transaction Summary Report"
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
            Me.btnOk.DisplayOnly = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(126, 132)
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
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(235, 132)
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
            Me.btnTranslate.DisplayOnly = True
            Me.btnTranslate.ImageIndex = 0
            Me.btnTranslate.Location = New System.Drawing.Point(16, 132)
            Me.btnTranslate.Name = "btnTranslate"
            Me.btnTranslate.OriginalImageName = Nothing
            Me.btnTranslate.SecurityKey = ""
            Me.btnTranslate.Size = New System.Drawing.Size(89, 25)
            Me.btnTranslate.TabIndex = 29
            Me.btnTranslate.Text = "Translate"
            '
            'TransactionSummary
            '
            Me.ClientSize = New System.Drawing.Size(352, 176)
            Me.Controls.Add(Me.btnTranslate)
            Me.Controls.Add(Me.lblTitle)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "TransactionSummary"
            Me.Text = "Account Activity Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
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