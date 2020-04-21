' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class OriginalMessages
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("MessageKey"))
                AddRule(New ValidateRequired("Message"))
            End If
        End Sub

        Public Property Caption As String
        Public Property IdNo As Integer
        Public Property IdNoTranslated As Integer
        Public Property LanguageIdNo As Integer
        Public Property Message As String
        Public Property MessageKey As String
        Public Property Notes As String
        Public Property TranslatedCaption As String
        Public Property TranslatedMessage As String

    End Class

End Namespace