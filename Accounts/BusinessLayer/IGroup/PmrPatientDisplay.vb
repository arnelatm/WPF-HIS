' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field


Namespace BusinessLayer

    Public Class PmrPatientDisplay
        Inherits AATM.BusinessLayer.BusinessObject

        Property [Token] As String
        Property [Status] As String
        Property [File_No] As String
        Property [Name] As String
        Property [Type]
        Property [Inv_Type]
        Property [CreateDate]
    End Class

End Namespace