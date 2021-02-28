Imports System.Xml.Serialization
Imports System.IO
Imports System.ComponentModel

Public Class SetSettings

    Private _appSettings As New AppSettings()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        _appSettings = AppSettings.Load()
        PropertyGrid.SelectedObject = _appSettings

        '' Add any initialization after the InitializeComponent() call.
        'PropertyGrid.SelectedObject = My.Settings()
        ''_appSettings = PropertyGrid.SelectedObject
        '' Attribute for the user-scope settings.
        'Dim userAttr As New System.Configuration.UserScopedSettingAttribute
        'Dim attrs As New System.ComponentModel.AttributeCollection(userAttr)
        'PropertyGrid.BrowsableAttributes = attrs
    End Sub

    Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
        _appSettings.Save()
    End Sub

End Class

<Serializable()>
Public Class AppSettings
    Private _deductionRule As String

    <TypeConverter(GetType(DeductionComputationRule)),
    CategoryAttribute("Payroll Settings"), DefaultValueAttribute(""),
    DescriptionAttribute("Select a rule from the list")>
    Public Property DeductionRule() As String
        Get
            Return _deductionRule
        End Get
        Set(ByVal Value As String)
            _deductionRule = Value
        End Set
    End Property

    Public Shared Function Load() As AppSettings
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(AppSettings))
        Dim retVal As AppSettings
        Dim reader As TextReader
        Dim fileNotFound As Boolean

        Try
            reader = New StreamReader("AccountSettings.xml")
        Catch ex As FileNotFoundException
            'Take the defaults
            fileNotFound = True
        End Try

        If fileNotFound Then
            retVal = New AppSettings
        Else
            'Read it from the file
            retVal = serializer.Deserialize(textReader:=reader)
        End If
        reader.Close()
        Return retVal
    End Function

    Public Sub Save()
        Dim serializer As New XmlSerializer(GetType(AppSettings))
        Dim writer As TextWriter
        writer = New StreamWriter("AccountSettings.xml")
        serializer.Serialize(writer, Me)
        writer.Close()
    End Sub

End Class

Public Class StatesList : Inherits System.ComponentModel.StringConverter

    '''
    Dim _States As String() = New String() {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia",
                                            "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts",
                                            "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico",
                                            "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina",
                                            "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"}

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(_States)
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

End Class

Public Class DeductionComputationRule : Inherits System.ComponentModel.StringConverter

    '''
    Dim _deductionRule As String() = New String() {"Use 30 days per month", "User No. of days in a month", "Use 26 days per month"}

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(_deductionRule)
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

End Class