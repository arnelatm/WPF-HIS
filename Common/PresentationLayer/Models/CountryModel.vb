Namespace PresentationLayer.Models

    Public Class CountryModel

        ' Country business object as seen by the Service client.
        Public Property Errors As List(Of String)

        Public Property CountryCode As String
        Public Property IdNo As Int16
        Public Property CountryName As String
        Public Property CountryNameAra As String
        Public Property Nationality As String
        Public Property NationalityAra As String
        Public Property Flag32 As String
        Public Property Flag128 As String
        Public Property Isoa3 As String
        Public Property Ison As String
        Public Property CountryTelCode As String
    End Class

End Namespace