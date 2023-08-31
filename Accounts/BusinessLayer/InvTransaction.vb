' InvTransType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class InvTransaction
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("InvTransTypeIdNo"))
                AddRule(New ValidateRequired("WarehouseIdNo"))
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRequired("Notes"))
            End If
        End Sub

        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As Date
        Public Property IdNo As Int32
        Public Property InvTransTypeIdNo As Int16
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int16
        Public Property WarehouseIdNo As Int16
        Public Property WarehouseToIdNo As Int16?
        Public Property InvTransactionDetails As List(Of InvTransactionDetail)

    End Class

    Public Class InvRequest
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            'If GetRules().Count() = 0 Then
            '    ' establish business rules
            '    AddRule(New ValidateRequired("InvTransTypeIdNo"))
            '    AddRule(New ValidateRequired("WarehouseIdNo"))
            '    AddRule(New ValidateRequired("TransactionDate"))
            '    AddRule(New ValidateRequired("Notes"))
            'End If
        End Sub

        Public Property InvTransactionRequests As List(Of InvTransaction)
        Public Property WarehouseIdNo As Int16
    End Class

End Namespace