Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PensionProviderEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PensionProviderEntryTv))
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Me._MBPensionProviderCannotBeParentToItself = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBParentWithChildrenChangedDisallowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBMainAccountNotEditable = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIban = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
        Me.txtPensionProviderNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtPensionProviderName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPensionProviderName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPensionProviderNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPensionProviderCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPensionProviderCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.cacPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'LocalizableContent1
            '
            LocalizableContent1.MessageBoxes.Add(Me._MBPensionProviderCannotBeParentToItself)
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
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblPaymentMethod
            '
            Me.lblPaymentMethod.DisplayOnly = True
            Me.lblPaymentMethod.EditingMode = False
            resources.ApplyResources(Me.lblPaymentMethod, "lblPaymentMethod")
            Me.lblPaymentMethod.Name = "lblPaymentMethod"
            '
            'txtIban
            '
            Me.txtIban.BackColor = System.Drawing.Color.White
            Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIban.ComputedValue = False
            Me.txtIban.CustomFormat = Nothing
            Me.txtIban.DataBoundControl = True
            Me.txtIban.EditingMode = False
            Me.txtIban.FindEnabled = True
            resources.ApplyResources(Me.txtIban, "txtIban")
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblIban
            Me.txtIban.MaximumValue = Nothing
            Me.txtIban.MinimumValue = Nothing
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.ReadOnly = True
            '
            'lblIban
            '
            Me.lblIban.DisplayOnly = True
            Me.lblIban.EditingMode = False
            resources.ApplyResources(Me.lblIban, "lblIban")
            Me.lblIban.Name = "lblIban"
            '
            'txtBankAccountNo
            '
            Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
            Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankAccountNo.ComputedValue = False
            Me.txtBankAccountNo.CustomFormat = Nothing
            Me.txtBankAccountNo.DataBoundControl = True
            Me.txtBankAccountNo.EditingMode = False
            Me.txtBankAccountNo.FindEnabled = True
            resources.ApplyResources(Me.txtBankAccountNo, "txtBankAccountNo")
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
            Me.txtBankAccountNo.MaximumValue = Nothing
            Me.txtBankAccountNo.MinimumValue = Nothing
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.ReadOnly = True
            '
            'lblBankAccountNo
            '
            Me.lblBankAccountNo.DisplayOnly = True
            Me.lblBankAccountNo.EditingMode = False
            resources.ApplyResources(Me.lblBankAccountNo, "lblBankAccountNo")
            Me.lblBankAccountNo.Name = "lblBankAccountNo"
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            resources.ApplyResources(Me.lblBankIdNo, "lblBankIdNo")
            Me.lblBankIdNo.Name = "lblBankIdNo"
            '
            'txtWebsite
            '
            Me.txtWebsite.BackColor = System.Drawing.Color.White
            Me.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWebsite.ComputedValue = False
            Me.txtWebsite.CustomFormat = Nothing
            Me.txtWebsite.DataBoundControl = True
            Me.txtWebsite.EditingMode = False
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
            '
            'lblWebsite
            '
            Me.lblWebsite.DisplayOnly = True
            Me.lblWebsite.EditingMode = False
            resources.ApplyResources(Me.lblWebsite, "lblWebsite")
            Me.lblWebsite.Name = "lblWebsite"
            '
            'txtEmail
            '
            Me.txtEmail.BackColor = System.Drawing.Color.White
            Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmail.ComputedValue = False
            Me.txtEmail.CustomFormat = Nothing
            Me.txtEmail.DataBoundControl = True
            Me.txtEmail.EditingMode = False
            Me.txtEmail.FindEnabled = True
            resources.ApplyResources(Me.txtEmail, "txtEmail")
            Me.txtEmail.ForeColor = System.Drawing.Color.Black
            Me.txtEmail.LinkedLabel = Me.lblEmail
            Me.txtEmail.MaximumValue = Nothing
            Me.txtEmail.MinimumValue = Nothing
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.OldValue = Nothing
            Me.txtEmail.ReadOnly = True
            '
            'lblEmail
            '
            Me.lblEmail.DisplayOnly = True
            Me.lblEmail.EditingMode = False
            resources.ApplyResources(Me.lblEmail, "lblEmail")
            Me.lblEmail.Name = "lblEmail"
            '
            'txtMobile
            '
            Me.txtMobile.BackColor = System.Drawing.Color.White
            Me.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMobile.ComputedValue = False
            Me.txtMobile.CustomFormat = Nothing
            Me.txtMobile.DataBoundControl = True
            Me.txtMobile.EditingMode = False
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
            '
            'lblMobile
            '
            Me.lblMobile.DisplayOnly = True
            Me.lblMobile.EditingMode = False
            resources.ApplyResources(Me.lblMobile, "lblMobile")
            Me.lblMobile.Name = "lblMobile"
            '
            'txtFax
            '
            Me.txtFax.BackColor = System.Drawing.Color.White
            Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFax.ComputedValue = False
            Me.txtFax.CustomFormat = Nothing
            Me.txtFax.DataBoundControl = True
            Me.txtFax.EditingMode = False
            Me.txtFax.FindEnabled = True
            resources.ApplyResources(Me.txtFax, "txtFax")
            Me.txtFax.ForeColor = System.Drawing.Color.Black
            Me.txtFax.LinkedLabel = Me.lblFax
            Me.txtFax.MaximumValue = Nothing
            Me.txtFax.MinimumValue = Nothing
            Me.txtFax.Name = "txtFax"
            Me.txtFax.OldValue = Nothing
            Me.txtFax.ReadOnly = True
            '
            'lblFax
            '
            Me.lblFax.DisplayOnly = True
            Me.lblFax.EditingMode = False
            resources.ApplyResources(Me.lblFax, "lblFax")
            Me.lblFax.Name = "lblFax"
            '
            'txtPhone2
            '
            Me.txtPhone2.BackColor = System.Drawing.Color.White
            Me.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone2.ComputedValue = False
            Me.txtPhone2.CustomFormat = Nothing
            Me.txtPhone2.DataBoundControl = True
            Me.txtPhone2.EditingMode = False
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
            '
            'lblPhone2
            '
            Me.lblPhone2.DisplayOnly = True
            Me.lblPhone2.EditingMode = False
            resources.ApplyResources(Me.lblPhone2, "lblPhone2")
            Me.lblPhone2.Name = "lblPhone2"
            '
            'txtPhone1
            '
            Me.txtPhone1.BackColor = System.Drawing.Color.White
            Me.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone1.ComputedValue = False
            Me.txtPhone1.CustomFormat = Nothing
            Me.txtPhone1.DataBoundControl = True
            Me.txtPhone1.EditingMode = False
            Me.txtPhone1.FindEnabled = True
            resources.ApplyResources(Me.txtPhone1, "txtPhone1")
            Me.txtPhone1.ForeColor = System.Drawing.Color.Black
            Me.txtPhone1.LinkedLabel = Me.lblPhone1
            Me.txtPhone1.MaximumValue = Nothing
            Me.txtPhone1.MinimumValue = Nothing
            Me.txtPhone1.Name = "txtPhone1"
            Me.txtPhone1.OldValue = Nothing
            Me.txtPhone1.ReadOnly = True
            '
            'lblPhone1
            '
            Me.lblPhone1.DisplayOnly = True
            Me.lblPhone1.EditingMode = False
            resources.ApplyResources(Me.lblPhone1, "lblPhone1")
            Me.lblPhone1.Name = "lblPhone1"
            '
            'lblCountryCode
            '
            Me.lblCountryCode.DisplayOnly = True
            Me.lblCountryCode.EditingMode = False
            resources.ApplyResources(Me.lblCountryCode, "lblCountryCode")
            Me.lblCountryCode.Name = "lblCountryCode"
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.Color.White
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.ComputedValue = False
            Me.txtZipCode.CustomFormat = Nothing
            Me.txtZipCode.DataBoundControl = True
            Me.txtZipCode.EditingMode = False
            Me.txtZipCode.FindEnabled = True
            resources.ApplyResources(Me.txtZipCode, "txtZipCode")
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Me.lblZipCode
            Me.txtZipCode.MaximumValue = Nothing
            Me.txtZipCode.MinimumValue = Nothing
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.ReadOnly = True
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            resources.ApplyResources(Me.lblZipCode, "lblZipCode")
            Me.lblZipCode.Name = "lblZipCode"
            '
            'txtPoBox
            '
            Me.txtPoBox.BackColor = System.Drawing.Color.White
            Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPoBox.ComputedValue = False
            Me.txtPoBox.CustomFormat = Nothing
            Me.txtPoBox.DataBoundControl = True
            Me.txtPoBox.EditingMode = False
            Me.txtPoBox.FindEnabled = True
            resources.ApplyResources(Me.txtPoBox, "txtPoBox")
            Me.txtPoBox.ForeColor = System.Drawing.Color.Black
            Me.txtPoBox.LinkedLabel = Me.lblPoBox
            Me.txtPoBox.MaximumValue = Nothing
            Me.txtPoBox.MinimumValue = Nothing
            Me.txtPoBox.Name = "txtPoBox"
            Me.txtPoBox.OldValue = Nothing
            Me.txtPoBox.ReadOnly = True
            '
            'lblPoBox
            '
            Me.lblPoBox.DisplayOnly = True
            Me.lblPoBox.EditingMode = False
            resources.ApplyResources(Me.lblPoBox, "lblPoBox")
            Me.lblPoBox.Name = "lblPoBox"
            '
            'txtProvinceState
            '
            Me.txtProvinceState.BackColor = System.Drawing.Color.White
            Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProvinceState.ComputedValue = False
            Me.txtProvinceState.CustomFormat = Nothing
            Me.txtProvinceState.DataBoundControl = True
            Me.txtProvinceState.EditingMode = False
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
            '
            'lblProvinceState
            '
            Me.lblProvinceState.DisplayOnly = True
            Me.lblProvinceState.EditingMode = False
            resources.ApplyResources(Me.lblProvinceState, "lblProvinceState")
            Me.lblProvinceState.Name = "lblProvinceState"
            '
            'txtTownCity
            '
            Me.txtTownCity.BackColor = System.Drawing.Color.White
            Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTownCity.ComputedValue = False
            Me.txtTownCity.CustomFormat = Nothing
            Me.txtTownCity.DataBoundControl = True
            Me.txtTownCity.EditingMode = False
            Me.txtTownCity.FindEnabled = True
            resources.ApplyResources(Me.txtTownCity, "txtTownCity")
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Me.lblTownCity
            Me.txtTownCity.MaximumValue = Nothing
            Me.txtTownCity.MinimumValue = Nothing
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.ReadOnly = True
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            resources.ApplyResources(Me.lblTownCity, "lblTownCity")
            Me.lblTownCity.Name = "lblTownCity"
            '
            'txtDistrict
            '
            Me.txtDistrict.BackColor = System.Drawing.Color.White
            Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistrict.ComputedValue = False
            Me.txtDistrict.CustomFormat = Nothing
            Me.txtDistrict.DataBoundControl = True
            Me.txtDistrict.EditingMode = False
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
            '
            'lblDistrict
            '
            Me.lblDistrict.DisplayOnly = True
            Me.lblDistrict.EditingMode = False
            resources.ApplyResources(Me.lblDistrict, "lblDistrict")
            Me.lblDistrict.Name = "lblDistrict"
            '
            'txtStreet
            '
            Me.txtStreet.BackColor = System.Drawing.Color.White
            Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStreet.ComputedValue = False
            Me.txtStreet.CustomFormat = Nothing
            Me.txtStreet.DataBoundControl = True
            Me.txtStreet.EditingMode = False
            Me.txtStreet.FindEnabled = True
            resources.ApplyResources(Me.txtStreet, "txtStreet")
            Me.txtStreet.ForeColor = System.Drawing.Color.Black
            Me.txtStreet.LinkedLabel = Me.lblStreet
            Me.txtStreet.MaximumValue = Nothing
            Me.txtStreet.MinimumValue = Nothing
            Me.txtStreet.Name = "txtStreet"
            Me.txtStreet.OldValue = Nothing
            Me.txtStreet.ReadOnly = True
            '
            'lblStreet
            '
            Me.lblStreet.DisplayOnly = True
            Me.lblStreet.EditingMode = False
            resources.ApplyResources(Me.lblStreet, "lblStreet")
            Me.lblStreet.Name = "lblStreet"
            '
            'txtContactDesignation
            '
            Me.txtContactDesignation.BackColor = System.Drawing.Color.White
            Me.txtContactDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtContactDesignation.ComputedValue = False
            Me.txtContactDesignation.CustomFormat = Nothing
            Me.txtContactDesignation.DataBoundControl = True
            Me.txtContactDesignation.EditingMode = False
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
            '
            'lblContactDesignation
            '
            Me.lblContactDesignation.DisplayOnly = True
            Me.lblContactDesignation.EditingMode = False
            resources.ApplyResources(Me.lblContactDesignation, "lblContactDesignation")
            Me.lblContactDesignation.Name = "lblContactDesignation"
            '
            'txtContactPerson
            '
            Me.txtContactPerson.BackColor = System.Drawing.Color.White
            Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtContactPerson.ComputedValue = False
            Me.txtContactPerson.CustomFormat = Nothing
            Me.txtContactPerson.DataBoundControl = True
            Me.txtContactPerson.EditingMode = False
            Me.txtContactPerson.FindEnabled = True
            resources.ApplyResources(Me.txtContactPerson, "txtContactPerson")
            Me.txtContactPerson.ForeColor = System.Drawing.Color.Black
            Me.txtContactPerson.LinkedLabel = Me.lblContactPerson
            Me.txtContactPerson.MaximumValue = Nothing
            Me.txtContactPerson.MinimumValue = Nothing
            Me.txtContactPerson.Name = "txtContactPerson"
            Me.txtContactPerson.OldValue = Nothing
            Me.txtContactPerson.ReadOnly = True
            '
            'lblContactPerson
            '
            Me.lblContactPerson.DisplayOnly = True
            Me.lblContactPerson.EditingMode = False
            resources.ApplyResources(Me.lblContactPerson, "lblContactPerson")
            Me.lblContactPerson.Name = "lblContactPerson"
            '
            'txtPensionProviderNameAra
            '
            Me.txtPensionProviderNameAra.BackColor = System.Drawing.Color.White
            Me.txtPensionProviderNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPensionProviderNameAra.ComputedValue = False
            Me.txtPensionProviderNameAra.CustomFormat = Nothing
            Me.txtPensionProviderNameAra.DataBoundControl = True
            Me.txtPensionProviderNameAra.EditingMode = False
            Me.txtPensionProviderNameAra.EnglishControl = Me.txtPensionProviderName
            Me.txtPensionProviderNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPensionProviderNameAra, True)
            resources.ApplyResources(Me.txtPensionProviderNameAra, "txtPensionProviderNameAra")
            Me.txtPensionProviderNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPensionProviderNameAra.LinkedLabel = Me.lblPensionProviderNameAra
            Me.txtPensionProviderNameAra.MaximumValue = Nothing
            Me.txtPensionProviderNameAra.MinimumValue = Nothing
            Me.txtPensionProviderNameAra.Name = "txtPensionProviderNameAra"
            Me.txtPensionProviderNameAra.OldValue = Nothing
            Me.txtPensionProviderNameAra.ReadOnly = True
            Me.txtPensionProviderNameAra.ValueIsMandatory = True
            '
            'txtPensionProviderName
            '
            Me.txtPensionProviderName.BackColor = System.Drawing.Color.White
            Me.txtPensionProviderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPensionProviderName.ComputedValue = False
            Me.txtPensionProviderName.CustomFormat = Nothing
            Me.txtPensionProviderName.DataBoundControl = True
            Me.txtPensionProviderName.EditingMode = False
            Me.txtPensionProviderName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPensionProviderName, True)
            resources.ApplyResources(Me.txtPensionProviderName, "txtPensionProviderName")
            Me.txtPensionProviderName.ForeColor = System.Drawing.Color.Black
            Me.txtPensionProviderName.LinkedLabel = Me.lblPensionProviderName
            Me.txtPensionProviderName.MaximumValue = Nothing
            Me.txtPensionProviderName.MinimumValue = Nothing
            Me.txtPensionProviderName.Name = "txtPensionProviderName"
            Me.txtPensionProviderName.OldValue = Nothing
            Me.txtPensionProviderName.ReadOnly = True
            Me.txtPensionProviderName.ValueIsMandatory = True
            '
            'lblPensionProviderName
            '
            Me.lblPensionProviderName.DisplayOnly = True
            Me.lblPensionProviderName.EditingMode = False
            resources.ApplyResources(Me.lblPensionProviderName, "lblPensionProviderName")
            Me.lblPensionProviderName.Name = "lblPensionProviderName"
            '
            'lblPensionProviderNameAra
            '
            Me.lblPensionProviderNameAra.DisplayOnly = True
            Me.lblPensionProviderNameAra.EditingMode = False
            resources.ApplyResources(Me.lblPensionProviderNameAra, "lblPensionProviderNameAra")
            Me.lblPensionProviderNameAra.Name = "lblPensionProviderNameAra"
            '
            'txtPensionProviderCode
            '
            Me.txtPensionProviderCode.BackColor = System.Drawing.Color.White
            Me.txtPensionProviderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPensionProviderCode.ComputedValue = False
            Me.txtPensionProviderCode.CustomFormat = Nothing
            Me.txtPensionProviderCode.DataBoundControl = True
            Me.txtPensionProviderCode.EditingMode = False
            Me.txtPensionProviderCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPensionProviderCode, True)
            resources.ApplyResources(Me.txtPensionProviderCode, "txtPensionProviderCode")
            Me.txtPensionProviderCode.ForeColor = System.Drawing.Color.Black
            Me.txtPensionProviderCode.LinkedLabel = Me.lblPensionProviderCode
            Me.txtPensionProviderCode.MaximumValue = Nothing
            Me.txtPensionProviderCode.MinimumValue = Nothing
            Me.txtPensionProviderCode.Name = "txtPensionProviderCode"
            Me.txtPensionProviderCode.OldValue = Nothing
            Me.txtPensionProviderCode.ReadOnly = True
            Me.txtPensionProviderCode.ValueIsMandatory = True
            '
            'lblPensionProviderCode
            '
            Me.lblPensionProviderCode.DisplayOnly = True
            Me.lblPensionProviderCode.EditingMode = False
            resources.ApplyResources(Me.lblPensionProviderCode, "lblPensionProviderCode")
            Me.lblPensionProviderCode.Name = "lblPensionProviderCode"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPensionProviderCode)
            Me.floDataDisplay.Controls.Add(Me.txtPensionProviderCode)
            Me.floDataDisplay.Controls.Add(Me.lblPensionProviderName)
            Me.floDataDisplay.Controls.Add(Me.txtPensionProviderName)
            Me.floDataDisplay.Controls.Add(Me.lblPensionProviderNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtPensionProviderNameAra)
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
            Me.floDataDisplay.Controls.Add(Me.lblBankIdNo)
            Me.floDataDisplay.Controls.Add(Me.cacBankIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblBankAccountNo)
            Me.floDataDisplay.Controls.Add(Me.txtBankAccountNo)
            Me.floDataDisplay.Controls.Add(Me.lblIban)
            Me.floDataDisplay.Controls.Add(Me.txtIban)
            Me.floDataDisplay.Controls.Add(Me.lblPaymentMethod)
            Me.floDataDisplay.Controls.Add(Me.cacPaymentMethod)
            Me.floDataDisplay.Controls.Add(Me.lblActive)
            Me.floDataDisplay.Controls.Add(Me.chkActive)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'cacCountryCode
            '
            Me.cacCountryCode.BackColor = System.Drawing.Color.White
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DefaultValue = Nothing
            Me.cacCountryCode.DisplayMember = "Name"
            Me.cacCountryCode.EditingMode = False
            Me.cacCountryCode.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacCountryCode, True)
            resources.ApplyResources(Me.cacCountryCode, "cacCountryCode")
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.LinkedLabel = Nothing
            Me.cacCountryCode.Name = "cacCountryCode"
            Me.cacCountryCode.OldValue = 0
            Me.cacCountryCode.OriginalDataSource = Nothing
            Me.cacCountryCode.OriginalList = Nothing
            Me.cacCountryCode.OverrideDropDownStyleList = False
            Me.cacCountryCode.PreviousSearchTerm = Nothing
            Me.cacCountryCode.PropertySelector = Nothing
            Me.cacCountryCode.ReadOnlyCombo = False
            Me.cacCountryCode.SuggestBoxHeight = 200
            Me.cacCountryCode.SuggestListOrderRule = Nothing
            Me.cacCountryCode.TextToSearch = Nothing
            Me.cacCountryCode.ValueIsMandatory = False
            Me.cacCountryCode.ValueIsNullable = False
            Me.cacCountryCode.ValueIsNumeric = False
            Me.cacCountryCode.ValueMember = "Code"
            '
            'cacBankIdNo
            '
            Me.cacBankIdNo.BackColor = System.Drawing.Color.White
            Me.cacBankIdNo.ChangingSearchValueOnly = False
            Me.cacBankIdNo.CurrentSearchTerm = ""
            Me.cacBankIdNo.DefaultValue = Nothing
            Me.cacBankIdNo.DisplayMember = "Name"
            Me.cacBankIdNo.EditingMode = False
            Me.cacBankIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cacBankIdNo, "cacBankIdNo")
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cacBankIdNo.ValueIsMandatory = False
            Me.cacBankIdNo.ValueIsNullable = False
            Me.cacBankIdNo.ValueIsNumeric = False
            Me.cacBankIdNo.ValueMember = "IdNo"
            '
            'cacPaymentMethod
            '
            Me.cacPaymentMethod.BackColor = System.Drawing.Color.White
            Me.cacPaymentMethod.ChangingSearchValueOnly = False
            Me.cacPaymentMethod.CurrentSearchTerm = ""
            Me.cacPaymentMethod.DefaultValue = Nothing
            Me.cacPaymentMethod.DisplayMember = "Name"
            Me.cacPaymentMethod.EditingMode = False
            Me.cacPaymentMethod.FilterRule = Nothing
            Me.floDataDisplay.SetFlowBreak(Me.cacPaymentMethod, True)
            resources.ApplyResources(Me.cacPaymentMethod, "cacPaymentMethod")
            Me.cacPaymentMethod.ForeColor = System.Drawing.Color.Black
            Me.cacPaymentMethod.FormattingEnabled = True
            Me.cacPaymentMethod.HideWhenNotEditingOrAdding = False
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
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = true
        Me.chkActive.OldValue = Nothing
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'PensionProviderEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PensionProviderEntryTv"
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents _MBPensionProviderCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents _MBMainAccountNotEditable As LocalizableMessageBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblPensionProviderCode As CLabel
        Friend WithEvents txtPensionProviderCode As CTextBox
        Friend WithEvents lblPensionProviderName As CLabel
        Friend WithEvents txtPensionProviderName As CTextBox
        Friend WithEvents lblPensionProviderNameAra As CLabel
        Friend WithEvents txtPensionProviderNameAra As CTextBoxArabic
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
        Friend WithEvents lblBankIdNo As CLabel
        Friend WithEvents lblBankAccountNo As CLabel
        Friend WithEvents txtBankAccountNo As CTextBox
        Friend WithEvents lblIban As CLabel
        Friend WithEvents txtIban As CTextBox
        Friend WithEvents lblPaymentMethod As CLabel
        Friend WithEvents chkActive As CCheckBox
        Friend WithEvents lblActive As CLabel
        Friend WithEvents cacCountryCode As CaComboBox
        Friend WithEvents cacBankIdNo As CaComboBox
        Friend WithEvents cacPaymentMethod As CaComboBox
        Friend WithEvents CLabel1 As CLabel
    End Class
End Namespace