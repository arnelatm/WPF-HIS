' This is the class that represents your cell which can use your ComboBox class
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CtComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
        AutoComplete = False
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CtComboBoxEditingControl)
        End Get
    End Property


    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        'Dim lastOpenedForm As Form = Application.OpenForms.Cast(Of Form)
        'lastOpenedForm.SuspendDrawing()
        'lastOpenedForm.SuspendLayout()
        If DataGridView.EditingControl IsNot Nothing Then
            'SuspendLayout(DataGridView.EditingControl)

            ' Call base...
            MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
            If DataGridView.EditingControl IsNot Nothing Then
                CellEditingControl = CType(DataGridView.EditingControl, CtComboBoxEditingControl)
                'CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
                'CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
        End If
        'astOpenedForm.ResumeDrawing()
        'lastOpenedForm.SuspendLayout()

    End Sub

    Public Property CellEditingControl As CtComboBoxEditingControl

End Class

