Imports AATM.ServicesLayer.Services

Public NotInheritable Class EstablishmentInformation

    Public Property EnglishName As String
    Public Property ArabicName As String

End Class

Public NotInheritable Class EstablishmentInformationProvider

    Private Const PrimaryEstablishmentIdNo As Int32 = 1

    Private Sub New()
    End Sub

    Public Shared Function Load(service As IService) As EstablishmentInformation
        If service Is Nothing Then
            Throw New ArgumentNullException(NameOf(service))
        End If

        Return New EstablishmentInformation With {
            .EnglishName = service.GetRecordFieldWithKeyG(Of String, Int32)(
                PrimaryEstablishmentIdNo,
                "Establishment",
                "IdNo",
                "EstablishmentName"),
            .ArabicName = service.GetRecordFieldWithKeyG(Of String, Int32)(
                PrimaryEstablishmentIdNo,
                "Establishment",
                "IdNo",
                "EstablishmentNameAra")}
    End Function

End Class
