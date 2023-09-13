Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ProductMovementReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductMovementReport))
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblProductIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboProductIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblEndingDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 54)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 22
            Me.lblSupplierCode.Text = "Warehouse Name"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierCode.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblProductIdNo)
            Me.CFlowLayout1.Controls.Add(Me.cboProductIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.lblEndingDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(696, 171)
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
            Me.CLabel2.Text = "Product Movement Report"
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
            Me.CLabel3.Location = New System.Drawing.Point(1, 28)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(60, 17)
            Me.CLabel3.TabIndex = 28
            Me.CLabel3.Text = " "
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
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
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(153, 54)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.MaxDropDownItems = 1
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(530, 28)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestCharCount = 0
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 29
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'lblProductIdNo
            '
            Me.lblProductIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblProductIdNo.DisplayOnly = True
            Me.lblProductIdNo.EditingMode = False
            Me.lblProductIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblProductIdNo.Location = New System.Drawing.Point(1, 84)
            Me.lblProductIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProductIdNo.Name = "lblProductIdNo"
            Me.lblProductIdNo.Size = New System.Drawing.Size(150, 24)
            Me.lblProductIdNo.TabIndex = 36
            Me.lblProductIdNo.Text = "Product Name"
            Me.lblProductIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblProductIdNo.Translatable = True
            '
            'cboProductIdNo
            '
            Me.cboProductIdNo.BackColor = System.Drawing.Color.White
            Me.cboProductIdNo.BegFindValue = Nothing
            Me.cboProductIdNo.ChangingSearchValueOnly = False
            Me.cboProductIdNo.CurrentSearchTerm = ""
            Me.cboProductIdNo.DataValue = Nothing
            Me.cboProductIdNo.DefaultValue = Nothing
            Me.cboProductIdNo.DisplayMember = "Name"
            Me.cboProductIdNo.DropDownHeight = 24
            Me.cboProductIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboProductIdNo.Editable = True
            Me.cboProductIdNo.EditingMode = False
            Me.cboProductIdNo.EndFindValue = Nothing
            Me.cboProductIdNo.FieldDescription = Nothing
            Me.cboProductIdNo.FieldName = Nothing
            Me.cboProductIdNo.FilterRule = Nothing
            Me.cboProductIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboProductIdNo.FindEnabled = False
            Me.cboProductIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboProductIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboProductIdNo.FormattingEnabled = True
            Me.cboProductIdNo.HideWhenNotEditingOrAdding = False
            Me.cboProductIdNo.IgnoreCase = False
            Me.cboProductIdNo.LimitToList = False
            Me.cboProductIdNo.LinkedLabel = Nothing
            Me.cboProductIdNo.Location = New System.Drawing.Point(153, 84)
            Me.cboProductIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboProductIdNo.MaxDropDownItems = 1
            Me.cboProductIdNo.Name = "cboProductIdNo"
            Me.cboProductIdNo.OldValue = 0
            Me.cboProductIdNo.OriginalDataSource = Nothing
            Me.cboProductIdNo.OriginalList = Nothing
            Me.cboProductIdNo.OverrideDropDownStyleList = False
            Me.cboProductIdNo.PreviousSearchTerm = Nothing
            Me.cboProductIdNo.PropertySelector = Nothing
            Me.cboProductIdNo.Size = New System.Drawing.Size(530, 28)
            Me.cboProductIdNo.Sorted = True
            Me.cboProductIdNo.SuggestBoxHeight = 246
            Me.cboProductIdNo.SuggestCharCount = 4
            Me.cboProductIdNo.SuggestListOrderRule = Nothing
            Me.cboProductIdNo.TabIndex = 37
            Me.cboProductIdNo.TextToSearch = Nothing
            Me.cboProductIdNo.Translatable = False
            Me.cboProductIdNo.ValueIsMandatory = False
            Me.cboProductIdNo.ValueIsNullable = False
            Me.cboProductIdNo.ValueIsNumeric = False
            Me.cboProductIdNo.ValueMember = "IdNo"
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.BackColor = System.Drawing.Color.Transparent
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBeginningDate.Location = New System.Drawing.Point(1, 114)
            Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBeginningDate.Name = "lblBeginningDate"
            Me.lblBeginningDate.Size = New System.Drawing.Size(150, 23)
            Me.lblBeginningDate.TabIndex = 33
            Me.lblBeginningDate.Text = "Beginning Date"
            Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBeginningDate.Translatable = True
            '
            'dtpBeginningDate
            '
            Me.dtpBeginningDate.AutoSize = True
            Me.dtpBeginningDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpBeginningDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBeginningDate.DefaultValue = Nothing
            Me.dtpBeginningDate.DisplayOnly = False
            Me.dtpBeginningDate.DtpDefaultValue = Nothing
            Me.dtpBeginningDate.EditingMode = True
            Me.dtpBeginningDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, True)
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            Me.dtpBeginningDate.Location = New System.Drawing.Point(152, 113)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpBeginningDate.TabIndex = 32
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Translatable = False
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'lblEndingDate
            '
            Me.lblEndingDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndingDate.DisplayOnly = True
            Me.lblEndingDate.EditingMode = False
            Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndingDate.Location = New System.Drawing.Point(1, 141)
            Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndingDate.Name = "lblEndingDate"
            Me.lblEndingDate.Size = New System.Drawing.Size(150, 23)
            Me.lblEndingDate.TabIndex = 35
            Me.lblEndingDate.Text = "Ending Date"
            Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndingDate.Translatable = True
            '
            'dtpEndingDate
            '
            Me.dtpEndingDate.AutoSize = True
            Me.dtpEndingDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpEndingDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndingDate.DefaultValue = Nothing
            Me.dtpEndingDate.DisplayOnly = False
            Me.dtpEndingDate.DtpDefaultValue = Nothing
            Me.dtpEndingDate.EditingMode = True
            Me.dtpEndingDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, True)
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(152, 140)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpEndingDate.TabIndex = 34
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Translatable = False
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
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
            Me.btnOk.Location = New System.Drawing.Point(231, 189)
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
            Me.btnCancel.Location = New System.Drawing.Point(353, 189)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'ProductMovementReport
            '
            Me.ClientSize = New System.Drawing.Size(722, 222)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "ProductMovementReport"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Product Movement Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboWarehouseIdNo As CtComboBox
        Friend WithEvents lblBeginningDate As CLabel
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents lblEndingDate As CLabel
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents lblProductIdNo As CLabel
        Friend WithEvents cboProductIdNo As CtComboBox
    End Class
End Namespace