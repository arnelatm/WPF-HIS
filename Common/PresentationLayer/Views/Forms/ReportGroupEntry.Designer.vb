Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportGroupEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportGroupEntry))
            Me.lblReportGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReportGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReportGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReportGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblReportGroupCode
            '
            Me.lblReportGroupCode.BackColor = System.Drawing.Color.Transparent
            Me.lblReportGroupCode.DisplayOnly = True
            Me.lblReportGroupCode.EditingMode = False
            resources.ApplyResources(Me.lblReportGroupCode, "lblReportGroupCode")
            Me.lblReportGroupCode.Name = "lblReportGroupCode"
            Me.lblReportGroupCode.Translatable = True
            '
            'CFlowLayout4
            '
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.CLabel1)
            Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout4.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout4.Controls.Add(Me.lblReportGroupCode)
            Me.CFlowLayout4.Controls.Add(Me.txtReportGroupCode)
            Me.CFlowLayout4.Controls.Add(Me.lblReportGroupName)
            Me.CFlowLayout4.Controls.Add(Me.txtReportGroupName)
            Me.CFlowLayout4.Controls.Add(Me.lblReportGroupNameAra)
            Me.CFlowLayout4.Controls.Add(Me.txtReportGroupNameAra)
            Me.CFlowLayout4.Name = "CFlowLayout4"
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
            'txtReportGroupCode
            '
            Me.txtReportGroupCode.BackColor = System.Drawing.Color.White
            Me.txtReportGroupCode.BegFindValue = Nothing
            Me.txtReportGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportGroupCode.ComputedValue = False
            Me.txtReportGroupCode.CustomFormat = Nothing
            Me.txtReportGroupCode.DataBoundControl = True
            Me.txtReportGroupCode.EditingMode = True
            Me.txtReportGroupCode.EndFindValue = Nothing
            Me.txtReportGroupCode.FieldDescription = Nothing
            Me.txtReportGroupCode.FieldName = Nothing
            Me.txtReportGroupCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportGroupCode.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtReportGroupCode, True)
            resources.ApplyResources(Me.txtReportGroupCode, "txtReportGroupCode")
            Me.txtReportGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtReportGroupCode.LinkedLabel = Me.lblReportGroupCode
            Me.txtReportGroupCode.MaximumValue = Nothing
            Me.txtReportGroupCode.MinimumValue = Nothing
            Me.txtReportGroupCode.Name = "txtReportGroupCode"
            Me.txtReportGroupCode.OldValue = Nothing
            Me.txtReportGroupCode.OverrideMaxLength = 0
            Me.txtReportGroupCode.ReadOnly = True
            Me.txtReportGroupCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportGroupCode.Translatable = False
            Me.txtReportGroupCode.ValueIsMandatory = True
            '
            'lblReportGroupName
            '
            Me.lblReportGroupName.BackColor = System.Drawing.Color.Transparent
            Me.lblReportGroupName.DisplayOnly = True
            Me.lblReportGroupName.EditingMode = False
            resources.ApplyResources(Me.lblReportGroupName, "lblReportGroupName")
            Me.lblReportGroupName.Name = "lblReportGroupName"
            Me.lblReportGroupName.Translatable = True
            '
            'txtReportGroupName
            '
            Me.txtReportGroupName.BackColor = System.Drawing.Color.White
            Me.txtReportGroupName.BegFindValue = Nothing
            Me.txtReportGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportGroupName.ComputedValue = False
            Me.txtReportGroupName.CustomFormat = Nothing
            Me.txtReportGroupName.DataBoundControl = True
            Me.txtReportGroupName.EditingMode = True
            Me.txtReportGroupName.EndFindValue = Nothing
            Me.txtReportGroupName.FieldDescription = Nothing
            Me.txtReportGroupName.FieldName = Nothing
            Me.txtReportGroupName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportGroupName.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtReportGroupName, True)
            resources.ApplyResources(Me.txtReportGroupName, "txtReportGroupName")
            Me.txtReportGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtReportGroupName.LinkedLabel = Me.lblReportGroupName
            Me.txtReportGroupName.MaximumValue = Nothing
            Me.txtReportGroupName.MinimumValue = Nothing
            Me.txtReportGroupName.Name = "txtReportGroupName"
            Me.txtReportGroupName.OldValue = Nothing
            Me.txtReportGroupName.OverrideMaxLength = 0
            Me.txtReportGroupName.ReadOnly = True
            Me.txtReportGroupName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportGroupName.Translatable = False
            Me.txtReportGroupName.ValueIsMandatory = True
            Me.txtReportGroupName.ValueIsUnique = True
            '
            'lblReportGroupNameAra
            '
            Me.lblReportGroupNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblReportGroupNameAra.DisplayOnly = True
            Me.lblReportGroupNameAra.EditingMode = False
            resources.ApplyResources(Me.lblReportGroupNameAra, "lblReportGroupNameAra")
            Me.lblReportGroupNameAra.Name = "lblReportGroupNameAra"
            Me.lblReportGroupNameAra.Translatable = True
            '
            'txtReportGroupNameAra
            '
            Me.txtReportGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtReportGroupNameAra.BegFindValue = Nothing
            Me.txtReportGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReportGroupNameAra.ComputedValue = False
            Me.txtReportGroupNameAra.CustomFormat = Nothing
            Me.txtReportGroupNameAra.DataBoundControl = True
            Me.txtReportGroupNameAra.EditingMode = True
            Me.txtReportGroupNameAra.EndFindValue = Nothing
            Me.txtReportGroupNameAra.EnglishControl = Me.txtReportGroupName
            Me.txtReportGroupNameAra.FieldDescription = Nothing
            Me.txtReportGroupNameAra.FieldName = Nothing
            Me.txtReportGroupNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReportGroupNameAra.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtReportGroupNameAra, True)
            resources.ApplyResources(Me.txtReportGroupNameAra, "txtReportGroupNameAra")
            Me.txtReportGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtReportGroupNameAra.LinkedLabel = Me.lblReportGroupNameAra
            Me.txtReportGroupNameAra.MaximumValue = Nothing
            Me.txtReportGroupNameAra.MinimumValue = Nothing
            Me.txtReportGroupNameAra.Name = "txtReportGroupNameAra"
            Me.txtReportGroupNameAra.OldValue = Nothing
            Me.txtReportGroupNameAra.OverrideMaxLength = 0
            Me.txtReportGroupNameAra.ReadOnly = True
            Me.txtReportGroupNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReportGroupNameAra.Translatable = False
            Me.txtReportGroupNameAra.ValueIsMandatory = True
            Me.txtReportGroupNameAra.ValueIsUnique = True
            '
            'ReportGroupEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.CFlowLayout4)
            Me.Name = "ReportGroupEntry"
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
        Friend WithEvents lblReportGroupCode As CLabel
        Friend WithEvents lblReportGroupName As CLabel
        Friend WithEvents lblReportGroupNameAra As CLabel
        Friend WithEvents dgvUnitIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvUnitQty As DataGridViewTextBoxColumn
        Friend WithEvents BaseQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvReportGroupIdNo As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtReportGroupCode As CTextBox
        Friend WithEvents txtReportGroupName As CTextBox
        Friend WithEvents txtReportGroupNameAra As CTextBoxArabic
    End Class
End NameSpace