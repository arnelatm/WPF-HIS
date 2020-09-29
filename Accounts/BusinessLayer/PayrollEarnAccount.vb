' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayrollEarnAccount
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property EarningIdNo As Int16
        Public Property IdNo As Int32
        Public Property PayGroupIdNo As Int16
        Public Property PayGroupName As String
        Public Property AccountIdNo As Int16
        Public Property AccountName As String

    End Class

End Namespace