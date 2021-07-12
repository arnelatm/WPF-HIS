Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CustomerEntryTv
        Inherits CFormEntryTvNew

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerEntryTv))
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSettlementDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblArAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRevAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIban = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCrNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCrNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtWebsite = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblWebsite = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmail = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmail = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMobile = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblMobile = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtFax = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblFax = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPhone2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPhone2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPhone1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPhone1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCountryCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtZipCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblZipCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPoBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPoBox = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProvinceState = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProvinceState = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTownCity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTownCity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDistrict = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDistrict = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtStreet = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblStreet = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtContactDesignation = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblContactDesignation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtContactPerson = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblContactPerson = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCustomerNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtCustomerName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCustomerName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCustomerNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCustomerCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCustomerCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cacRevAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cacArAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cacPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacDiscountSchemeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.dtpDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.cacAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.FormTreeView, "FormTreeView")
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'lblAccountStatus
            '
            Me.lblAccountStatus.DisplayOnly = True
            Me.lblAccountStatus.EditingMode = False
            resources.ApplyResources(Me.lblAccountStatus, "lblAccountStatus")
            Me.lblAccountStatus.Name = "lblAccountStatus"
            Me.lblAccountStatus.Translatable = True
            '
            'lblDateAccountOpen
            '
            Me.lblDateAccountOpen.DisplayOnly = True
            Me.lblDateAccountOpen.EditingMode = False
            resources.ApplyResources(Me.lblDateAccountOpen, "lblDateAccountOpen")
            Me.lblDateAccountOpen.Name = "lblDateAccountOpen"
            Me.lblDateAccountOpen.Translatable = True
            '
            'txtOpeningBalance
            '
            Me.txtOpeningBalance.BackColor = System.Drawing.Color.White
            Me.txtOpeningBalance.BegFindValue = Nothing
            Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOpeningBalance.ComputedValue = False
            Me.txtOpeningBalance.CustomFormat = Nothing
            Me.txtOpeningBalance.DataBoundControl = True
            Me.txtOpeningBalance.EditingMode = False
            Me.txtOpeningBalance.EndFindValue = Nothing
            Me.txtOpeningBalance.FieldDescription = Nothing
            Me.txtOpeningBalance.FieldName = Nothing
            Me.txtOpeningBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtOpeningBalance.FindEnabled = True
            resources.ApplyResources(Me.txtOpeningBalance, "txtOpeningBalance")
            Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
            Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtOpeningBalance.MaximumValue = Nothing
            Me.txtOpeningBalance.MinimumValue = Nothing
            Me.txtOpeningBalance.Name = "txtOpeningBalance"
            Me.txtOpeningBalance.OldValue = Nothing
            Me.txtOpeningBalance.ReadOnly = True
            Me.txtOpeningBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtOpeningBalance.Translatable = False
            Me.txtOpeningBalance.ValueIsNumeric = True
            '
            'lblOpeningBalance
            '
            Me.lblOpeningBalance.DisplayOnly = True
            Me.lblOpeningBalance.EditingMode = False
            resources.ApplyResources(Me.lblOpeningBalance, "lblOpeningBalance")
            Me.lblOpeningBalance.Name = "lblOpeningBalance"
            Me.lblOpeningBalance.Translatable = True
            '
            'txtSettlementDiscount
            '
            Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
            Me.txtSettlementDiscount.BegFindValue = Nothing
            Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSettlementDiscount.ComputedValue = False
            Me.txtSettlementDiscount.CustomFormat = Nothing
            Me.txtSettlementDiscount.DataBoundControl = True
            Me.txtSettlementDiscount.EditingMode = False
            Me.txtSettlementDiscount.EndFindValue = Nothing
            Me.txtSettlementDiscount.FieldDescription = Nothing
            Me.txtSettlementDiscount.FieldName = Nothing
            Me.txtSettlementDiscount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSettlementDiscount.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSettlementDiscount, True)
            resources.ApplyResources(Me.txtSettlementDiscount, "txtSettlementDiscount")
            Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDiscount.IgnoreNullCheck = True
            Me.txtSettlementDiscount.LinkedLabel = Nothing
            Me.txtSettlementDiscount.MaximumValue = Nothing
            Me.txtSettlementDiscount.MinimumValue = Nothing
            Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
            Me.txtSettlementDiscount.OldValue = Nothing
            Me.txtSettlementDiscount.ReadOnly = True
            Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSettlementDiscount.Translatable = False
            '
            'lblSettlementDiscount
            '
            Me.lblSettlementDiscount.DisplayOnly = True
            Me.lblSettlementDiscount.EditingMode = False
            resources.ApplyResources(Me.lblSettlementDiscount, "lblSettlementDiscount")
            Me.lblSettlementDiscount.Name = "lblSettlementDiscount"
            Me.lblSettlementDiscount.Translatable = True
            '
            'txtSettlementDueDays
            '
            Me.txtSettlementDueDays.BackColor = System.Drawing.Color.White
            Me.txtSettlementDueDays.BegFindValue = Nothing
            Me.txtSettlementDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSettlementDueDays.ComputedValue = False
            Me.txtSettlementDueDays.CustomFormat = Nothing
            Me.txtSettlementDueDays.DataBoundControl = True
            Me.txtSettlementDueDays.EditingMode = False
            Me.txtSettlementDueDays.EndFindValue = Nothing
            Me.txtSettlementDueDays.FieldDescription = Nothing
            Me.txtSettlementDueDays.FieldName = Nothing
            Me.txtSettlementDueDays.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSettlementDueDays.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSettlementDueDays, True)
            resources.ApplyResources(Me.txtSettlementDueDays, "txtSettlementDueDays")
            Me.txtSettlementDueDays.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDueDays.IgnoreNullCheck = True
            Me.txtSettlementDueDays.LinkedLabel = Me.CLabel2
            Me.txtSettlementDueDays.MaximumValue = Nothing
            Me.txtSettlementDueDays.MinimumValue = Nothing
            Me.txtSettlementDueDays.Name = "txtSettlementDueDays"
            Me.txtSettlementDueDays.OldValue = Nothing
            Me.txtSettlementDueDays.ReadOnly = True
            Me.txtSettlementDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSettlementDueDays.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Translatable = True
            '
            'lblPaymentMethod
            '
            Me.lblPaymentMethod.DisplayOnly = True
            Me.lblPaymentMethod.EditingMode = False
            resources.ApplyResources(Me.lblPaymentMethod, "lblPaymentMethod")
            Me.lblPaymentMethod.Name = "lblPaymentMethod"
            Me.lblPaymentMethod.Translatable = True
            '
            'txtPaymentDueDays
            '
            Me.txtPaymentDueDays.BackColor = System.Drawing.Color.White
            Me.txtPaymentDueDays.BegFindValue = Nothing
            Me.txtPaymentDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPaymentDueDays.ComputedValue = False
            Me.txtPaymentDueDays.CustomFormat = Nothing
            Me.txtPaymentDueDays.DataBoundControl = True
            Me.txtPaymentDueDays.EditingMode = False
            Me.txtPaymentDueDays.EndFindValue = Nothing
            Me.txtPaymentDueDays.FieldDescription = Nothing
            Me.txtPaymentDueDays.FieldName = Nothing
            Me.txtPaymentDueDays.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPaymentDueDays.FindEnabled = True
            resources.ApplyResources(Me.txtPaymentDueDays, "txtPaymentDueDays")
            Me.txtPaymentDueDays.ForeColor = System.Drawing.Color.Black
            Me.txtPaymentDueDays.IgnoreNullCheck = True
            Me.txtPaymentDueDays.LinkedLabel = Me.lblPaymentDueDays
            Me.txtPaymentDueDays.MaximumValue = Nothing
            Me.txtPaymentDueDays.MinimumValue = Nothing
            Me.txtPaymentDueDays.Name = "txtPaymentDueDays"
            Me.txtPaymentDueDays.OldValue = Nothing
            Me.txtPaymentDueDays.ReadOnly = True
            Me.txtPaymentDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPaymentDueDays.Translatable = False
            '
            'lblPaymentDueDays
            '
            Me.lblPaymentDueDays.DisplayOnly = True
            Me.lblPaymentDueDays.EditingMode = False
            resources.ApplyResources(Me.lblPaymentDueDays, "lblPaymentDueDays")
            Me.lblPaymentDueDays.Name = "lblPaymentDueDays"
            Me.lblPaymentDueDays.Translatable = True
            '
            'txtCreditLimit
            '
            Me.txtCreditLimit.BackColor = System.Drawing.Color.White
            Me.txtCreditLimit.BegFindValue = Nothing
            Me.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCreditLimit.ComputedValue = False
            Me.txtCreditLimit.CustomFormat = Nothing
            Me.txtCreditLimit.DataBoundControl = True
            Me.txtCreditLimit.EditingMode = False
            Me.txtCreditLimit.EndFindValue = Nothing
            Me.txtCreditLimit.FieldDescription = Nothing
            Me.txtCreditLimit.FieldName = Nothing
            Me.txtCreditLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCreditLimit.FindEnabled = True
            resources.ApplyResources(Me.txtCreditLimit, "txtCreditLimit")
            Me.txtCreditLimit.ForeColor = System.Drawing.Color.Black
            Me.txtCreditLimit.LinkedLabel = Me.lblCreditLimit
            Me.txtCreditLimit.MaximumValue = Nothing
            Me.txtCreditLimit.MinimumValue = Nothing
            Me.txtCreditLimit.Name = "txtCreditLimit"
            Me.txtCreditLimit.OldValue = Nothing
            Me.txtCreditLimit.ReadOnly = True
            Me.txtCreditLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCreditLimit.Translatable = False
            Me.txtCreditLimit.ValueIsNumeric = True
            '
            'lblCreditLimit
            '
            Me.lblCreditLimit.DisplayOnly = True
            Me.lblCreditLimit.EditingMode = False
            resources.ApplyResources(Me.lblCreditLimit, "lblCreditLimit")
            Me.lblCreditLimit.Name = "lblCreditLimit"
            Me.lblCreditLimit.Translatable = True
            '
            'lblArAccountIdNo
            '
            Me.lblArAccountIdNo.DisplayOnly = True
            Me.lblArAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblArAccountIdNo, "lblArAccountIdNo")
            Me.lblArAccountIdNo.Name = "lblArAccountIdNo"
            Me.lblArAccountIdNo.Translatable = True
            '
            'lblRevAccountIdNo
            '
            Me.lblRevAccountIdNo.DisplayOnly = True
            Me.lblRevAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblRevAccountIdNo, "lblRevAccountIdNo")
            Me.lblRevAccountIdNo.Name = "lblRevAccountIdNo"
            Me.lblRevAccountIdNo.Translatable = True
            '
            'txtIban
            '
            Me.txtIban.BackColor = System.Drawing.Color.White
            Me.txtIban.BegFindValue = Nothing
            Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIban.ComputedValue = False
            Me.txtIban.CustomFormat = Nothing
            Me.txtIban.DataBoundControl = True
            Me.txtIban.EditingMode = False
            Me.txtIban.EndFindValue = Nothing
            Me.txtIban.FieldDescription = Nothing
            Me.txtIban.FieldName = Nothing
            Me.txtIban.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIban.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtIban, True)
            resources.ApplyResources(Me.txtIban, "txtIban")
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblIban
            Me.txtIban.MaximumValue = Nothing
            Me.txtIban.MinimumValue = Nothing
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.ReadOnly = True
            Me.txtIban.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIban.Translatable = False
            '
            'lblIban
            '
            Me.lblIban.DisplayOnly = True
            Me.lblIban.EditingMode = False
            resources.ApplyResources(Me.lblIban, "lblIban")
            Me.lblIban.Name = "lblIban"
            Me.lblIban.Translatable = True
            '
            'txtBankAccountNo
            '
            Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
            Me.txtBankAccountNo.BegFindValue = Nothing
            Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankAccountNo.ComputedValue = False
            Me.txtBankAccountNo.CustomFormat = Nothing
            Me.txtBankAccountNo.DataBoundControl = True
            Me.txtBankAccountNo.EditingMode = False
            Me.txtBankAccountNo.EndFindValue = Nothing
            Me.txtBankAccountNo.FieldDescription = Nothing
            Me.txtBankAccountNo.FieldName = Nothing
            Me.txtBankAccountNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBankAccountNo.FindEnabled = True
            resources.ApplyResources(Me.txtBankAccountNo, "txtBankAccountNo")
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
            Me.txtBankAccountNo.MaximumValue = Nothing
            Me.txtBankAccountNo.MinimumValue = Nothing
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.ReadOnly = True
            Me.txtBankAccountNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankAccountNo.Translatable = False
            '
            'lblBankAccountNo
            '
            Me.lblBankAccountNo.DisplayOnly = True
            Me.lblBankAccountNo.EditingMode = False
            resources.ApplyResources(Me.lblBankAccountNo, "lblBankAccountNo")
            Me.lblBankAccountNo.Name = "lblBankAccountNo"
            Me.lblBankAccountNo.Translatable = True
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            resources.ApplyResources(Me.lblBankIdNo, "lblBankIdNo")
            Me.lblBankIdNo.Name = "lblBankIdNo"
            Me.lblBankIdNo.Translatable = True
            '
            'txtCrNumber
            '
            Me.txtCrNumber.BackColor = System.Drawing.Color.White
            Me.txtCrNumber.BegFindValue = Nothing
            Me.txtCrNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCrNumber.ComputedValue = False
            Me.txtCrNumber.CustomFormat = Nothing
            Me.txtCrNumber.DataBoundControl = True
            Me.txtCrNumber.EditingMode = False
            Me.txtCrNumber.EndFindValue = Nothing
            Me.txtCrNumber.FieldDescription = Nothing
            Me.txtCrNumber.FieldName = Nothing
            Me.txtCrNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCrNumber.FindEnabled = True
            resources.ApplyResources(Me.txtCrNumber, "txtCrNumber")
            Me.txtCrNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCrNumber.LinkedLabel = Me.lblCrNumber
            Me.txtCrNumber.MaximumValue = Nothing
            Me.txtCrNumber.MinimumValue = Nothing
            Me.txtCrNumber.Name = "txtCrNumber"
            Me.txtCrNumber.OldValue = Nothing
            Me.txtCrNumber.ReadOnly = True
            Me.txtCrNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCrNumber.Translatable = False
            '
            'lblCrNumber
            '
            Me.lblCrNumber.DisplayOnly = True
            Me.lblCrNumber.EditingMode = False
            resources.ApplyResources(Me.lblCrNumber, "lblCrNumber")
            Me.lblCrNumber.Name = "lblCrNumber"
            Me.lblCrNumber.Translatable = True
            '
            'txtWebsite
            '
            Me.txtWebsite.BackColor = System.Drawing.Color.White
            Me.txtWebsite.BegFindValue = Nothing
            Me.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWebsite.ComputedValue = False
            Me.txtWebsite.CustomFormat = Nothing
            Me.txtWebsite.DataBoundControl = True
            Me.txtWebsite.EditingMode = False
            Me.txtWebsite.EndFindValue = Nothing
            Me.txtWebsite.FieldDescription = Nothing
            Me.txtWebsite.FieldName = Nothing
            Me.txtWebsite.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtWebsite.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtWebsite, True)
            resources.ApplyResources(Me.txtWebsite, "txtWebsite")
            Me.txtWebsite.ForeColor = System.Drawing.Color.Black
            Me.txtWebsite.LinkedLabel = Me.lblWebsite
            Me.txtWebsite.MaximumValue = Nothing
            Me.txtWebsite.MinimumValue = Nothing
            Me.txtWebsite.Name = "txtWebsite"
            Me.txtWebsite.OldValue = Nothing
            Me.txtWebsite.ReadOnly = True
            Me.txtWebsite.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtWebsite.Translatable = False
            '
            'lblWebsite
            '
            Me.lblWebsite.DisplayOnly = True
            Me.lblWebsite.EditingMode = False
            resources.ApplyResources(Me.lblWebsite, "lblWebsite")
            Me.lblWebsite.Name = "lblWebsite"
            Me.lblWebsite.Translatable = True
            '
            'txtEmail
            '
            Me.txtEmail.BackColor = System.Drawing.Color.White
            Me.txtEmail.BegFindValue = Nothing
            Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmail.ComputedValue = False
            Me.txtEmail.CustomFormat = Nothing
            Me.txtEmail.DataBoundControl = True
            Me.txtEmail.EditingMode = False
            Me.txtEmail.EndFindValue = Nothing
            Me.txtEmail.FieldDescription = Nothing
            Me.txtEmail.FieldName = Nothing
            Me.txtEmail.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmail.FindEnabled = True
            resources.ApplyResources(Me.txtEmail, "txtEmail")
            Me.txtEmail.ForeColor = System.Drawing.Color.Black
            Me.txtEmail.LinkedLabel = Me.lblEmail
            Me.txtEmail.MaximumValue = Nothing
            Me.txtEmail.MinimumValue = Nothing
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.OldValue = Nothing
            Me.txtEmail.ReadOnly = True
            Me.txtEmail.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmail.Translatable = False
            '
            'lblEmail
            '
            Me.lblEmail.DisplayOnly = True
            Me.lblEmail.EditingMode = False
            resources.ApplyResources(Me.lblEmail, "lblEmail")
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Translatable = True
            '
            'txtMobile
            '
            Me.txtMobile.BackColor = System.Drawing.Color.White
            Me.txtMobile.BegFindValue = Nothing
            Me.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMobile.ComputedValue = False
            Me.txtMobile.CustomFormat = Nothing
            Me.txtMobile.DataBoundControl = True
            Me.txtMobile.EditingMode = False
            Me.txtMobile.EndFindValue = Nothing
            Me.txtMobile.FieldDescription = Nothing
            Me.txtMobile.FieldName = Nothing
            Me.txtMobile.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMobile.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtMobile, True)
            resources.ApplyResources(Me.txtMobile, "txtMobile")
            Me.txtMobile.ForeColor = System.Drawing.Color.Black
            Me.txtMobile.LinkedLabel = Me.lblMobile
            Me.txtMobile.MaximumValue = Nothing
            Me.txtMobile.MinimumValue = Nothing
            Me.txtMobile.Name = "txtMobile"
            Me.txtMobile.OldValue = Nothing
            Me.txtMobile.ReadOnly = True
            Me.txtMobile.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMobile.Translatable = False
            '
            'lblMobile
            '
            Me.lblMobile.DisplayOnly = True
            Me.lblMobile.EditingMode = False
            resources.ApplyResources(Me.lblMobile, "lblMobile")
            Me.lblMobile.Name = "lblMobile"
            Me.lblMobile.Translatable = True
            '
            'txtFax
            '
            Me.txtFax.BackColor = System.Drawing.Color.White
            Me.txtFax.BegFindValue = Nothing
            Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFax.ComputedValue = False
            Me.txtFax.CustomFormat = Nothing
            Me.txtFax.DataBoundControl = True
            Me.txtFax.EditingMode = False
            Me.txtFax.EndFindValue = Nothing
            Me.txtFax.FieldDescription = Nothing
            Me.txtFax.FieldName = Nothing
            Me.txtFax.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFax.FindEnabled = True
            resources.ApplyResources(Me.txtFax, "txtFax")
            Me.txtFax.ForeColor = System.Drawing.Color.Black
            Me.txtFax.LinkedLabel = Me.lblFax
            Me.txtFax.MaximumValue = Nothing
            Me.txtFax.MinimumValue = Nothing
            Me.txtFax.Name = "txtFax"
            Me.txtFax.OldValue = Nothing
            Me.txtFax.ReadOnly = True
            Me.txtFax.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFax.Translatable = False
            '
            'lblFax
            '
            Me.lblFax.DisplayOnly = True
            Me.lblFax.EditingMode = False
            resources.ApplyResources(Me.lblFax, "lblFax")
            Me.lblFax.Name = "lblFax"
            Me.lblFax.Translatable = True
            '
            'txtPhone2
            '
            Me.txtPhone2.BackColor = System.Drawing.Color.White
            Me.txtPhone2.BegFindValue = Nothing
            Me.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone2.ComputedValue = False
            Me.txtPhone2.CustomFormat = Nothing
            Me.txtPhone2.DataBoundControl = True
            Me.txtPhone2.EditingMode = False
            Me.txtPhone2.EndFindValue = Nothing
            Me.txtPhone2.FieldDescription = Nothing
            Me.txtPhone2.FieldName = Nothing
            Me.txtPhone2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhone2.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPhone2, True)
            resources.ApplyResources(Me.txtPhone2, "txtPhone2")
            Me.txtPhone2.ForeColor = System.Drawing.Color.Black
            Me.txtPhone2.LinkedLabel = Me.lblPhone2
            Me.txtPhone2.MaximumValue = Nothing
            Me.txtPhone2.MinimumValue = Nothing
            Me.txtPhone2.Name = "txtPhone2"
            Me.txtPhone2.OldValue = Nothing
            Me.txtPhone2.ReadOnly = True
            Me.txtPhone2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhone2.Translatable = False
            '
            'lblPhone2
            '
            Me.lblPhone2.DisplayOnly = True
            Me.lblPhone2.EditingMode = False
            resources.ApplyResources(Me.lblPhone2, "lblPhone2")
            Me.lblPhone2.Name = "lblPhone2"
            Me.lblPhone2.Translatable = True
            '
            'txtPhone1
            '
            Me.txtPhone1.BackColor = System.Drawing.Color.White
            Me.txtPhone1.BegFindValue = Nothing
            Me.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone1.ComputedValue = False
            Me.txtPhone1.CustomFormat = Nothing
            Me.txtPhone1.DataBoundControl = True
            Me.txtPhone1.EditingMode = False
            Me.txtPhone1.EndFindValue = Nothing
            Me.txtPhone1.FieldDescription = Nothing
            Me.txtPhone1.FieldName = Nothing
            Me.txtPhone1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPhone1.FindEnabled = True
            resources.ApplyResources(Me.txtPhone1, "txtPhone1")
            Me.txtPhone1.ForeColor = System.Drawing.Color.Black
            Me.txtPhone1.LinkedLabel = Me.lblPhone1
            Me.txtPhone1.MaximumValue = Nothing
            Me.txtPhone1.MinimumValue = Nothing
            Me.txtPhone1.Name = "txtPhone1"
            Me.txtPhone1.OldValue = Nothing
            Me.txtPhone1.ReadOnly = True
            Me.txtPhone1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhone1.Translatable = False
            '
            'lblPhone1
            '
            Me.lblPhone1.DisplayOnly = True
            Me.lblPhone1.EditingMode = False
            resources.ApplyResources(Me.lblPhone1, "lblPhone1")
            Me.lblPhone1.Name = "lblPhone1"
            Me.lblPhone1.Translatable = True
            '
            'lblCountryCode
            '
            Me.lblCountryCode.DisplayOnly = True
            Me.lblCountryCode.EditingMode = False
            resources.ApplyResources(Me.lblCountryCode, "lblCountryCode")
            Me.lblCountryCode.Name = "lblCountryCode"
            Me.lblCountryCode.Translatable = True
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.Color.White
            Me.txtZipCode.BegFindValue = Nothing
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.ComputedValue = False
            Me.txtZipCode.CustomFormat = Nothing
            Me.txtZipCode.DataBoundControl = True
            Me.txtZipCode.EditingMode = False
            Me.txtZipCode.EndFindValue = Nothing
            Me.txtZipCode.FieldDescription = Nothing
            Me.txtZipCode.FieldName = Nothing
            Me.txtZipCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtZipCode.FindEnabled = True
            resources.ApplyResources(Me.txtZipCode, "txtZipCode")
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Me.lblZipCode
            Me.txtZipCode.MaximumValue = Nothing
            Me.txtZipCode.MinimumValue = Nothing
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.ReadOnly = True
            Me.txtZipCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtZipCode.Translatable = False
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            resources.ApplyResources(Me.lblZipCode, "lblZipCode")
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Translatable = True
            '
            'txtPoBox
            '
            Me.txtPoBox.BackColor = System.Drawing.Color.White
            Me.txtPoBox.BegFindValue = Nothing
            Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPoBox.ComputedValue = False
            Me.txtPoBox.CustomFormat = Nothing
            Me.txtPoBox.DataBoundControl = True
            Me.txtPoBox.EditingMode = False
            Me.txtPoBox.EndFindValue = Nothing
            Me.txtPoBox.FieldDescription = Nothing
            Me.txtPoBox.FieldName = Nothing
            Me.txtPoBox.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPoBox.FindEnabled = True
            resources.ApplyResources(Me.txtPoBox, "txtPoBox")
            Me.txtPoBox.ForeColor = System.Drawing.Color.Black
            Me.txtPoBox.LinkedLabel = Me.lblPoBox
            Me.txtPoBox.MaximumValue = Nothing
            Me.txtPoBox.MinimumValue = Nothing
            Me.txtPoBox.Name = "txtPoBox"
            Me.txtPoBox.OldValue = Nothing
            Me.txtPoBox.ReadOnly = True
            Me.txtPoBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPoBox.Translatable = False
            '
            'lblPoBox
            '
            Me.lblPoBox.DisplayOnly = True
            Me.lblPoBox.EditingMode = False
            resources.ApplyResources(Me.lblPoBox, "lblPoBox")
            Me.lblPoBox.Name = "lblPoBox"
            Me.lblPoBox.Translatable = True
            '
            'txtProvinceState
            '
            Me.txtProvinceState.BackColor = System.Drawing.Color.White
            Me.txtProvinceState.BegFindValue = Nothing
            Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProvinceState.ComputedValue = False
            Me.txtProvinceState.CustomFormat = Nothing
            Me.txtProvinceState.DataBoundControl = True
            Me.txtProvinceState.EditingMode = False
            Me.txtProvinceState.EndFindValue = Nothing
            Me.txtProvinceState.FieldDescription = Nothing
            Me.txtProvinceState.FieldName = Nothing
            Me.txtProvinceState.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProvinceState.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtProvinceState, True)
            resources.ApplyResources(Me.txtProvinceState, "txtProvinceState")
            Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
            Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
            Me.txtProvinceState.MaximumValue = Nothing
            Me.txtProvinceState.MinimumValue = Nothing
            Me.txtProvinceState.Name = "txtProvinceState"
            Me.txtProvinceState.OldValue = Nothing
            Me.txtProvinceState.ReadOnly = True
            Me.txtProvinceState.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProvinceState.Translatable = False
            '
            'lblProvinceState
            '
            Me.lblProvinceState.DisplayOnly = True
            Me.lblProvinceState.EditingMode = False
            resources.ApplyResources(Me.lblProvinceState, "lblProvinceState")
            Me.lblProvinceState.Name = "lblProvinceState"
            Me.lblProvinceState.Translatable = True
            '
            'txtTownCity
            '
            Me.txtTownCity.BackColor = System.Drawing.Color.White
            Me.txtTownCity.BegFindValue = Nothing
            Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTownCity.ComputedValue = False
            Me.txtTownCity.CustomFormat = Nothing
            Me.txtTownCity.DataBoundControl = True
            Me.txtTownCity.EditingMode = False
            Me.txtTownCity.EndFindValue = Nothing
            Me.txtTownCity.FieldDescription = Nothing
            Me.txtTownCity.FieldName = Nothing
            Me.txtTownCity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTownCity.FindEnabled = True
            resources.ApplyResources(Me.txtTownCity, "txtTownCity")
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Me.lblTownCity
            Me.txtTownCity.MaximumValue = Nothing
            Me.txtTownCity.MinimumValue = Nothing
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.ReadOnly = True
            Me.txtTownCity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTownCity.Translatable = False
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            resources.ApplyResources(Me.lblTownCity, "lblTownCity")
            Me.lblTownCity.Name = "lblTownCity"
            Me.lblTownCity.Translatable = True
            '
            'txtDistrict
            '
            Me.txtDistrict.BackColor = System.Drawing.Color.White
            Me.txtDistrict.BegFindValue = Nothing
            Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistrict.ComputedValue = False
            Me.txtDistrict.CustomFormat = Nothing
            Me.txtDistrict.DataBoundControl = True
            Me.txtDistrict.EditingMode = False
            Me.txtDistrict.EndFindValue = Nothing
            Me.txtDistrict.FieldDescription = Nothing
            Me.txtDistrict.FieldName = Nothing
            Me.txtDistrict.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDistrict.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDistrict, True)
            resources.ApplyResources(Me.txtDistrict, "txtDistrict")
            Me.txtDistrict.ForeColor = System.Drawing.Color.Black
            Me.txtDistrict.LinkedLabel = Me.lblDistrict
            Me.txtDistrict.MaximumValue = Nothing
            Me.txtDistrict.MinimumValue = Nothing
            Me.txtDistrict.Name = "txtDistrict"
            Me.txtDistrict.OldValue = Nothing
            Me.txtDistrict.ReadOnly = True
            Me.txtDistrict.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDistrict.Translatable = False
            '
            'lblDistrict
            '
            Me.lblDistrict.DisplayOnly = True
            Me.lblDistrict.EditingMode = False
            resources.ApplyResources(Me.lblDistrict, "lblDistrict")
            Me.lblDistrict.Name = "lblDistrict"
            Me.lblDistrict.Translatable = True
            '
            'txtStreet
            '
            Me.txtStreet.BackColor = System.Drawing.Color.White
            Me.txtStreet.BegFindValue = Nothing
            Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStreet.ComputedValue = False
            Me.txtStreet.CustomFormat = Nothing
            Me.txtStreet.DataBoundControl = True
            Me.txtStreet.EditingMode = False
            Me.txtStreet.EndFindValue = Nothing
            Me.txtStreet.FieldDescription = Nothing
            Me.txtStreet.FieldName = Nothing
            Me.txtStreet.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStreet.FindEnabled = True
            resources.ApplyResources(Me.txtStreet, "txtStreet")
            Me.txtStreet.ForeColor = System.Drawing.Color.Black
            Me.txtStreet.LinkedLabel = Me.lblStreet
            Me.txtStreet.MaximumValue = Nothing
            Me.txtStreet.MinimumValue = Nothing
            Me.txtStreet.Name = "txtStreet"
            Me.txtStreet.OldValue = Nothing
            Me.txtStreet.ReadOnly = True
            Me.txtStreet.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStreet.Translatable = False
            '
            'lblStreet
            '
            Me.lblStreet.DisplayOnly = True
            Me.lblStreet.EditingMode = False
            resources.ApplyResources(Me.lblStreet, "lblStreet")
            Me.lblStreet.Name = "lblStreet"
            Me.lblStreet.Translatable = True
            '
            'txtContactDesignation
            '
            Me.txtContactDesignation.BackColor = System.Drawing.Color.White
            Me.txtContactDesignation.BegFindValue = Nothing
            Me.txtContactDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtContactDesignation.ComputedValue = False
            Me.txtContactDesignation.CustomFormat = Nothing
            Me.txtContactDesignation.DataBoundControl = True
            Me.txtContactDesignation.EditingMode = False
            Me.txtContactDesignation.EndFindValue = Nothing
            Me.txtContactDesignation.FieldDescription = Nothing
            Me.txtContactDesignation.FieldName = Nothing
            Me.txtContactDesignation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtContactDesignation.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtContactDesignation, True)
            resources.ApplyResources(Me.txtContactDesignation, "txtContactDesignation")
            Me.txtContactDesignation.ForeColor = System.Drawing.Color.Black
            Me.txtContactDesignation.LinkedLabel = Me.lblContactDesignation
            Me.txtContactDesignation.MaximumValue = Nothing
            Me.txtContactDesignation.MinimumValue = Nothing
            Me.txtContactDesignation.Name = "txtContactDesignation"
            Me.txtContactDesignation.OldValue = Nothing
            Me.txtContactDesignation.ReadOnly = True
            Me.txtContactDesignation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtContactDesignation.Translatable = False
            '
            'lblContactDesignation
            '
            Me.lblContactDesignation.DisplayOnly = True
            Me.lblContactDesignation.EditingMode = False
            resources.ApplyResources(Me.lblContactDesignation, "lblContactDesignation")
            Me.lblContactDesignation.Name = "lblContactDesignation"
            Me.lblContactDesignation.Translatable = True
            '
            'txtContactPerson
            '
            Me.txtContactPerson.BackColor = System.Drawing.Color.White
            Me.txtContactPerson.BegFindValue = Nothing
            Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtContactPerson.ComputedValue = False
            Me.txtContactPerson.CustomFormat = Nothing
            Me.txtContactPerson.DataBoundControl = True
            Me.txtContactPerson.EditingMode = False
            Me.txtContactPerson.EndFindValue = Nothing
            Me.txtContactPerson.FieldDescription = Nothing
            Me.txtContactPerson.FieldName = Nothing
            Me.txtContactPerson.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtContactPerson.FindEnabled = True
            resources.ApplyResources(Me.txtContactPerson, "txtContactPerson")
            Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
            Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
            Me.txtContactPerson.MaximumValue = Nothing
            Me.txtContactPerson.MinimumValue = Nothing
            Me.txtContactPerson.Name = "txtContactPerson"
            Me.txtContactPerson.OldValue = Nothing
            Me.txtContactPerson.ReadOnly = True
            Me.txtContactPerson.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtContactPerson.Translatable = False
            '
            'lblContactPerson
            '
            Me.lblContactPerson.DisplayOnly = True
            Me.lblContactPerson.EditingMode = False
            resources.ApplyResources(Me.lblContactPerson, "lblContactPerson")
            Me.lblContactPerson.Name = "lblContactPerson"
            Me.lblContactPerson.Translatable = True
            '
            'txtCustomerNameAra
            '
            Me.txtCustomerNameAra.BackColor = System.Drawing.Color.White
            Me.txtCustomerNameAra.BegFindValue = Nothing
            Me.txtCustomerNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCustomerNameAra.ComputedValue = False
            Me.txtCustomerNameAra.CustomFormat = Nothing
            Me.txtCustomerNameAra.DataBoundControl = True
            Me.txtCustomerNameAra.EditingMode = False
            Me.txtCustomerNameAra.EndFindValue = Nothing
            Me.txtCustomerNameAra.EnglishControl = Me.txtCustomerName
            Me.txtCustomerNameAra.FieldDescription = Nothing
            Me.txtCustomerNameAra.FieldName = Nothing
            Me.txtCustomerNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCustomerNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCustomerNameAra, True)
            resources.ApplyResources(Me.txtCustomerNameAra, "txtCustomerNameAra")
            Me.txtCustomerNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtCustomerNameAra.LinkedLabel = Me.lblCustomerNameAra
            Me.txtCustomerNameAra.MaximumValue = Nothing
            Me.txtCustomerNameAra.MinimumValue = Nothing
            Me.txtCustomerNameAra.Name = "txtCustomerNameAra"
            Me.txtCustomerNameAra.OldValue = Nothing
            Me.txtCustomerNameAra.ReadOnly = True
            Me.txtCustomerNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCustomerNameAra.Translatable = False
            Me.txtCustomerNameAra.ValueIsMandatory = True
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.Color.White
            Me.txtCustomerName.BegFindValue = Nothing
            Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCustomerName.ComputedValue = False
            Me.txtCustomerName.CustomFormat = Nothing
            Me.txtCustomerName.DataBoundControl = True
            Me.txtCustomerName.EditingMode = False
            Me.txtCustomerName.EndFindValue = Nothing
            Me.txtCustomerName.FieldDescription = Nothing
            Me.txtCustomerName.FieldName = Nothing
            Me.txtCustomerName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCustomerName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCustomerName, True)
            resources.ApplyResources(Me.txtCustomerName, "txtCustomerName")
            Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
            Me.txtCustomerName.LinkedLabel = Me.lblCustomerName
            Me.txtCustomerName.MaximumValue = Nothing
            Me.txtCustomerName.MinimumValue = Nothing
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.OldValue = Nothing
            Me.txtCustomerName.ReadOnly = True
            Me.txtCustomerName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCustomerName.Translatable = False
            Me.txtCustomerName.ValueIsMandatory = True
            '
            'lblCustomerName
            '
            Me.lblCustomerName.DisplayOnly = True
            Me.lblCustomerName.EditingMode = False
            resources.ApplyResources(Me.lblCustomerName, "lblCustomerName")
            Me.lblCustomerName.Name = "lblCustomerName"
            Me.lblCustomerName.Translatable = True
            '
            'lblCustomerNameAra
            '
            Me.lblCustomerNameAra.DisplayOnly = True
            Me.lblCustomerNameAra.EditingMode = False
            resources.ApplyResources(Me.lblCustomerNameAra, "lblCustomerNameAra")
            Me.lblCustomerNameAra.Name = "lblCustomerNameAra"
            Me.lblCustomerNameAra.Translatable = True
            '
            'lblVatNumber
            '
            Me.lblVatNumber.DisplayOnly = True
            Me.lblVatNumber.EditingMode = False
            resources.ApplyResources(Me.lblVatNumber, "lblVatNumber")
            Me.lblVatNumber.Name = "lblVatNumber"
            Me.lblVatNumber.Translatable = True
            '
            'txtCustomerCode
            '
            Me.txtCustomerCode.BackColor = System.Drawing.Color.White
            Me.txtCustomerCode.BegFindValue = Nothing
            Me.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCustomerCode.ComputedValue = False
            Me.txtCustomerCode.CustomFormat = Nothing
            Me.txtCustomerCode.DataBoundControl = True
            Me.txtCustomerCode.EditingMode = False
            Me.txtCustomerCode.EndFindValue = Nothing
            Me.txtCustomerCode.FieldDescription = Nothing
            Me.txtCustomerCode.FieldName = Nothing
            Me.txtCustomerCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCustomerCode.FindEnabled = True
            resources.ApplyResources(Me.txtCustomerCode, "txtCustomerCode")
            Me.txtCustomerCode.ForeColor = System.Drawing.Color.Black
            Me.txtCustomerCode.LinkedLabel = Me.lblCustomerCode
            Me.txtCustomerCode.MaximumValue = Nothing
            Me.txtCustomerCode.MinimumValue = Nothing
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.txtCustomerCode.OldValue = Nothing
            Me.txtCustomerCode.ReadOnly = True
            Me.txtCustomerCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCustomerCode.Translatable = False
            Me.txtCustomerCode.ValueIsMandatory = True
            '
            'lblCustomerCode
            '
            Me.lblCustomerCode.DisplayOnly = True
            Me.lblCustomerCode.EditingMode = False
            resources.ApplyResources(Me.lblCustomerCode, "lblCustomerCode")
            Me.lblCustomerCode.Name = "lblCustomerCode"
            Me.lblCustomerCode.Translatable = True
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
            Me.TxtIdNo.FindEnabled = True
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
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCustomerCode)
            Me.floDataDisplay.Controls.Add(Me.txtCustomerCode)
            Me.floDataDisplay.Controls.Add(Me.lblVatNumber)
            Me.floDataDisplay.Controls.Add(Me.txtVatNumber)
            Me.floDataDisplay.Controls.Add(Me.lblCustomerName)
            Me.floDataDisplay.Controls.Add(Me.txtCustomerName)
            Me.floDataDisplay.Controls.Add(Me.lblCustomerNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtCustomerNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblContactPerson)
            Me.floDataDisplay.Controls.Add(Me.txtContactPerson)
            Me.floDataDisplay.Controls.Add(Me.lblContactDesignation)
            Me.floDataDisplay.Controls.Add(Me.txtContactDesignation)
            Me.floDataDisplay.Controls.Add(Me.lblStreet)
            Me.floDataDisplay.Controls.Add(Me.txtStreet)
            Me.floDataDisplay.Controls.Add(Me.lblDistrict)
            Me.floDataDisplay.Controls.Add(Me.txtDistrict)
            Me.floDataDisplay.Controls.Add(Me.lblTownCity)
            Me.floDataDisplay.Controls.Add(Me.txtTownCity)
            Me.floDataDisplay.Controls.Add(Me.lblProvinceState)
            Me.floDataDisplay.Controls.Add(Me.txtProvinceState)
            Me.floDataDisplay.Controls.Add(Me.lblPoBox)
            Me.floDataDisplay.Controls.Add(Me.txtPoBox)
            Me.floDataDisplay.Controls.Add(Me.lblZipCode)
            Me.floDataDisplay.Controls.Add(Me.txtZipCode)
            Me.floDataDisplay.Controls.Add(Me.lblCountryCode)
            Me.floDataDisplay.Controls.Add(Me.cacCountryCode)
            Me.floDataDisplay.Controls.Add(Me.lblPhone1)
            Me.floDataDisplay.Controls.Add(Me.txtPhone1)
            Me.floDataDisplay.Controls.Add(Me.lblPhone2)
            Me.floDataDisplay.Controls.Add(Me.txtPhone2)
            Me.floDataDisplay.Controls.Add(Me.lblFax)
            Me.floDataDisplay.Controls.Add(Me.txtFax)
            Me.floDataDisplay.Controls.Add(Me.lblMobile)
            Me.floDataDisplay.Controls.Add(Me.txtMobile)
            Me.floDataDisplay.Controls.Add(Me.lblEmail)
            Me.floDataDisplay.Controls.Add(Me.txtEmail)
            Me.floDataDisplay.Controls.Add(Me.lblWebsite)
            Me.floDataDisplay.Controls.Add(Me.txtWebsite)
            Me.floDataDisplay.Controls.Add(Me.lblCrNumber)
            Me.floDataDisplay.Controls.Add(Me.txtCrNumber)
            Me.floDataDisplay.Controls.Add(Me.lblBankIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacBankIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblBankAccountNo)
            Me.floDataDisplay.Controls.Add(Me.txtBankAccountNo)
            Me.floDataDisplay.Controls.Add(Me.lblIban)
            Me.floDataDisplay.Controls.Add(Me.txtIban)
            Me.floDataDisplay.Controls.Add(Me.lblRevAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacRevAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblArAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacArAccountIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCreditLimit)
            Me.floDataDisplay.Controls.Add(Me.txtCreditLimit)
            Me.floDataDisplay.Controls.Add(Me.lblPaymentMethod)
            Me.floDataDisplay.Controls.Add(Me.cacPaymentMethod)
            Me.floDataDisplay.Controls.Add(Me.lblOpeningBalance)
            Me.floDataDisplay.Controls.Add(Me.txtOpeningBalance)
            Me.floDataDisplay.Controls.Add(Me.CLabel2)
            Me.floDataDisplay.Controls.Add(Me.txtSettlementDueDays)
            Me.floDataDisplay.Controls.Add(Me.lblPaymentDueDays)
            Me.floDataDisplay.Controls.Add(Me.txtPaymentDueDays)
            Me.floDataDisplay.Controls.Add(Me.lblSettlementDiscount)
            Me.floDataDisplay.Controls.Add(Me.txtSettlementDiscount)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.cacDiscountSchemeIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblDateAccountOpen)
            Me.floDataDisplay.Controls.Add(Me.dtpDateAccountOpen)
            Me.floDataDisplay.Controls.Add(Me.lblAccountStatus)
            Me.floDataDisplay.Controls.Add(Me.cacAccountStatus)
            Me.floDataDisplay.Controls.Add(Me.lblActive)
            Me.floDataDisplay.Controls.Add(Me.chkActive)
            Me.floDataDisplay.Controls.Add(Me.CLabel3)
            Me.floDataDisplay.Controls.Add(Me.txtBalance)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'txtVatNumber
            '
            Me.txtVatNumber.BackColor = System.Drawing.Color.White
            Me.txtVatNumber.BegFindValue = Nothing
            Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.EndFindValue = Nothing
            Me.txtVatNumber.FieldDescription = Nothing
            Me.txtVatNumber.FieldName = Nothing
            Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatNumber.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtVatNumber, True)
            resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Nothing
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Translatable = False
            '
            'cacCountryCode
            '
            Me.cacCountryCode.BackColor = System.Drawing.Color.White
            Me.cacCountryCode.BegFindValue = Nothing
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DefaultValue = Nothing
            Me.cacCountryCode.DisplayMember = "Name"
            Me.cacCountryCode.EditingMode = False
            Me.cacCountryCode.EndFindValue = Nothing
            Me.cacCountryCode.FieldDescription = Nothing
            Me.cacCountryCode.FieldName = Nothing
            Me.cacCountryCode.FilterRule = Nothing
            Me.cacCountryCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacCountryCode.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacCountryCode, True)
            resources.ApplyResources(Me.cacCountryCode, "cacCountryCode")
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.IgnoreCase = False
            Me.cacCountryCode.LinkedLabel = Me.lblCountryCode
            Me.cacCountryCode.Name = "cacCountryCode"
            Me.cacCountryCode.OldValue = 0
            Me.cacCountryCode.OriginalDataSource = Nothing
            Me.cacCountryCode.OriginalList = Nothing
            Me.cacCountryCode.OverrideDropDownStyleList = False
            Me.cacCountryCode.PreviousSearchTerm = Nothing
            Me.cacCountryCode.PropertySelector = Nothing
            Me.cacCountryCode.ReadOnlyCombo = False
            Me.cacCountryCode.SecurityKey = ""
            Me.cacCountryCode.SuggestBoxHeight = 200
            Me.cacCountryCode.SuggestListOrderRule = Nothing
            Me.cacCountryCode.TextToSearch = Nothing
            Me.cacCountryCode.Translatable = False
            Me.cacCountryCode.ValueIsMandatory = False
            Me.cacCountryCode.ValueIsNullable = False
            Me.cacCountryCode.ValueIsNumeric = False
            Me.cacCountryCode.ValueMember = "Code"
            '
            'cacBankIdNo
            '
            Me.cacBankIdNo.BackColor = System.Drawing.Color.White
            Me.cacBankIdNo.BegFindValue = Nothing
            Me.cacBankIdNo.ChangingSearchValueOnly = False
            Me.cacBankIdNo.CurrentSearchTerm = ""
            Me.cacBankIdNo.DefaultValue = Nothing
            Me.cacBankIdNo.DisplayMember = "Name"
            Me.cacBankIdNo.EditingMode = False
            Me.cacBankIdNo.EndFindValue = Nothing
            Me.cacBankIdNo.FieldDescription = Nothing
            Me.cacBankIdNo.FieldName = Nothing
            Me.cacBankIdNo.FilterRule = Nothing
            Me.cacBankIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacBankIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacBankIdNo, True)
            resources.ApplyResources(Me.cacBankIdNo, "cacBankIdNo")
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
            Me.cacBankIdNo.IgnoreCase = False
            Me.cacBankIdNo.LinkedLabel = Nothing
            Me.cacBankIdNo.Name = "cacBankIdNo"
            Me.cacBankIdNo.OldValue = 0
            Me.cacBankIdNo.OriginalDataSource = Nothing
            Me.cacBankIdNo.OriginalList = Nothing
            Me.cacBankIdNo.OverrideDropDownStyleList = False
            Me.cacBankIdNo.PreviousSearchTerm = Nothing
            Me.cacBankIdNo.PropertySelector = Nothing
            Me.cacBankIdNo.ReadOnlyCombo = False
            Me.cacBankIdNo.SuggestBoxHeight = 200
            Me.cacBankIdNo.SuggestListOrderRule = Nothing
            Me.cacBankIdNo.TextToSearch = Nothing
            Me.cacBankIdNo.Translatable = False
            Me.cacBankIdNo.ValueIsMandatory = False
            Me.cacBankIdNo.ValueIsNullable = False
            Me.cacBankIdNo.ValueIsNumeric = False
            Me.cacBankIdNo.ValueMember = "IdNo"
            '
            'cacRevAccountIdNo
            '
            Me.cacRevAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cacRevAccountIdNo.BegFindValue = Nothing
            Me.cacRevAccountIdNo.ChangingSearchValueOnly = False
            Me.cacRevAccountIdNo.CurrentSearchTerm = ""
            Me.cacRevAccountIdNo.DefaultValue = Nothing
            Me.cacRevAccountIdNo.DisplayMember = "Name"
            Me.cacRevAccountIdNo.EditingMode = False
            Me.cacRevAccountIdNo.EndFindValue = Nothing
            Me.cacRevAccountIdNo.FieldDescription = Nothing
            Me.cacRevAccountIdNo.FieldName = Nothing
            Me.cacRevAccountIdNo.FilterRule = Nothing
            Me.cacRevAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacRevAccountIdNo.FindEnabled = False
            resources.ApplyResources(Me.cacRevAccountIdNo, "cacRevAccountIdNo")
            Me.cacRevAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacRevAccountIdNo.FormattingEnabled = True
            Me.cacRevAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cacRevAccountIdNo.IgnoreCase = False
            Me.cacRevAccountIdNo.LinkedLabel = Nothing
            Me.cacRevAccountIdNo.Name = "cacRevAccountIdNo"
            Me.cacRevAccountIdNo.OldValue = 0
            Me.cacRevAccountIdNo.OriginalDataSource = Nothing
            Me.cacRevAccountIdNo.OriginalList = Nothing
            Me.cacRevAccountIdNo.OverrideDropDownStyleList = False
            Me.cacRevAccountIdNo.PreviousSearchTerm = Nothing
            Me.cacRevAccountIdNo.PropertySelector = Nothing
            Me.cacRevAccountIdNo.ReadOnlyCombo = False
            Me.cacRevAccountIdNo.SuggestBoxHeight = 200
            Me.cacRevAccountIdNo.SuggestListOrderRule = Nothing
            Me.cacRevAccountIdNo.TextToSearch = Nothing
            Me.cacRevAccountIdNo.Translatable = False
            Me.cacRevAccountIdNo.ValueIsMandatory = False
            Me.cacRevAccountIdNo.ValueIsNullable = False
            Me.cacRevAccountIdNo.ValueIsNumeric = False
            Me.cacRevAccountIdNo.ValueMember = "IdNo"
            '
            'cacArAccountIdNo
            '
            Me.cacArAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cacArAccountIdNo.BegFindValue = Nothing
            Me.cacArAccountIdNo.ChangingSearchValueOnly = False
            Me.cacArAccountIdNo.CurrentSearchTerm = ""
            Me.cacArAccountIdNo.DefaultValue = Nothing
            Me.cacArAccountIdNo.DisplayMember = "Name"
            Me.cacArAccountIdNo.EditingMode = False
            Me.cacArAccountIdNo.EndFindValue = Nothing
            Me.cacArAccountIdNo.FieldDescription = Nothing
            Me.cacArAccountIdNo.FieldName = Nothing
            Me.cacArAccountIdNo.FilterRule = Nothing
            Me.cacArAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacArAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacArAccountIdNo, True)
            resources.ApplyResources(Me.cacArAccountIdNo, "cacArAccountIdNo")
            Me.cacArAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacArAccountIdNo.FormattingEnabled = True
            Me.cacArAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cacArAccountIdNo.IgnoreCase = False
            Me.cacArAccountIdNo.LinkedLabel = Nothing
            Me.cacArAccountIdNo.Name = "cacArAccountIdNo"
            Me.cacArAccountIdNo.OldValue = 0
            Me.cacArAccountIdNo.OriginalDataSource = Nothing
            Me.cacArAccountIdNo.OriginalList = Nothing
            Me.cacArAccountIdNo.OverrideDropDownStyleList = False
            Me.cacArAccountIdNo.PreviousSearchTerm = Nothing
            Me.cacArAccountIdNo.PropertySelector = Nothing
            Me.cacArAccountIdNo.ReadOnlyCombo = False
            Me.cacArAccountIdNo.SuggestBoxHeight = 200
            Me.cacArAccountIdNo.SuggestListOrderRule = Nothing
            Me.cacArAccountIdNo.TextToSearch = Nothing
            Me.cacArAccountIdNo.Translatable = False
            Me.cacArAccountIdNo.ValueIsMandatory = False
            Me.cacArAccountIdNo.ValueIsNullable = False
            Me.cacArAccountIdNo.ValueIsNumeric = False
            Me.cacArAccountIdNo.ValueMember = "IdNo"
            '
            'cacPaymentMethod
            '
            Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
            Me.cacPaymentMethod.BegFindValue = Nothing
            Me.cacPaymentMethod.ChangingSearchValueOnly = False
            Me.cacPaymentMethod.CurrentSearchTerm = ""
            Me.cacPaymentMethod.DefaultValue = Nothing
            Me.cacPaymentMethod.DisplayMember = "Name"
            Me.cacPaymentMethod.EditingMode = False
            Me.cacPaymentMethod.EndFindValue = Nothing
            Me.cacPaymentMethod.FieldDescription = Nothing
            Me.cacPaymentMethod.FieldName = Nothing
            Me.cacPaymentMethod.FilterRule = Nothing
            Me.cacPaymentMethod.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacPaymentMethod.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacPaymentMethod, True)
            resources.ApplyResources(Me.cacPaymentMethod, "cacPaymentMethod")
            Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
            Me.cacPaymentMethod.FormattingEnabled = True
            Me.cacPaymentMethod.HideWhenNotEditingOrAdding = False
            Me.cacPaymentMethod.IgnoreCase = False
            Me.cacPaymentMethod.LinkedLabel = Nothing
            Me.cacPaymentMethod.Name = "cacPaymentMethod"
            Me.cacPaymentMethod.OldValue = 0
            Me.cacPaymentMethod.OriginalDataSource = Nothing
            Me.cacPaymentMethod.OriginalList = Nothing
            Me.cacPaymentMethod.OverrideDropDownStyleList = False
            Me.cacPaymentMethod.PreviousSearchTerm = Nothing
            Me.cacPaymentMethod.PropertySelector = Nothing
            Me.cacPaymentMethod.ReadOnlyCombo = False
            Me.cacPaymentMethod.SuggestBoxHeight = 200
            Me.cacPaymentMethod.SuggestListOrderRule = Nothing
            Me.cacPaymentMethod.TextToSearch = Nothing
            Me.cacPaymentMethod.Translatable = False
            Me.cacPaymentMethod.ValueIsMandatory = False
            Me.cacPaymentMethod.ValueIsNullable = False
            Me.cacPaymentMethod.ValueIsNumeric = False
            Me.cacPaymentMethod.ValueMember = "Code"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'cacDiscountSchemeIdNo
            '
            Me.cacDiscountSchemeIdNo.BackColor = System.Drawing.Color.White
            Me.cacDiscountSchemeIdNo.BegFindValue = Nothing
            Me.cacDiscountSchemeIdNo.ChangingSearchValueOnly = False
            Me.cacDiscountSchemeIdNo.CurrentSearchTerm = ""
            Me.cacDiscountSchemeIdNo.DefaultValue = Nothing
            Me.cacDiscountSchemeIdNo.DisplayMember = "Name"
            Me.cacDiscountSchemeIdNo.EditingMode = False
            Me.cacDiscountSchemeIdNo.EndFindValue = Nothing
            Me.cacDiscountSchemeIdNo.FieldDescription = Nothing
            Me.cacDiscountSchemeIdNo.FieldName = Nothing
            Me.cacDiscountSchemeIdNo.FilterRule = Nothing
            Me.cacDiscountSchemeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacDiscountSchemeIdNo.FindEnabled = False
            resources.ApplyResources(Me.cacDiscountSchemeIdNo, "cacDiscountSchemeIdNo")
            Me.cacDiscountSchemeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDiscountSchemeIdNo.FormattingEnabled = True
            Me.cacDiscountSchemeIdNo.HideWhenNotEditingOrAdding = False
            Me.cacDiscountSchemeIdNo.IgnoreCase = False
            Me.cacDiscountSchemeIdNo.LinkedLabel = Nothing
            Me.cacDiscountSchemeIdNo.Name = "cacDiscountSchemeIdNo"
            Me.cacDiscountSchemeIdNo.OldValue = 0
            Me.cacDiscountSchemeIdNo.OriginalDataSource = Nothing
            Me.cacDiscountSchemeIdNo.OriginalList = Nothing
            Me.cacDiscountSchemeIdNo.OverrideDropDownStyleList = False
            Me.cacDiscountSchemeIdNo.PreviousSearchTerm = Nothing
            Me.cacDiscountSchemeIdNo.PropertySelector = Nothing
            Me.cacDiscountSchemeIdNo.ReadOnlyCombo = False
            Me.cacDiscountSchemeIdNo.SuggestBoxHeight = 200
            Me.cacDiscountSchemeIdNo.SuggestListOrderRule = Nothing
            Me.cacDiscountSchemeIdNo.TextToSearch = Nothing
            Me.cacDiscountSchemeIdNo.Translatable = False
            Me.cacDiscountSchemeIdNo.ValueIsMandatory = False
            Me.cacDiscountSchemeIdNo.ValueIsNullable = False
            Me.cacDiscountSchemeIdNo.ValueIsNumeric = False
            Me.cacDiscountSchemeIdNo.ValueMember = "IdNo"
            '
            'dtpDateAccountOpen
            '
            Me.dtpDateAccountOpen.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDateAccountOpen.DefaultValue = Nothing
            Me.dtpDateAccountOpen.DisplayOnly = False
            Me.dtpDateAccountOpen.DtpDefaultValue = Nothing
            Me.dtpDateAccountOpen.EditingMode = False
            Me.dtpDateAccountOpen.EditsAllowed = False
            Me.floDataDisplay.SetFlowBreak(Me.dtpDateAccountOpen, True)
            resources.ApplyResources(Me.dtpDateAccountOpen, "dtpDateAccountOpen")
            Me.dtpDateAccountOpen.ForeColor = System.Drawing.Color.Black
            Me.dtpDateAccountOpen.LinkedLabel = Nothing
            Me.dtpDateAccountOpen.Name = "dtpDateAccountOpen"
            Me.dtpDateAccountOpen.ReadOnlyDp = False
            Me.dtpDateAccountOpen.SecurityKey = Nothing
            Me.dtpDateAccountOpen.ShowLongDate = False
            Me.dtpDateAccountOpen.ShowTime = False
            Me.dtpDateAccountOpen.TargetCalendar = CType(resources.GetObject("dtpDateAccountOpen.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDateAccountOpen.Translatable = False
            Me.dtpDateAccountOpen.Value = Nothing
            Me.dtpDateAccountOpen.ValueIsMandatory = False
            Me.dtpDateAccountOpen.ValueIsNullable = False
            '
            'cacAccountStatus
            '
            Me.cacAccountStatus.BackColor = System.Drawing.Color.White
            Me.cacAccountStatus.BegFindValue = Nothing
            Me.cacAccountStatus.ChangingSearchValueOnly = False
            Me.cacAccountStatus.CurrentSearchTerm = ""
            Me.cacAccountStatus.DefaultValue = Nothing
            Me.cacAccountStatus.DisplayMember = "Name"
            Me.cacAccountStatus.EditingMode = False
            Me.cacAccountStatus.EndFindValue = Nothing
            Me.cacAccountStatus.FieldDescription = Nothing
            Me.cacAccountStatus.FieldName = Nothing
            Me.cacAccountStatus.FilterRule = Nothing
            Me.cacAccountStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacAccountStatus.FindEnabled = False
            resources.ApplyResources(Me.cacAccountStatus, "cacAccountStatus")
            Me.cacAccountStatus.ForeColor = System.Drawing.Color.Black
            Me.cacAccountStatus.FormattingEnabled = True
            Me.cacAccountStatus.HideWhenNotEditingOrAdding = False
            Me.cacAccountStatus.IgnoreCase = False
            Me.cacAccountStatus.LinkedLabel = Nothing
            Me.cacAccountStatus.Name = "cacAccountStatus"
            Me.cacAccountStatus.OldValue = 0
            Me.cacAccountStatus.OriginalDataSource = Nothing
            Me.cacAccountStatus.OriginalList = Nothing
            Me.cacAccountStatus.OverrideDropDownStyleList = False
            Me.cacAccountStatus.PreviousSearchTerm = Nothing
            Me.cacAccountStatus.PropertySelector = Nothing
            Me.cacAccountStatus.ReadOnlyCombo = False
            Me.cacAccountStatus.SuggestBoxHeight = 200
            Me.cacAccountStatus.SuggestListOrderRule = Nothing
            Me.cacAccountStatus.TextToSearch = Nothing
            Me.cacAccountStatus.Translatable = False
            Me.cacAccountStatus.ValueIsMandatory = False
            Me.cacAccountStatus.ValueIsNullable = False
            Me.cacAccountStatus.ValueIsNumeric = False
            Me.cacAccountStatus.ValueMember = "Code"
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            resources.ApplyResources(Me.lblActive, "lblActive")
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Translatable = True
            '
            'txtBalance
            '
            Me.txtBalance.BackColor = System.Drawing.Color.White
            Me.txtBalance.BegFindValue = Nothing
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = False
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.DisplayOnly = True
            Me.txtBalance.EditingMode = False
            Me.txtBalance.EndFindValue = Nothing
            Me.txtBalance.FieldDescription = Nothing
            Me.txtBalance.FieldName = Nothing
            Me.txtBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBalance.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.txtBalance, True)
            resources.ApplyResources(Me.txtBalance, "txtBalance")
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBalance.Translatable = False
            Me.txtBalance.ValueIsNumeric = True
            '
            'chkActive
            '
            Me.chkActive.BackColor = System.Drawing.Color.Transparent
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = True
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            resources.ApplyResources(Me.chkActive, "chkActive")
            Me.floDataDisplay.SetFlowBreak(Me.chkActive, True)
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
            'CustomerEntryTvNew
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "CustomerEntryTvNew"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblAccountStatus As CLabel
        Friend WithEvents lblDateAccountOpen As CLabel
        Friend WithEvents txtOpeningBalance As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblCustomerCode As CLabel
        Friend WithEvents txtCustomerCode As CTextBox
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents lblCustomerName As CLabel
        Friend WithEvents txtCustomerName As CTextBox
        Friend WithEvents lblCustomerNameAra As CLabel
        Friend WithEvents txtCustomerNameAra As CTextBoxArabic
        Friend WithEvents lblContactPerson As CLabel
        Friend WithEvents txtContactPerson As CTextBox
        Friend WithEvents lblContactDesignation As CLabel
        Friend WithEvents txtContactDesignation As CTextBox
        Friend WithEvents lblStreet As CLabel
        Friend WithEvents txtStreet As CTextBox
        Friend WithEvents lblDistrict As CLabel
        Friend WithEvents txtDistrict As CTextBox
        Friend WithEvents lblTownCity As CLabel
        Friend WithEvents txtTownCity As CTextBox
        Friend WithEvents lblProvinceState As CLabel
        Friend WithEvents txtProvinceState As CTextBox
        Friend WithEvents lblPoBox As CLabel
        Friend WithEvents txtPoBox As CTextBox
        Friend WithEvents lblZipCode As CLabel
        Friend WithEvents txtZipCode As CTextBox
        Friend WithEvents lblCountryCode As CLabel
        Friend WithEvents lblPhone1 As CLabel
        Friend WithEvents txtPhone1 As CTextBox
        Friend WithEvents lblPhone2 As CLabel
        Friend WithEvents txtPhone2 As CTextBox
        Friend WithEvents lblFax As CLabel
        Friend WithEvents txtFax As CTextBox
        Friend WithEvents lblMobile As CLabel
        Friend WithEvents txtMobile As CTextBox
        Friend WithEvents lblEmail As CLabel
        Friend WithEvents txtEmail As CTextBox
        Friend WithEvents lblWebsite As CLabel
        Friend WithEvents txtWebsite As CTextBox
        Friend WithEvents lblCrNumber As CLabel
        Friend WithEvents txtCrNumber As CTextBox
        Friend WithEvents lblBankIdNo As CLabel
        Friend WithEvents lblBankAccountNo As CLabel
        Friend WithEvents txtBankAccountNo As CTextBox
        Friend WithEvents lblIban As CLabel
        Friend WithEvents txtIban As CTextBox
        Friend WithEvents lblRevAccountIdNo As CLabel
        Friend WithEvents lblArAccountIdNo As CLabel
        Friend WithEvents lblCreditLimit As CLabel
        Friend WithEvents txtCreditLimit As CTextBox
        Friend WithEvents lblPaymentDueDays As CLabel
        Friend WithEvents txtPaymentDueDays As CTextBox
        Friend WithEvents lblPaymentMethod As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtSettlementDueDays As CTextBox
        Friend WithEvents lblSettlementDiscount As CLabel
        Friend WithEvents txtSettlementDiscount As CTextBox
        Friend WithEvents lblOpeningBalance As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents dtpDateAccountOpen As CCustomDateTimePicker
        Friend WithEvents cacCountryCode As CaComboBox
        Friend WithEvents cacBankIdNo As CaComboBox
        Friend WithEvents cacRevAccountIdNo As CaComboBox
        Friend WithEvents cacArAccountIdNo As CaComboBox
        Friend WithEvents cacPaymentMethod As CaComboBox
        Friend WithEvents cacDiscountSchemeIdNo As CaComboBox
        Friend WithEvents cacAccountStatus As CaComboBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents txtBalance As CTextBox
        Friend WithEvents chkActive As CCheckBox
    End Class
End Namespace