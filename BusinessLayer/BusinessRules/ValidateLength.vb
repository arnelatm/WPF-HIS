Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace BusinessRules
    ' length validation rule.
    ' length must be between given min and max values

    Public Class ValidateLength
        Inherits BusinessRule

        Private ReadOnly _min As Integer
        Private ReadOnly _max As Integer

        Public Sub New(propertyName As String, min As Integer, max As Integer)
            MyBase.New(propertyName)
            Dim fieldName = Messaging.TranslateCaption(propertyName.SplitCamelCase)
            Dim errorMessage As String
            _min = min
            _max = max
            If _min <> _max Then
                errorMessage = Messaging.GetParametrizedMessage(True, "MsgInvalidTextLength", {"fieldName", fieldName, "minimumLength", min.ToString(), "maximumLength", max.ToString()})
            Else
                errorMessage = Messaging.GetParametrizedMessage(True, "MsgExactTextLength", {"fieldName", fieldName, "minimumLength", min.ToString()})
            End If
            [Error] = errorMessage
        End Sub

        Public Sub New(propertyName As String, errorMessage As String, min As Integer, max As Integer)
            Me.New(propertyName, min, max)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Dim length As Integer
            length = GetPropertyValue(businessObject).ToString().Length
            'Dim length As Integer = GetPropertyValue(businessObject).ToString().Length
            Return length >= _min AndAlso length <= _max
        End Function

    End Class

End Namespace