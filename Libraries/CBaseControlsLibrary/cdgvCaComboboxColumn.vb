Imports System.Windows.Forms

Public Class CDgvCaComboboxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        MyBase.New()
        CellTemplate = New CDgvCaComboboxCell
    End Sub

    Public Overrides Function Clone() As Object
        Dim copy As CDgvCaComboboxCell = TryCast(MyBase.Clone(), CDgvCaComboboxCell)
        'copy.DisplayOnly = DisplayOnly
        Return copy
    End Function

End Class