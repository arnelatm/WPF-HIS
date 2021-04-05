Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CheckPrinter
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckPrinter))
            Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
            Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpCheckDate = New CCustomDateTimePicker()
            Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpDisbursement.SuspendLayout()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'tlpDisbursement
            '
            Me.tlpDisbursement.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.ColumnCount = 6
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 0, 5)
            Me.tlpDisbursement.Controls.Add(Me.lblNotes, 0, 4)
            Me.tlpDisbursement.Controls.Add(Me.txtNotes, 1, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 0, 3)
            Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 1, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblPaymentType, 0, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 0, 1)
            Me.tlpDisbursement.Controls.Add(Me.cboPaymentType, 1, 2)
            Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 1, 1)
            Me.tlpDisbursement.Controls.Add(Me.lblAmount, 4, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 4, 1)
            Me.tlpDisbursement.Controls.Add(Me.txtAmount, 5, 2)
            Me.tlpDisbursement.Controls.Add(Me.dtpCheckDate, 5, 1)
            Me.tlpDisbursement.Controls.Add(Me.btnPrintCheck, 5, 5)
            Me.tlpDisbursement.Location = New System.Drawing.Point(0, 53)
            Me.tlpDisbursement.Name = "tlpDisbursement"
            Me.tlpDisbursement.RowCount = 6
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.Size = New System.Drawing.Size(672, 142)
            Me.tlpDisbursement.TabIndex = 5
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 5)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = "N2"
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayeeName.EditingMode = False
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.Location = New System.Drawing.Point(1, 107)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.Size = New System.Drawing.Size(548, 23)
            Me.txtPayeeName.TabIndex = 292
            Me.txtPayeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPayeeName.ValueIsMandatory = True
            Me.txtPayeeName.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(313, 30)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(236, 24)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(1, 82)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(115, 23)
            Me.lblNotes.TabIndex = 161
            Me.lblNotes.Text = "Description/Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 5)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(118, 82)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(551, 23)
            Me.txtNotes.TabIndex = 14
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(1, 56)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(105, 24)
            Me.lblSupplierIdNo.TabIndex = 7
            Me.lblSupplierIdNo.Text = "Payee:"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 5)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            Me.cboPayeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayeeIdNo.DropDownHeight = 1
            Me.cboPayeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayeeIdNo.EditingMode = False
            Me.cboPayeeIdNo.FilterRule = Nothing
            Me.cboPayeeIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.cboPayeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayeeIdNo.FormattingEnabled = True
            Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayeeIdNo.IntegralHeight = False
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Location = New System.Drawing.Point(118, 56)
            Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
            Me.cboPayeeIdNo.OldValue = 0
            Me.cboPayeeIdNo.OriginalDataSource = Nothing
            Me.cboPayeeIdNo.OriginalList = Nothing
            Me.cboPayeeIdNo.OverrideDropDownStyleList = False
            Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
            Me.cboPayeeIdNo.PreviousSelectedIndex = -1
            Me.cboPayeeIdNo.PropertySelector = Nothing
            Me.cboPayeeIdNo.ReadOnlyCombo = False
            Me.cboPayeeIdNo.SearchPlace = "1"
            Me.cboPayeeIdNo.Size = New System.Drawing.Size(553, 24)
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TabIndex = 5
            Me.cboPayeeIdNo.TextToSearch = Nothing
            Me.cboPayeeIdNo.ValueIsMandatory = False
            Me.cboPayeeIdNo.ValueIsNullable = False
            Me.cboPayeeIdNo.ValueIsNumeric = False
            Me.cboPayeeIdNo.ValueMember = "IdNo"
            '
            'lblPaymentType
            '
            Me.lblPaymentType.DisplayOnly = True
            Me.lblPaymentType.EditingMode = False
            Me.lblPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentType.Location = New System.Drawing.Point(1, 30)
            Me.lblPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentType.Name = "lblPaymentType"
            Me.lblPaymentType.Size = New System.Drawing.Size(115, 23)
            Me.lblPaymentType.TabIndex = 257
            Me.lblPaymentType.Text = "Payment Type:"
            Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckNumber.Location = New System.Drawing.Point(1, 1)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(112, 27)
            Me.lblCheckNumber.TabIndex = 290
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPaymentType
            '
            Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPaymentType.BackColor = System.Drawing.Color.White
            Me.cboPaymentType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 3)
            Me.cboPaymentType.CurrentSearchTerm = ""
            Me.cboPaymentType.DefaultValue = "0"
            Me.cboPaymentType.DisplayMember = "Name"
            Me.cboPaymentType.DropDownHeight = 1
            Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPaymentType.EditingMode = False
            Me.cboPaymentType.FilterRule = Nothing
            Me.cboPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
            Me.cboPaymentType.HideWhenNotEditingOrAdding = False
            Me.cboPaymentType.IntegralHeight = False
            Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
            Me.cboPaymentType.Location = New System.Drawing.Point(118, 30)
            Me.cboPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaymentType.Name = "cboPaymentType"
            Me.cboPaymentType.OldValue = 0
            Me.cboPaymentType.OriginalDataSource = Nothing
            Me.cboPaymentType.OriginalList = Nothing
            Me.cboPaymentType.OverrideDropDownStyleList = False
            Me.cboPaymentType.PreviousSearchTerm = Nothing
            Me.cboPaymentType.PreviousSelectedIndex = 0
            Me.cboPaymentType.PropertySelector = Nothing
            Me.cboPaymentType.ReadOnlyCombo = False
            Me.cboPaymentType.SearchPlace = "1"
            Me.cboPaymentType.Size = New System.Drawing.Size(193, 24)
            Me.cboPaymentType.SuggestBoxHeight = 200
            Me.cboPaymentType.SuggestListOrderRule = Nothing
            Me.cboPaymentType.TabIndex = 4
            Me.cboPaymentType.TextToSearch = Nothing
            Me.cboPaymentType.ValueIsMandatory = False
            Me.cboPaymentType.ValueIsNullable = False
            Me.cboPaymentType.ValueIsNumeric = False
            Me.cboPaymentType.ValueMember = "Code"
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = False
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Nothing
            Me.txtCheckNumber.Location = New System.Drawing.Point(118, 1)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.Size = New System.Drawing.Size(118, 23)
            Me.txtCheckNumber.TabIndex = 11
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckDate.Location = New System.Drawing.Point(313, 1)
            Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckDate.Name = "lblCheckDate"
            Me.lblCheckDate.Size = New System.Drawing.Size(236, 25)
            Me.lblCheckDate.TabIndex = 284
            Me.lblCheckDate.Text = "Check Date"
            Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(551, 30)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.Size = New System.Drawing.Size(118, 23)
            Me.txtAmount.TabIndex = 8
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'dtpCheckDate
            '
            Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCheckDate.DefaultValue = Nothing
            Me.dtpCheckDate.DisplayOnly = False
            Me.dtpCheckDate.DtpDefaultValue = Nothing
            Me.dtpCheckDate.EditingMode = False
            Me.dtpCheckDate.EditsAllowed = False
            Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
            Me.dtpCheckDate.LinkedLabel = Nothing
            Me.dtpCheckDate.Location = New System.Drawing.Point(551, 1)
            Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpCheckDate.TabIndex = 13
            Me.dtpCheckDate.TargetCalendar = Nothing
            Me.dtpCheckDate.Value = Nothing
            Me.dtpCheckDate.ValueIsMandatory = False
            Me.dtpCheckDate.ValueIsNullable = False
            '
            'btnPrintCheck
            '
            Me.btnPrintCheck.DesignerSelected = False
            Me.btnPrintCheck.DisplayOnly = True
            Me.btnPrintCheck.ImageIndex = 0
            Me.btnPrintCheck.Location = New System.Drawing.Point(553, 109)
            Me.btnPrintCheck.Name = "btnPrintCheck"
            Me.btnPrintCheck.OriginalImageName = Nothing
            Me.btnPrintCheck.SecurityKey = ""
            Me.btnPrintCheck.Size = New System.Drawing.Size(116, 31)
            Me.btnPrintCheck.TabIndex = 291
            Me.btnPrintCheck.TabStop = False
            Me.btnPrintCheck.Text = "Print Check"
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
            '
            'CheckPrinter
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(682, 203)
            Me.Controls.Add(Me.tlpDisbursement)
            Me.MaximumSize = New System.Drawing.Size(1000, 300)
            Me.MinimumSize = New System.Drawing.Size(16, 100)
            Me.Name = "CheckPrinter"
            Me.Text = "Petty Cash Journal "
            Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpDisbursement.ResumeLayout(False)
            Me.tlpDisbursement.PerformLayout()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents bsDjOiItems As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CdgvColumnText
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CdgvColumnText
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tlpDisbursement As TableLayoutPanel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents cboPayeeIdNo As CaComboBox
        Friend WithEvents dtpCheckDate As CCustomDateTimePicker
        Friend WithEvents lblCheckDate As CLabel
        Friend WithEvents txtCheckNumber As CTextBox
        Friend WithEvents lblCheckNumber As CLabel
        Friend WithEvents lblPaymentType As CLabel
        Friend WithEvents cboPaymentType As CaComboBox
        Friend WithEvents btnPrintCheck As CButton
        Friend WithEvents txtPayeeName As CTextBox
    End Class
End Namespace