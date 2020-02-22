' compares values of two properties given a data type and operator  (>, ==, etc)
Namespace BusinessRules
    Public Class ValidateValue
        Inherits BusinessRule

        Private Property OtherPropertyName As String
        Private Property DataType As ValidationDataType
        Private Property [Operator] As ValidationOperator

        Public Sub New(propertyName As String, otherPropertyName As String, [operator] As ValidationOperator,
                       dataType As ValidationDataType)
            MyBase.New(propertyName)

            Me.OtherPropertyName = otherPropertyName
            Me.Operator = [operator]
            Me.DataType = dataType
            Select Case [operator]
                Case ValidationOperator.Equal
                    [Error] = propertyName & " must be equal to " & otherPropertyName
                Case ValidationOperator.NotEqual
                    [Error] = propertyName & " must not be equal to " & otherPropertyName
                Case ValidationOperator.GreaterThan
                    [Error] = propertyName & " must be greater than " & otherPropertyName
                Case ValidationOperator.GreaterThanOrEqual
                    [Error] = propertyName & " must be greater than or equal to " & otherPropertyName
                Case ValidationOperator.LessThan
                    [Error] = propertyName & " must be less than " & otherPropertyName
                Case ValidationOperator.LessThanOrEqual
                    [Error] = propertyName & " must be less than or equal to " & otherPropertyName
            End Select
        End Sub

        Public Sub New(propertyName As String, otherPropertyName As String, errorMessage As String,
                       [operator] As ValidationOperator, dataType As ValidationDataType)
            Me.New(propertyName, otherPropertyName, [operator], dataType)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim propValue1 As String =
                        businessObject.GetType().GetProperty([Property]).GetValue(businessObject, Nothing).ToString()
                Dim propValue2 As String =
                        businessObject.GetType().GetProperty(OtherPropertyName).GetValue(businessObject, Nothing).
                        ToString()

                Select Case DataType
                    Case ValidationDataType.Integer

                        Dim ival1 As Integer = Integer.Parse(propValue1)
                        Dim ival2 As Integer = Integer.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return ival1 = ival2
                            Case ValidationOperator.NotEqual
                                Return ival1 <> ival2
                            Case ValidationOperator.GreaterThan
                                Return ival1 > ival2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return ival1 >= ival2
                            Case ValidationOperator.LessThan
                                Return ival1 < ival2
                            Case ValidationOperator.LessThanOrEqual
                                Return ival1 <= ival2
                        End Select

                    Case ValidationDataType.Double

                        Dim dVal1 As Double = Double.Parse(propValue1)
                        Dim dVal2 As Double = Double.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return Math.Abs(dVal1 - dVal2) < 0.00001
                            Case ValidationOperator.NotEqual
                                Return Math.Abs(dVal1 - dVal2) > 0.00001
                            Case ValidationOperator.GreaterThan
                                Return dVal1 > dVal2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return dVal1 >= dVal2
                            Case ValidationOperator.LessThan
                                Return dVal1 < dVal2
                            Case ValidationOperator.LessThanOrEqual
                                Return dVal1 <= dVal2
                        End Select

                    Case ValidationDataType.Decimal

                        Dim cval1 As Decimal = Decimal.Parse(propValue1)
                        Dim cval2 As Decimal = Decimal.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return cval1 = cval2
                            Case ValidationOperator.NotEqual
                                Return cval1 <> cval2
                            Case ValidationOperator.GreaterThan
                                Return cval1 > cval2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return cval1 >= cval2
                            Case ValidationOperator.LessThan
                                Return cval1 < cval2
                            Case ValidationOperator.LessThanOrEqual
                                Return cval1 <= cval2
                        End Select

                    Case ValidationDataType.Date

                        Dim tval1 As Date = Date.Parse(propValue1)
                        Dim tval2 As Date = Date.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return tval1 = tval2
                            Case ValidationOperator.NotEqual
                                Return tval1 <> tval2
                            Case ValidationOperator.GreaterThan
                                Return tval1 > tval2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return tval1 >= tval2
                            Case ValidationOperator.LessThan
                                Return tval1 < tval2
                            Case ValidationOperator.LessThanOrEqual
                                Return tval1 <= tval2
                        End Select

                    Case ValidationDataType.String

                        Dim result As Integer = String.Compare(propValue1, propValue2, StringComparison.CurrentCulture)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return result = 0
                            Case ValidationOperator.NotEqual
                                Return result <> 0
                            Case ValidationOperator.GreaterThan
                                Return result > 0
                            Case ValidationOperator.GreaterThanOrEqual
                                Return result >= 0
                            Case ValidationOperator.LessThan
                                Return result < 0
                            Case ValidationOperator.LessThanOrEqual
                                Return result <= 0
                        End Select

                End Select
                Return False
            Catch
                Return False
            End Try
        End Function

        Public Function ValidateExpression(businessObject As BusinessObject, pProperty As String,
                                           pDataType As ValidationDataType, pOperator As ValidationOperator,
                                           pValue As Object) As Boolean
            Try
                Dim propValue As String =
                        businessObject.GetType().GetProperty(pProperty).GetValue(businessObject, Nothing).ToString()

                Select Case DataType
                    Case ValidationDataType.Integer

                        Dim ival As Integer = Integer.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return ival = pValue
                            Case ValidationOperator.NotEqual
                                Return ival <> pValue
                            Case ValidationOperator.GreaterThan
                                Return ival > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return ival >= pValue
                            Case ValidationOperator.LessThan
                                Return ival < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return ival <= pValue
                        End Select

                    Case ValidationDataType.Double

                        Dim dVal As Double = Double.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.NotEqual
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.GreaterThan
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.GreaterThanOrEqual
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.LessThan
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.LessThanOrEqual
                                Return Math.Abs(dVal - pValue) < 0.00001
                        End Select

                    Case ValidationDataType.Decimal

                        Dim cVal As Decimal = Decimal.Parse(propValue)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return cVal = pValue
                            Case ValidationOperator.NotEqual
                                Return cVal = pValue
                            Case ValidationOperator.GreaterThan
                                Return cVal = pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return cVal = pValue
                            Case ValidationOperator.LessThan
                                Return cVal = pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return cVal = pValue
                        End Select

                    Case ValidationDataType.Date

                        Dim tval As Date = Date.Parse(propValue)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return tval = pValue
                            Case ValidationOperator.NotEqual
                                Return tval = pValue
                            Case ValidationOperator.GreaterThan
                                Return tval = pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return tval = pValue
                            Case ValidationOperator.LessThan
                                Return tval = pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return tval = pValue
                        End Select

                    Case ValidationDataType.String

                        Dim result As Integer = String.Compare(propValue, pValue, StringComparison.CurrentCulture)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return result = 0
                            Case ValidationOperator.NotEqual
                                Return result <> 0
                            Case ValidationOperator.GreaterThan
                                Return result > 0
                            Case ValidationOperator.GreaterThanOrEqual
                                Return result >= 0
                            Case ValidationOperator.LessThan
                                Return result < 0
                            Case ValidationOperator.LessThanOrEqual
                                Return result <= 0
                        End Select

                End Select
                Return False
            Catch
                Return False
            End Try
        End Function
    End Class
End Namespace