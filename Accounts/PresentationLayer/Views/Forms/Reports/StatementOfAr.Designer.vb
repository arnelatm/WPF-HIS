Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class StatementOfAr
        Inherits AATM.PresentationLayer.Forms.BfMain

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatementOfAr))
        Me.lblCustomerCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'lblCustomerCode
        '
        Me.lblCustomerCode.DisplayOnly = true
        Me.lblCustomerCode.EditingMode = false
        Me.lblCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCustomerCode.Location = New System.Drawing.Point(1, 82)
        Me.lblCustomerCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCustomerCode.Name = "lblCustomerCode"
        Me.lblCustomerCode.Size = New System.Drawing.Size(150, 24)
        Me.lblCustomerCode.TabIndex = 22
        Me.lblCustomerCode.Text = "Customer Code:"
        Me.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.lblBeginningDate.DisplayOnly = true
        Me.lblBeginningDate.EditingMode = false
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(1, 28)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(150, 25)
        Me.lblBeginningDate.TabIndex = 20
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerIdNo
        '
        Me.cboCustomerIdNo.BackColor = System.Drawing.Color.White
        Me.cboCustomerIdNo.ChangingSearchValueOnly = false
        Me.cboCustomerIdNo.CurrentSearchTerm = ""
        Me.cboCustomerIdNo.DefaultValue = Nothing
        Me.cboCustomerIdNo.DisplayMember = "Name"
        Me.cboCustomerIdNo.DropDownHeight = 200
        Me.cboCustomerIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerIdNo.EditingMode = true
        Me.cboCustomerIdNo.FilterRule = Nothing
        Me.cboCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboCustomerIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboCustomerIdNo.FormattingEnabled = true
        Me.cboCustomerIdNo.HideWhenNotEditingOrAdding = false
        Me.cboCustomerIdNo.IntegralHeight = false
        Me.cboCustomerIdNo.LinkedLabel = Nothing
        Me.cboCustomerIdNo.Location = New System.Drawing.Point(153, 82)
        Me.cboCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboCustomerIdNo.Name = "cboCustomerIdNo"
        Me.cboCustomerIdNo.OldValue = 0
        Me.cboCustomerIdNo.OriginalDataSource = Nothing
        Me.cboCustomerIdNo.OriginalList = Nothing
        Me.cboCustomerIdNo.OverrideDropDownStyleList = false
        Me.cboCustomerIdNo.PreviousSearchTerm = Nothing
        Me.cboCustomerIdNo.PreviousSelectedIndex = -1
        Me.cboCustomerIdNo.PropertySelector = Nothing
        Me.cboCustomerIdNo.ReadOnlyCombo = false
        Me.cboCustomerIdNo.SearchAnywhere = false
        Me.cboCustomerIdNo.Size = New System.Drawing.Size(520, 24)
        Me.cboCustomerIdNo.SuggestBoxHeight = 200
        Me.cboCustomerIdNo.SuggestListOrderRule = Nothing
        Me.cboCustomerIdNo.TabIndex = 25
        Me.cboCustomerIdNo.TextToSearch = Nothing
        Me.cboCustomerIdNo.ValueIsMandatory = false
        Me.cboCustomerIdNo.ValueIsNullable = false
        Me.cboCustomerIdNo.ValueIsNumeric = false
        Me.cboCustomerIdNo.ValueMember = "IdNo"
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DisplayOnly = false
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditingMode = true
        Me.dtpEndingDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, true)
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(153, 55)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = false
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = false
        Me.dtpEndingDate.ShowTime = false
        Me.dtpEndingDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpEndingDate.TabIndex = 24
        Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = false
        Me.dtpEndingDate.ValueIsNullable = false
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DisplayOnly = false
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditingMode = true
        Me.dtpBeginningDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpBeginningDate, true)
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(153, 28)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = false
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = false
        Me.dtpBeginningDate.ShowTime = false
        Me.dtpBeginningDate.Size = New System.Drawing.Size(107, 25)
        Me.dtpBeginningDate.TabIndex = 23
        Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = false
        Me.dtpBeginningDate.ValueIsNullable = false
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.CLabel2)
        Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.CLabel3)
        Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
        Me.CFlowLayout1.Controls.Add(Me.lblCustomerCode)
        Me.CFlowLayout1.Controls.Add(Me.cboCustomerIdNo)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(696, 121)
        Me.CFlowLayout1.TabIndex = 26
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CLabel2.Location = New System.Drawing.Point(1, 1)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(682, 25)
        Me.CLabel2.TabIndex = 26
        Me.CLabel2.Text = "Statement of Accounts Receivable"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.btnOk.DesignerSelected = false
        Me.btnOk.DisplayOnly = true
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
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DisplayOnly = true
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(360, 139)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'StatementOfAr
        '
        Me.ClientSize = New System.Drawing.Size(695, 177)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "StatementOfAr"
        Me.Text = "Statement of A.R."
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents lblCustomerCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboCustomerIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dtpEndingDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpBeginningDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    End Class
End NameSpace