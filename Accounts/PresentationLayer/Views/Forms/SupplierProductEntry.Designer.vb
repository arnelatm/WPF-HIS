Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SupplierProductEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupplierProductEntry))
            Me.txtSupplierProductCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSupplierProductCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProductIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboProductIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblSupplierProductName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSupplierProductName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSupplierProductNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSupplierProductNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSupplierProductCode
            '
            Me.txtSupplierProductCode.BackColor = System.Drawing.Color.White
            Me.txtSupplierProductCode.BegFindValue = Nothing
            Me.txtSupplierProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierProductCode.ComputedValue = False
            Me.txtSupplierProductCode.CustomFormat = Nothing
            Me.txtSupplierProductCode.DataBoundControl = True
            Me.txtSupplierProductCode.EditingMode = True
            Me.txtSupplierProductCode.EndFindValue = Nothing
            Me.txtSupplierProductCode.FieldDescription = Nothing
            Me.txtSupplierProductCode.FieldName = Nothing
            Me.txtSupplierProductCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierProductCode.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtSupplierProductCode, True)
            resources.ApplyResources(Me.txtSupplierProductCode, "txtSupplierProductCode")
            Me.txtSupplierProductCode.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierProductCode.LinkedLabel = Me.lblSupplierProductCode
            Me.txtSupplierProductCode.MaximumValue = Nothing
            Me.txtSupplierProductCode.MinimumValue = Nothing
            Me.txtSupplierProductCode.Name = "txtSupplierProductCode"
            Me.txtSupplierProductCode.OldValue = Nothing
            Me.txtSupplierProductCode.OverrideMaxLength = 0
            Me.txtSupplierProductCode.ReadOnly = True
            Me.txtSupplierProductCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierProductCode.Translatable = False
            Me.txtSupplierProductCode.ValueIsMandatory = True
            '
            'lblSupplierProductCode
            '
            Me.lblSupplierProductCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierProductCode.DisplayOnly = True
            Me.lblSupplierProductCode.EditingMode = False
            resources.ApplyResources(Me.lblSupplierProductCode, "lblSupplierProductCode")
            Me.lblSupplierProductCode.Name = "lblSupplierProductCode"
            Me.lblSupplierProductCode.Translatable = True
            '
            'CFlowLayout4
            '
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.CLabel1)
            Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout4.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblProductIdNo)
            Me.CFlowLayout4.Controls.Add(Me.cboProductIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblSupplierIdNo)
            Me.CFlowLayout4.Controls.Add(Me.cboSupplierIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblSupplierProductCode)
            Me.CFlowLayout4.Controls.Add(Me.txtSupplierProductCode)
            Me.CFlowLayout4.Controls.Add(Me.lblSupplierProductName)
            Me.CFlowLayout4.Controls.Add(Me.txtSupplierProductName)
            Me.CFlowLayout4.Controls.Add(Me.lblSupplierProductNameAra)
            Me.CFlowLayout4.Controls.Add(Me.txtSupplierProductNameAra)
            Me.CFlowLayout4.Name = "CFlowLayout4"
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
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblProductIdNo
            '
            Me.lblProductIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblProductIdNo.DisplayOnly = True
            Me.lblProductIdNo.EditingMode = False
            resources.ApplyResources(Me.lblProductIdNo, "lblProductIdNo")
            Me.lblProductIdNo.Name = "lblProductIdNo"
            Me.lblProductIdNo.Translatable = True
            '
            'cboProductIdNo
            '
            Me.cboProductIdNo.BackColor = System.Drawing.Color.White
            Me.cboProductIdNo.BegFindValue = Nothing
            Me.cboProductIdNo.ChangingSearchValueOnly = False
            Me.cboProductIdNo.CurrentSearchTerm = ""
            Me.cboProductIdNo.DataValue = Nothing
            Me.cboProductIdNo.DefaultValue = ""
            Me.cboProductIdNo.DisplayMember = "Name"
            Me.cboProductIdNo.Editable = True
            Me.cboProductIdNo.EditingMode = True
            Me.cboProductIdNo.EndFindValue = Nothing
            Me.cboProductIdNo.FieldDescription = Nothing
            Me.cboProductIdNo.FieldName = Nothing
            Me.cboProductIdNo.FilterRule = Nothing
            Me.cboProductIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboProductIdNo.FindEnabled = False
            Me.CFlowLayout4.SetFlowBreak(Me.cboProductIdNo, True)
            resources.ApplyResources(Me.cboProductIdNo, "cboProductIdNo")
            Me.cboProductIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboProductIdNo.HideWhenNotEditingOrAdding = False
            Me.cboProductIdNo.IgnoreCase = False
            Me.cboProductIdNo.LimitToList = False
            Me.cboProductIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboProductIdNo.Name = "cboProductIdNo"
            Me.cboProductIdNo.OldValue = 0
            Me.cboProductIdNo.OriginalDataSource = Nothing
            Me.cboProductIdNo.OriginalList = Nothing
            Me.cboProductIdNo.OverrideDropDownStyleList = False
            Me.cboProductIdNo.PreviousSearchTerm = Nothing
            Me.cboProductIdNo.PropertySelector = Nothing
            Me.cboProductIdNo.SuggestBoxHeight = 200
            Me.cboProductIdNo.SuggestCharCount = 3
            Me.cboProductIdNo.SuggestListOrderRule = Nothing
            Me.cboProductIdNo.TextToSearch = Nothing
            Me.cboProductIdNo.Translatable = False
            Me.cboProductIdNo.ValueIsMandatory = False
            Me.cboProductIdNo.ValueIsNullable = False
            Me.cboProductIdNo.ValueIsNumeric = False
            Me.cboProductIdNo.ValueMember = "IdNo"
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            resources.ApplyResources(Me.lblSupplierIdNo, "lblSupplierIdNo")
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Translatable = True
            '
            'cboSupplierIdNo
            '
            Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
            Me.cboSupplierIdNo.BegFindValue = Nothing
            Me.cboSupplierIdNo.ChangingSearchValueOnly = False
            Me.cboSupplierIdNo.CurrentSearchTerm = ""
            Me.cboSupplierIdNo.DataValue = Nothing
            Me.cboSupplierIdNo.DefaultValue = ""
            Me.cboSupplierIdNo.DisplayMember = "Name"
            Me.cboSupplierIdNo.Editable = True
            Me.cboSupplierIdNo.EditingMode = True
            Me.cboSupplierIdNo.EndFindValue = Nothing
            Me.cboSupplierIdNo.FieldDescription = Nothing
            Me.cboSupplierIdNo.FieldName = Nothing
            Me.cboSupplierIdNo.FilterRule = Nothing
            Me.cboSupplierIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSupplierIdNo.FindEnabled = False
            Me.CFlowLayout4.SetFlowBreak(Me.cboSupplierIdNo, True)
            resources.ApplyResources(Me.cboSupplierIdNo, "cboSupplierIdNo")
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IgnoreCase = False
            Me.cboSupplierIdNo.LimitToList = False
            Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestCharCount = 1
            Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.Translatable = False
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'lblSupplierProductName
            '
            Me.lblSupplierProductName.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierProductName.DisplayOnly = True
            Me.lblSupplierProductName.EditingMode = False
            resources.ApplyResources(Me.lblSupplierProductName, "lblSupplierProductName")
            Me.lblSupplierProductName.Name = "lblSupplierProductName"
            Me.lblSupplierProductName.Translatable = True
            '
            'txtSupplierProductName
            '
            Me.txtSupplierProductName.BackColor = System.Drawing.Color.White
            Me.txtSupplierProductName.BegFindValue = Nothing
            Me.txtSupplierProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierProductName.ComputedValue = False
            Me.txtSupplierProductName.CustomFormat = Nothing
            Me.txtSupplierProductName.DataBoundControl = True
            Me.txtSupplierProductName.EditingMode = True
            Me.txtSupplierProductName.EndFindValue = Nothing
            Me.txtSupplierProductName.FieldDescription = Nothing
            Me.txtSupplierProductName.FieldName = Nothing
            Me.txtSupplierProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierProductName.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtSupplierProductName, True)
            resources.ApplyResources(Me.txtSupplierProductName, "txtSupplierProductName")
            Me.txtSupplierProductName.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierProductName.LinkedLabel = Me.lblSupplierProductName
            Me.txtSupplierProductName.MaximumValue = Nothing
            Me.txtSupplierProductName.MinimumValue = Nothing
            Me.txtSupplierProductName.Name = "txtSupplierProductName"
            Me.txtSupplierProductName.OldValue = Nothing
            Me.txtSupplierProductName.OverrideMaxLength = 0
            Me.txtSupplierProductName.ReadOnly = True
            Me.txtSupplierProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierProductName.Translatable = False
            Me.txtSupplierProductName.ValueIsMandatory = True
            Me.txtSupplierProductName.ValueIsUnique = True
            '
            'lblSupplierProductNameAra
            '
            Me.lblSupplierProductNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierProductNameAra.DisplayOnly = True
            Me.lblSupplierProductNameAra.EditingMode = False
            resources.ApplyResources(Me.lblSupplierProductNameAra, "lblSupplierProductNameAra")
            Me.lblSupplierProductNameAra.Name = "lblSupplierProductNameAra"
            Me.lblSupplierProductNameAra.Translatable = True
            '
            'txtSupplierProductNameAra
            '
            Me.txtSupplierProductNameAra.BackColor = System.Drawing.Color.White
            Me.txtSupplierProductNameAra.BegFindValue = Nothing
            Me.txtSupplierProductNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSupplierProductNameAra.ComputedValue = False
            Me.txtSupplierProductNameAra.CustomFormat = Nothing
            Me.txtSupplierProductNameAra.DataBoundControl = True
            Me.txtSupplierProductNameAra.EditingMode = True
            Me.txtSupplierProductNameAra.EndFindValue = Nothing
            Me.txtSupplierProductNameAra.EnglishControl = Me.txtSupplierProductName
            Me.txtSupplierProductNameAra.FieldDescription = Nothing
            Me.txtSupplierProductNameAra.FieldName = Nothing
            Me.txtSupplierProductNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSupplierProductNameAra.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtSupplierProductNameAra, True)
            resources.ApplyResources(Me.txtSupplierProductNameAra, "txtSupplierProductNameAra")
            Me.txtSupplierProductNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtSupplierProductNameAra.LinkedLabel = Me.lblSupplierProductNameAra
            Me.txtSupplierProductNameAra.MaximumValue = Nothing
            Me.txtSupplierProductNameAra.MinimumValue = Nothing
            Me.txtSupplierProductNameAra.Name = "txtSupplierProductNameAra"
            Me.txtSupplierProductNameAra.OldValue = Nothing
            Me.txtSupplierProductNameAra.OverrideMaxLength = 0
            Me.txtSupplierProductNameAra.ReadOnly = True
            Me.txtSupplierProductNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSupplierProductNameAra.Translatable = False
            Me.txtSupplierProductNameAra.ValueIsMandatory = True
            Me.txtSupplierProductNameAra.ValueIsUnique = True
            '
            'CLabel1
            '
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CFlowLayout4.SetFlowBreak(Me.CLabel1, True)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'SupplierProductEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CFlowLayout4)
            Me.Name = "SupplierProductEntry"
            Me.Controls.SetChildIndex(Me.CFlowLayout4, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblSupplierProductCode As CLabel
        Friend WithEvents txtSupplierProductCode As CTextBox
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents cboProductIdNo As CtComboBox
        Friend WithEvents lblSupplierProductName As CLabel
        Friend WithEvents txtSupplierProductName As CTextBox
        Friend WithEvents lblSupplierProductNameAra As CLabel
        Friend WithEvents txtSupplierProductNameAra As CTextBoxArabic
        Friend WithEvents lblProductIdNo As CLabel
        Friend WithEvents cboSupplierIdNo As CtComboBox
        Friend WithEvents dgvUnitIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvUnitQty As DataGridViewTextBoxColumn
        Friend WithEvents BaseQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSupplierProductIdNo As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel1 As CLabel
    End Class
End NameSpace