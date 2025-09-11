Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FormDataViewer
        Inherits CFormBase

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDataViewer))
        Me.CtDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
        Me.bsLeaveHistory = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CCustomDateTimePicker1 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CCustomDateTimePicker2 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CtDataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsLeaveHistory,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
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
        'CtDataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.CtDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.CtDataGridView1.BegFindValue = Nothing
        Me.CtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CtDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CtDataGridView1.DgvFooter = Nothing
        Me.CtDataGridView1.DisplayOnly = false
        Me.CtDataGridView1.Ea = Nothing
        Me.CtDataGridView1.EditingMode = false
        Me.CtDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CtDataGridView1.EndFindValue = Nothing
        Me.CtDataGridView1.FieldDescription = Nothing
        Me.CtDataGridView1.FieldName = Nothing
        Me.CtDataGridView1.FieldsDictionary = Nothing
        Me.CtDataGridView1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CtDataGridView1.FindEnabled = false
        Me.CtDataGridView1.FirstRowDeletionEnabled = true
        Me.CtDataGridView1.FirstRowInsertionEnabled = true
        Me.CtDataGridView1.IgnoreCase = false
        Me.CtDataGridView1.IsDirty = false
        Me.CtDataGridView1.Location = New System.Drawing.Point(12, 172)
        Me.CtDataGridView1.Name = "CtDataGridView1"
        Me.CtDataGridView1.ReadOnly = true
        Me.CtDataGridView1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CtDataGridView1.SecurityKey = ""
        Me.CtDataGridView1.SequenceColumn = "dgvSequence"
        Me.CtDataGridView1.SequenceFieldName = "Sequence"
        Me.CtDataGridView1.ShowFooter = False
            Me.CtDataGridView1.Size = New System.Drawing.Size(841, 375)
            Me.CtDataGridView1.TabIndex = 4
        Me.CtDataGridView1.Translatable = true
        '
        'lblIdNo
        '
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(115, 24)
        Me.lblIdNo.TabIndex = 12
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BegFindValue = Nothing
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.EditingMode = true
        Me.txtIdNo.EndFindValue = Nothing
        Me.txtIdNo.FieldDescription = Nothing
        Me.txtIdNo.FieldName = Nothing
        Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtIdNo.FindEnabled = false
        Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Nothing
        Me.txtIdNo.Location = New System.Drawing.Point(118, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 11
        Me.txtIdNo.Translatable = false
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeIdNo.DisplayOnly = true
        Me.lblEmployeeIdNo.EditingMode = false
        Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmployeeIdNo.Location = New System.Drawing.Point(220, 1)
        Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Size = New System.Drawing.Size(134, 24)
        Me.lblEmployeeIdNo.TabIndex = 13
        Me.lblEmployeeIdNo.Text = "Employee Name"
        Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboEmployeeIdNo, true)
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.IntegralHeight = false
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(356, 1)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(350, 24)
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 14
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.BackColor = System.Drawing.Color.Transparent
        Me.dtpStartDate.DisplayOnly = true
        Me.dtpStartDate.EditingMode = false
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.dtpStartDate.Location = New System.Drawing.Point(1, 27)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(115, 24)
        Me.dtpStartDate.TabIndex = 15
        Me.dtpStartDate.Text = "Date Start"
        Me.dtpStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.dtpStartDate.Translatable = true
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.txtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cboEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout1.Controls.Add(Me.CCustomDateTimePicker1)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.CCustomDateTimePicker2)
        Me.CFlowLayout1.Location = New System.Drawing.Point(10, 99)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(842, 63)
        Me.CFlowLayout1.TabIndex = 16
        '
        'CCustomDateTimePicker1
        '
        Me.CCustomDateTimePicker1.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.CCustomDateTimePicker1.DefaultValue = Nothing
        Me.CCustomDateTimePicker1.DisplayOnly = false
        Me.CCustomDateTimePicker1.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker1.EditingMode = true
        Me.CCustomDateTimePicker1.EditsAllowed = false
        Me.CCustomDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker1.LinkedLabel = Nothing
        Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(118, 27)
        Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
        Me.CCustomDateTimePicker1.ReadOnlyDp = false
        Me.CCustomDateTimePicker1.SecurityKey = Nothing
        Me.CCustomDateTimePicker1.ShowLongDate = false
        Me.CCustomDateTimePicker1.ShowTime = false
        Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(119, 23)
        Me.CCustomDateTimePicker1.TabIndex = 16
        Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker1.Translatable = false
        Me.CCustomDateTimePicker1.Value = Nothing
        Me.CCustomDateTimePicker1.ValueIsMandatory = false
        Me.CCustomDateTimePicker1.ValueIsNullable = false
        '
        'CLabel1
        '
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(239, 27)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(115, 24)
        Me.CLabel1.TabIndex = 17
        Me.CLabel1.Text = "Date Start"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel1.Translatable = true
        '
        'CCustomDateTimePicker2
        '
        Me.CCustomDateTimePicker2.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.CCustomDateTimePicker2.DefaultValue = Nothing
        Me.CCustomDateTimePicker2.DisplayOnly = false
        Me.CCustomDateTimePicker2.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker2.EditingMode = true
        Me.CCustomDateTimePicker2.EditsAllowed = false
        Me.CCustomDateTimePicker2.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker2.LinkedLabel = Nothing
        Me.CCustomDateTimePicker2.Location = New System.Drawing.Point(356, 27)
        Me.CCustomDateTimePicker2.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker2.Name = "CCustomDateTimePicker2"
        Me.CCustomDateTimePicker2.ReadOnlyDp = false
        Me.CCustomDateTimePicker2.SecurityKey = Nothing
        Me.CCustomDateTimePicker2.ShowLongDate = false
        Me.CCustomDateTimePicker2.ShowTime = false
        Me.CCustomDateTimePicker2.Size = New System.Drawing.Size(119, 23)
        Me.CCustomDateTimePicker2.TabIndex = 18
        Me.CCustomDateTimePicker2.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker2.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker2.Translatable = false
        Me.CCustomDateTimePicker2.Value = Nothing
        Me.CCustomDateTimePicker2.ValueIsMandatory = false
        Me.CCustomDateTimePicker2.ValueIsNullable = false
        '
        'FormDataViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(865, 571)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CtDataGridView1)
        Me.Name = "FormDataViewer"
        Me.Controls.SetChildIndex(Me.CtDataGridView1, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CtDataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsLeaveHistory,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CtDataGridView1 As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents bsLeaveHistory As BindingSource
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CCustomDateTimePicker1 As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CCustomDateTimePicker2 As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    End Class
End NameSpace