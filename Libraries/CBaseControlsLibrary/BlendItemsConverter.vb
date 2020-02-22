Imports System.ComponentModel
Imports System.Drawing

<System.Diagnostics.DebuggerStepThrough()>
Friend Class BlendItemsConverter : Inherits ExpandableObjectConverter

    Public Overrides Function GetCreateInstanceSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function CreateInstance(ByVal context As ITypeDescriptorContext, ByVal propertyValues As System.Collections.IDictionary) As Object
        Dim bItem As New cBlendItems
        bItem.iColor = CType(propertyValues("iColor"), Color())
        bItem.iPoint = CType(propertyValues("iPoint"), Single())
        Return bItem
    End Function

    Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As System.Type) As Boolean
        If (sourceType Is GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext,
                                                    ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object

        If TypeOf value Is String Then
            Try
                Dim s As String() = Split(CType(value, String), "|")
                Dim bColors As New List(Of Color)
                Dim bPoints As New List(Of Single)

                For Each cstring As String In Split(s(0), ";")
                    bColors.Add(CType(TypeDescriptor.GetConverter(
                        GetType(Color)).ConvertFromString(cstring), Color))
                Next
                For Each cstring As String In Split(s(1), ";")
                    bPoints.Add(CType(TypeDescriptor.GetConverter(
                        GetType(Single)).ConvertFromString(cstring), Single))
                Next

                If Not IsNothing(bColors) AndAlso Not IsNothing(bPoints) Then
                    If bColors.Count <> bPoints.Count Then Throw New ArgumentException(String.Format("Can not convert '{0}' to type cBlendItem", CStr(value)))

                    Return New cBlendItems(bColors.ToArray, bPoints.ToArray)
                End If
            Catch ex As Exception
                Throw New ArgumentException(String.Format("Can not convert '{0}' to type cBlendItem", CStr(value)))
            End Try
        Else
            Return New cBlendItems()
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext,
                                                  ByVal culture As System.Globalization.CultureInfo,
                                                  ByVal value As Object, ByVal destinationType As Type) As Object

        If (destinationType Is GetType(String) AndAlso TypeOf value Is cBlendItems) Then
            Dim _BlendItems As cBlendItems = CType(value, cBlendItems)

            ' build the string as "Color1;Color2;Color3|Pt1;Pt2;Pt3"
            Dim bColors As New ArrayList
            Dim bPoints As New ArrayList
            For Each bColor As Color In _BlendItems.iColor
                If bColor.IsNamedColor Then
                    bColors.Add(bColor.Name)
                Else
                    bColors.Add(String.Format("{0},{1},{2},{3}", bColor.A, bColor.R, bColor.G, bColor.B))
                End If

            Next
            For Each bPoint As Single In _BlendItems.iPoint
                bPoints.Add(bPoint.ToString)
            Next

            Return String.Format("{0}|{1}", Join(bColors.ToArray, ";"), Join(bPoints.ToArray, ";"))
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)

    End Function

End Class