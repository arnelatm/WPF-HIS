Imports System.ComponentModel

Friend Class CornerConverter : Inherits ExpandableObjectConverter

    Public Overrides Function GetCreateInstanceSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function CreateInstance(ByVal context As ITypeDescriptorContext, ByVal propertyValues As System.Collections.IDictionary) As Object
        Dim crn As New CornersProperty
        Dim AL As Int32 = CType(propertyValues("All"), Int32)
        Dim LL As Int32 = CType(propertyValues("LowerLeft"), Int32)
        Dim LR As Int32 = CType(propertyValues("LowerRight"), Int32)
        Dim UL As Int32 = CType(propertyValues("UpperLeft"), Int32)
        Dim UR As Int32 = CType(propertyValues("UpperRight"), Int32)

        Dim oAll As Int32 = CType(CType(context.Instance, CButton).Corners, CornersProperty).All

        If oAll <> AL And AL > -1 Then
            crn.All = AL
        Else
            crn.LowerLeft = LL
            crn.LowerRight = LR
            crn.UpperLeft = UL
            crn.UpperRight = UR

        End If

        Return crn
    End Function

    Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext,
                                                       ByVal sourceType As System.Type) As Boolean

        If (sourceType Is GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext,
                                                    ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
        If TypeOf value Is String Then
            Try
                Dim s As String = CType(value, String)
                Dim cornerParts(4) As String
                cornerParts = Split(s, ",")
                If Not IsNothing(cornerParts) Then
                    If IsNothing(cornerParts(0)) Then cornerParts(0) = "0"
                    If IsNothing(cornerParts(1)) Then cornerParts(1) = "0"
                    If IsNothing(cornerParts(2)) Then cornerParts(2) = "0"
                    If IsNothing(cornerParts(3)) Then cornerParts(3) = "0"
                    Return New CornersProperty(CInt(cornerParts(0).Trim),
                                               CInt(cornerParts(1).Trim),
                                               CInt(cornerParts(2).Trim),
                                               CInt(cornerParts(3).Trim))
                End If
            Catch ex As Exception
                Throw New ArgumentException(String.Format("Can not convert '{0}' to type Corners", CStr(value)))
            End Try
        Else
            Return New CornersProperty()
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext,
                                                  ByVal culture As System.Globalization.CultureInfo,
                                                  ByVal value As Object, ByVal destinationType As System.Type) As Object

        Dim _Corners As CornersProperty = CType(value, CornersProperty)
        If (destinationType Is GetType(System.String) AndAlso TypeOf value Is CornersProperty) Then
            ' build the string as "UpperLeft, UpperRight, LowerLeft, LowerRight"
            Return String.Format("{0}, {1}, {2}, {3}",
                                 _Corners.LowerLeft,
                                 _Corners.LowerRight,
                                 _Corners.UpperLeft,
                                 _Corners.UpperRight)
        Else
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End If

    End Function

End Class