Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvColumnText
    Inherits DataGridViewTextBoxColumn
    Implements IEntryControl, IFindableControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean

    Public Sub New()
        CellTemplate = New CdgvCellText
    End Sub

    ' ReSharper disable once LocalizableElement
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
                _editingMode = True
            End If
        End Set
    End Property

    Public Overrides Function Clone() As Object
        Dim copy As CDgvColumnText = TryCast(MyBase.Clone(), CDgvColumnText)
        copy.DisplayOnly = DisplayOnly
        Return copy
    End Function

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    [ReadOnly] = True
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                Else
                    [ReadOnly] = False
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    [ReadOnly] = False
                End If
            Else
                [ReadOnly] = True
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    [ReadOnly] = editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    ' not applicable
    'End Sub
    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType

    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled
    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue
    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue
    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace
    Public Property FieldName As String Implements IFindableControl.FieldName
    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember
    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember
End Class