' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ReportSelector
        Inherits CrReport

        Public Property ReportList As List(Of CrReport)

    End Class

End Namespace