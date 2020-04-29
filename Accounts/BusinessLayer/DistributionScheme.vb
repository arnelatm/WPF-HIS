' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DistributionScheme
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("DistributionSchemeName"))
        End Sub

        Public Property DistributionSchemeCode As String
        Public Property DistributionSchemeName As String
        Public Property DistributionSchemeNameAra As String
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property TotalPercentage As Decimal
        Public Property ValidityEndDate As Date
        Public Property ValidityStartDate As Date
        Public Property DistributionSchemeItems As List(Of DistributionSchemeItem)
    End Class

End Namespace