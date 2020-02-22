' compares values of two properties given a data type and operator  (>, ==, etc)
Namespace BusinessRules
    Public Class ValidateContent
        Inherits BusinessRule

        Private Property PropertyValue As Object
        Private Property DataType As ValidationDataType
        Private Property [Operator] As ValidationOperator

        Public Sub New(propertyName As String, propertyValue As Object, [operator] As ValidationOperator,
                       dataType As ValidationDataType)
            MyBase.New(propertyName)

            Me.PropertyValue = propertyValue
            Me.Operator = [operator]
            Me.DataType = dataType
            Select Case [operator]
                Case ValidationOperator.Equal
                    [Error] = propertyName & " must be equal to " & propertyValue.ToString()
                Case ValidationOperator.NotEqual
                    [Error] = propertyName & " must not be equal to " & propertyValue.ToString()
                Case ValidationOperator.GreaterThan
                    [Error] = propertyName & " must be greater than " & propertyValue.ToString()
                Case ValidationOperator.GreaterThanOrEqual
                    [Error] = propertyName & " must be greater than or equal to " & propertyValue.ToString()
                Case ValidationOperator.LessThan
                    [Error] = propertyName & " must be less than " & propertyValue.ToString()
                Case ValidationOperator.LessThanOrEqual
                    [Error] = propertyName & " must be less than or equal to " & propertyValue.ToString()
            End Select
        End Sub

        Public Sub New(propertyName As String, propertyValue As Object, errorMessage As String,
                       [operator] As ValidationOperator, dataType As ValidationDataType)
            Me.New(propertyName, propertyValue, [operator], dataType)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim propValue1 As String =
                        businessObject.GetType().GetProperty([Property]).GetValue(businessObject, Nothing).ToString()
                Dim propValue2 As String = PropertyValue

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

                        Dim dval1 As Double = Double.Parse(propValue1)
                        Dim dval2 As Double = Double.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return Math.Abs(dval1 - dval2) < 0.0001
                            Case ValidationOperator.NotEqual
                                Return Math.Abs(dval1 - dval2) > 0.0001
                            Case ValidationOperator.GreaterThan
                                Return dval1 > dval2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return dval1 >= dval2
                            Case ValidationOperator.LessThan
                                Return dval1 < dval2
                            Case ValidationOperator.LessThanOrEqual
                                Return dval1 <= dval2
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
    End Class
End Namespace