Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SupplierEntryTv
        Inherits AATM.PresentationLayer.Forms.CFormEntryTv

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
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSupplierName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSupplierNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSupplierNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblContactPerson = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtContactPerson = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblContactDesignation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtContactDesignation = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblStreet = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtStreet = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDistrict = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDistrict = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTownCity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTownCity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblProvinceState = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtProvinceState = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPoBox = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPoBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblZipCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtZipCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCountryCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPhone1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPhone1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPhone2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPhone2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblFax = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtFax = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblMobile = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtMobile = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmail = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEmail = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblWebsite = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtWebsite = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCrNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCrNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIban = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblExpAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacExpAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblApAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacApAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCreditLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSettlementDueDays = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPaymentDueDays = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateAccountOpen = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacAccountStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
        Me.SplitContainer1.Size = New System.Drawing.Size(1078, 502)
        Me.SplitContainer1.SplitterDistance = 335
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormTreeView.Size = New System.Drawing.Size(335, 502)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = ""
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
        Me.floDataDisplay.Margin = New System.Windows.Forms.Padding(0)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(690, 481)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10)
        Me.floDataDisplay.Size = New System.Drawing.Size(733, 502)
        Me.floDataDisplay.TabIndex = 1
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(153, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Id No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TxtIdNo.Enabled = false
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(166, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblSupplierCode
        '
        Me.lblSupplierCode.DisplayOnly = true
        Me.lblSupplierCode.EditingMode = false
        Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierCode.Location = New System.Drawing.Point(230, 11)
        Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierCode.Name = "lblSupplierCode"
        Me.lblSupplierCode.Size = New System.Drawing.Size(79, 23)
        Me.lblSupplierCode.TabIndex = 156
        Me.lblSupplierCode.Text = "Code"
        Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSupplierCode.Translatable = true
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
        Me.txtSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSupplierCode.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierCode.LinkedLabel = Me.lblSupplierCode
        Me.txtSupplierCode.Location = New System.Drawing.Point(311, 11)
        Me.txtSupplierCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSupplierCode.MaximumValue = Nothing
        Me.txtSupplierCode.MinimumValue = Nothing
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.OldValue = Nothing
        Me.txtSupplierCode.ReadOnly = true
        Me.txtSupplierCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierCode.Size = New System.Drawing.Size(127, 23)
        Me.txtSupplierCode.TabIndex = 0
        Me.txtSupplierCode.Translatable = false
        Me.txtSupplierCode.ValueIsMandatory = true
        Me.txtSupplierCode.ValueIsUnique = true
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatNumber.Location = New System.Drawing.Point(440, 11)
        Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatNumber.Name = "lblVatNumber"
        Me.lblVatNumber.Size = New System.Drawing.Size(68, 23)
        Me.lblVatNumber.TabIndex = 209
        Me.lblVatNumber.Text = "VAT No."
        Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVatNumber.Translatable = true
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
        Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
        Me.txtVatNumber.Location = New System.Drawing.Point(510, 11)
        Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatNumber.Size = New System.Drawing.Size(205, 23)
        Me.txtVatNumber.TabIndex = 1
        Me.txtVatNumber.Translatable = false
        '
        'lblSupplierName
        '
        Me.lblSupplierName.DisplayOnly = true
        Me.lblSupplierName.EditingMode = false
        Me.lblSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierName.Location = New System.Drawing.Point(11, 36)
        Me.lblSupplierName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(153, 23)
        Me.lblSupplierName.TabIndex = 157
        Me.lblSupplierName.Text = "Name"
        Me.lblSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSupplierName.Translatable = true
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
        Me.txtSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSupplierName.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierName.LinkedLabel = Me.lblSupplierName
        Me.txtSupplierName.Location = New System.Drawing.Point(166, 36)
        Me.txtSupplierName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSupplierName.MaximumValue = Nothing
        Me.txtSupplierName.MinimumValue = Nothing
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.OldValue = Nothing
        Me.txtSupplierName.ReadOnly = true
        Me.txtSupplierName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierName.Size = New System.Drawing.Size(550, 23)
        Me.txtSupplierName.TabIndex = 2
        Me.txtSupplierName.Translatable = false
        Me.txtSupplierName.ValueIsMandatory = true
        Me.txtSupplierName.ValueIsUnique = true
        '
        'lblSupplierNameAra
        '
        Me.lblSupplierNameAra.DisplayOnly = true
        Me.lblSupplierNameAra.EditingMode = false
        Me.lblSupplierNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierNameAra.Location = New System.Drawing.Point(11, 61)
        Me.lblSupplierNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierNameAra.Name = "lblSupplierNameAra"
        Me.lblSupplierNameAra.Size = New System.Drawing.Size(153, 23)
        Me.lblSupplierNameAra.TabIndex = 158
        Me.lblSupplierNameAra.Text = "Name (Arabic)"
        Me.lblSupplierNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSupplierNameAra.Translatable = true
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
        Me.txtSupplierNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSupplierNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierNameAra.LinkedLabel = Me.lblSupplierNameAra
        Me.txtSupplierNameAra.Location = New System.Drawing.Point(166, 61)
        Me.txtSupplierNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSupplierNameAra.MaximumValue = Nothing
        Me.txtSupplierNameAra.MinimumValue = Nothing
        Me.txtSupplierNameAra.Name = "txtSupplierNameAra"
        Me.txtSupplierNameAra.OldValue = Nothing
        Me.txtSupplierNameAra.ReadOnly = true
        Me.txtSupplierNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSupplierNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSupplierNameAra.Size = New System.Drawing.Size(549, 23)
        Me.txtSupplierNameAra.TabIndex = 3
        Me.txtSupplierNameAra.Translatable = false
        Me.txtSupplierNameAra.ValueIsMandatory = true
        Me.txtSupplierNameAra.ValueIsUnique = true
        '
        'lblContactPerson
        '
        Me.lblContactPerson.DisplayOnly = true
        Me.lblContactPerson.EditingMode = false
        Me.lblContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblContactPerson.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblContactPerson.Location = New System.Drawing.Point(11, 86)
        Me.lblContactPerson.Margin = New System.Windows.Forms.Padding(1)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(153, 23)
        Me.lblContactPerson.TabIndex = 183
        Me.lblContactPerson.Text = "Contact Person"
        Me.lblContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblContactPerson.Translatable = true
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
        Me.txtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
        Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
        Me.txtContactPerson.Location = New System.Drawing.Point(166, 86)
        Me.txtContactPerson.Margin = New System.Windows.Forms.Padding(1)
        Me.txtContactPerson.MaximumValue = Nothing
        Me.txtContactPerson.MinimumValue = Nothing
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.OldValue = Nothing
        Me.txtContactPerson.ReadOnly = true
        Me.txtContactPerson.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtContactPerson.Size = New System.Drawing.Size(194, 23)
        Me.txtContactPerson.TabIndex = 4
        Me.txtContactPerson.Translatable = false
        '
        'lblContactDesignation
        '
        Me.lblContactDesignation.DisplayOnly = true
        Me.lblContactDesignation.EditingMode = false
        Me.lblContactDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblContactDesignation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblContactDesignation.Location = New System.Drawing.Point(362, 86)
        Me.lblContactDesignation.Margin = New System.Windows.Forms.Padding(1)
        Me.lblContactDesignation.Name = "lblContactDesignation"
        Me.lblContactDesignation.Size = New System.Drawing.Size(148, 23)
        Me.lblContactDesignation.TabIndex = 185
        Me.lblContactDesignation.Text = "Contact Designation"
        Me.lblContactDesignation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblContactDesignation.Translatable = true
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
        Me.txtContactDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtContactDesignation.ForeColor = System.Drawing.Color.Black
        Me.txtContactDesignation.LinkedLabel = Me.lblContactDesignation
        Me.txtContactDesignation.Location = New System.Drawing.Point(512, 86)
        Me.txtContactDesignation.Margin = New System.Windows.Forms.Padding(1)
        Me.txtContactDesignation.MaximumValue = Nothing
        Me.txtContactDesignation.MinimumValue = Nothing
        Me.txtContactDesignation.Name = "txtContactDesignation"
        Me.txtContactDesignation.OldValue = Nothing
        Me.txtContactDesignation.ReadOnly = true
        Me.txtContactDesignation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtContactDesignation.Size = New System.Drawing.Size(204, 23)
        Me.txtContactDesignation.TabIndex = 5
        Me.txtContactDesignation.Translatable = false
        '
        'lblStreet
        '
        Me.lblStreet.DisplayOnly = true
        Me.lblStreet.EditingMode = false
        Me.lblStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStreet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStreet.Location = New System.Drawing.Point(11, 111)
        Me.lblStreet.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(153, 23)
        Me.lblStreet.TabIndex = 187
        Me.lblStreet.Text = "Street "
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStreet.Translatable = true
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
        Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtStreet.ForeColor = System.Drawing.Color.Black
        Me.txtStreet.LinkedLabel = Me.lblStreet
        Me.txtStreet.Location = New System.Drawing.Point(166, 111)
        Me.txtStreet.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStreet.MaximumValue = Nothing
        Me.txtStreet.MinimumValue = Nothing
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.OldValue = Nothing
        Me.txtStreet.ReadOnly = true
        Me.txtStreet.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtStreet.Size = New System.Drawing.Size(194, 23)
        Me.txtStreet.TabIndex = 6
        Me.txtStreet.Translatable = false
        '
        'lblDistrict
        '
        Me.lblDistrict.DisplayOnly = true
        Me.lblDistrict.EditingMode = false
        Me.lblDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDistrict.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDistrict.Location = New System.Drawing.Point(362, 111)
        Me.lblDistrict.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(148, 23)
        Me.lblDistrict.TabIndex = 189
        Me.lblDistrict.Text = "District"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDistrict.Translatable = true
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
        Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDistrict.ForeColor = System.Drawing.Color.Black
        Me.txtDistrict.LinkedLabel = Me.lblDistrict
        Me.txtDistrict.Location = New System.Drawing.Point(512, 111)
        Me.txtDistrict.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDistrict.MaximumValue = Nothing
        Me.txtDistrict.MinimumValue = Nothing
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.OldValue = Nothing
        Me.txtDistrict.ReadOnly = true
        Me.txtDistrict.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDistrict.Size = New System.Drawing.Size(204, 23)
        Me.txtDistrict.TabIndex = 7
        Me.txtDistrict.Translatable = false
        '
        'lblTownCity
        '
        Me.lblTownCity.DisplayOnly = true
        Me.lblTownCity.EditingMode = false
        Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTownCity.Location = New System.Drawing.Point(11, 136)
        Me.lblTownCity.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTownCity.Name = "lblTownCity"
        Me.lblTownCity.Size = New System.Drawing.Size(153, 23)
        Me.lblTownCity.TabIndex = 191
        Me.lblTownCity.Text = "Town/City"
        Me.lblTownCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTownCity.Translatable = true
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
        Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTownCity.ForeColor = System.Drawing.Color.Black
        Me.txtTownCity.LinkedLabel = Me.lblTownCity
        Me.txtTownCity.Location = New System.Drawing.Point(166, 136)
        Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTownCity.MaximumValue = Nothing
        Me.txtTownCity.MinimumValue = Nothing
        Me.txtTownCity.Name = "txtTownCity"
        Me.txtTownCity.OldValue = Nothing
        Me.txtTownCity.ReadOnly = true
        Me.txtTownCity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTownCity.Size = New System.Drawing.Size(194, 23)
        Me.txtTownCity.TabIndex = 8
        Me.txtTownCity.Translatable = false
        '
        'lblProvinceState
        '
        Me.lblProvinceState.DisplayOnly = true
        Me.lblProvinceState.EditingMode = false
        Me.lblProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblProvinceState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProvinceState.Location = New System.Drawing.Point(362, 136)
        Me.lblProvinceState.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProvinceState.Name = "lblProvinceState"
        Me.lblProvinceState.Size = New System.Drawing.Size(148, 23)
        Me.lblProvinceState.TabIndex = 193
        Me.lblProvinceState.Text = "Province/State"
        Me.lblProvinceState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblProvinceState.Translatable = true
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
        Me.txtProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
        Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
        Me.txtProvinceState.Location = New System.Drawing.Point(512, 136)
        Me.txtProvinceState.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProvinceState.MaximumValue = Nothing
        Me.txtProvinceState.MinimumValue = Nothing
        Me.txtProvinceState.Name = "txtProvinceState"
        Me.txtProvinceState.OldValue = Nothing
        Me.txtProvinceState.ReadOnly = true
        Me.txtProvinceState.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtProvinceState.Size = New System.Drawing.Size(204, 23)
        Me.txtProvinceState.TabIndex = 9
        Me.txtProvinceState.Translatable = false
        '
        'lblPoBox
        '
        Me.lblPoBox.DisplayOnly = true
        Me.lblPoBox.EditingMode = false
        Me.lblPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPoBox.Location = New System.Drawing.Point(11, 161)
        Me.lblPoBox.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPoBox.Name = "lblPoBox"
        Me.lblPoBox.Size = New System.Drawing.Size(153, 23)
        Me.lblPoBox.TabIndex = 199
        Me.lblPoBox.Text = "P.O. Box Number"
        Me.lblPoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPoBox.Translatable = true
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
        Me.txtPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPoBox.ForeColor = System.Drawing.Color.Black
        Me.txtPoBox.LinkedLabel = Me.lblPoBox
        Me.txtPoBox.Location = New System.Drawing.Point(166, 161)
        Me.txtPoBox.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPoBox.MaximumValue = Nothing
        Me.txtPoBox.MinimumValue = Nothing
        Me.txtPoBox.Name = "txtPoBox"
        Me.txtPoBox.OldValue = Nothing
        Me.txtPoBox.ReadOnly = true
        Me.txtPoBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPoBox.Size = New System.Drawing.Size(62, 23)
        Me.txtPoBox.TabIndex = 10
        Me.txtPoBox.Translatable = false
        '
        'lblZipCode
        '
        Me.lblZipCode.DisplayOnly = true
        Me.lblZipCode.EditingMode = false
        Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblZipCode.Location = New System.Drawing.Point(230, 161)
        Me.lblZipCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(68, 23)
        Me.lblZipCode.TabIndex = 197
        Me.lblZipCode.Text = "Zip Code"
        Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblZipCode.Translatable = true
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
        Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtZipCode.ForeColor = System.Drawing.Color.Black
        Me.txtZipCode.LinkedLabel = Me.lblZipCode
        Me.txtZipCode.Location = New System.Drawing.Point(300, 161)
        Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtZipCode.MaximumValue = Nothing
        Me.txtZipCode.MinimumValue = Nothing
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.OldValue = Nothing
        Me.txtZipCode.ReadOnly = true
        Me.txtZipCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtZipCode.Size = New System.Drawing.Size(61, 23)
        Me.txtZipCode.TabIndex = 11
        Me.txtZipCode.Translatable = false
        '
        'lblCountryCode
        '
        Me.lblCountryCode.DisplayOnly = true
        Me.lblCountryCode.EditingMode = false
        Me.lblCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCountryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountryCode.Location = New System.Drawing.Point(363, 161)
        Me.lblCountryCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCountryCode.Name = "lblCountryCode"
        Me.lblCountryCode.Size = New System.Drawing.Size(148, 23)
        Me.lblCountryCode.TabIndex = 195
        Me.lblCountryCode.Text = "Country"
        Me.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCountryCode.Translatable = true
        '
        'cacCountryCode
        '
        Me.cacCountryCode.BackColor = System.Drawing.Color.White
        Me.cacCountryCode.BegFindValue = Nothing
        Me.cacCountryCode.ChangingSearchValueOnly = false
        Me.cacCountryCode.CurrentSearchTerm = ""
        Me.cacCountryCode.DataValue = Nothing
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
        Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
        Me.cacCountryCode.FormattingEnabled = true
        Me.cacCountryCode.HideWhenNotEditingOrAdding = false
        Me.cacCountryCode.IgnoreCase = false
        Me.cacCountryCode.IntegralHeight = false
        Me.cacCountryCode.LinkedLabel = Nothing
        Me.cacCountryCode.Location = New System.Drawing.Point(513, 161)
        Me.cacCountryCode.Margin = New System.Windows.Forms.Padding(1)
        Me.cacCountryCode.Name = "cacCountryCode"
        Me.cacCountryCode.OldValue = 0
        Me.cacCountryCode.OriginalDataSource = Nothing
        Me.cacCountryCode.OriginalList = Nothing
        Me.cacCountryCode.OverrideDropDownStyleList = false
        Me.cacCountryCode.PreviousSearchTerm = Nothing
        Me.cacCountryCode.PropertySelector = Nothing
        Me.cacCountryCode.ReadOnlyCombo = false
        Me.cacCountryCode.Size = New System.Drawing.Size(203, 24)
        Me.cacCountryCode.SuggestBoxHeight = 200
        Me.cacCountryCode.SuggestListOrderRule = Nothing
        Me.cacCountryCode.TabIndex = 12
        Me.cacCountryCode.TextToSearch = Nothing
        Me.cacCountryCode.Translatable = false
        Me.cacCountryCode.ValueIsMandatory = false
        Me.cacCountryCode.ValueIsNullable = false
        Me.cacCountryCode.ValueIsNumeric = false
        Me.cacCountryCode.ValueMember = "Code"
        '
        'lblPhone1
        '
        Me.lblPhone1.DisplayOnly = true
        Me.lblPhone1.EditingMode = false
        Me.lblPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhone1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPhone1.Location = New System.Drawing.Point(11, 187)
        Me.lblPhone1.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhone1.Name = "lblPhone1"
        Me.lblPhone1.Size = New System.Drawing.Size(153, 23)
        Me.lblPhone1.TabIndex = 201
        Me.lblPhone1.Text = "Main Phone Number"
        Me.lblPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPhone1.Translatable = true
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
        Me.txtPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.LinkedLabel = Me.lblPhone1
        Me.txtPhone1.Location = New System.Drawing.Point(166, 187)
        Me.txtPhone1.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhone1.MaximumValue = Nothing
        Me.txtPhone1.MinimumValue = Nothing
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.OldValue = Nothing
        Me.txtPhone1.ReadOnly = true
        Me.txtPhone1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPhone1.Size = New System.Drawing.Size(194, 23)
        Me.txtPhone1.TabIndex = 13
        Me.txtPhone1.Translatable = false
        '
        'lblPhone2
        '
        Me.lblPhone2.DisplayOnly = true
        Me.lblPhone2.EditingMode = false
        Me.lblPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPhone2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPhone2.Location = New System.Drawing.Point(362, 187)
        Me.lblPhone2.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhone2.Name = "lblPhone2"
        Me.lblPhone2.Size = New System.Drawing.Size(148, 23)
        Me.lblPhone2.TabIndex = 203
        Me.lblPhone2.Text = "Secondary Phone No."
        Me.lblPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPhone2.Translatable = true
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
        Me.txtPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.LinkedLabel = Me.lblPhone2
        Me.txtPhone2.Location = New System.Drawing.Point(512, 187)
        Me.txtPhone2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhone2.MaximumValue = Nothing
        Me.txtPhone2.MinimumValue = Nothing
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.OldValue = Nothing
        Me.txtPhone2.ReadOnly = true
        Me.txtPhone2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPhone2.Size = New System.Drawing.Size(204, 23)
        Me.txtPhone2.TabIndex = 14
        Me.txtPhone2.Translatable = false
        '
        'lblFax
        '
        Me.lblFax.DisplayOnly = true
        Me.lblFax.EditingMode = false
        Me.lblFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFax.Location = New System.Drawing.Point(11, 212)
        Me.lblFax.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(153, 23)
        Me.lblFax.TabIndex = 205
        Me.lblFax.Text = "Fax Number"
        Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFax.Translatable = true
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
        Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtFax.ForeColor = System.Drawing.Color.Black
        Me.txtFax.LinkedLabel = Me.lblFax
        Me.txtFax.Location = New System.Drawing.Point(166, 212)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFax.MaximumValue = Nothing
        Me.txtFax.MinimumValue = Nothing
        Me.txtFax.Name = "txtFax"
        Me.txtFax.OldValue = Nothing
        Me.txtFax.ReadOnly = true
        Me.txtFax.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtFax.Size = New System.Drawing.Size(194, 23)
        Me.txtFax.TabIndex = 15
        Me.txtFax.Translatable = false
        '
        'lblMobile
        '
        Me.lblMobile.DisplayOnly = true
        Me.lblMobile.EditingMode = false
        Me.lblMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblMobile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMobile.Location = New System.Drawing.Point(362, 212)
        Me.lblMobile.Margin = New System.Windows.Forms.Padding(1)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Size = New System.Drawing.Size(148, 23)
        Me.lblMobile.TabIndex = 207
        Me.lblMobile.Text = "Mobile Number"
        Me.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMobile.Translatable = true
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
        Me.txtMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.LinkedLabel = Me.lblMobile
        Me.txtMobile.Location = New System.Drawing.Point(512, 212)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(1)
        Me.txtMobile.MaximumValue = Nothing
        Me.txtMobile.MinimumValue = Nothing
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.OldValue = Nothing
        Me.txtMobile.ReadOnly = true
        Me.txtMobile.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtMobile.Size = New System.Drawing.Size(204, 23)
        Me.txtMobile.TabIndex = 16
        Me.txtMobile.Translatable = false
        '
        'lblEmail
        '
        Me.lblEmail.DisplayOnly = true
        Me.lblEmail.EditingMode = false
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmail.Location = New System.Drawing.Point(11, 237)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(153, 23)
        Me.lblEmail.TabIndex = 211
        Me.lblEmail.Text = "E-mail Address"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmail.Translatable = true
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
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.LinkedLabel = Me.lblEmail
        Me.txtEmail.Location = New System.Drawing.Point(166, 237)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmail.MaximumValue = Nothing
        Me.txtEmail.MinimumValue = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OldValue = Nothing
        Me.txtEmail.ReadOnly = true
        Me.txtEmail.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEmail.Size = New System.Drawing.Size(194, 23)
        Me.txtEmail.TabIndex = 17
        Me.txtEmail.Translatable = false
        '
        'lblWebsite
        '
        Me.lblWebsite.DisplayOnly = true
        Me.lblWebsite.EditingMode = false
        Me.lblWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblWebsite.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWebsite.Location = New System.Drawing.Point(362, 237)
        Me.lblWebsite.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(148, 23)
        Me.lblWebsite.TabIndex = 213
        Me.lblWebsite.Text = "Website Address"
        Me.lblWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblWebsite.Translatable = true
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
        Me.txtWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtWebsite.ForeColor = System.Drawing.Color.Black
        Me.txtWebsite.LinkedLabel = Me.lblWebsite
        Me.txtWebsite.Location = New System.Drawing.Point(512, 237)
        Me.txtWebsite.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWebsite.MaximumValue = Nothing
        Me.txtWebsite.MinimumValue = Nothing
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.OldValue = Nothing
        Me.txtWebsite.ReadOnly = true
        Me.txtWebsite.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtWebsite.Size = New System.Drawing.Size(204, 23)
        Me.txtWebsite.TabIndex = 18
        Me.txtWebsite.Translatable = false
        '
        'lblCrNumber
        '
        Me.lblCrNumber.DisplayOnly = true
        Me.lblCrNumber.EditingMode = false
        Me.lblCrNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCrNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCrNumber.Location = New System.Drawing.Point(11, 262)
        Me.lblCrNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCrNumber.Name = "lblCrNumber"
        Me.lblCrNumber.Size = New System.Drawing.Size(153, 23)
        Me.lblCrNumber.TabIndex = 215
        Me.lblCrNumber.Text = "Comm. Reg. No. (C.R.)"
        Me.lblCrNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCrNumber.Translatable = true
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
        Me.txtCrNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCrNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCrNumber.LinkedLabel = Me.lblCrNumber
        Me.txtCrNumber.Location = New System.Drawing.Point(166, 262)
        Me.txtCrNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCrNumber.MaximumValue = Nothing
        Me.txtCrNumber.MinimumValue = Nothing
        Me.txtCrNumber.Name = "txtCrNumber"
        Me.txtCrNumber.OldValue = Nothing
        Me.txtCrNumber.ReadOnly = true
        Me.txtCrNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCrNumber.Size = New System.Drawing.Size(194, 23)
        Me.txtCrNumber.TabIndex = 19
        Me.txtCrNumber.Translatable = false
        '
        'lblBankIdNo
        '
        Me.lblBankIdNo.DisplayOnly = true
        Me.lblBankIdNo.EditingMode = false
        Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBankIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBankIdNo.Location = New System.Drawing.Point(362, 262)
        Me.lblBankIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBankIdNo.Name = "lblBankIdNo"
        Me.lblBankIdNo.Size = New System.Drawing.Size(148, 23)
        Me.lblBankIdNo.TabIndex = 216
        Me.lblBankIdNo.Text = "Bank Name"
        Me.lblBankIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBankIdNo.Translatable = true
        '
        'cacBankIdNo
        '
        Me.cacBankIdNo.BackColor = System.Drawing.Color.White
        Me.cacBankIdNo.BegFindValue = Nothing
        Me.cacBankIdNo.ChangingSearchValueOnly = false
        Me.cacBankIdNo.CurrentSearchTerm = ""
        Me.cacBankIdNo.DataValue = Nothing
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
        Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacBankIdNo.FormattingEnabled = true
        Me.cacBankIdNo.HideWhenNotEditingOrAdding = false
        Me.cacBankIdNo.IgnoreCase = false
        Me.cacBankIdNo.IntegralHeight = false
        Me.cacBankIdNo.LinkedLabel = Nothing
        Me.cacBankIdNo.Location = New System.Drawing.Point(512, 262)
        Me.cacBankIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacBankIdNo.Name = "cacBankIdNo"
        Me.cacBankIdNo.OldValue = 0
        Me.cacBankIdNo.OriginalDataSource = Nothing
        Me.cacBankIdNo.OriginalList = Nothing
        Me.cacBankIdNo.OverrideDropDownStyleList = false
        Me.cacBankIdNo.PreviousSearchTerm = Nothing
        Me.cacBankIdNo.PropertySelector = Nothing
        Me.cacBankIdNo.ReadOnlyCombo = false
        Me.cacBankIdNo.Size = New System.Drawing.Size(204, 24)
        Me.cacBankIdNo.SuggestBoxHeight = 200
        Me.cacBankIdNo.SuggestListOrderRule = Nothing
        Me.cacBankIdNo.TabIndex = 20
        Me.cacBankIdNo.TextToSearch = Nothing
        Me.cacBankIdNo.Translatable = false
        Me.cacBankIdNo.ValueIsMandatory = false
        Me.cacBankIdNo.ValueIsNullable = false
        Me.cacBankIdNo.ValueIsNumeric = false
        Me.cacBankIdNo.ValueMember = "IdNo"
        '
        'lblBankAccountNo
        '
        Me.lblBankAccountNo.DisplayOnly = true
        Me.lblBankAccountNo.EditingMode = false
        Me.lblBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBankAccountNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBankAccountNo.Location = New System.Drawing.Point(11, 288)
        Me.lblBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBankAccountNo.Name = "lblBankAccountNo"
        Me.lblBankAccountNo.Size = New System.Drawing.Size(153, 23)
        Me.lblBankAccountNo.TabIndex = 218
        Me.lblBankAccountNo.Text = "Bank Account No."
        Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBankAccountNo.Translatable = true
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
        Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
        Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
        Me.txtBankAccountNo.Location = New System.Drawing.Point(166, 288)
        Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtBankAccountNo.MaximumValue = Nothing
        Me.txtBankAccountNo.MinimumValue = Nothing
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.OldValue = Nothing
        Me.txtBankAccountNo.ReadOnly = true
        Me.txtBankAccountNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBankAccountNo.Size = New System.Drawing.Size(194, 23)
        Me.txtBankAccountNo.TabIndex = 21
        Me.txtBankAccountNo.Translatable = false
        '
        'lblIban
        '
        Me.lblIban.DisplayOnly = true
        Me.lblIban.EditingMode = false
        Me.lblIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIban.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIban.Location = New System.Drawing.Point(362, 288)
        Me.lblIban.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIban.Name = "lblIban"
        Me.lblIban.Size = New System.Drawing.Size(148, 23)
        Me.lblIban.TabIndex = 220
        Me.lblIban.Text = "IBAN Number"
        Me.lblIban.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIban.Translatable = true
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
        Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIban.ForeColor = System.Drawing.Color.Black
        Me.txtIban.LinkedLabel = Me.lblIban
        Me.txtIban.Location = New System.Drawing.Point(512, 288)
        Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIban.MaximumValue = Nothing
        Me.txtIban.MinimumValue = Nothing
        Me.txtIban.Name = "txtIban"
        Me.txtIban.OldValue = Nothing
        Me.txtIban.ReadOnly = true
        Me.txtIban.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIban.Size = New System.Drawing.Size(204, 23)
        Me.txtIban.TabIndex = 22
        Me.txtIban.Translatable = false
        '
        'lblExpAccountIdNo
        '
        Me.lblExpAccountIdNo.DisplayOnly = true
        Me.lblExpAccountIdNo.EditingMode = false
        Me.lblExpAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblExpAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExpAccountIdNo.Location = New System.Drawing.Point(11, 313)
        Me.lblExpAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblExpAccountIdNo.Name = "lblExpAccountIdNo"
        Me.lblExpAccountIdNo.Size = New System.Drawing.Size(153, 23)
        Me.lblExpAccountIdNo.TabIndex = 236
        Me.lblExpAccountIdNo.Text = "Default Purchase Acct."
        Me.lblExpAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblExpAccountIdNo.Translatable = true
        '
        'cacExpAccountIdNo
        '
        Me.cacExpAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacExpAccountIdNo.BegFindValue = Nothing
        Me.cacExpAccountIdNo.ChangingSearchValueOnly = false
        Me.cacExpAccountIdNo.CurrentSearchTerm = ""
        Me.cacExpAccountIdNo.DataValue = Nothing
        Me.cacExpAccountIdNo.DefaultValue = Nothing
        Me.cacExpAccountIdNo.DisplayMember = "Name"
        Me.cacExpAccountIdNo.EditingMode = false
        Me.cacExpAccountIdNo.EndFindValue = Nothing
        Me.cacExpAccountIdNo.FieldDescription = Nothing
        Me.cacExpAccountIdNo.FieldName = Nothing
        Me.cacExpAccountIdNo.FilterRule = Nothing
        Me.cacExpAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacExpAccountIdNo.FindEnabled = false
        Me.cacExpAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacExpAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacExpAccountIdNo.FormattingEnabled = true
        Me.cacExpAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacExpAccountIdNo.IgnoreCase = false
        Me.cacExpAccountIdNo.IntegralHeight = false
        Me.cacExpAccountIdNo.LinkedLabel = Nothing
        Me.cacExpAccountIdNo.Location = New System.Drawing.Point(166, 313)
        Me.cacExpAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacExpAccountIdNo.Name = "cacExpAccountIdNo"
        Me.cacExpAccountIdNo.OldValue = 0
        Me.cacExpAccountIdNo.OriginalDataSource = Nothing
        Me.cacExpAccountIdNo.OriginalList = Nothing
        Me.cacExpAccountIdNo.OverrideDropDownStyleList = false
        Me.cacExpAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacExpAccountIdNo.PropertySelector = Nothing
        Me.cacExpAccountIdNo.ReadOnlyCombo = false
        Me.cacExpAccountIdNo.Size = New System.Drawing.Size(194, 24)
        Me.cacExpAccountIdNo.SuggestBoxHeight = 200
        Me.cacExpAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacExpAccountIdNo.TabIndex = 23
        Me.cacExpAccountIdNo.TabStop = false
        Me.cacExpAccountIdNo.TextToSearch = Nothing
        Me.cacExpAccountIdNo.Translatable = false
        Me.cacExpAccountIdNo.ValueIsMandatory = false
        Me.cacExpAccountIdNo.ValueIsNullable = false
        Me.cacExpAccountIdNo.ValueIsNumeric = false
        Me.cacExpAccountIdNo.ValueMember = "IdNo"
        '
        'lblApAccountIdNo
        '
        Me.lblApAccountIdNo.DisplayOnly = true
        Me.lblApAccountIdNo.EditingMode = false
        Me.lblApAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblApAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApAccountIdNo.Location = New System.Drawing.Point(362, 313)
        Me.lblApAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApAccountIdNo.Name = "lblApAccountIdNo"
        Me.lblApAccountIdNo.Size = New System.Drawing.Size(148, 23)
        Me.lblApAccountIdNo.TabIndex = 234
        Me.lblApAccountIdNo.Text = "Override AP Account"
        Me.lblApAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblApAccountIdNo.Translatable = true
        '
        'cacApAccountIdNo
        '
        Me.cacApAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cacApAccountIdNo.BegFindValue = Nothing
        Me.cacApAccountIdNo.ChangingSearchValueOnly = false
        Me.cacApAccountIdNo.CurrentSearchTerm = ""
        Me.cacApAccountIdNo.DataValue = Nothing
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
        Me.cacApAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacApAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacApAccountIdNo.FormattingEnabled = true
        Me.cacApAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cacApAccountIdNo.IgnoreCase = false
        Me.cacApAccountIdNo.IntegralHeight = false
        Me.cacApAccountIdNo.LinkedLabel = Nothing
        Me.cacApAccountIdNo.Location = New System.Drawing.Point(512, 313)
        Me.cacApAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacApAccountIdNo.Name = "cacApAccountIdNo"
        Me.cacApAccountIdNo.OldValue = 0
        Me.cacApAccountIdNo.OriginalDataSource = Nothing
        Me.cacApAccountIdNo.OriginalList = Nothing
        Me.cacApAccountIdNo.OverrideDropDownStyleList = false
        Me.cacApAccountIdNo.PreviousSearchTerm = Nothing
        Me.cacApAccountIdNo.PropertySelector = Nothing
        Me.cacApAccountIdNo.ReadOnlyCombo = false
        Me.cacApAccountIdNo.Size = New System.Drawing.Size(204, 24)
        Me.cacApAccountIdNo.SuggestBoxHeight = 200
        Me.cacApAccountIdNo.SuggestListOrderRule = Nothing
        Me.cacApAccountIdNo.TabIndex = 24
        Me.cacApAccountIdNo.TextToSearch = Nothing
        Me.cacApAccountIdNo.Translatable = false
        Me.cacApAccountIdNo.ValueIsMandatory = false
        Me.cacApAccountIdNo.ValueIsNullable = false
        Me.cacApAccountIdNo.ValueIsNumeric = false
        Me.cacApAccountIdNo.ValueMember = "IdNo"
        '
        'lblCreditLimit
        '
        Me.lblCreditLimit.DisplayOnly = true
        Me.lblCreditLimit.EditingMode = false
        Me.lblCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCreditLimit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCreditLimit.Location = New System.Drawing.Point(11, 339)
        Me.lblCreditLimit.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCreditLimit.Name = "lblCreditLimit"
        Me.lblCreditLimit.Size = New System.Drawing.Size(153, 23)
        Me.lblCreditLimit.TabIndex = 222
        Me.lblCreditLimit.Text = "Credit Limit"
        Me.lblCreditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCreditLimit.Translatable = true
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
        Me.txtCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCreditLimit.ForeColor = System.Drawing.Color.Black
        Me.txtCreditLimit.LinkedLabel = Me.lblCreditLimit
        Me.txtCreditLimit.Location = New System.Drawing.Point(166, 339)
        Me.txtCreditLimit.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCreditLimit.MaximumValue = Nothing
        Me.txtCreditLimit.MinimumValue = Nothing
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.OldValue = Nothing
        Me.txtCreditLimit.ReadOnly = true
        Me.txtCreditLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCreditLimit.Size = New System.Drawing.Size(194, 23)
        Me.txtCreditLimit.TabIndex = 25
        Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCreditLimit.Translatable = false
        Me.txtCreditLimit.ValueIsNumeric = true
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.DisplayOnly = true
        Me.lblPaymentMethod.EditingMode = false
        Me.lblPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPaymentMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPaymentMethod.Location = New System.Drawing.Point(362, 339)
        Me.lblPaymentMethod.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(148, 21)
        Me.lblPaymentMethod.TabIndex = 168
        Me.lblPaymentMethod.Text = "Payment Method"
        Me.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPaymentMethod.Translatable = true
        '
        'cacPaymentMethod
        '
        Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
        Me.cacPaymentMethod.BegFindValue = Nothing
        Me.cacPaymentMethod.ChangingSearchValueOnly = false
        Me.cacPaymentMethod.CurrentSearchTerm = ""
        Me.cacPaymentMethod.DataValue = Nothing
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
        Me.cacPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.cacPaymentMethod.FormattingEnabled = true
        Me.cacPaymentMethod.HideWhenNotEditingOrAdding = false
        Me.cacPaymentMethod.IgnoreCase = false
        Me.cacPaymentMethod.IntegralHeight = false
        Me.cacPaymentMethod.LinkedLabel = Nothing
        Me.cacPaymentMethod.Location = New System.Drawing.Point(512, 339)
        Me.cacPaymentMethod.Margin = New System.Windows.Forms.Padding(1)
        Me.cacPaymentMethod.Name = "cacPaymentMethod"
        Me.cacPaymentMethod.OldValue = 0
        Me.cacPaymentMethod.OriginalDataSource = Nothing
        Me.cacPaymentMethod.OriginalList = Nothing
        Me.cacPaymentMethod.OverrideDropDownStyleList = false
        Me.cacPaymentMethod.PreviousSearchTerm = Nothing
        Me.cacPaymentMethod.PropertySelector = Nothing
        Me.cacPaymentMethod.ReadOnlyCombo = false
        Me.cacPaymentMethod.Size = New System.Drawing.Size(204, 24)
        Me.cacPaymentMethod.SuggestBoxHeight = 200
        Me.cacPaymentMethod.SuggestListOrderRule = Nothing
        Me.cacPaymentMethod.TabIndex = 26
        Me.cacPaymentMethod.TextToSearch = Nothing
        Me.cacPaymentMethod.Translatable = false
        Me.cacPaymentMethod.ValueIsMandatory = false
        Me.cacPaymentMethod.ValueIsNullable = false
        Me.cacPaymentMethod.ValueIsNumeric = false
        Me.cacPaymentMethod.ValueMember = "Code"
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.DisplayOnly = true
        Me.lblOpeningBalance.EditingMode = false
        Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblOpeningBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOpeningBalance.Location = New System.Drawing.Point(11, 365)
        Me.lblOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        Me.lblOpeningBalance.Size = New System.Drawing.Size(153, 23)
        Me.lblOpeningBalance.TabIndex = 30
        Me.lblOpeningBalance.Text = "Opening Balance"
        Me.lblOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOpeningBalance.Translatable = true
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
        Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtOpeningBalance.Location = New System.Drawing.Point(166, 365)
        Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOpeningBalance.MaximumValue = Nothing
        Me.txtOpeningBalance.MinimumValue = Nothing
        Me.txtOpeningBalance.Name = "txtOpeningBalance"
        Me.txtOpeningBalance.OldValue = Nothing
        Me.txtOpeningBalance.ReadOnly = true
        Me.txtOpeningBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtOpeningBalance.Size = New System.Drawing.Size(195, 23)
        Me.txtOpeningBalance.TabIndex = 27
        Me.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOpeningBalance.Translatable = false
        Me.txtOpeningBalance.ValueIsNumeric = true
        '
        'lblSettlementDueDays
        '
        Me.lblSettlementDueDays.DisplayOnly = true
        Me.lblSettlementDueDays.EditingMode = false
        Me.lblSettlementDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSettlementDueDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSettlementDueDays.Location = New System.Drawing.Point(363, 365)
        Me.lblSettlementDueDays.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSettlementDueDays.Name = "lblSettlementDueDays"
        Me.lblSettlementDueDays.Size = New System.Drawing.Size(244, 23)
        Me.lblSettlementDueDays.TabIndex = 224
        Me.lblSettlementDueDays.Text = "Early Settlement Due Days"
        Me.lblSettlementDueDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSettlementDueDays.Translatable = true
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
        Me.txtSettlementDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSettlementDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDueDays.IgnoreNullCheck = true
        Me.txtSettlementDueDays.LinkedLabel = Me.lblSettlementDueDays
        Me.txtSettlementDueDays.Location = New System.Drawing.Point(609, 365)
        Me.txtSettlementDueDays.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSettlementDueDays.MaximumValue = Nothing
        Me.txtSettlementDueDays.MinimumValue = Nothing
        Me.txtSettlementDueDays.Name = "txtSettlementDueDays"
        Me.txtSettlementDueDays.OldValue = Nothing
        Me.txtSettlementDueDays.ReadOnly = true
        Me.txtSettlementDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSettlementDueDays.Size = New System.Drawing.Size(106, 23)
        Me.txtSettlementDueDays.TabIndex = 28
        Me.txtSettlementDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSettlementDueDays.Translatable = false
        '
        'lblPaymentDueDays
        '
        Me.lblPaymentDueDays.DisplayOnly = true
        Me.lblPaymentDueDays.EditingMode = false
        Me.lblPaymentDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPaymentDueDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPaymentDueDays.Location = New System.Drawing.Point(11, 390)
        Me.lblPaymentDueDays.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPaymentDueDays.Name = "lblPaymentDueDays"
        Me.lblPaymentDueDays.Size = New System.Drawing.Size(153, 23)
        Me.lblPaymentDueDays.TabIndex = 160
        Me.lblPaymentDueDays.Text = "Payment Due Days"
        Me.lblPaymentDueDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPaymentDueDays.Translatable = true
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
        Me.txtPaymentDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPaymentDueDays.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentDueDays.IgnoreNullCheck = true
        Me.txtPaymentDueDays.LinkedLabel = Me.lblPaymentDueDays
        Me.txtPaymentDueDays.Location = New System.Drawing.Point(166, 390)
        Me.txtPaymentDueDays.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPaymentDueDays.MaximumValue = Nothing
        Me.txtPaymentDueDays.MinimumValue = Nothing
        Me.txtPaymentDueDays.Name = "txtPaymentDueDays"
        Me.txtPaymentDueDays.OldValue = Nothing
        Me.txtPaymentDueDays.ReadOnly = true
        Me.txtPaymentDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPaymentDueDays.Size = New System.Drawing.Size(103, 23)
        Me.txtPaymentDueDays.TabIndex = 29
        Me.txtPaymentDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPaymentDueDays.Translatable = false
        '
        'lblSettlementDiscount
        '
        Me.lblSettlementDiscount.DisplayOnly = true
        Me.lblSettlementDiscount.EditingMode = false
        Me.lblSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSettlementDiscount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSettlementDiscount.Location = New System.Drawing.Point(271, 390)
        Me.lblSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSettlementDiscount.Name = "lblSettlementDiscount"
        Me.lblSettlementDiscount.Size = New System.Drawing.Size(238, 23)
        Me.lblSettlementDiscount.TabIndex = 230
        Me.lblSettlementDiscount.Text = "Early Settlement Discount Rate (%)"
        Me.lblSettlementDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSettlementDiscount.Translatable = true
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
        Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDiscount.IgnoreNullCheck = true
        Me.txtSettlementDiscount.LinkedLabel = Me.lblSettlementDiscount
        Me.txtSettlementDiscount.Location = New System.Drawing.Point(511, 390)
        Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSettlementDiscount.MaximumValue = Nothing
        Me.txtSettlementDiscount.MinimumValue = Nothing
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.ReadOnly = true
        Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSettlementDiscount.Size = New System.Drawing.Size(40, 23)
        Me.txtSettlementDiscount.TabIndex = 30
        Me.txtSettlementDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSettlementDiscount.Translatable = false
        Me.txtSettlementDiscount.ValueIsNumeric = true
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel3.Location = New System.Drawing.Point(553, 390)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(17, 23)
        Me.CLabel3.TabIndex = 226
        Me.CLabel3.Text = "%"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'lblActive
        '
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActive.Location = New System.Drawing.Point(572, 390)
        Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(118, 23)
        Me.lblActive.TabIndex = 239
        Me.lblActive.Text = "Active Account?"
        Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblActive.Translatable = true
        '
        'chkActive
        '
        Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkActive.AutoCheck = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.BegFindValue = Nothing
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.chkActive.EndFindValue = Nothing
        Me.chkActive.FieldDescription = Nothing
        Me.chkActive.FieldName = Nothing
        Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkActive.FindEnabled = false
        Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.floDataDisplay.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.IFindableControl_FindEnabled = false
        Me.chkActive.IgnoreCase = false
        Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Location = New System.Drawing.Point(692, 390)
        Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkActive.Size = New System.Drawing.Size(13, 13)
        Me.chkActive.TabIndex = 33
        Me.chkActive.Text = " "
        Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Translatable = false
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'lblDateAccountOpen
        '
        Me.lblDateAccountOpen.DisplayOnly = true
        Me.lblDateAccountOpen.EditingMode = false
        Me.lblDateAccountOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDateAccountOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateAccountOpen.Location = New System.Drawing.Point(11, 415)
        Me.lblDateAccountOpen.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateAccountOpen.Name = "lblDateAccountOpen"
        Me.lblDateAccountOpen.Size = New System.Drawing.Size(153, 23)
        Me.lblDateAccountOpen.TabIndex = 232
        Me.lblDateAccountOpen.Text = "Date Account Opening"
        Me.lblDateAccountOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateAccountOpen.Translatable = true
        '
        'dtpDateAccountOpen
        '
        Me.dtpDateAccountOpen.AutoSize = true
        Me.dtpDateAccountOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpDateAccountOpen.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpDateAccountOpen.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateAccountOpen.DefaultValue = Nothing
        Me.dtpDateAccountOpen.DisplayOnly = false
        Me.dtpDateAccountOpen.DtpDefaultValue = Nothing
        Me.dtpDateAccountOpen.EditingMode = false
        Me.dtpDateAccountOpen.EditsAllowed = false
        Me.dtpDateAccountOpen.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpDateAccountOpen.ForeColor = System.Drawing.Color.Black
        Me.dtpDateAccountOpen.LinkedLabel = Nothing
        Me.dtpDateAccountOpen.Location = New System.Drawing.Point(165, 414)
        Me.dtpDateAccountOpen.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDateAccountOpen.Name = "dtpDateAccountOpen"
        Me.dtpDateAccountOpen.ReadOnlyDp = false
        Me.dtpDateAccountOpen.SecurityKey = Nothing
        Me.dtpDateAccountOpen.ShowLongDate = false
        Me.dtpDateAccountOpen.ShowTime = false
        Me.dtpDateAccountOpen.Size = New System.Drawing.Size(123, 23)
        Me.dtpDateAccountOpen.TabIndex = 31
        Me.dtpDateAccountOpen.TargetCalendar = CType(resources.GetObject("dtpDateAccountOpen.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateAccountOpen.Translatable = false
        Me.dtpDateAccountOpen.Value = Nothing
        Me.dtpDateAccountOpen.ValueIsMandatory = false
        Me.dtpDateAccountOpen.ValueIsNullable = false
        '
        'lblAccountStatus
        '
        Me.lblAccountStatus.DisplayOnly = true
        Me.lblAccountStatus.EditingMode = false
        Me.lblAccountStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountStatus.Location = New System.Drawing.Point(289, 415)
        Me.lblAccountStatus.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountStatus.Name = "lblAccountStatus"
        Me.lblAccountStatus.Size = New System.Drawing.Size(218, 20)
        Me.lblAccountStatus.TabIndex = 238
        Me.lblAccountStatus.Text = "Account Status"
        Me.lblAccountStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAccountStatus.Translatable = true
        '
        'cacAccountStatus
        '
        Me.cacAccountStatus.BackColor = System.Drawing.Color.White
        Me.cacAccountStatus.BegFindValue = Nothing
        Me.cacAccountStatus.ChangingSearchValueOnly = false
        Me.cacAccountStatus.CurrentSearchTerm = ""
        Me.cacAccountStatus.DataValue = Nothing
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
        Me.cacAccountStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacAccountStatus.ForeColor = System.Drawing.Color.Black
        Me.cacAccountStatus.FormattingEnabled = true
        Me.cacAccountStatus.HideWhenNotEditingOrAdding = false
        Me.cacAccountStatus.IgnoreCase = false
        Me.cacAccountStatus.IntegralHeight = false
        Me.cacAccountStatus.LinkedLabel = Nothing
        Me.cacAccountStatus.Location = New System.Drawing.Point(509, 415)
        Me.cacAccountStatus.Margin = New System.Windows.Forms.Padding(1)
        Me.cacAccountStatus.Name = "cacAccountStatus"
        Me.cacAccountStatus.OldValue = 0
        Me.cacAccountStatus.OriginalDataSource = Nothing
        Me.cacAccountStatus.OriginalList = Nothing
        Me.cacAccountStatus.OverrideDropDownStyleList = false
        Me.cacAccountStatus.PreviousSearchTerm = Nothing
        Me.cacAccountStatus.PropertySelector = Nothing
        Me.cacAccountStatus.ReadOnlyCombo = false
        Me.cacAccountStatus.Size = New System.Drawing.Size(204, 24)
        Me.cacAccountStatus.SuggestBoxHeight = 200
        Me.cacAccountStatus.SuggestListOrderRule = Nothing
        Me.cacAccountStatus.TabIndex = 32
        Me.cacAccountStatus.TextToSearch = Nothing
        Me.cacAccountStatus.Translatable = false
        Me.cacAccountStatus.ValueIsMandatory = false
        Me.cacAccountStatus.ValueIsNullable = false
        Me.cacAccountStatus.ValueIsNumeric = false
        Me.cacAccountStatus.ValueMember = "Code"
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(11, 442)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(153, 23)
        Me.lblNotes.TabIndex = 159
        Me.lblNotes.Text = "Balance"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNotes.Translatable = true
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
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtBalance.Location = New System.Drawing.Point(166, 442)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.txtBalance.MaximumValue = Nothing
        Me.txtBalance.MinimumValue = Nothing
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.OldValue = Nothing
        Me.txtBalance.ReadOnly = true
        Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBalance.Size = New System.Drawing.Size(103, 23)
        Me.txtBalance.TabIndex = 43
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBalance.Translatable = false
        Me.txtBalance.ValueIsNumeric = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(11, 467)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(153, 23)
        Me.CLabel1.TabIndex = 240
        Me.CLabel1.Text = "Notes"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(166, 467)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(549, 23)
        Me.txtNotes.TabIndex = 44
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'SupplierEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1078, 555)
        Me.Name = "SupplierEntryTv"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Supplier Maintenance Form"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floDataDisplay As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSupplierCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblVatNumber As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtVatNumber As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSupplierName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSupplierName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSupplierNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSupplierNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents lblContactPerson As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtContactPerson As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblContactDesignation As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtContactDesignation As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblStreet As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStreet As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDistrict As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDistrict As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblTownCity As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTownCity As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblProvinceState As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtProvinceState As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPoBox As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPoBox As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblZipCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtZipCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCountryCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacCountryCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPhone1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPhone1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPhone2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPhone2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblFax As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtFax As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblMobile As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtMobile As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmail As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmail As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblWebsite As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtWebsite As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCrNumber As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtCrNumber As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblBankIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacBankIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBankAccountNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBankAccountNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIban As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIban As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblExpAccountIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacExpAccountIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblApAccountIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacApAccountIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblCreditLimit As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtCreditLimit As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPaymentMethod As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacPaymentMethod As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblOpeningBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtOpeningBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSettlementDueDays As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSettlementDueDays As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPaymentDueDays As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPaymentDueDays As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSettlementDiscount As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSettlementDiscount As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblActive As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkActive As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents lblDateAccountOpen As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpDateAccountOpen As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblAccountStatus As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacAccountStatus As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End NameSpace