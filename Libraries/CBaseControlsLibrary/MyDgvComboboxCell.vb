' This is the class that represents your cell which can use your ComboBox class
Imports System.Windows.Forms

Public Class MyDgvComboboxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CtComboBox)
        End Get
    End Property

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal formattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        ' Call base...
        MyBase.InitializeEditingControl(rowIndex, formattedValue, cellStyle)

        ' Convert the cell's EditingControl to your custom ComboBox type...
        Dim ctl As CtComboBox = CType(DataGridView.EditingControl, CtComboBox)

        ' Make sure you have an instance...
        If ctl IsNot Nothing Then
            ' Populate the ComboBox, passing the instance as a parameter
            'FillColorList(ctl)

            ' Set the value of the editing control instance to the current cell value.
            ctl.SelectedValue = formattedValue
        End If
    End Sub

End Class

' This is the class that represents your column which can use your cell class
Public Class MyDataGridViewComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        MyBase.New()

        ' Specify the column to use your custom cell class...
        MyBase.CellTemplate = New MyDgvComboboxCell()
    End Sub

End Class