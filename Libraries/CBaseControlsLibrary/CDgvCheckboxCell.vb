Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCheckboxCell
    Inherits DataGridViewCheckBoxCell
    Implements IEntryControl

    Public Sub New()
        MyBase.New()
    End Sub

    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom Checkbox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CDgvCheckBoxEditingControl)
        End Get
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set
            If Not AlwaysEditable Then
                _DisplayOnly = Value
                If Value Or DisplayOnly Then
                    Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    [ReadOnly] = True
                Else
                    Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    [ReadOnly] = False
                End If
            End If
        End Set
    End Property


    Public Overrides Function Clone() As Object
        Dim copy As CDgvCheckboxCell = TryCast(MyBase.Clone(), CDgvCheckboxCell)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function


    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
        End Set
    End Property


    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)
        'DataGridView.SuspendDrawingNew()
        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CDgvCheckBoxEditingControl)
        'DataGridView.ResumeDrawingNew()
    End Sub


    Public Property CellEditingControl As CDgvCheckBoxEditingControl
                [ReadOnly] = False
            Catch ex As Exception

            End Try

        End If
    End Sub


End Class