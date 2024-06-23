Namespace CascadingComboboBox
    Partial Class Form1
        ''' <summary>
        '''  Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        '''  Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        '''  Required method for Designer support - do not modify
        '''  the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            dataGridView1 = New Windows.Forms.DataGridView()
            btnNewData = New Windows.Forms.Button()
            CType(dataGridView1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' dataGridView1
            ' 
            dataGridView1.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dataGridView1.Location = New Drawing.Point(5, 5)
            dataGridView1.Name = "dataGridView1"
            dataGridView1.RowHeadersWidth = 51
            dataGridView1.RowTemplate.Height = 29
            dataGridView1.Size = New Drawing.Size(783, 399)
            dataGridView1.TabIndex = 0
            AddHandler dataGridView1.EditingControlShowing, AddressOf dataGridView1_EditingControlShowing
            ' 
            ' btnNewData
            ' 
            btnNewData.Location = New Drawing.Point(5, 413)
            btnNewData.Name = "btnNewData"
            btnNewData.Size = New Drawing.Size(94, 29)
            btnNewData.TabIndex = 1
            btnNewData.Text = "New Data"
            btnNewData.UseVisualStyleBackColor = True
            AddHandler btnNewData.Click, AddressOf btnNewData_Click
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(8F, 20F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(800, 450)
            Controls.Add(btnNewData)
            Controls.Add(dataGridView1)
            Name = "Form1"
            Text = "Form1"
            AddHandler Load, AddressOf Form1_Load
            CType(dataGridView1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub

#End Region

        Private dataGridView1 As Windows.Forms.DataGridView
        Private btnNewData As Windows.Forms.Button
    End Class
End Namespace
