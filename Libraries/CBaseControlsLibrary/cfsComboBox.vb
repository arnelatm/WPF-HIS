<Obsolete("Apparently unused legacy/experimental suggest-filter combo control. Prefer CtComboBox for new code.", False)>
<System.ComponentModel.ToolboxItem(False)>
Public Class CfsComboBox
    Inherits CbsComboBox

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        DisplayMember = "Name"
        PropertySelectorCompiled = Function(collection) collection.Cast(Of Lookup.LookupData)().[Select](Function(p) p.Name)
    End Sub

End Class
