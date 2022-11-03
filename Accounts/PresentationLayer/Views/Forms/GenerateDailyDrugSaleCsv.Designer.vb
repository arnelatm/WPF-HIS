Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GenerateDailyDrugSaleCsv
        Inherits AATM.PresentationLayer.Forms.CFormEntry

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerateDailyDrugSaleCsv))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpSaleDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpSaleDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 57)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(502, 50)
            Me.CFlowLayout1.TabIndex = 4
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(1, 1)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(184, 24)
            Me.lblEndDate.TabIndex = 5
            Me.lblEndDate.Text = "Date of Sales to Generate"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
            '
            'dtpSaleDate
            '
            Me.dtpSaleDate.AutoSize = True
            Me.dtpSaleDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpSaleDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpSaleDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpSaleDate.DefaultValue = Nothing
            Me.dtpSaleDate.DisplayOnly = False
            Me.dtpSaleDate.DtpDefaultValue = Nothing
            Me.dtpSaleDate.EditingMode = True
            Me.dtpSaleDate.EditsAllowed = False
            Me.dtpSaleDate.ForeColor = System.Drawing.Color.Black
            Me.dtpSaleDate.LinkedLabel = Nothing
            Me.dtpSaleDate.Location = New System.Drawing.Point(187, 1)
            Me.dtpSaleDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpSaleDate.Name = "dtpSaleDate"
            Me.dtpSaleDate.ReadOnlyDp = False
            Me.dtpSaleDate.SecurityKey = Nothing
            Me.dtpSaleDate.ShowLongDate = False
            Me.dtpSaleDate.ShowTime = False
            Me.dtpSaleDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpSaleDate.TabIndex = 12
            Me.dtpSaleDate.TargetCalendar = CType(resources.GetObject("dtpSaleDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpSaleDate.Translatable = False
            Me.dtpSaleDate.Value = Nothing
            Me.dtpSaleDate.ValueIsMandatory = False
            Me.dtpSaleDate.ValueIsNullable = False
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(146, 113)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 8
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(242, 113)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            '
            'GenerateDailyDrugSaleCsv
            '
            Me.AcceptButton = Me.btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(517, 153)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Name = "GenerateDailyDrugSaleCsv"
            Me.Text = "Generate Payroll CSV File"
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            Me.Controls.SetChildIndex(Me.btnCancel, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents dtpSaleDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    End Class
End NameSpace