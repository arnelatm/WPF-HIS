' compares values of two properties given a data type and operator  (>, ==, etc)
Namespace BusinessRules

    Public Class ValidateIfRequired
        Inherits ValidateRequired

        '        Private Property OtherPropertyName As String
        '        Private Property DataType As ValidationDataType
        '        Private Property [Operator] As ValidationOperator
        Private ReadOnly _conditionPropertyName As String

        Private ReadOnly _conditionValue As Object
        Private ReadOnly _conditionOperator As ValidationOperator
        Private ReadOnly _conditionDataType As ValidationDataType

        Public Sub New(propertyName As String,
                       conditionPropertyName As String,
                       conditionDataType As ValidationDataType,
                       conditionOperator As ValidationOperator,
                       conditionValue As Object)
            MyBase.New(propertyName)
            _conditionPropertyName = conditionPropertyName
            _conditionValue = conditionValue
            _conditionOperator = conditionOperator
            _conditionDataType = conditionDataType
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Dim retVal = True
            If _
                ValidateExpression(businessObject, _conditionPropertyName, _conditionDataType, _conditionOperator,
                                   _conditionValue) Then
                retVal = MyBase.Validate(businessObject)
            End If
            Return retVal
        End Function

    End Class

End Namespace