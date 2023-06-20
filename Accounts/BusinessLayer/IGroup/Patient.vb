' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports System.Web.Services

Namespace BusinessLayer

    Public Class Patient
        Property RegistrationNo As Int32
        Property Series As String
        Property PatientNameEnglish As String
        Property Gender As String
        Property Age As String
        Property AgeYMD As String

    End Class

    Public Class PatientPrescription
        Inherits Patient
        Property PrescriptionDetails As List(Of PrescriptionDetail)

    End Class

    'Public Class Prescription

    '    Property ItemNameEnglish As String
    '    Property DosageEnglish As String
    '    Property Duration As String

    'End Class

End Namespace