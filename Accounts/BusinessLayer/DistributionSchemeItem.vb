' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class DistributionSchemeItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Integer
        Public Property DistributionSchemeIdNo As Integer
        Public Property Sequence As Integer
        Public Property ProfitCenterIdNo As Integer
        Public Property ProfitCenterName As String
        Public Property Percentage As Decimal
    End Class
End NameSpace