' This is the class that represents your cell which can use your ComboBox class
Imports System.Windows.Forms

Public Class CDgvDtComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
        AutoComplete = False
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvDtComboBoxEditingControl)
        End Get
    End Property


    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        ' Call base...
        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)

        CellEditingControl = CType(DataGridView.EditingControl, CDgvDtComboBoxEditingControl)
        CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
        CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Public Property CellEditingControl As CDgvDtComboBoxEditingControl

End Class

