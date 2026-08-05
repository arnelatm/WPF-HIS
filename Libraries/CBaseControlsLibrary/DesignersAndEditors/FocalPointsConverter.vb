Imports System.ComponentModel

Friend Class FocalPointsConverter : Inherits ExpandableObjectConverter

    Public Overrides Function GetCreateInstanceSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function CreateInstance(ByVal context As ITypeDescriptorContext, ByVal propertyValues As System.Collections.IDictionary) As Object
        Dim fPt As New cFocalPoints
        fPt.CenterPtX = CType(propertyValues("CenterPtX"), Single)
        fPt.CenterPtY = CType(propertyValues("CenterPtY"), Single)
        fPt.FocusPtX = CType(propertyValues("FocusPtX"), Single)
        fPt.FocusPtY = CType(propertyValues("FocusPtY"), Single)
        Return fPt
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
                Dim s As String = CType(value, String)
                Dim FocalPointsParts(4) As String
                FocalPointsParts = Split(s, ",")
                If Not IsNothing(FocalPointsParts) Then
                    If IsNothing(FocalPointsParts(0)) Then FocalPointsParts(0) = "0.5"
                    If IsNothing(FocalPointsParts(1)) Then FocalPointsParts(1) = "0.5"
                    If IsNothing(FocalPointsParts(2)) Then FocalPointsParts(2) = "0"
                    If IsNothing(FocalPointsParts(3)) Then FocalPointsParts(3) = "0"
                    Return New cFocalPoints(CSng(FocalPointsParts(0).Trim),
                                            CSng(FocalPointsParts(1).Trim),
                                            CSng(FocalPointsParts(2).Trim),
                                            CSng(FocalPointsParts(3).Trim))
                End If
            Catch ex As Exception
                Throw New ArgumentException(String.Format("Can not convert '{0}' to type FocalPoints", CStr(value)))
            End Try
        Else
            Return New cFocalPoints()
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext,
                                                  ByVal culture As System.Globalization.CultureInfo,
                                                  ByVal value As Object, ByVal destinationType As System.Type) As Object

        If (destinationType Is GetType(System.String) AndAlso TypeOf value Is cFocalPoints) Then
            Dim _FocalPoints As cFocalPoints = CType(value, cFocalPoints)

            ' build the string as "UpperLeft,UpperRight,LowerLeft,LowerRight"
            Return String.Format("{0}, {1}, {2}, {3}", _FocalPoints.CenterPtX, _FocalPoints.CenterPtY, _FocalPoints.FocusPtX, _FocalPoints.FocusPtY)
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)

    End Function

End Class