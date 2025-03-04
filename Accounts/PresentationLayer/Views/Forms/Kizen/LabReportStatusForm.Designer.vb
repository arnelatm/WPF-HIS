Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LabReportStatusForm

        Inherits AATM.PresentationLayer.Forms.CFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabReportStatusForm))
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel17 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationality = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel16 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel15 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRequestedBy = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientNameMRN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSampleNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel13 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpCollectedDateTime = New AATM.Libraries.CBaseControlsLibrary.CDgvDtpEditingControl()
            Me.dtpProcessedDateTime = New AATM.Libraries.CBaseControlsLibrary.CDgvDtpEditingControl()
            Me.dtpValidatedDateTime = New AATM.Libraries.CBaseControlsLibrary.CDgvDtpEditingControl()
            Me.txtCollectedBy = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtProcessedBy = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtValidatedBy = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMRN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel14 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGender = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnUpdateNameFromFile = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblRequestedBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCompleted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.txtRequestedDateTime = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnSaveStatus = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'imgList
            '
            Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgList.TransparentColor = System.Drawing.Color.Transparent
            Me.imgList.Images.SetKeyName(0, "btnPrint.png")
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.AutoSize = True
            Me.CFlowLayout2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1311, 368)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvoiceNo, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel17, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNationality, 3, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel16, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel15, 3, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtRequestedBy, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientNameMRN, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtSampleNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel13, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpCollectedDateTime, 5, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpProcessedDateTime, 5, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpValidatedDateTime, 5, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtCollectedBy, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtProcessedBy, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtValidatedBy, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMRN, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 4, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel12, 4, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel14, 4, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 3, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGender, 5, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 5, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.btnUpdateNameFromFile, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblRequestedBy, 4, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.chkCompleted, 4, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtRequestedDateTime, 5, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.btnSaveStatus, 3, 11)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 12
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
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1244, 337)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
            Me.txtInvoiceNo.BegFindValue = Nothing
            Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInvoiceNo.ComputedValue = False
            Me.txtInvoiceNo.CustomFormat = Nothing
            Me.txtInvoiceNo.DataBoundControl = True
            Me.txtInvoiceNo.DisplayOnly = True
            Me.txtInvoiceNo.EditingMode = True
            Me.txtInvoiceNo.EndFindValue = Nothing
            Me.txtInvoiceNo.FieldDescription = Nothing
            Me.txtInvoiceNo.FieldName = Nothing
            Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvoiceNo.FindEnabled = False
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
            Me.txtInvoiceNo.LinkedLabel = Nothing
            Me.txtInvoiceNo.Location = New System.Drawing.Point(186, 251)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.OverrideMaxLength = 0
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(129, 26)
            Me.txtInvoiceNo.TabIndex = 52
            Me.txtInvoiceNo.Translatable = False
            '
            'CLabel17
            '
            Me.CLabel17.AutoSize = True
            Me.CLabel17.BackColor = System.Drawing.Color.Transparent
            Me.CLabel17.DisplayOnly = True
            Me.CLabel17.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel17.EditingMode = False
            Me.CLabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel17.Location = New System.Drawing.Point(1, 251)
            Me.CLabel17.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel17.Name = "CLabel17"
            Me.CLabel17.Size = New System.Drawing.Size(130, 23)
            Me.CLabel17.TabIndex = 51
            Me.CLabel17.Text = "Invoice Number:"
            Me.CLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel17.Translatable = True
            '
            'txtNationality
            '
            Me.txtNationality.BackColor = System.Drawing.Color.White
            Me.txtNationality.BegFindValue = Nothing
            Me.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNationality, 3)
            Me.txtNationality.ComputedValue = False
            Me.txtNationality.CustomFormat = Nothing
            Me.txtNationality.DataBoundControl = True
            Me.txtNationality.DisplayOnly = True
            Me.txtNationality.EditingMode = True
            Me.txtNationality.EndFindValue = Nothing
            Me.txtNationality.FieldDescription = Nothing
            Me.txtNationality.FieldName = Nothing
            Me.txtNationality.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNationality.FindEnabled = False
            Me.txtNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationality.ForeColor = System.Drawing.Color.Black
            Me.txtNationality.LinkedLabel = Nothing
            Me.txtNationality.Location = New System.Drawing.Point(479, 115)
            Me.txtNationality.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationality.MaximumValue = Nothing
            Me.txtNationality.MinimumValue = Nothing
            Me.txtNationality.Name = "txtNationality"
            Me.txtNationality.OldValue = Nothing
            Me.txtNationality.OverrideMaxLength = 0
            Me.txtNationality.ReadOnly = True
            Me.txtNationality.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNationality.Size = New System.Drawing.Size(714, 26)
            Me.txtNationality.TabIndex = 46
            Me.txtNationality.Translatable = False
            '
            'txtPatientName
            '
            Me.txtPatientName.BackColor = System.Drawing.Color.White
            Me.txtPatientName.BegFindValue = Nothing
            Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientName, 3)
            Me.txtPatientName.ComputedValue = False
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
            Me.txtPatientName.DisplayOnly = True
            Me.txtPatientName.EditingMode = True
            Me.txtPatientName.EndFindValue = Nothing
            Me.txtPatientName.FieldDescription = Nothing
            Me.txtPatientName.FieldName = Nothing
            Me.txtPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientName.FindEnabled = False
            Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientName.ForeColor = System.Drawing.Color.Black
            Me.txtPatientName.LinkedLabel = Nothing
            Me.txtPatientName.Location = New System.Drawing.Point(186, 29)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.ReadOnly = True
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(558, 26)
            Me.txtPatientName.TabIndex = 44
            Me.txtPatientName.Translatable = False
            '
            'CLabel16
            '
            Me.CLabel16.AutoSize = True
            Me.CLabel16.BackColor = System.Drawing.Color.Transparent
            Me.CLabel16.DisplayOnly = True
            Me.CLabel16.EditingMode = False
            Me.CLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel16.Location = New System.Drawing.Point(1, 29)
            Me.CLabel16.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel16.Name = "CLabel16"
            Me.CLabel16.Size = New System.Drawing.Size(183, 20)
            Me.CLabel16.TabIndex = 43
            Me.CLabel16.Text = "Patient Name In Report"
            Me.CLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel16.Translatable = True
            '
            'CLabel15
            '
            Me.CLabel15.AutoSize = True
            Me.CLabel15.BackColor = System.Drawing.Color.Transparent
            Me.CLabel15.DisplayOnly = True
            Me.CLabel15.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel15.EditingMode = False
            Me.CLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel15.Location = New System.Drawing.Point(479, 251)
            Me.CLabel15.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel15.Name = "CLabel15"
            Me.CLabel15.Size = New System.Drawing.Size(94, 23)
            Me.CLabel15.TabIndex = 35
            Me.CLabel15.Text = "Completed:"
            Me.CLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel15.Translatable = True
            '
            'txtRequestedBy
            '
            Me.txtRequestedBy.BackColor = System.Drawing.Color.White
            Me.txtRequestedBy.BegFindValue = Nothing
            Me.txtRequestedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtRequestedBy, 3)
            Me.txtRequestedBy.ComputedValue = False
            Me.txtRequestedBy.CustomFormat = Nothing
            Me.txtRequestedBy.DataBoundControl = True
            Me.txtRequestedBy.DisplayOnly = True
            Me.txtRequestedBy.EditingMode = True
            Me.txtRequestedBy.EndFindValue = Nothing
            Me.txtRequestedBy.FieldDescription = Nothing
            Me.txtRequestedBy.FieldName = Nothing
            Me.txtRequestedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRequestedBy.FindEnabled = False
            Me.txtRequestedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRequestedBy.ForeColor = System.Drawing.Color.Black
            Me.txtRequestedBy.LinkedLabel = Nothing
            Me.txtRequestedBy.Location = New System.Drawing.Point(186, 87)
            Me.txtRequestedBy.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRequestedBy.MaximumValue = Nothing
            Me.txtRequestedBy.MinimumValue = Nothing
            Me.txtRequestedBy.Name = "txtRequestedBy"
            Me.txtRequestedBy.OldValue = Nothing
            Me.txtRequestedBy.OverrideMaxLength = 0
            Me.txtRequestedBy.ReadOnly = True
            Me.txtRequestedBy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRequestedBy.Size = New System.Drawing.Size(558, 26)
            Me.txtRequestedBy.TabIndex = 24
            Me.txtRequestedBy.Translatable = False
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.BackColor = System.Drawing.Color.Transparent
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(1, 1)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(130, 20)
            Me.CLabel4.TabIndex = 19
            Me.CLabel4.Text = "Invoice Number:"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'txtPatientNameMRN
            '
            Me.txtPatientNameMRN.BackColor = System.Drawing.Color.White
            Me.txtPatientNameMRN.BegFindValue = Nothing
            Me.txtPatientNameMRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientNameMRN, 3)
            Me.txtPatientNameMRN.ComputedValue = False
            Me.txtPatientNameMRN.CustomFormat = Nothing
            Me.txtPatientNameMRN.DataBoundControl = True
            Me.txtPatientNameMRN.DisplayOnly = True
            Me.txtPatientNameMRN.EditingMode = True
            Me.txtPatientNameMRN.EndFindValue = Nothing
            Me.txtPatientNameMRN.FieldDescription = Nothing
            Me.txtPatientNameMRN.FieldName = Nothing
            Me.txtPatientNameMRN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientNameMRN.FindEnabled = False
            Me.txtPatientNameMRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientNameMRN.ForeColor = System.Drawing.Color.Black
            Me.txtPatientNameMRN.LinkedLabel = Nothing
            Me.txtPatientNameMRN.Location = New System.Drawing.Point(479, 1)
            Me.txtPatientNameMRN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientNameMRN.MaximumValue = Nothing
            Me.txtPatientNameMRN.MinimumValue = Nothing
            Me.txtPatientNameMRN.Name = "txtPatientNameMRN"
            Me.txtPatientNameMRN.OldValue = Nothing
            Me.txtPatientNameMRN.OverrideMaxLength = 0
            Me.txtPatientNameMRN.ReadOnly = True
            Me.txtPatientNameMRN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientNameMRN.Size = New System.Drawing.Size(714, 26)
            Me.txtPatientNameMRN.TabIndex = 18
            Me.txtPatientNameMRN.Translatable = False
            '
            'txtSampleNo
            '
            Me.txtSampleNo.BackColor = System.Drawing.Color.White
            Me.txtSampleNo.BegFindValue = Nothing
            Me.txtSampleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSampleNo.ComputedValue = False
            Me.txtSampleNo.CustomFormat = Nothing
            Me.txtSampleNo.DataBoundControl = True
            Me.txtSampleNo.EditingMode = True
            Me.txtSampleNo.EndFindValue = Nothing
            Me.txtSampleNo.FieldDescription = Nothing
            Me.txtSampleNo.FieldName = Nothing
            Me.txtSampleNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSampleNo.FindEnabled = False
            Me.txtSampleNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSampleNo.ForeColor = System.Drawing.Color.Black
            Me.txtSampleNo.LinkedLabel = Nothing
            Me.txtSampleNo.Location = New System.Drawing.Point(186, 1)
            Me.txtSampleNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSampleNo.MaximumValue = Nothing
            Me.txtSampleNo.MinimumValue = Nothing
            Me.txtSampleNo.Name = "txtSampleNo"
            Me.txtSampleNo.OldValue = Nothing
            Me.txtSampleNo.OverrideMaxLength = 0
            Me.txtSampleNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSampleNo.Size = New System.Drawing.Size(129, 26)
            Me.txtSampleNo.TabIndex = 17
            Me.txtSampleNo.Translatable = False
            '
            'CLabel6
            '
            Me.CLabel6.AutoSize = True
            Me.CLabel6.BackColor = System.Drawing.Color.Transparent
            Me.CLabel6.DisplayOnly = True
            Me.CLabel6.EditingMode = False
            Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel6.Location = New System.Drawing.Point(1, 87)
            Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel6.Name = "CLabel6"
            Me.CLabel6.Size = New System.Drawing.Size(116, 20)
            Me.CLabel6.TabIndex = 23
            Me.CLabel6.Text = "Requested by:"
            Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel6.Translatable = True
            '
            'CLabel9
            '
            Me.CLabel9.BackColor = System.Drawing.Color.Transparent
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel9.Location = New System.Drawing.Point(1, 149)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(147, 32)
            Me.CLabel9.TabIndex = 29
            Me.CLabel9.Text = "Collected by:"
            Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel9.Translatable = True
            '
            'CLabel13
            '
            Me.CLabel13.BackColor = System.Drawing.Color.Transparent
            Me.CLabel13.DisplayOnly = True
            Me.CLabel13.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel13.EditingMode = False
            Me.CLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel13.Location = New System.Drawing.Point(1, 217)
            Me.CLabel13.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel13.Name = "CLabel13"
            Me.CLabel13.Size = New System.Drawing.Size(147, 32)
            Me.CLabel13.TabIndex = 33
            Me.CLabel13.Text = "Validated by:"
            Me.CLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel13.Translatable = True
            '
            'CLabel11
            '
            Me.CLabel11.BackColor = System.Drawing.Color.Transparent
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(1, 183)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(147, 32)
            Me.CLabel11.TabIndex = 31
            Me.CLabel11.Text = "Processed by:"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel11.Translatable = True
            '
            'dtpCollectedDateTime
            '
            Me.dtpCollectedDateTime.AutoSize = True
            Me.dtpCollectedDateTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpCollectedDateTime.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpCollectedDateTime.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCollectedDateTime.DefaultValue = Nothing
            Me.dtpCollectedDateTime.DisplayOnly = False
            Me.dtpCollectedDateTime.DtpDefaultValue = Nothing
            Me.dtpCollectedDateTime.EditingControlDataGridView = Nothing
            Me.dtpCollectedDateTime.EditingControlFormattedValue = Nothing
            Me.dtpCollectedDateTime.EditingControlRowIndex = 0
            Me.dtpCollectedDateTime.EditingControlValueChanged = False
            Me.dtpCollectedDateTime.EditingMode = True
            Me.dtpCollectedDateTime.EditsAllowed = False
            Me.dtpCollectedDateTime.ForeColor = System.Drawing.Color.Black
            Me.dtpCollectedDateTime.LinkedLabel = Nothing
            Me.dtpCollectedDateTime.Location = New System.Drawing.Point(953, 148)
            Me.dtpCollectedDateTime.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpCollectedDateTime.Name = "dtpCollectedDateTime"
            Me.dtpCollectedDateTime.ReadOnlyDp = False
            Me.dtpCollectedDateTime.SecurityKey = Nothing
            Me.dtpCollectedDateTime.ShowLongDate = False
            Me.dtpCollectedDateTime.ShowTime = True
            Me.dtpCollectedDateTime.Size = New System.Drawing.Size(206, 27)
            Me.dtpCollectedDateTime.TabIndex = 36
            Me.dtpCollectedDateTime.TargetCalendar = CType(resources.GetObject("dtpCollectedDateTime.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpCollectedDateTime.Translatable = False
            Me.dtpCollectedDateTime.Value = Nothing
            Me.dtpCollectedDateTime.ValueIsMandatory = False
            Me.dtpCollectedDateTime.ValueIsNullable = False
            '
            'dtpProcessedDateTime
            '
            Me.dtpProcessedDateTime.AutoSize = True
            Me.dtpProcessedDateTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpProcessedDateTime.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpProcessedDateTime.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpProcessedDateTime.DefaultValue = Nothing
            Me.dtpProcessedDateTime.DisplayOnly = False
            Me.dtpProcessedDateTime.DtpDefaultValue = Nothing
            Me.dtpProcessedDateTime.EditingControlDataGridView = Nothing
            Me.dtpProcessedDateTime.EditingControlFormattedValue = Nothing
            Me.dtpProcessedDateTime.EditingControlRowIndex = 0
            Me.dtpProcessedDateTime.EditingControlValueChanged = False
            Me.dtpProcessedDateTime.EditingMode = True
            Me.dtpProcessedDateTime.EditsAllowed = False
            Me.dtpProcessedDateTime.ForeColor = System.Drawing.Color.Black
            Me.dtpProcessedDateTime.LinkedLabel = Nothing
            Me.dtpProcessedDateTime.Location = New System.Drawing.Point(953, 182)
            Me.dtpProcessedDateTime.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpProcessedDateTime.Name = "dtpProcessedDateTime"
            Me.dtpProcessedDateTime.ReadOnlyDp = False
            Me.dtpProcessedDateTime.SecurityKey = Nothing
            Me.dtpProcessedDateTime.ShowLongDate = False
            Me.dtpProcessedDateTime.ShowTime = True
            Me.dtpProcessedDateTime.Size = New System.Drawing.Size(206, 27)
            Me.dtpProcessedDateTime.TabIndex = 37
            Me.dtpProcessedDateTime.TargetCalendar = CType(resources.GetObject("dtpProcessedDateTime.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpProcessedDateTime.Translatable = False
            Me.dtpProcessedDateTime.Value = Nothing
            Me.dtpProcessedDateTime.ValueIsMandatory = False
            Me.dtpProcessedDateTime.ValueIsNullable = False
            '
            'dtpValidatedDateTime
            '
            Me.dtpValidatedDateTime.AutoSize = True
            Me.dtpValidatedDateTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpValidatedDateTime.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpValidatedDateTime.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpValidatedDateTime.DefaultValue = Nothing
            Me.dtpValidatedDateTime.DisplayOnly = False
            Me.dtpValidatedDateTime.DtpDefaultValue = Nothing
            Me.dtpValidatedDateTime.EditingControlDataGridView = Nothing
            Me.dtpValidatedDateTime.EditingControlFormattedValue = Nothing
            Me.dtpValidatedDateTime.EditingControlRowIndex = 0
            Me.dtpValidatedDateTime.EditingControlValueChanged = False
            Me.dtpValidatedDateTime.EditingMode = True
            Me.dtpValidatedDateTime.EditsAllowed = False
            Me.dtpValidatedDateTime.ForeColor = System.Drawing.Color.Black
            Me.dtpValidatedDateTime.LinkedLabel = Nothing
            Me.dtpValidatedDateTime.Location = New System.Drawing.Point(953, 216)
            Me.dtpValidatedDateTime.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpValidatedDateTime.Name = "dtpValidatedDateTime"
            Me.dtpValidatedDateTime.ReadOnlyDp = False
            Me.dtpValidatedDateTime.SecurityKey = Nothing
            Me.dtpValidatedDateTime.ShowLongDate = False
            Me.dtpValidatedDateTime.ShowTime = True
            Me.dtpValidatedDateTime.Size = New System.Drawing.Size(206, 27)
            Me.dtpValidatedDateTime.TabIndex = 38
            Me.dtpValidatedDateTime.TargetCalendar = CType(resources.GetObject("dtpValidatedDateTime.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpValidatedDateTime.Translatable = False
            Me.dtpValidatedDateTime.Value = Nothing
            Me.dtpValidatedDateTime.ValueIsMandatory = False
            Me.dtpValidatedDateTime.ValueIsNullable = False
            '
            'txtCollectedBy
            '
            Me.txtCollectedBy.BackColor = System.Drawing.Color.White
            Me.txtCollectedBy.BegFindValue = Nothing
            Me.txtCollectedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtCollectedBy, 3)
            Me.txtCollectedBy.ComputedValue = False
            Me.txtCollectedBy.CustomFormat = Nothing
            Me.txtCollectedBy.DataBoundControl = True
            Me.txtCollectedBy.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtCollectedBy.EditingMode = True
            Me.txtCollectedBy.EndFindValue = Nothing
            Me.txtCollectedBy.FieldDescription = Nothing
            Me.txtCollectedBy.FieldName = Nothing
            Me.txtCollectedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCollectedBy.FindEnabled = False
            Me.txtCollectedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCollectedBy.ForeColor = System.Drawing.Color.Black
            Me.txtCollectedBy.LinkedLabel = Nothing
            Me.txtCollectedBy.Location = New System.Drawing.Point(186, 149)
            Me.txtCollectedBy.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCollectedBy.MaximumValue = Nothing
            Me.txtCollectedBy.MinimumValue = Nothing
            Me.txtCollectedBy.Name = "txtCollectedBy"
            Me.txtCollectedBy.OldValue = Nothing
            Me.txtCollectedBy.OverrideMaxLength = 0
            Me.txtCollectedBy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCollectedBy.Size = New System.Drawing.Size(593, 26)
            Me.txtCollectedBy.TabIndex = 39
            Me.txtCollectedBy.Translatable = False
            '
            'txtProcessedBy
            '
            Me.txtProcessedBy.BackColor = System.Drawing.Color.White
            Me.txtProcessedBy.BegFindValue = Nothing
            Me.txtProcessedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtProcessedBy, 3)
            Me.txtProcessedBy.ComputedValue = False
            Me.txtProcessedBy.CustomFormat = Nothing
            Me.txtProcessedBy.DataBoundControl = True
            Me.txtProcessedBy.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtProcessedBy.EditingMode = True
            Me.txtProcessedBy.EndFindValue = Nothing
            Me.txtProcessedBy.FieldDescription = Nothing
            Me.txtProcessedBy.FieldName = Nothing
            Me.txtProcessedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProcessedBy.FindEnabled = False
            Me.txtProcessedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtProcessedBy.ForeColor = System.Drawing.Color.Black
            Me.txtProcessedBy.LinkedLabel = Nothing
            Me.txtProcessedBy.Location = New System.Drawing.Point(186, 183)
            Me.txtProcessedBy.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProcessedBy.MaximumValue = Nothing
            Me.txtProcessedBy.MinimumValue = Nothing
            Me.txtProcessedBy.Name = "txtProcessedBy"
            Me.txtProcessedBy.OldValue = Nothing
            Me.txtProcessedBy.OverrideMaxLength = 0
            Me.txtProcessedBy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProcessedBy.Size = New System.Drawing.Size(593, 26)
            Me.txtProcessedBy.TabIndex = 40
            Me.txtProcessedBy.Translatable = False
            '
            'txtValidatedBy
            '
            Me.txtValidatedBy.BackColor = System.Drawing.Color.White
            Me.txtValidatedBy.BegFindValue = Nothing
            Me.txtValidatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtValidatedBy, 3)
            Me.txtValidatedBy.ComputedValue = False
            Me.txtValidatedBy.CustomFormat = Nothing
            Me.txtValidatedBy.DataBoundControl = True
            Me.txtValidatedBy.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtValidatedBy.EditingMode = True
            Me.txtValidatedBy.EndFindValue = Nothing
            Me.txtValidatedBy.FieldDescription = Nothing
            Me.txtValidatedBy.FieldName = Nothing
            Me.txtValidatedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtValidatedBy.FindEnabled = False
            Me.txtValidatedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtValidatedBy.ForeColor = System.Drawing.Color.Black
            Me.txtValidatedBy.LinkedLabel = Nothing
            Me.txtValidatedBy.Location = New System.Drawing.Point(186, 217)
            Me.txtValidatedBy.Margin = New System.Windows.Forms.Padding(1)
            Me.txtValidatedBy.MaximumValue = Nothing
            Me.txtValidatedBy.MinimumValue = Nothing
            Me.txtValidatedBy.Name = "txtValidatedBy"
            Me.txtValidatedBy.OldValue = Nothing
            Me.txtValidatedBy.OverrideMaxLength = 0
            Me.txtValidatedBy.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtValidatedBy.Size = New System.Drawing.Size(593, 26)
            Me.txtValidatedBy.TabIndex = 41
            Me.txtValidatedBy.Translatable = False
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(317, 1)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(160, 20)
            Me.CLabel3.TabIndex = 16
            Me.CLabel3.Text = "Patient Name in File"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'CLabel7
            '
            Me.CLabel7.AutoSize = True
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel7.Location = New System.Drawing.Point(317, 115)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(92, 20)
            Me.CLabel7.TabIndex = 25
            Me.CLabel7.Text = "Nationality:"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'CLabel8
            '
            Me.CLabel8.AutoSize = True
            Me.CLabel8.BackColor = System.Drawing.Color.Transparent
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel8.Location = New System.Drawing.Point(1, 57)
            Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel8.Name = "CLabel8"
            Me.CLabel8.Size = New System.Drawing.Size(47, 20)
            Me.CLabel8.TabIndex = 27
            Me.CLabel8.Text = "MRN"
            Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel8.Translatable = True
            '
            'txtMRN
            '
            Me.txtMRN.BackColor = System.Drawing.Color.White
            Me.txtMRN.BegFindValue = Nothing
            Me.txtMRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMRN.ComputedValue = False
            Me.txtMRN.CustomFormat = Nothing
            Me.txtMRN.DataBoundControl = True
            Me.txtMRN.DisplayOnly = True
            Me.txtMRN.EditingMode = True
            Me.txtMRN.EndFindValue = Nothing
            Me.txtMRN.FieldDescription = Nothing
            Me.txtMRN.FieldName = Nothing
            Me.txtMRN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMRN.FindEnabled = False
            Me.txtMRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtMRN.ForeColor = System.Drawing.Color.Black
            Me.txtMRN.LinkedLabel = Nothing
            Me.txtMRN.Location = New System.Drawing.Point(186, 57)
            Me.txtMRN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtMRN.MaximumValue = Nothing
            Me.txtMRN.MinimumValue = Nothing
            Me.txtMRN.Name = "txtMRN"
            Me.txtMRN.OldValue = Nothing
            Me.txtMRN.OverrideMaxLength = 0
            Me.txtMRN.ReadOnly = True
            Me.txtMRN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMRN.Size = New System.Drawing.Size(129, 26)
            Me.txtMRN.TabIndex = 48
            Me.txtMRN.Translatable = False
            '
            'CLabel10
            '
            Me.CLabel10.BackColor = System.Drawing.Color.Transparent
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(781, 149)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(147, 32)
            Me.CLabel10.TabIndex = 30
            Me.CLabel10.Text = "Collected Date:"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel10.Translatable = True
            '
            'CLabel12
            '
            Me.CLabel12.BackColor = System.Drawing.Color.Transparent
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel12.Location = New System.Drawing.Point(781, 183)
            Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel12.Name = "CLabel12"
            Me.CLabel12.Size = New System.Drawing.Size(171, 32)
            Me.CLabel12.TabIndex = 32
            Me.CLabel12.Text = "Processed Date:"
            Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel12.Translatable = True
            '
            'CLabel14
            '
            Me.CLabel14.BackColor = System.Drawing.Color.Transparent
            Me.CLabel14.DisplayOnly = True
            Me.CLabel14.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel14.EditingMode = False
            Me.CLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel14.Location = New System.Drawing.Point(781, 217)
            Me.CLabel14.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel14.Name = "CLabel14"
            Me.CLabel14.Size = New System.Drawing.Size(147, 32)
            Me.CLabel14.TabIndex = 34
            Me.CLabel14.Text = "Validated Date:"
            Me.CLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel14.Translatable = True
            '
            'txtAge
            '
            Me.txtAge.BackColor = System.Drawing.Color.White
            Me.txtAge.BegFindValue = Nothing
            Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAge.ComputedValue = False
            Me.txtAge.CustomFormat = Nothing
            Me.txtAge.DataBoundControl = True
            Me.txtAge.DisplayOnly = True
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = False
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(479, 57)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.ReadOnly = True
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(245, 26)
            Me.txtAge.TabIndex = 21
            Me.txtAge.Translatable = False
            '
            'CLabel5
            '
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(781, 57)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(80, 21)
            Me.CLabel5.TabIndex = 20
            Me.CLabel5.Text = "Gender:"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtGender
            '
            Me.txtGender.BackColor = System.Drawing.Color.White
            Me.txtGender.BegFindValue = Nothing
            Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGender.ComputedValue = False
            Me.txtGender.CustomFormat = Nothing
            Me.txtGender.DataBoundControl = True
            Me.txtGender.DisplayOnly = True
            Me.txtGender.EditingMode = True
            Me.txtGender.EndFindValue = Nothing
            Me.txtGender.FieldDescription = Nothing
            Me.txtGender.FieldName = Nothing
            Me.txtGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGender.FindEnabled = False
            Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGender.ForeColor = System.Drawing.Color.Black
            Me.txtGender.LinkedLabel = Nothing
            Me.txtGender.Location = New System.Drawing.Point(954, 57)
            Me.txtGender.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGender.MaximumValue = Nothing
            Me.txtGender.MinimumValue = Nothing
            Me.txtGender.Name = "txtGender"
            Me.txtGender.OldValue = Nothing
            Me.txtGender.OverrideMaxLength = 0
            Me.txtGender.ReadOnly = True
            Me.txtGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGender.Size = New System.Drawing.Size(258, 26)
            Me.txtGender.TabIndex = 22
            Me.txtGender.Translatable = False
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Location = New System.Drawing.Point(1, 115)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(147, 32)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Invoice Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(953, 250)
            Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(95, 25)
            Me.btnRefresh.TabIndex = 11
            Me.btnRefresh.Text = "Refresh"
            '
            'btnUpdateNameFromFile
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.btnUpdateNameFromFile, 2)
            Me.btnUpdateNameFromFile.DesignerSelected = False
            Me.btnUpdateNameFromFile.ImageIndex = 0
            Me.btnUpdateNameFromFile.Location = New System.Drawing.Point(780, 28)
            Me.btnUpdateNameFromFile.Margin = New System.Windows.Forms.Padding(0)
            Me.btnUpdateNameFromFile.Name = "btnUpdateNameFromFile"
            Me.btnUpdateNameFromFile.OriginalImageName = Nothing
            Me.btnUpdateNameFromFile.SecurityKey = ""
            Me.btnUpdateNameFromFile.Size = New System.Drawing.Size(433, 25)
            Me.btnUpdateNameFromFile.TabIndex = 49
            Me.btnUpdateNameFromFile.Text = "Update Name from File"
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(317, 57)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(49, 28)
            Me.CLabel2.TabIndex = 15
            Me.CLabel2.Text = "Age:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'lblRequestedBy
            '
            Me.lblRequestedBy.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestedBy.DisplayOnly = True
            Me.lblRequestedBy.EditingMode = False
            Me.lblRequestedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRequestedBy.Location = New System.Drawing.Point(781, 87)
            Me.lblRequestedBy.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRequestedBy.Name = "lblRequestedBy"
            Me.lblRequestedBy.Size = New System.Drawing.Size(171, 21)
            Me.lblRequestedBy.TabIndex = 50
            Me.lblRequestedBy.Text = "Requested Date:"
            Me.lblRequestedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRequestedBy.Translatable = True
            '
            'chkCompleted
            '
            Me.chkCompleted.BackColor = System.Drawing.Color.White
            Me.chkCompleted.BegFindValue = Nothing
            Me.chkCompleted.DisplayOnly = False
            Me.chkCompleted.EditingMode = True
            Me.chkCompleted.EndFindValue = Nothing
            Me.chkCompleted.FieldDescription = Nothing
            Me.chkCompleted.FieldName = Nothing
            Me.chkCompleted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCompleted.FindEnabled = False
            Me.chkCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkCompleted.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkCompleted.ForeColor = System.Drawing.Color.Black
            Me.chkCompleted.IFindableControl_FindEnabled = False
            Me.chkCompleted.IgnoreCase = False
            Me.chkCompleted.LinkedLabel = Nothing
            Me.chkCompleted.Location = New System.Drawing.Point(784, 254)
            Me.chkCompleted.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.chkCompleted.Name = "chkCompleted"
            Me.chkCompleted.NoLabel = True
            Me.chkCompleted.OldValue = Nothing
            Me.chkCompleted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCompleted.Size = New System.Drawing.Size(17, 16)
            Me.chkCompleted.TabIndex = 42
            Me.chkCompleted.Text = "CCheckBox1"
            Me.chkCompleted.Translatable = False
            Me.chkCompleted.UseVisualStyleBackColor = False
            '
            'txtRequestedDateTime
            '
            Me.txtRequestedDateTime.BackColor = System.Drawing.Color.White
            Me.txtRequestedDateTime.BegFindValue = Nothing
            Me.txtRequestedDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRequestedDateTime.ComputedValue = False
            Me.txtRequestedDateTime.CustomFormat = Nothing
            Me.txtRequestedDateTime.DataBoundControl = True
            Me.txtRequestedDateTime.DisplayOnly = True
            Me.txtRequestedDateTime.EditingMode = True
            Me.txtRequestedDateTime.EndFindValue = Nothing
            Me.txtRequestedDateTime.FieldDescription = Nothing
            Me.txtRequestedDateTime.FieldName = Nothing
            Me.txtRequestedDateTime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRequestedDateTime.FindEnabled = False
            Me.txtRequestedDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRequestedDateTime.ForeColor = System.Drawing.Color.Black
            Me.txtRequestedDateTime.LinkedLabel = Nothing
            Me.txtRequestedDateTime.Location = New System.Drawing.Point(954, 87)
            Me.txtRequestedDateTime.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRequestedDateTime.MaximumValue = Nothing
            Me.txtRequestedDateTime.MinimumValue = Nothing
            Me.txtRequestedDateTime.Name = "txtRequestedDateTime"
            Me.txtRequestedDateTime.OldValue = Nothing
            Me.txtRequestedDateTime.OverrideMaxLength = 0
            Me.txtRequestedDateTime.ReadOnly = True
            Me.txtRequestedDateTime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRequestedDateTime.Size = New System.Drawing.Size(258, 26)
            Me.txtRequestedDateTime.TabIndex = 53
            Me.txtRequestedDateTime.Translatable = False
            '
            'btnSaveStatus
            '
            Me.btnSaveStatus.DesignerSelected = False
            Me.btnSaveStatus.ImageIndex = 0
            Me.btnSaveStatus.Location = New System.Drawing.Point(482, 279)
            Me.btnSaveStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.btnSaveStatus.Name = "btnSaveStatus"
            Me.btnSaveStatus.OriginalImageName = Nothing
            Me.btnSaveStatus.SecurityKey = ""
            Me.btnSaveStatus.SideImageAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.btnSaveStatus.Size = New System.Drawing.Size(179, 30)
            Me.btnSaveStatus.TabIndex = 54
            Me.btnSaveStatus.Text = "Save"
            '
            'txtDoctorCode
            '
            Me.txtDoctorCode.BackColor = System.Drawing.Color.White
            Me.txtDoctorCode.BegFindValue = Nothing
            Me.txtDoctorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorCode.ComputedValue = False
            Me.txtDoctorCode.CustomFormat = Nothing
            Me.txtDoctorCode.DataBoundControl = True
            Me.txtDoctorCode.EditingMode = True
            Me.txtDoctorCode.EndFindValue = Nothing
            Me.txtDoctorCode.FieldDescription = Nothing
            Me.txtDoctorCode.FieldName = Nothing
            Me.txtDoctorCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorCode.FindEnabled = False
            Me.txtDoctorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorCode.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorCode.LinkedLabel = Nothing
            Me.txtDoctorCode.Location = New System.Drawing.Point(924, 110)
            Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.OverrideMaxLength = 0
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(106, 26)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'LabReportStatusForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1311, 423)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "LabReportStatusForm"
            Me.Text = "Laboratory Report Status Updater"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtSampleNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPatientNameMRN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGender As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtAge As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtRequestedBy As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel15 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel9 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel12 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel13 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel14 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpCollectedDateTime As Libraries.CBaseControlsLibrary.CDgvDtpEditingControl
        Friend WithEvents dtpProcessedDateTime As Libraries.CBaseControlsLibrary.CDgvDtpEditingControl
        Friend WithEvents dtpValidatedDateTime As Libraries.CBaseControlsLibrary.CDgvDtpEditingControl
        Friend WithEvents txtCollectedBy As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtProcessedBy As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtValidatedBy As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents chkCompleted As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents CLabel16 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPatientName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtNationality As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtMRN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnUpdateNameFromFile As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblRequestedBy As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtInvoiceNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel17 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtRequestedDateTime As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnRefresh As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnSaveStatus As Libraries.CBaseControlsLibrary.CButton
    End Class
End Namespace