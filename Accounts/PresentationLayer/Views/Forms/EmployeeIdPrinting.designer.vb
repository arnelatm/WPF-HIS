Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeIdPrinting
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeIdPrinting))
        Me.bsPcJournals = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnSelectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.dgvPayeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvPayeeName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPayeeType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvReference = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPcClosed = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.DataGridViewPcJournals = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.DataGridViewPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
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
        'bsPcJournals
        '
        Me.bsPcJournals.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PcClosingJournalModel)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Controls.Add(Me.CButton1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPcJournals, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSelectAll, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 58)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 502)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = false
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(99, 459)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = "ClosePettyCash"
        Me.CButton1.Size = New System.Drawing.Size(90, 23)
        Me.CButton1.TabIndex = 15
        Me.CButton1.Text = "Unselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.DesignerSelected = false
        Me.btnSelectAll.ImageIndex = 0
        Me.btnSelectAll.Location = New System.Drawing.Point(3, 459)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.OriginalImageName = Nothing
        Me.btnSelectAll.SecurityKey = "ClosePettyCash"
        Me.btnSelectAll.Size = New System.Drawing.Size(90, 23)
        Me.btnSelectAll.TabIndex = 14
        Me.btnSelectAll.Text = "Select All"
        '
        'dgvPayeeNameAra
        '
        Me.dgvPayeeNameAra.BegFindValue = Nothing
        Me.dgvPayeeNameAra.DataPropertyName = "PayeeNameAra"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeNameAra.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPayeeNameAra.EditingMode = false
        Me.dgvPayeeNameAra.EndFindValue = Nothing
        Me.dgvPayeeNameAra.FieldDescription = Nothing
        Me.dgvPayeeNameAra.FieldName = Nothing
        Me.dgvPayeeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeNameAra.FindEnabled = false
        Me.dgvPayeeNameAra.HeaderText = "PayeeNameAra"
        Me.dgvPayeeNameAra.IgnoreCase = false
        Me.dgvPayeeNameAra.Name = "dgvPayeeNameAra"
        Me.dgvPayeeNameAra.ReadOnly = true
        Me.dgvPayeeNameAra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeNameAra.Translatable = false
        Me.dgvPayeeNameAra.Visible = false
        Me.dgvPayeeNameAra.Width = 150
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.BegFindValue = Nothing
        Me.dgvNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.EndFindValue = Nothing
        Me.dgvNotes.FieldDescription = Nothing
        Me.dgvNotes.FieldName = Nothing
        Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotes.FindEnabled = false
        Me.dgvNotes.HeaderText = "Notes"
        Me.dgvNotes.IgnoreCase = false
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotes.Translatable = false
        '
        'dgvAmount
        '
        Me.dgvAmount.BegFindValue = Nothing
        Me.dgvAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Format = "###,##0.00"
        Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAmount.EditingMode = false
        Me.dgvAmount.EndFindValue = Nothing
        Me.dgvAmount.FieldDescription = Nothing
        Me.dgvAmount.FieldName = Nothing
        Me.dgvAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvAmount.FindEnabled = false
        Me.dgvAmount.HeaderText = "Amount"
        Me.dgvAmount.Name = "dgvAmount"
        Me.dgvAmount.ReadOnly = true
        Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvAmount.Translatable = false
        '
        'dgvPayeeName
        '
        Me.dgvPayeeName.BegFindValue = Nothing
        Me.dgvPayeeName.DataPropertyName = "PayeeName"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeName.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPayeeName.EditingMode = false
        Me.dgvPayeeName.EndFindValue = Nothing
        Me.dgvPayeeName.FieldDescription = Nothing
        Me.dgvPayeeName.FieldName = Nothing
        Me.dgvPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeName.FindEnabled = false
        Me.dgvPayeeName.HeaderText = "PayeeName"
        Me.dgvPayeeName.IgnoreCase = false
        Me.dgvPayeeName.Name = "dgvPayeeName"
        Me.dgvPayeeName.ReadOnly = true
        Me.dgvPayeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeName.Translatable = false
        Me.dgvPayeeName.Width = 150
        '
        'dgvPayeeType
        '
        Me.dgvPayeeType.BegFindValue = Nothing
        Me.dgvPayeeType.DataPropertyName = "PaymentType"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeType.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPayeeType.EditingMode = false
        Me.dgvPayeeType.EndFindValue = Nothing
        Me.dgvPayeeType.FieldDescription = Nothing
        Me.dgvPayeeType.FieldName = Nothing
        Me.dgvPayeeType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeType.FindEnabled = false
        Me.dgvPayeeType.HeaderText = "Payee Type"
        Me.dgvPayeeType.IgnoreCase = false
        Me.dgvPayeeType.Name = "dgvPayeeType"
        Me.dgvPayeeType.ReadOnly = true
        Me.dgvPayeeType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeType.Translatable = false
        Me.dgvPayeeType.Width = 40
        '
        'dgvReference
        '
        Me.dgvReference.BegFindValue = Nothing
        Me.dgvReference.DataPropertyName = "ReferenceNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvReference.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReference.EditingMode = false
        Me.dgvReference.EndFindValue = Nothing
        Me.dgvReference.FieldDescription = Nothing
        Me.dgvReference.FieldName = Nothing
        Me.dgvReference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvReference.FindEnabled = false
        Me.dgvReference.HeaderText = "Reference No"
        Me.dgvReference.IgnoreCase = false
        Me.dgvReference.Name = "dgvReference"
        Me.dgvReference.ReadOnly = true
        Me.dgvReference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvReference.Translatable = false
        Me.dgvReference.Width = 80
        '
        'dgvIdNo
        '
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = false
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.IgnoreCase = false
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvIdNo.Translatable = false
        Me.dgvIdNo.Width = 50
        '
        'dgvTransactionDate
        '
        Me.dgvTransactionDate.BegFindValue = Nothing
        Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTransactionDate.DisplayOnly = true
        Me.dgvTransactionDate.EditingMode = false
        Me.dgvTransactionDate.EndFindValue = Nothing
        Me.dgvTransactionDate.FieldDescription = Nothing
        Me.dgvTransactionDate.FieldName = Nothing
        Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvTransactionDate.FindEnabled = false
        Me.dgvTransactionDate.HeaderText = "Date"
        Me.dgvTransactionDate.IgnoreCase = false
        Me.dgvTransactionDate.Name = "dgvTransactionDate"
        Me.dgvTransactionDate.ReadOnly = true
        Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvTransactionDate.Translatable = false
        Me.dgvTransactionDate.Width = 80
        '
        'dgvPcClosed
        '
        Me.dgvPcClosed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvPcClosed.BegFindValue = Nothing
        Me.dgvPcClosed.DataPropertyName = "PcClosed"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.NullValue = false
        Me.dgvPcClosed.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPcClosed.EditingMode = false
        Me.dgvPcClosed.EndFindValue = Nothing
        Me.dgvPcClosed.FieldDescription = Nothing
        Me.dgvPcClosed.FieldName = Nothing
        Me.dgvPcClosed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPcClosed.FindEnabled = false
        Me.dgvPcClosed.HeaderText = "Close?"
        Me.dgvPcClosed.IgnoreCase = false
        Me.dgvPcClosed.MinimumWidth = 50
        Me.dgvPcClosed.Name = "dgvPcClosed"
        Me.dgvPcClosed.ReadOnly = true
        Me.dgvPcClosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPcClosed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPcClosed.Translatable = false
        Me.dgvPcClosed.Width = 50
        '
        'DataGridViewPcJournals
        '
        Me.DataGridViewPcJournals.AllowUserToAddRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPcJournals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPcJournals.AutoGenerateColumns = false
        Me.DataGridViewPcJournals.BegFindValue = Nothing
        Me.DataGridViewPcJournals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPcJournals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvPcClosed, Me.dgvTransactionDate, Me.dgvIdNo, Me.dgvReference, Me.dgvPayeeType, Me.dgvPayeeName, Me.dgvAmount, Me.dgvNotes, Me.dgvPayeeNameAra})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPcJournals, 2)
        Me.DataGridViewPcJournals.DataSource = Me.bsPcJournals
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPcJournals.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewPcJournals.DgvFooter = Nothing
        Me.DataGridViewPcJournals.DisplayOnly = false
        Me.DataGridViewPcJournals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPcJournals.Ea = Nothing
        Me.DataGridViewPcJournals.EditingMode = false
        Me.DataGridViewPcJournals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPcJournals.EndFindValue = Nothing
        Me.DataGridViewPcJournals.FieldDescription = Nothing
        Me.DataGridViewPcJournals.FieldName = Nothing
        Me.DataGridViewPcJournals.FieldsDictionary = Nothing
        Me.DataGridViewPcJournals.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPcJournals.FindEnabled = false
        Me.DataGridViewPcJournals.FirstRowDeletionEnabled = true
        Me.DataGridViewPcJournals.FirstRowInsertionEnabled = true
        Me.DataGridViewPcJournals.IgnoreCase = false
        Me.DataGridViewPcJournals.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewPcJournals.Name = "DataGridViewPcJournals"
        Me.DataGridViewPcJournals.ReadOnly = true
        Me.DataGridViewPcJournals.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPcJournals.SecurityKey = "ClosePettyCash"
        Me.DataGridViewPcJournals.SequenceColumn = "dgvSequence"
        Me.DataGridViewPcJournals.SequenceFieldName = "Sequence"
        Me.DataGridViewPcJournals.ShowFooter = false
        Me.DataGridViewPcJournals.ShowInsertColumnWhenEditing = false
        Me.DataGridViewPcJournals.Size = New System.Drawing.Size(978, 450)
        Me.DataGridViewPcJournals.TabIndex = 10
        Me.DataGridViewPcJournals.Translatable = true
        '
        'EmployeeIdPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(1008, 659)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(945, 590)
        Me.Name = "EmployeeIdPrinting"
        Me.Text = "Employee ID Printing"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPcJournals,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.DataGridViewPcJournals,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsPcJournals As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CButton1 As CButton
        Friend WithEvents DataGridViewPcJournals As CDataGridView
        Friend WithEvents dgvPcClosed As CDgvCheckBoxColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents dgvReference As CDgvTextColumn
        Friend WithEvents dgvPayeeType As CDgvTextColumn
        Friend WithEvents dgvPayeeName As CDgvTextColumn
        Friend WithEvents dgvAmount As CdgvMoneyColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvPayeeNameAra As CDgvTextColumn
        Friend WithEvents btnSelectAll As CButton
    End Class
End Namespace