' This is the class that represents your cell which can use your ComboBox class
Imports System.Windows.Forms

Public Class CDgvComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvComboBoxEditingControl)
        End Get
    End Property

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal formattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        ' Call base...
        MyBase.InitializeEditingControl(rowIndex, formattedValue, cellStyle)

        ' Convert the cell's EditingControl to your custom ComboBox type...
        CellEditingControl = CType(DataGridView.EditingControl, CDgvComboBoxEditingControl)

        ' Make sure you have an instance...
        If CellEditingControl IsNot Nothing Then
            ' Populate the ComboBox, passing the instance as a parameter

            ' Set the value of the editing control instance to the current cell value.
            If Value Is Nothing Then
                CellEditingControl.SelectedIndex = -1
            Else
                CellEditingControl.SelectedValue = Value
            End If
            CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
            CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End If
    End Sub

    Public Property CellEditingControl As CDgvComboBoxEditingControl

End Class