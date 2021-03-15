Public Class Test

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        UnselectItem()
    End Sub

    Public Sub UnselectItem()
        Me.cCombobox.ValueMember = "Value"
        Me.cCombobox.DisplayMember = "Text"
        Me.cCombobox.Items.AddRange({New ComboBoxItem() With {
                                           .Selectable = False,
                                           .Text = "Unselectable",
                                           .Value = 0
                                           }, New ComboBoxItem() With {
                                           .Selectable = True,
                                           .Text = "Selectable1",
                                           .Value = 1
                                           }, New ComboBoxItem() With {
                                           .Selectable = True,
                                           .Text = "Selectable2",
                                           .Value = 2
                                           }, New ComboBoxItem() With {
                                           .Selectable = False,
                                           .Text = "Unselectable",
                                           .Value = 3
                                           }, New ComboBoxItem() With {
                                           .Selectable = True,
                                           .Text = "Selectable3",
                                           .Value = 4
                                           }, New ComboBoxItem() With {
                                           .Selectable = True,
                                           .Text = "Selectable4",
                                           .Value = 5
                                           }})
        AddHandler cCombobox.SelectedIndexChanged, Function(cbSender, cbe)
                                                       Dim cb = TryCast(cbSender, ComboBox)

                                                       If cb.SelectedItem IsNot Nothing AndAlso TypeOf cb.SelectedItem Is ComboBoxItem AndAlso (CType(cb.SelectedItem, ComboBoxItem)).Selectable = False Then
                                                           cb.SelectedIndex = -1
                                                           MessageBox.Show("You cannot select this Item")
                                                       End If
                                                   End Function

    End Sub

    Private Class ComboBoxItem
        Public Property Value As Integer
        Public Property Text As String
        Public Property Selectable As Boolean
    End Class

End Class