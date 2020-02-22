Imports System.Text.RegularExpressions

Namespace BusinessRules
    ' base class for regex based validation rules.

    Public Class ValidateRegex
        Inherits BusinessRule

        Protected Property Pattern As String

        Public Sub New(propertyName As String, pattern As String)
            MyBase.New(propertyName)
            Me.Pattern = pattern
        End Sub

        Public Sub New(propertyName As String, errorMessage As String, pattern As String)
            Me.New(propertyName, pattern)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Dim bo = GetPropertyValue(businessObject)
            Dim boS As String
            If bo Is Nothing Then
                boS = Nothing
            Else
                boS = bo.ToString()
            End If
            Dim bok = Regex.Match(boS, Pattern).Success
            Return bok
            'Return Regex.Match(GetPropertyValue(businessObject).ToString(), Pattern).Success
        End Function
    End Class
End Namespace