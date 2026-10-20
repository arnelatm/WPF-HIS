Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvDecimalCell
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    Protected Overrides Function GetFormattedValue(value As Object,
                                                   rowIndex As Integer,
                                                   ByRef cellStyle As DataGridViewCellStyle,
                                                   valueTypeConverter As TypeConverter,
                                                   formattedValueTypeConverter As TypeConverter,
                                                   context As DataGridViewDataErrorContexts) As Object
        If TypeOf value Is Decimal AndAlso String.IsNullOrEmpty(cellStyle.Format) Then
            ' Normalize scale-only differences without guessing precision or changing the value.
            Dim displayStyle = cellStyle.Clone()
            displayStyle.Format = NumericGridFormatting.UnspecifiedDecimalFormat
            Return MyBase.GetFormattedValue(value, rowIndex, displayStyle, valueTypeConverter, formattedValueTypeConverter, context)
        End If
        Return MyBase.GetFormattedValue(value, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
    End Function

    Public Overrides Function Clone() As Object
        Dim copy = DirectCast(MyBase.Clone(), CDgvDecimalCell)
        copy.DisplayOnly = DisplayOnly
        copy._editingMode = _editingMode
        copy._translatable = _translatable
        Return copy
    End Function

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            [ReadOnly] = False
            Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            [ReadOnly] = False
            Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            [ReadOnly] = True
        End If
    End Sub

    Sub New()
        If GlobalVariables.RightToLeftLayout Then
            Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Else
            Style.Alignment = DataGridViewContentAlignment.MiddleRight
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

End Class
