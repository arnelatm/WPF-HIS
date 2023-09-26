Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DocumentExpiryList
        Inherits AATM.PresentationLayer.Forms.BfMain

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentExpiryList))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.chkAllDocuments = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout1.Controls.Add(Me.chkAllDocuments)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.lblExpiryDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpExpiryDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(687, 101)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(682, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Expiry Report by Warehouse"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.CLabel3, True)
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 83)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(60, 17)
            Me.CLabel3.TabIndex = 28
            Me.CLabel3.Text = " "
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'lblExpiryDate
            '
            Me.lblExpiryDate.BackColor = System.Drawing.Color.Transparent
            Me.lblExpiryDate.DisplayOnly = True
            Me.lblExpiryDate.EditingMode = False
            Me.lblExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExpiryDate.Location = New System.Drawing.Point(1, 108)
            Me.lblExpiryDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExpiryDate.Name = "lblExpiryDate"
            Me.lblExpiryDate.Size = New System.Drawing.Size(150, 23)
            Me.lblExpiryDate.TabIndex = 33
            Me.lblExpiryDate.Text = "Expiry Date"
            Me.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExpiryDate.Translatable = True
            '
            'dtpExpiryDate
            '
            Me.dtpExpiryDate.AutoSize = True
            Me.dtpExpiryDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpExpiryDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpExpiryDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpExpiryDate.DefaultValue = Nothing
            Me.dtpExpiryDate.DisplayOnly = False
            Me.dtpExpiryDate.DtpDefaultValue = Nothing
            Me.dtpExpiryDate.EditingMode = True
            Me.dtpExpiryDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpExpiryDate, True)
            Me.dtpExpiryDate.ForeColor = System.Drawing.Color.Black
            Me.dtpExpiryDate.LinkedLabel = Nothing
            Me.dtpExpiryDate.Location = New System.Drawing.Point(152, 107)
            Me.dtpExpiryDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpExpiryDate.Name = "dtpExpiryDate"
            Me.dtpExpiryDate.ReadOnlyDp = False
            Me.dtpExpiryDate.SecurityKey = Nothing
            Me.dtpExpiryDate.ShowLongDate = False
            Me.dtpExpiryDate.ShowTime = False
            Me.dtpExpiryDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpExpiryDate.TabIndex = 32
            Me.dtpExpiryDate.TargetCalendar = CType(resources.GetObject("dtpExpiryDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpExpiryDate.Translatable = False
            Me.dtpExpiryDate.Value = Nothing
            Me.dtpExpiryDate.ValueIsMandatory = False
            Me.dtpExpiryDate.ValueIsNullable = False
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(25, 37)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(150, 25)
            Me.CLabel1.TabIndex = 26
            Me.CLabel1.Text = "Beginning Date :"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(105, 119)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(227, 119)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 28)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 34
            Me.lblSupplierCode.Text = "Document Types"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierCode.Translatable = True
            '
            'cboWarehouseIdNo
            '
            Me.cboWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseIdNo.BegFindValue = Nothing
            Me.cboWarehouseIdNo.ChangingSearchValueOnly = False
            Me.cboWarehouseIdNo.CurrentSearchTerm = ""
            Me.cboWarehouseIdNo.DataValue = Nothing
            Me.cboWarehouseIdNo.DefaultValue = Nothing
            Me.cboWarehouseIdNo.DisplayMember = "Name"
            Me.cboWarehouseIdNo.DropDownHeight = 24
            Me.cboWarehouseIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboWarehouseIdNo.Editable = True
            Me.cboWarehouseIdNo.EditingMode = False
            Me.cboWarehouseIdNo.EndFindValue = Nothing
            Me.cboWarehouseIdNo.FieldDescription = Nothing
            Me.cboWarehouseIdNo.FieldName = Nothing
            Me.cboWarehouseIdNo.FilterRule = Nothing
            Me.cboWarehouseIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboWarehouseIdNo.FindEnabled = False
            Me.cboWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseIdNo.FormattingEnabled = True
            Me.cboWarehouseIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseIdNo.IgnoreCase = False
            Me.cboWarehouseIdNo.IntegralHeight = False
            Me.cboWarehouseIdNo.LimitToList = False
            Me.cboWarehouseIdNo.LinkedLabel = Nothing
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(153, 28)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.MaxDropDownItems = 1
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.ReadOnlyCombo = False
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(530, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 35
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'chkAllDocuments
            '
            Me.chkAllDocuments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkAllDocuments.BackColor = System.Drawing.Color.Transparent
            Me.chkAllDocuments.BegFindValue = Nothing
            Me.chkAllDocuments.Checked = False
            Me.chkAllDocuments.EditingMode = False
            Me.chkAllDocuments.EndFindValue = Nothing
            Me.chkAllDocuments.FieldDescription = Nothing
            Me.chkAllDocuments.FieldName = Nothing
            Me.chkAllDocuments.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkAllDocuments.FindEnabled = False
            Me.chkAllDocuments.IgnoreCase = False
            Me.chkAllDocuments.LinkedLabel = Nothing
            Me.chkAllDocuments.Location = New System.Drawing.Point(4, 57)
            Me.chkAllDocuments.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.chkAllDocuments.Name = "chkAllDocuments"
            Me.chkAllDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkAllDocuments.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkAllDocuments.Size = New System.Drawing.Size(679, 21)
            Me.chkAllDocuments.TabIndex = 36
            Me.chkAllDocuments.Text = "Print All Document Types"
            Me.chkAllDocuments.Translatable = True
            '
            'DocumentExpiryList
            '
            Me.ClientSize = New System.Drawing.Size(705, 157)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "DocumentExpiryList"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Expiry Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents lblExpiryDate As CLabel
        Friend WithEvents dtpExpiryDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierCode As CLabel
        Friend WithEvents cboWarehouseIdNo As CaComboBox
        Friend WithEvents chkAllDocuments As UcCheckBox
    End Class
End Namespace