Imports System.Windows.Forms

Public Class CDgvCaComboboxCell
    Inherits DataGridViewComboBoxCell

    'Private WithEvents myGrid As DataGridView
    'Public Sub New()
    '    MyBase.New()
    '    myGrid = DataGridView
    'End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvCaComboBox)
        End Get
    End Property

    '    ' You must override the ValueType property to return the cell's
    '' underlying type
    'Public Overrides ReadOnly Property ValueType() As Type
    '    Get
    '        Return GetType(Integer)
    '    End Get
    'End Property

    Private MyEditingControl As CDgvCaComboBox

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal formattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)
        ' Call base...
        MyBase.InitializeEditingControl(rowIndex, formattedValue, cellStyle)

        ' Convert the cell's EditingControl to your custom ComboBox type...
        MyEditingControl = CType(DataGridView.EditingControl, CDgvCaComboBox)

        ' Make sure you have an instance...
        If MyEditingControl IsNot Nothing Then
            ' Set the value of the editing control instance to the current cell value.
            MyEditingControl.SelectedValue = Value
        End If
    End Sub

    Public Shadows Function DefaultNewRowValue() As Object
        Return 0
    End Function

    Protected Overrides Sub OnLeave(rowIndex As Integer, throughMouseClick As Boolean)
        If Not (MyEditingControl Is Nothing OrElse MyEditingControl.SelectedItem Is Nothing OrElse DataGridView.CurrentCell Is Nothing) Then
            DataGridView.CurrentCell.Value = MyEditingControl.SelectedItem.IdNo
        End If
    End Sub

End Class