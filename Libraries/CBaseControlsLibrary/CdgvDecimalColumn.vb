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

    Public Sub SetFormat(ByVal length As UInt16, ByVal decimalPlaces As UInt16)
        DefaultCellStyle.Format = StrDup(length - decimalPlaces - 2, "#") + "0." + StrDup(decimalPlaces, "0")
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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

End Class