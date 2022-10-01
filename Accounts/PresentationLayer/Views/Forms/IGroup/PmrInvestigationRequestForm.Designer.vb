Namespace PresentationLayer.Views.Forms.IGroup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PmrInvestigationRequestForm

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PmrRequestForm))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.CTextBox1)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout1.Controls.Add(Me.CDataGridView1)
            Me.CFlowLayout1.Location = New System.Drawing.Point(13, 71)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(671, 349)
            Me.CFlowLayout1.TabIndex = 4
            '
            'CDataGridView1
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.CDataGridView1.BegFindValue = Nothing
            Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
            Me.CDataGridView1.DgvFooter = Nothing
            Me.CDataGridView1.DisplayOnly = False
            Me.CDataGridView1.Ea = Nothing
            Me.CDataGridView1.EditingMode = False
            Me.CDataGridView1.EndFindValue = Nothing
            Me.CDataGridView1.FieldDescription = Nothing
            Me.CDataGridView1.FieldName = Nothing
            Me.CDataGridView1.FieldsDictionary = Nothing
            Me.CDataGridView1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CDataGridView1.FindEnabled = False
            Me.CDataGridView1.FirstRowDeletionEnabled = True
            Me.CDataGridView1.FirstRowInsertionEnabled = True
            Me.CDataGridView1.IgnoreCase = False
            Me.CDataGridView1.IsDirty = False
            Me.CDataGridView1.Location = New System.Drawing.Point(3, 53)
            Me.CDataGridView1.Name = "CDataGridView1"
            Me.CDataGridView1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CDataGridView1.SecurityKey = ""
            Me.CDataGridView1.SequenceColumn = "dgvSequence"
            Me.CDataGridView1.SequenceFieldName = "Sequence"
            Me.CDataGridView1.ShowFooter = False
            Me.CDataGridView1.ShowInsertColumnWhenEditing = True
            Me.CDataGridView1.Size = New System.Drawing.Size(666, 296)
            Me.CDataGridView1.TabIndex = 0
            Me.CDataGridView1.Translatable = True
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = True
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(135, 26)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 23)
            Me.dtpTransactionDate.TabIndex = 1
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 26)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(132, 23)
            Me.CLabel1.TabIndex = 6
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(132, 23)
            Me.CLabel2.TabIndex = 7
            Me.CLabel2.Text = "Doctor's Name:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.CTextBox1.BegFindValue = Nothing
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.EndFindValue = Nothing
            Me.CTextBox1.FieldDescription = Nothing
            Me.CTextBox1.FieldName = Nothing
            Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox1.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.CTextBox1, True)
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(135, 1)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(534, 23)
            Me.CTextBox1.TabIndex = 8
            Me.CTextBox1.Translatable = False
            '
            'PMRRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(699, 433)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "PMRRequestForm"
            Me.Text = "PMR Request Form"
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CDataGridView1 As Libraries.CBaseControlsLibrary.CDataGridView
    End Class
End Namespace