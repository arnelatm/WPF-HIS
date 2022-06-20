' PensionSchemeCode business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PensionScheme
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PensionSchemeName"))
                AddRule(New ValidateRequired("PensionSchemeCode"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("PensionProviderIdNo"))
            End If
        End Sub

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16?

        Public Property IdNo As Int16
        Public Property Notes As String
        Public Property PensionProviderIdNo As Int16
        Public Property PensionSchemeCode As String
        Public Property PensionSchemeName As String
        Public Property PensionSchemeNameAra As String
        Public Property PensionRates As List(Of PensionRate)

    End Class

End Namespace