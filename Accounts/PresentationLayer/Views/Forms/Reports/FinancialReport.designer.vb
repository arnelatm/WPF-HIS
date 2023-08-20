Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FinancialReport
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
            Me.lblEndDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblBegDateCaption = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIncludeZeroBalances = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIncludeZeroBalances = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnTranslate = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblTitle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblEndDateCaption
            '
            Me.lblEndDateCaption.DisplayOnly = True
            Me.lblEndDateCaption.EditingMode = False
            Me.lblEndDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDateCaption.Location = New System.Drawing.Point(155, 1)
            Me.lblEndDateCaption.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDateCaption.Name = "lblEndDateCaption"
            Me.lblEndDateCaption.Size = New System.Drawing.Size(139, 25)
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
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(155, 35)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpEndingDate.TabIndex = 24
            Me.dtpEndingDate.TargetCalendar = Nothing
            Me.dtpEndingDate.Translatable = False
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout1.Controls.Add(Me.lblIncludeZeroBalances)
            Me.CFlowLayout1.Controls.Add(Me.chkIncludeZeroBalances)
            Me.CFlowLayout1.Controls.Add(Me.btnTranslate)
            Me.CFlowLayout1.Controls.Add(Me.btnCancel)
            Me.CFlowLayout1.Controls.Add(Me.btnOk)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(327, 145)
            Me.CFlowLayout1.TabIndex = 26
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.dtpBeginningDate, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndingDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndDateCaption, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBegDateCaption, 0, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 13)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(301, 69)
            Me.TableLayoutPanel1.TabIndex = 30
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
            Me.dtpBeginningDate.Location = New System.Drawing.Point(1, 35)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpBeginningDate.TabIndex = 26
            Me.dtpBeginningDate.TargetCalendar = Nothing
            Me.dtpBeginningDate.Translatable = False
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'lblBegDateCaption
            '
            Me.lblBegDateCaption.DisplayOnly = True
            Me.lblBegDateCaption.EditingMode = False
            Me.lblBegDateCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBegDateCaption.Location = New System.Drawing.Point(1, 1)
            Me.lblBegDateCaption.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBegDateCaption.Name = "lblBegDateCaption"
            Me.lblBegDateCaption.Size = New System.Drawing.Size(152, 25)
            Me.lblBegDateCaption.TabIndex = 25
            Me.lblBegDateCaption.Text = "Beginning Date:"
            Me.lblBegDateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBegDateCaption.Translatable = True
            '
            'lblIncludeZeroBalances
            '
            Me.lblIncludeZeroBalances.DisplayOnly = True
            Me.lblIncludeZeroBalances.EditingMode = False
            Me.lblIncludeZeroBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIncludeZeroBalances.Location = New System.Drawing.Point(11, 86)
            Me.lblIncludeZeroBalances.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIncludeZeroBalances.Name = "lblIncludeZeroBalances"
            Me.lblIncludeZeroBalances.Size = New System.Drawing.Size(171, 25)
            Me.lblIncludeZeroBalances.TabIndex = 32
            Me.lblIncludeZeroBalances.Text = "Include Zero Balances?"
            Me.lblIncludeZeroBalances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIncludeZeroBalances.Translatable = True
            '
            'chkIncludeZeroBalances
            '
            Me.chkIncludeZeroBalances.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkIncludeZeroBalances.BackColor = System.Drawing.Color.White
            Me.chkIncludeZeroBalances.BegFindValue = Nothing
            Me.chkIncludeZeroBalances.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkIncludeZeroBalances.Checked = True
            Me.chkIncludeZeroBalances.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkIncludeZeroBalances.DisplayOnly = False
            Me.chkIncludeZeroBalances.EditingMode = True
            Me.chkIncludeZeroBalances.EndFindValue = Nothing
            Me.chkIncludeZeroBalances.FieldDescription = Nothing
            Me.chkIncludeZeroBalances.FieldName = Nothing
            Me.chkIncludeZeroBalances.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkIncludeZeroBalances.FindEnabled = False
            Me.chkIncludeZeroBalances.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkIncludeZeroBalances, True)
            Me.chkIncludeZeroBalances.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkIncludeZeroBalances.ForeColor = System.Drawing.Color.Black
            Me.chkIncludeZeroBalances.IFindableControl_FindEnabled = False
            Me.chkIncludeZeroBalances.IgnoreCase = False
            Me.chkIncludeZeroBalances.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkIncludeZeroBalances.LinkedLabel = Me.lblIncludeZeroBalances
            Me.chkIncludeZeroBalances.Location = New System.Drawing.Point(184, 86)
            Me.chkIncludeZeroBalances.Margin = New System.Windows.Forms.Padding(1)
            Me.chkIncludeZeroBalances.Name = "chkIncludeZeroBalances"
            Me.chkIncludeZeroBalances.NoLabel = True
            Me.chkIncludeZeroBalances.OldValue = Nothing
            Me.chkIncludeZeroBalances.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkIncludeZeroBalances.Size = New System.Drawing.Size(25, 21)
            Me.chkIncludeZeroBalances.TabIndex = 33
            Me.chkIncludeZeroBalances.Text = " "
            Me.chkIncludeZeroBalances.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkIncludeZeroBalances.Translatable = False
            Me.chkIncludeZeroBalances.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(108, 115)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(204, 115)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnTranslate
            '
            Me.btnTranslate.DesignerSelected = False
            Me.btnTranslate.ImageIndex = 0
            Me.btnTranslate.Location = New System.Drawing.Point(13, 115)
            Me.btnTranslate.Name = "btnTranslate"
            Me.btnTranslate.OriginalImageName = Nothing
            Me.btnTranslate.SecurityKey = ""
            Me.btnTranslate.Size = New System.Drawing.Size(89, 25)
            Me.btnTranslate.TabIndex = 29
            Me.btnTranslate.Text = "Translate"
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
            Me.lblTitle.Text = "Balance Sheet"
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
            'FinancialReport
            '
            Me.ClientSize = New System.Drawing.Size(339, 190)
            Me.Controls.Add(Me.lblTitle)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "FinancialReport"
            Me.Text = "Balance Sheet"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
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
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblIncludeZeroBalances As CLabel
        Friend WithEvents chkIncludeZeroBalances As CCheckBox
    End Class
End NameSpace