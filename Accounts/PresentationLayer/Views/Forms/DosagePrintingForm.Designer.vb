Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DosagePrintingForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DosagePrintingForm))
            Dim CBlendItems2 As AATM.Libraries.CBaseControlsLibrary.cBlendItems = New AATM.Libraries.CBaseControlsLibrary.cBlendItems()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDoseUnit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDuration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDose = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDosageName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDosageCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblFileNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAge = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.btnScanQrCode = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.cboItemIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.txtItemName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTin = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBarCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBarCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGtin = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboPatientType = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.cboDurationUnit = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.cboDoseUnit = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.txtDosageNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnFindPatient = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblItemName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtItemCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboGender = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.cboAgeYmd = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.btnClear = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.btnClear)
            Me.SplitContainer1.Panel2.Controls.Add(Me.CButton1)
            Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(870, 551)
            Me.SplitContainer1.SplitterDistance = 308
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(308, 551)
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
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.Color.White
            Me.CTextBox1.BegFindValue = Nothing
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.EndFindValue = Nothing
            Me.CTextBox1.FieldDescription = Nothing
            Me.CTextBox1.FieldName = Nothing
            Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox1.FindEnabled = False
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(11, 123)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Multiline = True
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.OverrideMaxLength = 0
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(505, 47)
            Me.CTextBox1.TabIndex = 305
            Me.CTextBox1.Translatable = False
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Location = New System.Drawing.Point(19, 502)
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            Me.CButton1.Size = New System.Drawing.Size(130, 25)
            Me.CButton1.TabIndex = 295
            Me.CButton1.Text = "Add New Dosage"
            '
            'lblGender
            '
            Me.lblGender.AutoSize = True
            Me.lblGender.BackColor = System.Drawing.Color.Transparent
            Me.lblGender.DisplayOnly = True
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.Location = New System.Drawing.Point(414, 357)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(56, 17)
            Me.lblGender.TabIndex = 310
            Me.lblGender.Text = "Gender"
            Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGender.Translatable = True
            '
            'lblDoseUnit
            '
            Me.lblDoseUnit.AutoSize = True
            Me.lblDoseUnit.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblDoseUnit, 2)
            Me.lblDoseUnit.DisplayOnly = True
            Me.lblDoseUnit.EditingMode = False
            Me.lblDoseUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDoseUnit.Location = New System.Drawing.Point(111, 137)
            Me.lblDoseUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDoseUnit.Name = "lblDoseUnit"
            Me.lblDoseUnit.Size = New System.Drawing.Size(70, 17)
            Me.lblDoseUnit.TabIndex = 2
            Me.lblDoseUnit.Text = "Dose Unit"
            Me.lblDoseUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDoseUnit.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(11, 137)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(67, 17)
            Me.CLabel1.TabIndex = 0
            Me.CLabel1.Text = "Dose Qty"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel10
            '
            Me.CLabel10.AutoSize = True
            Me.CLabel10.BackColor = System.Drawing.Color.Transparent
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(256, 11)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(74, 23)
            Me.CLabel10.TabIndex = 301
            Me.CLabel10.Text = "Code "
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel10.Translatable = True
            '
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(11, 11)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(47, 17)
            Me.CLabel5.TabIndex = 299
            Me.CLabel5.Text = "ID No."
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtDuration
            '
            Me.txtDuration.AlwaysEditable = True
            Me.txtDuration.BackColor = System.Drawing.Color.White
            Me.txtDuration.BegFindValue = Nothing
            Me.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDuration.ComputedValue = False
            Me.txtDuration.CustomFormat = Nothing
            Me.txtDuration.DataBoundControl = True
            Me.txtDuration.Editable = True
            Me.txtDuration.EditingMode = True
            Me.txtDuration.EndFindValue = Nothing
            Me.txtDuration.FieldDescription = Nothing
            Me.txtDuration.FieldName = Nothing
            Me.txtDuration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDuration.FindEnabled = False
            Me.txtDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDuration.ForeColor = System.Drawing.Color.Black
            Me.txtDuration.LinkedLabel = Nothing
            Me.txtDuration.Location = New System.Drawing.Point(11, 331)
            Me.txtDuration.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDuration.MaximumValue = Nothing
            Me.txtDuration.MinimumValue = Nothing
            Me.txtDuration.Name = "txtDuration"
            Me.txtDuration.OldValue = Nothing
            Me.txtDuration.OverrideMaxLength = 0
            Me.txtDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDuration.Size = New System.Drawing.Size(98, 23)
            Me.txtDuration.TabIndex = 14
            Me.txtDuration.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.AutoSize = True
            Me.CLabel8.BackColor = System.Drawing.Color.Transparent
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel8.Location = New System.Drawing.Point(11, 312)
            Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel8.Name = "CLabel8"
            Me.CLabel8.Size = New System.Drawing.Size(62, 17)
            Me.CLabel8.TabIndex = 294
            Me.CLabel8.Text = "Duration"
            Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel8.Translatable = True
            '
            'CLabel7
            '
            Me.CLabel7.AutoSize = True
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel7, 2)
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel7.Location = New System.Drawing.Point(111, 312)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(91, 17)
            Me.CLabel7.TabIndex = 12
            Me.CLabel7.Text = "Duration Unit"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'txtDose
            '
            Me.txtDose.AlwaysEditable = True
            Me.txtDose.BackColor = System.Drawing.Color.White
            Me.txtDose.BegFindValue = Nothing
            Me.txtDose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDose.ComputedValue = False
            Me.txtDose.CustomFormat = Nothing
            Me.txtDose.DataBoundControl = True
            Me.txtDose.EditingMode = True
            Me.txtDose.EndFindValue = Nothing
            Me.txtDose.FieldDescription = Nothing
            Me.txtDose.FieldName = Nothing
            Me.txtDose.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDose.FindEnabled = False
            Me.txtDose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDose.ForeColor = System.Drawing.Color.Black
            Me.txtDose.LinkedLabel = Nothing
            Me.txtDose.Location = New System.Drawing.Point(11, 156)
            Me.txtDose.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDose.MaximumValue = Nothing
            Me.txtDose.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtDose.MinimumValue = Nothing
            Me.txtDose.Name = "txtDose"
            Me.txtDose.OldValue = Nothing
            Me.txtDose.OverrideMaxLength = 0
            Me.txtDose.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDose.Size = New System.Drawing.Size(98, 23)
            Me.txtDose.TabIndex = 10
            Me.txtDose.Translatable = False
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtIdNo, 2)
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.DisplayOnly = True
            Me.txtIdNo.Editable = True
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = False
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Nothing
            Me.txtIdNo.Location = New System.Drawing.Point(111, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.ReadOnly = True
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(98, 23)
            Me.txtIdNo.TabIndex = 3
            Me.txtIdNo.Translatable = False
            '
            'txtDosageName
            '
            Me.txtDosageName.BackColor = System.Drawing.Color.White
            Me.txtDosageName.BegFindValue = Nothing
            Me.txtDosageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageName, 6)
            Me.txtDosageName.ComputedValue = False
            Me.txtDosageName.CustomFormat = Nothing
            Me.txtDosageName.DataBoundControl = True
            Me.txtDosageName.DisplayOnly = True
            Me.txtDosageName.EditingMode = True
            Me.txtDosageName.EndFindValue = Nothing
            Me.txtDosageName.FieldDescription = Nothing
            Me.txtDosageName.FieldName = Nothing
            Me.txtDosageName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageName.FindEnabled = False
            Me.txtDosageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageName.ForeColor = System.Drawing.Color.Black
            Me.txtDosageName.LinkedLabel = Nothing
            Me.txtDosageName.Location = New System.Drawing.Point(11, 201)
            Me.txtDosageName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageName.MaximumValue = Nothing
            Me.txtDosageName.MinimumValue = Nothing
            Me.txtDosageName.Multiline = True
            Me.txtDosageName.Name = "txtDosageName"
            Me.txtDosageName.OldValue = Nothing
            Me.txtDosageName.OverrideMaxLength = 0
            Me.txtDosageName.ReadOnly = True
            Me.txtDosageName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageName.Size = New System.Drawing.Size(515, 44)
            Me.txtDosageName.TabIndex = 12
            Me.txtDosageName.Translatable = False
            '
            'txtDosageCode
            '
            Me.txtDosageCode.BackColor = System.Drawing.Color.White
            Me.txtDosageCode.BegFindValue = Nothing
            Me.txtDosageCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageCode, 2)
            Me.txtDosageCode.ComputedValue = False
            Me.txtDosageCode.CustomFormat = Nothing
            Me.txtDosageCode.DataBoundControl = True
            Me.txtDosageCode.DisplayOnly = True
            Me.txtDosageCode.Editable = True
            Me.txtDosageCode.EditingMode = True
            Me.txtDosageCode.EndFindValue = Nothing
            Me.txtDosageCode.FieldDescription = Nothing
            Me.txtDosageCode.FieldName = Nothing
            Me.txtDosageCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageCode.FindEnabled = False
            Me.txtDosageCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageCode.ForeColor = System.Drawing.Color.Black
            Me.txtDosageCode.LinkedLabel = Nothing
            Me.txtDosageCode.Location = New System.Drawing.Point(332, 11)
            Me.txtDosageCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageCode.MaximumValue = Nothing
            Me.txtDosageCode.MinimumValue = Nothing
            Me.txtDosageCode.Name = "txtDosageCode"
            Me.txtDosageCode.OldValue = Nothing
            Me.txtDosageCode.OverrideMaxLength = 0
            Me.txtDosageCode.ReadOnly = True
            Me.txtDosageCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageCode.Size = New System.Drawing.Size(194, 23)
            Me.txtDosageCode.TabIndex = 4
            Me.txtDosageCode.Translatable = False
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.CLabel11.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 3)
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(11, 247)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(142, 17)
            Me.CLabel11.TabIndex = 303
            Me.CLabel11.Text = "Dosage Name Arabic"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.CLabel11.Translatable = True
            '
            'CLabel12
            '
            Me.CLabel12.AutoSize = True
            Me.CLabel12.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel12, 3)
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel12.Location = New System.Drawing.Point(11, 182)
            Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel12.Name = "CLabel12"
            Me.CLabel12.Size = New System.Drawing.Size(98, 17)
            Me.CLabel12.TabIndex = 304
            Me.CLabel12.Text = "Dosage Name"
            Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel12.Translatable = True
            '
            'lblFileNo
            '
            Me.lblFileNo.AutoSize = True
            Me.lblFileNo.BackColor = System.Drawing.Color.Transparent
            Me.lblFileNo.DisplayOnly = True
            Me.lblFileNo.EditingMode = False
            Me.lblFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFileNo.Location = New System.Drawing.Point(11, 357)
            Me.lblFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFileNo.Name = "lblFileNo"
            Me.lblFileNo.Size = New System.Drawing.Size(56, 17)
            Me.lblFileNo.TabIndex = 307
            Me.lblFileNo.Text = "File No."
            Me.lblFileNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFileNo.Translatable = True
            '
            'txtPatientName
            '
            Me.txtPatientName.AlwaysEditable = True
            Me.txtPatientName.BackColor = System.Drawing.Color.White
            Me.txtPatientName.BegFindValue = Nothing
            Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientName, 6)
            Me.txtPatientName.ComputedValue = False
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
            Me.txtPatientName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPatientName.Editable = True
            Me.txtPatientName.EditingMode = True
            Me.txtPatientName.EndFindValue = Nothing
            Me.txtPatientName.FieldDescription = Nothing
            Me.txtPatientName.FieldName = Nothing
            Me.txtPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientName.FindEnabled = False
            Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientName.ForeColor = System.Drawing.Color.Black
            Me.txtPatientName.LinkedLabel = Nothing
            Me.txtPatientName.Location = New System.Drawing.Point(11, 426)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(561, 23)
            Me.txtPatientName.TabIndex = 21
            Me.txtPatientName.Translatable = False
            '
            'lblAge
            '
            Me.lblAge.AutoSize = True
            Me.lblAge.BackColor = System.Drawing.Color.Transparent
            Me.lblAge.DisplayOnly = True
            Me.lblAge.EditingMode = False
            Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAge.Location = New System.Drawing.Point(256, 357)
            Me.lblAge.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAge.Name = "lblAge"
            Me.lblAge.Size = New System.Drawing.Size(33, 17)
            Me.lblAge.TabIndex = 311
            Me.lblAge.Text = "Age"
            Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAge.Translatable = True
            '
            'txtAge
            '
            Me.txtAge.AlwaysEditable = True
            Me.txtAge.BackColor = System.Drawing.Color.White
            Me.txtAge.BegFindValue = Nothing
            Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAge.ComputedValue = False
            Me.txtAge.CustomFormat = Nothing
            Me.txtAge.DataBoundControl = True
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = False
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(332, 376)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(80, 23)
            Me.txtAge.TabIndex = 18
            Me.txtAge.Translatable = False
            '
            'lblPatientName
            '
            Me.lblPatientName.AutoSize = True
            Me.lblPatientName.BackColor = System.Drawing.Color.Transparent
            Me.lblPatientName.DisplayOnly = True
            Me.lblPatientName.EditingMode = False
            Me.lblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPatientName.Location = New System.Drawing.Point(11, 407)
            Me.lblPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPatientName.Name = "lblPatientName"
            Me.lblPatientName.Size = New System.Drawing.Size(93, 17)
            Me.lblPatientName.TabIndex = 314
            Me.lblPatientName.Text = "Patient Name"
            Me.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPatientName.Translatable = True
            '
            'txtFileNo
            '
            Me.txtFileNo.AlwaysEditable = True
            Me.txtFileNo.BackColor = System.Drawing.Color.White
            Me.txtFileNo.BegFindValue = Nothing
            Me.txtFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFileNo.ComputedValue = False
            Me.txtFileNo.CustomFormat = Nothing
            Me.txtFileNo.DataBoundControl = True
            Me.txtFileNo.EditingMode = True
            Me.txtFileNo.EndFindValue = Nothing
            Me.txtFileNo.FieldDescription = Nothing
            Me.txtFileNo.FieldName = Nothing
            Me.txtFileNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFileNo.FindEnabled = False
            Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFileNo.ForeColor = System.Drawing.Color.Black
            Me.txtFileNo.LinkedLabel = Nothing
            Me.txtFileNo.Location = New System.Drawing.Point(11, 376)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(98, 23)
            Me.txtFileNo.TabIndex = 16
            Me.txtFileNo.Translatable = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.btnScanQrCode, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboItemIdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtItemName, 0, 17)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 4, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGTin, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtBarCode, 4, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblBarCode, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGtin, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGenericName, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.cboPatientType, 1, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDurationUnit, 1, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDoseUnit, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 0, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFileNo, 0, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageNameAra, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageCode, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageName, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDose, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDuration, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.btnFindPatient, 2, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.lblDoseUnit, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 1, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblItemName, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtItemCode, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 0, 16)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAge, 3, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGender, 5, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 0, 15)
            Me.TableLayoutPanel1.Controls.Add(Me.cboGender, 5, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAgeYmd, 3, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 4, 14)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 17)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
            Me.TableLayoutPanel1.RowCount = 18
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(540, 482)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'btnScanQrCode
            '
            Me.btnScanQrCode.DesignerSelected = True
            Me.btnScanQrCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnScanQrCode.ImageIndex = 0
            Me.btnScanQrCode.Location = New System.Drawing.Point(413, 35)
            Me.btnScanQrCode.Margin = New System.Windows.Forms.Padding(0)
            Me.btnScanQrCode.Name = "btnScanQrCode"
            Me.btnScanQrCode.OriginalImageName = Nothing
            Me.btnScanQrCode.SecurityKey = ""
            Me.btnScanQrCode.Size = New System.Drawing.Size(90, 20)
            Me.btnScanQrCode.TabIndex = 328
            Me.btnScanQrCode.Text = "Scan Qr Code"
            Me.btnScanQrCode.TextMargin = New System.Windows.Forms.Padding(0)
            '
            'cboItemIdNo
            '
            Me.cboItemIdNo.BackColor = System.Drawing.Color.White
            Me.cboItemIdNo.BegFindValue = Nothing
            Me.cboItemIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboItemIdNo, 5)
            Me.cboItemIdNo.CurrentSearchTerm = ""
            Me.cboItemIdNo.DataValue = Nothing
            Me.cboItemIdNo.DefaultValue = Nothing
            Me.cboItemIdNo.DisplayMember = "Name"
            Me.cboItemIdNo.Editable = True
            Me.cboItemIdNo.EditingMode = True
            Me.cboItemIdNo.EndFindValue = Nothing
            Me.cboItemIdNo.FieldDescription = Nothing
            Me.cboItemIdNo.FieldName = Nothing
            Me.cboItemIdNo.FilterRule = Nothing
            Me.cboItemIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboItemIdNo.FindEnabled = False
            Me.cboItemIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboItemIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboItemIdNo.FormattingEnabled = True
            Me.cboItemIdNo.HideWhenNotEditingOrAdding = False
            Me.cboItemIdNo.IgnoreCase = False
            Me.cboItemIdNo.IntegralHeight = False
            Me.cboItemIdNo.LimitToList = False
            Me.cboItemIdNo.LinkedLabel = Nothing
            Me.cboItemIdNo.Location = New System.Drawing.Point(111, 61)
            Me.cboItemIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboItemIdNo.Name = "cboItemIdNo"
            Me.cboItemIdNo.OldValue = 0
            Me.cboItemIdNo.OriginalDataSource = Nothing
            Me.cboItemIdNo.OriginalList = Nothing
            Me.cboItemIdNo.OverrideDropDownStyleList = False
            Me.cboItemIdNo.PreviousSearchTerm = Nothing
            Me.cboItemIdNo.PropertySelector = Nothing
            Me.cboItemIdNo.Size = New System.Drawing.Size(415, 24)
            Me.cboItemIdNo.SuggestBoxHeight = 200
            Me.cboItemIdNo.SuggestCharCount = 4
            Me.cboItemIdNo.SuggestListOrderRule = Nothing
            Me.cboItemIdNo.TabIndex = 7
            Me.cboItemIdNo.TextToSearch = Nothing
            Me.cboItemIdNo.Translatable = False
            Me.cboItemIdNo.ValueIsMandatory = False
            Me.cboItemIdNo.ValueIsNullable = False
            Me.cboItemIdNo.ValueIsNumeric = False
            Me.cboItemIdNo.ValueMember = "IdNo"
            '
            'txtItemName
            '
            Me.txtItemName.AlwaysEditable = True
            Me.txtItemName.BackColor = System.Drawing.Color.White
            Me.txtItemName.BegFindValue = Nothing
            Me.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtItemName, 6)
            Me.txtItemName.ComputedValue = False
            Me.txtItemName.CustomFormat = Nothing
            Me.txtItemName.DataBoundControl = True
            Me.txtItemName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtItemName.Editable = True
            Me.txtItemName.EditingMode = True
            Me.txtItemName.EndFindValue = Nothing
            Me.txtItemName.FieldDescription = Nothing
            Me.txtItemName.FieldName = Nothing
            Me.txtItemName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtItemName.FindEnabled = False
            Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtItemName.ForeColor = System.Drawing.Color.Black
            Me.txtItemName.LinkedLabel = Nothing
            Me.txtItemName.Location = New System.Drawing.Point(11, 451)
            Me.txtItemName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtItemName.MaximumValue = Nothing
            Me.txtItemName.MinimumValue = Nothing
            Me.txtItemName.Name = "txtItemName"
            Me.txtItemName.OldValue = Nothing
            Me.txtItemName.OverrideMaxLength = 0
            Me.txtItemName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtItemName.Size = New System.Drawing.Size(561, 23)
            Me.txtItemName.TabIndex = 22
            Me.txtItemName.Translatable = False
            Me.txtItemName.Visible = False
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(332, 357)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(74, 17)
            Me.CLabel3.TabIndex = 327
            Me.CLabel3.Text = "Yr/Mo/Day"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'txtGTin
            '
            Me.txtGTin.AlwaysEditable = True
            Me.txtGTin.BackColor = System.Drawing.Color.White
            Me.txtGTin.BegFindValue = Nothing
            Me.txtGTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtGTin, 2)
            Me.txtGTin.ComputedValue = False
            Me.txtGTin.CustomFormat = Nothing
            Me.txtGTin.DataBoundControl = True
            Me.txtGTin.EditingMode = True
            Me.txtGTin.EndFindValue = Nothing
            Me.txtGTin.FieldDescription = Nothing
            Me.txtGTin.FieldName = Nothing
            Me.txtGTin.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTin.FindEnabled = False
            Me.txtGTin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGTin.ForeColor = System.Drawing.Color.Black
            Me.txtGTin.LinkedLabel = Nothing
            Me.txtGTin.Location = New System.Drawing.Point(256, 36)
            Me.txtGTin.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTin.MaximumValue = Nothing
            Me.txtGTin.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtGTin.MinimumValue = Nothing
            Me.txtGTin.Name = "txtGTin"
            Me.txtGTin.OldValue = Nothing
            Me.txtGTin.OverrideMaxLength = 0
            Me.txtGTin.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTin.Size = New System.Drawing.Size(156, 23)
            Me.txtGTin.TabIndex = 5
            Me.txtGTin.Translatable = False
            '
            'txtBarCode
            '
            Me.txtBarCode.AlwaysEditable = True
            Me.txtBarCode.BackColor = System.Drawing.Color.White
            Me.txtBarCode.BegFindValue = Nothing
            Me.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtBarCode, 2)
            Me.txtBarCode.ComputedValue = False
            Me.txtBarCode.CustomFormat = Nothing
            Me.txtBarCode.DataBoundControl = True
            Me.txtBarCode.Editable = True
            Me.txtBarCode.EditingMode = True
            Me.txtBarCode.EndFindValue = Nothing
            Me.txtBarCode.FieldDescription = Nothing
            Me.txtBarCode.FieldName = Nothing
            Me.txtBarCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBarCode.FindEnabled = False
            Me.txtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBarCode.ForeColor = System.Drawing.Color.Black
            Me.txtBarCode.LinkedLabel = Nothing
            Me.txtBarCode.Location = New System.Drawing.Point(332, 87)
            Me.txtBarCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBarCode.MaximumValue = Nothing
            Me.txtBarCode.MinimumValue = Nothing
            Me.txtBarCode.Name = "txtBarCode"
            Me.txtBarCode.OldValue = Nothing
            Me.txtBarCode.OverrideMaxLength = 0
            Me.txtBarCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBarCode.Size = New System.Drawing.Size(194, 23)
            Me.txtBarCode.TabIndex = 8
            Me.txtBarCode.Translatable = False
            '
            'lblBarCode
            '
            Me.lblBarCode.AutoSize = True
            Me.lblBarCode.BackColor = System.Drawing.Color.Transparent
            Me.lblBarCode.DisplayOnly = True
            Me.lblBarCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblBarCode.EditingMode = False
            Me.lblBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBarCode.Location = New System.Drawing.Point(256, 87)
            Me.lblBarCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBarCode.Name = "lblBarCode"
            Me.lblBarCode.Size = New System.Drawing.Size(74, 23)
            Me.lblBarCode.TabIndex = 323
            Me.lblBarCode.Text = "BarCode"
            Me.lblBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblBarCode.Translatable = True
            '
            'lblGtin
            '
            Me.lblGtin.AutoSize = True
            Me.lblGtin.BackColor = System.Drawing.Color.Transparent
            Me.lblGtin.DisplayOnly = True
            Me.lblGtin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblGtin.EditingMode = False
            Me.lblGtin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGtin.Location = New System.Drawing.Point(213, 36)
            Me.lblGtin.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGtin.Name = "lblGtin"
            Me.lblGtin.Size = New System.Drawing.Size(41, 23)
            Me.lblGtin.TabIndex = 322
            Me.lblGtin.Text = "GTIN"
            Me.lblGtin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblGtin.Translatable = True
            '
            'txtGenericName
            '
            Me.txtGenericName.AlwaysEditable = True
            Me.txtGenericName.BackColor = System.Drawing.Color.White
            Me.txtGenericName.BegFindValue = Nothing
            Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtGenericName, 6)
            Me.txtGenericName.ComputedValue = False
            Me.txtGenericName.CustomFormat = Nothing
            Me.txtGenericName.DataBoundControl = True
            Me.txtGenericName.Editable = True
            Me.txtGenericName.EditingMode = True
            Me.txtGenericName.EndFindValue = Nothing
            Me.txtGenericName.FieldDescription = Nothing
            Me.txtGenericName.FieldName = Nothing
            Me.txtGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGenericName.FindEnabled = False
            Me.txtGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtGenericName.LinkedLabel = Nothing
            Me.txtGenericName.Location = New System.Drawing.Point(11, 112)
            Me.txtGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGenericName.MaximumValue = Nothing
            Me.txtGenericName.MinimumValue = Nothing
            Me.txtGenericName.Name = "txtGenericName"
            Me.txtGenericName.OldValue = Nothing
            Me.txtGenericName.OverrideMaxLength = 0
            Me.txtGenericName.ReadOnly = True
            Me.txtGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGenericName.Size = New System.Drawing.Size(515, 23)
            Me.txtGenericName.TabIndex = 9
            Me.txtGenericName.Translatable = False
            '
            'cboPatientType
            '
            Me.cboPatientType.BackColor = System.Drawing.Color.White
            Me.cboPatientType.BegFindValue = Nothing
            Me.cboPatientType.ChangingSearchValueOnly = False
            Me.cboPatientType.CurrentSearchTerm = ""
            Me.cboPatientType.DataValue = Nothing
            Me.cboPatientType.DefaultValue = Nothing
            Me.cboPatientType.DisplayMember = "IdNo"
            Me.cboPatientType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPatientType.Editable = True
            Me.cboPatientType.EditingMode = True
            Me.cboPatientType.EndFindValue = Nothing
            Me.cboPatientType.FieldDescription = Nothing
            Me.cboPatientType.FieldName = Nothing
            Me.cboPatientType.FilterRule = Nothing
            Me.cboPatientType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPatientType.FindEnabled = False
            Me.cboPatientType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPatientType.ForeColor = System.Drawing.Color.Black
            Me.cboPatientType.FormattingEnabled = True
            Me.cboPatientType.HideWhenNotEditingOrAdding = False
            Me.cboPatientType.IgnoreCase = False
            Me.cboPatientType.IntegralHeight = False
            Me.cboPatientType.LimitToList = False
            Me.cboPatientType.LinkedLabel = Nothing
            Me.cboPatientType.Location = New System.Drawing.Point(111, 376)
            Me.cboPatientType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPatientType.Name = "cboPatientType"
            Me.cboPatientType.OldValue = 0
            Me.cboPatientType.OriginalDataSource = Nothing
            Me.cboPatientType.OriginalList = Nothing
            Me.cboPatientType.OverrideDropDownStyleList = False
            Me.cboPatientType.PreviousSearchTerm = Nothing
            Me.cboPatientType.PropertySelector = Nothing
            Me.cboPatientType.Size = New System.Drawing.Size(100, 24)
            Me.cboPatientType.SuggestBoxHeight = 200
            Me.cboPatientType.SuggestCharCount = 0
            Me.cboPatientType.SuggestListOrderRule = Nothing
            Me.cboPatientType.TabIndex = 17
            Me.cboPatientType.TextToSearch = Nothing
            Me.cboPatientType.Translatable = False
            Me.cboPatientType.ValueIsMandatory = False
            Me.cboPatientType.ValueIsNullable = False
            Me.cboPatientType.ValueIsNumeric = True
            Me.cboPatientType.ValueMember = "IdNo"
            '
            'cboDurationUnit
            '
            Me.cboDurationUnit.BackColor = System.Drawing.Color.White
            Me.cboDurationUnit.BegFindValue = Nothing
            Me.cboDurationUnit.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDurationUnit, 2)
            Me.cboDurationUnit.CurrentSearchTerm = ""
            Me.cboDurationUnit.DataValue = Nothing
            Me.cboDurationUnit.DefaultValue = Nothing
            Me.cboDurationUnit.DisplayMember = "Name"
            Me.cboDurationUnit.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDurationUnit.Editable = True
            Me.cboDurationUnit.EditingMode = True
            Me.cboDurationUnit.EndFindValue = Nothing
            Me.cboDurationUnit.FieldDescription = Nothing
            Me.cboDurationUnit.FieldName = Nothing
            Me.cboDurationUnit.FilterRule = Nothing
            Me.cboDurationUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDurationUnit.FindEnabled = False
            Me.cboDurationUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDurationUnit.ForeColor = System.Drawing.Color.Black
            Me.cboDurationUnit.FormattingEnabled = True
            Me.cboDurationUnit.HideWhenNotEditingOrAdding = False
            Me.cboDurationUnit.IgnoreCase = False
            Me.cboDurationUnit.IntegralHeight = False
            Me.cboDurationUnit.LimitToList = False
            Me.cboDurationUnit.LinkedLabel = Nothing
            Me.cboDurationUnit.Location = New System.Drawing.Point(111, 331)
            Me.cboDurationUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDurationUnit.Name = "cboDurationUnit"
            Me.cboDurationUnit.OldValue = 0
            Me.cboDurationUnit.OriginalDataSource = Nothing
            Me.cboDurationUnit.OriginalList = Nothing
            Me.cboDurationUnit.OverrideDropDownStyleList = False
            Me.cboDurationUnit.PreviousSearchTerm = Nothing
            Me.cboDurationUnit.PropertySelector = Nothing
            Me.cboDurationUnit.Size = New System.Drawing.Size(143, 24)
            Me.cboDurationUnit.SuggestBoxHeight = 200
            Me.cboDurationUnit.SuggestCharCount = 0
            Me.cboDurationUnit.SuggestListOrderRule = Nothing
            Me.cboDurationUnit.TabIndex = 15
            Me.cboDurationUnit.TextToSearch = Nothing
            Me.cboDurationUnit.Translatable = False
            Me.cboDurationUnit.ValueIsMandatory = False
            Me.cboDurationUnit.ValueIsNullable = False
            Me.cboDurationUnit.ValueIsNumeric = True
            Me.cboDurationUnit.ValueMember = "IdNo"
            '
            'cboDoseUnit
            '
            Me.cboDoseUnit.BackColor = System.Drawing.Color.White
            Me.cboDoseUnit.BegFindValue = Nothing
            Me.cboDoseUnit.ChangingSearchValueOnly = False
            Me.cboDoseUnit.CurrentSearchTerm = ""
            Me.cboDoseUnit.DataValue = Nothing
            Me.cboDoseUnit.DefaultValue = Nothing
            Me.cboDoseUnit.DisplayMember = "Name"
            Me.cboDoseUnit.Editable = True
            Me.cboDoseUnit.EditingMode = True
            Me.cboDoseUnit.EndFindValue = Nothing
            Me.cboDoseUnit.FieldDescription = Nothing
            Me.cboDoseUnit.FieldName = Nothing
            Me.cboDoseUnit.FilterRule = Nothing
            Me.cboDoseUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDoseUnit.FindEnabled = False
            Me.cboDoseUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDoseUnit.ForeColor = System.Drawing.Color.Black
            Me.cboDoseUnit.FormattingEnabled = True
            Me.cboDoseUnit.HideWhenNotEditingOrAdding = False
            Me.cboDoseUnit.IgnoreCase = False
            Me.cboDoseUnit.IntegralHeight = False
            Me.cboDoseUnit.LimitToList = False
            Me.cboDoseUnit.LinkedLabel = Nothing
            Me.cboDoseUnit.Location = New System.Drawing.Point(111, 156)
            Me.cboDoseUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDoseUnit.Name = "cboDoseUnit"
            Me.cboDoseUnit.OldValue = 0
            Me.cboDoseUnit.OriginalDataSource = Nothing
            Me.cboDoseUnit.OriginalList = Nothing
            Me.cboDoseUnit.OverrideDropDownStyleList = False
            Me.cboDoseUnit.PreviousSearchTerm = Nothing
            Me.cboDoseUnit.PropertySelector = Nothing
            Me.cboDoseUnit.Size = New System.Drawing.Size(98, 24)
            Me.cboDoseUnit.SuggestBoxHeight = 200
            Me.cboDoseUnit.SuggestCharCount = 0
            Me.cboDoseUnit.SuggestListOrderRule = Nothing
            Me.cboDoseUnit.TabIndex = 11
            Me.cboDoseUnit.TextToSearch = Nothing
            Me.cboDoseUnit.Translatable = False
            Me.cboDoseUnit.ValueIsMandatory = False
            Me.cboDoseUnit.ValueIsNullable = False
            Me.cboDoseUnit.ValueIsNumeric = True
            Me.cboDoseUnit.ValueMember = "IdNo"
            '
            'txtDosageNameAra
            '
            Me.txtDosageNameAra.BackColor = System.Drawing.Color.White
            Me.txtDosageNameAra.BegFindValue = Nothing
            Me.txtDosageNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageNameAra, 6)
            Me.txtDosageNameAra.ComputedValue = False
            Me.txtDosageNameAra.CustomFormat = Nothing
            Me.txtDosageNameAra.DataBoundControl = True
            Me.txtDosageNameAra.DisplayOnly = True
            Me.txtDosageNameAra.EditingMode = True
            Me.txtDosageNameAra.EndFindValue = Nothing
            Me.txtDosageNameAra.FieldDescription = Nothing
            Me.txtDosageNameAra.FieldName = Nothing
            Me.txtDosageNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDosageNameAra.FindEnabled = False
            Me.txtDosageNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDosageNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDosageNameAra.LinkedLabel = Nothing
            Me.txtDosageNameAra.Location = New System.Drawing.Point(11, 266)
            Me.txtDosageNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageNameAra.MaximumValue = Nothing
            Me.txtDosageNameAra.MinimumValue = Nothing
            Me.txtDosageNameAra.Multiline = True
            Me.txtDosageNameAra.Name = "txtDosageNameAra"
            Me.txtDosageNameAra.OldValue = Nothing
            Me.txtDosageNameAra.OverrideMaxLength = 0
            Me.txtDosageNameAra.ReadOnly = True
            Me.txtDosageNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageNameAra.Size = New System.Drawing.Size(515, 44)
            Me.txtDosageNameAra.TabIndex = 13
            Me.txtDosageNameAra.Translatable = False
            '
            'btnFindPatient
            '
            Me.btnFindPatient.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.btnFindPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.White}
            CBlendItems2.iPoint = New Single() {0!, 1.0!}
            Me.btnFindPatient.ColorFillBlend = CBlendItems2
            Me.btnFindPatient.DesignerSelected = False
            Me.btnFindPatient.Image = Global.AATM.Accounts.My.Resources.Resources.btnfind
            Me.btnFindPatient.ImageIndex = 0
            Me.btnFindPatient.ImageSize = New System.Drawing.Size(23, 23)
            Me.btnFindPatient.Location = New System.Drawing.Point(215, 378)
            Me.btnFindPatient.Name = "btnFindPatient"
            Me.btnFindPatient.OriginalImageName = Nothing
            Me.btnFindPatient.SecurityKey = ""
            Me.btnFindPatient.Size = New System.Drawing.Size(28, 25)
            Me.btnFindPatient.TabIndex = 11
            Me.btnFindPatient.Text = ""
            '
            'lblItemName
            '
            Me.lblItemName.AutoSize = True
            Me.lblItemName.BackColor = System.Drawing.Color.Transparent
            Me.lblItemName.DisplayOnly = True
            Me.lblItemName.EditingMode = False
            Me.lblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItemName.Location = New System.Drawing.Point(11, 36)
            Me.lblItemName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblItemName.Name = "lblItemName"
            Me.lblItemName.Size = New System.Drawing.Size(64, 17)
            Me.lblItemName.TabIndex = 316
            Me.lblItemName.Text = "Medicine"
            Me.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItemName.Translatable = True
            '
            'txtItemCode
            '
            Me.txtItemCode.AlwaysEditable = True
            Me.txtItemCode.BackColor = System.Drawing.Color.White
            Me.txtItemCode.BegFindValue = Nothing
            Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtItemCode.ComputedValue = False
            Me.txtItemCode.CustomFormat = Nothing
            Me.txtItemCode.DataBoundControl = True
            Me.txtItemCode.Editable = True
            Me.txtItemCode.EditingMode = True
            Me.txtItemCode.EndFindValue = Nothing
            Me.txtItemCode.FieldDescription = Nothing
            Me.txtItemCode.FieldName = Nothing
            Me.txtItemCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtItemCode.FindEnabled = False
            Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtItemCode.ForeColor = System.Drawing.Color.Black
            Me.txtItemCode.LinkedLabel = Nothing
            Me.txtItemCode.Location = New System.Drawing.Point(11, 61)
            Me.txtItemCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtItemCode.MaximumValue = Nothing
            Me.txtItemCode.MinimumValue = Nothing
            Me.txtItemCode.Name = "txtItemCode"
            Me.txtItemCode.OldValue = Nothing
            Me.txtItemCode.OverrideMaxLength = 0
            Me.txtItemCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtItemCode.Size = New System.Drawing.Size(98, 23)
            Me.txtItemCode.TabIndex = 6
            Me.txtItemCode.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(11, 87)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(58, 17)
            Me.CLabel2.TabIndex = 317
            Me.CLabel2.Text = "Generic"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'cboGender
            '
            Me.cboGender.BackColor = System.Drawing.Color.White
            Me.cboGender.BegFindValue = Nothing
            Me.cboGender.ChangingSearchValueOnly = False
            Me.cboGender.CurrentSearchTerm = ""
            Me.cboGender.DataValue = Nothing
            Me.cboGender.DefaultValue = Nothing
            Me.cboGender.DisplayMember = "Name"
            Me.cboGender.DropDownHeight = 21
            Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboGender.Editable = True
            Me.cboGender.EditingMode = False
            Me.cboGender.EndFindValue = Nothing
            Me.cboGender.FieldDescription = Nothing
            Me.cboGender.FieldName = Nothing
            Me.cboGender.FilterRule = Nothing
            Me.cboGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboGender.FindEnabled = True
            Me.cboGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboGender.ForeColor = System.Drawing.Color.Black
            Me.cboGender.FormattingEnabled = True
            Me.cboGender.HideWhenNotEditingOrAdding = False
            Me.cboGender.IgnoreCase = False
            Me.cboGender.IntegralHeight = False
            Me.cboGender.LimitToList = False
            Me.cboGender.LinkedLabel = Me.lblGender
            Me.cboGender.Location = New System.Drawing.Point(413, 376)
            Me.cboGender.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboGender.MaxDropDownItems = 1
            Me.cboGender.Name = "cboGender"
            Me.cboGender.OldValue = 0
            Me.cboGender.OriginalDataSource = Nothing
            Me.cboGender.OriginalList = Nothing
            Me.cboGender.OverrideDropDownStyleList = False
            Me.cboGender.PreviousSearchTerm = Nothing
            Me.cboGender.PropertySelector = Nothing
            Me.cboGender.Size = New System.Drawing.Size(113, 24)
            Me.cboGender.SuggestBoxHeight = 200
            Me.cboGender.SuggestListOrderRule = Nothing
            Me.cboGender.TabIndex = 20
            Me.cboGender.TextToSearch = Nothing
            Me.cboGender.Translatable = False
            Me.cboGender.ValueIsMandatory = False
            Me.cboGender.ValueIsNullable = False
            Me.cboGender.ValueIsNumeric = False
            Me.cboGender.ValueMember = "Code"
            '
            'cboAgeYmd
            '
            Me.cboAgeYmd.BackColor = System.Drawing.Color.White
            Me.cboAgeYmd.BegFindValue = Nothing
            Me.cboAgeYmd.ChangingSearchValueOnly = False
            Me.cboAgeYmd.CurrentSearchTerm = ""
            Me.cboAgeYmd.DataValue = Nothing
            Me.cboAgeYmd.DefaultValue = Nothing
            Me.cboAgeYmd.DisplayMember = "Name"
            Me.cboAgeYmd.Editable = True
            Me.cboAgeYmd.EditingMode = True
            Me.cboAgeYmd.EndFindValue = Nothing
            Me.cboAgeYmd.FieldDescription = Nothing
            Me.cboAgeYmd.FieldName = Nothing
            Me.cboAgeYmd.FilterRule = Nothing
            Me.cboAgeYmd.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAgeYmd.FindEnabled = False
            Me.cboAgeYmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAgeYmd.ForeColor = System.Drawing.Color.Black
            Me.cboAgeYmd.FormattingEnabled = True
            Me.cboAgeYmd.HideWhenNotEditingOrAdding = False
            Me.cboAgeYmd.IgnoreCase = False
            Me.cboAgeYmd.IntegralHeight = False
            Me.cboAgeYmd.LimitToList = False
            Me.cboAgeYmd.LinkedLabel = Nothing
            Me.cboAgeYmd.Location = New System.Drawing.Point(256, 376)
            Me.cboAgeYmd.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAgeYmd.MaxDropDownItems = 1
            Me.cboAgeYmd.Name = "cboAgeYmd"
            Me.cboAgeYmd.OldValue = 0
            Me.cboAgeYmd.OriginalDataSource = Nothing
            Me.cboAgeYmd.OriginalList = Nothing
            Me.cboAgeYmd.OverrideDropDownStyleList = False
            Me.cboAgeYmd.PreviousSearchTerm = Nothing
            Me.cboAgeYmd.PropertySelector = Nothing
            Me.cboAgeYmd.Size = New System.Drawing.Size(74, 24)
            Me.cboAgeYmd.SuggestBoxHeight = 200
            Me.cboAgeYmd.SuggestListOrderRule = Nothing
            Me.cboAgeYmd.TabIndex = 19
            Me.cboAgeYmd.TextToSearch = Nothing
            Me.cboAgeYmd.Translatable = False
            Me.cboAgeYmd.ValueIsMandatory = False
            Me.cboAgeYmd.ValueIsNullable = False
            Me.cboAgeYmd.ValueIsNumeric = True
            Me.cboAgeYmd.ValueMember = "Code"
            '
            'btnClear
            '
            Me.btnClear.DesignerSelected = False
            Me.btnClear.ImageIndex = 0
            Me.btnClear.Location = New System.Drawing.Point(418, 502)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.OriginalImageName = Nothing
            Me.btnClear.SecurityKey = ""
            Me.btnClear.Size = New System.Drawing.Size(130, 25)
            Me.btnClear.TabIndex = 296
            Me.btnClear.Text = "Clear Values"
            '
            'DosagePrintingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(870, 606)
            Me.MinimumSize = New System.Drawing.Size(16, 100)
            Me.Name = "DosagePrintingForm"
            Me.Text = "Dosage Printing"
            Me.ViewDisplayName = "DosagePrintingForm"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CTextBox1 As CTextBox
        Friend WithEvents CButton1 As CButton
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtFileNo As CTextBox
        Friend WithEvents lblPatientName As CLabel
        Friend WithEvents txtAge As CTextBox
        Friend WithEvents lblAge As CLabel
        Friend WithEvents txtPatientName As CTextBox
        Friend WithEvents lblFileNo As CLabel
        Friend WithEvents CLabel12 As CLabel
        Friend WithEvents CLabel11 As CLabel
        Friend WithEvents txtDosageCode As CTextBox
        Friend WithEvents txtDosageName As CTextBox
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents txtDose As CTextBox
        Friend WithEvents CLabel7 As CLabel
        Friend WithEvents CLabel8 As CLabel
        Friend WithEvents txtDuration As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CLabel10 As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblDoseUnit As CLabel
        Friend WithEvents lblGender As CLabel
        Friend WithEvents txtDosageNameAra As CTextBox
        Friend WithEvents cboDoseUnit As AtmComboBox
        Friend WithEvents cboDurationUnit As AtmComboBox
        Friend WithEvents cboGender As AtmComboBox
        Friend WithEvents cboAgeYmd As AtmComboBox
        Friend WithEvents btnFindPatient As CButton
        Friend WithEvents cboPatientType As AtmComboBox
        Friend WithEvents lblItemName As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtItemCode As CTextBox
        Friend WithEvents txtGenericName As CTextBox
        Friend WithEvents lblGtin As CLabel
        Friend WithEvents txtBarCode As CTextBox
        Friend WithEvents lblBarCode As CLabel
        Friend WithEvents txtGTin As CTextBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents txtItemName As CTextBox
        Friend WithEvents cboItemIdNo As AtmComboBox
        Friend WithEvents btnScanQrCode As CButton
        Friend WithEvents btnClear As CButton
    End Class
End Namespace