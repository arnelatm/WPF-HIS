Namespace BusinessRules
    ' represents a validation rules that states that a value is required

    Public Class ValidateRequiredOne
        Inherits BusinessRule

        Private ReadOnly _propertyNames() As String

        Public Sub New(ByVal ParamArray propertyNames() As String)
            MyBase.New(propertyNames)
            _propertyNames = propertyNames
            [Error] = "You must enter a value on one of these fields!"
        End Sub

        Public Sub New(errorMessage As String, ParamArray propertyNames() As String)
            MyBase.New(propertyNames)
            _propertyNames = propertyNames
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                'Return (From propertyName In _propertyNames Select GetPropertyValue(businessObject)).Any(Function(propValue) propValue IsNot Nothing)
                Dim valid = False
                For Each propertyName In _propertyNames
                    Dim propValue = GetPropertyValue(businessObject, propertyName)
                    If propValue IsNot Nothing Then
                        If _
                            TypeOf (propValue) Is Int32 OrElse TypeOf (propValue) Is Int16 OrElse
                            TypeOf (propValue) Is Decimal OrElse TypeOf (propValue) Is Short OrElse
                            TypeOf (propValue) Is Long Then
                            If propValue <> 0 Then
                                valid = True
                                Exit For
                            End If
                        ElseIf TypeOf (propValue) Is String Then
                            If propValue <> "" Then
                                valid = True
                                Exit For
                            End If
                        End If
                    End If
                Next
                Return valid
            Catch
                Return False
            End Try
        End Function

        Private Shadows Function GetPropertyValue(businessObject As BusinessObject, propertyName As String) As Object
            ' note: reflection is relatively slow
            Return businessObject.GetType().GetProperty(propertyName).GetValue(businessObject, Nothing)
        End Function

    End Class

End Namespace