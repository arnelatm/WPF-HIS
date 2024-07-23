Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeAbsenceEntry
        Inherits CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeAbsenceEntry))
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.lblEquivalentHours = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEquivalentHours = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAddedBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtStartDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEndDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAbsenceType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAbsenceType = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.lblAbsenceReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAbsenceReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtAddedByUser = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout2.SuspendLayout
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = false
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeIdNo.DisplayOnly = true
        Me.lblEmployeeIdNo.EditingMode = false
        resources.ApplyResources(Me.lblEmployeeIdNo, "lblEmployeeIdNo")
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, true)
        resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblEquivalentHours
        '
        Me.lblEquivalentHours.BackColor = System.Drawing.Color.Transparent
        Me.lblEquivalentHours.DisplayOnly = true
        Me.lblEquivalentHours.EditingMode = false
        resources.ApplyResources(Me.lblEquivalentHours, "lblEquivalentHours")
        Me.lblEquivalentHours.Name = "lblEquivalentHours"
        Me.lblEquivalentHours.Translatable = true
        '
        'txtEquivalentHours
        '
        Me.txtEquivalentHours.BackColor = System.Drawing.Color.White
        Me.txtEquivalentHours.BegFindValue = Nothing
        Me.txtEquivalentHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquivalentHours.ComputedValue = false
        Me.txtEquivalentHours.CustomFormat = Nothing
        Me.txtEquivalentHours.DataBoundControl = true
        Me.txtEquivalentHours.EditingMode = true
        Me.txtEquivalentHours.EndFindValue = Nothing
        Me.txtEquivalentHours.FieldDescription = Nothing
        Me.txtEquivalentHours.FieldName = Nothing
        Me.txtEquivalentHours.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEquivalentHours.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtEquivalentHours, true)
        resources.ApplyResources(Me.txtEquivalentHours, "txtEquivalentHours")
        Me.txtEquivalentHours.ForeColor = System.Drawing.Color.Black
        Me.txtEquivalentHours.LinkedLabel = Me.lblEquivalentHours
        Me.txtEquivalentHours.MaximumValue = Nothing
        Me.txtEquivalentHours.MinimumValue = Nothing
        Me.txtEquivalentHours.Name = "txtEquivalentHours"
        Me.txtEquivalentHours.OldValue = Nothing
        Me.txtEquivalentHours.ReadOnly = true
        Me.txtEquivalentHours.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEquivalentHours.Translatable = false
        Me.txtEquivalentHours.ValueIsMandatory = true
        Me.txtEquivalentHours.ValueIsNumeric = true
        '
        'lblAddedBy
        '
        Me.lblAddedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblAddedBy.DisplayOnly = true
        Me.lblAddedBy.EditingMode = false
        resources.ApplyResources(Me.lblAddedBy, "lblAddedBy")
        Me.lblAddedBy.Name = "lblAddedBy"
        Me.lblAddedBy.Translatable = true
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.White
        Me.txtUserName.BegFindValue = Nothing
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.ComputedValue = false
        Me.txtUserName.CustomFormat = Nothing
        Me.txtUserName.DataBoundControl = true
        Me.txtUserName.DisplayOnly = true
        Me.txtUserName.EditingMode = true
        Me.txtUserName.EndFindValue = Nothing
        Me.txtUserName.FieldDescription = Nothing
        Me.txtUserName.FieldName = Nothing
        Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUserName.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtUserName, true)
        resources.ApplyResources(Me.txtUserName, "txtUserName")
        Me.txtUserName.ForeColor = System.Drawing.Color.Black
        Me.txtUserName.LinkedLabel = Me.lblAddedBy
        Me.txtUserName.MaximumValue = Nothing
        Me.txtUserName.MinimumValue = Nothing
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.OldValue = Nothing
        Me.txtUserName.ReadOnly = true
        Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUserName.Translatable = false
        Me.txtUserName.ValueIsMandatory = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollIdNo)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollCode)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollCode)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.txtStartDate)
        Me.CFlowLayout2.Controls.Add(Me.lblEndDate)
        Me.CFlowLayout2.Controls.Add(Me.txtEndDate)
        Me.CFlowLayout2.Controls.Add(Me.lblPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.txtPayrollName)
        Me.CFlowLayout2.Controls.Add(Me.lblEmployeeIdNo)
        Me.CFlowLayout2.Controls.Add(Me.cboEmployeeIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblAbsenceType)
        Me.CFlowLayout2.Controls.Add(Me.cboAbsenceType)
        Me.CFlowLayout2.Controls.Add(Me.lblEquivalentHours)
        Me.CFlowLayout2.Controls.Add(Me.txtEquivalentHours)
        Me.CFlowLayout2.Controls.Add(Me.lblAbsenceReason)
        Me.CFlowLayout2.Controls.Add(Me.txtAbsenceReason)
        Me.CFlowLayout2.Controls.Add(Me.lblAddedBy)
        Me.CFlowLayout2.Controls.Add(Me.txtUserName)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtAddedByUser)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblPayrollIdNo
        '
        Me.lblPayrollIdNo.DisplayOnly = true
        Me.lblPayrollIdNo.EditingMode = false
        resources.ApplyResources(Me.lblPayrollIdNo, "lblPayrollIdNo")
        Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
        Me.lblPayrollIdNo.Translatable = true
        '
        'txtPayrollIdNo
        '
        Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
        Me.txtPayrollIdNo.BegFindValue = Nothing
        Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollIdNo.ComputedValue = false
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = true
        Me.txtPayrollIdNo.DisplayOnly = true
        Me.txtPayrollIdNo.EditingMode = true
        Me.txtPayrollIdNo.EndFindValue = Nothing
        Me.txtPayrollIdNo.FieldDescription = Nothing
        Me.txtPayrollIdNo.FieldName = Nothing
        Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollIdNo.FindEnabled = false
        resources.ApplyResources(Me.txtPayrollIdNo, "txtPayrollIdNo")
        Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollIdNo.LinkedLabel = Nothing
        Me.txtPayrollIdNo.MaximumValue = Nothing
        Me.txtPayrollIdNo.MinimumValue = Nothing
        Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
        Me.txtPayrollIdNo.OldValue = Nothing
        Me.txtPayrollIdNo.ReadOnly = true
        Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollIdNo.TabStop = false
        Me.txtPayrollIdNo.Translatable = false
        '
        'lblPayrollCode
        '
        Me.lblPayrollCode.DisplayOnly = true
        Me.lblPayrollCode.EditingMode = false
        resources.ApplyResources(Me.lblPayrollCode, "lblPayrollCode")
        Me.lblPayrollCode.Name = "lblPayrollCode"
        Me.lblPayrollCode.Translatable = true
        '
        'txtPayrollCode
        '
        Me.txtPayrollCode.BackColor = System.Drawing.Color.White
        Me.txtPayrollCode.BegFindValue = Nothing
        Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollCode.ComputedValue = false
        Me.txtPayrollCode.CustomFormat = Nothing
        Me.txtPayrollCode.DataBoundControl = true
        Me.txtPayrollCode.DisplayOnly = true
        Me.txtPayrollCode.EditingMode = true
        Me.txtPayrollCode.EndFindValue = Nothing
        Me.txtPayrollCode.FieldDescription = Nothing
        Me.txtPayrollCode.FieldName = Nothing
        Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollCode.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollCode, true)
        resources.ApplyResources(Me.txtPayrollCode, "txtPayrollCode")
        Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollCode.LinkedLabel = Nothing
        Me.txtPayrollCode.MaximumValue = Nothing
        Me.txtPayrollCode.MinimumValue = Nothing
        Me.txtPayrollCode.Name = "txtPayrollCode"
        Me.txtPayrollCode.OldValue = Nothing
        Me.txtPayrollCode.ReadOnly = true
        Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollCode.TabStop = false
        Me.txtPayrollCode.Translatable = false
        '
        'lblStartDate
        '
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Translatable = true
        '
        'txtStartDate
        '
        Me.txtStartDate.BackColor = System.Drawing.Color.White
        Me.txtStartDate.BegFindValue = Nothing
        Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartDate.ComputedValue = false
        Me.txtStartDate.CustomFormat = Nothing
        Me.txtStartDate.DataBoundControl = true
        Me.txtStartDate.DisplayOnly = true
        Me.txtStartDate.EditingMode = true
        Me.txtStartDate.EndFindValue = Nothing
        Me.txtStartDate.FieldDescription = Nothing
        Me.txtStartDate.FieldName = Nothing
        Me.txtStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtStartDate.FindEnabled = false
        resources.ApplyResources(Me.txtStartDate, "txtStartDate")
        Me.txtStartDate.ForeColor = System.Drawing.Color.Black
        Me.txtStartDate.LinkedLabel = Me.lblStartDate
        Me.txtStartDate.MaximumValue = Nothing
        Me.txtStartDate.MinimumValue = Nothing
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.OldValue = Nothing
        Me.txtStartDate.ReadOnly = true
        Me.txtStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtStartDate.Translatable = false
        Me.txtStartDate.ValueIsMandatory = true
        '
        'lblEndDate
        '
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Translatable = true
        '
        'txtEndDate
        '
        Me.txtEndDate.BackColor = System.Drawing.Color.White
        Me.txtEndDate.BegFindValue = Nothing
        Me.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndDate.ComputedValue = false
        Me.txtEndDate.CustomFormat = Nothing
        Me.txtEndDate.DataBoundControl = true
        Me.txtEndDate.DisplayOnly = true
        Me.txtEndDate.EditingMode = true
        Me.txtEndDate.EndFindValue = Nothing
        Me.txtEndDate.FieldDescription = Nothing
        Me.txtEndDate.FieldName = Nothing
        Me.txtEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEndDate.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtEndDate, true)
        resources.ApplyResources(Me.txtEndDate, "txtEndDate")
        Me.txtEndDate.ForeColor = System.Drawing.Color.Black
        Me.txtEndDate.LinkedLabel = Me.lblEndDate
        Me.txtEndDate.MaximumValue = Nothing
        Me.txtEndDate.MinimumValue = Nothing
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.OldValue = Nothing
        Me.txtEndDate.ReadOnly = true
        Me.txtEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEndDate.Translatable = false
        Me.txtEndDate.ValueIsMandatory = true
        '
        'lblPayrollName
        '
        Me.lblPayrollName.DisplayOnly = true
        Me.lblPayrollName.EditingMode = false
        resources.ApplyResources(Me.lblPayrollName, "lblPayrollName")
        Me.lblPayrollName.Name = "lblPayrollName"
        Me.lblPayrollName.Translatable = true
        '
        'txtPayrollName
        '
        Me.txtPayrollName.BackColor = System.Drawing.Color.White
        Me.txtPayrollName.BegFindValue = Nothing
        Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollName.ComputedValue = false
        Me.txtPayrollName.CustomFormat = Nothing
        Me.txtPayrollName.DataBoundControl = true
        Me.txtPayrollName.DisplayOnly = true
        Me.txtPayrollName.EditingMode = true
        Me.txtPayrollName.EndFindValue = Nothing
        Me.txtPayrollName.FieldDescription = Nothing
        Me.txtPayrollName.FieldName = Nothing
        Me.txtPayrollName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollName.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollName, true)
        resources.ApplyResources(Me.txtPayrollName, "txtPayrollName")
        Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollName.LinkedLabel = Nothing
        Me.txtPayrollName.MaximumValue = Nothing
        Me.txtPayrollName.MinimumValue = Nothing
        Me.txtPayrollName.Name = "txtPayrollName"
        Me.txtPayrollName.OldValue = Nothing
        Me.txtPayrollName.ReadOnly = true
        Me.txtPayrollName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollName.TabStop = false
        Me.txtPayrollName.Translatable = false
        Me.txtPayrollName.ValueIsMandatory = true
        '
        'lblAbsenceType
        '
        Me.lblAbsenceType.BackColor = System.Drawing.Color.Transparent
        Me.lblAbsenceType.DisplayOnly = true
        Me.lblAbsenceType.EditingMode = false
        resources.ApplyResources(Me.lblAbsenceType, "lblAbsenceType")
        Me.lblAbsenceType.Name = "lblAbsenceType"
        Me.lblAbsenceType.Translatable = true
        '
        'cboAbsenceType
        '
        Me.cboAbsenceType.BackColor = System.Drawing.Color.White
        Me.cboAbsenceType.BegFindValue = Nothing
        Me.cboAbsenceType.ChangingSearchValueOnly = false
        Me.cboAbsenceType.CurrentSearchTerm = ""
        Me.cboAbsenceType.DefaultValue = Nothing
        Me.cboAbsenceType.DisplayMember = "Name"
        Me.cboAbsenceType.EditingMode = true
        Me.cboAbsenceType.EndFindValue = Nothing
        Me.cboAbsenceType.FieldDescription = Nothing
        Me.cboAbsenceType.FieldName = Nothing
            Me.cboAbsenceType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAbsenceType.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.cboAbsenceType, true)
        resources.ApplyResources(Me.cboAbsenceType, "cboAbsenceType")
        Me.cboAbsenceType.ForeColor = System.Drawing.Color.Black
        Me.cboAbsenceType.FormattingEnabled = true
        Me.cboAbsenceType.HideWhenNotEditingOrAdding = false
        Me.cboAbsenceType.IgnoreCase = false
        Me.cboAbsenceType.LinkedLabel = Me.lblAbsenceType
        Me.cboAbsenceType.Name = "cboAbsenceType"
        Me.cboAbsenceType.OldValue = 0
        Me.cboAbsenceType.OriginalDataSource = Nothing
        Me.cboAbsenceType.OriginalList = Nothing
        Me.cboAbsenceType.OverrideDropDownStyleList = false
        Me.cboAbsenceType.PreviousSearchTerm = Nothing
            Me.cboAbsenceType.SuggestBoxHeight = 200
            Me.cboAbsenceType.Translatable = False
            Me.cboAbsenceType.ValueIsMandatory = false
        Me.cboAbsenceType.ValueIsNullable = false
        Me.cboAbsenceType.ValueIsNumeric = false
        Me.cboAbsenceType.ValueMember = "IdNo"
        '
        'lblAbsenceReason
        '
        Me.lblAbsenceReason.BackColor = System.Drawing.Color.Transparent
        Me.lblAbsenceReason.DisplayOnly = true
        Me.lblAbsenceReason.EditingMode = false
        resources.ApplyResources(Me.lblAbsenceReason, "lblAbsenceReason")
        Me.lblAbsenceReason.Name = "lblAbsenceReason"
        Me.lblAbsenceReason.Translatable = true
        '
        'txtAbsenceReason
        '
        Me.txtAbsenceReason.BackColor = System.Drawing.Color.White
        Me.txtAbsenceReason.BegFindValue = Nothing
        Me.txtAbsenceReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbsenceReason.ComputedValue = false
        Me.txtAbsenceReason.CustomFormat = Nothing
        Me.txtAbsenceReason.DataBoundControl = true
        Me.txtAbsenceReason.EditingMode = true
        Me.txtAbsenceReason.EndFindValue = Nothing
        Me.txtAbsenceReason.FieldDescription = Nothing
        Me.txtAbsenceReason.FieldName = Nothing
        Me.txtAbsenceReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAbsenceReason.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtAbsenceReason, true)
        resources.ApplyResources(Me.txtAbsenceReason, "txtAbsenceReason")
        Me.txtAbsenceReason.ForeColor = System.Drawing.Color.Black
        Me.txtAbsenceReason.LinkedLabel = Me.lblAbsenceReason
        Me.txtAbsenceReason.MaximumValue = Nothing
        Me.txtAbsenceReason.MinimumValue = Nothing
        Me.txtAbsenceReason.Name = "txtAbsenceReason"
        Me.txtAbsenceReason.OldValue = Nothing
        Me.txtAbsenceReason.ReadOnly = true
        Me.txtAbsenceReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAbsenceReason.Translatable = false
        Me.txtAbsenceReason.ValueIsMandatory = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.DisplayOnly = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, true)
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblAddedBy
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'txtAddedByUser
        '
        Me.txtAddedByUser.BackColor = System.Drawing.Color.White
        Me.txtAddedByUser.BegFindValue = Nothing
        Me.txtAddedByUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddedByUser.ComputedValue = false
        Me.txtAddedByUser.CustomFormat = Nothing
        Me.txtAddedByUser.DataBoundControl = true
        Me.txtAddedByUser.EditingMode = true
        Me.txtAddedByUser.EndFindValue = Nothing
        Me.txtAddedByUser.FieldDescription = Nothing
        Me.txtAddedByUser.FieldName = Nothing
        Me.txtAddedByUser.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAddedByUser.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.txtAddedByUser, true)
        resources.ApplyResources(Me.txtAddedByUser, "txtAddedByUser")
        Me.txtAddedByUser.ForeColor = System.Drawing.Color.Black
        Me.txtAddedByUser.LinkedLabel = Me.lblAddedBy
        Me.txtAddedByUser.MaximumValue = Nothing
        Me.txtAddedByUser.MinimumValue = Nothing
        Me.txtAddedByUser.Name = "txtAddedByUser"
        Me.txtAddedByUser.OldValue = Nothing
        Me.txtAddedByUser.ReadOnly = true
        Me.txtAddedByUser.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAddedByUser.Translatable = false
        Me.txtAddedByUser.ValueIsMandatory = true
        '
        'EmployeeAbsenceEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "EmployeeAbsenceEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CdtComboBox
        Friend WithEvents lblEquivalentHours As CLabel
        Public WithEvents txtEquivalentHours As CTextBox
        Friend WithEvents lblAddedBy As CLabel
        Public WithEvents txtUserName As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblAbsenceType As CLabel
        Public WithEvents cboAbsenceType As CdtComboBox
        Friend WithEvents lblAbsenceReason As CLabel
        Public WithEvents txtAbsenceReason As CTextBox
        Friend WithEvents lblPayrollIdNo As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents txtStartDate As CTextBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents txtEndDate As CTextBox
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents txtPayrollName As CTextBox
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Public WithEvents txtAddedByUser As CTextBox
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
    End Class
End Namespace