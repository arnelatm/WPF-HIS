Imports System.Windows.Forms

Public Class MyFormCombobox
    Inherits Form

    Friend WithEvents BindingSource1 As BindingSource
    Private components As System.ComponentModel.IContainer
    Friend WithEvents ComboBox1 As ComboBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim MyTable As New DataTable
        MyTable.Columns.Add("Value", GetType(String))

        With MyTable.Rows
            .Add("server123")
            .Add("server456")
            .Add("computer")
            .Add("terminal33")
            .Add("client34 ")
        End With

        BindingSource1.DataSource = MyTable

        With ComboBox1
            .DisplayMember = "Value"
            .DataSource = BindingSource1

            'Binding will select the first item so we must explicitly clear it.
            .SelectedItem = Nothing
            .Text = Nothing
        End With
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        'Modifying the filter will replace the text so we must change it back again afterwards.
        Dim text = ComboBox1.Text
        Dim selectionStart = ComboBox1.SelectionStart

        'Filter the drop-down list if and only if the user has entered some non-whitespace text.
        BindingSource1.Filter = If(String.IsNullOrWhiteSpace(text),
                                   Nothing,
                                   String.Format("Value LIKE '*{0}*'",
                                                 text))

        ComboBox1.Text = text
        ComboBox1.SelectionStart = selectionStart
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyFormCombobox
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Name = "MyFormCombobox"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class