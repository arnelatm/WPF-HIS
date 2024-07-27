Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCheckBoxColumn
    Inherits DataGridViewCheckBoxColumn
    Implements IEntryControl, IFindableControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        CellTemplate = New CDgvCheckboxCell
        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        FlatStyle = FlatStyle.Standard
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            Dim dataGridViewCheckBoxCell As CDgvCheckboxCell = TryCast(value, CDgvCheckboxCell)
            If value IsNot Nothing AndAlso dataGridViewCheckBoxCell Is Nothing Then
                Throw New InvalidCastException("Must be a CDgvCheckBoxCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False

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
            If Not AlwaysEditable Then
                _editingMode = value
                If value Then
                    [ReadOnly] = False
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    _displayOnly = True
                Else
                    [ReadOnly] = False
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    _displayOnly = False
                End If
            Else
                _displayOnly = False
                Me.ReadOnly = False
            End If
            CType(CellTemplate, CDgvCheckboxCell).DisplayOnly = _displayOnly
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            If Not AlwaysEditable Then
                _editingMode = value
            End If
            UpdateDisplayOnlyControl()
            CType(CellTemplate, CDgvCheckboxCell).EditingMode = _editingMode
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            If [ReadOnly] Then
                [ReadOnly] = False
            End If
        Else
            [ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Try
                [ReadOnly] = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
            CType(CellTemplate, CDgvCheckboxCell).Translatable = _translatable
        End Set
    End Property

    'Public Property LinkedLabel As CLabel Implements IEntryControl.LinkedLabel

    'Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements IEntryControl.GetControlDescription
    '    Dim description As String
    '    If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
    '        description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
    '    Else
    '        description = LinkedLabel.Text
    '    End If
    '    Return description
    'End Function

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType

    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue

    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace

    Public Property FieldName As String Implements IFindableControl.FieldName

    Public Property FieldDescription As String Implements IFindableControl.FieldDescription

    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource

    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember

    Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

End Class