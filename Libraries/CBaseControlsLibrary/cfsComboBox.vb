Public Class CfsComboBox
    Inherits CbsComboBox

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        DisplayMember = "Name"
        PropertySelectorCompiled = Function(collection) collection.Cast(Of ClassesLibrary.LookupData)().[Select](Function(p) p.Name)
    End Sub

End Class