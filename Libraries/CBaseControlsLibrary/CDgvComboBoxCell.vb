' This is the class that represents your cell which can use your ComboBox class
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CDgvComboBoxCell
    Inherits DataGridViewComboBoxCell
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        MyBase.New()
        AutoComplete = False
    End Sub

    Public Property CellEditingControl As CtComboBoxEditingControl

    <DisplayName("DisplayOnly")>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <EditorBrowsable(EditorBrowsableState.Always), Bindable(True)>
    <Description("Set to True to specify that this control's value cannot be edited or changed.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            _displayOnly = value
            If value Then
                _editingMode = False
            End If
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
        End Set
    End Property

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CtComboBoxEditingControl)
        End Get
    End Property
    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell

    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)
        'DataGridView.SuspendDrawingNew()
        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CtComboBoxEditingControl)
        CellEditingControl.SetSuggestDataSource()
        'DataGridView.ResumeDrawingNew()
    End Sub

    'Public Overrides Function Clone() As Object

    '    Dim copy As CtComboBoxCell = TryCast(MyBase.Clone(), CtComboBoxCell)
    '    'copy.DisplayOnly = CellEditingControl.DisplayOnly
    '    'copy.EditingMode = CellEditingControl.EditingMode
    '    'copy.Translatable = CellEditingControl.Translatable
    '    'copy.DisplayMember = CellEditingControl.DisplayMember
    '    'copy.ValueMember = CellEditingControl.ValueMember
    '    Return copy
    'End Function
End Class