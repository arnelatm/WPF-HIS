Imports System.Globalization

Public Class CalendarUtilities
    Private ReadOnly newCal As Calendar
    Private Shared isGregorian As Boolean

    Public Shared Sub ChangeCalendar(ci As CultureInfo, cal As Calendar)
        Dim util As New CalendarUtilities(cal)

        ' Is the new calendar already the current calendar?
        If util.CalendarExists(ci.DateTimeFormat.Calendar) Then
            Exit Sub
        End If

        ' Is the new calendar supported?
        If Array.Exists(ci.OptionalCalendars, AddressOf util.CalendarExists) Then
            ci.DateTimeFormat.Calendar = cal
        End If
    End Sub

    Private Sub New(cal As Calendar)
        newCal = cal

        ' Is the new calendar a Gregorian calendar?
        isGregorian = cal.GetType().Name.Contains("Gregorian")
    End Sub

    Public Shared ReadOnly Property HasGregorian As Boolean
        Get
            Return isGregorian
        End Get
    End Property

    Public Shared Function IsCalendarGregorian(cal As Calendar) As Boolean
        Dim calName As String = cal.ToString().Replace("System.Globalization.", "")
        If TypeOf cal Is GregorianCalendar Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CalendarExists(cal As Calendar) As Boolean
        If cal.ToString() = newCal.ToString Then
            If isGregorian Then
                If CType(cal, GregorianCalendar).CalendarType =
                   CType(newCal, GregorianCalendar).CalendarType Then
                    Return True
                End If
            Else
                Return True
            End If
        End If
        Return False
    End Function

    Public Shared Function ShowCalendarName(cal As Calendar) As String
        Dim calName As String = cal.ToString().Replace("System.Globalization.", "")
        If TypeOf cal Is GregorianCalendar Then
            calName += ", Type " + CType(cal, GregorianCalendar).CalendarType.ToString()
        End If
        Return calName
    End Function

End Class