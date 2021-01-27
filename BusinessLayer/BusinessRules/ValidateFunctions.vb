Namespace BusinessRules
    Module ValidateFunctions
        Private Property [Operator] As ValidationOperator

        Public Function ValidateExpression(businessObject As BusinessObject, pProperty As String,
                                           pDataType As ValidationDataType, pOperator As ValidationOperator,
                                           pValue As Object) As Boolean
            Try
                Dim boPropValue As Object = businessObject.GetType().GetProperty(pProperty).GetValue(businessObject, Nothing)
                Dim propValue As String
                If boPropValue Is Nothing Then
                    propValue = Nothing
                Else
                    propValue = boPropValue.ToString()
                End If

                Select Case pDataType
                    Case ValidationDataType.Integer

                        Dim iVal As Integer = Integer.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return iVal = pValue
                            Case ValidationOperator.NotEqual
                                Return iVal <> pValue
                            Case ValidationOperator.GreaterThan
                                Return iVal > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return iVal >= pValue
                            Case ValidationOperator.LessThan
                                Return iVal < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return iVal <= pValue
                        End Select

                    Case ValidationDataType.Double

                        Dim dVal As Double = Double.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return Math.Abs(dVal - pValue) < 0.00001
                            Case ValidationOperator.NotEqual
                                Return Math.Abs(dVal - pValue) > 0.00001
                            Case ValidationOperator.GreaterThan
                                Return dVal > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return dVal >= pValue
                            Case ValidationOperator.LessThan
                                Return dVal < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return dVal <= pValue
                        End Select

                    Case ValidationDataType.Decimal

                        Dim cVal As Decimal = Decimal.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return cVal = pValue
                            Case ValidationOperator.NotEqual
                                Return cVal <> pValue
                            Case ValidationOperator.GreaterThan
                                Return cVal > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return cVal >= pValue
                            Case ValidationOperator.LessThan
                                Return cVal < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return cVal <= pValue
                        End Select

                    Case ValidationDataType.Date

                        Dim tVal As Date = Date.Parse(propValue)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return tVal = pValue
                            Case ValidationOperator.NotEqual
                                Return tVal <> pValue
                            Case ValidationOperator.GreaterThan
                                Return tVal > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return tVal >= pValue
                            Case ValidationOperator.LessThan
                                Return tVal < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return tVal <= pValue
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

                    Case ValidationDataType.Boolean

                        Dim bVal As Boolean = Boolean.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return If(pValue, bVal, Not bVal)
                            Case ValidationOperator.NotEqual
                                Return If(pValue, Not bVal, bVal)
                            Case Else
                                Return True
                        End Select
                End Select
                Return False
            Catch
                Return False
            End Try
        End Function

    End Module
End Namespace