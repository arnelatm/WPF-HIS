Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeAbsenceEntry
        Inherits CFormEntryNew

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
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEquivalentHours = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEquivalentHours = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAddedBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtStartDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEndDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAbsenceType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAbsenceType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAbsenceReason = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAbsenceReason = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtAddedByUser = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
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
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblEmployeeIdNo
            '
            Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblEmployeeIdNo.DisplayOnly = True
            Me.lblEmployeeIdNo.EditingMode = False
            resources.ApplyResources(Me.lblEmployeeIdNo, "lblEmployeeIdNo")
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
            Me.lblEmployeeIdNo.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboEmployeeIdNo, True)
            resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.ReadOnlyCombo = False
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'lblEquivalentHours
            '
            Me.lblEquivalentHours.BackColor = System.Drawing.Color.Transparent
            Me.lblEquivalentHours.DisplayOnly = True
            Me.lblEquivalentHours.EditingMode = False
            resources.ApplyResources(Me.lblEquivalentHours, "lblEquivalentHours")
            Me.lblEquivalentHours.Name = "lblEquivalentHours"
            Me.lblEquivalentHours.Translatable = True
            '
            'txtEquivalentHours
            '
            Me.txtEquivalentHours.BackColor = System.Drawing.Color.White
            Me.txtEquivalentHours.BegFindValue = Nothing
            Me.txtEquivalentHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEquivalentHours.ComputedValue = False
            Me.txtEquivalentHours.CustomFormat = Nothing
            Me.txtEquivalentHours.DataBoundControl = True
            Me.txtEquivalentHours.EditingMode = True
            Me.txtEquivalentHours.EndFindValue = Nothing
            Me.txtEquivalentHours.FieldDescription = Nothing
            Me.txtEquivalentHours.FieldName = Nothing
            Me.txtEquivalentHours.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEquivalentHours.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtEquivalentHours, True)
            resources.ApplyResources(Me.txtEquivalentHours, "txtEquivalentHours")
            Me.txtEquivalentHours.ForeColor = System.Drawing.Color.Black
            Me.txtEquivalentHours.LinkedLabel = Me.lblEquivalentHours
            Me.txtEquivalentHours.MaximumValue = Nothing
            Me.txtEquivalentHours.MinimumValue = Nothing
            Me.txtEquivalentHours.Name = "txtEquivalentHours"
            Me.txtEquivalentHours.OldValue = Nothing
            Me.txtEquivalentHours.ReadOnly = True
            Me.txtEquivalentHours.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEquivalentHours.Translatable = False
            Me.txtEquivalentHours.ValueIsMandatory = True
            Me.txtEquivalentHours.ValueIsNumeric = True
            '
            'lblAddedBy
            '
            Me.lblAddedBy.BackColor = System.Drawing.Color.Transparent
            Me.lblAddedBy.DisplayOnly = True
            Me.lblAddedBy.EditingMode = False
            resources.ApplyResources(Me.lblAddedBy, "lblAddedBy")
            Me.lblAddedBy.Name = "lblAddedBy"
            Me.lblAddedBy.Translatable = True
            '
            'txtUserName
            '
            Me.txtUserName.BackColor = System.Drawing.Color.White
            Me.txtUserName.BegFindValue = Nothing
            Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUserName.ComputedValue = False
            Me.txtUserName.CustomFormat = Nothing
            Me.txtUserName.DataBoundControl = True
            Me.txtUserName.EditingMode = True
            Me.txtUserName.EndFindValue = Nothing
            Me.txtUserName.FieldDescription = Nothing
            Me.txtUserName.FieldName = Nothing
            Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUserName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtUserName, True)
            resources.ApplyResources(Me.txtUserName, "txtUserName")
            Me.txtUserName.ForeColor = System.Drawing.Color.Black
            Me.txtUserName.LinkedLabel = Me.lblAddedBy
            Me.txtUserName.MaximumValue = Nothing
            Me.txtUserName.MinimumValue = Nothing
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.OldValue = Nothing
            Me.txtUserName.ReadOnly = True
            Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUserName.Translatable = False
            Me.txtUserName.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblPayrollIdNo)
            Me.CFlowLayout2.Controls.Add(Me.txtPayrollIdNo)
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
            Me.CFlowLayout2.Controls.Add(Me.txtAddedByUser)
            Me.CFlowLayout2.Controls.Add(Me.txtUserName)
            Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
            Me.CFlowLayout2.Name = "CFlowLayout2"
            '
            'lblPayrollIdNo
            '
            Me.lblPayrollIdNo.DisplayOnly = True
            Me.lblPayrollIdNo.EditingMode = False
            resources.ApplyResources(Me.lblPayrollIdNo, "lblPayrollIdNo")
            Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
            Me.lblPayrollIdNo.Translatable = True
            '
            'txtPayrollIdNo
            '
            Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
            Me.txtPayrollIdNo.BegFindValue = Nothing
            Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollIdNo.ComputedValue = False
            Me.txtPayrollIdNo.CustomFormat = Nothing
            Me.txtPayrollIdNo.DataBoundControl = True
            Me.txtPayrollIdNo.EditingMode = True
            Me.txtPayrollIdNo.EndFindValue = Nothing
            Me.txtPayrollIdNo.FieldDescription = Nothing
            Me.txtPayrollIdNo.FieldName = Nothing
            Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollIdNo.FindEnabled = False
            resources.ApplyResources(Me.txtPayrollIdNo, "txtPayrollIdNo")
            Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollIdNo.LinkedLabel = Nothing
            Me.txtPayrollIdNo.MaximumValue = Nothing
            Me.txtPayrollIdNo.MinimumValue = Nothing
            Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
            Me.txtPayrollIdNo.OldValue = Nothing
            Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollIdNo.TabStop = False
            Me.txtPayrollIdNo.Translatable = False
            '
            'lblStartDate
            '
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            resources.ApplyResources(Me.lblStartDate, "lblStartDate")
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Translatable = True
            '
            'txtStartDate
            '
            Me.txtStartDate.BackColor = System.Drawing.Color.White
            Me.txtStartDate.BegFindValue = Nothing
            Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStartDate.ComputedValue = False
            Me.txtStartDate.CustomFormat = Nothing
            Me.txtStartDate.DataBoundControl = True
            Me.txtStartDate.EditingMode = True
            Me.txtStartDate.EndFindValue = Nothing
            Me.txtStartDate.FieldDescription = Nothing
            Me.txtStartDate.FieldName = Nothing
            Me.txtStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStartDate.FindEnabled = False
            resources.ApplyResources(Me.txtStartDate, "txtStartDate")
            Me.txtStartDate.ForeColor = System.Drawing.Color.Black
            Me.txtStartDate.LinkedLabel = Me.lblStartDate
            Me.txtStartDate.MaximumValue = Nothing
            Me.txtStartDate.MinimumValue = Nothing
            Me.txtStartDate.Name = "txtStartDate"
            Me.txtStartDate.OldValue = Nothing
            Me.txtStartDate.ReadOnly = True
            Me.txtStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStartDate.Translatable = False
            Me.txtStartDate.ValueIsMandatory = True
            '
            'lblEndDate
            '
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            resources.ApplyResources(Me.lblEndDate, "lblEndDate")
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Translatable = True
            '
            'txtEndDate
            '
            Me.txtEndDate.BackColor = System.Drawing.Color.White
            Me.txtEndDate.BegFindValue = Nothing
            Me.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEndDate.ComputedValue = False
            Me.txtEndDate.CustomFormat = Nothing
            Me.txtEndDate.DataBoundControl = True
            Me.txtEndDate.EditingMode = True
            Me.txtEndDate.EndFindValue = Nothing
            Me.txtEndDate.FieldDescription = Nothing
            Me.txtEndDate.FieldName = Nothing
            Me.txtEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEndDate.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtEndDate, True)
            resources.ApplyResources(Me.txtEndDate, "txtEndDate")
            Me.txtEndDate.ForeColor = System.Drawing.Color.Black
            Me.txtEndDate.LinkedLabel = Me.lblEndDate
            Me.txtEndDate.MaximumValue = Nothing
            Me.txtEndDate.MinimumValue = Nothing
            Me.txtEndDate.Name = "txtEndDate"
            Me.txtEndDate.OldValue = Nothing
            Me.txtEndDate.ReadOnly = True
            Me.txtEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEndDate.Translatable = False
            Me.txtEndDate.ValueIsMandatory = True
            '
            'lblPayrollName
            '
            Me.lblPayrollName.DisplayOnly = True
            Me.lblPayrollName.EditingMode = False
            resources.ApplyResources(Me.lblPayrollName, "lblPayrollName")
            Me.lblPayrollName.Name = "lblPayrollName"
            Me.lblPayrollName.Translatable = True
            '
            'txtPayrollName
            '
            Me.txtPayrollName.BackColor = System.Drawing.Color.White
            Me.txtPayrollName.BegFindValue = Nothing
            Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollName.ComputedValue = False
            Me.txtPayrollName.CustomFormat = Nothing
            Me.txtPayrollName.DataBoundControl = True
            Me.txtPayrollName.DisplayOnly = True
            Me.txtPayrollName.EditingMode = True
            Me.txtPayrollName.EndFindValue = Nothing
            Me.txtPayrollName.FieldDescription = Nothing
            Me.txtPayrollName.FieldName = Nothing
            Me.txtPayrollName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtPayrollName, True)
            resources.ApplyResources(Me.txtPayrollName, "txtPayrollName")
            Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollName.LinkedLabel = Nothing
            Me.txtPayrollName.MaximumValue = Nothing
            Me.txtPayrollName.MinimumValue = Nothing
            Me.txtPayrollName.Name = "txtPayrollName"
            Me.txtPayrollName.OldValue = Nothing
            Me.txtPayrollName.ReadOnly = True
            Me.txtPayrollName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollName.TabStop = False
            Me.txtPayrollName.Translatable = False
            Me.txtPayrollName.ValueIsMandatory = True
            '
            'lblAbsenceType
            '
            Me.lblAbsenceType.BackColor = System.Drawing.Color.Transparent
            Me.lblAbsenceType.DisplayOnly = True
            Me.lblAbsenceType.EditingMode = False
            resources.ApplyResources(Me.lblAbsenceType, "lblAbsenceType")
            Me.lblAbsenceType.Name = "lblAbsenceType"
            Me.lblAbsenceType.Translatable = True
            '
            'cboAbsenceType
            '
            Me.cboAbsenceType.BackColor = System.Drawing.Color.White
            Me.cboAbsenceType.BegFindValue = Nothing
            Me.cboAbsenceType.ChangingSearchValueOnly = False
            Me.cboAbsenceType.CurrentSearchTerm = ""
            Me.cboAbsenceType.DefaultValue = Nothing
            Me.cboAbsenceType.DisplayMember = "Name"
            Me.cboAbsenceType.EditingMode = True
            Me.cboAbsenceType.EndFindValue = Nothing
            Me.cboAbsenceType.FieldDescription = Nothing
            Me.cboAbsenceType.FieldName = Nothing
            Me.cboAbsenceType.FilterRule = Nothing
            Me.cboAbsenceType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAbsenceType.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.cboAbsenceType, True)
            resources.ApplyResources(Me.cboAbsenceType, "cboAbsenceType")
            Me.cboAbsenceType.ForeColor = System.Drawing.Color.Black
            Me.cboAbsenceType.FormattingEnabled = True
            Me.cboAbsenceType.HideWhenNotEditingOrAdding = False
            Me.cboAbsenceType.IgnoreCase = False
            Me.cboAbsenceType.LinkedLabel = Me.lblAbsenceType
            Me.cboAbsenceType.Name = "cboAbsenceType"
            Me.cboAbsenceType.OldValue = 0
            Me.cboAbsenceType.OriginalDataSource = Nothing
            Me.cboAbsenceType.OriginalList = Nothing
            Me.cboAbsenceType.OverrideDropDownStyleList = False
            Me.cboAbsenceType.PreviousSearchTerm = Nothing
            Me.cboAbsenceType.PropertySelector = Nothing
            Me.cboAbsenceType.ReadOnlyCombo = False
            Me.cboAbsenceType.SuggestBoxHeight = 200
            Me.cboAbsenceType.SuggestListOrderRule = Nothing
            Me.cboAbsenceType.TextToSearch = Nothing
            Me.cboAbsenceType.Translatable = False
            Me.cboAbsenceType.ValueIsMandatory = False
            Me.cboAbsenceType.ValueIsNullable = False
            Me.cboAbsenceType.ValueIsNumeric = False
            Me.cboAbsenceType.ValueMember = "IdNo"
            '
            'lblAbsenceReason
            '
            Me.lblAbsenceReason.BackColor = System.Drawing.Color.Transparent
            Me.lblAbsenceReason.DisplayOnly = True
            Me.lblAbsenceReason.EditingMode = False
            resources.ApplyResources(Me.lblAbsenceReason, "lblAbsenceReason")
            Me.lblAbsenceReason.Name = "lblAbsenceReason"
            Me.lblAbsenceReason.Translatable = True
            '
            'txtAbsenceReason
            '
            Me.txtAbsenceReason.BackColor = System.Drawing.Color.White
            Me.txtAbsenceReason.BegFindValue = Nothing
            Me.txtAbsenceReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAbsenceReason.ComputedValue = False
            Me.txtAbsenceReason.CustomFormat = Nothing
            Me.txtAbsenceReason.DataBoundControl = True
            Me.txtAbsenceReason.EditingMode = True
            Me.txtAbsenceReason.EndFindValue = Nothing
            Me.txtAbsenceReason.FieldDescription = Nothing
            Me.txtAbsenceReason.FieldName = Nothing
            Me.txtAbsenceReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAbsenceReason.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtAbsenceReason, True)
            resources.ApplyResources(Me.txtAbsenceReason, "txtAbsenceReason")
            Me.txtAbsenceReason.ForeColor = System.Drawing.Color.Black
            Me.txtAbsenceReason.LinkedLabel = Me.lblAbsenceReason
            Me.txtAbsenceReason.MaximumValue = Nothing
            Me.txtAbsenceReason.MinimumValue = Nothing
            Me.txtAbsenceReason.Name = "txtAbsenceReason"
            Me.txtAbsenceReason.OldValue = Nothing
            Me.txtAbsenceReason.ReadOnly = True
            Me.txtAbsenceReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAbsenceReason.Translatable = False
            Me.txtAbsenceReason.ValueIsMandatory = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDateCreated, True)
            resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'txtAddedByUser
            '
            Me.txtAddedByUser.BackColor = System.Drawing.Color.White
            Me.txtAddedByUser.BegFindValue = Nothing
            Me.txtAddedByUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddedByUser.ComputedValue = False
            Me.txtAddedByUser.CustomFormat = Nothing
            Me.txtAddedByUser.DataBoundControl = True
            Me.txtAddedByUser.EditingMode = True
            Me.txtAddedByUser.EndFindValue = Nothing
            Me.txtAddedByUser.FieldDescription = Nothing
            Me.txtAddedByUser.FieldName = Nothing
            Me.txtAddedByUser.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAddedByUser.FindEnabled = False
            resources.ApplyResources(Me.txtAddedByUser, "txtAddedByUser")
            Me.txtAddedByUser.ForeColor = System.Drawing.Color.Black
            Me.txtAddedByUser.LinkedLabel = Me.lblAddedBy
            Me.txtAddedByUser.MaximumValue = Nothing
            Me.txtAddedByUser.MinimumValue = Nothing
            Me.txtAddedByUser.Name = "txtAddedByUser"
            Me.txtAddedByUser.OldValue = Nothing
            Me.txtAddedByUser.ReadOnly = True
            Me.txtAddedByUser.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAddedByUser.Translatable = False
            Me.txtAddedByUser.ValueIsMandatory = True
            '
            'EmployeeAbsenceEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Name = "EmployeeAbsenceEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Public WithEvents cboEmployeeIdNo As CaComboBox
        Friend WithEvents lblEquivalentHours As CLabel
        Public WithEvents txtEquivalentHours As CTextBox
        Friend WithEvents lblAddedBy As CLabel
        Public WithEvents txtUserName As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblAbsenceType As CLabel
        Public WithEvents cboAbsenceType As CaComboBox
        Friend WithEvents lblAbsenceReason As CLabel
        Public WithEvents txtAbsenceReason As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblPayrollIdNo As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents txtStartDate As CTextBox
        Friend WithEvents lblEndDate As CLabel
        Public WithEvents txtEndDate As CTextBox
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents txtPayrollName As CTextBox
        Public WithEvents txtAddedByUser As CTextBox
    End Class
End Namespace