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
            Me.cboDurationUnit = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboDoseUnit = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.txtDosageNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboAgeYmd = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.SplitContainer1.Panel2.Controls.Add(Me.CButton1)
            Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(905, 454)
            Me.SplitContainer1.SplitterDistance = 343
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(343, 454)
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
            Me.CButton1.Location = New System.Drawing.Point(19, 407)
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
            Me.lblGender.DisplayOnly = True
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.Location = New System.Drawing.Point(281, 300)
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
            Me.lblDoseUnit.DisplayOnly = True
            Me.lblDoseUnit.EditingMode = False
            Me.lblDoseUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDoseUnit.Location = New System.Drawing.Point(146, 36)
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
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(11, 36)
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
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(281, 11)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(122, 23)
            Me.CLabel10.TabIndex = 301
            Me.CLabel10.Text = "Code "
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel10.Translatable = True
            '
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
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
            Me.txtDuration.Location = New System.Drawing.Point(11, 230)
            Me.txtDuration.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDuration.MaximumValue = Nothing
            Me.txtDuration.MinimumValue = Nothing
            Me.txtDuration.Name = "txtDuration"
            Me.txtDuration.OldValue = Nothing
            Me.txtDuration.OverrideMaxLength = 0
            Me.txtDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDuration.Size = New System.Drawing.Size(98, 23)
            Me.txtDuration.TabIndex = 8
            Me.txtDuration.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.AutoSize = True
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel8.Location = New System.Drawing.Point(11, 211)
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
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel7.Location = New System.Drawing.Point(146, 211)
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
            Me.txtDose.Location = New System.Drawing.Point(11, 55)
            Me.txtDose.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDose.MaximumValue = Nothing
            Me.txtDose.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtDose.MinimumValue = Nothing
            Me.txtDose.Name = "txtDose"
            Me.txtDose.OldValue = Nothing
            Me.txtDose.OverrideMaxLength = 0
            Me.txtDose.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDose.Size = New System.Drawing.Size(98, 23)
            Me.txtDose.TabIndex = 4
            Me.txtDose.Translatable = False
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.DisplayOnly = True
            Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
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
            Me.txtIdNo.Location = New System.Drawing.Point(146, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.ReadOnly = True
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(133, 23)
            Me.txtIdNo.TabIndex = 0
            Me.txtIdNo.Translatable = False
            '
            'txtDosageName
            '
            Me.txtDosageName.BackColor = System.Drawing.Color.White
            Me.txtDosageName.BegFindValue = Nothing
            Me.txtDosageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageName, 4)
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
            Me.txtDosageName.Location = New System.Drawing.Point(11, 100)
            Me.txtDosageName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageName.MaximumValue = Nothing
            Me.txtDosageName.MinimumValue = Nothing
            Me.txtDosageName.Multiline = True
            Me.txtDosageName.Name = "txtDosageName"
            Me.txtDosageName.OldValue = Nothing
            Me.txtDosageName.OverrideMaxLength = 0
            Me.txtDosageName.ReadOnly = True
            Me.txtDosageName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageName.Size = New System.Drawing.Size(500, 44)
            Me.txtDosageName.TabIndex = 6
            Me.txtDosageName.Translatable = False
            '
            'txtDosageCode
            '
            Me.txtDosageCode.BackColor = System.Drawing.Color.White
            Me.txtDosageCode.BegFindValue = Nothing
            Me.txtDosageCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
            Me.txtDosageCode.Location = New System.Drawing.Point(405, 11)
            Me.txtDosageCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageCode.MaximumValue = Nothing
            Me.txtDosageCode.MinimumValue = Nothing
            Me.txtDosageCode.Name = "txtDosageCode"
            Me.txtDosageCode.OldValue = Nothing
            Me.txtDosageCode.OverrideMaxLength = 0
            Me.txtDosageCode.ReadOnly = True
            Me.txtDosageCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageCode.Size = New System.Drawing.Size(98, 23)
            Me.txtDosageCode.TabIndex = 1
            Me.txtDosageCode.Translatable = False
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(11, 146)
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel12, 2)
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel12.Location = New System.Drawing.Point(11, 81)
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
            Me.lblFileNo.DisplayOnly = True
            Me.lblFileNo.EditingMode = False
            Me.lblFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFileNo.Location = New System.Drawing.Point(11, 256)
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientName, 3)
            Me.txtPatientName.ComputedValue = False
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
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
            Me.txtPatientName.Location = New System.Drawing.Point(146, 275)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(400, 23)
            Me.txtPatientName.TabIndex = 11
            Me.txtPatientName.Translatable = False
            '
            'lblAge
            '
            Me.lblAge.AutoSize = True
            Me.lblAge.DisplayOnly = True
            Me.lblAge.EditingMode = False
            Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAge.Location = New System.Drawing.Point(11, 300)
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
            Me.txtAge.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = False
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(11, 319)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(133, 23)
            Me.txtAge.TabIndex = 12
            Me.txtAge.Translatable = False
            '
            'lblPatientName
            '
            Me.lblPatientName.AutoSize = True
            Me.lblPatientName.DisplayOnly = True
            Me.lblPatientName.EditingMode = False
            Me.lblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPatientName.Location = New System.Drawing.Point(146, 256)
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
            Me.txtFileNo.Location = New System.Drawing.Point(11, 275)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(98, 23)
            Me.txtFileNo.TabIndex = 10
            Me.txtFileNo.Translatable = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.cboDurationUnit, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDoseUnit, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAgeYmd, 1, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAge, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 1, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFileNo, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageCode, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageName, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDose, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDuration, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblDoseUnit, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGender, 2, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.cboGender, 2, 12)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 17)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
            Me.TableLayoutPanel1.RowCount = 13
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
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(526, 376)
            Me.TableLayoutPanel1.TabIndex = 0
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
            Me.cboDurationUnit.Location = New System.Drawing.Point(146, 230)
            Me.cboDurationUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDurationUnit.Name = "cboDurationUnit"
            Me.cboDurationUnit.OldValue = 0
            Me.cboDurationUnit.OriginalDataSource = Nothing
            Me.cboDurationUnit.OriginalList = Nothing
            Me.cboDurationUnit.OverrideDropDownStyleList = False
            Me.cboDurationUnit.PreviousSearchTerm = Nothing
            Me.cboDurationUnit.PropertySelector = Nothing
            Me.cboDurationUnit.Size = New System.Drawing.Size(221, 24)
            Me.cboDurationUnit.SuggestBoxHeight = 200
            Me.cboDurationUnit.SuggestCharCount = 0
            Me.cboDurationUnit.SuggestListOrderRule = Nothing
            Me.cboDurationUnit.TabIndex = 9
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDoseUnit, 2)
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
            Me.cboDoseUnit.Location = New System.Drawing.Point(146, 55)
            Me.cboDoseUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDoseUnit.Name = "cboDoseUnit"
            Me.cboDoseUnit.OldValue = 0
            Me.cboDoseUnit.OriginalDataSource = Nothing
            Me.cboDoseUnit.OriginalList = Nothing
            Me.cboDoseUnit.OverrideDropDownStyleList = False
            Me.cboDoseUnit.PreviousSearchTerm = Nothing
            Me.cboDoseUnit.PropertySelector = Nothing
            Me.cboDoseUnit.Size = New System.Drawing.Size(221, 24)
            Me.cboDoseUnit.SuggestBoxHeight = 200
            Me.cboDoseUnit.SuggestCharCount = 0
            Me.cboDoseUnit.SuggestListOrderRule = Nothing
            Me.cboDoseUnit.TabIndex = 5
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageNameAra, 4)
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
            Me.txtDosageNameAra.Location = New System.Drawing.Point(11, 165)
            Me.txtDosageNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageNameAra.MaximumValue = Nothing
            Me.txtDosageNameAra.MinimumValue = Nothing
            Me.txtDosageNameAra.Multiline = True
            Me.txtDosageNameAra.Name = "txtDosageNameAra"
            Me.txtDosageNameAra.OldValue = Nothing
            Me.txtDosageNameAra.OverrideMaxLength = 0
            Me.txtDosageNameAra.ReadOnly = True
            Me.txtDosageNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageNameAra.Size = New System.Drawing.Size(500, 44)
            Me.txtDosageNameAra.TabIndex = 7
            Me.txtDosageNameAra.Translatable = False
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
            Me.cboGender.DropDownHeight = 24
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
            Me.cboGender.Location = New System.Drawing.Point(280, 319)
            Me.cboGender.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboGender.MaxDropDownItems = 1
            Me.cboGender.Name = "cboGender"
            Me.cboGender.OldValue = 0
            Me.cboGender.OriginalDataSource = Nothing
            Me.cboGender.OriginalList = Nothing
            Me.cboGender.OverrideDropDownStyleList = False
            Me.cboGender.PreviousSearchTerm = Nothing
            Me.cboGender.PropertySelector = Nothing
            Me.cboGender.ReadOnlyCombo = False
            Me.cboGender.Size = New System.Drawing.Size(124, 24)
            Me.cboGender.SuggestBoxHeight = 200
            Me.cboGender.SuggestListOrderRule = Nothing
            Me.cboGender.TabIndex = 315
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
            Me.cboAgeYmd.Location = New System.Drawing.Point(146, 319)
            Me.cboAgeYmd.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAgeYmd.MaxDropDownItems = 1
            Me.cboAgeYmd.Name = "cboAgeYmd"
            Me.cboAgeYmd.OldValue = 0
            Me.cboAgeYmd.OriginalDataSource = Nothing
            Me.cboAgeYmd.OriginalList = Nothing
            Me.cboAgeYmd.OverrideDropDownStyleList = False
            Me.cboAgeYmd.PreviousSearchTerm = Nothing
            Me.cboAgeYmd.PropertySelector = Nothing
            Me.cboAgeYmd.ReadOnlyCombo = True
            Me.cboAgeYmd.Size = New System.Drawing.Size(93, 24)
            Me.cboAgeYmd.SuggestBoxHeight = 200
            Me.cboAgeYmd.SuggestListOrderRule = Nothing
            Me.cboAgeYmd.TabIndex = 13
            Me.cboAgeYmd.TextToSearch = Nothing
            Me.cboAgeYmd.Translatable = False
            Me.cboAgeYmd.ValueIsMandatory = False
            Me.cboAgeYmd.ValueIsNullable = False
            Me.cboAgeYmd.ValueIsNumeric = True
            Me.cboAgeYmd.ValueMember = "IdNo"
            '
            'DosagePrintingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(905, 507)
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
        Friend WithEvents cboDoseUnit As CtComboBox
        Friend WithEvents cboDurationUnit As CtComboBox
        Friend WithEvents cboGender As CaComboBox
        Friend WithEvents cboAgeYmd As CaComboBox
    End Class
End Namespace