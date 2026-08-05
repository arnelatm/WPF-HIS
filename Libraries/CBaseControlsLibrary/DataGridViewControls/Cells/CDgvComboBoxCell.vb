' This is the class that represents your cell which can use your ComboBox class
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

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

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CtComboBoxEditingControl)
        End Get
    End Property

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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    Public Property TreatZeroAsBlank As Boolean

    Protected Overrides Function GetFormattedValue(value As Object,
                                                   rowIndex As Integer,
                                                   ByRef cellStyle As DataGridViewCellStyle,
                                                   valueTypeConverter As TypeConverter,
                                                   formattedValueTypeConverter As TypeConverter,
                                                   context As DataGridViewDataErrorContexts) As Object
        If TreatZeroAsBlank AndAlso IsZeroValue(value) Then
            Return String.Empty
        End If

        Return MyBase.GetFormattedValue(value, rowIndex, cellStyle, valueTypeConverter, formattedValueTypeConverter, context)
    End Function

    Public Overrides Function Clone() As Object
        Dim copy As CDgvComboBoxCell = TryCast(MyBase.Clone(), CDgvComboBoxCell)
        If copy IsNot Nothing Then
            copy.DisplayOnly = DisplayOnly
            copy.EditingMode = EditingMode
            copy.Translatable = Translatable
            copy.TreatZeroAsBlank = TreatZeroAsBlank
        End If

        Return copy
    End Function

    Private Shared Function IsZeroValue(value As Object) As Boolean
        If value Is Nothing OrElse value Is DBNull.Value Then Return False

        Dim numericValue As Decimal
        Return Decimal.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Number, CultureInfo.InvariantCulture, numericValue) AndAlso
               numericValue = 0D
    End Function



    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)
        DataGridView.SuspendDrawingNew()
        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CtComboBoxEditingControl)
        DataGridView.ResumeDrawingNew()
    End Sub

    Public Property CellEditingControl As CtComboBoxEditingControl


End Class

