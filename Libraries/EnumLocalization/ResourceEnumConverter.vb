Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources

Public Class ResourceEnumConverter
    Inherits EnumConverter

    Private Class LookupTable
        Inherits Dictionary(Of String, Object)
    End Class

    Private ReadOnly _
        _lookupTables As Dictionary(Of CultureInfo, LookupTable) = New Dictionary(Of CultureInfo, LookupTable)()

    Private ReadOnly _resourceManager As ResourceManager
    Private ReadOnly _isFlagEnum As Boolean = False
    Private ReadOnly _flagValues As Array

    Private Function GetLookupTable(culture As CultureInfo) As LookupTable
        Dim result As LookupTable = Nothing
        If culture Is Nothing Then culture = CultureInfo.CurrentCulture

        If Not _lookupTables.TryGetValue(culture, result) Then
            result = New LookupTable()

            For Each value As Object In GetStandardValues()
                Dim text As String = GetValueText(culture, value)

                If text IsNot Nothing Then
                    result.Add(text, value)
                End If
            Next

            _lookupTables.Add(culture, result)
        End If

        Return result
    End Function

    Public Function GetValueText(culture As CultureInfo, value As Object) As String
        Dim type As Type = value.[GetType]()
        Dim resourceName As String = String.Format("{0}_{1}", type.Name, value.ToString())
        Dim result As String = _resourceManager.GetString(resourceName, culture)
        If result Is Nothing Then result = resourceName
        Return result
    End Function

    'Public Function GetValueText(culture As CultureInfo, value As Object) As String
    '    Dim type As Type = value.[GetType]()
    '    Dim resourceName As String = String.Format("{0}_{1}", type.Name, value.ToString())
    '    Dim result As String = _resourceManager.GetString(resourceName, culture)
    '    If result Is Nothing Then result = resourceName
    '    Return result
    'End Function

    'Public Function GetEValueText(culture As CultureInfo, value As Object) As String
    '    Dim type As Type = value.[GetType]()
    '    Dim resourceName As String = String.Format("{0}_{1}", type.Name, value.ToString())
    '    Dim result As String = _resourceManager.GetString(resourceName, culture)
    '    If result Is Nothing Then result = resourceName
    '    Return result
    'End Function

    Private Function IsSingleBitValue(value As ULong) As Boolean
        Select Case value
            Case 0
                Return False
            Case 1
                Return True
        End Select

        Return ((value And (value - 1)) = 0)
    End Function

    Private Function GetFlagValueText(culture As CultureInfo, value As Object) As String
        If [Enum].IsDefined(value.[GetType](), value) Then
            Return GetValueText(culture, value)
        End If

        Dim lValue As ULong = Convert.ToUInt32(value)
        Dim result As String = Nothing

        For Each flagValue As Object In _flagValues
            Dim lFlagValue As ULong = Convert.ToUInt32(flagValue)

            If IsSingleBitValue(lFlagValue) Then

                If (lFlagValue And lValue) = lFlagValue Then
                    Dim valueText As String = GetValueText(culture, flagValue)

                    If result Is Nothing Then
                        result = valueText
                    Else
                        result = String.Format("{0}, {1}", result, valueText)
                    End If
                End If
            End If
        Next

        Return result
    End Function

    Private Function GetValue(culture As CultureInfo, text As String) As Object
        Dim lookupTable As LookupTable = GetLookupTable(culture)
        Dim result As Object = Nothing
        lookupTable.TryGetValue(text, result)
        Return result
    End Function

    Private Function GetFlagValue(culture As CultureInfo, text As String) As Object
        Dim lookupTable As LookupTable = GetLookupTable(culture)
        Dim textValues As String() = text.Split(","c)
        Dim result As ULong = 0

        For Each textValue As String In textValues
            Dim value As Object = Nothing
            Dim trimmedTextValue As String = textValue.Trim()

            If Not lookupTable.TryGetValue(trimmedTextValue, value) Then
                Return Nothing
            End If

            result = result Or Convert.ToUInt32(value)
        Next

        Return [Enum].ToObject(EnumType, result)
    End Function

    Public Sub New(type As Type, resourceManager As ResourceManager)
        MyBase.New(type)
        _resourceManager = resourceManager
        Dim flagAttributes As Object() = type.GetCustomAttributes(GetType(FlagsAttribute), True)
        _isFlagEnum = flagAttributes.Length > 0

        If _isFlagEnum Then
            _flagValues = [Enum].GetValues(type)
        End If
    End Sub

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) _
        As Object
        If TypeOf value Is String Then
            Dim result As Object = If((_isFlagEnum), GetFlagValue(culture, CStr(value)), GetValue(culture, CStr(value)))

            If result Is Nothing Then
                result = MyBase.ConvertFrom(context, culture, value)
            End If

            Return result
        Else
            If value Is Nothing Then
                Return Nothing
            End If
            Return MyBase.ConvertFrom(context, culture, value)
        End If
    End Function

    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object,
                                        destinationType As Type) As Object
        If value IsNot Nothing AndAlso destinationType = GetType(String) Then
            Dim result As Object = If((_isFlagEnum), GetFlagValueText(culture, value), GetValueText(culture, value))
            Return result
        Else
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End If
    End Function

    Public Overloads Shared Function ConvertToString(value As [Enum]) As String
        Dim converter As TypeConverter = TypeDescriptor.GetConverter(value.[GetType]())
        Return converter.ConvertToString(value)
    End Function

    Public Shared Function GetValues(enumType As Type, culture As CultureInfo) _
        As List(Of KeyValuePair(Of [Enum], String))
        Dim result = New List(Of KeyValuePair(Of [Enum], String))()
        Dim converter As TypeConverter = TypeDescriptor.GetConverter(enumType)

        For Each value As [Enum] In [Enum].GetValues(enumType)
            Dim pair = New KeyValuePair(Of [Enum], String)(value, converter.ConvertToString(Nothing, culture, value))
            result.Add(pair)
        Next

        Return result
    End Function

    Public Shared Function GetValues(enumType As Type) As List(Of KeyValuePair(Of [Enum], String))
        Return GetValues(enumType, CultureInfo.CurrentUICulture)
    End Function

    Public Shared Sub MakeResource(enumName As String, x As Type)
        ''Using fs As IO.FileStream = New IO.FileStream(Server.MapPath("~/TestResource.resx"), IO.FileMode.Create)
        'Using resx As New Resources.ResXResourceWriter("..\..\My Project\Resources.resx")
        '    Dim items As Array
        '    items = System.Enum.GetValues(x)
        '    Dim item As String
        '    Dim itName As String
        '    Dim i As Integer = 0
        '    For Each item In items
        '        itName = [Enum].GetName(x, i)
        '        resx.AddResource(EnumName & "_" & itName, itName)
        '        i = i + 1
        '    Next
        'End Using
        Dim reader = New ResXResourceReader("..\..\My Project\Resources.resx")
        Dim node = reader.GetEnumerator()
        Dim writer = New ResXResourceWriter("..\..\My Project\Resources.resx")

        While node.MoveNext()
            writer.AddResource(node.Key.ToString(), node.Value.ToString())
        End While

        'Dim newNode = New ResXDataNode("Title", "Classic American Cars")
        Dim items As Array
        items = [Enum].GetValues(x)
        Dim itName As String
        Dim i = 0
        For Each item In items
            itName = [Enum].GetName(x, i)
            writer.AddResource(enumName & "_" & itName, itName)
            i = i + 1
        Next
        writer.Generate()
        writer.Close()
    End Sub

End Class