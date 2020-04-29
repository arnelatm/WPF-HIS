' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ProfitCenter
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("ProfitCenterName"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property ParentIdNo As Int32?
        Public Property ProfitCenterCode As String
        Public Property ProfitCenterName As String
        Public Property ProfitCenterNameAra As String
        Public Property ProfitCenterType As String
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class

End Namespace