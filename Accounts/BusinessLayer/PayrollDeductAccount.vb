' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayrollDeductAccount
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property AccountIdNo As Int16
        Public Property AccountName As String
        Public Property DeductionIdNo As Int16
        Public Property IdNo As Int32
        Public Property PayGroupIdNo As Int16
        Public Property PayGroupName As String
        Public Property Sequence As Int16

    End Class

End Namespace