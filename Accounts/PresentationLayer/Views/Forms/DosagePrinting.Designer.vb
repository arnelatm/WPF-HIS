Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DosagePrinting
        Inherits CFormEntry

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
        Me.txtDosage = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDosageUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboRoute = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDurationUnit = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboDirection = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDuration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboFrequencyTiming = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnPrintCheck
        '
        Me.btnPrintCheck.DesignerSelected = false
        Me.btnPrintCheck.ImageIndex = 0
        Me.btnPrintCheck.Location = New System.Drawing.Point(172, 264)
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
        Me.CLabel1.Location = New System.Drawing.Point(1, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(41, 17)
        Me.CLabel1.TabIndex = 0
        Me.CLabel1.Text = "Dose"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'txtDosage
        '
        Me.txtDosage.BackColor = System.Drawing.Color.White
        Me.txtDosage.BegFindValue = Nothing
        Me.txtDosage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosage.ComputedValue = false
        Me.txtDosage.CustomFormat = Nothing
        Me.txtDosage.DataBoundControl = true
        Me.txtDosage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDosage.EditingMode = true
        Me.txtDosage.EndFindValue = Nothing
        Me.txtDosage.FieldDescription = Nothing
        Me.txtDosage.FieldName = Nothing
        Me.txtDosage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDosage.FindEnabled = false
        Me.txtDosage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDosage.ForeColor = System.Drawing.Color.Black
        Me.txtDosage.LinkedLabel = Nothing
        Me.txtDosage.Location = New System.Drawing.Point(1, 20)
        Me.txtDosage.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDosage.MaximumValue = Nothing
        Me.txtDosage.MinimumValue = Nothing
        Me.txtDosage.Name = "txtDosage"
        Me.txtDosage.OldValue = Nothing
        Me.txtDosage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDosage.Size = New System.Drawing.Size(121, 23)
        Me.txtDosage.TabIndex = 1
        Me.txtDosage.Translatable = false
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(124, 1)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(33, 17)
        Me.CLabel2.TabIndex = 2
        Me.CLabel2.Text = "Unit"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'cboDosageUnit
        '
        Me.cboDosageUnit.BackColor = System.Drawing.Color.White
        Me.cboDosageUnit.BegFindValue = Nothing
        Me.cboDosageUnit.ChangingSearchValueOnly = false
        Me.cboDosageUnit.CurrentSearchTerm = ""
        Me.cboDosageUnit.DataValue = Nothing
        Me.cboDosageUnit.DefaultValue = Nothing
        Me.cboDosageUnit.DisplayMember = "Name"
        Me.cboDosageUnit.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.cboDosageUnit.Location = New System.Drawing.Point(124, 20)
        Me.cboDosageUnit.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDosageUnit.Name = "cboDosageUnit"
        Me.cboDosageUnit.OldValue = 0
        Me.cboDosageUnit.OriginalDataSource = Nothing
        Me.cboDosageUnit.OriginalList = Nothing
        Me.cboDosageUnit.OverrideDropDownStyleList = false
        Me.cboDosageUnit.PreviousSearchTerm = Nothing
        Me.cboDosageUnit.PropertySelector = Nothing
        Me.cboDosageUnit.ReadOnlyCombo = false
        Me.cboDosageUnit.Size = New System.Drawing.Size(304, 24)
        Me.cboDosageUnit.SuggestBoxHeight = 200
        Me.cboDosageUnit.SuggestListOrderRule = Nothing
        Me.cboDosageUnit.TabIndex = 3
        Me.cboDosageUnit.TextToSearch = Nothing
        Me.cboDosageUnit.Translatable = false
        Me.cboDosageUnit.ValueIsMandatory = false
        Me.cboDosageUnit.ValueIsNullable = false
        Me.cboDosageUnit.ValueIsNumeric = false
        Me.cboDosageUnit.ValueMember = "IdNo"
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 46)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(46, 17)
        Me.CLabel3.TabIndex = 4
        Me.CLabel3.Text = "Route"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'cboRoute
        '
        Me.cboRoute.BackColor = System.Drawing.Color.White
        Me.cboRoute.BegFindValue = Nothing
        Me.cboRoute.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboRoute, 2)
        Me.cboRoute.CurrentSearchTerm = ""
        Me.cboRoute.DataValue = Nothing
        Me.cboRoute.DefaultValue = Nothing
        Me.cboRoute.DisplayMember = "Name"
        Me.cboRoute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRoute.EditingMode = true
        Me.cboRoute.EndFindValue = Nothing
        Me.cboRoute.FieldDescription = Nothing
        Me.cboRoute.FieldName = Nothing
        Me.cboRoute.FilterRule = Nothing
        Me.cboRoute.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboRoute.FindEnabled = false
        Me.cboRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboRoute.ForeColor = System.Drawing.Color.Black
        Me.cboRoute.FormattingEnabled = true
        Me.cboRoute.HideWhenNotEditingOrAdding = false
        Me.cboRoute.IgnoreCase = false
        Me.cboRoute.IntegralHeight = false
        Me.cboRoute.LinkedLabel = Nothing
        Me.cboRoute.Location = New System.Drawing.Point(1, 65)
        Me.cboRoute.Margin = New System.Windows.Forms.Padding(1)
        Me.cboRoute.Name = "cboRoute"
        Me.cboRoute.OldValue = 0
        Me.cboRoute.OriginalDataSource = Nothing
        Me.cboRoute.OriginalList = Nothing
        Me.cboRoute.OverrideDropDownStyleList = false
        Me.cboRoute.PreviousSearchTerm = Nothing
        Me.cboRoute.PropertySelector = Nothing
        Me.cboRoute.ReadOnlyCombo = false
        Me.cboRoute.Size = New System.Drawing.Size(427, 24)
        Me.cboRoute.SuggestBoxHeight = 200
        Me.cboRoute.SuggestListOrderRule = Nothing
        Me.cboRoute.TabIndex = 5
        Me.cboRoute.TextToSearch = Nothing
        Me.cboRoute.Translatable = false
        Me.cboRoute.ValueIsMandatory = false
        Me.cboRoute.ValueIsNullable = false
        Me.cboRoute.ValueIsNumeric = false
        Me.cboRoute.ValueMember = "IdNo"
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = true
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel4.Location = New System.Drawing.Point(1, 156)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(75, 17)
        Me.CLabel4.TabIndex = 6
        Me.CLabel4.Text = "Frequency"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel4.Translatable = true
        '
        'cboDurationUnit
        '
        Me.cboDurationUnit.BackColor = System.Drawing.Color.White
        Me.cboDurationUnit.BegFindValue = Nothing
        Me.cboDurationUnit.ChangingSearchValueOnly = false
        Me.cboDurationUnit.CurrentSearchTerm = ""
        Me.cboDurationUnit.DataValue = Nothing
        Me.cboDurationUnit.DefaultValue = Nothing
        Me.cboDurationUnit.DisplayMember = "Name"
        Me.cboDurationUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDurationUnit.EditingMode = true
        Me.cboDurationUnit.EndFindValue = Nothing
        Me.cboDurationUnit.FieldDescription = Nothing
        Me.cboDurationUnit.FieldName = Nothing
        Me.cboDurationUnit.FilterRule = Nothing
        Me.cboDurationUnit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDurationUnit.FindEnabled = false
        Me.cboDurationUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDurationUnit.ForeColor = System.Drawing.Color.Black
        Me.cboDurationUnit.FormattingEnabled = true
        Me.cboDurationUnit.HideWhenNotEditingOrAdding = false
        Me.cboDurationUnit.IgnoreCase = false
        Me.cboDurationUnit.IntegralHeight = false
        Me.cboDurationUnit.LinkedLabel = Nothing
        Me.cboDurationUnit.Location = New System.Drawing.Point(124, 216)
        Me.cboDurationUnit.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDurationUnit.Name = "cboDurationUnit"
        Me.cboDurationUnit.OldValue = 0
        Me.cboDurationUnit.OriginalDataSource = Nothing
        Me.cboDurationUnit.OriginalList = Nothing
        Me.cboDurationUnit.OverrideDropDownStyleList = false
        Me.cboDurationUnit.PreviousSearchTerm = Nothing
        Me.cboDurationUnit.PropertySelector = Nothing
        Me.cboDurationUnit.ReadOnlyCombo = false
        Me.cboDurationUnit.Size = New System.Drawing.Size(304, 24)
        Me.cboDurationUnit.SuggestBoxHeight = 200
        Me.cboDurationUnit.SuggestListOrderRule = Nothing
        Me.cboDurationUnit.TabIndex = 11
        Me.cboDurationUnit.TextToSearch = Nothing
        Me.cboDurationUnit.Translatable = false
        Me.cboDurationUnit.ValueIsMandatory = false
        Me.cboDurationUnit.ValueIsNullable = false
        Me.cboDurationUnit.ValueIsNumeric = false
        Me.cboDurationUnit.ValueMember = "IdNo"
        '
        'CLabel7
        '
        Me.CLabel7.AutoSize = true
        Me.CLabel7.DisplayOnly = true
        Me.CLabel7.EditingMode = false
        Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel7.Location = New System.Drawing.Point(124, 198)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.Size = New System.Drawing.Size(91, 16)
        Me.CLabel7.TabIndex = 12
        Me.CLabel7.Text = "Duration Unit"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel7.Translatable = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboDirection, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboRoute, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDosageUnit, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDosage, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDurationUnit, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDuration, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cboFrequency, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cboFrequencyTiming, 1, 9)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(429, 246)
        Me.TableLayoutPanel1.TabIndex = 294
        '
        'cboDirection
        '
        Me.cboDirection.BackColor = System.Drawing.Color.White
        Me.cboDirection.BegFindValue = Nothing
        Me.cboDirection.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDirection, 2)
        Me.cboDirection.CurrentSearchTerm = ""
        Me.cboDirection.DataValue = Nothing
        Me.cboDirection.DefaultValue = Nothing
        Me.cboDirection.DisplayMember = "Name"
        Me.cboDirection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDirection.EditingMode = true
        Me.cboDirection.EndFindValue = Nothing
        Me.cboDirection.FieldDescription = Nothing
        Me.cboDirection.FieldName = Nothing
        Me.cboDirection.FilterRule = Nothing
        Me.cboDirection.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDirection.FindEnabled = false
        Me.cboDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDirection.ForeColor = System.Drawing.Color.Black
        Me.cboDirection.FormattingEnabled = true
        Me.cboDirection.HideWhenNotEditingOrAdding = false
        Me.cboDirection.IgnoreCase = false
        Me.cboDirection.IntegralHeight = false
        Me.cboDirection.LinkedLabel = Nothing
        Me.cboDirection.Location = New System.Drawing.Point(1, 130)
        Me.cboDirection.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.OldValue = 0
        Me.cboDirection.OriginalDataSource = Nothing
        Me.cboDirection.OriginalList = Nothing
        Me.cboDirection.OverrideDropDownStyleList = false
        Me.cboDirection.PreviousSearchTerm = Nothing
        Me.cboDirection.PropertySelector = Nothing
        Me.cboDirection.ReadOnlyCombo = false
        Me.cboDirection.Size = New System.Drawing.Size(427, 24)
        Me.cboDirection.SuggestBoxHeight = 200
        Me.cboDirection.SuggestListOrderRule = Nothing
        Me.cboDirection.TabIndex = 298
        Me.cboDirection.TextToSearch = Nothing
        Me.cboDirection.Translatable = false
        Me.cboDirection.ValueIsMandatory = false
        Me.cboDirection.ValueIsNullable = false
        Me.cboDirection.ValueIsNumeric = false
        Me.cboDirection.ValueMember = "IdNo"
        '
        'CLabel6
        '
        Me.CLabel6.AutoSize = true
        Me.CLabel6.DisplayOnly = true
        Me.CLabel6.EditingMode = false
        Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel6.Location = New System.Drawing.Point(1, 91)
        Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel6.Name = "CLabel6"
        Me.CLabel6.Size = New System.Drawing.Size(64, 17)
        Me.CLabel6.TabIndex = 10
        Me.CLabel6.Text = "Direction"
        Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel6.Translatable = true
        '
        'CLabel8
        '
        Me.CLabel8.AutoSize = true
        Me.CLabel8.DisplayOnly = true
        Me.CLabel8.EditingMode = false
        Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel8.Location = New System.Drawing.Point(1, 198)
        Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel8.Name = "CLabel8"
        Me.CLabel8.Size = New System.Drawing.Size(62, 16)
        Me.CLabel8.TabIndex = 294
        Me.CLabel8.Text = "Duration"
        Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel8.Translatable = true
        '
        'txtDuration
        '
        Me.txtDuration.BackColor = System.Drawing.Color.White
        Me.txtDuration.BegFindValue = Nothing
        Me.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDuration.ComputedValue = false
        Me.txtDuration.CustomFormat = Nothing
        Me.txtDuration.DataBoundControl = true
        Me.txtDuration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDuration.EditingMode = true
        Me.txtDuration.EndFindValue = Nothing
        Me.txtDuration.FieldDescription = Nothing
        Me.txtDuration.FieldName = Nothing
        Me.txtDuration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDuration.FindEnabled = false
        Me.txtDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDuration.ForeColor = System.Drawing.Color.Black
        Me.txtDuration.LinkedLabel = Nothing
        Me.txtDuration.Location = New System.Drawing.Point(1, 216)
        Me.txtDuration.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDuration.MaximumValue = Nothing
        Me.txtDuration.MinimumValue = Nothing
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.OldValue = Nothing
        Me.txtDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDuration.Size = New System.Drawing.Size(121, 23)
        Me.txtDuration.TabIndex = 293
        Me.txtDuration.Translatable = false
        '
        'cboFrequency
        '
        Me.cboFrequency.BackColor = System.Drawing.Color.White
        Me.cboFrequency.BegFindValue = Nothing
        Me.cboFrequency.ChangingSearchValueOnly = false
        Me.cboFrequency.CurrentSearchTerm = ""
        Me.cboFrequency.DataValue = Nothing
        Me.cboFrequency.DefaultValue = Nothing
        Me.cboFrequency.DisplayMember = "Name"
        Me.cboFrequency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFrequency.EditingMode = true
        Me.cboFrequency.EndFindValue = Nothing
        Me.cboFrequency.FieldDescription = Nothing
        Me.cboFrequency.FieldName = Nothing
        Me.cboFrequency.FilterRule = Nothing
        Me.cboFrequency.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboFrequency.FindEnabled = false
        Me.cboFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboFrequency.ForeColor = System.Drawing.Color.Black
        Me.cboFrequency.FormattingEnabled = true
        Me.cboFrequency.HideWhenNotEditingOrAdding = false
        Me.cboFrequency.IgnoreCase = false
        Me.cboFrequency.IntegralHeight = false
        Me.cboFrequency.LinkedLabel = Nothing
        Me.cboFrequency.Location = New System.Drawing.Point(1, 176)
        Me.cboFrequency.Margin = New System.Windows.Forms.Padding(1)
        Me.cboFrequency.Name = "cboFrequency"
        Me.cboFrequency.OldValue = 0
        Me.cboFrequency.OriginalDataSource = Nothing
        Me.cboFrequency.OriginalList = Nothing
        Me.cboFrequency.OverrideDropDownStyleList = false
        Me.cboFrequency.PreviousSearchTerm = Nothing
        Me.cboFrequency.PropertySelector = Nothing
        Me.cboFrequency.ReadOnlyCombo = false
        Me.cboFrequency.Size = New System.Drawing.Size(121, 24)
        Me.cboFrequency.SuggestBoxHeight = 200
        Me.cboFrequency.SuggestListOrderRule = Nothing
        Me.cboFrequency.TabIndex = 295
        Me.cboFrequency.TextToSearch = Nothing
        Me.cboFrequency.Translatable = false
        Me.cboFrequency.ValueIsMandatory = false
        Me.cboFrequency.ValueIsNullable = false
        Me.cboFrequency.ValueIsNumeric = false
        Me.cboFrequency.ValueMember = "IdNo"
        '
        'CLabel9
        '
        Me.CLabel9.AutoSize = true
        Me.CLabel9.DisplayOnly = true
        Me.CLabel9.EditingMode = false
        Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel9.Location = New System.Drawing.Point(124, 156)
        Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel9.Name = "CLabel9"
        Me.CLabel9.Size = New System.Drawing.Size(121, 17)
        Me.CLabel9.TabIndex = 296
        Me.CLabel9.Text = "Frequency Timing"
        Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel9.Translatable = true
        '
        'cboFrequencyTiming
        '
        Me.cboFrequencyTiming.BackColor = System.Drawing.Color.White
        Me.cboFrequencyTiming.BegFindValue = Nothing
        Me.cboFrequencyTiming.ChangingSearchValueOnly = false
        Me.cboFrequencyTiming.CurrentSearchTerm = ""
        Me.cboFrequencyTiming.DataValue = Nothing
        Me.cboFrequencyTiming.DefaultValue = Nothing
        Me.cboFrequencyTiming.DisplayMember = "Name"
        Me.cboFrequencyTiming.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFrequencyTiming.EditingMode = true
        Me.cboFrequencyTiming.EndFindValue = Nothing
        Me.cboFrequencyTiming.FieldDescription = Nothing
        Me.cboFrequencyTiming.FieldName = Nothing
        Me.cboFrequencyTiming.FilterRule = Nothing
        Me.cboFrequencyTiming.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboFrequencyTiming.FindEnabled = false
        Me.cboFrequencyTiming.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboFrequencyTiming.ForeColor = System.Drawing.Color.Black
        Me.cboFrequencyTiming.FormattingEnabled = true
        Me.cboFrequencyTiming.HideWhenNotEditingOrAdding = false
        Me.cboFrequencyTiming.IgnoreCase = false
        Me.cboFrequencyTiming.IntegralHeight = false
        Me.cboFrequencyTiming.LinkedLabel = Nothing
        Me.cboFrequencyTiming.Location = New System.Drawing.Point(124, 176)
        Me.cboFrequencyTiming.Margin = New System.Windows.Forms.Padding(1)
        Me.cboFrequencyTiming.Name = "cboFrequencyTiming"
        Me.cboFrequencyTiming.OldValue = 0
        Me.cboFrequencyTiming.OriginalDataSource = Nothing
        Me.cboFrequencyTiming.OriginalList = Nothing
        Me.cboFrequencyTiming.OverrideDropDownStyleList = false
        Me.cboFrequencyTiming.PreviousSearchTerm = Nothing
        Me.cboFrequencyTiming.PropertySelector = Nothing
        Me.cboFrequencyTiming.ReadOnlyCombo = false
        Me.cboFrequencyTiming.Size = New System.Drawing.Size(304, 24)
        Me.cboFrequencyTiming.SuggestBoxHeight = 200
        Me.cboFrequencyTiming.SuggestListOrderRule = Nothing
        Me.cboFrequencyTiming.TabIndex = 297
        Me.cboFrequencyTiming.TextToSearch = Nothing
        Me.cboFrequencyTiming.Translatable = false
        Me.cboFrequencyTiming.ValueIsMandatory = false
        Me.cboFrequencyTiming.ValueIsNullable = false
        Me.cboFrequencyTiming.ValueIsNumeric = false
        Me.cboFrequencyTiming.ValueMember = "IdNo"
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'bsDjOiItems
        '
        Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
        '
        'DosagePrinting
        '
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(455, 302)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnPrintCheck)
        Me.MinimumSize = New System.Drawing.Size(16, 100)
        Me.Name = "DosagePrinting"
        Me.Text = "Dosage Printing"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents bsDjOiItems As Windows.Forms.BindingSource
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
        Friend WithEvents txtDosage As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents cboDosageUnit As CaComboBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboRoute As CaComboBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents cboDurationUnit As CaComboBox
        Friend WithEvents CLabel7 As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CLabel6 As CLabel
        Friend WithEvents CLabel8 As CLabel
        Friend WithEvents txtDuration As CTextBox
        Friend WithEvents cboFrequency As CaComboBox
        Friend WithEvents CLabel9 As CLabel
        Friend WithEvents cboFrequencyTiming As CaComboBox
        Friend WithEvents cboDirection As CaComboBox
    End Class
End Namespace