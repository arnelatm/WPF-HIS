Namespace BusinessRules
    ' identity validation rule.
    ' value must be integer and greater than zero

    Public Class ValidateId
        Inherits BusinessRule

        Public Sub New(propertyName As String)
            MyBase.New(propertyName)
            [Error] = propertyName & " is an invalid identifier"
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            MyBase.New(propertyName)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim id As Integer = Integer.Parse(GetPropertyValue(businessObject).ToString())
                Return id >= 0
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace