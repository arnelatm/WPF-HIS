' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ReportSelector
        Inherits Report

        Public Property ReportList As List(Of Report)

    End Class

End Namespace