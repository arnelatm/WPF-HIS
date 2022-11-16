' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class GTinMatcher
        Inherits ItemDetails

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property DrugTradeName As String

        Public Property DrugPackageSize As Double?
        Public Property DrugPackageType As String
        Public Property DrugRegistrationNo As String
        Public Property DrugStrengthValue As String
        Public Property DrugUnitOfStrength As String
        Public Property DrugUnitOfVolume As String
        Public Property DrugUserId As String
        Public Property DrugVolume As Double?
        Public Property DrugPrescriptionDrug As Boolean
        Public Property DrugRouteOfAdministration As String

    End Class

End Namespace