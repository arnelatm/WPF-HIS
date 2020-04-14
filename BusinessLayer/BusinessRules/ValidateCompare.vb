' compares values of two properties given a data type and operator  (>, ==, etc)
Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports AATM.Libraries.GlobalFuncNSub

Namespace BusinessRules

    Public Class ValidateCompare
        Inherits BusinessRule

        Private Property PropertyName As String
        Private Property OtherPropertyName As String
        Private Property DataType As ValidationDataType
        Private Property [Operator] As ValidationOperator

        Public Sub New(propertyName As String, otherPropertyName As String, [operator] As ValidationOperator,
                       dataType As ValidationDataType)
            MyBase.New(propertyName)
            Dim strError As String = ""
            Me.PropertyName = propertyName
            Me.OtherPropertyName = otherPropertyName
            Me.Operator = [operator]
            Me.DataType = dataType
            Select Case [operator]
                Case ValidationOperator.Equal
                    MakeError($"MsgValidationCompareEqual", "must be equal to")
                Case ValidationOperator.NotEqual
                    MakeError($"MsgValidationCompareNotEqual", "must not be equal to")
                Case ValidationOperator.GreaterThan
                    MakeError($"MsgValidationCompareGreaterThan", "must be greater than")
                Case ValidationOperator.GreaterThanOrEqual
                    MakeError($"MsgValidationCompareGreaterThanOrEqualTo", "must be greater than or equal to")
                Case ValidationOperator.LessThan
                    MakeError($"MsgValidationCompareLessThan", "must be less than")
                Case ValidationOperator.LessThanOrEqual
                    MakeError($"MsgValidationCompareLessThanOrEqualTo", "must be less than or equal to")
            End Select
        End Sub

        Private Sub MakeError(errMessageKey As String, errMessageText As String)
            Dim strError = "{propertyName} " + errMessageText + " {otherPropertyName}"
            strError = Dac.GetMessage(errMessageKey, strError, "Validation Error")
            [Error] = strError.Interpolate(Function(x) PropertyName, Function(x) OtherPropertyName)
        End Sub

        Public Sub New(propertyName As String, otherPropertyName As String, errorMessage As String,
                       [operator] As ValidationOperator, dataType As ValidationDataType)
            Me.New(propertyName, otherPropertyName, [operator], dataType)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim propValue1 = businessObject.GetType().GetProperty([Property]).GetValue(businessObject, Nothing)
                Dim propValue2 = businessObject.GetType().GetProperty(OtherPropertyName).GetValue(businessObject,
                                                                                                  Nothing)

                Select Case DataType
                    Case ValidationDataType.Integer

                        Dim iVal1 As Integer? = If(propValue1 Is Nothing, Nothing, Integer.Parse(propValue1))
                        Dim iVal2 As Integer? = If(propValue2 Is Nothing, Nothing, Integer.Parse(propValue2))

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return iVal1 = iVal2
                                'Return EqualityComparer(Of Integer).[Default].Equals(ival1, ival2)
                            Case ValidationOperator.NotEqual
                                Return iVal1 <> iVal2
                                'Return Not EqualityComparer(Of Integer).[Default].Equals(ival1, ival2)
                            Case ValidationOperator.GreaterThan
                                'EqualityComparer(Of Integer).[Default].Equals(ival1, ival2)
                                Return iVal1 > iVal2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return iVal1 >= iVal2
                            Case ValidationOperator.LessThan
                                Return iVal1 < iVal2
                            Case ValidationOperator.LessThanOrEqual
                                Return iVal1 <= iVal2
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

                        Dim cVal1 As Decimal = Decimal.Parse(propValue1)
                        Dim cVal2 As Decimal = Decimal.Parse(propValue2)

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return cVal1 = cVal2
                            Case ValidationOperator.NotEqual
                                Return cVal1 <> cVal2
                            Case ValidationOperator.GreaterThan
                                Return cVal1 > cVal2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return cVal1 >= cVal2
                            Case ValidationOperator.LessThan
                                Return cVal1 < cVal2
                            Case ValidationOperator.LessThanOrEqual
                                Return cVal1 <= cVal2
                        End Select

                    Case ValidationDataType.Date

                        Dim tVal1 As Date? = If(propValue1 Is Nothing, Nothing, Date.Parse(propValue1))
                        Dim tVal2 As Date? = If(propValue2 Is Nothing, Nothing, Date.Parse(propValue2))

                        Select Case [Operator]
                            Case ValidationOperator.Equal
                                Return tVal1 = tVal2
                            Case ValidationOperator.NotEqual
                                Return tVal1 <> tVal2
                            Case ValidationOperator.GreaterThan
                                Return tVal1 > tVal2
                            Case ValidationOperator.GreaterThanOrEqual
                                Return tVal1 >= tVal2
                            Case ValidationOperator.LessThan
                                Return tVal1 < tVal2
                            Case ValidationOperator.LessThanOrEqual
                                Return tVal1 <= tVal2
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