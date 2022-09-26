Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CMaskedTextBox1
    Inherits MaskedTextBox
    Implements IEntryControl, IFindableControl, ILinkedLabel

    Private _defaultVal As String
    Private _isNumeric As Boolean
    Private _oldValue As String
    Private _oldText As String

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will only accept numeric values.")>
    <Browsable(True)>
    Public Property ValueIsNumeric As Boolean

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to the lowest allowed value for this control")>
    <Browsable(True)>
    Public Property MinimumValue As Decimal? = Nothing

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to the highest allowed value for this control")>
    <Browsable(True)>
    Public Property MaximumValue As Decimal? = Nothing

    Public Property DateTimePickerParent As Control = Nothing

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is readonly.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this field will contain a date.")>
    <Browsable(True)>
    Public Property DateField As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    Public Property ValueIsNullable As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Default Value that this control will have if initialized or cleared.")>
    <Browsable(True)>
    Public Property DefaultValue As String

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Mask to treat as empty value")>
    <Browsable(True)>
    Public Property EmptyMask As String = ""

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("Specify here the displayed field name to search")>
    <Browsable(True)>
    Public Property SearchField As String

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Property Translatable As Boolean Implements IEntryControl.Translatable

    Public Property EditsAllowed As Boolean

#Region "FindableControl"

    <Category("Custom Properties")>
    <Description("Set to True to enable find on this field.")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Get
            Return IFindableControl.SearchModeEnum.Date
        End Get
    End Property

    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember
        Get
            Return Nothing
        End Get
    End Property

    Private Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue

    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Public Property FieldName As String Implements IFindableControl.FieldName

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType
        Get
            Return IFindableControl.DataTypeEnum.Date
        End Get
        Set(value As IFindableControl.DataTypeEnum)

        End Set
    End Property

    Public Property FieldDescription As String Implements IFindableControl.FieldDescription

    Public Function GetControlDescription(Optional description As String = Nothing) As Object Implements ILinkedLabel.GetControlDescription
        Throw New NotImplementedException()
    End Function

#End Region

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    MakeVisible(visibleControl)
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub
End Class