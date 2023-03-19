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
        Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDose = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboDosageUnit = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.txtDosageNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDosageCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDosageName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboDurationTiming = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDuration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPrintCheck)
        Me.SplitContainer1.Size = New System.Drawing.Size(934, 480)
        Me.SplitContainer1.SplitterDistance = 355
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(355, 480)
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
        'btnPrintCheck
        '
        Me.btnPrintCheck.DesignerSelected = false
        Me.btnPrintCheck.ImageIndex = 0
        Me.btnPrintCheck.Location = New System.Drawing.Point(211, 321)
        Me.btnPrintCheck.Name = "btnPrintCheck"
        Me.btnPrintCheck.OriginalImageName = Nothing
        Me.btnPrintCheck.SecurityKey = ""
        Me.btnPrintCheck.Size = New System.Drawing.Size(116, 31)
        Me.btnPrintCheck.TabIndex = 291
        Me.btnPrintCheck.TabStop = false
        Me.btnPrintCheck.Text = "Print Dosage"
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(11, 36)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(67, 17)
        Me.CLabel1.TabIndex = 0
        Me.CLabel1.Text = "Dose Qty"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'txtDose
        '
        Me.txtDose.AlwaysEditable = true
        Me.txtDose.BackColor = System.Drawing.Color.White
        Me.txtDose.BegFindValue = Nothing
        Me.txtDose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDose.ComputedValue = false
        Me.txtDose.CustomFormat = Nothing
        Me.txtDose.DataBoundControl = true
        Me.txtDose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDose.EditingMode = true
        Me.txtDose.EndFindValue = Nothing
        Me.txtDose.FieldDescription = Nothing
        Me.txtDose.FieldName = Nothing
        Me.txtDose.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDose.FindEnabled = false
        Me.txtDose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDose.ForeColor = System.Drawing.Color.Black
        Me.txtDose.LinkedLabel = Nothing
        Me.txtDose.Location = New System.Drawing.Point(11, 55)
        Me.txtDose.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDose.MaximumValue = Nothing
        Me.txtDose.MinimumSize = New System.Drawing.Size(80, 2)
        Me.txtDose.MinimumValue = Nothing
        Me.txtDose.Name = "txtDose"
        Me.txtDose.OldValue = Nothing
        Me.txtDose.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDose.Size = New System.Drawing.Size(80, 23)
        Me.txtDose.TabIndex = 1
        Me.txtDose.Translatable = false
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(93, 36)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(86, 17)
        Me.CLabel2.TabIndex = 2
        Me.CLabel2.Text = "Dosage Unit"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cboDosageUnit, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDosageNameAra, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDosageCode, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDosageName, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDose, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDurationTiming, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDuration, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(569, 308)
        Me.TableLayoutPanel1.TabIndex = 294
        '
        'cboDosageUnit
        '
        Me.cboDosageUnit.AlwaysEditable = true
        Me.cboDosageUnit.BackColor = System.Drawing.Color.White
        Me.cboDosageUnit.BegFindValue = Nothing
        Me.cboDosageUnit.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDosageUnit, 3)
        Me.cboDosageUnit.CurrentSearchTerm = ""
        Me.cboDosageUnit.DataValue = Nothing
        Me.cboDosageUnit.DefaultValue = Nothing
        Me.cboDosageUnit.DisplayMember = "Name"
        Me.cboDosageUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDosageUnit.Editable = true
        Me.cboDosageUnit.EditingMode = true
        Me.cboDosageUnit.EndFindValue = Nothing
        Me.cboDosageUnit.FieldDescription = Nothing
        Me.cboDosageUnit.FieldName = Nothing
        Me.cboDosageUnit.FilterRule = Nothing
        Me.cboDosageUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDosageUnit.FindEnabled = false
        Me.cboDosageUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDosageUnit.ForeColor = System.Drawing.Color.Black
        Me.cboDosageUnit.FormattingEnabled = true
        Me.cboDosageUnit.HideWhenNotEditingOrAdding = false
        Me.cboDosageUnit.IgnoreCase = false
        Me.cboDosageUnit.IntegralHeight = false
        Me.cboDosageUnit.LinkedLabel = Nothing
        Me.cboDosageUnit.Location = New System.Drawing.Point(93, 55)
        Me.cboDosageUnit.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDosageUnit.Name = "cboDosageUnit"
        Me.cboDosageUnit.OldValue = 0
        Me.cboDosageUnit.OriginalDataSource = Nothing
        Me.cboDosageUnit.OriginalList = Nothing
        Me.cboDosageUnit.OverrideDropDownStyleList = false
        Me.cboDosageUnit.PreviousSearchTerm = Nothing
        Me.cboDosageUnit.PropertySelector = Nothing
        Me.cboDosageUnit.ReadOnlyCombo = false
        Me.cboDosageUnit.Size = New System.Drawing.Size(465, 24)
        Me.cboDosageUnit.SuggestBoxHeight = 200
        Me.cboDosageUnit.SuggestListOrderRule = Nothing
        Me.cboDosageUnit.TabIndex = 306
        Me.cboDosageUnit.TextToSearch = Nothing
        Me.cboDosageUnit.Translatable = false
        Me.cboDosageUnit.ValueIsMandatory = false
        Me.cboDosageUnit.ValueIsNullable = false
        Me.cboDosageUnit.ValueIsNumeric = true
        Me.cboDosageUnit.ValueMember = "IdNo"
        '
        'txtDosageNameAra
        '
        Me.txtDosageNameAra.BackColor = System.Drawing.Color.White
        Me.txtDosageNameAra.BegFindValue = Nothing
        Me.txtDosageNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageNameAra, 4)
        Me.txtDosageNameAra.ComputedValue = false
        Me.txtDosageNameAra.CustomFormat = Nothing
        Me.txtDosageNameAra.DataBoundControl = true
        Me.txtDosageNameAra.DisplayOnly = true
        Me.txtDosageNameAra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDosageNameAra.EditingMode = true
        Me.txtDosageNameAra.EndFindValue = Nothing
        Me.txtDosageNameAra.FieldDescription = Nothing
        Me.txtDosageNameAra.FieldName = Nothing
        Me.txtDosageNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDosageNameAra.FindEnabled = false
        Me.txtDosageNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDosageNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDosageNameAra.LinkedLabel = Nothing
        Me.txtDosageNameAra.Location = New System.Drawing.Point(11, 168)
        Me.txtDosageNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDosageNameAra.MaximumValue = Nothing
        Me.txtDosageNameAra.MinimumValue = Nothing
        Me.txtDosageNameAra.Multiline = true
        Me.txtDosageNameAra.Name = "txtDosageNameAra"
        Me.txtDosageNameAra.OldValue = Nothing
        Me.txtDosageNameAra.ReadOnly = true
        Me.txtDosageNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDosageNameAra.Size = New System.Drawing.Size(547, 47)
        Me.txtDosageNameAra.TabIndex = 305
        Me.txtDosageNameAra.Translatable = false
        '
        'CLabel12
        '
        Me.CLabel12.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel12, 2)
        Me.CLabel12.DisplayOnly = true
        Me.CLabel12.EditingMode = false
        Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel12.Location = New System.Drawing.Point(11, 81)
        Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel12.Name = "CLabel12"
        Me.CLabel12.Size = New System.Drawing.Size(98, 17)
        Me.CLabel12.TabIndex = 304
        Me.CLabel12.Text = "Dosage Name"
        Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel12.Translatable = true
        '
        'CLabel11
        '
        Me.CLabel11.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
        Me.CLabel11.DisplayOnly = true
        Me.CLabel11.EditingMode = false
        Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel11.Location = New System.Drawing.Point(11, 149)
        Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel11.Name = "CLabel11"
        Me.CLabel11.Size = New System.Drawing.Size(142, 17)
        Me.CLabel11.TabIndex = 303
        Me.CLabel11.Text = "Dosage Name Arabic"
        Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CLabel11.Translatable = true
        '
        'txtDosageCode
        '
        Me.txtDosageCode.BackColor = System.Drawing.Color.White
        Me.txtDosageCode.BegFindValue = Nothing
        Me.txtDosageCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosageCode.ComputedValue = false
        Me.txtDosageCode.CustomFormat = Nothing
        Me.txtDosageCode.DataBoundControl = true
        Me.txtDosageCode.DisplayOnly = true
        Me.txtDosageCode.Editable = true
        Me.txtDosageCode.EditingMode = true
        Me.txtDosageCode.EndFindValue = Nothing
        Me.txtDosageCode.FieldDescription = Nothing
        Me.txtDosageCode.FieldName = Nothing
        Me.txtDosageCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDosageCode.FindEnabled = false
        Me.txtDosageCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDosageCode.ForeColor = System.Drawing.Color.Black
        Me.txtDosageCode.LinkedLabel = Nothing
        Me.txtDosageCode.Location = New System.Drawing.Point(274, 11)
        Me.txtDosageCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDosageCode.MaximumValue = Nothing
        Me.txtDosageCode.MinimumValue = Nothing
        Me.txtDosageCode.Name = "txtDosageCode"
        Me.txtDosageCode.OldValue = Nothing
        Me.txtDosageCode.ReadOnly = true
        Me.txtDosageCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDosageCode.Size = New System.Drawing.Size(81, 23)
        Me.txtDosageCode.TabIndex = 301
        Me.txtDosageCode.Translatable = false
        '
        'txtDosageName
        '
        Me.txtDosageName.BackColor = System.Drawing.Color.White
        Me.txtDosageName.BegFindValue = Nothing
        Me.txtDosageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDosageName, 4)
        Me.txtDosageName.ComputedValue = false
        Me.txtDosageName.CustomFormat = Nothing
        Me.txtDosageName.DataBoundControl = true
        Me.txtDosageName.DisplayOnly = true
        Me.txtDosageName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDosageName.EditingMode = true
        Me.txtDosageName.EndFindValue = Nothing
        Me.txtDosageName.FieldDescription = Nothing
        Me.txtDosageName.FieldName = Nothing
        Me.txtDosageName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDosageName.FindEnabled = false
        Me.txtDosageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDosageName.ForeColor = System.Drawing.Color.Black
        Me.txtDosageName.LinkedLabel = Nothing
        Me.txtDosageName.Location = New System.Drawing.Point(11, 100)
        Me.txtDosageName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDosageName.MaximumValue = Nothing
        Me.txtDosageName.MinimumValue = Nothing
        Me.txtDosageName.Multiline = true
        Me.txtDosageName.Name = "txtDosageName"
        Me.txtDosageName.OldValue = Nothing
        Me.txtDosageName.ReadOnly = true
        Me.txtDosageName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDosageName.Size = New System.Drawing.Size(547, 47)
        Me.txtDosageName.TabIndex = 302
        Me.txtDosageName.Translatable = false
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BegFindValue = Nothing
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.DisplayOnly = true
        Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdNo.Editable = true
        Me.txtIdNo.EditingMode = true
        Me.txtIdNo.EndFindValue = Nothing
        Me.txtIdNo.FieldDescription = Nothing
        Me.txtIdNo.FieldName = Nothing
        Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtIdNo.FindEnabled = false
        Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Nothing
        Me.txtIdNo.Location = New System.Drawing.Point(93, 11)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.ReadOnly = true
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(86, 23)
        Me.txtIdNo.TabIndex = 300
        Me.txtIdNo.Translatable = false
        '
        'cboDurationTiming
        '
        Me.cboDurationTiming.AlwaysEditable = true
        Me.cboDurationTiming.BackColor = System.Drawing.Color.White
        Me.cboDurationTiming.BegFindValue = Nothing
        Me.cboDurationTiming.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDurationTiming, 2)
        Me.cboDurationTiming.CurrentSearchTerm = ""
        Me.cboDurationTiming.DataValue = Nothing
        Me.cboDurationTiming.DefaultValue = Nothing
        Me.cboDurationTiming.DisplayMember = "Name"
        Me.cboDurationTiming.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDurationTiming.Editable = true
        Me.cboDurationTiming.EditingMode = true
        Me.cboDurationTiming.EndFindValue = Nothing
        Me.cboDurationTiming.FieldDescription = Nothing
        Me.cboDurationTiming.FieldName = Nothing
        Me.cboDurationTiming.FilterRule = Nothing
        Me.cboDurationTiming.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDurationTiming.FindEnabled = false
        Me.cboDurationTiming.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDurationTiming.ForeColor = System.Drawing.Color.Black
        Me.cboDurationTiming.FormattingEnabled = true
        Me.cboDurationTiming.HideWhenNotEditingOrAdding = false
        Me.cboDurationTiming.IgnoreCase = false
        Me.cboDurationTiming.IntegralHeight = false
        Me.cboDurationTiming.LinkedLabel = Nothing
        Me.cboDurationTiming.Location = New System.Drawing.Point(181, 236)
        Me.cboDurationTiming.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDurationTiming.Name = "cboDurationTiming"
        Me.cboDurationTiming.OldValue = 0
        Me.cboDurationTiming.OriginalDataSource = Nothing
        Me.cboDurationTiming.OriginalList = Nothing
        Me.cboDurationTiming.OverrideDropDownStyleList = false
        Me.cboDurationTiming.PreviousSearchTerm = Nothing
        Me.cboDurationTiming.PropertySelector = Nothing
        Me.cboDurationTiming.ReadOnlyCombo = false
        Me.cboDurationTiming.Size = New System.Drawing.Size(377, 24)
        Me.cboDurationTiming.SuggestBoxHeight = 200
        Me.cboDurationTiming.SuggestListOrderRule = Nothing
        Me.cboDurationTiming.TabIndex = 11
        Me.cboDurationTiming.TextToSearch = Nothing
        Me.cboDurationTiming.Translatable = false
        Me.cboDurationTiming.ValueIsMandatory = false
        Me.cboDurationTiming.ValueIsNullable = false
        Me.cboDurationTiming.ValueIsNumeric = true
        Me.cboDurationTiming.ValueMember = "IdNo"
        '
        'CLabel7
        '
        Me.CLabel7.AutoSize = true
        Me.CLabel7.DisplayOnly = true
        Me.CLabel7.EditingMode = false
        Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel7.Location = New System.Drawing.Point(181, 217)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.Size = New System.Drawing.Size(91, 17)
        Me.CLabel7.TabIndex = 12
        Me.CLabel7.Text = "Duration Unit"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel7.Translatable = true
        '
        'CLabel8
        '
        Me.CLabel8.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel8, 2)
        Me.CLabel8.DisplayOnly = true
        Me.CLabel8.EditingMode = false
        Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel8.Location = New System.Drawing.Point(11, 217)
        Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel8.Name = "CLabel8"
        Me.CLabel8.Size = New System.Drawing.Size(62, 17)
        Me.CLabel8.TabIndex = 294
        Me.CLabel8.Text = "Duration"
        Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel8.Translatable = true
        '
        'txtDuration
        '
        Me.txtDuration.AlwaysEditable = true
        Me.txtDuration.BackColor = System.Drawing.Color.White
        Me.txtDuration.BegFindValue = Nothing
        Me.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDuration, 2)
        Me.txtDuration.ComputedValue = false
        Me.txtDuration.CustomFormat = Nothing
        Me.txtDuration.DataBoundControl = true
        Me.txtDuration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDuration.Editable = true
        Me.txtDuration.EditingMode = true
        Me.txtDuration.EndFindValue = Nothing
        Me.txtDuration.FieldDescription = Nothing
        Me.txtDuration.FieldName = Nothing
        Me.txtDuration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDuration.FindEnabled = false
        Me.txtDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDuration.ForeColor = System.Drawing.Color.Black
        Me.txtDuration.LinkedLabel = Nothing
        Me.txtDuration.Location = New System.Drawing.Point(11, 236)
        Me.txtDuration.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDuration.MaximumValue = Nothing
        Me.txtDuration.MinimumValue = Nothing
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.OldValue = Nothing
        Me.txtDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDuration.Size = New System.Drawing.Size(168, 23)
        Me.txtDuration.TabIndex = 293
        Me.txtDuration.Translatable = false
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = true
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.Location = New System.Drawing.Point(11, 11)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(47, 17)
        Me.CLabel5.TabIndex = 299
        Me.CLabel5.Text = "ID No."
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel5.Translatable = true
        '
        'CLabel10
        '
        Me.CLabel10.AutoSize = true
        Me.CLabel10.DisplayOnly = true
        Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel10.EditingMode = false
        Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel10.Location = New System.Drawing.Point(181, 11)
        Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel10.Name = "CLabel10"
        Me.CLabel10.Size = New System.Drawing.Size(91, 23)
        Me.CLabel10.TabIndex = 301
        Me.CLabel10.Text = "Code "
        Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel10.Translatable = true
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = false
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(11, 123)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Multiline = true
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(505, 47)
        Me.CTextBox1.TabIndex = 305
        Me.CTextBox1.Translatable = false
        '
        'DosagePrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(934, 533)
        Me.MinimumSize = New System.Drawing.Size(16, 100)
        Me.Name = "DosagePrinting"
        Me.Text = "Dosage Printing"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents btnPrintCheck As CButton
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtDose As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents txtDosageCode As CTextBox
        Friend WithEvents CLabel10 As CLabel
        Friend WithEvents txtDosageName As CTextBox
        Friend WithEvents CLabel11 As CLabel
        Friend WithEvents CLabel12 As CLabel
        Friend WithEvents txtDosageNameAra As CTextBox
        Friend WithEvents CTextBox1 As CTextBox
        Friend WithEvents cboDurationTiming As CtComboBox
        Friend WithEvents CLabel7 As CLabel
        Friend WithEvents CLabel8 As CLabel
        Friend WithEvents txtDuration As CTextBox
        Friend WithEvents cboDosageUnit As CtComboBox
    End Class
End Namespace