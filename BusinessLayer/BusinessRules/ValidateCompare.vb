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

    End Class

End Namespace