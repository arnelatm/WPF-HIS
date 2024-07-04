Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ShiftSummaryEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShiftSummaryEntry))
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateStart = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateEnd = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblCash = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCash = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCards = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCard = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTotal = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotal = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout2.SuspendLayout
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, true)
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblUserIdNo
        '
        Me.lblUserIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblUserIdNo.DisplayOnly = true
        Me.lblUserIdNo.EditingMode = false
        resources.ApplyResources(Me.lblUserIdNo, "lblUserIdNo")
        Me.lblUserIdNo.Name = "lblUserIdNo"
        Me.lblUserIdNo.Translatable = true
        '
        'cboUserIdNo
        '
        Me.cboUserIdNo.BackColor = System.Drawing.Color.White
        Me.cboUserIdNo.BegFindValue = Nothing
        Me.cboUserIdNo.ChangingSearchValueOnly = false
        Me.cboUserIdNo.CurrentSearchTerm = ""
        Me.cboUserIdNo.DefaultValue = Nothing
        Me.cboUserIdNo.DisplayMember = "Name"
        Me.cboUserIdNo.EditingMode = true
        Me.cboUserIdNo.EndFindValue = Nothing
        Me.cboUserIdNo.FieldDescription = Nothing
        Me.cboUserIdNo.FieldName = Nothing
        Me.cboUserIdNo.FilterRule = Nothing
        Me.cboUserIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboUserIdNo.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboUserIdNo, true)
        resources.ApplyResources(Me.cboUserIdNo, "cboUserIdNo")
        Me.cboUserIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboUserIdNo.FormattingEnabled = true
        Me.cboUserIdNo.HideWhenNotEditingOrAdding = false
        Me.cboUserIdNo.IgnoreCase = false
        Me.cboUserIdNo.LinkedLabel = Me.lblUserIdNo
        Me.cboUserIdNo.Name = "cboUserIdNo"
        Me.cboUserIdNo.OldValue = 0
        Me.cboUserIdNo.OriginalDataSource = Nothing
        Me.cboUserIdNo.OriginalList = Nothing
        Me.cboUserIdNo.OverrideDropDownStyleList = false
        Me.cboUserIdNo.PreviousSearchTerm = Nothing
        Me.cboUserIdNo.PropertySelector = Nothing
            Me.cboUserIdNo.SuggestBoxHeight = 200
            Me.cboUserIdNo.SuggestListOrderRule = Nothing
        Me.cboUserIdNo.TextToSearch = Nothing
        Me.cboUserIdNo.Translatable = false
        Me.cboUserIdNo.ValueIsMandatory = false
        Me.cboUserIdNo.ValueIsNullable = false
        Me.cboUserIdNo.ValueIsNumeric = false
        Me.cboUserIdNo.ValueMember = "IdNo"
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Translatable = true
        '
        'dtpDateStart
        '
        Me.dtpDateStart.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateStart.DefaultValue = Nothing
        Me.dtpDateStart.DisplayOnly = false
        Me.dtpDateStart.DtpDefaultValue = Nothing
        Me.dtpDateStart.EditingMode = true
        Me.dtpDateStart.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpDateStart, true)
        Me.dtpDateStart.ForeColor = System.Drawing.Color.Black
        Me.dtpDateStart.LinkedLabel = Me.lblStartDate
        resources.ApplyResources(Me.dtpDateStart, "dtpDateStart")
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ReadOnlyDp = false
        Me.dtpDateStart.SecurityKey = Nothing
        Me.dtpDateStart.ShowLongDate = false
        Me.dtpDateStart.ShowTime = true
        Me.dtpDateStart.TargetCalendar = Nothing
        Me.dtpDateStart.Translatable = false
        Me.dtpDateStart.Value = Nothing
        Me.dtpDateStart.ValueIsMandatory = false
        Me.dtpDateStart.ValueIsNullable = false
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.DisplayOnly = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, true)
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblUserIdNo)
        Me.CFlowLayout2.Controls.Add(Me.cboUserIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateStart)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateEnd)
        Me.CFlowLayout2.Controls.Add(Me.lblCash)
        Me.CFlowLayout2.Controls.Add(Me.txtCash)
        Me.CFlowLayout2.Controls.Add(Me.lblCards)
        Me.CFlowLayout2.Controls.Add(Me.txtCard)
        Me.CFlowLayout2.Controls.Add(Me.lblTotal)
        Me.CFlowLayout2.Controls.Add(Me.txtTotal)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Translatable = true
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateEnd.DefaultValue = Nothing
        Me.dtpDateEnd.DisplayOnly = false
        Me.dtpDateEnd.DtpDefaultValue = Nothing
        Me.dtpDateEnd.EditingMode = true
        Me.dtpDateEnd.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpDateEnd, true)
        Me.dtpDateEnd.ForeColor = System.Drawing.Color.Black
        Me.dtpDateEnd.LinkedLabel = Me.lblEndDate
        resources.ApplyResources(Me.dtpDateEnd, "dtpDateEnd")
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.ReadOnlyDp = false
        Me.dtpDateEnd.SecurityKey = Nothing
        Me.dtpDateEnd.ShowLongDate = false
        Me.dtpDateEnd.ShowTime = true
        Me.dtpDateEnd.TargetCalendar = Nothing
        Me.dtpDateEnd.Translatable = false
        Me.dtpDateEnd.Value = Nothing
        Me.dtpDateEnd.ValueIsMandatory = false
        Me.dtpDateEnd.ValueIsNullable = false
        '
        'lblCash
        '
        Me.lblCash.BackColor = System.Drawing.Color.Transparent
        Me.lblCash.DisplayOnly = true
        Me.lblCash.EditingMode = false
        resources.ApplyResources(Me.lblCash, "lblCash")
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Translatable = true
        '
        'txtCash
        '
        Me.txtCash.BackColor = System.Drawing.Color.White
        Me.txtCash.BegFindValue = Nothing
        Me.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCash.ComputedValue = false
        Me.txtCash.CustomFormat = Nothing
        Me.txtCash.DataBoundControl = true
        Me.txtCash.EditingMode = true
        Me.txtCash.EndFindValue = Nothing
        Me.txtCash.FieldDescription = Nothing
        Me.txtCash.FieldName = Nothing
        Me.txtCash.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCash.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtCash, true)
        resources.ApplyResources(Me.txtCash, "txtCash")
        Me.txtCash.ForeColor = System.Drawing.Color.Black
        Me.txtCash.LinkedLabel = Me.lblIdNo
        Me.txtCash.MaximumValue = Nothing
        Me.txtCash.MinimumValue = Nothing
        Me.txtCash.Name = "txtCash"
        Me.txtCash.OldValue = Nothing
        Me.txtCash.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCash.TabStop = false
        Me.txtCash.Translatable = false
        Me.txtCash.ValueIsNumeric = true
        '
        'lblCards
        '
        Me.lblCards.BackColor = System.Drawing.Color.Transparent
        Me.lblCards.DisplayOnly = true
        Me.lblCards.EditingMode = false
        resources.ApplyResources(Me.lblCards, "lblCards")
        Me.lblCards.Name = "lblCards"
        Me.lblCards.Translatable = true
        '
        'txtCard
        '
        Me.txtCard.BackColor = System.Drawing.Color.White
        Me.txtCard.BegFindValue = Nothing
        Me.txtCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCard.ComputedValue = false
        Me.txtCard.CustomFormat = Nothing
        Me.txtCard.DataBoundControl = true
        Me.txtCard.EditingMode = true
        Me.txtCard.EndFindValue = Nothing
        Me.txtCard.FieldDescription = Nothing
        Me.txtCard.FieldName = Nothing
        Me.txtCard.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCard.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtCard, true)
        resources.ApplyResources(Me.txtCard, "txtCard")
        Me.txtCard.ForeColor = System.Drawing.Color.Black
        Me.txtCard.LinkedLabel = Me.lblIdNo
        Me.txtCard.MaximumValue = Nothing
        Me.txtCard.MinimumValue = Nothing
        Me.txtCard.Name = "txtCard"
        Me.txtCard.OldValue = Nothing
        Me.txtCard.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCard.TabStop = false
        Me.txtCard.Translatable = false
        Me.txtCard.ValueIsNumeric = true
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.DisplayOnly = true
        Me.lblTotal.EditingMode = false
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Translatable = true
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BegFindValue = Nothing
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.ComputedValue = false
        Me.txtTotal.CustomFormat = Nothing
        Me.txtTotal.DataBoundControl = true
        Me.txtTotal.DisplayOnly = true
        Me.txtTotal.EditingMode = true
        Me.txtTotal.EndFindValue = Nothing
        Me.txtTotal.FieldDescription = Nothing
        Me.txtTotal.FieldName = Nothing
        Me.txtTotal.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotal.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtTotal, true)
        resources.ApplyResources(Me.txtTotal, "txtTotal")
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.LinkedLabel = Me.lblIdNo
        Me.txtTotal.MaximumValue = Nothing
        Me.txtTotal.MinimumValue = Nothing
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OldValue = Nothing
        Me.txtTotal.ReadOnly = true
        Me.txtTotal.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotal.TabStop = false
        Me.txtTotal.Translatable = false
        Me.txtTotal.ValueIsNumeric = true
        '
        'ShiftSummaryEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "ShiftSummaryEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblUserIdNo As CLabel
        Public WithEvents cboUserIdNo As CtCombobox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpDateStart As CCustomDateTimePicker
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents dtpDateEnd As CCustomDateTimePicker
        Friend WithEvents lblCash As CLabel
        Public WithEvents txtCash As CTextBox
        Friend WithEvents lblCards As CLabel
        Public WithEvents txtCard As CTextBox
        Friend WithEvents lblTotal As CLabel
        Public WithEvents txtTotal As CTextBox
    End Class
End Namespace