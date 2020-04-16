Imports System.Globalization
Imports System.Runtime.CompilerServices

Namespace AdoNet
    ' useful set of Extension methods for Data Access purposes

    Public Module Extensions
        ' transform object into Identity data type (integer).

        <Extension>
        Public Function AsId(item As Object, Optional ByVal defaultId As Integer = -1) As Integer
            If item Is Nothing Then
                Return defaultId
            End If

            Dim result As Integer
            If Not Integer.TryParse(item.ToString(), result) Then
                Return defaultId
            End If
            Return result
        End Function

        ' transform object into integer data type.

        <Extension>
        Public Function AsInt(Of T)(item As Object, Optional ByVal defaultInt As T = Nothing) As T
            Dim result As T
            Try

                If item Is Nothing Or item Is DBNull.Value Then
                    result = defaultInt
                ElseIf Not IsNumeric(item) Then
                    result = defaultInt
                Else
                    result = CType(item, T)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            Return result
        End Function

        <Extension>
        Public Function AsNumber(Of T)(item As Object, Optional ByVal defaultValue As T = Nothing) As T
            Dim result As T = Convert.ChangeType(0, GetType(T))
            Try

                If IsDBNull(item) Or item Is Nothing Then
                    Return defaultValue
                End If

                'If Not Integer.TryParse(item.ToString(), result) Then
                result = Convert.ChangeType(item, GetType(T))
            Catch ex As Exception
                MessageBox.Show("Conversion error (AsNumber Extensions). " & ex.Message)
            End Try

            Return result
        End Function

        <Extension>
        Public Function AsNullableInt(Of T)(item As Object) As T
            If item.Equals(DBNull.Value) Then
                'Dim retVal As Integer?
                'retVal = DirectCast(Nothing, Nullable(Of Integer))
                Return Nothing
            End If

            Dim result As T
            Try
                result = Convert.ChangeType(item, GetType(T))
            Catch ex As Exception
                result = Nothing ' DirectCast(Nothing, Nullable(Of Integer))
            End Try
            Return result
        End Function

        ' transform object into double data type

        <Extension>
        Public Function AsDouble(item As Object, Optional ByVal defaultDouble As Double = Nothing) As Double
            If item Is Nothing Then
                Return defaultDouble
            End If

            Dim result As Double
            If Not Double.TryParse(item.ToString(), result) Then
                Return defaultDouble
            End If

            Return result
        End Function

        ' transform object into double data type

        <Extension>
        Public Function AsDecimal(item As Object, Optional ByVal defaultDecimal As Decimal = Nothing) As Decimal
            If item Is Nothing Then
                Return defaultDecimal
            End If

            Dim result As Decimal
            If Not Decimal.TryParse(item.ToString(), result) Then
                Return defaultDecimal
            End If

            Return result
        End Function

        ' transform object into string data type

        <Extension>
        Public Function AsString(item As Object, Optional ByVal defaultString As String = Nothing) As String
            If item Is Nothing OrElse item.Equals(DBNull.Value) Then
                Return defaultString
            End If
            Return item.ToString().Trim()
        End Function

        ' transform object into char data type

        <Extension>
        Public Function AsChar(item As Object, Optional ByVal defaultChar As Char = Nothing) As Char
            If item Is Nothing OrElse item.Equals(DBNull.Value) Then
                Return defaultChar
            End If
            Return item.ToChar().Trim()
        End Function

        ' transform object into DateTime data type.

        <Extension>
        Public Function AsDate(item As Object)
            If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) Then
                Return Now
            End If
            Dim retDate As Date
            Try
                retDate = Convert.ToDateTime(item)
            Catch ex As Exception
                retDate = Now
            End Try
            Return retDate
        End Function

        <Extension>
        Public Function AsDateTime(item As Object, Optional ByVal defaultDateTime As Date? = Nothing) As Date?
            If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) Then
                Return defaultDateTime
            End If
            Dim retDate As Date?
            Try
                'round datetime values to seconds, ignore milliseconds
                'date comparison fails sometimes because of difference of milliseconds
                retDate = New DateTime(item.Year, item.Month, item.Day, item.Hour, item.Minute, item.Second)
            Catch ex As Exception
                Debugger.Break()
                retDate = Nothing
            End Try
            Return retDate
        End Function

        ' transform object into DateTime data type.

        <Extension>
        Public Function AsNullableDateTime(item As Object, Optional ByVal defaultDateTime As Date = Nothing) As Date?
            'Date.TryParse(item.ToString(), result)
            If item.Equals(DBNull.Value) Then
                Return Nothing
            Else
                Dim result As Date
                Date.TryParse(item.ToString(), result)
                Return result
            End If
        End Function

        ' transform object into String in date format "yyyy/mm/dd"
        Public Function AsShortDateString(item As Object, Optional ByVal defaultDateTime As Date = Nothing) As String
            Dim result As String
            If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) Then
                Return Nothing
            End If
            '' original date is in the format 'yyyy/mm/dd'
            Dim resultDate As Date
            Try
                resultDate = DateTime.ParseExact(item, "yyyy/MM/dd", CultureInfo.InvariantCulture)
            Catch ex As Exception
                Return Nothing
            End Try
            'If item Is Nothing OrElse item.Equals(System.DBNull.Value) Then
            '    Return Nothing
            'End If
            result = resultDate.ToShortDateString()
            Return result
        End Function

        ' transform object into String in date format "yyyy/mm/dd"
        Public Function AsDateFromYmd(item As Object, Optional ByVal defaultDateTime As Date? = Nothing) As Date?
            Dim result As Date
            If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) Then
                Return Nothing
            End If
            '' original date is in the format 'yyyy/mm/dd'
            Try

                'If Date.TryParseExact(dateString, "dd-MMM-yyyy", Nothing, DateTimeStyles.None, myDate) Then
                result = DateTime.ParseExact(item, "yyyy/MM/dd", CultureInfo.InvariantCulture)
            Catch ex As Exception
                Return Nothing
            End Try
            Return result
        End Function

        ' transform object into String in date format "yyyy/MM/dd"
        Public Function AsYyyyMmDdString(item As Object, Optional ByVal defaultDateTime As Date? = Nothing) As String
            Dim result As String
            If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) Then
                Return Nothing
            End If

            Dim resultDate As Date
            If Not Date.TryParse(item.ToString(), resultDate) Then
                Return Nothing
            End If
            resultDate = Date.Parse(item.ToString())
            'myDate.ToString("yyyy/MM/dd")
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture
            result = resultDate.ToString("yyyy/MM/dd")
            CultureInfo.CurrentCulture = curCulture
            Return result
        End Function

        ' transform object into bool data type

        <Extension>
        Public Function AsBool(item As Object, Optional ByVal defaultBool As Boolean = False) As Boolean
            If item Is Nothing Then
                Return defaultBool
            End If
            Dim x As Boolean
            x = New List(Of String)() From {"yes", "y", "true", "1"}.Contains(item.ToString().ToLower())
            Return x
            'Return New List(Of String)() From {"yes", "y", "true"}.Contains(item.ToString().ToLower())
        End Function

        ' transform string into byte array

        <Extension>
        Public Function AsByteArray(s As String) As Byte()
            If String.IsNullOrEmpty(s) Then
                Return Nothing
            End If

            Return Convert.FromBase64String(s)
        End Function

        ' transform object into base64 string.

        <Extension>
        Public Function AsBase64String(item As Object) As String
            If item Is Nothing Then
                Return Nothing
            End If
            Return Convert.ToBase64String(CType(item, Byte()))
        End Function

        ' transform object into Guid data type

        <Extension>
        Public Function AsGuid(item As Object) As Guid
            Try
                Return New Guid(item.ToString())
            Catch
                Return Guid.Empty
            End Try
        End Function

        ' concatenates SQL and ORDER BY clauses into a single string

        <Extension>
        Public Function OrderBy(sql As String, sortExpression As String) As String
            If String.IsNullOrEmpty(sortExpression) Then
                Return sql
            End If

            Return sql & " ORDER BY " & sortExpression
        End Function

        ' takes an enumerable source and returns a comma separate string.
        ' handy for building SQL Statements (for example with IN () statements) from object collections

        <Extension>
        Public Function CommaSeparate(Of T, TU)(source As IEnumerable(Of T), func As Func(Of T, TU)) As String
            Return String.Join(",", source.Select(Function(s) func(s).ToString()).ToArray())
        End Function

    End Module
End Namespace