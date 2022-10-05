' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class PmrPatientDisplay
        Inherits AATM.BusinessLayer.BusinessObject

        Property [CreateDate] As DateTime
        Property [Name] As String
        Property [Status] As Boolean
        Property [Token] As String
        Property PType As String
        Property FileNo As String
        Property InvType As String

    End Class

End Namespace