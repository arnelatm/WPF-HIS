' Category business object
' ** Enterprise Design Pattern: Domain Model Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Chart
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("AccountCode"))
                AddRule(New ValidateRequired("AccountName"))
                AddRule(New ValidateRequired("AccountGroup"))
            End If
        End Sub

        Public Property AccountCode As String
        Public Property AccountGroup As String
        Public Property AccountName As String
        Public Property AccountNameAra As String
        Public Property Active As Boolean
        Public Property DetailAccount As Boolean
        Public Property IdNo As Integer
        Public Property LevelNumber As Int16
        Public Property NormalBalance As String
        Public Property Notes As String
        Public Property ParentIdNo As Integer?
        Public Property PayeeType As String
        Public Property SortKey As String
        Public Property SpecialAccount As String
        Public Property WithReconciliation As Boolean
    End Class

End Namespace