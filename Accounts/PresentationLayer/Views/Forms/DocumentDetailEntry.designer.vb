Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DocumentDetailEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentDetailEntry))
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDocumentIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblBranchName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cBranchName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblContactName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboContactIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblDocumentNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDocumentNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIssueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpIssueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUserIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPicture = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.imgPicture = New AATM.Libraries.CBaseControlsLibrary.CPictureBox()
            Me.btnPictureViewer = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDataImageNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtContactType = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblLeaveIdNo
            '
            Me.lblLeaveIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblLeaveIdNo.DisplayOnly = True
            Me.lblLeaveIdNo.EditingMode = False
            resources.ApplyResources(Me.lblLeaveIdNo, "lblLeaveIdNo")
            Me.lblLeaveIdNo.Name = "lblLeaveIdNo"
            Me.lblLeaveIdNo.Translatable = True
            '
            'cboDocumentIdNo
            '
            Me.cboDocumentIdNo.BackColor = System.Drawing.Color.White
            Me.cboDocumentIdNo.BegFindValue = Nothing
            Me.cboDocumentIdNo.ChangingSearchValueOnly = False
            Me.cboDocumentIdNo.CurrentSearchTerm = ""
            Me.cboDocumentIdNo.DataValue = Nothing
            Me.cboDocumentIdNo.DefaultValue = Nothing
            Me.cboDocumentIdNo.DisplayMember = "Name"
            Me.cboDocumentIdNo.Editable = True
            Me.cboDocumentIdNo.EditingMode = True
            Me.cboDocumentIdNo.EndFindValue = Nothing
            Me.cboDocumentIdNo.FieldDescription = Nothing
            Me.cboDocumentIdNo.FieldName = Nothing
            Me.cboDocumentIdNo.FilterRule = Nothing
            Me.cboDocumentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDocumentIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboDocumentIdNo, True)
            resources.ApplyResources(Me.cboDocumentIdNo, "cboDocumentIdNo")
            Me.cboDocumentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDocumentIdNo.FormattingEnabled = True
            Me.cboDocumentIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDocumentIdNo.IgnoreCase = False
            Me.cboDocumentIdNo.LimitToList = False
            Me.cboDocumentIdNo.LinkedLabel = Me.lblLeaveIdNo
            Me.cboDocumentIdNo.Name = "cboDocumentIdNo"
            Me.cboDocumentIdNo.OldValue = 0
            Me.cboDocumentIdNo.OriginalDataSource = Nothing
            Me.cboDocumentIdNo.OriginalList = Nothing
            Me.cboDocumentIdNo.OverrideDropDownStyleList = False
            Me.cboDocumentIdNo.PreviousSearchTerm = Nothing
            Me.cboDocumentIdNo.PropertySelector = Nothing
            Me.cboDocumentIdNo.SuggestBoxHeight = 200
            Me.cboDocumentIdNo.SuggestCharCount = 0
            Me.cboDocumentIdNo.SuggestListOrderRule = Nothing
            Me.cboDocumentIdNo.TextToSearch = Nothing
            Me.cboDocumentIdNo.Translatable = False
            Me.cboDocumentIdNo.ValueIsMandatory = False
            Me.cboDocumentIdNo.ValueIsNullable = False
            Me.cboDocumentIdNo.ValueIsNumeric = False
            Me.cboDocumentIdNo.ValueMember = "IdNo"
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout2.Controls.Add(Me.CLabel1)
            Me.CFlowLayout2.Controls.Add(Me.CButton1)
            Me.CFlowLayout2.Controls.Add(Me.lblBranchName)
            Me.CFlowLayout2.Controls.Add(Me.cBranchName)
            Me.CFlowLayout2.Controls.Add(Me.lblLeaveIdNo)
            Me.CFlowLayout2.Controls.Add(Me.cboDocumentIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblContactName)
            Me.CFlowLayout2.Controls.Add(Me.cboContactIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblDocumentNumber)
            Me.CFlowLayout2.Controls.Add(Me.txtDocumentNumber)
            Me.CFlowLayout2.Controls.Add(Me.lblIssueDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpIssueDate)
            Me.CFlowLayout2.Controls.Add(Me.lblExpiryDate)
            Me.CFlowLayout2.Controls.Add(Me.dtpExpiryDate)
            Me.CFlowLayout2.Controls.Add(Me.lblEnteredBy)
            Me.CFlowLayout2.Controls.Add(Me.txtUserIdNo)
            Me.CFlowLayout2.Controls.Add(Me.txtUserName)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.lblActive)
            Me.CFlowLayout2.Controls.Add(Me.chkActive)
            Me.CFlowLayout2.Controls.Add(Me.lblPicture)
            Me.CFlowLayout2.Controls.Add(Me.imgPicture)
            Me.CFlowLayout2.Controls.Add(Me.btnPictureViewer)
            Me.CFlowLayout2.Controls.Add(Me.txtDataImageNo)
            Me.CFlowLayout2.Controls.Add(Me.txtContactType)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CFlowLayout2.SetFlowBreak(Me.CButton1, True)
            resources.ApplyResources(Me.CButton1, "CButton1")
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            '
            'lblBranchName
            '
            Me.lblBranchName.BackColor = System.Drawing.Color.Transparent
            Me.lblBranchName.DisplayOnly = True
            Me.lblBranchName.EditingMode = False
            resources.ApplyResources(Me.lblBranchName, "lblBranchName")
            Me.lblBranchName.Name = "lblBranchName"
            Me.lblBranchName.Translatable = True
            '
            'cBranchName
            '
            Me.cBranchName.BackColor = System.Drawing.Color.White
            Me.cBranchName.BegFindValue = Nothing
            Me.cBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.cBranchName.ComputedValue = False
            Me.cBranchName.CustomFormat = Nothing
            Me.cBranchName.DataBoundControl = True
            Me.cBranchName.DisplayOnly = True
            Me.cBranchName.EditingMode = True
            Me.cBranchName.EndFindValue = Nothing
            Me.cBranchName.FieldDescription = Nothing
            Me.cBranchName.FieldName = Nothing
            Me.cBranchName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cBranchName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cBranchName, True)
            resources.ApplyResources(Me.cBranchName, "cBranchName")
            Me.cBranchName.ForeColor = System.Drawing.Color.Black
            Me.cBranchName.LinkedLabel = Nothing
            Me.cBranchName.MaximumValue = Nothing
            Me.cBranchName.MinimumValue = Nothing
            Me.cBranchName.Name = "cBranchName"
            Me.cBranchName.OldValue = Nothing
            Me.cBranchName.OverrideMaxLength = 0
            Me.cBranchName.ReadOnly = True
            Me.cBranchName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.cBranchName.Translatable = False
            '
            'lblContactName
            '
            Me.lblContactName.BackColor = System.Drawing.Color.Transparent
            Me.lblContactName.DisplayOnly = True
            Me.lblContactName.EditingMode = False
            resources.ApplyResources(Me.lblContactName, "lblContactName")
            Me.lblContactName.Name = "lblContactName"
            Me.lblContactName.Translatable = True
            '
            'cboContactIdNo
            '
            Me.cboContactIdNo.BackColor = System.Drawing.Color.White
            Me.cboContactIdNo.BegFindValue = Nothing
            Me.cboContactIdNo.ChangingSearchValueOnly = False
            Me.cboContactIdNo.CurrentSearchTerm = ""
            Me.cboContactIdNo.DataValue = Nothing
            Me.cboContactIdNo.DefaultValue = Nothing
            Me.cboContactIdNo.DisplayMember = "Name"
            Me.cboContactIdNo.Editable = True
            Me.cboContactIdNo.EditingMode = True
            Me.cboContactIdNo.EndFindValue = Nothing
            Me.cboContactIdNo.FieldDescription = Nothing
            Me.cboContactIdNo.FieldName = Nothing
            Me.cboContactIdNo.FilterRule = Nothing
            Me.cboContactIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboContactIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboContactIdNo, True)
            resources.ApplyResources(Me.cboContactIdNo, "cboContactIdNo")
            Me.cboContactIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboContactIdNo.FormattingEnabled = True
            Me.cboContactIdNo.HideWhenNotEditingOrAdding = False
            Me.cboContactIdNo.IgnoreCase = False
            Me.cboContactIdNo.LimitToList = False
            Me.cboContactIdNo.LinkedLabel = Me.lblContactName
            Me.cboContactIdNo.Name = "cboContactIdNo"
            Me.cboContactIdNo.OldValue = 0
            Me.cboContactIdNo.OriginalDataSource = Nothing
            Me.cboContactIdNo.OriginalList = Nothing
            Me.cboContactIdNo.OverrideDropDownStyleList = False
            Me.cboContactIdNo.PreviousSearchTerm = Nothing
            Me.cboContactIdNo.PropertySelector = Nothing
            Me.cboContactIdNo.SuggestBoxHeight = 200
            Me.cboContactIdNo.SuggestCharCount = 0
            Me.cboContactIdNo.SuggestListOrderRule = Nothing
            Me.cboContactIdNo.TextToSearch = Nothing
            Me.cboContactIdNo.Translatable = False
            Me.cboContactIdNo.ValueIsMandatory = False
            Me.cboContactIdNo.ValueIsNullable = False
            Me.cboContactIdNo.ValueIsNumeric = False
            Me.cboContactIdNo.ValueMember = "IdNo"
            '
            'lblDocumentNumber
            '
            Me.lblDocumentNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblDocumentNumber.DisplayOnly = True
            Me.lblDocumentNumber.EditingMode = False
            resources.ApplyResources(Me.lblDocumentNumber, "lblDocumentNumber")
            Me.lblDocumentNumber.Name = "lblDocumentNumber"
            Me.lblDocumentNumber.Translatable = True
            '
            'txtDocumentNumber
            '
            Me.txtDocumentNumber.BackColor = System.Drawing.Color.White
            Me.txtDocumentNumber.BegFindValue = Nothing
            Me.txtDocumentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDocumentNumber.ComputedValue = False
            Me.txtDocumentNumber.CustomFormat = Nothing
            Me.txtDocumentNumber.DataBoundControl = True
            Me.txtDocumentNumber.EditingMode = True
            Me.txtDocumentNumber.EndFindValue = Nothing
            Me.txtDocumentNumber.FieldDescription = Nothing
            Me.txtDocumentNumber.FieldName = Nothing
            Me.txtDocumentNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDocumentNumber.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDocumentNumber, True)
            resources.ApplyResources(Me.txtDocumentNumber, "txtDocumentNumber")
            Me.txtDocumentNumber.ForeColor = System.Drawing.Color.Black
            Me.txtDocumentNumber.LinkedLabel = Nothing
            Me.txtDocumentNumber.MaximumValue = Nothing
            Me.txtDocumentNumber.MinimumValue = Nothing
            Me.txtDocumentNumber.Name = "txtDocumentNumber"
            Me.txtDocumentNumber.OldValue = Nothing
            Me.txtDocumentNumber.OverrideMaxLength = 0
            Me.txtDocumentNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDocumentNumber.Translatable = False
            '
            'lblIssueDate
            '
            Me.lblIssueDate.BackColor = System.Drawing.Color.Transparent
            Me.lblIssueDate.DisplayOnly = True
            Me.lblIssueDate.EditingMode = False
            resources.ApplyResources(Me.lblIssueDate, "lblIssueDate")
            Me.lblIssueDate.Name = "lblIssueDate"
            Me.lblIssueDate.Translatable = True
            '
            'dtpIssueDate
            '
            resources.ApplyResources(Me.dtpIssueDate, "dtpIssueDate")
            Me.dtpIssueDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpIssueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpIssueDate.DefaultValue = Nothing
            Me.dtpIssueDate.DisplayOnly = False
            Me.dtpIssueDate.DtpDefaultValue = Nothing
            Me.dtpIssueDate.EditingMode = True
            Me.dtpIssueDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpIssueDate, True)
            Me.dtpIssueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpIssueDate.LinkedLabel = Me.lblIssueDate
            Me.dtpIssueDate.Name = "dtpIssueDate"
            Me.dtpIssueDate.ReadOnlyDp = False
            Me.dtpIssueDate.SecurityKey = Nothing
            Me.dtpIssueDate.ShowLongDate = False
            Me.dtpIssueDate.ShowTime = False
            Me.dtpIssueDate.TargetCalendar = Nothing
            Me.dtpIssueDate.Translatable = False
            Me.dtpIssueDate.Value = Nothing
            Me.dtpIssueDate.ValueIsMandatory = False
            Me.dtpIssueDate.ValueIsNullable = False
            '
            'lblExpiryDate
            '
            Me.lblExpiryDate.BackColor = System.Drawing.Color.Transparent
            Me.lblExpiryDate.DisplayOnly = True
            Me.lblExpiryDate.EditingMode = False
            resources.ApplyResources(Me.lblExpiryDate, "lblExpiryDate")
            Me.lblExpiryDate.Name = "lblExpiryDate"
            Me.lblExpiryDate.Translatable = True
            '
            'dtpExpiryDate
            '
            resources.ApplyResources(Me.dtpExpiryDate, "dtpExpiryDate")
            Me.dtpExpiryDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpExpiryDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpExpiryDate.DefaultValue = Nothing
            Me.dtpExpiryDate.DisplayOnly = False
            Me.dtpExpiryDate.DtpDefaultValue = Nothing
            Me.dtpExpiryDate.EditingMode = True
            Me.dtpExpiryDate.EditsAllowed = False
            Me.CFlowLayout2.SetFlowBreak(Me.dtpExpiryDate, True)
            Me.dtpExpiryDate.ForeColor = System.Drawing.Color.Black
            Me.dtpExpiryDate.LinkedLabel = Me.lblExpiryDate
            Me.dtpExpiryDate.Name = "dtpExpiryDate"
            Me.dtpExpiryDate.ReadOnlyDp = False
            Me.dtpExpiryDate.SecurityKey = Nothing
            Me.dtpExpiryDate.ShowLongDate = False
            Me.dtpExpiryDate.ShowTime = False
            Me.dtpExpiryDate.TargetCalendar = Nothing
            Me.dtpExpiryDate.Translatable = False
            Me.dtpExpiryDate.Value = Nothing
            Me.dtpExpiryDate.ValueIsMandatory = False
            Me.dtpExpiryDate.ValueIsNullable = False
            '
            'lblEnteredBy
            '
            Me.lblEnteredBy.BackColor = System.Drawing.Color.Transparent
            Me.lblEnteredBy.DisplayOnly = True
            Me.lblEnteredBy.EditingMode = False
            resources.ApplyResources(Me.lblEnteredBy, "lblEnteredBy")
            Me.lblEnteredBy.Name = "lblEnteredBy"
            Me.lblEnteredBy.Translatable = True
            '
            'txtUserIdNo
            '
            Me.txtUserIdNo.BackColor = System.Drawing.Color.White
            Me.txtUserIdNo.BegFindValue = Nothing
            Me.txtUserIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUserIdNo.ComputedValue = False
            Me.txtUserIdNo.CustomFormat = Nothing
            Me.txtUserIdNo.DataBoundControl = True
            Me.txtUserIdNo.DisplayOnly = True
            Me.txtUserIdNo.EditingMode = True
            Me.txtUserIdNo.EndFindValue = Nothing
            Me.txtUserIdNo.FieldDescription = Nothing
            Me.txtUserIdNo.FieldName = Nothing
            Me.txtUserIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUserIdNo.FindEnabled = False
            resources.ApplyResources(Me.txtUserIdNo, "txtUserIdNo")
            Me.txtUserIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtUserIdNo.LinkedLabel = Nothing
            Me.txtUserIdNo.MaximumValue = Nothing
            Me.txtUserIdNo.MinimumValue = Nothing
            Me.txtUserIdNo.Name = "txtUserIdNo"
            Me.txtUserIdNo.OldValue = Nothing
            Me.txtUserIdNo.OverrideMaxLength = 0
            Me.txtUserIdNo.ReadOnly = True
            Me.txtUserIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUserIdNo.Translatable = False
            '
            'txtUserName
            '
            Me.txtUserName.BackColor = System.Drawing.Color.White
            Me.txtUserName.BegFindValue = Nothing
            Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUserName.ComputedValue = False
            Me.txtUserName.CustomFormat = Nothing
            Me.txtUserName.DataBoundControl = True
            Me.txtUserName.DisplayOnly = True
            Me.txtUserName.EditingMode = True
            Me.txtUserName.EndFindValue = Nothing
            Me.txtUserName.FieldDescription = Nothing
            Me.txtUserName.FieldName = Nothing
            Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUserName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtUserName, True)
            resources.ApplyResources(Me.txtUserName, "txtUserName")
            Me.txtUserName.ForeColor = System.Drawing.Color.Black
            Me.txtUserName.LinkedLabel = Nothing
            Me.txtUserName.MaximumValue = Nothing
            Me.txtUserName.MinimumValue = Nothing
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.OldValue = Nothing
            Me.txtUserName.OverrideMaxLength = 0
            Me.txtUserName.ReadOnly = True
            Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUserName.Translatable = False
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
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'lblActive
            '
            Me.lblActive.BackColor = System.Drawing.Color.Transparent
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            resources.ApplyResources(Me.lblActive, "lblActive")
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Translatable = True
            '
            'chkActive
            '
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            Me.chkActive.FlatAppearance.BorderSize = 0
            Me.CFlowLayout2.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.LinkedLabel = Nothing
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = True
            Me.chkActive.OldValue = Nothing
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'lblPicture
            '
            Me.lblPicture.BackColor = System.Drawing.Color.Transparent
            Me.lblPicture.DisplayOnly = True
            Me.lblPicture.EditingMode = False
            resources.ApplyResources(Me.lblPicture, "lblPicture")
            Me.lblPicture.Name = "lblPicture"
            Me.lblPicture.Translatable = True
            '
            'imgPicture
            '
            Me.imgPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.imgPicture.DisplayOnly = False
            Me.imgPicture.EditingMode = False
            resources.ApplyResources(Me.imgPicture, "imgPicture")
            Me.imgPicture.MaxImageSize = 5000000
            Me.imgPicture.Name = "imgPicture"
            Me.imgPicture.TabStop = False
            Me.imgPicture.Translatable = False
            '
            'btnPictureViewer
            '
            Me.btnPictureViewer.DesignerSelected = False
            Me.btnPictureViewer.ImageIndex = 0
            resources.ApplyResources(Me.btnPictureViewer, "btnPictureViewer")
            Me.btnPictureViewer.Name = "btnPictureViewer"
            Me.btnPictureViewer.OriginalImageName = Nothing
            Me.btnPictureViewer.SecurityKey = ""
            '
            'txtDataImageNo
            '
            Me.txtDataImageNo.BackColor = System.Drawing.Color.White
            Me.txtDataImageNo.BegFindValue = Nothing
            Me.txtDataImageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDataImageNo.ComputedValue = False
            Me.txtDataImageNo.CustomFormat = Nothing
            Me.txtDataImageNo.DataBoundControl = True
            Me.txtDataImageNo.DisplayOnly = True
            Me.txtDataImageNo.EditingMode = True
            Me.txtDataImageNo.EndFindValue = Nothing
            Me.txtDataImageNo.FieldDescription = Nothing
            Me.txtDataImageNo.FieldName = Nothing
            Me.txtDataImageNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDataImageNo.FindEnabled = False
            resources.ApplyResources(Me.txtDataImageNo, "txtDataImageNo")
            Me.txtDataImageNo.ForeColor = System.Drawing.Color.Black
            Me.txtDataImageNo.LinkedLabel = Nothing
            Me.txtDataImageNo.MaximumValue = Nothing
            Me.txtDataImageNo.MinimumValue = Nothing
            Me.txtDataImageNo.Name = "txtDataImageNo"
            Me.txtDataImageNo.OldValue = Nothing
            Me.txtDataImageNo.OverrideMaxLength = 0
            Me.txtDataImageNo.ReadOnly = True
            Me.txtDataImageNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDataImageNo.Translatable = False
            Me.txtDataImageNo.ValueIsMandatory = True
            '
            'txtContactType
            '
            Me.txtContactType.BackColor = System.Drawing.Color.White
            Me.txtContactType.BegFindValue = Nothing
            Me.txtContactType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtContactType.ComputedValue = False
            Me.txtContactType.CustomFormat = Nothing
            Me.txtContactType.DataBoundControl = True
            Me.txtContactType.EditingMode = True
            Me.txtContactType.EndFindValue = Nothing
            Me.txtContactType.FieldDescription = Nothing
            Me.txtContactType.FieldName = Nothing
            Me.txtContactType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtContactType.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtContactType, True)
            resources.ApplyResources(Me.txtContactType, "txtContactType")
            Me.txtContactType.ForeColor = System.Drawing.Color.Black
            Me.txtContactType.LinkedLabel = Nothing
            Me.txtContactType.MaximumValue = Nothing
            Me.txtContactType.MinimumValue = Nothing
            Me.txtContactType.Name = "txtContactType"
            Me.txtContactType.OldValue = Nothing
            Me.txtContactType.OverrideMaxLength = 0
            Me.txtContactType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtContactType.Translatable = False
            '
            'DocumentDetailEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Name = "DocumentDetailEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblLeaveIdNo As CLabel
        Public WithEvents cboDocumentIdNo As AtmComboBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblIssueDate As CLabel
        Public WithEvents dtpIssueDate As CCustomDateTimePicker
        Friend WithEvents lblExpiryDate As CLabel
        Friend WithEvents lblEnteredBy As CLabel
        Friend WithEvents lblDocumentNumber As CLabel
        Friend WithEvents txtDocumentNumber As CTextBox
        Friend WithEvents lblContactName As CLabel
        Public WithEvents cboContactIdNo As AtmComboBox
        Friend WithEvents lblPicture As CLabel
        Public WithEvents dtpExpiryDate As CCustomDateTimePicker
        Friend WithEvents txtUserIdNo As CTextBox
        Friend WithEvents txtUserName As CTextBox
        Public WithEvents txtDataImageNo As CTextBox
        Friend WithEvents imgPicture As CPictureBox
        Friend WithEvents lblActive As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents CButton1 As CButton
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtContactType As CTextBox
        Friend WithEvents btnPictureViewer As CButton
        Friend WithEvents lblBranchName As CLabel
        Friend WithEvents cBranchName As CTextBox
    End Class
End Namespace