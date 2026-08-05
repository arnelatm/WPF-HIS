Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvDecimalColumn
    Inherits DataGridViewColumn
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        CellTemplate = New CDgvDecimalCell
        DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Public Sub SetFormat(ByVal length As UInt16, ByVal nDecimalPlaces As UInt16)
        DefaultCellStyle.Format = StrDup(length - nDecimalPlaces - 2, "#") + "0." + StrDup(nDecimalPlaces, "0")
    End Sub

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

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    '<EditorBrowsable(EditorBrowsableState.Always), Bindable(True)>
    '<Description("Set to the number of decimal places to display.")>
    '<Browsable(True)>
    'Public Property DecimalPlaces As Int16
    '    Get
    '        Return _decimalPlaces
    '    End Get
    '    Set(value As Int16)
    '        _decimalPlaces = value
    '    End Set
    'End Property

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    '<EditorBrowsable(EditorBrowsableState.Always), Bindable(True)>
    '<Description("Set to the total length of the number including decimal places and period.")>
    '<Browsable(True)>
    'Public Property Length As Int16
    '    Get
    '        Return _length
    '    End Get
    '    Set(value As Int16)
    '        _length = value
    '    End Set
    'End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            [ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            [ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            [ReadOnly] = True
        End If
    End Sub

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to the number of decimal places to display value")>
    <Browsable(True)>
    Public Property DecimalPlaces As Integer = -1

End Class