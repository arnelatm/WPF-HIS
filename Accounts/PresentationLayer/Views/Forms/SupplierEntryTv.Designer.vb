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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(153, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Id No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.TxtIdNo.Enabled = False
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(166, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierCode.Location = New System.Drawing.Point(230, 11)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(79, 23)
            Me.lblSupplierCode.TabIndex = 156
            Me.lblSupplierCode.Text = "Code"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSupplierCode.Translatable = True
            '
            'txtSupplierCode
            '
            Me.txtSupplierCode.BackColor = System.Drawing.Color.White
            Me.txtSupplierCode.BegFindValue = Nothing
            Me.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierCode.ComputedValue = False
            Me.txtSupplierCode.CustomFormat = Nothing
            Me.txtSupplierCode.DataBoundControl = True
            Me.txtSupplierCode.EditingMode = False
            Me.txtSupplierCode.EndFindValue = Nothing
            Me.txtSupplierCode.FieldDescription = Nothing
            Me.txtSupplierCode.FieldName = Nothing
            Me.txtSupplierCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierCode.FindEnabled = True
            Me.txtSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSupplierCode.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierCode.LinkedLabel = Me.lblSupplierCode
            Me.txtSupplierCode.Location = New System.Drawing.Point(311, 11)
            Me.txtSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSupplierCode.MaximumValue = Nothing
            Me.txtSupplierCode.MinimumValue = Nothing
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.txtSupplierCode.OldValue = Nothing
            Me.txtSupplierCode.ReadOnly = True
            Me.txtSupplierCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierCode.Size = New System.Drawing.Size(127, 23)
            Me.txtSupplierCode.TabIndex = 0
            Me.txtSupplierCode.Translatable = False
            Me.txtSupplierCode.ValueIsMandatory = True
            Me.txtSupplierCode.ValueIsUnique = True
            '
            'lblVatNumber
            '
            Me.lblVatNumber.DisplayOnly = True
            Me.lblVatNumber.EditingMode = False
            Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNumber.Location = New System.Drawing.Point(440, 11)
            Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNumber.Name = "lblVatNumber"
            Me.lblVatNumber.Size = New System.Drawing.Size(68, 23)
            Me.lblVatNumber.TabIndex = 209
            Me.lblVatNumber.Text = "VAT No."
            Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblVatNumber.Translatable = True
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
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
            Me.txtVatNumber.Location = New System.Drawing.Point(510, 11)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(205, 23)
            Me.txtVatNumber.TabIndex = 1
            Me.txtVatNumber.Translatable = False
            '
            'lblSupplierName
            '
            Me.lblSupplierName.DisplayOnly = True
            Me.lblSupplierName.EditingMode = False
            Me.lblSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierName.Location = New System.Drawing.Point(11, 36)
            Me.lblSupplierName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierName.Name = "lblSupplierName"
            Me.lblSupplierName.Size = New System.Drawing.Size(153, 23)
            Me.lblSupplierName.TabIndex = 157
            Me.lblSupplierName.Text = "Name"
            Me.lblSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierName.Translatable = True
            '
            'txtSupplierName
            '
            Me.txtSupplierName.BackColor = System.Drawing.Color.White
            Me.txtSupplierName.BegFindValue = Nothing
            Me.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierName.ComputedValue = False
            Me.txtSupplierName.CustomFormat = Nothing
            Me.txtSupplierName.DataBoundControl = True
            Me.txtSupplierName.EditingMode = False
            Me.txtSupplierName.EndFindValue = Nothing
            Me.txtSupplierName.FieldDescription = Nothing
            Me.txtSupplierName.FieldName = Nothing
            Me.txtSupplierName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSupplierName, True)
            Me.txtSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSupplierName.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierName.LinkedLabel = Me.lblSupplierName
            Me.txtSupplierName.Location = New System.Drawing.Point(166, 36)
            Me.txtSupplierName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSupplierName.MaximumValue = Nothing
            Me.txtSupplierName.MinimumValue = Nothing
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.OldValue = Nothing
            Me.txtSupplierName.ReadOnly = True
            Me.txtSupplierName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierName.Size = New System.Drawing.Size(550, 23)
            Me.txtSupplierName.TabIndex = 2
            Me.txtSupplierName.Translatable = False
            Me.txtSupplierName.ValueIsMandatory = True
            Me.txtSupplierName.ValueIsUnique = True
            '
            'lblSupplierNameAra
            '
            Me.lblSupplierNameAra.DisplayOnly = True
            Me.lblSupplierNameAra.EditingMode = False
            Me.lblSupplierNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierNameAra.Location = New System.Drawing.Point(11, 61)
            Me.lblSupplierNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierNameAra.Name = "lblSupplierNameAra"
            Me.lblSupplierNameAra.Size = New System.Drawing.Size(153, 23)
            Me.lblSupplierNameAra.TabIndex = 158
            Me.lblSupplierNameAra.Text = "Name (Arabic)"
            Me.lblSupplierNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierNameAra.Translatable = True
            '
            'txtSupplierNameAra
            '
            Me.txtSupplierNameAra.BackColor = System.Drawing.Color.White
            Me.txtSupplierNameAra.BegFindValue = Nothing
            Me.txtSupplierNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierNameAra.ComputedValue = False
            Me.txtSupplierNameAra.CustomFormat = Nothing
            Me.txtSupplierNameAra.DataBoundControl = True
            Me.txtSupplierNameAra.EditingMode = False
            Me.txtSupplierNameAra.EndFindValue = Nothing
            Me.txtSupplierNameAra.EnglishControl = Me.txtSupplierName
            Me.txtSupplierNameAra.FieldDescription = Nothing
            Me.txtSupplierNameAra.FieldName = Nothing
            Me.txtSupplierNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtSupplierNameAra, True)
            Me.txtSupplierNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSupplierNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierNameAra.LinkedLabel = Me.lblSupplierNameAra
            Me.txtSupplierNameAra.Location = New System.Drawing.Point(166, 61)
            Me.txtSupplierNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSupplierNameAra.MaximumValue = Nothing
            Me.txtSupplierNameAra.MinimumValue = Nothing
            Me.txtSupplierNameAra.Name = "txtSupplierNameAra"
            Me.txtSupplierNameAra.OldValue = Nothing
            Me.txtSupplierNameAra.ReadOnly = True
            Me.txtSupplierNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtSupplierNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierNameAra.Size = New System.Drawing.Size(549, 23)
            Me.txtSupplierNameAra.TabIndex = 3
            Me.txtSupplierNameAra.Translatable = False
            Me.txtSupplierNameAra.ValueIsMandatory = True
            Me.txtSupplierNameAra.ValueIsUnique = True
            '
            'lblContactPerson
            '
            Me.lblContactPerson.DisplayOnly = True
            Me.lblContactPerson.EditingMode = False
            Me.lblContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblContactPerson.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblContactPerson.Location = New System.Drawing.Point(11, 86)
            Me.lblContactPerson.Margin = New System.Windows.Forms.Padding(1)
            Me.lblContactPerson.Name = "lblContactPerson"
            Me.lblContactPerson.Size = New System.Drawing.Size(153, 23)
            Me.lblContactPerson.TabIndex = 183
            Me.lblContactPerson.Text = "Contact Person"
            Me.lblContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblContactPerson.Translatable = True
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
            Me.txtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
            Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
            Me.txtContactPerson.Location = New System.Drawing.Point(166, 86)
            Me.txtContactPerson.Margin = New System.Windows.Forms.Padding(1)
            Me.txtContactPerson.MaximumValue = Nothing
            Me.txtContactPerson.MinimumValue = Nothing
            Me.txtContactPerson.Name = "txtContactPerson"
            Me.txtContactPerson.OldValue = Nothing
            Me.txtContactPerson.ReadOnly = True
            Me.txtContactPerson.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtContactPerson.Size = New System.Drawing.Size(194, 23)
            Me.txtContactPerson.TabIndex = 4
            Me.txtContactPerson.Translatable = False
            '
            'lblContactDesignation
            '
            Me.lblContactDesignation.DisplayOnly = True
            Me.lblContactDesignation.EditingMode = False
            Me.lblContactDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblContactDesignation.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblContactDesignation.Location = New System.Drawing.Point(362, 86)
            Me.lblContactDesignation.Margin = New System.Windows.Forms.Padding(1)
            Me.lblContactDesignation.Name = "lblContactDesignation"
            Me.lblContactDesignation.Size = New System.Drawing.Size(148, 23)
            Me.lblContactDesignation.TabIndex = 185
            Me.lblContactDesignation.Text = "Contact Designation"
            Me.lblContactDesignation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblContactDesignation.Translatable = True
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
            Me.txtContactDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtContactDesignation.ForeColor = System.Drawing.Color.Black
            Me.txtContactDesignation.LinkedLabel = Me.lblContactDesignation
            Me.txtContactDesignation.Location = New System.Drawing.Point(512, 86)
            Me.txtContactDesignation.Margin = New System.Windows.Forms.Padding(1)
            Me.txtContactDesignation.MaximumValue = Nothing
            Me.txtContactDesignation.MinimumValue = Nothing
            Me.txtContactDesignation.Name = "txtContactDesignation"
            Me.txtContactDesignation.OldValue = Nothing
            Me.txtContactDesignation.ReadOnly = True
            Me.txtContactDesignation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtContactDesignation.Size = New System.Drawing.Size(204, 23)
            Me.txtContactDesignation.TabIndex = 5
            Me.txtContactDesignation.Translatable = False
            '
            'lblStreet
            '
            Me.lblStreet.DisplayOnly = True
            Me.lblStreet.EditingMode = False
            Me.lblStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStreet.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblStreet.Location = New System.Drawing.Point(11, 111)
            Me.lblStreet.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStreet.Name = "lblStreet"
            Me.lblStreet.Size = New System.Drawing.Size(153, 23)
            Me.lblStreet.TabIndex = 187
            Me.lblStreet.Text = "Street "
            Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStreet.Translatable = True
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
            Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStreet.ForeColor = System.Drawing.Color.Black
            Me.txtStreet.LinkedLabel = Me.lblStreet
            Me.txtStreet.Location = New System.Drawing.Point(166, 111)
            Me.txtStreet.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStreet.MaximumValue = Nothing
            Me.txtStreet.MinimumValue = Nothing
            Me.txtStreet.Name = "txtStreet"
            Me.txtStreet.OldValue = Nothing
            Me.txtStreet.ReadOnly = True
            Me.txtStreet.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStreet.Size = New System.Drawing.Size(194, 23)
            Me.txtStreet.TabIndex = 6
            Me.txtStreet.Translatable = False
            '
            'lblDistrict
            '
            Me.lblDistrict.DisplayOnly = True
            Me.lblDistrict.EditingMode = False
            Me.lblDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDistrict.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDistrict.Location = New System.Drawing.Point(362, 111)
            Me.lblDistrict.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDistrict.Name = "lblDistrict"
            Me.lblDistrict.Size = New System.Drawing.Size(148, 23)
            Me.lblDistrict.TabIndex = 189
            Me.lblDistrict.Text = "District"
            Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblDistrict.Translatable = True
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
            Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDistrict.ForeColor = System.Drawing.Color.Black
            Me.txtDistrict.LinkedLabel = Me.lblDistrict
            Me.txtDistrict.Location = New System.Drawing.Point(512, 111)
            Me.txtDistrict.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDistrict.MaximumValue = Nothing
            Me.txtDistrict.MinimumValue = Nothing
            Me.txtDistrict.Name = "txtDistrict"
            Me.txtDistrict.OldValue = Nothing
            Me.txtDistrict.ReadOnly = True
            Me.txtDistrict.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDistrict.Size = New System.Drawing.Size(204, 23)
            Me.txtDistrict.TabIndex = 7
            Me.txtDistrict.Translatable = False
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTownCity.Location = New System.Drawing.Point(11, 136)
            Me.lblTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTownCity.Name = "lblTownCity"
            Me.lblTownCity.Size = New System.Drawing.Size(153, 23)
            Me.lblTownCity.TabIndex = 191
            Me.lblTownCity.Text = "Town/City"
            Me.lblTownCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblTownCity.Translatable = True
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
            Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Me.lblTownCity
            Me.txtTownCity.Location = New System.Drawing.Point(166, 136)
            Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTownCity.MaximumValue = Nothing
            Me.txtTownCity.MinimumValue = Nothing
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.ReadOnly = True
            Me.txtTownCity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTownCity.Size = New System.Drawing.Size(194, 23)
            Me.txtTownCity.TabIndex = 8
            Me.txtTownCity.Translatable = False
            '
            'lblProvinceState
            '
            Me.lblProvinceState.DisplayOnly = True
            Me.lblProvinceState.EditingMode = False
            Me.lblProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblProvinceState.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblProvinceState.Location = New System.Drawing.Point(362, 136)
            Me.lblProvinceState.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProvinceState.Name = "lblProvinceState"
            Me.lblProvinceState.Size = New System.Drawing.Size(148, 23)
            Me.lblProvinceState.TabIndex = 193
            Me.lblProvinceState.Text = "Province/State"
            Me.lblProvinceState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblProvinceState.Translatable = True
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
            Me.txtProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
            Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
            Me.txtProvinceState.Location = New System.Drawing.Point(512, 136)
            Me.txtProvinceState.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProvinceState.MaximumValue = Nothing
            Me.txtProvinceState.MinimumValue = Nothing
            Me.txtProvinceState.Name = "txtProvinceState"
            Me.txtProvinceState.OldValue = Nothing
            Me.txtProvinceState.ReadOnly = True
            Me.txtProvinceState.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProvinceState.Size = New System.Drawing.Size(204, 23)
            Me.txtProvinceState.TabIndex = 9
            Me.txtProvinceState.Translatable = False
            '
            'lblPoBox
            '
            Me.lblPoBox.DisplayOnly = True
            Me.lblPoBox.EditingMode = False
            Me.lblPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPoBox.Location = New System.Drawing.Point(11, 161)
            Me.lblPoBox.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPoBox.Name = "lblPoBox"
            Me.lblPoBox.Size = New System.Drawing.Size(153, 23)
            Me.lblPoBox.TabIndex = 199
            Me.lblPoBox.Text = "P.O. Box Number"
            Me.lblPoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPoBox.Translatable = True
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
            Me.txtPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPoBox.ForeColor = System.Drawing.Color.Black
            Me.txtPoBox.LinkedLabel = Me.lblPoBox
            Me.txtPoBox.Location = New System.Drawing.Point(166, 161)
            Me.txtPoBox.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPoBox.MaximumValue = Nothing
            Me.txtPoBox.MinimumValue = Nothing
            Me.txtPoBox.Name = "txtPoBox"
            Me.txtPoBox.OldValue = Nothing
            Me.txtPoBox.ReadOnly = True
            Me.txtPoBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPoBox.Size = New System.Drawing.Size(62, 23)
            Me.txtPoBox.TabIndex = 10
            Me.txtPoBox.Translatable = False
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblZipCode.Location = New System.Drawing.Point(230, 161)
            Me.lblZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(68, 23)
            Me.lblZipCode.TabIndex = 197
            Me.lblZipCode.Text = "Zip Code"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblZipCode.Translatable = True
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
            Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Me.lblZipCode
            Me.txtZipCode.Location = New System.Drawing.Point(300, 161)
            Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtZipCode.MaximumValue = Nothing
            Me.txtZipCode.MinimumValue = Nothing
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.ReadOnly = True
            Me.txtZipCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtZipCode.Size = New System.Drawing.Size(61, 23)
            Me.txtZipCode.TabIndex = 11
            Me.txtZipCode.Translatable = False
            '
            'lblCountryCode
            '
            Me.lblCountryCode.DisplayOnly = True
            Me.lblCountryCode.EditingMode = False
            Me.lblCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCountryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCountryCode.Location = New System.Drawing.Point(363, 161)
            Me.lblCountryCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCountryCode.Name = "lblCountryCode"
            Me.lblCountryCode.Size = New System.Drawing.Size(148, 23)
            Me.lblCountryCode.TabIndex = 195
            Me.lblCountryCode.Text = "Country"
            Me.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCountryCode.Translatable = True
            '
            'cacCountryCode
            '
            Me.cacCountryCode.BackColor = System.Drawing.Color.White
            Me.cacCountryCode.BegFindValue = Nothing
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DataValue = Nothing
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
            Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.IgnoreCase = False
            Me.cacCountryCode.IntegralHeight = False
            Me.cacCountryCode.LinkedLabel = Nothing
            Me.cacCountryCode.Location = New System.Drawing.Point(513, 161)
            Me.cacCountryCode.Margin = New System.Windows.Forms.Padding(1)
            Me.cacCountryCode.Name = "cacCountryCode"
            Me.cacCountryCode.OldValue = 0
            Me.cacCountryCode.OriginalDataSource = Nothing
            Me.cacCountryCode.OriginalList = Nothing
            Me.cacCountryCode.OverrideDropDownStyleList = False
            Me.cacCountryCode.PreviousSearchTerm = Nothing
            Me.cacCountryCode.PropertySelector = Nothing
            Me.cacCountryCode.ReadOnlyCombo = False
            Me.cacCountryCode.Size = New System.Drawing.Size(203, 24)
            Me.cacCountryCode.SuggestBoxHeight = 200
            Me.cacCountryCode.SuggestListOrderRule = Nothing
            Me.cacCountryCode.TabIndex = 12
            Me.cacCountryCode.TextToSearch = Nothing
            Me.cacCountryCode.Translatable = False
            Me.cacCountryCode.ValueIsMandatory = False
            Me.cacCountryCode.ValueIsNullable = False
            Me.cacCountryCode.ValueIsNumeric = False
            Me.cacCountryCode.ValueMember = "Code"
            '
            'lblPhone1
            '
            Me.lblPhone1.DisplayOnly = True
            Me.lblPhone1.EditingMode = False
            Me.lblPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhone1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPhone1.Location = New System.Drawing.Point(11, 187)
            Me.lblPhone1.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhone1.Name = "lblPhone1"
            Me.lblPhone1.Size = New System.Drawing.Size(153, 23)
            Me.lblPhone1.TabIndex = 201
            Me.lblPhone1.Text = "Main Phone Number"
            Me.lblPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPhone1.Translatable = True
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
            Me.txtPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhone1.ForeColor = System.Drawing.Color.Black
            Me.txtPhone1.LinkedLabel = Me.lblPhone1
            Me.txtPhone1.Location = New System.Drawing.Point(166, 187)
            Me.txtPhone1.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhone1.MaximumValue = Nothing
            Me.txtPhone1.MinimumValue = Nothing
            Me.txtPhone1.Name = "txtPhone1"
            Me.txtPhone1.OldValue = Nothing
            Me.txtPhone1.ReadOnly = True
            Me.txtPhone1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhone1.Size = New System.Drawing.Size(194, 23)
            Me.txtPhone1.TabIndex = 13
            Me.txtPhone1.Translatable = False
            '
            'lblPhone2
            '
            Me.lblPhone2.DisplayOnly = True
            Me.lblPhone2.EditingMode = False
            Me.lblPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhone2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPhone2.Location = New System.Drawing.Point(362, 187)
            Me.lblPhone2.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhone2.Name = "lblPhone2"
            Me.lblPhone2.Size = New System.Drawing.Size(148, 23)
            Me.lblPhone2.TabIndex = 203
            Me.lblPhone2.Text = "Secondary Phone No."
            Me.lblPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPhone2.Translatable = True
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
            Me.txtPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhone2.ForeColor = System.Drawing.Color.Black
            Me.txtPhone2.LinkedLabel = Me.lblPhone2
            Me.txtPhone2.Location = New System.Drawing.Point(512, 187)
            Me.txtPhone2.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhone2.MaximumValue = Nothing
            Me.txtPhone2.MinimumValue = Nothing
            Me.txtPhone2.Name = "txtPhone2"
            Me.txtPhone2.OldValue = Nothing
            Me.txtPhone2.ReadOnly = True
            Me.txtPhone2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPhone2.Size = New System.Drawing.Size(204, 23)
            Me.txtPhone2.TabIndex = 14
            Me.txtPhone2.Translatable = False
            '
            'lblFax
            '
            Me.lblFax.DisplayOnly = True
            Me.lblFax.EditingMode = False
            Me.lblFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFax.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblFax.Location = New System.Drawing.Point(11, 212)
            Me.lblFax.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFax.Name = "lblFax"
            Me.lblFax.Size = New System.Drawing.Size(153, 23)
            Me.lblFax.TabIndex = 205
            Me.lblFax.Text = "Fax Number"
            Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFax.Translatable = True
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
            Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFax.ForeColor = System.Drawing.Color.Black
            Me.txtFax.LinkedLabel = Me.lblFax
            Me.txtFax.Location = New System.Drawing.Point(166, 212)
            Me.txtFax.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFax.MaximumValue = Nothing
            Me.txtFax.MinimumValue = Nothing
            Me.txtFax.Name = "txtFax"
            Me.txtFax.OldValue = Nothing
            Me.txtFax.ReadOnly = True
            Me.txtFax.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFax.Size = New System.Drawing.Size(194, 23)
            Me.txtFax.TabIndex = 15
            Me.txtFax.Translatable = False
            '
            'lblMobile
            '
            Me.lblMobile.DisplayOnly = True
            Me.lblMobile.EditingMode = False
            Me.lblMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblMobile.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblMobile.Location = New System.Drawing.Point(362, 212)
            Me.lblMobile.Margin = New System.Windows.Forms.Padding(1)
            Me.lblMobile.Name = "lblMobile"
            Me.lblMobile.Size = New System.Drawing.Size(148, 23)
            Me.lblMobile.TabIndex = 207
            Me.lblMobile.Text = "Mobile Number"
            Me.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblMobile.Translatable = True
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
            Me.txtMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtMobile.ForeColor = System.Drawing.Color.Black
            Me.txtMobile.LinkedLabel = Me.lblMobile
            Me.txtMobile.Location = New System.Drawing.Point(512, 212)
            Me.txtMobile.Margin = New System.Windows.Forms.Padding(1)
            Me.txtMobile.MaximumValue = Nothing
            Me.txtMobile.MinimumValue = Nothing
            Me.txtMobile.Name = "txtMobile"
            Me.txtMobile.OldValue = Nothing
            Me.txtMobile.ReadOnly = True
            Me.txtMobile.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMobile.Size = New System.Drawing.Size(204, 23)
            Me.txtMobile.TabIndex = 16
            Me.txtMobile.Translatable = False
            '
            'lblEmail
            '
            Me.lblEmail.DisplayOnly = True
            Me.lblEmail.EditingMode = False
            Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmail.Location = New System.Drawing.Point(11, 237)
            Me.lblEmail.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(153, 23)
            Me.lblEmail.TabIndex = 211
            Me.lblEmail.Text = "E-mail Address"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEmail.Translatable = True
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
            Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmail.ForeColor = System.Drawing.Color.Black
            Me.txtEmail.LinkedLabel = Me.lblEmail
            Me.txtEmail.Location = New System.Drawing.Point(166, 237)
            Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmail.MaximumValue = Nothing
            Me.txtEmail.MinimumValue = Nothing
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.OldValue = Nothing
            Me.txtEmail.ReadOnly = True
            Me.txtEmail.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmail.Size = New System.Drawing.Size(194, 23)
            Me.txtEmail.TabIndex = 17
            Me.txtEmail.Translatable = False
            '
            'lblWebsite
            '
            Me.lblWebsite.DisplayOnly = True
            Me.lblWebsite.EditingMode = False
            Me.lblWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblWebsite.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWebsite.Location = New System.Drawing.Point(362, 237)
            Me.lblWebsite.Margin = New System.Windows.Forms.Padding(1)
            Me.lblWebsite.Name = "lblWebsite"
            Me.lblWebsite.Size = New System.Drawing.Size(148, 23)
            Me.lblWebsite.TabIndex = 213
            Me.lblWebsite.Text = "Website Address"
            Me.lblWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblWebsite.Translatable = True
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
            Me.txtWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtWebsite.ForeColor = System.Drawing.Color.Black
            Me.txtWebsite.LinkedLabel = Me.lblWebsite
            Me.txtWebsite.Location = New System.Drawing.Point(512, 237)
            Me.txtWebsite.Margin = New System.Windows.Forms.Padding(1)
            Me.txtWebsite.MaximumValue = Nothing
            Me.txtWebsite.MinimumValue = Nothing
            Me.txtWebsite.Name = "txtWebsite"
            Me.txtWebsite.OldValue = Nothing
            Me.txtWebsite.ReadOnly = True
            Me.txtWebsite.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtWebsite.Size = New System.Drawing.Size(204, 23)
            Me.txtWebsite.TabIndex = 18
            Me.txtWebsite.Translatable = False
            '
            'lblCrNumber
            '
            Me.lblCrNumber.DisplayOnly = True
            Me.lblCrNumber.EditingMode = False
            Me.lblCrNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCrNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCrNumber.Location = New System.Drawing.Point(11, 262)
            Me.lblCrNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCrNumber.Name = "lblCrNumber"
            Me.lblCrNumber.Size = New System.Drawing.Size(153, 23)
            Me.lblCrNumber.TabIndex = 215
            Me.lblCrNumber.Text = "Comm. Reg. No. (C.R.)"
            Me.lblCrNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCrNumber.Translatable = True
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
            Me.txtCrNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCrNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCrNumber.LinkedLabel = Me.lblCrNumber
            Me.txtCrNumber.Location = New System.Drawing.Point(166, 262)
            Me.txtCrNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCrNumber.MaximumValue = Nothing
            Me.txtCrNumber.MinimumValue = Nothing
            Me.txtCrNumber.Name = "txtCrNumber"
            Me.txtCrNumber.OldValue = Nothing
            Me.txtCrNumber.ReadOnly = True
            Me.txtCrNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCrNumber.Size = New System.Drawing.Size(194, 23)
            Me.txtCrNumber.TabIndex = 19
            Me.txtCrNumber.Translatable = False
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBankIdNo.Location = New System.Drawing.Point(362, 262)
            Me.lblBankIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankIdNo.Name = "lblBankIdNo"
            Me.lblBankIdNo.Size = New System.Drawing.Size(148, 23)
            Me.lblBankIdNo.TabIndex = 216
            Me.lblBankIdNo.Text = "Bank Name"
            Me.lblBankIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblBankIdNo.Translatable = True
            '
            'cacBankIdNo
            '
            Me.cacBankIdNo.BackColor = System.Drawing.Color.White
            Me.cacBankIdNo.BegFindValue = Nothing
            Me.cacBankIdNo.ChangingSearchValueOnly = False
            Me.cacBankIdNo.CurrentSearchTerm = ""
            Me.cacBankIdNo.DataValue = Nothing
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
            Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
            Me.cacBankIdNo.IgnoreCase = False
            Me.cacBankIdNo.IntegralHeight = False
            Me.cacBankIdNo.LinkedLabel = Nothing
            Me.cacBankIdNo.Location = New System.Drawing.Point(512, 262)
            Me.cacBankIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacBankIdNo.Name = "cacBankIdNo"
            Me.cacBankIdNo.OldValue = 0
            Me.cacBankIdNo.OriginalDataSource = Nothing
            Me.cacBankIdNo.OriginalList = Nothing
            Me.cacBankIdNo.OverrideDropDownStyleList = False
            Me.cacBankIdNo.PreviousSearchTerm = Nothing
            Me.cacBankIdNo.PropertySelector = Nothing
            Me.cacBankIdNo.ReadOnlyCombo = False
            Me.cacBankIdNo.Size = New System.Drawing.Size(204, 24)
            Me.cacBankIdNo.SuggestBoxHeight = 200
            Me.cacBankIdNo.SuggestListOrderRule = Nothing
            Me.cacBankIdNo.TabIndex = 20
            Me.cacBankIdNo.TextToSearch = Nothing
            Me.cacBankIdNo.Translatable = False
            Me.cacBankIdNo.ValueIsMandatory = False
            Me.cacBankIdNo.ValueIsNullable = False
            Me.cacBankIdNo.ValueIsNumeric = False
            Me.cacBankIdNo.ValueMember = "IdNo"
            '
            'lblBankAccountNo
            '
            Me.lblBankAccountNo.DisplayOnly = True
            Me.lblBankAccountNo.EditingMode = False
            Me.lblBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankAccountNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBankAccountNo.Location = New System.Drawing.Point(11, 288)
            Me.lblBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankAccountNo.Name = "lblBankAccountNo"
            Me.lblBankAccountNo.Size = New System.Drawing.Size(153, 23)
            Me.lblBankAccountNo.TabIndex = 218
            Me.lblBankAccountNo.Text = "Bank Account No."
            Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBankAccountNo.Translatable = True
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
            Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
            Me.txtBankAccountNo.Location = New System.Drawing.Point(166, 288)
            Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBankAccountNo.MaximumValue = Nothing
            Me.txtBankAccountNo.MinimumValue = Nothing
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.ReadOnly = True
            Me.txtBankAccountNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankAccountNo.Size = New System.Drawing.Size(194, 23)
            Me.txtBankAccountNo.TabIndex = 21
            Me.txtBankAccountNo.Translatable = False
            '
            'lblIban
            '
            Me.lblIban.DisplayOnly = True
            Me.lblIban.EditingMode = False
            Me.lblIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIban.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIban.Location = New System.Drawing.Point(362, 288)
            Me.lblIban.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIban.Name = "lblIban"
            Me.lblIban.Size = New System.Drawing.Size(148, 23)
            Me.lblIban.TabIndex = 220
            Me.lblIban.Text = "IBAN Number"
            Me.lblIban.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblIban.Translatable = True
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
            Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblIban
            Me.txtIban.Location = New System.Drawing.Point(512, 288)
            Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIban.MaximumValue = Nothing
            Me.txtIban.MinimumValue = Nothing
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.ReadOnly = True
            Me.txtIban.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIban.Size = New System.Drawing.Size(204, 23)
            Me.txtIban.TabIndex = 22
            Me.txtIban.Translatable = False
            '
            'lblExpAccountIdNo
            '
            Me.lblExpAccountIdNo.DisplayOnly = True
            Me.lblExpAccountIdNo.EditingMode = False
            Me.lblExpAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExpAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblExpAccountIdNo.Location = New System.Drawing.Point(11, 313)
            Me.lblExpAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExpAccountIdNo.Name = "lblExpAccountIdNo"
            Me.lblExpAccountIdNo.Size = New System.Drawing.Size(153, 23)
            Me.lblExpAccountIdNo.TabIndex = 236
            Me.lblExpAccountIdNo.Text = "Default Purchase Acct."
            Me.lblExpAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExpAccountIdNo.Translatable = True
            '
            'cacExpAccountIdNo
            '
            Me.cacExpAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cacExpAccountIdNo.BegFindValue = Nothing
            Me.cacExpAccountIdNo.ChangingSearchValueOnly = False
            Me.cacExpAccountIdNo.CurrentSearchTerm = ""
            Me.cacExpAccountIdNo.DataValue = Nothing
            Me.cacExpAccountIdNo.DefaultValue = Nothing
            Me.cacExpAccountIdNo.DisplayMember = "Name"
            Me.cacExpAccountIdNo.EditingMode = False
            Me.cacExpAccountIdNo.EndFindValue = Nothing
            Me.cacExpAccountIdNo.FieldDescription = Nothing
            Me.cacExpAccountIdNo.FieldName = Nothing
            Me.cacExpAccountIdNo.FilterRule = Nothing
            Me.cacExpAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacExpAccountIdNo.FindEnabled = False
            Me.cacExpAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacExpAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacExpAccountIdNo.FormattingEnabled = True
            Me.cacExpAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cacExpAccountIdNo.IgnoreCase = False
            Me.cacExpAccountIdNo.IntegralHeight = False
            Me.cacExpAccountIdNo.LinkedLabel = Nothing
            Me.cacExpAccountIdNo.Location = New System.Drawing.Point(166, 313)
            Me.cacExpAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacExpAccountIdNo.Name = "cacExpAccountIdNo"
            Me.cacExpAccountIdNo.OldValue = 0
            Me.cacExpAccountIdNo.OriginalDataSource = Nothing
            Me.cacExpAccountIdNo.OriginalList = Nothing
            Me.cacExpAccountIdNo.OverrideDropDownStyleList = False
            Me.cacExpAccountIdNo.PreviousSearchTerm = Nothing
            Me.cacExpAccountIdNo.PropertySelector = Nothing
            Me.cacExpAccountIdNo.ReadOnlyCombo = False
            Me.cacExpAccountIdNo.Size = New System.Drawing.Size(194, 24)
            Me.cacExpAccountIdNo.SuggestBoxHeight = 200
            Me.cacExpAccountIdNo.SuggestListOrderRule = Nothing
            Me.cacExpAccountIdNo.TabIndex = 23
            Me.cacExpAccountIdNo.TabStop = False
            Me.cacExpAccountIdNo.TextToSearch = Nothing
            Me.cacExpAccountIdNo.Translatable = False
            Me.cacExpAccountIdNo.ValueIsMandatory = False
            Me.cacExpAccountIdNo.ValueIsNullable = False
            Me.cacExpAccountIdNo.ValueIsNumeric = False
            Me.cacExpAccountIdNo.ValueMember = "IdNo"
            '
            'lblApAccountIdNo
            '
            Me.lblApAccountIdNo.DisplayOnly = True
            Me.lblApAccountIdNo.EditingMode = False
            Me.lblApAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblApAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblApAccountIdNo.Location = New System.Drawing.Point(362, 313)
            Me.lblApAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblApAccountIdNo.Name = "lblApAccountIdNo"
            Me.lblApAccountIdNo.Size = New System.Drawing.Size(148, 23)
            Me.lblApAccountIdNo.TabIndex = 234
            Me.lblApAccountIdNo.Text = "Override AP Account"
            Me.lblApAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblApAccountIdNo.Translatable = True
            '
            'cacApAccountIdNo
            '
            Me.cacApAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cacApAccountIdNo.BegFindValue = Nothing
            Me.cacApAccountIdNo.ChangingSearchValueOnly = False
            Me.cacApAccountIdNo.CurrentSearchTerm = ""
            Me.cacApAccountIdNo.DataValue = Nothing
            Me.cacApAccountIdNo.DefaultValue = Nothing
            Me.cacApAccountIdNo.DisplayMember = "Name"
            Me.cacApAccountIdNo.EditingMode = False
            Me.cacApAccountIdNo.EndFindValue = Nothing
            Me.cacApAccountIdNo.FieldDescription = Nothing
            Me.cacApAccountIdNo.FieldName = Nothing
            Me.cacApAccountIdNo.FilterRule = Nothing
            Me.cacApAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacApAccountIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacApAccountIdNo, True)
            Me.cacApAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacApAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacApAccountIdNo.FormattingEnabled = True
            Me.cacApAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cacApAccountIdNo.IgnoreCase = False
            Me.cacApAccountIdNo.IntegralHeight = False
            Me.cacApAccountIdNo.LinkedLabel = Nothing
            Me.cacApAccountIdNo.Location = New System.Drawing.Point(512, 313)
            Me.cacApAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacApAccountIdNo.Name = "cacApAccountIdNo"
            Me.cacApAccountIdNo.OldValue = 0
            Me.cacApAccountIdNo.OriginalDataSource = Nothing
            Me.cacApAccountIdNo.OriginalList = Nothing
            Me.cacApAccountIdNo.OverrideDropDownStyleList = False
            Me.cacApAccountIdNo.PreviousSearchTerm = Nothing
            Me.cacApAccountIdNo.PropertySelector = Nothing
            Me.cacApAccountIdNo.ReadOnlyCombo = False
            Me.cacApAccountIdNo.Size = New System.Drawing.Size(204, 24)
            Me.cacApAccountIdNo.SuggestBoxHeight = 200
            Me.cacApAccountIdNo.SuggestListOrderRule = Nothing
            Me.cacApAccountIdNo.TabIndex = 24
            Me.cacApAccountIdNo.TextToSearch = Nothing
            Me.cacApAccountIdNo.Translatable = False
            Me.cacApAccountIdNo.ValueIsMandatory = False
            Me.cacApAccountIdNo.ValueIsNullable = False
            Me.cacApAccountIdNo.ValueIsNumeric = False
            Me.cacApAccountIdNo.ValueMember = "IdNo"
            '
            'lblCreditLimit
            '
            Me.lblCreditLimit.DisplayOnly = True
            Me.lblCreditLimit.EditingMode = False
            Me.lblCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCreditLimit.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCreditLimit.Location = New System.Drawing.Point(11, 339)
            Me.lblCreditLimit.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCreditLimit.Name = "lblCreditLimit"
            Me.lblCreditLimit.Size = New System.Drawing.Size(153, 23)
            Me.lblCreditLimit.TabIndex = 222
            Me.lblCreditLimit.Text = "Credit Limit"
            Me.lblCreditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCreditLimit.Translatable = True
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
            Me.txtCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCreditLimit.ForeColor = System.Drawing.Color.Black
            Me.txtCreditLimit.LinkedLabel = Me.lblCreditLimit
            Me.txtCreditLimit.Location = New System.Drawing.Point(166, 339)
            Me.txtCreditLimit.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCreditLimit.MaximumValue = Nothing
            Me.txtCreditLimit.MinimumValue = Nothing
            Me.txtCreditLimit.Name = "txtCreditLimit"
            Me.txtCreditLimit.OldValue = Nothing
            Me.txtCreditLimit.ReadOnly = True
            Me.txtCreditLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCreditLimit.Size = New System.Drawing.Size(194, 23)
            Me.txtCreditLimit.TabIndex = 25
            Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtCreditLimit.Translatable = False
            Me.txtCreditLimit.ValueIsNumeric = True
            '
            'lblPaymentMethod
            '
            Me.lblPaymentMethod.DisplayOnly = True
            Me.lblPaymentMethod.EditingMode = False
            Me.lblPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentMethod.Location = New System.Drawing.Point(362, 339)
            Me.lblPaymentMethod.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentMethod.Name = "lblPaymentMethod"
            Me.lblPaymentMethod.Size = New System.Drawing.Size(148, 21)
            Me.lblPaymentMethod.TabIndex = 168
            Me.lblPaymentMethod.Text = "Payment Method"
            Me.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPaymentMethod.Translatable = True
            '
            'cacPaymentMethod
            '
            Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
            Me.cacPaymentMethod.BegFindValue = Nothing
            Me.cacPaymentMethod.ChangingSearchValueOnly = False
            Me.cacPaymentMethod.CurrentSearchTerm = ""
            Me.cacPaymentMethod.DataValue = Nothing
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
            Me.cacPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
            Me.cacPaymentMethod.FormattingEnabled = True
            Me.cacPaymentMethod.HideWhenNotEditingOrAdding = False
            Me.cacPaymentMethod.IgnoreCase = False
            Me.cacPaymentMethod.IntegralHeight = False
            Me.cacPaymentMethod.LinkedLabel = Nothing
            Me.cacPaymentMethod.Location = New System.Drawing.Point(512, 339)
            Me.cacPaymentMethod.Margin = New System.Windows.Forms.Padding(1)
            Me.cacPaymentMethod.Name = "cacPaymentMethod"
            Me.cacPaymentMethod.OldValue = 0
            Me.cacPaymentMethod.OriginalDataSource = Nothing
            Me.cacPaymentMethod.OriginalList = Nothing
            Me.cacPaymentMethod.OverrideDropDownStyleList = False
            Me.cacPaymentMethod.PreviousSearchTerm = Nothing
            Me.cacPaymentMethod.PropertySelector = Nothing
            Me.cacPaymentMethod.ReadOnlyCombo = False
            Me.cacPaymentMethod.Size = New System.Drawing.Size(204, 24)
            Me.cacPaymentMethod.SuggestBoxHeight = 200
            Me.cacPaymentMethod.SuggestListOrderRule = Nothing
            Me.cacPaymentMethod.TabIndex = 26
            Me.cacPaymentMethod.TextToSearch = Nothing
            Me.cacPaymentMethod.Translatable = False
            Me.cacPaymentMethod.ValueIsMandatory = False
            Me.cacPaymentMethod.ValueIsNullable = False
            Me.cacPaymentMethod.ValueIsNumeric = False
            Me.cacPaymentMethod.ValueMember = "Code"
            '
            'lblOpeningBalance
            '
            Me.lblOpeningBalance.DisplayOnly = True
            Me.lblOpeningBalance.EditingMode = False
            Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblOpeningBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblOpeningBalance.Location = New System.Drawing.Point(11, 365)
            Me.lblOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.lblOpeningBalance.Name = "lblOpeningBalance"
            Me.lblOpeningBalance.Size = New System.Drawing.Size(153, 23)
            Me.lblOpeningBalance.TabIndex = 30
            Me.lblOpeningBalance.Text = "Opening Balance"
            Me.lblOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblOpeningBalance.Translatable = True
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
            Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
            Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtOpeningBalance.Location = New System.Drawing.Point(166, 365)
            Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtOpeningBalance.MaximumValue = Nothing
            Me.txtOpeningBalance.MinimumValue = Nothing
            Me.txtOpeningBalance.Name = "txtOpeningBalance"
            Me.txtOpeningBalance.OldValue = Nothing
            Me.txtOpeningBalance.ReadOnly = True
            Me.txtOpeningBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtOpeningBalance.Size = New System.Drawing.Size(195, 23)
            Me.txtOpeningBalance.TabIndex = 27
            Me.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtOpeningBalance.Translatable = False
            Me.txtOpeningBalance.ValueIsNumeric = True
            '
            'lblSettlementDueDays
            '
            Me.lblSettlementDueDays.DisplayOnly = True
            Me.lblSettlementDueDays.EditingMode = False
            Me.lblSettlementDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSettlementDueDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSettlementDueDays.Location = New System.Drawing.Point(363, 365)
            Me.lblSettlementDueDays.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSettlementDueDays.Name = "lblSettlementDueDays"
            Me.lblSettlementDueDays.Size = New System.Drawing.Size(244, 23)
            Me.lblSettlementDueDays.TabIndex = 224
            Me.lblSettlementDueDays.Text = "Early Settlement Due Days"
            Me.lblSettlementDueDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSettlementDueDays.Translatable = True
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
            Me.txtSettlementDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSettlementDueDays.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDueDays.IgnoreNullCheck = True
            Me.txtSettlementDueDays.LinkedLabel = Me.lblSettlementDueDays
            Me.txtSettlementDueDays.Location = New System.Drawing.Point(609, 365)
            Me.txtSettlementDueDays.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSettlementDueDays.MaximumValue = Nothing
            Me.txtSettlementDueDays.MinimumValue = Nothing
            Me.txtSettlementDueDays.Name = "txtSettlementDueDays"
            Me.txtSettlementDueDays.OldValue = Nothing
            Me.txtSettlementDueDays.ReadOnly = True
            Me.txtSettlementDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSettlementDueDays.Size = New System.Drawing.Size(106, 23)
            Me.txtSettlementDueDays.TabIndex = 28
            Me.txtSettlementDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtSettlementDueDays.Translatable = False
            '
            'lblPaymentDueDays
            '
            Me.lblPaymentDueDays.DisplayOnly = True
            Me.lblPaymentDueDays.EditingMode = False
            Me.lblPaymentDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentDueDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentDueDays.Location = New System.Drawing.Point(11, 390)
            Me.lblPaymentDueDays.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentDueDays.Name = "lblPaymentDueDays"
            Me.lblPaymentDueDays.Size = New System.Drawing.Size(153, 23)
            Me.lblPaymentDueDays.TabIndex = 160
            Me.lblPaymentDueDays.Text = "Payment Due Days"
            Me.lblPaymentDueDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPaymentDueDays.Translatable = True
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
            Me.txtPaymentDueDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPaymentDueDays.ForeColor = System.Drawing.Color.Black
            Me.txtPaymentDueDays.IgnoreNullCheck = True
            Me.txtPaymentDueDays.LinkedLabel = Me.lblPaymentDueDays
            Me.txtPaymentDueDays.Location = New System.Drawing.Point(166, 390)
            Me.txtPaymentDueDays.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPaymentDueDays.MaximumValue = Nothing
            Me.txtPaymentDueDays.MinimumValue = Nothing
            Me.txtPaymentDueDays.Name = "txtPaymentDueDays"
            Me.txtPaymentDueDays.OldValue = Nothing
            Me.txtPaymentDueDays.ReadOnly = True
            Me.txtPaymentDueDays.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPaymentDueDays.Size = New System.Drawing.Size(103, 23)
            Me.txtPaymentDueDays.TabIndex = 29
            Me.txtPaymentDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPaymentDueDays.Translatable = False
            '
            'lblSettlementDiscount
            '
            Me.lblSettlementDiscount.DisplayOnly = True
            Me.lblSettlementDiscount.EditingMode = False
            Me.lblSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSettlementDiscount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSettlementDiscount.Location = New System.Drawing.Point(271, 390)
            Me.lblSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSettlementDiscount.Name = "lblSettlementDiscount"
            Me.lblSettlementDiscount.Size = New System.Drawing.Size(238, 23)
            Me.lblSettlementDiscount.TabIndex = 230
            Me.lblSettlementDiscount.Text = "Early Settlement Discount Rate (%)"
            Me.lblSettlementDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSettlementDiscount.Translatable = True
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
            Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDiscount.IgnoreNullCheck = True
            Me.txtSettlementDiscount.LinkedLabel = Me.lblSettlementDiscount
            Me.txtSettlementDiscount.Location = New System.Drawing.Point(511, 390)
            Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSettlementDiscount.MaximumValue = Nothing
            Me.txtSettlementDiscount.MinimumValue = Nothing
            Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
            Me.txtSettlementDiscount.OldValue = Nothing
            Me.txtSettlementDiscount.ReadOnly = True
            Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSettlementDiscount.Size = New System.Drawing.Size(40, 23)
            Me.txtSettlementDiscount.TabIndex = 30
            Me.txtSettlementDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtSettlementDiscount.Translatable = False
            Me.txtSettlementDiscount.ValueIsNumeric = True
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel3.Location = New System.Drawing.Point(553, 390)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(17, 23)
            Me.CLabel3.TabIndex = 226
            Me.CLabel3.Text = "%"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblActive.Location = New System.Drawing.Point(572, 390)
            Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Size = New System.Drawing.Size(118, 23)
            Me.lblActive.TabIndex = 239
            Me.lblActive.Text = "Active Account?"
            Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblActive.Translatable = True
            '
            'chkActive
            '
            Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkActive.AutoCheck = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = False
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.floDataDisplay.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Location = New System.Drawing.Point(692, 390)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = True
            Me.chkActive.OldValue = Nothing
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Size = New System.Drawing.Size(13, 13)
            Me.chkActive.TabIndex = 33
            Me.chkActive.Text = " "
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = True
            '
            'lblDateAccountOpen
            '
            Me.lblDateAccountOpen.DisplayOnly = True
            Me.lblDateAccountOpen.EditingMode = False
            Me.lblDateAccountOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDateAccountOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAccountOpen.Location = New System.Drawing.Point(11, 415)
            Me.lblDateAccountOpen.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateAccountOpen.Name = "lblDateAccountOpen"
            Me.lblDateAccountOpen.Size = New System.Drawing.Size(153, 23)
            Me.lblDateAccountOpen.TabIndex = 232
            Me.lblDateAccountOpen.Text = "Date Account Opening"
            Me.lblDateAccountOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateAccountOpen.Translatable = True
            '
            'dtpDateAccountOpen
            '
            Me.dtpDateAccountOpen.AutoSize = True
            Me.dtpDateAccountOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpDateAccountOpen.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpDateAccountOpen.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDateAccountOpen.DefaultValue = Nothing
            Me.dtpDateAccountOpen.DisplayOnly = False
            Me.dtpDateAccountOpen.DtpDefaultValue = Nothing
            Me.dtpDateAccountOpen.EditingMode = False
            Me.dtpDateAccountOpen.EditsAllowed = False
            Me.dtpDateAccountOpen.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpDateAccountOpen.ForeColor = System.Drawing.Color.Black
            Me.dtpDateAccountOpen.LinkedLabel = Nothing
            Me.dtpDateAccountOpen.Location = New System.Drawing.Point(165, 414)
            Me.dtpDateAccountOpen.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDateAccountOpen.Name = "dtpDateAccountOpen"
            Me.dtpDateAccountOpen.ReadOnlyDp = False
            Me.dtpDateAccountOpen.SecurityKey = Nothing
            Me.dtpDateAccountOpen.ShowLongDate = False
            Me.dtpDateAccountOpen.ShowTime = False
            Me.dtpDateAccountOpen.Size = New System.Drawing.Size(127, 36)
            Me.dtpDateAccountOpen.TabIndex = 31
            Me.dtpDateAccountOpen.TargetCalendar = CType(resources.GetObject("dtpDateAccountOpen.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDateAccountOpen.Translatable = False
            Me.dtpDateAccountOpen.Value = Nothing
            Me.dtpDateAccountOpen.ValueIsMandatory = False
            Me.dtpDateAccountOpen.ValueIsNullable = False
            '
            'lblAccountStatus
            '
            Me.lblAccountStatus.DisplayOnly = True
            Me.lblAccountStatus.EditingMode = False
            Me.lblAccountStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountStatus.Location = New System.Drawing.Point(293, 415)
            Me.lblAccountStatus.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountStatus.Name = "lblAccountStatus"
            Me.lblAccountStatus.Size = New System.Drawing.Size(218, 20)
            Me.lblAccountStatus.TabIndex = 238
            Me.lblAccountStatus.Text = "Account Status"
            Me.lblAccountStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblAccountStatus.Translatable = True
            '
            'cacAccountStatus
            '
            Me.cacAccountStatus.BackColor = System.Drawing.Color.White
            Me.cacAccountStatus.BegFindValue = Nothing
            Me.cacAccountStatus.ChangingSearchValueOnly = False
            Me.cacAccountStatus.CurrentSearchTerm = ""
            Me.cacAccountStatus.DataValue = Nothing
            Me.cacAccountStatus.DefaultValue = Nothing
            Me.cacAccountStatus.DisplayMember = "Name"
            Me.cacAccountStatus.EditingMode = False
            Me.cacAccountStatus.EndFindValue = Nothing
            Me.cacAccountStatus.FieldDescription = Nothing
            Me.cacAccountStatus.FieldName = Nothing
            Me.cacAccountStatus.FilterRule = Nothing
            Me.cacAccountStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacAccountStatus.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacAccountStatus, True)
            Me.cacAccountStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacAccountStatus.ForeColor = System.Drawing.Color.Black
            Me.cacAccountStatus.FormattingEnabled = True
            Me.cacAccountStatus.HideWhenNotEditingOrAdding = False
            Me.cacAccountStatus.IgnoreCase = False
            Me.cacAccountStatus.IntegralHeight = False
            Me.cacAccountStatus.LinkedLabel = Nothing
            Me.cacAccountStatus.Location = New System.Drawing.Point(513, 415)
            Me.cacAccountStatus.Margin = New System.Windows.Forms.Padding(1)
            Me.cacAccountStatus.Name = "cacAccountStatus"
            Me.cacAccountStatus.OldValue = 0
            Me.cacAccountStatus.OriginalDataSource = Nothing
            Me.cacAccountStatus.OriginalList = Nothing
            Me.cacAccountStatus.OverrideDropDownStyleList = False
            Me.cacAccountStatus.PreviousSearchTerm = Nothing
            Me.cacAccountStatus.PropertySelector = Nothing
            Me.cacAccountStatus.ReadOnlyCombo = False
            Me.cacAccountStatus.Size = New System.Drawing.Size(204, 24)
            Me.cacAccountStatus.SuggestBoxHeight = 200
            Me.cacAccountStatus.SuggestListOrderRule = Nothing
            Me.cacAccountStatus.TabIndex = 32
            Me.cacAccountStatus.TextToSearch = Nothing
            Me.cacAccountStatus.Translatable = False
            Me.cacAccountStatus.ValueIsMandatory = False
            Me.cacAccountStatus.ValueIsNullable = False
            Me.cacAccountStatus.ValueIsNumeric = False
            Me.cacAccountStatus.ValueMember = "Code"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(11, 451)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(153, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Balance"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
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
            Me.txtBalance.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBalance, True)
            Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtBalance.Location = New System.Drawing.Point(166, 451)
            Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBalance.Size = New System.Drawing.Size(103, 23)
            Me.txtBalance.TabIndex = 43
            Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtBalance.Translatable = False
            Me.txtBalance.ValueIsNumeric = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 476)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(153, 23)
            Me.CLabel1.TabIndex = 240
            Me.CLabel1.Text = "Notes"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Left
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(166, 476)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(549, 23)
            Me.txtNotes.TabIndex = 44
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'SupplierEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1078, 555)
            Me.Name = "SupplierEntryTv"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Supplier Maintenance Form"
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