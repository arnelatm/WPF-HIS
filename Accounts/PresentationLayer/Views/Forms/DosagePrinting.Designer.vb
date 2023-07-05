Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DosagePrinting
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DosagePrinting))
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDuration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDurationTiming = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.txtDose = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDosageName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDosageCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDosageNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboDosageUnit = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblFileNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAge = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblDirection = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CtComboBox1 = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.txtFrequency = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblFrequencyTiming = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CtComboBox2 = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboDirection = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboAgeDmy = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
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
            Me.SplitContainer1.Size = New System.Drawing.Size(905, 498)
            Me.SplitContainer1.SplitterDistance = 343
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(343, 498)
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
            Me.CButton1.Location = New System.Drawing.Point(19, 472)
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
            Me.lblGender.Location = New System.Drawing.Point(218, 380)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(56, 17)
            Me.lblGender.TabIndex = 310
            Me.lblGender.Text = "Gender"
            Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGender.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(114, 36)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(86, 17)
            Me.CLabel2.TabIndex = 2
            Me.CLabel2.Text = "Dosage Unit"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
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
            Me.CLabel10.Location = New System.Drawing.Point(218, 11)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(179, 23)
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
            Me.txtDuration.Location = New System.Drawing.Point(11, 320)
            Me.txtDuration.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDuration.MaximumValue = Nothing
            Me.txtDuration.MinimumValue = Nothing
            Me.txtDuration.Name = "txtDuration"
            Me.txtDuration.OldValue = Nothing
            Me.txtDuration.OverrideMaxLength = 0
            Me.txtDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDuration.Size = New System.Drawing.Size(98, 23)
            Me.txtDuration.TabIndex = 293
            Me.txtDuration.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.AutoSize = True
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel8.Location = New System.Drawing.Point(11, 300)
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
            Me.CLabel7.Location = New System.Drawing.Point(114, 300)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(91, 17)
            Me.CLabel7.TabIndex = 12
            Me.CLabel7.Text = "Duration Unit"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'cboDurationTiming
            '
            Me.cboDurationTiming.AlwaysEditable = True
            Me.cboDurationTiming.BackColor = System.Drawing.Color.White
            Me.cboDurationTiming.BegFindValue = Nothing
            Me.cboDurationTiming.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDurationTiming, 2)
            Me.cboDurationTiming.CurrentSearchTerm = ""
            Me.cboDurationTiming.DataValue = Nothing
            Me.cboDurationTiming.DefaultValue = Nothing
            Me.cboDurationTiming.DisplayMember = "Name"
            Me.cboDurationTiming.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDurationTiming.Editable = True
            Me.cboDurationTiming.EditingMode = True
            Me.cboDurationTiming.EndFindValue = Nothing
            Me.cboDurationTiming.FieldDescription = Nothing
            Me.cboDurationTiming.FieldName = Nothing
            Me.cboDurationTiming.FilterRule = Nothing
            Me.cboDurationTiming.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDurationTiming.FindEnabled = False
            Me.cboDurationTiming.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDurationTiming.ForeColor = System.Drawing.Color.Black
            Me.cboDurationTiming.FormattingEnabled = True
            Me.cboDurationTiming.HideWhenNotEditingOrAdding = False
            Me.cboDurationTiming.IgnoreCase = False
            Me.cboDurationTiming.IntegralHeight = False
            Me.cboDurationTiming.LinkedLabel = Nothing
            Me.cboDurationTiming.Location = New System.Drawing.Point(114, 320)
            Me.cboDurationTiming.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDurationTiming.Name = "cboDurationTiming"
            Me.cboDurationTiming.OldValue = 0
            Me.cboDurationTiming.OriginalDataSource = Nothing
            Me.cboDurationTiming.OriginalList = Nothing
            Me.cboDurationTiming.OverrideDropDownStyleList = False
            Me.cboDurationTiming.PreviousSearchTerm = Nothing
            Me.cboDurationTiming.PropertySelector = Nothing
            Me.cboDurationTiming.ReadOnlyCombo = False
            Me.cboDurationTiming.Size = New System.Drawing.Size(283, 24)
            Me.cboDurationTiming.SuggestBoxHeight = 200
            Me.cboDurationTiming.SuggestCharCount = 0
            Me.cboDurationTiming.SuggestListOrderRule = Nothing
            Me.cboDurationTiming.TabIndex = 11
            Me.cboDurationTiming.TextToSearch = Nothing
            Me.cboDurationTiming.Translatable = False
            Me.cboDurationTiming.ValueIsMandatory = False
            Me.cboDurationTiming.ValueIsNullable = False
            Me.cboDurationTiming.ValueIsNumeric = True
            Me.cboDurationTiming.ValueMember = "IdNo"
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
            Me.txtDose.TabIndex = 1
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
            Me.txtIdNo.Location = New System.Drawing.Point(114, 11)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.ReadOnly = True
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(102, 23)
            Me.txtIdNo.TabIndex = 300
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
            Me.txtDosageName.TabIndex = 302
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
            Me.txtDosageCode.Location = New System.Drawing.Point(399, 11)
            Me.txtDosageCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDosageCode.MaximumValue = Nothing
            Me.txtDosageCode.MinimumValue = Nothing
            Me.txtDosageCode.Name = "txtDosageCode"
            Me.txtDosageCode.OldValue = Nothing
            Me.txtDosageCode.OverrideMaxLength = 0
            Me.txtDosageCode.ReadOnly = True
            Me.txtDosageCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDosageCode.Size = New System.Drawing.Size(112, 23)
            Me.txtDosageCode.TabIndex = 301
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
            Me.txtDosageNameAra.TabIndex = 305
            Me.txtDosageNameAra.Translatable = False
            '
            'cboDosageUnit
            '
            Me.cboDosageUnit.AlwaysEditable = True
            Me.cboDosageUnit.BackColor = System.Drawing.Color.White
            Me.cboDosageUnit.BegFindValue = Nothing
            Me.cboDosageUnit.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDosageUnit, 3)
            Me.cboDosageUnit.CurrentSearchTerm = ""
            Me.cboDosageUnit.DataValue = Nothing
            Me.cboDosageUnit.DefaultValue = Nothing
            Me.cboDosageUnit.DisplayMember = "Name"
            Me.cboDosageUnit.Editable = True
            Me.cboDosageUnit.EditingMode = True
            Me.cboDosageUnit.EndFindValue = Nothing
            Me.cboDosageUnit.FieldDescription = Nothing
            Me.cboDosageUnit.FieldName = Nothing
            Me.cboDosageUnit.FilterRule = Nothing
            Me.cboDosageUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDosageUnit.FindEnabled = False
            Me.cboDosageUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDosageUnit.ForeColor = System.Drawing.Color.Black
            Me.cboDosageUnit.FormattingEnabled = True
            Me.cboDosageUnit.HideWhenNotEditingOrAdding = False
            Me.cboDosageUnit.IgnoreCase = False
            Me.cboDosageUnit.IntegralHeight = False
            Me.cboDosageUnit.LinkedLabel = Nothing
            Me.cboDosageUnit.Location = New System.Drawing.Point(114, 55)
            Me.cboDosageUnit.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDosageUnit.Name = "cboDosageUnit"
            Me.cboDosageUnit.OldValue = 0
            Me.cboDosageUnit.OriginalDataSource = Nothing
            Me.cboDosageUnit.OriginalList = Nothing
            Me.cboDosageUnit.OverrideDropDownStyleList = False
            Me.cboDosageUnit.PreviousSearchTerm = Nothing
            Me.cboDosageUnit.PropertySelector = Nothing
            Me.cboDosageUnit.ReadOnlyCombo = False
            Me.cboDosageUnit.Size = New System.Drawing.Size(397, 24)
            Me.cboDosageUnit.SuggestBoxHeight = 200
            Me.cboDosageUnit.SuggestCharCount = 0
            Me.cboDosageUnit.SuggestListOrderRule = Nothing
            Me.cboDosageUnit.TabIndex = 306
            Me.cboDosageUnit.TextToSearch = Nothing
            Me.cboDosageUnit.Translatable = False
            Me.cboDosageUnit.ValueIsMandatory = False
            Me.cboDosageUnit.ValueIsNullable = False
            Me.cboDosageUnit.ValueIsNumeric = True
            Me.cboDosageUnit.ValueMember = "IdNo"
            '
            'lblFileNo
            '
            Me.lblFileNo.AutoSize = True
            Me.lblFileNo.DisplayOnly = True
            Me.lblFileNo.EditingMode = False
            Me.lblFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFileNo.Location = New System.Drawing.Point(11, 340)
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
            Me.txtPatientName.Location = New System.Drawing.Point(114, 360)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(400, 23)
            Me.txtPatientName.TabIndex = 309
            Me.txtPatientName.Translatable = False
            '
            'lblAge
            '
            Me.lblAge.AutoSize = True
            Me.lblAge.DisplayOnly = True
            Me.lblAge.EditingMode = False
            Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAge.Location = New System.Drawing.Point(11, 380)
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
            Me.txtAge.Location = New System.Drawing.Point(11, 400)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(101, 23)
            Me.txtAge.TabIndex = 312
            Me.txtAge.Translatable = False
            '
            'lblPatientName
            '
            Me.lblPatientName.AutoSize = True
            Me.lblPatientName.DisplayOnly = True
            Me.lblPatientName.EditingMode = False
            Me.lblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPatientName.Location = New System.Drawing.Point(114, 340)
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
            Me.txtFileNo.Location = New System.Drawing.Point(11, 360)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumSize = New System.Drawing.Size(80, 2)
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(98, 23)
            Me.txtFileNo.TabIndex = 315
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
            Me.TableLayoutPanel1.Controls.Add(Me.cboAgeDmy, 1, 21)
            Me.TableLayoutPanel1.Controls.Add(Me.CtComboBox2, 1, 21)
            Me.TableLayoutPanel1.Controls.Add(Me.lblDirection, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CtComboBox1, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFrequency, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFrequencyTiming, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFrequency, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDirection, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 0, 19)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 1, 18)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 0, 21)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAge, 0, 20)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 1, 19)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFileNo, 0, 18)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDosageUnit, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageCode, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDosageName, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDose, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDurationTiming, 1, 17)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 1, 16)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 16)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDuration, 0, 17)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGender, 2, 20)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 17)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
            Me.TableLayoutPanel1.RowCount = 22
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
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(526, 441)
            Me.TableLayoutPanel1.TabIndex = 294
            '
            'lblDirection
            '
            Me.lblDirection.AutoSize = True
            Me.lblDirection.DisplayOnly = True
            Me.lblDirection.EditingMode = False
            Me.lblDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDirection.Location = New System.Drawing.Point(11, 256)
            Me.lblDirection.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDirection.Name = "lblDirection"
            Me.lblDirection.Size = New System.Drawing.Size(64, 17)
            Me.lblDirection.TabIndex = 321
            Me.lblDirection.Text = "Direction"
            Me.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDirection.Translatable = True
            '
            'CtComboBox1
            '
            Me.CtComboBox1.AlwaysEditable = True
            Me.CtComboBox1.BackColor = System.Drawing.Color.White
            Me.CtComboBox1.BegFindValue = Nothing
            Me.CtComboBox1.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.CtComboBox1, 2)
            Me.CtComboBox1.CurrentSearchTerm = ""
            Me.CtComboBox1.DataValue = Nothing
            Me.CtComboBox1.DefaultValue = Nothing
            Me.CtComboBox1.DisplayMember = "Name"
            Me.CtComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CtComboBox1.Editable = True
            Me.CtComboBox1.EditingMode = True
            Me.CtComboBox1.EndFindValue = Nothing
            Me.CtComboBox1.FieldDescription = Nothing
            Me.CtComboBox1.FieldName = Nothing
            Me.CtComboBox1.FilterRule = Nothing
            Me.CtComboBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtComboBox1.FindEnabled = False
            Me.CtComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CtComboBox1.ForeColor = System.Drawing.Color.Black
            Me.CtComboBox1.FormattingEnabled = True
            Me.CtComboBox1.HideWhenNotEditingOrAdding = False
            Me.CtComboBox1.IgnoreCase = False
            Me.CtComboBox1.IntegralHeight = False
            Me.CtComboBox1.LinkedLabel = Nothing
            Me.CtComboBox1.Location = New System.Drawing.Point(114, 230)
            Me.CtComboBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CtComboBox1.Name = "CtComboBox1"
            Me.CtComboBox1.OldValue = 0
            Me.CtComboBox1.OriginalDataSource = Nothing
            Me.CtComboBox1.OriginalList = Nothing
            Me.CtComboBox1.OverrideDropDownStyleList = False
            Me.CtComboBox1.PreviousSearchTerm = Nothing
            Me.CtComboBox1.PropertySelector = Nothing
            Me.CtComboBox1.ReadOnlyCombo = False
            Me.CtComboBox1.Size = New System.Drawing.Size(283, 24)
            Me.CtComboBox1.SuggestBoxHeight = 200
            Me.CtComboBox1.SuggestCharCount = 0
            Me.CtComboBox1.SuggestListOrderRule = Nothing
            Me.CtComboBox1.TabIndex = 320
            Me.CtComboBox1.TextToSearch = Nothing
            Me.CtComboBox1.Translatable = False
            Me.CtComboBox1.ValueIsMandatory = False
            Me.CtComboBox1.ValueIsNullable = False
            Me.CtComboBox1.ValueIsNumeric = True
            Me.CtComboBox1.ValueMember = "IdNo"
            '
            'txtFrequency
            '
            Me.txtFrequency.AlwaysEditable = True
            Me.txtFrequency.BackColor = System.Drawing.Color.White
            Me.txtFrequency.BegFindValue = Nothing
            Me.txtFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFrequency.ComputedValue = False
            Me.txtFrequency.CustomFormat = Nothing
            Me.txtFrequency.DataBoundControl = True
            Me.txtFrequency.Editable = True
            Me.txtFrequency.EditingMode = True
            Me.txtFrequency.EndFindValue = Nothing
            Me.txtFrequency.FieldDescription = Nothing
            Me.txtFrequency.FieldName = Nothing
            Me.txtFrequency.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFrequency.FindEnabled = False
            Me.txtFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFrequency.ForeColor = System.Drawing.Color.Black
            Me.txtFrequency.LinkedLabel = Nothing
            Me.txtFrequency.Location = New System.Drawing.Point(11, 230)
            Me.txtFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFrequency.MaximumValue = Nothing
            Me.txtFrequency.MinimumValue = Nothing
            Me.txtFrequency.Name = "txtFrequency"
            Me.txtFrequency.OldValue = Nothing
            Me.txtFrequency.OverrideMaxLength = 0
            Me.txtFrequency.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFrequency.Size = New System.Drawing.Size(98, 23)
            Me.txtFrequency.TabIndex = 319
            Me.txtFrequency.Translatable = False
            '
            'lblFrequencyTiming
            '
            Me.lblFrequencyTiming.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblFrequencyTiming, 2)
            Me.lblFrequencyTiming.DisplayOnly = True
            Me.lblFrequencyTiming.EditingMode = False
            Me.lblFrequencyTiming.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFrequencyTiming.Location = New System.Drawing.Point(114, 211)
            Me.lblFrequencyTiming.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFrequencyTiming.Name = "lblFrequencyTiming"
            Me.lblFrequencyTiming.Size = New System.Drawing.Size(121, 17)
            Me.lblFrequencyTiming.TabIndex = 318
            Me.lblFrequencyTiming.Text = "Frequency Timing"
            Me.lblFrequencyTiming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFrequencyTiming.Translatable = True
            '
            'lblFrequency
            '
            Me.lblFrequency.AutoSize = True
            Me.lblFrequency.DisplayOnly = True
            Me.lblFrequency.EditingMode = False
            Me.lblFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFrequency.Location = New System.Drawing.Point(11, 211)
            Me.lblFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFrequency.Name = "lblFrequency"
            Me.lblFrequency.Size = New System.Drawing.Size(75, 17)
            Me.lblFrequency.TabIndex = 317
            Me.lblFrequency.Text = "Frequency"
            Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFrequency.Translatable = True
            '
            'CtComboBox2
            '
            Me.CtComboBox2.AlwaysEditable = True
            Me.CtComboBox2.BackColor = System.Drawing.Color.White
            Me.CtComboBox2.BegFindValue = Nothing
            Me.CtComboBox2.ChangingSearchValueOnly = False
            Me.CtComboBox2.CurrentSearchTerm = ""
            Me.CtComboBox2.DataValue = Nothing
            Me.CtComboBox2.DefaultValue = Nothing
            Me.CtComboBox2.DisplayMember = "Name"
            Me.CtComboBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CtComboBox2.Editable = True
            Me.CtComboBox2.EditingMode = True
            Me.CtComboBox2.EndFindValue = Nothing
            Me.CtComboBox2.FieldDescription = Nothing
            Me.CtComboBox2.FieldName = Nothing
            Me.CtComboBox2.FilterRule = Nothing
            Me.CtComboBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtComboBox2.FindEnabled = False
            Me.CtComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CtComboBox2.ForeColor = System.Drawing.Color.Black
            Me.CtComboBox2.FormattingEnabled = True
            Me.CtComboBox2.HideWhenNotEditingOrAdding = False
            Me.CtComboBox2.IgnoreCase = False
            Me.CtComboBox2.IntegralHeight = False
            Me.CtComboBox2.LinkedLabel = Nothing
            Me.CtComboBox2.Location = New System.Drawing.Point(218, 400)
            Me.CtComboBox2.Margin = New System.Windows.Forms.Padding(1)
            Me.CtComboBox2.Name = "CtComboBox2"
            Me.CtComboBox2.OldValue = 0
            Me.CtComboBox2.OriginalDataSource = Nothing
            Me.CtComboBox2.OriginalList = Nothing
            Me.CtComboBox2.OverrideDropDownStyleList = False
            Me.CtComboBox2.PreviousSearchTerm = Nothing
            Me.CtComboBox2.PropertySelector = Nothing
            Me.CtComboBox2.ReadOnlyCombo = False
            Me.CtComboBox2.Size = New System.Drawing.Size(179, 24)
            Me.CtComboBox2.SuggestBoxHeight = 200
            Me.CtComboBox2.SuggestCharCount = 0
            Me.CtComboBox2.SuggestListOrderRule = Nothing
            Me.CtComboBox2.TabIndex = 322
            Me.CtComboBox2.TextToSearch = Nothing
            Me.CtComboBox2.Translatable = False
            Me.CtComboBox2.ValueIsMandatory = False
            Me.CtComboBox2.ValueIsNullable = False
            Me.CtComboBox2.ValueIsNumeric = True
            Me.CtComboBox2.ValueMember = "IdNo"
            '
            'cboDirection
            '
            Me.cboDirection.AlwaysEditable = True
            Me.cboDirection.BackColor = System.Drawing.Color.White
            Me.cboDirection.BegFindValue = Nothing
            Me.cboDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDirection, 4)
            Me.cboDirection.ComputedValue = False
            Me.cboDirection.CustomFormat = Nothing
            Me.cboDirection.DataBoundControl = True
            Me.cboDirection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDirection.EditingMode = True
            Me.cboDirection.EndFindValue = Nothing
            Me.cboDirection.FieldDescription = Nothing
            Me.cboDirection.FieldName = Nothing
            Me.cboDirection.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDirection.FindEnabled = False
            Me.cboDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDirection.ForeColor = System.Drawing.Color.Black
            Me.cboDirection.LinkedLabel = Nothing
            Me.cboDirection.Location = New System.Drawing.Point(11, 275)
            Me.cboDirection.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDirection.MaximumValue = Nothing
            Me.cboDirection.MinimumSize = New System.Drawing.Size(80, 2)
            Me.cboDirection.MinimumValue = Nothing
            Me.cboDirection.Name = "cboDirection"
            Me.cboDirection.OldValue = Nothing
            Me.cboDirection.OverrideMaxLength = 0
            Me.cboDirection.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.cboDirection.Size = New System.Drawing.Size(504, 23)
            Me.cboDirection.TabIndex = 316
            Me.cboDirection.Translatable = False
            '
            'cboAgeDmy
            '
            Me.cboAgeDmy.AlwaysEditable = True
            Me.cboAgeDmy.BackColor = System.Drawing.Color.White
            Me.cboAgeDmy.BegFindValue = Nothing
            Me.cboAgeDmy.ChangingSearchValueOnly = False
            Me.cboAgeDmy.CurrentSearchTerm = ""
            Me.cboAgeDmy.DataValue = Nothing
            Me.cboAgeDmy.DefaultValue = Nothing
            Me.cboAgeDmy.DisplayMember = "Name"
            Me.cboAgeDmy.Editable = True
            Me.cboAgeDmy.EditingMode = True
            Me.cboAgeDmy.EndFindValue = Nothing
            Me.cboAgeDmy.FieldDescription = Nothing
            Me.cboAgeDmy.FieldName = Nothing
            Me.cboAgeDmy.FilterRule = Nothing
            Me.cboAgeDmy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAgeDmy.FindEnabled = False
            Me.cboAgeDmy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAgeDmy.ForeColor = System.Drawing.Color.Black
            Me.cboAgeDmy.FormattingEnabled = True
            Me.cboAgeDmy.HideWhenNotEditingOrAdding = False
            Me.cboAgeDmy.IgnoreCase = False
            Me.cboAgeDmy.IntegralHeight = False
            Me.cboAgeDmy.LinkedLabel = Nothing
            Me.cboAgeDmy.Location = New System.Drawing.Point(114, 400)
            Me.cboAgeDmy.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAgeDmy.Name = "cboAgeDmy"
            Me.cboAgeDmy.OldValue = 0
            Me.cboAgeDmy.OriginalDataSource = Nothing
            Me.cboAgeDmy.OriginalList = Nothing
            Me.cboAgeDmy.OverrideDropDownStyleList = False
            Me.cboAgeDmy.PreviousSearchTerm = Nothing
            Me.cboAgeDmy.PropertySelector = Nothing
            Me.cboAgeDmy.ReadOnlyCombo = False
            Me.cboAgeDmy.Size = New System.Drawing.Size(102, 24)
            Me.cboAgeDmy.SuggestBoxHeight = 200
            Me.cboAgeDmy.SuggestCharCount = 0
            Me.cboAgeDmy.SuggestListOrderRule = Nothing
            Me.cboAgeDmy.TabIndex = 323
            Me.cboAgeDmy.TextToSearch = Nothing
            Me.cboAgeDmy.Translatable = False
            Me.cboAgeDmy.ValueIsMandatory = False
            Me.cboAgeDmy.ValueIsNullable = False
            Me.cboAgeDmy.ValueIsNumeric = True
            Me.cboAgeDmy.ValueMember = "IdNo"
            '
            'DosagePrinting
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(905, 551)
            Me.MinimumSize = New System.Drawing.Size(16, 100)
            Me.Name = "DosagePrinting"
            Me.Text = "Dosage Printing"
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
        Friend WithEvents cboDosageUnit As CtComboBox
        Friend WithEvents txtDosageNameAra As CTextBox
        Friend WithEvents CLabel12 As CLabel
        Friend WithEvents CLabel11 As CLabel
        Friend WithEvents txtDosageCode As CTextBox
        Friend WithEvents txtDosageName As CTextBox
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents txtDose As CTextBox
        Friend WithEvents cboDurationTiming As CtComboBox
        Friend WithEvents CLabel7 As CLabel
        Friend WithEvents CLabel8 As CLabel
        Friend WithEvents txtDuration As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CLabel10 As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents lblGender As CLabel
        Friend WithEvents lblFrequency As CLabel
        Friend WithEvents lblFrequencyTiming As CLabel
        Friend WithEvents txtFrequency As CTextBox
        Friend WithEvents lblDirection As CLabel
        Friend WithEvents CtComboBox1 As CtComboBox
        Friend WithEvents CtComboBox2 As CtComboBox
        Friend WithEvents cboDirection As CTextBox
        Friend WithEvents cboAgeDmy As CtComboBox
    End Class
End Namespace