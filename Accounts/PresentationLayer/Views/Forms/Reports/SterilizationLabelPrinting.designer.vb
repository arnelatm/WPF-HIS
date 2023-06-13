Imports AATM.Common.PresentationLayer.Views.Forms.Reports
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SterilizationLabelPrinter
        Inherits BfMain

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SterilizationLabelPrinter))
            Me.lblExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblProductionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpExpiryDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.dtpProductionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtCopies = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblExpiryDate
            '
            Me.lblExpiryDate.DisplayOnly = True
            Me.lblExpiryDate.EditingMode = False
            Me.lblExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblExpiryDate.Location = New System.Drawing.Point(11, 38)
            Me.lblExpiryDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblExpiryDate.Name = "lblExpiryDate"
            Me.lblExpiryDate.Size = New System.Drawing.Size(171, 25)
            Me.lblExpiryDate.TabIndex = 21
            Me.lblExpiryDate.Text = "Expiry Date:"
            Me.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblExpiryDate.Translatable = True
            '
            'lblProductionDate
            '
            Me.lblProductionDate.DisplayOnly = True
            Me.lblProductionDate.EditingMode = False
            Me.lblProductionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblProductionDate.Location = New System.Drawing.Point(11, 11)
            Me.lblProductionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProductionDate.Name = "lblProductionDate"
            Me.lblProductionDate.Size = New System.Drawing.Size(171, 25)
            Me.lblProductionDate.TabIndex = 20
            Me.lblProductionDate.Text = "Production Date :"
            Me.lblProductionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblProductionDate.Translatable = True
            '
            'dtpExpiryDate
            '
            Me.dtpExpiryDate.AutoSize = True
            Me.dtpExpiryDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpExpiryDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpExpiryDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpExpiryDate.DefaultValue = Nothing
            Me.dtpExpiryDate.DisplayOnly = False
            Me.dtpExpiryDate.DtpDefaultValue = Nothing
            Me.dtpExpiryDate.EditingMode = True
            Me.dtpExpiryDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpExpiryDate, True)
            Me.dtpExpiryDate.ForeColor = System.Drawing.Color.Black
            Me.dtpExpiryDate.LinkedLabel = Nothing
            Me.dtpExpiryDate.Location = New System.Drawing.Point(184, 38)
            Me.dtpExpiryDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpExpiryDate.Name = "dtpExpiryDate"
            Me.dtpExpiryDate.ReadOnlyDp = False
            Me.dtpExpiryDate.SecurityKey = Nothing
            Me.dtpExpiryDate.ShowLongDate = False
            Me.dtpExpiryDate.ShowTime = False
            Me.dtpExpiryDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpExpiryDate.TabIndex = 24
            Me.dtpExpiryDate.TargetCalendar = CType(resources.GetObject("dtpExpiryDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpExpiryDate.Translatable = False
            Me.dtpExpiryDate.Value = Nothing
            Me.dtpExpiryDate.ValueIsMandatory = False
            Me.dtpExpiryDate.ValueIsNullable = False
            '
            'dtpProductionDate
            '
            Me.dtpProductionDate.AutoSize = True
            Me.dtpProductionDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpProductionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpProductionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpProductionDate.DefaultValue = Nothing
            Me.dtpProductionDate.DisplayOnly = False
            Me.dtpProductionDate.DtpDefaultValue = Nothing
            Me.dtpProductionDate.EditingMode = True
            Me.dtpProductionDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpProductionDate, True)
            Me.dtpProductionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpProductionDate.LinkedLabel = Nothing
            Me.dtpProductionDate.Location = New System.Drawing.Point(184, 11)
            Me.dtpProductionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpProductionDate.Name = "dtpProductionDate"
            Me.dtpProductionDate.ReadOnlyDp = False
            Me.dtpProductionDate.SecurityKey = Nothing
            Me.dtpProductionDate.ShowLongDate = False
            Me.dtpProductionDate.ShowTime = False
            Me.dtpProductionDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpProductionDate.TabIndex = 23
            Me.dtpProductionDate.TargetCalendar = CType(resources.GetObject("dtpProductionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpProductionDate.Translatable = False
            Me.dtpProductionDate.Value = Nothing
            Me.dtpProductionDate.ValueIsMandatory = False
            Me.dtpProductionDate.ValueIsNullable = False
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblProductionDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpProductionDate)
            Me.CFlowLayout1.Controls.Add(Me.lblExpiryDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpExpiryDate)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.txtCopies)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(318, 102)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(0, 0)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(330, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Sterilization Label Printing"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
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
            Me.CLabel1.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(59, 145)
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
            Me.btnCancel.Location = New System.Drawing.Point(165, 145)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'txtCopies
            '
            Me.txtCopies.BackColor = System.Drawing.SystemColors.ControlLight
            Me.txtCopies.BegFindValue = Nothing
            Me.txtCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCopies.ComputedValue = False
            Me.txtCopies.CustomFormat = Nothing
            Me.txtCopies.DataBoundControl = True
            Me.txtCopies.EditingMode = True
            Me.txtCopies.EndFindValue = Nothing
            Me.txtCopies.FieldDescription = Nothing
            Me.txtCopies.FieldName = Nothing
            Me.txtCopies.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCopies.FindEnabled = False
            Me.txtCopies.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCopies.LinkedLabel = Nothing
            Me.txtCopies.Location = New System.Drawing.Point(184, 65)
            Me.txtCopies.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCopies.MaximumValue = Nothing
            Me.txtCopies.MinimumValue = Nothing
            Me.txtCopies.Name = "txtCopies"
            Me.txtCopies.OldValue = Nothing
            Me.txtCopies.OverrideMaxLength = 0
            Me.txtCopies.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCopies.Size = New System.Drawing.Size(100, 23)
            Me.txtCopies.TabIndex = 25
            Me.txtCopies.Translatable = False
            Me.txtCopies.ValueIsNumeric = True
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(11, 65)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(171, 25)
            Me.CLabel3.TabIndex = 26
            Me.CLabel3.Text = "Copies"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'SterilizationLabelPrinter
            '
            Me.ClientSize = New System.Drawing.Size(332, 182)
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "SterilizationLabelPrinter"
            Me.Text = "Sterilization Label Printing"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblExpiryDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblProductionDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpExpiryDate As CCustomDateTimePicker
        Friend WithEvents dtpProductionDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents txtCopies As CTextBox
    End Class
End Namespace