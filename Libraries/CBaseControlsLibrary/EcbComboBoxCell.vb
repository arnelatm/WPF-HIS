Imports System.Windows.Forms

Public Class EcbComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()

    End Sub

    Public Overrides Sub InitializeEditingControl(pRowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(pRowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As EcbComboBoxEditingControl = TryCast(DataGridView.EditingControl, EcbComboBoxEditingControl)
        ctl.ValueMember = "IdNo"
        ctl.DisplayMember = "Name"
        ctl.SelectedValue = Value
        ctl.CausesValidation = False
        ctl.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(EcbComboBoxEditingControl)
        End Get
    End Property

    'Public Overrides ReadOnly Property ValueType() As Type
    '    Get
    '        ' Return the type of the value that CalendarCell contains.
    '        Return GetType(ValueType)
    '    End Get
    'End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the 0 as the default value.
            Return 0
        End Get
    End Property

End Class