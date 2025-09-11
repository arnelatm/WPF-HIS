Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DoctorEntryTv
        Inherits CFormEntryTv

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoctorEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDoctorName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblDoctorNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSpecialtyIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.FormTreeView, "FormTreeView")
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
            Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
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
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
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
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
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
            Me.txtDoctorCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDoctorCode, True)
            resources.ApplyResources(Me.txtDoctorCode, "txtDoctorCode")
            Me.txtDoctorCode.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorCode.LinkedLabel = Me.lblDoctorCode
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.ReadOnly = True
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.ValueIsMandatory = True
            Me.txtDoctorCode.ValueIsUnique = True
            '
            'lblDoctorCode
            '
            Me.lblDoctorCode.DisplayOnly = True
            Me.lblDoctorCode.EditingMode = False
            resources.ApplyResources(Me.lblDoctorCode, "lblDoctorCode")
            Me.lblDoctorCode.Name = "lblDoctorCode"
            Me.lblDoctorCode.Translatable = True
            '
            'txtDoctorName
            '
            Me.txtDoctorName.BackColor = System.Drawing.Color.White
            Me.txtDoctorName.BegFindValue = Nothing
            Me.txtDoctorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorName.ComputedValue = False
            Me.txtDoctorName.CustomFormat = Nothing
            Me.txtDoctorName.DataBoundControl = True
            Me.txtDoctorName.DisplayOnly = True
            Me.txtDoctorName.EditingMode = False
            Me.txtDoctorName.EndFindValue = Nothing
            Me.txtDoctorName.FieldDescription = Nothing
            Me.txtDoctorName.FieldName = Nothing
            Me.txtDoctorName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDoctorName, True)
            resources.ApplyResources(Me.txtDoctorName, "txtDoctorName")
            Me.txtDoctorName.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorName.LinkedLabel = Me.lblDoctorName
            Me.txtDoctorName.MaximumValue = Nothing
            Me.txtDoctorName.MinimumValue = Nothing
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.OldValue = Nothing
            Me.txtDoctorName.ReadOnly = True
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Translatable = False
            Me.txtDoctorName.ValueIsMandatory = True
            Me.txtDoctorName.ValueIsUnique = True
            '
            'lblDoctorName
            '
            Me.lblDoctorName.DisplayOnly = True
            Me.lblDoctorName.EditingMode = False
            resources.ApplyResources(Me.lblDoctorName, "lblDoctorName")
            Me.lblDoctorName.Name = "lblDoctorName"
            Me.lblDoctorName.Translatable = True
            '
            'txtDoctorNameAra
            '
            Me.txtDoctorNameAra.BackColor = System.Drawing.Color.White
            Me.txtDoctorNameAra.BegFindValue = Nothing
            Me.txtDoctorNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorNameAra.ComputedValue = False
            Me.txtDoctorNameAra.CustomFormat = Nothing
            Me.txtDoctorNameAra.DataBoundControl = True
            Me.txtDoctorNameAra.DisplayOnly = True
            Me.txtDoctorNameAra.EditingMode = False
            Me.txtDoctorNameAra.EndFindValue = Nothing
            Me.txtDoctorNameAra.EnglishControl = Me.txtDoctorName
            Me.txtDoctorNameAra.FieldDescription = Nothing
            Me.txtDoctorNameAra.FieldName = Nothing
            Me.txtDoctorNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtDoctorNameAra, True)
            resources.ApplyResources(Me.txtDoctorNameAra, "txtDoctorNameAra")
            Me.txtDoctorNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorNameAra.LinkedLabel = Me.lblDoctorNameAra
            Me.txtDoctorNameAra.MaximumValue = Nothing
            Me.txtDoctorNameAra.MinimumValue = Nothing
            Me.txtDoctorNameAra.Name = "txtDoctorNameAra"
            Me.txtDoctorNameAra.OldValue = Nothing
            Me.txtDoctorNameAra.ReadOnly = True
            Me.txtDoctorNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorNameAra.Translatable = False
            Me.txtDoctorNameAra.ValueIsUnique = True
            '
            'lblDoctorNameAra
            '
            Me.lblDoctorNameAra.DisplayOnly = True
            Me.lblDoctorNameAra.EditingMode = False
            resources.ApplyResources(Me.lblDoctorNameAra, "lblDoctorNameAra")
            Me.lblDoctorNameAra.Name = "lblDoctorNameAra"
            Me.lblDoctorNameAra.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.floDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblDoctorCode)
            Me.floDataDisplay.Controls.Add(Me.txtDoctorCode)
            Me.floDataDisplay.Controls.Add(Me.CLabel1)
            Me.floDataDisplay.Controls.Add(Me.cboEmployeeIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblDoctorName)
            Me.floDataDisplay.Controls.Add(Me.txtDoctorName)
            Me.floDataDisplay.Controls.Add(Me.lblDoctorNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtDoctorNameAra)
            Me.floDataDisplay.Controls.Add(Me.CLabel2)
            Me.floDataDisplay.Controls.Add(Me.cboSpecialtyIdNo)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DataValue = Nothing
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboEmployeeIdNo, True)
            resources.ApplyResources(Me.cboEmployeeIdNo, "cboEmployeeIdNo")
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.LinkedLabel = Nothing
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Translatable = True
            '
            'cboSpecialtyIdNo
            '
            Me.cboSpecialtyIdNo.BackColor = System.Drawing.Color.White
            Me.cboSpecialtyIdNo.BegFindValue = Nothing
            Me.cboSpecialtyIdNo.ChangingSearchValueOnly = False
            Me.cboSpecialtyIdNo.CurrentSearchTerm = ""
            Me.cboSpecialtyIdNo.DataValue = Nothing
            Me.cboSpecialtyIdNo.DefaultValue = Nothing
            Me.cboSpecialtyIdNo.DisplayMember = "Name"
            Me.cboSpecialtyIdNo.EditingMode = True
            Me.cboSpecialtyIdNo.EndFindValue = Nothing
            Me.cboSpecialtyIdNo.FieldDescription = Nothing
            Me.cboSpecialtyIdNo.FieldName = Nothing
            Me.cboSpecialtyIdNo.FilterRule = Nothing
            Me.cboSpecialtyIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSpecialtyIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cboSpecialtyIdNo, True)
            resources.ApplyResources(Me.cboSpecialtyIdNo, "cboSpecialtyIdNo")
            Me.cboSpecialtyIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSpecialtyIdNo.FormattingEnabled = True
            Me.cboSpecialtyIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSpecialtyIdNo.IgnoreCase = False
            Me.cboSpecialtyIdNo.LinkedLabel = Nothing
            Me.cboSpecialtyIdNo.Name = "cboSpecialtyIdNo"
            Me.cboSpecialtyIdNo.OldValue = 0
            Me.cboSpecialtyIdNo.OriginalDataSource = Nothing
            Me.cboSpecialtyIdNo.OriginalList = Nothing
            Me.cboSpecialtyIdNo.OverrideDropDownStyleList = False
            Me.cboSpecialtyIdNo.PreviousSearchTerm = Nothing
            Me.cboSpecialtyIdNo.PropertySelector = Nothing
            Me.cboSpecialtyIdNo.SuggestBoxHeight = 200
            Me.cboSpecialtyIdNo.SuggestListOrderRule = Nothing
            Me.cboSpecialtyIdNo.TextToSearch = Nothing
            Me.cboSpecialtyIdNo.Translatable = False
            Me.cboSpecialtyIdNo.ValueIsMandatory = False
            Me.cboSpecialtyIdNo.ValueIsNullable = False
            Me.cboSpecialtyIdNo.ValueIsNumeric = False
            Me.cboSpecialtyIdNo.ValueMember = "IdNo"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'DoctorEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "DoctorEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtDoctorCode As CTextBox
        Friend WithEvents txtDoctorName As CTextBox
        Friend WithEvents txtDoctorNameAra As CTextBoxArabic
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblDoctorCode As CLabel
        Friend WithEvents lblDoctorName As CLabel
        Friend WithEvents lblDoctorNameAra As CLabel
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cboEmployeeIdNo As CtCombobox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents cboSpecialtyIdNo As CtCombobox
    End Class
End Namespace