' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class OriginalCaptions
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("Caption"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property Caption As String
        Property TranslatedCaption As String
        Property IdNoTranslated As Integer
        Property LanguageIdNo As Integer
    End Class

End Namespace