Namespace BusinessRules
    ' validates a range (min and max) for a given data type

    Public Class ValidateRange
        Inherits BusinessRule

        Private Property DataType As ValidationDataType
        Private Property [Operator] As ValidationOperator

        Private Property Min As Object
        Private Property Max As Object

        Public Sub New(propertyName As String, min As Object, max As Object, [operator] As ValidationOperator,
                       dataType As ValidationDataType)
            MyBase.New(propertyName)
            Me.Min = min
            Me.Max = max

            Me.Operator = [operator]
            Me.DataType = dataType

            [Error] = propertyName & " must be between " & Me.Min.ToString() & " and " & Me.Max.ToString()
        End Sub

        Public Sub New(propertyName As String, errorMessage As String, min As Object, max As Object,
                       [operator] As ValidationOperator, dataType As ValidationDataType)
            Me.New(propertyName, min, max, [operator], dataType)
            [Error] = errorMessage
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim value As String = GetPropertyValue(businessObject).ToString()

                Select Case DataType
                    Case ValidationDataType.Integer

                        Dim imin As Integer = Integer.Parse(Min.ToString())
                        Dim imax As Integer = Integer.Parse(Max.ToString())
                        Dim ival As Integer = Integer.Parse(value)

                        Return (ival >= imin AndAlso ival <= imax)

                    Case ValidationDataType.Double
                        Dim dmin As Double = Double.Parse(Min.ToString())
                        Dim dmax As Double = Double.Parse(Max.ToString())
                        Dim dval As Double = Double.Parse(value)

                        Return (dval >= dmin AndAlso dval <= dmax)

                    Case ValidationDataType.Decimal
                        Dim cmin As Decimal = Decimal.Parse(Min.ToString())
                        Dim cmax As Decimal = Decimal.Parse(Max.ToString())
                        Dim cval As Decimal = Decimal.Parse(value)

                        Return (cval >= cmin AndAlso cval <= cmax)

                    Case ValidationDataType.Date
                        Dim tmin As Date = Date.Parse(Min.ToString())
                        Dim tmax As Date = Date.Parse(Max.ToString())
                        Dim tval As Date = Date.Parse(value)

                        Return (tval >= tmin AndAlso tval <= tmax)

                    Case ValidationDataType.String

                        Dim smin As String = Min.ToString()
                        Dim smax As String = Max.ToString()

                        Dim result1 As Integer = String.Compare(smin, value)
                        Dim result2 As Integer = String.Compare(value, smax)

                        Return result1 >= 0 AndAlso result2 <= 0
                End Select
                Return False
            Catch
                Return False
            End Try
        End Function
    End Class
End Namespace