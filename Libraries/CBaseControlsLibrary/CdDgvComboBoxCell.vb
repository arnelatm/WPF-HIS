' This is the class that represents your cell which can use your ComboBox class
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CdDgvComboBoxCell
    Inherits DataGridViewComboBoxCell
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        MyBase.New()
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CdDgvComboBoxEditingControl)
        End Get
    End Property

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal formattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        ' Call base...
        MyBase.InitializeEditingControl(rowIndex, formattedValue, cellStyle)

        ' Convert the cell's EditingControl to your custom ComboBox type...
        CellEditingControl = CType(DataGridView.EditingControl, CdDgvComboBoxEditingControl)

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

    Public Property CellEditingControl As CdDgvComboBoxEditingControl

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            If Value Or DisplayOnly Then
                Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                [ReadOnly] = True
            Else
                Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property
    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set
            _translatable = Value
        End Set
    End Property

    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            If _displayOnly <> Value Then
                _displayOnly = Value
            End If
        End Set
    End Property

End Class