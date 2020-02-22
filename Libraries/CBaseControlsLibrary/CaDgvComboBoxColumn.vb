Imports System.Windows.Forms

Public Class CaDgvComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        MyBase.New()
        Me.AutoComplete = False
        MyBase.CellTemplate = New CaDgvComboboxCell
    End Sub

    'Public Overrides Function Clone() As Object
    '    Dim copy As CaDgvComboboxCell = TryCast(MyBase.Clone(), CaDgvComboboxCell)
    '    Return copy

    'End Function

End Class