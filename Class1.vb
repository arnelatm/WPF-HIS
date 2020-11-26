Imports System
Imports System.Runtime.InteropServices

Public Class Person
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property City As String
    Public Property State As String

    Public Sub New(ByVal fname As String, ByVal mname As String, ByVal lname As String, ByVal cityName As String, ByVal stateName As String)
        FirstName = fname
        MiddleName = mname
        LastName = lname
        City = cityName
        State = stateName
    End Sub

    ' Return the first and last name.
    Public Sub Deconstruct(<Out> ByRef fname As String, <Out> ByRef lname As String)
        fname = FirstName
        lname = LastName
    End Sub

    Public Sub Deconstruct(<Out> ByRef fname As String, <Out> ByRef mname As String, <Out> ByRef lname As String)
        fname = FirstName
        mname = MiddleName
        lname = LastName
    End Sub

    Public Sub Deconstruct(<Out> ByRef fname As String, <Out> ByRef lname As String, <Out> ByRef city As String, <Out> ByRef state As String)
        fname = FirstName
        lname = LastName
        city = Me.City
        state = Me.State
    End Sub
End Class

Public Class Example
    Public Shared Sub Main()
        Dim p = New Person("John", "Quincy", "Adams", "Boston", "MA")
        Dim fName_City_ = Nothing

        ' <Snippet1>
        ' Deconstruct the person object.
        (fName, _, city, _) = p
        Console.WriteLine($"Hello {fName} of {city}!")
        ' The example displays the following output:
        '      Hello John of Boston!
        ' </Snippet1>
    End Sub
End Class ' The example displays the following output:
'    Hello John Adams of Boston, MA!