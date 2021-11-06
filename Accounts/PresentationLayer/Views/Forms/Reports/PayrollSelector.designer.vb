Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PayrollSelector
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollSelector))
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CCustomDateTimePicker1 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.DisplayOnly = true
        Me.lblBeginningDate.EditingMode = false
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(11, 11)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(112, 25)
        Me.lblBeginningDate.TabIndex = 20
        Me.lblBeginningDate.Text = "Ending Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBeginningDate.Translatable = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.CCustomDateTimePicker1)
        Me.CFlowLayout1.Controls.Add(Me.CLabel3)
        Me.CFlowLayout1.Controls.Add(Me.CTextBox1)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout1.Size = New System.Drawing.Size(362, 156)
        Me.CFlowLayout1.TabIndex = 26
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CLabel2.Location = New System.Drawing.Point(0, 0)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(321, 25)
        Me.CLabel2.TabIndex = 26
        Me.CLabel2.Text = "Summary of Accounts Payable"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel2.Translatable = true
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
        Me.CLabel1.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(200, 231)
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
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(306, 231)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(11, 38)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(112, 25)
        Me.CLabel3.TabIndex = 21
        Me.CLabel3.Text = "Ending Date :"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = false
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(125, 38)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox1.TabIndex = 22
        Me.CTextBox1.Translatable = false
        '
        'CCustomDateTimePicker1
        '
        Me.CCustomDateTimePicker1.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.CCustomDateTimePicker1.DefaultValue = Nothing
        Me.CCustomDateTimePicker1.DisplayOnly = false
        Me.CCustomDateTimePicker1.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker1.EditingMode = true
        Me.CCustomDateTimePicker1.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.CCustomDateTimePicker1, true)
        Me.CCustomDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker1.LinkedLabel = Nothing
        Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(125, 11)
        Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
        Me.CCustomDateTimePicker1.ReadOnlyDp = false
        Me.CCustomDateTimePicker1.SecurityKey = Nothing
        Me.CCustomDateTimePicker1.ShowLongDate = false
        Me.CCustomDateTimePicker1.ShowTime = false
        Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(113, 23)
        Me.CCustomDateTimePicker1.TabIndex = 23
        Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker1.Translatable = false
        Me.CCustomDateTimePicker1.Value = Nothing
        Me.CCustomDateTimePicker1.ValueIsMandatory = false
        Me.CCustomDateTimePicker1.ValueIsNullable = false
        '
        'PayrollSelector
        '
        Me.ClientSize = New System.Drawing.Size(660, 278)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "PayrollSelector"
        Me.Text = "Summary of A.P."
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CCustomDateTimePicker1 As CCustomDateTimePicker
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents CTextBox1 As CTextBox
    End Class
End NameSpace