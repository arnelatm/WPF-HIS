' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field


Namespace BusinessLayer

    Public Class PmrPatientDisplay
        Inherits AATM.BusinessLayer.BusinessObject

        Property [Token] As String
        Property [Status] As String
        Property [File_No] As String
        Property [Name] As String
        Property [Type] As String
        Property [Inv_Type] As String
        Property [CreateDate] As DateTime
    End Class

End Namespace