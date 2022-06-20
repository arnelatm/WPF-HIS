Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeIdPrinting
        Inherits CFormBase

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeIdPrinting))
        Me.bsEmployeeIdList = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnUnSelectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.DataGridViewEmployeeIdList = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.btnSelectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.PrintThis = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPicture = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEmployeeIdList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.DataGridViewEmployeeIdList,System.ComponentModel.ISupportInitialize).BeginInit
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
        'bsEmployeeIdList
        '
        Me.bsEmployeeIdList.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeIdModel)
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
        Me.TableLayoutPanel1.Controls.Add(Me.btnUnSelectAll, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewEmployeeIdList, 0, 1)
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
        'btnUnSelectAll
        '
        Me.btnUnSelectAll.DesignerSelected = false
        Me.btnUnSelectAll.ImageIndex = 0
        Me.btnUnSelectAll.Location = New System.Drawing.Point(99, 459)
        Me.btnUnSelectAll.Name = "btnUnSelectAll"
        Me.btnUnSelectAll.OriginalImageName = Nothing
        Me.btnUnSelectAll.SecurityKey = "ClosePettyCash"
        Me.btnUnSelectAll.Size = New System.Drawing.Size(90, 23)
        Me.btnUnSelectAll.TabIndex = 15
        Me.btnUnSelectAll.Text = "Unselect All"
        '
        'DataGridViewEmployeeIdList
        '
        Me.DataGridViewEmployeeIdList.AllowUserToAddRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEmployeeIdList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewEmployeeIdList.AutoGenerateColumns = false
        Me.DataGridViewEmployeeIdList.BegFindValue = Nothing
        Me.DataGridViewEmployeeIdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEmployeeIdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrintThis, Me.dgvIdNo, Me.dgvEmployeeName, Me.dgvNationalIdNo, Me.dgvPicture})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewEmployeeIdList, 2)
        Me.DataGridViewEmployeeIdList.DataSource = Me.bsEmployeeIdList
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEmployeeIdList.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewEmployeeIdList.DgvFooter = Nothing
        Me.DataGridViewEmployeeIdList.DisplayOnly = false
        Me.DataGridViewEmployeeIdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewEmployeeIdList.Ea = Nothing
        Me.DataGridViewEmployeeIdList.EditingMode = false
        Me.DataGridViewEmployeeIdList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEmployeeIdList.EndFindValue = Nothing
        Me.DataGridViewEmployeeIdList.FieldDescription = Nothing
        Me.DataGridViewEmployeeIdList.FieldName = Nothing
        Me.DataGridViewEmployeeIdList.FieldsDictionary = Nothing
        Me.DataGridViewEmployeeIdList.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewEmployeeIdList.FindEnabled = false
        Me.DataGridViewEmployeeIdList.FirstRowDeletionEnabled = true
        Me.DataGridViewEmployeeIdList.FirstRowInsertionEnabled = true
        Me.DataGridViewEmployeeIdList.IgnoreCase = false
        Me.DataGridViewEmployeeIdList.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewEmployeeIdList.Name = "DataGridViewEmployeeIdList"
        Me.DataGridViewEmployeeIdList.ReadOnly = true
        Me.DataGridViewEmployeeIdList.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewEmployeeIdList.SecurityKey = "ClosePettyCash"
        Me.DataGridViewEmployeeIdList.SequenceColumn = "dgvSequence"
        Me.DataGridViewEmployeeIdList.SequenceFieldName = "Sequence"
        Me.DataGridViewEmployeeIdList.ShowFooter = false
        Me.DataGridViewEmployeeIdList.ShowInsertColumnWhenEditing = false
        Me.DataGridViewEmployeeIdList.Size = New System.Drawing.Size(978, 450)
        Me.DataGridViewEmployeeIdList.TabIndex = 10
        Me.DataGridViewEmployeeIdList.Translatable = true
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
        'PrintThis
        '
        Me.PrintThis.BegFindValue = Nothing
        Me.PrintThis.DataPropertyName = "Print"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.NullValue = false
        Me.PrintThis.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrintThis.EditingMode = false
        Me.PrintThis.EndFindValue = Nothing
        Me.PrintThis.FieldDescription = Nothing
        Me.PrintThis.FieldName = Nothing
        Me.PrintThis.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.PrintThis.FindEnabled = false
        Me.PrintThis.HeaderText = "Print?"
        Me.PrintThis.IgnoreCase = false
        Me.PrintThis.Name = "PrintThis"
        Me.PrintThis.ReadOnly = true
        Me.PrintThis.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.PrintThis.Translatable = false
        Me.PrintThis.Width = 40
        '
        'dgvIdNo
        '
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle3
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
        'dgvEmployeeName
        '
        Me.dgvEmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEmployeeName.BegFindValue = Nothing
        Me.dgvEmployeeName.DataPropertyName = "EmployeeName"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeName.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEmployeeName.EditingMode = false
        Me.dgvEmployeeName.EndFindValue = Nothing
        Me.dgvEmployeeName.FieldDescription = Nothing
        Me.dgvEmployeeName.FieldName = Nothing
        Me.dgvEmployeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEmployeeName.FindEnabled = false
        Me.dgvEmployeeName.HeaderText = "EmployeeName"
        Me.dgvEmployeeName.IgnoreCase = false
        Me.dgvEmployeeName.Name = "dgvEmployeeName"
        Me.dgvEmployeeName.ReadOnly = true
        Me.dgvEmployeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEmployeeName.Translatable = false
        '
        'dgvNationalIdNo
        '
        Me.dgvNationalIdNo.BegFindValue = Nothing
        Me.dgvNationalIdNo.DataPropertyName = "NationalIdNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvNationalIdNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvNationalIdNo.EditingMode = false
        Me.dgvNationalIdNo.EndFindValue = Nothing
        Me.dgvNationalIdNo.FieldDescription = Nothing
        Me.dgvNationalIdNo.FieldName = Nothing
        Me.dgvNationalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNationalIdNo.FindEnabled = false
        Me.dgvNationalIdNo.HeaderText = "NationalIdNo"
        Me.dgvNationalIdNo.IgnoreCase = false
        Me.dgvNationalIdNo.Name = "dgvNationalIdNo"
        Me.dgvNationalIdNo.ReadOnly = true
        Me.dgvNationalIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNationalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNationalIdNo.Translatable = false
        '
        'dgvPicture
        '
        Me.dgvPicture.DataPropertyName = "Picture"
        Me.dgvPicture.HeaderText = "Picture"
        Me.dgvPicture.Name = "dgvPicture"
        Me.dgvPicture.ReadOnly = true
        Me.dgvPicture.Width = 50
        '
        'EmployeeIdPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(1008, 563)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(945, 590)
        Me.Name = "EmployeeIdPrinting"
        Me.Text = "Employee ID Printing"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEmployeeIdList,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.DataGridViewEmployeeIdList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsEmployeeIdList As Windows.Forms.BindingSource
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnUnSelectAll As CButton
        Friend WithEvents DataGridViewEmployeeIdList As CDataGridView
        Friend WithEvents btnSelectAll As CButton
        Friend WithEvents IdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents NationalIdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents PictureDataGridViewImageColumn As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
        Friend WithEvents PrintThis As CDgvCheckBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents dgvEmployeeName As CDgvTextColumn
        Friend WithEvents dgvNationalIdNo As CDgvTextColumn
        Friend WithEvents dgvPicture As DataGridViewImageColumn
    End Class
End Namespace