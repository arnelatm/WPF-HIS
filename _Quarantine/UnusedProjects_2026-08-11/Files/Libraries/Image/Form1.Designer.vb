<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ListBoxForButtonClickExample = New System.Windows.Forms.ListBox()
        Me.cmdGetSingleImage = New System.Windows.Forms.Button()
        Me.PictureBoxForSingleClick = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBoxForDynamicLoad = New System.Windows.Forms.PictureBox()
        Me.ListBoxForLoadAlImageslExample = New System.Windows.Forms.ListBox()
        Me.dgvEmployeePictures = New System.Windows.Forms.DataGridView()
        Me.PictureBoxForDataGridView = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.PictureBoxForSingleClick,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        CType(Me.PictureBoxForDynamicLoad,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvEmployeePictures,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBoxForDataGridView,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox3.SuspendLayout
        Me.SuspendLayout
        '
        'ListBoxForButtonClickExample
        '
        Me.ListBoxForButtonClickExample.FormattingEnabled = true
        Me.ListBoxForButtonClickExample.Location = New System.Drawing.Point(6, 20)
        Me.ListBoxForButtonClickExample.Name = "ListBoxForButtonClickExample"
        Me.ListBoxForButtonClickExample.Size = New System.Drawing.Size(154, 121)
        Me.ListBoxForButtonClickExample.TabIndex = 0
        '
        'cmdGetSingleImage
        '
        Me.cmdGetSingleImage.Location = New System.Drawing.Point(6, 147)
        Me.cmdGetSingleImage.Name = "cmdGetSingleImage"
        Me.cmdGetSingleImage.Size = New System.Drawing.Size(75, 23)
        Me.cmdGetSingleImage.TabIndex = 1
        Me.cmdGetSingleImage.Text = "Get image"
        Me.cmdGetSingleImage.UseVisualStyleBackColor = true
        '
        'PictureBoxForSingleClick
        '
        Me.PictureBoxForSingleClick.Location = New System.Drawing.Point(174, 20)
        Me.PictureBoxForSingleClick.Name = "PictureBoxForSingleClick"
        Me.PictureBoxForSingleClick.Size = New System.Drawing.Size(131, 121)
        Me.PictureBoxForSingleClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxForSingleClick.TabIndex = 2
        Me.PictureBoxForSingleClick.TabStop = false
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.PictureBoxForSingleClick)
        Me.GroupBox1.Controls.Add(Me.cmdGetSingleImage)
        Me.GroupBox1.Controls.Add(Me.ListBoxForButtonClickExample)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 183)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Example get image from table on button click"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBoxForDynamicLoad)
        Me.GroupBox2.Controls.Add(Me.ListBoxForLoadAlImageslExample)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 183)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Example images loaded at shown event"
        '
        'PictureBoxForDynamicLoad
        '
        Me.PictureBoxForDynamicLoad.Location = New System.Drawing.Point(166, 20)
        Me.PictureBoxForDynamicLoad.Name = "PictureBoxForDynamicLoad"
        Me.PictureBoxForDynamicLoad.Size = New System.Drawing.Size(131, 121)
        Me.PictureBoxForDynamicLoad.TabIndex = 2
        Me.PictureBoxForDynamicLoad.TabStop = false
        '
        'ListBoxForLoadAlImageslExample
        '
        Me.ListBoxForLoadAlImageslExample.FormattingEnabled = true
        Me.ListBoxForLoadAlImageslExample.Location = New System.Drawing.Point(6, 20)
        Me.ListBoxForLoadAlImageslExample.Name = "ListBoxForLoadAlImageslExample"
        Me.ListBoxForLoadAlImageslExample.Size = New System.Drawing.Size(154, 121)
        Me.ListBoxForLoadAlImageslExample.TabIndex = 0
        '
        'dgvEmployeePictures
        '
        Me.dgvEmployeePictures.AllowUserToAddRows = false
        Me.dgvEmployeePictures.AllowUserToDeleteRows = false
        Me.dgvEmployeePictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployeePictures.Location = New System.Drawing.Point(3, 19)
        Me.dgvEmployeePictures.Name = "dgvEmployeePictures"
        Me.dgvEmployeePictures.ReadOnly = true
        Me.dgvEmployeePictures.Size = New System.Drawing.Size(160, 126)
        Me.dgvEmployeePictures.TabIndex = 5
        '
        'PictureBoxForDataGridView
        '
        Me.PictureBoxForDataGridView.Location = New System.Drawing.Point(171, 19)
        Me.PictureBoxForDataGridView.Name = "PictureBoxForDataGridView"
        Me.PictureBoxForDataGridView.Size = New System.Drawing.Size(131, 121)
        Me.PictureBoxForDataGridView.TabIndex = 3
        Me.PictureBoxForDataGridView.TabStop = false
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBoxForDataGridView)
        Me.GroupBox3.Controls.Add(Me.dgvEmployeePictures)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 395)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(308, 155)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Example displaying from DataTable in DataGridView"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Get image from file"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(214, 147)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save Image"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 559)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reading images"
        CType(Me.PictureBoxForSingleClick,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox2.ResumeLayout(false)
        CType(Me.PictureBoxForDynamicLoad,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvEmployeePictures,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBoxForDataGridView,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox3.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents ListBoxForButtonClickExample As ListBox
    Friend WithEvents cmdGetSingleImage As Button
    Friend WithEvents PictureBoxForSingleClick As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBoxForDynamicLoad As PictureBox
    Friend WithEvents ListBoxForLoadAlImageslExample As ListBox
    Friend WithEvents dgvEmployeePictures As DataGridView
    Friend WithEvents PictureBoxForDataGridView As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
