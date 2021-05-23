Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StatementOfAp
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatementOfAp))
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.dtpEndingDate = New CCustomDateTimePicker()
            Me.dtpBeginningDate = New CCustomDateTimePicker()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 82)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 22
            Me.lblSupplierCode.Text = "Supplier Code:"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 55)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(150, 25)
            Me.CLabel3.TabIndex = 21
            Me.CLabel3.Text = "Ending Date:"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBeginningDate.Location = New System.Drawing.Point(1, 28)
            Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBeginningDate.Name = "lblBeginningDate"
            Me.lblBeginningDate.Size = New System.Drawing.Size(150, 25)
            Me.lblBeginningDate.TabIndex = 20
            Me.lblBeginningDate.Text = "Beginning Date :"
            Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboSupplierIdNo
            '
            Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
            Me.cboSupplierIdNo.ChangingSearchValueOnly = False
            Me.cboSupplierIdNo.CurrentSearchTerm = ""
            Me.cboSupplierIdNo.DefaultValue = Nothing
            Me.cboSupplierIdNo.DisplayMember = "Name"
            Me.cboSupplierIdNo.DropDownHeight = 200
            Me.cboSupplierIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSupplierIdNo.EditingMode = True
            Me.cboSupplierIdNo.FilterRule = Nothing
            Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.FormattingEnabled = True
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IntegralHeight = False
            Me.cboSupplierIdNo.LinkedLabel = Nothing
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(153, 82)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.ReadOnlyCombo = False
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(520, 24)
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
            Me.cboSupplierIdNo.TabIndex = 25
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'dtpEndingDate
            '
            Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndingDate.DefaultValue = Nothing
            Me.dtpEndingDate.DisplayOnly = False
            Me.dtpEndingDate.DtpDefaultValue = Nothing
            Me.dtpEndingDate.EditingMode = True
            Me.dtpEndingDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, True)
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            Me.dtpEndingDate.Location = New System.Drawing.Point(153, 55)
            Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpEndingDate.TabIndex = 24
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'dtpBeginningDate
            '
            Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBeginningDate.DefaultValue = Nothing
            Me.dtpBeginningDate.DisplayOnly = False
            Me.dtpBeginningDate.DtpDefaultValue = Nothing
            Me.dtpBeginningDate.EditingMode = True
            Me.dtpBeginningDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, True)
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            Me.dtpBeginningDate.Location = New System.Drawing.Point(153, 28)
            Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpBeginningDate.TabIndex = 23
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboSupplierIdNo)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(696, 121)
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
            Me.CLabel2.Text = "Statement of Accounts Payable"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CLabel1
            '
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
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.DisplayOnly = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(238, 139)
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
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(360, 139)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'StatementOfAp
            '
            Me.ClientSize = New System.Drawing.Size(722, 178)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "StatementOfAp"
            Me.Text = "Statement of A.P."
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboSupplierIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dtpEndingDate As CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    End Class
End Namespace