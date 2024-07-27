Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.VisualBasic.PowerPacks

Public Class CDgvCheckboxCell
    Inherits DataGridViewCheckBoxCell
    Implements IEntryControl


    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        MyBase.New()
    End Sub


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False

    Public Property CellEditingControl As CDgvCheckBoxEditingControl

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
            Debugger.Break()
        End Set
    End Property

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom Checkbox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvCheckBoxEditingControl)
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

    Public Overrides Function Clone() As Object
        Dim copy As CDgvCheckboxCell = TryCast(MyBase.Clone(), CDgvCheckboxCell)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)


        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CDgvCheckBoxEditingControl)

    End Sub

    'Public Sub UpdateDisplayOnlyControl()
    '    If _editingMode And Not DisplayOnly Then
    '        Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
    '        Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
    '        [ReadOnly] = False
    '    Else
    '        Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
    '        Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '        Try
    '            [ReadOnly] = True
    '        Catch ex As Exception

    '        End Try

    '    End If
    'End Sub

End Class