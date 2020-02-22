Imports System.Windows.Forms

Public Class CDgvCellCaCombobox
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    ' You must override the EditType property to return the cell's 
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvCaComboboxColumn)
        End Get
    End Property


End Class
