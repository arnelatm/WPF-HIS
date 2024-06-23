<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        btnNewData = New Button()
        dataGridView1 = New DataGridView()
        CType(dataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnNewData
        ' 
        btnNewData.Location = New Point(9, 415)
        btnNewData.Name = "btnNewData"
        btnNewData.Size = New Size(94, 29)
        btnNewData.TabIndex = 3
        btnNewData.Text = "New Data"
        btnNewData.UseVisualStyleBackColor = True
        ' 
        ' dataGridView1
        ' 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridView1.Location = New Point(9, 7)
        dataGridView1.Name = "dataGridView1"
        dataGridView1.RowHeadersWidth = 51
        dataGridView1.RowTemplate.Height = 29
        dataGridView1.Size = New Size(783, 399)
        dataGridView1.TabIndex = 2
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnNewData)
        Controls.Add(dataGridView1)
        Name = "Form1"
        Text = "Form1"
        CType(dataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Private WithEvents btnNewData As Button
    Private WithEvents dataGridView1 As DataGridView
End Class
