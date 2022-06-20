Namespace PresentationLayer.Models

    Public Class EmployeeIdModel

        Public Sub New()
        End Sub

        Public Property IdNo As Int32
        Public Property EmployeeName As String
        Public Property NationalIdNo As String
        Public Property Errors As List(Of String)
        Public Property Picture As Image
        Public Property Print As Boolean

    End Class

End Namespace