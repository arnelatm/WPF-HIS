<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataGridViewBoxForm
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ProductModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTINDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ProductModelBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = false
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductNameDataGridViewTextBoxColumn, Me.ProductCodeDataGridViewTextBoxColumn, Me.BarcodeDataGridViewTextBoxColumn, Me.GTINDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ProductModelBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(573, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'ProductModelBindingSource
        '
        Me.ProductModelBindingSource.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.ProductModel)
        '
        'ProductNameDataGridViewTextBoxColumn
        '
        Me.ProductNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProductNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName"
        Me.ProductNameDataGridViewTextBoxColumn.HeaderText = "ProductName"
        Me.ProductNameDataGridViewTextBoxColumn.Name = "ProductNameDataGridViewTextBoxColumn"
        '
        'ProductCodeDataGridViewTextBoxColumn
        '
        Me.ProductCodeDataGridViewTextBoxColumn.DataPropertyName = "ProductCode"
        Me.ProductCodeDataGridViewTextBoxColumn.HeaderText = "ProductCode"
        Me.ProductCodeDataGridViewTextBoxColumn.Name = "ProductCodeDataGridViewTextBoxColumn"
        '
        'BarcodeDataGridViewTextBoxColumn
        '
        Me.BarcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode"
        Me.BarcodeDataGridViewTextBoxColumn.HeaderText = "Barcode"
        Me.BarcodeDataGridViewTextBoxColumn.Name = "BarcodeDataGridViewTextBoxColumn"
        '
        'GTINDataGridViewTextBoxColumn
        '
        Me.GTINDataGridViewTextBoxColumn.DataPropertyName = "GTIN"
        Me.GTINDataGridViewTextBoxColumn.HeaderText = "GTIN"
        Me.GTINDataGridViewTextBoxColumn.Name = "GTINDataGridViewTextBoxColumn"
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.Visible = false
        '
        'DataGridViewBoxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DataGridViewBoxForm"
        Me.Size = New System.Drawing.Size(573, 150)
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ProductModelBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents ProductNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BarcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GTINDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProductModelBindingSource As BindingSource
End Class
