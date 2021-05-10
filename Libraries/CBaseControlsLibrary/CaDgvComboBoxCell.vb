Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CaDgvComboboxCell
    Inherits DataGridViewComboBoxCell
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    'Private WithEvents myGrid As DataGridView
    'Public Sub New()
    '    MyBase.New()
    '    myGrid = DataGridView
    'End Sub

    Public Overrides Function Clone() As Object
        Dim copy As CaDgvComboboxCell = TryCast(MyBase.Clone(), CaDgvComboboxCell)
        copy.DisplayOnly = DisplayOnly
        copy.Translatable = Translatable
        copy.EditingMode = EditingMode
        Return copy
    End Function

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CaDgvComboBox)
        End Get
    End Property

    ' You must override the ValueType property to return the cell's
    ' underlying type
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(ValueType)
        End Get
    End Property

    Private _myEditingControl As CaDgvComboBox

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)
        ' Call base...
        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)

        ' Convert the cell's EditingControl to your custom ComboBox type...
        _myEditingControl = CType(DataGridView.EditingControl, CaDgvComboBox)

        ' Make sure you have an instance...
        If _myEditingControl IsNot Nothing Then
            ' Set the value of the editing control instance to the current cell value.
            If Value IsNot Nothing Then
                'MyEditingControl.SelectedValue = nothing
                'Else
                _myEditingControl.SelectedValue = Value
            End If
        End If
    End Sub

    Public ReadOnly Property CellEditingControl As CaDgvComboBox
        Get
            Return _myEditingControl
        End Get
    End Property

    Public Shadows Function DefaultNewRowValue() As Object
        Return 0
    End Function

    Protected Overrides Sub OnLeave(pRowIndex As Integer, throughMouseClick As Boolean)
        If Not (_myEditingControl Is Nothing OrElse _myEditingControl.SelectedItem Is Nothing OrElse DataGridView.CurrentCell Is Nothing) Then
            If DirectCast(DataGridView.CurrentCell, DataGridViewComboBoxCell).ValueMember = "Code" Then
                DataGridView.CurrentCell.Value = _myEditingControl.SelectedItem.Code
            Else
                DataGridView.CurrentCell.Value = _myEditingControl.SelectedItem.idno
            End If
        End If
    End Sub

    'Public Function GetValue()

    'End Function

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
            'If value Then
            '    ReadOnlyCombo = True
            'Else
            '    ReadOnly = False
            'End If
        End Set
    End Property

End Class