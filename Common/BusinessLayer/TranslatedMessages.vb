' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class TranslatedMessages
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                'AddRule(New ValidateRequired("MessagesName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property OriginalIdNo As Integer
        Public Property LanguageIdNo As Integer
        Public Property TranslatedMessage As String
        Public Property TranslatedCaption As String

    End Class

End Namespace