Imports System.Windows.Forms

Public Class CDgvComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        MyBase.New()

        ' Specify the column to use your custom cell class...
        MyBase.CellTemplate = New EcbComboBoxCell()

    End Sub

End Class
