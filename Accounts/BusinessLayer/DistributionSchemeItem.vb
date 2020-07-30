' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class DistributionSchemeItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Int32
        Public Property DistributionSchemeIdNo As Int32
        Public Property Sequence As Integer
        Public Property RevCostCenterIdNo As Int32
        Public Property RevCostCenterName As String
        Public Property Percentage As Decimal
    End Class

End Namespace