' This is the class that represents your cell which can use your ComboBox class
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class CfDgvComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
        AutoComplete = True
        'CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CfDgvComboBoxEditingControl)
        End Get
    End Property

    'You must also override this method To initialize the ComboBox instance...
    'This method will be called Each time a cell In the column enters edit-mode,
    'so you can fill the ComboBox instance based On the value Of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CtDgvComboBoxEditingControl)
        CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
        CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Public Property CellEditingControl As CtDgvComboBoxEditingControl


End Class