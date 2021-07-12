Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace BusinessRules
    ' validates a range (min and max) for a given data type

    Public Class ValidateRange
        Inherits BusinessRule

        Private Property DataType As ValidationDataType
        Private Property [Operator] As ValidationOperator

        Private Property Min As Object
        Private Property Max As Object

        Public Sub New(propertyName As String, min As Object, max As Object, dataType As ValidationDataType)
            MyBase.New(propertyName)
            Dim fieldName = Messaging.TranslateCaption(propertyName.SplitCamelCase)
            Dim errorMessage = Messaging.GetParametrizedMessage(True, "MsgInvalidRange", {"fieldName", fieldName, "minimumValue", min.ToString(), "maximumValue", max.ToString()})
            Me.Min = min
            Me.Max = max
            Me.Operator = [Operator]
            Me.DataType = dataType
            [Error] = errorMessage
        End Sub

        Public Sub New(propertyName As String, errorMessage As String, min As Object, max As Object,
                       [operator] As ValidationOperator, dataType As ValidationDataType)
            Me.New(propertyName, min, max, dataType)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim value = GetPropertyValue(businessObject)

                Select Case DataType
                    Case ValidationDataType.Integer

                        Dim iMin As Integer = Integer.Parse(Min.ToString())
                        Dim iMax As Integer = Integer.Parse(Max.ToString())
                        Dim iVal As Integer = IIf(value Is Nothing, 0, Integer.Parse(value.ToString()))

                        Return (iVal >= iMin AndAlso iVal <= iMax)

                    Case ValidationDataType.Double
                        Dim dMin As Double = Double.Parse(Min.ToString())
                        Dim dMax As Double = Double.Parse(Max.ToString())
                        Dim dVal As Double = IIf(value Is Nothing, 0, Double.Parse(value))

                        Return (dVal >= dMin AndAlso dVal <= dMax)

                    Case ValidationDataType.Decimal
                        Dim cMin As Decimal = Decimal.Parse(Min.ToString())
                        Dim cMax As Decimal = Decimal.Parse(Max.ToString())
                        Dim cVal As Decimal = IIf(value Is Nothing, 0, Decimal.Parse(value))

                        Return (cVal >= cMin AndAlso cVal <= cMax)

                    Case ValidationDataType.Date
                        Dim tMin As Date = Date.Parse(Min.ToString())
                        Dim tMax As Date = Date.Parse(Max.ToString())
                        Dim tVal As Date = IIf(value Is Nothing, Date.MinValue, Date.Parse(value))

                        Return (tVal.TrimMilliseconds() >= tMin.TrimMilliseconds() AndAlso tVal.TrimMilliseconds() <= tMax.TrimMilliseconds())

                    Case ValidationDataType.String

                        Dim sMin As String = Min.ToString()
                        Dim sMax As String = Max.ToString()

                        Dim result1 As Integer = String.Compare(sMin, IIf(value Is Nothing, "", value))
                        Dim result2 As Integer = String.Compare(sMax, IIf(value Is Nothing, "", value))

                        Return result1 <= 0 AndAlso result2 >= 0
                End Select
                Return False
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace