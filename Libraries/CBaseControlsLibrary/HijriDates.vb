Imports System.Globalization

Public Class HijriDates
    Private Const startGreg As Integer = 1700
    Private Const endGreg As Integer = 2300

    Private ReadOnly _
        allFormats As String() =
            {"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d",
             "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy",
             "dd M yyyy", "d MM yyyy"}

    Private ReadOnly arCul As CultureInfo
    Private ReadOnly enCul As CultureInfo
    Private ReadOnly h As UmAlQuraCalendar
    Private g As GregorianCalendar

    Public Sub New()
        arCul = New CultureInfo("ar-SA")
        enCul = New CultureInfo("en-US")
        h = New UmAlQuraCalendar()
        g = New GregorianCalendar(GregorianCalendarTypes.USEnglish)
        arCul.DateTimeFormat.Calendar = h
    End Sub

    Public Function IsHijri(hijri As String) As Boolean
        If hijri.Length <= 0 Then
            Return False
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)

            If tempDate.Year >= startGreg AndAlso tempDate.Year <= endGreg Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsGreg(greg As String) As Boolean
        If greg.Length <= 0 Then
            Return False
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)

            If tempDate.Year >= startGreg AndAlso tempDate.Year <= endGreg Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function FormatHijri(Hdate As String, format As String) As String
        If Hdate.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(Hdate, allFormats, arCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function FormatGreg(Hdate As String, format As String) As String
        If Hdate.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(Hdate, allFormats, enCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GDateNow() As String
        Try
            Return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GDateNow(format As String) As String
        Try
            Return DateTime.Now.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HDateNow() As String
        Try
            Return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HDateNow(format As String) As String
        Try
            Return DateTime.Now.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HijriToGreg(hijri As String) As String
        If hijri.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HijriToGreg(hijri As String, format As String) As String
        If hijri.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GregToHijri(greg As String) As String
        If greg.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GregToHijri(greg As String, format As String) As String
        If greg.Length <= 0 Then
            Return ""
        End If

        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat,
                                                           DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GTimeStamp() As String
        Return GDateNow("yyyyMMddHHmmss")
    End Function

    Public Function HTimeStamp() As String
        Return HDateNow("yyyyMMddHHmmss")
    End Function

    Public Function Compare(d1 As String, d2 As String) As Integer
        Try
            Dim date1 As DateTime = DateTime.ParseExact(d1, allFormats, arCul.DateTimeFormat,
                                                        DateTimeStyles.AllowWhiteSpaces)
            Dim date2 As DateTime = DateTime.ParseExact(d2, allFormats, arCul.DateTimeFormat,
                                                        DateTimeStyles.AllowWhiteSpaces)
            Return DateTime.Compare(date1, date2)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function Is29(iMonth As Integer, iYear As Integer) As Integer
        Try
            Return If(arCul.Calendar.GetDaysInMonth(iYear, iMonth) = 29, 1, 0)
        Catch e As Exception
            Return -1
        End Try
    End Function

End Class