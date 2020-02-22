Namespace BusinessRules
    Module ValidateFunctions
        Private Property [Operator] As ValidationOperator

        Public Function ValidateExpression(businessObject As BusinessObject, pProperty As String, pDataType As ValidationDataType, pOperator As ValidationOperator, pValue As Object) As Boolean
            Try
                Dim propValue As String = businessObject.GetType().GetProperty(pProperty).GetValue(businessObject, Nothing).ToString()

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

                        Dim cval As Decimal = Decimal.Parse(propValue)

                        Select Case pOperator
                            Case ValidationOperator.Equal
                                Return cval = pValue
                            Case ValidationOperator.NotEqual
                                Return cval <> pValue
                            Case ValidationOperator.GreaterThan
                                Return cval > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return cval >= pValue
                            Case ValidationOperator.LessThan
                                Return cval < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return cval <= pValue
                        End Select

                    Case ValidationDataType.Date

                        Dim tval As Date = Date.Parse(propValue)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return tval = pValue
                            Case ValidationOperator.NotEqual
                                Return tval <> pValue
                            Case ValidationOperator.GreaterThan
                                Return tval > pValue
                            Case ValidationOperator.GreaterThanOrEqual
                                Return tval >= pValue
                            Case ValidationOperator.LessThan
                                Return tval < pValue
                            Case ValidationOperator.LessThanOrEqual
                                Return tval <= pValue
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
    End Module
End Namespace