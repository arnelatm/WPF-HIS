Public Class Employee
    Public Property IdNo() As Integer
    Public Property EmployeeName() As String
    Public Property Picture() As Image

    Public Overrides Function ToString() As String
        Return EmployeeName
    End Function
End Class
