Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SupplierEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupplierEntryTv))
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Me._MBSupplierCannotBeParentToItself = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBParentWithChildrenChangedDisallowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBMainAccountNotEditable = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSettlementDueDays = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblApAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblExpAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.txtSupplierNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtSupplierName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblSupplierNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacExpAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacApAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.dtpDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.cacAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'LocalizableContent1
        '
        LocalizableContent1.MessageBoxes.Add(Me._MBSupplierCannotBeParentToItself)
        LocalizableContent1.MessageBoxes.Add(Me._MBParentWithChildrenChangedDisallowed)
        LocalizableContent1.MessageBoxes.Add(Me._MBMainAccountNotEditable)
        LocalizableContent1.Messages.Add(Me._MSGMandatoryFields)
        '
        '_MBParentWithChildrenChangedDisallowed
        '
        resources.ApplyResources(Me._MBParentWithChildrenChangedDisallowed, "_MBParentWithChildrenChangedDisallowed")
        '
        '_MBMainAccountNotEditable
        '
        resources.ApplyResources(Me._MBMainAccountNotEditable, "_MBMainAccountNotEditable")
        '
        '_MSGMandatoryFields
        '
        resources.ApplyResources(Me._MSGMandatoryFields, "_MSGMandatoryFields")
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtOpeningBalance.BegFindValue = Nothing
        Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpeningBalance.ComputedValue = false
        Me.txtOpeningBalance.CustomFormat = Nothing
        Me.txtOpeningBalance.DataBoundControl = true
        Me.txtOpeningBalance.EditingMode = false
        Me.txtOpeningBalance.EndFindValue = Nothing
        Me.txtOpeningBalance.FieldDescription = Nothing
        Me.txtOpeningBalance.FieldName = Nothing
        Me.txtOpeningBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtOpeningBalance.FindEnabled = true
        resources.ApplyResources(Me.txtOpeningBalance, "txtOpeningBalance")
        Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtOpeningBalance.MaximumValue = Nothing
        Me.txtOpeningBalance.MinimumValue = Nothing
        Me.txtOpeningBalance.Name = "txtOpeningBalance"
        Me.txtOpeningBalance.OldValue = Nothing
        Me.txtOpeningBalance.ReadOnly = true
        Me.txtOpeningBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtOpeningBalance.ValueIsNumeric = true
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.DisplayOnly = true
        Me.lblOpeningBalance.EditingMode = false
        resources.ApplyResources(Me.lblOpeningBalance, "lblOpeningBalance")
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        resources.ApplyResources(Me.CLabel3, "CLabel3")
        Me.CLabel3.Name = "CLabel3"
        '
        'txtSettlementDiscount
        '
        Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
        Me.txtSettlementDiscount.BegFindValue = Nothing
        Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDiscount.ComputedValue = false
        Me.txtSettlementDiscount.CustomFormat = Nothing
        Me.txtSettlementDiscount.DataBoundControl = true
        Me.txtSettlementDiscount.EditingMode = false
        Me.txtSettlementDiscount.EndFindValue = Nothing
        Me.txtSettlementDiscount.FieldDescription = Nothing
        Me.txtSettlementDiscount.FieldName = Nothing
        Me.txtSettlementDiscount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSettlementDiscount.FindEnabled = true
        resources.ApplyResources(Me.txtSettlementDiscount, "txtSettlementDiscount")
        Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDiscount.IgnoreNullCheck = true
        Me.txtSettlementDiscount.LinkedLabel = Me.lblSettlementDiscount
        Me.txtSettlementDiscount.MaximumValue = Nothing
        Me.txtSettlementDiscount.MinimumValue = Nothing
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.ReadOnly = true
        Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSettlementDiscount.ValueIsNumeric = true
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
        Me.txtSettlementDueDays.BegFindValue = Nothing
        Me.txtSettlementDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDueDays.ComputedValue = false
        Me.txtSettlementDueDays.CustomFormat = Nothing
        Me.txtSettlementDueDays.DataBoundControl = true
        Me.txtSettlementDueDays.EditingMode = false
        Me.txtSettlementDueDays.EndFindValue = Nothing
        Me.txtSettlementDueDays.FieldDescription = Nothing
        Me.txtSettlementDueDays.FieldName = Nothing
        Me.txtSettlementDueDays.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSettlementDueDays.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSettlementDueDays, true)
        resources.ApplyResources(Me.txtSettlementDueDays, "txtSettlementDueDays")
        Me.txtSettlementDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDueDays.IgnoreNullCheck = true
        Me.txtSettlementDueDays.LinkedLabel = Me.lblSettlementDueDays
        Me.txtSettlementDueDays.MaximumValue = Nothing
        Me.txtSettlementDueDays.MinimumValue = Nothing
        Me.txtSettlementDueDays.Name = "txtSettlementDueDays"
        Me.txtSettlementDueDays.OldValue = Nothing
        Me.txtSettlementDueDays.ReadOnly = true
        Me.txtSettlementDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'lblSettlementDueDays
        '
        Me.lblSettlementDueDays.DisplayOnly = true
        Me.lblSettlementDueDays.EditingMode = false
        resources.ApplyResources(Me.lblSettlementDueDays, "lblSettlementDueDays")
        Me.lblSettlementDueDays.Name = "lblSettlementDueDays"
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
        Me.txtPaymentDueDays.BegFindValue = Nothing
        Me.txtPaymentDueDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentDueDays.ComputedValue = false
        Me.txtPaymentDueDays.CustomFormat = Nothing
        Me.txtPaymentDueDays.DataBoundControl = true
        Me.txtPaymentDueDays.EditingMode = false
        Me.txtPaymentDueDays.EndFindValue = Nothing
        Me.txtPaymentDueDays.FieldDescription = Nothing
        Me.txtPaymentDueDays.FieldName = Nothing
        Me.txtPaymentDueDays.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPaymentDueDays.FindEnabled = true
        resources.ApplyResources(Me.txtPaymentDueDays, "txtPaymentDueDays")
        Me.txtPaymentDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentDueDays.IgnoreNullCheck = true
        Me.txtPaymentDueDays.LinkedLabel = Me.lblPaymentDueDays
        Me.txtPaymentDueDays.MaximumValue = Nothing
        Me.txtPaymentDueDays.MinimumValue = Nothing
        Me.txtPaymentDueDays.Name = "txtPaymentDueDays"
        Me.txtPaymentDueDays.OldValue = Nothing
        Me.txtPaymentDueDays.ReadOnly = true
        Me.txtPaymentDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtCreditLimit.BegFindValue = Nothing
        Me.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditLimit.ComputedValue = false
        Me.txtCreditLimit.CustomFormat = Nothing
        Me.txtCreditLimit.DataBoundControl = true
        Me.txtCreditLimit.EditingMode = false
        Me.txtCreditLimit.EndFindValue = Nothing
        Me.txtCreditLimit.FieldDescription = Nothing
        Me.txtCreditLimit.FieldName = Nothing
        Me.txtCreditLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCreditLimit.FindEnabled = true
        resources.ApplyResources(Me.txtCreditLimit, "txtCreditLimit")
        Me.txtCreditLimit.ForeColor = System.Drawing.Color.Black
        Me.txtCreditLimit.LinkedLabel = Me.lblCreditLimit
        Me.txtCreditLimit.MaximumValue = Nothing
        Me.txtCreditLimit.MinimumValue = Nothing
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.OldValue = Nothing
        Me.txtCreditLimit.ReadOnly = true
        Me.txtCreditLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCreditLimit.ValueIsNumeric = true
        '
        'lblCreditLimit
        '
        Me.lblCreditLimit.DisplayOnly = true
        Me.lblCreditLimit.EditingMode = false
        resources.ApplyResources(Me.lblCreditLimit, "lblCreditLimit")
        Me.lblCreditLimit.Name = "lblCreditLimit"
        '
        'lblApAccountIdNo
        '
        Me.lblApAccountIdNo.DisplayOnly = true
        Me.lblApAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblApAccountIdNo, "lblApAccountIdNo")
        Me.lblApAccountIdNo.Name = "lblApAccountIdNo"
        '
        'lblExpAccountIdNo
        '
        Me.lblExpAccountIdNo.DisplayOnly = true
        Me.lblExpAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblExpAccountIdNo, "lblExpAccountIdNo")
        Me.lblExpAccountIdNo.Name = "lblExpAccountIdNo"
        '
        'txtIban
        '
        Me.txtIban.BackColor = System.Drawing.Color.White
        Me.txtIban.BegFindValue = Nothing
        Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIban.ComputedValue = false
        Me.txtIban.CustomFormat = Nothing
        Me.txtIban.DataBoundControl = true
        Me.txtIban.EditingMode = false
        Me.txtIban.EndFindValue = Nothing
        Me.txtIban.FieldDescription = Nothing
        Me.txtIban.FieldName = Nothing
        Me.txtIban.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtIban.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtIban, true)
        resources.ApplyResources(Me.txtIban, "txtIban")
        Me.txtIban.ForeColor = System.Drawing.Color.Black
        Me.txtIban.LinkedLabel = Me.lblIban
        Me.txtIban.MaximumValue = Nothing
        Me.txtIban.MinimumValue = Nothing
        Me.txtIban.Name = "txtIban"
        Me.txtIban.OldValue = Nothing
        Me.txtIban.ReadOnly = true
        Me.txtIban.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtBankAccountNo.BegFindValue = Nothing
        Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccountNo.ComputedValue = false
        Me.txtBankAccountNo.CustomFormat = Nothing
        Me.txtBankAccountNo.DataBoundControl = true
        Me.txtBankAccountNo.EditingMode = false
        Me.txtBankAccountNo.EndFindValue = Nothing
        Me.txtBankAccountNo.FieldDescription = Nothing
        Me.txtBankAccountNo.FieldName = Nothing
        Me.txtBankAccountNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBankAccountNo.FindEnabled = true
        resources.ApplyResources(Me.txtBankAccountNo, "txtBankAccountNo")
        Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
        Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
        Me.txtBankAccountNo.MaximumValue = Nothing
        Me.txtBankAccountNo.MinimumValue = Nothing
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.OldValue = Nothing
        Me.txtBankAccountNo.ReadOnly = true
        Me.txtBankAccountNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtCrNumber.BegFindValue = Nothing
        Me.txtCrNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCrNumber.ComputedValue = false
        Me.txtCrNumber.CustomFormat = Nothing
        Me.txtCrNumber.DataBoundControl = true
        Me.txtCrNumber.EditingMode = false
        Me.txtCrNumber.EndFindValue = Nothing
        Me.txtCrNumber.FieldDescription = Nothing
        Me.txtCrNumber.FieldName = Nothing
        Me.txtCrNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCrNumber.FindEnabled = true
        resources.ApplyResources(Me.txtCrNumber, "txtCrNumber")
        Me.txtCrNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCrNumber.LinkedLabel = Me.lblCrNumber
        Me.txtCrNumber.MaximumValue = Nothing
        Me.txtCrNumber.MinimumValue = Nothing
        Me.txtCrNumber.Name = "txtCrNumber"
        Me.txtCrNumber.OldValue = Nothing
        Me.txtCrNumber.ReadOnly = true
        Me.txtCrNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtWebsite.BegFindValue = Nothing
        Me.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWebsite.ComputedValue = false
        Me.txtWebsite.CustomFormat = Nothing
        Me.txtWebsite.DataBoundControl = true
        Me.txtWebsite.EditingMode = false
        Me.txtWebsite.EndFindValue = Nothing
        Me.txtWebsite.FieldDescription = Nothing
        Me.txtWebsite.FieldName = Nothing
        Me.txtWebsite.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtWebsite.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtWebsite, true)
        resources.ApplyResources(Me.txtWebsite, "txtWebsite")
        Me.txtWebsite.ForeColor = System.Drawing.Color.Black
        Me.txtWebsite.LinkedLabel = Me.lblWebsite
        Me.txtWebsite.MaximumValue = Nothing
        Me.txtWebsite.MinimumValue = Nothing
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.OldValue = Nothing
        Me.txtWebsite.ReadOnly = true
        Me.txtWebsite.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtEmail.BegFindValue = Nothing
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.ComputedValue = false
        Me.txtEmail.CustomFormat = Nothing
        Me.txtEmail.DataBoundControl = true
        Me.txtEmail.EditingMode = false
        Me.txtEmail.EndFindValue = Nothing
        Me.txtEmail.FieldDescription = Nothing
        Me.txtEmail.FieldName = Nothing
        Me.txtEmail.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEmail.FindEnabled = true
        resources.ApplyResources(Me.txtEmail, "txtEmail")
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.LinkedLabel = Me.lblEmail
        Me.txtEmail.MaximumValue = Nothing
        Me.txtEmail.MinimumValue = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OldValue = Nothing
        Me.txtEmail.ReadOnly = true
        Me.txtEmail.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtMobile.BegFindValue = Nothing
        Me.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMobile.ComputedValue = false
        Me.txtMobile.CustomFormat = Nothing
        Me.txtMobile.DataBoundControl = true
        Me.txtMobile.EditingMode = false
        Me.txtMobile.EndFindValue = Nothing
        Me.txtMobile.FieldDescription = Nothing
        Me.txtMobile.FieldName = Nothing
        Me.txtMobile.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMobile.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtMobile, true)
        resources.ApplyResources(Me.txtMobile, "txtMobile")
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.LinkedLabel = Me.lblMobile
        Me.txtMobile.MaximumValue = Nothing
        Me.txtMobile.MinimumValue = Nothing
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.OldValue = Nothing
        Me.txtMobile.ReadOnly = true
        Me.txtMobile.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtFax.BegFindValue = Nothing
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.ComputedValue = false
        Me.txtFax.CustomFormat = Nothing
        Me.txtFax.DataBoundControl = true
        Me.txtFax.EditingMode = false
        Me.txtFax.EndFindValue = Nothing
        Me.txtFax.FieldDescription = Nothing
        Me.txtFax.FieldName = Nothing
        Me.txtFax.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtFax.FindEnabled = true
        resources.ApplyResources(Me.txtFax, "txtFax")
        Me.txtFax.ForeColor = System.Drawing.Color.Black
        Me.txtFax.LinkedLabel = Me.lblFax
        Me.txtFax.MaximumValue = Nothing
        Me.txtFax.MinimumValue = Nothing
        Me.txtFax.Name = "txtFax"
        Me.txtFax.OldValue = Nothing
        Me.txtFax.ReadOnly = true
        Me.txtFax.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtPhone2.BegFindValue = Nothing
        Me.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone2.ComputedValue = false
        Me.txtPhone2.CustomFormat = Nothing
        Me.txtPhone2.DataBoundControl = true
        Me.txtPhone2.EditingMode = false
        Me.txtPhone2.EndFindValue = Nothing
        Me.txtPhone2.FieldDescription = Nothing
        Me.txtPhone2.FieldName = Nothing
        Me.txtPhone2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPhone2.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtPhone2, true)
        resources.ApplyResources(Me.txtPhone2, "txtPhone2")
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.LinkedLabel = Me.lblPhone2
        Me.txtPhone2.MaximumValue = Nothing
        Me.txtPhone2.MinimumValue = Nothing
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.OldValue = Nothing
        Me.txtPhone2.ReadOnly = true
        Me.txtPhone2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtPhone1.BegFindValue = Nothing
        Me.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone1.ComputedValue = false
        Me.txtPhone1.CustomFormat = Nothing
        Me.txtPhone1.DataBoundControl = true
        Me.txtPhone1.EditingMode = false
        Me.txtPhone1.EndFindValue = Nothing
        Me.txtPhone1.FieldDescription = Nothing
        Me.txtPhone1.FieldName = Nothing
        Me.txtPhone1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPhone1.FindEnabled = true
        resources.ApplyResources(Me.txtPhone1, "txtPhone1")
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.LinkedLabel = Me.lblPhone1
        Me.txtPhone1.MaximumValue = Nothing
        Me.txtPhone1.MinimumValue = Nothing
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.OldValue = Nothing
        Me.txtPhone1.ReadOnly = true
        Me.txtPhone1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtZipCode.BegFindValue = Nothing
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.ComputedValue = false
        Me.txtZipCode.CustomFormat = Nothing
        Me.txtZipCode.DataBoundControl = true
        Me.txtZipCode.EditingMode = false
        Me.txtZipCode.EndFindValue = Nothing
        Me.txtZipCode.FieldDescription = Nothing
        Me.txtZipCode.FieldName = Nothing
        Me.txtZipCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtZipCode.FindEnabled = true
        resources.ApplyResources(Me.txtZipCode, "txtZipCode")
        Me.txtZipCode.ForeColor = System.Drawing.Color.Black
        Me.txtZipCode.LinkedLabel = Me.lblZipCode
        Me.txtZipCode.MaximumValue = Nothing
        Me.txtZipCode.MinimumValue = Nothing
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.OldValue = Nothing
        Me.txtZipCode.ReadOnly = true
        Me.txtZipCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtPoBox.BegFindValue = Nothing
        Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPoBox.ComputedValue = false
        Me.txtPoBox.CustomFormat = Nothing
        Me.txtPoBox.DataBoundControl = true
        Me.txtPoBox.EditingMode = false
        Me.txtPoBox.EndFindValue = Nothing
        Me.txtPoBox.FieldDescription = Nothing
        Me.txtPoBox.FieldName = Nothing
        Me.txtPoBox.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPoBox.FindEnabled = true
        resources.ApplyResources(Me.txtPoBox, "txtPoBox")
        Me.txtPoBox.ForeColor = System.Drawing.Color.Black
        Me.txtPoBox.LinkedLabel = Me.lblPoBox
        Me.txtPoBox.MaximumValue = Nothing
        Me.txtPoBox.MinimumValue = Nothing
        Me.txtPoBox.Name = "txtPoBox"
        Me.txtPoBox.OldValue = Nothing
        Me.txtPoBox.ReadOnly = true
        Me.txtPoBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtProvinceState.BegFindValue = Nothing
        Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvinceState.ComputedValue = false
        Me.txtProvinceState.CustomFormat = Nothing
        Me.txtProvinceState.DataBoundControl = true
        Me.txtProvinceState.EditingMode = false
        Me.txtProvinceState.EndFindValue = Nothing
        Me.txtProvinceState.FieldDescription = Nothing
        Me.txtProvinceState.FieldName = Nothing
        Me.txtProvinceState.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtProvinceState.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtProvinceState, true)
        resources.ApplyResources(Me.txtProvinceState, "txtProvinceState")
        Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
        Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
        Me.txtProvinceState.MaximumValue = Nothing
        Me.txtProvinceState.MinimumValue = Nothing
        Me.txtProvinceState.Name = "txtProvinceState"
        Me.txtProvinceState.OldValue = Nothing
        Me.txtProvinceState.ReadOnly = true
        Me.txtProvinceState.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtTownCity.BegFindValue = Nothing
        Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTownCity.ComputedValue = false
        Me.txtTownCity.CustomFormat = Nothing
        Me.txtTownCity.DataBoundControl = true
        Me.txtTownCity.EditingMode = false
        Me.txtTownCity.EndFindValue = Nothing
        Me.txtTownCity.FieldDescription = Nothing
        Me.txtTownCity.FieldName = Nothing
        Me.txtTownCity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTownCity.FindEnabled = true
        resources.ApplyResources(Me.txtTownCity, "txtTownCity")
        Me.txtTownCity.ForeColor = System.Drawing.Color.Black
        Me.txtTownCity.LinkedLabel = Me.lblTownCity
        Me.txtTownCity.MaximumValue = Nothing
        Me.txtTownCity.MinimumValue = Nothing
        Me.txtTownCity.Name = "txtTownCity"
        Me.txtTownCity.OldValue = Nothing
        Me.txtTownCity.ReadOnly = true
        Me.txtTownCity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtDistrict.BegFindValue = Nothing
        Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrict.ComputedValue = false
        Me.txtDistrict.CustomFormat = Nothing
        Me.txtDistrict.DataBoundControl = true
        Me.txtDistrict.EditingMode = false
        Me.txtDistrict.EndFindValue = Nothing
        Me.txtDistrict.FieldDescription = Nothing
        Me.txtDistrict.FieldName = Nothing
        Me.txtDistrict.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDistrict.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtDistrict, true)
        resources.ApplyResources(Me.txtDistrict, "txtDistrict")
        Me.txtDistrict.ForeColor = System.Drawing.Color.Black
        Me.txtDistrict.LinkedLabel = Me.lblDistrict
        Me.txtDistrict.MaximumValue = Nothing
        Me.txtDistrict.MinimumValue = Nothing
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.OldValue = Nothing
        Me.txtDistrict.ReadOnly = true
        Me.txtDistrict.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtStreet.BegFindValue = Nothing
        Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreet.ComputedValue = false
        Me.txtStreet.CustomFormat = Nothing
        Me.txtStreet.DataBoundControl = true
        Me.txtStreet.EditingMode = false
        Me.txtStreet.EndFindValue = Nothing
        Me.txtStreet.FieldDescription = Nothing
        Me.txtStreet.FieldName = Nothing
        Me.txtStreet.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtStreet.FindEnabled = true
        resources.ApplyResources(Me.txtStreet, "txtStreet")
        Me.txtStreet.ForeColor = System.Drawing.Color.Black
        Me.txtStreet.LinkedLabel = Me.lblStreet
        Me.txtStreet.MaximumValue = Nothing
        Me.txtStreet.MinimumValue = Nothing
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.OldValue = Nothing
        Me.txtStreet.ReadOnly = true
        Me.txtStreet.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtContactDesignation.BegFindValue = Nothing
        Me.txtContactDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactDesignation.ComputedValue = false
        Me.txtContactDesignation.CustomFormat = Nothing
        Me.txtContactDesignation.DataBoundControl = true
        Me.txtContactDesignation.EditingMode = false
        Me.txtContactDesignation.EndFindValue = Nothing
        Me.txtContactDesignation.FieldDescription = Nothing
        Me.txtContactDesignation.FieldName = Nothing
        Me.txtContactDesignation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtContactDesignation.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtContactDesignation, true)
        resources.ApplyResources(Me.txtContactDesignation, "txtContactDesignation")
        Me.txtContactDesignation.ForeColor = System.Drawing.Color.Black
        Me.txtContactDesignation.LinkedLabel = Me.lblContactDesignation
        Me.txtContactDesignation.MaximumValue = Nothing
        Me.txtContactDesignation.MinimumValue = Nothing
        Me.txtContactDesignation.Name = "txtContactDesignation"
        Me.txtContactDesignation.OldValue = Nothing
        Me.txtContactDesignation.ReadOnly = true
        Me.txtContactDesignation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
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
        Me.txtContactPerson.BegFindValue = Nothing
        Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactPerson.ComputedValue = false
        Me.txtContactPerson.CustomFormat = Nothing
        Me.txtContactPerson.DataBoundControl = true
        Me.txtContactPerson.EditingMode = false
        Me.txtContactPerson.EndFindValue = Nothing
        Me.txtContactPerson.FieldDescription = Nothing
        Me.txtContactPerson.FieldName = Nothing
        Me.txtContactPerson.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtContactPerson.FindEnabled = true
        resources.ApplyResources(Me.txtContactPerson, "txtContactPerson")
        Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
        Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
        Me.txtContactPerson.MaximumValue = Nothing
        Me.txtContactPerson.MinimumValue = Nothing
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.OldValue = Nothing
        Me.txtContactPerson.ReadOnly = true
        Me.txtContactPerson.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'lblContactPerson
        '
        Me.lblContactPerson.DisplayOnly = true
        Me.lblContactPerson.EditingMode = false
        resources.ApplyResources(Me.lblContactPerson, "lblContactPerson")
        Me.lblContactPerson.Name = "lblContactPerson"
        '
        'txtSupplierNameAra
        '
        Me.txtSupplierNameAra.BackColor = System.Drawing.Color.White
        Me.txtSupplierNameAra.BegFindValue = Nothing
        Me.txtSupplierNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierNameAra.ComputedValue = false
        Me.txtSupplierNameAra.CustomFormat = Nothing
        Me.txtSupplierNameAra.DataBoundControl = true
        Me.txtSupplierNameAra.EditingMode = false
        Me.txtSupplierNameAra.EndFindValue = Nothing
        Me.txtSupplierNameAra.EnglishControl = Me.txtSupplierName
        Me.txtSupplierNameAra.FieldDescription = Nothing
        Me.txtSupplierNameAra.FieldName = Nothing
        Me.txtSupplierNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSupplierNameAra.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSupplierNameAra, true)
        resources.ApplyResources(Me.txtSupplierNameAra, "txtSupplierNameAra")
        Me.txtSupplierNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierNameAra.LinkedLabel = Me.lblSupplierNameAra
        Me.txtSupplierNameAra.MaximumValue = Nothing
        Me.txtSupplierNameAra.MinimumValue = Nothing
        Me.txtSupplierNameAra.Name = "txtSupplierNameAra"
        Me.txtSupplierNameAra.OldValue = Nothing
        Me.txtSupplierNameAra.ReadOnly = true
        Me.txtSupplierNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierNameAra.ValueIsMandatory = true
        '
        'txtSupplierName
        '
        Me.txtSupplierName.BackColor = System.Drawing.Color.White
        Me.txtSupplierName.BegFindValue = Nothing
        Me.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierName.ComputedValue = false
        Me.txtSupplierName.CustomFormat = Nothing
        Me.txtSupplierName.DataBoundControl = true
        Me.txtSupplierName.EditingMode = false
        Me.txtSupplierName.EndFindValue = Nothing
        Me.txtSupplierName.FieldDescription = Nothing
        Me.txtSupplierName.FieldName = Nothing
        Me.txtSupplierName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSupplierName.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtSupplierName, true)
        resources.ApplyResources(Me.txtSupplierName, "txtSupplierName")
        Me.txtSupplierName.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierName.LinkedLabel = Me.lblSupplierName
        Me.txtSupplierName.MaximumValue = Nothing
        Me.txtSupplierName.MinimumValue = Nothing
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.OldValue = Nothing
        Me.txtSupplierName.ReadOnly = true
        Me.txtSupplierName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierName.ValueIsMandatory = true
        '
        'lblSupplierName
        '
        Me.lblSupplierName.DisplayOnly = true
        Me.lblSupplierName.EditingMode = false
        resources.ApplyResources(Me.lblSupplierName, "lblSupplierName")
        Me.lblSupplierName.Name = "lblSupplierName"
        '
        'lblSupplierNameAra
        '
        Me.lblSupplierNameAra.DisplayOnly = true
        Me.lblSupplierNameAra.EditingMode = false
        resources.ApplyResources(Me.lblSupplierNameAra, "lblSupplierNameAra")
        Me.lblSupplierNameAra.Name = "lblSupplierNameAra"
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        resources.ApplyResources(Me.lblVatNumber, "lblVatNumber")
        Me.lblVatNumber.Name = "lblVatNumber"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.BackColor = System.Drawing.Color.White
        Me.txtSupplierCode.BegFindValue = Nothing
        Me.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierCode.ComputedValue = false
        Me.txtSupplierCode.CustomFormat = Nothing
        Me.txtSupplierCode.DataBoundControl = true
        Me.txtSupplierCode.EditingMode = false
        Me.txtSupplierCode.EndFindValue = Nothing
        Me.txtSupplierCode.FieldDescription = Nothing
        Me.txtSupplierCode.FieldName = Nothing
        Me.txtSupplierCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSupplierCode.FindEnabled = true
        resources.ApplyResources(Me.txtSupplierCode, "txtSupplierCode")
        Me.txtSupplierCode.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierCode.LinkedLabel = Me.lblSupplierCode
        Me.txtSupplierCode.MaximumValue = Nothing
        Me.txtSupplierCode.MinimumValue = Nothing
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.OldValue = Nothing
        Me.txtSupplierCode.ReadOnly = true
        Me.txtSupplierCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierCode.ValueIsMandatory = true
        '
        'lblSupplierCode
        '
        Me.lblSupplierCode.DisplayOnly = true
        Me.lblSupplierCode.EditingMode = false
        resources.ApplyResources(Me.lblSupplierCode, "lblSupplierCode")
        Me.lblSupplierCode.Name = "lblSupplierCode"
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
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
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
        Me.floDataDisplay.Controls.Add(Me.lblSupplierCode)
        Me.floDataDisplay.Controls.Add(Me.txtSupplierCode)
        Me.floDataDisplay.Controls.Add(Me.lblVatNumber)
        Me.floDataDisplay.Controls.Add(Me.txtVatNumber)
        Me.floDataDisplay.Controls.Add(Me.lblSupplierName)
        Me.floDataDisplay.Controls.Add(Me.txtSupplierName)
        Me.floDataDisplay.Controls.Add(Me.lblSupplierNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtSupplierNameAra)
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
        Me.floDataDisplay.Controls.Add(Me.lblExpAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacExpAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblApAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacApAccountIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblCreditLimit)
        Me.floDataDisplay.Controls.Add(Me.txtCreditLimit)
        Me.floDataDisplay.Controls.Add(Me.lblPaymentMethod)
        Me.floDataDisplay.Controls.Add(Me.cacPaymentMethod)
        Me.floDataDisplay.Controls.Add(Me.lblOpeningBalance)
        Me.floDataDisplay.Controls.Add(Me.txtOpeningBalance)
        Me.floDataDisplay.Controls.Add(Me.lblSettlementDueDays)
        Me.floDataDisplay.Controls.Add(Me.txtSettlementDueDays)
        Me.floDataDisplay.Controls.Add(Me.lblPaymentDueDays)
        Me.floDataDisplay.Controls.Add(Me.txtPaymentDueDays)
        Me.floDataDisplay.Controls.Add(Me.lblSettlementDiscount)
        Me.floDataDisplay.Controls.Add(Me.txtSettlementDiscount)
        Me.floDataDisplay.Controls.Add(Me.CLabel3)
        Me.floDataDisplay.Controls.Add(Me.lblActive)
        Me.floDataDisplay.Controls.Add(Me.chkActive)
        Me.floDataDisplay.Controls.Add(Me.lblDateAccountOpen)
        Me.floDataDisplay.Controls.Add(Me.dtpDateAccountOpen)
        Me.floDataDisplay.Controls.Add(Me.lblAccountStatus)
        Me.floDataDisplay.Controls.Add(Me.cacAccountStatus)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtBalance)
        Me.floDataDisplay.Controls.Add(Me.CLabel1)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BegFindValue = Nothing
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.txtVatNumber.EndFindValue = Nothing
        Me.txtVatNumber.FieldDescription = Nothing
        Me.txtVatNumber.FieldName = Nothing
        Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatNumber.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtVatNumber, true)
        resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'cacCountryCode
        '
        Me.cacCountryCode.BackColor = System.Drawing.Color.White
        Me.cacCountryCode.BegFindValue = Nothing
        Me.cacCountryCode.ChangingSearchValueOnly = false
        Me.cacCountryCode.CurrentSearchTerm = ""
        Me.cacCountryCode.DefaultValue = Nothing
        Me.cacCountryCode.DisplayMember = "Name"
        Me.cacCountryCode.EditingMode = false
        Me.cacCountryCode.EndFindValue = Nothing
        Me.cacCountryCode.FieldDescription = Nothing
        Me.cacCountryCode.FieldName = Nothing
        Me.cacCountryCode.FilterRule = Nothing
        Me.cacCountryCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacCountryCode.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cacCountryCode, true)
        resources.ApplyResources(Me.cacCountryCode, "cacCountryCode")
        Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
        Me.cacCountryCode.FormattingEnabled = true
        Me.cacCountryCode.HideWhenNotEditingOrAdding = false
        Me.cacCountryCode.IgnoreCase = false
        Me.cacCountryCode.LinkedLabel = Nothing
        Me.cacCountryCode.Name = "cacCountryCode"
        Me.cacCountryCode.OldValue = 0
        Me.cacCountryCode.OriginalDataSource = Nothing
        Me.cacCountryCode.OriginalList = Nothing
        Me.cacCountryCode.OverrideDropDownStyleList = false
        Me.cacCountryCode.PreviousSearchTerm = Nothing
        Me.cacCountryCode.PropertySelector = Nothing
        Me.cacCountryCode.ReadOnlyCombo = false
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
        Me.cacBankIdNo.BegFindValue = Nothing
        Me.cacBankIdNo.ChangingSearchValueOnly = false
        Me.cacBankIdNo.CurrentSearchTerm = ""
        Me.cacBankIdNo.DefaultValue = Nothing
        Me.cacBankIdNo.DisplayMember = "Name"
        Me.cacBankIdNo.EditingMode = false
        Me.cacBankIdNo.EndFindValue = Nothing
        Me.cacBankIdNo.FieldDescription = Nothing
        Me.cacBankIdNo.FieldName = Nothing
        Me.cacBankIdNo.FilterRule = Nothing
        Me.cacBankIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacBankIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cacBankIdNo, true)
        resources.ApplyResources(Me.cacBankIdNo, "cacBankIdNo")
        Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacBankIdNo.FormattingEnabled = true
        Me.cacBankIdNo.HideWhenNotEditingOrAdding = false
        Me.cacBankIdNo.IgnoreCase = false
        Me.cacBankIdNo.LinkedLabel = Nothing
        Me.cacBankIdNo.Name = "cacBankIdNo"
        Me.cacBankIdNo.OldValue = 0
        Me.cacBankIdNo.OriginalDataSource = Nothing
        Me.cacBankIdNo.OriginalList = Nothing
        Me.cacBankIdNo.OverrideDropDownStyleList = false
        Me.cacBankIdNo.PreviousSearchTerm = Nothing
        Me.cacBankIdNo.PropertySelector = Nothing
        Me.cacBankIdNo.ReadOnlyCombo = false
        Me.cacBankIdNo.SuggestBoxHeight = 200
        Me.cacBankIdNo.SuggestListOrderRule = Nothing
        Me.cacBankIdNo.TextToSearch = Nothing
        Me.cacBankIdNo.ValueIsMandatory = false
        Me.cacBankIdNo.ValueIsNullable = false
        Me.cacBankIdNo.ValueIsNumeric = false
        Me.cacBankIdNo.ValueMember = "IdNo"
        '
        'cacExpAccountIdNo
        '
        Me.cacExpAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacExpAccountIdNo.BegFindValue = Nothing
        Me.cacExpAccountIdNo.ChangingSearchValueOnly = false
        Me.cacExpAccountIdNo.CurrentSearchTerm = ""
        Me.cacExpAccountIdNo.DefaultValue = Nothing
        Me.cacExpAccountIdNo.DisplayMember = "Name"
        Me.cacExpAccountIdNo.EditingMode = false
        Me.cacExpAccountIdNo.EndFindValue = Nothing
        Me.cacExpAccountIdNo.FieldDescription = Nothing
        Me.cacExpAccountIdNo.FieldName = Nothing
        Me.cacExpAccountIdNo.FilterRule = Nothing
        Me.cacExpAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacExpAccountIdNo.FindEnabled = false
        resources.ApplyResources(Me.cacExpAccountIdNo, "cacExpAccountIdNo")
        Me.cacExpAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacExpAccountIdNo.FormattingEnabled = true
        Me.cacExpAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacExpAccountIdNo.IgnoreCase = false
        Me.cacExpAccountIdNo.LinkedLabel = Nothing
        Me.cacExpAccountIdNo.Name = "cacExpAccountIdNo"
        Me.cacExpAccountIdNo.OldValue = 0
        Me.cacExpAccountIdNo.OriginalDataSource = Nothing
        Me.cacExpAccountIdNo.OriginalList = Nothing
        Me.cacExpAccountIdNo.OverrideDropDownStyleList = false
        Me.cacExpAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacExpAccountIdNo.PropertySelector = Nothing
        Me.cacExpAccountIdNo.ReadOnlyCombo = false
        Me.cacExpAccountIdNo.SuggestBoxHeight = 200
        Me.cacExpAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacExpAccountIdNo.TabStop = false
        Me.cacExpAccountIdNo.TextToSearch = Nothing
        Me.cacExpAccountIdNo.ValueIsMandatory = false
        Me.cacExpAccountIdNo.ValueIsNullable = false
        Me.cacExpAccountIdNo.ValueIsNumeric = false
        Me.cacExpAccountIdNo.ValueMember = "IdNo"
        '
        'cacApAccountIdNo
        '
        Me.cacApAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacApAccountIdNo.BegFindValue = Nothing
        Me.cacApAccountIdNo.ChangingSearchValueOnly = false
        Me.cacApAccountIdNo.CurrentSearchTerm = ""
        Me.cacApAccountIdNo.DefaultValue = Nothing
        Me.cacApAccountIdNo.DisplayMember = "Name"
        Me.cacApAccountIdNo.EditingMode = false
        Me.cacApAccountIdNo.EndFindValue = Nothing
        Me.cacApAccountIdNo.FieldDescription = Nothing
        Me.cacApAccountIdNo.FieldName = Nothing
        Me.cacApAccountIdNo.FilterRule = Nothing
        Me.cacApAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacApAccountIdNo.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cacApAccountIdNo, true)
        resources.ApplyResources(Me.cacApAccountIdNo, "cacApAccountIdNo")
        Me.cacApAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacApAccountIdNo.FormattingEnabled = true
        Me.cacApAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacApAccountIdNo.IgnoreCase = false
        Me.cacApAccountIdNo.LinkedLabel = Nothing
        Me.cacApAccountIdNo.Name = "cacApAccountIdNo"
        Me.cacApAccountIdNo.OldValue = 0
        Me.cacApAccountIdNo.OriginalDataSource = Nothing
        Me.cacApAccountIdNo.OriginalList = Nothing
        Me.cacApAccountIdNo.OverrideDropDownStyleList = false
        Me.cacApAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacApAccountIdNo.PropertySelector = Nothing
        Me.cacApAccountIdNo.ReadOnlyCombo = false
        Me.cacApAccountIdNo.SuggestBoxHeight = 200
        Me.cacApAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacApAccountIdNo.TextToSearch = Nothing
        Me.cacApAccountIdNo.ValueIsMandatory = false
        Me.cacApAccountIdNo.ValueIsNullable = false
        Me.cacApAccountIdNo.ValueIsNumeric = false
        Me.cacApAccountIdNo.ValueMember = "IdNo"
        '
        'cacPaymentMethod
        '
        Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
        Me.cacPaymentMethod.BegFindValue = Nothing
        Me.cacPaymentMethod.ChangingSearchValueOnly = false
        Me.cacPaymentMethod.CurrentSearchTerm = ""
        Me.cacPaymentMethod.DefaultValue = Nothing
        Me.cacPaymentMethod.DisplayMember = "Name"
        Me.cacPaymentMethod.EditingMode = false
        Me.cacPaymentMethod.EndFindValue = Nothing
        Me.cacPaymentMethod.FieldDescription = Nothing
        Me.cacPaymentMethod.FieldName = Nothing
        Me.cacPaymentMethod.FilterRule = Nothing
        Me.cacPaymentMethod.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacPaymentMethod.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cacPaymentMethod, true)
        resources.ApplyResources(Me.cacPaymentMethod, "cacPaymentMethod")
        Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.cacPaymentMethod.FormattingEnabled = true
        Me.cacPaymentMethod.HideWhenNotEditingOrAdding = false
        Me.cacPaymentMethod.IgnoreCase = false
        Me.cacPaymentMethod.LinkedLabel = Nothing
        Me.cacPaymentMethod.Name = "cacPaymentMethod"
        Me.cacPaymentMethod.OldValue = 0
        Me.cacPaymentMethod.OriginalDataSource = Nothing
        Me.cacPaymentMethod.OriginalList = Nothing
        Me.cacPaymentMethod.OverrideDropDownStyleList = false
        Me.cacPaymentMethod.PreviousSearchTerm = Nothing
        Me.cacPaymentMethod.PropertySelector = Nothing
        Me.cacPaymentMethod.ReadOnlyCombo = false
        Me.cacPaymentMethod.SuggestBoxHeight = 200
        Me.cacPaymentMethod.SuggestListOrderRule = Nothing
        Me.cacPaymentMethod.TextToSearch = Nothing
        Me.cacPaymentMethod.ValueIsMandatory = false
        Me.cacPaymentMethod.ValueIsNullable = false
        Me.cacPaymentMethod.ValueIsNumeric = false
        Me.cacPaymentMethod.ValueMember = "Code"
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
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = false
        Me.chkActive.IgnoreCase = false
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'dtpDateAccountOpen
        '
        Me.dtpDateAccountOpen.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateAccountOpen.DefaultValue = Nothing
        Me.dtpDateAccountOpen.DisplayOnly = false
        Me.dtpDateAccountOpen.DtpDefaultValue = Nothing
        Me.dtpDateAccountOpen.EditingMode = false
        Me.dtpDateAccountOpen.EditsAllowed = false
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
        Me.cacAccountStatus.BegFindValue = Nothing
        Me.cacAccountStatus.ChangingSearchValueOnly = false
        Me.cacAccountStatus.CurrentSearchTerm = ""
        Me.cacAccountStatus.DefaultValue = Nothing
        Me.cacAccountStatus.DisplayMember = "Name"
        Me.cacAccountStatus.EditingMode = false
        Me.cacAccountStatus.EndFindValue = Nothing
        Me.cacAccountStatus.FieldDescription = Nothing
        Me.cacAccountStatus.FieldName = Nothing
        Me.cacAccountStatus.FilterRule = Nothing
        Me.cacAccountStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacAccountStatus.FindEnabled = false
        Me.floDataDisplay.SetFlowBreak(Me.cacAccountStatus, true)
        resources.ApplyResources(Me.cacAccountStatus, "cacAccountStatus")
        Me.cacAccountStatus.ForeColor = System.Drawing.Color.Black
        Me.cacAccountStatus.FormattingEnabled = true
        Me.cacAccountStatus.HideWhenNotEditingOrAdding = false
        Me.cacAccountStatus.IgnoreCase = false
        Me.cacAccountStatus.LinkedLabel = Nothing
        Me.cacAccountStatus.Name = "cacAccountStatus"
        Me.cacAccountStatus.OldValue = 0
        Me.cacAccountStatus.OriginalDataSource = Nothing
        Me.cacAccountStatus.OriginalList = Nothing
        Me.cacAccountStatus.OverrideDropDownStyleList = false
        Me.cacAccountStatus.PreviousSearchTerm = Nothing
        Me.cacAccountStatus.PropertySelector = Nothing
        Me.cacAccountStatus.ReadOnlyCombo = false
        Me.cacAccountStatus.SuggestBoxHeight = 200
        Me.cacAccountStatus.SuggestListOrderRule = Nothing
        Me.cacAccountStatus.TextToSearch = Nothing
        Me.cacAccountStatus.ValueIsMandatory = false
        Me.cacAccountStatus.ValueIsNullable = false
        Me.cacAccountStatus.ValueIsNumeric = false
        Me.cacAccountStatus.ValueMember = "Code"
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.BegFindValue = Nothing
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.ComputedValue = false
        Me.txtBalance.CustomFormat = Nothing
        Me.txtBalance.DataBoundControl = true
        Me.txtBalance.DisplayOnly = true
        Me.txtBalance.EditingMode = false
        Me.txtBalance.EndFindValue = Nothing
        Me.txtBalance.FieldDescription = Nothing
        Me.txtBalance.FieldName = Nothing
        Me.txtBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBalance.FindEnabled = true
        Me.floDataDisplay.SetFlowBreak(Me.txtBalance, true)
        resources.ApplyResources(Me.txtBalance, "txtBalance")
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtBalance.MaximumValue = Nothing
        Me.txtBalance.MinimumValue = Nothing
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.OldValue = Nothing
        Me.txtBalance.ReadOnly = true
        Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBalance.ValueIsNumeric = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'SupplierEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "SupplierEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents _MBSupplierCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents _MBMainAccountNotEditable As LocalizableMessageBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblAccountStatus As CLabel
        Friend WithEvents lblDateAccountOpen As CLabel
        Friend WithEvents txtOpeningBalance As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblSupplierCode As CLabel
        Friend WithEvents txtSupplierCode As CTextBox
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents lblSupplierName As CLabel
        Friend WithEvents txtSupplierName As CTextBox
        Friend WithEvents lblSupplierNameAra As CLabel
        Friend WithEvents txtSupplierNameAra As CTextBoxArabic
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
        Friend WithEvents lblExpAccountIdNo As CLabel
        Friend WithEvents lblApAccountIdNo As CLabel
        Friend WithEvents lblCreditLimit As CLabel
        Friend WithEvents txtCreditLimit As CTextBox
        Friend WithEvents lblPaymentDueDays As CLabel
        Friend WithEvents txtPaymentDueDays As CTextBox
        Friend WithEvents lblPaymentMethod As CLabel
        Friend WithEvents lblSettlementDueDays As CLabel
        Friend WithEvents txtSettlementDueDays As CTextBox
        Friend WithEvents lblSettlementDiscount As CLabel
        Friend WithEvents txtSettlementDiscount As CTextBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents lblOpeningBalance As CLabel
        Friend WithEvents dtpDateAccountOpen As CCustomDateTimePicker
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents lblActive As CLabel
        Friend WithEvents cacCountryCode As CaComboBox
        Friend WithEvents cacBankIdNo As CaComboBox
        Friend WithEvents cacExpAccountIdNo As CaComboBox
        Friend WithEvents cacApAccountIdNo As CaComboBox
        Friend WithEvents cacPaymentMethod As CaComboBox
        Friend WithEvents cacAccountStatus As CaComboBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtBalance As CTextBox
    End Class
End Namespace