Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class HolidayEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HolidayEntry))
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpHolidayDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtHolidayName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblHolidayNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtHolidayNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
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
        Me.CFlowLayout2.SetFlowBreak(Me.TxtIdNo, true)
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
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout2.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout2.Controls.Add(Me.lblNote)
        Me.CFlowLayout2.Controls.Add(Me.txtHolidayName)
        Me.CFlowLayout2.Controls.Add(Me.lblHolidayNameAra)
        Me.CFlowLayout2.Controls.Add(Me.txtHolidayNameAra)
        Me.CFlowLayout2.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout2.Controls.Add(Me.dtpHolidayDate)
        Me.CFlowLayout2.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        resources.ApplyResources(Me.CFlowLayout2, "CFlowLayout2")
        Me.CFlowLayout2.Name = "CFlowLayout2"
        '
        'lblNote
        '
        Me.lblNote.BackColor = System.Drawing.Color.Transparent
        Me.lblNote.DisplayOnly = true
        Me.lblNote.EditingMode = false
        resources.ApplyResources(Me.lblNote, "lblNote")
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Translatable = true
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Translatable = true
        '
        'dtpHolidayDate
        '
        Me.dtpHolidayDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpHolidayDate.DefaultValue = Nothing
        Me.dtpHolidayDate.DisplayOnly = false
        Me.dtpHolidayDate.DtpDefaultValue = Nothing
        Me.dtpHolidayDate.EditingMode = true
        Me.dtpHolidayDate.EditsAllowed = false
        Me.CFlowLayout2.SetFlowBreak(Me.dtpHolidayDate, true)
        Me.dtpHolidayDate.ForeColor = System.Drawing.Color.Black
        Me.dtpHolidayDate.LinkedLabel = Me.lblStartDate
        resources.ApplyResources(Me.dtpHolidayDate, "dtpHolidayDate")
        Me.dtpHolidayDate.Name = "dtpHolidayDate"
        Me.dtpHolidayDate.ReadOnlyDp = false
        Me.dtpHolidayDate.SecurityKey = Nothing
        Me.dtpHolidayDate.ShowLongDate = false
        Me.dtpHolidayDate.ShowTime = false
        Me.dtpHolidayDate.TargetCalendar = Nothing
        Me.dtpHolidayDate.Translatable = false
        Me.dtpHolidayDate.Value = Nothing
        Me.dtpHolidayDate.ValueIsMandatory = false
        Me.dtpHolidayDate.ValueIsNullable = false
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
        Me.txtDateCreated.LinkedLabel = Nothing
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'txtHolidayName
        '
        Me.txtHolidayName.BackColor = System.Drawing.Color.White
        Me.txtHolidayName.BegFindValue = Nothing
        Me.txtHolidayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHolidayName.ComputedValue = false
        Me.txtHolidayName.CustomFormat = Nothing
        Me.txtHolidayName.DataBoundControl = true
        Me.txtHolidayName.EditingMode = false
        Me.txtHolidayName.EndFindValue = Nothing
        Me.txtHolidayName.FieldDescription = Nothing
        Me.txtHolidayName.FieldName = Nothing
        Me.txtHolidayName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtHolidayName.FindEnabled = true
        resources.ApplyResources(Me.txtHolidayName, "txtHolidayName")
        Me.txtHolidayName.ForeColor = System.Drawing.Color.Black
        Me.txtHolidayName.MaximumValue = Nothing
        Me.txtHolidayName.MinimumValue = Nothing
        Me.txtHolidayName.Name = "txtHolidayName"
        Me.txtHolidayName.OldValue = Nothing
        Me.txtHolidayName.ReadOnly = true
        Me.txtHolidayName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtHolidayName.Translatable = false
        Me.txtHolidayName.ValueIsMandatory = true
        Me.txtHolidayName.ValueIsUnique = true
        '
        'lblHolidayNameAra
        '
        Me.lblHolidayNameAra.DisplayOnly = true
        Me.lblHolidayNameAra.EditingMode = false
        resources.ApplyResources(Me.lblHolidayNameAra, "lblHolidayNameAra")
        Me.lblHolidayNameAra.Name = "lblHolidayNameAra"
        Me.lblHolidayNameAra.Translatable = true
        '
        'txtHolidayNameAra
        '
        Me.txtHolidayNameAra.BackColor = System.Drawing.Color.White
        Me.txtHolidayNameAra.BegFindValue = Nothing
        Me.txtHolidayNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHolidayNameAra.ComputedValue = false
        Me.txtHolidayNameAra.CustomFormat = Nothing
        Me.txtHolidayNameAra.DataBoundControl = true
        Me.txtHolidayNameAra.EditingMode = false
        Me.txtHolidayNameAra.EndFindValue = Nothing
        Me.txtHolidayNameAra.EnglishControl = Me.txtHolidayName
        Me.txtHolidayNameAra.FieldDescription = Nothing
        Me.txtHolidayNameAra.FieldName = Nothing
        Me.txtHolidayNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtHolidayNameAra.FindEnabled = true
        resources.ApplyResources(Me.txtHolidayNameAra, "txtHolidayNameAra")
        Me.txtHolidayNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtHolidayNameAra.LinkedLabel = Me.lblHolidayNameAra
        Me.txtHolidayNameAra.MaximumValue = Nothing
        Me.txtHolidayNameAra.MinimumValue = Nothing
        Me.txtHolidayNameAra.Name = "txtHolidayNameAra"
        Me.txtHolidayNameAra.OldValue = Nothing
        Me.txtHolidayNameAra.ReadOnly = true
        Me.txtHolidayNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtHolidayNameAra.Translatable = false
        Me.txtHolidayNameAra.ValueIsUnique = true
        '
        'HolidayEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Controls.Add(Me.CFlowLayout2)
        Me.Name = "HolidayEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblIdNo As CLabel
        Public WithEvents TxtIdNo As CTextBox
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblNote As CLabel
        Public WithEvents txtDateCreated As CTextBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblStartDate As CLabel
        Public WithEvents dtpHolidayDate As CCustomDateTimePicker
        Friend WithEvents txtHolidayName As CTextBox
        Friend WithEvents lblHolidayNameAra As CLabel
        Friend WithEvents txtHolidayNameAra As CTextBoxArabic
    End Class
End Namespace