' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.DataLayer

Namespace BusinessLayer

    Public Class CkJournal
        Inherits DisbursementJournal

        Public Property CheckDate As Date?
        Public Property CheckNumber As String

    End Class

End Namespace