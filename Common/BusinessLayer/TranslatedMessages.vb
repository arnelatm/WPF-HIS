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

        Public Property IdNo As Int32
        Public Property MessageIdNo As Int32
        Public Property LanguageIdNo As Int32
        Public Property TranslatedMessage As String
        Public Property TranslatedCaption As String
    End Class

End Namespace