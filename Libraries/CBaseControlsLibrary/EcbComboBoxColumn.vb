
Imports System.Windows.Forms

Public Class EcbComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Me.CellTemplate = New EcbComboBoxCell
    End Sub

    'Public Overrides Property CellTemplate() As DataGridViewCell
    '    Get
    '        Return MyBase.CellTemplate
    '    End Get
    '    Set(ByVal value As DataGridViewCell)
    '        ' Ensure that the cell used for the template is a CalendarCell.
    '        If Not value Is Nothing AndAlso (Not value.GetType().IsAssignableFrom(GetType(EcbComboBoxCell))) Then
    '            Throw New InvalidCastException("Must be a ECBComboBoxCell")
    '        End If
    '        DisplayMember = "Name"
    '        ValueMember = "idNo"
    '        MyBase.CellTemplate = value
    '    End Set
    'End Property

End Class