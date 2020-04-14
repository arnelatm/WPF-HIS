' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class TranslatedCaption
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                'AddRule(New ValidateRequired("CaptionsName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property Caption As String
        Public Property CaptionIdNo As Integer
        Public Property LanguageIdNo As Integer
        Public Property TranslatedCaption As String
    End Class

End Namespace