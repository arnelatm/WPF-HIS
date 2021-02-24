Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GeneratePayroll
        Inherits BfMain

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneratePayroll))
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblPayroll = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBeginningDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndingDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            resources.ApplyResources(Me.btnCancel, "btnCancel")
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = True
            Me.btnOk.DisplayOnly = True
            Me.btnOk.ImageIndex = 0
            resources.ApplyResources(Me.btnOk, "btnOk")
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblPayroll)
            Me.CFlowLayout1.Controls.Add(Me.cboPayrollIdNo)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.txtPayrollIdNo)
            Me.CFlowLayout1.Controls.Add(Me.CLabel4)
            Me.CFlowLayout1.Controls.Add(Me.cboPayCycleIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpBeginningDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.dtpEndingDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel5)
            Me.CFlowLayout1.Controls.Add(Me.txtPayrollName)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'lblPayroll
            '
            Me.lblPayroll.DisplayOnly = True
            Me.lblPayroll.EditingMode = False
            resources.ApplyResources(Me.lblPayroll, "lblPayroll")
            Me.lblPayroll.Name = "lblPayroll"
            '
            'cboPayrollIdNo
            '
            Me.cboPayrollIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayrollIdNo.ChangingSearchValueOnly = False
            Me.cboPayrollIdNo.CurrentSearchTerm = ""
            Me.cboPayrollIdNo.DefaultValue = Nothing
            Me.cboPayrollIdNo.DisplayMember = "Name"
            Me.cboPayrollIdNo.DropDownHeight = 200
            Me.cboPayrollIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayrollIdNo.EditingMode = True
            Me.cboPayrollIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboPayrollIdNo, "cboPayrollIdNo")
            Me.cboPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayrollIdNo.FormattingEnabled = True
            Me.cboPayrollIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayrollIdNo.LinkedLabel = Nothing
            Me.cboPayrollIdNo.Name = "cboPayrollIdNo"
            Me.cboPayrollIdNo.OldValue = 0
            Me.cboPayrollIdNo.OriginalDataSource = Nothing
            Me.cboPayrollIdNo.OriginalList = Nothing
            Me.cboPayrollIdNo.OverrideDropDownStyleList = False
            Me.cboPayrollIdNo.PreviousSearchTerm = Nothing
            Me.cboPayrollIdNo.PreviousSelectedIndex = -1
            Me.cboPayrollIdNo.PropertySelector = Nothing
            Me.cboPayrollIdNo.ReadOnlyCombo = False
            Me.cboPayrollIdNo.SearchAnywhere = False
            Me.cboPayrollIdNo.SuggestBoxHeight = 200
            Me.cboPayrollIdNo.SuggestListOrderRule = Nothing
            Me.cboPayrollIdNo.TextToSearch = Nothing
            Me.cboPayrollIdNo.ValueIsMandatory = False
            Me.cboPayrollIdNo.ValueIsNullable = False
            Me.cboPayrollIdNo.ValueIsNumeric = False
            Me.cboPayrollIdNo.ValueMember = "IdNo"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'txtPayrollIdNo
            '
            Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
            Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollIdNo.ComputedValue = False
            Me.txtPayrollIdNo.CustomFormat = Nothing
            Me.txtPayrollIdNo.DataBoundControl = True
            Me.txtPayrollIdNo.DisplayOnly = True
            Me.txtPayrollIdNo.EditingMode = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtPayrollIdNo, True)
            resources.ApplyResources(Me.txtPayrollIdNo, "txtPayrollIdNo")
            Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollIdNo.LinkedLabel = Nothing
            Me.txtPayrollIdNo.MaximumValue = Nothing
            Me.txtPayrollIdNo.MinimumValue = Nothing
            Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
            Me.txtPayrollIdNo.OldValue = Nothing
            Me.txtPayrollIdNo.ReadOnly = True
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            resources.ApplyResources(Me.CLabel4, "CLabel4")
            Me.CLabel4.Name = "CLabel4"
            '
            'cboPayCycleIdNo
            '
            Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayCycleIdNo.ChangingSearchValueOnly = False
            Me.cboPayCycleIdNo.CurrentSearchTerm = ""
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            Me.cboPayCycleIdNo.DisplayOnly = True
            Me.cboPayCycleIdNo.DropDownHeight = 200
            Me.cboPayCycleIdNo.EditingMode = True
            Me.cboPayCycleIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboPayCycleIdNo, "cboPayCycleIdNo")
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
            Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
            Me.cboPayCycleIdNo.OldValue = 0
            Me.cboPayCycleIdNo.OriginalDataSource = Nothing
            Me.cboPayCycleIdNo.OriginalList = Nothing
            Me.cboPayCycleIdNo.OverrideDropDownStyleList = False
            Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleIdNo.PreviousSelectedIndex = -1
            Me.cboPayCycleIdNo.PropertySelector = Nothing
            Me.cboPayCycleIdNo.ReadOnlyCombo = True
            Me.cboPayCycleIdNo.SearchAnywhere = False
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
            Me.cboPayCycleIdNo.TextToSearch = Nothing
            Me.cboPayCycleIdNo.ValueIsMandatory = False
            Me.cboPayCycleIdNo.ValueIsNullable = False
            Me.cboPayCycleIdNo.ValueIsNumeric = False
            Me.cboPayCycleIdNo.ValueMember = "IdNo"
            '
            'lblBeginningDate
            '
            Me.lblBeginningDate.DisplayOnly = True
            Me.lblBeginningDate.EditingMode = False
            resources.ApplyResources(Me.lblBeginningDate, "lblBeginningDate")
            Me.lblBeginningDate.Name = "lblBeginningDate"
            '
            'dtpBeginningDate
            '
            Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBeginningDate.DefaultValue = Nothing
            Me.dtpBeginningDate.DisplayOnly = True
            Me.dtpBeginningDate.DtpDefaultValue = Nothing
            Me.dtpBeginningDate.EditingMode = True
            Me.dtpBeginningDate.EditsAllowed = False
            Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBeginningDate.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpBeginningDate, "dtpBeginningDate")
            Me.dtpBeginningDate.Name = "dtpBeginningDate"
            Me.dtpBeginningDate.ReadOnlyDp = False
            Me.dtpBeginningDate.SecurityKey = Nothing
            Me.dtpBeginningDate.ShowLongDate = False
            Me.dtpBeginningDate.ShowTime = False
            Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBeginningDate.Value = Nothing
            Me.dtpBeginningDate.ValueIsMandatory = False
            Me.dtpBeginningDate.ValueIsNullable = False
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.Name = "CLabel3"
            '
            'dtpEndingDate
            '
            Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndingDate.DefaultValue = Nothing
            Me.dtpEndingDate.DisplayOnly = True
            Me.dtpEndingDate.DtpDefaultValue = Nothing
            Me.dtpEndingDate.EditingMode = True
            Me.dtpEndingDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpEndingDate, True)
            Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndingDate.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpEndingDate, "dtpEndingDate")
            Me.dtpEndingDate.Name = "dtpEndingDate"
            Me.dtpEndingDate.ReadOnlyDp = False
            Me.dtpEndingDate.SecurityKey = Nothing
            Me.dtpEndingDate.ShowLongDate = False
            Me.dtpEndingDate.ShowTime = False
            Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndingDate.Value = Nothing
            Me.dtpEndingDate.ValueIsMandatory = False
            Me.dtpEndingDate.ValueIsNullable = False
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            resources.ApplyResources(Me.CLabel5, "CLabel5")
            Me.CLabel5.Name = "CLabel5"
            '
            'txtPayrollName
            '
            Me.txtPayrollName.BackColor = System.Drawing.Color.White
            Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollName.ComputedValue = False
            Me.txtPayrollName.CustomFormat = Nothing
            Me.txtPayrollName.DataBoundControl = True
            Me.txtPayrollName.DisplayOnly = True
            Me.txtPayrollName.EditingMode = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtPayrollName, True)
            resources.ApplyResources(Me.txtPayrollName, "txtPayrollName")
            Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollName.LinkedLabel = Nothing
            Me.txtPayrollName.MaximumValue = Nothing
            Me.txtPayrollName.MinimumValue = Nothing
            Me.txtPayrollName.Name = "txtPayrollName"
            Me.txtPayrollName.OldValue = Nothing
            Me.txtPayrollName.ReadOnly = True
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Name = "CLabel2"
            '
            'GeneratePayroll
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "GeneratePayroll"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents btnCancel As CButton
        Friend WithEvents btnOk As CButton
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblPayroll As CLabel
        Friend WithEvents cboPayrollIdNo As CaComboBox
        Friend WithEvents lblBeginningDate As CLabel
        Friend WithEvents dtpBeginningDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents dtpEndingDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents txtPayrollName As CTextBox
        Friend WithEvents cboPayCycleIdNo As CaComboBox
    End Class
End Namespace