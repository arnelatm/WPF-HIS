Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries.GlobalFuncNSub

Namespace BusinessLayer.BusinessRules
    ' represents a validation rules that states that a value is required

    Public Class ValidateAccounts
        Inherits BusinessRule

        Private ReadOnly _propertyNames() As String

        Public Sub New(propertyName As String)
            MyBase.New(propertyName)
            [Error] = propertyName & " invalid accounts."
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            MyBase.New(propertyName)
            [Error] = errorMessage
        End Sub

        'Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
        '    Try
        '        Dim propValue = GetPropertyValue(businessObject)
        '        If propValue Is Nothing Then
        '            Return False
        '        End If
        '        Return GetPropertyValue(businessObject).ToString().Length > 0
        '    Catch
        '        Return False
        '    End Try
        'End Function

        Public Overrides Function Validate(businessObject As AATM.BusinessLayer.BusinessObject) As Boolean
            Try
                If _propertyNames Is Nothing Then
                    Try
                        Dim propValue = GetPropertyValue(businessObject)
                        If GlobalFunctions.IsEmpty(propValue) Then
                            Return False
                        End If
                        Return True
                    Catch
                        Return False
                    End Try
                Else
                    'Return (From propertyName In _propertyNames Select GetPropertyValue(businessObject)).Any(Function(propValue) propValue IsNot Nothing)
                    For Each propertyName In _propertyNames
                        Dim propValue = GetPropertyValue(businessObject, propertyName)
                        If Not IsEmpty(propValue) Then
                            Return True
                        End If
                    Next
                    Return False
                End If
            Catch
                Return False
            End Try
        End Function

        Private Overloads Function GetPropertyValue(businessObject As AATM.BusinessLayer.BusinessObject, propertyName As String) As Object
            ' note: reflection is relatively slow
            Return businessObject.GetType().GetProperty(propertyName).GetValue(businessObject, Nothing)
        End Function

    End Class

End Namespace