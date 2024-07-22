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

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            [ReadOnly] = False
        Else
            Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            Try
                [ReadOnly] = True
            Catch ex As Exception

            End Try

        End If
    End Sub

End Class