Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RecurringPayElementEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringPayElementEntry))
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblPayElementName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayElementIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblTotalAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
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
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblEmployeeIdNo
            '
            Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblEmployeeIdNo.DisplayOnly = True
            Me.lblEmployeeIdNo.EditingMode = False
            resources.ApplyResources(Me.lblEmployeeIdNo, "lblEmployeeIdNo")
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
            Me.lblEmployeeIdNo.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, True)
            resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.ReadOnlyCombo = False
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            resources.ApplyResources(Me.lblAmount, "lblAmount")
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = True
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtAmount, True)
            resources.ApplyResources(Me.txtAmount, "txtAmount")
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            resources.ApplyResources(Me.lblStartDate, "lblStartDate")
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Translatable = True
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.TargetCalendar = Nothing
            Me.dtpStartDate.Translatable = False
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblPeriodicPayment
            '
            Me.lblPeriodicPayment.BackColor = System.Drawing.Color.Transparent
            Me.lblPeriodicPayment.DisplayOnly = True
            Me.lblPeriodicPayment.EditingMode = False
            resources.ApplyResources(Me.lblPeriodicPayment, "lblPeriodicPayment")
            Me.lblPeriodicPayment.Name = "lblPeriodicPayment"
            Me.lblPeriodicPayment.Translatable = True
            '
            'txtPeriodicPayment
            '
            Me.txtPeriodicPayment.BackColor = System.Drawing.Color.White
            Me.txtPeriodicPayment.BegFindValue = Nothing
            Me.txtPeriodicPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPeriodicPayment.ComputedValue = False
            Me.txtPeriodicPayment.CustomFormat = Nothing
            Me.txtPeriodicPayment.DataBoundControl = True
            Me.txtPeriodicPayment.EditingMode = True
            Me.txtPeriodicPayment.EndFindValue = Nothing
            Me.txtPeriodicPayment.FieldDescription = Nothing
            Me.txtPeriodicPayment.FieldName = Nothing
            Me.txtPeriodicPayment.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPeriodicPayment.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtPeriodicPayment, True)
            resources.ApplyResources(Me.txtPeriodicPayment, "txtPeriodicPayment")
            Me.txtPeriodicPayment.ForeColor = System.Drawing.Color.Black
            Me.txtPeriodicPayment.LinkedLabel = Me.lblPeriodicPayment
            Me.txtPeriodicPayment.MaximumValue = Nothing
            Me.txtPeriodicPayment.MinimumValue = Nothing
            Me.txtPeriodicPayment.Name = "txtPeriodicPayment"
            Me.txtPeriodicPayment.OldValue = Nothing
            Me.txtPeriodicPayment.ReadOnly = True
            Me.txtPeriodicPayment.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPeriodicPayment.Translatable = False
            Me.txtPeriodicPayment.ValueIsMandatory = True
            Me.txtPeriodicPayment.ValueIsNumeric = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblEmployeeIdNo)
            Me.CFlowLayout2.Controls.Add(Me.cboEmployeeIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblPayElementName)
            Me.CFlowLayout2.Controls.Add(Me.cboPayElementIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblAmount)
            Me.CFlowLayout2.Controls.Add(Me.txtAmount)
            Me.CFlowLayout2.Controls.Add(Me.lblPeriodicPayment)
            Me.CFlowLayout2.Controls.Add(Me.txtPeriodicPayment)
            Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpStartDate)
            Me.CFlowLayout2.Controls.Add(Me.lblTotalAmount)
            Me.CFlowLayout2.Controls.Add(Me.txtTotalAmount)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'lblPayElementName
            '
            Me.lblPayElementName.BackColor = System.Drawing.Color.Transparent
            Me.lblPayElementName.DisplayOnly = True
            Me.lblPayElementName.EditingMode = False
            resources.ApplyResources(Me.lblPayElementName, "lblPayElementName")
            Me.lblPayElementName.Name = "lblPayElementName"
            Me.lblPayElementName.Translatable = True
            '
            'cboPayElementIdNo
            '
            Me.cboPayElementIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayElementIdNo.BegFindValue = Nothing
            Me.cboPayElementIdNo.ChangingSearchValueOnly = False
            Me.cboPayElementIdNo.CurrentSearchTerm = ""
            Me.cboPayElementIdNo.DefaultValue = Nothing
            Me.cboPayElementIdNo.DisplayMember = "Name"
            Me.cboPayElementIdNo.EditingMode = True
            Me.cboPayElementIdNo.EndFindValue = Nothing
            Me.cboPayElementIdNo.FieldDescription = Nothing
            Me.cboPayElementIdNo.FieldName = Nothing
            Me.cboPayElementIdNo.FilterRule = Nothing
            Me.cboPayElementIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayElementIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboPayElementIdNo, True)
            resources.ApplyResources(Me.cboPayElementIdNo, "cboPayElementIdNo")
            Me.cboPayElementIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayElementIdNo.FormattingEnabled = True
            Me.cboPayElementIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayElementIdNo.IgnoreCase = False
            Me.cboPayElementIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboPayElementIdNo.Name = "cboPayElementIdNo"
            Me.cboPayElementIdNo.OldValue = 0
            Me.cboPayElementIdNo.OriginalDataSource = Nothing
            Me.cboPayElementIdNo.OriginalList = Nothing
            Me.cboPayElementIdNo.OverrideDropDownStyleList = False
            Me.cboPayElementIdNo.PreviousSearchTerm = Nothing
            Me.cboPayElementIdNo.PropertySelector = Nothing
            Me.cboPayElementIdNo.ReadOnlyCombo = False
            Me.cboPayElementIdNo.SuggestBoxHeight = 200
            Me.cboPayElementIdNo.SuggestListOrderRule = Nothing
            Me.cboPayElementIdNo.TextToSearch = Nothing
            Me.cboPayElementIdNo.Translatable = False
            Me.cboPayElementIdNo.ValueIsMandatory = False
            Me.cboPayElementIdNo.ValueIsNullable = False
            Me.cboPayElementIdNo.ValueIsNumeric = False
            Me.cboPayElementIdNo.ValueMember = "IdNo"
            '
            'lblTotalAmount
            '
            Me.lblTotalAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalAmount.DisplayOnly = True
            Me.lblTotalAmount.EditingMode = False
            resources.ApplyResources(Me.lblTotalAmount, "lblTotalAmount")
            Me.lblTotalAmount.Name = "lblTotalAmount"
            Me.lblTotalAmount.Translatable = True
            '
            'txtTotalAmount
            '
            Me.txtTotalAmount.BackColor = System.Drawing.Color.White
            Me.txtTotalAmount.BegFindValue = Nothing
            Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalAmount.ComputedValue = False
            Me.txtTotalAmount.CustomFormat = Nothing
            Me.txtTotalAmount.DataBoundControl = True
            Me.txtTotalAmount.DisplayOnly = True
            Me.txtTotalAmount.EditingMode = True
            Me.txtTotalAmount.EndFindValue = Nothing
            Me.txtTotalAmount.FieldDescription = Nothing
            Me.txtTotalAmount.FieldName = Nothing
            Me.txtTotalAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalAmount.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtTotalAmount, True)
            resources.ApplyResources(Me.txtTotalAmount, "txtTotalAmount")
            Me.txtTotalAmount.ForeColor = System.Drawing.Color.Black
            Me.txtTotalAmount.LinkedLabel = Me.lblTotalAmount
            Me.txtTotalAmount.MaximumValue = Nothing
            Me.txtTotalAmount.MinimumValue = Nothing
            Me.txtTotalAmount.Name = "txtTotalAmount"
            Me.txtTotalAmount.OldValue = Nothing
            Me.txtTotalAmount.ReadOnly = True
            Me.txtTotalAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalAmount.Translatable = False
            Me.txtTotalAmount.ValueIsMandatory = True
            Me.txtTotalAmount.ValueIsNumeric = True
            '
            'RecurringPayElementEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Name = "RecurringPayElementEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CaComboBox
        Friend WithEvents lblAmount As CLabel
        Public WithEvents txtAmount As CTextBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents lblPeriodicPayment As CLabel
        Public WithEvents txtPeriodicPayment As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblPayElementName As CLabel
        Public WithEvents cboPayElementIdNo As CaComboBox
        Friend WithEvents lblTotalAmount As CLabel
        Public WithEvents txtTotalAmount As CTextBox
    End Class
End Namespace