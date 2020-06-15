Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.LocalizationUtilities

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CustomerEntryTv
        Inherits CFormEntryTv

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
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me._localizableMessage1 = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
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
        Me.dtpDateAccountOpen = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.cacAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        '
        'LocalizableContent1
        '
        LocalizableContent1.Messages.Add(Me._MSGMandatoryFields)
        LocalizableContent1.Messages.Add(Me._localizableMessage1)
        '
        '_MSGMandatoryFields
        '
        resources.ApplyResources(Me._MSGMandatoryFields, "_MSGMandatoryFields")
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'lblAccountStatus
        '
        Me.lblAccountStatus.DisplayOnly = true
        Me.lblAccountStatus.EditingMode = false
        resources.ApplyResources(Me.lblAccountStatus, "lblAccountStatus")
        Me.lblAccountStatus.Name = "lblAccountStatus"
        '
        'lblDateAccountOpen
        '
        Me.lblDateAccountOpen.DisplayOnly = true
        Me.lblDateAccountOpen.EditingMode = false
        resources.ApplyResources(Me.lblDateAccountOpen, "lblDateAccountOpen")
        Me.lblDateAccountOpen.Name = "lblDateAccountOpen"
        '
        'txtOpeningBalance
        '
        Me.txtOpeningBalance.BackColor = System.Drawing.Color.White
        Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpeningBalance.ComputedValue = false
        Me.txtOpeningBalance.CustomFormat = Nothing
        Me.txtOpeningBalance.DataBoundControl = true
        Me.txtOpeningBalance.EditingMode = false
        resources.ApplyResources(Me.txtOpeningBalance, "txtOpeningBalance")
        Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtOpeningBalance.MaximumValue = Nothing
        Me.txtOpeningBalance.MinimumValue = Nothing
        Me.txtOpeningBalance.Name = "txtOpeningBalance"
        Me.txtOpeningBalance.OldValue = Nothing
        Me.txtOpeningBalance.ReadOnly = true
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.DisplayOnly = true
        Me.lblOpeningBalance.EditingMode = false
        resources.ApplyResources(Me.lblOpeningBalance, "lblOpeningBalance")
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        '
        'txtSettlementDiscount
        '
        Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
        Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDiscount.ComputedValue = false
        Me.txtSettlementDiscount.CustomFormat = Nothing
        Me.txtSettlementDiscount.DataBoundControl = true
        Me.txtSettlementDiscount.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtSettlementDiscount, true)
        resources.ApplyResources(Me.txtSettlementDiscount, "txtSettlementDiscount")
        Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDiscount.IgnoreNullCheck = true
        Me.txtSettlementDiscount.LinkedLabel = Nothing
        Me.txtSettlementDiscount.MaximumValue = Nothing
        Me.txtSettlementDiscount.MinimumValue = Nothing
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.ReadOnly = true
        '
        'lblSettlementDiscount
        '
        Me.lblSettlementDiscount.DisplayOnly = true
        Me.lblSettlementDiscount.EditingMode = false
        resources.ApplyResources(Me.lblSettlementDiscount, "lblSettlementDiscount")
        Me.lblSettlementDiscount.Name = "lblSettlementDiscount"
        '
        'txtSettlementDueDays
        '
        Me.txtSettlementDueDays.BackColor = System.Drawing.Color.White
        Me.txtSettlementDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDueDays.ComputedValue = false
        Me.txtSettlementDueDays.CustomFormat = Nothing
        Me.txtSettlementDueDays.DataBoundControl = true
        Me.txtSettlementDueDays.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtSettlementDueDays, true)
        resources.ApplyResources(Me.txtSettlementDueDays, "txtSettlementDueDays")
        Me.txtSettlementDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDueDays.IgnoreNullCheck = true
        Me.txtSettlementDueDays.LinkedLabel = Me.CLabel2
        Me.txtSettlementDueDays.MaximumValue = Nothing
        Me.txtSettlementDueDays.MinimumValue = Nothing
        Me.txtSettlementDueDays.Name = "txtSettlementDueDays"
        Me.txtSettlementDueDays.OldValue = Nothing
        Me.txtSettlementDueDays.ReadOnly = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.DisplayOnly = true
        Me.lblPaymentMethod.EditingMode = false
        resources.ApplyResources(Me.lblPaymentMethod, "lblPaymentMethod")
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        '
        'txtPaymentDueDays
        '
        Me.txtPaymentDueDays.BackColor = System.Drawing.Color.White
        Me.txtPaymentDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentDueDays.ComputedValue = false
        Me.txtPaymentDueDays.CustomFormat = Nothing
        Me.txtPaymentDueDays.DataBoundControl = true
        Me.txtPaymentDueDays.EditingMode = false
        resources.ApplyResources(Me.txtPaymentDueDays, "txtPaymentDueDays")
        Me.txtPaymentDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentDueDays.IgnoreNullCheck = true
        Me.txtPaymentDueDays.LinkedLabel = Me.lblPaymentDueDays
        Me.txtPaymentDueDays.MaximumValue = Nothing
        Me.txtPaymentDueDays.MinimumValue = Nothing
        Me.txtPaymentDueDays.Name = "txtPaymentDueDays"
        Me.txtPaymentDueDays.OldValue = Nothing
        Me.txtPaymentDueDays.ReadOnly = true
        '
        'lblPaymentDueDays
        '
        Me.lblPaymentDueDays.DisplayOnly = true
        Me.lblPaymentDueDays.EditingMode = false
        resources.ApplyResources(Me.lblPaymentDueDays, "lblPaymentDueDays")
        Me.lblPaymentDueDays.Name = "lblPaymentDueDays"
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.BackColor = System.Drawing.Color.White
        Me.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditLimit.ComputedValue = false
        Me.txtCreditLimit.CustomFormat = Nothing
        Me.txtCreditLimit.DataBoundControl = true
        Me.txtCreditLimit.EditingMode = false
        resources.ApplyResources(Me.txtCreditLimit, "txtCreditLimit")
        Me.txtCreditLimit.ForeColor = System.Drawing.Color.Black
        Me.txtCreditLimit.LinkedLabel = Me.lblCreditLimit
        Me.txtCreditLimit.MaximumValue = Nothing
        Me.txtCreditLimit.MinimumValue = Nothing
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.OldValue = Nothing
        Me.txtCreditLimit.ReadOnly = true
        '
        'lblCreditLimit
        '
        Me.lblCreditLimit.DisplayOnly = true
        Me.lblCreditLimit.EditingMode = false
        resources.ApplyResources(Me.lblCreditLimit, "lblCreditLimit")
        Me.lblCreditLimit.Name = "lblCreditLimit"
        '
        'lblArAccountIdNo
        '
        Me.lblArAccountIdNo.DisplayOnly = true
        Me.lblArAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblArAccountIdNo, "lblArAccountIdNo")
        Me.lblArAccountIdNo.Name = "lblArAccountIdNo"
        '
        'lblRevAccountIdNo
        '
        Me.lblRevAccountIdNo.DisplayOnly = true
        Me.lblRevAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblRevAccountIdNo, "lblRevAccountIdNo")
        Me.lblRevAccountIdNo.Name = "lblRevAccountIdNo"
        '
        'txtIban
        '
        Me.txtIban.BackColor = System.Drawing.Color.White
        Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIban.ComputedValue = false
        Me.txtIban.CustomFormat = Nothing
        Me.txtIban.DataBoundControl = true
        Me.txtIban.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtIban, true)
        resources.ApplyResources(Me.txtIban, "txtIban")
        Me.txtIban.ForeColor = System.Drawing.Color.Black
        Me.txtIban.LinkedLabel = Me.lblIban
        Me.txtIban.MaximumValue = Nothing
        Me.txtIban.MinimumValue = Nothing
        Me.txtIban.Name = "txtIban"
        Me.txtIban.OldValue = Nothing
        Me.txtIban.ReadOnly = true
        '
        'lblIban
        '
        Me.lblIban.DisplayOnly = true
        Me.lblIban.EditingMode = false
        resources.ApplyResources(Me.lblIban, "lblIban")
        Me.lblIban.Name = "lblIban"
        '
        'txtBankAccountNo
        '
        Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
        Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccountNo.ComputedValue = false
        Me.txtBankAccountNo.CustomFormat = Nothing
        Me.txtBankAccountNo.DataBoundControl = true
        Me.txtBankAccountNo.EditingMode = false
        resources.ApplyResources(Me.txtBankAccountNo, "txtBankAccountNo")
        Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
        Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
        Me.txtBankAccountNo.MaximumValue = Nothing
        Me.txtBankAccountNo.MinimumValue = Nothing
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.OldValue = Nothing
        Me.txtBankAccountNo.ReadOnly = true
        '
        'lblBankAccountNo
        '
        Me.lblBankAccountNo.DisplayOnly = true
        Me.lblBankAccountNo.EditingMode = false
        resources.ApplyResources(Me.lblBankAccountNo, "lblBankAccountNo")
        Me.lblBankAccountNo.Name = "lblBankAccountNo"
        '
        'lblBankIdNo
        '
        Me.lblBankIdNo.DisplayOnly = true
        Me.lblBankIdNo.EditingMode = false
        resources.ApplyResources(Me.lblBankIdNo, "lblBankIdNo")
        Me.lblBankIdNo.Name = "lblBankIdNo"
        '
        'txtCrNumber
        '
        Me.txtCrNumber.BackColor = System.Drawing.Color.White
        Me.txtCrNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCrNumber.ComputedValue = false
        Me.txtCrNumber.CustomFormat = Nothing
        Me.txtCrNumber.DataBoundControl = true
        Me.txtCrNumber.EditingMode = false
        resources.ApplyResources(Me.txtCrNumber, "txtCrNumber")
        Me.txtCrNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCrNumber.LinkedLabel = Me.lblCrNumber
        Me.txtCrNumber.MaximumValue = Nothing
        Me.txtCrNumber.MinimumValue = Nothing
        Me.txtCrNumber.Name = "txtCrNumber"
        Me.txtCrNumber.OldValue = Nothing
        Me.txtCrNumber.ReadOnly = true
        '
        'lblCrNumber
        '
        Me.lblCrNumber.DisplayOnly = true
        Me.lblCrNumber.EditingMode = false
        resources.ApplyResources(Me.lblCrNumber, "lblCrNumber")
        Me.lblCrNumber.Name = "lblCrNumber"
        '
        'txtWebsite
        '
        Me.txtWebsite.BackColor = System.Drawing.Color.White
        Me.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWebsite.ComputedValue = false
        Me.txtWebsite.CustomFormat = Nothing
        Me.txtWebsite.DataBoundControl = true
        Me.txtWebsite.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtWebsite, true)
        resources.ApplyResources(Me.txtWebsite, "txtWebsite")
        Me.txtWebsite.ForeColor = System.Drawing.Color.Black
        Me.txtWebsite.LinkedLabel = Me.lblWebsite
        Me.txtWebsite.MaximumValue = Nothing
        Me.txtWebsite.MinimumValue = Nothing
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.OldValue = Nothing
        Me.txtWebsite.ReadOnly = true
        '
        'lblWebsite
        '
        Me.lblWebsite.DisplayOnly = true
        Me.lblWebsite.EditingMode = false
        resources.ApplyResources(Me.lblWebsite, "lblWebsite")
        Me.lblWebsite.Name = "lblWebsite"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.ComputedValue = false
        Me.txtEmail.CustomFormat = Nothing
        Me.txtEmail.DataBoundControl = true
        Me.txtEmail.EditingMode = false
        resources.ApplyResources(Me.txtEmail, "txtEmail")
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.LinkedLabel = Me.lblEmail
        Me.txtEmail.MaximumValue = Nothing
        Me.txtEmail.MinimumValue = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OldValue = Nothing
        Me.txtEmail.ReadOnly = true
        '
        'lblEmail
        '
        Me.lblEmail.DisplayOnly = true
        Me.lblEmail.EditingMode = false
        resources.ApplyResources(Me.lblEmail, "lblEmail")
        Me.lblEmail.Name = "lblEmail"
        '
        'txtMobile
        '
        Me.txtMobile.BackColor = System.Drawing.Color.White
        Me.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMobile.ComputedValue = false
        Me.txtMobile.CustomFormat = Nothing
        Me.txtMobile.DataBoundControl = true
        Me.txtMobile.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtMobile, true)
        resources.ApplyResources(Me.txtMobile, "txtMobile")
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.LinkedLabel = Me.lblMobile
        Me.txtMobile.MaximumValue = Nothing
        Me.txtMobile.MinimumValue = Nothing
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.OldValue = Nothing
        Me.txtMobile.ReadOnly = true
        '
        'lblMobile
        '
        Me.lblMobile.DisplayOnly = true
        Me.lblMobile.EditingMode = false
        resources.ApplyResources(Me.lblMobile, "lblMobile")
        Me.lblMobile.Name = "lblMobile"
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.ComputedValue = false
        Me.txtFax.CustomFormat = Nothing
        Me.txtFax.DataBoundControl = true
        Me.txtFax.EditingMode = false
        resources.ApplyResources(Me.txtFax, "txtFax")
        Me.txtFax.ForeColor = System.Drawing.Color.Black
        Me.txtFax.LinkedLabel = Me.lblFax
        Me.txtFax.MaximumValue = Nothing
        Me.txtFax.MinimumValue = Nothing
        Me.txtFax.Name = "txtFax"
        Me.txtFax.OldValue = Nothing
        Me.txtFax.ReadOnly = true
        '
        'lblFax
        '
        Me.lblFax.DisplayOnly = true
        Me.lblFax.EditingMode = false
        resources.ApplyResources(Me.lblFax, "lblFax")
        Me.lblFax.Name = "lblFax"
        '
        'txtPhone2
        '
        Me.txtPhone2.BackColor = System.Drawing.Color.White
        Me.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone2.ComputedValue = false
        Me.txtPhone2.CustomFormat = Nothing
        Me.txtPhone2.DataBoundControl = true
        Me.txtPhone2.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtPhone2, true)
        resources.ApplyResources(Me.txtPhone2, "txtPhone2")
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.LinkedLabel = Me.lblPhone2
        Me.txtPhone2.MaximumValue = Nothing
        Me.txtPhone2.MinimumValue = Nothing
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.OldValue = Nothing
        Me.txtPhone2.ReadOnly = true
        '
        'lblPhone2
        '
        Me.lblPhone2.DisplayOnly = true
        Me.lblPhone2.EditingMode = false
        resources.ApplyResources(Me.lblPhone2, "lblPhone2")
        Me.lblPhone2.Name = "lblPhone2"
        '
        'txtPhone1
        '
        Me.txtPhone1.BackColor = System.Drawing.Color.White
        Me.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone1.ComputedValue = false
        Me.txtPhone1.CustomFormat = Nothing
        Me.txtPhone1.DataBoundControl = true
        Me.txtPhone1.EditingMode = false
        resources.ApplyResources(Me.txtPhone1, "txtPhone1")
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.LinkedLabel = Me.lblPhone1
        Me.txtPhone1.MaximumValue = Nothing
        Me.txtPhone1.MinimumValue = Nothing
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.OldValue = Nothing
        Me.txtPhone1.ReadOnly = true
        '
        'lblPhone1
        '
        Me.lblPhone1.DisplayOnly = true
        Me.lblPhone1.EditingMode = false
        resources.ApplyResources(Me.lblPhone1, "lblPhone1")
        Me.lblPhone1.Name = "lblPhone1"
        '
        'lblCountryCode
        '
        Me.lblCountryCode.DisplayOnly = true
        Me.lblCountryCode.EditingMode = false
        resources.ApplyResources(Me.lblCountryCode, "lblCountryCode")
        Me.lblCountryCode.Name = "lblCountryCode"
        '
        'txtZipCode
        '
        Me.txtZipCode.BackColor = System.Drawing.Color.White
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.ComputedValue = false
        Me.txtZipCode.CustomFormat = Nothing
        Me.txtZipCode.DataBoundControl = true
        Me.txtZipCode.EditingMode = false
        resources.ApplyResources(Me.txtZipCode, "txtZipCode")
        Me.txtZipCode.ForeColor = System.Drawing.Color.Black
        Me.txtZipCode.LinkedLabel = Me.lblZipCode
        Me.txtZipCode.MaximumValue = Nothing
        Me.txtZipCode.MinimumValue = Nothing
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.OldValue = Nothing
        Me.txtZipCode.ReadOnly = true
        '
        'lblZipCode
        '
        Me.lblZipCode.DisplayOnly = true
        Me.lblZipCode.EditingMode = false
        resources.ApplyResources(Me.lblZipCode, "lblZipCode")
        Me.lblZipCode.Name = "lblZipCode"
        '
        'txtPoBox
        '
        Me.txtPoBox.BackColor = System.Drawing.Color.White
        Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPoBox.ComputedValue = false
        Me.txtPoBox.CustomFormat = Nothing
        Me.txtPoBox.DataBoundControl = true
        Me.txtPoBox.EditingMode = false
        resources.ApplyResources(Me.txtPoBox, "txtPoBox")
        Me.txtPoBox.ForeColor = System.Drawing.Color.Black
        Me.txtPoBox.LinkedLabel = Me.lblPoBox
        Me.txtPoBox.MaximumValue = Nothing
        Me.txtPoBox.MinimumValue = Nothing
        Me.txtPoBox.Name = "txtPoBox"
        Me.txtPoBox.OldValue = Nothing
        Me.txtPoBox.ReadOnly = true
        '
        'lblPoBox
        '
        Me.lblPoBox.DisplayOnly = true
        Me.lblPoBox.EditingMode = false
        resources.ApplyResources(Me.lblPoBox, "lblPoBox")
        Me.lblPoBox.Name = "lblPoBox"
        '
        'txtProvinceState
        '
        Me.txtProvinceState.BackColor = System.Drawing.Color.White
        Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvinceState.ComputedValue = false
        Me.txtProvinceState.CustomFormat = Nothing
        Me.txtProvinceState.DataBoundControl = true
        Me.txtProvinceState.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtProvinceState, true)
        resources.ApplyResources(Me.txtProvinceState, "txtProvinceState")
        Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
        Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
        Me.txtProvinceState.MaximumValue = Nothing
        Me.txtProvinceState.MinimumValue = Nothing
        Me.txtProvinceState.Name = "txtProvinceState"
        Me.txtProvinceState.OldValue = Nothing
        Me.txtProvinceState.ReadOnly = true
        '
        'lblProvinceState
        '
        Me.lblProvinceState.DisplayOnly = true
        Me.lblProvinceState.EditingMode = false
        resources.ApplyResources(Me.lblProvinceState, "lblProvinceState")
        Me.lblProvinceState.Name = "lblProvinceState"
        '
        'txtTownCity
        '
        Me.txtTownCity.BackColor = System.Drawing.Color.White
        Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTownCity.ComputedValue = false
        Me.txtTownCity.CustomFormat = Nothing
        Me.txtTownCity.DataBoundControl = true
        Me.txtTownCity.EditingMode = false
        resources.ApplyResources(Me.txtTownCity, "txtTownCity")
        Me.txtTownCity.ForeColor = System.Drawing.Color.Black
        Me.txtTownCity.LinkedLabel = Me.lblTownCity
        Me.txtTownCity.MaximumValue = Nothing
        Me.txtTownCity.MinimumValue = Nothing
        Me.txtTownCity.Name = "txtTownCity"
        Me.txtTownCity.OldValue = Nothing
        Me.txtTownCity.ReadOnly = true
        '
        'lblTownCity
        '
        Me.lblTownCity.DisplayOnly = true
        Me.lblTownCity.EditingMode = false
        resources.ApplyResources(Me.lblTownCity, "lblTownCity")
        Me.lblTownCity.Name = "lblTownCity"
        '
        'txtDistrict
        '
        Me.txtDistrict.BackColor = System.Drawing.Color.White
        Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrict.ComputedValue = false
        Me.txtDistrict.CustomFormat = Nothing
        Me.txtDistrict.DataBoundControl = true
        Me.txtDistrict.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtDistrict, true)
        resources.ApplyResources(Me.txtDistrict, "txtDistrict")
        Me.txtDistrict.ForeColor = System.Drawing.Color.Black
        Me.txtDistrict.LinkedLabel = Me.lblDistrict
        Me.txtDistrict.MaximumValue = Nothing
        Me.txtDistrict.MinimumValue = Nothing
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.OldValue = Nothing
        Me.txtDistrict.ReadOnly = true
        '
        'lblDistrict
        '
        Me.lblDistrict.DisplayOnly = true
        Me.lblDistrict.EditingMode = false
        resources.ApplyResources(Me.lblDistrict, "lblDistrict")
        Me.lblDistrict.Name = "lblDistrict"
        '
        'txtStreet
        '
        Me.txtStreet.BackColor = System.Drawing.Color.White
        Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreet.ComputedValue = false
        Me.txtStreet.CustomFormat = Nothing
        Me.txtStreet.DataBoundControl = true
        Me.txtStreet.EditingMode = false
        resources.ApplyResources(Me.txtStreet, "txtStreet")
        Me.txtStreet.ForeColor = System.Drawing.Color.Black
        Me.txtStreet.LinkedLabel = Me.lblStreet
        Me.txtStreet.MaximumValue = Nothing
        Me.txtStreet.MinimumValue = Nothing
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.OldValue = Nothing
        Me.txtStreet.ReadOnly = true
        '
        'lblStreet
        '
        Me.lblStreet.DisplayOnly = true
        Me.lblStreet.EditingMode = false
        resources.ApplyResources(Me.lblStreet, "lblStreet")
        Me.lblStreet.Name = "lblStreet"
        '
        'txtContactDesignation
        '
        Me.txtContactDesignation.BackColor = System.Drawing.Color.White
        Me.txtContactDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactDesignation.ComputedValue = false
        Me.txtContactDesignation.CustomFormat = Nothing
        Me.txtContactDesignation.DataBoundControl = true
        Me.txtContactDesignation.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtContactDesignation, true)
        resources.ApplyResources(Me.txtContactDesignation, "txtContactDesignation")
        Me.txtContactDesignation.ForeColor = System.Drawing.Color.Black
        Me.txtContactDesignation.LinkedLabel = Me.lblContactDesignation
        Me.txtContactDesignation.MaximumValue = Nothing
        Me.txtContactDesignation.MinimumValue = Nothing
        Me.txtContactDesignation.Name = "txtContactDesignation"
        Me.txtContactDesignation.OldValue = Nothing
        Me.txtContactDesignation.ReadOnly = true
        '
        'lblContactDesignation
        '
        Me.lblContactDesignation.DisplayOnly = true
        Me.lblContactDesignation.EditingMode = false
        resources.ApplyResources(Me.lblContactDesignation, "lblContactDesignation")
        Me.lblContactDesignation.Name = "lblContactDesignation"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.BackColor = System.Drawing.Color.White
        Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactPerson.ComputedValue = false
        Me.txtContactPerson.CustomFormat = Nothing
        Me.txtContactPerson.DataBoundControl = true
        Me.txtContactPerson.EditingMode = false
        resources.ApplyResources(Me.txtContactPerson, "txtContactPerson")
        Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
        Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
        Me.txtContactPerson.MaximumValue = Nothing
        Me.txtContactPerson.MinimumValue = Nothing
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.OldValue = Nothing
        Me.txtContactPerson.ReadOnly = true
        '
        'lblContactPerson
        '
        Me.lblContactPerson.DisplayOnly = true
        Me.lblContactPerson.EditingMode = false
        resources.ApplyResources(Me.lblContactPerson, "lblContactPerson")
        Me.lblContactPerson.Name = "lblContactPerson"
        '
        'txtCustomerNameAra
        '
        Me.txtCustomerNameAra.BackColor = System.Drawing.Color.White
        Me.txtCustomerNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerNameAra.ComputedValue = false
        Me.txtCustomerNameAra.CustomFormat = Nothing
        Me.txtCustomerNameAra.DataBoundControl = true
        Me.txtCustomerNameAra.EditingMode = false
        Me.txtCustomerNameAra.EnglishControl = Me.txtCustomerName
        Me.floDataDisplay.SetFlowBreak(Me.txtCustomerNameAra, true)
        resources.ApplyResources(Me.txtCustomerNameAra, "txtCustomerNameAra")
        Me.txtCustomerNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerNameAra.LinkedLabel = Me.lblCustomerNameAra
        Me.txtCustomerNameAra.MaximumValue = Nothing
        Me.txtCustomerNameAra.MinimumValue = Nothing
        Me.txtCustomerNameAra.Name = "txtCustomerNameAra"
        Me.txtCustomerNameAra.OldValue = Nothing
        Me.txtCustomerNameAra.ReadOnly = true
        Me.txtCustomerNameAra.ValueIsMandatory = true
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.ComputedValue = false
        Me.txtCustomerName.CustomFormat = Nothing
        Me.txtCustomerName.DataBoundControl = true
        Me.txtCustomerName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCustomerName, true)
        resources.ApplyResources(Me.txtCustomerName, "txtCustomerName")
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.LinkedLabel = Me.lblCustomerName
        Me.txtCustomerName.MaximumValue = Nothing
        Me.txtCustomerName.MinimumValue = Nothing
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.OldValue = Nothing
        Me.txtCustomerName.ReadOnly = true
        Me.txtCustomerName.ValueIsMandatory = true
        '
        'lblCustomerName
        '
        Me.lblCustomerName.DisplayOnly = true
        Me.lblCustomerName.EditingMode = false
        resources.ApplyResources(Me.lblCustomerName, "lblCustomerName")
        Me.lblCustomerName.Name = "lblCustomerName"
        '
        'lblCustomerNameAra
        '
        Me.lblCustomerNameAra.DisplayOnly = true
        Me.lblCustomerNameAra.EditingMode = false
        resources.ApplyResources(Me.lblCustomerNameAra, "lblCustomerNameAra")
        Me.lblCustomerNameAra.Name = "lblCustomerNameAra"
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        resources.ApplyResources(Me.lblVatNumber, "lblVatNumber")
        Me.lblVatNumber.Name = "lblVatNumber"
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.BackColor = System.Drawing.Color.White
        Me.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerCode.ComputedValue = false
        Me.txtCustomerCode.CustomFormat = Nothing
        Me.txtCustomerCode.DataBoundControl = true
        Me.txtCustomerCode.EditingMode = false
        resources.ApplyResources(Me.txtCustomerCode, "txtCustomerCode")
        Me.txtCustomerCode.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerCode.LinkedLabel = Me.lblCustomerCode
        Me.txtCustomerCode.MaximumValue = Nothing
        Me.txtCustomerCode.MinimumValue = Nothing
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.OldValue = Nothing
        Me.txtCustomerCode.ReadOnly = true
        Me.txtCustomerCode.ValueIsMandatory = true
        '
        'lblCustomerCode
        '
        Me.lblCustomerCode.DisplayOnly = true
        Me.lblCustomerCode.EditingMode = false
        resources.ApplyResources(Me.lblCustomerCode, "lblCustomerCode")
        Me.lblCustomerCode.Name = "lblCustomerCode"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.TabStop = false
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
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
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtVatNumber, true)
        resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Nothing
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        '
        'cacCountryCode
        '
        Me.cacCountryCode.BackColor = System.Drawing.Color.White
        Me.cacCountryCode.ChangingSearchValueOnly = false
        Me.cacCountryCode.CurrentSearchTerm = ""
        Me.cacCountryCode.DefaultValue = Nothing
        Me.cacCountryCode.DisplayMember = "Name"
        Me.cacCountryCode.DropDownHeight = 1
        Me.cacCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacCountryCode.EditingMode = false
        Me.cacCountryCode.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacCountryCode, true)
        resources.ApplyResources(Me.cacCountryCode, "cacCountryCode")
        Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
        Me.cacCountryCode.FormattingEnabled = true
        Me.cacCountryCode.HideWhenNotEditingOrAdding = false
        Me.cacCountryCode.LinkedLabel = Me.lblCountryCode
        Me.cacCountryCode.Name = "cacCountryCode"
        Me.cacCountryCode.OldValue = 0
        Me.cacCountryCode.OriginalDataSource = Nothing
        Me.cacCountryCode.OriginalList = Nothing
        Me.cacCountryCode.OverrideDropDownStyleList = false
        Me.cacCountryCode.PreviousSearchTerm = Nothing
        Me.cacCountryCode.PreviousSelectedIndex = -1
        Me.cacCountryCode.PropertySelector = Nothing
        Me.cacCountryCode.ReadOnlyCombo = false
        Me.cacCountryCode.SearchAnywhere = false
        Me.cacCountryCode.SecurityKey = ""
        Me.cacCountryCode.SuggestBoxHeight = 200
        Me.cacCountryCode.SuggestListOrderRule = Nothing
        Me.cacCountryCode.TextToSearch = Nothing
        Me.cacCountryCode.ValueIsMandatory = false
        Me.cacCountryCode.ValueIsNullable = false
        Me.cacCountryCode.ValueIsNumeric = false
        Me.cacCountryCode.ValueMember = "Code"
        '
        'cacBankIdNo
        '
        Me.cacBankIdNo.BackColor = System.Drawing.Color.White
        Me.cacBankIdNo.ChangingSearchValueOnly = false
        Me.cacBankIdNo.CurrentSearchTerm = ""
        Me.cacBankIdNo.DefaultValue = Nothing
        Me.cacBankIdNo.DisplayMember = "Name"
        Me.cacBankIdNo.DropDownHeight = 1
        Me.cacBankIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacBankIdNo.EditingMode = false
        Me.cacBankIdNo.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacBankIdNo, true)
        resources.ApplyResources(Me.cacBankIdNo, "cacBankIdNo")
        Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacBankIdNo.FormattingEnabled = true
        Me.cacBankIdNo.HideWhenNotEditingOrAdding = false
        Me.cacBankIdNo.LinkedLabel = Nothing
        Me.cacBankIdNo.Name = "cacBankIdNo"
        Me.cacBankIdNo.OldValue = 0
        Me.cacBankIdNo.OriginalDataSource = Nothing
        Me.cacBankIdNo.OriginalList = Nothing
        Me.cacBankIdNo.OverrideDropDownStyleList = false
        Me.cacBankIdNo.PreviousSearchTerm = Nothing
        Me.cacBankIdNo.PreviousSelectedIndex = -1
        Me.cacBankIdNo.PropertySelector = Nothing
        Me.cacBankIdNo.ReadOnlyCombo = false
        Me.cacBankIdNo.SearchAnywhere = false
        Me.cacBankIdNo.SuggestBoxHeight = 200
        Me.cacBankIdNo.SuggestListOrderRule = Nothing
        Me.cacBankIdNo.TextToSearch = Nothing
        Me.cacBankIdNo.ValueIsMandatory = false
        Me.cacBankIdNo.ValueIsNullable = false
        Me.cacBankIdNo.ValueIsNumeric = false
        Me.cacBankIdNo.ValueMember = "IdNo"
        '
        'cacRevAccountIdNo
        '
        Me.cacRevAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacRevAccountIdNo.ChangingSearchValueOnly = false
        Me.cacRevAccountIdNo.CurrentSearchTerm = ""
        Me.cacRevAccountIdNo.DefaultValue = Nothing
        Me.cacRevAccountIdNo.DisplayMember = "Name"
        Me.cacRevAccountIdNo.DropDownHeight = 1
        Me.cacRevAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacRevAccountIdNo.EditingMode = false
        Me.cacRevAccountIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cacRevAccountIdNo, "cacRevAccountIdNo")
        Me.cacRevAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacRevAccountIdNo.FormattingEnabled = true
        Me.cacRevAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacRevAccountIdNo.LinkedLabel = Nothing
        Me.cacRevAccountIdNo.Name = "cacRevAccountIdNo"
        Me.cacRevAccountIdNo.OldValue = 0
        Me.cacRevAccountIdNo.OriginalDataSource = Nothing
        Me.cacRevAccountIdNo.OriginalList = Nothing
        Me.cacRevAccountIdNo.OverrideDropDownStyleList = false
        Me.cacRevAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacRevAccountIdNo.PreviousSelectedIndex = -1
        Me.cacRevAccountIdNo.PropertySelector = Nothing
        Me.cacRevAccountIdNo.ReadOnlyCombo = false
        Me.cacRevAccountIdNo.SearchAnywhere = false
        Me.cacRevAccountIdNo.SuggestBoxHeight = 200
        Me.cacRevAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacRevAccountIdNo.TextToSearch = Nothing
        Me.cacRevAccountIdNo.ValueIsMandatory = false
        Me.cacRevAccountIdNo.ValueIsNullable = false
        Me.cacRevAccountIdNo.ValueIsNumeric = false
        Me.cacRevAccountIdNo.ValueMember = "IdNo"
        '
        'cacArAccountIdNo
        '
        Me.cacArAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacArAccountIdNo.ChangingSearchValueOnly = false
        Me.cacArAccountIdNo.CurrentSearchTerm = ""
        Me.cacArAccountIdNo.DefaultValue = Nothing
        Me.cacArAccountIdNo.DisplayMember = "Name"
        Me.cacArAccountIdNo.DropDownHeight = 1
        Me.cacArAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacArAccountIdNo.EditingMode = false
        Me.cacArAccountIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cacArAccountIdNo, "cacArAccountIdNo")
        Me.cacArAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacArAccountIdNo.FormattingEnabled = true
        Me.cacArAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacArAccountIdNo.LinkedLabel = Nothing
        Me.cacArAccountIdNo.Name = "cacArAccountIdNo"
        Me.cacArAccountIdNo.OldValue = 0
        Me.cacArAccountIdNo.OriginalDataSource = Nothing
        Me.cacArAccountIdNo.OriginalList = Nothing
        Me.cacArAccountIdNo.OverrideDropDownStyleList = false
        Me.cacArAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacArAccountIdNo.PreviousSelectedIndex = -1
        Me.cacArAccountIdNo.PropertySelector = Nothing
        Me.cacArAccountIdNo.ReadOnlyCombo = false
        Me.cacArAccountIdNo.SearchAnywhere = false
        Me.cacArAccountIdNo.SuggestBoxHeight = 200
        Me.cacArAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacArAccountIdNo.TextToSearch = Nothing
        Me.cacArAccountIdNo.ValueIsMandatory = false
        Me.cacArAccountIdNo.ValueIsNullable = false
        Me.cacArAccountIdNo.ValueIsNumeric = false
        Me.cacArAccountIdNo.ValueMember = "IdNo"
        '
        'cacPaymentMethod
        '
        Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
        Me.cacPaymentMethod.ChangingSearchValueOnly = false
        Me.cacPaymentMethod.CurrentSearchTerm = ""
        Me.cacPaymentMethod.DefaultValue = Nothing
        Me.cacPaymentMethod.DisplayMember = "Name"
        Me.cacPaymentMethod.DropDownHeight = 1
        Me.cacPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacPaymentMethod.EditingMode = false
        Me.cacPaymentMethod.FilterRule = Nothing
        resources.ApplyResources(Me.cacPaymentMethod, "cacPaymentMethod")
        Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.cacPaymentMethod.FormattingEnabled = true
        Me.cacPaymentMethod.HideWhenNotEditingOrAdding = false
        Me.cacPaymentMethod.LinkedLabel = Nothing
        Me.cacPaymentMethod.Name = "cacPaymentMethod"
        Me.cacPaymentMethod.OldValue = 0
        Me.cacPaymentMethod.OriginalDataSource = Nothing
        Me.cacPaymentMethod.OriginalList = Nothing
        Me.cacPaymentMethod.OverrideDropDownStyleList = false
        Me.cacPaymentMethod.PreviousSearchTerm = Nothing
        Me.cacPaymentMethod.PreviousSelectedIndex = -1
        Me.cacPaymentMethod.PropertySelector = Nothing
        Me.cacPaymentMethod.ReadOnlyCombo = false
        Me.cacPaymentMethod.SearchAnywhere = false
        Me.cacPaymentMethod.SuggestBoxHeight = 200
        Me.cacPaymentMethod.SuggestListOrderRule = Nothing
        Me.cacPaymentMethod.TextToSearch = Nothing
        Me.cacPaymentMethod.ValueIsMandatory = false
        Me.cacPaymentMethod.ValueIsNullable = false
        Me.cacPaymentMethod.ValueIsNumeric = false
        Me.cacPaymentMethod.ValueMember = "Code"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'cacDiscountSchemeIdNo
        '
        Me.cacDiscountSchemeIdNo.BackColor = System.Drawing.Color.White
        Me.cacDiscountSchemeIdNo.ChangingSearchValueOnly = false
        Me.cacDiscountSchemeIdNo.CurrentSearchTerm = ""
        Me.cacDiscountSchemeIdNo.DefaultValue = Nothing
        Me.cacDiscountSchemeIdNo.DisplayMember = "Name"
        Me.cacDiscountSchemeIdNo.DropDownHeight = 1
        Me.cacDiscountSchemeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacDiscountSchemeIdNo.EditingMode = false
        Me.cacDiscountSchemeIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cacDiscountSchemeIdNo, "cacDiscountSchemeIdNo")
        Me.cacDiscountSchemeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacDiscountSchemeIdNo.FormattingEnabled = true
        Me.cacDiscountSchemeIdNo.HideWhenNotEditingOrAdding = false
        Me.cacDiscountSchemeIdNo.LinkedLabel = Nothing
        Me.cacDiscountSchemeIdNo.Name = "cacDiscountSchemeIdNo"
        Me.cacDiscountSchemeIdNo.OldValue = 0
        Me.cacDiscountSchemeIdNo.OriginalDataSource = Nothing
        Me.cacDiscountSchemeIdNo.OriginalList = Nothing
        Me.cacDiscountSchemeIdNo.OverrideDropDownStyleList = false
        Me.cacDiscountSchemeIdNo.PreviousSearchTerm = Nothing
        Me.cacDiscountSchemeIdNo.PreviousSelectedIndex = -1
        Me.cacDiscountSchemeIdNo.PropertySelector = Nothing
        Me.cacDiscountSchemeIdNo.ReadOnlyCombo = false
        Me.cacDiscountSchemeIdNo.SearchAnywhere = false
        Me.cacDiscountSchemeIdNo.SuggestBoxHeight = 200
        Me.cacDiscountSchemeIdNo.SuggestListOrderRule = Nothing
        Me.cacDiscountSchemeIdNo.TextToSearch = Nothing
        Me.cacDiscountSchemeIdNo.ValueIsMandatory = false
        Me.cacDiscountSchemeIdNo.ValueIsNullable = false
        Me.cacDiscountSchemeIdNo.ValueIsNumeric = false
        Me.cacDiscountSchemeIdNo.ValueMember = "IdNo"
        '
        'dtpDateAccountOpen
        '
        Me.dtpDateAccountOpen.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateAccountOpen.DefaultValue = Nothing
        Me.dtpDateAccountOpen.DisplayOnly = false
        Me.dtpDateAccountOpen.DtpDefaultValue = Nothing
        Me.dtpDateAccountOpen.EditingMode = false
        Me.dtpDateAccountOpen.EditsAllowed = false
        Me.floDataDisplay.SetFlowBreak(Me.dtpDateAccountOpen, true)
        resources.ApplyResources(Me.dtpDateAccountOpen, "dtpDateAccountOpen")
        Me.dtpDateAccountOpen.ForeColor = System.Drawing.Color.Black
        Me.dtpDateAccountOpen.LinkedLabel = Nothing
        Me.dtpDateAccountOpen.Name = "dtpDateAccountOpen"
        Me.dtpDateAccountOpen.ReadOnlyDp = false
        Me.dtpDateAccountOpen.SecurityKey = Nothing
        Me.dtpDateAccountOpen.ShowLongDate = false
        Me.dtpDateAccountOpen.ShowTime = false
        Me.dtpDateAccountOpen.TargetCalendar = CType(resources.GetObject("dtpDateAccountOpen.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateAccountOpen.Value = Nothing
        Me.dtpDateAccountOpen.ValueIsMandatory = false
        Me.dtpDateAccountOpen.ValueIsNullable = false
        '
        'cacAccountStatus
        '
        Me.cacAccountStatus.BackColor = System.Drawing.Color.White
        Me.cacAccountStatus.ChangingSearchValueOnly = false
        Me.cacAccountStatus.CurrentSearchTerm = ""
        Me.cacAccountStatus.DefaultValue = Nothing
        Me.cacAccountStatus.DisplayMember = "Name"
        Me.cacAccountStatus.DropDownHeight = 1
        Me.cacAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacAccountStatus.EditingMode = false
        Me.cacAccountStatus.FilterRule = Nothing
        resources.ApplyResources(Me.cacAccountStatus, "cacAccountStatus")
        Me.cacAccountStatus.ForeColor = System.Drawing.Color.Black
        Me.cacAccountStatus.FormattingEnabled = true
        Me.cacAccountStatus.HideWhenNotEditingOrAdding = false
        Me.cacAccountStatus.LinkedLabel = Nothing
        Me.cacAccountStatus.Name = "cacAccountStatus"
        Me.cacAccountStatus.OldValue = 0
        Me.cacAccountStatus.OriginalDataSource = Nothing
        Me.cacAccountStatus.OriginalList = Nothing
        Me.cacAccountStatus.OverrideDropDownStyleList = false
        Me.cacAccountStatus.PreviousSearchTerm = Nothing
        Me.cacAccountStatus.PreviousSelectedIndex = -1
        Me.cacAccountStatus.PropertySelector = Nothing
        Me.cacAccountStatus.ReadOnlyCombo = false
        Me.cacAccountStatus.SearchAnywhere = false
        Me.cacAccountStatus.SuggestBoxHeight = 200
        Me.cacAccountStatus.SuggestListOrderRule = Nothing
        Me.cacAccountStatus.TextToSearch = Nothing
        Me.cacAccountStatus.ValueIsMandatory = false
        Me.cacAccountStatus.ValueIsNullable = false
        Me.cacAccountStatus.ValueIsNumeric = false
        Me.cacAccountStatus.ValueMember = "Code"
        '
        'lblActive
        '
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        resources.ApplyResources(Me.lblActive, "lblActive")
        Me.lblActive.Name = "lblActive"
        '
        'chkActive
        '
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.chkActive.AutoCheck = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.LinkedLabel = Nothing
        Me.chkActive.Name = "chkActive"
        Me.chkActive.OldValue = Nothing
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'CustomerEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "CustomerEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
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
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblActive As CLabel
        Friend WithEvents dtpDateAccountOpen As CCustomDateTimePicker
        Friend WithEvents cacCountryCode As CaComboBox
        Friend WithEvents _localizableMessage1 As LocalizableMessage
        Friend WithEvents cacBankIdNo As CaComboBox
        Friend WithEvents cacRevAccountIdNo As CaComboBox
        Friend WithEvents cacArAccountIdNo As CaComboBox
        Friend WithEvents cacPaymentMethod As CaComboBox
        Friend WithEvents cacDiscountSchemeIdNo As CaComboBox
        Friend WithEvents cacAccountStatus As CaComboBox
    End Class
End Namespace